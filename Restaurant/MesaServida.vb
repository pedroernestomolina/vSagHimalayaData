Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class Restaurant

            Enum TipoPedido
                ParaMesa = 0
                ParaLLevar = 1
            End Enum

            Enum TipoPedidoEnviando
                SiEnviado = 1
                NoEnviado = 0
            End Enum

            Enum TipoAnulacion As Integer
                Anulacion = 1
                CtaPendiente = 2
            End Enum

            Enum TipoMovimientoMesa
                PorCambio = 1   ' Por Cambio De Mesa
                PorUnion = 2    ' Union Entre Mesas
                PorTraslado = 3 ' Traslado De Pedido A Mesa
            End Enum

            Public Class MonitorMesas
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_mesa As CampoDato
                    Private f_ci_rif As CampoDato
                    Private f_auto_cliente As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Mesa() As CampoDato
                        Get
                            Return f_mesa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesa = value
                        End Set
                    End Property

                    ReadOnly Property _Mesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_Mesa._RetornarValor(Of String)() Is Nothing, "", Me.c_Mesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CiRif() As CampoDato
                        Get
                            Return Me.f_ci_rif
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_ci_rif = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' CEDULA / RIF  USADA PARA PODER VISUALIZAR MESA VIA MOVIL
                    ''' </summary>
                    ReadOnly Property _CiRif() As String
                        Get
                            Dim xv As String = IIf(Me.c_CiRif._RetornarValor(Of String)() Is Nothing, "", Me.c_CiRif._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoCliente() As CampoDato
                        Get
                            Return Me.f_auto_cliente
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_auto_cliente = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoCliente._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoCliente._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_Cliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Try
                                Dim xv As New FichaClientes.c_Clientes
                                xv.F_BuscarCargar(_AutoCliente)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase MONITOR DE MESAS - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Mesa = New CampoDato("mesa", 6)
                        Me.c_AutoCliente = New CampoDato("auto_cliente", 10)
                        Me.c_CiRif = New CampoDato("ci_rif", 12)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_Mesa._ContenidoCampo = xrow(.c_Mesa._NombreCampo)
                                If Not IsDBNull(xrow(.c_CiRif._NombreCampo)) Then
                                    .c_CiRif._ContenidoCampo = xrow(.c_CiRif._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_AutoCliente._NombreCampo)) Then
                                    .c_AutoCliente._ContenidoCampo = xrow(.c_AutoCliente._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("MONITOR DE MESAS - RESTAURANT " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarMonitor As String = "INSERT INTO Rest_Mesas (auto,mesa) values (@auto,@mesa)"

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarCargar(ByVal xmesa As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from rest_mesas where mesa=@xmesa", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@xmesa", xmesa)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Throw New Exception("MONITOR MESAS - RESTAURANT:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class TemporalVentasMesas

                Class c_Registro
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_Mesonero As CampoDato
                    Private f_unida As CampoDato
                    Private f_Mesa As CampoDato
                    Private f_Codigo_Plato As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_tasa_iva As CampoDato
                    Private f_importe As CampoDato
                    Private f_costo_total_neto As CampoDato
                    Private f_codigo_Mesonero As CampoDato
                    Private f_Mesonero As CampoDato
                    Private f_tipo_tasa As CampoDato
                    Private f_tipo_precio As CampoDato
                    Private f_Enviado As CampoDato
                    Private f_ParaLlevar As CampoDato
                    Private f_escombo As CampoDato
                    Private f_espesado As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_Hora As CampoDato
                    Private f_fecha As CampoDato
                    Private f_maquina As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_auto_mesa_monitor As CampoDato
                    Private f_id_seguridad As Byte()
                    Private f_detalle_plato As CampoDato


                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaPlato() As FastFood.Platos.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Platos
                                xv.F_CargarRegistro(_AutoPlato)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoMesonero() As CampoDato
                        Get
                            Return f_auto_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoMesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaMesonero() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Try
                                Dim xv As New FichaVendedores
                                xv.F_BuscarVendedor(_AutoMesonero)
                                Return xv.f_Vendedor.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Try
                                Dim xv As New FichaGlobal.c_Usuario
                                xv.F_BuscarRegistro(_AutoUsuario)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Jornada
                                xv.F_BuscarCargar(_AutoJornada)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.OperadorJornada
                                xv.F_BuscarCargar(_AutoOperador)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Unida() As CampoDato
                        Get
                            Return f_unida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_unida = value
                        End Set
                    End Property

                    ReadOnly Property _Unida() As String
                        Get
                            Dim xv As String = IIf(Me.c_Unida._RetornarValor(Of String)() Is Nothing, "", Me.c_Unida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Mesa() As CampoDato
                        Get
                            Return f_Mesa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Mesa = value
                        End Set
                    End Property

                    ReadOnly Property _Mesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_Mesa._RetornarValor(Of String)() Is Nothing, "", Me.c_Mesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_Codigo_Plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Codigo_Plato = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CantidadDespachar() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CantidadDespachar._ContenidoCampo Is Nothing, 0, Me.c_CantidadDespachar._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_neto._ContenidoCampo Is Nothing, 0, Me.f_precio_neto._RetornarValor(Of Decimal)())
                            Dim xp As New Precio(xv, _TasaIva)
                            Return xp
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa_iva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_Importe() As CampoDato
                        Get
                            Return f_importe
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_importe = value
                        End Set
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Importe._ContenidoCampo Is Nothing, 0, Me.c_Importe._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_total_neto = value
                        End Set
                    End Property

                    ReadOnly Property _CostoTotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CostoTotalNeto._ContenidoCampo Is Nothing, 0, Me.c_CostoTotalNeto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoNeto() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = Decimal.Round(_CostoTotalNeto / _CantidadDespachar, 2, MidpointRounding.AwayFromZero)
                            Return x
                        End Get
                    End Property

                    Property c_CodigoMesonero() As CampoDato
                        Get
                            Return f_codigo_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo_Mesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Mesonero() As CampoDato
                        Get
                            Return f_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _Mesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_Mesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_Mesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoTasa() As CampoDato
                        Get
                            Return f_tipo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasa() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasa._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasa._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    Property c_TipoPrecio() As CampoDato
                        Get
                            Return f_tipo_precio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_precio = value
                        End Set
                    End Property

                    ReadOnly Property _TipoPrecio() As FastFood.TipoPrecioFastFood
                        Get
                            Dim xv As String = IIf(Me.c_TipoPrecio._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoPrecio._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return FastFood.TipoPrecioFastFood.Precio_1
                                Case "2" : Return FastFood.TipoPrecioFastFood.Precio_2
                                Case "3" : Return FastFood.TipoPrecioFastFood.Precio_Oferta
                            End Select
                        End Get
                    End Property

                    Property c_Enviado() As CampoDato
                        Get
                            Return f_Enviado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Enviado = value
                        End Set
                    End Property

                    ReadOnly Property _FueEnviado() As TipoPedidoEnviando
                        Get
                            Dim xv As String = IIf(Me.c_Enviado._RetornarValor(Of String)() Is Nothing, "", Me.c_Enviado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoPedidoEnviando.NoEnviado
                                Case "1" : Return TipoPedidoEnviando.SiEnviado
                            End Select
                        End Get
                    End Property

                    Property c_ParaLlevar() As CampoDato
                        Get
                            Return f_ParaLlevar
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_ParaLlevar = value
                        End Set
                    End Property

                    ReadOnly Property _ParaLlevar() As TipoPedido
                        Get
                            Dim xv As String = IIf(Me.c_ParaLlevar._RetornarValor(Of String)() Is Nothing, "", Me.c_ParaLlevar._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoPedido.ParaLLevar
                                Case "1" : Return TipoPedido.ParaMesa
                            End Select
                        End Get
                    End Property

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    ReadOnly Property _EsCombo() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsCombo._RetornarValor(Of String)() Is Nothing, "", Me.c_EsCombo._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _EsPesado() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EsOferta._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return f_Hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.c_Hora._RetornarValor(Of String)() Is Nothing, "", Me.c_Hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaProceso._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaProceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_EquipoEstacion() As CampoDato
                        Get
                            Return f_maquina
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_maquina = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EquipoEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_EquipoEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoMonitorMesa() As CampoDato
                        Get
                            Return f_auto_mesa_monitor
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_mesa_monitor = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMonitorMesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoMonitorMesa._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoMonitorMesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Protected Friend Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Id() As Byte()
                        Get
                            Return Me._IdSeguridad
                        End Get
                    End Property

                    ReadOnly Property _TotalItem() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = Decimal.Round(Me._Importe + (Me._Importe * Me._TasaIva / 100), 2, MidpointRounding.AwayFromZero)
                            Return x
                        End Get
                    End Property

                    Property c_DetallePlato() As CampoDato
                        Get
                            Return f_detalle_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle_plato = value
                        End Set
                    End Property

                    ReadOnly Property _DetallePlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_DetallePlato._RetornarValor(Of String)() Is Nothing, "", Me.c_DetallePlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL MESAS / PEDIDOS - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoItem = New CampoDato("auto_item", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoMesonero = New CampoDato("Auto_Mesonero", 10)
                        Me.c_Unida = New CampoDato("Unida", 6)
                        Me.c_Mesa = New CampoDato("Mesa", 6)
                        Me.c_CodigoPlato = New CampoDato("codigo_plato", 15)
                        Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                        Me.c_CantidadDespachar = New CampoDato("cantidad")
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_TasaIva = New CampoDato("tasa_iva")
                        Me.c_Importe = New CampoDato("importe")
                        Me.c_CostoTotalNeto = New CampoDato("costo_total_neto")
                        Me.c_CodigoMesonero = New CampoDato("Codigo_Mesonero", 15)
                        Me.c_Mesonero = New CampoDato("Mesonero", 120)
                        Me.c_TipoTasa = New CampoDato("tipo_tasa", 1)
                        Me.c_TipoPrecio = New CampoDato("tipo_precio", 1)
                        Me.c_Enviado = New CampoDato("enviado", 1)
                        Me.c_ParaLlevar = New CampoDato("ParaLlevar", 1)
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_EsPesado = New CampoDato("espesado", 1)
                        Me.c_EsOferta = New CampoDato("esoferta", 1)
                        Me.c_Hora = New CampoDato("Hora", 10)
                        Me.c_FechaProceso = New CampoDato("fecha")
                        Me.c_EquipoEstacion = New CampoDato("maquina", 20)
                        Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                        Me.c_AutoMonitorMesa = New CampoDato("auto_mesa_monitor", 10)
                        Me.c_DetallePlato = New CampoDato("detalle_plato", 120)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                Me.M_Limpiar()

                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoMesonero._ContenidoCampo = xrow(.c_AutoMesonero._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_CantidadDespachar._ContenidoCampo = xrow(.c_CantidadDespachar._NombreCampo)
                                .c_CodigoMesonero._ContenidoCampo = xrow(.c_CodigoMesonero._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_Enviado._ContenidoCampo = xrow(.c_Enviado._NombreCampo)
                                .c_EquipoEstacion._ContenidoCampo = xrow(.c_EquipoEstacion._NombreCampo)
                                .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Importe._ContenidoCampo = xrow(.c_Importe._NombreCampo)
                                .c_Mesa._ContenidoCampo = xrow(.c_Mesa._NombreCampo)
                                .c_Mesonero._ContenidoCampo = xrow(.c_Mesonero._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_ParaLlevar._ContenidoCampo = xrow(.c_ParaLlevar._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoPrecio._ContenidoCampo = xrow(.c_TipoPrecio._NombreCampo)
                                .c_TipoTasa._ContenidoCampo = xrow(.c_TipoTasa._NombreCampo)
                                .c_Unida._ContenidoCampo = xrow(.c_Unida._NombreCampo)
                                .c_AutoMonitorMesa._ContenidoCampo = xrow(.c_AutoMonitorMesa._NombreCampo)
                                ._IdSeguridad = xrow("id_seguridad")
                                .c_DetallePlato._ContenidoCampo = xrow(.c_DetallePlato._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA RESTAURANT" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarPedido As String = "INSERT INTO Rest_TemporalMesas (" & _
                    "auto_item," & _
                    "auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "importe," & _
                    "costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario, auto_mesa_monitor, detalle_plato)" & _
                    " VALUES (" & _
                    "@auto_item," & _
                    "@auto_plato," & _
                    "@auto_usuario," & _
                    "@auto_jornada," & _
                    "@auto_operador," & _
                    "@auto_Mesonero," & _
                    "@Unida," & _
                    "@Mesa," & _
                    "@codigo_plato," & _
                    "@nombre_plato," & _
                    "@cantidad," & _
                    "@precio_neto," & _
                    "@tasa_iva," & _
                    "@importe," & _
                    "@costo_total_neto," & _
                    "@Codigo_Mesonero," & _
                    "@Mesonero," & _
                    "@tipo_tasa," & _
                    "@tipo_precio," & _
                    "@Enviado," & _
                    "@Parallevar," & _
                    "@escombo," & _
                    "@espesado," & _
                    "@esoferta," & _
                    "@Hora," & _
                    "@fecha," & _
                    "@maquina," & _
                    "@nombre_usuario, @auto_mesa_monitor, @detalle_plato)"


                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Public Class DevolucionAnulacion

                Class c_Registro
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_Mesonero As CampoDato
                    Private f_unida As CampoDato
                    Private f_Mesa As CampoDato
                    Private f_Codigo_Plato As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_tasa_iva As CampoDato
                    Private f_importe As CampoDato
                    Private f_costo_total_neto As CampoDato
                    Private f_codigo_Mesonero As CampoDato
                    Private f_Mesonero As CampoDato
                    Private f_tipo_tasa As CampoDato
                    Private f_tipo_precio As CampoDato
                    Private f_Enviado As CampoDato
                    Private f_ParaLlevar As CampoDato
                    Private f_escombo As CampoDato
                    Private f_espesado As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_Hora As CampoDato
                    Private f_fecha As CampoDato
                    Private f_maquina As CampoDato
                    Private f_nombre_usuario As CampoDato
                    'DEVOLUCION/ANULACION
                    Private f_auto_jornada_dev As CampoDato
                    Private f_auto_operador_dev As CampoDato
                    Private f_auto_usuario_dev As CampoDato
                    Private f_maquina_dev As CampoDato
                    Private f_Hora_dev As CampoDato
                    Private f_fecha_dev As CampoDato
                    Private f_motivo_dev As CampoDato
                    Private f_nombre_usuario_dev As CampoDato
                    Private f_nivel_clave_usada As CampoDato
                    Private f_auto_anulacion As CampoDato
                    Private f_tipo_anulacion As CampoDato


                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaPlato() As FastFood.Platos.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Platos
                                xv.F_CargarRegistro(_AutoPlato)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoMesonero() As CampoDato
                        Get
                            Return f_auto_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoMesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaMesonero() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Try
                                Dim xv As New FichaVendedores
                                xv.F_BuscarVendedor(_AutoMesonero)
                                Return xv.f_Vendedor.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Try
                                Dim xv As New FichaGlobal.c_Usuario
                                xv.F_BuscarRegistro(_AutoUsuario)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Jornada
                                xv.F_BuscarCargar(_AutoJornada)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.OperadorJornada
                                xv.F_BuscarCargar(_AutoOperador)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Unida() As CampoDato
                        Get
                            Return f_unida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_unida = value
                        End Set
                    End Property

                    ReadOnly Property _Unida() As String
                        Get
                            Dim xv As String = IIf(Me.c_Unida._RetornarValor(Of String)() Is Nothing, "", Me.c_Unida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Mesa() As CampoDato
                        Get
                            Return f_Mesa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Mesa = value
                        End Set
                    End Property

                    ReadOnly Property _Mesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_Mesa._RetornarValor(Of String)() Is Nothing, "", Me.c_Mesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_Codigo_Plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Codigo_Plato = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CantidadDespachar() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CantidadDespachar._ContenidoCampo Is Nothing, 0, Me.c_CantidadDespachar._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_neto._ContenidoCampo Is Nothing, 0, Me.f_precio_neto._RetornarValor(Of Decimal)())
                            Dim xp As New Precio(xv, _TasaIva)
                            Return xp
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa_iva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_Importe() As CampoDato
                        Get
                            Return f_importe
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_importe = value
                        End Set
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Importe._ContenidoCampo Is Nothing, 0, Me.c_Importe._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_total_neto = value
                        End Set
                    End Property

                    ReadOnly Property _CostoTotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CostoTotalNeto._ContenidoCampo Is Nothing, 0, Me.c_CostoTotalNeto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CodigoMesonero() As CampoDato
                        Get
                            Return f_codigo_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo_Mesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Mesonero() As CampoDato
                        Get
                            Return f_Mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Mesonero = value
                        End Set
                    End Property

                    ReadOnly Property _Mesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_Mesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_Mesonero._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoTasa() As CampoDato
                        Get
                            Return f_tipo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasa() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasa._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasa._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    Property c_TipoPrecio() As CampoDato
                        Get
                            Return f_tipo_precio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_precio = value
                        End Set
                    End Property

                    ReadOnly Property _TipoPrecio() As FastFood.TipoPrecioFastFood
                        Get
                            Dim xv As String = IIf(Me.c_TipoPrecio._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoPrecio._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return FastFood.TipoPrecioFastFood.Precio_1
                                Case "2" : Return FastFood.TipoPrecioFastFood.Precio_2
                                Case "3" : Return FastFood.TipoPrecioFastFood.Precio_Oferta
                            End Select
                        End Get
                    End Property

                    Property c_Enviado() As CampoDato
                        Get
                            Return f_Enviado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Enviado = value
                        End Set
                    End Property

                    ReadOnly Property _FueEnviado() As TipoPedidoEnviando
                        Get
                            Dim xv As String = IIf(Me.c_Enviado._RetornarValor(Of String)() Is Nothing, "", Me.c_Enviado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoPedidoEnviando.NoEnviado
                                Case "1" : Return TipoPedidoEnviando.SiEnviado
                            End Select
                        End Get
                    End Property

                    Property c_ParaLlevar() As CampoDato
                        Get
                            Return f_ParaLlevar
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_ParaLlevar = value
                        End Set
                    End Property

                    ReadOnly Property _ParaLlevar() As TipoPedido
                        Get
                            Dim xv As String = IIf(Me.c_ParaLlevar._RetornarValor(Of String)() Is Nothing, "", Me.c_ParaLlevar._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoPedido.ParaLLevar
                                Case "1" : Return TipoPedido.ParaMesa
                            End Select
                        End Get
                    End Property

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    ReadOnly Property _EsCombo() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsCombo._RetornarValor(Of String)() Is Nothing, "", Me.c_EsCombo._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _EsPesado() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EsOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EsOferta._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return f_Hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.c_Hora._RetornarValor(Of String)() Is Nothing, "", Me.c_Hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaProceso._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaProceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_EquipoEstacion() As CampoDato
                        Get
                            Return f_maquina
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_maquina = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EquipoEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_EquipoEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Property c_AutoJornadaDev() As CampoDato
                        Get
                            Return f_auto_jornada_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada_dev = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornadaDev._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornadaDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaJornadaDev() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Jornada
                                xv.F_BuscarCargar(_AutoJornadaDev)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperadorDev() As CampoDato
                        Get
                            Return f_auto_operador_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador_dev = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperadorDev._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperadorDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaOperadorDev() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.OperadorJornada
                                xv.F_BuscarCargar(_AutoOperadorDev)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuarioDev() As CampoDato
                        Get
                            Return f_auto_usuario_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario_dev = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuarioDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuarioDev._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuarioDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaUsuarioDev() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Try
                                Dim xv As New FichaGlobal.c_Usuario
                                xv.F_BuscarRegistro(_AutoUsuarioDev)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_EquipoEstacionDev() As CampoDato
                        Get
                            Return f_maquina_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_maquina_dev = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacionDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_EquipoEstacionDev._RetornarValor(Of String)() Is Nothing, "", Me.c_EquipoEstacionDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_HoraDev() As CampoDato
                        Get
                            Return f_Hora_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Hora_dev = value
                        End Set
                    End Property

                    ReadOnly Property _HoraDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_HoraDev._RetornarValor(Of String)() Is Nothing, "", Me.c_HoraDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaDev() As CampoDato
                        Get
                            Return f_fecha_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_dev = value
                        End Set
                    End Property

                    ReadOnly Property _FechaDev() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaDev._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaDev._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_MotivoDev() As CampoDato
                        Get
                            Return f_motivo_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_motivo_dev = value
                        End Set
                    End Property

                    ReadOnly Property _MotivoDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_MotivoDev._RetornarValor(Of String)() Is Nothing, "", Me.c_MotivoDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuarioDev() As CampoDato
                        Get
                            Return f_nombre_usuario_dev
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario_dev = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuarioDev() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuarioDev._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuarioDev._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoAnulacion() As CampoDato
                        Get
                            Return f_auto_anulacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_anulacion = value
                        End Set
                    End Property

                    ReadOnly Property _AutoAnulacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoAnulacion._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoAnulacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoAnulacion() As CampoDato
                        Get
                            Return f_tipo_anulacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_anulacion = value
                        End Set
                    End Property

                    ReadOnly Property _TipoAnulacion() As TipoAnulacion
                        Get
                            Dim xv As String = IIf(Me.c_TipoAnulacion._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoAnulacion._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "A" Then
                                Return TipoAnulacion.Anulacion
                            Else
                                Return TipoAnulacion.CtaPendiente
                            End If
                        End Get
                    End Property

                    Property c_NivelClaveUsada() As CampoDato
                        Get
                            Return f_nivel_clave_usada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nivel_clave_usada = value
                        End Set
                    End Property

                    ReadOnly Property _NivelClaveUsada() As NivelClave
                        Get
                            Dim xv As String = IIf(Me.c_NivelClaveUsada._RetornarValor(Of String)() Is Nothing, "", Me.c_NivelClaveUsada._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "1" : Return NivelClave.Maxima
                                Case "2" : Return NivelClave.Media
                                Case "3" : Return NivelClave.Minima
                                Case Else : Return NivelClave.SinClave
                            End Select
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase DEVOLUCION / ANULACION - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoItem = New CampoDato("auto_item", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoMesonero = New CampoDato("Auto_Mesonero", 10)
                        Me.c_Unida = New CampoDato("Unida", 6)
                        Me.c_Mesa = New CampoDato("Mesa", 6)
                        Me.c_CodigoPlato = New CampoDato("codigo_plato", 15)
                        Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                        Me.c_CantidadDespachar = New CampoDato("cantidad")
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_TasaIva = New CampoDato("tasa_iva")
                        Me.c_Importe = New CampoDato("importe")
                        Me.c_CostoTotalNeto = New CampoDato("costo_total_neto")
                        Me.c_CodigoMesonero = New CampoDato("Codigo_Mesonero", 15)
                        Me.c_Mesonero = New CampoDato("Mesonero", 120)
                        Me.c_TipoTasa = New CampoDato("tipo_tasa", 1)
                        Me.c_TipoPrecio = New CampoDato("tipo_precio", 1)
                        Me.c_Enviado = New CampoDato("enviado", 1)
                        Me.c_ParaLlevar = New CampoDato("ParaLlevar", 1)
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_EsPesado = New CampoDato("espesado", 1)
                        Me.c_EsOferta = New CampoDato("esoferta", 1)
                        Me.c_Hora = New CampoDato("Hora", 10)
                        Me.c_FechaProceso = New CampoDato("fecha")
                        Me.c_EquipoEstacion = New CampoDato("maquina", 20)
                        Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                        'DEVOLUCION / ANULACION
                        Me.c_AutoUsuarioDev = New CampoDato("auto_usuario_dev", 10)
                        Me.c_AutoJornadaDev = New CampoDato("auto_jornada_dev", 10)
                        Me.c_AutoOperadorDev = New CampoDato("auto_operador_dev", 10)
                        Me.c_EquipoEstacionDev = New CampoDato("maquina_dev", 20)
                        Me.c_HoraDev = New CampoDato("Hora_dev", 10)
                        Me.c_FechaDev = New CampoDato("fecha_dev")
                        Me.c_MotivoDev = New CampoDato("motivo_dev", 120)
                        Me.c_NombreUsuarioDev = New CampoDato("nombre_usuario_dev", 20)
                        Me.c_NivelClaveUsada = New CampoDato("nivel_clave_usada", 1)
                        Me.c_AutoAnulacion = New CampoDato("auto_anulacion", 10)
                        Me.c_TipoAnulacion = New CampoDato("tipo_anulacion", 1)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoMesonero._ContenidoCampo = xrow(.c_AutoMesonero._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_CantidadDespachar._ContenidoCampo = xrow(.c_CantidadDespachar._NombreCampo)
                                .c_CodigoMesonero._ContenidoCampo = xrow(.c_CodigoMesonero._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_Enviado._ContenidoCampo = xrow(.c_Enviado._NombreCampo)
                                .c_EquipoEstacion._ContenidoCampo = xrow(.c_EquipoEstacion._NombreCampo)
                                .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Importe._ContenidoCampo = xrow(.c_Importe._NombreCampo)
                                .c_Mesa._ContenidoCampo = xrow(.c_Mesa._NombreCampo)
                                .c_Mesonero._ContenidoCampo = xrow(.c_Mesonero._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_ParaLlevar._ContenidoCampo = xrow(.c_ParaLlevar._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoPrecio._ContenidoCampo = xrow(.c_TipoPrecio._NombreCampo)
                                .c_TipoTasa._ContenidoCampo = xrow(.c_TipoTasa._NombreCampo)
                                .c_Unida._ContenidoCampo = xrow(.c_Unida._NombreCampo)
                                'DEVOLUCION / ANULACION
                                .c_AutoJornadaDev._ContenidoCampo = xrow(.c_AutoJornadaDev._NombreCampo)
                                .c_AutoOperadorDev._ContenidoCampo = xrow(.c_AutoOperadorDev._NombreCampo)
                                .c_AutoUsuarioDev._ContenidoCampo = xrow(.c_AutoUsuarioDev._NombreCampo)
                                .c_EquipoEstacionDev._ContenidoCampo = xrow(.c_EquipoEstacionDev._NombreCampo)
                                .c_HoraDev._ContenidoCampo = xrow(.c_HoraDev._NombreCampo)
                                .c_FechaDev._ContenidoCampo = xrow(.c_FechaDev._NombreCampo)
                                .c_MotivoDev._ContenidoCampo = xrow(.c_MotivoDev._NombreCampo)
                                .c_NombreUsuarioDev._ContenidoCampo = xrow(.c_NombreUsuarioDev._NombreCampo)
                                .c_NivelClaveUsada._ContenidoCampo = xrow(.c_NivelClaveUsada._NombreCampo)
                                .c_AutoAnulacion._ContenidoCampo = xrow(.c_AutoAnulacion._NombreCampo)
                                .c_TipoAnulacion._ContenidoCampo = xrow(.c_TipoAnulacion._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("DEVOLUCION /ANULACION - RESTAURANT" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarPedido As String = "INSERT INTO Rest_TemporalMesas (" & _
                    "auto_item," & _
                    "auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "importe," & _
                    "costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario," & _
                    "auto_jornada_DEV," & _
                    "auto_operador_DEV," & _
                    "auto_usuario_DEV," & _
                    "Hora_DEV," & _
                    "fecha_DEV," & _
                    "maquina_DEV," & _
                    "motivo_DEV," & _
                    "nombre_usuario_DEV," & _
                    "nivel_clave_usada," & _
                    "auto_anulacion," & _
                    "tipo_anulacion)" & _
                    " VALUES (" & _
                    "@auto_item," & _
                    "@auto_plato," & _
                    "@auto_usuario," & _
                    "@auto_jornada," & _
                    "@auto_operador," & _
                    "@auto_Mesonero," & _
                    "@Unida," & _
                    "@Mesa," & _
                    "@codigo_plato," & _
                    "@nombre_plato," & _
                    "@cantidad," & _
                    "@precio_neto," & _
                    "@tasa_iva," & _
                    "@importe," & _
                    "@costo_total_neto," & _
                    "@Codigo_Mesonero," & _
                    "@Mesonero," & _
                    "@tipo_tasa," & _
                    "@tipo_precio," & _
                    "@Enviado," & _
                    "@Parallevar," & _
                    "@escombo," & _
                    "@espesado," & _
                    "@esoferta," & _
                    "@Hora," & _
                    "@fecha," & _
                    "@maquina," & _
                    "@nombre_usuario," & _
                    "@auto_jornada_DEV," & _
                    "@auto_operador_DEV," & _
                    "@auto_usuario_DEV," & _
                    "@Hora_DEV," & _
                    "@fecha_DEV," & _
                    "@maquina_DEV," & _
                    "@motivo_DEV," & _
                    "@nombre_usuario_DEV," & _
                    "@nivel_clave_usada," & _
                    "@auto_anulacion," & _
                    "@tipo_anulacion)"


                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Public Class CambioUnionMesas

                Class c_Registro
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_fecha As CampoDato
                    Private f_Hora As CampoDato
                    Private f_motivo As CampoDato
                    Private f_mesa_inicio As CampoDato
                    Private f_mesa_final As CampoDato
                    Private f_equipo As CampoDato
                    Private f_nivel_clave_usada As CampoDato
                    Private f_tipo_movimiento As CampoDato


                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.Jornada
                                xv.F_BuscarCargar(_AutoJornada)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As New FastFood.OperadorJornada
                                xv.F_BuscarCargar(_AutoOperador)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Try
                                Dim xv As New FichaGlobal.c_Usuario
                                xv.F_BuscarRegistro(_AutoUsuario)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaProceso._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaProceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return f_Hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.c_Hora._RetornarValor(Of String)() Is Nothing, "", Me.c_Hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Motivo() As CampoDato
                        Get
                            Return f_motivo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_motivo = value
                        End Set
                    End Property

                    ReadOnly Property _Motivo() As String
                        Get
                            Dim xv As String = IIf(Me.c_Motivo._RetornarValor(Of String)() Is Nothing, "", Me.c_Motivo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_DeLaMesa() As CampoDato
                        Get
                            Return f_mesa_inicio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesa_inicio = value
                        End Set
                    End Property

                    ReadOnly Property _DeLaMesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_DeLaMesa._RetornarValor(Of String)() Is Nothing, "", Me.c_DeLaMesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ParaLaMesa() As CampoDato
                        Get
                            Return f_mesa_final
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesa_final = value
                        End Set
                    End Property

                    ReadOnly Property _ParaLaMesa() As String
                        Get
                            Dim xv As String = IIf(Me.c_ParaLaMesa._RetornarValor(Of String)() Is Nothing, "", Me.c_ParaLaMesa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EquipoEstacion() As CampoDato
                        Get
                            Return f_equipo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_equipo = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EquipoEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_EquipoEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NivelClaveUsada() As CampoDato
                        Get
                            Return f_nivel_clave_usada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nivel_clave_usada = value
                        End Set
                    End Property

                    ReadOnly Property _NivelClaveUsada() As NivelClave
                        Get
                            Dim xv As String = IIf(Me.c_NivelClaveUsada._RetornarValor(Of String)() Is Nothing, "", Me.c_NivelClaveUsada._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "1" : Return NivelClave.Maxima
                                Case "2" : Return NivelClave.Media
                                Case "3" : Return NivelClave.Minima
                                Case Else : Return NivelClave.SinClave
                            End Select
                        End Get
                    End Property

                    Property c_TipoMovimiento() As CampoDato
                        Get
                            Return f_tipo_movimiento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_movimiento = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMovimientoMesa() As TipoMovimientoMesa
                        Get
                            Dim xv As String = IIf(Me.c_TipoMovimiento._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoMovimiento._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "C" : Return TipoMovimientoMesa.PorCambio
                                Case "U" : Return TipoMovimientoMesa.PorUnion
                            End Select
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase DEVOLUCION / ANULACION - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)
                        Me.c_DeLaMesa = New CampoDato("mesa_inicio", 6)
                        Me.c_EquipoEstacion = New CampoDato("equipo", 20)
                        Me.c_FechaProceso = New CampoDato("fecha")
                        Me.c_Hora = New CampoDato("hora", 10)
                        Me.c_Motivo = New CampoDato("motivo", 120)
                        Me.c_NivelClaveUsada = New CampoDato("nivel_clave_usada", 1)
                        Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                        Me.c_ParaLaMesa = New CampoDato("mesa_final", 6)
                        Me.c_TipoMovimiento = New CampoDato("tipo_movimiento", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_DeLaMesa._ContenidoCampo = xrow(.c_DeLaMesa._NombreCampo)
                                .c_EquipoEstacion._ContenidoCampo = xrow(.c_EquipoEstacion._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Motivo._ContenidoCampo = xrow(.c_Motivo._NombreCampo)
                                .c_NivelClaveUsada._ContenidoCampo = xrow(.c_NivelClaveUsada._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_ParaLaMesa._ContenidoCampo = xrow(.c_ParaLaMesa._NombreCampo)
                                .c_TipoMovimiento._ContenidoCampo = xrow(.c_TipoMovimiento._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("CAMBIO / UNION DE MESAS - RESTAURANT" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarCambioUnion As String = "INSERT INTO Rest_CambioUnionMesas (" & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_usuario," & _
                    "nombre_usuario," & _
                    "fecha," & _
                    "hora," & _
                    "motivo," & _
                    "mesa_inicio," & _
                    "mesa_final," & _
                    "equipo," & _
                    "nivel_clave_usada, tipo_movimiento) " & _
                    "VALUES(" & _
                    "@auto_jornada," & _
                    "@auto_operador," & _
                    "@auto_usuario," & _
                    "@nombre_usuario," & _
                    "@fecha," & _
                    "@hora," & _
                    "@motivo," & _
                    "@mesa_inicio," & _
                    "@mesa_final," & _
                    "@equipo," & _
                    "@nivel_clave_usada, @tipo_movimiento)"


                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

            End Class

            Public Class HistorialComandas

                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_estacion As CampoDato
                    Private f_mesonero_nombre As CampoDato
                    Private f_mesonero_codigo As CampoDato
                    Private f_mesa As CampoDato
                    Private f_fecha As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad_plato As CampoDato
                    Private f_detalle_plato As CampoDato
                    Private f_nombre_estacion As CampoDato
                    Private f_ruta_estacion As CampoDato
                    Private f_estatus_plato_envio As CampoDato
                    Private f_estatus_estacion_envio As CampoDato
                    Private f_parallevar As CampoDato


                    ''' <summary>
                    ''' AUTO HISTORIAL COMANDA
                    ''' </summary>
                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoEstacion() As CampoDato
                        Get
                            Return f_auto_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_MesoneroNombre() As CampoDato
                        Get
                            Return f_mesonero_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesonero_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _MesoneroNombre() As String
                        Get
                            Dim xv As String = IIf(Me.c_MesoneroNombre._RetornarValor(Of String)() Is Nothing, "", Me.c_MesoneroNombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_MesoneroCodigo() As CampoDato
                        Get
                            Return f_mesonero_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesonero_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _MesoneroCodigo() As String
                        Get
                            Dim xv As String = IIf(Me.c_MesoneroCodigo._RetornarValor(Of String)() Is Nothing, "", Me.c_MesoneroCodigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_MesPedido() As CampoDato
                        Get
                            Return f_mesa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_mesa = value
                        End Set
                    End Property

                    ReadOnly Property _MesaPedido() As String
                        Get
                            Dim xv As String = IIf(Me.c_MesPedido._RetornarValor(Of String)() Is Nothing, "", Me.c_MesPedido._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaProceso._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaProceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombrePlato._RetornarValor(Of String)() Is Nothing, "", Me.c_NombrePlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return f_cantidad_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad_plato = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Cantidad._ContenidoCampo Is Nothing, 0, Me.c_Cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_NotasDetalle() As CampoDato
                        Get
                            Return f_detalle_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle_plato = value
                        End Set
                    End Property

                    ReadOnly Property _NotasDetalle() As String
                        Get
                            Dim xv As String = IIf(Me.c_NotasDetalle._RetornarValor(Of String)() Is Nothing, "", Me.c_NotasDetalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreEstacion() As CampoDato
                        Get
                            Return f_nombre_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_RutaEstacion() As CampoDato
                        Get
                            Return f_ruta_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_ruta_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _RutaEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_RutaEstacion._RetornarValor(Of String)() Is Nothing, "", Me.c_RutaEstacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EstatusPlatoEnvio() As CampoDato
                        Get
                            Return f_estatus_plato_envio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus_plato_envio = value
                        End Set
                    End Property

                    Property c_EstatusEstacionEnvio() As CampoDato
                        Get
                            Return f_estatus_estacion_envio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus_estacion_envio = value
                        End Set
                    End Property

                    Property c_EsParallevar() As CampoDato
                        Get
                            Return f_parallevar
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_parallevar = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMovimiento() As Restaurant.TipoPedido
                        Get
                            Dim xv As String = IIf(Me.c_EsParallevar._RetornarValor(Of String)() Is Nothing, "", Me.c_EsParallevar._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "0" : Return TipoPedido.ParaMesa
                                Case "1" : Return TipoPedido.ParaLLevar
                            End Select
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase DEVOLUCION / ANULACION - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        With Me
                            .c_Auto = New CampoDato("auto", 10)
                            .c_AutoEstacion = New CampoDato("auto_estacion", 10)
                            .c_AutoItem = New CampoDato("auto_item", 10)
                            .c_AutoJornada = New CampoDato("auto_jornada", 10)
                            .c_AutoOperador = New CampoDato("auto_operador", 10)
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_Cantidad = New CampoDato("cantidad_plato")
                            .c_EsParallevar = New CampoDato("parallevar", 1)
                            .c_EstatusEstacionEnvio = New CampoDato("estatus_estacion_envio", 1)
                            .c_EstatusPlatoEnvio = New CampoDato("estatus_plato_envio", 1)
                            .c_FechaProceso = New CampoDato("fecha")
                            .c_MesoneroCodigo = New CampoDato("mesonero_codigo", 15)
                            .c_MesoneroNombre = New CampoDato("mesonero_nombre", 20)
                            .c_MesPedido = New CampoDato("mesa", 6)
                            .c_NombreEstacion = New CampoDato("nombre_estacion", 20)
                            .c_NombrePlato = New CampoDato("nombre_plato", 60)
                            .c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                            .c_NotasDetalle = New CampoDato("detalle_plato", 120)
                            .c_RutaEstacion = New CampoDato("ruta_estacion", 250)
                        End With
                        M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoEstacion._ContenidoCampo = xrow(.c_AutoEstacion._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_EsParallevar._ContenidoCampo = xrow(.c_EsParallevar._NombreCampo)
                                .c_EstatusEstacionEnvio._ContenidoCampo = xrow(.c_EstatusEstacionEnvio._NombreCampo)
                                .c_EstatusPlatoEnvio._ContenidoCampo = xrow(.c_EstatusPlatoEnvio._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_MesoneroCodigo._ContenidoCampo = xrow(.c_MesoneroCodigo._NombreCampo)
                                .c_MesoneroNombre._ContenidoCampo = xrow(.c_MesoneroNombre._NombreCampo)
                                .c_MesPedido._ContenidoCampo = xrow(.c_MesPedido._NombreCampo)
                                .c_NombreEstacion._ContenidoCampo = xrow(.c_NombreEstacion._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_NotasDetalle._ContenidoCampo = xrow(.c_NotasDetalle._NombreCampo)
                                .c_RutaEstacion._ContenidoCampo = xrow(.c_RutaEstacion._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("HISTORIAL COMANDAS - RESTAURANT" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class


                Dim xregistro As c_Registro

                Protected Friend Const InsertarHistorialComanda As String = "INSERT INTO Rest_HistorialComandas (" & _
                    "auto, " & _
                    "auto_jornada, " & _
                    "auto_operador, " & _
                    "auto_estacion, " & _
                    "mesonero_nombre, " & _
                    "mesonero_codigo, " & _
                    "mesa, " & _
                    "fecha, " & _
                    "nombre_usuario, " & _
                    "auto_item, " & _
                    "auto_plato, " & _
                    "nombre_plato, " & _
                    "cantidad_plato, " & _
                    "detalle_plato, " & _
                    "nombre_estacion, " & _
                    "ruta_estacion, " & _
                    "estatus_plato_envio, " & _
                    "estatus_estacion_envio, " & _
                    "parallevar) " & _
                    "VALUES (" & _
                    "@auto, " & _
                    "@auto_jornada, " & _
                    "@auto_operador, " & _
                    "@auto_estacion, " & _
                    "@mesonero_nombre, " & _
                    "@mesonero_codigo, " & _
                    "@mesa, " & _
                    "@fecha, " & _
                    "@nombre_usuario, " & _
                    "@auto_item, " & _
                    "@auto_plato, " & _
                    "@nombre_plato, " & _
                    "@cantidad_plato, " & _
                    "@detalle_plato, " & _
                    "@nombre_estacion, " & _
                    "@ruta_estacion, " & _
                    "@estatus_plato_envio, " & _
                    "@estatus_estacion_envio, " & _
                    "@parallevar)"


                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Public Class CtaMesaMovil
                Class c_Registro
                    Private f_mesa As CampoDato
                    Private f_id As CampoDato

                    Property c_Mesa() As CampoDato
                        Get
                            Return f_mesa
                        End Get
                        Set(ByVal value As CampoDato)
                            f_mesa = value
                        End Set
                    End Property

                    Property c_Id() As CampoDato
                        Get
                            Return f_id
                        End Get
                        Set(ByVal value As CampoDato)
                            f_id = value
                        End Set
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZA CLASE CTA MOVIL - RESTAURANT" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Id = New CampoDato("id")
                        Me.c_Mesa = New CampoDato("mesa", 6)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Mesa._ContenidoCampo = xrow(.c_Mesa._NombreCampo)
                                .c_Id._ContenidoCampo = xrow(.c_Id._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("HISTORIAL COMANDAS - RESTAURANT" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

            End Class

        End Class
    End Class
End Namespace
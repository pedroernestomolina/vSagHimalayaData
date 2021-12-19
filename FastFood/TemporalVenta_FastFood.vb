Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FastFood

            Public Enum TipoItemFastFood As Integer
                Plato = 1
                Producto = 2
            End Enum

            Public Class DevolucionAnulacion_FastFood
                Class c_Registro
                    Private f_auto_plato As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_codigo As CampoDato
                    Private f_tasa As CampoDato
                    Private f_costo_plato As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_venta As CampoDato
                    Private f_importe As CampoDato
                    Private f_estacion As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_hora As CampoDato
                    Private f_tipo_dev_anu As CampoDato
                    Private f_auto_anulacion As CampoDato
                    Private f_espesado As CampoDato
                    Private f_fecha As CampoDato
                    Private f_tipo_tasa As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_nivel_clave_usada As CampoDato

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa = value
                        End Set
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_plato = value
                        End Set
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_venta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_venta = value
                        End Set
                    End Property

                    Property c_Importe() As CampoDato
                        Get
                            Return f_importe
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_importe = value
                        End Set
                    End Property

                    Property c_EstacionEquipo() As CampoDato
                        Get
                            Return f_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estacion = value
                        End Set
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return f_hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_hora = value
                        End Set
                    End Property

                    Property c_TipoDevolucionAnulacion() As CampoDato
                        Get
                            Return f_tipo_dev_anu
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_dev_anu = value
                        End Set
                    End Property

                    Property c_AutoAnulacion() As CampoDato
                        Get
                            Return f_auto_anulacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_anulacion = value
                        End Set
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_TipoTasa() As CampoDato
                        Get
                            Return f_tipo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_tasa = value
                        End Set
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_NivelClaveProcesada() As CampoDato
                        Get
                            Return f_nivel_clave_usada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nivel_clave_usada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Codigo() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tasa._ContenidoCampo Is Nothing, 0, Me.f_tasa._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoTotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_plato._ContenidoCampo Is Nothing, 0, Me.f_costo_plato._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoPlato() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(Me._CostoTotalNeto / Me._Cantidad, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_cantidad._ContenidoCampo Is Nothing, 0, Me.f_cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_venta._ContenidoCampo Is Nothing, 0, Me.f_precio_venta._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_importe._ContenidoCampo Is Nothing, 0, Me.f_importe._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EstacionEquipo() As String
                        Get
                            Dim xv As String = IIf(Me.f_estacion._RetornarValor(Of String)() Is Nothing, "", Me.f_estacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora._RetornarValor(Of String)() Is Nothing, "", Me.f_hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Enum TipoDevolucionAnulacion
                        Devolucion = 1
                        Anulacion = 2
                        AnulacionPorPendiente = 3
                    End Enum

                    ReadOnly Property _TipoDevolucionAnulacion() As TipoDevolucionAnulacion
                        Get
                            Dim xv As String = IIf(Me.f_tipo_dev_anu._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_dev_anu._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "D" : Return TipoDevolucionAnulacion.Devolucion
                                Case "A" : Return TipoDevolucionAnulacion.Anulacion
                                Case "P" : Return TipoDevolucionAnulacion.AnulacionPorPendiente
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoAnulacion() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_anulacion._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_anulacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_espesado._RetornarValor(Of String)() Is Nothing, "", Me.f_espesado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.f_tipo_tasa._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_tasa._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_esoferta._RetornarValor(Of String)() Is Nothing, "", Me.f_esoferta._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Enum NivelClave As Integer
                        Maxima = 1
                        Media = 2
                        Minima = 3
                        SinClave = 0
                    End Enum

                    ReadOnly Property _NivelClaveProcesada() As NivelClave
                        Get
                            Dim xv As String = IIf(Me.f_nivel_clave_usada._RetornarValor(Of String)() Is Nothing, "", Me.f_nivel_clave_usada._RetornarValor(Of String)())
                            Select Case xv.Trim
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
                            Dim x As String = "Error Al Inicializar Clase DEVOLUCION / ANULACION - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        With Me
                            .c_AutoAnulacion = New CampoDato("auto_anulacion", 10)
                            .c_AutoJornada = New CampoDato("auto_jornada", 10)
                            .c_AutoOperador = New CampoDato("auto_operador", 10)
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_AutoUsuario = New CampoDato("auto_usuario", 10)
                            .c_Cantidad = New CampoDato("cantidad")
                            .c_CodigoPlato = New CampoDato("codigo", 10)
                            .c_CostoTotalNeto = New CampoDato("costo_plato")
                            .c_EsOferta = New CampoDato("esoferta", 1)
                            .c_EsPesado = New CampoDato("espesado", 1)
                            .c_EstacionEquipo = New CampoDato("estacion", 20)
                            .c_Fecha = New CampoDato("fecha")
                            .c_Hora = New CampoDato("hora", 10)
                            .c_Importe = New CampoDato("importe")
                            .c_NivelClaveProcesada = New CampoDato("nivel_clave_usada", 1)
                            .c_NombrePlato = New CampoDato("nombre_plato", 60)
                            .c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                            .c_PrecioNeto = New CampoDato("precio_venta")
                            .c_TasaIva = New CampoDato("tasa")
                            .c_TipoDevolucionAnulacion = New CampoDato("tipo_dev_anu", 1)
                            .c_TipoTasa = New CampoDato("tipo_tasa", 1)

                            .M_Limpiar()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoAnulacion._ContenidoCampo = xrow(.c_AutoAnulacion._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_EstacionEquipo._ContenidoCampo = xrow(.c_EstacionEquipo._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Importe._ContenidoCampo = xrow(.c_Importe._NombreCampo)
                                .c_NivelClaveProcesada._ContenidoCampo = xrow(.c_NivelClaveProcesada._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoDevolucionAnulacion._ContenidoCampo = xrow(.c_TipoDevolucionAnulacion._NombreCampo)
                                .c_TipoTasa._ContenidoCampo = xrow(.c_TipoTasa._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("DEVOLUCION / ANULACION - FASTFOOD " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_DEVANULACION_FASTFOOD As String = "INSERT INTO DevolucionAnulacionFastFood (" _
                    + "auto_plato" _
                    + ",nombre_plato" _
                    + ",codigo" _
                    + ",tasa" _
                    + ",espesado" _
                    + ",tipo_tasa" _
                    + ",costo_plato" _
                    + ",cantidad" _
                    + ",precio_venta" _
                    + ",importe" _
                    + ",estacion" _
                    + ",auto_usuario" _
                    + ",nombre_usuario" _
                    + ",hora" _
                    + ",tipo_dev_anu" _
                    + ",auto_anulacion" _
                    + ",esoferta" _
                    + ",auto_jornada" _
                    + ",auto_operador" _
                    + ",fecha, nivel_clave_usada) " _
                    + "VALUES(" _
                    + "@auto_plato" _
                    + ",@nombre_plato" _
                    + ",@codigo" _
                    + ",@tasa" _
                    + ",@espesado" _
                    + ",@tipo_tasa" _
                    + ",@costo_plato" _
                    + ",@cantidad" _
                    + ",@precio_venta" _
                    + ",@importe" _
                    + ",@estacion" _
                    + ",@auto_usuario" _
                    + ",@nombre_usuario" _
                    + ",@hora" _
                    + ",@tipo_dev_anu" _
                    + ",@auto_anulacion" _
                    + ",@esoferta" _
                    + ",@auto_jornada" _
                    + ",@auto_operador" _
                    + ",@fecha, @nivel_clave_usada) "

                Dim xregistro As c_Registro

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

            Public Class TemporalVenta_FastFood
                Enum TipoMovimiento As Integer
                    Agregar = 1
                    Devolucion = 2
                    Ajuste = 3
                End Enum

                Event _ActualizarTemporal()
                Event _VisorPrecioAgregar(ByVal xnombre As String, ByVal xcantidad As Decimal, ByVal xpneto As Decimal, ByVal xtipo As TipoMovimiento)
                Event _PedidoAnulado()
                Event _CtaPendiente()
                Event _VisorSubTotal()
                Event _CtaPendienteAnulada()
                Event _VisorItemAnulado(ByVal xproducto As String)


                Class c_Registro
                    Private f_codigo As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_tasa_iva As CampoDato
                    Private f_importe As CampoDato
                    Private f_espesado As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_tipo_tasa As CampoDato
                    Private f_fecha As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_estacion As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_escombo As CampoDato
                    Private f_detalle As CampoDato
                    Private f_costo_total_neto As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_auto_producto As CampoDato
                    Private f_tipo_item As CampoDato
                    Private f_empaque As CampoDato
                    Private f_contenido_empaque As CampoDato
                    Private f_auto_medida As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_tipo_precio As CampoDato

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_CantidadDespachar() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa_iva = value
                        End Set
                    End Property

                    Property c_Importe() As CampoDato
                        Get
                            Return f_importe
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_importe = value
                        End Set
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_TipoTasa() As CampoDato
                        Get
                            Return f_tipo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_tasa = value
                        End Set
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    Property c_EstacionEquipo() As CampoDato
                        Get
                            Return f_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estacion = value
                        End Set
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_total_neto = value
                        End Set
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    Property c_AutoProducto() As CampoDato
                        Get
                            Return f_auto_producto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_producto = value
                        End Set
                    End Property

                    Property c_TipoItem() As CampoDato
                        Get
                            Return f_tipo_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_item = value
                        End Set
                    End Property

                    Property c_NombreEmpaque() As CampoDato
                        Get
                            Return f_empaque
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_empaque = value
                        End Set
                    End Property

                    Property c_ContenidoEmpaque() As CampoDato
                        Get
                            Return f_contenido_empaque
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    Property c_AutoMedida() As CampoDato
                        Get
                            Return f_auto_medida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_medida = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_TipoPrecio() As CampoDato
                        Get
                            Return f_tipo_precio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_precio = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_item._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_item._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_medida._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_medida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_producto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_producto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_cantidad._ContenidoCampo Is Nothing, 0, Me.f_cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_contenido_empaque._ContenidoCampo Is Nothing, 0, Me.f_contenido_empaque._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoPlato() As Decimal
                        Get
                            Dim xr As Decimal = 0
                            xr = Me._CostoTotalItem / Me._CantidadDespachar
                            Return Decimal.Round(xr, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _CostoTotalItem() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_total_neto._ContenidoCampo Is Nothing, 0, Me.f_costo_total_neto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EsCombo() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_escombo._RetornarValor(Of String)() Is Nothing, "", Me.f_escombo._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_esoferta._RetornarValor(Of String)() Is Nothing, "", Me.f_esoferta._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_espesado._RetornarValor(Of String)() Is Nothing, "", Me.f_espesado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EstacionEquipo() As String
                        Get
                            Dim xv As String = IIf(Me.f_estacion._RetornarValor(Of String)() Is Nothing, "", Me.f_estacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim ximporte As Decimal = 0
                            ximporte = Me._PrecioNeto * Me._CantidadDespachar
                            Return Decimal.Round(ximporte, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _Impuesto() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = (_Importe * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Dim xv As String = IIf(Me.f_empaque._RetornarValor(Of String)() Is Nothing, "", Me.f_empaque._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' MUESTRA LAS OBSERVACIONES DADAS AL PLATO
                    ''' </summary>
                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_detalle._RetornarValor(Of String)() Is Nothing, "", Me.f_detalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _PFinal() As Decimal
                        Get
                            Dim xpfin As Decimal = 0
                            xpfin = Me._PrecioNeto
                            xpfin = Decimal.Round(xpfin, 2, MidpointRounding.AwayFromZero)
                            Return xpfin
                        End Get
                    End Property

                    ReadOnly Property _PFinalFullIva() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _PFinal + (_PFinal * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_neto._ContenidoCampo Is Nothing, 0, Me.f_precio_neto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tasa_iva._ContenidoCampo Is Nothing, 0, Me.f_tasa_iva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TipoItem() As TipoItemFastFood
                        Get
                            Dim xv As String = IIf(Me.f_tipo_item._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_item._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return TipoItemFastFood.Plato
                                Case "2" : Return TipoItemFastFood.Producto
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.f_tipo_tasa._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_tasa._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _Total() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _Importe + _Impuesto
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _TipoPrecio() As TipoPrecioFastFood
                        Get
                            Dim xv As String = IIf(Me.f_tipo_precio._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_precio._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return TipoPrecioFastFood.Precio_1
                                Case "2" : Return TipoPrecioFastFood.Precio_2
                                Case "3" : Return TipoPrecioFastFood.Precio_Oferta
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' RETORNA LAS NOTAS ADICONALES ASIGNADAS AL PLATO PARA LA COCINA / BARRA / ETC
                    ''' </summary>
                    Function f_NotasPlato() As String
                        Try
                            Dim xp1 As New SqlParameter("@auto_item", _AutoItem)
                            Dim xp2 As New SqlParameter("@auto_plato", _AutoPlato)
                            Dim xnota As String = F_GetString("select detalle from temporalventa_notasplato_fastfood where auto_item=@auto_item and auto_plato=@auto_plato", xp1, xp2)
                            Return xnota.Trim
                        Catch ex As Exception
                            Return ""
                        End Try
                    End Function

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoItem = New CampoDato("auto_item", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoMedida = New CampoDato("auto_medida", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_AutoProducto = New CampoDato("auto_producto", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)
                        Me.c_CantidadDespachar = New CampoDato("cantidad")
                        Me.c_CodigoPlato = New CampoDato("codigo", 15)
                        Me.c_ContenidoEmpaque = New CampoDato("contenido_empaque")
                        Me.c_CostoTotalNeto = New CampoDato("costo_total_neto")
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_EsOferta = New CampoDato("esoferta", 1)
                        Me.c_EsPesado = New CampoDato("espesado", 1)
                        Me.c_EstacionEquipo = New CampoDato("estacion", 20)
                        Me.c_FechaProceso = New CampoDato("fecha")
                        Me.c_Importe = New CampoDato("importe")
                        Me.c_NombreEmpaque = New CampoDato("empaque", 15)
                        Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                        Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                        Me.c_NotasItem = New CampoDato("detalle", 120)
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_TasaIva = New CampoDato("tasa_iva")
                        Me.c_TipoItem = New CampoDato("tipo_item", 1)
                        Me.c_TipoTasa = New CampoDato("tipo_tasa", 1)
                        Me.c_TipoPrecio = New CampoDato("tipo_precio", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoMedida._ContenidoCampo = xrow(.c_AutoMedida._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_CantidadDespachar._ContenidoCampo = xrow(.c_CantidadDespachar._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_ContenidoEmpaque._ContenidoCampo = xrow(.c_ContenidoEmpaque._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_EstacionEquipo._ContenidoCampo = xrow(.c_EstacionEquipo._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_Importe._ContenidoCampo = xrow(.c_Importe._NombreCampo)
                                .c_NombreEmpaque._ContenidoCampo = xrow(.c_NombreEmpaque._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                .c_TipoTasa._ContenidoCampo = xrow(.c_TipoTasa._NombreCampo)
                                .c_TipoPrecio._ContenidoCampo = xrow(.c_TipoPrecio._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA FAST FOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class AgregarItemTipoPlato
                    Private xplato As Platos.c_Registro
                    Private xcantidad As Decimal
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xjornada As String
                    Private xoperador As String
                    Private xcnf_precio As FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar

                    Property _Plato() As Platos.c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As Platos.c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _Cantidad() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _Estacion() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _Jornada() As String
                        Get
                            Return xjornada
                        End Get
                        Set(ByVal value As String)
                            xjornada = value
                        End Set
                    End Property

                    Property _Operador() As String
                        Get
                            Return xoperador
                        End Get
                        Set(ByVal value As String)
                            xoperador = value
                        End Set
                    End Property

                    Property _CnfPrecio() As FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar
                        Get
                            Return xcnf_precio
                        End Get
                        Set(ByVal value As FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar)
                            xcnf_precio = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema()
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TipoItem() As TipoItemFastFood
                        Get
                            Return TipoItemFastFood.Plato
                        End Get
                    End Property

                    Function f_NotasItem(Optional ByVal xauto_item As String = "") As String
                        Dim xdetalle As String = ""

                        If _Plato._PlatoTipoCombo = TipoSiNo.Si Then
                            Dim xtb As New DataTable
                            Dim xsql As String = "select * from menucombos_fastfood where auto_plato_combo=@auto"
                            Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", _Plato._Automatico)
                                xadap.Fill(xtb)
                            End Using

                            Dim xitem_combo As New PlatosCombos
                            For Each xrow In xtb.Rows
                                xitem_combo.M_CargarFicha(xrow)

                                If xdetalle <> "" Then
                                    xdetalle += " + "
                                End If
                                Dim xcant As String = ""
                                If _Plato._EstatusBalanza = TipoEstatus.Inactivo Then
                                    xcant = xitem_combo.RegistroDato._Cantidad.ToString.Split(",")(0)
                                End If
                                xdetalle += xcant + " " + xitem_combo.RegistroDato._NombrePlato
                            Next
                        Else
                            Dim xcant As String = ""
                            If _Plato._EstatusBalanza = TipoEstatus.Inactivo Then
                                xcant = _Cantidad.ToString.Split(",")(0)
                            End If
                            xdetalle = xcant + " " + _Plato._NombrePlato
                        End If
                        Return xdetalle
                    End Function

                    Sub New()
                        Me._Cantidad = 0
                        Me._CnfPrecio = 0
                        Me._Estacion = ""
                        Me._Jornada = ""
                        Me._Operador = ""
                        Me._Plato = Nothing
                        Me._Usuario = Nothing
                    End Sub
                End Class
                Class AgregarItemTipoProducto
                    Private xcantidad As Decimal
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xjornada As String
                    Private xoperador As String
                    Private xproducto As FichaProducto.Prd_Producto.c_Registro

                    Property _Cantidad() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _Estacion() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _Jornada() As String
                        Get
                            Return xjornada
                        End Get
                        Set(ByVal value As String)
                            xjornada = value
                        End Set
                    End Property

                    Property _Operador() As String
                        Get
                            Return xoperador
                        End Get
                        Set(ByVal value As String)
                            xoperador = value
                        End Set
                    End Property

                    Property _Producto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Return Me.xproducto
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                            Me.xproducto = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema()
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TipoItem() As TipoItemFastFood
                        Get
                            Return TipoItemFastFood.Producto
                        End Get
                    End Property

                    Sub New()
                        Me._Cantidad = 0
                        Me._Estacion = ""
                        Me._Jornada = ""
                        Me._Operador = ""
                        Me._Usuario = Nothing
                        Me._Producto = Nothing
                    End Sub
                End Class
                Class AjusteItem
                    Enum TipoAjusteFastFood As Integer
                        Incrementar = 1
                        Disminuir = 2
                        Ajustar_A = 3
                    End Enum

                    Private xitem As TemporalVenta_FastFood.c_Registro
                    Private xcantidad As Decimal
                    Private xajuste As TipoAjusteFastFood
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xnivel_clave As DevolucionAnulacion_FastFood.c_Registro.NivelClave

                    Property _Item() As TemporalVenta_FastFood.c_Registro
                        Get
                            Return xitem
                        End Get
                        Set(ByVal value As TemporalVenta_FastFood.c_Registro)
                            xitem = value
                        End Set
                    End Property

                    Property _Cantidad() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As TipoAjusteFastFood
                        Get
                            Return xajuste
                        End Get
                        Set(ByVal value As TipoAjusteFastFood)
                            xajuste = value
                        End Set
                    End Property

                    Function _NotasItem(ByVal xcantidad As Decimal) As String
                        Dim xdetalle As String = ""

                        If _Item._EsCombo = TipoSiNo.Si Then
                            Dim xtb As New DataTable
                            Dim xsql As String = "select * from menucombos_fastfood where auto_plato_combo=@auto"
                            Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", _Item._AutoPlato)
                                xadap.Fill(xtb)
                            End Using

                            Dim xitem_combo As New PlatosCombos
                            For Each xrow In xtb.Rows
                                xitem_combo.M_CargarFicha(xrow)

                                If xdetalle <> "" Then
                                    xdetalle += " + "
                                End If
                                Dim xcant As String = ""
                                If _Item._EsPesado = TipoSiNo.No Then
                                    xcant = xitem_combo.RegistroDato._Cantidad.ToString.Split(",")(0)
                                End If
                                xdetalle += xcant + " " + xitem_combo.RegistroDato._NombrePlato

                                Dim xp1 As New SqlParameter("@auto_item", _Item._AutoItem)
                                Dim xp2 As New SqlParameter("@auto_plato", xitem_combo.RegistroDato._AutoPlato)
                                Dim xnota As String = F_GetString("select detalle from temporalventa_notasplato_fastfood where auto_item=@auto_item and auto_plato=@auto_plato", xp1, xp2)
                                If xnota.Trim <> "" Then
                                    xdetalle += ": " + xnota.Trim
                                End If
                            Next
                        Else
                            Dim xcant As String = ""
                            If _Item._EsPesado = TipoSiNo.No Then
                                xcant = xcantidad.ToString.Split(",")(0)
                            End If
                            xdetalle = xcant + " " + _Item._NombrePlato

                            Dim xp1 As New SqlParameter("@auto_item", _Item._AutoItem)
                            Dim xp2 As New SqlParameter("@auto_plato", _Item._AutoPlato)
                            Dim xnota As String = F_GetString("select detalle from temporalventa_notasplato_fastfood where auto_item=@auto_item and auto_plato=@auto_plato", xp1, xp2)
                            If xnota.Trim <> "" Then
                                xdetalle += ": " + xnota.Trim
                            End If
                        End If
                        Return xdetalle
                    End Function

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    ReadOnly Property _EsDevolucion() As String
                        Get
                            Return "D"
                        End Get
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Property _NivelClaveUsada() As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                        Get
                            Return Me.xnivel_clave
                        End Get
                        Set(ByVal value As DevolucionAnulacion_FastFood.c_Registro.NivelClave)
                            Me.xnivel_clave = value
                        End Set
                    End Property

                    Sub New()
                        Me._Cantidad = 0
                        Me._Item = Nothing
                        Me._TipoMovimiento = 0
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EstacionEquipo = ""
                        Me._FichaUsuario = Nothing
                        Me._NivelClaveUsada = 0
                    End Sub
                End Class
                Class AnularPedido
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xitems As List(Of TemporalVenta_FastFood.c_Registro)
                    Private xnivel_clave As DevolucionAnulacion_FastFood.c_Registro.NivelClave

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _Items() As List(Of TemporalVenta_FastFood.c_Registro)
                        Get
                            Return xitems
                        End Get
                        Set(ByVal value As List(Of TemporalVenta_FastFood.c_Registro))
                            xitems = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _NivelClaveUsada() As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                        Get
                            Return Me.xnivel_clave
                        End Get
                        Set(ByVal value As DevolucionAnulacion_FastFood.c_Registro.NivelClave)
                            Me.xnivel_clave = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _EsAnulacion() As String
                        Get
                            Return "A"
                        End Get
                    End Property

                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EstacionEquipo = ""
                        Me._FichaUsuario = Nothing
                        Me._Items = Nothing
                        Me._NivelClaveUsada = 0
                    End Sub
                End Class
                Class AnularPendiente
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xnivel_clave As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                    Private xdocpendiente As String

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _NivelClaveUsada() As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                        Get
                            Return Me.xnivel_clave
                        End Get
                        Set(ByVal value As DevolucionAnulacion_FastFood.c_Registro.NivelClave)
                            Me.xnivel_clave = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Property _AutoDocPendiente() As String
                        Get
                            Return Me.xdocpendiente
                        End Get
                        Set(ByVal value As String)
                            Me.xdocpendiente = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _EsAnulacion() As String
                        Get
                            Return "P"
                        End Get
                    End Property

                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EstacionEquipo = ""
                        Me._FichaUsuario = Nothing
                        Me._NivelClaveUsada = 0
                        Me._AutoDocPendiente = ""
                    End Sub
                End Class
                Class AnularTodasPendientes
                    Enum TipoAnulacion As Integer
                        Todas = 1
                        SoloOperador = 2
                    End Enum

                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xnivel_clave As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                    Private xtipoanulacion As TipoAnulacion

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _NivelClaveUsada() As DevolucionAnulacion_FastFood.c_Registro.NivelClave
                        Get
                            Return Me.xnivel_clave
                        End Get
                        Set(ByVal value As DevolucionAnulacion_FastFood.c_Registro.NivelClave)
                            Me.xnivel_clave = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Property _TipoAnulacion() As TipoAnulacion
                        Get
                            Return xtipoanulacion
                        End Get
                        Set(ByVal value As TipoAnulacion)
                            xtipoanulacion = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _EsAnulacion() As String
                        Get
                            Return "P"
                        End Get
                    End Property

                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EstacionEquipo = ""
                        Me._FichaUsuario = Nothing
                        Me._NivelClaveUsada = 0
                        Me._TipoAnulacion = 0
                    End Sub
                End Class


                Protected Friend Const InsertRegistroTemporalVenta As String = "INSERT INTO TemporalVenta_FastFood (" _
                 + "Codigo, " _
                 + "nombre_plato, " _
                 + "Cantidad, " _
                 + "Precio_Neto, " _
                 + "Tasa_Iva, " _
                 + "Importe, " _
                 + "EsPesado, " _
                 + "Auto_Item, " _
                 + "Auto_plato, " _
                 + "Tipo_Tasa, " _
                 + "Auto_Usuario, " _
                 + "Nombre_Usuario, " _
                 + "Fecha, " _
                 + "Estacion, " _
                 + "Costo_total_neto, " _
                 + "escombo, " _
                 + "esoferta, " _
                 + "detalle, " _
                 + "auto_producto, " _
                 + "tipo_item, " _
                 + "auto_medida, " _
                 + "empaque, " _
                 + "contenido_empaque, " _
                 + "auto_operador, " _
                 + "auto_jornada, " _
                 + "tipo_precio) " _
                 + "VALUES (" _
                 + "@Codigo, " _
                 + "@nombre_plato, " _
                 + "@Cantidad, " _
                 + "@Precio_Neto, " _
                 + "@Tasa_Iva, " _
                 + "@Importe, " _
                 + "@EsPesado, " _
                 + "@Auto_Item," _
                 + "@Auto_plato, " _
                 + "@Tipo_Tasa, " _
                 + "@Auto_Usuario, " _
                 + "@Nombre_Usuario, " _
                 + "@Fecha, " _
                 + "@Estacion, " _
                 + "@Costo_total_neto, " _
                 + "@escombo, " _
                 + "@esoferta, " _
                 + "@detalle, " _
                 + "@auto_producto, " _
                 + "@tipo_item, " _
                 + "@auto_medida, " _
                 + "@empaque, " _
                 + "@contenido_empaque, " _
                 + "@auto_operador, " _
                 + "@auto_jornada, " _
                 + "@tipo_precio)"

                Dim xregistro As c_Registro

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

                Function F_AgregarPlato(ByVal xitem As AgregarItemTipoPlato) As Boolean
                    Try
                        Dim xreg As New TemporalVenta_FastFood.c_Registro
                        Dim xreg2 As New FastFood.TemporalVenta_NotasPlato_FastFood.c_Registro

                        With xreg 'TEMPORAL VENTA - FASTFOOD
                            .c_AutoItem._ContenidoCampo = ""
                            .c_AutoJornada._ContenidoCampo = xitem._Jornada
                            .c_AutoMedida._ContenidoCampo = ""
                            .c_AutoOperador._ContenidoCampo = xitem._Operador
                            .c_AutoPlato._ContenidoCampo = xitem._Plato._Automatico
                            .c_AutoProducto._ContenidoCampo = ""
                            .c_AutoUsuario._ContenidoCampo = xitem._Usuario._AutoUsuario
                            .c_CantidadDespachar._ContenidoCampo = xitem._Cantidad
                            .c_CodigoPlato._ContenidoCampo = xitem._Plato._CodigoPlato
                            .c_ContenidoEmpaque._ContenidoCampo = 0
                            .c_CostoTotalNeto._ContenidoCampo = Decimal.Round(xitem._Plato._CostoPlato * xitem._Cantidad, 2, MidpointRounding.AwayFromZero)
                            .c_EsCombo._ContenidoCampo = IIf(xitem._Plato._PlatoTipoCombo = TipoSiNo.Si, "1", "0")
                            .c_EsOferta._ContenidoCampo = IIf(xitem._Plato._PlatoEnOferta, "1", "0")
                            .c_EsPesado._ContenidoCampo = IIf(xitem._Plato._EstatusBalanza = TipoEstatus.Activo, "1", "0")
                            .c_EstacionEquipo._ContenidoCampo = xitem._Estacion
                            .c_FechaProceso._ContenidoCampo = xitem._Fecha
                            .c_Importe._ContenidoCampo = Decimal.Round(xitem._Plato._PrecioAFacturar(xitem._CnfPrecio)._Base * xitem._Cantidad, 2, MidpointRounding.AwayFromZero)
                            .c_NombreEmpaque._ContenidoCampo = ""
                            .c_NombrePlato._ContenidoCampo = xitem._Plato._NombrePlato
                            .c_NombreUsuario._ContenidoCampo = xitem._Usuario._NombreUsuario
                            .c_NotasItem._ContenidoCampo = xitem.f_NotasItem
                            .c_PrecioNeto._ContenidoCampo = xitem._Plato._PrecioAFacturar(xitem._CnfPrecio)._Base
                            .c_TasaIva._ContenidoCampo = xitem._Plato._TasaImpuesto
                            .c_TipoItem._ContenidoCampo = IIf(xitem._TipoItem = TipoItemFastFood.Plato, "1", "2")
                            Select Case xitem._Plato._PrecioAFacturar_Seleccionado
                                Case TipoPrecioFastFood.Precio_1 : .c_TipoPrecio._ContenidoCampo = "1"
                                Case TipoPrecioFastFood.Precio_2 : .c_TipoPrecio._ContenidoCampo = "2"
                                Case TipoPrecioFastFood.Precio_Oferta : .c_TipoPrecio._ContenidoCampo = "3"
                            End Select
                            .c_TipoTasa._ContenidoCampo = xitem._Plato.c_TipoImpuesto._ContenidoCampo
                        End With

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_fastfood=a_temporalventa_fastfood+1;select a_temporalventa_fastfood from contadores"
                                    xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xcmd.CommandText = InsertRegistroTemporalVenta
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoMedida._NombreCampo, xreg._AutoMedida).Size = xreg.c_AutoMedida._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                        .AddWithValue("@" + xreg.c_CantidadDespachar._NombreCampo, xreg._CantidadDespachar)
                                        .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._CodigoPlato).Size = xreg.c_CodigoPlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_ContenidoEmpaque._NombreCampo, xreg._ContenidoEmpaque)
                                        .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalItem)
                                        .AddWithValue("@" + xreg.c_EsCombo._NombreCampo, xreg.c_EsCombo._ContenidoCampo).Size = xreg.c_EsCombo._LargoCampo
                                        .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                        .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                        .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                        .AddWithValue("@" + xreg.c_FechaProceso._NombreCampo, xreg._FechaProceso)
                                        .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                        .AddWithValue("@" + xreg.c_NombreEmpaque._NombreCampo, xreg._NombreEmpaque).Size = xreg.c_NombreEmpaque._LargoCampo
                                        .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                        .AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg._NotasItem).Size = xreg.c_NotasItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                        .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                        .AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_TipoPrecio._NombreCampo, xreg.c_TipoPrecio._ContenidoCampo).Size = xreg.c_TipoPrecio._LargoCampo
                                        .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    If xreg._EsCombo = TipoSiNo.Si Then
                                        If xitem._Plato.f_AutoPlatos_Combo.Rows.Count > 0 Then
                                            For Each xrow In xitem._Plato.f_AutoPlatos_Combo.Rows
                                                xreg2.M_Limpiar()

                                                With xreg2 'TEMPORAL VENTA NOTAS DEL PLATO - FASTFOOD 
                                                    .c_AutoItem._ContenidoCampo = xreg._AutoItem
                                                    .c_AutoPlato._ContenidoCampo = xrow(0).ToString.Trim
                                                    .c_NotasItem._ContenidoCampo = ""
                                                End With

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = TemporalVenta_NotasPlato_FastFood.INSERT_TEMPORALVENTA_NOTAS
                                                With xcmd.Parameters
                                                    .AddWithValue("@" + xreg2.c_AutoItem._NombreCampo, xreg2._AutoItem).Size = xreg2.c_AutoItem._LargoCampo
                                                    .AddWithValue("@" + xreg2.c_AutoPlato._NombreCampo, xreg2._AutoPlato).Size = xreg2.c_AutoPlato._LargoCampo
                                                    .AddWithValue("@" + xreg2.c_NotasItem._NombreCampo, xreg2._NotasItem).Size = xreg2.c_NotasItem._LargoCampo
                                                End With
                                                xcmd.ExecuteNonQuery()
                                            Next
                                        End If
                                    Else
                                        With xreg2 'TEMPORAL VENTA NOTAS DEL PLATO - FASTFOOD 
                                            .c_AutoItem._ContenidoCampo = xreg._AutoItem
                                            .c_AutoPlato._ContenidoCampo = xreg._AutoPlato
                                            .c_NotasItem._ContenidoCampo = ""
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = TemporalVenta_NotasPlato_FastFood.INSERT_TEMPORALVENTA_NOTAS
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xreg2.c_AutoItem._NombreCampo, xreg2._AutoItem).Size = xreg2.c_AutoItem._LargoCampo
                                            .AddWithValue("@" + xreg2.c_AutoPlato._NombreCampo, xreg2._AutoPlato).Size = xreg2.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xreg2.c_NotasItem._NombreCampo, xreg2._NotasItem).Size = xreg2.c_NotasItem._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    End If

                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTemporal()
                                RaiseEvent _VisorPrecioAgregar(xreg._NombrePlato, xreg._CantidadDespachar, xreg._PrecioNeto, TipoMovimiento.Agregar)

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("TEMPORAL VENTAS FAST FOOD" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AgregarProducto(ByVal xitem As AgregarItemTipoProducto) As Boolean
                    Try
                        Dim xreg As New TemporalVenta_FastFood.c_Registro
                        Dim xreg2 As New FastFood.TemporalVenta_NotasPlato_FastFood.c_Registro
                        Dim xpnet As New Precio

                        If xitem._Producto.f_VerificarOferta Then
                            xpnet = xitem._Producto._PrecioOferta
                        Else
                            xpnet = xitem._Producto._PrecioDetal
                        End If

                        With xreg 'TEMPORAL VENTA - FASTFOOD
                            .c_AutoItem._ContenidoCampo = ""
                            .c_AutoJornada._ContenidoCampo = xitem._Jornada
                            .c_AutoMedida._ContenidoCampo = xitem._Producto._AutoEmpaqueVentaDetal
                            .c_AutoOperador._ContenidoCampo = xitem._Operador
                            .c_AutoPlato._ContenidoCampo = "PROD000001"
                            .c_AutoProducto._ContenidoCampo = xitem._Producto._AutoProducto
                            .c_AutoUsuario._ContenidoCampo = xitem._Usuario._AutoUsuario
                            .c_CantidadDespachar._ContenidoCampo = xitem._Cantidad
                            .c_CodigoPlato._ContenidoCampo = ""
                            .c_ContenidoEmpaque._ContenidoCampo = xitem._Producto._ContEmpqVentaDetal
                            .c_CostoTotalNeto._ContenidoCampo = Decimal.Round(xitem._Producto._CostoCompra._Base_Inv * xitem._Cantidad, 2, MidpointRounding.AwayFromZero)
                            .c_EsCombo._ContenidoCampo = "0"
                            .c_EsOferta._ContenidoCampo = IIf(xitem._Producto.f_VerificarOferta, "1", "0")
                            .c_EsPesado._ContenidoCampo = IIf(xitem._Producto._EsPesado = TipoEstatus.Activo, "1", "0")
                            .c_EstacionEquipo._ContenidoCampo = xitem._Estacion
                            .c_FechaProceso._ContenidoCampo = xitem._Fecha
                            .c_Importe._ContenidoCampo = Decimal.Round(xpnet._Base * xitem._Cantidad, 2, MidpointRounding.AwayFromZero)
                            .c_NombreEmpaque._ContenidoCampo = xitem._Producto._NombreEmpaqueVentaDetal
                            .c_NombrePlato._ContenidoCampo = xitem._Producto._DescripcionResumenDelProducto
                            .c_NombreUsuario._ContenidoCampo = xitem._Usuario._NombreUsuario
                            .c_NotasItem._ContenidoCampo = ""
                            .c_PrecioNeto._ContenidoCampo = xpnet._Base
                            .c_TasaIva._ContenidoCampo = xitem._Producto._TasaImpuesto
                            .c_TipoItem._ContenidoCampo = IIf(xitem._TipoItem = TipoItemFastFood.Plato, "1", "2")
                            .c_TipoPrecio._ContenidoCampo = "0"
                            .c_TipoTasa._ContenidoCampo = xitem._Producto.c_TipoImpuesto.c_Texto
                        End With

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_fastfood=a_temporalventa_fastfood+1;select a_temporalventa_fastfood from contadores"
                                    xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xcmd.CommandText = InsertRegistroTemporalVenta
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoMedida._NombreCampo, xreg._AutoMedida).Size = xreg.c_AutoMedida._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                        .AddWithValue("@" + xreg.c_CantidadDespachar._NombreCampo, xreg._CantidadDespachar)
                                        .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._CodigoPlato).Size = xreg.c_CodigoPlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_ContenidoEmpaque._NombreCampo, xreg._ContenidoEmpaque)
                                        .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalItem)
                                        .AddWithValue("@" + xreg.c_EsCombo._NombreCampo, xreg.c_EsCombo._ContenidoCampo).Size = xreg.c_EsCombo._LargoCampo
                                        .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                        .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                        .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                        .AddWithValue("@" + xreg.c_FechaProceso._NombreCampo, xreg._FechaProceso)
                                        .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                        .AddWithValue("@" + xreg.c_NombreEmpaque._NombreCampo, xreg._NombreEmpaque).Size = xreg.c_NombreEmpaque._LargoCampo
                                        .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                        .AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg._NotasItem).Size = xreg.c_NotasItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                        .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                        .AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_TipoPrecio._NombreCampo, xreg.c_TipoPrecio._ContenidoCampo).Size = xreg.c_TipoPrecio._LargoCampo
                                        .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTemporal()
                                RaiseEvent _VisorPrecioAgregar(xreg._NombrePlato, xreg._CantidadDespachar, xreg._PrecioNeto, TipoMovimiento.Agregar)

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("TEMPORAL VENTAS FAST FOOD" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function _ActualizarItemCantidad(ByVal xmov As AjusteItem) As Boolean
                    Try
                        Dim Anulacion As Boolean = False
                        Dim xreg As New DevolucionAnulacion_FastFood.c_Registro
                        Dim xcan, ximp, xcos, xdev As Decimal
                        xcan = ximp = xcos = xdev = 0

                        xcan = xmov._Item._CantidadDespachar
                        If xmov._TipoMovimiento = AjusteItem.TipoAjusteFastFood.Incrementar Then
                            xcan += xmov._Cantidad
                        ElseIf xmov._TipoMovimiento = AjusteItem.TipoAjusteFastFood.Disminuir Then
                            xcan -= xmov._Cantidad
                            xdev = xmov._Cantidad
                        ElseIf xmov._TipoMovimiento = AjusteItem.TipoAjusteFastFood.Ajustar_A Then
                            xcan = xmov._Cantidad
                            If xmov._Cantidad > xmov._Item._CantidadDespachar Then
                            Else
                                xdev = xmov._Item._CantidadDespachar - xmov._Cantidad
                            End If
                        End If
                        ximp = Decimal.Round(xcan * xmov._Item._PrecioNeto, 2, MidpointRounding.AwayFromZero)
                        xcos = Decimal.Round(xcan * xmov._Item._CostoPlato, 2, MidpointRounding.AwayFromZero)

                        With xreg
                            .c_AutoAnulacion._ContenidoCampo = ""
                            .c_AutoPlato._ContenidoCampo = xmov._Item._AutoPlato
                            .c_AutoUsuario._ContenidoCampo = xmov._FichaUsuario._AutoUsuario
                            .c_Cantidad._ContenidoCampo = xdev
                            .c_CodigoPlato._ContenidoCampo = xmov._Item._CodigoPlato
                            .c_CostoTotalNeto._ContenidoCampo = Decimal.Round(xdev * xmov._Item._CostoPlato, 2, MidpointRounding.AwayFromZero)
                            .c_EsPesado._ContenidoCampo = xmov._Item.c_EsPesado._ContenidoCampo
                            .c_EstacionEquipo._ContenidoCampo = xmov._EstacionEquipo
                            .c_Fecha._ContenidoCampo = xmov._Fecha
                            .c_Hora._ContenidoCampo = xmov._Hora
                            .c_Importe._ContenidoCampo = Decimal.Round(xdev * xmov._Item._PrecioNeto, 2, MidpointRounding.AwayFromZero)
                            .c_NombrePlato._ContenidoCampo = xmov._Item._NombrePlato
                            .c_NombreUsuario._ContenidoCampo = xmov._FichaUsuario._NombreUsuario
                            .c_PrecioNeto._ContenidoCampo = xmov._Item._PrecioNeto
                            .c_TasaIva._ContenidoCampo = xmov._Item._TasaIva
                            .c_TipoDevolucionAnulacion._ContenidoCampo = xmov._EsDevolucion
                            .c_TipoTasa._ContenidoCampo = xmov._Item._TipoTasa
                            .c_EsOferta._ContenidoCampo = xmov._Item.c_EsOferta._ContenidoCampo
                            .c_AutoJornada._ContenidoCampo = xmov._AutoJornada
                            .c_AutoOperador._ContenidoCampo = xmov._AutoOperador
                            Select Case xmov._NivelClaveUsada
                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Maxima : .c_NivelClaveProcesada._ContenidoCampo = "1"
                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Media : .c_NivelClaveProcesada._ContenidoCampo = "2"
                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Minima : .c_NivelClaveProcesada._ContenidoCampo = "3"
                                Case Else : .c_NivelClaveProcesada._ContenidoCampo = "0"
                            End Select
                        End With

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Dim xret As Integer = 0
                                Dim xvalor As Integer = 0
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "update temporalventa_fastfood set cantidad=@cantidad, importe=@importe, " & _
                                      "costo_total_neto=@costototalneto, detalle=@detalle where auto_item=@auto_item"
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@cantidad", xcan)
                                    xcmd.Parameters.AddWithValue("@importe", ximp)
                                    xcmd.Parameters.AddWithValue("@costototalneto", xcos)
                                    xcmd.Parameters.AddWithValue("@detalle", xmov._NotasItem(xcan))
                                    xcmd.Parameters.AddWithValue("@auto_item", xmov._Item._AutoItem)
                                    xret = xcmd.ExecuteNonQuery()
                                    If xret = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR ITEM - CANTIDAD")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT cantidad from temporalventa_fastfood where auto_item=@auto_item"
                                    xcmd.Parameters.AddWithValue("@auto_item", xmov._Item._AutoItem)
                                    xvalor = xcmd.ExecuteScalar()
                                    If xvalor = 0 Then
                                        Anulacion = True
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@auto_item", xmov._Item._AutoItem)
                                        xcmd.CommandText = "delete from temporalventa_NOTASPLATO_fastfood where auto_item=@auto_item"
                                        xret = xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@auto_item", xmov._Item._AutoItem)
                                        xcmd.CommandText = "delete from temporalventa_fastfood where auto_item=@auto_item"
                                        xret = xcmd.ExecuteNonQuery()
                                        If xret = 0 Then
                                            Throw New Exception("ERROR AL ELIMINAR ITEM")
                                        End If
                                    End If

                                    If xdev > 0 Then  ' SI FUE POR DEVOLUCION
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = DevolucionAnulacion_FastFood.INSERT_DEVANULACION_FASTFOOD
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xreg.c_AutoAnulacion._NombreCampo, xreg._AutoAnulacion).Size = xreg.c_AutoAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                            .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._Codigo).Size = xreg.c_CodigoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalNeto)
                                            .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                            .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                            .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                            .AddWithValue("@" + xreg.c_Fecha._NombreCampo, xreg._Fecha)
                                            .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                            .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                            .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                            .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                            .AddWithValue("@" + xreg.c_TipoDevolucionAnulacion._NombreCampo, xreg.c_TipoDevolucionAnulacion._ContenidoCampo).Size = xreg.c_TipoDevolucionAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                            .AddWithValue("@" + xreg.c_NivelClaveProcesada._NombreCampo, xreg.c_NivelClaveProcesada._ContenidoCampo).Size = xreg.c_NivelClaveProcesada._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    End If

                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTemporal()
                                If Anulacion Then
                                    RaiseEvent _VisorItemAnulado(xreg._NombrePlato)
                                Else
                                    RaiseEvent _VisorPrecioAgregar(xreg._NombrePlato, xcan, xmov._Item._PrecioNeto, xmov._TipoMovimiento)
                                End If

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("TEMPORAL VENTAS FAST FOOD" + vbCrLf + "ACTUALIZAR CANTIDAD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AnularPedido(ByVal xmov As AnularPedido) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xreg As New DevolucionAnulacion_FastFood.c_Registro

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_anulacion_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=a_temporalventa_anulacion_fastfood+1;select a_temporalventa_anulacion_fastfood from contadores"
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    For Each xitem As TemporalVenta_FastFood.c_Registro In xmov._Items
                                        xreg.M_Limpiar()

                                        With xreg
                                            .c_AutoAnulacion._ContenidoCampo = xauto
                                            .c_AutoPlato._ContenidoCampo = xitem._AutoPlato
                                            .c_AutoUsuario._ContenidoCampo = xmov._FichaUsuario._AutoUsuario
                                            .c_Cantidad._ContenidoCampo = xitem._CantidadDespachar
                                            .c_CodigoPlato._ContenidoCampo = xitem._CodigoPlato
                                            .c_CostoTotalNeto._ContenidoCampo = xitem._CostoTotalItem
                                            .c_EsPesado._ContenidoCampo = xitem.c_EsPesado._ContenidoCampo
                                            .c_EstacionEquipo._ContenidoCampo = xmov._EstacionEquipo
                                            .c_Fecha._ContenidoCampo = xmov._Fecha
                                            .c_Hora._ContenidoCampo = xmov._Hora
                                            .c_Importe._ContenidoCampo = xitem._Importe
                                            .c_NombrePlato._ContenidoCampo = xitem._NombrePlato
                                            .c_NombreUsuario._ContenidoCampo = xmov._FichaUsuario._NombreUsuario
                                            .c_PrecioNeto._ContenidoCampo = xitem._PrecioNeto
                                            .c_TasaIva._ContenidoCampo = xitem._TasaIva
                                            .c_TipoDevolucionAnulacion._ContenidoCampo = xmov._EsAnulacion
                                            .c_TipoTasa._ContenidoCampo = xitem.c_TipoTasa._ContenidoCampo
                                            .c_EsOferta._ContenidoCampo = xitem.c_EsOferta._ContenidoCampo
                                            .c_AutoJornada._ContenidoCampo = xmov._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xmov._AutoOperador
                                            Select Case xmov._NivelClaveUsada
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Maxima : .c_NivelClaveProcesada._ContenidoCampo = "1"
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Media : .c_NivelClaveProcesada._ContenidoCampo = "2"
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Minima : .c_NivelClaveProcesada._ContenidoCampo = "3"
                                                Case Else : .c_NivelClaveProcesada._ContenidoCampo = "0"
                                            End Select
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = DevolucionAnulacion_FastFood.INSERT_DEVANULACION_FASTFOOD
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xreg.c_AutoAnulacion._NombreCampo, xreg._AutoAnulacion).Size = xreg.c_AutoAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                            .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._Codigo).Size = xreg.c_CodigoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalNeto)
                                            .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                            .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                            .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                            .AddWithValue("@" + xreg.c_Fecha._NombreCampo, xreg._Fecha)
                                            .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                            .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                            .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                            .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                            .AddWithValue("@" + xreg.c_TipoDevolucionAnulacion._NombreCampo, xreg.c_TipoDevolucionAnulacion._ContenidoCampo).Size = xreg.c_TipoDevolucionAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                            .AddWithValue("@" + xreg.c_NivelClaveProcesada._NombreCampo, xreg.c_NivelClaveProcesada._ContenidoCampo).Size = xreg.c_NivelClaveProcesada._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@autoitem", xitem._AutoItem)
                                        xcmd.CommandText = "delete from temporalventa_notasplato_fastfood where auto_item=@autoitem"
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@autoitem", xitem._AutoItem)
                                        xcmd.CommandText = "delete from temporalventa_fastfood where auto_item=@autoitem"
                                        xcmd.ExecuteNonQuery()
                                    Next
                                End Using
                                xtr.Commit()

                                RaiseEvent _PedidoAnulado()
                                RaiseEvent _ActualizarTemporal()

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ERROR AL ANULAR PEDIDO FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_DejarPendiente(ByVal xpend As TemporalVentaPendiente_FastFood.AgregarCta) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xreg As New TemporalVentaPendiente_FastFood.c_Registro

                        With xreg
                            .c_AutoCliente._ContenidoCampo = xpend._AutoCliente
                            .c_AutoJornada._ContenidoCampo = xpend._AutoJornada
                            .c_AutoMovimiento._ContenidoCampo = ""
                            .c_AutoOperador._ContenidoCampo = xpend._AutoOperador
                            .c_AutoUsuario._ContenidoCampo = xpend._FichaUsuario._AutoUsuario
                            .c_EquipoEstacion._ContenidoCampo = xpend._EquipoEstacion
                            .c_Fecha._ContenidoCampo = xpend._Fecha
                            .c_Hora._ContenidoCampo = xpend._Hora
                            .c_Items._ContenidoCampo = xpend._Items
                            .c_MontoTotal._ContenidoCampo = xpend._Monto
                            .c_NombrePendiente._ContenidoCampo = xpend._NombrePendiente
                            .c_NombreUsuario._ContenidoCampo = xpend._FichaUsuario._NombreUsuario
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_pendiente_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_pendiente_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_pendiente_fastfood=a_temporalventa_pendiente_fastfood+1; " _
                                        + "select a_temporalventa_pendiente_fastfood from contadores"
                                    xreg.c_AutoMovimiento._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = TemporalVentaPendiente_FastFood.INSERT_TemporalVentaPendiente_FastFood
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xreg.c_AutoCliente._NombreCampo, xreg._AutoCliente).Size = xreg.c_AutoCliente._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoMovimiento._NombreCampo, xreg._AutoMovimiento).Size = xreg.c_AutoMovimiento._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                        .AddWithValue("@" + xreg.c_EquipoEstacion._NombreCampo, xreg._EquipoEstacion).Size = xreg.c_EquipoEstacion._LargoCampo
                                        .AddWithValue("@" + xreg.c_Fecha._NombreCampo, xreg._Fecha)
                                        .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                        .AddWithValue("@" + xreg.c_Items._NombreCampo, xreg._Items)
                                        .AddWithValue("@" + xreg.c_MontoTotal._NombreCampo, xreg._MontoTotal)
                                        .AddWithValue("@" + xreg.c_NombrePendiente._NombreCampo, xreg._NombrePendiente).Size = xreg.c_NombrePendiente._LargoCampo
                                        .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    Dim xit As Integer = 0
                                    For Each xdetalle As TemporalVenta_FastFood.c_Registro In xpend._ListaItems
                                        Dim xitem As New TemporalVentaPendienteDetalle_FastFood.c_Registro
                                        xit += 1

                                        With xitem
                                            .c_AutoItem._ContenidoCampo = xit.ToString
                                            .c_AutoMedida._ContenidoCampo = xdetalle._AutoMedida
                                            .c_AutoPendiente._ContenidoCampo = xreg.c_AutoMovimiento._ContenidoCampo
                                            .c_AutoPlato._ContenidoCampo = xdetalle._AutoPlato
                                            .c_AutoProducto._ContenidoCampo = xdetalle._AutoProducto
                                            .c_CantidadDespachar._ContenidoCampo = xdetalle._CantidadDespachar
                                            .c_CodigoPlato._ContenidoCampo = xdetalle._CodigoPlato
                                            .c_ContenidoEmpaque._ContenidoCampo = xdetalle._ContenidoEmpaque
                                            .c_CostoTotalNeto._ContenidoCampo = xdetalle._CostoTotalItem
                                            .c_EsCombo._ContenidoCampo = xdetalle.c_EsCombo._ContenidoCampo
                                            .c_EsOferta._ContenidoCampo = xdetalle.c_EsOferta._ContenidoCampo
                                            .c_EsPesado._ContenidoCampo = xdetalle.c_EsPesado._ContenidoCampo
                                            .c_Importe._ContenidoCampo = xdetalle._Importe
                                            .c_NombreEmpaque._ContenidoCampo = xdetalle._NombreEmpaque
                                            .c_NombrePlato._ContenidoCampo = xdetalle._NombrePlato
                                            .c_NotasItem._ContenidoCampo = xdetalle._NotasItem
                                            .c_PrecioNeto._ContenidoCampo = xdetalle._PrecioNeto
                                            .c_TasaIva._ContenidoCampo = xdetalle._TasaIva
                                            .c_TipoItem._ContenidoCampo = xdetalle.c_TipoItem._ContenidoCampo
                                            .c_TipoPrecio._ContenidoCampo = xdetalle.c_TipoPrecio._ContenidoCampo
                                            .c_TipoTasa._ContenidoCampo = xdetalle.c_TipoTasa._ContenidoCampo
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = TemporalVentaPendienteDetalle_FastFood.INSERT_TemporalVentaPendienteDetalle_FastFood
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xitem.c_AutoItem._NombreCampo, xitem._AutoItem).Size = xitem.c_AutoItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoPendiente._NombreCampo, xitem._AutoPendiente).Size = xitem.c_AutoPendiente._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoMedida._NombreCampo, xitem._AutoMedida).Size = xitem.c_AutoMedida._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoPlato._NombreCampo, xitem._AutoPlato).Size = xitem.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoProducto._NombreCampo, xitem._AutoProducto).Size = xitem.c_AutoProducto._LargoCampo
                                            .AddWithValue("@" + xitem.c_CantidadDespachar._NombreCampo, xitem._CantidadDespachar)
                                            .AddWithValue("@" + xitem.c_CodigoPlato._NombreCampo, xitem._CodigoPlato).Size = xitem.c_CodigoPlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_ContenidoEmpaque._NombreCampo, xitem._ContenidoEmpaque)
                                            .AddWithValue("@" + xitem.c_CostoTotalNeto._NombreCampo, xitem._CostoTotalItem)
                                            .AddWithValue("@" + xitem.c_EsCombo._NombreCampo, xitem.c_EsCombo._ContenidoCampo).Size = xitem.c_EsCombo._LargoCampo
                                            .AddWithValue("@" + xitem.c_EsOferta._NombreCampo, xitem.c_EsOferta._ContenidoCampo).Size = xitem.c_EsOferta._LargoCampo
                                            .AddWithValue("@" + xitem.c_EsPesado._NombreCampo, xitem.c_EsPesado._ContenidoCampo).Size = xitem.c_EsPesado._LargoCampo
                                            .AddWithValue("@" + xitem.c_Importe._NombreCampo, xitem._Importe)
                                            .AddWithValue("@" + xitem.c_NombreEmpaque._NombreCampo, xitem._NombreEmpaque).Size = xitem.c_NombreEmpaque._LargoCampo
                                            .AddWithValue("@" + xitem.c_NombrePlato._NombreCampo, xitem._NombrePlato).Size = xitem.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_NotasItem._NombreCampo, xitem._NotasItem).Size = xitem.c_NotasItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_PrecioNeto._NombreCampo, xitem._PrecioNeto)
                                            .AddWithValue("@" + xitem.c_TasaIva._NombreCampo, xitem._TasaIva)
                                            .AddWithValue("@" + xitem.c_TipoItem._NombreCampo, xitem.c_TipoItem._ContenidoCampo).Size = xitem.c_TipoItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_TipoPrecio._NombreCampo, xitem.c_TipoPrecio._ContenidoCampo).Size = xitem.c_TipoPrecio._LargoCampo
                                            .AddWithValue("@" + xitem.c_TipoTasa._NombreCampo, xitem.c_TipoTasa._ContenidoCampo).Size = xitem.c_TipoTasa._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()

                                        Dim xdtb As New DataTable
                                        Dim xreader As SqlDataReader
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select * from temporalventa_notasplato_fastfood where auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_item", xdetalle._AutoItem)
                                        xreader = xcmd.ExecuteReader
                                        xdtb.Load(xreader)

                                        Dim xnotas As New TemporalVenta_NotasPlato_FastFood
                                        Dim xnotaspend As New TemporalVentaPendiente_NotasPlato_FastFood.c_Registro
                                        For Each xdr In xdtb.Rows
                                            xnotas.M_CargarRegistro(xdr)

                                            xnotaspend.M_Limpiar()
                                            With xnotaspend
                                                .c_AutoPendiente._ContenidoCampo = xitem._AutoPendiente
                                                .c_AutoItem._ContenidoCampo = xitem._AutoItem
                                                .c_AutoPlato._ContenidoCampo = xnotas.RegistroDato._AutoPlato
                                                .c_NotasItem._ContenidoCampo = xnotas.RegistroDato._NotasItem
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = TemporalVentaPendiente_NotasPlato_FastFood.INSERT_TEMPORALVENTA_NOTAS_PENDIENTES
                                            With xcmd.Parameters
                                                .AddWithValue("@" + xnotaspend.c_AutoPendiente._NombreCampo, xnotaspend._AutoPendiente).Size = xnotaspend.c_AutoPendiente._LargoCampo
                                                .AddWithValue("@" + xnotaspend.c_AutoItem._NombreCampo, xnotaspend._AutoItem).Size = xnotaspend.c_AutoItem._LargoCampo
                                                .AddWithValue("@" + xnotaspend.c_AutoPlato._NombreCampo, xnotaspend._AutoPlato).Size = xnotaspend.c_AutoPlato._LargoCampo
                                                .AddWithValue("@" + xnotaspend.c_NotasItem._NombreCampo, xnotaspend._NotasItem).Size = xnotaspend.c_NotasItem._LargoCampo
                                            End With
                                            xcmd.ExecuteNonQuery()
                                        Next

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete from temporalventa_notasplato_fastfood where auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_item", xdetalle._AutoItem)
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete from temporalventa_fastfood where auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_item", xdetalle._AutoItem)
                                        xcmd.ExecuteNonQuery()
                                    Next
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTemporal()
                                RaiseEvent _CtaPendiente()

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("CUENTA PENDIENTE" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AbrirCtaPendiente(ByVal xctaabrir As TemporalVentaPendiente_FastFood.AbrirCta) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Dim xpdt As New FastFood.TemporalVentaPendienteDetalle_FastFood ' Temporal Pendiente Detalle
                        Dim xitem As New FastFood.TemporalVenta_FastFood.c_Registro  ' Temporal Detalle
                        Dim xntpdt As New TemporalVentaPendiente_NotasPlato_FastFood ' Notas Temporal Pendiente Detalle
                        Dim xntitem As New TemporalVenta_NotasPlato_FastFood.c_Registro ' Notas Temporal Detalle 

                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from temporalventa_pendientedetalle_fastfood where auto_doc=@auto_doc"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_doc", xctaabrir._DocPend_Abrir)
                            xadap.Fill(xtb)
                        End Using

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    For Each xrow As DataRow In xtb.Rows
                                        xpdt.M_CargarRegistro(xrow)

                                        xcmd.CommandText = "select a_temporalventa_fastfood from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_temporalventa_fastfood=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_temporalventa_fastfood=a_temporalventa_fastfood+1; " _
                                            + "select a_temporalventa_fastfood from contadores"
                                        xitem.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        With xitem
                                            .c_AutoPlato._ContenidoCampo = xpdt.RegistroDato._AutoPlato
                                            .c_AutoUsuario._ContenidoCampo = xctaabrir._FichaUsuario._AutoUsuario
                                            .c_CantidadDespachar._ContenidoCampo = xpdt.RegistroDato._CantidadDespachar
                                            .c_CodigoPlato._ContenidoCampo = xpdt.RegistroDato._CodigoPlato
                                            .c_CostoTotalNeto._ContenidoCampo = xpdt.RegistroDato._CostoTotalItem
                                            .c_EsPesado._ContenidoCampo = xpdt.RegistroDato.c_EsPesado._ContenidoCampo
                                            .c_EstacionEquipo._ContenidoCampo = xctaabrir._EquipoEstacion
                                            .c_FechaProceso._ContenidoCampo = xctaabrir._Fecha
                                            .c_NombrePlato._ContenidoCampo = xpdt.RegistroDato._NombrePlato
                                            .c_NombreUsuario._ContenidoCampo = xctaabrir._FichaUsuario._NombreUsuario
                                            .c_PrecioNeto._ContenidoCampo = xpdt.RegistroDato._PrecioNeto
                                            .c_TasaIva._ContenidoCampo = xpdt.RegistroDato._TasaIva
                                            .c_TipoTasa._ContenidoCampo = xpdt.RegistroDato.c_TipoTasa._ContenidoCampo
                                            .c_Importe._ContenidoCampo = xpdt.RegistroDato._Importe
                                            .c_EsCombo._ContenidoCampo = xpdt.RegistroDato.c_EsCombo._ContenidoCampo
                                            .c_NotasItem._ContenidoCampo = xpdt.RegistroDato._NotasItem
                                            .c_EsOferta._ContenidoCampo = xpdt.RegistroDato.c_EsOferta._ContenidoCampo
                                            .c_AutoProducto._ContenidoCampo = xpdt.RegistroDato._AutoProducto
                                            .c_TipoItem._ContenidoCampo = xpdt.RegistroDato.c_TipoItem._ContenidoCampo
                                            .c_AutoMedida._ContenidoCampo = xpdt.RegistroDato._AutoMedida
                                            .c_NombreEmpaque._ContenidoCampo = xpdt.RegistroDato._NombreEmpaque
                                            .c_ContenidoEmpaque._ContenidoCampo = xpdt.RegistroDato._ContenidoEmpaque
                                            .c_AutoJornada._ContenidoCampo = xctaabrir._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xctaabrir._AutoOperador
                                            .c_TipoPrecio._ContenidoCampo = xpdt.RegistroDato.c_TipoPrecio._ContenidoCampo
                                        End With

                                        xcmd.CommandText = FastFood.TemporalVenta_FastFood.InsertRegistroTemporalVenta
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xitem.c_AutoItem._NombreCampo, xitem._AutoItem).Size = xitem.c_AutoItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoJornada._NombreCampo, xitem._AutoJornada).Size = xitem.c_AutoJornada._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoMedida._NombreCampo, xitem._AutoMedida).Size = xitem.c_AutoMedida._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoOperador._NombreCampo, xitem._AutoOperador).Size = xitem.c_AutoOperador._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoPlato._NombreCampo, xitem._AutoPlato).Size = xitem.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoProducto._NombreCampo, xitem._AutoProducto).Size = xitem.c_AutoProducto._LargoCampo
                                            .AddWithValue("@" + xitem.c_AutoUsuario._NombreCampo, xitem._AutoUsuario).Size = xitem.c_AutoUsuario._LargoCampo
                                            .AddWithValue("@" + xitem.c_CantidadDespachar._NombreCampo, xitem._CantidadDespachar)
                                            .AddWithValue("@" + xitem.c_CodigoPlato._NombreCampo, xitem._CodigoPlato).Size = xitem.c_CodigoPlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_ContenidoEmpaque._NombreCampo, xitem._ContenidoEmpaque)
                                            .AddWithValue("@" + xitem.c_CostoTotalNeto._NombreCampo, xitem._CostoTotalItem)
                                            .AddWithValue("@" + xitem.c_EsCombo._NombreCampo, xitem.c_EsCombo._ContenidoCampo).Size = xitem.c_EsCombo._LargoCampo
                                            .AddWithValue("@" + xitem.c_EsOferta._NombreCampo, xitem.c_EsOferta._ContenidoCampo).Size = xitem.c_EsOferta._LargoCampo
                                            .AddWithValue("@" + xitem.c_EsPesado._NombreCampo, xitem.c_EsPesado._ContenidoCampo).Size = xitem.c_EsPesado._LargoCampo
                                            .AddWithValue("@" + xitem.c_EstacionEquipo._NombreCampo, xitem._EstacionEquipo).Size = xitem.c_EstacionEquipo._LargoCampo
                                            .AddWithValue("@" + xitem.c_FechaProceso._NombreCampo, xitem._FechaProceso)
                                            .AddWithValue("@" + xitem.c_Importe._NombreCampo, xitem._Importe)
                                            .AddWithValue("@" + xitem.c_NombreEmpaque._NombreCampo, xitem._NombreEmpaque).Size = xitem.c_NombreEmpaque._LargoCampo
                                            .AddWithValue("@" + xitem.c_NombrePlato._NombreCampo, xitem._NombrePlato).Size = xitem.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xitem.c_NombreUsuario._NombreCampo, xitem._NombreUsuario).Size = xitem.c_NombreUsuario._LargoCampo
                                            .AddWithValue("@" + xitem.c_NotasItem._NombreCampo, xitem._NotasItem).Size = xitem.c_NotasItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_PrecioNeto._NombreCampo, xitem._PrecioNeto)
                                            .AddWithValue("@" + xitem.c_TasaIva._NombreCampo, xitem._TasaIva)
                                            .AddWithValue("@" + xitem.c_TipoItem._NombreCampo, xitem.c_TipoItem._ContenidoCampo).Size = xitem.c_TipoItem._LargoCampo
                                            .AddWithValue("@" + xitem.c_TipoPrecio._NombreCampo, xitem.c_TipoPrecio._ContenidoCampo).Size = xitem.c_TipoPrecio._LargoCampo
                                            .AddWithValue("@" + xitem.c_TipoTasa._NombreCampo, xitem.c_TipoTasa._ContenidoCampo).Size = xitem.c_TipoTasa._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()

                                        Dim xreader As SqlDataReader
                                        Dim xdtb As New DataTable
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select * from temporalventa_pendientedetalle_notasplato_fastfood where auto_doc=@auto_doc and auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._DocPend_Abrir).Size = xpdt.RegistroDato.c_AutoPendiente._LargoCampo
                                        xcmd.Parameters.AddWithValue("@auto_item", xpdt.RegistroDato._AutoItem).Size = xpdt.RegistroDato.c_AutoItem._LargoCampo
                                        xreader = xcmd.ExecuteReader
                                        xdtb.Load(xreader)

                                        For Each xdr In xdtb.Rows
                                            xntpdt.M_CargarRegistro(xdr)

                                            xntitem.M_Limpiar()
                                            With xntitem
                                                .c_AutoItem._ContenidoCampo = xitem._AutoItem
                                                .c_AutoPlato._ContenidoCampo = xntpdt.RegistroDato._AutoPlato
                                                .c_NotasItem._ContenidoCampo = xntpdt.RegistroDato._NotasItem
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = TemporalVenta_NotasPlato_FastFood.INSERT_TEMPORALVENTA_NOTAS
                                            With xcmd.Parameters
                                                .AddWithValue("@" + xntitem.c_AutoItem._NombreCampo, xntitem._AutoItem).Size = xntitem.c_AutoItem._LargoCampo
                                                .AddWithValue("@" + xntitem.c_AutoPlato._NombreCampo, xntitem._AutoPlato).Size = xntitem.c_AutoPlato._LargoCampo
                                                .AddWithValue("@" + xntitem.c_NotasItem._NombreCampo, xntitem._NotasItem).Size = xntitem.c_NotasItem._LargoCampo
                                            End With
                                            xcmd.ExecuteNonQuery()
                                        Next
                                    Next

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporalventa_pendientedetalle_notasplato_fastfood where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._DocPend_Abrir)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporalventa_pendientedetalle_fastfood where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._DocPend_Abrir)
                                    xcmd.ExecuteNonQuery()

                                    Dim xret As Integer = 0
                                    If xctaabrir._PermitirAbrirCtasOtorsUsuarios Then
                                        xcmd.CommandText = "delete from temporalventa_pendiente_fastfood where auto_doc=@auto_doc"
                                    Else
                                        xcmd.CommandText = "delete from temporalventa_pendiente_fastfood where auto_doc=@auto_doc and auto_jornada=@jornada and auto_operador=@operador"
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._DocPend_Abrir)
                                    xcmd.Parameters.AddWithValue("@jornada", xctaabrir._AutoJornada)
                                    xcmd.Parameters.AddWithValue("@operador", xctaabrir._AutoOperador)
                                    xret = xcmd.ExecuteNonQuery()

                                    If xret = 0 Then
                                        Throw New Exception("ERROR AL ABRIR CTA PENDIENTE:" + vbCrLf + "ABIERTA POR OTRO USUARIO / NO PUEDES ABRIR CTAS DE OTROS USUARIOS")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTemporal()
                                RaiseEvent _VisorSubTotal()

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ABRIR CUENTA PENDIENTE - FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AnularPendiente(ByVal xmov As AnularPendiente) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xreg As New DevolucionAnulacion_FastFood.c_Registro
                        Dim xtb As New DataTable
                        Dim xdr As SqlDataReader = Nothing
                        Dim xit_pend As New TemporalVentaPendienteDetalle_FastFood
                        Dim xr As Integer = 0

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_anulacion_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=a_temporalventa_anulacion_fastfood+1;select a_temporalventa_anulacion_fastfood from contadores"
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from TemporalVenta_PendienteDetalle_FastFood where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xmov._AutoDocPendiente)
                                    xdr = xcmd.ExecuteReader()
                                    xtb.Load(xdr)
                                    xdr.Close()

                                    For Each xitem In xtb.Rows
                                        xit_pend.M_CargarRegistro(xitem)
                                        xreg.M_Limpiar()

                                        With xreg
                                            .c_AutoAnulacion._ContenidoCampo = xauto
                                            .c_AutoPlato._ContenidoCampo = xit_pend.RegistroDato._AutoPlato
                                            .c_AutoUsuario._ContenidoCampo = xmov._FichaUsuario._AutoUsuario
                                            .c_Cantidad._ContenidoCampo = xit_pend.RegistroDato._CantidadDespachar
                                            .c_CodigoPlato._ContenidoCampo = xit_pend.RegistroDato._CodigoPlato
                                            .c_CostoTotalNeto._ContenidoCampo = xit_pend.RegistroDato._CostoTotalItem
                                            .c_EsPesado._ContenidoCampo = xit_pend.RegistroDato.c_EsPesado._ContenidoCampo
                                            .c_EstacionEquipo._ContenidoCampo = xmov._EstacionEquipo
                                            .c_Fecha._ContenidoCampo = xmov._Fecha
                                            .c_Hora._ContenidoCampo = xmov._Hora
                                            .c_Importe._ContenidoCampo = xit_pend.RegistroDato._Importe
                                            .c_NombrePlato._ContenidoCampo = xit_pend.RegistroDato._NombrePlato
                                            .c_NombreUsuario._ContenidoCampo = xmov._FichaUsuario._NombreUsuario
                                            .c_PrecioNeto._ContenidoCampo = xit_pend.RegistroDato._PrecioNeto
                                            .c_TasaIva._ContenidoCampo = xit_pend.RegistroDato._TasaIva
                                            .c_TipoDevolucionAnulacion._ContenidoCampo = xmov._EsAnulacion
                                            .c_TipoTasa._ContenidoCampo = xit_pend.RegistroDato.c_TipoTasa._ContenidoCampo
                                            .c_EsOferta._ContenidoCampo = xit_pend.RegistroDato.c_EsOferta._ContenidoCampo
                                            .c_AutoJornada._ContenidoCampo = xmov._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xmov._AutoOperador
                                            Select Case xmov._NivelClaveUsada
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Maxima : .c_NivelClaveProcesada._ContenidoCampo = "1"
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Media : .c_NivelClaveProcesada._ContenidoCampo = "2"
                                                Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Minima : .c_NivelClaveProcesada._ContenidoCampo = "3"
                                                Case Else : .c_NivelClaveProcesada._ContenidoCampo = "0"
                                            End Select
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = DevolucionAnulacion_FastFood.INSERT_DEVANULACION_FASTFOOD
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xreg.c_AutoAnulacion._NombreCampo, xreg._AutoAnulacion).Size = xreg.c_AutoAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                            .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._Codigo).Size = xreg.c_CodigoPlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalNeto)
                                            .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                            .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                            .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                            .AddWithValue("@" + xreg.c_Fecha._NombreCampo, xreg._Fecha)
                                            .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                            .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                            .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                            .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                            .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                            .AddWithValue("@" + xreg.c_TipoDevolucionAnulacion._NombreCampo, xreg.c_TipoDevolucionAnulacion._ContenidoCampo).Size = xreg.c_TipoDevolucionAnulacion._LargoCampo
                                            .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                            .AddWithValue("@" + xreg.c_NivelClaveProcesada._NombreCampo, xreg.c_NivelClaveProcesada._ContenidoCampo).Size = xreg.c_NivelClaveProcesada._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_doc", xmov._AutoDocPendiente)
                                    xcmd.CommandText = "delete from TemporalVenta_PendienteDetalle_NotasPlato_Fastfood where auto_doc=@auto_doc"
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_doc", xmov._AutoDocPendiente)
                                    xcmd.CommandText = "delete from TemporalVenta_PendienteDetalle_FastFood where auto_doc=@auto_doc"
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_doc", xmov._AutoDocPendiente)
                                    xcmd.CommandText = "delete from TemporalVenta_Pendiente_FastFood where auto_doc=@auto_doc"
                                    xr = xcmd.ExecuteNonQuery()

                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL TRATAR DE ELIMINAR PEDIDO PENDIENTE." + vbCrLf + "FUE ELIMINDAO POR OTRO USUARIO / NO ENCONTRADO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _CtaPendienteAnulada()
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ERROR AL ANULAR PEDIDO FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_AnularTodasPendiente(ByVal xmov As AnularTodasPendientes) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xreg As New DevolucionAnulacion_FastFood.c_Registro
                        Dim xtb As New DataTable
                        Dim xdr As SqlDataReader = Nothing
                        Dim xit_pend As New TemporalVentaPendienteDetalle_FastFood
                        Dim xr As Integer = 0

                        Dim xsql As String = ""
                        If xmov._TipoAnulacion = AnularTodasPendientes.TipoAnulacion.SoloOperador Then
                            xsql = "select auto_doc from TemporalVenta_Pendiente_FastFood where auto_operador=@operador"
                        Else
                            xsql = "select auto_doc from TemporalVenta_Pendiente_FastFood"
                        End If
                        Dim xtb_doc As New DataTable
                        Using xadapta As New SqlDataAdapter("", _MiCadenaConexion)
                            xadapta.SelectCommand.CommandText = xsql
                            xadapta.SelectCommand.Parameters.AddWithValue("@operador", xmov._AutoOperador)
                            xadapta.Fill(xtb_doc)
                        End Using


                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                For Each xrd As DataRow In xtb_doc.Rows
                                    Dim xdoc As String = xrd(0).ToString.Trim

                                    Using xcmd As New SqlCommand("", xcon, xtr)
                                        xcmd.CommandText = "select a_temporalventa_anulacion_fastfood from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_temporalventa_anulacion_fastfood=a_temporalventa_anulacion_fastfood+1;select a_temporalventa_anulacion_fastfood from contadores"
                                        xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select * from TemporalVenta_PendienteDetalle_FastFood where auto_doc=@auto_doc"
                                        xcmd.Parameters.AddWithValue("@auto_doc", xdoc)
                                        xdr = xcmd.ExecuteReader()
                                        xtb.Load(xdr)
                                        xdr.Close()

                                        For Each xitem In xtb.Rows
                                            xit_pend.M_CargarRegistro(xitem)
                                            xreg.M_Limpiar()

                                            With xreg
                                                .c_AutoAnulacion._ContenidoCampo = xauto
                                                .c_AutoPlato._ContenidoCampo = xit_pend.RegistroDato._AutoPlato
                                                .c_AutoUsuario._ContenidoCampo = xmov._FichaUsuario._AutoUsuario
                                                .c_Cantidad._ContenidoCampo = xit_pend.RegistroDato._CantidadDespachar
                                                .c_CodigoPlato._ContenidoCampo = xit_pend.RegistroDato._CodigoPlato
                                                .c_CostoTotalNeto._ContenidoCampo = xit_pend.RegistroDato._CostoTotalItem
                                                .c_EsPesado._ContenidoCampo = xit_pend.RegistroDato.c_EsPesado._ContenidoCampo
                                                .c_EstacionEquipo._ContenidoCampo = xmov._EstacionEquipo
                                                .c_Fecha._ContenidoCampo = xmov._Fecha
                                                .c_Hora._ContenidoCampo = xmov._Hora
                                                .c_Importe._ContenidoCampo = xit_pend.RegistroDato._Importe
                                                .c_NombrePlato._ContenidoCampo = xit_pend.RegistroDato._NombrePlato
                                                .c_NombreUsuario._ContenidoCampo = xmov._FichaUsuario._NombreUsuario
                                                .c_PrecioNeto._ContenidoCampo = xit_pend.RegistroDato._PrecioNeto
                                                .c_TasaIva._ContenidoCampo = xit_pend.RegistroDato._TasaIva
                                                .c_TipoDevolucionAnulacion._ContenidoCampo = xmov._EsAnulacion
                                                .c_TipoTasa._ContenidoCampo = xit_pend.RegistroDato.c_TipoTasa._ContenidoCampo
                                                .c_EsOferta._ContenidoCampo = xit_pend.RegistroDato.c_EsOferta._ContenidoCampo
                                                .c_AutoJornada._ContenidoCampo = xmov._AutoJornada
                                                .c_AutoOperador._ContenidoCampo = xmov._AutoOperador
                                                Select Case xmov._NivelClaveUsada
                                                    Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Maxima : .c_NivelClaveProcesada._ContenidoCampo = "1"
                                                    Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Media : .c_NivelClaveProcesada._ContenidoCampo = "2"
                                                    Case DevolucionAnulacion_FastFood.c_Registro.NivelClave.Minima : .c_NivelClaveProcesada._ContenidoCampo = "3"
                                                    Case Else : .c_NivelClaveProcesada._ContenidoCampo = "0"
                                                End Select
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = DevolucionAnulacion_FastFood.INSERT_DEVANULACION_FASTFOOD
                                            With xcmd.Parameters
                                                .AddWithValue("@" + xreg.c_AutoAnulacion._NombreCampo, xreg._AutoAnulacion).Size = xreg.c_AutoAnulacion._LargoCampo
                                                .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                                .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                                .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                                .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                                .AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                                .AddWithValue("@" + xreg.c_CodigoPlato._NombreCampo, xreg._Codigo).Size = xreg.c_CodigoPlato._LargoCampo
                                                .AddWithValue("@" + xreg.c_CostoTotalNeto._NombreCampo, xreg._CostoTotalNeto)
                                                .AddWithValue("@" + xreg.c_EsOferta._NombreCampo, xreg.c_EsOferta._ContenidoCampo).Size = xreg.c_EsOferta._LargoCampo
                                                .AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                                .AddWithValue("@" + xreg.c_EstacionEquipo._NombreCampo, xreg._EstacionEquipo).Size = xreg.c_EstacionEquipo._LargoCampo
                                                .AddWithValue("@" + xreg.c_Fecha._NombreCampo, xreg._Fecha)
                                                .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                                .AddWithValue("@" + xreg.c_Importe._NombreCampo, xreg._Importe)
                                                .AddWithValue("@" + xreg.c_NombrePlato._NombreCampo, xreg._NombrePlato).Size = xreg.c_NombrePlato._LargoCampo
                                                .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                                .AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioNeto)
                                                .AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                                .AddWithValue("@" + xreg.c_TipoDevolucionAnulacion._NombreCampo, xreg.c_TipoDevolucionAnulacion._ContenidoCampo).Size = xreg.c_TipoDevolucionAnulacion._LargoCampo
                                                .AddWithValue("@" + xreg.c_TipoTasa._NombreCampo, xreg.c_TipoTasa._ContenidoCampo).Size = xreg.c_TipoTasa._LargoCampo
                                                .AddWithValue("@" + xreg.c_NivelClaveProcesada._NombreCampo, xreg.c_NivelClaveProcesada._ContenidoCampo).Size = xreg.c_NivelClaveProcesada._LargoCampo
                                            End With
                                            xcmd.ExecuteNonQuery()
                                        Next

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@auto_doc", xdoc)
                                        xcmd.CommandText = "delete from TemporalVenta_PendienteDetalle_NotasPlato_Fastfood where auto_doc=@auto_doc"
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@auto_doc", xdoc)
                                        xcmd.CommandText = "delete from TemporalVenta_PendienteDetalle_FastFood where auto_doc=@auto_doc"
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@auto_doc", xdoc)
                                        xcmd.CommandText = "delete from TemporalVenta_Pendiente_FastFood where auto_doc=@auto_doc"
                                        xr = xcmd.ExecuteNonQuery()

                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL TRATAR DE ELIMINAR PEDIDO PENDIENTE." + vbCrLf + "FUE ELIMINDAO POR OTRO USUARIO / NO ENCONTRADO")
                                        End If
                                    End Using
                                Next
                                xtr.Commit()

                                RaiseEvent _CtaPendienteAnulada()
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ERROR AL ANULAR PEDIDO FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Public Class TemporalVenta_NotasPlato_FastFood
                Event _NotasActualizadas()

                Class c_Registro
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_detalle As CampoDato

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_item._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_item._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_detalle._RetornarValor(Of String)() Is Nothing, "", Me.f_detalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA NOTAS DEL PLATO - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        With Me
                            .c_AutoItem = New CampoDato("auto_item", 10)
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_NotasItem = New CampoDato("detalle", 120)

                            M_Limpiar()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA NOTAS DEL PLATO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class ActualizarNotas
                    Private xdetalle As String
                    Private xfichaitem As TemporalVenta_FastFood.c_Registro
                    Private xautoplato As String

                    Property _NotasItem() As String
                        Get
                            Return xdetalle
                        End Get
                        Set(ByVal value As String)
                            xdetalle = value
                        End Set
                    End Property

                    Property _FichaItem() As TemporalVenta_FastFood.c_Registro
                        Get
                            Return xfichaitem
                        End Get
                        Set(ByVal value As TemporalVenta_FastFood.c_Registro)
                            xfichaitem = value
                        End Set
                    End Property

                    Property _AutoPlatoDelCombo_Modificar() As String
                        Get
                            Return xautoplato
                        End Get
                        Set(ByVal value As String)
                            xautoplato = value
                        End Set
                    End Property

                    ReadOnly Property _ObservacionesItem() As String
                        Get
                            Dim xdetalle As String = ""
                            If _FichaItem._EsCombo = TipoSiNo.Si Then
                                Try
                                    Dim xtb As New DataTable
                                    Dim xsql As String = "select * from menucombos_fastfood where auto_plato_combo=@auto"
                                    Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                                        xadap.SelectCommand.Parameters.AddWithValue("@auto", _FichaItem._AutoPlato)
                                        xadap.Fill(xtb)
                                    End Using

                                    Dim xitem_combo As New PlatosCombos.c_Registro
                                    For Each xrow In xtb.Rows
                                        xitem_combo.M_Limpiar()
                                        xitem_combo.CargarRegistro(xrow)
                                        If xdetalle <> "" Then
                                            xdetalle += " + "
                                        End If

                                        Dim xcant As String = ""
                                        If _FichaItem._EsPesado = TipoSiNo.No Then
                                            xcant = xitem_combo._Cantidad.ToString.Split(",")(0)
                                        End If
                                        xdetalle += xcant + " " + xitem_combo._NombrePlato

                                        If _AutoPlatoDelCombo_Modificar = xitem_combo._AutoPlato Then
                                            xdetalle += ": " + _NotasItem
                                        Else
                                            Dim xp1 As New SqlParameter("@auto_item", _FichaItem._AutoItem)
                                            Dim xp2 As New SqlParameter("@auto_plato", xitem_combo._AutoPlato)
                                            Dim xnota As String = F_GetString("select detalle from temporalventa_notasplato_fastfood where auto_item=@auto_item and auto_plato=@auto_plato", xp1, xp2)
                                            xdetalle += ": " + xnota.Trim
                                        End If
                                    Next
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            Else
                                Dim xcant As String = ""
                                If _FichaItem._EsPesado = TipoSiNo.No Then
                                    xcant = _FichaItem._CantidadDespachar.ToString.Split(",")(0)
                                End If
                                xdetalle = xcant + " " + _FichaItem._NombrePlato.ToString.Trim
                                If _NotasItem.Trim <> "" Then
                                    xdetalle += ": " + _NotasItem.Trim
                                End If
                            End If
                            Return xdetalle
                        End Get
                    End Property

                    Sub New()
                        _NotasItem = ""
                        _FichaItem = Nothing
                        _AutoPlatoDelCombo_Modificar = ""
                    End Sub
                End Class

                Protected Friend Const INSERT_TEMPORALVENTA_NOTAS As String = _
                    "insert into temporalventa_notasplato_fastfood (" & _
                    "auto_item," & _
                    "auto_plato," & _
                    "detalle) " & _
                    "Values(" & _
                    "@auto_item," & _
                    "@auto_plato," & _
                    "@detalle)"

                Dim xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Protected Friend Set(ByVal value As c_Registro)
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

                Function F_BuscarRegistro(ByVal xauto_item As String, ByVal xauto_plato As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            With xadap
                                .SelectCommand.CommandText = "select * from temporalventa_notasplato_fastfood where auto_item=@auto_item and auto_plato=@auto_plato"
                                .SelectCommand.Parameters.AddWithValue("@auto_item", xauto_item)
                                .SelectCommand.Parameters.AddWithValue("@auto_plato", xauto_plato)
                                .Fill(xtb)
                            End With
                        End Using
                        If (xtb.Rows.Count > 0) Then
                            M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("NOTAS FAST FOOD" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_ActualizarNotasItem(ByVal xnota As ActualizarNotas) As Boolean
                    Try
                        Dim xsql As String = "update temporalventa_notasplato_fastfood set detalle=@detalle where auto_item=@auto_item and auto_plato=@auto_plato"
                        Dim xtr As SqlTransaction = Nothing
                        Dim xnotas As String = xnota._ObservacionesItem

                        Dim xreg As New TemporalVenta_NotasPlato_FastFood.c_Registro
                        With xreg
                            If xnota._FichaItem._EsCombo = TipoSiNo.Si Then
                                .c_AutoItem._ContenidoCampo = xnota._FichaItem._AutoItem
                                .c_AutoPlato._ContenidoCampo = xnota._AutoPlatoDelCombo_Modificar
                                .c_NotasItem._ContenidoCampo = xnota._NotasItem
                            Else
                                .c_AutoItem._ContenidoCampo = xnota._FichaItem._AutoItem
                                .c_AutoPlato._ContenidoCampo = xnota._FichaItem._AutoPlato
                                .c_NotasItem._ContenidoCampo = xnota._NotasItem
                            End If
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                        .AddWithValue("@" + xreg.c_AutoPlato._NombreCampo, xreg._AutoPlato).Size = xreg.c_AutoPlato._LargoCampo
                                        .AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg._NotasItem).Size = xreg.c_NotasItem._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update temporalventa_fastfood set detalle=@detalle where auto_item=@auto_item"
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xnota._FichaItem.c_AutoItem._NombreCampo, xnota._FichaItem._AutoItem).Size = xnota._FichaItem.c_AutoItem._LargoCampo
                                        .AddWithValue("@" + xnota._FichaItem.c_NotasItem._NombreCampo, xnotas).Size = xnota._FichaItem.c_NotasItem._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _NotasActualizadas()

                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ERROR AL ACTUALIZAR NOTAS DEL ITEM" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Public Class TemporalVentaPendiente_FastFood
                Class c_Registro
                    Private f_auto_doc As CampoDato
                    Private f_fecha_doc As CampoDato
                    Private f_hora_doc As CampoDato
                    Private f_monto_doc As CampoDato
                    Private f_items_doc As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_equipoestacion As CampoDato
                    Private f_nombre_pendiente As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_cliente As CampoDato

                    Property c_AutoMovimiento() As CampoDato
                        Get
                            Return f_auto_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_doc = value
                        End Set
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return f_fecha_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_doc = value
                        End Set
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return f_hora_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_hora_doc = value
                        End Set
                    End Property

                    Property c_MontoTotal() As CampoDato
                        Get
                            Return f_monto_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_monto_doc = value
                        End Set
                    End Property

                    Property c_Items() As CampoDato
                        Get
                            Return f_items_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_items_doc = value
                        End Set
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    Property c_EquipoEstacion() As CampoDato
                        Get
                            Return f_equipoestacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_equipoestacion = value
                        End Set
                    End Property

                    Property c_NombrePendiente() As CampoDato
                        Get
                            Return f_nombre_pendiente
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_pendiente = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_AutoCliente() As CampoDato
                        Get
                            Return f_auto_cliente
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_cliente = value
                        End Set
                    End Property


                    ReadOnly Property _AutoMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_doc._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_doc._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_doc._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_doc._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _MontoTotal() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_monto_doc._ContenidoCampo Is Nothing, 0, Me.f_monto_doc._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Items() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_items_doc._ContenidoCampo Is Nothing, 0, Me.f_items_doc._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.f_equipoestacion._RetornarValor(Of String)() Is Nothing, "", Me.f_equipoestacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePendiente() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_pendiente._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_pendiente._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_cliente._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_cliente._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA PENDIENTE - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)
                        Me.c_EquipoEstacion = New CampoDato("equipoestacion", 20)
                        Me.c_Fecha = New CampoDato("fecha_doc")
                        Me.c_Hora = New CampoDato("hora_doc", 10)
                        Me.c_Items = New CampoDato("items_doc")
                        Me.c_MontoTotal = New CampoDato("monto_doc")
                        Me.c_NombrePendiente = New CampoDato("nombre_pendiente", 120)
                        Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                        Me.c_AutoMovimiento = New CampoDato("auto_doc", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoCliente = New CampoDato("auto_cliente", 10)

                        M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoCliente._ContenidoCampo = xrow(.c_AutoCliente._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoMovimiento._ContenidoCampo = xrow(.c_AutoMovimiento._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_EquipoEstacion._ContenidoCampo = xrow(.c_EquipoEstacion._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Items._ContenidoCampo = xrow(.c_Items._NombreCampo)
                                .c_MontoTotal._ContenidoCampo = xrow(.c_MontoTotal._NombreCampo)
                                .c_NombrePendiente._ContenidoCampo = xrow(.c_NombrePendiente._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA PENDIENTE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class AgregarCta
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xnombre As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xlista_items As List(Of TemporalVenta_FastFood.c_Registro)
                    Private xauto_cliente As String


                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString()
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Monto() As Decimal
                        Get
                            Dim res = _ListaItems.Select(Function(s) s._Total).Sum
                            Return res
                        End Get
                    End Property

                    Property _ListaItems() As List(Of TemporalVenta_FastFood.c_Registro)
                        Get
                            Return Me.xlista_items
                        End Get
                        Set(ByVal value As List(Of TemporalVenta_FastFood.c_Registro))
                            Me.xlista_items = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Items() As Integer
                        Get
                            Return _ListaItems.Count
                        End Get
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _NombrePendiente() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _AutoCliente() As String
                        Get
                            Return xauto_cliente
                        End Get
                        Set(ByVal value As String)
                            xauto_cliente = value
                        End Set
                    End Property


                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EquipoEstacion = ""
                        Me._FichaUsuario = Nothing
                        Me._ListaItems = Nothing
                        Me._NombrePendiente = ""
                        Me._AutoCliente = ""
                    End Sub
                End Class

                Class AbrirCta
                    Private xdocpendiente As String
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xpermitir_abrir_ctas_otros_usuarios As Boolean

                    Property _PermitirAbrirCtasOtorsUsuarios() As Boolean
                        Get
                            Return Me.xpermitir_abrir_ctas_otros_usuarios
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xpermitir_abrir_ctas_otros_usuarios = value
                        End Set
                    End Property

                    Property _DocPend_Abrir() As String
                        Get
                            Return Me.xdocpendiente
                        End Get
                        Set(ByVal value As String)
                            Me.xdocpendiente = value
                        End Set
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString()
                        End Get
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._EquipoEstacion = ""
                        Me._FichaUsuario = Nothing
                    End Sub
                End Class


                Protected Friend Const INSERT_TemporalVentaPendiente_FastFood As String = "INSERT INTO TemporalVenta_Pendiente_FastFood (" _
                 + "auto_doc, " _
                 + "fecha_doc, " _
                 + "hora_doc, " _
                 + "monto_doc, " _
                 + "items_doc, " _
                 + "auto_usuario, " _
                 + "nombre_usuario, " _
                 + "equipoestacion, " _
                 + "auto_operador, " _
                 + "auto_jornada, " _
                 + "nombre_pendiente, auto_cliente) " _
                 + "VALUES (" _
                 + "@auto_doc, " _
                 + "@fecha_doc, " _
                 + "@hora_doc, " _
                 + "@monto_doc, " _
                 + "@items_doc, " _
                 + "@auto_usuario, " _
                 + "@nombre_usuario, " _
                 + "@equipoestacion, " _
                 + "@auto_operador, " _
                 + "@auto_jornada, " _
                 + "@nombre_pendiente, @auto_cliente) "

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
                    Me.RegistroDato = New c_Registro
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

            Public Class TemporalVentaPendienteDetalle_FastFood
                Class c_Registro
                    Private f_auto_doc As CampoDato
                    Private f_codigo As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_tasa_iva As CampoDato
                    Private f_importe As CampoDato
                    Private f_espesado As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_tipo_tasa As CampoDato
                    Private f_escombo As CampoDato
                    Private f_costo_total_neto As CampoDato
                    Private f_detalle As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_auto_producto As CampoDato
                    Private f_tipo_item As CampoDato
                    Private f_empaque As CampoDato
                    Private f_contenido_empaque As CampoDato
                    Private f_auto_medida As CampoDato
                    Private f_tipo_precio As CampoDato

                    Property c_AutoPendiente() As CampoDato
                        Get
                            Return f_auto_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_doc = value
                        End Set
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_CantidadDespachar() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa_iva = value
                        End Set
                    End Property

                    Property c_Importe() As CampoDato
                        Get
                            Return f_importe
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_importe = value
                        End Set
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_TipoTasa() As CampoDato
                        Get
                            Return f_tipo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_tasa = value
                        End Set
                    End Property

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_total_neto = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    Property c_AutoProducto() As CampoDato
                        Get
                            Return f_auto_producto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_producto = value
                        End Set
                    End Property

                    Property c_TipoItem() As CampoDato
                        Get
                            Return f_tipo_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_item = value
                        End Set
                    End Property

                    Property c_NombreEmpaque() As CampoDato
                        Get
                            Return f_empaque
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_empaque = value
                        End Set
                    End Property

                    Property c_ContenidoEmpaque() As CampoDato
                        Get
                            Return f_contenido_empaque
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    Property c_AutoMedida() As CampoDato
                        Get
                            Return f_auto_medida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_medida = value
                        End Set
                    End Property

                    Property c_TipoPrecio() As CampoDato
                        Get
                            Return f_tipo_precio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_precio = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPendiente() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_item._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_item._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_medida._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_medida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_producto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_producto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_cantidad._ContenidoCampo Is Nothing, 0, Me.f_cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' CODIGO DEL PLATO / CODIGO DEL PRODUCTO
                    ''' </summary>
                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_contenido_empaque._ContenidoCampo Is Nothing, 0, Me.f_contenido_empaque._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' COSTO DEL PLATO / COSTO DEL PRODUCTO: EN UNIDAD DE INVENTARIO
                    ''' </summary>
                    ReadOnly Property _CostoPlato() As Decimal
                        Get
                            Dim xr As Decimal = 0
                            xr = Me._CostoTotalItem / Me._CantidadDespachar
                            Return Decimal.Round(xr, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _CostoTotalItem() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_total_neto._ContenidoCampo Is Nothing, 0, Me.f_costo_total_neto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EsCombo() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_escombo._RetornarValor(Of String)() Is Nothing, "", Me.f_escombo._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_esoferta._RetornarValor(Of String)() Is Nothing, "", Me.f_esoferta._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_espesado._RetornarValor(Of String)() Is Nothing, "", Me.f_espesado._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim ximporte As Decimal = 0
                            ximporte = Me._PrecioNeto * Me._CantidadDespachar
                            Return Decimal.Round(ximporte, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _Impuesto() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = (_Importe * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Dim xv As String = IIf(Me.f_empaque._RetornarValor(Of String)() Is Nothing, "", Me.f_empaque._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' MUESTRA LAS OBSERVACIONES DADAS AL PLATO
                    ''' </summary>
                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_detalle._RetornarValor(Of String)() Is Nothing, "", Me.f_detalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _PFinal() As Decimal
                        Get
                            Dim xpfin As Decimal = 0
                            xpfin = Me._PrecioNeto
                            xpfin = Decimal.Round(xpfin, 2, MidpointRounding.AwayFromZero)
                            Return xpfin
                        End Get
                    End Property

                    ReadOnly Property _PFinalFullIva() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _PFinal + (_PFinal * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_neto._ContenidoCampo Is Nothing, 0, Me.f_precio_neto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tasa_iva._ContenidoCampo Is Nothing, 0, Me.f_tasa_iva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TipoItem() As TipoItemFastFood
                        Get
                            Dim xv As String = IIf(Me.f_tipo_item._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_item._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return TipoItemFastFood.Plato
                                Case "2" : Return TipoItemFastFood.Producto
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.f_tipo_tasa._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_tasa._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoPrecio() As TipoPrecioFastFood
                        Get
                            Dim xv As String = IIf(Me.f_tipo_precio._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_precio._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "1" : Return TipoPrecioFastFood.Precio_1
                                Case "2" : Return TipoPrecioFastFood.Precio_2
                                Case "3" : Return TipoPrecioFastFood.Precio_Oferta
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _Total() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _Importe + _Impuesto
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA PENDIENTE DETALLE - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoItem = New CampoDato("auto_item", 10)
                        Me.c_AutoPendiente = New CampoDato("auto_doc", 10)
                        Me.c_AutoMedida = New CampoDato("auto_medida", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_AutoProducto = New CampoDato("auto_producto", 10)
                        Me.c_CantidadDespachar = New CampoDato("cantidad")
                        Me.c_CodigoPlato = New CampoDato("codigo", 15)
                        Me.c_ContenidoEmpaque = New CampoDato("contenido_empaque")
                        Me.c_CostoTotalNeto = New CampoDato("costo_total_neto")
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_EsOferta = New CampoDato("esoferta", 1)
                        Me.c_EsPesado = New CampoDato("espesado", 1)
                        Me.c_Importe = New CampoDato("importe")
                        Me.c_NombreEmpaque = New CampoDato("empaque", 15)
                        Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                        Me.c_NotasItem = New CampoDato("detalle", 120)
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_TasaIva = New CampoDato("tasa_iva")
                        Me.c_TipoItem = New CampoDato("tipo_item", 1)
                        Me.c_TipoTasa = New CampoDato("tipo_tasa", 1)
                        Me.c_TipoPrecio = New CampoDato("tipo_precio", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoPendiente._ContenidoCampo = xrow(.c_AutoPendiente._NombreCampo)
                                .c_AutoMedida._ContenidoCampo = xrow(.c_AutoMedida._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_CantidadDespachar._ContenidoCampo = xrow(.c_CantidadDespachar._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_ContenidoEmpaque._ContenidoCampo = xrow(.c_ContenidoEmpaque._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_Importe._ContenidoCampo = xrow(.c_Importe._NombreCampo)
                                .c_NombreEmpaque._ContenidoCampo = xrow(.c_NombreEmpaque._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                .c_TipoTasa._ContenidoCampo = xrow(.c_TipoTasa._NombreCampo)
                                .c_TipoPrecio._ContenidoCampo = xrow(.c_TipoPrecio._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA PENDIENTE DETALLE FAST FOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_TemporalVentaPendienteDetalle_FastFood As String = "INSERT INTO TemporalVenta_PendienteDetalle_FastFood (" _
                 + "Auto_Doc, " _
                 + "Codigo, " _
                 + "nombre_plato, " _
                 + "Cantidad, " _
                 + "Precio_Neto, " _
                 + "Tasa_Iva, " _
                 + "Importe, " _
                 + "EsPesado, " _
                 + "Auto_Item, " _
                 + "Auto_plato, " _
                 + "Tipo_Tasa, " _
                 + "escombo, " _
                 + "esoferta, " _
                 + "detalle, " _
                 + "auto_producto, " _
                 + "tipo_item, " _
                 + "auto_medida, " _
                 + "empaque, " _
                 + "contenido_empaque, " _
                 + "Costo_total_neto, tipo_precio) " _
                 + "VALUES (" _
                 + "@Auto_Doc, " _
                 + "@Codigo, " _
                 + "@nombre_plato, " _
                 + "@Cantidad, " _
                 + "@Precio_Neto, " _
                 + "@Tasa_Iva, " _
                 + "@Importe, " _
                 + "@EsPesado, " _
                 + "@Auto_Item," _
                 + "@Auto_plato, " _
                 + "@Tipo_Tasa, " _
                 + "@escombo, " _
                 + "@esoferta, " _
                 + "@detalle, " _
                 + "@auto_producto, " _
                 + "@tipo_item, " _
                 + "@auto_medida, " _
                 + "@empaque, " _
                 + "@contenido_empaque, " _
                 + "@Costo_total_neto, @tipo_precio) "

                Dim xregistro As c_Registro

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

            Public Class TemporalVentaPendiente_NotasPlato_FastFood
                Class c_Registro
                    Private f_auto_doc As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_detalle As CampoDato

                    Property c_AutoPendiente() As CampoDato
                        Get
                            Return f_auto_doc
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_doc = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPendiente() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_item._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_item._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_detalle._RetornarValor(Of String)() Is Nothing, "", Me.f_detalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA NOTAS PENDIENTES DEL PLATO - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        With Me
                            .c_AutoPendiente = New CampoDato("auto_doc", 10)
                            .c_AutoItem = New CampoDato("auto_item", 10)
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_NotasItem = New CampoDato("detalle", 120)

                            M_Limpiar()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoPendiente._ContenidoCampo = xrow(.c_AutoPendiente._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TEMPORAL VENTA PENDIENTE NOTAS DEL PLATO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_TEMPORALVENTA_NOTAS_PENDIENTES As String = _
                    "insert into TemporalVenta_PendienteDetalle_NotasPlato_Fastfood (" & _
                    "auto_doc," & _
                    "auto_item," & _
                    "auto_plato," & _
                    "detalle) " & _
                    "Values(" & _
                    "@auto_doc," & _
                    "@auto_item," & _
                    "@auto_plato," & _
                    "@detalle)"

                Dim xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Protected Friend Set(ByVal value As c_Registro)
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

            Public Class VentasDetalle_FastFood
                Class c_Registro
                    Private f_auto_documento As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_codigo As CampoDato
                    Private f_nombre As CampoDato
                    Private f_auto_grupo As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_total_neto As CampoDato
                    Private f_tasa As CampoDato
                    Private f_impuesto As CampoDato
                    Private f_total As CampoDato
                    Private f_auto As CampoDato
                    Private f_estatus As CampoDato
                    Private f_fecha As CampoDato
                    Private f_tipo As CampoDato
                    Private f_signo As CampoDato
                    Private f_precio_final As CampoDato
                    Private f_auto_entidad As CampoDato
                    Private f_utilidad As CampoDato
                    Private f_codigo_tasa As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_espesado As CampoDato
                    Private f_tipocalculoutilidad As CampoDato
                    Private f_tipomovimiento As CampoDato
                    Private f_costo_total_neto As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_detalle As CampoDato
                    Private f_utilidadp As CampoDato
                    Private f_auto_item_origen As CampoDato
                    Private f_costo_neto As CampoDato
                    Private f_tipo_item As CampoDato
                    Private f_escombo As CampoDato
                    Private f_rest_auto_mesonero As CampoDato
                    Private f_rest_nombre_mesonero As CampoDato
                    Private f_rest_codigo_mesonero As CampoDato

                    Private xitem_origen As String
                    ''' <summary>
                    ''' SOLO USADO PARA GRABAR VENTA, INDICA EL ITEM ORIGINAL EN TABLA REST_TEMPORALMESAS QUE VINCULA CON REST_HISTORIALCOMANDAS
                    ''' </summary>
                    Protected Friend Property _ItemOrigenTablaTemporal() As String
                        Get
                            Return xitem_origen
                        End Get
                        Set(ByVal value As String)
                            xitem_origen = value
                        End Set
                    End Property


                    Property c_AutoDocumento() As CampoDato
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_documento = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_AutoGrupo() As CampoDato
                        Get
                            Return f_auto_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_grupo = value
                        End Set
                    End Property

                    Property c_CantidadDespachada() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
                        End Set
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    Property c_TotalNeto() As CampoDato
                        Get
                            Return f_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_total_neto = value
                        End Set
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa = value
                        End Set
                    End Property

                    Property c_MontoIva() As CampoDato
                        Get
                            Return f_impuesto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_impuesto = value
                        End Set
                    End Property

                    Property c_TotalGeneral() As CampoDato
                        Get
                            Return f_total
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_total = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    Property c_FechaEmision() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_TipoDocumento() As CampoDato
                        Get
                            Return f_tipo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo = value
                        End Set
                    End Property

                    Property c_SignoDocumento() As CampoDato
                        Get
                            Return f_signo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_signo = value
                        End Set
                    End Property

                    Property c_PrecioFinal() As CampoDato
                        Get
                            Return f_precio_final
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_final = value
                        End Set
                    End Property

                    Property c_AutoCliente() As CampoDato
                        Get
                            Return f_auto_entidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_entidad = value
                        End Set
                    End Property

                    Property c_UtilidadMonto() As CampoDato
                        Get
                            Return f_utilidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_utilidad = value
                        End Set
                    End Property

                    Property c_TipoTasaIva() As CampoDato
                        Get
                            Return f_codigo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo_tasa = value
                        End Set
                    End Property

                    Property c_EnOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return f_espesado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_espesado = value
                        End Set
                    End Property

                    Property c_TipoCalculoUtilidad() As CampoDato
                        Get
                            Return f_tipocalculoutilidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipocalculoutilidad = value
                        End Set
                    End Property

                    Property c_TipoMovimiento() As CampoDato
                        Get
                            Return f_tipomovimiento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipomovimiento = value
                        End Set
                    End Property

                    Property c_CostoTotalNeto() As CampoDato
                        Get
                            Return f_costo_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_total_neto = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    Property c_UtilidadTasa() As CampoDato
                        Get
                            Return f_utilidadp
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_utilidadp = value
                        End Set
                    End Property

                    Property c_AutoItemOrigen() As CampoDato
                        Get
                            Return f_auto_item_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item_origen = value
                        End Set
                    End Property

                    Property c_CostoNeto() As CampoDato
                        Get
                            Return f_costo_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_neto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Indica Si El Iterm Registrado Es Un Plato / Un Producto Del Inventario
                    ''' </summary>
                    Property c_TipoItem() As CampoDato
                        Get
                            Return f_tipo_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_item = value
                        End Set
                    End Property

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    Property c_Rest_AutoMesonero() As CampoDato
                        Get
                            Return f_rest_auto_mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_rest_auto_mesonero = value
                        End Set
                    End Property

                    Property c_Rest_NombreMesonero() As CampoDato
                        Get
                            Return f_rest_nombre_mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_rest_nombre_mesonero = value
                        End Set
                    End Property

                    Property c_Rest_CodigoMesonero() As CampoDato
                        Get
                            Return f_rest_codigo_mesonero
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_rest_codigo_mesonero = value
                        End Set
                    End Property


                    ReadOnly Property _AutoCliente() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoCliente._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoCliente._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDocumento._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDocumento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoGrupo._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoGrupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItemOrigen() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItemOrigen._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItemOrigen._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadDespachada() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CantidadDespachada._ContenidoCampo Is Nothing, 0, Me.c_CantidadDespachada._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CostoNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CostoNeto._ContenidoCampo Is Nothing, 0, Me.c_CostoNeto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoTotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CostoTotalNeto._ContenidoCampo Is Nothing, 0, Me.c_CostoTotalNeto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EnOferta() As Boolean
                        Get
                            Dim xv As String = IIf(Me.c_EnOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EnOferta._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As Boolean
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As Boolean
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_FechaEmision._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaEmision._RetornarValor(Of Date)())
                            Return xv.date
                        End Get
                    End Property

                    ReadOnly Property _MontoImpuesto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_MontoIva._ContenidoCampo Is Nothing, 0, Me.c_MontoIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombrePlato._RetornarValor(Of String)() Is Nothing, "", Me.c_NombrePlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_NotasItem._RetornarValor(Of String)() Is Nothing, "", Me.c_NotasItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _PrecioFinal() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioFinal._ContenidoCampo Is Nothing, 0, Me.c_PrecioFinal._RetornarValor(Of Decimal)())
                            Dim xv1 As New Precio(xv, _TasaIva)
                            Return xv1
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioNeto._ContenidoCampo Is Nothing, 0, Me.c_PrecioNeto._RetornarValor(Of Decimal)())
                            Dim xv1 As New Precio(xv, _TasaIva)
                            Return xv1
                        End Get
                    End Property

                    ReadOnly Property _Signo() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_SignoDocumento._ContenidoCampo Is Nothing, 0, Me.c_SignoDocumento._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TipoCalculoUtilidad() As TipoCalculoUtilidad
                        Get
                            Dim xv As String = IIf(Me.c_TipoCalculoUtilidad._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoCalculoUtilidad._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "C" Then
                                Return TipoCalculoUtilidad.BaseAlCosto
                            Else 'V'
                                Return TipoCalculoUtilidad.BaseAlPrecioVenta
                            End If
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As FichaVentas.TipoDocumentoVentaRegistrado
                        Get
                            Dim xv As String = IIf(Me.c_TipoDocumento._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoDocumento._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "01" : Return FichaVentas.TipoDocumentoVentaRegistrado.Factura
                                Case "02" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaDebito
                                Case "03" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito
                                Case "04" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega
                                Case "05" : Return FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                                Case "06" : Return FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Indica Si El Iterm Registrado Es Un Plato / Un Producto Del Inventario
                    ''' </summary>
                    ReadOnly Property _TipoItem() As TipoItemFastFood
                        Get
                            Dim xv As String = IIf(Me.c_TipoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoItem._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "1" : Return TipoItemFastFood.Plato
                                Case "2" : Return TipoItemFastFood.Producto
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoMovimientoEfectuado() As TipoMovimientoDetalle
                        Get
                            Dim xv As String = IIf(Me.c_TipoMovimiento._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoMovimiento._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "V" : Return TipoMovimientoDetalle.Venta
                                Case "A" : Return TipoMovimientoDetalle.Ajuste
                                Case "D" : Return TipoMovimientoDetalle.Devolucion
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasaIva._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasaIva._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TotalGeneral() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TotalGeneral._ContenidoCampo Is Nothing, 0, Me.c_TotalGeneral._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TotalNeto._ContenidoCampo Is Nothing, 0, Me.c_TotalNeto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _UtilidadMonto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_UtilidadMonto._ContenidoCampo Is Nothing, 0, Me.c_UtilidadMonto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _UtilidadTasa() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_UtilidadTasa._ContenidoCampo Is Nothing, 0, Me.c_UtilidadTasa._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EsCombo() As Boolean
                        Get
                            Dim xv As String = IIf(Me.c_EsCombo._RetornarValor(Of String)() Is Nothing, "", Me.c_EsCombo._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _Rest_AutoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_Rest_AutoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_Rest_AutoMesonero._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Rest_NombreMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_Rest_NombreMesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_Rest_NombreMesonero._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Rest_CodigoMesonero() As String
                        Get
                            Dim xv As String = IIf(Me.c_Rest_CodigoMesonero._RetornarValor(Of String)() Is Nothing, "", Me.c_Rest_CodigoMesonero._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Try
                                Dim x As String = ""
                                Dim xp1 As New SqlParameter("@auto", _AutoGrupo)
                                x = F_GetString("SELECT NOMBRE_GRUPO FROM GRUPO_FASTFOOD WHERE AUTO=@AUTO", xp1)
                                Return x
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase VENTAS DETALLE - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub


                    Sub New()
                        Me.c_AutoCliente = New CampoDato("auto_entidad", 10)
                        Me.c_AutoDocumento = New CampoDato("auto_documento", 10)
                        Me.c_AutoGrupo = New CampoDato("auto_grupo", 10)
                        Me.c_AutoItem = New CampoDato("auto", 10)
                        Me.c_AutoItemOrigen = New CampoDato("auto_item_origen", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_CantidadDespachada = New CampoDato("cantidad")
                        Me.c_CodigoPlato = New CampoDato("codigo", 15)
                        Me.c_CostoNeto = New CampoDato("costo_neto")
                        Me.c_CostoTotalNeto = New CampoDato("costo_total_neto")
                        Me.c_EnOferta = New CampoDato("esoferta", 1)
                        Me.c_EsPesado = New CampoDato("espesado", 1)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_FechaEmision = New CampoDato("fecha")
                        Me.c_MontoIva = New CampoDato("impuesto")
                        Me.c_NombrePlato = New CampoDato("nombre", 60)
                        Me.c_NotasItem = New CampoDato("detalle", 120)
                        Me.c_PrecioFinal = New CampoDato("precio_final")
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_SignoDocumento = New CampoDato("signo")
                        Me.c_TasaIva = New CampoDato("tasa")
                        Me.c_TipoCalculoUtilidad = New CampoDato("tipocalculoutilidad", 1)
                        Me.c_TipoDocumento = New CampoDato("tipo", 2)
                        Me.c_TipoItem = New CampoDato("tipo_item", 1)
                        Me.c_TipoMovimiento = New CampoDato("tipomovimiento", 1)
                        Me.c_TipoTasaIva = New CampoDato("codigo_tasa", 1)
                        Me.c_TotalGeneral = New CampoDato("total")
                        Me.c_TotalNeto = New CampoDato("total_neto")
                        Me.c_UtilidadMonto = New CampoDato("utilidad")
                        Me.c_UtilidadTasa = New CampoDato("utilidadp")
                        Me.c_Rest_AutoMesonero = New CampoDato("rest_auto_mesonero", 10)
                        Me.c_Rest_CodigoMesonero = New CampoDato("rest_codigo_mesonero", 15)
                        Me.c_Rest_NombreMesonero = New CampoDato("rest_nombre_mesonero", 120)

                        M_Limpiar()
                    End Sub


                    Sub M_CargarRegistro(ByVal xrow As DataRow)
                        Try
                            M_Limpiar()

                            With Me
                                .c_AutoCliente._ContenidoCampo = xrow(.c_AutoCliente._NombreCampo)
                                .c_AutoDocumento._ContenidoCampo = xrow(.c_AutoDocumento._NombreCampo)
                                .c_AutoGrupo._ContenidoCampo = xrow(.c_AutoGrupo._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoItemOrigen._ContenidoCampo = xrow(.c_AutoItemOrigen._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_CantidadDespachada._ContenidoCampo = xrow(.c_CantidadDespachada._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_CostoNeto._ContenidoCampo = xrow(.c_CostoNeto._NombreCampo)
                                .c_CostoTotalNeto._ContenidoCampo = xrow(.c_CostoTotalNeto._NombreCampo)
                                .c_EnOferta._ContenidoCampo = xrow(.c_EnOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_FechaEmision._ContenidoCampo = xrow(.c_FechaEmision._NombreCampo)
                                .c_MontoIva._ContenidoCampo = xrow(.c_MontoIva._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                .c_PrecioFinal._ContenidoCampo = xrow(.c_PrecioFinal._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_SignoDocumento._ContenidoCampo = xrow(.c_SignoDocumento._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoCalculoUtilidad._ContenidoCampo = xrow(.c_TipoCalculoUtilidad._NombreCampo)
                                .c_TipoDocumento._ContenidoCampo = xrow(.c_TipoDocumento._NombreCampo)
                                .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                .c_TipoMovimiento._ContenidoCampo = xrow(.c_TipoMovimiento._NombreCampo)
                                .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)
                                .c_TotalGeneral._ContenidoCampo = xrow(.c_TotalGeneral._NombreCampo)
                                .c_TotalNeto._ContenidoCampo = xrow(.c_TotalNeto._NombreCampo)
                                .c_UtilidadMonto._ContenidoCampo = xrow(.c_UtilidadMonto._NombreCampo)
                                .c_UtilidadTasa._ContenidoCampo = xrow(.c_UtilidadTasa._NombreCampo)

                                If Not IsDBNull(xrow(.c_EsCombo._NombreCampo)) Then
                                    .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_AutoMesonero._NombreCampo)) Then
                                    .c_Rest_AutoMesonero._ContenidoCampo = xrow(.c_Rest_AutoMesonero._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_CodigoMesonero._NombreCampo)) Then
                                    .c_Rest_CodigoMesonero._ContenidoCampo = xrow(.c_Rest_CodigoMesonero._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_NombreMesonero._NombreCampo)) Then
                                    .c_Rest_NombreMesonero._ContenidoCampo = xrow(.c_Rest_NombreMesonero._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CARGAR FICHA VENTAS DETALLE - FASTFOOD " + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    ''' <summary>
                    ''' Buscar Cargar Item Especifico Del Documento De Venta
                    ''' </summary>
                    ''' <param name="xdoc">Documento A Cargar</param>
                    ''' <param name="xitem">Item A Cargar</param>
                    Function BuscarCargar(ByVal xdoc As String, ByVal xitem As String) As Boolean
                        Try
                            Dim xtb As New DataTable
                            Dim xp1 As New SqlParameter("@autodoc", xdoc)
                            Dim xp2 As New SqlParameter("@auto", xitem)
                            Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                xadap.SelectCommand.CommandText = "select * from ventas_detalle_fastfood where auto_documento=@autodoc and auto=@auto"
                                xadap.SelectCommand.Parameters.AddWithValue("@autodoc", xdoc)
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", xitem)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                M_CargarRegistro(xtb(0))
                                Return True
                            Else
                                Throw New Exception("ITEM NO ENCONTRADO")
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Function
                End Class

                Protected Friend Const INSERT_VENTASDETALLE_FASTFOOD As String = "INSERT INTO Ventas_Detalle_FastFood (" & _
                    "auto_documento, " & _
                    "auto_plato, " & _
                    "codigo, " & _
                    "nombre, " & _
                    "auto_grupo, " & _
                    "cantidad, " & _
                    "precio_neto, " & _
                    "total_neto, " & _
                    "tasa, " & _
                    "impuesto, " & _
                    "total, " & _
                    "auto, " & _
                    "estatus, " & _
                    "fecha, " & _
                    "tipo, " & _
                    "signo, " & _
                    "precio_final, " & _
                    "auto_entidad, " & _
                    "utilidad, " & _
                    "codigo_tasa, " & _
                    "esoferta, " & _
                    "espesado, " & _
                    "tipocalculoutilidad, " & _
                    "tipomovimiento, " & _
                    "costo_total_neto, " & _
                    "auto_operador, " & _
                    "auto_jornada, " & _
                    "detalle, " & _
                    "utilidadp, " & _
                    "auto_item_origen, " & _
                    "costo_neto, " & _
                    "tipo_item, escombo, rest_auto_mesonero, rest_codigo_mesonero, rest_nombre_mesonero) " & _
                    "VALUES (" & _
                    "@auto_documento, " & _
                    "@auto_plato, " & _
                    "@codigo, " & _
                    "@nombre, " & _
                    "@auto_grupo, " & _
                    "@cantidad, " & _
                    "@precio_neto, " & _
                    "@total_neto, " & _
                    "@tasa, " & _
                    "@impuesto, " & _
                    "@total, " & _
                    "@auto, " & _
                    "@estatus, " & _
                    "@fecha, " & _
                    "@tipo, " & _
                    "@signo, " & _
                    "@precio_final, " & _
                    "@auto_entidad, " & _
                    "@utilidad, " & _
                    "@codigo_tasa, " & _
                    "@esoferta, " & _
                    "@espesado, " & _
                    "@tipocalculoutilidad, " & _
                    "@tipomovimiento, " & _
                    "@costo_total_neto, " & _
                    "@auto_operador, " & _
                    "@auto_jornada, " & _
                    "@detalle, " & _
                    "@utilidadp, " & _
                    "@auto_item_origen, " & _
                    "@costo_neto, " & _
                    "@tipo_item, @escombo, @rest_auto_mesonero, @rest_codigo_mesonero, @rest_nombre_mesonero)"
 
                Dim xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.RegistroDato = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .M_CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarCargar(ByVal xautodoc As String, ByVal xautoitem As String) As Boolean
                    Try
                        Me.RegistroDato.BuscarCargar(xautodoc, xautoitem)
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Public Class HistorialComandas_FastFood
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_documento As CampoDato
                    Private f_documento As CampoDato
                    Private f_fecha As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_nombre_usuario As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_cantidad_plato As CampoDato
                    Private f_detalle_plato As CampoDato
                    Private f_auto_estacion As CampoDato
                    Private f_nombre_estacion As CampoDato
                    Private f_ruta_estacion As CampoDato
                    Private f_estatus_plato_envio As CampoDato
                    Private f_estatus_estacion_envio As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    Property c_AutoDocumento() As CampoDato
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_documento = value
                        End Set
                    End Property

                    Property c_Documento() As CampoDato
                        Get
                            Return f_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_documento = value
                        End Set
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombre_usuario
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_usuario = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return f_cantidad_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad_plato = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_NotasDetalle() As CampoDato
                        Get
                            Return f_detalle_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle_plato = value
                        End Set
                    End Property

                    Property c_AutoEstacion() As CampoDato
                        Get
                            Return f_auto_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_estacion = value
                        End Set
                    End Property

                    Property c_NombreEstacion() As CampoDato
                        Get
                            Return f_nombre_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_estacion = value
                        End Set
                    End Property

                    Property c_RutaEstacion() As CampoDato
                        Get
                            Return f_ruta_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_ruta_estacion = value
                        End Set
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


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TEMPORAL VENTA NOTAS PENDIENTES DEL PLATO - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub


                    Sub New()
                        With Me
                            Me.c_Auto = New CampoDato("auto", 10)
                            Me.c_AutoDocumento = New CampoDato("auto_documento", 10)
                            Me.c_AutoEstacion = New CampoDato("auto_estacion", 10)
                            Me.c_AutoItem = New CampoDato("auto_item", 10)
                            Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                            Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                            Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                            Me.c_Cantidad = New CampoDato("cantidad_plato")
                            Me.c_Documento = New CampoDato("documento", 10)
                            Me.c_EstatusEstacionEnvio = New CampoDato("estatus_estacion_envio", 1)
                            Me.c_EstatusPlatoEnvio = New CampoDato("estatus_plato_envio", 1)
                            Me.c_FechaProceso = New CampoDato("fecha")
                            Me.c_NombreEstacion = New CampoDato("nombre_estacion", 20)
                            Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                            Me.c_NombreUsuario = New CampoDato("nombre_usuario", 20)
                            Me.c_NotasDetalle = New CampoDato("detalle_plato", 120)
                            Me.c_RutaEstacion = New CampoDato("ruta_estacion", 250)

                            M_Limpiar()
                        End With
                    End Sub


                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoDocumento._ContenidoCampo = xrow(.c_AutoDocumento._NombreCampo)
                                .c_AutoEstacion._ContenidoCampo = xrow(.c_AutoEstacion._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_Documento._ContenidoCampo = xrow(.c_Documento._NombreCampo)
                                .c_EstatusEstacionEnvio._ContenidoCampo = xrow(.c_EstatusEstacionEnvio._NombreCampo)
                                .c_EstatusPlatoEnvio._ContenidoCampo = xrow(.c_EstatusPlatoEnvio._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_NombreEstacion._ContenidoCampo = xrow(.c_NombreEstacion._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_NotasDetalle._ContenidoCampo = xrow(.c_NotasDetalle._NombreCampo)
                                .c_RutaEstacion._ContenidoCampo = xrow(.c_RutaEstacion._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("HISTORIAL COMANDAS FASTFOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    RegistroDato = New c_Registro
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


                Protected Friend Const INSERT_HISTORIALCOMANDAS_FASTFOOD As String = "INSERT INTO HISTORIALCOMANDAS_FASTFOOD (" & _
                    "auto," & _
                    "auto_documento," & _
                    "documento," & _
                    "fecha," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "nombre_usuario," & _
                    "auto_item," & _
                    "auto_plato," & _
                    "nombre_plato," & _
                    "cantidad_plato," & _
                    "detalle_plato," & _
                    "auto_estacion," & _
                    "nombre_estacion," & _
                    "ruta_estacion," & _
                    "estatus_plato_envio," & _
                    "estatus_estacion_envio) " & _
                    "VALUES (" & _
                    "@auto," & _
                    "@auto_documento," & _
                    "@documento," & _
                    "@fecha," & _
                    "@auto_jornada," & _
                    "@auto_operador," & _
                    "@nombre_usuario," & _
                    "@auto_item," & _
                    "@auto_plato," & _
                    "@nombre_plato," & _
                    "@cantidad_plato," & _
                    "@detalle_plato," & _
                    "@auto_estacion," & _
                    "@nombre_estacion," & _
                    "@ruta_estacion," & _
                    "@estatus_plato_envio," & _
                    "@estatus_estacion_envio)"

            End Class

            Public Class PlatoSalida
                Class c_Registro
                    Private f_auto_documento As CampoDato
                    Private f_documento As CampoDato
                    Private f_fecha As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_auto_grupo As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_nombre_grupo As CampoDato
                    Private f_cantidad_requerida As CampoDato
                    Private f_signo As CampoDato
                    Private f_estatus As CampoDato
                    Private f_cantidad_total As CampoDato


                    Property c_AutoDocumento() As CampoDato
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_documento = value
                        End Set
                    End Property

                    Property c_Documento() As CampoDato
                        Get
                            Return f_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_documento = value
                        End Set
                    End Property

                    Property c_FechaProceso() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' ITEM EN TABLA VENTA_DETALLE_FASTFOOD, AL CUAL HACE REFERENCIA
                    ''' </summary>
                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_AutoGrupo() As CampoDato
                        Get
                            Return f_auto_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_grupo = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_NombreGrupo() As CampoDato
                        Get
                            Return f_nombre_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_grupo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Cantidad Requerida Por El Combo De Este Plato
                    ''' </summary>
                    Property c_CantidadRequerida() As CampoDato
                        Get
                            Return f_cantidad_requerida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad_requerida = value
                        End Set
                    End Property

                    Property c_Signo() As CampoDato
                        Get
                            Return f_signo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_signo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Cantidad Total Que Salio 
                    ''' </summary>
                    Property c_CantidadTotal() As CampoDato
                        Get
                            Return f_cantidad_total
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad_total = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Estatus De La Salida 
                    ''' </summary>
                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property


                    ''' <summary>
                    ''' Auto Documento Venta Al Cual Hace Referencia
                    ''' </summary>
                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDocumento._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDocumento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoGrupo._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoGrupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' AUTO ITEM EN TABLA VENTA_DETALLE_FASTFOOD, AL CUAL HACE REFERENCIA
                    ''' </summary>
                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoPlato._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoPlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna La Cantidad Requerida Por El Combo De Este Plato
                    ''' </summary>
                    ReadOnly Property _CantidadRequerida() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CantidadRequerida._ContenidoCampo Is Nothing, 0, Me.c_CantidadRequerida._RetornarValor(Of Decimal))
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Documento() As String
                        Get
                            Dim xv As String = IIf(Me.c_Documento._RetornarValor(Of String)() Is Nothing, "", Me.c_Documento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_Documento._ContenidoCampo Is Nothing, Date.MinValue, Me.c_FechaProceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreGrupo._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreGrupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombrePlato._RetornarValor(Of String)() Is Nothing, "", Me.c_NombrePlato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna el tipo de movimiento como positivo / negativo
                    ''' </summary>
                    ReadOnly Property _Signo() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_Signo._ContenidoCampo Is Nothing, 1, Me.c_Signo._RetornarValor(Of Integer))
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna La Cantidad Total Que Salio Del Plato
                    ''' </summary>
                    ReadOnly Property _CantidadTotal() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_CantidadTotal._ContenidoCampo Is Nothing, 0, Me.c_CantidadTotal._RetornarValor(Of Decimal))
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna La Cantidad Total Que Salio Del Plato
                    ''' </summary>
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "0" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase PLATO SALIDA - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub


                    Sub New()
                        With Me
                            Me.c_AutoDocumento = New CampoDato("auto_documento", 10)
                            Me.c_AutoGrupo = New CampoDato("auto_grupo", 10)
                            Me.c_AutoItem = New CampoDato("auto_item", 10)
                            Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                            Me.c_CantidadRequerida = New CampoDato("cantidad_requerida")
                            Me.c_Documento = New CampoDato("documento", 10)
                            Me.c_FechaProceso = New CampoDato("fecha")
                            Me.c_NombreGrupo = New CampoDato("nombre_grupo", 60)
                            Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                            Me.c_Signo = New CampoDato("signo")
                            Me.c_CantidadTotal = New CampoDato("cantidad_total")
                            Me.c_Estatus = New CampoDato("estatus")

                            M_Limpiar()
                        End With
                    End Sub


                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoDocumento._ContenidoCampo = xrow(.c_AutoDocumento._NombreCampo)
                                .c_AutoGrupo._ContenidoCampo = xrow(.c_AutoGrupo._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_CantidadRequerida._ContenidoCampo = xrow(.c_CantidadRequerida._NombreCampo)
                                .c_CantidadTotal._ContenidoCampo = xrow(.c_CantidadTotal._NombreCampo)
                                .c_Documento._ContenidoCampo = xrow(.c_Documento._NombreCampo)
                                .c_FechaProceso._ContenidoCampo = xrow(.c_FechaProceso._NombreCampo)
                                .c_NombreGrupo._ContenidoCampo = xrow(.c_NombreGrupo._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_Signo._ContenidoCampo = xrow(.c_Signo._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PLATO SALIDA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const InsertRegistro As String = "INSERT PlatoSalida_FastFood (" & _
                        "auto_documento, " & _
                        "documento, " & _
                        "fecha, " & _
                        "auto_item, " & _
                        "auto_plato, " & _
                        "auto_grupo, " & _
                        "nombre_plato, " & _
                        "nombre_grupo, " & _
                        "cantidad_requerida, cantidad_total, estatus, " & _
                        "signo) " & _
                        " VALUES (" & _
                        "@auto_documento, " & _
                        "@documento, " & _
                        "@fecha, " & _
                        "@auto_item, " & _
                        "@auto_plato, " & _
                        "@auto_grupo, " & _
                        "@nombre_plato, " & _
                        "@nombre_grupo, " & _
                        "@cantidad_requerida, @cantidad_total, @estatus, " & _
                        "@signo) "

                Dim xregistro As c_Registro

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

            Public Class VentaInventario
                Class c_Registro
                    Private f_auto_documento As CampoDato
                    Private f_auto_item As CampoDato
                    Private f_auto_producto As CampoDato
                    Private f_auto_med_empaq As CampoDato
                    Private f_cont_empaq As CampoDato
                    Private f_cant_requiere As CampoDato
                    Private f_auto_deposito As CampoDato

                    ''' <summary>
                    ''' Automatico Del Documento De Venta
                    ''' </summary>
                    Property c_AutoDocumentoVenta() As CampoDato
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumentoVenta() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDocumentoVenta._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDocumentoVenta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Documento De Venta
                    ''' </summary>
                    ReadOnly Property _f_AutoDocumentoVenta() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                Dim xventas As New FichaVentas.V_Ventas
                                xventas.F_BuscarDocumento(_AutoDocumentoVenta)
                                Return xventas.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Automatico Del Item de Venta
                    ''' </summary>
                    Property c_AutoItemVenta() As CampoDato
                        Get
                            Return f_auto_item
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItemVenta() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItemVenta._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItemVenta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Item Venta
                    ''' </summary>
                    ReadOnly Property _f_AutoItemVenta() As FastFood.VentasDetalle_FastFood.c_Registro
                        Get
                            Try
                                Dim xitemventas As New FastFood.VentasDetalle_FastFood
                                xitemventas.F_BuscarCargar(_AutoDocumentoVenta, _AutoItemVenta)
                                Return xitemventas.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Automatico Del Producto
                    ''' </summary>
                    Property c_AutoProducto() As CampoDato
                        Get
                            Return f_auto_producto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoProducto._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoProducto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Item Producto
                    ''' </summary>
                    ReadOnly Property _f_AutoProducto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xproducto As New FichaProducto.Prd_Producto
                                xproducto.F_BuscarCargarFichaProducto(_AutoProducto)
                                Return xproducto.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Automatico Medida Empaque 
                    ''' </summary>
                    Property c_AutoMedEmpaq() As CampoDato
                        Get
                            Return f_auto_med_empaq
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_med_empaq = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMedEmpaq() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoMedEmpaq._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoMedEmpaq._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Medida Empaque
                    ''' </summary>
                    ReadOnly Property _f_AutoMedEmpaq() As FichaProducto.Prd_Medida.c_Registro
                        Get
                            Try
                                Dim xmedida As New FichaProducto.Prd_Medida
                                xmedida.F_BuscarMedida(_AutoMedEmpaq)
                                Return xmedida.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Contenido Del Empaque Seleccionado
                    ''' </summary>
                    Property c_ContEmpaque() As CampoDato
                        Get
                            Return f_cont_empaq
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cont_empaq = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_ContEmpaque._ContenidoCampo Is Nothing, 0, Me.c_ContEmpaque._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' Cantidad A Descontar Del Inventario
                    ''' </summary>
                    Property c_Cantidad_Requerida_Descontar() As CampoDato
                        Get
                            Return f_cant_requiere
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cant_requiere = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad_Requerida_Descontar() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_Cantidad_Requerida_Descontar._ContenidoCampo Is Nothing, 0, Me.c_Cantidad_Requerida_Descontar._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' Automatico Del Deposito Descontado
                    ''' </summary>
                    Property c_AutoDeposito() As CampoDato
                        Get
                            Return f_auto_deposito
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDeposito._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDeposito._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Deposito
                    ''' </summary>
                    ReadOnly Property _f_AutoDeposito() As FichaGlobal.c_Depositos.c_Registro
                        Get
                            Try
                                Dim xdeposito As New FichaGlobal.c_Depositos
                                xdeposito.F_BuscarDeposito(_AutoDeposito)
                                Return xdeposito.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase VENTAS INVENTARIO - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub


                    Sub New()
                        Me.c_AutoDeposito = New CampoDato("auto_deposito", 10)
                        Me.c_AutoDocumentoVenta = New CampoDato("auto_documento", 10)
                        Me.c_AutoItemVenta = New CampoDato("auto_item", 10)
                        Me.c_AutoMedEmpaq = New CampoDato("auto_med_empaq", 10)
                        Me.c_AutoProducto = New CampoDato("auto_producto", 10)
                        Me.c_Cantidad_Requerida_Descontar = New CampoDato("cantidad_requiere")
                        Me.c_ContEmpaque = New CampoDato("cont_empaq")

                        M_Limpiar()
                    End Sub

                    Sub M_CargarRegistro(ByVal xrow As DataRow)
                        Try
                            M_Limpiar()

                            With Me
                                .c_AutoDeposito._ContenidoCampo = xrow(.c_AutoDeposito._NombreCampo)
                                .c_AutoDocumentoVenta._ContenidoCampo = xrow(.c_AutoDocumentoVenta._NombreCampo)
                                .c_AutoItemVenta._ContenidoCampo = xrow(.c_AutoItemVenta._NombreCampo)
                                .c_AutoMedEmpaq._ContenidoCampo = xrow(.c_AutoMedEmpaq._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_Cantidad_Requerida_Descontar._ContenidoCampo = xrow(.c_Cantidad_Requerida_Descontar._NombreCampo)
                                .c_ContEmpaque._ContenidoCampo = xrow(.c_ContEmpaque._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("CARGAR FICHA VENTAS INVENTARIO - FASTFODD " + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const Insert As String = "INSERT INTO VentaInventario_FastFood (" & _
                    "auto_documento," & _
                    "auto_item," & _
                    "auto_producto," & _
                    "auto_med_empaq," & _
                    "cont_empaq," & _
                    "cantidad_requiere, auto_deposito) " & _
                    "VALUES (" & _
                    "@auto_documento," & _
                    "@auto_item," & _
                    "@auto_producto," & _
                    "@auto_med_empaq," & _
                    "@cont_empaq," & _
                    "@cantidad_requiere, @auto_deposito)"

                Dim xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.RegistroDato = New c_Registro
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .M_CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

        End Class
    End Class
End Namespace

Imports System.Data.SqlClient
Imports System.Text

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class PosOnline

            Enum ModoUsoPesado As Integer
                EsPesado = 1
                EsPesadoUnidad = 2
                EsItem = 3
            End Enum

            Enum TipoDevolucionPos As Integer
                Devolucion = 1
                Anulacion = 2
                DevolucionItem = 3
                AnulacionPendiente = 4
            End Enum

            Enum TipoItemPos As Integer
                ItemCodigoBarra = 1
                Plu = 2
                PreEmpaque = 3
                Mayor = 4
                Ticket = 5
                Departamento = 6
                Tarjeta = 7 'panaderia
            End Enum


            Public Class PosVenta
                Class c_Registro
                    Private f_autoitem As CampoDato
                    Private f_autojornada As CampoDato
                    Private f_autooperador As CampoDato
                    Private f_prd_automatico As CampoDato
                    Private f_prd_nombrecorto As CampoDato
                    Private f_prd_cantidad As CampoDato
                    Private f_prd_precioneto As CampoDato
                    Private f_prd_tasaiva As CampoDato
                    Private f_prd_tasatipo As CampoDato
                    Private f_prd_esoferta As CampoDato
                    Private f_prd_espesado As CampoDato
                    Private f_prd_precioventa As CampoDato
                    Private f_prd_codigobarra As CampoDato
                    Private f_prd_plu As CampoDato
                    Private f_prd_psugerido As CampoDato
                    Private f_prd_autoempaq As CampoDato
                    Private f_prd_contempaq As CampoDato
                    Private f_prd_nombreempaq As CampoDato
                    Private f_prd_tipoempaq As CampoDato
                    Private f_prd_tipopreciomay As CampoDato
                    Private f_etiq_formato As CampoDato
                    Private f_etiq_depart As CampoDato
                    Private f_etiq_seccion As CampoDato
                    Private f_etiq_vendedor As CampoDato
                    Private f_etiq_plu As CampoDato
                    Private f_etiq_peso As CampoDato
                    Private f_etiq_precio As CampoDato
                    Private f_etiq_control As CampoDato
                    Private f_etiq_digitos As CampoDato
                    Private f_etiq_ticket As CampoDato
                    Private f_etiq_balanza As CampoDato
                    Private f_etiq_monto As CampoDato
                    Private f_etiq_item As CampoDato
                    Private f_etiq_auto As CampoDato
                    Private f_id_equipo As CampoDato
                    Private f_autousuario As CampoDato
                    Private f_prd_tipo As CampoDato
                    Private f_notas_item As CampoDato


                    Property c_AutoItem() As CampoDato
                        Get
                            Return Me.f_autoitem
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_autoitem = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return Me.f_autojornada
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_autojornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _f_Jornada() As FastFood.Jornada.c_Registro
                        Try
                            Dim xv As New FastFood.Jornada
                            xv.F_BuscarCargar(_AutoJornada)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return Me.f_autooperador
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_autooperador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _f_Operador() As FastFood.OperadorJornada.c_Registro
                        Try
                            Dim xv As New FastFood.OperadorJornada
                            xv.F_BuscarCargar(_AutoOperador)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_AutoProducto() As CampoDato
                        Get
                            Return Me.f_prd_automatico
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_automatico = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoProducto._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoProducto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_Producto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xv As New FichaProducto.Prd_Producto
                                xv.F_BuscarCargarFichaProducto(_AutoProducto)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_NombreCorto() As CampoDato
                        Get
                            Return Me.f_prd_nombrecorto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombrecorto = value
                        End Set
                    End Property

                    ReadOnly Property _NombreCorto() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreCorto._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreCorto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return Me.f_prd_cantidad
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Cantidad._ContenidoCampo Is Nothing, 0, Me.c_Cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return Me.f_prd_precioneto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioneto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioVenta() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioNeto._ContenidoCampo Is Nothing, 0, Me.c_PrecioNeto._RetornarValor(Of Decimal)())
                            Dim xpv As New Precio(xv, _TasaIva)
                            Return xpv
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasaiva
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasaiva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TipoTasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasatipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasatipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasaIva._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasaIva._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                                Case Else : Throw New Exception("ERROR TASA IVA DEL PRODUCTO")
                            End Select
                        End Get
                    End Property

                    Property c_EnOferta() As CampoDato
                        Get
                            Return Me.f_prd_esoferta
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _EnOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EnOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EnOferta._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return Me.f_prd_espesado
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _EsPesado() As ModoUsoPesado
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return ModoUsoPesado.EsItem
                                Case "1" : Return ModoUsoPesado.EsPesado
                                Case "2" : Return ModoUsoPesado.EsPesadoUnidad
                            End Select
                        End Get
                    End Property

                    Property c_PrecioRegular() As CampoDato
                        Get
                            Return Me.f_prd_precioventa
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioventa = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioRegular() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioRegular._ContenidoCampo Is Nothing, 0, Me.c_PrecioRegular._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CodigoBarraLeido() As CampoDato
                        Get
                            Return Me.f_prd_codigobarra
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarraLeido() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoBarraLeido._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoBarraLeido._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PLU() As CampoDato
                        Get
                            Return Me.f_prd_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PLU() As String
                        Get
                            Dim xv As String = IIf(Me.c_PLU._RetornarValor(Of String)() Is Nothing, "", Me.c_PLU._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioSugerido() As CampoDato
                        Get
                            Return Me.f_prd_psugerido
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_psugerido = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioSugerido() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioSugerido._ContenidoCampo Is Nothing, 0, Me.c_PrecioSugerido._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_AutoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_autoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_autoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _f_ProductoEmpaqueMedida() As FichaProducto.Prd_Medida.c_Registro
                        Try
                            Dim xv As New FichaProducto.Prd_Medida
                            xv.F_BuscarMedida(_AutoEmpaqueMedida)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_ContenidoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_contempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_contempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaqueMedida() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_ContenidoEmpaqueMedida._ContenidoCampo Is Nothing, 0, Me.c_ContenidoEmpaqueMedida._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_NombreEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_nombreempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombreempaq = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_tipoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaPrecioMayor() As CampoDato
                        Get
                            Return Me.f_prd_tipopreciomay
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipopreciomay = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaPrecioMayor() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _MontoIva() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad * _TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property


                    Property c_EtiquetaFormato() As CampoDato
                        Get
                            Return Me.f_etiq_formato
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_formato = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaFormato() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaFormato._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaFormato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDepartamento() As CampoDato
                        Get
                            Return Me.f_etiq_depart
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_depart = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDepartamento() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDepartamento._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDepartamento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaSeccion() As CampoDato
                        Get
                            Return Me.f_etiq_seccion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_seccion = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaSeccion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaSeccion._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaSeccion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaVendedor() As CampoDato
                        Get
                            Return Me.f_etiq_vendedor
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaVendedor() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaVendedor._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaVendedor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPlu() As CampoDato
                        Get
                            Return Me.f_etiq_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_plu = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPlu() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPlu._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaPlu._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPeso() As CampoDato
                        Get
                            Return Me.f_etiq_peso
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_peso = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPeso() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPeso._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPeso._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPrecio() As CampoDato
                        Get
                            Return Me.f_etiq_precio
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_precio = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPrecio() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPrecio._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPrecio._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaControl() As CampoDato
                        Get
                            Return Me.f_etiq_control
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_control = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaControl() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaControl._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaControl._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDigitos() As CampoDato
                        Get
                            Return Me.f_etiq_digitos
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_digitos = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDigitos() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDigitos._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDigitos._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaTicket() As CampoDato
                        Get
                            Return Me.f_etiq_ticket
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_ticket = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaTicket() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaTicket._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaTicket._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaBalanza() As CampoDato
                        Get
                            Return Me.f_etiq_balanza
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_balanza = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaBalanza() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaBalanza._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaBalanza._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaImporteMonto() As CampoDato
                        Get
                            Return Me.f_etiq_monto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_monto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaImporteMonto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_EtiquetaImporteMonto._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaImporteMonto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_EtiquetaItem() As CampoDato
                        Get
                            Return Me.f_etiq_item
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_item = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaItem._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaAuto() As CampoDato
                        Get
                            Return Me.f_etiq_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_auto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaAuto() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaAuto._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaAuto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_IdEquipo() As CampoDato
                        Get
                            Return Me.f_id_equipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_id_equipo = value
                        End Set
                    End Property

                    ReadOnly Property _IdEquipo() As String
                        Get
                            Dim xv As String = IIf(Me.c_IdEquipo._RetornarValor(Of String)() Is Nothing, "", Me.c_IdEquipo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return Me.f_autousuario
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_autousuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoItem() As CampoDato
                        Get
                            Return Me.f_prd_tipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoItem() As TipoItemPos
                        Get
                            Dim xv As String = IIf(Me.c_TipoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoItem._RetornarValor(Of String)())
                            Select Case xv
                                Case 1 : Return TipoItemPos.ItemCodigoBarra
                                Case 2 : Return TipoItemPos.Plu
                                Case 3 : Return TipoItemPos.PreEmpaque
                                Case 4 : Return TipoItemPos.Mayor
                                Case 5 : Return TipoItemPos.Ticket
                                Case 6 : Return TipoItemPos.Departamento
                                Case 7 : Return TipoItemPos.Tarjeta
                            End Select
                        End Get
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return Me.f_notas_item
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_notas_item = value
                        End Set
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_NotasItem._RetornarValor(Of String)() Is Nothing, "", Me.c_NotasItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase POS ONLIE - VENTA " + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoEmpaqueMedida = New CampoDato("Prd_AutoEmpaq", 10)
                        Me.c_AutoItem = New CampoDato("autoitem", 10)
                        Me.c_AutoJornada = New CampoDato("autojornada", 10)
                        Me.c_AutoOperador = New CampoDato("autooperador", 10)
                        Me.c_AutoProducto = New CampoDato("Prd_Automatico", 10)
                        Me.c_Cantidad = New CampoDato("Prd_Cantidad")
                        Me.c_CodigoBarraLeido = New CampoDato("Prd_CodigoBarra", 15)
                        Me.c_ContenidoEmpaqueMedida = New CampoDato("Prd_ContenidoEmpaq")
                        Me.c_EnOferta = New CampoDato("Prd_EsOferta", 1)
                        Me.c_EsPesado = New CampoDato("Prd_EsPesado", 1)
                        Me.c_NombreCorto = New CampoDato("Prd_NombreCorto", 40)
                        Me.c_NombreEmpaqueMedida = New CampoDato("Prd_NombreEmpaq", 15)
                        Me.c_PLU = New CampoDato("Prd_Plu", 5)
                        Me.c_PrecioNeto = New CampoDato("Prd_PrecioNeto")
                        Me.c_PrecioRegular = New CampoDato("Prd_PrecioVenta")
                        Me.c_PrecioSugerido = New CampoDato("Prd_PSugerido")
                        Me.c_ReferenciaEmpaqueMedida = New CampoDato("Prd_TipoEmpaq", 1)
                        Me.c_ReferenciaPrecioMayor = New CampoDato("Prd_TipoPrecioMay", 1)
                        Me.c_TasaIva = New CampoDato("Prd_TasaIva")
                        Me.c_TipoTasaIva = New CampoDato("Prd_TasaTipo", 1)

                        Me.c_EtiquetaAuto = New CampoDato("etiq_auto", 10)
                        Me.c_EtiquetaBalanza = New CampoDato("etiq_balanza", 15)
                        Me.c_EtiquetaControl = New CampoDato("etiq_control", 15)
                        Me.c_EtiquetaDepartamento = New CampoDato("etiq_depart", 15)
                        Me.c_EtiquetaDigitos = New CampoDato("etiq_digitos", 15)
                        Me.c_EtiquetaFormato = New CampoDato("etiq_formato", 15)
                        Me.c_EtiquetaImporteMonto = New CampoDato("etiq_monto")
                        Me.c_EtiquetaItem = New CampoDato("etiq_item")
                        Me.c_EtiquetaPeso = New CampoDato("etiq_peso")
                        Me.c_EtiquetaPlu = New CampoDato("etiq_plu", 15)
                        Me.c_EtiquetaPrecio = New CampoDato("etiq_precio")
                        Me.c_EtiquetaSeccion = New CampoDato("etiq_seccion", 15)
                        Me.c_EtiquetaTicket = New CampoDato("etiq_ticket", 15)
                        Me.c_EtiquetaVendedor = New CampoDato("etiq_vendedor", 15)

                        Me.c_IdEquipo = New CampoDato("id_equipo", 60)
                        Me.c_AutoUsuario = New CampoDato("autousuario", 10)
                        Me.c_TipoItem = New CampoDato("prd_tipo", 1)
                        Me.c_NotasItem = New CampoDato("notas_item", 120)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoEmpaqueMedida._ContenidoCampo = xrow(.c_AutoEmpaqueMedida._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_CodigoBarraLeido._ContenidoCampo = xrow(.c_CodigoBarraLeido._NombreCampo)
                                .c_ContenidoEmpaqueMedida._ContenidoCampo = xrow(.c_ContenidoEmpaqueMedida._NombreCampo)
                                .c_EnOferta._ContenidoCampo = xrow(.c_EnOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_NombreCorto._ContenidoCampo = xrow(.c_NombreCorto._NombreCampo)
                                .c_NombreEmpaqueMedida._ContenidoCampo = xrow(.c_NombreEmpaqueMedida._NombreCampo)
                                .c_PLU._ContenidoCampo = xrow(.c_PLU._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_PrecioRegular._ContenidoCampo = xrow(.c_PrecioRegular._NombreCampo)
                                .c_PrecioSugerido._ContenidoCampo = xrow(.c_PrecioSugerido._NombreCampo)
                                .c_ReferenciaEmpaqueMedida._ContenidoCampo = xrow(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                .c_ReferenciaPrecioMayor._ContenidoCampo = xrow(.c_ReferenciaPrecioMayor._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)

                                .c_EtiquetaAuto._ContenidoCampo = xrow(.c_EtiquetaAuto._NombreCampo)
                                .c_EtiquetaBalanza._ContenidoCampo = xrow(.c_EtiquetaBalanza._NombreCampo)
                                .c_EtiquetaControl._ContenidoCampo = xrow(.c_EtiquetaControl._NombreCampo)
                                .c_EtiquetaDepartamento._ContenidoCampo = xrow(.c_EtiquetaDepartamento._NombreCampo)
                                .c_EtiquetaDigitos._ContenidoCampo = xrow(.c_EtiquetaDigitos._NombreCampo)
                                .c_EtiquetaFormato._ContenidoCampo = xrow(.c_EtiquetaFormato._NombreCampo)
                                .c_EtiquetaImporteMonto._ContenidoCampo = xrow(.c_EtiquetaImporteMonto._NombreCampo)
                                .c_EtiquetaItem._ContenidoCampo = xrow(.c_EtiquetaItem._NombreCampo)
                                .c_EtiquetaPeso._ContenidoCampo = xrow(.c_EtiquetaPeso._NombreCampo)
                                .c_EtiquetaPlu._ContenidoCampo = xrow(.c_EtiquetaPlu._NombreCampo)
                                .c_EtiquetaPrecio._ContenidoCampo = xrow(.c_EtiquetaPrecio._NombreCampo)
                                .c_EtiquetaSeccion._ContenidoCampo = xrow(.c_EtiquetaSeccion._NombreCampo)
                                .c_EtiquetaTicket._ContenidoCampo = xrow(.c_EtiquetaTicket._NombreCampo)
                                .c_EtiquetaVendedor._ContenidoCampo = xrow(.c_EtiquetaVendedor._NombreCampo)

                                If Not IsDBNull(xrow(.c_IdEquipo._NombreCampo)) Then
                                    .c_IdEquipo._ContenidoCampo = xrow(.c_IdEquipo._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_AutoUsuario._NombreCampo)) Then
                                    .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_TipoItem._NombreCampo)) Then
                                    .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_NotasItem._NombreCampo)) Then
                                    .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR ITEM VENTA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT As String = "INSERT INTO POS_Venta (" & _
                    "AutoItem," & _
                    "AutoJornada," & _
                    "AutoOperador," & _
                    "Prd_Automatico," & _
                    "Prd_NombreCorto," & _
                    "Prd_Cantidad," & _
                    "Prd_PrecioNeto," & _
                    "Prd_TasaIva," & _
                    "Prd_TasaTipo," & _
                    "Prd_EsOferta," & _
                    "Prd_EsPesado," & _
                    "Prd_PrecioVenta," & _
                    "Prd_CodigoBarra," & _
                    "Prd_Plu," & _
                    "Prd_PSugerido," & _
                    "Prd_AutoEmpaq," & _
                    "Prd_ContenidoEmpaq," & _
                    "Prd_NombreEmpaq," & _
                    "Prd_TipoEmpaq," & _
                    "Prd_TipoPrecioMay," & _
                    "etiq_formato," & _
                    "etiq_depart," & _
                    "etiq_seccion," & _
                    "etiq_vendedor," & _
                    "etiq_plu," & _
                    "etiq_peso," & _
                    "etiq_precio," & _
                    "etiq_control," & _
                    "etiq_digitos," & _
                    "etiq_ticket," & _
                    "etiq_balanza," & _
                    "etiq_monto," & _
                    "etiq_item," & _
                    "etiq_auto, id_equipo, AutoUsuario, prd_tipo, notas_item) " & _
                    "VALUES (" & _
                    "@AutoItem," & _
                    "@AutoJornada," & _
                    "@AutoOperador," & _
                    "@Prd_Automatico," & _
                    "@Prd_NombreCorto," & _
                    "@Prd_Cantidad," & _
                    "@Prd_PrecioNeto," & _
                    "@Prd_TasaIva," & _
                    "@Prd_TasaTipo," & _
                    "@Prd_EsOferta," & _
                    "@Prd_EsPesado," & _
                    "@Prd_PrecioVenta," & _
                    "@Prd_CodigoBarra," & _
                    "@Prd_Plu," & _
                    "@Prd_PSugerido," & _
                    "@Prd_AutoEmpaq," & _
                    "@Prd_ContenidoEmpaq," & _
                    "@Prd_NombreEmpaq," & _
                    "@Prd_TipoEmpaq," & _
                    "@Prd_TipoPrecioMay," & _
                    "@etiq_formato," & _
                    "@etiq_depart," & _
                    "@etiq_seccion," & _
                    "@etiq_vendedor," & _
                    "@etiq_plu," & _
                    "@etiq_peso," & _
                    "@etiq_precio," & _
                    "@etiq_control," & _
                    "@etiq_digitos," & _
                    "@etiq_ticket," & _
                    "@etiq_balanza," & _
                    "@etiq_monto," & _
                    "@etiq_item," & _
                    "@etiq_auto, @id_equipo, @AutoUsuario, @prd_tipo, @notas_item)"


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

                Function F_BuscarCargar(ByVal xauto_item As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from pos_venta where autoitem=@autoitem", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@autoitem", xauto_item)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Throw New Exception("POS - VENTA:" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Public Class PendienteEncabezado
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
                    Private f_id_equipo As CampoDato


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

                    Property c_IdEquipo() As CampoDato
                        Get
                            Return f_id_equipo
                        End Get
                        Set(ByVal value As CampoDato)
                            f_id_equipo = value
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

                    ReadOnly Property _IdEquipo() As String
                        Get
                            Dim xv As String = IIf(Me.f_id_equipo._RetornarValor(Of String)() Is Nothing, "", Me.f_id_equipo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CLASE PENDIENTE ENCABEZADO - POS VENTA" + vbCrLf + ex.Message
                            Throw New Exception(x)
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
                        Me.c_IdEquipo = New CampoDato("id_equipo", 60)
                        M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

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

                                If Not IsDBNull(xrow(.c_AutoCliente._NombreCampo)) Then
                                    .c_AutoCliente._ContenidoCampo = xrow(.c_AutoCliente._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_IdEquipo._NombreCampo)) Then
                                    .c_IdEquipo._ContenidoCampo = xrow(.c_IdEquipo._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AS CARGAR DATA POS-VENTA PENDIENTE ENCABEZADO" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_PENDIENTE_ENCABEZADO As String = "INSERT INTO POS_VENTA_PENDENCABEZADO (" _
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
                 + "nombre_pendiente, auto_cliente, id_equipo) " _
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
                 + "@nombre_pendiente, @auto_cliente,@id_equipo) "

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

                Function F_BuscarCargar(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from pos_venta_pendencabezado where auto_doc=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Throw New Exception("ENCABEZADO PENDIENTE:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class PendienteDetalle
                Class c_Registro
                    Private f_autodoc_encabezado As CampoDato
                    Private f_prd_automatico As CampoDato
                    Private f_prd_nombrecorto As CampoDato
                    Private f_prd_cantidad As CampoDato
                    Private f_prd_precioneto As CampoDato
                    Private f_prd_tasaiva As CampoDato
                    Private f_prd_tasatipo As CampoDato
                    Private f_prd_esoferta As CampoDato
                    Private f_prd_espesado As CampoDato
                    Private f_prd_precioventa As CampoDato
                    Private f_prd_codigobarra As CampoDato
                    Private f_prd_plu As CampoDato
                    Private f_prd_psugerido As CampoDato
                    Private f_prd_autoempaq As CampoDato
                    Private f_prd_contempaq As CampoDato
                    Private f_prd_nombreempaq As CampoDato
                    Private f_prd_tipoempaq As CampoDato
                    Private f_prd_tipopreciomay As CampoDato
                    Private f_etiq_formato As CampoDato
                    Private f_etiq_depart As CampoDato
                    Private f_etiq_seccion As CampoDato
                    Private f_etiq_vendedor As CampoDato
                    Private f_etiq_plu As CampoDato
                    Private f_etiq_peso As CampoDato
                    Private f_etiq_precio As CampoDato
                    Private f_etiq_control As CampoDato
                    Private f_etiq_digitos As CampoDato
                    Private f_etiq_ticket As CampoDato
                    Private f_etiq_balanza As CampoDato
                    Private f_etiq_monto As CampoDato
                    Private f_etiq_item As CampoDato
                    Private f_etiq_auto As CampoDato
                    Private f_prd_tipo As CampoDato
                    Private f_notas_item As CampoDato


                    Property c_AutoDocEncabezado() As CampoDato
                        Get
                            Return f_autodoc_encabezado
                        End Get
                        Set(ByVal value As CampoDato)
                            f_autodoc_encabezado = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocEncabezado() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDocEncabezado._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDocEncabezado._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoProducto() As CampoDato
                        Get
                            Return Me.f_prd_automatico
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_automatico = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoProducto._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoProducto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_Producto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xv As New FichaProducto.Prd_Producto
                                xv.F_BuscarCargarFichaProducto(_AutoProducto)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_NombreCorto() As CampoDato
                        Get
                            Return Me.f_prd_nombrecorto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombrecorto = value
                        End Set
                    End Property

                    ReadOnly Property _NombreCorto() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreCorto._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreCorto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return Me.f_prd_cantidad
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Cantidad._ContenidoCampo Is Nothing, 0, Me.c_Cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return Me.f_prd_precioneto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioneto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioVenta() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioNeto._ContenidoCampo Is Nothing, 0, Me.c_PrecioNeto._RetornarValor(Of Decimal)())
                            Dim xpv As New Precio(xv, _TasaIva)
                            Return xpv
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasaiva
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasaiva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TipoTasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasatipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasatipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasaIva._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasaIva._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                                Case Else : Throw New Exception("ERROR TASA IVA DEL PRODUCTO")
                            End Select
                        End Get
                    End Property

                    Property c_EnOferta() As CampoDato
                        Get
                            Return Me.f_prd_esoferta
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _EnOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EnOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EnOferta._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return Me.f_prd_espesado
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _EsPesado() As ModoUsoPesado
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return ModoUsoPesado.EsItem
                                Case "1" : Return ModoUsoPesado.EsPesado
                                Case "2" : Return ModoUsoPesado.EsPesadoUnidad
                            End Select
                        End Get
                    End Property

                    Property c_PrecioRegular() As CampoDato
                        Get
                            Return Me.f_prd_precioventa
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioventa = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioRegular() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioRegular._ContenidoCampo Is Nothing, 0, Me.c_PrecioRegular._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CodigoBarraLeido() As CampoDato
                        Get
                            Return Me.f_prd_codigobarra
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarraLeido() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoBarraLeido._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoBarraLeido._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PLU() As CampoDato
                        Get
                            Return Me.f_prd_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PLU() As String
                        Get
                            Dim xv As String = IIf(Me.c_PLU._RetornarValor(Of String)() Is Nothing, "", Me.c_PLU._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioSugerido() As CampoDato
                        Get
                            Return Me.f_prd_psugerido
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_psugerido = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioSugerido() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioSugerido._ContenidoCampo Is Nothing, 0, Me.c_PrecioSugerido._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_AutoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_autoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_autoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _f_ProductoEmpaqueMedida() As FichaProducto.Prd_Medida.c_Registro
                        Try
                            Dim xv As New FichaProducto.Prd_Medida
                            xv.F_BuscarMedida(_AutoEmpaqueMedida)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_ContenidoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_contempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_contempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaqueMedida() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_ContenidoEmpaqueMedida._ContenidoCampo Is Nothing, 0, Me.c_ContenidoEmpaqueMedida._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_NombreEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_nombreempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombreempaq = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_tipoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaPrecioMayor() As CampoDato
                        Get
                            Return Me.f_prd_tipopreciomay
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipopreciomay = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaPrecioMayor() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _MontoIva() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad * _TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TotalItem() As Decimal
                        Get
                            Dim ximp As Decimal = _PrecioVenta._Base * _Cantidad
                            Dim xiva As Decimal = ximp * _TasaIva / 100
                            Return Decimal.Round(ximp + xiva, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Property c_EtiquetaFormato() As CampoDato
                        Get
                            Return Me.f_etiq_formato
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_formato = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaFormato() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaFormato._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaFormato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDepartamento() As CampoDato
                        Get
                            Return Me.f_etiq_depart
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_depart = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDepartamento() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDepartamento._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDepartamento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaSeccion() As CampoDato
                        Get
                            Return Me.f_etiq_seccion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_seccion = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaSeccion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaSeccion._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaSeccion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaVendedor() As CampoDato
                        Get
                            Return Me.f_etiq_vendedor
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaVendedor() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaVendedor._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaVendedor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPlu() As CampoDato
                        Get
                            Return Me.f_etiq_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_plu = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPlu() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPlu._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaPlu._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPeso() As CampoDato
                        Get
                            Return Me.f_etiq_peso
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_peso = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPeso() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPeso._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPeso._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPrecio() As CampoDato
                        Get
                            Return Me.f_etiq_precio
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_precio = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPrecio() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPrecio._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPrecio._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaControl() As CampoDato
                        Get
                            Return Me.f_etiq_control
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_control = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaControl() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaControl._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaControl._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDigitos() As CampoDato
                        Get
                            Return Me.f_etiq_digitos
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_digitos = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDigitos() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDigitos._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDigitos._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaTicket() As CampoDato
                        Get
                            Return Me.f_etiq_ticket
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_ticket = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaTicket() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaTicket._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaTicket._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaBalanza() As CampoDato
                        Get
                            Return Me.f_etiq_balanza
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_balanza = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaBalanza() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaBalanza._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaBalanza._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaImporteMonto() As CampoDato
                        Get
                            Return Me.f_etiq_monto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_monto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaImporteMonto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_EtiquetaImporteMonto._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaImporteMonto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_EtiquetaItem() As CampoDato
                        Get
                            Return Me.f_etiq_item
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_item = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaItem._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaAuto() As CampoDato
                        Get
                            Return Me.f_etiq_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_auto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaAuto() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaAuto._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaAuto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoItem() As CampoDato
                        Get
                            Return Me.f_prd_tipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoItem() As TipoItemPos
                        Get
                            Dim xv As String = IIf(Me.c_TipoItem._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoItem._RetornarValor(Of String)())
                            Select Case xv
                                Case 1 : Return TipoItemPos.ItemCodigoBarra
                                Case 2 : Return TipoItemPos.Plu
                                Case 3 : Return TipoItemPos.PreEmpaque
                                Case 4 : Return TipoItemPos.Mayor
                                Case 5 : Return TipoItemPos.Ticket
                                Case 6 : Return TipoItemPos.Departamento
                            End Select
                        End Get
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return Me.f_notas_item
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_notas_item = value
                        End Set
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_NotasItem._RetornarValor(Of String)() Is Nothing, "", Me.c_NotasItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CLASE PENDIENTE DETALLE" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoDocEncabezado = New CampoDato("autodoc_encabezado", 10)
                        Me.c_AutoEmpaqueMedida = New CampoDato("Prd_AutoEmpaq", 10)
                        Me.c_AutoProducto = New CampoDato("Prd_Automatico", 10)
                        Me.c_Cantidad = New CampoDato("Prd_Cantidad")
                        Me.c_CodigoBarraLeido = New CampoDato("Prd_CodigoBarra", 15)
                        Me.c_ContenidoEmpaqueMedida = New CampoDato("Prd_ContenidoEmpaq")
                        Me.c_EnOferta = New CampoDato("Prd_EsOferta", 1)
                        Me.c_EsPesado = New CampoDato("Prd_EsPesado", 1)
                        Me.c_NombreCorto = New CampoDato("Prd_NombreCorto", 40)
                        Me.c_NombreEmpaqueMedida = New CampoDato("Prd_NombreEmpaq", 15)
                        Me.c_PLU = New CampoDato("Prd_Plu", 5)
                        Me.c_PrecioNeto = New CampoDato("Prd_PrecioNeto")
                        Me.c_PrecioRegular = New CampoDato("Prd_PrecioVenta")
                        Me.c_PrecioSugerido = New CampoDato("Prd_PSugerido")
                        Me.c_ReferenciaEmpaqueMedida = New CampoDato("Prd_TipoEmpaq", 1)
                        Me.c_ReferenciaPrecioMayor = New CampoDato("Prd_TipoPrecioMay", 1)
                        Me.c_TasaIva = New CampoDato("Prd_TasaIva")
                        Me.c_TipoTasaIva = New CampoDato("Prd_TasaTipo", 1)

                        Me.c_EtiquetaAuto = New CampoDato("etiq_auto", 10)
                        Me.c_EtiquetaBalanza = New CampoDato("etiq_balanza", 15)
                        Me.c_EtiquetaControl = New CampoDato("etiq_control", 15)
                        Me.c_EtiquetaDepartamento = New CampoDato("etiq_depart", 15)
                        Me.c_EtiquetaDigitos = New CampoDato("etiq_digitos", 15)
                        Me.c_EtiquetaFormato = New CampoDato("etiq_formato", 15)
                        Me.c_EtiquetaImporteMonto = New CampoDato("etiq_monto")
                        Me.c_EtiquetaItem = New CampoDato("etiq_item")
                        Me.c_EtiquetaPeso = New CampoDato("etiq_peso")
                        Me.c_EtiquetaPlu = New CampoDato("etiq_plu", 15)
                        Me.c_EtiquetaPrecio = New CampoDato("etiq_precio")
                        Me.c_EtiquetaSeccion = New CampoDato("etiq_seccion", 15)
                        Me.c_EtiquetaTicket = New CampoDato("etiq_ticket", 15)
                        Me.c_EtiquetaVendedor = New CampoDato("etiq_vendedor", 15)

                        Me.c_TipoItem = New CampoDato("prd_tipo", 1)
                        Me.c_NotasItem = New CampoDato("notas_item", 120)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoDocEncabezado._ContenidoCampo = xrow(.c_AutoDocEncabezado._NombreCampo)
                                .c_AutoEmpaqueMedida._ContenidoCampo = xrow(.c_AutoEmpaqueMedida._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_CodigoBarraLeido._ContenidoCampo = xrow(.c_CodigoBarraLeido._NombreCampo)
                                .c_ContenidoEmpaqueMedida._ContenidoCampo = xrow(.c_ContenidoEmpaqueMedida._NombreCampo)
                                .c_EnOferta._ContenidoCampo = xrow(.c_EnOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_NombreCorto._ContenidoCampo = xrow(.c_NombreCorto._NombreCampo)
                                .c_NombreEmpaqueMedida._ContenidoCampo = xrow(.c_NombreEmpaqueMedida._NombreCampo)
                                .c_PLU._ContenidoCampo = xrow(.c_PLU._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_PrecioRegular._ContenidoCampo = xrow(.c_PrecioRegular._NombreCampo)
                                .c_PrecioSugerido._ContenidoCampo = xrow(.c_PrecioSugerido._NombreCampo)
                                .c_ReferenciaEmpaqueMedida._ContenidoCampo = xrow(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                .c_ReferenciaPrecioMayor._ContenidoCampo = xrow(.c_ReferenciaPrecioMayor._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)

                                .c_EtiquetaAuto._ContenidoCampo = xrow(.c_EtiquetaAuto._NombreCampo)
                                .c_EtiquetaBalanza._ContenidoCampo = xrow(.c_EtiquetaBalanza._NombreCampo)
                                .c_EtiquetaControl._ContenidoCampo = xrow(.c_EtiquetaControl._NombreCampo)
                                .c_EtiquetaDepartamento._ContenidoCampo = xrow(.c_EtiquetaDepartamento._NombreCampo)
                                .c_EtiquetaDigitos._ContenidoCampo = xrow(.c_EtiquetaDigitos._NombreCampo)
                                .c_EtiquetaFormato._ContenidoCampo = xrow(.c_EtiquetaFormato._NombreCampo)
                                .c_EtiquetaImporteMonto._ContenidoCampo = xrow(.c_EtiquetaImporteMonto._NombreCampo)
                                .c_EtiquetaItem._ContenidoCampo = xrow(.c_EtiquetaItem._NombreCampo)
                                .c_EtiquetaPeso._ContenidoCampo = xrow(.c_EtiquetaPeso._NombreCampo)
                                .c_EtiquetaPlu._ContenidoCampo = xrow(.c_EtiquetaPlu._NombreCampo)
                                .c_EtiquetaPrecio._ContenidoCampo = xrow(.c_EtiquetaPrecio._NombreCampo)
                                .c_EtiquetaSeccion._ContenidoCampo = xrow(.c_EtiquetaSeccion._NombreCampo)
                                .c_EtiquetaTicket._ContenidoCampo = xrow(.c_EtiquetaTicket._NombreCampo)
                                .c_EtiquetaVendedor._ContenidoCampo = xrow(.c_EtiquetaVendedor._NombreCampo)

                                If Not IsDBNull(xrow(.c_TipoItem._NombreCampo)) Then
                                    .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                End If
                                If Not IsDBNull(xrow(.c_NotasItem._NombreCampo)) Then
                                    .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR DETALLE PENDIENTE" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT As String = "INSERT INTO POS_Venta_PendDetalle (" & _
                    "AutoDoc_Encabezado," & _
                    "Prd_Automatico," & _
                    "Prd_NombreCorto," & _
                    "Prd_Cantidad," & _
                    "Prd_PrecioNeto," & _
                    "Prd_TasaIva," & _
                    "Prd_TasaTipo," & _
                    "Prd_EsOferta," & _
                    "Prd_EsPesado," & _
                    "Prd_PrecioVenta," & _
                    "Prd_CodigoBarra," & _
                    "Prd_Plu," & _
                    "Prd_PSugerido," & _
                    "Prd_AutoEmpaq," & _
                    "Prd_ContenidoEmpaq," & _
                    "Prd_NombreEmpaq," & _
                    "Prd_TipoEmpaq," & _
                    "Prd_TipoPrecioMay," & _
                    "etiq_formato," & _
                    "etiq_depart," & _
                    "etiq_seccion," & _
                    "etiq_vendedor," & _
                    "etiq_plu," & _
                    "etiq_peso," & _
                    "etiq_precio," & _
                    "etiq_control," & _
                    "etiq_digitos," & _
                    "etiq_ticket," & _
                    "etiq_balanza," & _
                    "etiq_monto," & _
                    "etiq_item," & _
                    "etiq_auto, prd_tipo, notas_item) " & _
                    "VALUES (" & _
                    "@AutoDoc_Encabezado," & _
                    "@Prd_Automatico," & _
                    "@Prd_NombreCorto," & _
                    "@Prd_Cantidad," & _
                    "@Prd_PrecioNeto," & _
                    "@Prd_TasaIva," & _
                    "@Prd_TasaTipo," & _
                    "@Prd_EsOferta," & _
                    "@Prd_EsPesado," & _
                    "@Prd_PrecioVenta," & _
                    "@Prd_CodigoBarra," & _
                    "@Prd_Plu," & _
                    "@Prd_PSugerido," & _
                    "@Prd_AutoEmpaq," & _
                    "@Prd_ContenidoEmpaq," & _
                    "@Prd_NombreEmpaq," & _
                    "@Prd_TipoEmpaq," & _
                    "@Prd_TipoPrecioMay," & _
                    "@etiq_formato," & _
                    "@etiq_depart," & _
                    "@etiq_seccion," & _
                    "@etiq_vendedor," & _
                    "@etiq_plu," & _
                    "@etiq_peso," & _
                    "@etiq_precio," & _
                    "@etiq_control," & _
                    "@etiq_digitos," & _
                    "@etiq_ticket," & _
                    "@etiq_balanza," & _
                    "@etiq_monto," & _
                    "@etiq_item," & _
                    "@etiq_auto, @prd_tipo, @notas_item)"


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

            Public Class DevolucionAnulacion
                Class c_Registro
                    Private f_prd_automatico As CampoDato
                    Private f_prd_nombrecorto As CampoDato
                    Private f_prd_cantidad As CampoDato
                    Private f_prd_precioneto As CampoDato
                    Private f_prd_tasaiva As CampoDato
                    Private f_prd_tasatipo As CampoDato
                    Private f_prd_esoferta As CampoDato
                    Private f_prd_espesado As CampoDato
                    Private f_prd_precioventa As CampoDato
                    Private f_prd_codigobarra As CampoDato
                    Private f_prd_plu As CampoDato
                    Private f_prd_psugerido As CampoDato
                    Private f_prd_autoempaq As CampoDato
                    Private f_prd_contempaq As CampoDato
                    Private f_prd_nombreempaq As CampoDato
                    Private f_prd_tipoempaq As CampoDato
                    Private f_prd_tipopreciomay As CampoDato
                    Private f_etiq_formato As CampoDato
                    Private f_etiq_depart As CampoDato
                    Private f_etiq_seccion As CampoDato
                    Private f_etiq_vendedor As CampoDato
                    Private f_etiq_plu As CampoDato
                    Private f_etiq_peso As CampoDato
                    Private f_etiq_precio As CampoDato
                    Private f_etiq_control As CampoDato
                    Private f_etiq_digitos As CampoDato
                    Private f_etiq_ticket As CampoDato
                    Private f_etiq_balanza As CampoDato
                    Private f_etiq_monto As CampoDato
                    Private f_etiq_item As CampoDato
                    Private f_etiq_auto As CampoDato
                    Private f_autojornada_devanu As CampoDato
                    Private f_autooperador_devanu As CampoDato
                    Private f_autousuario_devanu As CampoDato
                    Private f_nombreusuario_devanu As CampoDato
                    Private f_fecha_devanu As CampoDato
                    Private f_hora_devanu As CampoDato
                    Private f_nivelclave_devanu As CampoDato
                    Private f_estacion_devanu As CampoDato
                    Private f_tipo_devanu As CampoDato
                    Private f_auto_devanu As CampoDato


                    Property c_AutoProducto() As CampoDato
                        Get
                            Return Me.f_prd_automatico
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_automatico = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoProducto._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoProducto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_Producto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xv As New FichaProducto.Prd_Producto
                                xv.F_BuscarCargarFichaProducto(_AutoProducto)
                                Return xv.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_NombreCorto() As CampoDato
                        Get
                            Return Me.f_prd_nombrecorto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombrecorto = value
                        End Set
                    End Property

                    ReadOnly Property _NombreCorto() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreCorto._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreCorto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return Me.f_prd_cantidad
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Cantidad._ContenidoCampo Is Nothing, 0, Me.c_Cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return Me.f_prd_precioneto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioneto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioVenta() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioNeto._ContenidoCampo Is Nothing, 0, Me.c_PrecioNeto._RetornarValor(Of Decimal)())
                            Dim xpv As New Precio(xv, _TasaIva)
                            Return xpv
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasaiva
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasaiva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_TasaIva._ContenidoCampo Is Nothing, 0, Me.c_TasaIva._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TipoTasaIva() As CampoDato
                        Get
                            Return Me.f_prd_tasatipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tasatipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasaIva._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasaIva._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                                Case Else : Throw New Exception("ERROR TASA IVA DEL PRODUCTO")
                            End Select
                        End Get
                    End Property

                    Property c_EnOferta() As CampoDato
                        Get
                            Return Me.f_prd_esoferta
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _EnOferta() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.c_EnOferta._RetornarValor(Of String)() Is Nothing, "", Me.c_EnOferta._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    Property c_EsPesado() As CampoDato
                        Get
                            Return Me.f_prd_espesado
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _EsPesado() As ModoUsoPesado
                        Get
                            Dim xv As String = IIf(Me.c_EsPesado._RetornarValor(Of String)() Is Nothing, "", Me.c_EsPesado._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return ModoUsoPesado.EsItem
                                Case "1" : Return ModoUsoPesado.EsPesado
                                Case "2" : Return ModoUsoPesado.EsPesadoUnidad
                            End Select
                        End Get
                    End Property

                    Property c_PrecioRegular() As CampoDato
                        Get
                            Return Me.f_prd_precioventa
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_precioventa = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioRegular() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioRegular._ContenidoCampo Is Nothing, 0, Me.c_PrecioRegular._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_CodigoBarraLeido() As CampoDato
                        Get
                            Return Me.f_prd_codigobarra
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarraLeido() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoBarraLeido._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoBarraLeido._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PLU() As CampoDato
                        Get
                            Return Me.f_prd_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PLU() As String
                        Get
                            Dim xv As String = IIf(Me.c_PLU._RetornarValor(Of String)() Is Nothing, "", Me.c_PLU._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_PrecioSugerido() As CampoDato
                        Get
                            Return Me.f_prd_psugerido
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_psugerido = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioSugerido() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_PrecioSugerido._ContenidoCampo Is Nothing, 0, Me.c_PrecioSugerido._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_AutoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_autoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_autoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _f_ProductoEmpaqueMedida() As FichaProducto.Prd_Medida.c_Registro
                        Try
                            Dim xv As New FichaProducto.Prd_Medida
                            xv.F_BuscarMedida(_AutoEmpaqueMedida)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_ContenidoEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_contempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_contempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaqueMedida() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_ContenidoEmpaqueMedida._ContenidoCampo Is Nothing, 0, Me.c_ContenidoEmpaqueMedida._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_NombreEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_nombreempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_nombreempaq = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaEmpaqueMedida() As CampoDato
                        Get
                            Return Me.f_prd_tipoempaq
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipoempaq = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpaqueMedida() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaEmpaqueMedida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ReferenciaPrecioMayor() As CampoDato
                        Get
                            Return Me.f_prd_tipopreciomay
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_prd_tipopreciomay = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaPrecioMayor() As String
                        Get
                            Dim xv As String = IIf(Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)() Is Nothing, "", Me.c_ReferenciaPrecioMayor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _MontoIva() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(_PrecioVenta._Base * _Cantidad * _TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Property c_EtiquetaFormato() As CampoDato
                        Get
                            Return Me.f_etiq_formato
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_formato = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaFormato() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaFormato._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaFormato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDepartamento() As CampoDato
                        Get
                            Return Me.f_etiq_depart
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_depart = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDepartamento() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDepartamento._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDepartamento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaSeccion() As CampoDato
                        Get
                            Return Me.f_etiq_seccion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_seccion = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaSeccion() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaSeccion._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaSeccion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaVendedor() As CampoDato
                        Get
                            Return Me.f_etiq_vendedor
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaVendedor() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaVendedor._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaVendedor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPlu() As CampoDato
                        Get
                            Return Me.f_etiq_plu
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_plu = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPlu() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPlu._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaPlu._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPeso() As CampoDato
                        Get
                            Return Me.f_etiq_peso
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_peso = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPeso() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPeso._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPeso._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaPrecio() As CampoDato
                        Get
                            Return Me.f_etiq_precio
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_precio = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaPrecio() As Decimal
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaPrecio._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaPrecio._RetornarValor(Of Decimal)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaControl() As CampoDato
                        Get
                            Return Me.f_etiq_control
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_control = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaControl() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaControl._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaControl._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaDigitos() As CampoDato
                        Get
                            Return Me.f_etiq_digitos
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_digitos = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaDigitos() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaDigitos._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaDigitos._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaTicket() As CampoDato
                        Get
                            Return Me.f_etiq_ticket
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_ticket = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaTicket() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaTicket._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaTicket._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaBalanza() As CampoDato
                        Get
                            Return Me.f_etiq_balanza
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_balanza = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaBalanza() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaBalanza._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaBalanza._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaImporteMonto() As CampoDato
                        Get
                            Return Me.f_etiq_monto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_monto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaImporteMonto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_EtiquetaImporteMonto._ContenidoCampo Is Nothing, 0, Me.c_EtiquetaImporteMonto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_EtiquetaItem() As CampoDato
                        Get
                            Return Me.f_etiq_item
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_item = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaItem._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaItem._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EtiquetaAuto() As CampoDato
                        Get
                            Return Me.f_etiq_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_etiq_auto = value
                        End Set
                    End Property

                    ReadOnly Property _EtiquetaAuto() As String
                        Get
                            Dim xv As String = IIf(Me.c_EtiquetaAuto._RetornarValor(Of String)() Is Nothing, "", Me.c_EtiquetaAuto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_autojornada_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_autojornada_devanu = value
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
                            Return f_autooperador_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_autooperador_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_autousuario_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_autousuario_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return f_nombreusuario_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_nombreusuario_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return f_fecha_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_fecha_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _FechaDevAnu() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_Fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.c_Fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_HoraDevAnu() As CampoDato
                        Get
                            Return f_hora_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_hora_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _HoraDevAnu() As String
                        Get
                            Dim xv As String = IIf(Me.c_HoraDevAnu._RetornarValor(Of String)() Is Nothing, "", Me.c_HoraDevAnu._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EstacionDevAnu() As CampoDato
                        Get
                            Return f_estacion_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_estacion_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _EstacionDevAnu() As String
                        Get
                            Dim xv As String = IIf(Me.c_EstacionDevAnu._RetornarValor(Of String)() Is Nothing, "", Me.c_EstacionDevAnu._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NivelClaveDevAnu() As CampoDato
                        Get
                            Return f_nivelclave_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_nivelclave_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _NivelClaveDevAnu() As NivelClave
                        Get
                            Dim xv As String = IIf(Me.c_NivelClaveDevAnu._RetornarValor(Of String)() Is Nothing, "", Me.c_NivelClaveDevAnu._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return NivelClave.SinClave
                                Case "1" : Return NivelClave.Maxima
                                Case "2" : Return NivelClave.Media
                                Case "3" : Return NivelClave.Minima
                            End Select
                        End Get
                    End Property

                    Property c_TipoDevAnu() As CampoDato
                        Get
                            Return f_tipo_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_tipo_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDevAnu() As TipoDevolucionPos
                        Get
                            Dim xv As String = IIf(Me.c_TipoDevAnu._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoDevAnu._RetornarValor(Of String)())
                            Select Case xv
                                Case "1" : Return TipoDevolucionPos.Devolucion
                                Case "2" : Return TipoDevolucionPos.Anulacion
                                Case "3" : Return TipoDevolucionPos.DevolucionItem
                                Case "4" : Return TipoDevolucionPos.AnulacionPendiente
                            End Select
                        End Get
                    End Property

                    Property c_AutoDevAnu() As CampoDato
                        Get
                            Return f_auto_devanu
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_devanu = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDevAnu() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoDevAnu._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoDevAnu._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase POS DEVOLUCION-ANULACION" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoEmpaqueMedida = New CampoDato("Prd_AutoEmpaq", 10)
                        Me.c_AutoProducto = New CampoDato("Prd_Automatico", 10)
                        Me.c_Cantidad = New CampoDato("Prd_Cantidad")
                        Me.c_CodigoBarraLeido = New CampoDato("Prd_CodigoBarra", 15)
                        Me.c_ContenidoEmpaqueMedida = New CampoDato("Prd_ContenidoEmpaq")
                        Me.c_EnOferta = New CampoDato("Prd_EsOferta", 1)
                        Me.c_EsPesado = New CampoDato("Prd_EsPesado", 1)
                        Me.c_NombreCorto = New CampoDato("Prd_NombreCorto", 40)
                        Me.c_NombreEmpaqueMedida = New CampoDato("Prd_NombreEmpaq", 15)
                        Me.c_PLU = New CampoDato("Prd_Plu", 5)
                        Me.c_PrecioNeto = New CampoDato("Prd_PrecioNeto")
                        Me.c_PrecioRegular = New CampoDato("Prd_PrecioVenta")
                        Me.c_PrecioSugerido = New CampoDato("Prd_PSugerido")
                        Me.c_ReferenciaEmpaqueMedida = New CampoDato("Prd_TipoEmpaq", 1)
                        Me.c_ReferenciaPrecioMayor = New CampoDato("Prd_TipoPrecioMay", 1)
                        Me.c_TasaIva = New CampoDato("Prd_TasaIva")
                        Me.c_TipoTasaIva = New CampoDato("Prd_TasaTipo", 1)
                        Me.c_EtiquetaAuto = New CampoDato("etiq_auto", 10)
                        Me.c_EtiquetaBalanza = New CampoDato("etiq_balanza", 15)
                        Me.c_EtiquetaControl = New CampoDato("etiq_control", 15)
                        Me.c_EtiquetaDepartamento = New CampoDato("etiq_depart", 15)
                        Me.c_EtiquetaDigitos = New CampoDato("etiq_digitos", 15)
                        Me.c_EtiquetaFormato = New CampoDato("etiq_formato", 15)
                        Me.c_EtiquetaImporteMonto = New CampoDato("etiq_monto")
                        Me.c_EtiquetaItem = New CampoDato("etiq_item")
                        Me.c_EtiquetaPeso = New CampoDato("etiq_peso")
                        Me.c_EtiquetaPlu = New CampoDato("etiq_plu", 15)
                        Me.c_EtiquetaPrecio = New CampoDato("etiq_precio")
                        Me.c_EtiquetaSeccion = New CampoDato("etiq_seccion", 15)
                        Me.c_EtiquetaTicket = New CampoDato("etiq_ticket", 15)
                        Me.c_EtiquetaVendedor = New CampoDato("etiq_vendedor", 15)
                        Me.c_AutoDevAnu = New CampoDato("auto_devanu", 10)
                        Me.c_AutoJornada = New CampoDato("autojornada_devanu", 10)
                        Me.c_AutoOperador = New CampoDato("autooperador_devanu", 10)
                        Me.c_AutoUsuario = New CampoDato("autousuario_devanu", 10)
                        Me.c_Fecha = New CampoDato("fecha_devanu")
                        Me.c_HoraDevAnu = New CampoDato("hora_devanu", 10)
                        Me.c_EstacionDevAnu = New CampoDato("estacion_devanu", 20)
                        Me.c_NivelClaveDevAnu = New CampoDato("nivelclave_devanu", 1)
                        Me.c_NombreUsuario = New CampoDato("nombreusuario_devanu", 20)
                        Me.c_TipoDevAnu = New CampoDato("tipo_devanu", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoEmpaqueMedida._ContenidoCampo = xrow(.c_AutoEmpaqueMedida._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_CodigoBarraLeido._ContenidoCampo = xrow(.c_CodigoBarraLeido._NombreCampo)
                                .c_ContenidoEmpaqueMedida._ContenidoCampo = xrow(.c_ContenidoEmpaqueMedida._NombreCampo)
                                .c_EnOferta._ContenidoCampo = xrow(.c_EnOferta._NombreCampo)
                                .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                .c_NombreCorto._ContenidoCampo = xrow(.c_NombreCorto._NombreCampo)
                                .c_NombreEmpaqueMedida._ContenidoCampo = xrow(.c_NombreEmpaqueMedida._NombreCampo)
                                .c_PLU._ContenidoCampo = xrow(.c_PLU._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_PrecioRegular._ContenidoCampo = xrow(.c_PrecioRegular._NombreCampo)
                                .c_PrecioSugerido._ContenidoCampo = xrow(.c_PrecioSugerido._NombreCampo)
                                .c_ReferenciaEmpaqueMedida._ContenidoCampo = xrow(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                .c_ReferenciaPrecioMayor._ContenidoCampo = xrow(.c_ReferenciaPrecioMayor._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)
                                .c_EtiquetaAuto._ContenidoCampo = xrow(.c_EtiquetaAuto._NombreCampo)
                                .c_EtiquetaBalanza._ContenidoCampo = xrow(.c_EtiquetaBalanza._NombreCampo)
                                .c_EtiquetaControl._ContenidoCampo = xrow(.c_EtiquetaControl._NombreCampo)
                                .c_EtiquetaDepartamento._ContenidoCampo = xrow(.c_EtiquetaDepartamento._NombreCampo)
                                .c_EtiquetaDigitos._ContenidoCampo = xrow(.c_EtiquetaDigitos._NombreCampo)
                                .c_EtiquetaFormato._ContenidoCampo = xrow(.c_EtiquetaFormato._NombreCampo)
                                .c_EtiquetaImporteMonto._ContenidoCampo = xrow(.c_EtiquetaImporteMonto._NombreCampo)
                                .c_EtiquetaItem._ContenidoCampo = xrow(.c_EtiquetaItem._NombreCampo)
                                .c_EtiquetaPeso._ContenidoCampo = xrow(.c_EtiquetaPeso._NombreCampo)
                                .c_EtiquetaPlu._ContenidoCampo = xrow(.c_EtiquetaPlu._NombreCampo)
                                .c_EtiquetaPrecio._ContenidoCampo = xrow(.c_EtiquetaPrecio._NombreCampo)
                                .c_EtiquetaSeccion._ContenidoCampo = xrow(.c_EtiquetaSeccion._NombreCampo)
                                .c_EtiquetaTicket._ContenidoCampo = xrow(.c_EtiquetaTicket._NombreCampo)
                                .c_EtiquetaVendedor._ContenidoCampo = xrow(.c_EtiquetaVendedor._NombreCampo)

                                .c_AutoDevAnu._ContenidoCampo = xrow(.c_AutoDevAnu._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_EstacionDevAnu._ContenidoCampo = xrow(.c_EstacionDevAnu._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_HoraDevAnu._ContenidoCampo = xrow(.c_HoraDevAnu._NombreCampo)
                                .c_NivelClaveDevAnu._ContenidoCampo = xrow(.c_NivelClaveDevAnu._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_TipoDevAnu._ContenidoCampo = xrow(.c_TipoDevAnu._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR DEVOLUCION-ANULACION" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT As String = "INSERT INTO POS_Venta_DEVANULACION (" & _
                    "Prd_Automatico," & _
                    "Prd_NombreCorto," & _
                    "Prd_Cantidad," & _
                    "Prd_PrecioNeto," & _
                    "Prd_TasaIva," & _
                    "Prd_TasaTipo," & _
                    "Prd_EsOferta," & _
                    "Prd_EsPesado," & _
                    "Prd_PrecioVenta," & _
                    "Prd_CodigoBarra," & _
                    "Prd_Plu," & _
                    "Prd_PSugerido," & _
                    "Prd_AutoEmpaq," & _
                    "Prd_ContenidoEmpaq," & _
                    "Prd_NombreEmpaq," & _
                    "Prd_TipoEmpaq," & _
                    "Prd_TipoPrecioMay," & _
                    "etiq_formato," & _
                    "etiq_depart," & _
                    "etiq_seccion," & _
                    "etiq_vendedor," & _
                    "etiq_plu," & _
                    "etiq_peso," & _
                    "etiq_precio," & _
                    "etiq_control," & _
                    "etiq_digitos," & _
                    "etiq_ticket," & _
                    "etiq_balanza," & _
                    "etiq_monto," & _
                    "etiq_item," & _
                    "etiq_auto, " & _
                    "AutoJornada_DevAnu," & _
                    "AutoOperador_DevAnu," & _
                    "AutoUsuario_DevAnu," & _
                    "NombreUsuario_DevAnu," & _
                    "Fecha_DevAnu," & _
                    "Hora_DevAnu," & _
                    "Auto_DevAnu," & _
                    "Tipo_DevAnu," & _
                    "NivelClave_DevAnu," & _
                    "Estacion_DevAnu) " & _
                    "VALUES (" & _
                    "@Prd_Automatico," & _
                    "@Prd_NombreCorto," & _
                    "@Prd_Cantidad," & _
                    "@Prd_PrecioNeto," & _
                    "@Prd_TasaIva," & _
                    "@Prd_TasaTipo," & _
                    "@Prd_EsOferta," & _
                    "@Prd_EsPesado," & _
                    "@Prd_PrecioVenta," & _
                    "@Prd_CodigoBarra," & _
                    "@Prd_Plu," & _
                    "@Prd_PSugerido," & _
                    "@Prd_AutoEmpaq," & _
                    "@Prd_ContenidoEmpaq," & _
                    "@Prd_NombreEmpaq," & _
                    "@Prd_TipoEmpaq," & _
                    "@Prd_TipoPrecioMay," & _
                    "@etiq_formato," & _
                    "@etiq_depart," & _
                    "@etiq_seccion," & _
                    "@etiq_vendedor," & _
                    "@etiq_plu," & _
                    "@etiq_peso," & _
                    "@etiq_precio," & _
                    "@etiq_control," & _
                    "@etiq_digitos," & _
                    "@etiq_ticket," & _
                    "@etiq_balanza," & _
                    "@etiq_monto," & _
                    "@etiq_item," & _
                    "@etiq_auto, " & _
                    "@AutoJornada_DevAnu," & _
                    "@AutoOperador_DevAnu," & _
                    "@AutoUsuario_DevAnu," & _
                    "@NombreUsuario_DevAnu," & _
                    "@Fecha_DevAnu," & _
                    "@Hora_DevAnu," & _
                    "@Auto_DevAnu," & _
                    "@Tipo_DevAnu," & _
                    "@NivelClave_DevAnu," & _
                    "@Estacion_DevAnu)"


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


            Public Class AgregarRegistroPosVenta_PorCodigoBarra
                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xcodigobarra As String
                Private xidequipo As String

                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property

                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
                    End Set
                End Property

                Property _CodigoBarra() As String
                    Get
                        Return xcodigobarra
                    End Get
                    Set(ByVal value As String)
                        xcodigobarra = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Cantidad() As Integer
                    Get
                        Return 1
                    End Get
                End Property

                Protected Friend ReadOnly Property _ReferenciaEmpaque() As String
                    Get
                        Return "5"
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "1"
                    End Get
                End Property

                Sub New()
                    Me._CodigoBarra = ""
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._FichaUsuario = Nothing
                    Me._IdEquipo = ""
                End Sub
            End Class

            Public Class AgregarRegistroPosVenta_PorPLU
                Enum TipoEntrada As Integer
                    PorPeso = 0
                    PorPrecio = 1
                End Enum

                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xpeso As Decimal
                Private xprecio As Decimal
                Private xtipo_entrada As TipoEntrada
                Private xmodopesado As ModoUsoPesado
                Private xidequipo As String
                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property

                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
                    End Set
                End Property

                Property _Peso() As Decimal
                    Get
                        Return xpeso
                    End Get
                    Set(ByVal value As Decimal)
                        xpeso = value
                    End Set
                End Property

                Property _Precio() As Decimal
                    Get
                        Return xprecio
                    End Get
                    Set(ByVal value As Decimal)
                        xprecio = value
                    End Set
                End Property

                Property _TipoEntrada() As TipoEntrada
                    Get
                        Return xtipo_entrada
                    End Get
                    Set(ByVal value As TipoEntrada)
                        xtipo_entrada = value
                    End Set
                End Property

                Property _ModoPesado() As ModoUsoPesado
                    Get
                        Return Me.xmodopesado
                    End Get
                    Set(ByVal value As ModoUsoPesado)
                        Me.xmodopesado = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _ReferenciaEmpaque() As String
                    Get
                        Return "5"
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "2"
                    End Get
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Sub New()
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._Peso = 0
                    Me._Precio = 0
                    Me._TipoEntrada = TipoEntrada.PorPeso
                    Me._ModoPesado = ModoUsoPesado.EsPesado
                    Me._IdEquipo = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Public Class AgregarRegistroPosVenta_PorPreEmpaque
                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xmodopesado As ModoUsoPesado
                Private xcodigobarra As String
                Private xempq_control As String
                Private xempq_departamento As String
                Private xempq_digitos As String
                Private xempq_formato As String
                Private xempq_monto As Decimal
                Private xempq_peso As Decimal
                Private xempq_plu As String
                Private xempq_precio As String
                Private xempq_seccion As String
                Private xempq_ticket As String
                Private xempq_vendedor As String
                Private xidequipo As String

                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property


                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
                    End Set
                End Property

                Property _ModoPesado() As ModoUsoPesado
                    Get
                        Return Me.xmodopesado
                    End Get
                    Set(ByVal value As ModoUsoPesado)
                        Me.xmodopesado = value
                    End Set
                End Property

                Property _CodigoBarra() As String
                    Get
                        Return xcodigobarra.Trim
                    End Get
                    Set(ByVal value As String)
                        xcodigobarra = value
                    End Set
                End Property

                Property PEmpq_DigitosControl() As String
                    Get
                        Return xempq_control.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_control = value
                    End Set
                End Property

                Property PEmpq_Departamento() As String
                    Get
                        Return xempq_departamento.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_departamento = value
                    End Set
                End Property

                Property PEmpq_Digitos() As String
                    Get
                        Return xempq_digitos.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_digitos = value
                    End Set
                End Property

                Property PEmpq_Formato() As String
                    Get
                        Return xempq_formato.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_formato = value
                    End Set
                End Property

                Property PEmpq_Monto() As Decimal
                    Get
                        Return xempq_monto
                    End Get
                    Set(ByVal value As Decimal)
                        xempq_monto = value
                    End Set
                End Property

                Property PEmpq_Peso() As Decimal
                    Get
                        Return xempq_peso
                    End Get
                    Set(ByVal value As Decimal)
                        xempq_peso = value
                    End Set
                End Property

                Property PEmpq_PLU() As String
                    Get
                        Return xempq_plu.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_plu = value
                    End Set
                End Property

                Property PEmpq_Precio() As Decimal
                    Get
                        Return xempq_precio
                    End Get
                    Set(ByVal value As Decimal)
                        xempq_precio = value
                    End Set
                End Property

                Property PEmpq_Seccion() As String
                    Get
                        Return xempq_seccion.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_seccion = value
                    End Set
                End Property

                Property PEmpq_Ticket() As String
                    Get
                        Return xempq_ticket.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_ticket = value
                    End Set
                End Property

                Property PEmpq_Vendedor() As String
                    Get
                        Return xempq_vendedor.Trim
                    End Get
                    Set(ByVal value As String)
                        xempq_vendedor = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _ReferenciaEmpaque() As String
                    Get
                        Return "5"
                    End Get
                End Property

                Protected Friend ReadOnly Property _Peso() As Decimal
                    Get
                        Return Me.PEmpq_Peso
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "3"
                    End Get
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Sub New()
                    Me._CodigoBarra = ""
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._ModoPesado = ModoUsoPesado.EsPesado

                    Me.PEmpq_Departamento = ""
                    Me.PEmpq_Digitos = ""
                    Me.PEmpq_DigitosControl = ""
                    Me.PEmpq_Formato = ""
                    Me.PEmpq_Monto = 0
                    Me.PEmpq_Peso = 0
                    Me.PEmpq_PLU = ""
                    Me.PEmpq_Precio = 0
                    Me.PEmpq_Seccion = ""
                    Me.PEmpq_Ticket = ""
                    Me.PEmpq_Vendedor = ""

                    Me._IdEquipo = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Public Class AgregarRegistroPosVenta_PorMayor
                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xficha_productoempaque As FichaProducto.Prd_Empaque.c_Registro
                Private xcantidad As Decimal
                Private xmodopesado As ModoUsoPesado
                Private xidequipo As String

                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property


                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
                    End Set
                End Property

                Property _FichaProductoEmpaque() As FichaProducto.Prd_Empaque.c_Registro
                    Get
                        Return xficha_productoempaque
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Empaque.c_Registro)
                        xficha_productoempaque = value
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

                Property _ModoPesado() As ModoUsoPesado
                    Get
                        Return Me.xmodopesado
                    End Get
                    Set(ByVal value As ModoUsoPesado)
                        Me.xmodopesado = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "4"
                    End Get
                End Property

                Sub New()
                    Me._Cantidad = 0
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._FichaProductoEmpaque = Nothing
                    Me._ModoPesado = ModoUsoPesado.EsPesado
                    Me._IdEquipo = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Public Class AgregarRegistroPosVenta_PorDescripcionDetal
                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xcantidad As Decimal
                Private xmodopesado As ModoUsoPesado
                Private xidequipo As String

                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property


                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
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

                Property _ModoPesado() As ModoUsoPesado
                    Get
                        Return Me.xmodopesado
                    End Get
                    Set(ByVal value As ModoUsoPesado)
                        Me.xmodopesado = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "1"
                    End Get
                End Property

                Sub New()
                    Me._Cantidad = 0
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._ModoPesado = ModoUsoPesado.EsPesado
                    Me._IdEquipo = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Public Class AgregarRegistroPosVenta_PorDepartamento
                Private xficha_operadorjornadaactiva As FastFood.OperadorJornada_Activa
                Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                Private xnombre As String
                Private xmonto As Decimal
                Private xidequipo As String

                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichausuario = value
                    End Set
                End Property


                Property _FichaOperadorJornadaActiva() As FastFood.OperadorJornada_Activa
                    Get
                        Return xficha_operadorjornadaactiva
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada_Activa)
                        xficha_operadorjornadaactiva = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return xficha_producto
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        xficha_producto = value
                    End Set
                End Property

                Property _NombreDepartamento() As String
                    Get
                        Return xnombre.Trim
                    End Get
                    Set(ByVal value As String)
                        xnombre = value
                    End Set
                End Property

                Property _Monto() As Decimal
                    Get
                        Return xmonto
                    End Get
                    Set(ByVal value As Decimal)
                        xmonto = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _ReferenciaEmpaque() As String
                    Get
                        Return "5"
                    End Get
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _TipoItem() As String
                    Get
                        Return "6"
                    End Get
                End Property


                Sub New()
                    Me._FichaOperadorJornadaActiva = Nothing
                    Me._FichaProducto = Nothing
                    Me._Monto = 0
                    Me._NombreDepartamento = ""
                    Me._IdEquipo = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Public Class AgregarCtaPendiente
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xnombre As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xcliente As FichaClientes.c_Clientes.c_Registro
                Private xidequipo As String


                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
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

                Property _NombrePendiente() As String
                    Get
                        Return xnombre
                    End Get
                    Set(ByVal value As String)
                        xnombre = value
                    End Set
                End Property

                Property _Cliente() As FichaClientes.c_Clientes.c_Registro
                    Get
                        Return xcliente
                    End Get
                    Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                        xcliente = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property


                Sub New()
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._NombrePendiente = ""
                    Me._Cliente = Nothing
                    Me._IdEquipo = ""
                End Sub
            End Class

            Public Class AbrirCtaPendiente
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xfichaAbrir As PendienteEncabezado.c_Registro
                Private xid As String


                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Property _FichaAbrir() As PendienteEncabezado.c_Registro
                    Get
                        Return xfichaAbrir
                    End Get
                    Set(ByVal value As PendienteEncabezado.c_Registro)
                        xfichaAbrir = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
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

                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property


                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaAbrir = Nothing
                    Me._FichaUsuario = Nothing
                    Me._IdEquipo = ""
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                End Sub
            End Class

            Public Class AgregarDevolucion
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xfichaprd As FichaProducto.Prd_Producto.c_Registro
                Private xid As String


                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "1"
                    End Get
                End Property

                Protected Friend ReadOnly Property _AutoDevAnu() As String
                    Get
                        Return ""
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property

                Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                    Get
                        Return Me.xfichaprd
                    End Get
                    Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                        Me.xfichaprd = value
                    End Set
                End Property

                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._FichaProducto = Nothing
                    Me._IdEquipo = ""
                End Sub
            End Class

            Public Class AgregarAnulacion
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xid As String


                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "2"
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property


                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._IdEquipo = ""
                End Sub
            End Class

            Public Class AgregarAnulacionPendiente
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xencabezadopend As PendienteEncabezado.c_Registro
                Private xid As String


                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "4"
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property

                Property _EncabezadoPendiente() As PendienteEncabezado.c_Registro
                    Get
                        Return xencabezadopend
                    End Get
                    Set(ByVal value As PendienteEncabezado.c_Registro)
                        xencabezadopend = value
                    End Set
                End Property


                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._IdEquipo = ""
                    Me._EncabezadoPendiente = Nothing
                End Sub
            End Class

            Public Class AgregarAnulacionPendienteTodas
                Enum TipoAlcanze As Integer
                    PorUsuario = 1
                    Todas = 2
                End Enum
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xid As String
                Private xalcanze As TipoAlcanze

                Property _Alcance() As TipoAlcanze
                    Get
                        Return xalcanze
                    End Get
                    Set(ByVal value As TipoAlcanze)
                        xalcanze = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "4"
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property

                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._IdEquipo = ""
                    Me._Alcance = TipoAlcanze.PorUsuario
                End Sub
            End Class


            Public Class AgregarDevolucionItem
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xfichaitem As PosVenta.c_Registro
                Private xid As String


                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "3"
                    End Get
                End Property

                Protected Friend ReadOnly Property _AutoDevAnu() As String
                    Get
                        Return ""
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property

                Property _FichaItem() As PosVenta.c_Registro
                    Get
                        Return Me.xfichaitem
                    End Get
                    Set(ByVal value As PosVenta.c_Registro)
                        Me.xfichaitem = value
                    End Set
                End Property

                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._FichaItem = Nothing
                    Me._IdEquipo = ""
                End Sub
            End Class

            Public Class AgregarDevolucionCantidadItem
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xnivelclave As NivelClave
                Private xfichaitem As PosVenta.c_Registro
                Private xid As String
                Private xcantidad As Decimal


                Property _IdEquipo() As String
                    Get
                        Return xid
                    End Get
                    Set(ByVal value As String)
                        xid = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString()
                    End Get
                End Property

                Protected Friend ReadOnly Property _TipoDevAnu() As String
                    Get
                        Return "1"
                    End Get
                End Property

                Protected Friend ReadOnly Property _AutoDevAnu() As String
                    Get
                        Return ""
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

                Property _NivelCave() As NivelClave
                    Get
                        Return xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        xnivelclave = value
                    End Set
                End Property

                Property _FichaItem() As PosVenta.c_Registro
                    Get
                        Return Me.xfichaitem
                    End Get
                    Set(ByVal value As PosVenta.c_Registro)
                        Me.xfichaitem = value
                    End Set
                End Property

                Property _CantidadDevolver() As Decimal
                    Get
                        Return xcantidad
                    End Get
                    Set(ByVal value As Decimal)
                        xcantidad = value
                    End Set
                End Property

                Sub New()
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._NivelCave = NivelClave.SinClave
                    Me._FichaItem = Nothing
                    Me._IdEquipo = ""
                    Me._CantidadDevolver = 0
                End Sub
            End Class

            Public Class AgregarTarjetaPendiente
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xcliente As FichaClientes.c_Clientes.c_Registro
                Private xidequipo As String
                Private ximpresora As ImpFiscales.MisFiscales.IFiscal
                Private xtotal As Decimal


                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
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

                Property _Cliente() As FichaClientes.c_Clientes.c_Registro
                    Get
                        Return xcliente
                    End Get
                    Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                        xcliente = value
                    End Set
                End Property

                Property _IdEquipo() As String
                    Get
                        Return xidequipo
                    End Get
                    Set(ByVal value As String)
                        xidequipo = value
                    End Set
                End Property

                Property _Impresora() As ImpFiscales.MisFiscales.IFiscal
                    Get
                        Return ximpresora
                    End Get
                    Set(ByVal value As ImpFiscales.MisFiscales.IFiscal)
                        ximpresora = value
                    End Set
                End Property

                Property _TotalCta() As Decimal
                    Get
                        Return xtotal
                    End Get
                    Set(ByVal value As Decimal)
                        xtotal = value
                    End Set
                End Property


                Sub New()
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._EquipoEstacion = ""
                    Me._FichaUsuario = Nothing
                    Me._Cliente = Nothing
                    Me._IdEquipo = ""
                    Me._Impresora = Nothing
                    Me._TotalCta = 0
                End Sub
            End Class


            Function f_AgregarRegistroPosVenta_PorCodigoBarra(ByVal xregistro As AgregarRegistroPosVenta_PorCodigoBarra) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = xregistro._Cantidad
                        .c_CodigoBarraLeido._ContenidoCampo = xregistro._CodigoBarra
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._ContEmpqVentaDetal
                        If xregistro._FichaProducto.f_VerificarOferta Then
                            .c_EnOferta._ContenidoCampo = "1"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioOferta._Base
                        Else
                            .c_EnOferta._ContenidoCampo = "0"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        End If
                        .c_EsPesado._ContenidoCampo = "0"
                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = ""
                        .c_EtiquetaDepartamento._ContenidoCampo = ""
                        .c_EtiquetaDigitos._ContenidoCampo = ""
                        .c_EtiquetaFormato._ContenidoCampo = ""
                        .c_EtiquetaImporteMonto._ContenidoCampo = 0
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = 0
                        .c_EtiquetaPlu._ContenidoCampo = ""
                        .c_EtiquetaPrecio._ContenidoCampo = 0
                        .c_EtiquetaSeccion._ContenidoCampo = ""
                        .c_EtiquetaTicket._ContenidoCampo = ""
                        .c_EtiquetaVendedor._ContenidoCampo = ""
                        .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._NombreEmpaqueVentaDetal
                        .c_PLU._ContenidoCampo = ""
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xregistro._ReferenciaEmpaque
                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()

                            RaiseEvent _RegistroVentaOk()
                            RaiseEvent _FichaUltimoItemRegistrado(xreg._AutoItem)
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_AgregarRegistroPosVenta_PorPLU(ByVal xregistro As AgregarRegistroPosVenta_PorPLU) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = xregistro._Peso
                        .c_CodigoBarraLeido._ContenidoCampo = ""
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._ContEmpqVentaDetal
                        If xregistro._FichaProducto.f_VerificarOferta Then
                            .c_EnOferta._ContenidoCampo = "1"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioOferta._Base
                        Else
                            .c_EnOferta._ContenidoCampo = "0"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        End If
                        If xregistro._ModoPesado = ModoUsoPesado.EsPesado Then
                            .c_EsPesado._ContenidoCampo = "1"
                        Else
                            .c_EsPesado._ContenidoCampo = "2"
                        End If

                        If xregistro._TipoEntrada = AgregarRegistroPosVenta_PorPLU.TipoEntrada.PorPrecio Then
                            .c_PrecioNeto._ContenidoCampo = Decimal.Round(xregistro._Precio / (1 + (xregistro._FichaProducto._TasaImpuesto / 100)), 2, MidpointRounding.AwayFromZero)
                            If .c_PrecioNeto._ContenidoCampo > 0 Then
                                .c_Cantidad._ContenidoCampo = Decimal.Round(xregistro._FichaProducto._PrecioDetal._Base / .c_PrecioNeto._ContenidoCampo, 3, MidpointRounding.AwayFromZero)
                            Else
                                .c_Cantidad._ContenidoCampo = 0
                            End If

                            If .c_PrecioNeto._ContenidoCampo = 0 Then
                                Throw New Exception("PRECIO A DESPACHAR INCORRECTO, NO PUEDE SER CERO (0). VERIFIQUE")
                            End If
                        End If

                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = ""
                        .c_EtiquetaDepartamento._ContenidoCampo = ""
                        .c_EtiquetaDigitos._ContenidoCampo = ""
                        .c_EtiquetaFormato._ContenidoCampo = ""
                        .c_EtiquetaImporteMonto._ContenidoCampo = 0
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = 0
                        .c_EtiquetaPlu._ContenidoCampo = ""
                        .c_EtiquetaPrecio._ContenidoCampo = 0
                        .c_EtiquetaSeccion._ContenidoCampo = ""
                        .c_EtiquetaTicket._ContenidoCampo = ""
                        .c_EtiquetaVendedor._ContenidoCampo = ""
                        .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._NombreEmpaqueVentaDetal
                        .c_PLU._ContenidoCampo = xregistro._FichaProducto._PLU
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xregistro._ReferenciaEmpaque
                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _RegistroVentaOk()
                            If xregistro._ModoPesado = ModoUsoPesado.EsPesado Then
                                RaiseEvent _FichaUltimoItemRegistrado("")
                            Else
                                RaiseEvent _FichaUltimoItemRegistrado(xreg._AutoItem)
                            End If
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_AgregarRegistroPosVenta_PorPreEmpaque(ByVal xregistro As AgregarRegistroPosVenta_PorPreEmpaque) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = xregistro._Peso
                        .c_CodigoBarraLeido._ContenidoCampo = xregistro._CodigoBarra
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._ContEmpqVentaDetal
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto

                        If xregistro._FichaProducto.f_VerificarOferta Then
                            .c_EnOferta._ContenidoCampo = "1"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioOferta._Base
                        Else
                            .c_EnOferta._ContenidoCampo = "0"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        End If
                        If xregistro._ModoPesado = ModoUsoPesado.EsPesado Then
                            .c_EsPesado._ContenidoCampo = "1"
                        Else
                            .c_EsPesado._ContenidoCampo = "2"
                        End If

                        If xregistro._Peso = 0 Then
                            If xregistro.PEmpq_Precio > 0 Then
                                If ._PrecioVenta._Base > 0 Then
                                    .c_Cantidad._ContenidoCampo = Decimal.Round(xregistro.PEmpq_Precio / ._PrecioVenta._Full, 3, MidpointRounding.AwayFromZero)
                                End If
                            End If
                        End If

                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = xregistro.PEmpq_DigitosControl
                        .c_EtiquetaDepartamento._ContenidoCampo = xregistro.PEmpq_Departamento
                        .c_EtiquetaDigitos._ContenidoCampo = xregistro.PEmpq_Digitos
                        .c_EtiquetaFormato._ContenidoCampo = xregistro.PEmpq_Formato
                        .c_EtiquetaImporteMonto._ContenidoCampo = xregistro.PEmpq_Monto
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = xregistro.PEmpq_Peso
                        .c_EtiquetaPlu._ContenidoCampo = xregistro.PEmpq_PLU
                        .c_EtiquetaPrecio._ContenidoCampo = xregistro.PEmpq_Precio
                        .c_EtiquetaSeccion._ContenidoCampo = xregistro.PEmpq_Seccion
                        .c_EtiquetaTicket._ContenidoCampo = xregistro.PEmpq_Ticket
                        .c_EtiquetaVendedor._ContenidoCampo = xregistro.PEmpq_Vendedor
                        .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._NombreEmpaqueVentaDetal
                        .c_PLU._ContenidoCampo = ""
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xregistro._ReferenciaEmpaque
                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _RegistroVentaOk()
                            RaiseEvent _FichaUltimoItemRegistrado("")
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_AgregarRegistroPosVenta_PorDepartamento(ByVal xregistro As AgregarRegistroPosVenta_PorDepartamento) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = 1
                        .c_CodigoBarraLeido._ContenidoCampo = ""
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._ContEmpqVentaDetal
                        .c_EnOferta._ContenidoCampo = "0"
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto
                        .c_PrecioNeto._ContenidoCampo = New Precio(xregistro._Monto, ._TasaIva, Precio.TipoFuncion.Desglozar)._Base
                        .c_EsPesado._ContenidoCampo = "0"
                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = ""
                        .c_EtiquetaDepartamento._ContenidoCampo = ""
                        .c_EtiquetaDigitos._ContenidoCampo = ""
                        .c_EtiquetaFormato._ContenidoCampo = ""
                        .c_EtiquetaImporteMonto._ContenidoCampo = 0
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = 0
                        .c_EtiquetaPlu._ContenidoCampo = ""
                        .c_EtiquetaPrecio._ContenidoCampo = 0
                        .c_EtiquetaSeccion._ContenidoCampo = ""
                        .c_EtiquetaTicket._ContenidoCampo = ""
                        .c_EtiquetaVendedor._ContenidoCampo = ""
                        If xregistro._NombreDepartamento = "" Then
                            .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        Else
                            .c_NombreCorto._ContenidoCampo = xregistro._NombreDepartamento
                        End If
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._NombreEmpaqueVentaDetal
                        .c_PLU._ContenidoCampo = xregistro._FichaProducto._PLU
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xregistro._ReferenciaEmpaque
                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _RegistroVentaOk()
                            RaiseEvent _FichaUltimoItemRegistrado(xreg._AutoItem)
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_AgregarRegistroPosVenta_PorMayor(ByVal xregistro As AgregarRegistroPosVenta_PorMayor) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = xregistro._Cantidad
                        .c_CodigoBarraLeido._ContenidoCampo = ""
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProductoEmpaque._ContenidoEmpaque
                        .c_EnOferta._ContenidoCampo = "0"
                        .c_PrecioNeto._ContenidoCampo = xregistro._FichaProductoEmpaque._PrecioNeto_1

                        Select Case xregistro._ModoPesado
                            Case ModoUsoPesado.EsItem : .c_EsPesado._ContenidoCampo = "0"
                            Case ModoUsoPesado.EsPesado : .c_EsPesado._ContenidoCampo = "1"
                            Case ModoUsoPesado.EsPesadoUnidad : .c_EsPesado._ContenidoCampo = "2"
                        End Select

                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = ""
                        .c_EtiquetaDepartamento._ContenidoCampo = ""
                        .c_EtiquetaDigitos._ContenidoCampo = ""
                        .c_EtiquetaFormato._ContenidoCampo = ""
                        .c_EtiquetaImporteMonto._ContenidoCampo = 0
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = 0
                        .c_EtiquetaPlu._ContenidoCampo = ""
                        .c_EtiquetaPrecio._ContenidoCampo = 0
                        .c_EtiquetaSeccion._ContenidoCampo = ""
                        .c_EtiquetaTicket._ContenidoCampo = ""
                        .c_EtiquetaVendedor._ContenidoCampo = ""
                        .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProductoEmpaque._f_FichaMedida._NombreMedida
                        .c_PLU._ContenidoCampo = ""
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProductoEmpaque._PrecioNeto_1
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xregistro._FichaProductoEmpaque._ReferenciaEmpaqueSeleccionado
                        .c_ReferenciaPrecioMayor._ContenidoCampo = "1"
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _RegistroVentaOk()
                            If xregistro._ModoPesado = ModoUsoPesado.EsPesado Then
                                RaiseEvent _FichaUltimoItemRegistrado("")
                            Else
                                RaiseEvent _FichaUltimoItemRegistrado(xreg._AutoItem)
                            End If
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_AgregarRegistroPosVenta_PorDescripcionDetal(ByVal xregistro As AgregarRegistroPosVenta_PorDescripcionDetal) As Boolean
                Try
                    Dim xreg As New PosOnline.PosVenta.c_Registro
                    With xreg
                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._AutoEmpaqueVentaDetal
                        .c_AutoItem._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xregistro._FichaOperadorJornadaActiva.RegistroDato._AutoOperador
                        .c_AutoProducto._ContenidoCampo = xregistro._FichaProducto._AutoProducto
                        .c_Cantidad._ContenidoCampo = xregistro._Cantidad
                        .c_CodigoBarraLeido._ContenidoCampo = ""
                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._ContEmpqVentaDetal

                        If xregistro._FichaProducto.f_VerificarOferta Then
                            .c_EnOferta._ContenidoCampo = "1"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioOferta._Base
                        Else
                            .c_EnOferta._ContenidoCampo = "0"
                            .c_PrecioNeto._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        End If

                        Select Case xregistro._ModoPesado
                            Case ModoUsoPesado.EsItem : .c_EsPesado._ContenidoCampo = "0"
                            Case ModoUsoPesado.EsPesado : .c_EsPesado._ContenidoCampo = "1"
                            Case ModoUsoPesado.EsPesadoUnidad : .c_EsPesado._ContenidoCampo = "2"
                        End Select

                        .c_EtiquetaAuto._ContenidoCampo = ""
                        .c_EtiquetaBalanza._ContenidoCampo = ""
                        .c_EtiquetaControl._ContenidoCampo = ""
                        .c_EtiquetaDepartamento._ContenidoCampo = ""
                        .c_EtiquetaDigitos._ContenidoCampo = ""
                        .c_EtiquetaFormato._ContenidoCampo = ""
                        .c_EtiquetaImporteMonto._ContenidoCampo = 0
                        .c_EtiquetaItem._ContenidoCampo = 0
                        .c_EtiquetaPeso._ContenidoCampo = 0
                        .c_EtiquetaPlu._ContenidoCampo = ""
                        .c_EtiquetaPrecio._ContenidoCampo = 0
                        .c_EtiquetaSeccion._ContenidoCampo = ""
                        .c_EtiquetaTicket._ContenidoCampo = ""
                        .c_EtiquetaVendedor._ContenidoCampo = ""
                        .c_NombreCorto._ContenidoCampo = xregistro._FichaProducto._DescripcionResumenDelProducto
                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._FichaProducto._NombreEmpaqueVentaDetal
                        .c_PLU._ContenidoCampo = ""
                        .c_PrecioRegular._ContenidoCampo = xregistro._FichaProducto._PrecioDetal._Base
                        .c_PrecioSugerido._ContenidoCampo = xregistro._FichaProducto._PrecioSugerido
                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = "5"
                        .c_ReferenciaPrecioMayor._ContenidoCampo = "1"
                        .c_TasaIva._ContenidoCampo = xregistro._FichaProducto._TasaImpuesto
                        Select Case xregistro._FichaProducto._TipoImpuesto
                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                        End Select
                        .c_IdEquipo._ContenidoCampo = xregistro._IdEquipo
                        .c_AutoUsuario._ContenidoCampo = xregistro._FichaUsuario._AutoUsuario
                        .c_TipoItem._ContenidoCampo = xregistro._TipoItem
                        .c_NotasItem._ContenidoCampo = ""
                    End With

                    If xreg._Cantidad = 0 Then
                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                    End If

                    If xreg._PrecioVenta._Base = 0 Then
                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                    End If

                    If xreg._f_Producto._EstatusProducto = TipoEstatus.Inactivo Then
                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_posventa_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                xreg.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosVenta.INSERT
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoEmpaqueMedida._NombreCampo, xreg._AutoEmpaqueMedida).Size = xreg.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoItem._NombreCampo, xreg._AutoItem).Size = xreg.c_AutoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoProducto._NombreCampo, xreg._AutoProducto).Size = xreg.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_Cantidad._NombreCampo, xreg._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_CodigoBarraLeido._NombreCampo, xreg._CodigoBarraLeido).Size = xreg.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ContenidoEmpaqueMedida._NombreCampo, xreg._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EnOferta._NombreCampo, xreg.c_EnOferta._ContenidoCampo).Size = xreg.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EsPesado._NombreCampo, xreg.c_EsPesado._ContenidoCampo).Size = xreg.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaAuto._NombreCampo, xreg._EtiquetaAuto).Size = xreg.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaBalanza._NombreCampo, xreg._EtiquetaBalanza).Size = xreg.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaControl._NombreCampo, xreg._EtiquetaControl).Size = xreg.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDepartamento._NombreCampo, xreg._EtiquetaDepartamento).Size = xreg.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaDigitos._NombreCampo, xreg._EtiquetaDigitos).Size = xreg.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaFormato._NombreCampo, xreg._EtiquetaFormato).Size = xreg.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaImporteMonto._NombreCampo, xreg._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaItem._NombreCampo, xreg._EtiquetaItem).Size = xreg.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPeso._NombreCampo, xreg._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPlu._NombreCampo, xreg._EtiquetaPlu).Size = xreg.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaPrecio._NombreCampo, xreg._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaSeccion._NombreCampo, xreg._EtiquetaSeccion).Size = xreg.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaTicket._NombreCampo, xreg._EtiquetaTicket).Size = xreg.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_EtiquetaVendedor._NombreCampo, xreg._EtiquetaVendedor).Size = xreg.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreCorto._NombreCampo, xreg._NombreCorto).Size = xreg.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NombreEmpaqueMedida._NombreCampo, xreg._NombreEmpaqueMedida).Size = xreg.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PLU._NombreCampo, xreg._PLU).Size = xreg.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioNeto._NombreCampo, xreg._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioRegular._NombreCampo, xreg._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_PrecioSugerido._NombreCampo, xreg._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaEmpaqueMedida._NombreCampo, xreg._ReferenciaEmpaqueMedida).Size = xreg.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_ReferenciaPrecioMayor._NombreCampo, xreg._ReferenciaPrecioMayor).Size = xreg.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TasaIva._NombreCampo, xreg._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoTasaIva._NombreCampo, xreg.c_TipoTasaIva._ContenidoCampo).Size = xreg.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg.c_IdEquipo._ContenidoCampo).Size = xreg.c_IdEquipo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg.c_AutoUsuario._ContenidoCampo).Size = xreg.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_TipoItem._NombreCampo, xreg.c_TipoItem._ContenidoCampo).Size = xreg.c_TipoItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xreg.c_NotasItem._NombreCampo, xreg.c_NotasItem._ContenidoCampo).Size = xreg.c_NotasItem._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _RegistroVentaOk()
                            If xregistro._ModoPesado = ModoUsoPesado.EsPesado Then
                                RaiseEvent _FichaUltimoItemRegistrado("")
                            Else
                                RaiseEvent _FichaUltimoItemRegistrado(xreg._AutoItem)
                            End If
                            RaiseEvent _VisorPrecio(xreg._NombreCorto, xreg._Cantidad, xreg._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            RaiseEvent _ErrorRegistro()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR REGISTRO POS VENTA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_ActualizarNotasItem(ByVal xnotas As String, ByVal xficha As PosVenta.c_Registro) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta set notas_item=@notas where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._AutoItem)
                                xcmd.Parameters.AddWithValue("@notas", xnotas)
                                xcmd.ExecuteNonQuery()
                            End Using

                            RaiseEvent _NotasItemActualizadaOk()
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    RaiseEvent _ErrorRegistro()
                    Throw New Exception("ACTUALIZAR CANTIDAD DEL ITEM" + vbCrLf + ex.Message)
                End Try
            End Function


            Function f_ActualizarCantidadItem(ByVal xcant As Integer, ByVal xficha As PosVenta.c_Registro) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta set prd_cantidad=prd_cantidad+@cant where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._AutoItem)
                                xcmd.Parameters.AddWithValue("@cant", xcant)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select prd_cantidad from pos_venta where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._AutoItem)
                                If xcmd.ExecuteScalar <= 0 Then
                                    Throw New Exception("ITEM NO PUEDE SER ELIMINADO")
                                End If
                            End Using
                            xtr.Commit()

                            RaiseEvent _RegistroVentaOk()
                            RaiseEvent _FichaUltimoItemRegistrado(xficha._AutoItem)
                            RaiseEvent _VisorActualizarCantidadVenta(xficha._NombreCorto, xficha._Cantidad, xficha._PrecioVenta._Full)
                            Return True

                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    RaiseEvent _ErrorRegistro()
                    Throw New Exception("ACTUALIZAR CANTIDAD DEL ITEM" + vbCrLf + ex.Message)
                End Try
            End Function

            Function f_ActualizarVendedor(ByVal xcodigovend As String, ByVal xficha As PosVenta.c_Registro) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta set etiq_vendedor=@codigo where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._AutoItem)
                                xcmd.Parameters.AddWithValue("@codigo", xcodigovend)
                                xcmd.ExecuteNonQuery()
                            End Using

                            RaiseEvent _VendedorActualizado()
                            RaiseEvent _FichaUltimoItemRegistrado("")
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    RaiseEvent _ErrorRegistro()
                    Throw New Exception("ACTUALIZAR VENDEDOR DEL ITEM" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_DejarCtaPendiente(ByVal xcta As AgregarCtaPendiente) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xreg As New PendienteEncabezado.c_Registro
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xtb_balanza As New DataTable

                    With xreg
                        .c_AutoCliente._ContenidoCampo = xcta._Cliente.r_Automatico
                        .c_AutoJornada._ContenidoCampo = xcta._Jornada._AutoJornada
                        .c_AutoMovimiento._ContenidoCampo = ""
                        .c_AutoOperador._ContenidoCampo = xcta._Operador._AutoOperador
                        .c_AutoUsuario._ContenidoCampo = xcta._FichaUsuario._AutoUsuario
                        .c_EquipoEstacion._ContenidoCampo = xcta._EquipoEstacion
                        .c_Fecha._ContenidoCampo = xcta._Fecha
                        .c_Hora._ContenidoCampo = xcta._Hora
                        .c_Items._ContenidoCampo = 0
                        .c_MontoTotal._ContenidoCampo = 0
                        .c_NombrePendiente._ContenidoCampo = xcta._NombrePendiente
                        .c_NombreUsuario._ContenidoCampo = xcta._FichaUsuario._NombreUsuario
                        .c_IdEquipo._ContenidoCampo = xcta._IdEquipo
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = "select a_posventa_pendiente from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_posventa_pendiente=0"
                                    xcmd.ExecuteScalar()
                                End If
                                xcmd.CommandText = "update contadores set a_posventa_pendiente=a_posventa_pendiente+1; " _
                                    + "select a_posventa_pendiente from contadores"
                                xreg.c_AutoMovimiento._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from pos_venta where autojornada=@jornada and autooperador=@operador " & _
                                "and autousuario=@usuario and id_equipo=@id"
                                xcmd.Parameters.AddWithValue("@jornada", xreg._AutoJornada)
                                xcmd.Parameters.AddWithValue("@operador", xreg._AutoOperador)
                                xcmd.Parameters.AddWithValue("@usuario", xreg._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xcta._IdEquipo)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("PROBLEMA AL DEJAR ITEMS PENDIENTES, AL PARECER YA FUERON PROCESADOS")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select etiq_auto as auto from POS_Venta where AutoJornada=@jornada and AutoOperador=@operador " & _
                                "and AutoUsuario=@usuario and id_equipo=@id and etiq_auto<>'' group by etiq_auto"
                                xcmd.Parameters.AddWithValue("@jornada", xreg._AutoJornada)
                                xcmd.Parameters.AddWithValue("@operador", xreg._AutoOperador)
                                xcmd.Parameters.AddWithValue("@usuario", xreg._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xcta._IdEquipo)
                                xrd = xcmd.ExecuteReader()
                                xtb_balanza.Load(xrd)
                                xrd.Close()

                                xreg.c_Items._ContenidoCampo = xtb.Rows.Count
                                xreg.c_MontoTotal._ContenidoCampo = (From x In xtb.AsEnumerable Select x.Field(Of Decimal)("prd_importe")).Sum

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosOnline.PendienteEncabezado.INSERT_PENDIENTE_ENCABEZADO
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
                                    .AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg._IdEquipo).Size = xreg.c_IdEquipo._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()

                                Dim xtotalpend As Decimal = 0
                                For Each xr As DataRow In xtb.Rows
                                    Dim xdetpend As New PendienteDetalle.c_Registro
                                    With xdetpend
                                        .c_AutoDocEncabezado._ContenidoCampo = xreg._AutoMovimiento
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                        .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                        .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                        .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                        .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                        .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                        .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                        .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                        .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                        .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                        .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                        .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                        .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                        .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                        .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                        .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                        .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                        .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                        .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                        .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                        .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                        .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                        .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                        .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                        .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                        .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                        .c_TipoItem._ContenidoCampo = xr(.c_TipoItem._NombreCampo)
                                        .c_NotasItem._ContenidoCampo = xr(.c_NotasItem._NombreCampo)
                                    End With
                                    xtotalpend += xdetpend._TotalItem

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PendienteDetalle.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoDocEncabezado._NombreCampo, xdetpend._AutoDocEncabezado).Size = xdetpend.c_AutoDocEncabezado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoEmpaqueMedida._NombreCampo, xdetpend._AutoEmpaqueMedida).Size = xdetpend.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoProducto._NombreCampo, xdetpend._AutoProducto).Size = xdetpend.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_Cantidad._NombreCampo, xdetpend._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_CodigoBarraLeido._NombreCampo, xdetpend._CodigoBarraLeido).Size = xdetpend.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ContenidoEmpaqueMedida._NombreCampo, xdetpend._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EnOferta._NombreCampo, xdetpend.c_EnOferta._ContenidoCampo).Size = xdetpend.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EsPesado._NombreCampo, xdetpend.c_EsPesado._ContenidoCampo).Size = xdetpend.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaAuto._NombreCampo, xdetpend._EtiquetaAuto).Size = xdetpend.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaBalanza._NombreCampo, xdetpend._EtiquetaBalanza).Size = xdetpend.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaControl._NombreCampo, xdetpend._EtiquetaControl).Size = xdetpend.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaDepartamento._NombreCampo, xdetpend._EtiquetaDepartamento).Size = xdetpend.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaDigitos._NombreCampo, xdetpend._EtiquetaDigitos).Size = xdetpend.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaFormato._NombreCampo, xdetpend._EtiquetaFormato).Size = xdetpend.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaImporteMonto._NombreCampo, xdetpend._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaItem._NombreCampo, xdetpend._EtiquetaItem).Size = xdetpend.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPeso._NombreCampo, xdetpend._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPlu._NombreCampo, xdetpend._EtiquetaPlu).Size = xdetpend.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPrecio._NombreCampo, xdetpend._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaSeccion._NombreCampo, xdetpend._EtiquetaSeccion).Size = xdetpend.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaTicket._NombreCampo, xdetpend._EtiquetaTicket).Size = xdetpend.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaVendedor._NombreCampo, xdetpend._EtiquetaVendedor).Size = xdetpend.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NombreCorto._NombreCampo, xdetpend._NombreCorto).Size = xdetpend.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NombreEmpaqueMedida._NombreCampo, xdetpend._NombreEmpaqueMedida).Size = xdetpend.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PLU._NombreCampo, xdetpend._PLU).Size = xdetpend.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioNeto._NombreCampo, xdetpend._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioRegular._NombreCampo, xdetpend._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioSugerido._NombreCampo, xdetpend._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ReferenciaEmpaqueMedida._NombreCampo, xdetpend._ReferenciaEmpaqueMedida).Size = xdetpend.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ReferenciaPrecioMayor._NombreCampo, xdetpend._ReferenciaPrecioMayor).Size = xdetpend.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TasaIva._NombreCampo, xdetpend._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TipoTasaIva._NombreCampo, xdetpend.c_TipoTasaIva._ContenidoCampo).Size = xdetpend.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TipoItem._NombreCampo, xdetpend.c_TipoItem._ContenidoCampo).Size = xdetpend.c_TipoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NotasItem._NombreCampo, xdetpend.c_NotasItem._ContenidoCampo).Size = xdetpend.c_NotasItem._LargoCampo
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from pos_venta where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xr("autoitem").ToString)
                                    If xcmd.ExecuteNonQuery = 0 Then
                                        Throw New Exception("PROBLEMA AL DEJAR ITEM PENDIENTE, AL PARECER YA FUE PROCESADO")
                                    End If
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta_pendencabezado set monto_doc=@total where auto_doc=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xreg._AutoMovimiento)
                                xcmd.Parameters.AddWithValue("@total", xtotalpend)
                                xcmd.ExecuteNonQuery()

                                For Each xrg In xtb_balanza.Rows
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='1', estatus='P', usuario=@usuario, auto_operador=@operador, " & _
                                    "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='1' and estatus='B'"
                                    xcmd.Parameters.AddWithValue("@usuario", xcta._FichaUsuario._NombreUsuario).Size = 20
                                    xcmd.Parameters.AddWithValue("@operador", xcta._Operador._AutoOperador).Size = 10
                                    xcmd.Parameters.AddWithValue("@jornada", xcta._Jornada._AutoJornada).Size = 10
                                    xcmd.Parameters.AddWithValue("@estacion", xcta._EquipoEstacion).Size = 20
                                    xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                    End If
                                Next

                            End Using
                            xtr.Commit()
                            RaiseEvent _CtaPendienteOK()
                            RaiseEvent _VisorLimpiar()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL DEJAR CUENTA PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AbrirCuentaPendiente(ByVal xctaabrir As AbrirCtaPendiente) As Boolean
                Try
                    Dim xtb As New DataTable
                    Dim xtb_balanza As New DataTable
                    Dim xrd As SqlDataReader
                    Dim xpdt As PendienteDetalle.c_Registro
                    Dim xitem As PosVenta.c_Registro

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from pos_venta_pendDetalle where autodoc_encabezado=@auto_doc"
                                xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._FichaAbrir._AutoMovimiento)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("PROBLEMA AL CARGAR CUENTA PENDIENTE, AL PARECER YA FUE PROCESADA")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select etiq_auto as auto from pos_venta_pendDetalle where autodoc_encabezado=@auto_doc and etiq_auto<>'' group by etiq_auto"
                                xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._FichaAbrir._AutoMovimiento)
                                xrd = xcmd.ExecuteReader()
                                xtb_balanza.Load(xrd)
                                xrd.Close()

                                For Each xrow As DataRow In xtb.Rows
                                    xpdt = New PendienteDetalle.c_Registro
                                    xitem = New PosVenta.c_Registro
                                    xpdt.CargarRegistro(xrow)

                                    With xitem
                                        .c_AutoJornada._ContenidoCampo = xctaabrir._Jornada._AutoJornada
                                        .c_AutoOperador._ContenidoCampo = xctaabrir._Operador._AutoOperador
                                        .c_AutoUsuario._ContenidoCampo = xctaabrir._FichaUsuario._AutoUsuario
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xrow(.c_AutoEmpaqueMedida._NombreCampo)
                                        .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                        .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                        .c_CodigoBarraLeido._ContenidoCampo = xrow(.c_CodigoBarraLeido._NombreCampo)
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xrow(.c_ContenidoEmpaqueMedida._NombreCampo)
                                        .c_EnOferta._ContenidoCampo = xrow(.c_EnOferta._NombreCampo)
                                        .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                        .c_EsPesado._ContenidoCampo = xrow(.c_EsPesado._NombreCampo)
                                        .c_EtiquetaAuto._ContenidoCampo = xrow(.c_EtiquetaAuto._NombreCampo)
                                        .c_EtiquetaBalanza._ContenidoCampo = xrow(.c_EtiquetaBalanza._NombreCampo)
                                        .c_EtiquetaControl._ContenidoCampo = xrow(.c_EtiquetaControl._NombreCampo)
                                        .c_EtiquetaDepartamento._ContenidoCampo = xrow(.c_EtiquetaDepartamento._NombreCampo)
                                        .c_EtiquetaDigitos._ContenidoCampo = xrow(.c_EtiquetaDigitos._NombreCampo)
                                        .c_EtiquetaFormato._ContenidoCampo = xrow(.c_EtiquetaFormato._NombreCampo)
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xrow(.c_EtiquetaImporteMonto._NombreCampo)
                                        .c_EtiquetaItem._ContenidoCampo = xrow(.c_EtiquetaItem._NombreCampo)
                                        .c_EtiquetaPeso._ContenidoCampo = xrow(.c_EtiquetaPeso._NombreCampo)
                                        .c_EtiquetaPlu._ContenidoCampo = xrow(.c_EtiquetaPlu._NombreCampo)
                                        .c_EtiquetaPrecio._ContenidoCampo = xrow(.c_EtiquetaPrecio._NombreCampo)
                                        .c_EtiquetaSeccion._ContenidoCampo = xrow(.c_EtiquetaSeccion._NombreCampo)
                                        .c_EtiquetaTicket._ContenidoCampo = xrow(.c_EtiquetaTicket._NombreCampo)
                                        .c_EtiquetaVendedor._ContenidoCampo = xrow(.c_EtiquetaVendedor._NombreCampo)
                                        .c_NombreCorto._ContenidoCampo = xrow(.c_NombreCorto._NombreCampo)
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xrow(.c_NombreEmpaqueMedida._NombreCampo)
                                        .c_PLU._ContenidoCampo = xrow(.c_PLU._NombreCampo)
                                        .c_PrecioRegular._ContenidoCampo = xrow(.c_PrecioRegular._NombreCampo)
                                        .c_PrecioSugerido._ContenidoCampo = xrow(.c_PrecioSugerido._NombreCampo)
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xrow(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = xrow(.c_ReferenciaPrecioMayor._NombreCampo)
                                        .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                        .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)
                                        .c_IdEquipo._ContenidoCampo = xctaabrir._IdEquipo
                                        .c_TipoItem._ContenidoCampo = xrow(.c_TipoItem._NombreCampo)
                                        .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_posventa_item from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_posventa_item=0"
                                        xcmd.ExecuteNonQuery()
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                    xitem.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PosVenta.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoEmpaqueMedida._NombreCampo, xitem._AutoEmpaqueMedida).Size = xitem.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoItem._NombreCampo, xitem._AutoItem).Size = xitem.c_AutoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoJornada._NombreCampo, xitem._AutoJornada).Size = xitem.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoOperador._NombreCampo, xitem._AutoOperador).Size = xitem.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoProducto._NombreCampo, xitem._AutoProducto).Size = xitem.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_Cantidad._NombreCampo, xitem._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_CodigoBarraLeido._NombreCampo, xitem._CodigoBarraLeido).Size = xitem.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_ContenidoEmpaqueMedida._NombreCampo, xitem._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EnOferta._NombreCampo, xitem.c_EnOferta._ContenidoCampo).Size = xitem.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EsPesado._NombreCampo, xitem.c_EsPesado._ContenidoCampo).Size = xitem.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaAuto._NombreCampo, xitem._EtiquetaAuto).Size = xitem.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaBalanza._NombreCampo, xitem._EtiquetaBalanza).Size = xitem.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaControl._NombreCampo, xitem._EtiquetaControl).Size = xitem.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaDepartamento._NombreCampo, xitem._EtiquetaDepartamento).Size = xitem.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaDigitos._NombreCampo, xitem._EtiquetaDigitos).Size = xitem.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaFormato._NombreCampo, xitem._EtiquetaFormato).Size = xitem.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaImporteMonto._NombreCampo, xitem._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaItem._NombreCampo, xitem._EtiquetaItem).Size = xitem.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaPeso._NombreCampo, xitem._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaPlu._NombreCampo, xitem._EtiquetaPlu).Size = xitem.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaPrecio._NombreCampo, xitem._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaSeccion._NombreCampo, xitem._EtiquetaSeccion).Size = xitem.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaTicket._NombreCampo, xitem._EtiquetaTicket).Size = xitem.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_EtiquetaVendedor._NombreCampo, xitem._EtiquetaVendedor).Size = xitem.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_NombreCorto._NombreCampo, xitem._NombreCorto).Size = xitem.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_NombreEmpaqueMedida._NombreCampo, xitem._NombreEmpaqueMedida).Size = xitem.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_PLU._NombreCampo, xitem._PLU).Size = xitem.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_PrecioNeto._NombreCampo, xitem._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_PrecioRegular._NombreCampo, xitem._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_PrecioSugerido._NombreCampo, xitem._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_ReferenciaEmpaqueMedida._NombreCampo, xitem._ReferenciaEmpaqueMedida).Size = xitem.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_ReferenciaPrecioMayor._NombreCampo, xitem._ReferenciaPrecioMayor).Size = xitem.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_TasaIva._NombreCampo, xitem._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_TipoTasaIva._NombreCampo, xitem.c_TipoTasaIva._ContenidoCampo).Size = xitem.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_IdEquipo._NombreCampo, xitem.c_IdEquipo._ContenidoCampo).Size = xitem.c_IdEquipo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_AutoUsuario._NombreCampo, xitem.c_AutoUsuario._ContenidoCampo).Size = xitem.c_AutoUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_TipoItem._NombreCampo, xitem.c_TipoItem._ContenidoCampo).Size = xitem.c_TipoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xitem.c_NotasItem._NombreCampo, xitem.c_NotasItem._ContenidoCampo).Size = xitem.c_NotasItem._LargoCampo
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL REGISTRAR ITEM PENDIENTE A VENTA")
                                    End If
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from pos_venta_penddetalle where autodoc_encabezado=@auto_doc"
                                xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._FichaAbrir._AutoMovimiento)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL ELIMINAR ITEMS PENDIENTES")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from pos_venta_pendencabezado where auto_doc=@auto_doc"
                                xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._FichaAbrir._AutoMovimiento)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL ABRIR CUENTA PENDIENTE, AL PARECER YA FUE PROCESADA")
                                End If

                                For Each xrg In xtb_balanza.Rows
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='1', estatus='B', usuario=@usuario, auto_operador=@operador, " & _
                                    "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='1' and estatus='P'"
                                    xcmd.Parameters.AddWithValue("@usuario", xctaabrir._FichaUsuario._NombreUsuario).Size = 20
                                    xcmd.Parameters.AddWithValue("@operador", xctaabrir._Operador._AutoOperador).Size = 10
                                    xcmd.Parameters.AddWithValue("@jornada", xctaabrir._Jornada._AutoJornada).Size = 10
                                    xcmd.Parameters.AddWithValue("@estacion", xctaabrir._EquipoEstacion).Size = 20
                                    xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                    End If
                                Next

                            End Using
                            xtr.Commit()
                            RaiseEvent _AbrirCtaPendienteOK(xctaabrir._FichaAbrir._NombrePendiente, xctaabrir._FichaAbrir._AutoCliente)
                            RaiseEvent _VisorSubTotalPendiente()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ABRIR CUENTA PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_Devolucion(ByVal xficha As AgregarDevolucion) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xitemventa As PosVenta.c_Registro
                    Dim xdevolucion As New DevolucionAnulacion.c_Registro

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@autoprd", xficha._FichaProducto._AutoProducto)
                                xcmd.Parameters.AddWithValue("@autojornada", xficha._Jornada._AutoJornada)
                                xcmd.Parameters.AddWithValue("@autooperador", xficha._Operador._AutoOperador)
                                xcmd.Parameters.AddWithValue("@autousuario", xficha._FichaUsuario._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xficha._IdEquipo)

                                xcmd.CommandText = "select top(1) * from POS_Venta where Prd_Automatico=@autoprd and prd_tipo='1' " & _
                                "and AutoJornada=@autojornada and AutoOperador=@autooperador and AutoUsuario=@autousuario and id_equipo=@id"
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("PRODUCTO NO ENCONTRADO / FACTURADO ")
                                End If

                                xitemventa = New PosVenta.c_Registro
                                xitemventa.CargarRegistro(xtb.Rows(0))
                                Dim xr As DataRow = xtb.Rows(0)

                                With xdevolucion
                                    .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                    .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                    .c_Cantidad._ContenidoCampo = 1
                                    .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                    .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                    .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                    .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                    .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                    .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                    .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                    .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                    .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                    .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                    .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                    .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                    .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                    .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                    .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                    .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                    .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                    .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                    .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                    .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                    .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                    .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                    .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                    .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                    .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                    .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                    .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                    .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                    .c_AutoDevAnu._ContenidoCampo = xficha._AutoDevAnu
                                    .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                    .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                    .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                    .c_Fecha._ContenidoCampo = xficha._Fecha
                                    .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                    Select Case xficha._NivelCave
                                        Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                        Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                        Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                        Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                    End Select
                                    .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                    .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                    .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = DevolucionAnulacion.INSERT
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL REGISTRAR DEVOLUCION")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "UPDATE POS_VENTA SET prd_CANTIDAD=prd_CANTIDAD-1 where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xitemventa._AutoItem)
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PROBLEMA AL ACTUALIZAR ITEM EN DEVOLUCION")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete POS_VENTA where autoitem=@autoitem and prd_cantidad=0"
                                xcmd.Parameters.AddWithValue("@autoitem", xitemventa._AutoItem)
                                xcmd.ExecuteNonQuery()

                            End Using
                            xtr.Commit()
                            RaiseEvent _DevolucionOK()
                            RaiseEvent _VisorDevolucion(xdevolucion._NombreCorto, xdevolucion._Cantidad, xdevolucion._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR DEVOLUCION" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_Anulacion(ByVal xficha As AgregarAnulacion) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xtb_balanza As New DataTable
                    Dim xitemventa As PosVenta.c_Registro
                    Dim xanulacion As String

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@autojornada", xficha._Jornada._AutoJornada)
                                xcmd.Parameters.AddWithValue("@autooperador", xficha._Operador._AutoOperador)
                                xcmd.Parameters.AddWithValue("@autousuario", xficha._FichaUsuario._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xficha._IdEquipo)

                                xcmd.CommandText = "select * from POS_Venta where AutoJornada=@autojornada and AutoOperador=@autooperador " & _
                                "and AutoUsuario=@autousuario and id_equipo=@id"
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("PRODUCTOS NO ENCONTRADO / FACTURADO")
                                End If

                                xcmd.CommandText = "select etiq_auto as auto from POS_Venta where AutoJornada=@autojornada and AutoOperador=@autooperador " & _
                                "and AutoUsuario=@autousuario and id_equipo=@id and etiq_auto<>'' group by etiq_auto"
                                xrd = xcmd.ExecuteReader()
                                xtb_balanza.Load(xrd)
                                xrd.Close()

                                xanulacion = ""
                                xcmd.CommandText = "select a_posventa_anulacion from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_posventa_anulacion=0"
                                    xcmd.ExecuteScalar()
                                End If
                                xcmd.CommandText = "update contadores set a_posventa_anulacion=a_posventa_anulacion+1; " _
                                    + "select a_posventa_anulacion from contadores"
                                xanulacion = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                For Each xr As DataRow In xtb.Rows
                                    xitemventa = New PosVenta.c_Registro
                                    xitemventa.CargarRegistro(xr)

                                    Dim xdevolucion As New DevolucionAnulacion.c_Registro
                                    With xdevolucion
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                        .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                        .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                        .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                        .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                        .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                        .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                        .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                        .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                        .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                        .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                        .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                        .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                        .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                        .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                        .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                        .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                        .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                        .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                        .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                        .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                        .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                        .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                        .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                        .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                        .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                        .c_AutoDevAnu._ContenidoCampo = xanulacion
                                        .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                        .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                        .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                        .c_Fecha._ContenidoCampo = xficha._Fecha
                                        .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                        Select Case xficha._NivelCave
                                            Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                            Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                            Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                            Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                        End Select
                                        .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                        .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                        .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = DevolucionAnulacion.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL REGISTRAR ANULACION")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete POS_VENTA where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xitemventa._AutoItem)
                                    If xcmd.ExecuteNonQuery = 0 Then
                                        Throw New Exception("PROBLEMA AL ANULAR ITEM EN VENTA")
                                    End If
                                Next

                                For Each xrg In xtb_balanza.Rows
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='0', estatus='0', usuario='', auto_operador='', " & _
                                    "auto_jornada='', serial='', estacion='' where auto=@autoitem and enuso='1' and estatus='B'"
                                    xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET BALANZA: TICKET NO ENCONTRADO / OTRO USUARIO YA LO ACTUALIZO")
                                    End If
                                Next
                            End Using
                            xtr.Commit()
                            RaiseEvent _AnulacionOK()
                            RaiseEvent _VisorLimpiar()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR ANULACION PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AnulacionPendiente(ByVal xficha As AgregarAnulacionPendiente) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xtb_balanza As New DataTable
                    Dim xitemventa As PendienteDetalle.c_Registro
                    Dim xanulacion As String

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto", xficha._EncabezadoPendiente._AutoMovimiento)
                                xcmd.CommandText = "select * from POS_Venta_penddetalle where autodoc_encabezado=@auto"
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("ITEMS DE LA CUENTA PENDIENTE NO ENCONTRADO")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto", xficha._EncabezadoPendiente._AutoMovimiento)
                                xcmd.CommandText = "select etiq_auto as auto from POS_Venta_penddetalle where autodoc_encabezado=@auto and etiq_auto<>'' group by etiq_auto"
                                xrd = xcmd.ExecuteReader()
                                xtb_balanza.Load(xrd)
                                xrd.Close()

                                xanulacion = ""
                                xcmd.CommandText = "select a_posventa_anulacion from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_posventa_anulacion=0"
                                    xcmd.ExecuteScalar()
                                End If
                                xcmd.CommandText = "update contadores set a_posventa_anulacion=a_posventa_anulacion+1; " _
                                    + "select a_posventa_anulacion from contadores"
                                xanulacion = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                For Each xr As DataRow In xtb.Rows
                                    xitemventa = New PendienteDetalle.c_Registro
                                    xitemventa.CargarRegistro(xr)

                                    Dim xdevolucion As New DevolucionAnulacion.c_Registro
                                    With xdevolucion
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                        .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                        .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                        .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                        .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                        .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                        .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                        .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                        .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                        .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                        .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                        .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                        .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                        .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                        .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                        .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                        .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                        .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                        .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                        .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                        .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                        .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                        .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                        .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                        .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                        .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                        .c_AutoDevAnu._ContenidoCampo = xanulacion
                                        .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                        .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                        .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                        .c_Fecha._ContenidoCampo = xficha._Fecha
                                        .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                        Select Case xficha._NivelCave
                                            Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                            Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                            Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                            Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                        End Select
                                        .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                        .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                        .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = DevolucionAnulacion.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL REGISTRAR ANULACION")
                                    End If
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete POS_VENTA_PENDDETALLE where autodoc_encabezado=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xficha._EncabezadoPendiente._AutoMovimiento)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete POS_VENTA_PENDENCABEZADO where auto_doc=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xficha._EncabezadoPendiente._AutoMovimiento)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL ANULAR CUENTA PENDIENTE / NO ENCONTRADA")
                                End If

                                For Each xrg In xtb_balanza.Rows
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='0', estatus='0', usuario=@usuario, auto_operador=@operador, " & _
                                    "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='1' and estatus='P'"
                                    xcmd.Parameters.AddWithValue("@usuario", xficha._FichaUsuario._NombreUsuario).Size = 20
                                    xcmd.Parameters.AddWithValue("@operador", xficha._Operador._AutoOperador).Size = 10
                                    xcmd.Parameters.AddWithValue("@jornada", xficha._Jornada._AutoJornada).Size = 10
                                    xcmd.Parameters.AddWithValue("@estacion", xficha._EquipoEstacion).Size = 20
                                    xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                    End If
                                Next

                            End Using
                            xtr.Commit()
                            RaiseEvent _AnulacionOK()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR ANULACION PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AnulacionPendienteTodas(ByVal xficha As AgregarAnulacionPendienteTodas) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xtb_balanza As New DataTable
                    Dim xitemventa As PendienteDetalle.c_Registro
                    Dim xanulacion As String

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xlista As New DataTable
                                xcmd.Parameters.Clear()
                                If xficha._Alcance = AgregarAnulacionPendienteTodas.TipoAlcanze.Todas Then
                                    xcmd.CommandText = "select * from POS_Venta_pendencabezado where nombre_pendiente<>''"
                                Else
                                    xcmd.CommandText = "select * from POS_Venta_pendencabezado where nombre_pendiente<>'' and auto_operador=@operador and auto_jornada=@jornada"
                                    xcmd.Parameters.AddWithValue("@operador", xficha._Operador._AutoOperador)
                                    xcmd.Parameters.AddWithValue("@jornada", xficha._Operador._AutoJornada)
                                End If
                                xrd = xcmd.ExecuteReader()
                                xlista.Load(xrd)
                                xrd.Close()

                                Dim xauto As String = ""
                                For Each xr_lista As DataRow In xlista.Rows
                                    xauto = xr_lista("auto_doc").ToString.Trim

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.CommandText = "select * from POS_Venta_penddetalle where autodoc_encabezado=@auto"
                                    xrd = xcmd.ExecuteReader()
                                    xtb.Load(xrd)
                                    xrd.Close()

                                    If xtb.Rows.Count = 0 Then
                                        Throw New Exception("ITEMS DE LA CUENTA PENDIENTE NO ENCONTRADO")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.CommandText = "select etiq_auto as auto from POS_Venta_penddetalle where autodoc_encabezado=@auto and etiq_auto<>'' group by etiq_auto"
                                    xrd = xcmd.ExecuteReader()
                                    xtb_balanza.Load(xrd)
                                    xrd.Close()

                                    xanulacion = ""
                                    xcmd.CommandText = "select a_posventa_anulacion from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_posventa_anulacion=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_posventa_anulacion=a_posventa_anulacion+1; " _
                                        + "select a_posventa_anulacion from contadores"
                                    xanulacion = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    For Each xr As DataRow In xtb.Rows
                                        xitemventa = New PendienteDetalle.c_Registro
                                        xitemventa.CargarRegistro(xr)

                                        Dim xdevolucion As New DevolucionAnulacion.c_Registro
                                        With xdevolucion
                                            .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                            .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                            .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                            .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                            .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                            .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                            .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                            .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                            .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                            .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                            .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                            .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                            .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                            .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                            .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                            .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                            .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                            .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                            .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                            .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                            .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                            .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                            .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                            .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                            .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                            .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                            .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                            .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                            .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                            .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                            .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                            .c_AutoDevAnu._ContenidoCampo = xanulacion
                                            .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                            .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                            .c_Fecha._ContenidoCampo = xficha._Fecha
                                            .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                            Select Case xficha._NivelCave
                                                Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                                Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                                Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                                Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                            End Select
                                            .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                            .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                            .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = DevolucionAnulacion.INSERT
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                        If xcmd.ExecuteNonQuery() = 0 Then
                                            Throw New Exception("PROBLEMA AL REGISTRAR ANULACION")
                                        End If
                                    Next

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete POS_VENTA_PENDDETALLE where autodoc_encabezado=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete POS_VENTA_PENDENCABEZADO where auto_doc=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ANULAR CUENTA PENDIENTE / NO ENCONTRADA")
                                    End If

                                    For Each xrg In xtb_balanza.Rows
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update balanzaeuro_encabezado set enuso='0', estatus='0', usuario=@usuario, auto_operador=@operador, " & _
                                        "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='1' and estatus='P'"
                                        xcmd.Parameters.AddWithValue("@usuario", xficha._FichaUsuario._NombreUsuario).Size = 20
                                        xcmd.Parameters.AddWithValue("@operador", xficha._Operador._AutoOperador).Size = 10
                                        xcmd.Parameters.AddWithValue("@jornada", xficha._Jornada._AutoJornada).Size = 10
                                        xcmd.Parameters.AddWithValue("@estacion", xficha._EquipoEstacion).Size = 20
                                        xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                        If xcmd.ExecuteNonQuery() = 0 Then
                                            Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                        End If
                                    Next
                                Next

                            End Using
                            xtr.Commit()
                            RaiseEvent _AnulacionOK()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR ANULACION PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function


            Function F_DevolucionItem(ByVal xficha As AgregarDevolucionItem) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xitemventa As PosVenta.c_Registro
                    Dim xdevolucion As New DevolucionAnulacion.c_Registro
                    Dim xcnt As Integer = 0

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._FichaItem._AutoItem)
                                xcmd.CommandText = "select  * from POS_Venta where autoitem=@autoitem"
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("ITEM NO ENCONTRADO / FACTURADO ")
                                End If

                                If xtb(0)("etiq_auto").ToString.Trim <> "" Then
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xtb(0)("etiq_auto").ToString.Trim)
                                    xcmd.CommandText = "select count(*) as cnt from POS_Venta where etiq_auto=@auto"
                                    xcnt = xcmd.ExecuteScalar
                                End If

                                xitemventa = New PosVenta.c_Registro
                                xitemventa.CargarRegistro(xtb.Rows(0))
                                Dim xr As DataRow = xtb.Rows(0)

                                With xdevolucion
                                    .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                    .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                    .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                    .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                    .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                    .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                    .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                    .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                    .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                    .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                    .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                    .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                    .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                    .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                    .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                    .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                    .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                    .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                    .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                    .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                    .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                    .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                    .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                    .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                    .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                    .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                    .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                    .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                    .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                    .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                    .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                    .c_AutoDevAnu._ContenidoCampo = xficha._AutoDevAnu
                                    .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                    .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                    .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                    .c_Fecha._ContenidoCampo = xficha._Fecha
                                    .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                    Select Case xficha._NivelCave
                                        Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                        Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                        Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                        Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                    End Select
                                    .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                    .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                    .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = DevolucionAnulacion.INSERT
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL REGISTRAR DEVOLUCION")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete POS_VENTA where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._FichaItem._AutoItem)
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PROBLEMA AL ACTUALIZAR ITEM EN DEVOLUCION")
                                End If

                                If xcnt = 1 Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='0', estatus='0', usuario='', auto_operador='', " & _
                                    "auto_jornada='', serial='', estacion='' where auto=@autoitem and enuso='1' and estatus='B'"
                                    xcmd.Parameters.AddWithValue("@autoitem", xdevolucion._EtiquetaAuto)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET BALANZA: TICKET NO ENCONTRADO / OTRO USUARIO YA LO ACTUALIZO")
                                    End If
                                End If

                            End Using
                            xtr.Commit()
                            RaiseEvent _VisorDevolucionCantidad(xdevolucion._NombreCorto, xdevolucion._Cantidad, xdevolucion._PrecioVenta._Full)
                            RaiseEvent _DevolucionOK()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR DEVOLUCION ITEM" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_TarjetaPendiente(ByVal xcta As AgregarTarjetaPendiente) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xreg As New PendienteEncabezado.c_Registro
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xdf As New StringBuilder(1000)
                    Dim xtb_balanza As New DataTable


                    With xreg
                        .c_AutoCliente._ContenidoCampo = xcta._Cliente.r_Automatico
                        .c_AutoJornada._ContenidoCampo = xcta._Jornada._AutoJornada
                        .c_AutoMovimiento._ContenidoCampo = ""
                        .c_AutoOperador._ContenidoCampo = xcta._Operador._AutoOperador
                        .c_AutoUsuario._ContenidoCampo = xcta._FichaUsuario._AutoUsuario
                        .c_EquipoEstacion._ContenidoCampo = xcta._EquipoEstacion
                        .c_Fecha._ContenidoCampo = xcta._Fecha
                        .c_Hora._ContenidoCampo = xcta._Hora
                        .c_Items._ContenidoCampo = 0
                        .c_MontoTotal._ContenidoCampo = 0
                        .c_NombrePendiente._ContenidoCampo = ""
                        .c_NombreUsuario._ContenidoCampo = xcta._FichaUsuario._NombreUsuario
                        .c_IdEquipo._ContenidoCampo = xcta._IdEquipo
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = "select a_posventa_pendiente from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_posventa_pendiente=0"
                                    xcmd.ExecuteScalar()
                                End If
                                xcmd.CommandText = "update contadores set a_posventa_pendiente=a_posventa_pendiente+1; " _
                                    + "select a_posventa_pendiente from contadores"
                                xreg.c_AutoMovimiento._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from pos_venta where autojornada=@jornada and autooperador=@operador " & _
                                "and autousuario=@usuario and id_equipo=@id"
                                xcmd.Parameters.AddWithValue("@jornada", xreg._AutoJornada)
                                xcmd.Parameters.AddWithValue("@operador", xreg._AutoOperador)
                                xcmd.Parameters.AddWithValue("@usuario", xreg._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xcta._IdEquipo)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("PROBLEMA AL DEJAR ITEMS PENDIENTES, AL PARECER YA FUERON PROCESADOS")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select etiq_auto as auto from POS_Venta where AutoJornada=@jornada and AutoOperador=@operador " & _
                                "and AutoUsuario=@usuario and id_equipo=@id and etiq_auto<>'' group by etiq_auto"
                                xcmd.Parameters.AddWithValue("@jornada", xreg._AutoJornada)
                                xcmd.Parameters.AddWithValue("@operador", xreg._AutoOperador)
                                xcmd.Parameters.AddWithValue("@usuario", xreg._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@id", xcta._IdEquipo)
                                xrd = xcmd.ExecuteReader()
                                xtb_balanza.Load(xrd)
                                xrd.Close()

                                xreg.c_Items._ContenidoCampo = xtb.Rows.Count
                                xreg.c_MontoTotal._ContenidoCampo = (From x In xtb.AsEnumerable Select x.Field(Of Decimal)("prd_importe")).Sum

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = PosOnline.PendienteEncabezado.INSERT_PENDIENTE_ENCABEZADO
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
                                    .AddWithValue("@" + xreg.c_IdEquipo._NombreCampo, xreg._IdEquipo).Size = xreg.c_IdEquipo._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()

                                Dim xtotalpend As Decimal = 0
                                For Each xr As DataRow In xtb.Rows
                                    Dim xdetpend As New PendienteDetalle.c_Registro
                                    With xdetpend
                                        .c_AutoDocEncabezado._ContenidoCampo = xreg._AutoMovimiento
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                        .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                        .c_Cantidad._ContenidoCampo = xr(.c_Cantidad._NombreCampo)
                                        .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                        .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                        .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                        .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                        .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                        .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                        .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                        .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                        .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                        .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                        .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                        .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                        .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                        .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                        .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                        .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                        .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                        .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                        .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                        .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                        .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                        .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                        .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                        .c_TipoItem._ContenidoCampo = xr(.c_TipoItem._NombreCampo)
                                        .c_NotasItem._ContenidoCampo = xr(.c_NotasItem._NombreCampo)
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PendienteDetalle.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoDocEncabezado._NombreCampo, xdetpend._AutoDocEncabezado).Size = xdetpend.c_AutoDocEncabezado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoEmpaqueMedida._NombreCampo, xdetpend._AutoEmpaqueMedida).Size = xdetpend.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_AutoProducto._NombreCampo, xdetpend._AutoProducto).Size = xdetpend.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_Cantidad._NombreCampo, xdetpend._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_CodigoBarraLeido._NombreCampo, xdetpend._CodigoBarraLeido).Size = xdetpend.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ContenidoEmpaqueMedida._NombreCampo, xdetpend._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EnOferta._NombreCampo, xdetpend.c_EnOferta._ContenidoCampo).Size = xdetpend.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EsPesado._NombreCampo, xdetpend.c_EsPesado._ContenidoCampo).Size = xdetpend.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaAuto._NombreCampo, xdetpend._EtiquetaAuto).Size = xdetpend.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaBalanza._NombreCampo, xdetpend._EtiquetaBalanza).Size = xdetpend.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaControl._NombreCampo, xdetpend._EtiquetaControl).Size = xdetpend.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaDepartamento._NombreCampo, xdetpend._EtiquetaDepartamento).Size = xdetpend.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaDigitos._NombreCampo, xdetpend._EtiquetaDigitos).Size = xdetpend.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaFormato._NombreCampo, xdetpend._EtiquetaFormato).Size = xdetpend.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaImporteMonto._NombreCampo, xdetpend._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaItem._NombreCampo, xdetpend._EtiquetaItem).Size = xdetpend.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPeso._NombreCampo, xdetpend._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPlu._NombreCampo, xdetpend._EtiquetaPlu).Size = xdetpend.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaPrecio._NombreCampo, xdetpend._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaSeccion._NombreCampo, xdetpend._EtiquetaSeccion).Size = xdetpend.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaTicket._NombreCampo, xdetpend._EtiquetaTicket).Size = xdetpend.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_EtiquetaVendedor._NombreCampo, xdetpend._EtiquetaVendedor).Size = xdetpend.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NombreCorto._NombreCampo, xdetpend._NombreCorto).Size = xdetpend.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NombreEmpaqueMedida._NombreCampo, xdetpend._NombreEmpaqueMedida).Size = xdetpend.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PLU._NombreCampo, xdetpend._PLU).Size = xdetpend.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioNeto._NombreCampo, xdetpend._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioRegular._NombreCampo, xdetpend._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_PrecioSugerido._NombreCampo, xdetpend._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ReferenciaEmpaqueMedida._NombreCampo, xdetpend._ReferenciaEmpaqueMedida).Size = xdetpend.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_ReferenciaPrecioMayor._NombreCampo, xdetpend._ReferenciaPrecioMayor).Size = xdetpend.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TasaIva._NombreCampo, xdetpend._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TipoTasaIva._NombreCampo, xdetpend.c_TipoTasaIva._ContenidoCampo).Size = xdetpend.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_TipoItem._NombreCampo, xdetpend.c_TipoItem._ContenidoCampo).Size = xdetpend.c_TipoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdetpend.c_NotasItem._NombreCampo, xdetpend.c_NotasItem._ContenidoCampo).Size = xdetpend.c_NotasItem._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                    xtotalpend += xdetpend._TotalItem

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from pos_venta where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xr("autoitem").ToString)
                                    If xcmd.ExecuteNonQuery = 0 Then
                                        Throw New Exception("PROBLEMA AL DEJAR ITEM PENDIENTE, AL PARECER YA FUE PROCESADO")
                                    End If
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta_pendencabezado set monto_doc=@total where auto_doc=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xreg._AutoMovimiento)
                                xcmd.Parameters.AddWithValue("@total", xtotalpend)
                                xcmd.ExecuteNonQuery()

                                For Each xrg In xtb_balanza.Rows
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update balanzaeuro_encabezado set enuso='1', estatus='P', usuario=@usuario, auto_operador=@operador, " & _
                                    "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='1' and estatus='B'"
                                    xcmd.Parameters.AddWithValue("@usuario", xcta._FichaUsuario._NombreUsuario).Size = 20
                                    xcmd.Parameters.AddWithValue("@operador", xcta._Operador._AutoOperador).Size = 10
                                    xcmd.Parameters.AddWithValue("@jornada", xcta._Jornada._AutoJornada).Size = 10
                                    xcmd.Parameters.AddWithValue("@estacion", xcta._EquipoEstacion).Size = 20
                                    xcmd.Parameters.AddWithValue("@autoitem", xrg("auto").ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                    End If
                                Next


                                Dim xt As String = ""
                                Dim xfecha As Date = Date.Today
                                Dim xb As String = ""
                                Dim XANCHO As Integer = 40
                                'If xcta._Impresora IsNot Nothing Then
                                '    XANCHO = xcta._Impresora.AnchoTextoNoFiscal
                                'End If

                                xt = "No Cuenta : " + xreg._AutoMovimiento
                                xt = xt.Trim.PadRight(XANCHO, " ")
                                xdf.Append(xt)

                                xt = "De Fecha  : " + xreg._Fecha.ToShortDateString()
                                xt = xt.Trim.PadRight(XANCHO, " ")
                                xdf.Append(xt)

                                xt = "Usuario   : " + xreg._NombreUsuario
                                xt = xt.Trim.PadRight(XANCHO, " ")
                                xdf.Append(xt)

                                xt = "Estacion  : " + xreg._EquipoEstacion
                                xt = xt.Trim.PadRight(XANCHO, " ")
                                xdf.Append(xt)

                                xt = Space(XANCHO)
                                xdf.Append(xt)

                                If xreg._AutoCliente <> "" Then
                                    xt = "Datos Del Cliente:"
                                    xt = xt.Trim.PadRight(XANCHO, " ")
                                    xdf.Append(xt)

                                    xt = xcta._Cliente.r_CiRif
                                    xt = xt.Trim.PadRight(XANCHO, " ")
                                    xdf.Append(xt)

                                    xt = xcta._Cliente.r_NombreRazonSocial
                                    xt = xt.Trim.PadRight(XANCHO, " ")
                                    xdf.Append(xt)
                                End If
                                xb = String.Format("{0:0.00}", xcta._TotalCta)
                                xt = "Total Monto: " + xb
                                xt = xt.Trim.PadRight(XANCHO, " ")
                                xdf.Append(xt)

                                If xcta._Impresora IsNot Nothing Then
                                    xcta._Impresora.CodigoBarra(xreg._AutoMovimiento)
                                    xcta._Impresora.TextoDNF(xdf.ToString)
                                Else
                                    For i = 1 To 8
                                        xt = Space(XANCHO)
                                        xdf.Append(xt)
                                    Next
                                    xt = "-"
                                    xdf.Append(xt)
                                End If

                            End Using
                            xtr.Commit()
                            RaiseEvent _CtaPendienteOK()
                            RaiseEvent _TarjetaPendiente(xdf)
                            RaiseEvent _VisorLimpiar()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL DEJAR TARJETA PENDIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_DevolucionCantidadItem(ByVal xficha As AgregarDevolucionCantidadItem) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xtb As New DataTable
                    Dim xitemventa As PosVenta.c_Registro
                    Dim xdevolucion As New DevolucionAnulacion.c_Registro

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._FichaItem._AutoItem)
                                xcmd.CommandText = "select  * from POS_Venta where autoitem=@autoitem"
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("ITEM NO ENCONTRADO / FACTURADO ")
                                End If

                                xitemventa = New PosVenta.c_Registro
                                xitemventa.CargarRegistro(xtb.Rows(0))
                                Dim xr As DataRow = xtb.Rows(0)

                                With xdevolucion
                                    .c_AutoEmpaqueMedida._ContenidoCampo = xr(.c_AutoEmpaqueMedida._NombreCampo)
                                    .c_AutoProducto._ContenidoCampo = xr(.c_AutoProducto._NombreCampo)
                                    .c_Cantidad._ContenidoCampo = xficha._CantidadDevolver
                                    .c_CodigoBarraLeido._ContenidoCampo = xr(.c_CodigoBarraLeido._NombreCampo)
                                    .c_ContenidoEmpaqueMedida._ContenidoCampo = xr(.c_ContenidoEmpaqueMedida._NombreCampo)
                                    .c_EnOferta._ContenidoCampo = xr(.c_EnOferta._NombreCampo)
                                    .c_PrecioNeto._ContenidoCampo = xr(.c_PrecioNeto._NombreCampo)
                                    .c_EsPesado._ContenidoCampo = xr(.c_EsPesado._NombreCampo)
                                    .c_EtiquetaAuto._ContenidoCampo = xr(.c_EtiquetaAuto._NombreCampo)
                                    .c_EtiquetaBalanza._ContenidoCampo = xr(.c_EtiquetaBalanza._NombreCampo)
                                    .c_EtiquetaControl._ContenidoCampo = xr(.c_EtiquetaControl._NombreCampo)
                                    .c_EtiquetaDepartamento._ContenidoCampo = xr(.c_EtiquetaDepartamento._NombreCampo)
                                    .c_EtiquetaDigitos._ContenidoCampo = xr(.c_EtiquetaDigitos._NombreCampo)
                                    .c_EtiquetaFormato._ContenidoCampo = xr(.c_EtiquetaFormato._NombreCampo)
                                    .c_EtiquetaImporteMonto._ContenidoCampo = xr(.c_EtiquetaImporteMonto._NombreCampo)
                                    .c_EtiquetaItem._ContenidoCampo = xr(.c_EtiquetaItem._NombreCampo)
                                    .c_EtiquetaPeso._ContenidoCampo = xr(.c_EtiquetaPeso._NombreCampo)
                                    .c_EtiquetaPlu._ContenidoCampo = xr(.c_EtiquetaPlu._NombreCampo)
                                    .c_EtiquetaPrecio._ContenidoCampo = xr(.c_EtiquetaPrecio._NombreCampo)
                                    .c_EtiquetaSeccion._ContenidoCampo = xr(.c_EtiquetaSeccion._NombreCampo)
                                    .c_EtiquetaTicket._ContenidoCampo = xr(.c_EtiquetaTicket._NombreCampo)
                                    .c_EtiquetaVendedor._ContenidoCampo = xr(.c_EtiquetaVendedor._NombreCampo)
                                    .c_NombreCorto._ContenidoCampo = xr(.c_NombreCorto._NombreCampo)
                                    .c_NombreEmpaqueMedida._ContenidoCampo = xr(.c_NombreEmpaqueMedida._NombreCampo)
                                    .c_PLU._ContenidoCampo = xr(.c_PLU._NombreCampo)
                                    .c_PrecioRegular._ContenidoCampo = xr(.c_PrecioRegular._NombreCampo)
                                    .c_PrecioSugerido._ContenidoCampo = xr(.c_PrecioSugerido._NombreCampo)
                                    .c_ReferenciaEmpaqueMedida._ContenidoCampo = xr(.c_ReferenciaEmpaqueMedida._NombreCampo)
                                    .c_ReferenciaPrecioMayor._ContenidoCampo = xr(.c_ReferenciaPrecioMayor._NombreCampo)
                                    .c_TasaIva._ContenidoCampo = xr(.c_TasaIva._NombreCampo)
                                    .c_TipoTasaIva._ContenidoCampo = xr(.c_TipoTasaIva._NombreCampo)
                                    .c_AutoDevAnu._ContenidoCampo = xficha._AutoDevAnu
                                    .c_AutoJornada._ContenidoCampo = xficha._Jornada._AutoJornada
                                    .c_AutoOperador._ContenidoCampo = xficha._Operador._AutoOperador
                                    .c_AutoUsuario._ContenidoCampo = xficha._FichaUsuario._AutoUsuario
                                    .c_Fecha._ContenidoCampo = xficha._Fecha
                                    .c_HoraDevAnu._ContenidoCampo = xficha._Hora
                                    Select Case xficha._NivelCave
                                        Case NivelClave.SinClave : .c_NivelClaveDevAnu._ContenidoCampo = "0"
                                        Case NivelClave.Maxima : .c_NivelClaveDevAnu._ContenidoCampo = "1"
                                        Case NivelClave.Media : .c_NivelClaveDevAnu._ContenidoCampo = "2"
                                        Case NivelClave.Minima : .c_NivelClaveDevAnu._ContenidoCampo = "3"
                                    End Select
                                    .c_NombreUsuario._ContenidoCampo = xficha._FichaUsuario._NombreUsuario
                                    .c_TipoDevAnu._ContenidoCampo = xficha._TipoDevAnu
                                    .c_EstacionDevAnu._ContenidoCampo = xficha._EquipoEstacion
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = DevolucionAnulacion.INSERT
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoEmpaqueMedida._NombreCampo, xdevolucion._AutoEmpaqueMedida).Size = xdevolucion.c_AutoEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoProducto._NombreCampo, xdevolucion._AutoProducto).Size = xdevolucion.c_AutoProducto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Cantidad._NombreCampo, xdevolucion._Cantidad)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_CodigoBarraLeido._NombreCampo, xdevolucion._CodigoBarraLeido).Size = xdevolucion.c_CodigoBarraLeido._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ContenidoEmpaqueMedida._NombreCampo, xdevolucion._ContenidoEmpaqueMedida)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EnOferta._NombreCampo, xdevolucion.c_EnOferta._ContenidoCampo).Size = xdevolucion.c_EnOferta._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EsPesado._NombreCampo, xdevolucion.c_EsPesado._ContenidoCampo).Size = xdevolucion.c_EsPesado._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaAuto._NombreCampo, xdevolucion._EtiquetaAuto).Size = xdevolucion.c_EtiquetaAuto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaBalanza._NombreCampo, xdevolucion._EtiquetaBalanza).Size = xdevolucion.c_EtiquetaBalanza._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaControl._NombreCampo, xdevolucion._EtiquetaControl).Size = xdevolucion.c_EtiquetaControl._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDepartamento._NombreCampo, xdevolucion._EtiquetaDepartamento).Size = xdevolucion.c_EtiquetaDepartamento._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaDigitos._NombreCampo, xdevolucion._EtiquetaDigitos).Size = xdevolucion.c_EtiquetaDigitos._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaFormato._NombreCampo, xdevolucion._EtiquetaFormato).Size = xdevolucion.c_EtiquetaFormato._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaImporteMonto._NombreCampo, xdevolucion._EtiquetaImporteMonto)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaItem._NombreCampo, xdevolucion._EtiquetaItem).Size = xdevolucion.c_EtiquetaItem._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPeso._NombreCampo, xdevolucion._EtiquetaPeso)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPlu._NombreCampo, xdevolucion._EtiquetaPlu).Size = xdevolucion.c_EtiquetaPlu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaPrecio._NombreCampo, xdevolucion._EtiquetaPrecio)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaSeccion._NombreCampo, xdevolucion._EtiquetaSeccion).Size = xdevolucion.c_EtiquetaSeccion._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaTicket._NombreCampo, xdevolucion._EtiquetaTicket).Size = xdevolucion.c_EtiquetaTicket._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EtiquetaVendedor._NombreCampo, xdevolucion._EtiquetaVendedor).Size = xdevolucion.c_EtiquetaVendedor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreCorto._NombreCampo, xdevolucion._NombreCorto).Size = xdevolucion.c_NombreCorto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreEmpaqueMedida._NombreCampo, xdevolucion._NombreEmpaqueMedida).Size = xdevolucion.c_NombreEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PLU._NombreCampo, xdevolucion._PLU).Size = xdevolucion.c_PLU._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioNeto._NombreCampo, xdevolucion._PrecioVenta._Base)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioRegular._NombreCampo, xdevolucion._PrecioRegular)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_PrecioSugerido._NombreCampo, xdevolucion._PrecioSugerido)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaEmpaqueMedida._NombreCampo, xdevolucion._ReferenciaEmpaqueMedida).Size = xdevolucion.c_ReferenciaEmpaqueMedida._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_ReferenciaPrecioMayor._NombreCampo, xdevolucion._ReferenciaPrecioMayor).Size = xdevolucion.c_ReferenciaPrecioMayor._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TasaIva._NombreCampo, xdevolucion._TasaIva)
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoTasaIva._NombreCampo, xdevolucion.c_TipoTasaIva._ContenidoCampo).Size = xdevolucion.c_TipoTasaIva._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoDevAnu._NombreCampo, xdevolucion.c_AutoDevAnu._ContenidoCampo).Size = xdevolucion.c_AutoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoJornada._NombreCampo, xdevolucion.c_AutoJornada._ContenidoCampo).Size = xdevolucion.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoOperador._NombreCampo, xdevolucion.c_AutoOperador._ContenidoCampo).Size = xdevolucion.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_AutoUsuario._NombreCampo, xdevolucion.c_AutoUsuario._ContenidoCampo).Size = xdevolucion.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NombreUsuario._NombreCampo, xdevolucion.c_NombreUsuario._ContenidoCampo).Size = xdevolucion.c_NombreUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_Fecha._NombreCampo, xdevolucion.c_Fecha._ContenidoCampo).Size = xdevolucion.c_Fecha._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_HoraDevAnu._NombreCampo, xdevolucion.c_HoraDevAnu._ContenidoCampo).Size = xdevolucion.c_HoraDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_NivelClaveDevAnu._NombreCampo, xdevolucion.c_NivelClaveDevAnu._ContenidoCampo).Size = xdevolucion.c_NivelClaveDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_TipoDevAnu._NombreCampo, xdevolucion.c_TipoDevAnu._ContenidoCampo).Size = xdevolucion.c_TipoDevAnu._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xdevolucion.c_EstacionDevAnu._NombreCampo, xdevolucion.c_EstacionDevAnu._ContenidoCampo).Size = xdevolucion.c_EstacionDevAnu._LargoCampo
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL REGISTRAR DEVOLUCION")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update POS_VENTA set prd_cantidad=prd_cantidad-@cantidad where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xficha._FichaItem._AutoItem)
                                xcmd.Parameters.AddWithValue("@cantidad", xficha._CantidadDevolver)
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PROBLEMA AL ACTUALIZAR ITEM EN DEVOLUCION")
                                End If

                            End Using
                            xtr.Commit()
                            RaiseEvent _DevolucionOK()
                            RaiseEvent _VisorDevolucionCantidad(xdevolucion._NombreCorto, xdevolucion._Cantidad, xdevolucion._PrecioVenta._Full)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL EFECTUAR DEVOLUCION ITEM" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_ActualizarCantidadPrecioItem(ByVal xitem As PosVenta, ByVal xcant As Decimal, ByVal xprecio As Decimal) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update pos_venta set prd_cantidad=@cant, prd_precioneto=@neto where autoitem=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xitem.RegistroDato._AutoItem)
                                xcmd.Parameters.AddWithValue("@cant", xcant)
                                xcmd.Parameters.AddWithValue("@neto", xprecio)
                                xcmd.ExecuteNonQuery()
                            End Using

                            RaiseEvent _RegistroVentaOk()
                            RaiseEvent _VisorActualizarCantidadVenta(xitem.RegistroDato._NombreCorto, xitem.RegistroDato._Cantidad, xitem.RegistroDato._PrecioVenta._Full)
                            Return True

                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    RaiseEvent _ErrorRegistro()
                    Throw New Exception("PROBLEMA AL ACTUALIZAR CANTIDAD / PRECIO DEL ITEM" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class
    End Class
End Namespace



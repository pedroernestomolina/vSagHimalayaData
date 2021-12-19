Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports ImpFiscales.MisFiscales
Imports DataSistema.MiDataSistema.DataSistema.PosOnline


Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FastFood

            Public Class VentasFastFood
                Event _FacturaGrabadaOk()
                Event _VisorCambioDar(ByVal xmonto As Decimal)
                Event _ImprimirComanda(ByVal xautodoc As String)
                Event _NotaCreditoExitosa()
                Event _NotaCreditoAnuladaExitosamente()
                Event _ImprimirFacturaChimba(ByVal auto_doc As String)
                Event _ImprimirCopiaFactura(ByVal auto_doc As String)


                Public Class AgregarVenta
                    Class Encabezado
                        Enum TipoCondicionPago As Integer
                            Contado = 0
                            Credito = 1
                        End Enum

                        Private xcliente As FichaClientes.c_Clientes.c_Registro
                        Private xusuario As FichaGlobal.c_Usuario.c_Registro
                        Private xvendedor As FichaVendedores.c_Vendedor.c_Registro
                        Private xcobrador As FichaCobradores.c_Cobrador.c_Registro
                        Private xestacion As String
                        Private xrenglones As Integer
                        Private xsucursal As String
                        Private xbase1 As Decimal
                        Private xbase2 As Decimal
                        Private xbase3 As Decimal
                        Private xbase0 As Decimal
                        Private xtasa1 As Decimal
                        Private xtasa2 As Decimal
                        Private xtasa3 As Decimal
                        Private xtasadescuento As Decimal
                        Private xjornada As String
                        Private xoperador As String
                        Private xserie As String
                        Private xcondicion As TipoCondicionPago
                        Private xtotal As Decimal
                        Private xsubtotal As Decimal
                        Private xfactor As Decimal
                        Private xmonto_descuento_neto As Decimal
                        Private xmonto_cargo_neto As Decimal
                        Private xtasacargo As Decimal

                        Property _Cliente() As FichaClientes.c_Clientes.c_Registro
                            Get
                                Return xcliente
                            End Get
                            Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                                xcliente = value
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

                        Property _Vendedor() As FichaVendedores.c_Vendedor.c_Registro
                            Get
                                Return xvendedor
                            End Get
                            Set(ByVal value As FichaVendedores.c_Vendedor.c_Registro)
                                xvendedor = value
                            End Set
                        End Property

                        Property _Cobrador() As FichaCobradores.c_Cobrador.c_Registro
                            Get
                                Return xcobrador
                            End Get
                            Set(ByVal value As FichaCobradores.c_Cobrador.c_Registro)
                                xcobrador = value
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

                        Property _Renglones() As Integer
                            Get
                                Return xrenglones
                            End Get
                            Set(ByVal value As Integer)
                                xrenglones = value
                            End Set
                        End Property

                        Property _Sucursal() As String
                            Get
                                Return xsucursal
                            End Get
                            Set(ByVal value As String)
                                xsucursal = value
                            End Set
                        End Property

                        Property _Exento() As Decimal
                            Get
                                Return xbase0
                            End Get
                            Set(ByVal value As Decimal)
                                xbase0 = value
                            End Set
                        End Property

                        Property _MontoBase1() As Decimal
                            Get
                                Return xbase1
                            End Get
                            Set(ByVal value As Decimal)
                                xbase1 = value
                            End Set
                        End Property

                        Property _MontoBase2() As Decimal
                            Get
                                Return xbase2
                            End Get
                            Set(ByVal value As Decimal)
                                xbase2 = value
                            End Set
                        End Property

                        Property _MontoBase3() As Decimal
                            Get
                                Return xbase3
                            End Get
                            Set(ByVal value As Decimal)
                                xbase3 = value
                            End Set
                        End Property

                        Property _TasaIva1() As Decimal
                            Get
                                Return xtasa1
                            End Get
                            Set(ByVal value As Decimal)
                                xtasa1 = value
                            End Set
                        End Property

                        Property _TasaIva2() As Decimal
                            Get
                                Return xtasa2
                            End Get
                            Set(ByVal value As Decimal)
                                xtasa2 = value
                            End Set
                        End Property

                        Property _TasaIva3() As Decimal
                            Get
                                Return xtasa3
                            End Get
                            Set(ByVal value As Decimal)
                                xtasa3 = value
                            End Set
                        End Property

                        Property _TasaDescuento() As Decimal
                            Get
                                Return xtasadescuento
                            End Get
                            Set(ByVal value As Decimal)
                                xtasadescuento = value
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

                        Property _Serie() As String
                            Get
                                Return xserie
                            End Get
                            Set(ByVal value As String)
                                xserie = value
                            End Set
                        End Property

                        Property _CondicionPago() As TipoCondicionPago
                            Get
                                Return xcondicion
                            End Get
                            Set(ByVal value As TipoCondicionPago)
                                xcondicion = value
                            End Set
                        End Property

                        Property _TotalGeneral() As Decimal
                            Get
                                Return xtotal
                            End Get
                            Set(ByVal value As Decimal)
                                xtotal = value
                            End Set
                        End Property

                        Property _FactorCambio() As Decimal
                            Get
                                Return xfactor
                            End Get
                            Set(ByVal value As Decimal)
                                xfactor = value
                            End Set
                        End Property

                        Property _SubTotalGeneralSinDescuentoNiCargos() As Decimal
                            Get
                                Return xsubtotal
                            End Get
                            Set(ByVal value As Decimal)
                                xsubtotal = value
                            End Set
                        End Property

                        Property _MontoDescuentoNeto() As Decimal
                            Get
                                Return xmonto_descuento_neto
                            End Get
                            Set(ByVal value As Decimal)
                                xmonto_descuento_neto = value
                            End Set
                        End Property

                        Property _MontoCargoNeto() As Decimal
                            Get
                                Return xmonto_cargo_neto
                            End Get
                            Set(ByVal value As Decimal)
                                xmonto_cargo_neto = value
                            End Set
                        End Property

                        Property _TasaCargo() As Decimal
                            Get
                                Return xtasacargo
                            End Get
                            Set(ByVal value As Decimal)
                                xtasacargo = value
                            End Set
                        End Property

                        Protected Friend ReadOnly Property _FechaEmision() As Date
                            Get
                                Return FechaSistema.Date
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Hora() As String
                            Get
                                Dim xv As String = F_GetDate("select getdate()").ToShortTimeString
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _AnoRelacion() As String
                            Get
                                Return Year(_FechaEmision).ToString.Trim.PadLeft(4, "0")
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Base() As Decimal
                            Get
                                Dim xv As Decimal = Decimal.Round(Me._MontoBase1 + Me._MontoBase2 + Me._MontoBase3, 2, MidpointRounding.AwayFromZero)
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _BloquearAlmacen() As String
                            Get
                                Return "0"
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _DiasCredito() As Integer
                            Get
                                If Me._CondicionPago = TipoCondicionPago.Contado Then
                                    Return 0
                                Else
                                    Return Me._Cliente.r_DiasCredito
                                End If
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Estatus() As String
                            Get
                                Return "0"
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _FechaVencimiento() As Date
                            Get
                                Return DateAdd(DateInterval.Day, _DiasCredito, _FechaEmision)
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Impuesto1() As Decimal
                            Get
                                Dim xv As Decimal = 0
                                xv = Decimal.Round(Me._MontoBase1 * Me._TasaIva1 / 100, 2, MidpointRounding.AwayFromZero)
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Impuesto2() As Decimal
                            Get
                                Dim xv As Decimal = 0
                                xv = Decimal.Round(Me._MontoBase2 * Me._TasaIva2 / 100, 2, MidpointRounding.AwayFromZero)
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Impuesto3() As Decimal
                            Get
                                Dim xv As Decimal = 0
                                xv = Decimal.Round(Me._MontoBase3 * Me._TasaIva3 / 100, 2, MidpointRounding.AwayFromZero)
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _Impuesto() As Decimal
                            Get
                                Dim xv As Decimal = 0
                                xv = Decimal.Round(Me._Impuesto1 + Me._Impuesto2 + Me._Impuesto3, 2, MidpointRounding.AwayFromZero)
                                Return xv
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _MesRelacion() As String
                            Get
                                Return Month(_FechaEmision).ToString.Trim.PadLeft(2, "0")
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _TipoDocumento() As String
                            Get
                                Return "01"
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _TipoColumna() As String
                            Get
                                Return "1"
                            End Get
                        End Property

                        Protected Friend ReadOnly Property _MontoDivisa() As Decimal
                            Get
                                Dim xv As Decimal = 0
                                If _FactorCambio > 0 Then
                                    xv = Decimal.Round(_TotalGeneral / _FactorCambio, 2, MidpointRounding.AwayFromZero)
                                End If
                                Return xv
                            End Get
                        End Property

                        ReadOnly Property _SaldoPendiente() As Decimal
                            Get
                                If _CondicionPago = TipoCondicionPago.Contado Then
                                    Return 0
                                Else
                                    Return _TotalGeneral
                                End If
                            End Get
                        End Property

                        Sub New()
                            Me._Cliente = Nothing
                            Me._Cobrador = Nothing
                            Me._CondicionPago = TipoCondicionPago.Contado
                            Me._EstacionEquipo = ""
                            Me._Exento = 0
                            Me._Jornada = ""
                            Me._MontoBase1 = 0
                            Me._MontoBase2 = 0
                            Me._MontoBase3 = 0
                            Me._MontoDescuentoNeto = 0
                            Me._Operador = ""
                            Me._Renglones = 0
                            Me._Serie = ""
                            Me._Sucursal = ""
                            Me._TasaDescuento = 0
                            Me._TasaIva1 = 0
                            Me._TasaIva2 = 0
                            Me._TasaIva3 = 0
                            Me._Usuario = Nothing
                            Me._Vendedor = Nothing
                            Me._FactorCambio = 0
                            Me._TotalGeneral = 0
                            Me._SubTotalGeneralSinDescuentoNiCargos = 0
                            Me._MontoCargoNeto = 0
                            Me._TasaCargo = 0
                        End Sub
                    End Class
                    Class Detalle
                        Class Item
                            Private xreg As TemporalVenta_FastFood.c_Registro
                            Private xplato As Platos.c_Registro
                            Private xproducto As FichaProducto.Prd_Producto.c_Registro

                            Property _Registro() As TemporalVenta_FastFood.c_Registro
                                Get
                                    Return xreg
                                End Get
                                Set(ByVal value As TemporalVenta_FastFood.c_Registro)
                                    xreg = value
                                End Set
                            End Property

                            Property _Plato() As Platos.c_Registro
                                Get
                                    Return xplato
                                End Get
                                Set(ByVal value As Platos.c_Registro)
                                    xplato = value
                                End Set
                            End Property

                            Property _Producto() As FichaProducto.Prd_Producto.c_Registro
                                Get
                                    Return xproducto
                                End Get
                                Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                                    xproducto = value
                                End Set
                            End Property

                            Sub New()
                                Me._Plato = New Platos.c_Registro
                                Me._Producto = New FichaProducto.Prd_Producto.c_Registro
                                Me._Registro = New TemporalVenta_FastFood.c_Registro
                            End Sub
                        End Class

                        Private xitems As Item

                        Property _Item() As Item
                            Get
                                Return xitems
                            End Get
                            Set(ByVal value As Item)
                                xitems = value
                            End Set
                        End Property

                        Sub New()
                            Me._Item = New Item
                        End Sub
                    End Class

                    Private xfichadeposito As FichaGlobal.c_Depositos.c_Registro
                    Private xencabezado As Encabezado
                    Private xdetalles As List(Of Detalle)
                    Private xtipocalculoutilidad As TipoCalculoUtilidad
                    Private xmontorecibe As Decimal
                    Private xtablapagos As DataTable

                    Property _TablaModosPago() As DataTable
                        Get
                            Return xtablapagos
                        End Get
                        Set(ByVal value As DataTable)
                            xtablapagos = value
                        End Set
                    End Property

                    Property _MontoRecibido() As Decimal
                        Get
                            Return xmontorecibe
                        End Get
                        Set(ByVal value As Decimal)
                            xmontorecibe = value
                        End Set
                    End Property

                    Property _TipoCalculoUtilidad() As TipoCalculoUtilidad
                        Get
                            Return xtipocalculoutilidad
                        End Get
                        Set(ByVal value As TipoCalculoUtilidad)
                            xtipocalculoutilidad = value
                        End Set
                    End Property

                    Property _FichaDeposito() As FichaGlobal.c_Depositos.c_Registro
                        Get
                            Return xfichadeposito
                        End Get
                        Set(ByVal value As FichaGlobal.c_Depositos.c_Registro)
                            xfichadeposito = value
                        End Set
                    End Property

                    Property _Encabezado() As Encabezado
                        Get
                            Return xencabezado
                        End Get
                        Set(ByVal value As Encabezado)
                            xencabezado = value
                        End Set
                    End Property

                    Property _Detalles() As List(Of Detalle)
                        Get
                            Return xdetalles
                        End Get
                        Set(ByVal value As List(Of Detalle))
                            xdetalles = value
                        End Set
                    End Property

                    Sub New()
                        Me._Encabezado = New Encabezado
                        Me._Detalles = New List(Of Detalle)
                        Me._FichaDeposito = Nothing
                        Me._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto
                        Me._MontoRecibido = 0
                        Me._TablaModosPago = New DataTable
                    End Sub

                    Sub M_CrearTablaModoPago(ByRef xtb As DataTable)
                        Try
                            xtb = New DataTable
                            xtb.Columns.Add("AutoAgencia", GetType(String))
                            xtb.Columns.Add("NombreAgencia", GetType(String))
                            xtb.Columns.Add("ChequeTarjetaNumero", GetType(String))
                            xtb.Columns.Add("Importe", GetType(Decimal))
                            xtb.Columns.Add("AutoTipoPago", GetType(String))
                            xtb.Columns.Add("NombreTipoPago", GetType(String))
                            xtb.Columns.Add("CodigoTipoPago", GetType(String))
                            xtb.Columns.Add("MontoRecibido", GetType(Decimal))
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Sub
                End Class

                Enum ModoFactura As Integer
                    Legal = 1
                    Chimba = 2
                End Enum

                Function F_GrabarVentaFastFood(ByVal xventa As AgregarVenta _
                                               , ByVal impfiscal As IFiscal _
                                               , ByVal xpagos As List(Of FormaPago) _
                                               , Optional ByVal xmodo As ModoFactura = ModoFactura.Legal) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_ventas=a_ventas+1; select a_ventas from contadores"
                        Dim xsql_2 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                        Dim xsql_3 As String = "update series_fiscales set correlativo=correlativo+1, estatus_fiscal='1' where nombre=@nombre;" _
                                             + "select correlativo from series_fiscales where nombre=@nombre"
                        Dim xsql_4 As String = "update contadores set a_historialcomandas_fastfood=a_historialcomandas_fastfood+1; select a_historialcomandas_fastfood from contadores"

                        Dim autocxc As String = ""
                        Dim xtr As SqlTransaction = Nothing
                        Dim xfiscal As New FichaGlobal.c_SeriesFiscales

                        Dim xtb As New DataTable
                        If xmodo = ModoFactura.Legal Then
                            Using xadap As New SqlDataAdapter("select * from series_fiscales where nombre=@nombre", _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                xfiscal.M_CargarFicha(xtb(0))
                            Else
                                Throw New Exception("ERROR... SERIE NO REGISTRADA, VERIFIQUE")
                            End If
                        End If

                        If impfiscal IsNot Nothing Then
                            If xfiscal.RegistroDato.r_SerialFiscal <> impfiscal.Ver_SerialImpresoraFiscal Then
                                Throw New Exception("ERROR... SERIAL FISCAL NO COINCIDE CON EL SERIAL DE LA IMPRESORA A GENERAR DOCUMENTO, VERIFIQUE")
                            End If
                        End If

                        If xmodo = ModoFactura.Legal Then
                            If xfiscal.RegistroDato.r_EstatusSerie = TipoEstatus.Activo Then
                                If xfiscal.RegistroDato.r_EstatusParaVentas = TipoEstatus.Inactivo Then
                                    Throw New Exception("ERROR... SERIE NO ASIGNADA PARA EFECTUAR VENTAS, VERIFIQUE")
                                End If
                            Else
                                Throw New Exception("ERROR... SERIE ESTA EN ESTADO INACTVIO, VERIFIQUE")
                            End If
                        End If


                        Dim xtb_venta As New FichaVentas.V_Ventas.c_Registro
                        With xtb_venta
                            .c_AnoRelacion.c_Texto = xventa._Encabezado._AnoRelacion
                            .c_AutoCliente.c_Texto = xventa._Encabezado._Cliente.r_Automatico
                            .c_AutoDocumento.c_Texto = ""
                            .c_AutomaticoJornada.c_Texto = xventa._Encabezado._Jornada
                            .c_AutomaticoOperador.c_Texto = xventa._Encabezado._Operador
                            .c_AutoRecibo.c_Texto = ""
                            .c_AutoUsuario.c_Texto = xventa._Encabezado._Usuario._AutoUsuario
                            .c_AutoVendedor.c_Texto = xventa._Encabezado._Vendedor.r_Automatico
                            .c_Base.c_Valor = xventa._Encabezado._Base
                            .c_Base1.c_Valor = xventa._Encabezado._MontoBase1
                            .c_Base2.c_Valor = xventa._Encabezado._MontoBase2
                            .c_Base3.c_Valor = xventa._Encabezado._MontoBase3
                            .c_BloquearAlmacen.c_Texto = xventa._Encabezado._BloquearAlmacen
                            .c_CantidadRenglones.c_Valor = xventa._Encabezado._Renglones
                            .c_CiRifCliente.c_Texto = xventa._Encabezado._Cliente.r_CiRif
                            .c_CodigoCliente.c_Texto = xventa._Encabezado._Cliente.r_CodigoCliente
                            .c_CodigoSucursal.c_Texto = xventa._Encabezado._Sucursal
                            .c_CodigoTransporte.c_Texto = ""
                            .c_CodigoUsuario.c_Texto = xventa._Encabezado._Usuario._CodigoUsuario
                            .c_CodigoVendedor.c_Texto = xventa._Encabezado._Vendedor.r_CodigoVendedor
                            .c_ComprobanteRetencion.c_Texto = ""
                            .c_ComprobanteRetencionISLR.c_Texto = ""
                            .c_CondicionPago.c_Texto = IIf(xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado, "CONTADO", "CREDITO")
                            .c_ControlFiscal.c_Texto = ""
                            .c_DiasCreditoCliente.c_Valor = xventa._Encabezado._DiasCredito
                            .c_DirDespacho.c_Texto = xventa._Encabezado._Cliente.r_DirDespacho
                            .c_DirFiscalCliente.c_Texto = xventa._Encabezado._Cliente.r_DirFiscal
                            .c_Documento.c_Texto = ""
                            .c_DocumentoAplica.c_Texto = ""
                            .c_EstacionEquipo.c_Texto = xventa._Encabezado._EstacionEquipo
                            .c_EstatusDocumento.c_Texto = xventa._Encabezado._Estatus
                            .c_Exento.c_Valor = xventa._Encabezado._Exento
                            .c_FactorCambio.c_Valor = xventa._Encabezado._FactorCambio
                            .c_FechaEmision.c_Valor = xventa._Encabezado._FechaEmision
                            .c_FechaPedido.c_Valor = xventa._Encabezado._FechaEmision
                            .c_FechaRelacion.c_Valor = xventa._Encabezado._FechaEmision
                            .c_FechaVencimiento.c_Valor = xventa._Encabezado._FechaVencimiento
                            .c_Hora.c_Texto = xventa._Encabezado._Hora
                            .c_Impuesto.c_Valor = xventa._Encabezado._Impuesto
                            .c_Impuesto1.c_Valor = xventa._Encabezado._Impuesto1
                            .c_Impuesto2.c_Valor = xventa._Encabezado._Impuesto2
                            .c_Impuesto3.c_Valor = xventa._Encabezado._Impuesto3
                            .c_MesRelacion.c_Texto = xventa._Encabezado._MesRelacion
                            .c_MontoCargo.c_Valor = xventa._Encabezado._MontoCargoNeto
                            .c_MontoDescuento_1.c_Valor = xventa._Encabezado._MontoDescuentoNeto
                            .c_MontoDescuento_2.c_Valor = 0
                            .c_MontoDivisa.c_Valor = xventa._Encabezado._MontoDivisa
                            .c_MontoSaldoPendiente.c_Valor = xventa._Encabezado._SaldoPendiente
                            .c_MontoSubTotal.c_Valor = xventa._Encabezado._SubTotalGeneralSinDescuentoNiCargos
                            .c_NombreCliente.c_Texto = xventa._Encabezado._Cliente.r_NombreRazonSocial
                            .c_NombreDespachador.c_Texto = ""
                            .c_NombreVendedor.c_Texto = xventa._Encabezado._Vendedor.r_NombreVendedor
                            .c_NotasDocumento.c_Texto = ""
                            .c_NumeroPedido.c_Texto = ""
                            .c_NumeroRecibo.c_Texto = ""
                            .c_OrdenCompra.c_Texto = ""
                            .c_RetencionISLR.c_Valor = 0
                            .c_RetencionIva.c_Valor = 0
                            If impfiscal IsNot Nothing Then
                                .c_SerialImpresoraFiscal.c_Texto = impfiscal.Ver_SerialImpresoraFiscal
                            Else
                                .c_SerialImpresoraFiscal.c_Texto = ""
                            End If
                            .c_SerialUnico_Jornada.c_Texto = ""
                            If xmodo = ModoFactura.Legal Then
                                .c_SerieAsignada.c_Texto = xventa._Encabezado._Serie
                            Else
                                .c_SerieAsignada.c_Texto = ""
                            End If
                            .c_Tasa1.c_Valor = xventa._Encabezado._TasaIva1
                            .c_Tasa2.c_Valor = xventa._Encabezado._TasaIva2
                            .c_Tasa3.c_Valor = xventa._Encabezado._TasaIva3
                            .c_TasaCargos.c_Valor = xventa._Encabezado._TasaCargo
                            .c_TasaDescuento_1.c_Valor = xventa._Encabezado._TasaDescuento
                            .c_TasaDescuento_2.c_Valor = 0
                            .c_TasaRetencionISLR.c_Valor = 0
                            .c_TasaRetencionIva.c_Valor = 0
                            .c_TelefonoCliente.c_Texto = xventa._Encabezado._Cliente.r_Telefono_1
                            .c_TipoColumna.c_Texto = xventa._Encabezado._TipoColumna
                            .c_TipoDocumento.c_Texto = xventa._Encabezado._TipoDocumento
                            .c_TotalGeneral.c_Valor = xventa._Encabezado._TotalGeneral
                            .c_Transporte.c_Texto = ""
                            .c_Usuario.c_Texto = xventa._Encabezado._Usuario._NombreUsuario
                            .c_ValidezDocumentoDias.c_Valor = 0
                            .c_OrigenDocumento.c_Texto = "04"
                            .c_Rest_ModoMesaPedido.c_Texto = ""
                            .c_Rest_NumeroMesaPedido.c_Texto = ""
                            .c_Rest_ServicioMonto.c_Valor = 0
                            .c_Rest_ServicioTasa.c_Valor = 0
                            .c_Relacion_Z.c_Valor = 0
                        End With

                        'Tabla Usada Para Lista De Productos Para La Impresora Fiscal
                        Dim xtablaprd As New DataTable
                        With xtablaprd
                            .Columns.Add("cantidad", GetType(System.Decimal))
                            .Columns.Add("nombre", GetType(System.String))
                            .Columns.Add("codigo", GetType(System.String))
                            .Columns.Add("precio_neto", GetType(System.Decimal))
                            .Columns.Add("codigo_tasa", GetType(System.String))
                        End With

                        Dim i As Integer = 0
                        Dim xdetalles As New List(Of VentasDetalle_FastFood.c_Registro)
                        Dim xhistorial As New List(Of HistorialComandas_FastFood.c_Registro)
                        Dim xlistakardex As New List(Of FichaProducto.Prd_Kardex.c_Registro)

                        Dim xlist = From s In xventa._Detalles Where s._Item._Registro._TipoItem = TipoItemFastFood.Plato
                        For Each xitem In xlist
                            i += 1
                            Dim xventadetallefastfood As New VentasDetalle_FastFood.c_Registro

                            With xventadetallefastfood
                                .c_AutoCliente._ContenidoCampo = xventa._Encabezado._Cliente.r_Automatico
                                .c_AutoDocumento._ContenidoCampo = ""
                                .c_AutoGrupo._ContenidoCampo = xitem._Item._Plato._AutoGrupo
                                .c_AutoItem._ContenidoCampo = i.ToString.Trim.PadLeft(10, "0")
                                .c_AutoItemOrigen._ContenidoCampo = ""
                                .c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                                .c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                                .c_AutoPlato._ContenidoCampo = xitem._Item._Registro._AutoPlato
                                .c_CantidadDespachada._ContenidoCampo = xitem._Item._Registro._CantidadDespachar
                                .c_CodigoPlato._ContenidoCampo = xitem._Item._Registro._CodigoPlato
                                .c_CostoNeto._ContenidoCampo = xitem._Item._Registro._CostoPlato
                                .c_CostoTotalNeto._ContenidoCampo = xitem._Item._Registro._CostoTotalItem
                                .c_EnOferta._ContenidoCampo = xitem._Item._Registro.c_EsOferta._ContenidoCampo
                                .c_EsPesado._ContenidoCampo = xitem._Item._Registro.c_EsPesado._ContenidoCampo
                                .c_Estatus._ContenidoCampo = "0"
                                .c_FechaEmision._ContenidoCampo = FechaSistema()
                                .c_MontoIva._ContenidoCampo = 0
                                .c_NombrePlato._ContenidoCampo = xitem._Item._Registro._NombrePlato
                                .c_NotasItem._ContenidoCampo = xitem._Item._Registro._NotasItem
                                .c_PrecioFinal._ContenidoCampo = 0
                                .c_PrecioNeto._ContenidoCampo = xitem._Item._Registro._PrecioNeto
                                .c_SignoDocumento._ContenidoCampo = 1
                                .c_TasaIva._ContenidoCampo = xitem._Item._Registro._TasaIva
                                .c_TipoCalculoUtilidad._ContenidoCampo = IIf(xventa._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto, "C", "V")
                                .c_TipoDocumento._ContenidoCampo = "01"
                                .c_TipoItem._ContenidoCampo = IIf(xitem._Item._Registro._TipoItem = TipoItemFastFood.Plato, "1", "2")
                                .c_TipoMovimiento._ContenidoCampo = "V"
                                Select Case xitem._Item._Registro._TipoTasa
                                    Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                                    Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                                    Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                                    Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                                End Select
                                .c_TotalGeneral._ContenidoCampo = 0
                                .c_TotalNeto._ContenidoCampo = 0
                                .c_UtilidadMonto._ContenidoCampo = 0
                                .c_UtilidadTasa._ContenidoCampo = 0
                                .c_EsCombo._ContenidoCampo = IIf(xitem._Item._Registro._EsCombo = TipoSiNo.Si, "1", "0")
                                .c_Rest_AutoMesonero._ContenidoCampo = ""
                                .c_Rest_CodigoMesonero._ContenidoCampo = ""
                                .c_Rest_NombreMesonero._ContenidoCampo = ""

                                Dim x0 As Decimal = xitem._Item._Registro._PrecioNeto
                                Dim x1 As Decimal = Decimal.Round(x0 * xitem._Item._Registro._CantidadDespachar, 2, MidpointRounding.AwayFromZero)
                                .c_TotalNeto._ContenidoCampo = x1
                                Dim x2 As Decimal = Decimal.Round(x1 * xitem._Item._Registro._TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                                .c_MontoIva._ContenidoCampo = x2
                                .c_TotalGeneral._ContenidoCampo = Decimal.Round(x1 + x2, 2, MidpointRounding.AwayFromZero)
                                Dim x4 As Decimal = x0
                                x4 = Decimal.Round(x4 - (x4 * xventa._Encabezado._TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
                                x4 = Decimal.Round(x4 + (x4 * xventa._Encabezado._TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
                                .c_PrecioFinal._ContenidoCampo = x4
                                Dim x5 As Decimal = x4 * ._CantidadDespachada
                                Dim x6 As Decimal = Decimal.Round((xitem._Item._Plato._CostoPlato * xitem._Item._Registro._CantidadDespachar), 2, MidpointRounding.AwayFromZero)
                                .c_UtilidadMonto._ContenidoCampo = Decimal.Round(x5 - x6, 2, MidpointRounding.AwayFromZero)
                                If ._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    .c_UtilidadTasa._ContenidoCampo = UtilidadBaseCosto(x6, ._UtilidadMonto)
                                Else
                                    .c_UtilidadTasa._ContenidoCampo = UtilidadBasePrecioVenta(x5, ._UtilidadMonto)
                                End If

                                If ._UtilidadMonto >= 0 Then
                                Else
                                    Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO POR DEBAJO DEL COSTO" + vbCrLf + ._NombrePlato)
                                End If

                                If xitem._Item._Plato._EstatusPlato = TipoEstatus.Activo Then
                                Else
                                    Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO POR INACTIVO" + vbCrLf + ._NombrePlato)
                                End If
                            End With
                            xdetalles.Add(xventadetallefastfood)


                            'HISTORIAL DE COMANDAS
                            Dim xsql As String = ""
                            If xitem._Item._Registro._EsCombo = TipoSiNo.Si Then
                                xsql = "select mp.auto xauto, (mc.cantidad * @xcantidad) xcantidad, mp.nombre_plato xnombre, tvn.detalle xdetalle, " & _
                                "'' xauto_estacion, '' xnombre_estacion, '' xruta_estacion, '' xestatus_plato_envio, '' xestatus_estacion_envio from " & _
                                "TemporalVenta_NotasPlato_FastFood tvn join MenuPlatos_FastFood mp on tvn.auto_plato=mp.auto " & _
                                "join MenuCombos_FastFood mc on mc.auto_plato = mp.auto and mc.auto_plato_combo=@plato " & _
                                "where tvn.auto_item=@item " & _
                                "UNION " & _
                                "select mp.auto xauto, @xcantidad xcantidad, mp.nombre_plato xnombre, '' xdetalle, " & _
                                "'' xauto_estacion, '' xnombre_estacion, '' xruta_estacion, '' xestatus_plato_envio, '' xestatus_estacion_envio from " & _
                                "MenuPlatos_FastFood mp join TemporalVenta_FastFood tvf on tvf.auto_plato=mp.auto " & _
                                "where tvf.auto_item=@item"
                            Else
                                xsql = "select mp.auto xauto, @xcantidad xcantidad, mp.nombre_plato xnombre, tvn.detalle xdetalle, " & _
                                "'' xauto_estacion, '' xnombre_estacion, '' xruta_estacion, '' xestatus_plato_envio, '' xestatus_estacion_envio from " & _
                                "TemporalVenta_NotasPlato_FastFood tvn join MenuPlatos_FastFood mp on tvn.auto_plato=mp.auto " & _
                                "where tvn.auto_item=@item"
                            End If
                            Dim xtb_notas As New DataTable
                            Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.AddWithValue("@plato", xitem._Item._Registro._AutoPlato)
                                xadap.SelectCommand.Parameters.AddWithValue("@item", xitem._Item._Registro._AutoItem)
                                xadap.SelectCommand.Parameters.AddWithValue("@xcantidad", xitem._Item._Registro._CantidadDespachar)
                                xadap.Fill(xtb_notas)
                            End Using

                            'LISTA DE KARDEX PARA PLATOS QUE TRABAJAN CON INVENTARIO
                            For Each dr_notas As DataRow In xtb_notas.Rows
                                Dim xtb_inv As New DataTable
                                Dim xsql_inv As String = "select * from menuplatoinventario where auto_plato=@plato"
                                Using xadap As New SqlDataAdapter(xsql_inv, _MiCadenaConexion)
                                    xadap.SelectCommand.Parameters.AddWithValue("@plato", dr_notas("xauto"))
                                    xadap.Fill(xtb_inv)
                                End Using
                                Dim xplatoinv As New PlatosInventario.c_Registro
                                For Each xdr As DataRow In xtb_inv.Rows
                                    xplatoinv.M_Limpiar()
                                    xplatoinv.CargarRegistro(xdr)

                                    Dim xitemkardex As New FichaProducto.Prd_Kardex.c_Registro
                                    With xitemkardex
                                        .c_AutoConcepto.c_Texto = ""
                                        .c_AutoDeposito.c_Texto = xventa._FichaDeposito._Automatico
                                        .c_AutoDocumento.c_Texto = ""
                                        .c_AutoProducto.c_Texto = xplatoinv._Producto._AutoProducto
                                        .c_CantidadMover.c_Valor = xplatoinv._CantRequerida * xitem._Item._Registro._CantidadDespachar
                                        .c_CantidadUnidadesMover.c_Valor = xplatoinv._CantRequerida * xplatoinv._ContenidoEmpaque * xitem._Item._Registro._CantidadDespachar
                                        .c_Documento.c_Texto = ""
                                        .c_Entidad.c_Texto = xventa._Encabezado._Cliente.r_NombreRazonSocial
                                        .c_Estatus.c_Texto = xventa._Encabezado._Estatus
                                        .c_FechaEmision.c_Valor = xventa._Encabezado._FechaEmision
                                        .c_NotasDetallesMovimiento.c_Texto = ""
                                        .c_OrigenMovimiento.c_Texto = "0801"
                                        .c_ReferenciaEmpaque.c_Texto = "5"
                                        .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Salida
                                        .c_NombreProducto.c_Texto = xplatoinv._Producto._DescripcionDetallaDelProducto
                                        .c_NombreDeposito.c_Texto = xventa._FichaDeposito._Nombre
                                        .c_NombreConcepto.c_Texto = ""
                                        .c_NombreMedidaEmpaque.c_Texto = xplatoinv._MedidaEmpaque._NombreMedida
                                        .c_AutoMedida.c_Texto = xplatoinv._MedidaEmpaque._Automatico
                                        .c_ContenidoMedidaEmpaque.c_Valor = xplatoinv._ContenidoEmpaque
                                        .c_CodigoProducto.c_Texto = xplatoinv._Producto._CodigoProducto
                                        .c_CodigoDeposito.c_Texto = xventa._FichaDeposito._Codigo
                                        .c_CodigoConcepto.c_Texto = "VENTAS"

                                        ._FastFood_ItemVenta = i.ToString.Trim.PadLeft(10, "0")
                                        ._FastFood_CantidadRequerida = xplatoinv._CantRequerida
                                    End With
                                    xlistakardex.Add(xitemkardex)
                                Next
                            Next

                            Dim xsql2 As String = "select e.auto xauto_estacion ,e.nombre xnombre_estacion," & _
                               "e.ruta xruta_estacion,e.estatus xestatus_estacion, me.estatus xestatus_envio_plato " & _
                               "from Estacion_FastFood e join MenuEstaciones_FastFood me on e.auto=me.auto_estacion " & _
                               "join MenuPlatos_FastFood mp on mp.auto=me.auto_plato where mp.auto=@auto_plato"
                            Dim xtb_envio As New DataTable
                            For Each dr As DataRow In xtb_notas.AsEnumerable
                                xtb_envio.Rows.Clear()
                                Using xadap As New SqlDataAdapter(xsql2, _MiCadenaConexion)
                                    xadap.SelectCommand.Parameters.Clear()
                                    xadap.SelectCommand.Parameters.AddWithValue("@auto_plato", dr.Field(Of String)("xauto"))
                                    xadap.Fill(xtb_envio)
                                End Using
                                If xtb_envio.Rows.Count > 0 Then
                                    dr.SetField(Of String)("xauto_estacion", xtb_envio(0).Field(Of String)("xauto_estacion"))
                                    dr.SetField(Of String)("xnombre_estacion", xtb_envio(0).Field(Of String)("xnombre_estacion"))
                                    dr.SetField(Of String)("xruta_estacion", xtb_envio(0).Field(Of String)("xruta_estacion"))
                                    dr.SetField(Of String)("xestatus_plato_envio", xtb_envio(0).Field(Of String)("xestatus_envio_plato"))
                                    dr.SetField(Of String)("xestatus_estacion_envio", xtb_envio(0).Field(Of String)("xestatus_estacion"))
                                End If
                            Next
                            xtb_notas.AcceptChanges()

                            For Each xdrow In xtb_notas.AsEnumerable
                                Dim xcomanda As New HistorialComandas_FastFood.c_Registro
                                With xcomanda
                                    .c_Auto._ContenidoCampo = ""
                                    .c_AutoDocumento._ContenidoCampo = ""
                                    .c_AutoEstacion._ContenidoCampo = xdrow.Field(Of String)("xauto_estacion")
                                    .c_AutoItem._ContenidoCampo = xventadetallefastfood._AutoItem
                                    .c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                                    .c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                                    .c_AutoPlato._ContenidoCampo = xdrow.Field(Of String)("xauto")
                                    .c_Cantidad._ContenidoCampo = xdrow.Field(Of Decimal)("xcantidad")
                                    .c_Documento._ContenidoCampo = ""
                                    .c_EstatusEstacionEnvio._ContenidoCampo = xdrow.Field(Of String)("xestatus_estacion_envio")
                                    .c_EstatusPlatoEnvio._ContenidoCampo = xdrow.Field(Of String)("xestatus_plato_envio")
                                    .c_FechaProceso._ContenidoCampo = xventa._Encabezado._FechaEmision
                                    .c_NombreEstacion._ContenidoCampo = xdrow.Field(Of String)("xnombre_estacion")
                                    .c_NombrePlato._ContenidoCampo = xdrow.Field(Of String)("xnombre")
                                    .c_NombreUsuario._ContenidoCampo = xventa._Encabezado._Usuario._NombreUsuario
                                    .c_NotasDetalle._ContenidoCampo = xdrow.Field(Of String)("xdetalle")
                                    .c_RutaEstacion._ContenidoCampo = xdrow.Field(Of String)("xruta_estacion")
                                End With
                                xhistorial.Add(xcomanda)
                            Next
                        Next

                        Dim xproductos As New List(Of FichaVentas.V_VentasDetalle.c_Registro)
                        Dim xlist2 = From s In xventa._Detalles Where s._Item._Registro._TipoItem = TipoItemFastFood.Producto
                        For Each xitem In xlist2
                            i += 1

                            Dim xprdventa As New FichaVentas.V_VentasDetalle.c_Registro
                            With xprdventa
                                .c_AutoCliente.c_Texto = xventa._Encabezado._Cliente.r_Automatico
                                .c_AutoDepartamento.c_Texto = xitem._Item._Producto._AutoDepartamento
                                .c_AutoDeposito.c_Texto = xventa._FichaDeposito._Automatico
                                .c_AutoDocumento.c_Texto = ""
                                .c_AutoGrupo.c_Texto = xitem._Item._Producto._AutoGrupo
                                .c_AutoItem.c_Texto = i.ToString.Trim.PadLeft(10, "0")
                                .c_AutoItemOrigen.c_Texto = ""
                                .c_AutoMedida.c_Texto = xitem._Item._Producto._AutoEmpaqueVentaDetal
                                .c_AutoProducto.c_Texto = xitem._Item._Producto._AutoProducto
                                .c_AutoSubGrupo.c_Texto = xitem._Item._Producto._AutoSubGrupo
                                .c_CantidadDespachada.c_Valor = xitem._Item._Registro._CantidadDespachar
                                .c_CantidadUnidadInventario.c_Valor = (xitem._Item._Registro._ContenidoEmpaque * xitem._Item._Registro._CantidadDespachar)
                                .c_CategoriaProducto.c_Texto = xitem._Item._Producto._CategoriaDelProducto
                                .c_CodigoDeposito.c_Texto = xventa._FichaDeposito._Codigo
                                .c_CodigoProducto.c_Texto = xitem._Item._Producto._CodigoProducto
                                .c_ContenidoEmpaque.c_Valor = xitem._Item._Registro._ContenidoEmpaque
                                .c_Corte.c_Texto = xitem._Item._Producto.c_Corte.c_Texto
                                .c_Corte_X.c_Valor = 0
                                .c_Corte_Y.c_Valor = 0
                                .c_Corte_Z.c_Valor = 0
                                .c_CostoInventario.c_Valor = Decimal.Round(xitem._Item._Producto._CostoCompra._Base_Inv, 2, MidpointRounding.AwayFromZero)
                                .c_CostoVenta.c_Valor = Decimal.Round((xitem._Item._Producto._CostoCompra._Base_Inv * xitem._Item._Registro._ContenidoEmpaque) _
                                                                      * xitem._Item._Registro._CantidadDespachar, 2, MidpointRounding.AwayFromZero)
                                .c_DescuentoMonto_1.c_Valor = 0
                                .c_DescuentoMonto_2.c_Valor = 0
                                .c_DescuentoMonto_3.c_Valor = 0
                                .c_DescuentoTasa_1.c_Valor = 0
                                .c_DescuentoTasa_2.c_Valor = 0
                                .c_DescuentoTasa_3.c_Valor = 0
                                .c_DetalleNotas.c_Texto = ""
                                .c_DiasGarantia.c_Valor = xitem._Item._Producto._DiasDeGarantia
                                .c_Estatus.c_Texto = "0"
                                .c_EstatusCorte.c_Texto = xitem._Item._Producto.c_EstatusCorte.c_Texto
                                .c_EstatusGarantia.c_Texto = xitem._Item._Producto.c_EstatusGarantia.c_Texto
                                .c_EstatusSerial.c_Texto = xitem._Item._Producto.c_EstatusSerial.c_Texto
                                .c_FechaEmision.c_Valor = xventa._Encabezado._FechaEmision
                                .c_ForzarMedida.c_Texto = IIf(xitem._Item._Producto._ForzarUsoDecimalesEmpaqueVentaDetal = TipoSiNo.Si, "1", "0")
                                .c_MontoIva.c_Valor = 0 'xitem._Item._Registro._Impuesto
                                .c_NombreDeposito.c_Texto = xventa._FichaDeposito._Nombre
                                .c_NombreEmpaque.c_Texto = xitem._Item._Registro._NombreEmpaque
                                .c_NombreProducto.c_Texto = xitem._Item._Registro._NombrePlato
                                .c_NumeroDecimales.c_Valor = xitem._Item._Producto._CantDecimalesEmpaqueVentaDetal
                                .c_NombreCortoProducto.c_Texto = xitem._Item._Producto._DescripcionResumenDelProducto
                                .c_PrecioFinal.c_Valor = 0 'calculado
                                .c_PrecioInventario.c_Valor = 0 'calculado
                                .c_PrecioItem.c_Valor = xitem._Item._Registro._PrecioNeto
                                .c_PrecioNeto.c_Valor = xitem._Item._Registro._PrecioNeto
                                .c_PrecioSugerido.c_Valor = xitem._Item._Producto._PrecioSugerido
                                .c_PTO_AutoJornada.c_Texto = xventa._Encabezado._Jornada
                                .c_PTO_AutoOperador.c_Texto = xventa._Encabezado._Operador
                                .c_PTO_CodigoBarra.c_Texto = ""
                                .c_PTO_DigitosEtiqueta.c_Texto = ""
                                .c_PTO_EsPesado.c_Texto = xitem._Item._Registro.c_EsPesado._ContenidoCampo
                                .c_PTO_EstaEnOferta.c_Texto = xitem._Item._Registro.c_EsOferta._ContenidoCampo
                                .c_PTO_FormatoEtiqueta.c_Texto = ""
                                .c_PTO_MontoTotalEtiqueta.c_Valor = 0
                                .c_PTO_NumeroBalanzaEtiqueta.c_Texto = ""
                                .c_PTO_NumeroControlEtiqueta.c_Texto = ""
                                .c_PTO_NumeroDepartEtiqueta.c_Texto = ""
                                .c_PTO_NumeroItemEtiqueta.c_Valor = 0
                                .c_PTO_NumeroTicketEtiqueta.c_Texto = ""
                                .c_PTO_PesoEtiqueta.c_Valor = 0
                                .c_PTO_Plu.c_Texto = ""
                                .c_PTO_PluEtiqueta.c_Texto = ""
                                .c_PTO_PrecioEtiqueta.c_Valor = 0
                                .c_PTO_SeccionEtiqueta.c_Texto = ""
                                .c_PTO_VendedorEtiqueta.c_Texto = ""
                                .c_ReferenciaEmpaque.c_Texto = "5"
                                .c_SignoDocumento.c_Valor = 1
                                .c_TasaIva.c_Valor = xitem._Item._Registro._TasaIva
                                .c_TipoCalculoUtilidad.c_Texto = IIf(xventa._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto, "C", "V")
                                .c_TipoDocumento.c_Texto = "01"
                                .c_TipoMovimiento.c_Texto = "V"
                                .c_TipoTasaIva.c_Texto = xitem._Item._Registro.c_TipoTasa._ContenidoCampo
                                .c_TotalGeneral.c_Valor = 0 'xitem._Item._Registro._Total
                                .c_TotalNeto.c_Valor = 0 'xitem._Item._Registro._Importe
                                .c_UtilidadMonto.c_Valor = 0 'calculado
                                .c_UtilidadTasa.c_Valor = 0  ' calculado


                                Dim x0 As Decimal = xitem._Item._Registro._PrecioNeto
                                Dim x1 As Decimal = Decimal.Round(x0 * xitem._Item._Registro._CantidadDespachar, 2, MidpointRounding.AwayFromZero)
                                .c_TotalNeto.c_Valor = x1
                                Dim x2 As Decimal = Decimal.Round(x1 * xitem._Item._Registro._TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                                .c_MontoIva.c_Valor = x2
                                .c_TotalGeneral.c_Valor = Decimal.Round(x1 + x2, 2, MidpointRounding.AwayFromZero)
                                Dim x4 As Decimal = x0
                                x4 = Decimal.Round(x4 - (x4 * xventa._Encabezado._TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
                                x4 = Decimal.Round(x4 + (x4 * xventa._Encabezado._TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
                                .c_PrecioFinal.c_Valor = x4
                                .c_PrecioInventario.c_Valor = Decimal.Round(x4 / xitem._Item._Registro._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                                Dim x5 As Decimal = Decimal.Round(x4 * ._CantidadDespachada, 2, MidpointRounding.AwayFromZero)
                                Dim x6 As Decimal = Decimal.Round((xitem._Item._Producto._CostoCompra._Base_Inv * xitem._Item._Registro._ContenidoEmpaque) _
                                                                  * xitem._Item._Registro._CantidadDespachar, 2, MidpointRounding.AwayFromZero)

                                .c_UtilidadMonto.c_Valor = Decimal.Round(x5 - x6, 2, MidpointRounding.AwayFromZero)
                                If ._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    .c_UtilidadTasa.c_Valor = UtilidadBaseCosto(x6, ._UtilidadMonto)
                                Else
                                    .c_UtilidadTasa.c_Valor = UtilidadBasePrecioVenta(x5, ._UtilidadMonto)
                                End If

                                If ._UtilidadMonto >= 0 Then
                                Else
                                    Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO POR DEBAJO DEL COSTO" + vbCrLf + .c_NombreProducto.c_Texto)
                                End If

                                If xitem._Item._Producto._EstatusProducto = TipoEstatus.Activo Then
                                Else
                                    Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO POR INACTIVO" + vbCrLf + .c_NombreProducto.c_Texto)
                                End If

                            End With
                            xproductos.Add(xprdventa)
                        Next

                        'VERIFICO LIMITE DE DOCUMENTOS DEL CLIENTE / LIMITE DE CREDITO
                        If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Credito Then
                            Dim xcliente As New FichaClientes
                            xcliente.F_BuscarCliente(xventa._Encabezado._Cliente.r_Automatico)
                            If (xcliente.f_Clientes.RegistroDato.r_LimiteCreditoPermitido = 0) Or _
                               (xcliente.f_Clientes.RegistroDato.r_CreditoDisponible >= xventa._Encabezado._TotalGeneral) Then
                                If xcliente.f_Clientes.RegistroDato.r_CantDocPendPermitidos > 0 Then
                                    If (xcliente.f_Clientes.RegistroDato.r_CantidadDocPendientes + 1) > xcliente.f_Clientes.RegistroDato.r_CantDocPendPermitidos Then
                                        Throw New Exception("ERROR... CLIENTE SOBREPASA SU LIMITE DE DOCUMENTOS PENDIENTES DE CREDITO, VERIFIQUE")
                                    End If
                                End If
                            Else
                                Throw New Exception("ERROR... CLIENTE SOBREPASA SU LIMITE DE CREDITO, VERIFIQUE")
                            End If
                        End If

                        '
                        ' ARRANCA EL PROCEDIMIENTO DE GRABAR
                        '
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'ACTUALIZO CONTADOR AUTOMATICO DE VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_1
                                    xtb_venta.c_AutoDocumento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'ACTUALIZA CONTADOR AUTOMATICO CXC
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_2
                                    autocxc = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    If xmodo = ModoFactura.Legal Then
                                        'ACTUALIZA CORRELATIVO DE SERIES FISCALES
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql_3
                                        xcmd.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                                        xtb_venta.c_Documento.c_Texto = xventa._Encabezado._Serie + _
                                                         xcmd.ExecuteScalar().ToString.Trim.PadLeft(10 - xventa._Encabezado._Serie.Length, "0")
                                    Else
                                        'ACTUALIZA CORRELATIVO FACTURAS CHIMBA
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select a_chimbo from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update contadores set a_chimbo=0"
                                            xcmd.ExecuteNonQuery()
                                        End If
                                        xcmd.CommandText = "update CONTADORES set a_chimbo=a_chimbo+1;" _
                                             + "select a_chimbo from contadores"
                                        xtb_venta.c_Documento.c_Texto = "PED" + xcmd.ExecuteScalar().ToString.Trim.PadLeft(7, "0")
                                        xtb_venta.c_TipoDocumento.c_Texto = "XX"
                                    End If

                                    'VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaVentas.INSERT_VENTAS_POS
                                    xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto).Size = xtb_venta.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xtb_venta.c_Documento.c_Texto).Size = xtb_venta.c_Documento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xtb_venta.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xtb_venta.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nombre", xtb_venta.c_NombreCliente.c_Texto).Size = xtb_venta.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@dir_fiscal", xtb_venta.c_DirFiscalCliente.c_Texto).Size = xtb_venta.c_DirFiscalCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xtb_venta.c_CiRifCliente.c_Texto).Size = xtb_venta.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xtb_venta.c_TipoDocumento.c_Texto).Size = xtb_venta.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@exento", xtb_venta.c_Exento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base1", xtb_venta.c_Base1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base2", xtb_venta.c_Base2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base3", xtb_venta.c_Base3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto1", xtb_venta.c_Impuesto1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto2", xtb_venta.c_Impuesto2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto3", xtb_venta.c_Impuesto3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base", xtb_venta.c_Base.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto", xtb_venta.c_Impuesto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total", xtb_venta.c_TotalGeneral.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa1", xtb_venta.c_Tasa1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa2", xtb_venta.c_Tasa2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa3", xtb_venta.c_Tasa3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nota", xtb_venta.c_NotasDocumento.c_Texto).Size = xtb_venta.c_NotasDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xtb_venta.c_TasaRetencionIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xtb_venta.c_TasaRetencionISLR.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion_iva", xtb_venta.c_RetencionIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion_islr", xtb_venta.c_RetencionISLR.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xtb_venta.c_AutoCliente.c_Texto).Size = xtb_venta.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_entidad", xtb_venta.c_CodigoCliente.c_Texto).Size = xtb_venta.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@mes_relacion", xtb_venta.c_MesRelacion.c_Texto).Size = xtb_venta.c_MesRelacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@control", xtb_venta.c_ControlFiscal.c_Texto).Size = xtb_venta.c_ControlFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_relacion", xtb_venta.c_FechaRelacion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@orden_compra", xtb_venta.c_OrdenCompra.c_Texto).Size = xtb_venta.c_OrdenCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@dias", xtb_venta.c_DiasCreditoCliente.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1", xtb_venta.c_MontoDescuento_1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2", xtb_venta.c_MontoDescuento_2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cargos", xtb_venta.c_MontoCargo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xtb_venta.c_TasaDescuento_1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xtb_venta.c_TasaDescuento_2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cargos_porcentaje", xtb_venta.c_TasaCargos.c_Valor)
                                    xcmd.Parameters.AddWithValue("@columna", xtb_venta.c_TipoColumna.c_Texto).Size = xtb_venta.c_TipoColumna.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xtb_venta.c_EstatusDocumento.c_Texto).Size = xtb_venta.c_EstatusDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@aplica", xtb_venta.c_DocumentoAplica.c_Texto).Size = xtb_venta.c_DocumentoAplica.c_Largo
                                    xcmd.Parameters.AddWithValue("@comprobante_retencion", xtb_venta.c_ComprobanteRetencion.c_Texto).Size = xtb_venta.c_ComprobanteRetencion.c_Largo
                                    xcmd.Parameters.AddWithValue("@subtotal", xtb_venta.c_MontoSubTotal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@telefono", xtb_venta.c_TelefonoCliente.c_Texto).Size = xtb_venta.c_TelefonoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@factor_cambio", xtb_venta.c_FactorCambio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_vendedor", xtb_venta.c_CodigoVendedor.c_Texto).Size = xtb_venta.c_CodigoVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@vendedor", xtb_venta.c_NombreVendedor.c_Texto).Size = xtb_venta.c_NombreVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_vendedor", xtb_venta.c_AutoVendedor.c_Texto).Size = xtb_venta.c_AutoVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_pedido", xtb_venta.c_FechaPedido.c_Valor)
                                    xcmd.Parameters.AddWithValue("@pedido", xtb_venta.c_NumeroPedido.c_Texto).Size = xtb_venta.c_NumeroPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@condicion_pago", xtb_venta.c_CondicionPago.c_Texto).Size = xtb_venta.c_CondicionPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xtb_venta.c_Usuario.c_Texto).Size = xtb_venta.c_Usuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", xtb_venta.c_CodigoUsuario.c_Texto).Size = xtb_venta.c_CodigoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_sucursal", xtb_venta.c_CodigoSucursal.c_Texto).Size = xtb_venta.c_CodigoSucursal.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xtb_venta.c_Hora.c_Texto).Size = xtb_venta.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@transporte", xtb_venta.c_Transporte.c_Texto).Size = xtb_venta.c_Transporte.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_transporte", xtb_venta.c_CodigoTransporte.c_Texto).Size = xtb_venta.c_CodigoTransporte.c_Largo
                                    xcmd.Parameters.AddWithValue("@monto_divisa", xtb_venta.c_MontoDivisa.c_Valor)
                                    xcmd.Parameters.AddWithValue("@despachado", xtb_venta.c_NombreDespachador.c_Texto).Size = xtb_venta.c_NombreDespachador.c_Largo
                                    xcmd.Parameters.AddWithValue("@dir_despacho", xtb_venta.c_DirDespacho.c_Texto).Size = xtb_venta.c_DirDespacho.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xtb_venta.c_EstacionEquipo.c_Texto).Size = xtb_venta.c_EstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_recibo", xtb_venta.c_AutoRecibo.c_Texto).Size = xtb_venta.c_AutoRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@recibo", xtb_venta.c_NumeroRecibo.c_Texto).Size = xtb_venta.c_NumeroRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@renglones", xtb_venta.c_CantidadRenglones.c_Valor)
                                    xcmd.Parameters.AddWithValue("@saldo_pendiente", xtb_venta.c_MontoSaldoPendiente.c_Valor)
                                    xcmd.Parameters.AddWithValue("@ano_relacion", xtb_venta.c_AnoRelacion.c_Texto).Size = xtb_venta.c_AnoRelacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xtb_venta.c_ComprobanteRetencionISLR.c_Texto).Size = xtb_venta.c_ComprobanteRetencionISLR.c_Largo
                                    xcmd.Parameters.AddWithValue("@dias_validez", xtb_venta.c_ValidezDocumentoDias.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nrf", xtb_venta.c_SerialImpresoraFiscal.c_Texto).Size = xtb_venta.c_SerialImpresoraFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xtb_venta.c_AutoUsuario.c_Texto).Size = xtb_venta.c_AutoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_jornada", xtb_venta.c_AutomaticoJornada.c_Texto).Size = xtb_venta.c_AutomaticoJornada.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_operador", xtb_venta.c_AutomaticoOperador.c_Texto).Size = xtb_venta.c_AutomaticoOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@serie", xtb_venta.c_SerieAsignada.c_Texto).Size = xtb_venta.c_SerieAsignada.c_Largo
                                    xcmd.Parameters.AddWithValue("@serial", xtb_venta.c_SerialUnico_Jornada.c_Texto).Size = xtb_venta.c_SerialUnico_Jornada.c_Largo
                                    xcmd.Parameters.AddWithValue("@bloquear_almacen", xtb_venta.c_BloquearAlmacen.c_Texto).Size = xtb_venta.c_BloquearAlmacen.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen_documento", xtb_venta.c_OrigenDocumento.c_Texto).Size = xtb_venta.c_OrigenDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@rest_numero_mesapedido", xtb_venta.c_Rest_NumeroMesaPedido.c_Texto).Size = xtb_venta.c_Rest_NumeroMesaPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@rest_servicio_monto", xtb_venta.c_Rest_ServicioMonto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_servicio_tasa", xtb_venta.c_Rest_ServicioTasa.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_modo_mesapedido", xtb_venta.c_Rest_ModoMesaPedido.c_Texto).Size = xtb_venta.c_Rest_ModoMesaPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@relacion_z", xtb_venta.c_Relacion_Z.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'CXC, sea Contado / Credito
                                    Dim xcxc_doc_factura As New FichaCtasCobrar.c_CxC.c_Registro
                                    With xcxc_doc_factura
                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                        .c_AutoCxC.c_Texto = autocxc
                                        .c_AutoDocumento.c_Texto = xtb_venta.c_AutoDocumento.c_Texto
                                        .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                        .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                        .c_EstatusCancelado.c_Texto = "0"
                                        .c_EstatusDocumentoCxC.c_Texto = "0"
                                        .c_FechaProceso.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                        .c_FechaVencimiento.c_Valor = xtb_venta.c_FechaVencimiento.c_Valor
                                        .c_MontoAcumulado.c_Valor = 0
                                        .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_MontoPorCobrar.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_NombreAgencia.c_Texto = ""
                                        .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                        .c_NotasDetalles.c_Texto = "DOCUMENTO DE VENTA"
                                        .c_Numero.c_Texto = ""
                                        .c_NumeroDocumento.c_Texto = xtb_venta.c_Documento.c_Texto
                                        .c_TipoDocumento.c_Texto = "FAC"
                                        .c_TipoMovimiento.c_Valor = 1
                                        .c_TipoOperacion.c_Texto = ""
                                        .c_AutoMovimientoEntrada.c_Texto = ""
                                        .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasCobrar.INSERT_CXC
                                    xcmd.Parameters.AddWithValue("@auto", xcxc_doc_factura.c_AutoCxC.c_Texto).Size = xcxc_doc_factura.c_AutoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xcxc_doc_factura.c_FechaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo_documento", xcxc_doc_factura.c_TipoDocumento.c_Texto).Size = xcxc_doc_factura.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xcxc_doc_factura.c_NumeroDocumento.c_Texto).Size = xcxc_doc_factura.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc_doc_factura.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xcxc_doc_factura.c_NotasDetalles.c_Texto).Size = xcxc_doc_factura.c_NotasDetalles.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe", xcxc_doc_factura.c_MontoImporte.c_Valor)
                                    xcmd.Parameters.AddWithValue("@acumulado", xcxc_doc_factura.c_MontoAcumulado.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xcxc_doc_factura.c_AutoCliente.c_Texto).Size = xcxc_doc_factura.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cliente", xcxc_doc_factura.c_NombreCliente.c_Texto).Size = xcxc_doc_factura.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xcxc_doc_factura.c_CiRifCliente.c_Texto).Size = xcxc_doc_factura.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_cliente", xcxc_doc_factura.c_CodigoCliente.c_Texto).Size = xcxc_doc_factura.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cancelado", xcxc_doc_factura.c_EstatusCancelado.c_Texto).Size = xcxc_doc_factura.c_EstatusCancelado.c_Largo
                                    xcmd.Parameters.AddWithValue("@resta", xcxc_doc_factura.c_MontoPorCobrar.c_Valor)
                                    xcmd.Parameters.AddWithValue("@operacion", xcxc_doc_factura.c_TipoOperacion.c_Texto).Size = xcxc_doc_factura.c_TipoOperacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xcxc_doc_factura.c_EstatusDocumentoCxC.c_Texto).Size = xcxc_doc_factura.c_EstatusDocumentoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xcxc_doc_factura.c_AutoDocumento.c_Texto).Size = xcxc_doc_factura.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero", xcxc_doc_factura.c_Numero.c_Texto).Size = xcxc_doc_factura.c_Numero.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_agencia", xcxc_doc_factura.c_AutoAgencia.c_Texto).Size = xcxc_doc_factura.c_AutoAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@agencia", xcxc_doc_factura.c_NombreAgencia.c_Texto).Size = xcxc_doc_factura.c_NombreAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xcxc_doc_factura.c_TipoMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc_doc_factura.c_AutoMovimientoEntrada.c_Texto).Size = xcxc_doc_factura.c_AutoMovimientoEntrada.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_emision", xcxc_doc_factura.c_FechaEmision.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'BUSCAR EL CONCEPTO ADECUADO PARA EL TIPO DE DOCUMENTO
                                    Dim auto_concepto As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from productos_conceptos where codigo='VENTAS'"
                                    auto_concepto = xcmd.ExecuteScalar()
                                    If (auto_concepto Is Nothing) Or IsDBNull(auto_concepto) Then
                                        Throw New Exception("CONCEPTO 'VENTAS' NO ESTA DEFINIDO EN LA TABLA CONCEPTOS DE MOVIMIENTO DEL INVENTARIO")
                                    End If

                                    Dim xconcepto As String = ""
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select nombre from productos_conceptos where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", auto_concepto)
                                    xconcepto = xcmd.ExecuteScalar

                                    Dim xsalidaventa As New PlatoSalida.c_Registro
                                    'VENTAS_DETALLE PLATOS
                                    For Each xdt In xdetalles
                                        Dim xit As String = xdt._AutoItem

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = VentasDetalle_FastFood.INSERT_VENTASDETALLE_FASTFOOD
                                        xdt.c_AutoDocumento._ContenidoCampo = xtb_venta.c_AutoDocumento.c_Texto
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoCliente._NombreCampo, xdt._AutoCliente).Size = xdt.c_AutoCliente._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoDocumento._NombreCampo, xdt._AutoDocumento).Size = xdt.c_AutoDocumento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoGrupo._NombreCampo, xdt._AutoGrupo).Size = xdt.c_AutoGrupo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoItem._NombreCampo, xdt._AutoItem).Size = xdt.c_AutoItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoItemOrigen._NombreCampo, xdt._AutoItemOrigen).Size = xdt.c_AutoItemOrigen._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoJornada._NombreCampo, xdt._AutoJornada).Size = xdt.c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoOperador._NombreCampo, xdt._AutoOperador).Size = xdt.c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_AutoPlato._NombreCampo, xdt._AutoPlato).Size = xdt.c_AutoPlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_CantidadDespachada._NombreCampo, xdt._CantidadDespachada)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_CodigoPlato._NombreCampo, xdt._CodigoPlato).Size = xdt.c_CodigoPlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_CostoNeto._NombreCampo, xdt._CostoNeto)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_CostoTotalNeto._NombreCampo, xdt._CostoTotalNeto)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_EnOferta._NombreCampo, xdt.c_EnOferta._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_EsPesado._NombreCampo, xdt.c_EsPesado._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_Estatus._NombreCampo, xdt.c_Estatus._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_FechaEmision._NombreCampo, xdt._FechaEmision)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_MontoIva._NombreCampo, xdt._MontoImpuesto)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_NombrePlato._NombreCampo, xdt._NombrePlato)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_NotasItem._NombreCampo, xdt._NotasItem)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_PrecioFinal._NombreCampo, xdt._PrecioFinal._Base)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_PrecioNeto._NombreCampo, xdt._PrecioNeto._Base)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_SignoDocumento._NombreCampo, xdt._Signo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TasaIva._NombreCampo, xdt._TasaIva)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TipoCalculoUtilidad._NombreCampo, xdt.c_TipoCalculoUtilidad._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TipoDocumento._NombreCampo, xdt.c_TipoDocumento._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TipoItem._NombreCampo, xdt.c_TipoItem._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TipoMovimiento._NombreCampo, xdt.c_TipoMovimiento._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TipoTasaIva._NombreCampo, xdt.c_TipoTasaIva._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TotalGeneral._NombreCampo, xdt._TotalGeneral)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_TotalNeto._NombreCampo, xdt._TotalNeto)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_UtilidadMonto._NombreCampo, xdt._UtilidadMonto)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_UtilidadTasa._NombreCampo, xdt._UtilidadTasa)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_EsCombo._NombreCampo, xdt._EsCombo)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_AutoMesonero._NombreCampo, xdt._Rest_AutoMesonero)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_CodigoMesonero._NombreCampo, xdt._Rest_CodigoMesonero)
                                        xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_NombreMesonero._NombreCampo, xdt._Rest_NombreMesonero)
                                        xcmd.ExecuteNonQuery()

                                        Dim xlist_h = From s In xhistorial Where s.c_AutoItem._ContenidoCampo = xit
                                        For Each xcomanda In xlist_h
                                            xcomanda.c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                            xcomanda.c_Documento._ContenidoCampo = xtb_venta.c_Documento.c_Texto

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select a_historialcomandas_fastfood from contadores"
                                            If IsDBNull(xcmd.ExecuteScalar()) Then
                                                xcmd.CommandText = "update contadores set a_historialcomandas_fastfood=0"
                                                xcmd.ExecuteScalar()
                                            End If
                                            xcmd.CommandText = xsql_4
                                            xcomanda.c_Auto._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = HistorialComandas_FastFood.INSERT_HISTORIALCOMANDAS_FASTFOOD
                                            With xcmd.Parameters
                                                .AddWithValue("@" + xcomanda.c_Auto._NombreCampo, xcomanda.c_Auto._ContenidoCampo).Size = xcomanda.c_Auto._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoDocumento._NombreCampo, xcomanda.c_AutoDocumento._ContenidoCampo).Size = xcomanda.c_AutoDocumento._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoEstacion._NombreCampo, xcomanda.c_AutoEstacion._ContenidoCampo).Size = xcomanda.c_AutoEstacion._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoItem._NombreCampo, xcomanda.c_AutoItem._ContenidoCampo).Size = xcomanda.c_AutoItem._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoJornada._NombreCampo, xcomanda.c_AutoJornada._ContenidoCampo).Size = xcomanda.c_AutoJornada._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoOperador._NombreCampo, xcomanda.c_AutoOperador._ContenidoCampo).Size = xcomanda.c_AutoOperador._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_AutoPlato._NombreCampo, xcomanda.c_AutoPlato._ContenidoCampo).Size = xcomanda.c_AutoPlato._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_Cantidad._NombreCampo, xcomanda.c_Cantidad._ContenidoCampo)
                                                .AddWithValue("@" + xcomanda.c_Documento._NombreCampo, xcomanda.c_Documento._ContenidoCampo).Size = xcomanda.c_Documento._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_EstatusEstacionEnvio._NombreCampo, xcomanda.c_EstatusEstacionEnvio._ContenidoCampo).Size = xcomanda.c_EstatusEstacionEnvio._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_EstatusPlatoEnvio._NombreCampo, xcomanda.c_EstatusPlatoEnvio._ContenidoCampo).Size = xcomanda.c_EstatusPlatoEnvio._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_FechaProceso._NombreCampo, xcomanda.c_FechaProceso._ContenidoCampo)
                                                .AddWithValue("@" + xcomanda.c_NombreEstacion._NombreCampo, xcomanda.c_NombreEstacion._ContenidoCampo).Size = xcomanda.c_NombreEstacion._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_NombrePlato._NombreCampo, xcomanda.c_NombrePlato._ContenidoCampo).Size = xcomanda.c_NombrePlato._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_NombreUsuario._NombreCampo, xcomanda.c_NombreUsuario._ContenidoCampo).Size = xcomanda.c_NombreUsuario._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_NotasDetalle._NombreCampo, xcomanda.c_NotasDetalle._ContenidoCampo).Size = xcomanda.c_NotasDetalle._LargoCampo
                                                .AddWithValue("@" + xcomanda.c_RutaEstacion._NombreCampo, xcomanda.c_RutaEstacion._ContenidoCampo).Size = xcomanda.c_RutaEstacion._LargoCampo
                                            End With
                                            xcmd.ExecuteNonQuery()
                                        Next

                                        'SI ES UN COMBO, DEVUELVE LOS PLATOS QUE INTEGRAN EL COMBO CON SU RESPECTIVA CANTIDAD
                                        If xdt._EsCombo Then
                                            Dim xtb_plat As New DataTable
                                            Dim xreader As SqlDataReader
                                            Dim xsql As String = _
                                            "select mp.auto a_plato ,mp.nombre_plato n_plato ,mc.cantidad ,mp.auto_grupo a_grupo, g.nombre_grupo n_grupo " & _
                                            "from MenuCombos_FastFood mc join MenuPlatos_FastFood mp on mc.auto_plato=mp.auto " & _
                                            "join Grupo_FastFood g on mp.auto_grupo=g.auto where mc.auto_plato_combo=@autocombo"

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = xsql
                                            xcmd.Parameters.AddWithValue("@autocombo", xdt._AutoPlato)
                                            xreader = xcmd.ExecuteReader()
                                            xtb_plat.Load(xreader)

                                            For Each xrp As DataRow In xtb_plat.Rows
                                                With xsalidaventa
                                                    .M_Limpiar()

                                                    .c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                                    .c_AutoGrupo._ContenidoCampo = xrp("a_grupo")
                                                    .c_AutoItem._ContenidoCampo = xdt._AutoItem
                                                    .c_AutoPlato._ContenidoCampo = xrp("a_plato")
                                                    .c_CantidadRequerida._ContenidoCampo = xrp("cantidad")
                                                    .c_Documento._ContenidoCampo = xtb_venta._Documento
                                                    .c_FechaProceso._ContenidoCampo = xdt._FechaEmision
                                                    .c_NombreGrupo._ContenidoCampo = xrp("n_grupo")
                                                    .c_NombrePlato._ContenidoCampo = xrp("n_plato")
                                                    .c_Signo._ContenidoCampo = 1
                                                    .c_CantidadTotal._ContenidoCampo = xdt._CantidadDespachada * xrp("cantidad")
                                                    .c_Estatus._ContenidoCampo = "0"
                                                End With

                                                With xsalidaventa
                                                    xcmd.Parameters.Clear()
                                                    xcmd.CommandText = PlatoSalida.InsertRegistro
                                                    xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_AutoGrupo._NombreCampo, ._AutoGrupo).Size = .c_AutoGrupo._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_AutoPlato._NombreCampo, ._AutoPlato).Size = .c_AutoPlato._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_CantidadRequerida._NombreCampo, ._CantidadRequerida)
                                                    xcmd.Parameters.AddWithValue("@" + .c_CantidadTotal._NombreCampo, ._CantidadTotal)
                                                    xcmd.Parameters.AddWithValue("@" + .c_Documento._NombreCampo, ._Documento).Size = .c_Documento._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_FechaProceso._NombreCampo, ._FechaProceso)
                                                    xcmd.Parameters.AddWithValue("@" + .c_NombreGrupo._NombreCampo, ._NombreGrupo).Size = .c_NombreGrupo._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_NombrePlato._NombreCampo, ._NombrePlato).Size = .c_NombrePlato._LargoCampo
                                                    xcmd.Parameters.AddWithValue("@" + .c_Signo._NombreCampo, ._Signo)
                                                    xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo).Size = .c_Estatus._LargoCampo

                                                    xcmd.ExecuteNonQuery()
                                                End With
                                            Next
                                        Else
                                            With xsalidaventa
                                                .M_Limpiar()

                                                .c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                                .c_AutoGrupo._ContenidoCampo = xdt._AutoGrupo
                                                .c_AutoItem._ContenidoCampo = xdt._AutoItem
                                                .c_AutoPlato._ContenidoCampo = xdt._AutoPlato
                                                .c_Documento._ContenidoCampo = xtb_venta._Documento
                                                .c_FechaProceso._ContenidoCampo = xdt._FechaEmision
                                                .c_NombreGrupo._ContenidoCampo = xdt._NombreGrupo
                                                .c_NombrePlato._ContenidoCampo = xdt._NombrePlato
                                                .c_Signo._ContenidoCampo = 1
                                                .c_CantidadRequerida._ContenidoCampo = 1
                                                .c_CantidadTotal._ContenidoCampo = xdt._CantidadDespachada
                                                .c_Estatus._ContenidoCampo = "0"

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = PlatoSalida.InsertRegistro
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoGrupo._NombreCampo, ._AutoGrupo).Size = .c_AutoGrupo._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoPlato._NombreCampo, ._AutoPlato).Size = .c_AutoPlato._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_CantidadRequerida._NombreCampo, ._CantidadRequerida)
                                                xcmd.Parameters.AddWithValue("@" + .c_CantidadTotal._NombreCampo, ._CantidadTotal)
                                                xcmd.Parameters.AddWithValue("@" + .c_Documento._NombreCampo, ._Documento).Size = .c_Documento._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_FechaProceso._NombreCampo, ._FechaProceso)
                                                xcmd.Parameters.AddWithValue("@" + .c_NombreGrupo._NombreCampo, ._NombreGrupo).Size = .c_NombreGrupo._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_NombrePlato._NombreCampo, ._NombrePlato).Size = .c_NombrePlato._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_Signo._NombreCampo, ._Signo)
                                                xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo).Size = .c_Estatus._LargoCampo
                                                xcmd.ExecuteNonQuery()
                                            End With
                                        End If

                                        'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                        Dim dr As DataRow = xtablaprd.NewRow
                                        dr("cantidad") = xdt._CantidadDespachada
                                        dr("nombre") = xdt._NombrePlato
                                        dr("codigo") = xdt._CodigoPlato
                                        dr("precio_neto") = xdt._PrecioNeto._Base
                                        dr("codigo_tasa") = xdt.c_TipoTasaIva._ContenidoCampo
                                        xtablaprd.Rows.Add(dr)
                                    Next

                                    'REALIZAR EL KARDEX DE LOS PLATOS QUE TOCAN INVENTARIO
                                    For Each xinv As FichaProducto.Prd_Kardex.c_Registro In xlistakardex

                                        'DESCONTAR DE INVENTARIO 
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaVentas.VENTAS_UPDATE_PRODUCTOS_DEPOSITO
                                        xcmd.Parameters.AddWithValue("@auto_producto", xinv._AutoProducto)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xinv._AutoDeposito)
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xinv._CantidadUnidadesMover)
                                        xcmd.ExecuteNonQuery()

                                        'CAMPOS PENDIENTES POR LLENAR
                                        With xinv
                                            .c_AutoConcepto.c_Texto = auto_concepto
                                            .c_AutoDocumento.c_Texto = xtb_venta._AutoDocumento
                                            .c_Documento.c_Texto = xtb_venta._Documento
                                            .c_NombreConcepto.c_Texto = xconcepto
                                        End With
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                        xcmd.Parameters.AddWithValue("@auto_producto", xinv.c_AutoProducto.c_Texto).Size = xinv.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xinv.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xinv.c_AutoDeposito.c_Texto).Size = xinv.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad", xinv.c_CantidadMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_concepto", xinv.c_AutoConcepto.c_Texto).Size = xinv.c_AutoConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@entidad", xinv.c_Entidad.c_Texto).Size = xinv.c_Entidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@documento", xinv.c_Documento.c_Texto).Size = xinv.c_Documento.c_Largo
                                        xcmd.Parameters.AddWithValue("@medida_empaque", xinv.c_ReferenciaEmpaque.c_Texto).Size = xinv.c_ReferenciaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@signo", xinv.c_TipoMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xinv.c_CantidadUnidadesMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus", xinv.c_Estatus.c_Texto).Size = xinv.c_Estatus.c_Largo
                                        xcmd.Parameters.AddWithValue("@origen", xinv.c_OrigenMovimiento.c_Texto).Size = xinv.c_OrigenMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_documento", xinv.c_AutoDocumento.c_Texto).Size = xinv.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xinv.c_NotasDetallesMovimiento.c_Texto).Size = xinv.c_NotasDetallesMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreproducto", xinv.c_NombreProducto.c_Texto).Size = xinv.c_NombreProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombredeposito", xinv.c_NombreDeposito.c_Texto).Size = xinv.c_NombreDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreconcepto", xinv.c_NombreConcepto.c_Texto).Size = xinv.c_NombreConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xinv.c_NombreMedidaEmpaque.c_Texto).Size = xinv.c_NombreMedidaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_automedida", xinv.c_AutoMedida.c_Texto).Size = xinv.c_AutoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xinv.c_ContenidoMedidaEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@n_codigoproducto", xinv.c_CodigoProducto.c_Texto).Size = xinv.c_CodigoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigodeposito", xinv.c_CodigoDeposito.c_Texto).Size = xinv.c_CodigoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigoconcepto", xinv.c_CodigoConcepto.c_Texto).Size = xinv.c_CodigoConcepto.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        Dim xventainventario As New FastFood.VentaInventario.c_Registro
                                        With xventainventario
                                            .c_AutoDocumentoVenta._ContenidoCampo = xtb_venta._AutoDocumento
                                            .c_AutoItemVenta._ContenidoCampo = xinv._FastFood_ItemVenta
                                            .c_AutoMedEmpaq._ContenidoCampo = xinv.c_AutoMedida.c_Texto
                                            .c_AutoProducto._ContenidoCampo = xinv.c_AutoProducto.c_Texto
                                            .c_Cantidad_Requerida_Descontar._ContenidoCampo = xinv._FastFood_CantidadRequerida
                                            .c_ContEmpaque._ContenidoCampo = xinv.c_ContenidoMedidaEmpaque.c_Valor
                                            .c_AutoDeposito._ContenidoCampo = xinv._AutoDeposito
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FastFood.VentaInventario.Insert
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoDocumentoVenta._NombreCampo, xventainventario._AutoDocumentoVenta).Size = xventainventario.c_AutoDocumentoVenta._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoItemVenta._NombreCampo, xventainventario._AutoItemVenta).Size = xventainventario.c_AutoItemVenta._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoMedEmpaq._NombreCampo, xventainventario._AutoMedEmpaq).Size = xventainventario.c_AutoMedEmpaq._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoProducto._NombreCampo, xventainventario._AutoProducto).Size = xventainventario.c_AutoProducto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_Cantidad_Requerida_Descontar._NombreCampo, xventainventario._Cantidad_Requerida_Descontar)
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_ContEmpaque._NombreCampo, xventainventario._ContenidoEmpaque)
                                        xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoDeposito._NombreCampo, xventainventario._AutoDeposito).Size = xventainventario.c_AutoDeposito._LargoCampo
                                        xcmd.ExecuteNonQuery()
                                    Next


                                    'VENTAS_DETALLE PRODUCTOS
                                    For Each xprdvt In xproductos
                                        xprdvt.c_AutoDocumento.c_Texto = xtb_venta._AutoDocumento

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaVentas.INSERT_VENTAS_DETALLE_POS
                                        xcmd.Parameters.AddWithValue("@auto_documento", xprdvt.c_AutoDocumento.c_Texto).Size = xprdvt.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_productos", xprdvt.c_AutoProducto.c_Texto).Size = xprdvt.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo", xprdvt.c_CodigoProducto.c_Texto).Size = xprdvt.c_CodigoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombre", xprdvt.c_NombreProducto.c_Texto).Size = xprdvt.c_NombreProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_departamento", xprdvt.c_AutoDepartamento.c_Texto).Size = xprdvt.c_AutoDepartamento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_grupo", xprdvt.c_AutoGrupo.c_Texto).Size = xprdvt.c_AutoGrupo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_subgrupo", xprdvt.c_AutoSubGrupo.c_Texto).Size = xprdvt.c_AutoSubGrupo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xprdvt.c_AutoDeposito.c_Texto).Size = xprdvt.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad", xprdvt.c_CantidadDespachada.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xprdvt.c_NombreEmpaque.c_Texto).Size = xprdvt.c_NombreEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@descuento1p", xprdvt.c_DescuentoTasa_1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuento2p", xprdvt.c_DescuentoTasa_2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuento3p", xprdvt.c_DescuentoTasa_3.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuento1", xprdvt.c_DescuentoMonto_1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuento2", xprdvt.c_DescuentoMonto_2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuento3", xprdvt.c_DescuentoMonto_3.c_Valor)
                                        xcmd.Parameters.AddWithValue("@total_neto", xprdvt.c_TotalNeto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@tasa", xprdvt.c_TasaIva.c_Valor)
                                        xcmd.Parameters.AddWithValue("@impuesto", xprdvt.c_MontoIva.c_Valor)
                                        xcmd.Parameters.AddWithValue("@total", xprdvt.c_TotalGeneral.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto", xprdvt.c_AutoItem.c_Texto).Size = xprdvt.c_AutoItem.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo_tasa", xprdvt.c_TipoTasaIva.c_Texto).Size = xprdvt.c_TipoTasaIva.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus", xprdvt.c_Estatus.c_Texto).Size = xprdvt.c_Estatus.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xprdvt.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@tipo", xprdvt.c_TipoDocumento.c_Texto).Size = xprdvt.c_TipoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@deposito", xprdvt.c_NombreDeposito.c_Texto).Size = xprdvt.c_NombreDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@signo", xprdvt.c_SignoDocumento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_entidad", xprdvt.c_AutoCliente.c_Texto).Size = xprdvt.c_AutoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@decimales", xprdvt.c_NumeroDecimales.c_Valor)
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xprdvt.c_ContenidoEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xprdvt.c_CantidadUnidadInventario.c_Valor)
                                        xcmd.Parameters.AddWithValue("@costo_inventario", xprdvt.c_CostoInventario.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_neto", xprdvt.c_PrecioNeto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@costo_venta", xprdvt.c_CostoVenta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_final", xprdvt.c_PrecioFinal.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_inventario", xprdvt.c_PrecioInventario.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidad", xprdvt.c_UtilidadMonto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidadp", xprdvt.c_UtilidadTasa.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_item", xprdvt.c_PrecioItem.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus_garantia", xprdvt.c_EstatusGarantia.c_Texto).Size = xprdvt.c_EstatusGarantia.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus_serial", xprdvt.c_EstatusSerial.c_Texto).Size = xprdvt.c_EstatusSerial.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo_deposito", xprdvt.c_CodigoDeposito.c_Texto).Size = xprdvt.c_CodigoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@dias_garantia", xprdvt.c_DiasGarantia.c_Valor)
                                        xcmd.Parameters.AddWithValue("@detalle", xprdvt.c_DetalleNotas.c_Texto).Size = xprdvt.c_DetalleNotas.c_Largo
                                        xcmd.Parameters.AddWithValue("@psv", xprdvt.c_PrecioSugerido.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque_tipo", xprdvt.c_ReferenciaEmpaque.c_Texto).Size = xprdvt.c_ReferenciaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus_corte", xprdvt.c_EstatusCorte.c_Texto).Size = xprdvt.c_EstatusCorte.c_Largo
                                        xcmd.Parameters.AddWithValue("@x", xprdvt.c_Corte_X.c_Valor)
                                        xcmd.Parameters.AddWithValue("@y", xprdvt.c_Corte_Y.c_Valor)
                                        xcmd.Parameters.AddWithValue("@z", xprdvt.c_Corte_Z.c_Valor)
                                        xcmd.Parameters.AddWithValue("@corte", xprdvt.c_Corte.c_Texto).Size = xprdvt.c_Corte.c_Largo
                                        xcmd.Parameters.AddWithValue("@categoria", xprdvt.c_CategoriaProducto.c_Texto).Size = xprdvt.c_CategoriaProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_esoferta", xprdvt.c_PTO_EstaEnOferta.c_Texto).Size = xprdvt.c_PTO_EstaEnOferta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_espesado", xprdvt.c_PTO_EsPesado.c_Texto).Size = xprdvt.c_PTO_EsPesado.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_codigobarra", xprdvt.c_PTO_CodigoBarra.c_Texto)
                                        xcmd.Parameters.AddWithValue("@N_plu", xprdvt.c_PTO_Plu.c_Texto).Size = xprdvt.c_PTO_Plu.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_formato", xprdvt.c_PTO_FormatoEtiqueta.c_Texto).Size = xprdvt.c_PTO_FormatoEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_depart", xprdvt.c_PTO_NumeroDepartEtiqueta.c_Texto).Size = xprdvt.c_PTO_NumeroDepartEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_seccion", xprdvt.c_PTO_SeccionEtiqueta.c_Texto).Size = xprdvt.c_PTO_SeccionEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_vendedor", xprdvt.c_PTO_VendedorEtiqueta.c_Texto).Size = xprdvt.c_PTO_VendedorEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_plu", xprdvt.c_PTO_PluEtiqueta.c_Texto).Size = xprdvt.c_PTO_PluEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_peso", xprdvt.c_PTO_PesoEtiqueta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@N_etiq_precio", xprdvt.c_PTO_PrecioEtiqueta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@N_etiq_control", xprdvt.c_PTO_NumeroControlEtiqueta.c_Texto).Size = xprdvt.c_PTO_NumeroControlEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_digitos", xprdvt.c_PTO_DigitosEtiqueta.c_Texto).Size = xprdvt.c_PTO_DigitosEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_ticket", xprdvt.c_PTO_NumeroTicketEtiqueta.c_Texto).Size = xprdvt.c_PTO_NumeroTicketEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_numbalanza", xprdvt.c_PTO_NumeroBalanzaEtiqueta.c_Texto).Size = xprdvt.c_PTO_NumeroBalanzaEtiqueta.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_etiq_montoitem", xprdvt.c_PTO_MontoTotalEtiqueta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@N_etiq_numitem", xprdvt.c_PTO_NumeroItemEtiqueta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@N_auto_jornada", xprdvt.c_PTO_AutoJornada.c_Texto).Size = xprdvt.c_PTO_AutoJornada.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_auto_operador", xprdvt.c_PTO_AutoOperador.c_Texto).Size = xprdvt.c_PTO_AutoOperador.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_automedida", xprdvt.c_AutoMedida.c_Texto).Size = xprdvt.c_AutoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_forzarmedida", xprdvt.c_ForzarMedida.c_Texto).Size = xprdvt.c_ForzarMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_TipoCalculoUtilidad", xprdvt.c_TipoCalculoUtilidad.c_Texto).Size = xprdvt.c_TipoCalculoUtilidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@N_TipoMovimiento", xprdvt.c_TipoMovimiento.c_Texto).Size = xprdvt.c_TipoMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_auto_item_origen", xprdvt.c_AutoItemOrigen.c_Texto).Size = xprdvt.c_AutoItemOrigen.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombre_corto", xprdvt.c_NombreCortoProducto.c_Texto).Size = xprdvt.c_NombreCortoProducto.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaVentas.VENTAS_UPDATE_PRODUCTOS_DEPOSITO
                                        xcmd.Parameters.AddWithValue("@auto_producto", xprdvt.c_AutoProducto.c_Texto).Size = xprdvt.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xprdvt.c_AutoDeposito.c_Texto).Size = xprdvt.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xprdvt.c_CantidadUnidadInventario.c_Valor)
                                        xcmd.ExecuteNonQuery()

                                        'PRODUCTOS_KARDEX
                                        Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                                        With xkardex
                                            .c_AutoConcepto.c_Texto = auto_concepto
                                            .c_AutoDeposito.c_Texto = xprdvt.c_AutoDeposito.c_Texto
                                            .c_AutoDocumento.c_Texto = xtb_venta._AutoDocumento
                                            .c_AutoProducto.c_Texto = xprdvt.c_AutoProducto.c_Texto
                                            .c_CantidadMover.c_Valor = xprdvt.c_CantidadDespachada.c_Valor
                                            .c_CantidadUnidadesMover.c_Valor = xprdvt.c_CantidadUnidadInventario.c_Valor
                                            .c_Documento.c_Texto = xtb_venta._Documento
                                            .c_Entidad.c_Texto = xtb_venta._NombreCliente
                                            .c_Estatus.c_Texto = xtb_venta.c_EstatusDocumento.c_Texto
                                            .c_FechaEmision.c_Valor = xtb_venta._FechaEmision
                                            .c_NotasDetallesMovimiento.c_Texto = ""
                                            .c_OrigenMovimiento.c_Texto = "0801"
                                            .c_ReferenciaEmpaque.c_Texto = xprdvt.c_ReferenciaEmpaque.c_Texto
                                            .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Salida
                                            .c_NombreProducto.c_Texto = xprdvt.c_NombreProducto.c_Texto.Trim
                                            .c_NombreDeposito.c_Texto = xprdvt.c_NombreDeposito.c_Texto.Trim
                                            .c_NombreConcepto.c_Texto = xconcepto
                                            .c_NombreMedidaEmpaque.c_Texto = xprdvt.c_NombreEmpaque.c_Texto.Trim
                                            .c_AutoMedida.c_Texto = xprdvt.c_AutoMedida.c_Texto.Trim
                                            .c_ContenidoMedidaEmpaque.c_Valor = xprdvt.c_ContenidoEmpaque.c_Valor
                                            .c_CodigoProducto.c_Texto = xprdvt._CodigoProducto
                                            .c_CodigoDeposito.c_Texto = xprdvt._CodigoDeposito
                                            .c_CodigoConcepto.c_Texto = "VENTAS"
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                        xcmd.Parameters.AddWithValue("@auto_producto", xkardex.c_AutoProducto.c_Texto).Size = xkardex.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xkardex.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xkardex.c_AutoDeposito.c_Texto).Size = xkardex.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad", xkardex.c_CantidadMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_concepto", xkardex.c_AutoConcepto.c_Texto).Size = xkardex.c_AutoConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@entidad", xkardex.c_Entidad.c_Texto).Size = xkardex.c_Entidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@documento", xkardex.c_Documento.c_Texto).Size = xkardex.c_Documento.c_Largo
                                        xcmd.Parameters.AddWithValue("@medida_empaque", xkardex.c_ReferenciaEmpaque.c_Texto).Size = xkardex.c_ReferenciaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@signo", xkardex.c_TipoMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xkardex.c_CantidadUnidadesMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus", xkardex.c_Estatus.c_Texto).Size = xkardex.c_Estatus.c_Largo
                                        xcmd.Parameters.AddWithValue("@origen", xkardex.c_OrigenMovimiento.c_Texto).Size = xkardex.c_OrigenMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_documento", xkardex.c_AutoDocumento.c_Texto).Size = xkardex.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xkardex.c_NotasDetallesMovimiento.c_Texto).Size = xkardex.c_NotasDetallesMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreproducto", xkardex.c_NombreProducto.c_Texto).Size = xkardex.c_NombreProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombredeposito", xkardex.c_NombreDeposito.c_Texto).Size = xkardex.c_NombreDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreconcepto", xkardex.c_NombreConcepto.c_Texto).Size = xkardex.c_NombreConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xkardex.c_NombreMedidaEmpaque.c_Texto).Size = xkardex.c_NombreMedidaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_automedida", xkardex.c_AutoMedida.c_Texto).Size = xkardex.c_AutoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xkardex.c_ContenidoMedidaEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@n_codigoproducto", xkardex.c_CodigoProducto.c_Texto).Size = xkardex.c_CodigoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigodeposito", xkardex.c_CodigoDeposito.c_Texto).Size = xkardex.c_CodigoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigoconcepto", xkardex.c_CodigoConcepto.c_Texto).Size = xkardex.c_CodigoConcepto.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                        Dim dr As DataRow = xtablaprd.NewRow
                                        dr("cantidad") = xprdvt.c_CantidadDespachada.c_Valor
                                        dr("nombre") = xprdvt.c_NombreProducto.c_Texto.Trim
                                        dr("codigo") = xprdvt.c_CodigoProducto.c_Texto.Trim
                                        dr("precio_neto") = xprdvt.c_PrecioNeto.c_Valor
                                        dr("codigo_tasa") = xprdvt._TipoTasaIva
                                        xtablaprd.Rows.Add(dr)
                                    Next


                                    'FACTURA CONTADO
                                    If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado Then
                                        Dim autocxc_pago As String = ""
                                        Dim autocxc_recibopago As String = ""
                                        Dim autocxc_numerorecibopago As String = ""

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores SET a_cxc=a_cxc+1;select a_cxc from contadores"
                                        autocxc_pago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_cxc_recibos=a_cxc_recibos+1;select a_cxc_recibos from contadores"
                                        autocxc_recibopago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_cxc_recibos_numero=a_cxc_recibos_numero+1;select a_cxc_recibos_numero from contadores"
                                        autocxc_numerorecibopago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        'CXC, sea Contado / Credito
                                        Dim xcxc_doc_pago As New FichaCtasCobrar.c_CxC.c_Registro
                                        xcxc_doc_pago.LimpiarRegistro()
                                        With xcxc_doc_pago
                                            .c_AutoAgencia.c_Texto = ""
                                            .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                            .c_AutoCxC.c_Texto = autocxc_pago
                                            .c_AutoDocumento.c_Texto = ""
                                            .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                            .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                            .c_EstatusCancelado.c_Texto = ""
                                            .c_EstatusDocumentoCxC.c_Texto = "0"
                                            .c_FechaProceso.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                            .c_FechaVencimiento.c_Valor = xtb_venta.c_FechaVencimiento.c_Valor
                                            .c_MontoAcumulado.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_MontoPorCobrar.c_Valor = 0
                                            .c_NombreAgencia.c_Texto = ""
                                            .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                            .c_NotasDetalles.c_Texto = ""
                                            .c_Numero.c_Texto = ""
                                            .c_NumeroDocumento.c_Texto = autocxc_numerorecibopago
                                            .c_TipoDocumento.c_Texto = "PAG"
                                            .c_TipoMovimiento.c_Valor = -1
                                            .c_TipoOperacion.c_Texto = ""
                                            .c_AutoMovimientoEntrada.c_Texto = ""
                                            .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaCtasCobrar.INSERT_CXC
                                        xcmd.Parameters.AddWithValue("@auto", xcxc_doc_pago.c_AutoCxC.c_Texto).Size = xcxc_doc_pago.c_AutoCxC.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xcxc_doc_pago.c_FechaProceso.c_Valor)
                                        xcmd.Parameters.AddWithValue("@tipo_documento", xcxc_doc_pago.c_TipoDocumento.c_Texto).Size = xcxc_doc_pago.c_TipoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@documento", xcxc_doc_pago.c_NumeroDocumento.c_Texto).Size = xcxc_doc_pago.c_NumeroDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc_doc_pago.c_FechaVencimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@detalle", xcxc_doc_pago.c_NotasDetalles.c_Texto).Size = xcxc_doc_pago.c_NotasDetalles.c_Largo
                                        xcmd.Parameters.AddWithValue("@importe", xcxc_doc_pago.c_MontoImporte.c_Valor)
                                        xcmd.Parameters.AddWithValue("@acumulado", xcxc_doc_pago.c_MontoAcumulado.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_cliente", xcxc_doc_pago.c_AutoCliente.c_Texto).Size = xcxc_doc_pago.c_AutoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@cliente", xcxc_doc_pago.c_NombreCliente.c_Texto).Size = xcxc_doc_pago.c_NombreCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@ci_rif", xcxc_doc_pago.c_CiRifCliente.c_Texto).Size = xcxc_doc_pago.c_CiRifCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo_cliente", xcxc_doc_pago.c_CodigoCliente.c_Texto).Size = xcxc_doc_pago.c_CodigoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@cancelado", xcxc_doc_pago.c_EstatusCancelado.c_Texto).Size = xcxc_doc_pago.c_EstatusCancelado.c_Largo
                                        xcmd.Parameters.AddWithValue("@resta", xcxc_doc_pago.c_MontoPorCobrar.c_Valor)
                                        xcmd.Parameters.AddWithValue("@operacion", xcxc_doc_pago.c_TipoOperacion.c_Texto).Size = xcxc_doc_pago.c_TipoOperacion.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus", xcxc_doc_pago.c_EstatusDocumentoCxC.c_Texto).Size = xcxc_doc_pago.c_EstatusDocumentoCxC.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_documento", xcxc_doc_pago.c_AutoDocumento.c_Texto).Size = xcxc_doc_pago.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@numero", xcxc_doc_pago.c_Numero.c_Texto).Size = xcxc_doc_pago.c_Numero.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_agencia", xcxc_doc_pago.c_AutoAgencia.c_Texto).Size = xcxc_doc_pago.c_AutoAgencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@agencia", xcxc_doc_pago.c_NombreAgencia.c_Texto).Size = xcxc_doc_pago.c_NombreAgencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@signo", xcxc_doc_pago.c_TipoMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc_doc_factura.c_AutoMovimientoEntrada.c_Texto).Size = xcxc_doc_factura.c_AutoMovimientoEntrada.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha_emision", xcxc_doc_factura.c_FechaEmision.c_Valor)
                                        xcmd.ExecuteNonQuery()

                                        'CXC_RECIBOS
                                        Dim xrecibo As New FichaCtasCobrar.c_Recibos.c_Registro
                                        With xrecibo
                                            .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                            .c_AutoCobrador.c_Texto = xventa._Encabezado._Cobrador.r_Automatico
                                            .c_AutoRecibo.c_Texto = autocxc_recibopago
                                            .c_AutoUsuario.c_Texto = xtb_venta.c_AutoUsuario.c_Texto
                                            .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                            .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                            .c_DirFiscalCliente.c_Texto = xtb_venta.c_DirFiscalCliente.c_Texto
                                            .c_EstatusRecibo.c_Texto = "0"
                                            .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                            .c_MontoAnticipo.c_Valor = 0
                                            .c_MontoDescuento.c_Valor = 0
                                            .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_MontoImporteDocumento.c_Valor = 0
                                            .c_MontoTotalDocumento.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                            .c_NombreCobrador.c_Texto = xventa._Encabezado._Cobrador.r_NombreCobrador
                                            .c_NombreUsuario.c_Texto = xtb_venta.c_Usuario.c_Texto
                                            .c_NotasDetalles.c_Texto = ""
                                            .c_NumeroRecibo.c_Texto = autocxc_numerorecibopago
                                            .c_TelefonoCliente.c_Texto = xtb_venta.c_TelefonoCliente.c_Texto
                                            .c_CantidadDocumentosRelacionados.c_Valor = 1
                                            .c_CantNCPagadas.c_Valor = 0
                                            .c_MontoNCPagadas.c_Valor = 0
                                            .c_AutoCxcPago.c_Texto = autocxc_pago
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaCtasCobrar._INSERT_CXC_RECIBOS
                                        xcmd.Parameters.AddWithValue("@auto", xrecibo.c_AutoRecibo.c_Texto).Size = xrecibo.c_AutoRecibo.c_Largo
                                        xcmd.Parameters.AddWithValue("@numero", xrecibo.c_NumeroRecibo.c_Texto).Size = xrecibo.c_NumeroRecibo.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xrecibo.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xrecibo.c_AutoUsuario.c_Texto).Size = xrecibo.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@importe", xrecibo.c_MontoImporte.c_Valor)
                                        xcmd.Parameters.AddWithValue("@usuario", xrecibo.c_NombreUsuario.c_Texto).Size = xrecibo.c_NombreUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@importe_documentos", xrecibo.c_MontoImporteDocumento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@descuentos", xrecibo.c_MontoDescuento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@total_documentos", xrecibo.c_MontoTotalDocumento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@detalle", xrecibo.c_NotasDetalles.c_Texto).Size = xrecibo.c_NotasDetalles.c_Largo
                                        xcmd.Parameters.AddWithValue("@cobrador", xrecibo.c_NombreCobrador.c_Texto).Size = xrecibo.c_NombreCobrador.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_cliente", xrecibo.c_AutoCliente.c_Texto).Size = xrecibo.c_AutoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombre_cliente", xrecibo.c_NombreCliente.c_Texto).Size = xrecibo.c_NombreCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@ci_rif_cliente", xrecibo.c_CiRifCliente.c_Texto).Size = xrecibo.c_CiRifCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo_cliente", xrecibo.c_CodigoCliente.c_Texto).Size = xrecibo.c_CodigoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus", xrecibo.c_EstatusRecibo.c_Texto).Size = xrecibo.c_EstatusRecibo.c_Largo
                                        xcmd.Parameters.AddWithValue("@direccion", xrecibo.c_DirFiscalCliente.c_Texto).Size = xrecibo.c_DirFiscalCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@telefono", xrecibo.c_TelefonoCliente.c_Texto).Size = xrecibo.c_TelefonoCliente.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_cobrador", xrecibo.c_AutoCobrador.c_Texto).Size = xrecibo.c_AutoCobrador.c_Largo
                                        xcmd.Parameters.AddWithValue("@anticipos", xrecibo.c_MontoAnticipo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cant_doc_rel", xrecibo.c_CantidadDocumentosRelacionados.c_Valor)
                                        'campos nuevos
                                        xcmd.Parameters.AddWithValue("@monto_nc_pagadas", xrecibo.c_MontoNCPagadas.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cant_nc_pagadas", xrecibo.c_CantNCPagadas.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_cxc", xrecibo.c_AutoCxcPago.c_Texto)
                                        xcmd.ExecuteNonQuery()

                                        'VENTAS
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "UPDATE VENTAS SET " _
                                          + "recibo=@recibo, auto_recibo=@auto_recibo where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto)
                                        xcmd.Parameters.AddWithValue("@auto_recibo", autocxc_recibopago)
                                        xcmd.Parameters.AddWithValue("@recibo", autocxc_numerorecibopago)
                                        xcmd.ExecuteNonQuery()

                                        'CXC_DOCUMENTOS
                                        Dim xdoc As New FichaCtasCobrar.c_Documentos.c_Registro
                                        With xdoc
                                            .c_AutoCxC.c_Texto = autocxc
                                            .c_AutoCxCPago.c_Texto = autocxc_pago
                                            .c_AutoCxCRecibo.c_Texto = xrecibo.c_AutoRecibo.c_Texto
                                            .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                            .c_Item.c_Valor = 1
                                            .c_Monto.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_NotasDetalles.c_Texto = ""
                                            .c_NumeroDocumento.c_Texto = xtb_venta.c_Documento.c_Texto
                                            .c_NumeroRecibo.c_Texto = autocxc_numerorecibopago
                                            .c_OrigenDocumento.c_Texto = "FACTURA"
                                            .c_TipoDocumento.c_Texto = "PAG"
                                            .c_TipoOperacion.c_Texto = "Cancelación"
                                            .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                            .c_SignoDocumento.c_Valor = 1
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaCtasCobrar.INSERT_CXC_DOCUMENTOS
                                        xcmd.Parameters.AddWithValue("@item", xdoc.c_Item.c_Valor)
                                        xcmd.Parameters.AddWithValue("@operacion", xdoc.c_TipoOperacion.c_Texto).Size = xdoc.c_TipoOperacion.c_Largo
                                        xcmd.Parameters.AddWithValue("@monto", xdoc.c_Monto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_cxc", xdoc.c_AutoCxC.c_Texto).Size = xdoc.c_AutoCxC.c_Largo
                                        xcmd.Parameters.AddWithValue("@documento", xdoc.c_NumeroDocumento.c_Texto).Size = xdoc.c_NumeroDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_cxc_pago", xdoc.c_AutoCxCPago.c_Texto).Size = xdoc.c_AutoCxCPago.c_Largo
                                        xcmd.Parameters.AddWithValue("@tipo", xdoc.c_TipoDocumento.c_Texto).Size = xdoc.c_TipoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xdoc.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@detalle", xdoc.c_NotasDetalles.c_Texto).Size = xdoc.c_NotasDetalles.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_cxc_recibo", xdoc.c_AutoCxCRecibo.c_Texto).Size = xdoc.c_AutoCxCRecibo.c_Largo
                                        xcmd.Parameters.AddWithValue("@numero_recibo", xdoc.c_NumeroRecibo.c_Texto).Size = xdoc.c_NumeroDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@origen", xdoc.c_OrigenDocumento.c_Texto).Size = xdoc.c_OrigenDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@monto_pendiente", xdoc.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                        'campos nuevo
                                        xcmd.Parameters.AddWithValue("@signo", xdoc.c_SignoDocumento.c_Valor)
                                        xcmd.ExecuteNonQuery()

                                        'CXC_MODO_PAGO()
                                        Dim xmodopago As New FichaCtasCobrar.c_ModosPago.c_Registro
                                        For Each xregpag In xventa._TablaModosPago.Rows
                                            With xmodopago
                                                .LimpiarRegistro()

                                                .c_AutoAgencia.c_Texto = xregpag(0)
                                                .c_AutoRecibo.c_Texto = xrecibo.c_AutoRecibo.c_Texto
                                                .c_AutoTipoPago.c_Texto = xregpag(4)
                                                .c_CodigoTipoPago.c_Texto = xregpag(6)
                                                .c_EstatusMovimiento.c_Texto = "0"
                                                .c_FechaEmision.c_Valor = xtb_venta._FechaEmision
                                                .c_MontoImporte.c_Valor = xregpag(3)
                                                .c_MontoRecibido.c_Valor = xregpag(7)
                                                .c_NombreAgencia.c_Texto = xregpag(1)
                                                .c_NombreTipoPago.c_Texto = xregpag(5)
                                                .c_Numero.c_Texto = xregpag(2)
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaCtasCobrar.INSERT_CXC_MODO_PAGO
                                            xcmd.Parameters.AddWithValue("@numero", xmodopago.c_Numero.c_Texto).Size = xmodopago.c_Numero.c_Largo
                                            xcmd.Parameters.AddWithValue("@agencia", xmodopago.c_NombreAgencia.c_Texto).Size = xmodopago.c_NombreAgencia.c_Largo
                                            xcmd.Parameters.AddWithValue("@importe", xmodopago.c_MontoImporte.c_Valor)
                                            xcmd.Parameters.AddWithValue("@codigo", xmodopago.c_CodigoTipoPago.c_Texto).Size = xmodopago.c_CodigoTipoPago.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_recibo", xmodopago.c_AutoRecibo.c_Texto).Size = xmodopago.c_AutoRecibo.c_Largo
                                            xcmd.Parameters.AddWithValue("@nombre", xmodopago.c_NombreTipoPago.c_Texto).Size = xmodopago.c_NombreTipoPago.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_medios_pago", xmodopago.c_AutoTipoPago.c_Texto).Size = xmodopago.c_AutoTipoPago.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_agencia", xmodopago.c_AutoAgencia.c_Texto).Size = xmodopago.c_AutoAgencia.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", xmodopago.c_FechaEmision.c_Valor)
                                            xcmd.Parameters.AddWithValue("@estatus", xmodopago.c_EstatusMovimiento.c_Texto).Size = xmodopago.c_EstatusMovimiento.c_Largo
                                            xcmd.Parameters.AddWithValue("@monto_recibido", xmodopago.c_MontoRecibido.c_Valor)
                                            xcmd.ExecuteNonQuery()
                                        Next

                                        'DOCUMENTO FACTURA EN CXC :> PAGADO COMPLETO
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update cxc set cancelado = '1', acumulado = importe, resta = 0 where auto = @auto"
                                        xcmd.Parameters.AddWithValue("@auto", xcxc_doc_factura.c_AutoCxC.c_Texto).Size = xcxc_doc_factura.c_AutoCxC.c_Largo
                                        xcmd.ExecuteNonQuery()
                                    End If


                                    'VENTAS_MEDIDAS
                                    Dim x = From n In xproductos _
                                            Select n._AutoMedida, n._CantidadDespachada, n._NumeroDecimales, n._NombreEmpaque _
                                            Group By _AutoMedida, _NumeroDecimales, _NombreEmpaque Into Sum(_CantidadDespachada)

                                    Dim xmedida As New FichaVentas.V_VentasMedida.c_Registro
                                    For Each xmed In x
                                        xmedida.M_LimpiarRegistro()

                                        With xmedida
                                            .c_AutoDocumento.c_Texto = xtb_venta._AutoDocumento
                                            .c_AutoMedida.c_Texto = xmed._AutoMedida
                                            .c_CantidadEmpaques.c_Valor = xmed.Sum
                                            .c_DecimalesEmpaque.c_Texto = xmed._NumeroDecimales
                                            .c_NombreEmpaque.c_Texto = xmed._NombreEmpaque
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaVentas.INSERT_VENTAS_MEDIDA
                                        xcmd.Parameters.AddWithValue("@auto_documento", xmedida.c_AutoDocumento.c_Texto).Size = xmedida.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_medida", xmedida.c_AutoMedida.c_Texto).Size = xmedida.c_AutoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@total_medida", xmedida.c_CantidadEmpaques.c_Valor)
                                        xcmd.Parameters.AddWithValue("@decimales", xmedida.c_DecimalesEmpaque.c_Texto).Size = xmedida.c_DecimalesEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombre", xmedida.c_NombreEmpaque.c_Texto).Size = xmedida.c_NombreEmpaque.c_Largo
                                        xcmd.ExecuteNonQuery()
                                    Next


                                    Dim t_debito As Single = 0
                                    Dim t_credito As Single = 0
                                    Dim t_saldo As Single = 0

                                    'BUSCA LOS SALDOS PARA EL CLIENTE
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                    t_debito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                    t_credito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                    t_saldo = xcmd.ExecuteScalar()

                                    'CLIENTES
                                    Dim xr_cliente As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "UPDATE CLIENTES SET " _
                                      + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                      + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo, " _
                                      + "fecha_ult_compra=@fecha_ult_compra where auto=@auto and estatus='Activo'"
                                    xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                    xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                    xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                    xcmd.Parameters.AddWithValue("@fecha_ult_compra", xtb_venta.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoCliente.c_Texto)
                                    xr_cliente = xcmd.ExecuteNonQuery()
                                    If xr_cliente = 0 Then
                                        Throw New Exception("VERIFICAR CLIENTE, AL PARECER FUE EILIMINADO / CAMBIO DE ESTATUS")
                                    End If

                                    'TABLA(TEMPORALVENTA)
                                    For Each xdr In xventa._Detalles
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete temporalventa_notasplato_fastfood where auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_item", xdr._Item._Registro._AutoItem)
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete temporalventa_fastfood where auto_item=@auto_item"
                                        xcmd.Parameters.AddWithValue("@auto_item", xdr._Item._Registro._AutoItem)
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    Dim xcontrol As Integer = 0
                                    Dim xcont As String = ""
                                    Dim xz As Integer = 0

                                    If impfiscal IsNot Nothing Then
                                        Integer.TryParse(impfiscal.Ver_UltimaFacturaRegistrada, xcontrol)
                                        xcontrol += 1
                                        xcont = xcontrol.ToString.Trim.PadLeft(10, "0")
                                        Integer.TryParse(impfiscal.Ver_UltimoZFiscal, xz)
                                        xz += 1
                                    End If

                                    'VENTAS. PARA ACTUALIZAR EL # DE CONTROL  DEL DOCUMENTO
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update ventas set control = @control, relacion_z=@relacion_z where auto = @auto"
                                    xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto).Size = xtb_venta.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@control", xcont).Size = xtb_venta.c_ControlFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@relacion_z", xz)
                                    xcmd.ExecuteNonQuery()

                                    If xmodo = ModoFactura.Legal Then
                                        With impfiscal
                                            .FacturaInicializa(xtb_venta.c_Tasa1.c_Valor, _
                                                               xtb_venta.c_Tasa2.c_Valor, _
                                                               xtb_venta.c_Tasa3.c_Valor)

                                            .Cli_CondicionVenta = xtb_venta.c_CondicionPago.c_Texto.Trim
                                            .Cli_DirCliente = xtb_venta.c_DirFiscalCliente.c_Texto.Trim
                                            .Cli_EstacionVenta = xtb_venta.c_EstacionEquipo.c_Texto.Trim
                                            .Cli_FacturaVenta = xtb_venta.c_Documento.c_Texto.Trim
                                            .Cli_NomCliente = xtb_venta.c_NombreCliente.c_Texto.Trim
                                            .Cli_RifCliente = xtb_venta.c_CiRifCliente.c_Texto.Trim
                                            .Cli_TelCliente = xtb_venta.c_TelefonoCliente.c_Texto.Trim
                                            .Cli_UsuarioVenta = xtb_venta.c_Usuario.c_Texto.Trim
                                            .AutoDocumento = xtb_venta._AutoDocumento
                                            .Cli_DocumentoVenta = xtb_venta._Documento

                                            .CargoGlobal = xtb_venta.c_TasaCargos.c_Valor
                                            .DsctoGlobal = xtb_venta.c_TasaDescuento_1.c_Valor
                                        End With

                                        Dim xmontorecibe As Decimal = 0
                                        If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado Then
                                            xmontorecibe = xventa._Encabezado._TotalGeneral
                                        End If
                                        If xventa._Encabezado._TotalGeneral > 0 Then
                                            'ImprimeFactura(impfiscal, xtablaprd, xmontorecibe, xventa._Encabezado._TotalGeneral, xpagos)
                                            ImprimeFactura_3(impfiscal, xtablaprd, xmontorecibe, xventa._Encabezado._TotalGeneral, xpagos)
                                        Else
                                            Throw New Exception("NO SE PUEDE GENERAR UNA FACTURA FISCAL DE MONTO CERO (0)")
                                        End If
                                    End If

                                    xtr.Commit()
                                End Using
                                Dim xr As Decimal = xventa._MontoRecibido - xtb_venta._TotalGenereal

                                RaiseEvent _FacturaGrabadaOk()
                                If xmodo = ModoFactura.Chimba Then
                                    RaiseEvent _ImprimirFacturaChimba(xtb_venta._AutoDocumento)
                                End If
                                RaiseEvent _ImprimirComanda(xtb_venta._AutoDocumento)
                                RaiseEvent _ImprimirCopiaFactura(xtb_venta._AutoDocumento)
                                RaiseEvent _VisorCambioDar(xr)

                                Return True
                            Catch xsql As SqlException
                                xtr.Rollback()
                                If xsql.Number = 2601 Then
                                    Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO Y SERIE, VERIFIQUE")
                                ElseIf xsql.Number = 547 Then
                                    Throw New Exception("ERROR... AL PARECER EL CLIENTE / VENDEDOR SELECCIONADO FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE")
                                Else
                                    Throw New Exception(xsql.Message + vbCrLf + "ERROR NUMERO: " + xsql.Number.ToString)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("VENTAS" + vbCrLf + "ERROR AL GRABAR VENTA:" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function ImprimeFactura_3(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal, ByVal formasPago As List(Of FormaPago)) As Boolean
                    Try
                        xfiscal.FacturaEncabezado()
                        For Each dr As DataRow In xtablaprd.Rows
                            xfiscal.LimpiarItem()
                            xfiscal.Prd_CantidadPrd = dr("cantidad")
                            xfiscal.Prd_DetallePrd = dr("nombre")
                            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                            xfiscal.Prd_Empaque = ""
                            xfiscal.Prd_Codigo = ""
                            xfiscal.FacturaDetalle()
                        Next

                        xfiscal.MedioPago_1 = xmonto_recibe + 1
                        xfiscal.FacturaCerrar()
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                    End Try
                    Return True
                End Function


                Function ImprimeFactura_2(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal, ByVal formasPago As List(Of FormaPago)) As Boolean
                    Try
                        Dim fiscal As LibFoxFiscal.LibFoxFiscal.IFiscal
                        fiscal = New LibFoxFiscal.LibFoxFiscal.Fiscal
                        fiscal.SetPuerto(4)
                        Dim encabezado = New LibFoxFiscal.LibFoxFiscal.Factura
                        With encabezado
                            .CargoGlobal = xfiscal.CargoGlobal
                            .CiRif = xfiscal.Cli_RifCliente
                            .CondicionPago = xfiscal.Cli_CondicionVenta
                            .Direccion = xfiscal.Cli_DirCliente
                            .DsctoGlobal = xfiscal.DsctoGlobal
                            .Estacion = xfiscal.Cli_EstacionVenta
                            .NombreRazonSocial = xfiscal.Cli_NomCliente
                            .Telefono = xfiscal.Cli_TelCliente
                            .Total = xtotalfactura
                            .Usuario = xfiscal.Cli_UsuarioOperador
                        End With

                        Dim detalles As List(Of LibFoxFiscal.LibFoxFiscal.IFacturaDetalles) = New List(Of LibFoxFiscal.LibFoxFiscal.IFacturaDetalles)
                        For Each dt In xtablaprd.Rows
                            Dim tasa As Integer? = Nothing
                            If dt("codigo_tasa") = "1" Then
                                tasa = 1
                            End If
                            If dt("codigo_tasa") = "2" Then
                                tasa = 2
                            End If
                            If dt("codigo_tasa") = "3" Then
                                tasa = 3
                            End If
                            Dim detalle = New LibFoxFiscal.LibFoxFiscal.FacturaDetalles
                            With detalle
                                .Cantidad = dt("cantidad")
                                .Cargo = 0
                                .Codigo = ""
                                .Descripcion = dt("nombre")
                                .Dscto = 0
                                .Precio = dt("precio_neto")
                                .Tasa = tasa
                            End With
                            detalles.Add(detalle)
                        Next
                        encabezado.Detalles = detalles

                        Dim pagos As List(Of LibFoxFiscal.LibFoxFiscal.IFacturaMedioPago) = New List(Of LibFoxFiscal.LibFoxFiscal.IFacturaMedioPago)
                        Dim pago = New LibFoxFiscal.LibFoxFiscal.FacturaMedioPago
                        With pago
                            .Monto = xmonto_recibe
                            .Posicion = 1
                        End With
                        pagos.Add(pago)
                        encabezado.MediosPago = pagos

                        Dim r01 = fiscal.Factura(encabezado)
                        If r01.Resultado = LibFoxFiscal.Resultado.EnumResultado.ERROR Then
                            Throw New Exception(r01.MensajeError)
                        End If

                        Return True
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                    End Try
                    Return True
                End Function



                Function ImprimeFactura(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal, ByVal formasPago As List(Of FormaPago)) As Boolean
                    'If TypeOf (xfiscal) Is ImpFiscales.MisFiscales.HKA112 Then
                    '    Dim xlib As New [Lib].Provider.HKA112(xfiscal.PuertoConexion, [Lib].IFiscal.ModelosFiscales.HKA112)
                    '    xlib.FacturaInicializa(12, 8, 21)

                    '    Try
                    '        With xlib
                    '            .Cli_NomCliente = xfiscal.Cli_NomCliente
                    '            .Cli_RifCliente = xfiscal.Cli_RifCliente
                    '            .Cli_CondicionVenta = xfiscal.Cli_CondicionVenta
                    '            .Cli_DirCliente = xfiscal.Cli_DirCliente
                    '            .Cli_TelCliente = xfiscal.Cli_TelCliente
                    '            .Cli_UsuarioVenta = xfiscal.Cli_UsuarioVenta
                    '            .Cli_DocumentoVenta = xfiscal.Cli_DocumentoVenta
                    '            .Cli_EstacionVenta = xfiscal.Cli_EstacionVenta
                    '            .Cli_FacturaVenta = xfiscal.Cli_FacturaVenta
                    '            .Cli_LineaEncabezado1 = xfiscal.Cli_LineaEncabezado1
                    '            .AutoDocumento = xfiscal.AutoDocumento
                    '            .CargoGlobal = xfiscal.CargoGlobal
                    '            .DsctoGlobal = xfiscal.DsctoGlobal
                    '        End With

                    '        xlib.FacturaEncabezado()
                    '        For Each dr As DataRow In xtablaprd.Rows
                    '            xlib.LimpiarItem()
                    '            xlib.Prd_CantidadPrd = dr("cantidad")
                    '            xlib.Prd_DetallePrd = dr("nombre")
                    '            xlib.Prd_PNetoPrd = dr("precio_neto")
                    '            xlib.Prd_TasaIvaPrd = dr("codigo_tasa")
                    '            xlib.Prd_Empaque = ""
                    '            xlib.Prd_Codigo = ""
                    '            xlib.FacturaDetalle()
                    '        Next
                    '        If xmonto_recibe >= xtotalfactura Then
                    '            xlib.MedioPago_1 = xmonto_recibe
                    '        Else
                    '            xlib.MedioPago_7 = xtotalfactura
                    '        End If
                    '        xlib.FacturaCerrar()
                    '        Return True
                    '    Catch ex As Exception
                    '        Try
                    '            xlib.AbortarDF()
                    '        Catch ex2 As Exception
                    '        End Try
                    '        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                    '    End Try

                    'Else
                    '    Try
                    '        xfiscal.FacturaEncabezado()
                    '        For Each dr As DataRow In xtablaprd.Rows
                    '            xfiscal.LimpiarItem()
                    '            xfiscal.Prd_CantidadPrd = dr("cantidad")
                    '            xfiscal.Prd_DetallePrd = dr("nombre")
                    '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                    '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                    '            xfiscal.Prd_Empaque = ""
                    '            xfiscal.Prd_Codigo = ""
                    '            xfiscal.FacturaDetalle()
                    '        Next

                    '        If xmonto_recibe >= xtotalfactura Then
                    '            xfiscal.MedioPago_1 = xmonto_recibe
                    '        Else
                    '            xfiscal.MedioPago_7 = xtotalfactura
                    '        End If
                    '        xfiscal.FacturaCerrar()
                    '        Return True
                    '    Catch ex As Exception
                    '        Try
                    '            xfiscal.AbortarDF()
                    '        Catch ex2 As Exception
                    '        End Try
                    '        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                    '    End Try
                    'End If

                    Try
                        xfiscal.FacturaEncabezado()
                        For Each dr As DataRow In xtablaprd.Rows
                            xfiscal.LimpiarItem()
                            xfiscal.Prd_CantidadPrd = dr("cantidad")
                            xfiscal.Prd_DetallePrd = dr("nombre")
                            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                            xfiscal.Prd_Empaque = ""
                            xfiscal.Prd_Codigo = ""
                            xfiscal.FacturaDetalle()
                        Next

                        'If xmonto_recibe >= xtotalfactura Then
                        '    xfiscal.MedioPago_1 = xmonto_recibe
                        'Else
                        '    xfiscal.MedioPago_7 = xtotalfactura
                        'End If

                        If xmonto_recibe >= xtotalfactura Then
                            For Each met As FormaPago In formasPago
                                Select Case met.Tipo
                                    Case FormaPago.TipoPago.EfectivoTickets
                                        xfiscal.MedioPago_1 = met.Monto
                                    Case FormaPago.TipoPago.Cheque
                                        xfiscal.MedioPago_2 = met.Monto
                                    Case FormaPago.TipoPago.TDebito
                                        xfiscal.MedioPago_3 = met.Monto
                                    Case FormaPago.TipoPago.TCredito
                                        xfiscal.MedioPago_4 = met.Monto
                                    Case FormaPago.TipoPago.Otros
                                        xfiscal.MedioPago_5 = met.Monto
                                End Select
                            Next
                            'xfiscal.MedioPago_1 = xmonto_recibe
                        Else
                            xfiscal.MedioPago_7 = xtotalfactura
                        End If

                        xfiscal.FacturaCerrar()
                        Return True
                    Catch ex As Exception
                        Try
                            xfiscal.AbortarDF()
                        Catch ex2 As Exception
                        End Try
                        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                    End Try
                    Return True
                End Function


                'Function ImprimeFactura(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal) As Boolean
                '    Try
                '        xfiscal.FacturaEncabezado()

                '        For Each dr As DataRow In xtablaprd.Rows
                '            xfiscal.LimpiarItem()
                '            xfiscal.Prd_CantidadPrd = dr("cantidad")
                '            xfiscal.Prd_DetallePrd = dr("nombre")
                '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                '            xfiscal.FacturaDetalle()
                '        Next

                '        If xmonto_recibe >= xtotalfactura Then
                '            xfiscal.MedioPago_1 = xtotalfactura
                '        Else
                '            xfiscal.MedioPago_7 = xtotalfactura
                '        End If

                '        xfiscal.FacturaCerrar()
                '        Return True
                '    Catch ex As Exception
                '        Try
                '            xfiscal.AbortarDF()
                '        Catch ex2 As Exception
                '        End Try
                '        Throw New Exception("ERROR AL IMPRIMIR FACTURA FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                '    End Try
                'End Function

                Public Class AgregarNotaCredito
                    Class ItemsNC_Plato
                        Private xitem As VentasDetalle_FastFood.c_Registro
                        Private xcantidad_devolver As Decimal

                        Property _ItemDetalle() As VentasDetalle_FastFood.c_Registro
                            Get
                                Return xitem
                            End Get
                            Set(ByVal value As VentasDetalle_FastFood.c_Registro)
                                xitem = value
                            End Set
                        End Property

                        Property _CantidadDevolver() As Decimal
                            Get
                                Return xcantidad_devolver
                            End Get
                            Set(ByVal value As Decimal)
                                xcantidad_devolver = value
                            End Set
                        End Property

                        Sub New()
                            _ItemDetalle = Nothing
                            _CantidadDevolver = 0
                        End Sub
                    End Class
                    Class ItemsNC_Producto
                        Private xitem As FichaVentas.V_VentasDetalle.c_Registro
                        Private xcantidad_devolver As Decimal

                        Property _ItemDetalle() As FichaVentas.V_VentasDetalle.c_Registro
                            Get
                                Return xitem
                            End Get
                            Set(ByVal value As FichaVentas.V_VentasDetalle.c_Registro)
                                xitem = value
                            End Set
                        End Property

                        Property _CantidadDevolver() As Decimal
                            Get
                                Return xcantidad_devolver
                            End Get
                            Set(ByVal value As Decimal)
                                xcantidad_devolver = value
                            End Set
                        End Property

                        Sub New()
                            _ItemDetalle = Nothing
                            _CantidadDevolver = 0
                        End Sub
                    End Class


                    Private xfactura_afecta As FichaVentas.V_Ventas.c_Registro
                    Private xlista_Platos As List(Of ItemsNC_Plato)
                    Private xlista_Productos As List(Of ItemsNC_Producto)
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xmontobase1 As Decimal
                    Private xmontobase2 As Decimal
                    Private xmontobase3 As Decimal
                    Private xmontoexento As Decimal
                    Private xmotivo As String
                    Private xserie As String
                    Private xsucursal As String
                    Private xjornada As FastFood.Jornada.c_Registro
                    Private xoperador As FastFood.OperadorJornada.c_Registro


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

                    Property _EquipoEstacionMovimiento() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _MontoBase_1() As Decimal
                        Get
                            Return xmontobase1
                        End Get
                        Set(ByVal value As Decimal)
                            xmontobase1 = value
                        End Set
                    End Property

                    Property _MontoBase_2() As Decimal
                        Get
                            Return xmontobase2
                        End Get
                        Set(ByVal value As Decimal)
                            xmontobase2 = value
                        End Set
                    End Property

                    Property _MontoBase_3() As Decimal
                        Get
                            Return xmontobase3
                        End Get
                        Set(ByVal value As Decimal)
                            xmontobase3 = value
                        End Set
                    End Property

                    Property _MontoExento() As Decimal
                        Get
                            Return xmontoexento
                        End Get
                        Set(ByVal value As Decimal)
                            xmontoexento = value
                        End Set
                    End Property

                    Property _MotivoNC() As String
                        Get
                            Return xmotivo
                        End Get
                        Set(ByVal value As String)
                            xmotivo = value
                        End Set
                    End Property

                    Property _SerieFiscalAsignadaParaNC() As String
                        Get
                            Return xserie
                        End Get
                        Set(ByVal value As String)
                            xserie = value
                        End Set
                    End Property

                    Property _CodigoSucrusal() As String
                        Get
                            Return xsucursal
                        End Get
                        Set(ByVal value As String)
                            xsucursal = value
                        End Set
                    End Property

                    Property _FacturaAfecta() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Return xfactura_afecta
                        End Get
                        Set(ByVal value As FichaVentas.V_Ventas.c_Registro)
                            xfactura_afecta = value
                        End Set
                    End Property

                    Property _ListaItemsDevolver_Platos() As List(Of ItemsNC_Plato)
                        Get
                            Return xlista_Platos
                        End Get
                        Set(ByVal value As List(Of ItemsNC_Plato))
                            xlista_Platos = value
                        End Set
                    End Property

                    Property _ListaItemsDevolver_Productos() As List(Of ItemsNC_Producto)
                        Get
                            Return xlista_Productos
                        End Get
                        Set(ByVal value As List(Of ItemsNC_Producto))
                            xlista_Productos = value
                        End Set
                    End Property

                    Property _UsuarioMovimiento() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaMovimiento() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _HoraMovimiento() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _CantidadRenglones() As Integer
                        Get
                            Dim x As Integer = 0
                            If _ListaItemsDevolver_Platos Is Nothing Then
                                x = 0
                            Else
                                x = _ListaItemsDevolver_Platos.Count
                            End If

                            If _ListaItemsDevolver_Productos Is Nothing Then
                                x += 0
                            Else
                                x += _ListaItemsDevolver_Productos.Count
                            End If

                            Return x
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _SubTotal() As Decimal
                        Get
                            Return Decimal.Round(_MontoBase_1 + _MontoBase_2 + _MontoBase_3 + _MontoExento, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Sub New()
                        Me._CodigoSucrusal = ""
                        Me._EquipoEstacionMovimiento = ""
                        Me._FacturaAfecta = Nothing
                        Me._ListaItemsDevolver_Platos = New List(Of ItemsNC_Plato)
                        Me._ListaItemsDevolver_Productos = New List(Of ItemsNC_Producto)
                        Me._MontoBase_1 = 0
                        Me._MontoBase_2 = 0
                        Me._MontoBase_3 = 0
                        Me._MontoExento = 0
                        Me._MotivoNC = ""
                        Me._SerieFiscalAsignadaParaNC = ""
                        Me._UsuarioMovimiento = Nothing
                        Me._Operador = Nothing
                        Me._Jornada = Nothing
                    End Sub
                End Class

                Function F_GrabarNotaCreditoFastFood(ByVal xdata As AgregarNotaCredito, _
                                        ByVal ximpresora As IFiscal) As Boolean

                    Dim xsql_1 As String = "update contadores set a_ventas=a_ventas+1; select a_ventas from contadores"
                    Dim xsql_2 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                    Dim xsql_3 As String = "update series_fiscales set correlativo=correlativo+1, estatus_fiscal='1' where nombre=@nombre;" _
                                          + "select correlativo from series_fiscales where nombre=@nombre"

                    Dim autocxc As String = ""
                    Dim xventa As FichaVentas.V_Ventas

                    'Tabla Usada Para Lista De Productos Para La Impresora Fiscal
                    Dim xtablaprd As New DataTable
                    With xtablaprd
                        .Columns.Add("cantidad", GetType(System.Decimal))
                        .Columns.Add("nombre", GetType(System.String))
                        .Columns.Add("precio_neto", GetType(System.Decimal))
                        .Columns.Add("codigo_tasa", GetType(System.String))
                        .Columns.Add("detalle", GetType(System.String))
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Dim xfiscal As New FichaGlobal.c_SeriesFiscales
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from series_fiscales where nombre=@nombre", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@nombre", xdata._SerieFiscalAsignadaParaNC)
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count > 0 Then
                            xfiscal.M_CargarFicha(xtb(0))
                        Else
                            Throw New Exception("ERROR... SERIE NO REGISTRADA, VERIFIQUE")
                        End If

                        If xfiscal.RegistroDato.r_SerialFiscal <> ximpresora.Ver_SerialImpresoraFiscal Then
                            Throw New Exception("ERROR... SERIAL FISCAL NO COINCIDE CON EL SERIAL DE LA IMPRESORA A GENERAR DOCUMENTO, VERIFIQUE")
                        End If

                        If xfiscal.RegistroDato.r_EstatusSerie = TipoEstatus.Activo Then
                            If xfiscal.RegistroDato.r_EstatusParaNC = TipoEstatus.Activo Then
                            Else
                                Throw New Exception("ERROR... SERIE NO ASIGNADA PARA EFECTUAR NOTAS DE CREDITO, VERIFIQUE")
                            End If
                        Else
                            Throw New Exception("ERROR... SERIE ESTA EN ESTADO INACTVIO, VERIFIQUE")
                        End If

                        xventa = New FichaVentas.V_Ventas
                        With xventa.RegistroDato
                            .c_AutoCliente.c_Texto = xdata._FacturaAfecta._AutoCliente
                            .c_AutoVendedor.c_Texto = xdata._FacturaAfecta.c_AutoVendedor.c_Texto
                            .c_CiRifCliente.c_Texto = xdata._FacturaAfecta.c_CiRifCliente.c_Texto
                            .c_CodigoCliente.c_Texto = xdata._FacturaAfecta.c_CodigoCliente.c_Texto
                            .c_CodigoVendedor.c_Texto = xdata._FacturaAfecta.c_CodigoVendedor.c_Texto
                            .c_DirDespacho.c_Texto = xdata._FacturaAfecta.c_DirDespacho.c_Texto
                            .c_DirFiscalCliente.c_Texto = xdata._FacturaAfecta.c_DirFiscalCliente.c_Texto
                            .c_FactorCambio.c_Valor = xdata._FacturaAfecta.c_FactorCambio.c_Valor
                            .c_NombreCliente.c_Texto = xdata._FacturaAfecta.c_NombreCliente.c_Texto
                            .c_NombreVendedor.c_Texto = xdata._FacturaAfecta.c_NombreVendedor.c_Texto
                            .c_Tasa1.c_Valor = xdata._FacturaAfecta.c_Tasa1.c_Valor
                            .c_Tasa2.c_Valor = xdata._FacturaAfecta.c_Tasa2.c_Valor
                            .c_Tasa3.c_Valor = xdata._FacturaAfecta.c_Tasa3.c_Valor
                            .c_TelefonoCliente.c_Texto = xdata._FacturaAfecta.c_TelefonoCliente.c_Texto
                            .c_BloquearAlmacen.c_Texto = xdata._FacturaAfecta.c_BloquearAlmacen.c_Texto
                            .c_DocumentoAplica.c_Texto = xdata._FacturaAfecta.c_Documento.c_Texto
                            .c_FechaPedido.c_Valor = xdata._FechaMovimiento
                            .c_TasaCargos.c_Valor = xdata._FacturaAfecta.c_TasaCargos.c_Valor
                            .c_TasaDescuento_1.c_Valor = xdata._FacturaAfecta.c_TasaDescuento_1.c_Valor
                            .c_TasaDescuento_2.c_Valor = xdata._FacturaAfecta.c_TasaDescuento_2.c_Valor
                        End With

                        Dim xmd1 As Decimal = 0
                        Dim xmd2 As Decimal = 0
                        Dim xmt As Decimal = 0
                        Dim xb1 As Decimal = 0
                        Dim xb2 As Decimal = 0
                        Dim xb3 As Decimal = 0
                        Dim xexento As Decimal = 0

                        xb1 = xdata._MontoBase_1
                        xb2 = xdata._MontoBase_2
                        xb3 = xdata._MontoBase_3
                        xexento = xdata._MontoExento

                        If xventa.RegistroDato._TasaDescuento_1 > 0 Then
                            Dim xd1 As Decimal = 0
                            Dim xd2 As Decimal = 0
                            Dim xd3 As Decimal = 0
                            Dim xd4 As Decimal = 0
                            xd1 = Decimal.Round((xb1 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xd2 = Decimal.Round((xb2 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xd3 = Decimal.Round((xb3 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xd4 = Decimal.Round((xexento * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xventa.RegistroDato.c_MontoDescuento_1.c_Valor = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)

                            xb1 = Decimal.Round(xb1 - (xb1 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xb2 = Decimal.Round(xb2 - (xb2 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xb3 = Decimal.Round(xb3 - (xb3 * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                            xexento = Decimal.Round(xexento - (xexento * xventa.RegistroDato._TasaDescuento_1 / 100), 2, MidpointRounding.AwayFromZero)
                        End If

                        If xventa.RegistroDato._TasaDescuento_2 > 0 Then
                            Dim xd1 As Decimal = 0
                            Dim xd2 As Decimal = 0
                            Dim xd3 As Decimal = 0
                            Dim xd4 As Decimal = 0
                            xd1 = Decimal.Round((xb1 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xd2 = Decimal.Round((xb2 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xd3 = Decimal.Round((xb3 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xd4 = Decimal.Round((xexento * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xventa.RegistroDato.c_MontoDescuento_2.c_Valor = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)

                            xb1 = Decimal.Round(xb1 - (xb1 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xb2 = Decimal.Round(xb2 - (xb2 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xb3 = Decimal.Round(xb3 - (xb3 * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                            xexento = Decimal.Round(xexento - (xexento * xventa.RegistroDato._TasaDescuento_2 / 100), 2, MidpointRounding.AwayFromZero)
                        End If

                        If xventa.RegistroDato._TasaCargos > 0 Then
                            Dim xc1 As Decimal = 0
                            Dim xc2 As Decimal = 0
                            Dim xc3 As Decimal = 0
                            Dim xc4 As Decimal = 0
                            xc1 = Decimal.Round((xb1 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xc2 = Decimal.Round((xb2 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xc3 = Decimal.Round((xb3 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xc4 = Decimal.Round((xexento * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xventa.RegistroDato.c_MontoCargo.c_Valor = Decimal.Round(xc1 + xc2 + xc3 + xc4, 2, MidpointRounding.AwayFromZero)

                            xb1 = Decimal.Round(xb1 + (xb1 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xb2 = Decimal.Round(xb2 + (xb2 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xb3 = Decimal.Round(xb3 + (xb3 * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                            xexento = Decimal.Round(xexento + (xexento * xventa.RegistroDato._TasaCargos / 100), 2, MidpointRounding.AwayFromZero)
                        End If

                        Dim ximp1 As Decimal = 0
                        Dim ximp2 As Decimal = 0
                        Dim ximp3 As Decimal = 0

                        ximp1 = Decimal.Round(xb1 * xventa.RegistroDato._TasaIva_1 / 100, 2, MidpointRounding.AwayFromZero)
                        ximp2 = Decimal.Round(xb2 * xventa.RegistroDato._TasaIva_2 / 100, 2, MidpointRounding.AwayFromZero)
                        ximp3 = Decimal.Round(xb3 * xventa.RegistroDato._TasaIva_3 / 100, 2, MidpointRounding.AwayFromZero)

                        xventa.RegistroDato.c_Base1.c_Valor = xb1
                        xventa.RegistroDato.c_Base2.c_Valor = xb2
                        xventa.RegistroDato.c_Base3.c_Valor = xb3
                        xventa.RegistroDato.c_Base.c_Valor = Decimal.Round(xb1 + xb2 + xb3, 2, MidpointRounding.AwayFromZero)
                        xventa.RegistroDato.c_Exento.c_Valor = xexento
                        xventa.RegistroDato.c_Impuesto1.c_Valor = ximp1
                        xventa.RegistroDato.c_Impuesto2.c_Valor = ximp2
                        xventa.RegistroDato.c_Impuesto3.c_Valor = ximp3
                        xventa.RegistroDato.c_Impuesto.c_Valor = Decimal.Round(ximp1 + ximp2 + ximp3, 2, MidpointRounding.AwayFromZero)
                        xventa.RegistroDato.c_TotalGeneral.c_Valor = xventa.RegistroDato.c_Exento.c_Valor + _
                                                                   xventa.RegistroDato.c_Base.c_Valor + xventa.RegistroDato.c_Impuesto.c_Valor

                        With xventa.RegistroDato
                            .c_TipoDocumento.c_Texto = "03"
                            .c_FechaEmision.c_Valor = xdata._FechaMovimiento
                            .c_SerialImpresoraFiscal.c_Texto = xfiscal.RegistroDato.r_SerialFiscal
                            .c_FechaVencimiento.c_Valor = xdata._FechaMovimiento
                            .c_MesRelacion.c_Texto = Month(xdata._FechaMovimiento).ToString.Trim.PadLeft(2, "0")
                            .c_FechaRelacion.c_Valor = xdata._FechaMovimiento
                            .c_TipoColumna.c_Texto = "1"
                            .c_EstatusDocumento.c_Texto = "0"
                            .c_AnoRelacion.c_Texto = Year(xdata._FechaMovimiento).ToString.Trim.PadLeft(4, "0")
                            If .c_FactorCambio.c_Valor > 0 Then
                                .c_MontoDivisa.c_Valor = Decimal.Round(.c_TotalGeneral.c_Valor / .c_FactorCambio.c_Valor, 2, MidpointRounding.AwayFromZero)
                            Else
                                .c_MontoDivisa.c_Valor = 0
                            End If
                            .c_NotasDocumento.c_Texto = xdata._MotivoNC
                            .c_SerieAsignada.c_Texto = xdata._SerieFiscalAsignadaParaNC
                            .c_Usuario.c_Texto = xdata._UsuarioMovimiento._NombreUsuario
                            .c_CodigoUsuario.c_Texto = xdata._UsuarioMovimiento._CodigoUsuario
                            .c_AutoUsuario.c_Texto = xdata._UsuarioMovimiento._AutoUsuario
                            .c_AutomaticoJornada.c_Texto = xdata._Jornada._AutoJornada
                            .c_AutomaticoOperador.c_Texto = xdata._Operador._AutoOperador
                            .c_EstacionEquipo.c_Texto = xdata._EquipoEstacionMovimiento
                            .c_Hora.c_Texto = xdata._HoraMovimiento
                            .c_CodigoSucursal.c_Texto = xdata._CodigoSucrusal
                            .c_CondicionPago.c_Texto = "CONTADO"

                            If ximpresora IsNot Nothing Then
                                Dim xnc As Integer = 0
                                Dim xz As Integer = 0

                                Integer.TryParse(ximpresora.Ver_UltNotaCredito, xnc)
                                Integer.TryParse(ximpresora.Ver_UltimoZFiscal, xz)
                                xz += 1
                                .c_ControlFiscal.c_Texto = (xnc + 1).ToString.Trim.PadLeft(10, "0")
                                .c_Relacion_Z.c_Valor = xz
                            Else
                                .c_ControlFiscal.c_Texto = ""
                                .c_Relacion_Z.c_Valor = 0
                            End If

                            'Try
                            '    Dim xnc As Integer = 0
                            '    ximpresora.Estatus()
                            '    Integer.TryParse(ximpresora.Ver_UltNotaCredito, xnc)
                            '    .c_ControlFiscal.c_Texto = (xnc + 1).ToString.Trim.PadLeft(10, "0")
                            'Catch ex As Exception
                            '    .c_ControlFiscal.c_Texto = ""
                            'End Try

                            .c_CantidadRenglones.c_Valor = xdata._CantidadRenglones
                            .c_MontoSubTotal.c_Valor = xdata._SubTotal
                            .c_OrigenDocumento.c_Texto = "04"
                            .c_Rest_ModoMesaPedido.c_Texto = ""
                            .c_Rest_NumeroMesaPedido.c_Texto = ""
                            .c_Rest_ServicioMonto.c_Valor = 0
                            .c_Rest_ServicioTasa.c_Valor = 0
                        End With

                        'LISTA DE PLATOS A DEVOLVER
                        Dim xauto As Integer = 0
                        For Each xdetplato In xdata._ListaItemsDevolver_Platos
                            xauto += 1

                            With xdetplato._ItemDetalle
                                .c_AutoDocumento._ContenidoCampo = ""
                                .c_AutoItem._ContenidoCampo = xauto.ToString.Trim.PadLeft(10, "0")
                                .c_AutoItemOrigen._ContenidoCampo = xdetplato._ItemDetalle.c_AutoItem._ContenidoCampo
                                .c_AutoJornada._ContenidoCampo = xdata._Jornada._AutoJornada
                                .c_AutoOperador._ContenidoCampo = xdata._Operador._AutoOperador
                                .c_CostoTotalNeto._ContenidoCampo = 0
                                .c_FechaEmision._ContenidoCampo = xdata._FechaMovimiento
                                .c_MontoIva._ContenidoCampo = 0
                                .c_SignoDocumento._ContenidoCampo = -1
                                .c_TipoDocumento._ContenidoCampo = "03"
                                .c_TipoMovimiento._ContenidoCampo = "D"
                                .c_TotalGeneral._ContenidoCampo = 0
                                .c_TotalNeto._ContenidoCampo = 0
                                .c_UtilidadMonto._ContenidoCampo = 0
                                .c_UtilidadTasa._ContenidoCampo = 0
                                .c_NotasItem._ContenidoCampo = ""

                                Dim x0 As Decimal = ._PrecioNeto._Base
                                Dim x1 As Decimal = Decimal.Round(x0 * xdetplato._CantidadDevolver, 2, MidpointRounding.AwayFromZero)
                                .c_TotalNeto._ContenidoCampo = x1
                                Dim x2 As Decimal = Decimal.Round(x1 * ._TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                                .c_MontoIva._ContenidoCampo = x2
                                .c_TotalGeneral._ContenidoCampo = Decimal.Round(x1 + x2, 2, MidpointRounding.AwayFromZero)
                                .c_CostoTotalNeto._ContenidoCampo = ._CostoNeto * xdetplato._CantidadDevolver

                                Dim x5 As Decimal = ._PrecioFinal._Base * ._CantidadDespachada
                                Dim x6 As Decimal = ._CostoTotalNeto

                                .c_UtilidadMonto._ContenidoCampo = Decimal.Round(x5 - x6, 2, MidpointRounding.AwayFromZero)
                                If ._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    .c_UtilidadTasa._ContenidoCampo = UtilidadBaseCosto(x6, ._UtilidadMonto)
                                Else
                                    .c_UtilidadTasa._ContenidoCampo = UtilidadBasePrecioVenta(x5, ._UtilidadMonto)
                                End If
                            End With
                        Next


                        Dim xproductos As New List(Of FichaVentas.V_VentasDetalle.c_Registro)
                        For Each xitem In xdata._ListaItemsDevolver_Productos
                            xauto += 1

                            With xitem._ItemDetalle
                                .c_AutoDocumento.c_Texto = ""
                                .c_AutoItem.c_Texto = xauto.ToString.Trim.PadLeft(10, "0")
                                .c_AutoItemOrigen.c_Texto = xitem._ItemDetalle.c_AutoItem.c_Texto
                                .c_CantidadUnidadInventario.c_Valor = (xitem._ItemDetalle._ContenidoEmpaque * xitem._CantidadDevolver)
                                .c_DetalleNotas.c_Texto = ""
                                .c_FechaEmision.c_Valor = xdata._FechaMovimiento
                                .c_MontoIva.c_Valor = 0
                                .c_PTO_AutoJornada.c_Texto = xdata._Jornada._AutoJornada
                                .c_PTO_AutoOperador.c_Texto = xdata._Operador._AutoOperador
                                .c_SignoDocumento.c_Valor = -1
                                .c_TipoDocumento.c_Texto = "03"
                                .c_TipoMovimiento.c_Texto = "D"
                                .c_TotalGeneral.c_Valor = 0
                                .c_TotalNeto.c_Valor = 0
                                .c_UtilidadMonto.c_Valor = 0
                                .c_UtilidadTasa.c_Valor = 0
                                .c_CostoVenta.c_Valor = Decimal.Round((xitem._ItemDetalle._CostoInventario * xitem._ItemDetalle._ContenidoEmpaque) _
                                                                                                  * xitem._CantidadDevolver, 2, MidpointRounding.AwayFromZero)
                                .c_NombreCortoProducto.c_Texto = xitem._ItemDetalle._NombreCortoProducto

                                Dim x0 As Decimal = ._PrecioNeto
                                Dim x1 As Decimal = Decimal.Round(x0 * xitem._CantidadDevolver, 2, MidpointRounding.AwayFromZero)
                                .c_TotalNeto.c_Valor = x1
                                Dim x2 As Decimal = Decimal.Round(x1 * ._TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                                .c_MontoIva.c_Valor = x2
                                .c_TotalGeneral.c_Valor = Decimal.Round(x1 + x2, 2, MidpointRounding.AwayFromZero)

                                Dim x5 As Decimal = Decimal.Round(._PrecioFinal * xitem._CantidadDevolver, 2, MidpointRounding.AwayFromZero)
                                Dim x6 As Decimal = ._CostoVenta

                                .c_UtilidadMonto.c_Valor = Decimal.Round(x5 - x6, 2, MidpointRounding.AwayFromZero)
                                If ._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                    .c_UtilidadTasa.c_Valor = UtilidadBaseCosto(x6, ._UtilidadMonto)
                                Else
                                    .c_UtilidadTasa.c_Valor = UtilidadBasePrecioVenta(x5, ._UtilidadMonto)
                                End If
                            End With
                        Next


                        '
                        ' ARRANCA EL PROCEDIMIENTO DE GRABAR
                        '
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'ACTUALIZO CONTADOR AUTOMATICO DE VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_1
                                    xventa.RegistroDato.c_AutoDocumento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'ACTUALIZA CONTADOR AUTOMATICO CXC
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_2
                                    autocxc = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'ACTUALIZA CORRELATIVO DE SERIES FISCALES
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3
                                    xcmd.Parameters.AddWithValue("@nombre", xventa.RegistroDato._SerieFiscalAsignada)
                                    xventa.RegistroDato.c_Documento.c_Texto = xventa.RegistroDato._SerieFiscalAsignada + _
                                                    xcmd.ExecuteScalar().ToString.Trim.PadLeft(10 - xventa.RegistroDato._SerieFiscalAsignada.Length, "0")

                                    'VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaVentas.INSERT_VENTAS_POS
                                    xcmd.Parameters.AddWithValue("@auto", xventa.RegistroDato.c_AutoDocumento.c_Texto).Size = xventa.RegistroDato.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xventa.RegistroDato.c_Documento.c_Texto).Size = xventa.RegistroDato.c_Documento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xventa.RegistroDato.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xventa.RegistroDato.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nombre", xventa.RegistroDato.c_NombreCliente.c_Texto).Size = xventa.RegistroDato.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@dir_fiscal", xventa.RegistroDato.c_DirFiscalCliente.c_Texto).Size = xventa.RegistroDato.c_DirFiscalCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xventa.RegistroDato.c_CiRifCliente.c_Texto).Size = xventa.RegistroDato.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xventa.RegistroDato.c_TipoDocumento.c_Texto).Size = xventa.RegistroDato.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@exento", xventa.RegistroDato.c_Exento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base1", xventa.RegistroDato.c_Base1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base2", xventa.RegistroDato.c_Base2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base3", xventa.RegistroDato.c_Base3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto1", xventa.RegistroDato.c_Impuesto1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto2", xventa.RegistroDato.c_Impuesto2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto3", xventa.RegistroDato.c_Impuesto3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base", xventa.RegistroDato.c_Base.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto", xventa.RegistroDato.c_Impuesto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total", xventa.RegistroDato.c_TotalGeneral.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa1", xventa.RegistroDato.c_Tasa1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa2", xventa.RegistroDato.c_Tasa2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa3", xventa.RegistroDato.c_Tasa3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nota", xventa.RegistroDato.c_NotasDocumento.c_Texto).Size = xventa.RegistroDato.c_NotasDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xventa.RegistroDato.c_TasaRetencionIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xventa.RegistroDato.c_TasaRetencionISLR.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion_iva", xventa.RegistroDato.c_RetencionIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion_islr", xventa.RegistroDato.c_RetencionISLR.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xventa.RegistroDato.c_AutoCliente.c_Texto).Size = xventa.RegistroDato.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_entidad", xventa.RegistroDato.c_CodigoCliente.c_Texto).Size = xventa.RegistroDato.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@mes_relacion", xventa.RegistroDato.c_MesRelacion.c_Texto).Size = xventa.RegistroDato.c_MesRelacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@control", xventa.RegistroDato.c_ControlFiscal.c_Texto).Size = xventa.RegistroDato.c_ControlFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_relacion", xventa.RegistroDato.c_FechaRelacion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@orden_compra", xventa.RegistroDato.c_OrdenCompra.c_Texto).Size = xventa.RegistroDato.c_OrdenCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@dias", xventa.RegistroDato.c_DiasCreditoCliente.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1", xventa.RegistroDato.c_MontoDescuento_1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2", xventa.RegistroDato.c_MontoDescuento_2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cargos", xventa.RegistroDato.c_MontoCargo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xventa.RegistroDato.c_TasaDescuento_1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xventa.RegistroDato.c_TasaDescuento_2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cargos_porcentaje", xventa.RegistroDato.c_TasaCargos.c_Valor)
                                    xcmd.Parameters.AddWithValue("@columna", xventa.RegistroDato.c_TipoColumna.c_Texto).Size = xventa.RegistroDato.c_TipoColumna.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xventa.RegistroDato.c_EstatusDocumento.c_Texto).Size = xventa.RegistroDato.c_EstatusDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@aplica", xventa.RegistroDato.c_DocumentoAplica.c_Texto).Size = xventa.RegistroDato.c_DocumentoAplica.c_Largo
                                    xcmd.Parameters.AddWithValue("@comprobante_retencion", xventa.RegistroDato.c_ComprobanteRetencion.c_Texto).Size = xventa.RegistroDato.c_ComprobanteRetencion.c_Largo
                                    xcmd.Parameters.AddWithValue("@subtotal", xventa.RegistroDato.c_MontoSubTotal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@telefono", xventa.RegistroDato.c_TelefonoCliente.c_Texto).Size = xventa.RegistroDato.c_TelefonoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@factor_cambio", xventa.RegistroDato.c_FactorCambio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_vendedor", xventa.RegistroDato.c_CodigoVendedor.c_Texto).Size = xventa.RegistroDato.c_CodigoVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@vendedor", xventa.RegistroDato.c_NombreVendedor.c_Texto).Size = xventa.RegistroDato.c_NombreVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_vendedor", xventa.RegistroDato.c_AutoVendedor.c_Texto).Size = xventa.RegistroDato.c_AutoVendedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_pedido", xventa.RegistroDato.c_FechaPedido.c_Valor)
                                    xcmd.Parameters.AddWithValue("@pedido", xventa.RegistroDato.c_NumeroPedido.c_Texto).Size = xventa.RegistroDato.c_NumeroPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@condicion_pago", xventa.RegistroDato.c_CondicionPago.c_Texto).Size = xventa.RegistroDato.c_CondicionPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xventa.RegistroDato.c_Usuario.c_Texto).Size = xventa.RegistroDato.c_Usuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", xventa.RegistroDato.c_CodigoUsuario.c_Texto).Size = xventa.RegistroDato.c_CodigoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_sucursal", xventa.RegistroDato.c_CodigoSucursal.c_Texto).Size = xventa.RegistroDato.c_CodigoSucursal.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xventa.RegistroDato.c_Hora.c_Texto).Size = xventa.RegistroDato.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@transporte", xventa.RegistroDato.c_Transporte.c_Texto).Size = xventa.RegistroDato.c_Transporte.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_transporte", xventa.RegistroDato.c_CodigoTransporte.c_Texto).Size = xventa.RegistroDato.c_CodigoTransporte.c_Largo
                                    xcmd.Parameters.AddWithValue("@monto_divisa", xventa.RegistroDato.c_MontoDivisa.c_Valor)
                                    xcmd.Parameters.AddWithValue("@despachado", xventa.RegistroDato.c_NombreDespachador.c_Texto).Size = xventa.RegistroDato.c_NombreDespachador.c_Largo
                                    xcmd.Parameters.AddWithValue("@dir_despacho", xventa.RegistroDato.c_DirDespacho.c_Texto).Size = xventa.RegistroDato.c_DirDespacho.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xventa.RegistroDato.c_EstacionEquipo.c_Texto).Size = xventa.RegistroDato.c_EstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_recibo", xventa.RegistroDato.c_AutoRecibo.c_Texto).Size = xventa.RegistroDato.c_AutoRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@recibo", xventa.RegistroDato.c_NumeroRecibo.c_Texto).Size = xventa.RegistroDato.c_NumeroRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@renglones", xventa.RegistroDato.c_CantidadRenglones.c_Valor)
                                    xcmd.Parameters.AddWithValue("@saldo_pendiente", xventa.RegistroDato.c_MontoSaldoPendiente.c_Valor)
                                    xcmd.Parameters.AddWithValue("@ano_relacion", xventa.RegistroDato.c_AnoRelacion.c_Texto).Size = xventa.RegistroDato.c_AnoRelacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xventa.RegistroDato.c_ComprobanteRetencionISLR.c_Texto).Size = xventa.RegistroDato.c_ComprobanteRetencionISLR.c_Largo
                                    xcmd.Parameters.AddWithValue("@dias_validez", xventa.RegistroDato.c_ValidezDocumentoDias.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nrf", xventa.RegistroDato.c_SerialImpresoraFiscal.c_Texto).Size = xventa.RegistroDato.c_SerialImpresoraFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xventa.RegistroDato.c_AutoUsuario.c_Texto).Size = xventa.RegistroDato.c_AutoUsuario.c_Largo

                                    'CAMPOS NUEVOS
                                    xcmd.Parameters.AddWithValue("@auto_jornada", xventa.RegistroDato.c_AutomaticoJornada.c_Texto).Size = xventa.RegistroDato.c_AutomaticoJornada.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_operador", xventa.RegistroDato.c_AutomaticoOperador.c_Texto).Size = xventa.RegistroDato.c_AutomaticoOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@serie", xventa.RegistroDato.c_SerieAsignada.c_Texto).Size = xventa.RegistroDato.c_SerieAsignada.c_Largo
                                    xcmd.Parameters.AddWithValue("@serial", xventa.RegistroDato.c_SerialUnico_Jornada.c_Texto).Size = xventa.RegistroDato.c_SerialUnico_Jornada.c_Largo
                                    xcmd.Parameters.AddWithValue("@bloquear_almacen", xventa.RegistroDato.c_BloquearAlmacen.c_Texto).Size = xventa.RegistroDato.c_BloquearAlmacen.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen_documento", xventa.RegistroDato.c_OrigenDocumento.c_Texto).Size = xventa.RegistroDato.c_OrigenDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@rest_numero_mesapedido", xventa.RegistroDato.c_Rest_NumeroMesaPedido.c_Texto).Size = xventa.RegistroDato.c_Rest_NumeroMesaPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@rest_servicio_monto", xventa.RegistroDato.c_Rest_ServicioMonto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_servicio_tasa", xventa.RegistroDato.c_Rest_ServicioTasa.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_modo_mesapedido", xventa.RegistroDato.c_Rest_ModoMesaPedido.c_Texto).Size = xventa.RegistroDato.c_Rest_ModoMesaPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@relacion_z", xventa.RegistroDato.c_Relacion_Z.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'CXC, sea Contado / Credito
                                    Dim xcxc As New FichaCtasCobrar.c_CxC.c_Registro
                                    With xcxc
                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoCliente.c_Texto = xventa.RegistroDato.c_AutoCliente.c_Texto
                                        .c_AutoCxC.c_Texto = autocxc
                                        .c_AutoDocumento.c_Texto = xventa.RegistroDato.c_AutoDocumento.c_Texto
                                        .c_CiRifCliente.c_Texto = xventa.RegistroDato.c_CiRifCliente.c_Texto
                                        .c_CodigoCliente.c_Texto = xventa.RegistroDato.c_CodigoCliente.c_Texto
                                        .c_EstatusCancelado.c_Texto = "0"
                                        .c_EstatusDocumentoCxC.c_Texto = "0"
                                        .c_FechaProceso.c_Valor = xventa.RegistroDato.c_FechaEmision.c_Valor
                                        .c_FechaVencimiento.c_Valor = xventa.RegistroDato.c_FechaVencimiento.c_Valor
                                        .c_MontoAcumulado.c_Valor = 0
                                        .c_MontoImporte.c_Valor = xventa.RegistroDato.c_TotalGeneral.c_Valor * -1
                                        .c_MontoPorCobrar.c_Valor = xventa.RegistroDato.c_TotalGeneral.c_Valor * -1
                                        .c_NombreAgencia.c_Texto = ""
                                        .c_NombreCliente.c_Texto = xventa.RegistroDato.c_NombreCliente.c_Texto
                                        .c_NotasDetalles.c_Texto = xventa.RegistroDato.c_NotasDocumento.c_Texto
                                        .c_Numero.c_Texto = ""
                                        .c_NumeroDocumento.c_Texto = xventa.RegistroDato.c_Documento.c_Texto
                                        .c_TipoDocumento.c_Texto = "NCF"
                                        .c_TipoMovimiento.c_Valor = -1
                                        .c_TipoOperacion.c_Texto = ""
                                        .c_AutoMovimientoEntrada.c_Texto = ""
                                        .c_FechaEmision.c_Valor = xventa.RegistroDato.c_FechaEmision.c_Valor
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasCobrar.INSERT_CXC
                                    xcmd.Parameters.AddWithValue("@auto", xcxc.c_AutoCxC.c_Texto).Size = xcxc.c_AutoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xcxc.c_FechaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo_documento", xcxc.c_TipoDocumento.c_Texto).Size = xcxc.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xcxc.c_NumeroDocumento.c_Texto).Size = xcxc.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xcxc.c_NotasDetalles.c_Texto).Size = xcxc.c_NotasDetalles.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe", xcxc.c_MontoImporte.c_Valor)
                                    xcmd.Parameters.AddWithValue("@acumulado", xcxc.c_MontoAcumulado.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xcxc.c_AutoCliente.c_Texto).Size = xcxc.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cliente", xcxc.c_NombreCliente.c_Texto).Size = xcxc.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xcxc.c_CiRifCliente.c_Texto).Size = xcxc.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_cliente", xcxc.c_CodigoCliente.c_Texto).Size = xcxc.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cancelado", xcxc.c_EstatusCancelado.c_Texto).Size = xcxc.c_EstatusCancelado.c_Largo
                                    xcmd.Parameters.AddWithValue("@resta", xcxc.c_MontoPorCobrar.c_Valor)
                                    xcmd.Parameters.AddWithValue("@operacion", xcxc.c_TipoOperacion.c_Texto).Size = xcxc.c_TipoOperacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xcxc.c_EstatusDocumentoCxC.c_Texto).Size = xcxc.c_EstatusDocumentoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xcxc.c_AutoDocumento.c_Texto).Size = xcxc.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero", xcxc.c_Numero.c_Texto).Size = xcxc.c_Numero.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_agencia", xcxc.c_AutoAgencia.c_Texto).Size = xcxc.c_AutoAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@agencia", xcxc.c_NombreAgencia.c_Texto).Size = xcxc.c_NombreAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xcxc.c_TipoMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc.c_AutoMovimientoEntrada.c_Texto).Size = xcxc.c_AutoMovimientoEntrada.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_emision", xcxc.c_FechaEmision.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'BUSCAR EL CONCEPTO ADECUADO PARA EL TIPO DE DOCUMENTO
                                    Dim auto_concepto As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from productos_conceptos where codigo='DEV_VENTAS'"
                                    auto_concepto = xcmd.ExecuteScalar()
                                    If (auto_concepto Is Nothing) Or IsDBNull(auto_concepto) Then
                                        Throw New Exception("CONCEPTO 'DEV_VENTAS' NO ESTA DEFINIDO EN LA TABLA CONCEPTOS DE MOVIMIENTO DEL INVENTARIO")
                                    End If

                                    Dim xconcepto As String = ""
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select nombre from productos_conceptos where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", auto_concepto)
                                    xconcepto = xcmd.ExecuteScalar


                                    '' PARA LISTA DE PLATOS
                                    For Each xdt In xdata._ListaItemsDevolver_Platos
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = VentasDetalle_FastFood.INSERT_VENTASDETALLE_FASTFOOD
                                        With xdt._ItemDetalle
                                            .c_AutoDocumento._ContenidoCampo = xventa.RegistroDato.c_AutoDocumento.c_Texto
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoCliente._NombreCampo, ._AutoCliente).Size = .c_AutoCliente._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoGrupo._NombreCampo, ._AutoGrupo).Size = .c_AutoGrupo._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoItemOrigen._NombreCampo, ._AutoItemOrigen).Size = .c_AutoItemOrigen._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoJornada._NombreCampo, ._AutoJornada).Size = .c_AutoJornada._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoOperador._NombreCampo, ._AutoOperador).Size = .c_AutoOperador._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoPlato._NombreCampo, ._AutoPlato).Size = .c_AutoPlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_CantidadDespachada._NombreCampo, xdt._CantidadDevolver)
                                            xcmd.Parameters.AddWithValue("@" + .c_CodigoPlato._NombreCampo, ._CodigoPlato).Size = .c_CodigoPlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_CostoNeto._NombreCampo, ._CostoNeto)
                                            xcmd.Parameters.AddWithValue("@" + .c_CostoTotalNeto._NombreCampo, ._CostoTotalNeto)
                                            xcmd.Parameters.AddWithValue("@" + .c_EnOferta._NombreCampo, .c_EnOferta._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_EsPesado._NombreCampo, .c_EsPesado._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_FechaEmision._NombreCampo, ._FechaEmision)
                                            xcmd.Parameters.AddWithValue("@" + .c_MontoIva._NombreCampo, ._MontoImpuesto)
                                            xcmd.Parameters.AddWithValue("@" + .c_NombrePlato._NombreCampo, ._NombrePlato)
                                            xcmd.Parameters.AddWithValue("@" + .c_NotasItem._NombreCampo, ._NotasItem)
                                            xcmd.Parameters.AddWithValue("@" + .c_PrecioFinal._NombreCampo, ._PrecioFinal._Base)
                                            xcmd.Parameters.AddWithValue("@" + .c_PrecioNeto._NombreCampo, ._PrecioNeto._Base)
                                            xcmd.Parameters.AddWithValue("@" + .c_SignoDocumento._NombreCampo, ._Signo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TasaIva._NombreCampo, ._TasaIva)
                                            xcmd.Parameters.AddWithValue("@" + .c_TipoCalculoUtilidad._NombreCampo, .c_TipoCalculoUtilidad._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TipoDocumento._NombreCampo, .c_TipoDocumento._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TipoItem._NombreCampo, .c_TipoItem._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TipoMovimiento._NombreCampo, .c_TipoMovimiento._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TipoTasaIva._NombreCampo, .c_TipoTasaIva._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + .c_TotalGeneral._NombreCampo, ._TotalGeneral)
                                            xcmd.Parameters.AddWithValue("@" + .c_TotalNeto._NombreCampo, ._TotalNeto)
                                            xcmd.Parameters.AddWithValue("@" + .c_UtilidadMonto._NombreCampo, ._UtilidadMonto)
                                            xcmd.Parameters.AddWithValue("@" + .c_UtilidadTasa._NombreCampo, ._UtilidadTasa)
                                            xcmd.Parameters.AddWithValue("@" + .c_EsCombo._NombreCampo, ._EsCombo)
                                            xcmd.Parameters.AddWithValue("@" + .c_Rest_AutoMesonero._NombreCampo, ._Rest_AutoMesonero)
                                            xcmd.Parameters.AddWithValue("@" + .c_Rest_CodigoMesonero._NombreCampo, ._Rest_CodigoMesonero)
                                            xcmd.Parameters.AddWithValue("@" + .c_Rest_NombreMesonero._NombreCampo, ._Rest_NombreMesonero)
                                            xcmd.ExecuteNonQuery()
                                        End With

                                        Dim xvalor As Decimal = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "SELECT SUM(CANTIDAD) FROM VENTAS_DETALLE_FASTFOOD WHERE auto_plato=@auto_plato and auto_item_origen=@auto_item_origen " & _
                                          "AND TipoMovimiento='D' AND AUTO_DOCUMENTO IN (select AUTO from ventas where aplica=@aplica AND estatus='0') "
                                        xcmd.Parameters.AddWithValue("@auto_plato", xdt._ItemDetalle._AutoPlato)
                                        xcmd.Parameters.AddWithValue("@auto_item_origen", xdt._ItemDetalle._AutoItemOrigen)
                                        xcmd.Parameters.AddWithValue("@aplica", xventa.RegistroDato._DocumentoAplica)
                                        xvalor = xcmd.ExecuteScalar()
                                        If IsDBNull(xvalor) Then
                                        Else
                                            If xvalor > xdt._ItemDetalle._CantidadDespachada Then
                                                Throw New Exception("PLATO HA EFECTUAR DEVOLUCION:" & xdt._ItemDetalle._NombrePlato & _
                                                                    vbCrLf & "LA CANTIDAD A DEVOLVER SUPERA LA CANTIDAD FACTURADA" & vbCrLf & _
                                                                    "VERIFICA SI HAY UNA NOTA DE CREDITO YA REALIZADA A ESTE PLATO")
                                            End If
                                        End If

                                        Dim xtb_inv As New DataTable
                                        Dim xrd As SqlDataReader
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select * from ventainventario_fastfood where auto_documento=@auto_doc and auto_item=@auto_it"
                                        xcmd.Parameters.AddWithValue("@auto_doc", xdata._FacturaAfecta._AutoDocumento)
                                        xcmd.Parameters.AddWithValue("@auto_it", xdt._ItemDetalle._AutoItemOrigen)
                                        xrd = xcmd.ExecuteReader()
                                        xtb_inv.Load(xrd)
                                        xrd.Close()

                                        For Each xdr_inv As DataRow In xtb_inv.Rows
                                            Dim xventainv As New FastFood.VentaInventario
                                            xventainv.M_CargarRegistro(xdr_inv)

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaVentas.VENTAS_UPDATE_PRODUCTOS_DEPOSITO
                                            xcmd.Parameters.AddWithValue("@auto_producto", xventainv.RegistroDato._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xventainv.RegistroDato._AutoDeposito)
                                            xcmd.Parameters.AddWithValue("@cantidad_inventario", xdt._CantidadDevolver * _
                                                                         xventainv.RegistroDato._Cantidad_Requerida_Descontar * _
                                                                         xventainv.RegistroDato._ContenidoEmpaque * xdt._ItemDetalle._Signo)
                                            xcmd.ExecuteNonQuery()


                                            'PRODUCTOS_KARDEX
                                            Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                                            With xkardex
                                                .c_AutoConcepto.c_Texto = auto_concepto
                                                .c_AutoDeposito.c_Texto = xventainv.RegistroDato._f_AutoDeposito._Automatico
                                                .c_AutoDocumento.c_Texto = xventa.RegistroDato._AutoDocumento
                                                .c_AutoProducto.c_Texto = xventainv.RegistroDato._f_AutoProducto._AutoProducto
                                                .c_CantidadMover.c_Valor = xdt._CantidadDevolver
                                                .c_CantidadUnidadesMover.c_Valor = xdt._CantidadDevolver * _
                                                                         xventainv.RegistroDato._Cantidad_Requerida_Descontar * _
                                                                         xventainv.RegistroDato._ContenidoEmpaque
                                                .c_Documento.c_Texto = xventa.RegistroDato._Documento
                                                .c_Entidad.c_Texto = xventa.RegistroDato._NombreCliente
                                                .c_Estatus.c_Texto = "0"
                                                .c_FechaEmision.c_Valor = xdata._FechaMovimiento
                                                .c_NotasDetallesMovimiento.c_Texto = ""
                                                .c_OrigenMovimiento.c_Texto = "0803"
                                                .c_ReferenciaEmpaque.c_Texto = "5"
                                                .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Entrada
                                                .c_NombreProducto.c_Texto = xventainv.RegistroDato._f_AutoProducto._DescripcionDetallaDelProducto
                                                .c_NombreDeposito.c_Texto = xventainv.RegistroDato._f_AutoDeposito._Nombre
                                                .c_NombreConcepto.c_Texto = xconcepto
                                                .c_NombreMedidaEmpaque.c_Texto = xventainv.RegistroDato._f_AutoMedEmpaq._NombreMedida
                                                .c_AutoMedida.c_Texto = xventainv.RegistroDato._f_AutoMedEmpaq._Automatico
                                                .c_ContenidoMedidaEmpaque.c_Valor = xventainv.RegistroDato._ContenidoEmpaque
                                                .c_CodigoProducto.c_Texto = xventainv.RegistroDato._f_AutoProducto._CodigoProducto
                                                .c_CodigoDeposito.c_Texto = xventainv.RegistroDato._f_AutoDeposito._Codigo
                                                .c_CodigoConcepto.c_Texto = "DEV_VENTAS"
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                            xcmd.Parameters.AddWithValue("@auto_producto", xkardex.c_AutoProducto.c_Texto).Size = xkardex.c_AutoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", xkardex.c_FechaEmision.c_Valor)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xkardex.c_AutoDeposito.c_Texto).Size = xkardex.c_AutoDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@cantidad", xkardex.c_CantidadMover.c_Valor)
                                            xcmd.Parameters.AddWithValue("@auto_concepto", xkardex.c_AutoConcepto.c_Texto).Size = xkardex.c_AutoConcepto.c_Largo
                                            xcmd.Parameters.AddWithValue("@entidad", xkardex.c_Entidad.c_Texto).Size = xkardex.c_Entidad.c_Largo
                                            xcmd.Parameters.AddWithValue("@documento", xkardex.c_Documento.c_Texto).Size = xkardex.c_Documento.c_Largo
                                            xcmd.Parameters.AddWithValue("@medida_empaque", xkardex.c_ReferenciaEmpaque.c_Texto).Size = xkardex.c_ReferenciaEmpaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@signo", xkardex.c_TipoMovimiento.c_Valor)
                                            xcmd.Parameters.AddWithValue("@cantidad_inventario", xkardex.c_CantidadUnidadesMover.c_Valor)
                                            xcmd.Parameters.AddWithValue("@estatus", xkardex.c_Estatus.c_Texto).Size = xkardex.c_Estatus.c_Largo
                                            xcmd.Parameters.AddWithValue("@origen", xkardex.c_OrigenMovimiento.c_Texto).Size = xkardex.c_OrigenMovimiento.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_documento", xkardex.c_AutoDocumento.c_Texto).Size = xkardex.c_AutoDocumento.c_Largo
                                            xcmd.Parameters.AddWithValue("@nota", xkardex.c_NotasDetallesMovimiento.c_Texto).Size = xkardex.c_NotasDetallesMovimiento.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_nombreproducto", xkardex.c_NombreProducto.c_Texto).Size = xkardex.c_NombreProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_nombredeposito", xkardex.c_NombreDeposito.c_Texto).Size = xkardex.c_NombreDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_nombreconcepto", xkardex.c_NombreConcepto.c_Texto).Size = xkardex.c_NombreConcepto.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xkardex.c_NombreMedidaEmpaque.c_Texto).Size = xkardex.c_NombreMedidaEmpaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_automedida", xkardex.c_AutoMedida.c_Texto).Size = xkardex.c_AutoMedida.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xkardex.c_ContenidoMedidaEmpaque.c_Valor)
                                            xcmd.Parameters.AddWithValue("@n_codigoproducto", xkardex.c_CodigoProducto.c_Texto).Size = xkardex.c_CodigoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_codigodeposito", xkardex.c_CodigoDeposito.c_Texto).Size = xkardex.c_CodigoDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_codigoconcepto", xkardex.c_CodigoConcepto.c_Texto).Size = xkardex.c_CodigoConcepto.c_Largo
                                            xcmd.ExecuteNonQuery()
                                        Next

                                        'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                        Dim dr As DataRow = xtablaprd.NewRow
                                        dr("cantidad") = xdt._CantidadDevolver
                                        dr("nombre") = xdt._ItemDetalle._NombrePlato
                                        dr("precio_neto") = xdt._ItemDetalle._PrecioNeto._Base
                                        dr("codigo_tasa") = xdt._ItemDetalle.c_TipoTasaIva._ContenidoCampo.ToString.Trim
                                        dr("detalle") = ""
                                        xtablaprd.Rows.Add(dr)
                                    Next

                                    '' PARA LA LISTA DE PRODUCTOS
                                    For Each xprdvt In xdata._ListaItemsDevolver_Productos
                                        With xprdvt._ItemDetalle
                                            .c_AutoDocumento.c_Texto = xventa.RegistroDato.c_AutoDocumento.c_Texto

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaVentas.INSERT_VENTAS_DETALLE_POS
                                            xcmd.Parameters.AddWithValue("@auto_documento", .c_AutoDocumento.c_Texto).Size = .c_AutoDocumento.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_productos", .c_AutoProducto.c_Texto).Size = .c_AutoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@codigo", .c_CodigoProducto.c_Texto).Size = .c_CodigoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@nombre", .c_NombreProducto.c_Texto).Size = .c_NombreProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_departamento", .c_AutoDepartamento.c_Texto).Size = .c_AutoDepartamento.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_grupo", .c_AutoGrupo.c_Texto).Size = .c_AutoGrupo.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_subgrupo", .c_AutoSubGrupo.c_Texto).Size = .c_AutoSubGrupo.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_deposito", .c_AutoDeposito.c_Texto).Size = .c_AutoDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@cantidad", xprdvt._CantidadDevolver)
                                            xcmd.Parameters.AddWithValue("@empaque", .c_NombreEmpaque.c_Texto).Size = .c_NombreEmpaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@descuento1p", .c_DescuentoTasa_1.c_Valor)
                                            xcmd.Parameters.AddWithValue("@descuento2p", .c_DescuentoTasa_2.c_Valor)
                                            xcmd.Parameters.AddWithValue("@descuento3p", .c_DescuentoTasa_3.c_Valor)
                                            xcmd.Parameters.AddWithValue("@descuento1", .c_DescuentoMonto_1.c_Valor)
                                            xcmd.Parameters.AddWithValue("@descuento2", .c_DescuentoMonto_2.c_Valor)
                                            xcmd.Parameters.AddWithValue("@descuento3", .c_DescuentoMonto_3.c_Valor)
                                            xcmd.Parameters.AddWithValue("@total_neto", .c_TotalNeto.c_Valor)
                                            xcmd.Parameters.AddWithValue("@tasa", .c_TasaIva.c_Valor)
                                            xcmd.Parameters.AddWithValue("@impuesto", .c_MontoIva.c_Valor)
                                            xcmd.Parameters.AddWithValue("@total", .c_TotalGeneral.c_Valor)
                                            xcmd.Parameters.AddWithValue("@auto", .c_AutoItem.c_Texto).Size = .c_AutoItem.c_Largo
                                            xcmd.Parameters.AddWithValue("@codigo_tasa", .c_TipoTasaIva.c_Texto).Size = .c_TipoTasaIva.c_Largo
                                            xcmd.Parameters.AddWithValue("@estatus", .c_Estatus.c_Texto).Size = .c_Estatus.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", .c_FechaEmision.c_Valor)
                                            xcmd.Parameters.AddWithValue("@tipo", .c_TipoDocumento.c_Texto).Size = .c_TipoDocumento.c_Largo
                                            xcmd.Parameters.AddWithValue("@deposito", .c_NombreDeposito.c_Texto).Size = .c_NombreDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@signo", .c_SignoDocumento.c_Valor)
                                            xcmd.Parameters.AddWithValue("@auto_entidad", .c_AutoCliente.c_Texto).Size = .c_AutoCliente.c_Largo
                                            xcmd.Parameters.AddWithValue("@decimales", .c_NumeroDecimales.c_Valor)
                                            xcmd.Parameters.AddWithValue("@contenido_empaque", .c_ContenidoEmpaque.c_Valor)
                                            xcmd.Parameters.AddWithValue("@cantidad_inventario", .c_CantidadUnidadInventario.c_Valor)
                                            xcmd.Parameters.AddWithValue("@costo_inventario", .c_CostoInventario.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_neto", .c_PrecioNeto.c_Valor)
                                            xcmd.Parameters.AddWithValue("@costo_venta", .c_CostoVenta.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_final", .c_PrecioFinal.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_inventario", .c_PrecioInventario.c_Valor)
                                            xcmd.Parameters.AddWithValue("@utilidad", .c_UtilidadMonto.c_Valor)
                                            xcmd.Parameters.AddWithValue("@utilidadp", .c_UtilidadTasa.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_item", .c_PrecioItem.c_Valor)
                                            xcmd.Parameters.AddWithValue("@estatus_garantia", .c_EstatusGarantia.c_Texto).Size = .c_EstatusGarantia.c_Largo
                                            xcmd.Parameters.AddWithValue("@estatus_serial", .c_EstatusSerial.c_Texto).Size = .c_EstatusSerial.c_Largo
                                            xcmd.Parameters.AddWithValue("@codigo_deposito", .c_CodigoDeposito.c_Texto).Size = .c_CodigoDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@dias_garantia", .c_DiasGarantia.c_Valor)
                                            xcmd.Parameters.AddWithValue("@detalle", .c_DetalleNotas.c_Texto).Size = .c_DetalleNotas.c_Largo
                                            xcmd.Parameters.AddWithValue("@psv", .c_PrecioSugerido.c_Valor)
                                            xcmd.Parameters.AddWithValue("@empaque_tipo", .c_ReferenciaEmpaque.c_Texto).Size = .c_ReferenciaEmpaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@estatus_corte", .c_EstatusCorte.c_Texto).Size = .c_EstatusCorte.c_Largo
                                            xcmd.Parameters.AddWithValue("@x", .c_Corte_X.c_Valor)
                                            xcmd.Parameters.AddWithValue("@y", .c_Corte_Y.c_Valor)
                                            xcmd.Parameters.AddWithValue("@z", .c_Corte_Z.c_Valor)
                                            xcmd.Parameters.AddWithValue("@corte", .c_Corte.c_Texto).Size = .c_Corte.c_Largo
                                            xcmd.Parameters.AddWithValue("@categoria", .c_CategoriaProducto.c_Texto).Size = .c_CategoriaProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_esoferta", .c_PTO_EstaEnOferta.c_Texto).Size = .c_PTO_EstaEnOferta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_espesado", .c_PTO_EsPesado.c_Texto).Size = .c_PTO_EsPesado.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_codigobarra", .c_PTO_CodigoBarra.c_Texto)
                                            xcmd.Parameters.AddWithValue("@N_plu", .c_PTO_Plu.c_Texto).Size = .c_PTO_Plu.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_formato", .c_PTO_FormatoEtiqueta.c_Texto).Size = .c_PTO_FormatoEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_depart", .c_PTO_NumeroDepartEtiqueta.c_Texto).Size = .c_PTO_NumeroDepartEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_seccion", .c_PTO_SeccionEtiqueta.c_Texto).Size = .c_PTO_SeccionEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_vendedor", .c_PTO_VendedorEtiqueta.c_Texto).Size = .c_PTO_VendedorEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_plu", .c_PTO_PluEtiqueta.c_Texto).Size = .c_PTO_PluEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_peso", .c_PTO_PesoEtiqueta.c_Valor)
                                            xcmd.Parameters.AddWithValue("@N_etiq_precio", .c_PTO_PrecioEtiqueta.c_Valor)
                                            xcmd.Parameters.AddWithValue("@N_etiq_control", .c_PTO_NumeroControlEtiqueta.c_Texto).Size = .c_PTO_NumeroControlEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_digitos", .c_PTO_DigitosEtiqueta.c_Texto).Size = .c_PTO_DigitosEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_ticket", .c_PTO_NumeroTicketEtiqueta.c_Texto).Size = .c_PTO_NumeroTicketEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_numbalanza", .c_PTO_NumeroBalanzaEtiqueta.c_Texto).Size = .c_PTO_NumeroBalanzaEtiqueta.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_etiq_montoitem", .c_PTO_MontoTotalEtiqueta.c_Valor)
                                            xcmd.Parameters.AddWithValue("@N_etiq_numitem", .c_PTO_NumeroItemEtiqueta.c_Valor)
                                            xcmd.Parameters.AddWithValue("@N_auto_jornada", .c_PTO_AutoJornada.c_Texto).Size = .c_PTO_AutoJornada.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_auto_operador", .c_PTO_AutoOperador.c_Texto).Size = .c_PTO_AutoOperador.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_automedida", .c_AutoMedida.c_Texto).Size = .c_AutoMedida.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_forzarmedida", .c_ForzarMedida.c_Texto).Size = .c_ForzarMedida.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_TipoCalculoUtilidad", .c_TipoCalculoUtilidad.c_Texto).Size = .c_TipoCalculoUtilidad.c_Largo
                                            xcmd.Parameters.AddWithValue("@N_TipoMovimiento", .c_TipoMovimiento.c_Texto).Size = .c_TipoMovimiento.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_auto_item_origen", .c_AutoItemOrigen.c_Texto).Size = .c_AutoItemOrigen.c_Largo
                                            xcmd.Parameters.AddWithValue("@n_nombre_corto", .c_NombreCortoProducto.c_Texto).Size = .c_NombreCortoProducto.c_Largo
                                            xcmd.ExecuteNonQuery()

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaVentas.VENTAS_UPDATE_PRODUCTOS_DEPOSITO
                                            xcmd.Parameters.AddWithValue("@auto_producto", ._AutoProducto).Size = .c_AutoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_deposito", ._AutoDeposito).Size = .c_AutoDeposito.c_Largo
                                            xcmd.Parameters.AddWithValue("@cantidad_inventario", ._CantidadUnidadInventario * ._SignoDocumento)
                                            xcmd.ExecuteNonQuery()

                                            Dim xvalor As Decimal = 0
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "SELECT SUM(CANTIDAD) FROM VENTAS_DETALLE WHERE auto_productos=@auto_producto and n_auto_item_origen=@auto_item_origen " & _
                                              "AND n_TipoMovimiento='D' AND AUTO_DOCUMENTO IN (select AUTO from ventas where aplica=@aplica AND estatus='0')"
                                            xcmd.Parameters.AddWithValue("@auto_producto", ._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_item_origen", ._AutoItemOrigen)
                                            xcmd.Parameters.AddWithValue("@aplica", xventa.RegistroDato._DocumentoAplica)
                                            xvalor = xcmd.ExecuteScalar()
                                            If IsDBNull(xvalor) Then
                                            Else
                                                If xvalor > ._CantidadDespachada Then
                                                    Throw New Exception("PRODUCTO HA EFECTUAR DEVOLUCION: " & ._NombreProducto & _
                                                                        vbCrLf & "LA CANTIDAD A DEVOLVER SUPERA LA CANTIDAD FACTURADA" & vbCrLf & _
                                                                        "VERIFICA SI HAY UNA NOTA DE CREDITO YA REALIZADA A ESTE PRODUCTO")
                                                End If
                                            End If
                                        End With

                                        'PRODUCTOS_KARDEX
                                        Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                                        With xkardex
                                            .c_AutoConcepto.c_Texto = auto_concepto
                                            .c_AutoDeposito.c_Texto = xprdvt._ItemDetalle._AutoDeposito
                                            .c_AutoDocumento.c_Texto = xprdvt._ItemDetalle._AutoDocumento
                                            .c_AutoProducto.c_Texto = xprdvt._ItemDetalle._AutoProducto
                                            .c_CantidadMover.c_Valor = xprdvt._CantidadDevolver
                                            .c_CantidadUnidadesMover.c_Valor = xprdvt._CantidadDevolver
                                            .c_Documento.c_Texto = xventa.RegistroDato._Documento
                                            .c_Entidad.c_Texto = xventa.RegistroDato._NombreCliente
                                            .c_Estatus.c_Texto = "0"
                                            .c_FechaEmision.c_Valor = xdata._FechaMovimiento
                                            .c_NotasDetallesMovimiento.c_Texto = ""
                                            .c_OrigenMovimiento.c_Texto = "0803"
                                            .c_ReferenciaEmpaque.c_Texto = xprdvt._ItemDetalle.c_ReferenciaEmpaque.c_Texto
                                            .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Entrada
                                            .c_NombreProducto.c_Texto = xprdvt._ItemDetalle._NombreProducto
                                            .c_NombreDeposito.c_Texto = xprdvt._ItemDetalle._NombreDeposito
                                            .c_NombreConcepto.c_Texto = xconcepto
                                            .c_NombreMedidaEmpaque.c_Texto = xprdvt._ItemDetalle._NombreEmpaque
                                            .c_AutoMedida.c_Texto = xprdvt._ItemDetalle._AutoMedida
                                            .c_ContenidoMedidaEmpaque.c_Valor = xprdvt._ItemDetalle._ContenidoEmpaque
                                            .c_CodigoProducto.c_Texto = xprdvt._ItemDetalle._CodigoProducto
                                            .c_CodigoDeposito.c_Texto = xprdvt._ItemDetalle._CodigoDeposito
                                            .c_CodigoConcepto.c_Texto = "DEV_VENTAS"
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                        xcmd.Parameters.AddWithValue("@auto_producto", xkardex.c_AutoProducto.c_Texto).Size = xkardex.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xkardex.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xkardex.c_AutoDeposito.c_Texto).Size = xkardex.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad", xkardex.c_CantidadMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_concepto", xkardex.c_AutoConcepto.c_Texto).Size = xkardex.c_AutoConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@entidad", xkardex.c_Entidad.c_Texto).Size = xkardex.c_Entidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@documento", xkardex.c_Documento.c_Texto).Size = xkardex.c_Documento.c_Largo
                                        xcmd.Parameters.AddWithValue("@medida_empaque", xkardex.c_ReferenciaEmpaque.c_Texto).Size = xkardex.c_ReferenciaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@signo", xkardex.c_TipoMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xkardex.c_CantidadUnidadesMover.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus", xkardex.c_Estatus.c_Texto).Size = xkardex.c_Estatus.c_Largo
                                        xcmd.Parameters.AddWithValue("@origen", xkardex.c_OrigenMovimiento.c_Texto).Size = xkardex.c_OrigenMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_documento", xkardex.c_AutoDocumento.c_Texto).Size = xkardex.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xkardex.c_NotasDetallesMovimiento.c_Texto).Size = xkardex.c_NotasDetallesMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreproducto", xkardex.c_NombreProducto.c_Texto).Size = xkardex.c_NombreProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombredeposito", xkardex.c_NombreDeposito.c_Texto).Size = xkardex.c_NombreDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombreconcepto", xkardex.c_NombreConcepto.c_Texto).Size = xkardex.c_NombreConcepto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xkardex.c_NombreMedidaEmpaque.c_Texto).Size = xkardex.c_NombreMedidaEmpaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_automedida", xkardex.c_AutoMedida.c_Texto).Size = xkardex.c_AutoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xkardex.c_ContenidoMedidaEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@n_codigoproducto", xkardex.c_CodigoProducto.c_Texto).Size = xkardex.c_CodigoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigodeposito", xkardex.c_CodigoDeposito.c_Texto).Size = xkardex.c_CodigoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@n_codigoconcepto", xkardex.c_CodigoConcepto.c_Texto).Size = xkardex.c_CodigoConcepto.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                        Dim dr As DataRow = xtablaprd.NewRow
                                        dr("cantidad") = xprdvt._CantidadDevolver
                                        dr("nombre") = xprdvt._ItemDetalle._NombreProducto
                                        dr("precio_neto") = xprdvt._ItemDetalle._PrecioNeto
                                        dr("codigo_tasa") = xprdvt._ItemDetalle.c_TipoTasaIva.c_Texto.ToString.Trim
                                        dr("detalle") = ""
                                        xtablaprd.Rows.Add(dr)
                                    Next

                                    'VERIFICO SI EL MONTO DE LA NC ES SUPERIOR AL MONTO ORIGINAL DEL DOCUMENTO DE FACTURA
                                    Dim xval As Decimal = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT SUM(total) FROM VENTAS WHERE auto IN (select AUTO from ventas where aplica=@aplica AND estatus='0')"
                                    xcmd.Parameters.AddWithValue("@aplica", xventa.RegistroDato._DocumentoAplica)
                                    xval = xcmd.ExecuteScalar()
                                    If IsDBNull(xval) Then
                                    Else
                                        If xval > xdata._FacturaAfecta._TotalGenereal Then
                                            Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO SUPERA EL TOTAL DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                        End If
                                    End If

                                    Dim t_debito As Single = 0
                                    Dim t_credito As Single = 0
                                    Dim t_saldo As Single = 0

                                    'BUSCA LOS SALDOS PARA EL CLIENTE
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xventa.RegistroDato.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                    t_debito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xventa.RegistroDato.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                    t_credito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xventa.RegistroDato.c_AutoCliente.c_Texto)
                                    xcmd.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                    t_saldo = xcmd.ExecuteScalar()

                                    'CLIENTES
                                    Dim xr_cliente As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "UPDATE CLIENTES SET " _
                                      + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                      + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                      + "where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                    xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                    xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                    xcmd.Parameters.AddWithValue("@auto", xventa.RegistroDato.c_AutoCliente.c_Texto)
                                    xr_cliente = xcmd.ExecuteNonQuery()
                                    If xr_cliente = 0 Then
                                        Throw New Exception("VERIFICAR CLIENTE, AL PARECER FUE EILIMINADO / CAMBIO DE ESTATUS")
                                    End If

                                    With ximpresora
                                        .NC_Inicializa(xventa.RegistroDato.c_Tasa1.c_Valor, _
                                                           xventa.RegistroDato.c_Tasa2.c_Valor, _
                                                           xventa.RegistroDato.c_Tasa3.c_Valor)

                                        .Cli_CondicionVenta = xventa.RegistroDato.c_CondicionPago.c_Texto.Trim
                                        .Cli_DirCliente = xventa.RegistroDato.c_DirFiscalCliente.c_Texto.Trim
                                        .Cli_EstacionVenta = xventa.RegistroDato.c_EstacionEquipo.c_Texto.Trim
                                        .Cli_FacturaVenta = xventa.RegistroDato.c_DocumentoAplica.c_Texto.Trim
                                        .Cli_NomCliente = xventa.RegistroDato.c_NombreCliente.c_Texto.Trim
                                        .Cli_RifCliente = xventa.RegistroDato.c_CiRifCliente.c_Texto.Trim
                                        .Cli_TelCliente = xventa.RegistroDato.c_TelefonoCliente.c_Texto.Trim
                                        .Cli_UsuarioVenta = xventa.RegistroDato.c_Usuario.c_Texto.Trim
                                        .Cli_FechaFacturaDev = xdata._FacturaAfecta._FechaEmision
                                        .Cli_HoraFacturaDev = xdata._FacturaAfecta._HoraDocumento
                                        .Cli_SerialImp = xdata._FacturaAfecta._SerialImpresoraFiscal
                                        .AutoDocumento = xventa.RegistroDato._AutoDocumento

                                        .CargoGlobal = xventa.RegistroDato.c_TasaCargos.c_Valor
                                        .DsctoGlobal = xventa.RegistroDato.c_TasaDescuento_1.c_Valor
                                    End With
                                    If xventa.RegistroDato.c_TotalGeneral.c_Valor > 0 Then
                                        ImprimeNotaCredito(ximpresora, xtablaprd, xventa.RegistroDato.c_TotalGeneral.c_Valor)
                                    Else
                                        Throw New Exception("NO SE PUEDE GENERAR UNA NOTA DE CREDITO FISCAL DE MONTO CERO (0.0)")
                                    End If

                                    xtr.Commit()
                                End Using

                                RaiseEvent _NotaCreditoExitosa()
                                Return True
                            Catch xsql As SqlException
                                xtr.Rollback()
                                If xsql.Number = 2601 Then
                                    Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO Y SERIE, VERIFIQUE")
                                ElseIf xsql.Number = 547 Then
                                    Throw New Exception("ERROR... AL PARECER EL CLIENTE / VENDEDOR SELECCIONADO FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE")
                                Else
                                    Throw New Exception(xsql.Message + vbCrLf + "ERROR NUMERO: " + xsql.Number.ToString)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("VENTAS" + vbCrLf + "ERROR AL GRABAR NOTA DE CREDITO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function ImprimeNotaCredito(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xtotal As Decimal) As Boolean
                    'If TypeOf (xfiscal) Is ImpFiscales.MisFiscales.HKA112 Then
                    '    Dim xlib As New [Lib].Provider.HKA112(xfiscal.PuertoConexion, [Lib].IFiscal.ModelosFiscales.HKA112)
                    '    xlib.FacturaInicializa(12, 8, 21)

                    '    Try
                    '        With xlib
                    '            .Cli_NomCliente = xfiscal.Cli_NomCliente
                    '            .Cli_RifCliente = xfiscal.Cli_RifCliente
                    '            .Cli_CondicionVenta = xfiscal.Cli_CondicionVenta
                    '            .Cli_DirCliente = xfiscal.Cli_DirCliente
                    '            .Cli_TelCliente = xfiscal.Cli_TelCliente
                    '            .Cli_UsuarioVenta = xfiscal.Cli_UsuarioVenta
                    '            .Cli_DocumentoVenta = xfiscal.Cli_DocumentoVenta
                    '            .Cli_EstacionVenta = xfiscal.Cli_EstacionVenta
                    '            .Cli_FacturaVenta = xfiscal.Cli_FacturaVenta
                    '            .Cli_FechaFacturaDev = xfiscal.Cli_FechaFacturaDev
                    '            .Cli_HoraFacturaDev = xfiscal.Cli_HoraFacturaDev
                    '            .Cli_SerialImp = xfiscal.Cli_SerialImp
                    '            .Cli_LineaEncabezado1 = xfiscal.Cli_LineaEncabezado1
                    '            .AutoDocumento = xfiscal.AutoDocumento
                    '            .CargoGlobal = xfiscal.CargoGlobal
                    '            .DsctoGlobal = xfiscal.DsctoGlobal
                    '        End With

                    '        xlib.NC_Encabezado()
                    '        For Each dr As DataRow In xtablaprd.Rows
                    '            xlib.LimpiarItem()
                    '            xlib.Prd_CantidadPrd = dr("cantidad")
                    '            xlib.Prd_DetallePrd = dr("nombre")
                    '            xlib.Prd_PNetoPrd = dr("precio_neto")
                    '            xlib.Prd_TasaIvaPrd = dr("codigo_tasa")
                    '            xlib.Prd_Nota1Prd = dr("detalle")
                    '            xlib.NC_Detalle()
                    '        Next
                    '        xlib.MedioPago_1 = xtotal
                    '        xlib.NC_Cerrar()
                    '        Return True
                    '    Catch ex As Exception
                    '        Try
                    '            xlib.AbortarDF()
                    '        Catch ex2 As Exception
                    '        End Try
                    '        Throw New Exception("ERROR AL IMPRIMIR NOTA DE CREDITO FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                    '    End Try

                    'Else
                    '    Try
                    '        xfiscal.NC_Encabezado()

                    '        For Each dr As DataRow In xtablaprd.Rows
                    '            xfiscal.LimpiarItem()
                    '            xfiscal.Prd_CantidadPrd = dr("cantidad")
                    '            xfiscal.Prd_DetallePrd = dr("nombre")
                    '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                    '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                    '            xfiscal.Prd_Nota1Prd = dr("detalle")
                    '            xfiscal.NC_Detalle()
                    '        Next

                    '        xfiscal.MedioPago_1 = xtotal
                    '        xfiscal.NC_Cerrar()

                    '        Return True
                    '    Catch ex As Exception
                    '        Try
                    '            xfiscal.AbortarDF()
                    '        Catch ex2 As Exception
                    '        End Try
                    '        Throw New Exception("ERROR AL IMPRIMIR NOTA DE CREDITO FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                    '    End Try
                    'End If

                    Try
                        xfiscal.NC_Encabezado()

                        For Each dr As DataRow In xtablaprd.Rows
                            xfiscal.LimpiarItem()
                            xfiscal.Prd_CantidadPrd = dr("cantidad")
                            xfiscal.Prd_DetallePrd = dr("nombre")
                            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                            xfiscal.Prd_Nota1Prd = dr("detalle")
                            xfiscal.NC_Detalle()
                        Next

                        xfiscal.MedioPago_1 = xtotal
                        xfiscal.NC_Cerrar()

                        Return True
                    Catch ex As Exception
                        Try
                            xfiscal.AbortarDF()
                        Catch ex2 As Exception
                        End Try
                        Throw New Exception("ERROR AL IMPRIMIR NOTA DE CREDITO FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                    End Try

                    Return True
                End Function


                'Function ImprimeNotaCredito(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xtotal As Single) As Boolean
                '    Try
                '        xfiscal.NC_Encabezado()

                '        For Each dr As DataRow In xtablaprd.Rows
                '            xfiscal.LimpiarItem()
                '            xfiscal.Prd_CantidadPrd = dr("cantidad")
                '            xfiscal.Prd_DetallePrd = dr("nombre")
                '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                '            xfiscal.Prd_Nota1Prd = dr("detalle")
                '            xfiscal.NC_Detalle()
                '        Next

                '        xfiscal.MedioPago_1 = xtotal
                '        xfiscal.NC_Cerrar()

                '        Return True
                '    Catch ex As Exception
                '        Try
                '            xfiscal.AbortarDF()
                '        Catch ex2 As Exception
                '        End Try
                '        Throw New Exception("ERROR AL IMPRIMIR NOTA DE CREDITO FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                '    End Try
                'End Function

                Class DocumentoAnulado
                    Private xdocumento As FichaVentas.V_Ventas.c_Registro
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String
                    Private xdetalle As String

                    Property _DocumentoAnular() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Return xdocumento
                        End Get
                        Set(ByVal value As FichaVentas.V_Ventas.c_Registro)
                            xdocumento = value
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

                    Property _EquipoEstacion() As String
                        Get
                            Return xestacion.Trim
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _DetalleMotivo() As String
                        Get
                            Return xdetalle.Trim
                        End Get
                        Set(ByVal value As String)
                            xdetalle = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Sub New()
                        Me._DetalleMotivo = ""
                        Me._DocumentoAnular = Nothing
                        Me._EquipoEstacion = ""
                        Me._Usuario = Nothing
                    End Sub
                End Class

                Function F_AnularDocumentoNC(ByVal xdoc As DocumentoAnulado) As Boolean
                    Try
                        Dim DocAnulado As New FichaGlobal.c_DocumentosAnulados
                        Dim xdetalle As New DataTable

                        If xdoc._DocumentoAnular._EstatusDocumento = TipoEstatus.Inactivo Then
                            Throw New Exception("Error Al Anular Documento... Dicho Documento Ya Se Encuentra Anulado !!!")
                        End If

                        'Dim sql_1 As String = "select auto_productos,auto_deposito,sum(cantidad_inventario*signo) cantidad " _
                        '    + "from ventas_detalle where auto_documento=@auto_documento group by auto_productos,auto_deposito"
                        'Using xadap As New SqlDataAdapter(sql_1, _MiCadenaConexion)
                        '    xadap.SelectCommand.Parameters.AddWithValue("@auto_documento", xdoc._DocumentoAnular._AutoDocumento)
                        '    xadap.Fill(xdetalle)
                        'End Using

                        Dim sql_1 As String = "select auto_producto,auto_deposito,sum(cantidad_inventario*signo) cantidad " & _
                             "from productos_kardex where auto_documento=@auto_documento and documento=@documento and origen='0803' " & _
                             "group by auto_producto,auto_deposito"
                        Using xadap As New SqlDataAdapter(sql_1, _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_documento", xdoc._DocumentoAnular._AutoDocumento)
                            xadap.SelectCommand.Parameters.AddWithValue("@documento", xdoc._DocumentoAnular._Documento)
                            xadap.Fill(xdetalle)
                        End Using

                        With DocAnulado.RegistroDato
                            .c_AutoAnulacion.c_Texto = ""
                            .c_AutoDocumento.c_Texto = xdoc._DocumentoAnular._AutoDocumento
                            .c_CodigoAnulacion.c_Texto = "08" + xdoc._DocumentoAnular.c_TipoDocumento.c_Texto
                            .c_CodigoUsuario.c_Texto = xdoc._Usuario._CodigoUsuario
                            .c_FechaEmision.c_Valor = xdoc._Fecha
                            .c_HoraAnulacion.c_Texto = xdoc._Hora
                            .c_NombreEstacion.c_Texto = xdoc._EquipoEstacion
                            .c_NombreUsuario.c_Texto = xdoc._Usuario._NombreUsuario
                            .c_NotaDetalleAnulacion.c_Texto = xdoc._DetalleMotivo
                        End With

                        Dim xsql_1 As String = "update contadores set a_documentos_anulados=a_documentos_anulados+1;" _
                          + "select a_documentos_anulados from contadores"
                        Dim xsql_2 As String = "update ventas set estatus='1' where auto=@auto"
                        Dim xsql_3_1 As String = "update ventas_detalle set estatus='1' where auto_documento=@auto"
                        Dim xsql_3_2 As String = "update ventas_detalle_fastfood set estatus='1' where auto_documento=@auto"
                        Dim xsql_4 As String = "update productos_kardex set estatus='1' where auto_documento=@auto and origen=@origen"
                        Dim xsql_5 As String = "update productos_deposito set real = real - @cantidad1, disponible = disponible - @cantidad2, " _
                           + " reservada=reservada+@cantidad3 from productos_deposito pd where pd.auto_producto=@auto_producto and pd.auto_deposito=@auto_deposito"
                        Dim xsql_6 As String = "select codigo,nombre as producto,cantidad,precio_neto precioneto,descuento1p descuento,tasa tasaiva,total_neto " & _
                                      "importe, N_espesado espesado,auto_productos autoproducto,empaque nombreempaque, contenido_empaque contenidoempaque, " & _
                                      "empaque_tipo referenciaempaque, N_automedida automedida,decimales decimalesmedida,N_forzarmedida forzarmedida, " & _
                                      "codigo_tasa tipotasa,tipo tipodocumento, psv psugerido, costo_inventario costoinventario, costo_venta costoventa, " & _
                                      "detalle notasitem from ventas_detalle where auto_documento=@auto"

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try

                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    'CONTADORES
                                    xcmd.CommandText = xsql_1
                                    DocAnulado.RegistroDato.c_AutoAnulacion.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'DOCUMENTOS_ANULADOS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                    xcmd.Parameters.AddWithValue("@codigo", DocAnulado.RegistroDato.c_CodigoAnulacion.c_Texto).Size = DocAnulado.RegistroDato.c_CodigoAnulacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", DocAnulado.RegistroDato.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@hora", DocAnulado.RegistroDato.c_HoraAnulacion.c_Texto).Size = DocAnulado.RegistroDato.c_HoraAnulacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@detalle", DocAnulado.RegistroDato.c_NotaDetalleAnulacion.c_Texto).Size = DocAnulado.RegistroDato.c_NotaDetalleAnulacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", DocAnulado.RegistroDato.c_NombreEstacion.c_Texto).Size = DocAnulado.RegistroDato.c_NombreEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", DocAnulado.RegistroDato.c_NombreUsuario.c_Texto).Size = DocAnulado.RegistroDato.c_NombreUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", DocAnulado.RegistroDato.c_CodigoUsuario.c_Texto).Size = DocAnulado.RegistroDato.c_CodigoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto", DocAnulado.RegistroDato.c_AutoAnulacion.c_Texto).Size = DocAnulado.RegistroDato.c_AutoAnulacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", DocAnulado.RegistroDato.c_AutoDocumento.c_Texto).Size = DocAnulado.RegistroDato.c_AutoDocumento.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    'VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_2
                                    xcmd.Parameters.AddWithValue("@auto", xdoc._DocumentoAnular._AutoDocumento)
                                    xcmd.ExecuteNonQuery()

                                    'VENTAS_DETALLE
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3_1
                                    xcmd.Parameters.AddWithValue("@auto", xdoc._DocumentoAnular._AutoDocumento)
                                    xcmd.ExecuteNonQuery()

                                    'VENTAS DETALLE FASTFOOD
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3_2
                                    xcmd.Parameters.AddWithValue("@auto", xdoc._DocumentoAnular._AutoDocumento)
                                    xcmd.ExecuteNonQuery()

                                    'PRODUCTOS_KARDEX
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_4
                                    xcmd.Parameters.AddWithValue("@auto", xdoc._DocumentoAnular._AutoDocumento)
                                    xcmd.Parameters.AddWithValue("@origen", DocAnulado.RegistroDato.c_CodigoAnulacion.c_Texto)
                                    xcmd.ExecuteNonQuery()

                                    'PRODUCTOS_DEPOSITO
                                    For Each dr As DataRow In xdetalle.Rows
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql_5
                                        xcmd.Parameters.AddWithValue("@cantidad1", dr("cantidad"))
                                        xcmd.Parameters.AddWithValue("@cantidad2", dr("cantidad"))
                                        xcmd.Parameters.AddWithValue("@cantidad3", 0)
                                        xcmd.Parameters.AddWithValue("@auto_producto", dr("auto_producto").ToString)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", dr("auto_deposito").ToString)
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    'CXC
                                    Dim xanticipos As Decimal = 0
                                    Dim xauto_cxc As String = ""
                                    Dim xobj As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from cxc where auto_documento=@auto_documento"
                                    xcmd.Parameters.AddWithValue("@auto_documento", xdoc._DocumentoAnular._AutoDocumento)
                                    xobj = xcmd.ExecuteScalar()

                                    If IsDBNull(xobj) Or (xobj Is Nothing) Then
                                    Else
                                        xauto_cxc = xobj.ToString.Trim
                                        Dim xdocumentos As Integer = 0

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select COUNT(*) xdoc from cxc_documentos cd join cxc_recibos cr on cd.auto_cxc_recibo = cr.auto " & _
                                                           "where cd.auto_cxc=@auto and cr.estatus='0'"
                                        xcmd.Parameters.AddWithValue("@auto", xauto_cxc)
                                        xdocumentos = xcmd.ExecuteScalar()
                                        If xdocumentos > 0 Then
                                            Throw New Exception("ERROR AL ANULAR DOCUMENTO, HAY MOVIMIENTOS DE PAGOS EFECTUADOS EN CXC SOBRE ESTE DOCUMENTO, VERIFIQUE POR FAVOR")
                                        Else
                                            'CXC, ELIMINO EL MOVIMIENTO PRINCIPAL
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "UPDATE CXC set estatus='1' where auto=@auto"
                                            xcmd.Parameters.AddWithValue("@auto", xauto_cxc)
                                            xcmd.ExecuteNonQuery()

                                            'CONTADORES DOCUMENTOS ANULADOS, SE INCREMENTA EL AUTOMATICO
                                            Dim xcxc_anulado As New FichaGlobal.c_DocumentosAnulados.c_Registro
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = xsql_1
                                            xcxc_anulado.c_AutoAnulacion.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                            With xcxc_anulado
                                                .c_AutoDocumento.c_Texto = xauto_cxc
                                                .c_CodigoAnulacion.c_Texto = "0401"
                                                .c_CodigoUsuario.c_Texto = xdoc._Usuario._CodigoUsuario
                                                .c_FechaEmision.c_Valor = xdoc._Fecha
                                                .c_HoraAnulacion.c_Texto = xdoc._Hora
                                                .c_NombreEstacion.c_Texto = xdoc._EquipoEstacion
                                                .c_NombreUsuario.c_Texto = xdoc._Usuario._NombreUsuario
                                                .c_NotaDetalleAnulacion.c_Texto = "ANULACION DE " + xdoc._DetalleMotivo
                                            End With

                                            'DOCUMENTOS_ANULADOS, SE GRABA EL DOCUMENTO ANULADO
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                            xcmd.Parameters.AddWithValue("@codigo", xcxc_anulado.c_CodigoAnulacion.c_Texto).Size = xcxc_anulado.c_CodigoAnulacion.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", xcxc_anulado.c_FechaEmision.c_Valor)
                                            xcmd.Parameters.AddWithValue("@hora", xcxc_anulado.c_HoraAnulacion.c_Texto).Size = xcxc_anulado.c_HoraAnulacion.c_Largo
                                            xcmd.Parameters.AddWithValue("@detalle", xcxc_anulado.c_NotaDetalleAnulacion.c_Texto).Size = xcxc_anulado.c_NotaDetalleAnulacion.c_Largo
                                            xcmd.Parameters.AddWithValue("@estacion", xcxc_anulado.c_NombreEstacion.c_Texto).Size = xcxc_anulado.c_NombreEstacion.c_Largo
                                            xcmd.Parameters.AddWithValue("@usuario", xcxc_anulado.c_NombreUsuario.c_Texto).Size = xcxc_anulado.c_NombreUsuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@codigo_usuario", xcxc_anulado.c_CodigoUsuario.c_Texto).Size = xcxc_anulado.c_CodigoUsuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto", xcxc_anulado.c_AutoAnulacion.c_Texto).Size = xcxc_anulado.c_AutoAnulacion.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_documento", xcxc_anulado.c_AutoDocumento.c_Texto).Size = xcxc_anulado.c_AutoDocumento.c_Largo
                                            xcmd.ExecuteNonQuery()

                                            'CXC_DOCUMENTOS, TOMO TODOS LOS DOCUMENTOS DE PAGOS RELACIONADOS CON ESTA CXC
                                            Dim xreader As SqlDataReader = Nothing
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "SELECT AUTO_CXC_PAGO,AUTO_CXC_RECIBO from cxc_documentos where auto_cxc=@auto_cxc"
                                            xcmd.Parameters.AddWithValue("@auto_cxc", xauto_cxc)
                                            xreader = xcmd.ExecuteReader()
                                            Dim xtb As New DataTable
                                            xtb.Load(xreader)
                                            xreader.Close()

                                            For Each xrow As DataRow In xtb.Rows
                                                Dim xauto_recibo As String = ""
                                                Dim xauto_cxc_pago As String = ""

                                                xauto_recibo = xrow(1).ToString
                                                xauto_cxc_pago = xrow(0).ToString

                                                Using xcmd2 As New SqlCommand("", xcon, xtr)
                                                    'CXC_RECIBOS, ELIMINO TODOS LOS RECIBOS RELACIONADOS
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = "UPDATE CXC_RECIBOS set estatus='1' where auto=@auto"
                                                    xcmd2.Parameters.AddWithValue("@auto", xauto_recibo)
                                                    xcmd2.ExecuteNonQuery()

                                                    'CXC_RECIBOS, VERIFICO SI HAY UN ANTICIPO Y LO ACUMULO
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = "select anticipos from CXC_RECIBOS where auto=@auto"
                                                    xcmd2.Parameters.AddWithValue("@auto", xauto_recibo)
                                                    xanticipos += xcmd2.ExecuteScalar

                                                    'CXC_MODO_PAGO, ELIMINO TODOS LOS PAGOS RELACIONADOS
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = "UPDATE CXC_MODO_PAGO set estatus='1' where auto_recibo=@auto"
                                                    xcmd2.Parameters.AddWithValue("@auto", xauto_recibo)
                                                    xcmd2.ExecuteNonQuery()

                                                    'CXC, ELIMINO TODOS LOS MOVIMIENTOS DE CXC RELACIONADOS A LOS PAGOS EFECTUADOS
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = "UPDATE CXC set estatus='1' where auto=@auto"
                                                    xcmd2.Parameters.AddWithValue("@auto", xauto_cxc_pago)
                                                    xcmd2.ExecuteNonQuery()

                                                    Dim xcxc_pago As New FichaGlobal.c_DocumentosAnulados.c_Registro
                                                    'CONTADORES DOCUMENTOS ANULADOS, SE INCREMENTA EL AUTOMATICO
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = xsql_1
                                                    xcxc_pago.c_AutoAnulacion.c_Texto = xcmd2.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                                    With xcxc_pago
                                                        .c_AutoDocumento.c_Texto = xauto_recibo
                                                        .c_CodigoAnulacion.c_Texto = "0401"
                                                        .c_CodigoUsuario.c_Texto = xdoc._Usuario._CodigoUsuario
                                                        .c_FechaEmision.c_Valor = xdoc._Fecha
                                                        .c_HoraAnulacion.c_Texto = xdoc._Hora
                                                        .c_NombreEstacion.c_Texto = xdoc._EquipoEstacion
                                                        .c_NombreUsuario.c_Texto = xdoc._Usuario._NombreUsuario
                                                        .c_NotaDetalleAnulacion.c_Texto = "ANULACION PAGO DE " + xdoc._DocumentoAnular._TipoDocumento.ToString + ", " + xdoc._DetalleMotivo
                                                    End With

                                                    'DOCUMENTOS_ANULADOS, SE GRABA EL DOCUMENTO ANULADO
                                                    xcmd2.Parameters.Clear()
                                                    xcmd2.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                                    xcmd2.Parameters.AddWithValue("@codigo", xcxc_pago.c_CodigoAnulacion.c_Texto).Size = xcxc_pago.c_CodigoAnulacion.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@fecha", xcxc_pago.c_FechaEmision.c_Valor)
                                                    xcmd2.Parameters.AddWithValue("@hora", xcxc_pago.c_HoraAnulacion.c_Texto).Size = xcxc_pago.c_HoraAnulacion.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@detalle", xcxc_pago.c_NotaDetalleAnulacion.c_Texto).Size = xcxc_pago.c_NotaDetalleAnulacion.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@estacion", xcxc_pago.c_NombreEstacion.c_Texto).Size = xcxc_pago.c_NombreEstacion.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@usuario", xcxc_pago.c_NombreUsuario.c_Texto).Size = xcxc_pago.c_NombreUsuario.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@codigo_usuario", xcxc_pago.c_CodigoUsuario.c_Texto).Size = xcxc_pago.c_CodigoUsuario.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@auto", xcxc_pago.c_AutoAnulacion.c_Texto).Size = xcxc_pago.c_AutoAnulacion.c_Largo
                                                    xcmd2.Parameters.AddWithValue("@auto_documento", xcxc_pago.c_AutoDocumento.c_Texto).Size = xcxc_pago.c_AutoDocumento.c_Largo
                                                    xcmd2.ExecuteNonQuery()
                                                End Using
                                            Next
                                        End If
                                    End If

                                    'BUSCA LOS SALDOS PARA EL CLIENTE
                                    Dim t_debito As Single = 0
                                    Dim t_credito As Single = 0
                                    Dim t_saldo As Single = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xdoc._DocumentoAnular._AutoCliente)
                                    xcmd.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                    t_debito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xdoc._DocumentoAnular._AutoCliente)
                                    xcmd.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                    t_credito = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xdoc._DocumentoAnular._AutoCliente)
                                    xcmd.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                      + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                    t_saldo = xcmd.ExecuteScalar()

                                    'CLIENTES
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "UPDATE CLIENTES SET " _
                                      + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                      + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                      + "where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                    xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                    xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                    xcmd.Parameters.AddWithValue("@auto", xdoc._DocumentoAnular._AutoCliente)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _NotaCreditoAnuladaExitosamente()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ERROR AL ANULAR DOCUMENTO DE NOTA DE CREDITO DE VENTAS" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class
        End Class
    End Class
End Namespace


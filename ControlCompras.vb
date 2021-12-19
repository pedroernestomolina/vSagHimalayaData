Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FichaCompras
            Event _CargarProveedor(ByVal xauto As String)

            Class GrabarCompra
                Dim xcompra As c_Compra.AgregarCompra
                Dim xcompra_detalle As List(Of c_ComprasDetalle.AgregarDetalleCompra)
                Dim xidunico As String

                Property _Compra() As c_Compra.AgregarCompra
                    Get
                        Return xcompra
                    End Get
                    Set(ByVal value As c_Compra.AgregarCompra)
                        xcompra = value
                    End Set
                End Property

                Property _CompraDetalle() As List(Of c_ComprasDetalle.AgregarDetalleCompra)
                    Get
                        Return xcompra_detalle
                    End Get
                    Set(ByVal value As List(Of c_ComprasDetalle.AgregarDetalleCompra))
                        xcompra_detalle = value
                    End Set
                End Property

                Property _IdUnico() As String
                    Get
                        Return xidunico
                    End Get
                    Set(ByVal value As String)
                        xidunico = value
                    End Set
                End Property

                'Compra De Mercancia
                ReadOnly Property _TipoCompraRegistrada() As String
                    Get
                        Return "1"
                    End Get
                End Property

                ReadOnly Property _ConceptoGasto() As String
                    Get
                        Return "COMPRA DE MERCANCIA"
                    End Get
                End Property
            End Class

            Class GrabarNC
                Dim xcompra_nc As c_Compra.AgregarCompra
                Dim xcompra_detalle_nc As List(Of c_ComprasDetalle.AgregarDetalleNC)
                Dim xreg As c_Compra.c_Registro

                Property _Compra_NC() As c_Compra.AgregarCompra
                    Get
                        Return xcompra_nc
                    End Get
                    Set(ByVal value As c_Compra.AgregarCompra)
                        xcompra_nc = value
                    End Set
                End Property

                Property _CompraDetalle_NC() As List(Of c_ComprasDetalle.AgregarDetalleNC)
                    Get
                        Return xcompra_detalle_nc
                    End Get
                    Set(ByVal value As List(Of c_ComprasDetalle.AgregarDetalleNC))
                        xcompra_detalle_nc = value
                    End Set
                End Property

                Property _FichaCompraOrigen() As c_Compra.c_Registro
                    Get
                        Return xreg
                    End Get
                    Set(ByVal value As c_Compra.c_Registro)
                        xreg = value
                    End Set
                End Property

                'TIPO DE COMPRA REGISTRADA PARA EFECTUAR NOTA DE CREDITO
                ReadOnly Property _TipoNCRegistrada() As String
                    Get
                        Return "1"
                    End Get
                End Property
            End Class

            Class GrabarCompraGasto
                Dim xcompra As c_Compra.AgregarCompra
                Dim xconceptogasto As String

                Property _ConceptoGasto() As String
                    Get
                        Return xconceptogasto
                    End Get
                    Set(ByVal value As String)
                        xconceptogasto = value
                    End Set
                End Property

                Property _Compra() As c_Compra.AgregarCompra
                    Protected Friend Get
                        Return xcompra
                    End Get
                    Set(ByVal value As c_Compra.AgregarCompra)
                        xcompra = value
                    End Set
                End Property

                ReadOnly Property _TipoCompra() As String
                    Get
                        Return "2"
                    End Get
                End Property

                ReadOnly Property _EstatusCompra() As String
                    Get
                        Return "0"
                    End Get
                End Property

                ReadOnly Property _EstatusCancelado() As String
                    Get
                        Return "0"
                    End Get
                End Property

                Sub New()
                    _Compra = Nothing
                    _ConceptoGasto = ""
                End Sub
            End Class

            Class GrabarGasto_NC
                Dim xcompra_nc As c_Compra.AgregarCompra
                Dim xreg As c_Compra.c_Registro

                ReadOnly Property _TipoCompra() As String
                    Get
                        Return "2"
                    End Get
                End Property

                ReadOnly Property _EstatusDocumento() As String
                    Get
                        Return "0"
                    End Get
                End Property

                ReadOnly Property _EstatusCancelado() As String
                    Get
                        Return "0"
                    End Get
                End Property

                Property _Compra_NC() As c_Compra.AgregarCompra
                    Get
                        Return xcompra_nc
                    End Get
                    Set(ByVal value As c_Compra.AgregarCompra)
                        xcompra_nc = value
                    End Set
                End Property

                Property _FichaCompraOrigen() As c_Compra.c_Registro
                    Get
                        Return xreg
                    End Get
                    Set(ByVal value As c_Compra.c_Registro)
                        xreg = value
                    End Set
                End Property

                Sub New()
                    Me._Compra_NC = Nothing
                    Me._FichaCompraOrigen = Nothing
                End Sub
            End Class


            Public Class c_Compra
                Class AgregarCompra
                    Private xregistro As c_Registro
                    Private xproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xfichaordercompras As FichaCompras.c_Compra.c_Registro

                    Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Property _Proveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Protected Friend Get
                            Return xproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            xproveedor = value
                        End Set
                    End Property

                    Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _FichaOrdenCompra() As FichaCompras.c_Compra.c_Registro
                        Protected Friend Get
                            Return Me.xfichaordercompras
                        End Get
                        Set(ByVal value As FichaCompras.c_Compra.c_Registro)
                            Me.xfichaordercompras = value
                        End Set
                    End Property

                    Sub New()
                        _Proveedor = Nothing
                        _Usuario = Nothing
                        _FichaOrdenCompra = Nothing
                        Me.RegistroDato = New c_Registro
                    End Sub

                    WriteOnly Property _NumeroDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroDocumentoCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NumeroControl() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroControlDocumento.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _FechaProceso() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaCarga.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TipoDocumento() As TipoDocumentoCompra
                        Set(ByVal value As TipoDocumentoCompra)
                            Select Case value
                                Case TipoDocumentoCompra.Factura
                                    Me.RegistroDato.c_TipoDocumentoCompra.c_Texto = "01"
                                Case TipoDocumentoCompra.NotaDebito
                                    Me.RegistroDato.c_TipoDocumentoCompra.c_Texto = "02"
                                Case TipoDocumentoCompra.NotaCredito
                                    Me.RegistroDato.c_TipoDocumentoCompra.c_Texto = "03"
                                Case TipoDocumentoCompra.OrdenCompra
                                    Me.RegistroDato.c_TipoDocumentoCompra.c_Texto = "04"
                            End Select
                        End Set
                    End Property
                    WriteOnly Property _MontoExento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoExento.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase3.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaIva_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaIva_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaIva_3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa3.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _NotasDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NotasDetalleCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _OrdenCompraNumero() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroOrdenCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _DiasCreditoOtorgado() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_DiasCredito.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaCargos() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaCargos.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoSubtotal() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoSubtotal.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _FactorCambio() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_FactorCambio.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _CantidadRenglones() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_CantidadRenglones.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _SerieDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_SerieDocumento.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreEstacionEquipo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreEstacionEquipo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Hora() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Hora.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuestoLicor() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuestoLicor.c_Valor = value
                        End Set
                    End Property
                End Class

                Public Class c_Registro
                    Private f_autocompra As CampoTexto
                    Private f_nrodocumentocompra As CampoTexto
                    Private f_fechaemision As CampoFecha
                    Private f_fechavencimiento As CampoFecha
                    Private f_nombreproveedor As CampoTexto
                    Private f_direccionfiscal As CampoTexto
                    Private f_cirifproveedor As CampoTexto
                    Private f_tipodocumentocompra As CampoTexto
                    Private f_montoexento As CampoDecimal
                    Private f_montobase1 As CampoDecimal
                    Private f_montobase2 As CampoDecimal
                    Private f_montobase3 As CampoDecimal
                    Private f_montoimpuesto1 As CampoDecimal
                    Private f_montoimpuesto2 As CampoDecimal
                    Private f_montoimpuesto3 As CampoDecimal
                    Private f_montototalbase As CampoDecimal
                    Private f_montototalimpuesto As CampoDecimal
                    Private f_montototal As CampoDecimal
                    Private f_tasa1 As CampoDecimal
                    Private f_tasa2 As CampoDecimal
                    Private f_tasa3 As CampoDecimal
                    Private f_detallecompra As CampoTexto
                    Private f_tasaretencioniva As CampoDecimal
                    Private f_tasaretencionislr As CampoDecimal
                    Private f_montoretencioniva As CampoDecimal
                    Private f_montoretencionislr As CampoDecimal
                    Private f_autoproveedor As CampoTexto
                    Private f_codigoproveedor As CampoTexto
                    Private f_mesrelacion As CampoTexto
                    Private f_genero As CampoTexto
                    Private f_nrocontrolcompra As CampoTexto
                    Private f_fechacarga As CampoFecha
                    Private f_ordencompra As CampoTexto
                    Private f_diascredito As CampoInteger
                    Private f_montodescuento1 As CampoDecimal
                    Private f_montodescuento2 As CampoDecimal
                    Private f_montocargos As CampoDecimal
                    Private f_porcentajedescuento1 As CampoDecimal
                    Private f_porcentajedescuento2 As CampoDecimal
                    Private f_porcentajecargos As CampoDecimal
                    Private f_columna As CampoTexto
                    Private f_estatuscompra As CampoTexto
                    Private f_montoflete As CampoDecimal
                    Private f_porcentajeflete As CampoDecimal
                    Private f_montoseguro As CampoDecimal
                    Private f_porcentajeseguro As CampoDecimal
                    Private f_montoarancel As CampoDecimal
                    Private f_porcentajearancel As CampoDecimal
                    Private f_montoservicio As CampoDecimal
                    Private f_porcentajeservicio As CampoDecimal
                    Private f_montoaduana As CampoDecimal
                    Private f_porcentajeaduana As CampoDecimal
                    Private f_montoagente As CampoDecimal
                    Private f_porcentajeagente As CampoDecimal
                    Private f_montogastos As CampoDecimal
                    Private f_porcentajegastos As CampoDecimal
                    Private f_montootrosgastos As CampoDecimal
                    Private f_porcentajeotrosgastos As CampoDecimal
                    Private f_expedientecompra As CampoTexto
                    Private f_aplicadocumento As CampoTexto
                    Private f_comprobanteretencion As CampoTexto
                    Private f_montosubtotal As CampoDecimal
                    Private f_telefonoproveedor As CampoTexto
                    Private f_factorcambio As CampoDecimal
                    Private f_planillaimportacion As CampoTexto
                    Private f_montoretencionivaterceros As CampoDecimal
                    Private f_montoanticipoivaimportacion As CampoDecimal
                    Private f_anorelacion As CampoTexto
                    Private f_comprobanteretencionislr As CampoTexto
                    Private f_cantidadrenglones As CampoInteger
                    Private f_n_serie As CampoTexto
                    Private f_n_serieaplica As CampoTexto
                    Private f_n_auto_usuario As CampoTexto
                    Private f_n_usuario As CampoTexto
                    Private f_n_codigo_usuario As CampoTexto
                    Private f_n_estacion As CampoTexto
                    Private f_n_hora As CampoTexto
                    Private f_n_periodo As CampoInteger
                    Private f_n_tipo_compra As CampoTexto
                    Private f_n_montoimplicor As CampoDecimal
                    Private f_n_concepto_gasto As CampoTexto

                    Protected Friend Property c_AutoDocumentoCompra() As CampoTexto
                        Get
                            Return f_autocompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autocompra = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroDocumentoCompra() As CampoTexto
                        Get
                            Return f_nrodocumentocompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nrodocumentocompra = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fechaemision
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechaemision = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaVencimiento() As CampoFecha
                        Get
                            Return f_fechavencimiento
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechavencimiento = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreProveedor() As CampoTexto
                        Get
                            Return f_nombreproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreproveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_DirFiscalProveedor() As CampoTexto
                        Get
                            Return f_direccionfiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_direccionfiscal = value
                        End Set
                    End Property

                    Protected Friend Property c_CiRifProveedor() As CampoTexto
                        Get
                            Return f_cirifproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cirifproveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoDocumentoCompra() As CampoTexto
                        Get
                            Return f_tipodocumentocompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipodocumentocompra = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoExento() As CampoDecimal
                        Get
                            Return f_montoexento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoexento = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase1() As CampoDecimal
                        Get
                            Return f_montobase1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montobase1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase2() As CampoDecimal
                        Get
                            Return f_montobase2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montobase2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase3() As CampoDecimal
                        Get
                            Return f_montobase3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montobase3 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto1() As CampoDecimal
                        Get
                            Return f_montoimpuesto1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoimpuesto1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto2() As CampoDecimal
                        Get
                            Return f_montoimpuesto2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoimpuesto2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto3() As CampoDecimal
                        Get
                            Return f_montoimpuesto3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoimpuesto3 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoTotalBase() As CampoDecimal
                        Get
                            Return f_montototalbase
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montototalbase = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoTotalImpuesto() As CampoDecimal
                        Get
                            Return f_montototalimpuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montototalimpuesto = value
                        End Set
                    End Property

                    Protected Friend Property c_TotalGeneral() As CampoDecimal
                        Get
                            Return f_montototal
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montototal = value
                        End Set
                    End Property

                    Protected Friend Property c_Tasa1() As CampoDecimal
                        Get
                            Return f_tasa1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa1 = value
                        End Set
                    End Property

                    Protected Friend Property c_Tasa2() As CampoDecimal
                        Get
                            Return f_tasa2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa2 = value
                        End Set
                    End Property

                    Protected Friend Property c_Tasa3() As CampoDecimal
                        Get
                            Return f_tasa3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa3 = value
                        End Set
                    End Property

                    Protected Friend Property c_NotasDetalleCompra() As CampoTexto
                        Get
                            Return f_detallecompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detallecompra = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaRetencionIva() As CampoDecimal
                        Get
                            Return f_tasaretencioniva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaretencioniva = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaRetencionIslr() As CampoDecimal
                        Get
                            Return f_tasaretencionislr
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaretencionislr = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRetencionIva() As CampoDecimal
                        Get
                            Return f_montoretencioniva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoretencioniva = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRetencionIslr() As CampoDecimal
                        Get
                            Return f_montoretencionislr
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoretencionislr = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_autoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoproveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigoproveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_MesRelacion() As CampoTexto
                        Get
                            Return f_mesrelacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_mesrelacion = value
                        End Set
                    End Property

                    Protected Friend Property c_Genero() As CampoTexto
                        Get
                            Return f_genero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_genero = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroControlDocumento() As CampoTexto
                        Get
                            Return f_nrocontrolcompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nrocontrolcompra = value
                        End Set
                    End Property

                    Property c_FechaCarga() As CampoFecha
                        Get
                            Return f_fechacarga
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechacarga = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroOrdenCompra() As CampoTexto
                        Get
                            Return f_ordencompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ordencompra = value
                        End Set
                    End Property

                    Protected Friend Property c_DiasCredito() As CampoInteger
                        Get
                            Return f_diascredito
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_diascredito = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento1() As CampoDecimal
                        Get
                            Return f_montodescuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montodescuento1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento2() As CampoDecimal
                        Get
                            Return f_montodescuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montodescuento2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoCargos() As CampoDecimal
                        Get
                            Return f_montocargos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montocargos = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento1() As CampoDecimal
                        Get
                            Return f_porcentajedescuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajedescuento1 = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento2() As CampoDecimal
                        Get
                            Return f_porcentajedescuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajedescuento2 = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaCargos() As CampoDecimal
                        Get
                            Return f_porcentajecargos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajecargos = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoColumna() As CampoTexto
                        Get
                            Return f_columna
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_columna = value
                        End Set
                    End Property

                    Protected Friend Property c_EstatusCompra() As CampoTexto
                        Get
                            Return f_estatuscompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatuscompra = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoFlete() As CampoDecimal
                        Get
                            Return f_montoflete
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoflete = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaFlete() As CampoDecimal
                        Get
                            Return f_porcentajeflete
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeflete = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoSeguro() As CampoDecimal
                        Get
                            Return f_montoseguro
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoseguro = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaSeguro() As CampoDecimal
                        Get
                            Return f_porcentajeseguro
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeseguro = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoArancel() As CampoDecimal
                        Get
                            Return f_montoarancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoarancel = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaArancel() As CampoDecimal
                        Get
                            Return f_porcentajearancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajearancel = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoServicio() As CampoDecimal
                        Get
                            Return f_montoservicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoservicio = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaServicio() As CampoDecimal
                        Get
                            Return f_porcentajeservicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeservicio = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAduana() As CampoDecimal
                        Get
                            Return f_montoaduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoaduana = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaAduana() As CampoDecimal
                        Get
                            Return f_porcentajeaduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeaduana = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAgente() As CampoDecimal
                        Get
                            Return f_montoagente
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoagente = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaAgente() As CampoDecimal
                        Get
                            Return f_porcentajeagente
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeagente = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoGastos() As CampoDecimal
                        Get
                            Return f_montogastos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montogastos = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaGastos() As CampoDecimal
                        Get
                            Return f_porcentajegastos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajegastos = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoOtrosGastos() As CampoDecimal
                        Get
                            Return f_montootrosgastos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montootrosgastos = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaOtrosGastos() As CampoDecimal
                        Get
                            Return f_porcentajeotrosgastos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_porcentajeotrosgastos = value
                        End Set
                    End Property

                    Protected Friend Property c_ExpedienteCompra() As CampoTexto
                        Get
                            Return f_expedientecompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_expedientecompra = value
                        End Set
                    End Property

                    Protected Friend Property c_DocumentoAplica() As CampoTexto
                        Get
                            Return f_aplicadocumento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_aplicadocumento = value
                        End Set
                    End Property

                    Protected Friend Property c_ComprobanteRetencionIva() As CampoTexto
                        Get
                            Return f_comprobanteretencion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comprobanteretencion = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoSubtotal() As CampoDecimal
                        Get
                            Return f_montosubtotal
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montosubtotal = value
                        End Set
                    End Property

                    Protected Friend Property c_TelefonoProveedor() As CampoTexto
                        Get
                            Return f_telefonoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefonoproveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_FactorCambio() As CampoDecimal
                        Get
                            Return f_factorcambio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_factorcambio = value
                        End Set
                    End Property

                    Protected Friend Property c_PlanillaImportacion() As CampoTexto
                        Get
                            Return f_planillaimportacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_planillaimportacion = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRetencionIvaTerceros() As CampoDecimal
                        Get
                            Return f_montoretencionivaterceros
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoretencionivaterceros = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAnticipoIvaImportacion() As CampoDecimal
                        Get
                            Return f_montoanticipoivaimportacion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoanticipoivaimportacion = value
                        End Set
                    End Property

                    Protected Friend Property c_AnoRelacion() As CampoTexto
                        Get
                            Return f_anorelacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_anorelacion = value
                        End Set
                    End Property

                    Protected Friend Property c_ComprobanteRetencionIslr() As CampoTexto
                        Get
                            Return f_comprobanteretencionislr
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comprobanteretencionislr = value
                        End Set
                    End Property

                    Protected Friend Property c_CantidadRenglones() As CampoInteger
                        Get
                            Return f_cantidadrenglones
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_cantidadrenglones = value
                        End Set
                    End Property

                    Protected Friend Property c_SerieDocumento() As CampoTexto
                        Get
                            Return f_n_serie
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_serie = value
                        End Set
                    End Property

                    Protected Friend Property c_SerieDocumentoAplica() As CampoTexto
                        Get
                            Return f_n_serieaplica
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_serieaplica = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_n_auto_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_auto_usuario = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return f_n_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_usuario = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoUsuario() As CampoTexto
                        Get
                            Return f_n_codigo_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_codigo_usuario = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreEstacionEquipo() As CampoTexto
                        Get
                            Return f_n_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_estacion = value
                        End Set
                    End Property

                    Protected Friend Property c_Hora() As CampoTexto
                        Get
                            Return f_n_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_hora = value
                        End Set
                    End Property

                    Protected Friend Property c_Periodo() As CampoInteger
                        Get
                            Return f_n_periodo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_n_periodo = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoCompraRegistrada() As CampoTexto
                        Get
                            Return f_n_tipo_compra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_tipo_compra = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuestoLicor() As CampoDecimal
                        Get
                            Return f_n_montoimplicor
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_montoimplicor = value
                        End Set
                    End Property

                    Protected Friend Property c_ConceptoGasto() As CampoTexto
                        Get
                            Return f_n_concepto_gasto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_concepto_gasto = value
                        End Set
                    End Property


                    ReadOnly Property _AutoDocumentoCompra() As String
                        Get
                            Return c_AutoDocumentoCompra.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumentoCompra() As String
                        Get
                            Return c_NumeroDocumentoCompra.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return c_FechaEmision.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _FechaVencimiento() As Date
                        Get
                            Return c_FechaVencimiento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NombreProveedor() As String
                        Get
                            Return c_NombreProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _DirFiscalProveedor() As String
                        Get
                            Return c_DirFiscalProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifProveedor() As String
                        Get
                            Return c_CiRifProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumentoCompra() As TipoDocumentoCompra
                        Get
                            Select Case c_TipoDocumentoCompra.c_Texto.Trim.ToUpper
                                Case "01" : Return TipoDocumentoCompra.Factura
                                Case "02" : Return TipoDocumentoCompra.NotaDebito
                                Case "03" : Return TipoDocumentoCompra.NotaCredito
                                Case "04" : Return TipoDocumentoCompra.OrdenCompra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _MontoExento() As Decimal
                        Get
                            Return c_MontoExento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _BaseImpuestoTasa1() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase1.c_Valor, c_MontoImpuesto1.c_Valor, c_Tasa1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _BaseImpuestoTasa2() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase2.c_Valor, c_MontoImpuesto2.c_Valor, c_Tasa2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _BaseImpuestoTasa3() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase3.c_Valor, c_MontoImpuesto3.c_Valor, c_Tasa3.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _MontoTotalBase() As Decimal
                        Get
                            Return c_MontoTotalBase.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoTotalImpuesto() As Decimal
                        Get
                            Return c_MontoTotalImpuesto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TotalGeneral() As Decimal
                        Get
                            Return c_TotalGeneral.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasDetalleCompra() As String
                        Get
                            Return c_NotasDetalleCompra.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _RetencionIva() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaRetencionIva.c_Valor, c_MontoRetencionIva.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _RetencionIslr() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaRetencionIslr.c_Valor, c_MontoRetencionIslr.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return c_AutoProveedor.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return c_CodigoProveedor.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _MesRelacion() As String
                        Get
                            Return c_MesRelacion.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _Genero() As String
                        Get
                            Return c_Genero.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NumeroControlDocumento() As String
                        Get
                            Return c_NumeroControlDocumento.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _FechaCarga() As Date
                        Get
                            Return c_FechaCarga.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NumeroOrdenCompra() As String
                        Get
                            Return c_NumeroOrdenCompra.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _DiasCredito() As Integer
                        Get
                            Return c_DiasCredito.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Descuento1() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento1.c_Valor, c_MontoDescuento1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento2() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento2.c_Valor, c_MontoDescuento2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Cargos() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaCargos.c_Valor, c_MontoCargos.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _TipoColumna() As String
                        Get
                            Return c_TipoColumna.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _EstatusCompra() As TipoEstatus
                        Get
                            Select Case c_EstatusCompra.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                                Case "2" : Return TipoEstatus.Procesado
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _GastosFlete() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaFlete.c_Valor, c_MontoFlete.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosSeguro() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaSeguro.c_Valor, c_MontoSeguro.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosArancel() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaArancel.c_Valor, c_MontoArancel.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosServicio() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaServicio.c_Valor, c_MontoServicio.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosAduana() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaAduana.c_Valor, c_MontoAduana.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosAgenteAduanal() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaAgente.c_Valor, c_MontoAgente.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Gastos() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaGastos.c_Valor, c_MontoGastos.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _OtrosGastos() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaOtrosGastos.c_Valor, c_MontoOtrosGastos.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _ExpedienteCompra() As String
                        Get
                            Return c_ExpedienteCompra.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _DocumentoAplica() As String
                        Get
                            Return c_DocumentoAplica.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ComprobanteRetencionIva() As String
                        Get
                            Return c_ComprobanteRetencionIva.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoSubtotal() As Decimal
                        Get
                            Return c_MontoSubtotal.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TelefonoProveedor() As String
                        Get
                            Return c_TelefonoProveedor.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _FactorCambio() As Decimal
                        Get
                            Return c_FactorCambio.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PlanillaImportacion() As String
                        Get
                            Return c_PlanillaImportacion.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _MontoRetencionIvaTerceros() As Decimal
                        Get
                            Return c_MontoRetencionIvaTerceros.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoAnticipoIvaImportacion() As Decimal
                        Get
                            Return c_MontoAnticipoIvaImportacion.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AnoRelacion() As Integer
                        Get
                            Dim xv As Integer = 0
                            Integer.TryParse(Me.c_AnoRelacion.c_Texto, xv)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _ComprobanteRetencionIslr() As String
                        Get
                            Return c_ComprobanteRetencionIslr.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _CantidadRenglones() As Integer
                        Get
                            Return c_CantidadRenglones.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _SerieDocumento() As String
                        Get
                            Return c_SerieDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _SerieDocumentoAplica() As String
                        Get
                            Return c_SerieDocumentoAplica.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoUsuario() As String
                        Get
                            Return c_CodigoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEstacionEquipo() As String
                        Get
                            Return c_NombreEstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Return c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Periodo() As Integer
                        Get
                            Return c_Periodo.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoCompraRegistrada() As TipoCompraRegistrada
                        Get
                            If f_n_tipo_compra.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoCompraRegistrada.CompraMercancia
                            Else
                                Return TipoCompraRegistrada.CompraGasto
                            End If
                        End Get
                    End Property

                    ReadOnly Property _MontoImpuestoLicor() As Decimal
                        Get
                            Return Me.c_MontoImpuestoLicor.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _ConceptoGasto() As String
                        Get
                            Return Me.c_ConceptoGasto.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        c_AutoDocumentoCompra = New CampoTexto(10, "auto")
                        c_NumeroDocumentoCompra = New CampoTexto(15, "documento")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_FechaVencimiento = New CampoFecha("fecha_vencimiento")
                        c_NombreProveedor = New CampoTexto(120, "nombre")
                        c_DirFiscalProveedor = New CampoTexto(120, "dir_fiscal")
                        c_CiRifProveedor = New CampoTexto(12, "ci_rif")
                        c_TipoDocumentoCompra = New CampoTexto(2, "Tipo")
                        c_MontoExento = New CampoDecimal("exento")
                        c_MontoBase1 = New CampoDecimal("base1")
                        c_MontoBase2 = New CampoDecimal("base2")
                        c_MontoBase3 = New CampoDecimal("base3")
                        c_MontoImpuesto1 = New CampoDecimal("impuesto1")
                        c_MontoImpuesto2 = New CampoDecimal("impuesto2")
                        c_MontoImpuesto3 = New CampoDecimal("impuesto3")
                        c_MontoTotalBase = New CampoDecimal("base")
                        c_MontoTotalImpuesto = New CampoDecimal("impuesto")
                        c_TotalGeneral = New CampoDecimal("total")
                        c_Tasa1 = New CampoDecimal("tasa1")
                        c_Tasa2 = New CampoDecimal("tasa2")
                        c_Tasa3 = New CampoDecimal("tasa3")
                        c_NotasDetalleCompra = New CampoTexto(120, "nota")
                        c_TasaRetencionIva = New CampoDecimal("tasa_retencion_iva")
                        c_TasaRetencionIslr = New CampoDecimal("tasa_retencion_islr")
                        c_MontoRetencionIva = New CampoDecimal("retencion_iva")
                        c_MontoRetencionIslr = New CampoDecimal("retencion_islr")
                        c_AutoProveedor = New CampoTexto(10, "auto_entidad")
                        c_CodigoProveedor = New CampoTexto(15, "codigo_entidad")
                        c_MesRelacion = New CampoTexto(2, "mes_relacion")
                        c_Genero = New CampoTexto(10, "genero")
                        c_NumeroControlDocumento = New CampoTexto(15, "control")
                        c_FechaCarga = New CampoFecha("Fecha_carga")
                        c_NumeroOrdenCompra = New CampoTexto(10, "orden_compra")
                        c_DiasCredito = New CampoInteger("dias")
                        c_MontoDescuento1 = New CampoDecimal("descuento1")
                        c_MontoDescuento2 = New CampoDecimal("descuento2")
                        c_MontoCargos = New CampoDecimal("cargos")
                        c_TasaDescuento1 = New CampoDecimal("descuento1_porcentaje")
                        c_TasaDescuento2 = New CampoDecimal("descuento2_porcentaje")
                        c_TasaCargos = New CampoDecimal("cargos_porcentaje")
                        c_TipoColumna = New CampoTexto(1, "columna")
                        c_EstatusCompra = New CampoTexto(1, "estatus")
                        c_MontoFlete = New CampoDecimal("flete")
                        c_TasaFlete = New CampoDecimal("fletep")
                        c_MontoSeguro = New CampoDecimal("seguro")
                        c_TasaSeguro = New CampoDecimal("segurop")
                        c_MontoArancel = New CampoDecimal("arancel")
                        c_TasaArancel = New CampoDecimal("arancelp")
                        c_MontoServicio = New CampoDecimal("servicio")
                        c_TasaServicio = New CampoDecimal("serviciop")
                        c_MontoAduana = New CampoDecimal("aduana")
                        c_TasaAduana = New CampoDecimal("aduanap")
                        c_MontoAgente = New CampoDecimal("agente")
                        c_TasaAgente = New CampoDecimal("agentep")
                        c_MontoGastos = New CampoDecimal("gastos")
                        c_TasaGastos = New CampoDecimal("gastosp")
                        c_MontoOtrosGastos = New CampoDecimal("otros")
                        c_TasaOtrosGastos = New CampoDecimal("otrosp")
                        c_ExpedienteCompra = New CampoTexto(20, "expediente")
                        c_DocumentoAplica = New CampoTexto(10, "aplica")
                        c_ComprobanteRetencionIva = New CampoTexto(14, "comprobante_retencion")
                        c_MontoSubtotal = New CampoDecimal("subtotal")
                        c_TelefonoProveedor = New CampoTexto(50, "telefono")
                        c_FactorCambio = New CampoDecimal("factor_cambio")
                        c_PlanillaImportacion = New CampoTexto(13, "planilla_importacion")
                        c_MontoRetencionIvaTerceros = New CampoDecimal("retencion_iva_terceros")
                        c_MontoAnticipoIvaImportacion = New CampoDecimal("anticipo_iva_importacion")
                        c_AnoRelacion = New CampoTexto(4, "ano_relacion")
                        c_ComprobanteRetencionIslr = New CampoTexto(10, "comprobante_retencion_islr")
                        c_CantidadRenglones = New CampoInteger("renglones")
                        c_SerieDocumento = New CampoTexto(10, "n_serie")
                        c_SerieDocumentoAplica = New CampoTexto(10, "n_serieaplica")
                        c_AutoUsuario = New CampoTexto(10, "n_auto_usuario")
                        c_NombreUsuario = New CampoTexto(20, "n_usuario")
                        c_CodigoUsuario = New CampoTexto(10, "n_codigo_usuario")
                        c_NombreEstacionEquipo = New CampoTexto(20, "n_estacion")
                        c_Hora = New CampoTexto(10, "n_hora")
                        c_Periodo = New CampoInteger("n_periodo")
                        c_TipoCompraRegistrada = New CampoTexto(1, "n_tipo_compra")
                        c_MontoImpuestoLicor = New CampoDecimal("n_montoimplicor")
                        c_ConceptoGasto = New CampoTexto(40, "n_concepto_gasto")

                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub M_CargarData(ByVal xdatarow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()

                            c_AutoDocumentoCompra.c_Texto = xdatarow(c_AutoDocumentoCompra.c_NombreInterno)
                            c_NumeroDocumentoCompra.c_Texto = xdatarow(c_NumeroDocumentoCompra.c_NombreInterno)
                            c_FechaEmision.c_Valor = xdatarow(c_FechaEmision.c_NombreInterno)
                            c_FechaVencimiento.c_Valor = xdatarow(c_FechaVencimiento.c_NombreInterno)
                            c_NombreProveedor.c_Texto = xdatarow(c_NombreProveedor.c_NombreInterno)
                            c_DirFiscalProveedor.c_Texto = xdatarow(c_DirFiscalProveedor.c_NombreInterno)
                            c_CiRifProveedor.c_Texto = xdatarow(c_CiRifProveedor.c_NombreInterno)
                            c_TipoDocumentoCompra.c_Texto = xdatarow(c_TipoDocumentoCompra.c_NombreInterno)
                            c_MontoExento.c_Valor = xdatarow(c_MontoExento.c_NombreInterno)
                            c_MontoBase1.c_Valor = xdatarow(c_MontoBase1.c_NombreInterno)
                            c_MontoBase2.c_Valor = xdatarow(c_MontoBase2.c_NombreInterno)
                            c_MontoBase3.c_Valor = xdatarow(c_MontoBase3.c_NombreInterno)
                            c_MontoImpuesto1.c_Valor = xdatarow(c_MontoImpuesto1.c_NombreInterno)
                            c_MontoImpuesto2.c_Valor = xdatarow(c_MontoImpuesto2.c_NombreInterno)
                            c_MontoImpuesto3.c_Valor = xdatarow(c_MontoImpuesto3.c_NombreInterno)
                            c_MontoTotalBase.c_Valor = xdatarow(c_MontoTotalBase.c_NombreInterno)
                            c_MontoTotalImpuesto.c_Valor = xdatarow(c_MontoTotalImpuesto.c_NombreInterno)
                            c_TotalGeneral.c_Valor = xdatarow(c_TotalGeneral.c_NombreInterno)
                            c_Tasa1.c_Valor = xdatarow(c_Tasa1.c_NombreInterno)
                            c_Tasa2.c_Valor = xdatarow(c_Tasa2.c_NombreInterno)
                            c_Tasa3.c_Valor = xdatarow(c_Tasa3.c_NombreInterno)
                            c_NotasDetalleCompra.c_Texto = xdatarow(c_NotasDetalleCompra.c_NombreInterno)
                            c_TasaRetencionIva.c_Valor = xdatarow(c_TasaRetencionIva.c_NombreInterno)
                            c_TasaRetencionIslr.c_Valor = xdatarow(c_TasaRetencionIslr.c_NombreInterno)
                            c_MontoRetencionIva.c_Valor = xdatarow(c_MontoRetencionIva.c_NombreInterno)
                            c_MontoRetencionIslr.c_Valor = xdatarow(c_MontoRetencionIslr.c_NombreInterno)
                            c_AutoProveedor.c_Texto = xdatarow(c_AutoProveedor.c_NombreInterno)
                            c_CodigoProveedor.c_Texto = xdatarow(c_CodigoProveedor.c_NombreInterno)
                            c_MesRelacion.c_Texto = xdatarow(c_MesRelacion.c_NombreInterno)
                            c_Genero.c_Texto = xdatarow(c_Genero.c_NombreInterno)
                            c_NumeroControlDocumento.c_Texto = xdatarow(c_NumeroControlDocumento.c_NombreInterno)
                            c_FechaCarga.c_Valor = xdatarow(c_FechaCarga.c_NombreInterno)
                            c_NumeroOrdenCompra.c_Texto = xdatarow(c_NumeroOrdenCompra.c_NombreInterno)
                            c_DiasCredito.c_Valor = xdatarow(c_DiasCredito.c_NombreInterno)
                            c_MontoDescuento1.c_Valor = xdatarow(c_MontoDescuento1.c_NombreInterno)
                            c_MontoDescuento2.c_Valor = xdatarow(c_MontoDescuento2.c_NombreInterno)
                            c_MontoCargos.c_Valor = xdatarow(c_MontoCargos.c_NombreInterno)
                            c_TasaDescuento1.c_Valor = xdatarow(c_TasaDescuento1.c_NombreInterno)
                            c_TasaDescuento2.c_Valor = xdatarow(c_TasaDescuento2.c_NombreInterno)
                            c_TasaCargos.c_Valor = xdatarow(c_TasaCargos.c_NombreInterno)
                            c_TipoColumna.c_Texto = xdatarow(c_TipoColumna.c_NombreInterno)
                            c_EstatusCompra.c_Texto = xdatarow(c_EstatusCompra.c_NombreInterno)
                            c_MontoFlete.c_Valor = xdatarow(c_MontoFlete.c_NombreInterno)
                            c_TasaFlete.c_Valor = xdatarow(c_TasaFlete.c_NombreInterno)
                            c_MontoSeguro.c_Valor = xdatarow(c_MontoSeguro.c_NombreInterno)
                            c_TasaSeguro.c_Valor = xdatarow(c_TasaSeguro.c_NombreInterno)
                            c_MontoArancel.c_Valor = xdatarow(c_MontoArancel.c_NombreInterno)
                            c_TasaArancel.c_Valor = xdatarow(c_TasaArancel.c_NombreInterno)
                            c_MontoServicio.c_Valor = xdatarow(c_MontoServicio.c_NombreInterno)
                            c_TasaServicio.c_Valor = xdatarow(c_TasaServicio.c_NombreInterno)
                            c_MontoAduana.c_Valor = xdatarow(c_MontoAduana.c_NombreInterno)
                            c_TasaAduana.c_Valor = xdatarow(c_TasaAduana.c_NombreInterno)
                            c_MontoAgente.c_Valor = xdatarow(c_MontoAgente.c_NombreInterno)
                            c_TasaAgente.c_Valor = xdatarow(c_TasaAgente.c_NombreInterno)
                            c_MontoGastos.c_Valor = xdatarow(c_MontoGastos.c_NombreInterno)
                            c_TasaGastos.c_Valor = xdatarow(c_TasaGastos.c_NombreInterno)
                            c_MontoOtrosGastos.c_Valor = xdatarow(c_MontoOtrosGastos.c_NombreInterno)
                            c_TasaOtrosGastos.c_Valor = xdatarow(c_TasaOtrosGastos.c_NombreInterno)
                            c_ExpedienteCompra.c_Texto = xdatarow(c_ExpedienteCompra.c_NombreInterno)
                            c_DocumentoAplica.c_Texto = xdatarow(c_DocumentoAplica.c_NombreInterno)
                            c_ComprobanteRetencionIva.c_Texto = xdatarow(c_ComprobanteRetencionIva.c_NombreInterno)
                            c_MontoSubtotal.c_Valor = xdatarow(c_MontoSubtotal.c_NombreInterno)
                            c_TelefonoProveedor.c_Texto = xdatarow(c_TelefonoProveedor.c_NombreInterno)
                            c_FactorCambio.c_Valor = xdatarow(c_FactorCambio.c_NombreInterno)
                            c_PlanillaImportacion.c_Texto = xdatarow(c_PlanillaImportacion.c_NombreInterno)
                            c_MontoRetencionIvaTerceros.c_Valor = xdatarow(c_MontoRetencionIvaTerceros.c_NombreInterno)
                            c_MontoAnticipoIvaImportacion.c_Valor = xdatarow(c_MontoAnticipoIvaImportacion.c_NombreInterno)
                            c_AnoRelacion.c_Texto = xdatarow(c_AnoRelacion.c_NombreInterno)
                            c_ComprobanteRetencionIslr.c_Texto = xdatarow(c_ComprobanteRetencionIslr.c_NombreInterno)
                            c_CantidadRenglones.c_Valor = xdatarow(c_CantidadRenglones.c_NombreInterno)

                            If Not IsDBNull(xdatarow(c_SerieDocumento.c_NombreInterno)) Then
                                c_SerieDocumento.c_Texto = xdatarow(c_SerieDocumento.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_SerieDocumentoAplica.c_NombreInterno)) Then
                                c_SerieDocumentoAplica.c_Texto = xdatarow(c_SerieDocumentoAplica.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_AutoUsuario.c_NombreInterno)) Then
                                c_AutoUsuario.c_Texto = xdatarow(c_AutoUsuario.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_NombreUsuario.c_NombreInterno)) Then
                                c_NombreUsuario.c_Texto = xdatarow(c_NombreUsuario.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_CodigoUsuario.c_NombreInterno)) Then
                                c_CodigoUsuario.c_Texto = xdatarow(c_CodigoUsuario.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_NombreEstacionEquipo.c_NombreInterno)) Then
                                c_NombreEstacionEquipo.c_Texto = xdatarow(c_NombreEstacionEquipo.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_Hora.c_NombreInterno)) Then
                                c_Hora.c_Texto = xdatarow(c_Hora.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_Periodo.c_NombreInterno)) Then
                                c_Periodo.c_Valor = xdatarow(c_Periodo.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_TipoCompraRegistrada.c_NombreInterno)) Then
                                c_TipoCompraRegistrada.c_Texto = xdatarow(c_TipoCompraRegistrada.c_NombreInterno)
                            Else
                                c_TipoCompraRegistrada.c_Texto = "1"
                            End If

                            If Not IsDBNull(xdatarow(c_MontoImpuestoLicor.c_NombreInterno)) Then
                                c_MontoImpuestoLicor.c_Valor = xdatarow(c_MontoImpuestoLicor.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_ConceptoGasto.c_NombreInterno)) Then
                                c_ConceptoGasto.c_Texto = xdatarow(c_ConceptoGasto.c_NombreInterno)
                            End If

                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "CARGAR FICHA REGISTRO" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    Function fn_RetornarPeriodo() As Integer
                        If c_FechaCarga.c_Valor.Day > 15 Then
                            Return 2
                        Else
                            Return 1
                        End If
                    End Function

                    Function fn_AnoRelacion() As String
                        Return Year(c_FechaCarga.c_Valor).ToString
                    End Function

                    Function fn_MesRelacion() As String
                        Return Month(c_FechaCarga.c_Valor).ToString.Trim.PadLeft(2, "0")
                    End Function

                    Function fn_FechaVencimiento() As Date
                        Return DateAdd(DateInterval.Day, c_DiasCredito.c_Valor, c_FechaEmision.c_Valor)
                    End Function
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
                    Me.RegistroDato = New c_Registro
                End Sub

                Function F_CargarCompra(ByVal xauto As String) As Boolean
                    Dim xtb As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from compras where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(xtb)
                        End Using
                        If (xtb.Rows.Count >= 1) Then
                            M_CargarRegistro(xtb.Rows.Item(0))
                            Return True
                        Else
                            Throw New Exception("AUTOMATICO DEL DOCUMENTO DE COMPRA NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "CARGAR COMPRAS" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.M_CargarData(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Public Class c_ComprasDetalle
                Class AgregarDetalleCompra
                    Private xfichadetallecompras As c_Registro
                    Private xfichaprd As FichaProducto.Prd_Producto.c_Registro
                    Private xfichadeposito As FichaGlobal.c_Depositos.c_Registro
                    Private xcantidad As Decimal
                    Private xpromocion As Decimal
                    Private xtasa_descuento1 As Decimal
                    Private xtasa_descuento2 As Decimal
                    Private xtasa_descuento3 As Decimal
                    Private xmonto_descuento1 As Decimal
                    Private xmonto_descuento2 As Decimal
                    Private xmonto_descuento3 As Decimal
                    Private ximporte As Decimal
                    Private xcostobruto As Decimal
                    Private xpreciosugerido As Decimal
                    Private xprd_codigoproveedor As String
                    Private xnotasdetalle As String
                    Private xcosto As Decimal
                    Private xmontoimplicor As Decimal
                    Private xvalor_CostoActual As Decimal
                    Private xvalor_CostoReferencia As Decimal
                    Private xcontenidoempaque As Integer
                    Private xauto_medida As String
                    Private xnombre_medida As String
                    Private xforzar_medida As Boolean
                    Private xnumerodecimales_medida As Integer


                    Protected Friend Property _ValorCostoActual() As Decimal
                        Get
                            Return Me.xvalor_CostoActual
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xvalor_CostoActual = value
                        End Set
                    End Property

                    Protected Friend Property _ValorCostoReferencia() As Decimal
                        Get
                            Return Me.xvalor_CostoReferencia
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xvalor_CostoReferencia = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _ValorCostoReferenciaInventario() As Decimal
                        Get
                            Dim x As Decimal = Me._ValorCostoReferencia / Me._ContenidoEmpaque
                            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                            Return x
                        End Get
                    End Property

                    Protected Friend Property _FichaRegistroDetalleCompra() As c_Registro
                        Get
                            Return Me.xfichadetallecompras
                        End Get
                        Set(ByVal value As c_Registro)
                            Me.xfichadetallecompras = value
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

                    Property _FichaDeposito() As FichaGlobal.c_Depositos.c_Registro
                        Get
                            Return Me.xfichadeposito
                        End Get
                        Set(ByVal value As FichaGlobal.c_Depositos.c_Registro)
                            Me.xfichadeposito = value
                        End Set
                    End Property

                    Property _CantidadCompra() As Decimal
                        Get
                            Return Me.xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcantidad = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _CantidadCompraInventario() As Decimal
                        Get
                            Return (Me._ContenidoEmpaque * Me._CantidadCompra)
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TotalUnidadesInventarioEntrarDeposito() As Decimal
                        Get
                            Dim x As Decimal = (Me._CantidadCompra + Me._CantidadPromo) * Me._ContenidoEmpaque
                            Return x
                        End Get
                    End Property

                    Property _CantidadPromo() As Decimal
                        Get
                            Return Me.xpromocion
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xpromocion = value
                        End Set
                    End Property

                    Property _TasaDescuento1() As Decimal
                        Get
                            Return Me.xtasa_descuento1
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_descuento1 = value
                        End Set
                    End Property

                    Property _TasaDescuento2() As Decimal
                        Get
                            Return Me.xtasa_descuento2
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_descuento2 = value
                        End Set
                    End Property

                    Property _TasaDescuento3() As Decimal
                        Get
                            Return Me.xtasa_descuento3
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_descuento3 = value
                        End Set
                    End Property

                    Property _MontoDescuento1() As Decimal
                        Get
                            Return Me.xmonto_descuento1
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto_descuento1 = value
                        End Set
                    End Property

                    Property _MontoDescuento2() As Decimal
                        Get
                            Return Me.xmonto_descuento2
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto_descuento2 = value
                        End Set
                    End Property

                    Property _MontoDescuento3() As Decimal
                        Get
                            Return Me.xmonto_descuento3
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto_descuento3 = value
                        End Set
                    End Property

                    'TOTAL NETO YA CON LOS DESCUENTOS LINEALES
                    Property _TotalImporte() As Decimal
                        Get
                            Return Me.ximporte
                        End Get
                        Set(ByVal value As Decimal)
                            Me.ximporte = value
                        End Set
                    End Property

                    Property _CostoBruto() As Decimal
                        Get
                            Return Me.xcostobruto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcostobruto = value
                        End Set
                    End Property

                    Property _PrecioSugerido() As Decimal
                        Get
                            Return Me.xpreciosugerido
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xpreciosugerido = value
                        End Set
                    End Property

                    Property _NotasDetalles() As String
                        Get
                            Return Me.xnotasdetalle
                        End Get
                        Set(ByVal value As String)
                            Me.xnotasdetalle = value
                        End Set
                    End Property

                    'COSTO BRUTO YA CON DESCUENTOS LINEALES
                    Property _CostoItem() As String
                        Get
                            Return Me.xcosto
                        End Get
                        Set(ByVal value As String)
                            Me.xcosto = value
                        End Set
                    End Property

                    Property _ProductoCodigoProveedor() As String
                        Get
                            Return Me.xprd_codigoproveedor
                        End Get
                        Set(ByVal value As String)
                            Me.xprd_codigoproveedor = value
                        End Set
                    End Property

                    Property _MontoImpuestoLicor() As Decimal
                        Get
                            Return Me.xmontoimplicor
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmontoimplicor = value
                        End Set
                    End Property

                    Property _ContenidoEmpaque() As Integer
                        Get
                            Return xcontenidoempaque
                        End Get
                        Set(ByVal value As Integer)
                            xcontenidoempaque = value
                        End Set
                    End Property

                    Property _AutoMedidaEmpaque() As String
                        Get
                            Return Me.xauto_medida
                        End Get
                        Set(ByVal value As String)
                            Me.xauto_medida = value
                        End Set
                    End Property

                    Property _NombreMedidaEmpaque() As String
                        Get
                            Return Me.xnombre_medida
                        End Get
                        Set(ByVal value As String)
                            Me.xnombre_medida = value
                        End Set
                    End Property

                    Property _ForzarMedidaEmpaque() As Boolean
                        Get
                            Return Me.xforzar_medida
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xforzar_medida = value
                        End Set
                    End Property

                    Property _NumeroDecimalesMedidaEmpaque() As Integer
                        Get
                            Return Me.xnumerodecimales_medida
                        End Get
                        Set(ByVal value As Integer)
                            Me.xnumerodecimales_medida = value
                        End Set
                    End Property


                    Sub New()
                        Me._CantidadCompra = 0
                        Me._CantidadPromo = 0
                        Me._CostoBruto = 0
                        Me._CostoItem = 0
                        Me._FichaDeposito = Nothing
                        Me._FichaProducto = Nothing
                        Me._MontoDescuento1 = 0
                        Me._MontoDescuento2 = 0
                        Me._MontoDescuento3 = 0
                        Me._NotasDetalles = ""
                        Me._PrecioSugerido = 0
                        Me._ProductoCodigoProveedor = ""
                        Me._TasaDescuento1 = 0
                        Me._TasaDescuento2 = 0
                        Me._TasaDescuento3 = 0
                        Me._TotalImporte = 0
                        Me._MontoImpuestoLicor = 0
                        Me._FichaRegistroDetalleCompra = New c_Registro
                        Me._ValorCostoActual = 0
                        Me._ValorCostoReferencia = 0
                        Me._ContenidoEmpaque = 0
                        Me._AutoMedidaEmpaque = ""
                        Me._NombreMedidaEmpaque = ""
                        Me._NumeroDecimalesMedidaEmpaque = 0
                        Me._ForzarMedidaEmpaque = False
                    End Sub
                End Class

                Class AgregarDetalleNC
                    Dim xitemorigen As c_ComprasDetalle.c_Registro
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

                    WriteOnly Property _Cantidad() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CantidadCompra.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoNeto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CostoBruto.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaDescuento1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento3.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Importe() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TotalNeto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _NotasItem() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NotasItem.c_Texto = value
                        End Set
                    End Property
                    Property _ItemDetalleOrigen() As c_ComprasDetalle.c_Registro
                        Get
                            Return xitemorigen
                        End Get
                        Set(ByVal value As c_ComprasDetalle.c_Registro)
                            xitemorigen = value
                        End Set
                    End Property
                    WriteOnly Property _TipoMovimiento() As TipoMovimientoCompraDetalle
                        Set(ByVal value As TipoMovimientoCompraDetalle)
                            Select Case value
                                Case TipoMovimientoCompraDetalle.Ajuste
                                    Me.RegistroDato.c_TipoMovimiento.c_Texto = "A"
                                Case TipoMovimientoCompraDetalle.AjusteGlobal
                                    Me.RegistroDato.c_TipoMovimiento.c_Texto = "G"
                                Case TipoMovimientoCompraDetalle.Devolucion
                                    Me.RegistroDato.c_TipoMovimiento.c_Texto = "D"
                                Case TipoMovimientoCompraDetalle.Compra
                                    Me.RegistroDato.c_TipoMovimiento.c_Texto = "C"
                            End Select
                        End Set
                    End Property
                End Class

                Public Class c_Registro
                    Private f_autodetallecompra As CampoTexto
                    Private f_autodocumentocompra As CampoTexto
                    Private f_autoproductos As CampoTexto
                    Private f_codigoproducto As CampoTexto
                    Private f_nombreproducto As CampoTexto
                    Private f_autodepartamento As CampoTexto
                    Private f_autogrupo As CampoTexto
                    Private f_autosubgrupo As CampoTexto
                    Private f_autodeposito As CampoTexto
                    Private f_cantidadcompra As CampoDecimal
                    Private f_bono As CampoDecimal
                    Private f_empaque As CampoTexto
                    Private f_costobruto As CampoDecimal
                    Private f_tasadescuento1 As CampoDecimal
                    Private f_tasadescuento2 As CampoDecimal
                    Private f_tasadescuento3 As CampoDecimal
                    Private f_montodescuento1 As CampoDecimal
                    Private f_montodescuento2 As CampoDecimal
                    Private f_montodescuento3 As CampoDecimal
                    Private f_costo As CampoDecimal
                    Private f_totalneto As CampoDecimal
                    Private f_tasaiva As CampoDecimal
                    Private f_montoimpuesto As CampoDecimal
                    Private f_montototal As CampoDecimal
                    Private f_codigoarancel As CampoTexto
                    Private f_montoarancel As CampoDecimal
                    Private f_tasaarancel As CampoDecimal
                    Private f_montoservicio As CampoDecimal
                    Private f_tasaservicio As CampoDecimal
                    Private f_montoaduana As CampoDecimal
                    Private f_tasaaduana As CampoDecimal
                    Private f_tipotasa As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fechaemision As CampoFecha
                    Private f_tipodocumento As CampoTexto
                    Private f_nombredeposito As CampoTexto
                    Private f_signo As CampoInteger
                    Private f_costofinal As CampoDecimal
                    Private f_autoproveedor As CampoTexto
                    Private f_cantidaddecimales As CampoTexto
                    Private f_contenidoempaque As CampoInteger
                    Private f_cantidadcompraunidadinventario As CampoDecimal
                    Private f_costoinventario As CampoDecimal
                    Private f_montoflete As CampoDecimal
                    Private f_montoseguro As CampoDecimal
                    Private f_montootrosgastos As CampoDecimal
                    Private f_costoimportacion As CampoDecimal
                    Private f_valorfob As CampoDecimal
                    Private f_valorcif As CampoDecimal
                    Private f_codigodeposito As CampoTexto
                    Private f_empaquetipo As CampoTexto
                    Private f_detalle As CampoTexto
                    Private f_categoriaproducto As CampoTexto
                    Private f_codigoproveedor As CampoTexto

                    'CAMPOS NUEVOS, QUE SE AGREGARON
                    Private f_n_espesado As CampoTexto
                    Private f_n_forzarmedida As CampoTexto
                    Private f_n_automedida As CampoTexto
                    Private f_n_tipomovimiento As CampoTexto
                    Private f_n_periodo As CampoInteger
                    Private f_n_montoimplicor As CampoDecimal
                    Private f_n_psugerido As CampoDecimal

                    Protected Friend Property c_AutoDetalleCompra() As CampoTexto
                        Get
                            Return f_autodetallecompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autodetallecompra = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoDocumentoCompra() As CampoTexto
                        Get
                            Return f_autodocumentocompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autodocumentocompra = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_autoproductos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoproductos = value
                        End Set
                    End Property
                    Protected Friend Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigoproducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigoproducto = value
                        End Set
                    End Property
                    Protected Friend Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_nombreproducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreproducto = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoDepartamento() As CampoTexto
                        Get
                            Return f_autodepartamento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autodepartamento = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_autogrupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autogrupo = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoSubgrupo() As CampoTexto
                        Get
                            Return f_autosubgrupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autosubgrupo = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoDeposito() As CampoTexto
                        Get
                            Return f_autodeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autodeposito = value
                        End Set
                    End Property
                    Protected Friend Property c_CantidadCompra() As CampoDecimal
                        Get
                            Return f_cantidadcompra
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidadcompra = value
                        End Set
                    End Property
                    Protected Friend Property c_Bono() As CampoDecimal
                        Get
                            Return f_bono
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_bono = value
                        End Set
                    End Property
                    Protected Friend Property c_Empaque() As CampoTexto
                        Get
                            Return f_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque = value
                        End Set
                    End Property
                    Protected Friend Property c_CostoBruto() As CampoDecimal
                        Get
                            Return f_costobruto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costobruto = value
                        End Set
                    End Property
                    Property c_TasaDescuento1() As CampoDecimal
                        Get
                            Return f_tasadescuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasadescuento1 = value
                        End Set
                    End Property
                    Property c_TasaDescuento2() As CampoDecimal
                        Get
                            Return f_tasadescuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasadescuento2 = value
                        End Set
                    End Property
                    Property c_TasaDescuento3() As CampoDecimal
                        Get
                            Return f_tasadescuento3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasadescuento3 = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoDescuento1() As CampoDecimal
                        Get
                            Return f_montodescuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montodescuento1 = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoDescuento2() As CampoDecimal
                        Get
                            Return f_montodescuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montodescuento2 = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoDescuento3() As CampoDecimal
                        Get
                            Return f_montodescuento3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montodescuento3 = value
                        End Set
                    End Property
                    Protected Friend Property c_Costo() As CampoDecimal
                        Get
                            Return f_costo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo = value
                        End Set
                    End Property
                    Protected Friend Property c_TotalNeto() As CampoDecimal
                        Get
                            Return f_totalneto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_totalneto = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_tasaiva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaiva = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoImpuesto() As CampoDecimal
                        Get
                            Return f_montoimpuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoimpuesto = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoTotal() As CampoDecimal
                        Get
                            Return f_montototal
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montototal = value
                        End Set
                    End Property
                    Protected Friend Property c_CodigoArancel() As CampoTexto
                        Get
                            Return f_codigoarancel
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigoarancel = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoArancel() As CampoDecimal
                        Get
                            Return f_montoarancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoarancel = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaArancel() As CampoDecimal
                        Get
                            Return f_tasaarancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaarancel = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoServicio() As CampoDecimal
                        Get
                            Return f_montoservicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoservicio = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaServicio() As CampoDecimal
                        Get
                            Return f_tasaservicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaservicio = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoAduana() As CampoDecimal
                        Get
                            Return f_montoaduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoaduana = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaAduana() As CampoDecimal
                        Get
                            Return f_tasaaduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaaduana = value
                        End Set
                    End Property
                    Protected Friend Property c_TipoTasa() As CampoTexto
                        Get
                            Return f_tipotasa
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipotasa = value
                        End Set
                    End Property
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property
                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fechaemision
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechaemision = value
                        End Set
                    End Property
                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipodocumento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipodocumento = value
                        End Set
                    End Property
                    Protected Friend Property c_NombreDeposito() As CampoTexto
                        Get
                            Return f_nombredeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombredeposito = value
                        End Set
                    End Property
                    Protected Friend Property c_Signo() As CampoInteger
                        Get
                            Return f_signo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_signo = value
                        End Set
                    End Property
                    Protected Friend Property c_CostoFinal() As CampoDecimal
                        Get
                            Return f_costofinal
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costofinal = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_autoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoproveedor = value
                        End Set
                    End Property
                    Protected Friend Property c_CantidadDecimales() As CampoTexto
                        Get
                            Return f_cantidaddecimales
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cantidaddecimales = value
                        End Set
                    End Property
                    Protected Friend Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenidoempaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenidoempaque = value
                        End Set
                    End Property
                    Protected Friend Property c_CantidadCompraUnidadInventario() As CampoDecimal
                        Get
                            Return f_cantidadcompraunidadinventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidadcompraunidadinventario = value
                        End Set
                    End Property
                    Protected Friend Property c_CostoInventario() As CampoDecimal
                        Get
                            Return f_costoinventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoinventario = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoFlete() As CampoDecimal
                        Get
                            Return f_montoflete
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoflete = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoSeguro() As CampoDecimal
                        Get
                            Return f_montoseguro
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montoseguro = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoOtrosGastos() As CampoDecimal
                        Get
                            Return f_montootrosgastos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_montootrosgastos = value
                        End Set
                    End Property
                    Protected Friend Property c_CostoImportacion() As CampoDecimal
                        Get
                            Return f_costoimportacion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoimportacion = value
                        End Set
                    End Property
                    Protected Friend Property c_ValorFob() As CampoDecimal
                        Get
                            Return f_valorfob
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_valorfob = value
                        End Set
                    End Property
                    Protected Friend Property c_ValorCif() As CampoDecimal
                        Get
                            Return f_valorcif
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_valorcif = value
                        End Set
                    End Property
                    Protected Friend Property c_CodigoDeposito() As CampoTexto
                        Get
                            Return f_codigodeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigodeposito = value
                        End Set
                    End Property
                    Protected Friend Property c_EmpaqueTipo() As CampoTexto
                        Get
                            Return f_empaquetipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaquetipo = value
                        End Set
                    End Property
                    Property c_NotasItem() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property
                    Protected Friend Property c_CategoriaProducto() As CampoTexto
                        Get
                            Return f_categoriaproducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_categoriaproducto = value
                        End Set
                    End Property
                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigoproveedor = value
                        End Set
                    End Property

                    Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_n_automedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_automedida = value
                        End Set
                    End Property

                    Property c_ForzarMedida() As CampoTexto
                        Get
                            Return f_n_forzarmedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_forzarmedida = value
                        End Set
                    End Property

                    Property c_TipoMovimiento() As CampoTexto
                        Get
                            Return f_n_tipomovimiento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_tipomovimiento = value
                        End Set
                    End Property

                    Property c_PTO_EsPesado() As CampoTexto
                        Get
                            Return f_n_espesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_espesado = value
                        End Set
                    End Property

                    Property c_Periodo() As CampoInteger
                        Get
                            Return f_n_periodo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_n_periodo = value
                        End Set
                    End Property

                    Property c_MontoImpuestoLicor() As CampoDecimal
                        Get
                            Return f_n_montoimplicor
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_montoimplicor = value
                        End Set
                    End Property

                    Property c_PrecioSugeridoVenta() As CampoDecimal
                        Get
                            Return f_n_psugerido
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_psugerido = value
                        End Set
                    End Property


                    ReadOnly Property _AutoDetalleCompra() As String
                        Get
                            Return c_AutoDetalleCompra.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoDocumentoCompra() As String
                        Get
                            Return c_AutoDocumentoCompra.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoDepartamento() As String
                        Get
                            Return c_AutoDepartamento.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return c_AutoGrupo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoSubgrupo() As String
                        Get
                            Return c_AutoSubgrupo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return c_AutoDeposito.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CantidadCompra() As Decimal
                        Get
                            Return c_CantidadCompra.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _Bono() As Decimal
                        Get
                            Return c_Bono.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _Empaque() As String
                        Get
                            Return c_Empaque.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CostoBruto() As Decimal
                        Get
                            Return c_CostoBruto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Descuento1() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento1.c_Valor, c_MontoDescuento1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento2() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento2.c_Valor, c_MontoDescuento2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento3() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento3.c_Valor, c_MontoDescuento3.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Costo() As Decimal
                        Get
                            Return c_Costo.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TotalNeto() As Decimal
                        Get
                            Return c_TotalNeto.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return c_TasaIva.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoImpuesto() As Decimal
                        Get
                            Return c_MontoImpuesto.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoTotal() As Decimal
                        Get
                            Return c_MontoTotal.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CodigoArancel() As String
                        Get
                            Return c_CodigoArancel.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _GastosArancel() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaArancel.c_Valor, c_MontoArancel.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosServicio() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaServicio.c_Valor, c_MontoServicio.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _GastosAduana() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaAduana.c_Valor, c_MontoAduana.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As String
                        Get
                            Return c_TipoTasa.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case c_Estatus.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property
                    ReadOnly Property _TipoDocumento() As String
                        Get
                            Return c_TipoDocumento.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreDeposito() As String
                        Get
                            Return c_NombreDeposito.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Signo() As Integer
                        Get
                            Return c_Signo.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _Costofinal() As Decimal
                        Get
                            Return c_CostoFinal.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CantidadDecimales() As Integer
                        Get
                            Return Int(c_CantidadDecimales.c_Texto.Trim)
                        End Get
                    End Property
                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CantidadCompraUnidadInventario() As Decimal
                        Get
                            Return c_CantidadCompraUnidadInventario.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return c_CostoInventario.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoFlete() As Decimal
                        Get
                            Return c_MontoFlete.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoSeguro() As Decimal
                        Get
                            Return c_MontoSeguro.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoOtrosGastos() As Decimal
                        Get
                            Return c_MontoOtrosGastos.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CostoImportacion() As Decimal
                        Get
                            Return c_CostoImportacion.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _ValorFob() As Decimal
                        Get
                            Return c_ValorFob.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _ValorCif() As Decimal
                        Get
                            Return c_ValorCif.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CodigoDeposito() As String
                        Get
                            Return c_CodigoDeposito.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _EmpaqueTipo() As String
                        Get
                            Return c_EmpaqueTipo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NotasItem() As String
                        Get
                            Return c_NotasItem.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CategoriaProducto() As String
                        Get
                            Return c_CategoriaProducto.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return c_CodigoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return Me.c_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ForzarMedida() As Boolean
                        Get
                            Select Case Me.c_ForzarMedida.c_Texto.Trim
                                Case "0"
                                    Return False
                                Case "1"
                                    Return True
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoMovimientoEfectuado() As TipoMovimientoCompraDetalle
                        Get
                            Select Case Me.c_TipoMovimiento.c_Texto.Trim.ToUpper
                                Case "C" : Return TipoMovimientoCompraDetalle.Compra
                                Case "A" : Return TipoMovimientoCompraDetalle.Ajuste
                                Case "D" : Return TipoMovimientoCompraDetalle.Devolucion
                                Case "G" : Return TipoMovimientoCompraDetalle.AjusteGlobal
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _Periodo() As Integer
                        Get
                            Return c_Periodo.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _PTO_EsPesado() As TipoEstatus
                        Get
                            If Me.c_PTO_EsPesado.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' CALCULA EL TOTAL DE UNIDADES EN INVENTARIO A ENTRAR AL DEPOSITO (CANTIDAD COMPRADA+BONO)*EMPAQUE
                    ''' </summary>
                    ReadOnly Property _TotalUnidadesAEntrarInventario() As Decimal
                        Get
                            Dim xr As Decimal
                            xr = (Me._CantidadCompra + Me._Bono) * Me._ContenidoEmpaque
                            Return xr
                        End Get
                    End Property

                    ReadOnly Property _MontoImpuestoLicor() As Decimal
                        Get
                            Return Me.c_MontoImpuestoLicor.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PrecioSugeridoVenta() As Decimal
                        Get
                            Return c_PrecioSugeridoVenta.c_Valor
                        End Get
                    End Property


                    Sub New()
                        c_AutoDetalleCompra = New CampoTexto(10, "auto")
                        c_AutoDocumentoCompra = New CampoTexto(10, "auto_documento")
                        c_AutoProducto = New CampoTexto(10, "auto_productos")
                        c_CodigoProducto = New CampoTexto(15, "codigo")
                        c_NombreProducto = New CampoTexto(200, "nombre")
                        c_AutoDepartamento = New CampoTexto(10, "auto_departamento")
                        c_AutoGrupo = New CampoTexto(10, "auto_grupo")
                        c_AutoSubgrupo = New CampoTexto(10, "auto_subgrupo")
                        c_AutoDeposito = New CampoTexto(10, "auto_deposito")
                        c_CantidadCompra = New CampoDecimal("cantidad")
                        c_Bono = New CampoDecimal("bono")
                        c_Empaque = New CampoTexto(15, "empaque")
                        c_CostoBruto = New CampoDecimal("costo_bruto")
                        c_TasaDescuento1 = New CampoDecimal("descuento1p")
                        c_TasaDescuento2 = New CampoDecimal("descuento2p")
                        c_TasaDescuento3 = New CampoDecimal("descuento3p")
                        c_MontoDescuento1 = New CampoDecimal("descuento1")
                        c_MontoDescuento2 = New CampoDecimal("descuento2")
                        c_MontoDescuento3 = New CampoDecimal("descuento3")
                        c_Costo = New CampoDecimal("costo")
                        c_TotalNeto = New CampoDecimal("total_neto")
                        c_TasaIva = New CampoDecimal("tasa")
                        c_MontoImpuesto = New CampoDecimal("impuesto")
                        c_MontoTotal = New CampoDecimal("total")
                        c_CodigoArancel = New CampoTexto(15, "codigo_arancel")
                        c_MontoArancel = New CampoDecimal("arancel")
                        c_TasaArancel = New CampoDecimal("arancelp")
                        c_TasaServicio = New CampoDecimal("tasa_serviciop")
                        c_MontoServicio = New CampoDecimal("tasa_servicio")
                        c_TasaAduana = New CampoDecimal("tasa_aduanap")
                        c_MontoAduana = New CampoDecimal("tasa_aduana")
                        c_TipoTasa = New CampoTexto(1, "codigo_tasa")
                        c_Estatus = New CampoTexto(1, "estatus")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_TipoDocumento = New CampoTexto(2, "tipo")
                        c_NombreDeposito = New CampoTexto(20, "deposito")
                        c_Signo = New CampoInteger("signo")
                        c_CostoFinal = New CampoDecimal("costo_final")
                        c_AutoProveedor = New CampoTexto(10, "auto_entidad")
                        c_CantidadDecimales = New CampoTexto(1, "decimales")
                        c_ContenidoEmpaque = New CampoInteger("contenido_empaque")
                        c_CantidadCompraUnidadInventario = New CampoDecimal("cantidad_inventario")
                        c_CostoInventario = New CampoDecimal("costo_inventario")
                        c_MontoFlete = New CampoDecimal("flete")
                        c_MontoSeguro = New CampoDecimal("seguro")
                        c_MontoOtrosGastos = New CampoDecimal("otros")
                        c_CostoImportacion = New CampoDecimal("costo_importacion")
                        c_ValorFob = New CampoDecimal("valor_fob")
                        c_ValorCif = New CampoDecimal("valor_cif")
                        c_CodigoDeposito = New CampoTexto(10, "codigo_deposito")
                        c_EmpaqueTipo = New CampoTexto(1, "empaque_tipo")
                        c_NotasItem = New CampoTexto(160, "detalle")
                        c_CategoriaProducto = New CampoTexto(20, "categoria")
                        c_CodigoProveedor = New CampoTexto(15, "codigo_proveedor")

                        c_PTO_EsPesado = New CampoTexto(1, "N_espesado")
                        c_ForzarMedida = New CampoTexto(1, "N_forzarmedida")
                        c_AutoMedida = New CampoTexto(10, "N_automedida")
                        c_TipoMovimiento = New CampoTexto(1, "N_TipoMovimiento")
                        c_Periodo = New CampoInteger("N_periodo")
                        c_MontoImpuestoLicor = New CampoDecimal("N_MontoImpLicor")
                        c_PrecioSugeridoVenta = New CampoDecimal("N_psugerido")

                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub M_CargarData(ByVal xdatarow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()

                            c_AutoDetalleCompra.c_Texto = xdatarow(c_AutoDetalleCompra.c_NombreInterno.Trim)
                            c_AutoDocumentoCompra.c_Texto = xdatarow(c_AutoDocumentoCompra.c_NombreInterno.Trim)
                            c_AutoProducto.c_Texto = xdatarow(c_AutoProducto.c_NombreInterno.Trim)
                            c_CodigoProducto.c_Texto = xdatarow(c_CodigoProducto.c_NombreInterno.Trim)
                            c_NombreProducto.c_Texto = xdatarow(c_NombreProducto.c_NombreInterno.Trim)
                            c_AutoDepartamento.c_Texto = xdatarow(c_AutoDepartamento.c_NombreInterno.Trim)
                            c_AutoGrupo.c_Texto = xdatarow(c_AutoGrupo.c_NombreInterno.Trim)
                            c_AutoSubgrupo.c_Texto = xdatarow(c_AutoSubgrupo.c_NombreInterno.Trim)
                            c_AutoDeposito.c_Texto = xdatarow(c_AutoDeposito.c_NombreInterno.Trim)
                            c_CantidadCompra.c_Valor = xdatarow(c_CantidadCompra.c_NombreInterno.Trim)
                            c_Bono.c_Valor = xdatarow(c_Bono.c_NombreInterno.Trim)
                            c_Empaque.c_Texto = xdatarow(c_Empaque.c_NombreInterno.Trim)
                            c_CostoBruto.c_Valor = xdatarow(c_CostoBruto.c_NombreInterno.Trim)
                            c_TasaDescuento1.c_Valor = xdatarow(c_TasaDescuento1.c_NombreInterno.Trim)
                            c_TasaDescuento2.c_Valor = xdatarow(c_TasaDescuento2.c_NombreInterno.Trim)
                            c_TasaDescuento3.c_Valor = xdatarow(c_TasaDescuento3.c_NombreInterno.Trim)
                            c_MontoDescuento1.c_Valor = xdatarow(c_MontoDescuento1.c_NombreInterno.Trim)
                            c_MontoDescuento2.c_Valor = xdatarow(c_MontoDescuento2.c_NombreInterno.Trim)
                            c_MontoDescuento3.c_Valor = xdatarow(c_MontoDescuento3.c_NombreInterno.Trim)
                            c_Costo.c_Valor = xdatarow(c_Costo.c_NombreInterno.Trim)
                            c_TotalNeto.c_Valor = xdatarow(c_TotalNeto.c_NombreInterno.Trim)
                            c_TasaIva.c_Valor = xdatarow(c_TasaIva.c_NombreInterno.Trim)
                            c_MontoImpuesto.c_Valor = xdatarow(c_MontoImpuesto.c_NombreInterno.Trim)
                            c_MontoTotal.c_Valor = xdatarow(c_MontoTotal.c_NombreInterno.Trim)
                            c_CodigoArancel.c_Texto = xdatarow(c_CodigoArancel.c_NombreInterno.Trim)
                            c_MontoArancel.c_Valor = xdatarow(c_MontoArancel.c_NombreInterno.Trim)
                            c_TasaArancel.c_Valor = xdatarow(c_TasaArancel.c_NombreInterno.Trim)
                            c_TasaServicio.c_Valor = xdatarow(c_TasaServicio.c_NombreInterno.Trim)
                            c_MontoServicio.c_Valor = xdatarow(c_MontoServicio.c_NombreInterno.Trim)
                            c_TasaAduana.c_Valor = xdatarow(c_TasaAduana.c_NombreInterno.Trim)
                            c_MontoAduana.c_Valor = xdatarow(c_MontoAduana.c_NombreInterno.Trim)
                            c_TipoTasa.c_Texto = xdatarow(c_TipoTasa.c_NombreInterno.Trim)
                            c_Estatus.c_Texto = xdatarow(c_Estatus.c_NombreInterno.Trim)
                            c_FechaEmision.c_Valor = xdatarow(c_FechaEmision.c_NombreInterno.Trim)
                            c_TipoDocumento.c_Texto = xdatarow(c_TipoDocumento.c_NombreInterno.Trim)
                            c_NombreDeposito.c_Texto = xdatarow(c_NombreDeposito.c_NombreInterno.Trim)
                            c_Signo.c_Valor = xdatarow(c_Signo.c_NombreInterno.Trim)
                            c_CostoFinal.c_Valor = xdatarow(c_CostoFinal.c_NombreInterno.Trim)
                            c_AutoProveedor.c_Texto = xdatarow(c_AutoProveedor.c_NombreInterno.Trim)
                            c_CantidadDecimales.c_Texto = xdatarow(c_CantidadDecimales.c_NombreInterno.Trim)
                            c_ContenidoEmpaque.c_Valor = xdatarow(c_ContenidoEmpaque.c_NombreInterno.Trim)
                            c_CantidadCompraUnidadInventario.c_Valor = xdatarow(c_CantidadCompraUnidadInventario.c_NombreInterno.Trim)
                            c_CostoInventario.c_Valor = xdatarow(c_CostoInventario.c_NombreInterno.Trim)
                            c_MontoFlete.c_Valor = xdatarow(c_MontoFlete.c_NombreInterno.Trim)
                            c_MontoSeguro.c_Valor = xdatarow(c_MontoSeguro.c_NombreInterno.Trim)
                            c_MontoOtrosGastos.c_Valor = xdatarow(c_MontoOtrosGastos.c_NombreInterno.Trim)
                            c_CostoImportacion.c_Valor = xdatarow(c_CostoImportacion.c_NombreInterno.Trim)
                            c_ValorFob.c_Valor = xdatarow(c_ValorFob.c_NombreInterno.Trim)
                            c_ValorCif.c_Valor = xdatarow(c_ValorCif.c_NombreInterno.Trim)
                            c_CodigoDeposito.c_Texto = xdatarow(c_CodigoDeposito.c_NombreInterno.Trim)
                            c_EmpaqueTipo.c_Texto = xdatarow(c_EmpaqueTipo.c_NombreInterno.Trim)
                            c_NotasItem.c_Texto = xdatarow(c_NotasItem.c_NombreInterno.Trim)
                            c_CategoriaProducto.c_Texto = xdatarow(c_CategoriaProducto.c_NombreInterno.Trim)
                            c_CodigoProveedor.c_Texto = xdatarow(c_CodigoProveedor.c_NombreInterno.Trim)

                            If Not IsDBNull(xdatarow(c_PTO_EsPesado.c_NombreInterno)) Then
                                c_PTO_EsPesado.c_Texto = xdatarow(c_PTO_EsPesado.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_ForzarMedida.c_NombreInterno)) Then
                                c_ForzarMedida.c_Texto = xdatarow(c_ForzarMedida.c_NombreInterno)
                            End If
                            If Not IsDBNull(xdatarow(c_AutoMedida.c_NombreInterno)) Then
                                c_AutoMedida.c_Texto = xdatarow(c_AutoMedida.c_NombreInterno)
                            End If
                            If Not IsDBNull(xdatarow(c_TipoMovimiento.c_NombreInterno)) Then
                                c_TipoMovimiento.c_Texto = xdatarow(c_TipoMovimiento.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_Periodo.c_NombreInterno)) Then
                                c_Periodo.c_Valor = xdatarow(c_Periodo.c_NombreInterno)
                            End If

                            If Not IsDBNull(xdatarow(c_MontoImpuestoLicor.c_NombreInterno)) Then
                                c_MontoImpuestoLicor.c_Valor = xdatarow(c_MontoImpuestoLicor.c_NombreInterno)
                            End If
                            If Not IsDBNull(xdatarow(c_PrecioSugeridoVenta.c_NombreInterno)) Then
                                c_PrecioSugeridoVenta.c_Valor = xdatarow(c_PrecioSugeridoVenta.c_NombreInterno)
                            End If

                        Catch ex As Exception
                            Throw New Exception("COMPRAS DETALLE" + vbCrLf + "CARGAR FICHA DE COMPRA DETALLE" + vbCrLf + ex.Message)
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
                    Me.RegistroDato = New c_Registro
                End Sub

                Function F_CargarCompraDetalle(ByVal xauto As String, ByVal xautodoc As String) As Boolean
                    Dim xtb As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from compras_detalle where auto=@auto and auto_documento=@auto_documento", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto_documento", xautodoc)
                            f_adapter.Fill(xtb)
                        End Using
                        If (xtb.Rows.Count >= 1) Then
                            RegistroDato.M_CargarData(xtb.Rows.Item(0))
                        Else
                            Throw New Exception("AUTOMATICO REGISTRO DETALLE NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "COMPRAS DETALLE" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class


            ''' <summary>
            ''' Permite Procesar Una Compra
            ''' </summary>
            ''' <param name="xgrabarcompra"></param>
            ''' CLASE QUE PERMITE PROCESAR LA COMPRA
            Function F_GrabarCompra(ByVal xgrabarcompra As GrabarCompra)
                Dim xsql_1 As String = "update contadores set a_compras=a_compras+1; select a_compras from contadores"
                Dim xsql_2 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim xsql_3 As String = "update contadores set a_productos_historico_costos=a_productos_historico_costos+1;select a_productos_historico_costos from contadores"

                Dim autocxp As String = ""
                Dim xhistorico As New FichaProducto.Prd_HistoricoCostos.c_Registro

                Dim xproducto As String = ""
                Dim xtr As SqlTransaction = Nothing
                Try
                    Dim xn As Decimal = 0
                    Dim xmd1 As Decimal = 0
                    Dim xmd2 As Decimal = 0
                    Dim xmt As Decimal = 0
                    Dim xb1 As Decimal = 0
                    Dim xb2 As Decimal = 0
                    Dim xb3 As Decimal = 0
                    Dim xexento As Decimal = 0

                    xn = xgrabarcompra._Compra.RegistroDato.c_MontoSubtotal.c_Valor
                    xb1 = xgrabarcompra._Compra.RegistroDato.c_MontoBase1.c_Valor
                    xb2 = xgrabarcompra._Compra.RegistroDato.c_MontoBase2.c_Valor
                    xb3 = xgrabarcompra._Compra.RegistroDato.c_MontoBase3.c_Valor
                    xexento = xgrabarcompra._Compra.RegistroDato.c_MontoExento.c_Valor

                    If xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor > 0 Then
                        Dim xd1 As Decimal = 0
                        Dim xd2 As Decimal = 0
                        Dim xd3 As Decimal = 0
                        Dim xd4 As Decimal = 0
                        xd1 = Decimal.Round((xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd2 = Decimal.Round((xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd3 = Decimal.Round((xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd4 = Decimal.Round((xexento * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xgrabarcompra._Compra.RegistroDato.c_MontoDescuento1.c_Valor = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)

                        xb1 = Decimal.Round(xb1 - (xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb2 = Decimal.Round(xb2 - (xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb3 = Decimal.Round(xb3 - (xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xexento = Decimal.Round(xexento - (xexento * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                    End If

                    If xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor > 0 Then
                        Dim xd1 As Decimal = 0
                        Dim xd2 As Decimal = 0
                        Dim xd3 As Decimal = 0
                        Dim xd4 As Decimal = 0
                        xd1 = Decimal.Round((xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd2 = Decimal.Round((xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd3 = Decimal.Round((xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xd4 = Decimal.Round((xexento * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xgrabarcompra._Compra.RegistroDato.c_MontoDescuento2.c_Valor = Decimal.Round(xd1 + xd2 + xd3 + xd4, 2, MidpointRounding.AwayFromZero)

                        xb1 = Decimal.Round(xb1 - (xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb2 = Decimal.Round(xb2 - (xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb3 = Decimal.Round(xb3 - (xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xexento = Decimal.Round(xexento - (xexento * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                    End If

                    If xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor > 0 Then
                        Dim xc1 As Decimal = 0
                        Dim xc2 As Decimal = 0
                        Dim xc3 As Decimal = 0
                        Dim xc4 As Decimal = 0
                        xc1 = Decimal.Round((xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xc2 = Decimal.Round((xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xc3 = Decimal.Round((xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xc4 = Decimal.Round((xexento * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xgrabarcompra._Compra.RegistroDato.c_MontoCargos.c_Valor = Decimal.Round(xc1 + xc2 + xc3 + xc4, 2, MidpointRounding.AwayFromZero)

                        xb1 = Decimal.Round(xb1 + (xb1 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb2 = Decimal.Round(xb2 + (xb2 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xb3 = Decimal.Round(xb3 + (xb3 * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                        xexento = Decimal.Round(xexento + (xexento * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100), 2, MidpointRounding.AwayFromZero)
                    End If

                    Dim ximp1 As Decimal = 0
                    Dim ximp2 As Decimal = 0
                    Dim ximp3 As Decimal = 0

                    ximp1 = Decimal.Round(xb1 * xgrabarcompra._Compra.RegistroDato.c_Tasa1.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp2 = Decimal.Round(xb2 * xgrabarcompra._Compra.RegistroDato.c_Tasa2.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp3 = Decimal.Round(xb3 * xgrabarcompra._Compra.RegistroDato.c_Tasa3.c_Valor / 100, 2, MidpointRounding.AwayFromZero)

                    xgrabarcompra._Compra.RegistroDato.c_MontoBase1.c_Valor = xb1
                    xgrabarcompra._Compra.RegistroDato.c_MontoBase2.c_Valor = xb2
                    xgrabarcompra._Compra.RegistroDato.c_MontoBase3.c_Valor = xb3
                    xgrabarcompra._Compra.RegistroDato.c_MontoTotalBase.c_Valor = Decimal.Round(xb1 + xb2 + xb3, 2, MidpointRounding.AwayFromZero)
                    xgrabarcompra._Compra.RegistroDato.c_MontoExento.c_Valor = xexento
                    xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto1.c_Valor = ximp1
                    xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto2.c_Valor = ximp2
                    xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto3.c_Valor = ximp3
                    xgrabarcompra._Compra.RegistroDato.c_MontoTotalImpuesto.c_Valor = Decimal.Round(ximp1 + ximp2 + ximp3, 2, MidpointRounding.AwayFromZero)
                    xgrabarcompra._Compra.RegistroDato.c_TotalGeneral.c_Valor = xgrabarcompra._Compra.RegistroDato.c_MontoExento.c_Valor + _
                                                               xgrabarcompra._Compra.RegistroDato.c_MontoTotalBase.c_Valor + xgrabarcompra._Compra.RegistroDato.c_MontoTotalImpuesto.c_Valor

                    With xgrabarcompra._Compra.RegistroDato
                        .c_FechaVencimiento.c_Valor = .fn_FechaVencimiento
                        .c_MesRelacion.c_Texto = .fn_MesRelacion
                        .c_TipoColumna.c_Texto = "1"
                        .c_EstatusCompra.c_Texto = "0"
                        .c_AnoRelacion.c_Texto = .fn_AnoRelacion
                        .c_Periodo.c_Valor = .fn_RetornarPeriodo
                        .c_AutoUsuario.c_Texto = xgrabarcompra._Compra._Usuario._AutoUsuario
                        .c_CodigoUsuario.c_Texto = xgrabarcompra._Compra._Usuario._CodigoUsuario
                        .c_NombreUsuario.c_Texto = xgrabarcompra._Compra._Usuario._NombreUsuario
                        .c_TipoCompraRegistrada.c_Texto = xgrabarcompra._TipoCompraRegistrada
                        .c_TotalGeneral.c_Valor += .c_MontoImpuestoLicor.c_Valor
                        .c_TotalGeneral.c_Valor = Decimal.Round(.c_TotalGeneral.c_Valor, 2, MidpointRounding.AwayFromZero)
                        .c_ConceptoGasto.c_Texto = xgrabarcompra._ConceptoGasto
                    End With

                    Dim xauto As Integer = 0
                    For Each xdetalle In xgrabarcompra._CompraDetalle
                        xauto += 1

                        With xdetalle._FichaRegistroDetalleCompra
                            .c_AutoDepartamento.c_Texto = xdetalle._FichaProducto._AutoDepartamento
                            .c_AutoDeposito.c_Texto = xdetalle._FichaDeposito._Automatico
                            .c_AutoDetalleCompra.c_Texto = xauto.ToString.Trim.PadLeft(10, "0")
                            .c_AutoGrupo.c_Texto = xdetalle._FichaProducto._AutoGrupo
                            .c_AutoMedida.c_Texto = xdetalle._AutoMedidaEmpaque
                            .c_AutoProducto.c_Texto = xdetalle._FichaProducto._AutoProducto
                            .c_AutoProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._Automatico
                            .c_AutoSubgrupo.c_Texto = xdetalle._FichaProducto._AutoSubGrupo
                            .c_Bono.c_Valor = xdetalle._CantidadPromo
                            .c_CantidadCompra.c_Valor = xdetalle._CantidadCompra
                            .c_CantidadCompraUnidadInventario.c_Valor = xdetalle._CantidadCompraInventario
                            .c_CantidadDecimales.c_Texto = xdetalle._NumeroDecimalesMedidaEmpaque.ToString
                            .c_CategoriaProducto.c_Texto = xdetalle._FichaProducto._CategoriaDelProducto
                            .c_CodigoArancel.c_Texto = ""
                            .c_CodigoDeposito.c_Texto = xdetalle._FichaDeposito._Codigo
                            .c_CodigoProducto.c_Texto = xdetalle._FichaProducto._CodigoProducto
                            .c_CodigoProveedor.c_Texto = xdetalle._ProductoCodigoProveedor
                            .c_ContenidoEmpaque.c_Valor = xdetalle._ContenidoEmpaque
                            .c_Costo.c_Valor = xdetalle._CostoItem
                            .c_CostoBruto.c_Valor = xdetalle._CostoBruto
                            .c_CostoImportacion.c_Valor = 0
                            .c_Empaque.c_Texto = xdetalle._NombreMedidaEmpaque
                            .c_EmpaqueTipo.c_Texto = "1"
                            .c_Estatus.c_Texto = "0"
                            .c_FechaEmision.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaEmision.c_Valor
                            .c_ForzarMedida.c_Texto = IIf(xdetalle._ForzarMedidaEmpaque, "1", "0")
                            .c_MontoAduana.c_Valor = 0
                            .c_MontoArancel.c_Valor = 0
                            .c_MontoDescuento1.c_Valor = xdetalle._MontoDescuento1
                            .c_MontoDescuento2.c_Valor = xdetalle._MontoDescuento2
                            .c_MontoDescuento3.c_Valor = xdetalle._MontoDescuento3
                            .c_MontoFlete.c_Valor = 0
                            .c_MontoOtrosGastos.c_Valor = 0
                            .c_MontoSeguro.c_Valor = 0
                            .c_MontoServicio.c_Valor = 0
                            .c_NombreDeposito.c_Texto = xdetalle._FichaDeposito._Nombre
                            .c_NombreProducto.c_Texto = xdetalle._FichaProducto._DescripcionDetallaDelProducto
                            .c_NotasItem.c_Texto() = xdetalle._NotasDetalles
                            .c_Periodo.c_Valor = xgrabarcompra._Compra.RegistroDato.fn_RetornarPeriodo
                            .c_PTO_EsPesado.c_Texto = IIf(xdetalle._FichaProducto._EsPesado, "1", "0")
                            .c_Signo.c_Valor = 1
                            .c_TasaAduana.c_Valor = 0
                            .c_TasaArancel.c_Valor = 0
                            .c_TasaDescuento1.c_Valor = xdetalle._TasaDescuento1
                            .c_TasaDescuento2.c_Valor = xdetalle._TasaDescuento2
                            .c_TasaDescuento3.c_Valor = xdetalle._TasaDescuento3
                            .c_TasaIva.c_Valor = xdetalle._FichaProducto._TasaImpuesto
                            .c_TasaServicio.c_Valor = 0
                            .c_TasaDescuento1.c_Valor = xdetalle._TasaDescuento1
                            .c_TasaDescuento2.c_Valor = xdetalle._TasaDescuento2
                            .c_TasaDescuento3.c_Valor = xdetalle._TasaDescuento3
                            .c_TasaIva.c_Valor = xdetalle._FichaProducto._TasaImpuesto
                            .c_TasaServicio.c_Valor = 0
                            .c_TipoDocumento.c_Texto = xgrabarcompra._Compra.RegistroDato.c_TipoDocumentoCompra.c_Texto
                            .c_TipoMovimiento.c_Texto = "C"
                            .c_TipoTasa.c_Texto = xdetalle._FichaProducto.c_TipoImpuesto.c_Texto
                            .c_TotalNeto.c_Valor = xdetalle._TotalImporte
                            .c_ValorCif.c_Valor = 0
                            .c_ValorFob.c_Valor = 0
                            .c_MontoImpuestoLicor.c_Valor = xdetalle._MontoImpuestoLicor
                            .c_PrecioSugeridoVenta.c_Valor = xdetalle._PrecioSugerido


                            'COSTO FINAL DEL PRODUCTO. YA CON LOS DESCUENTOS Y CARGOS GLOBALES DEL DOCUMENTO
                            Dim xcosfin As Decimal = .c_Costo.c_Valor
                            If xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor > 0 Then
                                xcosfin = xcosfin - (xcosfin * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor / 100)
                            End If
                            If xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor > 0 Then
                                xcosfin = xcosfin - (xcosfin * xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor / 100)
                            End If
                            If xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor > 0 Then
                                xcosfin = xcosfin + (xcosfin * xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor / 100)
                            End If
                            xcosfin += xdetalle._MontoImpuestoLicor
                            .c_CostoFinal.c_Valor = Decimal.Round(xcosfin, 2, MidpointRounding.AwayFromZero)
                            .c_CostoInventario.c_Valor = Decimal.Round(.c_CostoFinal.c_Valor / .c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)

                            'IMPUESTO Y TOTAL GENERAL
                            Dim ximp As Decimal = 0
                            Dim xnet As Decimal = 0
                            xnet = ._TotalNeto
                            ximp = Decimal.Round(._TotalNeto * .c_TasaIva.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                            .c_MontoImpuesto.c_Valor = ximp
                            .c_MontoTotal.c_Valor = Decimal.Round(xnet + ximp, 2, MidpointRounding.AwayFromZero)

                            'CARGO COSTO ACTUAL DEL PRODUCTO
                            Dim xobj As Object = Nothing
                            Using xconn As New SqlConnection(_MiCadenaConexion)
                                xconn.Open()
                                Using xcmd As New SqlCommand("", xconn)
                                    xcmd.CommandText = "select costo_compra from productos where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle._FichaProducto._AutoProducto).Size = xdetalle._FichaProducto.c_Automatico.c_Largo
                                    xobj = xcmd.ExecuteScalar
                                End Using
                            End Using
                            If xobj IsNot Nothing And Not IsDBNull(xobj) Then
                                If xobj = 0 Then
                                    'xdetalle._ValorCostoActual = xcosfin
                                    xdetalle._ValorCostoActual = (.c_CostoInventario.c_Valor * xdetalle._FichaProducto._ContEmpqCompra)
                                Else
                                    xdetalle._ValorCostoActual = xobj
                                End If
                            End If

                            'VERIFICO CUAL SERA EL NUEVO COSTO DE REFERENCIA
                            xobj = Nothing
                            Using xconn As New SqlConnection(_MiCadenaConexion)
                                xconn.Open()
                                Using xcmd As New SqlCommand("", xconn)
                                    xcmd.CommandText = "select max(fecha_emision) from productos_historico_costos where auto_producto=@auto_producto and (costo_actual+costo_nuevo+costo)>0"
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdetalle._FichaProducto._AutoProducto).Size = xdetalle._FichaProducto.c_Automatico.c_Largo
                                    xobj = xcmd.ExecuteScalar
                                End Using
                            End Using
                            If xobj IsNot Nothing And Not IsDBNull(xobj) Then
                                If ._FechaEmision >= xobj Then
                                    'xdetalle._ValorCostoReferencia = xcosfin
                                    xdetalle._ValorCostoReferencia = (.c_CostoInventario.c_Valor * xdetalle._FichaProducto._ContEmpqCompra)
                                Else
                                    xdetalle._ValorCostoReferencia = xdetalle._ValorCostoActual
                                End If
                            Else
                                'xdetalle._ValorCostoReferencia = xcosfin
                                xdetalle._ValorCostoReferencia = (.c_CostoInventario.c_Valor * xdetalle._FichaProducto._ContEmpqCompra)
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
                                'ACTUALIZO CONTADOR AUTOMATICO DE COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_1
                                xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'ACTUALIZA CONTADOR AUTOMATICO CXP
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                autocxp = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_COMPRAS
                                xcmd.Parameters.AddWithValue("@auto", xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xgrabarcompra._Compra.RegistroDato.c_NumeroDocumentoCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NumeroDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xgrabarcompra._Compra.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xgrabarcompra._Compra.RegistroDato.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xgrabarcompra._Compra._Proveedor._NombreRazonSocial).Size = xgrabarcompra._Compra.RegistroDato.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_fiscal", xgrabarcompra._Compra._Proveedor._DirFiscal).Size = xgrabarcompra._Compra.RegistroDato.c_DirFiscalProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xgrabarcompra._Compra._Proveedor._CiRif).Size = xgrabarcompra._Compra.RegistroDato.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo", xgrabarcompra._Compra.RegistroDato.c_TipoDocumentoCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_TipoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@exento", xgrabarcompra._Compra.RegistroDato.c_MontoExento.c_Valor)
                                xcmd.Parameters.AddWithValue("@base1", xgrabarcompra._Compra.RegistroDato.c_MontoBase1.c_Valor)
                                xcmd.Parameters.AddWithValue("@base2", xgrabarcompra._Compra.RegistroDato.c_MontoBase2.c_Valor)
                                xcmd.Parameters.AddWithValue("@base3", xgrabarcompra._Compra.RegistroDato.c_MontoBase3.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto1", xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto1.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto2", xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto2.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto3", xgrabarcompra._Compra.RegistroDato.c_MontoImpuesto3.c_Valor)
                                xcmd.Parameters.AddWithValue("@base", xgrabarcompra._Compra.RegistroDato.c_MontoTotalBase.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto", xgrabarcompra._Compra.RegistroDato.c_MontoTotalImpuesto.c_Valor)
                                xcmd.Parameters.AddWithValue("@total", xgrabarcompra._Compra.RegistroDato.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa1", xgrabarcompra._Compra.RegistroDato.c_Tasa1.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa2", xgrabarcompra._Compra.RegistroDato.c_Tasa2.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa3", xgrabarcompra._Compra.RegistroDato.c_Tasa3.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xgrabarcompra._Compra.RegistroDato.c_NotasDetalleCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NotasDetalleCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xgrabarcompra._Compra.RegistroDato.c_TasaRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xgrabarcompra._Compra.RegistroDato.c_TasaRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_iva", xgrabarcompra._Compra.RegistroDato.c_MontoRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_islr", xgrabarcompra._Compra.RegistroDato.c_MontoRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabarcompra._Compra._Proveedor._Automatico).Size = xgrabarcompra._Compra.RegistroDato.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_entidad", xgrabarcompra._Compra._Proveedor._CodigoProveedor).Size = xgrabarcompra._Compra.RegistroDato.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@mes_relacion", xgrabarcompra._Compra.RegistroDato.c_MesRelacion.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_MesRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@genero", xgrabarcompra._Compra.RegistroDato.c_Genero.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_Genero.c_Largo
                                xcmd.Parameters.AddWithValue("@control", xgrabarcompra._Compra.RegistroDato.c_NumeroControlDocumento.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NumeroControlDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_carga", xgrabarcompra._Compra.RegistroDato.c_FechaCarga.c_Valor)
                                xcmd.Parameters.AddWithValue("@orden_compra", xgrabarcompra._Compra.RegistroDato.c_NumeroOrdenCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NumeroOrdenCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@dias", xgrabarcompra._Compra.RegistroDato.c_DiasCredito.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1", xgrabarcompra._Compra.RegistroDato.c_MontoDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2", xgrabarcompra._Compra.RegistroDato.c_MontoDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos", xgrabarcompra._Compra.RegistroDato.c_MontoCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xgrabarcompra._Compra.RegistroDato.c_TasaDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xgrabarcompra._Compra.RegistroDato.c_TasaDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos_porcentaje", xgrabarcompra._Compra.RegistroDato.c_TasaCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@columna", xgrabarcompra._Compra.RegistroDato.c_TipoColumna.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_TipoColumna.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xgrabarcompra._Compra.RegistroDato.c_EstatusCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_EstatusCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@flete", xgrabarcompra._Compra.RegistroDato.c_MontoFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@fletep", xgrabarcompra._Compra.RegistroDato.c_TasaFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@seguro", xgrabarcompra._Compra.RegistroDato.c_MontoSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@segurop", xgrabarcompra._Compra.RegistroDato.c_TasaSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancel", xgrabarcompra._Compra.RegistroDato.c_MontoArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancelp", xgrabarcompra._Compra.RegistroDato.c_TasaArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@servicio", xgrabarcompra._Compra.RegistroDato.c_MontoServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@serviciop", xgrabarcompra._Compra.RegistroDato.c_TasaServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduana", xgrabarcompra._Compra.RegistroDato.c_MontoAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduanap", xgrabarcompra._Compra.RegistroDato.c_TasaAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@agente", xgrabarcompra._Compra.RegistroDato.c_MontoAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@agentep", xgrabarcompra._Compra.RegistroDato.c_TasaAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastos", xgrabarcompra._Compra.RegistroDato.c_MontoGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastosp", xgrabarcompra._Compra.RegistroDato.c_TasaGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otros", xgrabarcompra._Compra.RegistroDato.c_MontoOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otrosp", xgrabarcompra._Compra.RegistroDato.c_TasaOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@expediente", xgrabarcompra._Compra.RegistroDato.c_ExpedienteCompra.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_ExpedienteCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xgrabarcompra._Compra.RegistroDato.c_DocumentoAplica.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion", xgrabarcompra._Compra.RegistroDato.c_ComprobanteRetencionIva.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_ComprobanteRetencionIva.c_Largo
                                xcmd.Parameters.AddWithValue("@subtotal", xgrabarcompra._Compra.RegistroDato.c_MontoSubtotal.c_Valor)
                                xcmd.Parameters.AddWithValue("@telefono", xgrabarcompra._Compra._Proveedor._Telefono_1).Size = xgrabarcompra._Compra.RegistroDato.c_TelefonoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@factor_cambio", xgrabarcompra._Compra.RegistroDato.c_FactorCambio.c_Valor)
                                xcmd.Parameters.AddWithValue("@planilla_importacion", xgrabarcompra._Compra.RegistroDato.c_PlanillaImportacion.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_PlanillaImportacion.c_Largo
                                xcmd.Parameters.AddWithValue("@retencion_iva_terceros", xgrabarcompra._Compra.RegistroDato.c_MontoRetencionIvaTerceros.c_Valor)
                                xcmd.Parameters.AddWithValue("@anticipo_iva_importacion", xgrabarcompra._Compra.RegistroDato.c_MontoAnticipoIvaImportacion.c_Valor)
                                xcmd.Parameters.AddWithValue("@ano_relacion", xgrabarcompra._Compra.RegistroDato.c_AnoRelacion.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_AnoRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xgrabarcompra._Compra.RegistroDato.c_ComprobanteRetencionIslr.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_ComprobanteRetencionIslr.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serie", xgrabarcompra._Compra.RegistroDato.c_SerieDocumento.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_SerieDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serieaplica", xgrabarcompra._Compra.RegistroDato.c_SerieDocumentoAplica.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_SerieDocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@n_auto_usuario", xgrabarcompra._Compra.RegistroDato.c_AutoUsuario.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_AutoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_codigo_usuario", xgrabarcompra._Compra.RegistroDato.c_CodigoUsuario.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_usuario", xgrabarcompra._Compra.RegistroDato.c_NombreUsuario.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_estacion", xgrabarcompra._Compra.RegistroDato.c_NombreEstacionEquipo.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_NombreEstacionEquipo.c_Largo
                                xcmd.Parameters.AddWithValue("@n_hora", xgrabarcompra._Compra.RegistroDato.c_Hora.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_Hora.c_Largo
                                xcmd.Parameters.AddWithValue("@n_periodo", xgrabarcompra._Compra.RegistroDato.c_Periodo.c_Valor)
                                xcmd.Parameters.AddWithValue("@renglones", xgrabarcompra._Compra.RegistroDato.c_CantidadRenglones.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_tipo_compra", xgrabarcompra._Compra.RegistroDato.c_TipoCompraRegistrada.c_Texto).Size = xgrabarcompra._Compra.RegistroDato.c_TipoCompraRegistrada.c_Largo
                                xcmd.Parameters.AddWithValue("@n_montoimplicor", xgrabarcompra._Compra.RegistroDato.c_MontoImpuestoLicor.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_concepto_gasto", xgrabarcompra._Compra.RegistroDato.c_ConceptoGasto.c_Texto)
                                xcmd.ExecuteNonQuery()

                                'CXP
                                Dim xcxp As New FichaCtasPagar.c_CxP.c_Registro
                                With xcxp
                                    .c_AutoProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._Automatico
                                    .c_AutoCxP.c_Texto = autocxp
                                    .c_AutoDocumento.c_Texto = xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                    .c_CiRifProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaEmision.c_Valor
                                    .c_FechaVencimiento.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaVencimiento.c_Valor
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xgrabarcompra._Compra.RegistroDato.c_TotalGeneral.c_Valor
                                    .c_MontoPorPagar.c_Valor = xgrabarcompra._Compra.RegistroDato.c_TotalGeneral.c_Valor
                                    .c_NombreProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._NombreRazonSocial
                                    .c_NotaDetalle.c_Texto = "DOCUMENTO DE COMPRA"
                                    .c_NumeroDocumento.c_Texto = xgrabarcompra._Compra.RegistroDato.c_NumeroDocumentoCompra.c_Texto
                                    .c_TipoDocumento.c_Texto = "FAC"
                                    .c_TipoOperacion.c_Texto = ""
                                    .c_Signo.c_Valor = 1
                                    .c_FechaProceso.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaCarga.c_Valor

                                    'NUEVOS
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = ""
                                    .c_FechaRecepcionDevolucion.c_Valor = Date.MinValue
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreTitular.c_Texto = ""
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroCuenta.c_Texto = ""
                                    .c_TipoCuenta.c_Texto = ""
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaCtasPagar.INSERT_CXP
                                xcmd.Parameters.AddWithValue("@auto", xcxp.c_AutoCxP.c_Texto).Size = xcxp.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xcxp.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_carga", xcxp.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xcxp.c_TipoDocumento.c_Texto).Size = xcxp.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xcxp.c_NumeroDocumento.c_Texto).Size = xcxp.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxp.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xcxp.c_NotaDetalle.c_Texto).Size = xcxp.c_NotaDetalle.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xcxp.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xcxp.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcxp.c_AutoProveedor.c_Texto).Size = xcxp.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@proveedor", xcxp.c_NombreProveedor.c_Texto).Size = xcxp.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xcxp.c_CiRifProveedor.c_Texto).Size = xcxp.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xcxp.c_CodigoProveedor.c_Texto).Size = xcxp.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xcxp.c_EstatusCancelado.c_Texto).Size = xcxp.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xcxp.c_MontoPorPagar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xcxp.c_TipoOperacion.c_Texto).Size = xcxp.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xcxp.c_EstatusDocumento.c_Texto).Size = xcxp.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xcxp.c_AutoDocumento.c_Texto).Size = xcxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xcxp.c_Signo.c_Valor)

                                'nuevos
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxp.c_AutoMovimientoEntrada.c_Texto).Size = xcxp.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.Add("@fecha_recepcion_devolucion", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null
                                xcmd.Parameters.AddWithValue("@numero", xcxp.c_Numero.c_Texto).Size = xcxp.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xcxp.c_AutoAgencia.c_Texto).Size = xcxp.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xcxp.c_NumeroCuenta.c_Texto).Size = xcxp.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xcxp.c_TipoCuenta.c_Texto).Size = xcxp.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xcxp.c_NombreTitular.c_Texto).Size = xcxp.c_NombreTitular.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xcxp.c_NombreAgencia.c_Texto).Size = xcxp.c_NombreAgencia.c_Largo
                                xcmd.ExecuteNonQuery()

                                'BUSCAR EL CONCEPTO ADECUADO PARA EL TIPO DE DOCUMENTO
                                Dim auto_concepto As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto from productos_conceptos where codigo='COMPRAS'"
                                auto_concepto = xcmd.ExecuteScalar()
                                If (auto_concepto Is Nothing) Or IsDBNull(auto_concepto) Then
                                    Throw New Exception("CONCEPTO 'COMPRAS' NO ESTA DEFINIDO EN LA TABLA CONCEPTOS DE MOVIMIENTO DEL INVENTARIO")
                                End If

                                Dim xconcepto As String = ""
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select nombre from productos_conceptos where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", auto_concepto)
                                xconcepto = xcmd.ExecuteScalar

                                For Each xdetalle In xgrabarcompra._CompraDetalle
                                    xproducto = xdetalle._FichaProducto._DescripcionDetallaDelProducto
                                    xdetalle._FichaRegistroDetalleCompra.c_AutoDocumentoCompra.c_Texto = xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto

                                    'COMPRAS_DETALLE
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_COMPRAS_DETALLE
                                    xcmd.Parameters.AddWithValue("@auto_documento", xdetalle._FichaRegistroDetalleCompra.c_AutoDocumentoCompra.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoDocumentoCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_productos", xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xdetalle._FichaRegistroDetalleCompra.c_CodigoProducto.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CodigoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xdetalle._FichaRegistroDetalleCompra.c_NombreProducto.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_NombreProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_departamento", xdetalle._FichaRegistroDetalleCompra.c_AutoDepartamento.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoDepartamento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xdetalle._FichaRegistroDetalleCompra.c_AutoGrupo.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_subgrupo", xdetalle._FichaRegistroDetalleCompra.c_AutoSubgrupo.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoSubgrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdetalle._FichaRegistroDetalleCompra.c_AutoDeposito.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad", xdetalle._FichaRegistroDetalleCompra.c_CantidadCompra.c_Valor)
                                    xcmd.Parameters.AddWithValue("@bono", xdetalle._FichaRegistroDetalleCompra.c_Bono.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xdetalle._FichaRegistroDetalleCompra.c_Empaque.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_Empaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@costo_bruto", xdetalle._FichaRegistroDetalleCompra.c_CostoBruto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_final", xdetalle._FichaRegistroDetalleCompra.c_CostoFinal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1p", xdetalle._FichaRegistroDetalleCompra.c_TasaDescuento1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2p", xdetalle._FichaRegistroDetalleCompra.c_TasaDescuento2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento3p", xdetalle._FichaRegistroDetalleCompra.c_TasaDescuento3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1", xdetalle._FichaRegistroDetalleCompra.c_MontoDescuento1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2", xdetalle._FichaRegistroDetalleCompra.c_MontoDescuento2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento3", xdetalle._FichaRegistroDetalleCompra.c_MontoDescuento3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo", xdetalle._FichaRegistroDetalleCompra.c_Costo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total_neto", xdetalle._FichaRegistroDetalleCompra.c_TotalNeto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa", xdetalle._FichaRegistroDetalleCompra.c_TasaIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto", xdetalle._FichaRegistroDetalleCompra.c_MontoImpuesto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total", xdetalle._FichaRegistroDetalleCompra.c_MontoTotal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle._FichaRegistroDetalleCompra.c_AutoDetalleCompra.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoDetalleCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_arancel", xdetalle._FichaRegistroDetalleCompra.c_CodigoArancel.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CodigoArancel.c_Largo
                                    xcmd.Parameters.AddWithValue("@arancel", xdetalle._FichaRegistroDetalleCompra.c_MontoArancel.c_Valor)
                                    xcmd.Parameters.AddWithValue("@arancelp", xdetalle._FichaRegistroDetalleCompra.c_TasaArancel.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_servicio", xdetalle._FichaRegistroDetalleCompra.c_TasaServicio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_serviciop", xdetalle._FichaRegistroDetalleCompra.c_MontoServicio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_aduana", xdetalle._FichaRegistroDetalleCompra.c_TasaAduana.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_aduanap", xdetalle._FichaRegistroDetalleCompra.c_MontoAduana.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_tasa", xdetalle._FichaRegistroDetalleCompra.c_TipoTasa.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_TipoTasa.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xdetalle._FichaRegistroDetalleCompra.c_Estatus.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xdetalle._FichaRegistroDetalleCompra.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo", xdetalle._FichaRegistroDetalleCompra.c_TipoDocumento.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@deposito", xdetalle._FichaRegistroDetalleCompra.c_NombreDeposito.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_NombreDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xdetalle._FichaRegistroDetalleCompra.c_Signo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xdetalle._FichaRegistroDetalleCompra.c_AutoProveedor.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProveedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@decimales", xdetalle._FichaRegistroDetalleCompra.c_CantidadDecimales.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CantidadDecimales.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xdetalle._FichaRegistroDetalleCompra.c_ContenidoEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xdetalle._FichaRegistroDetalleCompra.c_CantidadCompraUnidadInventario.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_inventario", xdetalle._FichaRegistroDetalleCompra.c_CostoInventario.c_Valor)
                                    xcmd.Parameters.AddWithValue("@flete", xdetalle._FichaRegistroDetalleCompra.c_MontoFlete.c_Valor)
                                    xcmd.Parameters.AddWithValue("@seguro", xdetalle._FichaRegistroDetalleCompra.c_MontoSeguro.c_Valor)
                                    xcmd.Parameters.AddWithValue("@otros", xdetalle._FichaRegistroDetalleCompra.c_MontoOtrosGastos.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_importacion", xdetalle._FichaRegistroDetalleCompra.c_CostoImportacion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@valor_fob", xdetalle._FichaRegistroDetalleCompra.c_ValorFob.c_Valor)
                                    xcmd.Parameters.AddWithValue("@valor_cif", xdetalle._FichaRegistroDetalleCompra.c_ValorCif.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_deposito", xdetalle._FichaRegistroDetalleCompra.c_CodigoDeposito.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CodigoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@empaque_tipo", xdetalle._FichaRegistroDetalleCompra.c_EmpaqueTipo.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_EmpaqueTipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@detalle", xdetalle._FichaRegistroDetalleCompra.c_NotasItem.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_NotasItem.c_Largo
                                    xcmd.Parameters.AddWithValue("@categoria", xdetalle._FichaRegistroDetalleCompra.c_CategoriaProducto.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CategoriaProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_proveedor", xdetalle._FichaRegistroDetalleCompra.c_CodigoProveedor.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_CodigoProveedor.c_Largo
                                    'CAMPOS NUEVOS
                                    xcmd.Parameters.AddWithValue("@N_espesado", xdetalle._FichaRegistroDetalleCompra.c_PTO_EsPesado.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_PTO_EsPesado.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_automedida", xdetalle._FichaRegistroDetalleCompra.c_AutoMedida.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_forzarmedida", xdetalle._FichaRegistroDetalleCompra.c_ForzarMedida.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_ForzarMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_TipoMovimiento", xdetalle._FichaRegistroDetalleCompra.c_TipoMovimiento.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_TipoMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_periodo", xdetalle._FichaRegistroDetalleCompra.c_Periodo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@N_montoimplicor", xdetalle._FichaRegistroDetalleCompra.c_MontoImpuestoLicor.c_Valor)
                                    xcmd.Parameters.AddWithValue("@N_psugerido", xdetalle._FichaRegistroDetalleCompra.c_PrecioSugeridoVenta.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    If xdetalle._FichaRegistroDetalleCompra._CostoBruto <> 0 Then
                                        'ACTUALIZO/VERIFICO CONTADORES HISTORICO DE COSTOS
                                        Dim xobj1 As Object = Nothing
                                        xcmd.CommandText = "select a_productos_historico_costos from contadores"
                                        xobj1 = xcmd.ExecuteScalar()
                                        If IsDBNull(xobj1) Then
                                            xcmd.CommandText = "update contadores set a_productos_historico_costos=0"
                                            xcmd.ExecuteNonQuery()
                                        End If
                                        xcmd.CommandText = xsql_3
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                        'PRODUCTOS_HISTORICO_COSTOS
                                        With xhistorico
                                            .c_AutoDocumento.c_Texto = xdetalle._FichaRegistroDetalleCompra._AutoDocumentoCompra
                                            .c_AutoProducto.c_Texto = xdetalle._FichaRegistroDetalleCompra._AutoProducto
                                            .c_AutoUsuario.c_Texto = xgrabarcompra._Compra.RegistroDato._AutoUsuario
                                            .c_AutoEntidad.c_Texto = xgrabarcompra._Compra._Proveedor._Automatico
                                            .c_CodigoUsuario.c_Texto = xgrabarcompra._Compra.RegistroDato._CodigoUsuario
                                            .c_ContenidoEmpaque.c_Valor = xdetalle._FichaRegistroDetalleCompra._ContenidoEmpaque
                                            .c_CostoReferencia.c_Valor = xdetalle._ValorCostoReferencia
                                            .c_CostoActual.c_Valor = xdetalle._ValorCostoActual
                                            .c_CostoNuevo.c_Valor = xdetalle._FichaRegistroDetalleCompra._Costofinal
                                            .c_Documento.c_Texto = xgrabarcompra._Compra.RegistroDato._NumeroDocumentoCompra
                                            .c_Entidad.c_Texto = xgrabarcompra._Compra._Proveedor._NombreRazonSocial
                                            .c_Empaque.c_Texto = xdetalle._FichaRegistroDetalleCompra._Empaque
                                            .c_NombreEstacionEquipo.c_Texto = xgrabarcompra._Compra.RegistroDato._NombreEstacionEquipo
                                            .c_Estatus.c_Texto = "0"
                                            .c_FechaProceso.c_Valor = xgrabarcompra._Compra.RegistroDato._FechaCarga
                                            .c_FechaEmision.c_Valor = xgrabarcompra._Compra.RegistroDato._FechaEmision
                                            .c_Hora.c_Texto = xgrabarcompra._Compra.RegistroDato._Hora
                                            .c_Nota.c_Texto = "ENTRADA DE MERCANCIA POR COMPRA"
                                            .c_Origen.c_Texto = "0701"
                                            .c_Usuario.c_Texto = xgrabarcompra._Compra.RegistroDato._NombreUsuario
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaProducto.Prd_Producto.INSERT_PRODUCTOS_HISTORICO_COSTOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_documento", xhistorico.c_AutoDocumento.c_Texto).Size = xhistorico.c_AutoDocumento.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_entidad", xhistorico.c_AutoEntidad.c_Texto).Size = xhistorico.c_AutoEntidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigo_usuario", xhistorico.c_CodigoUsuario.c_Texto).Size = xhistorico.c_CodigoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@costo", xhistorico.c_CostoReferencia.c_Valor)
                                        xcmd.Parameters.AddWithValue("@costo_actual", xhistorico.c_CostoActual.c_Valor)
                                        xcmd.Parameters.AddWithValue("@costo_nuevo", xhistorico.c_CostoNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@documento", xhistorico.c_Documento.c_Texto).Size = xhistorico.c_Documento.c_Largo
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@entidad", xhistorico.c_Entidad.c_Texto).Size = xhistorico.c_Entidad.c_Largo
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_NombreEstacionEquipo.c_Texto).Size = xhistorico.c_NombreEstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@estatus", xhistorico.c_Estatus.c_Texto).Size = xhistorico.c_Estatus.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha_carga", xhistorico.c_FechaProceso.c_Valor)
                                        xcmd.Parameters.AddWithValue("@fecha_emision", xhistorico.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@origen", xhistorico.c_Origen.c_Texto).Size = xhistorico.c_Origen.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        Dim xp As Object = Nothing
                                        Dim xp1 As Decimal = 0
                                        Dim xp2 As Decimal = 0
                                        Dim xp4 As Decimal = 0
                                        Dim xp5 As Decimal = 0
                                        Dim xp6 As Decimal = 0
                                        Dim xp7 As Decimal = 0

                                        ' EXISTENCIA REAL DEL PRODUCTO
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select sum(real) as real from productos_deposito where auto_producto=@auto_producto"
                                        xcmd.Parameters.AddWithValue("@auto_producto", xdetalle._FichaRegistroDetalleCompra._AutoProducto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Largo
                                        xp = xcmd.ExecuteScalar
                                        If Not IsDBNull(xp) And xp IsNot Nothing Then
                                            xp1 = Math.Abs(xp)
                                        End If

                                        ' COSTO PROMEDIO ACTUAL DEL PRODUCTO
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select costo_promedio_compra from productos where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@auto", xdetalle._FichaRegistroDetalleCompra._AutoProducto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Largo
                                        xp = xcmd.ExecuteScalar
                                        If Not IsDBNull(xp) And xp IsNot Nothing Then
                                            xp2 = xp
                                        End If

                                        xp4 = xp1 / xdetalle._FichaRegistroDetalleCompra._ContenidoEmpaque                       ' existencia real en unidad de compra
                                        xp5 = xdetalle._FichaRegistroDetalleCompra._CantidadCompra + xdetalle._FichaRegistroDetalleCompra._Bono ' cantidad a entrar mas los bonos/promocion en unidad de compra
                                        xp6 = ((xp4 * xp2) + (xp5 * xdetalle._FichaRegistroDetalleCompra._Costofinal)) / (xp4 + xp5)
                                        xp6 = Decimal.Round(xp6, 2, MidpointRounding.AwayFromZero)
                                        xp7 = xp6 / xdetalle._FichaRegistroDetalleCompra._ContenidoEmpaque
                                        xp7 = Decimal.Round(xp7, 2, MidpointRounding.AwayFromZero)


                                        ' PRODUCTOS: ACTUALIZAR COSTOS DEL PRODUCTO
                                        Dim xr1 As Integer = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = UPDATE_PRODUCTOS
                                        xcmd.Parameters.AddWithValue("@costo_proveedor_compra", xdetalle._ValorCostoReferencia)
                                        xcmd.Parameters.AddWithValue("@costo_proveedor_inventario", xdetalle._ValorCostoReferenciaInventario)
                                        xcmd.Parameters.AddWithValue("@costo_compra", xdetalle._ValorCostoReferencia)
                                        xcmd.Parameters.AddWithValue("@costo_inventario", xdetalle._ValorCostoReferenciaInventario)
                                        xcmd.Parameters.AddWithValue("@costo_promedio_compra", xp6)
                                        xcmd.Parameters.AddWithValue("@costo_promedio_inventario", xp7)
                                        xcmd.Parameters.AddWithValue("@psv", xdetalle._PrecioSugerido)
                                        xcmd.Parameters.AddWithValue("@auto", xdetalle._FichaRegistroDetalleCompra._AutoProducto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Largo
                                        xr1 = xcmd.ExecuteNonQuery()
                                        If xr1 = 0 Then
                                            Throw New Exception("ERROR AL ACTUALIZAR DATA DEL PRODUCTO" + vbCrLf + xdetalle._FichaRegistroDetalleCompra._NombreProducto)
                                        End If
                                    End If

                                    ' PRODUCTOS_DEPOSITO
                                    Dim xr As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = UPDATE_PRODUCTOS_DEPOSITO
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdetalle._FichaRegistroDetalleCompra.c_AutoDeposito.c_Texto).Size = xdetalle._FichaRegistroDetalleCompra.c_AutoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xdetalle._TotalUnidadesInventarioEntrarDeposito)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Or xr Is Nothing Then
                                        Throw New Exception("ERROR EL PRODUCTO (" + xdetalle._FichaRegistroDetalleCompra.c_NombreProducto.c_Texto.Trim + ") NO TIENE ASIGNADO EL DEPOSITO (" _
                                                            + xdetalle._FichaRegistroDetalleCompra.c_NombreDeposito.c_Texto.Trim + "), VERIFIQUE")
                                    End If

                                    ' PRODUCTOS_KARDEX
                                    Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                                    With xkardex
                                        .c_AutoConcepto.c_Texto = auto_concepto
                                        .c_Entidad.c_Texto = xgrabarcompra._Compra._Proveedor._NombreRazonSocial
                                        .c_AutoDeposito.c_Texto = xdetalle._FichaRegistroDetalleCompra.c_AutoDeposito.c_Texto
                                        .c_AutoDocumento.c_Texto = xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                        .c_AutoProducto.c_Texto = xdetalle._FichaRegistroDetalleCompra.c_AutoProducto.c_Texto
                                        .c_CantidadMover.c_Valor = xdetalle._FichaRegistroDetalleCompra.c_CantidadCompra.c_Valor + xdetalle._FichaRegistroDetalleCompra.c_Bono.c_Valor
                                        .c_CantidadUnidadesMover.c_Valor = xdetalle._TotalUnidadesInventarioEntrarDeposito
                                        .c_Documento.c_Texto = xgrabarcompra._Compra.RegistroDato.c_NumeroDocumentoCompra.c_Texto
                                        .c_Entidad.c_Texto = xgrabarcompra._Compra._Proveedor._NombreRazonSocial
                                        .c_Estatus.c_Texto = xgrabarcompra._Compra.RegistroDato.c_EstatusCompra.c_Texto
                                        .c_FechaEmision.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaCarga.c_Valor
                                        .c_NotasDetallesMovimiento.c_Texto = "ENTRADA POR COMPRA"
                                        .c_OrigenMovimiento.c_Texto = "0701"
                                        .c_ReferenciaEmpaque.c_Texto = xdetalle._FichaRegistroDetalleCompra.c_EmpaqueTipo.c_Texto
                                        .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Entrada
                                        'Campos Nuevos
                                        .c_NombreProducto.c_Texto = xdetalle._FichaProducto._DescripcionDetallaDelProducto
                                        .c_NombreDeposito.c_Texto = xdetalle._FichaDeposito._Nombre
                                        .c_NombreConcepto.c_Texto = xconcepto
                                        .c_NombreMedidaEmpaque.c_Texto = xdetalle._FichaRegistroDetalleCompra._Empaque
                                        .c_AutoMedida.c_Texto = xdetalle._FichaRegistroDetalleCompra._AutoMedida
                                        .c_ContenidoMedidaEmpaque.c_Valor = xdetalle._FichaRegistroDetalleCompra._ContenidoEmpaque
                                        .c_CodigoProducto.c_Texto = xdetalle._FichaProducto._CodigoProducto
                                        .c_CodigoDeposito.c_Texto = xdetalle._FichaDeposito._Codigo
                                        .c_CodigoConcepto.c_Texto = "COMPRAS"
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
                                    'Campos Nuevos
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

                                    'PRODUCTOS_PROVEEDOR: ASIGNAR CODIGO DEL PROVEEDOR DEL PRODUCTO
                                    Dim xb As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select codigo from productos_proveedor where auto_proveedor=@auto_proveedor and auto_producto=@auto_producto and codigo=@codigo"
                                    xcmd.Parameters.AddWithValue("@auto_proveedor", xdetalle._FichaRegistroDetalleCompra._AutoProveedor)
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdetalle._FichaRegistroDetalleCompra._AutoProducto)
                                    xcmd.Parameters.AddWithValue("@codigo", xdetalle._FichaRegistroDetalleCompra._CodigoProveedor)
                                    xb = xcmd.ExecuteScalar
                                    If xb Is Nothing And xdetalle._FichaRegistroDetalleCompra._CodigoProveedor <> "" Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaProducto.Prd_Proveedor.Insert_1
                                        xcmd.Parameters.AddWithValue("@auto_proveedor", xdetalle._FichaRegistroDetalleCompra._AutoProveedor)
                                        xcmd.Parameters.AddWithValue("@auto_producto", xdetalle._FichaRegistroDetalleCompra._AutoProducto)
                                        xcmd.Parameters.AddWithValue("@codigo", xdetalle._FichaRegistroDetalleCompra._CodigoProveedor)
                                        xcmd.ExecuteNonQuery()
                                    End If
                                Next

                                Dim xobj As Object = Nothing
                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabarcompra._Compra._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabarcompra._Compra._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabarcompra._Compra._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_resta from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_saldo = xobj
                                End If

                                'PROVEEDORES
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "UPDATE PROVEEDORES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo, " _
                                  + "fecha_ult_compra=@fecha_ult_compra where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@fecha_ult_compra", xgrabarcompra._Compra.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto", xgrabarcompra._Compra._Proveedor._Automatico)
                                xcmd.ExecuteNonQuery()

                                'TABLA TEMPORALCOMPRA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete temporal_compra where idunico=@idunico and tipodocumento='1' and autousuario=@autousuario"
                                xcmd.Parameters.AddWithValue("@idunico", xgrabarcompra._IdUnico)
                                xcmd.Parameters.AddWithValue("@autousuario", xgrabarcompra._Compra.RegistroDato._AutoUsuario)
                                xcmd.ExecuteNonQuery()

                                'ORDEN DE COMPRAS
                                If xgrabarcompra._Compra._FichaOrdenCompra IsNot Nothing Then
                                    Dim xestatus As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xgrabarcompra._Compra._FichaOrdenCompra._AutoDocumentoCompra)
                                    xcmd.CommandText = "select estatus from compras with (readpast) where auto = @auto"
                                    xestatus = xcmd.ExecuteScalar()
                                    If IsDBNull(xestatus) Or (xestatus Is Nothing) Then
                                        Throw New Exception("DOCUMENTO ORDEN DE COMPRA NO ENCONTRADO")
                                    Else
                                        If xestatus.ToString.Trim <> "0" Then
                                            If xestatus.ToString.Trim = "1" Then
                                                Throw New Exception("DOCUMENTO ORDEN DE COMPRA SE ENCUENTRA EN ESTADO ANULADO")
                                            Else
                                                Throw New Exception("DOCUMENTO ORDEN DE COMPRA YA FUE PROCESADO")
                                            End If
                                        End If
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update compras SET estatus = '2' where auto=@auto and estatus='0'"
                                    xcmd.Parameters.AddWithValue("@auto", xgrabarcompra._Compra._FichaOrdenCompra._AutoDocumentoCompra)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR ORDEN DE COMPRA")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "insert CompraOrdenCompra (AutoCompra, AutoOrdenCompra) values (@auto_compra, @auto_orden)"
                                    xcmd.Parameters.AddWithValue("@auto_compra", xgrabarcompra._Compra.RegistroDato.c_AutoDocumentoCompra.c_Texto)
                                    xcmd.Parameters.AddWithValue("@auto_orden", xgrabarcompra._Compra._FichaOrdenCompra._AutoDocumentoCompra)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL REGISTRAR COMPRA - ORDEN DE COMPRA ")
                                    End If
                                End If

                                xtr.Commit()
                            End Using

                            RaiseEvent FacturaExitosa(xgrabarcompra._Compra.RegistroDato._AutoDocumentoCompra)
                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 547 Then
                                Throw New Exception("ERROR... EL PROVEEDOR HA SIDO ELIMINADO POR OTRO USUARIO, VERIFIQUE")
                            Else
                                If xsql.Number = 2601 And xproducto = "" Then
                                    Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO, VERIFIQUE")
                                Else
                                    If xsql.Number = 2601 And xproducto <> "" Then
                                        Throw New Exception("ERROR... NO SE PUEDE ASIGNAR ESTE CODIGO PARA EL PRODUCTO " + xproducto + ". YA EXISTE PARA OTRO PRODUCTO.")
                                    Else
                                        Throw New Exception(xsql.Message)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("COMPRAS" + vbCrLf + "ERROR AL GRABAR COMPRA:" + vbCrLf + ex.Message)
                End Try
            End Function


            Class DocumentoOrdenTrasladar
                Private xfichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xequipoestacion As String
                Private xidunico As String
                Private xautodocumento As String

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xfichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xfichaUsuario = value
                    End Set
                End Property

                Property _EquipoEstacion() As String
                    Protected Friend Get
                        Return xequipoestacion
                    End Get
                    Set(ByVal value As String)
                        xequipoestacion = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _FechaMovimiento() As Date
                    Get
                        Return F_GetDate("select getdate()").Date
                    End Get
                End Property

                Property _IDUnico() As String
                    Protected Friend Get
                        Return xidunico
                    End Get
                    Set(ByVal value As String)
                        xidunico = value
                    End Set
                End Property

                Property _AutoDocumentoTrasladar() As String
                    Protected Friend Get
                        Return xautodocumento
                    End Get
                    Set(ByVal value As String)
                        xautodocumento = value
                    End Set
                End Property

                Sub New()
                    Me._AutoDocumentoTrasladar = ""
                    Me._EquipoEstacion = ""
                    Me._IDUnico = ""
                    Me._FichaUsuario = Nothing
                End Sub
            End Class

            Function F_TrasladarOrdenCompra(ByVal doctrasladar As DocumentoOrdenTrasladar) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Dim xfichacompra As FichaCompras.c_Compra

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xtb As New DataTable

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from compras WITH (READPAST) where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", doctrasladar._AutoDocumentoTrasladar)
                                xrd = xcmd.ExecuteReader
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("DOCUMENTO ORDEN DE COMPRA NO ENCONTRADO")
                                End If

                                xfichacompra = New FichaCompras.c_Compra
                                xfichacompra.M_CargarRegistro(xtb.Rows(0))

                                If xfichacompra.RegistroDato._TipoDocumentoCompra = TipoDocumentoCompra.OrdenCompra Then
                                    If xfichacompra.RegistroDato._EstatusCompra = TipoEstatus.Activo Then
                                    Else
                                        If xfichacompra.RegistroDato._EstatusCompra = TipoEstatus.Inactivo Then
                                            Throw New Exception("DOCUMENTO SE ENCUENTRA ANULADO")
                                        Else
                                            Throw New Exception("DOCUMENTO YA FUE PROCESADO")
                                        End If
                                    End If
                                Else
                                    Throw New Exception("TIPO DOCUMENTO NO PUEDE SER PROCESADO")
                                End If

                                xtb = New DataTable
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from compras_detalle WITH (READPAST) where auto_documento=@auto"
                                xcmd.Parameters.AddWithValue("@auto", doctrasladar._AutoDocumentoTrasladar)
                                xrd = xcmd.ExecuteReader
                                xtb.Load(xrd)
                                xrd.Close()

                                For Each xrow As DataRow In xtb.Rows
                                    Dim xdetOrden As New FichaCompras.c_ComprasDetalle
                                    xdetOrden.RegistroDato.M_CargarData(xrow)

                                    Dim xdetTemp As New FichaCompras.c_TemporalCompra.c_Registro
                                    xcmd.CommandText = "select a_temporalcompra from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalcompra=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalcompra=a_temporalcompra+1; " _
                                        + "select a_temporalcompra from contadores"
                                    xdetTemp.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    With xdetTemp
                                        .c_AutoDeposito.c_Texto = xdetOrden.RegistroDato._AutoDeposito
                                        .c_AutoMedida.c_Texto = xdetOrden.RegistroDato._AutoMedida
                                        .c_AutoProducto.c_Texto = xdetOrden.RegistroDato._AutoProducto
                                        .c_AutoUsuario.c_Texto = doctrasladar._FichaUsuario._AutoUsuario
                                        .c_CantidadItems.c_Valor = xdetOrden.RegistroDato._CantidadCompra
                                        .c_CodigoProducto.c_Texto = xdetOrden.RegistroDato._CodigoProducto
                                        .c_CodigoProductoProveedor.c_Texto = xdetOrden.RegistroDato._CodigoProveedor
                                        .c_ContenidoEmpaque.c_Valor = xdetOrden.RegistroDato._ContenidoEmpaque
                                        .c_TasaDescuento_1.c_Valor = xdetOrden.RegistroDato._Descuento1._Tasa
                                        .c_TasaDescuento_2.c_Valor = xdetOrden.RegistroDato._Descuento2._Tasa
                                        .c_TasaDescuento_3.c_Valor = xdetOrden.RegistroDato._Descuento3._Tasa
                                        .c_MontoDescuento_1.c_Valor = xdetOrden.RegistroDato._Descuento1._Valor
                                        .c_MontoDescuento_2.c_Valor = xdetOrden.RegistroDato._Descuento2._Valor
                                        .c_MontoDescuento_3.c_Valor = xdetOrden.RegistroDato._Descuento3._Valor
                                        .c_Bono.c_Valor = xdetOrden.RegistroDato._Bono
                                        .c_EsPesado.c_Texto = xdetOrden.RegistroDato.c_PTO_EsPesado.c_Texto
                                        .c_NombreEstacionEquipo.c_Texto = doctrasladar._EquipoEstacion
                                        .c_FechaProceso.c_Valor = doctrasladar._FechaMovimiento
                                        .c_ForzarMedida.c_Texto = xdetOrden.RegistroDato.c_ForzarMedida.c_Texto
                                        .c_IdUnico.c_Texto = doctrasladar._IDUnico
                                        .c_NotasItem.c_Texto = xdetOrden.RegistroDato._NotasItem
                                        .c_NombreEmpaque.c_Texto = xdetOrden.RegistroDato._Empaque
                                        .c_NombreProducto.c_Texto = xdetOrden.RegistroDato._NombreProducto
                                        .c_NombreUsuario.c_Texto = doctrasladar._FichaUsuario._NombreUsuario
                                        .c_NumeroDecimalesMedida.c_Texto = xdetOrden.RegistroDato._CantidadDecimales
                                        .c_CostoUnitario.c_Valor = xdetOrden.RegistroDato._CostoBruto
                                        .c_Costo_Final.c_Valor = xdetOrden.RegistroDato._Costofinal
                                        .c_CostoInventario.c_Valor = xdetOrden.RegistroDato._CostoInventario
                                        .c_PSugerido.c_Valor = xdetOrden.RegistroDato._PrecioSugeridoVenta
                                        .c_TasaIva.c_Valor = xdetOrden.RegistroDato._TasaIva
                                        .c_TipoDocumento.c_Texto = "1"
                                        .c_TipoTasa.c_Texto = xdetOrden.RegistroDato._TipoTasa
                                        .c_CostoTotal.c_Valor = xdetOrden.RegistroDato._TotalNeto
                                        .c_CodigoArancel.c_Texto = ""
                                        .c_MontoArancel.c_Valor = 0
                                        .c_TasaArancel.c_Valor = 0
                                        .c_MontoAduana.c_Valor = 0
                                        .c_TasaAduana.c_Valor = 0
                                        .c_MontoServicio.c_Valor = 0
                                        .c_TasaServicio.c_Valor = 0
                                        .c_MontoFlete.c_Valor = 0
                                        .c_MontoSeguro.c_Valor = 0
                                        .c_MontoOtros.c_Valor = 0
                                        .c_CostoImportacion.c_Valor = 0
                                        .c_ValorFob.c_Valor = 0
                                        .c_ValorCif.c_Valor = 0
                                        .c_MontoImpuestoLicor.c_Valor = xdetOrden.RegistroDato._MontoImpuestoLicor
                                        .c_AutoOrdenCompra.c_Texto = doctrasladar._AutoDocumentoTrasladar
                                    End With

                                    xcmd.CommandText = FichaCompras.c_TemporalCompra.InsertRegistroTemporalCompra
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@codigo", xdetTemp.c_CodigoProducto.c_Texto).Size = xdetTemp.c_CodigoProducto.c_Largo
                                        .AddWithValue("@cod_prod_proveedor", xdetTemp.c_CodigoProductoProveedor.c_Texto).Size = xdetTemp.c_CodigoProductoProveedor.c_Largo
                                        .AddWithValue("@producto", xdetTemp.c_NombreProducto.c_Texto).Size = xdetTemp.c_NombreProducto.c_Largo
                                        .AddWithValue("@espesado", xdetTemp.c_EsPesado.c_Texto).Size = xdetTemp.c_EsPesado.c_Largo
                                        .AddWithValue("@cantidad", xdetTemp.c_CantidadItems.c_Valor)
                                        .AddWithValue("@costo_bruto", xdetTemp.c_CostoUnitario.c_Valor)
                                        .AddWithValue("@costo_final", xdetTemp.c_Costo_Final.c_Valor)
                                        .AddWithValue("@costoinventario", xdetTemp.c_CostoInventario.c_Valor)
                                        .AddWithValue("@descuento1p", xdetTemp.c_TasaDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2p", xdetTemp.c_TasaDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3p", xdetTemp.c_TasaDescuento_3.c_Valor)
                                        .AddWithValue("@descuento1", xdetTemp.c_MontoDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2", xdetTemp.c_MontoDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3", xdetTemp.c_MontoDescuento_3.c_Valor)
                                        .AddWithValue("@bono", xdetTemp.c_Bono.c_Valor)
                                        .AddWithValue("@tasaiva", xdetTemp.c_TasaIva.c_Valor)
                                        .AddWithValue("@costo", xdetTemp.c_CostoTotal.c_Valor)
                                        .AddWithValue("@codigoarancel", xdetTemp.c_CodigoArancel.c_Texto)
                                        .AddWithValue("@arancel", xdetTemp.c_MontoArancel.c_Valor)
                                        .AddWithValue("@arancelp", xdetTemp.c_TasaArancel.c_Valor)
                                        .AddWithValue("@aduana", xdetTemp.c_MontoAduana.c_Valor)
                                        .AddWithValue("@aduanap", xdetTemp.c_TasaAduana.c_Valor)
                                        .AddWithValue("@servicio", xdetTemp.c_MontoServicio.c_Valor)
                                        .AddWithValue("@serviciop", xdetTemp.c_TasaServicio.c_Valor)
                                        .AddWithValue("@flete", xdetTemp.c_MontoFlete.c_Valor)
                                        .AddWithValue("@seguro", xdetTemp.c_MontoSeguro.c_Valor)
                                        .AddWithValue("@otros", xdetTemp.c_MontoOtros.c_Valor)
                                        .AddWithValue("@costoimportacion", xdetTemp.c_CostoImportacion.c_Valor)
                                        .AddWithValue("@valorfob", xdetTemp.c_ValorFob.c_Valor)
                                        .AddWithValue("@valorcif", xdetTemp.c_ValorCif.c_Valor)
                                        .AddWithValue("@autoitem", xdetTemp.c_AutoItem.c_Texto).Size = xdetTemp.c_AutoItem.c_Largo
                                        .AddWithValue("@autoproducto", xdetTemp._AutoProducto).Size = xdetTemp.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombreempaque", xdetTemp.c_NombreEmpaque.c_Texto).Size = xdetTemp.c_NombreEmpaque.c_Largo
                                        .AddWithValue("@contenidoempaque", xdetTemp.c_ContenidoEmpaque.c_Valor)
                                        .AddWithValue("@automedida", xdetTemp.c_AutoMedida.c_Texto).Size = xdetTemp.c_AutoMedida.c_Largo
                                        .AddWithValue("@decimalesmedida", xdetTemp.c_NumeroDecimalesMedida.c_Texto).Size = xdetTemp.c_NumeroDecimalesMedida.c_Largo
                                        .AddWithValue("@forzarmedida", xdetTemp.c_ForzarMedida.c_Texto).Size = xdetTemp.c_ForzarMedida.c_Largo
                                        .AddWithValue("@tipotasa", xdetTemp.c_TipoTasa.c_Texto).Size = xdetTemp.c_TipoTasa.c_Largo
                                        .AddWithValue("@autodeposito", xdetTemp.c_AutoDeposito.c_Texto).Size = xdetTemp.c_AutoDeposito.c_Largo
                                        .AddWithValue("@autousuario", xdetTemp.c_AutoUsuario.c_Texto).Size = xdetTemp.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombreusuario", xdetTemp.c_NombreUsuario.c_Texto).Size = xdetTemp.c_NombreUsuario.c_Largo
                                        .AddWithValue("@fecha", xdetTemp.c_FechaProceso.c_Valor)
                                        .AddWithValue("@estacion", xdetTemp.c_NombreEstacionEquipo.c_Texto).Size = xdetTemp.c_NombreEstacionEquipo.c_Largo
                                        .AddWithValue("@tipodocumento", xdetTemp.c_TipoDocumento.c_Texto).Size = xdetTemp.c_TipoDocumento.c_Largo
                                        .AddWithValue("@psugerido", xdetTemp.c_PSugerido.c_Valor)
                                        .AddWithValue("@notasitem", xdetTemp.c_NotasItem.c_Texto).Size = xdetTemp.c_NotasItem.c_Largo
                                        .AddWithValue("@montoimplicor", xdetTemp.c_MontoImpuestoLicor.c_Valor)
                                        .AddWithValue("@idunico", xdetTemp.c_IdUnico.c_Texto).Size = xdetTemp.c_IdUnico.c_Largo
                                        .AddWithValue("@autoordencompra", xdetTemp.c_AutoOrdenCompra.c_Texto).Size = xdetTemp.c_AutoOrdenCompra.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()
                                Next
                            End Using
                            xtr.Commit()
                            RaiseEvent ActualizarTabla()
                            RaiseEvent _CargarProveedor(xfichacompra.RegistroDato._AutoProveedor)

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function
        End Class
    End Class
End Namespace


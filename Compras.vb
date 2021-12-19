Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class FichaCompras
            Event ActualizarTabla()
            Event FacturaExitosa(ByVal xauto As String)
            Event _RetencionOk_Generada(ByVal xauto As String)

            Public Class c_TemporalCompra
                Event ActualizarTabla()
                Event _AbrirPendienteOk()
                Event _PendienteOk()
                Event _CargarProvCtaPendiente(ByVal xauto As String)
                Event _RecuperarOK()
                Event _ActualizarRegistroOk()


                Class AgregarRegistro
                    Private xficha_medidaempaque As FichaProducto.Prd_Medida.c_Registro
                    Private xficha_usuario As FichaGlobal.c_Usuario.c_Registro
                    Private xficha_producto As FichaProducto.Prd_Producto.c_Registro
                    Private xficha_deposito As FichaGlobal.c_Depositos.c_Registro
                    Private xcantidad As Decimal
                    Private xcontenido As Integer
                    Private xtasa_desc_1 As Decimal
                    Private xtasa_desc_2 As Decimal
                    Private xtasa_desc_3 As Decimal
                    Private ximporte As Decimal
                    Private xcosto_final As Decimal
                    Private xcosto_neto As Decimal
                    Private xbono As Decimal
                    Private xcodigo_prd_prov As String
                    Private xequipo As String
                    Private xprecio_sugerido As Decimal
                    Private xtipo_doc As TipoDocumentoCompra
                    Private xnotas As String
                    Private xidunico As String
                    Private ximpuesto_licor As Decimal

                    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Return Me.xficha_producto
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                            Me.xficha_producto = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xficha_usuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xficha_usuario = value
                        End Set
                    End Property

                    Property _FichaDeposito() As FichaGlobal.c_Depositos.c_Registro
                        Get
                            Return Me.xficha_deposito
                        End Get
                        Set(ByVal value As FichaGlobal.c_Depositos.c_Registro)
                            Me.xficha_deposito = value
                        End Set
                    End Property

                    Property _FichaMedidaEmapque() As FichaProducto.Prd_Medida.c_Registro
                        Get
                            Return Me.xficha_medidaempaque
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Medida.c_Registro)
                            Me.xficha_medidaempaque = value
                        End Set
                    End Property

                    Property _Cantidad() As Decimal
                        Get
                            Return Me.xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcantidad = value
                        End Set
                    End Property

                    Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.xcontenido
                        End Get
                        Set(ByVal value As Integer)
                            Me.xcontenido = value
                        End Set
                    End Property

                    Property _TasaDescuento_1() As Decimal
                        Get
                            Return Me.xtasa_desc_1
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_desc_1 = value
                        End Set
                    End Property

                    Property _TasaDescuento_2() As Decimal
                        Get
                            Return Me.xtasa_desc_2
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_desc_2 = value
                        End Set
                    End Property

                    Property _TasaDescuento_3() As Decimal
                        Get
                            Return Me.xtasa_desc_3
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_desc_3 = value
                        End Set
                    End Property

                    Property _Importe() As Decimal
                        Get
                            Return Me.ximporte
                        End Get
                        Set(ByVal value As Decimal)
                            Me.ximporte = value
                        End Set
                    End Property

                    Property _CostoFinal() As Decimal
                        Get
                            Return Me.xcosto_final
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcosto_final = value
                        End Set
                    End Property

                    Property _CostoNeto() As Decimal
                        Get
                            Return Me.xcosto_neto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcosto_neto = value
                        End Set
                    End Property

                    Property _Bono() As Decimal
                        Get
                            Return Me.xbono
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xbono = value
                        End Set
                    End Property

                    Property _CodigoPrdProveedor() As String
                        Get
                            Return Me.xcodigo_prd_prov
                        End Get
                        Set(ByVal value As String)
                            Me.xcodigo_prd_prov = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return Me.xequipo
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _PrecioSugerido() As Decimal
                        Get
                            Return Me.xprecio_sugerido
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xprecio_sugerido = value
                        End Set
                    End Property

                    Property _TipoDocumento() As TipoDocumentoCompra
                        Get
                            Return Me.xtipo_doc
                        End Get
                        Set(ByVal value As TipoDocumentoCompra)
                            Me.xtipo_doc = value
                        End Set
                    End Property

                    Property _Notas() As String
                        Get
                            Return Me.xnotas
                        End Get
                        Set(ByVal value As String)
                            Me.xnotas = value
                        End Set
                    End Property

                    Property _IdUnico() As String
                        Get
                            Return Me.xidunico
                        End Get
                        Set(ByVal value As String)
                            Me.xidunico = value
                        End Set
                    End Property

                    Property _ImpuestoLicor() As Decimal
                        Get
                            Return Me.ximpuesto_licor
                        End Get
                        Set(ByVal value As Decimal)
                            Me.ximpuesto_licor = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Sub New()
                        Me._Bono = 0
                        Me._Cantidad = 0
                        Me._CodigoPrdProveedor = ""
                        Me._ContenidoEmpaque = 0
                        Me._CostoFinal = 0
                        Me._CostoNeto = 0
                        Me._EstacionEquipo = ""
                        Me._FichaDeposito = Nothing
                        Me._FichaProducto = Nothing
                        Me._FichaUsuario = Nothing
                        Me._FichaMedidaEmapque = Nothing
                        Me._IdUnico = ""
                        Me._Importe = 0
                        Me._ImpuestoLicor = 0
                        Me._Notas = ""
                        Me._PrecioSugerido = 0
                        Me._TasaDescuento_1 = 0
                        Me._TasaDescuento_2 = 0
                        Me._TasaDescuento_3 = 0
                        Me._TipoDocumento = 0
                    End Sub
                End Class
                Class AbrirCtaPendiente
                    Private xfichaUsuario As FichaGlobal.c_Usuario.c_Registro
                    Private xequipoestacion As String
                    Private xidunico As String
                    Private xtipodocumento As TipoDocumentoVenta
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

                    Property _TipoDocumento() As TipoDocumentoCompra
                        Protected Friend Get
                            Return xtipodocumento
                        End Get
                        Set(ByVal value As TipoDocumentoCompra)
                            xtipodocumento = value
                        End Set
                    End Property

                    Property _AutoDocumentoAbrir() As String
                        Protected Friend Get
                            Return xautodocumento
                        End Get
                        Set(ByVal value As String)
                            xautodocumento = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoDocumentoAbrir = ""
                        Me._EquipoEstacion = ""
                        Me._IDUnico = ""
                        Me._TipoDocumento = 0
                        Me._FichaUsuario = Nothing
                    End Sub
                End Class
                Class AgregarPendiente
                    Dim xmonto As Decimal
                    Dim xequipo As String
                    Dim xusuario As FichaGlobal.c_Usuario.c_Registro
                    Dim xproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Dim xanombrede As String
                    Dim xtipodoc As TipoDocumentoCompra
                    Dim xidunico As String

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

                    Property _MontoPendiente() As Decimal
                        Get
                            Return Me.xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xusuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Get
                            Return Me.xequipo
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Get
                            Return Me.xproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            Me.xproveedor = value
                        End Set
                    End Property

                    Property _ANombreDe() As String
                        Get
                            Return Me.xanombrede
                        End Get
                        Set(ByVal value As String)
                            Me.xanombrede = value
                        End Set
                    End Property

                    Property _TipoDocumento() As TipoDocumentoCompra
                        Get
                            Return Me.xtipodoc
                        End Get
                        Set(ByVal value As TipoDocumentoCompra)
                            Me.xtipodoc = value
                        End Set
                    End Property

                    Property _IdUnico() As String
                        Get
                            Return Me.xidunico
                        End Get
                        Set(ByVal value As String)
                            Me.xidunico = value
                        End Set
                    End Property

                    Sub New()
                        Me._ANombreDe = ""
                        Me._EquipoEstacion = ""
                        Me._FichaProveedor = Nothing
                        Me._FichaUsuario = Nothing
                        Me._IdUnico = ""
                        Me._MontoPendiente = 0
                        Me._TipoDocumento = 0
                    End Sub
                End Class
                Class RecuperarDocumento
                    Private xequipoestacion As String
                    Private xidunico As String
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro

                    Private xtipodocumento_recuperar As TipoDocumentoCompra
                    Private xautousuario_recuperar As String
                    Private xfecha_recuperar As Date
                    Private xidunico_recuperar As String

                    Property _AutoUsuario_Recuperar() As String
                        Protected Friend Get
                            Return xautousuario_recuperar
                        End Get
                        Set(ByVal value As String)
                            xautousuario_recuperar = value
                        End Set
                    End Property

                    Property _IdUnico_Recuperar() As String
                        Protected Friend Get
                            Return xidunico_recuperar
                        End Get
                        Set(ByVal value As String)
                            xidunico_recuperar = value
                        End Set
                    End Property

                    Property _FechaMovimiento_Recuperar() As Date
                        Protected Friend Get
                            Return xfecha_recuperar
                        End Get
                        Set(ByVal value As Date)
                            xfecha_recuperar = value
                        End Set
                    End Property

                    Property _TipoDocumento_Recuperar() As TipoDocumentoCompra
                        Protected Friend Get
                            Return xtipodocumento_recuperar
                        End Get
                        Set(ByVal value As TipoDocumentoCompra)
                            xtipodocumento_recuperar = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xusuario = value
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

                    Protected Friend ReadOnly Property _TipoDoc() As String
                        Get
                            Select Case Me._TipoDocumento_Recuperar
                                Case TipoDocumentoCompra.Factura : Return "1"
                                Case TipoDocumentoCompra.NotaDebito : Return "2"
                                Case TipoDocumentoCompra.NotaCredito : Return "3"
                                Case TipoDocumentoCompra.OrdenCompra : Return "4"
                                Case Else
                                    Throw New Exception("TIPO DE DOCUMENTO INCORRECTO")
                            End Select
                        End Get
                    End Property

                    Sub New()
                        Me._AutoUsuario_Recuperar = ""
                        Me._EquipoEstacion = ""
                        Me._FechaMovimiento_Recuperar = Date.MinValue
                        Me._FichaUsuario = Nothing
                        Me._IDUnico = ""
                        Me._IdUnico_Recuperar = ""
                        Me._TipoDocumento_Recuperar = 0
                    End Sub
                End Class
                Class c_Registro
                    Private f_Codigo As CampoTexto
                    Private f_Producto As CampoTexto
                    Private f_Cantidad As CampoDecimal
                    Private f_Costo_Bruto As CampoDecimal
                    Private f_Descuento1p As CampoDecimal
                    Private f_Descuento2p As CampoDecimal
                    Private f_Descuento3p As CampoDecimal
                    Private f_Descuento1 As CampoDecimal
                    Private f_Descuento2 As CampoDecimal
                    Private f_Descuento3 As CampoDecimal
                    Private f_TasaIva As CampoDecimal
                    Private f_Costo As CampoDecimal
                    Private f_AutoItem As CampoTexto
                    Private f_AutoProducto As CampoTexto
                    Private f_IdUnico As CampoTexto
                    Private f_NombreEmpaque As CampoTexto
                    Private f_ContenidoEmpaque As CampoInteger
                    Private f_PSugerido As CampoDecimal
                    Private f_Costo_Final As CampoDecimal
                    Private f_AutoDeposito As CampoTexto
                    Private f_AutoMedida As CampoTexto
                    Private f_ForzarMedida As CampoTexto
                    Private f_DecimalesMedida As CampoTexto
                    Private f_AutoUsuario As CampoTexto
                    Private f_Estacion As CampoTexto
                    Private f_Fecha As CampoFecha
                    Private f_NotasItem As CampoTexto
                    Private f_NombreUsuario As CampoTexto
                    Private f_TipoDocumento As CampoTexto
                    Private f_TipoTasa As CampoTexto
                    Private f_Bono As CampoDecimal
                    Private f_Cod_Prod_Proveedor As CampoTexto
                    Private f_EsPesado As CampoTexto
                    Private f_CostoInventario As CampoDecimal
                    Private f_CodigoArancel As CampoTexto
                    Private f_Arancel As CampoDecimal
                    Private f_Arancelp As CampoDecimal
                    Private f_Servicio As CampoDecimal
                    Private f_Serviciop As CampoDecimal
                    Private f_Aduana As CampoDecimal
                    Private f_Aduanap As CampoDecimal
                    Private f_Flete As CampoDecimal
                    Private f_Seguro As CampoDecimal
                    Private f_Otros As CampoDecimal
                    Private f_CostoImportacion As CampoDecimal
                    Private f_ValorFob As CampoDecimal
                    Private f_ValorCif As CampoDecimal
                    Private f_MontoImpLicor As CampoDecimal
                    Private f_autoordencompra As CampoTexto


                    Protected Friend Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_Codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_Codigo = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_Producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_Producto = value
                        End Set
                    End Property

                    Protected Friend Property c_CantidadItems() As CampoDecimal
                        Get
                            Return f_Cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Cantidad = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoUnitario() As CampoDecimal
                        Get
                            Return f_Costo_Bruto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Costo_Bruto = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento_1() As CampoDecimal
                        Get
                            Return f_Descuento1p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento1p = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento_2() As CampoDecimal
                        Get
                            Return f_Descuento2p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento2p = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento_3() As CampoDecimal
                        Get
                            Return f_Descuento3p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento3p = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento_1() As CampoDecimal
                        Get
                            Return f_Descuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento_2() As CampoDecimal
                        Get
                            Return f_Descuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento_3() As CampoDecimal
                        Get
                            Return f_Descuento3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Descuento3 = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_TasaIva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_TasaIva = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoTotal() As CampoDecimal
                        Get
                            Return f_Costo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Costo = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoItem() As CampoTexto
                        Get
                            Return f_AutoItem
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_AutoItem = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_AutoProducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_AutoProducto = value
                        End Set
                    End Property

                    Protected Friend Property c_IdUnico() As CampoTexto
                        Get
                            Return f_IdUnico
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_IdUnico = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreEmpaque() As CampoTexto
                        Get
                            Return f_NombreEmpaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_NombreEmpaque = value
                        End Set
                    End Property

                    Protected Friend Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_ContenidoEmpaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_ContenidoEmpaque = value
                        End Set
                    End Property

                    Protected Friend Property c_PSugerido() As CampoDecimal
                        Get
                            Return f_PSugerido
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_PSugerido = value
                        End Set
                    End Property

                    Protected Friend Property c_Costo_Final() As CampoDecimal
                        Get
                            Return f_Costo_Final
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Costo_Final = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDeposito() As CampoTexto
                        Get
                            Return f_AutoDeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_AutoDeposito = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_AutoMedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_AutoMedida = value
                        End Set
                    End Property

                    Protected Friend Property c_ForzarMedida() As CampoTexto
                        Get
                            Return f_ForzarMedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ForzarMedida = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroDecimalesMedida() As CampoTexto
                        Get
                            Return f_DecimalesMedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_DecimalesMedida = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_AutoUsuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_AutoUsuario = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreEstacionEquipo() As CampoTexto
                        Get
                            Return f_Estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_Estacion = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaProceso() As CampoFecha
                        Get
                            Return f_Fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_Fecha = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoTexto
                        Get
                            Return f_NotasItem
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_NotasItem = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return f_NombreUsuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_NombreUsuario = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_TipoDocumento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_TipoDocumento = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoTasa() As CampoTexto
                        Get
                            Return f_TipoTasa
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_TipoTasa = value
                        End Set
                    End Property

                    Protected Friend Property c_Bono() As CampoDecimal
                        Get
                            Return f_Bono
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Bono = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoProductoProveedor() As CampoTexto
                        Get
                            Return f_Cod_Prod_Proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_Cod_Prod_Proveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_EsPesado() As CampoTexto
                        Get
                            Return f_EsPesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_EsPesado = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoInventario() As CampoDecimal
                        Get
                            Return f_CostoInventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_CostoInventario = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoArancel() As CampoTexto
                        Get
                            Return f_CodigoArancel
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_CodigoArancel = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoArancel() As CampoDecimal
                        Get
                            Return f_Arancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Arancel = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaArancel() As CampoDecimal
                        Get
                            Return f_Arancelp
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Arancelp = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoServicio() As CampoDecimal
                        Get
                            Return f_Servicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Servicio = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaServicio() As CampoDecimal
                        Get
                            Return f_Serviciop
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Serviciop = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAduana() As CampoDecimal
                        Get
                            Return f_Aduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Aduana = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaAduana() As CampoDecimal
                        Get
                            Return f_Aduanap
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Aduanap = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoFlete() As CampoDecimal
                        Get
                            Return f_Flete
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Flete = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoSeguro() As CampoDecimal
                        Get
                            Return f_Seguro
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Seguro = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoOtros() As CampoDecimal
                        Get
                            Return f_Otros
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Otros = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoImportacion() As CampoDecimal
                        Get
                            Return f_CostoImportacion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_CostoImportacion = value
                        End Set
                    End Property

                    Protected Friend Property c_ValorFob() As CampoDecimal
                        Get
                            Return f_ValorFob
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_ValorFob = value
                        End Set
                    End Property

                    Protected Friend Property c_ValorCif() As CampoDecimal
                        Get
                            Return f_ValorCif
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_ValorCif = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuestoLicor() As CampoDecimal
                        Get
                            Return Me.f_MontoImpLicor
                        End Get
                        Set(ByVal value As CampoDecimal)
                            Me.f_MontoImpLicor = value
                        End Set
                    End Property

                    Property c_AutoOrdenCompra() As CampoTexto
                        Get
                            Return Me.f_autoordencompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_autoordencompra = value
                        End Set
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

                    ReadOnly Property _CantidadItems() As Decimal
                        Get
                            Return c_CantidadItems.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoUnitario() As Decimal
                        Get
                            Return c_CostoUnitario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Descuento_1() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento_1.c_Valor, c_MontoDescuento_1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento_2() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento_2.c_Valor, c_MontoDescuento_2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento_3() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaDescuento_3.c_Valor, c_MontoDescuento_3.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return c_TasaIva.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoTotal() As Decimal
                        Get
                            Return c_CostoTotal.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Return c_AutoItem.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xficha As New FichaProducto.Prd_Producto
                                xficha.F_BuscarCargarFichaProducto(_AutoProducto)
                                Return xficha.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _IdUnico() As String
                        Get
                            Return c_IdUnico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return c_NombreEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Costo_Final() As Decimal
                        Get
                            Return c_Costo_Final.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PSugerido() As Decimal
                        Get
                            Return c_PSugerido.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return c_AutoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return c_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ForzarMedida() As Boolean
                        Get
                            Select Case c_ForzarMedida.c_Texto.Trim
                                Case "1"
                                    Return True
                                Case "0"
                                    Return False
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _NumeroDecimalesMedida() As Integer
                        Get
                            Dim xv As Integer = 0
                            Integer.TryParse(Me.c_NumeroDecimalesMedida.c_Texto, xv)
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEstacionEquipo() As String
                        Get
                            Return c_NombreEstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return c_FechaProceso.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Return c_NotasItem.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoCompra
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto
                                Case "1" : Return TipoDocumentoCompra.Factura
                                Case "2" : Return TipoDocumentoCompra.NotaDebito
                                Case "3" : Return TipoDocumentoCompra.NotaCredito
                                Case "4" : Return TipoDocumentoCompra.OrdenCompra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As String
                        Get
                            Return c_TipoTasa.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Bono() As Decimal
                        Get
                            Return c_Bono.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As Boolean
                        Get
                            If Me.c_EsPesado.c_Texto = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _CodigoProductoProveedor() As String
                        Get
                            Return c_CodigoProductoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return c_CostoInventario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoArancel() As String
                        Get
                            Return c_CodigoArancel.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoArancel() As Decimal
                        Get
                            Return c_MontoArancel.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TasaArancel() As Decimal
                        Get
                            Return c_TasaArancel.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoServicio() As Decimal
                        Get
                            Return c_MontoServicio.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TasaServicio() As Decimal
                        Get
                            Return c_TasaServicio.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoAduana() As Decimal
                        Get
                            Return c_MontoAduana.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TasaAduana() As Decimal
                        Get
                            Return c_TasaAduana.c_Valor
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

                    ReadOnly Property _MontoOtros() As Decimal
                        Get
                            Return c_MontoOtros.c_Valor
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

                    ReadOnly Property _MontoImpuestoLicor() As Decimal
                        Get
                            Return Me.c_MontoImpuestoLicor.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoOrdenCompra() As String
                        Get
                            Return Me.c_AutoOrdenCompra.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' CANTIDAD * COSTO NETO DEL PRODUCTO
                    ''' </summary>
                    ReadOnly Property _Calc_ImporteNeto() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = _CostoUnitario * _CantidadItems
                            Return x
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        f_Codigo = New CampoTexto(15, "Codigo")
                        f_Producto = New CampoTexto(200, "Producto")
                        f_Cantidad = New CampoDecimal("Cantidad")
                        f_Costo_Bruto = New CampoDecimal("Costo_Bruto")
                        f_Descuento1p = New CampoDecimal("Descuento1p")
                        f_Descuento2p = New CampoDecimal("Descuento2p")
                        f_Descuento3p = New CampoDecimal("Descuento3p")
                        f_Descuento1 = New CampoDecimal("Descuento1")
                        f_Descuento2 = New CampoDecimal("Descuento2")
                        f_Descuento3 = New CampoDecimal("Descuento3")
                        f_TasaIva = New CampoDecimal("TasaIva")
                        f_Costo = New CampoDecimal("Costo")
                        f_AutoItem = New CampoTexto(10, "AutoItem")
                        f_AutoProducto = New CampoTexto(10, "AutoProducto")
                        f_IdUnico = New CampoTexto(60, "IdUnico")
                        f_NombreEmpaque = New CampoTexto(15, "NombreEmpaque")
                        f_ContenidoEmpaque = New CampoInteger("ContenidoEmpaque")
                        f_PSugerido = New CampoDecimal("PSugerido")
                        f_Costo_Final = New CampoDecimal("Costo_Final")
                        f_AutoDeposito = New CampoTexto(10, "AutoDeposito")
                        f_AutoMedida = New CampoTexto(10, "AutoMedida")
                        f_ForzarMedida = New CampoTexto(1, "ForzarMedida")
                        f_DecimalesMedida = New CampoTexto(1, "DecimalesMedida")
                        f_AutoUsuario = New CampoTexto(10, "AutoUsuario")
                        f_Estacion = New CampoTexto(20, "Estacion")
                        f_Fecha = New CampoFecha("Fecha")
                        f_NotasItem = New CampoTexto(160, "NotasItem")
                        f_NombreUsuario = New CampoTexto(20, "NombreUsuario")
                        f_TipoDocumento = New CampoTexto(1, "TipoDocumento")
                        f_TipoTasa = New CampoTexto(1, "TipoTasa")
                        f_Bono = New CampoDecimal("Bono")
                        f_Cod_Prod_Proveedor = New CampoTexto(15, "Cod_Prod_Proveedor")
                        f_EsPesado = New CampoTexto(1, "EsPesado")
                        f_CostoInventario = New CampoDecimal("CostoInventario")
                        f_CodigoArancel = New CampoTexto(15, "CodigoArancel")
                        f_Arancel = New CampoDecimal("Arancel")
                        f_Arancelp = New CampoDecimal("Arancelp")
                        f_Servicio = New CampoDecimal("Servicio")
                        f_Serviciop = New CampoDecimal("Serviciop")
                        f_Aduana = New CampoDecimal("Aduana")
                        f_Aduanap = New CampoDecimal("Aduanap")
                        f_Flete = New CampoDecimal("Flete")
                        f_Seguro = New CampoDecimal("Seguro")
                        f_Otros = New CampoDecimal("Otros")
                        f_CostoImportacion = New CampoDecimal("CostoImportacion")
                        f_ValorFob = New CampoDecimal("ValorFob")
                        f_ValorCif = New CampoDecimal("ValorCif")
                        f_MontoImpLicor = New CampoDecimal("MontoImplicor")
                        f_autoordencompra = New CampoTexto(10, "AutoOrdenCompra")

                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_CodigoProducto.c_Texto = xrow(.c_CodigoProducto.c_NombreInterno)
                                .c_NombreProducto.c_Texto = xrow(.c_NombreProducto.c_NombreInterno)
                                .c_CantidadItems.c_Valor = xrow(.c_CantidadItems.c_NombreInterno)
                                .c_CostoUnitario.c_Valor = xrow(.c_CostoUnitario.c_NombreInterno)
                                .c_TasaDescuento_1.c_Valor = xrow(.c_TasaDescuento_1.c_NombreInterno)
                                .c_TasaDescuento_2.c_Valor = xrow(.c_TasaDescuento_2.c_NombreInterno)
                                .c_TasaDescuento_3.c_Valor = xrow(.c_TasaDescuento_3.c_NombreInterno)
                                .c_MontoDescuento_1.c_Valor = xrow(.c_MontoDescuento_1.c_NombreInterno)
                                .c_MontoDescuento_2.c_Valor = xrow(.c_MontoDescuento_2.c_NombreInterno)
                                .c_MontoDescuento_3.c_Valor = xrow(.c_MontoDescuento_3.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_CostoTotal.c_Valor = xrow(.c_CostoTotal.c_NombreInterno)
                                .c_AutoItem.c_Texto = xrow(.c_AutoItem.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_IdUnico.c_Texto = xrow(.c_IdUnico.c_NombreInterno)
                                .c_NombreEmpaque.c_Texto = xrow(.c_NombreEmpaque.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_Costo_Final.c_Valor = xrow(.c_Costo_Final.c_NombreInterno)
                                .c_PSugerido.c_Valor = xrow(.c_PSugerido.c_NombreInterno)
                                .c_AutoDeposito.c_Texto = xrow(.c_AutoDeposito.c_NombreInterno)
                                .c_AutoMedida.c_Texto = xrow(.c_AutoMedida.c_NombreInterno)
                                .c_ForzarMedida.c_Texto = xrow(.c_ForzarMedida.c_NombreInterno)
                                .c_NumeroDecimalesMedida.c_Texto = xrow(.c_NumeroDecimalesMedida.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)
                                .c_NombreEstacionEquipo.c_Texto = xrow(.c_NombreEstacionEquipo.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_NotasItem.c_Texto = xrow(.c_NotasItem.c_NombreInterno)
                                .c_NombreUsuario.c_Texto = xrow(.c_NombreUsuario.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TipoTasa.c_Texto = xrow(.c_TipoTasa.c_NombreInterno)
                                .c_Bono.c_Valor = xrow(.c_Bono.c_NombreInterno)
                                .c_EsPesado.c_Texto = xrow(.c_EsPesado.c_NombreInterno)
                                .c_CodigoProductoProveedor.c_Texto = xrow(.c_CodigoProductoProveedor.c_NombreInterno)
                                .c_CostoInventario.c_Valor = xrow(.c_CostoInventario.c_NombreInterno)
                                .c_CodigoArancel.c_Texto = xrow(.c_CodigoArancel.c_NombreInterno)
                                .c_MontoArancel.c_Valor = xrow(.c_MontoArancel.c_NombreInterno)
                                .c_MontoAduana.c_Valor = xrow(.c_MontoAduana.c_NombreInterno)
                                .c_MontoFlete.c_Valor = xrow(.c_MontoFlete.c_NombreInterno)
                                .c_MontoServicio.c_Valor = xrow(.c_MontoServicio.c_NombreInterno)
                                .c_MontoSeguro.c_Valor = xrow(.c_MontoSeguro.c_NombreInterno)
                                .c_MontoOtros.c_Valor = xrow(.c_MontoOtros.c_NombreInterno)
                                .c_TasaArancel.c_Valor = xrow(.c_TasaArancel.c_NombreInterno)
                                .c_TasaAduana.c_Valor = xrow(.c_TasaAduana.c_NombreInterno)
                                .c_TasaServicio.c_Valor = xrow(.c_TasaServicio.c_NombreInterno)
                                .c_ValorFob.c_Valor = xrow(.c_ValorFob.c_NombreInterno)
                                .c_ValorCif.c_Valor = xrow(.c_ValorCif.c_NombreInterno)
                                .c_CostoImportacion.c_Valor = xrow(.c_CostoImportacion.c_NombreInterno)

                                If Not IsDBNull(xrow(c_MontoImpuestoLicor.c_NombreInterno)) Then
                                    .c_MontoImpuestoLicor.c_Valor = xrow(c_MontoImpuestoLicor.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_AutoOrdenCompra.c_NombreInterno)) Then
                                    .c_AutoOrdenCompra.c_Texto = xrow(c_AutoOrdenCompra.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "TEMPORAL COMPRA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

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

                Protected Friend Const InsertRegistroTemporalCompra As String = "INSERT INTO Temporal_Compra (" _
                 + "Codigo, " _
                 + "Cod_Prod_Proveedor, " _
                 + "Producto, " _
                 + "EsPesado, " _
                 + "Cantidad, " _
                 + "Costo_Bruto, " _
                 + "Costo_Final, " _
                 + "CostoInventario, " _
                 + "Descuento1p, " _
                 + "Descuento2p, " _
                 + "Descuento3p, " _
                 + "Descuento1, " _
                 + "Descuento2, " _
                 + "Descuento3, " _
                 + "Bono, " _
                 + "TasaIva, " _
                 + "Costo, " _
                 + "CodigoArancel, " _
                 + "Arancel, " _
                 + "Arancelp, " _
                 + "Aduana, " _
                 + "Aduanap, " _
                 + "Servicio, " _
                 + "Serviciop, " _
                 + "Flete, " _
                 + "Seguro, " _
                 + "Otros, " _
                 + "CostoImportacion, " _
                 + "ValorFob, " _
                 + "ValorCif, " _
                 + "AutoItem, " _
                 + "AutoProducto, " _
                 + "NombreEmpaque, " _
                 + "ContenidoEmpaque, " _
                 + "AutoMedida, " _
                 + "DecimalesMedida, " _
                 + "ForzarMedida, " _
                 + "TipoTasa, " _
                 + "AutoDeposito, " _
                 + "AutoUsuario, " _
                 + "NombreUsuario, " _
                 + "Fecha, " _
                 + "Estacion, " _
                 + "TipoDocumento, " _
                 + "PSugerido, " _
                 + "NotasItem, " _
                 + "MontoImpLicor, " _
                 + "IdUnico, AUTOORDENCOMPRA) " _
                 + "VALUES (" _
                 + "@Codigo, " _
                 + "@Cod_Prod_Proveedor, " _
                 + "@Producto, " _
                 + "@EsPesado, " _
                 + "@Cantidad, " _
                 + "@Costo_Bruto, " _
                 + "@Costo_Final, " _
                 + "@CostoInventario, " _
                 + "@Descuento1p, " _
                 + "@Descuento2p, " _
                 + "@Descuento3p, " _
                 + "@Descuento1, " _
                 + "@Descuento2, " _
                 + "@Descuento3, " _
                 + "@Bono, " _
                 + "@TasaIva, " _
                 + "@Costo, " _
                 + "@CodigoArancel, " _
                 + "@Arancel, " _
                 + "@Arancelp, " _
                 + "@Aduana, " _
                 + "@Aduanap, " _
                 + "@Servicio, " _
                 + "@Serviciop, " _
                 + "@Flete, " _
                 + "@Seguro, " _
                 + "@Otros, " _
                 + "@CostoImportacion, " _
                 + "@ValorFob, " _
                 + "@ValorCif, " _
                 + "@AutoItem," _
                 + "@AutoProducto, " _
                 + "@NombreEmpaque, " _
                 + "@ContenidoEmpaque, " _
                 + "@AutoMedida, " _
                 + "@DecimalesMedida, " _
                 + "@ForzarMedida, " _
                 + "@TipoTasa, " _
                 + "@AutoDeposito, " _
                 + "@AutoUsuario, " _
                 + "@NombreUsuario, " _
                 + "@Fecha, " _
                 + "@Estacion, " _
                 + "@TipoDocumento, " _
                 + "@PSugerido, " _
                 + "@NotasItem, " _
                 + "@MontoImpLicor, " _
                 + "@IdUnico, @AUTOORDENCOMPRA) "

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_AgregarRegisto(ByVal xitem As AgregarRegistro) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xreg As FichaCompras.c_TemporalCompra.c_Registro

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            xreg = New FichaCompras.c_TemporalCompra.c_Registro

                            Try
                                With xreg
                                    .c_AutoDeposito.c_Texto = xitem._FichaDeposito._Automatico
                                    .c_AutoItem.c_Texto = ""
                                    .c_AutoMedida.c_Texto = xitem._FichaMedidaEmapque._Automatico
                                    .c_AutoProducto.c_Texto = xitem._FichaProducto._AutoProducto
                                    .c_AutoUsuario.c_Texto = xitem._FichaUsuario._AutoUsuario
                                    .c_Bono.c_Valor = xitem._Bono
                                    .c_CantidadItems.c_Valor = xitem._Cantidad
                                    .c_CodigoArancel.c_Texto = ""
                                    .c_CodigoProducto.c_Texto = xitem._FichaProducto._CodigoProducto
                                    .c_CodigoProductoProveedor.c_Texto = xitem._CodigoPrdProveedor
                                    .c_ContenidoEmpaque.c_Valor = xitem._ContenidoEmpaque
                                    .c_Costo_Final.c_Valor = xitem._CostoFinal
                                    .c_CostoImportacion.c_Valor = 0
                                    .c_CostoInventario.c_Valor = 0
                                    .c_CostoTotal.c_Valor = xitem._Importe
                                    .c_CostoUnitario.c_Valor = xitem._CostoNeto
                                    .c_EsPesado.c_Texto = IIf(xitem._FichaProducto._EsPesado = TipoEstatus.Activo, "1", "0")
                                    .c_FechaProceso.c_Valor = xitem._Fecha
                                    .c_ForzarMedida.c_Texto = IIf(xitem._FichaMedidaEmapque._ForzarDecimales, "1", "0")
                                    .c_IdUnico.c_Texto = xitem._IdUnico
                                    .c_MontoAduana.c_Valor = 0
                                    .c_MontoArancel.c_Valor = 0
                                    .c_MontoDescuento_1.c_Valor = 0
                                    .c_MontoDescuento_2.c_Valor = 0
                                    .c_MontoDescuento_3.c_Valor = 0
                                    .c_MontoFlete.c_Valor = 0
                                    .c_MontoImpuestoLicor.c_Valor = xitem._ImpuestoLicor
                                    .c_MontoOtros.c_Valor = 0
                                    .c_MontoSeguro.c_Valor = 0
                                    .c_MontoServicio.c_Valor = 0
                                    .c_NombreEmpaque.c_Texto = xitem._FichaMedidaEmapque._NombreMedida
                                    .c_NombreEstacionEquipo.c_Texto = xitem._EstacionEquipo
                                    .c_NombreProducto.c_Texto = xitem._FichaProducto._DescripcionDetallaDelProducto
                                    .c_NombreUsuario.c_Texto = xitem._FichaUsuario._NombreUsuario
                                    .c_NotasItem.c_Texto = xitem._Notas
                                    .c_NumeroDecimalesMedida.c_Texto = xitem._FichaMedidaEmapque._DigitosDecimalesAUsar.ToString
                                    .c_PSugerido.c_Valor = xitem._PrecioSugerido
                                    .c_TasaAduana.c_Valor = 0
                                    .c_TasaArancel.c_Valor = 0
                                    .c_TasaDescuento_1.c_Valor = xitem._TasaDescuento_1
                                    .c_TasaDescuento_2.c_Valor = xitem._TasaDescuento_2
                                    .c_TasaDescuento_3.c_Valor = xitem._TasaDescuento_3
                                    .c_TasaIva.c_Valor = xitem._FichaProducto._TasaImpuesto
                                    .c_TasaServicio.c_Valor = 0
                                    Select Case xitem._TipoDocumento
                                        Case TipoDocumentoCompra.Factura : .c_TipoDocumento.c_Texto = "1"
                                        Case TipoDocumentoCompra.NotaDebito : .c_TipoDocumento.c_Texto = "2"
                                        Case TipoDocumentoCompra.NotaCredito : .c_TipoDocumento.c_Texto = "3"
                                        Case TipoDocumentoCompra.OrdenCompra : .c_TipoDocumento.c_Texto = "4"
                                    End Select
                                    .c_TipoTasa.c_Texto = xitem._FichaProducto.c_TipoImpuesto.c_Texto
                                    .c_ValorCif.c_Valor = 0
                                    .c_ValorFob.c_Valor = 0
                                    .c_AutoOrdenCompra.c_Texto = ""
                                End With

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalcompra from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalcompra=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalcompra=a_temporalcompra+1;select a_temporalcompra from contadores"
                                    xreg.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    Dim xdp1 As Decimal = Decimal.Round(xreg.c_TasaDescuento_1.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim xdp2 As Decimal = Decimal.Round(xreg.c_TasaDescuento_2.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim xdp3 As Decimal = Decimal.Round(xreg.c_TasaDescuento_3.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim ximp As Decimal = xreg._Calc_ImporteNeto

                                    Dim xd1 As Decimal = 0
                                    Dim xd2 As Decimal = 0
                                    Dim xd3 As Decimal = 0
                                    With xreg
                                        If .c_TasaDescuento_1.c_Valor > 0 Then
                                            xd1 = xdp1 * ximp / 100
                                            ximp = ximp - ximp * xdp1 / 100
                                        End If

                                        If .c_TasaDescuento_2.c_Valor > 0 Then
                                            xd2 = xdp2 * ximp / 100
                                            ximp = ximp - ximp * xdp2 / 100
                                        End If

                                        If .c_TasaDescuento_3.c_Valor > 0 Then
                                            xd3 = xdp3 * ximp / 100
                                        End If

                                        .c_MontoDescuento_1.c_Valor = Decimal.Round(xd1, 2, MidpointRounding.AwayFromZero)
                                        .c_MontoDescuento_2.c_Valor = Decimal.Round(xd2, 2, MidpointRounding.AwayFromZero)
                                        .c_MontoDescuento_3.c_Valor = Decimal.Round(xd3, 2, MidpointRounding.AwayFromZero)
                                        .c_CostoInventario.c_Valor = Decimal.Round(.c_Costo_Final.c_Valor / .c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    End With

                                    xcmd.CommandText = InsertRegistroTemporalCompra
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@codigo", xreg.c_CodigoProducto.c_Texto).Size = xreg.c_CodigoProducto.c_Largo
                                        .AddWithValue("@cod_prod_proveedor", xreg.c_CodigoProductoProveedor.c_Texto).Size = xreg.c_CodigoProductoProveedor.c_Largo
                                        .AddWithValue("@producto", xreg.c_NombreProducto.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                        .AddWithValue("@espesado", xreg.c_EsPesado.c_Texto).Size = xreg.c_EsPesado.c_Largo
                                        .AddWithValue("@cantidad", xreg.c_CantidadItems.c_Valor)
                                        .AddWithValue("@costo_bruto", xreg.c_CostoUnitario.c_Valor)
                                        .AddWithValue("@costo_final", xreg.c_Costo_Final.c_Valor)
                                        .AddWithValue("@costoinventario", xreg.c_CostoInventario.c_Valor)
                                        .AddWithValue("@descuento1p", xreg.c_TasaDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2p", xreg.c_TasaDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3p", xreg.c_TasaDescuento_3.c_Valor)
                                        .AddWithValue("@descuento1", xreg.c_MontoDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2", xreg.c_MontoDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3", xreg.c_MontoDescuento_3.c_Valor)
                                        .AddWithValue("@bono", xreg.c_Bono.c_Valor)
                                        .AddWithValue("@tasaiva", xreg.c_TasaIva.c_Valor)
                                        .AddWithValue("@costo", xreg.c_CostoTotal.c_Valor)
                                        .AddWithValue("@codigoarancel", xreg.c_CodigoArancel.c_Texto)
                                        .AddWithValue("@arancel", xreg.c_MontoArancel.c_Valor)
                                        .AddWithValue("@arancelp", xreg.c_TasaArancel.c_Valor)
                                        .AddWithValue("@aduana", xreg.c_MontoAduana.c_Valor)
                                        .AddWithValue("@aduanap", xreg.c_TasaAduana.c_Valor)
                                        .AddWithValue("@servicio", xreg.c_MontoServicio.c_Valor)
                                        .AddWithValue("@serviciop", xreg.c_TasaServicio.c_Valor)
                                        .AddWithValue("@flete", xreg.c_MontoFlete.c_Valor)
                                        .AddWithValue("@seguro", xreg.c_MontoSeguro.c_Valor)
                                        .AddWithValue("@otros", xreg.c_MontoOtros.c_Valor)
                                        .AddWithValue("@costoimportacion", xreg.c_CostoImportacion.c_Valor)
                                        .AddWithValue("@valorfob", xreg.c_ValorFob.c_Valor)
                                        .AddWithValue("@valorcif", xreg.c_ValorCif.c_Valor)
                                        .AddWithValue("@autoitem", xreg.c_AutoItem.c_Texto).Size = xreg.c_AutoItem.c_Largo
                                        .AddWithValue("@autoproducto", xreg._AutoProducto).Size = xreg.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombreempaque", xreg.c_NombreEmpaque.c_Texto).Size = xreg.c_NombreEmpaque.c_Largo
                                        .AddWithValue("@contenidoempaque", xreg.c_ContenidoEmpaque.c_Valor)
                                        .AddWithValue("@automedida", xreg.c_AutoMedida.c_Texto).Size = xreg.c_AutoMedida.c_Largo
                                        .AddWithValue("@decimalesmedida", xreg.c_NumeroDecimalesMedida.c_Texto).Size = xreg.c_NumeroDecimalesMedida.c_Largo
                                        .AddWithValue("@forzarmedida", xreg.c_ForzarMedida.c_Texto).Size = xreg.c_ForzarMedida.c_Largo
                                        .AddWithValue("@tipotasa", xreg.c_TipoTasa.c_Texto).Size = xreg.c_TipoTasa.c_Largo
                                        .AddWithValue("@autodeposito", xreg.c_AutoDeposito.c_Texto).Size = xreg.c_AutoDeposito.c_Largo
                                        .AddWithValue("@autousuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombreusuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                        .AddWithValue("@fecha", xreg.c_FechaProceso.c_Valor)
                                        .AddWithValue("@estacion", xreg.c_NombreEstacionEquipo.c_Texto).Size = xreg.c_NombreEstacionEquipo.c_Largo
                                        .AddWithValue("@tipodocumento", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                        .AddWithValue("@psugerido", xreg.c_PSugerido.c_Valor)
                                        .AddWithValue("@notasitem", xreg.c_NotasItem.c_Texto).Size = xreg.c_NotasItem.c_Largo
                                        .AddWithValue("@MontoImpLicor", xreg.c_MontoImpuestoLicor.c_Valor).Size = xreg.c_MontoImpuestoLicor.c_Valor
                                        .AddWithValue("@idunico", xreg.c_IdUnico.c_Texto).Size = xreg.c_IdUnico.c_Largo
                                        .AddWithValue("@autoordencompra", xreg.c_AutoOrdenCompra.c_Texto).Size = xreg.c_AutoOrdenCompra.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarTabla()
                                Return True
                            Catch xsql As SqlException
                                xtr.Rollback()
                                If xsql.Number = 547 Then
                                    Throw New Exception("PRODUCTO (" + xreg._NombreProducto + ") NO HA SIDO ENCONTRADO, VERIFIQUE")
                                Else
                                    Throw New Exception(xsql.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_EliminarTodo(ByVal xidunico As String, ByVal xauto_usuario As String, ByVal xtipodoc As TipoDocumentoVenta) As Boolean
                    Try
                        Dim xtipo As Integer = [Enum].Parse(GetType(TipoDocumentoCompra), xtipodoc)
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporal_compra where idunico=@idunico and autousuario=@autousuario and tipodocumento=@tipodocumento"
                                    xcmd.Parameters.AddWithValue("@idunico", xidunico)
                                    xcmd.Parameters.AddWithValue("@autousuario", xauto_usuario)
                                    xcmd.Parameters.AddWithValue("@tipodocumento", xtipo.ToString)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarTabla()
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "ELIMINAR TODOS LOS REGISTROS TEMPORAL COMPRA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto)
                                    xcmd.CommandText = "delete from temporal_compra where autoitem=@autoitem"
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarTabla()
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "ELIMINAR REGISTRO TEMPORALCOMPRA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarItem_Notas(ByVal xauto As String, ByVal xnotas As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update temporal_compra set notasitem=@notasitem where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto)
                                    xcmd.Parameters.AddWithValue("@notasitem", xnotas).Size = Me.RegistroDato.c_NotasItem.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent ActualizarTabla()
                                Return True
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "ACTUALIZAR NOTAS / DETALLE DEL ITEM : TEMPORALCOMPRA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from temporal_compra where autoitem=@autoitem"
                            xadap.SelectCommand.Parameters.AddWithValue("@autoitem", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("ITEM NO ENCONTRADO... VERIFIQUE SI OTRO USUARIO LO HA PROCESADO")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("COMPRAS" + vbCrLf + "TEMPORAL COMPRA: BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarRegistro(ByVal xauto_registro_viejo As String, ByVal xitem As AgregarRegistro) As Boolean
                    Try
                        Dim xrd As SqlDataReader
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Dim xreg As New FichaCompras.c_TemporalCompra.c_Registro
                            With xreg
                                .c_AutoDeposito.c_Texto = xitem._FichaDeposito._Automatico
                                .c_AutoItem.c_Texto = ""
                                .c_AutoMedida.c_Texto = xitem._FichaMedidaEmapque._Automatico
                                .c_AutoProducto.c_Texto = xitem._FichaProducto._AutoProducto
                                .c_AutoUsuario.c_Texto = xitem._FichaUsuario._AutoUsuario
                                .c_Bono.c_Valor = xitem._Bono
                                .c_CantidadItems.c_Valor = xitem._Cantidad
                                .c_CodigoArancel.c_Texto = ""
                                .c_CodigoProducto.c_Texto = xitem._FichaProducto._CodigoProducto
                                .c_CodigoProductoProveedor.c_Texto = xitem._CodigoPrdProveedor
                                .c_ContenidoEmpaque.c_Valor = xitem._ContenidoEmpaque
                                .c_Costo_Final.c_Valor = xitem._CostoFinal
                                .c_CostoImportacion.c_Valor = 0
                                .c_CostoInventario.c_Valor = 0
                                .c_CostoTotal.c_Valor = xitem._Importe
                                .c_CostoUnitario.c_Valor = xitem._CostoNeto
                                .c_EsPesado.c_Texto = IIf(xitem._FichaProducto._EsPesado = TipoEstatus.Activo, "1", "0")
                                .c_FechaProceso.c_Valor = xitem._Fecha
                                .c_ForzarMedida.c_Texto = IIf(xitem._FichaMedidaEmapque._ForzarDecimales = TipoEstatus.Activo, "1", "0")
                                .c_IdUnico.c_Texto = xitem._IdUnico
                                .c_MontoAduana.c_Valor = 0
                                .c_MontoArancel.c_Valor = 0
                                .c_MontoDescuento_1.c_Valor = 0
                                .c_MontoDescuento_2.c_Valor = 0
                                .c_MontoDescuento_3.c_Valor = 0
                                .c_MontoFlete.c_Valor = 0
                                .c_MontoImpuestoLicor.c_Valor = xitem._ImpuestoLicor
                                .c_MontoOtros.c_Valor = 0
                                .c_MontoSeguro.c_Valor = 0
                                .c_MontoServicio.c_Valor = 0
                                .c_NombreEmpaque.c_Texto = xitem._FichaMedidaEmapque._NombreMedida
                                .c_NombreEstacionEquipo.c_Texto = xitem._EstacionEquipo
                                .c_NombreProducto.c_Texto = xitem._FichaProducto._DescripcionDetallaDelProducto
                                .c_NombreUsuario.c_Texto = xitem._FichaUsuario._NombreUsuario
                                .c_NotasItem.c_Texto = xitem._Notas
                                .c_NumeroDecimalesMedida.c_Texto = xitem._FichaMedidaEmapque._DigitosDecimalesAUsar.ToString
                                .c_PSugerido.c_Valor = xitem._PrecioSugerido
                                .c_TasaAduana.c_Valor = 0
                                .c_TasaArancel.c_Valor = 0
                                .c_TasaDescuento_1.c_Valor = xitem._TasaDescuento_1
                                .c_TasaDescuento_2.c_Valor = xitem._TasaDescuento_2
                                .c_TasaDescuento_3.c_Valor = xitem._TasaDescuento_3
                                .c_TasaIva.c_Valor = xitem._FichaProducto._TasaImpuesto
                                .c_TasaServicio.c_Valor = 0
                                Select Case xitem._TipoDocumento
                                    Case TipoDocumentoCompra.Factura : .c_TipoDocumento.c_Texto = "1"
                                    Case TipoDocumentoCompra.NotaDebito : .c_TipoDocumento.c_Texto = "2"
                                    Case TipoDocumentoCompra.NotaCredito : .c_TipoDocumento.c_Texto = "3"
                                    Case TipoDocumentoCompra.OrdenCompra : .c_TipoDocumento.c_Texto = "4"
                                End Select
                                .c_TipoTasa.c_Texto = xitem._FichaProducto.c_TipoImpuesto.c_Texto
                                .c_ValorCif.c_Valor = 0
                                .c_ValorFob.c_Valor = 0
                                .c_AutoOrdenCompra.c_Texto = ""
                            End With

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xtb As New DataTable

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporal_compra with (READPAST) where AutoItem=@AutoItem"
                                    xcmd.Parameters.AddWithValue("@AutoItem", xauto_registro_viejo)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)

                                    If xtb.Rows.Count > 0 Then
                                        Dim xficha As New FichaCompras.c_TemporalCompra
                                        xficha.M_CargarRegistro(xtb.Rows(0))
                                        xreg.c_AutoOrdenCompra.c_Texto = xficha.RegistroDato._AutoOrdenCompra
                                    End If

                                    Dim x As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete temporal_compra where AutoItem=@AutoItem"
                                    xcmd.Parameters.AddWithValue("@AutoItem", xauto_registro_viejo)
                                    x = xcmd.ExecuteNonQuery()
                                    If x = 0 Then
                                        Throw New Exception("ITEM NO ENCONTRADO / FUE PROCESADO POR OTRO USUARIO")
                                    End If

                                    xcmd.CommandText = "select a_temporalcompra from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalcompra=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalcompra=a_temporalcompra+1;select a_temporalcompra from contadores"
                                    xreg.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    Dim xdp1 As Decimal = Decimal.Round(xreg.c_TasaDescuento_1.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim xdp2 As Decimal = Decimal.Round(xreg.c_TasaDescuento_2.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim xdp3 As Decimal = Decimal.Round(xreg.c_TasaDescuento_3.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    Dim ximp As Decimal = xreg._Calc_ImporteNeto

                                    Dim xd1 As Decimal = 0
                                    Dim xd2 As Decimal = 0
                                    Dim xd3 As Decimal = 0
                                    With xreg
                                        If .c_TasaDescuento_1.c_Valor > 0 Then
                                            xd1 = xdp1 * ximp / 100
                                            ximp = ximp - ximp * xdp1 / 100
                                        End If

                                        If .c_TasaDescuento_2.c_Valor > 0 Then
                                            xd2 = xdp2 * ximp / 100
                                            ximp = ximp - ximp * xdp2 / 100
                                        End If

                                        If .c_TasaDescuento_3.c_Valor > 0 Then
                                            xd3 = xdp3 * ximp / 100
                                        End If

                                        .c_MontoDescuento_1.c_Valor = Decimal.Round(xd1, 2, MidpointRounding.AwayFromZero)
                                        .c_MontoDescuento_2.c_Valor = Decimal.Round(xd2, 2, MidpointRounding.AwayFromZero)
                                        .c_MontoDescuento_3.c_Valor = Decimal.Round(xd3, 2, MidpointRounding.AwayFromZero)
                                        .c_CostoInventario.c_Valor = Decimal.Round(.c_Costo_Final.c_Valor / .c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)
                                    End With

                                    xcmd.CommandText = InsertRegistroTemporalCompra
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@codigo", xreg.c_CodigoProducto.c_Texto).Size = xreg.c_CodigoProducto.c_Largo
                                        .AddWithValue("@cod_prod_proveedor", xreg.c_CodigoProductoProveedor.c_Texto).Size = xreg.c_CodigoProductoProveedor.c_Largo
                                        .AddWithValue("@producto", xreg.c_NombreProducto.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                        .AddWithValue("@espesado", xreg.c_EsPesado.c_Texto).Size = xreg.c_EsPesado.c_Largo
                                        .AddWithValue("@cantidad", xreg.c_CantidadItems.c_Valor)
                                        .AddWithValue("@costo_bruto", xreg.c_CostoUnitario.c_Valor)
                                        .AddWithValue("@costo_final", xreg.c_Costo_Final.c_Valor)
                                        .AddWithValue("@costoinventario", xreg.c_CostoInventario.c_Valor)
                                        .AddWithValue("@descuento1p", xreg.c_TasaDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2p", xreg.c_TasaDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3p", xreg.c_TasaDescuento_3.c_Valor)
                                        .AddWithValue("@descuento1", xreg.c_MontoDescuento_1.c_Valor)
                                        .AddWithValue("@descuento2", xreg.c_MontoDescuento_2.c_Valor)
                                        .AddWithValue("@descuento3", xreg.c_MontoDescuento_3.c_Valor)
                                        .AddWithValue("@bono", xreg.c_Bono.c_Valor)
                                        .AddWithValue("@tasaiva", xreg.c_TasaIva.c_Valor)
                                        .AddWithValue("@costo", xreg.c_CostoTotal.c_Valor)
                                        .AddWithValue("@codigoarancel", xreg.c_CodigoArancel.c_Texto)
                                        .AddWithValue("@arancel", xreg.c_MontoArancel.c_Valor)
                                        .AddWithValue("@arancelp", xreg.c_TasaArancel.c_Valor)
                                        .AddWithValue("@aduana", xreg.c_MontoAduana.c_Valor)
                                        .AddWithValue("@aduanap", xreg.c_TasaAduana.c_Valor)
                                        .AddWithValue("@servicio", xreg.c_MontoServicio.c_Valor)
                                        .AddWithValue("@serviciop", xreg.c_TasaServicio.c_Valor)
                                        .AddWithValue("@flete", xreg.c_MontoFlete.c_Valor)
                                        .AddWithValue("@seguro", xreg.c_MontoSeguro.c_Valor)
                                        .AddWithValue("@otros", xreg.c_MontoOtros.c_Valor)
                                        .AddWithValue("@costoimportacion", xreg.c_CostoImportacion.c_Valor)
                                        .AddWithValue("@valorfob", xreg.c_ValorFob.c_Valor)
                                        .AddWithValue("@valorcif", xreg.c_ValorCif.c_Valor)
                                        .AddWithValue("@autoitem", xreg.c_AutoItem.c_Texto).Size = xreg.c_AutoItem.c_Largo
                                        .AddWithValue("@autoproducto", xreg._AutoProducto).Size = xreg.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombreempaque", xreg.c_NombreEmpaque.c_Texto).Size = xreg.c_NombreEmpaque.c_Largo
                                        .AddWithValue("@contenidoempaque", xreg.c_ContenidoEmpaque.c_Valor)
                                        .AddWithValue("@automedida", xreg.c_AutoMedida.c_Texto).Size = xreg.c_AutoMedida.c_Largo
                                        .AddWithValue("@decimalesmedida", xreg.c_NumeroDecimalesMedida.c_Texto).Size = xreg.c_NumeroDecimalesMedida.c_Largo
                                        .AddWithValue("@forzarmedida", xreg.c_ForzarMedida.c_Texto).Size = xreg.c_ForzarMedida.c_Largo
                                        .AddWithValue("@tipotasa", xreg.c_TipoTasa.c_Texto).Size = xreg.c_TipoTasa.c_Largo
                                        .AddWithValue("@autodeposito", xreg.c_AutoDeposito.c_Texto).Size = xreg.c_AutoDeposito.c_Largo
                                        .AddWithValue("@autousuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombreusuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                        .AddWithValue("@fecha", xreg.c_FechaProceso.c_Valor)
                                        .AddWithValue("@estacion", xreg.c_NombreEstacionEquipo.c_Texto).Size = xreg.c_NombreEstacionEquipo.c_Largo
                                        .AddWithValue("@tipodocumento", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                        .AddWithValue("@psugerido", xreg.c_PSugerido.c_Valor)
                                        .AddWithValue("@notasitem", xreg.c_NotasItem.c_Texto).Size = xreg.c_NotasItem.c_Largo
                                        .AddWithValue("@MontoImpLicor", xreg.c_MontoImpuestoLicor.c_Valor).Size = xreg.c_MontoImpuestoLicor.c_Valor
                                        .AddWithValue("@idunico", xreg.c_IdUnico.c_Texto).Size = xreg.c_IdUnico.c_Largo
                                        .AddWithValue("@autoordencompra", xreg.c_AutoOrdenCompra.c_Texto).Size = xreg.c_AutoOrdenCompra.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarRegistroOk()
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

                Function F_AbrirCtaPendiente(ByVal xctaabrir As AbrirCtaPendiente) As Boolean
                    Dim xtmpComPend As New FichaCompras.c_TemporalCompraPendiente
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader

                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xtb As New DataTable

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporal_compra_pendiente where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._AutoDocumentoAbrir)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)
                                    xrd.Close()

                                    If xtb.Rows.Count = 0 Then
                                        Throw New Exception("DOCUMENTO DE COMPRA PENDIENTE FUE PROCESADO POR OTRO USUARIO... VERIFIQUE POR FAVOR")
                                    End If

                                    xtmpComPend.M_CargarRegistro(xtb(0))
                                    xtb = New DataTable

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporal_compra_pendientedetalle where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._AutoDocumentoAbrir)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)
                                    xrd.Close()

                                    For Each xrow As DataRow In xtb.Rows
                                        Dim xr As New FichaCompras.c_TemporalCompraPendienteDetalle.c_Registro
                                        xr.CargarRegistro(xrow)

                                        Dim xreg As New FichaCompras.c_TemporalCompra.c_Registro
                                        xcmd.CommandText = "select a_temporalcompra from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_temporalcompra=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_temporalcompra=a_temporalcompra+1; " _
                                            + "select a_temporalcompra from contadores"
                                        xreg.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        Dim x As Integer = [Enum].Parse(GetType(TipoDocumentoCompra), xctaabrir._TipoDocumento)
                                        With xreg
                                            .c_AutoDeposito.c_Texto = xr.c_AutoDeposito.c_Texto
                                            .c_AutoMedida.c_Texto = xr.c_AutoMedida.c_Texto
                                            .c_AutoProducto.c_Texto = xr.c_AutoProducto.c_Texto
                                            .c_AutoUsuario.c_Texto = xctaabrir._FichaUsuario._AutoUsuario
                                            .c_CantidadItems.c_Valor = xr.c_CantidadItems.c_Valor
                                            .c_CodigoProducto.c_Texto = xr.c_CodigoProducto.c_Texto
                                            .c_CodigoProductoProveedor.c_Texto = xr.c_CodigoProductoProveedor.c_Texto
                                            .c_ContenidoEmpaque.c_Valor = xr.c_ContenidoEmpaque.c_Valor
                                            .c_TasaDescuento_1.c_Valor = xr.c_TasaDescuento1.c_Valor
                                            .c_TasaDescuento_2.c_Valor = xr.c_TasaDescuento2.c_Valor
                                            .c_TasaDescuento_3.c_Valor = xr.c_TasaDescuento3.c_Valor
                                            .c_MontoDescuento_1.c_Valor = xr.c_MontoDescuento1.c_Valor
                                            .c_MontoDescuento_2.c_Valor = xr.c_MontoDescuento2.c_Valor
                                            .c_MontoDescuento_3.c_Valor = xr.c_MontoDescuento3.c_Valor
                                            .c_Bono.c_Valor = xr.c_Bono.c_Valor
                                            .c_EsPesado.c_Texto = xr.c_EsPesado.c_Texto
                                            .c_NombreEstacionEquipo.c_Texto = xctaabrir._EquipoEstacion
                                            .c_FechaProceso.c_Valor = xctaabrir._FechaMovimiento
                                            .c_ForzarMedida.c_Texto = xr.c_ForzarDecimalesMedida.c_Texto
                                            .c_IdUnico.c_Texto = xctaabrir._IDUnico
                                            .c_NotasItem.c_Texto = xr.c_NotasItem.c_Texto
                                            .c_NombreEmpaque.c_Texto = xr.c_NombreEmpaque.c_Texto
                                            .c_NombreProducto.c_Texto = xr.c_NombreProducto.c_Texto
                                            .c_NombreUsuario.c_Texto = xctaabrir._FichaUsuario._NombreUsuario
                                            .c_NumeroDecimalesMedida.c_Texto = xr.c_NumeroDecimalesMedida.c_Texto
                                            .c_CostoUnitario.c_Valor = xr.c_CostoUnitario.c_Valor
                                            .c_Costo_Final.c_Valor = xr.c_CostoFinal.c_Valor
                                            .c_CostoInventario.c_Valor = xr.c_CostoInventario.c_Valor
                                            .c_PSugerido.c_Valor = xr.c_PSugerido.c_Valor
                                            .c_TasaIva.c_Valor = xr.c_TasaIva.c_Valor
                                            .c_TipoDocumento.c_Texto = x.ToString
                                            .c_TipoTasa.c_Texto = xr.c_TipoTasa.c_Texto
                                            .c_CostoTotal.c_Valor = xr.c_CostoTotal.c_Valor
                                            .c_CodigoArancel.c_Texto = xr.c_CodigoArancel.c_Texto
                                            .c_MontoArancel.c_Valor = xr.c_MontoArancel.c_Valor
                                            .c_TasaArancel.c_Valor = xr.c_TasaArancel.c_Valor
                                            .c_MontoAduana.c_Valor = xr.c_MontoAduana.c_Valor
                                            .c_TasaAduana.c_Valor = xr.c_TasaAduana.c_Valor
                                            .c_MontoServicio.c_Valor = xr.c_MontoServicio.c_Valor
                                            .c_TasaServicio.c_Valor = xr.c_TasaServicio.c_Valor
                                            .c_MontoFlete.c_Valor = xr.c_MontoFlete.c_Valor
                                            .c_MontoSeguro.c_Valor = xr.c_MontoSeguro.c_Valor
                                            .c_MontoOtros.c_Valor = xr.c_MontoOtros.c_Valor
                                            .c_CostoImportacion.c_Valor = xr.c_CostoImportacion.c_Valor
                                            .c_ValorFob.c_Valor = xr.c_ValorFob.c_Valor
                                            .c_ValorCif.c_Valor = xr.c_ValorCif.c_Valor
                                            .c_MontoImpuestoLicor.c_Valor = xr.c_MontoImpuestoLicor.c_Valor
                                            .c_AutoOrdenCompra.c_Texto = xr.c_AutoOrdenCompra.c_Texto
                                        End With

                                        xcmd.CommandText = InsertRegistroTemporalCompra
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@codigo", xreg.c_CodigoProducto.c_Texto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@cod_prod_proveedor", xreg.c_CodigoProductoProveedor.c_Texto).Size = xreg.c_CodigoProductoProveedor.c_Largo
                                            .AddWithValue("@producto", xreg.c_NombreProducto.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                            .AddWithValue("@espesado", xreg.c_EsPesado.c_Texto).Size = xreg.c_EsPesado.c_Largo
                                            .AddWithValue("@cantidad", xreg.c_CantidadItems.c_Valor)
                                            .AddWithValue("@costo_bruto", xreg.c_CostoUnitario.c_Valor)
                                            .AddWithValue("@costo_final", xreg.c_Costo_Final.c_Valor)
                                            .AddWithValue("@costoinventario", xreg.c_CostoInventario.c_Valor)
                                            .AddWithValue("@descuento1p", xreg.c_TasaDescuento_1.c_Valor)
                                            .AddWithValue("@descuento2p", xreg.c_TasaDescuento_2.c_Valor)
                                            .AddWithValue("@descuento3p", xreg.c_TasaDescuento_3.c_Valor)
                                            .AddWithValue("@descuento1", xreg.c_MontoDescuento_1.c_Valor)
                                            .AddWithValue("@descuento2", xreg.c_MontoDescuento_2.c_Valor)
                                            .AddWithValue("@descuento3", xreg.c_MontoDescuento_3.c_Valor)
                                            .AddWithValue("@bono", xreg.c_Bono.c_Valor)
                                            .AddWithValue("@tasaiva", xreg.c_TasaIva.c_Valor)
                                            .AddWithValue("@costo", xreg.c_CostoTotal.c_Valor)
                                            .AddWithValue("@codigoarancel", xreg.c_CodigoArancel.c_Texto)
                                            .AddWithValue("@arancel", xreg.c_MontoArancel.c_Valor)
                                            .AddWithValue("@arancelp", xreg.c_TasaArancel.c_Valor)
                                            .AddWithValue("@aduana", xreg.c_MontoAduana.c_Valor)
                                            .AddWithValue("@aduanap", xreg.c_TasaAduana.c_Valor)
                                            .AddWithValue("@servicio", xreg.c_MontoServicio.c_Valor)
                                            .AddWithValue("@serviciop", xreg.c_TasaServicio.c_Valor)
                                            .AddWithValue("@flete", xreg.c_MontoFlete.c_Valor)
                                            .AddWithValue("@seguro", xreg.c_MontoSeguro.c_Valor)
                                            .AddWithValue("@otros", xreg.c_MontoOtros.c_Valor)
                                            .AddWithValue("@costoimportacion", xreg.c_CostoImportacion.c_Valor)
                                            .AddWithValue("@valorfob", xreg.c_ValorFob.c_Valor)
                                            .AddWithValue("@valorcif", xreg.c_ValorCif.c_Valor)
                                            .AddWithValue("@autoitem", xreg.c_AutoItem.c_Texto).Size = xreg.c_AutoItem.c_Largo
                                            .AddWithValue("@autoproducto", xreg._AutoProducto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@nombreempaque", xreg.c_NombreEmpaque.c_Texto).Size = xreg.c_NombreEmpaque.c_Largo
                                            .AddWithValue("@contenidoempaque", xreg.c_ContenidoEmpaque.c_Valor)
                                            .AddWithValue("@automedida", xreg.c_AutoMedida.c_Texto).Size = xreg.c_AutoMedida.c_Largo
                                            .AddWithValue("@decimalesmedida", xreg.c_NumeroDecimalesMedida.c_Texto).Size = xreg.c_NumeroDecimalesMedida.c_Largo
                                            .AddWithValue("@forzarmedida", xreg.c_ForzarMedida.c_Texto).Size = xreg.c_ForzarMedida.c_Largo
                                            .AddWithValue("@tipotasa", xreg.c_TipoTasa.c_Texto).Size = xreg.c_TipoTasa.c_Largo
                                            .AddWithValue("@autodeposito", xreg.c_AutoDeposito.c_Texto).Size = xreg.c_AutoDeposito.c_Largo
                                            .AddWithValue("@autousuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                            .AddWithValue("@nombreusuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                            .AddWithValue("@fecha", xreg.c_FechaProceso.c_Valor)
                                            .AddWithValue("@estacion", xreg.c_NombreEstacionEquipo.c_Texto).Size = xreg.c_NombreEstacionEquipo.c_Largo
                                            .AddWithValue("@tipodocumento", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                            .AddWithValue("@psugerido", xreg.c_PSugerido.c_Valor)
                                            .AddWithValue("@notasitem", xreg.c_NotasItem.c_Texto).Size = xreg.c_NotasItem.c_Largo
                                            .AddWithValue("@montoimplicor", xreg.c_MontoImpuestoLicor.c_Valor)
                                            .AddWithValue("@idunico", xreg.c_IdUnico.c_Texto).Size = xreg.c_IdUnico.c_Largo
                                            .AddWithValue("@AutoOrdenCompra", xreg.c_AutoOrdenCompra.c_Texto).Size = xreg.c_AutoOrdenCompra.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    Dim xint As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporal_compra_pendientedetalle where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._AutoDocumentoAbrir)
                                    xint = xcmd.ExecuteNonQuery
                                    If xint = 0 Then
                                        Throw New Exception("DOCUMENTO DE COMPRA PENDIENTE FUE PROCESADO POR OTRO USUARIO... VERIFIQUE POR FAVOR")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporal_compra_pendiente where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xctaabrir._AutoDocumentoAbrir)
                                    xint = xcmd.ExecuteNonQuery
                                    If xint = 0 Then
                                        Throw New Exception("DOCUMENTO DE COMPRA PENDIENTE FUE PROCESADO POR OTRO USUARIO... VERIFIQUE POR FAVOR")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _AbrirPendienteOk()
                                If xtmpComPend.RegistroDato._AutomaticoProveedor <> "" Then
                                    RaiseEvent _CargarProvCtaPendiente(xtmpComPend.RegistroDato._AutomaticoProveedor)
                                End If

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

                Function F_DejarCtaPendiente(ByVal xreg As AgregarPendiente) As Boolean
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader

                    Try
                        Dim xTmpEncPend As New FichaCompras.c_TemporalCompraPendiente.c_Registro
                        With xTmpEncPend
                            .c_AutoMovimiento.c_Texto = ""
                            .c_AutoProveedor.c_Texto = xreg._FichaProveedor._Automatico
                            .c_AutoUsuario.c_Texto = xreg._FichaUsuario._AutoUsuario
                            .c_EquipoEstacion.c_Texto = xreg._EquipoEstacion
                            .c_FechaMovimiento.c_Valor = xreg._FechaMovimiento
                            .c_HoraMovimiento.c_Texto = xreg._HoraMovimiento
                            .c_MontoCtaPendiente.c_Valor = xreg._MontoPendiente
                            .c_NombreCtaPendiente.c_Texto = xreg._ANombreDe
                            .c_NombreUsuario.c_Texto = xreg._FichaUsuario._NombreUsuario
                            Select Case xreg._TipoDocumento
                                Case TipoDocumentoCompra.Factura
                                    .c_TipoDocumento.c_Texto = "1"
                                Case TipoDocumentoCompra.NotaDebito
                                    .c_TipoDocumento.c_Texto = "2"
                                Case TipoDocumentoCompra.NotaCredito
                                    .c_TipoDocumento.c_Texto = "3"
                                Case TipoDocumentoCompra.OrdenCompra
                                    .c_TipoDocumento.c_Texto = "4"
                            End Select
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Dim xtb As New DataTable

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporal_compra where idunico=@idunico and tipodocumento=@tipodoc"
                                    xcmd.Parameters.AddWithValue("@idunico", xreg._IdUnico)
                                    xcmd.Parameters.AddWithValue("@tipodoc", xTmpEncPend.c_TipoDocumento.c_Texto)
                                    xrd = xcmd.ExecuteReader()
                                    xtb.Load(xrd)
                                    If xtb.Rows.Count = 0 Then
                                        Throw New Exception("OTRO USUARIO PROCESO ESTE DOCUMENTO... VERIFIQUE POR FAVOR")
                                    End If

                                    xcmd.CommandText = "select a_temporalcompra_pendiente from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalcompra_pendiente=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalcompra_pendiente=a_temporalcompra_pendiente+1; " _
                                        + "select a_temporalcompra_pendiente from contadores"
                                    xTmpEncPend.c_AutoMovimiento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xTmpEncPend.c_ItemsCtaPendiente.c_Valor = xtb.Rows.Count

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCompras.c_TemporalCompraPendiente.InsertRegistro
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto_doc", xTmpEncPend.c_AutoMovimiento.c_Texto).Size = xTmpEncPend.c_AutoMovimiento.c_Largo
                                        .AddWithValue("@fecha_doc", xTmpEncPend.c_FechaMovimiento.c_Valor)
                                        .AddWithValue("@hora_doc", xTmpEncPend.c_HoraMovimiento.c_Texto).Size = xTmpEncPend.c_HoraMovimiento.c_Largo
                                        .AddWithValue("@monto_doc", xTmpEncPend.c_MontoCtaPendiente.c_Valor)
                                        .AddWithValue("@items_doc", xTmpEncPend.c_ItemsCtaPendiente.c_Valor)
                                        .AddWithValue("@tipo_doc", xTmpEncPend.c_TipoDocumento.c_Texto).Size = xTmpEncPend.c_TipoDocumento.c_Largo
                                        .AddWithValue("@auto_usuario", xTmpEncPend.c_AutoUsuario.c_Texto).Size = xTmpEncPend.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombre_usuario", xTmpEncPend.c_NombreUsuario.c_Texto).Size = xTmpEncPend.c_NombreUsuario.c_Largo
                                        .AddWithValue("@equipoestacion", xTmpEncPend.c_EquipoEstacion.c_Texto).Size = xTmpEncPend.c_EquipoEstacion.c_Largo
                                        .AddWithValue("@auto_proveedor", xTmpEncPend.c_AutoProveedor.c_Texto).Size = xTmpEncPend.c_AutoProveedor.c_Largo
                                        .AddWithValue("@nombre_pendiente", xTmpEncPend.c_NombreCtaPendiente.c_Texto).Size = xTmpEncPend.c_NombreCtaPendiente.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    Dim xitem As Integer = 0
                                    Dim xdet As New FichaCompras.c_TemporalCompra.c_Registro
                                    For Each xrow In xtb.Rows
                                        xdet.CargarRegistro(xrow)

                                        Dim xdetalle As New FichaCompras.c_TemporalCompraPendienteDetalle.c_Registro
                                        With xdetalle
                                            xitem += 1
                                            .c_AutoDoc.c_Texto = xTmpEncPend.c_AutoMovimiento.c_Texto
                                            .c_AutoItem.c_Texto = xitem.ToString.Trim.PadLeft(10, "0")
                                            .c_AutoDeposito.c_Texto = xdet._AutoDeposito
                                            .c_AutoMedida.c_Texto = xdet._AutoMedida
                                            .c_AutoProducto.c_Texto = xdet._AutoProducto
                                            .c_Bono.c_Valor = xdet._Bono
                                            .c_CantidadItems.c_Valor = xdet._CantidadItems
                                            .c_CodigoArancel.c_Texto = ""
                                            .c_CodigoProducto.c_Texto = xdet._CodigoProducto
                                            .c_CodigoProductoProveedor.c_Texto = xdet._CodigoProductoProveedor
                                            .c_ContenidoEmpaque.c_Valor = xdet._ContenidoEmpaque
                                            .c_CostoFinal.c_Valor = xdet._Costo_Final
                                            .c_CostoImportacion.c_Valor = 0
                                            .c_CostoInventario.c_Valor = 0
                                            .c_CostoTotal.c_Valor = xdet._CostoTotal
                                            .c_CostoUnitario.c_Valor = xdet._CostoUnitario
                                            .c_EsPesado.c_Texto = xdet.c_EsPesado.c_Texto
                                            .c_ForzarDecimalesMedida.c_Texto = xdet.c_ForzarMedida.c_Texto
                                            .c_MontoAduana.c_Valor = 0
                                            .c_MontoArancel.c_Valor = 0
                                            .c_MontoDescuento1.c_Valor = 0
                                            .c_MontoDescuento2.c_Valor = 0
                                            .c_MontoDescuento3.c_Valor = 0
                                            .c_MontoFlete.c_Valor = 0
                                            .c_MontoImpuestoLicor.c_Valor = xdet._MontoImpuestoLicor
                                            .c_MontoOtros.c_Valor = 0
                                            .c_MontoSeguro.c_Valor = 0
                                            .c_MontoServicio.c_Valor = 0
                                            .c_NombreEmpaque.c_Texto = xdet._NombreEmpaque
                                            .c_NombreProducto.c_Texto = xdet._NombreProducto
                                            .c_NotasItem.c_Texto = xdet._NotasItem
                                            .c_NumeroDecimalesMedida.c_Texto = xdet._NumeroDecimalesMedida
                                            .c_PSugerido.c_Valor = xdet._PSugerido
                                            .c_TasaAduana.c_Valor = 0
                                            .c_TasaArancel.c_Valor = 0
                                            .c_TasaDescuento1.c_Valor = xdet._Descuento_1._Tasa
                                            .c_TasaDescuento2.c_Valor = xdet._Descuento_2._Tasa
                                            .c_TasaDescuento3.c_Valor = xdet._Descuento_3._Tasa
                                            .c_TasaIva.c_Valor = xdet._TasaIva
                                            .c_TasaServicio.c_Valor = 0
                                            .c_TipoTasa.c_Texto = xdet.c_TipoTasa.c_Texto
                                            .c_ValorCif.c_Valor = 0
                                            .c_ValorFob.c_Valor = 0


                                            Dim xd1 As Decimal = 0
                                            Dim xd2 As Decimal = 0
                                            Dim xd3 As Decimal = 0
                                            Dim ximp As Decimal = 0

                                            ximp = .c_CantidadItems.c_Valor * .c_CostoUnitario.c_Valor
                                            If .c_TasaDescuento1.c_Valor > 0 Then
                                                xd1 = .c_TasaDescuento1.c_Valor * ximp / 100
                                                ximp = ximp - xd1
                                            End If

                                            If .c_TasaDescuento2.c_Valor > 0 Then
                                                xd2 = .c_TasaDescuento2.c_Valor * ximp / 100
                                                ximp = ximp - xd2
                                            End If

                                            If .c_TasaDescuento3.c_Valor > 0 Then
                                                xd3 = .c_TasaDescuento3.c_Valor * ximp / 100
                                                ximp = ximp - xd3
                                            End If

                                            .c_MontoDescuento1.c_Valor = Decimal.Round(xd1, 2, MidpointRounding.AwayFromZero)
                                            .c_MontoDescuento2.c_Valor = Decimal.Round(xd2, 2, MidpointRounding.AwayFromZero)
                                            .c_MontoDescuento3.c_Valor = Decimal.Round(xd3, 2, MidpointRounding.AwayFromZero)
                                            .c_CostoInventario.c_Valor = Decimal.Round(.c_CostoFinal.c_Valor / .c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)
                                            .c_AutoOrdenCompra.c_Texto = xdet.c_AutoOrdenCompra.c_Texto
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaCompras.c_TemporalCompraPendienteDetalle.InsertRegistro 
                                        With xcmd.Parameters
                                            .AddWithValue("@auto_doc", xdetalle.c_AutoDoc.c_Texto).Size = xdetalle.c_AutoDoc.c_Largo
                                            .AddWithValue("@codigo", xdetalle.c_CodigoProducto.c_Texto).Size = xdetalle.c_CodigoProducto.c_Largo
                                            .AddWithValue("@cod_prod_proveedor", xdetalle.c_CodigoProductoProveedor.c_Texto).Size = xdetalle.c_CodigoProductoProveedor.c_Largo
                                            .AddWithValue("@producto", xdetalle.c_NombreProducto.c_Texto).Size = xdetalle.c_NombreProducto.c_Largo
                                            .AddWithValue("@cantidad", xdetalle.c_CantidadItems.c_Valor)
                                            .AddWithValue("@costoxunidad", xdetalle.c_CostoUnitario.c_Valor)
                                            .AddWithValue("@costofinal", xdetalle.c_CostoFinal.c_Valor)
                                            .AddWithValue("@costoinventario", xdetalle.c_CostoInventario.c_Valor)
                                            .AddWithValue("@descuento1p", xdetalle.c_TasaDescuento1.c_Valor)
                                            .AddWithValue("@descuento2p", xdetalle.c_TasaDescuento2.c_Valor)
                                            .AddWithValue("@descuento3p", xdetalle.c_TasaDescuento3.c_Valor)
                                            .AddWithValue("@descuento1", xdetalle.c_MontoDescuento1.c_Valor)
                                            .AddWithValue("@descuento2", xdetalle.c_MontoDescuento2.c_Valor)
                                            .AddWithValue("@descuento3", xdetalle.c_MontoDescuento3.c_Valor)
                                            .AddWithValue("@Bono", xdetalle.c_Bono.c_Valor)
                                            .AddWithValue("@tasaiva", xdetalle.c_TasaIva.c_Valor)
                                            .AddWithValue("@costo", xdetalle.c_CostoTotal.c_Valor)
                                            .AddWithValue("@codigoarancel", xdetalle.c_CodigoArancel.c_Texto)
                                            .AddWithValue("@arancel", xdetalle.c_MontoArancel.c_Valor)
                                            .AddWithValue("@arancelp", xdetalle.c_TasaArancel.c_Valor)
                                            .AddWithValue("@aduana", xdetalle.c_MontoAduana.c_Valor)
                                            .AddWithValue("@aduanap", xdetalle.c_TasaAduana.c_Valor)
                                            .AddWithValue("@servicio", xdetalle.c_MontoServicio.c_Valor)
                                            .AddWithValue("@serviciop", xdetalle.c_TasaServicio.c_Valor)
                                            .AddWithValue("@flete", xdetalle.c_MontoFlete.c_Valor)
                                            .AddWithValue("@seguro", xdetalle.c_MontoSeguro.c_Valor)
                                            .AddWithValue("@otros", xdetalle.c_MontoOtros.c_Valor)
                                            .AddWithValue("@costoimportacion", xdetalle.c_CostoImportacion.c_Valor)
                                            .AddWithValue("@valorfob", xdetalle.c_ValorFob.c_Valor)
                                            .AddWithValue("@valorcif", xdetalle.c_ValorCif.c_Valor)
                                            .AddWithValue("@espesado", xdetalle.c_EsPesado.c_Texto).Size = xdetalle.c_EsPesado.c_Largo
                                            .AddWithValue("@autoitem", xdetalle.c_AutoItem.c_Texto).Size = xdetalle.c_AutoItem.c_Largo
                                            .AddWithValue("@autoproducto", xdetalle._AutoProducto).Size = xdetalle.c_AutoProducto.c_Largo
                                            .AddWithValue("@nombreempaque", xdetalle.c_NombreEmpaque.c_Texto).Size = xdetalle.c_NombreEmpaque.c_Largo
                                            .AddWithValue("@contenidoempaque", xdetalle.c_ContenidoEmpaque.c_Valor)
                                            .AddWithValue("@automedida", xdetalle.c_AutoMedida.c_Texto).Size = xdetalle.c_AutoMedida.c_Largo
                                            .AddWithValue("@decimalesmedida", xdetalle.c_NumeroDecimalesMedida.c_Texto).Size = xdetalle.c_NumeroDecimalesMedida.c_Largo
                                            .AddWithValue("@forzarmedida", xdetalle.c_ForzarDecimalesMedida.c_Texto).Size = xdetalle.c_ForzarDecimalesMedida.c_Largo
                                            .AddWithValue("@tipotasa", xdetalle.c_TipoTasa.c_Texto).Size = xdetalle.c_TipoTasa.c_Largo
                                            .AddWithValue("@autodeposito", xdetalle.c_AutoDeposito.c_Texto).Size = xdetalle.c_AutoDeposito.c_Largo
                                            .AddWithValue("@psugerido", xdetalle.c_PSugerido.c_Valor)
                                            .AddWithValue("@notasitem", xdetalle.c_NotasItem.c_Texto).Size = xdetalle.c_NotasItem.c_Largo
                                            .AddWithValue("@MontoImpLicor", xdetalle.c_MontoImpuestoLicor.c_Valor)
                                            .AddWithValue("@AutoOrdenCompra", xdetalle.c_AutoOrdenCompra.c_Texto).Size = xdetalle.c_AutoOrdenCompra.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporal_compra where idunico=@idunico and tipodocumento=@tipodocumento"
                                    xcmd.Parameters.AddWithValue("@idunico", xreg._IdUnico)
                                    xcmd.Parameters.AddWithValue("@tipodocumento", xTmpEncPend.c_TipoDocumento.c_Texto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _PendienteOK()
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

                Function F_RecuperarDocumento(ByVal xrecuperar As RecuperarDocumento) As Boolean
                    Dim xtr As SqlTransaction
                    Dim xrd As SqlDataReader
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Dim xtb As New DataTable
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporal_compra where " & _
                                          "fecha=@fecha and idunico=@idunico and autousuario=@autousuario and tipodocumento=@tipodocumento"
                                    xcmd.Parameters.AddWithValue("@autousuario", xrecuperar._AutoUsuario_Recuperar)
                                    xcmd.Parameters.AddWithValue("@idunico", xrecuperar._IdUnico_Recuperar)
                                    xcmd.Parameters.AddWithValue("@fecha", xrecuperar._FechaMovimiento_Recuperar)
                                    xcmd.Parameters.AddWithValue("@tipodocumento", xrecuperar._TipoDoc)
                                    xrd = xcmd.ExecuteReader()
                                    xtb.Load(xrd)
                                    xrd.Close()

                                    For Each xrow As DataRow In xtb.Rows
                                        Dim xr As New FichaCompras.c_TemporalCompra.c_Registro
                                        Dim xreg As New FichaCompras.c_TemporalCompra.c_Registro
                                        xr.CargarRegistro(xrow)

                                        xcmd.CommandText = "select a_temporalcompra from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_temporalcompra=0"
                                            xcmd.ExecuteNonQuery()
                                        End If
                                        xcmd.CommandText = "update contadores set a_temporalcompra=a_temporalcompra+1; " _
                                            + "select a_temporalcompra from contadores"
                                        xreg.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        With xreg
                                            .c_AutoDeposito.c_Texto = xr.c_AutoDeposito.c_Texto
                                            .c_AutoMedida.c_Texto = xr.c_AutoMedida.c_Texto
                                            .c_AutoProducto.c_Texto = xr.c_AutoProducto.c_Texto
                                            .c_AutoUsuario.c_Texto = xrecuperar._FichaUsuario._AutoUsuario
                                            .c_CantidadItems.c_Valor = xr.c_CantidadItems.c_Valor
                                            .c_CodigoProducto.c_Texto = xr.c_CodigoProducto.c_Texto
                                            .c_ContenidoEmpaque.c_Valor = xr.c_ContenidoEmpaque.c_Valor
                                            .c_MontoDescuento_1.c_Valor = xr.c_MontoDescuento_1.c_Valor
                                            .c_MontoDescuento_2.c_Valor = xr.c_MontoDescuento_2.c_Valor
                                            .c_MontoDescuento_3.c_Valor = xr.c_MontoDescuento_3.c_Valor
                                            .c_TasaDescuento_1.c_Valor = xr.c_TasaDescuento_1.c_Valor
                                            .c_TasaDescuento_2.c_Valor = xr.c_TasaDescuento_2.c_Valor
                                            .c_TasaDescuento_3.c_Valor = xr.c_TasaDescuento_3.c_Valor
                                            .c_Bono.c_Valor = xr.c_Bono.c_Valor
                                            .c_EsPesado.c_Texto = xr.c_EsPesado.c_Texto
                                            .c_NombreEstacionEquipo.c_Texto = xrecuperar._EquipoEstacion
                                            .c_FechaProceso.c_Valor = xrecuperar._FechaMovimiento
                                            .c_ForzarMedida.c_Texto = xr.c_ForzarMedida.c_Texto
                                            .c_IdUnico.c_Texto = xrecuperar._IDUnico
                                            .c_NotasItem.c_Texto = xr.c_NotasItem.c_Texto
                                            .c_NombreEmpaque.c_Texto = xr.c_NombreEmpaque.c_Texto
                                            .c_NombreProducto.c_Texto = xr.c_NombreProducto.c_Texto
                                            .c_NombreUsuario.c_Texto = xrecuperar._FichaUsuario._NombreUsuario
                                            .c_NumeroDecimalesMedida.c_Texto = xr.c_NumeroDecimalesMedida.c_Texto
                                            .c_CostoUnitario.c_Valor = xr.c_CostoUnitario.c_Valor
                                            .c_PSugerido.c_Valor = xr.c_PSugerido.c_Valor
                                            .c_TasaIva.c_Valor = xr.c_TasaIva.c_Valor
                                            .c_TipoDocumento.c_Texto = xrecuperar._TipoDoc
                                            .c_TipoTasa.c_Texto = xr.c_TipoTasa.c_Texto
                                            .c_CostoTotal.c_Valor = xr.c_CostoTotal.c_Valor
                                            .c_Costo_Final.c_Valor = xr.c_Costo_Final.c_Valor
                                            .c_CostoInventario.c_Valor = xr.c_CostoInventario.c_Valor
                                            .c_CodigoProductoProveedor.c_Texto = xr.c_CodigoProductoProveedor.c_Texto
                                            .c_CodigoArancel.c_Texto = xr.c_CodigoArancel.c_Texto
                                            .c_MontoArancel.c_Valor = xr.c_MontoArancel.c_Valor
                                            .c_TasaArancel.c_Valor = xr.c_TasaArancel.c_Valor
                                            .c_MontoAduana.c_Valor = xr.c_MontoAduana.c_Valor
                                            .c_TasaAduana.c_Valor = xr.c_TasaAduana.c_Valor
                                            .c_MontoServicio.c_Valor = xr.c_MontoServicio.c_Valor
                                            .c_TasaServicio.c_Valor = xr.c_TasaServicio.c_Valor
                                            .c_MontoFlete.c_Valor = xr.c_MontoFlete.c_Valor
                                            .c_MontoSeguro.c_Valor = xr.c_MontoSeguro.c_Valor
                                            .c_MontoOtros.c_Valor = xr.c_MontoOtros.c_Valor
                                            .c_CostoImportacion.c_Valor = xr.c_CostoImportacion.c_Valor
                                            .c_ValorFob.c_Valor = xr.c_ValorFob.c_Valor
                                            .c_ValorCif.c_Valor = xr.c_ValorCif.c_Valor
                                            .c_MontoImpuestoLicor.c_Valor = xr.c_MontoImpuestoLicor.c_Valor
                                            .c_AutoOrdenCompra.c_Texto = xr.c_AutoOrdenCompra.c_Texto
                                        End With

                                        xcmd.CommandText = FichaCompras.c_TemporalCompra.InsertRegistroTemporalCompra
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@codigo", xreg.c_CodigoProducto.c_Texto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@cod_prod_proveedor", xreg.c_CodigoProductoProveedor.c_Texto).Size = xreg.c_CodigoProductoProveedor.c_Largo
                                            .AddWithValue("@producto", xreg.c_NombreProducto.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                            .AddWithValue("@espesado", xreg.c_EsPesado.c_Texto).Size = xreg.c_EsPesado.c_Largo
                                            .AddWithValue("@cantidad", xreg.c_CantidadItems.c_Valor)
                                            .AddWithValue("@costo_bruto", xreg.c_CostoUnitario.c_Valor)
                                            .AddWithValue("@costo_final", xreg.c_Costo_Final.c_Valor)
                                            .AddWithValue("@costoinventario", xreg.c_CostoInventario.c_Valor)
                                            .AddWithValue("@descuento1p", xreg.c_TasaDescuento_1.c_Valor)
                                            .AddWithValue("@descuento2p", xreg.c_TasaDescuento_2.c_Valor)
                                            .AddWithValue("@descuento3p", xreg.c_TasaDescuento_3.c_Valor)
                                            .AddWithValue("@descuento1", xreg.c_MontoDescuento_1.c_Valor)
                                            .AddWithValue("@descuento2", xreg.c_MontoDescuento_2.c_Valor)
                                            .AddWithValue("@descuento3", xreg.c_MontoDescuento_3.c_Valor)
                                            .AddWithValue("@bono", xreg.c_Bono.c_Valor)
                                            .AddWithValue("@tasaiva", xreg.c_TasaIva.c_Valor)
                                            .AddWithValue("@costo", xreg.c_CostoTotal.c_Valor)
                                            .AddWithValue("@codigoarancel", xreg.c_CodigoArancel.c_Texto)
                                            .AddWithValue("@arancel", xreg.c_MontoArancel.c_Valor)
                                            .AddWithValue("@arancelp", xreg.c_TasaArancel.c_Valor)
                                            .AddWithValue("@aduana", xreg.c_MontoAduana.c_Valor)
                                            .AddWithValue("@aduanap", xreg.c_TasaAduana.c_Valor)
                                            .AddWithValue("@servicio", xreg.c_MontoServicio.c_Valor)
                                            .AddWithValue("@serviciop", xreg.c_TasaServicio.c_Valor)
                                            .AddWithValue("@flete", xreg.c_MontoFlete.c_Valor)
                                            .AddWithValue("@seguro", xreg.c_MontoSeguro.c_Valor)
                                            .AddWithValue("@otros", xreg.c_MontoOtros.c_Valor)
                                            .AddWithValue("@costoimportacion", xreg.c_CostoImportacion.c_Valor)
                                            .AddWithValue("@valorfob", xreg.c_ValorFob.c_Valor)
                                            .AddWithValue("@valorcif", xreg.c_ValorCif.c_Valor)
                                            .AddWithValue("@autoitem", xreg.c_AutoItem.c_Texto).Size = xreg.c_AutoItem.c_Largo
                                            .AddWithValue("@autoproducto", xreg._AutoProducto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@nombreempaque", xreg.c_NombreEmpaque.c_Texto).Size = xreg.c_NombreEmpaque.c_Largo
                                            .AddWithValue("@contenidoempaque", xreg.c_ContenidoEmpaque.c_Valor)
                                            .AddWithValue("@automedida", xreg.c_AutoMedida.c_Texto).Size = xreg.c_AutoMedida.c_Largo
                                            .AddWithValue("@decimalesmedida", xreg.c_NumeroDecimalesMedida.c_Texto).Size = xreg.c_NumeroDecimalesMedida.c_Largo
                                            .AddWithValue("@forzarmedida", xreg.c_ForzarMedida.c_Texto).Size = xreg.c_ForzarMedida.c_Largo
                                            .AddWithValue("@tipotasa", xreg.c_TipoTasa.c_Texto).Size = xreg.c_TipoTasa.c_Largo
                                            .AddWithValue("@autodeposito", xreg.c_AutoDeposito.c_Texto).Size = xreg.c_AutoDeposito.c_Largo
                                            .AddWithValue("@autousuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                            .AddWithValue("@nombreusuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                            .AddWithValue("@fecha", xreg.c_FechaProceso.c_Valor)
                                            .AddWithValue("@estacion", xreg.c_NombreEstacionEquipo.c_Texto).Size = xreg.c_NombreEstacionEquipo.c_Largo
                                            .AddWithValue("@tipodocumento", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                            .AddWithValue("@psugerido", xreg.c_PSugerido.c_Valor)
                                            .AddWithValue("@notasitem", xreg.c_NotasItem.c_Texto).Size = xreg.c_NotasItem.c_Largo
                                            .AddWithValue("@montoimplicor", xreg.c_MontoImpuestoLicor.c_Valor)
                                            .AddWithValue("@idunico", xreg.c_IdUnico.c_Texto).Size = xreg.c_IdUnico.c_Largo
                                            .AddWithValue("@autoordencompra", xreg.c_AutoOrdenCompra.c_Texto).Size = xreg.c_AutoOrdenCompra.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()

                                        Dim xint As Integer = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete from temporal_compra where autoitem=@autoitem"
                                        xcmd.Parameters.AddWithValue("@autoitem", xr.c_AutoItem.c_Texto)
                                        xint = xcmd.ExecuteNonQuery()
                                        If xint = 0 Then
                                            Throw New Exception("PROBLEMA AL RECUPERAR DOCUMENTO" + vbCrLf + "AL PARECER OTRO USUARIO YA PROCESO ESTE DOCUMENTO")
                                        End If
                                    Next
                                End Using
                                xtr.Commit()

                                RaiseEvent _RecuperarOK()
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

            Class c_TemporalCompraPendiente
                Class c_Registro
                    Private xautomov As CampoTexto
                    Private xfecha As CampoFecha
                    Private xhora As CampoTexto
                    Private xmonto As CampoDecimal
                    Private xitems As CampoInteger
                    Private xtipodocumento As CampoTexto
                    Private xautousuario As CampoTexto
                    Private xnombreusuario As CampoTexto
                    Private xequipo As CampoTexto
                    Private xautoproveedor As CampoTexto
                    Private xpendiente As CampoTexto

                    Protected Friend Property c_AutoMovimiento() As CampoTexto
                        Get
                            Return xautomov
                        End Get
                        Set(ByVal value As CampoTexto)
                            xautomov = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMovimiento() As String
                        Get
                            Return Me.c_AutoMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaMovimiento() As CampoFecha
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            xfecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaMovimiento() As Date
                        Get
                            Return Me.c_FechaMovimiento.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_HoraMovimiento() As CampoTexto
                        Get
                            Return xhora
                        End Get
                        Set(ByVal value As CampoTexto)
                            xhora = value
                        End Set
                    End Property

                    ReadOnly Property _HoraMovimiento() As String
                        Get
                            Return Me.c_HoraMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_MontoCtaPendiente() As CampoDecimal
                        Get
                            Return xmonto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            xmonto = value
                        End Set
                    End Property

                    ReadOnly Property _MontoTotal() As Decimal
                        Get
                            Return Me.c_MontoCtaPendiente.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_ItemsCtaPendiente() As CampoInteger
                        Get
                            Return xitems
                        End Get
                        Set(ByVal value As CampoInteger)
                            xitems = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadItems() As Integer
                        Get
                            Return Me.c_ItemsCtaPendiente.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return xtipodocumento
                        End Get
                        Set(ByVal value As CampoTexto)
                            xtipodocumento = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoCompra
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim
                                Case "1"
                                    Return TipoDocumentoCompra.Factura
                                Case "2"
                                    Return TipoDocumentoCompra.NotaDebito
                                Case "3"
                                    Return TipoDocumentoCompra.NotaCredito
                                Case "4"
                                    Return TipoDocumentoCompra.OrdenCompra
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return xautousuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            xautousuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutomaticoUsuario() As String
                        Get
                            Return Me.c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return xnombreusuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            xnombreusuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_EquipoEstacion() As CampoTexto
                        Get
                            Return xequipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            xequipo = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Return Me.c_EquipoEstacion.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return xautoproveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            xautoproveedor = value
                        End Set
                    End Property

                    ReadOnly Property _AutomaticoProveedor() As String
                        Get
                            Return Me.c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreCtaPendiente() As CampoTexto
                        Get
                            Return xpendiente
                        End Get
                        Set(ByVal value As CampoTexto)
                            xpendiente = value
                        End Set
                    End Property

                    ReadOnly Property _NombreCtaPendiente() As String
                        Get
                            Return Me.c_NombreCtaPendiente.c_Texto.Trim
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoProveedor = New CampoTexto(10, "auto_proveedor")
                        Me.c_AutoUsuario = New CampoTexto(10, "auto_usuario")
                        Me.c_EquipoEstacion = New CampoTexto(20, "equipoestacion")
                        Me.c_FechaMovimiento = New CampoFecha("fecha_doc")
                        Me.c_HoraMovimiento = New CampoTexto(10, "hora_doc")
                        Me.c_ItemsCtaPendiente = New CampoInteger("items_doc")
                        Me.c_MontoCtaPendiente = New CampoDecimal("monto_doc")
                        Me.c_NombreCtaPendiente = New CampoTexto(120, "nombre_pendiente")
                        Me.c_NombreUsuario = New CampoTexto(20, "nombre_usuario")
                        Me.c_AutoMovimiento = New CampoTexto(10, "auto_doc")
                        Me.c_TipoDocumento = New CampoTexto(1, "tipo_doc")

                        M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_AutoProveedor.c_Texto = xrow(.c_AutoProveedor.c_NombreInterno)
                                .c_AutoMovimiento.c_Texto = xrow(.c_AutoMovimiento.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)
                                .c_EquipoEstacion.c_Texto = xrow(.c_EquipoEstacion.c_NombreInterno)
                                .c_FechaMovimiento.c_Valor = xrow(.c_FechaMovimiento.c_NombreInterno)
                                .c_HoraMovimiento.c_Texto = xrow(.c_HoraMovimiento.c_NombreInterno)
                                .c_ItemsCtaPendiente.c_Valor = xrow(.c_ItemsCtaPendiente.c_NombreInterno)
                                .c_MontoCtaPendiente.c_Valor = xrow(.c_MontoCtaPendiente.c_NombreInterno)
                                .c_NombreCtaPendiente.c_Texto = xrow(.c_NombreCtaPendiente.c_NombreInterno)
                                .c_NombreUsuario.c_Texto = xrow(.c_NombreUsuario.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "TEMPORAL COMPRA PENDIENTE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

                Sub New(ByVal XROW As DataRow)
                    Me.RegistroDato = New c_Registro
                    Me.RegistroDato.CargarRegistro(XROW)
                End Sub

                Function F_BuscarCargar(ByVal xauto_doc As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from temporal_compra_pendiente where auto_doc=@auto_doc"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_doc", xauto_doc)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("DOCUMENTO PENDIENTE NO ENCONTRADO")
                        End If

                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Protected Friend Const InsertRegistro As String = "INSERT INTO Temporal_Compra_Pendiente (" _
                 + "auto_doc, " _
                 + "fecha_doc, " _
                 + "hora_doc, " _
                 + "monto_doc, " _
                 + "items_doc, " _
                 + "tipo_doc, " _
                 + "auto_usuario, " _
                 + "nombre_usuario, " _
                 + "equipoestacion, " _
                 + "auto_proveedor, " _
                 + "nombre_pendiente) " _
                 + "VALUES (" _
                 + "@auto_doc, " _
                 + "@fecha_doc, " _
                 + "@hora_doc, " _
                 + "@monto_doc, " _
                 + "@items_doc, " _
                 + "@tipo_doc, " _
                 + "@auto_usuario, " _
                 + "@nombre_usuario, " _
                 + "@equipoestacion, " _
                 + "@auto_proveedor, " _
                 + "@nombre_pendiente) "
            End Class

            Class c_TemporalCompraPendienteDetalle
                Class AgregarDetallePendiente
                    Dim xreg As c_Registro

                    WriteOnly Property _CodigoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_CodigoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoProductoProveedor() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_CodigoProductoProveedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_NombreProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Cantidad() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CantidadItems.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoUnitario() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoUnitario.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaDescuento1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaDescuento1.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaDescuento2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaDescuento2.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaDescuento3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaDescuento3.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Bono() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_Bono.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaIva() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaIva.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EsPesado() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroDetalle.c_EsPesado.c_Texto = "1"
                            Else
                                Me.RegistroDetalle.c_EsPesado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_NombreEmpaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ContenidoEmpaque() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDetalle.c_ContenidoEmpaque.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoMedida() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_AutoMedida.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NumeroDecimalesMedida() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDetalle.c_NumeroDecimalesMedida.c_Texto = value.ToString
                        End Set
                    End Property

                    WriteOnly Property _ForzarMedida() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroDetalle.c_ForzarDecimalesMedida.c_Texto = "1"
                            Else
                                Me.RegistroDetalle.c_ForzarDecimalesMedida.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _TipoTasa() As TipoTasaImpuesto
                        Set(ByVal value As TipoTasaImpuesto)
                            Select Case value
                                Case TipoTasaImpuesto.Exento
                                    Me.RegistroDetalle.c_TipoTasa.c_Texto = "0"
                                Case TipoTasaImpuesto.Vigente
                                    Me.RegistroDetalle.c_TipoTasa.c_Texto = "1"
                                Case TipoTasaImpuesto.Reducida
                                    Me.RegistroDetalle.c_TipoTasa.c_Texto = "2"
                                Case TipoTasaImpuesto.Otra
                                    Me.RegistroDetalle.c_TipoTasa.c_Texto = "3"
                                Case Else
                                    Throw New Exception("COMPRAS TEMPORAL" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + "ERROR EN EL TIPO DE IMPUESTO PARA ESTE PRODUCTO")
                            End Select
                        End Set
                    End Property

                    WriteOnly Property _AutoDeposito() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_AutoDeposito.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PSugerido() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_PSugerido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _NotasItem() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_NotasItem.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoArancel() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_CodigoArancel.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _MontoArancel() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoArancel.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaArancel() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaArancel.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoServicio() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoServicio.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaServicio() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaServicio.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoAduana() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoAduana.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaAduana() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaAduana.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoFlete() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoFlete.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoSeguro() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoSeguro.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoOtros() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoOtros.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _CostoImportacion() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoImportacion.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _ValorFob() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_ValorFob.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _ValorCif() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_ValorCif.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TotalImporte() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoTotal.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoFinal() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoFinal.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoImpuestoLicor() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_MontoImpuestoLicor.c_Valor = value
                        End Set
                    End Property

                    Protected Friend Property RegistroDetalle() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroDetalle = New c_Registro
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto_doc As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_cod_prod_pro As CampoTexto
                    Private f_producto As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_costoxunid As CampoDecimal
                    Private f_costofinal As CampoDecimal
                    Private f_descuento1p As CampoDecimal
                    Private f_descuento2p As CampoDecimal
                    Private f_descuento3p As CampoDecimal
                    Private f_descuento1 As CampoDecimal
                    Private f_descuento2 As CampoDecimal
                    Private f_descuento3 As CampoDecimal
                    Private f_bono As CampoDecimal
                    Private f_tasaiva As CampoDecimal
                    Private f_costo As CampoDecimal
                    Private f_espesado As CampoTexto
                    Private f_autoitem As CampoTexto
                    Private f_autoproducto As CampoTexto
                    Private f_nombreempaque As CampoTexto
                    Private f_contenidoempaque As CampoInteger
                    Private f_automedida As CampoTexto
                    Private f_decimalesmedida As CampoTexto
                    Private f_forzarmedida As CampoTexto
                    Private f_tipotasa As CampoTexto
                    Private f_autodeposito As CampoTexto
                    Private f_psugerido As CampoDecimal
                    Private f_notasitem As CampoTexto
                    Private f_costoinventario As CampoDecimal
                    Private f_CodigoArancel As CampoTexto
                    Private f_Arancel As CampoDecimal
                    Private f_Arancelp As CampoDecimal
                    Private f_Servicio As CampoDecimal
                    Private f_Serviciop As CampoDecimal
                    Private f_Aduana As CampoDecimal
                    Private f_Aduanap As CampoDecimal
                    Private f_Flete As CampoDecimal
                    Private f_Seguro As CampoDecimal
                    Private f_Otros As CampoDecimal
                    Private f_CostoImportacion As CampoDecimal
                    Private f_ValorFob As CampoDecimal
                    Private f_ValorCif As CampoDecimal
                    Private f_MontoImpLicor As CampoDecimal
                    Private f_autoordencompra As CampoTexto


                    Protected Friend Property c_AutoDoc() As CampoTexto
                        Get
                            Return f_auto_doc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_doc = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoProductoProveedor() As CampoTexto
                        Get
                            Return f_cod_prod_pro
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cod_prod_pro = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_producto = value
                        End Set
                    End Property

                    Protected Friend Property c_CantidadItems() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoUnitario() As CampoDecimal
                        Get
                            Return f_costoxunid
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoxunid = value
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

                    Protected Friend Property c_TasaDescuento1() As CampoDecimal
                        Get
                            Return f_descuento1p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1p = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento2() As CampoDecimal
                        Get
                            Return f_descuento2p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2p = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaDescuento3() As CampoDecimal
                        Get
                            Return f_descuento3p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento3p = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento1() As CampoDecimal
                        Get
                            Return f_descuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento2() As CampoDecimal
                        Get
                            Return f_descuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDescuento3() As CampoDecimal
                        Get
                            Return f_descuento3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento3 = value
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

                    Protected Friend Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_tasaiva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasaiva = value
                        End Set
                    End Property

                    Protected Friend Property c_CostoTotal() As CampoDecimal
                        Get
                            Return f_costo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo = value
                        End Set
                    End Property

                    Protected Friend Property c_EsPesado() As CampoTexto
                        Get
                            Return f_espesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_espesado = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoItem() As CampoTexto
                        Get
                            Return f_autoitem
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoitem = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_autoproducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoproducto = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreEmpaque() As CampoTexto
                        Get
                            Return f_nombreempaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreempaque = value
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

                    Protected Friend Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_automedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_automedida = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroDecimalesMedida() As CampoTexto
                        Get
                            Return f_decimalesmedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_decimalesmedida = value
                        End Set
                    End Property

                    Protected Friend Property c_ForzarDecimalesMedida() As CampoTexto
                        Get
                            Return f_forzarmedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_forzarmedida = value
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

                    Protected Friend Property c_AutoDeposito() As CampoTexto
                        Get
                            Return f_autodeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autodeposito = value
                        End Set
                    End Property

                    Protected Friend Property c_PSugerido() As CampoDecimal
                        Get
                            Return f_psugerido
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_psugerido = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoTexto
                        Get
                            Return f_notasitem
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_notasitem = value
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

                    Protected Friend Property c_CodigoArancel() As CampoTexto
                        Get
                            Return f_CodigoArancel
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_CodigoArancel = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoArancel() As CampoDecimal
                        Get
                            Return f_Arancel
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Arancel = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaArancel() As CampoDecimal
                        Get
                            Return f_Arancelp
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Arancelp = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoServicio() As CampoDecimal
                        Get
                            Return f_Servicio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Servicio = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaServicio() As CampoDecimal
                        Get
                            Return f_Serviciop
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Serviciop = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoAduana() As CampoDecimal
                        Get
                            Return f_Aduana
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Aduana = value
                        End Set
                    End Property
                    Protected Friend Property c_TasaAduana() As CampoDecimal
                        Get
                            Return f_Aduanap
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Aduanap = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoFlete() As CampoDecimal
                        Get
                            Return f_Flete
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Flete = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoSeguro() As CampoDecimal
                        Get
                            Return f_Seguro
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Seguro = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoOtros() As CampoDecimal
                        Get
                            Return f_Otros
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_Otros = value
                        End Set
                    End Property
                    Protected Friend Property c_CostoImportacion() As CampoDecimal
                        Get
                            Return f_CostoImportacion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_CostoImportacion = value
                        End Set
                    End Property
                    Protected Friend Property c_ValorFob() As CampoDecimal
                        Get
                            Return f_ValorFob
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_ValorFob = value
                        End Set
                    End Property
                    Protected Friend Property c_ValorCif() As CampoDecimal
                        Get
                            Return f_ValorCif
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_ValorCif = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoImpuestoLicor() As CampoDecimal
                        Get
                            Return Me.f_MontoImpLicor
                        End Get
                        Set(ByVal value As CampoDecimal)
                            Me.f_MontoImpLicor = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoOrdenCompra() As CampoTexto
                        Get
                            Return Me.f_autoordencompra
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_autoordencompra = value
                        End Set
                    End Property

                    ReadOnly Property _AutoPendiente() As String
                        Get
                            Return Me.c_AutoDoc.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Return Me.c_AutoItem.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadItems() As Decimal
                        Get
                            Return Me.c_CantidadItems.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return Me.c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoProductoProveedor() As String
                        Get
                            Return Me.c_CodigoProductoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Descuento1() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(Me.c_TasaDescuento1.c_Valor, Me.c_MontoDescuento1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento2() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(Me.c_TasaDescuento2.c_Valor, Me.c_MontoDescuento2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Descuento3() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(Me.c_TasaDescuento3.c_Valor, Me.c_MontoDescuento3.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As String
                        Get
                            Return Me.c_EsPesado.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CostoTotal() As Decimal
                        Get
                            Return c_CostoTotal.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return Me.c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CostoUnitario() As Decimal
                        Get
                            Return Me.c_CostoUnitario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoFinal() As Decimal
                        Get
                            Return Me.c_CostoFinal.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return Me.c_TasaIva.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return Me.c_NombreEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return Me.c_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDecimalesMedida() As Integer
                        Get
                            Dim xvalor As Integer = 0
                            Integer.TryParse(Me.c_NumeroDecimalesMedida.c_Texto, xvalor)
                            Return xvalor
                        End Get
                    End Property

                    ReadOnly Property _ForzarMedida() As Boolean
                        Get
                            If Me.c_ForzarDecimalesMedida.c_Texto.Trim = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _TipoTasa() As String
                        Get
                            Return Me.c_TipoTasa.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return Me.c_AutoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _PSugerido() As Decimal
                        Get
                            Return Me.c_PSugerido.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Return Me.c_NotasItem.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Impuesto() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = (_CostoTotal * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _Total() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _CostoTotal + _Impuesto
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return c_CostoInventario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoArancel() As String
                        Get
                            Return c_CodigoArancel.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoArancel() As Decimal
                        Get
                            Return c_MontoArancel.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TasaArancel() As Decimal
                        Get
                            Return c_TasaArancel.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoServicio() As Decimal
                        Get
                            Return c_MontoServicio.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TasaServicio() As Decimal
                        Get
                            Return c_TasaServicio.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoAduana() As Decimal
                        Get
                            Return c_MontoAduana.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TasaAduana() As Decimal
                        Get
                            Return c_TasaAduana.c_Valor
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
                    ReadOnly Property _MontoOtros() As Decimal
                        Get
                            Return c_MontoOtros.c_Valor
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
                    ReadOnly Property _MontoImpuestoLicor() As Decimal
                        Get
                            Return c_MontoImpuestoLicor.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _AutoOrdenCompra() As String
                        Get
                            Return c_AutoOrdenCompra.c_Texto
                        End Get
                    End Property


                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoDoc = New CampoTexto(10, "auto_doc")
                        Me.c_AutoItem = New CampoTexto(10, "autoitem")
                        Me.c_CantidadItems = New CampoDecimal("cantidad")
                        Me.c_CodigoProducto = New CampoTexto(15, "codigo")
                        Me.c_CodigoProductoProveedor = New CampoTexto(15, "cod_prod_proveedor")
                        Me.c_TasaDescuento1 = New CampoDecimal("descuento1p")
                        Me.c_TasaDescuento2 = New CampoDecimal("descuento2p")
                        Me.c_TasaDescuento3 = New CampoDecimal("descuento3p")
                        Me.c_MontoDescuento1 = New CampoDecimal("descuento1")
                        Me.c_MontoDescuento2 = New CampoDecimal("descuento2")
                        Me.c_MontoDescuento3 = New CampoDecimal("descuento3")
                        Me.c_Bono = New CampoDecimal("bono")
                        Me.c_EsPesado = New CampoTexto(1, "espesado")
                        Me.c_NombreProducto = New CampoTexto(200, "producto")
                        Me.c_CostoUnitario = New CampoDecimal("costoxunidad")
                        Me.c_CostoFinal = New CampoDecimal("costofinal")
                        Me.c_TasaIva = New CampoDecimal("tasaiva")
                        Me.c_CostoTotal = New CampoDecimal("costo")
                        Me.c_AutoProducto = New CampoTexto(10, "autoproducto")
                        Me.c_NombreEmpaque = New CampoTexto(20, "nombreempaque")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenidoempaque")
                        Me.c_AutoMedida = New CampoTexto(10, "automedida")
                        Me.c_NumeroDecimalesMedida = New CampoTexto(1, "decimalesmedida")
                        Me.c_ForzarDecimalesMedida = New CampoTexto(1, "forzarmedida")
                        Me.c_TipoTasa = New CampoTexto(1, "tipotasa")
                        Me.c_AutoDeposito = New CampoTexto(10, "autodeposito")
                        Me.c_PSugerido = New CampoDecimal("psugerido")
                        Me.c_NotasItem = New CampoTexto(160, "notasitem")
                        Me.c_CostoInventario = New CampoDecimal("CostoInventario")
                        Me.c_CodigoArancel = New CampoTexto(15, "CodigoArancel")
                        Me.c_MontoArancel = New CampoDecimal("Arancel")
                        Me.c_MontoAduana = New CampoDecimal("Aduana")
                        Me.c_MontoFlete = New CampoDecimal("Flete")
                        Me.c_MontoServicio = New CampoDecimal("Servicio")
                        Me.c_MontoSeguro = New CampoDecimal("Seguro")
                        Me.c_MontoOtros = New CampoDecimal("Otros")
                        Me.c_TasaArancel = New CampoDecimal("Arancelp")
                        Me.c_TasaAduana = New CampoDecimal("Aduanap")
                        Me.c_TasaServicio = New CampoDecimal("Serviciop")
                        Me.c_ValorFob = New CampoDecimal("ValorFob")
                        Me.c_ValorCif = New CampoDecimal("ValorCif")
                        Me.c_CostoImportacion = New CampoDecimal("CostoImportacion")
                        Me.c_MontoImpuestoLicor = New CampoDecimal("MontoImpLicor")
                        Me.c_AutoOrdenCompra = New CampoTexto(10, "AutoOrdenCompra")
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_AutoDeposito.c_Texto = xrow(.c_AutoDeposito.c_NombreInterno)
                                .c_AutoDoc.c_Texto = xrow(.c_AutoDoc.c_NombreInterno)
                                .c_AutoItem.c_Texto = xrow(.c_AutoItem.c_NombreInterno)
                                .c_AutoMedida.c_Texto = xrow(.c_AutoMedida.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_CantidadItems.c_Valor = xrow(.c_CantidadItems.c_NombreInterno)
                                .c_CodigoProducto.c_Texto = xrow(.c_CodigoProducto.c_NombreInterno)
                                .c_CodigoProductoProveedor.c_Texto = xrow(.c_CodigoProductoProveedor.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_TasaDescuento1.c_Valor = xrow(.c_TasaDescuento1.c_NombreInterno)
                                .c_TasaDescuento2.c_Valor = xrow(.c_TasaDescuento2.c_NombreInterno)
                                .c_TasaDescuento3.c_Valor = xrow(.c_TasaDescuento3.c_NombreInterno)
                                .c_MontoDescuento1.c_Valor = xrow(.c_MontoDescuento1.c_NombreInterno)
                                .c_MontoDescuento2.c_Valor = xrow(.c_MontoDescuento2.c_NombreInterno)
                                .c_MontoDescuento3.c_Valor = xrow(.c_MontoDescuento3.c_NombreInterno)
                                .c_Bono.c_Valor = xrow(.c_Bono.c_NombreInterno)
                                .c_EsPesado.c_Texto = xrow(.c_EsPesado.c_NombreInterno)
                                .c_ForzarDecimalesMedida.c_Texto = xrow(.c_ForzarDecimalesMedida.c_NombreInterno)
                                .c_NotasItem.c_Texto = xrow(.c_NotasItem.c_NombreInterno)
                                .c_NombreEmpaque.c_Texto = xrow(.c_NombreEmpaque.c_NombreInterno)
                                .c_NombreProducto.c_Texto = xrow(.c_NombreProducto.c_NombreInterno)
                                .c_NumeroDecimalesMedida.c_Texto = xrow(.c_NumeroDecimalesMedida.c_NombreInterno)
                                .c_CostoUnitario.c_Valor = xrow(.c_CostoUnitario.c_NombreInterno)
                                .c_CostoFinal.c_Valor = xrow(.c_CostoFinal.c_NombreInterno)
                                .c_PSugerido.c_Valor = xrow(.c_PSugerido.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_TipoTasa.c_Texto = xrow(.c_TipoTasa.c_NombreInterno)
                                .c_CostoTotal.c_Valor = xrow(.c_CostoTotal.c_NombreInterno)
                                .c_CostoInventario.c_Valor = xrow(.c_CostoInventario.c_NombreInterno)
                                .c_CodigoArancel.c_Texto = xrow(.c_CodigoArancel.c_NombreInterno)
                                .c_MontoArancel.c_Valor = xrow(.c_MontoArancel.c_NombreInterno)
                                .c_MontoAduana.c_Valor = xrow(.c_MontoAduana.c_NombreInterno)
                                .c_MontoFlete.c_Valor = xrow(.c_MontoFlete.c_NombreInterno)
                                .c_MontoServicio.c_Valor = xrow(.c_MontoServicio.c_NombreInterno)
                                .c_MontoSeguro.c_Valor = xrow(.c_MontoSeguro.c_NombreInterno)
                                .c_MontoOtros.c_Valor = xrow(.c_MontoOtros.c_NombreInterno)
                                .c_TasaArancel.c_Valor = xrow(.c_TasaArancel.c_NombreInterno)
                                .c_TasaAduana.c_Valor = xrow(.c_TasaAduana.c_NombreInterno)
                                .c_TasaServicio.c_Valor = xrow(.c_TasaServicio.c_NombreInterno)
                                .c_ValorFob.c_Valor = xrow(.c_ValorFob.c_NombreInterno)
                                .c_ValorCif.c_Valor = xrow(.c_ValorCif.c_NombreInterno)
                                .c_CostoImportacion.c_Valor = xrow(.c_CostoImportacion.c_NombreInterno)

                                If Not IsDBNull(xrow(c_MontoImpuestoLicor.c_NombreInterno)) Then
                                    .c_MontoImpuestoLicor.c_Valor = xrow(c_MontoImpuestoLicor.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_AutoOrdenCompra.c_NombreInterno)) Then
                                    .c_AutoOrdenCompra.c_Texto = xrow(c_AutoOrdenCompra.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "TEMPORAL COMPRA PENDIENTE DETALLE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const InsertRegistro As String = "INSERT INTO Temporal_Compra_PendienteDetalle (" _
                                 + "Auto_Doc, " _
                                 + "Codigo, " _
                                 + "Cod_Prod_Proveedor, " _
                                 + "Producto, " _
                                 + "Cantidad, " _
                                 + "CostoxUnidad, " _
                                 + "CostoFinal, " _
                                 + "CostoInventario, " _
                                 + "Descuento1p, " _
                                 + "Descuento2p, " _
                                 + "Descuento3p, " _
                                 + "Descuento1, " _
                                 + "Descuento2, " _
                                 + "Descuento3, " _
                                 + "Bono, " _
                                 + "TasaIva, " _
                                 + "Costo, " _
                                 + "CodigoArancel, " _
                                 + "Arancel, " _
                                 + "Arancelp, " _
                                 + "Aduana, " _
                                 + "Aduanap, " _
                                 + "Servicio, " _
                                 + "Serviciop, " _
                                 + "Flete, " _
                                 + "Seguro, " _
                                 + "Otros, " _
                                 + "CostoImportacion, " _
                                 + "ValorFob, " _
                                 + "ValorCif, " _
                                 + "EsPesado, " _
                                 + "AutoItem, " _
                                 + "AutoProducto, " _
                                 + "NombreEmpaque, " _
                                 + "ContenidoEmpaque, " _
                                 + "AutoMedida, " _
                                 + "DecimalesMedida, " _
                                 + "ForzarMedida, " _
                                 + "TipoTasa, " _
                                 + "AutoDeposito, " _
                                 + "PSugerido, " _
                                 + "NotasItem, " _
                                 + "MontoImpLicor, AutoOrdenCompra) " _
                                 + "VALUES (" _
                                 + "@Auto_Doc, " _
                                 + "@Codigo, " _
                                 + "@Cod_Prod_Proveedor, " _
                                 + "@Producto, " _
                                 + "@Cantidad, " _
                                 + "@CostoxUnidad, " _
                                 + "@CostoFinal, " _
                                 + "@CostoInventario, " _
                                 + "@Descuento1p, " _
                                 + "@Descuento2p, " _
                                 + "@Descuento3p, " _
                                 + "@Descuento1, " _
                                 + "@Descuento2, " _
                                 + "@Descuento3, " _
                                 + "@Bono, " _
                                 + "@TasaIva, " _
                                 + "@Costo, " _
                                 + "@CodigoArancel, " _
                                 + "@Arancel, " _
                                 + "@Arancelp, " _
                                 + "@Aduana, " _
                                 + "@Aduanap, " _
                                 + "@Servicio, " _
                                 + "@Serviciop, " _
                                 + "@Flete, " _
                                 + "@Seguro, " _
                                 + "@Otros, " _
                                 + "@CostoImportacion, " _
                                 + "@ValorFob, " _
                                 + "@ValorCif, " _
                                 + "@EsPesado, " _
                                 + "@AutoItem," _
                                 + "@AutoProducto, " _
                                 + "@NombreEmpaque, " _
                                 + "@ContenidoEmpaque, " _
                                 + "@AutoMedida, " _
                                 + "@DecimalesMedida, " _
                                 + "@ForzarMedida, " _
                                 + "@TipoTasa, " _
                                 + "@AutoDeposito, " _
                                 + "@PSugerido, " _
                                 + "@NotasItem, " _
                                 + "@MontoImpLicor, @AutoOrdenCompra) "

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

                Sub New(ByVal xrow As DataRow)
                    Me.RegistroDato = New c_Registro
                    Me.RegistroDato.CargarRegistro(xrow)
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

            Public Class c_Retenciones
                Class AgregarRetencionIva
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _FechaRelacion() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaRelacion.c_Valor = value
                            Me.RegistroDato.c_MesRelacion.c_Texto = Month(value).ToString.Trim.PadLeft(2, "0")
                            Me.RegistroDato.c_AnoRelacion.c_Texto = Year(value).ToString.Trim.PadLeft(4, "0")
                        End Set
                    End Property

                    WriteOnly Property _NumeroPlanillaRetencion() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroPlanillaRetencion.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumentoRetencion() As TipoDocumentoRetencion
                        Set(ByVal value As TipoDocumentoRetencion)
                            Select Case value
                                Case TipoDocumentoRetencion.ISLR : Me.RegistroDato.c_TipoDocumentoRetencion.c_Texto = "02"
                                Case TipoDocumentoRetencion.IVA : Me.RegistroDato.c_TipoDocumentoRetencion.c_Texto = "01"
                            End Select
                        End Set
                    End Property
                    WriteOnly Property _MontoExento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoExento.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuesto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoTotalGeneral() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoTotal.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaRetencion() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaRetencion.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoRetencion() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoRetencion.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Periodo() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_Periodo.c_Valor = value
                        End Set
                    End Property
                End Class

                Public Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_nombre As CampoTexto
                    Private f_dir_fiscal As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_exento As CampoDecimal
                    Private f_base As CampoDecimal
                    Private f_impuesto As CampoDecimal
                    Private f_total As CampoDecimal
                    Private f_tasa_retencion As CampoDecimal
                    Private f_retencion As CampoDecimal
                    Private f_auto_entidad As CampoTexto
                    Private f_fecha_relacion As CampoFecha
                    Private f_codigo_entidad As CampoTexto
                    Private f_ano_relacion As CampoTexto
                    Private f_mes_relacion As CampoTexto
                    Private f_auto_cxp As CampoTexto
                    Private f_auto_recibo_cxp As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_periodo As CampoInteger

                    Protected Friend Property c_AutoRetencion() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoCxP() As CampoTexto
                        Get
                            Return f_auto_cxp
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxp = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto_recibo_cxp
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_recibo_cxp = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroPlanillaRetencion() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreProveedor() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Protected Friend Property c_DirFiscalProveedor() As CampoTexto
                        Get
                            Return f_dir_fiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dir_fiscal = value
                        End Set
                    End Property

                    Protected Friend Property c_CiRifProveedor() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoDocumentoRetencion() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoExento() As CampoDecimal
                        Get
                            Return f_exento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_exento = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase() As CampoDecimal
                        Get
                            Return f_base
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto() As CampoDecimal
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoTotal() As CampoDecimal
                        Get
                            Return f_total
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaRetencion() As CampoDecimal
                        Get
                            Return f_tasa_retencion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa_retencion = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRetencion() As CampoDecimal
                        Get
                            Return f_retencion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_retencion = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_auto_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_entidad = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaRelacion() As CampoFecha
                        Get
                            Return f_fecha_relacion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_relacion = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigo_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_entidad = value
                        End Set
                    End Property

                    Protected Friend Property c_AnoRelacion() As CampoTexto
                        Get
                            Return f_ano_relacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ano_relacion = value
                        End Set
                    End Property

                    Protected Friend Property c_MesRelacion() As CampoTexto
                        Get
                            Return f_mes_relacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_mes_relacion = value
                        End Set
                    End Property

                    Protected Friend Property c_EstatusRetencion() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    Protected Friend Property c_Periodo() As CampoInteger
                        Get
                            Return f_periodo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_periodo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoRetencion() As String
                        Get
                            Return c_AutoRetencion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoCxP() As String
                        Get
                            Return c_AutoCxP.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroPlanillaRetencion() As String
                        Get
                            Return c_NumeroPlanillaRetencion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
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

                    ReadOnly Property _TipoDocumentoRetencion() As TipoDocumentoRetencion
                        Get
                            Select Case c_TipoDocumentoRetencion.c_Texto.Trim
                                Case "01" : Return TipoDocumentoRetencion.IVA
                                Case "02" : Return TipoDocumentoRetencion.ISLR
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _MontoExento() As Decimal
                        Get
                            Return c_MontoExento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoBase() As Decimal
                        Get
                            Return c_MontoBase.c_Valor
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

                    ReadOnly Property _Retencion() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaRetencion.c_Valor, c_MontoRetencion.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaRelacion() As Date
                        Get
                            Return New Date(c_FechaRelacion.c_Valor.Year, c_FechaRelacion.c_Valor.Month, c_FechaRelacion.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return c_CodigoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AnoRelacion() As Integer
                        Get
                            Return Int(c_AnoRelacion.c_Texto.Trim)
                        End Get
                    End Property

                    ReadOnly Property _MesRelacion() As Integer
                        Get
                            Return Int(c_MesRelacion.c_Texto.Trim)
                        End Get
                    End Property

                    ReadOnly Property _EstatusRetencion() As TipoEstatus
                        Get
                            Select Case c_EstatusRetencion.c_Texto.Trim
                                Case "0"
                                    Return TipoEstatus.Activo
                                Case "1"
                                    Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _Periodo() As Integer
                        Get
                            Return c_Periodo.c_Valor
                        End Get
                    End Property

                    Sub New()
                        c_AutoRetencion = New CampoTexto(10, "auto")
                        c_NumeroPlanillaRetencion = New CampoTexto(14, "documento")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_NombreProveedor = New CampoTexto(120, "nombre")
                        c_DirFiscalProveedor = New CampoTexto(120, "dir_fiscal")
                        c_CiRifProveedor = New CampoTexto(12, "ci_rif")
                        c_TipoDocumentoRetencion = New CampoTexto(2, "tipo")
                        c_MontoExento = New CampoDecimal("exento")
                        c_MontoBase = New CampoDecimal("base")
                        c_MontoImpuesto = New CampoDecimal("impuesto")
                        c_MontoTotal = New CampoDecimal("total")
                        c_TasaRetencion = New CampoDecimal("tasa_retencion")
                        c_MontoRetencion = New CampoDecimal("retencion")
                        c_AutoProveedor = New CampoTexto(10, "auto_entidad")
                        c_FechaRelacion = New CampoFecha("fecha_relacion")
                        c_CodigoProveedor = New CampoTexto(15, "codigo_entidad")
                        c_AnoRelacion = New CampoTexto(4, "ano_relacion")
                        c_MesRelacion = New CampoTexto(2, "mes_relacion")
                        c_AutoCxP = New CampoTexto(10, "auto_cxp")
                        c_AutoRecibo = New CampoTexto(10, "auto_recibo_cxp")
                        c_EstatusRetencion = New CampoTexto(1, "estatus")
                        c_Periodo = New CampoInteger("periodo")
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()
                            With Me
                                .c_AutoRetencion.c_Texto = xrow(.c_AutoRetencion.c_NombreInterno)
                                .c_NumeroPlanillaRetencion.c_Texto = xrow(.c_NumeroPlanillaRetencion.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_NombreProveedor.c_Texto = xrow(.c_NombreProveedor.c_NombreInterno)
                                .c_DirFiscalProveedor.c_Texto = xrow(.c_DirFiscalProveedor.c_NombreInterno)
                                .c_CiRifProveedor.c_Texto = xrow(.c_CiRifProveedor.c_NombreInterno)
                                .c_TipoDocumentoRetencion.c_Texto = xrow(.c_TipoDocumentoRetencion.c_NombreInterno)
                                .c_MontoExento.c_Valor = xrow(c_MontoExento.c_NombreInterno)
                                .c_MontoBase.c_Valor = xrow(c_MontoBase.c_NombreInterno)
                                .c_MontoImpuesto.c_Valor = xrow(c_MontoImpuesto.c_NombreInterno)
                                .c_MontoTotal.c_Valor = xrow(c_MontoTotal.c_NombreInterno)
                                .c_TasaRetencion.c_Valor = xrow(c_TasaRetencion.c_NombreInterno)
                                .c_MontoRetencion.c_Valor = xrow(c_MontoRetencion.c_NombreInterno)
                                .c_AutoProveedor.c_Texto = xrow(c_AutoProveedor.c_NombreInterno)
                                .c_FechaRelacion.c_Valor = xrow(c_FechaRelacion.c_NombreInterno)
                                .c_CodigoProveedor.c_Texto = xrow(c_CodigoProveedor.c_NombreInterno)
                                .c_AnoRelacion.c_Texto = xrow(c_AnoRelacion.c_NombreInterno)
                                .c_MesRelacion.c_Texto = xrow(c_MesRelacion.c_NombreInterno)

                                'NUEVOS
                                If Not IsDBNull(xrow(.c_AutoCxP.c_NombreInterno)) Then
                                    .c_AutoCxP.c_Texto = xrow(.c_AutoCxP.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoRecibo.c_NombreInterno)) Then
                                    .c_AutoRecibo.c_Texto = xrow(.c_AutoRecibo.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_EstatusRetencion.c_NombreInterno)) Then
                                    .c_EstatusRetencion.c_Texto = xrow(.c_EstatusRetencion.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_Periodo.c_NombreInterno)) Then
                                    .c_Periodo.c_Valor = xrow(.c_Periodo.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "RETENCION COMPRA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    Function AnoRelacion() As String
                        Return Year(c_FechaRelacion.c_Valor).ToString
                    End Function

                    Function MesRelacion() As String
                        Return Month(c_FechaRelacion.c_Valor).ToString.Trim.PadLeft(2, "0")
                    End Function

                    Function RetornarPeriodo() As Integer
                        If c_FechaRelacion.c_Valor.Day > 15 Then
                            Return 2
                        Else
                            Return 1
                        End If
                    End Function

                    Function RetornarPeriodo(ByVal xfecha As Date) As Integer
                        If xfecha.Day > 15 Then
                            Return 2
                        Else
                            Return 1
                        End If
                    End Function

                    Function VerificarDocumento_AnoMesPeriodo(ByVal xfecha As Date) As Boolean
                        If Me.RetornarPeriodo(xfecha) = Me._Periodo And Year(xfecha) = _AnoRelacion And Month(xfecha) = _MesRelacion Then
                            Return True
                        Else
                            Return False
                        End If
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

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarDocumento(ByVal xauto As String) As Boolean
                    Dim xtb As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from retenciones_compras where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(xtb)
                        End Using
                        If (xtb.Rows.Count > 0) Then
                            M_CargarRegistro(xtb.Rows.Item(0))
                        Else
                            Throw New Exception("AUTO DEL DOCUMENTO NO ENCONTRADO / DOCUMENTO FUE ANULADO POR OTRO USUARIO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("RETENCION COMPRAS" + vbCrLf + "BUSCAR DOCUMENTO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class c_RetencionesDetalle
                Class AgregarRetencionIvaDetalle
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _AutoDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NumeroDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoExento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoExento.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoBase() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoBase1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoBase3.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuesto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuesto1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuesto2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoImpuesto3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto3.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoTotal() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoTotal.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaRetencion() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaRetencion.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _MontoRetencion() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoRetencion.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _NumeroControlFiscal() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroControlFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DocumentoAplica() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DocumentoAplica.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumento() As TipoDocumentoCompra
                        Set(ByVal value As TipoDocumentoCompra)
                            Select Case value
                                Case TipoDocumentoCompra.Factura : Me.RegistroDato.c_TipoDocumento.c_Texto = "01"
                                Case TipoDocumentoCompra.NotaDebito : Me.RegistroDato.c_TipoDocumento.c_Texto = "02"
                                Case TipoDocumentoCompra.NotaCredito : Me.RegistroDato.c_TipoDocumento.c_Texto = "03"
                            End Select
                        End Set
                    End Property

                    WriteOnly Property _Tasa1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Tasa2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Tasa3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa3.c_Valor = value
                        End Set
                    End Property
                End Class

                Public Class c_Registro
                    Private f_auto_documento As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_exento As CampoDecimal
                    Private f_base As CampoDecimal
                    Private f_base1 As CampoDecimal
                    Private f_base2 As CampoDecimal
                    Private f_base3 As CampoDecimal
                    Private f_impuesto As CampoDecimal
                    Private f_impuesto1 As CampoDecimal
                    Private f_impuesto2 As CampoDecimal
                    Private f_impuesto3 As CampoDecimal
                    Private f_total As CampoDecimal
                    Private f_tasa_retencion As CampoDecimal
                    Private f_retencion As CampoDecimal
                    Private f_control As CampoTexto
                    Private f_aplica As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_tasa1 As CampoDecimal
                    Private f_tasa2 As CampoDecimal
                    Private f_tasa3 As CampoDecimal
                    Private f_auto As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_comprobante As CampoTexto
                    Private f_tipo_retencion As CampoTexto
                    Private f_fecha_retencion As CampoFecha
                    Private f_estatus As CampoTexto

                    Protected Friend Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroDocumento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoExento() As CampoDecimal
                        Get
                            Return f_exento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_exento = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase() As CampoDecimal
                        Get
                            Return f_base
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase1() As CampoDecimal
                        Get
                            Return f_base1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase2() As CampoDecimal
                        Get
                            Return f_base2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoBase3() As CampoDecimal
                        Get
                            Return f_base3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base3 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto() As CampoDecimal
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto = value
                        End Set
                    End Property


                    Protected Friend Property c_MontoImpuesto1() As CampoDecimal
                        Get
                            Return f_impuesto1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto1 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto2() As CampoDecimal
                        Get
                            Return f_impuesto2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto2 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImpuesto3() As CampoDecimal
                        Get
                            Return f_impuesto3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto3 = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoTotal() As CampoDecimal
                        Get
                            Return f_total
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaRetencion() As CampoDecimal
                        Get
                            Return f_tasa_retencion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa_retencion = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRetencion() As CampoDecimal
                        Get
                            Return f_retencion
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_retencion = value
                        End Set
                    End Property

                    Protected Friend Property c_NumeroControlFiscal() As CampoTexto
                        Get
                            Return f_control
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_control = value
                        End Set
                    End Property


                    Protected Friend Property c_DocumentoAplica() As CampoTexto
                        Get
                            Return f_aplica
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_aplica = value
                        End Set
                    End Property


                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
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
                    Protected Friend Property c_AutoRetencion() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property


                    Protected Friend Property c_CiRifProveedor() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    Protected Friend Property c_ComprobanteRetencion() As CampoTexto
                        Get
                            Return f_comprobante
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comprobante = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoRetencion() As CampoTexto
                        Get
                            Return f_tipo_retencion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_retencion = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaRetencion() As CampoFecha
                        Get
                            Return f_fecha_retencion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_retencion = value
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

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumento() As String
                        Get
                            Return c_NumeroDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _MontoExento() As Decimal
                        Get
                            Return c_MontoExento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoTotalBase() As Decimal
                        Get
                            Return c_MontoBase.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoTotalImpuesto() As Decimal
                        Get
                            Return c_MontoImpuesto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Base_Impuesto_Tasa1() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase1.c_Valor, c_MontoImpuesto1.c_Valor, c_Tasa1.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Base_Impuesto_Tasa2() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase2.c_Valor, c_MontoImpuesto2.c_Valor, c_Tasa2.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _Base_Impuesto_Tasa3() As Base_Impuesto_Tasa
                        Get
                            Return New Base_Impuesto_Tasa(c_MontoBase3.c_Valor, c_MontoImpuesto3.c_Valor, c_Tasa3.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _MontoTotal() As Decimal
                        Get
                            Return c_MontoTotal.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Retencion() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaRetencion.c_Valor, c_MontoRetencion.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _NumeroControlFiscal() As String
                        Get
                            Return c_NumeroControlFiscal.c_Texto.Trim
                        End Get
                    End Property


                    ReadOnly Property _DocumentoAplica() As String
                        Get
                            Return c_DocumentoAplica.c_Texto.Trim
                        End Get
                    End Property


                    ReadOnly Property _TipoDocumento() As TipoDocumentoCompra
                        Get
                            Select Case c_TipoDocumento.c_Texto.Trim
                                Case "01" : Return TipoDocumentoCompra.Factura
                                Case "02" : Return TipoDocumentoCompra.NotaDebito
                                Case "03" : Return TipoDocumentoCompra.NotaCredito
                                Case "04" : Return TipoDocumentoCompra.OrdenCompra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoRetencion() As String
                        Get
                            Return c_AutoRetencion.c_Texto.Trim
                        End Get
                    End Property


                    ReadOnly Property _CiRifProveedor() As String
                        Get
                            Return c_CiRifProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ComprobanteRetencion() As String
                        Get
                            Return c_ComprobanteRetencion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoRetencion() As TipoDocumentoRetencion
                        Get
                            Select Case c_TipoRetencion.c_Texto.Trim
                                Case "01" : Return TipoDocumentoRetencion.IVA
                                Case "02" : Return TipoDocumentoRetencion.ISLR
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _FechaRetencion() As Date
                        Get
                            Return New Date(c_FechaRetencion.c_Valor.Year, c_FechaRetencion.c_Valor.Month, c_FechaRetencion.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case c_Estatus.c_Texto.Trim
                                Case "0"
                                    Return TipoEstatus.Activo
                                Case "1"
                                    Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    Sub New()
                        c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        c_NumeroDocumento = New CampoTexto(15, "documento")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_MontoExento = New CampoDecimal("exento")
                        c_MontoBase = New CampoDecimal("base")
                        c_MontoBase1 = New CampoDecimal("base1")
                        c_MontoBase2 = New CampoDecimal("base2")
                        c_MontoBase3 = New CampoDecimal("base3")
                        c_MontoImpuesto = New CampoDecimal("impuesto")
                        c_MontoImpuesto1 = New CampoDecimal("impuesto1")
                        c_MontoImpuesto2 = New CampoDecimal("impuesto2")
                        c_MontoImpuesto3 = New CampoDecimal("impuesto3")
                        c_MontoTotal = New CampoDecimal("total")
                        c_TasaRetencion = New CampoDecimal("tasa_retencion")
                        c_MontoRetencion = New CampoDecimal("retencion")
                        c_NumeroControlFiscal = New CampoTexto(15, "control")
                        c_DocumentoAplica = New CampoTexto(10, "aplica")
                        c_TipoDocumento = New CampoTexto(2, "tipo")
                        c_Tasa1 = New CampoDecimal("tasa1")
                        c_Tasa2 = New CampoDecimal("tasa2")
                        c_Tasa3 = New CampoDecimal("tasa3")
                        c_AutoRetencion = New CampoTexto(10, "auto")
                        c_CiRifProveedor = New CampoTexto(12, "ci_rif")
                        c_ComprobanteRetencion = New CampoTexto(14, "comprobante")
                        c_TipoRetencion = New CampoTexto(2, "tipo_retencion")
                        c_FechaRetencion = New CampoFecha("fecha_retencion")
                        c_Estatus = New CampoTexto(1, "estatus")
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()
                            With Me
                                .c_AutoDocumento.c_Texto = xrow(c_AutoDocumento.c_NombreInterno)
                                .c_NumeroDocumento.c_Texto = xrow(c_NumeroDocumento.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(c_FechaEmision.c_NombreInterno)
                                .c_MontoExento.c_Valor = xrow(c_MontoExento.c_NombreInterno)
                                .c_MontoBase.c_Valor = xrow(c_MontoBase.c_NombreInterno)
                                If Not IsDBNull(xrow(c_MontoBase1.c_NombreInterno)) Then
                                    .c_MontoBase1.c_Valor = xrow(c_MontoBase1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_MontoBase2.c_NombreInterno)) Then
                                    .c_MontoBase2.c_Valor = xrow(c_MontoBase2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_MontoBase3.c_NombreInterno)) Then
                                    .c_MontoBase3.c_Valor = xrow(c_MontoBase3.c_NombreInterno)
                                End If
                                .c_MontoImpuesto.c_Valor = xrow(c_MontoImpuesto.c_NombreInterno)
                                If Not IsDBNull(xrow(c_MontoImpuesto1.c_NombreInterno)) Then
                                    .c_MontoImpuesto1.c_Valor = xrow(c_MontoImpuesto1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_MontoImpuesto2.c_NombreInterno)) Then
                                    .c_MontoImpuesto2.c_Valor = xrow(c_MontoImpuesto2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(c_MontoImpuesto3.c_NombreInterno)) Then
                                    .c_MontoImpuesto3.c_Valor = xrow(c_MontoImpuesto3.c_NombreInterno)
                                End If
                                .c_MontoTotal.c_Valor = xrow(c_MontoTotal.c_NombreInterno)
                                .c_TasaRetencion.c_Valor = xrow(c_TasaRetencion.c_NombreInterno)
                                .c_MontoRetencion.c_Valor = xrow(c_MontoRetencion.c_NombreInterno)
                                .c_NumeroControlFiscal.c_Texto = xrow(c_NumeroControlFiscal.c_NombreInterno)
                                .c_DocumentoAplica.c_Texto = xrow(c_DocumentoAplica.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(c_TipoDocumento.c_NombreInterno)
                                If Not IsDBNull(xrow(c_Tasa1.c_NombreInterno)) Then
                                    .c_Tasa1.c_Valor = xrow(c_Tasa1.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(c_Tasa2.c_NombreInterno)) Then
                                    .c_Tasa2.c_Valor = xrow(c_Tasa2.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(c_Tasa3.c_NombreInterno)) Then
                                    .c_Tasa3.c_Valor = xrow(c_Tasa3.c_NombreInterno)
                                End If
                                .c_AutoRetencion.c_Texto = xrow(c_AutoRetencion.c_NombreInterno)
                                .c_CiRifProveedor.c_Texto = xrow(c_CiRifProveedor.c_NombreInterno)
                                .c_ComprobanteRetencion.c_Texto = xrow(c_ComprobanteRetencion.c_NombreInterno)
                                .c_TipoRetencion.c_Texto = xrow(c_TipoRetencion.c_NombreInterno)
                                .c_FechaRetencion.c_Valor = xrow(c_FechaRetencion.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("COMPRAS" + vbCrLf + "RETENCION IVA DETALLE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

            Class GrabarRetenciones
                Dim xretencion As c_Retenciones.AgregarRetencionIva
                Dim xretencion_detalle As List(Of c_RetencionesDetalle.AgregarRetencionIvaDetalle)
                Dim xproveedor As FichaProveedores.c_Proveedor.c_Registro
                Dim xusuario As FichaGlobal.c_Usuario.c_Registro

                ReadOnly Property _TipoPagoOrigen() As String
                    Get
                        Return "3"
                    End Get
                End Property

                Property _Retencion() As c_Retenciones.AgregarRetencionIva
                    Get
                        Return xretencion
                    End Get
                    Set(ByVal value As c_Retenciones.AgregarRetencionIva)
                        xretencion = value
                    End Set
                End Property

                Property _RetencionDetalle() As List(Of c_RetencionesDetalle.AgregarRetencionIvaDetalle)
                    Get
                        Return xretencion_detalle
                    End Get
                    Set(ByVal value As List(Of c_RetencionesDetalle.AgregarRetencionIvaDetalle))
                        xretencion_detalle = value
                    End Set
                End Property

                Property _Proveedor() As FichaProveedores.c_Proveedor.c_Registro
                    Get
                        Return xproveedor
                    End Get
                    Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                        xproveedor = value
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
            End Class

            Private xtemporalcompra As c_TemporalCompra
            Private xcompras As c_Compra
            Private xcomprasdetalle As c_ComprasDetalle
            Private xretenciones As c_Retenciones
            Private xretencionesdetalle As c_RetencionesDetalle

            Property F_TemporalCompra() As c_TemporalCompra
                Get
                    Return xtemporalcompra
                End Get
                Set(ByVal value As c_TemporalCompra)
                    xtemporalcompra = value
                End Set
            End Property

            Property F_Compras() As c_Compra
                Get
                    Return xcompras
                End Get
                Set(ByVal value As c_Compra)
                    xcompras = value
                End Set
            End Property

            Property F_ComprasDetalle() As c_ComprasDetalle
                Get
                    Return xcomprasdetalle
                End Get
                Set(ByVal value As c_ComprasDetalle)
                    xcomprasdetalle = value
                End Set
            End Property

            Property F_Retenciones() As c_Retenciones
                Get
                    Return xretenciones
                End Get
                Set(ByVal value As c_Retenciones)
                    xretenciones = value
                End Set
            End Property

            Property F_RetencionesDetalle() As c_RetencionesDetalle
                Get
                    Return xretencionesdetalle
                End Get
                Set(ByVal value As c_RetencionesDetalle)
                    xretencionesdetalle = value
                End Set
            End Property

            Sub New()
                Me.F_TemporalCompra = New c_TemporalCompra
                Me.F_Compras = New c_Compra
                Me.F_ComprasDetalle = New c_ComprasDetalle
                Me.F_Retenciones = New c_Retenciones
                Me.F_RetencionesDetalle = New c_RetencionesDetalle
            End Sub

#Region "FUNCIONES SELECT"
            Protected Friend Const INSERT_COMPRAS As String = "INSERT INTO compras (" _
                + "auto" _
                + ", documento" _
                + ", fecha" _
                + ", fecha_vencimiento" _
                + ", nombre" _
                + ", dir_fiscal" _
                + ", ci_rif" _
                + ", tipo" _
                + ", exento" _
                + ", base1" _
                + ", base2" _
                + ", base3" _
                + ", impuesto1" _
                + ", impuesto2" _
                + ", impuesto3" _
                + ", base" _
                + ", impuesto" _
                + ", total" _
                + ", tasa1" _
                + ", tasa2" _
                + ", tasa3" _
                + ", nota" _
                + ", tasa_retencion_iva" _
                + ", tasa_retencion_islr" _
                + ", retencion_iva" _
                + ", retencion_islr" _
                + ", auto_entidad" _
                + ", codigo_entidad" _
                + ", mes_relacion" _
                + ", genero" _
                + ", control" _
                + ", fecha_carga" _
                + ", orden_compra" _
                + ", dias" _
                + ", descuento1" _
                + ", descuento2" _
                + ", cargos" _
                + ", descuento1_porcentaje" _
                + ", descuento2_porcentaje" _
                + ", cargos_porcentaje" _
                + ", columna" _
                + ", estatus" _
                + ", flete" _
                + ", fletep" _
                + ", seguro" _
                + ", segurop" _
                + ", arancel" _
                + ", arancelp" _
                + ", servicio" _
                + ", serviciop" _
                + ", aduana" _
                + ", aduanap" _
                + ", agente" _
                + ", agentep" _
                + ", gastos" _
                + ", gastosp" _
                + ", otros" _
                + ", otrosp" _
                + ", expediente" _
                + ", aplica" _
                + ", comprobante_retencion" _
                + ", subtotal" _
                + ", telefono" _
                + ", factor_cambio" _
                + ", planilla_importacion" _
                + ", retencion_iva_terceros" _
                + ", anticipo_iva_importacion" _
                + ", ano_relacion" _
                + ", comprobante_retencion_islr" _
                + ", n_serie" _
                + ", n_serieaplica" _
                + ", n_auto_usuario" _
                + ", n_codigo_usuario" _
                + ", n_usuario" _
                + ", n_estacion" _
                + ", n_hora" _
                + ", n_periodo" _
                + ", renglones" _
                + ", n_tipo_compra" _
                + ", n_montoimplicor, n_concepto_gasto) " _
                + "VALUES(" _
                + "@auto" _
                + ", @documento" _
                + ", @fecha" _
                + ", @fecha_vencimiento" _
                + ", @nombre" _
                + ", @dir_fiscal" _
                + ", @ci_rif" _
                + ", @tipo" _
                + ", @exento" _
                + ", @base1" _
                + ", @base2" _
                + ", @base3" _
                + ", @impuesto1" _
                + ", @impuesto2" _
                + ", @impuesto3" _
                + ", @base" _
                + ", @impuesto" _
                + ", @total" _
                + ", @tasa1" _
                + ", @tasa2" _
                + ", @tasa3" _
                + ", @nota" _
                + ", @tasa_retencion_iva" _
                + ", @tasa_retencion_islr" _
                + ", @retencion_iva" _
                + ", @retencion_islr" _
                + ", @auto_entidad" _
                + ", @codigo_entidad" _
                + ", @mes_relacion" _
                + ", @genero" _
                + ", @control" _
                + ", @fecha_carga" _
                + ", @orden_compra" _
                + ", @dias" _
                + ", @descuento1" _
                + ", @descuento2" _
                + ", @cargos" _
                + ", @descuento1_porcentaje" _
                + ", @descuento2_porcentaje" _
                + ", @cargos_porcentaje" _
                + ", @columna" _
                + ", @estatus" _
                + ", @flete" _
                + ", @fletep" _
                + ", @seguro" _
                + ", @segurop" _
                + ", @arancel" _
                + ", @arancelp" _
                + ", @servicio" _
                + ", @serviciop" _
                + ", @aduana" _
                + ", @aduanap" _
                + ", @agente" _
                + ", @agentep" _
                + ", @gastos" _
                + ", @gastosp" _
                + ", @otros" _
                + ", @otrosp" _
                + ", @expediente" _
                + ", @aplica" _
                + ", @comprobante_retencion" _
                + ", @subtotal" _
                + ", @telefono" _
                + ", @factor_cambio" _
                + ", @planilla_importacion" _
                + ", @retencion_iva_terceros" _
                + ", @anticipo_iva_importacion" _
                + ", @ano_relacion" _
                + ", @comprobante_retencion_islr" _
                + ", @n_serie" _
                + ", @n_serieaplica" _
                + ", @n_auto_usuario" _
                + ", @n_codigo_usuario" _
                + ", @n_usuario" _
                + ", @n_estacion" _
                + ", @n_hora" _
                + ", @n_periodo" _
                + ", @renglones" _
                + ", @n_tipo_compra" _
                + ", @n_montoimplicor, @n_concepto_gasto)"

            Protected Friend Const INSERT_COMPRAS_DETALLE As String = "INSERT INTO compras_detalle (" _
                + "auto_documento" _
                + ",auto_productos" _
                + ",codigo" _
                + ",nombre" _
                + ",auto_departamento" _
                + ",auto_grupo" _
                + ",auto_subgrupo" _
                + ",auto_deposito" _
                + ",cantidad" _
                + ",bono" _
                + ",empaque" _
                + ",costo_bruto" _
                + ",costo_final" _
                + ",descuento1p" _
                + ",descuento2p" _
                + ",descuento3p" _
                + ",descuento1" _
                + ",descuento2" _
                + ",descuento3" _
                + ",costo" _
                + ",total_neto" _
                + ",tasa" _
                + ",impuesto" _
                + ",total" _
                + ",auto" _
                + ",codigo_arancel" _
                + ",arancel" _
                + ",arancelp" _
                + ",tasa_servicio" _
                + ",tasa_serviciop" _
                + ",tasa_aduana" _
                + ",tasa_aduanap" _
                + ",codigo_tasa" _
                + ",estatus" _
                + ",fecha" _
                + ",tipo" _
                + ",deposito" _
                + ",signo" _
                + ",auto_entidad" _
                + ",decimales" _
                + ",contenido_empaque" _
                + ",cantidad_inventario" _
                + ",costo_inventario" _
                + ",flete" _
                + ",seguro" _
                + ",otros" _
                + ",costo_importacion" _
                + ",valor_fob" _
                + ",valor_cif" _
                + ",codigo_deposito" _
                + ",empaque_tipo" _
                + ",detalle" _
                + ",categoria" _
                + ",codigo_proveedor" _
                + ",N_espesado" _
                + ",N_forzarmedida" _
                + ",N_automedida" _
                + ",N_periodo" _
                + ",N_tipomovimiento" _
                + ",N_montoimplicor, N_PSUGERIDO) " _
                + "VALUES(" _
                + "@auto_documento" _
                + ",@auto_productos" _
                + ",@codigo" _
                + ",@nombre" _
                + ",@auto_departamento" _
                + ",@auto_grupo" _
                + ",@auto_subgrupo" _
                + ",@auto_deposito" _
                + ",@cantidad" _
                + ",@bono" _
                + ",@empaque" _
                + ",@costo_bruto" _
                + ",@costo_final" _
                + ",@descuento1p" _
                + ",@descuento2p" _
                + ",@descuento3p" _
                + ",@descuento1" _
                + ",@descuento2" _
                + ",@descuento3" _
                + ",@costo" _
                + ",@total_neto" _
                + ",@tasa" _
                + ",@impuesto" _
                + ",@total" _
                + ",@auto" _
                + ",@codigo_arancel" _
                + ",@arancel" _
                + ",@arancelp" _
                + ",@tasa_servicio" _
                + ",@tasa_serviciop" _
                + ",@tasa_aduana" _
                + ",@tasa_aduanap" _
                + ",@codigo_tasa" _
                + ",@estatus" _
                + ",@fecha" _
                + ",@tipo" _
                + ",@deposito" _
                + ",@signo" _
                + ",@auto_entidad" _
                + ",@decimales" _
                + ",@contenido_empaque" _
                + ",@cantidad_inventario" _
                + ",@costo_inventario" _
                + ",@flete" _
                + ",@seguro" _
                + ",@otros" _
                + ",@costo_importacion" _
                + ",@valor_fob" _
                + ",@valor_cif" _
                + ",@codigo_deposito" _
                + ",@empaque_tipo" _
                + ",@detalle" _
                + ",@categoria" _
                + ",@codigo_proveedor" _
                + ",@N_espesado" _
                + ",@N_forzarmedida" _
                + ",@N_automedida" _
                + ",@N_periodo" _
                + ",@N_tipomovimiento" _
                + ",@N_montoimplicor, @N_PSUGERIDO)"

            Protected Friend Const INSERT_RETENCIONESIVA_COMPRAS As String = "INSERT INTO retenciones_compras (" _
               + "auto" _
               + ",documento" _
               + ",fecha" _
               + ",nombre" _
               + ",dir_fiscal" _
               + ",ci_rif" _
               + ",tipo" _
               + ",exento" _
               + ",base" _
               + ",impuesto" _
               + ",total" _
               + ",tasa_retencion" _
               + ",retencion" _
               + ",auto_entidad" _
               + ",fecha_relacion" _
               + ",codigo_entidad" _
               + ",ano_relacion" _
               + ",mes_relacion" _
               + ",auto_cxp" _
               + ",estatus" _
               + ",periodo" _
               + ",auto_recibo_cxp) " _
               + "VALUES(" _
               + "@auto" _
               + ",@documento" _
               + ",@fecha" _
               + ",@nombre" _
               + ",@dir_fiscal" _
               + ",@ci_rif" _
               + ",@tipo" _
               + ",@exento" _
               + ",@base" _
               + ",@impuesto" _
               + ",@total" _
               + ",@tasa_retencion" _
               + ",@retencion" _
               + ",@auto_entidad" _
               + ",@fecha_relacion" _
               + ",@codigo_entidad" _
               + ",@ano_relacion" _
               + ",@mes_relacion" _
               + ",@auto_cxp" _
               + ",@estatus" _
               + ",@periodo" _
               + ",@auto_recibo_cxp) "

            Protected Friend Const INSERT_RETENCIONESIVA_COMPRAS_DETALLE As String = "INSERT INTO retenciones_compras_detalle (" _
               + "auto_documento" _
               + ",documento" _
               + ",fecha" _
               + ",exento" _
               + ",base" _
                + ", base1" _
                + ", base2" _
                + ", base3" _
               + ",impuesto" _
               + ", impuesto1" _
                + ", impuesto2" _
                + ", impuesto3" _
               + ",total" _
               + ",tasa_retencion" _
               + ",retencion" _
               + ",control" _
               + ",aplica" _
               + ",tipo" _
                + ", tasa1" _
                + ", tasa2" _
                + ", tasa3" _
               + ",auto" _
               + ",ci_rif" _
               + ",comprobante" _
               + ",tipo_retencion" _
               + ",estatus" _
               + ",fecha_retencion) " _
               + "VALUES(" _
               + "@auto_documento" _
               + ",@documento" _
               + ",@fecha" _
               + ",@exento" _
               + ",@base" _
               + ", @base1" _
                + ", @base2" _
                + ", @base3" _
               + ",@impuesto" _
                + ", @impuesto1" _
                + ", @impuesto2" _
                + ", @impuesto3" _
               + ",@total" _
               + ",@tasa_retencion" _
               + ",@retencion" _
               + ",@control" _
               + ",@aplica" _
               + ",@tipo" _
               + ", @tasa1" _
                + ", @tasa2" _
                + ", @tasa3" _
               + ",@auto" _
               + ",@ci_rif" _
               + ",@comprobante" _
               + ",@tipo_retencion" _
               + ",@estatus" _
               + ",@fecha_retencion) "

            Protected Friend Const UPDATE_COMPRAS_RETENCION_IVA As String = "Update compras set " _
               + "comprobante_retencion='', retencion_iva=0, tasa_retencion_iva=0 " _
               + "where auto=@auto"

            Protected Friend Const UPDATE_CXP_RETENCION_IVA As String = "Update cxp set " _
                       + "acumulado=acumulado-@monto, resta=resta+@monto,cancelado='0' " _
                       + "where auto_documento=@auto_documento"

            Protected Friend Const UPDATE_PRODUCTOS As String = "UPDATE PRODUCTOS SET " _
                + "costo_proveedor_compra=@costo_proveedor_compra" _
                + ",costo_proveedor_inventario=@costo_proveedor_inventario" _
                + ",costo_compra=@costo_compra" _
                + ",costo_inventario=@costo_inventario" _
                + ",costo_promedio_compra=@costo_promedio_compra" _
                + ",costo_promedio_inventario=@costo_promedio_inventario" _
                + ",psv=@psv " _
                + "WHERE auto=@auto"

            Protected Friend Const UPDATE_PRODUCTOS_DEPOSITO As String = "UPDATE productos_deposito SET " _
                + "real=real+@cantidad_inventario" _
                + ",disponible=disponible+@cantidad_inventario " _
                + "WHERE auto_producto=@auto_producto and auto_deposito=@auto_deposito"

#End Region



            ''' <summary>
            ''' Permite Procesar Una Orden Compra
            ''' </summary>
            ''' <param name="xgrabarcompra"></param>
            ''' CLASE QUE PERMITE PROCESAR LA COMPRA
            Function F_GrabarOrdenCompra(ByVal xgrabarcompra As GrabarCompra)
                Dim xsql_1 As String = "update contadores set a_compras=a_compras+1; select a_compras from contadores"
                Dim xsql_2 As String = "update contadores set a_orden_compra_numero =a_orden_compra_numero +1; select a_orden_compra_numero from contadores"
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
                        .c_ConceptoGasto.c_Texto = ""
                    End With

                    Dim xauto As Integer = 0
                    For Each xdetalle In xgrabarcompra._CompraDetalle
                        xauto += 1

                        With xdetalle._FichaRegistroDetalleCompra
                            .c_AutoDepartamento.c_Texto = xdetalle._FichaProducto._AutoDepartamento
                            .c_AutoDeposito.c_Texto = xdetalle._FichaDeposito._Automatico
                            .c_AutoDetalleCompra.c_Texto = xauto.ToString.Trim.PadLeft(10, "0")
                            .c_AutoGrupo.c_Texto = xdetalle._FichaProducto._AutoGrupo
                            .c_AutoMedida.c_Texto = xdetalle._FichaProducto._AutoEmpaqueCompra
                            .c_AutoProducto.c_Texto = xdetalle._FichaProducto._AutoProducto
                            .c_AutoProveedor.c_Texto = xgrabarcompra._Compra._Proveedor._Automatico
                            .c_AutoSubgrupo.c_Texto = xdetalle._FichaProducto._AutoSubGrupo
                            .c_Bono.c_Valor = xdetalle._CantidadPromo
                            .c_CantidadCompra.c_Valor = xdetalle._CantidadCompra
                            .c_CantidadCompraUnidadInventario.c_Valor = xdetalle._CantidadCompraInventario
                            .c_CantidadDecimales.c_Texto = xdetalle._FichaProducto._CantDecimalesEmpaqueCompra.ToString.Trim
                            .c_CategoriaProducto.c_Texto = xdetalle._FichaProducto._CategoriaDelProducto
                            .c_CodigoArancel.c_Texto = ""
                            .c_CodigoDeposito.c_Texto = xdetalle._FichaDeposito._Codigo
                            .c_CodigoProducto.c_Texto = xdetalle._FichaProducto._CodigoProducto
                            .c_CodigoProveedor.c_Texto = xdetalle._ProductoCodigoProveedor
                            .c_ContenidoEmpaque.c_Valor = xdetalle._FichaProducto._ContEmpqCompra
                            .c_Costo.c_Valor = xdetalle._CostoItem
                            .c_CostoBruto.c_Valor = xdetalle._CostoBruto
                            .c_CostoImportacion.c_Valor = 0
                            .c_Empaque.c_Texto = xdetalle._FichaProducto._NombreEmpaqueCompra
                            .c_EmpaqueTipo.c_Texto = "1"
                            .c_Estatus.c_Texto = "0"
                            .c_FechaEmision.c_Valor = xgrabarcompra._Compra.RegistroDato.c_FechaEmision.c_Valor
                            .c_ForzarMedida.c_Texto = IIf(xdetalle._FichaProducto._ForzarUsoDecimalesEmpaqueCompra = TipoSiNo.Si, "1", "0")
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
                                    xdetalle._ValorCostoActual = xcosfin
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
                                    xdetalle._ValorCostoReferencia = xcosfin
                                Else
                                    xdetalle._ValorCostoReferencia = xdetalle._ValorCostoActual
                                End If
                            Else
                                xdetalle._ValorCostoReferencia = xdetalle._ValorCostoActual
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

                                'ACTUALIZA CONTADOR NUMERO DE ORDEN DE COMPRA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                xgrabarcompra._Compra.RegistroDato.c_NumeroDocumentoCompra.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

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

                                'TABLA TEMPORALCOMPRA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete temporal_compra where idunico=@idunico and tipodocumento='4' and autousuario=@autousuario"
                                xcmd.Parameters.AddWithValue("@idunico", xgrabarcompra._IdUnico)
                                xcmd.Parameters.AddWithValue("@autousuario", xgrabarcompra._Compra.RegistroDato._AutoUsuario)
                                xcmd.ExecuteNonQuery()

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
                    Throw New Exception("ORDEN DE COMPRA" + vbCrLf + "ERROR AL GRABAR ORDEN DE COMPRA:" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Permite Procesar Una Nota Credito
            ''' </summary>
            ''' <param name="xgrabar"></param>
            ''' CLASE QUE PERMITE PROCESAR LA NOTA DE CREDITO
            Function F_GrabarNC(ByVal xgrabar As GrabarNC)
                Dim xsql_1 As String = "update contadores set a_compras=a_compras+1; select a_compras from contadores"
                Dim xsql_2 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"

                Dim autocxp As String = ""

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

                    xn = xgrabar._Compra_NC.RegistroDato.c_MontoSubtotal.c_Valor
                    xb1 = xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor
                    xb2 = xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor
                    xb3 = xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor
                    xexento = xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor

                    Dim ximp1 As Decimal = 0
                    Dim ximp2 As Decimal = 0
                    Dim ximp3 As Decimal = 0

                    ximp1 = Decimal.Round(xb1 * xgrabar._Compra_NC.RegistroDato.c_Tasa1.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp2 = Decimal.Round(xb2 * xgrabar._Compra_NC.RegistroDato.c_Tasa2.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp3 = Decimal.Round(xb3 * xgrabar._Compra_NC.RegistroDato.c_Tasa3.c_Valor / 100, 2, MidpointRounding.AwayFromZero)

                    xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor = xb1
                    xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor = xb2
                    xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor = xb3
                    xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor = Decimal.Round(xb1 + xb2 + xb3, 2, MidpointRounding.AwayFromZero)
                    xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor = xexento
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto1.c_Valor = ximp1
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto2.c_Valor = ximp2
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto3.c_Valor = ximp3
                    xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor = Decimal.Round(ximp1 + ximp2 + ximp3, 2, MidpointRounding.AwayFromZero)
                    xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor = xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor + _
                                                               xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor + xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor

                    With xgrabar._Compra_NC.RegistroDato
                        .c_FechaVencimiento.c_Valor = ._FechaCarga
                        .c_MesRelacion.c_Texto = .fn_MesRelacion
                        .c_TipoColumna.c_Texto = "1"
                        .c_EstatusCompra.c_Texto = "0"
                        .c_AnoRelacion.c_Texto = .fn_AnoRelacion
                        .c_Periodo.c_Valor = .fn_RetornarPeriodo
                        .c_DocumentoAplica.c_Texto = xgrabar._FichaCompraOrigen._NumeroDocumentoCompra
                        .c_SerieDocumentoAplica.c_Texto = xgrabar._FichaCompraOrigen._SerieDocumento
                        .c_TipoCompraRegistrada.c_Texto = xgrabar._TipoNCRegistrada
                        .c_AutoUsuario.c_Texto = xgrabar._Compra_NC._Usuario._AutoUsuario
                        .c_CodigoUsuario.c_Texto = xgrabar._Compra_NC._Usuario._CodigoUsuario
                        .c_NombreUsuario.c_Texto = xgrabar._Compra_NC._Usuario._NombreUsuario
                        .c_ConceptoGasto.c_Texto = xgrabar._FichaCompraOrigen._ConceptoGasto
                    End With

                    Dim xtipoNotaCredito_por_devolucion As Boolean = False
                    If xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor = xgrabar._FichaCompraOrigen.c_TotalGeneral.c_Valor Then
                        xtipoNotaCredito_por_devolucion = True
                    End If

                    Dim xauto As Integer = 0
                    For Each xdetalle In xgrabar._CompraDetalle_NC
                        xauto += 1

                        With xdetalle
                            .RegistroDato.c_Periodo.c_Valor = xgrabar._Compra_NC.RegistroDato._Periodo
                            .RegistroDato.c_AutoDetalleCompra.c_Texto = xauto.ToString.Trim.PadLeft(10, "0")
                            .RegistroDato.c_AutoProveedor.c_Texto = ._ItemDetalleOrigen.c_AutoProveedor.c_Texto
                            .RegistroDato.c_AutoDepartamento.c_Texto = ._ItemDetalleOrigen.c_AutoDepartamento.c_Texto
                            .RegistroDato.c_AutoDeposito.c_Texto = ._ItemDetalleOrigen.c_AutoDeposito.c_Texto
                            .RegistroDato.c_AutoGrupo.c_Texto = ._ItemDetalleOrigen.c_AutoGrupo.c_Texto
                            .RegistroDato.c_AutoMedida.c_Texto = ._ItemDetalleOrigen.c_AutoMedida.c_Texto
                            .RegistroDato.c_AutoProducto.c_Texto = ._ItemDetalleOrigen.c_AutoProducto.c_Texto
                            .RegistroDato.c_AutoSubgrupo.c_Texto = ._ItemDetalleOrigen.c_AutoSubgrupo.c_Texto

                            .RegistroDato.c_CategoriaProducto.c_Texto = ._ItemDetalleOrigen.c_CategoriaProducto.c_Texto
                            .RegistroDato.c_CodigoDeposito.c_Texto = ._ItemDetalleOrigen.c_CodigoDeposito.c_Texto
                            .RegistroDato.c_CodigoProducto.c_Texto = ._ItemDetalleOrigen.c_CodigoProducto.c_Texto
                            .RegistroDato.c_ContenidoEmpaque.c_Valor = ._ItemDetalleOrigen.c_ContenidoEmpaque.c_Valor

                            .RegistroDato.c_Estatus.c_Texto = ._ItemDetalleOrigen.c_Estatus.c_Texto

                            .RegistroDato.c_FechaEmision.c_Valor = xgrabar._Compra_NC.RegistroDato._FechaEmision
                            .RegistroDato.c_ForzarMedida.c_Texto = ._ItemDetalleOrigen.c_ForzarMedida.c_Texto

                            .RegistroDato.c_NombreDeposito.c_Texto = ._ItemDetalleOrigen.c_NombreDeposito.c_Texto
                            .RegistroDato.c_Empaque.c_Texto = ._ItemDetalleOrigen.c_Empaque.c_Texto
                            .RegistroDato.c_NombreProducto.c_Texto = ._ItemDetalleOrigen.c_NombreProducto.c_Texto
                            .RegistroDato.c_CantidadDecimales.c_Texto = ._ItemDetalleOrigen.c_CantidadDecimales.c_Texto

                            .RegistroDato.c_PTO_EsPesado.c_Texto = ._ItemDetalleOrigen.c_PTO_EsPesado.c_Texto

                            .RegistroDato.c_EmpaqueTipo.c_Texto = ._ItemDetalleOrigen.c_EmpaqueTipo.c_Texto
                            .RegistroDato.c_Signo.c_Valor = -1
                            .RegistroDato.c_TasaIva.c_Valor = ._ItemDetalleOrigen.c_TasaIva.c_Valor
                            .RegistroDato.c_TipoDocumento.c_Texto = "03"
                            .RegistroDato.c_TipoTasa.c_Texto = ._ItemDetalleOrigen.c_TipoTasa.c_Texto
                            .RegistroDato.c_CodigoProveedor.c_Texto = ._ItemDetalleOrigen.c_CodigoProveedor.c_Texto.Trim

                            .RegistroDato.c_Periodo.c_Valor = xgrabar._Compra_NC.RegistroDato._Periodo
                            .RegistroDato.c_PrecioSugeridoVenta.c_Valor = 0

                            If .RegistroDato._TipoMovimientoEfectuado = TipoMovimientoCompraDetalle.Devolucion Then
                                .RegistroDato.c_TipoMovimiento.c_Texto = "D"

                                Dim x0 As Decimal = 0
                                x0 = .RegistroDato._TotalNeto

                                .RegistroDato.c_TasaDescuento1.c_Valor = 0
                                .RegistroDato.c_TasaDescuento2.c_Valor = 0
                                .RegistroDato.c_TasaDescuento3.c_Valor = 0
                                .RegistroDato.c_MontoDescuento1.c_Valor = 0
                                .RegistroDato.c_MontoDescuento2.c_Valor = 0
                                .RegistroDato.c_MontoDescuento3.c_Valor = 0


                                Dim x1 As Decimal = 0
                                x1 = Decimal.Round(x0 / .RegistroDato._CantidadCompra, 2, MidpointRounding.AwayFromZero)
                                .RegistroDato.c_Costo.c_Valor = x1

                                Dim x2 As Decimal = 0
                                x2 = Decimal.Round(x0 * .RegistroDato.c_TasaIva.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                                .RegistroDato.c_MontoImpuesto.c_Valor = x2
                                .RegistroDato.c_MontoTotal.c_Valor = Decimal.Round(x0 + x2, 2, MidpointRounding.AwayFromZero)

                                Dim x3 As Decimal = 0
                                x3 = .RegistroDato.c_CantidadCompra.c_Valor * .RegistroDato.c_ContenidoEmpaque.c_Valor
                                .RegistroDato.c_CantidadCompraUnidadInventario.c_Valor = x3

                                .RegistroDato.c_CostoFinal.c_Valor = x1
                                .RegistroDato.c_CostoInventario.c_Valor = Decimal.Round(x1 / .RegistroDato.c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)

                            Else 'AJUSTE
                                If .RegistroDato._TipoMovimientoEfectuado = TipoMovimientoCompraDetalle.Ajuste Then
                                    .RegistroDato.c_TipoMovimiento.c_Texto = "A"

                                    Dim t1 As Decimal = Decimal.Round(xdetalle._ItemDetalleOrigen._Costo, 2, MidpointRounding.AwayFromZero)
                                    Dim t2 As Decimal = Decimal.Round(t1 * (xdetalle._ItemDetalleOrigen.c_CantidadCompra.c_Valor - xdetalle.RegistroDato._CantidadCompra), 2, MidpointRounding.AwayFromZero)
                                    Dim t3 As Decimal = Decimal.Round(.RegistroDato._TotalNeto, 2, MidpointRounding.AwayFromZero)
                                    Dim t4 As Decimal = Decimal.Round(._ItemDetalleOrigen._TotalNeto, 2, MidpointRounding.AwayFromZero)

                                    Dim x0 As Decimal = Decimal.Round(t4 - (t2 + t3), 2, MidpointRounding.AwayFromZero)

                                    .RegistroDato.c_CostoBruto.c_Valor = Decimal.Round(x0 / .RegistroDato._CantidadCompra, 2, MidpointRounding.AwayFromZero)

                                    .RegistroDato.c_TasaDescuento1.c_Valor = 0
                                    .RegistroDato.c_TasaDescuento2.c_Valor = 0
                                    .RegistroDato.c_TasaDescuento3.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento1.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento2.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento3.c_Valor = 0

                                    .RegistroDato.c_TotalNeto.c_Valor = x0

                                    Dim x1 As Decimal = 0
                                    x1 = Decimal.Round(x0 / .RegistroDato._CantidadCompra, 2, MidpointRounding.AwayFromZero)
                                    .RegistroDato.c_Costo.c_Valor = x1

                                    Dim x2 As Decimal = 0
                                    x2 = Decimal.Round(x0 * .RegistroDato.c_TasaIva.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                                    .RegistroDato.c_MontoImpuesto.c_Valor = x2
                                    .RegistroDato.c_MontoTotal.c_Valor = Decimal.Round(x0 + x2, 2, MidpointRounding.AwayFromZero)

                                    Dim x3 As Decimal = 0
                                    x3 = .RegistroDato.c_CantidadCompra.c_Valor * .RegistroDato.c_ContenidoEmpaque.c_Valor
                                    .RegistroDato.c_CantidadCompraUnidadInventario.c_Valor = x3

                                    .RegistroDato.c_CostoFinal.c_Valor = x1
                                    .RegistroDato.c_CostoInventario.c_Valor = Decimal.Round(x1 / .RegistroDato.c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)
                                Else 'AJUSTE GLOBAL
                                    .RegistroDato.c_TipoMovimiento.c_Texto = "A"
                                    Dim x0 As Decimal = .RegistroDato._TotalNeto
                                    .RegistroDato.c_CostoBruto.c_Valor = Decimal.Round(x0 / .RegistroDato._CantidadCompra, 2, MidpointRounding.AwayFromZero)

                                    .RegistroDato.c_TasaDescuento1.c_Valor = 0
                                    .RegistroDato.c_TasaDescuento2.c_Valor = 0
                                    .RegistroDato.c_TasaDescuento3.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento1.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento2.c_Valor = 0
                                    .RegistroDato.c_MontoDescuento3.c_Valor = 0

                                    Dim x1 As Decimal = 0
                                    x1 = Decimal.Round(x0 / .RegistroDato._CantidadCompra, 2, MidpointRounding.AwayFromZero)
                                    .RegistroDato.c_Costo.c_Valor = x1

                                    Dim x2 As Decimal = 0
                                    x2 = Decimal.Round(x0 * .RegistroDato.c_TasaIva.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                                    .RegistroDato.c_MontoImpuesto.c_Valor = x2
                                    .RegistroDato.c_MontoTotal.c_Valor = Decimal.Round(x0 + x2, 2, MidpointRounding.AwayFromZero)

                                    Dim x3 As Decimal = 0
                                    x3 = .RegistroDato.c_CantidadCompra.c_Valor * .RegistroDato.c_ContenidoEmpaque.c_Valor
                                    .RegistroDato.c_CantidadCompraUnidadInventario.c_Valor = x3

                                    .RegistroDato.c_CostoFinal.c_Valor = x1
                                    .RegistroDato.c_CostoInventario.c_Valor = Decimal.Round(x1 / .RegistroDato.c_ContenidoEmpaque.c_Valor, 2, MidpointRounding.AwayFromZero)
                                End If
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
                                xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'ACTUALIZA CONTADOR AUTOMATICO CXC
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                autocxp = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_COMPRAS
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xgrabar._Compra_NC.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xgrabar._Compra_NC.RegistroDato.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xgrabar._Compra_NC._Proveedor._NombreRazonSocial).Size = xgrabar._Compra_NC.RegistroDato.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_fiscal", xgrabar._Compra_NC._Proveedor._DirFiscal).Size = xgrabar._Compra_NC.RegistroDato.c_DirFiscalProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xgrabar._Compra_NC._Proveedor._CiRif).Size = xgrabar._Compra_NC.RegistroDato.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo", xgrabar._Compra_NC.RegistroDato.c_TipoDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@exento", xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor)
                                xcmd.Parameters.AddWithValue("@base1", xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor)
                                xcmd.Parameters.AddWithValue("@base2", xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor)
                                xcmd.Parameters.AddWithValue("@base3", xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto1", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto1.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto2", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto2.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto3", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto3.c_Valor)
                                xcmd.Parameters.AddWithValue("@base", xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto", xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor)
                                xcmd.Parameters.AddWithValue("@total", xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa1", xgrabar._Compra_NC.RegistroDato.c_Tasa1.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa2", xgrabar._Compra_NC.RegistroDato.c_Tasa2.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa3", xgrabar._Compra_NC.RegistroDato.c_Tasa3.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xgrabar._Compra_NC.RegistroDato.c_NotasDetalleCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NotasDetalleCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xgrabar._Compra_NC.RegistroDato.c_TasaRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xgrabar._Compra_NC.RegistroDato.c_TasaRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_iva", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_islr", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico).Size = xgrabar._Compra_NC.RegistroDato.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_entidad", xgrabar._Compra_NC._Proveedor._CodigoProveedor).Size = xgrabar._Compra_NC.RegistroDato.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@mes_relacion", xgrabar._Compra_NC.RegistroDato.c_MesRelacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_MesRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@genero", xgrabar._Compra_NC.RegistroDato.c_Genero.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_Genero.c_Largo
                                xcmd.Parameters.AddWithValue("@control", xgrabar._Compra_NC.RegistroDato.c_NumeroControlDocumento.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroControlDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_carga", xgrabar._Compra_NC.RegistroDato.c_FechaCarga.c_Valor)
                                xcmd.Parameters.AddWithValue("@orden_compra", xgrabar._Compra_NC.RegistroDato.c_NumeroOrdenCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroOrdenCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@dias", xgrabar._Compra_NC.RegistroDato.c_DiasCredito.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1", xgrabar._Compra_NC.RegistroDato.c_MontoDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2", xgrabar._Compra_NC.RegistroDato.c_MontoDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos", xgrabar._Compra_NC.RegistroDato.c_MontoCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@columna", xgrabar._Compra_NC.RegistroDato.c_TipoColumna.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoColumna.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xgrabar._Compra_NC.RegistroDato.c_EstatusCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_EstatusCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@flete", xgrabar._Compra_NC.RegistroDato.c_MontoFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@fletep", xgrabar._Compra_NC.RegistroDato.c_TasaFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@seguro", xgrabar._Compra_NC.RegistroDato.c_MontoSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@segurop", xgrabar._Compra_NC.RegistroDato.c_TasaSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancel", xgrabar._Compra_NC.RegistroDato.c_MontoArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancelp", xgrabar._Compra_NC.RegistroDato.c_TasaArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@servicio", xgrabar._Compra_NC.RegistroDato.c_MontoServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@serviciop", xgrabar._Compra_NC.RegistroDato.c_TasaServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduana", xgrabar._Compra_NC.RegistroDato.c_MontoAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduanap", xgrabar._Compra_NC.RegistroDato.c_TasaAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@agente", xgrabar._Compra_NC.RegistroDato.c_MontoAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@agentep", xgrabar._Compra_NC.RegistroDato.c_TasaAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastos", xgrabar._Compra_NC.RegistroDato.c_MontoGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastosp", xgrabar._Compra_NC.RegistroDato.c_TasaGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otros", xgrabar._Compra_NC.RegistroDato.c_MontoOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otrosp", xgrabar._Compra_NC.RegistroDato.c_TasaOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@expediente", xgrabar._Compra_NC.RegistroDato.c_ExpedienteCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ExpedienteCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion", xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIva.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIva.c_Largo
                                xcmd.Parameters.AddWithValue("@subtotal", xgrabar._Compra_NC.RegistroDato.c_MontoSubtotal.c_Valor)
                                xcmd.Parameters.AddWithValue("@telefono", xgrabar._Compra_NC._Proveedor._Telefono_1).Size = xgrabar._Compra_NC.RegistroDato.c_TelefonoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@factor_cambio", xgrabar._Compra_NC.RegistroDato.c_FactorCambio.c_Valor)
                                xcmd.Parameters.AddWithValue("@planilla_importacion", xgrabar._Compra_NC.RegistroDato.c_PlanillaImportacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_PlanillaImportacion.c_Largo
                                xcmd.Parameters.AddWithValue("@retencion_iva_terceros", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIvaTerceros.c_Valor)
                                xcmd.Parameters.AddWithValue("@anticipo_iva_importacion", xgrabar._Compra_NC.RegistroDato.c_MontoAnticipoIvaImportacion.c_Valor)
                                xcmd.Parameters.AddWithValue("@ano_relacion", xgrabar._Compra_NC.RegistroDato.c_AnoRelacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AnoRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIslr.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIslr.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumento.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_SerieDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serieaplica", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@n_auto_usuario", xgrabar._Compra_NC.RegistroDato.c_AutoUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AutoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_codigo_usuario", xgrabar._Compra_NC.RegistroDato.c_CodigoUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_usuario", xgrabar._Compra_NC.RegistroDato.c_NombreUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_estacion", xgrabar._Compra_NC.RegistroDato.c_NombreEstacionEquipo.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NombreEstacionEquipo.c_Largo
                                xcmd.Parameters.AddWithValue("@n_hora", xgrabar._Compra_NC.RegistroDato.c_Hora.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_Hora.c_Largo
                                xcmd.Parameters.AddWithValue("@n_periodo", xgrabar._Compra_NC.RegistroDato.c_Periodo.c_Valor)
                                xcmd.Parameters.AddWithValue("@renglones", xgrabar._Compra_NC.RegistroDato.c_CantidadRenglones.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_tipo_compra", xgrabar._Compra_NC.RegistroDato.c_TipoCompraRegistrada.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoCompraRegistrada.c_Largo
                                xcmd.Parameters.AddWithValue("@n_montoimplicor", xgrabar._Compra_NC.RegistroDato.c_MontoImpuestoLicor.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_concepto_gasto", xgrabar._Compra_NC.RegistroDato.c_ConceptoGasto.c_Texto)
                                xcmd.ExecuteNonQuery()

                                Dim xcxp As New FichaCtasPagar.c_CxP.c_Registro
                                With xcxp
                                    .c_AutoProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._Automatico
                                    .c_AutoCxP.c_Texto = autocxp
                                    .c_AutoDocumento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                    .c_CiRifProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaEmision.c_Valor
                                    .c_FechaVencimiento.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaVencimiento.c_Valor
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor * -1
                                    .c_MontoPorPagar.c_Valor = xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor * -1
                                    .c_NombreProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._NombreRazonSocial
                                    .c_NotaDetalle.c_Texto = "DOCUMENTO DE NOTA DE CRÉDITO"
                                    .c_NumeroDocumento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Texto
                                    .c_TipoDocumento.c_Texto = "NCF"
                                    .c_TipoOperacion.c_Texto = ""
                                    .c_Signo.c_Valor = -1
                                    .c_FechaProceso.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaCarga.c_Valor

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
                                xcmd.CommandText = "select auto from productos_conceptos where codigo='DEV_COMPRA'"
                                auto_concepto = xcmd.ExecuteScalar()
                                If (auto_concepto Is Nothing) Or IsDBNull(auto_concepto) Then
                                    Throw New Exception("CONCEPTO 'DEV_COMPRA' NO ESTA DEFINIDO EN LA TABLA CONCEPTOS DE MOVIMIENTO DEL INVENTARIO")
                                End If

                                Dim xconcepto As String = ""
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select nombre from productos_conceptos where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", auto_concepto)
                                xconcepto = xcmd.ExecuteScalar

                                'COMPRAS_DETALLE
                                For Each xdetalle In xgrabar._CompraDetalle_NC
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_COMPRAS_DETALLE

                                    With xdetalle
                                        .RegistroDato.c_AutoDocumentoCompra.c_Texto = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                    End With

                                    xcmd.Parameters.AddWithValue("@auto_documento", xdetalle.RegistroDato.c_AutoDocumentoCompra.c_Texto).Size = xdetalle.RegistroDato.c_AutoDocumentoCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_productos", xdetalle.RegistroDato.c_AutoProducto.c_Texto).Size = xdetalle.RegistroDato.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xdetalle.RegistroDato.c_CodigoProducto.c_Texto).Size = xdetalle.RegistroDato.c_CodigoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xdetalle.RegistroDato.c_NombreProducto.c_Texto).Size = xdetalle.RegistroDato.c_NombreProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_departamento", xdetalle.RegistroDato.c_AutoDepartamento.c_Texto).Size = xdetalle.RegistroDato.c_AutoDepartamento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xdetalle.RegistroDato.c_AutoGrupo.c_Texto).Size = xdetalle.RegistroDato.c_AutoGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_subgrupo", xdetalle.RegistroDato.c_AutoSubgrupo.c_Texto).Size = xdetalle.RegistroDato.c_AutoSubgrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdetalle.RegistroDato.c_AutoDeposito.c_Texto).Size = xdetalle.RegistroDato.c_AutoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad", xdetalle.RegistroDato.c_CantidadCompra.c_Valor)
                                    xcmd.Parameters.AddWithValue("@bono", xdetalle.RegistroDato.c_Bono.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xdetalle.RegistroDato.c_Empaque.c_Texto).Size = xdetalle.RegistroDato.c_Empaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@costo_bruto", xdetalle.RegistroDato.c_CostoBruto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_final", xdetalle.RegistroDato.c_CostoFinal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1p", xdetalle.RegistroDato.c_TasaDescuento1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2p", xdetalle.RegistroDato.c_TasaDescuento2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento3p", xdetalle.RegistroDato.c_TasaDescuento3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento1", xdetalle.RegistroDato.c_MontoDescuento1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento2", xdetalle.RegistroDato.c_MontoDescuento2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuento3", xdetalle.RegistroDato.c_MontoDescuento3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo", xdetalle.RegistroDato.c_Costo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total_neto", xdetalle.RegistroDato.c_TotalNeto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa", xdetalle.RegistroDato.c_TasaIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto", xdetalle.RegistroDato.c_MontoImpuesto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total", xdetalle.RegistroDato.c_MontoTotal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle.RegistroDato.c_AutoDetalleCompra.c_Texto).Size = xdetalle.RegistroDato.c_AutoDetalleCompra.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_arancel", xdetalle.RegistroDato.c_CodigoArancel.c_Texto).Size = xdetalle.RegistroDato.c_CodigoArancel.c_Largo
                                    xcmd.Parameters.AddWithValue("@arancel", xdetalle.RegistroDato.c_MontoArancel.c_Valor)
                                    xcmd.Parameters.AddWithValue("@arancelp", xdetalle.RegistroDato.c_TasaArancel.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_servicio", xdetalle.RegistroDato.c_TasaServicio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_serviciop", xdetalle.RegistroDato.c_MontoServicio.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_aduana", xdetalle.RegistroDato.c_TasaAduana.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_aduanap", xdetalle.RegistroDato.c_MontoAduana.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_tasa", xdetalle.RegistroDato.c_TipoTasa.c_Texto).Size = xdetalle.RegistroDato.c_TipoTasa.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xdetalle.RegistroDato.c_Estatus.c_Texto).Size = xdetalle.RegistroDato.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xdetalle.RegistroDato.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo", xdetalle.RegistroDato.c_TipoDocumento.c_Texto).Size = xdetalle.RegistroDato.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@deposito", xdetalle.RegistroDato.c_NombreDeposito.c_Texto).Size = xdetalle.RegistroDato.c_NombreDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xdetalle.RegistroDato.c_Signo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xdetalle.RegistroDato.c_AutoProveedor.c_Texto).Size = xdetalle.RegistroDato.c_AutoProveedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@decimales", xdetalle.RegistroDato.c_CantidadDecimales.c_Texto).Size = xdetalle.RegistroDato.c_CantidadDecimales.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xdetalle.RegistroDato.c_ContenidoEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xdetalle.RegistroDato.c_CantidadCompraUnidadInventario.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_inventario", xdetalle.RegistroDato.c_CostoInventario.c_Valor)
                                    xcmd.Parameters.AddWithValue("@flete", xdetalle.RegistroDato.c_MontoFlete.c_Valor)
                                    xcmd.Parameters.AddWithValue("@seguro", xdetalle.RegistroDato.c_MontoSeguro.c_Valor)
                                    xcmd.Parameters.AddWithValue("@otros", xdetalle.RegistroDato.c_MontoOtrosGastos.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_importacion", xdetalle.RegistroDato.c_CostoImportacion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@valor_fob", xdetalle.RegistroDato.c_ValorFob.c_Valor)
                                    xcmd.Parameters.AddWithValue("@valor_cif", xdetalle.RegistroDato.c_ValorCif.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_deposito", xdetalle.RegistroDato.c_CodigoDeposito.c_Texto).Size = xdetalle.RegistroDato.c_CodigoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@empaque_tipo", xdetalle.RegistroDato.c_EmpaqueTipo.c_Texto).Size = xdetalle.RegistroDato.c_EmpaqueTipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@detalle", xdetalle.RegistroDato.c_NotasItem.c_Texto).Size = xdetalle.RegistroDato.c_NotasItem.c_Largo
                                    xcmd.Parameters.AddWithValue("@categoria", xdetalle.RegistroDato.c_CategoriaProducto.c_Texto).Size = xdetalle.RegistroDato.c_CategoriaProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_proveedor", xdetalle.RegistroDato.c_CodigoProveedor.c_Texto).Size = xdetalle.RegistroDato.c_CodigoProveedor.c_Largo
                                    'CAMPOS NUEVOS
                                    xcmd.Parameters.AddWithValue("@N_espesado", xdetalle.RegistroDato.c_PTO_EsPesado.c_Texto).Size = xdetalle.RegistroDato.c_PTO_EsPesado.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_automedida", xdetalle.RegistroDato.c_AutoMedida.c_Texto).Size = xdetalle.RegistroDato.c_AutoMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_forzarmedida", xdetalle.RegistroDato.c_ForzarMedida.c_Texto).Size = xdetalle.RegistroDato.c_ForzarMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_TipoMovimiento", xdetalle.RegistroDato.c_TipoMovimiento.c_Texto).Size = xdetalle.RegistroDato.c_TipoMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@N_periodo", xdetalle.RegistroDato.c_Periodo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@n_montoimplicor", xdetalle.RegistroDato.c_MontoImpuestoLicor.c_Valor)
                                    xcmd.Parameters.AddWithValue("@n_psugerido", xdetalle.RegistroDato.c_PrecioSugeridoVenta.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    If xdetalle.RegistroDato._TipoMovimientoEfectuado = TipoMovimientoCompraDetalle.Devolucion Then
                                        Dim xvalor As Object = Nothing
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "SELECT SUM(CANTIDAD) FROM COMPRAS_DETALLE WHERE auto_productos=@auto_producto AND N_TipoMovimiento='D' " & _
                                          "AND AUTO_DOCUMENTO IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0') "
                                        xcmd.Parameters.AddWithValue("@auto_producto", xdetalle.RegistroDato.c_AutoProducto.c_Texto)
                                        xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto)
                                        xcmd.Parameters.AddWithValue("@serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto)
                                        xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico)
                                        xvalor = xcmd.ExecuteScalar()
                                        If IsDBNull(xvalor) Or xvalor Is Nothing Then
                                        Else
                                            If (xvalor) > xdetalle._ItemDetalleOrigen._CantidadCompra Then
                                                Throw New Exception("PRODUCTO HA EFECTUAR DEVOLUCION:" & vbCrLf & xdetalle.RegistroDato.c_NombreProducto.c_Texto & _
                                                                    vbCrLf & "LA CANTIDAD A DEVOLVER SUPERA LA CANTIDAD FACTURADA" & vbCrLf & _
                                                                    "VERIFICA SI HAY UNA NOTA DE CREDITO YA REALIZADA A ESTE PRODUCTO")
                                            End If
                                        End If

                                        Dim xr As Object = Nothing
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = UPDATE_PRODUCTOS_DEPOSITO
                                        xcmd.Parameters.AddWithValue("@auto_producto", xdetalle.RegistroDato.c_AutoProducto.c_Texto).Size = xdetalle.RegistroDato.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xdetalle.RegistroDato.c_AutoDeposito.c_Texto).Size = xdetalle.RegistroDato.c_AutoDeposito.c_Largo
                                        xcmd.Parameters.AddWithValue("@cantidad_inventario", xdetalle.RegistroDato.c_CantidadCompraUnidadInventario.c_Valor * xdetalle.RegistroDato.c_Signo.c_Valor)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Or xr Is Nothing Then
                                            Throw New Exception("ERROR EL PRODUCTO (" + xdetalle.RegistroDato.c_NombreProducto.c_Texto.Trim + ") NO TIENE ASIGNADO EL DEPOSITO (" _
                                                                + xdetalle.RegistroDato.c_NombreDeposito.c_Texto.Trim + "), VERIFIQUE")
                                        End If

                                        'PRODUCTOS_KARDEX
                                        Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                                        With xkardex
                                            .c_AutoConcepto.c_Texto = auto_concepto
                                            .c_AutoDeposito.c_Texto = xdetalle.RegistroDato.c_AutoDeposito.c_Texto
                                            .c_AutoDocumento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                            .c_AutoProducto.c_Texto = xdetalle.RegistroDato.c_AutoProducto.c_Texto
                                            .c_CantidadMover.c_Valor = xdetalle.RegistroDato.c_CantidadCompra.c_Valor
                                            .c_CantidadUnidadesMover.c_Valor = xdetalle.RegistroDato.c_CantidadCompraUnidadInventario.c_Valor
                                            .c_Documento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Texto
                                            .c_Entidad.c_Texto = xgrabar._Compra_NC._Proveedor._NombreRazonSocial
                                            .c_Estatus.c_Texto = xgrabar._Compra_NC.RegistroDato.c_EstatusCompra.c_Texto
                                            .c_FechaEmision.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaCarga.c_Valor
                                            .c_NotasDetallesMovimiento.c_Texto = xdetalle.RegistroDato._NotasItem
                                            .c_OrigenMovimiento.c_Texto = "0703"
                                            .c_ReferenciaEmpaque.c_Texto = xdetalle.RegistroDato.c_EmpaqueTipo.c_Texto
                                            .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Salida
                                            'Campos Nuevos
                                            .c_NombreProducto.c_Texto = xdetalle.RegistroDato._NombreProducto
                                            .c_NombreDeposito.c_Texto = xdetalle.RegistroDato._NombreDeposito
                                            .c_NombreConcepto.c_Texto = xconcepto
                                            .c_NombreMedidaEmpaque.c_Texto = xdetalle.RegistroDato._Empaque
                                            .c_AutoMedida.c_Texto = xdetalle.RegistroDato._AutoMedida
                                            .c_ContenidoMedidaEmpaque.c_Valor = xdetalle.RegistroDato._ContenidoEmpaque
                                            .c_CodigoProducto.c_Texto = xdetalle.RegistroDato._CodigoProducto
                                            .c_CodigoDeposito.c_Texto = xdetalle.RegistroDato._CodigoDeposito
                                            .c_CodigoConcepto.c_Texto = "DEV_COMPRA"
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
                                    End If

                                    'VERIFICO SI EL MONTO DE LA NC ES SUPERIOR AL MONTO ORIGINAL DEL ITEM DE FACTURA
                                    Dim xmonto As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT SUM(TOTAL) FROM COMPRAS_DETALLE WHERE auto_productos=@auto_producto " & _
                                      "AND AUTO_DOCUMENTO IN (select AUTO from compras where aplica=@aplica AND n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0') "
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdetalle.RegistroDato.c_AutoProducto.c_Texto)
                                    xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto)
                                    xcmd.Parameters.AddWithValue("@serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto)
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico)
                                    xmonto = xcmd.ExecuteScalar()
                                    If IsDBNull(xmonto) Or xmonto Is Nothing Then
                                    Else
                                        If (xmonto) > xdetalle._ItemDetalleOrigen._MontoTotal Then
                                            Throw New Exception("PRODUCTO HA EFECTUAR DEVOLUCION:" & vbCrLf & xdetalle.RegistroDato.c_NombreProducto.c_Texto & _
                                                                vbCrLf & "EL MONTO A DEVOLVER SUPERA EL IMPORTE TOTAL FACTURADO" & vbCrLf & _
                                                                "VERIFICA SI HAY UNA NOTA DE CREDITO YA REALIZADA A ESTE PRODUCTO")
                                        End If
                                    End If
                                Next

                                'VERIFICO SI EL MONTO DE LA NC ES SUPERIOR AL MONTO ORIGINAL DEL DOCUMENTO DE FACTURA
                                Dim xval As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT SUM(total) FROM compras WHERE auto IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0')"
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico)
                                xval = xcmd.ExecuteScalar()
                                If IsDBNull(xval) Or xval Is Nothing Then
                                Else
                                    If xval > xgrabar._FichaCompraOrigen._TotalGeneral Then
                                        Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO SUPERA EL TOTAL DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                    End If
                                End If

                                Dim xobj As Object = Nothing
                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Compra_NC._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Compra_NC._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Compra_NC._Proveedor._Automatico)
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
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._Compra_NC._Proveedor._Automatico)
                                xcmd.ExecuteNonQuery()

                                'VERIFICO QUE EL DOCUMENTO NO HAYA SIDO ANULADO
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select estatus from compras where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._FichaCompraOrigen._AutoDocumentoCompra)
                                xobj = xcmd.ExecuteScalar
                                If xobj = "1" Then
                                    Throw New Exception("ERROR... EL DOCUMENTO HA SIDO ANULADO POR OTRO USUARIO, VERIFIQUE")
                                End If

                                xtr.Commit()
                            End Using
                            RaiseEvent FacturaExitosa(xgrabar._Compra_NC.RegistroDato._AutoDocumentoCompra)
                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO, VERIFIQUE")
                            Else
                                Throw New Exception(xsql.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("COMPRAS" + vbCrLf + "ERROR AL GRABAR NOTA DE CREDITO:" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' GRABAR COMPRA TIPO GASTO
            ''' </summary>
            ''' <param name="xgrabarcompra"></param>
            Function F_GrabarCompraGasto(ByVal xgrabarcompra As GrabarCompraGasto)
                Dim xsql_1 As String = "update contadores set a_compras=a_compras+1; select a_compras from contadores"
                Dim xsql_2 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim autocxp As String = ""
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
                        .c_TipoCompraRegistrada.c_Texto = xgrabarcompra._TipoCompra
                        .c_MontoImpuestoLicor.c_Valor = 0
                    End With

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
                                xcmd.Parameters.AddWithValue("@n_concepto_gasto", xgrabarcompra._ConceptoGasto)
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

                                xtr.Commit()
                            End Using

                            RaiseEvent FacturaExitosa(xgrabarcompra._Compra.RegistroDato._AutoDocumentoCompra)
                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 547 Then
                                Throw New Exception("ERROR... EL PROVEEDOR HA SIDO ELIMINADO POR OTRO USUARIO, VERIFIQUE")
                            ElseIf xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO DE DOCUMENTO Y SERIE, VERIFIQUE")
                            Else
                                Throw New Exception(xsql.Message + ", Error Numero: " + xsql.Number.ToString)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("COMPRAS" + vbCrLf + "ERROR AL GRABAR COMPRA / GASTO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarGasto_NC(ByVal xgrabar As GrabarGasto_NC)
                Dim xsql_1 As String = "update contadores set a_compras=a_compras+1; select a_compras from contadores"
                Dim xsql_2 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim autocxp As String = ""
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

                    xn = xgrabar._Compra_NC.RegistroDato.c_MontoSubtotal.c_Valor
                    xb1 = xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor
                    xb2 = xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor
                    xb3 = xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor
                    xexento = xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor

                    Dim ximp1 As Decimal = 0
                    Dim ximp2 As Decimal = 0
                    Dim ximp3 As Decimal = 0

                    ximp1 = Decimal.Round(xb1 * xgrabar._Compra_NC.RegistroDato.c_Tasa1.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp2 = Decimal.Round(xb2 * xgrabar._Compra_NC.RegistroDato.c_Tasa2.c_Valor / 100, 2, MidpointRounding.AwayFromZero)
                    ximp3 = Decimal.Round(xb3 * xgrabar._Compra_NC.RegistroDato.c_Tasa3.c_Valor / 100, 2, MidpointRounding.AwayFromZero)

                    xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor = xb1
                    xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor = xb2
                    xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor = xb3
                    xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor = Decimal.Round(xb1 + xb2 + xb3, 2, MidpointRounding.AwayFromZero)
                    xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor = xexento
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto1.c_Valor = ximp1
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto2.c_Valor = ximp2
                    xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto3.c_Valor = ximp3
                    xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor = Decimal.Round(ximp1 + ximp2 + ximp3, 2, MidpointRounding.AwayFromZero)
                    xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor = xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor + _
                                                               xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor + xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor

                    With xgrabar._Compra_NC.RegistroDato
                        .c_FechaVencimiento.c_Valor = ._FechaCarga
                        .c_MesRelacion.c_Texto = .fn_MesRelacion
                        .c_TipoColumna.c_Texto = "1"
                        .c_EstatusCompra.c_Texto = xgrabar._EstatusDocumento
                        .c_AnoRelacion.c_Texto = .fn_AnoRelacion
                        .c_DocumentoAplica.c_Texto = xgrabar._FichaCompraOrigen._NumeroDocumentoCompra
                        .c_SerieDocumentoAplica.c_Texto = xgrabar._FichaCompraOrigen._SerieDocumento
                        .c_AutoProveedor.c_Texto = xgrabar._FichaCompraOrigen._AutoProveedor
                        .c_NombreProveedor.c_Texto = xgrabar._FichaCompraOrigen._NombreProveedor
                        .c_CodigoProveedor.c_Texto = xgrabar._FichaCompraOrigen._CodigoProveedor
                        .c_CiRifProveedor.c_Texto = xgrabar._FichaCompraOrigen._CiRifProveedor
                        .c_DirFiscalProveedor.c_Texto = xgrabar._FichaCompraOrigen._DirFiscalProveedor
                        .c_TipoCompraRegistrada.c_Texto = xgrabar._TipoCompra
                        .c_MontoImpuestoLicor.c_Valor = 0
                        .c_AutoUsuario.c_Texto = xgrabar._Compra_NC._Usuario._AutoUsuario
                        .c_CodigoUsuario.c_Texto = xgrabar._Compra_NC._Usuario._CodigoUsuario
                        .c_NombreUsuario.c_Texto = xgrabar._Compra_NC._Usuario._NombreUsuario
                        .c_Periodo.c_Valor = .fn_RetornarPeriodo
                        .c_ConceptoGasto.c_Texto = xgrabar._FichaCompraOrigen._ConceptoGasto
                    End With

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
                                xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'ACTUALIZA CONTADOR AUTOMATICO CXP
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                autocxp = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_COMPRAS
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xgrabar._Compra_NC.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xgrabar._Compra_NC.RegistroDato.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xgrabar._Compra_NC._Proveedor._NombreRazonSocial).Size = xgrabar._Compra_NC.RegistroDato.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_fiscal", xgrabar._Compra_NC._Proveedor._DirFiscal).Size = xgrabar._Compra_NC.RegistroDato.c_DirFiscalProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xgrabar._Compra_NC._Proveedor._CiRif).Size = xgrabar._Compra_NC.RegistroDato.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo", xgrabar._Compra_NC.RegistroDato.c_TipoDocumentoCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoDocumentoCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@exento", xgrabar._Compra_NC.RegistroDato.c_MontoExento.c_Valor)
                                xcmd.Parameters.AddWithValue("@base1", xgrabar._Compra_NC.RegistroDato.c_MontoBase1.c_Valor)
                                xcmd.Parameters.AddWithValue("@base2", xgrabar._Compra_NC.RegistroDato.c_MontoBase2.c_Valor)
                                xcmd.Parameters.AddWithValue("@base3", xgrabar._Compra_NC.RegistroDato.c_MontoBase3.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto1", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto1.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto2", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto2.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto3", xgrabar._Compra_NC.RegistroDato.c_MontoImpuesto3.c_Valor)
                                xcmd.Parameters.AddWithValue("@base", xgrabar._Compra_NC.RegistroDato.c_MontoTotalBase.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto", xgrabar._Compra_NC.RegistroDato.c_MontoTotalImpuesto.c_Valor)
                                xcmd.Parameters.AddWithValue("@total", xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa1", xgrabar._Compra_NC.RegistroDato.c_Tasa1.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa2", xgrabar._Compra_NC.RegistroDato.c_Tasa2.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa3", xgrabar._Compra_NC.RegistroDato.c_Tasa3.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xgrabar._Compra_NC.RegistroDato.c_NotasDetalleCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NotasDetalleCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xgrabar._Compra_NC.RegistroDato.c_TasaRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xgrabar._Compra_NC.RegistroDato.c_TasaRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_iva", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_islr", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIslr.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico).Size = xgrabar._Compra_NC.RegistroDato.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_entidad", xgrabar._Compra_NC._Proveedor._CodigoProveedor).Size = xgrabar._Compra_NC.RegistroDato.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@mes_relacion", xgrabar._Compra_NC.RegistroDato.c_MesRelacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_MesRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@genero", xgrabar._Compra_NC.RegistroDato.c_Genero.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_Genero.c_Largo
                                xcmd.Parameters.AddWithValue("@control", xgrabar._Compra_NC.RegistroDato.c_NumeroControlDocumento.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroControlDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_carga", xgrabar._Compra_NC.RegistroDato.c_FechaCarga.c_Valor)
                                xcmd.Parameters.AddWithValue("@orden_compra", xgrabar._Compra_NC.RegistroDato.c_NumeroOrdenCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NumeroOrdenCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@dias", xgrabar._Compra_NC.RegistroDato.c_DiasCredito.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1", xgrabar._Compra_NC.RegistroDato.c_MontoDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2", xgrabar._Compra_NC.RegistroDato.c_MontoDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos", xgrabar._Compra_NC.RegistroDato.c_MontoCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaDescuento1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaDescuento2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos_porcentaje", xgrabar._Compra_NC.RegistroDato.c_TasaCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@columna", xgrabar._Compra_NC.RegistroDato.c_TipoColumna.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoColumna.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xgrabar._Compra_NC.RegistroDato.c_EstatusCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_EstatusCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@flete", xgrabar._Compra_NC.RegistroDato.c_MontoFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@fletep", xgrabar._Compra_NC.RegistroDato.c_TasaFlete.c_Valor)
                                xcmd.Parameters.AddWithValue("@seguro", xgrabar._Compra_NC.RegistroDato.c_MontoSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@segurop", xgrabar._Compra_NC.RegistroDato.c_TasaSeguro.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancel", xgrabar._Compra_NC.RegistroDato.c_MontoArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@arancelp", xgrabar._Compra_NC.RegistroDato.c_TasaArancel.c_Valor)
                                xcmd.Parameters.AddWithValue("@servicio", xgrabar._Compra_NC.RegistroDato.c_MontoServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@serviciop", xgrabar._Compra_NC.RegistroDato.c_TasaServicio.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduana", xgrabar._Compra_NC.RegistroDato.c_MontoAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@aduanap", xgrabar._Compra_NC.RegistroDato.c_TasaAduana.c_Valor)
                                xcmd.Parameters.AddWithValue("@agente", xgrabar._Compra_NC.RegistroDato.c_MontoAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@agentep", xgrabar._Compra_NC.RegistroDato.c_TasaAgente.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastos", xgrabar._Compra_NC.RegistroDato.c_MontoGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@gastosp", xgrabar._Compra_NC.RegistroDato.c_TasaGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otros", xgrabar._Compra_NC.RegistroDato.c_MontoOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@otrosp", xgrabar._Compra_NC.RegistroDato.c_TasaOtrosGastos.c_Valor)
                                xcmd.Parameters.AddWithValue("@expediente", xgrabar._Compra_NC.RegistroDato.c_ExpedienteCompra.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ExpedienteCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion", xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIva.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIva.c_Largo
                                xcmd.Parameters.AddWithValue("@subtotal", xgrabar._Compra_NC.RegistroDato.c_MontoSubtotal.c_Valor)
                                xcmd.Parameters.AddWithValue("@telefono", xgrabar._Compra_NC._Proveedor._Telefono_1).Size = xgrabar._Compra_NC.RegistroDato.c_TelefonoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@factor_cambio", xgrabar._Compra_NC.RegistroDato.c_FactorCambio.c_Valor)
                                xcmd.Parameters.AddWithValue("@planilla_importacion", xgrabar._Compra_NC.RegistroDato.c_PlanillaImportacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_PlanillaImportacion.c_Largo
                                xcmd.Parameters.AddWithValue("@retencion_iva_terceros", xgrabar._Compra_NC.RegistroDato.c_MontoRetencionIvaTerceros.c_Valor)
                                xcmd.Parameters.AddWithValue("@anticipo_iva_importacion", xgrabar._Compra_NC.RegistroDato.c_MontoAnticipoIvaImportacion.c_Valor)
                                xcmd.Parameters.AddWithValue("@ano_relacion", xgrabar._Compra_NC.RegistroDato.c_AnoRelacion.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AnoRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIslr.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_ComprobanteRetencionIslr.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumento.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_SerieDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@n_serieaplica", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@n_auto_usuario", xgrabar._Compra_NC.RegistroDato.c_AutoUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_AutoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_codigo_usuario", xgrabar._Compra_NC.RegistroDato.c_CodigoUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_usuario", xgrabar._Compra_NC.RegistroDato.c_NombreUsuario.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@n_estacion", xgrabar._Compra_NC.RegistroDato.c_NombreEstacionEquipo.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_NombreEstacionEquipo.c_Largo
                                xcmd.Parameters.AddWithValue("@n_hora", xgrabar._Compra_NC.RegistroDato.c_Hora.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_Hora.c_Largo
                                xcmd.Parameters.AddWithValue("@n_periodo", xgrabar._Compra_NC.RegistroDato.c_Periodo.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_tipo_compra", xgrabar._Compra_NC.RegistroDato.c_TipoCompraRegistrada.c_Texto).Size = xgrabar._Compra_NC.RegistroDato.c_TipoCompraRegistrada.c_Largo
                                xcmd.Parameters.AddWithValue("@renglones", xgrabar._Compra_NC.RegistroDato.c_CantidadRenglones.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_montoimplicor", xgrabar._Compra_NC.RegistroDato.c_MontoImpuestoLicor.c_Valor)
                                xcmd.Parameters.AddWithValue("@n_concepto_gasto", xgrabar._Compra_NC.RegistroDato.c_ConceptoGasto.c_Texto)
                                xcmd.ExecuteNonQuery()

                                Dim xcxc_doc_factura As New FichaCtasPagar.c_CxP.c_Registro
                                With xcxc_doc_factura
                                    .c_AutoProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._Automatico
                                    .c_AutoCxP.c_Texto = autocxp
                                    .c_AutoDocumento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_AutoDocumentoCompra.c_Texto
                                    .c_CiRifProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = xgrabar._EstatusCancelado
                                    .c_EstatusDocumento.c_Texto = xgrabar._EstatusDocumento
                                    .c_FechaEmision.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaEmision.c_Valor
                                    .c_FechaVencimiento.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaVencimiento.c_Valor
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor * -1
                                    .c_MontoPorPagar.c_Valor = xgrabar._Compra_NC.RegistroDato.c_TotalGeneral.c_Valor * -1
                                    .c_NombreProveedor.c_Texto = xgrabar._Compra_NC._Proveedor._NombreRazonSocial
                                    .c_NotaDetalle.c_Texto = "DOCUMENTO DE NOTA DE CRÉDITO"
                                    .c_NumeroDocumento.c_Texto = xgrabar._Compra_NC.RegistroDato.c_NumeroDocumentoCompra.c_Texto
                                    .c_TipoDocumento.c_Texto = "NCF"
                                    .c_TipoOperacion.c_Texto = ""
                                    .c_Signo.c_Valor = -1
                                    .c_FechaProceso.c_Valor = xgrabar._Compra_NC.RegistroDato.c_FechaCarga.c_Valor

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
                                xcmd.Parameters.AddWithValue("@auto", xcxc_doc_factura.c_AutoCxP.c_Texto).Size = xcxc_doc_factura.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xcxc_doc_factura.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_carga", xcxc_doc_factura.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xcxc_doc_factura.c_TipoDocumento.c_Texto).Size = xcxc_doc_factura.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xcxc_doc_factura.c_NumeroDocumento.c_Texto).Size = xcxc_doc_factura.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc_doc_factura.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xcxc_doc_factura.c_NotaDetalle.c_Texto).Size = xcxc_doc_factura.c_NotaDetalle.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xcxc_doc_factura.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xcxc_doc_factura.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcxc_doc_factura.c_AutoProveedor.c_Texto).Size = xcxc_doc_factura.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@proveedor", xcxc_doc_factura.c_NombreProveedor.c_Texto).Size = xcxc_doc_factura.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xcxc_doc_factura.c_CiRifProveedor.c_Texto).Size = xcxc_doc_factura.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xcxc_doc_factura.c_CodigoProveedor.c_Texto).Size = xcxc_doc_factura.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xcxc_doc_factura.c_EstatusCancelado.c_Texto).Size = xcxc_doc_factura.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xcxc_doc_factura.c_MontoPorPagar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xcxc_doc_factura.c_TipoOperacion.c_Texto).Size = xcxc_doc_factura.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xcxc_doc_factura.c_EstatusDocumento.c_Texto).Size = xcxc_doc_factura.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xcxc_doc_factura.c_AutoDocumento.c_Texto).Size = xcxc_doc_factura.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xcxc_doc_factura.c_Signo.c_Valor)
                                'nuevos
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc_doc_factura.c_AutoMovimientoEntrada.c_Texto).Size = xcxc_doc_factura.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.Add("@fecha_recepcion_devolucion", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null
                                xcmd.Parameters.AddWithValue("@numero", xcxc_doc_factura.c_Numero.c_Texto).Size = xcxc_doc_factura.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xcxc_doc_factura.c_AutoAgencia.c_Texto).Size = xcxc_doc_factura.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xcxc_doc_factura.c_NumeroCuenta.c_Texto).Size = xcxc_doc_factura.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xcxc_doc_factura.c_TipoCuenta.c_Texto).Size = xcxc_doc_factura.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xcxc_doc_factura.c_NombreTitular.c_Texto).Size = xcxc_doc_factura.c_NombreTitular.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xcxc_doc_factura.c_NombreAgencia.c_Texto).Size = xcxc_doc_factura.c_NombreAgencia.c_Largo
                                xcmd.ExecuteNonQuery()


                                Dim xval As Object = Nothing
                                'VERIFICO SI EL MONTO EXENTO DE LA NC ES SUPERIOR AL MONTO EXENTO ORIGINAL DEL DOCUMENTO DE FACTURA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT SUM(exento) FROM compras WHERE auto IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0')"
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico)
                                xval = xcmd.ExecuteScalar()
                                If IsDBNull(xval) Or xval Is Nothing Then
                                Else
                                    If xval > xgrabar._FichaCompraOrigen._MontoExento Then
                                        Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO EXENTO SUPERA EL TOTAL EXENTO DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                    End If
                                End If

                                'VERIFICO SI EL MONTO BASE1 DE LA NC ES SUPERIOR AL MONTO BASE1 ORIGINAL DEL DOCUMENTO DE FACTURA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT SUM(base1) FROM compras WHERE auto IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0')"
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._Compra_NC.RegistroDato.c_DocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@serie", xgrabar._Compra_NC.RegistroDato.c_SerieDocumentoAplica.c_Texto)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Compra_NC._Proveedor._Automatico)
                                xval = xcmd.ExecuteScalar()
                                If IsDBNull(xval) Or xval Is Nothing Then
                                Else
                                    If xval > xgrabar._FichaCompraOrigen._BaseImpuestoTasa1._Base Then
                                        Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO BASE 1 SUPERA EL TOTAL BASE 1 DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                    End If
                                End If

                                'VERIFICO SI EL MONTO BASE2 DE LA NC ES SUPERIOR AL MONTO BASE2 ORIGINAL DEL DOCUMENTO DE FACTURA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT SUM(base2) FROM compras WHERE auto IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0')"
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._FichaCompraOrigen._NumeroDocumentoCompra)
                                xcmd.Parameters.AddWithValue("@serie", xgrabar._FichaCompraOrigen._SerieDocumento)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._FichaCompraOrigen._AutoProveedor)
                                xval = xcmd.ExecuteScalar()
                                If IsDBNull(xval) Or xval Is Nothing Then
                                Else
                                    If xval > xgrabar._FichaCompraOrigen._BaseImpuestoTasa2._Base Then
                                        Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO BASE 2 SUPERA EL TOTAL BASE 2 DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                    End If
                                End If

                                'VERIFICO SI EL MONTO BASE3 DE LA NC ES SUPERIOR AL MONTO BASE3 ORIGINAL DEL DOCUMENTO DE FACTURA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT SUM(base3) FROM compras WHERE auto IN (select AUTO from compras where aplica=@aplica and n_serieaplica=@serie and auto_entidad=@auto_entidad AND estatus='0')"
                                xcmd.Parameters.AddWithValue("@aplica", xgrabar._FichaCompraOrigen._NumeroDocumentoCompra)
                                xcmd.Parameters.AddWithValue("@serie", xgrabar._FichaCompraOrigen._SerieDocumento)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._FichaCompraOrigen._AutoProveedor)
                                xval = xcmd.ExecuteScalar()
                                If IsDBNull(xval) Or xval Is Nothing Then
                                Else
                                    If xval > xgrabar._FichaCompraOrigen._BaseImpuestoTasa3._Base Then
                                        Throw New Exception("ERROR... AL PROCESAR NOTA DE CREDITO" & vbCrLf & "MONTO BASE 3 SUPERA EL TOTAL BASE 3 DEL DOCUMENTO ORIGEN AL QUE AFECTA")
                                    End If
                                End If

                                Dim xobj As Object = Nothing
                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._FichaCompraOrigen._AutoProveedor)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._FichaCompraOrigen._AutoProveedor)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._FichaCompraOrigen._AutoProveedor)
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
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._FichaCompraOrigen._AutoProveedor)
                                xcmd.ExecuteNonQuery()

                                'VERIFICO QUE EL DOCUMENTO NO HAYA SIDO ANULADO
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select estatus from compras where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._FichaCompraOrigen._AutoDocumentoCompra)
                                xobj = xcmd.ExecuteScalar
                                If xobj = "1" Then
                                    Throw New Exception("ERROR... EL DOCUMENTO HA SIDO ANULADO POR OTRO USUARIO, VERIFIQUE")
                                End If

                                xtr.Commit()
                            End Using
                            RaiseEvent FacturaExitosa(xgrabar._Compra_NC.RegistroDato._AutoDocumentoCompra)
                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO, VERIFIQUE")
                            Else
                                Throw New Exception(xsql.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("COMPRAS" + vbCrLf + "ERROR AL GRABAR NOTA DE CREDITO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Class DocRevertir
                Private xUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xEquipo As String
                Private xIdUnico As String

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xUsuario = value
                    End Set
                End Property

                Property _EquipoEstacion() As String
                    Get
                        Return Me.xEquipo.Trim
                    End Get
                    Set(ByVal value As String)
                        Me.xEquipo = value
                    End Set
                End Property

                Property _IdUnico() As String
                    Get
                        Return Me.xIdUnico
                    End Get
                    Set(ByVal value As String)
                        Me.xIdUnico = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _FechaMovimiento() As Date
                    Get
                        Dim xfecha As Date = F_GetDate("select getdate()")
                        Return xfecha.Date
                    End Get
                End Property


                Sub New()
                    _IdUnico = ""
                    _EquipoEstacion = ""
                    _FichaUsuario = Nothing
                End Sub
            End Class

            ''' <summary>
            ''' Permite Anular Documento De Compra: Ya Sea Compra/Nota Crédito/Orden Compra
            ''' </summary>
            Function F_AnularDocumento(ByVal xdoc As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro, Optional ByVal Revertir As DocRevertir = Nothing) As Boolean
                Try
                    Dim xcompra As New FichaCompras.c_Compra
                    xcompra.F_CargarCompra(xdoc.RegistroDato.c_AutoDocumento.c_Texto)

                    Select Case xcompra.RegistroDato._TipoDocumentoCompra
                        Case TipoDocumentoCompra.Factura, TipoDocumentoCompra.NotaCredito, TipoDocumentoCompra.NotaDebito
                            If Month(xcompra.RegistroDato._FechaCarga) = Month(xdoc.RegistroDato.c_FechaEmision.c_Valor) _
                              And Year(xcompra.RegistroDato._FechaCarga) = Year(xdoc.RegistroDato.c_FechaEmision.c_Valor) Then
                            Else
                                Throw New Exception("Error Al Anular Documento... Fecha No Corresponde Al Perido Actual De Carga Del Documento !!!")
                            End If
                    End Select

                    If xcompra.RegistroDato._EstatusCompra = TipoEstatus.Inactivo Then
                        Throw New Exception("Error Al Anular Documento... Dicho Documento Ya Se Encuentra Anulado !!!")
                    End If
                    If xcompra.RegistroDato._EstatusCompra = TipoEstatus.Procesado Then
                        Throw New Exception("Error Al Anular Documento... Documento Fue Procesado Por Una Compra !!!")
                    End If

                    'VERIFICAR SI HAY NOTAS DE CREDITO QUE AFECTEN AL DOCUMENTO DE COMPRA
                    Dim xp1 As New SqlParameter("@aplica", xcompra.RegistroDato._NumeroDocumentoCompra)
                    Dim xp2 As New SqlParameter("@serie", xcompra.RegistroDato._SerieDocumento)
                    Dim xp3 As New SqlParameter("@auto_entidad", xcompra.RegistroDato._AutoProveedor)
                    If F_GetInteger("SELECT COUNT(*) FROM COMPRAS WHERE APLICA=@aplica and auto_entidad=@auto_entidad and n_serieaplica=@serie and estatus='0'", xp1, xp2, xp3) > 0 Then
                        Throw New Exception("Error Al Anular Documento... Dicho Documento Tiene Documentos Relacionados Que Deben Ser Eliminados Primero !!!")
                    End If

                    'VERIFICAR SI HAY RETENCIONES PARA EL DOCUMENTO DE COMPRA A ANULAR
                    Dim xp4 As New SqlParameter("@auto_documento", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                    If F_GetInteger("SELECT COUNT(*) FROM retenciones_compras_detalle WHERE auto_documento=@auto_documento and estatus='0'", xp4) > 0 Then
                        Throw New Exception("Error Al Anular Documento... Dicho Documento Tiene Documentos Relacionados Que Deben Ser Eliminados Primero !!!")
                    End If

                    Dim xdetalle As New DataTable
                    Dim sql_1 As String = "select * from compras_detalle where auto_documento=@auto_documento"
                    Using xadap As New SqlDataAdapter(sql_1, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto_documento", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                        xadap.Fill(xdetalle)
                    End Using

                    With xdoc
                        .RegistroDato.c_CodigoAnulacion.c_Texto = "07" + xcompra.RegistroDato.c_TipoDocumentoCompra.c_Texto
                    End With

                    Dim xsql_1 As String = "update contadores set a_documentos_anulados=a_documentos_anulados+1;" _
                      + "select a_documentos_anulados from contadores"
                    Dim xsql_2 As String = "update compras set estatus='1' where auto=@auto"
                    Dim xsql_3 As String = "update cxp set estatus='1' where auto_documento=@auto"
                    Dim xsql_4 As String = "update compras_detalle set estatus='1' where auto_documento=@auto"
                    Dim xsql_5 As String = "update productos_kardex set estatus='1' where auto_documento=@auto and origen=@origen"
                    Dim xsql_6 As String = "update productos_deposito set real = real + @cantidad, disponible = disponible + @cantidad " _
                       + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito"
                    Dim xsql_7 As String = "update productos_historico_costos set estatus='1' " _
                       + "where auto_documento=@auto_documento and origen=@origen"

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try

                            Using xcmd As New SqlCommand("", xcon, xtr)
                                'CONTADORES
                                xcmd.CommandText = xsql_1
                                xdoc.RegistroDato.c_AutoAnulacion.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'DOCUMENTOS_ANULADOS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                xcmd.Parameters.AddWithValue("@codigo", xdoc.RegistroDato.c_CodigoAnulacion.c_Texto).Size = xdoc.RegistroDato.c_CodigoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xdoc.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@hora", xdoc.RegistroDato.c_HoraAnulacion.c_Texto).Size = xdoc.RegistroDato.c_HoraAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@detalle", xdoc.RegistroDato.c_NotaDetalleAnulacion.c_Texto).Size = xdoc.RegistroDato.c_NotaDetalleAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estacion", xdoc.RegistroDato.c_NombreEstacion.c_Texto).Size = xdoc.RegistroDato.c_NombreEstacion.c_Largo
                                xcmd.Parameters.AddWithValue("@usuario", xdoc.RegistroDato.c_NombreUsuario.c_Texto).Size = xdoc.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_usuario", xdoc.RegistroDato.c_CodigoUsuario.c_Texto).Size = xdoc.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@auto", xdoc.RegistroDato.c_AutoAnulacion.c_Texto).Size = xdoc.RegistroDato.c_AutoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xdoc.RegistroDato.c_AutoDocumento.c_Texto).Size = xdoc.RegistroDato.c_AutoDocumento.c_Largo
                                xcmd.ExecuteNonQuery()

                                'COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                xcmd.Parameters.AddWithValue("@auto", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                                xcmd.ExecuteNonQuery()

                                'CXP
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_3
                                xcmd.Parameters.AddWithValue("@auto", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                                xcmd.ExecuteNonQuery()

                                'COMPRAS_DETALLE
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_4
                                xcmd.Parameters.AddWithValue("@auto", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                                xcmd.ExecuteNonQuery()

                                'PRODUCTOS_KARDEX
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_5
                                xcmd.Parameters.AddWithValue("@auto", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                                xcmd.Parameters.AddWithValue("@origen", xdoc.RegistroDato.c_CodigoAnulacion.c_Texto)
                                xcmd.ExecuteNonQuery()

                                Select Case xcompra.RegistroDato.c_TipoDocumentoCompra.c_Texto
                                    Case "01"
                                        'PRODUCTOS_DEPOSITO
                                        For Each dr As DataRow In xdetalle.Rows
                                            Dim xcompras_detalle As New c_ComprasDetalle.c_Registro
                                            xcompras_detalle.M_CargarData(dr)

                                            'VERIFICO SI EL ITEM TIENE UN COSTO. EN CASO DE NO TENERLO EL ITEM FUE POR UN CAMBIO / REPOSICION DE MERCANCIA 
                                            If xcompras_detalle._CostoBruto > 0 Then
                                                Dim xob As Object = Nothing
                                                Dim xf As Date = Date.MinValue
                                                Dim xa As Integer = 0
                                                Dim xa1 As Integer = 0
                                                Dim xc As Decimal = 0
                                                Dim xc1 As Decimal = 0

                                                'CARGO LA MAYOR FECHA DE EMISION DEL PRODUCTO
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "select max(fecha_emision) from productos_historico_costos where auto_producto=@auto_producto and estatus='0' AND (costo_actual+costo_nuevo+costo)>0"
                                                xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                                xob = xcmd.ExecuteScalar
                                                If xob IsNot Nothing And Not IsDBNull(xob) Then
                                                    xf = xob
                                                End If

                                                'CARGO EL MAYOR AUTOMATICO DEL PRODUCTO
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "select max(auto) from productos_historico_costos where auto_producto=@auto_producto and estatus='0' AND fecha_emision=@fecha_maxima_emision"
                                                xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                                xcmd.Parameters.AddWithValue("@fecha_maxima_emision", xf)
                                                xob = xcmd.ExecuteScalar
                                                If xob IsNot Nothing And Not IsDBNull(xob) Then
                                                    xa = Integer.Parse(xob)
                                                End If

                                                'CARGO EL AUTOMATICO DEL PRODUCTO A ANULAR
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "select auto from productos_historico_costos where auto_producto=@auto_producto and auto_documento=@auto_documento"
                                                xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                                xcmd.Parameters.AddWithValue("@auto_documento", xcompras_detalle._AutoDocumentoCompra)
                                                xob = xcmd.ExecuteScalar
                                                If xob IsNot Nothing And Not IsDBNull(xob) Then
                                                    xa1 = Integer.Parse(xob)
                                                End If

                                                'VERIFICO SI HAY UN DOCUMENTO EMITIDO DESPUES DEL DOCUMENTO A ANULAR
                                                If xf > xcompras_detalle._FechaEmision Then 'HAY DOCUMENTOS DESPUES DE ESTE
                                                Else
                                                    If xa > xa1 Then 'ES EL DOCUMENTO A ANULAR EL ULTIMO REGISTRADO PARA ESA FECHA
                                                    Else
                                                        'SI NO HAY MODIFICO LOS COSTOS FINALES EN PRODUCTOS
                                                        xcmd.Parameters.Clear()
                                                        xcmd.CommandText = "select top(1) costo_nuevo from productos_historico_costos where auto_producto=@auto_producto and auto not in (@auto) order by fecha_emision desc ,auto desc"
                                                        xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                                        xcmd.Parameters.AddWithValue("@auto", xa1.ToString.Trim.PadLeft(10, "0"))
                                                        xob = xcmd.ExecuteScalar
                                                        If xob IsNot Nothing And Not IsDBNull(xob) Then
                                                            xc = xob
                                                            xc1 = Decimal.Round(xc / xcompras_detalle._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                                                        End If

                                                        'PRODUCTOS
                                                        xcmd.Parameters.Clear()
                                                        xcmd.CommandText = "update productos set costo_proveedor_compra=@costo_proveedor_compra, costo_proveedor_inventario=@costo_proveedor_inventario, " & _
                                                                           "costo_compra=@costo_compra, costo_inventario=@costo_inventario where auto=@auto"
                                                        xcmd.Parameters.AddWithValue("@costo_proveedor_compra", xc)
                                                        xcmd.Parameters.AddWithValue("@costo_proveedor_inventario", xc1)
                                                        xcmd.Parameters.AddWithValue("@costo_compra", xc)
                                                        xcmd.Parameters.AddWithValue("@costo_inventario", xc1)
                                                        xcmd.Parameters.AddWithValue("@auto", xcompras_detalle._AutoProducto)
                                                        xcmd.ExecuteNonQuery()
                                                    End If
                                                End If
                                            End If

                                            'PRODUCTOS_DEPOSITO
                                            Dim xr As Integer = 0
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = xsql_6
                                            xcmd.Parameters.AddWithValue("@cantidad", xcompras_detalle._TotalUnidadesAEntrarInventario * -1)
                                            xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xcompras_detalle._AutoDeposito)
                                            xr = xcmd.ExecuteNonQuery()
                                            If xr = 0 Then
                                                Throw New Exception("ERROR AL ACTUALIZAR EL DEPOSITO DEL PRODUCTO" + vbCrLf + xcompras_detalle._NombreProducto + vbCrLf)
                                            End If
                                        Next
                                    Case "03" ' ES UNA NOTA DE CRÉDITO
                                        For Each dr As DataRow In xdetalle.Rows
                                            Dim xcompras_detalle As New c_ComprasDetalle.c_Registro
                                            xcompras_detalle.M_CargarData(dr)
                                            If xcompras_detalle._TipoMovimientoEfectuado = TipoMovimientoCompraDetalle.Devolucion Then
                                                'PRODUCTOS_DEPOSITO
                                                Dim xr As Integer = 0
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = xsql_6
                                                xcmd.Parameters.AddWithValue("@cantidad", xcompras_detalle._CantidadCompraUnidadInventario * 1)
                                                xcmd.Parameters.AddWithValue("@auto_producto", xcompras_detalle._AutoProducto)
                                                xcmd.Parameters.AddWithValue("@auto_deposito", xcompras_detalle._AutoDeposito)
                                                xr = xcmd.ExecuteNonQuery()
                                                If xr = 0 Then
                                                    Throw New Exception("ERROR AL ACTUALIZAR DEPOSITO. PRODUCTO/DEPOSITO NO ENCONTRADO")
                                                End If
                                            End If
                                        Next
                                End Select

                                'PRODUCTOS_HISTORICO_COSTOS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_7
                                xcmd.Parameters.AddWithValue("@auto_documento", xdoc.RegistroDato.c_AutoDocumento.c_Texto)
                                xcmd.Parameters.AddWithValue("@origen", xdoc.RegistroDato.c_CodigoAnulacion.c_Texto)
                                xcmd.ExecuteNonQuery()

                                Dim xobj As Object = Nothing
                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcompra.RegistroDato.c_AutoProveedor.c_Texto)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcompra.RegistroDato.c_AutoProveedor.c_Texto)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcompra.RegistroDato.c_AutoProveedor.c_Texto)
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
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@auto", xcompra.RegistroDato.c_AutoProveedor.c_Texto)
                                xcmd.ExecuteNonQuery()

                                'ORDEN DE COMPRA
                                Dim xAutoOrden As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT AutoOrdenCompra from CompraOrdenCompra with (READPAST) where AutoCompra=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xcompra.RegistroDato._AutoDocumentoCompra)
                                xAutoOrden = xcmd.ExecuteScalar
                                If IsDBNull(xAutoOrden) Or (xAutoOrden Is Nothing) Then
                                Else
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update compras set estatus='0' where Auto=@auto and estatus='2'"
                                    xcmd.Parameters.AddWithValue("@auto", xAutoOrden.ToString.Trim)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("PROBLEMA AL ACTUALIZAR ORDEN DE COMPRA")
                                    End If
                                End If

                                If Revertir IsNot Nothing Then
                                    For Each xrow As DataRow In xdetalle.Rows
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
                                            .c_AutoUsuario.c_Texto = Revertir._FichaUsuario._AutoUsuario
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
                                            .c_NombreEstacionEquipo.c_Texto = Revertir._EquipoEstacion
                                            .c_FechaProceso.c_Valor = Revertir._FechaMovimiento
                                            .c_ForzarMedida.c_Texto = xdetOrden.RegistroDato.c_ForzarMedida.c_Texto
                                            .c_IdUnico.c_Texto = Revertir._IdUnico
                                            .c_NotasItem.c_Texto = xdetOrden.RegistroDato._NotasItem
                                            .c_NombreEmpaque.c_Texto = xdetOrden.RegistroDato._Empaque
                                            .c_NombreProducto.c_Texto = xdetOrden.RegistroDato._NombreProducto
                                            .c_NombreUsuario.c_Texto = Revertir._FichaUsuario._NombreUsuario
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
                                            If IsDBNull(xAutoOrden) Or (xAutoOrden Is Nothing) Then
                                                .c_AutoOrdenCompra.c_Texto = ""
                                            Else
                                                .c_AutoOrdenCompra.c_Texto = xAutoOrden.ToString.Trim
                                            End If
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

                                End If


                            End Using

                            xtr.Commit()
                            RaiseEvent ActualizarTabla()
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
                    Throw New Exception("COMPRAS " + vbCrLf + "ANULAR DOCUMENTO DE COMPRAS" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_ProximaPlanillaRetencionGenerar() As String
                Try
                    Dim xa As Integer = 0
                    Dim xf As Date

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Using xcmd As New SqlCommand("", xcon)
                            xcmd.CommandText = "select a_retencion_compras_iva from contadores"
                            xa = xcmd.ExecuteScalar()

                            xcmd.CommandText = "select getdate()"
                            xf = xcmd.ExecuteScalar
                        End Using
                    End Using
                    Dim xr As String = ""
                    xr = Year(xf).ToString + Month(xf).ToString.Trim.PadLeft(2, "0") + (xa + 1).ToString.Trim.PadLeft(10, "0")
                    Return xr
                Catch ex As Exception
                    Throw New Exception("ERROR AL GENERAR PROXIMA PLANILLA RETENCION COMPRAS" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Grabar Retencion Compras Tipo Iva
            ''' </summary>
            ''' <param name="xgrabar"></param>
            ''' Clase Que Contiene La Informacion Para Registrar La Retencion
            ''' <returns></returns>
            Function F_GrabarRetencionIva(ByVal xgrabar As GrabarRetenciones) As Boolean
                Dim xsql1 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim xsql2 As String = "update contadores set a_cxp_recibos=a_cxp_recibos+1; select a_cxp_recibos from contadores"
                Dim xsql3 As String = "update contadores set a_cxp_recibos_numero=a_cxp_recibos_numero+1; select a_cxp_recibos_numero from contadores"
                Dim xsql4 As String = "update contadores set a_retencion_compras_iva=a_retencion_compras_iva+1; select a_retencion_compras_iva from contadores"

                Dim xsentencia As String = "update contadores set a_retencion_compras=a_retencion_compras+1; select a_retencion_compras from contadores"

                Dim xautoretencion As String = ""
                Dim xtr As SqlTransaction = Nothing
                Dim xautodetalle As Integer = 0

                Dim xagregar_cxp As New FichaCtasPagar.c_CxP.c_Registro
                Dim xagregar_cxp_documentos As New FichaCtasPagar.c_Documentos
                Dim xagregar_cxp_recibos As New FichaCtasPagar.c_Recibo
                Dim xagregar_cxp_modo_pago As New FichaCtasPagar.c_ModoPago

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = xsql1
                                xagregar_cxp.c_AutoCxP.c_Texto = xcmd.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                xcmd.CommandText = xsql2
                                xagregar_cxp_recibos.RegistroDato.c_AutoRecibo.c_Texto = xcmd.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                xcmd.CommandText = xsql3
                                xagregar_cxp_recibos.RegistroDato.c_NumeroRecibo.c_Texto = xcmd.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                xcmd.CommandText = xsql4
                                xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Texto = xcmd.ExecuteScalar().ToString().Trim.PadLeft(8, "0")

                                'REGISTRAR LA CUENTA POR PAGAR. PAGO EFECTUADO
                                With xagregar_cxp
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_FechaProceso.c_Valor = xgrabar._Retencion.RegistroDato._FechaRelacion
                                    .c_FechaEmision.c_Valor = xgrabar._Retencion.RegistroDato._FechaEmision
                                    .c_FechaVencimiento.c_Valor = xgrabar._Retencion.RegistroDato._FechaEmision
                                    .c_TipoDocumento.c_Texto = "PAG"
                                    .c_NumeroDocumento.c_Texto = xagregar_cxp_recibos.RegistroDato.c_NumeroRecibo.c_Texto
                                    .c_NotaDetalle.c_Texto = "Pago Con Planilla De Retencion N# " + xgrabar._Retencion.RegistroDato.c_AnoRelacion.c_Texto _
                                                                                                        + xgrabar._Retencion.RegistroDato.c_MesRelacion.c_Texto _
                                                                                                        + xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Texto
                                    .c_MontoImporte.c_Valor = xgrabar._Retencion.RegistroDato.c_MontoRetencion.c_Valor
                                    .c_MontoAcumulado.c_Valor = .c_MontoImporte.c_Valor
                                    .c_AutoProveedor.c_Texto = xgrabar._Proveedor._Automatico
                                    .c_NombreProveedor.c_Texto = xgrabar._Proveedor._NombreRazonSocial
                                    .c_CiRifProveedor.c_Texto = xgrabar._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabar._Proveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = ""
                                    .c_MontoPorPagar.c_Valor = 0
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_Signo.c_Valor = -1

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

                                'GRABAR CUENTA POR PAGAR'
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaCtasPagar.INSERT_CXP
                                xcmd.Parameters.AddWithValue("@auto", xagregar_cxp.c_AutoCxP.c_Texto).Size = xagregar_cxp.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xagregar_cxp.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_carga", xagregar_cxp.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xagregar_cxp.c_TipoDocumento.c_Texto).Size = xagregar_cxp.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xagregar_cxp.c_NumeroDocumento.c_Texto).Size = xagregar_cxp.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xagregar_cxp.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xagregar_cxp.c_NotaDetalle.c_Texto).Size = xagregar_cxp.c_NotaDetalle.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xagregar_cxp.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xagregar_cxp.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar_cxp.c_AutoProveedor.c_Texto).Size = xagregar_cxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@proveedor", xagregar_cxp.c_NombreProveedor.c_Texto).Size = xagregar_cxp.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xagregar_cxp.c_CiRifProveedor.c_Texto).Size = xagregar_cxp.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xagregar_cxp.c_CodigoProveedor.c_Texto).Size = xagregar_cxp.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xagregar_cxp.c_EstatusCancelado.c_Texto).Size = xagregar_cxp.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xagregar_cxp.c_MontoPorPagar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xagregar_cxp.c_TipoOperacion.c_Texto).Size = xagregar_cxp.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xagregar_cxp.c_EstatusDocumento.c_Texto).Size = xagregar_cxp.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xagregar_cxp.c_AutoDocumento.c_Texto).Size = xagregar_cxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xagregar_cxp.c_Signo.c_Valor)
                                'nuevos
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xagregar_cxp.c_AutoMovimientoEntrada.c_Texto).Size = xagregar_cxp.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.Add("@fecha_recepcion_devolucion", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null
                                xcmd.Parameters.AddWithValue("@numero", xagregar_cxp.c_Numero.c_Texto).Size = xagregar_cxp.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xagregar_cxp.c_AutoAgencia.c_Texto).Size = xagregar_cxp.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xagregar_cxp.c_NumeroCuenta.c_Texto).Size = xagregar_cxp.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xagregar_cxp.c_TipoCuenta.c_Texto).Size = xagregar_cxp.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xagregar_cxp.c_NombreTitular.c_Texto).Size = xagregar_cxp.c_NombreTitular.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xagregar_cxp.c_NombreAgencia.c_Texto).Size = xagregar_cxp.c_NombreAgencia.c_Largo
                                xcmd.ExecuteNonQuery()

                                'REGISTRAR RECIBO'
                                With xagregar_cxp_recibos.RegistroDato
                                    .c_FechaEmision.c_Valor = xgrabar._Retencion.RegistroDato._FechaEmision
                                    .c_AutoUsuario.c_Texto = xgrabar._Usuario._AutoUsuario
                                    .c_MontoImporte.c_Valor = xgrabar._Retencion.RegistroDato.c_MontoRetencion.c_Valor
                                    .c_NombreUsuario.c_Texto = xgrabar._Usuario._NombreUsuario
                                    .c_NotaDetalleRecibo.c_Texto = "Recibo De Cobro De Planilla Numero " + xgrabar._Retencion.RegistroDato.c_AnoRelacion.c_Texto _
                                                                                                     + xgrabar._Retencion.RegistroDato.c_MesRelacion.c_Texto _
                                                                                                     + xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Texto
                                    .c_AutoProveedor.c_Texto = xgrabar._Proveedor._Automatico
                                    .c_NombreProveedor.c_Texto = xgrabar._Proveedor._NombreRazonSocial
                                    .c_CiRifProveedor.c_Texto = xgrabar._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabar._Proveedor._CodigoProveedor
                                    .c_EstatusRecibo.c_Texto = "0"
                                    .c_MontoImporteDocumento.c_Valor = ._MontoImporte
                                    .c_MontoTotalDocumento.c_Valor = ._MontoImporte
                                    .c_CantidadDocumentosRelacionados.c_Valor = xgrabar._RetencionDetalle.Count
                                    .c_TipoPago.c_Texto = xgrabar._TipoPagoOrigen
                                End With

                                'GRABAR RECIBO'
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaCtasPagar._INSERT_CXP_RECIBOS
                                xcmd.Parameters.AddWithValue("@auto", xagregar_cxp_recibos.RegistroDato.c_AutoRecibo.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_AutoRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@numero", xagregar_cxp_recibos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_NumeroRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xagregar_cxp_recibos.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_usuario", xagregar_cxp_recibos.RegistroDato.c_AutoUsuario.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_AutoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xagregar_cxp_recibos.RegistroDato.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@usuario", xagregar_cxp_recibos.RegistroDato.c_NombreUsuario.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@importe_documentos", xagregar_cxp_recibos.RegistroDato.c_MontoImporteDocumento.c_Valor)
                                xcmd.Parameters.AddWithValue("@total_documentos", xagregar_cxp_recibos.RegistroDato.c_MontoTotalDocumento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xagregar_cxp_recibos.RegistroDato.c_NotaDetalleRecibo.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_NotaDetalleRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar_cxp_recibos.RegistroDato.c_AutoProveedor.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@nombre_proveedor", xagregar_cxp_recibos.RegistroDato.c_NombreProveedor.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif_proveedor", xagregar_cxp_recibos.RegistroDato.c_CiRifProveedor.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xagregar_cxp_recibos.RegistroDato.c_CodigoProveedor.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xagregar_cxp_recibos.RegistroDato.c_EstatusRecibo.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_EstatusRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@cant_doc_rel", xagregar_cxp_recibos.RegistroDato.c_CantidadDocumentosRelacionados.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_pago", xagregar_cxp_recibos.RegistroDato.c_TipoPago.c_Texto).Size = xagregar_cxp_recibos.RegistroDato.c_TipoPago.c_Largo
                                ''AGREGADO EL 09/12/2021 
                                xcmd.Parameters.AddWithValue("@monto_recibido", xagregar_cxp_recibos.RegistroDato.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@monto_cambio", 0)
                                xcmd.Parameters.AddWithValue("@dirFiscal_proveedor", "")
                                xcmd.Parameters.AddWithValue("@telefono_proveedor", "")
                                xcmd.Parameters.AddWithValue("@nota", "")
                                xcmd.Parameters.AddWithValue("@auto_cxp", xagregar_cxp.c_AutoCxP.c_Texto)

                                xcmd.ExecuteNonQuery()

                                'ACTUALIZO CONTADOR AUTOMATICO DE RETENCIONES DE COMPRAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsentencia
                                xgrabar._Retencion.RegistroDato.c_AutoRetencion.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                xautoretencion = xgrabar._Retencion.RegistroDato.c_AutoRetencion.c_Texto

                                'RETENCIONES COMPRAS
                                With xgrabar._Retencion.RegistroDato
                                    .c_AutoProveedor.c_Texto = xgrabar._Proveedor._Automatico
                                    .c_NombreProveedor.c_Texto = xgrabar._Proveedor._NombreRazonSocial
                                    .c_CiRifProveedor.c_Texto = xgrabar._Proveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xgrabar._Proveedor._CodigoProveedor
                                    .c_DirFiscalProveedor.c_Texto = xgrabar._Proveedor._DirFiscal
                                    .c_AutoCxP.c_Texto = xagregar_cxp.c_AutoCxP.c_Texto
                                    .c_AutoRecibo.c_Texto = xagregar_cxp_recibos.RegistroDato.c_AutoRecibo.c_Texto
                                    .c_EstatusRetencion.c_Texto = "0"
                                    .c_NumeroPlanillaRetencion.c_Texto = .c_AnoRelacion.c_Texto _
                                                                         + .c_MesRelacion.c_Texto _
                                                                         + .c_NumeroPlanillaRetencion.c_Texto
                                    .c_AnoRelacion.c_Texto = .AnoRelacion
                                    .c_MesRelacion.c_Texto = .MesRelacion
                                    .c_Periodo.c_Valor = .RetornarPeriodo
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_RETENCIONESIVA_COMPRAS
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._Retencion.RegistroDato.c_AutoRetencion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_AutoRetencion.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xgrabar._Retencion.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xgrabar._Retencion.RegistroDato.c_NombreProveedor.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_fiscal", xgrabar._Retencion.RegistroDato.c_DirFiscalProveedor.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_DirFiscalProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xgrabar._Retencion.RegistroDato.c_CiRifProveedor.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo", xgrabar._Retencion.RegistroDato.c_TipoDocumentoRetencion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_TipoDocumentoRetencion.c_Largo
                                xcmd.Parameters.AddWithValue("@exento", xgrabar._Retencion.RegistroDato.c_MontoExento.c_Valor)
                                xcmd.Parameters.AddWithValue("@base", xgrabar._Retencion.RegistroDato.c_MontoBase.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto", xgrabar._Retencion.RegistroDato.c_MontoImpuesto.c_Valor)
                                xcmd.Parameters.AddWithValue("@total", xgrabar._Retencion.RegistroDato.c_MontoTotal.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa_retencion", xgrabar._Retencion.RegistroDato.c_TasaRetencion.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion", xgrabar._Retencion.RegistroDato.c_MontoRetencion.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xgrabar._Retencion.RegistroDato.c_AutoProveedor.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_relacion", xgrabar._Retencion.RegistroDato.c_FechaRelacion.c_Valor)
                                xcmd.Parameters.AddWithValue("@codigo_entidad", xgrabar._Retencion.RegistroDato.c_CodigoProveedor.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ano_relacion", xgrabar._Retencion.RegistroDato.c_AnoRelacion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_AnoRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@mes_relacion", xgrabar._Retencion.RegistroDato.c_MesRelacion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_MesRelacion.c_Largo

                                'Nuevos
                                xcmd.Parameters.AddWithValue("@auto_cxp", xgrabar._Retencion.RegistroDato.c_AutoCxP.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_recibo_cxp", xgrabar._Retencion.RegistroDato.c_AutoRecibo.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_AutoRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xgrabar._Retencion.RegistroDato.c_EstatusRetencion.c_Texto).Size = xgrabar._Retencion.RegistroDato.c_EstatusRetencion.c_Largo
                                xcmd.Parameters.AddWithValue("@periodo", xgrabar._Retencion.RegistroDato.c_Periodo.c_Valor)
                                xcmd.ExecuteNonQuery()

                                'RETENCIONES COMPRAS DETALLE
                                Dim xitem As Integer = 0
                                For Each xdetalle In xgrabar._RetencionDetalle
                                    xitem += 1

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_RETENCIONESIVA_COMPRAS_DETALLE
                                    With xdetalle
                                        .RegistroDato.c_AutoRetencion.c_Texto = xgrabar._Retencion.RegistroDato.c_AutoRetencion.c_Texto
                                        .RegistroDato.c_FechaRetencion.c_Valor = xgrabar._Retencion.RegistroDato.c_FechaRelacion.c_Valor
                                        .RegistroDato.c_TipoRetencion.c_Texto = xgrabar._Retencion.RegistroDato.c_TipoDocumentoRetencion.c_Texto
                                        .RegistroDato.c_ComprobanteRetencion.c_Texto = xgrabar._Retencion.RegistroDato.c_NumeroPlanillaRetencion.c_Texto
                                        .RegistroDato.c_CiRifProveedor.c_Texto = xgrabar._Proveedor._CiRif
                                        .RegistroDato.c_Estatus.c_Texto = "0"
                                    End With
                                    xcmd.Parameters.AddWithValue("@auto_documento", xdetalle.RegistroDato.c_AutoDocumento.c_Texto).Size = xdetalle.RegistroDato.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xdetalle.RegistroDato.c_NumeroDocumento.c_Texto).Size = xdetalle.RegistroDato.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xdetalle.RegistroDato.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@exento", xdetalle.RegistroDato.c_MontoExento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base", xdetalle.RegistroDato.c_MontoBase.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base1", xdetalle.RegistroDato.c_MontoBase1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base2", xdetalle.RegistroDato.c_MontoBase2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@base3", xdetalle.RegistroDato.c_MontoBase3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto", xdetalle.RegistroDato.c_MontoImpuesto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto1", xdetalle.RegistroDato.c_MontoImpuesto1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto2", xdetalle.RegistroDato.c_MontoImpuesto2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@impuesto3", xdetalle.RegistroDato.c_MontoImpuesto3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total", xdetalle.RegistroDato.c_MontoTotal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa_retencion", xdetalle.RegistroDato.c_TasaRetencion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion", xdetalle.RegistroDato.c_MontoRetencion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@control", xdetalle.RegistroDato.c_NumeroControlFiscal.c_Texto).Size = xdetalle.RegistroDato.c_NumeroControlFiscal.c_Largo
                                    xcmd.Parameters.AddWithValue("@aplica", xdetalle.RegistroDato.c_DocumentoAplica.c_Texto).Size = xdetalle.RegistroDato.c_DocumentoAplica.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xdetalle.RegistroDato.c_TipoDocumento.c_Texto).Size = xdetalle.RegistroDato.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@tasa1", xdetalle.RegistroDato.c_Tasa1.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa2", xdetalle.RegistroDato.c_Tasa2.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tasa3", xdetalle.RegistroDato.c_Tasa3.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle.RegistroDato.c_AutoRetencion.c_Texto).Size = xdetalle.RegistroDato.c_AutoRetencion.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xdetalle.RegistroDato.c_CiRifProveedor.c_Texto).Size = xdetalle.RegistroDato.c_CiRifProveedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@comprobante", xdetalle.RegistroDato.c_ComprobanteRetencion.c_Texto).Size = xdetalle.RegistroDato.c_ComprobanteRetencion.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo_retencion", xdetalle.RegistroDato.c_TipoRetencion.c_Texto).Size = xdetalle.RegistroDato.c_TipoRetencion.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_retencion", xdetalle.RegistroDato.c_FechaRetencion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estatus", xdetalle.RegistroDato.c_Estatus.c_Texto).Size = xdetalle.RegistroDato.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    'VERIFICO EL DOCUMENTO PARA DETERMINAR LO SIGUIENTE:
                                    'ESTATUS DEL DOCUMENTO: ACTIVO
                                    'OH SI YA TIENE UNA RETENCION HECHA
                                    Dim dr As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select estatus,comprobante_retencion from compras where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle.RegistroDato.c_AutoDocumento.c_Texto)
                                    dr = xcmd.ExecuteReader
                                    Dim xerr As Boolean = False
                                    While dr.Read
                                        If dr(0).ToString.Trim = "1" Then
                                            xerr = True
                                        End If
                                        If dr(1).ToString.Trim <> "" Then
                                            xerr = True
                                        End If
                                    End While
                                    dr.Close()
                                    If xerr = True Then
                                        Throw New Exception("ERROR EN DOCUMENTO A PROCESAR RETENCION: " & _
                                                            xdetalle.RegistroDato.c_NumeroDocumento.c_Texto & vbCrLf & _
                                                            "DOCUMENTO ANULADO / YA TIENE UNA RETENCION ASIGNADA")
                                    End If

                                    'ACTUALIZAR COMPRAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update compras set tasa_retencion_iva=@tasa_retencion_iva, retencion_iva=@retencion_iva, comprobante_retencion=@comprobante_retencion where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xdetalle.RegistroDato.c_AutoDocumento.c_Texto).Size = xdetalle.RegistroDato.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xdetalle.RegistroDato.c_TasaRetencion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@retencion_iva", xdetalle.RegistroDato.c_MontoRetencion.c_Valor)
                                    xcmd.Parameters.AddWithValue("@comprobante_retencion", xdetalle.RegistroDato.c_ComprobanteRetencion.c_Texto).Size = xdetalle.RegistroDato.c_ComprobanteRetencion.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    'ACTUALIZAR CUENTAS POR COBRAR
                                    Dim xr As Integer = 0
                                    Dim xsigno As Integer = 1
                                    Dim xauto As String = ""
                                    Dim xtipo As String = ""

                                    Select Case xdetalle.RegistroDato._TipoDocumento
                                        Case TipoDocumentoCompra.Factura
                                            xtipo = "FACTURA"
                                        Case TipoDocumentoCompra.NotaDebito
                                            xtipo = "NOTA DEBITO"
                                        Case TipoDocumentoCompra.NotaCredito
                                            xtipo = "NOTA CREDITO"
                                            xsigno = -1
                                    End Select

                                    Dim xobj_1 As Object
                                    xauto = ""
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from cxp where auto_documento=@auto_documento and estatus='0'"
                                    xcmd.Parameters.AddWithValue("@auto_documento", xdetalle.RegistroDato.c_AutoDocumento.c_Texto).Size = xdetalle.RegistroDato.c_AutoDocumento.c_Largo
                                    xobj_1 = xcmd.ExecuteScalar
                                    If xobj_1 Is Nothing Or IsDBNull(xobj_1) Then
                                        Throw New Exception("ERROR DOCUMENTO DE CXP NO ENCONTADO / ANULADO POR OTRO USUARIO")
                                    Else
                                        xauto = xobj_1.ToString
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update cxp set acumulado=acumulado+@monto, resta=resta-@monto where auto=@auto and ABS(resta)>=ABS(@monto)"
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@monto", xdetalle.RegistroDato.c_MontoRetencion.c_Valor)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR EL MONTO DE LA RETENCION ES MAYOR AL MONTO POR PAGAR DEL DOCUMENTO")
                                    End If

                                    Dim xrest As Decimal = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select resta from cxp where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xrest = xcmd.ExecuteScalar

                                    If IsNothing(xrest) Or IsDBNull(xrest) Then
                                        Throw New Exception("ERROR AL ACTUALIZAR EL ESTATUS DE CANCELADO DE LA CXP" + vbCrLf + "AUTO DE LA CXP NO ENCONTRADO")
                                    End If

                                    If xrest = 0 Then
                                        xr = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update cxp set cancelado='1' where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@auto", xauto)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL ACTUALIZAR EL ESTATUS DE CANCELADO DE LA CXP" + vbCrLf + "AUTO DE LA CXP NO ENCONTRADO")
                                        End If
                                    End If

                                    'REGISTRAR DOCUMENTO
                                    With xagregar_cxp_documentos.RegistroDato
                                        .c_AutoCxP.c_Texto = xauto
                                        .c_AutoPago.c_Texto = xagregar_cxp.c_AutoCxP.c_Texto
                                        .c_AutoRecibo.c_Texto = xagregar_cxp_recibos.RegistroDato.c_AutoRecibo.c_Texto
                                        .c_NumeroRecibo.c_Texto = xagregar_cxp_recibos.RegistroDato.c_NumeroRecibo.c_Texto
                                        .c_TipoDocumento.c_Texto = "PAG"
                                        .c_OrigenDocumento.c_Texto = xtipo
                                        .c_Item.c_Valor = xitem
                                        .c_FechaEmision.c_Valor = xgrabar._Retencion.RegistroDato._FechaRelacion
                                        .c_NumeroDocumento.c_Texto = xdetalle.RegistroDato._NumeroDocumento
                                        .c_TipoOperacion.c_Texto = "Abono"
                                        .c_MontoDocumento.c_Valor = xdetalle.RegistroDato._Retencion._Valor
                                        .c_NotaDetalle.c_Texto = "Abono Con Planilla Numero " + xgrabar._Retencion.RegistroDato._NumeroPlanillaRetencion
                                    End With

                                    'GRABAR DOCUMENTO'
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasPagar.INSERT_CXP_DOCUMENTOS
                                    xcmd.Parameters.AddWithValue("@item", xagregar_cxp_documentos.RegistroDato.c_Item.c_Valor)
                                    xcmd.Parameters.AddWithValue("@operacion", xagregar_cxp_documentos.RegistroDato.c_TipoOperacion.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_TipoOperacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@monto", xagregar_cxp_documentos.RegistroDato.c_MontoDocumento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cxp", xagregar_cxp_documentos.RegistroDato.c_AutoCxP.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_AutoCxP.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xagregar_cxp_documentos.RegistroDato.c_NumeroDocumento.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cxp_pago", xagregar_cxp_documentos.RegistroDato.c_AutoPago.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_AutoPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xagregar_cxp_documentos.RegistroDato.c_TipoDocumento.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xagregar_cxp_documentos.RegistroDato.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xagregar_cxp_documentos.RegistroDato.c_NotaDetalle.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_NotaDetalle.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cxp_recibo", xagregar_cxp_documentos.RegistroDato.c_AutoRecibo.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_AutoRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero_recibo", xagregar_cxp_documentos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_NumeroRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xagregar_cxp_documentos.RegistroDato.c_OrigenDocumento.c_Texto).Size = xagregar_cxp_documentos.RegistroDato.c_OrigenDocumento.c_Largo
                                    xcmd.ExecuteNonQuery()
                                Next

                                'VERIFICO QUE LAS NOTAS DE CREDITO A PROCESAR ESTEN CON SU DOCUMENTO DE COMPRA EN EL MISMO PERIODO CON SU RETENCION 
                                'SIN IMPORTAR SI EL DOC DE COMPRA SE LE HIZO RETENCION SIN HABER TENIDO LA NC.
                                Dim xd1 As FichaCompras.c_Compra.c_Registro
                                Dim xtb As DataTable
                                Dim xdr As SqlDataReader
                                Dim xautover As New Object
                                For Each xdetalle In xgrabar._RetencionDetalle
                                    If xdetalle.RegistroDato._TipoDocumento = TipoDocumentoCompra.NotaCredito Then
                                        xd1 = New FichaCompras.c_Compra.c_Registro
                                        xtb = New DataTable
                                        xdr = Nothing
                                        xautover = Nothing

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select * from compras where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@auto", xdetalle.RegistroDato._AutoDocumento)
                                        xdr = xcmd.ExecuteReader()
                                        xtb.Load(xdr)

                                        xd1.M_CargarData(xtb.Rows(0)) 'CARGAR REGISTRO N/C

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select AUTO from compras where documento=@documento and auto_entidad=@auto_entidad and n_serie=@serie " & _
                                            "and mes_relacion=@mes and ano_relacion=@ano and n_periodo=@periodo and comprobante_retencion<>'' and estatus='0'"
                                        xcmd.Parameters.AddWithValue("@documento", xd1._DocumentoAplica)
                                        xcmd.Parameters.AddWithValue("@auto_entidad", xd1._AutoProveedor)
                                        xcmd.Parameters.AddWithValue("@serie", xd1._SerieDocumentoAplica)
                                        xcmd.Parameters.AddWithValue("@mes", xd1._MesRelacion)
                                        xcmd.Parameters.AddWithValue("@ano ", xd1._AnoRelacion)
                                        xcmd.Parameters.AddWithValue("@periodo", xd1._Periodo)
                                        xautover = xcmd.ExecuteScalar()

                                        If xautover = Nothing Or IsDBNull(xautover) Then
                                            Dim xm As String = vbCrLf & "DOCUMENTO NOTA DE CREDITO #: " & xdetalle.RegistroDato._NumeroDocumento & vbCrLf & _
                                              " ESTA EN UN PERIODO QUE NO CORRESPONDE AL DOCUMENTO ORIGEN DE COMPRA, ó ,AL DOCUMENTO DE COMPRA NO SE LE APLICO RETENCION"
                                            Throw New Exception(xm)
                                        End If
                                    End If
                                Next

                                Dim xobj As Object = Nothing
                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Proveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xgrabar._Proveedor._Automatico)
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
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@auto", xgrabar._Proveedor._Automatico)
                                xcmd.ExecuteNonQuery()

                                xtr.Commit()
                            End Using
                            RaiseEvent _RetencionOk_Generada(xautoretencion)
                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO DE RETENCION CON EL MISMO NUMERO DE PLANILLA ASIGNADA")
                            Else
                                Throw New Exception(xsql.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("RETENCION COMPRAS IVA" + vbCrLf + "ERROR AL GRABAR RETENCION COMPRAS IVA:" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Anular Documento De Retencion En Compra
            ''' </summary>
            ''' <param name="xauto"></param>
            ''' AUTOMATICO DEL DOCUMENTO A ANULAR
            ''' <returns></returns>
            Function F_AnularRetencionIva(ByVal xauto As String, ByVal xdoc_anulados As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xauto_recibo As String = ""
                Dim xauto_cxp As String = ""
                Dim xauto1 As String = ""
                Dim xsql1 As String = "update contadores set a_documentos_anulados=a_documentos_anulados+1;select a_documentos_anulados from contadores"

                Try
                    Dim xretencion As New FichaCompras.c_Retenciones
                    xretencion.F_BuscarDocumento(xauto)

                    If xretencion.RegistroDato.VerificarDocumento_AnoMesPeriodo(xdoc_anulados.RegistroDato.c_FechaEmision.c_Valor) Then
                    Else
                        Throw New Exception("Error Al Anular Documento... Fecha No Corresponde Al Perido Actual !!!")
                    End If

                    If xretencion.RegistroDato._EstatusRetencion = TipoEstatus.Inactivo Then
                        Throw New Exception("Error Al Anular Documento... Dicho Documento Ya Se Encuentra Anulado !!!")
                    End If

                    Dim xtb As New DataTable
                    Using xadap As New SqlDataAdapter("select auto_documento, retencion from retenciones_compras_detalle where auto=@auto", _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                        xadap.Fill(xtb)
                    End Using

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                'NECESITO EL AUTO DE LA CUENTA POR PAGAR DEL PAGO DE LA RETENCION
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto_cxp from retenciones_compras where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xauto_cxp = xcmd.ExecuteScalar.ToString.Trim

                                'NECESITO EL AUTO DEL RECIBO DE LA CUENTA POR PAGAR DEL PAGO DE LA RETENCION
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto_recibo_cxp from retenciones_compras where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xauto_recibo = xcmd.ExecuteScalar.ToString.Trim

                                'ACTUALIZAR EL ESTATUS A ANULADOR DEL PAGO RELACIONADO CON LA PLANILLA DE RETENCION EN (1)
                                Dim xr As Integer = 0
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update cxp set estatus='1' where auto=@auto and estatus='0'"
                                xcmd.Parameters.AddWithValue("@auto", xauto_cxp)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE SE PUEDE VOLVER A ANULAR")
                                End If

                                'ACTUALIZAR EL ESTATUS A ANULADO DEL RECIBO DE CXP RELACIONADO CON LA PLANILLA DE RETENCION EN (1)
                                xr = 0
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update cxp_recibos set estatus='1' where auto=@auto and estatus='0'"
                                xcmd.Parameters.AddWithValue("@auto", xauto_recibo)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE SE PUEDE VOLVER A ANULAR")
                                End If

                                For Each xreg As DataRow In xtb.Rows
                                    'ACTUALIZO LOS DOCUMENTOS DE COMPRA RELACIONADOS CON LA PLANILLA DE RETENCION
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = UPDATE_COMPRAS_RETENCION_IVA
                                    xcmd.Parameters.AddWithValue("@auto", xreg("auto_documento"))
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE SE PUEDE VOLVER A ANULAR")
                                    End If

                                    'ACTUALIZO LOS MONTOS DE CUENTAS POR PAGAR RELACIONADOS CON LA PLANILLA DE RETENCION
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = UPDATE_CXP_RETENCION_IVA
                                    xcmd.Parameters.AddWithValue("@auto_documento", xreg("auto_documento"))
                                    xcmd.Parameters.AddWithValue("@monto", xreg("retencion"))
                                    xcmd.ExecuteNonQuery()
                                Next

                                'ACTUALIZAR EL ESTATUS DEL DOCUMENTO ANULADO DE RETENCIONES COMPRAS DETALLE EN (1)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update retenciones_compras_detalle set estatus='1' where auto=@auto and estatus='0'"
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE SE PUEDE VOLVER A ANULAR")
                                End If

                                'ACTUALIZAR EL ESTATUS DEL DOCUMENTO ANULADO DE RETENCIONES COMPRAS EN (1)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update retenciones_compras set estatus='1' where auto=@auto and estatus='0'"
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("EL DOCUMENTO YA ESTA ANULADO. NO PUEDE SE PUEDE VOLVER A ANULAR")
                                End If

                                'REGISTRAR DOCUMENTO DE RETENCION ANULADO
                                xcmd.CommandText = "update contadores set a_documentos_anulados=a_documentos_anulados+1;select a_documentos_anulados from contadores"
                                xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Texto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")
                                With xdoc_anulados.RegistroDato
                                    .c_AutoDocumento.c_Texto = xauto
                                    .c_CodigoAnulacion.c_Texto = "RETE"
                                End With

                                'GRABAR DOCUMENTO ANULADO
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                xcmd.Parameters.AddWithValue("@codigo", xdoc_anulados.RegistroDato.c_CodigoAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_CodigoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xdoc_anulados.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@hora", xdoc_anulados.RegistroDato.c_HoraAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_HoraAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@detalle", xdoc_anulados.RegistroDato.c_NotaDetalleAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_NotaDetalleAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estacion", xdoc_anulados.RegistroDato.c_NombreEstacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_NombreEstacion.c_Largo
                                xcmd.Parameters.AddWithValue("@usuario", xdoc_anulados.RegistroDato.c_NombreUsuario.c_Texto).Size = xdoc_anulados.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_usuario", xdoc_anulados.RegistroDato.c_CodigoUsuario.c_Texto).Size = xdoc_anulados.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@auto", xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xdoc_anulados.RegistroDato.c_AutoDocumento.c_Texto).Size = xdoc_anulados.RegistroDato.c_AutoDocumento.c_Largo
                                xcmd.ExecuteNonQuery()

                                'REGISTRAR DOCUMENTO DE PAGO ANULADO
                                xcmd.CommandText = "update contadores set a_documentos_anulados=a_documentos_anulados+1;select a_documentos_anulados from contadores"
                                xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Texto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")
                                With xdoc_anulados.RegistroDato
                                    .c_AutoDocumento.c_Texto = xauto_cxp
                                    .c_CodigoAnulacion.c_Texto = "0501"
                                End With

                                'GRABAR DOCUMENTO ANULADO
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                xcmd.Parameters.AddWithValue("@codigo", xdoc_anulados.RegistroDato.c_CodigoAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_CodigoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xdoc_anulados.RegistroDato.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@hora", xdoc_anulados.RegistroDato.c_HoraAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_HoraAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@detalle", xdoc_anulados.RegistroDato.c_NotaDetalleAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_NotaDetalleAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estacion", xdoc_anulados.RegistroDato.c_NombreEstacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_NombreEstacion.c_Largo
                                xcmd.Parameters.AddWithValue("@usuario", xdoc_anulados.RegistroDato.c_NombreUsuario.c_Texto).Size = xdoc_anulados.RegistroDato.c_NombreUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_usuario", xdoc_anulados.RegistroDato.c_CodigoUsuario.c_Texto).Size = xdoc_anulados.RegistroDato.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@auto", xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Texto).Size = xdoc_anulados.RegistroDato.c_AutoAnulacion.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xdoc_anulados.RegistroDato.c_AutoDocumento.c_Texto).Size = xdoc_anulados.RegistroDato.c_AutoDocumento.c_Largo
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()

                            RaiseEvent ActualizarTabla()
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("RETENCIONES IVA" + vbCrLf + "ERROR AL ANULAR" + vbCrLf + ex.Message)
                End Try
            End Function


            ''' <summary>
            ''' FUNCION: INDICA SI HAY / NO RETENCIONES 
            ''' </summary>
            Function F_HayRetenciones() As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Using xcmd As New SqlCommand("", xcon)
                            xcmd.CommandText = "select count(*) from retenciones_compras"
                            If xcmd.ExecuteScalar() > 0 Then
                                Return True
                            Else
                                Return False
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function
        End Class

        Private xfichaCompras As FichaCompras

        Property f_FichaCompras() As FichaCompras
            Get
                Return xfichaCompras
            End Get
            Set(ByVal value As FichaCompras)
                xfichaCompras = value
            End Set
        End Property

    End Class
End Namespace


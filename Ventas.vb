Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL VENTAS
        ''' </summary>
        Partial Public Class FichaVentas
            Event ActualizarTabla()
            Event FacturaExitosa()
            Event DocumentoProcesado(ByVal xauto)
            Event _ActualizarFichaCliente(ByVal xauto_cliente As String)
            Event _DocumentoTrasladado(ByVal xDocVenta As FichaVentas.V_Ventas.c_Registro)


            ''' <summary>
            ''' Clase. USADA PARA CONTENER LOS TIPOS DE EMPAQUE DE VENTA
            ''' </summary>
            Private Class MedidasVenta
                Dim xauto As String
                Dim xnombre As String
                Dim xdecimales As String
                Dim xcantidad As Decimal

                Property _Auto() As String
                    Get
                        Return xauto
                    End Get
                    Set(ByVal value As String)
                        xauto = value
                    End Set
                End Property

                Property _Nombre() As String
                    Get
                        Return xnombre
                    End Get
                    Set(ByVal value As String)
                        xnombre = value
                    End Set
                End Property

                Property _Decimales() As String
                    Get
                        Return xdecimales
                    End Get
                    Set(ByVal value As String)
                        xdecimales = value
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

                Sub New()
                    _Auto = ""
                    _Decimales = ""
                    _Cantidad = 0
                    _Nombre = ""
                End Sub
            End Class

            ''' <summary>
            ''' Clase. CONDICIONES USADAS PARA GUARDAR/PROCESAR EL DOCUMENTO 
            ''' </summary>
            Class CondicionesParaVenta
                Private xprecio_cero As Boolean
                Private xprecio_menor_costo As Boolean
                Private xruptura_por_existencia As Boolean

                Property _Permitir_PrecioCero() As Boolean
                    Get
                        Return xprecio_cero
                    End Get
                    Set(ByVal value As Boolean)
                        xprecio_cero = value
                    End Set
                End Property

                Property _Permitir_PrecioMenorCosto() As Boolean
                    Get
                        Return xprecio_menor_costo
                    End Get
                    Set(ByVal value As Boolean)
                        xprecio_menor_costo = value
                    End Set
                End Property

                Property _Permitir_RupturaPorExistencia() As Boolean
                    Get
                        Return xruptura_por_existencia
                    End Get
                    Set(ByVal value As Boolean)
                        xruptura_por_existencia = value
                    End Set
                End Property

                Sub New()
                    _Permitir_PrecioCero = False
                    _Permitir_PrecioMenorCosto = False
                    _Permitir_RupturaPorExistencia = True
                End Sub
            End Class

            ''' <summary>
            ''' INDICA LOS TIPOS DE DOCUMENTOS DE VENTAS REGISTRADOS EN LA BASE DE DATOS
            ''' </summary>
            Public Enum TipoDocumentoVentaRegistrado
                Factura = 1
                NotaDebito = 2
                NotaCredito = 3
                NotaEntrega = 4
                Presupuesto = 5
                Pedido = 6
                Chimbo = -1
                ChimboNC = -2
            End Enum

            ''' <summary>
            ''' INDICA EL TIPO/CONDICION DE PAGO
            ''' </summary>
            Public Enum TipoCondcionPago As Integer
                Contado = 1
                Credito = 2
            End Enum

            ''' <summary>
            ''' PROCEDENCIA / ORIGEN MODULO EL CUAL EMITIO EL DOCUMENTO
            ''' </summary>
            Enum ProcedenciaDocumento As Integer
                NODEFINIDO = 0
                ADMINISTRATIVO = 1
                PTOVENTA_ONLINE = 2
                PTOVENTA_OFFLINE = 3
                FASTFOOD = 4
                RESTAURANT = 5
                ESTACIONAMIENTO = 6
            End Enum


            ''' <summary>
            ''' CLASE USADA EN CASO DE REVERTIR UN DOCUMENTO
            ''' </summary>
            ''' <remarks></remarks>
            Class RevertirDocumento
                Private xautodeposito As String
                Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                Private xbloquearexistencia As String
                Private xfecha As Date
                Private xestacion As String
                Private xidunico As String

                Property _AutoDeposito() As String
                    Get
                        Return Me.xautodeposito
                    End Get
                    Set(ByVal value As String)
                        Me.xautodeposito = value
                    End Set
                End Property

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xfichausuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xfichausuario = value
                    End Set
                End Property

                Property _BloquearExistencia() As Boolean
                    Get
                        Return Me.xbloquearexistencia
                    End Get
                    Set(ByVal value As Boolean)
                        Me.xbloquearexistencia = value
                    End Set
                End Property

                Property _Fecha() As Date
                    Get
                        Return Me.xfecha
                    End Get
                    Set(ByVal value As Date)
                        Me.xfecha = value
                    End Set
                End Property

                Property _Estacion() As String
                    Get
                        Return Me.xestacion
                    End Get
                    Set(ByVal value As String)
                        Me.xestacion = value
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
                    Me._AutoDeposito = ""
                    Me._BloquearExistencia = False
                    Me._Estacion = ""
                    Me._Fecha = Date.MinValue
                    Me._FichaUsuario = Nothing
                    Me._IdUnico = ""
                End Sub
            End Class

            Class V_TemporalVenta
                Event ActualizarTabla()

                ''' <summary>
                ''' Clase. Permite Definar Forma De Trabajo
                ''' </summary>
                Class Condiciones
                    Private xbloquearexistencia As Boolean
                    Private xagruparitems As Boolean

                    Property _BloquearExistencia() As Boolean
                        Get
                            Return xbloquearexistencia
                        End Get
                        Set(ByVal value As Boolean)
                            xbloquearexistencia = value
                        End Set
                    End Property

                    Property _AgruparItems() As Boolean
                        Get
                            Return xagruparitems
                        End Get
                        Set(ByVal value As Boolean)
                            xagruparitems = False
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase. Permite Definar Datos Necesarios Para Agregar Un Registro
                ''' </summary>
                Class c_AgregarRegistro
                    Dim xreg As c_Registro

                    Protected Friend Property RegistroNuevo() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_CodigoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_NombreProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Cantidad() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_CantidadDespachar.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioNeto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_PrecioNeto.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Descuento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_Descuento.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaIva() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_TasaIva.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EsPesado() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroNuevo.c_EsPesado.c_Texto = "1"
                            Else
                                Me.RegistroNuevo.c_EsPesado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ForzarMedida() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroNuevo.c_ForzarDecimalesMedida.c_Texto = "1"
                            Else
                                Me.RegistroNuevo.c_ForzarDecimalesMedida.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _ContenidoEmpaque() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroNuevo.c_ContenidoEmpaque.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _NombreEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_NombreEmpaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoMedida() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_AutoMedida.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NumeroDecimalesMedida() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroNuevo.c_NumeroDecimalesMedida.c_Texto = value.ToString
                        End Set
                    End Property

                    WriteOnly Property _ReferenciaEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_ReferenciaEmpaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoTasa() As TipoTasaImpuesto
                        Set(ByVal value As TipoTasaImpuesto)
                            Select Case value
                                Case TipoTasaImpuesto.Exento
                                    Me.RegistroNuevo.c_TipoTasa.c_Texto = "0"
                                Case TipoTasaImpuesto.Vigente
                                    Me.RegistroNuevo.c_TipoTasa.c_Texto = "1"
                                Case TipoTasaImpuesto.Reducida
                                    Me.RegistroNuevo.c_TipoTasa.c_Texto = "2"
                                Case TipoTasaImpuesto.Otra
                                    Me.RegistroNuevo.c_TipoTasa.c_Texto = "3"
                                Case Else
                                    Throw New Exception("VENTAS TEMPORAL" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + "ERROR EN EL TIPO DE IMPUESTO PARA ESTE PRODUCTO")
                            End Select
                        End Set
                    End Property

                    WriteOnly Property _AutoDeposito() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_AutoDeposito.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_AutoUsuario.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_NombreUsuario.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaProceso() As Date
                        Set(ByVal value As Date)
                            Me.RegistroNuevo.c_FechaProceso.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EstacionEquipo() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_EstacionEquipo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_TipoDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PSugerido() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_PSugerido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoInventario() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_CostoInventario.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoVenta() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroNuevo.c_CostoVenta.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ItemNotas() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_ItemNotas.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdUnico() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_IdUnico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoDocumento_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_AutoDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumento_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_TipoDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ProblemaDocumento_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroNuevo.c_ProblemaDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RestringidoVenta() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                Me.RegistroNuevo.c_RestringidoVenta.c_Texto = "1"
                            Else
                                Me.RegistroNuevo.c_RestringidoVenta.c_Texto = ""
                            End If
                        End Set
                    End Property


                    Sub New()
                        Me.RegistroNuevo = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase. Definicion Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_codigo As CampoTexto
                    Private f_producto As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_precioneto As CampoDecimal
                    Private f_descuento As CampoDecimal
                    Private f_tasaiva As CampoDecimal
                    Private f_importe As CampoDecimal
                    Private f_espesado As CampoTexto
                    Private f_autoitem As CampoTexto
                    Private f_autoproducto As CampoTexto
                    Private f_bloquearexistencia As CampoTexto
                    Private f_nombreempaque As CampoTexto
                    Private f_contenidoempaque As CampoInteger
                    Private f_referenciaempaque As CampoTexto
                    Private f_automedida As CampoTexto
                    Private f_decimalesmedida As CampoTexto
                    Private f_forzarmedida As CampoTexto
                    Private f_tipotasa As CampoTexto
                    Private f_autodeposito As CampoTexto
                    Private f_autousuario As CampoTexto
                    Private f_nombreusuario As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_estacion As CampoTexto
                    Private f_tipodocumento As CampoTexto
                    Private f_psugerido As CampoDecimal
                    Private f_pliquida As CampoDecimal
                    Private f_costoinventario As CampoDecimal
                    Private f_costoventa As CampoDecimal
                    Private f_notasitem As CampoTexto
                    Private f_idunico As CampoTexto

                    'Campos Nuevos
                    Private f_n_tipodoc_origen As CampoTexto
                    Private f_n_autodoc_origen As CampoTexto
                    Private f_n_problema_origen As CampoTexto
                    Private f_n_autoitem_doc_origen As CampoTexto
                    Private f_n_restringidoVenta As CampoTexto


                    Protected Friend Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
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

                    Protected Friend Property c_CantidadDespachar() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    Protected Friend Property c_PrecioNeto() As CampoDecimal
                        Get
                            Return f_precioneto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precioneto = value
                        End Set
                    End Property

                    Protected Friend Property c_Descuento() As CampoDecimal
                        Get
                            Return f_descuento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento = value
                        End Set
                    End Property

                    Protected Friend Property c_Importe() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
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

                    Protected Friend Property c_BloquearExistencia() As CampoTexto
                        Get
                            Return f_bloquearexistencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_bloquearexistencia = value
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

                    Protected Friend Property c_ReferenciaEmpaque() As CampoTexto
                        Get
                            Return f_referenciaempaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_referenciaempaque = value
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

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_autousuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autousuario = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return f_nombreusuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreusuario = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaProceso() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Protected Friend Property c_EstacionEquipo() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
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

                    Protected Friend Property c_PSugerido() As CampoDecimal
                        Get
                            Return f_psugerido
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_psugerido = value
                        End Set
                    End Property

                    Protected Friend Property c_PLiquida() As CampoDecimal
                        Get
                            Return f_pliquida
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_pliquida = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Costo De Venta En Unidad DE Inventario del Empaque
                    ''' </summary>
                    Protected Friend Property c_CostoInventario() As CampoDecimal
                        Get
                            Return f_costoinventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoinventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Costo De Venta del Empaque
                    ''' </summary>
                    Protected Friend Property c_CostoVenta() As CampoDecimal
                        Get
                            Return f_costoventa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoventa = value
                        End Set
                    End Property

                    Property c_ItemNotas() As CampoTexto
                        Get
                            Return f_notasitem
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_notasitem = value
                        End Set
                    End Property

                    Property c_IdUnico() As CampoTexto
                        Get
                            Return f_idunico
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_idunico = value
                        End Set
                    End Property

                    'Campos Nuevos
                    Property c_TipoDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_tipodoc_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            Me.f_n_tipodoc_origen = value
                        End Set
                    End Property

                    Property c_AutoDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_autodoc_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            Me.f_n_autodoc_origen = value
                        End Set
                    End Property

                    Property c_ProblemaDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_problema_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            Me.f_n_problema_origen = value
                        End Set
                    End Property

                    Property c_AutoItem_Documento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_autoitem_doc_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            Me.f_n_autoitem_doc_origen = value
                        End Set
                    End Property

                    Property c_RestringidoVenta() As CampoTexto
                        Get
                            Return Me.f_n_restringidoVenta
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            Me.f_n_restringidoVenta = value
                        End Set
                    End Property


                    ReadOnly Property _RestringidoVenta() As TipoSiNo
                        Get
                            If Me.c_RestringidoVenta.c_Texto = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumentoOrigen() As TipoDocumentoTrasladarVenta
                        Get
                            Select Case Me.c_TipoDocumento_Origen.c_Texto.Trim
                                Case "01" : Return TipoDocumentoTrasladarVenta.Presupuesto
                                Case "02" : Return TipoDocumentoTrasladarVenta.Pedido
                                Case "03" : Return TipoDocumentoTrasladarVenta.NotraEntrega
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumentoOrigen() As String
                        Get
                            Return Me.c_AutoDocumento_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem_DocumentoOrigen() As String
                        Get
                            Return Me.c_AutoItem_Documento_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaVenta_DocumentoOrigen() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                Dim xventa As New FichaVentas.V_Ventas
                                xventa.F_BuscarDocumento(Me._AutoDocumentoOrigen)
                                Return xventa.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _f_FichaVentaDetalle_AutoItem_DocumentoOrigen() As FichaVentas.V_VentasDetalle.c_Registro
                        Get
                            Try
                                Dim xventadetalle As New FichaVentas.V_VentasDetalle
                                xventadetalle.F_BuscarCargar(Me._AutoDocumentoOrigen, Me._AutoItem_DocumentoOrigen)
                                Return xventadetalle.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _ProblemaDocumentoOrigen() As Boolean
                        Get
                            If Me.c_ProblemaDocumento_Origen.c_Texto.Trim = "0" Then
                                Return False
                            Else
                                Return True
                            End If
                        End Get
                    End Property
                    '

                    ReadOnly Property _AutoItem() As String
                        Get
                            Return Me.c_AutoItem.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Return Me.c_CantidadDespachar.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return Me.c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Descuento() As Decimal
                        Get
                            Return Me.c_Descuento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As String
                        Get
                            Return Me.c_EsPesado.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim ximporte As Decimal = 0

                            'ximporte = (Me._PrecioNeto - (Me._PrecioNeto * Me._Descuento / 100)) * Me._CantidadDespachar
                            'Return Decimal.Round(ximporte, 2, MidpointRounding.AwayFromZero)

                            Dim x1 As Decimal = (Me._PrecioNeto * Me._CantidadDespachar)
                            Dim x2 As Decimal = x1 * Me._Descuento / 100
                            x2 = Decimal.Round(x2, 2, MidpointRounding.AwayFromZero)
                            Dim x3 As Decimal = x1 - x2
                            x3 = Decimal.Round(x3, 2, MidpointRounding.AwayFromZero)
                            Return x3
                        End Get
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return Me.c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Return Me.c_PrecioNeto.c_Valor
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

                    ReadOnly Property _BloquearExistencia() As Boolean
                        Get
                            If Me.c_BloquearExistencia.c_Texto.Trim = "1" Then
                                Return True
                            Else
                                Return False
                            End If
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

                    ReadOnly Property _ReferenciaEmpaque() As String
                        Get
                            Return Me.c_ReferenciaEmpaque.c_Texto.Trim
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

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return Me.c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FechaProceso.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EstacionEquipo() As String
                        Get
                            Return Me.c_EstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As String
                        Get
                            Return Me.c_TipoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _PSugerido() As Decimal
                        Get
                            Return Me.c_PSugerido.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PFinal() As Decimal
                        Get
                            Dim xpfin As Decimal = 0
                            xpfin = Me._PrecioNeto - (Me._PrecioNeto * Me._Descuento / 100)
                            xpfin = Decimal.Round(xpfin, 2, MidpointRounding.AwayFromZero)
                            Return xpfin
                        End Get
                    End Property

                    ReadOnly Property _PLiquida() As Decimal
                        Get
                            Dim xliq As Decimal = 0
                            xliq = _PFinal / _ContenidoEmpaque
                            xliq = Decimal.Round(xliq, 2, MidpointRounding.AwayFromZero)
                            Return xliq
                        End Get
                    End Property

                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return Me.c_CostoInventario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoVenta() As Decimal
                        Get
                            Return Me.c_CostoVenta.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _ItemNotas() As String
                        Get
                            Return Me.c_ItemNotas.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _IdUnico() As String
                        Get
                            Return Me.c_IdUnico.c_Texto.Trim
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

                    ReadOnly Property _PLiquidaFullIva() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _PLiquida + (_PLiquida * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
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

                    ReadOnly Property _DsctoMonto() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = Me._PrecioNeto * Me._Descuento / 100
                            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                            Return x
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

                    ReadOnly Property _func_CantidadUnidadesInventarioDespachada() As Decimal
                        Get
                            Dim xcant As Decimal = 0
                            xcant = Me._CantidadDespachar * Me._ContenidoEmpaque
                            Return xcant
                        End Get
                    End Property

                    ReadOnly Property _func_Importe() As Decimal
                        Get
                            Dim ximport_1 As Decimal = 0
                            Dim xdesc As Decimal = 0
                            ximport_1 = Me._CantidadDespachar * Me._PrecioNeto
                            xdesc = ximport_1 * Me._Descuento / 100
                            Return Decimal.Round(ximport_1 - xdesc, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoItem = New CampoTexto(10, "autoitem")
                        Me.c_CantidadDespachar = New CampoDecimal("cantidad")
                        Me.c_CodigoProducto = New CampoTexto(15, "codigo")
                        Me.c_Descuento = New CampoDecimal("descuento")
                        Me.c_EsPesado = New CampoTexto(1, "espesado")
                        Me.c_NombreProducto = New CampoTexto(200, "producto")
                        Me.c_PrecioNeto = New CampoDecimal("precioneto")
                        Me.c_TasaIva = New CampoDecimal("tasaiva")
                        Me.c_AutoProducto = New CampoTexto(10, "autoproducto")
                        Me.c_BloquearExistencia = New CampoTexto(1, "bloquearexistencia")
                        Me.c_NombreEmpaque = New CampoTexto(20, "nombreempaque")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenidoempaque")
                        Me.c_ReferenciaEmpaque = New CampoTexto(1, "referenciaempaque")
                        Me.c_AutoMedida = New CampoTexto(10, "automedida")
                        Me.c_NumeroDecimalesMedida = New CampoTexto(1, "decimalesmedida")
                        Me.c_ForzarDecimalesMedida = New CampoTexto(1, "forzarmedida")
                        Me.c_TipoTasa = New CampoTexto(1, "tipotasa")
                        Me.c_AutoDeposito = New CampoTexto(10, "autodeposito")
                        Me.c_AutoUsuario = New CampoTexto(10, "autousuario")
                        Me.c_NombreUsuario = New CampoTexto(10, "nombreusuario")
                        Me.c_FechaProceso = New CampoFecha("fecha")
                        Me.c_EstacionEquipo = New CampoTexto(20, "estacion")
                        Me.c_TipoDocumento = New CampoTexto(1, "tipodocumento")
                        Me.c_PSugerido = New CampoDecimal("psugerido")
                        Me.c_PLiquida = New CampoDecimal("pliquida")
                        Me.c_CostoInventario = New CampoDecimal("costoinventario")
                        Me.c_CostoVenta = New CampoDecimal("costoventa")
                        Me.c_ItemNotas = New CampoTexto(160, "notasitem")
                        Me.c_IdUnico = New CampoTexto(60, "idunico")
                        Me.c_Importe = New CampoDecimal("importe")

                        ' Campos Nuevos
                        Me.c_AutoDocumento_Origen = New CampoTexto(10, "n_autodoc_origen")
                        Me.c_TipoDocumento_Origen = New CampoTexto(2, "n_tipodoc_origen")
                        Me.c_ProblemaDocumento_Origen = New CampoTexto(1, "n_problema_origen")
                        Me.c_AutoItem_Documento_Origen = New CampoTexto(10, "n_autoitem_doc_origen")
                        Me.c_RestringidoVenta = New CampoTexto(1, "n_RestringidoVenta")

                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_AutoDeposito.c_Texto = xrow(.c_AutoDeposito.c_NombreInterno)
                                .c_AutoItem.c_Texto = xrow(.c_AutoItem.c_NombreInterno)
                                .c_AutoMedida.c_Texto = xrow(.c_AutoMedida.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)
                                .c_BloquearExistencia.c_Texto = xrow(.c_BloquearExistencia.c_NombreInterno)
                                .c_CantidadDespachar.c_Valor = xrow(.c_CantidadDespachar.c_NombreInterno)
                                .c_CodigoProducto.c_Texto = xrow(.c_CodigoProducto.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_CostoInventario.c_Valor = xrow(.c_CostoInventario.c_NombreInterno)
                                .c_CostoVenta.c_Valor = xrow(.c_CostoVenta.c_NombreInterno)
                                .c_Descuento.c_Valor = xrow(.c_Descuento.c_NombreInterno)
                                .c_EsPesado.c_Texto = xrow(.c_EsPesado.c_NombreInterno)
                                .c_EstacionEquipo.c_Texto = xrow(.c_EstacionEquipo.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_ForzarDecimalesMedida.c_Texto = xrow(.c_ForzarDecimalesMedida.c_NombreInterno)
                                .c_ItemNotas.c_Texto = xrow(.c_ItemNotas.c_NombreInterno)
                                .c_NombreEmpaque.c_Texto = xrow(.c_NombreEmpaque.c_NombreInterno)
                                .c_NombreProducto.c_Texto = xrow(.c_NombreProducto.c_NombreInterno)
                                .c_NombreUsuario.c_Texto = xrow(.c_NombreUsuario.c_NombreInterno)
                                .c_NumeroDecimalesMedida.c_Texto = xrow(.c_NumeroDecimalesMedida.c_NombreInterno)
                                .c_PLiquida.c_Valor = xrow(.c_PLiquida.c_NombreInterno)
                                .c_PrecioNeto.c_Valor = xrow(.c_PrecioNeto.c_NombreInterno)
                                .c_PSugerido.c_Valor = xrow(.c_PSugerido.c_NombreInterno)
                                .c_ReferenciaEmpaque.c_Texto = xrow(.c_ReferenciaEmpaque.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TipoTasa.c_Texto = xrow(.c_TipoTasa.c_NombreInterno)
                                .c_IdUnico.c_Texto = xrow(.c_IdUnico.c_NombreInterno)
                                .c_Importe.c_Valor = xrow(.c_Importe.c_NombreInterno)

                                ' Campos Nuevos
                                If Not IsDBNull(xrow(.c_AutoDocumento_Origen.c_NombreInterno)) Then
                                    .c_AutoDocumento_Origen.c_Texto = xrow(.c_AutoDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_TipoDocumento_Origen.c_NombreInterno)) Then
                                    .c_TipoDocumento_Origen.c_Texto = xrow(.c_TipoDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_ProblemaDocumento_Origen.c_NombreInterno)) Then
                                    .c_ProblemaDocumento_Origen.c_Texto = xrow(.c_ProblemaDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoItem_Documento_Origen.c_NombreInterno)) Then
                                    .c_AutoItem_Documento_Origen.c_Texto = xrow(.c_AutoItem_Documento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_RestringidoVenta.c_NombreInterno)) Then
                                    .c_RestringidoVenta.c_Texto = xrow(.c_RestringidoVenta.c_NombreInterno)
                                End If

                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR DATA EN TEMPORAL VENTA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertRegistroTemporalVenta As String = "INSERT INTO TemporalVenta (" _
                 + "Codigo, " _
                 + "Producto, " _
                 + "Cantidad, " _
                 + "PrecioNeto, " _
                 + "Descuento, " _
                 + "TasaIva, " _
                 + "Importe, " _
                 + "EsPesado, " _
                 + "AutoItem, " _
                 + "AutoProducto, " _
                 + "BloquearExistencia, " _
                 + "NombreEmpaque, " _
                 + "ContenidoEmpaque, " _
                 + "ReferenciaEmpaque, " _
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
                 + "PLiquida, " _
                 + "CostoInventario, " _
                 + "CostoVenta, " _
                 + "NotasItem, " _
                 + "IdUnico, n_tipodoc_origen, n_autodoc_origen, n_problema_origen, n_autoitem_doc_origen, n_Restringidoventa) " _
                 + "VALUES (" _
                 + "@Codigo, " _
                 + "@Producto, " _
                 + "@Cantidad, " _
                 + "@PrecioNeto, " _
                 + "@Descuento, " _
                 + "@TasaIva, " _
                 + "@Importe, " _
                 + "@EsPesado, " _
                 + "@AutoItem," _
                 + "@AutoProducto, " _
                 + "@BloquearExistencia, " _
                 + "@NombreEmpaque, " _
                 + "@ContenidoEmpaque, " _
                 + "@ReferenciaEmpaque, " _
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
                 + "@PLiquida, " _
                 + "@CostoInventario, " _
                 + "@CostoVenta, " _
                 + "@NotasItem, " _
                 + "@IdUnico, @n_tipodoc_origen, @n_autodoc_origen, @n_problema_origen, @n_autoitem_doc_origen, @n_Restringidoventa) "

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

                ''' <summary>
                ''' Funcion: Agregar Registro A La Tabla
                ''' </summary>
                Function F_AgregarRegisto(ByVal xitem As c_AgregarRegistro, ByVal xcondiciones As Condiciones) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa=0"
                                        xcmd.ExecuteScalar()
                                    End If

                                    xcmd.CommandText = "update contadores set a_temporalventa=a_temporalventa+1;select a_temporalventa from contadores"
                                    xitem.RegistroNuevo.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    If xcondiciones._BloquearExistencia Then
                                        xitem.RegistroNuevo.c_BloquearExistencia.c_Texto = "1"

                                        Dim xdisponible As Decimal = 0
                                        Dim xcantidad As Decimal = xitem.RegistroNuevo._CantidadDespachar * xitem.RegistroNuevo._ContenidoEmpaque

                                        If xitem.RegistroNuevo._TipoDocumento = "4" Then
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select SUM(disponible) as disponible from productos_deposito where auto_producto=@auto_producto"
                                            xcmd.Parameters.AddWithValue("@auto_producto", xitem.RegistroNuevo._AutoProducto)
                                            xdisponible = xcmd.ExecuteScalar()
                                        Else
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select disponible from productos_deposito where auto_producto=@auto_producto and auto_deposito=@auto_deposito"
                                            xcmd.Parameters.AddWithValue("@auto_producto", xitem.RegistroNuevo._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xitem.RegistroNuevo._AutoDeposito)
                                            xdisponible = xcmd.ExecuteScalar()
                                        End If

                                        If xdisponible >= xcantidad Then  ' xitem.RegistroNuevo._TipoDocumento = "4" Or
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update productos_deposito set reservada=reservada+@cantidad, disponible=disponible-@cantidad " _
                                                                     + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito"
                                            xcmd.Parameters.AddWithValue("@cantidad", xcantidad)
                                            xcmd.Parameters.AddWithValue("@auto_producto", xitem.RegistroNuevo._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xitem.RegistroNuevo._AutoDeposito)
                                            xcmd.ExecuteNonQuery()
                                        Else
                                            Throw New Exception("Existencia No Disponible Para Facturar... Verifique Por Favor")
                                        End If
                                    Else
                                        xitem.RegistroNuevo.c_BloquearExistencia.c_Texto = "0"
                                    End If

                                    xcmd.CommandText = InsertRegistroTemporalVenta
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@codigo", xitem.RegistroNuevo.c_CodigoProducto.c_Texto).Size = xitem.RegistroNuevo.c_CodigoProducto.c_Largo
                                        .AddWithValue("@producto", xitem.RegistroNuevo.c_NombreProducto.c_Texto).Size = xitem.RegistroNuevo.c_NombreProducto.c_Largo
                                        .AddWithValue("@cantidad", xitem.RegistroNuevo.c_CantidadDespachar.c_Valor)
                                        .AddWithValue("@precioneto", xitem.RegistroNuevo.c_PrecioNeto.c_Valor)
                                        .AddWithValue("@descuento", xitem.RegistroNuevo.c_Descuento.c_Valor)
                                        .AddWithValue("@tasaiva", xitem.RegistroNuevo.c_TasaIva.c_Valor)
                                        .AddWithValue("@importe", xitem.RegistroNuevo._Importe)
                                        .AddWithValue("@espesado", xitem.RegistroNuevo.c_EsPesado.c_Texto).Size = xitem.RegistroNuevo.c_EsPesado.c_Largo
                                        .AddWithValue("@autoitem", xitem.RegistroNuevo.c_AutoItem.c_Texto).Size = xitem.RegistroNuevo.c_AutoItem.c_Largo
                                        .AddWithValue("@autoproducto", xitem.RegistroNuevo._AutoProducto).Size = xitem.RegistroNuevo.c_CodigoProducto.c_Largo
                                        .AddWithValue("@bloquearexistencia", xitem.RegistroNuevo.c_BloquearExistencia.c_Texto).Size = xitem.RegistroNuevo.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombreempaque", xitem.RegistroNuevo.c_NombreEmpaque.c_Texto).Size = xitem.RegistroNuevo.c_NombreEmpaque.c_Largo
                                        .AddWithValue("@contenidoempaque", xitem.RegistroNuevo.c_ContenidoEmpaque.c_Valor)
                                        .AddWithValue("@referenciaempaque", xitem.RegistroNuevo.c_ReferenciaEmpaque.c_Texto).Size = xitem.RegistroNuevo.c_ReferenciaEmpaque.c_Largo
                                        .AddWithValue("@automedida", xitem.RegistroNuevo.c_AutoMedida.c_Texto).Size = xitem.RegistroNuevo.c_AutoMedida.c_Largo
                                        .AddWithValue("@decimalesmedida", xitem.RegistroNuevo.c_NumeroDecimalesMedida.c_Texto).Size = xitem.RegistroNuevo.c_NumeroDecimalesMedida.c_Largo
                                        .AddWithValue("@forzarmedida", xitem.RegistroNuevo.c_ForzarDecimalesMedida.c_Texto).Size = xitem.RegistroNuevo.c_ForzarDecimalesMedida.c_Largo
                                        .AddWithValue("@tipotasa", xitem.RegistroNuevo.c_TipoTasa.c_Texto).Size = xitem.RegistroNuevo.c_TipoTasa.c_Largo
                                        .AddWithValue("@autodeposito", xitem.RegistroNuevo.c_AutoDeposito.c_Texto).Size = xitem.RegistroNuevo.c_AutoDeposito.c_Largo
                                        .AddWithValue("@autousuario", xitem.RegistroNuevo.c_AutoUsuario.c_Texto).Size = xitem.RegistroNuevo.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombreusuario", xitem.RegistroNuevo.c_NombreUsuario.c_Texto).Size = xitem.RegistroNuevo.c_NombreUsuario.c_Largo
                                        .AddWithValue("@fecha", xitem.RegistroNuevo.c_FechaProceso.c_Valor)
                                        .AddWithValue("@estacion", xitem.RegistroNuevo.c_EstacionEquipo.c_Texto).Size = xitem.RegistroNuevo.c_EstacionEquipo.c_Largo
                                        .AddWithValue("@tipodocumento", xitem.RegistroNuevo.c_TipoDocumento.c_Texto).Size = xitem.RegistroNuevo.c_TipoDocumento.c_Largo
                                        .AddWithValue("@psugerido", xitem.RegistroNuevo.c_PSugerido.c_Valor)
                                        .AddWithValue("@pliquida", xitem.RegistroNuevo._PLiquida)
                                        .AddWithValue("@costoinventario", xitem.RegistroNuevo.c_CostoInventario.c_Valor)
                                        .AddWithValue("@costoventa", xitem.RegistroNuevo.c_CostoVenta.c_Valor)
                                        .AddWithValue("@notasitem", xitem.RegistroNuevo.c_ItemNotas.c_Texto).Size = xitem.RegistroNuevo.c_ItemNotas.c_Largo
                                        .AddWithValue("@idunico", xitem.RegistroNuevo.c_IdUnico.c_Texto).Size = xitem.RegistroNuevo.c_IdUnico.c_Largo

                                        ' Campos Nuevos
                                        .AddWithValue("@n_autodoc_origen", xitem.RegistroNuevo.c_AutoDocumento_Origen.c_Texto).Size = xitem.RegistroNuevo.c_AutoDocumento_Origen.c_Largo
                                        .AddWithValue("@n_tipodoc_origen", xitem.RegistroNuevo.c_TipoDocumento_Origen.c_Texto).Size = xitem.RegistroNuevo.c_TipoDocumento_Origen.c_Largo
                                        .AddWithValue("@n_problema_origen", xitem.RegistroNuevo.c_ProblemaDocumento_Origen.c_Texto).Size = xitem.RegistroNuevo.c_ProblemaDocumento_Origen.c_Largo
                                        .AddWithValue("@n_autoitem_doc_origen", xitem.RegistroNuevo.c_AutoItem_Documento_Origen.c_Texto).Size = xitem.RegistroNuevo.c_AutoItem_Documento_Origen.c_Largo
                                        .AddWithValue("@n_RestringidoVenta", xitem.RegistroNuevo.c_RestringidoVenta.c_Texto).Size = xitem.RegistroNuevo.c_RestringidoVenta.c_Largo
                                    End With
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
                        Throw New Exception("PROBLEMA AL AGREGAR REGISTRO A TEMPORAL VENTA:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarTodo(ByVal xidunico As String, ByVal xauto_usuario As String, ByVal xtipodoc As TipoDocumentoVenta) As Boolean
                    Try
                        Dim xtipo As Integer = [Enum].Parse(GetType(TipoDocumentoVenta), xtipodoc)
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xtb As New DataTable
                                    Dim xreader As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select autoitem from temporalventa where idunico=@idunico and autousuario=@autousuario and tipodocumento=@tipodocumento"
                                    xcmd.Parameters.AddWithValue("@idunico", xidunico)
                                    xcmd.Parameters.AddWithValue("@autousuario", xauto_usuario)
                                    xcmd.Parameters.AddWithValue("@tipodocumento", xtipo.ToString)
                                    xreader = xcmd.ExecuteReader()
                                    xtb.Load(xreader)

                                    For Each xr As DataRow In xtb.Rows
                                        xcmd.CommandText = "update productos_deposito set disponible=disponible+(t.cantidad*t.contenidoempaque), " _
                                            + "reservada=reservada-(t.cantidad*t.contenidoempaque) " _
                                            + "from productos_deposito dp join temporalventa t on dp.auto_producto=t.autoproducto and dp.auto_deposito=t.autodeposito " _
                                            + "where t.bloquearexistencia='1' and t.idunico=@idunico and t.autousuario=@autousuario and tipodocumento=@tipodocumento " & _
                                              " and autoitem=@autoitem"
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@idunico", xidunico)
                                        xcmd.Parameters.AddWithValue("@autousuario", xauto_usuario)
                                        xcmd.Parameters.AddWithValue("@tipodocumento", xtipo.ToString)
                                        xcmd.Parameters.AddWithValue("@autoitem", xr(0).ToString)
                                        xcmd.ExecuteNonQuery()

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete from temporalventa where idunico=@idunico and autousuario=@autousuario and tipodocumento=@tipodocumento " & _
                                                                " and autoitem=@autoitem"
                                        xcmd.Parameters.AddWithValue("@idunico", xidunico)
                                        xcmd.Parameters.AddWithValue("@autousuario", xauto_usuario)
                                        xcmd.Parameters.AddWithValue("@tipodocumento", xtipo.ToString)
                                        xcmd.Parameters.AddWithValue("@autoitem", xr(0).ToString)
                                        xcmd.ExecuteNonQuery()
                                    Next
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
                        Throw New Exception("PROBLEMA AL ELIMINAR TODOS LOS REGISTROS EN TEMPORAL VENTA" + vbCrLf + ex.Message)
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
                                    xcmd.CommandText = "update productos_deposito set disponible=disponible+(t.cantidad*t.contenidoempaque), " _
                                        + "reservada=reservada-(t.cantidad*t.contenidoempaque) " _
                                        + "from productos_deposito dp join temporalventa t on dp.auto_producto=t.autoproducto and dp.auto_deposito=t.autodeposito " _
                                        + "where t.bloquearexistencia='1' and t.autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto)
                                    xcmd.CommandText = "delete from temporalventa where autoitem=@autoitem"
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
                        Throw New Exception("PROBLEMA AL ELIMINAR REGISTRO EN TEMPORAL VENTA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarItem_Notas(ByVal xauto As String, ByVal xnotas As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update temporalventa set notasitem=@notasitem where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto)
                                    xcmd.Parameters.AddWithValue("@notasitem", xnotas).Size = Me.RegistroDato.c_ItemNotas.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent ActualizarTabla()
                                Return True
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL ACTUALIZAR NOTAS/DETALLE DEL ITEM EN TEMPORAL VENTA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from temporalventa where autoitem=@autoitem"
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
                        Throw New Exception("PROBLEMA AL ENCONTRAR REGISTRO TEMPORAL VENTA" + vbCrLf + ex.Message)
                    End Try
                End Function


                Class ActualizarRegistroTemporalVenta
                    Private xitem As FichaVentas.V_TemporalVenta.c_Registro
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xcantidad As Decimal
                    Private xprecioneto As Decimal
                    Private xdescuento As Decimal
                    Private xequipo As String
                    Private xidunico As String

                    Property _FichaItemDetalleActualizar() As FichaVentas.V_TemporalVenta.c_Registro
                        Protected Friend Get
                            Return Me.xitem
                        End Get
                        Set(ByVal value As FichaVentas.V_TemporalVenta.c_Registro)
                            Me.xitem = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return Me.xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xusuario = value
                        End Set
                    End Property

                    Property _Cantidad() As Decimal
                        Protected Friend Get
                            Return Me.xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcantidad = value
                        End Set
                    End Property

                    Property _PrecioNeto() As Decimal
                        Protected Friend Get
                            Return Me.xprecioneto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xprecioneto = value
                        End Set
                    End Property

                    Property _Descuento() As Decimal
                        Protected Friend Get
                            Return Me.xdescuento
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xdescuento = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return Me.xequipo.Trim()
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _IdUnico() As String
                        Protected Friend Get
                            Return Me.xidunico.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xidunico = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaProceso() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Sub New()
                        Me._Cantidad = 0
                        Me._Descuento = 0
                        Me._EquipoEstacion = ""
                        Me._FichaItemDetalleActualizar = Nothing
                        Me._FichaUsuario = Nothing
                        Me._IdUnico = ""
                        Me._PrecioNeto = 0
                    End Sub
                End Class

                Function F_ActualizarRegistro(ByVal xRegActualiza As ActualizarRegistroTemporalVenta) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Dim xregistro As New FichaVentas.V_TemporalVenta.c_Registro
                                With xregistro
                                    .c_AutoDeposito.c_Texto = xRegActualiza._FichaItemDetalleActualizar._AutoDeposito
                                    .c_AutoDocumento_Origen.c_Texto = xRegActualiza._FichaItemDetalleActualizar._AutoDocumentoOrigen
                                    .c_AutoItem.c_Texto = ""
                                    .c_AutoItem_Documento_Origen.c_Texto = xRegActualiza._FichaItemDetalleActualizar._AutoItem_DocumentoOrigen
                                    .c_AutoMedida.c_Texto = xRegActualiza._FichaItemDetalleActualizar._AutoMedida
                                    .c_AutoProducto.c_Texto = xRegActualiza._FichaItemDetalleActualizar._AutoProducto
                                    .c_AutoUsuario.c_Texto = xRegActualiza._FichaUsuario._AutoUsuario
                                    .c_BloquearExistencia.c_Texto = xRegActualiza._FichaItemDetalleActualizar.c_BloquearExistencia.c_Texto
                                    .c_CantidadDespachar.c_Valor = xRegActualiza._Cantidad
                                    .c_CodigoProducto.c_Texto = xRegActualiza._FichaItemDetalleActualizar._CodigoProducto
                                    .c_ContenidoEmpaque.c_Valor = xRegActualiza._FichaItemDetalleActualizar._ContenidoEmpaque
                                    .c_CostoInventario.c_Valor = xRegActualiza._FichaItemDetalleActualizar._CostoInventario
                                    .c_CostoVenta.c_Valor = xRegActualiza._FichaItemDetalleActualizar._CostoVenta
                                    .c_Descuento.c_Valor = xRegActualiza._Descuento
                                    .c_EsPesado.c_Texto = xRegActualiza._FichaItemDetalleActualizar.c_EsPesado.c_Texto
                                    .c_EstacionEquipo.c_Texto = xRegActualiza._EquipoEstacion
                                    .c_FechaProceso.c_Valor = xRegActualiza._FechaProceso
                                    .c_ForzarDecimalesMedida.c_Texto = xRegActualiza._FichaItemDetalleActualizar.c_ForzarDecimalesMedida.c_Texto
                                    .c_IdUnico.c_Texto = xRegActualiza._IdUnico
                                    .c_ItemNotas.c_Texto = xRegActualiza._FichaItemDetalleActualizar._ItemNotas
                                    .c_NombreEmpaque.c_Texto = xRegActualiza._FichaItemDetalleActualizar._NombreEmpaque
                                    .c_NombreProducto.c_Texto = xRegActualiza._FichaItemDetalleActualizar._NombreProducto
                                    .c_NombreUsuario.c_Texto = xRegActualiza._FichaUsuario._NombreUsuario
                                    .c_NumeroDecimalesMedida.c_Texto = xRegActualiza._FichaItemDetalleActualizar._NumeroDecimalesMedida
                                    .c_PrecioNeto.c_Valor = xRegActualiza._PrecioNeto
                                    .c_ProblemaDocumento_Origen.c_Texto = IIf(xRegActualiza._FichaItemDetalleActualizar._ProblemaDocumentoOrigen, "1", "0")
                                    .c_PSugerido.c_Valor = xRegActualiza._FichaItemDetalleActualizar._PSugerido
                                    .c_ReferenciaEmpaque.c_Texto = xRegActualiza._FichaItemDetalleActualizar._ReferenciaEmpaque
                                    .c_TasaIva.c_Valor = xRegActualiza._FichaItemDetalleActualizar._TasaIva
                                    .c_TipoDocumento.c_Texto = xRegActualiza._FichaItemDetalleActualizar._TipoDocumento
                                    .c_TipoDocumento_Origen.c_Texto = xRegActualiza._FichaItemDetalleActualizar.c_TipoDocumento_Origen.c_Texto
                                    .c_TipoTasa.c_Texto = xRegActualiza._FichaItemDetalleActualizar._TipoTasa
                                    .c_Importe.c_Valor = xregistro._func_Importe
                                    .c_PLiquida.c_Valor = xregistro._PLiquida
                                End With

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    ' Elimino Registro Viejo
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update productos_deposito set disponible=disponible+(t.cantidad*t.contenidoempaque), " _
                                        + "reservada=reservada-(t.cantidad*t.contenidoempaque) " _
                                        + "from productos_deposito dp join temporalventa t on dp.auto_producto=t.autoproducto and dp.auto_deposito=t.autodeposito " _
                                        + "where t.bloquearexistencia='1' and t.autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xRegActualiza._FichaItemDetalleActualizar._AutoItem)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@autoitem", xRegActualiza._FichaItemDetalleActualizar._AutoItem)
                                    xcmd.CommandText = "delete from temporalventa where autoitem=@autoitem"
                                    xcmd.ExecuteNonQuery()

                                    xcmd.CommandText = "select a_temporalventa from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_temporalventa=a_temporalventa+1;select a_temporalventa from contadores"
                                    xregistro.c_AutoItem.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    If xRegActualiza._FichaItemDetalleActualizar._BloquearExistencia Then
                                        Dim xdisponible As Decimal = 0
                                        Dim xcantidad As Decimal = xregistro._func_CantidadUnidadesInventarioDespachada

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select disponible from productos_deposito where auto_producto=@auto_producto and auto_deposito=@auto_deposito"
                                        xcmd.Parameters.AddWithValue("@auto_producto", xregistro._AutoProducto)
                                        xcmd.Parameters.AddWithValue("@auto_deposito", xregistro._AutoDeposito)
                                        xdisponible = xcmd.ExecuteScalar()

                                        If xdisponible >= xcantidad Then
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update productos_deposito set reservada=reservada+@cantidad, disponible=disponible-@cantidad " _
                                                                     + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito"
                                            xcmd.Parameters.AddWithValue("@cantidad", xcantidad)
                                            xcmd.Parameters.AddWithValue("@auto_producto", xregistro._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@auto_deposito", xregistro._AutoDeposito)
                                            xcmd.ExecuteNonQuery()
                                        Else
                                            Throw New Exception("Existencia No Disponible Para Facturar... Verifique Por Favor")
                                        End If
                                    End If

                                    xcmd.CommandText = InsertRegistroTemporalVenta
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@codigo", xregistro.c_CodigoProducto.c_Texto).Size = xregistro.c_CodigoProducto.c_Largo
                                        .AddWithValue("@producto", xregistro.c_NombreProducto.c_Texto).Size = xregistro.c_NombreProducto.c_Largo
                                        .AddWithValue("@cantidad", xregistro.c_CantidadDespachar.c_Valor)
                                        .AddWithValue("@precioneto", xregistro.c_PrecioNeto.c_Valor)
                                        .AddWithValue("@descuento", xregistro.c_Descuento.c_Valor)
                                        .AddWithValue("@tasaiva", xregistro.c_TasaIva.c_Valor)
                                        .AddWithValue("@importe", xregistro._Importe)
                                        .AddWithValue("@espesado", xregistro.c_EsPesado.c_Texto).Size = xregistro.c_EsPesado.c_Largo
                                        .AddWithValue("@autoitem", xregistro.c_AutoItem.c_Texto).Size = xregistro.c_AutoItem.c_Largo
                                        .AddWithValue("@autoproducto", xregistro._AutoProducto).Size = xregistro.c_CodigoProducto.c_Largo
                                        .AddWithValue("@bloquearexistencia", xregistro.c_BloquearExistencia.c_Texto).Size = xregistro.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombreempaque", xregistro.c_NombreEmpaque.c_Texto).Size = xregistro.c_NombreEmpaque.c_Largo
                                        .AddWithValue("@contenidoempaque", xregistro.c_ContenidoEmpaque.c_Valor)
                                        .AddWithValue("@referenciaempaque", xregistro.c_ReferenciaEmpaque.c_Texto).Size = xregistro.c_ReferenciaEmpaque.c_Largo
                                        .AddWithValue("@automedida", xregistro.c_AutoMedida.c_Texto).Size = xregistro.c_AutoMedida.c_Largo
                                        .AddWithValue("@decimalesmedida", xregistro.c_NumeroDecimalesMedida.c_Texto).Size = xregistro.c_NumeroDecimalesMedida.c_Largo
                                        .AddWithValue("@forzarmedida", xregistro.c_ForzarDecimalesMedida.c_Texto).Size = xregistro.c_ForzarDecimalesMedida.c_Largo
                                        .AddWithValue("@tipotasa", xregistro.c_TipoTasa.c_Texto).Size = xregistro.c_TipoTasa.c_Largo
                                        .AddWithValue("@autodeposito", xregistro.c_AutoDeposito.c_Texto).Size = xregistro.c_AutoDeposito.c_Largo
                                        .AddWithValue("@autousuario", xregistro.c_AutoUsuario.c_Texto).Size = xregistro.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombreusuario", xregistro.c_NombreUsuario.c_Texto).Size = xregistro.c_NombreUsuario.c_Largo
                                        .AddWithValue("@fecha", xregistro.c_FechaProceso.c_Valor)
                                        .AddWithValue("@estacion", xregistro.c_EstacionEquipo.c_Texto).Size = xregistro.c_EstacionEquipo.c_Largo
                                        .AddWithValue("@tipodocumento", xregistro.c_TipoDocumento.c_Texto).Size = xregistro.c_TipoDocumento.c_Largo
                                        .AddWithValue("@psugerido", xregistro.c_PSugerido.c_Valor)
                                        .AddWithValue("@pliquida", xregistro._PLiquida)
                                        .AddWithValue("@costoinventario", xregistro.c_CostoInventario.c_Valor)
                                        .AddWithValue("@costoventa", xregistro.c_CostoVenta.c_Valor)
                                        .AddWithValue("@notasitem", xregistro.c_ItemNotas.c_Texto).Size = xregistro.c_ItemNotas.c_Largo
                                        .AddWithValue("@idunico", xregistro.c_IdUnico.c_Texto).Size = xregistro.c_IdUnico.c_Largo
                                        ' Campos Nuevos
                                        .AddWithValue("@n_autodoc_origen", xregistro.c_AutoDocumento_Origen.c_Texto).Size = xregistro.c_AutoDocumento_Origen.c_Largo
                                        .AddWithValue("@n_tipodoc_origen", xregistro.c_TipoDocumento_Origen.c_Texto).Size = xregistro.c_TipoDocumento_Origen.c_Largo
                                        .AddWithValue("@n_problema_origen", xregistro.c_ProblemaDocumento_Origen.c_Texto).Size = xregistro.c_ProblemaDocumento_Origen.c_Largo
                                        .AddWithValue("@n_autoitem_doc_origen", xregistro.c_AutoItem_Documento_Origen.c_Texto).Size = xregistro.c_AutoItem_Documento_Origen.c_Largo
                                        .AddWithValue("@n_RestringidoVenta", xregistro.c_RestringidoVenta.c_Texto).Size = xregistro.c_RestringidoVenta.c_Largo
                                    End With
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
                        Throw New Exception("PROBLEMA AL ACTUALIZAR ITEM TABLA TEMPORAL VENTA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarDescripcionItem(ByVal xauto_registro As String, ByVal xdescripcion As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update temporalventa set producto=@producto where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xauto_registro)
                                    xcmd.Parameters.AddWithValue("@producto", xdescripcion)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL QUERER ACTUALIZAR DESCRIPCION DEL ITEM")
                                    End If
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
                        Throw New Exception("ACTUALIZAR DESCRIPCION DEL ITEM" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Class V_TemporalVentaPendiente
                Event ActualizarTabla()
                Event _ActualizarFichaCliente(ByVal xauto_cliente As String)

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
                    Private xautocliente As CampoTexto
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

                    ReadOnly Property _TipoDocumento() As TipoDocumentoVenta
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim
                                Case "1"
                                    Return TipoDocumentoVenta.Factura
                                Case "2"
                                    Return TipoDocumentoVenta.NotaEntrega
                                Case "3"
                                    Return TipoDocumentoVenta.Presupuesto
                                Case "4"
                                    Return TipoDocumentoVenta.Pedido
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

                    Protected Friend Property c_AutoCliente() As CampoTexto
                        Get
                            Return xautocliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            xautocliente = value
                        End Set
                    End Property

                    ReadOnly Property _AutomaticoCliente() As String
                        Get
                            Return Me.c_AutoCliente.c_Texto.Trim
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
                        Me.c_AutoCliente = New CampoTexto(10, "auto_cliente")
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

                                .c_AutoCliente.c_Texto = xrow(.c_AutoCliente.c_NombreInterno)
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
                            Throw New Exception("VENTAS" + vbCrLf + "TEMPORAL VENTA PENDIENTE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarCargar(ByVal xAutoMovimiento As String) As Boolean
                    Try
                        Dim xp1 As New SqlParameter("@auto", xAutoMovimiento)
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from temporalventa_pendiente where auto_doc=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Add(xp1)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count >= 1 Then
                            M_CargarRegistro(xtb.Rows(0))
                            Return True
                        End If
                    Catch ex As Exception
                        Throw New Exception("DOCUMENTO PENDIENTE:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Const InsertRegistro_TemporalVentaPendiente As String = "INSERT INTO TemporalVenta_Pendiente (" _
                 + "auto_doc, " _
                 + "fecha_doc, " _
                 + "hora_doc, " _
                 + "monto_doc, " _
                 + "items_doc, " _
                 + "tipo_doc, " _
                 + "auto_usuario, " _
                 + "nombre_usuario, " _
                 + "equipoestacion, " _
                 + "auto_cliente, " _
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
                 + "@auto_cliente, " _
                 + "@nombre_pendiente) "

                Const InsertRegistro_TemporalVentaPendienteDetalle As String = "INSERT INTO TemporalVenta_PendienteDetalle (" _
                 + "Auto_Doc, " _
                 + "Codigo, " _
                 + "Producto, " _
                 + "Cantidad, " _
                 + "PrecioNeto, " _
                 + "Descuento, " _
                 + "TasaIva, " _
                 + "Importe, " _
                 + "EsPesado, " _
                 + "AutoItem, " _
                 + "AutoProducto, " _
                 + "BloquearExistencia, " _
                 + "NombreEmpaque, " _
                 + "ContenidoEmpaque, " _
                 + "ReferenciaEmpaque, " _
                 + "AutoMedida, " _
                 + "DecimalesMedida, " _
                 + "ForzarMedida, " _
                 + "TipoTasa, " _
                 + "AutoDeposito, " _
                 + "PSugerido, " _
                 + "PLiquida, " _
                 + "CostoInventario, " _
                 + "CostoVenta, " _
                 + "NotasItem, " _
                 + "n_tipodoc_origen, n_autodoc_origen, n_problema_origen, n_autoitem_doc_origen, n_RestringidoVenta) " _
                 + "VALUES (" _
                 + "@Auto_Doc, " _
                 + "@Codigo, " _
                 + "@Producto, " _
                 + "@Cantidad, " _
                 + "@PrecioNeto, " _
                 + "@Descuento, " _
                 + "@TasaIva, " _
                 + "@Importe, " _
                 + "@EsPesado, " _
                 + "@AutoItem," _
                 + "@AutoProducto, " _
                 + "@BloquearExistencia, " _
                 + "@NombreEmpaque, " _
                 + "@ContenidoEmpaque, " _
                 + "@ReferenciaEmpaque, " _
                 + "@AutoMedida, " _
                 + "@DecimalesMedida, " _
                 + "@ForzarMedida, " _
                 + "@TipoTasa, " _
                 + "@AutoDeposito, " _
                 + "@PSugerido, " _
                 + "@PLiquida, " _
                 + "@CostoInventario, " _
                 + "@CostoVenta, " _
                 + "@NotasItem, " _
                 + "@n_tipodoc_origen, @n_autodoc_origen, @n_problema_origen, @n_autoitem_doc_origen, @n_RestringidoVenta) "


                Class RegistroTemporalPendiente
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xcliente As FichaClientes.c_Clientes.c_Registro
                    Private xequipo As String
                    Private xpendiente As String
                    Private xtipodoc As TipoDocumentoVenta
                    Private xidunico As String
                    Private xlista_items As List(Of FichaVentas.V_TemporalVenta.c_Registro)

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xcliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xcliente = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return Me.xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xusuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return Me.xequipo.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _NombreCtaPendiente() As String
                        Protected Friend Get
                            Return Me.xpendiente.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xpendiente = value
                        End Set
                    End Property

                    Property _TipoDocumentoPendiente() As TipoDocumentoVenta
                        Protected Friend Get
                            Return Me.xtipodoc
                        End Get
                        Set(ByVal value As TipoDocumentoVenta)
                            Me.xtipodoc = value
                        End Set
                    End Property

                    Protected Friend Property _IdUnico() As String
                        Get
                            Return Me.xidunico.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xidunico = value
                        End Set
                    End Property

                    Property _ListaItems() As List(Of FichaVentas.V_TemporalVenta.c_Registro)
                        Get
                            Return Me.xlista_items
                        End Get
                        Set(ByVal value As List(Of FichaVentas.V_TemporalVenta.c_Registro))
                            Me.xlista_items = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaProceso() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _HoraProceso() As String
                        Get
                            Return F_GetDate("select getdate()").Date.ToShortTimeString
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _MontoCtaPendiente() As Decimal
                        Get
                            Dim xres = (From x In _ListaItems Select (x._Importe)).Sum
                            Return xres
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _ItemsCtaPendiente() As Integer
                        Get
                            Return Me._ListaItems.Count
                        End Get
                    End Property

                    Sub New()
                        Me._EquipoEstacion = ""
                        Me._FichaCliente = Nothing
                        Me._FichaUsuario = Nothing
                        Me._NombreCtaPendiente = ""
                        Me._TipoDocumentoPendiente = 0
                        Me._IdUnico = ""
                        Me._ListaItems = Nothing
                    End Sub
                End Class

                Function F_DejarCta_Pendiente(BYVAL xRegistroPendiente As RegistroTemporalPendiente) As Boolean
                    Dim xtr As SqlTransaction
                    Try
                        Dim xreg As New FichaVentas.V_TemporalVentaPendiente.c_Registro
                        With xreg
                            .c_AutoCliente.c_Texto = xRegistroPendiente._FichaCliente.r_Automatico
                            .c_AutoMovimiento.c_Texto = ""
                            .c_AutoUsuario.c_Texto = xRegistroPendiente._FichaUsuario._AutoUsuario
                            .c_EquipoEstacion.c_Texto = xRegistroPendiente._EquipoEstacion
                            .c_FechaMovimiento.c_Valor = xRegistroPendiente._FechaProceso
                            .c_HoraMovimiento.c_Texto = xRegistroPendiente._HoraProceso
                            .c_ItemsCtaPendiente.c_Valor = xRegistroPendiente._ItemsCtaPendiente
                            .c_MontoCtaPendiente.c_Valor = xRegistroPendiente._MontoCtaPendiente
                            .c_NombreCtaPendiente.c_Texto = xRegistroPendiente._NombreCtaPendiente
                            .c_NombreUsuario.c_Texto = xRegistroPendiente._FichaUsuario._NombreUsuario
                            Select Case xRegistroPendiente._TipoDocumentoPendiente
                                Case TipoDocumentoVenta.Factura : .c_TipoDocumento.c_Texto = "1"
                                Case TipoDocumentoVenta.NotaEntrega : .c_TipoDocumento.c_Texto = "2"
                                Case TipoDocumentoVenta.Presupuesto : .c_TipoDocumento.c_Texto = "3"
                                Case TipoDocumentoVenta.Pedido : .c_TipoDocumento.c_Texto = "4"
                            End Select
                        End With

                        Dim xmontototal As Decimal = 0
                        Dim xlista As New List(Of FichaVentas.V_TemporalVentaPendienteDetalle.c_Registro)
                        For Each xr In xRegistroPendiente._ListaItems
                            Dim xdt As New FichaVentas.V_TemporalVentaPendienteDetalle.c_Registro
                            With xdt
                                .c_AutoDeposito.c_Texto = xr._AutoDeposito
                                .c_AutoDoc.c_Texto = ""
                                .c_AutoDocumento_Origen.c_Texto = xr._AutoDocumentoOrigen
                                .c_AutoItem.c_Texto = ""
                                .c_AutoItem_DocumentoOrigen.c_Texto = xr._AutoItem_DocumentoOrigen
                                .c_AutoMedida.c_Texto = xr._AutoMedida
                                .c_AutoProducto.c_Texto = xr._AutoProducto
                                .c_BloquearExistencia.c_Texto = xr.c_BloquearExistencia.c_Texto
                                .c_CantidadDespachar.c_Valor = xr._CantidadDespachar
                                .c_CodigoProducto.c_Texto = xr._CodigoProducto
                                .c_ContenidoEmpaque.c_Valor = xr._ContenidoEmpaque
                                .c_CostoInventario.c_Valor = xr._CostoInventario
                                .c_CostoVenta.c_Valor = xr._CostoVenta
                                .c_Descuento.c_Valor = xr._Descuento
                                .c_EsPesado.c_Texto = xr.c_EsPesado.c_Texto
                                .c_ForzarDecimalesMedida.c_Texto = xr.c_ForzarDecimalesMedida.c_Texto
                                .c_ItemNotas.c_Texto = xr._ItemNotas
                                .c_Importe.c_Valor = xr._Importe
                                .c_NombreEmpaque.c_Texto = xr._NombreEmpaque
                                .c_NombreProducto.c_Texto = xr._NombreProducto
                                .c_NumeroDecimalesMedida.c_Texto = xr._NumeroDecimalesMedida
                                .c_PrecioNeto.c_Valor = xr._PrecioNeto
                                .c_PLiquida.c_Valor = xr._PLiquida
                                .c_ProblemaDocumento_Origen.c_Texto = xr.c_ProblemaDocumento_Origen.c_Texto
                                .c_PSugerido.c_Valor = xr._PSugerido
                                .c_ReferenciaEmpaque.c_Texto = xr._ReferenciaEmpaque
                                .c_TasaIva.c_Valor = xr._TasaIva
                                .c_TipoDocumento_Origen.c_Texto = xr.c_TipoDocumento_Origen.c_Texto
                                .c_TipoTasa.c_Texto = xr._TipoTasa
                                .c_RestringidoVenta.c_Texto = IIf(xr._RestringidoVenta = TipoSiNo.Si, "1", "")
                            End With
                            xmontototal += xdt._Total
                            xlista.Add(xdt)
                        Next

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_temporalventa_pendiente from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_temporalventa_pendiente=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_temporalventa_pendiente=a_temporalventa_pendiente+1; " _
                                        + "select a_temporalventa_pendiente from contadores"
                                    xreg.c_AutoMovimiento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertRegistro_TemporalVentaPendiente
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto_doc", xreg.c_AutoMovimiento.c_Texto).Size = xreg.c_AutoMovimiento.c_Largo
                                        .AddWithValue("@fecha_doc", xreg.c_FechaMovimiento.c_Valor)
                                        .AddWithValue("@hora_doc", xreg.c_HoraMovimiento.c_Texto).Size = xreg.c_HoraMovimiento.c_Largo
                                        .AddWithValue("@monto_doc", xmontototal)
                                        .AddWithValue("@items_doc", xreg.c_ItemsCtaPendiente.c_Valor)
                                        .AddWithValue("@tipo_doc", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                        .AddWithValue("@auto_usuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                        .AddWithValue("@nombre_usuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                        .AddWithValue("@equipoestacion", xreg.c_EquipoEstacion.c_Texto).Size = xreg.c_EquipoEstacion.c_Largo
                                        .AddWithValue("@auto_cliente", xreg.c_AutoCliente.c_Texto).Size = xreg.c_AutoCliente.c_Largo
                                        .AddWithValue("@nombre_pendiente", xreg.c_NombreCtaPendiente.c_Texto).Size = xreg.c_NombreCtaPendiente.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    Dim xitem As Integer = 0
                                    For Each xdet As V_TemporalVentaPendienteDetalle.c_Registro In xlista
                                        xitem += 1
                                        xdet.c_AutoDoc.c_Texto = xreg._AutoMovimiento
                                        xdet.c_AutoItem.c_Texto = xitem.ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = InsertRegistro_TemporalVentaPendienteDetalle
                                        With xcmd.Parameters
                                            .AddWithValue("@auto_doc", xdet.c_AutoDoc.c_Texto).Size = xdet.c_AutoDoc.c_Largo
                                            .AddWithValue("@codigo", xdet.c_CodigoProducto.c_Texto).Size = xdet.c_CodigoProducto.c_Largo
                                            .AddWithValue("@producto", xdet.c_NombreProducto.c_Texto).Size = xdet.c_NombreProducto.c_Largo
                                            .AddWithValue("@cantidad", xdet.c_CantidadDespachar.c_Valor)
                                            .AddWithValue("@precioneto", xdet.c_PrecioNeto.c_Valor)
                                            .AddWithValue("@descuento", xdet.c_Descuento.c_Valor)
                                            .AddWithValue("@tasaiva", xdet.c_TasaIva.c_Valor)
                                            .AddWithValue("@importe", xdet._Importe)
                                            .AddWithValue("@espesado", xdet.c_EsPesado.c_Texto).Size = xdet.c_EsPesado.c_Largo
                                            .AddWithValue("@autoitem", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                            .AddWithValue("@autoproducto", xdet._AutoProducto).Size = xdet.c_AutoProducto.c_Largo
                                            .AddWithValue("@bloquearexistencia", xdet.c_BloquearExistencia.c_Texto).Size = xdet.c_BloquearExistencia.c_Largo
                                            .AddWithValue("@nombreempaque", xdet.c_NombreEmpaque.c_Texto).Size = xdet.c_NombreEmpaque.c_Largo
                                            .AddWithValue("@contenidoempaque", xdet.c_ContenidoEmpaque.c_Valor)
                                            .AddWithValue("@referenciaempaque", xdet.c_ReferenciaEmpaque.c_Texto).Size = xdet.c_ReferenciaEmpaque.c_Largo
                                            .AddWithValue("@automedida", xdet.c_AutoMedida.c_Texto).Size = xdet.c_AutoMedida.c_Largo
                                            .AddWithValue("@decimalesmedida", xdet.c_NumeroDecimalesMedida.c_Texto).Size = xdet.c_NumeroDecimalesMedida.c_Largo
                                            .AddWithValue("@forzarmedida", xdet.c_ForzarDecimalesMedida.c_Texto).Size = xdet.c_ForzarDecimalesMedida.c_Largo
                                            .AddWithValue("@tipotasa", xdet.c_TipoTasa.c_Texto).Size = xdet.c_TipoTasa.c_Largo
                                            .AddWithValue("@autodeposito", xdet.c_AutoDeposito.c_Texto).Size = xdet.c_AutoDeposito.c_Largo
                                            .AddWithValue("@psugerido", xdet.c_PSugerido.c_Valor)
                                            .AddWithValue("@pliquida", xdet._PLiquida)
                                            .AddWithValue("@costoinventario", xdet.c_CostoInventario.c_Valor)
                                            .AddWithValue("@costoventa", xdet.c_CostoVenta.c_Valor)
                                            .AddWithValue("@notasitem", xdet.c_ItemNotas.c_Texto).Size = xdet.c_ItemNotas.c_Largo

                                            'Campos Nuevos
                                            .AddWithValue("@n_tipodoc_origen", xdet.c_TipoDocumento_Origen.c_Texto).Size = xdet.c_TipoDocumento_Origen.c_Largo
                                            .AddWithValue("@n_autodoc_origen", xdet.c_AutoDocumento_Origen.c_Texto).Size = xdet.c_AutoDocumento_Origen.c_Largo
                                            .AddWithValue("@n_problema_origen", xdet.c_ProblemaDocumento_Origen.c_Texto).Size = xdet.c_ProblemaDocumento_Origen.c_Largo
                                            .AddWithValue("@n_autoitem_doc_origen", xdet.c_AutoItem_DocumentoOrigen.c_Texto).Size = xdet.c_AutoItem_DocumentoOrigen.c_Largo
                                            .AddWithValue("@n_RestringidoVenta", xdet.c_RestringidoVenta.c_Texto).Size = xdet.c_RestringidoVenta.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    For Each x As FichaVentas.V_TemporalVenta.c_Registro In xRegistroPendiente._ListaItems
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete from temporalventa where autoitem=@autoitem"
                                        xcmd.Parameters.AddWithValue("@autoitem", x._AutoItem)
                                        If xcmd.ExecuteNonQuery = 0 Then
                                            Throw New Exception("PROBLEMA AL DEJAR CUENTA PENDIENTE DETALLE, REGISTRO NO ENCONTRADO")
                                        End If
                                    Next

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
                        Throw New Exception("PROBLEMA AL GRABAR EN TABLA TEMPORAL PENDIENTE VENTA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Class CtaPendienteAbrir
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xctapendiente As FichaVentas.V_TemporalVentaPendiente.c_Registro
                    Private xequipo As String
                    Private xidunico As String

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return Me.xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xusuario = value
                        End Set
                    End Property

                    Property _FichaPendienteAbrir() As FichaVentas.V_TemporalVentaPendiente.c_Registro
                        Protected Friend Get
                            Return Me.xctapendiente
                        End Get
                        Set(ByVal value As FichaVentas.V_TemporalVentaPendiente.c_Registro)
                            Me.xctapendiente = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return Me.xequipo.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _IdUnico() As String
                        Protected Friend Get
                            Return Me.xidunico.Trim
                        End Get
                        Set(ByVal value As String)
                            Me.xidunico = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaProceso() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    Sub New()
                        Me._EquipoEstacion = ""
                        Me._FichaUsuario = Nothing
                        Me._FichaPendienteAbrir = Nothing
                        Me._IdUnico = ""
                    End Sub
                End Class

                Function F_AbrirCta_Pendiente(ByVal xregistro As CtaPendienteAbrir) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xrd As SqlDataReader
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xtb As New DataTable
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from temporalventa_pendientedetalle where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xregistro._FichaPendienteAbrir._AutoMovimiento)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)
                                    xrd.close()

                                    Dim xautoitem As String = ""
                                    For Each xrow As DataRow In xtb.Rows
                                        Dim xr As New FichaVentas.V_TemporalVentaPendienteDetalle.c_Registro
                                        xr.CargarRegistro(xrow)

                                        xautoitem = ""
                                        xcmd.CommandText = "select a_temporalventa from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_temporalventa=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_temporalventa=a_temporalventa+1; " _
                                            + "select a_temporalventa from contadores"
                                        xautoitem = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        Dim xreg As New FichaVentas.V_TemporalVenta.c_Registro
                                        With xreg
                                            .c_AutoItem.c_Texto = xautoitem
                                            .c_AutoDeposito.c_Texto = xr.c_AutoDeposito.c_Texto
                                            .c_AutoMedida.c_Texto = xr.c_AutoMedida.c_Texto
                                            .c_AutoProducto.c_Texto = xr.c_AutoProducto.c_Texto
                                            .c_AutoUsuario.c_Texto = xregistro._FichaUsuario._AutoUsuario
                                            .c_CantidadDespachar.c_Valor = xr.c_CantidadDespachar.c_Valor
                                            .c_CodigoProducto.c_Texto = xr.c_CodigoProducto.c_Texto
                                            .c_ContenidoEmpaque.c_Valor = xr.c_ContenidoEmpaque.c_Valor
                                            .c_CostoInventario.c_Valor = xr.c_CostoInventario.c_Valor
                                            .c_CostoVenta.c_Valor = xr.c_CostoVenta.c_Valor
                                            .c_Descuento.c_Valor = xr.c_Descuento.c_Valor
                                            .c_EsPesado.c_Texto = xr.c_EsPesado.c_Texto
                                            .c_EstacionEquipo.c_Texto = xregistro._EquipoEstacion
                                            .c_FechaProceso.c_Valor = xregistro._FechaProceso
                                            .c_ForzarDecimalesMedida.c_Texto = xr.c_ForzarDecimalesMedida.c_Texto
                                            .c_IdUnico.c_Texto = xregistro._IdUnico
                                            .c_ItemNotas.c_Texto = xr.c_ItemNotas.c_Texto
                                            .c_NombreEmpaque.c_Texto = xr.c_NombreEmpaque.c_Texto
                                            .c_NombreProducto.c_Texto = xr.c_NombreProducto.c_Texto
                                            .c_NombreUsuario.c_Texto = xregistro._FichaUsuario._NombreUsuario
                                            .c_NumeroDecimalesMedida.c_Texto = xr.c_NumeroDecimalesMedida.c_Texto
                                            .c_PrecioNeto.c_Valor = xr.c_PrecioNeto.c_Valor
                                            .c_PSugerido.c_Valor = xr.c_PSugerido.c_Valor
                                            .c_ReferenciaEmpaque.c_Texto = xr.c_ReferenciaEmpaque.c_Texto
                                            .c_TasaIva.c_Valor = xr.c_TasaIva.c_Valor
                                            .c_TipoDocumento.c_Texto = xregistro._FichaPendienteAbrir.c_TipoDocumento.c_Texto
                                            .c_TipoTasa.c_Texto = xr.c_TipoTasa.c_Texto
                                            .c_BloquearExistencia.c_Texto = xr.c_BloquearExistencia.c_Texto
                                            .c_PLiquida.c_Valor = xr.c_PLiquida.c_Valor
                                            .c_Importe.c_Valor = xr.c_Importe.c_Valor
                                            ' Campos Nuevos
                                            .c_AutoDocumento_Origen.c_Texto = xr.c_AutoDocumento_Origen.c_Texto
                                            .c_TipoDocumento_Origen.c_Texto = xr.c_TipoDocumento_Origen.c_Texto
                                            .c_ProblemaDocumento_Origen.c_Texto = xr.c_ProblemaDocumento_Origen.c_Texto
                                            .c_AutoItem_Documento_Origen.c_Texto = xr.c_AutoItem_DocumentoOrigen.c_Texto
                                            .c_RestringidoVenta.c_Texto = xr.c_RestringidoVenta.c_Texto
                                        End With

                                        xcmd.CommandText = FichaVentas.V_TemporalVenta.InsertRegistroTemporalVenta
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@codigo", xreg.c_CodigoProducto.c_Texto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@producto", xreg.c_NombreProducto.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                            .AddWithValue("@cantidad", xreg.c_CantidadDespachar.c_Valor)
                                            .AddWithValue("@precioneto", xreg.c_PrecioNeto.c_Valor)
                                            .AddWithValue("@descuento", xreg.c_Descuento.c_Valor)
                                            .AddWithValue("@tasaiva", xreg.c_TasaIva.c_Valor)
                                            .AddWithValue("@importe", xreg._Importe)
                                            .AddWithValue("@espesado", xreg.c_EsPesado.c_Texto).Size = xreg.c_EsPesado.c_Largo
                                            .AddWithValue("@autoitem", xreg.c_AutoItem.c_Texto).Size = xreg.c_AutoItem.c_Largo
                                            .AddWithValue("@autoproducto", xreg._AutoProducto).Size = xreg.c_CodigoProducto.c_Largo
                                            .AddWithValue("@bloquearexistencia", xreg.c_BloquearExistencia.c_Texto).Size = xreg.c_NombreProducto.c_Largo
                                            .AddWithValue("@nombreempaque", xreg.c_NombreEmpaque.c_Texto).Size = xreg.c_NombreEmpaque.c_Largo
                                            .AddWithValue("@contenidoempaque", xreg.c_ContenidoEmpaque.c_Valor)
                                            .AddWithValue("@referenciaempaque", xreg.c_ReferenciaEmpaque.c_Texto).Size = xreg.c_ReferenciaEmpaque.c_Largo
                                            .AddWithValue("@automedida", xreg.c_AutoMedida.c_Texto).Size = xreg.c_AutoMedida.c_Largo
                                            .AddWithValue("@decimalesmedida", xreg.c_NumeroDecimalesMedida.c_Texto).Size = xreg.c_NumeroDecimalesMedida.c_Largo
                                            .AddWithValue("@forzarmedida", xreg.c_ForzarDecimalesMedida.c_Texto).Size = xreg.c_ForzarDecimalesMedida.c_Largo
                                            .AddWithValue("@tipotasa", xreg.c_TipoTasa.c_Texto).Size = xreg.c_TipoTasa.c_Largo
                                            .AddWithValue("@autodeposito", xreg.c_AutoDeposito.c_Texto).Size = xreg.c_AutoDeposito.c_Largo
                                            .AddWithValue("@autousuario", xreg.c_AutoUsuario.c_Texto).Size = xreg.c_AutoUsuario.c_Largo
                                            .AddWithValue("@nombreusuario", xreg.c_NombreUsuario.c_Texto).Size = xreg.c_NombreUsuario.c_Largo
                                            .AddWithValue("@fecha", xreg.c_FechaProceso.c_Valor)
                                            .AddWithValue("@estacion", xreg.c_EstacionEquipo.c_Texto).Size = xreg.c_EstacionEquipo.c_Largo
                                            .AddWithValue("@tipodocumento", xreg.c_TipoDocumento.c_Texto).Size = xreg.c_TipoDocumento.c_Largo
                                            .AddWithValue("@psugerido", xreg.c_PSugerido.c_Valor)
                                            .AddWithValue("@pliquida", xreg._PLiquida)
                                            .AddWithValue("@costoinventario", xreg.c_CostoInventario.c_Valor)
                                            .AddWithValue("@costoventa", xreg.c_CostoVenta.c_Valor)
                                            .AddWithValue("@notasitem", xreg.c_ItemNotas.c_Texto).Size = xreg.c_ItemNotas.c_Largo
                                            .AddWithValue("@idunico", xreg.c_IdUnico.c_Texto).Size = xreg.c_IdUnico.c_Largo
                                            ' Campos Nuevos
                                            .AddWithValue("@n_autodoc_origen", xreg.c_AutoDocumento_Origen.c_Texto).Size = xreg.c_AutoDocumento_Origen.c_Largo
                                            .AddWithValue("@n_tipodoc_origen", xreg.c_TipoDocumento_Origen.c_Texto).Size = xreg.c_TipoDocumento_Origen.c_Largo
                                            .AddWithValue("@n_problema_origen", xreg.c_ProblemaDocumento_Origen.c_Texto).Size = xreg.c_ProblemaDocumento_Origen.c_Largo
                                            .AddWithValue("@n_autoitem_doc_origen", xreg.c_AutoItem_Documento_Origen.c_Texto).Size = xreg.c_AutoItem_Documento_Origen.c_Largo
                                            .AddWithValue("@n_RestringidoVenta", xreg.c_RestringidoVenta.c_Texto).Size = xreg.c_RestringidoVenta.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporalventa_pendientedetalle where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xregistro._FichaPendienteAbrir._AutoMovimiento)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("REGISTROS EN TABLA VENTA DETALLE PENDIENTE NO ENCONTRADOS")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from temporalventa_pendiente where auto_doc=@auto_doc"
                                    xcmd.Parameters.AddWithValue("@auto_doc", xregistro._FichaPendienteAbrir._AutoMovimiento)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("REGISTRO EN TABLA VENTA PENDIENTE NO ECONTRADO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent ActualizarTabla()
                                If xregistro._FichaPendienteAbrir._AutomaticoCliente <> "" Then
                                    RaiseEvent _ActualizarFichaCliente(xregistro._FichaPendienteAbrir._AutomaticoCliente)
                                End If
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL ABRIR CUENTA TEMPORAL VENTA PENDIENTE" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Class V_TemporalVentaPendienteDetalle
                Class AgregarDetallePendiente
                    Dim xreg As c_Registro

                    WriteOnly Property _CodigoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_CodigoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_NombreProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Cantidad() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CantidadDespachar.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioNeto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_PrecioNeto.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Descuento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_Descuento.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaIva() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_TasaIva.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Importe() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_Importe.c_Valor = value
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

                    WriteOnly Property _BloquearExistencia() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroDetalle.c_BloquearExistencia.c_Texto = "1"
                            Else
                                Me.RegistroDetalle.c_BloquearExistencia.c_Texto = "0"
                            End If
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

                    WriteOnly Property _ReferenciaEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_ReferenciaEmpaque.c_Texto = value
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
                                    Throw New Exception("VENTAS TEMPORAL" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + "ERROR EN EL TIPO DE IMPUESTO PARA ESTE PRODUCTO")
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

                    WriteOnly Property _PLiquida() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_PLiquida.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoInventario() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoInventario.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoVenta() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDetalle.c_CostoVenta.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ItemNotas() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_ItemNotas.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumento_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_TipoDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoDocumento_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_AutoDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Problema_Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroDetalle.c_ProblemaDocumento_Origen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Restringidoventa() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                Me.RegistroDetalle.c_RestringidoVenta.c_Texto = "1"
                            Else
                                Me.RegistroDetalle.c_RestringidoVenta.c_Texto = ""
                            End If
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
                    Private f_producto As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_precioneto As CampoDecimal
                    Private f_descuento As CampoDecimal
                    Private f_tasaiva As CampoDecimal
                    Private f_importe As CampoDecimal
                    Private f_espesado As CampoTexto
                    Private f_autoitem As CampoTexto
                    Private f_autoproducto As CampoTexto
                    Private f_bloquearexistencia As CampoTexto
                    Private f_nombreempaque As CampoTexto
                    Private f_contenidoempaque As CampoInteger
                    Private f_referenciaempaque As CampoTexto
                    Private f_automedida As CampoTexto
                    Private f_decimalesmedida As CampoTexto
                    Private f_forzarmedida As CampoTexto
                    Private f_tipotasa As CampoTexto
                    Private f_autodeposito As CampoTexto
                    Private f_psugerido As CampoDecimal
                    Private f_pliquida As CampoDecimal
                    Private f_costoinventario As CampoDecimal
                    Private f_costoventa As CampoDecimal
                    Private f_notasitem As CampoTexto

                    'Campos Nuevos
                    Private f_n_tipodoc_origen As CampoTexto
                    Private f_n_autodoc_origen As CampoTexto
                    Private f_n_problema_origen As CampoTexto
                    Private f_n_autoitem_doc_origen As CampoTexto
                    Private f_n_restringidoVenta As CampoTexto

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

                    Protected Friend Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_producto = value
                        End Set
                    End Property

                    Protected Friend Property c_CantidadDespachar() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    Protected Friend Property c_PrecioNeto() As CampoDecimal
                        Get
                            Return f_precioneto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precioneto = value
                        End Set
                    End Property

                    Protected Friend Property c_Descuento() As CampoDecimal
                        Get
                            Return f_descuento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento = value
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

                    Protected Friend Property c_Importe() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
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

                    Protected Friend Property c_BloquearExistencia() As CampoTexto
                        Get
                            Return f_bloquearexistencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_bloquearexistencia = value
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

                    Protected Friend Property c_ReferenciaEmpaque() As CampoTexto
                        Get
                            Return f_referenciaempaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_referenciaempaque = value
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

                    Protected Friend Property c_PLiquida() As CampoDecimal
                        Get
                            Return f_pliquida
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_pliquida = value
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

                    Protected Friend Property c_CostoVenta() As CampoDecimal
                        Get
                            Return f_costoventa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costoventa = value
                        End Set
                    End Property

                    Property c_ItemNotas() As CampoTexto
                        Get
                            Return f_notasitem
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_notasitem = value
                        End Set
                    End Property


                    'Campos Nuevos
                    Protected Friend Property c_TipoDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_tipodoc_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_n_tipodoc_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_autodoc_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_n_autodoc_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_ProblemaDocumento_Origen() As CampoTexto
                        Get
                            Return Me.f_n_problema_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_n_problema_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoItem_DocumentoOrigen() As CampoTexto
                        Get
                            Return Me.f_n_autoitem_doc_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_n_autoitem_doc_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_RestringidoVenta() As CampoTexto
                        Get
                            Return Me.f_n_restringidoVenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_n_restringidoVenta = value
                        End Set
                    End Property


                    ReadOnly Property _TipoDocumentoOrigen() As String
                        Get
                            Return Me.c_TipoDocumento_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumentoOrigen() As String
                        Get
                            Return Me.c_AutoDocumento_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ProblemaDocumentoOrigen() As String
                        Get
                            Return Me.c_ProblemaDocumento_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItem_DocumentoOrigen() As String
                        Get
                            Return Me.c_AutoItem_DocumentoOrigen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _RestringidoVenta() As TipoSiNo
                        Get
                            If Me.c_RestringidoVenta.c_Texto = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property


                    '
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

                    ReadOnly Property _CantidadDespachar() As Decimal
                        Get
                            Return Me.c_CantidadDespachar.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return Me.c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Descuento() As Decimal
                        Get
                            Return Me.c_Descuento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As String
                        Get
                            Return Me.c_EsPesado.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Return c_Importe.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return Me.c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Return Me.c_PrecioNeto.c_Valor
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

                    ReadOnly Property _BloquearExistencia() As Boolean
                        Get
                            If Me.c_BloquearExistencia.c_Texto.Trim = "1" Then
                                Return True
                            Else
                                Return False
                            End If
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

                    ReadOnly Property _ReferenciaEmpaque() As String
                        Get
                            Return Me.c_ReferenciaEmpaque.c_Texto.Trim
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

                    ReadOnly Property _PFinal() As Decimal
                        Get
                            Dim xpfin As Decimal = 0
                            xpfin = Me._PrecioNeto - (Me._PrecioNeto * Me._Descuento / 100)
                            xpfin = Decimal.Round(xpfin, 2, MidpointRounding.AwayFromZero)
                            Return xpfin
                        End Get
                    End Property

                    ReadOnly Property _PLiquida() As Decimal
                        Get
                            Dim xliq As Decimal = 0
                            xliq = _PFinal / _ContenidoEmpaque
                            xliq = Decimal.Round(xliq, 2, MidpointRounding.AwayFromZero)
                            Return xliq
                        End Get
                    End Property

                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return Me.c_CostoInventario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoVenta() As Decimal
                        Get
                            Return Me.c_CostoVenta.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _ItemNotas() As String
                        Get
                            Return Me.c_ItemNotas.c_Texto.Trim
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

                    ReadOnly Property _PLiquidaFullIva() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _PLiquida + (_PLiquida * _TasaIva / 100)
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
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

                    ReadOnly Property _Total() As Decimal
                        Get
                            Dim xt As Decimal = 0
                            xt = _Importe + _Impuesto
                            xt = Decimal.Round(xt, 2, MidpointRounding.AwayFromZero)
                            Return xt
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoDoc = New CampoTexto(10, "auto_doc")
                        Me.c_AutoItem = New CampoTexto(10, "autoitem")
                        Me.c_CantidadDespachar = New CampoDecimal("cantidad")
                        Me.c_CodigoProducto = New CampoTexto(15, "codigo")
                        Me.c_Descuento = New CampoDecimal("descuento")
                        Me.c_EsPesado = New CampoTexto(1, "espesado")
                        Me.c_NombreProducto = New CampoTexto(200, "producto")
                        Me.c_PrecioNeto = New CampoDecimal("precioneto")
                        Me.c_TasaIva = New CampoDecimal("tasaiva")
                        Me.c_Importe = New CampoDecimal("importe")
                        Me.c_AutoProducto = New CampoTexto(10, "autoproducto")
                        Me.c_BloquearExistencia = New CampoTexto(1, "bloquearexistencia")
                        Me.c_NombreEmpaque = New CampoTexto(20, "nombreempaque")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenidoempaque")
                        Me.c_ReferenciaEmpaque = New CampoTexto(1, "referenciaempaque")
                        Me.c_AutoMedida = New CampoTexto(10, "automedida")
                        Me.c_NumeroDecimalesMedida = New CampoTexto(1, "decimalesmedida")
                        Me.c_ForzarDecimalesMedida = New CampoTexto(1, "forzarmedida")
                        Me.c_TipoTasa = New CampoTexto(1, "tipotasa")
                        Me.c_AutoDeposito = New CampoTexto(10, "autodeposito")
                        Me.c_PSugerido = New CampoDecimal("psugerido")
                        Me.c_PLiquida = New CampoDecimal("pliquida")
                        Me.c_CostoInventario = New CampoDecimal("costoinventario")
                        Me.c_CostoVenta = New CampoDecimal("costoventa")
                        Me.c_ItemNotas = New CampoTexto(160, "notasitem")

                        ' Campos Nuevos
                        Me.c_AutoDocumento_Origen = New CampoTexto(10, "n_autodoc_origen")
                        Me.c_TipoDocumento_Origen = New CampoTexto(2, "n_tipodoc_origen")
                        Me.c_ProblemaDocumento_Origen = New CampoTexto(1, "n_problema_origen")
                        Me.c_AutoItem_DocumentoOrigen = New CampoTexto(10, "n_autoitem_doc_origen")
                        Me.c_RestringidoVenta = New CampoTexto(1, "n_RestringidoVenta")
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
                                .c_BloquearExistencia.c_Texto = xrow(.c_BloquearExistencia.c_NombreInterno)
                                .c_CantidadDespachar.c_Valor = xrow(.c_CantidadDespachar.c_NombreInterno)
                                .c_CodigoProducto.c_Texto = xrow(.c_CodigoProducto.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_CostoInventario.c_Valor = xrow(.c_CostoInventario.c_NombreInterno)
                                .c_CostoVenta.c_Valor = xrow(.c_CostoVenta.c_NombreInterno)
                                .c_Descuento.c_Valor = xrow(.c_Descuento.c_NombreInterno)
                                .c_EsPesado.c_Texto = xrow(.c_EsPesado.c_NombreInterno)
                                .c_ForzarDecimalesMedida.c_Texto = xrow(.c_ForzarDecimalesMedida.c_NombreInterno)
                                .c_ItemNotas.c_Texto = xrow(.c_ItemNotas.c_NombreInterno)
                                .c_NombreEmpaque.c_Texto = xrow(.c_NombreEmpaque.c_NombreInterno)
                                .c_NombreProducto.c_Texto = xrow(.c_NombreProducto.c_NombreInterno)
                                .c_NumeroDecimalesMedida.c_Texto = xrow(.c_NumeroDecimalesMedida.c_NombreInterno)
                                .c_PLiquida.c_Valor = xrow(.c_PLiquida.c_NombreInterno)
                                .c_PrecioNeto.c_Valor = xrow(.c_PrecioNeto.c_NombreInterno)
                                .c_PSugerido.c_Valor = xrow(.c_PSugerido.c_NombreInterno)
                                .c_ReferenciaEmpaque.c_Texto = xrow(.c_ReferenciaEmpaque.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_TipoTasa.c_Texto = xrow(.c_TipoTasa.c_NombreInterno)
                                .c_Importe.c_Valor = xrow(.c_Importe.c_NombreInterno)

                                ' Campos Nuevos
                                If Not IsDBNull(xrow(.c_AutoDocumento_Origen.c_NombreInterno)) Then
                                    .c_AutoDocumento_Origen.c_Texto = xrow(.c_AutoDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_TipoDocumento_Origen.c_NombreInterno)) Then
                                    .c_TipoDocumento_Origen.c_Texto = xrow(.c_TipoDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_ProblemaDocumento_Origen.c_NombreInterno)) Then
                                    .c_ProblemaDocumento_Origen.c_Texto = xrow(.c_ProblemaDocumento_Origen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoItem_DocumentoOrigen.c_NombreInterno)) Then
                                    .c_AutoItem_DocumentoOrigen.c_Texto = xrow(.c_AutoItem_DocumentoOrigen.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_RestringidoVenta.c_NombreInterno)) Then
                                    .c_RestringidoVenta.c_Texto = xrow(.c_RestringidoVenta.c_NombreInterno)
                                End If

                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR DATA TABLA TEMPORAL VENTA PENDIENTE DETALLE" + vbCrLf + ex.Message)
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

            Class RecuperarDoc
                Private xautousuario As String
                Private xequipoestacion As String
                Private xfechaprocesao As Date
                Private xidunico As String
                Private xnombreusuario As String
                Private xtipodocumento As TipoDocumentoVenta

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

                Property _AutoUsuario() As String
                    Protected Friend Get
                        Return xautousuario
                    End Get
                    Set(ByVal value As String)
                        xautousuario = value
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

                Property _FechaMovimiento() As Date
                    Protected Friend Get
                        Return xfechaprocesao
                    End Get
                    Set(ByVal value As Date)
                        xfechaprocesao = value
                    End Set
                End Property

                Property _IDUnico() As String
                    Protected Friend Get
                        Return xidunico
                    End Get
                    Set(ByVal value As String)
                        xidunico = value
                    End Set
                End Property

                Property _NombreUsuario() As String
                    Protected Friend Get
                        Return xnombreusuario
                    End Get
                    Set(ByVal value As String)
                        xnombreusuario = value
                    End Set
                End Property

                Property _TipoDocumento() As TipoDocumentoVenta
                    Protected Friend Get
                        Return xtipodocumento
                    End Get
                    Set(ByVal value As TipoDocumentoVenta)
                        xtipodocumento = value
                    End Set
                End Property

                Sub New()
                    Me._AutoUsuario = ""
                    Me._EquipoEstacion = ""
                    Me._FechaMovimiento = Date.MinValue
                    Me._IDUnico = ""
                    Me._NombreUsuario = ""
                    Me._TipoDocumento = 0

                    Me._AutoUsuario_Recuperar = ""
                    Me._FechaMovimiento_Recuperar = Date.MinValue
                    Me._IdUnico_Recuperar = ""
                End Sub
            End Class

            Class V_Ventas
                Class AgregarVenta

                    Private xregistro As c_Registro
                    Private xdocumentoorigen As String
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xfichavendedor As FichaVendedores.c_Vendedor.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xdescuentoporprontopago As Decimal

                    Property _DescuentoPorProntoPago() As Decimal
                        Get
                            Return xdescuentoporprontopago
                        End Get
                        Set(ByVal value As Decimal)
                            xdescuentoporprontopago = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _AutoCobrador() As String
                        Get
                            Return xfichacliente.r_AutoCobrador
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _NombreCobrador() As String
                        Get
                            Return xfichacliente.r_NombreCobrador
                        End Get
                    End Property

                    Property _DocumentoOrigen_PresupuestoPedidoNotaEntrega() As String
                        Get
                            Return Me.xdocumentoorigen
                        End Get
                        Set(ByVal value As String)
                            Me.xdocumentoorigen = value
                        End Set
                    End Property

                    ReadOnly Property _f_FichaDocumentoOrigen() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                Dim xficha As New FichaVentas.V_Ventas
                                xficha.F_BuscarDocumento(Me._DocumentoOrigen_PresupuestoPedidoNotaEntrega)
                                Return xficha.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
                        End Set
                    End Property

                    Property _FichaVendedor() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Return Me.xfichavendedor
                        End Get
                        Set(ByVal value As FichaVendedores.c_Vendedor.c_Registro)
                            Me.xfichavendedor = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xfichausuario = value
                        End Set
                    End Property


                    Sub New()
                        Me._DocumentoOrigen_PresupuestoPedidoNotaEntrega = ""
                        Me._DescuentoPorProntoPago = 0
                        Me.RegistroDato = New c_Registro
                        Me._FichaCliente = Nothing
                        Me._FichaUsuario = Nothing
                        Me._FichaVendedor = Nothing

                        SubTotal_1 = 0.0
                        DsctoGeneralMonto = 0.0
                        CargoGeneralMonto = 0.0
                    End Sub

                    WriteOnly Property _SerieFiscalAsignada() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_SerieAsignada.c_Texto = value
                        End Set
                    End Property

                    Protected Friend WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = F_GetDate("select getdate()").Date
                        End Set
                    End Property
                    WriteOnly Property _FechaOrdenCompra() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaPedido.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _NombreCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreCliente.c_Texto = Me._FichaCliente.r_NombreRazonSocial
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _DirFiscalCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DirFiscalCliente.c_Texto = Me._FichaCliente.r_DirFiscal
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CiRifCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CiRifCliente.c_Texto = Me._FichaCliente.r_CiRif
                        End Set
                    End Property
                    WriteOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Set(ByVal value As TipoDocumentoVentaRegistrado)
                            Select Case value
                                Case TipoDocumentoVentaRegistrado.Factura
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "01"
                                Case TipoDocumentoVentaRegistrado.NotaDebito
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "02"
                                Case TipoDocumentoVentaRegistrado.NotaCredito
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "03"
                                Case TipoDocumentoVentaRegistrado.NotaEntrega
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "04"
                                Case TipoDocumentoVentaRegistrado.Presupuesto
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "05"
                                Case TipoDocumentoVentaRegistrado.Pedido
                                    Me.RegistroDato.c_TipoDocumento.c_Texto = "06"
                            End Select
                        End Set
                    End Property
                    WriteOnly Property _MontoExento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Exento.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base3.c_Valor = value
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
                            Me.RegistroDato.c_NotasDocumento.c_Texto = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoCliente.c_Texto = Me._FichaCliente.r_Automatico
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CodigoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoCliente.c_Texto = Me._FichaCliente.r_CodigoCliente
                        End Set
                    End Property
                    WriteOnly Property _OrdenCompraNumero() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_OrdenCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _DiasCreditoOtorgado() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_DiasCreditoCliente.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento_1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaDescuento_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaDescuento_2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _TasaCargos() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaCargos.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoSubtotal() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoSubTotal.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _TelefonoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TelefonoCliente.c_Texto = Me._FichaCliente.r_Telefono_1
                        End Set
                    End Property
                    WriteOnly Property _FactorCambio() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_FactorCambio.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CodigoVendedor() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoVendedor.c_Texto = _FichaVendedor.r_CodigoVendedor
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _NombreVendedor() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreVendedor.c_Texto = _FichaVendedor.r_NombreVendedor
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoVendedor() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoVendedor.c_Texto = _FichaVendedor.r_Automatico
                        End Set
                    End Property
                    WriteOnly Property _NumeroPedido() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroPedido.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CondicionPago() As TipoCondcionPago
                        Set(ByVal value As TipoCondcionPago)
                            If value = TipoCondcionPago.Contado Then
                                Me.RegistroDato.c_CondicionPago.c_Texto = "CONTADO"
                            Else
                                Me.RegistroDato.c_CondicionPago.c_Texto = "CREDITO"
                            End If
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _NombreUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Usuario.c_Texto = _FichaUsuario._NombreUsuario
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CodigoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoUsuario.c_Texto = _FichaUsuario._CodigoUsuario
                        End Set
                    End Property
                    WriteOnly Property _CodigoSucursal() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoSucursal.c_Texto = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _HoraDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Hora.c_Texto = F_GetDate("select getdate()").ToShortTimeString
                        End Set
                    End Property
                    WriteOnly Property _DirDespacho() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DirDespacho.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _EstacionEquipoProceso() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_EstacionEquipo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CantidadRenglones() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_CantidadRenglones.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoSaldoPendiente() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoSaldoPendiente.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoUsuario.c_Texto = _FichaUsuario._AutoUsuario
                        End Set
                    End Property
                    WriteOnly Property _DiasValidezDocumento() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_ValidezDocumentoDias.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoJornada() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoJornada.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoOperador() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoOperador.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _SerialUnicoJornada() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_SerialUnico_Jornada.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _BloquearAlmacen() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_BloquearAlmacen.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _OrigenDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_OrigenDocumento.c_Texto = "01"
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_Numero_MesaPedido() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Rest_NumeroMesaPedido.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_ServicioTasa() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Rest_ServicioTasa.c_Valor = 0
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_ServicioMonto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Rest_ServicioMonto.c_Valor = 0
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_Modo_MesaPedido() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Rest_ModoMesaPedido.c_Texto = ""
                        End Set
                    End Property

                    Private _dsctoGeneralMonto As Decimal
                    Property DsctoGeneralMonto() As Decimal
                        Get
                            Return _dsctoGeneralMonto
                        End Get
                        Set(ByVal value As Decimal)
                            _dsctoGeneralMonto = value
                        End Set
                    End Property

                    Private _cargoGeneralMonto As Decimal
                    Property CargoGeneralMonto() As Decimal
                        Get
                            Return _cargoGeneralMonto
                        End Get
                        Set(ByVal value As Decimal)
                            _cargoGeneralMonto = value
                        End Set
                    End Property

                    Private _subTotal_1 As Decimal
                    Property SubTotal_1() As Decimal
                        Get
                            Return _subTotal_1
                        End Get
                        Set(ByVal value As Decimal)
                            _subTotal_1 = value
                        End Set
                    End Property

                    ''

                    ''
                    Property estatusDivisa As Boolean

                    ReadOnly Property esDivisa As String
                        Get
                            If estatusDivisa Then
                                Return "1"
                            Else
                                Return "0"
                            End If
                        End Get
                    End Property

                    ReadOnly Property montoDivisa As Decimal
                        Get
                            Dim xr As Decimal = 0.0
                            If estatusDivisa Then
                                xr = Me.RegistroDato.c_TotalGeneral.c_Valor
                            Else
                                xr = Me.RegistroDato.c_TotalGeneral.c_Valor / Me.RegistroDato.c_FactorCambio.c_Valor
                            End If
                            Return xr
                        End Get
                    End Property


                    Protected Friend Sub AsignarData()
                        Me._AutoCliente = ""
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._AutoUsuario = ""
                        Me._AutoVendedor = ""
                        Me._BloquearAlmacen = ""
                        Me._CiRifCliente = ""
                        Me._CodigoCliente = ""
                        Me._CodigoUsuario = ""
                        Me._CodigoVendedor = ""
                        Me._DirFiscalCliente = ""
                        Me._FechaEmision = New Date()
                        Me._HoraDocumento = ""
                        Me._NombreCliente = ""
                        Me._NombreUsuario = ""
                        Me._NombreVendedor = ""
                        Me._OrigenDocumento = ""
                        Me._Rest_Modo_MesaPedido = ""
                        Me._Rest_Numero_MesaPedido = ""
                        Me._Rest_ServicioMonto = 0
                        Me._Rest_ServicioTasa = 0
                        Me._SerialUnicoJornada = ""
                        Me._TelefonoCliente = ""
                    End Sub

                End Class

                Class AgregarNotaCredito
                    Private xregistro As c_Registro
                    Private xficharegistroventa_origen As FichaVentas.V_Ventas.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro

                    Property _FichaRegistroVentaOrigen() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Return xficharegistroventa_origen
                        End Get
                        Set(ByVal value As FichaVentas.V_Ventas.c_Registro)
                            xficharegistroventa_origen = value
                        End Set
                    End Property

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xfichausuario = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroDato = New c_Registro
                        Me._FichaUsuario = Nothing
                        Me._FichaRegistroVentaOrigen = Nothing
                    End Sub

                    Protected Friend Sub AsignarData()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._AutoUsuario = ""
                        Me._CodigoUsuario = ""
                        Me._CondicionPago = 0
                        Me._FechaEmision = New Date()
                        Me._HoraDocumento = ""
                        Me._NombreUsuario = ""
                        Me._TipoDocumento = 0
                        Me._OrigenDocumento = ""
                        Me._Rest_Modo_MesaPedido = ""
                        Me._Rest_Numero_MesaPedido = ""
                        Me._Rest_ServicioMonto = 0
                        Me._Rest_ServicioTasa = 0
                    End Sub

                    WriteOnly Property _SerieFiscalAsignada() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_SerieAsignada.c_Texto = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = F_GetDate("select getdate()").Date
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Set(ByVal value As TipoDocumentoVentaRegistrado)
                            Me.RegistroDato.c_TipoDocumento.c_Texto = "03"
                        End Set
                    End Property
                    WriteOnly Property _MontoExento() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Exento.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base1.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_2() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base2.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _MontoBase_3() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Base3.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _NotasDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NotasDocumento.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _MontoSubtotal() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoSubTotal.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CondicionPago() As TipoCondcionPago
                        Set(ByVal value As TipoCondcionPago)
                            Me.RegistroDato.c_CondicionPago.c_Texto = "CONTADO"
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _NombreUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Usuario.c_Texto = _FichaUsuario._NombreUsuario
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _CodigoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoUsuario.c_Texto = _FichaUsuario._CodigoUsuario
                        End Set
                    End Property
                    WriteOnly Property _CodigoSucursal() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoSucursal.c_Texto = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _HoraDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Hora.c_Texto = F_GetDate("select getdate()").ToShortTimeString
                        End Set
                    End Property
                    WriteOnly Property _EstacionEquipoProceso() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_EstacionEquipo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CantidadRenglones() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_CantidadRenglones.c_Valor = value
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoUsuario.c_Texto = _FichaUsuario._AutoUsuario
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoJornada() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoJornada.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _AutoOperador() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoOperador.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _OrigenDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_OrigenDocumento.c_Texto = "01"
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_Numero_MesaPedido() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Rest_NumeroMesaPedido.c_Texto = ""
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_ServicioTasa() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Rest_ServicioTasa.c_Valor = 0
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_ServicioMonto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Rest_ServicioMonto.c_Valor = 0
                        End Set
                    End Property
                    Protected Friend WriteOnly Property _Rest_Modo_MesaPedido() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Rest_ModoMesaPedido.c_Texto = ""
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_fecha_vencimiento As CampoFecha
                    Private f_nombre As CampoTexto
                    Private f_dir_fiscal As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_exento As CampoDecimal
                    Private f_base1 As CampoDecimal
                    Private f_base2 As CampoDecimal
                    Private f_base3 As CampoDecimal
                    Private f_impuesto1 As CampoDecimal
                    Private f_impuesto2 As CampoDecimal
                    Private f_impuesto3 As CampoDecimal
                    Private f_base As CampoDecimal
                    Private f_impuesto As CampoDecimal
                    Private f_total As CampoDecimal
                    Private f_tasa1 As CampoDecimal
                    Private f_tasa2 As CampoDecimal
                    Private f_tasa3 As CampoDecimal

                    Private f_nota As CampoTexto
                    Private f_tasa_retencion_iva As CampoDecimal
                    Private f_tasa_retencion_islr As CampoDecimal
                    Private f_retencion_iva As CampoDecimal
                    Private f_retencion_islr As CampoDecimal
                    Private f_auto_entidad As CampoTexto
                    Private f_codigo_entidad As CampoTexto
                    Private f_mes_relacion As CampoTexto
                    Private f_control As CampoTexto
                    Private f_fecha_relacion As CampoFecha
                    Private f_orden_compra As CampoTexto
                    Private f_dias As CampoInteger
                    Private f_descuento1 As CampoDecimal
                    Private f_descuento2 As CampoDecimal
                    Private f_cargos As CampoDecimal
                    Private f_descuento1_porcentaje As CampoDecimal
                    Private f_descuento2_porcentaje As CampoDecimal
                    Private f_cargos_porcentaje As CampoDecimal
                    Private f_columna As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_aplica As CampoTexto
                    Private f_comprobante_retencion As CampoTexto
                    Private f_subtotal As CampoDecimal
                    Private f_telefono As CampoTexto
                    Private f_factor_cambio As CampoDecimal
                    Private f_codigo_vendedor As CampoTexto
                    Private f_vendedor As CampoTexto
                    Private f_auto_vendedor As CampoTexto

                    Private f_fecha_pedido As CampoFecha
                    Private f_pedido As CampoTexto
                    Private f_condicion_pago As CampoTexto
                    Private f_usuario As CampoTexto
                    Private f_codigo_usuario As CampoTexto
                    Private f_codigo_sucursal As CampoTexto
                    Private f_hora As CampoTexto
                    Private f_transporte As CampoTexto
                    Private f_codigo_transporte As CampoTexto
                    Private f_monto_divisa As CampoDecimal
                    Private f_despachado As CampoTexto
                    Private f_dir_despacho As CampoTexto
                    Private f_estacion As CampoTexto
                    Private f_auto_recibo As CampoTexto
                    Private f_recibo As CampoTexto
                    Private f_renglones As CampoInteger
                    Private f_saldo_pendiente As CampoDecimal
                    Private f_ano_relacion As CampoTexto
                    Private f_comprobante_retencion_islr As CampoTexto
                    Private f_dias_validez As CampoInteger
                    Private f_nrf As CampoTexto
                    Private f_auto_usuario As CampoTexto

                    'CAMPOS NUEVOS, QUE SE AGREGARON
                    Private f_serie As CampoTexto
                    Private f_auto_jornada As CampoTexto
                    Private f_auto_operador As CampoTexto
                    Private f_serial As CampoTexto
                    Private f_bloquear_almacen As CampoTexto
                    Private f_origen_documento As CampoTexto
                    Private f_rest_numero_mesapedido As CampoTexto
                    Private f_rest_servicio_tasa As CampoDecimal
                    Private f_rest_servicio_monto As CampoDecimal
                    Private f_rest_modo_mesapedido As CampoTexto
                    Private f_descuento_por_prontopago As CampoDecimal
                    Private f_relacion_z As CampoInteger

                    ''
                    Property EstatusDivisa As String


                    Property c_Relacion_Z() As CampoInteger
                        Get
                            Return f_relacion_z
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_relacion_z = value
                        End Set
                    End Property

                    ReadOnly Property RelacionZ() As Integer
                        Get
                            Return f_relacion_z.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoPorProntoPago() As CampoDecimal
                        Get
                            Return f_descuento_por_prontopago
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento_por_prontopago = value
                        End Set
                    End Property

                    ReadOnly Property _DescuentoPorProntoPago() As Decimal
                        Get
                            Return f_descuento_por_prontopago.c_Valor
                        End Get
                    End Property

                    Property c_OrigenDocumento() As CampoTexto
                        Get
                            Return f_origen_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_origen_documento = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' PROCEDENCIA / ORIGEN MODULO EL CUAL EMITIO EL DOCUMENTO
                    ''' </summary>
                    ReadOnly Property _OrigenProcedenciaDocumento() As ProcedenciaDocumento
                        Get
                            Select Case Me.c_OrigenDocumento.c_Texto.Trim.ToUpper
                                Case "01" : Return ProcedenciaDocumento.ADMINISTRATIVO
                                Case "02" : Return ProcedenciaDocumento.PTOVENTA_ONLINE
                                Case "03" : Return ProcedenciaDocumento.PTOVENTA_OFFLINE
                                Case "04" : Return ProcedenciaDocumento.FASTFOOD
                                Case "05" : Return ProcedenciaDocumento.RESTAURANT
                                Case "06" : Return ProcedenciaDocumento.ESTACIONAMIENTO
                                Case Else : Return ProcedenciaDocumento.NODEFINIDO
                            End Select
                        End Get
                    End Property

                    Property c_Rest_NumeroMesaPedido() As CampoTexto
                        Get
                            Return f_rest_numero_mesapedido
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_rest_numero_mesapedido = value
                        End Set
                    End Property

                    ReadOnly Property _Rest_NumeroMesaPedido() As String
                        Get
                            Return Me.c_Rest_NumeroMesaPedido.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Rest_ServicioTasa() As CampoDecimal
                        Get
                            Return f_rest_servicio_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDecimal)
                            f_rest_servicio_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _Rest_ServicioTasa() As Decimal
                        Get
                            Return Me.c_Rest_ServicioTasa.c_Valor
                        End Get
                    End Property

                    Property c_Rest_ServicioMonto() As CampoDecimal
                        Get
                            Return f_rest_servicio_monto
                        End Get
                        Protected Friend Set(ByVal value As CampoDecimal)
                            f_rest_servicio_monto = value
                        End Set
                    End Property

                    ReadOnly Property _Rest_ServicioMonto() As Decimal
                        Get
                            Return Me.c_Rest_ServicioMonto.c_Valor
                        End Get
                    End Property

                    Property c_Rest_ModoMesaPedido() As CampoTexto
                        Get
                            Return f_rest_modo_mesapedido
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_rest_modo_mesapedido = value
                        End Set
                    End Property

                    ReadOnly Property _Rest_ModoMesaPedido() As Restaurant.TipoPedido
                        Get
                            Select Case Me.c_Rest_ModoMesaPedido.c_Texto.Trim.ToUpper
                                Case "M" : Return Restaurant.TipoPedido.ParaMesa
                                Case "P" : Return Restaurant.TipoPedido.ParaLLevar
                            End Select
                        End Get
                    End Property


                    Protected Friend Property c_BloquearAlmacen() As CampoTexto
                        Get
                            Return f_bloquear_almacen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_bloquear_almacen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' INDICA SI EL DOCUMENTO TIENE LA MERCANCIA BLOQUEADA EN RESERVADA, ESTO PARA DOCUMENTOS TIPO PEDIDO, SABER SI AL ANULAR LIBERA/NO LA MERCANCIA
                    ''' </summary>
                    ReadOnly Property _BloquearExistencia() As Boolean
                        Get
                            If Me.c_BloquearAlmacen.c_Texto.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_SerieAsignada() As CampoTexto
                        Get
                            Return f_serie
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_serie = value
                        End Set
                    End Property

                    ReadOnly Property _SerieFiscalAsignada() As String
                        Get
                            Return Me.c_SerieAsignada.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutomaticoJornada() As CampoTexto
                        Get
                            Return f_auto_jornada
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Return Me.c_AutomaticoJornada.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutomaticoOperador() As CampoTexto
                        Get
                            Return f_auto_operador
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Return Me.c_AutomaticoOperador.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_SerialUnico_Jornada() As CampoTexto
                        Get
                            Return f_serial
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_serial = value
                        End Set
                    End Property

                    ReadOnly Property _SerialUnicoJornada() As String
                        Get
                            Return Me.c_SerialUnico_Jornada.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return Me.c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Documento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    ReadOnly Property _Documento() As String
                        Get
                            Return Me.c_Documento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return Me.c_FechaEmision.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_FechaVencimiento() As CampoFecha
                        Get
                            Return f_fecha_vencimiento
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_vencimiento = value
                        End Set
                    End Property

                    ReadOnly Property _FechaVencimiento() As Date
                        Get
                            Return Me.c_FechaVencimiento.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_NombreCliente() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreCliente() As String
                        Get
                            Return Me.c_NombreCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_DirFiscalCliente() As CampoTexto
                        Get
                            Return f_dir_fiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dir_fiscal = value
                        End Set
                    End Property

                    ReadOnly Property _DirFiscalCliente() As String
                        Get
                            Return Me.c_DirFiscalCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CiRifCliente() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    ReadOnly Property _CiRifCliente() As String
                        Get
                            Return Me.c_CiRifCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim.ToUpper
                                Case "01"
                                    Return TipoDocumentoVentaRegistrado.Factura
                                Case "02"
                                    Return TipoDocumentoVentaRegistrado.NotaDebito
                                Case "03"
                                    Return TipoDocumentoVentaRegistrado.NotaCredito
                                Case "04"
                                    Return TipoDocumentoVentaRegistrado.NotaEntrega
                                Case "05"
                                    Return TipoDocumentoVentaRegistrado.Presupuesto
                                Case "06"
                                    Return TipoDocumentoVentaRegistrado.Pedido
                                Case "XX"
                                    Return TipoDocumentoVentaRegistrado.Chimbo
                                Case "XN"
                                    Return TipoDocumentoVentaRegistrado.ChimboNC
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_Exento() As CampoDecimal
                        Get
                            Return f_exento
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_exento = value
                        End Set
                    End Property

                    ReadOnly Property _MontoExento() As Decimal
                        Get
                            Return Me.c_Exento.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Base1() As CampoDecimal
                        Get
                            Return f_base1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base1 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoBase_1() As Decimal
                        Get
                            Return Me.c_Base1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Base2() As CampoDecimal
                        Get
                            Return f_base2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base2 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoBase_2() As Decimal
                        Get
                            Return Me.c_Base2.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Base3() As CampoDecimal
                        Get
                            Return f_base3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base3 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoBase_3() As Decimal
                        Get
                            Return Me.c_Base3.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Impuesto1() As CampoDecimal
                        Get
                            Return f_impuesto1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto1 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoImpuesto_1() As Decimal
                        Get
                            Return Me.c_Impuesto1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Impuesto2() As CampoDecimal
                        Get
                            Return f_impuesto2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto2 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoImpuesto_2() As Decimal
                        Get
                            Return Me.c_Impuesto2.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Impuesto3() As CampoDecimal
                        Get
                            Return f_impuesto3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto3 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoImpuesto_3() As Decimal
                        Get
                            Return Me.c_Impuesto3.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Base() As CampoDecimal
                        Get
                            Return f_base
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_base = value
                        End Set
                    End Property

                    ReadOnly Property _MontoTotalBases() As Decimal
                        Get
                            Return Me.c_Base.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Impuesto() As CampoDecimal
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto = value
                        End Set
                    End Property

                    ReadOnly Property _MontoTotalImpuesto() As Decimal
                        Get
                            Return Me.c_Impuesto.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TotalGeneral() As CampoDecimal
                        Get
                            Return f_total
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total = value
                        End Set
                    End Property

                    ReadOnly Property _TotalGenereal() As Decimal
                        Get
                            Return Me.c_TotalGeneral.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Tasa1() As CampoDecimal
                        Get
                            Return f_tasa1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa1 = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva_1() As Decimal
                        Get
                            Return Me.c_Tasa1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Tasa2() As CampoDecimal
                        Get
                            Return f_tasa2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa2 = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva_2() As Decimal
                        Get
                            Return Me.c_Tasa2.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Tasa3() As CampoDecimal
                        Get
                            Return f_tasa3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa3 = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva_3() As Decimal
                        Get
                            Return Me.c_Tasa3.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_NotasDocumento() As CampoTexto
                        Get
                            Return f_nota
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nota = value
                        End Set
                    End Property

                    ReadOnly Property _NotasDocumento() As String
                        Get
                            Return Me.c_NotasDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_TasaRetencionIva() As CampoDecimal
                        Get
                            Return f_tasa_retencion_iva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa_retencion_iva = value
                        End Set
                    End Property

                    Protected Friend Property c_TasaRetencionISLR() As CampoDecimal
                        Get
                            Return f_tasa_retencion_islr
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa_retencion_islr = value
                        End Set
                    End Property

                    ReadOnly Property _TasaRetencionISLR() As Decimal
                        Get
                            Return Me.c_TasaRetencionISLR.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_RetencionIva() As CampoDecimal
                        Get
                            Return f_retencion_iva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_retencion_iva = value
                        End Set
                    End Property

                    ReadOnly Property _MontoRetencionIva() As Decimal
                        Get
                            Return Me.c_RetencionIva.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_RetencionISLR() As CampoDecimal
                        Get
                            Return f_retencion_islr
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_retencion_islr = value
                        End Set
                    End Property

                    ReadOnly Property _MontoRetencionISLR() As Decimal
                        Get
                            Return Me.c_RetencionIva.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_AutoCliente() As CampoTexto
                        Get
                            Return f_auto_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return Me.c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' RETORNA FICHA DEL CLIENTE
                    ''' </summary>
                    ReadOnly Property _f_FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Try
                                Dim xcliente As New FichaClientes.c_Clientes
                                xcliente.F_BuscarCargar(Me._AutoCliente)
                                Return xcliente.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Protected Friend Property c_CodigoCliente() As CampoTexto
                        Get
                            Return f_codigo_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoCliente() As String
                        Get
                            Return Me.c_CodigoCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_MesRelacion() As CampoTexto
                        Get
                            Return f_mes_relacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_mes_relacion = value
                        End Set
                    End Property

                    ReadOnly Property _MesRelacion() As Integer
                        Get
                            Dim xmes As Integer = 0
                            Integer.TryParse(Me.c_MesRelacion.c_Texto, xmes)
                            Return xmes
                        End Get
                    End Property

                    Protected Friend Property c_ControlFiscal() As CampoTexto
                        Get
                            Return f_control
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_control = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroControlFiscal() As String
                        Get
                            Return Me.c_ControlFiscal.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaRelacion() As CampoFecha
                        Get
                            Return f_fecha_relacion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_relacion = value
                        End Set
                    End Property

                    ReadOnly Property _FechaRelacion() As Date
                        Get
                            Return Me.c_FechaRelacion.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_OrdenCompra() As CampoTexto
                        Get
                            Return f_orden_compra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_orden_compra = value
                        End Set
                    End Property

                    ReadOnly Property _OrdenCompraNumero() As String
                        Get
                            Return Me.c_OrdenCompra.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_DiasCreditoCliente() As CampoInteger
                        Get
                            Return f_dias
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias = value
                        End Set
                    End Property

                    ReadOnly Property _DiasCreditoOtorgado() As Integer
                        Get
                            Return Me.c_DiasCreditoCliente.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_MontoDescuento_1() As CampoDecimal
                        Get
                            Return f_descuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoDescuento_1() As Decimal
                        Get
                            Return Me.c_MontoDescuento_1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_MontoDescuento_2() As CampoDecimal
                        Get
                            Return f_descuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2 = value
                        End Set
                    End Property

                    ReadOnly Property _MontoDescuento_2() As Decimal
                        Get
                            Return Me.c_MontoDescuento_2.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_MontoCargo() As CampoDecimal
                        Get
                            Return f_cargos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cargos = value
                        End Set
                    End Property

                    ReadOnly Property _MontoCargos() As Decimal
                        Get
                            Return Me.c_MontoCargo.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TasaDescuento_1() As CampoDecimal
                        Get
                            Return f_descuento1_porcentaje
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1_porcentaje = value
                        End Set
                    End Property

                    ReadOnly Property _TasaDescuento_1() As Decimal
                        Get
                            Return Me.c_TasaDescuento_1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TasaDescuento_2() As CampoDecimal
                        Get
                            Return f_descuento2_porcentaje
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2_porcentaje = value
                        End Set
                    End Property

                    ReadOnly Property _TasaDescuento_2() As Decimal
                        Get
                            Return Me.c_TasaDescuento_2.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TasaCargos() As CampoDecimal
                        Get
                            Return f_cargos_porcentaje
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cargos_porcentaje = value
                        End Set
                    End Property

                    ReadOnly Property _TasaCargos() As Decimal
                        Get
                            Return Me.c_TasaCargos.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TipoColumna() As CampoTexto
                        Get
                            Return f_columna
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_columna = value
                        End Set
                    End Property

                    ReadOnly Property _TipoColumnaUsada() As String
                        Get
                            Return Me.c_TipoColumna.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_EstatusDocumento() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusDocumento() As TipoEstatus
                        Get
                            Select Case Me.c_EstatusDocumento.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                                Case "2" : Return TipoEstatus.Procesado
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_DocumentoAplica() As CampoTexto
                        Get
                            Return f_aplica
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_aplica = value
                        End Set
                    End Property

                    ReadOnly Property _DocumentoAplica() As String
                        Get
                            Return Me.c_DocumentoAplica.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_ComprobanteRetencion() As CampoTexto
                        Get
                            Return f_comprobante_retencion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comprobante_retencion = value
                        End Set
                    End Property

                    ReadOnly Property _ComprobanteRetencionIva() As String
                        Get
                            Return Me.c_ComprobanteRetencion.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_MontoSubTotal() As CampoDecimal
                        Get
                            Return f_subtotal
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_subtotal = value
                        End Set
                    End Property

                    ReadOnly Property _MontoSubtotal() As Decimal
                        Get
                            Return Me.c_MontoSubTotal.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TelefonoCliente() As CampoTexto
                        Get
                            Return f_telefono
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono = value
                        End Set
                    End Property

                    ReadOnly Property _TelefonoCliente() As String
                        Get
                            Return Me.c_TelefonoCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FactorCambio() As CampoDecimal
                        Get
                            Return f_factor_cambio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_factor_cambio = value
                        End Set
                    End Property

                    ReadOnly Property _FactorCambio() As Decimal
                        Get
                            Return Me.c_FactorCambio.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_CodigoVendedor() As CampoTexto
                        Get
                            Return f_codigo_vendedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoVendedor() As String
                        Get
                            Return Me.c_CodigoVendedor.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_NombreVendedor() As CampoTexto
                        Get
                            Return f_vendedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _NombreVendedor() As String
                        Get
                            Return Me.c_NombreVendedor.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_AutoVendedor() As CampoTexto
                        Get
                            Return f_auto_vendedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _AutoVendedor() As String
                        Get
                            Return Me.c_AutoVendedor.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _f_FichaVendedor() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Try
                                Dim xvend As New FichaVendedores
                                xvend.F_BuscarVendedor(_AutoVendedor)
                                Return xvend.f_Vendedor.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Protected Friend Property c_FechaPedido() As CampoFecha
                        Get
                            Return f_fecha_pedido
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_pedido = value
                        End Set
                    End Property

                    ReadOnly Property _FechaPedido() As String
                        Get
                            Return Me.c_FechaPedido.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_NumeroPedido() As CampoTexto
                        Get
                            Return f_pedido
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_pedido = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroPedido() As String
                        Get
                            Return Me.c_NumeroPedido.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CondicionPago() As CampoTexto
                        Get
                            Return f_condicion_pago
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_condicion_pago = value
                        End Set
                    End Property

                    ReadOnly Property _CondicionPago() As TipoCondcionPago
                        Get
                            If Me.c_CondicionPago.c_Texto.Trim.ToUpper = "CONTADO" Then
                                Return TipoCondcionPago.Contado
                            Else
                                Return TipoCondcionPago.Credito
                            End If
                            Return Me.c_DocumentoAplica.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_Usuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_Usuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoUsuario() As CampoTexto
                        Get
                            Return f_codigo_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoUsuario() As String
                        Get
                            Return Me.c_CodigoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoSucursal() As CampoTexto
                        Get
                            Return f_codigo_sucursal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_sucursal = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoSucursal() As String
                        Get
                            Return Me.c_CodigoSucursal.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _HoraDocumento() As String
                        Get
                            Return Me.c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Transporte() As CampoTexto
                        Get
                            Return f_transporte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_transporte = value
                        End Set
                    End Property

                    ReadOnly Property _Transporte() As String
                        Get
                            Return Me.c_Transporte.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoTransporte() As CampoTexto
                        Get
                            Return f_codigo_transporte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_transporte = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoTransporte() As String
                        Get
                            Return Me.c_CodigoTransporte.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_MontoDivisa() As CampoDecimal
                        Get
                            Return f_monto_divisa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto_divisa = value
                        End Set
                    End Property

                    ReadOnly Property _MontoDivisa() As Decimal
                        Get
                            Return c_MontoDivisa.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_NombreDespachador() As CampoTexto
                        Get
                            Return f_despachado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_despachado = value
                        End Set
                    End Property

                    ReadOnly Property _NombreDespachador() As String
                        Get
                            Return c_NombreDespachador.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_DirDespacho() As CampoTexto
                        Get
                            Return f_dir_despacho
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dir_despacho = value
                        End Set
                    End Property

                    ReadOnly Property _DirDespacho() As String
                        Get
                            Return c_DirDespacho.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_EstacionEquipo() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _EstacionEquipoProceso() As String
                        Get
                            Return c_EstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_recibo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' INDICA LOS MEDIOS DE PAGOS USADOS PARA EL PAGO DEL DOCUMENTO
                    ''' </summary>
                    ReadOnly Property _MediosDePago() As String
                        Get
                            Try
                                If _AutoRecibo <> "" Then
                                    Dim xtb As New DataTable
                                    Dim xmedio As String = ""
                                    Dim xsql As String = "select monto_recibido as monto, nombre as modo from cxc_modo_pago where auto_recibo=@autorecibo"
                                    Dim xp1 As New SqlParameter("@autorecibo", Me._AutoRecibo)

                                    Using xcon As New SqlClient.SqlDataAdapter(xsql, _MiCadenaConexion)
                                        xcon.SelectCommand.Parameters.Clear()
                                        xcon.SelectCommand.Parameters.Add(xp1)
                                        xcon.Fill(xtb)
                                    End Using

                                    If xtb.Rows.Count > 0 Then
                                        For Each xr As DataRow In xtb.Rows
                                            xmedio += xr("modo").ToString.Trim + "=" + xr("monto").ToString.Trim + " ,"
                                        Next
                                    End If
                                    Return xmedio
                                Else
                                    Return ""
                                End If
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    Protected Friend Property c_NumeroRecibo() As CampoTexto
                        Get
                            Return f_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_recibo = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroRecibo() As String
                        Get
                            Return c_NumeroRecibo.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CantidadRenglones() As CampoInteger
                        Get
                            Return f_renglones
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_renglones = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadRenglones() As Integer
                        Get
                            Return c_CantidadRenglones.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_MontoSaldoPendiente() As CampoDecimal
                        Get
                            Return f_saldo_pendiente
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_saldo_pendiente = value
                        End Set
                    End Property

                    ReadOnly Property _MontoSaldoPendiente() As Decimal
                        Get
                            Return c_MontoSaldoPendiente.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_AnoRelacion() As CampoTexto
                        Get
                            Return f_ano_relacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ano_relacion = value
                        End Set
                    End Property

                    ReadOnly Property _AnoRelacion() As Integer
                        Get
                            Dim xano As Integer = 0
                            Integer.TryParse(Me.c_AnoRelacion.c_Texto, xano)
                            Return xano
                        End Get
                    End Property

                    Protected Friend Property c_ComprobanteRetencionISLR() As CampoTexto
                        Get
                            Return f_comprobante_retencion_islr
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comprobante_retencion_islr = value
                        End Set
                    End Property

                    ReadOnly Property _ComprobanteRetencionISLR() As String
                        Get
                            Return c_ComprobanteRetencionISLR.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ValidezDocumentoDias() As CampoInteger
                        Get
                            Return f_dias_validez
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_validez = value
                        End Set
                    End Property

                    ReadOnly Property _DiasValidezDocumento() As Integer
                        Get
                            Return c_ValidezDocumentoDias.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_SerialImpresoraFiscal() As CampoTexto
                        Get
                            Return f_nrf
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nrf = value
                        End Set
                    End Property

                    ReadOnly Property _SerialImpresoraFiscal() As String
                        Get
                            Return c_SerialImpresoraFiscal.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_auto_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoSubTotal_DespuesDescuentoCargosGlobales() As Decimal
                        Get
                            Dim x As Decimal = (_MontoSubtotal - _MontoDescuento_1 - _MontoDescuento_2 + _MontoCargos)
                            Return Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _SubTotalMontoGravable_AntesDescuentosCargosGlobales() As Decimal
                        Get
                            If _AutoDocumento <> "" Then
                                Return _f_SubTotalMontoGravable_AntesDescuentosCargosGlobales()
                            Else
                                Return 0
                            End If
                        End Get
                    End Property

                    ReadOnly Property _SubTotalMontoExento_AntesDescuentosCargosGlobales() As Decimal
                        Get
                            If _AutoDocumento <> "" Then
                                Return _f_SubTotalMontoExento_AntesDescuentosCargosGlobales()
                            Else
                                Return 0
                            End If
                        End Get
                    End Property

                    ReadOnly Property _SubTotalMontoBase_1_AntesDescuentosCargosGlobales() As Decimal
                        Get
                            If _AutoDocumento <> "" Then
                                Return _f_SubTotalMontoBase_1_AntesDescuentosCargosGlobales()
                            Else
                                Return 0
                            End If
                        End Get
                    End Property

                    ReadOnly Property _SubTotalMontoBase_2_AntesDescuentosCargosGlobales() As Decimal
                        Get
                            If _AutoDocumento <> "" Then
                                Return _f_SubTotalMontoBase_2_AntesDescuentosCargosGlobales()
                            Else
                                Return 0
                            End If
                        End Get
                    End Property

                    ReadOnly Property _SubTotalMontoBase_3_AntesDescuentosCargosGlobales() As Decimal
                        Get
                            If _AutoDocumento <> "" Then
                                Return _f_SubTotalMontoBase_3_AntesDescuentosCargosGlobales()
                            Else
                                Return 0
                            End If
                        End Get
                    End Property

                    Function _f_SubTotalMontoGravable_AntesDescuentosCargosGlobales() As Decimal
                        Try
                            Dim p1 As New SqlParameter("@auto", _AutoDocumento)
                            Dim xsql As String = "select SUM(cantidad*precio_neto) from ventas_detalle where auto_documento=@auto and codigo_tasa<>'0'"
                            Dim xr As Decimal = 0
                            xr = F_GetDecimal(xsql, p1)
                            Return xr
                        Catch ex As Exception
                            Return 0
                        End Try
                    End Function

                    Function _f_SubTotalMontoExento_AntesDescuentosCargosGlobales() As Decimal
                        Try
                            Dim p1 As New SqlParameter("@auto", _AutoDocumento)
                            Dim xsql As String = "select SUM(cantidad*precio_neto) from ventas_detalle where auto_documento=@auto and codigo_tasa='0'"
                            Dim xr As Decimal = 0
                            xr = F_GetDecimal(xsql, p1)
                            Return xr
                        Catch ex As Exception
                            Return 0
                        End Try
                    End Function

                    Function _f_SubTotalMontoBase_1_AntesDescuentosCargosGlobales() As Decimal
                        Try
                            Dim p1 As New SqlParameter("@auto", _AutoDocumento)
                            Dim xsql As String = "select SUM(cantidad*precio_neto) from ventas_detalle where auto_documento=@auto and codigo_tasa='1'"
                            Dim xr As Decimal = 0
                            xr = F_GetDecimal(xsql, p1)
                            Return xr
                        Catch ex As Exception
                            Return 0
                        End Try
                    End Function

                    Function _f_SubTotalMontoBase_2_AntesDescuentosCargosGlobales() As Decimal
                        Try
                            Dim p1 As New SqlParameter("@auto", _AutoDocumento)
                            Dim xsql As String = "select SUM(cantidad*precio_neto) from ventas_detalle where auto_documento=@auto and codigo_tasa='2'"
                            Dim xr As Decimal = 0
                            xr = F_GetDecimal(xsql, p1)
                            Return xr
                        Catch ex As Exception
                            Return 0
                        End Try
                    End Function

                    Function _f_SubTotalMontoBase_3_AntesDescuentosCargosGlobales() As Decimal
                        Try
                            Dim p1 As New SqlParameter("@auto", _AutoDocumento)
                            Dim xsql As String = "select SUM(cantidad*precio_neto) from ventas_detalle where auto_documento=@auto and codigo_tasa='3'"
                            Dim xr As Decimal = 0
                            xr = F_GetDecimal(xsql, p1)
                            Return xr
                        Catch ex As Exception
                            Return 0
                        End Try
                    End Function


                    Sub New()
                        f_auto = New CampoTexto(10, "auto")
                        f_documento = New CampoTexto(10, "documento")
                        f_fecha = New CampoFecha("fecha")
                        f_fecha_vencimiento = New CampoFecha("fecha_vencimiento")
                        f_nombre = New CampoTexto(120, "nombre")
                        f_dir_fiscal = New CampoTexto(120, "dir_fiscal")
                        f_ci_rif = New CampoTexto(12, "ci_rif")
                        f_tipo = New CampoTexto(2, "tipo")
                        f_exento = New CampoDecimal("exento")
                        f_base1 = New CampoDecimal("base1")
                        f_base2 = New CampoDecimal("base2")
                        f_base3 = New CampoDecimal("base3")
                        f_impuesto1 = New CampoDecimal("impuesto1")
                        f_impuesto2 = New CampoDecimal("impuesto2")
                        f_impuesto3 = New CampoDecimal("impuesto3")
                        f_base = New CampoDecimal("base")
                        f_impuesto = New CampoDecimal("impuesto")
                        f_total = New CampoDecimal("total")
                        f_tasa1 = New CampoDecimal("tasa1")
                        f_tasa2 = New CampoDecimal("tasa2")
                        f_tasa3 = New CampoDecimal("tasa3")

                        f_nota = New CampoTexto(120, "nota")
                        f_tasa_retencion_iva = New CampoDecimal("tasa_retencion_iva")
                        f_tasa_retencion_islr = New CampoDecimal("tasa_retencion_islr")
                        f_retencion_iva = New CampoDecimal("retencion_iva")
                        f_retencion_islr = New CampoDecimal("retencion_islr")
                        f_auto_entidad = New CampoTexto(10, "auto_entidad")
                        f_codigo_entidad = New CampoTexto(15, "codigo_entidad")
                        f_mes_relacion = New CampoTexto(2, "mes_relacion")
                        f_control = New CampoTexto(10, "control")
                        f_fecha_relacion = New CampoFecha("fecha_relacion")
                        f_orden_compra = New CampoTexto(10, "orden_compra")
                        f_dias = New CampoInteger("dias")
                        f_descuento1 = New CampoDecimal("descuento1")
                        f_descuento2 = New CampoDecimal("descuento2")
                        f_cargos = New CampoDecimal("cargos")
                        f_descuento1_porcentaje = New CampoDecimal("descuento1_porcentaje")
                        f_descuento2_porcentaje = New CampoDecimal("descuento2_porcentaje")
                        f_cargos_porcentaje = New CampoDecimal("cargos_porcentaje")
                        f_columna = New CampoTexto(1, "columna")
                        f_estatus = New CampoTexto(1, "estatus")
                        f_aplica = New CampoTexto(10, "aplica")
                        f_comprobante_retencion = New CampoTexto(14, "comprobante_retencion")
                        f_subtotal = New CampoDecimal("subtotal")
                        f_telefono = New CampoTexto(50, "telefono")
                        f_factor_cambio = New CampoDecimal("factor_cambio")
                        f_codigo_vendedor = New CampoTexto(10, "codigo_vendedor")
                        f_vendedor = New CampoTexto(40, "vendedor")
                        f_auto_vendedor = New CampoTexto(10, "auto_vendedor")

                        f_fecha_pedido = New CampoFecha("fecha_pedido")
                        f_pedido = New CampoTexto(10, "pedido")
                        f_condicion_pago = New CampoTexto(15, "condicion_pago")
                        f_usuario = New CampoTexto(20, "usuario")
                        f_codigo_usuario = New CampoTexto(10, "codigo_usuario")
                        f_codigo_sucursal = New CampoTexto(10, "codigo_sucursal")
                        f_hora = New CampoTexto(10, "hora")
                        f_transporte = New CampoTexto(20, "transporte")
                        f_codigo_transporte = New CampoTexto(10, "codigo_transporte")
                        f_monto_divisa = New CampoDecimal("monto_divisa")
                        f_despachado = New CampoTexto(40, "despachado")
                        f_dir_despacho = New CampoTexto(120, "dir_despacho")
                        f_estacion = New CampoTexto(20, "estacion")
                        f_auto_recibo = New CampoTexto(10, "auto_recibo")
                        f_recibo = New CampoTexto(10, "recibo")
                        f_renglones = New CampoInteger("renglones")
                        f_saldo_pendiente = New CampoDecimal("saldo_pendiente")
                        f_ano_relacion = New CampoTexto(4, "ano_relacion")
                        f_comprobante_retencion_islr = New CampoTexto(14, "comprobante_retencion_islr")
                        f_dias_validez = New CampoInteger("dias_validez")
                        f_nrf = New CampoTexto(10, "nrf")
                        f_auto_usuario = New CampoTexto(10, "auto_usuario")
                        'CAMPOS NUEVOS
                        f_serie = New CampoTexto(10, "serie")
                        f_auto_jornada = New CampoTexto(10, "auto_jornada")
                        f_auto_operador = New CampoTexto(10, "auto_operador")
                        f_serial = New CampoTexto(60, "serial")
                        f_bloquear_almacen = New CampoTexto(1, "bloquear_almacen")

                        f_rest_modo_mesapedido = New CampoTexto(1, "rest_modo_mesapedido")
                        f_rest_numero_mesapedido = New CampoTexto(6, "rest_numero_mesapedido")
                        f_rest_servicio_monto = New CampoDecimal("rest_servicio_monto")
                        f_rest_servicio_tasa = New CampoDecimal("rest_servicio_tasa")
                        f_origen_documento = New CampoTexto(2, "origen_documento")
                        f_descuento_por_prontopago = New CampoDecimal("descuento_por_prontopago")

                        f_relacion_z = New CampoInteger("relacion_z")
                        M_LimpiarRegistro()
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()

                            With Me
                                ''
                                EstatusDivisa = xrow("estatusDivisa")

                                .c_AutoDocumento.c_Texto = xrow(c_AutoDocumento.c_NombreInterno)
                                .c_Documento.c_Texto = xrow(.c_Documento.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_FechaVencimiento.c_Valor = xrow(.c_FechaVencimiento.c_NombreInterno)
                                .c_NombreCliente.c_Texto = xrow(.c_NombreCliente.c_NombreInterno)
                                .c_DirFiscalCliente.c_Texto = xrow(.c_DirFiscalCliente.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(.c_CiRifCliente.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_Exento.c_Valor = xrow(.c_Exento.c_NombreInterno)
                                .c_Base1.c_Valor = xrow(.c_Base1.c_NombreInterno)
                                .c_Base2.c_Valor = xrow(.c_Base2.c_NombreInterno)
                                .c_Base3.c_Valor = xrow(.c_Base3.c_NombreInterno)
                                .c_Impuesto1.c_Valor = xrow(.c_Impuesto1.c_NombreInterno)
                                .c_Impuesto2.c_Valor = xrow(.c_Impuesto2.c_NombreInterno)
                                .c_Impuesto3.c_Valor = xrow(.c_Impuesto3.c_NombreInterno)
                                .c_Impuesto.c_Valor = xrow(.c_Impuesto.c_NombreInterno)
                                .c_Base.c_Valor = xrow(.c_Base.c_NombreInterno)
                                .c_Impuesto.c_Valor = xrow(.c_Impuesto.c_NombreInterno)
                                .c_TotalGeneral.c_Valor = xrow(.c_TotalGeneral.c_NombreInterno)
                                .c_Tasa1.c_Valor = xrow(.c_Tasa1.c_NombreInterno)
                                .c_Tasa2.c_Valor = xrow(.c_Tasa2.c_NombreInterno)
                                .c_Tasa3.c_Valor = xrow(.c_Tasa3.c_NombreInterno)

                                .c_NotasDocumento.c_Texto = xrow(.c_NotasDocumento.c_NombreInterno)
                                .c_TasaRetencionIva.c_Valor = xrow(.c_TasaRetencionIva.c_NombreInterno)
                                .c_TasaRetencionISLR.c_Valor = xrow(.c_TasaRetencionISLR.c_NombreInterno)
                                .c_RetencionIva.c_Valor = xrow(.c_RetencionIva.c_NombreInterno)
                                .c_RetencionISLR.c_Valor = xrow(.c_RetencionISLR.c_NombreInterno)
                                .c_AutoCliente.c_Texto = xrow(.c_AutoCliente.c_NombreInterno)
                                .c_CodigoCliente.c_Texto = xrow(.c_CodigoCliente.c_NombreInterno)
                                .c_MesRelacion.c_Texto = xrow(.c_MesRelacion.c_NombreInterno)
                                .c_ControlFiscal.c_Texto = xrow(.c_ControlFiscal.c_NombreInterno)
                                .c_FechaRelacion.c_Valor = xrow(.c_FechaRelacion.c_NombreInterno)
                                .c_OrdenCompra.c_Texto = xrow(.c_OrdenCompra.c_NombreInterno)
                                .c_DiasCreditoCliente.c_Valor = xrow(.c_DiasCreditoCliente.c_NombreInterno)
                                .c_MontoDescuento_1.c_Valor = xrow(.c_MontoDescuento_1.c_NombreInterno)
                                .c_MontoDescuento_2.c_Valor = xrow(.c_MontoDescuento_2.c_NombreInterno)
                                .c_MontoCargo.c_Valor = xrow(.c_MontoCargo.c_NombreInterno)
                                .c_TasaDescuento_1.c_Valor = xrow(.c_TasaDescuento_1.c_NombreInterno)
                                .c_TasaDescuento_2.c_Valor = xrow(.c_TasaDescuento_2.c_NombreInterno)
                                .c_TasaCargos.c_Valor = xrow(.c_TasaCargos.c_NombreInterno)
                                .c_TipoColumna.c_Texto = xrow(.c_TipoColumna.c_NombreInterno)
                                .c_EstatusDocumento.c_Texto = xrow(.c_EstatusDocumento.c_NombreInterno)
                                .c_DocumentoAplica.c_Texto = xrow(.c_DocumentoAplica.c_NombreInterno)
                                .c_ComprobanteRetencion.c_Texto = xrow(.c_ComprobanteRetencion.c_NombreInterno)
                                .c_MontoSubTotal.c_Valor = xrow(.c_MontoSubTotal.c_NombreInterno)
                                .c_TelefonoCliente.c_Texto = xrow(.c_TelefonoCliente.c_NombreInterno)
                                .c_FactorCambio.c_Valor = xrow(.c_FactorCambio.c_NombreInterno)
                                .c_CodigoVendedor.c_Texto = xrow(.c_CodigoVendedor.c_NombreInterno)
                                .c_NombreVendedor.c_Texto = xrow(.c_NombreVendedor.c_NombreInterno)
                                .c_AutoVendedor.c_Texto = xrow(.c_AutoVendedor.c_NombreInterno)
                                .c_FechaPedido.c_Valor = xrow(.c_FechaPedido.c_NombreInterno)
                                .c_NumeroPedido.c_Texto = xrow(.c_NumeroPedido.c_NombreInterno)
                                .c_CondicionPago.c_Texto = xrow(.c_CondicionPago.c_NombreInterno)
                                .c_Usuario.c_Texto = xrow(.c_Usuario.c_NombreInterno)
                                .c_CodigoUsuario.c_Texto = xrow(.c_CodigoUsuario.c_NombreInterno)
                                .c_CodigoSucursal.c_Texto = xrow(.c_CodigoSucursal.c_NombreInterno)
                                .c_Hora.c_Texto = xrow(.c_Hora.c_NombreInterno)
                                .c_Transporte.c_Texto = xrow(.c_Transporte.c_NombreInterno)
                                .c_CodigoTransporte.c_Texto = xrow(.c_CodigoTransporte.c_NombreInterno)
                                .c_MontoDivisa.c_Valor = xrow(.c_MontoDivisa.c_NombreInterno)
                                .c_NombreDespachador.c_Texto = xrow(.c_NombreDespachador.c_NombreInterno)
                                .c_DirDespacho.c_Texto = xrow(.c_DirDespacho.c_NombreInterno)
                                .c_EstacionEquipo.c_Texto = xrow(.c_EstacionEquipo.c_NombreInterno)
                                .c_AutoRecibo.c_Texto = xrow(.c_AutoRecibo.c_NombreInterno)
                                .c_NumeroRecibo.c_Texto = xrow(.c_NumeroRecibo.c_NombreInterno)
                                .c_CantidadRenglones.c_Valor = xrow(.c_CantidadRenglones.c_NombreInterno)
                                .c_MontoSaldoPendiente.c_Valor = xrow(.c_MontoSaldoPendiente.c_NombreInterno)
                                .c_AnoRelacion.c_Texto = xrow(.c_AnoRelacion.c_NombreInterno)
                                .c_ComprobanteRetencionISLR.c_Texto = xrow(.c_ComprobanteRetencionISLR.c_NombreInterno)
                                .c_ValidezDocumentoDias.c_Valor = xrow(.c_ValidezDocumentoDias.c_NombreInterno)
                                .c_SerialImpresoraFiscal.c_Texto = xrow(.c_SerialImpresoraFiscal.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)

                                'campos nuevos
                                If Not IsDBNull(xrow(.c_AutomaticoJornada.c_NombreInterno)) Then
                                    .c_AutomaticoJornada.c_Texto = xrow(.c_AutomaticoJornada.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_AutomaticoOperador.c_NombreInterno)) Then
                                    .c_AutomaticoOperador.c_Texto = xrow(.c_AutomaticoOperador.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_SerieAsignada.c_NombreInterno)) Then
                                    .c_SerieAsignada.c_Texto = xrow(.c_SerieAsignada.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_SerialUnico_Jornada.c_NombreInterno)) Then
                                    .c_SerialUnico_Jornada.c_Texto = xrow(.c_SerialUnico_Jornada.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_BloquearAlmacen.c_NombreInterno)) Then
                                    .c_BloquearAlmacen.c_Texto = xrow(.c_BloquearAlmacen.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_Rest_ModoMesaPedido.c_NombreInterno)) Then
                                    .c_Rest_ModoMesaPedido.c_Texto = xrow(.c_Rest_ModoMesaPedido.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_NumeroMesaPedido.c_NombreInterno)) Then
                                    .c_Rest_NumeroMesaPedido.c_Texto = xrow(.c_Rest_NumeroMesaPedido.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_ServicioMonto.c_NombreInterno)) Then
                                    .c_Rest_ServicioMonto.c_Valor = xrow(.c_Rest_ServicioMonto.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Rest_ServicioTasa.c_NombreInterno)) Then
                                    .c_Rest_ServicioTasa.c_Valor = xrow(.c_Rest_ServicioTasa.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_OrigenDocumento.c_NombreInterno)) Then
                                    .c_OrigenDocumento.c_Texto = xrow(.c_OrigenDocumento.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_DescuentoPorProntoPago.c_NombreInterno)) Then
                                    .c_DescuentoPorProntoPago.c_Valor = xrow(.c_DescuentoPorProntoPago.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Relacion_Z.c_NombreInterno)) Then
                                    .c_Relacion_Z.c_Valor = xrow(.c_Relacion_Z.c_NombreInterno)
                                End If

                            End With
                        Catch ex As Exception
                            Throw New Exception("VENTAS" + vbCrLf + "VENTA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

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
                    Try
                        Dim xp1 As New SqlParameter("@auto", xauto)
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from ventas where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Add(xp1)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count >= 1 Then
                            M_CargarRegistro(xtb.Rows(0))
                        Else
                            Throw New Exception("AUTO DEL DOCUMENTO NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("VENTAS" + vbCrLf + "BUSCAR DOCUMENTO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Class V_VentasDetalle
                Class AgregarDetalleNotaCredito
                    Private xcantidad As Decimal
                    Private xprecio As Decimal
                    Private xdescto As Decimal
                    Private xnotas As String
                    Private ximporte As Decimal
                    Private xtipomovimiento As TipoMovimientoNC
                    Private xitem_origen As FichaVentas.V_VentasDetalle.c_Registro
                    Private xregistro As FichaVentas.V_VentasDetalle.c_Registro

                    Protected Friend Property RegistroDato() As FichaVentas.V_VentasDetalle.c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As FichaVentas.V_VentasDetalle.c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Property _Cantidad() As Decimal
                        Protected Friend Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _PrecioNeto() As Decimal
                        Protected Friend Get
                            Return xprecio
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio = value
                        End Set
                    End Property

                    Property _Descto() As Decimal
                        Protected Friend Get
                            Return xdescto
                        End Get
                        Set(ByVal value As Decimal)
                            xdescto = value
                        End Set
                    End Property

                    Property _Importe() As Decimal
                        Protected Friend Get
                            Return ximporte
                        End Get
                        Set(ByVal value As Decimal)
                            ximporte = value
                        End Set
                    End Property

                    Property _NotasDetalle() As String
                        Protected Friend Get
                            Return xnotas
                        End Get
                        Set(ByVal value As String)
                            xnotas = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As TipoMovimientoNC
                        Get
                            Return xtipomovimiento
                        End Get
                        Set(ByVal value As TipoMovimientoNC)
                            xtipomovimiento = value
                        End Set
                    End Property

                    Property _ItemDetalleOrigen() As FichaVentas.V_VentasDetalle.c_Registro
                        Get
                            Return xitem_origen
                        End Get
                        Set(ByVal value As FichaVentas.V_VentasDetalle.c_Registro)
                            xitem_origen = value
                        End Set
                    End Property

                    Sub New()
                        _Cantidad = 0
                        _Descto = 0
                        _ItemDetalleOrigen = Nothing
                        _NotasDetalle = ""
                        _PrecioNeto = 0
                        _TipoMovimiento = 0

                        RegistroDato = New FichaVentas.V_VentasDetalle.c_Registro
                    End Sub
                End Class

                Class AgregarDetalleVenta
                    Private xregistro As c_Registro
                    Private xdepbloqueado As Boolean
                    Private xtipocalculoutilidad As TipoCalculoUtilidad
                    Private xitem_doc_origen As FichaVentas.V_VentasDetalle.c_Registro

                    Property _FichaItem_DocOrigen() As FichaVentas.V_VentasDetalle.c_Registro
                        Protected Friend Get
                            Return Me.xitem_doc_origen
                        End Get
                        Set(ByVal value As FichaVentas.V_VentasDetalle.c_Registro)
                            Me.xitem_doc_origen = value
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

                    Property _DepositoBloqueado() As Boolean
                        Protected Friend Get
                            Return xdepbloqueado
                        End Get
                        Set(ByVal value As Boolean)
                            xdepbloqueado = value
                        End Set
                    End Property

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        Me._FichaItem_DocOrigen = Nothing
                        Me._DepositoBloqueado = False
                        Me._TipoCalculoUtilidad = 0

                        Me.RegistroDato = New c_Registro
                        With Me.RegistroDato
                            .c_Corte.c_Texto = "0"
                            .c_Estatus.c_Texto = "0"
                            .c_EstatusCorte.c_Texto = "0"
                            .c_EstatusSerial.c_Texto = "0"
                            .c_SignoDocumento.c_Valor = 1
                        End With
                    End Sub

                    WriteOnly Property _AutoMedidaEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoMedida.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ForzarMedida() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroDato.c_ForzarMedida.c_Texto = "1"
                            Else
                                Me.RegistroDato.c_ForzarMedida.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EsPesado() As Boolean
                        Set(ByVal value As Boolean)
                            If value = True Then
                                Me.RegistroDato.c_PTO_EsPesado.c_Texto = "1"
                            Else
                                Me.RegistroDato.c_PTO_EsPesado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _NombreDeposito() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreDeposito.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoDeposito() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoDeposito.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoDeposito() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoDeposito.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoDepartamento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoDepartamento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoSubGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoSubGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CantidadDespachada() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CantidadDespachada.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _NombreEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreEmpaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DescuentoTasa_1() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_DescuentoTasa_1.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaIva() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaIva.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TipoTasaIva() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TipoTasaIva.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NumeroDecimales() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_NumeroDecimales.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ContenidoEmpaque() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_ContenidoEmpaque.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoInventario() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CostoInventario.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioNeto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_PrecioNeto.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoVenta() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CostoVenta.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusGarantia() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_EstatusGarantia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusSerial() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_EstatusSerial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DiasGarantia() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_DiasGarantia.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _DetalleNotas() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DetalleNotas.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioSugerido() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_PrecioSugerido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ReferenciaEmpaque() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_ReferenciaEmpaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CategoriaProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CategoriaProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DescripcionCortaProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreCortoProducto.c_Texto = value
                        End Set
                    End Property
                End Class

                Public Class c_Registro
                    Private f_auto_documento As CampoTexto
                    Private f_auto_productos As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_auto_departamento As CampoTexto
                    Private f_auto_grupo As CampoTexto
                    Private f_auto_subgrupo As CampoTexto
                    Private f_auto_deposito As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_empaque As CampoTexto
                    Private f_precio_neto As CampoDecimal
                    Private f_descuento1p As CampoDecimal
                    Private f_descuento2p As CampoDecimal
                    Private f_descuento3p As CampoDecimal
                    Private f_descuento1 As CampoDecimal
                    Private f_descuento2 As CampoDecimal
                    Private f_descuento3 As CampoDecimal
                    Private f_costo_venta As CampoDecimal
                    Private f_total_neto As CampoDecimal
                    Private f_tasa As CampoDecimal
                    Private f_impuesto As CampoDecimal
                    Private f_total As CampoDecimal
                    Private f_auto As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_tipo As CampoTexto
                    Private f_deposito As CampoTexto
                    Private f_signo As CampoInteger
                    Private f_precio_final As CampoDecimal
                    Private f_auto_entidad As CampoTexto
                    Private f_decimales As CampoInteger
                    Private f_contenido_empaque As CampoInteger
                    Private f_cantidad_inventario As CampoDecimal
                    Private f_precio_inventario As CampoDecimal
                    Private f_costo_inventario As CampoDecimal
                    Private f_utilidad As CampoDecimal
                    Private f_utilidadp As CampoDecimal
                    Private f_precio_item As CampoDecimal
                    Private f_estatus_garantia As CampoTexto
                    Private f_estatus_serial As CampoTexto
                    Private f_codigo_deposito As CampoTexto
                    Private f_dias_garantia As CampoInteger
                    Private f_detalle As CampoTexto
                    Private f_psv As CampoDecimal
                    Private f_empaque_tipo As CampoTexto
                    Private f_codigo_tasa As CampoTexto
                    Private f_estatus_corte As CampoTexto
                    Private f_x As CampoDecimal
                    Private f_y As CampoDecimal
                    Private f_z As CampoDecimal
                    Private f_corte As CampoTexto
                    Private f_categoria As CampoTexto

                    'CAMPOS NUEVOS AGREGADOS
                    Private f_n_esoferta As CampoTexto
                    Private f_n_espesado As CampoTexto
                    Private f_n_codigobarra As CampoTexto
                    Private f_n_plu As CampoTexto
                    Private f_n_etiq_formato As CampoTexto
                    Private f_n_etiq_depart As CampoTexto
                    Private f_n_etiq_seccion As CampoTexto
                    Private f_n_etiq_vendedor As CampoTexto
                    Private f_n_etiq_plu As CampoTexto
                    Private f_n_etiq_peso As CampoDecimal
                    Private f_n_etiq_precio As CampoDecimal
                    Private f_n_etiq_control As CampoTexto
                    Private f_n_etiq_digitos As CampoTexto
                    Private f_n_etiq_ticket As CampoTexto
                    Private f_n_etiq_numbalanza As CampoTexto
                    Private f_n_etiq_montoitem As CampoDecimal
                    Private f_n_etiq_numitem As CampoInteger
                    Private f_n_etiq_jornada As CampoTexto
                    Private f_n_etiq_operador As CampoTexto
                    Private f_n_forzarmedida As CampoTexto
                    Private f_n_automedida As CampoTexto
                    Private f_n_tipocalculoutilidad As CampoTexto
                    Private f_n_tipomovimiento As CampoTexto
                    Private f_n_auto_item_origen As CampoTexto
                    Private f_n_nombre_corto As CampoTexto

                    'CAMPO USADO PARA ELEBORAR NOTA DE CREDITO, GUARDA LA CANTIDAD REAL DESPACHADA
                    Private XCANTIDAD_DESPACHADA As Decimal


                    Sub New()
                        f_auto_documento = New CampoTexto(10, "auto_documento")
                        f_auto_productos = New CampoTexto(10, "auto_productos")
                        f_codigo = New CampoTexto(15, "codigo")
                        f_nombre = New CampoTexto(200, "nombre")
                        f_auto_departamento = New CampoTexto(10, "auto_departamento")
                        f_auto_grupo = New CampoTexto(10, "auto_grupo")
                        f_auto_subgrupo = New CampoTexto(10, "auto_subgrupo")
                        f_auto_deposito = New CampoTexto(10, "auto_deposito")
                        f_cantidad = New CampoDecimal("cantidad")
                        f_empaque = New CampoTexto(15, "empaque")
                        f_precio_neto = New CampoDecimal("precio_neto")
                        f_descuento1p = New CampoDecimal("descuento1p")
                        f_descuento2p = New CampoDecimal("descuento2p ")
                        f_descuento3p = New CampoDecimal("descuento3p ")
                        f_descuento1 = New CampoDecimal("descuento1")
                        f_descuento2 = New CampoDecimal("descuento2")
                        f_descuento3 = New CampoDecimal("descuento3")
                        f_costo_venta = New CampoDecimal("costo_venta")
                        f_total_neto = New CampoDecimal("total_neto")
                        f_tasa = New CampoDecimal("tasa")
                        f_impuesto = New CampoDecimal("impuesto")
                        f_total = New CampoDecimal("total")
                        f_auto = New CampoTexto(10, "auto")
                        f_estatus = New CampoTexto(1, "estatus")
                        f_fecha = New CampoFecha("fecha")
                        f_tipo = New CampoTexto(2, "tipo")
                        f_deposito = New CampoTexto(20, "deposito")
                        f_signo = New CampoInteger("signo")
                        f_precio_final = New CampoDecimal("precio_final")
                        f_auto_entidad = New CampoTexto(10, "auto_entidad")
                        f_decimales = New CampoInteger("decimales")
                        f_contenido_empaque = New CampoInteger("contenido_empaque")
                        f_cantidad_inventario = New CampoDecimal("cantidad_inventario")
                        f_precio_inventario = New CampoDecimal("precio_inventario")
                        f_costo_inventario = New CampoDecimal("costo_inventario")
                        f_utilidad = New CampoDecimal("utilidad")
                        f_utilidadp = New CampoDecimal("utilidadp")
                        f_precio_item = New CampoDecimal("precio_item")
                        f_estatus_garantia = New CampoTexto(1, "estatus_garantia")
                        f_estatus_serial = New CampoTexto(1, "estatus_serial")
                        f_codigo_deposito = New CampoTexto(10, "codigo_deposito")
                        f_dias_garantia = New CampoInteger("dias_garantia")
                        f_detalle = New CampoTexto(160, "detalle")
                        f_psv = New CampoDecimal("psv")
                        f_empaque_tipo = New CampoTexto(1, "empaque_tipo")
                        f_codigo_tasa = New CampoTexto(1, "codigo_tasa")
                        f_estatus_corte = New CampoTexto(1, "estatus")
                        f_x = New CampoDecimal("x")
                        f_y = New CampoDecimal("y")
                        f_z = New CampoDecimal("z")
                        f_corte = New CampoTexto(1, "corte")
                        f_categoria = New CampoTexto(20, "categoria")

                        f_n_esoferta = New CampoTexto(1, "N_esoferta")
                        f_n_espesado = New CampoTexto(1, "N_espesado")
                        f_n_codigobarra = New CampoTexto(15, "N_codigobarra")
                        f_n_plu = New CampoTexto(15, "N_plu")
                        f_n_etiq_formato = New CampoTexto(15, "N_etiq_formato")
                        f_n_etiq_depart = New CampoTexto(15, "N_etiq_depart")
                        f_n_etiq_seccion = New CampoTexto(15, "N_etiq_seccion")
                        f_n_etiq_vendedor = New CampoTexto(15, "N_etiq_vendedor")
                        f_n_etiq_plu = New CampoTexto(15, "N_etiq_plu")
                        f_n_etiq_peso = New CampoDecimal("N_etiq_peso")
                        f_n_etiq_precio = New CampoDecimal("N_etiq_precio")
                        f_n_etiq_control = New CampoTexto(15, "N_etiq_control")
                        f_n_etiq_digitos = New CampoTexto(15, "N_etiq_digitos")
                        f_n_etiq_ticket = New CampoTexto(15, "N_etiq_ticket")
                        f_n_etiq_numbalanza = New CampoTexto(15, "N_etiq_numbalanza")
                        f_n_etiq_montoitem = New CampoDecimal("N_etiq_montoitem")
                        f_n_etiq_numitem = New CampoInteger("N_etiq_numitem")
                        f_n_etiq_jornada = New CampoTexto(10, "N_auto_jornada")
                        f_n_etiq_operador = New CampoTexto(10, "N_auto_operador")
                        f_n_forzarmedida = New CampoTexto(10, "N_forzarmedida")
                        f_n_automedida = New CampoTexto(10, "N_automedida")
                        f_n_tipocalculoutilidad = New CampoTexto(1, "N_TipoCalculoUtilidad")
                        f_n_tipomovimiento = New CampoTexto(1, "N_TipoMovimiento")
                        f_n_auto_item_origen = New CampoTexto(10, "n_auto_item_origen")
                        f_n_nombre_corto = New CampoTexto(40, "n_nombre_corto")

                        _CampoAyuda_CantidadDespachada = 0

                        Me.M_LimpiarRegistro()
                    End Sub


                    ''' <summary>
                    ''' CAMPO USADO PARA INDICAR LA CANTIDAD DESPACHADA EN VENTA
                    ''' ME PERMITE COMPARAR CON LAS NOTAS DE CREDITO X DEVOLUCION SI EXCEDE / NO
                    ''' </summary>
                    Property _CampoAyuda_CantidadDespachada() As Decimal
                        Get
                            Return XCANTIDAD_DESPACHADA
                        End Get
                        Set(ByVal value As Decimal)
                            XCANTIDAD_DESPACHADA = value
                        End Set
                    End Property

                    Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return Me.c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_productos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_productos = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return Me.c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' DESCRIPCION GENERAL DEL PRODUCTO DESPACHADO, LARGA
                    ''' </summary>
                    Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' DESCRIPCION GENERAL DEL PRODUCTO DESPACHADO, LARGA
                    ''' </summary>
                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return Me.c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoDepartamento() As CampoTexto
                        Get
                            Return f_auto_departamento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_departamento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDepartamento() As String
                        Get
                            Return Me.c_AutoDepartamento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_AutoGrupo.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoSubGrupo() As CampoTexto
                        Get
                            Return f_auto_subgrupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_subgrupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoSubGrupo() As String
                        Get
                            Return Me.c_AutoSubGrupo.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoDeposito() As CampoTexto
                        Get
                            Return f_auto_deposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return Me.c_AutoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CantidadDespachada() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadDespachada() As Decimal
                        Get
                            Return Me.c_CantidadDespachada.c_Valor
                        End Get
                    End Property

                    Property c_NombreEmpaque() As CampoTexto
                        Get
                            Return f_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return Me.c_NombreEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    Property c_DescuentoTasa_1() As CampoDecimal
                        Get
                            Return f_descuento1p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1p = value
                        End Set
                    End Property

                    ReadOnly Property _Tasa_Descuento1() As Decimal
                        Get
                            Return Me.c_DescuentoTasa_1.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoTasa_2() As CampoDecimal
                        Get
                            Return f_descuento2p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2p = value
                        End Set
                    End Property

                    ReadOnly Property _Tasa_Descuento2() As Decimal
                        Get
                            Return Me.c_DescuentoTasa_2.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoTasa_3() As CampoDecimal
                        Get
                            Return f_descuento3p
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento3p = value
                        End Set
                    End Property

                    ReadOnly Property _Tasa_Descuento3() As Decimal
                        Get
                            Return Me.c_DescuentoTasa_3.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoMonto_1() As CampoDecimal
                        Get
                            Return f_descuento1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento1 = value
                        End Set
                    End Property

                    ReadOnly Property _Monto_Descuento1() As Decimal
                        Get
                            Return Me.c_DescuentoMonto_1.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoMonto_2() As CampoDecimal
                        Get
                            Return f_descuento2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento2 = value
                        End Set
                    End Property

                    ReadOnly Property _Monto_Descuento2() As Decimal
                        Get
                            Return Me.c_DescuentoMonto_2.c_Valor
                        End Get
                    End Property

                    Property c_DescuentoMonto_3() As CampoDecimal
                        Get
                            Return f_descuento3
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuento3 = value
                        End Set
                    End Property

                    ReadOnly Property _Monto_Descuento3() As Decimal
                        Get
                            Return Me.c_DescuentoMonto_3.c_Valor
                        End Get
                    End Property

                    Property c_TotalNeto() As CampoDecimal
                        Get
                            Return f_total_neto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total_neto = value
                        End Set
                    End Property

                    ReadOnly Property _TotalNeto() As Decimal
                        Get
                            Return Me.c_TotalNeto.c_Valor
                        End Get
                    End Property

                    Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_tasa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return Me.c_TasaIva.c_Valor
                        End Get
                    End Property

                    Property c_MontoIva() As CampoDecimal
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_impuesto = value
                        End Set
                    End Property

                    ReadOnly Property _MontoIva() As Decimal
                        Get
                            Return Me.c_MontoIva.c_Valor
                        End Get
                    End Property

                    Property c_TotalGeneral() As CampoDecimal
                        Get
                            Return f_total
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total = value
                        End Set
                    End Property

                    ReadOnly Property _TotalGeneral() As Decimal
                        Get
                            Return Me.c_TotalGeneral.c_Valor
                        End Get
                    End Property

                    Property c_AutoItem() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Return Me.c_AutoItem.c_Texto.Trim
                        End Get
                    End Property

                    Property c_TipoTasaIva() As CampoTexto
                        Get
                            Return f_codigo_tasa
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As String
                        Get
                            Return Me.c_TipoTasaIva.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property

                    Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return Me.c_FechaEmision.c_Valor
                        End Get
                    End Property

                    Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim.ToUpper
                                Case "01" : Return TipoDocumentoVentaRegistrado.Factura
                                Case "02" : Return TipoDocumentoVentaRegistrado.NotaDebito
                                Case "03" : Return TipoDocumentoVentaRegistrado.NotaCredito
                                Case "04" : Return TipoDocumentoVentaRegistrado.NotaEntrega
                                Case "05" : Return TipoDocumentoVentaRegistrado.Presupuesto
                                Case "06" : Return TipoDocumentoVentaRegistrado.Pedido
                            End Select
                        End Get
                    End Property

                    Property c_NombreDeposito() As CampoTexto
                        Get
                            Return f_deposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _NombreDeposito() As String
                        Get
                            Return Me.c_NombreDeposito.c_Texto.Trim
                        End Get
                    End Property

                    Property c_SignoDocumento() As CampoInteger
                        Get
                            Return f_signo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_signo = value
                        End Set
                    End Property

                    ReadOnly Property _SignoDocumento() As Integer
                        Get
                            Return Me.c_SignoDocumento.c_Valor
                        End Get
                    End Property

                    Property c_AutoCliente() As CampoTexto
                        Get
                            Return f_auto_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return Me.c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NumeroDecimales() As CampoInteger
                        Get
                            Return f_decimales
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_decimales = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroDecimales() As Integer
                        Get
                            Return Me.c_NumeroDecimales.c_Valor
                        End Get
                    End Property

                    Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenido_empaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    Property c_CantidadUnidadInventario() As CampoDecimal
                        Get
                            Return f_cantidad_inventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad_inventario = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadUnidadInventario() As Decimal
                        Get
                            Return Me.c_CantidadUnidadInventario.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Costo En Unidad De Inventario
                    ''' </summary>
                    Property c_CostoInventario() As CampoDecimal
                        Get
                            Return f_costo_inventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo_inventario = value
                        End Set
                    End Property

                    ReadOnly Property _CostoInventario() As Decimal
                        Get
                            Return Me.c_CostoInventario.c_Valor
                        End Get
                    End Property

                    Property c_PrecioNeto() As CampoDecimal
                        Get
                            Return f_precio_neto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_neto = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNeto() As Decimal
                        Get
                            Return Me.c_PrecioNeto.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' PRECIO DE VENTA DEL PRODUCTO, ANTES DE LOS DESCUENTOS LINEAL Y (DESCUENTOS Y CARGOS) GLOBAL
                    ''' </summary>
                    ReadOnly Property _PrecioDeVenta() As Precio
                        Get
                            Dim x As New Precio(_PrecioNeto, _TasaIva)
                            Return x
                        End Get
                    End Property

                    ''' <summary>
                    ''' Costo de Venta Total, Usado Para El Calculo De La Ganancia
                    ''' </summary>
                    Property c_CostoVenta() As CampoDecimal
                        Get
                            Return f_costo_venta
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo_venta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Costo de Venta Total, Usado Para El Calculo De La Ganancia
                    ''' </summary>
                    ReadOnly Property _CostoVenta() As Decimal
                        Get
                            Return Me.c_CostoVenta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Costo de Venta del Empaque
                    ''' </summary>
                    ReadOnly Property _CostoVentaEmpaque() As Decimal
                        Get
                            Return Decimal.Round(Me._CostoVenta / Me._CantidadDespachada, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Property c_PrecioFinal() As CampoDecimal
                        Get
                            Return f_precio_final
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_final = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioFinal() As Decimal
                        Get
                            Return Me.c_PrecioFinal.c_Valor
                        End Get
                    End Property

                    Property c_PrecioInventario() As CampoDecimal
                        Get
                            Return f_precio_inventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_inventario = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioInventario() As Precio
                        Get
                            Dim x As New Precio(Me.c_PrecioInventario.c_Valor, Me._TasaIva)
                            Return x
                        End Get
                    End Property

                    Property c_UtilidadMonto() As CampoDecimal
                        Get
                            Return f_utilidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_utilidad = value
                        End Set
                    End Property

                    ReadOnly Property _UtilidadMonto() As Decimal
                        Get
                            Return Me.c_UtilidadMonto.c_Valor
                        End Get
                    End Property

                    Property c_UtilidadTasa() As CampoDecimal
                        Get
                            Return f_utilidadp
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_utilidadp = value
                        End Set
                    End Property

                    ReadOnly Property _UtilidadTasa() As Decimal
                        Get
                            Return Me.c_UtilidadTasa.c_Valor
                        End Get
                    End Property

                    Property c_PrecioItem() As CampoDecimal
                        Get
                            Return f_precio_item
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_item = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioItem() As Decimal
                        Get
                            Return Me.c_PrecioItem.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PrecioItem_FullIva() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = Me._PrecioItem + (Me._PrecioItem * Me._TasaIva / 100)
                            Return Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    ReadOnly Property _PrecioLiquida() As Decimal
                        Get
                            Dim x As Decimal = 0
                            x = Me._PrecioItem_FullIva / Me._ContenidoEmpaque
                            Return Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Property c_EstatusGarantia() As CampoTexto
                        Get
                            Return f_estatus_garantia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_garantia = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusGarantia() As TipoEstatus
                        Get
                            If Me.c_EstatusGarantia.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Property c_EstatusSerial() As CampoTexto
                        Get
                            Return f_estatus_serial
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_serial = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusSerial() As TipoEstatus
                        Get
                            If Me.c_EstatusSerial.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Property c_CodigoDeposito() As CampoTexto
                        Get
                            Return f_codigo_deposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoDeposito() As String
                        Get
                            Return Me.c_CodigoDeposito.c_Texto
                        End Get
                    End Property

                    Property c_DiasGarantia() As CampoInteger
                        Get
                            Return f_dias_garantia
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_garantia = value
                        End Set
                    End Property

                    ReadOnly Property _DiasGarantia() As Integer
                        Get
                            Return Me.c_DiasGarantia.c_Valor
                        End Get
                    End Property

                    Property c_DetalleNotas() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    ReadOnly Property _DetalleNotas() As String
                        Get
                            Return Me.c_DetalleNotas.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PrecioSugerido() As CampoDecimal
                        Get
                            Return f_psv
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_psv = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioSugerido() As Decimal
                        Get
                            Return Me.c_PrecioSugerido.c_Valor
                        End Get
                    End Property

                    Property c_ReferenciaEmpaque() As CampoTexto
                        Get
                            Return f_empaque_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpaque() As String
                        Get
                            Return Me.c_ReferenciaEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    Property c_EstatusCorte() As CampoTexto
                        Get
                            Return f_estatus_corte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_corte = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusCorte() As TipoEstatus
                        Get
                            If Me.c_EstatusCorte.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Property c_Corte_X() As CampoDecimal
                        Get
                            Return f_x
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_x = value
                        End Set
                    End Property

                    ReadOnly Property _CorteX() As Decimal
                        Get
                            Return Me.c_Corte_X.c_Valor
                        End Get
                    End Property

                    Property c_Corte_Y() As CampoDecimal
                        Get
                            Return f_y
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_y = value
                        End Set
                    End Property

                    ReadOnly Property _CorteY() As Decimal
                        Get
                            Return Me.c_Corte_Y.c_Valor
                        End Get
                    End Property

                    Property c_Corte_Z() As CampoDecimal
                        Get
                            Return f_z
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_z = value
                        End Set
                    End Property

                    ReadOnly Property _CorteZ() As Decimal
                        Get
                            Return Me.c_Corte_Z.c_Valor
                        End Get
                    End Property

                    Property c_Corte() As CampoTexto
                        Get
                            Return f_corte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_corte = value
                        End Set
                    End Property

                    ReadOnly Property _Corte() As String
                        Get
                            Return Me.c_Corte.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CategoriaProducto() As CampoTexto
                        Get
                            Return f_categoria
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_categoria = value
                        End Set
                    End Property

                    ReadOnly Property _CategoriaProducto() As String
                        Get
                            Return Me.c_CategoriaProducto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_EstaEnOferta() As CampoTexto
                        Get
                            Return f_n_esoferta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_EstaEnOferta() As TipoEstatus
                        Get
                            If Me.c_PTO_EstaEnOferta.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Property c_PTO_EsPesado() As CampoTexto
                        Get
                            Return f_n_espesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_espesado = value
                        End Set
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

                    Property c_PTO_CodigoBarra() As CampoTexto
                        Get
                            Return f_n_codigobarra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_CodigoBarra() As String
                        Get
                            Return Me.c_PTO_CodigoBarra.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_Plu() As CampoTexto
                        Get
                            Return f_n_plu
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_Plu() As String
                        Get
                            Return Me.c_PTO_Plu.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_FormatoEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_formato
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_formato = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_FormatoEtiqueta() As String
                        Get
                            Return Me.c_PTO_FormatoEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_SeccionEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_seccion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_seccion = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_SeccionEtiqueta() As String
                        Get
                            Return Me.c_PTO_SeccionEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_NumeroDepartEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_depart
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_depart = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_NumeroDepartEtiqueta() As String
                        Get
                            Return Me.c_PTO_NumeroDepartEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_VendedorEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_vendedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_VendedorEtiqueta() As String
                        Get
                            Return Me.c_PTO_VendedorEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_PluEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_plu
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_PluEtiqueta() As String
                        Get
                            Return Me.c_PTO_PluEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_PesoEtiqueta() As CampoDecimal
                        Get
                            Return f_n_etiq_peso
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_etiq_peso = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_PesoEtiqueta() As Decimal
                        Get
                            Return c_PTO_PesoEtiqueta.c_Valor
                        End Get
                    End Property

                    Property c_PTO_PrecioEtiqueta() As CampoDecimal
                        Get
                            Return f_n_etiq_precio
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_etiq_precio = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_PrecioEtiqueta() As Decimal
                        Get
                            Return c_PTO_PrecioEtiqueta.c_Valor
                        End Get
                    End Property

                    Property c_PTO_NumeroControlEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_control
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_control = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_NumeroControlEtiqueta() As String
                        Get
                            Return c_PTO_NumeroControlEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_DigitosEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_digitos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_digitos = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_DigitosEtiqueta() As String
                        Get
                            Return c_PTO_DigitosEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_NumeroTicketEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_ticket
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_ticket = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_NumeroTicketEtiqueta() As String
                        Get
                            Return c_PTO_NumeroTicketEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_NumeroBalanzaEtiqueta() As CampoTexto
                        Get
                            Return f_n_etiq_numbalanza
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_numbalanza = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_NumeroBalanzaEtiqueta() As String
                        Get
                            Return c_PTO_NumeroBalanzaEtiqueta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_MontoTotalEtiqueta() As CampoDecimal
                        Get
                            Return f_n_etiq_montoitem
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_n_etiq_montoitem = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_MontoTotalEtiqueta() As Decimal
                        Get
                            Return c_PTO_MontoTotalEtiqueta.c_Valor
                        End Get
                    End Property

                    Property c_PTO_NumeroItemEtiqueta() As CampoInteger
                        Get
                            Return f_n_etiq_numitem
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_n_etiq_numitem = value
                        End Set
                    End Property

                    ReadOnly Property _PTO_NumeroItemEtiqueta() As Integer
                        Get
                            Return Me.c_PTO_NumeroItemEtiqueta.c_Valor
                        End Get
                    End Property

                    Property c_PTO_AutoJornada() As CampoTexto
                        Get
                            Return f_n_etiq_jornada
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_control = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Para El Pto de venta
                    ''' Retorna el Auto De la Jornada
                    ''' </summary>
                    ReadOnly Property _AutoJornada() As String
                        Get
                            Return Me.c_PTO_AutoJornada.c_Texto.Trim
                        End Get
                    End Property

                    Property c_PTO_AutoOperador() As CampoTexto
                        Get
                            Return f_n_etiq_operador
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_etiq_operador = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Para El Pto de venta
                    ''' Retorna el Auto Del Operador de la jornada
                    ''' </summary>
                    ReadOnly Property _AutoOperador() As String
                        Get
                            Return Me.c_PTO_AutoOperador.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_n_automedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_automedida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return Me.c_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' DATOS DE LA UNIDAD DE MEDIDA DEL PRODUCTO COMO:  NOMBRE, CANTIDAD DE DIGISITOS USADOS
                    ''' </summary>
                    ReadOnly Property _f_FichaMedida() As FichaProducto.Prd_Medida.c_Registro
                        Get
                            Try
                                Dim xficha As New FichaProducto.Prd_Medida
                                xficha.F_BuscarMedida(Me._AutoMedida)
                                Return xficha.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
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

                    Property c_ForzarMedida() As CampoTexto
                        Get
                            Return f_n_forzarmedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_forzarmedida = value
                        End Set
                    End Property

                    ReadOnly Property _ForzarMedida() As String
                        Get
                            Return Me.c_ForzarMedida.c_Texto.Trim
                        End Get
                    End Property

                    Property c_TipoCalculoUtilidad() As CampoTexto
                        Get
                            Return f_n_tipocalculoutilidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_tipocalculoutilidad = value
                        End Set
                    End Property

                    ReadOnly Property _TipoCalculoUtilidad() As TipoCalculoUtilidad
                        Get
                            If Me.c_TipoCalculoUtilidad.c_Texto.Trim.ToUpper = "C" Then
                                Return TipoCalculoUtilidad.BaseAlCosto
                            Else
                                Return TipoCalculoUtilidad.BaseAlPrecioVenta
                            End If
                        End Get
                    End Property

                    Property c_TipoMovimiento() As CampoTexto
                        Get
                            Return f_n_tipomovimiento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_tipomovimiento = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMovimientoEfectuado() As TipoMovimientoDetalle
                        Get
                            Select Case Me.c_TipoMovimiento.c_Texto.Trim.ToUpper
                                Case "V" : Return TipoMovimientoDetalle.Venta
                                Case "A" : Return TipoMovimientoDetalle.Ajuste
                                Case "D" : Return TipoMovimientoDetalle.Devolucion
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' INDICAR EL ITEM ORIGEN EN TABLA VENTAS DETALLE AL CUAL SE LE APLICO LA DEVOLUCION PARA NC
                    ''' </summary>
                    Property c_AutoItemOrigen() As CampoTexto
                        Get
                            Return f_n_auto_item_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_auto_item_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' INDICAR EL ITEM ORIGEN EN TABLA VENTAS DETALLE AL CUAL SE LE APLICO LA DEVOLUCION PARA NC
                    ''' </summary>
                    ReadOnly Property _AutoItemOrigen() As String
                        Get
                            Return Me.c_AutoItemOrigen.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' DESCRIPCION CORTA DEL PRODUCTO DESPACHADO, CORTA DE 40 CARACT PARA USO FISCAL
                    ''' </summary>
                    Property c_NombreCortoProducto() As CampoTexto
                        Get
                            Return f_n_nombre_corto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_nombre_corto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' DESCRIPCION CORTA DEL PRODUCTO DESPACHADO, CORTA DE 40 CARACT PARA USO FISCAL
                    ''' </summary>
                    ReadOnly Property _NombreCortoProducto() As String
                        Get
                            Return Me.c_NombreCortoProducto.c_Texto.Trim
                        End Get
                    End Property


                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub M_CargarFicha(ByVal dr As DataRow)
                        Try
                            M_LimpiarRegistro()
                            With Me
                                c_AutoCliente.c_Texto = dr(c_AutoCliente.c_NombreInterno)
                                c_AutoDepartamento.c_Texto = dr(c_AutoDepartamento.c_NombreInterno)
                                c_AutoDeposito.c_Texto = dr(c_AutoDeposito.c_NombreInterno)
                                c_AutoDocumento.c_Texto = dr(c_AutoDocumento.c_NombreInterno)
                                c_AutoGrupo.c_Texto = dr(c_AutoGrupo.c_NombreInterno)
                                c_AutoItem.c_Texto = dr(c_AutoItem.c_NombreInterno)
                                c_AutoProducto.c_Texto = dr(c_AutoProducto.c_NombreInterno)
                                c_AutoSubGrupo.c_Texto = dr(c_AutoSubGrupo.c_NombreInterno)
                                c_CantidadDespachada.c_Valor = dr(c_CantidadDespachada.c_NombreInterno)
                                c_CantidadUnidadInventario.c_Valor = dr(c_CantidadUnidadInventario.c_NombreInterno)
                                c_CategoriaProducto.c_Texto = dr(c_CategoriaProducto.c_NombreInterno)
                                c_CodigoDeposito.c_Texto = dr(c_CodigoDeposito.c_NombreInterno)
                                c_ContenidoEmpaque.c_Valor = dr(c_ContenidoEmpaque.c_NombreInterno)
                                c_CodigoProducto.c_Texto = dr(c_CodigoProducto.c_NombreInterno)
                                c_Corte.c_Texto = dr(c_Corte.c_NombreInterno)
                                c_Corte_X.c_Valor = dr(c_Corte_X.c_NombreInterno)
                                c_Corte_Y.c_Valor = dr(c_Corte_Y.c_NombreInterno)
                                c_Corte_Z.c_Valor = dr(c_Corte_Z.c_NombreInterno)
                                c_CostoInventario.c_Valor = dr(c_CostoInventario.c_NombreInterno)
                                c_CostoVenta.c_Valor = dr(c_CostoVenta.c_NombreInterno)

                                c_DescuentoMonto_1.c_Valor = dr(c_DescuentoMonto_1.c_NombreInterno)
                                c_DescuentoMonto_2.c_Valor = dr(c_DescuentoMonto_2.c_NombreInterno)
                                c_DescuentoMonto_3.c_Valor = dr(c_DescuentoMonto_3.c_NombreInterno)
                                c_DescuentoTasa_1.c_Valor = dr(c_DescuentoTasa_1.c_NombreInterno)
                                c_DescuentoTasa_2.c_Valor = dr(c_DescuentoTasa_2.c_NombreInterno)
                                c_DescuentoTasa_3.c_Valor = dr(c_DescuentoTasa_3.c_NombreInterno)
                                c_DetalleNotas.c_Texto = dr(c_DetalleNotas.c_NombreInterno)
                                c_DiasGarantia.c_Valor = dr(c_DiasGarantia.c_NombreInterno)
                                c_Estatus.c_Texto = dr(c_Estatus.c_NombreInterno)
                                c_EstatusCorte.c_Texto = dr(c_EstatusCorte.c_NombreInterno)
                                c_EstatusGarantia.c_Texto = dr(c_EstatusGarantia.c_NombreInterno)
                                c_EstatusSerial.c_Texto = dr(c_EstatusSerial.c_NombreInterno)
                                c_FechaEmision.c_Valor = dr(c_FechaEmision.c_NombreInterno)
                                c_MontoIva.c_Valor = dr(c_MontoIva.c_NombreInterno)
                                c_NombreDeposito.c_Texto = dr(c_NombreDeposito.c_NombreInterno)
                                c_NombreEmpaque.c_Texto = dr(c_NombreEmpaque.c_NombreInterno)
                                c_NombreProducto.c_Texto = dr(c_NombreProducto.c_NombreInterno)
                                c_NumeroDecimales.c_Valor = dr(c_NumeroDecimales.c_NombreInterno)
                                c_PrecioFinal.c_Valor = dr(c_PrecioFinal.c_NombreInterno)
                                c_PrecioInventario.c_Valor = dr(c_PrecioInventario.c_NombreInterno)
                                c_PrecioItem.c_Valor = dr(c_PrecioItem.c_NombreInterno)
                                c_PrecioNeto.c_Valor = dr(c_PrecioNeto.c_NombreInterno)
                                c_PrecioSugerido.c_Valor = dr(c_PrecioSugerido.c_NombreInterno)

                                If Not IsDBNull(dr(c_PTO_AutoJornada.c_NombreInterno)) Then
                                    c_PTO_AutoJornada.c_Texto = dr(c_PTO_AutoJornada.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_AutoOperador.c_NombreInterno)) Then
                                    c_PTO_AutoOperador.c_Texto = dr(c_PTO_AutoOperador.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_CodigoBarra.c_NombreInterno)) Then
                                    c_PTO_CodigoBarra.c_Texto = dr(c_PTO_CodigoBarra.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_DigitosEtiqueta.c_NombreInterno)) Then
                                    c_PTO_DigitosEtiqueta.c_Texto = dr(c_PTO_DigitosEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_EsPesado.c_NombreInterno)) Then
                                    c_PTO_EsPesado.c_Texto = dr(c_PTO_EsPesado.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_EstaEnOferta.c_NombreInterno)) Then
                                    c_PTO_EstaEnOferta.c_Texto = dr(c_PTO_EstaEnOferta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_FormatoEtiqueta.c_NombreInterno)) Then
                                    c_PTO_FormatoEtiqueta.c_Texto = dr(c_PTO_FormatoEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_MontoTotalEtiqueta.c_NombreInterno)) Then
                                    c_PTO_MontoTotalEtiqueta.c_Valor = dr(c_PTO_MontoTotalEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_NumeroBalanzaEtiqueta.c_NombreInterno)) Then
                                    c_PTO_NumeroBalanzaEtiqueta.c_Texto = dr(c_PTO_NumeroBalanzaEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_NumeroControlEtiqueta.c_NombreInterno)) Then
                                    c_PTO_NumeroControlEtiqueta.c_Texto = dr(c_PTO_NumeroControlEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_NumeroDepartEtiqueta.c_NombreInterno)) Then
                                    c_PTO_NumeroDepartEtiqueta.c_Texto = dr(c_PTO_NumeroDepartEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_NumeroItemEtiqueta.c_NombreInterno)) Then
                                    c_PTO_NumeroItemEtiqueta.c_Valor = dr(c_PTO_NumeroItemEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_NumeroTicketEtiqueta.c_NombreInterno)) Then
                                    c_PTO_NumeroTicketEtiqueta.c_Texto = dr(c_PTO_NumeroTicketEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_PesoEtiqueta.c_NombreInterno)) Then
                                    c_PTO_PesoEtiqueta.c_Valor = dr(c_PTO_PesoEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_Plu.c_NombreInterno)) Then
                                    c_PTO_Plu.c_Texto = dr(c_PTO_Plu.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_PluEtiqueta.c_NombreInterno)) Then
                                    c_PTO_PluEtiqueta.c_Texto = dr(c_PTO_PluEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_PrecioEtiqueta.c_NombreInterno)) Then
                                    c_PTO_PrecioEtiqueta.c_Valor = dr(c_PTO_PrecioEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_SeccionEtiqueta.c_NombreInterno)) Then
                                    c_PTO_SeccionEtiqueta.c_Texto = dr(c_PTO_SeccionEtiqueta.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_PTO_VendedorEtiqueta.c_NombreInterno)) Then
                                    c_PTO_VendedorEtiqueta.c_Texto = dr(c_PTO_VendedorEtiqueta.c_NombreInterno)
                                End If

                                If Not IsDBNull(dr(c_ForzarMedida.c_NombreInterno)) Then
                                    c_ForzarMedida.c_Texto = dr(c_ForzarMedida.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_AutoMedida.c_NombreInterno)) Then
                                    c_AutoMedida.c_Texto = dr(c_AutoMedida.c_NombreInterno)
                                End If

                                If Not IsDBNull(dr(c_TipoCalculoUtilidad.c_NombreInterno)) Then
                                    c_TipoCalculoUtilidad.c_Texto = dr(c_TipoCalculoUtilidad.c_NombreInterno)
                                End If
                                If Not IsDBNull(dr(c_TipoMovimiento.c_NombreInterno)) Then
                                    c_TipoMovimiento.c_Texto = dr(c_TipoMovimiento.c_NombreInterno)
                                End If

                                If Not IsDBNull(dr(c_AutoItemOrigen.c_NombreInterno)) Then
                                    c_AutoItemOrigen.c_Texto = dr(c_AutoItemOrigen.c_NombreInterno)
                                End If

                                If Not IsDBNull(dr(c_NombreCortoProducto.c_NombreInterno)) Then
                                    c_NombreCortoProducto.c_Texto = dr(c_NombreCortoProducto.c_NombreInterno)
                                End If

                                c_ReferenciaEmpaque.c_Texto = dr(c_ReferenciaEmpaque.c_NombreInterno)
                                c_SignoDocumento.c_Valor = dr(c_SignoDocumento.c_NombreInterno)
                                c_TasaIva.c_Valor = dr(c_TasaIva.c_NombreInterno)
                                c_TipoDocumento.c_Texto = dr(c_TipoDocumento.c_NombreInterno)
                                c_TipoTasaIva.c_Texto = dr(c_TipoTasaIva.c_NombreInterno)
                                c_TotalGeneral.c_Valor = dr(c_TotalGeneral.c_NombreInterno)
                                c_TotalNeto.c_Valor = dr(c_TotalNeto.c_NombreInterno)
                                c_UtilidadMonto.c_Valor = dr(c_UtilidadMonto.c_NombreInterno)
                                c_UtilidadTasa.c_Valor = dr(c_UtilidadTasa.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR DETALLE REGISTRO VENTA" + vbCrLf + ex.Message)
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
                                xadap.SelectCommand.CommandText = "select * from ventas_detalle where auto_documento=@autodoc and auto=@auto"
                                xadap.SelectCommand.Parameters.AddWithValue("@autodoc", xdoc)
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", xitem)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                M_CargarFicha(xtb(0))
                                Return True
                            Else
                                Throw New Exception("ITEM NO ENCONTRADO")
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Function
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

                Function F_BuscarCargar(ByVal xautodoc As String, ByVal xautoitem As String) As Boolean
                    Try
                        Me.RegistroDato.BuscarCargar(xautodoc, xautoitem)
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Class V_VentasMedida
                Class c_Registro
                    Private f_auto_documento As CampoTexto
                    Private f_auto_medida As CampoTexto
                    Private f_total_medida As CampoDecimal
                    Private f_decimales As CampoTexto
                    Private f_nombre As CampoTexto

                    Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return Me.c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_auto_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_medida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return Me.c_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CantidadEmpaques() As CampoDecimal
                        Get
                            Return f_total_medida
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total_medida = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadEmpaque() As Decimal
                        Get
                            Return Me.c_CantidadEmpaques.c_Valor
                        End Get
                    End Property

                    Property c_DecimalesEmpaque() As CampoTexto
                        Get
                            Return f_decimales
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_decimales = value
                        End Set
                    End Property

                    ReadOnly Property _DecimalesEmpaque() As Integer
                        Get
                            Dim xd As Integer = 0
                            Integer.TryParse(Me.c_DecimalesEmpaque.c_Texto, xd)
                            Return xd
                        End Get
                    End Property

                    Property c_NombreEmpaque() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return Me.c_NombreEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        Me.c_AutoMedida = New CampoTexto(10, "auto_medida")
                        Me.c_CantidadEmpaques = New CampoDecimal("total_medida")
                        Me.c_DecimalesEmpaque = New CampoTexto(1, "decimales")
                        Me.c_NombreEmpaque = New CampoTexto(20, "nombre")
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
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
            End Class

            Class V_RetencionesIva
                Class AgregarRetencionIva
                    Private xautousuario As String = ""
                    Private xautocobrador As String = ""
                    Private xnombreusuario As String = ""
                    Private xnombrecobrador As String = ""

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

                    Property _AutoUsuario() As String
                        Protected Friend Get
                            Return xautousuario
                        End Get
                        Set(ByVal value As String)
                            xautousuario = value
                        End Set
                    End Property

                    Property _NombreUsuario() As String
                        Protected Friend Get
                            Return xnombreusuario
                        End Get
                        Set(ByVal value As String)
                            xnombreusuario = value
                        End Set
                    End Property

                    Property _AutoCobrador() As String
                        Protected Friend Get
                            Return xautocobrador
                        End Get
                        Set(ByVal value As String)
                            xautocobrador = value
                        End Set
                    End Property

                    Property _NombreCobrador() As String
                        Protected Friend Get
                            Return xnombrecobrador
                        End Get
                        Set(ByVal value As String)
                            xnombrecobrador = value
                        End Set
                    End Property

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
                    WriteOnly Property _NombreCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreCliente.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _DirFiscalCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DirFiscalCliente.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CiRifCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CiRifCliente.c_Texto = value
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
                            Me.RegistroDato.c_MontoTotalGeneral.c_Valor = value
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
                    WriteOnly Property _AutoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoCliente.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Codigocliente.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_Registro
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

                    'NUEVOS
                    Private f_auto_cxc As CampoTexto
                    Private f_auto_recibo_cxc As CampoTexto


                    Protected Friend Property c_AutoCxc_Pago() As CampoTexto
                        Get
                            Return f_auto_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCxC_Pago() As String
                        Get
                            Return Me.c_AutoCxc_Pago.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoReciboCxC_Pago() As CampoTexto
                        Get
                            Return f_auto_recibo_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_recibo_cxc = value
                        End Set
                    End Property

                    ReadOnly Property _AutoReciboCxC_Pago() As String
                        Get
                            Return Me.c_AutoReciboCxC_Pago.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_NumeroPlanillaRetencion() As CampoTexto
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

                    Protected Friend Property c_NombreCliente() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property
                    Protected Friend Property c_DirFiscalCliente() As CampoTexto
                        Get
                            Return f_dir_fiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dir_fiscal = value
                        End Set
                    End Property
                    Protected Friend Property c_CiRifCliente() As CampoTexto
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
                    Protected Friend Property c_MontoTotalGeneral() As CampoDecimal
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
                    Protected Friend Property c_AutoCliente() As CampoTexto
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
                    Protected Friend Property c_Codigocliente() As CampoTexto
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

                    ReadOnly Property _Auto() As String
                        Get
                            Return c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroPlanilla() As String
                        Get
                            Return c_NumeroPlanillaRetencion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return c_FechaEmision.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NombreCliente() As String
                        Get
                            Return c_NombreCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _DirFiscalCliente() As String
                        Get
                            Return c_DirFiscalCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifCliente() As String
                        Get
                            Return c_CiRifCliente.c_Texto.Trim
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

                    ReadOnly Property _MontoTotalGeneral() As Decimal
                        Get
                            Return c_MontoTotalGeneral.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _Retencion() As Tasa_Valor
                        Get
                            Return New Tasa_Valor(c_TasaRetencion.c_Valor, c_MontoRetencion.c_Valor)
                        End Get
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaRelacion() As Date
                        Get
                            Return c_FechaRelacion.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Codigocliente() As String
                        Get
                            Return c_Codigocliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AnoRelacion() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.c_AnoRelacion.c_Texto, x)
                            Return x
                        End Get
                    End Property

                    ReadOnly Property _MesRelacion() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.c_MesRelacion.c_Texto, x)
                            Return x
                        End Get
                    End Property

                    Sub New()
                        f_auto = New CampoTexto(10, "auto")
                        f_documento = New CampoTexto(14, "documento")
                        f_fecha = New CampoFecha("fecha")
                        f_nombre = New CampoTexto(120, "nombre")
                        f_ci_rif = New CampoTexto(12, "ci_rif")
                        f_tipo = New CampoTexto(2, "tipo")
                        f_exento = New CampoDecimal("exento")
                        f_base = New CampoDecimal("base")
                        f_impuesto = New CampoDecimal("impuesto")
                        f_total = New CampoDecimal("total")
                        f_tasa_retencion = New CampoDecimal("tasa_retencion")
                        f_retencion = New CampoDecimal("retencion")
                        f_auto_entidad = New CampoTexto(10, "auto_entidad")
                        f_fecha_relacion = New CampoFecha("fecha_relacion")
                        f_codigo_entidad = New CampoTexto(15, "codigo_entidad")
                        f_ano_relacion = New CampoTexto(4, "ano_relacion")
                        f_mes_relacion = New CampoTexto(2, "mes_relacion")
                        f_dir_fiscal = New CampoTexto(120, "dir_fiscal")

                        ' Nuevos
                        f_auto_cxc = New CampoTexto(10, "auto_cxc")
                        f_auto_recibo_cxc = New CampoTexto(10, "auto_recibo_cxc")
                    End Sub

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()
                            With Me
                                .c_Auto.c_Texto = xrow(.c_Auto.c_NombreInterno)
                                .c_NumeroPlanillaRetencion.c_Texto = xrow(.c_NumeroPlanillaRetencion.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_NombreCliente.c_Texto = xrow(.c_NombreCliente.c_NombreInterno)
                                .c_DirFiscalCliente.c_Texto = xrow(.c_DirFiscalCliente.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(.c_CiRifCliente.c_NombreInterno)
                                .c_TipoDocumentoRetencion.c_Texto = xrow(.c_TipoDocumentoRetencion.c_NombreInterno)
                                .c_MontoExento.c_Valor = xrow(c_MontoExento.c_NombreInterno)
                                .c_MontoBase.c_Valor = xrow(c_MontoBase.c_NombreInterno)
                                .c_MontoImpuesto.c_Valor = xrow(c_MontoImpuesto.c_NombreInterno)
                                .c_MontoTotalGeneral.c_Valor = xrow(c_MontoTotalGeneral.c_NombreInterno)
                                .c_TasaRetencion.c_Valor = xrow(c_TasaRetencion.c_NombreInterno)
                                .c_MontoRetencion.c_Valor = xrow(c_MontoRetencion.c_NombreInterno)
                                .c_AutoCliente.c_Texto = xrow(c_AutoCliente.c_NombreInterno)
                                .c_FechaRelacion.c_Valor = xrow(c_FechaRelacion.c_NombreInterno)
                                .c_Codigocliente.c_Texto = xrow(c_Codigocliente.c_NombreInterno)
                                .c_AnoRelacion.c_Texto = xrow(c_AnoRelacion.c_NombreInterno)
                                .c_MesRelacion.c_Texto = xrow(c_MesRelacion.c_NombreInterno)

                                'NUEVOS
                                If Not IsDBNull(xrow(.c_AutoCxc_Pago.c_NombreInterno)) Then
                                    .c_AutoCxc_Pago.c_Texto = xrow(.c_AutoCxc_Pago.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoReciboCxC_Pago.c_NombreInterno)) Then
                                    .c_AutoReciboCxC_Pago.c_Texto = xrow(.c_AutoReciboCxC_Pago.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("VENTAS" + vbCrLf + "RETENCION VENTA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

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
                        Using f_adapter As New SqlDataAdapter("select * from retenciones_ventas where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(xtb)
                        End Using
                        If (xtb.Rows.Count > 0) Then
                            M_CargarRegistro(xtb.Rows.Item(0))
                        Else
                            Throw New Exception("AUTO DEL DOCUMENTO NO ENCONTRADO / DOCUMENTO FUE ANULADO POR OTRO USUARIO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("RETENCION VENTAS" + vbCrLf + "BUSCAR DOCUMENTO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Class V_RetencionesIvaDetalle

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

                    WriteOnly Property _MontoImpuesto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_MontoImpuesto.c_Valor = value
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

                    WriteOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Set(ByVal value As TipoDocumentoVentaRegistrado)
                            Select Case value
                                Case TipoDocumentoVentaRegistrado.Factura : Me.RegistroDato.c_TipoDocumento.c_Texto = "01"
                                Case TipoDocumentoVentaRegistrado.NotaDebito : Me.RegistroDato.c_TipoDocumento.c_Texto = "02"
                                Case TipoDocumentoVentaRegistrado.NotaCredito : Me.RegistroDato.c_TipoDocumento.c_Texto = "03"
                            End Select
                        End Set
                    End Property

                    WriteOnly Property _Tasa() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Tasa.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CiRifCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CiRifCliente.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto_documento As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_exento As CampoDecimal
                    Private f_base As CampoDecimal
                    Private f_impuesto As CampoDecimal
                    Private f_total As CampoDecimal
                    Private f_tasa_retencion As CampoDecimal
                    Private f_retencion As CampoDecimal
                    Private f_control As CampoTexto
                    Private f_aplica As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_tasa As CampoDecimal
                    Private f_auto As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_comprobante As CampoTexto
                    Private f_tipo_retencion As CampoTexto
                    Private f_fecha_retencion As CampoFecha

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

                    Protected Friend Property c_Tasa() As CampoDecimal
                        Get
                            Return f_tasa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa = value
                        End Set
                    End Property
                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Protected Friend Property c_CiRifCliente() As CampoTexto
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
                            Return c_FechaEmision.c_Valor
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

                    ReadOnly Property _TipoDocumento() As TipoDocumentoVentaRegistrado
                        Get
                            Select Case c_TipoDocumento.c_Texto.Trim
                                Case "01" : Return TipoDocumentoVentaRegistrado.Factura
                                Case "02" : Return TipoDocumentoVentaRegistrado.NotaDebito
                                Case "03" : Return TipoDocumentoVentaRegistrado.NotaCredito
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _Tasa() As Decimal
                        Get
                            Return c_Tasa.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _Auto() As String
                        Get
                            Return c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifCliente() As String
                        Get
                            Return c_CiRifCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ComprobanteRetencion() As String
                        Get
                            Return c_ComprobanteRetencion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoRetencion() As String
                        Get
                            Return c_TipoRetencion.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _FechaRetencion() As Date
                        Get
                            Return c_FechaRetencion.c_Valor
                        End Get
                    End Property

                    Sub New()
                        f_auto_documento = New CampoTexto(10, "auto_documento")
                        f_documento = New CampoTexto(10, "documento")
                        f_fecha = New CampoFecha("fecha")
                        f_exento = New CampoDecimal("exento")
                        f_base = New CampoDecimal("base")
                        f_impuesto = New CampoDecimal("impuesto")
                        f_total = New CampoDecimal("total")
                        f_tasa_retencion = New CampoDecimal("tasa_retencion")
                        f_retencion = New CampoDecimal("retencion")
                        f_control = New CampoTexto(10, "control")
                        f_aplica = New CampoTexto(10, "aplica")
                        f_tipo = New CampoTexto(2, "tipo")
                        f_tasa = New CampoDecimal("tasa")
                        f_auto = New CampoTexto(10, "auto")
                        f_ci_rif = New CampoTexto(12, "ci_rif")
                        f_comprobante = New CampoTexto(14, "comprobante")
                        f_tipo_retencion = New CampoTexto(2, "tipo_retencion")
                        f_fecha_retencion = New CampoFecha("fecha_retencion")
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
                                .c_MontoImpuesto.c_Valor = xrow(c_MontoImpuesto.c_NombreInterno)
                                .c_MontoTotal.c_Valor = xrow(c_MontoTotal.c_NombreInterno)
                                .c_TasaRetencion.c_Valor = xrow(c_TasaRetencion.c_NombreInterno)
                                .c_MontoRetencion.c_Valor = xrow(c_MontoRetencion.c_NombreInterno)
                                .c_NumeroControlFiscal.c_Texto = xrow(c_NumeroControlFiscal.c_NombreInterno)
                                .c_DocumentoAplica.c_Texto = xrow(c_DocumentoAplica.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(c_TipoDocumento.c_NombreInterno)
                                .c_Tasa.c_Valor = xrow(c_Tasa.c_NombreInterno)
                                .c_Auto.c_Texto = xrow(c_Auto.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(c_CiRifCliente.c_NombreInterno)
                                .c_ComprobanteRetencion.c_Texto = xrow(c_ComprobanteRetencion.c_NombreInterno)
                                .c_TipoRetencion.c_Texto = xrow(c_TipoRetencion.c_NombreInterno)
                                .c_FechaRetencion.c_Valor = xrow(c_FechaRetencion.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("VENTAS" + vbCrLf + "RETENCION IVA DETALLE" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Sub New()
                    xregistro = New c_Registro
                End Sub

                Property RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                'Function F_BuscarRegistros(ByVal xauto As String) As Boolean
                '    Dim f_data As New DataTable
                '    Try
                '        Using f_adapter As New SqlDataAdapter("select * from retenciones_ventas_detalle where auto=@auto", _MiCadenaConexion)
                '            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                '            f_adapter.Fill(f_data)
                '        End Using
                '        If (f_data.Rows.Count >= 1) Then
                '            RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                '        Else
                '            Throw New Exception("Error No Hay Informacion Para Este Registro")
                '        End If
                '    Catch ex As Exception
                '        Throw New Exception("Error No Se Pudo Realizar La Transaccion" + vbCrLf + ex.Message)
                '    End Try
                'End Function
            End Class


            ''' <summary>
            ''' 
            ''' DEFINE LAS INSTANCIAS A CADA CLASE
            ''' 
            ''' </summary>
            Private xtemporalventa As V_TemporalVenta
            Private xtemporalventa_pendiente As V_TemporalVentaPendiente
            Private xventa As V_Ventas
            Private xventadetalle As V_VentasDetalle

            Private xretencionesiva As V_RetencionesIva
            Private xretencionesiva_detalle As V_RetencionesIvaDetalle


            Property F_TemporalVenta() As V_TemporalVenta
                Get
                    Return xtemporalventa
                End Get
                Set(ByVal value As V_TemporalVenta)
                    xtemporalventa = value
                End Set
            End Property

            Property F_TemporalVentaPendiente() As V_TemporalVentaPendiente
                Get
                    Return xtemporalventa_pendiente
                End Get
                Set(ByVal value As V_TemporalVentaPendiente)
                    xtemporalventa_pendiente = value
                End Set
            End Property

            Property F_Venta() As V_Ventas
                Get
                    Return xventa
                End Get
                Set(ByVal value As V_Ventas)
                    xventa = value
                End Set
            End Property

            Property F_VentaDetalle() As V_VentasDetalle
                Get
                    Return xventadetalle
                End Get
                Set(ByVal value As V_VentasDetalle)
                    xventadetalle = value
                End Set
            End Property

            Property F_RetencionesIva() As V_RetencionesIva
                Get
                    Return xretencionesiva
                End Get
                Set(ByVal value As V_RetencionesIva)
                    xretencionesiva = value
                End Set
            End Property

            Property F_RetencionesIva_Detalle() As V_RetencionesIvaDetalle
                Get
                    Return xretencionesiva_detalle
                End Get
                Set(ByVal value As V_RetencionesIvaDetalle)
                    xretencionesiva_detalle = value
                End Set
            End Property


            Sub New()
                Me.F_TemporalVenta = New V_TemporalVenta
                Me.F_TemporalVentaPendiente = New V_TemporalVentaPendiente
                Me.F_Venta = New V_Ventas
                Me.F_VentaDetalle = New V_VentasDetalle

                Me.F_RetencionesIva = New V_RetencionesIva
                Me.F_RetencionesIva_Detalle = New V_RetencionesIvaDetalle
            End Sub


#Region "DEFINICIONES DE INSTRUCCIONES SQL PARA EL MODULO DE VENTA"
            Protected Friend Const INSERT_VENTAS_ESTACIONAMIENTO As String = "insert ventas (" _
                           + "auto," _
                           + "documento," _
                           + "fecha," _
                           + "fecha_vencimiento," _
                           + "nombre," _
                           + "dir_fiscal," _
                           + "ci_rif," _
                           + "tipo," _
                           + "exento," _
                           + "base1," _
                           + "base2," _
                           + "base3," _
                           + "impuesto1," _
                           + "impuesto2," _
                           + "impuesto3," _
                           + "base," _
                           + "impuesto," _
                           + "total," _
                           + "tasa1," _
                           + "tasa2," _
                           + "tasa3," _
                           + "nota," _
                           + "tasa_retencion_iva," _
                           + "tasa_retencion_islr," _
                           + "retencion_iva," _
                           + "retencion_islr," _
                           + "auto_entidad," _
                           + "codigo_entidad," _
                           + "mes_relacion," _
                           + "control," _
                           + "fecha_relacion," _
                           + "orden_compra," _
                           + "dias," _
                           + "descuento1," _
                           + "descuento2," _
                           + "cargos," _
                           + "descuento1_porcentaje," _
                           + "descuento2_porcentaje," _
                           + "cargos_porcentaje," _
                           + "columna," _
                           + "estatus," _
                           + "aplica," _
                           + "comprobante_retencion," _
                           + "subtotal," _
                           + "telefono," _
                           + "factor_cambio," _
                           + "codigo_vendedor," _
                           + "vendedor," _
                           + "auto_vendedor," _
                           + "fecha_pedido," _
                           + "pedido," _
                           + "condicion_pago," _
                           + "usuario," _
                           + "codigo_usuario," _
                           + "codigo_sucursal," _
                           + "hora," _
                           + "transporte," _
                           + "codigo_transporte," _
                           + "monto_divisa," _
                           + "despachado," _
                           + "dir_despacho," _
                           + "estacion," _
                           + "auto_recibo," _
                           + "recibo," _
                           + "renglones," _
                           + "saldo_pendiente," _
                           + "ano_relacion," _
                           + "comprobante_retencion_islr," _
                           + "dias_validez," _
                           + "nrf," _
                           + "auto_usuario," _
                           + "auto_jornada," _
                           + "auto_operador," _
                           + "serie," _
                           + "serial, " _
                           + "bloquear_almacen," _
                           + "origen_documento," _
                           + "rest_numero_mesapedido," _
                           + "rest_servicio_tasa," _
                           + "rest_servicio_monto," _
                           + "rest_modo_mesapedido, descuento_por_prontopago) " _
                           + "VALUES (" _
                           + "@auto," _
                           + "@documento," _
                           + "@fecha," _
                           + "@fecha_vencimiento," _
                           + "@nombre," _
                           + "@dir_fiscal," _
                           + "@ci_rif," _
                           + "@tipo," _
                           + "@exento," _
                           + "@base1," _
                           + "@base2," _
                           + "@base3," _
                           + "@impuesto1," _
                           + "@impuesto2," _
                           + "@impuesto3," _
                           + "@base," _
                           + "@impuesto," _
                           + "@total," _
                           + "@tasa1," _
                           + "@tasa2," _
                           + "@tasa3," _
                           + "@nota," _
                           + "@tasa_retencion_iva," _
                           + "@tasa_retencion_islr," _
                           + "@retencion_iva," _
                           + "@retencion_islr," _
                           + "@auto_entidad," _
                           + "@codigo_entidad," _
                           + "@mes_relacion," _
                           + "@control," _
                           + "@fecha_relacion," _
                           + "@orden_compra," _
                           + "@dias," _
                           + "@descuento1," _
                           + "@descuento2," _
                           + "@cargos," _
                           + "@descuento1_porcentaje," _
                           + "@descuento2_porcentaje," _
                           + "@cargos_porcentaje," _
                           + "@columna," _
                           + "@estatus," _
                           + "@aplica," _
                           + "@comprobante_retencion," _
                           + "@subtotal," _
                           + "@telefono," _
                           + "@factor_cambio," _
                           + "@codigo_vendedor," _
                           + "@vendedor," _
                           + "@auto_vendedor," _
                           + "@fecha_pedido," _
                           + "@pedido," _
                           + "@condicion_pago," _
                           + "@usuario," _
                           + "@codigo_usuario," _
                           + "@codigo_sucursal," _
                           + "@hora," _
                           + "@transporte," _
                           + "@codigo_transporte," _
                           + "@monto_divisa," _
                           + "@despachado," _
                           + "@dir_despacho," _
                           + "@estacion," _
                           + "@auto_recibo," _
                           + "@recibo," _
                           + "@renglones," _
                           + "@saldo_pendiente," _
                           + "@ano_relacion," _
                           + "@comprobante_retencion_islr," _
                           + "@dias_validez," _
                           + "@nrf," _
                           + "@auto_usuario," _
                           + "@auto_jornada," _
                           + "@auto_operador," _
                           + "@serie," _
                           + "@serial, " _
                           + "@bloquear_almacen," _
                           + "@origen_documento," _
                           + "@rest_numero_mesapedido," _
                           + "@rest_servicio_tasa," _
                           + "@rest_servicio_monto," _
                           + "@rest_modo_mesapedido, @descuento_por_prontopago)"



            Protected Friend Const INSERT_VENTAS As String = "insert ventas (" _
               + "auto," _
               + "documento," _
               + "fecha," _
               + "fecha_vencimiento," _
               + "nombre," _
               + "dir_fiscal," _
               + "ci_rif," _
               + "tipo," _
               + "exento," _
               + "base1," _
               + "base2," _
               + "base3," _
               + "impuesto1," _
               + "impuesto2," _
               + "impuesto3," _
               + "base," _
               + "impuesto," _
               + "total," _
               + "tasa1," _
               + "tasa2," _
               + "tasa3," _
               + "nota," _
               + "tasa_retencion_iva," _
               + "tasa_retencion_islr," _
               + "retencion_iva," _
               + "retencion_islr," _
               + "auto_entidad," _
               + "codigo_entidad," _
               + "mes_relacion," _
               + "control," _
               + "fecha_relacion," _
               + "orden_compra," _
               + "dias," _
               + "descuento1," _
               + "descuento2," _
               + "cargos," _
               + "descuento1_porcentaje," _
               + "descuento2_porcentaje," _
               + "cargos_porcentaje," _
               + "columna," _
               + "estatus," _
               + "aplica," _
               + "comprobante_retencion," _
               + "subtotal," _
               + "telefono," _
               + "factor_cambio," _
               + "codigo_vendedor," _
               + "vendedor," _
               + "auto_vendedor," _
               + "fecha_pedido," _
               + "pedido," _
               + "condicion_pago," _
               + "usuario," _
               + "codigo_usuario," _
               + "codigo_sucursal," _
               + "hora," _
               + "transporte," _
               + "codigo_transporte," _
               + "monto_divisa," _
               + "despachado," _
               + "dir_despacho," _
               + "estacion," _
               + "auto_recibo," _
               + "recibo," _
               + "renglones," _
               + "saldo_pendiente," _
               + "ano_relacion," _
               + "comprobante_retencion_islr," _
               + "dias_validez," _
               + "nrf," _
               + "auto_usuario," _
               + "auto_jornada," _
               + "auto_operador," _
               + "serie," _
               + "serial, " _
               + "bloquear_almacen," _
               + "origen_documento," _
               + "rest_numero_mesapedido," _
               + "rest_servicio_tasa," _
               + "rest_servicio_monto," _
               + "rest_modo_mesapedido, descuento_por_prontopago, relacion_z) " _
               + "VALUES (" _
               + "@auto," _
               + "@documento," _
               + "@fecha," _
               + "@fecha_vencimiento," _
               + "@nombre," _
               + "@dir_fiscal," _
               + "@ci_rif," _
               + "@tipo," _
               + "@exento," _
               + "@base1," _
               + "@base2," _
               + "@base3," _
               + "@impuesto1," _
               + "@impuesto2," _
               + "@impuesto3," _
               + "@base," _
               + "@impuesto," _
               + "@total," _
               + "@tasa1," _
               + "@tasa2," _
               + "@tasa3," _
               + "@nota," _
               + "@tasa_retencion_iva," _
               + "@tasa_retencion_islr," _
               + "@retencion_iva," _
               + "@retencion_islr," _
               + "@auto_entidad," _
               + "@codigo_entidad," _
               + "@mes_relacion," _
               + "@control," _
               + "@fecha_relacion," _
               + "@orden_compra," _
               + "@dias," _
               + "@descuento1," _
               + "@descuento2," _
               + "@cargos," _
               + "@descuento1_porcentaje," _
               + "@descuento2_porcentaje," _
               + "@cargos_porcentaje," _
               + "@columna," _
               + "@estatus," _
               + "@aplica," _
               + "@comprobante_retencion," _
               + "@subtotal," _
               + "@telefono," _
               + "@factor_cambio," _
               + "@codigo_vendedor," _
               + "@vendedor," _
               + "@auto_vendedor," _
               + "@fecha_pedido," _
               + "@pedido," _
               + "@condicion_pago," _
               + "@usuario," _
               + "@codigo_usuario," _
               + "@codigo_sucursal," _
               + "@hora," _
               + "@transporte," _
               + "@codigo_transporte," _
               + "@monto_divisa," _
               + "@despachado," _
               + "@dir_despacho," _
               + "@estacion," _
               + "@auto_recibo," _
               + "@recibo," _
               + "@renglones," _
               + "@saldo_pendiente," _
               + "@ano_relacion," _
               + "@comprobante_retencion_islr," _
               + "@dias_validez," _
               + "@nrf," _
               + "@auto_usuario," _
               + "@auto_jornada," _
               + "@auto_operador," _
               + "@serie," _
               + "@serial, " _
               + "@bloquear_almacen," _
               + "@origen_documento," _
               + "@rest_numero_mesapedido," _
               + "@rest_servicio_tasa," _
               + "@rest_servicio_monto," _
               + "@rest_modo_mesapedido, @descuento_por_prontopago, @relacion_z)"


            Protected Friend Const INSERT_VENTAS_PEDIDO As String = "insert ventas (" _
               + "auto," _
               + "documento," _
               + "fecha," _
               + "fecha_vencimiento," _
               + "nombre," _
               + "dir_fiscal," _
               + "ci_rif," _
               + "tipo," _
               + "exento," _
               + "base1," _
               + "base2," _
               + "base3," _
               + "impuesto1," _
               + "impuesto2," _
               + "impuesto3," _
               + "base," _
               + "impuesto," _
               + "total," _
               + "tasa1," _
               + "tasa2," _
               + "tasa3," _
               + "nota," _
               + "tasa_retencion_iva," _
               + "tasa_retencion_islr," _
               + "retencion_iva," _
               + "retencion_islr," _
               + "auto_entidad," _
               + "codigo_entidad," _
               + "mes_relacion," _
               + "control," _
               + "fecha_relacion," _
               + "orden_compra," _
               + "dias," _
               + "descuento1," _
               + "descuento2," _
               + "cargos," _
               + "descuento1_porcentaje," _
               + "descuento2_porcentaje," _
               + "cargos_porcentaje," _
               + "columna," _
               + "estatus," _
               + "aplica," _
               + "comprobante_retencion," _
               + "subtotal," _
               + "telefono," _
               + "factor_cambio," _
               + "codigo_vendedor," _
               + "vendedor," _
               + "auto_vendedor," _
               + "fecha_pedido," _
               + "pedido," _
               + "condicion_pago," _
               + "usuario," _
               + "codigo_usuario," _
               + "codigo_sucursal," _
               + "hora," _
               + "transporte," _
               + "codigo_transporte," _
               + "monto_divisa," _
               + "despachado," _
               + "dir_despacho," _
               + "estacion," _
               + "auto_recibo," _
               + "recibo," _
               + "renglones," _
               + "saldo_pendiente," _
               + "ano_relacion," _
               + "comprobante_retencion_islr," _
               + "dias_validez," _
               + "nrf," _
               + "auto_usuario," _
               + "auto_jornada," _
               + "auto_operador," _
               + "serie," _
               + "serial, " _
               + "bloquear_almacen," _
               + "origen_documento," _
               + "rest_numero_mesapedido," _
               + "rest_servicio_tasa," _
               + "rest_servicio_monto," _
               + "rest_modo_mesapedido, descuento_por_prontopago, relacion_z, estatusDivisa) " _
               + "VALUES (" _
               + "@auto," _
               + "@documento," _
               + "@fecha," _
               + "@fecha_vencimiento," _
               + "@nombre," _
               + "@dir_fiscal," _
               + "@ci_rif," _
               + "@tipo," _
               + "@exento," _
               + "@base1," _
               + "@base2," _
               + "@base3," _
               + "@impuesto1," _
               + "@impuesto2," _
               + "@impuesto3," _
               + "@base," _
               + "@impuesto," _
               + "@total," _
               + "@tasa1," _
               + "@tasa2," _
               + "@tasa3," _
               + "@nota," _
               + "@tasa_retencion_iva," _
               + "@tasa_retencion_islr," _
               + "@retencion_iva," _
               + "@retencion_islr," _
               + "@auto_entidad," _
               + "@codigo_entidad," _
               + "@mes_relacion," _
               + "@control," _
               + "@fecha_relacion," _
               + "@orden_compra," _
               + "@dias," _
               + "@descuento1," _
               + "@descuento2," _
               + "@cargos," _
               + "@descuento1_porcentaje," _
               + "@descuento2_porcentaje," _
               + "@cargos_porcentaje," _
               + "@columna," _
               + "@estatus," _
               + "@aplica," _
               + "@comprobante_retencion," _
               + "@subtotal," _
               + "@telefono," _
               + "@factor_cambio," _
               + "@codigo_vendedor," _
               + "@vendedor," _
               + "@auto_vendedor," _
               + "@fecha_pedido," _
               + "@pedido," _
               + "@condicion_pago," _
               + "@usuario," _
               + "@codigo_usuario," _
               + "@codigo_sucursal," _
               + "@hora," _
               + "@transporte," _
               + "@codigo_transporte," _
               + "@monto_divisa," _
               + "@despachado," _
               + "@dir_despacho," _
               + "@estacion," _
               + "@auto_recibo," _
               + "@recibo," _
               + "@renglones," _
               + "@saldo_pendiente," _
               + "@ano_relacion," _
               + "@comprobante_retencion_islr," _
               + "@dias_validez," _
               + "@nrf," _
               + "@auto_usuario," _
               + "@auto_jornada," _
               + "@auto_operador," _
               + "@serie," _
               + "@serial, " _
               + "@bloquear_almacen," _
               + "@origen_documento," _
               + "@rest_numero_mesapedido," _
               + "@rest_servicio_tasa," _
               + "@rest_servicio_monto," _
               + "@rest_modo_mesapedido, @descuento_por_prontopago, @relacion_z, @estatusDivisa)"


            Protected Friend Const INSERT_VENTAS_POS As String = "insert ventas (" _
               + "auto," _
               + "documento," _
               + "fecha," _
               + "fecha_vencimiento," _
               + "nombre," _
               + "dir_fiscal," _
               + "ci_rif," _
               + "tipo," _
               + "exento," _
               + "base1," _
               + "base2," _
               + "base3," _
               + "impuesto1," _
               + "impuesto2," _
               + "impuesto3," _
               + "base," _
               + "impuesto," _
               + "total," _
               + "tasa1," _
               + "tasa2," _
               + "tasa3," _
               + "nota," _
               + "tasa_retencion_iva," _
               + "tasa_retencion_islr," _
               + "retencion_iva," _
               + "retencion_islr," _
               + "auto_entidad," _
               + "codigo_entidad," _
               + "mes_relacion," _
               + "control," _
               + "fecha_relacion," _
               + "orden_compra," _
               + "dias," _
               + "descuento1," _
               + "descuento2," _
               + "cargos," _
               + "descuento1_porcentaje," _
               + "descuento2_porcentaje," _
               + "cargos_porcentaje," _
               + "columna," _
               + "estatus," _
               + "aplica," _
               + "comprobante_retencion," _
               + "subtotal," _
               + "telefono," _
               + "factor_cambio," _
               + "codigo_vendedor," _
               + "vendedor," _
               + "auto_vendedor," _
               + "fecha_pedido," _
               + "pedido," _
               + "condicion_pago," _
               + "usuario," _
               + "codigo_usuario," _
               + "codigo_sucursal," _
               + "hora," _
               + "transporte," _
               + "codigo_transporte," _
               + "monto_divisa," _
               + "despachado," _
               + "dir_despacho," _
               + "estacion," _
               + "auto_recibo," _
               + "recibo," _
               + "renglones," _
               + "saldo_pendiente," _
               + "ano_relacion," _
               + "comprobante_retencion_islr," _
               + "dias_validez," _
               + "nrf," _
               + "auto_usuario," _
               + "auto_jornada," _
               + "auto_operador," _
               + "serie," _
               + "serial, " _
               + "bloquear_almacen, " _
               + "origen_documento, " _
               + "rest_numero_mesapedido, " _
               + "rest_servicio_tasa, " _
               + "rest_servicio_monto, " _
               + "rest_modo_mesapedido, relacion_z) " _
               + "VALUES (" _
               + "@auto," _
               + "@documento," _
               + "@fecha," _
               + "@fecha_vencimiento," _
               + "@nombre," _
               + "@dir_fiscal," _
               + "@ci_rif," _
               + "@tipo," _
               + "@exento," _
               + "@base1," _
               + "@base2," _
               + "@base3," _
               + "@impuesto1," _
               + "@impuesto2," _
               + "@impuesto3," _
               + "@base," _
               + "@impuesto," _
               + "@total," _
               + "@tasa1," _
               + "@tasa2," _
               + "@tasa3," _
               + "@nota," _
               + "@tasa_retencion_iva," _
               + "@tasa_retencion_islr," _
               + "@retencion_iva," _
               + "@retencion_islr," _
               + "@auto_entidad," _
               + "@codigo_entidad," _
               + "@mes_relacion," _
               + "@control," _
               + "@fecha_relacion," _
               + "@orden_compra," _
               + "@dias," _
               + "@descuento1," _
               + "@descuento2," _
               + "@cargos," _
               + "@descuento1_porcentaje," _
               + "@descuento2_porcentaje," _
               + "@cargos_porcentaje," _
               + "@columna," _
               + "@estatus," _
               + "@aplica," _
               + "@comprobante_retencion," _
               + "@subtotal," _
               + "@telefono," _
               + "@factor_cambio," _
               + "@codigo_vendedor," _
               + "@vendedor," _
               + "@auto_vendedor," _
               + "@fecha_pedido," _
               + "@pedido," _
               + "@condicion_pago," _
               + "@usuario," _
               + "@codigo_usuario," _
               + "@codigo_sucursal," _
               + "@hora," _
               + "@transporte," _
               + "@codigo_transporte," _
               + "@monto_divisa," _
               + "@despachado," _
               + "@dir_despacho," _
               + "@estacion," _
               + "@auto_recibo," _
               + "@recibo," _
               + "@renglones," _
               + "@saldo_pendiente," _
               + "@ano_relacion," _
               + "@comprobante_retencion_islr," _
               + "@dias_validez," _
               + "@nrf," _
               + "@auto_usuario," _
               + "@auto_jornada," _
               + "@auto_operador," _
               + "@serie," _
               + "@serial, " _
               + "@bloquear_almacen," _
               + "@origen_documento, " _
               + "@rest_numero_mesapedido, " _
               + "@rest_servicio_tasa, " _
               + "@rest_servicio_monto, " _
               + "@rest_modo_mesapedido, @relacion_z) "


            Protected Friend Const INSERT_VENTAS_DETALLE As String = "INSERT INTO ventas_detalle (" _
               + "auto_documento," _
               + "auto_productos," _
               + "codigo," _
               + "nombre," _
               + "auto_departamento," _
               + "auto_grupo," _
               + "auto_subgrupo," _
               + "auto_deposito," _
               + "cantidad," _
               + "empaque," _
               + "precio_neto," _
               + "descuento1p," _
               + "descuento2p," _
               + "descuento3p," _
               + "descuento1," _
               + "descuento2," _
               + "descuento3," _
               + "costo_venta," _
               + "total_neto," _
               + "tasa," _
               + "impuesto," _
               + "total," _
               + "auto," _
               + "estatus," _
               + "fecha," _
               + "tipo," _
               + "deposito," _
               + "signo," _
               + "precio_final," _
               + "auto_entidad," _
               + "decimales," _
               + "contenido_empaque," _
               + "cantidad_inventario," _
               + "precio_inventario," _
               + "costo_inventario," _
               + "utilidad," _
               + "utilidadp," _
               + "precio_item," _
               + "estatus_garantia," _
               + "estatus_serial," _
               + "codigo_deposito," _
               + "dias_garantia," _
               + "detalle," _
               + "psv," _
               + "empaque_tipo," _
               + "codigo_tasa," _
               + "estatus_corte," _
               + "x," _
               + "y," _
               + "z," _
               + "corte," _
               + "categoria," _
               + "N_esoferta," _
               + "N_espesado," _
               + "N_codigobarra," _
               + "N_plu," _
               + "N_etiq_formato," _
               + "N_etiq_depart," _
               + "N_etiq_seccion," _
               + "N_etiq_vendedor," _
               + "N_etiq_plu," _
               + "N_etiq_peso," _
               + "N_etiq_precio," _
               + "N_etiq_control," _
               + "N_etiq_digitos," _
               + "N_etiq_ticket," _
               + "N_etiq_numbalanza," _
               + "N_etiq_montoitem," _
               + "N_etiq_numitem," _
               + "N_auto_jornada," _
               + "N_auto_operador, " _
               + "N_automedida, " _
               + "N_forzarmedida, " _
               + "N_TipoCalculoUtilidad, " _
               + "N_TipoMovimiento, " _
               + "n_auto_item_origen, n_nombre_corto, n_licor_capacidad, n_licor_grados, n_licor_nacional_importado) " _
               + "VALUES (" _
               + "@auto_documento," _
               + "@auto_productos," _
               + "@codigo," _
               + "@nombre," _
               + "@auto_departamento," _
               + "@auto_grupo," _
               + "@auto_subgrupo," _
               + "@auto_deposito," _
               + "@cantidad," _
               + "@empaque," _
               + "@precio_neto," _
               + "@descuento1p," _
               + "@descuento2p," _
               + "@descuento3p," _
               + "@descuento1," _
               + "@descuento2," _
               + "@descuento3," _
               + "@costo_venta," _
               + "@total_neto," _
               + "@tasa," _
               + "@impuesto," _
               + "@total," _
               + "@auto," _
               + "@estatus," _
               + "@fecha," _
               + "@tipo," _
               + "@deposito," _
               + "@signo," _
               + "@precio_final," _
               + "@auto_entidad," _
               + "@decimales," _
               + "@contenido_empaque," _
               + "@cantidad_inventario," _
               + "@precio_inventario," _
               + "@costo_inventario," _
               + "@utilidad," _
               + "@utilidadp," _
               + "@precio_item," _
               + "@estatus_garantia," _
               + "@estatus_serial," _
               + "@codigo_deposito," _
               + "@dias_garantia," _
               + "@detalle," _
               + "@psv," _
               + "@empaque_tipo," _
               + "@codigo_tasa," _
               + "@estatus_corte," _
               + "@x," _
               + "@y," _
               + "@z," _
               + "@corte," _
               + "@categoria," _
               + "@N_esoferta," _
               + "@N_espesado," _
               + "@N_codigobarra," _
               + "@N_plu," _
               + "@N_etiq_formato," _
               + "@N_etiq_depart," _
               + "@N_etiq_seccion," _
               + "@N_etiq_vendedor," _
               + "@N_etiq_plu," _
               + "@N_etiq_peso," _
               + "@N_etiq_precio," _
               + "@N_etiq_control," _
               + "@N_etiq_digitos," _
               + "@N_etiq_ticket," _
               + "@N_etiq_numbalanza," _
               + "@N_etiq_montoitem," _
               + "@N_etiq_numitem," _
               + "@N_auto_jornada," _
               + "@N_auto_operador," _
               + "@N_automedida, " _
               + "@N_forzarmedida, " _
               + "@N_TipoCalculoUtilidad, " _
               + "@N_TipoMovimiento, " _
               + "@n_auto_item_origen, @n_nombre_corto, @n_licor_capacidad, @n_licor_grados, @n_licor_nacional_importado) "


            Protected Friend Const INSERT_VENTAS_DETALLE_POS As String = "INSERT INTO ventas_detalle (" _
                           + "auto_documento," _
                           + "auto_productos," _
                           + "codigo," _
                           + "nombre," _
                           + "auto_departamento," _
                           + "auto_grupo," _
                           + "auto_subgrupo," _
                           + "auto_deposito," _
                           + "cantidad," _
                           + "empaque," _
                           + "precio_neto," _
                           + "descuento1p," _
                           + "descuento2p," _
                           + "descuento3p," _
                           + "descuento1," _
                           + "descuento2," _
                           + "descuento3," _
                           + "costo_venta," _
                           + "total_neto," _
                           + "tasa," _
                           + "impuesto," _
                           + "total," _
                           + "auto," _
                           + "estatus," _
                           + "fecha," _
                           + "tipo," _
                           + "deposito," _
                           + "signo," _
                           + "precio_final," _
                           + "auto_entidad," _
                           + "decimales," _
                           + "contenido_empaque," _
                           + "cantidad_inventario," _
                           + "precio_inventario," _
                           + "costo_inventario," _
                           + "utilidad," _
                           + "utilidadp," _
                           + "precio_item," _
                           + "estatus_garantia," _
                           + "estatus_serial," _
                           + "codigo_deposito," _
                           + "dias_garantia," _
                           + "detalle," _
                           + "psv," _
                           + "empaque_tipo," _
                           + "codigo_tasa," _
                           + "estatus_corte," _
                           + "x," _
                           + "y," _
                           + "z," _
                           + "corte," _
                           + "categoria," _
                           + "N_esoferta," _
                           + "N_espesado," _
                           + "N_codigobarra," _
                           + "N_plu," _
                           + "N_etiq_formato," _
                           + "N_etiq_depart," _
                           + "N_etiq_seccion," _
                           + "N_etiq_vendedor," _
                           + "N_etiq_plu," _
                           + "N_etiq_peso," _
                           + "N_etiq_precio," _
                           + "N_etiq_control," _
                           + "N_etiq_digitos," _
                           + "N_etiq_ticket," _
                           + "N_etiq_numbalanza," _
                           + "N_etiq_montoitem," _
                           + "N_etiq_numitem," _
                           + "N_auto_jornada," _
                           + "N_auto_operador, " _
                           + "N_automedida, " _
                           + "N_forzarmedida, " _
                           + "N_TipoCalculoUtilidad, " _
                           + "N_TipoMovimiento, " _
                           + "n_auto_item_origen, n_nombre_corto) " _
                           + "VALUES (" _
                           + "@auto_documento," _
                           + "@auto_productos," _
                           + "@codigo," _
                           + "@nombre," _
                           + "@auto_departamento," _
                           + "@auto_grupo," _
                           + "@auto_subgrupo," _
                           + "@auto_deposito," _
                           + "@cantidad," _
                           + "@empaque," _
                           + "@precio_neto," _
                           + "@descuento1p," _
                           + "@descuento2p," _
                           + "@descuento3p," _
                           + "@descuento1," _
                           + "@descuento2," _
                           + "@descuento3," _
                           + "@costo_venta," _
                           + "@total_neto," _
                           + "@tasa," _
                           + "@impuesto," _
                           + "@total," _
                           + "@auto," _
                           + "@estatus," _
                           + "@fecha," _
                           + "@tipo," _
                           + "@deposito," _
                           + "@signo," _
                           + "@precio_final," _
                           + "@auto_entidad," _
                           + "@decimales," _
                           + "@contenido_empaque," _
                           + "@cantidad_inventario," _
                           + "@precio_inventario," _
                           + "@costo_inventario," _
                           + "@utilidad," _
                           + "@utilidadp," _
                           + "@precio_item," _
                           + "@estatus_garantia," _
                           + "@estatus_serial," _
                           + "@codigo_deposito," _
                           + "@dias_garantia," _
                           + "@detalle," _
                           + "@psv," _
                           + "@empaque_tipo," _
                           + "@codigo_tasa," _
                           + "@estatus_corte," _
                           + "@x," _
                           + "@y," _
                           + "@z," _
                           + "@corte," _
                           + "@categoria," _
                           + "@N_esoferta," _
                           + "@N_espesado," _
                           + "@N_codigobarra," _
                           + "@N_plu," _
                           + "@N_etiq_formato," _
                           + "@N_etiq_depart," _
                           + "@N_etiq_seccion," _
                           + "@N_etiq_vendedor," _
                           + "@N_etiq_plu," _
                           + "@N_etiq_peso," _
                           + "@N_etiq_precio," _
                           + "@N_etiq_control," _
                           + "@N_etiq_digitos," _
                           + "@N_etiq_ticket," _
                           + "@N_etiq_numbalanza," _
                           + "@N_etiq_montoitem," _
                           + "@N_etiq_numitem," _
                           + "@N_auto_jornada," _
                           + "@N_auto_operador," _
                           + "@N_automedida, " _
                           + "@N_forzarmedida, " _
                           + "@N_TipoCalculoUtilidad, " _
                           + "@N_TipoMovimiento, " _
                           + "@n_auto_item_origen, @n_nombre_corto) "


            Protected Friend Const INSERT_VENTAS_MEDIDA As String = "INSERT INTO ventas_medida (" _
               + "auto_documento," _
               + "auto_medida," _
               + "total_medida," _
               + "decimales," _
               + "nombre)" _
               + "VALUES (" _
               + "@auto_documento," _
               + "@auto_medida," _
               + "@total_medida," _
               + "@decimales," _
               + "@nombre)"

            Protected Friend Const PRODUCTOS_DEPOSITO_DESBLOQUEAR = "Update productos_deposito set " _
               + "disponible=disponible+@cantidad_inventario, reservada=reservada-@cantidad_inventario " _
               + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito "

            Protected Friend Const VENTAS_UPDATE_PRODUCTOS_DEPOSITO = "Update productos_deposito set " _
               + "real=real-@cantidad_inventario,disponible=disponible-@cantidad_inventario " _
               + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito "

            Protected Friend Const INSERT_RETENCIONESIVA_VENTAS As String = "INSERT INTO retenciones_ventas (" _
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
               + ",auto_cxc" _
               + ",auto_recibo_cxc) " _
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
               + ",@auto_cxc" _
               + ",@auto_recibo_cxc) "

            Protected Friend Const INSERT_RETENCIONESIVA_VENTAS_DETALLE As String = "INSERT INTO retenciones_ventas_detalle (" _
               + "auto_documento" _
               + ",documento" _
               + ",fecha" _
               + ",exento" _
               + ",base" _
               + ",impuesto" _
               + ",total" _
               + ",tasa_retencion" _
               + ",retencion" _
               + ",control" _
               + ",aplica" _
               + ",tipo" _
               + ",tasa" _
               + ",auto" _
               + ",ci_rif" _
               + ",comprobante" _
               + ",tipo_retencion" _
               + ",fecha_retencion) " _
               + "VALUES(" _
               + "@auto_documento" _
               + ",@documento" _
               + ",@fecha" _
               + ",@exento" _
               + ",@base" _
               + ",@impuesto" _
               + ",@total" _
               + ",@tasa_retencion" _
               + ",@retencion" _
               + ",@control" _
               + ",@aplica" _
               + ",@tipo" _
               + ",@tasa" _
               + ",@auto" _
               + ",@ci_rif" _
               + ",@comprobante" _
               + ",@tipo_retencion" _
               + ",@fecha_retencion) "
#End Region

            Class ModoImprimirFactura
                Private xmodo As TipoImpresora
                Private xformato As String
                Private xruta As String
                Private ximpresora As IFiscal
                Private xorden As FichaGlobal.c_ConfSistema.ConfModuloVentas.OrdenImprimirItems
                Private ximprimirlineaadicional_empaquesugeridocontenido_imp_fiscal As Boolean
                Private xsubdetalle_fiscal_1 As String
                Private xsubdetalle_fiscal_2 As String
                Private xsubdetalle_fiscal_3 As String
                Private xsubdetalle_fiscal_4 As String

                Property _SubDetalleFiscal_1() As String
                    Get
                        Return Me.xsubdetalle_fiscal_1
                    End Get
                    Set(ByVal value As String)
                        Me.xsubdetalle_fiscal_1 = value
                    End Set
                End Property

                Property _SubDetalleFiscal_2() As String
                    Get
                        Return Me.xsubdetalle_fiscal_2
                    End Get
                    Set(ByVal value As String)
                        Me.xsubdetalle_fiscal_2 = value
                    End Set
                End Property

                Property _SubDetalleFiscal_3() As String
                    Get
                        Return Me.xsubdetalle_fiscal_3
                    End Get
                    Set(ByVal value As String)
                        Me.xsubdetalle_fiscal_3 = value
                    End Set
                End Property

                Property _SubDetalleFiscal_4() As String
                    Get
                        Return Me.xsubdetalle_fiscal_4
                    End Get
                    Set(ByVal value As String)
                        Me.xsubdetalle_fiscal_4 = value
                    End Set
                End Property

                Property _ModoImpresion() As TipoImpresora
                    Get
                        Return xmodo
                    End Get
                    Set(ByVal value As TipoImpresora)
                        xmodo = value
                    End Set
                End Property

                Property _FormatoNombre() As String
                    Get
                        Return xformato
                    End Get
                    Set(ByVal value As String)
                        xformato = value
                    End Set
                End Property

                Property _RutaImpresora() As String
                    Get
                        Return xruta
                    End Get
                    Set(ByVal value As String)
                        xruta = value
                    End Set
                End Property

                Property _Impresora() As IFiscal
                    Get
                        Return ximpresora
                    End Get
                    Set(ByVal value As IFiscal)
                        ximpresora = value
                    End Set
                End Property

                Property _OrdenAlImprimir() As FichaGlobal.c_ConfSistema.ConfModuloVentas.OrdenImprimirItems
                    Get
                        Return Me.xorden
                    End Get
                    Set(ByVal value As FichaGlobal.c_ConfSistema.ConfModuloVentas.OrdenImprimirItems)
                        Me.xorden = value
                    End Set
                End Property

                Property _ImprimirLineaDetalle_EmpaqueContenidoSugerio_Imp_Fiscal() As Boolean
                    Get
                        Return Me.ximprimirlineaadicional_empaquesugeridocontenido_imp_fiscal
                    End Get
                    Set(ByVal value As Boolean)
                        Me.ximprimirlineaadicional_empaquesugeridocontenido_imp_fiscal = value
                    End Set
                End Property

                Sub New()
                    Me._FormatoNombre = ""
                    Me._RutaImpresora = ""
                    Me._ModoImpresion = 0
                    Me._Impresora = Nothing
                    Me._OrdenAlImprimir = FichaGlobal.c_ConfSistema.ConfModuloVentas.OrdenImprimirItems.PorDefecto
                    Me._ImprimirLineaDetalle_EmpaqueContenidoSugerio_Imp_Fiscal = False
                    Me._SubDetalleFiscal_1 = ""
                    Me._SubDetalleFiscal_2 = ""
                    Me._SubDetalleFiscal_3 = ""
                    Me._SubDetalleFiscal_4 = ""
                End Sub
            End Class

        End Class

        Private xfichaVentas As FichaVentas

        ''' <summary>
        ''' Ficha General Ventas
        ''' </summary>
        Property f_FichaVentas() As FichaVentas
            Get
                Return xfichaventas
            End Get
            Set(ByVal value As FichaVentas)
                xfichaventas = value
            End Set
        End Property
    End Class
End Namespace
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Reflection

Namespace MiDataSistema

    ''' <summary>
    ''' DEFINICION DE CLASE DE MANEJO DE DATA DEL SISTEMA
    ''' MODULO PRINCIPAL
    ''' </summary>
    Partial Public Class DataSistema

        ''' <summary>
        ''' INDICA EL TIPO DE LIBRERIA A CARGAR 
        ''' </summary>
        ''' <remarks></remarks>
        Enum TipoSistema As Integer
            Administrativo = 1
            Estacionamiento = 2
        End Enum

        Shared xcadena As String
        Shared xclavenivelmaximo As String
        Shared xclavenivelmedio As String
        Shared xclavenivelminimo As String
        Private xtiposistema As TipoSistema

        ''' <summary>
        ''' REPRESENTA EL TIPO DE LIBRERIA DE DATOS A CARGAR POR EL SISTEMA
        ''' </summary>
        Property p_TipoSistema() As TipoSistema
            Get
                Return xtiposistema
            End Get
            Set(ByVal value As TipoSistema)
                xtiposistema = value
            End Set
        End Property

        ''' <summary>
        ''' TIPOS DE MOVIMIENTO DE INVENTARIO
        ''' </summary>
        Enum TipoMovimientoInventario As Integer
            Entrada = 1
            Salida = -1
        End Enum

        ''' <summary>
        ''' TIPOS DE ESTATUS
        ''' </summary>
        Enum TipoEstatus As Integer
            Activo = 1
            Inactivo = 0
            Procesado = 2
        End Enum

        ''' <summary>
        ''' OTRO TIPO DE ESTATUS
        ''' </summary>
        Enum TipoSiNo As Integer
            Si = 1
            No = 2
        End Enum

        ''' <summary>
        ''' TIPO DE PRECIO ASIGNADO AL CLIENTE PARA FACTURAR
        ''' </summary>
        Enum PrecioTarifa As Integer
            Precio_1 = 1
            Precio_2 = 2
        End Enum

        ''' <summary>
        ''' TIPO TASA IMPUESTO 
        ''' </summary>
        Enum TipoTasaImpuesto As Integer
            Exento = 0
            Vigente = 1
            Reducida = 2
            Otra = 3
        End Enum

        ''' <summary>
        ''' TIPO PRODUCTO BALANZA
        ''' </summary>
        Enum TipoProductoBalanza As Integer
            Pesado = 1
            Unidad = 2
        End Enum

        ''' <summary>
        ''' TIPO REPLICA :> ENVIO DEL PRODUCTO AL PTO DE VENTA
        ''' </summary>
        Enum TipoReplica As Integer
            Replicado = 1
            NoReplicado = 0
        End Enum

        ''' <summary>
        ''' TIPO DEPT PTO DE VENTA :> INDICA SI LA FICHA ES CONSIDERADA COMO UN PRODUCTO / DEPARTAMENTO PARA EL PTO DE VENTA
        ''' </summary>
        Enum TipoDepPtoVenta
            TipoDepartamento = 1
            TipoProducto = 0
        End Enum

        ''' <summary>
        ''' TIPO DOCUMENTOS MANEJADOS EN MODULO DE VENTAS
        ''' </summary>
        Enum TipoDocumentoVenta As Integer
            Factura = 1
            NotaEntrega = 2
            Presupuesto = 3
            Pedido = 4
            NotaCredito = 5
        End Enum

        ''' <summary>
        ''' TIPOS DE CALCULO DE UTILDAD
        ''' </summary>
        Enum TipoCalculoUtilidad As Integer
            BaseAlCosto = 1
            BaseAlPrecioVenta = 2
        End Enum

        ''' <summary>
        ''' TIPO DOCUMENTOS MANEJADOS EN MODULO DE COMPRAS
        ''' </summary>
        Enum TipoDocumentoCompra As Integer
            Factura = 1
            NotaDebito = 2
            NotaCredito = 3
            OrdenCompra = 4
        End Enum

        ''' <summary>
        ''' TIPO DOCUMENTOS MANEJADOS EN RETENCIONES
        ''' </summary>
        Enum TipoDocumentoRetencion As Integer
            IVA = 1
            ISLR = 2
        End Enum

        ''' <summary>
        ''' TIPO MOVIMIENTOS A EFECTUAR PARA UNA NOTA DE CREDITO
        ''' </summary>
        Enum TipoMovimientoNC As Integer
            AJUSTE = 1
            DEVOLUCION = 2
            AJUSTE_GLOBAL = 3
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Movimiento En Ventas Detalle
        ''' </summary>
        Enum TipoMovimientoDetalle As Integer
            Venta = 1
            Devolucion = 2
            Ajuste = 3
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Ficha Usadas Para La Entrada Del Cliente
        ''' </summary>
        Enum TipoEntradaCliente As Integer
            FichaBasica = 1
            FichaRegistro = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Documento Registrado En CxC 
        ''' </summary>
        Enum TipoDocumentoRegistradoCxC As Integer
            Factura = 1
            NotaCredito = 2
            NotaDebito = 3
            Prestamo = 4
            ChequeDevuelto = 5
            Anticipo = 6
            Pago = 7
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Documento Registrado En CxC Tabla CXC_Movimientos_Entrada
        ''' </summary>
        Enum TipoDocumentoMovEntradaCxC
            Factura = 1
            NotaDebito = 2
            NotaCredito = 3
            ChequeDevuelto = 4
            Prestamo = 5
            NotaCreditoGeneradaPorSistema = 6
            NotaCreditoNoGeneradaPorSistema = 7
            Anticipos = 8
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Entrada Registrado En CxC Tabla CXC_Movimientos_Entrada
        ''' </summary>
        Enum TipoEntradaMovEntradaCxC
            PropiaDelSistema = 1
            EntradaExterna = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Impresora A Usar Al Imprimir Documento De Venta
        ''' </summary>
        Enum TipoImpresora As Integer
            Fiscal = 1
            Texto = 2
            Grafico = 3
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar Si Hay / No Movimientos Efectuados
        ''' </summary>
        Enum HayMovimientos As Integer
            SiHay = 1
            NoHay = 0
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Diferenciar Comsiones Del Vendedor y Cobrador
        ''' </summary>
        Enum TipoTablaComision
            Vendedor = 1
            Cobrador = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Identificar El Estatus De La Instalacion Del Sistema
        ''' </summary>
        Enum TipoEstatusInstalacion As Integer
            PorActivar = 0
            Instalada = 1
            ExpiroLimite = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Movimiento En Compras Detalle
        ''' </summary>
        Enum TipoMovimientoCompraDetalle As Integer
            Compra = 1
            Devolucion = 2
            Ajuste = 3
            AjusteGlobal = 4
        End Enum

        ''' <summary>
        ''' Tipo Funcionamiento del Sistema / Instalacion 
        ''' </summary>
        Enum TipoSistemaInstalado As Integer
            Basico = 1
            Administrativo = 2
            Full = 3
            Avanzado = 4
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Identificar El Tipo De Pago EN Cuentas Por Pagar
        ''' </summary>
        Enum TipoPago As Integer
            Cheque = 0
            Transferencia = 1
            NotaCredito = 2
            Retencion = 3
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Identificar El Tipo De Cuenta Bancaria
        ''' </summary>
        Enum TipoCuentaBancaria As Integer
            Ahorro = 0
            Corriente = 1
            Fal = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Documento Registrado En CxP Tabla CXP_Movimientos_Entrada
        ''' </summary>
        Enum TipoDocumentoMovEntradaCxP
            Factura = 1
            NotaDebito = 2
            NotaCredito = 3
            ChequeDevuelto = 4
            NotaCreditoNoGeneradaPorSistema = 5
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Indicar El Tipo De Entrada Registrado En CxP Tabla CXP_Movimientos_Entrada
        ''' </summary>
        Enum TipoEntradaMovEntradaCxP
            PropiaDelSistema = 1
            EntradaExterna = 2
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Identificar El Tipo De Documento Registrado En Cuentas Por Pagar
        ''' </summary>
        Enum TipoDocumentoCuentaxPagar As Integer
            Factura = 1
            NotaDebito = 2
            NotaCredito = 3
            ChequeDevuelto = 4
            Prestamo = 5
            Pago = 6
        End Enum

        ''' <summary>
        ''' Tipo Usado Para Identificar El Tipo De Compra Registrada 
        ''' </summary>
        Enum TipoCompraRegistrada As Integer
            CompraMercancia = 1
            CompraGasto = 2
        End Enum

        Enum NivelClave As Integer
            Maxima = 1
            Media = 2
            Minima = 3
            SinClave = 0
        End Enum

        Enum TipoDevolucion
            Total = 1
            Parcial = 2
        End Enum

        ''' <summary>
        ''' Clase Texto, Para Campos String 
        ''' </summary>
        Class CampoTexto
            Private f_texto As String
            Private f_largo As Integer
            Private f_nombre As String

            ''' <summary>
            ''' Contenido Del Campo
            ''' </summary>
            Property c_Texto() As String
                Get
                    Return VerificaLargo(f_texto)
                End Get
                Protected Friend Set(ByVal value As String)
                    f_texto = value
                End Set
            End Property

            ''' <summary>
            ''' Ancho Del Texto En La BD
            ''' </summary>
            Property c_Largo() As Integer
                Get
                    Return f_largo
                End Get
                Protected Friend Set(ByVal value As Integer)
                    f_largo = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Interno Del Campo En La BD
            ''' </summary>
            Property c_NombreInterno() As String
                Get
                    Return f_nombre.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    f_nombre = value
                End Set
            End Property

            Function VerificaLargo(ByVal xtexto As String) As String
                Dim xt As String = xtexto.Trim
                If xt.Length <= Me.c_Largo Then
                    Return xt
                Else
                    Return xt.Substring(0, Me.c_Largo)
                End If
            End Function

            Sub New()
                c_Largo = 0
                c_NombreInterno = ""
                c_Texto = ""
            End Sub

            ''' <param name="xnombre"></param>
            ''' Nombre Campo En La Tabla
            ''' <param name="xlargo" ></param>
            ''' Largo Campo En La Tabla
            Sub New(ByVal xlargo As Integer, ByVal xnombre As String, Optional ByVal xcont As String = "")
                Me.c_Largo = xlargo
                Me.c_NombreInterno = xnombre
                Me.c_Texto = xcont
            End Sub
        End Class

        ''' <summary>
        ''' Clase Single, Para Campos Single
        ''' </summary>
        Class CampoSingle
            Private f_valor As Single
            Private f_nombre As String

            ''' <summary>
            ''' Contenido Del Campo
            ''' </summary>
            Property c_Valor() As Single
                Get
                    Return f_valor
                End Get
                Protected Friend Set(ByVal value As Single)
                    f_valor = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Interno Del Campo En La BD
            ''' </summary>
            Property c_NombreInterno() As String
                Get
                    Return f_nombre.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    f_nombre = value
                End Set
            End Property

            'Public Overrides Function ToString() As String
            '    Return String.Format("{0:#0.00}", Me.c_Valor)
            'End Function

            Sub New()
                c_Valor = 0
                c_NombreInterno = ""
            End Sub

            ''' <param name="xnombre"></param>
            ''' Nombre Campo En La Tabla
            Sub New(ByVal xnombre As String)
                c_Valor = 0
                c_NombreInterno = xnombre
            End Sub
        End Class

        ''' <summary>
        ''' Clase Decimal, Para Campos Decimales
        ''' </summary>
        Class CampoDecimal
            Private f_valor As Decimal
            Private f_nombre As String

            ''' <summary>
            ''' Contenido Del Campo
            ''' </summary>
            Property c_Valor() As Decimal
                Get
                    Return f_valor
                End Get
                Protected Friend Set(ByVal value As Decimal)
                    f_valor = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Interno Del Campo En La BD
            ''' </summary>
            Property c_NombreInterno() As String
                Get
                    Return f_nombre.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    f_nombre = value
                End Set
            End Property

            'Public Overrides Function ToString() As String
            '    Return String.Format("{0:#0.00}", Me.c_Valor)
            'End Function

            Sub New()
                c_Valor = 0
                c_NombreInterno = ""
            End Sub

            ''' <param name="xnombre"></param>
            ''' Nombre Campo En La Tabla
            Sub New(ByVal xnombre As String)
                c_Valor = 0
                c_NombreInterno = xnombre
            End Sub
        End Class

        ''' <summary>
        ''' Clase Integer, Para Campos Enteros
        ''' </summary>
        Class CampoInteger
            Private f_valor As Integer
            Private f_nombre As String

            ''' <summary>
            ''' Contenido Del Campo
            ''' </summary>
            Property c_Valor() As Integer
                Get
                    Return f_valor
                End Get
                Set(ByVal value As Integer)
                    f_valor = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Interno Del Campo En La BD
            ''' </summary>
            Property c_NombreInterno() As String
                Get
                    Return f_nombre.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    f_nombre = value
                End Set
            End Property

            Sub New()
                c_Valor = 0
                c_NombreInterno = ""
            End Sub

            ''' <param name="xnombre"></param>
            ''' Nombre Campo En La Tabla
            Sub New(ByVal xnombre As String)
                c_Valor = 0
                c_NombreInterno = xnombre
            End Sub
        End Class

        ''' <summary>
        ''' Clase Fecha, Para Campos Tipo DateTime
        ''' </summary>
        Class CampoFecha
            Private f_valor As DateTime
            Private f_nombre As String

            ''' <summary>
            ''' Contenido Del Campo
            ''' </summary>
            Property c_Valor() As DateTime
                Get
                    Return f_valor.Date
                End Get
                Set(ByVal value As DateTime)
                    f_valor = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre Interno Del Campo En La BD
            ''' </summary>
            Property c_NombreInterno() As String
                Get
                    Return f_nombre.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    f_nombre = value
                End Set
            End Property

            Sub New()
                c_Valor = Date.MinValue
                c_NombreInterno = ""
            End Sub

            Sub New(ByVal xnom As String)
                c_Valor = Date.MinValue
                c_NombreInterno = xnom
            End Sub
        End Class

        ''' <summary>
        ''' Clase Precio/Costo, Usada Para El Calculo De Base , Iva, Full :> Tanto En Unidades Como Por Empaque
        ''' </summary>
        Class PrecioCosto
            Private xbase As Decimal
            Private xiva As Decimal
            Private xfull As Decimal
            Private xtasa As Decimal
            Private xcontempq As Integer

            Private xbase_inv As Decimal
            Private xiva_inv As Decimal
            Private xfull_inv As Decimal

            ''' <summary>
            ''' NETO 
            ''' </summary>
            Property _Base() As Decimal
                Get
                    Return xbase
                End Get
                Protected Friend Set(ByVal value As Decimal)
                    xbase = value
                    xiva = value * xtasa / 100
                    xfull = value + xiva

                    xbase_inv = value / xcontempq
                    xiva_inv = xbase_inv * xtasa / 100
                    xfull_inv = xbase_inv + xiva_inv
                End Set
            End Property

            Protected Friend WriteOnly Property _TasaImpuesto() As Decimal
                Set(ByVal value As Decimal)
                    xtasa = value
                End Set
            End Property

            Protected Friend WriteOnly Property _ContEmpaque() As Integer
                Set(ByVal value As Integer)
                    xcontempq = value
                End Set
            End Property

            ''' <summary>
            ''' FULL 
            ''' </summary>
            ReadOnly Property _Full() As Decimal
                Get
                    Return Decimal.Round(xfull, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ''' <summary>
            ''' IVA
            ''' </summary>
            ReadOnly Property _Iva() As Decimal
                Get
                    Return Decimal.Round(xiva, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ''' <summary>
            ''' NETO EN UNIDADES DE INVENTARIO 
            ''' </summary>
            ReadOnly Property _Base_Inv() As Decimal
                Get
                    Return Decimal.Round(xbase_inv, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ''' <summary>
            ''' FULL EN UNIDADES DE INVENTARIO 
            ''' </summary>
            ReadOnly Property _Full_Inv() As Decimal
                Get
                    Return Decimal.Round(xfull_inv, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            ''' <summary>
            ''' IVA EN UNIDADES DE INVENTARIO 
            ''' </summary>
            ReadOnly Property _Iva_Inv() As Decimal
                Get
                    Return Decimal.Round(xiva_inv, 2, MidpointRounding.AwayFromZero)
                End Get
            End Property

            Sub New(ByVal base As Decimal, ByVal tasa As Decimal, ByVal cont As Integer)
                M_Limpiar()

                Me._TasaImpuesto = tasa
                Me._ContEmpaque = cont
                Me._Base = base
            End Sub

            Sub New()
                M_Limpiar()
            End Sub

            Sub M_Limpiar()
                xbase = 0
                xiva = 0
                xfull = 0
                xtasa = 0
                xcontempq = 0

                xbase_inv = 0
                xiva_inv = 0
                xfull_inv = 0
            End Sub
        End Class

        ''' <summary>
        ''' Clase Precio, Usada Para El Calculo De Base , Iva, Full 
        ''' </summary>
        Class Precio
            Private xbase As Decimal
            Private xiva As Decimal
            Private xfull As Decimal
            Private xtasa As Decimal

            Property _Base() As Decimal
                Get
                    Return xbase
                End Get
                Set(ByVal value As Decimal)
                    xbase = value
                    xiva = xbase * xtasa / 100
                    xfull = xbase + xiva
                End Set
            End Property

            Property _Tasa() As Decimal
                Get
                    Return xtasa
                End Get
                Set(ByVal value As Decimal)
                    xtasa = value
                End Set
            End Property

            ReadOnly Property _Iva() As Decimal
                Get
                    Return Decimal.Round(xiva, 2)
                End Get
            End Property

            ReadOnly Property _Full() As Decimal
                Get
                    Return Decimal.Round(xfull, 2)
                End Get
            End Property

            Enum TipoFuncion As Integer
                Aplicar = 1
                Desglozar = 2
            End Enum

            Sub New(ByVal base As Decimal, ByVal tasa As Decimal, Optional ByVal xfuncion As TipoFuncion = TipoFuncion.Aplicar)
                M_Limpiar()

                If xfuncion = TipoFuncion.Aplicar Then
                    Me._Tasa = tasa
                    Me._Base = base
                Else
                    Me._Tasa = tasa
                    Me._Base = Decimal.Round(base / (1 + tasa / 100), 2, MidpointRounding.AwayFromZero)
                End If
            End Sub

            Sub New()
                M_Limpiar()
            End Sub

            Sub M_Limpiar()
                xbase = 0
                xiva = 0
                xfull = 0
                xtasa = 0
            End Sub
        End Class

        ''' <summary>
        ''' Clase Costo/Utilidad, Usada Para MOSTRAR COSTO,PRECIO , Margen y Utilidad
        ''' </summary>
        Class VerCostoUtilidad
            Private xcostonetocompra As Decimal
            Private xcontempcompra As Integer

            Private xcontenidoventa As Integer
            Private xprecioneto As Single
            Private xmargen As Single
            Private xutilidad As Single

            Property _CostoNetoCompra() As Decimal
                Get
                    Return xcostonetocompra
                End Get
                Set(ByVal value As Decimal)
                    xcostonetocompra = value
                End Set
            End Property

            ReadOnly Property _CostoNeto() As Decimal
                Get
                    Dim xcost As Decimal = 0
                    xcost = (Me._CostoNetoCompra / Me._ContenidoEmpaqueCompra) * Me._ContenidoEmpaqueVenta
                    xcost = Decimal.Round(xcost, 2, MidpointRounding.AwayFromZero)
                    Return xcost
                End Get
            End Property

            ReadOnly Property _CostoNetoInv() As Decimal
                Get
                    Dim xinv As Decimal = 0
                    xinv = Me._CostoNeto / Me._ContenidoEmpaqueVenta
                    xinv = Decimal.Round(xinv, 2, MidpointRounding.AwayFromZero)
                    Return xinv
                End Get
            End Property

            Property _ContenidoEmpaqueCompra() As Integer
                Get
                    Return xcontempcompra
                End Get
                Set(ByVal value As Integer)
                    xcontempcompra = value
                End Set
            End Property

            Property _ContenidoEmpaqueVenta() As Integer
                Get
                    Return xcontenidoventa
                End Get
                Set(ByVal value As Integer)
                    xcontenidoventa = value
                End Set
            End Property

            Property _PrecioNeto() As Single
                Get
                    Return xprecioneto
                End Get
                Set(ByVal value As Single)
                    xprecioneto = value
                End Set
            End Property

            ReadOnly Property _MargenGanancia() As Decimal
                Get
                    Return (xprecioneto - Me._CostoNeto)
                End Get
            End Property

            Property _Utilidad() As Single
                Get
                    Return xutilidad
                End Get
                Set(ByVal value As Single)
                    xutilidad = value
                End Set
            End Property

            Sub New()
                Me._ContenidoEmpaqueCompra = 0
                Me._ContenidoEmpaqueVenta = 0
                Me._CostoNetoCompra = 0
                Me._PrecioNeto = 0
                Me._Utilidad = 0
            End Sub
        End Class

        ''' <summary>
        ''' Clase Tasa/Valor Para Aquellas Propiedades Que Almacenan Una Tasa/Valor como descuentos, cargos, etc..
        ''' </summary>
        Public Class Tasa_Valor
            Private f_tasa As Decimal
            Private f_valor As Decimal

            Property _Tasa() As Decimal
                Get
                    Return f_tasa
                End Get
                Set(ByVal value As Decimal)
                    f_tasa = value
                End Set
            End Property

            Property _Valor() As Decimal
                Get
                    Return f_valor
                End Get
                Set(ByVal value As Decimal)
                    f_valor = value
                End Set
            End Property

            Sub New(ByVal xtasa As Decimal, ByVal xvalor As Decimal)
                _Tasa = xtasa
                _Valor = xvalor
            End Sub

            Sub New()
                _Tasa = 0
                _Valor = 0
            End Sub
        End Class

        ''' <summary>
        ''' Clase Base/Tasa/Impuesto Para Aquellas Propiedades Que Almacenan costos/precios, etc..
        ''' </summary>
        Public Class Base_Impuesto_Tasa
            Private f_base As Decimal
            Private f_impuesto As Decimal
            Private f_tasa As Decimal

            Property _Base() As Decimal
                Get
                    Return f_base
                End Get
                Set(ByVal value As Decimal)
                    f_base = value
                End Set
            End Property

            Property _Impuesto() As Decimal
                Get
                    Return f_impuesto
                End Get
                Set(ByVal value As Decimal)
                    f_impuesto = value
                End Set
            End Property

            Property _Tasa() As Decimal
                Get
                    Return f_tasa
                End Get
                Set(ByVal value As Decimal)
                    f_tasa = value
                End Set
            End Property

            Sub New(ByVal xbase As Decimal, ByVal ximpuesto As Decimal, ByVal xtasa As Decimal)
                _Base = xbase
                _Impuesto = ximpuesto
                _Tasa = xtasa
            End Sub

            Sub New()
                _Base = 0
                _Impuesto = 0
                _Tasa = 0
            End Sub
        End Class

        ''' <summary>
        ''' Clase Base NUEVA PARA CUALQUIER TIPO DE DATO
        ''' </summary>
        Public Class CampoDato
            Private xnombre_campo As String
            Private xlargo_campo As Integer
            Private xcontenido_campo As Object
            Private xdecimales_campo As Integer

            Property _NombreCampo() As String
                Get
                    Return Me.xnombre_campo.Trim
                End Get
                Protected Friend Set(ByVal value As String)
                    Me.xnombre_campo = value
                End Set
            End Property

            Property _LargoCampo() As Integer
                Get
                    Return Me.xlargo_campo
                End Get
                Protected Friend Set(ByVal value As Integer)
                    Me.xlargo_campo = value
                End Set
            End Property

            Property _ContenidoCampo() As Object
                Get
                    Return Me.xcontenido_campo
                End Get
                Protected Friend Set(ByVal value As Object)
                    Me.xcontenido_campo = value
                End Set
            End Property

            Property _DecimalesCampo() As Integer
                Get
                    Return Me.xdecimales_campo
                End Get
                Protected Friend Set(ByVal value As Integer)
                    Me.xdecimales_campo = value
                End Set
            End Property

            Public Function _RetornarValor(Of T)() As T
                If Me._ContenidoCampo Is Nothing Then
                    Return Nothing
                Else
                    Dim rt As T = CType(Me._ContenidoCampo, T)
                    Return rt
                End If
            End Function

            Sub New()
                Me._NombreCampo = ""
                Me._LargoCampo = 0
                Me._ContenidoCampo = Nothing
                Me._DecimalesCampo = 0
            End Sub

            Sub New(ByVal xnombre_campo As String, Optional ByVal xlargo_campo As Integer = 0)
                Me._NombreCampo = xnombre_campo
                Me._LargoCampo = xlargo_campo
                Me._ContenidoCampo = Nothing
                Me._DecimalesCampo = 0
            End Sub
        End Class

        Protected Friend Shared Function InicializarDato(ByVal xobjeto As Object) As Boolean
            Try
                Dim xb As System.Reflection.BindingFlags = BindingFlags.Instance Or BindingFlags.DeclaredOnly _
                                                           Or BindingFlags.Public Or BindingFlags.Static Or BindingFlags.NonPublic

                Dim xobj As Object = xobjeto
                Dim xpropiedades As PropertyInfo() = xobjeto.GetType().GetProperties(xb)
                For Each xp In xpropiedades
                    If xp.Name.ToString.Trim.ToUpper = "_CONTENIDOCAMPO" Then
                        Dim xvalor As Object = Nothing
                        xp.SetValue(xobj, xvalor, Nothing)
                    End If
                    If xp.PropertyType Is GetType(CampoDato) Then
                        InicializarDato(xp.GetValue(xobj, Nothing))
                    End If
                Next
                Return (True)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Shared Property _MiCadenaConexion() As String
            Get
                Return xcadena
            End Get
            Set(ByVal value As String)
                xcadena = value
            End Set
        End Property

        ''' <summary>
        ''' Funcion. Devuelve Fecha Del Motor BD
        ''' </summary>
        ReadOnly Property p_FechaDelMotorBD() As Date
            Get
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Using xcmd As New SqlCommand("SELECT getdate()", xcon)
                            Return CType(xcmd.ExecuteScalar(), Date).Date
                        End Using
                    End Using
                Catch ex As Exception
                    Return Date.MinValue
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Funcion: Devuelve Hora Del Motor BD
        ''' </summary>
        ReadOnly Property p_HoraDelMotorBD() As String
            Get
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Using xcmd As New SqlCommand("SELECT getdate()", xcon)
                            Return CType(xcmd.ExecuteScalar(), Date).ToShortTimeString
                        End Using
                    End Using
                Catch ex As Exception
                    Return ""
                End Try
            End Get
        End Property

        Shared Property p_ClaveNivelMaximo() As String
            Get
                Return xclavenivelmaximo
            End Get
            Set(ByVal value As String)
                xclavenivelmaximo = value
            End Set
        End Property

        Shared Property p_ClaveNivelMedio() As String
            Get
                Return xclavenivelmedio
            End Get
            Set(ByVal value As String)
                xclavenivelmedio = value
            End Set
        End Property

        Shared Property p_ClaveNivelMinimo() As String
            Get
                Return xclavenivelminimo
            End Get
            Set(ByVal value As String)
                xclavenivelminimo = value
            End Set
        End Property

        Sub New()
            _MiCadenaConexion = ""
            Inicializa()
        End Sub

        Sub New(ByVal xcadenaconexion As String)
            _MiCadenaConexion = xcadenaconexion
            Inicializa()
        End Sub

        Private Sub Inicializa()
            p_TipoSistema = TipoSistema.Administrativo

            p_ClaveNivelMaximo = ""
            p_ClaveNivelMedio = ""
            p_ClaveNivelMinimo = ""

            F_VerificarConexion()

            xfichaProducto = New FichaProducto
            xfichaGlobal = New FichaGlobal
            xfichaCliente = New FichaClientes
            xfichaProveedor = New FichaProveedores
            xfichaVentas = New FichaVentas
            xfichasCxc = New FichaCtasCobrar
            xfichaVendedor = New FichaVendedores
            xfichaCobrador = New FichaCobradores
            xfichaCompras = New FichaCompras
            xfichasCxP = New FichaCtasPagar
            xfichapanaderia = New FichaPanaderia
            xfichafastfood = New FastFood
            xfichaestacionamiento = New Estacionamiento
            xficharestaurant = New Restaurant
            xfichaposonline = New PosOnline
            xfichagastos = New ControlGastos
            xfichaUsuarioVendedor = New UsuarioVendedor

        End Sub

        ''' <summary>
        ''' Funcion: Obtener Una Lista De Datos
        ''' </summary>
        ''' <param name="xsql"></param>
        ''' Instruccion A Ejecutar
        ''' <param name="xtb"></param>
        ''' Tabla A Colocar La Data Resultante
        Function F_GetData(ByVal xsql As String, ByVal xtb As DataTable) As Boolean
            Try
                xtb.Rows.Clear()
                Using xcon As New SqlClient.SqlDataAdapter(xsql, _MiCadenaConexion)
                    xcon.Fill(xtb)
                End Using
                Return True
            Catch ex As Exception
                Throw New Exception("PRINCIPAL: " + vbCrLf + "GET DATA" + vbCrLf + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Funcion: Obtener Una Lista De Datos
        ''' </summary>
        ''' <param name="xsql"></param>
        ''' Instruccion A Ejecutar
        ''' <param name="xtb"></param>
        ''' Tabla A Colocar La Data Resultante
        ''' <param name="xlista"></param>
        ''' Lista De Parametros A Pasar
        Function F_GetData(ByVal xsql As String, ByVal xtb As DataTable, ByVal ParamArray xlista() As SqlParameter) As Boolean
            Try
                xtb.Rows.Clear()
                Using xcon As New SqlClient.SqlDataAdapter(xsql, _MiCadenaConexion)
                    xcon.SelectCommand.Parameters.Clear()
                    If xlista IsNot Nothing Then
                        For Each xp In xlista
                            xcon.SelectCommand.Parameters.Add(xp)
                        Next
                    End If
                    xcon.Fill(xtb)
                End Using
                Return True
            Catch ex As Exception
                Throw New Exception("PRINCIPAL: " + vbCrLf + "GET DATA" + vbCrLf + ex.Message)
            End Try
        End Function

        Function F_GetData(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As DataSet
            Try
                Dim xds As New DataSet

                Using xadp As New SqlDataAdapter(xsql, _MiCadenaConexion)
                    xadp.SelectCommand.Parameters.Clear()
                    If xlista IsNot Nothing Then
                        For Each xp In xlista
                            xadp.SelectCommand.Parameters.Add(xp)
                        Next
                    End If
                    xadp.Fill(xds)
                End Using

                Return xds
            Catch ex As Exception
                Throw New Exception("PRINCIPAL: " + vbCrLf + "GET DATA" + vbCrLf + ex.Message)
            End Try
        End Function

        Function F_GetData(ByVal xsql As String, ByVal xds As DataSet, ByVal ParamArray xlista() As SqlParameter) As Boolean
            Try
                Using xadp As New SqlDataAdapter(xsql, _MiCadenaConexion)
                    xadp.SelectCommand.Parameters.Clear()
                    For Each xp In xlista
                        xadp.SelectCommand.Parameters.Add(xp)
                    Next
                    xadp.Fill(xds)
                End Using

                Return True
            Catch ex As Exception
                Throw New Exception("PRINCIPAL: " + vbCrLf + "GET DATA" + vbCrLf + ex.Message)
            End Try
        End Function

        Function F_GetData(ByVal xsql As String, ByRef xrow As DataRow, ByVal ParamArray xlista() As SqlParameter) As Boolean
            Try
                Dim xtb As New DataTable
                Using xadp As New SqlDataAdapter(xsql, _MiCadenaConexion)
                    xadp.SelectCommand.Parameters.Clear()
                    For Each xp In xlista
                        xadp.SelectCommand.Parameters.Add(xp)
                    Next
                    xadp.Fill(xtb)
                End Using

                xrow = xtb(0)

                Return True
            Catch ex As Exception
                Throw New Exception("PRINCIPAL: " + vbCrLf + "GET DATA" + vbCrLf + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Funcion: Buscar y Cargar Data Del Usuario
        ''' </summary>
        ''' <param name="xnombre"></param>
        ''' Nombre Del Usuario A Buscar
        ''' <param name="xclave"></param>
        ''' Clave Del Usuario
        ''' <returns></returns>
        Function F_ConectarConUsuario(ByVal xnombre As String, ByVal xclave As String) As Object
            Try
                Dim xsql As String = "select auto from usuarios where nombre=@nombre and clave=@clave and estatus='Activo'"
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()
                    Using xcmd As New SqlCommand(xsql, xcon)
                        xcmd.Parameters.AddWithValue("@nombre", xnombre)
                        xcmd.Parameters.AddWithValue("@clave", xclave)
                        Return xcmd.ExecuteScalar
                    End Using
                End Using
            Catch ex As Exception
                Throw New Exception("MODULO: CONECTAR CON USUARIO." + vbCrLf + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Funcion: Carga Inicial De Fichas De Datos Del Sistema
        ''' </summary>
        ''' <param name="xauto_usuario">
        ''' Automatico Del Usuario A Cargar
        ''' </param>
        Function F_CargaInicial(ByVal xauto_usuario As String) As Boolean
            Try
                Dim xobj As Object = Nothing
                Dim xsql_3 As String = "select * from grupo_opciones where codigo_grupo=@codigo_grupo"
                Dim xsql_4 As String = "select * from fiscal"
                Dim xsql_5 As String = "select * from opciones where (codigo like ('GLOBAL%')) or (codigo like ('VENTAS%')) or " & _
                  "(codigo like ('CLIENTE%')) or (codigo like ('INVENT%')) or (codigo like ('CXC%')) or (codigo like ('VENDED%')) or " & _
                  "(codigo like ('COBRAD%')) or (codigo like ('PANAD%')) or (codigo like ('FAST%')) or (codigo like ('REST%')) order by codigo"

                'FICHA DEL NEGOCIO
                Me.f_FichaGlobal.f_Negocio.F_CargarDataNegocio()

                'FICHA USUARIOS - GRUPO
                Me.f_FichaGlobal.f_Usuario.F_BuscarRegistro(xauto_usuario)

                'FICHA PERMISOS DEL USUARIO
                Me.f_FichaGlobal.f_PermisosUsuario.LimpiarFicha()
                Me.f_FichaGlobal.f_PermisosUsuario.p_TablaDato.Clear()
                Using xadap As New SqlDataAdapter(xsql_3, _MiCadenaConexion)
                    xadap.SelectCommand.Parameters.AddWithValue("@codigo_grupo", Me.f_FichaGlobal.f_Usuario.RegistroDato._AutoGrupo)
                    xadap.Fill(Me.f_FichaGlobal.f_PermisosUsuario.p_TablaDato)
                End Using
                Me.f_FichaGlobal.f_PermisosUsuario.M_CargarFicha()

                'FICHA TASAS FISCALES
                Using xadap As New SqlDataAdapter(xsql_4, _MiCadenaConexion)
                    xadap.Fill(Me.f_FichaGlobal.f_Fiscal.TablaFiscal)
                End Using
                Me.f_FichaGlobal.f_Fiscal.M_CargarFicha()

                'FICHA CONFIGURACION GLOBAL
                Using xadap As New SqlDataAdapter(xsql_5, _MiCadenaConexion)
                    xadap.Fill(Me.f_FichaGlobal.f_ConfSistema.p_Tabla)
                End Using
                Me.f_FichaGlobal.f_ConfSistema.M_CargarFicha()

                'FICHA(TARIFAS) : PARA(Estacionamiento)
                If p_TipoSistema = TipoSistema.Estacionamiento Then
                    Me.f_FichaEstacionamiento.f_Tarifas.F_CargarTarifas()
                End If

                Return True
            Catch ex As Exception
                Throw New Exception("CARGAR DATOS INICIALES." + vbCrLf + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' MODULO USADO PARA PANADERIA CARGA DE PEDIDO, DONDE NO HACE FALTA IDENTIFICARSE
        ''' </summary>
        Function F_CargaInicial() As Boolean
            Try
                Dim xobj As Object = Nothing
                Dim xsql_1 As String = "select * from fiscal"
                Dim xsql_2 As String = "select * from opciones where (codigo like ('GLOBAL%')) or (codigo like ('VENTAS%')) or " & _
                  "(codigo like ('CLIENTE%')) or (codigo like ('INVENT%')) or (codigo like ('CXC%')) or (codigo like ('VENDED%')) or " & _
                  "(codigo like ('COBRAD%')) or (codigo like ('PANAD%')) or (codigo like ('FAST%')) or (codigo like ('REST%')) order by codigo"

                'FICHA DEL NEGOCIO
                Me.f_FichaGlobal.f_Negocio.F_CargarDataNegocio()

                'FICHA TASAS FISCALES
                Using xadap As New SqlDataAdapter(xsql_1, _MiCadenaConexion)
                    xadap.Fill(Me.f_FichaGlobal.f_Fiscal.TablaFiscal)
                End Using
                Me.f_FichaGlobal.f_Fiscal.M_CargarFicha()

                'FICHA CONFIGURACION GLOBAL
                Using xadap As New SqlDataAdapter(xsql_2, _MiCadenaConexion)
                    xadap.Fill(Me.f_FichaGlobal.f_ConfSistema.p_Tabla)
                End Using
                Me.f_FichaGlobal.f_ConfSistema.M_CargarFicha()

                'FICHA(TARIFAS) : PARA(Estacionamiento)
                If p_TipoSistema = TipoSistema.Estacionamiento Then
                    Me.f_FichaEstacionamiento.f_Tarifas.F_CargarTarifas()
                End If

                Return True
            Catch EX2 As SqlException
                Throw New Exception(EX2.Message + vbCrLf + EX2.Number)
            Catch ex As Exception
                Throw New Exception("CARGAR DATOS INICIALES." + vbCrLf + ex.Message)
            End Try
        End Function

        Private Shared Function ValorEscalar(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As Object
            Dim xobj As Object = Nothing
            Try
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()
                    Using xcmd As New SqlCommand(xsql, xcon)
                        xcmd.Parameters.Clear()
                        For Each xp In xlista
                            xcmd.Parameters.Add(xp)
                        Next
                        xobj = xcmd.ExecuteScalar()
                    End Using
                    Return xobj
                End Using
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return xobj
            End Try
        End Function

        Shared Function F_GetString(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As String
            Try
                Dim xobj As Object = ValorEscalar(xsql, xlista)
                If IsDBNull(xobj) Or IsNothing(xobj) Then
                    Return ""
                Else
                    Return xobj.ToString()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
            End Try
        End Function

        Shared Function F_GetInteger(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As Integer
            Try
                Dim xobj As Object = ValorEscalar(xsql, xlista)
                If IsDBNull(xobj) Or IsNothing(xobj) Then
                    Return 0
                Else
                    Return CType(xobj, Integer)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
        End Function

        Shared Function F_GetDate(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As Date
            Try
                Dim xobj As Object = ValorEscalar(xsql, xlista)
                If IsDBNull(xobj) Or IsNothing(xobj) Then
                    Return Date.MinValue
                Else
                    Return CType(xobj, Date)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Date.MinValue
            End Try
        End Function

        Shared Function F_GetDecimal(ByVal xsql As String, ByVal ParamArray xlista() As SqlParameter) As Decimal
            Try
                Dim xobj As Object = ValorEscalar(xsql, xlista)
                If IsDBNull(xobj) Or IsNothing(xobj) Then
                    Return 0
                Else
                    Return CType(xobj, Decimal)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
        End Function

        Shared Sub LimpiarVariableTipo(ByVal xob As Object)
            Dim xflag As BindingFlags = BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.DeclaredOnly Or BindingFlags.Static Or BindingFlags.NonPublic
            Dim x As Type = xob.GetType
            Dim xinfo As PropertyInfo() = x.GetProperties(xflag)

            Dim xobj As Object = xob
            For Each xinf As PropertyInfo In xinfo
                If xinf.Name.ToString.Trim = "c_Texto" Then
                    xinf.SetValue(xobj, "", Nothing)
                    Exit For
                End If
                If xinf.Name.ToString.Trim = "c_Valor" Then
                    If xobj.ToString.Contains("CampoDecimal") Then
                        Dim xvalor As Decimal = 0
                        xinf.SetValue(xobj, xvalor, Nothing)
                    End If
                    If xobj.ToString.Contains("CampoSingle") Then
                        Dim xvalor As Single = 0
                        xinf.SetValue(xobj, xvalor, Nothing)
                    End If
                    If xobj.ToString.Contains("CampoInteger") Then
                        Dim xvalor As Integer = 0
                        xinf.SetValue(xobj, xvalor, Nothing)
                    End If
                    If xobj.ToString.Contains("CampoFecha") Then
                        Dim xvalor As Date = Date.MinValue
                        xinf.SetValue(xobj, xvalor, Nothing)
                    End If

                    Exit For
                End If
                If xinf.PropertyType.ToString.Contains("CampoTexto") Or xinf.PropertyType.ToString.Contains("CampoInteger") _
                    Or xinf.PropertyType.ToString.Contains("CampoDecimal") Or xinf.PropertyType.ToString.Contains("CampoSingle") _
                    Or xinf.PropertyType.ToString.Contains("CampoFecha") Then
                    LimpiarVariableTipo(xinf.GetValue(xob, Nothing))
                End If
            Next
        End Sub

        Function F_CompactarBD(ByVal xbd As String) As Boolean
            Try
                Dim xcn As New SqlConnectionStringBuilder
                xcn.ConnectionString = _MiCadenaConexion
                With xcn
                    .UserID = "Propietario"
                    .Password = "fs-ASPIRE-5745"
                End With

                If MessageBox.Show("Este Procedimiento Puede Tardar Varios Minutos Dependiendo Del Tamaño De La Base De Datos, Presione Cualquier Tecla Para Continuar...", "*** Mensaje De Alerta ***", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    Using xcon As New SqlConnection(xcn.ConnectionString)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandTimeout = 0
                                xcmd.CommandType = CommandType.StoredProcedure
                                xcmd.CommandText = "sp_compactar"
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                End If
            Catch ex As Exception
                Throw New Exception("PRINCIPAL" + vbCrLf + "COMPACTAR BD" + vbCrLf + ex.Message)
            End Try
        End Function

        Function F_RespaldarBD(ByVal xpath As String) As Boolean
            Try
                Dim xcn As New SqlConnectionStringBuilder
                xcn.ConnectionString = _MiCadenaConexion
                With xcn
                    .UserID = "Propietario"
                    .Password = "fs-ASPIRE-5745"
                End With

                If MessageBox.Show("Este Procedimiento Puede Tardar Varios Minutos Dependiendo Del Tamaño De La Base De Datos, Presione Cualquier Tecla Para Continuar...", "*** Mensaje De Alerta ***", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    Using xcon As New SqlConnection(xcn.ConnectionString)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandTimeout = 0
                                xcmd.CommandType = CommandType.StoredProcedure
                                xcmd.CommandText = "sp_respaldo"
                                xcmd.Parameters.AddWithValue("@RESP", xpath + "\" + xcn.InitialCatalog + ".bak")
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch EX2 As SqlException
                            Throw New Exception(EX2.Message + ", " + EX2.Number.ToString)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                End If
            Catch ex As Exception
                Throw New Exception("PRINCIPAL" + vbCrLf + "RESPALDAR BD" + vbCrLf + ex.Message)
            End Try
        End Function

        Function F_MantenimientoBD() As Boolean
            Try
                Dim xcn As New SqlConnectionStringBuilder
                xcn.ConnectionString = _MiCadenaConexion
                With xcn
                    .UserID = "Propietario"
                    .Password = "fs-ASPIRE-5745"
                End With

                If MessageBox.Show("Este Procedimiento Puede Tardar Varios Minutos Dependiendo Del Tamaño De La Base De Datos, Presione Cualquier Tecla Para Continuar...", "*** Mensaje De Alerta ***", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                    Using xcon As New SqlConnection(xcn.ConnectionString)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandTimeout = 0
                                xcmd.CommandType = CommandType.StoredProcedure
                                xcmd.CommandText = "sp_mantenimientobd"
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                End If
            Catch ex As Exception
                Throw New Exception("PROBLEMA AL EFECTUAR EL MANTENIMIENTO" + vbCrLf + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Funcion Que Permite Retornar Si La Conexion Se Establecio Correctamente
        ''' </summary>
        Function F_VerificarConexion() As Boolean
            Try
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()
                End Using
                Return True
            Catch ex2 As SqlException
                Throw New Exception("ERROR AL INTENTAR CONECTAR CON BASE DE DATOS... " + vbCrLf + "ERROR NUMERO: " + ex2.Number.ToString + vbCrLf + "MENSAJE: " + ex2.Message)
            Catch ex As Exception
                Throw New Exception("ERROR AL INTENTAR CONECTAR CON BASE DE DATOS... " + vbCrLf + "MENSAJE: " + ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Funcion Que Permite Retornar Si La Conexion Se Establecio Correctamente
        ''' </summary>
        Shared Function F_VerificarConexionRemota(ByVal xcadena As String) As Boolean
            Try
                Using xcon As New SqlConnection(xcadena)
                    xcon.Open()
                End Using
                Return True
            Catch ex2 As SqlException
                Select Case ex2.Number
                    Case 18456, 53, 4060
                        Throw New Exception("ERROR AL INTENTAR CONECTAR CON BASE DE DATOS... " + vbCrLf + "VERIFIQUE: INSTANCIA DEL SERVIDOR DE BASE DE DATOS, CABLE DE RED, USUARIO, CONFIGURACION DEL EQUIPO, TARJETA DE RED, ETC" + vbCrLf + "PROBLEMA ES DE RED")
                    Case Else
                        Throw New Exception("ERROR AL INTENTAR CONECTAR CON BASE DE DATOS... " + vbCrLf + "ERROR NUMERO: " + ex2.Number.ToString + vbCrLf + "MENSAJE: " + ex2.Message)
                End Select
            Catch ex As Exception
                Throw New Exception("ERROR AL INTENTAR CONECTAR CON BASE DE DATOS... " + vbCrLf + "MENSAJE: " + ex.Message)
            End Try
        End Function

        Function F_VerificarUsuario(ByVal xnombre As String, ByVal xclave As String) As String
            Try
                Dim xobj As Object = Nothing
                Dim xsql As String = "select auto from usuarios where nombre=@nombre and clave=@clave and estatus='Activo'"
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()
                    Using xcmd As New SqlCommand(xsql, xcon)
                        xcmd.Parameters.AddWithValue("@nombre", xnombre)
                        xcmd.Parameters.AddWithValue("@clave", xclave)
                        xobj = xcmd.ExecuteScalar()
                    End Using
                    If (xobj Is Nothing) Or (IsDBNull(xobj)) Then
                        Return ""
                    Else
                        Return xobj.ToString
                    End If
                End Using
            Catch ex As Exception
                Throw New Exception("Modulo: Principal" & vbCrLf & "Funcion: VerificarUsuario" & vbCrLf + ex.Message)
            End Try
        End Function

        Protected Friend Shared Function F_TransformarDecimal(ByVal xvalorstring As String) As Decimal
            Dim x As String = ""
            Dim xvalor As Decimal = 0

            If xvalorstring.Contains(",") Then
                If My.Application.Culture.NumberFormat.CurrencyDecimalSeparator = "," Then
                    x = xvalorstring
                Else
                    x = xvalorstring.Replace(",", My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
                End If
            Else
                If My.Application.Culture.NumberFormat.CurrencyDecimalSeparator = "." Then
                    x = xvalorstring
                Else
                    x = xvalorstring.Replace(".", My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
                End If
            End If
            Decimal.TryParse(x, xvalor)
            Return xvalor
        End Function


        Public Class Resultado

            Public Enum EnumResult As Integer
                isOk = 1
                isError = -1
            End Enum


            Public Property Mensaje As String
            Public Property Result As EnumResult


            Sub New()
                Mensaje = ""
                Result = EnumResult.isOk
            End Sub


        End Class


        Public Class ResultadoEntidad(Of T)
            Inherits Resultado


            Property Entidad As T


            Sub New()
                MyBase.New()
            End Sub


        End Class


        Public Function TasaActualDolar_GetData() As ResultadoEntidad(Of Decimal)
            Dim result As New ResultadoEntidad(Of Decimal)

            Try
                Dim xobj As Object = Nothing
                Dim xsql As String = "select divisa from fiscal"
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()
                    Using xcmd As New SqlCommand(xsql, xcon)
                        xobj = xcmd.ExecuteScalar()
                    End Using
                    If (xobj Is Nothing) Or (IsDBNull(xobj)) Then
                        result.Mensaje = "PROPIEDAD DIVISA NO DEFINIDA"
                        result.Result = Resultado.EnumResult.isError
                    Else
                        result.Entidad = CType(xobj, Decimal)
                    End If
                End Using
            Catch ex As Exception
                result.Mensaje = ex.Message
                result.Result = Resultado.EnumResult.isError
            End Try

            Return result
        End Function

        Public Function TasaActualDolar_ActualizarData(valor As Decimal) As Resultado
            Dim xtr As SqlTransaction = Nothing
            Dim result As New Resultado

            Try
                Dim xobj As Object = Nothing
                Dim xsql As String = "update fiscal set divisa=@divisa"
                Using xcon As New SqlConnection(_MiCadenaConexion)
                    xcon.Open()

                    Try
                        xtr = xcon.BeginTransaction
                        Using xcmd As New SqlCommand(xsql, xcon, xtr)
                            xcmd.Parameters.AddWithValue("@divisa", valor)
                            xobj = xcmd.ExecuteNonQuery()
                        End Using

                        xtr.Commit()
                    Catch ex As Exception
                        xtr.Rollback()
                        result.Mensaje = ex.Message
                        result.Result = Resultado.EnumResult.isError
                    End Try

                End Using
            Catch ex As Exception
                result.Mensaje = ex.Message
                result.Result = Resultado.EnumResult.isError
            End Try

            Return result
        End Function


    End Class
End Namespace
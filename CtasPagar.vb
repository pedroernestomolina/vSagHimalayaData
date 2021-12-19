Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class FichaCtasPagar

            Public Class c_CxP
                Public Class c_Registro
                    Private f_auto As New CampoTexto
                    Private f_fecha As New CampoFecha
                    Private f_fecha_carga As New CampoFecha
                    Private f_tipo_documento As New CampoTexto
                    Private f_documento As New CampoTexto
                    Private f_fecha_vencimiento As New CampoFecha
                    Private f_detalle As New CampoTexto
                    Private f_importe As New CampoDecimal
                    Private f_acumulado As New CampoDecimal
                    Private f_auto_proveedor As New CampoTexto
                    Private f_proveedor As New CampoTexto
                    Private f_ci_rif As New CampoTexto
                    Private f_codigo_proveedor As New CampoTexto
                    Private f_cancelado As New CampoTexto
                    Private f_resta As New CampoDecimal
                    Private f_operacion As New CampoTexto
                    Private f_estatus As New CampoTexto
                    Private f_auto_documento As New CampoTexto
                    Private f_signo As New CampoInteger

                    'NUEVOS
                    Private f_auto_mov_entrada As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private f_fecha_recepcion_devolucion As CampoFecha
                    Private f_numero As CampoTexto
                    Private f_auto_agencia As CampoTexto
                    Private f_agencia As CampoTexto
                    Private f_numero_cuenta As CampoTexto
                    Private f_tipo_cuenta As CampoTexto
                    Private f_titular As CampoTexto

                    Protected Friend Property c_AutoCxP() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
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

                    Protected Friend Property c_FechaProceso() As CampoFecha
                        Get
                            Return f_fecha_carga
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_carga = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipo_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_documento = value
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

                    Protected Friend Property c_FechaVencimiento() As CampoFecha
                        Get
                            Return f_fecha_vencimiento
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_vencimiento = value
                        End Set
                    End Property

                    Protected Friend Property c_NotaDetalle() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImporte() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAcumulado() As CampoDecimal
                        Get
                            Return f_acumulado
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_acumulado = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_auto_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_proveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreProveedor() As CampoTexto
                        Get
                            Return f_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_proveedor = value
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

                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigo_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_proveedor = value
                        End Set
                    End Property

                    Protected Friend Property c_EstatusCancelado() As CampoTexto
                        Get
                            Return f_cancelado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cancelado = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoPorPagar() As CampoDecimal
                        Get
                            Return f_resta
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_resta = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoOperacion() As CampoTexto
                        Get
                            Return f_operacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_operacion = value
                        End Set
                    End Property

                    Protected Friend Property c_EstatusDocumento() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
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

                    ReadOnly Property _AutoCxP() As String
                        Get
                            Return c_AutoCxP.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return New Date(c_FechaProceso.c_Valor.Year, c_FechaProceso.c_Valor.Month, c_FechaProceso.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoCuentaxPagar
                        Get
                            Select Case c_TipoDocumento.c_Texto
                                Case "FAC"
                                    Return TipoDocumentoCuentaxPagar.Factura
                                Case "ND", "NDF"
                                    Return TipoDocumentoCuentaxPagar.NotaDebito
                                Case "NC", "NCF"
                                    Return TipoDocumentoCuentaxPagar.NotaCredito
                                Case "CHD"
                                    Return TipoDocumentoCuentaxPagar.ChequeDevuelto
                                Case "PRE"
                                    Return TipoDocumentoCuentaxPagar.Prestamo
                                Case "PAG"
                                    Return TipoDocumentoCuentaxPagar.Pago
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumento() As String
                        Get
                            Return c_NumeroDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaVencimiento() As Date
                        Get
                            Return New Date(c_FechaVencimiento.c_Valor.Year, c_FechaVencimiento.c_Valor.Month, c_FechaVencimiento.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _NotaDetalle() As String
                        Get
                            Return c_NotaDetalle.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoImporte() As Decimal
                        Get
                            Return c_MontoImporte.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoAcumulado() As Decimal
                        Get
                            Return c_MontoAcumulado.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreProveedor() As String
                        Get
                            Return c_NombreProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifProveedor() As String
                        Get
                            Return c_CiRifProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return c_CodigoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _EstatusCancelado() As TipoSiNo
                        Get
                            Select Case c_EstatusCancelado.c_Texto.Trim
                                Case "1" : Return TipoSiNo.Si
                                Case "0" : Return TipoSiNo.No
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _MontoPorPagar() As Decimal
                        Get
                            Return c_MontoPorPagar.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoOperacion() As String
                        Get
                            Return c_TipoOperacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _EstatusDocumento() As TipoEstatus
                        Get
                            Select Case c_EstatusDocumento.c_Texto.Trim
                                Case "1" : Return TipoEstatus.Inactivo
                                Case "0" : Return TipoEstatus.Activo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Signo() As Integer
                        Get
                            Return c_Signo.c_Valor
                        End Get
                    End Property


                    'CAMPO NUEVOS
                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    Protected Friend Property c_AutoMovimientoEntrada() As CampoTexto
                        Get
                            Return f_auto_mov_entrada
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_mov_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMovimientoEntrada() As String
                        Get
                            Return Me.c_AutoMovimientoEntrada.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaRecepcionDevolucion() As CampoFecha
                        Get
                            Return f_fecha_recepcion_devolucion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_recepcion_devolucion = value
                        End Set
                    End Property

                    ReadOnly Property _FechaRecepcionDevolucion() As Date
                        Get
                            Return c_FechaRecepcionDevolucion.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' numero cheque/deposito/planilla/etc
                    ''' </summary>
                    Protected Friend Property c_Numero() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
                        End Set
                    End Property

                    ReadOnly Property _Numero() As String
                        Get
                            Return c_Numero.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoAgencia() As CampoTexto
                        Get
                            Return f_auto_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_agencia = value
                        End Set
                    End Property

                    ReadOnly Property _AutoAgencia() As String
                        Get
                            Return c_AutoAgencia.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreAgencia() As CampoTexto
                        Get
                            Return f_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_agencia = value
                        End Set
                    End Property

                    ReadOnly Property _NombreAgencia() As String
                        Get
                            Return c_NombreAgencia.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NumeroCuenta() As CampoTexto
                        Get
                            Return f_numero_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero_cuenta = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroCuenta() As String
                        Get
                            Return c_NumeroCuenta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_TipoCuenta() As CampoTexto
                        Get
                            Return f_tipo_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_cuenta = value
                        End Set
                    End Property

                    ReadOnly Property _TipoCuenta() As TipoCuentaBancaria
                        Get
                            Select Case c_TipoCuenta.c_Texto.Trim
                                Case "Ahorro" : Return TipoCuentaBancaria.Ahorro
                                Case "Corriente" : Return TipoCuentaBancaria.Corriente
                                Case "Fal" : Return TipoCuentaBancaria.Fal
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_NombreTitular() As CampoTexto
                        Get
                            Return f_titular
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_titular = value
                        End Set
                    End Property

                    ReadOnly Property _NombreTitular() As String
                        Get
                            Return c_NombreTitular.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        c_AutoCxP = New CampoTexto(10, "auto")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_FechaProceso = New CampoFecha("fecha_carga")
                        c_TipoDocumento = New CampoTexto(3, "tipo_documento")
                        c_NumeroDocumento = New CampoTexto(15, "documento")
                        c_FechaVencimiento = New CampoFecha("fecha_vencimiento")
                        c_NotaDetalle = New CampoTexto(50, "detalle")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_MontoAcumulado = New CampoDecimal("acumulado")
                        c_AutoProveedor = New CampoTexto(10, "auto_proveedor")
                        c_NombreProveedor = New CampoTexto(120, "proveedor")
                        c_CiRifProveedor = New CampoTexto(12, "ci_rif")
                        c_CodigoProveedor = New CampoTexto(15, "codigo_proveedor")
                        c_EstatusCancelado = New CampoTexto(1, "cancelado")
                        c_MontoPorPagar = New CampoDecimal("resta")
                        c_TipoOperacion = New CampoTexto(11, "operacion")
                        c_EstatusDocumento = New CampoTexto(1, "estatus")
                        c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        c_Signo = New CampoInteger("signo")

                        'NUEVOS
                        c_AutoMovimientoEntrada = New CampoTexto(10, "auto_mov_entrada")
                        c_FechaRecepcionDevolucion = New CampoFecha("fecha_recepcion_devolucion")
                        c_FechaProceso = New CampoFecha("fecha_carga")
                        c_Numero = New CampoTexto(10, "numero")
                        c_AutoAgencia = New CampoTexto(10, "auto_agencia")
                        c_NombreAgencia = New CampoTexto(40, "agencia")
                        c_NumeroCuenta = New CampoTexto(25, "numero_cuenta")
                        c_TipoCuenta = New CampoTexto(25, "tipo_cuenta")
                        c_NombreTitular = New CampoTexto(50, "titular")

                        LimpiarRegistro()
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoProveedor.c_Texto = xrow(.c_AutoProveedor.c_NombreInterno)
                                .c_AutoCxP.c_Texto = xrow(.c_AutoCxP.c_NombreInterno)
                                .c_AutoDocumento.c_Texto = xrow(.c_AutoDocumento.c_NombreInterno)
                                .c_CiRifProveedor.c_Texto = xrow(.c_CiRifProveedor.c_NombreInterno)
                                .c_CodigoProveedor.c_Texto = xrow(.c_CodigoProveedor.c_NombreInterno)
                                .c_EstatusCancelado.c_Texto = xrow(.c_EstatusCancelado.c_NombreInterno)
                                .c_EstatusDocumento.c_Texto = xrow(.c_EstatusDocumento.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_FechaVencimiento.c_Valor = xrow(.c_FechaVencimiento.c_NombreInterno)
                                .c_MontoAcumulado.c_Valor = xrow(.c_MontoAcumulado.c_NombreInterno)
                                .c_MontoImporte.c_Valor = xrow(.c_MontoImporte.c_NombreInterno)
                                .c_MontoPorPagar.c_Valor = xrow(.c_MontoPorPagar.c_NombreInterno)
                                .c_NombreProveedor.c_Texto = xrow(.c_NombreProveedor.c_NombreInterno)
                                .c_NotaDetalle.c_Texto = xrow(.c_NotaDetalle.c_NombreInterno)
                                .c_NumeroDocumento.c_Texto = xrow(.c_NumeroDocumento.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_Signo.c_Valor = xrow(.c_Signo.c_NombreInterno)
                                .c_TipoOperacion.c_Texto = xrow(.c_TipoOperacion.c_NombreInterno)

                                'NUEVOS
                                If Not IsDBNull(xrow(.c_AutoMovimientoEntrada.c_NombreInterno)) Then
                                    .c_AutoMovimientoEntrada.c_Texto = xrow(.c_AutoMovimientoEntrada.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                                If Not IsDBNull(xrow(.c_FechaRecepcionDevolucion.c_NombreInterno)) Then
                                    .c_FechaRecepcionDevolucion.c_Valor = xrow(.c_FechaRecepcionDevolucion.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_FechaProceso.c_NombreInterno)) Then
                                    .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Numero.c_NombreInterno)) Then
                                    .c_Numero.c_Texto = xrow(.c_Numero.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoAgencia.c_NombreInterno)) Then
                                    .c_AutoAgencia.c_Texto = xrow(.c_AutoAgencia.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NombreAgencia.c_NombreInterno)) Then
                                    .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NumeroCuenta.c_NombreInterno)) Then
                                    .c_NumeroCuenta.c_Texto = xrow(.c_NumeroCuenta.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_TipoCuenta.c_NombreInterno)) Then
                                    .c_TipoCuenta.c_Texto = xrow(.c_TipoCuenta.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NombreTitular.c_NombreInterno)) Then
                                    .c_NombreTitular.c_Texto = xrow(.c_NombreTitular.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXP" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    Function F_FechaVencimiento(ByVal xdias As Integer) As Date
                        Return DateAdd(DateInterval.Day, xdias, Me._FechaEmision)
                    End Function

                    Function F_MontoAcumulado() As Decimal
                        Return ((Me._MontoImporte - Me._MontoPorPagar) * Me._Signo)
                    End Function
                End Class

                Class c_AgregarDocumentoCxP
                    Private xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Private ximporte As Decimal
                    Private xsaldo As Decimal
                    Private xnotas As String
                    Private xdocumento As String
                    Private xfechaemision As Date
                    Private xfechaproceso As Date
                    Private xdiascredito As Integer
                    Private xtipodocumento As TipoDocumentoMovEntradaCxP

                    Sub New()
                        Me._FichaProveedor = New FichaProveedores.c_Proveedor.c_Registro
                        Me._SaldoPendiente = 0
                        Me._FechaEmision = Date.MinValue
                        Me._FechaProceso = Date.MinValue
                        Me._Importe = 0
                        Me._NotasDetalle = ""
                        Me._NumeroDocumento = ""
                        Me._DiasCredito = 0
                    End Sub

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus Del Documento (0 - > Activo)
                    ''' </summary>
                    ReadOnly Property _EstatusDocumento() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus De Cancelacion Del Documento (0 - > No Se Ha Cancelado)
                    ''' </summary>
                    ReadOnly Property _EstatusCancelado() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Protected Friend Get
                            Return Me.xfichaproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            Me.xfichaproveedor = value
                        End Set
                    End Property

                    Property _SaldoPendiente() As Decimal
                        Protected Friend Get
                            Return xsaldo
                        End Get
                        Set(ByVal value As Decimal)
                            xsaldo = value
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

                    Property _NumeroDocumento() As String
                        Protected Friend Get
                            Return xdocumento
                        End Get
                        Set(ByVal value As String)
                            xdocumento = value
                        End Set
                    End Property

                    Property _FechaEmision() As Date
                        Protected Friend Get
                            Return xfechaemision
                        End Get
                        Set(ByVal value As Date)
                            xfechaemision = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Protected Friend Get
                            Return xfechaproceso
                        End Get
                        Set(ByVal value As Date)
                            xfechaproceso = value
                        End Set
                    End Property

                    Property _TipoDocumentoProcesar() As TipoDocumentoMovEntradaCxP
                        Get
                            Return Me.xtipodocumento
                        End Get
                        Set(ByVal value As TipoDocumentoMovEntradaCxP)
                            Me.xtipodocumento = value
                        End Set
                    End Property

                    Property _DiasCredito() As Integer
                        Get
                            Return Me.xdiascredito
                        End Get
                        Set(ByVal value As Integer)
                            Me.xdiascredito = value
                        End Set
                    End Property
                End Class

                Class c_AgregarNotaDebito
                    Private xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Private xmonto As Decimal
                    Private xnotas As String
                    Private xfechaproceso As Date
                    Private xaplica As String

                    Sub New()
                        Me._FichaProveedor = New FichaProveedores.c_Proveedor.c_Registro
                        Me._FechaProceso = Date.MinValue
                        Me._Monto = 0
                        Me._NotasDetalle = ""
                        Me._NumeroDocumentoAplica = ""
                    End Sub

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus Del Documento (0 - > Activo)
                    ''' </summary>
                    ReadOnly Property _EstatusDocumento() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus De Cancelacion Del Documento (0 - > No Se Ha Cancelado)
                    ''' </summary>
                    ReadOnly Property _EstatusCancelado() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad Que Retorna El Tipo De Entrada Del Documento (0 -> Generada Por El Sistema)
                    ''' </summary>
                    ReadOnly Property _TipoEntrada() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Protected Friend Get
                            Return Me.xfichaproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            Me.xfichaproveedor = value
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

                    Property _Monto() As Decimal
                        Protected Friend Get
                            Return xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Protected Friend Get
                            Return xfechaproceso
                        End Get
                        Set(ByVal value As Date)
                            xfechaproceso = value
                        End Set
                    End Property

                    Property _NumeroDocumentoAplica() As String
                        Protected Friend Get
                            Return xaplica
                        End Get
                        Set(ByVal value As String)
                            xaplica = value
                        End Set
                    End Property
                End Class

                Class c_AgregarChequeDevuelto
                    Private xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Private xfichabanco As FichaBancos.c_Bancos.c_Registro
                    Private xcomision As Decimal
                    Private xmonto As Decimal
                    Private xnotas As String
                    Private xnumerocheque As String
                    Private xfechaemision As Date
                    Private xfechaproceso As Date
                    Private xfechadevolucion As Date

                    Sub New()
                        Me._FichaProveedor = New FichaProveedores.c_Proveedor.c_Registro
                        Me._FichaBanco = New FichaBancos.c_Bancos.c_Registro
                        Me._ComisionCheque = 0
                        Me._FechaDevolucion = Date.MinValue
                        Me._FechaEmision = Date.MinValue
                        Me._FechaProceso = Date.MinValue
                        Me._MontoCheque = 0
                        Me._NotasDetalle = ""
                        Me._NumeroCheque = ""
                    End Sub

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus Del Documento (0 - > Activo)
                    ''' </summary>
                    ReadOnly Property _EstatusDocumento() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus De Cancelacion Del Documento (0 - > No Se Ha Cancelado)
                    ''' </summary>
                    ReadOnly Property _EstatusCancelado() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad Que Retorna El Tipo De Entrada Del Documento (0 -> Generada Por El Sistema)
                    ''' </summary>
                    ReadOnly Property _TipoEntrada() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Protected Friend Get
                            Return Me.xfichaproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            Me.xfichaproveedor = value
                        End Set
                    End Property

                    Property _FichaBanco() As FichaBancos.c_Bancos.c_Registro
                        Get
                            Return Me.xfichabanco
                        End Get
                        Set(ByVal value As FichaBancos.c_Bancos.c_Registro)
                            Me.xfichabanco = value
                        End Set
                    End Property

                    Property _ComisionCheque() As Decimal
                        Protected Friend Get
                            Return xcomision
                        End Get
                        Set(ByVal value As Decimal)
                            xcomision = value
                        End Set
                    End Property

                    Property _MontoCheque() As Decimal
                        Protected Friend Get
                            Return xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto = value
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

                    Property _NumeroCheque() As String
                        Protected Friend Get
                            Return xnumerocheque
                        End Get
                        Set(ByVal value As String)
                            xnumerocheque = value
                        End Set
                    End Property

                    Property _FechaEmision() As Date
                        Protected Friend Get
                            Return xfechaemision
                        End Get
                        Set(ByVal value As Date)
                            xfechaemision = value
                        End Set
                    End Property

                    Property _FechaDevolucion() As Date
                        Protected Friend Get
                            Return xfechadevolucion
                        End Get
                        Set(ByVal value As Date)
                            xfechadevolucion = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Protected Friend Get
                            Return xfechaproceso
                        End Get
                        Set(ByVal value As Date)
                            xfechaproceso = value
                        End Set
                    End Property
                End Class

                Class c_AgregarPagos
                    Class Doc
                        Private xauto As String
                        Private xid As Byte()

                        Property _AutoDocumento() As String
                            Protected Friend Get
                                Return xauto
                            End Get
                            Set(ByVal value As String)
                                xauto = value
                            End Set
                        End Property

                        Property _IdDocumento() As Byte()
                            Protected Friend Get
                                Return xid
                            End Get
                            Set(ByVal value As Byte())
                                xid = value
                            End Set
                        End Property

                        Sub New()
                            Me._AutoDocumento = ""
                        End Sub
                    End Class

                    Private xlista_DocumentosPagar As List(Of Doc)
                    Private xfichaproveedor As FichaProveedores.c_Proveedor.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xfechaproceso As Date
                    Private xnotas As String
                    Private xmonto As Decimal
                    Private xfechaemision As Date
                    Private xlista_pagos_documentos_nc As List(Of Doc)

                    ''' <summary>
                    ''' Propiedad Que Retorna el Estatus Del Documento (0 - > Activo)
                    ''' </summary>
                    ReadOnly Property _EstatusDocumento() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    ReadOnly Property _TipoPago() As String
                        Get
                            Return "2"
                        End Get
                    End Property

                    Property _ListaDocumentosNC_ModoPago() As List(Of Doc)
                        Protected Friend Get
                            Return Me.xlista_pagos_documentos_nc
                        End Get
                        Set(ByVal value As List(Of Doc))
                            Me.xlista_pagos_documentos_nc = value
                        End Set
                    End Property

                    Property _ListaDocumentosPagar() As List(Of Doc)
                        Protected Friend Get
                            Return Me.xlista_DocumentosPagar
                        End Get
                        Set(ByVal value As List(Of Doc))
                            Me.xlista_DocumentosPagar = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return Me.xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xfichausuario = value
                        End Set
                    End Property

                    Property _FichaProveedor() As FichaProveedores.c_Proveedor.c_Registro
                        Protected Friend Get
                            Return Me.xfichaproveedor
                        End Get
                        Set(ByVal value As FichaProveedores.c_Proveedor.c_Registro)
                            Me.xfichaproveedor = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Get
                            Return xfechaproceso
                        End Get
                        Set(ByVal value As Date)
                            xfechaproceso = value
                        End Set
                    End Property

                    Property _FechaEmision() As Date
                        Get
                            Return xfechaemision
                        End Get
                        Set(ByVal value As Date)
                            xfechaemision = value
                        End Set
                    End Property

                    Property _MontoImporte() As Decimal
                        Get
                            Return xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto = value
                        End Set
                    End Property

                    Property _NotasDetalle() As String
                        Get
                            Return xnotas
                        End Get
                        Set(ByVal value As String)
                            xnotas = value
                        End Set
                    End Property

                    Sub New()
                        Me._FechaProceso = Date.MinValue
                        Me._FechaEmision = Date.MinValue
                        Me._ListaDocumentosPagar = New List(Of Doc)
                        Me._ListaDocumentosNC_ModoPago = New List(Of Doc)
                        Me._FichaProveedor = New FichaProveedores.c_Proveedor.c_Registro
                        Me._FichaUsuario = New FichaGlobal.c_Usuario.c_Registro
                        Me._MontoImporte = 0
                        Me._NotasDetalle = ""
                    End Sub
                End Class

                Class c_AnularDocumentoCxP
                    Private xfichaCxP As FichaCtasPagar.c_CxP.c_Registro
                    Private xDocumentoAnular As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                    Private xlistdocumentos As List(Of c_Documentos.c_Registro)
                    Private xautorecibo As String

                    ''' <summary>
                    ''' Propiedad Que Retorna el Codigo De Anulacion (0501 -> Anulado Por Adm CxP)
                    ''' </summary>
                    ReadOnly Property _CodigoAnulacion() As String
                        Get
                            Return "0501"
                        End Get
                    End Property

                    Property _FichaRegistroCxp() As FichaCtasPagar.c_CxP.c_Registro
                        Get
                            Return Me.xfichaCxP
                        End Get
                        Set(ByVal value As FichaCtasPagar.c_CxP.c_Registro)
                            Me.xfichaCxP = value
                        End Set
                    End Property

                    Property _DocumentoAnular() As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Get
                            Return Me.xDocumentoAnular
                        End Get
                        Set(ByVal value As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro)
                            Me.xDocumentoAnular = value
                        End Set
                    End Property

                    Property _AutoReciboCxp() As String
                        Get
                            Return Me.xautorecibo
                        End Get
                        Set(ByVal value As String)
                            Me.xautorecibo = value
                        End Set
                    End Property

                    Property _ListaDocumentos() As List(Of c_Documentos.c_Registro)
                        Get
                            Return Me.xlistdocumentos
                        End Get
                        Set(ByVal value As List(Of c_Documentos.c_Registro))
                            Me.xlistdocumentos = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoReciboCxp = ""
                        Me._FichaRegistroCxp = New FichaCtasPagar.c_CxP.c_Registro
                        Me._DocumentoAnular = New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Me._ListaDocumentos = New List(Of c_Documentos.c_Registro)
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

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from cxp where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarFicha(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("CXP" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Public Class c_Documentos
                Public Class c_Registro
                    Private f_item As New CampoInteger
                    Private f_operacion As CampoTexto
                    Private f_monto As CampoDecimal
                    Private f_auto_cxp As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_auto_cxp_pago As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_detalle As CampoTexto
                    Private f_auto_cxp_recibo As CampoTexto
                    Private f_numero_recibo As CampoTexto
                    Private f_origen As CampoTexto

                    Protected Friend Property c_Item() As CampoInteger
                        Get
                            Return f_item
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_item = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoOperacion() As CampoTexto
                        Get
                            Return f_operacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_operacion = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoDocumento() As CampoDecimal
                        Get
                            Return f_monto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto = value
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

                    Protected Friend Property c_NumeroDocumento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoPago() As CampoTexto
                        Get
                            Return f_auto_cxp_pago
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxp_pago = value
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

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Protected Friend Property c_NotaDetalle() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto_cxp_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxp_recibo = value
                        End Set
                    End Property
                    Protected Friend Property c_NumeroRecibo() As CampoTexto
                        Get
                            Return f_numero_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero_recibo = value
                        End Set
                    End Property
                    Protected Friend Property c_OrigenDocumento() As CampoTexto
                        Get
                            Return f_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_origen = value
                        End Set
                    End Property

                    ReadOnly Property _Item() As Integer
                        Get
                            Return c_Item.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoOperacion() As String
                        Get
                            Return c_TipoOperacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoDocumento() As Decimal
                        Get
                            Return c_MontoDocumento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoCxP() As String
                        Get
                            Return c_AutoCxP.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumento() As String
                        Get
                            Return c_NumeroDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPago() As String
                        Get
                            Return c_AutoPago.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As String
                        Get
                            Return c_TipoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _NotaDetalleCuentasPorPagar() As String
                        Get
                            Return c_NotaDetalle.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroRecibo() As String
                        Get
                            Return c_NumeroRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _OrigenDocumento() As String
                        Get
                            Return c_OrigenDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        c_Item = New CampoInteger("item")
                        c_TipoOperacion = New CampoTexto(11, "operacion")
                        c_MontoDocumento = New CampoDecimal("monto")
                        c_AutoCxP = New CampoTexto(10, "auto_cxp")
                        c_NumeroDocumento = New CampoTexto(15, "documento")
                        c_AutoPago = New CampoTexto(10, "auto_cxp_pago")
                        c_TipoDocumento = New CampoTexto(3, "tipo")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_NotaDetalle = New CampoTexto(50, "detalle")
                        c_AutoRecibo = New CampoTexto(10, "auto_cxp_recibo")
                        c_NumeroRecibo = New CampoTexto(10, "numero_recibo")
                        c_OrigenDocumento = New CampoTexto(20, "origen")
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
                    Me.RegistroDato = New C_Registro
                End Sub
            End Class

            Public Class c_ModoPago
                Public Class c_Registro
                    Private f_auto_recibo As CampoTexto
                    Private f_auto_movimientos As CampoTexto
                    Private f_numero As CampoTexto
                    Private f_banco As CampoTexto
                    Private f_importe As CampoDecimal
                    Private f_nombre As CampoTexto

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_recibo = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoMovimiento() As CampoTexto
                        Get
                            Return f_auto_movimientos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_movimientos = value
                        End Set
                    End Property

                    Protected Friend Property c_Numero() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreBanco() As CampoTexto
                        Get
                            Return f_banco
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_banco = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoImporte() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreModoPago() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMovimiento() As String
                        Get
                            Return c_AutoMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Numero() As String
                        Get
                            Return c_Numero.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreBanco() As String
                        Get
                            Return c_NombreBanco.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoImporte() As Decimal
                        Get
                            Return c_MontoImporte.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NombreModoPago() As String
                        Get
                            Return c_NombreModoPago.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        c_AutoRecibo = New CampoTexto(10, "auto_recibo")
                        c_AutoRecibo = New CampoTexto(10, "auto_movimientos")
                        c_Numero = New CampoTexto(15, "numero")
                        c_NombreBanco = New CampoTexto(50, "Banco")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_NombreModoPago = New CampoTexto(20, "nombre")
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
                    Me.RegistroDato = New C_Registro
                End Sub
            End Class

            Public Class c_Recibo
                Public Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_numero As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_auto_usuario As CampoTexto
                    Private f_importe As CampoDecimal
                    Private f_usuario As CampoTexto
                    Private f_importe_documentos As CampoDecimal
                    Private f_total_documentos As CampoDecimal
                    Private f_detalle As CampoTexto
                    Private f_auto_proveedor As CampoTexto
                    Private f_nombre_proveedor As CampoTexto
                    Private f_ci_rif_proveedor As CampoTexto
                    Private f_codigo_proveedor As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_cant_doc_rel As CampoInteger
                    Private f_tipo_pago As CampoTexto

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property
                    Protected Friend Property c_NumeroRecibo() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
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
                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_auto_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_usuario = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoImporte() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
                        End Set
                    End Property
                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoImporteDocumento() As CampoDecimal
                        Get
                            Return f_importe_documentos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe_documentos = value
                        End Set
                    End Property
                    Protected Friend Property c_MontoTotalDocumento() As CampoDecimal
                        Get
                            Return f_total_documentos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total_documentos = value
                        End Set
                    End Property
                    Protected Friend Property c_NotaDetalleRecibo() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property
                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_auto_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_proveedor = value
                        End Set
                    End Property
                    Protected Friend Property c_NombreProveedor() As CampoTexto
                        Get
                            Return f_nombre_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_proveedor = value
                        End Set
                    End Property
                    Protected Friend Property c_CiRifProveedor() As CampoTexto
                        Get
                            Return f_ci_rif_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif_proveedor = value
                        End Set
                    End Property
                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigo_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_proveedor = value
                        End Set
                    End Property
                    Protected Friend Property c_EstatusRecibo() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property
                    Protected Friend Property c_TipoPago() As CampoTexto
                        Get
                            Return f_tipo_pago
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_pago = value
                        End Set
                    End Property
                    Protected Friend Property c_CantidadDocumentosRelacionados() As CampoInteger
                        Get
                            Return f_cant_doc_rel
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_cant_doc_rel = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadDocumentosRelacionados() As Integer
                        Get
                            Return Me.c_CantidadDocumentosRelacionados.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _OrigenPago() As TipoPago
                        Get
                            Select Case Me.c_TipoPago.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoPago.Cheque
                                Case "1" : Return TipoPago.Transferencia
                                Case "2" : Return TipoPago.NotaCredito
                                Case "3" : Return TipoPago.Retencion
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NumeroRecibo() As String
                        Get
                            Return c_NumeroRecibo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property
                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _MontoImporte() As Decimal
                        Get
                            Return c_MontoImporte.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _MontoImporteDocumento() As Decimal
                        Get
                            Return c_MontoImporteDocumento.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _MontoTotalDocumento() As Decimal
                        Get
                            Return c_MontoTotalDocumento.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _NotaDetalleRecibo() As String
                        Get
                            Return c_NotaDetalleRecibo.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreProveedor() As String
                        Get
                            Return c_NombreProveedor.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CiRifProveedor() As String
                        Get
                            Return c_CiRifProveedor.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return c_CodigoProveedor.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _EstatusRecibo() As TipoEstatus
                        Get
                            Select Case Me.c_EstatusRecibo.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Inactivo
                                Case "1" : Return TipoEstatus.Activo
                            End Select
                        End Get
                    End Property

                    Sub New()
                        c_AutoRecibo = New CampoTexto(10, "auto")
                        c_NumeroRecibo = New CampoTexto(10, "numero")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_AutoUsuario = New CampoTexto(10, "auto_usuario")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_NombreUsuario = New CampoTexto(50, "usuario")
                        c_MontoImporteDocumento = New CampoDecimal("importe_documento")
                        c_MontoTotalDocumento = New CampoDecimal("total_documento")
                        c_NotaDetalleRecibo = New CampoTexto(50, "detalle")
                        c_AutoProveedor = New CampoTexto(10, "auto_Proveedor")
                        c_NombreProveedor = New CampoTexto(120, "nombre_Proveedor")
                        c_CiRifProveedor = New CampoTexto(12, "ci_rif_Proveedor")
                        c_CodigoProveedor = New CampoTexto(15, "codigo_Proveedor")
                        c_EstatusRecibo = New CampoTexto(1, "estatus")
                        c_CantidadDocumentosRelacionados = New CampoInteger("cant_doc_rel")
                        c_TipoPago = New CampoTexto(1, "tipo_pago")
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property RegistroDato() As C_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As C_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.RegistroDato = New C_Registro
                End Sub
            End Class

            Class c_MovimientosEntrada
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_cxp As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_fecha_carga As CampoFecha
                    Private f_fecha_vencimiento As CampoFecha
                    Private f_nombre As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_tipo_documento As CampoTexto
                    Private f_nota As CampoTexto
                    Private f_auto_proveedor As CampoTexto
                    Private f_codigo_proveedor As CampoTexto
                    Private f_dias_credito As CampoInteger
                    Private f_estatus As CampoTexto
                    Private f_aplica As CampoTexto
                    Private f_total As CampoDecimal
                    Private f_tipo_entrada As CampoTexto
                    Private f_autoagencia As CampoTexto
                    Private f_nombreagencia As CampoTexto
                    Private f_numeroplanilla As CampoTexto
                    Private f_fechadevolucion As CampoFecha

                    'NUEVOS
                    Private f_numero_cuenta As CampoTexto
                    Private f_tipo_cuenta As CampoTexto
                    Private f_titular As CampoTexto

                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Return Me.c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoCxP() As CampoTexto
                        Get
                            Return f_auto_cxp
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxp = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCxP() As String
                        Get
                            Return Me.c_AutoCxP.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' AUTOMATICO DEL TIPO DE MOVIMIENTO EN TABLA CONTADORES
                    ''' </summary>
                    Protected Friend Property c_Documento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' AUTOMATICO DEL TIPO DE MOVIMIENTO EN TABLA CONTADORES
                    ''' </summary>
                    ReadOnly Property _Documento() As String
                        Get
                            Return Me.c_Documento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_FechaProceso() As CampoFecha
                        Get
                            Return f_fecha_carga
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_carga = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FechaProceso.c_Valor
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

                    Protected Friend Property c_NombreProveedor() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreProveedor() As String
                        Get
                            Return Me.c_NombreProveedor.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CiRifProveedor() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    ReadOnly Property _CiRifProveedor() As String
                        Get
                            Return Me.c_CiRifProveedor.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_TipoDocumento() As CampoTexto
                        Get
                            Return f_tipo_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_documento = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoMovEntradaCxP
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim.ToUpper
                                Case "FAC" : Return TipoDocumentoMovEntradaCxP.Factura
                                Case "ND", "NDF" : Return TipoDocumentoMovEntradaCxP.NotaDebito
                                Case "NC", "NCF" : Return TipoDocumentoMovEntradaCxP.NotaCredito
                                Case "CHD" : Return TipoDocumentoMovEntradaCxP.ChequeDevuelto
                            End Select
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

                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_auto_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_proveedor = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return Me.c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigo_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_proveedor = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return Me.c_CodigoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_DiasCreditoProveedor() As CampoInteger
                        Get
                            Return f_dias_credito
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_credito = value
                        End Set
                    End Property

                    ReadOnly Property _DiasCreditoOtorgado() As Integer
                        Get
                            Return Me.c_DiasCreditoProveedor.c_Valor
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
                            If Me.c_EstatusDocumento.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
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

                    Protected Friend Property c_TipoEntrada() As CampoTexto
                        Get
                            Return f_tipo_entrada
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _TipoEntrada() As TipoEntradaMovEntradaCxP
                        Get
                            Select Case Me.c_TipoEntrada.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEntradaMovEntradaCxP.PropiaDelSistema
                                Case "1" : Return TipoEntradaMovEntradaCxP.EntradaExterna
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_AutoAgencia() As CampoTexto
                        Get
                            Return f_autoagencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoagencia = value
                        End Set
                    End Property

                    ReadOnly Property _AutoAgencia() As String
                        Get
                            Return Me.c_AutoAgencia.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreAgencia() As CampoTexto
                        Get
                            Return f_nombreagencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreagencia = value
                        End Set
                    End Property

                    ReadOnly Property _NombreAgencia() As String
                        Get
                            Return Me.c_NombreAgencia.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NumeroPlanilla() As CampoTexto
                        Get
                            Return f_numeroplanilla
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numeroplanilla = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroPlanilla() As String
                        Get
                            Return Me.c_NumeroPlanilla.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaDevolucion() As CampoFecha
                        Get
                            Return f_fechadevolucion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechadevolucion = value
                        End Set
                    End Property

                    ReadOnly Property _FechaDevolucion() As Date
                        Get
                            Return Me.c_FechaDevolucion.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_NumeroCuenta() As CampoTexto
                        Get
                            Return f_numero_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero_cuenta = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoCuenta() As CampoTexto
                        Get
                            Return f_tipo_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_cuenta = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreTitular() As CampoTexto
                        Get
                            Return f_titular
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_titular = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroCuenta() As String
                        Get
                            Return c_NumeroCuenta.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoCuenta() As TipoCuentaBancaria
                        Get
                            Select Case c_TipoCuenta.c_Texto.Trim
                                Case "Ahorro" : Return TipoCuentaBancaria.Ahorro
                                Case "Corriente" : Return TipoCuentaBancaria.Corriente
                                Case "Fal" : Return TipoCuentaBancaria.Fal
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _NombreTitular() As String
                        Get
                            Return c_NombreTitular.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        f_auto = New CampoTexto(10, "auto")
                        f_auto_cxp = New CampoTexto(10, "auto_cxp")
                        f_tipo_documento = New CampoTexto(10, "tipo_documento")
                        f_documento = New CampoTexto(10, "documento")
                        f_fecha = New CampoFecha("fecha")
                        f_fecha_carga = New CampoFecha("fecha_carga")
                        f_fecha_vencimiento = New CampoFecha("fecha_vencimiento")
                        f_nombre = New CampoTexto(120, "nombre")
                        f_ci_rif = New CampoTexto(12, "ci_rif")
                        f_total = New CampoDecimal("total")
                        f_nota = New CampoTexto(120, "nota")
                        f_auto_proveedor = New CampoTexto(10, "auto_proveedor")
                        f_codigo_proveedor = New CampoTexto(15, "codigo_proveedor")
                        f_dias_credito = New CampoInteger("dias_credito")
                        f_estatus = New CampoTexto(1, "estatus")
                        f_aplica = New CampoTexto(10, "aplica")
                        f_tipo_entrada = New CampoTexto(1, "tipo_entrada")
                        f_autoagencia = New CampoTexto(10, "autoagencia")
                        f_nombreagencia = New CampoTexto(40, "nombreagencia")
                        f_numeroplanilla = New CampoTexto(10, "numeroplanilla")
                        f_fechadevolucion = New CampoFecha("fechadevolucion")

                        'NUEVOS
                        c_NumeroCuenta = New CampoTexto(25, "numero_cuenta")
                        c_TipoCuenta = New CampoTexto(25, "tipo_cuenta")
                        c_NombreTitular = New CampoTexto(50, "titular")

                        LimpiarRegistro()
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()

                            With Me
                                .c_Auto.c_Texto = xrow(c_Auto.c_NombreInterno)
                                .c_AutoCxP.c_Texto = xrow(c_AutoCxP.c_NombreInterno)
                                .c_Documento.c_Texto = xrow(.c_Documento.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_FechaVencimiento.c_Valor = xrow(.c_FechaVencimiento.c_NombreInterno)
                                .c_NombreProveedor.c_Texto = xrow(.c_NombreProveedor.c_NombreInterno)
                                .c_CiRifProveedor.c_Texto = xrow(.c_CiRifProveedor.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TotalGeneral.c_Valor = xrow(.c_TotalGeneral.c_NombreInterno)
                                .c_NotasDocumento.c_Texto = xrow(.c_NotasDocumento.c_NombreInterno)
                                .c_AutoProveedor.c_Texto = xrow(.c_AutoProveedor.c_NombreInterno)
                                .c_CodigoProveedor.c_Texto = xrow(.c_CodigoProveedor.c_NombreInterno)
                                .c_DiasCreditoProveedor.c_Valor = xrow(.c_DiasCreditoProveedor.c_NombreInterno)
                                .c_EstatusDocumento.c_Texto = xrow(.c_EstatusDocumento.c_NombreInterno)
                                .c_DocumentoAplica.c_Texto = xrow(.c_DocumentoAplica.c_NombreInterno)
                                .c_TipoEntrada.c_Texto = xrow(.c_TipoEntrada.c_NombreInterno)
                                .c_AutoAgencia.c_Texto = xrow(.c_AutoAgencia.c_NombreInterno)
                                .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)
                                .c_NumeroPlanilla.c_Texto = xrow(.c_NumeroPlanilla.c_NombreInterno)
                                .c_FechaDevolucion.c_Valor = xrow(.c_FechaDevolucion.c_NombreInterno)

                                If Not IsDBNull(xrow(.c_NumeroCuenta.c_NombreInterno)) Then
                                    .c_NumeroCuenta.c_Texto = xrow(.c_NumeroCuenta.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_TipoCuenta.c_NombreInterno)) Then
                                    .c_TipoCuenta.c_Texto = xrow(.c_TipoCuenta.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NombreTitular.c_NombreInterno)) Then
                                    .c_NombreTitular.c_Texto = xrow(.c_NombreTitular.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXP MOVIMIENTO DE ENTRADA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Sub M_CargarRegistro(ByVal xauto As String)
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from cxp_movimientos_entrada where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto).Size = Me.RegistroDato.c_Auto.c_Largo
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count = 0 Then
                            Throw New Exception("MOVIMIENTO DE ENTRADA EN CXP NO ENCONTRADO")
                        End If
                        Me.RegistroDato.CargarRegistro(xtb(0))
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Private xcxp As c_CxP
            Private xrecibo As c_Recibo
            Private xdocumento As c_Documentos
            Private xmodopago As c_ModoPago
            Private xmovimientosentrada As c_MovimientosEntrada

            Property F_CuentaPagar() As c_CxP
                Get
                    Return xcxp
                End Get
                Set(ByVal value As c_CxP)
                    xcxp = value
                End Set
            End Property

            Property F_Recibos() As c_Recibo
                Get
                    Return xrecibo
                End Get
                Set(ByVal value As c_Recibo)
                    xrecibo = value
                End Set
            End Property

            Property F_Documentos() As c_Documentos
                Get
                    Return xdocumento
                End Get
                Set(ByVal value As c_Documentos)
                    xdocumento = value
                End Set
            End Property

            Property F_ModoPago() As c_ModoPago
                Get
                    Return xmodopago
                End Get
                Set(ByVal value As c_ModoPago)
                    xmodopago = value
                End Set
            End Property

            Property F_MovimientosEntrada() As c_MovimientosEntrada
                Get
                    Return Me.xmovimientosentrada
                End Get
                Set(ByVal value As c_MovimientosEntrada)
                    Me.xmovimientosentrada = value
                End Set
            End Property

            Sub New()
                Me.F_CuentaPagar = New c_CxP
                Me.F_Documentos = New c_Documentos
                Me.F_ModoPago = New c_ModoPago
                Me.F_Recibos = New c_Recibo
                Me.F_MovimientosEntrada = New c_MovimientosEntrada
            End Sub

#Region "FUNCIONES INSERT"
            Protected Friend Const INSERT_CXP As String = "INSERT INTO cxp (" _
                + " auto" _
                + ",fecha" _
                + ",fecha_carga" _
                + ",tipo_documento" _
                + ",documento" _
                + ",fecha_vencimiento" _
                + ",detalle" _
                + ",importe" _
                + ",acumulado" _
                + ",auto_proveedor" _
                + ",proveedor" _
                + ",ci_rif" _
                + ",codigo_proveedor" _
                + ",cancelado" _
                + ",resta" _
                + ",operacion" _
                + ",estatus" _
                + ",auto_documento" _
                + ",signo" _
                + ",auto_mov_entrada" _
                + ",fecha_recepcion_devolucion" _
                + ",numero" _
                + ",auto_agencia" _
                + ",agencia" _
                + ",numero_cuenta" _
                + ",tipo_cuenta" _
                + ",titular) " _
                + "VALUES (" _
                + " @auto" _
                + ",@fecha" _
                + ",@fecha_carga" _
                + ",@tipo_documento" _
                + ",@documento" _
                + ",@fecha_vencimiento" _
                + ",@detalle" _
                + ",@importe" _
                + ",@acumulado" _
                + ",@auto_proveedor" _
                + ",@proveedor" _
                + ",@ci_rif" _
                + ",@codigo_proveedor" _
                + ",@cancelado" _
                + ",@resta" _
                + ",@operacion" _
                + ",@estatus" _
                + ",@auto_documento" _
                + ",@signo" _
                + ",@auto_mov_entrada" _
                + ",@fecha_recepcion_devolucion" _
                + ",@numero" _
                + ",@auto_agencia" _
                + ",@agencia" _
                + ",@numero_cuenta" _
                + ",@tipo_cuenta" _
                + ",@titular) "

            Protected Friend Const _INSERT_CXP_RECIBOS As String = "INSERT INTO cxp_recibos (" _
               + "auto," _
               + "numero," _
               + "fecha," _
               + "auto_usuario," _
               + "importe," _
               + "usuario," _
               + "importe_documentos," _
               + "total_documentos," _
               + "detalle," _
               + "auto_proveedor," _
               + "nombre_proveedor," _
               + "ci_rif_proveedor," _
               + "codigo_proveedor," _
               + "estatus," _
               + "cant_doc_rel," _
               + "tipo_pago," _
               + "monto_recibido," _
               + "monto_cambio," _
               + "dirFiscal_proveedor," _
               + "telefono_proveedor," _
               + "nota, " _
               + "auto_cxp ) " _
               + "VALUES (" _
               + "@auto," _
               + "@numero," _
               + "@fecha," _
               + "@auto_usuario," _
               + "@importe," _
               + "@usuario," _
               + "@importe_documentos," _
               + "@total_documentos," _
               + "@detalle," _
               + "@auto_proveedor," _
               + "@nombre_proveedor," _
               + "@ci_rif_proveedor," _
               + "@codigo_proveedor," _
               + "@estatus," _
               + "@cant_doc_rel," _
               + "@tipo_pago," _
               + "@monto_recibido," _
               + "@monto_cambio," _
               + "@dirFiscal_proveedor," _
               + "@telefono_proveedor," _
               + "@nota, " _
               + "@auto_cxp ) "

            Protected Friend Const INSERT_CXP_DOCUMENTOS As String = "INSERT INTO cxp_documentos (" _
               + "item," _
               + "operacion," _
               + "monto," _
               + "auto_cxp," _
               + "documento," _
               + "auto_cxp_pago," _
               + "tipo," _
               + "fecha," _
               + "detalle," _
               + "auto_cxp_recibo," _
               + "numero_recibo," _
               + "origen) " _
               + "VALUES (" _
               + "@item," _
               + "@operacion," _
               + "@monto," _
               + "@auto_cxp," _
               + "@documento," _
               + "@auto_cxp_pago," _
               + "@tipo," _
               + "@fecha," _
               + "@detalle," _
               + "@auto_cxp_recibo," _
               + "@numero_recibo," _
               + "@origen) "

            Protected Friend Const INSERT_CXP_MODO_PAGO As String = "INSERT INTO cxp_modo_pago (" _
               + "auto_recibo," _
               + "auto_movimientos) " _
               + "numero," _
               + "banco," _
               + "importe," _
               + "nombre) " _
               + "VALUES (" _
               + "@auto_recibo," _
               + "@auto_movimientos) " _
               + "@numero," _
               + "@banco," _
               + "@importe," _
               + "@nombre) "

            Protected Friend Const INSERT_CXP_MOVIMIENTOS_ENTRADA As String = "insert cxp_movimientos_entrada (" _
               + "auto," _
               + "auto_cxp," _
               + "documento," _
               + "fecha," _
               + "fecha_carga," _
               + "fecha_vencimiento," _
               + "nombre," _
               + "ci_rif," _
               + "tipo_documento," _
               + "total," _
               + "nota," _
               + "auto_proveedor," _
               + "codigo_proveedor," _
               + "dias_credito," _
               + "estatus," _
               + "aplica," _
               + "tipo_entrada," _
               + "autoagencia," _
               + "nombreagencia," _
               + "numeroplanilla," _
               + "fechadevolucion, " _
               + "numero_cuenta," _
               + "tipo_cuenta," _
               + "titular) " _
               + "VALUES (" _
               + "@auto," _
               + "@auto_cxp," _
               + "@documento," _
               + "@fecha," _
               + "@fecha_carga," _
               + "@fecha_vencimiento," _
               + "@nombre," _
               + "@ci_rif," _
               + "@tipo_documento," _
               + "@total," _
               + "@nota," _
               + "@auto_proveedor," _
               + "@codigo_proveedor," _
               + "@dias_credito," _
               + "@estatus," _
               + "@aplica," _
               + "@tipo_entrada," _
               + "@autoagencia," _
               + "@nombreagencia," _
               + "@numeroplanilla," _
               + "@fechadevolucion, " _
               + "@numero_cuenta," _
               + "@tipo_cuenta," _
               + "@titular) "
#End Region

            Function F_GrabarMovimientoEntrada(ByVal xagregar As c_CxP.c_AgregarDocumentoCxP) As Boolean
                Dim xobj As Object = Nothing
                Dim xsql1 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim xsql2 As String = "update contadores set a_cxp_movimientos_entrada=a_cxp_movimientos_entrada+1; select a_cxp_movimientos_entrada from contadores"
                Dim xsql3 As String = ""
                Dim xauto_1 As String = ""
                Dim xauto_2 As String = ""
                Dim xauto_3 As String = ""
                Dim xsigno As Integer = 1
                Dim xtmov As String = ""
                Dim xtipoentrada As String = ""
                Dim xtr As SqlTransaction

                Try
                    Select Case xagregar._TipoDocumentoProcesar
                        Case TipoDocumentoMovEntradaCxP.Factura
                            xsql3 = "update contadores set a_cxp_fc=a_cxp_fc+1; select a_cxp_fc from contadores"
                            xtmov = "FAC"
                            xtipoentrada = "1"
                        Case TipoDocumentoMovEntradaCxP.NotaDebito
                            xsql3 = "update contadores set a_cxp_nd=a_cxp_nd+1; select a_cxp_nd from contadores"
                            xtmov = "NDF"
                            xtipoentrada = "1"
                        Case TipoDocumentoMovEntradaCxP.NotaCredito
                            Throw New Exception("NO SE DEBE SELECCIONAR ESTE TIPO DE NOTA DE CREDITO PARA UN MOVIMIENTO DE ENTRADA")
                        Case TipoDocumentoMovEntradaCxP.NotaCreditoNoGeneradaPorSistema
                            xsql3 = "update contadores set a_cxp_nc=a_cxp_nc+1; select a_cxp_nc from contadores"
                            xsigno = -1
                            xtmov = "NCF"
                            xtipoentrada = "0"
                    End Select

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXP
                                xcmd.CommandText = xsql1
                                xauto_1 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES MOV ENTRADA CXP
                                xcmd.CommandText = "select a_cxp_movimientos_entrada from contadores"
                                xobj = xcmd.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcmd.CommandText = "update contadores set a_cxp_movimientos_entrada=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.CommandText = xsql2
                                xauto_2 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'VERIFICO CONTADORES CXP_FACTURA POR SI ES NULL
                                xcmd.CommandText = "select a_cxp_fc from contadores"
                                xobj = xcmd.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcmd.CommandText = "update contadores set a_cxp_fc=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                'CONTADORES PARA EL TIPO DE MOVIMIENTO A INGRESAR
                                xcmd.CommandText = xsql3
                                xauto_3 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CXP
                                Dim xcxp As New FichaCtasPagar.c_CxP.c_Registro
                                With xcxp
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NumeroCuenta.c_Texto = ""
                                    .c_TipoCuenta.c_Texto = ""
                                    .c_NombreTitular.c_Texto = ""
                                    .c_Numero.c_Texto = ""
                                    .c_AutoCxP.c_Texto = xauto_1
                                    .c_AutoProveedor.c_Texto = xagregar._FichaProveedor._Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto_2
                                    .c_CiRifProveedor.c_Texto = xagregar._FichaProveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xagregar._FichaProveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = xagregar._EstatusCancelado
                                    .c_EstatusDocumento.c_Texto = xagregar._EstatusDocumento
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = Date.MinValue
                                    .c_Signo.c_Valor = xsigno
                                    .c_MontoImporte.c_Valor = xagregar._Importe * xsigno
                                    .c_MontoPorPagar.c_Valor = xagregar._SaldoPendiente * xsigno
                                    .c_FechaVencimiento.c_Valor = .F_FechaVencimiento(xagregar._DiasCredito)
                                    .c_MontoAcumulado.c_Valor = .F_MontoAcumulado
                                    .c_NombreProveedor.c_Texto = xagregar._FichaProveedor._NombreRazonSocial
                                    .c_NotaDetalle.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroDocumento.c_Texto = xauto_3
                                    .c_TipoDocumento.c_Texto = xtmov
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_CXP
                                xcmd.Parameters.AddWithValue("@auto", xcxp.c_AutoCxP.c_Texto).Size = xcxp.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xcxp.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_carga", xcxp.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xcxp.c_TipoDocumento.c_Texto).Size = xcxp.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xcxp.c_NumeroDocumento.c_Texto).Size = xcxp.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxp.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xcxp.c_NotaDetalle.c_Texto).Size = xcxp.c_NotaDetalle.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xcxp.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xcxp.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcxp.c_AutoProveedor.c_Texto).Size = xcxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@proveedor", xcxp.c_NombreProveedor.c_Texto).Size = xcxp.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xcxp.c_CiRifProveedor.c_Texto).Size = xcxp.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xcxp.c_CodigoProveedor.c_Texto).Size = xcxp.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xcxp.c_EstatusCancelado.c_Texto).Size = xcxp.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xcxp.c_MontoPorPagar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xcxp.c_TipoOperacion.c_Texto).Size = xcxp.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xcxp.c_EstatusDocumento.c_Texto).Size = xcxp.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xcxp.c_AutoDocumento.c_Texto).Size = xcxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xcxp.c_Signo.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxp.c_AutoMovimientoEntrada.c_Texto).Size = xcxp.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.Add("@fecha_recepcion_devolucion", SqlDbType.DateTime).Value = System.Data.SqlTypes.SqlDateTime.Null
                                xcmd.Parameters.AddWithValue("@numero", xcxp.c_Numero.c_Texto).Size = xcxp.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xcxp.c_AutoAgencia.c_Texto).Size = xcxp.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xcxp.c_NombreAgencia.c_Texto).Size = xcxp.c_NombreAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xcxp.c_NumeroCuenta.c_Texto).Size = xcxp.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xcxp.c_TipoCuenta.c_Texto).Size = xcxp.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xcxp.c_NombreTitular.c_Texto).Size = xcxp.c_NombreTitular.c_Largo
                                xcmd.ExecuteNonQuery()

                                'MOVIMIENTO ENTRADA CXP
                                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto_2
                                    .c_AutoProveedor.c_Texto = xagregar._FichaProveedor._Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCxP.c_Texto = xauto_1
                                    .c_CiRifProveedor.c_Texto = xagregar._FichaProveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xagregar._FichaProveedor._CodigoProveedor
                                    .c_DiasCreditoProveedor.c_Valor = xagregar._DiasCredito
                                    .c_Documento.c_Texto = xauto_3
                                    .c_DocumentoAplica.c_Texto = xagregar._NumeroDocumento
                                    .c_EstatusDocumento.c_Texto = xagregar._EstatusDocumento
                                    .c_FechaDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xcxp._FechaVencimiento
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreProveedor.c_Texto = xagregar._FichaProveedor._NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TipoDocumento.c_Texto = xtmov
                                    .c_TipoEntrada.c_Texto = xtipoentrada
                                    .c_TotalGeneral.c_Valor = xagregar._Importe
                                    .c_NumeroCuenta.c_Texto = ""
                                    .c_TipoCuenta.c_Texto = ""
                                    .c_NombreTitular.c_Texto = ""
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_CXP_MOVIMIENTOS_ENTRADA
                                xcmd.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_cxp", xagregar_mov.c_AutoCxP.c_Texto).Size = xagregar_mov.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_carga", xagregar_mov.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreProveedor.c_Texto).Size = xagregar_mov.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifProveedor.c_Texto).Size = xagregar_mov.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar_mov.c_AutoProveedor.c_Texto).Size = xagregar_mov.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xagregar_mov.c_CodigoProveedor.c_Texto).Size = xagregar_mov.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoProveedor.c_Valor)
                                xcmd.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcmd.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcmd.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xagregar_mov.c_NumeroCuenta.c_Texto).Size = xagregar_mov.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xagregar_mov.c_TipoCuenta.c_Texto).Size = xagregar_mov.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xagregar_mov.c_NombreTitular.c_Texto).Size = xagregar_mov.c_NombreTitular.c_Largo
                                xcmd.ExecuteNonQuery()

                                Dim t_debito1 As Single = 0
                                Dim t_credito1 As Single = 0
                                Dim t_saldo1 As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito1 = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito1 = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_resta from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_saldo1 = xobj
                                End If

                                'PROVEEDORES
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "UPDATE PROVEEDORES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito1)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito1)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo1)
                                xcmd.Parameters.AddWithValue("@auto", xagregar._FichaProveedor._Automatico)
                                xobj = xcmd.ExecuteNonQuery()
                                If xobj = 0 Or xobj Is Nothing Or IsDBNull(xobj) Then
                                    Throw New Exception("PROVEEDOR NO ENCONTRADO / FUE MODIFICADO POR OTRO USUARIO")
                                End If
                            End Using
                            xtr.Commit()
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
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL GRABAR DOCUMENTO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarNotaDebito(ByVal xagregar As c_CxP.c_AgregarNotaDebito) As Boolean
                Dim xsql1 As String = "update contadores set a_cxp=a_cxp+1; select a_cxp from contadores"
                Dim xsql2 As String = "update contadores set a_cxp_nd=a_cxp_nd+1; select a_cxp_nd from contadores"
                Dim xsql3 As String = "update contadores set a_cxp_movimientos_entrada=a_cxp_movimientos_entrada+1; select a_cxp_movimientos_entrada from contadores"

                Dim xauto_1 As String = ""
                Dim xauto_2 As String = ""
                Dim xauto_3 As String = ""

                Dim xobj As Object = Nothing
                Dim xtr As SqlTransaction = Nothing

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXP
                                xcmd.CommandText = xsql1
                                xauto_1 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES MOVIMIENTO DE ENTRADA
                                xcmd.CommandText = "select a_cxp_movimientos_entrada from contadores"
                                xobj = xcmd.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcmd.CommandText = "update contadores set a_cxp_movimientos_entrada=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.CommandText = xsql3
                                xauto_3 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES NOTA DE DEBITO
                                xcmd.CommandText = xsql2
                                xauto_2 = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CXP
                                Dim xcxp As New FichaCtasPagar.c_CxP.c_Registro
                                With xcxp
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroCuenta.c_Texto = ""
                                    .c_TipoCuenta.c_Texto = ""
                                    .c_NombreTitular.c_Texto = ""
                                    .c_AutoCxP.c_Texto = xauto_1
                                    .c_AutoProveedor.c_Texto = xagregar._FichaProveedor._Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto_3
                                    .c_CiRifProveedor.c_Texto = xagregar._FichaProveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xagregar._FichaProveedor._CodigoProveedor
                                    .c_EstatusCancelado.c_Texto = xagregar._EstatusCancelado
                                    .c_EstatusDocumento.c_Texto = xagregar._EstatusDocumento
                                    .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xagregar._Monto
                                    .c_MontoPorPagar.c_Valor = xagregar._Monto
                                    .c_NombreProveedor.c_Texto = xagregar._FichaProveedor._NombreRazonSocial
                                    .c_NotaDetalle.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroDocumento.c_Texto = xauto_2
                                    .c_TipoDocumento.c_Texto = "ND"
                                    .c_Signo.c_Valor = 1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_CXP
                                xcmd.Parameters.AddWithValue("@auto", xcxp.c_AutoCxP.c_Texto).Size = xcxp.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xcxp.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_carga", xcxp.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xcxp.c_TipoDocumento.c_Texto).Size = xcxp.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xcxp.c_NumeroDocumento.c_Texto).Size = xcxp.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxp.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xcxp.c_NotaDetalle.c_Texto).Size = xcxp.c_NotaDetalle.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xcxp.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xcxp.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xcxp.c_AutoProveedor.c_Texto).Size = xcxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@proveedor", xcxp.c_NombreProveedor.c_Texto).Size = xcxp.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xcxp.c_CiRifProveedor.c_Texto).Size = xcxp.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xcxp.c_CodigoProveedor.c_Texto).Size = xcxp.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xcxp.c_EstatusCancelado.c_Texto).Size = xcxp.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xcxp.c_MontoPorPagar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xcxp.c_TipoOperacion.c_Texto).Size = xcxp.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xcxp.c_EstatusDocumento.c_Texto).Size = xcxp.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xcxp.c_AutoDocumento.c_Texto).Size = xcxp.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xcxp.c_Signo.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxp.c_AutoMovimientoEntrada.c_Texto).Size = xcxp.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_recepcion_devolucion", xcxp.c_FechaRecepcionDevolucion.c_Valor)
                                xcmd.Parameters.AddWithValue("@numero", xcxp.c_Numero.c_Texto).Size = xcxp.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xcxp.c_AutoAgencia.c_Texto).Size = xcxp.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xcxp.c_NombreAgencia.c_Texto).Size = xcxp.c_NombreAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xcxp.c_NumeroCuenta.c_Texto).Size = xcxp.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xcxp.c_TipoCuenta.c_Texto).Size = xcxp.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xcxp.c_NombreTitular.c_Texto).Size = xcxp.c_NombreTitular.c_Largo
                                xcmd.ExecuteNonQuery()

                                'MOVIMIENTO ENTRADA CXP
                                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto_3
                                    .c_AutoProveedor.c_Texto = xagregar._FichaProveedor._Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_NumeroCuenta.c_Texto = ""
                                    .c_TipoCuenta.c_Texto = ""
                                    .c_NombreTitular.c_Texto = ""
                                    .c_AutoCxP.c_Texto = xauto_1
                                    .c_CiRifProveedor.c_Texto = xagregar._FichaProveedor._CiRif
                                    .c_CodigoProveedor.c_Texto = xagregar._FichaProveedor._CodigoProveedor
                                    .c_DiasCreditoProveedor.c_Valor = 0
                                    .c_Documento.c_Texto = xauto_2
                                    .c_DocumentoAplica.c_Texto = xagregar._NumeroDocumentoAplica
                                    .c_EstatusDocumento.c_Texto = xagregar._EstatusDocumento
                                    .c_FechaDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreProveedor.c_Texto = xagregar._FichaProveedor._NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TipoDocumento.c_Texto = "NDF"
                                    .c_TipoEntrada.c_Texto = xagregar._TipoEntrada
                                    .c_TotalGeneral.c_Valor = xagregar._Monto
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = INSERT_CXP_MOVIMIENTOS_ENTRADA
                                xcmd.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_cxp", xagregar_mov.c_AutoCxP.c_Texto).Size = xagregar_mov.c_AutoCxP.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_carga", xagregar_mov.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreProveedor.c_Texto).Size = xagregar_mov.c_NombreProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifProveedor.c_Texto).Size = xagregar_mov.c_CiRifProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar_mov.c_AutoProveedor.c_Texto).Size = xagregar_mov.c_AutoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_proveedor", xagregar_mov.c_CodigoProveedor.c_Texto).Size = xagregar_mov.c_CodigoProveedor.c_Largo
                                xcmd.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoProveedor.c_Valor)
                                xcmd.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcmd.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcmd.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcmd.Parameters.AddWithValue("@numero_cuenta", xagregar_mov.c_NumeroCuenta.c_Texto).Size = xagregar_mov.c_NumeroCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo_cuenta", xagregar_mov.c_TipoCuenta.c_Texto).Size = xagregar_mov.c_TipoCuenta.c_Largo
                                xcmd.Parameters.AddWithValue("@titular", xagregar_mov.c_NombreTitular.c_Texto).Size = xagregar_mov.c_NombreTitular.c_Largo
                                xcmd.ExecuteNonQuery()

                                Dim t_debito1 As Single = 0
                                Dim t_credito1 As Single = 0
                                Dim t_saldo1 As Single = 0

                                'BUSCA LOS SALDOS PARA EL PROVEEDOR
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_debito1 = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_credito1 = xobj
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._FichaProveedor._Automatico)
                                xcmd.CommandText = "select sum(resta) as s_resta from cxp where auto_proveedor=@auto_proveedor and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_proveedor"
                                xobj = xcmd.ExecuteScalar()
                                If Not IsDBNull(xobj) And xobj IsNot Nothing Then
                                    t_saldo1 = xobj
                                End If

                                'PROVEEDORES
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "UPDATE PROVEEDORES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito1)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito1)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo1)
                                xcmd.Parameters.AddWithValue("@auto", xagregar._FichaProveedor._Automatico)
                                xobj = xcmd.ExecuteNonQuery()
                                If xobj = 0 Or xobj Is Nothing Or IsDBNull(xobj) Then
                                    Throw New Exception("PROVEEDOR NO ENCONTRADO / FUE MODIFICADO POR OTRO USUARIO")
                                End If
                            End Using
                            xtr.Commit()
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR PAGAR" + vbCrLf + "ERROR AL GRABAR NOTA DÉBITO:" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class

        Private xfichasCxP As FichaCtasPagar

        Property f_FichasCxP() As FichaCtasPagar
            Get
                Return xfichasCxP
            End Get
            Set(ByVal value As FichaCtasPagar)
                xfichasCxP = value
            End Set
        End Property
    End Class
End Namespace
Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class FichaCtasCobrar
            Event RetornarAutoRecibo(ByVal xauto As String)
            Event DocumentoProcesado()

            Class c_CxC

                Class c_AgregarNotaDebito
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xmonto As Decimal
                    Private xnotas As String
                    Private xfechaproceso As Date
                    Private xapliaca As String

                    Sub New()
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._FechaProceso = Date.MinValue
                        Me._Monto = 0
                        Me._NotasDetalle = ""
                        Me._NumeroDocumentoAplica = ""
                    End Sub

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
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
                            Return xapliaca
                        End Get
                        Set(ByVal value As String)
                            xapliaca = value
                        End Set
                    End Property
                End Class

                Class c_AgregarChequeDevuelto
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xfichaagencia As FichaBancos.c_Agencias.c_Registro
                    Private xcomision As Decimal
                    Private xmonto As Decimal
                    Private xnotas As String
                    Private xnumerocheque As String
                    Private xfechaemision As Date
                    Private xfechaproceso As Date
                    Private xfechadevolucion As Date

                    Sub New()
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._FichaAgencia = New FichaBancos.c_Agencias.c_Registro
                        Me._ComisionCheque = 0
                        Me._FechaDevolucion = Date.MinValue
                        Me._FechaEmision = Date.MinValue
                        Me._FechaProceso = Date.MinValue
                        Me._MontoCheque = 0
                        Me._NotasDetalle = ""
                        Me._NumeroCheque = ""
                    End Sub

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
                        End Set
                    End Property

                    Property _FichaAgencia() As FichaBancos.c_Agencias.c_Registro
                        Protected Friend Get
                            Return Me.xfichaagencia
                        End Get
                        Set(ByVal value As FichaBancos.c_Agencias.c_Registro)
                            Me.xfichaagencia = value
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

                Class c_AgregarDocumentoCxC
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private ximporte As Decimal
                    Private xsaldo As Decimal
                    Private xnotas As String
                    Private xdocumento As String
                    Private xfechaemision As Date
                    Private xfechaproceso As Date
                    Private xdiascredito As Integer
                    Private xtipodocumento As TipoDocumentoMovEntradaCxC

                    Sub New()
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._SaldoPendiente = 0
                        Me._FechaEmision = Date.MinValue
                        Me._FechaProceso = Date.MinValue
                        Me._Importe = 0
                        Me._NotasDetalle = ""
                        Me._NumeroDocumento = ""
                        Me._DiasCredito = 0
                    End Sub

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
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

                    Property _TipoDocumentoProcesar() As TipoDocumentoMovEntradaCxC
                        Get
                            Return Me.xtipodocumento
                        End Get
                        Set(ByVal value As TipoDocumentoMovEntradaCxC)
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

                Class c_AgregarPagoNotaCredito
                    Private xfichacxc As FichaCtasCobrar.c_CxC.c_Registro
                    Private xfichacobrador As FichaCobradores.c_Cobrador.c_Registro
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xfecha As Date
                    Private xnotas As String
                    Private xmonto As Decimal

                    Property _FichaCxC() As FichaCtasCobrar.c_CxC.c_Registro
                        Protected Friend Get
                            Return Me.xfichacxc
                        End Get
                        Set(ByVal value As FichaCtasCobrar.c_CxC.c_Registro)
                            Me.xfichacxc = value
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

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
                        End Set
                    End Property

                    Property _FichaCobrador() As FichaCobradores.c_Cobrador.c_Registro
                        Protected Friend Get
                            Return Me.xfichacobrador
                        End Get
                        Set(ByVal value As FichaCobradores.c_Cobrador.c_Registro)
                            Me.xfichacobrador = value
                        End Set
                    End Property

                    Property _FechaEmision() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
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
                        Me._FechaEmision = Date.MinValue
                        Me._FichaCxC = New FichaCtasCobrar.c_CxC.c_Registro
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._FichaCobrador = New FichaCobradores.c_Cobrador.c_Registro
                        Me._FichaUsuario = New FichaGlobal.c_Usuario.c_Registro
                        Me._MontoImporte = 0
                        Me._NotasDetalle = ""
                    End Sub
                End Class

                Class c_AgregarPagoAnticipo
                    Class Pagos
                        Private xmediopago As FichaGlobal.c_MediosPagos.c_Registro
                        Private xagencia As String
                        Private xplanilla As String
                        Private ximporte As Decimal
                        Private xrecibido As Decimal

                        Sub New()
                            Me._Agencia = ""
                            Me._MedioPago = New FichaGlobal.c_MediosPagos.c_Registro
                            Me._MontoImporte = 0
                            Me._MontoRecibido = 0
                            Me._PlanillaCheque = ""
                        End Sub

                        Property _MedioPago() As FichaGlobal.c_MediosPagos.c_Registro
                            Get
                                Return xmediopago
                            End Get
                            Set(ByVal value As FichaGlobal.c_MediosPagos.c_Registro)
                                xmediopago = value
                            End Set
                        End Property

                        Property _Agencia() As String
                            Get
                                Return xagencia
                            End Get
                            Set(ByVal value As String)
                                xagencia = value
                            End Set
                        End Property

                        Property _PlanillaCheque() As String
                            Get
                                Return xplanilla
                            End Get
                            Set(ByVal value As String)
                                xplanilla = value
                            End Set
                        End Property

                        Property _MontoImporte() As Decimal
                            Get
                                Return ximporte
                            End Get
                            Set(ByVal value As Decimal)
                                ximporte = value
                            End Set
                        End Property

                        Property _MontoRecibido() As Decimal
                            Get
                                Return xrecibido
                            End Get
                            Set(ByVal value As Decimal)
                                xrecibido = value
                            End Set
                        End Property
                    End Class

                    Private xlistapagos As List(Of Pagos)
                    Private xfichacobrador As FichaCobradores.c_Cobrador.c_Registro
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xfecha As Date
                    Private xfechaproceso As Date
                    Private xnotas As String
                    Private xmonto As Decimal

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return Me.xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xfichausuario = value
                        End Set
                    End Property

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
                        End Set
                    End Property

                    Property _FichaCobrador() As FichaCobradores.c_Cobrador.c_Registro
                        Protected Friend Get
                            Return Me.xfichacobrador
                        End Get
                        Set(ByVal value As FichaCobradores.c_Cobrador.c_Registro)
                            Me.xfichacobrador = value
                        End Set
                    End Property

                    Property _FechaEmision() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
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

                    Property _ListaPagos() As List(Of Pagos)
                        Get
                            Return xlistapagos
                        End Get
                        Set(ByVal value As List(Of Pagos))
                            xlistapagos = value
                        End Set
                    End Property

                    Sub New()
                        Me._FechaEmision = Date.MinValue
                        Me._FechaProceso = Date.MinValue
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._FichaCobrador = New FichaCobradores.c_Cobrador.c_Registro
                        Me._FichaUsuario = New FichaGlobal.c_Usuario.c_Registro
                        Me._MontoImporte = 0
                        Me._NotasDetalle = ""
                        Me._ListaPagos = New List(Of Pagos)
                    End Sub
                End Class

                Class c_AnularDocumentoCxC
                    Private xfichaCxC As FichaCtasCobrar.c_CxC.c_Registro
                    Private xDocumentoAnular As FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                    Private xlistdocumentos As List(Of c_Documentos.c_Registro)
                    Private xautorecibo As String

                    Property _FichaRegistroCxc() As FichaCtasCobrar.c_CxC.c_Registro
                        Get
                            Return Me.xfichaCxC
                        End Get
                        Set(ByVal value As FichaCtasCobrar.c_CxC.c_Registro)
                            Me.xfichaCxC = value
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

                    Property _AutoReciboCxc() As String
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
                        Me._AutoReciboCxc = ""
                        Me._FichaRegistroCxc = New FichaCtasCobrar.c_CxC.c_Registro
                        Me._DocumentoAnular = New FichaGlobal.c_DocumentosAnulados.c_AgregarRegistro
                        Me._ListaDocumentos = New List(Of c_Documentos.c_Registro)
                    End Sub
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
                    Class ModoPagos
                        Private xmediopago As FichaGlobal.c_MediosPagos.c_Registro
                        Private xagencia As String
                        Private xplanilla As String
                        Private ximporte As Decimal
                        Private xrecibido As Decimal

                        Sub New()
                            Me._Agencia = ""
                            Me._MedioPago = New FichaGlobal.c_MediosPagos.c_Registro
                            Me._MontoImporte = 0
                            Me._MontoRecibido = 0
                            Me._PlanillaCheque = ""
                        End Sub

                        Property _MedioPago() As FichaGlobal.c_MediosPagos.c_Registro
                            Get
                                Return xmediopago
                            End Get
                            Set(ByVal value As FichaGlobal.c_MediosPagos.c_Registro)
                                xmediopago = value
                            End Set
                        End Property

                        Property _Agencia() As String
                            Get
                                Return xagencia
                            End Get
                            Set(ByVal value As String)
                                xagencia = value
                            End Set
                        End Property

                        Property _PlanillaCheque() As String
                            Get
                                Return xplanilla
                            End Get
                            Set(ByVal value As String)
                                xplanilla = value
                            End Set
                        End Property

                        Property _MontoImporte() As Decimal
                            Get
                                Return ximporte
                            End Get
                            Set(ByVal value As Decimal)
                                ximporte = value
                            End Set
                        End Property

                        Property _MontoRecibido() As Decimal
                            Get
                                Return xrecibido
                            End Get
                            Set(ByVal value As Decimal)
                                xrecibido = value
                            End Set
                        End Property
                    End Class

                    Private xlista_DocumentosPagar As List(Of Doc)
                    Private xfichacobrador As FichaCobradores.c_Cobrador.c_Registro
                    Private xfichacliente As FichaClientes.c_Clientes.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xfechaproceso As Date
                    Private xnotas As String
                    Private xmonto As Decimal
                    Private xmonto_anticipo As Decimal
                    Private xfechaemision As Date
                    Private xlista_pagos_documentos_nc As List(Of Doc)
                    Private xlista_modospagos As List(Of ModoPagos)

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

                    Property _ListaModosPagos() As List(Of ModoPagos)
                        Protected Friend Get
                            Return Me.xlista_modospagos
                        End Get
                        Set(ByVal value As List(Of ModoPagos))
                            Me.xlista_modospagos = value
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

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Protected Friend Get
                            Return Me.xfichacliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            Me.xfichacliente = value
                        End Set
                    End Property

                    Property _FichaCobrador() As FichaCobradores.c_Cobrador.c_Registro
                        Protected Friend Get
                            Return Me.xfichacobrador
                        End Get
                        Set(ByVal value As FichaCobradores.c_Cobrador.c_Registro)
                            Me.xfichacobrador = value
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

                    Property _MontoAnticipoUsado() As Decimal
                        Get
                            Return xmonto_anticipo
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto_anticipo = value
                        End Set
                    End Property

                    Sub New()
                        Me._FechaProceso = Date.MinValue
                        Me._FechaEmision = Date.MinValue
                        Me._ListaDocumentosPagar = New List(Of Doc)
                        Me._ListaDocumentosNC_ModoPago = New List(Of Doc)
                        Me._FichaCliente = New FichaClientes.c_Clientes.c_Registro
                        Me._FichaCobrador = New FichaCobradores.c_Cobrador.c_Registro
                        Me._FichaUsuario = New FichaGlobal.c_Usuario.c_Registro
                        Me._MontoImporte = 0
                        Me._NotasDetalle = ""
                        _MontoAnticipoUsado = 0
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_tipo_documento As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha_vencimiento As CampoFecha
                    Private f_detalle As CampoTexto
                    Private f_importe As CampoDecimal
                    Private f_acumulado As CampoDecimal
                    Private f_auto_cliente As CampoTexto
                    Private f_cliente As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_codigo_cliente As CampoTexto
                    Private f_cancelado As CampoTexto
                    Private f_resta As CampoDecimal
                    Private f_operacion As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_auto_documento As CampoTexto
                    Private f_numero As CampoTexto
                    Private f_auto_agencia As CampoTexto
                    Private f_agencia As CampoTexto
                    Private f_signo As CampoInteger

                    'Nuevos
                    Private f_auto_mov_entrada As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private f_fecha_emision As CampoFecha
                    Private f_fecha_recepcion_devolucion As CampoFecha
                    Private f_auto_movimiento As CampoTexto
                    Private f_auto_documento_retencion As CampoTexto

                    Protected Friend Property c_AutoCxC() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
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

                    Protected Friend Property c_NotasDetalles() As CampoTexto
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

                    Protected Friend Property c_AutoCliente() As CampoTexto
                        Get
                            Return f_auto_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cliente = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreCliente() As CampoTexto
                        Get
                            Return f_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cliente = value
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

                    Protected Friend Property c_CodigoCliente() As CampoTexto
                        Get
                            Return f_codigo_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_cliente = value
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

                    Protected Friend Property c_MontoPorCobrar() As CampoDecimal
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

                    Protected Friend Property c_EstatusDocumentoCxC() As CampoTexto
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

                    ''' <summary>
                    ''' NUMERO DEL CHEQUE/DEPOSITO/TRANSFERENCIA 
                    ''' </summary>
                    Protected Friend Property c_Numero() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoAgencia() As CampoTexto
                        Get
                            Return f_auto_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_agencia = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreAgencia() As CampoTexto
                        Get
                            Return f_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_agencia = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' ASIGNA EL SIGNO DEL DOCUMENTO ORIGEN
                    ''' </summary>
                    Protected Friend Property c_TipoMovimiento() As CampoInteger
                        Get
                            Return f_signo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_signo = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDocumentoRetencion() As CampoTexto
                        Get
                            Return f_auto_documento_retencion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento_retencion = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCxC() As String
                        Get
                            Return c_AutoCxC.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return c_FechaProceso.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As String
                        Get
                            Return c_TipoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumentoRegistradoCxC() As TipoDocumentoRegistradoCxC
                        Get
                            Select Case Me._TipoDocumento
                                Case "FAC" : Return TipoDocumentoRegistradoCxC.Factura
                                Case "NCF", "NC" : Return TipoDocumentoRegistradoCxC.NotaCredito
                                Case "ND", "NDF" : Return TipoDocumentoRegistradoCxC.NotaDebito
                                Case "PRE" : Return TipoDocumentoRegistradoCxC.Prestamo
                                Case "CHD" : Return TipoDocumentoRegistradoCxC.ChequeDevuelto
                                Case "ANT" : Return TipoDocumentoRegistradoCxC.Anticipo
                                Case "PAG" : Return TipoDocumentoRegistradoCxC.Pago
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
                            Return c_FechaVencimiento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasDetalles() As String
                        Get
                            Return c_NotasDetalles.c_Texto.Trim
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

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreCliente() As String
                        Get
                            Return c_NombreCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifCliente() As String
                        Get
                            Return c_CiRifCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoCliente() As String
                        Get
                            Return c_CodigoCliente.c_Texto.Trim
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

                    ReadOnly Property _MontoPorCobrar() As Decimal
                        Get
                            Return c_MontoPorCobrar.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoOperacion() As String
                        Get
                            Return c_TipoOperacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _EstatusDocumentoCxC() As TipoEstatus
                        Get
                            Select Case c_EstatusDocumentoCxC.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Numero() As String
                        Get
                            Return c_Numero.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoAgencia() As String
                        Get
                            Return c_AutoAgencia.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreAgencia() As String
                        Get
                            Return c_NombreAgencia.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' RETORNA EL SIGNO DEL DOCUMENTO ORIGEN
                    ''' </summary>
                    ReadOnly Property _TipoMovimiento() As Integer
                        Get
                            Return c_TipoMovimiento.c_Valor
                        End Get
                    End Property

                    'NUEVOS
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

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha_emision
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_emision = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return c_FechaEmision.c_Valor
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
                    ''' INDICA EL AUTO A TABLA MOVIMIENTOS, PARA SABER SI ESTE MOVIMIENTO SE ORIGINO DE BANCOS, POR CHEQUE DEVUELTO
                    ''' </summary>
                    ''' <value></value>
                    Protected Friend Property c_AutoMovimientoBanco() As CampoTexto
                        Get
                            Return f_auto_movimiento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_movimiento = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' RETORNA EL AUTO PARA LA TABLA MOVIMIENTOS, INDICANDO SI ES UN CHEQUE DEVUELTO
                    ''' </summary>
                    ReadOnly Property _AutoMovimientoBanco() As String
                        Get
                            Return c_AutoMovimientoBanco.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumentoRetencion() As String
                        Get
                            Return c_AutoDocumentoRetencion.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_AutoCxC = New CampoTexto(10, "auto")
                        c_FechaProceso = New CampoFecha("fecha")
                        c_TipoDocumento = New CampoTexto(3, "tipo_documento")
                        c_NumeroDocumento = New CampoTexto(10, "documento")
                        c_FechaVencimiento = New CampoFecha("fecha_vencimiento")
                        c_NotasDetalles = New CampoTexto(120, "detalle")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_MontoAcumulado = New CampoDecimal("acumulado")
                        c_AutoCliente = New CampoTexto(10, "auto_cliente")
                        c_NombreCliente = New CampoTexto(120, "cliente")
                        c_CiRifCliente = New CampoTexto(12, "ci_rif")
                        c_CodigoCliente = New CampoTexto(15, "codigo_cliente")
                        c_EstatusCancelado = New CampoTexto(1, "cancelado")
                        c_MontoPorCobrar = New CampoDecimal("resta")
                        c_TipoOperacion = New CampoTexto(11, "operacion")
                        c_EstatusDocumentoCxC = New CampoTexto(1, "estatus")
                        c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        c_Numero = New CampoTexto(10, "numero")
                        c_AutoAgencia = New CampoTexto(10, "auto_agencia")
                        c_NombreAgencia = New CampoTexto(40, "agencia")
                        c_TipoMovimiento = New CampoInteger("signo")

                        'Nuevos
                        c_AutoMovimientoEntrada = New CampoTexto(10, "auto_mov_entrada")
                        c_FechaRecepcionDevolucion = New CampoFecha("fecha_recepcion_devolucion")
                        c_FechaEmision = New CampoFecha("fecha_emision")
                        c_AutoMovimientoBanco = New CampoTexto(10, "auto_movimiento")
                        c_AutoDocumentoRetencion = New CampoTexto(10, "auto_documento_retencion")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoAgencia.c_Texto = xrow(.c_AutoAgencia.c_NombreInterno)
                                .c_AutoCliente.c_Texto = xrow(.c_AutoCliente.c_NombreInterno)
                                .c_AutoCxC.c_Texto = xrow(.c_AutoCxC.c_NombreInterno)
                                .c_AutoDocumento.c_Texto = xrow(.c_AutoDocumento.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(.c_CiRifCliente.c_NombreInterno)
                                .c_CodigoCliente.c_Texto = xrow(.c_CodigoCliente.c_NombreInterno)
                                .c_EstatusCancelado.c_Texto = xrow(.c_EstatusCancelado.c_NombreInterno)
                                .c_EstatusDocumentoCxC.c_Texto = xrow(.c_EstatusDocumentoCxC.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_FechaVencimiento.c_Valor = xrow(.c_FechaVencimiento.c_NombreInterno)
                                .c_MontoAcumulado.c_Valor = xrow(.c_MontoAcumulado.c_NombreInterno)
                                .c_MontoImporte.c_Valor = xrow(.c_MontoImporte.c_NombreInterno)
                                .c_MontoPorCobrar.c_Valor = xrow(.c_MontoPorCobrar.c_NombreInterno)
                                .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)
                                .c_NombreCliente.c_Texto = xrow(.c_NombreCliente.c_NombreInterno)
                                .c_NotasDetalles.c_Texto = xrow(.c_NotasDetalles.c_NombreInterno)
                                .c_Numero.c_Texto = xrow(.c_Numero.c_NombreInterno)
                                .c_NumeroDocumento.c_Texto = xrow(.c_NumeroDocumento.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TipoMovimiento.c_Valor = xrow(.c_TipoMovimiento.c_NombreInterno)
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
                                If Not IsDBNull(xrow(.c_FechaEmision.c_NombreInterno)) Then
                                    .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoMovimientoBanco.c_NombreInterno)) Then
                                    .c_AutoMovimientoBanco.c_Texto = xrow(.c_AutoMovimientoBanco.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoDocumentoRetencion.c_NombreInterno)) Then
                                    .c_AutoDocumentoRetencion.c_Texto = xrow(.c_AutoDocumentoRetencion.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXC" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from cxc where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarFicha(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("CXC" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Class c_Recibos
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_numero As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_auto_usuario As CampoTexto
                    Private f_importe As CampoDecimal
                    Private f_usuario As CampoTexto
                    Private f_importe_documentos As CampoDecimal
                    Private f_descuentos As CampoDecimal
                    Private f_total_documentos As CampoDecimal
                    Private f_detalle As CampoTexto
                    Private f_cobrador As CampoTexto
                    Private f_auto_cliente As CampoTexto
                    Private f_nombre_cliente As CampoTexto
                    Private f_ci_rif_cliente As CampoTexto
                    Private f_codigo_cliente As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_direccion As CampoTexto
                    Private f_telefono As CampoTexto
                    Private f_auto_cobrador As CampoTexto
                    Private f_anticipos As CampoDecimal
                    Private f_cant_doc_rel As CampoInteger
                    'Campos Nuevos
                    Private f_monto_nc_pagadas As CampoDecimal
                    Private f_cant_nc_pagadas As CampoInteger
                    Private f_auto_cxc As CampoTexto


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

                    Protected Friend Property c_MontoDescuento() As CampoDecimal
                        Get
                            Return f_descuentos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_descuentos = value
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

                    Protected Friend Property c_NotasDetalles() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreCobrador() As CampoTexto
                        Get
                            Return f_cobrador
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_cobrador = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoCliente() As CampoTexto
                        Get
                            Return f_auto_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cliente = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreCliente() As CampoTexto
                        Get
                            Return f_nombre_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_cliente = value
                        End Set
                    End Property

                    Protected Friend Property c_CiRifCliente() As CampoTexto
                        Get
                            Return f_ci_rif_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ci_rif_cliente = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoCliente() As CampoTexto
                        Get
                            Return f_codigo_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_cliente = value
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

                    Protected Friend Property c_DirFiscalCliente() As CampoTexto
                        Get
                            Return f_direccion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_direccion = value
                        End Set
                    End Property

                    Protected Friend Property c_TelefonoCliente() As CampoTexto
                        Get
                            Return f_telefono
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoCobrador() As CampoTexto
                        Get
                            Return f_auto_cobrador
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cobrador = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoAnticipo() As CampoDecimal
                        Get
                            Return f_anticipos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_anticipos = value
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

                    '' CAMPOS NUEVOS

                    Protected Friend Property c_MontoNCPagadas() As CampoDecimal
                        Get
                            Return f_monto_nc_pagadas
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto_nc_pagadas = value
                        End Set
                    End Property

                    Protected Friend Property c_CantNCPagadas() As CampoInteger
                        Get
                            Return f_cant_nc_pagadas
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_cant_nc_pagadas = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' retorna el automatico de la cxc PAGO al cual se le esta realizando el recibo
                    ''' </summary>
                    Protected Friend Property c_AutoCxcPago() As CampoTexto
                        Get
                            Return f_auto_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc = value
                        End Set
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
                            Return c_FechaEmision.c_Valor
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

                    ReadOnly Property _MontoDescuento() As Decimal
                        Get
                            Return c_MontoDescuento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MontoTotalDocumento() As Decimal
                        Get
                            Return c_MontoTotalDocumento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasDetalles() As String
                        Get
                            Return c_NotasDetalles.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreCobrador() As String
                        Get
                            Return c_NombreCobrador.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreCliente() As String
                        Get
                            Return c_NombreCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRifCliente() As String
                        Get
                            Return c_CiRifCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoCliente() As String
                        Get
                            Return c_CodigoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _EstatusRecibo() As TipoEstatus
                        Get
                            Select Case c_EstatusRecibo.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _DirFiscalCliente() As String
                        Get
                            Return c_DirFiscalCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TelefonoCliente() As String
                        Get
                            Return c_TelefonoCliente.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoCobrador() As String
                        Get
                            Return c_AutoCobrador.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoAnticipo() As Decimal
                        Get
                            Return c_MontoAnticipo.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CantidadDocumentosRelacionados() As Integer
                        Get
                            Return Me.c_CantidadDocumentosRelacionados.c_Valor
                        End Get
                    End Property

                    'CAMPOS NUEVOS

                    ReadOnly Property _MontoNCPagadas() As Decimal
                        Get
                            Return Me.c_MontoNCPagadas.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CantNCPagadas() As Integer
                        Get
                            Return Me.c_CantNCPagadas.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' retorna el automatico de la cxc PAGO al cual se le esta realizando el recibo
                    ''' </summary>
                    ReadOnly Property _AutoCxCPago() As String
                        Get
                            Return Me.c_AutoCxcPago.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _TipoDocOrigen() As TipoDocumentoRegistradoCxC
                        Get
                            Try
                                If Me._AutoCxCPago <> "" Then
                                    Dim xcxc As New FichaCtasCobrar.c_CxC
                                    xcxc.F_CargarRegistro(_AutoCxCPago)
                                    Return xcxc.RegistroDato._TipoDocumentoRegistradoCxC
                                End If
                            Catch ex As Exception
                                Return 0
                            End Try
                        End Get
                    End Property


                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_AutoRecibo = New CampoTexto(10, "auto")
                        c_NumeroRecibo = New CampoTexto(10, "numero")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_AutoUsuario = New CampoTexto(10, "auto_usuario")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_NombreUsuario = New CampoTexto(50, "usuario")
                        c_MontoImporteDocumento = New CampoDecimal("importe_documentos")
                        c_MontoDescuento = New CampoDecimal("descuentos")
                        c_MontoTotalDocumento = New CampoDecimal("total_documentos")
                        c_NotasDetalles = New CampoTexto(50, "detalle")
                        c_NombreCobrador = New CampoTexto(50, "cobrador")
                        c_AutoCliente = New CampoTexto(10, "auto_cliente")
                        c_NombreCliente = New CampoTexto(120, "nombre_cliente")
                        c_CiRifCliente = New CampoTexto(12, "ci_rif_cliente")
                        c_CodigoCliente = New CampoTexto(15, "codigo_cliente")
                        c_EstatusRecibo = New CampoTexto(1, "estatus")
                        c_DirFiscalCliente = New CampoTexto(120, "direccion")
                        c_TelefonoCliente = New CampoTexto(60, "telefono")
                        c_AutoCobrador = New CampoTexto(10, "auto_cobrador")
                        c_MontoAnticipo = New CampoDecimal("anticipos")
                        c_CantidadDocumentosRelacionados = New CampoInteger("cant_doc_rel")
                        c_MontoNCPagadas = New CampoDecimal("monto_nc_pagadas")
                        c_CantNCPagadas = New CampoInteger("cant_nc_pagadas")
                        c_AutoCxcPago = New CampoTexto(10, "auto_cxc")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoCliente.c_Texto = xrow(.c_AutoCliente.c_NombreInterno)
                                .c_AutoCobrador.c_Texto = xrow(.c_AutoCobrador.c_NombreInterno)
                                .c_AutoRecibo.c_Texto = xrow(.c_AutoRecibo.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(.c_CiRifCliente.c_NombreInterno)
                                .c_CodigoCliente.c_Texto = xrow(.c_CodigoCliente.c_NombreInterno)
                                .c_DirFiscalCliente.c_Texto = xrow(.c_DirFiscalCliente.c_NombreInterno)
                                .c_EstatusRecibo.c_Texto = xrow(.c_EstatusRecibo.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_MontoAnticipo.c_Valor = xrow(.c_MontoAnticipo.c_NombreInterno)
                                .c_MontoDescuento.c_Valor = xrow(.c_MontoDescuento.c_NombreInterno)
                                .c_MontoImporte.c_Valor = xrow(.c_MontoImporte.c_NombreInterno)
                                .c_MontoImporteDocumento.c_Valor = xrow(.c_MontoImporteDocumento.c_NombreInterno)
                                .c_MontoTotalDocumento.c_Valor = xrow(.c_MontoTotalDocumento.c_NombreInterno)
                                .c_NombreCliente.c_Texto = xrow(.c_NombreCliente.c_NombreInterno)
                                .c_NombreCobrador.c_Texto = xrow(.c_NombreCobrador.c_NombreInterno)
                                .c_NombreUsuario.c_Texto = xrow(.c_NombreUsuario.c_NombreInterno)
                                .c_NotasDetalles.c_Texto = xrow(.c_NotasDetalles.c_NombreInterno)
                                .c_NumeroRecibo.c_Texto = xrow(.c_NumeroRecibo.c_NombreInterno)
                                .c_TelefonoCliente.c_Texto = xrow(.c_TelefonoCliente.c_NombreInterno)

                                If Not IsDBNull(xrow(.c_CantidadDocumentosRelacionados.c_NombreInterno)) Then
                                    .c_CantidadDocumentosRelacionados.c_Valor = xrow(.c_CantidadDocumentosRelacionados.c_NombreInterno)
                                End If
                                'CAMPOS NUEVOS
                                If Not IsDBNull(xrow(.c_MontoNCPagadas.c_NombreInterno)) Then
                                    .c_MontoNCPagadas.c_Valor = xrow(.c_MontoNCPagadas.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_CantNCPagadas.c_NombreInterno)) Then
                                    .c_CantNCPagadas.c_Valor = xrow(.c_CantNCPagadas.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_AutoCxcPago.c_NombreInterno)) Then
                                    .c_AutoCxcPago.c_Texto = xrow(.c_AutoCxcPago.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXC RECIBOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Sub M_CargarRegistro(ByVal xauto As String)
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from cxc_recibos where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.RegistroDato.CargarFicha(xtb(0))
                        Else
                            Throw New Exception("AUTO RECIBO DE COBRO NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Class c_Documentos
                Class c_Registro
                    Private f_item As New CampoInteger
                    Private f_operacion As CampoTexto
                    Private f_monto As CampoDecimal
                    Private f_auto_cxc As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_auto_cxc_pago As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_detalle As CampoTexto
                    Private f_auto_cxc_recibo As CampoTexto
                    Private f_numero_recibo As CampoTexto
                    Private f_origen As CampoTexto
                    'Campos Nuevos
                    Private f_monto_pendiente As CampoDecimal
                    Private f_signo As CampoInteger

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

                    Protected Friend Property c_Monto() As CampoDecimal
                        Get
                            Return f_monto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoCxC() As CampoTexto
                        Get
                            Return f_auto_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc = value
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

                    Protected Friend Property c_AutoCxCPago() As CampoTexto
                        Get
                            Return f_auto_cxc_pago
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc_pago = value
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

                    Protected Friend Property c_NotasDetalles() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoCxCRecibo() As CampoTexto
                        Get
                            Return f_auto_cxc_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc_recibo = value
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

                    ''' <summary>
                    ''' Indica El Saldo Pendiente De La Cuenta Al Abonar / Pagar en su totalidad
                    ''' </summary>
                    Protected Friend Property c_SaldoPendienteAlMomentoDeAbonarPagar() As CampoDecimal
                        Get
                            Return f_monto_pendiente
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto_pendiente = value
                        End Set
                    End Property

                    Protected Friend Property c_SignoDocumento() As CampoInteger
                        Get
                            Return f_signo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_signo = value
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

                    ReadOnly Property _Monto() As Decimal
                        Get
                            Return c_Monto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _AutoCxC() As String
                        Get
                            Return c_AutoCxC.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumento() As String
                        Get
                            Return c_NumeroDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoCxCPago() As String
                        Get
                            Return c_AutoCxCPago.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As String
                        Get
                            Return c_TipoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return c_FechaEmision.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _NotasDetalles() As String
                        Get
                            Return c_NotasDetalles.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoCxCRecibo.c_Texto.Trim
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

                    ReadOnly Property _SaldoPendienteAlMomentoDeAbonarPagar() As Decimal
                        Get
                            Return c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _SignoDocumento() As Integer
                        Get
                            Return c_SignoDocumento.c_Valor
                        End Get
                    End Property


                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Item = New CampoInteger("item")
                        c_TipoOperacion = New CampoTexto(11, "operacion")
                        c_Monto = New CampoDecimal("monto")
                        c_AutoCxC = New CampoTexto(10, "auto_cxc")
                        c_NumeroDocumento = New CampoTexto(10, "documento")
                        c_AutoCxCPago = New CampoTexto(10, "auto_cxc_pago")
                        c_TipoDocumento = New CampoTexto(3, "tipo")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_NotasDetalles = New CampoTexto(50, "detalle")
                        c_AutoCxCRecibo = New CampoTexto(10, "auto_cxc_recibo")
                        c_NumeroRecibo = New CampoTexto(10, "numero_recibo")
                        c_OrigenDocumento = New CampoTexto(20, "origen")
                        'Nuevos
                        c_SaldoPendienteAlMomentoDeAbonarPagar = New CampoDecimal("monto_pendiente")
                        c_SignoDocumento = New CampoInteger("signo")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoCxC.c_Texto = xrow(.c_AutoCxC.c_NombreInterno)
                                .c_AutoCxCPago.c_Texto = xrow(.c_AutoCxCPago.c_NombreInterno)
                                .c_AutoCxCRecibo.c_Texto = xrow(.c_AutoCxCRecibo.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_Item.c_Valor = xrow(.c_Item.c_NombreInterno)
                                .c_Monto.c_Valor = xrow(.c_Monto.c_NombreInterno)
                                .c_NotasDetalles.c_Texto = xrow(.c_NotasDetalles.c_NombreInterno)
                                .c_NumeroDocumento.c_Texto = xrow(.c_NumeroDocumento.c_NombreInterno)
                                .c_NumeroRecibo.c_Texto = xrow(.c_NumeroRecibo.c_NombreInterno)
                                .c_OrigenDocumento.c_Texto = xrow(.c_OrigenDocumento.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TipoOperacion.c_Texto = xrow(.c_TipoOperacion.c_NombreInterno)

                                'Nuevos
                                If Not IsDBNull(xrow(.c_SaldoPendienteAlMomentoDeAbonarPagar.c_NombreInterno)) Then
                                    .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xrow(.c_SaldoPendienteAlMomentoDeAbonarPagar.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_SignoDocumento.c_NombreInterno)) Then
                                    .c_SignoDocumento.c_Valor = xrow(.c_SignoDocumento.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXC DOCUMENTOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Class c_ModosPago
                Class AgregarModoPago
                    Private xregistro As c_Registro

                    WriteOnly Property _Numero() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_Numero.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreAgencia() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_NombreAgencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _MontoImporte() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegsitroDato.c_MontoImporte.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoTipoPago() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_CodigoTipoPago.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreTipoPago() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_NombreTipoPago.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoTipoPago() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_AutoTipoPago.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoAgencia() As String
                        Set(ByVal value As String)
                            Me.RegsitroDato.c_AutoAgencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _MontoRecibido() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegsitroDato.c_MontoRecibido.c_Valor = value
                        End Set
                    End Property

                    Protected Friend Property RegsitroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegsitroDato = New c_Registro
                    End Sub
                End Class

                Class c_Registro
                    Private f_numero As CampoTexto
                    Private f_agencia As CampoTexto
                    Private f_importe As CampoDecimal
                    Private f_codigo As CampoTexto
                    Private f_auto_recibo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_auto_medios_pago As CampoTexto
                    Private f_auto_agencia As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_estatus As CampoTexto
                    Private f_monto_recibido As CampoDecimal

                    ''' <summary>
                    ''' INDICA EL NUMERO DE LA FORMA DE PAGO
                    ''' NUMERO DE CHEQUE/NUMERO DE CTA ETC
                    ''' </summary>
                    Protected Friend Property c_Numero() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreAgencia() As CampoTexto
                        Get
                            Return f_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_agencia = value
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

                    Protected Friend Property c_CodigoTipoPago() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoRecibo() As CampoTexto
                        Get
                            Return f_auto_recibo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_recibo = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreTipoPago() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoTipoPago() As CampoTexto
                        Get
                            Return f_auto_medios_pago
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_medios_pago = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoAgencia() As CampoTexto
                        Get
                            Return f_auto_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_agencia = value
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

                    Protected Friend Property c_EstatusMovimiento() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    Protected Friend Property c_MontoRecibido() As CampoDecimal
                        Get
                            Return f_monto_recibido
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto_recibido = value
                        End Set
                    End Property

                    ReadOnly Property _Numero() As String
                        Get
                            Return c_Numero.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreAgencia() As String
                        Get
                            Return c_NombreAgencia.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _MontoImporte() As Decimal
                        Get
                            Return c_MontoImporte.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoTipoPago() As String
                        Get
                            Return c_CodigoTipoPago.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoRecibo() As String
                        Get
                            Return c_AutoRecibo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreTipoPago() As String
                        Get
                            Return c_NombreTipoPago.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoTipoPago() As String
                        Get
                            Return c_AutoTipoPago.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoAgencia() As String
                        Get
                            Return c_AutoAgencia.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return c_FechaEmision.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EstatusMovimiento() As TipoEstatus
                        Get
                            Select Case c_EstatusMovimiento.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _MontoRecibido() As Decimal
                        Get
                            Return c_MontoRecibido.c_Valor
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Numero = New CampoTexto(15, "numero")
                        c_NombreAgencia = New CampoTexto(50, "agencia")
                        c_MontoImporte = New CampoDecimal("importe")
                        c_CodigoTipoPago = New CampoTexto(2, "codigo")
                        c_AutoRecibo = New CampoTexto(10, "auto_recibo")
                        c_NombreTipoPago = New CampoTexto(20, "nombre")
                        c_AutoTipoPago = New CampoTexto(10, "auto_medios_pago")
                        c_AutoAgencia = New CampoTexto(10, "auto_agencia")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_EstatusMovimiento = New CampoTexto(1, "estatus")
                        c_MontoRecibido = New CampoDecimal("monto_recibido")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoAgencia.c_Texto = xrow(.c_AutoAgencia.c_NombreInterno)
                                .c_AutoRecibo.c_Texto = xrow(.c_AutoRecibo.c_NombreInterno)
                                .c_AutoTipoPago.c_Texto = xrow(.c_AutoTipoPago.c_NombreInterno)
                                .c_CodigoTipoPago.c_Texto = xrow(.c_CodigoTipoPago.c_NombreInterno)
                                .c_EstatusMovimiento.c_Texto = xrow(.c_EstatusMovimiento.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_MontoImporte.c_Valor = xrow(.c_MontoImporte.c_NombreInterno)
                                .c_MontoRecibido.c_Valor = xrow(.c_MontoRecibido.c_NombreInterno)
                                .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)
                                .c_NombreTipoPago.c_Texto = xrow(.c_NombreTipoPago.c_NombreInterno)
                                .c_Numero.c_Texto = xrow(.c_Numero.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXC MODO PAGO" + vbCrLf + "CARGAR REGISTRO:" + vbCrLf + ex.Message)
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
            End Class

            Class c_MovimientosEntrada
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_cxc As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_fecha_emision As CampoFecha
                    Private f_fecha_vencimiento As CampoFecha
                    Private f_nombre As CampoTexto
                    Private f_dir_fiscal As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_tipo_documento As CampoTexto
                    Private f_nota As CampoTexto
                    Private f_auto_cliente As CampoTexto
                    Private f_codigo_cliente As CampoTexto
                    Private f_dias_credito As CampoInteger
                    Private f_estatus As CampoTexto
                    Private f_aplica As CampoTexto
                    Private f_total As CampoDecimal
                    Private f_telefono As CampoTexto
                    Private f_tipo_entrada As CampoTexto
                    Private f_autoagencia As CampoTexto
                    Private f_nombreagencia As CampoTexto
                    Private f_numeroplanilla As CampoTexto
                    Private f_fechadevolucion As CampoFecha

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

                    Protected Friend Property c_AutoCxC() As CampoTexto
                        Get
                            Return f_auto_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cxc = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCxC() As String
                        Get
                            Return Me.c_AutoCxC.c_Texto.Trim
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
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FechaProceso.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha_emision
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_emision = value
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
                            Return f_tipo_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_documento = value
                        End Set
                    End Property

                    ReadOnly Property _TipoDocumento() As TipoDocumentoMovEntradaCxC
                        Get
                            Select Case Me.c_TipoDocumento.c_Texto.Trim.ToUpper
                                Case "FAC" : Return TipoDocumentoMovEntradaCxC.Factura
                                Case "ND", "NDF" : Return TipoDocumentoMovEntradaCxC.NotaDebito
                                Case "NC", "NCF" : Return TipoDocumentoMovEntradaCxC.NotaCredito
                                Case "CHD" : Return TipoDocumentoMovEntradaCxC.ChequeDevuelto
                                Case "PRE" : Return TipoDocumentoMovEntradaCxC.Prestamo
                                Case "ANT" : Return TipoDocumentoMovEntradaCxC.Anticipos
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

                    Protected Friend Property c_AutoCliente() As CampoTexto
                        Get
                            Return f_auto_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cliente = value
                        End Set
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Return Me.c_AutoCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoCliente() As CampoTexto
                        Get
                            Return f_codigo_cliente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_cliente = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoCliente() As String
                        Get
                            Return Me.c_CodigoCliente.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_DiasCreditoCliente() As CampoInteger
                        Get
                            Return f_dias_credito
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_credito = value
                        End Set
                    End Property

                    ReadOnly Property _DiasCreditoOtorgado() As Integer
                        Get
                            Return Me.c_DiasCreditoCliente.c_Valor
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

                    Protected Friend Property c_TipoEntrada() As CampoTexto
                        Get
                            Return f_tipo_entrada
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _TipoEntrada() As TipoEntradaMovEntradaCxC
                        Get
                            Select Case Me.c_TipoEntrada.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEntradaMovEntradaCxC.PropiaDelSistema
                                Case "1" : Return TipoEntradaMovEntradaCxC.EntradaExterna
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


                    Sub New()
                        f_auto = New CampoTexto(10, "auto")
                        f_auto_cxc = New CampoTexto(10, "auto_cxc")
                        f_tipo_documento = New CampoTexto(10, "tipo_documento")
                        f_documento = New CampoTexto(10, "documento")
                        f_fecha = New CampoFecha("fecha")
                        f_fecha_emision = New CampoFecha("fecha_emision")
                        f_fecha_vencimiento = New CampoFecha("fecha_vencimiento")
                        f_nombre = New CampoTexto(120, "nombre")
                        f_dir_fiscal = New CampoTexto(120, "dir_fiscal")
                        f_ci_rif = New CampoTexto(12, "ci_rif")
                        f_total = New CampoDecimal("total")
                        f_nota = New CampoTexto(120, "nota")
                        f_auto_cliente = New CampoTexto(10, "auto_cliente")
                        f_codigo_cliente = New CampoTexto(15, "codigo_cliente")
                        f_dias_credito = New CampoInteger("dias_credito")
                        f_estatus = New CampoTexto(1, "estatus")
                        f_aplica = New CampoTexto(10, "aplica")
                        f_telefono = New CampoTexto(50, "telefono")
                        f_tipo_entrada = New CampoTexto(1, "tipo_entrada")
                        f_autoagencia = New CampoTexto(10, "autoagencia")
                        f_nombreagencia = New CampoTexto(40, "nombreagencia")
                        f_numeroplanilla = New CampoTexto(10, "numeroplanilla")
                        f_fechadevolucion = New CampoFecha("fechadevolucion")

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
                                .c_AutoCxC.c_Texto = xrow(c_AutoCxC.c_NombreInterno)
                                .c_Documento.c_Texto = xrow(.c_Documento.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_FechaVencimiento.c_Valor = xrow(.c_FechaVencimiento.c_NombreInterno)
                                .c_NombreCliente.c_Texto = xrow(.c_NombreCliente.c_NombreInterno)
                                .c_DirFiscalCliente.c_Texto = xrow(.c_DirFiscalCliente.c_NombreInterno)
                                .c_CiRifCliente.c_Texto = xrow(.c_CiRifCliente.c_NombreInterno)
                                .c_TipoDocumento.c_Texto = xrow(.c_TipoDocumento.c_NombreInterno)
                                .c_TotalGeneral.c_Valor = xrow(.c_TotalGeneral.c_NombreInterno)
                                .c_NotasDocumento.c_Texto = xrow(.c_NotasDocumento.c_NombreInterno)
                                .c_AutoCliente.c_Texto = xrow(.c_AutoCliente.c_NombreInterno)
                                .c_CodigoCliente.c_Texto = xrow(.c_CodigoCliente.c_NombreInterno)
                                .c_DiasCreditoCliente.c_Valor = xrow(.c_DiasCreditoCliente.c_NombreInterno)
                                .c_EstatusDocumento.c_Texto = xrow(.c_EstatusDocumento.c_NombreInterno)
                                .c_DocumentoAplica.c_Texto = xrow(.c_DocumentoAplica.c_NombreInterno)
                                .c_TelefonoCliente.c_Texto = xrow(.c_TelefonoCliente.c_NombreInterno)
                                .c_TipoEntrada.c_Texto = xrow(.c_TipoEntrada.c_NombreInterno)
                                .c_AutoAgencia.c_Texto = xrow(.c_AutoAgencia.c_NombreInterno)
                                .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)
                                .c_NumeroPlanilla.c_Texto = xrow(.c_NumeroPlanilla.c_NombreInterno)
                                .c_FechaDevolucion.c_Valor = xrow(.c_FechaDevolucion.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("CXC MOVIMIENTO DE ENTRADA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarMovimientoEntrada
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

                    WriteOnly Property _DocumentoAplica() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_DocumentoAplica.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TipoDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NotasDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NotasDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoCliente.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoCliente.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DiasCreditoOtorgado() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_DiasCreditoCliente.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TipoEntrada() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_TipoEntrada.c_Texto = value
                        End Set
                    End Property

                    Dim xresta As Decimal = 0

                    Property _MontoPorCobrar() As Decimal
                        Get
                            Return xresta
                        End Get
                        Set(ByVal value As Decimal)
                            xresta = value
                        End Set
                    End Property

                    WriteOnly Property _TotalGeneral() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TotalGeneral.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TelefonoCliente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TelefonoCliente.c_Texto = value
                        End Set
                    End Property
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
                            xadap.SelectCommand.CommandText = "select * from cxc_movimientos_entrada where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto).Size = Me.RegistroDato.c_Auto.c_Largo
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count = 0 Then
                            Throw New Exception("MOVIMIENTO DE ENTRADA EN CXC NO ENCONTRADO")
                        End If
                        Me.RegistroDato.CargarRegistro(xtb(0))
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Private xcxc As c_CxC
            Private xrecibos As c_Recibos
            Private xdocumentos As c_Documentos
            Private xmovimientosentrada As c_MovimientosEntrada
            Private xmodopago As c_ModosPago

            Property f_CxC() As c_CxC
                Get
                    Return Me.xcxc
                End Get
                Set(ByVal value As c_CxC)
                    Me.xcxc = value
                End Set
            End Property

            Property f_Recibos() As c_Recibos
                Get
                    Return Me.xrecibos
                End Get
                Set(ByVal value As c_Recibos)
                    Me.xrecibos = value
                End Set
            End Property

            Property f_Documentos() As c_Documentos
                Get
                    Return Me.xdocumentos
                End Get
                Set(ByVal value As c_Documentos)
                    Me.xdocumentos = value
                End Set
            End Property

            Property f_MovimientosEntrada() As c_MovimientosEntrada
                Get
                    Return Me.xmovimientosentrada
                End Get
                Set(ByVal value As c_MovimientosEntrada)
                    Me.xmovimientosentrada = value
                End Set
            End Property

            Property f_ModosPago() As c_ModosPago
                Get
                    Return Me.xmodopago
                End Get
                Set(ByVal value As c_ModosPago)
                    Me.xmodopago = value
                End Set
            End Property

            Sub New()
                Me.f_CxC = New c_CxC
                Me.f_Recibos = New c_Recibos
                Me.f_Documentos = New c_Documentos
                Me.f_MovimientosEntrada = New c_MovimientosEntrada
                Me.f_ModosPago = New c_ModosPago
            End Sub

#Region "Instrucciones SQL"
            Protected Friend Const INSERT_CXC As String = "INSERT cxc (" _
               + "auto," _
               + "auto_mov_entrada," _
               + "fecha," _
               + "tipo_documento," _
               + "documento," _
               + "fecha_vencimiento," _
               + "detalle," _
               + "importe," _
               + "acumulado," _
               + "auto_cliente," _
               + "cliente," _
               + "ci_rif," _
               + "codigo_cliente," _
               + "cancelado," _
               + "resta," _
               + "operacion," _
               + "estatus," _
               + "auto_documento," _
               + "numero," _
               + "auto_agencia," _
               + "agencia," _
               + "signo," _
               + "fecha_emision) " _
               + "VALUES (" _
               + "@auto," _
               + "@auto_mov_entrada," _
               + "@fecha," _
               + "@tipo_documento," _
               + "@documento," _
               + "@fecha_vencimiento," _
               + "@detalle," _
               + "@importe," _
               + "@acumulado," _
               + "@auto_cliente," _
               + "@cliente," _
               + "@ci_rif," _
               + "@codigo_cliente," _
               + "@cancelado," _
               + "@resta," _
               + "@operacion," _
               + "@estatus," _
               + "@auto_documento," _
               + "@numero," _
               + "@auto_agencia," _
               + "@agencia," _
               + "@signo," _
               + "@fecha_emision) "

            Protected Friend Const INSERT_CXC_CHEQUE_DEVUELTO As String = "INSERT cxc (" _
               + "auto," _
               + "auto_mov_entrada," _
               + "fecha," _
               + "tipo_documento," _
               + "documento," _
               + "fecha_vencimiento," _
               + "detalle," _
               + "importe," _
               + "acumulado," _
               + "auto_cliente," _
               + "cliente," _
               + "ci_rif," _
               + "codigo_cliente," _
               + "cancelado," _
               + "resta," _
               + "operacion," _
               + "estatus," _
               + "auto_documento," _
               + "numero," _
               + "auto_agencia," _
               + "agencia," _
               + "signo," _
               + "fecha_recepcion_devolucion," _
               + "fecha_emision) " _
               + "VALUES (" _
               + "@auto," _
               + "@auto_mov_entrada," _
               + "@fecha," _
               + "@tipo_documento," _
               + "@documento," _
               + "@fecha_vencimiento," _
               + "@detalle," _
               + "@importe," _
               + "@acumulado," _
               + "@auto_cliente," _
               + "@cliente," _
               + "@ci_rif," _
               + "@codigo_cliente," _
               + "@cancelado," _
               + "@resta," _
               + "@operacion," _
               + "@estatus," _
               + "@auto_documento," _
               + "@numero," _
               + "@auto_agencia," _
               + "@agencia," _
               + "@signo," _
               + "@fecha_recepcion_devolucion," _
               + "@fecha_emision) "

            Protected Friend Const _INSERT_CXC_RECIBOS As String = "INSERT INTO cxc_recibos (" _
               + "auto," _
               + "numero," _
               + "fecha," _
               + "auto_usuario," _
               + "importe," _
               + "usuario," _
               + "importe_documentos," _
               + "descuentos," _
               + "total_documentos," _
               + "detalle," _
               + "cobrador," _
               + "auto_cliente," _
               + "nombre_cliente," _
               + "ci_rif_cliente," _
               + "codigo_cliente," _
               + "estatus," _
               + "direccion," _
               + "telefono," _
               + "auto_cobrador," _
               + "anticipos," _
               + "cant_doc_rel, monto_nc_pagadas, cant_nc_pagadas, auto_cxc) " _
               + "VALUES (" _
               + "@auto," _
               + "@numero," _
               + "@fecha," _
               + "@auto_usuario," _
               + "@importe," _
               + "@usuario," _
               + "@importe_documentos," _
               + "@descuentos," _
               + "@total_documentos," _
               + "@detalle," _
               + "@cobrador," _
               + "@auto_cliente," _
               + "@nombre_cliente," _
               + "@ci_rif_cliente," _
               + "@codigo_cliente," _
               + "@estatus," _
               + "@direccion," _
               + "@telefono," _
               + "@auto_cobrador," _
               + "@anticipos," _
               + "@cant_doc_rel, @monto_nc_pagadas, @cant_nc_pagadas, @auto_cxc)"

            Protected Friend Const INSERT_CXC_DOCUMENTOS As String = "INSERT INTO cxc_documentos (" _
               + "item," _
               + "operacion," _
               + "monto," _
               + "auto_cxc," _
               + "documento," _
               + "auto_cxc_pago," _
               + "tipo," _
               + "fecha," _
               + "detalle," _
               + "auto_cxc_recibo," _
               + "numero_recibo," _
               + "origen, " _
               + "monto_pendiente,signo) " _
               + "VALUES (" _
               + "@item," _
               + "@operacion," _
               + "@monto," _
               + "@auto_cxc," _
               + "@documento," _
               + "@auto_cxc_pago," _
               + "@tipo," _
               + "@fecha," _
               + "@detalle," _
               + "@auto_cxc_recibo," _
               + "@numero_recibo," _
               + "@origen, " _
               + "@monto_pendiente,@signo) "

            Protected Friend Const INSERT_CXC_MODO_PAGO As String = "INSERT INTO cxc_modo_pago (" _
               + "numero," _
               + "agencia," _
               + "importe," _
               + "codigo," _
               + "auto_recibo," _
               + "nombre," _
               + "auto_medios_pago," _
               + "auto_agencia," _
               + "fecha," _
               + "estatus," _
               + "monto_recibido) " _
               + "VALUES (" _
               + "@numero," _
               + "@agencia," _
               + "@importe," _
               + "@codigo," _
               + "@auto_recibo," _
               + "@nombre," _
               + "@auto_medios_pago," _
               + "@auto_agencia," _
               + "@fecha," _
               + "@estatus," _
               + "@monto_recibido)"

            Protected Friend Const INSERT_CXC_MOVIMIENTOS_ENTRADA As String = "insert cxc_movimientos_entrada (" _
               + "auto," _
               + "auto_cxc," _
               + "documento," _
               + "fecha," _
               + "fecha_emision," _
               + "fecha_vencimiento," _
               + "nombre," _
               + "dir_fiscal," _
               + "ci_rif," _
               + "tipo_documento," _
               + "total," _
               + "nota," _
               + "auto_cliente," _
               + "codigo_cliente," _
               + "dias_credito," _
               + "estatus," _
               + "aplica," _
               + "telefono," _
               + "tipo_entrada," _
               + "autoagencia," _
               + "nombreagencia," _
               + "numeroplanilla," _
               + "fechadevolucion) " _
               + "VALUES (" _
               + "@auto," _
               + "@auto_cxc," _
               + "@documento," _
               + "@fecha," _
               + "@fecha_emision," _
               + "@fecha_vencimiento," _
               + "@nombre," _
               + "@dir_fiscal," _
               + "@ci_rif," _
               + "@tipo_documento," _
               + "@total," _
               + "@nota," _
               + "@auto_cliente," _
               + "@codigo_cliente," _
               + "@dias_credito," _
               + "@estatus," _
               + "@aplica," _
               + "@telefono," _
               + "@tipo_entrada," _
               + "@autoagencia," _
               + "@nombreagencia," _
               + "@numeroplanilla," _
               + "@fechadevolucion) "

#End Region

#Region "Funciones"
            ''' <summary>
            ''' PERMITE ANULAR UN DOCUMENTO DE CUENTAS POR COBRAR
            ''' </summary>
            Function F_AnularDocumento(ByVal xanulardoc As c_CxC.c_AnularDocumentoCxC) As Boolean
                Dim xsql1 As String = "update contadores set a_documentos_anulados=a_documentos_anulados+1;select a_documentos_anulados from contadores"
                Dim xr As Integer = 0
                Dim xtr As SqlTransaction = Nothing

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                xcommand.CommandText = xsql1
                                xanulardoc._DocumentoAnular.RegistroDato.c_AutoAnulacion.c_Texto = xcommand.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                'REGISTRAR DOCUMENTO ANULADO
                                With xanulardoc._DocumentoAnular.RegistroDato
                                    .c_AutoDocumento.c_Texto = xanulardoc._FichaRegistroCxc._AutoCxC
                                    .c_CodigoAnulacion.c_Texto = "0401"
                                End With

                                'GRABAR DOCUMENTO ANULADO
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = FichaGlobal.c_DocumentosAnulados.InsertSql
                                xcommand.Parameters.AddWithValue("@codigo", xanulardoc._DocumentoAnular.RegistroDato.c_CodigoAnulacion.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_CodigoAnulacion.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xanulardoc._DocumentoAnular.RegistroDato.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@hora", xanulardoc._DocumentoAnular.RegistroDato.c_HoraAnulacion.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_HoraAnulacion.c_Largo
                                xcommand.Parameters.AddWithValue("@detalle", xanulardoc._DocumentoAnular.RegistroDato.c_NotaDetalleAnulacion.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_NotaDetalleAnulacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estacion", xanulardoc._DocumentoAnular.RegistroDato.c_NombreEstacion.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_NombreEstacion.c_Largo
                                xcommand.Parameters.AddWithValue("@usuario", xanulardoc._DocumentoAnular.RegistroDato.c_NombreUsuario.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_NombreUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_usuario", xanulardoc._DocumentoAnular.RegistroDato.c_CodigoUsuario.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_CodigoUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@auto", xanulardoc._DocumentoAnular.RegistroDato.c_AutoAnulacion.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_AutoAnulacion.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xanulardoc._DocumentoAnular.RegistroDato.c_AutoDocumento.c_Texto).Size = xanulardoc._DocumentoAnular.RegistroDato.c_AutoDocumento.c_Largo
                                xcommand.ExecuteNonQuery()

                                ' ES UN DOCUMENTO TIPO PAGO
                                If xanulardoc._FichaRegistroCxc._TipoDocumento = "PAG" Then
                                    xr = 0
                                    'VERIFICA SI ES UN PAGO DE RETENCION DE IVA , EN CASE DE SER ASI, ERROR
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "select count(*) from cxc_modo_pago where auto_recibo=@auto_recibo and auto_medios_pago='RVI0000001'"
                                    xcommand.Parameters.AddWithValue("@auto_recibo", xanulardoc._AutoReciboCxc).Size = Me.f_ModosPago.RegistroDato.c_AutoRecibo.c_Largo
                                    xr = xcommand.ExecuteScalar
                                    If xr > 0 Then
                                        Throw New Exception("EL DOCUMENTO ESTA RELACIONADO CON UNA RETENCIÓN. NO SE PUEDE ANULAR")
                                    End If

                                    'ACTUALIZAR DOCUMENTOS DE PAGO DE CUENTAS POR COBRAR
                                    xr = 0
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc set estatus='1' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCxC).Size = xanulardoc._FichaRegistroCxc.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@id_seguridad", xanulardoc._FichaRegistroCxc._IdSeguridad)
                                    xr = xcommand.ExecuteNonQuery
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ANULAR DOCUMENTO, EL DOCUMENTO HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                    End If

                                    'ACTUALIZAR ESTATUS EN MODO DE PAGO EN 1 (ANULADO) 
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc_modo_pago set estatus='1' where auto_recibo=@auto_recibo"
                                    xcommand.Parameters.AddWithValue("@auto_recibo", xanulardoc._AutoReciboCxc).Size = Me.f_ModosPago.RegistroDato.c_AutoRecibo.c_Largo
                                    xcommand.ExecuteNonQuery()

                                    'ACTUALIZAR ESTATUS EN RECIBO EN 1 (ANULADO) 
                                    Dim xanticipo As Decimal = 0
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc_recibos set estatus='1' where auto=@auto; select anticipos from cxc_recibos where auto=@auto"
                                    xcommand.Parameters.AddWithValue("@auto", xanulardoc._AutoReciboCxc).Size = Me.f_ModosPago.RegistroDato.c_AutoRecibo.c_Largo
                                    xanticipo = xcommand.ExecuteScalar

                                    If xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada <> "" Then
                                        If xanticipo > 0 Then
                                            xanticipo *= -1
                                        End If
                                        'ACTUALIZAR ESTATUS EN MOVIMIENTO_ENTRADA EN 1 (ANULADO) 
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update cxc_movimientos_entrada set estatus='1' where auto=@auto"
                                        xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada).Size = Me.f_MovimientosEntrada.RegistroDato.c_Auto.c_Largo
                                        xcommand.ExecuteNonQuery()
                                    End If

                                    If Math.Abs(xanticipo) > 0 Then
                                        'ACTUALIZAR ANTICIPO DEL CLIENTE
                                        xr = 0
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update clientes set total_anticipos=total_anticipos+@anticipo where auto=@auto and (total_anticipos+@anticipo)>=0"
                                        xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                        xcommand.Parameters.AddWithValue("@anticipo", xanticipo)
                                        xr = xcommand.ExecuteNonQuery
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL ANULAR DOCUMENTO, ESTE ANTICIPO HA SIDO UTILIZADO. ANULE PRIMERO LOS MOVIMIENTOS DEL ANTICIPO")
                                        End If
                                    End If

                                    'ACTUALIZAR DOCUMENTOS DE CUENTAS POR COBRAR
                                    For Each xrow In xanulardoc._ListaDocumentos
                                        Dim x_cxc As New c_CxC
                                        Dim xsigno As Integer = 1
                                        Dim f_data As New DataTable
                                        Dim f_reader As SqlDataReader

                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "select * from cxc where auto=@auto"
                                        xcommand.Parameters.AddWithValue("@auto", xrow._AutoCxC)
                                        f_reader = xcommand.ExecuteReader()
                                        f_data.Load(f_reader)
                                        x_cxc.M_CargarRegistro(f_data.Rows(0))

                                        If x_cxc.RegistroDato._TipoDocumento = "NCF" Or x_cxc.RegistroDato._TipoDocumento = "NC" Then
                                            xsigno = -1
                                        End If

                                        With x_cxc
                                            .RegistroDato.c_MontoAcumulado.c_Valor -= xrow._Monto * xsigno
                                            .RegistroDato.c_MontoPorCobrar.c_Valor += xrow._Monto * xsigno
                                            If .RegistroDato.c_MontoPorCobrar.c_Valor = 0 Then
                                                .RegistroDato.c_EstatusCancelado.c_Texto = "1"
                                            Else
                                                .RegistroDato.c_EstatusCancelado.c_Texto = "0"
                                            End If
                                        End With

                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update cxc set acumulado=@acumulado, resta=@resta, cancelado=@cancelado where auto=@auto"
                                        xcommand.Parameters.AddWithValue("@auto", x_cxc.RegistroDato._AutoCxC).Size = x_cxc.RegistroDato.c_AutoCxC.c_Largo
                                        xcommand.Parameters.AddWithValue("@acumulado", x_cxc.RegistroDato._MontoAcumulado)
                                        xcommand.Parameters.AddWithValue("@resta", x_cxc.RegistroDato._MontoPorCobrar)
                                        xcommand.Parameters.AddWithValue("@cancelado", x_cxc.RegistroDato.c_EstatusCancelado.c_Texto).Size = x_cxc.RegistroDato.c_EstatusCancelado.c_Largo
                                        xcommand.ExecuteNonQuery()

                                        If x_cxc.RegistroDato._AutoMovimientoBanco <> "" Then
                                            Dim xr_banco As Integer = 0
                                            xcommand.Parameters.Clear()
                                            xcommand.CommandText = "update movimientos set estatus_operacion='0' where auto=@auto_movimiento"
                                            xcommand.Parameters.AddWithValue("@auto_movimiento", x_cxc.RegistroDato._AutoMovimientoBanco)
                                            xr_banco = xcommand.ExecuteNonQuery()
                                            If xr_banco = 0 Then
                                                Throw New Exception("ERROR AL ACTUALIZAR EN TABLA MOVIMIENTOS: CHEQUE PAGADO - PARA BANCO")
                                            End If
                                        End If
                                    Next

                                    ' ES UN DOCUMENTO TIPO ANTICIPO
                                ElseIf xanulardoc._FichaRegistroCxc._TipoDocumentoRegistradoCxC = TipoDocumentoRegistradoCxC.Anticipo Then

                                    'ACTUALIZAR DOCUMENTOS DE PAGO DE CUENTAS POR COBRAR
                                    xr = 0
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc set estatus='1' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCxC).Size = xanulardoc._FichaRegistroCxc.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@id_seguridad", xanulardoc._FichaRegistroCxc._IdSeguridad)
                                    xr = xcommand.ExecuteNonQuery
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ANULAR DOCUMENTO, EL DOCUMENTO HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                    End If

                                    'ACTUALIZAR ESTATUS EN MODO DE PAGO EN 1 (ANULADO) 
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc_modo_pago set estatus='1' where auto_recibo=@auto_recibo"
                                    xcommand.Parameters.AddWithValue("@auto_recibo", xanulardoc._AutoReciboCxc).Size = Me.f_ModosPago.RegistroDato.c_AutoRecibo.c_Largo
                                    xcommand.ExecuteNonQuery()

                                    'ACTUALIZAR ESTATUS EN RECIBO EN 1 (ANULADO) 
                                    Dim xanticipo As Decimal = 0
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc_recibos set estatus='1' where auto=@auto; select anticipos from cxc_recibos where auto=@auto"
                                    xcommand.Parameters.AddWithValue("@auto", xanulardoc._AutoReciboCxc).Size = Me.f_ModosPago.RegistroDato.c_AutoRecibo.c_Largo
                                    xanticipo = xcommand.ExecuteScalar

                                    If xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada <> "" Then
                                        If xanticipo > 0 Then
                                            xanticipo *= -1
                                        End If
                                        'ACTUALIZAR ESTATUS EN MOVIMIENTO_ENTRADA EN 1 (ANULADO) 
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update cxc_movimientos_entrada set estatus='1' where auto=@auto"
                                        xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada).Size = Me.f_MovimientosEntrada.RegistroDato.c_Auto.c_Largo
                                        xcommand.ExecuteNonQuery()
                                    End If

                                    If Math.Abs(xanticipo) > 0 Then
                                        'ACTUALIZAR ANTICIPO DEL CLIENTE
                                        xr = 0
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update clientes set total_anticipos=total_anticipos+@anticipo where auto=@auto and (total_anticipos+@anticipo)>=0"
                                        xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                        xcommand.Parameters.AddWithValue("@anticipo", xanticipo)
                                        xr = xcommand.ExecuteNonQuery
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL ANULAR DOCUMENTO, ESTE ANTICIPO HA SIDO UTILIZADO. ANULE PRIMERO LOS MOVIMIENTOS DEL ANTICIPO")
                                        End If
                                    End If

                                ElseIf xanulardoc._FichaRegistroCxc._TipoDocumentoRegistradoCxC = TipoDocumentoRegistradoCxC.NotaCredito _
                                And xanulardoc._FichaRegistroCxc._AutoDocumentoRetencion <> "" Then
                                    Throw New Exception("DOCUMENTO NO PUEDE SER ANULADO, DICHO DOCUMENTO PERTENECE A UNA RETENCION REALIZADA")

                                Else
                                    If Math.Abs(xanulardoc._FichaRegistroCxc._MontoAcumulado) > 0 Then
                                        Throw New Exception("ERROR, ESTE DOCUMENTO POSEE MOVIMIENTOS. ANULE PRIMERO LOS MOVIMIENTOS DEL DOCUMENTO.")
                                    End If

                                    'ACTUALIZAR DOCUMENTO EN CUENTAS POR COBRAR
                                    xr = 0
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "update cxc set estatus='1' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCxC).Size = xanulardoc._FichaRegistroCxc.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@id_seguridad", xanulardoc._FichaRegistroCxc._IdSeguridad)
                                    xr = xcommand.ExecuteNonQuery
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ANULAR DOCUMENTO, EL DOCUMENTO HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                    End If

                                    If xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada <> "" Then
                                        'ACTUALIZAR ESTATUS EN MOVIMIENTO_ENTRADA EN 1 (ANULADO) 
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update cxc_movimientos_entrada set estatus='1' where auto=@auto"
                                        xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoMovimientoEntrada).Size = Me.f_MovimientosEntrada.RegistroDato.c_Auto.c_Largo
                                        xcommand.ExecuteNonQuery()
                                    End If
                                End If

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xanulardoc._FichaRegistroCxc._AutoCliente).Size = xanulardoc._FichaRegistroCxc.c_AutoCliente.c_Largo
                                xcommand.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent DocumentoProcesado()
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ANULAR DOCUMENTO" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' PERMITE PROCESAR UN CHEQUE DEVUELTO
            ''' </summary>
            ''' <param name="xagregar"></param>
            ''' CLASE PARA PROCESAR EL CHEQUE DEVUELTO            
            Function F_GrabarChequeDevuelto(ByVal xagregar As c_CxC.c_AgregarChequeDevuelto) As Boolean
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql2 As String = "update contadores set a_cxc_chd=a_cxc_chd+1; select a_cxc_chd from contadores"
                Dim xsql3 As String = "update contadores set a_cxc_nd=a_cxc_nd+1; select a_cxc_nd from contadores"
                Dim xsql4 As String = "update contadores set a_cxc_movimientos_entrada=a_cxc_movimientos_entrada+1; select a_cxc_movimientos_entrada from contadores"

                Dim xauto_1 As String = ""
                Dim xauto_2 As String = ""
                Dim xauto_3 As String = ""
                Dim xauto_4 As String = ""
                Dim xaplica As String = ""

                Dim xobj As Object = Nothing
                Dim xtr As SqlTransaction = Nothing

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC
                                xcommand.CommandText = xsql1
                                xauto_1 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES NUMERO CHEQUE DEVUELTO
                                xcommand.CommandText = xsql2
                                xauto_2 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                xaplica = xauto_2

                                'CONTADORES MOVIMIENTO DE ENTRADA
                                xcommand.CommandText = "select a_cxc_movimientos_entrada from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_movimientos_entrada=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql4
                                xauto_3 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'GRABAR CHEQUE DEVUELTO EN CXC
                                Dim xcxc As New FichaCtasCobrar.c_CxC.c_Registro
                                With xcxc
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_AutoAgencia.c_Texto = xagregar._FichaAgencia._Automatico
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto_3
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xagregar._FechaDevolucion
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xagregar._MontoCheque
                                    .c_MontoPorCobrar.c_Valor = xagregar._MontoCheque
                                    .c_NombreAgencia.c_Texto = xagregar._FichaAgencia._NombreAgencia
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xagregar._NotasDetalle
                                    .c_Numero.c_Texto = xagregar._NumeroCheque
                                    .c_NumeroDocumento.c_Texto = xauto_2
                                    .c_TipoDocumento.c_Texto = "CHD"
                                    .c_TipoMovimiento.c_Valor = 1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                xcommand.CommandText = INSERT_CXC_CHEQUE_DEVUELTO
                                xcommand.Parameters.AddWithValue("@auto", xcxc.c_AutoCxC.c_Texto).Size = xcxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xcxc.c_AutoMovimientoEntrada.c_Texto).Size = xcxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xcxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xcxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xcxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xcxc.c_TipoDocumento.c_Texto).Size = xcxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xcxc.c_NumeroDocumento.c_Texto).Size = xcxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xcxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xcxc.c_NotasDetalles.c_Texto).Size = xcxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xcxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xcxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xcxc.c_AutoCliente.c_Texto).Size = xcxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xcxc.c_NombreCliente.c_Texto).Size = xcxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xcxc.c_CiRifCliente.c_Texto).Size = xcxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xcxc.c_CodigoCliente.c_Texto).Size = xcxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xcxc.c_EstatusCancelado.c_Texto).Size = xcxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xcxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xcxc.c_TipoOperacion.c_Texto).Size = xcxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xcxc.c_EstatusDocumentoCxC.c_Texto).Size = xcxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xcxc.c_AutoDocumento.c_Texto).Size = xcxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xcxc.c_Numero.c_Texto).Size = xcxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xcxc.c_AutoAgencia.c_Texto).Size = xcxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xcxc.c_NombreAgencia.c_Texto).Size = xcxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xcxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'AGREGAR MOVIMIENTO DE ENTRADA
                                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto_3
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoAgencia.c_Texto = xagregar._FichaAgencia._Automatico
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_DiasCreditoCliente.c_Valor = 0
                                    .c_DirFiscalCliente.c_Texto = xagregar._FichaCliente.r_DirFiscal
                                    .c_Documento.c_Texto = xauto_2
                                    .c_DocumentoAplica.c_Texto = ""
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaDevolucion.c_Valor = xagregar._FechaDevolucion
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_NombreAgencia.c_Texto = xagregar._FichaAgencia._NombreAgencia
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = xagregar._NumeroCheque
                                    .c_TelefonoCliente.c_Texto = xagregar._FichaCliente.r_Telefono_1
                                    .c_TipoDocumento.c_Texto = "CHD"
                                    .c_TipoEntrada.c_Texto = "0"
                                    .c_TotalGeneral.c_Valor = xagregar._MontoCheque
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcommand.ExecuteNonQuery()

                                If xagregar._ComisionCheque > 0 Then
                                    xauto_1 = ""
                                    xauto_2 = ""
                                    xauto_3 = ""
                                    xauto_4 = ""

                                    xcommand.CommandText = xsql1
                                    xauto_1 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0") 'CXC
                                    xcommand.CommandText = xsql3
                                    xauto_2 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0") 'ND
                                    xcommand.CommandText = xsql4
                                    xauto_3 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0") 'MOV ENTRADA

                                    'CXC
                                    With xcxc
                                        .LimpiarRegistro()

                                        .c_AutoCxC.c_Texto = xauto_1
                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                        .c_AutoDocumento.c_Texto = ""
                                        .c_AutoMovimientoEntrada.c_Texto = xauto_3
                                        .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                        .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                        .c_EstatusCancelado.c_Texto = "0"
                                        .c_EstatusDocumentoCxC.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                        .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                        .c_FechaRecepcionDevolucion.c_Valor = xagregar._FechaProceso
                                        .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                        .c_MontoAcumulado.c_Valor = 0
                                        .c_MontoImporte.c_Valor = xagregar._ComisionCheque
                                        .c_MontoPorCobrar.c_Valor = xagregar._ComisionCheque
                                        .c_NombreAgencia.c_Texto = ""
                                        .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                        .c_NotasDetalles.c_Texto = "ND/Comisión Chq.Dev.#" + xagregar._NumeroCheque + "/" + xagregar._FichaAgencia._NombreAgencia
                                        .c_Numero.c_Texto = ""
                                        .c_NumeroDocumento.c_Texto = xauto_2
                                        .c_TipoDocumento.c_Texto = "ND"
                                        .c_TipoMovimiento.c_Valor = 1
                                        .c_TipoOperacion.c_Texto = ""
                                    End With

                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = INSERT_CXC
                                    xcommand.Parameters.AddWithValue("@auto", xcxc.c_AutoCxC.c_Texto).Size = xcxc.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_mov_entrada", xcxc.c_AutoMovimientoEntrada.c_Texto).Size = xcxc.c_AutoMovimientoEntrada.c_Largo
                                    xcommand.Parameters.AddWithValue("@fecha", xcxc.c_FechaProceso.c_Valor)
                                    xcommand.Parameters.AddWithValue("@fecha_emision", xcxc.c_FechaEmision.c_Valor)
                                    xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xcxc.c_FechaRecepcionDevolucion.c_Valor)
                                    xcommand.Parameters.AddWithValue("@tipo_documento", xcxc.c_TipoDocumento.c_Texto).Size = xcxc.c_TipoDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@documento", xcxc.c_NumeroDocumento.c_Texto).Size = xcxc.c_NumeroDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@fecha_vencimiento", xcxc.c_FechaVencimiento.c_Valor)
                                    xcommand.Parameters.AddWithValue("@detalle", xcxc.c_NotasDetalles.c_Texto).Size = xcxc.c_NotasDetalles.c_Largo
                                    xcommand.Parameters.AddWithValue("@importe", xcxc.c_MontoImporte.c_Valor)
                                    xcommand.Parameters.AddWithValue("@acumulado", xcxc.c_MontoAcumulado.c_Valor)
                                    xcommand.Parameters.AddWithValue("@auto_cliente", xcxc.c_AutoCliente.c_Texto).Size = xcxc.c_AutoCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@cliente", xcxc.c_NombreCliente.c_Texto).Size = xcxc.c_NombreCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@ci_rif", xcxc.c_CiRifCliente.c_Texto).Size = xcxc.c_CiRifCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@codigo_cliente", xcxc.c_CodigoCliente.c_Texto).Size = xcxc.c_CodigoCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@cancelado", xcxc.c_EstatusCancelado.c_Texto).Size = xcxc.c_EstatusCancelado.c_Largo
                                    xcommand.Parameters.AddWithValue("@resta", xcxc.c_MontoPorCobrar.c_Valor)
                                    xcommand.Parameters.AddWithValue("@operacion", xcxc.c_TipoOperacion.c_Texto).Size = xcxc.c_TipoOperacion.c_Largo
                                    xcommand.Parameters.AddWithValue("@estatus", xcxc.c_EstatusDocumentoCxC.c_Texto).Size = xcxc.c_EstatusDocumentoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_documento", xcxc.c_AutoDocumento.c_Texto).Size = xcxc.c_AutoDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@numero", xcxc.c_Numero.c_Texto).Size = xcxc.c_Numero.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_agencia", xcxc.c_AutoAgencia.c_Texto).Size = xcxc.c_AutoAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@agencia", xcxc.c_NombreAgencia.c_Texto).Size = xcxc.c_NombreAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@signo", xcxc.c_TipoMovimiento.c_Valor)
                                    xcommand.ExecuteNonQuery()

                                    'MOVIMIENTO ENTRADA CXC
                                    With xagregar_mov
                                        .LimpiarRegistro()

                                        .c_Auto.c_Texto = xauto_3
                                        .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoCxC.c_Texto = xauto_1
                                        .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                        .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                        .c_DiasCreditoCliente.c_Valor = 0
                                        .c_DirFiscalCliente.c_Texto = xagregar._FichaCliente.r_DirFiscal
                                        .c_Documento.c_Texto = xauto_2
                                        .c_DocumentoAplica.c_Texto = xaplica
                                        .c_EstatusDocumento.c_Texto = "0"
                                        .c_FechaDevolucion.c_Valor = xagregar._FechaProceso
                                        .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                        .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                        .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                        .c_NombreAgencia.c_Texto = ""
                                        .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                        .c_NotasDocumento.c_Texto = "ND/Comisión Chq.Dev.#" + xagregar._NumeroCheque + "/" + xagregar._FichaAgencia._NombreAgencia
                                        .c_NumeroPlanilla.c_Texto = ""
                                        .c_TelefonoCliente.c_Texto = xagregar._FichaCliente.r_Telefono_1
                                        .c_TipoDocumento.c_Texto = "NDF"
                                        .c_TipoEntrada.c_Texto = "0"
                                        .c_TotalGeneral.c_Valor = xagregar._ComisionCheque
                                    End With

                                    'GRABAR MOVIMIENTO DE ENTRADA
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                    xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                    xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                    xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                    xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                    xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                    xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                    xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                    xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                    xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                    xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                    xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                    xcommand.ExecuteNonQuery()
                                End If

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xagregar._FichaCliente.r_Automatico)
                                xcommand.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "CHEQUE DEVUELTO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarNotaDebito(ByVal xagregar As c_CxC.c_AgregarNotaDebito) As Boolean
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql3 As String = "update contadores set a_cxc_nd=a_cxc_nd+1; select a_cxc_nd from contadores"
                Dim xsql4 As String = "update contadores set a_cxc_movimientos_entrada=a_cxc_movimientos_entrada+1; select a_cxc_movimientos_entrada from contadores"

                Dim xauto_1 As String = ""
                Dim xauto_2 As String = ""
                Dim xauto_3 As String = ""
                Dim xauto_4 As String = ""

                Dim xobj As Object = Nothing
                Dim xtr As SqlTransaction = Nothing

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC
                                xcommand.CommandText = xsql1
                                xauto_1 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES MOVIMIENTO DE ENTRADA
                                xcommand.CommandText = "select a_cxc_movimientos_entrada from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_movimientos_entrada=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql4
                                xauto_3 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES NOTA DE DEBITO
                                xcommand.CommandText = xsql3
                                xauto_2 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CXC
                                Dim xcxc As New FichaCtasCobrar.c_CxC.c_Registro
                                With xcxc
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto_3
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xagregar._Monto
                                    .c_MontoPorCobrar.c_Valor = xagregar._Monto
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xagregar._NotasDetalle
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xauto_2
                                    .c_TipoDocumento.c_Texto = "ND"
                                    .c_TipoMovimiento.c_Valor = 1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC
                                xcommand.Parameters.AddWithValue("@auto", xcxc.c_AutoCxC.c_Texto).Size = xcxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xcxc.c_AutoMovimientoEntrada.c_Texto).Size = xcxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xcxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xcxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xcxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xcxc.c_TipoDocumento.c_Texto).Size = xcxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xcxc.c_NumeroDocumento.c_Texto).Size = xcxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xcxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xcxc.c_NotasDetalles.c_Texto).Size = xcxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xcxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xcxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xcxc.c_AutoCliente.c_Texto).Size = xcxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xcxc.c_NombreCliente.c_Texto).Size = xcxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xcxc.c_CiRifCliente.c_Texto).Size = xcxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xcxc.c_CodigoCliente.c_Texto).Size = xcxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xcxc.c_EstatusCancelado.c_Texto).Size = xcxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xcxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xcxc.c_TipoOperacion.c_Texto).Size = xcxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xcxc.c_EstatusDocumentoCxC.c_Texto).Size = xcxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xcxc.c_AutoDocumento.c_Texto).Size = xcxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xcxc.c_Numero.c_Texto).Size = xcxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xcxc.c_AutoAgencia.c_Texto).Size = xcxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xcxc.c_NombreAgencia.c_Texto).Size = xcxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xcxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'MOVIMIENTO ENTRADA CXC
                                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                                With xagregar_mov

                                    .c_Auto.c_Texto = xauto_3
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_DiasCreditoCliente.c_Valor = 0
                                    .c_DirFiscalCliente.c_Texto = xagregar._FichaCliente.r_DirFiscal
                                    .c_Documento.c_Texto = xauto_2
                                    .c_DocumentoAplica.c_Texto = xagregar._NumeroDocumentoAplica
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaEmision.c_Valor = xagregar._FechaProceso
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xagregar._FechaProceso
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TelefonoCliente.c_Texto = xagregar._FichaCliente.r_Telefono_1
                                    .c_TipoDocumento.c_Texto = "NDF"
                                    .c_TipoEntrada.c_Texto = "0"
                                    .c_TotalGeneral.c_Valor = xagregar._Monto
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcommand.ExecuteNonQuery()

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xagregar._FichaCliente.r_Automatico)
                                xcommand.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL GRABAR NOTA DÉBITO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarMovimientoEntrada(ByVal xagregar As c_CxC.c_AgregarDocumentoCxC) As Boolean
                Dim xobj As Object = Nothing
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql2 As String = "update contadores set a_cxc_movimientos_entrada=a_cxc_movimientos_entrada+1; select a_cxc_movimientos_entrada from contadores"
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
                        Case TipoDocumentoMovEntradaCxC.Factura
                            xsql3 = "update contadores set a_cxc_fc=a_cxc_fc+1; select a_cxc_fc from contadores"
                            xtmov = "FAC"
                            xtipoentrada = "1"
                        Case TipoDocumentoMovEntradaCxC.NotaDebito
                            xsql3 = "update contadores set a_cxc_nd=a_cxc_nd+1; select a_cxc_nd from contadores"
                            xtmov = "NDF"
                            xtipoentrada = "1"
                        Case TipoDocumentoMovEntradaCxC.NotaCredito
                            Throw New Exception("NO SE DEBE SELECCIONAR ESTE TIPO DE NOTA DE CREDITO PARA UN MOVIMIENTO DE ENTRADA")
                        Case TipoDocumentoMovEntradaCxC.NotaCreditoNoGeneradaPorSistema
                            xsql3 = "update contadores set a_cxc_nc=a_cxc_nc+1; select a_cxc_nc from contadores"
                            xsigno = -1
                            xtmov = "NCF"
                            xtipoentrada = "1"
                        Case TipoDocumentoMovEntradaCxC.NotaCreditoGeneradaPorSistema
                            xsql3 = "update contadores set a_cxc_nc=a_cxc_nc+1; select a_cxc_nc from contadores"
                            xsigno = -1
                            xtmov = "NCF"
                            xtipoentrada = "0"
                        Case TipoDocumentoMovEntradaCxC.Prestamo
                            xsql3 = "update contadores set a_cxc_prestamos=a_cxc_prestamos+1; select a_cxc_prestamos from contadores"
                            xtmov = "PRE"
                            xtipoentrada = "0"
                    End Select

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC
                                xcommand.CommandText = xsql1
                                xauto_1 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CONTADORES MOV ENTRADA CXC
                                xcommand.CommandText = "select a_cxc_movimientos_entrada from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_movimientos_entrada=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql2
                                xauto_2 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'VERIFICO CONTADORES CXC_FACTURA POR SI ES NULL
                                xcommand.CommandText = "select a_cxc_fc from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_fc=0"
                                    xcommand.ExecuteNonQuery()
                                End If

                                'VERIFICO CONTADORES CXC_PRESTAMO POR SI ES NULL
                                xcommand.CommandText = "select a_cxc_prestamos from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_prestamos=0"
                                    xcommand.ExecuteNonQuery()
                                End If

                                'CONTADORES PARA EL TIPO DE MOVIMIENTO A INGRESAR
                                xcommand.CommandText = xsql3
                                xauto_3 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'CXC
                                Dim xcxc As New FichaCtasCobrar.c_CxC.c_Registro
                                With xcxc
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto_2
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = DateAdd(DateInterval.Day, xagregar._DiasCredito, xagregar._FechaEmision)
                                    .c_MontoAcumulado.c_Valor = (xagregar._Importe - xagregar._SaldoPendiente) * xsigno
                                    .c_MontoImporte.c_Valor = xagregar._Importe * xsigno
                                    .c_MontoPorCobrar.c_Valor = xagregar._SaldoPendiente * xsigno
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xagregar._NotasDetalle
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xauto_3
                                    .c_TipoDocumento.c_Texto = xtmov
                                    .c_TipoMovimiento.c_Valor = xsigno
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC
                                xcommand.Parameters.AddWithValue("@auto", xcxc.c_AutoCxC.c_Texto).Size = xcxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xcxc.c_AutoMovimientoEntrada.c_Texto).Size = xcxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xcxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xcxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xcxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xcxc.c_TipoDocumento.c_Texto).Size = xcxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xcxc.c_NumeroDocumento.c_Texto).Size = xcxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xcxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xcxc.c_NotasDetalles.c_Texto).Size = xcxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xcxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xcxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xcxc.c_AutoCliente.c_Texto).Size = xcxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xcxc.c_NombreCliente.c_Texto).Size = xcxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xcxc.c_CiRifCliente.c_Texto).Size = xcxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xcxc.c_CodigoCliente.c_Texto).Size = xcxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xcxc.c_EstatusCancelado.c_Texto).Size = xcxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xcxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xcxc.c_TipoOperacion.c_Texto).Size = xcxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xcxc.c_EstatusDocumentoCxC.c_Texto).Size = xcxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xcxc.c_AutoDocumento.c_Texto).Size = xcxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xcxc.c_Numero.c_Texto).Size = xcxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xcxc.c_AutoAgencia.c_Texto).Size = xcxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xcxc.c_NombreAgencia.c_Texto).Size = xcxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xcxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'MOVIMIENTO ENTRADA CXC
                                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto_2
                                    .c_AutoCliente.c_Texto = xagregar._FichaCliente.r_Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCxC.c_Texto = xauto_1
                                    .c_CiRifCliente.c_Texto = xagregar._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xagregar._FichaCliente.r_CodigoCliente
                                    .c_DiasCreditoCliente.c_Valor = xagregar._DiasCredito
                                    .c_DirFiscalCliente.c_Texto = xagregar._FichaCliente.r_DirFiscal
                                    .c_Documento.c_Texto = xauto_3
                                    .c_DocumentoAplica.c_Texto = xagregar._NumeroDocumento
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaDevolucion.c_Valor = xagregar._FechaProceso
                                    .c_FechaEmision.c_Valor = xagregar._FechaEmision
                                    .c_FechaProceso.c_Valor = xagregar._FechaProceso
                                    .c_FechaVencimiento.c_Valor = DateAdd(DateInterval.Day, xagregar._DiasCredito, xagregar._FechaEmision)
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xagregar._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xagregar._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TelefonoCliente.c_Texto = xagregar._FichaCliente.r_Telefono_1
                                    .c_TipoDocumento.c_Texto = xtmov
                                    .c_TipoEntrada.c_Texto = xtipoentrada
                                    .c_TotalGeneral.c_Valor = xagregar._Importe
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcommand.ExecuteNonQuery()

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar._FichaCliente.r_Automatico)
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xagregar._FichaCliente.r_Automatico)
                                xcommand.ExecuteNonQuery()
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

            Function F_GrabarNotaCreditoPago(ByVal xpagonc As c_CxC.c_AgregarPagoNotaCredito) As Boolean
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql2 As String = "update contadores set a_cxc_recibos=a_cxc_recibos+1; select a_cxc_recibos from contadores"
                Dim xsql3 As String = "update contadores set a_cxc_recibos_numero=a_cxc_recibos_numero+1; select a_cxc_recibos_numero from contadores"
                Dim xsql4 As String = "update contadores set a_cxc_movimientos_entrada=a_cxc_movimientos_entrada+1; select a_cxc_movimientos_entrada from contadores"
                Dim xauto1 As String = ""
                Dim xauto2 As String = ""
                Dim xauto3 As String = ""
                Dim xauto4 As String = ""

                Dim xtipo_operacion As String = ""
                Dim xcancelado As String = "0"
                Dim xobj As Object = Nothing
                Dim xabono As Decimal = xpagonc._MontoImporte

                Dim xagregar_cxc As New c_CxC.c_Registro
                Dim xagregar_cxc_documentos As New c_Documentos
                Dim xagregar_cxc_recibos As New c_Recibos.c_Registro
                Dim xagregar_cxc_modo_pago As New c_ModosPago.c_Registro
                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                Dim xtr As SqlTransaction

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC
                                xcommand.CommandText = xsql1
                                xauto1 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_RECIBO
                                xcommand.CommandText = xsql2
                                xauto2 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_RECIBO_NUMERO
                                xcommand.CommandText = xsql3
                                xauto3 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTAORES MOV ENTRADA CXC
                                xcommand.CommandText = "select a_cxc_movimientos_entrada from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_movimientos_entrada=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql4
                                xauto4 = xcommand.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                Dim xsaldo_pendiente_antes_del_abono_pago As Decimal = 0
                                xsaldo_pendiente_antes_del_abono_pago = xpagonc._FichaCxC._MontoPorCobrar

                                With xpagonc._FichaCxC
                                    If ._MontoImporte > ._MontoAcumulado + xabono Then
                                        .c_MontoAcumulado.c_Valor += xabono
                                        .c_MontoPorCobrar.c_Valor -= xabono
                                        .c_EstatusCancelado.c_Texto = "0"
                                        xtipo_operacion = "Abono"
                                    Else
                                        .c_MontoAcumulado.c_Valor = ._MontoImporte
                                        .c_MontoPorCobrar.c_Valor = 0
                                        .c_EstatusCancelado.c_Texto = "1"
                                        xtipo_operacion = "Cancelación"
                                    End If
                                End With

                                'ACTUALIZAR DOCUMENTO DE CUENTA POR COBRAR
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE cxc SET cancelado=@cancelado, acumulado=@acumulado, resta=@resta where auto=@auto and id_seguridad=@id_seguridad"
                                xcommand.Parameters.AddWithValue("@cancelado", xpagonc._FichaCxC.c_EstatusCancelado.c_Texto).Size = xpagonc._FichaCxC.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@acumulado", xpagonc._FichaCxC.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@resta", xpagonc._FichaCxC.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto", xpagonc._FichaCxC.c_AutoCxC.c_Texto).Size = xpagonc._FichaCxC.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@id_seguridad", xpagonc._FichaCxC.c_IdSeguridad)
                                If xcommand.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("ERROR EL REGISTRO HA SIDO MODIFICADO, POR FAVOR VERIFIQUE")
                                End If

                                If xpagonc._FichaCxC._EstatusCancelado = TipoSiNo.Si Then
                                    If xpagonc._FichaCxC._AutoMovimientoBanco <> "" Then
                                        Dim xr_banco As Integer = 0
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update movimientos set estatus_operacion='2' where auto=@auto_movimiento"
                                        xcommand.Parameters.AddWithValue("@auto_movimiento", xpagonc._FichaCxC._AutoMovimientoBanco)
                                        xr_banco = xcommand.ExecuteNonQuery()
                                        If xr_banco = 0 Then
                                            Throw New Exception("ERROR AL ACTUALIZAR EN TABLA MOVIMIENTOS: CHEQUE PAGADO - PARA BANCO")
                                        End If
                                    End If
                                End If

                                'REGISTRAR PAGO EN CUENTA POR COBRAR
                                With xagregar_cxc
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xpagonc._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto4
                                    .c_CiRifCliente.c_Texto = xpagonc._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagonc._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = ""
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagonc._FechaEmision
                                    .c_FechaProceso.c_Valor = xpagonc._FechaEmision
                                    .c_FechaRecepcionDevolucion.c_Valor = xpagonc._FechaEmision
                                    .c_FechaVencimiento.c_Valor = xpagonc._FechaEmision
                                    .c_MontoAcumulado.c_Valor = xpagonc._MontoImporte
                                    .c_MontoImporte.c_Valor = 0
                                    .c_MontoPorCobrar.c_Valor = xpagonc._MontoImporte
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xpagonc._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xpagonc._NotasDetalle
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xauto3
                                    .c_TipoDocumento.c_Texto = "PAG"
                                    .c_TipoMovimiento.c_Valor = -1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                'GRABAR PAGO CUENTA POR COBRAR'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc.c_AutoCxC.c_Texto).Size = xagregar_cxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xagregar_cxc.c_AutoMovimientoEntrada.c_Texto).Size = xagregar_cxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_cxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xagregar_cxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_cxc.c_TipoDocumento.c_Texto).Size = xagregar_cxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_cxc.c_NumeroDocumento.c_Texto).Size = xagregar_cxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_cxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc.c_NotasDetalles.c_Texto).Size = xagregar_cxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xagregar_cxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc.c_AutoCliente.c_Texto).Size = xagregar_cxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xagregar_cxc.c_NombreCliente.c_Texto).Size = xagregar_cxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_cxc.c_CiRifCliente.c_Texto).Size = xagregar_cxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc.c_CodigoCliente.c_Texto).Size = xagregar_cxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xagregar_cxc.c_EstatusCancelado.c_Texto).Size = xagregar_cxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xagregar_cxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc.c_TipoOperacion.c_Texto).Size = xagregar_cxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc.c_EstatusDocumentoCxC.c_Texto).Size = xagregar_cxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xagregar_cxc.c_AutoDocumento.c_Texto).Size = xagregar_cxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc.c_Numero.c_Texto).Size = xagregar_cxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc.c_AutoAgencia.c_Texto).Size = xagregar_cxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc.c_NombreAgencia.c_Texto).Size = xagregar_cxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xagregar_cxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR RECIBO'
                                With xagregar_cxc_recibos
                                    .c_AutoCliente.c_Texto = xpagonc._FichaCliente.r_Automatico
                                    .c_AutoCobrador.c_Texto = xpagonc._FichaCobrador.r_Automatico
                                    .c_AutoRecibo.c_Texto = xauto2
                                    .c_AutoUsuario.c_Texto = xpagonc._FichaUsuario._AutoUsuario
                                    .c_CantidadDocumentosRelacionados.c_Valor = 1
                                    .c_CiRifCliente.c_Texto = xpagonc._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagonc._FichaCliente.r_CodigoCliente
                                    .c_DirFiscalCliente.c_Texto = xpagonc._FichaCliente.r_DirFiscal
                                    .c_EstatusRecibo.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagonc._FechaEmision
                                    .c_MontoAnticipo.c_Valor = 0
                                    .c_MontoDescuento.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xpagonc._MontoImporte
                                    .c_MontoImporteDocumento.c_Valor = xpagonc._MontoImporte
                                    .c_MontoTotalDocumento.c_Valor = xpagonc._MontoImporte
                                    .c_NombreCliente.c_Texto = xpagonc._FichaCliente.r_NombreRazonSocial
                                    .c_NombreCobrador.c_Texto = xpagonc._FichaCobrador.r_NombreCobrador
                                    .c_NombreUsuario.c_Texto = xpagonc._FichaUsuario._NombreUsuario
                                    .c_NotasDetalles.c_Texto = xpagonc._NotasDetalle
                                    .c_NumeroRecibo.c_Texto = xauto3
                                    .c_TelefonoCliente.c_Texto = xpagonc._FichaCliente.r_Telefono_1
                                    .c_MontoNCPagadas.c_Valor = xpagonc._MontoImporte
                                    .c_CantNCPagadas.c_Valor = 1
                                    .c_AutoCxcPago.c_Texto = xauto1
                                End With

                                'GRABAR RECIBO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = _INSERT_CXC_RECIBOS
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc_recibos.c_AutoRecibo.c_Texto).Size = xagregar_cxc_recibos.c_AutoRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_recibos.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_recibos.c_NumeroRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_recibos.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_usuario", xagregar_cxc_recibos.c_AutoUsuario.c_Texto).Size = xagregar_cxc_recibos.c_AutoUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_recibos.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@usuario", xagregar_cxc_recibos.c_NombreUsuario.c_Texto).Size = xagregar_cxc_recibos.c_NombreUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe_documentos", xagregar_cxc_recibos.c_MontoImporteDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@descuentos", xagregar_cxc_recibos.c_MontoDescuento.c_Valor)
                                xcommand.Parameters.AddWithValue("@total_documentos", xagregar_cxc_recibos.c_MontoTotalDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_recibos.c_NotasDetalles.c_Texto).Size = xagregar_cxc_recibos.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@cobrador", xagregar_cxc_recibos.c_NombreCobrador.c_Texto).Size = xagregar_cxc_recibos.c_NombreCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc_recibos.c_AutoCliente.c_Texto).Size = xagregar_cxc_recibos.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@nombre_cliente", xagregar_cxc_recibos.c_NombreCliente.c_Texto).Size = xagregar_cxc_recibos.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif_cliente", xagregar_cxc_recibos.c_CiRifCliente.c_Texto).Size = xagregar_cxc_recibos.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc_recibos.c_CodigoCliente.c_Texto).Size = xagregar_cxc_recibos.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_recibos.c_EstatusRecibo.c_Texto).Size = xagregar_cxc_recibos.c_EstatusRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@direccion", xagregar_cxc_recibos.c_DirFiscalCliente.c_Texto).Size = xagregar_cxc_recibos.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_cxc_recibos.c_TelefonoCliente.c_Texto).Size = xagregar_cxc_recibos.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cobrador", xagregar_cxc_recibos.c_AutoCobrador.c_Texto).Size = xagregar_cxc_recibos.c_AutoCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@anticipos", xagregar_cxc_recibos.c_MontoAnticipo.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_doc_rel", xagregar_cxc_recibos.c_CantidadDocumentosRelacionados.c_Valor)
                                'campos nuevos
                                xcommand.Parameters.AddWithValue("@monto_nc_pagadas", xagregar_cxc_recibos.c_MontoNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_nc_pagadas", xagregar_cxc_recibos.c_CantNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_recibos.c_AutoCxcPago.c_Texto)
                                xcommand.ExecuteNonQuery()

                                Dim xtipo As String = ""
                                Select Case xpagonc._FichaCxC._TipoDocumento
                                    Case "FAC" : xtipo = "FACTURA"
                                    Case "NDF" : xtipo = "NOTA DÉBITO"
                                    Case "ND" : xtipo = "NOTA DÉBITO"
                                    Case "CHD" : xtipo = "CHEQUE DEVUELTO"
                                End Select

                                'REGISTRAR DOCUMENTO'
                                With xagregar_cxc_documentos.RegistroDato
                                    .c_AutoCxC.c_Texto = xpagonc._FichaCxC._AutoCxC
                                    .c_AutoCxCPago.c_Texto = xauto1
                                    .c_AutoCxCRecibo.c_Texto = xauto2
                                    .c_NumeroRecibo.c_Texto = xauto3
                                    .c_TipoDocumento.c_Texto = "PAG"
                                    .c_OrigenDocumento.c_Texto = xtipo
                                    .c_Item.c_Valor = 1
                                    .c_FechaEmision.c_Valor = xpagonc._FechaEmision
                                    .c_NumeroDocumento.c_Texto = xpagonc._FichaCxC._NumeroDocumento
                                    .c_TipoOperacion.c_Texto = xtipo_operacion
                                    .c_NotasDetalles.c_Texto = xpagonc._NotasDetalle
                                    .c_Monto.c_Valor = xpagonc._MontoImporte
                                    .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xsaldo_pendiente_antes_del_abono_pago
                                    .c_SignoDocumento.c_Valor = xpagonc._FichaCxC._TipoMovimiento
                                End With

                                'GRABAR DOCUMENTO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_DOCUMENTOS
                                xcommand.Parameters.AddWithValue("@item", xagregar_cxc_documentos.RegistroDato.c_Item.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@monto", xagregar_cxc_documentos.RegistroDato.c_Monto.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc_pago", xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo", xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_documentos.RegistroDato.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc_recibo", xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@numero_recibo", xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@origen", xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@monto_pendiente", xagregar_cxc_documentos.RegistroDato.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                'campos nuevos
                                xcommand.Parameters.AddWithValue("@signo", xagregar_cxc_documentos.RegistroDato.c_SignoDocumento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR MODOS DE PAGO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MODO_PAGO
                                With xagregar_cxc_modo_pago
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoRecibo.c_Texto = xauto2
                                    .c_AutoTipoPago.c_Texto = "NC00000001"
                                    .c_CodigoTipoPago.c_Texto = "NC"
                                    .c_EstatusMovimiento.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagonc._FechaEmision
                                    .c_MontoImporte.c_Valor = xpagonc._MontoImporte
                                    .c_MontoRecibido.c_Valor = xpagonc._MontoImporte
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreTipoPago.c_Texto = "NOTA CREDITO"
                                    .c_Numero.c_Texto = ""
                                End With

                                'GRABAR MODO DE PAGO'
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_modo_pago.c_Numero.c_Texto).Size = xagregar_cxc_modo_pago.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc_modo_pago.c_NombreAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_modo_pago.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@codigo", xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_recibo", xagregar_cxc_modo_pago.c_AutoRecibo.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_cxc_modo_pago.c_NombreTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreTipoPago.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_medios_pago", xagregar_cxc_modo_pago.c_AutoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoTipoPago.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc_modo_pago.c_AutoAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_modo_pago.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Texto).Size = xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Largo
                                xcommand.Parameters.AddWithValue("@monto_recibido", xagregar_cxc_modo_pago.c_MontoRecibido.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'AGREGAR MOVIMIENTO DE ENTRADA
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto4
                                    .c_AutoCliente.c_Texto = xpagonc._FichaCliente.r_Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_CiRifCliente.c_Texto = xpagonc._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagonc._FichaCliente.r_CodigoCliente
                                    .c_DiasCreditoCliente.c_Valor = 0
                                    .c_DirFiscalCliente.c_Texto = xpagonc._FichaCliente.r_DirFiscal
                                    .c_Documento.c_Texto = xauto3
                                    .c_DocumentoAplica.c_Texto = xpagonc._FichaCxC._NumeroDocumento
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaDevolucion.c_Valor = xpagonc._FechaEmision
                                    .c_FechaEmision.c_Valor = xpagonc._FechaEmision
                                    .c_FechaProceso.c_Valor = xpagonc._FechaEmision
                                    .c_FechaVencimiento.c_Valor = xpagonc._FechaEmision
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xpagonc._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xpagonc._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TelefonoCliente.c_Texto = xpagonc._FichaCliente.r_Telefono_1
                                    .c_TipoDocumento.c_Texto = "NCF"
                                    .c_TipoEntrada.c_Texto = "0"
                                    .c_TotalGeneral.c_Valor = xpagonc._MontoImporte
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcommand.ExecuteNonQuery()

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagonc._FichaCliente.r_Automatico).Size = xpagonc._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagonc._FichaCliente.r_Automatico).Size = xpagonc._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagonc._FichaCliente.r_Automatico).Size = xpagonc._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xpagonc._FichaCliente.r_Automatico).Size = xpagonc._FichaCliente.c_Automatico.c_Largo
                                xcommand.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent RetornarAutoRecibo(xauto2)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL GRABAR NOTA CRÉDITO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarAnticipo(ByVal xpagoanticipo As FichaCtasCobrar.c_CxC.c_AgregarPagoAnticipo) As Boolean
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql2 As String = "update contadores set a_cxc_recibos=a_cxc_recibos+1; select a_cxc_recibos from contadores"
                Dim xsql3 As String = "update contadores set a_cxc_recibos_numero=a_cxc_recibos_numero+1; select a_cxc_recibos_numero from contadores"
                Dim xsql4 As String = "update contadores set a_cxc_movimientos_entrada=a_cxc_movimientos_entrada+1; select a_cxc_movimientos_entrada from contadores"
                Dim xsql5 As String = "update contadores set a_cxc_anticipos=a_cxc_anticipos+1; select a_cxc_anticipos from contadores"

                Dim xauto1 As String = ""
                Dim xauto2 As String = ""
                Dim xauto3 As String = ""
                Dim xauto4 As String = ""
                Dim xauto5 As String = ""

                Dim xobj As Object = Nothing
                Dim xagregar_cxc As New c_CxC.c_Registro
                Dim xagregar_cxc_recibos As New c_Recibos.c_Registro
                Dim xagregar_cxc_documentos As New c_Documentos
                Dim xagregar_cxc_modo_pago As New c_ModosPago.c_Registro
                Dim xagregar_mov As New c_MovimientosEntrada.c_Registro
                Dim xtr As SqlTransaction

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC AUTO
                                xcommand.CommandText = xsql1
                                xauto1 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_RECIBOS AUTO
                                xcommand.CommandText = xsql2
                                xauto2 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_RECIBOS NUMERO DOCUMENTO
                                xcommand.CommandText = xsql3
                                xauto3 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_MOVIMIENTOS_ENTRADA AUTO
                                xobj = Nothing
                                xcommand.CommandText = "select a_cxc_movimientos_entrada from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_movimientos_entrada=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql4
                                xauto4 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC_ANTICIPOS AUTO
                                xobj = Nothing
                                xcommand.CommandText = "select a_cxc_anticipos from contadores"
                                xobj = xcommand.ExecuteScalar()
                                If IsDBNull(xobj) Then
                                    xcommand.CommandText = "update contadores set a_cxc_anticipos=0"
                                    xcommand.ExecuteNonQuery()
                                End If
                                xcommand.CommandText = xsql5
                                xauto5 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                With xagregar_cxc
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xpagoanticipo._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = xauto4
                                    .c_CiRifCliente.c_Texto = xpagoanticipo._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagoanticipo._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = ""
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagoanticipo._FechaEmision
                                    .c_FechaProceso.c_Valor = xpagoanticipo._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xpagoanticipo._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xpagoanticipo._FechaProceso
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xpagoanticipo._MontoImporte
                                    .c_MontoPorCobrar.c_Valor = xpagoanticipo._MontoImporte
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xpagoanticipo._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xpagoanticipo._NotasDetalle
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xauto3
                                    .c_TipoDocumento.c_Texto = "ANT"
                                    .c_TipoMovimiento.c_Valor = -1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                'GRABAR PAGO CUENTA POR COBRAR'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc.c_AutoCxC.c_Texto).Size = xagregar_cxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xagregar_cxc.c_AutoMovimientoEntrada.c_Texto).Size = xagregar_cxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_cxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xagregar_cxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_cxc.c_TipoDocumento.c_Texto).Size = xagregar_cxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_cxc.c_NumeroDocumento.c_Texto).Size = xagregar_cxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_cxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc.c_NotasDetalles.c_Texto).Size = xagregar_cxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xagregar_cxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc.c_AutoCliente.c_Texto).Size = xagregar_cxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xagregar_cxc.c_NombreCliente.c_Texto).Size = xagregar_cxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_cxc.c_CiRifCliente.c_Texto).Size = xagregar_cxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc.c_CodigoCliente.c_Texto).Size = xagregar_cxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xagregar_cxc.c_EstatusCancelado.c_Texto).Size = xagregar_cxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xagregar_cxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc.c_TipoOperacion.c_Texto).Size = xagregar_cxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc.c_EstatusDocumentoCxC.c_Texto).Size = xagregar_cxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xagregar_cxc.c_AutoDocumento.c_Texto).Size = xagregar_cxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc.c_Numero.c_Texto).Size = xagregar_cxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc.c_AutoAgencia.c_Texto).Size = xagregar_cxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc.c_NombreAgencia.c_Texto).Size = xagregar_cxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xagregar_cxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR RECIBO'
                                With xagregar_cxc_recibos
                                    .c_AutoCliente.c_Texto = xpagoanticipo._FichaCliente.r_Automatico
                                    .c_AutoCobrador.c_Texto = xpagoanticipo._FichaCobrador.r_Automatico
                                    .c_AutoRecibo.c_Texto = xauto2
                                    .c_AutoUsuario.c_Texto = xpagoanticipo._FichaUsuario._AutoUsuario
                                    .c_CantidadDocumentosRelacionados.c_Valor = 1
                                    .c_CiRifCliente.c_Texto = xpagoanticipo._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagoanticipo._FichaCliente.r_CodigoCliente
                                    .c_DirFiscalCliente.c_Texto = xpagoanticipo._FichaCliente.r_DirFiscal
                                    .c_EstatusRecibo.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagoanticipo._FechaProceso
                                    .c_MontoAnticipo.c_Valor = xpagoanticipo._MontoImporte
                                    .c_MontoDescuento.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xpagoanticipo._MontoImporte
                                    .c_MontoImporteDocumento.c_Valor = xpagoanticipo._MontoImporte
                                    .c_MontoTotalDocumento.c_Valor = xpagoanticipo._MontoImporte
                                    .c_NombreCliente.c_Texto = xpagoanticipo._FichaCliente.r_NombreRazonSocial
                                    .c_NombreCobrador.c_Texto = xpagoanticipo._FichaCobrador.r_NombreCobrador
                                    .c_NombreUsuario.c_Texto = xpagoanticipo._FichaUsuario._NombreUsuario
                                    .c_NotasDetalles.c_Texto = xpagoanticipo._NotasDetalle
                                    .c_NumeroRecibo.c_Texto = xauto3
                                    .c_TelefonoCliente.c_Texto = xpagoanticipo._FichaCliente.r_Telefono_1
                                    .c_MontoNCPagadas.c_Valor = 0
                                    .c_CantNCPagadas.c_Valor = 0
                                    .c_AutoCxcPago.c_Texto = xauto1
                                End With

                                'GRABAR RECIBO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = _INSERT_CXC_RECIBOS
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc_recibos.c_AutoRecibo.c_Texto).Size = xagregar_cxc_recibos.c_AutoRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_recibos.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_recibos.c_NumeroRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_recibos.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_usuario", xagregar_cxc_recibos.c_AutoUsuario.c_Texto).Size = xagregar_cxc_recibos.c_AutoUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_recibos.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@usuario", xagregar_cxc_recibos.c_NombreUsuario.c_Texto).Size = xagregar_cxc_recibos.c_NombreUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe_documentos", xagregar_cxc_recibos.c_MontoImporteDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@descuentos", xagregar_cxc_recibos.c_MontoDescuento.c_Valor)
                                xcommand.Parameters.AddWithValue("@total_documentos", xagregar_cxc_recibos.c_MontoTotalDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_recibos.c_NotasDetalles.c_Texto).Size = xagregar_cxc_recibos.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@cobrador", xagregar_cxc_recibos.c_NombreCobrador.c_Texto).Size = xagregar_cxc_recibos.c_NombreCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc_recibos.c_AutoCliente.c_Texto).Size = xagregar_cxc_recibos.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@nombre_cliente", xagregar_cxc_recibos.c_NombreCliente.c_Texto).Size = xagregar_cxc_recibos.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif_cliente", xagregar_cxc_recibos.c_CiRifCliente.c_Texto).Size = xagregar_cxc_recibos.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc_recibos.c_CodigoCliente.c_Texto).Size = xagregar_cxc_recibos.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_recibos.c_EstatusRecibo.c_Texto).Size = xagregar_cxc_recibos.c_EstatusRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@direccion", xagregar_cxc_recibos.c_DirFiscalCliente.c_Texto).Size = xagregar_cxc_recibos.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_cxc_recibos.c_TelefonoCliente.c_Texto).Size = xagregar_cxc_recibos.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cobrador", xagregar_cxc_recibos.c_AutoCobrador.c_Texto).Size = xagregar_cxc_recibos.c_AutoCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@anticipos", xagregar_cxc_recibos.c_MontoAnticipo.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_doc_rel", xagregar_cxc_recibos.c_CantidadDocumentosRelacionados.c_Valor)
                                'campos nuevos
                                xcommand.Parameters.AddWithValue("@monto_nc_pagadas", xagregar_cxc_recibos.c_MontoNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_nc_pagadas", xagregar_cxc_recibos.c_CantNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_recibos.c_AutoCxcPago.c_Texto)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR DOCUMENTO'
                                With xagregar_cxc_documentos.RegistroDato
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_AutoCxCPago.c_Texto = xauto1
                                    .c_AutoCxCRecibo.c_Texto = xauto2
                                    .c_NumeroRecibo.c_Texto = xauto3
                                    .c_TipoDocumento.c_Texto = "PAG"
                                    .c_OrigenDocumento.c_Texto = "ANTICIPO"
                                    .c_Item.c_Valor = 1
                                    .c_FechaEmision.c_Valor = xpagoanticipo._FechaProceso
                                    .c_NumeroDocumento.c_Texto = xauto5
                                    .c_TipoOperacion.c_Texto = "ANTICIPO"
                                    .c_NotasDetalles.c_Texto = xpagoanticipo._NotasDetalle
                                    .c_Monto.c_Valor = xpagoanticipo._MontoImporte
                                    .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = 0
                                    .c_SignoDocumento.c_Valor = -1
                                End With

                                'GRABAR DOCUMENTO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_DOCUMENTOS
                                xcommand.Parameters.AddWithValue("@item", xagregar_cxc_documentos.RegistroDato.c_Item.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@monto", xagregar_cxc_documentos.RegistroDato.c_Monto.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc_pago", xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo", xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_documentos.RegistroDato.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc_recibo", xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@numero_recibo", xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@origen", xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@monto_pendiente", xagregar_cxc_documentos.RegistroDato.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                xcommand.Parameters.AddWithValue("@signo", xagregar_cxc_documentos.RegistroDato.c_SignoDocumento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR MODOS DE PAGO'
                                For Each xdetalle As FichaCtasCobrar.c_CxC.c_AgregarPagoAnticipo.Pagos In xpagoanticipo._ListaPagos
                                    With xagregar_cxc_modo_pago
                                        .LimpiarRegistro()

                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoRecibo.c_Texto = xauto2
                                        .c_AutoTipoPago.c_Texto = xdetalle._MedioPago._AutoTipoPago
                                        .c_CodigoTipoPago.c_Texto = xdetalle._MedioPago._CodigoTipoPago
                                        .c_EstatusMovimiento.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xpagoanticipo._FechaProceso
                                        .c_MontoImporte.c_Valor = xdetalle._MontoImporte
                                        .c_MontoRecibido.c_Valor = xdetalle._MontoRecibido
                                        .c_NombreAgencia.c_Texto = xdetalle._Agencia
                                        .c_NombreTipoPago.c_Texto = xdetalle._MedioPago._NombreTipoPago
                                        .c_Numero.c_Texto = xdetalle._PlanillaCheque
                                    End With

                                    'GRABAR MODO DE PAGO'
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = INSERT_CXC_MODO_PAGO
                                    xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_modo_pago.c_Numero.c_Texto).Size = xagregar_cxc_modo_pago.c_Numero.c_Largo
                                    xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc_modo_pago.c_NombreAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_modo_pago.c_MontoImporte.c_Valor)
                                    xcommand.Parameters.AddWithValue("@codigo", xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_recibo", xagregar_cxc_modo_pago.c_AutoRecibo.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoRecibo.c_Largo
                                    xcommand.Parameters.AddWithValue("@nombre", xagregar_cxc_modo_pago.c_NombreTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreTipoPago.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_medios_pago", xagregar_cxc_modo_pago.c_AutoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoTipoPago.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc_modo_pago.c_AutoAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoAgencia.c_Largo
                                    xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_modo_pago.c_FechaEmision.c_Valor)
                                    xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Texto).Size = xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Largo
                                    xcommand.Parameters.AddWithValue("@monto_recibido", xagregar_cxc_modo_pago.c_MontoRecibido.c_Valor)
                                    xcommand.ExecuteNonQuery()
                                Next

                                'AGREGAR MOVIMIENTO DE ENTRADA
                                With xagregar_mov
                                    .c_Auto.c_Texto = xauto4
                                    .c_AutoCliente.c_Texto = xpagoanticipo._FichaCliente.r_Automatico
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_CiRifCliente.c_Texto = xpagoanticipo._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagoanticipo._FichaCliente.r_CodigoCliente
                                    .c_DiasCreditoCliente.c_Valor = 0
                                    .c_DirFiscalCliente.c_Texto = xpagoanticipo._FichaCliente.r_DirFiscal
                                    .c_Documento.c_Texto = xauto3
                                    .c_DocumentoAplica.c_Texto = xauto5
                                    .c_EstatusDocumento.c_Texto = "0"
                                    .c_FechaDevolucion.c_Valor = xpagoanticipo._FechaProceso
                                    .c_FechaEmision.c_Valor = xpagoanticipo._FechaEmision
                                    .c_FechaProceso.c_Valor = xpagoanticipo._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xpagoanticipo._FechaProceso
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xpagoanticipo._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDocumento.c_Texto = xpagoanticipo._NotasDetalle
                                    .c_NumeroPlanilla.c_Texto = ""
                                    .c_TelefonoCliente.c_Texto = xpagoanticipo._FichaCliente.r_Telefono_1
                                    .c_TipoDocumento.c_Texto = "ANT"
                                    .c_TipoEntrada.c_Texto = "0"
                                    .c_TotalGeneral.c_Valor = xpagoanticipo._MontoImporte
                                End With

                                'GRABAR MOVIMIENTO DE ENTRADA
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC_MOVIMIENTOS_ENTRADA
                                xcommand.Parameters.AddWithValue("@auto", xagregar_mov.c_Auto.c_Texto).Size = xagregar_mov.c_Auto.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_mov.c_AutoCxC.c_Texto).Size = xagregar_mov.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_mov.c_Documento.c_Texto).Size = xagregar_mov.c_Documento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_mov.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_mov.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_mov.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@nombre", xagregar_mov.c_NombreCliente.c_Texto).Size = xagregar_mov.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dir_fiscal", xagregar_mov.c_DirFiscalCliente.c_Texto).Size = xagregar_mov.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_mov.c_CiRifCliente.c_Texto).Size = xagregar_mov.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_mov.c_TipoDocumento.c_Texto).Size = xagregar_mov.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@total", xagregar_mov.c_TotalGeneral.c_Valor)
                                xcommand.Parameters.AddWithValue("@nota", xagregar_mov.c_NotasDocumento.c_Texto).Size = xagregar_mov.c_NotasDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_mov.c_AutoCliente.c_Texto).Size = xagregar_mov.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_mov.c_CodigoCliente.c_Texto).Size = xagregar_mov.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@dias_credito", xagregar_mov.c_DiasCreditoCliente.c_Valor)
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_mov.c_EstatusDocumento.c_Texto).Size = xagregar_mov.c_EstatusDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@aplica", xagregar_mov.c_DocumentoAplica.c_Texto).Size = xagregar_mov.c_DocumentoAplica.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_mov.c_TelefonoCliente.c_Texto).Size = xagregar_mov.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@tipo_entrada", xagregar_mov.c_TipoEntrada.c_Texto).Size = xagregar_mov.c_TipoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@autoagencia", xagregar_mov.c_AutoAgencia.c_Texto).Size = xagregar_mov.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@nombreagencia", xagregar_mov.c_NombreAgencia.c_Texto).Size = xagregar_mov.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@numeroplanilla", xagregar_mov.c_NumeroPlanilla.c_Texto).Size = xagregar_mov.c_NumeroPlanilla.c_Largo
                                xcommand.Parameters.AddWithValue("@fechadevolucion", xagregar_mov.c_FechaDevolucion.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'ACTUALIZAR ANTICIPO DEL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE clientes SET total_anticipos=total_anticipos+@monto where auto=@auto_cliente"
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagoanticipo._FichaCliente.r_Automatico)
                                xcommand.Parameters.AddWithValue("@monto", xpagoanticipo._MontoImporte)
                                xcommand.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent RetornarAutoRecibo(xauto2)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "ERROR AL GRABAR ANTICIPO:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_GrabarAbono(ByVal xpagos As FichaCtasCobrar.c_CxC.c_AgregarPagos)
                Dim xsql1 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                Dim xsql2 As String = "update contadores set a_cxc_recibos=a_cxc_recibos+1; select a_cxc_recibos from contadores"
                Dim xsql3 As String = "update contadores set a_cxc_recibos_numero=a_cxc_recibos_numero+1; select a_cxc_recibos_numero from contadores"

                Dim xauto1 As String = ""
                Dim xauto2 As String = ""
                Dim xauto3 As String = ""

                Dim xitems As Integer = 0
                Dim xorigen As String = ""
                Dim xobj As Object = Nothing

                Dim xagregar_cxc As New c_CxC.c_Registro
                Dim xagregar_cxc_recibos As New c_Recibos.c_Registro
                Dim xagregar_cxc_documentos As New c_Documentos
                Dim xagregar_cxc_modo_pago As New c_ModosPago.c_Registro
                Dim xtr As SqlTransaction

                Dim MontoTotalPagado As Decimal = 0

                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcommand As New SqlCommand("", xcon, xtr)
                                'CONTADORES CXC AUTO DEL PAGO
                                xcommand.CommandText = xsql1
                                xauto1 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC RECIBO AUTO 
                                xcommand.CommandText = xsql2
                                xauto2 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CONTADORES CXC NUMERO RECIBO DEL PAGO
                                xcommand.CommandText = xsql3
                                xauto3 = xcommand.ExecuteScalar().ToString().Trim.PadLeft(10, "0")

                                'CXC DOCUMENTO DE PAGO
                                With xagregar_cxc
                                    .c_AutoCxC.c_Texto = xauto1
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xpagos._FichaCliente.r_Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = ""
                                    .c_CiRifCliente.c_Texto = xpagos._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagos._FichaCliente.r_CodigoCliente
                                    .c_EstatusCancelado.c_Texto = ""
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagos._FechaEmision
                                    .c_FechaProceso.c_Valor = xpagos._FechaProceso
                                    .c_FechaRecepcionDevolucion.c_Valor = xpagos._FechaProceso
                                    .c_FechaVencimiento.c_Valor = xpagos._FechaProceso
                                    .c_MontoAcumulado.c_Valor = xpagos._MontoImporte
                                    .c_MontoImporte.c_Valor = xpagos._MontoImporte
                                    .c_MontoPorCobrar.c_Valor = 0
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xpagos._FichaCliente.r_NombreRazonSocial
                                    .c_NotasDetalles.c_Texto = xpagos._NotasDetalle
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xauto3
                                    .c_TipoDocumento.c_Texto = "PAG"
                                    .c_TipoMovimiento.c_Valor = -1
                                    .c_TipoOperacion.c_Texto = ""
                                End With

                                'GRABAR PAGO CUENTA POR COBRAR'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = INSERT_CXC
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc.c_AutoCxC.c_Texto).Size = xagregar_cxc.c_AutoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_mov_entrada", xagregar_cxc.c_AutoMovimientoEntrada.c_Texto).Size = xagregar_cxc.c_AutoMovimientoEntrada.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc.c_FechaProceso.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_emision", xagregar_cxc.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@fecha_recepcion_devolucion", xagregar_cxc.c_FechaRecepcionDevolucion.c_Valor)
                                xcommand.Parameters.AddWithValue("@tipo_documento", xagregar_cxc.c_TipoDocumento.c_Texto).Size = xagregar_cxc.c_TipoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@documento", xagregar_cxc.c_NumeroDocumento.c_Texto).Size = xagregar_cxc.c_NumeroDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha_vencimiento", xagregar_cxc.c_FechaVencimiento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc.c_NotasDetalles.c_Texto).Size = xagregar_cxc.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@acumulado", xagregar_cxc.c_MontoAcumulado.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc.c_AutoCliente.c_Texto).Size = xagregar_cxc.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cliente", xagregar_cxc.c_NombreCliente.c_Texto).Size = xagregar_cxc.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif", xagregar_cxc.c_CiRifCliente.c_Texto).Size = xagregar_cxc.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc.c_CodigoCliente.c_Texto).Size = xagregar_cxc.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@cancelado", xagregar_cxc.c_EstatusCancelado.c_Texto).Size = xagregar_cxc.c_EstatusCancelado.c_Largo
                                xcommand.Parameters.AddWithValue("@resta", xagregar_cxc.c_MontoPorCobrar.c_Valor)
                                xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc.c_TipoOperacion.c_Texto).Size = xagregar_cxc.c_TipoOperacion.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc.c_EstatusDocumentoCxC.c_Texto).Size = xagregar_cxc.c_EstatusDocumentoCxC.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_documento", xagregar_cxc.c_AutoDocumento.c_Texto).Size = xagregar_cxc.c_AutoDocumento.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc.c_Numero.c_Texto).Size = xagregar_cxc.c_Numero.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc.c_AutoAgencia.c_Texto).Size = xagregar_cxc.c_AutoAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc.c_NombreAgencia.c_Texto).Size = xagregar_cxc.c_NombreAgencia.c_Largo
                                xcommand.Parameters.AddWithValue("@signo", xagregar_cxc.c_TipoMovimiento.c_Valor)
                                xcommand.ExecuteNonQuery()

                                'REGISTRAR RECIBO'
                                With xagregar_cxc_recibos
                                    .c_AutoCliente.c_Texto = xpagos._FichaCliente.r_Automatico
                                    .c_AutoCobrador.c_Texto = xpagos._FichaCobrador.r_Automatico
                                    .c_AutoRecibo.c_Texto = xauto2
                                    .c_AutoUsuario.c_Texto = xpagos._FichaUsuario._AutoUsuario
                                    .c_CantidadDocumentosRelacionados.c_Valor = xpagos._ListaDocumentosPagar.Count
                                    .c_CiRifCliente.c_Texto = xpagos._FichaCliente.r_CiRif
                                    .c_CodigoCliente.c_Texto = xpagos._FichaCliente.r_CodigoCliente
                                    .c_DirFiscalCliente.c_Texto = xpagos._FichaCliente.r_DirFiscal
                                    .c_EstatusRecibo.c_Texto = "0"
                                    .c_FechaEmision.c_Valor = xpagos._FechaProceso
                                    .c_MontoAnticipo.c_Valor = xpagos._MontoAnticipoUsado
                                    .c_MontoDescuento.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xpagos._MontoImporte
                                    .c_MontoImporteDocumento.c_Valor = xpagos._MontoImporte
                                    .c_MontoTotalDocumento.c_Valor = xpagos._MontoImporte
                                    .c_NombreCliente.c_Texto = xpagos._FichaCliente.r_NombreRazonSocial
                                    .c_NombreCobrador.c_Texto = xpagos._FichaCobrador.r_NombreCobrador
                                    .c_NombreUsuario.c_Texto = xpagos._FichaUsuario._NombreUsuario
                                    .c_NotasDetalles.c_Texto = xpagos._NotasDetalle
                                    .c_NumeroRecibo.c_Texto = xauto3
                                    .c_TelefonoCliente.c_Texto = xpagos._FichaCliente.r_Telefono_1
                                    'CAMPOS NUEVOS
                                    .c_MontoNCPagadas.c_Valor = 0
                                    .c_CantNCPagadas.c_Valor = 0
                                    .c_AutoCxcPago.c_Texto = xauto1
                                End With

                                'GRABAR RECIBO'
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = _INSERT_CXC_RECIBOS
                                xcommand.Parameters.AddWithValue("@auto", xagregar_cxc_recibos.c_AutoRecibo.c_Texto).Size = xagregar_cxc_recibos.c_AutoRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_recibos.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_recibos.c_NumeroRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_recibos.c_FechaEmision.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_usuario", xagregar_cxc_recibos.c_AutoUsuario.c_Texto).Size = xagregar_cxc_recibos.c_AutoUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_recibos.c_MontoImporte.c_Valor)
                                xcommand.Parameters.AddWithValue("@usuario", xagregar_cxc_recibos.c_NombreUsuario.c_Texto).Size = xagregar_cxc_recibos.c_NombreUsuario.c_Largo
                                xcommand.Parameters.AddWithValue("@importe_documentos", xagregar_cxc_recibos.c_MontoImporteDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@descuentos", xagregar_cxc_recibos.c_MontoDescuento.c_Valor)
                                xcommand.Parameters.AddWithValue("@total_documentos", xagregar_cxc_recibos.c_MontoTotalDocumento.c_Valor)
                                xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_recibos.c_NotasDetalles.c_Texto).Size = xagregar_cxc_recibos.c_NotasDetalles.c_Largo
                                xcommand.Parameters.AddWithValue("@cobrador", xagregar_cxc_recibos.c_NombreCobrador.c_Texto).Size = xagregar_cxc_recibos.c_NombreCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cliente", xagregar_cxc_recibos.c_AutoCliente.c_Texto).Size = xagregar_cxc_recibos.c_AutoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@nombre_cliente", xagregar_cxc_recibos.c_NombreCliente.c_Texto).Size = xagregar_cxc_recibos.c_NombreCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@ci_rif_cliente", xagregar_cxc_recibos.c_CiRifCliente.c_Texto).Size = xagregar_cxc_recibos.c_CiRifCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@codigo_cliente", xagregar_cxc_recibos.c_CodigoCliente.c_Texto).Size = xagregar_cxc_recibos.c_CodigoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_recibos.c_EstatusRecibo.c_Texto).Size = xagregar_cxc_recibos.c_EstatusRecibo.c_Largo
                                xcommand.Parameters.AddWithValue("@direccion", xagregar_cxc_recibos.c_DirFiscalCliente.c_Texto).Size = xagregar_cxc_recibos.c_DirFiscalCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@telefono", xagregar_cxc_recibos.c_TelefonoCliente.c_Texto).Size = xagregar_cxc_recibos.c_TelefonoCliente.c_Largo
                                xcommand.Parameters.AddWithValue("@auto_cobrador", xagregar_cxc_recibos.c_AutoCobrador.c_Texto).Size = xagregar_cxc_recibos.c_AutoCobrador.c_Largo
                                xcommand.Parameters.AddWithValue("@anticipos", xagregar_cxc_recibos.c_MontoAnticipo.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_doc_rel", xagregar_cxc_recibos.c_CantidadDocumentosRelacionados.c_Valor)
                                'campos nuevos
                                xcommand.Parameters.AddWithValue("@monto_nc_pagadas", xagregar_cxc_recibos.c_MontoNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@cant_nc_pagadas", xagregar_cxc_recibos.c_CantNCPagadas.c_Valor)
                                xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_recibos.c_AutoCxcPago.c_Texto)
                                xcommand.ExecuteNonQuery()


                                'DOCUMENTOS PAGANDO / ABONANDO
                                Dim TotalPagado As Decimal = 0
                                Dim xtotalimporte As Decimal = xpagos._MontoImporte
                                Dim ximporte As Decimal = 0
                                Dim xcxc As New FichaCtasCobrar.c_CxC
                                Dim xsaldo_pendiente_antes_del_pago_abono As Decimal = 0

                                For Each xcxcdoc As FichaCtasCobrar.c_CxC.c_AgregarPagos.Doc In xpagos._ListaDocumentosPagar
                                    xsaldo_pendiente_antes_del_pago_abono = 0

                                    Dim xreader As SqlDataReader
                                    Dim xtb As New DataTable
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "select * from cxc where auto=@auto AND ID_SEGURIDAD=@ID"
                                    xcommand.Parameters.AddWithValue("@auto", xcxcdoc._AutoDocumento)
                                    xcommand.Parameters.AddWithValue("@ID", xcxcdoc._IdDocumento)
                                    xreader = xcommand.ExecuteReader()
                                    xtb.Load(xreader)
                                    If xtb.Rows.Count > 0 Then
                                        xcxc.M_CargarRegistro(xtb(0))
                                        xsaldo_pendiente_antes_del_pago_abono = xcxc.RegistroDato._MontoPorCobrar
                                    Else
                                        Throw New Exception("DOCUMENTO DE CXC NO ENCONTRADO / FUE MODIFICADO POR OTRO USUARIO")
                                    End If

                                    If xtotalimporte >= xcxc.RegistroDato._MontoPorCobrar Then
                                        With xcxc.RegistroDato
                                            .c_MontoAcumulado.c_Valor = ._MontoImporte
                                            .c_EstatusCancelado.c_Texto = "1"
                                            xtotalimporte -= ._MontoPorCobrar
                                            ximporte = ._MontoPorCobrar
                                            TotalPagado += ._MontoPorCobrar
                                            .c_MontoPorCobrar.c_Valor = 0
                                        End With
                                    Else
                                        With xcxc.RegistroDato
                                            .c_MontoPorCobrar.c_Valor -= xtotalimporte
                                            .c_MontoAcumulado.c_Valor += xtotalimporte
                                            .c_EstatusCancelado.c_Texto = "0"
                                            TotalPagado += xtotalimporte
                                            ximporte = xtotalimporte
                                            xtotalimporte = 0
                                        End With
                                    End If

                                    'ACTUALIZAR CXC SALDO
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = "UPDATE cxc SET cancelado=@cancelado, acumulado=@acumulado, resta=@resta where auto=@auto and id_seguridad=@id_seguridad"
                                    xcommand.Parameters.AddWithValue("@cancelado", xcxc.RegistroDato.c_EstatusCancelado.c_Texto).Size = xcxc.RegistroDato.c_EstatusCancelado.c_Largo
                                    xcommand.Parameters.AddWithValue("@acumulado", xcxc.RegistroDato._MontoAcumulado)
                                    xcommand.Parameters.AddWithValue("@resta", xcxc.RegistroDato._MontoPorCobrar)
                                    xcommand.Parameters.AddWithValue("@auto", xcxc.RegistroDato._AutoCxC).Size = xcxc.RegistroDato.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@id_seguridad", xcxc.RegistroDato._IdSeguridad)
                                    If xcommand.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("ERROR DOCUMENTO DE CXC HA SIDO MODIFICADO POR OTRO USUARIO, POR FAVOR VERIFIQUE" + vbCrLf + "CXC NUMERO: " + xcxc.RegistroDato._NumeroDocumento)
                                    End If

                                    If xcxc.RegistroDato._EstatusCancelado = TipoSiNo.Si Then
                                        If xcxc.RegistroDato._AutoMovimientoBanco <> "" Then
                                            Dim xr_banco As Integer = 0
                                            xcommand.Parameters.Clear()
                                            xcommand.CommandText = "update movimientos set estatus_operacion='2' where auto=@auto_movimiento"
                                            xcommand.Parameters.AddWithValue("@auto_movimiento", xcxc.RegistroDato._AutoMovimientoBanco)
                                            xr_banco = xcommand.ExecuteNonQuery()
                                            If xr_banco = 0 Then
                                                Throw New Exception("ERROR AL ACTUALIZAR EN TABLA MOVIMIENTOS: CHEQUE PAGADO - PARA BANCO")
                                            End If
                                        End If
                                    End If

                                    Select Case xcxc.RegistroDato._TipoDocumento
                                        Case "FAC" : xorigen = "FACTURA"
                                        Case "NDF" : xorigen = "NOTA DÉBITO"
                                        Case "ND" : xorigen = "NOTA DÉBITO"
                                        Case "CHD" : xorigen = "CHEQUE DEVUELTO"
                                    End Select

                                    'REGISTRAR DOCUMENTO'
                                    With xagregar_cxc_documentos.RegistroDato
                                        .c_AutoCxC.c_Texto = xcxc.RegistroDato._AutoCxC
                                        .c_AutoCxCPago.c_Texto = xauto1
                                        .c_AutoCxCRecibo.c_Texto = xauto2
                                        .c_NumeroRecibo.c_Texto = xauto3
                                        .c_TipoDocumento.c_Texto = "PAG"
                                        .c_OrigenDocumento.c_Texto = xorigen
                                        .c_Item.c_Valor = xitems
                                        .c_FechaEmision.c_Valor = xpagos._FechaProceso
                                        .c_NumeroDocumento.c_Texto = xcxc.RegistroDato._NumeroDocumento
                                        .c_TipoOperacion.c_Texto = IIf(xcxc.RegistroDato._EstatusCancelado = TipoSiNo.Si, "Cancelacion", "Abono")
                                        .c_NotasDetalles.c_Texto = xpagos._NotasDetalle
                                        .c_Monto.c_Valor = ximporte
                                        .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xsaldo_pendiente_antes_del_pago_abono
                                        .c_SignoDocumento.c_Valor = xcxc.RegistroDato._TipoMovimiento
                                    End With

                                    'GRABAR DOCUMENTO'
                                    xcommand.Parameters.Clear()
                                    xcommand.CommandText = INSERT_CXC_DOCUMENTOS
                                    xcommand.Parameters.AddWithValue("@item", xagregar_cxc_documentos.RegistroDato.c_Item.c_Valor)
                                    xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Largo
                                    xcommand.Parameters.AddWithValue("@monto", xagregar_cxc_documentos.RegistroDato.c_Monto.c_Valor)
                                    xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Largo
                                    xcommand.Parameters.AddWithValue("@documento", xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_cxc_pago", xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Largo
                                    xcommand.Parameters.AddWithValue("@tipo", xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_documentos.RegistroDato.c_FechaEmision.c_Valor)
                                    xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Largo
                                    xcommand.Parameters.AddWithValue("@auto_cxc_recibo", xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Largo
                                    xcommand.Parameters.AddWithValue("@numero_recibo", xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Largo
                                    xcommand.Parameters.AddWithValue("@origen", xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Largo
                                    xcommand.Parameters.AddWithValue("@monto_pendiente", xagregar_cxc_documentos.RegistroDato.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                    'campos nuevos
                                    xcommand.Parameters.AddWithValue("@signo", xagregar_cxc_documentos.RegistroDato.c_SignoDocumento.c_Valor)
                                    xcommand.ExecuteNonQuery()

                                    xitems += 1
                                    If xtotalimporte = 0 Then
                                        Exit For
                                    End If
                                Next
                                MontoTotalPagado = TotalPagado

                                Dim xTotalMontoPagadoPorNC As Decimal = 0
                                Dim xCantNCPagadas As Integer = 0
                                For Each xdetallenc In xpagos._ListaDocumentosNC_ModoPago
                                    If TotalPagado > 0 Then

                                        xsaldo_pendiente_antes_del_pago_abono = 0
                                        Dim xreader As SqlDataReader
                                        Dim xtb As New DataTable
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "select * from cxc where auto=@auto AND ID_SEGURIDAD=@ID"
                                        xcommand.Parameters.AddWithValue("@auto", xdetallenc._AutoDocumento)
                                        xcommand.Parameters.AddWithValue("@ID", xdetallenc._IdDocumento)
                                        xreader = xcommand.ExecuteReader()
                                        xtb.Load(xreader)
                                        If xtb.Rows.Count > 0 Then
                                            xcxc.M_CargarRegistro(xtb(0))
                                            xsaldo_pendiente_antes_del_pago_abono = xcxc.RegistroDato._MontoPorCobrar
                                        Else
                                            Throw New Exception("DOCUMENTO DE CXC NO ENCONTRADO / FUE MODIFICADO POR OTRO USUARIO")
                                        End If

                                        Dim xmonto As Decimal = 0
                                        Dim xtipmov As String = ""
                                        With xcxc.RegistroDato
                                            If TotalPagado >= Math.Abs(._MontoPorCobrar) Then
                                                TotalPagado += ._MontoPorCobrar
                                                xmonto = Math.Abs(._MontoPorCobrar)
                                                .c_EstatusCancelado.c_Texto = "1"
                                                .c_MontoAcumulado.c_Valor += ._MontoPorCobrar
                                                .c_MontoPorCobrar.c_Valor -= ._MontoPorCobrar
                                                xtipmov = "Cancelación"
                                            Else
                                                .c_EstatusCancelado.c_Texto = "0"
                                                .c_MontoAcumulado.c_Valor += (TotalPagado * -1)
                                                .c_MontoPorCobrar.c_Valor -= (TotalPagado * -1)
                                                xmonto = TotalPagado
                                                TotalPagado = 0
                                                xtipmov = "Abono"
                                            End If
                                        End With

                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "update cxc set acumulado = @acumulado, resta=@resta, cancelado=@cancelado where auto=@auto and abs(resta)>=@monto and estatus='0' and id_seguridad=@idseguridad"
                                        xcommand.Parameters.AddWithValue("@auto", xcxc.RegistroDato.c_AutoCxC.c_Texto).Size = xcxc.RegistroDato.c_AutoCxC.c_Largo
                                        xcommand.Parameters.AddWithValue("@cancelado", xcxc.RegistroDato.c_EstatusCancelado.c_Texto).Size = xcxc.RegistroDato.c_EstatusCancelado.c_Largo
                                        xcommand.Parameters.AddWithValue("@acumulado", xcxc.RegistroDato.c_MontoAcumulado.c_Valor)
                                        xcommand.Parameters.AddWithValue("@resta", xcxc.RegistroDato.c_MontoPorCobrar.c_Valor)
                                        xcommand.Parameters.AddWithValue("@monto", xmonto)
                                        xcommand.Parameters.AddWithValue("@idseguridad", xcxc.RegistroDato._IdSeguridad)
                                        If xcommand.ExecuteNonQuery() = 0 Then
                                            Throw New Exception("ERROR EL REGISTRO HA SIDO MODIFICADO, POR FAVOR VERIFIQUE")
                                        End If
                                        xTotalMontoPagadoPorNC += xmonto
                                        xCantNCPagadas += 1


                                        'REGISTRAR DOCUMENTO'
                                        With xagregar_cxc_documentos.RegistroDato
                                            .LimpiarRegistro()

                                            .c_AutoCxC.c_Texto = xcxc.RegistroDato._AutoCxC
                                            .c_AutoCxCPago.c_Texto = xauto1
                                            .c_AutoCxCRecibo.c_Texto = xauto2
                                            .c_NumeroRecibo.c_Texto = xauto3
                                            .c_TipoDocumento.c_Texto = "PAG"
                                            .c_OrigenDocumento.c_Texto = "NOTA CRÉDITO"
                                            .c_Item.c_Valor = xitems
                                            .c_FechaEmision.c_Valor = xpagos._FechaProceso
                                            .c_NumeroDocumento.c_Texto = xcxc.RegistroDato._NumeroDocumento
                                            .c_TipoOperacion.c_Texto = IIf(xcxc.RegistroDato._EstatusCancelado = TipoSiNo.Si, "Cancelacion", "Abono")
                                            .c_NotasDetalles.c_Texto = xpagos._NotasDetalle
                                            .c_Monto.c_Valor = xmonto
                                            .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xsaldo_pendiente_antes_del_pago_abono
                                            .c_SignoDocumento.c_Valor = xcxc.RegistroDato._TipoMovimiento
                                        End With

                                        'GRABAR DOCUMENTO'
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = INSERT_CXC_DOCUMENTOS
                                        xcommand.Parameters.AddWithValue("@item", xagregar_cxc_documentos.RegistroDato.c_Item.c_Valor)
                                        xcommand.Parameters.AddWithValue("@operacion", xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoOperacion.c_Largo
                                        xcommand.Parameters.AddWithValue("@monto", xagregar_cxc_documentos.RegistroDato.c_Monto.c_Valor)
                                        xcommand.Parameters.AddWithValue("@auto_cxc", xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxC.c_Largo
                                        xcommand.Parameters.AddWithValue("@documento", xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroDocumento.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_cxc_pago", xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@tipo", xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_TipoDocumento.c_Largo
                                        xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_documentos.RegistroDato.c_FechaEmision.c_Valor)
                                        xcommand.Parameters.AddWithValue("@detalle", xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NotasDetalles.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_cxc_recibo", xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_AutoCxCRecibo.c_Largo
                                        xcommand.Parameters.AddWithValue("@numero_recibo", xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_NumeroRecibo.c_Largo
                                        xcommand.Parameters.AddWithValue("@origen", xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Texto).Size = xagregar_cxc_documentos.RegistroDato.c_OrigenDocumento.c_Largo
                                        xcommand.Parameters.AddWithValue("@monto_pendiente", xagregar_cxc_documentos.RegistroDato.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                        xcommand.Parameters.AddWithValue("@SIGNO", xagregar_cxc_documentos.RegistroDato.c_SignoDocumento.c_Valor)
                                        xcommand.ExecuteNonQuery()
                                        xitems += 1
                                    Else
                                        Exit For
                                    End If
                                Next

                                'PAGO POR ANTICIPO
                                If xpagos._MontoAnticipoUsado > 0 Then
                                    If TotalPagado > 0 Then
                                        Dim xr As Integer = 0
                                        'ACTUALIZAR ANTICIPO DEL CLIENTE
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = "UPDATE clientes SET total_anticipos=total_anticipos-@monto where auto=@auto_cliente"
                                        xcommand.Parameters.AddWithValue("@auto_cliente", xpagos._FichaCliente.r_Automatico).Size = xpagos._FichaCliente.c_Automatico.c_Largo
                                        xcommand.Parameters.AddWithValue("@monto", xpagos._MontoAnticipoUsado)
                                        xr = xcommand.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("PROBLEMA AL ACTUALIZAR ANTICIPO DEL CLIENTE")
                                        End If

                                        With xagregar_cxc_modo_pago
                                            .LimpiarRegistro()

                                            .c_AutoAgencia.c_Texto = ""
                                            .c_AutoRecibo.c_Texto = xauto2
                                            .c_AutoTipoPago.c_Texto = "AN00000001"
                                            .c_CodigoTipoPago.c_Texto = "AN"
                                            .c_EstatusMovimiento.c_Texto = "0"
                                            .c_FechaEmision.c_Valor = xpagos._FechaProceso
                                            .c_MontoImporte.c_Valor = xpagos._MontoAnticipoUsado
                                            .c_MontoRecibido.c_Valor = xpagos._MontoAnticipoUsado
                                            .c_NombreAgencia.c_Texto = ""
                                            .c_NombreTipoPago.c_Texto = "ANTICIPO"
                                            .c_Numero.c_Texto = ""
                                        End With

                                        'GRABAR MODO DE PAGO'
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = INSERT_CXC_MODO_PAGO
                                        xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_modo_pago.c_Numero.c_Texto).Size = xagregar_cxc_modo_pago.c_Numero.c_Largo
                                        xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc_modo_pago.c_NombreAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreAgencia.c_Largo
                                        xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_modo_pago.c_MontoImporte.c_Valor)
                                        xcommand.Parameters.AddWithValue("@codigo", xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_recibo", xagregar_cxc_modo_pago.c_AutoRecibo.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoRecibo.c_Largo
                                        xcommand.Parameters.AddWithValue("@nombre", xagregar_cxc_modo_pago.c_NombreTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_medios_pago", xagregar_cxc_modo_pago.c_AutoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc_modo_pago.c_AutoAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoAgencia.c_Largo
                                        xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_modo_pago.c_FechaEmision.c_Valor)
                                        xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Texto).Size = xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Largo
                                        xcommand.Parameters.AddWithValue("@monto_recibido", xagregar_cxc_modo_pago.c_MontoRecibido.c_Valor)
                                        xcommand.ExecuteNonQuery()
                                    End If
                                    TotalPagado -= xpagos._MontoAnticipoUsado
                                End If

                                'OTROS MODOS DE PAGO
                                For Each xmdpago In xpagos._ListaModosPagos
                                    If TotalPagado > 0 Then
                                        Dim ximp As Decimal = 0
                                        If TotalPagado >= xmdpago._MontoRecibido Then
                                            ximp = xmdpago._MontoRecibido
                                        Else
                                            ximp = TotalPagado
                                        End If
                                        With xagregar_cxc_modo_pago
                                            .LimpiarRegistro()

                                            .c_AutoAgencia.c_Texto = ""
                                            .c_AutoRecibo.c_Texto = xauto2
                                            .c_AutoTipoPago.c_Texto = xmdpago._MedioPago._AutoTipoPago
                                            .c_CodigoTipoPago.c_Texto = xmdpago._MedioPago._CodigoTipoPago
                                            .c_EstatusMovimiento.c_Texto = "0"
                                            .c_FechaEmision.c_Valor = xpagos._FechaProceso
                                            .c_MontoImporte.c_Valor = ximp
                                            .c_MontoRecibido.c_Valor = xmdpago._MontoRecibido
                                            .c_NombreAgencia.c_Texto = xmdpago._Agencia
                                            .c_NombreTipoPago.c_Texto = xmdpago._MedioPago._NombreTipoPago
                                            .c_Numero.c_Texto = xmdpago._PlanillaCheque
                                        End With

                                        'GRABAR MODO DE PAGO'
                                        xcommand.Parameters.Clear()
                                        xcommand.CommandText = INSERT_CXC_MODO_PAGO
                                        xcommand.Parameters.AddWithValue("@numero", xagregar_cxc_modo_pago.c_Numero.c_Texto).Size = xagregar_cxc_modo_pago.c_Numero.c_Largo
                                        xcommand.Parameters.AddWithValue("@agencia", xagregar_cxc_modo_pago.c_NombreAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreAgencia.c_Largo
                                        xcommand.Parameters.AddWithValue("@importe", xagregar_cxc_modo_pago.c_MontoImporte.c_Valor)
                                        xcommand.Parameters.AddWithValue("@codigo", xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_CodigoTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_recibo", xagregar_cxc_modo_pago.c_AutoRecibo.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoRecibo.c_Largo
                                        xcommand.Parameters.AddWithValue("@nombre", xagregar_cxc_modo_pago.c_NombreTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_NombreTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_medios_pago", xagregar_cxc_modo_pago.c_AutoTipoPago.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoTipoPago.c_Largo
                                        xcommand.Parameters.AddWithValue("@auto_agencia", xagregar_cxc_modo_pago.c_AutoAgencia.c_Texto).Size = xagregar_cxc_modo_pago.c_AutoAgencia.c_Largo
                                        xcommand.Parameters.AddWithValue("@fecha", xagregar_cxc_modo_pago.c_FechaEmision.c_Valor)
                                        xcommand.Parameters.AddWithValue("@estatus", xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Texto).Size = xagregar_cxc_modo_pago.c_EstatusMovimiento.c_Largo
                                        xcommand.Parameters.AddWithValue("@monto_recibido", xagregar_cxc_modo_pago.c_MontoRecibido.c_Valor)
                                        xcommand.ExecuteNonQuery()
                                        TotalPagado -= ximp
                                    End If
                                Next

                                'ACTUALIZO CXC
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "update cxc set importe=@monto1, acumulado=@monto where auto=@auto"
                                xcommand.Parameters.AddWithValue("@auto", xauto1)
                                xcommand.Parameters.AddWithValue("@monto", MontoTotalPagado)
                                xcommand.Parameters.AddWithValue("@monto1", MontoTotalPagado - xTotalMontoPagadoPorNC - xpagos._MontoAnticipoUsado)
                                xcommand.ExecuteNonQuery()

                                'ACTUALIZO CXC_RECIBOS
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "update cxc_recibos set importe=@monto, importe_documentos=@monto, total_documentos=@monto, " & _
                                                          "cant_doc_rel=@cant, monto_nc_pagadas=@monto_nc_pagadas, cant_nc_pagadas=@cant_nc_pagadas " & _
                                                          "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@auto", xauto2)
                                xcommand.Parameters.AddWithValue("@monto", MontoTotalPagado)
                                xcommand.Parameters.AddWithValue("@cant", xitems)
                                xcommand.Parameters.AddWithValue("@monto_nc_pagadas", xTotalMontoPagadoPorNC)
                                xcommand.Parameters.AddWithValue("@cant_nc_pagadas", xCantNCPagadas)
                                xcommand.ExecuteNonQuery()

                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagos._FichaCliente.r_Automatico).Size = xpagos._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagos._FichaCliente.r_Automatico).Size = xpagos._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcommand.ExecuteScalar()

                                xcommand.Parameters.Clear()
                                xcommand.Parameters.AddWithValue("@auto_cliente", xpagos._FichaCliente.r_Automatico).Size = xpagos._FichaCliente.c_Automatico.c_Largo
                                xcommand.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcommand.ExecuteScalar()

                                'CLIENTES
                                xcommand.Parameters.Clear()
                                xcommand.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo " _
                                  + "where auto=@auto"
                                xcommand.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcommand.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcommand.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcommand.Parameters.AddWithValue("@auto", xpagos._FichaCliente.r_Automatico).Size = xpagos._FichaCliente.c_Automatico.c_Largo
                                xcommand.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent RetornarAutoRecibo(xauto2)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CUENTAS POR COBRAR" + vbCrLf + "GRABAR ABONO:" + vbCrLf + ex.Message)
                End Try
            End Function
#End Region

        End Class

        Private xfichasCxc As FichaCtasCobrar

        Property f_FichasCxc() As FichaCtasCobrar
            Get
                Return xfichasCxc
            End Get
            Set(ByVal value As FichaCtasCobrar)
                xfichasCxc = value
            End Set
        End Property
    End Class
End Namespace
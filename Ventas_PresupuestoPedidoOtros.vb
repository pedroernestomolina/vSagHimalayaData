Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FichaVentas

            Public Enum TipoDocumentoTrasladarVenta As Integer
                Presupuesto = 1
                Pedido = 2
                NotraEntrega = 3
            End Enum

            Public Class V_PresupuestoPedidoOtros
                Class c_Registro
                    Private f_auto_doc_origen As CampoDato
                    Private f_auto_doc_venta As CampoDato
                    Private f_fechaemision_origen As CampoDato
                    Private f_fechaproceso As CampoDato
                    Private f_auto_entidad As CampoDato
                    Private f_ci_rif_entidad As CampoDato
                    Private f_nombre_entidad As CampoDato
                    Private f_diasvalidez_doc_origen As CampoDato
                    Private f_tipodocumento_origen As CampoDato
                    Private f_numdocumento_origen As CampoDato
                    Private f_numdocumento_venta As CampoDato

                    ''' <summary>
                    ''' automatico documento presupuesto/pedido/nota entrega > ORIGEN
                    ''' </summary>
                    Property c_AutoDocumentoOrigen() As CampoDato
                        Get
                            Return Me.f_auto_doc_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_auto_doc_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' automatico documento venta > FACTURA
                    ''' </summary>
                    Property c_AutoDocumentoVenta() As CampoDato
                        Get
                            Return Me.f_auto_doc_venta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_auto_doc_venta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Fecha Emision Documento Origen
                    ''' </summary>
                    Property c_FechaEmisionDocumentoOrigen() As CampoDato
                        Get
                            Return Me.f_fechaemision_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fechaemision_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Fecha Proceso De Factura De Venta
                    ''' </summary>
                    Property c_FechaProcesoDocumentoVenta() As CampoDato
                        Get
                            Return Me.f_fechaproceso
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fechaproceso = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Del Cliente, Documento Venta
                    ''' </summary>
                    Property c_AutoEntidad() As CampoDato
                        Get
                            Return Me.f_auto_entidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_auto_entidad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' CiRif Del Cliente, Documento Venta
                    ''' </summary>
                    Property c_CiRif() As CampoDato
                        Get
                            Return Me.f_ci_rif_entidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_ci_rif_entidad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Nombre Del Cliente, Documento Venta
                    ''' </summary>
                    Property c_NombreEntidad() As CampoDato
                        Get
                            Return Me.f_nombre_entidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_nombre_entidad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Dias Validez Doc Origen 
                    ''' </summary>
                    Property c_DiasValidesDocOrigen() As CampoDato
                        Get
                            Return Me.f_diasvalidez_doc_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_diasvalidez_doc_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Tipo Documento Origen 
                    ''' </summary>
                    Property c_TipoDocumentoOrigen() As CampoDato
                        Get
                            Return Me.f_tipodocumento_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_tipodocumento_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Numero Documento Origen
                    ''' </summary>
                    Property c_NumeroDocumento_Origen() As CampoDato
                        Get
                            Return Me.f_numdocumento_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_numdocumento_origen = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Numero Documento Venta
                    ''' </summary>
                    Property c_NumeroDocumento_Venta() As CampoDato
                        Get
                            Return Me.f_numdocumento_venta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_numdocumento_venta = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumentoOrigen() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc_origen._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_origen._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumentoVenta() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc_venta._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_venta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoEntidad() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_entidad._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_entidad._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CiRif_Entidad() As String
                        Get
                            Dim xv As String = IIf(Me.f_ci_rif_entidad._RetornarValor(Of String)() Is Nothing, "", Me.f_ci_rif_entidad._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _DiasValidezDocumentoOrigen() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_diasvalidez_doc_origen._ContenidoCampo Is Nothing, 0, Me.f_diasvalidez_doc_origen._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _FechaEmisionDocumento_Origen() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fechaemision_origen._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fechaemision_origen._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _FechaProcesoDocumento_Venta() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fechaproceso._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fechaproceso._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _NombreEntidad() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_entidad._ContenidoCampo Is Nothing, "", Me.f_nombre_entidad._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumentoOrigen() As String
                        Get
                            Dim xv As String = IIf(Me.f_numdocumento_origen._ContenidoCampo Is Nothing, "", Me.f_numdocumento_origen._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDocumentoVenta() As String
                        Get
                            Dim xv As String = IIf(Me.f_numdocumento_venta._ContenidoCampo Is Nothing, "", Me.f_numdocumento_venta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' funcion: retorna el tipo de documento origen a trasladar a venta
                    ''' </summary>
                    ReadOnly Property _TipoDocumentoOrigen() As TipoDocumentoTrasladarVenta
                        Get
                            Dim xv As String = IIf(Me.f_tipodocumento_origen._ContenidoCampo Is Nothing, "", Me.f_tipodocumento_origen._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "01" : Return TipoDocumentoTrasladarVenta.Presupuesto
                                Case "02" : Return TipoDocumentoTrasladarVenta.Pedido
                                Case "03" : Return TipoDocumentoTrasladarVenta.NotraEntrega
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' funcion: retorna si / no el documento esta dentro de los dias de validez 
                    ''' </summary>
                    ReadOnly Property _ValidezFechaDocumento() As Boolean
                        Get
                            Dim xr As Integer = DateDiff(DateInterval.Day, Me._FechaProcesoDocumento_Venta, Me._FechaEmisionDocumento_Origen)
                            If xr > Me._DiasValidezDocumentoOrigen Then
                                Return False
                            Else
                                Return True
                            End If
                        End Get
                    End Property

                    Sub Inicializar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CLASE (V_PresupuestoPedidoOtros)" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoDocumentoOrigen = New CampoDato("auto_doc_origen", 10)
                        Me.c_AutoDocumentoVenta = New CampoDato("auto_doc_venta", 10)
                        Me.c_AutoEntidad = New CampoDato("auto_entidad", 10)
                        Me.c_CiRif = New CampoDato("ci_rif_entidad", 12)
                        Me.c_DiasValidesDocOrigen = New CampoDato("diasvalidez_doc_origen")
                        Me.c_FechaEmisionDocumentoOrigen = New CampoDato("fechaemision_origen")
                        Me.c_FechaProcesoDocumentoVenta = New CampoDato("fechaproceso")
                        Me.c_NombreEntidad = New CampoDato("nombre_entidad", 120)
                        Me.c_NumeroDocumento_Origen = New CampoDato("numdocumento_origen", 10)
                        Me.c_NumeroDocumento_Venta = New CampoDato("numdocumento_venta", 10)
                        Me.c_TipoDocumentoOrigen = New CampoDato("tipodocumento_origen", 2)

                        Me.Inicializar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .Inicializar()

                                .c_AutoDocumentoOrigen._ContenidoCampo = xrow(.c_AutoDocumentoOrigen._NombreCampo)
                                .c_AutoDocumentoVenta._ContenidoCampo = xrow(.c_AutoDocumentoVenta._NombreCampo)
                                .c_AutoEntidad._ContenidoCampo = xrow(.c_AutoEntidad._NombreCampo)
                                .c_CiRif._ContenidoCampo = xrow(.c_CiRif._NombreCampo)
                                .c_DiasValidesDocOrigen._ContenidoCampo = xrow(.c_DiasValidesDocOrigen._NombreCampo)
                                .c_FechaEmisionDocumentoOrigen._ContenidoCampo = xrow(.c_FechaEmisionDocumentoOrigen._NombreCampo)
                                .c_FechaProcesoDocumentoVenta._ContenidoCampo = xrow(.c_FechaProcesoDocumentoVenta._NombreCampo)
                                .c_NombreEntidad._ContenidoCampo = xrow(.c_NombreEntidad._NombreCampo)
                                .c_NumeroDocumento_Origen._ContenidoCampo = xrow(.c_NumeroDocumento_Origen._NombreCampo)
                                .c_NumeroDocumento_Venta._ContenidoCampo = xrow(.c_NumeroDocumento_Venta._NombreCampo)
                                .c_TipoDocumentoOrigen._ContenidoCampo = xrow(.c_TipoDocumentoOrigen._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("VENTAS" + vbCrLf + "V_PresupuestoPedidoOtros" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

                Protected Friend Const Insert_Ventas_PresupuestoPedidoOtros As String = _
                      "INSERT INTO ventas_presupuestopedidootros ( " & _
                          "auto_doc_origen, " & _
                          "auto_doc_venta, " & _
                          "fechaemision_origen, " & _
                          "fechaproceso, " & _
                          "auto_entidad, " & _
                          "ci_rif_entidad, " & _
                          "nombre_entidad, " & _
                          "diasvalidez_doc_origen, " & _
                          "tipodocumento_origen, " & _
                          "numdocumento_origen, " & _
                          "numdocumento_venta ) " & _
                          "Values ( " & _
                          "@auto_doc_origen, " & _
                          "@auto_doc_venta, " & _
                          "@fechaemision_origen, " & _
                          "@fechaproceso, " & _
                          "@auto_entidad, " & _
                          "@ci_rif_entidad, " & _
                          "@nombre_entidad, " & _
                          "@diasvalidez_doc_origen, " & _
                          "@tipodocumento_origen, " & _
                          "@numdocumento_origen, " & _
                          "@numdocumento_venta ) "
            End Class

        End Class
    End Class
End Namespace


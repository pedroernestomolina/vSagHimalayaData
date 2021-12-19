Imports System.Data.SqlClient
Imports System.Text

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class PosOnline
            Enum TipoUsoTicket As Integer
                Libre = 0
                Ocupado = 1
            End Enum

            Enum TipoEstatusTicket As Integer
                Facturado = 1
                Pendiente = 2
                Anulado = 3
                Libre = 4
                Ocupado = 5
            End Enum

            Public Class BalanzaEncabezado

                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_cliente As CampoDato
                    Private f_idbalanza As CampoDato
                    Private f_seccion As CampoDato
                    Private f_ticket As CampoDato
                    Private f_vendedor As CampoDato
                    Private f_hora As CampoDato
                    Private f_fecha As CampoDato
                    Private f_total As CampoDato
                    Private f_lineas As CampoDato
                    Private f_grupo As CampoDato
                    Private f_ensuso As CampoDato
                    Private f_pendiente As CampoDato
                    Private f_estatus As CampoDato
                    Private f_factura As CampoDato
                    Private f_usuario As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_serial As CampoDato
                    Private f_estacion As CampoDato
                    Private f_motivo As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return Me.f_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.c_Auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cliente() As CampoDato
                        Get
                            Return Me.f_cliente
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_cliente = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoCliente() As String
                        Get
                            Dim xv As String = IIf(Me.c_Cliente._RetornarValor(Of String)() Is Nothing, "", Me.c_Cliente._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_IdBalanza() As CampoDato
                        Get
                            Return Me.f_idbalanza
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_idbalanza = value
                        End Set
                    End Property

                    ReadOnly Property _IdBalanza() As String
                        Get
                            Dim xv As String = IIf(Me.c_IdBalanza._RetornarValor(Of String)() Is Nothing, "", Me.c_IdBalanza._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Seccion() As CampoDato
                        Get
                            Return Me.f_seccion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_seccion = value
                        End Set
                    End Property

                    ReadOnly Property _Seccion() As String
                        Get
                            Dim xv As String = IIf(Me.c_Seccion._RetornarValor(Of String)() Is Nothing, "", Me.c_Seccion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Ticket() As CampoDato
                        Get
                            Return Me.f_ticket
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_ticket = value
                        End Set
                    End Property

                    ReadOnly Property _Ticket() As String
                        Get
                            Dim xv As String = IIf(Me.c_Ticket._RetornarValor(Of String)() Is Nothing, "", Me.c_Ticket._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CodigoVendedor() As CampoDato
                        Get
                            Return Me.f_vendedor
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoVendedor() As String
                        Get
                            Dim xv As String = IIf(Me.c_CodigoVendedor._RetornarValor(Of String)() Is Nothing, "", Me.c_CodigoVendedor._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _FichaVendedor() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Try
                                Dim xauto As String = ""
                                Dim xficha As New FichaVendedores
                                Dim XP1 As New SqlParameter("@CODIGO", _CodigoVendedor)
                                xauto = F_GetString("SELECT AUTO FROM VENDEDORES WHERE CODIGO=@CODIGO", XP1)
                                If xauto <> "" Then
                                    xficha.F_BuscarVendedor(xauto)
                                    Return xficha.f_Vendedor.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return Me.f_hora
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.c_Hora._RetornarValor(Of String)() Is Nothing, "", Me.c_Hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return Me.f_fecha
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim xv As Date = IIf(Me.c_Fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.c_Fecha._RetornarValor(Of Date)())
                            Return xv
                        End Get
                    End Property

                    Property c_Total() As CampoDato
                        Get
                            Return Me.f_total
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_total = value
                        End Set
                    End Property

                    ReadOnly Property _Total() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.c_Total._ContenidoCampo Is Nothing, 0, Me.c_Total._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_Lineas() As CampoDato
                        Get
                            Return Me.f_lineas
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_lineas = value
                        End Set
                    End Property

                    ReadOnly Property _Lineas() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.c_Lineas._ContenidoCampo Is Nothing, 0, Me.c_Lineas._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_Grupo() As CampoDato
                        Get
                            Return Me.f_grupo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _Grupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_Grupo._RetornarValor(Of String)() Is Nothing, "", Me.c_Grupo._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_EnUso() As CampoDato
                        Get
                            Return Me.f_ensuso
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_ensuso = value
                        End Set
                    End Property

                    ReadOnly Property _EnUso() As TipoUsoTicket
                        Get
                            Dim xv As String = IIf(Me.c_EnUso._RetornarValor(Of String)() Is Nothing, "", Me.c_EnUso._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoUsoTicket.Libre
                                Case Else : Return TipoUsoTicket.Ocupado
                            End Select
                        End Get
                    End Property

                    Property c_Pendiente() As CampoDato
                        Get
                            Return Me.f_pendiente
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_pendiente = value
                        End Set
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return Me.f_estatus
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatusTicket
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            Select Case xv
                                Case "F" : Return TipoEstatusTicket.Facturado
                                Case "A" : Return TipoEstatusTicket.Anulado
                                Case "P" : Return TipoEstatusTicket.Pendiente
                                Case "0" : Return TipoEstatusTicket.Libre
                                Case "B" : Return TipoEstatusTicket.Ocupado
                            End Select
                        End Get
                    End Property

                    Property c_Documento() As CampoDato
                        Get
                            Return Me.f_factura
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_factura = value
                        End Set
                    End Property

                    ReadOnly Property _Documento() As String
                        Get
                            Dim xv As String = IIf(Me.c_Documento._RetornarValor(Of String)() Is Nothing, "", Me.c_Documento._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    Property c_NombreUsuario() As CampoDato
                        Get
                            Return Me.f_usuario
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreUsuario._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreUsuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return Me.f_auto_jornada
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoJornada._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoJornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _FichaJornada() As FastFood.Jornada.c_Registro
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
                            Return Me.f_auto_operador
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.c_AutoOperador._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoOperador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Function _FichaOperador() As FastFood.OperadorJornada.c_Registro
                        Try
                            Dim xv As New FastFood.OperadorJornada
                            xv.F_BuscarCargar(_AutoOperador)
                            Return xv.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Function

                    Property c_Serial() As CampoDato
                        Get
                            Return Me.f_serial
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_serial = value
                        End Set
                    End Property

                    ReadOnly Property _Serial() As String
                        Get
                            Dim xv As String = IIf(Me.c_Serial._RetornarValor(Of String)() Is Nothing, "", Me.c_Serial._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Estacion() As CampoDato
                        Get
                            Return Me.f_estacion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _Estacion() As String
                        Get
                            Dim xv As String = IIf(Me.c_Estacion._RetornarValor(Of String)() Is Nothing, "", Me.c_Estacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Motivo() As CampoDato
                        Get
                            Return Me.f_motivo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_motivo = value
                        End Set
                    End Property

                    ReadOnly Property _Motivo() As String
                        Get
                            Dim xv As String = IIf(Me.c_Motivo._RetornarValor(Of String)() Is Nothing, "", Me.c_Motivo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase POS ONLINE - BALANZA " + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Cliente = New CampoDato("cliente", 5)
                        Me.c_IdBalanza = New CampoDato("idbalanza", 5)
                        Me.c_Seccion = New CampoDato("seccion", 5)
                        Me.c_Ticket = New CampoDato("ticket", 5)
                        Me.c_CodigoVendedor = New CampoDato("vendedor", 5)
                        Me.c_Hora = New CampoDato("hora", 10)
                        Me.c_Fecha = New CampoDato("fecha")
                        Me.c_Total = New CampoDato("total")
                        Me.c_Lineas = New CampoDato("lineas", 10)
                        Me.c_Grupo = New CampoDato("grupo", 2)
                        Me.c_EnUso = New CampoDato("enuso", 1)
                        Me.c_Pendiente = New CampoDato("pendiente", 1)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_Documento = New CampoDato("factura", 10)
                        Me.c_NombreUsuario = New CampoDato("usuario", 20)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_Serial = New CampoDato("serial", 60)
                        Me.c_Estacion = New CampoDato("estacion", 20)
                        Me.c_Motivo = New CampoDato("motivo", 120)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_Cliente._ContenidoCampo = xrow(.c_Cliente._NombreCampo)
                                .c_IdBalanza._ContenidoCampo = xrow(.c_IdBalanza._NombreCampo)
                                .c_Seccion._ContenidoCampo = xrow(.c_Seccion._NombreCampo)
                                .c_Ticket._ContenidoCampo = xrow(.c_Ticket._NombreCampo)
                                .c_CodigoVendedor._ContenidoCampo = xrow(.c_CodigoVendedor._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_Total._ContenidoCampo = xrow(.c_Total._NombreCampo)
                                .c_Lineas._ContenidoCampo = xrow(.c_Lineas._NombreCampo)
                                .c_Grupo._ContenidoCampo = xrow(.c_Grupo._NombreCampo)
                                .c_EnUso._ContenidoCampo = xrow(.c_EnUso._NombreCampo)
                                .c_Pendiente._ContenidoCampo = xrow(.c_Pendiente._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_Documento._ContenidoCampo = xrow(.c_Documento._NombreCampo)
                                .c_NombreUsuario._ContenidoCampo = xrow(.c_NombreUsuario._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_Serial._ContenidoCampo = xrow(.c_Serial._NombreCampo)
                                .c_Estacion._ContenidoCampo = xrow(.c_Estacion._NombreCampo)
                                .c_Motivo._ContenidoCampo = xrow(.c_Motivo._NombreCampo)

                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR REGISTRO:" + vbCrLf + ex.Message)
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
                        Using xadap As New SqlDataAdapter("select * from balanzaeuro_encabezado where auto=@autoitem", _MiCadenaConexion)
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
                        Throw New Exception("BALANZA ENCABEZADO:" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Class AbrirTicketBalanza
                Private xoperador As FastFood.OperadorJornada.c_Registro
                Private xjornada As FastFood.Jornada.c_Registro
                Private xestacion As String
                Private xautoitem As String
                Private xid As String
                Private xfichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xformato As String
                Private xetiq_digitos As String
                Private xetiq_control As String
                Private xetiq_depart As String
                Private xetiq_precio As Decimal
                Private xcodigobarraleido As String

                Property _CodigoBarraLeido() As String
                    Get
                        Return xcodigobarraleido
                    End Get
                    Set(ByVal value As String)
                        xcodigobarraleido = value
                    End Set
                End Property

                Property _FormatoTicket() As String
                    Get
                        Return xformato
                    End Get
                    Set(ByVal value As String)
                        xformato = value
                    End Set
                End Property

                Property _EtqDigitos() As String
                    Get
                        Return xetiq_digitos
                    End Get
                    Set(ByVal value As String)
                        xetiq_digitos = value
                    End Set
                End Property

                Property _EtqControl() As String
                    Get
                        Return xetiq_control
                    End Get
                    Set(ByVal value As String)
                        xetiq_control = value
                    End Set
                End Property

                Property _EtqDepart() As String
                    Get
                        Return xetiq_depart
                    End Get
                    Set(ByVal value As String)
                        xetiq_depart = value
                    End Set
                End Property

                Property _EtqPrecio() As Decimal
                    Get
                        Return xetiq_precio
                    End Get
                    Set(ByVal value As Decimal)
                        xetiq_precio = value
                    End Set
                End Property

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return xfichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        xfichaUsuario = value
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

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        xoperador = value
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

                Property _Estacion() As String
                    Get
                        Return xestacion
                    End Get
                    Set(ByVal value As String)
                        xestacion = value
                    End Set
                End Property

                Property _AutoItem() As String
                    Get
                        Return xautoitem
                    End Get
                    Set(ByVal value As String)
                        xautoitem = value
                    End Set
                End Property

                Sub New()
                    Me._AutoItem = ""
                    Me._Estacion = ""
                    Me._Jornada = Nothing
                    Me._Operador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._IdEquipo = ""
                    Me._FormatoTicket = ""
                    Me._EtqControl = ""
                    Me._EtqDepart = ""
                    Me._EtqPrecio = 0
                    Me._EtqDigitos = ""
                    Me._CodigoBarraLeido = ""
                End Sub
            End Class

            Class AnularTicketBalanza
                Inherits AbrirTicketBalanza

                Private xmotivo As String

                Property _Motivo() As String
                    Get
                        Return xmotivo
                    End Get
                    Set(ByVal value As String)
                        xmotivo = value
                    End Set
                End Property

                Overloads ReadOnly Property _IdEquipo() As String
                    Get
                        Return ""
                    End Get
                End Property

                Sub New()
                    MyBase.New()
                    Me._Motivo = ""
                End Sub
            End Class

            Function F_AnularTicketBalanza(ByVal xRegistro As AnularTicketBalanza) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xobj As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "SELECT enuso from balanzaeuro_encabezado where auto=@autoitem"
                                xcmd.Parameters.AddWithValue("@autoitem", xRegistro._AutoItem)
                                xobj = xcmd.ExecuteScalar()
                                If IsDBNull(xobj) Or IsNothing(xobj) Then
                                    Throw New Exception("TICKET BALANZA NO ENCONTRADO")
                                End If

                                If xobj.ToString.Trim <> "0" Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT ESTATUS from balanzaeuro_encabezado where auto=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xRegistro._AutoItem)
                                    xobj = xcmd.ExecuteScalar().ToString.Trim.ToUpper

                                    Select Case xobj
                                        Case "F" : Throw New Exception("TICKET BALANZA NO PUEDE SER ANULADO YA QUE SU ESTATUS ES FACTURADO")
                                        Case "A" : Throw New Exception("TICKET BALANZA NO PUEDE SER ANULADO YA QUE SU ESTATUS ES ANULADO")
                                        Case "P" : Throw New Exception("TICKET BALANZA NO PUEDE SER ANULADO YA QUE SU ESTATUS ES PENDIENTE")
                                        Case "B" : Throw New Exception("TICKET BALANZA NO PUEDE SER ANULADO YA QUE SU ESTATUS ES OCUPADO")
                                        Case Else : Throw New Exception("TICKET BALANZA NO PUEDE SER ANULADO NO SE TIENE NINGUNA REFERENCIA DEL PORQUE")
                                    End Select
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update balanzaeuro_encabezado set enuso='1', estatus='A', usuario=@usuario, auto_operador=@operador, " & _
                                "auto_jornada=@jornada, serial='', estacion=@estacion, motivo=@motivo where auto=@autoitem and enuso='0'"
                                xcmd.Parameters.AddWithValue("@usuario", xRegistro._FichaUsuario._NombreUsuario).Size = 20
                                xcmd.Parameters.AddWithValue("@operador", xRegistro._Operador._AutoOperador).Size = 10
                                xcmd.Parameters.AddWithValue("@jornada", xRegistro._Jornada._AutoJornada).Size = 10
                                xcmd.Parameters.AddWithValue("@estacion", xRegistro._Estacion).Size = 20
                                xcmd.Parameters.AddWithValue("@motivo", xRegistro._Motivo).Size = 120
                                xcmd.Parameters.AddWithValue("@autoitem", xRegistro._AutoItem)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL ANULAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO ELIMINO")
                                End If
                            End Using
                            xtr.Commit()

                            RaiseEvent _TicketBalanzaAnuladoOk()
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

            Function F_AbrirTicketBalanza(ByVal xreg As AbrirTicketBalanza) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Dim xrd As SqlDataReader = Nothing
                            Dim xtb As New DataTable
                            Dim xrt As Object = Nothing

                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select 1 as x " & _
                                "from balanzaeuro_encabezado be where be.auto=@auto and be.enuso='0' and be.estatus='0'"
                                xcmd.Parameters.AddWithValue("@auto", xreg._AutoItem)
                                xrt = xcmd.ExecuteScalar
                                If xrt Is Nothing Or IsDBNull(xrt) Or xrt = 0 Then
                                    Throw New Exception("TICKET BALANZA NO PUEDE SER PROCESADO, ESTATUS INCORRECTO")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select bd.idbalanza,bd.seccion,bd.ticket,bd.vendedor,bd.plu,bd.peso,bd.total,bd.linea,bd.auto " & _
                                "from balanzaeuro_detalle bd join balanzaeuro_encabezado be on bd.auto_balanzaeuro=be.auto and be.estatus='0' and be.enuso='0' " & _
                                "where be.auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xreg._AutoItem)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("TICKET DE BALANZA NO TIENE DETALLES / ITEMS")
                                End If

                                For Each xr As DataRow In xtb.Rows
                                    Dim fichaprd As New FichaProducto
                                    Dim xregistro As FichaProducto.Prd_Producto.c_Registro = Nothing
                                    xregistro = fichaprd.f_PrdProducto.FPos_BuscarPLU(xr("plu").ToString.Trim)

                                    If xregistro Is Nothing Then
                                        Throw New Exception("PRODUCTO CON PLU #" + xr("plu").ToString.Trim + " NO ENCONTRADO")
                                    End If

                                    If xregistro._EstatusBalanza <> TipoEstatus.Activo Then
                                        Throw New Exception("PRODUCTO CON PLU #" + xr("plu").ToString.Trim + " NO TIENE EL ESTATUS DE BALANZA ACTIVADO")
                                    End If

                                    If xregistro._EstatusProducto = TipoEstatus.Inactivo Then
                                        Throw New Exception("PRODUCTO CON ESTATUS INACTIVO / SUSPENDIDO. VERIFIQUE")
                                    End If

                                    Dim xreg2 As New PosOnline.PosVenta.c_Registro
                                    With xreg2
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xregistro._AutoEmpaqueVentaDetal
                                        .c_AutoItem._ContenidoCampo = ""
                                        .c_AutoJornada._ContenidoCampo = xreg._Jornada._AutoJornada
                                        .c_AutoOperador._ContenidoCampo = xreg._Operador._AutoOperador
                                        .c_AutoProducto._ContenidoCampo = xregistro._AutoProducto
                                        .c_Cantidad._ContenidoCampo = xr("Peso")
                                        .c_CodigoBarraLeido._ContenidoCampo = xreg._CodigoBarraLeido
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xregistro._ContEmpqVentaDetal
                                        .c_TasaIva._ContenidoCampo = xregistro._TasaImpuesto

                                        If xregistro.f_VerificarOferta Then
                                            .c_EnOferta._ContenidoCampo = "1"
                                            .c_PrecioNeto._ContenidoCampo = xregistro._PrecioOferta._Base
                                        Else
                                            .c_EnOferta._ContenidoCampo = "0"
                                            .c_PrecioNeto._ContenidoCampo = xregistro._PrecioDetal._Base
                                        End If

                                        If xregistro._TipoProducto = TipoProductoBalanza.Pesado Then
                                            .c_EsPesado._ContenidoCampo = "1"
                                        Else
                                            .c_EsPesado._ContenidoCampo = "2"
                                        End If

                                        .c_EtiquetaAuto._ContenidoCampo = xreg._AutoItem
                                        .c_EtiquetaBalanza._ContenidoCampo = xr("idbalanza").ToString.Trim
                                        .c_EtiquetaControl._ContenidoCampo = xreg._EtqControl
                                        .c_EtiquetaDepartamento._ContenidoCampo = xreg._EtqDepart
                                        .c_EtiquetaDigitos._ContenidoCampo = xreg._EtqDigitos
                                        .c_EtiquetaFormato._ContenidoCampo = xreg._FormatoTicket
                                        .c_EtiquetaImporteMonto._ContenidoCampo = xr("total")
                                        .c_EtiquetaItem._ContenidoCampo = xr("linea")
                                        .c_EtiquetaPeso._ContenidoCampo = xr("peso")
                                        .c_EtiquetaPlu._ContenidoCampo = xr("plu").ToString.Trim
                                        .c_EtiquetaPrecio._ContenidoCampo = xreg._EtqPrecio
                                        .c_EtiquetaSeccion._ContenidoCampo = xr("seccion").ToString.Trim
                                        .c_EtiquetaTicket._ContenidoCampo = xr("ticket").ToString.Trim
                                        .c_EtiquetaVendedor._ContenidoCampo = xr("vendedor").ToString.Trim
                                        .c_NombreCorto._ContenidoCampo = xregistro._DescripcionResumenDelProducto
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xregistro._NombreEmpaqueVentaDetal
                                        .c_PLU._ContenidoCampo = xr("plu")
                                        .c_PrecioRegular._ContenidoCampo = xregistro._PrecioDetal._Base
                                        .c_PrecioSugerido._ContenidoCampo = xregistro._PrecioSugerido
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = "5" 'UNIDAD
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                                        Select Case xregistro._TipoImpuesto
                                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                                        End Select
                                        .c_IdEquipo._ContenidoCampo = xreg._IdEquipo
                                        .c_AutoUsuario._ContenidoCampo = xreg._FichaUsuario._AutoUsuario
                                        .c_TipoItem._ContenidoCampo = "5" 'TICKET BALANZA
                                        .c_NotasItem._ContenidoCampo = ""
                                    End With

                                    If xreg2._Cantidad = 0 Then
                                        Throw New Exception("CANTIDAD A DESPACHAR INCORRECTA, NO PUEDE SER CERO (0). VERIFIQUE")
                                    End If

                                    If xreg2._PrecioVenta._Base = 0 Then
                                        Throw New Exception("PRECIO DE VENTA INCORRECTO, PRODUCTO NO TIENE UN PRECIO ASIGNADO. VERIFIQUE")
                                    End If

                                    If Math.Abs((xreg2._PrecioVenta._Full * xreg2._Cantidad) - xr("TOTAL")) > 1 Then
                                        Throw New Exception("PRODUCTO CON PLU #" + xr("plu").ToString.Trim + " TIENE EL PRECIO DE VENTA INCORRECTO")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_posventa_item from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_posventa_item=0"
                                        xcmd.ExecuteNonQuery()
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_posventa_item=a_posventa_item+1;select a_posventa_item from contadores"
                                    xreg2.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PosVenta.INSERT
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoEmpaqueMedida._NombreCampo, xreg2._AutoEmpaqueMedida).Size = xreg2.c_AutoEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoItem._NombreCampo, xreg2._AutoItem).Size = xreg2.c_AutoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoJornada._NombreCampo, xreg2._AutoJornada).Size = xreg2.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoOperador._NombreCampo, xreg2._AutoOperador).Size = xreg2.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoProducto._NombreCampo, xreg2._AutoProducto).Size = xreg2.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_Cantidad._NombreCampo, xreg2._Cantidad)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_CodigoBarraLeido._NombreCampo, xreg2._CodigoBarraLeido).Size = xreg2.c_CodigoBarraLeido._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_ContenidoEmpaqueMedida._NombreCampo, xreg2._ContenidoEmpaqueMedida)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EnOferta._NombreCampo, xreg2.c_EnOferta._ContenidoCampo).Size = xreg2.c_EnOferta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EsPesado._NombreCampo, xreg2.c_EsPesado._ContenidoCampo).Size = xreg2.c_EsPesado._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaAuto._NombreCampo, xreg2._EtiquetaAuto).Size = xreg2.c_EtiquetaAuto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaBalanza._NombreCampo, xreg2._EtiquetaBalanza).Size = xreg2.c_EtiquetaBalanza._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaControl._NombreCampo, xreg2._EtiquetaControl).Size = xreg2.c_EtiquetaControl._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaDepartamento._NombreCampo, xreg2._EtiquetaDepartamento).Size = xreg2.c_EtiquetaDepartamento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaDigitos._NombreCampo, xreg2._EtiquetaDigitos).Size = xreg2.c_EtiquetaDigitos._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaFormato._NombreCampo, xreg2._EtiquetaFormato).Size = xreg2.c_EtiquetaFormato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaImporteMonto._NombreCampo, xreg2._EtiquetaImporteMonto)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaItem._NombreCampo, xreg2._EtiquetaItem).Size = xreg2.c_EtiquetaItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaPeso._NombreCampo, xreg2._EtiquetaPeso)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaPlu._NombreCampo, xreg2._EtiquetaPlu).Size = xreg2.c_EtiquetaPlu._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaPrecio._NombreCampo, xreg2._EtiquetaPrecio)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaSeccion._NombreCampo, xreg2._EtiquetaSeccion).Size = xreg2.c_EtiquetaSeccion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaTicket._NombreCampo, xreg2._EtiquetaTicket).Size = xreg2.c_EtiquetaTicket._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_EtiquetaVendedor._NombreCampo, xreg2._EtiquetaVendedor).Size = xreg2.c_EtiquetaVendedor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_NombreCorto._NombreCampo, xreg2._NombreCorto).Size = xreg2.c_NombreCorto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_NombreEmpaqueMedida._NombreCampo, xreg2._NombreEmpaqueMedida).Size = xreg2.c_NombreEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_PLU._NombreCampo, xreg2._PLU).Size = xreg2.c_PLU._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_PrecioNeto._NombreCampo, xreg2._PrecioVenta._Base)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_PrecioRegular._NombreCampo, xreg2._PrecioRegular)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_PrecioSugerido._NombreCampo, xreg2._PrecioSugerido)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_ReferenciaEmpaqueMedida._NombreCampo, xreg2._ReferenciaEmpaqueMedida).Size = xreg2.c_ReferenciaEmpaqueMedida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_ReferenciaPrecioMayor._NombreCampo, xreg2._ReferenciaPrecioMayor).Size = xreg2.c_ReferenciaPrecioMayor._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_TasaIva._NombreCampo, xreg2._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_TipoTasaIva._NombreCampo, xreg2.c_TipoTasaIva._ContenidoCampo).Size = xreg2.c_TipoTasaIva._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_IdEquipo._NombreCampo, xreg2.c_IdEquipo._ContenidoCampo).Size = xreg2.c_IdEquipo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_AutoUsuario._NombreCampo, xreg2.c_AutoUsuario._ContenidoCampo).Size = xreg2.c_AutoUsuario._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_TipoItem._NombreCampo, xreg2.c_TipoItem._ContenidoCampo).Size = xreg2.c_TipoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xreg2.c_NotasItem._NombreCampo, xreg2.c_NotasItem._ContenidoCampo).Size = xreg2.c_NotasItem._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update balanzaeuro_encabezado set enuso='1', estatus='B', usuario=@usuario, auto_operador=@operador, " & _
                                "auto_jornada=@jornada, serial='', estacion=@estacion where auto=@autoitem and enuso='0'"
                                xcmd.Parameters.AddWithValue("@usuario", xreg._FichaUsuario._NombreUsuario).Size = 20
                                xcmd.Parameters.AddWithValue("@operador", xreg._Operador._AutoOperador).Size = 10
                                xcmd.Parameters.AddWithValue("@jornada", xreg._Jornada._AutoJornada).Size = 10
                                xcmd.Parameters.AddWithValue("@estacion", xreg._Estacion).Size = 20
                                xcmd.Parameters.AddWithValue("@autoitem", xreg._AutoItem)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("PROBLEMA AL ACTUALIZAR TICKET: TICKET NO ENCONTRADO / OTRO USUARIO YA LO PUSO EN USO")
                                End If
                            End Using
                            xtr.Commit()

                            RaiseEvent _TicketBalanzaOk()
                            RaiseEvent _FichaUltimoItemRegistrado("")
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

            Class ResultadoBusqedaTicket
                Private xcnt As Integer
                Private xauto As String

                Property _CNT() As Integer
                    Get
                        Return xcnt
                    End Get
                    Set(ByVal value As Integer)
                        xcnt = value
                    End Set
                End Property

                Property _AUTOTICKET() As String
                    Get
                        Return xauto
                    End Get
                    Set(ByVal value As String)
                        xauto = value
                    End Set
                End Property

                Sub New()
                    _CNT = 0
                    _AUTOTICKET = ""
                End Sub
            End Class

            Function F_BuscarTicketBalanza(ByVal xticket As String) As ResultadoBusqedaTicket
                Dim xresult As New ResultadoBusqedaTicket

                Try
                    Dim xp1 As New SqlParameter("@ticket", xticket)
                    Dim xp2 As New SqlParameter("@ticket", xticket)
                    Dim xquery1 As String = "select COUNT(*) as cnt  from BalanzaEuro_Encabezado where enuso='0' and estatus='0' and ticket=@ticket group by ticket"
                    Dim xquery2 As String = "select auto from BalanzaEuro_Encabezado where enuso='0' and estatus='0' and ticket=@ticket"

                    xresult._CNT = F_GetDecimal(xquery1, xp1)
                    If xresult._CNT = 1 Then
                        xresult._AUTOTICKET = F_GetString(xquery2, xp2)
                    End If

                    Return xresult
                Catch ex As Exception
                    Return xresult
                End Try
            End Function

            Function F_HayTicketsBalanzasSinCerrar() As Boolean
                Try
                    Dim xquery1 As String = "select COUNT(*) as cnt  from BalanzaEuro_Encabezado where estatus not in ('F', 'A')"
                    If F_GetInteger(xquery1) > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function
        End Class
    End Class
End Namespace



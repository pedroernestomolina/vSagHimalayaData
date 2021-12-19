Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Public Enum TipoEstatusOperador
            Abierto = 1
            Cerrado = 2
        End Enum

        Partial Public Class FastFood

            Public Class OperadorJornada
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_usuario As CampoDato
                    Private f_usuario_nombre As CampoDato
                    Private f_usuario_grupo As CampoDato
                    Private f_estatus As CampoDato
                    Private f_fecha_inicio As CampoDato
                    Private f_hora_inicio As CampoDato
                    Private f_fecha_cierre As CampoDato
                    Private f_hora_cierre As CampoDato
                    Private f_autousuario_cierre As CampoDato
                    Private f_nombreusuario_cierre As CampoDato
                    Private f_nombregrupo_cierre As CampoDato
                    Private f_totalventas As CampoDato
                    Private f_totaldoc_ventas As CampoDato
                    Private f_totalnc As CampoDato
                    Private f_totaldoc_nc As CampoDato
                    Private f_totalventascredito As CampoDato
                    Private f_totaldocventascredito As CampoDato

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return Me.f_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
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
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _FichaJornada() As Jornada.c_Registro
                        Get
                            Try
                                Dim xficha As New Jornada
                                xficha.F_BuscarCargar(_AutoJornada)
                                Return xficha.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return Me.f_auto_usuario
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_UsuarioNombre() As CampoDato
                        Get
                            Return Me.f_usuario_nombre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_usuario_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _UsuarioNombre() As String
                        Get
                            Dim xv As String = IIf(Me.f_usuario_nombre._RetornarValor(Of String)() Is Nothing, "", Me.f_usuario_nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_UsuarioGrupo() As CampoDato
                        Get
                            Return Me.f_usuario_grupo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_usuario_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _UsuarioGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.f_usuario_grupo._RetornarValor(Of String)() Is Nothing, "", Me.f_usuario_grupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return Me.f_estatus
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusOperador() As TipoEstatusOperador
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            If xv = "0" Then
                                Return TipoEstatusOperador.Abierto
                            Else
                                Return TipoEstatusOperador.Cerrado
                            End If
                        End Get
                    End Property

                    Property c_FechaInicio() As CampoDato
                        Get
                            Return Me.f_fecha_inicio
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_fecha_inicio = value
                        End Set
                    End Property

                    ReadOnly Property _FechaInicio() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_inicio._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_inicio._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_HoraInicio() As CampoDato
                        Get
                            Return Me.f_hora_inicio
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_hora_inicio = value
                        End Set
                    End Property

                    ReadOnly Property _HoraInicio() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_inicio._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_inicio._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Fechacierre() As CampoDato
                        Get
                            Return Me.f_fecha_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_fecha_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _FechaCierre() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_cierre._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_cierre._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_HoraCierre() As CampoDato
                        Get
                            Return Me.f_hora_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_hora_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _HoraCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoUsuarioCierre() As CampoDato
                        Get
                            Return Me.f_autousuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_autousuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuarioCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_autousuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_autousuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_UsuarioNombreCierre() As CampoDato
                        Get
                            Return Me.f_nombreusuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_nombreusuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _UsuarioNombreCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombreusuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_nombreusuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_UsuarioGrupoCierre() As CampoDato
                        Get
                            Return Me.f_nombregrupo_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_nombregrupo_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _UsuarioGrupoCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombregrupo_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_nombregrupo_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TotalDocumentos_Ventas() As CampoDato
                        Get
                            Return Me.f_totaldoc_ventas
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totaldoc_ventas = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDocumentos_Ventas() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_totaldoc_ventas._ContenidoCampo Is Nothing, 0, Me.f_totaldoc_ventas._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalDocumentos_NC() As CampoDato
                        Get
                            Return Me.f_totaldoc_nc
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totaldoc_nc = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDocumentos_NC() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_totaldoc_nc._ContenidoCampo Is Nothing, 0, Me.f_totaldoc_nc._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalDocumentos_VentasCredito() As CampoDato
                        Get
                            Return Me.f_totaldocventascredito
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totaldocventascredito = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDocumentos_VentasCredito() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_totaldocventascredito._ContenidoCampo Is Nothing, 0, Me.f_totaldocventascredito._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalVentas() As CampoDato
                        Get
                            Return Me.f_totalventas
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totalventas = value
                        End Set
                    End Property

                    ReadOnly Property _TotalVentas() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_totalventas._ContenidoCampo Is Nothing, 0, Me.f_totalventas._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalNC() As CampoDato
                        Get
                            Return Me.f_totalnc
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totalnc = value
                        End Set
                    End Property

                    ReadOnly Property _TotalNC() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_totalnc._ContenidoCampo Is Nothing, 0, Me.f_totalnc._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalVentasCredito() As CampoDato
                        Get
                            Return Me.f_totalventascredito
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_totalventascredito = value
                        End Set
                    End Property

                    ReadOnly Property _TotalVentasCredito() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_totalventascredito._ContenidoCampo Is Nothing, 0, Me.f_totalventascredito._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Function f_TieneCuentasPendientesEnFastFood() As Boolean
                        Dim xr As Integer = 0
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Using xcmd As New SqlCommand("select count(*) from TemporalVenta_Pendiente_FastFood where auto_operador=@operador", xcon)
                                        xcmd.Parameters.AddWithValue("@operador", _AutoOperador)
                                        xr = xcmd.ExecuteScalar()
                                        If xr > 0 Then
                                            Return True
                                        Else
                                            Return False
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CUENTAS PENDIENTES OPERADOR FAST-FOOD" + vbCrLf + ex.Message)
                        End Try
                    End Function

                    Function f_TieneMesasPedidosPendientes() As Boolean
                        Dim xr As Integer = 0
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Using xcmd As New SqlCommand("select count(*) from rest_Temporalmesas where auto_operador=@operador", xcon)
                                        xcmd.Parameters.AddWithValue("@operador", _AutoOperador)
                                        xr = xcmd.ExecuteScalar()
                                        If xr > 0 Then
                                            Return True
                                        Else
                                            Return False
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CUENTAS PENDIENTES OPERADOR" + vbCrLf + ex.Message)
                        End Try
                    End Function

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario")
                        Me.c_AutoUsuarioCierre = New CampoDato("autousuario_cierre", 10)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_Fechacierre = New CampoDato("fecha_cierre")
                        Me.c_FechaInicio = New CampoDato("fecha_inicio")
                        Me.c_HoraCierre = New CampoDato("hora_cierre", 10)
                        Me.c_HoraInicio = New CampoDato("hora_inicio", 10)
                        Me.c_TotalDocumentos_NC = New CampoDato("totaldocnc")
                        Me.c_TotalDocumentos_Ventas = New CampoDato("totaldocventas")
                        Me.c_TotalDocumentos_VentasCredito = New CampoDato("totaldocventascredito")
                        Me.c_TotalNC = New CampoDato("totalnc")
                        Me.c_TotalVentas = New CampoDato("totalventas")
                        Me.c_TotalVentasCredito = New CampoDato("totalventascredito")
                        Me.c_UsuarioGrupo = New CampoDato("usuario_grupo", 50)
                        Me.c_UsuarioGrupoCierre = New CampoDato("nombregrupo_cierre", 50)
                        Me.c_UsuarioNombre = New CampoDato("usuario_nombre", 20)
                        Me.c_UsuarioNombreCierre = New CampoDato("nombreusuario_cierre", 20)

                        M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase OPERADORJORNADA" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                                .c_AutoUsuarioCierre._ContenidoCampo = xrow(.c_AutoUsuarioCierre._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                If xrow(.c_Fechacierre._NombreCampo) IsNot Nothing Then
                                    .c_Fechacierre._ContenidoCampo = xrow(.c_Fechacierre._NombreCampo)
                                End If
                                .c_FechaInicio._ContenidoCampo = xrow(.c_FechaInicio._NombreCampo)
                                .c_HoraCierre._ContenidoCampo = xrow(.c_HoraCierre._NombreCampo)
                                .c_HoraInicio._ContenidoCampo = xrow(.c_HoraInicio._NombreCampo)
                                .c_TotalDocumentos_NC._ContenidoCampo = xrow(.c_TotalDocumentos_NC._NombreCampo)
                                .c_TotalDocumentos_Ventas._ContenidoCampo = xrow(.c_TotalDocumentos_Ventas._NombreCampo)
                                .c_TotalDocumentos_VentasCredito._ContenidoCampo = xrow(.c_TotalDocumentos_VentasCredito._NombreCampo)
                                .c_TotalNC._ContenidoCampo = xrow(.c_TotalNC._NombreCampo)
                                .c_TotalVentas._ContenidoCampo = xrow(.c_TotalVentas._NombreCampo)
                                .c_TotalVentasCredito._ContenidoCampo = xrow(.c_TotalVentasCredito._NombreCampo)
                                .c_UsuarioGrupo._ContenidoCampo = xrow(.c_UsuarioGrupo._NombreCampo)
                                .c_UsuarioGrupoCierre._ContenidoCampo = xrow(.c_UsuarioGrupoCierre._NombreCampo)
                                .c_UsuarioNombre._ContenidoCampo = xrow(.c_UsuarioNombre._NombreCampo)
                                .c_UsuarioNombreCierre._ContenidoCampo = xrow(.c_UsuarioNombreCierre._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("FASTFOOD" + vbCrLf + "OPERADOR-JORNADA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Friend Const CERRAR_OPERADORJORNADA As String = "update operadorjornada set " & _
                  "estatus=@estatus, " & _
                  "hora_cierre=@hora_cierre, " & _
                  "autousuario_cierre=@autousuario_cierre, " & _
                  "nombreusuario_cierre=@nombreusuario_cierre, " & _
                  "nombregrupo_cierre=@nombregrupo_cierre, " & _
                  "totalventas=@totalventas, " & _
                  "totaldocventas=@totaldocventas, " & _
                  "totalnc=@totalnc, " & _
                  "totaldocnc=@totaldocnc, " & _
                  "totalventascredito=@totalventascredito, " & _
                  "totaldocventascredito=@totaldocventascredito, " & _
                  "fecha_cierre=@fecha_cierre  " & _
                  "where auto=@operador"


                Friend Const INSERT_OPERADORJORNADA As String = "insert into operadorjornada (" & _
                        "auto, " & _
                        "auto_jornada, " & _
                        "auto_usuario, " & _
                        "usuario_nombre, " & _
                        "usuario_grupo, " & _
                        "estatus, " & _
                        "fecha_inicio, " & _
                        "hora_inicio, " & _
                        "hora_cierre, " & _
                        "autousuario_cierre, " & _
                        "nombreusuario_cierre, " & _
                        "nombregrupo_cierre, " & _
                        "totalventas, " & _
                        "totaldocventas, " & _
                        "totalnc, " & _
                        "totaldocnc, " & _
                        "totalventascredito, " & _
                        "totaldocventascredito, " & _
                        "fecha_cierre) " & _
                        "Values (" & _
                        "@auto, " & _
                        "@auto_jornada, " & _
                        "@auto_usuario, " & _
                        "@usuario_nombre, " & _
                        "@usuario_grupo, " & _
                        "@estatus, " & _
                        "@fecha_inicio, " & _
                        "@hora_inicio, " & _
                        "@hora_cierre, " & _
                        "@autousuario_cierre, " & _
                        "@nombreusuario_cierre, " & _
                        "@nombregrupo_cierre, " & _
                        "@totalventas, " & _
                        "@totaldocventas, " & _
                        "@totalnc, " & _
                        "@totaldocnc, " & _
                        "@totalventascredito, " & _
                        "@totaldocventascredito, " & _
                        "@fecha_cierre) "

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
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from operadorjornada where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count >= 1 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                        Else
                            Throw New Exception("AUTO DEL OPERADOR NO ENCONTRADO.. VERIFIQUE")
                        End If
                    Catch ex As Exception
                        Throw New Exception("FASTFOOD:" + vbCrLf + "OPERADOR JORNADA" + vbCrLf + "Funcion: BUSCAR / CARGAR" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MONITOR / CONTROL DE VENTAS EN CAJA
                ''' </summary>


                Class FichaMonitor
                    Private xmonto As Decimal
                    Private xequipo_emisor As String
                    Private xusuario_emisor As String
                    Private xequipo_destino As String
                    Private xusuario_destino As String

                    Property _MontoVerificar() As Decimal
                        Get
                            Return Me.xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto = value
                        End Set
                    End Property

                    Property _EquipoEmisor() As String
                        Get
                            Return Me.xequipo_emisor
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo_emisor = value
                        End Set
                    End Property

                    Property _EquipoDestino() As String
                        Get
                            Return Me.xequipo_destino
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo_destino = value
                        End Set
                    End Property

                    Property _UsuarioEmisor() As String
                        Get
                            Return Me.xusuario_emisor
                        End Get
                        Set(ByVal value As String)
                            Me.xusuario_emisor = value
                        End Set
                    End Property

                    Property _UsuarioDestino() As String
                        Get
                            Return Me.xusuario_destino
                        End Get
                        Set(ByVal value As String)
                            Me.xusuario_destino = value
                        End Set
                    End Property

                    Sub New()
                        Me._EquipoDestino = ""
                        Me._EquipoEmisor = ""
                        Me._MontoVerificar = 0
                        Me._UsuarioDestino = ""
                        Me._UsuarioEmisor = ""
                    End Sub
                End Class

                Function F_MonitorVentas(ByVal xmonitor As FichaMonitor) As Boolean
                    Try
                        Dim xtotal As Object = Nothing
                        Dim xmontoPagado As Object = Nothing
                        Dim xretiros As Object = Nothing
                        Dim xtr As SqlTransaction = Nothing

                        Dim xsql1 As String = "with a as ( select total, case when tipo='01' then 1 when tipo='03' then -1 " & _
                                                " when tipo='XX' THEN 1 END AS SIGNO from ventas with (readpast) " & _
                                                " where auto_jornada=@jornada and auto_operador=@operador and tipo in ('01','03', 'XX')) " & _
                                                " select SUM(a.total*SIGNO) AS TOTAL from a;"

                        Dim xsql2 As String = "select SUM(pago.monto_recibido) AS TOTAL_PAGADO from cxc_modo_pago pago with (readpast) join ventas v " & _
                                              " with (readpast) on pago.auto_recibo=v.recibo where pago.codigo NOT in ('01','04') " & _
                                              " and v.auto_jornada=@jornada and v.auto_operador=@operador"

                        Dim xsql3 As String = "select SUM(monto) as totalRetiro from FondoRetiroAperturaGaveta with (readpast) " & _
                                              " where auto_jornada =@jornada and auto_operador=@operador and tipo='2'"

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@jornada", Me.RegistroDato._AutoJornada)
                                    xcmd.Parameters.AddWithValue("@operador", Me.RegistroDato._AutoOperador)
                                    xcmd.CommandText = xsql1
                                    xtotal = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@jornada", Me.RegistroDato._AutoJornada)
                                    xcmd.Parameters.AddWithValue("@operador", Me.RegistroDato._AutoOperador)
                                    xcmd.CommandText = xsql2
                                    xmontoPagado = xcmd.ExecuteScalar()

                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@jornada", Me.RegistroDato._AutoJornada)
                                    xcmd.Parameters.AddWithValue("@operador", Me.RegistroDato._AutoOperador)
                                    xcmd.CommandText = xsql3
                                    xretiros = xcmd.ExecuteScalar()
                                End Using

                                If IsNothing(xtotal) Or IsDBNull(xtotal) Then
                                    xtotal = 0
                                End If

                                If IsNothing(xmontoPagado) Or IsDBNull(xmontoPagado) Then
                                    xmontoPagado = 0
                                End If

                                If IsNothing(xretiros) Or IsDBNull(xretiros) Then
                                    xretiros = 0
                                End If

                                If (xtotal - xmontoPagado - xretiros) >= xmonitor._MontoVerificar Then
                                    Dim xmensaje As New MensajesAlerta
                                    With xmensaje
                                        .RegistroDato.c_EquipoDestino._ContenidoCampo = xmonitor._EquipoDestino
                                        .RegistroDato.c_EquipoEmisor._ContenidoCampo = xmonitor._EquipoEmisor
                                        .RegistroDato.c_Mensaje._ContenidoCampo = "VENTA SUPERA / IGUALA EL MONTO ESTABLECIDO EN CAJA"
                                        .RegistroDato.c_Monto._ContenidoCampo = (xtotal - xmontoPagado - xretiros)
                                        .RegistroDato.c_UsuarioDestino._ContenidoCampo = xmonitor._UsuarioDestino
                                        .RegistroDato.c_UsuarioEmisor._ContenidoCampo = xmonitor._UsuarioEmisor
                                        .RegistroDato.c_EstatusMovimiento._ContenidoCampo = "0"
                                    End With

                                    xtr = xcon.BeginTransaction
                                    Using xcmd As New SqlCommand("", xcon, xtr)
                                        Try
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select a_mensaje_alerta from contadores"
                                            If IsDBNull(xcmd.ExecuteScalar()) Then
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "update contadores set a_mensaje_alerta=0"
                                                xcmd.ExecuteNonQuery()
                                            End If

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update contadores set a_mensaje_alerta=a_mensaje_alerta+1;select a_mensaje_alerta from contadores"
                                            xmensaje.RegistroDato.c_Auto._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = MensajesAlerta.InsertMensajeAlerta
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_Auto._NombreCampo, xmensaje.RegistroDato._Auto).Size = xmensaje.RegistroDato.c_Auto._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_EquipoDestino._NombreCampo, xmensaje.RegistroDato._EquipoDestino).Size = xmensaje.RegistroDato.c_EquipoDestino._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_EquipoEmisor._NombreCampo, xmensaje.RegistroDato._EquipoEmisor).Size = xmensaje.RegistroDato.c_EquipoEmisor._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_EstatusMovimiento._NombreCampo, xmensaje.RegistroDato._EstatusMovimiento).Size = xmensaje.RegistroDato.c_EstatusMovimiento._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_Mensaje._NombreCampo, xmensaje.RegistroDato._Mensaje).Size = xmensaje.RegistroDato.c_Mensaje._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_Monto._NombreCampo, xmensaje.RegistroDato._Monto)
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_UsuarioDestino._NombreCampo, xmensaje.RegistroDato._UsuarioDestino).Size = xmensaje.RegistroDato.c_UsuarioDestino._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xmensaje.RegistroDato.c_UsuarioEmisor._NombreCampo, xmensaje.RegistroDato._UsuarioEmisor).Size = xmensaje.RegistroDato.c_UsuarioEmisor._LargoCampo
                                            xcmd.ExecuteNonQuery()

                                            xtr.Commit()
                                            Return True
                                        Catch ex As Exception
                                            xtr.Rollback()
                                            Throw New Exception(ex.Message)
                                        End Try
                                    End Using
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("Problema En Monitor Ventas Operador-Jornada: " + vbCrLf + ex.Message)
                    End Try
                End Function

                Protected Overrides Sub Finalize()
                    MyBase.Finalize()
                End Sub
            End Class

            Public Class OperadorJornada_Activa
                Class c_Registro
                    Private f_auto_operador As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_usuario As CampoDato

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xjornada As New FastFood.Jornada
                                xjornada.F_BuscarCargar(_AutoJornada)
                                Return xjornada.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xoperador As New FastFood.OperadorJornada
                                xoperador.F_BuscarCargar(_AutoOperador)
                                Return xoperador.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoUsuario() As CampoDato
                        Get
                            Return f_auto_usuario
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Try
                                Dim xusuario As New FichaGlobal.c_Usuario
                                xusuario.F_BuscarRegistro(_AutoUsuario)
                                Return xusuario.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoUsuario = New CampoDato("auto_usuario", 10)

                        M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase OPERADORJORNADA-ACTIVA" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoUsuario._ContenidoCampo = xrow(.c_AutoUsuario._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("FASTFOOD" + vbCrLf + "OPERADORJORNADA-ACTIVA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Friend Const INSERT_OPERADORJORNADA_ACTIVO As String = "INSERT INTO OperadorJornada_Activo (" & _
                     "auto_operador," & _
                     "auto_usuario," & _
                     "auto_jornada) " & _
                     "VALUES (" & _
                     "@auto_operador," & _
                     "@auto_usuario," & _
                     "@auto_jornada) "

                Friend Const ELIMINAR_OPERADORJORNADA_ACTIVO As String = "delete operadorjornada_activo where auto_operador=@operador and auto_jornada=@jornada"

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

                ''' <summary>
                ''' BUSCAR Y CARGAR DATA DEL OPERADOR , JORNADA Y USUARIO ACTIVOS
                ''' </summary>
                ''' <param name="xauto_jornada ">AUTO DE LA JORNADA A CARGAR</param>
                Function F_BuscarCargar(ByVal xauto_jornada As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from operadorjornada_activo where auto_jornada=@auto_jornada"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_jornada", xauto_jornada)
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count >= 1 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                        Else
                            Throw New Exception("AUTO DE LA JORNADA NO ENCONTRADO.. VERIFIQUE")
                        End If
                    Catch ex As Exception
                        Throw New Exception("OPERADOR - JORNADA ACTIVO" + vbCrLf + "Funcion: BUSCAR / CARGAR" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Public Class OperadorCrear
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xjornada As FastFood.Jornada.c_Registro

                Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xusuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xusuario = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xjornada = value
                    End Set
                End Property

                ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()")
                    End Get
                End Property

                ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString
                    End Get
                End Property

                Sub New()
                    Me._Jornada = Nothing
                    Me._Usuario = Nothing
                End Sub
            End Class

            Public Class OperadorCerrar
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xjornada As FastFood.Jornada.c_Registro
                Private xoperador As FastFood.OperadorJornada.c_Registro

                Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xusuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xusuario = value
                    End Set
                End Property

                Property _Jornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xjornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xjornada = value
                    End Set
                End Property

                Property _Operador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xoperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xoperador = value
                    End Set
                End Property

                ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()")
                    End Get
                End Property

                ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString
                    End Get
                End Property

                ReadOnly Property _TotalVentas() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select sum(total) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='01' and estatus='0'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL VENTAS:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TotalDocVentas() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select count(*) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='01' and estatus='0'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL VENTAS:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TotalNC() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select sum(total) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='03' and estatus='0'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL NC:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TotalDocNC() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select count(*) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='03' and estatus='0'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL DOC NC:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TotalVentasCredito() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select sum(total) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='01' and estatus='0' and condicion_pago<>'CONTADO'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL VENTAS CREDITO:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TotalDocVentasCredito() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.Parameters.AddWithValue("@operador", _Operador._AutoOperador)
                                        xcmd.CommandText = "select count(*) from ventas where auto_jornada=@jornada and auto_operador=@operador and tipo='01' and estatus='0' and condicion_pago<>'CONTADO'"
                                        xobj = xcmd.ExecuteScalar()
                                    End Using
                                    If xobj Is Nothing Or IsDBNull(xobj) Then
                                        Return 0
                                    Else
                                        Return xobj
                                    End If
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End Using
                        Catch ex As Exception
                            Throw New Exception("CERRAR OPERADOR:" & vbCrLf & "TOTAL DOC VENTAS CREDITO:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                Sub New()
                    Me._Jornada = Nothing
                    Me._Usuario = Nothing
                    Me._Operador = Nothing
                End Sub
            End Class

        End Class
    End Class
End Namespace


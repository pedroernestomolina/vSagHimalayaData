Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Public Enum TipoEstatusJornada
            Abierta = 1
            Cerrada = 2
        End Enum

        Partial Public Class FastFood

            Public Class Jornada
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_serialfiscal As CampoDato
                    Private f_fecha_apert As CampoDato
                    Private f_hora_apert As CampoDato
                    Private f_auto_usuario_apert As CampoDato
                    Private f_codigo_usuario_apert As CampoDato
                    Private f_nombre_usuario_apert As CampoDato
                    Private f_grupo_usuario_apert As CampoDato
                    Private f_estacion_apert As CampoDato
                    Private f_estatus As CampoDato
                    Private f_fecha_cierre As CampoDato
                    Private f_hora_cierre As CampoDato
                    Private f_auto_usuario_cierre As CampoDato
                    Private f_codigo_usuario_cierre As CampoDato
                    Private f_nombre_usuario_cierre As CampoDato
                    Private f_grupo_usuario_cierre As CampoDato
                    Private f_totaldoc_ventas As CampoDato
                    Private f_totaldoc_nc As CampoDato
                    Private f_totalventas As CampoDato
                    Private f_totalnc As CampoDato

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_SerialFiscal() As CampoDato
                        Get
                            Return f_serialfiscal
                        End Get
                        Set(ByVal value As CampoDato)
                            f_serialfiscal = value
                        End Set
                    End Property

                    ReadOnly Property _SerialFiscal() As String
                        Get
                            Dim xv As String = IIf(Me.f_serialfiscal._RetornarValor(Of String)() Is Nothing, "", Me.f_serialfiscal._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaApertura() As CampoDato
                        Get
                            Return f_fecha_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_fecha_apert = value
                        End Set
                    End Property

                    ReadOnly Property _FechaApertura() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_apert._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_apert._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_HoraApertura() As CampoDato
                        Get
                            Return f_hora_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_hora_apert = value
                        End Set
                    End Property

                    ReadOnly Property _HoraApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoUsuarioApertura() As CampoDato
                        Get
                            Return f_auto_usuario_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_usuario_apert = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuarioApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuarioApertura() As CampoDato
                        Get
                            Return f_nombre_usuario_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_nombre_usuario_apert = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuarioApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_usuario_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_usuario_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CodigoUsuarioApertura() As CampoDato
                        Get
                            Return f_codigo_usuario_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_codigo_usuario_apert = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoUsuarioApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo_usuario_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo_usuario_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_GrupoUsuarioApertura() As CampoDato
                        Get
                            Return f_grupo_usuario_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_grupo_usuario_apert = value
                        End Set
                    End Property

                    ReadOnly Property _GrupoUsuarioApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_grupo_usuario_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_grupo_usuario_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EstacionApertura() As CampoDato
                        Get
                            Return f_estacion_apert
                        End Get
                        Set(ByVal value As CampoDato)
                            f_estacion_apert = value
                        End Set
                    End Property

                    ReadOnly Property _EstacionApertura() As String
                        Get
                            Dim xv As String = IIf(Me.f_estacion_apert._RetornarValor(Of String)() Is Nothing, "", Me.f_estacion_apert._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusJornada() As TipoEstatusJornada
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            If xv = "0" Then
                                Return TipoEstatusJornada.Abierta
                            Else
                                Return TipoEstatusJornada.Cerrada
                            End If
                        End Get
                    End Property

                    Property c_FechaCierre() As CampoDato
                        Get
                            Return f_fecha_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_fecha_cierre = value
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
                            Return f_hora_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_hora_cierre = value
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
                            Return f_auto_usuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_auto_usuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuarioCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_usuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_usuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreUsuarioCierre() As CampoDato
                        Get
                            Return f_nombre_usuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_nombre_usuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuarioCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_usuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_usuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_CodigoUsuarioCierre() As CampoDato
                        Get
                            Return f_codigo_usuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_codigo_usuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoUsuarioCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo_usuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo_usuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_GrupoUsuarioCierre() As CampoDato
                        Get
                            Return f_grupo_usuario_cierre
                        End Get
                        Set(ByVal value As CampoDato)
                            f_grupo_usuario_cierre = value
                        End Set
                    End Property

                    ReadOnly Property _GrupoUsuarioCierre() As String
                        Get
                            Dim xv As String = IIf(Me.f_grupo_usuario_cierre._RetornarValor(Of String)() Is Nothing, "", Me.f_grupo_usuario_cierre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TotalDocumentos_Ventas() As CampoDato
                        Get
                            Return f_totaldoc_ventas
                        End Get
                        Set(ByVal value As CampoDato)
                            f_totaldoc_ventas = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDoc_Ventas() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_totaldoc_ventas._ContenidoCampo Is Nothing, 0, Me.f_totaldoc_ventas._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalDocumentos_NC() As CampoDato
                        Get
                            Return f_totaldoc_nc
                        End Get
                        Set(ByVal value As CampoDato)
                            f_totaldoc_nc = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDoc_NC() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_totaldoc_nc._ContenidoCampo Is Nothing, 0, Me.f_totaldoc_nc._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_TotalVentas() As CampoDato
                        Get
                            Return f_totalventas
                        End Get
                        Set(ByVal value As CampoDato)
                            f_totalventas = value
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
                            Return f_totalnc
                        End Get
                        Set(ByVal value As CampoDato)
                            f_totalnc = value
                        End Set
                    End Property

                    ReadOnly Property _TotalNC() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_totalnc._ContenidoCampo Is Nothing, 0, Me.f_totalnc._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto", 10)
                        Me.c_AutoUsuarioApertura = New CampoDato("auto_usuario_apert", 10)
                        Me.c_AutoUsuarioCierre = New CampoDato("auto_usuario_cierre", 10)
                        Me.c_CodigoUsuarioApertura = New CampoDato("codigo_usuario_apert", 10)
                        Me.c_CodigoUsuarioCierre = New CampoDato("codigo_usuario_cierre", 10)
                        Me.c_EstacionApertura = New CampoDato("estacion_apert", 20)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_FechaApertura = New CampoDato("fecha_apert")
                        Me.c_FechaCierre = New CampoDato("fecha_cierre")
                        Me.c_GrupoUsuarioApertura = New CampoDato("grupo_usuario_apert", 50)
                        Me.c_GrupoUsuarioCierre = New CampoDato("grupo_usuario_cierre", 50)
                        Me.c_HoraApertura = New CampoDato("hora_apert", 10)
                        Me.c_HoraCierre = New CampoDato("hora_cierre", 10)
                        Me.c_NombreUsuarioApertura = New CampoDato("nombre_usuario_apert", 20)
                        Me.c_NombreUsuarioCierre = New CampoDato("nombre_usuario_cierre", 20)
                        Me.c_SerialFiscal = New CampoDato("serialfiscal", 15)
                        Me.c_TotalDocumentos_NC = New CampoDato("totaldoc_nc")
                        Me.c_TotalDocumentos_Ventas = New CampoDato("totaldoc_ventas")
                        Me.c_TotalNC = New CampoDato("totalnc")
                        Me.c_TotalVentas = New CampoDato("totalventas")

                        M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CLASE: JORNADA" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoUsuarioApertura._ContenidoCampo = xrow(.c_AutoUsuarioApertura._NombreCampo)
                                .c_AutoUsuarioCierre._ContenidoCampo = xrow(.c_AutoUsuarioCierre._NombreCampo)
                                .c_CodigoUsuarioApertura._ContenidoCampo = xrow(.c_CodigoUsuarioApertura._NombreCampo)
                                .c_CodigoUsuarioCierre._ContenidoCampo = xrow(.c_CodigoUsuarioCierre._NombreCampo)
                                .c_EstacionApertura._ContenidoCampo = xrow(.c_EstacionApertura._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_FechaApertura._ContenidoCampo = xrow(.c_FechaApertura._NombreCampo)
                                If xrow(.c_FechaCierre._NombreCampo) IsNot Nothing Then
                                    .c_FechaCierre._ContenidoCampo = xrow(.c_FechaCierre._NombreCampo)
                                End If
                                .c_GrupoUsuarioApertura._ContenidoCampo = xrow(.c_GrupoUsuarioApertura._NombreCampo)
                                .c_GrupoUsuarioCierre._ContenidoCampo = xrow(.c_GrupoUsuarioCierre._NombreCampo)
                                .c_HoraApertura._ContenidoCampo = xrow(.c_HoraApertura._NombreCampo)
                                .c_HoraCierre._ContenidoCampo = xrow(.c_HoraCierre._NombreCampo)
                                .c_NombreUsuarioApertura._ContenidoCampo = xrow(.c_NombreUsuarioApertura._NombreCampo)
                                .c_NombreUsuarioCierre._ContenidoCampo = xrow(.c_NombreUsuarioCierre._NombreCampo)
                                .c_SerialFiscal._ContenidoCampo = xrow(.c_SerialFiscal._NombreCampo)
                                .c_TotalDocumentos_NC._ContenidoCampo = xrow(.c_TotalDocumentos_NC._NombreCampo)
                                .c_TotalDocumentos_Ventas._ContenidoCampo = xrow(.c_TotalDocumentos_Ventas._NombreCampo)
                                .c_TotalNC._ContenidoCampo = xrow(.c_TotalNC._NombreCampo)
                                .c_TotalVentas._ContenidoCampo = xrow(.c_TotalVentas._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("FASTFOOD" + vbCrLf + "JORNADA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub


                    Function f_TieneCuentasPendientesEnFastFood() As Boolean
                        Dim xr As Integer = 0
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Using xcmd As New SqlCommand("select count(*) from TemporalVenta_Pendiente_FastFood where auto_jornada=@jornada", xcon)
                                        xcmd.Parameters.AddWithValue("@jornada", _AutoJornada)
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
                            Throw New Exception("CUENTAS PENDIENTES JORNADA FAST-FOOD" + vbCrLf + ex.Message)
                        End Try
                    End Function

                    Function f_TieneMesasPedidosPendientes() As Boolean
                        Dim xr As Integer = 0
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Using xcmd As New SqlCommand("select count(*) from rest_Temporalmesas where auto_jornada=@jornada", xcon)
                                        xcmd.Parameters.AddWithValue("@jornada", _AutoJornada)
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
                            Throw New Exception("CUENTAS PENDIENTES JORNADA" + vbCrLf + ex.Message)
                        End Try
                    End Function

                    Function f_TieneCuentasPendientes_POSONLINE() As Boolean
                        Dim xr As Integer = 0
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Using xcmd As New SqlCommand("select count(*) from POS_VENTA_PENDENCABEZADO where auto_jornada=@jornada", xcon)
                                        xcmd.Parameters.AddWithValue("@jornada", _AutoJornada)
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
                            Throw New Exception("PROBLEMA AL VERIFICAR CUENTAS PENDIENTES POS-ONLINE" + vbCrLf + ex.Message)
                        End Try
                    End Function

                End Class

                Friend Const INSERT_JORNADA As String = "INSERT INTO Jornada (" _
                    + "auto," _
                    + "serialfiscal," _
                    + "fecha_apert," _
                    + "hora_apert," _
                    + "auto_usuario_apert," _
                    + "codigo_usuario_apert," _
                    + "nombre_usuario_apert," _
                    + "grupo_usuario_apert," _
                    + "estacion_apert," _
                    + "estatus," _
                    + "fecha_cierre," _
                    + "hora_cierre," _
                    + "auto_usuario_cierre," _
                    + "codigo_usuario_cierre," _
                    + "nombre_usuario_cierre," _
                    + "grupo_usuario_cierre," _
                    + "totaldoc_ventas," _
                    + "totaldoc_nc," _
                    + "totalventas," _
                    + "totalnc) " _
                    + "Values (" _
                    + "@auto," _
                    + "@serialfiscal," _
                    + "@fecha_apert," _
                    + "@hora_apert," _
                    + "@auto_usuario_apert," _
                    + "@codigo_usuario_apert," _
                    + "@nombre_usuario_apert," _
                    + "@grupo_usuario_apert," _
                    + "@estacion_apert," _
                    + "@estatus," _
                    + "@fecha_cierre," _
                    + "@hora_cierre," _
                    + "@auto_usuario_cierre," _
                    + "@codigo_usuario_cierre," _
                    + "@nombre_usuario_cierre," _
                    + "@grupo_usuario_cierre," _
                    + "@totaldoc_ventas," _
                    + "@totaldoc_nc," _
                    + "@totalventas," _
                    + "@totalnc) "

                Friend Const CERRAR_JORNADA As String = "update jornada set " & _
                  "estatus=@estatus, " & _
                  "fecha_cierre=@fecha_cierre,  " & _
                  "hora_cierre=@hora_cierre, " & _
                  "auto_usuario_cierre=@auto_usuario_cierre, " & _
                  "codigo_usuario_cierre=@codigo_usuario_cierre, " & _
                  "nombre_usuario_cierre=@nombre_usuario_cierre, " & _
                  "grupo_usuario_cierre=@grupo_usuario_cierre, " & _
                  "totaldoc_ventas=@totaldoc_ventas, " & _
                  "totaldoc_nc=@totaldoc_nc, " & _
                  "totalventas=@totalventas, " & _
                  "totalnc=@totalnc " & _
                  "where auto=@jornada"

                Friend Const ELIMINAR_JORNADAACTIVA As String = "delete jornadaActiva where auto_jornada=@jornada"

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
                            xadap.SelectCommand.CommandText = "select * from jornada where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count >= 1 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                        Else
                            Throw New Exception("AUTO JORNADA NO ENCONTRADO.. VERIFIQUE")
                        End If
                    Catch ex As Exception
                        Throw New Exception("FASTFOOD:" + vbCrLf + "JORNADA" + vbCrLf + "Funcion: BUSCAR / CARGAR" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class JornadaActiva
                Class c_Registro
                    Private f_auto_jornada As CampoDato
                    Private f_serialfiscal As CampoDato

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

                    Property c_SerialFiscal() As CampoDato
                        Get
                            Return f_serialfiscal
                        End Get
                        Set(ByVal value As CampoDato)
                            f_serialfiscal = value
                        End Set
                    End Property

                    ReadOnly Property _SerialFiscal() As String
                        Get
                            Dim xv As String = IIf(Me.f_serialfiscal._RetornarValor(Of String)() Is Nothing, "", Me.f_serialfiscal._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_SerialFiscal = New CampoDato("serialfiscal", 15)

                        M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase JORNADA-ACTIVA" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_SerialFiscal._ContenidoCampo = xrow(.c_SerialFiscal._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("FASTFOOD" + vbCrLf + "JORNADA-ACTIVA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Friend Const INSERT_JORNADA_ACTIVA As String = "INSERT INTO JornadaActiva (" & _
                    "auto_jornada," & _
                    "serialfiscal) " & _
                    "VALUES (" & _
                    "@auto_jornada," & _
                    "@serialfiscal)"

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

            ''' <summary>
            ''' Usada Para La Apertura De Jornada
            ''' </summary>
            Public Class AbrirJornada
                Private xserialfiscal As String
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xestacion As String

                Property _SerialImpFiscal() As String
                    Get
                        Return Me.xserialfiscal.Trim
                    End Get
                    Set(ByVal value As String)
                        Me.xserialfiscal = value
                    End Set
                End Property

                Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xusuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xusuario = value
                    End Set
                End Property

                Property _EstacionEquipo() As String
                    Get
                        Return Me.xestacion.Trim
                    End Get
                    Set(ByVal value As String)
                        Me.xestacion = value
                    End Set
                End Property

                Sub New()
                    Me._EstacionEquipo = ""
                    Me._SerialImpFiscal = ""
                    Me._Usuario = Nothing
                End Sub
            End Class

            Public Class CerrarJornada
                Private xusuario As FichaGlobal.c_Usuario.c_Registro
                Private xjornada As FastFood.Jornada.c_Registro
                Private xpermitir_mesas_pedidos_pendientes As Boolean

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

                Property _PermitirMesasPedidosPendientes() As Boolean
                    Get
                        Return xpermitir_mesas_pedidos_pendientes
                    End Get
                    Set(ByVal value As Boolean)
                        xpermitir_mesas_pedidos_pendientes = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("select getdate()")
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("select getdate()").ToShortTimeString
                    End Get
                End Property

                Protected Friend ReadOnly Property _TotalVentas() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.CommandText = "select sum(total) from ventas where auto_jornada=@jornada and tipo='01' and estatus='0'"
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
                            Throw New Exception("CERRAR JORNADA:" & vbCrLf & "TOTAL VENTAS:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                Protected Friend ReadOnly Property _TotalDocVentas() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.CommandText = "select count(*) from ventas where auto_jornada=@jornada and tipo='01' and estatus='0'"
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
                            Throw New Exception("CERRAR JORNADA:" & vbCrLf & "TOTAL DOC VENTAS:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                Protected Friend ReadOnly Property _TotalNC() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.CommandText = "select sum(total) from ventas where auto_jornada=@jornada and tipo='03' and estatus='0'"
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
                            Throw New Exception("CERRAR JORNADA:" & vbCrLf & "TOTAL NC:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                Protected Friend ReadOnly Property _TotalDocNC() As Decimal
                    Get
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Try
                                    Dim xobj As Object = Nothing
                                    Using xcmd As New SqlCommand("", xcon)
                                        xcmd.Parameters.Clear()
                                        xcmd.Parameters.AddWithValue("@jornada", _Jornada._AutoJornada)
                                        xcmd.CommandText = "select count(*) from ventas where auto_jornada=@jornada and tipo='03' and estatus='0'"
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
                            Throw New Exception("CERRAR JORNADA:" & vbCrLf & "TOTAL DOC NC:" & vbCrLf & ex.Message)
                        End Try
                    End Get
                End Property

                Sub New()
                    Me._Jornada = Nothing
                    Me._Usuario = Nothing
                    Me._PermitirMesasPedidosPendientes = False
                End Sub
            End Class

        End Class
    End Class
End Namespace


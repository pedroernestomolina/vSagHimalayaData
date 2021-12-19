Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FastFood

            Public Class EstacionFastFood
                Event _ActualizarTabla()

                Class Agregar
                    Private xnombre As String
                    Private xruta As String
                    Private xestatus As TipoEstatus

                    Property _NombreEstacion() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _RutaEstacion() As String
                        Get
                            Return xruta
                        End Get
                        Set(ByVal value As String)
                            xruta = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    Sub New()
                        Me._Estatus = 0
                        Me._NombreEstacion = ""
                        Me._RutaEstacion = ""
                    End Sub
                End Class
                Class Modificar
                    Private xestacion As c_Registro
                    Private xnombre As String
                    Private xruta As String
                    Private xestatus As TipoEstatus

                    Property _NombreEstacion() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _RutaEstacion() As String
                        Get
                            Return xruta
                        End Get
                        Set(ByVal value As String)
                            xruta = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    Property _FichaOrigen() As c_Registro
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As c_Registro)
                            xestacion = value
                        End Set
                    End Property

                    Sub New()
                        Me._Estatus = 0
                        Me._FichaOrigen = Nothing
                        Me._NombreEstacion = ""
                        Me._RutaEstacion = ""
                    End Sub
                End Class
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_nombre As CampoDato
                    Private f_ruta As CampoDato
                    Private f_estatus As CampoDato
                    Private f_id_seguridad As Byte()

                    Property c_Automatico() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    Property c_NombreEstacion() As CampoDato
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_RutaEstacion() As CampoDato
                        Get
                            Return f_ruta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_ruta = value
                        End Set
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _RutaEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.f_ruta._RetornarValor(Of String)() Is Nothing, "", Me.f_ruta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase ESTACIONES - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoDato("auto", 10)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_NombreEstacion = New CampoDato("nombre", 20)
                        Me.c_RutaEstacion = New CampoDato("ruta", 250)

                        M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Automatico._ContenidoCampo = xrow(.c_Automatico._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_NombreEstacion._ContenidoCampo = xrow(.c_NombreEstacion._NombreCampo)
                                .c_RutaEstacion._ContenidoCampo = xrow(.c_RutaEstacion._NombreCampo)
                                .c_IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("ESTACION FASTFOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    RegistroDato = New c_Registro
                End Sub

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarCargar(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from estacion_fastfood where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count >= 1 Then
                            Me.M_CargarFicha(xtb.Rows(0))
                        Else
                            Throw New Exception("ESTACION COMANDA NO ENCONTRADO.. VERIFIQUE")
                        End If
                    Catch ex As Exception
                        Throw New Exception("FASTFOOD:" + vbCrLf + "ESTACION COMANDA" + vbCrLf + "Funcion: BUSCAR / CARGAR" + vbCrLf + ex.Message)
                    End Try
                End Function


                Protected Friend Const InsertarEstacionComanda As String = "insert into estacion_fastfood (auto, nombre, ruta, estatus) " _
                                            + "values(@auto,@nombre,@ruta,@estatus)"

                Protected Friend Const EliminarEstacionComanda As String = "delete from estacion_fastfood where auto=@auto and id_seguridad=@id"

                Protected Friend Const ActualizarEstacion As String = "update estacion_fastfood set nombre=@nombre, " _
                                              + "ruta=@ruta, estatus=@estatus where auto=@auto and id_seguridad=@id "


                Function F_AgregarEstacionComanda(ByVal xreg As Agregar) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_estacion_fastfood=a_estacion_fastfood+1; select a_estacion_fastfood from contadores"
                        Dim xestacion As New c_Registro
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        With xestacion
                            .c_Automatico._ContenidoCampo = ""
                            If xreg._Estatus = TipoEstatus.Activo Then
                                .c_Estatus._ContenidoCampo = "0"
                            Else
                                .c_Estatus._ContenidoCampo = "1"
                            End If
                            .c_NombreEstacion._ContenidoCampo = xreg._NombreEstacion
                            .c_RutaEstacion._ContenidoCampo = xreg._RutaEstacion
                        End With

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.CommandText = "select a_estacion_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_estacion_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = xsql_1
                                    xestacion.c_Automatico._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarEstacionComanda
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_Automatico._NombreCampo, xestacion._Automatico).Size = xestacion.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_Estatus._NombreCampo, xestacion.c_Estatus._ContenidoCampo).Size = xestacion.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_NombreEstacion._NombreCampo, xestacion._NombreEstacion).Size = xestacion.c_NombreEstacion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_RutaEstacion._NombreCampo, xestacion._RutaEstacion).Size = xestacion.c_RutaEstacion._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE DE LA ESTACION YA EXISTENTE, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRABAR ESTACION/COMANDA FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarEstacionComanda(ByVal xestacion As c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarEstacionComanda
                                    xcmd.Parameters.AddWithValue("@auto", xestacion._Automatico)
                                    xcmd.Parameters.AddWithValue("@id", xestacion._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()
                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... LA ESTACION FUE ACTUALIZADA / ELIMINADA POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 547 Then
                                    Throw New Exception("ERROR... LA ESTACION NO PUEDE SER ELIMINADA, POSEE PLATOS RELACIONADOS")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ELIMINAR ESTACION/COMANDA FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarEstacionComanda(ByVal xreg As Modificar) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xestacion As New c_Registro
                        Dim xobj As Object = Nothing

                        With xestacion
                            .c_Automatico._ContenidoCampo = xreg._FichaOrigen._Automatico
                            If xreg._Estatus = TipoEstatus.Activo Then
                                .c_Estatus._ContenidoCampo = "0"
                            Else
                                .c_Estatus._ContenidoCampo = "1"
                            End If
                            .c_NombreEstacion._ContenidoCampo = xreg._NombreEstacion
                            .c_RutaEstacion._ContenidoCampo = xreg._RutaEstacion
                            .c_IdSeguridad = xreg._FichaOrigen._IdSeguridad
                        End With

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarEstacion
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_Automatico._NombreCampo, xestacion._Automatico).Size = xestacion.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_Estatus._NombreCampo, xestacion.c_Estatus._ContenidoCampo).Size = xestacion.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_NombreEstacion._NombreCampo, xestacion._NombreEstacion).Size = xestacion.c_NombreEstacion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xestacion.c_RutaEstacion._NombreCampo, xestacion._RutaEstacion).Size = xestacion.c_RutaEstacion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@id", xestacion._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()
                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... LA ESTACION FUE ACTUALIZADA / ELIMINADA POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE DE LA ESTACION YA EXISTENTE, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS" + vbCrLf + "MODIFICAR ESTACION" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class MenuPlatoEstacion
                Event _ActualizarTablaPlatoEstacion()

                Class Agregar
                    Private xAutoEstacion As String
                    Private xAutoPlato As String
                    Private xEstatus As TipoEstatus

                    Property _AutoEstacion() As String
                        Get
                            Return xAutoEstacion
                        End Get
                        Set(ByVal value As String)
                            xAutoEstacion = value
                        End Set
                    End Property

                    Property _AutoPlato() As String
                        Get
                            Return xAutoPlato
                        End Get
                        Set(ByVal value As String)
                            xAutoPlato = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xEstatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xEstatus = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoEstacion = ""
                        Me._AutoPlato = ""
                        Me._Estatus = 0
                    End Sub
                End Class
                Class Modificar
                    Private xauto_estacion As String
                    Private xestatus As String
                    Private xficha As c_Registro

                    Property _AutoEstacion() As String
                        Get
                            Return xauto_estacion
                        End Get
                        Set(ByVal value As String)
                            xauto_estacion = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    Property _FichaOrigen() As c_Registro
                        Get
                            Return xficha
                        End Get
                        Set(ByVal value As c_Registro)
                            xficha = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoEstacion = ""
                        Me._Estatus = 0
                        Me._FichaOrigen = Nothing
                    End Sub
                End Class
                Class c_Registro
                    Private f_auto_plato As CampoDato
                    Private f_auto_estacion As CampoDato
                    Private f_auto As CampoDato
                    Private f_estatus As CampoDato
                    Private f_id_seguridad As Byte()

                    Property c_Automatico() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    Property c_AutoEstacion() As CampoDato
                        Get
                            Return f_auto_estacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_estacion = value
                        End Set
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoEstacion() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_estacion._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_estacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Dim xv As String = ""
                            Dim xp1 As New SqlParameter("@auto", _AutoEstacion)
                            Try
                                xv = F_GetString("select nombre from estacion_fastfood where auto=@auto", xp1)
                            Catch ex As Exception
                            End Try
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Ruta() As String
                        Get
                            Dim xv As String = ""
                            Dim xp1 As New SqlParameter("@auto", _AutoEstacion)
                            Try
                                xv = F_GetString("select ruta from estacion_fastfood where auto=@auto", xp1)
                            Catch ex As Exception
                            End Try
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase MENU PLATO ESTACION - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        With Me
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_AutoEstacion = New CampoDato("auto_estacion", 10)
                            .c_Automatico = New CampoDato("auto", 10)
                            .c_Estatus = New CampoDato("estatus", 1)

                            .M_Limpiar()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()
                                .c_AutoEstacion._ContenidoCampo = xrow(.c_AutoEstacion._NombreCampo)
                                .c_Automatico._ContenidoCampo = xrow(.c_Automatico._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU PLATO ESTACION" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    RegistroDato = New c_Registro
                End Sub

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub


                Protected Friend Const InsertarPlatoEstacion As String = "insert into menuestaciones_fastfood (auto, auto_estacion, auto_plato, estatus) " _
                                            + "values(@auto,@auto_estacion,@auto_plato,@estatus)"

                Protected Friend Const EliminarPlatoEstacion As String = "delete from menuestaciones_fastfood where auto=@auto and id_seguridad=@id"

                Protected Friend Const ActualizarPlatoEstacion As String = "update menuestaciones_fastfood set auto_estacion=@auto_estacion, " _
                                              + "estatus=@estatus where auto=@auto and id_seguridad=@id "


                Function F_AgregarPlatoEstacion(ByVal xreg As Agregar) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_menuestacion_fastfood=a_menuestacion_fastfood+1; select a_menuestacion_fastfood from contadores"
                        Dim xplatoestacion As New c_Registro
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        With xplatoestacion
                            .c_AutoEstacion._ContenidoCampo = xreg._AutoEstacion
                            .c_Automatico._ContenidoCampo = ""
                            .c_AutoPlato._ContenidoCampo = xreg._AutoPlato
                            If xreg._Estatus = TipoEstatus.Activo Then
                                .c_Estatus._ContenidoCampo = "0"
                            Else
                                .c_Estatus._ContenidoCampo = "1"
                            End If
                        End With

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.CommandText = "select a_menuestacion_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_menuestacion_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = xsql_1
                                    xplatoestacion.c_Automatico._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarPlatoEstacion
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_AutoEstacion._NombreCampo, xplatoestacion._AutoEstacion).Size = xplatoestacion.c_AutoEstacion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_Automatico._NombreCampo, xplatoestacion._Automatico).Size = xplatoestacion.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_AutoPlato._NombreCampo, xplatoestacion._AutoPlato).Size = xplatoestacion.c_AutoPlato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_Estatus._NombreCampo, xplatoestacion.c_Estatus._ContenidoCampo).Size = xplatoestacion.c_Estatus._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTablaPlatoEstacion()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... ESTACION YA EXISTENTE PARA ESTE PLATO, POR FAVOR VERIFIQUE")
                                ElseIf ex.Number = 547 Then
                                    Throw New Exception("ERROR... ESTACION/COMANDA FUE ELIMINADA POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message + vbCrLf + ex.Number.ToString)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRABAR PLATO - ESTACION FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarPlatoEstacion(ByVal xreg As c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarPlatoEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xreg._Automatico)
                                    xcmd.Parameters.AddWithValue("@id", xreg.c_IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL PLATO - ESTACION FUE ACTUALIZADO / ELIMINADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTablaPlatoEstacion()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 547 Then
                                    Throw New Exception("ERROR... LA ESTACION NO PUEDE SER ELIMINADA, POSEE PLATOS RELACIONADOS")
                                Else
                                    Throw New Exception(ex.Message)
                                End If

                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ELIMINAR PLATO-ESTACION FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarPlatoEstacion(ByVal xreg As Modificar) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing
                        Dim xplatoestacion As New c_Registro

                        With xplatoestacion
                            .c_AutoEstacion._ContenidoCampo = xreg._AutoEstacion
                            .c_Automatico._ContenidoCampo = xreg._FichaOrigen._Automatico
                            .c_AutoPlato._ContenidoCampo = xreg._FichaOrigen._AutoPlato
                            If xreg._Estatus = TipoEstatus.Activo Then
                                .c_Estatus._ContenidoCampo = "0"
                            Else
                                .c_Estatus._ContenidoCampo = "1"
                            End If
                            .c_IdSeguridad = xreg._FichaOrigen._IdSeguridad
                        End With


                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarPlatoEstacion
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_AutoEstacion._NombreCampo, xplatoestacion._AutoEstacion).Size = xplatoestacion.c_AutoEstacion._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_Automatico._NombreCampo, xplatoestacion._Automatico).Size = xplatoestacion.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_AutoPlato._NombreCampo, xplatoestacion._AutoPlato).Size = xplatoestacion.c_AutoPlato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xplatoestacion.c_Estatus._NombreCampo, xplatoestacion.c_Estatus._ContenidoCampo).Size = xplatoestacion.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@id", xplatoestacion._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()
                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL PLATO - ESTACION FUE ACTUALIZADO / ELIMINADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTablaPlatoEstacion()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... ESTACION YA EXISTENTE PARA ESTE PLATO, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MODIFICAR PLATO-ESTACION FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

        End Class
    End Class
End Namespace

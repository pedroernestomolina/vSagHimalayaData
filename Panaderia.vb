Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class FichaPanaderia
            Enum TipoEstatusTarjeta As Integer
                Activa = 1
                Bloqueada = 2
            End Enum

            Public Class Tarjeta
                Event _AbrirTarjeta()

                Class c_AgregarRegistro
                    Private xregistro As c_Registro

                    Protected Friend Property Registro() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        Registro = New c_Registro
                    End Sub

                    WriteOnly Property _IdTarjeta() As String
                        Set(ByVal value As String)
                            Me.Registro.c_IdTarjeta.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Hora() As String
                        Set(ByVal value As String)
                            Me.Registro.c_Hora.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fecha() As Date
                        Set(ByVal value As Date)
                            Me.Registro.c_Fecha.c_Valor = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_id As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_hora As CampoTexto
                    Private f_monto As CampoDecimal
                    Private f_items As CampoInteger
                    Private f_estatus As CampoTexto

                    Protected Friend Property c_IdTarjeta() As CampoTexto
                        Get
                            Return f_id
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_id = value
                        End Set
                    End Property

                    ReadOnly Property _IdTarjeta() As String
                        Get
                            Return Me.c_IdTarjeta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Fecha() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Return Me.c_Fecha.c_Valor
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

                    ReadOnly Property _Hora() As String
                        Get
                            Return Me.c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_TotalMonto() As CampoDecimal
                        Get
                            Return f_monto
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_monto = value
                        End Set
                    End Property

                    ReadOnly Property _MontoTotal() As Decimal
                        Get
                            Return Me.c_TotalMonto.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Items() As CampoInteger
                        Get
                            Return f_items
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_items = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadItems() As Integer
                        Get
                            Return Me.c_Items.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusTarjeta() As TipoEstatusTarjeta
                        Get
                            Select Case Me.c_Estatus.c_Texto.Trim.ToUpper
                                Case "0"
                                    Return TipoEstatusTarjeta.Activa
                                Case "1"
                                    Return TipoEstatusTarjeta.Bloqueada
                            End Select
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_IdTarjeta = New CampoTexto(5, "id")
                        Me.c_Fecha = New CampoFecha("fecha")
                        Me.c_Hora = New CampoTexto(10, "hora")
                        Me.c_TotalMonto = New CampoDecimal("monto")
                        Me.c_Items = New CampoInteger("items")
                        Me.c_Estatus = New CampoTexto(1, "estatus")

                        Me.LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()

                            With Me
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_Fecha.c_Valor = xrow(.c_Fecha.c_NombreInterno)
                                .c_Hora.c_Texto = xrow(.c_Hora.c_NombreInterno)
                                .c_IdTarjeta.c_Texto = xrow(.c_IdTarjeta.c_NombreInterno)
                                .c_Items.c_Valor = xrow(.c_Items.c_NombreInterno)
                                .c_TotalMonto.c_Valor = xrow(.c_TotalMonto.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PANADERIA TARJETA" + vbCrLf + "CARGAR REGISTRO:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Const INSERT_TARJETA As String = "INSERT INTO PanaderiaTarjeta (" & _
                            "Id," & _
                            "Fecha," & _
                            "Hora," & _
                            "Monto," & _
                            "Items," & _
                            "Estatus)" & _
                            "VALUES (" & _
                            "@Id," & _
                            "@Fecha," & _
                            "@Hora," & _
                            "@Monto," & _
                            "@Items," & _
                            "@Estatus)"


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

                Function F_CargarRegistro(ByVal xid As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from panaderiatarjeta where id=@idtarjeta"
                            xadap.SelectCommand.Parameters.AddWithValue("@idtarjeta", xid).Size = Me.RegistroDato.c_IdTarjeta.c_Largo
                            xadap.Fill(xtb)
                            If xtb.Rows.Count = 0 Then
                                Throw New Exception("TARJETA NO ECONTRADA / FUE ELIMINADA POR OTRO USUARIO")
                            End If
                        End Using

                        With Me.RegistroDato
                            .CargarRegistro(xtb(0))
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Function F_BuscarAbrirCrearTarjeta(ByVal xreg As c_AgregarRegistro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction

                                Dim xrt As Object = Nothing
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select id from panaderiatarjeta where id=@idtarjeta"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                    xrt = xcmd.ExecuteScalar()

                                    If IsNothing(xrt) Then  ' NO ESTA CREADA , SE CREA
                                        xreg.Registro.c_Estatus.c_Texto = "1"
                                        xreg.Registro.c_Items.c_Valor = 0
                                        xreg.Registro.c_TotalMonto.c_Valor = 0

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_TARJETA
                                        xcmd.Parameters.AddWithValue("@id", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xreg.Registro.c_Fecha.c_Valor)
                                        xcmd.Parameters.AddWithValue("@hora", xreg.Registro.c_Hora.c_Texto).Size = xreg.Registro.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@monto", xreg.Registro.c_TotalMonto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@items", xreg.Registro.c_Items.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus", xreg.Registro.c_Estatus.c_Texto).Size = xreg.Registro.c_Estatus.c_Largo
                                        xcmd.ExecuteNonQuery()
                                    Else ' SI YA EXISTE 
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select estatus  from panaderiatarjeta where id=@idtarjeta"
                                        xcmd.Parameters.AddWithValue("@idtarjeta", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                        If xcmd.ExecuteScalar.ToString.Trim.ToUpper = "0" Then  ' SI NO ESTA BLOQUEADA
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update panaderiatarjeta set estatus='1' where id=@id"
                                            xcmd.Parameters.AddWithValue("@id", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                            xcmd.ExecuteNonQuery()
                                        Else ' SI ESTA BLOQUEADA
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select monto from panaderiatarjeta where id=@idtarjeta"
                                            xcmd.Parameters.AddWithValue("@idtarjeta", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                            If xcmd.ExecuteScalar > 0 Then  ' EL MONTO ES MAYOR A CERO 
                                                Throw New Exception("TARJETA BLOQUEADO POR OTRO USUARIO")
                                            Else ' SE PUEDE USAR
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "update panaderiatarjeta set estatus='1' where id=@id"
                                                xcmd.Parameters.AddWithValue("@id", xreg.Registro.c_IdTarjeta.c_Texto).Size = xreg.Registro.c_IdTarjeta.c_Largo
                                                xcmd.ExecuteNonQuery()
                                            End If
                                        End If
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _AbrirTarjeta()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Throw New Exception(ex2.Message & "," & ex2.Number)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA" + vbCrLf + "BUSCAR ABRIR CREAR TARJETA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_DesbloquearTarjeta(ByVal xid As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update panaderiatarjeta set estatus='0' where id=@idtarjeta and estatus='1'"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xid).Size = Me.RegistroDato.c_IdTarjeta.c_Largo
                                    xr = xcmd.ExecuteNonQuery
                                    If xr = 0 Then
                                        Throw New Exception("TARJETA NO ENCONTRADA / TARJETA HA SIDO DESBLOQUEADA POR OTRO USUARIO. VERIFIQUE POR FAVOR !!!")
                                    End If
                                End Using
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message & "," & ex2.Number)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA" + vbCrLf + "DESBLOQUEAR LIMPIAR TARJETA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_CantidadTarjetasAbiertas() As Integer
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select count(*) from panaderiatarjeta where monto>0"
                                    xr = xcmd.ExecuteScalar
                                End Using
                                Return xr
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message & "," & ex2.Number)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA" + vbCrLf + "CANTIDAD DE TARJETAS ABIERTAS" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class TarjetaAnulada
                Event _TarjetaProcesada()

                Class c_AnularTarjeta
                    Private xid As String
                    Private xfecha As Date
                    Private xhora As String
                    Private xmotivo As String
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xestacion As String

                    Property _IdTarjeta() As String
                        Get
                            Return xid
                        End Get
                        Set(ByVal value As String)
                            xid = value
                        End Set
                    End Property

                    Protected Friend Property _FechaProceso() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Protected Friend Property _Hora() As String
                        Get
                            Return xhora
                        End Get
                        Set(ByVal value As String)
                            xhora = value
                        End Set
                    End Property

                    Property _MotivoAnulacion() As String
                        Get
                            Return xmotivo
                        End Get
                        Set(ByVal value As String)
                            xmotivo = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Sub New()
                        _EstacionEquipo = ""
                        _FechaProceso = F_GetDate("select getdate()")
                        _FichaUsuario = Nothing
                        _Hora = F_GetDate("select getdate()").ToShortTimeString
                        _IdTarjeta = ""
                        _MotivoAnulacion = ""
                    End Sub
                End Class

                Class c_Registro
                    Private f_idtarjeta As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_hora As CampoTexto
                    Private f_motivo As CampoTexto
                    Private f_nombreusuario As CampoTexto
                    Private f_codigousuario As CampoTexto
                    Private f_estacion As CampoTexto

                    Property c_IdTarjeta() As CampoTexto
                        Get
                            Return f_idtarjeta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_idtarjeta = value
                        End Set
                    End Property

                    Property c_Fecha() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    Property c_Motivo() As CampoTexto
                        Get
                            Return f_motivo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_motivo = value
                        End Set
                    End Property

                    Property c_UsuarioNombre() As CampoTexto
                        Get
                            Return f_nombreusuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreusuario = value
                        End Set
                    End Property

                    Property c_UsuarioCodgio() As CampoTexto
                        Get
                            Return f_codigousuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigousuario = value
                        End Set
                    End Property

                    Property c_Estacion() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_IdTarjeta = New CampoTexto(5, "idtarjeta")
                        Me.c_Fecha = New CampoFecha("fecha")
                        Me.c_Hora = New CampoTexto(10, "hora")
                        Me.c_Motivo = New CampoTexto(120, "motivo")
                        Me.c_UsuarioNombre = New CampoTexto(20, "nombreusuario")
                        Me.c_UsuarioCodgio = New CampoTexto(10, "codigousuario")
                        Me.c_Estacion = New CampoTexto(20, "estacion")

                        Me.LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()

                            With Me
                                .c_Estacion.c_Texto = xrow(.c_Estacion.c_NombreInterno)
                                .c_Fecha.c_Valor = xrow(.c_Fecha.c_NombreInterno)
                                .c_Hora.c_Texto = xrow(.c_Hora.c_NombreInterno)
                                .c_IdTarjeta.c_Texto = xrow(.c_IdTarjeta.c_NombreInterno)
                                .c_Motivo.c_Texto = xrow(.c_Motivo.c_NombreInterno)
                                .c_UsuarioCodgio.c_Texto = xrow(.c_UsuarioCodgio.c_NombreInterno)
                                .c_UsuarioNombre.c_Texto = xrow(.c_UsuarioNombre.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PANADERIA TARJETA ANULADA" + vbCrLf + "CARGAR REGISTRO:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_TARJETAANULADA As String = "insert into panaderiatarjetaanulada (" _
                    + "idtarjeta," _
                    + "fecha," _
                    + "hora," _
                    + "motivo," _
                    + "nombreusuario," _
                    + "codigousuario," _
                    + "estacion) " _
                    + "VALUES(" _
                    + "@idtarjeta," _
                    + "@fecha," _
                    + "@hora," _
                    + "@motivo," _
                    + "@nombreusuario," _
                    + "@codigousuario," _
                    + "@estacion) "

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

                Sub M_LimpiarRegistro()
                    Me.M_LimpiarRegistro()
                End Sub

                Function F_CargarRegistro(ByVal xid As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select * from panaderiatarjetaanulada where idtarjeta=@idtarjeta"
                            xadap.SelectCommand.Parameters.AddWithValue("@idtarjeta", xid).Size = Me.RegistroDato.c_IdTarjeta.c_Largo
                            xadap.Fill(xtb)
                            If xtb.Rows.Count = 0 Then
                                Throw New Exception("TARJETA NO ECONTRADA / FUE ELIMINADA POR OTRO USUARIO")
                            End If
                        End Using

                        With Me.RegistroDato
                            .CargarRegistro(xtb(0))
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_VerificarTarjeta(ByVal xid As String) As TipoEstatus
                    Dim xrt As Object = Nothing
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select idtarjeta from panaderiatarjetaanulada where idtarjeta=@idtarjeta"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xid)
                                    xrt = xcmd.ExecuteScalar()

                                    If IsNothing(xrt) Then
                                        Return TipoEstatus.Activo
                                    Else
                                        Throw New Exception("ERROR... TARJETA ESTA ANULADA... VERIFIQUE POR FAVOR")
                                    End If
                                End Using
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA ANULADA" + vbCrLf + "VERIFICAR TARJETA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActivarTarjeta(ByVal xid As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction

                                Dim xrt As Object = Nothing
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xobj As Object = Nothing

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from panaderiatarjetaanulada where idtarjeta=@id "
                                    xcmd.Parameters.AddWithValue("@id", xid)
                                    xobj = xcmd.ExecuteNonQuery

                                    If xobj = 0 Or xobj Is Nothing Then
                                        Throw New Exception("TARJETA NO ENCONTRADA / FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using

                                xtr.Commit()
                                RaiseEvent _TarjetaProcesada()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Throw New Exception(ex2.Message & "," & ex2.Number)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA" + vbCrLf + "ACTIVAR TARJETA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AnularTarjeta(ByVal xgrabar As c_AnularTarjeta) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction

                                Dim xrt As Object = Nothing
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    Dim xreg As New TarjetaAnulada.c_Registro
                                    With xreg
                                        .c_Estacion.c_Texto = xgrabar._EstacionEquipo
                                        .c_Fecha.c_Valor = xgrabar._FechaProceso
                                        .c_Hora.c_Texto = xgrabar._Hora
                                        .c_IdTarjeta.c_Texto = xgrabar._IdTarjeta
                                        .c_Motivo.c_Texto = xgrabar._MotivoAnulacion
                                        .c_UsuarioCodgio.c_Texto = xgrabar._FichaUsuario._CodigoUsuario
                                        .c_UsuarioNombre.c_Texto = xgrabar._FichaUsuario._NombreUsuario
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_TARJETAANULADA
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xreg.c_IdTarjeta.c_Texto).Size = xreg.c_IdTarjeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xreg.c_Fecha.c_Valor)
                                    xcmd.Parameters.AddWithValue("@hora", xreg.c_Hora.c_Texto).Size = xreg.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@motivo", xreg.c_Motivo.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nombreusuario", xreg.c_UsuarioNombre.c_Texto).Size = xreg.c_UsuarioNombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigousuario", xreg.c_UsuarioCodgio.c_Texto).Size = xreg.c_UsuarioCodgio.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xreg.c_Estacion.c_Texto).Size = xreg.c_Estacion.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    Dim xobj As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select count(*) from panaderiatarjeta where id=@id and monto>0"
                                    xcmd.Parameters.AddWithValue("@id", xreg.c_IdTarjeta.c_Texto).Size = xreg.c_IdTarjeta.c_Largo
                                    xobj = xcmd.ExecuteScalar
                                    If xobj > 0 Then
                                        Throw New Exception("DISCULPE ESTA TARJETA POSEE UN PEDIDO, DEBE ANULAR EL PEDIDO PRIMERO")
                                    End If

                                    Dim xreg_1 As New TarjetaAnulada_Historico.c_Registro
                                    With xreg_1
                                        .c_Estacion.c_Texto = xgrabar._EstacionEquipo
                                        .c_Fecha.c_Valor = xgrabar._FechaProceso
                                        .c_Hora.c_Texto = xgrabar._Hora
                                        .c_IdTarjeta.c_Texto = xgrabar._IdTarjeta
                                        .c_Motivo.c_Texto = xgrabar._MotivoAnulacion
                                        .c_UsuarioCodgio.c_Texto = xgrabar._FichaUsuario._CodigoUsuario
                                        .c_UsuarioNombre.c_Texto = xgrabar._FichaUsuario._NombreUsuario
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = TarjetaAnulada_Historico.INSERT_TARJETAANULADA_HISTORICO
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xreg_1.c_IdTarjeta.c_Texto).Size = xreg_1.c_IdTarjeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xreg_1.c_Fecha.c_Valor)
                                    xcmd.Parameters.AddWithValue("@hora", xreg_1.c_Hora.c_Texto).Size = xreg_1.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@motivo", xreg_1.c_Motivo.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nombreusuario", xreg_1.c_UsuarioNombre.c_Texto).Size = xreg_1.c_UsuarioNombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigousuario", xreg_1.c_UsuarioCodgio.c_Texto).Size = xreg_1.c_UsuarioCodgio.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xreg_1.c_Estacion.c_Texto).Size = xreg_1.c_Estacion.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _TarjetaProcesada()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2627 Then
                                    Throw New Exception("TARJETA YA SE ENCUENTRA ANULADA... VERIFIQUE POR FAVOR")
                                Else
                                    Throw New Exception(ex2.Message & "," & ex2.Number)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA TARJETA" + vbCrLf + "ANULAR TARJETA" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class TarjetaAnulada_Historico
                Class c_Registro
                    Private f_idtarjeta As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_hora As CampoTexto
                    Private f_motivo As CampoTexto
                    Private f_nombreusuario As CampoTexto
                    Private f_codigousuario As CampoTexto
                    Private f_estacion As CampoTexto

                    Property c_IdTarjeta() As CampoTexto
                        Get
                            Return f_idtarjeta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_idtarjeta = value
                        End Set
                    End Property

                    Property c_Fecha() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    Property c_Motivo() As CampoTexto
                        Get
                            Return f_motivo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_motivo = value
                        End Set
                    End Property

                    Property c_UsuarioNombre() As CampoTexto
                        Get
                            Return f_nombreusuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombreusuario = value
                        End Set
                    End Property

                    Property c_UsuarioCodgio() As CampoTexto
                        Get
                            Return f_codigousuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigousuario = value
                        End Set
                    End Property

                    Property c_Estacion() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_IdTarjeta = New CampoTexto(5, "idtarjeta")
                        Me.c_Fecha = New CampoFecha("fecha")
                        Me.c_Hora = New CampoTexto(10, "hora")
                        Me.c_Motivo = New CampoTexto(120, "motivo")
                        Me.c_UsuarioNombre = New CampoTexto(20, "nombreusuario")
                        Me.c_UsuarioCodgio = New CampoTexto(10, "codigousuario")
                        Me.c_Estacion = New CampoTexto(20, "estacion")

                        Me.LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()

                            With Me
                                .c_Estacion.c_Texto = xrow(.c_Estacion.c_NombreInterno)
                                .c_Fecha.c_Valor = xrow(.c_Fecha.c_NombreInterno)
                                .c_Hora.c_Texto = xrow(.c_Hora.c_NombreInterno)
                                .c_IdTarjeta.c_Texto = xrow(.c_IdTarjeta.c_NombreInterno)
                                .c_Motivo.c_Texto = xrow(.c_Motivo.c_NombreInterno)
                                .c_UsuarioCodgio.c_Texto = xrow(.c_UsuarioCodgio.c_NombreInterno)
                                .c_UsuarioNombre.c_Texto = xrow(.c_UsuarioNombre.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PANADERIA TARJETA ANULADA HISTORICO" + vbCrLf + "CARGAR REGISTRO:" + vbCrLf + ex.Message)
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

                Sub M_LimpiarRegistro()
                    Me.M_LimpiarRegistro()
                End Sub

                Protected Friend Const INSERT_TARJETAANULADA_HISTORICO As String = "insert into panaderiatarjetaanulada_historico (" _
                    + "idtarjeta," _
                    + "fecha," _
                    + "hora," _
                    + "motivo," _
                    + "nombreusuario," _
                    + "codigousuario," _
                    + "estacion) " _
                    + "VALUES(" _
                    + "@idtarjeta," _
                    + "@fecha," _
                    + "@hora," _
                    + "@motivo," _
                    + "@nombreusuario," _
                    + "@codigousuario," _
                    + "@estacion) "
            End Class

            Public Class PedidoDetalles
                Event _ActualizarPedidoDetalle()
                Event _RetornaAutoPedidoDetalle(ByVal xauto As String)

                Class AgregarDetalle
                    Private xfichaproducto As FichaProducto.Prd_Producto.c_Registro
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xcantidad As Decimal
                    Private xcodigobarra As String
                    Private xplu As String
                    Private xidtarjeta As String
                    Private xfechaproceso As Date
                    Private xhoraproceso As String
                    Private xequipo As String
                    Private xprecioventaneto As Decimal
                    Private xcontenidoempaqventa As Integer
                    Private xreferenciaempaqventa As String
                    Private xnombremedidaempaqventa As String
                    Private xautomedidaempaqventa As String
                    Private xprecioventanetoregular As Decimal
                    Private xdecimalesmostrar As Integer

                    Property _FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                        Protected Friend Get
                            Return Me.xfichaproducto
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                            Me.xfichaproducto = value
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

                    Property _Cantidad() As Decimal
                        Protected Friend Get
                            Return Me.xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcantidad = value
                        End Set
                    End Property

                    Property _CodigoBarra() As String
                        Protected Friend Get
                            Return Me.xcodigobarra
                        End Get
                        Set(ByVal value As String)
                            Me.xcodigobarra = value
                        End Set
                    End Property

                    Property _Plu() As String
                        Protected Friend Get
                            Return Me.xplu
                        End Get
                        Set(ByVal value As String)
                            Me.xplu = value
                        End Set
                    End Property

                    Property _IdTarjeta() As String
                        Protected Friend Get
                            Return Me.xidtarjeta
                        End Get
                        Set(ByVal value As String)
                            Me.xidtarjeta = value
                        End Set
                    End Property

                    Protected Friend Property _FechaProceso() As Date
                        Get
                            Return Me.xfechaproceso
                        End Get
                        Set(ByVal value As Date)
                            Me.xfechaproceso = value
                        End Set
                    End Property

                    Protected Friend Property _HoraProceso() As String
                        Get
                            Return Me.xhoraproceso
                        End Get
                        Set(ByVal value As String)
                            Me.xhoraproceso = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return Me.xequipo
                        End Get
                        Set(ByVal value As String)
                            Me.xequipo = value
                        End Set
                    End Property

                    Property _PrecioVentaNeto() As Decimal
                        Protected Friend Get
                            Return Me.xprecioventaneto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xprecioventaneto = value
                        End Set
                    End Property

                    Property _ContenidoEmpaqVenta() As Integer
                        Protected Friend Get
                            Return Me.xcontenidoempaqventa
                        End Get
                        Set(ByVal value As Integer)
                            Me.xcontenidoempaqventa = value
                        End Set
                    End Property

                    Property _ReferenciaEmpaqVenta() As String
                        Protected Friend Get
                            Return Me.xreferenciaempaqventa
                        End Get
                        Set(ByVal value As String)
                            Me.xreferenciaempaqventa = value
                        End Set
                    End Property

                    Property _NombreMedidaEmpaqVenta() As String
                        Protected Friend Get
                            Return Me.xnombremedidaempaqventa
                        End Get
                        Set(ByVal value As String)
                            Me.xnombremedidaempaqventa = value
                        End Set
                    End Property

                    Property _AutoMedidaEmpaqVenta() As String
                        Protected Friend Get
                            Return Me.xautomedidaempaqventa
                        End Get
                        Set(ByVal value As String)
                            Me.xautomedidaempaqventa = value
                        End Set
                    End Property

                    Property _PrecioVentaNetoRegular() As Decimal
                        Protected Friend Get
                            Return Me.xprecioventanetoregular
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xprecioventanetoregular = value
                        End Set
                    End Property

                    Property _NumeroDecimalesMostrar() As Integer
                        Protected Friend Get
                            Return Me.xdecimalesmostrar
                        End Get
                        Set(ByVal value As Integer)
                            Me.xdecimalesmostrar = value
                        End Set
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Dim x As Decimal = Me._Cantidad * Me._PrecioVentaNeto
                            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
                            Return x
                        End Get
                    End Property

                    Sub New()
                        Me._Cantidad = 0
                        Me._CodigoBarra = ""
                        Me._EquipoEstacion = ""
                        Me._FechaProceso = F_GetDate("SELECT getdate()")
                        Me._FichaProducto = Nothing
                        Me._FichaUsuario = Nothing
                        Me._HoraProceso = Me._FechaProceso.ToShortTimeString
                        Me._IdTarjeta = ""
                        Me._Plu = ""
                        Me._PrecioVentaNeto = 0

                        Me._AutoMedidaEmpaqVenta = ""
                        Me._ContenidoEmpaqVenta = 0
                        Me._NombreMedidaEmpaqVenta = ""
                        Me._PrecioVentaNetoRegular = 0
                        Me._ReferenciaEmpaqVenta = ""
                        Me._NumeroDecimalesMostrar = 0
                    End Sub
                End Class
                Class c_Registro
                    Private f_producto As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_precionetoventa As CampoDecimal
                    Private f_iva As CampoDecimal
                    Private f_importe As CampoDecimal
                    Private f_esoferta As CampoTexto
                    Private f_espesado As CampoTexto
                    Private f_tipoimpuesto As CampoTexto
                    Private f_precioventaregular As CampoDecimal
                    Private f_autoitem As CampoTexto
                    Private f_codigobarra As CampoTexto
                    Private f_plu As CampoTexto
                    Private f_auto_producto As CampoTexto
                    Private f_referencia_empaque_venta As CampoTexto
                    Private f_contenido_empaque_venta As CampoInteger
                    Private f_auto_medida As CampoTexto
                    Private f_nombre_medida As CampoTexto
                    Private f_id_tarjeta As CampoTexto
                    Private f_codigooperador As CampoTexto
                    Private f_nombreoperador As CampoTexto
                    Private f_fechaproceso As CampoFecha
                    Private f_horaproceso As CampoTexto
                    Private f_equipoestacion As CampoTexto
                    Private f_numerodecimlaes As CampoTexto

                    Protected Friend Property c_Producto() As CampoTexto
                        Get
                            Return f_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_producto = value
                        End Set
                    End Property

                    ReadOnly Property _Producto() As String
                        Get
                            Return c_Producto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Cantidad() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Return c_Cantidad.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_PrecioNetoVenta() As CampoDecimal
                        Get
                            Return f_precionetoventa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precionetoventa = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNetoVenta() As Decimal
                        Get
                            Return c_PrecioNetoVenta.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_iva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_iva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return c_TasaIva.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Importe() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
                        End Set
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Return Me.c_Importe.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_ProductoEnOferta() As CampoTexto
                        Get
                            Return f_esoferta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _ProductoEnOferta() As TipoEstatus
                        Get
                            If Me.c_ProductoEnOferta.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_ProductoEsPesado() As CampoTexto
                        Get
                            Return f_espesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _ProductoPesado() As TipoEstatus
                        Get
                            If Me.c_ProductoEsPesado.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_TipoTasaIva() As CampoTexto
                        Get
                            Return f_tipoimpuesto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipoimpuesto = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Select Case Me.c_TipoTasaIva.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_PrecioVentaRegularNeto() As CampoDecimal
                        Get
                            Return f_precioventaregular
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precioventaregular = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioVentaRegularNeto() As Decimal
                        Get
                            Return Me.c_PrecioVentaRegularNeto.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_AutoItem() As CampoTexto
                        Get
                            Return f_autoitem
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_autoitem = value
                        End Set
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Return Me.c_AutoItem.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoBarra() As CampoTexto
                        Get
                            Return f_codigobarra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarra() As String
                        Get
                            Return Me.c_CodigoBarra.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Plu() As CampoTexto
                        Get
                            Return f_plu
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_plu = value
                        End Set
                    End Property

                    ReadOnly Property _Plu() As String
                        Get
                            Return Me.c_Plu.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return Me.f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ReferenciaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_referencia_empaque_venta
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_referencia_empaque_venta = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpqVenta() As String
                        Get
                            Return Me.c_ReferenciaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ContenidoEmpqVenta() As CampoInteger
                        Get
                            Return Me.f_contenido_empaque_venta
                        End Get
                        Set(ByVal value As CampoInteger)
                            Me.f_contenido_empaque_venta = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpqventa() As Integer
                        Get
                            Return Me.c_ContenidoEmpqVenta.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_AutoMedidaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_auto_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_auto_medida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMedidaEmpqventa() As String
                        Get
                            Return Me.c_AutoMedidaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreMedidaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_nombre_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_nombre_medida = value
                        End Set
                    End Property

                    ReadOnly Property _NombreMedidaEmapqVenta() As String
                        Get
                            Return Me.c_NombreMedidaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_IdTajeta() As CampoTexto
                        Get
                            Return Me.f_id_tarjeta
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_id_tarjeta = value
                        End Set
                    End Property

                    ReadOnly Property _IdTarjeta() As String
                        Get
                            Return Me.c_IdTajeta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CodigoOperador() As CampoTexto
                        Get
                            Return Me.f_codigooperador
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_codigooperador = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoOperador() As String
                        Get
                            Return Me.c_CodigoOperador.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NombreOperador() As CampoTexto
                        Get
                            Return Me.f_nombreoperador
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_nombreoperador = value
                        End Set
                    End Property

                    ReadOnly Property _NombreOperador() As String
                        Get
                            Return Me.c_NombreOperador.c_Texto.Trim
                        End Get
                    End Property

                    Property c_FehcaProceso() As CampoFecha
                        Get
                            Return Me.f_fechaproceso
                        End Get
                        Set(ByVal value As CampoFecha)
                            Me.f_fechaproceso = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FehcaProceso.c_Valor
                        End Get
                    End Property

                    Property c_HoraProceso() As CampoTexto
                        Get
                            Return Me.f_horaproceso
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_horaproceso = value
                        End Set
                    End Property

                    ReadOnly Property _HoraProceso() As String
                        Get
                            Return Me.c_HoraProceso.c_Texto.Trim
                        End Get
                    End Property

                    Property c_EquipoEstacion() As CampoTexto
                        Get
                            Return Me.f_equipoestacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_equipoestacion = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Return Me.c_EquipoEstacion.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NumeroDecimalesMostrar() As CampoTexto
                        Get
                            Return Me.f_numerodecimlaes
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_numerodecimlaes = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroDecimlaesMostrar() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.c_NumeroDecimalesMostrar.c_Texto, x)
                            Return x
                        End Get
                    End Property

                    ReadOnly Property _CalculaNuevoImporteYaConDevolucion() As Decimal
                        Get
                            Dim xr As Decimal = 0
                            xr = (Me._Cantidad - 1) * Me._PrecioNetoVenta
                            xr = Decimal.Round(xr, 2, MidpointRounding.AwayFromZero)
                            Return xr
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Producto = New CampoTexto(40, "producto")
                        Me.c_Cantidad = New CampoDecimal("cantidad")
                        Me.c_PrecioNetoVenta = New CampoDecimal("precionetoventa")
                        Me.c_TasaIva = New CampoDecimal("iva")
                        Me.c_Importe = New CampoDecimal("importe")
                        Me.c_ProductoEnOferta = New CampoTexto(1, "esoferta")
                        Me.c_ProductoEsPesado = New CampoTexto(1, "espesado")
                        Me.c_TipoTasaIva = New CampoTexto(1, "tipoimpuesto")
                        Me.c_PrecioVentaRegularNeto = New CampoDecimal("precioventaregular")
                        Me.c_AutoItem = New CampoTexto(10, "autoitem")
                        Me.c_CodigoBarra = New CampoTexto(15, "codigobarra")
                        Me.c_Plu = New CampoTexto(5, "plu")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_ReferenciaEmpqVenta = New CampoTexto(1, "referencia_empaque_venta")
                        Me.c_ContenidoEmpqVenta = New CampoInteger("contenido_empaque_venta")
                        Me.c_AutoMedidaEmpqVenta = New CampoTexto(10, "auto_medida")
                        Me.c_NombreMedidaEmpqVenta = New CampoTexto(20, "nombre_medida")
                        Me.c_IdTajeta = New CampoTexto(5, "id_tarjeta")
                        Me.c_CodigoOperador = New CampoTexto(10, "codigooperador")
                        Me.c_NombreOperador = New CampoTexto(20, "nombreoperador")
                        Me.c_FehcaProceso = New CampoFecha("fechaproceso")
                        Me.c_HoraProceso = New CampoTexto(10, "horaproceso")
                        Me.c_EquipoEstacion = New CampoTexto(20, "equipoestacion")
                        Me.c_NumeroDecimalesMostrar = New CampoTexto(1, "numerodecimales")

                        Me.LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_AutoItem.c_Texto = xrow(.c_AutoItem.c_NombreInterno)
                                .c_AutoMedidaEmpqVenta.c_Texto = xrow(.c_AutoMedidaEmpqVenta.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_Cantidad.c_Valor = xrow(.c_Cantidad.c_NombreInterno)
                                .c_CodigoBarra.c_Texto = xrow(.c_CodigoBarra.c_NombreInterno)
                                .c_ContenidoEmpqVenta.c_Valor = xrow(.c_ContenidoEmpqVenta.c_NombreInterno)
                                .c_Importe.c_Valor = xrow(.c_Importe.c_NombreInterno)
                                .c_NombreMedidaEmpqVenta.c_Texto = xrow(.c_NombreMedidaEmpqVenta.c_NombreInterno)
                                .c_Plu.c_Texto = xrow(.c_Plu.c_NombreInterno)
                                .c_PrecioNetoVenta.c_Valor = xrow(.c_PrecioNetoVenta.c_NombreInterno)
                                .c_PrecioVentaRegularNeto.c_Valor = xrow(.c_PrecioVentaRegularNeto.c_NombreInterno)
                                .c_Producto.c_Texto = xrow(.c_Producto.c_NombreInterno)
                                .c_ProductoEnOferta.c_Texto = xrow(.c_ProductoEnOferta.c_NombreInterno)
                                .c_ProductoEsPesado.c_Texto = xrow(.c_ProductoEsPesado.c_NombreInterno)
                                .c_ReferenciaEmpqVenta.c_Texto = xrow(.c_ReferenciaEmpqVenta.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_TipoTasaIva.c_Texto = xrow(.c_TipoTasaIva.c_NombreInterno)

                                .c_IdTajeta.c_Texto = xrow(.c_IdTajeta.c_NombreInterno)
                                .c_CodigoOperador.c_Texto = xrow(.c_CodigoOperador.c_NombreInterno)
                                .c_NombreOperador.c_Texto = xrow(.c_NombreOperador.c_NombreInterno)
                                .c_FehcaProceso.c_Valor = xrow(.c_FehcaProceso.c_NombreInterno)
                                .c_HoraProceso.c_Texto = xrow(.c_HoraProceso.c_NombreInterno)
                                .c_EquipoEstacion.c_Texto = xrow(.c_EquipoEstacion.c_NombreInterno)
                                .c_NumeroDecimalesMostrar.c_Texto = xrow(.c_NumeroDecimalesMostrar.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PANADERIA PEDIDO DETALLE" + vbCrLf + "CARGAR FICHA" + vbCrLf + ex.Message)
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

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
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

                Protected Friend Const INSERT_PANADERIA_PEDIDO_DETALLES As String = "INSERT INTO PanaderiaPedidoDetalles (" & _
                    "Producto," & _
                    "Cantidad," & _
                    "PrecioNetoVenta," & _
                    "Iva," & _
                    "Importe," & _
                    "EsOferta," & _
                    "EsPesado," & _
                    "TipoImpuesto," & _
                    "PrecioVentaRegular," & _
                    "autoitem," & _
                    "codigobarra," & _
                    "plu," & _
                    "auto_producto," & _
                    "referencia_empaque_venta," & _
                    "contenido_empaque_venta," & _
                    "auto_medida," & _
                    "nombre_medida," & _
                    "id_tarjeta," & _
                    "codigooperador," & _
                    "nombreoperador," & _
                    "fechaproceso," & _
                    "horaproceso," & _
                    "equipoestacion," & _
                    "numerodecimales)" & _
                    "VALUES (" & _
                    "@Producto," & _
                    "@Cantidad," & _
                    "@PrecioNetoVenta," & _
                    "@Iva," & _
                    "@Importe," & _
                    "@EsOferta," & _
                    "@EsPesado," & _
                    "@TipoImpuesto," & _
                    "@PrecioVentaRegular," & _
                    "@autoitem," & _
                    "@codigobarra," & _
                    "@plu," & _
                    "@auto_producto," & _
                    "@referencia_empaque_venta," & _
                    "@contenido_empaque_venta," & _
                    "@auto_medida," & _
                    "@nombre_medida," & _
                    "@id_tarjeta," & _
                    "@codigooperador," & _
                    "@nombreoperador," & _
                    "@fechaproceso," & _
                    "@horaproceso," & _
                    "@equipoestacion," & _
                    "@numerodecimales)"

                Function F_BuscarDetalle(ByVal xautoitem As String) As Boolean
                    Try
                        Dim xsql As String = "select * from panaderiapedidodetalles where autoitem=@autoitem"
                        Dim xp1 As New SqlParameter("@autoitem", xautoitem)
                        Dim xtb As New DataTable

                        Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.Add(xp1)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("AUTO DEL PEDIDO DETALLE NO ENCONTADO")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_ActualizarPedidoDetalle(ByVal xautoitem As String, ByVal xcant As Integer) As Boolean
                    Try
                        Dim xfecha As Date
                        Dim xhora As String
                        Dim ximporte As Decimal = 0
                        Dim xcantidad As Decimal = 0
                        Dim xid As String

                        F_BuscarDetalle(xautoitem)
                        xid = Me.RegistroDato._IdTarjeta
                        xfecha = F_GetDate("SELECT getdate()")
                        xhora = xfecha.ToShortTimeString
                        xcantidad = Me.RegistroDato._Cantidad + xcant
                        ximporte = Decimal.Round(xcantidad * Me.RegistroDato._PrecioNetoVenta, 2, MidpointRounding.AwayFromZero)

                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Dim xobj As Object
                                Dim xauto As String
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "delete panaderiapedidodetalles where autoitem=@autoitem"
                                    xcmd.Parameters.AddWithValue("@autoitem", xautoitem)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_panaderia_pedido_detalle from contadores"
                                    xobj = xcmd.ExecuteScalar()
                                    If IsNothing(xobj) Or IsDBNull(xobj) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_panaderia_pedido_detalle=0"
                                        xcmd.ExecuteNonQuery()
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_panaderia_pedido_detalle=a_panaderia_pedido_detalle+1; select a_panaderia_pedido_detalle from contadores"
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    Dim xdet As New FichaPanaderia.PedidoDetalles.c_Registro
                                    With xdet
                                        .c_AutoItem.c_Texto = xauto
                                        .c_AutoMedidaEmpqVenta.c_Texto = Me.RegistroDato.c_AutoMedidaEmpqVenta.c_Texto
                                        .c_AutoProducto.c_Texto = Me.RegistroDato.c_AutoProducto.c_Texto
                                        .c_Cantidad.c_Valor = xcantidad
                                        .c_CodigoBarra.c_Texto = Me.RegistroDato.c_CodigoBarra.c_Texto
                                        .c_CodigoOperador.c_Texto = Me.RegistroDato.c_CodigoOperador.c_Texto
                                        .c_ContenidoEmpqVenta.c_Valor = Me.RegistroDato.c_ContenidoEmpqVenta.c_Valor
                                        .c_EquipoEstacion.c_Texto = Me.RegistroDato.c_EquipoEstacion.c_Texto
                                        .c_FehcaProceso.c_Valor = xfecha
                                        .c_HoraProceso.c_Texto = xhora
                                        .c_IdTajeta.c_Texto = Me.RegistroDato.c_IdTajeta.c_Texto
                                        .c_Importe.c_Valor = ximporte
                                        .c_NombreMedidaEmpqVenta.c_Texto = Me.RegistroDato.c_NombreMedidaEmpqVenta.c_Texto
                                        .c_NombreOperador.c_Texto = Me.RegistroDato.c_NombreOperador.c_Texto
                                        .c_Plu.c_Texto = Me.RegistroDato.c_Plu.c_Texto
                                        .c_PrecioNetoVenta.c_Valor = Me.RegistroDato.c_PrecioNetoVenta.c_Valor
                                        .c_PrecioVentaRegularNeto.c_Valor = Me.RegistroDato.c_PrecioVentaRegularNeto.c_Valor
                                        .c_Producto.c_Texto = Me.RegistroDato.c_Producto.c_Texto
                                        .c_ProductoEnOferta.c_Texto = Me.RegistroDato.c_ProductoEnOferta.c_Texto
                                        .c_ProductoEsPesado.c_Texto = Me.RegistroDato.c_ProductoEsPesado.c_Texto
                                        .c_ReferenciaEmpqVenta.c_Texto = Me.RegistroDato.c_ReferenciaEmpqVenta.c_Texto
                                        .c_TasaIva.c_Valor = Me.RegistroDato.c_TasaIva.c_Valor
                                        .c_TipoTasaIva.c_Texto = Me.RegistroDato.c_TipoTasaIva.c_Texto
                                        .c_NumeroDecimalesMostrar.c_Texto = Me.RegistroDato.c_NumeroDecimalesMostrar.c_Texto
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PANADERIA_PEDIDO_DETALLES
                                    xcmd.Parameters.AddWithValue("@Producto", xdet.c_Producto.c_Texto).Size = xdet.c_Producto.c_Largo
                                    xcmd.Parameters.AddWithValue("@Cantidad", xdet.c_Cantidad.c_Valor)
                                    xcmd.Parameters.AddWithValue("@PrecioNetoVenta", xdet.c_PrecioNetoVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Iva", xdet.c_TasaIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Importe", xdet.c_Importe.c_Valor)
                                    xcmd.Parameters.AddWithValue("@EsOferta", xdet.c_ProductoEnOferta.c_Texto).Size = xdet.c_ProductoEnOferta.c_Largo
                                    xcmd.Parameters.AddWithValue("@EsPesado", xdet.c_ProductoEsPesado.c_Texto).Size = xdet.c_ProductoEsPesado.c_Largo
                                    xcmd.Parameters.AddWithValue("@TipoImpuesto", xdet.c_TipoTasaIva.c_Texto).Size = xdet.c_TipoTasaIva.c_Largo
                                    xcmd.Parameters.AddWithValue("@PrecioVentaRegular", xdet.c_PrecioVentaRegularNeto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@autoitem", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigobarra", xdet.c_CodigoBarra.c_Texto).Size = xdet.c_CodigoBarra.c_Largo
                                    xcmd.Parameters.AddWithValue("@plu", xdet.c_Plu.c_Texto).Size = xdet.c_Plu.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdet.c_AutoProducto.c_Texto).Size = xdet.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@referencia_empaque_venta", xdet.c_ReferenciaEmpqVenta.c_Texto).Size = xdet.c_ReferenciaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque_venta", xdet.c_ContenidoEmpqVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_medida", xdet.c_AutoMedidaEmpqVenta.c_Texto).Size = xdet.c_AutoMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_medida", xdet.c_NombreMedidaEmpqVenta.c_Texto).Size = xdet.c_NombreMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@id_tarjeta", xdet.c_IdTajeta.c_Texto).Size = xdet.c_IdTajeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigooperador", xdet.c_CodigoOperador.c_Texto).Size = xdet.c_CodigoOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombreoperador", xdet.c_NombreOperador.c_Texto).Size = xdet.c_NombreOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@fechaproceso", xdet.c_FehcaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@horaproceso", xdet.c_HoraProceso.c_Texto).Size = xdet.c_HoraProceso.c_Largo
                                    xcmd.Parameters.AddWithValue("@equipoestacion", xdet.c_EquipoEstacion.c_Texto).Size = xdet.c_EquipoEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@numerodecimales", xdet.c_NumeroDecimalesMostrar.c_Texto).Size = xdet.c_NumeroDecimalesMostrar.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    Dim xmonto As Decimal = 0
                                    Dim xitems As Integer = 0
                                    Dim xrd As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select sum(importe) ximporte, count(*) xitems from panaderiaPEDIDOdetalles where ID_tarjeta=@idtarjeta"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xid)
                                    xrd = xcmd.ExecuteReader()
                                    While xrd.Read
                                        If IsDBNull(xrd(0)) Or IsNothing(xrd(0)) Then
                                        Else
                                            xmonto = xrd(0)
                                        End If
                                        If IsDBNull(xrd(1)) Or IsNothing(xrd(1)) Then
                                        Else
                                            xitems = xrd(1)
                                        End If
                                    End While
                                    xrd.Close()

                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update panaderiatarjeta set fecha=@fecha, hora=@hora, monto=@monto, items=@items " & _
                                      "where id=@id AND ESTATUS='1'"
                                    xcmd.Parameters.AddWithValue("@fecha", xfecha)
                                    xcmd.Parameters.AddWithValue("@hora", xhora)
                                    xcmd.Parameters.AddWithValue("@monto", xmonto)
                                    xcmd.Parameters.AddWithValue("@items", xitems)
                                    xcmd.Parameters.AddWithValue("@id", xid)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("TARJETA NO ENCONTRADO / TARJETA HA SIDO DESBLOQUEADA POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _RetornaAutoPedidoDetalle(xauto)
                                RaiseEvent _ActualizarPedidoDetalle()
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
                        Throw New Exception("ACTUALIZAR DETALLE PEDIDO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AgregraDetalle(ByVal xdetalle As AgregarDetalle) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Dim xobj As Object
                                Dim xauto As String
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_panaderia_pedido_detalle from contadores"
                                    xobj = xcmd.ExecuteScalar()
                                    If IsNothing(xobj) Or IsDBNull(xobj) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_panaderia_pedido_detalle=0"
                                        xcmd.ExecuteNonQuery()
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_panaderia_pedido_detalle=a_panaderia_pedido_detalle+1; select a_panaderia_pedido_detalle from contadores"
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    Dim xdet As New FichaPanaderia.PedidoDetalles.c_Registro
                                    With xdet
                                        .c_AutoItem.c_Texto = xauto
                                        .c_AutoMedidaEmpqVenta.c_Texto = xdetalle._AutoMedidaEmpaqVenta
                                        .c_AutoProducto.c_Texto = xdetalle._FichaProducto._AutoProducto
                                        .c_Cantidad.c_Valor = xdetalle._Cantidad
                                        .c_CodigoBarra.c_Texto = xdetalle._CodigoBarra
                                        .c_CodigoOperador.c_Texto = xdetalle._FichaUsuario._CodigoUsuario
                                        .c_ContenidoEmpqVenta.c_Valor = xdetalle._ContenidoEmpaqVenta
                                        .c_EquipoEstacion.c_Texto = xdetalle._EquipoEstacion
                                        .c_FehcaProceso.c_Valor = xdetalle._FechaProceso
                                        .c_HoraProceso.c_Texto = xdetalle._HoraProceso
                                        .c_IdTajeta.c_Texto = xdetalle._IdTarjeta
                                        .c_Importe.c_Valor = xdetalle._Importe
                                        .c_NombreMedidaEmpqVenta.c_Texto = xdetalle._NombreMedidaEmpaqVenta
                                        .c_NombreOperador.c_Texto = xdetalle._FichaUsuario._NombreUsuario
                                        .c_Plu.c_Texto = xdetalle._Plu
                                        .c_PrecioNetoVenta.c_Valor = xdetalle._PrecioVentaNeto
                                        .c_PrecioVentaRegularNeto.c_Valor = xdetalle._PrecioVentaNetoRegular
                                        .c_Producto.c_Texto = xdetalle._FichaProducto._DescripcionDetallaDelProducto
                                        .c_ProductoEnOferta.c_Texto = IIf(xdetalle._FichaProducto.f_VerificarOferta, "1", "0")
                                        .c_ProductoEsPesado.c_Texto = IIf(xdetalle._FichaProducto._EsPesado, "1", "0")
                                        .c_ReferenciaEmpqVenta.c_Texto = xdetalle._ReferenciaEmpaqVenta
                                        .c_TasaIva.c_Valor = xdetalle._FichaProducto._TasaImpuesto
                                        .c_TipoTasaIva.c_Texto = xdetalle._FichaProducto.c_TipoImpuesto.c_Texto
                                        .c_NumeroDecimalesMostrar.c_Texto = xdetalle._NumeroDecimalesMostrar.ToString.Trim
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PANADERIA_PEDIDO_DETALLES
                                    xcmd.Parameters.AddWithValue("@Producto", xdet.c_Producto.c_Texto).Size = xdet.c_Producto.c_Largo
                                    xcmd.Parameters.AddWithValue("@Cantidad", xdet.c_Cantidad.c_Valor)
                                    xcmd.Parameters.AddWithValue("@PrecioNetoVenta", xdet.c_PrecioNetoVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Iva", xdet.c_TasaIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Importe", xdet.c_Importe.c_Valor)
                                    xcmd.Parameters.AddWithValue("@EsOferta", xdet.c_ProductoEnOferta.c_Texto).Size = xdet.c_ProductoEnOferta.c_Largo
                                    xcmd.Parameters.AddWithValue("@EsPesado", xdet.c_ProductoEsPesado.c_Texto).Size = xdet.c_ProductoEsPesado.c_Largo
                                    xcmd.Parameters.AddWithValue("@TipoImpuesto", xdet.c_TipoTasaIva.c_Texto).Size = xdet.c_TipoTasaIva.c_Largo
                                    xcmd.Parameters.AddWithValue("@PrecioVentaRegular", xdet.c_PrecioVentaRegularNeto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@autoitem", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigobarra", xdet.c_CodigoBarra.c_Texto).Size = xdet.c_CodigoBarra.c_Largo
                                    xcmd.Parameters.AddWithValue("@plu", xdet.c_Plu.c_Texto).Size = xdet.c_Plu.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdet.c_AutoProducto.c_Texto).Size = xdet.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@referencia_empaque_venta", xdet.c_ReferenciaEmpqVenta.c_Texto).Size = xdet.c_ReferenciaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque_venta", xdet.c_ContenidoEmpqVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_medida", xdet.c_AutoMedidaEmpqVenta.c_Texto).Size = xdet.c_AutoMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_medida", xdet.c_NombreMedidaEmpqVenta.c_Texto).Size = xdet.c_NombreMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@id_tarjeta", xdet.c_IdTajeta.c_Texto).Size = xdet.c_IdTajeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigooperador", xdet.c_CodigoOperador.c_Texto).Size = xdet.c_CodigoOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombreoperador", xdet.c_NombreOperador.c_Texto).Size = xdet.c_NombreOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@fechaproceso", xdet.c_FehcaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@horaproceso", xdet.c_HoraProceso.c_Texto).Size = xdet.c_HoraProceso.c_Largo
                                    xcmd.Parameters.AddWithValue("@equipoestacion", xdet.c_EquipoEstacion.c_Texto).Size = xdet.c_EquipoEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@numerodecimales", xdet.c_NumeroDecimalesMostrar.c_Texto).Size = xdet.c_NumeroDecimalesMostrar.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    Dim xmonto As Decimal = 0
                                    Dim xitems As Integer = 0
                                    Dim xrd As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select sum(importe) ximporte, count(*) xitems from panaderiaPEDIDOdetalles where ID_tarjeta=@idtarjeta"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xdetalle._IdTarjeta)
                                    xrd = xcmd.ExecuteReader()
                                    While xrd.Read
                                        If IsDBNull(xrd(0)) Or IsNothing(xrd(0)) Then
                                        Else
                                            xmonto = xrd(0)
                                        End If
                                        If IsDBNull(xrd(1)) Or IsNothing(xrd(1)) Then
                                        Else
                                            xitems = xrd(1)
                                        End If
                                    End While
                                    xrd.Close()

                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update panaderiatarjeta set fecha=@fecha, hora=@hora, monto=@monto, items=@items " & _
                                      "where id=@id and estatus='1'"
                                    xcmd.Parameters.AddWithValue("@fecha", xdetalle._FechaProceso)
                                    xcmd.Parameters.AddWithValue("@hora", xdetalle._HoraProceso)
                                    xcmd.Parameters.AddWithValue("@monto", xmonto)
                                    xcmd.Parameters.AddWithValue("@items", xitems)
                                    xcmd.Parameters.AddWithValue("@id", xdetalle._IdTarjeta)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("TARJETA NO ENCONTRADO / TARJETA HA SIDO DESBLOQUEADA POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _RetornaAutoPedidoDetalle(xauto)
                                RaiseEvent _ActualizarPedidoDetalle()
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
                        Throw New Exception("AGREGAR DETALLE PEDIDO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Public Class Devolucion
                Event _AnularDevolucion()
                Event _AnularItem()
                Event _Devolucion()

                Enum TipoMovimiento_PanaderiaAnulaDev As Integer
                    Devolucion = 1
                    Anulacion = 2
                End Enum

                Class AgregarDevolucionAnulacion
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xequipoestacion As String
                    Private xtipomovimiento As TipoMovimiento_PanaderiaAnulaDev
                    Private xautoitem As String
                    Private xidtarjeta As String

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("select getdate()")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString()
                        End Get
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xfichausuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Get
                            Return Me.xequipoestacion
                        End Get
                        Set(ByVal value As String)
                            Me.xequipoestacion = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As TipoMovimiento_PanaderiaAnulaDev
                        Get
                            Return Me.xtipomovimiento
                        End Get
                        Set(ByVal value As TipoMovimiento_PanaderiaAnulaDev)
                            Me.xtipomovimiento = value
                        End Set
                    End Property

                    Property _AutoItem_Movimiento() As String
                        Get
                            Return Me.xautoitem
                        End Get
                        Set(ByVal value As String)
                            Me.xautoitem = value
                        End Set
                    End Property

                    Property _IdTarjeta_Movimiento() As String
                        Get
                            Return Me.xidtarjeta
                        End Get
                        Set(ByVal value As String)
                            Me.xidtarjeta = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoItem_Movimiento = ""
                        Me._EquipoEstacion = ""
                        Me._FichaUsuario = Nothing
                        Me._IdTarjeta_Movimiento = ""
                        Me._TipoMovimiento = 0
                    End Sub
                End Class

                Class AgregarDevolucion
                    Private xfichausuario As FichaGlobal.c_Usuario.c_Registro
                    Private xequipoestacion As String
                    Private xautoproducto As String
                    Private xidtarjeta As String
                    Private xcantidaddevolver As Integer
                    Private xtipomovimineto As String

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("select getdate()")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString()
                        End Get
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return Me.xfichausuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            Me.xfichausuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Get
                            Return Me.xequipoestacion
                        End Get
                        Set(ByVal value As String)
                            Me.xequipoestacion = value
                        End Set
                    End Property

                    Property _AutoProducto() As String
                        Get
                            Return Me.xautoproducto
                        End Get
                        Set(ByVal value As String)
                            Me.xautoproducto = value
                        End Set
                    End Property

                    Property _IdTarjeta_Movimiento() As String
                        Get
                            Return Me.xidtarjeta
                        End Get
                        Set(ByVal value As String)
                            Me.xidtarjeta = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _CantDevolver() As Integer
                        Get
                            Return 1
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TipoMovimiento() As String
                        Get
                            Return "1"
                        End Get
                    End Property

                    Sub New()
                        Me._AutoProducto = ""
                        Me._EquipoEstacion = ""
                        Me._FichaUsuario = Nothing
                        Me._IdTarjeta_Movimiento = ""
                    End Sub
                End Class

                Class c_Registro
                    Private f_producto As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_precionetoventa As CampoDecimal
                    Private f_iva As CampoDecimal
                    Private f_importe As CampoDecimal
                    Private f_esoferta As CampoTexto
                    Private f_espesado As CampoTexto
                    Private f_tipoimpuesto As CampoTexto
                    Private f_precioventaregular As CampoDecimal
                    Private f_codigobarra As CampoTexto
                    Private f_plu As CampoTexto
                    Private f_auto_producto As CampoTexto
                    Private f_referencia_empaque_venta As CampoTexto
                    Private f_contenido_empaque_venta As CampoInteger
                    Private f_auto_medida As CampoTexto
                    Private f_nombre_medida As CampoTexto
                    Private f_id_tarjeta As CampoTexto
                    Private f_codigooperador As CampoTexto
                    Private f_nombreoperador As CampoTexto
                    Private f_fechaproceso As CampoFecha
                    Private f_horaproceso As CampoTexto
                    Private f_equipoestacion As CampoTexto
                    Private f_numerodecimlaes As CampoTexto

                    Private f_fecha_mov As CampoFecha
                    Private f_hora_mov As CampoTexto
                    Private f_codigooperador_mov As CampoTexto
                    Private f_nombreoperador_mov As CampoTexto
                    Private f_equipoestacion_mov As CampoTexto
                    Private f_tipo_mov As CampoTexto
                    Private f_auto_anulacion_mov As CampoTexto

                    Protected Friend Property c_Producto() As CampoTexto
                        Get
                            Return f_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_producto = value
                        End Set
                    End Property

                    ReadOnly Property _Producto() As String
                        Get
                            Return c_Producto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Cantidad() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Return c_Cantidad.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_PrecioNetoVenta() As CampoDecimal
                        Get
                            Return f_precionetoventa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precionetoventa = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNetoVenta() As Decimal
                        Get
                            Return c_PrecioNetoVenta.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_TasaIva() As CampoDecimal
                        Get
                            Return f_iva
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_iva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Return c_TasaIva.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Importe() As CampoDecimal
                        Get
                            Return f_importe
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_importe = value
                        End Set
                    End Property

                    ReadOnly Property _Importe() As Decimal
                        Get
                            Return Me.c_Importe.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_ProductoEnOferta() As CampoTexto
                        Get
                            Return f_esoferta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_esoferta = value
                        End Set
                    End Property

                    ReadOnly Property _ProductoEnOferta() As TipoEstatus
                        Get
                            If Me.c_ProductoEnOferta.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_ProductoEsPesado() As CampoTexto
                        Get
                            Return f_espesado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_espesado = value
                        End Set
                    End Property

                    ReadOnly Property _ProductoPesado() As TipoEstatus
                        Get
                            If Me.c_ProductoEsPesado.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_TipoTasaIva() As CampoTexto
                        Get
                            Return f_tipoimpuesto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipoimpuesto = value
                        End Set
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Select Case Me.c_TipoTasaIva.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_PrecioVentaRegularNeto() As CampoDecimal
                        Get
                            Return f_precioventaregular
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precioventaregular = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioVentaRegularNeto() As Decimal
                        Get
                            Return Me.c_PrecioVentaRegularNeto.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_CodigoBarra() As CampoTexto
                        Get
                            Return f_codigobarra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigobarra = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarra() As String
                        Get
                            Return Me.c_CodigoBarra.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Plu() As CampoTexto
                        Get
                            Return f_plu
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_plu = value
                        End Set
                    End Property

                    ReadOnly Property _Plu() As String
                        Get
                            Return Me.c_Plu.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return Me.f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ReferenciaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_referencia_empaque_venta
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_referencia_empaque_venta = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpqVenta() As String
                        Get
                            Return Me.c_ReferenciaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ContenidoEmpqVenta() As CampoInteger
                        Get
                            Return Me.f_contenido_empaque_venta
                        End Get
                        Set(ByVal value As CampoInteger)
                            Me.f_contenido_empaque_venta = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpqventa() As Integer
                        Get
                            Return Me.c_ContenidoEmpqVenta.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_AutoMedidaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_auto_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_auto_medida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMedidaEmpqventa() As String
                        Get
                            Return Me.c_AutoMedidaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreMedidaEmpqVenta() As CampoTexto
                        Get
                            Return Me.f_nombre_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_nombre_medida = value
                        End Set
                    End Property

                    ReadOnly Property _NombreMedidaEmapqVenta() As String
                        Get
                            Return Me.c_NombreMedidaEmpqVenta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_IdTajeta() As CampoTexto
                        Get
                            Return Me.f_id_tarjeta
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_id_tarjeta = value
                        End Set
                    End Property

                    ReadOnly Property _IdTarjeta() As String
                        Get
                            Return Me.c_IdTajeta.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CodigoOperador() As CampoTexto
                        Get
                            Return Me.f_codigooperador
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_codigooperador = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoOperador() As String
                        Get
                            Return Me.c_CodigoOperador.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NombreOperador() As CampoTexto
                        Get
                            Return Me.f_nombreoperador
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_nombreoperador = value
                        End Set
                    End Property

                    ReadOnly Property _NombreOperador() As String
                        Get
                            Return Me.c_NombreOperador.c_Texto.Trim
                        End Get
                    End Property

                    Property c_FehcaProceso() As CampoFecha
                        Get
                            Return Me.f_fechaproceso
                        End Get
                        Set(ByVal value As CampoFecha)
                            Me.f_fechaproceso = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FehcaProceso.c_Valor
                        End Get
                    End Property

                    Property c_HoraProceso() As CampoTexto
                        Get
                            Return Me.f_horaproceso
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_horaproceso = value
                        End Set
                    End Property

                    ReadOnly Property _HoraProceso() As String
                        Get
                            Return Me.c_HoraProceso.c_Texto.Trim
                        End Get
                    End Property

                    Property c_EquipoEstacion() As CampoTexto
                        Get
                            Return Me.f_equipoestacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_equipoestacion = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Return Me.c_EquipoEstacion.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NumeroDecimalesMostrar() As CampoTexto
                        Get
                            Return Me.f_numerodecimlaes
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_numerodecimlaes = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroDecimlaesMostrar() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.c_NumeroDecimalesMostrar.c_Texto, x)
                            Return x
                        End Get
                    End Property


                    Property c_CodigoOperador_Mov() As CampoTexto
                        Get
                            Return Me.f_codigooperador_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_codigooperador_mov = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoOperador_Movimiento() As String
                        Get
                            Return Me.c_CodigoOperador_Mov.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NombreOperador_Mov() As CampoTexto
                        Get
                            Return Me.f_nombreoperador_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_nombreoperador_mov = value
                        End Set
                    End Property

                    ReadOnly Property _NombreOperador_Movimiento() As String
                        Get
                            Return Me.c_NombreOperador_Mov.c_Texto.Trim
                        End Get
                    End Property

                    Property c_FehcaProceso_Mov() As CampoFecha
                        Get
                            Return Me.f_fecha_mov
                        End Get
                        Set(ByVal value As CampoFecha)
                            Me.f_fecha_mov = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha_Movimiento() As Date
                        Get
                            Return Me.c_FehcaProceso_Mov.c_Valor
                        End Get
                    End Property

                    Property c_HoraProceso_Mov() As CampoTexto
                        Get
                            Return Me.f_hora_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_hora_mov = value
                        End Set
                    End Property

                    ReadOnly Property _Hora_Movimiento() As String
                        Get
                            Return Me.c_HoraProceso_Mov.c_Texto.Trim
                        End Get
                    End Property

                    Property c_EquipoEstacion_Mov() As CampoTexto
                        Get
                            Return Me.f_equipoestacion_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_equipoestacion_mov = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion_Movimiento() As String
                        Get
                            Return Me.c_EquipoEstacion_Mov.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Tipo_Mov() As CampoTexto
                        Get
                            Return Me.f_tipo_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_tipo_mov = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMOvimiento() As TipoMovimiento_PanaderiaAnulaDev
                        Get
                            Select Case c_Tipo_Mov.c_Texto.Trim.ToUpper
                                Case "1" : Return TipoMovimiento_PanaderiaAnulaDev.Devolucion
                                Case "2" : Return TipoMovimiento_PanaderiaAnulaDev.Anulacion
                            End Select
                        End Get
                    End Property

                    Property c_AutoAnulacion_Mov() As CampoTexto
                        Get
                            Return Me.f_auto_anulacion_mov
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_auto_anulacion_mov = value
                        End Set
                    End Property

                    ReadOnly Property _AutoAnulacion_Movimiento() As String
                        Get
                            Return Me.c_AutoAnulacion_Mov.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Producto = New CampoTexto(40, "producto")
                        Me.c_Cantidad = New CampoDecimal("cantidad")
                        Me.c_PrecioNetoVenta = New CampoDecimal("precionetoventa")
                        Me.c_TasaIva = New CampoDecimal("iva")
                        Me.c_Importe = New CampoDecimal("importe")
                        Me.c_ProductoEnOferta = New CampoTexto(1, "esoferta")
                        Me.c_ProductoEsPesado = New CampoTexto(1, "espesado")
                        Me.c_TipoTasaIva = New CampoTexto(1, "tipoimpuesto")
                        Me.c_PrecioVentaRegularNeto = New CampoDecimal("precioventaregular")
                        Me.c_CodigoBarra = New CampoTexto(15, "codigobarra")
                        Me.c_Plu = New CampoTexto(5, "plu")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_ReferenciaEmpqVenta = New CampoTexto(1, "referencia_empaque_venta")
                        Me.c_ContenidoEmpqVenta = New CampoInteger("contenido_empaque_venta")
                        Me.c_AutoMedidaEmpqVenta = New CampoTexto(10, "auto_medida")
                        Me.c_NombreMedidaEmpqVenta = New CampoTexto(20, "nombre_medida")
                        Me.c_IdTajeta = New CampoTexto(5, "id_tarjeta")
                        Me.c_CodigoOperador = New CampoTexto(10, "codigooperador")
                        Me.c_NombreOperador = New CampoTexto(20, "nombreoperador")
                        Me.c_FehcaProceso = New CampoFecha("fechaproceso")
                        Me.c_HoraProceso = New CampoTexto(10, "horaproceso")
                        Me.c_EquipoEstacion = New CampoTexto(20, "equipoestacion")
                        Me.c_NumeroDecimalesMostrar = New CampoTexto(1, "numerodecimales")

                        Me.c_CodigoOperador_Mov = New CampoTexto(10, "codigooperador_mov")
                        Me.c_NombreOperador_Mov = New CampoTexto(20, "nombreoperador_mov")
                        Me.c_FehcaProceso_Mov = New CampoFecha("fecha_mov")
                        Me.c_HoraProceso_Mov = New CampoTexto(10, "hora_mov")
                        Me.c_EquipoEstacion_Mov = New CampoTexto(20, "equipoestacion_mov")
                        Me.c_Tipo_Mov = New CampoTexto(1, "tipo_mov")
                        Me.c_AutoAnulacion_Mov = New CampoTexto(10, "auto_anulacion_mov")

                        Me.LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_AutoMedidaEmpqVenta.c_Texto = xrow(.c_AutoMedidaEmpqVenta.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_Cantidad.c_Valor = xrow(.c_Cantidad.c_NombreInterno)
                                .c_CodigoBarra.c_Texto = xrow(.c_CodigoBarra.c_NombreInterno)
                                .c_ContenidoEmpqVenta.c_Valor = xrow(.c_ContenidoEmpqVenta.c_NombreInterno)
                                .c_Importe.c_Valor = xrow(.c_Importe.c_NombreInterno)
                                .c_NombreMedidaEmpqVenta.c_Texto = xrow(.c_NombreMedidaEmpqVenta.c_NombreInterno)
                                .c_Plu.c_Texto = xrow(.c_Plu.c_NombreInterno)
                                .c_PrecioNetoVenta.c_Valor = xrow(.c_PrecioNetoVenta.c_NombreInterno)
                                .c_PrecioVentaRegularNeto.c_Valor = xrow(.c_PrecioVentaRegularNeto.c_NombreInterno)
                                .c_Producto.c_Texto = xrow(.c_Producto.c_NombreInterno)
                                .c_ProductoEnOferta.c_Texto = xrow(.c_ProductoEnOferta.c_NombreInterno)
                                .c_ProductoEsPesado.c_Texto = xrow(.c_ProductoEsPesado.c_NombreInterno)
                                .c_ReferenciaEmpqVenta.c_Texto = xrow(.c_ReferenciaEmpqVenta.c_NombreInterno)
                                .c_TasaIva.c_Valor = xrow(.c_TasaIva.c_NombreInterno)
                                .c_TipoTasaIva.c_Texto = xrow(.c_TipoTasaIva.c_NombreInterno)
                                .c_IdTajeta.c_Texto = xrow(.c_IdTajeta.c_NombreInterno)
                                .c_CodigoOperador.c_Texto = xrow(.c_CodigoOperador.c_NombreInterno)
                                .c_NombreOperador.c_Texto = xrow(.c_NombreOperador.c_NombreInterno)
                                .c_FehcaProceso.c_Valor = xrow(.c_FehcaProceso.c_NombreInterno)
                                .c_HoraProceso.c_Texto = xrow(.c_HoraProceso.c_NombreInterno)
                                .c_EquipoEstacion.c_Texto = xrow(.c_EquipoEstacion.c_NombreInterno)
                                .c_NumeroDecimalesMostrar.c_Texto = xrow(.c_NumeroDecimalesMostrar.c_NombreInterno)

                                .c_FehcaProceso_Mov.c_Valor = xrow(.c_FehcaProceso_Mov.c_NombreInterno)
                                .c_HoraProceso_Mov.c_Texto = xrow(.c_HoraProceso_Mov.c_NombreInterno)
                                .c_CodigoOperador_Mov.c_Texto = xrow(.c_CodigoOperador_Mov.c_NombreInterno)
                                .c_NombreOperador_Mov.c_Texto = xrow(.c_NombreOperador_Mov.c_NombreInterno)
                                .c_EquipoEstacion_Mov.c_Texto = xrow(.c_EquipoEstacion_Mov.c_NombreInterno)
                                .c_Tipo_Mov.c_Texto = xrow(.c_Tipo_Mov.c_NombreInterno)
                                .c_AutoAnulacion_Mov.c_Texto = xrow(.c_AutoAnulacion_Mov.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PANADERIA ANULA-DEVOLUCION" + vbCrLf + "CARGAR FICHA" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const Insert_Devolucion As String = "INSERT INTO PanaderiaDevolucion (" & _
                    "Producto," & _
                    "Cantidad," & _
                    "PrecioNetoVenta," & _
                    "Iva," & _
                    "Importe," & _
                    "EsOferta," & _
                    "EsPesado," & _
                    "TipoImpuesto," & _
                    "PrecioVentaRegular," & _
                    "codigobarra," & _
                    "plu," & _
                    "auto_producto," & _
                    "referencia_empaque_venta," & _
                    "contenido_empaque_venta," & _
                    "auto_medida," & _
                    "nombre_medida," & _
                    "id_tarjeta," & _
                    "codigooperador," & _
                    "nombreoperador," & _
                    "fechaproceso," & _
                    "horaproceso," & _
                    "equipoestacion," & _
                    "numerodecimales," & _
                    "fecha_mov," & _
                    "hora_mov," & _
                    "codigooperador_mov," & _
                    "nombreoperador_mov," & _
                    "equipoestacion_mov," & _
                    "tipo_mov," & _
                    "auto_anulacion_mov)" & _
                    "VALUES (" & _
                    "@Producto," & _
                    "@Cantidad," & _
                    "@PrecioNetoVenta," & _
                    "@Iva," & _
                    "@Importe," & _
                    "@EsOferta," & _
                    "@EsPesado," & _
                    "@TipoImpuesto," & _
                    "@PrecioVentaRegular," & _
                    "@codigobarra," & _
                    "@plu," & _
                    "@auto_producto," & _
                    "@referencia_empaque_venta," & _
                    "@contenido_empaque_venta," & _
                    "@auto_medida," & _
                    "@nombre_medida," & _
                    "@id_tarjeta," & _
                    "@codigooperador," & _
                    "@nombreoperador," & _
                    "@fechaproceso," & _
                    "@horaproceso," & _
                    "@equipoestacion," & _
                    "@numerodecimales," & _
                    "@fecha_mov," & _
                    "@hora_mov," & _
                    "@codigooperador_mov," & _
                    "@nombreoperador_mov," & _
                    "@equipoestacion_mov," & _
                    "@tipo_mov," & _
                    "@auto_anulacion_mov)"

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

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
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

                Function F_AnularPedido(ByVal xpedido_anular As AgregarDevolucionAnulacion) As Boolean
                    Try
                        Dim xauto_anulacion As String = ""
                        Dim xtb As New DataTable
                        If xpedido_anular._TipoMovimiento = TipoMovimiento_PanaderiaAnulaDev.Anulacion Then
                            Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.Clear()
                                xadap.SelectCommand.CommandText = "select PD.* from panaderiapedidodetalles PD, PanaderiaTarjeta PT " & _
                                  "where PD.id_tarjeta=@ID AND PD.id_tarjeta=PT.ID AND PT.ESTATUS='1' order by autoitem  desc"
                                xadap.SelectCommand.Parameters.AddWithValue("@id", xpedido_anular._IdTarjeta_Movimiento)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count <= 0 Then
                                Throw New Exception("PEDIDO - TARJETA A ANULAR NO POSEE DETALLES / TAJETA YA FUE ANULADA POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                            End If
                        Else
                            Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.Clear()
                                xadap.SelectCommand.CommandText = "select PD.* from panaderiapedidodetalles PD, PanaderiaTarjeta PT " & _
                                  "where PD.id_tarjeta=@ID AND PD.AUTOITEM=@item AND PD.id_tarjeta=PT.ID AND PT.ESTATUS='1' order by autoitem  desc"
                                xadap.SelectCommand.Parameters.AddWithValue("@id", xpedido_anular._IdTarjeta_Movimiento)
                                xadap.SelectCommand.Parameters.AddWithValue("@item", xpedido_anular._AutoItem_Movimiento)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count <= 0 Then
                                Throw New Exception("PEDIDO - ITEM A ANULAR NO ENCONTRADO / YA FUE ANULADO POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                            End If
                        End If

                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Dim xdet As New PedidoDetalles.c_Registro
                                Dim xdev As New Devolucion.c_Registro

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    If xpedido_anular._TipoMovimiento = TipoMovimiento_PanaderiaAnulaDev.Anulacion Then
                                        Dim xobj As Object = Nothing
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select a_panaderia_anulacion from contadores"
                                        xobj = xcmd.ExecuteScalar()
                                        If IsNothing(xobj) Or IsDBNull(xobj) Then
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update contadores set a_panaderia_anulacion=0"
                                            xcmd.ExecuteNonQuery()
                                        End If

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_panaderia_anulacion=a_panaderia_anulacion+1; select a_panaderia_anulacion from contadores"
                                        xauto_anulacion = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    End If

                                    For Each xdr As DataRow In xtb.Rows
                                        xdet.CargarRegistro(xdr)
                                        With xdev
                                            .LimpiarRegistro()
                                            .c_AutoMedidaEmpqVenta.c_Texto = xdet.c_AutoMedidaEmpqVenta.c_Texto
                                            .c_AutoProducto.c_Texto = xdet.c_AutoProducto.c_Texto
                                            .c_Cantidad.c_Valor = xdet.c_Cantidad.c_Valor
                                            .c_CodigoBarra.c_Texto = xdet.c_CodigoBarra.c_Texto
                                            .c_CodigoOperador.c_Texto = xdet.c_CodigoOperador.c_Texto
                                            .c_CodigoOperador_Mov.c_Texto = xpedido_anular._FichaUsuario._CodigoUsuario
                                            .c_ContenidoEmpqVenta.c_Valor = xdet.c_ContenidoEmpqVenta.c_Valor
                                            .c_EquipoEstacion.c_Texto = xdet.c_EquipoEstacion.c_Texto
                                            .c_EquipoEstacion_Mov.c_Texto = xpedido_anular._EquipoEstacion
                                            .c_FehcaProceso.c_Valor = xdet.c_FehcaProceso.c_Valor
                                            .c_FehcaProceso_Mov.c_Valor = xpedido_anular._Fecha
                                            .c_HoraProceso.c_Texto = xdet.c_HoraProceso.c_Texto
                                            .c_HoraProceso_Mov.c_Texto = xpedido_anular._Hora
                                            .c_IdTajeta.c_Texto = xdet.c_IdTajeta.c_Texto
                                            .c_Importe.c_Valor = xdet.c_Importe.c_Valor
                                            .c_NombreMedidaEmpqVenta.c_Texto = xdet.c_NombreMedidaEmpqVenta.c_Texto
                                            .c_NombreOperador.c_Texto = xdet.c_NombreOperador.c_Texto
                                            .c_NombreOperador_Mov.c_Texto = xpedido_anular._FichaUsuario._NombreUsuario
                                            .c_NumeroDecimalesMostrar.c_Texto = xdet.c_NumeroDecimalesMostrar.c_Texto
                                            .c_Plu.c_Texto = xdet.c_Plu.c_Texto
                                            .c_PrecioNetoVenta.c_Valor = xdet.c_PrecioNetoVenta.c_Valor
                                            .c_PrecioVentaRegularNeto.c_Valor = xdet.c_PrecioVentaRegularNeto.c_Valor
                                            .c_Producto.c_Texto = xdet.c_Producto.c_Texto
                                            .c_ProductoEnOferta.c_Texto = xdet.c_ProductoEnOferta.c_Texto
                                            .c_ProductoEsPesado.c_Texto = xdet.c_ProductoEsPesado.c_Texto
                                            .c_ReferenciaEmpqVenta.c_Texto = xdet.c_ReferenciaEmpqVenta.c_Texto
                                            .c_TasaIva.c_Valor = xdet.c_TasaIva.c_Valor
                                            .c_Tipo_Mov.c_Texto = xpedido_anular._TipoMovimiento
                                            .c_TipoTasaIva.c_Texto = xdet.c_TipoTasaIva.c_Texto
                                            .c_AutoAnulacion_Mov.c_Texto = xauto_anulacion
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = Insert_Devolucion
                                        xcmd.Parameters.AddWithValue("@Producto", xdev.c_Producto.c_Texto).Size = xdev.c_Producto.c_Largo
                                        xcmd.Parameters.AddWithValue("@Cantidad", xdev.c_Cantidad.c_Valor)
                                        xcmd.Parameters.AddWithValue("@PrecioNetoVenta", xdev.c_PrecioNetoVenta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@Iva", xdev.c_TasaIva.c_Valor)
                                        xcmd.Parameters.AddWithValue("@Importe", xdev.c_Importe.c_Valor)
                                        xcmd.Parameters.AddWithValue("@EsOferta", xdev.c_ProductoEnOferta.c_Texto).Size = xdev.c_ProductoEnOferta.c_Largo
                                        xcmd.Parameters.AddWithValue("@EsPesado", xdev.c_ProductoEsPesado.c_Texto).Size = xdev.c_ProductoEsPesado.c_Largo
                                        xcmd.Parameters.AddWithValue("@TipoImpuesto", xdev.c_TipoTasaIva.c_Texto).Size = xdev.c_TipoTasaIva.c_Largo
                                        xcmd.Parameters.AddWithValue("@PrecioVentaRegular", xdev.c_PrecioVentaRegularNeto.c_Valor)
                                        xcmd.Parameters.AddWithValue("@codigobarra", xdev.c_CodigoBarra.c_Texto).Size = xdev.c_CodigoBarra.c_Largo
                                        xcmd.Parameters.AddWithValue("@plu", xdev.c_Plu.c_Texto).Size = xdev.c_Plu.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xdev.c_AutoProducto.c_Texto).Size = xdev.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@referencia_empaque_venta", xdev.c_ReferenciaEmpqVenta.c_Texto).Size = xdev.c_ReferenciaEmpqVenta.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque_venta", xdev.c_ContenidoEmpqVenta.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_medida", xdev.c_AutoMedidaEmpqVenta.c_Texto).Size = xdev.c_AutoMedidaEmpqVenta.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombre_medida", xdev.c_NombreMedidaEmpqVenta.c_Texto).Size = xdev.c_NombreMedidaEmpqVenta.c_Largo
                                        xcmd.Parameters.AddWithValue("@id_tarjeta", xdev.c_IdTajeta.c_Texto).Size = xdev.c_IdTajeta.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigooperador", xdev.c_CodigoOperador.c_Texto).Size = xdev.c_CodigoOperador.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombreoperador", xdev.c_NombreOperador.c_Texto).Size = xdev.c_NombreOperador.c_Largo
                                        xcmd.Parameters.AddWithValue("@fechaproceso", xdev.c_FehcaProceso.c_Valor)
                                        xcmd.Parameters.AddWithValue("@horaproceso", xdev.c_HoraProceso.c_Texto).Size = xdev.c_HoraProceso.c_Largo
                                        xcmd.Parameters.AddWithValue("@equipoestacion", xdev.c_EquipoEstacion.c_Texto).Size = xdev.c_EquipoEstacion.c_Largo
                                        xcmd.Parameters.AddWithValue("@numerodecimales", xdev.c_NumeroDecimalesMostrar.c_Texto).Size = xdev.c_NumeroDecimalesMostrar.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha_mov", xdev.c_FehcaProceso_Mov.c_Valor)
                                        xcmd.Parameters.AddWithValue("@hora_mov", xdev.c_HoraProceso_Mov.c_Texto).Size = xdev.c_HoraProceso_Mov.c_Largo
                                        xcmd.Parameters.AddWithValue("@codigooperador_mov", xdev.c_CodigoOperador_Mov.c_Texto).Size = xdev.c_CodigoOperador_Mov.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombreoperador_mov", xdev.c_NombreOperador_Mov.c_Texto).Size = xdev.c_NombreOperador_Mov.c_Largo
                                        xcmd.Parameters.AddWithValue("@equipoestacion_mov", xdev.c_EquipoEstacion_Mov.c_Texto).Size = xdev.c_EquipoEstacion_Mov.c_Largo
                                        xcmd.Parameters.AddWithValue("@tipo_mov", xdev.c_Tipo_Mov.c_Texto).Size = xdev.c_Tipo_Mov.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_anulacion_mov", xdev.c_AutoAnulacion_Mov.c_Texto).Size = xdev.c_AutoAnulacion_Mov.c_Largo
                                        xcmd.ExecuteNonQuery()

                                        Dim xr As Integer = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete panaderiapedidodetalles where autoitem=@item and id_tarjeta=@id"
                                        xcmd.Parameters.AddWithValue("@id", xpedido_anular._IdTarjeta_Movimiento).Size = xdet.c_IdTajeta.c_Largo
                                        xcmd.Parameters.AddWithValue("@item", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ITEM A ANULAR NO ECONTRADA / OTRO USUARIO YA ANULO ESTE ITEM")
                                        End If
                                    Next

                                    If xpedido_anular._TipoMovimiento = TipoMovimiento_PanaderiaAnulaDev.Anulacion Then
                                        Dim xr As Integer = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "delete panaderiatarjeta where id=@id and estatus='1'"
                                        xcmd.Parameters.AddWithValue("@id", xpedido_anular._IdTarjeta_Movimiento)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("TARJETA A ANULAR PEDIDO NO ECONTRADA / OTRO USUARIO YA ANULO ESTA TARJETA")
                                        End If
                                    End If

                                    If xpedido_anular._TipoMovimiento = TipoMovimiento_PanaderiaAnulaDev.Devolucion Then
                                        Dim xmonto As Decimal = 0
                                        Dim xitems As Integer = 0
                                        Dim xrd As SqlDataReader
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select sum(importe) ximporte, count(*) xitems from panaderiaPEDIDOdetalles where ID_tarjeta=@idtarjeta"
                                        xcmd.Parameters.AddWithValue("@idtarjeta", xpedido_anular._IdTarjeta_Movimiento)
                                        xrd = xcmd.ExecuteReader()
                                        While xrd.Read
                                            If IsDBNull(xrd(0)) Or IsNothing(xrd(0)) Then
                                            Else
                                                xmonto = xrd(0)
                                            End If
                                            If IsDBNull(xrd(1)) Or IsNothing(xrd(1)) Then
                                            Else
                                                xitems = xrd(1)
                                            End If
                                        End While
                                        xrd.Close()

                                        Dim xr2 As Integer = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update panaderiatarjeta set fecha=@fecha, hora=@hora, monto=@monto, items=@items " & _
                                          "where id=@id AND ESTATUS='1'"
                                        xcmd.Parameters.AddWithValue("@fecha", xpedido_anular._Fecha)
                                        xcmd.Parameters.AddWithValue("@hora", xpedido_anular._Hora)
                                        xcmd.Parameters.AddWithValue("@monto", xmonto)
                                        xcmd.Parameters.AddWithValue("@items", xitems)
                                        xcmd.Parameters.AddWithValue("@id", xpedido_anular._IdTarjeta_Movimiento)
                                        xr2 = xcmd.ExecuteNonQuery()
                                        If xr2 = 0 Then
                                            Throw New Exception("TARJETA NO ENCONTRADO / TARJETA HA SIDO DESBLOQUEADA POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                                        End If
                                    End If

                                    xtr.Commit()
                                    If xpedido_anular._TipoMovimiento = TipoMovimiento_PanaderiaAnulaDev.Anulacion Then
                                        RaiseEvent _AnularDevolucion()
                                    Else
                                        RaiseEvent _AnularItem()
                                    End If
                                    Return True
                                End Using
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA - DEVOLUCION - ANULACION" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_Devolucion(ByVal xitemdev As AgregarDevolucion) As Boolean
                    Try
                        Dim xauto_anulacion As String = ""
                        Dim xtb As New DataTable

                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select PD.* from panaderiapedidodetalles PD, PanaderiaTarjeta PT " & _
                              "where PD.id_tarjeta=@ID AND PD.auto_producto=@autoprd AND PD.id_tarjeta=PT.ID AND PT.ESTATUS='1' order by autoitem  desc"
                            xadap.SelectCommand.Parameters.AddWithValue("@id", xitemdev._IdTarjeta_Movimiento)
                            xadap.SelectCommand.Parameters.AddWithValue("@autoprd", xitemdev._AutoProducto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count <= 0 Then
                            Throw New Exception("PEDIDO - ITEM AL REALIZAR DEVOLUCION NO ENCONTRADO / YA FUE ANULADO POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                        End If

                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Dim xdet As New PedidoDetalles.c_Registro
                                Dim xdev As New Devolucion.c_Registro

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    
                                    xdet.CargarRegistro(xtb(0))
                                    With xdev
                                        .LimpiarRegistro()
                                        .c_AutoMedidaEmpqVenta.c_Texto = xdet.c_AutoMedidaEmpqVenta.c_Texto
                                        .c_AutoProducto.c_Texto = xdet.c_AutoProducto.c_Texto
                                        .c_Cantidad.c_Valor = xitemdev._CantDevolver
                                        .c_CodigoBarra.c_Texto = xdet.c_CodigoBarra.c_Texto
                                        .c_CodigoOperador.c_Texto = xdet.c_CodigoOperador.c_Texto
                                        .c_CodigoOperador_Mov.c_Texto = xitemdev._FichaUsuario._CodigoUsuario
                                        .c_ContenidoEmpqVenta.c_Valor = xdet.c_ContenidoEmpqVenta.c_Valor
                                        .c_EquipoEstacion.c_Texto = xdet.c_EquipoEstacion.c_Texto
                                        .c_EquipoEstacion_Mov.c_Texto = xitemdev._EquipoEstacion
                                        .c_FehcaProceso.c_Valor = xdet.c_FehcaProceso.c_Valor
                                        .c_FehcaProceso_Mov.c_Valor = xitemdev._Fecha
                                        .c_HoraProceso.c_Texto = xdet.c_HoraProceso.c_Texto
                                        .c_HoraProceso_Mov.c_Texto = xitemdev._Hora
                                        .c_IdTajeta.c_Texto = xdet.c_IdTajeta.c_Texto
                                        .c_Importe.c_Valor = xdet.c_PrecioNetoVenta.c_Valor
                                        .c_NombreMedidaEmpqVenta.c_Texto = xdet.c_NombreMedidaEmpqVenta.c_Texto
                                        .c_NombreOperador.c_Texto = xdet.c_NombreOperador.c_Texto
                                        .c_NombreOperador_Mov.c_Texto = xitemdev._FichaUsuario._NombreUsuario
                                        .c_NumeroDecimalesMostrar.c_Texto = xdet.c_NumeroDecimalesMostrar.c_Texto
                                        .c_Plu.c_Texto = xdet.c_Plu.c_Texto
                                        .c_PrecioNetoVenta.c_Valor = xdet.c_PrecioNetoVenta.c_Valor
                                        .c_PrecioVentaRegularNeto.c_Valor = xdet.c_PrecioVentaRegularNeto.c_Valor
                                        .c_Producto.c_Texto = xdet.c_Producto.c_Texto
                                        .c_ProductoEnOferta.c_Texto = xdet.c_ProductoEnOferta.c_Texto
                                        .c_ProductoEsPesado.c_Texto = xdet.c_ProductoEsPesado.c_Texto
                                        .c_ReferenciaEmpqVenta.c_Texto = xdet.c_ReferenciaEmpqVenta.c_Texto
                                        .c_TasaIva.c_Valor = xdet.c_TasaIva.c_Valor
                                        .c_Tipo_Mov.c_Texto = xitemdev._TipoMovimiento
                                        .c_TipoTasaIva.c_Texto = xdet.c_TipoTasaIva.c_Texto
                                        .c_AutoAnulacion_Mov.c_Texto = xauto_anulacion
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_Devolucion
                                    xcmd.Parameters.AddWithValue("@Producto", xdev.c_Producto.c_Texto).Size = xdev.c_Producto.c_Largo
                                    xcmd.Parameters.AddWithValue("@Cantidad", xdev.c_Cantidad.c_Valor)
                                    xcmd.Parameters.AddWithValue("@PrecioNetoVenta", xdev.c_PrecioNetoVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Iva", xdev.c_TasaIva.c_Valor)
                                    xcmd.Parameters.AddWithValue("@Importe", xdev.c_Importe.c_Valor)
                                    xcmd.Parameters.AddWithValue("@EsOferta", xdev.c_ProductoEnOferta.c_Texto).Size = xdev.c_ProductoEnOferta.c_Largo
                                    xcmd.Parameters.AddWithValue("@EsPesado", xdev.c_ProductoEsPesado.c_Texto).Size = xdev.c_ProductoEsPesado.c_Largo
                                    xcmd.Parameters.AddWithValue("@TipoImpuesto", xdev.c_TipoTasaIva.c_Texto).Size = xdev.c_TipoTasaIva.c_Largo
                                    xcmd.Parameters.AddWithValue("@PrecioVentaRegular", xdev.c_PrecioVentaRegularNeto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigobarra", xdev.c_CodigoBarra.c_Texto).Size = xdev.c_CodigoBarra.c_Largo
                                    xcmd.Parameters.AddWithValue("@plu", xdev.c_Plu.c_Texto).Size = xdev.c_Plu.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdev.c_AutoProducto.c_Texto).Size = xdev.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@referencia_empaque_venta", xdev.c_ReferenciaEmpqVenta.c_Texto).Size = xdev.c_ReferenciaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque_venta", xdev.c_ContenidoEmpqVenta.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_medida", xdev.c_AutoMedidaEmpqVenta.c_Texto).Size = xdev.c_AutoMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_medida", xdev.c_NombreMedidaEmpqVenta.c_Texto).Size = xdev.c_NombreMedidaEmpqVenta.c_Largo
                                    xcmd.Parameters.AddWithValue("@id_tarjeta", xdev.c_IdTajeta.c_Texto).Size = xdev.c_IdTajeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigooperador", xdev.c_CodigoOperador.c_Texto).Size = xdev.c_CodigoOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombreoperador", xdev.c_NombreOperador.c_Texto).Size = xdev.c_NombreOperador.c_Largo
                                    xcmd.Parameters.AddWithValue("@fechaproceso", xdev.c_FehcaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@horaproceso", xdev.c_HoraProceso.c_Texto).Size = xdev.c_HoraProceso.c_Largo
                                    xcmd.Parameters.AddWithValue("@equipoestacion", xdev.c_EquipoEstacion.c_Texto).Size = xdev.c_EquipoEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@numerodecimales", xdev.c_NumeroDecimalesMostrar.c_Texto).Size = xdev.c_NumeroDecimalesMostrar.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_mov", xdev.c_FehcaProceso_Mov.c_Valor)
                                    xcmd.Parameters.AddWithValue("@hora_mov", xdev.c_HoraProceso_Mov.c_Texto).Size = xdev.c_HoraProceso_Mov.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigooperador_mov", xdev.c_CodigoOperador_Mov.c_Texto).Size = xdev.c_CodigoOperador_Mov.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombreoperador_mov", xdev.c_NombreOperador_Mov.c_Texto).Size = xdev.c_NombreOperador_Mov.c_Largo
                                    xcmd.Parameters.AddWithValue("@equipoestacion_mov", xdev.c_EquipoEstacion_Mov.c_Texto).Size = xdev.c_EquipoEstacion_Mov.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo_mov", xdev.c_Tipo_Mov.c_Texto).Size = xdev.c_Tipo_Mov.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_anulacion_mov", xdev.c_AutoAnulacion_Mov.c_Texto).Size = xdev.c_AutoAnulacion_Mov.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update panaderiapedidodetalles set cantidad=cantidad-1, importe=@importe " & _
                                        "where autoitem=@item and id_tarjeta=@id"
                                    xcmd.Parameters.AddWithValue("@id", xitemdev._IdTarjeta_Movimiento).Size = xdet.c_IdTajeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@item", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe", xdet._CalculaNuevoImporteYaConDevolucion)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ITEM AL REALIZAR DEVOLUCION NO ENCONTRADO / OTRO USUARIO YA ANULO ESTE ITEM")
                                    End If

                                    xr = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT CANTIDAD FROM panaderiapedidodetalles where autoitem=@item and id_tarjeta=@id"
                                    xcmd.Parameters.AddWithValue("@id", xitemdev._IdTarjeta_Movimiento).Size = xdet.c_IdTajeta.c_Largo
                                    xcmd.Parameters.AddWithValue("@item", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                    xr = xcmd.ExecuteScalar
                                    If xr = 0 Then
                                        xr = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "DELETE panaderiapedidodetalles where autoitem=@item and id_tarjeta=@id and CANTIDAD=0"
                                        xcmd.Parameters.AddWithValue("@id", xitemdev._IdTarjeta_Movimiento).Size = xdet.c_IdTajeta.c_Largo
                                        xcmd.Parameters.AddWithValue("@item", xdet.c_AutoItem.c_Texto).Size = xdet.c_AutoItem.c_Largo
                                        xr = xcmd.ExecuteNonQuery
                                        If xr = 0 Then
                                            Throw New Exception("PROBLEMA CON EL ITEM AL REALIZAR LA DEVOLUCION: POSEE TODAVIA CANTIDAD / ITEM NO ENCONTRADO")
                                        End If
                                    End If

                                    Dim xmonto As Decimal = 0
                                    Dim xitems As Integer = 0
                                    Dim xrd As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select sum(importe) ximporte, count(*) xitems from panaderiaPEDIDOdetalles where ID_tarjeta=@idtarjeta"
                                    xcmd.Parameters.AddWithValue("@idtarjeta", xitemdev._IdTarjeta_Movimiento)
                                    xrd = xcmd.ExecuteReader()
                                    While xrd.Read
                                        If IsDBNull(xrd(0)) Or IsNothing(xrd(0)) Then
                                        Else
                                            xmonto = xrd(0)
                                        End If
                                        If IsDBNull(xrd(1)) Or IsNothing(xrd(1)) Then
                                        Else
                                            xitems = xrd(1)
                                        End If
                                    End While
                                    xrd.Close()

                                    Dim xr2 As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update panaderiatarjeta set fecha=@fecha, hora=@hora, monto=@monto, items=@items " & _
                                      "where id=@id AND ESTATUS='1'"
                                    xcmd.Parameters.AddWithValue("@fecha", xitemdev._Fecha)
                                    xcmd.Parameters.AddWithValue("@hora", xitemdev._Hora)
                                    xcmd.Parameters.AddWithValue("@monto", xmonto)
                                    xcmd.Parameters.AddWithValue("@items", xitems)
                                    xcmd.Parameters.AddWithValue("@id", xitemdev._IdTarjeta_Movimiento)
                                    xr2 = xcmd.ExecuteNonQuery()
                                    If xr2 = 0 Then
                                        Throw New Exception("TARJETA NO ENCONTRADO / TARJETA HA SIDO DESBLOQUEADA POR OTRO USUARIO. VERIFIQUE POR FAVOR")
                                    End If

                                    xtr.Commit()

                                    RaiseEvent _Devolucion()
                                    Return True
                                End Using
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PANADERIA - DEVOLUCION - ANULACION" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class

            Private xtarjeta As Tarjeta
            Private xtarjetaanulada As TarjetaAnulada
            Private xtarjetaanulada_historico As TarjetaAnulada_Historico
            Private xpedidodetalle As PedidoDetalles
            Private xdevolucion As Devolucion

            Property f_Tarjeta() As Tarjeta
                Get
                    Return xtarjeta
                End Get
                Set(ByVal value As Tarjeta)
                    xtarjeta = value
                End Set
            End Property

            Property f_TarjetaAnulada() As TarjetaAnulada
                Get
                    Return xtarjetaanulada
                End Get
                Set(ByVal value As TarjetaAnulada)
                    xtarjetaanulada = value
                End Set
            End Property

            Property f_TarjetaAnuladaHistorico() As TarjetaAnulada_Historico
                Get
                    Return xtarjetaanulada_historico
                End Get
                Set(ByVal value As TarjetaAnulada_Historico)
                    xtarjetaanulada_historico = value
                End Set
            End Property

            Property f_PedidoDetalle() As PedidoDetalles
                Get
                    Return xpedidodetalle
                End Get
                Set(ByVal value As PedidoDetalles)
                    xpedidodetalle = value
                End Set
            End Property

            Property f_Devolucion() As Devolucion
                Get
                    Return xdevolucion
                End Get
                Set(ByVal value As Devolucion)
                    xdevolucion = value
                End Set
            End Property

            Sub New()
                f_Tarjeta = New Tarjeta
                f_TarjetaAnulada = New TarjetaAnulada
                f_PedidoDetalle = New PedidoDetalles
                f_Devolucion = New Devolucion
                f_TarjetaAnuladaHistorico = New TarjetaAnulada_Historico
            End Sub

            Function F_ProcesarTarjeta(ByVal xidtarjeta As String, ByVal xtabla As DataTable) As Boolean
                Try
                    xtabla.Clear()

                    Dim xtb As New DataTable
                    Dim xtr As SqlTransaction = Nothing
                    Dim xrd As SqlDataReader = Nothing
                    Dim xtarjeta As New Tarjeta.c_Registro

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from panaderiatarjeta where id=@id"
                                xcmd.Parameters.AddWithValue("@id", xidtarjeta)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count > 0 Then
                                    xtarjeta.CargarRegistro(xtb(0))
                                    If xtarjeta._CantidadItems > 0 Then
                                        If xtarjeta._EstatusTarjeta = TipoEstatusTarjeta.Bloqueada Then
                                            Throw New Exception("TARJETA SE ENCUENTRA BLOQUEADA POR UN OPERADOR... VERIFIQUE POR FAVOR")
                                        End If
                                    Else
                                        Throw New Exception("TARJETA NO ENCONTRADA... VERIFIQUE POR FAVOR")
                                    End If
                                Else
                                    Throw New Exception("TARJETA NO ENCONTRADA... VERIFIQUE POR FAVOR")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select * from panaderiapedidodetalles where id_tarjeta=@id"
                                xcmd.Parameters.AddWithValue("@id", xidtarjeta)
                                xrd = xcmd.ExecuteReader()
                                xtabla.Load(xrd)
                                xrd.Close()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from panaderiapedidodetalles where id_tarjeta=@id"
                                xcmd.Parameters.AddWithValue("@id", xidtarjeta)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from panaderiatarjeta where id=@id"
                                xcmd.Parameters.AddWithValue("@id", xidtarjeta)
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            Return True
                        Catch ex2 As SqlException
                            Throw New Exception(ex2.Message + vbCrLf + ex2.Number.ToString)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("ERROR AL PROCESAR TARJETA:" + vbCrLf + ex.Message)
                End Try
            End Function

            Class TarjetaProcesar
                Private _id As String
                Private _jornada As FastFood.Jornada
                Private _operador As FastFood.OperadorJornada
                Private _idequipo As String
                Private _usuario As FichaGlobal.c_Usuario


                Property IdTarjeta() As String
                    Get
                        Return _id
                    End Get
                    Set(ByVal value As String)
                        _id = value
                    End Set
                End Property

                Property Jornada() As FastFood.Jornada
                    Get
                        Return _jornada
                    End Get
                    Set(ByVal value As FastFood.Jornada)
                        _jornada = value
                    End Set
                End Property

                Property Operador() As FastFood.OperadorJornada
                    Get
                        Return _operador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada)
                        _operador = value
                    End Set
                End Property

                Property IdEquipoEstacion() As String
                    Get
                        Return _idequipo
                    End Get
                    Set(ByVal value As String)
                        _idequipo = value
                    End Set
                End Property

                Property Usuario() As FichaGlobal.c_Usuario
                    Get
                        Return _usuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario)
                        _usuario = value
                    End Set
                End Property

                Sub New()
                    IdTarjeta = ""
                    Jornada = Nothing
                    Operador = Nothing
                    IdEquipoEstacion = ""
                    Usuario = Nothing
                End Sub
            End Class

            Function F_ProcesarTarjeta(ByVal xTarjetaProcesar As TarjetaProcesar) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Dim xrd As SqlDataReader = Nothing
                    Dim xtarjeta As New Tarjeta.c_Registro

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xtb As New DataTable

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select pd.* from panaderiapedidodetalles as pd join panaderiatarjeta as p on pd.id_tarjeta=p.id where pd.id_tarjeta=@id and p.estatus='0'"
                                xcmd.Parameters.AddWithValue("@id", xTarjetaProcesar.IdTarjeta)
                                xrd = xcmd.ExecuteReader()
                                xtb.Load(xrd)
                                xrd.Close()

                                If xtb.Rows.Count = 0 Then
                                    Throw New Exception("TARJETA NO ENCONTRADA / BLOQUEADA POR UN OPERADOR... VERIFIQUE POR FAVOR")
                                End If

                                For Each xr As DataRow In xtb.Rows
                                    Dim xreg1 As New FichaPanaderia.PedidoDetalles
                                    xreg1.M_CargarRegistro(xr)

                                    Dim xreg2 As New PosOnline.PosVenta.c_Registro
                                    With xreg2
                                        .c_AutoEmpaqueMedida._ContenidoCampo = xreg1.RegistroDato.c_AutoMedidaEmpqVenta.c_Texto
                                        .c_AutoJornada._ContenidoCampo = xTarjetaProcesar.Jornada.RegistroDato._AutoJornada
                                        .c_AutoOperador._ContenidoCampo = xTarjetaProcesar.Operador.RegistroDato._AutoOperador
                                        .c_AutoProducto._ContenidoCampo = xreg1.RegistroDato.c_AutoProducto.c_Texto
                                        .c_Cantidad._ContenidoCampo = xreg1.RegistroDato.c_Cantidad.c_Valor
                                        .c_CodigoBarraLeido._ContenidoCampo = xreg1.RegistroDato.c_CodigoBarra.c_Texto
                                        .c_ContenidoEmpaqueMedida._ContenidoCampo = xreg1.RegistroDato.c_ContenidoEmpqVenta.c_Valor
                                        .c_TasaIva._ContenidoCampo = xreg1.RegistroDato.c_TasaIva.c_Valor

                                        If xreg1.RegistroDato._ProductoEnOferta = TipoEstatus.Activo Then
                                            .c_EnOferta._ContenidoCampo = "1"
                                            .c_PrecioNeto._ContenidoCampo = xreg1.RegistroDato._PrecioNetoVenta
                                        Else
                                            .c_EnOferta._ContenidoCampo = "0"
                                            .c_PrecioNeto._ContenidoCampo = xreg1.RegistroDato._PrecioVentaRegularNeto
                                        End If

                                        If xreg1.RegistroDato._ProductoPesado = TipoProductoBalanza.Pesado Then
                                            .c_EsPesado._ContenidoCampo = "1"
                                        Else
                                            .c_EsPesado._ContenidoCampo = "0"
                                        End If

                                        .c_NombreCorto._ContenidoCampo = xreg1.RegistroDato._Producto
                                        .c_NombreEmpaqueMedida._ContenidoCampo = xreg1.RegistroDato._NombreMedidaEmapqVenta
                                        .c_PLU._ContenidoCampo = xr("plu")
                                        .c_PrecioRegular._ContenidoCampo = xreg1.RegistroDato._PrecioVentaRegularNeto
                                        .c_PrecioSugerido._ContenidoCampo = 0
                                        .c_ReferenciaEmpaqueMedida._ContenidoCampo = "5" 'UNIDAD
                                        .c_ReferenciaPrecioMayor._ContenidoCampo = ""
                                        Select Case xreg1.RegistroDato._TipoTasaIva
                                            Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                                            Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                                            Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                                            Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                                            Case Else : Throw New Exception("TASA IVA DEL PRODUCTO INCORRECTA")
                                        End Select
                                        .c_IdEquipo._ContenidoCampo = xTarjetaProcesar.IdEquipoEstacion
                                        .c_AutoUsuario._ContenidoCampo = xTarjetaProcesar.Usuario.RegistroDato._AutoUsuario
                                        .c_TipoItem._ContenidoCampo = "6" 'TARJETA
                                        .c_NotasItem._ContenidoCampo = ""

                                        .c_EtiquetaTicket._ContenidoCampo = xreg1.RegistroDato._IdTarjeta
                                        .c_EtiquetaVendedor._ContenidoCampo = xreg1.RegistroDato._CodigoOperador
                                    End With

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
                                    xcmd.CommandText = PosOnline.PosVenta.INSERT
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
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("ITEM NO PUDO SER PROCESADO")
                                    End If
                                Next

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from panaderiapedidodetalles where id_tarjeta=@id"
                                xcmd.Parameters.AddWithValue("@id", xTarjetaProcesar.IdTarjeta)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from panaderiatarjeta where id=@id"
                                xcmd.Parameters.AddWithValue("@id", xTarjetaProcesar.IdTarjeta)
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            Return True
                        Catch ex2 As SqlException
                            Throw New Exception(ex2.Message + vbCrLf + ex2.Number.ToString)
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("ERROR AL PROCESAR TARJETA:" + vbCrLf + ex.Message)
                End Try
            End Function


        End Class

        Private xfichapanaderia As FichaPanaderia

        Property f_FichaPanaderia() As FichaPanaderia
            Get
                Return xfichapanaderia
            End Get
            Set(ByVal value As FichaPanaderia)
                xfichapanaderia = value
            End Set
        End Property
    End Class
End Namespace
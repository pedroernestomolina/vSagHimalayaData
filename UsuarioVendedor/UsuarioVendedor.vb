Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class UsuarioVendedor
            Event _ActualizarTabla()

            Class c_Registro
                Private f_auto_usuario As CampoDato
                Private f_auto_vendedor As CampoDato

                Property c_Usuario() As CampoDato
                    Get
                        Return Me.f_auto_usuario
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_auto_usuario = value
                    End Set
                End Property

                ReadOnly Property _AutoUsuario() As String
                    Get
                        Dim xv As String = IIf(Me.c_Usuario._RetornarValor(Of String)() Is Nothing, "", Me.c_Usuario._RetornarValor(Of String)())
                        Return xv
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

                Property c_Vendedor() As CampoDato
                    Get
                        Return Me.f_auto_vendedor
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_auto_vendedor = value
                    End Set
                End Property

                ReadOnly Property _AutoVendedor() As String
                    Get
                        Dim xv As String = IIf(Me.c_Vendedor._RetornarValor(Of String)() Is Nothing, "", Me.c_Vendedor._RetornarValor(Of String)())
                        Return xv
                    End Get
                End Property

                ReadOnly Property _f_FichaVendedor() As FichaVendedores.c_Vendedor.c_Registro
                    Get
                        Try
                            Dim xvendedor As New FichaVendedores
                            xvendedor.F_BuscarVendedor(_AutoVendedor)
                            Return xvendedor.f_Vendedor.RegistroDato
                        Catch ex As Exception
                            Return Nothing
                        End Try
                    End Get
                End Property

                Sub CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me
                            .Inicializar()

                            .c_Usuario._ContenidoCampo = xrow(.c_Usuario._NombreCampo)
                            .c_Vendedor._ContenidoCampo = xrow(.c_Vendedor._NombreCampo)
                        End With
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL CARGAR VINCULO (USUARIO - VENDEDOR)" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub Inicializar()
                    Try
                        InicializarDato(Me)
                    Catch ex As Exception
                        Dim x As String = "PROBLEMA AL INICIALIZAR CLASE (UsuarioVendedor)" + vbCrLf + ex.Message
                        Throw New Exception(x)
                    End Try
                End Sub

                Sub New()
                    Me.c_Usuario = New CampoDato("auto_usuario", 10)
                    Me.c_Vendedor = New CampoDato("auto_vendedor", 10)

                    Me.Inicializar()
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

            ''' <summary>
            ''' Busca y Cargar El Vinculo Existente Entre El Usuario y Vendedor
            ''' </summary>
            Function F_BuscarCargar(ByVal xautousuario As String) As Boolean
                Try
                    Dim xtb As New DataTable
                    Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.Clear()
                        xadap.SelectCommand.CommandText = "select * from usuario_vendedor where auto_usuario=@auto_usuario"
                        xadap.SelectCommand.Parameters.AddWithValue("@auto_usuario", xautousuario)
                        xadap.Fill(xtb)
                    End Using

                    If xtb.Rows.Count = 0 Then
                        Throw New Exception("NO EXISTE NINGUN VINCULO PARA ESTE USUARIO")
                    End If
                    Me.M_CargarFicha(xtb.Rows(0))
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL BUSCAR VINCULO USUARIO - VENDEDOR:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AgregarCrearVinculo(ByVal xauto_usuario As String, ByVal xauto_vendedor As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "insert into usuario_vendedor (auto_usuario, auto_vendedor) values (@auto_usuario, @auto_vendedor)"
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_usuario", xauto_usuario)
                                xcmd.Parameters.AddWithValue("@auto_vendedor", xauto_vendedor)
                                xcmd.ExecuteNonQuery()
                            End Using
                            RaiseEvent _ActualizarTabla()

                            Return True
                        Catch ex2 As SqlException
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("EXISTE UN VINCULO PARA ESTE USUARIO, VERIFIQUE")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number.ToString)
                            End Select
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL REGISTRAR VINCULO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_EliminarVinculo(ByVal xauto_usuario As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "delete usuario_vendedor where auto_usuario=@auto_usuario"
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_usuario", xauto_usuario)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("VINCULO NO ENCONTRADO / YA FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE")
                                End If
                            End Using
                            RaiseEvent _ActualizarTabla()

                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ELIMINAR VINCULO" + vbCrLf + ex.Message)
                End Try
            End Function

        End Class

        Private xfichaUsuarioVendedor As UsuarioVendedor

        Property f_UsuarioVendedor() As UsuarioVendedor
            Get
                Return xfichaUsuarioVendedor
            End Get
            Set(ByVal value As UsuarioVendedor)
                xfichaUsuarioVendedor = value
            End Set
        End Property


    End Class
End Namespace


Imports System.Data
Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class MensajesAlerta
            Enum EstatusMensajesAlerta As Integer
                Escuchado = 1
                NoEscuchado = 0
            End Enum

            Class c_Registro
                Private f_auto As CampoDato
                Private f_equipo_emisor As CampoDato
                Private f_usuario_emisor As CampoDato
                Private f_mensaje As CampoDato
                Private f_monto As CampoDato
                Private f_equipo_destino As CampoDato
                Private f_usuario_destino As CampoDato
                Private f_estatus As CampoDato

                Property c_Auto() As CampoDato
                    Get
                        Return Me.f_auto
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_auto = value
                    End Set
                End Property

                ReadOnly Property _Auto() As String
                    Get
                        Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_EquipoEmisor() As CampoDato
                    Get
                        Return Me.f_equipo_emisor
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_equipo_emisor = value
                    End Set
                End Property

                ReadOnly Property _EquipoEmisor() As String
                    Get
                        Dim xv As String = IIf(Me.f_equipo_emisor._RetornarValor(Of String)() Is Nothing, "", Me.f_equipo_emisor._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_UsuarioEmisor() As CampoDato
                    Get
                        Return Me.f_usuario_emisor
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_usuario_emisor = value
                    End Set
                End Property

                ReadOnly Property _UsuarioEmisor() As String
                    Get
                        Dim xv As String = IIf(Me.f_usuario_emisor._RetornarValor(Of String)() Is Nothing, "", Me.f_usuario_emisor._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_EquipoDestino() As CampoDato
                    Get
                        Return Me.f_equipo_destino
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_equipo_destino = value
                    End Set
                End Property

                ReadOnly Property _EquipoDestino() As String
                    Get
                        Dim xv As String = IIf(Me.f_equipo_destino._RetornarValor(Of String)() Is Nothing, "", Me.f_equipo_destino._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_UsuarioDestino() As CampoDato
                    Get
                        Return Me.f_usuario_destino
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_usuario_destino = value
                    End Set
                End Property

                ReadOnly Property _UsuarioDestino() As String
                    Get
                        Dim xv As String = IIf(Me.f_usuario_destino._RetornarValor(Of String)() Is Nothing, "", Me.f_usuario_destino._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_Mensaje() As CampoDato
                    Get
                        Return Me.f_mensaje
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_mensaje = value
                    End Set
                End Property

                ReadOnly Property _Mensaje() As String
                    Get
                        Dim xv As String = IIf(Me.f_mensaje._RetornarValor(Of String)() Is Nothing, "", Me.f_mensaje._RetornarValor(Of String)())
                        Return xv.Trim
                    End Get
                End Property

                Property c_Monto() As CampoDato
                    Get
                        Return Me.f_monto
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_monto = value
                    End Set
                End Property

                ReadOnly Property _Monto() As Decimal
                    Get
                        Dim xv As Decimal = IIf(Me.f_monto._ContenidoCampo Is Nothing, 0, Me.f_monto._RetornarValor(Of Decimal)())
                        Return xv
                    End Get
                End Property

                Property c_EstatusMovimiento() As CampoDato
                    Get
                        Return Me.f_estatus
                    End Get
                    Set(ByVal value As CampoDato)
                        Me.f_estatus = value
                    End Set
                End Property

                ReadOnly Property _EstatusMovimiento() As EstatusMensajesAlerta
                    Get
                        Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                        If xv = "0" Then
                            Return EstatusMensajesAlerta.NoEscuchado
                        Else
                            Return EstatusMensajesAlerta.Escuchado
                        End If
                    End Get
                End Property

                Sub New()
                    Me.c_Auto = New CampoDato("auto", 10)
                    Me.c_EquipoDestino = New CampoDato("equipo_destino", 20)
                    Me.c_EquipoEmisor = New CampoDato("equipo_emisor", 20)
                    Me.c_EstatusMovimiento = New CampoDato("estatus", 1)
                    Me.c_Mensaje = New CampoDato("mensaje", 60)
                    Me.c_Monto = New CampoDato("monto")
                    Me.c_UsuarioDestino = New CampoDato("usuario_destino", 20)
                    Me.c_UsuarioEmisor = New CampoDato("usuario_emisor", 20)

                    M_Limpiar()
                End Sub

                Sub M_Limpiar()
                    Try
                        InicializarDato(Me)
                    Catch ex As Exception
                        Dim x As String = "PROBLEMA AL INICIALIZAR CLASE: MENSAJES DE ALERTA" + vbCrLf + ex.Message
                        Throw New Exception(x)
                    End Try
                End Sub

                Sub CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me
                            .M_Limpiar()

                            .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                            .c_EquipoDestino._ContenidoCampo = xrow(.c_EquipoDestino._NombreCampo)
                            .c_EquipoEmisor._ContenidoCampo = xrow(.c_EquipoEmisor._NombreCampo)
                            .c_EstatusMovimiento._ContenidoCampo = xrow(.c_EstatusMovimiento._NombreCampo)
                            .c_Mensaje._ContenidoCampo = xrow(.c_Mensaje._NombreCampo)
                            .c_Monto._ContenidoCampo = xrow(.c_Monto._NombreCampo)
                            .c_UsuarioDestino._ContenidoCampo = xrow(.c_UsuarioDestino._NombreCampo)
                            .c_UsuarioEmisor._ContenidoCampo = xrow(.c_UsuarioEmisor._NombreCampo)
                        End With
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL CARGAR REGISTRO DE MENSAJE DE ALERTA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

            End Class

            Friend Const InsertMensajeAlerta As String = "INSERT INTO MensajesAlerta (" & _
                "auto," & _
                "equipo_emisor," & _
                "usuario_emisor," & _
                "mensaje," & _
                "monto," & _
                "equipo_destino," & _
                "usuario_destino," & _
                "estatus)" & _
                "VALUES (" & _
                "@auto," & _
                "@equipo_emisor," & _
                "@usuario_emisor," & _
                "@mensaje," & _
                "@monto," & _
                "@equipo_destino," & _
                "@usuario_destino," & _
                "@estatus)"

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

    End Class
End Namespace


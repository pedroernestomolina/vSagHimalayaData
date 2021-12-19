Imports System.Data.SqlClient
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class ControlGastos

            Public Class Conceptos
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_nombre As CampoDato
                    Private f_estatus As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Nombre() As CampoDato
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreConcepto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Nombre._RetornarValor(Of String)() Is Nothing, "", Me.c_Nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            If xv = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CONCEPTO" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Nombre = New CampoDato("nombre", 40)
                        Me.c_Estatus = New CampoDato("estatus", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_Nombre._ContenidoCampo = xrow(.c_Nombre._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR CONCEPTO" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarConcepto As String = "INSERT INTO GASTOS_CONCEPTOS (auto,nombre,estatus) values (@auto,@nombre,@estatus)"

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

                Function F_BuscarCargar(ByVal xAutoConceptoGasto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from gastos_conceptos where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xAutoConceptoGasto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Public Class SubConceptos
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_nombre As CampoDato
                    Private f_estatus As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Nombre() As CampoDato
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreConcepto() As String
                        Get
                            Dim xv As String = IIf(Me.c_Nombre._RetornarValor(Of String)() Is Nothing, "", Me.c_Nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            If xv = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR SUBCONCEPTOS " + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Nombre = New CampoDato("nombre", 40)
                        Me.c_Estatus = New CampoDato("estatus", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_Nombre._ContenidoCampo = xrow(.c_Nombre._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR SUBCONCEPTO" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Dim xregistro As c_Registro

                Protected Friend Const InsertarSubConcepto As String = "INSERT INTO GASTOS_SUBCONCEPTOS (auto,nombre,estatus) values (@auto,@nombre,@estatus)"

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

                Function F_BuscarCargar(ByVal xAutoConceptoGasto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from gastos_subconceptos where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xAutoConceptoGasto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb.Rows(0))
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
    End Class
End Namespace
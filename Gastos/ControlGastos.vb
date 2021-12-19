Imports System.Data.SqlClient
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class ControlGastos
            Event _ActualizarTablaGastos()
            Event _ConceptoEliminadoOk()

            Private xconceptos As Conceptos
            Private xsubconceptos As SubConceptos


            Property F_Concepto() As Conceptos
                Get
                    Return xconceptos
                End Get
                Set(ByVal value As Conceptos)
                    xconceptos = value
                End Set
            End Property

            Property F_SubConcepto() As SubConceptos
                Get
                    Return xsubconceptos
                End Get
                Set(ByVal value As SubConceptos)
                    xsubconceptos = value
                End Set
            End Property

            Sub New()
                F_Concepto = New Conceptos
                F_SubConcepto = New SubConceptos
            End Sub


            Class ActualizarConcepto
                Dim xfichaConcepto As Conceptos.c_Registro
                Dim xnombre_nuevo As String
                Dim xestatus_nuevo As Boolean

                Property _FichaActualizar() As Conceptos.c_Registro
                    Get
                        Return Me.xfichaConcepto
                    End Get
                    Set(ByVal value As Conceptos.c_Registro)
                        Me.xfichaConcepto = value
                    End Set
                End Property

                Property _NombreNuevo() As String
                    Get
                        Return Me.xnombre_nuevo
                    End Get
                    Set(ByVal value As String)
                        Me.xnombre_nuevo = value
                    End Set
                End Property

                Property _Estatus() As Boolean
                    Get
                        Return Me.xestatus_nuevo
                    End Get
                    Set(ByVal value As Boolean)
                        Me.xestatus_nuevo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property Estatus() As String
                    Get
                        If _Estatus = True Then
                            Return "0"
                        Else
                            Return "1"
                        End If
                    End Get
                End Property

                Sub New()
                    Me._Estatus = False
                    Me._NombreNuevo = ""
                    Me._FichaActualizar = Nothing
                End Sub
            End Class
            Class ActualizarSubConcepto
                Dim xfichaSubConcepto As SubConceptos.c_Registro
                Dim xnombre_nuevo As String
                Dim xestatus_nuevo As Boolean

                Property _FichaActualizar() As SubConceptos.c_Registro
                    Get
                        Return Me.xfichasubConcepto
                    End Get
                    Set(ByVal value As SubConceptos.c_Registro)
                        Me.xfichaSubConcepto = value
                    End Set
                End Property

                Property _NombreNuevo() As String
                    Get
                        Return Me.xnombre_nuevo
                    End Get
                    Set(ByVal value As String)
                        Me.xnombre_nuevo = value
                    End Set
                End Property

                Property _Estatus() As Boolean
                    Get
                        Return Me.xestatus_nuevo
                    End Get
                    Set(ByVal value As Boolean)
                        Me.xestatus_nuevo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property Estatus() As String
                    Get
                        If _Estatus = True Then
                            Return "0"
                        Else
                            Return "1"
                        End If
                    End Get
                End Property

                Sub New()
                    Me._Estatus = False
                    Me._NombreNuevo = ""
                    Me._FichaActualizar = Nothing
                End Sub
            End Class


            Function F_AgregarConcepto(ByVal xNuevoConcepto As String) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xitem As New Conceptos.c_Registro
                    With xitem
                        .c_Nombre._ContenidoCampo = xNuevoConcepto
                        .c_Estatus._ContenidoCampo = "0"
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_gastos_conceptos from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_gastos_conceptos=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_gastos_conceptos=a_gastos_conceptos+1;select a_gastos_conceptos from contadores"
                                xitem.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = Conceptos.InsertarConcepto
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Auto._NombreCampo, xitem._Auto).Size = xitem.c_Auto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Nombre._NombreCampo, xitem._NombreConcepto).Size = xitem.c_Nombre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Estatus._NombreCampo, xitem.c_Estatus._ContenidoCampo).Size = xitem.c_Estatus._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent _ActualizarTablaGastos()
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("CONCEPTO YA FUE REGISTRADO")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number)
                            End Select
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL AGREGAR CONCEPTO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_EliminarConcepto(ByVal xauto_concepto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from gastos_conceptos where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xauto_concepto)
                                If xcmd.ExecuteNonQuery() = 1 Then
                                Else
                                    Throw New Exception("CONCEPTO NO FUE ENCONTRADO / YA FUE ELIMINADO POR OTRO USUARIO")
                                End If
                            End Using
                            RaiseEvent _ConceptoEliminadoOk()
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ELIMINAR CONCEPTO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_ModificarConcepto(ByVal xficha_modificar As ActualizarConcepto) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update gastos_conceptos set nombre=@nombre, estatus=@estatus where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xficha_modificar._FichaActualizar._Auto)
                                xcmd.Parameters.AddWithValue("@nombre", xficha_modificar._NombreNuevo)
                                xcmd.Parameters.AddWithValue("@estatus", xficha_modificar.Estatus)
                                If xcmd.ExecuteNonQuery() = 1 Then
                                Else
                                    Throw New Exception("CONCEPTO GASTO NO ENCONTRADO / YA FUE ACTUALIZADO POR OTRO USUARIO")
                                End If
                            End Using
                            RaiseEvent _ActualizarTablaGastos()
                            Return True
                        Catch ex2 As SqlException
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("NOMBRE CONCEPTO YA REGISTRADO")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number)
                            End Select
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ACTUALIZAR CONCEPTO GASTO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AgregarSubConcepto(ByVal xNuevoConcepto As String) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Dim xitem As New Conceptos.c_Registro
                    With xitem
                        .c_Nombre._ContenidoCampo = xNuevoConcepto
                        .c_Estatus._ContenidoCampo = "0"
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_gastos_subconceptos from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_gastos_subconceptos=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_gastos_subconceptos=a_gastos_subconceptos+1;select a_gastos_subconceptos from contadores"
                                xitem.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = SubConceptos.InsertarSubConcepto
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Auto._NombreCampo, xitem._Auto).Size = xitem.c_Auto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Nombre._NombreCampo, xitem._NombreConcepto).Size = xitem.c_Nombre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xitem.c_Estatus._NombreCampo, xitem.c_Estatus._ContenidoCampo).Size = xitem.c_Estatus._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent _ActualizarTablaGastos()
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("SUBCONCEPTO YA FUE REGISTRADO")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number)
                            End Select
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL AGREGAR SUBCONCEPTO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_EliminarSubConcepto(ByVal xauto_subconcepto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete from gastos_subconceptos where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xauto_subconcepto)
                                If xcmd.ExecuteNonQuery() = 1 Then
                                Else
                                    Throw New Exception("SUBCONCEPTO NO FUE ENCONTRADO / YA FUE ELIMINADO POR OTRO USUARIO")
                                End If
                            End Using
                            RaiseEvent _ConceptoEliminadoOk()
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ELIMINAR SUBCONCEPTO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_ModificarSubConcepto(ByVal xficha_modificar As ActualizarSubConcepto) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update gastos_subconceptos set nombre=@nombre, estatus=@estatus where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xficha_modificar._FichaActualizar._Auto)
                                xcmd.Parameters.AddWithValue("@nombre", xficha_modificar._NombreNuevo)
                                xcmd.Parameters.AddWithValue("@estatus", xficha_modificar.Estatus)
                                If xcmd.ExecuteNonQuery() = 1 Then
                                Else
                                    Throw New Exception("SUBCONCEPTO NO ENCONTRADO / YA FUE ACTUALIZADO POR OTRO USUARIO")
                                End If
                            End Using
                            RaiseEvent _ActualizarTablaGastos()
                            Return True
                        Catch ex2 As SqlException
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("NOMBRE SUBCONCEPTO YA REGISTRADO")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number)
                            End Select
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL ACTUALIZAR SUBCONCEPTO" + vbCrLf + ex.Message)
                End Try
            End Function

        End Class

        Private xfichagastos As ControlGastos

        Property f_FichaGastos() As ControlGastos
            Get
                Return Me.xfichagastos
            End Get
            Set(ByVal value As ControlGastos)
                Me.xfichagastos = value
            End Set
        End Property
    End Class
End Namespace


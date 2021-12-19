Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute
Imports ImpFiscales.MisFiscales
Imports DataSistema.MiDataSistema.DataSistema

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL MENUPLATOS
        ''' </summary>
        Public Class FichaMenuPlatos
            Event ActualizarTabla()

            ''' <summary>
            ''' Tipo Usado Para Identificar El Tipo De Busqueda Del Plato
            ''' </summary>
            Enum TipoBusquedaPlato As Integer
                PorCodigo = 0
                PorDescripcion = 1
                PorPLU = 2
            End Enum

            ''' <summary>
            ''' Clase. USADA PARA CONTENER LAS ESTACIONES A USAR POR LOS PLATOS
            ''' </summary>
            Public Class Estacion_FastFood

                Event EstacionProcesada()

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_ruta As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Auto De La Estacion
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Automatico De La Estacion
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Nombre De La Estacion
                    ''' </summary>
                    Protected Friend Property c_NombreEstacion() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Nombre De La Estacion
                    ''' </summary>
                    ReadOnly Property _NombreEstacion() As String
                        Get
                            Return c_NombreEstacion.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Ruta De La Estacion
                    ''' </summary>
                    Protected Friend Property c_RutaEstacion() As CampoTexto
                        Get
                            Return f_ruta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_ruta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna La Ruta Establecida Para La Estacion
                    ''' </summary>
                    ReadOnly Property _RutaEstacion() As String
                        Get
                            Return c_RutaEstacion.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Estatus De La Estacion
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Estado De La Estacion
                    ''' </summary>
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case Me.c_Estatus.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Id Seguridad Del Grupo
                    ''' </summary>
                    Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property


                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_NombreEstacion = New CampoTexto(20, "nombre")
                        Me.c_RutaEstacion = New CampoTexto(250, "ruta")

                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreEstacion.c_Texto = xrow(.c_NombreEstacion.c_NombreInterno)
                                .c_RutaEstacion.c_Texto = xrow(.c_RutaEstacion.c_NombreInterno)
                                ._IdSeguridad = xrow("id_seguridad")

                                If Not IsDBNull(xrow(.c_Estatus.c_NombreInterno)) Then
                                    .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                Else
                                    .c_Estatus.c_Texto = "0"
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU-PLATOS" + vbCrLf + "ESTACION FASTFOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarEstacion
                    Private xnombre As String
                    Private xruta As String
                    Private xestatus As TipoEstatus

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre De La Estacion
                    ''' </summary>                    
                    Property _NombreEstacion() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set La Ruta Establecida Para La Estacion
                    ''' </summary>                    
                    Property _RutaEstacion() As String
                        Get
                            Return xruta
                        End Get
                        Set(ByVal value As String)
                            xruta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Estatus De La Estacion
                    ''' </summary>                    
                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property
                End Class

                Class c_ModificarEstacion
                    Private xestacion As FichaMenuPlatos.Estacion_FastFood.c_Registro
                    Private xnombre As String
                    Private xruta As String
                    Private xestatus As TipoEstatus

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre De La Estacion
                    ''' </summary>                    
                    Property _NombreEstacion() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set La Ruta Establecida Para La Estacion
                    ''' </summary>                    
                    Property _RutaEstacion() As String
                        Get
                            Return xruta
                        End Get
                        Set(ByVal value As String)
                            xruta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Estatus De La Estacion
                    ''' </summary>                    
                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set La Ficha De La Estacion A Modificar
                    ''' </summary>                    
                    Property _FichaEstacion() As FichaMenuPlatos.Estacion_FastFood.c_Registro
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As FichaMenuPlatos.Estacion_FastFood.c_Registro)
                            xestacion = value
                        End Set
                    End Property
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
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

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.M_LimpiarRegistro()
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from estacion_fastfood where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("ESTACION FAST FOOD" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Dim InsertarEstacion As String = "insert into estacion_fastfood (auto, nombre, ruta, estatus) " _
                                            + "values(@auto,@nombre,@ruta,@estatus)"

                Dim ActualizarEstacion As String = "update estacion_fastfood set nombre=@nombre, " _
                                              + "ruta=@ruta, estatus=@estatus where auto=@auto and id_seguridad=@id "

                Dim EliminarEstacion As String = "delete from estacion_fastfood where auto=@auto and id_seguridad=@id"

                ''' <summary>
                ''' Metodo: Permite Grabar Una Estacion Para FastFood
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DE LA ESTACION A GRABAR                
                Function F_GrabarEstacion(ByVal xgrabar As FichaMenuPlatos.Estacion_FastFood.c_AgregarEstacion) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_estacion_fastfood=a_estacion_fastfood+1; select a_estacion_fastfood from contadores"
                        Dim xauto_1 As String = ""

                        Dim xestacion As New FichaMenuPlatos.Estacion_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

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
                                    xauto_1 = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    With xestacion
                                        .c_Automatico.c_Texto = xauto_1
                                        .c_Estatus.c_Texto = IIf(xgrabar._Estatus = TipoEstatus.Activo, "0", "1")
                                        .c_NombreEstacion.c_Texto = xgrabar._NombreEstacion
                                        .c_RutaEstacion.c_Texto = xgrabar._RutaEstacion
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xestacion.c_Automatico.c_Texto).Size = xestacion.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xestacion.c_NombreEstacion.c_Texto).Size = xestacion.c_NombreEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@ruta", xestacion.c_RutaEstacion.c_Texto).Size = xestacion.c_RutaEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xestacion.c_Estatus.c_Texto).Size = xestacion.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent EstacionProcesada()
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
                        Throw New Exception("MENU PLATOS" + vbCrLf + "GRABAR ESTACION FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Metodo: Permite Actualizar Una Estacion Para FastFood
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DE LA ESTACION A MODIFICAR              
                Function F_ActualizarEstacion(ByVal xgrabar As FichaMenuPlatos.Estacion_FastFood.c_ModificarEstacion) As Boolean
                    Try
                        Dim xestacion As New FichaMenuPlatos.Estacion_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    With xestacion
                                        .c_Automatico.c_Texto = xgrabar._FichaEstacion._Automatico
                                        .c_Estatus.c_Texto = IIf(xgrabar._Estatus = TipoEstatus.Activo, "0", "1")
                                        .c_NombreEstacion.c_Texto = xgrabar._NombreEstacion
                                        .c_RutaEstacion.c_Texto = xgrabar._RutaEstacion
                                        ._IdSeguridad = xgrabar._FichaEstacion._IdSeguridad
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xestacion.c_Automatico.c_Texto).Size = xestacion.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xestacion.c_NombreEstacion.c_Texto).Size = xestacion.c_NombreEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@ruta", xestacion.c_RutaEstacion.c_Texto).Size = xestacion.c_RutaEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xestacion.c_Estatus.c_Texto).Size = xestacion.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xestacion._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... LA ESTACION FUE ACTUALIZADA POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent EstacionProcesada()
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

                ''' <summary>
                ''' Metodo: Permite Eliminar Una Estacion Para FastFood
                ''' </summary>
                ''' <param name="xestacion"></param>
                ''' CLASE FICHA ESTACION
                Function F_EliminarEstacion(ByVal xestacion As FichaMenuPlatos.Estacion_FastFood.c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xestacion.c_Automatico.c_Texto).Size = xestacion.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xestacion._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... LA ESTACION FUE ACTUALIZADA POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent EstacionProcesada()
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
                        Throw New Exception("MENU PLATOS" + vbCrLf + "ELIMINAR ESTACION FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' Clase. USADA PARA CONTENER LOS GRUPOS DEL MENU
            ''' </summary>
            Public Class Grupo_FastFood

                Event GrupoProcesado()

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre_grupo As CampoTexto
                    Private f_nombre_boton As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Auto Del Grupo
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Automatico Del Grupo
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Nombre Del Grupo
                    ''' </summary>
                    Protected Friend Property c_NombreGrupo() As CampoTexto
                        Get
                            Return f_nombre_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_grupo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Nombre Del Grupo
                    ''' </summary>
                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Return c_NombreGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Nombre Del Boton
                    ''' </summary>
                    Protected Friend Property c_NombreBoton() As CampoTexto
                        Get
                            Return f_nombre_boton
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_boton = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Nombre Establecido Para El Boton
                    ''' </summary>
                    ReadOnly Property _NombreBoton() As String
                        Get
                            Return c_NombreBoton.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Estatus Del Grupo
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Retorna El Estado Del Grupo
                    ''' </summary>
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case Me.c_Estatus.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Id Seguridad Del Grupo
                    ''' </summary>
                    Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_NombreBoton = New CampoTexto(30, "nombre_boton")
                        Me.c_NombreGrupo = New CampoTexto(60, "nombre_grupo")
                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_NombreBoton.c_Texto = xrow(.c_NombreBoton.c_NombreInterno)
                                .c_NombreGrupo.c_Texto = xrow(.c_NombreGrupo.c_NombreInterno)
                                ._IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU-PLATOS" + vbCrLf + "GRUPO FASTFOOD" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarGrupo
                    Private xnombre_grupo As String
                    Private xnombre_boton As String
                    Private xestatus As TipoEstatus

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre Del Grupo
                    ''' </summary>                    
                    Property _NombreGrupo() As String
                        Get
                            Return xnombre_grupo
                        End Get
                        Set(ByVal value As String)
                            xnombre_grupo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre Establecido Para El Boton
                    ''' </summary>                    
                    Property _NombreBoton() As String
                        Get
                            Return xnombre_boton
                        End Get
                        Set(ByVal value As String)
                            xnombre_boton = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Estatus Del Grupo
                    ''' </summary>                    
                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property
                End Class

                Class c_ModificarGrupo
                    Private xgrupo As FichaMenuPlatos.Grupo_FastFood.c_Registro
                    Private xnombre_grupo As String
                    Private xnombre_boton As String
                    Private xestatus As TipoEstatus

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre Del Grupo
                    ''' </summary>                    
                    Property _NombreGrupo() As String
                        Get
                            Return xnombre_grupo
                        End Get
                        Set(ByVal value As String)
                            xnombre_grupo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Nombre Establecido Para El Boton
                    ''' </summary>                    
                    Property _NombreBoton() As String
                        Get
                            Return xnombre_boton
                        End Get
                        Set(ByVal value As String)
                            xnombre_boton = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Estatus Del Grupo
                    ''' </summary>                    
                    Property _Estatus() As TipoEstatus
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set La Ficha Del Grupo A Modificar
                    ''' </summary>                    
                    Property _FichaGrupo() As FichaMenuPlatos.Grupo_FastFood.c_Registro
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As FichaMenuPlatos.Grupo_FastFood.c_Registro)
                            xgrupo = value
                        End Set
                    End Property
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
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

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.M_LimpiarRegistro()
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from grupo_fastfood where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("GRUPO FAST FOOD" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Dim InsertarGrupo As String = "insert into grupo_fastfood (auto, nombre_grupo, nombre_boton, estatus) " _
                                            + "values(@auto,@nombre_grupo,@nombre_boton,@estatus)"

                Dim ActualizarGrupo As String = "update grupo_fastfood set nombre_grupo=@nombre_grupo, " _
                                              + "nombre_boton=@nombre_boton, estatus=@estatus where auto=@auto and id_seguridad=@id "

                Dim EliminarGrupo As String = "delete grupo_fastfood where auto=@auto and id_seguridad=@id"
                ''' <summary>
                ''' Metodo: Permite Grabar Un Grupo De Menu
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DEL GRUPO A GRABAR                
                Function F_GrabarGrupo(ByVal xgrabar As FichaMenuPlatos.Grupo_FastFood.c_AgregarGrupo) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_grupo_fastfood=a_grupo_fastfood+1; select a_grupo_fastfood from contadores"
                        Dim xauto_1 As String = ""

                        Dim xgrupo As New FichaMenuPlatos.Grupo_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.CommandText = "select a_grupo_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_grupo_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If

                                    xcmd.CommandText = xsql_1
                                    xauto_1 = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    With xgrupo
                                        .c_Automatico.c_Texto = xauto_1
                                        .c_Estatus.c_Texto = IIf(xgrabar._Estatus = TipoEstatus.Activo, "0", "1")
                                        .c_NombreBoton.c_Texto = xgrabar._NombreBoton
                                        .c_NombreGrupo.c_Texto = xgrabar._NombreGrupo
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarGrupo
                                    xcmd.Parameters.AddWithValue("@auto", xgrupo.c_Automatico.c_Texto).Size = xgrupo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_grupo", xgrupo.c_NombreGrupo.c_Texto).Size = xgrupo.c_NombreGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_boton", xgrupo.c_NombreBoton.c_Texto).Size = xgrupo.c_NombreBoton.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xgrupo.c_Estatus.c_Texto).Size = xgrupo.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent GrupoProcesado()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE DEL GRUPO / NOMBRE DE BOTON YA EXISTENTE, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS" + vbCrLf + "GRABAR GRUPO FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Metodo: Permite Actualizar Un Grupo De Menu
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DEL GRUPO A MODIFICAR              
                Function F_ActualizarGrupo(ByVal xgrabar As FichaMenuPlatos.Grupo_FastFood.c_ModificarGrupo) As Boolean
                    Try
                        Dim xgrupo As New FichaMenuPlatos.Grupo_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    With xgrupo
                                        .c_Automatico.c_Texto = xgrabar._FichaGrupo._Automatico
                                        .c_Estatus.c_Texto = IIf(xgrabar._Estatus = TipoEstatus.Activo, "0", "1")
                                        .c_NombreBoton.c_Texto = xgrabar._NombreBoton
                                        .c_NombreGrupo.c_Texto = xgrabar._NombreGrupo
                                        ._IdSeguridad = xgrabar._FichaGrupo._IdSeguridad
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarGrupo
                                    xcmd.Parameters.AddWithValue("@auto", xgrupo.c_Automatico.c_Texto).Size = xgrupo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_grupo", xgrupo.c_NombreGrupo.c_Texto).Size = xgrupo.c_NombreGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_boton", xgrupo.c_NombreBoton.c_Texto).Size = xgrupo.c_NombreBoton.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xgrupo.c_Estatus.c_Texto).Size = xgrupo.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xgrupo._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL GRUPO FUE ACTUALIZADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent GrupoProcesado()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE DEL GRUPO / NOMBRE DE BOTON YA EXISTENTE, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS" + vbCrLf + "MODIFICAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Metodo: Permite Eliminar Un Grupo De Menu
                ''' </summary>
                ''' <param name="xgrupo"></param>
                ''' CLASE FICHA GRUPO
                Function F_EliminarGrupo(ByVal xgrupo As FichaMenuPlatos.Grupo_FastFood.c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarGrupo
                                    xcmd.Parameters.AddWithValue("@auto", xgrupo.c_Automatico.c_Texto).Size = xgrupo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xgrupo._IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL GRUPO FUE ACTUALIZADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent GrupoProcesado()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 547 Then
                                    Throw New Exception("ERROR... EL GRUPO NO PUEDE SER ELIMINADO, POSEE PLATOS RELACIONADOS")
                                Else
                                    Throw New Exception(ex.Message)
                                End If

                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS" + vbCrLf + "ELIMINAR GRUPO FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' Clase. USADA PARA CONTENER LOS PLATOS DEL MENU
            ''' </summary>
            Public Class MenuPlatos_FastFood
                Event PlatoRegistrado(ByVal xauto As String)
                Event ActualizarFicha()

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_grupo As CampoTexto
                    Private f_nombre_plato As CampoTexto
                    Private f_nombre_boton As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_precio_1 As CampoDecimal
                    Private f_precio_2 As CampoDecimal
                    Private f_impuesto As CampoTexto
                    Private f_tasa As CampoDecimal
                    Private f_pesado_unidad As CampoTexto
                    Private f_comentarios As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_escombo As CampoTexto
                    Private f_esoferta As CampoTexto
                    Private f_fecha_inicio As CampoFecha
                    Private f_fecha_final As CampoFecha
                    Private f_precio_oferta As CampoDecimal
                    Private f_id_seguridad As Byte()
                    Private f_fecha_alta As CampoFecha
                    Private f_fecha_ult_actualizacion As CampoFecha
                    Private f_estatus_balanza As CampoTexto
                    Private f_PLU As CampoTexto
                    Private f_costo_plato As CampoDecimal
                    Private f_utilidad_1 As CampoDecimal
                    Private f_utilidad_2 As CampoDecimal
                    Private f_utilidad_oferta As CampoDecimal

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Auto Del Plato
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Plato
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Auto Del Grupo
                    ''' </summary>
                    Protected Friend Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Grupo
                    ''' </summary>
                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return c_AutoGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Nombre Del Plato
                    ''' </summary>              
                    Protected Friend Property c_NombrePlato() As CampoTexto
                        Get
                            Return f_nombre_plato
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_plato = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Nombre Del Plato
                    ''' </summary>
                    ReadOnly Property _NombrePlato() As String
                        Get
                            Return c_NombrePlato.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Nombre Del Boton
                    ''' </summary>
                    Protected Friend Property c_NombreBoton() As CampoTexto
                        Get
                            Return f_nombre_boton
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_boton = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Nombre Establecido Para El Boton
                    ''' </summary>
                    ReadOnly Property _NombreBoton() As String
                        Get
                            Return c_NombreBoton.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Codigo Del Plato
                    ''' </summary>
                    Protected Friend Property c_CodigoPlato() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Codigo Del Plato
                    ''' </summary>
                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Return c_CodigoPlato.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Precio 1
                    ''' </summary>
                    Protected Friend Property c_Precio_1() As CampoDecimal
                        Get
                            Return f_precio_1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Precio 1 Neto Del Plato
                    ''' </summary>
                    ReadOnly Property _Precio_1() As Precio
                        Get
                            Return New Precio(c_Precio_1.c_Valor, c_TasaImpuesto.c_Valor)
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Precio 2
                    ''' </summary>
                    Protected Friend Property c_Precio_2() As CampoDecimal
                        Get
                            Return f_precio_2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Precio 2 Neto Del Plato
                    ''' </summary>
                    ReadOnly Property _Precio_2() As Precio
                        Get
                            Return New Precio(c_Precio_2.c_Valor, c_TasaImpuesto.c_Valor)
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Impuesto
                    ''' </summary>
                    Property c_TipoImpuesto() As CampoTexto
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_impuesto = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Tipo De Impuesto Del Plato
                    ''' </summary>
                    ReadOnly Property _TipoImpuesto() As TipoTasaImpuesto
                        Get
                            Select Case Me.c_TipoImpuesto.c_Texto.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Tasa
                    ''' </summary>
                    Protected Friend Property c_TasaImpuesto() As CampoDecimal
                        Get
                            Return f_tasa
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_tasa = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna La Tasa Del Impuesto Del Plato
                    ''' </summary>
                    ReadOnly Property _TasaImpuesto() As Decimal
                        Get
                            Return c_TasaImpuesto.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Pesado_Unidad
                    ''' </summary>
                    Protected Friend Property c_PesadoUnidad() As CampoTexto
                        Get
                            Return f_pesado_unidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_pesado_unidad = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna Si El Plato Es De Tipo Pesado O Unidad
                    ''' </summary>
                    ReadOnly Property _PesadoUnidad() As TipoProductoBalanza
                        Get
                            Select Case Me.c_PesadoUnidad.c_Texto.Trim.ToUpper
                                Case "U" : Return TipoProductoBalanza.Unidad
                                Case "P" : Return TipoProductoBalanza.Pesado
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Comentarios
                    ''' </summary>
                    Protected Friend Property c_Comentarios() As CampoTexto
                        Get
                            Return f_comentarios
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comentarios = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna Los Comentario Acerca Del Plato
                    ''' </summary>
                    ReadOnly Property _Comentarios() As String
                        Get
                            Return c_Comentarios.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Estatus
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Estado Del Plato
                    ''' </summary>
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case c_Estatus.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo EsCombo
                    ''' </summary>
                    Protected Friend Property c_EsCombo() As CampoTexto
                        Get
                            Return f_escombo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_escombo = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna Si El Plato Es Un Combo
                    ''' </summary>
                    ReadOnly Property _EstatusCombo() As TipoSiNo
                        Get
                            Select Case c_EsCombo.c_Texto.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _EsCombo() As TipoSiNo
                        Get
                            Dim xp1 As New SqlParameter("@auto", _Automatico)
                            Dim xr As Integer = F_GetInteger("select count(*) from menucombos_fastfood where auto_plato_combo=@auto", xp1)
                            If _EstatusCombo = TipoSiNo.Si And xr > 0 Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo EsOferta
                    ''' </summary>
                    Protected Friend Property c_EsOferta() As CampoTexto
                        Get
                            Return f_esoferta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_esoferta = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna Si Se Aplicado o No La Oferta
                    ''' </summary>
                    ReadOnly Property _EsOferta() As TipoSiNo
                        Get
                            Select Case Me.c_EsOferta.c_Texto.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Fecha Inicio
                    ''' </summary>
                    Protected Friend Property c_FechaInicio() As CampoFecha
                        Get
                            Return f_fecha_inicio
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_inicio = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna La Fecha Inicial De La Oferta
                    ''' </summary>
                    ReadOnly Property _FechaInicio() As Date
                        Get
                            Return c_FechaInicio.c_Valor.Date
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Fecha Final
                    ''' </summary>
                    Protected Friend Property c_FechaFinal() As CampoFecha
                        Get
                            Return f_fecha_final
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_final = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna La Fecha Final De La Oferta
                    ''' </summary>
                    ReadOnly Property _FechaFinal() As Date
                        Get
                            Return c_FechaFinal.c_Valor.Date
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Precio Oferta
                    ''' </summary>
                    Protected Friend Property c_PrecioOferta() As CampoDecimal
                        Get
                            Return f_precio_oferta
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_oferta = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Precio Oferta Neto Del Plato
                    ''' </summary>
                    ReadOnly Property _PrecioOferta() As Precio
                        Get
                            Return New Precio(c_PrecioOferta.c_Valor, c_TasaImpuesto.c_Valor, Precio.TipoFuncion.Desglozar)
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set El Id Seguridad Del Plato
                    ''' </summary>
                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Fecha Alta
                    ''' </summary>
                    Protected Friend Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna La Fecha De Registro Del Plato
                    ''' </summary>
                    ReadOnly Property _FechaAlta() As Date
                        Get
                            Return c_FechaAlta.c_Valor.Date
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Fecha Ult Actualizacion
                    ''' </summary>
                    Protected Friend Property c_FechaUltActualizacion() As CampoFecha
                        Get
                            Return f_fecha_ult_actualizacion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_ult_actualizacion = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna La Ultima Fecha De Actualizacion Del Plato
                    ''' </summary>
                    ReadOnly Property _FechaUltActualizacion() As Date
                        Get
                            Return c_FechaUltActualizacion.c_Valor.Date
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Estatus Balanza
                    ''' </summary>
                    Protected Friend Property c_EstatusBalanza() As CampoTexto
                        Get
                            Return f_estatus_balanza
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_balanza = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna Si El Plato Usa Balanza
                    ''' </summary>
                    ReadOnly Property _EstatusBalanza() As TipoEstatus
                        Get
                            If Me.c_EstatusBalanza.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo PLU
                    ''' </summary>
                    Protected Friend Property c_CodigoPLU() As CampoTexto
                        Get
                            Return f_PLU
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_PLU = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Codigo PLU Del Plato
                    ''' </summary>
                    ReadOnly Property _CodigoPLU() As String
                        Get
                            Return c_CodigoPLU.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Costo De Plato
                    ''' </summary>
                    Protected Friend Property c_CostoPlato() As CampoDecimal
                        Get
                            Return f_costo_plato
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo_plato = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Costo Del Plato
                    ''' </summary>
                    ReadOnly Property _CostoPlato() As Decimal
                        Get
                            Return c_CostoPlato.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Utilidad Del Precio 1
                    ''' </summary>
                    Protected Friend Property c_Utilidad1() As CampoDecimal
                        Get
                            Return f_utilidad_1
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_utilidad_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Margen De Utilidad Asignado Al Precio 1
                    ''' </summary>
                    ReadOnly Property _UtilidadPrecio_1() As Decimal
                        Get
                            Return Me.c_Utilidad1.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Utilidad Del Precio 2
                    ''' </summary>
                    Protected Friend Property c_Utilidad2() As CampoDecimal
                        Get
                            Return f_utilidad_2
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_utilidad_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Margen De Utilidad Asignado Al Precio 2
                    ''' </summary>
                    ReadOnly Property _UtilidadPrecio_2() As Decimal
                        Get
                            Return Me.c_Utilidad2.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Propiedad: Get o Set Las Caracteristicas Del Campo Utilidad Del Precio Oferta
                    ''' </summary>
                    Protected Friend Property c_UtilidadOferta() As CampoDecimal
                        Get
                            Return f_utilidad_oferta
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_utilidad_oferta = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Margen De Utilidad Asignado Al Precio Oferta
                    ''' </summary>
                    ReadOnly Property _UtilidadPrecioOferta() As Decimal
                        Get
                            Return Me.c_UtilidadOferta.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As TipoEstatus
                        Get
                            If _EstatusBalanza = TipoEstatus.Activo And _PesadoUnidad = TipoProductoBalanza.Pesado Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Dim xp1 As New SqlParameter("@auto", _AutoGrupo)
                            Dim xt As String = ""
                            xt = F_GetString("select nombre_grupo from grupo_fastfood where auto=@auto", xp1)
                            Return xt.Trim
                        End Get
                    End Property

                    'PROPIEDADES ADICIONALES
                    Dim xgrupo As FichaMenuPlatos.Grupo_FastFood
                    Property _FichaGrupo() As FichaMenuPlatos.Grupo_FastFood
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As FichaMenuPlatos.Grupo_FastFood)
                            xgrupo = value
                        End Set
                    End Property

                    Function f_VerificarOferta() As Boolean
                        Dim xret As Boolean = False
                        If _EsOferta = TipoSiNo.Si Then
                            If _FechaFinal >= _FechaSistema(_MiCadenaConexion) Then
                                xret = True
                            End If
                        End If
                        Return xret
                    End Function

                    ReadOnly Property _PrecioVentaActual() As Precio
                        Get
                            If f_VerificarOferta() Then
                                Return _PrecioOferta
                            Else
                                Return _Precio_1
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoGrupo = New CampoTexto(10, "auto_grupo")
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_CodigoPlato = New CampoTexto(15, "codigo")
                        Me.c_Comentarios = New CampoTexto(120, "comentarios")
                        Me.c_EsCombo = New CampoTexto(1, "escombo")
                        Me.c_EsOferta = New CampoTexto(1, "esoferta")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_FechaAlta = New CampoFecha("fecha_alta")
                        Me.c_FechaFinal = New CampoFecha("fecha_final")
                        Me.c_FechaInicio = New CampoFecha("fecha_inicio")
                        Me.c_NombreBoton = New CampoTexto(30, "nombre_boton")
                        Me.c_NombrePlato = New CampoTexto(120, "nombre_plato")
                        Me.c_PesadoUnidad = New CampoTexto(1, "pesado_unidad")
                        Me.c_Precio_1 = New CampoDecimal("precio_1")
                        Me.c_Precio_2 = New CampoDecimal("precio_2")
                        Me.c_PrecioOferta = New CampoDecimal("precio_oferta")
                        Me.c_TasaImpuesto = New CampoDecimal("tasa")
                        Me.c_TipoImpuesto = New CampoTexto(1, "impuesto")
                        Me.c_EstatusBalanza = New CampoTexto(1, "estatus_balanza")
                        Me.c_CodigoPLU = New CampoTexto(5, "PLU")
                        Me.c_FechaUltActualizacion = New CampoFecha("fecha_ult_actualizacion")
                        Me.c_CostoPlato = New CampoDecimal("costo_plato")
                        Me.c_Utilidad1 = New CampoDecimal("utilidad_1")
                        Me.c_Utilidad2 = New CampoDecimal("utilidad_2")
                        Me.c_UtilidadOferta = New CampoDecimal("utilidad_oferta")

                        Me._FichaGrupo = New FichaMenuPlatos.Grupo_FastFood
                        Me.M_LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_AutoGrupo.c_Texto = xrow(.c_AutoGrupo.c_NombreInterno)
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_CodigoPlato.c_Texto = xrow(.c_CodigoPlato.c_NombreInterno)
                                .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                                .c_EsCombo.c_Texto = xrow(.c_EsCombo.c_NombreInterno)
                                .c_EsOferta.c_Texto = xrow(.c_EsOferta.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                                .c_FechaFinal.c_Valor = xrow(.c_FechaFinal.c_NombreInterno)
                                .c_FechaInicio.c_Valor = xrow(.c_FechaInicio.c_NombreInterno)
                                .c_IdSeguridad = xrow("id_seguridad")
                                .c_NombreBoton.c_Texto = xrow(.c_NombreBoton.c_NombreInterno)
                                .c_NombrePlato.c_Texto = xrow(.c_NombrePlato.c_NombreInterno)
                                .c_PesadoUnidad.c_Texto = xrow(.c_PesadoUnidad.c_NombreInterno)
                                .c_Precio_1.c_Valor = xrow(.c_Precio_1.c_NombreInterno)
                                .c_Precio_2.c_Valor = xrow(.c_Precio_2.c_NombreInterno)
                                .c_PrecioOferta.c_Valor = xrow(.c_PrecioOferta.c_NombreInterno)
                                .c_TasaImpuesto.c_Valor = xrow(.c_TasaImpuesto.c_NombreInterno)
                                .c_TipoImpuesto.c_Texto = xrow(.c_TipoImpuesto.c_NombreInterno)
                                .c_EstatusBalanza.c_Texto = xrow(.c_EstatusBalanza.c_NombreInterno)
                                .c_CodigoPLU.c_Texto = xrow(.c_CodigoPLU.c_NombreInterno)
                                .c_FechaUltActualizacion.c_Valor = xrow(.c_FechaUltActualizacion.c_NombreInterno)
                                If Not IsDBNull(xrow(.c_CostoPlato.c_NombreInterno)) Then
                                    .c_CostoPlato.c_Valor = xrow(.c_CostoPlato.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Utilidad1.c_NombreInterno)) Then
                                    .c_Utilidad1.c_Valor = xrow(.c_Utilidad1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Utilidad2.c_NombreInterno)) Then
                                    .c_Utilidad2.c_Valor = xrow(.c_Utilidad2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_UtilidadOferta.c_NombreInterno)) Then
                                    .c_UtilidadOferta.c_Valor = xrow(.c_UtilidadOferta.c_NombreInterno)
                                End If
                            End With

                            _FichaGrupo.F_CargarRegistro(Me.c_AutoGrupo.c_Texto)

                        Catch ex As Exception
                            Throw New Exception("MENU-PLATOS" + vbCrLf + "MENU PLATOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarPlato
                    Private xcodigo As String
                    Private xnombre_plato As String
                    Private xnombre_boton As String
                    Private xgrupo As Grupo_FastFood.c_Registro
                    Private xtasa As FichaGlobal.c_TasasFiscales.Tasas
                    Private xestatus As String
                    Private xfecha As Date
                    Private xprecio_1 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xcosto As Decimal

                    Property _CodigoPlato() As String
                        Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As String)
                            xcodigo = value
                        End Set
                    End Property

                    Property _NombrePlato() As String
                        Get
                            Return xnombre_plato
                        End Get
                        Set(ByVal value As String)
                            xnombre_plato = value
                        End Set
                    End Property

                    Property _NombreBoton() As String
                        Get
                            Return xnombre_boton
                        End Get
                        Set(ByVal value As String)
                            xnombre_boton = value
                        End Set
                    End Property

                    Property _FichaGrupo() As Grupo_FastFood.c_Registro
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As Grupo_FastFood.c_Registro)
                            xgrupo = value
                        End Set
                    End Property

                    Property _TasaFiscal() As FichaGlobal.c_TasasFiscales.Tasas
                        Get
                            Return xtasa
                        End Get
                        Set(ByVal value As FichaGlobal.c_TasasFiscales.Tasas)
                            xtasa = value
                        End Set
                    End Property

                    Property _FechaRegistro() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Property _PrecioNeto_1() As Decimal
                        Get
                            Return xprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_1 = value
                        End Set
                    End Property

                      Property _UtilidadPrecio_1() As Decimal
                        Get
                            Return xutilidad_1
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidad_1 = value
                        End Set
                    End Property

                   
                    Property _CostoPlato() As Decimal
                        Get
                            Return xcosto
                        End Get
                        Set(ByVal value As Decimal)
                            xcosto = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As String
                        Get
                            Return "0"
                        End Get
                    End Property
                End Class

                Class c_ModificarPlato
                    Private xcodigo As String
                    Private xnombre_plato As String
                    Private xnombre_boton As String
                    Private xgrupo As Grupo_FastFood.c_Registro
                    Private xtasa As FichaGlobal.c_TasasFiscales.Tasas
                    Private xestatus As TipoEstatus
                    Private xfecha As Date
                    Private xplato_origen As c_Registro
                    Private xprecio_1 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xcosto As Decimal

                    Property _CodigoPlato() As String
                        Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As String)
                            xcodigo = value
                        End Set
                    End Property

                    Property _NombrePlato() As String
                        Get
                            Return xnombre_plato
                        End Get
                        Set(ByVal value As String)
                            xnombre_plato = value
                        End Set
                    End Property

                    Property _NombreBoton() As String
                        Get
                            Return xnombre_boton
                        End Get
                        Set(ByVal value As String)
                            xnombre_boton = value
                        End Set
                    End Property

                    Property _FichaGrupo() As Grupo_FastFood.c_Registro
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As Grupo_FastFood.c_Registro)
                            xgrupo = value
                        End Set
                    End Property

                    Property _TasaFiscal() As FichaGlobal.c_TasasFiscales.Tasas
                        Get
                            Return xtasa
                        End Get
                        Set(ByVal value As FichaGlobal.c_TasasFiscales.Tasas)
                            xtasa = value
                        End Set
                    End Property

                    Property _FechaActualizacion() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Property _PrecioNeto_1() As Decimal
                        Get
                            Return xprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_1 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio_1() As Decimal
                        Get
                            Return xutilidad_1
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidad_1 = value
                        End Set
                    End Property


                    Property _CostoPlato() As Decimal
                        Get
                            Return xcosto
                        End Get
                        Set(ByVal value As Decimal)
                            xcosto = value
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

                    Property _FichaPlatoOrigen() As c_Registro
                        Get
                            Return xplato_origen
                        End Get
                        Set(ByVal value As c_Registro)
                            xplato_origen = value
                        End Set
                    End Property
                End Class

                Class c_ActualizarPrecios
                    Private xplato As c_Registro
                    Private xprecio_1 As Decimal
                    Private xprecio_2 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xutilidad_2 As Decimal
                    Private xfecha As Date

                    Property _FichaPlatoOrigen() As c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _PrecioNeto_1() As Decimal
                        Get
                            Return xprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_1 = value
                        End Set
                    End Property

                    Property _PrecioNeto_2() As Decimal
                        Get
                            Return xprecio_2
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_2 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio_1() As Decimal
                        Get
                            Return xutilidad_1
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidad_1 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio_2() As Decimal
                        Get
                            Return xutilidad_2
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidad_2 = value
                        End Set
                    End Property

                    Property _FechaActualizacion() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property
                End Class

                Class c_ActualizarPrecioOferta
                    Private xplato As c_Registro
                    Private xprecio As Decimal
                    Private xinicio As Date
                    Private xfin As Date
                    Private xutilidad As Decimal
                    Private xfecha As Date

                    Property _FichaPlatoOrigen() As c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _PrecioOferta() As Decimal
                        Get
                            Return xprecio
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio = value
                        End Set
                    End Property

                    Property _UtilidadPrecioOferta() As Decimal
                        Get
                            Return xutilidad
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidad = value
                        End Set
                    End Property

                    Property _FechaInicio() As Date
                        Get
                            Return xinicio
                        End Get
                        Set(ByVal value As Date)
                            xinicio = value
                        End Set
                    End Property

                    Property _FechaCulminacion() As Date
                        Get
                            Return xfin
                        End Get
                        Set(ByVal value As Date)
                            xfin = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property
                End Class

                Class c_ActualizarCosto
                    Private xplato As c_Registro
                    Private xcosto As Decimal
                    Private xfecha As Date

                    Property _FichaPlatoOrigen() As c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _CostoPlato() As Decimal
                        Get
                            Return xcosto
                        End Get
                        Set(ByVal value As Decimal)
                            xcosto = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaBalanza
                    Private xplato As c_Registro
                    Private xplu As String
                    Private xtipo As TipoProductoBalanza
                    Private xest As TipoEstatus
                    Private xfecha As Date

                    Property _FichaPlato() As c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _CodigoPLU() As String
                        Get
                            Return xplu
                        End Get
                        Set(ByVal value As String)
                            xplu = value
                        End Set
                    End Property

                    Property _EstatusBalanza() As TipoEstatus
                        Get
                            Return xest
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xest = value
                        End Set
                    End Property

                    Property _TipoPlatoBalanza() As TipoProductoBalanza
                        Get
                            Return xtipo
                        End Get
                        Set(ByVal value As TipoProductoBalanza)
                            xtipo = value
                        End Set
                    End Property

                    Property _FechaProceso() As Date
                        Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property
                End Class

                Dim xtipo_busqueda As String() = {"Por Código", "Por Descripción", "Por PLU"}
                Property _TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                    Set(ByVal value As String())
                        xtipo_busqueda = value
                    End Set
                End Property

                Private xregistro As c_Registro

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
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

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.M_LimpiarRegistro()
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from menuplatos_fastfood where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("MENU-PLATOS" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

#Region "FUNCIONES SQL"
                Protected Friend Const INSERT_PLATO As String = "INSERT INTO menuplatos_fastfood (" _
                    + "auto" _
                    + ",auto_grupo" _
                    + ",nombre_plato" _
                    + ",nombre_boton" _
                    + ",codigo" _
                    + ",precio_1" _
                    + ",precio_2" _
                    + ",impuesto" _
                    + ",tasa" _
                    + ",pesado_unidad" _
                    + ",comentarios" _
                    + ",estatus" _
                    + ",escombo" _
                    + ",esoferta" _
                    + ",fecha_inicio" _
                    + ",fecha_final" _
                    + ",precio_oferta" _
                    + ",fecha_alta" _
                    + ",fecha_ult_actualizacion" _
                    + ",estatus_balanza" _
                    + ",costo_plato" _
                    + ",utilidad_1" _
                    + ",utilidad_2" _
                    + ",utilidad_oferta" _
                    + ",PLU) " _
                    + "VALUES(" _
                    + "@auto" _
                    + ",@auto_grupo" _
                    + ",@nombre_plato" _
                    + ",@nombre_boton" _
                    + ",@codigo" _
                    + ",@precio_1" _
                    + ",@precio_2" _
                    + ",@impuesto" _
                    + ",@tasa" _
                    + ",@pesado_unidad" _
                    + ",@comentarios" _
                    + ",@estatus" _
                    + ",@escombo" _
                    + ",@esoferta" _
                    + ",@fecha_inicio" _
                    + ",@fecha_final" _
                    + ",@precio_oferta" _
                    + ",@fecha_alta" _
                    + ",@fecha_ult_actualizacion" _
                    + ",@estatus_balanza" _
                    + ",@costo_plato" _
                    + ",@utilidad_1" _
                    + ",@utilidad_2" _
                    + ",@utilidad_oferta" _
                    + ",@PLU)"

                Protected Friend Const UPDATE_PLATO As String = "UPDATE menuplatos_fastfood SET " _
                    + "auto_grupo=@auto_grupo" _
                    + ",nombre_plato=@nombre_plato" _
                    + ",nombre_boton=@nombre_boton" _
                    + ",codigo=@codigo" _
                    + ",impuesto=@impuesto" _
                    + ",tasa=@tasa" _
                    + ",comentarios=@comentarios" _
                    + ",estatus=@estatus" _
                    + ",fecha_ult_actualizacion=@fecha_ult_actualizacion" _
                    + ",precio_1=@precio_1" _
                    + ",utilidad_1=@utilidad_1" _
                    + ",costo_plato=@costo_plato " _
                    + "WHERE auto=@auto and id_seguridad=@id"

#End Region

                Function F_AgregarPlato(ByVal xgrabar As c_AgregarPlato) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xsql_1 As String = "update contadores set a_menuplato_fastfood=a_menuplato_fastfood+1;select a_menuplato_fastfood from contadores"

                        Dim xplato As New c_Registro

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'CONTADOR PLATO
                                    xcmd.CommandText = "select a_menuplato_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_menuplato_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If

                                    xcmd.CommandText = xsql_1
                                    xplato.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    With xplato
                                        .c_AutoGrupo.c_Texto = xgrabar._FichaGrupo.c_Automatico.c_Texto
                                        .c_CodigoPlato.c_Texto = xgrabar._CodigoPlato
                                        .c_Comentarios.c_Texto = ""
                                        .c_EsCombo.c_Texto = "0"
                                        .c_EsOferta.c_Texto = "0"
                                        .c_Estatus.c_Texto = xgrabar._Estatus
                                        .c_FechaAlta.c_Valor = xgrabar._FechaRegistro
                                        .c_FechaFinal.c_Valor = xgrabar._FechaRegistro
                                        .c_FechaInicio.c_Valor = xgrabar._FechaRegistro
                                        .c_NombreBoton.c_Texto = xgrabar._NombreBoton
                                        .c_NombrePlato.c_Texto = xgrabar._NombrePlato
                                        .c_PesadoUnidad.c_Texto = ""
                                        .c_TasaImpuesto.c_Valor = xgrabar._TasaFiscal._TasaValor
                                        .c_TipoImpuesto.c_Texto = xgrabar._TasaFiscal._TasaTipo
                                        .c_FechaUltActualizacion.c_Valor = xgrabar._FechaRegistro
                                        .c_Precio_1.c_Valor = xgrabar._PrecioNeto_1
                                        .c_Utilidad1.c_Valor = xgrabar._UtilidadPrecio_1
                                        .c_CostoPlato.c_Valor = xgrabar._CostoPlato
                                    End With

                                    'MENUPLATOS
                                    xcmd.CommandText = INSERT_PLATO
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xplato.c_Automatico.c_Texto).Size = xplato.c_Automatico.c_Largo
                                        .AddWithValue("@auto_grupo", xplato.c_AutoGrupo.c_Texto).Size = xplato.c_AutoGrupo.c_Largo
                                        .AddWithValue("@nombre_plato", xplato.c_NombrePlato.c_Texto).Size = xplato.c_NombrePlato.c_Largo
                                        .AddWithValue("@nombre_boton", xplato.c_NombreBoton.c_Texto).Size = xplato.c_NombreBoton.c_Largo
                                        .AddWithValue("@codigo", xplato.c_CodigoPlato.c_Texto).Size = xplato.c_CodigoPlato.c_Largo
                                        .AddWithValue("@precio_1", xplato.c_Precio_1.c_Valor)
                                        .AddWithValue("@precio_2", xplato.c_Precio_2.c_Valor)
                                        .AddWithValue("@impuesto", xplato.c_TipoImpuesto.c_Texto).Size = xplato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@tasa", xplato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@pesado_unidad", xplato.c_PesadoUnidad.c_Texto).Size = xplato.c_PesadoUnidad.c_Largo
                                        .AddWithValue("@comentarios", xplato.c_Comentarios.c_Texto).Size = xplato.c_Comentarios.c_Largo
                                        .AddWithValue("@estatus", xplato.c_Estatus.c_Texto).Size = xplato.c_Estatus.c_Largo
                                        .AddWithValue("@escombo", xplato.c_EsCombo.c_Texto).Size = xplato.c_EsCombo.c_Largo
                                        .AddWithValue("@esoferta", xplato.c_EsOferta.c_Texto).Size = xplato.c_EsOferta.c_Largo
                                        .AddWithValue("@fecha_inicio", xplato.c_FechaInicio.c_Valor)
                                        .AddWithValue("@fecha_final", xplato.c_FechaFinal.c_Valor)
                                        .AddWithValue("@precio_oferta", xplato.c_PrecioOferta.c_Valor)
                                        .AddWithValue("@fecha_alta", xplato.c_FechaAlta.c_Valor)
                                        .AddWithValue("@fecha_ult_actualizacion", xplato.c_FechaUltActualizacion.c_Valor)
                                        .AddWithValue("@estatus_balanza", xplato.c_EstatusBalanza.c_Texto).Size = xplato.c_EstatusBalanza.c_Largo
                                        .AddWithValue("@costo_plato", xplato.c_CostoPlato.c_Valor)
                                        .AddWithValue("@utilidad_1", xplato.c_Utilidad1.c_Valor)
                                        .AddWithValue("@utilidad_2", xplato.c_Utilidad2.c_Valor)
                                        .AddWithValue("@utilidad_oferta", xplato.c_UtilidadOferta.c_Valor)
                                        .AddWithValue("@PLU", xplato.c_CodigoPLU.c_Texto).Size = xplato.c_CodigoPLU.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                End Using
                                xtr.Commit()
                                RaiseEvent PlatoRegistrado(xplato.c_Automatico.c_Texto)
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                If EXSQL.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE PLATO / NOMBRE BOTÓN YA EXISTENTE")
                                Else
                                    Throw New Exception(EXSQL.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "AGREGAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarPlato(ByVal xgrabar As c_ModificarPlato) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Dim xplato As New c_Registro

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    With xplato
                                        .c_Automatico.c_Texto = xgrabar._FichaPlatoOrigen.c_Automatico.c_Texto
                                        .c_AutoGrupo.c_Texto = xgrabar._FichaGrupo.c_Automatico.c_Texto
                                        .c_CodigoPlato.c_Texto = xgrabar._CodigoPlato
                                        .c_Comentarios.c_Texto = ""
                                        .c_Estatus.c_Texto = IIf(xgrabar._Estatus = TipoEstatus.Activo, "0", "1")
                                        .c_NombreBoton.c_Texto = xgrabar._NombreBoton
                                        .c_NombrePlato.c_Texto = xgrabar._NombrePlato
                                        .c_TasaImpuesto.c_Valor = xgrabar._TasaFiscal._TasaValor
                                        .c_TipoImpuesto.c_Texto = xgrabar._TasaFiscal._TasaTipo
                                        .c_FechaUltActualizacion.c_Valor = xgrabar._FechaActualizacion
                                        .c_IdSeguridad = xgrabar._FichaPlatoOrigen.c_IdSeguridad
                                        .c_Precio_1.c_Valor = xgrabar._PrecioNeto_1
                                        .c_Utilidad1.c_Valor = xgrabar._UtilidadPrecio_1
                                        .c_CostoPlato.c_Valor = xgrabar._CostoPlato
                                    End With

                                    Dim xr As Integer = 0
                                    'MENUPLATOS
                                    xcmd.CommandText = UPDATE_PLATO
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xplato.c_Automatico.c_Texto).Size = xplato.c_Automatico.c_Largo
                                        .AddWithValue("@auto_grupo", xplato.c_AutoGrupo.c_Texto).Size = xplato.c_AutoGrupo.c_Largo
                                        .AddWithValue("@nombre_plato", xplato.c_NombrePlato.c_Texto).Size = xplato.c_NombrePlato.c_Largo
                                        .AddWithValue("@nombre_boton", xplato.c_NombreBoton.c_Texto).Size = xplato.c_NombreBoton.c_Largo
                                        .AddWithValue("@codigo", xplato.c_CodigoPlato.c_Texto).Size = xplato.c_CodigoPlato.c_Largo
                                        .AddWithValue("@impuesto", xplato.c_TipoImpuesto.c_Texto).Size = xplato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@tasa", xplato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@comentarios", xplato.c_Comentarios.c_Texto).Size = xplato.c_Comentarios.c_Largo
                                        .AddWithValue("@estatus", xplato.c_Estatus.c_Texto).Size = xplato.c_Estatus.c_Largo
                                        .AddWithValue("@fecha_ult_actualizacion", xplato.c_FechaUltActualizacion.c_Valor)
                                        .AddWithValue("@precio_1", xplato.c_Precio_1.c_Valor)
                                        .AddWithValue("@utilidad_1", xplato.c_Utilidad1.c_Valor)
                                        .AddWithValue("@costo_plato", xplato.c_CostoPlato.c_Valor)
                                        .AddWithValue("@id", xplato.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE ACTUALIZADO POR OTRO USUARIO")
                                    End If

                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                If EXSQL.Number = 2601 Then
                                    Throw New Exception("ERROR... NOMBRE PLATO / NOMBRE BOTÓN YA EXISTENTE")
                                Else
                                    Throw New Exception(EXSQL.Number)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "MODIFICAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarPlato(ByVal xgrabar As c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xsql As String = "Delete menuplatos_fastfood where auto=@auto and id_seguridad=@id"

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    Dim xr As Integer = 0
                                    'MENUPLATOS
                                    xcmd.CommandText = xsql
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xgrabar.c_Automatico.c_Texto).Size = xgrabar.c_Automatico.c_Largo
                                        .AddWithValue("@id", xgrabar.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE ACTUALIZADO POR OTRO USUARIO")
                                    End If

                                End Using
                                xtr.Commit()
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                If EXSQL.Number = 547 Then
                                    Throw New Exception("ERROR... EL PLATO COMBO NO PUEDE SER ELIMINADO, POSEE PLATOS RELACIONADOS")
                                Else
                                    Throw New Exception(EXSQL.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "ELIMINAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarPrecios(ByVal xgrabar As c_ActualizarPrecios) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xsql As String = "UPDATE menuplatos_fastfood SET precio_1=@precio_1, precio_2=@precio_2, " _
                                            + "utilidad_1=@utilidad_1,utilidad_2=@utilidad_2, " _
                                            + "fecha_ult_actualizacion=@fecha where auto=@auto and id_seguridad=@id"

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    Dim xr As Integer = 0
                                    xcmd.CommandText = xsql
                                    With xcmd.Parameters
                                        .Clear()
                                        .AddWithValue("@auto", xgrabar._FichaPlatoOrigen._Automatico).Size = xgrabar._FichaPlatoOrigen.c_Automatico.c_Largo
                                        .AddWithValue("@id", xgrabar._FichaPlatoOrigen.c_IdSeguridad)
                                        .AddWithValue("@precio_1", xgrabar._PrecioNeto_1)
                                        .AddWithValue("@precio_2", xgrabar._PrecioNeto_2)
                                        .AddWithValue("@utilidad_1", xgrabar._UtilidadPrecio_1)
                                        .AddWithValue("@utilidad_2", xgrabar._UtilidadPrecio_2)
                                        .AddWithValue("@fecha", xgrabar._FechaActualizacion)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                Throw New Exception(EXSQL.Number)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "ACTUALIZAR PRECIOS" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarPrecioOferta(ByVal xgrabar As c_ActualizarPrecioOferta) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xsql As String = "UPDATE menuplatos_fastfood SET precio_oferta=@precio_oferta,utilidad_oferta=@utilidad_oferta, esoferta='1', " _
                                            + "fecha_inicio=@fecha_inicio, fecha_final=@fecha_final, fecha_ult_actualizacion=@fecha_ult_actualizacion " _
                                            + "where auto=@auto and id_seguridad=@id"

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    Dim xr As Integer = 0
                                    xcmd.CommandText = xsql
                                    With xcmd.Parameters
                                        .Clear()
                                        .AddWithValue("@auto", xgrabar._FichaPlatoOrigen._Automatico).Size = xgrabar._FichaPlatoOrigen.c_Automatico.c_Largo
                                        .AddWithValue("@id", xgrabar._FichaPlatoOrigen.c_IdSeguridad)
                                        .AddWithValue("@precio_oferta", xgrabar._PrecioOferta)
                                        .AddWithValue("@utilidad_oferta", xgrabar._UtilidadPrecioOferta)
                                        .AddWithValue("@fecha_inicio", xgrabar._FechaInicio)
                                        .AddWithValue("@fecha_final", xgrabar._FechaCulminacion)
                                        .AddWithValue("@fecha_ult_actualizacion", xgrabar._FechaProceso)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                Throw New Exception(EXSQL.Number)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "ACTUALIZAR PRECIO OFERTA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_DesactivarPrecioOferta(ByVal xplato As c_Registro) As Boolean
                    Try
                        Dim xr As Integer = 0
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)

                                    xr = 0
                                    xcmd.CommandText = "update menuplatos_fastfood set esoferta='0' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xplato._Automatico).Size = xplato.c_Automatico.c_Largo
                                        .AddWithValue("@id_seguridad", xplato.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL DESACTIVAR PROMOCION / OEFERTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                    End If
                                End Using
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message + "," + ex2.Number)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS" + vbCrLf + "DESACTIVAR OFERTA / PROMOCION" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarCosto(ByVal xgrabar As c_ActualizarCosto) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    Dim xr As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set costo_plato=@costo_plato, fecha_ult_actualizacion=@fecha_ult_actualizacion " _
                                                        + "where auto=@auto and id_seguridad=@id"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xgrabar._FichaPlatoOrigen._Automatico).Size = xgrabar._FichaPlatoOrigen.c_Automatico.c_Largo
                                        .AddWithValue("@id", xgrabar._FichaPlatoOrigen.c_IdSeguridad)
                                        .AddWithValue("@costo_plato", xgrabar._CostoPlato)
                                        .AddWithValue("@fecha_ult_actualizacion", xgrabar._FechaProceso)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "MODIFICAR FICHA COSTO DEL PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarFichaBalanza(ByVal xgrabar As c_ModificarFichaBalanza) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set plu=@plu,estatus_balanza=@estatus_balanza,pesado_unidad=@pesado_unidad " _
                                                    + "where auto=@auto and id_seguridad=@id_seguridad"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xgrabar._FichaPlato._Automatico).Size = xgrabar._FichaPlato.c_Automatico.c_Largo
                                        .AddWithValue("@plu", xgrabar._CodigoPLU).Size = xgrabar._FichaPlato.c_CodigoPLU.c_Largo
                                        .AddWithValue("@estatus_balanza", IIf(xgrabar._EstatusBalanza = TipoEstatus.Activo, "1", "0")).Size = xgrabar._FichaPlato.c_EstatusBalanza.c_Largo
                                        .AddWithValue("@pesado_unidad", IIf(xgrabar._TipoPlatoBalanza = TipoProductoBalanza.Pesado, "P", "U")).Size = xgrabar._FichaPlato.c_PesadoUnidad.c_Largo
                                        .AddWithValue("@id_seguridad", xgrabar._FichaPlato.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "MODIFICAR FICHA BALANZA DEL PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarFichaCombo(ByVal xplato As c_Registro, ByVal xvalor As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set escombo=@valor " _
                                                    + "where auto=@auto and id_seguridad=@id_seguridad"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xplato._Automatico).Size = xplato.c_Automatico.c_Largo
                                        .AddWithValue("@valor", xvalor).Size = xplato.c_EsCombo.c_Largo
                                        .AddWithValue("@id_seguridad", xplato.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU PLATOS:" + vbCrLf + "MODIFICAR FICHA COMBO DEL PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' Clase. USADA PARA CONTENER LOS PLATOS DEL MENU
            ''' </summary>
            Public Class MenuEstacion_FastFood
                Event PlatoEstacionProcesado()

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_auto_plato As CampoTexto
                    Private f_auto_estacion As CampoTexto
                    Private f_auto As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Auto Plato - Estacion
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Plato - Estacion
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Auto Plato
                    ''' </summary>
                    Protected Friend Property c_AutoPlato() As CampoTexto
                        Get
                            Return f_auto_plato
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_plato = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Plato
                    ''' </summary>
                    ReadOnly Property _AutoPlato() As String
                        Get
                            Return c_AutoPlato.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Auto Estacion
                    ''' </summary>
                    Protected Friend Property c_AutoEstacion() As CampoTexto
                        Get
                            Return f_auto_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_estacion = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico De La Estacion
                    ''' </summary>
                    ReadOnly Property _AutoEstacion() As String
                        Get
                            Return c_AutoEstacion.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Estatus
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Estado Del Plato - Estacion
                    ''' </summary>
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case Me.c_Estatus.c_Texto.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Id Seguridad
                    ''' </summary>
                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Id Seguridad
                    ''' </summary>
                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property


                    ReadOnly Property _FichaEstacion() As FichaMenuPlatos.Estacion_FastFood.c_Registro
                        Get
                            Dim xficha As New FichaMenuPlatos.Estacion_FastFood
                            If _AutoEstacion <> "" Then
                                xficha.F_CargarRegistro(_AutoEstacion)
                            End If
                            Return xficha.RegistroDato
                        End Get
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        With Me
                            .c_AutoPlato = New CampoTexto(10, "auto_plato")
                            .c_AutoEstacion = New CampoTexto(10, "auto_estacion")
                            .c_Automatico = New CampoTexto(10, "auto")
                            .c_Estatus = New CampoTexto(1, "estatus")

                            .M_LimpiarRegistro()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_AutoEstacion.c_Texto = xrow(.c_AutoEstacion.c_NombreInterno)
                                .c_AutoPlato.c_Texto = xrow(.c_AutoPlato.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_IdSeguridad = xrow("id_seguridad")

                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU-PLATOS" + vbCrLf + "MENU ESTACION" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarRegistro
                    Private xauto_estacion As String
                    Private xauto_plato As String
                    Private xestatus As String

                    Property _AutoEstacion() As String
                        Get
                            Return xauto_estacion
                        End Get
                        Set(ByVal value As String)
                            xauto_estacion = value
                        End Set
                    End Property

                    Property _AutoPlato() As String
                        Get
                            Return xauto_plato
                        End Get
                        Set(ByVal value As String)
                            xauto_plato = value
                        End Set
                    End Property

                    Property _Estatus() As String
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As String)
                            xestatus = value
                        End Set
                    End Property
                End Class

                Class c_ModificarRegistro
                    Private xauto_estacion As String
                    Private xestatus As String
                    Private xficha As FichaMenuPlatos.MenuEstacion_FastFood.c_Registro

                    Property _AutoEstacion() As String
                        Get
                            Return xauto_estacion
                        End Get
                        Set(ByVal value As String)
                            xauto_estacion = value
                        End Set
                    End Property

                    Property _Estatus() As String
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As String)
                            xestatus = value
                        End Set
                    End Property

                    Property _FichaOrigen() As FichaMenuPlatos.MenuEstacion_FastFood.c_Registro
                        Get
                            Return xficha
                        End Get
                        Set(ByVal value As FichaMenuPlatos.MenuEstacion_FastFood.c_Registro)
                            xficha = value
                        End Set
                    End Property
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
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

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.M_LimpiarRegistro()
                End Sub


                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from menuestaciones_fastfood where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("MENU PLATOS" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Dim InsertarPlatoEstacion As String = "insert into menuestaciones_fastfood (auto, auto_estacion, auto_plato, estatus) " _
                                            + "values(@auto,@auto_estacion,@auto_plato,@estatus)"

                Dim ActualizarPlatoEstacion As String = "update menuestaciones_fastfood set auto_estacion=@auto_estacion, " _
                                              + "estatus=@estatus where auto=@auto and id_seguridad=@id "

                Dim EliminarPlatoEstacion As String = "delete from menuestaciones_fastfood where auto=@auto and id_seguridad=@id"


                ''' <summary>
                ''' Metodo: Permite Grabar Un Menu Estacion 
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DEL MENU ESTACION A GRABAR                
                Function F_GrabarEstacion(ByVal xgrabar As FichaMenuPlatos.MenuEstacion_FastFood.c_AgregarRegistro) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_menuestacion_fastfood=a_menuestacion_fastfood+1; select a_menuestacion_fastfood from contadores"
                        Dim xauto_1 As String = ""

                        Dim xreg As New FichaMenuPlatos.MenuEstacion_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

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
                                    xauto_1 = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    With xreg
                                        .c_Automatico.c_Texto = xauto_1
                                        .c_Estatus.c_Texto = xgrabar._Estatus
                                        .c_AutoEstacion.c_Texto = xgrabar._AutoEstacion
                                        .c_AutoPlato.c_Texto = xgrabar._AutoPlato
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarPlatoEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_Automatico.c_Texto).Size = xreg.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_estacion", xreg.c_AutoEstacion.c_Texto).Size = xreg.c_AutoEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_plato", xreg.c_AutoPlato.c_Texto).Size = xreg.c_AutoPlato.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xreg.c_Estatus.c_Texto).Size = xreg.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent PlatoEstacionProcesado()
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
                        Throw New Exception("MENU PLATOS" + vbCrLf + "GRABAR MENU ESTACION FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Metodo: Permite Actualizar Un Menu Estacion 
                ''' </summary>
                ''' <param name="xgrabar"></param>
                ''' CLASE QUE CONTIENE LOS DATOS DEL MENU ESTACION A MODIFICAR              
                Function F_ActualizarEstacion(ByVal xgrabar As FichaMenuPlatos.MenuEstacion_FastFood.c_ModificarRegistro) As Boolean
                    Try
                        Dim xreg As New FichaMenuPlatos.MenuEstacion_FastFood.c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)

                                    With xreg
                                        .c_Automatico.c_Texto = xgrabar._FichaOrigen._Automatico
                                        .c_Estatus.c_Texto = xgrabar._Estatus
                                        .c_AutoEstacion.c_Texto = xgrabar._AutoEstacion
                                        .c_IdSeguridad = xgrabar._FichaOrigen._IdSeguridad
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarPlatoEstacion
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_Automatico.c_Texto).Size = xreg.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_estacion", xreg.c_AutoEstacion.c_Texto).Size = xreg.c_AutoEstacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xreg.c_Estatus.c_Texto).Size = xreg.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xreg.c_IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL PLATO - ESTACION FUE ACTUALIZADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent PlatoEstacionProcesado()
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
                        Throw New Exception("MENU PLATOS" + vbCrLf + "MODIFICAR MENU ESTACION" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Metodo: Permite Eliminar Un Plato - Estacion 
                ''' </summary>
                ''' <param name="xreg"></param>
                ''' CLASE FICHA PLATO - ESTACION
                Function F_EliminarEstacion(ByVal xreg As FichaMenuPlatos.MenuEstacion_FastFood.c_Registro) As Boolean
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
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_Automatico.c_Texto).Size = xreg.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xreg.c_IdSeguridad)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL PLATO - ESTACION FUE ACTUALIZADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent PlatoEstacionProcesado()
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
                        Throw New Exception("MENU PLATOS" + vbCrLf + "ELIMINAR MENU ESTACION FAST FOOD" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' Clase. USADA PARA CONTENER LOS PLATOS PERTENECIENTES A UN PLATO COMBO
            ''' </summary>
            Public Class MenuCombos_FastFood
                Event ActualizarFicha()

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_plato As CampoTexto
                    Private f_auto_plato_combo As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_id_seguridad As Byte()


                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Auto 
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico De Menu Combos
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Auto Plato
                    ''' </summary>
                    Protected Friend Property c_AutoPlato() As CampoTexto
                        Get
                            Return f_auto_plato
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_plato = value
                        End Set
                    End Property
                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Plato Perteneciente Al Combo
                    ''' </summary>
                    ReadOnly Property _AutoPlato() As String
                        Get
                            Return c_AutoPlato.c_Texto.Trim
                        End Get
                    End Property
                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Auto Plato Combo
                    ''' </summary>
                    Protected Friend Property c_AutoPlatoCombo() As CampoTexto
                        Get
                            Return f_auto_plato_combo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_plato_combo = value
                        End Set
                    End Property
                    ''' <summary>
                    '''  Propiedad: Retorna El Automatico Del Plato Combo
                    ''' </summary>
                    ReadOnly Property _AutoPlatoCombo() As String
                        Get
                            Return c_AutoPlatoCombo.c_Texto.Trim
                        End Get
                    End Property
                    ''' <summary>
                    '''  Propiedad: Get o Set Las Caracteristicas Del Campo Cantidad
                    ''' </summary>
                    Protected Friend Property c_CantidadPlatos() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property
                    ''' <summary>
                    '''  Propiedad: Retorna La Cantidad De Platos Para El Combo
                    ''' </summary>
                    ReadOnly Property _CantidadPlatos() As Decimal
                        Get
                            Return c_CantidadPlatos.c_Valor
                        End Get
                    End Property


                    ''' <summary>
                    '''  Propiedad: Retorna La Cantidad De Platos Para El Combo
                    ''' </summary>
                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xp1 As New SqlParameter("@auto", _AutoPlato)
                            Return F_GetString("select nombre_plato from menuplatos_fastfood where auto=@auto", xp1)
                        End Get
                    End Property


                    ''' <summary>
                    '''  Propiedad: Get o Set El Id De Seguridad Del Plato
                    ''' </summary>
                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        With Me
                            .c_Automatico = New CampoTexto(10, "auto")
                            .c_AutoPlato = New CampoTexto(10, "auto_plato")
                            .c_AutoPlatoCombo = New CampoTexto(10, "auto_plato_combo")
                            .c_CantidadPlatos = New CampoDecimal("cantidad")

                            .M_LimpiarRegistro()
                        End With
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_AutoPlato.c_Texto = xrow(.c_AutoPlato.c_NombreInterno)
                                .c_AutoPlatoCombo.c_Texto = xrow(.c_AutoPlatoCombo.c_NombreInterno)
                                .c_CantidadPlatos.c_Valor = xrow(.c_CantidadPlatos.c_NombreInterno)
                                .c_IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU PLATOS" + vbCrLf + "MENU COMBOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class c_AgregarPlatoCombo
                    Private xcombo As MenuPlatos_FastFood.c_Registro
                    Private xplato As MenuPlatos_FastFood.c_Registro
                    Private xcantidad As Decimal

                    Property _FichaCombo() As MenuPlatos_FastFood.c_Registro
                        Get
                            Return xcombo
                        End Get
                        Set(ByVal value As MenuPlatos_FastFood.c_Registro)
                            xcombo = value
                        End Set
                    End Property

                    Property _FichaPlato() As MenuPlatos_FastFood.c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As MenuPlatos_FastFood.c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _CantidadPlatos() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarPlatoCombo
                    Private xficha As c_Registro
                    Private xcombo As MenuPlatos_FastFood.c_Registro
                    Private xplato As MenuPlatos_FastFood.c_Registro
                    Private xcantidad As Decimal

                    Property _FichaOrigen() As c_Registro
                        Get
                            Return xficha
                        End Get
                        Set(ByVal value As c_Registro)
                            xficha = value
                        End Set
                    End Property

                    Property _FichaCombo() As MenuPlatos_FastFood.c_Registro
                        Get
                            Return xcombo
                        End Get
                        Set(ByVal value As MenuPlatos_FastFood.c_Registro)
                            xcombo = value
                        End Set
                    End Property

                    Property _FichaPlato() As MenuPlatos_FastFood.c_Registro
                        Get
                            Return xplato
                        End Get
                        Set(ByVal value As MenuPlatos_FastFood.c_Registro)
                            xplato = value
                        End Set
                    End Property

                    Property _CantidadPlatos() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                '''  Clase Registro De Dato
                ''' </summary>
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

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.M_LimpiarRegistro()
                End Sub


                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from menucombos_fastfood where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("MENU COMBOS" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_AgregarPlatoCombo(ByVal xgrabar As c_AgregarPlatoCombo) As Boolean
                    Try
                        Dim xcombo As New c_Registro

                        Dim xsql As String = "update contadores set a_menucombo_fastfood=a_menucombo_fastfood+1;select a_menucombo_fastfood from contadores"
                        Dim xauto As String = ""

                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    xcmd.CommandText = "select a_menucombo_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_menucombo_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If

                                    xcmd.CommandText = xsql
                                    xauto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    With xcombo
                                        .c_Automatico.c_Texto = xauto
                                        .c_AutoPlato.c_Texto = xgrabar._FichaPlato._Automatico
                                        .c_AutoPlatoCombo.c_Texto = xgrabar._FichaCombo._Automatico
                                        .c_CantidadPlatos.c_Valor = xgrabar._CantidadPlatos
                                    End With

                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select count(*) from menucombos_fastfood where auto_plato=@auto_plato "
                                    With xcmd.Parameters
                                        .AddWithValue("@auto_plato", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                    End With
                                    xr = xcmd.ExecuteScalar
                                    If xr > 0 Then
                                        Throw New Exception("Error... Plato Pertenece A Un Combo No Puede Ser Un Plato Combo")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "insert into menucombos_fastfood (auto,auto_plato,auto_plato_combo,cantidad) values(@auto,@auto_plato,@auto_plato_combo,@cantidad) "
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xcombo._Automatico).Size = xcombo.c_Automatico.c_Largo
                                        .AddWithValue("@auto_plato", xcombo._AutoPlato).Size = xcombo.c_AutoPlato.c_Largo
                                        .AddWithValue("@auto_plato_combo", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                        .AddWithValue("@cantidad", xcombo._CantidadPlatos)
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set escombo='1' where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                    xcmd.ExecuteNonQuery()

                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU COMBOS:" + vbCrLf + "AGREGAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarPlatoCombo(ByVal xgrabar As c_ModificarPlatoCombo) As Boolean
                    Try
                        Dim xcombo As New c_Registro

                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0

                                    With xcombo
                                        .c_Automatico.c_Texto = xgrabar._FichaOrigen.c_Automatico.c_Texto
                                        .c_AutoPlato.c_Texto = xgrabar._FichaPlato._Automatico
                                        .c_AutoPlatoCombo.c_Texto = xgrabar._FichaCombo._Automatico
                                        .c_CantidadPlatos.c_Valor = xgrabar._CantidadPlatos
                                        .c_IdSeguridad = xgrabar._FichaOrigen.c_IdSeguridad
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menucombos_fastfood set auto_plato=@auto_plato, auto_plato_combo=@auto_plato_combo, cantidad=@cantidad where auto=@auto and id_seguridad=@id"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xcombo._Automatico).Size = xcombo.c_Automatico.c_Largo
                                        .AddWithValue("@auto_plato", xcombo._AutoPlato).Size = xcombo.c_AutoPlato.c_Largo
                                        .AddWithValue("@auto_plato_combo", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                        .AddWithValue("@cantidad", xcombo._CantidadPlatos)
                                        .AddWithValue("@id", xcombo.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... EL REGISTRO FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU COMBOS:" + vbCrLf + "MODIFICAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarPlatoCombo(ByVal xcombo As c_Registro) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete menucombos_fastfood where auto=@auto and id_seguridad=@id"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xcombo._Automatico).Size = xcombo.c_Automatico.c_Largo
                                        .AddWithValue("@id", xcombo.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()

                                    If xr = 0 Then
                                        Throw New Exception("ERROR... EL REGISTRO FUE MODIFICADO POR OTRO USUARIO")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select count(*) from menucombos_fastfood where auto_plato_combo=@auto_plato_combo"
                                    xcmd.Parameters.AddWithValue("@auto_plato_combo", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                    xr = xcmd.ExecuteScalar

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set escombo=@escombo where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo.c_Largo
                                    xcmd.Parameters.AddWithValue("@escombo", IIf(xr > 0, "1", "0"))
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MENU COMBOS:" + vbCrLf + "ELIMINAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class


            Private xgrupo As Grupo_FastFood
            Private xmenuplato As MenuPlatos_FastFood
            Private xmenuestacion As MenuEstacion_FastFood

            Property f_Grupo() As Grupo_FastFood
                Get
                    Return xgrupo
                End Get
                Set(ByVal value As Grupo_FastFood)
                    xgrupo = value
                End Set
            End Property

            Property f_MenuPlato() As MenuPlatos_FastFood
                Get
                    Return xmenuplato
                End Get
                Set(ByVal value As MenuPlatos_FastFood)
                    xmenuplato = value
                End Set
            End Property

            Property f_MenuEstacion() As MenuEstacion_FastFood
                Get
                    Return xmenuestacion
                End Get
                Set(ByVal value As MenuEstacion_FastFood)
                    xmenuestacion = value
                End Set
            End Property

            Sub New()
                f_Grupo = New Grupo_FastFood
                f_MenuPlato = New MenuPlatos_FastFood
                f_MenuEstacion = New MenuEstacion_FastFood
            End Sub
        End Class
    End Class

End Namespace

Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FastFood

            Public Enum TipoPrecioFastFood As Integer
                Precio_1 = 1
                Precio_2 = 2
                Precio_Oferta = 3
            End Enum

            Shared Function FechaSistema() As Date
                Return F_GetDate("select getdate()").Date
            End Function

            ''' <summary>
            ''' DEFINE LA CLASE PARA LOS GRUPOS A LA CUAL PERTENECE EL PLATO
            ''' </summary>
            Public Class GrupoFastFood
                Event _ActualizarTabla()

                Class Eliminar
                    Private xauto As String
                    Private xid As Byte()

                    Property _AutoGrupo() As String
                        Get
                            Return xauto
                        End Get
                        Set(ByVal value As String)
                            xauto = value
                        End Set
                    End Property

                    Property _Id() As Byte()
                        Get
                            Return xid
                        End Get
                        Set(ByVal value As Byte())
                            xid = value
                        End Set
                    End Property

                    Sub New()
                        _AutoGrupo = ""
                    End Sub
                End Class
                Class Modificar
                    Inherits Eliminar

                    Private xnombre As String
                    Private xboton As String
                    Private xestatus As TipoEstatus

                    Property _Nombre() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _Boton() As String
                        Get
                            Return xboton
                        End Get
                        Set(ByVal value As String)
                            xboton = value
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
                        MyBase.New()
                        _Boton = ""
                        _Nombre = ""
                        _Estatus = 0
                    End Sub
                End Class
                Class Agregar
                    Private xnombre As String
                    Private xboton As String
                    Private xestatus As TipoEstatus

                    Property _Nombre() As String
                        Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _Boton() As String
                        Get
                            Return xboton
                        End Get
                        Set(ByVal value As String)
                            xboton = value
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
                        _Boton = ""
                        _Nombre = ""
                        _Estatus = 0
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_nombre_grupo As CampoDato
                    Private f_nombre_boton As CampoDato
                    Private f_estatus As CampoDato
                    Private f_id_seguridad As Byte()
                    Private f_estatus_imagen As CampoDato

                    Property c_Automatico() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_Automatico._RetornarValor(Of String)() Is Nothing, "", Me.c_Automatico._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreGrupo() As CampoDato
                        Get
                            Return f_nombre_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreGrupo._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreGrupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_NombreBoton() As CampoDato
                        Get
                            Return f_nombre_boton
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_boton = value
                        End Set
                    End Property

                    ReadOnly Property _Boton() As String
                        Get
                            Dim xv As String = IIf(Me.c_NombreBoton._RetornarValor(Of String)() Is Nothing, "", Me.c_NombreBoton._RetornarValor(Of String)())
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

                    ReadOnly Property _EstatusGrupo() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.c_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.c_Estatus._RetornarValor(Of String)())
                            If xv.Trim = "1" Then
                                Return TipoEstatus.Inactivo
                            ElseIf xv.Trim = "0" Then
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property

                    Protected Friend Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Id() As Byte()
                        Get
                            Return Me._IdSeguridad
                        End Get
                    End Property

                    Property c_EstatusImagen() As CampoDato
                        Get
                            Return f_estatus_imagen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus_imagen = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusImagen() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.c_EstatusImagen._RetornarValor(Of String)() Is Nothing, "", Me.c_EstatusImagen._RetornarValor(Of String)())
                            If xv.Trim = "1" Then
                                Return TipoEstatus.Activo
                            ElseIf xv.Trim = "0" Then
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "PROBLEMA AL INICIALIZAR CLASE GRUPO - FASTFOOD" + vbCrLf + ex.Message
                            Throw New Exception(x)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoDato("auto", 10)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_NombreBoton = New CampoDato("nombre_boton", 30)
                        Me.c_NombreGrupo = New CampoDato("nombre_grupo", 60)
                        Me.c_EstatusImagen = New CampoDato("estatus_imagen", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Automatico._ContenidoCampo = xrow(.c_Automatico._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_NombreBoton._ContenidoCampo = xrow(.c_NombreBoton._NombreCampo)
                                .c_NombreGrupo._ContenidoCampo = xrow(.c_NombreGrupo._NombreCampo)
                                ._IdSeguridad = xrow("id_seguridad")
                                If Not IsDBNull(xrow(.c_EstatusImagen._NombreCampo)) Then
                                    .c_EstatusImagen._ContenidoCampo = xrow(.c_EstatusImagen._NombreCampo)
                                End If
                                ._IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("PROBLEMA AL CARGAR REGISTRO GRUPO FASTFOOD:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const EliminarGrp As String = "delete grupo_fastfood where auto=@auto and id_seguridad=@id"
                Protected Friend Const ActualizarGrp As String = "update grupo_fastfood set nombre_grupo=@nombre_grupo, " _
                                                              + "nombre_boton=@nombre_boton, estatus=@estatus where auto=@auto and id_seguridad=@id "
                Protected Friend InsertarGrp As String = "insert into grupo_fastfood (auto, nombre_grupo, nombre_boton, estatus, estatus_imagen) " _
                                            + "values(@auto,@nombre_grupo,@nombre_boton,@estatus,@estatus_imagen)"

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


                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        With Me.RegistroDato
                            .CargarRegistro(xrow)
                        End With
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub


                Sub M_LimpiarFicha()
                    Me.RegistroDato.M_Limpiar()
                End Sub


                Function F_EliminarGrupo(ByVal xgrupo As Eliminar) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()
                            xtr = xconn.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarGrp
                                    xcmd.Parameters.AddWithValue("@auto", xgrupo._AutoGrupo)
                                    xcmd.Parameters.AddWithValue("@id", xgrupo._Id)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL GRUPO FUE ACTUALIZADO / ELIMINADO POR OTRO USUARIO , POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
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
                        Throw New Exception(ex.Message)
                    End Try
                End Function


                Function F_ActualizarGrupo(ByVal xgrupo As Modificar) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing
                        Dim xgrp As New c_Registro

                        With xgrp
                            .c_Automatico._ContenidoCampo = xgrupo._AutoGrupo
                            .c_Estatus._ContenidoCampo = IIf(xgrupo._Estatus = TipoEstatus.Activo, "0", "1")
                            .c_NombreBoton._ContenidoCampo = xgrupo._Boton
                            .c_NombreGrupo._ContenidoCampo = xgrupo._Nombre
                            ._IdSeguridad = xgrupo._Id
                        End With

                        Using xconn As New SqlConnection(_MiCadenaConexion)
                            xconn.Open()

                            xtr = xconn.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xconn, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ActualizarGrp
                                    xcmd.Parameters.AddWithValue("@" + xgrp.c_Automatico._NombreCampo, xgrp._AutoGrupo).Size = xgrp.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrp.c_NombreGrupo._NombreCampo, xgrp._NombreGrupo).Size = xgrp.c_NombreGrupo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrp.c_NombreBoton._NombreCampo, xgrp._Boton).Size = xgrp.c_NombreBoton._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrp.c_Estatus._NombreCampo, xgrp.c_Estatus._ContenidoCampo).Size = xgrp.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@id", xgrp._Id)
                                    xobj = xcmd.ExecuteNonQuery()

                                    If xobj = 0 Then
                                        Throw New Exception("ERROR... EL GRUPO FUE ACTUALIZADO / ELIMINADO POR OTRO USUARIO, POR FAVOR VERIFIQUE")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
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
                        Throw New Exception("MODIFICAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_AgregarGrupo(ByVal xgrp As Agregar) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_grupo_fastfood=a_grupo_fastfood+1; select a_grupo_fastfood from contadores"
                        Dim xgrupo As New c_Registro
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        With xgrupo
                            .c_Automatico._ContenidoCampo = ""
                            .c_Estatus._ContenidoCampo = IIf(xgrp._Estatus = TipoEstatus.Activo, "0", "1")
                            .c_NombreBoton._ContenidoCampo = xgrp._Boton
                            .c_NombreGrupo._ContenidoCampo = xgrp._Nombre
                            .c_EstatusImagen._ContenidoCampo = "0"
                        End With

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
                                    xgrupo.c_Automatico._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = InsertarGrp
                                    xcmd.Parameters.AddWithValue("@" + xgrupo.c_Automatico._NombreCampo, xgrupo._AutoGrupo).Size = xgrupo.c_Automatico._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrupo.c_NombreGrupo._NombreCampo, xgrupo._NombreGrupo).Size = xgrupo.c_NombreGrupo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrupo.c_NombreBoton._NombreCampo, xgrupo._Boton).Size = xgrupo.c_NombreBoton._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrupo.c_Estatus._NombreCampo, xgrupo.c_Estatus._ContenidoCampo).Size = xgrupo.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xgrupo.c_EstatusImagen._NombreCampo, xgrupo.c_EstatusImagen._ContenidoCampo).Size = xgrupo.c_EstatusImagen._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarTabla()
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
                        Throw New Exception("GRABAR GRUPO FASTFOOD" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EstatusImagen(ByVal xgrupo As GrupoFastFood.c_Registro, ByVal xestatus_img As Boolean) As Boolean
                    Try
                        Dim xestatus As String = "0"
                        If xestatus_img Then
                            xestatus = "1"
                        End If

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            Dim rt As Integer = 0
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "Update grupo_fastfood set estatus_imagen=@estatus where auto=@auto and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@auto", xgrupo._AutoGrupo)
                                xcmd.Parameters.AddWithValue("@id", xgrupo._IdSeguridad)
                                xcmd.Parameters.AddWithValue("@estatus", xestatus)
                                rt = xcmd.ExecuteNonQuery()
                            End Using
                            If rt = 0 Then
                                Throw New Exception("GRUPO NO ENCONTRADO / ACTUALIZADO POR OTRO USUARIO")
                            End If

                            Return True
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

            End Class

            ''' <summary>
            ''' DEFINE LA CLASE PLATOS DEL MENU
            ''' </summary>
            Public Class Platos
                Event _PlatoRegistrado(ByVal xauto As String)
                Event _PlatoActualizado(ByVal xauto As String)

                Class Agregar
                    Private xcodigo As String
                    Private xnombre_plato As String
                    Private xnombre_boton As String
                    Private xgrupo As GrupoFastFood.c_Registro
                    Private xtasa As FichaGlobal.c_TasasFiscales.Tasas
                    Private xprecio_1 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xcosto As Decimal
                    Private xcomentarios As String

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

                    Property _FichaGrupo() As GrupoFastFood.c_Registro
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As GrupoFastFood.c_Registro)
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

                    ReadOnly Property _FechaRegistro() As Date
                        Get
                            Return FechaSistema()
                        End Get
                    End Property

                    Property _PrecioNeto() As Decimal
                        Get
                            Return xprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_1 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio() As Decimal
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

                    Property _Comentarios() As String
                        Get
                            Return xcomentarios
                        End Get
                        Set(ByVal value As String)
                            xcomentarios = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Sub New()
                        Me._CodigoPlato = ""
                        Me._CostoPlato = 0
                        Me._FichaGrupo = Nothing
                        Me._NombreBoton = ""
                        Me._NombrePlato = ""
                        Me._PrecioNeto = 0
                        Me._TasaFiscal = Nothing
                        Me._UtilidadPrecio = 0
                        Me._Comentarios = ""
                    End Sub
                End Class
                Class Eliminar
                    Private xauto As String
                    Private xid As Byte()

                    Property _AutoPlato() As String
                        Get
                            Return xauto
                        End Get
                        Set(ByVal value As String)
                            xauto = value
                        End Set
                    End Property

                    Property _Id() As Byte()
                        Get
                            Return xid
                        End Get
                        Set(ByVal value As Byte())
                            xid = value
                        End Set
                    End Property

                    Sub New()
                        _AutoPlato = ""
                    End Sub
                End Class
                Class Modificar
                    Private xcodigo As String
                    Private xnombre_plato As String
                    Private xnombre_boton As String
                    Private xgrupo As GrupoFastFood.c_Registro
                    Private xtasa As FichaGlobal.c_TasasFiscales.Tasas
                    Private xprecio_1 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xcosto As Decimal
                    Private xestatus As TipoEstatus
                    Private xficha As c_Registro
                    Private xcomentarios As String

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

                    Property _FichaGrupo() As GrupoFastFood.c_Registro
                        Get
                            Return xgrupo
                        End Get
                        Set(ByVal value As GrupoFastFood.c_Registro)
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

                    ReadOnly Property _FechaRegistro() As Date
                        Get
                            Return FechaSistema()
                        End Get
                    End Property

                    Property _PrecioNeto() As Decimal
                        Get
                            Return xprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecio_1 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio() As Decimal
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

                    Property _FichaPlato() As c_Registro
                        Get
                            Return xficha
                        End Get
                        Set(ByVal value As c_Registro)
                            xficha = value
                        End Set
                    End Property

                    Property _Comentarios() As String
                        Get
                            Return xcomentarios
                        End Get
                        Set(ByVal value As String)
                            xcomentarios = value
                        End Set
                    End Property

                    Sub New()
                        Me._CodigoPlato = ""
                        Me._CostoPlato = 0
                        Me._FichaGrupo = Nothing
                        Me._NombreBoton = ""
                        Me._NombrePlato = ""
                        Me._PrecioNeto = 0
                        Me._TasaFiscal = Nothing
                        Me._UtilidadPrecio = 0
                        Me._Estatus = 0
                        Me._FichaPlato = Nothing
                        Me._Comentarios = ""
                    End Sub
                End Class
                Class ModBalanza
                    Private xplato As c_Registro
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

                    Property _EstatusBalanza() As TipoEstatus
                        Get
                            Return xest
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xest = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaProceso() As Date
                        Get
                            Return FechaSistema().Date
                        End Get
                    End Property

                    ReadOnly Property _EstatusBalanzaGrabar() As String
                        Get
                            If _EstatusBalanza = TipoEstatus.Activo Then
                                Return "1"
                            Else
                                Return "0"
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me._EstatusBalanza = 0
                        Me._FichaPlato = Nothing
                    End Sub
                End Class
                Class ModPrecios
                    Private xplato As c_Registro
                    Private xprecio_1 As Decimal
                    Private xprecio_2 As Decimal
                    Private xutilidad_1 As Decimal
                    Private xutilidad_2 As Decimal

                    Property _FichaPlato() As c_Registro
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

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property

                    Sub New()
                        Me._FichaPlato = Nothing
                        Me._PrecioNeto_1 = 0
                        Me._PrecioNeto_2 = 0
                        Me._UtilidadPrecio_1 = 0
                        Me._UtilidadPrecio_2 = 0
                    End Sub
                End Class
                Class ModOferta
                    Private xplato As c_Registro
                    Private xprecio As Decimal
                    Private xinicio As Date
                    Private xfin As Date
                    Private xutilidad As Decimal

                    Property _FichaPlato() As c_Registro
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

                    Protected Friend ReadOnly Property _FechaProceso() As Date
                        Get
                            Return FechaSistema.Date
                        End Get
                    End Property
                End Class
                Class PlatosCombo
                    Class LPlatos
                        Private xauto_plato As String
                        Private xcant_plato As Integer

                        Property _AutoPlato() As String
                            Get
                                Return xauto_plato
                            End Get
                            Set(ByVal value As String)
                                xauto_plato = value
                            End Set
                        End Property

                        Property _Cantidad() As Decimal
                            Get
                                Return xcant_plato
                            End Get
                            Set(ByVal value As Decimal)
                                xcant_plato = value
                            End Set
                        End Property

                        Sub New()
                            Me._AutoPlato = ""
                            Me._Cantidad = 0
                        End Sub
                    End Class

                    Private xplatocombo As Platos.c_Registro
                    Private xlistaplatos As List(Of LPlatos)

                    Property _PlatoCombo() As Platos.c_Registro
                        Get
                            Return xplatocombo
                        End Get
                        Set(ByVal value As Platos.c_Registro)
                            xplatocombo = value
                        End Set
                    End Property

                    Property _ListaPlatosComponente() As List(Of LPlatos)
                        Get
                            Return xlistaplatos
                        End Get
                        Set(ByVal value As List(Of LPlatos))
                            xlistaplatos = value
                        End Set
                    End Property

                    Sub New()
                        _PlatoCombo = Nothing
                        _ListaPlatosComponente = New List(Of LPlatos)
                    End Sub
                End Class
                Class ItemInventario
                    Private xa_plato As String
                    Private xa_producto As String
                    Private xa_medida_empaq As String
                    Private xcontenido As Integer
                    Private xcantidad As Decimal

                    Property _AutoPlato() As String
                        Protected Friend Get
                            Return xa_plato
                        End Get
                        Set(ByVal value As String)
                            xa_plato = value
                        End Set
                    End Property

                    Property _AutoProducto() As String
                        Protected Friend Get
                            Return xa_producto
                        End Get
                        Set(ByVal value As String)
                            xa_producto = value
                        End Set
                    End Property

                    Property _AutoMedidaEmpaq() As String
                        Protected Friend Get
                            Return xa_medida_empaq
                        End Get
                        Set(ByVal value As String)
                            xa_medida_empaq = value
                        End Set
                    End Property

                    Property _ContenidoEmpaq() As Integer
                        Get
                            Return xcontenido
                        End Get
                        Set(ByVal value As Integer)
                            xcontenido = value
                        End Set
                    End Property

                    Property _CantidadDescontar() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoMedidaEmpaq = ""
                        Me._AutoPlato = ""
                        Me._AutoProducto = ""
                        Me._CantidadDescontar = 0
                        Me._ContenidoEmpaq = 0
                    End Sub
                End Class
                Class ModificarItemInv
                    Private xa_medida_empaq As String
                    Private xcontenido As Integer
                    Private xcantidad As Decimal
                    Private xfichaitem As PlatosInventario.c_Registro

                    Property _AutoMedidaEmpaq() As String
                        Protected Friend Get
                            Return xa_medida_empaq
                        End Get
                        Set(ByVal value As String)
                            xa_medida_empaq = value
                        End Set
                    End Property

                    Property _ContenidoEmpaq() As Integer
                        Get
                            Return xcontenido
                        End Get
                        Set(ByVal value As Integer)
                            xcontenido = value
                        End Set
                    End Property

                    Property _CantidadDescontar() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _ItemInventario() As PlatosInventario.c_Registro
                        Get
                            Return xfichaitem
                        End Get
                        Set(ByVal value As PlatosInventario.c_Registro)
                            xfichaitem = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoMedidaEmpaq = ""
                        Me._CantidadDescontar = 0
                        Me._ContenidoEmpaq = 0
                        Me._ItemInventario = Nothing
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_grupo As CampoDato
                    Private f_nombre_plato As CampoDato
                    Private f_nombre_boton As CampoDato
                    Private f_codigo As CampoDato
                    Private f_precio_1 As CampoDato
                    Private f_precio_2 As CampoDato
                    Private f_impuesto As CampoDato
                    Private f_tasa As CampoDato
                    Private f_pesado_unidad As CampoDato
                    Private f_comentarios As CampoDato
                    Private f_estatus As CampoDato
                    Private f_escombo As CampoDato
                    Private f_esoferta As CampoDato
                    Private f_fecha_inicio As CampoDato
                    Private f_fecha_final As CampoDato
                    Private f_precio_oferta As CampoDato
                    Private f_id_seguridad As Byte()
                    Private f_fecha_alta As CampoDato
                    Private f_estatus_balanza As CampoDato
                    Private f_PLU As CampoDato
                    Private f_fecha_ult_actualizacion As CampoDato
                    Private f_costo_plato As CampoDato
                    Private f_utilidad_1 As CampoDato
                    Private f_utilidad_2 As CampoDato
                    Private f_utilidad_oferta As CampoDato
                    Private f_imagen As CampoDato

                    '
                    Private xtipo_precio_seleccionado As TipoPrecioFastFood

#Region "Define"
                    Property c_Automatico() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    Property c_AutoGrupo() As CampoDato
                        Get
                            Return f_auto_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_grupo = value
                        End Set
                    End Property

                    Property c_NombrePlato() As CampoDato
                        Get
                            Return f_nombre_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_plato = value
                        End Set
                    End Property

                    Property c_NombreBoton() As CampoDato
                        Get
                            Return f_nombre_boton
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre_boton = value
                        End Set
                    End Property

                    Property c_CodigoPlato() As CampoDato
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_Precio_1() As CampoDato
                        Get
                            Return f_precio_1
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_1 = value
                        End Set
                    End Property

                    Property c_Precio_2() As CampoDato
                        Get
                            Return f_precio_2
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_2 = value
                        End Set
                    End Property

                    Property c_TipoImpuesto() As CampoDato
                        Get
                            Return f_impuesto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_impuesto = value
                        End Set
                    End Property

                    Property c_TasaImpuesto() As CampoDato
                        Get
                            Return f_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa = value
                        End Set
                    End Property

                    Property c_PesadoUnidad() As CampoDato
                        Get
                            Return f_pesado_unidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_pesado_unidad = value
                        End Set
                    End Property

                    Property c_Comentarios() As CampoDato
                        Get
                            Return f_comentarios
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_comentarios = value
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

                    Property c_EsCombo() As CampoDato
                        Get
                            Return f_escombo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_escombo = value
                        End Set
                    End Property

                    Property c_EsOferta() As CampoDato
                        Get
                            Return f_esoferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_esoferta = value
                        End Set
                    End Property

                    Property c_FechaInicioOferta() As CampoDato
                        Get
                            Return f_fecha_inicio
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_inicio = value
                        End Set
                    End Property

                    Property c_FechaCulminacionOferta() As CampoDato
                        Get
                            Return f_fecha_final
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_final = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' FULL IVA
                    ''' </summary>
                    Property c_PrecioOferta() As CampoDato
                        Get
                            Return f_precio_oferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_oferta = value
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

                    Property c_FechaAlta() As CampoDato
                        Get
                            Return f_fecha_alta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_alta = value
                        End Set
                    End Property

                    Property c_EstatusBalanza() As CampoDato
                        Get
                            Return f_estatus_balanza
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_estatus_balanza = value
                        End Set
                    End Property

                    Property c_CodigoPLU() As CampoDato
                        Get
                            Return f_PLU
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_PLU = value
                        End Set
                    End Property

                    Property c_FechaUltActualizacion() As CampoDato
                        Get
                            Return f_fecha_ult_actualizacion
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha_ult_actualizacion = value
                        End Set
                    End Property

                    Property c_CostoPlato() As CampoDato
                        Get
                            Return f_costo_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_plato = value
                        End Set
                    End Property

                    Property c_Utilidad1() As CampoDato
                        Get
                            Return f_utilidad_1
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_utilidad_1 = value
                        End Set
                    End Property

                    Property c_Utilidad2() As CampoDato
                        Get
                            Return f_utilidad_2
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_utilidad_2 = value
                        End Set
                    End Property

                    Property c_UtilidadOferta() As CampoDato
                        Get
                            Return f_utilidad_oferta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_utilidad_oferta = value
                        End Set
                    End Property
#End Region

                    ReadOnly Property _Automatico() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_grupo._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_grupo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_plato._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_plato._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreBoton() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre_boton._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre_boton._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoPlato() As String
                        Get
                            Dim xv As String = IIf(Me.f_codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Precio_1() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_1._ContenidoCampo Is Nothing, 0, Me.f_precio_1._RetornarValor(Of Decimal)())
                            Return New Precio(xv, _TasaImpuesto, Precio.TipoFuncion.Aplicar)
                        End Get
                    End Property

                    ReadOnly Property _Precio_2() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_2._ContenidoCampo Is Nothing, 0, Me.f_precio_2._RetornarValor(Of Decimal)())
                            Return New Precio(xv, _TasaImpuesto, Precio.TipoFuncion.Aplicar)
                        End Get
                    End Property

                    ReadOnly Property _TipoImpuesto() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.f_impuesto._RetornarValor(Of String)() Is Nothing, "", Me.f_impuesto._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _TasaImpuesto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tasa._ContenidoCampo Is Nothing, 0, Me.f_tasa._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _PesadoUnidad() As TipoProductoBalanza
                        Get
                            Dim xv As String = IIf(Me.f_pesado_unidad._RetornarValor(Of String)() Is Nothing, "", Me.f_pesado_unidad._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "U" : Return TipoProductoBalanza.Unidad
                                Case "P" : Return TipoProductoBalanza.Pesado
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _Comentarios() As String
                        Get
                            Dim xv As String = IIf(Me.f_comentarios._RetornarValor(Of String)() Is Nothing, "", Me.f_comentarios._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _EstatusPlato() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _PlatoTipoCombo() As TipoSiNo
                        Get
                            Dim xv As String = IIf(Me.f_escombo._RetornarValor(Of String)() Is Nothing, "", Me.f_escombo._RetornarValor(Of String)())
                            Select Case xv.Trim
                                Case "0" : Return TipoSiNo.No
                                Case "1" : Return TipoSiNo.Si
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion La Cual Retorna True/False, Indicando Si Esta / No En Oferta, Tomando En Cuenta La Fecha Y El Estaus De Oferta
                    ''' </summary>
                    ReadOnly Property _PlatoEnOferta() As Boolean
                        Get
                            Dim xv As String = IIf(Me.f_esoferta._RetornarValor(Of String)() Is Nothing, "", Me.f_esoferta._RetornarValor(Of String)())
                            If xv.Trim = "1" Then
                                If FechaSistema() >= _FechaInicioOferta And FechaSistema() <= _FechaCulminacionOferta Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ReadOnly Property _FechaInicioOferta() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_inicio._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_inicio._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _FechaCulminacionOferta() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_final._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_final._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _Precio_Oferta() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_oferta._ContenidoCampo Is Nothing, 0, Me.f_precio_oferta._RetornarValor(Of Decimal)())
                            Return New Precio(xv, _TasaImpuesto, Precio.TipoFuncion.Desglozar)
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.f_id_seguridad
                        End Get
                    End Property

                    ReadOnly Property _FechaAlta() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_alta._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_alta._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _EstatusBalanza() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_estatus_balanza._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus_balanza._RetornarValor(Of String)())
                            If xv.Trim = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ReadOnly Property _CodigoPLU() As String
                        Get
                            Dim xv As String = IIf(Me.f_PLU._RetornarValor(Of String)() Is Nothing, "", Me.f_PLU._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _FechaUltActualizacion() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_ult_actualizacion._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_ult_actualizacion._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    ReadOnly Property _CostoPlato() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_plato._ContenidoCampo Is Nothing, 0, Me.f_costo_plato._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _UtilidadPrecio_1() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_utilidad_1._ContenidoCampo Is Nothing, 0, Me.f_utilidad_1._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _UtilidadPrecio_2() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_utilidad_2._ContenidoCampo Is Nothing, 0, Me.f_utilidad_2._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _UtilidadPrecioOferta() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_utilidad_oferta._ContenidoCampo Is Nothing, 0, Me.f_utilidad_oferta._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Try
                                Dim xp1 As New SqlParameter("@auto", _AutoGrupo)
                                Dim xt As String = ""
                                xt = F_GetString("select nombre_grupo from grupo_fastfood where auto=@auto", xp1)
                                Return xt.Trim
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Inidica El Precio A Facturar Para FastFood, Tomando Como Base El Tipo De Precio Seleccionado 
                    ''' </summary>
                    ReadOnly Property _PrecioAFacturar(ByVal xopcion As FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar) As Precio
                        Get
                            If _PlatoEnOferta Then
                                Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_Oferta
                                Return _Precio_Oferta
                            Else
                                If xopcion = FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar.Precio_1 Then
                                    Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                    Return _Precio_1
                                Else
                                    If Me._Precio_2._Base > 0 Then
                                        Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_2
                                        Return _Precio_2
                                    Else
                                        Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                        Return _Precio_1
                                    End If
                                End If
                            End If
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _PrecioAFacturar_Restaurant(ByVal xestatus_oferta As Boolean, ByVal xprecio_seleccionado As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar) As Precio
                        Get
                            If xestatus_oferta Then
                                If _PlatoEnOferta Then
                                    Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_Oferta
                                    Return _Precio_Oferta
                                Else
                                    If xprecio_seleccionado = FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar.Precio_1 Then
                                        Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                        Return _Precio_1
                                    Else
                                        If Me._Precio_2._Base > 0 Then
                                            Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_2
                                            Return _Precio_2
                                        Else
                                            Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                            Return _Precio_1
                                        End If
                                    End If
                                End If
                            Else
                                If xprecio_seleccionado = FichaGlobal.c_ConfSistema.ConfFastFood.PrecioFacturar.Precio_1 Then
                                    Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                    Return _Precio_1
                                Else
                                    If Me._Precio_2._Base > 0 Then
                                        Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_2
                                        Return _Precio_2
                                    Else
                                        Me._PrecioAFacturar_Seleccionado = TipoPrecioFastFood.Precio_1
                                        Return _Precio_1
                                    End If
                                End If
                            End If
                        End Get
                    End Property

                    Property _PrecioAFacturar_Seleccionado() As TipoPrecioFastFood
                        Get
                            Return Me.xtipo_precio_seleccionado
                        End Get
                        Set(ByVal value As TipoPrecioFastFood)
                            Me.xtipo_precio_seleccionado = value
                        End Set
                    End Property

                    Function f_AutoPlatos_Combo() As DataTable
                        If Me._PlatoTipoCombo = TipoSiNo.Si Then
                            Try
                                Dim xtb As New DataTable
                                Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                    xadap.SelectCommand.CommandText = "select auto_plato from menucombos_fastfood where auto_plato_combo=@auto"
                                    xadap.SelectCommand.Parameters.Clear()
                                    xadap.SelectCommand.Parameters.AddWithValue("@auto", Me._Automatico).Size = Me.c_Automatico._LargoCampo
                                    xadap.Fill(xtb)
                                End Using
                                Return xtb
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                                Return Nothing
                            End Try
                        Else
                            Return Nothing
                        End If
                    End Function

                    ''' <summary>
                    ''' Indica Si El Plato Envia / No Comandas
                    ''' </summary>
                    ReadOnly Property _NotificaComanda() As Boolean
                        Get
                            Try
                                Dim xres As Integer = 0
                                Dim xp1 As New SqlParameter("@auto", Me._Automatico)
                                xres = F_GetInteger("select COUNT(*) from MenuEstaciones_FastFood where auto_plato=@auto", xp1)
                                If xres > 0 Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Catch ex As Exception
                                Return False
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _EstatusInventario() As Boolean
                        Get
                            Try
                                Dim xres As Integer = 0
                                Dim xp1 As New SqlParameter("@auto", Me._Automatico)
                                xres = F_GetInteger("select COUNT(*) from MenuPlatoInventario where auto_plato=@auto", xp1)
                                If xres > 0 Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Catch ex As Exception
                                Return False
                            End Try
                        End Get
                    End Property

                    Property c_Imagen() As CampoDato
                        Get
                            Return f_imagen
                        End Get
                        Set(ByVal value As CampoDato)
                            f_imagen = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusImagen() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_imagen._RetornarValor(Of String)() Is Nothing, "", Me.f_imagen._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoGrupo = New CampoDato("auto_grupo", 10)
                        Me.c_Automatico = New CampoDato("auto", 10)
                        Me.c_CodigoPlato = New CampoDato("codigo", 15)
                        Me.c_Comentarios = New CampoDato("comentarios", 120)
                        Me.c_EsCombo = New CampoDato("escombo", 1)
                        Me.c_EsOferta = New CampoDato("esoferta", 1)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_FechaAlta = New CampoDato("fecha_alta")
                        Me.c_FechaCulminacionOferta = New CampoDato("fecha_final")
                        Me.c_FechaInicioOferta = New CampoDato("fecha_inicio")
                        Me.c_NombreBoton = New CampoDato("nombre_boton", 30)
                        Me.c_NombrePlato = New CampoDato("nombre_plato", 60)
                        Me.c_PesadoUnidad = New CampoDato("pesado_unidad", 1)
                        Me.c_Precio_1 = New CampoDato("precio_1")
                        Me.c_Precio_2 = New CampoDato("precio_2")
                        Me.c_PrecioOferta = New CampoDato("precio_oferta")
                        Me.c_TasaImpuesto = New CampoDato("tasa")
                        Me.c_TipoImpuesto = New CampoDato("impuesto", 1)
                        Me.c_EstatusBalanza = New CampoDato("estatus_balanza", 1)
                        Me.c_CodigoPLU = New CampoDato("PLU", 5)
                        Me.c_FechaUltActualizacion = New CampoDato("fecha_ult_actualizacion")
                        Me.c_CostoPlato = New CampoDato("costo_plato")
                        Me.c_Utilidad1 = New CampoDato("utilidad_1")
                        Me.c_Utilidad2 = New CampoDato("utilidad_2")
                        Me.c_UtilidadOferta = New CampoDato("utilidad_oferta")
                        Me.c_Imagen = New CampoDato("imagen", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            Me._PrecioAFacturar_Seleccionado = 0
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase MENU PLATO ESTACION - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoGrupo._ContenidoCampo = xrow(.c_AutoGrupo._NombreCampo)
                                .c_Automatico._ContenidoCampo = xrow(.c_Automatico._NombreCampo)
                                .c_CodigoPlato._ContenidoCampo = xrow(.c_CodigoPlato._NombreCampo)
                                .c_CodigoPLU._ContenidoCampo = xrow(.c_CodigoPLU._NombreCampo)
                                .c_Comentarios._ContenidoCampo = xrow(.c_Comentarios._NombreCampo)
                                .c_CostoPlato._ContenidoCampo = xrow(.c_CostoPlato._NombreCampo)
                                .c_EsCombo._ContenidoCampo = xrow(.c_EsCombo._NombreCampo)
                                .c_EsOferta._ContenidoCampo = xrow(.c_EsOferta._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_EstatusBalanza._ContenidoCampo = xrow(.c_EstatusBalanza._NombreCampo)
                                .c_FechaAlta._ContenidoCampo = xrow(.c_FechaAlta._NombreCampo)

                                If IsDBNull(xrow(.c_FechaCulminacionOferta._NombreCampo)) Then
                                    .c_FechaCulminacionOferta._ContenidoCampo = DBNull.Value
                                Else
                                    .c_FechaCulminacionOferta._ContenidoCampo = xrow(.c_FechaCulminacionOferta._NombreCampo)
                                End If
                                If IsDBNull(xrow(.c_FechaInicioOferta._NombreCampo)) Then
                                    .c_FechaInicioOferta._ContenidoCampo = DBNull.Value
                                Else
                                    .c_FechaInicioOferta._ContenidoCampo = xrow(.c_FechaInicioOferta._NombreCampo)
                                End If

                                .c_FechaUltActualizacion._ContenidoCampo = xrow(.c_FechaUltActualizacion._NombreCampo)
                                .c_IdSeguridad = xrow("id_seguridad")
                                .c_NombreBoton._ContenidoCampo = xrow(.c_NombreBoton._NombreCampo)
                                .c_NombrePlato._ContenidoCampo = xrow(.c_NombrePlato._NombreCampo)
                                .c_PesadoUnidad._ContenidoCampo = xrow(.c_PesadoUnidad._NombreCampo)
                                .c_Precio_1._ContenidoCampo = xrow(.c_Precio_1._NombreCampo)
                                .c_Precio_2._ContenidoCampo = xrow(.c_Precio_2._NombreCampo)
                                .c_PrecioOferta._ContenidoCampo = xrow(.c_PrecioOferta._NombreCampo)
                                .c_TasaImpuesto._ContenidoCampo = xrow(.c_TasaImpuesto._NombreCampo)
                                .c_TipoImpuesto._ContenidoCampo = xrow(.c_TipoImpuesto._NombreCampo)
                                .c_Utilidad1._ContenidoCampo = xrow(.c_Utilidad1._NombreCampo)
                                .c_Utilidad2._ContenidoCampo = xrow(.c_Utilidad2._NombreCampo)
                                .c_UtilidadOferta._ContenidoCampo = xrow(.c_UtilidadOferta._NombreCampo)

                                If Not IsDBNull(xrow(.c_Imagen._NombreCampo)) Then
                                    .c_Imagen._ContenidoCampo = xrow(.c_Imagen._NombreCampo)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU PLATOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

#Region "FUNCIONES SQL"
                Protected Friend Const ELIMINAR_PLATO As String = "Delete menuplatos_fastfood where auto=@auto and id_seguridad=@id"

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
                    + ",PLU,imagen) " _
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
                    + ",@PLU,@imagen)"

                Protected Friend Const ACTUALIZAR_PLATO As String = "UPDATE menuplatos_fastfood SET " _
                                   + "auto_grupo=@auto_grupo" _
                                   + ",nombre_plato=@nombre_plato" _
                                   + ",nombre_boton=@nombre_boton" _
                                   + ",codigo=@codigo" _
                                   + ",impuesto=@impuesto" _
                                   + ",tasa=@tasa" _
                                   + ",estatus=@estatus" _
                                   + ",fecha_ult_actualizacion=@fecha_ult_actualizacion" _
                                   + ",precio_1=@precio_1" _
                                   + ",utilidad_1=@utilidad_1" _
                                   + ",costo_plato=@costo_plato " _
                                   + ",comentarios=@comentarios " _
                                   + "WHERE auto=@auto and id_seguridad=@id"

#End Region

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


                Sub M_LimpiarFicha()
                    Me.RegistroDato.M_Limpiar()
                End Sub


                ''' <summary>
                ''' funcion que permite buscar y cargar un plato a la ficha
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from menuplatos_fastfood where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using

                        If (xtb.Rows.Count > 0) Then
                            M_CargarFicha(xtb(0))
                        End If

                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function


                Function F_Agregar(ByVal xreg As Agregar) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_menuplato_fastfood=a_menuplato_fastfood+1;select a_menuplato_fastfood from contadores"
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xplato As New c_Registro

                        With xplato
                            .c_AutoGrupo._ContenidoCampo = xreg._FichaGrupo._AutoGrupo
                            .c_Automatico._ContenidoCampo = ""
                            .c_CodigoPlato._ContenidoCampo = xreg._CodigoPlato
                            .c_CodigoPLU._ContenidoCampo = ""
                            .c_Comentarios._ContenidoCampo = xreg._Comentarios
                            .c_CostoPlato._ContenidoCampo = xreg._CostoPlato
                            .c_EsCombo._ContenidoCampo = "0"
                            .c_EsOferta._ContenidoCampo = "0"
                            .c_Estatus._ContenidoCampo = xreg._Estatus
                            .c_EstatusBalanza._ContenidoCampo = "0"
                            .c_FechaAlta._ContenidoCampo = xreg._FechaRegistro
                            .c_FechaCulminacionOferta._ContenidoCampo = DBNull.Value
                            .c_FechaInicioOferta._ContenidoCampo = DBNull.Value
                            .c_FechaUltActualizacion._ContenidoCampo = xreg._FechaRegistro
                            .c_Imagen._ContenidoCampo = "0"
                            .c_NombreBoton._ContenidoCampo = xreg._NombreBoton
                            .c_NombrePlato._ContenidoCampo = xreg._NombrePlato
                            .c_PesadoUnidad._ContenidoCampo = ""
                            .c_Precio_1._ContenidoCampo = xreg._PrecioNeto
                            .c_Precio_2._ContenidoCampo = 0
                            .c_PrecioOferta._ContenidoCampo = 0
                            .c_TasaImpuesto._ContenidoCampo = xreg._TasaFiscal._TasaValor
                            .c_TipoImpuesto._ContenidoCampo = xreg._TasaFiscal._TasaTipo
                            .c_Utilidad1._ContenidoCampo = xreg._UtilidadPrecio
                            .c_Utilidad2._ContenidoCampo = 0
                            .c_UtilidadOferta._ContenidoCampo = 0
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_menuplato_fastfood from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_menuplato_fastfood=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = xsql_1
                                    xplato.c_Automatico._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'MENUPLATOS
                                    xcmd.CommandText = INSERT_PLATO
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xplato.c_AutoGrupo._NombreCampo, xplato._AutoGrupo).Size = xplato.c_AutoGrupo._LargoCampo
                                        .AddWithValue("@" + xplato.c_Automatico._NombreCampo, xplato._Automatico).Size = xplato.c_Automatico._LargoCampo
                                        .AddWithValue("@" + xplato.c_CodigoPlato._NombreCampo, xplato._CodigoPlato).Size = xplato.c_CodigoPlato._LargoCampo
                                        .AddWithValue("@" + xplato.c_CodigoPLU._NombreCampo, xplato._CodigoPLU).Size = xplato.c_CodigoPLU._LargoCampo
                                        .AddWithValue("@" + xplato.c_Comentarios._NombreCampo, xplato._Comentarios).Size = xplato.c_Comentarios._LargoCampo
                                        .AddWithValue("@" + xplato.c_CostoPlato._NombreCampo, xplato._CostoPlato)
                                        .AddWithValue("@" + xplato.c_EsCombo._NombreCampo, xplato.c_EsCombo._ContenidoCampo).Size = xplato.c_EsCombo._LargoCampo
                                        .AddWithValue("@" + xplato.c_EsOferta._NombreCampo, xplato.c_EsOferta._ContenidoCampo).Size = xplato.c_EsOferta._LargoCampo
                                        .AddWithValue("@" + xplato.c_Estatus._NombreCampo, xplato.c_Estatus._ContenidoCampo).Size = xplato.c_Estatus._LargoCampo
                                        .AddWithValue("@" + xplato.c_EstatusBalanza._NombreCampo, xplato.c_EstatusBalanza._ContenidoCampo).Size = xplato.c_EstatusBalanza._LargoCampo
                                        .AddWithValue("@" + xplato.c_FechaAlta._NombreCampo, xplato._FechaAlta)
                                        .AddWithValue("@" + xplato.c_FechaCulminacionOferta._NombreCampo, DBNull.Value)
                                        .AddWithValue("@" + xplato.c_FechaInicioOferta._NombreCampo, DBNull.Value)
                                        .AddWithValue("@" + xplato.c_FechaUltActualizacion._NombreCampo, xplato._FechaUltActualizacion)
                                        .AddWithValue("@" + xplato.c_Imagen._NombreCampo, xplato.c_Imagen._ContenidoCampo)
                                        .AddWithValue("@" + xplato.c_NombreBoton._NombreCampo, xplato._NombreBoton).Size = xplato.c_NombreBoton._LargoCampo
                                        .AddWithValue("@" + xplato.c_NombrePlato._NombreCampo, xplato._NombrePlato).Size = xplato.c_NombrePlato._LargoCampo
                                        .AddWithValue("@" + xplato.c_PesadoUnidad._NombreCampo, xplato._PesadoUnidad).Size = xplato.c_PesadoUnidad._LargoCampo
                                        .AddWithValue("@" + xplato.c_Precio_1._NombreCampo, xplato._Precio_1._Base)
                                        .AddWithValue("@" + xplato.c_Precio_2._NombreCampo, xplato._Precio_2._Base)
                                        .AddWithValue("@" + xplato.c_PrecioOferta._NombreCampo, xplato._Precio_Oferta._Base)
                                        .AddWithValue("@" + xplato.c_TasaImpuesto._NombreCampo, xplato._TasaImpuesto)
                                        .AddWithValue("@" + xplato.c_TipoImpuesto._NombreCampo, xplato.c_TipoImpuesto._ContenidoCampo).Size = xplato.c_TipoImpuesto._LargoCampo
                                        .AddWithValue("@" + xplato.c_Utilidad1._NombreCampo, xplato._UtilidadPrecio_1)
                                        .AddWithValue("@" + xplato.c_Utilidad2._NombreCampo, xplato._UtilidadPrecio_2)
                                        .AddWithValue("@" + xplato.c_UtilidadOferta._NombreCampo, xplato._UtilidadPrecioOferta)
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoRegistrado(xplato._Automatico)
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
                        Throw New Exception("AGREGAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_EliminarPlato(ByVal xreg As Eliminar) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xr As Integer = 0

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = ELIMINAR_PLATO
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xreg._AutoPlato)
                                        .AddWithValue("@id", xreg._Id)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE ELIMINADO / ACTUALIZADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                If EXSQL.Number = 547 Then
                                    Throw New Exception("ERROR... EL PLATO NO PUEDE SER ELIMINADO, MOTIVO: PLATO TIENE MOVIMIENTO DE VENTAS / PLATO ES UN COMBO ")
                                Else
                                    Throw New Exception(EXSQL.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ELIMINAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarPlato(ByVal xreg As Modificar) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xplato As New c_Registro

                        With xplato
                            .c_AutoGrupo._ContenidoCampo = xreg._FichaGrupo._AutoGrupo
                            .c_Automatico._ContenidoCampo = xreg._FichaPlato._Automatico
                            .c_CodigoPlato._ContenidoCampo = xreg._CodigoPlato
                            .c_CostoPlato._ContenidoCampo = xreg._CostoPlato
                            If xreg._Estatus = TipoEstatus.Activo Then
                                .c_Estatus._ContenidoCampo = "0"
                            Else
                                .c_Estatus._ContenidoCampo = "1"
                            End If
                            .c_FechaUltActualizacion._ContenidoCampo = xreg._FechaRegistro
                            .c_NombreBoton._ContenidoCampo = xreg._NombreBoton
                            .c_NombrePlato._ContenidoCampo = xreg._NombrePlato
                            .c_Comentarios._ContenidoCampo = xreg._Comentarios
                            .c_Precio_1._ContenidoCampo = xreg._PrecioNeto
                            .c_TasaImpuesto._ContenidoCampo = xreg._TasaFiscal._TasaValor
                            .c_TipoImpuesto._ContenidoCampo = xreg._TasaFiscal._TasaTipo
                            .c_Utilidad1._ContenidoCampo = xreg._UtilidadPrecio
                            .c_IdSeguridad = xreg._FichaPlato._IdSeguridad
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0
                                    xcmd.CommandText = ACTUALIZAR_PLATO
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xplato.c_AutoGrupo._NombreCampo, xplato._AutoGrupo).Size = xplato.c_AutoGrupo._LargoCampo
                                        .AddWithValue("@" + xplato.c_Automatico._NombreCampo, xplato._Automatico).Size = xplato.c_Automatico._LargoCampo
                                        .AddWithValue("@" + xplato.c_CodigoPlato._NombreCampo, xplato._CodigoPlato).Size = xplato.c_CodigoPlato._LargoCampo
                                        .AddWithValue("@" + xplato.c_CostoPlato._NombreCampo, xplato._CostoPlato)
                                        .AddWithValue("@" + xplato.c_FechaUltActualizacion._NombreCampo, xplato._FechaUltActualizacion)
                                        .AddWithValue("@" + xplato.c_NombreBoton._NombreCampo, xplato._NombreBoton).Size = xplato.c_NombreBoton._LargoCampo
                                        .AddWithValue("@" + xplato.c_NombrePlato._NombreCampo, xplato._NombrePlato).Size = xplato.c_NombrePlato._LargoCampo
                                        .AddWithValue("@" + xplato.c_Comentarios._NombreCampo, xplato._Comentarios).Size = xplato.c_Comentarios._LargoCampo
                                        .AddWithValue("@" + xplato.c_Precio_1._NombreCampo, xplato._Precio_1._Base)
                                        .AddWithValue("@" + xplato.c_TasaImpuesto._NombreCampo, xplato._TasaImpuesto)
                                        .AddWithValue("@" + xplato.c_TipoImpuesto._NombreCampo, xplato.c_TipoImpuesto._ContenidoCampo).Size = xplato.c_TipoImpuesto._LargoCampo
                                        .AddWithValue("@" + xplato.c_Utilidad1._NombreCampo, xplato._UtilidadPrecio_1)
                                        .AddWithValue("@" + xplato.c_Estatus._NombreCampo, xplato.c_Estatus._ContenidoCampo).Size = xplato.c_Estatus._LargoCampo
                                        .AddWithValue("@ID", xplato._IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE ELIMINADO / ACTUALIZADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xplato._Automatico)
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
                        Throw New Exception("MODIFICAR PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarFichaBalanza(ByVal xbal As ModBalanza) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update menuplatos_fastfood set estatus_balanza=@estatus_balanza, fecha_ult_actualizacion=@fecha" & _
                                                     " where auto=@auto and id_seguridad=@id"
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xbal._FichaPlato._Automatico)
                                        .AddWithValue("@estatus_balanza", xbal._EstatusBalanzaGrabar).Size = xbal._FichaPlato.c_EstatusBalanza._LargoCampo
                                        .AddWithValue("@fecha", xbal._FechaProceso)
                                        .AddWithValue("@id", xbal._FichaPlato._IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO / ANULADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xbal._FichaPlato._Automatico)
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
                        Throw New Exception("MODIFICAR FICHA BALANZA DEL PLATO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarFichaPrecios(ByVal xreg As ModPrecios) As Boolean
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
                                        .AddWithValue("@auto", xreg._FichaPlato._Automatico)
                                        .AddWithValue("@fecha", xreg._Fecha)
                                        .AddWithValue("@precio_1", xreg._PrecioNeto_1)
                                        .AddWithValue("@utilidad_1", xreg._UtilidadPrecio_1)
                                        .AddWithValue("@precio_2", xreg._PrecioNeto_2)
                                        .AddWithValue("@utilidad_2", xreg._UtilidadPrecio_2)
                                        .AddWithValue("@ID", xreg._FichaPlato._IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO / ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xreg._FichaPlato._Automatico)
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
                        Throw New Exception("ACTUALIZAR PRECIOS" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarFichaOferta(ByVal xreg As ModOferta) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xsql As String = "UPDATE menuplatos_fastfood SET precio_oferta=@precio_oferta,utilidad_oferta=@utilidad_oferta, esoferta='1', " _
                                            + "fecha_inicio=@fecha_inicio, fecha_final=@fecha_final, fecha_ult_actualizacion=@fecha " _
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
                                        .AddWithValue("@auto", xreg._FichaPlato._Automatico)
                                        .AddWithValue("@ID", xreg._FichaPlato._IdSeguridad)
                                        .AddWithValue("@precio_oferta", xreg._PrecioOferta)
                                        .AddWithValue("@utilidad_oferta", xreg._UtilidadPrecioOferta)
                                        .AddWithValue("@fecha_inicio", xreg._FechaInicio)
                                        .AddWithValue("@fecha_final", xreg._FechaCulminacion)
                                        .AddWithValue("@fecha", xreg._FechaProceso)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... PLATO FUE MODIFICADO / ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xreg._FichaPlato._Automatico)
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
                        Throw New Exception("ACTUALIZAR OFERTAS" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_DesactivarOferta(ByVal xplato As c_Registro) As Boolean
                    Try
                        Dim xr As Integer = 0
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "update menuplatos_fastfood set esoferta='0' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xplato._Automatico)
                                        .AddWithValue("@id_seguridad", xplato.c_IdSeguridad)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL DESACTIVAR OFERTA... PLATO HA SIDO ACTUALIZADO / ELIMINADO POR OTRO USUARIO ")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xplato._Automatico)
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Throw New Exception(ex2.Message + "," + ex2.Number)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("DESACTIVAR OFERTA" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModificarFichaCombo(ByVal xplatoscombo As PlatosCombo) As Boolean
                    Try
                        Dim xcombo As New FastFood.PlatosCombos.c_Registro
                        Dim xsql As String = "update contadores set a_menucombo_fastfood=a_menucombo_fastfood+1;select a_menucombo_fastfood from contadores"
                        Dim xtr As SqlTransaction = Nothing

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xres As Integer = 0
                                    xcmd.Parameters.Clear()
                                    If xplatoscombo._ListaPlatosComponente.Count > 0 Then
                                        xcmd.CommandText = "update menuplatos_fastfood set escombo='1' where auto=@auto and id_seguridad=@id"
                                    Else
                                        xcmd.CommandText = "update menuplatos_fastfood set escombo='0' where auto=@auto and id_seguridad=@id"
                                    End If
                                    xcmd.Parameters.AddWithValue("@auto", xplatoscombo._PlatoCombo._Automatico)
                                    xcmd.Parameters.AddWithValue("@id", xplatoscombo._PlatoCombo._IdSeguridad)
                                    xres = xcmd.ExecuteNonQuery()
                                    If xres = 0 Then
                                        Throw New Exception("ERROR AL REGISTRAR PLATOS AL COMBO, AL PARECER UN USUARIO HA MODIFICADO EL REGISTRO")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete from menucombos_fastfood where auto_plato_combo=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xplatoscombo._PlatoCombo._Automatico)
                                    xcmd.ExecuteNonQuery()

                                    For Each xr In xplatoscombo._ListaPlatosComponente
                                        With xcombo
                                            .M_Limpiar()

                                            .c_AutoPlato._ContenidoCampo = xr._AutoPlato
                                            .c_Cantidad._ContenidoCampo = xr._Cantidad
                                            .c_AutoPlatoCombo._ContenidoCampo = xplatoscombo._PlatoCombo._Automatico
                                        End With

                                        xcmd.CommandText = "select a_menucombo_fastfood from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_menucombo_fastfood=0"
                                            xcmd.ExecuteNonQuery()
                                        End If

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql
                                        xcombo.c_Automatico._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "insert into menucombos_fastfood (auto,auto_plato,auto_plato_combo,cantidad) values(@auto,@auto_plato,@auto_plato_combo,@cantidad) "
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xcombo.c_Automatico._NombreCampo, xcombo._Automatico).Size = xcombo.c_Automatico._LargoCampo
                                            .AddWithValue("@" + xcombo.c_AutoPlato._NombreCampo, xcombo._AutoPlato).Size = xcombo.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xcombo.c_AutoPlatoCombo._NombreCampo, xcombo._AutoPlatoCombo).Size = xcombo.c_AutoPlatoCombo._LargoCampo
                                            .AddWithValue("@" + xcombo.c_Cantidad._NombreCampo, xcombo._Cantidad)
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xplatoscombo._PlatoCombo._Automatico)
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
                        Throw New Exception("AGREGAR PLATOS A COMBO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_AgregarItemInventario(ByVal xiteminv As ItemInventario) As Boolean
                    Try
                        Dim xplatoinv As New PlatosInventario.c_Registro
                        Dim xsql As String = "update contadores set a_menuplato_inventario=a_menuplato_inventario+1;select a_menuplato_inventario from contadores"
                        Dim xtr As SqlTransaction = Nothing

                        With xplatoinv
                            .c_Auto._ContenidoCampo = ""
                            .c_AutoMedidaEmpaq._ContenidoCampo = xiteminv._AutoMedidaEmpaq
                            .c_AutoPlato._ContenidoCampo = xiteminv._AutoPlato
                            .c_AutoProducto._ContenidoCampo = xiteminv._AutoProducto
                            .c_CantidadRequeridad._ContenidoCampo = xiteminv._CantidadDescontar
                            .c_ContenidoEmpaque._ContenidoCampo = xiteminv._ContenidoEmpaq
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xres As Integer = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_menuplato_inventario from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_menuplato_inventario=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql
                                    xplatoinv.c_Auto._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PlatosInventario.InsertItemInv
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xplatoinv.c_Auto._NombreCampo, xplatoinv._Auto).Size = xplatoinv.c_Auto._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_AutoMedidaEmpaq._NombreCampo, xplatoinv._MedidaEmpaque._Automatico).Size = xplatoinv.c_AutoMedidaEmpaq._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_AutoPlato._NombreCampo, xplatoinv._Plato._Automatico).Size = xplatoinv.c_AutoPlato._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_AutoProducto._NombreCampo, xplatoinv._Producto._AutoProducto).Size = xplatoinv.c_AutoProducto._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_CantidadRequeridad._NombreCampo, xplatoinv._CantRequerida)
                                        .AddWithValue("@" + xplatoinv.c_ContenidoEmpaque._NombreCampo, xplatoinv._ContenidoEmpaque)
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _PlatoActualizado(xplatoinv._Plato._Automatico)
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
                        Throw New Exception("AGREGAR PRODUCTO INVENTARIO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_EliminarItemInventario(ByVal xitem As PlatosInventario.c_Registro) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    Dim xres As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PlatosInventario.EliminarItemInv
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xitem.c_Auto._NombreCampo, xitem._Auto)
                                        .AddWithValue("@ID", xitem._Id)
                                    End With
                                    xres = xcmd.ExecuteNonQuery()
                                    If xres = 0 Then
                                        Throw New Exception("PRODUCTO A ELIMINAR AL PARECER FUE ACTUALIZAZO / ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using

                                RaiseEvent _PlatoActualizado(xitem._Plato._Automatico)
                                Return True
                            Catch exsql As SqlException
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using

                    Catch ex As Exception
                        Throw New Exception("ELIMINAR PRODUCTO INVENTARIO" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ModoficarItemInventario(ByVal xitem As ModificarItemInv) As Boolean
                    Try
                        Dim xplatoinv As New PlatosInventario.c_Registro
                        With xplatoinv
                            .c_Auto._ContenidoCampo = xitem._ItemInventario._Auto
                            .c_AutoMedidaEmpaq._ContenidoCampo = xitem._AutoMedidaEmpaq
                            .c_AutoPlato._ContenidoCampo = xitem._ItemInventario._Plato._Automatico
                            .c_AutoProducto._ContenidoCampo = xitem._ItemInventario._Producto._AutoProducto
                            .c_CantidadRequeridad._ContenidoCampo = xitem._CantidadDescontar
                            .c_ContenidoEmpaque._ContenidoCampo = xitem._ContenidoEmpaq
                            .c_IdSeguridad = xitem._ItemInventario._Id
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    Dim xres As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = PlatosInventario.ModificarItemInv
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xplatoinv.c_Auto._NombreCampo, xplatoinv._Auto).Size = xplatoinv.c_Auto._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_AutoMedidaEmpaq._NombreCampo, xplatoinv._MedidaEmpaque._Automatico).Size = xplatoinv.c_AutoMedidaEmpaq._LargoCampo
                                        .AddWithValue("@" + xplatoinv.c_CantidadRequeridad._NombreCampo, xplatoinv._CantRequerida)
                                        .AddWithValue("@" + xplatoinv.c_ContenidoEmpaque._NombreCampo, xplatoinv._ContenidoEmpaque)
                                        .AddWithValue("@ID", xplatoinv._Id)
                                    End With
                                    xres = xcmd.ExecuteNonQuery()
                                    If xres = 0 Then
                                        Throw New Exception("PRODUCTO A MODIFICAR AL PARECER FUE ACTUALIZADO / ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using

                                RaiseEvent _PlatoActualizado(xplatoinv._Plato._Automatico)
                                Return True
                            Catch exsql As SqlException
                                Throw New Exception(exsql.Message)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using

                    Catch ex As Exception
                        Throw New Exception("MODIFICAR PRODUCTO INVENTARIO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActivarImagen(ByVal xplato As Platos.c_Registro) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            Dim rt As Integer = 0
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "Update menuplatos_fastfood set imagen='1' where auto=@auto and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@auto", xplato._Automatico)
                                xcmd.Parameters.AddWithValue("@id", xplato._IdSeguridad)
                                rt = xcmd.ExecuteNonQuery()
                            End Using
                            If rt > 0 Then
                                RaiseEvent _PlatoActualizado(xplato._Automatico)
                                Return True
                            Else
                                Throw New Exception("PLATO NO ENCONTRADO / ACTUALIZADO POR OTRO USUARIO")
                            End If
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_DesactivarImagen(ByVal xplato As Platos.c_Registro) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()

                            Dim rt As Integer = 0
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "Update menuplatos_fastfood set imagen='0' where auto=@auto and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@auto", xplato._Automatico)
                                xcmd.Parameters.AddWithValue("@id", xplato._IdSeguridad)
                                rt = xcmd.ExecuteNonQuery()
                            End Using
                            If rt > 0 Then
                                RaiseEvent _PlatoActualizado(xplato._Automatico)
                                Return True
                            Else
                                Throw New Exception("PLATO NO ENCONTRADO / ACTUALIZADO POR OTRO USUARIO")
                            End If
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

            End Class

            ''' <summary>
            ''' DEFINE LA CLASE PARA EL PLATO QUE USE COMBO: (CONJUNTO DE OTROS PLATOS)
            ''' </summary>
            Public Class PlatosCombos
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_auto_plato_combo As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' AUTOMATICO LINEA DE REGISTRO
                    ''' </summary>
                    Property c_Automatico() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' AUTO PLATO AL CUAL HACE REFERENCIA
                    ''' </summary>
                    Property c_AutoPlato() As CampoDato
                        Get
                            Return f_auto_plato
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' AUTO PLATO TIPO COMBO AL CUAL HACE REFERENCIA
                    ''' </summary>
                    Property c_AutoPlatoCombo() As CampoDato
                        Get
                            Return f_auto_plato_combo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_plato_combo = value
                        End Set
                    End Property

                    Property c_Cantidad() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
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

                    ReadOnly Property _AutoPlatoCombo() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_plato_combo._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_plato_combo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Cantidad() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_cantidad._ContenidoCampo Is Nothing, 0, Me.f_cantidad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                    End Property

                    ReadOnly Property _NombrePlato() As String
                        Get
                            Dim xp1 As New SqlParameter("@auto", _AutoPlato)
                            Return F_GetString("select nombre_plato from menuplatos_fastfood where auto=@auto", xp1).Trim
                        End Get
                    End Property

                    Sub New()
                        With Me
                            .c_Automatico = New CampoDato("auto", 10)
                            .c_AutoPlato = New CampoDato("auto_plato", 10)
                            .c_AutoPlatoCombo = New CampoDato("auto_plato_combo", 10)
                            .c_Cantidad = New CampoDato("cantidad")

                            Me.M_Limpiar()
                        End With
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase MENU COMBOS - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Automatico._ContenidoCampo = xrow(.c_Automatico._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoPlatoCombo._ContenidoCampo = xrow(.c_AutoPlatoCombo._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("MENU COMBOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
            End Class

            ''' <summary>
            ''' DEFINE LA CLASE PARA EL PLATO QUE USE PRODUCTOS DE INVENTARIO
            ''' </summary>
            Public Class PlatosInventario
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_auto_plato As CampoDato
                    Private f_auto_producto As CampoDato
                    Private f_auto_medida_empaq As CampoDato
                    Private f_contenido_empaq As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_id_seguridad As Byte()

                    Property c_Auto() As CampoDato
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

                    Property c_AutoProducto() As CampoDato
                        Get
                            Return f_auto_producto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_producto = value
                        End Set
                    End Property

                    Property c_AutoMedidaEmpaq() As CampoDato
                        Get
                            Return f_auto_medida_empaq
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_medida_empaq = value
                        End Set
                    End Property

                    Property c_ContenidoEmpaque() As CampoDato
                        Get
                            Return f_contenido_empaq
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_contenido_empaq = value
                        End Set
                    End Property

                    Property c_CantidadRequeridad() As CampoDato
                        Get
                            Return f_cantidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad = value
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

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = ""
                            xv = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.c_Auto._RetornarValor(Of String)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Plato() As Platos.c_Registro
                        Get
                            Try
                                Dim xv As String = ""
                                xv = IIf(Me.f_auto_plato._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoPlato._RetornarValor(Of String)())
                                If xv <> "" Then
                                    Dim xplato As New Platos
                                    xplato.F_CargarRegistro(xv)
                                    Return xplato.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _Producto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xv As String = ""
                                xv = IIf(Me.c_AutoProducto._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoProducto._RetornarValor(Of String)())
                                If xv <> "" Then
                                    Dim xproducto As New FichaProducto.Prd_Producto
                                    If xproducto.F_BuscarProducto(xv) Then
                                        Return xproducto.RegistroDato
                                    Else
                                        Return Nothing
                                    End If
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _MedidaEmpaque() As FichaProducto.Prd_Medida.c_Registro
                        Get
                            Try
                                Dim xv As String = ""
                                xv = IIf(Me.c_AutoMedidaEmpaq._RetornarValor(Of String)() Is Nothing, "", Me.c_AutoMedidaEmpaq._RetornarValor(Of String)())
                                If xv <> "" Then
                                    Dim xmedida As New FichaProducto.Prd_Medida
                                    xmedida.F_BuscarMedida(xv)
                                    Return xmedida.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna La Cantidad En Unidades De Inventario Contenida Por El Empaque
                    ''' </summary>
                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Dim xv As Integer = 0
                            xv = IIf(Me.c_ContenidoEmpaque._ContenidoCampo Is Nothing, 0, Me.c_ContenidoEmpaque._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna la Cantidad Registrada Para La Salida Del Kardex
                    ''' </summary>
                    ''' <value></value>
                    ReadOnly Property _CantRequerida() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            xv = IIf(Me.c_CantidadRequeridad._ContenidoCampo Is Nothing, 0, Me.c_CantidadRequeridad._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _Id() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Retorna La Cantidad En Unidades de Inventario Para La Salida Del Kardex
                    ''' </summary>
                    ReadOnly Property _CantUnidadesRequerida() As Integer
                        Get
                            Return Me._CantRequerida * Me._ContenidoEmpaque
                        End Get
                    End Property

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_AutoMedidaEmpaq = New CampoDato("auto_medida_empaq", 10)
                        Me.c_AutoPlato = New CampoDato("auto_plato", 10)
                        Me.c_AutoProducto = New CampoDato("auto_producto", 10)
                        Me.c_CantidadRequeridad = New CampoDato("cantidad")
                        Me.c_ContenidoEmpaque = New CampoDato("contenido_empaq")

                        Me.M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase PLATO INVENTARIO - FASTFOOD" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoMedidaEmpaq._ContenidoCampo = xrow(.c_AutoMedidaEmpaq._NombreCampo)
                                .c_AutoPlato._ContenidoCampo = xrow(.c_AutoPlato._NombreCampo)
                                .c_AutoProducto._ContenidoCampo = xrow(.c_AutoProducto._NombreCampo)
                                .c_CantidadRequeridad._ContenidoCampo = xrow(.c_CantidadRequeridad._NombreCampo)
                                .c_ContenidoEmpaque._ContenidoCampo = xrow(.c_ContenidoEmpaque._NombreCampo)
                                .c_IdSeguridad = xrow("id_seguridad")
                            End With
                        Catch ex As Exception
                            Throw New Exception("PLATO INVENTARIO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const ModificarItemInv As String = "update MenuPlatoInventario set auto_medida_empaq=@auto_medida_empaq, " & _
                "contenido_empaq=@contenido_empaq, cantidad=@cantidad where auto=@auto and id_seguridad=@id"

                Protected Friend Const EliminarItemInv As String = "delete MenuPlatoInventario where auto=@auto and id_seguridad=@id"

                Protected Friend Const InsertItemInv As String = _
                  "INSERT INTO MenuPlatoInventario (" & _
                    "auto," & _
                    "auto_plato," & _
                    "auto_producto," & _
                    "auto_medida_empaq," & _
                    "contenido_empaq," & _
                    "cantidad) " & _
                    "VALUES (" & _
                    "@auto," & _
                    "@auto_plato," & _
                    "@auto_producto," & _
                    "@auto_medida_empaq," & _
                    "@contenido_empaq," & _
                    "@cantidad) "


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
            End Class

        End Class
    End Class
End Namespace


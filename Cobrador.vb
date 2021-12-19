Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL COBRADORES
        ''' </summary>
        Public Class FichaCobradores
            Event CobradorNuevo(ByVal xauto As String)

            ''' <summary>
            ''' Define Los Tipos De Busqueda 
            ''' </summary>
            Public Enum TipoBusqueda As Integer
                PorNombre = 0
                PorRif_CI = 1
                PorCodigo = 2
            End Enum

            ''' <summary>
            ''' Define los Tipos de Comisiones que puede tener un cobrador
            ''' </summary>
            Public Enum TipoComision As Integer
                SinComision = 0
                ComisionGlobal = 1
                ComisionRango = 2
                ComisionPersonalizada = 3
            End Enum

            ''' <summary>
            ''' CLASE FICHA DE COBRADOR
            ''' </summary>
            Public Class c_Cobrador
                Event Actualizar()

                ''' <summary>
                ''' Clase PARA AGREGAR UN NUEVO COBRADOR
                ''' </summary>
                Class c_AgregarCobrador
                    Private xvendedor As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xvendedor
                        End Get
                        Set(ByVal value As c_Registro)
                            xvendedor = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xvendedor.c_CodigoCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Nombre() As String
                        Set(ByVal value As String)
                            xvendedor.c_NombreCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CiRif() As String
                        Set(ByVal value As String)
                            xvendedor.c_CiRif.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Direccion() As String
                        Set(ByVal value As String)
                            xvendedor.c_Direccion.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xvendedor.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xvendedor.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xvendedor.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xvendedor.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_1() As String
                        Set(ByVal value As String)
                            xvendedor.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_2() As String
                        Set(ByVal value As String)
                            xvendedor.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xvendedor.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xvendedor.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xvendedor.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xvendedor.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoComision() As TipoComision
                        Set(ByVal value As TipoComision)
                            Dim x As Integer = CType(value, Integer)

                            xvendedor.c_TipoComision.c_Texto = x.ToString
                        End Set
                    End Property

                    WriteOnly Property _Comision() As Single
                        Set(ByVal value As Single)
                            xvendedor.c_ComisionCobrador.c_Valor = value
                        End Set
                    End Property

                    Sub New()
                        xvendedor = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR UN COBRADOR
                ''' </summary>
                Class c_ModificarCobrador
                    Private xcobrador As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xcobrador
                        End Get
                        Set(ByVal value As c_Registro)
                            xcobrador = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xcobrador.c_CodigoCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Nombre() As String
                        Set(ByVal value As String)
                            xcobrador.c_NombreCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CiRif() As String
                        Set(ByVal value As String)
                            xcobrador.c_CiRif.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Direccion() As String
                        Set(ByVal value As String)
                            xcobrador.c_Direccion.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xcobrador.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xcobrador.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xcobrador.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xcobrador.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_1() As String
                        Set(ByVal value As String)
                            xcobrador.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_2() As String
                        Set(ByVal value As String)
                            xcobrador.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xcobrador.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xcobrador.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xcobrador.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xcobrador.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoComision() As TipoComision
                        Set(ByVal value As TipoComision)
                            Dim x As Integer = CType(value, Integer)

                            xcobrador.c_TipoComision.c_Texto = x.ToString
                        End Set
                    End Property

                    WriteOnly Property _Comision() As Single
                        Set(ByVal value As Single)
                            xcobrador.c_ComisionCobrador.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            xcobrador.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xcobrador.c_IdSeguridad = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xcobrador.r_EstatusCobrador
                        End Get
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcobrador.c_Estatus.c_Texto = "Activo"
                            Else
                                xcobrador.c_Estatus.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property

                    Sub New()
                        xcobrador = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_ci As CampoTexto
                    Private f_direccion As CampoTexto
                    Private f_contacto As CampoTexto
                    Private f_email As CampoTexto
                    Private f_comentarios As CampoTexto
                    Private f_advertencia As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha_alta As CampoFecha

                    Private f_telefono1 As CampoTexto
                    Private f_telefono2 As CampoTexto
                    Private f_celular1 As CampoTexto
                    Private f_celular2 As CampoTexto
                    Private f_fax1 As CampoTexto
                    Private f_fax2 As CampoTexto
                    Private f_tipo_comision As CampoTexto
                    Private f_estatus_foto As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private f_comision As CampoSingle

                    ''' <summary>
                    ''' Campo, Automatico Del Cobrador
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property r_Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Nombre Del Cobrador
                    ''' </summary>
                    Property c_NombreCobrador() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property r_NombreCobrador() As String
                        Get
                            Return Me.c_NombreCobrador.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Codigo Asignado Al Cobrador
                    ''' </summary>
                    Property c_CodigoCobrador() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property r_CodigoCobrador() As String
                        Get
                            Return Me.c_CodigoCobrador.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, CI / RIF 
                    ''' </summary>
                    Property c_CiRif() As CampoTexto
                        Get
                            Return f_ci
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ci = value
                        End Set
                    End Property

                    ReadOnly Property r_CiRif() As String
                        Get
                            Return Me.c_CiRif.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Direccion 
                    ''' </summary>
                    Property c_Direccion() As CampoTexto
                        Get
                            Return f_direccion
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_direccion = value
                        End Set
                    End Property

                    ReadOnly Property r_DireccionCobrador() As String
                        Get
                            Return Me.c_Direccion.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Persona De Contacto
                    ''' </summary>
                    Property c_ContactarA() As CampoTexto
                        Get
                            Return f_contacto
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contacto = value
                        End Set
                    End Property

                    ReadOnly Property r_ContactarA() As String
                        Get
                            Return Me.c_ContactarA.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Email
                    ''' </summary>
                    Property c_Email() As CampoTexto
                        Get
                            Return f_email
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_email = value
                        End Set
                    End Property

                    ReadOnly Property r_Email() As String
                        Get
                            Return Me.c_Email.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Comentarios
                    ''' </summary>
                    Property c_Comentarios() As CampoTexto
                        Get
                            Return f_comentarios
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_comentarios = value
                        End Set
                    End Property

                    ReadOnly Property r_Comentarios() As String
                        Get
                            Return Me.c_Comentarios.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Advertencia
                    ''' </summary>
                    Property c_Advertencia() As CampoTexto
                        Get
                            Return f_advertencia
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_advertencia = value
                        End Set
                    End Property

                    ReadOnly Property r_Advertencia() As String
                        Get
                            Return Me.c_Advertencia.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Del Cobrador
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property r_EstatusCobrador() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Fecha De Creacion Del Cobrador
                    ''' </summary>
                    Protected Friend Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property

                    ReadOnly Property r_FechaCreacion() As Date
                        Get
                            Return Me.c_FechaAlta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono #1 (residencial)
                    ''' </summary>
                    Property c_Telefono_1() As CampoTexto
                        Get
                            Return f_telefono1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_1() As String
                        Get
                            Return Me.c_Telefono_1.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono #2 (residencial)
                    ''' </summary>
                    Property c_Telefono_2() As CampoTexto
                        Get
                            Return f_telefono2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_2() As String
                        Get
                            Return Me.c_Telefono_2.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Celular #1 (movil)
                    ''' </summary>
                    Property c_Celular_1() As CampoTexto
                        Get
                            Return f_celular1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Celular_1() As String
                        Get
                            Return Me.c_Celular_1.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Celular #2 (movil)
                    ''' </summary>
                    Property c_Celular_2() As CampoTexto
                        Get
                            Return f_celular2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Celular_2() As String
                        Get
                            Return Me.c_Celular_2.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fax #1
                    ''' </summary>
                    Property c_Fax_1() As CampoTexto
                        Get
                            Return f_fax1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Fax_1() As String
                        Get
                            Return Me.c_Fax_1.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fax #2
                    ''' </summary>
                    Property c_Fax_2() As CampoTexto
                        Get
                            Return f_fax2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Fax_2() As String
                        Get
                            Return Me.c_Fax_2.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Tipo Comision Asignada
                    ''' </summary>
                    Protected Friend Property c_TipoComision() As CampoTexto
                        Get
                            Return f_tipo_comision
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_comision = value
                        End Set
                    End Property

                    ReadOnly Property r_TipoComisionAsignada() As TipoComision
                        Get
                            Select Case Me.c_TipoComision.c_Texto.Trim.ToUpper
                                Case "0"
                                    Return TipoComision.SinComision
                                Case "1"
                                    Return TipoComision.ComisionGlobal
                                Case "2"
                                    Return TipoComision.ComisionRango
                                Case "3"
                                    Return TipoComision.ComisionPersonalizada
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Foto
                    ''' </summary>
                    Protected Friend Property c_EstatusFoto() As CampoTexto
                        Get
                            Return f_estatus_foto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_foto = value
                        End Set
                    End Property

                    ReadOnly Property r_EstatusFoto() As TipoEstatus
                        Get
                            If Me.c_EstatusFoto.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Id De Seguridad
                    ''' </summary>
                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property r_IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Comsion Asignada Personalizada
                    ''' </summary>
                    Protected Friend Property c_ComisionCobrador() As CampoSingle
                        Get
                            Return f_comision
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_comision = value
                        End Set
                    End Property

                    ReadOnly Property r_ComisionPersonalizada() As Single
                        Get
                            Return Me.c_ComisionCobrador.c_Valor
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_NombreCobrador = New CampoTexto(120, "nombre")
                        Me.c_CodigoCobrador = New CampoTexto(15, "codigo")
                        Me.c_CiRif = New CampoTexto(12, "ci")
                        Me.c_Direccion = New CampoTexto(120, "direccion")
                        Me.c_ContactarA = New CampoTexto(50, "contacto")
                        Me.c_Email = New CampoTexto(50, "email")
                        Me.c_Comentarios = New CampoTexto(60, "comentarios")
                        Me.c_Advertencia = New CampoTexto(60, "advertencia")
                        Me.c_Estatus = New CampoTexto(20, "estatus")
                        Me.c_FechaAlta = New CampoFecha("fecha_alta")
                        Me.c_Telefono_1 = New CampoTexto(14, "telefono1")
                        Me.c_Telefono_2 = New CampoTexto(14, "telefono2")
                        Me.c_Celular_1 = New CampoTexto(14, "celular1")
                        Me.c_Celular_2 = New CampoTexto(14, "celular2")
                        Me.c_Fax_1 = New CampoTexto(14, "fax1")
                        Me.c_Fax_2 = New CampoTexto(14, "fax2")
                        Me.c_TipoComision = New CampoTexto(1, "tipo_comision")
                        Me.c_EstatusFoto = New CampoTexto(1, "estatus_foto")
                        Me.c_ComisionCobrador = New CampoSingle("comision")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()
                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreCobrador.c_Texto = xrow(.c_NombreCobrador.c_NombreInterno)

                                If Not IsDBNull(xrow(.c_CodigoCobrador.c_NombreInterno)) Then
                                    .c_CodigoCobrador.c_Texto = xrow(.c_CodigoCobrador.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_CiRif.c_NombreInterno)) Then
                                    .c_CiRif.c_Texto = xrow(.c_CiRif.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Direccion.c_NombreInterno)) Then
                                    .c_Direccion.c_Texto = xrow(.c_Direccion.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_ContactarA.c_NombreInterno)) Then
                                    .c_ContactarA.c_Texto = xrow(.c_ContactarA.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Email.c_NombreInterno)) Then
                                    .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Comentarios.c_NombreInterno)) Then
                                    .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Advertencia.c_NombreInterno)) Then
                                    .c_Advertencia.c_Texto = xrow(.c_Advertencia.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Estatus.c_NombreInterno)) Then
                                    .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_FechaAlta.c_NombreInterno)) Then
                                    .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Telefono_1.c_NombreInterno)) Then
                                    .c_Telefono_1.c_Texto = xrow(.c_Telefono_1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Telefono_2.c_NombreInterno)) Then
                                    .c_Telefono_2.c_Texto = xrow(.c_Telefono_2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Fax_1.c_NombreInterno)) Then
                                    .c_Fax_1.c_Texto = xrow(.c_Fax_1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Fax_2.c_NombreInterno)) Then
                                    .c_Fax_2.c_Texto = xrow(.c_Fax_2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Celular_1.c_NombreInterno)) Then
                                    .c_Celular_1.c_Texto = xrow(.c_Celular_1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_Celular_2.c_NombreInterno)) Then
                                    .c_Celular_2.c_Texto = xrow(.c_Celular_2.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_TipoComision.c_NombreInterno)) Then
                                    .c_TipoComision.c_Texto = xrow(.c_TipoComision.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_EstatusFoto.c_NombreInterno)) Then
                                    .c_EstatusFoto.c_Texto = xrow(.c_EstatusFoto.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                                If Not IsDBNull(xrow(.c_ComisionCobrador.c_NombreInterno)) Then
                                    .c_ComisionCobrador.c_Valor = xrow(.c_ComisionCobrador.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("COBRADORES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xtipo_busqueda As String() = {"Por Nombre", "Por CI", "Por Codigo"}
                ReadOnly Property p_TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                End Property

                Private xtipo_comision As String() = {"Sin Comision", "Comsion Global Definida", "Por Rangos Definidos", "Personalizada"}
                ReadOnly Property p_TipoComsion() As String()
                    Get
                        Return xtipo_comision
                    End Get
                End Property

                ''' Bucar Vendedor
                Friend Const Select_1 As String = "SELECT * FROM COBRADORES WHERE AUTO=@AUTO"

                Friend Const InsertarVendedor As String = "Insert Into Cobradores (" _
                   + "auto, " _
                   + "nombre, " _
                   + "codigo, " _
                   + "ci, " _
                   + "direccion, " _
                   + "contacto, " _
                   + "email, " _
                   + "comentarios, " _
                   + "advertencia, " _
                   + "estatus, " _
                   + "fecha_alta, " _
                   + "telefono1, " _
                   + "telefono2, " _
                   + "celular1, " _
                   + "celular2, " _
                   + "fax1, " _
                   + "fax2, " _
                   + "tipo_comision, " _
                   + "estatus_foto, " _
                   + "comision) " _
                   + "VALUES (" _
                   + "@auto, " _
                   + "@nombre, " _
                   + "@codigo, " _
                   + "@ci, " _
                   + "@direccion, " _
                   + "@contacto, " _
                   + "@email, " _
                   + "@comentarios, " _
                   + "@advertencia, " _
                   + "@estatus, " _
                   + "@fecha_alta, " _
                   + "@telefono1, " _
                   + "@telefono2, " _
                   + "@celular1, " _
                   + "@celular2, " _
                   + "@fax1, " _
                   + "@fax2, " _
                   + "@tipo_comision, " _
                   + "@estatus_foto, " _
                   + "@comision)"

                Friend Const ModificarCobrador_1 As String = "Update Cobradores set " _
                   + "nombre=@nombre, " _
                   + "codigo=@codigo, " _
                   + "ci=@ci, " _
                   + "direccion=@direccion, " _
                   + "contacto=@contacto, " _
                   + "email=@email, " _
                   + "comentarios=@comentarios, " _
                   + "advertencia=@advertencia, " _
                   + "estatus=@estatus, " _
                   + "telefono1=@telefono1, " _
                   + "telefono2=@telefono2, " _
                   + "celular1=@celular1, " _
                   + "celular2=@celular2, " _
                   + "fax1=@fax1, " _
                   + "fax2=@fax2, " _
                   + "tipo_comision=@tipo_comision, " _
                   + "estatus_foto=@estatus_foto, " _
                   + "comision=@comision " _
                   + "where auto=@auto and id_seguridad=@id_seguridad"

                Private xregistro As c_Registro
                Private xtabla As DataTable

                Sub New()
                    xtabla = New DataTable("COBRADORES")
                    xregistro = New c_Registro
                End Sub

                ''' <summary>
                ''' Tabla A Almacenar Registro
                ''' </summary>
                Protected Friend Property TablaDato() As DataTable
                    Get
                        Return xtabla
                    End Get
                    Set(ByVal value As DataTable)
                        xtabla = value
                    End Set
                End Property

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Protected Friend Sub M_Limpiar_Tabla()
                    xtabla.Rows.Clear()
                End Sub

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

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Private xcobrador As c_Cobrador

            Property f_Cobrador() As c_Cobrador
                Get
                    Return xcobrador
                End Get
                Set(ByVal value As c_Cobrador)
                    xcobrador = value
                End Set
            End Property

            Sub New()
                Me.f_Cobrador = New c_Cobrador
            End Sub

            ''' <summary>
            ''' Funcion: Buscar y Cargar Cobrador En Ficha Registro
            ''' </summary>
            Function F_BuscarCobrador(ByVal xauto As String) As Boolean
                Dim xr As Integer
                Try
                    Me.f_Cobrador.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(c_Cobrador.Select_1, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                        xr = xadap.Fill(Me.f_Cobrador.TablaDato)
                    End Using
                    If xr = 0 Then
                        Throw New Exception("COBRADOR NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                    Else
                        Me.f_Cobrador.M_CargarRegistro(Me.f_Cobrador.TablaDato(0))
                    End If
                    Return True
                Catch ex As Exception
                    Throw New Exception("COBRADOR" + vbCrLf + "BUSCAR COBRADOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Agregar Un Cobrador Nuevo Al Sistema
            ''' </summary>
            Function F_CobradorNuevo(ByVal xcobrador As c_Cobrador.c_AgregarCobrador) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd0 As New SqlCommand("update contadores set a_cobrador=a_cobrador+1;select a_cobrador from contadores")
                Dim xcmd1 As New SqlCommand(c_Cobrador.InsertarVendedor)

                Try
                    With xcmd1
                        xcobrador.d_Registro.c_FechaAlta.c_Valor = Date.Today
                        xcobrador.d_Registro.c_Estatus.c_Texto = "Activo"
                        xcobrador.d_Registro.c_EstatusFoto.c_Texto = "0"

                        .Parameters.AddWithValue("@nombre", xcobrador.d_Registro.c_NombreCobrador.c_Texto).Size = xcobrador.d_Registro.c_NombreCobrador.c_Largo
                        .Parameters.AddWithValue("@codigo", xcobrador.d_Registro.c_CodigoCobrador.c_Texto).Size = xcobrador.d_Registro.c_CodigoCobrador.c_Largo
                        .Parameters.AddWithValue("@ci", xcobrador.d_Registro.c_CiRif.c_Texto).Size = xcobrador.d_Registro.c_CiRif.c_Largo
                        .Parameters.AddWithValue("@direccion", xcobrador.d_Registro.c_Direccion.c_Texto).Size = xcobrador.d_Registro.c_Direccion.c_Largo
                        .Parameters.AddWithValue("@contacto", xcobrador.d_Registro.c_ContactarA.c_Texto).Size = xcobrador.d_Registro.c_ContactarA.c_Largo
                        .Parameters.AddWithValue("@email", xcobrador.d_Registro.c_Email.c_Texto).Size = xcobrador.d_Registro.c_Email.c_Largo
                        .Parameters.AddWithValue("@comentarios", xcobrador.d_Registro.c_Comentarios.c_Texto).Size = xcobrador.d_Registro.c_Comentarios.c_Largo
                        .Parameters.AddWithValue("@advertencia", xcobrador.d_Registro.c_Advertencia.c_Texto).Size = xcobrador.d_Registro.c_Advertencia.c_Largo
                        .Parameters.AddWithValue("@estatus", xcobrador.d_Registro.c_Estatus.c_Texto).Size = xcobrador.d_Registro.c_Estatus.c_Largo
                        .Parameters.AddWithValue("@fecha_alta", xcobrador.d_Registro.c_FechaAlta.c_Valor)
                        .Parameters.AddWithValue("@Telefono1", xcobrador.d_Registro.c_Telefono_1.c_Texto).Size = xcobrador.d_Registro.c_Telefono_1.c_Largo
                        .Parameters.AddWithValue("@Telefono2", xcobrador.d_Registro.c_Telefono_2.c_Texto).Size = xcobrador.d_Registro.c_Telefono_2.c_Largo
                        .Parameters.AddWithValue("@Celular1", xcobrador.d_Registro.c_Celular_1.c_Texto).Size = xcobrador.d_Registro.c_Celular_1.c_Largo
                        .Parameters.AddWithValue("@Celular2", xcobrador.d_Registro.c_Celular_2.c_Texto).Size = xcobrador.d_Registro.c_Celular_2.c_Largo
                        .Parameters.AddWithValue("@Fax1", xcobrador.d_Registro.c_Fax_1.c_Texto).Size = xcobrador.d_Registro.c_Fax_1.c_Largo
                        .Parameters.AddWithValue("@Fax2", xcobrador.d_Registro.c_Fax_2.c_Texto).Size = xcobrador.d_Registro.c_Fax_2.c_Largo
                        .Parameters.AddWithValue("@tipo_comision", xcobrador.d_Registro.c_TipoComision.c_Texto).Size = xcobrador.d_Registro.c_TipoComision.c_Largo
                        .Parameters.AddWithValue("@estatus_foto", xcobrador.d_Registro.c_EstatusFoto.c_Texto).Size = xcobrador.d_Registro.c_EstatusFoto.c_Largo
                        .Parameters.AddWithValue("@comision", xcobrador.d_Registro.c_ComisionCobrador.c_Valor)
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            xtr = xcon.BeginTransaction

                            'CONTADORES
                            Using xcmd0
                                xcmd0.Connection = xcon
                                xcmd0.Transaction = xtr
                                xcobrador.d_Registro.c_Automatico.c_Texto = xcmd0.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                            End Using

                            'GRABO EL COBRADOR
                            Using xcmd1
                                xcmd1.Connection = xcon
                                xcmd1.Transaction = xtr
                                xcmd1.Parameters.AddWithValue("@auto", xcobrador.d_Registro.c_Automatico.c_Texto)
                                xcmd1.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Codigo, Rif o CI Del Cobrador. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent CobradorNuevo(xcobrador.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("COBRADOR" + vbCrLf + "INSERTAR COBRADOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Eliminar Un Cobrador Del Sistema
            ''' </summary>
            Function F_CobradorElimina(ByVal xauto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim EliminarRegistro As String = "delete cobradores where auto=@auto"
                            Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex2 As SqlException
                            If ex2.Number = 547 Then
                                Throw New Exception("ERROR AL ELIMINAR COBRADOR, COBRADOR TIENE MOVIMIENTOS EFECTUADOS")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("COBRADOR" + vbCrLf + "ELIMINAR COBRADOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Modificar Un Cobrador Del Sistema
            ''' </summary>
            Function F_CobradorModifica(ByVal xcobrador As c_Cobrador.c_ModificarCobrador) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd1 As New SqlCommand(c_Cobrador.ModificarCobrador_1)

                Try
                    With xcmd1
                        .Parameters.AddWithValue("@nombre", xcobrador.d_Registro.c_NombreCobrador.c_Texto).Size = xcobrador.d_Registro.c_NombreCobrador.c_Largo
                        .Parameters.AddWithValue("@codigo", xcobrador.d_Registro.c_CodigoCobrador.c_Texto).Size = xcobrador.d_Registro.c_CodigoCobrador.c_Largo
                        .Parameters.AddWithValue("@ci", xcobrador.d_Registro.c_CiRif.c_Texto).Size = xcobrador.d_Registro.c_CiRif.c_Largo
                        .Parameters.AddWithValue("@direccion", xcobrador.d_Registro.c_Direccion.c_Texto).Size = xcobrador.d_Registro.c_Direccion.c_Largo
                        .Parameters.AddWithValue("@contacto", xcobrador.d_Registro.c_ContactarA.c_Texto).Size = xcobrador.d_Registro.c_ContactarA.c_Largo
                        .Parameters.AddWithValue("@email", xcobrador.d_Registro.c_Email.c_Texto).Size = xcobrador.d_Registro.c_Email.c_Largo
                        .Parameters.AddWithValue("@comentarios", xcobrador.d_Registro.c_Comentarios.c_Texto).Size = xcobrador.d_Registro.c_Comentarios.c_Largo
                        .Parameters.AddWithValue("@advertencia", xcobrador.d_Registro.c_Advertencia.c_Texto).Size = xcobrador.d_Registro.c_Advertencia.c_Largo
                        .Parameters.AddWithValue("@estatus", xcobrador.d_Registro.c_Estatus.c_Texto).Size = xcobrador.d_Registro.c_Estatus.c_Largo
                        .Parameters.AddWithValue("@Telefono1", xcobrador.d_Registro.c_Telefono_1.c_Texto).Size = xcobrador.d_Registro.c_Telefono_1.c_Largo
                        .Parameters.AddWithValue("@Telefono2", xcobrador.d_Registro.c_Telefono_2.c_Texto).Size = xcobrador.d_Registro.c_Telefono_2.c_Largo
                        .Parameters.AddWithValue("@Celular1", xcobrador.d_Registro.c_Celular_1.c_Texto).Size = xcobrador.d_Registro.c_Celular_1.c_Largo
                        .Parameters.AddWithValue("@Celular2", xcobrador.d_Registro.c_Celular_2.c_Texto).Size = xcobrador.d_Registro.c_Celular_2.c_Largo
                        .Parameters.AddWithValue("@Fax1", xcobrador.d_Registro.c_Fax_1.c_Texto).Size = xcobrador.d_Registro.c_Fax_1.c_Largo
                        .Parameters.AddWithValue("@Fax2", xcobrador.d_Registro.c_Fax_2.c_Texto).Size = xcobrador.d_Registro.c_Fax_2.c_Largo
                        .Parameters.AddWithValue("@tipo_comision", xcobrador.d_Registro.c_TipoComision.c_Texto).Size = xcobrador.d_Registro.c_TipoComision.c_Largo
                        .Parameters.AddWithValue("@estatus_foto", xcobrador.d_Registro.c_EstatusFoto.c_Texto).Size = xcobrador.d_Registro.c_EstatusFoto.c_Largo
                        .Parameters.AddWithValue("@comision", xcobrador.d_Registro.c_ComisionCobrador.c_Valor)
                        .Parameters.AddWithValue("@id_seguridad", xcobrador.d_Registro.c_IdSeguridad)
                        .Parameters.AddWithValue("@auto", xcobrador.d_Registro.c_Automatico.c_Texto)
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Dim xr As Integer = 0

                            Using xcmd1
                                xcmd1.Transaction = xtr
                                xcmd1.Connection = xcon
                                xr = xcmd1.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("Error Al Actualizar Datos Del Cobrador, Otro Usuario Ya Actualizo Los Datos, Verifique Por Favor")
                                End If
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Codigo, Rif o CI Del Cobrador. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent CobradorNuevo(xcobrador.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("COBRADOR" + vbCrLf + "MODIFICAR COBRADOR" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class

        Private xfichaCobrador As FichaCobradores

        ''' <summary>
        ''' Ficha General Cobradores
        ''' </summary>
        Property f_FichaCobradores() As FichaCobradores
            Get
                Return xfichaCobrador
            End Get
            Set(ByVal value As FichaCobradores)
                xfichaCobrador = value
            End Set
        End Property
    End Class
End Namespace
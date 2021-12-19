Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL VENDEDORES
        ''' </summary>
        Public Class FichaVendedores
            Event VendedorNuevo(ByVal xauto As String)

            ''' <summary>
            ''' Define Los Tipos De Busqueda 
            ''' </summary>
            Public Enum TipoBusquedaVendedor As Integer
                PorNombre = 0
                PorRif_CI = 1
                PorCodigo = 2
            End Enum

            ''' <summary>
            ''' Define los Tipos de Comisiones que puede tener un vendedor
            ''' </summary>
            Public Enum TipoComisionVendedor As Integer
                SinComision = 0
                ComisionGlobal = 1
                ComisionRango = 2
                ComisionPersonalizada = 3
            End Enum

            ''' <summary>
            ''' CLASE FICHA DE VENDEDOR
            ''' </summary>
            Public Class c_Vendedor
                Event Actualizar()

                ''' <summary>
                ''' Clase PARA AGREGAR UN NUEVO VENDEDOR
                ''' </summary>
                Class c_AgregarVendedor
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
                            xvendedor.c_CodigoVendedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Nombre() As String
                        Set(ByVal value As String)
                            xvendedor.c_NombreVendedor.c_Texto = value
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

                    WriteOnly Property _TipoComision() As TipoComisionVendedor
                        Set(ByVal value As TipoComisionVendedor)
                            Dim x As Integer = CType(value, Integer)

                            xvendedor.c_TipoComision.c_Texto = x.ToString
                        End Set
                    End Property

                    WriteOnly Property _Comision() As Single
                        Set(ByVal value As Single)
                            xvendedor.c_ComisionVendedor.c_Valor = value
                        End Set
                    End Property

                    Sub New()
                        xvendedor = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR UN VENDEDOR
                ''' </summary>
                Class c_ModificarVendedor
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
                            xvendedor.c_CodigoVendedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Nombre() As String
                        Set(ByVal value As String)
                            xvendedor.c_NombreVendedor.c_Texto = value
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

                    WriteOnly Property _TipoComision() As TipoComisionVendedor
                        Set(ByVal value As TipoComisionVendedor)
                            Dim x As Integer = CType(value, Integer)

                            xvendedor.c_TipoComision.c_Texto = x.ToString
                        End Set
                    End Property

                    WriteOnly Property _Comision() As Single
                        Set(ByVal value As Single)
                            xvendedor.c_ComisionVendedor.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            xvendedor.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xvendedor.c_IdSeguridad = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xvendedor.r_EstatusVendedor
                        End Get
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xvendedor.c_Estatus.c_Texto = "Activo"
                            Else
                                xvendedor.c_Estatus.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property

                    Sub New()
                        xvendedor = New c_Registro
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
                    Private f_telefono As CampoTexto
                    Private f_email As CampoTexto
                    Private f_comentarios As CampoTexto
                    Private f_advertencia As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha_alta As CampoFecha
                    Private f_website As CampoTexto
                    Private f_ventas_gp As CampoSingle
                    Private f_ventas_1p As CampoSingle
                    Private f_ventas_2p As CampoSingle
                    Private f_ventas_3p As CampoSingle
                    Private f_ventas_4p As CampoSingle
                    Private f_cobro_gp As CampoSingle
                    Private f_cobro_1p As CampoSingle
                    Private f_cobro_2p As CampoSingle
                    Private f_cobro_3p As CampoSingle
                    Private f_cobro_4p As CampoSingle

                    'Campos Nuevos Agregados A La Tabla

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
                    ''' Campo, Automatico Del Vendedor
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
                    ''' Campo, Nombre Del Vendedor
                    ''' </summary>
                    Property c_NombreVendedor() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property r_NombreVendedor() As String
                        Get
                            Return Me.c_NombreVendedor.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Codigo Asignado Al Vendedor
                    ''' </summary>
                    Property c_CodigoVendedor() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property r_CodigoVendedor() As String
                        Get
                            Return Me.c_CodigoVendedor.c_Texto
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

                    ReadOnly Property r_DireccionVendedor() As String
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
                    ''' Campo, Telefono No Usado
                    ''' </summary>
                    Property c_Telefono() As CampoTexto
                        Get
                            Return f_telefono
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono = value
                        End Set
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
                    ''' Campo, Estatus Del Vendedor
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property r_EstatusVendedor() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Fecha De Creacion Del Vendedor
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
                    ''' Campo, WebSite
                    ''' </summary>
                    Property c_WebSite() As CampoTexto
                        Get
                            Return f_website
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_website = value
                        End Set
                    End Property

                    ReadOnly Property r_WebSite() As String
                        Get
                            Return Me.c_WebSite.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, No Usado
                    ''' </summary>
                    Protected Friend Property c_VentasGP() As CampoSingle
                        Get
                            Return f_ventas_gp
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ventas_gp = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, No Usado
                    ''' </summary>
                    Protected Friend Property c_Ventas1P() As CampoSingle
                        Get
                            Return f_ventas_1p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ventas_1p = value
                        End Set
                    End Property

                    Protected Friend Property c_Ventas2P() As CampoSingle
                        Get
                            Return f_ventas_2p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ventas_2p = value
                        End Set
                    End Property

                    Protected Friend Property c_Ventas3P() As CampoSingle
                        Get
                            Return f_ventas_3p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ventas_3p = value
                        End Set
                    End Property

                    Protected Friend Property c_Ventas4P() As CampoSingle
                        Get
                            Return f_ventas_4p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ventas_4p = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, No Usado
                    ''' </summary>
                    Protected Friend Property c_CobroGP() As CampoSingle
                        Get
                            Return f_cobro_gp
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_cobro_gp = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, No Usado
                    ''' </summary>
                    Protected Friend Property c_Cobro1P() As CampoSingle
                        Get
                            Return f_cobro_1p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_cobro_1p = value
                        End Set
                    End Property

                    Protected Friend Property c_Cobro2P() As CampoSingle
                        Get
                            Return f_cobro_2p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_cobro_2p = value
                        End Set
                    End Property

                    Protected Friend Property c_Cobro3P() As CampoSingle
                        Get
                            Return f_cobro_3p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_cobro_3p = value
                        End Set
                    End Property

                    Protected Friend Property c_Cobro4P() As CampoSingle
                        Get
                            Return f_cobro_4p
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_cobro_4p = value
                        End Set
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

                    ReadOnly Property r_TipoComisionAsignada() As TipoComisionVendedor
                        Get
                            Select Case Me.c_TipoComision.c_Texto.Trim.ToUpper
                                Case "0"
                                    Return TipoComisionVendedor.SinComision
                                Case "1"
                                    Return TipoComisionVendedor.ComisionGlobal
                                Case "2"
                                    Return TipoComisionVendedor.ComisionRango
                                Case "3"
                                    Return TipoComisionVendedor.ComisionPersonalizada
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
                    Protected Friend Property c_ComisionVendedor() As CampoSingle
                        Get
                            Return f_comision
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_comision = value
                        End Set
                    End Property

                    ReadOnly Property r_ComisionPersonalizada() As Single
                        Get
                            Return Me.c_ComisionVendedor.c_Valor
                        End Get
                    End Property


                    Sub M_LimpiarRegistro()
                        With Me.c_Automatico
                            .c_Largo = 10
                            .c_NombreInterno = "auto"
                            .c_Texto = ""
                        End With
                        With Me.c_NombreVendedor
                            .c_Largo = 120
                            .c_NombreInterno = "nombre"
                            .c_Texto = ""
                        End With
                        With Me.c_CodigoVendedor
                            .c_Largo = 15
                            .c_NombreInterno = "codigo"
                            .c_Texto = ""
                        End With
                        With Me.c_CiRif
                            .c_Largo = 12
                            .c_NombreInterno = "ci"
                            .c_Texto = ""
                        End With
                        With Me.c_Direccion
                            .c_Largo = 120
                            .c_NombreInterno = "direccion"
                            .c_Texto = ""
                        End With
                        With Me.c_ContactarA
                            .c_Largo = 50
                            .c_NombreInterno = "contacto"
                            .c_Texto = ""
                        End With
                        With Me.c_Telefono
                            .c_Largo = 60
                            .c_NombreInterno = "telefono"
                            .c_Texto = ""
                        End With
                        With Me.c_Email
                            .c_Largo = 50
                            .c_NombreInterno = "email"
                            .c_Texto = ""
                        End With
                        With Me.c_Comentarios
                            .c_Largo = 60
                            .c_NombreInterno = "comentarios"
                            .c_Texto = ""
                        End With
                        With Me.c_Advertencia
                            .c_Largo = 60
                            .c_NombreInterno = "advertencia"
                            .c_Texto = ""
                        End With
                        With Me.c_Estatus
                            .c_Largo = 20
                            .c_NombreInterno = "estatus"
                            .c_Texto = ""
                        End With
                        With Me.c_WebSite
                            .c_Largo = 50
                            .c_Texto = ""
                            .c_NombreInterno = "website"
                        End With
                        With Me.c_FechaAlta
                            .c_Valor = Date.MinValue
                            .c_NombreInterno = "fecha_alta"
                        End With
                        With Me.c_VentasGP
                            .c_Valor = 0
                            .c_NombreInterno = "ventas_gp"
                        End With
                        With Me.c_Ventas1P
                            .c_Valor = 0
                            .c_NombreInterno = "ventas_1p"
                        End With
                        With Me.c_Ventas2P
                            .c_Valor = 0
                            .c_NombreInterno = "ventas_2p"
                        End With
                        With Me.c_Ventas3P
                            .c_Valor = 0
                            .c_NombreInterno = "ventas_3p"
                        End With
                        With Me.c_Ventas4P
                            .c_Valor = 0
                            .c_NombreInterno = "ventas_4p"
                        End With
                        With Me.c_CobroGP
                            .c_Valor = 0
                            .c_NombreInterno = "cobro_gp"
                        End With
                        With Me.c_Cobro1P
                            .c_Valor = 0
                            .c_NombreInterno = "cobro_1p"
                        End With
                        With Me.c_Cobro2P
                            .c_Valor = 0
                            .c_NombreInterno = "cobro_2p"
                        End With
                        With Me.c_Cobro3P
                            .c_Valor = 0
                            .c_NombreInterno = "cobro_3p"
                        End With
                        With Me.c_Cobro4P
                            .c_Valor = 0
                            .c_NombreInterno = "cobro_4p"
                        End With

                        'CAMPOS NUEVOS
                        With Me.c_Telefono_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono1"
                        End With
                        With Me.c_Telefono_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono2"
                        End With
                        With Me.c_Celular_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "celular1"
                        End With
                        With Me.c_Celular_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "celular2"
                        End With
                        With Me.c_Fax_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "fax1"
                        End With
                        With Me.c_Fax_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "fax2"
                        End With
                        With Me.c_TipoComision
                            .c_Largo = 1
                            .c_Texto = ""
                            .c_NombreInterno = "tipo_comision"
                        End With
                        With Me.c_EstatusFoto
                            .c_Largo = 1
                            .c_Texto = ""
                            .c_NombreInterno = "estatus_foto"
                        End With
                        With Me.c_ComisionVendedor
                            .c_Valor = 0
                            .c_NombreInterno = "comision"
                        End With
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto
                        Me.c_NombreVendedor = New CampoTexto
                        Me.c_CodigoVendedor = New CampoTexto
                        Me.c_CiRif = New CampoTexto
                        Me.c_Direccion = New CampoTexto
                        Me.c_ContactarA = New CampoTexto
                        Me.c_Telefono = New CampoTexto
                        Me.c_Email = New CampoTexto
                        Me.c_Comentarios = New CampoTexto
                        Me.c_Advertencia = New CampoTexto
                        Me.c_Estatus = New CampoTexto
                        Me.c_WebSite = New CampoTexto
                        Me.c_FechaAlta = New CampoFecha
                        Me.c_VentasGP = New CampoSingle
                        Me.c_Ventas1P = New CampoSingle
                        Me.c_Ventas2P = New CampoSingle
                        Me.c_Ventas3P = New CampoSingle
                        Me.c_Ventas4P = New CampoSingle
                        Me.c_CobroGP = New CampoSingle
                        Me.c_Cobro1P = New CampoSingle
                        Me.c_Cobro2P = New CampoSingle
                        Me.c_Cobro3P = New CampoSingle
                        Me.c_Cobro4P = New CampoSingle

                        Me.c_Telefono_1 = New CampoTexto
                        Me.c_Telefono_2 = New CampoTexto
                        Me.c_Celular_1 = New CampoTexto
                        Me.c_Celular_2 = New CampoTexto
                        Me.c_Fax_1 = New CampoTexto
                        Me.c_Fax_2 = New CampoTexto
                        Me.c_TipoComision = New CampoTexto
                        Me.c_EstatusFoto = New CampoTexto
                        Me.c_ComisionVendedor = New CampoSingle

                        M_LimpiarRegistro()
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()
                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreVendedor.c_Texto = xrow(.c_NombreVendedor.c_NombreInterno)
                                .c_CodigoVendedor.c_Texto = xrow(.c_CodigoVendedor.c_NombreInterno)
                                .c_CiRif.c_Texto = xrow(.c_CiRif.c_NombreInterno)
                                .c_Direccion.c_Texto = xrow(.c_Direccion.c_NombreInterno)
                                .c_ContactarA.c_Texto = xrow(.c_ContactarA.c_NombreInterno)
                                .c_Telefono.c_Texto = xrow(.c_Telefono.c_NombreInterno)
                                .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                                .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                                .c_Advertencia.c_Texto = xrow(.c_Advertencia.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                                .c_WebSite.c_Texto = xrow(.c_WebSite.c_NombreInterno)
                                .c_VentasGP.c_Valor = xrow(.c_VentasGP.c_NombreInterno)
                                .c_Ventas1P.c_Valor = xrow(.c_Ventas1P.c_NombreInterno)
                                .c_Ventas2P.c_Valor = xrow(.c_Ventas2P.c_NombreInterno)
                                .c_Ventas3P.c_Valor = xrow(.c_Ventas3P.c_NombreInterno)
                                .c_Ventas4P.c_Valor = xrow(.c_Ventas4P.c_NombreInterno)
                                .c_CobroGP.c_Valor = xrow(.c_CobroGP.c_NombreInterno)
                                .c_Cobro1P.c_Valor = xrow(.c_Cobro1P.c_NombreInterno)
                                .c_Cobro2P.c_Valor = xrow(.c_Cobro2P.c_NombreInterno)
                                .c_Cobro3P.c_Valor = xrow(.c_Cobro3P.c_NombreInterno)
                                .c_Cobro4P.c_Valor = xrow(.c_Cobro4P.c_NombreInterno)

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
                                If Not IsDBNull(xrow(.c_ComisionVendedor.c_NombreInterno)) Then
                                    .c_ComisionVendedor.c_Valor = xrow(.c_ComisionVendedor.c_NombreInterno)
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("VENDEDORES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                Friend Const Select_1 As String = "SELECT * FROM VENDEDORES WHERE AUTO=@AUTO"

                Friend Const InsertarVendedor As String = "Insert Into Vendedores (" _
                   + "auto, " _
                   + "nombre, " _
                   + "codigo, " _
                   + "ci, " _
                   + "direccion, " _
                   + "contacto, " _
                   + "telefono, " _
                   + "email, " _
                   + "comentarios, " _
                   + "advertencia, " _
                   + "estatus, " _
                   + "fecha_alta, " _
                   + "website, " _
                   + "ventas_gp, " _
                   + "ventas_1p, " _
                   + "ventas_2p, " _
                   + "ventas_3p, " _
                   + "ventas_4p, " _
                   + "cobro_gp, " _
                   + "cobro_1p, " _
                   + "cobro_2p, " _
                   + "cobro_3p, " _
                   + "cobro_4p, " _
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
                   + "@telefono, " _
                   + "@email, " _
                   + "@comentarios, " _
                   + "@advertencia, " _
                   + "@estatus, " _
                   + "@fecha_alta, " _
                   + "@website, " _
                   + "@ventas_gp, " _
                   + "@ventas_1p, " _
                   + "@ventas_2p, " _
                   + "@ventas_3p, " _
                   + "@ventas_4p, " _
                   + "@cobro_gp, " _
                   + "@cobro_1p, " _
                   + "@cobro_2p, " _
                   + "@cobro_3p, " _
                   + "@cobro_4p, " _
                   + "@telefono1, " _
                   + "@telefono2, " _
                   + "@celular1, " _
                   + "@celular2, " _
                   + "@fax1, " _
                   + "@fax2, " _
                   + "@tipo_comision, " _
                   + "@estatus_foto, " _
                   + "@comision)"

                Friend Const ModificarVendedor_1 As String = "Update Vendedores set " _
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
                    xtabla = New DataTable("VENDEDORES")
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

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            Private xvendedor As c_Vendedor

            Property f_Vendedor() As c_Vendedor
                Get
                    Return xvendedor
                End Get
                Set(ByVal value As c_Vendedor)
                    xvendedor = value
                End Set
            End Property

            Sub New()
                Me.f_Vendedor = New c_Vendedor
            End Sub

            ''' <summary>
            ''' Funcion: Buscar y Cargar Vendedor En Ficha Registro
            ''' </summary>
            Function F_BuscarVendedor(ByVal xauto As String) As Boolean
                Dim xr As Integer
                Try
                    Me.f_Vendedor.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(c_Vendedor.Select_1, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                        xr = xadap.Fill(Me.f_Vendedor.TablaDato)
                    End Using
                    If xr = 0 Then
                        Throw New Exception("VENDEDOR NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                    Else
                        Me.f_Vendedor.M_CargarFicha(Me.f_Vendedor.TablaDato(0))
                    End If
                    Return True
                Catch ex As Exception
                    Throw New Exception("VENDEDORES" + vbCrLf + "BUSCAR VENDEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Agregar Un Vendedor Nuevo Al Sistema
            ''' </summary>
            Function F_VendedorNuevo(ByVal xvendedor As c_Vendedor.c_AgregarVendedor) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd0 As New SqlCommand("update contadores set a_vendedores=a_vendedores+1;select a_vendedores from contadores")
                Dim xcmd1 As New SqlCommand(c_Vendedor.InsertarVendedor)

                Try
                    With xcmd1
                        xvendedor.d_Registro.c_FechaAlta.c_Valor = Date.Today
                        xvendedor.d_Registro.c_Estatus.c_Texto = "Activo"
                        xvendedor.d_Registro.c_EstatusFoto.c_Texto = "0"

                        .Parameters.AddWithValue("@nombre", xvendedor.d_Registro.c_NombreVendedor.c_Texto).Size = xvendedor.d_Registro.c_NombreVendedor.c_Largo
                        .Parameters.AddWithValue("@codigo", xvendedor.d_Registro.c_CodigoVendedor.c_Texto).Size = xvendedor.d_Registro.c_CodigoVendedor.c_Largo
                        .Parameters.AddWithValue("@ci", xvendedor.d_Registro.c_CiRif.c_Texto).Size = xvendedor.d_Registro.c_CiRif.c_Largo
                        .Parameters.AddWithValue("@direccion", xvendedor.d_Registro.c_Direccion.c_Texto).Size = xvendedor.d_Registro.c_Direccion.c_Largo
                        .Parameters.AddWithValue("@contacto", xvendedor.d_Registro.c_ContactarA.c_Texto).Size = xvendedor.d_Registro.c_ContactarA.c_Largo
                        .Parameters.AddWithValue("@telefono", xvendedor.d_Registro.c_Telefono.c_Texto).Size = xvendedor.d_Registro.c_Telefono.c_Largo
                        .Parameters.AddWithValue("@email", xvendedor.d_Registro.c_Email.c_Texto).Size = xvendedor.d_Registro.c_Email.c_Largo
                        .Parameters.AddWithValue("@comentarios", xvendedor.d_Registro.c_Comentarios.c_Texto).Size = xvendedor.d_Registro.c_Comentarios.c_Largo
                        .Parameters.AddWithValue("@advertencia", xvendedor.d_Registro.c_Advertencia.c_Texto).Size = xvendedor.d_Registro.c_Advertencia.c_Largo
                        .Parameters.AddWithValue("@estatus", xvendedor.d_Registro.c_Estatus.c_Texto).Size = xvendedor.d_Registro.c_Estatus.c_Largo
                        .Parameters.AddWithValue("@fecha_alta", xvendedor.d_Registro.c_FechaAlta.c_Valor)
                        .Parameters.AddWithValue("@website", xvendedor.d_Registro.c_WebSite.c_Texto).Size = xvendedor.d_Registro.c_WebSite.c_Largo
                        .Parameters.AddWithValue("@ventas_gp", xvendedor.d_Registro.c_VentasGP.c_Valor)
                        .Parameters.AddWithValue("@ventas_1p", xvendedor.d_Registro.c_Ventas1P.c_Valor)
                        .Parameters.AddWithValue("@ventas_2p", xvendedor.d_Registro.c_Ventas2P.c_Valor)
                        .Parameters.AddWithValue("@ventas_3p", xvendedor.d_Registro.c_Ventas3P.c_Valor)
                        .Parameters.AddWithValue("@ventas_4p", xvendedor.d_Registro.c_Ventas4P.c_Valor)
                        .Parameters.AddWithValue("@cobro_gp", xvendedor.d_Registro.c_CobroGP.c_Valor)
                        .Parameters.AddWithValue("@cobro_1p", xvendedor.d_Registro.c_Cobro1P.c_Valor)
                        .Parameters.AddWithValue("@cobro_2p", xvendedor.d_Registro.c_Cobro2P.c_Valor)
                        .Parameters.AddWithValue("@cobro_3p", xvendedor.d_Registro.c_Cobro3P.c_Valor)
                        .Parameters.AddWithValue("@cobro_4p", xvendedor.d_Registro.c_Cobro4P.c_Valor)
                        .Parameters.AddWithValue("@Telefono1", xvendedor.d_Registro.c_Telefono_1.c_Texto).Size = xvendedor.d_Registro.c_Telefono_1.c_Largo
                        .Parameters.AddWithValue("@Telefono2", xvendedor.d_Registro.c_Telefono_2.c_Texto).Size = xvendedor.d_Registro.c_Telefono_2.c_Largo
                        .Parameters.AddWithValue("@Celular1", xvendedor.d_Registro.c_Celular_1.c_Texto).Size = xvendedor.d_Registro.c_Celular_1.c_Largo
                        .Parameters.AddWithValue("@Celular2", xvendedor.d_Registro.c_Celular_2.c_Texto).Size = xvendedor.d_Registro.c_Celular_2.c_Largo
                        .Parameters.AddWithValue("@Fax1", xvendedor.d_Registro.c_Fax_1.c_Texto).Size = xvendedor.d_Registro.c_Fax_1.c_Largo
                        .Parameters.AddWithValue("@Fax2", xvendedor.d_Registro.c_Fax_2.c_Texto).Size = xvendedor.d_Registro.c_Fax_2.c_Largo
                        .Parameters.AddWithValue("@tipo_comision", xvendedor.d_Registro.c_TipoComision.c_Texto).Size = xvendedor.d_Registro.c_TipoComision.c_Largo
                        .Parameters.AddWithValue("@estatus_foto", xvendedor.d_Registro.c_EstatusFoto.c_Texto).Size = xvendedor.d_Registro.c_EstatusFoto.c_Largo
                        .Parameters.AddWithValue("@comision", xvendedor.d_Registro.c_ComisionVendedor.c_Valor)
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            xtr = xcon.BeginTransaction

                            'CONTADORES
                            Using xcmd0
                                xcmd0.Connection = xcon
                                xcmd0.Transaction = xtr
                                xvendedor.d_Registro.c_Automatico.c_Texto = xcmd0.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                            End Using

                            'GRABO EL PROVEEDOR
                            Using xcmd1
                                xcmd1.Connection = xcon
                                xcmd1.Transaction = xtr
                                xcmd1.Parameters.AddWithValue("@auto", xvendedor.d_Registro.c_Automatico.c_Texto)
                                xcmd1.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Codigo, Rif o CI Del Vendedor. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent VendedorNuevo(xvendedor.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("VENDEDOR" + vbCrLf + "INSERTAR VENDEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Eliminar Un Vendedor Del Sistema
            ''' </summary>
            Function F_VendedorElimina(ByVal xauto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim EliminarRegistro As String = "delete vendedores where auto=@auto"
                            Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex2 As SqlException
                            If ex2.Number = 547 Then
                                Throw New Exception("ERROR AL ELIMINAR VENDEDOR, VENDEDOR TIENE MOVIMIENTOS EFECTUADOS")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("VENDEDOR" + vbCrLf + "ELIMINAR VENDEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Modificar Un Vendedore Del Sistema
            ''' </summary>
            Function F_VendedorModifica(ByVal xvendedor As c_Vendedor.c_ModificarVendedor) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd1 As New SqlCommand(c_Vendedor.ModificarVendedor_1)

                Try
                    With xcmd1
                        .Parameters.AddWithValue("@nombre", xvendedor.d_Registro.c_NombreVendedor.c_Texto).Size = xvendedor.d_Registro.c_NombreVendedor.c_Largo
                        .Parameters.AddWithValue("@codigo", xvendedor.d_Registro.c_CodigoVendedor.c_Texto).Size = xvendedor.d_Registro.c_CodigoVendedor.c_Largo
                        .Parameters.AddWithValue("@ci", xvendedor.d_Registro.c_CiRif.c_Texto).Size = xvendedor.d_Registro.c_CiRif.c_Largo
                        .Parameters.AddWithValue("@direccion", xvendedor.d_Registro.c_Direccion.c_Texto).Size = xvendedor.d_Registro.c_Direccion.c_Largo
                        .Parameters.AddWithValue("@contacto", xvendedor.d_Registro.c_ContactarA.c_Texto).Size = xvendedor.d_Registro.c_ContactarA.c_Largo
                        .Parameters.AddWithValue("@email", xvendedor.d_Registro.c_Email.c_Texto).Size = xvendedor.d_Registro.c_Email.c_Largo
                        .Parameters.AddWithValue("@comentarios", xvendedor.d_Registro.c_Comentarios.c_Texto).Size = xvendedor.d_Registro.c_Comentarios.c_Largo
                        .Parameters.AddWithValue("@advertencia", xvendedor.d_Registro.c_Advertencia.c_Texto).Size = xvendedor.d_Registro.c_Advertencia.c_Largo
                        .Parameters.AddWithValue("@estatus", xvendedor.d_Registro.c_Estatus.c_Texto).Size = xvendedor.d_Registro.c_Estatus.c_Largo
                        .Parameters.AddWithValue("@Telefono1", xvendedor.d_Registro.c_Telefono_1.c_Texto).Size = xvendedor.d_Registro.c_Telefono_1.c_Largo
                        .Parameters.AddWithValue("@Telefono2", xvendedor.d_Registro.c_Telefono_2.c_Texto).Size = xvendedor.d_Registro.c_Telefono_2.c_Largo
                        .Parameters.AddWithValue("@Celular1", xvendedor.d_Registro.c_Celular_1.c_Texto).Size = xvendedor.d_Registro.c_Celular_1.c_Largo
                        .Parameters.AddWithValue("@Celular2", xvendedor.d_Registro.c_Celular_2.c_Texto).Size = xvendedor.d_Registro.c_Celular_2.c_Largo
                        .Parameters.AddWithValue("@Fax1", xvendedor.d_Registro.c_Fax_1.c_Texto).Size = xvendedor.d_Registro.c_Fax_1.c_Largo
                        .Parameters.AddWithValue("@Fax2", xvendedor.d_Registro.c_Fax_2.c_Texto).Size = xvendedor.d_Registro.c_Fax_2.c_Largo
                        .Parameters.AddWithValue("@tipo_comision", xvendedor.d_Registro.c_TipoComision.c_Texto).Size = xvendedor.d_Registro.c_TipoComision.c_Largo
                        .Parameters.AddWithValue("@estatus_foto", xvendedor.d_Registro.c_EstatusFoto.c_Texto).Size = xvendedor.d_Registro.c_EstatusFoto.c_Largo
                        .Parameters.AddWithValue("@comision", xvendedor.d_Registro.c_ComisionVendedor.c_Valor)
                        .Parameters.AddWithValue("@id_seguridad", xvendedor.d_Registro.c_IdSeguridad)
                        .Parameters.AddWithValue("@auto", xvendedor.d_Registro.c_Automatico.c_Texto)
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
                                    Throw New Exception("Error Al Actualizar Datos Del Vendedor, Otro Usuario Ya Actualizo Los Datos, Verifique Por Favor")
                                End If
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Codigo, Rif o CI Del Vendedor. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent VendedorNuevo(xvendedor.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("VENDEDOR" + vbCrLf + "MODIFICAR VENDEDOR" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class

        Private xfichaVendedor As FichaVendedores

        ''' <summary>
        ''' Ficha General Vendedores
        ''' </summary>
        Property f_FichaVendedores() As FichaVendedores
            Get
                Return xfichaVendedor
            End Get
            Set(ByVal value As FichaVendedores)
                xfichaVendedor = value
            End Set
        End Property
    End Class
End Namespace
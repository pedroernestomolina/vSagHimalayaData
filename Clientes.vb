Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL CLIENTES
        ''' </summary>
        Public Class FichaClientes
            Event ClienteNuevo(ByVal xauto As String)
            Event ClienteBasicoModificadoOk(ByVal xauto As String)

            ''' <summary>
            ''' Define Los Tipos De Busqueda 
            ''' </summary>
            Public Enum TipoBusquedaCliente As Integer
                PorNombreRazonSocial = 0
                PorRif_CI = 1
                PorCodigo = 2
            End Enum

            ''' <summary>
            ''' CLASE FICHA DE CLIENTE
            ''' </summary>
            Public Class c_Clientes
                Event Actualizar()

                ''' <summary>
                ''' Clase PARA AGREGAR UN NUEVO CLIENTE
                ''' </summary>
                Class c_AgregarCliente
                    Private xcliente As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xcliente
                        End Get
                        Set(ByVal value As c_Registro)
                            xcliente = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xcliente.c_CodigoCliente.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreRazonSocial() As String
                        Set(ByVal value As String)
                            xcliente.c_NombreRazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RifCi() As String
                        Set(ByVal value As String)
                            xcliente.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirFiscal() As String
                        Set(ByVal value As String)
                            xcliente.c_DirFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirDespacho() As String
                        Set(ByVal value As String)
                            xcliente.c_DirDespacho.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xcliente.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xcliente.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioTarifa() As PrecioTarifa
                        Set(ByVal value As PrecioTarifa)
                            If value = PrecioTarifa.Precio_1 Then
                                xcliente.c_PrecioAsignado.c_Texto = "1"
                            Else
                                xcliente.c_PrecioAsignado.c_Texto = "2"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DscAsignado() As Single
                        Set(ByVal value As Single)
                            xcliente.c_DescuentoAsignado.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ActivarCredito() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                xcliente.c_CreditoHabilitado.c_Texto = "1"
                            Else
                                xcliente.c_CreditoHabilitado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DiasCredito() As Integer
                        Set(ByVal value As Integer)
                            xcliente.c_DiasCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _LimiteCreditoPermitido() As Single
                        Set(ByVal value As Single)
                            xcliente.c_LimiteCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_CXC() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableCXC.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Ingresos() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableIngresos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Anticipos() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableAnticipos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoZona() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoZona.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoVendedor() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoVendedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DenominacionFiscal() As String
                        Set(ByVal value As String)
                            xcliente.c_DenominacionFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionIVA() As Single
                        Set(ByVal value As Single)
                            xcliente.c_RetencionIVA.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionISLR() As Single
                        Set(ByVal value As Single)
                            xcliente.c_RetencionISLR.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xcliente.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xcliente.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _WebSite() As String
                        Set(ByVal value As String)
                            xcliente.c_WebSite.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CantDocCreditoPermitido() As Integer
                        Set(ByVal value As Integer)
                            xcliente.c_DocPendientesPermitido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoEstado() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoEstado.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CargoAsignado() As Single
                        Set(ByVal value As Single)
                            xcliente.c_CargoAsignado.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoCobrador() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Dia1() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia1.c_Texto = "1"
                            Else
                                xcliente.c_Dia1.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia2() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia2.c_Texto = "1"
                            Else
                                xcliente.c_Dia2.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia3() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia3.c_Texto = "1"
                            Else
                                xcliente.c_Dia3.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia4() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia4.c_Texto = "1"
                            Else
                                xcliente.c_Dia4.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia5() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia5.c_Texto = "1"
                            Else
                                xcliente.c_Dia5.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia6() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia6.c_Texto = "1"
                            Else
                                xcliente.c_Dia6.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia7() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia7.c_Texto = "1"
                            Else
                                xcliente.c_Dia7.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Telf_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_3() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_3.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_4() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_4.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusAfiliacion() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_EstatusAfiliado.c_Texto = "1"
                            Else
                                xcliente.c_EstatusAfiliado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _LicorLicenciaNombre() As String
                        Set(ByVal value As String)
                            xcliente.c_LicorLicenciaNombre.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _LicorLicenciaNumero() As String
                        Set(ByVal value As String)
                            xcliente.c_LicorLicenciaNumero.c_Texto = value
                        End Set
                    End Property


                    Sub New()
                        xcliente = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA AGREGAR UN NUEVO CLIENTE
                ''' </summary>
                Class c_AgregarClienteBasico
                    Private xregistro As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    WriteOnly Property _NombreRazonSocial() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_NombreRazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RifCi() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirFiscal() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_DirFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_1() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoZona() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_AutoZona.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoVendedor() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_AutoVendedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoEstado() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_AutoEstado.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoCobrador() As String
                        Set(ByVal value As String)
                            Me.d_Registro.c_AutoCobrador.c_Texto = value
                        End Set
                    End Property

                    Sub New()
                        Me.d_Registro = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR UN CLIENTE BASICO
                ''' </summary>
                Class c_ModificarClienteBasico
                    Private xnombre As String
                    Private xdirfiscal As String
                    Private xcontacto As String
                    Private xtelefono As String
                    Private xcorreo As String
                    Private xficha As FichaClientes.c_Clientes.c_Registro


                    Property _NombreRazonSocial() As String
                        Get
                            Return xnombre.Trim
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _DirFiscal() As String
                        Get
                            Return xdirfiscal.Trim
                        End Get
                        Set(ByVal value As String)
                            xdirfiscal = value
                        End Set
                    End Property

                    Property _PersonaContacto() As String
                        Get
                            Return xcontacto.Trim
                        End Get
                        Set(ByVal value As String)
                            xcontacto = value
                        End Set
                    End Property

                    Property _Telefono_1() As String
                        Get
                            Return xtelefono
                        End Get
                        Set(ByVal value As String)
                            xtelefono = value
                        End Set
                    End Property

                    Property _Email() As String
                        Get
                            Return xcorreo.Trim
                        End Get
                        Set(ByVal value As String)
                            xcorreo = value
                        End Set
                    End Property

                    Property _FichaCliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Return xficha
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            xficha = value
                        End Set
                    End Property

                    Sub New()
                        Me._DirFiscal = ""
                        Me._Email = ""
                        Me._FichaCliente = Nothing
                        Me._NombreRazonSocial = ""
                        Me._PersonaContacto = ""
                        Me._Telefono_1 = ""
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR UN CLIENTE
                ''' </summary>
                Class c_ModificarCliente
                    Private xcliente As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xcliente
                        End Get
                        Set(ByVal value As c_Registro)
                            xcliente = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xcliente.c_CodigoCliente.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreRazonSocial() As String
                        Set(ByVal value As String)
                            xcliente.c_NombreRazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RifCi() As String
                        Set(ByVal value As String)
                            xcliente.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirFiscal() As String
                        Set(ByVal value As String)
                            xcliente.c_DirFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirDespacho() As String
                        Set(ByVal value As String)
                            xcliente.c_DirDespacho.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xcliente.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xcliente.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PrecioTarifa() As PrecioTarifa
                        Set(ByVal value As PrecioTarifa)
                            If value = PrecioTarifa.Precio_1 Then
                                xcliente.c_PrecioAsignado.c_Texto = "1"
                            Else
                                xcliente.c_PrecioAsignado.c_Texto = "2"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DscAsignado() As Single
                        Set(ByVal value As Single)
                            xcliente.c_DescuentoAsignado.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _ActivarCredito() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                xcliente.c_CreditoHabilitado.c_Texto = "1"
                            Else
                                xcliente.c_CreditoHabilitado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DiasCredito() As Integer
                        Set(ByVal value As Integer)
                            xcliente.c_DiasCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _LimiteCreditoPermitido() As Single
                        Set(ByVal value As Single)
                            xcliente.c_LimiteCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_CXC() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableCXC.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Ingresos() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableIngresos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Anticipos() As String
                        Set(ByVal value As String)
                            xcliente.c_ContableAnticipos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoZona() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoZona.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoVendedor() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoVendedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DenominacionFiscal() As String
                        Set(ByVal value As String)
                            xcliente.c_DenominacionFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionIVA() As Single
                        Set(ByVal value As Single)
                            xcliente.c_RetencionIVA.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionISLR() As Single
                        Set(ByVal value As Single)
                            xcliente.c_RetencionISLR.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xcliente.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xcliente.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Get
                            Return xcliente.r_EstatusDelCliente
                        End Get
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Estatus.c_Texto = "Activo"
                            Else
                                xcliente.c_Estatus.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _WebSite() As String
                        Set(ByVal value As String)
                            xcliente.c_WebSite.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CantDocCreditoPermitido() As Integer
                        Set(ByVal value As Integer)
                            xcliente.c_DocPendientesPermitido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoEstado() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoEstado.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CargoAsignado() As Single
                        Set(ByVal value As Single)
                            xcliente.c_CargoAsignado.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoCobrador() As String
                        Set(ByVal value As String)
                            xcliente.c_AutoCobrador.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Dia1() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia1.c_Texto = "1"
                            Else
                                xcliente.c_Dia1.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia2() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia2.c_Texto = "1"
                            Else
                                xcliente.c_Dia2.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia3() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia3.c_Texto = "1"
                            Else
                                xcliente.c_Dia3.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia4() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia4.c_Texto = "1"
                            Else
                                xcliente.c_Dia4.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia5() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia5.c_Texto = "1"
                            Else
                                xcliente.c_Dia5.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia6() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia6.c_Texto = "1"
                            Else
                                xcliente.c_Dia6.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Dia7() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_Dia7.c_Texto = "1"
                            Else
                                xcliente.c_Dia7.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Telf_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_3() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_3.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_4() As String
                        Set(ByVal value As String)
                            xcliente.c_Telefono_4.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xcliente.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xcliente.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusAfiliacion() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcliente.c_EstatusAfiliado.c_Texto = "1"
                            Else
                                xcliente.c_EstatusAfiliado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            xcliente.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xcliente.c_IdSeguridad = value
                        End Set
                    End Property


                    WriteOnly Property _LicorLicenciaNombre() As String
                        Set(ByVal value As String)
                            xcliente.c_LicorLicenciaNombre.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _LicorLicenciaNumero() As String
                        Set(ByVal value As String)
                            xcliente.c_LicorLicenciaNumero.c_Texto = value
                        End Set
                    End Property


                    Sub New()
                        xcliente = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Class c_Registro
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_ci_rif As CampoTexto
                    Private f_dir_fiscal As CampoTexto
                    Private f_dir_despacho As CampoTexto
                    Private f_contacto As CampoTexto
                    Private f_telefono As CampoTexto
                    Private f_email As CampoTexto
                    Private f_tarifa As CampoTexto
                    Private f_descuento As CampoSingle
                    Private f_credito As CampoTexto
                    Private f_dias_credito As CampoInteger
                    Private f_limite_credito As CampoSingle
                    Private f_contable_cxc As CampoTexto
                    Private f_contable_ingresos As CampoTexto
                    Private f_contable_anticipos As CampoTexto
                    Private f_total_debitos As CampoSingle
                    Private f_total_creditos As CampoSingle
                    Private f_total_anticipos As CampoSingle
                    Private f_total_saldo As CampoSingle
                    Private f_credito_disponible As CampoSingle
                    Private f_auto As CampoTexto
                    Private f_auto_grupo As CampoTexto
                    Private f_auto_zona As CampoTexto
                    Private f_auto_vendedor As CampoTexto
                    Private f_denominacion_fiscal As CampoTexto
                    Private f_retencion_iva As CampoSingle
                    Private f_retencion_islr As CampoSingle
                    Private f_comentarios As CampoTexto
                    Private f_advertencia As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha_ult_compra As CampoFecha
                    Private f_fecha_ult_pago As CampoFecha
                    Private f_website As CampoTexto
                    Private f_doc_pendientes As CampoInteger
                    Private f_auto_estado As CampoTexto
                    Private f_fecha_alta As CampoFecha
                    Private f_recargo As CampoSingle
                    Private f_tipo_contribuyente As CampoTexto
                    Private f_puntos As CampoSingle
                    Private f_auto_cobrador As CampoTexto
                    Private f_dia1 As CampoTexto
                    Private f_dia2 As CampoTexto
                    Private f_dia3 As CampoTexto
                    Private f_dia4 As CampoTexto
                    Private f_dia5 As CampoTexto
                    Private f_dia6 As CampoTexto
                    Private f_dia7 As CampoTexto
                    Private f_telefono_1 As CampoTexto
                    Private f_telefono_2 As CampoTexto
                    Private f_telefono_3 As CampoTexto
                    Private f_telefono_4 As CampoTexto
                    Private f_celular_1 As CampoTexto
                    Private f_celular_2 As CampoTexto
                    Private f_fax_1 As CampoTexto
                    Private f_fax_2 As CampoTexto
                    Private f_estatus_afiliado As CampoTexto
                    Private f_fechaemision_afiliado As CampoFecha
                    Private f_estatus_foto As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private f_tiporegistro As CampoTexto
                    Private f_licor_licencia_nombre As CampoTexto
                    Private f_licor_licencia_numero As CampoTexto


                    Property c_LicorLicenciaNombre() As CampoTexto
                        Get
                            Return f_licor_licencia_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_licor_licencia_nombre = value
                        End Set
                    End Property

                    Property c_LicorLicenciaNumero() As CampoTexto
                        Get
                            Return f_licor_licencia_numero
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_licor_licencia_numero = value
                        End Set
                    End Property

                    ReadOnly Property r_LicorLicenciaNombre() As String
                        Get
                            Return Me.c_LicorLicenciaNombre.c_Texto
                        End Get
                    End Property

                    ReadOnly Property r_LicorLicenciaNumero() As String
                        Get
                            Return Me.c_LicorLicenciaNumero.c_Texto
                        End Get
                    End Property



                    ''' <summary>
                    ''' Campo, Codigo Del Cliente
                    ''' </summary>
                    Property c_CodigoCliente() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property r_CodigoCliente() As String
                        Get
                            Return Me.c_CodigoCliente.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Nombre / Razon Social
                    ''' </summary>
                    Property c_NombreRazonSocial() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property r_NombreRazonSocial() As String
                        Get
                            Return Me.c_NombreRazonSocial.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, CI / RIF DEL CLIENTE
                    ''' </summary>
                    Property c_RIF() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    ReadOnly Property r_CiRif() As String
                        Get
                            Return Me.c_RIF.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Direccion Fiscal
                    ''' </summary>
                    Property c_DirFiscal() As CampoTexto
                        Get
                            Return f_dir_fiscal
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_dir_fiscal = value
                        End Set
                    End Property

                    ReadOnly Property r_DirFiscal() As String
                        Get
                            Return Me.c_DirFiscal.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Direccion De Despacho
                    ''' </summary>
                    Property c_DirDespacho() As CampoTexto
                        Get
                            Return f_dir_despacho
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_dir_despacho = value
                        End Set
                    End Property

                    ReadOnly Property r_DirDespacho() As String
                        Get
                            Return Me.c_DirDespacho.c_Texto
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
                    ''' Campo, Telefono
                    ''' </summary>
                    <Obsolete("Usar Telefono 1,2,3,4")> _
                    Property c_Telefono() As CampoTexto
                        Get
                            Return f_telefono
                        End Get
                        Set(ByVal value As CampoTexto)
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
                    ''' Campo, Tipo De Precio Asignado
                    ''' </summary>
                    Protected Friend Property c_PrecioAsignado() As CampoTexto
                        Get
                            Return f_tarifa
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tarifa = value
                        End Set
                    End Property

                    ReadOnly Property r_TipoPrecioFijado() As String
                        Get
                            Return Me.c_PrecioAsignado.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Porcentaje De Descuento Global 
                    ''' </summary>
                    Protected Friend Property c_DescuentoAsignado() As CampoSingle
                        Get
                            Return f_descuento
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_descuento = value
                        End Set
                    End Property

                    ReadOnly Property r_DescuentoGlobal() As Single
                        Get
                            Return Me.c_DescuentoAsignado.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Credito
                    ''' </summary>
                    Protected Friend Property c_CreditoHabilitado() As CampoTexto
                        Get
                            Return f_credito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_credito = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna El Estatus Del Credito
                    ''' </summary>
                    ReadOnly Property r_CreditoHabilitado() As TipoEstatus
                        Get
                            If Me.c_CreditoHabilitado.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Dias De Credito
                    ''' </summary>
                    Protected Friend Property c_DiasCredito() As CampoInteger
                        Get
                            Return f_dias_credito
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_credito = value
                        End Set
                    End Property

                    ReadOnly Property r_DiasCredito() As Integer
                        Get
                            Return Me.c_DiasCredito.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Limite De Credito
                    ''' </summary>
                    Property c_LimiteCredito() As CampoSingle
                        Get
                            Return f_limite_credito
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_limite_credito = value
                        End Set
                    End Property

                    ReadOnly Property r_LimiteCreditoPermitido() As Single
                        Get
                            Return Me.c_LimiteCredito.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cuenta Contable CXC
                    ''' </summary>
                    Property c_ContableCXC() As CampoTexto
                        Get
                            Return f_contable_cxc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_contable_cxc = value
                        End Set
                    End Property

                    ReadOnly Property r_CtaCxC() As String
                        Get
                            Return Me.c_ContableCXC.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cuenta Contable Ingresos
                    ''' </summary>
                    Property c_ContableIngresos() As CampoTexto
                        Get
                            Return f_contable_ingresos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_contable_ingresos = value
                        End Set
                    End Property

                    ReadOnly Property r_CtaIngresos() As String
                        Get
                            Return Me.c_ContableIngresos.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cuenta Contable Anticipos
                    ''' </summary>
                    Property c_ContableAnticipos() As CampoTexto
                        Get
                            Return f_contable_anticipos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_contable_anticipos = value
                        End Set
                    End Property

                    ReadOnly Property r_CtaAnticipos() As String
                        Get
                            Return Me.c_ContableAnticipos.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Total Debitos
                    ''' </summary>
                    Property c_TotalDebitos() As CampoSingle
                        Get
                            Return f_total_debitos
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_total_debitos = value
                        End Set
                    End Property

                    ReadOnly Property r_TotalDebitos() As Single
                        Get
                            Return Me.c_TotalDebitos.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Total Creditos
                    ''' </summary>
                    Property c_TotalCreditos() As CampoSingle
                        Get
                            Return f_total_creditos
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_total_creditos = value
                        End Set
                    End Property

                    ReadOnly Property r_TotalCreditos() As Single
                        Get
                            Return Me.c_TotalCreditos.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Total Anticipos
                    ''' </summary>
                    Property c_TotalAnticipos() As CampoSingle
                        Get
                            Return f_total_anticipos
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_total_anticipos = value
                        End Set
                    End Property

                    ReadOnly Property r_TotalAnticipos() As Single
                        Get
                            Return Me.c_TotalAnticipos.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Total Saldo, Total Creditos - Total Debitos
                    ''' </summary>
                    Property c_TotalSaldo() As CampoSingle
                        Get
                            Return f_total_saldo
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_total_saldo = value
                        End Set
                    End Property

                    ReadOnly Property r_TotalSaldo() As Single
                        Get
                            Return Me.c_TotalSaldo.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Credito Disponible, Total Saldo - Limite Credito
                    ''' </summary>
                    Property c_CreditoDisponible() As CampoSingle
                        Get
                            Return f_credito_disponible
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_credito_disponible = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna El Credito Disponible Del Cliente
                    ''' </summary>
                    ReadOnly Property r_CreditoDisponible() As Single
                        Get
                            Return Me.c_CreditoDisponible.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Cliente
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
                    ''' Funcion: Retorna El Automatico Del Cliente
                    ''' </summary>
                    ReadOnly Property r_Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Grupo
                    ''' </summary>
                    Protected Friend Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
                        End Set
                    End Property

                    ReadOnly Property r_AutoGrupo() As String
                        Get
                            Return Me.c_AutoGrupo.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico De La Zona
                    ''' </summary>
                    Protected Friend Property c_AutoZona() As CampoTexto
                        Get
                            Return f_auto_zona
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_zona = value
                        End Set
                    End Property

                    ReadOnly Property r_AutoZona() As String
                        Get
                            Return Me.c_AutoZona.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Vendedor
                    ''' </summary>
                    Protected Friend Property c_AutoVendedor() As CampoTexto
                        Get
                            Return f_auto_vendedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_vendedor = value
                        End Set
                    End Property

                    ReadOnly Property r_AutoVendedor() As String
                        Get
                            Return Me.c_AutoVendedor.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Denominacion Fiscal
                    ''' </summary>
                    Protected Friend Property c_DenominacionFiscal() As CampoTexto
                        Get
                            Return f_denominacion_fiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_denominacion_fiscal = value
                        End Set
                    End Property

                    ReadOnly Property r_DenominacionFiscal() As String
                        Get
                            Return Me.c_DenominacionFiscal.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Retencion IVA
                    ''' </summary>
                    Protected Friend Property c_RetencionIVA() As CampoSingle
                        Get
                            Return f_retencion_iva
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_retencion_iva = value
                        End Set
                    End Property

                    ReadOnly Property r_RetencionIva() As String
                        Get
                            Return Me.c_RetencionIVA.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Retencion ISLR
                    ''' </summary>
                    Protected Friend Property c_RetencionISLR() As CampoSingle
                        Get
                            Return f_retencion_islr
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_retencion_islr = value
                        End Set
                    End Property

                    ReadOnly Property r_RetencionISLR() As String
                        Get
                            Return Me.c_RetencionISLR.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Comentarios
                    ''' </summary>
                    Property c_Comentarios() As CampoTexto
                        Get
                            Return f_comentarios
                        End Get
                        Set(ByVal value As CampoTexto)
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
                        Set(ByVal value As CampoTexto)
                            f_advertencia = value
                        End Set
                    End Property

                    ReadOnly Property r_Advertencias() As String
                        Get
                            Return Me.c_Advertencia.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Del Cliente
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
                    ''' Funcion: Retorna Estatus Del Cliente
                    ''' </summary>
                    ReadOnly Property r_EstatusDelCliente() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fecha Ultima Compra/Venta
                    ''' </summary>
                    Property c_FechaUltCompra() As CampoFecha
                        Get
                            Return f_fecha_ult_compra
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_ult_compra = value
                        End Set
                    End Property

                    ReadOnly Property r_FechaUltVenta() As Date
                        Get
                            Return Me.c_FechaUltCompra.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fecha Ultima Pago
                    ''' </summary>
                    Property c_FechaUltPago() As CampoFecha
                        Get
                            Return f_fecha_ult_pago
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_ult_pago = value
                        End Set
                    End Property

                    ReadOnly Property r_FechaUltPago() As Date
                        Get
                            Return Me.c_FechaUltPago.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, WebSite
                    ''' </summary>
                    Property c_WebSite() As CampoTexto
                        Get
                            Return f_website
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_website = value
                        End Set
                    End Property

                    ReadOnly Property r_WebSite() As String
                        Get
                            Return Me.c_WebSite.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cantidad Permitida De Documentos Pendientes 
                    ''' </summary>
                    Property c_DocPendientesPermitido() As CampoInteger
                        Get
                            Return f_doc_pendientes
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_doc_pendientes = value
                        End Set
                    End Property

                    ReadOnly Property r_CantDocPendPermitidos() As Integer
                        Get
                            Return Me.c_DocPendientesPermitido.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Estado
                    ''' </summary>
                    Property c_AutoEstado() As CampoTexto
                        Get
                            Return f_auto_estado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_estado = value
                        End Set
                    End Property

                    ReadOnly Property r_AutoEstado() As String
                        Get
                            Return Me.c_AutoEstado.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fecha Alta / Registro Del Cliente
                    ''' </summary>
                    Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property

                    ReadOnly Property r_FechaAltaCreacion() As Date
                        Get
                            Return Me.c_FechaAlta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Porcentaje De Recargo Global
                    ''' </summary>
                    Property c_CargoAsignado() As CampoSingle
                        Get
                            Return f_recargo
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_recargo = value
                        End Set
                    End Property

                    ReadOnly Property r_CargoPorcentaje() As Single
                        Get
                            Return Me.c_CargoAsignado.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Tipo Contribuyente
                    ''' </summary>
                    Protected Friend Property c_TipoContribuyente() As CampoTexto
                        Get
                            Return f_tipo_contribuyente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_contribuyente = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Es / No Contribuyente
                    ''' </summary>
                    ReadOnly Property r_TipoContribuyente() As TipoSiNo
                        Get
                            If Me.c_TipoContribuyente.c_Texto.ToUpper = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Puntos Acumulados
                    ''' </summary>
                    Property c_PuntosAcumulados() As CampoSingle
                        Get
                            Return f_puntos
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_puntos = value
                        End Set
                    End Property

                    ReadOnly Property r_PuntoAcumulados() As Single
                        Get
                            Return Me.c_PuntosAcumulados.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Cobrador
                    ''' </summary>
                    Property c_AutoCobrador() As CampoTexto
                        Get
                            Return f_auto_cobrador
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_cobrador = value
                        End Set
                    End Property

                    ReadOnly Property r_AutoCobrador() As String
                        Get
                            Return Me.c_AutoCobrador.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property r_NombreCobrador() As String
                        Get
                            Dim xobj As Object = Nothing
                            Try
                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Try
                                        Using xcmd As New SqlCommand("select nombre from cobradores where auto=@auto", xcon)
                                            xcmd.Parameters.AddWithValue("@auto", Me.r_AutoCobrador)
                                            xobj = xcmd.ExecuteScalar()
                                            If IsDBNull(xobj) Or xobj Is Nothing Then
                                                Return ""
                                            Else
                                                Return xobj.ToString
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Throw New Exception(ex.Message)
                                    End Try
                                End Using
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return ""
                            End Try
                        End Get
                    End Property

                    ReadOnly Property r_NombreVendedor() As String
                        Get
                            Dim xnom As String = ""
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me.r_AutoVendedor)
                                xnom = F_GetString("select nombre from vendedores where auto=@auto", xp1)
                            Catch ex As Exception
                                xnom = "ERROR"
                            End Try
                            Return xnom
                        End Get
                    End Property

                    ReadOnly Property r_NombreGrupo() As String
                        Get
                            Dim xnom As String = ""
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me.r_AutoGrupo)
                                xnom = F_GetString("select nombre from grupo_cliente where auto=@auto", xp1)
                            Catch ex As Exception
                                xnom = "ERROR"
                            End Try
                            Return xnom
                        End Get
                    End Property

                    ReadOnly Property r_NombreEstado() As String
                        Get
                            Dim xnom As String = ""
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me.r_AutoEstado)
                                xnom = F_GetString("select nombre from estados where auto=@auto", xp1)
                            Catch ex As Exception
                                xnom = "ERROR"
                            End Try
                            Return xnom
                        End Get
                    End Property

                    ReadOnly Property r_NombreZona() As String
                        Get
                            Dim xnom As String = ""
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me.r_AutoZona)
                                xnom = F_GetString("select nombre from zona_cliente where auto=@auto", xp1)
                            Catch ex As Exception
                                xnom = "ERROR"
                            End Try
                            Return xnom
                        End Get
                    End Property


                    ''' <summary>
                    ''' Campo, Cobranza Dia 1
                    ''' </summary>
                    Property c_Dia1() As CampoTexto
                        Get
                            Return f_dia1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 1
                    ''' </summary>
                    ReadOnly Property r_Dia1() As TipoEstatus
                        Get
                            If Me.c_Dia1.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 2
                    ''' </summary>
                    Property c_Dia2() As CampoTexto
                        Get
                            Return f_dia2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 2
                    ''' </summary>
                    ReadOnly Property r_Dia2() As TipoEstatus
                        Get
                            If Me.c_Dia2.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 3
                    ''' </summary>
                    Property c_Dia3() As CampoTexto
                        Get
                            Return f_dia3
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 3
                    ''' </summary>
                    ReadOnly Property r_Dia3() As TipoEstatus
                        Get
                            If Me.c_Dia3.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 4
                    ''' </summary>
                    Property c_Dia4() As CampoTexto
                        Get
                            Return f_dia4
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 4
                    ''' </summary>
                    ReadOnly Property r_Dia4() As TipoEstatus
                        Get
                            If Me.c_Dia4.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 5
                    ''' </summary>
                    Property c_Dia5() As CampoTexto
                        Get
                            Return f_dia5
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia5 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 5
                    ''' </summary>
                    ReadOnly Property r_Dia5() As TipoEstatus
                        Get
                            If Me.c_Dia5.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 6
                    ''' </summary>
                    Property c_Dia6() As CampoTexto
                        Get
                            Return f_dia6
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia6 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 6
                    ''' </summary>
                    ReadOnly Property r_Dia6() As TipoEstatus
                        Get
                            If Me.c_Dia6.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cobranza Dia 7
                    ''' </summary>
                    Property c_Dia7() As CampoTexto
                        Get
                            Return f_dia7
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dia7 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Se Cobra El Dia 7
                    ''' </summary>
                    ReadOnly Property r_Dia7() As TipoEstatus
                        Get
                            If Me.c_Dia7.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono_1
                    ''' </summary>
                    Property c_Telefono_1() As CampoTexto
                        Get
                            Return f_telefono_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_1() As String
                        Get
                            Return Me.c_Telefono_1.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono_2
                    ''' </summary>
                    Property c_Telefono_2() As CampoTexto
                        Get
                            Return f_telefono_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_2() As String
                        Get
                            Return Me.c_Telefono_2.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono_3
                    ''' </summary>
                    Property c_Telefono_3() As CampoTexto
                        Get
                            Return f_telefono_3
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_3 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_3() As String
                        Get
                            Return Me.c_Telefono_3.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono_4
                    ''' </summary>
                    Property c_Telefono_4() As CampoTexto
                        Get
                            Return f_telefono_4
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_4 = value
                        End Set
                    End Property

                    ReadOnly Property r_Telefono_4() As String
                        Get
                            Return Me.c_Telefono_4.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Celular_1
                    ''' </summary>
                    Property c_Celular_1() As CampoTexto
                        Get
                            Return f_celular_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_celular_1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Celular_1() As String
                        Get
                            Return Me.c_Celular_1.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Celular_2
                    ''' </summary>
                    Property c_Celular_2() As CampoTexto
                        Get
                            Return f_celular_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_celular_2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Celular_2() As String
                        Get
                            Return Me.c_Celular_2.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fax_1
                    ''' </summary>
                    Property c_Fax_1() As CampoTexto
                        Get
                            Return f_fax_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_fax_1 = value
                        End Set
                    End Property

                    ReadOnly Property r_Fax_1() As String
                        Get
                            Return Me.c_Fax_1.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fax_2
                    ''' </summary>
                    Property c_Fax_2() As CampoTexto
                        Get
                            Return f_fax_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_fax_2 = value
                        End Set
                    End Property

                    ReadOnly Property r_Fax_2() As String
                        Get
                            Return Me.c_Fax_2.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Afiliado
                    ''' </summary>
                    Protected Friend Property c_EstatusAfiliado() As CampoTexto
                        Get
                            Return f_estatus_afiliado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_afiliado = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Esta Afiliado / No Al Club
                    ''' </summary>
                    ReadOnly Property r_EstatusAfiliado() As TipoEstatus
                        Get
                            If Me.c_EstatusAfiliado.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fecha De Emision Del Afiliado
                    ''' </summary>
                    Property c_FechaEmision_Afiliado() As CampoFecha
                        Get
                            Return f_fechaemision_afiliado
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fechaemision_afiliado = value
                        End Set
                    End Property

                    ReadOnly Property r_FechaAfiliacion() As Date
                        Get
                            Return Me.c_FechaEmision_Afiliado.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Foto / Imagen
                    ''' </summary>
                    Protected Friend Property c_EstatusFoto() As CampoTexto
                        Get
                            Return f_estatus_foto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_foto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Indica Si Existe / No Foto Del Cliente
                    ''' </summary>
                    ReadOnly Property r_EstatusFoto() As TipoEstatus
                        Get
                            If Me.c_EstatusFoto.c_Texto.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Id De Seguridad
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
                    ''' Funcion: Retorna Id Seguridad
                    ''' </summary>
                    ReadOnly Property r_IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Tipo Entrada Cliente
                    ''' </summary>
                    Property c_TipoRegistro() As CampoTexto
                        Get
                            Return f_tiporegistro
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tiporegistro = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Indica el tipo de entrada dada a la ficha
                    ''' </summary>
                    ReadOnly Property r_TipoRegistroFicha() As TipoEntradaCliente
                        Get
                            Select Case Me.c_TipoRegistro.c_Texto.Trim.ToUpper
                                Case "B" : Return TipoEntradaCliente.FichaBasica
                                Case "F" : Return TipoEntradaCliente.FichaRegistro
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna La Cantidad de Documentos Pendientes Hasta La Fecha Del Cliente
                    ''' </summary>
                    ReadOnly Property r_CantidadDocPendientes() As Integer
                        Get
                            Dim xobj As Object
                            Dim xsql_1 As String = "select count(*) from cxc where estatus='0' " _
                              + "and auto_cliente= @auto_cliente and cancelado='0' and tipo_documento not in('PAG','NCF')"
                            Try
                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Try
                                        Using xcmd As New SqlCommand(xsql_1, xcon)
                                            xcmd.Parameters.AddWithValue("@auto_cliente", r_Automatico)
                                            xobj = xcmd.ExecuteScalar()
                                        End Using
                                        If IsDBNull(xobj) Or (xobj Is Nothing) Then
                                            Return 0
                                        Else
                                            Dim xn As Integer = 0
                                            Integer.TryParse(xobj, xn)
                                            Return xn
                                        End If
                                    Catch ex As Exception
                                        Throw New Exception(ex.Message)
                                    End Try
                                End Using
                            Catch ex As Exception
                                Throw New Exception("ERROR AL VERIFICAR LIMITE DOCUMENTOS PENDIENTES DEL CLIENTE" + vbCrLf + ex.Message)
                            End Try
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Advertencia = New CampoTexto(60, "advertencia")
                        Me.c_AutoCobrador = New CampoTexto(10, "auto_cobrador")
                        Me.c_AutoEstado = New CampoTexto(10, "auto_estado")
                        Me.c_AutoGrupo = New CampoTexto(10, "auto_grupo")
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_AutoVendedor = New CampoTexto(10, "auto_vendedor")
                        Me.c_AutoZona = New CampoTexto(10, "auto_zona")
                        Me.c_CargoAsignado = New CampoSingle("recargo")
                        Me.c_Celular_1 = New CampoTexto(14, "celular_1")
                        Me.c_Celular_2 = New CampoTexto(14, "celular_2")
                        Me.c_CodigoCliente = New CampoTexto(15, "codigo")
                        Me.c_Comentarios = New CampoTexto(60, "comentarios")
                        Me.c_ContableAnticipos = New CampoTexto(20, "contable_anticipos")
                        Me.c_ContableCXC = New CampoTexto(20, "contable_cxc")
                        Me.c_ContableIngresos = New CampoTexto(20, "contable_ingresos")
                        Me.c_ContactarA = New CampoTexto(50, "contacto")
                        Me.c_CreditoHabilitado = New CampoTexto(1, "credito")
                        Me.c_CreditoDisponible = New CampoSingle("credito_disponible")
                        Me.c_DenominacionFiscal = New CampoTexto(25, "denominacion_fiscal")
                        Me.c_DescuentoAsignado = New CampoSingle("descuento")
                        Me.c_Dia1 = New CampoTexto(1, "dia1")
                        Me.c_Dia2 = New CampoTexto(1, "dia2")
                        Me.c_Dia3 = New CampoTexto(1, "dia3")
                        Me.c_Dia4 = New CampoTexto(1, "dia4")
                        Me.c_Dia5 = New CampoTexto(1, "dia5")
                        Me.c_Dia6 = New CampoTexto(1, "dia6")
                        Me.c_Dia7 = New CampoTexto(1, "dia7")
                        Me.c_DiasCredito = New CampoInteger("dias_credito")
                        Me.c_DirDespacho = New CampoTexto(120, "dir_despacho")
                        Me.c_DirFiscal = New CampoTexto(120, "dir_fiscal")
                        Me.c_DocPendientesPermitido = New CampoInteger("doc_pendientes")
                        Me.c_Email = New CampoTexto(59, "email")
                        Me.c_Estatus = New CampoTexto(20, "estatus")
                        Me.c_EstatusAfiliado = New CampoTexto(1, "estatus_afiliado")
                        Me.c_EstatusFoto = New CampoTexto(1, "estatus_foto")
                        Me.c_Fax_1 = New CampoTexto(14, "fax_1")
                        Me.c_Fax_2 = New CampoTexto(14, "fax_2")
                        Me.c_FechaAlta = New CampoFecha("fecha_alta")
                        Me.c_FechaEmision_Afiliado = New CampoFecha("fechaemision_afiliado")
                        Me.c_FechaUltCompra = New CampoFecha("fecha_ult_compra")
                        Me.c_FechaUltPago = New CampoFecha("fecha_ult_pago")
                        Me.c_LimiteCredito = New CampoSingle("limite_credito")
                        Me.c_NombreRazonSocial = New CampoTexto(120, "nombre")
                        Me.c_PrecioAsignado = New CampoTexto(1, "tarifa")
                        Me.c_PuntosAcumulados = New CampoSingle("puntos")
                        Me.c_RetencionISLR = New CampoSingle("retencion_islr")
                        Me.c_RetencionIVA = New CampoSingle("retencion_iva")
                        Me.c_RIF = New CampoTexto(12, "ci_rif")
                        Me.c_Telefono = New CampoTexto(60, "telefono")
                        Me.c_Telefono_1 = New CampoTexto(14, "telefono_1")
                        Me.c_Telefono_2 = New CampoTexto(14, "telefono_2")
                        Me.c_Telefono_3 = New CampoTexto(14, "telefono_3")
                        Me.c_Telefono_4 = New CampoTexto(14, "telefono_4")
                        Me.c_TipoContribuyente = New CampoTexto(1, "tipo_contribuyente")
                        Me.c_TotalAnticipos = New CampoSingle("total_anticipos")
                        Me.c_TotalCreditos = New CampoSingle("total_creditos")
                        Me.c_TotalDebitos = New CampoSingle("total_debitos")
                        Me.c_TotalSaldo = New CampoSingle("total_saldo")
                        Me.c_WebSite = New CampoTexto(50, "website")
                        Me.c_TipoRegistro = New CampoTexto(1, "tiporegistro")

                        Me.c_LicorLicenciaNombre = New CampoTexto(120, "licor_licencia_nombre")
                        Me.c_LicorLicenciaNumero = New CampoTexto(30, "licor_licencia_numero")
                        M_LimpiarRegistro()
                    End Sub

                    Function _HabilitarCredito(ByVal xmonto As Decimal) As Boolean
                        If r_EstatusDelCliente = TipoEstatus.Inactivo Then
                            Return False
                        End If
                        If r_CreditoHabilitado = TipoEstatus.Inactivo Then
                            Return False
                        End If
                        If r_CreditoDisponible < xmonto Then
                            Return False
                        End If
                        If r_CantDocPendPermitidos <= r_CantidadDocPendientes Then
                            Return False
                        End If
                        Return True
                    End Function
                End Class

                Private xtipo_busqueda As String() = {"Por Nombre/Razon Social", "Por RIF/CI", "Por Codigo"}
                ReadOnly Property p_TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                End Property

                Private xdenfiscal As String() = {"No Contibuyente", "Contribuyente Formal", "Contribuyente Ordinario", "Gobierno", "Exonerado", "Extranjero/Exportador"}
                ReadOnly Property p_DenominacionFiscal() As String()
                    Get
                        Return xdenfiscal
                    End Get
                End Property

                Private xtipprecio As String() = {"Precio Tipo 1", "Precio Tipo 2"}
                ReadOnly Property p_TipoPrecioAsignado() As String()
                    Get
                        Return xtipprecio
                    End Get
                End Property

                Friend Const Select_1 As String = "select * from clientes where auto=@auto"

                Friend Const InsertarClientes As String = "Insert Into Clientes (" _
                  + "codigo," _
                  + "nombre," _
                  + "ci_rif," _
                  + "dir_fiscal," _
                  + "dir_despacho," _
                  + "contacto," _
                  + "telefono," _
                  + "email," _
                  + "tarifa," _
                  + "descuento," _
                  + "credito," _
                  + "dias_credito," _
                  + "limite_credito," _
                  + "contable_cxc," _
                  + "contable_ingresos," _
                  + "contable_anticipos," _
                  + "total_debitos," _
                  + "total_creditos," _
                  + "total_anticipos," _
                  + "total_saldo," _
                  + "credito_disponible," _
                  + "auto," _
                  + "auto_grupo," _
                  + "auto_zona," _
                  + "auto_vendedor," _
                  + "denominacion_fiscal," _
                  + "retencion_iva," _
                  + "retencion_islr," _
                  + "comentarios," _
                  + "advertencia," _
                  + "estatus," _
                  + "fecha_ult_compra," _
                  + "fecha_ult_pago," _
                  + "website," _
                  + "doc_pendientes," _
                  + "auto_estado," _
                  + "fecha_alta," _
                  + "recargo," _
                  + "tipo_contribuyente," _
                  + "puntos," _
                  + "auto_cobrador," _
                  + "dia1," _
                  + "dia2," _
                  + "dia3," _
                  + "dia4," _
                  + "dia5," _
                  + "dia6," _
                  + "dia7," _
                  + "Telefono_1," _
                  + "Telefono_2," _
                  + "Telefono_3," _
                  + "Telefono_4," _
                  + "Celular_1," _
                  + "Celular_2," _
                  + "Fax_1," _
                  + "Fax_2," _
                  + "Estatus_Afiliado," _
                  + "FechaEmision_Afiliado," _
                  + "tiporegistro," _
                  + "Estatus_Foto) " _
                  + "VALUES (" _
                  + "@codigo," _
                  + "@nombre," _
                  + "@ci_rif," _
                  + "@dir_fiscal," _
                  + "@dir_despacho," _
                  + "@contacto," _
                  + "@telefono," _
                  + "@email," _
                  + "@tarifa," _
                  + "@descuento," _
                  + "@credito," _
                  + "@dias_credito," _
                  + "@limite_credito," _
                  + "@contable_cxc," _
                  + "@contable_ingresos," _
                  + "@contable_anticipos," _
                  + "@total_debitos," _
                  + "@total_creditos," _
                  + "@total_anticipos," _
                  + "@total_saldo," _
                  + "@credito_disponible," _
                  + "@auto," _
                  + "@auto_grupo," _
                  + "@auto_zona," _
                  + "@auto_vendedor," _
                  + "@denominacion_fiscal," _
                  + "@retencion_iva," _
                  + "@retencion_islr," _
                  + "@comentarios," _
                  + "@advertencia," _
                  + "@estatus," _
                  + "@fecha_ult_compra," _
                  + "@fecha_ult_pago," _
                  + "@website," _
                  + "@doc_pendientes," _
                  + "@auto_estado," _
                  + "@fecha_alta," _
                  + "@recargo," _
                  + "@tipo_contribuyente," _
                  + "@puntos," _
                  + "@auto_cobrador," _
                  + "@dia1," _
                  + "@dia2," _
                  + "@dia3," _
                  + "@dia4," _
                  + "@dia5," _
                  + "@dia6," _
                  + "@dia7," _
                  + "@Telefono_1," _
                  + "@Telefono_2," _
                  + "@Telefono_3," _
                  + "@Telefono_4," _
                  + "@Celular_1," _
                  + "@Celular_2," _
                  + "@Fax_1," _
                  + "@Fax_2," _
                  + "@Estatus_Afiliado," _
                  + "@FechaEmision_Afiliado," _
                  + "@tiporegistro," _
                  + "@Estatus_Foto) "

                Friend Const InsertarClientesMayor As String = "Insert Into Clientes (" _
                                  + "codigo," _
                                  + "nombre," _
                                  + "ci_rif," _
                                  + "dir_fiscal," _
                                  + "dir_despacho," _
                                  + "contacto," _
                                  + "telefono," _
                                  + "email," _
                                  + "tarifa," _
                                  + "descuento," _
                                  + "credito," _
                                  + "dias_credito," _
                                  + "limite_credito," _
                                  + "contable_cxc," _
                                  + "contable_ingresos," _
                                  + "contable_anticipos," _
                                  + "total_debitos," _
                                  + "total_creditos," _
                                  + "total_anticipos," _
                                  + "total_saldo," _
                                  + "credito_disponible," _
                                  + "auto," _
                                  + "auto_grupo," _
                                  + "auto_zona," _
                                  + "auto_vendedor," _
                                  + "denominacion_fiscal," _
                                  + "retencion_iva," _
                                  + "retencion_islr," _
                                  + "comentarios," _
                                  + "advertencia," _
                                  + "estatus," _
                                  + "fecha_ult_compra," _
                                  + "fecha_ult_pago," _
                                  + "website," _
                                  + "doc_pendientes," _
                                  + "auto_estado," _
                                  + "fecha_alta," _
                                  + "recargo," _
                                  + "tipo_contribuyente," _
                                  + "puntos," _
                                  + "auto_cobrador," _
                                  + "dia1," _
                                  + "dia2," _
                                  + "dia3," _
                                  + "dia4," _
                                  + "dia5," _
                                  + "dia6," _
                                  + "dia7," _
                                  + "Telefono_1," _
                                  + "Telefono_2," _
                                  + "Telefono_3," _
                                  + "Telefono_4," _
                                  + "Celular_1," _
                                  + "Celular_2," _
                                  + "Fax_1," _
                                  + "Fax_2," _
                                  + "Estatus_Afiliado," _
                                  + "FechaEmision_Afiliado," _
                                  + "tiporegistro," _
                                  + "Estatus_Foto, licor_licencia_nombre, licor_licencia_numero) " _
                                  + "VALUES (" _
                                  + "@codigo," _
                                  + "@nombre," _
                                  + "@ci_rif," _
                                  + "@dir_fiscal," _
                                  + "@dir_despacho," _
                                  + "@contacto," _
                                  + "@telefono," _
                                  + "@email," _
                                  + "@tarifa," _
                                  + "@descuento," _
                                  + "@credito," _
                                  + "@dias_credito," _
                                  + "@limite_credito," _
                                  + "@contable_cxc," _
                                  + "@contable_ingresos," _
                                  + "@contable_anticipos," _
                                  + "@total_debitos," _
                                  + "@total_creditos," _
                                  + "@total_anticipos," _
                                  + "@total_saldo," _
                                  + "@credito_disponible," _
                                  + "@auto," _
                                  + "@auto_grupo," _
                                  + "@auto_zona," _
                                  + "@auto_vendedor," _
                                  + "@denominacion_fiscal," _
                                  + "@retencion_iva," _
                                  + "@retencion_islr," _
                                  + "@comentarios," _
                                  + "@advertencia," _
                                  + "@estatus," _
                                  + "@fecha_ult_compra," _
                                  + "@fecha_ult_pago," _
                                  + "@website," _
                                  + "@doc_pendientes," _
                                  + "@auto_estado," _
                                  + "@fecha_alta," _
                                  + "@recargo," _
                                  + "@tipo_contribuyente," _
                                  + "@puntos," _
                                  + "@auto_cobrador," _
                                  + "@dia1," _
                                  + "@dia2," _
                                  + "@dia3," _
                                  + "@dia4," _
                                  + "@dia5," _
                                  + "@dia6," _
                                  + "@dia7," _
                                  + "@Telefono_1," _
                                  + "@Telefono_2," _
                                  + "@Telefono_3," _
                                  + "@Telefono_4," _
                                  + "@Celular_1," _
                                  + "@Celular_2," _
                                  + "@Fax_1," _
                                  + "@Fax_2," _
                                  + "@Estatus_Afiliado," _
                                  + "@FechaEmision_Afiliado," _
                                  + "@tiporegistro," _
                                  + "@Estatus_Foto, @licor_licencia_nombre, @licor_licencia_numero) "


                Friend Const ModificarCliente_1 As String = "Update Clientes set " _
                  + "codigo=@CODIGO," _
                  + "nombre=@NOMBRE," _
                  + "ci_rif=@ci_rif," _
                  + "dir_fiscal=@DIR_FISCAL," _
                  + "dir_despacho=@DIR_DESPACHO," _
                  + "contacto=@CONTACTO," _
                  + "telefono=@TELEFONO," _
                  + "email=@EMAIL," _
                  + "tarifa=@TARIFA," _
                  + "descuento=@DESCUENTO," _
                  + "credito=@CREDITO," _
                  + "dias_credito=@dias_credito," _
                  + "limite_credito=@limite_credito," _
                  + "contable_cxc=@contable_cxc," _
                  + "contable_ingresos=@contable_ingresos," _
                  + "contable_anticipos=@contable_anticipos," _
                  + "auto_grupo=@auto_grupo," _
                  + "auto_zona=@auto_zona," _
                  + "auto_vendedor=@auto_vendedor," _
                  + "denominacion_fiscal=@denominacion_fiscal," _
                  + "retencion_iva=@retencion_iva," _
                  + "retencion_islr=@retencion_islr," _
                  + "comentarios=@comentarios," _
                  + "advertencia=@advertencia," _
                  + "estatus=@estatus," _
                  + "website=@website," _
                  + "doc_pendientes=@doc_pendientes," _
                  + "auto_estado=@auto_estado," _
                  + "recargo=@recargo," _
                  + "tipo_contribuyente=@tipo_contribuyente," _
                  + "auto_cobrador=@auto_cobrador," _
                  + "dia1=@dia1," _
                  + "dia2=@dia2," _
                  + "dia3=@dia3," _
                  + "dia4=@dia4," _
                  + "dia5=@dia5," _
                  + "dia6=@dia6," _
                  + "dia7=@dia7," _
                  + "telefono_1=@telefono_1," _
                  + "telefono_2=@telefono_2," _
                  + "telefono_3=@telefono_3," _
                  + "telefono_4=@telefono_4," _
                  + "celular_1=@celular_1," _
                  + "celular_2=@celular_2," _
                  + "fax_1=@fax_1," _
                  + "fax_2=@fax_2," _
                  + "estatus_afiliado=@estatus_afiliado," _
                  + "fechaemision_afiliado=@fechaemision_afiliado, " _
                  + "licor_licencia_nombre=@licor_licencia_nombre, " _
                  + "licor_licencia_numero=@licor_licencia_numero " _
                  + "WHERE AUTO=@AUTO and id_seguridad=@id_seguridad"

                Friend Const ModificarCliente_2 As String = "Update Clientes set " _
                  + "credito_disponible = (Limite_credito-Total_saldo) " _
                  + "WHERE AUTO=@AUTO"

                Private xregistro As c_Registro
                Private xtabla As DataTable

                Sub New()
                    xtabla = New DataTable("CLIENTES")
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

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.M_LimpiarRegistro()
                        With Me.RegistroDato
                            .c_Advertencia.c_Texto = xrow(.c_Advertencia.c_NombreInterno)
                            .c_AutoCobrador.c_Texto = xrow(.c_AutoCobrador.c_NombreInterno)
                            .c_AutoEstado.c_Texto = xrow(.c_AutoEstado.c_NombreInterno)
                            .c_AutoGrupo.c_Texto = xrow(.c_AutoGrupo.c_NombreInterno)
                            .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                            .c_AutoVendedor.c_Texto = xrow(.c_AutoVendedor.c_NombreInterno)
                            .c_AutoZona.c_Texto = xrow(.c_AutoZona.c_NombreInterno)
                            .c_CargoAsignado.c_Valor = xrow(.c_CargoAsignado.c_NombreInterno)
                            .c_CodigoCliente.c_Texto = xrow(.c_CodigoCliente.c_NombreInterno)
                            .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                            .c_ContableAnticipos.c_Texto = xrow(.c_ContableAnticipos.c_NombreInterno)
                            .c_ContableCXC.c_Texto = xrow(.c_ContableCXC.c_NombreInterno)
                            .c_ContableIngresos.c_Texto = xrow(.c_ContableIngresos.c_NombreInterno)
                            .c_ContactarA.c_Texto = xrow(.c_ContactarA.c_NombreInterno)
                            .c_CreditoDisponible.c_Valor = xrow(.c_CreditoDisponible.c_NombreInterno)
                            .c_CreditoHabilitado.c_Texto = xrow(.c_CreditoHabilitado.c_NombreInterno)
                            .c_DenominacionFiscal.c_Texto = xrow(.c_DenominacionFiscal.c_NombreInterno)
                            .c_DescuentoAsignado.c_Valor = xrow(.c_DescuentoAsignado.c_NombreInterno)
                            .c_Dia1.c_Texto = xrow(.c_Dia1.c_NombreInterno)
                            .c_Dia2.c_Texto = xrow(.c_Dia2.c_NombreInterno)
                            .c_Dia3.c_Texto = xrow(.c_Dia3.c_NombreInterno)
                            .c_Dia4.c_Texto = xrow(.c_Dia4.c_NombreInterno)
                            .c_Dia5.c_Texto = xrow(.c_Dia5.c_NombreInterno)
                            .c_Dia6.c_Texto = xrow(.c_Dia6.c_NombreInterno)
                            .c_Dia7.c_Texto = xrow(.c_Dia7.c_NombreInterno)
                            .c_DiasCredito.c_Valor = xrow(.c_DiasCredito.c_NombreInterno)
                            .c_DirDespacho.c_Texto = xrow(.c_DirDespacho.c_NombreInterno)
                            .c_DirFiscal.c_Texto = xrow(.c_DirFiscal.c_NombreInterno)
                            .c_DocPendientesPermitido.c_Valor = xrow(.c_DocPendientesPermitido.c_NombreInterno)
                            .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                            .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                            .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                            .c_FechaUltCompra.c_Valor = xrow(.c_FechaUltCompra.c_NombreInterno)
                            .c_FechaUltPago.c_Valor = xrow(.c_FechaUltPago.c_NombreInterno)
                            .c_LimiteCredito.c_Valor = xrow(.c_LimiteCredito.c_NombreInterno)
                            .c_NombreRazonSocial.c_Texto = xrow(.c_NombreRazonSocial.c_NombreInterno)
                            .c_PrecioAsignado.c_Texto = xrow(.c_PrecioAsignado.c_NombreInterno)
                            .c_PuntosAcumulados.c_Valor = xrow(.c_PuntosAcumulados.c_NombreInterno)
                            .c_RetencionISLR.c_Valor = xrow(.c_RetencionISLR.c_NombreInterno)
                            .c_RetencionIVA.c_Valor = xrow(.c_RetencionIVA.c_NombreInterno)
                            .c_RIF.c_Texto = xrow(.c_RIF.c_NombreInterno)
                            .c_Telefono.c_Texto = xrow(.c_Telefono.c_NombreInterno)

                            If Not IsDBNull(xrow(.c_Telefono_1.c_NombreInterno)) Then
                                .c_Telefono_1.c_Texto = xrow(.c_Telefono_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Telefono_2.c_NombreInterno)) Then
                                .c_Telefono_2.c_Texto = xrow(.c_Telefono_2.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Telefono_3.c_NombreInterno)) Then
                                .c_Telefono_3.c_Texto = xrow(.c_Telefono_3.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Telefono_4.c_NombreInterno)) Then
                                .c_Telefono_4.c_Texto = xrow(.c_Telefono_4.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Celular_1.c_NombreInterno)) Then
                                .c_Celular_1.c_Texto = xrow(.c_Celular_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Celular_2.c_NombreInterno)) Then
                                .c_Celular_2.c_Texto = xrow(.c_Celular_2.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Fax_1.c_NombreInterno)) Then
                                .c_Fax_1.c_Texto = xrow(.c_Fax_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_Fax_2.c_NombreInterno)) Then
                                .c_Fax_2.c_Texto = xrow(.c_Fax_2.c_NombreInterno)
                            End If

                            If Not IsDBNull(xrow(.c_EstatusAfiliado.c_NombreInterno)) Then
                                .c_EstatusAfiliado.c_Texto = xrow(.c_EstatusAfiliado.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_EstatusFoto.c_NombreInterno)) Then
                                .c_EstatusFoto.c_Texto = xrow(.c_EstatusFoto.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_FechaEmision_Afiliado.c_NombreInterno)) Then
                                .c_FechaEmision_Afiliado.c_Valor = xrow(.c_FechaEmision_Afiliado.c_NombreInterno)
                            End If

                            If Not IsDBNull(xrow(.c_TipoRegistro.c_NombreInterno)) Then
                                .c_TipoRegistro.c_Texto = xrow(.c_TipoRegistro.c_NombreInterno)
                            End If

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                .c_IdSeguridad = xrow("id_seguridad")
                            End If

                            .c_TipoContribuyente.c_Texto = xrow(.c_TipoContribuyente.c_NombreInterno)
                            .c_TotalAnticipos.c_Valor = xrow(.c_TotalAnticipos.c_NombreInterno)
                            .c_TotalCreditos.c_Valor = xrow(.c_TotalCreditos.c_NombreInterno)
                            .c_TotalDebitos.c_Valor = xrow(.c_TotalDebitos.c_NombreInterno)
                            .c_TotalSaldo.c_Valor = xrow(.c_TotalSaldo.c_NombreInterno)
                            .c_WebSite.c_Texto = xrow(.c_WebSite.c_NombreInterno)

                            If Not IsDBNull(xrow(.c_LicorLicenciaNombre.c_NombreInterno)) Then
                                .c_LicorLicenciaNombre.c_Texto = xrow(.c_LicorLicenciaNombre.c_NombreInterno)
                            End If
                            If Not IsDBNull(xrow(.c_LicorLicenciaNumero.c_NombreInterno)) Then
                                .c_LicorLicenciaNumero.c_Texto = xrow(.c_LicorLicenciaNumero.c_NombreInterno)
                            End If

                        End With
                    Catch ex As Exception
                        Throw New Exception("CLIENTES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                ''' <summary>
                ''' Funcion: Buscar y Cargar Cliente En Ficha Registro
                ''' </summary>
                Function F_BuscarCargar(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Dim xr As Integer

                        Using xadap As New SqlDataAdapter(c_Clientes.Select_1, _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xr = xadap.Fill(xtb)
                        End Using
                        If xr = 0 Then
                            Throw New Exception("CLIENTE NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                        Else
                            Me.M_CargarFicha(xtb(0))
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("CLIENTES" + vbCrLf + "BUSCAR CLIENTE" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE FICHA DE GRUPO CLIENTE
            ''' </summary>
            Public Class c_Grupos
                Event Actualizar()

                Public Class c_ModificarGrupo
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    ''' <summary>
                    ''' PARA USO INTERNO 
                    ''' </summary>
                    Protected Friend ReadOnly Property c_GrupoModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                    End Property

                    ''' <summary>
                    ''' Nombre Del Grupo A Modificar
                    ''' </summary>
                    WriteOnly Property c_NombreGrupo() As String
                        Set(ByVal value As String)
                            xreg.c_NombreGrupo.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Del Grupo A Modificar
                    ''' </summary>
                    WriteOnly Property c_AutomaticoGrupo() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Id De Seguridad
                    ''' </summary>
                    WriteOnly Property c_IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Public Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo, Automatico Del Grupo
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
                    ''' Campo, Nombre Del Grupo
                    ''' </summary>
                    Property c_NombreGrupo() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Id Seguridad
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
                    ''' Funcion: Retorna El ID De Seguridad Aisgnado
                    ''' </summary>
                    ReadOnly Property r_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna El Automatico Del Grupo
                    ''' </summary>
                    ReadOnly Property r_Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        With c_Automatico
                            .c_Largo = 10
                            .c_NombreInterno = "auto"
                            .c_Texto = ""
                        End With

                        With c_NombreGrupo
                            .c_Largo = 50
                            .c_NombreInterno = "nombre"
                            .c_Texto = ""
                        End With
                    End Sub

                    Sub New()
                        c_Automatico = New CampoTexto
                        c_NombreGrupo = New CampoTexto

                        M_LimpiarRegistro()
                    End Sub
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

                Private Const AgregarRegistro_1 As String = "update contadores set a_grupo_cliente=a_grupo_cliente+1; select a_grupo_cliente from contadores"
                Private Const AgregarRegistro_2 As String = "insert into grupo_cliente (auto,nombre) values (@auto,@nombre)"
                Private Const ModificarRegistro_1 As String = "update grupo_cliente set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const EliminarRegistro As String = "delete grupo_cliente where auto=@auto"

                Sub New()
                    RegistroDato = New c_Registro
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.M_LimpiarRegistro()
                        With Me.RegistroDato
                            .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                            .c_NombreGrupo.c_Texto = xrow(.c_NombreGrupo.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                .c_IdSeguridad = xrow("id_seguridad")
                            End If
                        End With
                    Catch ex As Exception
                        Throw New Exception("GRUPO CLIENTES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Funcion: Permite Eliminar Un Registro De la BD
                ''' </summary>
                Function F_EliminaGrupo(ByVal xautomatico As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xautomatico)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR GRUPO, EXISTEN CLIENTES DENTRO DE ESTE GRUPO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRUPO CLIENTES" + vbCrLf + "ELIMINAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Agregar Un Registro A La BD
                ''' </summary>
                Function F_NuevoGrupo(ByVal xnombre As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xauto As String = ""
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand(AgregarRegistro_1, xcon, xtr)
                                    xauto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@nombre", xnombre)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL AGREGAR GRUPO, EXISTE UN GRUPO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRUPO CLIENTES" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Modificar Un Registro De La BD
                ''' </summary>
                Function F_ModificaGrupo(ByVal xgrupomod As c_ModificarGrupo) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(ModificarRegistro_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_GrupoModificar.c_Automatico.c_Texto)
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_GrupoModificar.c_NombreGrupo.c_Texto)
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_GrupoModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR GRUPO, GRUPO HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR GRUPO, EXISTE UN GRUPO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRUPO CLIENTES" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE FICHA ZONA 
            ''' </summary>
            Public Class c_Zonas
                Event Actualizar()

                ''' <summary>
                ''' Clase Registro Agregar Zona
                ''' </summary>
                Public Class c_AgregarZona
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    ''' <summary>
                    ''' Nombre Zona A Agregar
                    ''' </summary>
                    WriteOnly Property c_NombreZona() As String
                        Set(ByVal value As String)
                            xreg.c_NombreZona.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Autmatico Estado A Ser Asignada
                    ''' </summary>
                    WriteOnly Property c_AutomaticoEstado() As String
                        Set(ByVal value As String)
                            xreg.c_AutomaticoEstado.c_Texto = value
                        End Set
                    End Property

                    Protected Friend Property c_ZonaRegistrar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase Registro Modificar Zona
                ''' </summary>
                Public Class c_ModificarZona
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    ''' <summary>
                    ''' Nombre Zona A Actualizar
                    ''' </summary>
                    WriteOnly Property c_NombreZona() As String
                        Set(ByVal value As String)
                            xreg.c_NombreZona.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Autmatico Zona A Actualizar
                    ''' </summary>
                    WriteOnly Property c_AutomaticoZona() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Id Seguridad Zona A Actualizar
                    ''' </summary>
                    WriteOnly Property c_IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property

                    Protected Friend Property c_ZonaRegistrar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Public Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_auto_estado As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo, Automatico Zona
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
                    ''' Campo, Nombre Zona
                    ''' </summary>
                    Property c_NombreZona() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Estado
                    ''' </summary>
                    Property c_AutomaticoEstado() As CampoTexto
                        Get
                            Return f_auto_estado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_estado = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Id Seguridad
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
                    ''' Funcion: Retorna El ID De Seguridad Aisgnado
                    ''' </summary>
                    ReadOnly Property r_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                    End Property

                    ReadOnly Property r_Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property r_AutoEstado() As String
                        Get
                            Return Me.c_AutomaticoEstado.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property r_NombreZona() As String
                        Get
                            Return Me.c_NombreZona.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Automatico = New CampoTexto(10, "auto")
                        c_NombreZona = New CampoTexto(50, "nombre")
                        c_AutomaticoEstado = New CampoTexto(10, "auto_estado")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreZona.c_Texto = xrow(.c_NombreZona.c_NombreInterno)
                                .c_AutomaticoEstado.c_Texto = xrow(.c_AutomaticoEstado.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("ZONA CLIENTES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
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

                Private Const AgregarRegistro_1 As String = "update contadores set a_zona_cliente=a_zona_cliente+1;select a_zona_cliente from contadores"
                Private Const AgregarRegistro_2 As String = "insert into zona_cliente (auto,nombre,auto_estado) values (@auto,@nombre,@auto_estado)"
                Private Const ModificarRegistro_1 As String = "update zona_cliente set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const EliminarRegistro As String = "delete from zona_cliente where auto=@auto"

                Sub New()
                    RegistroDato = New c_Registro
                End Sub

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

                ''' <summary>
                '''  Funcion: Permite Agregar Una Nueva Zona A La BD
                ''' </summary>
                Function F_NuevaZona(ByVal xzona As c_AgregarZona) As Boolean
                    Dim xpar1 As SqlParameter
                    Dim xpar2 As SqlParameter
                    Dim xpar3 As SqlParameter
                    Dim xtr As SqlTransaction = Nothing

                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand(AgregarRegistro_1, xcon, xtr)
                                    xzona.c_ZonaRegistrar.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xcmd.Parameters.Clear()

                                    xpar1 = New SqlParameter("@auto", xzona.c_ZonaRegistrar.c_Automatico.c_Texto)
                                    xpar2 = New SqlParameter("@nombre", xzona.c_ZonaRegistrar.c_NombreZona.c_Texto)
                                    xpar3 = New SqlParameter("@auto_estado", xzona.c_ZonaRegistrar.c_AutomaticoEstado.c_Texto)
                                    xcmd.CommandText = AgregarRegistro_2
                                    xcmd.Parameters.Add(xpar1)
                                    xcmd.Parameters.Add(xpar2)
                                    xcmd.Parameters.Add(xpar3)
                                    xcmd.ExecuteNonQuery()

                                    xtr.Commit()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL AGREGAR ZONA, EXISTE UNA ZONA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ZONA CLIENTES" + vbCrLf + "AGREGAR ZONA" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Eliminar Una Zona De La BD
                ''' </summary>
                Function F_EliminarZona(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception("ZONA NO PUEDE SER ELIMINADA, HAY CLIENTES CONTENIDO EN ESTA ZONA")
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ZONA CLIENTES" + vbCrLf + "ELIMINAR ZONA" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Modificar Una Zona De La BD
                ''' </summary>
                Function F_ModificarZona(ByVal xzona As c_ModificarZona) As Boolean
                    Dim xpar1 As SqlParameter
                    Dim xpar2 As SqlParameter
                    Dim xpar3 As SqlParameter
                    Dim xc As Integer = 0
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand(ModificarRegistro_1, xcon)
                                    xpar1 = New SqlParameter("@auto", xzona.c_ZonaRegistrar.c_Automatico.c_Texto)
                                    xpar2 = New SqlParameter("@nombre", xzona.c_ZonaRegistrar.c_NombreZona.c_Texto)
                                    xpar3 = New SqlParameter("@id_seguridad", xzona.c_ZonaRegistrar.c_IdSeguridad)
                                    xcmd.Parameters.Add(xpar1)
                                    xcmd.Parameters.Add(xpar2)
                                    xcmd.Parameters.Add(xpar3)
                                    xc = xcmd.ExecuteNonQuery()
                                End Using
                                If xc = 0 Then
                                    Throw New Exception("ERROR AL ACTUALIZAR ZONA, REGISTRO YA FUE MODIFICADO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR ZONA, EXISTE UNA ZONA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ZONA CLIENTES" + vbCrLf + "MODIFICAR ZONA" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Private xcliente As c_Clientes
            Private xgrupo As c_Grupos
            Private xzona As c_Zonas

            Property f_Clientes() As c_Clientes
                Get
                    Return xcliente
                End Get
                Set(ByVal value As c_Clientes)
                    xcliente = value
                End Set
            End Property

            Property f_Grupos() As c_Grupos
                Get
                    Return xgrupo
                End Get
                Set(ByVal value As c_Grupos)
                    xgrupo = value
                End Set
            End Property

            Property f_Zonas() As c_Zonas
                Get
                    Return xzona
                End Get
                Set(ByVal value As c_Zonas)
                    xzona = value
                End Set
            End Property

            Sub New()
                Me.f_Clientes = New c_Clientes
                Me.f_Grupos = New c_Grupos
                Me.f_Zonas = New c_Zonas
            End Sub

            ''' <summary>
            ''' Funcion: Buscar y Cargar Cliente En Ficha Registro
            ''' </summary>
            Function F_BuscarCliente(ByVal xauto As String) As Boolean
                Dim xr As Integer
                Try
                    Me.f_Clientes.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(c_Clientes.Select_1, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                        xr = xadap.Fill(Me.f_Clientes.TablaDato)
                    End Using
                    If xr = 0 Then
                        Throw New Exception("CLIENTE NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                    Else
                        Me.f_Clientes.M_CargarFicha(Me.f_Clientes.TablaDato.Rows(0))
                    End If
                    Return True
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "BUSCAR CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function


            Public Class Factura
                Private _facturaNro As String
                Private _fechaEmision As Date
                Private _monto As Decimal
                Private _dias As Integer
                Private _cantidad As Decimal


                Property FacturaNro() As String
                    Get
                        Return _facturaNro
                    End Get
                    Set(ByVal value As String)
                        _facturaNro = value
                    End Set
                End Property

                Property FechaEmision() As Date
                    Get
                        Return _fechaEmision
                    End Get
                    Set(ByVal value As Date)
                        _fechaEmision = value
                    End Set
                End Property

                Property Monto() As Decimal
                    Get
                        Return _monto
                    End Get
                    Set(ByVal value As Decimal)
                        _monto = value
                    End Set
                End Property

                Property DiasTranscurridos() As Integer
                    Get
                        Return _dias
                    End Get
                    Set(ByVal value As Integer)
                        _dias = value
                    End Set
                End Property

                Property Cantidad() As Decimal
                    Get
                        Return _cantidad
                    End Get
                    Set(ByVal value As Decimal)
                        _cantidad = value
                    End Set
                End Property


                Sub New()
                    With Me
                        .FacturaNro = ""
                        .FechaEmision = Now
                        .Monto = 0
                        .DiasTranscurridos = 0
                        .Cantidad = 0
                    End With
                End Sub
            End Class

            Function F_BuscarUltimasVentas(ByVal autoC As String, ByVal autoP As String) As List(Of Factura)
                Dim resul As New List(Of Factura)
                Dim dt As New DataTable

                Try
                    Dim fecha As Date = Now

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("select getdate()", xcon)
                                fecha = xcmd.ExecuteScalar
                            End Using
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using

                    Dim sql As String = "Select TOP 10 v.auto ,v.documento,v.fecha ,v.total, vd.cantidad  from ventas_detalle as vd join ventas as v " & _
                                        "on vd.auto_documento=v.auto where V.auto_entidad='" + autoC + "' and  vd.auto_productos ='" + autoP + "' and (v.tipo='01' OR v.tipo='XX') and v.estatus='0' order by fecha desc, auto DESC"
                    Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                        xadap.SelectCommand.CommandText = sql
                        xadap.Fill(dt)
                    End Using
                    For Each r In dt.Rows
                        Dim reg = New Factura
                        With reg
                            .FacturaNro = r(1)
                            .FechaEmision = r(2)
                            .Monto = r(3)
                            .DiasTranscurridos = DateDiff(DateInterval.Day, r(2), fecha)
                            .Cantidad = r(4)
                        End With
                        resul.Add(reg)
                    Next

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

                Return resul
            End Function

            Private Function GrabarCliente(ByVal xcliente As c_Clientes.c_Registro) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd0 As New SqlCommand("update contadores set a_clientes=a_clientes+1;select a_clientes from contadores")
                Dim xcmd1 As New SqlCommand(c_Clientes.InsertarClientesMayor)

                Try
                    With xcmd1
                        .Parameters.AddWithValue("@codigo", xcliente.c_CodigoCliente.c_Texto)
                        .Parameters.AddWithValue("@nombre", xcliente.c_NombreRazonSocial.c_Texto)
                        .Parameters.AddWithValue("@ci_rif", xcliente.c_RIF.c_Texto)
                        .Parameters.AddWithValue("@dir_fiscal", xcliente.c_DirFiscal.c_Texto)
                        .Parameters.AddWithValue("@dir_despacho", xcliente.c_DirDespacho.c_Texto)
                        .Parameters.AddWithValue("@contacto", xcliente.c_ContactarA.c_Texto)
                        .Parameters.AddWithValue("@telefono", xcliente.c_Telefono.c_Texto)
                        .Parameters.AddWithValue("@email", xcliente.c_Email.c_Texto)
                        .Parameters.AddWithValue("@tarifa", xcliente.c_PrecioAsignado.c_Texto)
                        .Parameters.AddWithValue("@descuento", xcliente.c_DescuentoAsignado.c_Valor)
                        .Parameters.AddWithValue("@credito", xcliente.c_CreditoHabilitado.c_Texto)
                        .Parameters.AddWithValue("@dias_credito", xcliente.c_DiasCredito.c_Valor)
                        .Parameters.AddWithValue("@limite_credito", xcliente.c_LimiteCredito.c_Valor)
                        .Parameters.AddWithValue("@contable_cxc", xcliente.c_ContableCXC.c_Texto)
                        .Parameters.AddWithValue("@contable_ingresos", xcliente.c_ContableIngresos.c_Texto)
                        .Parameters.AddWithValue("@contable_anticipos", xcliente.c_ContableAnticipos.c_Texto)
                        .Parameters.AddWithValue("@total_debitos", xcliente.c_TotalDebitos.c_Valor)
                        .Parameters.AddWithValue("@total_creditos", xcliente.c_TotalCreditos.c_Valor)
                        .Parameters.AddWithValue("@total_anticipos", xcliente.c_TotalAnticipos.c_Valor)
                        .Parameters.AddWithValue("@total_saldo", xcliente.c_TotalSaldo.c_Valor)
                        .Parameters.AddWithValue("@credito_disponible", xcliente.c_CreditoDisponible.c_Valor)
                        .Parameters.AddWithValue("@auto_grupo", xcliente.c_AutoGrupo.c_Texto)
                        .Parameters.AddWithValue("@auto_zona", xcliente.c_AutoZona.c_Texto)
                        .Parameters.AddWithValue("@auto_vendedor", xcliente.c_AutoVendedor.c_Texto)
                        .Parameters.AddWithValue("@denominacion_fiscal", xcliente.c_DenominacionFiscal.c_Texto)
                        .Parameters.AddWithValue("@retencion_iva", xcliente.c_RetencionIVA.c_Valor)
                        .Parameters.AddWithValue("@retencion_islr", xcliente.c_RetencionISLR.c_Valor)
                        .Parameters.AddWithValue("@comentarios", xcliente.c_Comentarios.c_Texto)
                        .Parameters.AddWithValue("@advertencia", xcliente.c_Advertencia.c_Texto)
                        .Parameters.AddWithValue("@estatus", xcliente.c_Estatus.c_Texto)
                        .Parameters.AddWithValue("@fecha_ult_compra", xcliente.c_FechaUltCompra.c_Valor)
                        .Parameters.AddWithValue("@fecha_ult_pago", xcliente.c_FechaUltPago.c_Valor)
                        .Parameters.AddWithValue("@website", xcliente.c_WebSite.c_Texto)
                        .Parameters.AddWithValue("@doc_pendientes", xcliente.c_DocPendientesPermitido.c_Valor)
                        .Parameters.AddWithValue("@auto_estado", xcliente.c_AutoEstado.c_Texto)
                        .Parameters.AddWithValue("@fecha_alta", xcliente.c_FechaAlta.c_Valor)
                        .Parameters.AddWithValue("@recargo", xcliente.c_CargoAsignado.c_Valor)
                        .Parameters.AddWithValue("@tipo_contribuyente", xcliente.c_TipoContribuyente.c_Texto)
                        .Parameters.AddWithValue("@puntos", xcliente.c_PuntosAcumulados.c_Valor)
                        .Parameters.AddWithValue("@auto_cobrador", xcliente.c_AutoCobrador.c_Texto)
                        .Parameters.AddWithValue("@dia1", xcliente.c_Dia1.c_Texto)
                        .Parameters.AddWithValue("@dia2", xcliente.c_Dia2.c_Texto)
                        .Parameters.AddWithValue("@dia3", xcliente.c_Dia3.c_Texto)
                        .Parameters.AddWithValue("@dia4", xcliente.c_Dia4.c_Texto)
                        .Parameters.AddWithValue("@dia5", xcliente.c_Dia5.c_Texto)
                        .Parameters.AddWithValue("@dia6", xcliente.c_Dia6.c_Texto)
                        .Parameters.AddWithValue("@dia7", xcliente.c_Dia7.c_Texto)
                        .Parameters.AddWithValue("@Telefono_1", xcliente.c_Telefono_1.c_Texto)
                        .Parameters.AddWithValue("@Telefono_2", xcliente.c_Telefono_2.c_Texto)
                        .Parameters.AddWithValue("@Telefono_3", xcliente.c_Telefono_3.c_Texto)
                        .Parameters.AddWithValue("@Telefono_4", xcliente.c_Telefono_4.c_Texto)
                        .Parameters.AddWithValue("@Celular_1", xcliente.c_Celular_1.c_Texto)
                        .Parameters.AddWithValue("@Celular_2", xcliente.c_Celular_2.c_Texto)
                        .Parameters.AddWithValue("@Fax_1", xcliente.c_Fax_1.c_Texto)
                        .Parameters.AddWithValue("@Fax_2", xcliente.c_Fax_2.c_Texto)
                        .Parameters.AddWithValue("@Estatus_Afiliado", xcliente.c_EstatusAfiliado.c_Texto)
                        .Parameters.AddWithValue("@FechaEmision_Afiliado", IIf(xcliente.c_FechaEmision_Afiliado.c_Valor = Date.MinValue, DBNull.Value, xcliente.c_FechaEmision_Afiliado.c_Valor))
                        .Parameters.AddWithValue("@Estatus_Foto", xcliente.c_EstatusFoto.c_Texto)
                        .Parameters.AddWithValue("@tiporegistro", xcliente.c_TipoRegistro.c_Texto)
                        .Parameters.AddWithValue("@licor_licencia_nombre", xcliente.c_LicorLicenciaNombre.c_Texto)
                        .Parameters.AddWithValue("@licor_licencia_numero", xcliente.c_LicorLicenciaNumero.c_Texto)
                    End With

                    If xcliente.c_AutoCobrador.c_Texto.Trim = "" Then
                        Throw New Exception("ERROR AL GRABAR CLIENTE... COBRADOR NO ASIGNADO")
                    End If
                    If xcliente.c_AutoEstado.c_Texto.Trim = "" Then
                        Throw New Exception("ERROR AL GRABAR CLIENTE... ESTADO NO ASIGNADO")
                    End If
                    If xcliente.c_AutoGrupo.c_Texto.Trim = "" Then
                        Throw New Exception("ERROR AL GRABAR CLIENTE... GRUPO NO ASIGNADO")
                    End If
                    If xcliente.c_AutoVendedor.c_Texto.Trim = "" Then
                        Throw New Exception("ERROR AL GRABAR CLIENTE... VENDEDOR NO ASIGNADO")
                    End If
                    If xcliente.c_AutoZona.c_Texto.Trim = "" Then
                        Throw New Exception("ERROR AL GRABAR CLIENTE... ZONA NO ASIGNADA")
                    End If

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            xtr = xcon.BeginTransaction

                            'CONTADORES
                            Using xcmd0
                                xcmd0.Connection = xcon
                                xcmd0.Transaction = xtr
                                xcliente.c_Automatico.c_Texto = xcmd0.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                            End Using

                            'GRABO EL CLIENTE
                            Using xcmd1
                                xcmd1.Connection = xcon
                                xcmd1.Transaction = xtr
                                xcmd1.Parameters.AddWithValue("@auto", xcliente.c_Automatico.c_Texto)
                                xcmd1.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Nombre, Codigo, Rif o CI Del Cliente. Ya Registrado, Verifique Por Favor")
                            ElseIf ex2.Number = 547 Then
                                Throw New Exception("Al Parecer El Cobrador / Vendedor / Grupo / Estado / Zona  Asignado Al Cliente Fue Eliminado Por Otro Usuario, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent ClienteNuevo(xcliente.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "INSERTAR CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Agregar Un Cliente Nuevo Al Sistema
            ''' </summary>
            Function F_ClienteNuevo(ByVal xcliente As c_Clientes.c_AgregarCliente) As Boolean
                Try
                    Dim xreg As c_Clientes.c_Registro = xcliente.d_Registro
                    With xreg
                        .c_FechaAlta.c_Valor = Date.Today
                        .c_FechaUltPago.c_Valor = Date.Today
                        .c_FechaUltCompra.c_Valor = Date.Today
                        .c_Estatus.c_Texto = "Activo"
                        .c_TotalAnticipos.c_Valor = 0
                        .c_TotalCreditos.c_Valor = 0
                        .c_TotalDebitos.c_Valor = 0
                        .c_TotalSaldo.c_Valor = 0
                        .c_PuntosAcumulados.c_Valor = 0
                        .c_EstatusFoto.c_Texto = "0"

                        If .r_CreditoHabilitado Then
                            .c_CreditoDisponible.c_Valor = .c_LimiteCredito.c_Valor
                        Else
                            .c_CreditoDisponible.c_Valor = 0
                        End If

                        If .c_RIF.c_Texto.Length = 12 Then
                            .c_TipoContribuyente.c_Texto = "1"
                        Else
                            .c_TipoContribuyente.c_Texto = "0"
                        End If

                        If .r_EstatusAfiliado = TipoEstatus.Activo Then
                            .c_FechaEmision_Afiliado.c_Valor = Date.Today
                        Else
                            .c_FechaEmision_Afiliado.c_Valor = Date.MinValue
                        End If

                        .c_TipoRegistro.c_Texto = "F"
                    End With
                    Return GrabarCliente(xreg)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Agregar Un Cliente Nuevo Al Sistema Con Datos Basicos
            ''' </summary>
            Function F_ClienteNuevoBasico(ByVal xcliente_basico As c_Clientes.c_AgregarClienteBasico) As Boolean
                Try
                    Dim xcli As c_Clientes.c_Registro = xcliente_basico.d_Registro
                    With xcli
                        .c_CodigoCliente.c_Texto = ""
                        .c_DirDespacho.c_Texto = ""
                        .c_Comentarios.c_Texto = ""
                        .c_PrecioAsignado.c_Texto = "1"
                        .c_DescuentoAsignado.c_Valor = 0
                        .c_CreditoHabilitado.c_Texto = "0"
                        .c_DiasCredito.c_Valor = 0
                        .c_LimiteCredito.c_Valor = 0
                        .c_ContableCXC.c_Texto = ""
                        .c_ContableIngresos.c_Texto = ""
                        .c_ContableAnticipos.c_Texto = ""
                        .c_RetencionIVA.c_Valor = 0
                        .c_RetencionISLR.c_Valor = 0
                        .c_Advertencia.c_Texto = ""
                        .c_WebSite.c_Texto = ""
                        .c_DocPendientesPermitido.c_Valor = 0
                        .c_CargoAsignado.c_Valor = 0
                        .c_Dia1.c_Texto = ""
                        .c_Dia2.c_Texto = ""
                        .c_Dia3.c_Texto = ""
                        .c_Dia4.c_Texto = ""
                        .c_Dia5.c_Texto = ""
                        .c_Dia6.c_Texto = ""
                        .c_Dia7.c_Texto = ""
                        .c_Telefono_2.c_Texto = ""
                        .c_Telefono_3.c_Texto = ""
                        .c_Telefono_4.c_Texto = ""
                        .c_Celular_1.c_Texto = ""
                        .c_Celular_2.c_Texto = ""
                        .c_Fax_1.c_Texto = ""
                        .c_Fax_2.c_Texto = ""
                        .c_EstatusAfiliado.c_Texto = "0"

                        .c_FechaAlta.c_Valor = Date.Today
                        .c_FechaUltPago.c_Valor = Date.Today
                        .c_FechaUltCompra.c_Valor = Date.Today
                        .c_Estatus.c_Texto = "Activo"
                        .c_TotalAnticipos.c_Valor = 0
                        .c_TotalCreditos.c_Valor = 0
                        .c_TotalDebitos.c_Valor = 0
                        .c_TotalSaldo.c_Valor = 0
                        .c_PuntosAcumulados.c_Valor = 0
                        .c_EstatusFoto.c_Texto = "0"

                        If .r_CreditoHabilitado Then
                            .c_CreditoDisponible.c_Valor = .c_LimiteCredito.c_Valor
                        Else
                            .c_CreditoDisponible.c_Valor = 0
                        End If

                        If .c_RIF.c_Texto.Length = 12 Then
                            .c_TipoContribuyente.c_Texto = "1"
                            xcli.c_DenominacionFiscal.c_Texto = "Contribuyente Ordinario"
                        Else
                            .c_TipoContribuyente.c_Texto = "0"
                            xcli.c_DenominacionFiscal.c_Texto = "No Contribuyente"
                        End If

                        If .r_EstatusAfiliado = TipoEstatus.Activo Then
                            .c_FechaEmision_Afiliado.c_Valor = Date.Today
                        Else
                            .c_FechaEmision_Afiliado.c_Valor = Date.MinValue
                        End If

                        .c_TipoRegistro.c_Texto = "B"
                    End With
                    Return GrabarCliente(xcli)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Eliminar Un Cliente Nuevo Del Sistema
            ''' </summary>
            Function F_ClienteElimina(ByVal xauto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim EliminarRegistro As String = "delete clientes where auto=@auto"
                            Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex2 As SqlException
                            If ex2.Number = 547 Then
                                Throw New Exception("ERROR AL ELIMINAR CLIENTE, CLIENTE TIENE MOVIMIENTOS EFECTUADOS")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("CLIENTE" + vbCrLf + "ELIMINAR CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Modificar Un Cliente Del Sistema
            ''' </summary>
            Function F_ClienteModifica(ByVal xcliente As c_Clientes.c_ModificarCliente) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd1 As New SqlCommand(c_Clientes.ModificarCliente_1)

                Try
                    With xcmd1
                        If xcliente.d_Registro.c_RIF.c_Texto.Length = 12 Then
                            xcliente.d_Registro.c_TipoContribuyente.c_Texto = "1"
                        Else
                            xcliente.d_Registro.c_TipoContribuyente.c_Texto = "0"
                        End If

                        If xcliente.d_Registro.c_EstatusAfiliado.c_Texto = "1" Then
                            If xcliente.d_Registro.c_FechaEmision_Afiliado.c_Valor = Date.MinValue Then
                                xcliente.d_Registro.c_FechaEmision_Afiliado.c_Valor = Date.Today
                            End If
                        End If

                        .Parameters.AddWithValue("@codigo", xcliente.d_Registro.c_CodigoCliente.c_Texto)
                        .Parameters.AddWithValue("@nombre", xcliente.d_Registro.c_NombreRazonSocial.c_Texto)
                        .Parameters.AddWithValue("@ci_rif", xcliente.d_Registro.c_RIF.c_Texto)
                        .Parameters.AddWithValue("@dir_fiscal", xcliente.d_Registro.c_DirFiscal.c_Texto)
                        .Parameters.AddWithValue("@dir_despacho", xcliente.d_Registro.c_DirDespacho.c_Texto)
                        .Parameters.AddWithValue("@contacto", xcliente.d_Registro.c_ContactarA.c_Texto)
                        .Parameters.AddWithValue("@telefono", xcliente.d_Registro.c_Telefono.c_Texto)
                        .Parameters.AddWithValue("@email", xcliente.d_Registro.c_Email.c_Texto)
                        .Parameters.AddWithValue("@tarifa", xcliente.d_Registro.c_PrecioAsignado.c_Texto)
                        .Parameters.AddWithValue("@descuento", xcliente.d_Registro.c_DescuentoAsignado.c_Valor)
                        .Parameters.AddWithValue("@credito", xcliente.d_Registro.c_CreditoHabilitado.c_Texto)
                        .Parameters.AddWithValue("@dias_credito", xcliente.d_Registro.c_DiasCredito.c_Valor)
                        .Parameters.AddWithValue("@limite_credito", xcliente.d_Registro.c_LimiteCredito.c_Valor)
                        .Parameters.AddWithValue("@contable_cxc", xcliente.d_Registro.c_ContableCXC.c_Texto)
                        .Parameters.AddWithValue("@contable_ingresos", xcliente.d_Registro.c_ContableIngresos.c_Texto)
                        .Parameters.AddWithValue("@contable_anticipos", xcliente.d_Registro.c_ContableAnticipos.c_Texto)
                        .Parameters.AddWithValue("@auto_grupo", xcliente.d_Registro.c_AutoGrupo.c_Texto)
                        .Parameters.AddWithValue("@auto_zona", xcliente.d_Registro.c_AutoZona.c_Texto)
                        .Parameters.AddWithValue("@auto_vendedor", xcliente.d_Registro.c_AutoVendedor.c_Texto)
                        .Parameters.AddWithValue("@denominacion_fiscal", xcliente.d_Registro.c_DenominacionFiscal.c_Texto)
                        .Parameters.AddWithValue("@retencion_iva", xcliente.d_Registro.c_RetencionIVA.c_Valor)
                        .Parameters.AddWithValue("@retencion_islr", xcliente.d_Registro.c_RetencionISLR.c_Valor)
                        .Parameters.AddWithValue("@comentarios", xcliente.d_Registro.c_Comentarios.c_Texto)
                        .Parameters.AddWithValue("@advertencia", xcliente.d_Registro.c_Advertencia.c_Texto)
                        .Parameters.AddWithValue("@estatus", xcliente.d_Registro.c_Estatus.c_Texto)
                        .Parameters.AddWithValue("@website", xcliente.d_Registro.c_WebSite.c_Texto)
                        .Parameters.AddWithValue("@doc_pendientes", xcliente.d_Registro.c_DocPendientesPermitido.c_Valor)
                        .Parameters.AddWithValue("@auto_estado", xcliente.d_Registro.c_AutoEstado.c_Texto)
                        .Parameters.AddWithValue("@recargo", xcliente.d_Registro.c_CargoAsignado.c_Valor)
                        .Parameters.AddWithValue("@tipo_contribuyente", xcliente.d_Registro.c_TipoContribuyente.c_Texto)
                        .Parameters.AddWithValue("@auto_cobrador", xcliente.d_Registro.c_AutoCobrador.c_Texto)
                        .Parameters.AddWithValue("@dia1", xcliente.d_Registro.c_Dia1.c_Texto)
                        .Parameters.AddWithValue("@dia2", xcliente.d_Registro.c_Dia2.c_Texto)
                        .Parameters.AddWithValue("@dia3", xcliente.d_Registro.c_Dia3.c_Texto)
                        .Parameters.AddWithValue("@dia4", xcliente.d_Registro.c_Dia4.c_Texto)
                        .Parameters.AddWithValue("@dia5", xcliente.d_Registro.c_Dia5.c_Texto)
                        .Parameters.AddWithValue("@dia6", xcliente.d_Registro.c_Dia6.c_Texto)
                        .Parameters.AddWithValue("@dia7", xcliente.d_Registro.c_Dia7.c_Texto)
                        .Parameters.AddWithValue("@Telefono_1", xcliente.d_Registro.c_Telefono_1.c_Texto)
                        .Parameters.AddWithValue("@Telefono_2", xcliente.d_Registro.c_Telefono_2.c_Texto)
                        .Parameters.AddWithValue("@Telefono_3", xcliente.d_Registro.c_Telefono_3.c_Texto)
                        .Parameters.AddWithValue("@Telefono_4", xcliente.d_Registro.c_Telefono_4.c_Texto)
                        .Parameters.AddWithValue("@Celular_1", xcliente.d_Registro.c_Celular_1.c_Texto)
                        .Parameters.AddWithValue("@Celular_2", xcliente.d_Registro.c_Celular_2.c_Texto)
                        .Parameters.AddWithValue("@Fax_1", xcliente.d_Registro.c_Fax_1.c_Texto)
                        .Parameters.AddWithValue("@Fax_2", xcliente.d_Registro.c_Fax_2.c_Texto)
                        .Parameters.AddWithValue("@Estatus_Afiliado", xcliente.d_Registro.c_EstatusAfiliado.c_Texto)
                        .Parameters.AddWithValue("@FechaEmision_Afiliado", IIf(xcliente.d_Registro.c_FechaEmision_Afiliado.c_Valor = Date.MinValue, DBNull.Value, xcliente.d_Registro.c_FechaEmision_Afiliado.c_Valor))
                        .Parameters.AddWithValue("@auto", xcliente.d_Registro.c_Automatico.c_Texto)
                        .Parameters.AddWithValue("@id_seguridad", xcliente.d_Registro.c_IdSeguridad)
                        .Parameters.AddWithValue("@licor_licencia_nombre", xcliente.d_Registro.c_LicorLicenciaNombre.c_Texto)
                        .Parameters.AddWithValue("@licor_licencia_numero", xcliente.d_Registro.c_LicorLicenciaNumero.c_Texto)
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim xr As Integer = 0

                            xtr = xcon.BeginTransaction
                            Using xcmd1
                                xcmd1.Transaction = xtr
                                xcmd1.Connection = xcon
                                xr = xcmd1.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("Error Al Actualizar Datos Del Cliente, Otro Usuario Ya Actualizo Los Datos, Verifique Por Favor")
                                End If
                            End Using

                            Using xcmd2 As New SqlCommand(c_Clientes.ModificarCliente_2, xcon, xtr)
                                With xcmd2
                                    .Parameters.AddWithValue("@auto", xcliente.d_Registro.c_Automatico.c_Texto)
                                End With
                                xcmd2.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Nombre, Codigo, Rif o CI Del Cliente. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent ClienteNuevo(xcliente.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "MODIFICAR CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' FUNCION QUE MODIFICA LOS DATOS BASICOS DEL CLIENTE - DESDE EL PTO DE VENTA
            ''' </summary>
            Function F_ModificaClienteBasico(ByVal xcliente As c_Clientes.c_ModificarClienteBasico) As Boolean
                Try
                    Dim xficha As New FichaClientes.c_Clientes.c_Registro
                    With xficha
                        .c_NombreRazonSocial.c_Texto = xcliente._NombreRazonSocial
                        .c_DirFiscal.c_Texto = xcliente._DirFiscal
                        .c_Email.c_Texto = xcliente._Email
                        .c_ContactarA.c_Texto = xcliente._PersonaContacto
                        .c_Telefono_1.c_Texto = xcliente._Telefono_1
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim xr As Integer = 0
                            xtr = xcon.BeginTransaction
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = "update clientes set nombre=@nombre, dir_fiscal=@dir_fiscal, contacto=@contacto, telefono_1=@telefono_1," & _
                                "email=@email where auto=@auto and id_seguridad=@id_seguridad"
                                With xcmd
                                    .Parameters.AddWithValue("@nombre", xficha.r_NombreRazonSocial).Size = xficha.c_NombreRazonSocial.c_Largo
                                    .Parameters.AddWithValue("@dir_fiscal", xficha.r_DirFiscal).Size = xficha.c_NombreRazonSocial.c_Largo
                                    .Parameters.AddWithValue("@contacto", xficha.r_ContactarA).Size = xficha.c_NombreRazonSocial.c_Largo
                                    .Parameters.AddWithValue("@telefono_1", xficha.r_Telefono_1).Size = xficha.c_NombreRazonSocial.c_Largo
                                    .Parameters.AddWithValue("@email", xficha.r_Email).Size = xficha.c_NombreRazonSocial.c_Largo
                                    .Parameters.AddWithValue("@auto", xcliente._FichaCliente.r_Automatico)
                                    .Parameters.AddWithValue("@id_seguridad", xcliente._FichaCliente.r_IdSeguridad)
                                End With
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL CLIENTE" + vbCrLf + "CLIENTE NO ENCONTRADO / YA FUE ACTUALIZADO POR OTRO USUARIO")
                                End If
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(ex2.Message)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent ClienteBasicoModificadoOk(xcliente._FichaCliente.r_Automatico)
                    Return True
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function


            ''' <summary>
            ''' Funcion: Permite Buscar y Cargar Un Cliente Por Su CI/Rif
            ''' </summary>
            Function F_BuscarRif(ByVal xrif As String) As Boolean
                Dim xr As Integer
                Try
                    Dim xsql As String = "select * from clientes where ci_rif=@ci_rif"

                    Me.f_Clientes.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@ci_rif", xrif)
                        xr = xadap.Fill(Me.f_Clientes.TablaDato)
                    End Using
                    If xr = 0 Then
                        Throw New Exception("CLIENTE NO ENCONTRADO")
                    Else
                        Me.f_Clientes.M_CargarFicha(Me.f_Clientes.TablaDato.Rows(0))
                    End If
                    Return True
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "BUSCAR CI/RIF DEL CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Buscar y Cargar Un Cliente Por Su CI/Rif
            ''' </summary>
            Function F_BuscarCargarClientePorRif(ByVal xrif As String) As Boolean
                Dim xr As Integer
                Try
                    Dim xsql As String = "select * from clientes where ci_rif=@ci_rif"

                    Me.f_Clientes.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@ci_rif", xrif)
                        xr = xadap.Fill(Me.f_Clientes.TablaDato)
                    End Using
                    If xr = 0 Then
                        Return False
                    Else
                        Me.f_Clientes.M_CargarFicha(Me.f_Clientes.TablaDato.Rows(0))
                        Return True
                    End If
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "BUSCAR CI/RIF DEL CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Buscar y Cargar Un Cliente Por Su Codigo
            ''' </summary>
            Function F_BuscarCargarClientePorCodigo(ByVal xcodigo As String) As Boolean
                Dim xr As Integer
                Try
                    Dim xsql As String = "select * from clientes where codigo=@codigo"

                    Me.f_Clientes.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@codigo", xcodigo)
                        xr = xadap.Fill(Me.f_Clientes.TablaDato)
                    End Using
                    If xr = 0 Then
                        Return False
                    Else
                        Me.f_Clientes.M_CargarFicha(Me.f_Clientes.TablaDato.Rows(0))
                        Return True
                    End If
                Catch ex As Exception
                    Throw New Exception("CLIENTES" + vbCrLf + "BUSCAR CODIGO DEL CLIENTE" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class

        Private xfichaCliente As FichaClientes

        ''' <summary>
        ''' Ficha General Clientes
        ''' </summary>
        Property f_FichaClientes() As FichaClientes
            Get
                Return xfichacliente
            End Get
            Set(ByVal value As FichaClientes)
                xfichacliente = value
            End Set
        End Property
    End Class
End Namespace
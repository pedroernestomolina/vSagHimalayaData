Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL PROVEEDORES
        ''' </summary>
        Public Class FichaProveedores
            Event ProveedorNuevo(ByVal xauto As String)

            ''' <summary>
            ''' Define Los Tipos De Busqueda Para El Proveedor
            ''' </summary>
            Public Enum TipoBusqueda As Integer
                PorNombreRazonSocial = 0
                PorRif_CI = 1
                PorCodigo = 2
            End Enum

            ''' <summary>
            ''' CLASE FICHA DE PROVEEDOR
            ''' </summary>
            Public Class c_Proveedor
                Event Actualizar()

                ''' <summary>
                ''' Clase PARA AGREGAR UN NUEVO PROVEEDOR
                ''' </summary>
                Class c_AgregarProveedor
                    Private xproveedor As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xproveedor
                        End Get
                        Set(ByVal value As c_Registro)
                            xproveedor = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xproveedor.c_CodigoProveedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreRazonSocial() As String
                        Set(ByVal value As String)
                            xproveedor.c_NombreRazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RifCi() As String
                        Set(ByVal value As String)
                            xproveedor.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirFiscal() As String
                        Set(ByVal value As String)
                            xproveedor.c_DirFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xproveedor.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ActivarCredito() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                xproveedor.c_CreditoHabilitado.c_Texto = "1"
                            Else
                                xproveedor.c_CreditoHabilitado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DiasCredito() As Integer
                        Set(ByVal value As Integer)
                            xproveedor.c_DiasCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _LimiteCreditoPermitido() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_LimiteCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_CXP() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableCXP.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Ingresos() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableIngresos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Anticipos() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableAnticipos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            xproveedor.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DenominacionFiscal() As String
                        Set(ByVal value As String)
                            xproveedor.c_DenominacionFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionIVA() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_RetencionIVA.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionISLR() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_RetencionISLR.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xproveedor.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xproveedor.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _WebSite() As String
                        Set(ByVal value As String)
                            xproveedor.c_WebSite.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CantDocCreditoPermitido() As Integer
                        Set(ByVal value As Integer)
                            xproveedor.c_DocPendientesPermitido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_3() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_3.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_4() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_4.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoOrigen() As String
                        Set(ByVal value As String)
                            xproveedor.c_TipoOrigen.c_Texto = value
                        End Set
                    End Property

                    Sub New()
                        xproveedor = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR UN PROVEEDOR
                ''' </summary>
                Class c_ModificarProveedor
                    Private xproveedor As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xproveedor
                        End Get
                        Set(ByVal value As c_Registro)
                            xproveedor = value
                        End Set
                    End Property

                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            xproveedor.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xproveedor.c_IdSeguridad = value
                        End Set
                    End Property

                    WriteOnly Property _Codigo() As String
                        Set(ByVal value As String)
                            xproveedor.c_CodigoProveedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreRazonSocial() As String
                        Set(ByVal value As String)
                            xproveedor.c_NombreRazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RifCi() As String
                        Set(ByVal value As String)
                            xproveedor.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirFiscal() As String
                        Set(ByVal value As String)
                            xproveedor.c_DirFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _PersonaContacto() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            xproveedor.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ActivarCredito() As TipoSiNo
                        Set(ByVal value As TipoSiNo)
                            If value = TipoSiNo.Si Then
                                xproveedor.c_CreditoHabilitado.c_Texto = "1"
                            Else
                                xproveedor.c_CreditoHabilitado.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DiasCredito() As Integer
                        Set(ByVal value As Integer)
                            xproveedor.c_DiasCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _LimiteCreditoPermitido() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_LimiteCredito.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_CXP() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableCXP.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Ingresos() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableIngresos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CtaContable_Anticipos() As String
                        Set(ByVal value As String)
                            xproveedor.c_ContableAnticipos.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            xproveedor.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DenominacionFiscal() As String
                        Set(ByVal value As String)
                            xproveedor.c_DenominacionFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionIVA() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_RetencionIVA.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _RetencionISLR() As Single
                        Set(ByVal value As Single)
                            xproveedor.c_RetencionISLR.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            xproveedor.c_Comentarios.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Adevertencia() As String
                        Set(ByVal value As String)
                            xproveedor.c_Advertencia.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _WebSite() As String
                        Set(ByVal value As String)
                            xproveedor.c_WebSite.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CantDocCreditoPermitido() As Integer
                        Set(ByVal value As Integer)
                            xproveedor.c_DocPendientesPermitido.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_3() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_3.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telf_4() As String
                        Set(ByVal value As String)
                            xproveedor.c_Telefono_4.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            xproveedor.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            xproveedor.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoOrigen() As String
                        Set(ByVal value As String)
                            xproveedor.c_TipoOrigen.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xproveedor.c_Estatus.c_Texto = "Activo"
                            Else
                                xproveedor.c_Estatus.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property

                    Sub New()
                        xproveedor = New c_Registro
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
                    Private f_contacto As CampoTexto
                    Private f_telefono As CampoTexto
                    Private f_email As CampoTexto
                    Private f_credito As CampoTexto
                    Private f_dias_credito As CampoInteger
                    Private f_limite_credito As CampoSingle
                    Private f_contable_cxp As CampoTexto
                    Private f_contable_ingresos As CampoTexto
                    Private f_contable_anticipos As CampoTexto
                    Private f_total_debitos As CampoSingle
                    Private f_total_creditos As CampoSingle
                    Private f_total_anticipos As CampoSingle
                    Private f_total_saldo As CampoSingle
                    Private f_credito_disponible As CampoSingle
                    Private f_auto As CampoTexto
                    Private f_auto_grupo As CampoTexto
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
                    Private f_fecha_alta As CampoFecha
                    Private f_telefono_1 As CampoTexto
                    Private f_telefono_2 As CampoTexto
                    Private f_telefono_3 As CampoTexto
                    Private f_telefono_4 As CampoTexto
                    Private f_celular_1 As CampoTexto
                    Private f_celular_2 As CampoTexto
                    Private f_fax_1 As CampoTexto
                    Private f_fax_2 As CampoTexto
                    Private f_tipoorigen As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo, Codigo Del Proveedor
                    ''' </summary>
                    Property c_CodigoProveedor() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoProveedor() As String
                        Get
                            Return Me.c_CodigoProveedor.c_Texto.Trim
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

                    ReadOnly Property _NombreRazonSocial() As String
                        Get
                            Return Me.c_NombreRazonSocial.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, CI / RIF DEL PROVEEDOR
                    ''' </summary>
                    Property c_RIF() As CampoTexto
                        Get
                            Return f_ci_rif
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ci_rif = value
                        End Set
                    End Property

                    ReadOnly Property _CiRif() As String
                        Get
                            Return Me.c_RIF.c_Texto.Trim
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

                    ReadOnly Property _DirFiscal() As String
                        Get
                            Return Me.c_DirFiscal.c_Texto.Trim
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

                    ReadOnly Property _ContactarA() As String
                        Get
                            Return Me.c_ContactarA.c_Texto.Trim
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

                    ReadOnly Property _Email() As String
                        Get
                            Return Me.c_Email.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Email
                    ''' </summary>
                    Property c_CreditoHabilitado() As CampoTexto
                        Get
                            Return f_credito
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_credito = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna El Estatus Del Credito
                    ''' </summary>
                    ReadOnly Property _EstatusCredito() As TipoEstatus
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
                    Property c_DiasCredito() As CampoInteger
                        Get
                            Return f_dias_credito
                        End Get
                        Protected Friend Set(ByVal value As CampoInteger)
                            f_dias_credito = value
                        End Set
                    End Property

                    ReadOnly Property _DiasCredito() As Integer
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

                    ReadOnly Property _LimiteCredito() As Single
                        Get
                            Return Me.c_LimiteCredito.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cuenta Contable CXP
                    ''' </summary>
                    Property c_ContableCXP() As CampoTexto
                        Get
                            Return f_contable_cxp
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contable_cxp = value
                        End Set
                    End Property

                    ReadOnly Property _ContableCXP() As String
                        Get
                            Return Me.c_ContableCXP.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Cuenta Contable Ingresos
                    ''' </summary>
                    Property c_ContableIngresos() As CampoTexto
                        Get
                            Return f_contable_ingresos
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contable_ingresos = value
                        End Set
                    End Property

                    ReadOnly Property _ContableIngresos() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contable_anticipos = value
                        End Set
                    End Property

                    ReadOnly Property _ContableAnticipos() As String
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
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_total_debitos = value
                        End Set
                    End Property

                    ReadOnly Property _TotalDebitos() As Single
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
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_total_creditos = value
                        End Set
                    End Property

                    ReadOnly Property _TotalCreditos() As Single
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
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_total_anticipos = value
                        End Set
                    End Property

                    ReadOnly Property _TotalAnticipos() As Single
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
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_total_saldo = value
                        End Set
                    End Property

                    ReadOnly Property _TotalSaldo() As Single
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

                    ReadOnly Property _CreditoDisponible() As Single
                        Get
                            Return Me.c_CreditoDisponible.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Proveedor
                    ''' </summary>
                    Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Automatico Del Grupo
                    ''' </summary>
                    Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_AutoGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Denominacion Fiscal
                    ''' </summary>
                    Property c_DenominacionFiscal() As CampoTexto
                        Get
                            Return f_denominacion_fiscal
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_denominacion_fiscal = value
                        End Set
                    End Property

                    ReadOnly Property _DenominacionFiscal() As String
                        Get
                            Return Me.c_DenominacionFiscal.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Retencion IVA
                    ''' </summary>
                    Property c_RetencionIVA() As CampoSingle
                        Get
                            Return f_retencion_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_retencion_iva = value
                        End Set
                    End Property

                    ReadOnly Property _TasaRetencionIva() As Single
                        Get
                            Return Me.c_RetencionIVA.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Retencion ISLR
                    ''' </summary>
                    Property c_RetencionISLR() As CampoSingle
                        Get
                            Return f_retencion_islr
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_retencion_islr = value
                        End Set
                    End Property

                    ReadOnly Property _TasaRetencionISLR() As Single
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_comentarios = value
                        End Set
                    End Property

                    ReadOnly Property _Comentarios() As String
                        Get
                            Return Me.c_Comentarios.c_Texto.Trim
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

                    ReadOnly Property _Advertencia() As String
                        Get
                            Return Me.c_Advertencia.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Del Proveedor
                    ''' </summary>
                    Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Del Proveedor
                    ''' </summary>
                    ReadOnly Property _EstatusDelProveedor() As TipoEstatus
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
                        Protected Friend Set(ByVal value As CampoFecha)
                            f_fecha_ult_compra = value
                        End Set
                    End Property

                    ReadOnly Property _FechaUltCompra() As Date
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
                        Protected Friend Set(ByVal value As CampoFecha)
                            f_fecha_ult_pago = value
                        End Set
                    End Property

                    ReadOnly Property _FechaUltPago() As Date
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_website = value
                        End Set
                    End Property

                    ReadOnly Property _WebSite() As String
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
                        Protected Friend Set(ByVal value As CampoInteger)
                            f_doc_pendientes = value
                        End Set
                    End Property

                    ReadOnly Property _DocPendientesPermitidos() As Integer
                        Get
                            Return Me.c_DocPendientesPermitido.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Fecha Alta / Registro Del Proveedor
                    ''' </summary>
                    Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Protected Friend Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property

                    ReadOnly Property _FechaAlta() As Date
                        Get
                            Return Me.c_FechaAlta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Telefono_1
                    ''' </summary>
                    Property c_Telefono_1() As CampoTexto
                        Get
                            Return f_telefono_1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_1 = value
                        End Set
                    End Property

                    ReadOnly Property _Telefono_1() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_2 = value
                        End Set
                    End Property

                    ReadOnly Property _Telefono_2() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_3 = value
                        End Set
                    End Property

                    ReadOnly Property _Telefono_3() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_4 = value
                        End Set
                    End Property

                    ReadOnly Property _Telefono_4() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular_1 = value
                        End Set
                    End Property

                    ReadOnly Property _Celular_1() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular_2 = value
                        End Set
                    End Property

                    ReadOnly Property _Celular_2() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax_1 = value
                        End Set
                    End Property

                    ReadOnly Property _Fax_1() As String
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
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax_2 = value
                        End Set
                    End Property

                    ReadOnly Property _Fax_2() As String
                        Get
                            Return Me.c_Fax_2.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Origen / Nacionalidad Del Proveedor
                    ''' </summary>
                    Property c_TipoOrigen() As CampoTexto
                        Get
                            Return f_tipoorigen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_tipoorigen = value
                        End Set
                    End Property

                    ReadOnly Property _TipoOrigen() As String
                        Get
                            Return Me.c_TipoOrigen.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Id De Seguridad
                    ''' </summary>
                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Protected Friend Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Id Seguridad
                    ''' </summary>
                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' NOMBRE DEL GRUPO
                    ''' </summary>
                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Dim xp1 As New SqlParameter("@grupo", Me._AutoGrupo)
                            Return MiDataSistema.DataSistema.F_GetString("SELECT nombre from grupo_proveedor where auto=@grupo", xp1)
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna La Cantidad de Documentos Pendientes Hasta La Fecha Del Proveedor
                    ''' </summary>
                    ReadOnly Property _CantidadDocPendientes() As Integer
                        Get
                            Dim xobj As Object
                            Dim xsql_1 As String = "select count(*) from cxp where estatus='0' " _
                              + "and auto_proveedor= @auto_proveedor and cancelado='0' and tipo_documento not in('PAG','NCF')"
                            Try
                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Try
                                        Using xcmd As New SqlCommand(xsql_1, xcon)
                                            xcmd.Parameters.AddWithValue("@auto_proveedor", Me._Automatico)
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
                                Throw New Exception("ERROR AL VERIFICAR LIMITE DOCUMENTOS PENDIENTES DEL PROVEEDOR" + vbCrLf + ex.Message)
                            End Try
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        With Me.c_CodigoProveedor
                            .c_Largo = 15
                            .c_NombreInterno = "codigo"
                            .c_Texto = ""
                        End With
                        With Me.c_NombreRazonSocial
                            .c_Largo = 120
                            .c_NombreInterno = "nombre"
                            .c_Texto = ""
                        End With
                        With Me.c_RIF
                            .c_Largo = 12
                            .c_NombreInterno = "ci_rif"
                            .c_Texto = ""
                        End With
                        With Me.c_DirFiscal
                            .c_Largo = 120
                            .c_NombreInterno = "dir_fiscal"
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
                        With Me.c_CreditoHabilitado
                            .c_Largo = 1
                            .c_NombreInterno = "credito"
                            .c_Texto = ""
                        End With
                        With Me.c_DiasCredito
                            .c_Valor = 0
                            .c_NombreInterno = "dias_credito"
                        End With
                        With Me.c_LimiteCredito
                            .c_Valor = 0
                            .c_NombreInterno = "limite_credito"
                        End With
                        With Me.c_ContableCXP
                            .c_Largo = 20
                            .c_NombreInterno = "contable_cxp"
                            .c_Texto = ""
                        End With
                        With Me.c_ContableIngresos
                            .c_Largo = 20
                            .c_NombreInterno = "contable_ingresos"
                            .c_Texto = ""
                        End With
                        With Me.c_ContableAnticipos
                            .c_Largo = 20
                            .c_NombreInterno = "contable_anticipos"
                            .c_Texto = ""
                        End With
                        With Me.c_TotalDebitos
                            .c_Valor = 0
                            .c_NombreInterno = "total_debitos"
                        End With
                        With Me.c_TotalCreditos
                            .c_Valor = 0
                            .c_NombreInterno = "total_creditos"
                        End With
                        With Me.c_TotalAnticipos
                            .c_Valor = 0
                            .c_NombreInterno = "total_anticipos"
                        End With
                        With Me.c_TotalSaldo
                            .c_Valor = 0
                            .c_NombreInterno = "total_saldo"
                        End With
                        With Me.c_CreditoDisponible
                            .c_Valor = 0
                            .c_NombreInterno = "credito_disponible"
                        End With
                        With Me.c_Automatico
                            .c_Largo = 10
                            .c_NombreInterno = "auto"
                            .c_Texto = ""
                        End With
                        With Me.c_AutoGrupo
                            .c_Largo = 10
                            .c_NombreInterno = "auto_grupo"
                            .c_Texto = ""
                        End With
                        With Me.c_DenominacionFiscal
                            .c_Largo = 25
                            .c_NombreInterno = "denominacion_fiscal"
                            .c_Texto = ""
                        End With
                        With Me.c_RetencionIVA
                            .c_Valor = 0
                            .c_NombreInterno = "retencion_iva"
                        End With
                        With Me.c_RetencionISLR
                            .c_Valor = 0
                            .c_NombreInterno = "retencion_islr"
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
                        With Me.c_FechaUltCompra
                            .c_Valor = Date.MinValue
                            .c_NombreInterno = "fecha_ult_compra"
                        End With
                        With Me.c_FechaUltPago
                            .c_Valor = Date.MinValue
                            .c_NombreInterno = "fecha_ult_pago"
                        End With
                        With Me.c_WebSite
                            .c_Largo = 50
                            .c_Texto = ""
                            .c_NombreInterno = "website"
                        End With
                        With Me.c_DocPendientesPermitido
                            .c_Valor = 0
                            .c_NombreInterno = "doc_pendientes"
                        End With
                        With Me.c_FechaAlta
                            .c_Valor = Date.MinValue
                            .c_NombreInterno = "fecha_alta"
                        End With
                        With Me.c_Telefono_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono_1"
                        End With
                        With Me.c_Telefono_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono_2"
                        End With
                        With Me.c_Telefono_3
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono_3"
                        End With
                        With Me.c_Telefono_4
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "telefono_4"
                        End With
                        With Me.c_Celular_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "celular_1"
                        End With
                        With Me.c_Celular_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "celular_2"
                        End With
                        With Me.c_Fax_1
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "fax_1"
                        End With
                        With Me.c_Fax_2
                            .c_Largo = 14
                            .c_Texto = ""
                            .c_NombreInterno = "fax_2"
                        End With
                        With Me.c_TipoOrigen
                            .c_Largo = 20
                            .c_Texto = ""
                            .c_NombreInterno = "tipoorigen"
                        End With
                    End Sub

                    Sub New()
                        Me.c_Advertencia = New CampoTexto
                        Me.c_AutoGrupo = New CampoTexto
                        Me.c_Automatico = New CampoTexto
                        Me.c_Celular_1 = New CampoTexto
                        Me.c_Celular_2 = New CampoTexto
                        Me.c_CodigoProveedor = New CampoTexto
                        Me.c_Comentarios = New CampoTexto
                        Me.c_ContableAnticipos = New CampoTexto
                        Me.c_ContableCXP = New CampoTexto
                        Me.c_ContableIngresos = New CampoTexto
                        Me.c_ContactarA = New CampoTexto
                        Me.c_CreditoHabilitado = New CampoTexto
                        Me.c_CreditoDisponible = New CampoSingle
                        Me.c_DenominacionFiscal = New CampoTexto
                        Me.c_DiasCredito = New CampoInteger
                        Me.c_DirFiscal = New CampoTexto
                        Me.c_DocPendientesPermitido = New CampoInteger
                        Me.c_Email = New CampoTexto
                        Me.c_Estatus = New CampoTexto
                        Me.c_Fax_1 = New CampoTexto
                        Me.c_Fax_2 = New CampoTexto
                        Me.c_FechaAlta = New CampoFecha
                        Me.c_FechaUltCompra = New CampoFecha
                        Me.c_FechaUltPago = New CampoFecha
                        Me.c_LimiteCredito = New CampoSingle
                        Me.c_NombreRazonSocial = New CampoTexto
                        Me.c_RetencionISLR = New CampoSingle
                        Me.c_RetencionIVA = New CampoSingle
                        Me.c_RIF = New CampoTexto
                        Me.c_Telefono = New CampoTexto
                        Me.c_Telefono_1 = New CampoTexto
                        Me.c_Telefono_2 = New CampoTexto
                        Me.c_Telefono_3 = New CampoTexto
                        Me.c_Telefono_4 = New CampoTexto
                        Me.c_TotalAnticipos = New CampoSingle
                        Me.c_TotalCreditos = New CampoSingle
                        Me.c_TotalDebitos = New CampoSingle
                        Me.c_TotalSaldo = New CampoSingle
                        Me.c_WebSite = New CampoTexto
                        Me.c_TipoOrigen = New CampoTexto

                        LimpiarRegistro()
                    End Sub
                End Class

                Private xtipo_busqueda As String() = {"Por Nombre/Razon Social", "Por RIF/CI", "Por Codigo"}
                ReadOnly Property p_TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                End Property

                Private xtipo_origen As String() = {"Nacional", "Extranjero"}
                ReadOnly Property p_TipoOrigen() As String()
                    Get
                        Return xtipo_origen
                    End Get
                End Property

                Private xdenfiscal As String() = {"No Contibuyente", "Contribuyente Formal", "Contribuyente Ordinario", "Gobierno", "Exonerado", "Extranjero/Exportador"}
                ReadOnly Property p_DenominacionFiscal() As String()
                    Get
                        Return xdenfiscal
                    End Get
                End Property

                ''' Bucar Proveedor
                Friend Const Select_1 As String = "select p.*,g.nombre nombre_grupo from proveedores p join grupo_proveedor g on p.auto_grupo=g.auto " _
                     + "where p.auto=@auto"

                Friend Const InsertarProveedor As String = "Insert Into Proveedores (" _
                    + "codigo," _
                    + "nombre," _
                    + "ci_rif," _
                    + "dir_fiscal," _
                    + "contacto," _
                    + "telefono," _
                    + "email," _
                    + "credito," _
                    + "dias_credito," _
                    + "limite_credito," _
                    + "contable_cxp," _
                    + "contable_ingresos," _
                    + "contable_anticipos," _
                    + "total_debitos," _
                    + "total_creditos," _
                    + "total_anticipos," _
                    + "total_saldo," _
                    + "credito_disponible," _
                    + "auto," _
                    + "auto_grupo," _
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
                    + "fecha_alta," _
                    + "Telefono_1," _
                    + "Telefono_2," _
                    + "Telefono_3," _
                    + "Telefono_4," _
                    + "Celular_1," _
                    + "Celular_2," _
                    + "Fax_1," _
                    + "Fax_2," _
                    + "tipoorigen) " _
                    + " values (" _
                    + "@codigo," _
                    + "@nombre," _
                    + "@ci_rif," _
                    + "@dir_fiscal," _
                    + "@contacto," _
                    + "@telefono," _
                    + "@email," _
                    + "@credito," _
                    + "@dias_credito," _
                    + "@limite_credito," _
                    + "@contable_cxp," _
                    + "@contable_ingresos," _
                    + "@contable_anticipos," _
                    + "@total_debitos," _
                    + "@total_creditos," _
                    + "@total_anticipos," _
                    + "@total_saldo," _
                    + "@credito_disponible," _
                    + "@auto," _
                    + "@auto_grupo," _
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
                    + "@fecha_alta," _
                    + "@Telefono_1," _
                    + "@Telefono_2," _
                    + "@Telefono_3," _
                    + "@Telefono_4," _
                    + "@Celular_1," _
                    + "@Celular_2," _
                    + "@Fax_1," _
                    + "@Fax_2," _
                    + "@tipoorigen)"

                Friend Const ModificarProveedor_1 As String = "Update Proveedores set " _
                  + "codigo=@CODIGO," _
                  + "nombre=@NOMBRE," _
                  + "ci_rif=@ci_rif," _
                  + "dir_fiscal=@DIR_FISCAL," _
                  + "contacto=@CONTACTO," _
                  + "telefono=@TELEFONO," _
                  + "email=@EMAIL," _
                  + "credito=@CREDITO," _
                  + "dias_credito=@dias_credito," _
                  + "limite_credito=@limite_credito," _
                  + "contable_cxp=@contable_cxp," _
                  + "contable_ingresos=@contable_ingresos," _
                  + "contable_anticipos=@contable_anticipos," _
                  + "auto_grupo=@auto_grupo," _
                  + "denominacion_fiscal=@denominacion_fiscal," _
                  + "retencion_iva=@retencion_iva," _
                  + "retencion_islr=@retencion_islr," _
                  + "comentarios=@comentarios," _
                  + "advertencia=@advertencia," _
                  + "estatus=@estatus," _
                  + "website=@website," _
                  + "doc_pendientes=@doc_pendientes," _
                  + "telefono_1=@telefono_1," _
                  + "telefono_2=@telefono_2," _
                  + "telefono_3=@telefono_3," _
                  + "telefono_4=@telefono_4," _
                  + "celular_1=@celular_1," _
                  + "celular_2=@celular_2," _
                  + "fax_1=@fax_1," _
                  + "fax_2=@fax_2," _
                  + "tipoorigen=@tipoorigen " _
                  + "WHERE AUTO=@AUTO and id_seguridad=@id_seguridad"

                Friend Const ModificarProveedor_2 As String = "Update Proveedores set " _
                  + "credito_disponible = (Limite_credito-Total_saldo) " _
                  + "WHERE AUTO=@AUTO"

                Private xregistro As c_Registro
                Private xtabla As DataTable

                Sub New()
                    xtabla = New DataTable("PROVEEDOR")
                    xregistro = New c_Registro
                End Sub

                ''' <summary>
                ''' Tabla A Almacenar Registro
                ''' </summary>
                Property TablaDato() As DataTable
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
                Sub M_Limpiar_Tabla()
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

                ''' <summary>
                ''' Metodo: Carga Ficha De Datos Fiscales A La Clase Registro
                ''' </summary>
                Sub M_CargarFicha()
                    Try
                        Me.RegistroDato.LimpiarRegistro()

                        With Me.RegistroDato
                            .c_Advertencia.c_Texto = xtabla.Rows(0)(.c_Advertencia.c_NombreInterno)
                            .c_AutoGrupo.c_Texto = xtabla.Rows(0)(.c_AutoGrupo.c_NombreInterno)
                            .c_Automatico.c_Texto = xtabla.Rows(0)(.c_Automatico.c_NombreInterno)
                            .c_CodigoProveedor.c_Texto = xtabla.Rows(0)(.c_CodigoProveedor.c_NombreInterno)
                            .c_Comentarios.c_Texto = xtabla.Rows(0)(.c_Comentarios.c_NombreInterno)
                            .c_ContableAnticipos.c_Texto = xtabla.Rows(0)(.c_ContableAnticipos.c_NombreInterno)
                            .c_ContableCXP.c_Texto = xtabla.Rows(0)(.c_ContableCXP.c_NombreInterno)
                            .c_ContableIngresos.c_Texto = xtabla.Rows(0)(.c_ContableIngresos.c_NombreInterno)
                            .c_ContactarA.c_Texto = xtabla.Rows(0)(.c_ContactarA.c_NombreInterno)
                            .c_CreditoDisponible.c_Valor = xtabla.Rows(0)(.c_CreditoDisponible.c_NombreInterno)
                            .c_CreditoHabilitado.c_Texto = xtabla.Rows(0)(.c_CreditoHabilitado.c_NombreInterno)
                            .c_DenominacionFiscal.c_Texto = xtabla.Rows(0)(.c_DenominacionFiscal.c_NombreInterno)
                            .c_DiasCredito.c_Valor = xtabla.Rows(0)(.c_DiasCredito.c_NombreInterno)
                            .c_DirFiscal.c_Texto = xtabla.Rows(0)(.c_DirFiscal.c_NombreInterno)
                            .c_DocPendientesPermitido.c_Valor = xtabla.Rows(0)(.c_DocPendientesPermitido.c_NombreInterno)
                            .c_Email.c_Texto = xtabla.Rows(0)(.c_Email.c_NombreInterno)
                            .c_Estatus.c_Texto = xtabla.Rows(0)(.c_Estatus.c_NombreInterno)
                            .c_FechaAlta.c_Valor = xtabla.Rows(0)(.c_FechaAlta.c_NombreInterno)
                            .c_FechaUltCompra.c_Valor = xtabla.Rows(0)(.c_FechaUltCompra.c_NombreInterno)
                            .c_FechaUltPago.c_Valor = xtabla.Rows(0)(.c_FechaUltPago.c_NombreInterno)
                            .c_LimiteCredito.c_Valor = xtabla.Rows(0)(.c_LimiteCredito.c_NombreInterno)
                            .c_NombreRazonSocial.c_Texto = xtabla.Rows(0)(.c_NombreRazonSocial.c_NombreInterno)
                            .c_RetencionISLR.c_Valor = xtabla.Rows(0)(.c_RetencionISLR.c_NombreInterno)
                            .c_RetencionIVA.c_Valor = xtabla.Rows(0)(.c_RetencionIVA.c_NombreInterno)
                            .c_RIF.c_Texto = xtabla.Rows(0)(.c_RIF.c_NombreInterno)
                            .c_Telefono.c_Texto = xtabla.Rows(0)(.c_Telefono.c_NombreInterno)

                            If Not IsDBNull(xtabla.Rows(0)(.c_Telefono_1.c_NombreInterno)) Then
                                .c_Telefono_1.c_Texto = xtabla.Rows(0)(.c_Telefono_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Telefono_2.c_NombreInterno)) Then
                                .c_Telefono_2.c_Texto = xtabla.Rows(0)(.c_Telefono_2.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Telefono_3.c_NombreInterno)) Then
                                .c_Telefono_3.c_Texto = xtabla.Rows(0)(.c_Telefono_3.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Telefono_4.c_NombreInterno)) Then
                                .c_Telefono_4.c_Texto = xtabla.Rows(0)(.c_Telefono_4.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Celular_1.c_NombreInterno)) Then
                                .c_Celular_1.c_Texto = xtabla.Rows(0)(.c_Celular_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Celular_2.c_NombreInterno)) Then
                                .c_Celular_2.c_Texto = xtabla.Rows(0)(.c_Celular_2.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Fax_1.c_NombreInterno)) Then
                                .c_Fax_1.c_Texto = xtabla.Rows(0)(.c_Fax_1.c_NombreInterno)
                            End If
                            If Not IsDBNull(xtabla.Rows(0)(.c_Fax_2.c_NombreInterno)) Then
                                .c_Fax_2.c_Texto = xtabla.Rows(0)(.c_Fax_2.c_NombreInterno)
                            End If

                            If Not IsDBNull(xtabla.Rows(0)("id_seguridad")) Then
                                .c_IdSeguridad = xtabla.Rows(0)("id_seguridad")
                            End If

                            If Not IsDBNull(xtabla.Rows(0)(.c_TipoOrigen.c_NombreInterno)) Then
                                .c_TipoOrigen.c_Texto = xtabla.Rows(0)(.c_TipoOrigen.c_NombreInterno)
                            Else
                                .c_TipoOrigen.c_Texto = "Nacional"
                            End If

                            .c_TotalAnticipos.c_Valor = xtabla.Rows(0)(.c_TotalAnticipos.c_NombreInterno)
                            .c_TotalCreditos.c_Valor = xtabla.Rows(0)(.c_TotalCreditos.c_NombreInterno)
                            .c_TotalDebitos.c_Valor = xtabla.Rows(0)(.c_TotalDebitos.c_NombreInterno)
                            .c_TotalSaldo.c_Valor = xtabla.Rows(0)(.c_TotalSaldo.c_NombreInterno)
                            .c_WebSite.c_Texto = xtabla.Rows(0)(.c_WebSite.c_NombreInterno)
                        End With
                    Catch ex As Exception
                        Throw New Exception("CLIENTES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.LimpiarRegistro()

                        With Me.RegistroDato
                            .c_Advertencia.c_Texto = xrow(.c_Advertencia.c_NombreInterno)
                            .c_AutoGrupo.c_Texto = xrow(.c_AutoGrupo.c_NombreInterno)
                            .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                            .c_CodigoProveedor.c_Texto = xrow(.c_CodigoProveedor.c_NombreInterno)
                            .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                            .c_ContableAnticipos.c_Texto = xrow(.c_ContableAnticipos.c_NombreInterno)
                            .c_ContableCXP.c_Texto = xrow(.c_ContableCXP.c_NombreInterno)
                            .c_ContableIngresos.c_Texto = xrow(.c_ContableIngresos.c_NombreInterno)
                            .c_ContactarA.c_Texto = xrow(.c_ContactarA.c_NombreInterno)
                            .c_CreditoDisponible.c_Valor = xrow(.c_CreditoDisponible.c_NombreInterno)
                            .c_CreditoHabilitado.c_Texto = xrow(.c_CreditoHabilitado.c_NombreInterno)
                            .c_DenominacionFiscal.c_Texto = xrow(.c_DenominacionFiscal.c_NombreInterno)
                            .c_DiasCredito.c_Valor = xrow(.c_DiasCredito.c_NombreInterno)
                            .c_DirFiscal.c_Texto = xrow(.c_DirFiscal.c_NombreInterno)
                            .c_DocPendientesPermitido.c_Valor = xrow(.c_DocPendientesPermitido.c_NombreInterno)
                            .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                            .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                            .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                            .c_FechaUltCompra.c_Valor = xrow(.c_FechaUltCompra.c_NombreInterno)
                            .c_FechaUltPago.c_Valor = xrow(.c_FechaUltPago.c_NombreInterno)
                            .c_LimiteCredito.c_Valor = xrow(.c_LimiteCredito.c_NombreInterno)
                            .c_NombreRazonSocial.c_Texto = xrow(.c_NombreRazonSocial.c_NombreInterno)
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

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                .c_IdSeguridad = xrow("id_seguridad")
                            End If

                            If Not IsDBNull(xrow(.c_TipoOrigen.c_NombreInterno)) Then
                                .c_TipoOrigen.c_Texto = xrow(.c_TipoOrigen.c_NombreInterno)
                            End If

                            .c_TotalAnticipos.c_Valor = xrow(.c_TotalAnticipos.c_NombreInterno)
                            .c_TotalCreditos.c_Valor = xrow(.c_TotalCreditos.c_NombreInterno)
                            .c_TotalDebitos.c_Valor = xrow(.c_TotalDebitos.c_NombreInterno)
                            .c_TotalSaldo.c_Valor = xrow(.c_TotalSaldo.c_NombreInterno)
                            .c_WebSite.c_Texto = xrow(.c_WebSite.c_NombreInterno)
                        End With
                    Catch ex As Exception
                        Throw New Exception("PROVEEDORES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub
            End Class

            ''' <summary>
            ''' CLASE FICHA DE GRUPO PROVEEDOR
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

                Private Const AgregarRegistro_1 As String = "update contadores set a_grupo_proveedor=a_grupo_proveedor+1; select a_grupo_proveedor from contadores"
                Private Const AgregarRegistro_2 As String = "insert into grupo_proveedor (auto,nombre) values (@auto,@nombre)"
                Private Const ModificarRegistro_1 As String = "update grupo_proveedor set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const EliminarRegistro As String = "delete grupo_proveedor where auto=@auto"

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
                        Throw New Exception("GRUPO PROVEEDORES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                                    Throw New Exception("ERROR AL ELIMINAR GRUPO, EXISTEN PROVEEDORES DENTRO DE ESTE GRUPO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRUPO PROVEEDORES" + vbCrLf + "ELIMINAR REGISTRO" + vbCrLf + ex.Message)
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
                        Throw New Exception("GRUPO PROVEEDORES" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
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
                                    Throw New Exception("ERROR AL MODIFICAR GRUPO, GRUPO HA SIDO ACTUALIZADO POR OTRO USUARIO")
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
                        Throw New Exception("GRUPO PROVEEDORES" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE FICHA DE CTAS BANCARIAS DEL PROVEEDOR
            ''' </summary>
            Public Class c_CtasBancarias
                Event Actualizar()

                Class c_AgregarCta
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Del Proveedor
                    ''' </summary>
                    WriteOnly Property _AutoProveedor() As String
                        Set(ByVal value As String)
                            xregistro.c_AutomaticoProveedor.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico De La Agencia
                    ''' </summary>
                    WriteOnly Property _AutoAgencia() As String
                        Set(ByVal value As String)
                            xregistro.c_AutomaticoAgencia.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Numero De Cuenta
                    ''' </summary>
                    WriteOnly Property _NumertoCta() As String
                        Set(ByVal value As String)
                            xregistro.c_NumeroCta.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Tipo De Cuenta
                    ''' </summary>
                    WriteOnly Property _TipoCta() As String
                        Set(ByVal value As String)
                            xregistro.c_TipoCta.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' A Nombre / A Favor De Quien Esta La Cuenta
                    ''' </summary>
                    WriteOnly Property _ANombreDe() As String
                        Set(ByVal value As String)
                            xregistro.c_A_Favor_De.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Estatus De La Cuenta
                    ''' </summary>
                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xregistro.c_Estatus.c_Texto = "0"
                            Else
                                xregistro.c_Estatus.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroDato = New c_Registro
                    End Sub
                End Class

                Class c_ModificarCta
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico De la Cta
                    ''' </summary>
                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            xregistro.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico De La Agencia
                    ''' </summary>
                    WriteOnly Property _AutoAgencia() As String
                        Set(ByVal value As String)
                            xregistro.c_AutomaticoAgencia.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Numero De Cuenta
                    ''' </summary>
                    WriteOnly Property _NumertoCta() As String
                        Set(ByVal value As String)
                            xregistro.c_NumeroCta.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Tipo De Cuenta
                    ''' </summary>
                    WriteOnly Property _TipoCta() As String
                        Set(ByVal value As String)
                            xregistro.c_TipoCta.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' A Nombre / A Favor De Quien Esta La Cuenta
                    ''' </summary>
                    WriteOnly Property _ANombreDe() As String
                        Set(ByVal value As String)
                            xregistro.c_A_Favor_De.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Estatus De La Cuenta
                    ''' </summary>
                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xregistro.c_Estatus.c_Texto = "0"
                            Else
                                xregistro.c_Estatus.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroDato = New c_Registro
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_agencia As CampoTexto
                    Private f_numero As CampoTexto
                    Private f_auto_proveedor As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_estatus As CampoTexto

                    Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_AutomaticoAgencia() As CampoTexto
                        Get
                            Return f_auto_agencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_agencia = value
                        End Set
                    End Property

                    Property c_NumeroCta() As CampoTexto
                        Get
                            Return f_numero
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero = value
                        End Set
                    End Property

                    Property c_AutomaticoProveedor() As CampoTexto
                        Get
                            Return f_auto_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_proveedor = value
                        End Set
                    End Property

                    Property c_TipoCta() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    Property c_A_Favor_De() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    Sub M_LimpiarFicha()
                        With Me.c_A_Favor_De
                            .c_Largo = 120
                            .c_NombreInterno = "nombre_id"
                            .c_Texto = ""
                        End With

                        With Me.c_Automatico
                            .c_Largo = 10
                            .c_NombreInterno = "auto"
                            .c_Texto = ""
                        End With

                        With Me.c_AutomaticoAgencia
                            .c_Largo = 10
                            .c_NombreInterno = "auto_agencia"
                            .c_Texto = ""
                        End With

                        With Me.c_AutomaticoProveedor
                            .c_Largo = 10
                            .c_NombreInterno = "auto_proveedor"
                            .c_Texto = ""
                        End With

                        With Me.c_Estatus
                            .c_Largo = 1
                            .c_NombreInterno = "estatus"
                            .c_Texto = ""
                        End With

                        With Me.c_NumeroCta
                            .c_Largo = 25
                            .c_NombreInterno = "numero"
                            .c_Texto = ""
                        End With

                        With Me.c_TipoCta
                            .c_Largo = 20
                            .c_NombreInterno = "tipo"
                            .c_Texto = ""
                        End With
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto
                        Me.c_A_Favor_De = New CampoTexto
                        Me.c_AutomaticoAgencia = New CampoTexto
                        Me.c_AutomaticoProveedor = New CampoTexto
                        Me.c_Estatus = New CampoTexto
                        Me.c_NumeroCta = New CampoTexto
                        Me.c_TipoCta = New CampoTexto

                        M_LimpiarFicha()
                    End Sub

                    ''' <summary>
                    ''' Funcion: Retorna El Estatus De La Cta
                    ''' </summary>
                    ReadOnly Property r_EstatusCta() As Boolean
                        Get
                            If Me.c_Estatus.c_Texto = "0" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Automatico De La Agencia
                    ''' </summary>
                    ReadOnly Property r_AutomaticoCta() As String
                        Get
                            Return Me.c_Automatico.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Nombre De La Agencia
                    ''' </summary>
                    Function r_AgenciaNombre() As String
                        Dim xsql As String = "SELECT NOMBRE FROM AGENCIAS WHERE AUTO=@auto"
                        Dim xobj As Object = Nothing
                        Try
                            Using xcon As New SqlConnection(_MiCadenaConexion)
                                xcon.Open()
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = xsql
                                    xcmd.Parameters.AddWithValue("@auto", Me.c_AutomaticoAgencia.c_Texto)
                                    xobj = xcmd.ExecuteScalar

                                    If xobj IsNot Nothing Then
                                        Return xobj.ToString
                                    Else
                                        Return ""
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Function
                End Class

                Private Const AgregarRegistro_0 As String = "select a_proveedor_cta_bancaria from contadores"
                Private Const AgregarRegistro_1 As String = "update contadores set a_proveedor_cta_bancaria=a_proveedor_cta_bancaria+1; select a_proveedor_cta_bancaria from contadores"
                Private Const AgregarRegistro_2 As String = "insert into proveedores_agencias (auto_agencia,numero,auto_proveedor,tipo,nombre_id,estatus,auto) " _
                              + "values (@auto_agencia,@numero,@auto_proveedor,@tipo,@nombre_id,@estatus,@auto)"
                Private Const EliminarRegistro As String = "delete proveedores_agencias where auto=@auto"
                Private Const ModificarRegistro_1 As String = "update proveedores_agencias set auto_agencia=@auto_agencia, " _
                              + "numero=@numero, tipo=@tipo, nombre_id=@nombre_id, estatus=@estatus where auto=@auto"

                Private xregistro As c_Registro

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
                        Me.RegistroDato.M_LimpiarFicha()
                        With Me.RegistroDato
                            .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                            .c_A_Favor_De.c_Texto = xrow(.c_A_Favor_De.c_NombreInterno)
                            .c_AutomaticoAgencia.c_Texto = xrow(.c_AutomaticoAgencia.c_NombreInterno)
                            .c_AutomaticoProveedor.c_Texto = xrow(.c_AutomaticoProveedor.c_NombreInterno)
                            .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                            .c_NumeroCta.c_Texto = xrow(.c_NumeroCta.c_NombreInterno)
                            .c_TipoCta.c_Texto = xrow(.c_TipoCta.c_NombreInterno)

                            'If Not IsDBNull(xrow("id_seguridad")) Then
                            '    .c_IdSeguridad = xrow("id_seguridad")
                            'End If
                        End With
                    Catch ex As Exception
                        Throw New Exception("CTAS BANCARIAS PROVEEDORES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Funcion: Permite Agregar Un Registro De la BD
                ''' </summary>
                Function F_AgregarCta(ByVal xcta As c_AgregarCta) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xauto As String = ""
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand(AgregarRegistro_0, xcon, xtr)
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_proveedor_cta_bancaria=0"
                                        xcmd.ExecuteNonQuery()
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_1
                                    xauto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@auto_agencia", xcta.RegistroDato.c_AutomaticoAgencia.c_Texto)
                                    xcmd.Parameters.AddWithValue("@numero", xcta.RegistroDato.c_NumeroCta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@auto_proveedor", xcta.RegistroDato.c_AutomaticoProveedor.c_Texto)
                                    xcmd.Parameters.AddWithValue("@tipo", xcta.RegistroDato.c_TipoCta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nombre_id", xcta.RegistroDato.c_A_Favor_De.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus", xcta.RegistroDato.c_Estatus.c_Texto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL AGREGAR CTA AL PROVEEDOR, EXISTE UNA CTA CON EL MISMO NUMERO")
                                ElseIf ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL AGREGAR CTA AL PROVEEDOR, PROVEEDOR FUE ELIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("CTAS BANCARIA - PROVEEDORES" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Eliminar Un Registro De la BD
                ''' </summary>
                Function F_EliminaCta(ByVal xautomatico As String) As Boolean
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
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("CTAS BANCARIAS - PROVEEDORES" + vbCrLf + "ELIMINAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Modificar Un Registro De La BD
                ''' </summary>
                Function F_ModificarCta(ByVal xctamodificar As c_ModificarCta) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(ModificarRegistro_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xctamodificar.RegistroDato.r_AutomaticoCta)
                                    xcmd.Parameters.AddWithValue("@auto_agencia", xctamodificar.RegistroDato.c_AutomaticoAgencia.c_Texto)
                                    xcmd.Parameters.AddWithValue("@numero", xctamodificar.RegistroDato.c_NumeroCta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@tipo", xctamodificar.RegistroDato.c_TipoCta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nombre_id", xctamodificar.RegistroDato.c_A_Favor_De.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus", xctamodificar.RegistroDato.c_Estatus.c_Texto)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR CTA BANCARIA, LA CTA HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR CTA BANCARIA, EXISTE UNA CTA CON EL MISMO NUMERO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("CTA BANCARIA - PROVEEDORES" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub New()
                    Me.RegistroDato = New c_Registro
                End Sub
            End Class

            Private xproveedor As c_Proveedor
            Private xgrupo As c_Grupos
            Private xctas As c_CtasBancarias

            Property f_Proveedor() As c_Proveedor
                Get
                    Return xproveedor
                End Get
                Set(ByVal value As c_Proveedor)
                    xproveedor = value
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

            Property f_CtasBancaria() As c_CtasBancarias
                Get
                    Return xctas
                End Get
                Set(ByVal value As c_CtasBancarias)
                    xctas = value
                End Set
            End Property

            Sub New()
                Me.f_Proveedor = New c_Proveedor
                Me.f_Grupos = New c_Grupos
                Me.f_CtasBancaria = New c_CtasBancarias
            End Sub

            ''' <summary>
            ''' Funcion: Buscar y Cargar Proveedor En Ficha Registro
            ''' </summary>
            Function F_BuscarProveedor(ByVal xauto As String) As Boolean
                Dim xr As Integer
                Try
                    Me.f_Proveedor.M_Limpiar_Tabla()
                    Using xadap As New SqlDataAdapter(c_Proveedor.Select_1, _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                        xr = xadap.Fill(Me.f_Proveedor.TablaDato)
                    End Using
                    If xr = 0 Then
                        Throw New Exception("PROVEEDOR NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                    Else
                        Me.f_Proveedor.M_CargarFicha()
                    End If
                    Return True
                Catch ex As Exception
                    Throw New Exception("PROVEEDOR" + vbCrLf + "BUSCAR PROVEEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Eliminar Un Proveedor Del Sistema
            ''' </summary>
            Function F_ProveedorElimina(ByVal xauto As String) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Dim EliminarRegistro As String = "delete proveedores where auto=@auto"
                            Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                xcmd.Parameters.AddWithValue("@auto", xauto)
                                xcmd.ExecuteNonQuery()
                            End Using
                            Return True
                        Catch ex2 As SqlException
                            If ex2.Number = 547 Then
                                Throw New Exception("ERROR AL ELIMINAR PROVEEDOR, PROVEEDOR TIENE MOVIMIENTOS EFECTUADOS")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROVEEDOR" + vbCrLf + "ELIMINAR PROVEEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Agregar Un Proveedor Nuevo Al Sistema
            ''' </summary>
            Function F_ProveedorNuevo(ByVal xproveedor As c_Proveedor.c_AgregarProveedor) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd0 As New SqlCommand("update contadores set a_proveedores=a_proveedores+1;select a_proveedores from contadores")
                Dim xcmd1 As New SqlCommand(c_Proveedor.InsertarProveedor)

                Try
                    With xcmd1
                        xproveedor.d_Registro.c_FechaAlta.c_Valor = Date.Today
                        xproveedor.d_Registro.c_FechaUltPago.c_Valor = Date.Today
                        xproveedor.d_Registro.c_FechaUltCompra.c_Valor = Date.Today
                        xproveedor.d_Registro.c_Estatus.c_Texto = "Activo"
                        xproveedor.d_Registro.c_TotalAnticipos.c_Valor = 0
                        xproveedor.d_Registro.c_TotalCreditos.c_Valor = 0
                        xproveedor.d_Registro.c_TotalDebitos.c_Valor = 0
                        xproveedor.d_Registro.c_TotalSaldo.c_Valor = 0

                        If xproveedor.d_Registro._EstatusCredito Then
                            xproveedor.d_Registro.c_CreditoDisponible.c_Valor = xproveedor.d_Registro.c_LimiteCredito.c_Valor
                        Else
                            xproveedor.d_Registro.c_CreditoDisponible.c_Valor = 0
                        End If

                        .Parameters.AddWithValue("@codigo", xproveedor.d_Registro.c_CodigoProveedor.c_Texto)
                        .Parameters.AddWithValue("@nombre", xproveedor.d_Registro.c_NombreRazonSocial.c_Texto)
                        .Parameters.AddWithValue("@ci_rif", xproveedor.d_Registro.c_RIF.c_Texto)
                        .Parameters.AddWithValue("@dir_fiscal", xproveedor.d_Registro.c_DirFiscal.c_Texto)
                        .Parameters.AddWithValue("@contacto", xproveedor.d_Registro.c_ContactarA.c_Texto)
                        .Parameters.AddWithValue("@telefono", xproveedor.d_Registro.c_Telefono.c_Texto)
                        .Parameters.AddWithValue("@email", xproveedor.d_Registro.c_Email.c_Texto)
                        .Parameters.AddWithValue("@credito", xproveedor.d_Registro.c_CreditoHabilitado.c_Texto)
                        .Parameters.AddWithValue("@dias_credito", xproveedor.d_Registro.c_DiasCredito.c_Valor)
                        .Parameters.AddWithValue("@limite_credito", xproveedor.d_Registro.c_LimiteCredito.c_Valor)
                        .Parameters.AddWithValue("@contable_cxp", xproveedor.d_Registro.c_ContableCXP.c_Texto)
                        .Parameters.AddWithValue("@contable_ingresos", xproveedor.d_Registro.c_ContableIngresos.c_Texto)
                        .Parameters.AddWithValue("@contable_anticipos", xproveedor.d_Registro.c_ContableAnticipos.c_Texto)
                        .Parameters.AddWithValue("@total_debitos", xproveedor.d_Registro.c_TotalDebitos.c_Valor)
                        .Parameters.AddWithValue("@total_creditos", xproveedor.d_Registro.c_TotalCreditos.c_Valor)
                        .Parameters.AddWithValue("@total_anticipos", xproveedor.d_Registro.c_TotalAnticipos.c_Valor)
                        .Parameters.AddWithValue("@total_saldo", xproveedor.d_Registro.c_TotalSaldo.c_Valor)
                        .Parameters.AddWithValue("@credito_disponible", xproveedor.d_Registro.c_CreditoDisponible.c_Valor)
                        .Parameters.AddWithValue("@auto_grupo", xproveedor.d_Registro.c_AutoGrupo.c_Texto)
                        .Parameters.AddWithValue("@denominacion_fiscal", xproveedor.d_Registro.c_DenominacionFiscal.c_Texto)
                        .Parameters.AddWithValue("@retencion_iva", xproveedor.d_Registro.c_RetencionIVA.c_Valor)
                        .Parameters.AddWithValue("@retencion_islr", xproveedor.d_Registro.c_RetencionISLR.c_Valor)
                        .Parameters.AddWithValue("@comentarios", xproveedor.d_Registro.c_Comentarios.c_Texto)
                        .Parameters.AddWithValue("@advertencia", xproveedor.d_Registro.c_Advertencia.c_Texto)
                        .Parameters.AddWithValue("@estatus", xproveedor.d_Registro.c_Estatus.c_Texto)
                        .Parameters.AddWithValue("@fecha_ult_compra", xproveedor.d_Registro.c_FechaUltCompra.c_Valor)
                        .Parameters.AddWithValue("@fecha_ult_pago", xproveedor.d_Registro.c_FechaUltPago.c_Valor)
                        .Parameters.AddWithValue("@website", xproveedor.d_Registro.c_WebSite.c_Texto)
                        .Parameters.AddWithValue("@doc_pendientes", xproveedor.d_Registro.c_DocPendientesPermitido.c_Valor)
                        .Parameters.AddWithValue("@fecha_alta", xproveedor.d_Registro.c_FechaAlta.c_Valor)
                        .Parameters.AddWithValue("@Telefono_1", xproveedor.d_Registro.c_Telefono_1.c_Texto)
                        .Parameters.AddWithValue("@Telefono_2", xproveedor.d_Registro.c_Telefono_2.c_Texto)
                        .Parameters.AddWithValue("@Telefono_3", xproveedor.d_Registro.c_Telefono_3.c_Texto)
                        .Parameters.AddWithValue("@Telefono_4", xproveedor.d_Registro.c_Telefono_4.c_Texto)
                        .Parameters.AddWithValue("@Celular_1", xproveedor.d_Registro.c_Celular_1.c_Texto)
                        .Parameters.AddWithValue("@Celular_2", xproveedor.d_Registro.c_Celular_2.c_Texto)
                        .Parameters.AddWithValue("@Fax_1", xproveedor.d_Registro.c_Fax_1.c_Texto)
                        .Parameters.AddWithValue("@Fax_2", xproveedor.d_Registro.c_Fax_2.c_Texto)
                        .Parameters.AddWithValue("@tipoorigen", xproveedor.d_Registro.c_TipoOrigen.c_Texto)
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            xtr = xcon.BeginTransaction

                            'CONTADORES
                            Using xcmd0
                                xcmd0.Connection = xcon
                                xcmd0.Transaction = xtr
                                xproveedor.d_Registro.c_Automatico.c_Texto = xcmd0.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                            End Using

                            'GRABO EL PROVEEDOR
                            Using xcmd1
                                xcmd1.Connection = xcon
                                xcmd1.Transaction = xtr
                                xcmd1.Parameters.AddWithValue("@auto", xproveedor.d_Registro.c_Automatico.c_Texto)
                                xcmd1.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Nombre, Codigo, Rif o CI Del Proveedor. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent ProveedorNuevo(xproveedor.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("PROVEEDOR" + vbCrLf + "INSERTAR PROVEEDOR" + vbCrLf + ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Funcion: Permite Modificar Un Cliente Del Sistema
            ''' </summary>
            Function F_ProveedorModifica(ByVal xproveedor As c_Proveedor.c_ModificarProveedor) As Boolean
                Dim xtr As SqlTransaction = Nothing
                Dim xcmd1 As New SqlCommand(c_Proveedor.ModificarProveedor_1)

                Try
                    With xcmd1
                        .Parameters.AddWithValue("@codigo", xproveedor.d_Registro.c_CodigoProveedor.c_Texto)
                        .Parameters.AddWithValue("@nombre", xproveedor.d_Registro.c_NombreRazonSocial.c_Texto)
                        .Parameters.AddWithValue("@ci_rif", xproveedor.d_Registro.c_RIF.c_Texto)
                        .Parameters.AddWithValue("@dir_fiscal", xproveedor.d_Registro.c_DirFiscal.c_Texto)
                        .Parameters.AddWithValue("@contacto", xproveedor.d_Registro.c_ContactarA.c_Texto)
                        .Parameters.AddWithValue("@telefono", xproveedor.d_Registro.c_Telefono.c_Texto)
                        .Parameters.AddWithValue("@email", xproveedor.d_Registro.c_Email.c_Texto)
                        .Parameters.AddWithValue("@credito", xproveedor.d_Registro.c_CreditoHabilitado.c_Texto)
                        .Parameters.AddWithValue("@dias_credito", xproveedor.d_Registro.c_DiasCredito.c_Valor)
                        .Parameters.AddWithValue("@limite_credito", xproveedor.d_Registro.c_LimiteCredito.c_Valor)
                        .Parameters.AddWithValue("@contable_cxp", xproveedor.d_Registro.c_ContableCXP.c_Texto)
                        .Parameters.AddWithValue("@contable_ingresos", xproveedor.d_Registro.c_ContableIngresos.c_Texto)
                        .Parameters.AddWithValue("@contable_anticipos", xproveedor.d_Registro.c_ContableAnticipos.c_Texto)
                        .Parameters.AddWithValue("@auto_grupo", xproveedor.d_Registro.c_AutoGrupo.c_Texto)
                        .Parameters.AddWithValue("@denominacion_fiscal", xproveedor.d_Registro.c_DenominacionFiscal.c_Texto)
                        .Parameters.AddWithValue("@retencion_iva", xproveedor.d_Registro.c_RetencionIVA.c_Valor)
                        .Parameters.AddWithValue("@retencion_islr", xproveedor.d_Registro.c_RetencionISLR.c_Valor)
                        .Parameters.AddWithValue("@comentarios", xproveedor.d_Registro.c_Comentarios.c_Texto)
                        .Parameters.AddWithValue("@advertencia", xproveedor.d_Registro.c_Advertencia.c_Texto)
                        .Parameters.AddWithValue("@estatus", xproveedor.d_Registro.c_Estatus.c_Texto)
                        .Parameters.AddWithValue("@website", xproveedor.d_Registro.c_WebSite.c_Texto)
                        .Parameters.AddWithValue("@doc_pendientes", xproveedor.d_Registro.c_DocPendientesPermitido.c_Valor)
                        .Parameters.AddWithValue("@Telefono_1", xproveedor.d_Registro.c_Telefono_1.c_Texto)
                        .Parameters.AddWithValue("@Telefono_2", xproveedor.d_Registro.c_Telefono_2.c_Texto)
                        .Parameters.AddWithValue("@Telefono_3", xproveedor.d_Registro.c_Telefono_3.c_Texto)
                        .Parameters.AddWithValue("@Telefono_4", xproveedor.d_Registro.c_Telefono_4.c_Texto)
                        .Parameters.AddWithValue("@Celular_1", xproveedor.d_Registro.c_Celular_1.c_Texto)
                        .Parameters.AddWithValue("@Celular_2", xproveedor.d_Registro.c_Celular_2.c_Texto)
                        .Parameters.AddWithValue("@Fax_1", xproveedor.d_Registro.c_Fax_1.c_Texto)
                        .Parameters.AddWithValue("@Fax_2", xproveedor.d_Registro.c_Fax_2.c_Texto)
                        .Parameters.AddWithValue("@tipoorigen", xproveedor.d_Registro.c_TipoOrigen.c_Texto)
                        .Parameters.AddWithValue("@auto", xproveedor.d_Registro.c_Automatico.c_Texto)
                        .Parameters.AddWithValue("@id_seguridad", xproveedor.d_Registro.c_IdSeguridad)
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
                                    Throw New Exception("Error Al Actualizar Datos Del Proveedor, Otro Usuario Ya Actualizo Los Datos, Verifique Por Favor")
                                End If
                            End Using

                            Using xcmd2 As New SqlCommand(c_Proveedor.ModificarProveedor_2, xcon, xtr)
                                With xcmd2
                                    .Parameters.AddWithValue("@auto", xproveedor.d_Registro.c_Automatico.c_Texto)
                                End With
                                xcmd2.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            If ex2.Number = 3609 Then
                                Throw New Exception("Error Al Intentar Registrar Nombre, Codigo, Rif o CI Del Proveedor. Ya Registrado, Verifique Por Favor")
                            Else
                                Throw New Exception(ex2.Message)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                    RaiseEvent ProveedorNuevo(xproveedor.d_Registro.c_Automatico.c_Texto)
                    Return True
                Catch ex As Exception
                    Throw New ExecutionEngineException("PROVEEDOR" + vbCrLf + "MODIFICAR PROVEEDOR" + vbCrLf + ex.Message)
                End Try
            End Function
        End Class

        Private xfichaProveedor As FichaProveedores

        ''' <summary>
        ''' Ficha General Proveedores
        ''' </summary>
        Property f_FichaProveedores() As FichaProveedores
            Get
                Return xfichaproveedor
            End Get
            Set(ByVal value As FichaProveedores)
                xfichaproveedor = value
            End Set
        End Property
    End Class
End Namespace
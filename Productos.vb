Imports System.Data
Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' CLASE GENERAL PRODUCTOS
        ''' </summary>
        Public Class FichaProducto
            ''' <summary>
            ''' Define Los Tipos De Busqueda Para El Producto
            ''' </summary>
            Public Enum TipoBusquedaProducto As Integer
                PorCodBarra = 0
                PorCodigo = 1
                PorDescripcion = 2
                PorPlu = 3
                PorReferencia = 4
                PorNumParte = 5
                PorSerial = 6
                PorCodigoProveedor = 7
            End Enum

            ''' <summary>
            ''' CLASE PRODUCTOS
            ''' </summary>
            Class Prd_Producto
                Event _ActualizarFicha()
                Event _ProductoRegistrado(ByVal xauto As String)
                Event _ActualizarPrecios()

                Class c_AgregarProducto
                    Private xregistro As c_Registro
                    Private xdeposito As String
                    Private xhora As String
                    Private xequipoestacion As String
                    Private xfichausu As FichaGlobal.c_Usuario.c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        _AutoDepositoDefecto = ""
                        _Equipoestacion = ""
                        _Hora = ""
                        _FichaUsuario = Nothing
                        RegistroDato = New c_Registro
                    End Sub

                    Property _Equipoestacion() As String
                        Protected Friend Get
                            Return xequipoestacion.Trim
                        End Get
                        Set(ByVal value As String)
                            xequipoestacion = value
                        End Set
                    End Property

                    Property _Hora() As String
                        Protected Friend Get
                            Return xhora.Trim
                        End Get
                        Set(ByVal value As String)
                            xhora = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return xfichausu
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xfichausu = value
                        End Set
                    End Property

                    Property _AutoDepositoDefecto() As String
                        Protected Friend Get
                            Return xdeposito
                        End Get
                        Set(ByVal value As String)
                            xdeposito = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoProducto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _DescripcionGeneral() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreProducto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _DescripcionResumen() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreProductoResumen.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoDepartamento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoDepartamento.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoGrupo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoSubGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoSubGrupo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoMarca() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoMarca.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoEmpqCompra() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoEmpqVenta() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TipoImpuesto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TipoImpuesto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TasaIva() As Single
                        Set(ByVal value As Single)
                            Me.RegistroDato.c_TasaImpuesto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroDato.c_EstatusProducto.c_Texto = "Activo"
                            Else
                                Me.RegistroDato.c_EstatusProducto.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property
                    WriteOnly Property _FechaAlta() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaAlta.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _ContenidoEmpqCompra() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_ContEmpCompra.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _ContenidoEmpqVentaDetal() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_ContEmpVentaDetal.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Origen() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_OrigenProducto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Categoria() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CategoriaProducto.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaPrincipalProducto
                    Inherits c_AgregarProducto

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaModificacion() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaUltCambio.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property

                    Sub New()
                        MyBase.New()
                    End Sub
                End Class

                Class c_AgregarDepartamentoPtoventas
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _NombreNuevoDeptoPtoVenta() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreProducto.c_Texto = value
                            Me.RegistroDato.c_NombreProductoResumen.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoDepartamento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoDepartamento.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoGrupo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoMarca() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoMarca.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoEmpqCompra() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoEmpqVenta() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TipoImpuesto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_TipoImpuesto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TasaIva() As Single
                        Set(ByVal value As Single)
                            Me.RegistroDato.c_TasaImpuesto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroDato.c_EstatusProducto.c_Texto = "Activo"
                            Else
                                Me.RegistroDato.c_EstatusProducto.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property
                    WriteOnly Property _FechaAlta() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaAlta.c_Valor = value
                        End Set
                    End Property
                End Class

                Class c_ModificarDepartamentoPtoVentas
                    Inherits c_AgregarDepartamentoPtoventas

                    Sub New()
                        MyBase.New()
                    End Sub

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaBalanza
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _EstatusBalanza() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroDato.c_EstatusBalanza.c_Texto = "1"
                            Else
                                Me.RegistroDato.c_EstatusBalanza.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _CodigoPLU() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_PLU.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _TipoPesado() As TipoProductoBalanza
                        Set(ByVal value As TipoProductoBalanza)
                            If value = TipoProductoBalanza.Pesado Then
                                Me.RegistroDato.c_PesadoUnidad.c_Texto = "P"
                            Else
                                Me.RegistroDato.c_PesadoUnidad.c_Texto = "U"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaLicor
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _EstatusLicor() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroDato.c_EstatusLicor.c_Texto = "1"
                            Else
                                Me.RegistroDato.c_EstatusLicor.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _CapacidadBotella() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_CapacidadBotella.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _GradosAlcohol() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_GradosAlchohol.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _TasaLicor() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaLicor.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaGarantia
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _EstatusGarantia() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroDato.c_EstatusGarantia.c_Texto = "1"
                            Else
                                Me.RegistroDato.c_EstatusGarantia.c_Texto = "0"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _DiasGarantia() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_DiasGarantia.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaDimensiones
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _Alto() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Alto.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Ancho() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Ancho.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Largo() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Largo.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Peso() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_Peso.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoArancel() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoArancel.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TasaArancel() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_TasaArancel.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaContabilidad
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _CtaContable() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CtaContable.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaDetalle
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
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

                    WriteOnly Property _Modelo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Modelo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Referencia() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Referencia.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NumParte() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroParte.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_ModificarCosto
                    Private xregistro As FichaProducto.Prd_HistoricoPrecios.c_Registro
                    Private xfichausu As FichaGlobal.c_Usuario.c_Registro
                    Private xidseguridad As Byte()

                    Protected Friend Property RegistroDato() As FichaProducto.Prd_HistoricoPrecios.c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As FichaProducto.Prd_HistoricoPrecios.c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        _FichaUsuario = Nothing
                        RegistroDato = New FichaProducto.Prd_HistoricoPrecios.c_Registro
                    End Sub

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaMovimiento() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaMovimiento.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoAnterior() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_PrecioAnterior.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _CostoNuevo() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_PrecioNuevo.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EmpaqueMedida() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Empaque.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Equipoestacion() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_EstacionEquipo.c_Texto = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return xfichausu
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xfichausu = value
                        End Set
                    End Property

                    WriteOnly Property _Hora() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Hora.c_Texto = value
                        End Set
                    End Property

                    Property _IdSeguridad() As Byte()
                        Protected Friend Get
                            Return xidseguridad
                        End Get
                        Set(ByVal value As Byte())
                            xidseguridad = value
                        End Set
                    End Property

                    WriteOnly Property _ContenidoEmpaque() As Integer
                        Set(ByVal value As Integer)
                            Me.RegistroDato.c_ContenidoEmpaque.c_Valor = value
                        End Set
                    End Property
                End Class

                Class c_ModificarFichaEventoPresupuesto
                    Private xauto As String
                    Private xid As Byte()
                    Private xestatus As Boolean
                    Private xcantidad As Decimal

                    Property _AutoPrd() As String
                        Get
                            Return xauto
                        End Get
                        Set(ByVal value As String)
                            xauto = value
                        End Set
                    End Property

                    Property _ID() As Byte()
                        Get
                            Return xid
                        End Get
                        Set(ByVal value As Byte())
                            xid = value
                        End Set
                    End Property

                    Property _HabilitarParaPresupuestoEvento() As Boolean
                        Get
                            Return xestatus
                        End Get
                        Set(ByVal value As Boolean)
                            xestatus = value
                        End Set
                    End Property

                    Property _CantidadConsumoPorPersona() As Decimal
                        Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoPrd = ""
                        Me._CantidadConsumoPorPersona = 0
                        Me._HabilitarParaPresupuestoEvento = False
                    End Sub
                End Class

                Class c_ModificarFichaEstatusProducto
                    Private xauto As String
                    Private xid As Byte()
                    Private xregulado As TipoSiNo
                    Private xrestringido As TipoSiNo

                    Property _AutoPrd() As String
                        Get
                            Return xauto
                        End Get
                        Set(ByVal value As String)
                            xauto = value
                        End Set
                    End Property

                    Property _ID() As Byte()
                        Get
                            Return xid
                        End Get
                        Set(ByVal value As Byte())
                            xid = value
                        End Set
                    End Property

                    Property _Regulado() As TipoSiNo
                        Get
                            Return xregulado
                        End Get
                        Set(ByVal value As TipoSiNo)
                            xregulado = value
                        End Set
                    End Property

                    Property _Restringido() As TipoSiNo
                        Get
                            Return xrestringido
                        End Get
                        Set(ByVal value As TipoSiNo)
                            xrestringido = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoPrd = ""
                        Me._ID = Nothing
                        Me._Regulado = TipoSiNo.No
                        Me._Restringido = TipoSiNo.No
                    End Sub
                End Class


                Class c_AgregarProductoDeposito
                    Private xprd As String
                    Private xdep As String

                    Property _AutoDeposito() As String
                        Protected Friend Get
                            Return xdep
                        End Get
                        Set(ByVal value As String)
                            xdep = value
                        End Set
                    End Property

                    Property _AutoProducto() As String
                        Protected Friend Get
                            Return xprd
                        End Get
                        Set(ByVal value As String)
                            xprd = value
                        End Set
                    End Property

                    Sub New()
                        _AutoDeposito = ""
                        _AutoProducto = ""
                    End Sub
                End Class

                Class c_ModificarDatosDeposito
                    Private xficha_productodeposito As FichaProducto.Prd_Deposito.c_Registro
                    Private xub1 As String
                    Private xub2 As String
                    Private xub3 As String
                    Private xub4 As String
                    Private xniv_minimo As Decimal
                    Private xniv_optimo As Decimal

                    Property _Ubicacion1() As String
                        Protected Friend Get
                            Return Me.xub1
                        End Get
                        Set(ByVal value As String)
                            Me.xub1 = value
                        End Set
                    End Property

                    Property _Ubicacion2() As String
                        Protected Friend Get
                            Return Me.xub2
                        End Get
                        Set(ByVal value As String)
                            Me.xub2 = value
                        End Set
                    End Property

                    Property _Ubicacion3() As String
                        Protected Friend Get
                            Return Me.xub3
                        End Get
                        Set(ByVal value As String)
                            Me.xub3 = value
                        End Set
                    End Property

                    Property _Ubicacion4() As String
                        Protected Friend Get
                            Return Me.xub4
                        End Get
                        Set(ByVal value As String)
                            Me.xub4 = value
                        End Set
                    End Property

                    Property _NivelMinimo() As Decimal
                        Protected Friend Get
                            Return Me.xniv_minimo
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xniv_minimo = value
                        End Set
                    End Property

                    Property _NivelOptimo() As Decimal
                        Protected Friend Get
                            Return Me.xniv_optimo
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xniv_optimo = value
                        End Set
                    End Property

                    Property _FichaProductoDeposito() As FichaProducto.Prd_Deposito.c_Registro
                        Get
                            Return Me.xficha_productodeposito
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Deposito.c_Registro)
                            Me.xficha_productodeposito = value
                        End Set
                    End Property

                    Sub New()
                        Me._NivelMinimo = 0
                        Me._NivelOptimo = 0
                        Me._Ubicacion1 = ""
                        Me._Ubicacion2 = ""
                        Me._Ubicacion3 = ""
                        Me._Ubicacion4 = ""
                        Me._FichaProductoDeposito = Nothing
                    End Sub
                End Class

                Class c_ProductoOferta
                    Private xautoproducto As String
                    Private xidseguidad As Byte()
                    Private xinicio As Date
                    Private xfin As Date
                    Private xpreciooferta As Decimal
                    Private xutilidadoferta As Decimal
                    Private xfecha As Date

                    Property _IdSeguridadProducto() As Byte()
                        Protected Friend Get
                            Return xidseguidad
                        End Get
                        Set(ByVal value As Byte())
                            xidseguidad = value
                        End Set
                    End Property

                    Property _AutoProducto() As String
                        Protected Friend Get
                            Return xautoproducto
                        End Get
                        Set(ByVal value As String)
                            xautoproducto = value
                        End Set
                    End Property

                    Property _InicioOferta() As Date
                        Protected Friend Get
                            Return xinicio
                        End Get
                        Set(ByVal value As Date)
                            xinicio = value
                        End Set
                    End Property

                    Property _FinOferta() As Date
                        Protected Friend Get
                            Return xfin
                        End Get
                        Set(ByVal value As Date)
                            xfin = value
                        End Set
                    End Property

                    Property _PrecioOferta() As Decimal
                        Protected Friend Get
                            Return xpreciooferta
                        End Get
                        Set(ByVal value As Decimal)
                            xpreciooferta = value
                        End Set
                    End Property

                    Property _UtilidadOferta() As Decimal
                        Protected Friend Get
                            Return xutilidadoferta
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidadoferta = value
                        End Set
                    End Property

                    Property _Fecha() As Date
                        Protected Friend Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoProducto = ""
                        Me._InicioOferta = Date.MinValue
                        Me._FinOferta = Date.MinValue
                        Me._PrecioOferta = 0
                        Me._UtilidadOferta = 0
                        Me._Fecha = Date.MinValue
                    End Sub
                End Class

                Public Class c_AgregarPrecioEmpaque
                    Private xreferencia As String
                    Private xprecioanterior_1 As Decimal
                    Private xprecioanterior_2 As Decimal
                    Private xprecionuevo_1 As Decimal
                    Private xprecionuevo_2 As Decimal
                    Private xutilidadprecio_1 As Decimal
                    Private xutilidadprecio_2 As Decimal
                    Private xcontenido As Integer
                    Private xid As Byte()
                    Private xfichamedida As FichaProducto.Prd_Medida.c_Registro

                    Sub New()
                        _PrecioAnterior_1 = 0
                        _PrecioAnterior_2 = 0
                        _PrecioNuevo_1 = 0
                        _PrecioNuevo_2 = 0
                        _UtilidadPrecio_1 = 0
                        _UtilidadPrecio_2 = 0
                        _ContenidoEmpaque = 0
                        _PrecioReferencia = ""

                        _FichaMedidaEmpaque = New FichaProducto.Prd_Medida.c_Registro
                    End Sub

                    Property _PrecioReferencia() As String
                        Protected Friend Get
                            Return xreferencia
                        End Get
                        Set(ByVal value As String)
                            xreferencia = value
                        End Set
                    End Property

                    Property _FichaMedidaEmpaque() As FichaProducto.Prd_Medida.c_Registro
                        Protected Friend Get
                            Return xfichamedida
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Medida.c_Registro)
                            xfichamedida = value
                        End Set
                    End Property

                    Property _ContenidoEmpaque() As Integer
                        Get
                            Return xcontenido
                        End Get
                        Set(ByVal value As Integer)
                            xcontenido = value
                        End Set
                    End Property

                    Property _IdSeguridad() As Byte()
                        Protected Friend Get
                            Return xid
                        End Get
                        Set(ByVal value As Byte())
                            xid = value
                        End Set
                    End Property

                    Property _PrecioAnterior_1() As Decimal
                        Protected Friend Get
                            Return xprecioanterior_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecioanterior_1 = value
                        End Set
                    End Property

                    Property _PrecioAnterior_2() As Decimal
                        Protected Friend Get
                            Return xprecioanterior_2
                        End Get
                        Set(ByVal value As Decimal)
                            xprecioanterior_2 = value
                        End Set
                    End Property

                    Property _PrecioNuevo_1() As Decimal
                        Protected Friend Get
                            Return xprecionuevo_1
                        End Get
                        Set(ByVal value As Decimal)
                            xprecionuevo_1 = value
                        End Set
                    End Property

                    Property _PrecioNuevo_2() As Decimal
                        Protected Friend Get
                            Return xprecionuevo_2
                        End Get
                        Set(ByVal value As Decimal)
                            xprecionuevo_2 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio_1() As Decimal
                        Get
                            Return xutilidadprecio_1
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidadprecio_1 = value
                        End Set
                    End Property

                    Property _UtilidadPrecio_2() As Decimal
                        Get
                            Return xutilidadprecio_2
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidadprecio_2 = value
                        End Set
                    End Property
                End Class

                Class Detal
                    Private xfichamedidaventa As FichaProducto.Prd_Medida.c_Registro
                    Private xcontenidoempaqueventa As Integer
                    Private xprecioventa As Decimal
                    Private xutilidadventa As Decimal
                    Private xpvs As Decimal
                    Private xestatusoferta As TipoEstatus
                    Private xinicio As Date
                    Private xfin As Date
                    Private xpreciooferta As Decimal
                    Private xutilidadoferta As Decimal
                    Private xprecioanterior As Decimal

                    Property _FichaMedidaEmpaqueVenta() As FichaProducto.Prd_Medida.c_Registro
                        Protected Friend Get
                            Return xfichamedidaventa
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Medida.c_Registro)
                            xfichamedidaventa = value
                        End Set
                    End Property

                    Property _ContenidoEmpaqueVenta() As Integer
                        Protected Friend Get
                            Return xcontenidoempaqueventa
                        End Get
                        Set(ByVal value As Integer)
                            xcontenidoempaqueventa = value
                        End Set
                    End Property

                    Property _PrecioVenta() As Decimal
                        Protected Friend Get
                            Return xprecioventa
                        End Get
                        Set(ByVal value As Decimal)
                            xprecioventa = value
                        End Set
                    End Property

                    Property _UtilidadVenta() As Decimal
                        Protected Friend Get
                            Return xutilidadventa
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidadventa = value
                        End Set
                    End Property

                    Property _PrecioSugerido() As Decimal
                        Protected Friend Get
                            Return xpvs
                        End Get
                        Set(ByVal value As Decimal)
                            xpvs = value
                        End Set
                    End Property

                    Property _EstatusOferta() As TipoEstatus
                        Protected Friend Get
                            Return xestatusoferta
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatusoferta = value
                        End Set
                    End Property

                    Property _InicioOferta() As Date
                        Protected Friend Get
                            Return xinicio
                        End Get
                        Set(ByVal value As Date)
                            xinicio = value
                        End Set
                    End Property

                    Property _FinOferta() As Date
                        Protected Friend Get
                            Return xfin
                        End Get
                        Set(ByVal value As Date)
                            xfin = value
                        End Set
                    End Property

                    Property _PrecioOferta() As Decimal
                        Protected Friend Get
                            Return xpreciooferta
                        End Get
                        Set(ByVal value As Decimal)
                            xpreciooferta = value
                        End Set
                    End Property

                    Property _UtilidadOferta() As Decimal
                        Protected Friend Get
                            Return xutilidadoferta
                        End Get
                        Set(ByVal value As Decimal)
                            xutilidadoferta = value
                        End Set
                    End Property

                    Property _PrecioAnterior() As Decimal
                        Protected Friend Get
                            Return xprecioanterior
                        End Get
                        Set(ByVal value As Decimal)
                            xprecioanterior = value
                        End Set
                    End Property

                    Sub New()
                        _FichaMedidaEmpaqueVenta = New FichaProducto.Prd_Medida.c_Registro
                        _ContenidoEmpaqueVenta = 0
                        _PrecioOferta = 0
                        _PrecioSugerido = 0
                        _PrecioVenta = 0
                        _UtilidadOferta = 0
                        _UtilidadVenta = 0
                        _InicioOferta = Date.MinValue
                        _FinOferta = Date.MinValue
                        _EstatusOferta = TipoEstatus.Inactivo
                        _PrecioAnterior = 0
                    End Sub
                End Class

                Class ActualizarPrecioMayor
                    Private xhora As String
                    Private xfecha As Date
                    Private xestacion As String
                    Private xautoproducto As String
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xlistaprecios As List(Of c_AgregarPrecioEmpaque)
                    Private xdetal As Detal
                    Private xtipoprecio As FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios
                    Private xidseguidad As Byte()

                    Property _IdSeguridadProducto() As Byte()
                        Protected Friend Get
                            Return xidseguidad
                        End Get
                        Set(ByVal value As Byte())
                            xidseguidad = value
                        End Set
                    End Property

                    Property _AutoProducto() As String
                        Protected Friend Get
                            Return xautoproducto
                        End Get
                        Set(ByVal value As String)
                            xautoproducto = value
                        End Set
                    End Property

                    Property _Fecha() As Date
                        Protected Friend Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Property _Hora() As String
                        Protected Friend Get
                            Return xhora
                        End Get
                        Set(ByVal value As String)
                            xhora = value
                        End Set
                    End Property

                    Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                        Protected Friend Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _ListaEmpaquesMayor() As List(Of c_AgregarPrecioEmpaque)
                        Get
                            Return xlistaprecios
                        End Get
                        Set(ByVal value As List(Of c_AgregarPrecioEmpaque))
                            xlistaprecios = value
                        End Set
                    End Property

                    Property _VentaDetal() As Detal
                        Get
                            Return xdetal
                        End Get
                        Set(ByVal value As Detal)
                            xdetal = value
                        End Set
                    End Property

                    Property _TipoPrecioModificar() As FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios
                        Protected Friend Get
                            Return xtipoprecio
                        End Get
                        Set(ByVal value As FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios)
                            xtipoprecio = value
                        End Set
                    End Property

                    Sub New()
                        _AutoProducto = ""
                        _Fecha = Date.MinValue
                        _Hora = ""
                        _EquipoEstacion = ""
                        _FichaUsuario = New FichaGlobal.c_Usuario.c_Registro
                        _ListaEmpaquesMayor = New List(Of c_AgregarPrecioEmpaque)
                        _VentaDetal = New Detal
                        _TipoPrecioModificar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos
                    End Sub
                End Class



                Class c_Registro

#Region "Definicion"
                    Private xtb_0 As DataTable
                    Private xtb_1 As DataTable
                    Private xtb_2 As DataTable
                    Private xtb_3 As DataTable
                    Private xtb_4 As DataTable

                    Private f_auto As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_nombre_corto As CampoTexto
                    Private f_auto_departamento As CampoTexto
                    Private f_auto_grupo As CampoTexto
                    Private f_auto_subgrupo As CampoTexto
                    Private f_impuesto As CampoTexto
                    Private f_auto_medida_compra As CampoTexto
                    Private f_auto_medida_venta As CampoTexto

                    Private f_factor_existencia As CampoInteger
                    Private f_costo_proveedor_compra As CampoSingle
                    Private f_costo_proveedor_inventario As CampoSingle
                    Private f_costo_importacion_compra As CampoSingle
                    Private f_costo_importacion_inventario As CampoSingle
                    Private f_costo_varios_compra As CampoSingle
                    Private f_costo_varios_inventario As CampoSingle
                    Private f_costo_compra As CampoSingle
                    Private f_costo_inventario As CampoSingle
                    Private f_costo_promedio_compra As CampoSingle
                    Private f_costo_promedio_inventario As CampoSingle

                    Private f_estatus_empaque As CampoTexto
                    Private f_utilidad_1 As CampoSingle
                    Private f_utilidad_2 As CampoSingle
                    Private f_utilidad_3 As CampoSingle
                    Private f_utilidad_4 As CampoSingle
                    Private f_precio_1 As CampoSingle
                    Private f_precio_2 As CampoSingle
                    Private f_precio_3 As CampoSingle
                    Private f_precio_4 As CampoSingle
                    Private f_por_llegar As CampoSingle

                    Private f_estatus_balanza As CampoTexto
                    Private f_plu As CampoTexto
                    Private f_pesado_unidad As CampoTexto
                    Private f_estatus_envasado As CampoTexto
                    Private f_dias_envasado As CampoInteger
                    Private f_extra_1 As CampoTexto
                    Private f_dias_garantia As CampoInteger
                    Private f_modelo As CampoTexto
                    Private f_comentarios As CampoTexto
                    Private f_fecha_cambio_precio As CampoFecha
                    Private f_referencia As CampoTexto
                    Private f_contenido_empaque As CampoInteger
                    Private f_psv As CampoSingle
                    Private f_contable_producto As CampoTexto
                    Private f_contenido_empaque_venta As CampoInteger

                    Private f_estatus As CampoTexto
                    Private f_advertencia As CampoTexto
                    Private f_fecha_alta As CampoFecha
                    Private f_extra_2 As CampoTexto
                    Private f_categoria As CampoTexto
                    Private f_origen As CampoTexto
                    Private f_alto As CampoSingle
                    Private f_largo As CampoSingle
                    Private f_ancho As CampoSingle
                    Private f_peso As CampoSingle
                    Private f_codigo_arancel As CampoTexto
                    Private f_tasa_arancel As CampoSingle
                    Private f_auto_marca As CampoTexto
                    Private f_estatus_garantia As CampoTexto
                    Private f_estatus_serial As CampoTexto
                    Private f_precio_pto_venta As CampoSingle
                    Private f_utilidad_pto_venta As CampoSingle
                    Private f_estatus_licor As CampoTexto
                    Private f_capacidad As CampoSingle
                    Private f_grados As CampoSingle
                    Private f_tasa_licor As CampoSingle
                    Private f_estatus_oferta As CampoTexto
                    Private f_inicio As CampoFecha
                    Private f_fin As CampoFecha
                    Private f_precio_oferta As CampoSingle

                    Private f_etiqueta As CampoTexto
                    Private f_publicidad As CampoTexto
                    Private f_utilidad_oferta As CampoSingle
                    Private f_tasa As CampoSingle
                    Private f_medida_precio_1 As CampoTexto
                    Private f_medida_precio_2 As CampoTexto
                    Private f_medida_precio_3 As CampoTexto
                    Private f_medida_precio_4 As CampoTexto
                    Private f_medida_precio_pto_venta As CampoTexto
                    Private f_estatus_corte As CampoTexto
                    Private f_corte As CampoTexto
                    Private f_estatus_website As CampoTexto
                    Private f_detalle As CampoTexto
                    Private f_estatus_departamento As CampoTexto

                    'Campos Nuevos
                    Private f_estatus_replica As CampoTexto
                    Private f_numero_parte As CampoTexto
                    Private f_idseguridad As Byte()
                    Private f_estatus_foto As CampoTexto

                    Private f_estatus_consumo As CampoTexto
                    Private f_cant_consumo As CampoDecimal

                    '25/11/2014
                    Private f_EstaRegulado As CampoTexto
                    Private f_EstaRestringidoVenta As CampoTexto

                    Private xcostoproveedorcompra As PrecioCosto
                    Private xcostoimpcompra As PrecioCosto
                    Private xcostopromediocompra As PrecioCosto
                    Private xcostovariocompra As PrecioCosto
                    Private xpreciooferta As Precio
                    Private xpreciodetal As Precio
#End Region

#Region "Propiedades"
                    ''' <summary>
                    ''' Campo Automatico Del Producto
                    ''' </summary>
                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_Automatico.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Codigo Administrativo Asignado Al Producto
                    ''' </summary>
                    Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return Me.c_CodigoProducto.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Descripcion Detallada Del Producto
                    ''' </summary>
                    Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _DescripcionDetallaDelProducto() As String
                        Get
                            Return Me.c_NombreProducto.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Descripcion Corta Del Producto
                    ''' </summary>
                    Property c_NombreProductoResumen() As CampoTexto
                        Get
                            Return f_nombre_corto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre_corto = value
                        End Set
                    End Property

                    ReadOnly Property _DescripcionResumenDelProducto() As String
                        Get
                            If Me.c_NombreProductoResumen.c_Texto.Trim <> "" Then
                                Return Me.c_NombreProductoResumen.c_Texto
                            Else
                                Return Me.c_NombreProducto.c_Texto
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del Departamento
                    ''' </summary>
                    Protected Friend Property c_AutomaticoDepartamento() As CampoTexto
                        Get
                            Return f_auto_departamento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_departamento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDepartamento() As String
                        Get
                            Return Me.c_AutomaticoDepartamento.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreDepartamento() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_departamento where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoDepartamento)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del Grupo 
                    ''' </summary>
                    Protected Friend Property c_AutomaticoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_AutomaticoGrupo.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_grupo where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoGrupo)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del SubGrupo 
                    ''' </summary>
                    Protected Friend Property c_AutomaticoSubGrupo() As CampoTexto
                        Get
                            Return f_auto_subgrupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_subgrupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoSubGrupo() As String
                        Get
                            Return Me.c_AutomaticoSubGrupo.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreSubGrupo() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_subgrupo where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoSubGrupo)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    Sub SetTipoImpuesto(ByVal tipoImpuesto As String)
                        Me.f_impuesto.c_Texto = tipoImpuesto
                    End Sub

                    ''' <summary>
                    ''' Campo Tipo Impuesto Del Producto (0:Exento, 1:Tasa Vigente, 2:Tasa Reducida, 3:Otra Tasa)
                    ''' </summary>
                    Protected Friend Property c_TipoImpuesto() As CampoTexto
                        Get
                            Return f_impuesto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_impuesto = value
                        End Set
                    End Property

                    ReadOnly Property _TipoImpuesto() As TipoTasaImpuesto
                        Get
                            Dim xtipo As TipoTasaImpuesto
                            Integer.TryParse(Me.c_TipoImpuesto.c_Texto, xtipo)
                            Return xtipo
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Empaque De Compra
                    ''' </summary>
                    Protected Friend Property c_AutomaticoEmpaqueCompra() As CampoTexto
                        Get
                            Return f_auto_medida_compra
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_medida_compra = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEmpaqueCompra() As String
                        Get
                            Return Me.c_AutomaticoEmpaqueCompra.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaqueCompra() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueCompra)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _CantDecimalesEmpaqueCompra() As Integer
                        Get
                            Try
                                Dim xsql As String = "select decimales from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueCompra)
                                Dim xdec As Integer = 0

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Integer.TryParse(xcmd.ExecuteScalar().ToString, xdec)
                                    End Using
                                End Using

                                Return xdec
                            Catch ex As Exception
                                Return 0
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _ForzarUsoDecimalesEmpaqueCompra() As TipoSiNo
                        Get
                            Try
                                Dim xsql As String = "select forzar_decimales from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueCompra)
                                Dim xfor As String = ""

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        xfor = xcmd.ExecuteScalar().ToString
                                        If xfor.Trim.ToUpper = "0" Then
                                            Return TipoSiNo.No
                                        Else
                                            Return TipoSiNo.Si
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return TipoSiNo.No
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Empaque De Venta Detal :> PTO DE VENTA
                    ''' </summary>
                    Protected Friend Property c_AutomaticoEmpaqueVentaDetal() As CampoTexto
                        Get
                            Return f_auto_medida_venta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_medida_venta = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEmpaqueVentaDetal() As String
                        Get
                            Return Me.c_AutomaticoEmpaqueVentaDetal.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreEmpaqueVentaDetal() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueVentaDetal)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _CantDecimalesEmpaqueVentaDetal() As Integer
                        Get
                            Try
                                Dim xsql As String = "select decimales from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueVentaDetal)
                                Dim xdec As Integer = 0

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Integer.TryParse(xcmd.ExecuteScalar().ToString, xdec)
                                    End Using
                                End Using

                                Return xdec
                            Catch ex As Exception
                                Return 0
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _ForzarUsoDecimalesEmpaqueVentaDetal() As TipoSiNo
                        Get
                            Try
                                Dim xsql As String = "select forzar_decimales from productos_medida where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoEmpaqueCompra)
                                Dim xfor As String = ""

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        xfor = xcmd.ExecuteScalar().ToString
                                        If xfor.Trim.ToUpper = "0" Then
                                            Return TipoSiNo.No
                                        Else
                                            Return TipoSiNo.Si
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return TipoSiNo.No
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_FactorExistencia() As CampoInteger
                        Get
                            Return f_factor_existencia
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_factor_existencia = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Costo De Compra Proveedor Segun Factura
                    ''' </summary>
                    Protected Friend Property c_CostoProveedorCompra() As CampoSingle
                        Get
                            Return f_costo_proveedor_compra
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_proveedor_compra = value
                        End Set
                    End Property

                    Property _CostoProveedorCompra() As PrecioCosto
                        Get
                            Return xcostoproveedorcompra
                        End Get
                        Protected Friend Set(ByVal value As PrecioCosto)
                            xcostocompra = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_CostoProveedorInventario() As CampoSingle
                        Get
                            Return f_costo_proveedor_inventario
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_proveedor_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Costo De Importacion Segun Factura
                    ''' </summary>
                    Protected Friend Property c_CostoImportacionCompra() As CampoSingle
                        Get
                            Return f_costo_importacion_compra
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_importacion_compra = value
                        End Set
                    End Property

                    ReadOnly Property _CostoImportacionCompra() As PrecioCosto
                        Get
                            Return xcostoimpcompra
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_CostoImportacionInventario() As CampoSingle
                        Get
                            Return f_costo_importacion_inventario
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_importacion_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Otros Costos
                    ''' </summary>
                    Property c_CostoVariosCompra() As CampoSingle
                        Get
                            Return f_costo_varios_compra
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_varios_compra = value
                        End Set
                    End Property

                    ReadOnly Property _CostoVariosCompra() As PrecioCosto
                        Get
                            Return xcostovariocompra
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Property c_CostoVariosInventario() As CampoSingle
                        Get
                            Return f_costo_varios_inventario
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_varios_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Costo De Compra
                    ''' </summary>
                    Protected Friend Property c_CostoCompra() As CampoSingle
                        Get
                            Return f_costo_compra
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_compra = value
                        End Set
                    End Property

                    Dim xcostocompra As PrecioCosto
                    ReadOnly Property _CostoCompra() As PrecioCosto
                        Get
                            xcostocompra = New PrecioCosto(Me.c_CostoCompra.c_Valor, Me._TasaImpuesto, Me._ContEmpqCompra)
                            Return xcostocompra
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_CostoInventario() As CampoSingle
                        Get
                            Return f_costo_inventario
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Costo Promedio De Compra
                    ''' </summary>
                    Property c_CostoPromedioCompra() As CampoSingle
                        Get
                            Return f_costo_promedio_compra
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_promedio_compra = value
                        End Set
                    End Property

                    ReadOnly Property _CostoPromedioCompra() As PrecioCosto
                        Get
                            Return xcostopromediocompra
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_CostoPromedioInventario() As CampoSingle
                        Get
                            Return f_costo_promedio_inventario
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_costo_promedio_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_EstatusEmpaque() As CampoTexto
                        Get
                            Return f_estatus_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_empaque = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Utilidad1() As CampoSingle
                        Get
                            Return f_utilidad_1
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Utilidad2() As CampoSingle
                        Get
                            Return f_utilidad_2
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Utilidad3() As CampoSingle
                        Get
                            Return f_utilidad_3
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Utilidad4() As CampoSingle
                        Get
                            Return f_utilidad_4
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Precio 1
                    ''' </summary>
                    Protected Friend Property c_Precio1() As CampoSingle
                        Get
                            Return f_precio_1
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Precio 2
                    ''' </summary>
                    Protected Friend Property c_Precio2() As CampoSingle
                        Get
                            Return f_precio_2
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Precio 3
                    ''' </summary>
                    Protected Friend Property c_Precio3() As CampoSingle
                        Get
                            Return f_precio_3
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Precio 4
                    ''' </summary>
                    Protected Friend Property c_Precio4() As CampoSingle
                        Get
                            Return f_precio_4
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' SIN USO
                    ''' </summary>
                    Protected Friend Property c_PorLLegar() As CampoSingle
                        Get
                            Return f_por_llegar
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_por_llegar = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Uso / No De La Balanza 
                    ''' </summary>
                    Protected Friend Property c_EstatusBalanza() As CampoTexto
                        Get
                            Return f_estatus_balanza
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_balanza = value
                        End Set
                    End Property

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
                    ''' Campo PLU Asignado Al Producto
                    ''' </summary>
                    Property c_PLU() As CampoTexto
                        Get
                            Return f_plu
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_plu = value
                        End Set
                    End Property

                    ReadOnly Property _PLU() As String
                        Get
                            Return Me.c_PLU.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Modo De Trabajo Del Producto 
                    ''' </summary>
                    Protected Friend Property c_PesadoUnidad() As CampoTexto
                        Get
                            Return f_pesado_unidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_pesado_unidad = value
                        End Set
                    End Property

                    ReadOnly Property _TipoProducto() As TipoProductoBalanza
                        Get
                            If Me.c_PesadoUnidad.c_Texto.Trim.ToUpper = "P" Then
                                Return TipoProductoBalanza.Pesado
                            Else
                                Return TipoProductoBalanza.Unidad
                            End If
                        End Get
                    End Property

                    ReadOnly Property _EsPesado() As TipoEstatus
                        Get
                            If _EstatusBalanza = TipoEstatus.Activo And _TipoProducto = TipoProductoBalanza.Pesado Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si El Producto Es / No Envasado
                    ''' </summary>
                    Protected Friend Property c_EstatusEnvasado() As CampoTexto
                        Get
                            Return f_estatus_envasado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_envasado = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusEnvasado() As TipoEstatus
                        Get
                            If Me.c_EstatusEnvasado.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Dias De Envasado 
                    ''' </summary>
                    Protected Friend Property c_DiasEnvasado() As CampoInteger
                        Get
                            Return f_dias_envasado
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_envasado = value
                        End Set
                    End Property

                    ReadOnly Property _DiasDeEnvasado() As Integer
                        Get
                            Return Me.c_DiasEnvasado.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Extra1() As CampoTexto
                        Get
                            Return f_extra_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_extra_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Cantidad Dias De Garantia Ofrecida
                    ''' </summary>
                    Protected Friend Property c_DiasGarantia() As CampoInteger
                        Get
                            Return f_dias_garantia
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_dias_garantia = value
                        End Set
                    End Property

                    ReadOnly Property _DiasDeGarantia() As Integer
                        Get
                            Return Me.c_DiasGarantia.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Inf Nombre Del Modelo 
                    ''' </summary>
                    Property c_Modelo() As CampoTexto
                        Get
                            Return f_modelo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_modelo = value
                        End Set
                    End Property

                    ReadOnly Property _Modelo() As String
                        Get
                            Return Me.c_Modelo.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Inf Adicional Del Producto
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
                            Return Me.c_Comentarios.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Fecha Ultima Cambio De Precio 
                    ''' </summary>
                    Protected Friend Property c_FechaUltCambio() As CampoFecha
                        Get
                            Return f_fecha_cambio_precio
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_cambio_precio = value
                        End Set
                    End Property

                    ReadOnly Property _FechaUltCambioPrecio() As Date
                        Get
                            Return Me.c_FechaUltCambio.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Referencia Adicional Del Producto
                    ''' </summary>
                    Property c_Referencia() As CampoTexto
                        Get
                            Return f_referencia
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_referencia = value
                        End Set
                    End Property

                    ReadOnly Property _Referencia() As String
                        Get
                            Return Me.c_Referencia.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Unidades Contenidas En Empaque De Compra
                    ''' </summary>
                    Protected Friend Property c_ContEmpCompra() As CampoInteger
                        Get
                            Return f_contenido_empaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _ContEmpqCompra() As Integer
                        Get
                            Return Me.c_ContEmpCompra.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Precio Sugerido De Venta
                    ''' </summary>
                    Protected Friend Property c_PrecioSugerido() As CampoSingle
                        Get
                            Return f_psv
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_psv = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioSugerido() As Single
                        Get
                            Return Me.c_PrecioSugerido.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica La Cta Contable A Asignar
                    ''' </summary>
                    Property c_CtaContable() As CampoTexto
                        Get
                            Return f_contable_producto
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contable_producto = value
                        End Set
                    End Property

                    ReadOnly Property _CtaContable() As String
                        Get
                            Return Me.c_CtaContable.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Unidades Contenidas En Empaque De Venta Detal .: PTO DE VENTA
                    ''' </summary>
                    Protected Friend Property c_ContEmpVentaDetal() As CampoInteger
                        Get
                            Return f_contenido_empaque_venta
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque_venta = value
                        End Set
                    End Property

                    ReadOnly Property _ContEmpqVentaDetal() As Integer
                        Get
                            Return Me.c_ContEmpVentaDetal.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Estatus Del Producto 
                    ''' </summary>
                    Protected Friend Property c_EstatusProducto() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusProducto() As TipoEstatus
                        Get
                            If Me.c_EstatusProducto.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Alguna Inf Adicional Importante Del Producto
                    ''' </summary>
                    Property c_Advertencia() As CampoTexto
                        Get
                            Return f_advertencia
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_advertencia = value
                        End Set
                    End Property

                    ReadOnly Property _Advertencias() As String
                        Get
                            Return Me.c_Advertencia.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Fecha De Alta / Creacion Del Producto
                    ''' </summary>
                    Protected Friend Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property

                    ReadOnly Property _FechaCreacionProducto() As String
                        Get
                            Return Me.c_FechaAlta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Extra2() As CampoTexto
                        Get
                            Return f_extra_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_extra_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Categoria Del Producto 
                    ''' </summary>
                    Protected Friend Property c_CategoriaProducto() As CampoTexto
                        Get
                            Return f_categoria
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_categoria = value
                        End Set
                    End Property

                    ReadOnly Property _CategoriaDelProducto() As String
                        Get
                            Return Me.c_CategoriaProducto.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Procedencia / Origen Del Producto
                    ''' </summary>
                    Protected Friend Property c_OrigenProducto() As CampoTexto
                        Get
                            Return f_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_origen = value
                        End Set
                    End Property

                    ReadOnly Property _OrigenDelProducto() As String
                        Get
                            Return Me.c_OrigenProducto.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Medidas Alto
                    ''' </summary>
                    Protected Friend Property c_Alto() As CampoSingle
                        Get
                            Return f_alto
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_alto = value
                        End Set
                    End Property

                    ReadOnly Property _MedidaAlto() As Single
                        Get
                            Return Me.c_Alto.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Medidas Largo
                    ''' </summary>
                    Protected Friend Property c_Largo() As CampoSingle
                        Get
                            Return f_largo
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_largo = value
                        End Set
                    End Property

                    ReadOnly Property _MedidaLargo() As Single
                        Get
                            Return Me.c_Largo.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Medidas Ancho
                    ''' </summary>
                    Protected Friend Property c_Ancho() As CampoSingle
                        Get
                            Return f_ancho
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_ancho = value
                        End Set
                    End Property

                    ReadOnly Property _MedidaAncho() As Single
                        Get
                            Return Me.c_Ancho.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Medidas Peso
                    ''' </summary>
                    Protected Friend Property c_Peso() As CampoSingle
                        Get
                            Return f_peso
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_peso = value
                        End Set
                    End Property

                    ReadOnly Property _MedidaPeso() As Single
                        Get
                            Return Me.c_Peso.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Codigo Arancelario
                    ''' </summary>
                    Property c_CodigoArancel() As CampoTexto
                        Get
                            Return f_codigo_arancel
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo_arancel = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoArancelDelProducto() As String
                        Get
                            Return Me.c_CodigoArancel.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Arancel
                    ''' </summary>
                    Protected Friend Property c_TasaArancel() As CampoSingle
                        Get
                            Return f_tasa_arancel
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_tasa_arancel = value
                        End Set
                    End Property

                    ReadOnly Property _TasaArancelDelProducto() As Single
                        Get
                            Return Me.c_TasaArancel.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Marca
                    ''' </summary>
                    Protected Friend Property c_AutomaticoMarca() As CampoTexto
                        Get
                            Return f_auto_marca
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_marca = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMarca() As String
                        Get
                            Return Me.c_AutomaticoMarca.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _NombreMarca() As String
                        Get
                            Try
                                Dim xsql As String = "select nombre from productos_marca where auto=@auto"
                                Dim xpar As New SqlParameter("@auto", Me._AutoMarca)

                                Using xcon As New SqlConnection(_MiCadenaConexion)
                                    xcon.Open()
                                    Using xcmd As New SqlCommand(xsql, xcon)
                                        xcmd.Parameters.Add(xpar)
                                        Return xcmd.ExecuteScalar().ToString.Trim
                                    End Using
                                End Using
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Uso / No Garantia
                    ''' </summary>
                    Property c_EstatusGarantia() As CampoTexto
                        Get
                            Return f_estatus_garantia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_garantia = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusGarantia() As TipoEstatus
                        Get
                            If Me.c_EstatusGarantia.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Uso / No Seriales
                    ''' </summary>
                    Protected Friend Property c_EstatusSerial() As CampoTexto
                        Get
                            Return f_estatus_serial
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_serial = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusSerial() As TipoEstatus
                        Get
                            If Me.c_EstatusSerial.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Precio De Venta Neto Para El Pto De Venta
                    ''' </summary>
                    Protected Friend Property c_PrecioNetoPtoVenta() As CampoSingle
                        Get
                            Return f_precio_pto_venta
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_pto_venta = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioDetal() As Precio
                        Get
                            With xpreciodetal
                                ._Tasa = _TasaImpuesto
                                ._Base = Me.c_PrecioNetoPtoVenta.c_Valor
                            End With
                            Return xpreciodetal
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Margen De Utilidad PtoVenta
                    ''' </summary>
                    Protected Friend Property c_UtilidadPtoVenta() As CampoSingle
                        Get
                            Return f_utilidad_pto_venta
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_pto_venta = value
                        End Set
                    End Property

                    ReadOnly Property _UtilidadPrecioDetal() As Single
                        Get
                            Return Me.c_UtilidadPtoVenta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Peternece / No Grupo Licores
                    ''' </summary>
                    Protected Friend Property c_EstatusLicor() As CampoTexto
                        Get
                            Return f_estatus_licor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_licor = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusLicor() As TipoEstatus
                        Get
                            If Me.c_EstatusLicor.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Capacidad De La Botella En mml
                    ''' </summary>
                    Protected Friend Property c_CapacidadBotella() As CampoSingle
                        Get
                            Return f_capacidad
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_capacidad = value
                        End Set
                    End Property

                    ReadOnly Property _CapacidadBotellaLicor() As Single
                        Get
                            Return Me.c_CapacidadBotella.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Grados De Alcohol
                    ''' </summary>
                    Protected Friend Property c_GradosAlchohol() As CampoSingle
                        Get
                            Return f_grados
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_grados = value
                        End Set
                    End Property

                    ReadOnly Property _GradosAlcoholdBotellaLicor() As Single
                        Get
                            Return Me.c_GradosAlchohol.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Tipo De Tasa Asignada 
                    ''' </summary>
                    Protected Friend Property c_TasaLicor() As CampoSingle
                        Get
                            Return f_tasa_licor
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_tasa_licor = value
                        End Set
                    End Property

                    ReadOnly Property _TasaBotellaLicor() As Single
                        Get
                            Return Me.c_TasaLicor.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Existe / No Promocion/Oferta Del Producto
                    ''' </summary>
                    Protected Friend Property c_EstatusOferta() As CampoTexto
                        Get
                            Return f_estatus_oferta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_oferta = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusOferta() As TipoEstatus
                        Get
                            If Me.c_EstatusOferta.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica La Fecha De Inicio De La Oferta
                    ''' </summary>
                    Protected Friend Property c_InicioOferta() As CampoFecha
                        Get
                            Return f_inicio
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_inicio = value
                        End Set
                    End Property

                    ReadOnly Property _FechaInicioOferta() As Date
                        Get
                            Return Me.c_InicioOferta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Fecha De Culminacion De La Oferta
                    ''' </summary>
                    Protected Friend Property c_FinOferta() As CampoFecha
                        Get
                            Return f_fin
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fin = value
                        End Set
                    End Property

                    ReadOnly Property _FechaCulminacionOferta() As Date
                        Get
                            Return Me.c_FinOferta.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Precio Asigando Para La Oferta, Precio Es Full Iva
                    ''' </summary>
                    Protected Friend Property c_PrecioOferta() As CampoSingle
                        Get
                            Return f_precio_oferta
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_oferta = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioOferta() As Precio
                        Get
                            With xpreciooferta
                                ._Tasa = _TasaImpuesto
                                ._Base = Decimal.Round(c_PrecioOferta.c_Valor / (1 + (_TasaImpuesto / 100)), 2, MidpointRounding.AwayFromZero)
                            End With
                            Return xpreciooferta
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Etiqueta() As CampoTexto
                        Get
                            Return f_etiqueta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_etiqueta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_Publicidad() As CampoTexto
                        Get
                            Return f_publicidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_publicidad = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Margen Utilidad Asignado Al Precio Para Las Ofertas
                    ''' </summary>
                    Protected Friend Property c_UtilidadOferta() As CampoSingle
                        Get
                            Return f_utilidad_oferta
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_oferta = value
                        End Set
                    End Property

                    ReadOnly Property _UtilidadPrecioOferta() As Single
                        Get
                            Return Me.c_UtilidadOferta.c_Valor
                        End Get
                    End Property

                    Sub SetTasaImpuesto(ByVal tasa As Single)
                        Me.f_tasa.c_Valor = tasa
                    End Sub

                    ''' <summary>
                    ''' Campo Indica Tasa Iva Del Producto
                    ''' </summary>
                    Protected Friend Property c_TasaImpuesto() As CampoSingle
                        Get
                            Return f_tasa
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_tasa = value
                        End Set
                    End Property

                    ReadOnly Property _TasaImpuesto() As Single
                        Get
                            Return Me.c_TasaImpuesto.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_MedidaPrecio1() As CampoTexto
                        Get
                            Return f_medida_precio_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_precio_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_MedidaPrecio2() As CampoTexto
                        Get
                            Return f_medida_precio_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_precio_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_MedidaPrecio3() As CampoTexto
                        Get
                            Return f_medida_precio_3
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_precio_3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_MedidaPrecio4() As CampoTexto
                        Get
                            Return f_medida_precio_4
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_precio_4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo SIN USO
                    ''' </summary>
                    Protected Friend Property c_MedidaPrecioPtoVenta() As CampoTexto
                        Get
                            Return f_medida_precio_pto_venta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_precio_pto_venta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo INDICA SI EL PRODUCTO UTILIZA CORTE
                    ''' </summary>
                    Protected Friend Property c_EstatusCorte() As CampoTexto
                        Get
                            Return f_estatus_corte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_corte = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusCorte() As TipoEstatus
                        Get
                            If Me.c_EstatusCorte.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' SIN USO
                    ''' </summary>
                    Protected Friend Property c_Corte() As CampoTexto
                        Get
                            Return f_corte
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_corte = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si El Producto Es Desplegado En El Web
                    ''' </summary>
                    Protected Friend Property c_EstatusWebSite() As CampoTexto
                        Get
                            Return f_estatus_website
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_website = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusWeb() As TipoEstatus
                        Get
                            If Me.c_EstatusWebSite.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Detalle Adicional Del Producto
                    ''' </summary>
                    Protected Friend Property c_Detalle() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    ReadOnly Property _DetallesAdicionales() As String
                        Get
                            Return Me.c_Detalle.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si El Producto Es Considerado Un Departamento Para el Punto De Venta
                    ''' </summary>
                    Protected Friend Property c_EstatusDepartamento() As CampoTexto
                        Get
                            Return f_estatus_departamento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_departamento = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusDepartamento() As TipoDepPtoVenta
                        Get
                            If Me.c_EstatusDepartamento.c_Texto = "1" Then
                                Return TipoDepPtoVenta.TipoDepartamento
                            Else
                                Return TipoDepPtoVenta.TipoProducto
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si El Producto Fue Enviado Al Pto De Venta, En Caso Dado El Producto Ya No Podra Ser Anulado
                    ''' </summary>
                    Protected Friend Property c_EstatusReplica() As CampoTexto
                        Get
                            Return f_estatus_replica
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_replica = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusReplica() As TipoReplica
                        Get
                            If Me.c_EstatusReplica.c_Texto = "1" Then
                                Return TipoReplica.Replicado
                            Else
                                Return TipoReplica.NoReplicado
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Numero Parte Asigando Al Producto 
                    ''' </summary>
                    Property c_NumeroParte() As CampoTexto
                        Get
                            Return f_numero_parte
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_numero_parte = value
                        End Set
                    End Property

                    ReadOnly Property _NumeroParte() As String
                        Get
                            Return Me.c_NumeroParte.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Id Seguridad Del Registro
                    ''' </summary>
                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_idseguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_idseguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    Protected Friend Property c_EstatusFoto() As CampoTexto
                        Get
                            Return f_estatus_foto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_foto = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusFoto() As TipoEstatus
                        Get
                            If Me.c_EstatusFoto.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' FUNCION 
                    ''' RETORNA SI EL PRODUCTO ES APTO PARA USAR PRECIO OFERTA
                    ''' VERIFICA: ESTATUS OFERTA,  FECHA DE INICIO Y FECHA DE CULMINACIONCON CON RESPECTO A LA FECHA DEL SISTEMA
                    ''' </summary>
                    Function f_VerificarOferta() As Boolean
                        If _EstatusOferta = TipoEstatus.Activo Then
                            If _FechaSistema(_MiCadenaConexion) >= _FechaInicioOferta AndAlso _FechaSistema(_MiCadenaConexion) <= _FechaCulminacionOferta Then
                                Return True
                            End If
                        End If
                        Return False
                    End Function

                    ''' <summary>
                    ''' FUNCION 
                    ''' RETORNA SI EL PRODUCTO ES APTO PARA SER USADO POR LA BALANZA
                    ''' VERIFICA: ESTATUS BALANZA, ESTATUS PESADO
                    ''' </summary>
                    Function f_VerificarUsoBalanza() As Boolean
                        If _EstatusBalanza = TipoEstatus.Activo Then
                            If _TipoProducto = TipoProductoBalanza.Pesado Then
                                Return True
                            End If
                        End If
                        Return False
                    End Function

                    Property c_EstatusConsumo() As CampoTexto
                        Get
                            Return f_estatus_consumo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_consumo = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusConsumo() As Boolean
                        Get
                            If Me.c_EstatusConsumo.c_Texto.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    Property c_CantConsumo() As CampoDecimal
                        Get
                            Return f_cant_consumo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cant_consumo = value
                        End Set
                    End Property

                    ReadOnly Property _CantConsumo() As Decimal
                        Get
                            Return Me.c_CantConsumo.c_Valor
                        End Get
                    End Property

                    Property c_EstaRegulado() As CampoTexto
                        Get
                            Return f_EstaRegulado
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_EstaRegulado = value
                        End Set
                    End Property

                    ReadOnly Property _EstaRegulado() As TipoSiNo
                        Get
                            If Me.c_EstaRegulado.c_Texto = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

                    Property c_EstaRestringidoVenta() As CampoTexto
                        Get
                            Return f_EstaRestringidoVenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_EstaRestringidoVenta = value
                        End Set
                    End Property

                    ReadOnly Property _EstaRestringidoVenta() As TipoSiNo
                        Get
                            If Me.c_EstaRestringidoVenta.c_Texto = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

#End Region

                    ''' <summary>
                    ''' Retorna Tabla Producto
                    ''' </summary>
                    Protected Friend Property tb_Producto() As DataTable
                        Get
                            Return xtb_0
                        End Get
                        Set(ByVal value As DataTable)
                            xtb_0 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Retorna Tabla Con Los Codigos Alternos Registrados
                    ''' </summary>
                    Property tb_CodigosAlternos() As DataTable
                        Get
                            Return xtb_1
                        End Get
                        Protected Friend Set(ByVal value As DataTable)
                            xtb_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Retorna Tabla Con Las Existencias En Cada Deposito Definido Del Producto
                    ''' </summary>
                    Property tb_Existencia() As DataTable
                        Get
                            Return xtb_2
                        End Get
                        Protected Friend Set(ByVal value As DataTable)
                            xtb_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Retorna Lista De Precios Definido Del Producto
                    ''' </summary>
                    Property tb_Precios() As DataTable
                        Get
                            Return xtb_3
                        End Get
                        Protected Friend Set(ByVal value As DataTable)
                            xtb_3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Retorna Proveedores Asignados A Este Producto
                    ''' </summary>
                    Property tb_Proveedores() As DataTable
                        Get
                            Return xtb_4
                        End Get
                        Protected Friend Set(ByVal value As DataTable)
                            xtb_4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Metodo. Inicializa Las Tablas
                    ''' </summary>
                    Friend Sub LimpiarTablas()
                        Me.tb_Producto.Rows.Clear()
                        Me.tb_CodigosAlternos.Rows.Clear()
                        Me.tb_Existencia.Rows.Clear()
                        Me.tb_Precios.Rows.Clear()
                        Me.tb_Proveedores.Rows.Clear()
                    End Sub

                    ''' <summary>
                    ''' METODO: LIMPIAR / INICIALIZAR FICHA DE REGISTRO
                    ''' </summary>
                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)

                        xcostoproveedorcompra.M_Limpiar()
                        xcostoimpcompra.M_Limpiar()
                        xcostopromediocompra.M_Limpiar()
                        xcostovariocompra.M_Limpiar()

                        xpreciooferta.M_Limpiar()
                        xpreciodetal.M_Limpiar()
                    End Sub

                    Sub New()
                        Me.c_Advertencia = New CampoTexto(60, "advertencia")
                        Me.c_Alto = New CampoSingle("alto")
                        Me.c_Ancho = New CampoSingle("ancho")
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_AutomaticoDepartamento = New CampoTexto(10, "auto_departamento")
                        Me.c_AutomaticoEmpaqueCompra = New CampoTexto(10, "auto_medida_compra")
                        Me.c_AutomaticoEmpaqueVentaDetal = New CampoTexto(10, "auto_medida_venta")
                        Me.c_AutomaticoGrupo = New CampoTexto(10, "auto_grupo")
                        Me.c_AutomaticoMarca = New CampoTexto(10, "auto_marca")
                        Me.c_AutomaticoSubGrupo = New CampoTexto(10, "auto_subgrupo")
                        Me.c_CapacidadBotella = New CampoSingle("capacidad")
                        Me.c_CategoriaProducto = New CampoTexto(20, "categoria")
                        Me.c_CodigoArancel = New CampoTexto(15, "codigo_arancel")
                        Me.c_CodigoProducto = New CampoTexto(15, "codigo")
                        Me.c_Comentarios = New CampoTexto(120, "comentarios")
                        Me.c_ContEmpCompra = New CampoInteger("contenido_empaque")
                        Me.c_ContEmpVentaDetal = New CampoInteger("contenido_empaque_venta")
                        Me.c_Corte = New CampoTexto(1, "corte")
                        Me.c_CostoCompra = New CampoSingle("costo_compra")
                        Me.c_CostoImportacionCompra = New CampoSingle("costo_importacion_compra")
                        Me.c_CostoImportacionInventario = New CampoSingle("costo_importacion_inventario")
                        Me.c_CostoInventario = New CampoSingle("costo_inventario")
                        Me.c_CostoPromedioCompra = New CampoSingle("costo_promedio_compra")
                        Me.c_CostoPromedioInventario = New CampoSingle("costo_promedio_inventario")
                        Me.c_CostoProveedorCompra = New CampoSingle("costo_proveedor_compra")
                        Me.c_CostoProveedorInventario = New CampoSingle("costo_proveedor_inventario")
                        Me.c_CostoVariosCompra = New CampoSingle("costo_varios_compra")
                        Me.c_CostoVariosInventario = New CampoSingle("costo_varios_inventario")
                        Me.c_CtaContable = New CampoTexto(11, "contable_producto")
                        Me.c_Detalle = New CampoTexto(250, "detalle")
                        Me.c_DiasEnvasado = New CampoInteger("dias_envasado")
                        Me.c_DiasGarantia = New CampoInteger("dias_garantia")
                        Me.c_EstatusBalanza = New CampoTexto(1, "estatus_balanza")
                        Me.c_EstatusCorte = New CampoTexto(1, "estatus_corte")
                        Me.c_EstatusDepartamento = New CampoTexto(1, "estatus_departamento")
                        Me.c_EstatusEmpaque = New CampoTexto(1, "estatus_empaque")
                        Me.c_EstatusEnvasado = New CampoTexto(1, "estatus_envasado")
                        Me.c_EstatusGarantia = New CampoTexto(1, "estatus_garantia")
                        Me.c_EstatusLicor = New CampoTexto(1, "estatus_licor")
                        Me.c_EstatusOferta = New CampoTexto(1, "estatus_oferta")
                        Me.c_EstatusProducto = New CampoTexto(10, "estatus")
                        Me.c_EstatusReplica = New CampoTexto(1, "estatus_replica")
                        Me.c_EstatusSerial = New CampoTexto(1, "estatus_serial")
                        Me.c_EstatusWebSite = New CampoTexto(1, "estatus_website")
                        Me.c_Etiqueta = New CampoTexto(10, "etiqueta")
                        Me.c_Extra1 = New CampoTexto(40, "extra_1")
                        Me.c_Extra2 = New CampoTexto(40, "extra_2")
                        Me.c_FactorExistencia = New CampoInteger("factor_existencia")
                        Me.c_FechaAlta = New CampoFecha("fecha_alta")
                        Me.c_FechaUltCambio = New CampoFecha("fecha_cambio_precio")
                        Me.c_FinOferta = New CampoFecha("fin")
                        Me.c_GradosAlchohol = New CampoSingle("grados")
                        Me.c_InicioOferta = New CampoFecha("inicio")
                        Me.c_Largo = New CampoSingle("largo")
                        Me.c_MedidaPrecio1 = New CampoTexto(1, "medida_precio_1")
                        Me.c_MedidaPrecio2 = New CampoTexto(1, "medida_precio_2")
                        Me.c_MedidaPrecio3 = New CampoTexto(1, "medida_precio_3")
                        Me.c_MedidaPrecio4 = New CampoTexto(1, "medida_precio_4")
                        Me.c_MedidaPrecioPtoVenta = New CampoTexto(1, "medida_precio_pto_venta")
                        Me.c_Modelo = New CampoTexto(40, "modelo")
                        Me.c_NombreProducto = New CampoTexto(200, "nombre")
                        Me.c_NombreProductoResumen = New CampoTexto(40, "nombre_corto")
                        Me.c_OrigenProducto = New CampoTexto(20, "origen")
                        Me.c_PesadoUnidad = New CampoTexto(1, "pesado_unidad")
                        Me.c_Peso = New CampoSingle("peso")
                        Me.c_PLU = New CampoTexto(5, "plu")
                        Me.c_PorLLegar = New CampoSingle("por_llegar")
                        Me.c_Precio1 = New CampoSingle("precio_1")
                        Me.c_Precio2 = New CampoSingle("precio_2")
                        Me.c_Precio3 = New CampoSingle("precio_3")
                        Me.c_Precio4 = New CampoSingle("precio_4")
                        Me.c_PrecioNetoPtoVenta = New CampoSingle("precio_pto_venta")
                        Me.c_PrecioOferta = New CampoSingle("precio_oferta")
                        Me.c_PrecioSugerido = New CampoSingle("psv")
                        Me.c_Publicidad = New CampoTexto(120, "publicidad")
                        Me.c_Referencia = New CampoTexto(20, "referencia")
                        Me.c_TasaArancel = New CampoSingle("tasa_arancel")
                        Me.c_TasaImpuesto = New CampoSingle("tasa")
                        Me.c_TasaLicor = New CampoSingle("tasa_licor")
                        Me.c_TipoImpuesto = New CampoTexto(1, "impuesto")
                        Me.c_Utilidad1 = New CampoSingle("utilidad_1")
                        Me.c_Utilidad2 = New CampoSingle("utilidad_2")
                        Me.c_Utilidad3 = New CampoSingle("utilidad_3")
                        Me.c_Utilidad4 = New CampoSingle("utilidad_4")
                        Me.c_UtilidadOferta = New CampoSingle("utilidad_oferta")
                        Me.c_UtilidadPtoVenta = New CampoSingle("utilidad_pto_venta")

                        'CAMPOS NUEVOS
                        Me.c_EstatusFoto = New CampoTexto(1, "estatus_foto")
                        Me.c_NumeroParte = New CampoTexto(30, "numero_parte")
                        Me.c_EstatusConsumo = New CampoTexto(1, "estatus_consumo")
                        Me.c_CantConsumo = New CampoDecimal("cant_consumo")

                        '25/11/2014
                        Me.c_EstaRegulado = New CampoTexto(1, "EstaRegulado")
                        Me.c_EstaRestringidoVenta = New CampoTexto(1, "EstaRestringidoVenta")


                        Me.tb_Producto = New DataTable
                        Me.tb_CodigosAlternos = New DataTable
                        Me.tb_Existencia = New DataTable
                        Me.tb_Precios = New DataTable
                        Me.tb_Proveedores = New DataTable

                        xcostoproveedorcompra = New PrecioCosto
                        xcostoimpcompra = New PrecioCosto
                        xcostopromediocompra = New PrecioCosto
                        xcostovariocompra = New PrecioCosto

                        xpreciooferta = New Precio
                        xpreciodetal = New Precio

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .LimpiarRegistro()

                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_CodigoProducto.c_Texto = xrow(.c_CodigoProducto.c_NombreInterno)
                                .c_NombreProducto.c_Texto = xrow(.c_NombreProducto.c_NombreInterno)
                                .c_NombreProductoResumen.c_Texto = xrow(.c_NombreProductoResumen.c_NombreInterno)
                                .c_AutomaticoDepartamento.c_Texto = xrow(.c_AutomaticoDepartamento.c_NombreInterno)
                                .c_AutomaticoGrupo.c_Texto = xrow(.c_AutomaticoGrupo.c_NombreInterno)
                                .c_AutomaticoSubGrupo.c_Texto = xrow(.c_AutomaticoSubGrupo.c_NombreInterno)
                                .c_TipoImpuesto.c_Texto = xrow(.c_TipoImpuesto.c_NombreInterno)
                                .c_AutomaticoEmpaqueCompra.c_Texto = xrow(.c_AutomaticoEmpaqueCompra.c_NombreInterno)
                                .c_AutomaticoEmpaqueVentaDetal.c_Texto = xrow(.c_AutomaticoEmpaqueVentaDetal.c_NombreInterno)
                                .c_FactorExistencia.c_Valor = xrow(.c_FactorExistencia.c_NombreInterno)
                                .c_CostoProveedorCompra.c_Valor = xrow(.c_CostoProveedorCompra.c_NombreInterno)
                                .c_CostoProveedorInventario.c_Valor = xrow(.c_CostoProveedorInventario.c_NombreInterno)
                                .c_CostoImportacionCompra.c_Valor = xrow(.c_CostoImportacionCompra.c_NombreInterno)
                                .c_CostoImportacionInventario.c_Valor = xrow(.c_CostoImportacionInventario.c_NombreInterno)
                                .c_CostoVariosCompra.c_Valor = xrow(.c_CostoVariosCompra.c_NombreInterno)
                                .c_CostoVariosInventario.c_Valor = xrow(.c_CostoVariosInventario.c_NombreInterno)
                                .c_CostoCompra.c_Valor = xrow(.c_CostoCompra.c_NombreInterno)
                                .c_CostoInventario.c_Valor = xrow(.c_CostoInventario.c_NombreInterno)
                                .c_CostoPromedioCompra.c_Valor = xrow(.c_CostoPromedioCompra.c_NombreInterno)
                                .c_CostoPromedioInventario.c_Valor = xrow(.c_CostoPromedioInventario.c_NombreInterno)

                                .c_EstatusEmpaque.c_Texto = xrow(.c_EstatusEmpaque.c_NombreInterno)
                                .c_Utilidad1.c_Valor = xrow(.c_Utilidad1.c_NombreInterno)
                                .c_Utilidad2.c_Valor = xrow(.c_Utilidad2.c_NombreInterno)
                                .c_Utilidad3.c_Valor = xrow(.c_Utilidad3.c_NombreInterno)
                                .c_Utilidad4.c_Valor = xrow(.c_Utilidad4.c_NombreInterno)
                                .c_Precio1.c_Valor = xrow(.c_Precio1.c_NombreInterno)
                                .c_Precio2.c_Valor = xrow(.c_Precio2.c_NombreInterno)
                                .c_Precio3.c_Valor = xrow(.c_Precio3.c_NombreInterno)
                                .c_Precio4.c_Valor = xrow(.c_Precio4.c_NombreInterno)
                                .c_PorLLegar.c_Valor = xrow(.c_PorLLegar.c_NombreInterno)
                                .c_EstatusBalanza.c_Texto = xrow(.c_EstatusBalanza.c_NombreInterno)
                                .c_PLU.c_Texto = xrow(.c_PLU.c_NombreInterno)
                                .c_PesadoUnidad.c_Texto = xrow(.c_PesadoUnidad.c_NombreInterno)
                                .c_EstatusEnvasado.c_Texto = xrow(.c_EstatusEnvasado.c_NombreInterno)
                                .c_DiasEnvasado.c_Valor = xrow(.c_DiasEnvasado.c_NombreInterno)

                                .c_Extra1.c_Texto = xrow(.c_Extra1.c_NombreInterno)
                                .c_DiasGarantia.c_Valor = xrow(.c_DiasGarantia.c_NombreInterno)
                                .c_Modelo.c_Texto = xrow(.c_Modelo.c_NombreInterno)
                                .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                                .c_FechaUltCambio.c_Valor = xrow(.c_FechaUltCambio.c_NombreInterno)
                                .c_Referencia.c_Texto = xrow(.c_Referencia.c_NombreInterno)
                                .c_ContEmpCompra.c_Valor = xrow(.c_ContEmpCompra.c_NombreInterno)
                                .c_PrecioSugerido.c_Valor = xrow(.c_PrecioSugerido.c_NombreInterno)
                                .c_CtaContable.c_Texto = xrow(.c_CtaContable.c_NombreInterno)
                                .c_ContEmpVentaDetal.c_Valor = xrow(.c_ContEmpVentaDetal.c_NombreInterno)
                                .c_EstatusProducto.c_Texto = xrow(.c_EstatusProducto.c_NombreInterno)
                                .c_Advertencia.c_Texto = xrow(.c_Advertencia.c_NombreInterno)
                                .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                                .c_Extra2.c_Texto = xrow(.c_Extra2.c_NombreInterno)
                                .c_CategoriaProducto.c_Texto = xrow(.c_CategoriaProducto.c_NombreInterno)
                                .c_OrigenProducto.c_Texto = xrow(.c_OrigenProducto.c_NombreInterno)
                                .c_Alto.c_Valor = xrow(.c_Alto.c_NombreInterno)
                                .c_Largo.c_Valor = xrow(.c_Largo.c_NombreInterno)
                                .c_Ancho.c_Valor = xrow(.c_Ancho.c_NombreInterno)
                                .c_Peso.c_Valor = xrow(.c_Peso.c_NombreInterno)

                                .c_CodigoArancel.c_Texto = xrow(.c_CodigoArancel.c_NombreInterno)
                                .c_TasaArancel.c_Valor = xrow(.c_TasaArancel.c_NombreInterno)
                                .c_AutomaticoMarca.c_Texto = xrow(.c_AutomaticoMarca.c_NombreInterno)
                                .c_EstatusGarantia.c_Texto = xrow(.c_EstatusGarantia.c_NombreInterno)
                                .c_EstatusSerial.c_Texto = xrow(.c_EstatusSerial.c_NombreInterno)
                                .c_PrecioNetoPtoVenta.c_Valor = xrow(.c_PrecioNetoPtoVenta.c_NombreInterno)
                                .c_UtilidadPtoVenta.c_Valor = xrow(.c_UtilidadPtoVenta.c_NombreInterno)
                                .c_EstatusLicor.c_Texto = xrow(.c_EstatusLicor.c_NombreInterno)
                                .c_CapacidadBotella.c_Valor = xrow(.c_CapacidadBotella.c_NombreInterno)
                                .c_GradosAlchohol.c_Valor = xrow(.c_GradosAlchohol.c_NombreInterno)
                                .c_TasaLicor.c_Valor = xrow(.c_TasaLicor.c_NombreInterno)
                                .c_EstatusOferta.c_Texto = xrow(.c_EstatusOferta.c_NombreInterno)
                                .c_InicioOferta.c_Valor = xrow(.c_InicioOferta.c_NombreInterno)
                                .c_FinOferta.c_Valor = xrow(.c_FinOferta.c_NombreInterno)
                                .c_PrecioOferta.c_Valor = xrow(.c_PrecioOferta.c_NombreInterno)

                                .c_Etiqueta.c_Texto = xrow(.c_Etiqueta.c_NombreInterno)
                                .c_Publicidad.c_Texto = xrow(.c_Publicidad.c_NombreInterno)
                                .c_UtilidadOferta.c_Valor = xrow(.c_UtilidadOferta.c_NombreInterno)
                                .c_TasaImpuesto.c_Valor = xrow(.c_TasaImpuesto.c_NombreInterno)
                                .c_MedidaPrecio1.c_Texto = xrow(.c_MedidaPrecio1.c_NombreInterno)
                                .c_MedidaPrecio2.c_Texto = xrow(.c_MedidaPrecio2.c_NombreInterno)
                                .c_MedidaPrecio3.c_Texto = xrow(.c_MedidaPrecio3.c_NombreInterno)
                                .c_MedidaPrecio4.c_Texto = xrow(.c_MedidaPrecio4.c_NombreInterno)
                                .c_MedidaPrecioPtoVenta.c_Texto = xrow(.c_MedidaPrecioPtoVenta.c_NombreInterno)
                                .c_EstatusCorte.c_Texto = xrow(.c_EstatusCorte.c_NombreInterno)
                                .c_Corte.c_Texto = xrow(.c_Corte.c_NombreInterno)
                                .c_EstatusWebSite.c_Texto = xrow(.c_EstatusWebSite.c_NombreInterno)
                                .c_Detalle.c_Texto = xrow(.c_Detalle.c_NombreInterno)
                                .c_EstatusDepartamento.c_Texto = xrow(.c_EstatusDepartamento.c_NombreInterno)
                                .c_EstatusReplica.c_Texto = xrow(.c_EstatusReplica.c_NombreInterno)

                                If Not IsDBNull(xrow(.c_NumeroParte.c_NombreInterno)) Then
                                    .c_NumeroParte.c_Texto = xrow(.c_NumeroParte.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If

                                With ._CostoProveedorCompra
                                    ._TasaImpuesto = Me.c_TasaImpuesto.c_Valor
                                    ._ContEmpaque = Me.c_ContEmpCompra.c_Valor
                                    ._Base = Me.c_CostoProveedorCompra.c_Valor
                                End With

                                With ._CostoImportacionCompra
                                    ._TasaImpuesto = Me.c_TasaImpuesto.c_Valor
                                    ._ContEmpaque = Me.c_ContEmpCompra.c_Valor
                                    ._Base = Me.c_CostoImportacionCompra.c_Valor
                                End With

                                With ._CostoPromedioCompra
                                    ._TasaImpuesto = Me.c_TasaImpuesto.c_Valor
                                    ._ContEmpaque = Me.c_ContEmpCompra.c_Valor
                                    ._Base = Me.c_CostoPromedioCompra.c_Valor
                                End With

                                With ._CostoVariosCompra
                                    ._TasaImpuesto = Me.c_TasaImpuesto.c_Valor
                                    ._ContEmpaque = Me.c_ContEmpCompra.c_Valor
                                    ._Base = Me.c_CostoVariosCompra.c_Valor
                                End With

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If

                                If Not IsDBNull(xrow(.c_EstatusFoto.c_NombreInterno)) Then
                                    .c_EstatusFoto.c_Texto = xrow(.c_EstatusFoto.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_EstatusConsumo.c_NombreInterno)) Then
                                    .c_EstatusConsumo.c_Texto = xrow(.c_EstatusConsumo.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_CantConsumo.c_NombreInterno)) Then
                                    .c_CantConsumo.c_Valor = xrow(.c_CantConsumo.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_EstaRegulado.c_NombreInterno)) Then
                                    .c_EstaRegulado.c_Texto = xrow(.c_EstaRegulado.c_NombreInterno)
                                End If

                                If Not IsDBNull(xrow(.c_EstaRestringidoVenta.c_NombreInterno)) Then
                                    .c_EstaRestringidoVenta.c_Texto = xrow(.c_EstaRestringidoVenta.c_NombreInterno)
                                End If

                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS - CARGAR FICHA" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    Function BuscarCargar(ByVal xauto As String) As Boolean
                        Try
                            Dim xtb As New DataTable
                            Dim xp1 As New SqlParameter("@autodoc", xauto)
                            Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                xadap.SelectCommand.CommandText = "select * from productos where auto=@auto"
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                CargarRegistro(xtb(0))
                                Return True
                            Else
                                Throw New Exception("PRODUCTO NO ENCONTRADO")
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Function
                End Class

                Private xtipo_busqueda As String() = {"Por Codigo Barra/Alterno", "Por Codigo", "Por Descripcion", "Por Plu", "Por Referencia", "Por Numero Parte", "Por Serial #", "Por Codigo Proveedor"}
                Private xorigen() As String = {"Nacional", "Importado"}
                Private xcategoria() As String = {"Producto Terminado", "Materia Prima", "Bien de Servicio"}

                ''' <summary>
                ''' FUNCION: Retorna Una Lista Con Los Tipos De Busqueda Preestablecidos
                ''' </summary>
                ReadOnly Property _TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                End Property

                ''' <summary>
                ''' FUNCION: Retorna Una Lista Con Los Tipos De Origen Del Producto
                ''' </summary>
                ReadOnly Property _OrigenProducto() As String()
                    Get
                        Return xorigen
                    End Get
                End Property

                ''' <summary>
                ''' FUNCION: Retorna Una Lista Con Los Tipos De Categoria Del Producto
                ''' </summary>
                ReadOnly Property _CategoriaProducto() As String()
                    Get
                        Return xcategoria
                    End Get
                End Property

                Dim xregistro As c_Registro

                ''' <summary>
                ''' 
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
                    Me.RegistroDato = New c_Registro
                End Sub

                Sub New(ByVal xrow As DataRow)
                    Me.RegistroDato = New c_Registro
                    M_CargarRegistro(xrow)
                End Sub

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_LimpiarFicha()
                    Me.RegistroDato.LimpiarRegistro()
                    Me.RegistroDato.LimpiarTablas()
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

#Region "INSTRUCCIONES SQL"
                Private Const INSERT_PRODUCTO = "insert into productos (" _
                                      + "auto," _
                                      + "codigo," _
                                      + "nombre," _
                                      + "nombre_corto," _
                                      + "auto_departamento," _
                                      + "auto_grupo," _
                                      + "auto_subgrupo," _
                                      + "impuesto," _
                                      + "auto_medida_compra," _
                                      + "auto_medida_venta," _
                                      + "factor_existencia," _
                                      + "costo_proveedor_compra," _
                                      + "costo_proveedor_inventario," _
                                      + "costo_importacion_compra," _
                                      + "COSTO_IMPORTACION_INVENTARIO," _
                                      + "COSTO_VARIOS_COMPRA," _
                                      + "COSTO_VARIOS_INVENTARIO," _
                                      + "COSTO_COMPRA," _
                                      + "COSTO_INVENTARIO," _
                                      + "COSTO_PROMEDIO_COMPRA," _
                                      + "COSTO_PROMEDIO_INVENTARIO," _
                                      + "estatus_empaque," _
                                      + "UTILIDAD_1," _
                                      + "UTILIDAD_2," _
                                      + "UTILIDAD_3," _
                                      + "UTILIDAD_4," _
                                      + "PRECIO_1," _
                                      + "PRECIO_2," _
                                      + "PRECIO_3," _
                                      + "PRECIO_4," _
                                      + "POR_LLEGAR," _
                                      + "estatus_balanza," _
                                      + "PLU," _
                                      + "PESADO_UNIDAD," _
                                      + "estatus_envasado, " _
                                      + "DIAS_ENVASADO," _
                                      + "EXTRA_1," _
                                      + "DIAS_GARANTIA," _
                                      + "MODELO," _
                                      + "comentarios," _
                                      + "fecha_cambio_precio," _
                                      + "referencia," _
                                      + "contenido_empaque," _
                                      + "psv," _
                                      + "contable_producto," _
                                      + "contenido_empaque_venta," _
                                      + "estatus," _
                                      + "advertencia," _
                                      + "fecha_alta," _
                                      + "extra_2," _
                                      + "categoria," _
                                      + "origen," _
                                      + "alto," _
                                      + "largo," _
                                      + "ancho," _
                                      + "peso, " _
                                      + "codigo_arancel," _
                                      + "tasa_arancel," _
                                      + "auto_marca," _
                                      + "estatus_garantia," _
                                      + "estatus_serial," _
                                      + "precio_pto_venta," _
                                      + "utilidad_pto_venta," _
                                      + "estatus_licor," _
                                      + "capacidad," _
                                      + "grados," _
                                      + "tasa_licor," _
                                      + "estatus_oferta," _
                                      + "inicio," _
                                      + "fin," _
                                      + "precio_oferta," _
                                      + "etiqueta," _
                                      + "publicidad," _
                                      + "utilidad_oferta," _
                                      + "tasa," _
                                      + "medida_precio_1," _
                                      + "medida_precio_2," _
                                      + "medida_precio_3," _
                                      + "medida_precio_4," _
                                      + "medida_precio_pto_venta," _
                                      + "estatus_corte," _
                                      + "corte," _
                                      + "estatus_website," _
                                      + "detalle," _
                                      + "estatus_departamento," _
                                      + "estatus_replica," _
                                      + "numero_parte," _
                                      + "estatus_foto, EstaRegulado, EstaRestringidoventa) " _
                                      + "VALUES (" _
                                      + "@auto," _
                                      + "@codigo," _
                                      + "@nombre," _
                                      + "@nombre_corto," _
                                      + "@auto_departamento," _
                                      + "@auto_grupo," _
                                      + "@auto_subgrupo," _
                                      + "@impuesto," _
                                      + "@auto_medida_compra," _
                                      + "@auto_medida_venta," _
                                      + "@factor_existencia," _
                                      + "@costo_proveedor_compra," _
                                      + "@costo_proveedor_inventario," _
                                      + "@costo_importacion_compra," _
                                      + "@COSTO_IMPORTACION_INVENTARIO," _
                                      + "@COSTO_VARIOS_COMPRA," _
                                      + "@COSTO_VARIOS_INVENTARIO," _
                                      + "@COSTO_COMPRA," _
                                      + "@COSTO_INVENTARIO," _
                                      + "@COSTO_PROMEDIO_COMPRA," _
                                      + "@COSTO_PROMEDIO_INVENTARIO," _
                                      + "@estatus_empaque," _
                                      + "@UTILIDAD_1," _
                                      + "@UTILIDAD_2," _
                                      + "@UTILIDAD_3," _
                                      + "@UTILIDAD_4," _
                                      + "@PRECIO_1," _
                                      + "@PRECIO_2," _
                                      + "@PRECIO_3," _
                                      + "@PRECIO_4," _
                                      + "@POR_LLEGAR," _
                                      + "@estatus_balanza," _
                                      + "@PLU," _
                                      + "@PESADO_UNIDAD," _
                                      + "@estatus_envasado, " _
                                      + "@DIAS_ENVASADO," _
                                      + "@EXTRA_1," _
                                      + "@DIAS_GARANTIA," _
                                      + "@MODELO," _
                                      + "@comentarios," _
                                      + "@fecha_cambio_precio," _
                                      + "@referencia," _
                                      + "@contenido_empaque," _
                                      + "@psv," _
                                      + "@contable_producto," _
                                      + "@contenido_empaque_venta," _
                                      + "@estatus," _
                                      + "@advertencia," _
                                      + "@fecha_alta," _
                                      + "@extra_2," _
                                      + "@categoria," _
                                      + "@origen," _
                                      + "@alto," _
                                      + "@largo," _
                                      + "@ancho," _
                                      + "@peso, " _
                                      + "@codigo_arancel," _
                                      + "@tasa_arancel," _
                                      + "@auto_marca," _
                                      + "@estatus_garantia," _
                                      + "@estatus_serial," _
                                      + "@precio_pto_venta," _
                                      + "@utilidad_pto_venta," _
                                      + "@estatus_licor," _
                                      + "@capacidad," _
                                      + "@grados," _
                                      + "@tasa_licor," _
                                      + "@estatus_oferta," _
                                      + "@inicio," _
                                      + "@fin," _
                                      + "@precio_oferta," _
                                      + "@etiqueta," _
                                      + "@publicidad," _
                                      + "@utilidad_oferta," _
                                      + "@tasa," _
                                      + "@medida_precio_1," _
                                      + "@medida_precio_2," _
                                      + "@medida_precio_3," _
                                      + "@medida_precio_4," _
                                      + "@medida_precio_pto_venta," _
                                      + "@estatus_corte," _
                                      + "@corte," _
                                      + "@estatus_website," _
                                      + "@detalle," _
                                      + "@estatus_departamento," _
                                      + "@estatus_replica," _
                                      + "@numero_parte," _
                                      + "@estatus_foto, @EstaRegulado, @EstaRestringidoventa)"

                Private Const DeleteDeptoPtoVenta_1 As String = _
                    "Delete productos where auto=@auto and estatus_departamento='1'"

                Private Const UpdateDeptoPtoVenta_1 As String = _
                    "Update productos set nombre=@nombre, nombre_corto=@nombre_corto, " & _
                            "auto_departamento=@auto_departamento, auto_grupo=@auto_grupo, auto_subgrupo=@auto_subgrupo," & _
                            "impuesto=@impuesto,tasa=@tasa,auto_medida_compra=@auto_medida_compra, auto_medida_venta=@auto_medida_venta," & _
                            "fecha_cambio_precio=@fecha_cambio_precio,estatus=@estatus,auto_marca=@auto_marca " & _
                            "where auto=@auto and estatus_departamento='1' and id_seguridad=@id_seguridad"

                Private Const INSERT_PRODUCTOS_DEPOSITO = "insert into productos_deposito (" _
                                              + "auto_producto," _
                                              + "auto_deposito," _
                                              + "real," _
                                              + "reservada," _
                                              + "disponible," _
                                              + "ubicacion_1," _
                                              + "ubicacion_2," _
                                              + "ubicacion_3," _
                                              + "ubicacion_4," _
                                              + "nivel_minimo," _
                                              + "pto_pedido," _
                                              + "nivel_optimo)" _
                                              + " VALUES (" _
                                              + "@auto_producto," _
                                              + "@auto_deposito," _
                                              + "@real," _
                                              + "@reservada," _
                                              + "@disponible," _
                                              + "@ubicacion_1," _
                                              + "@ubicacion_2," _
                                              + "@ubicacion_3," _
                                              + "@ubicacion_4," _
                                              + "@nivel_minimo," _
                                              + "@pto_pedido," _
                                              + "@nivel_optimo)"

                Private Const INSERT_PRODUCTOS_EMPAQUE = "insert into productos_empaque(" _
                                      + "auto_producto," _
                                      + "precio_1," _
                                      + "precio_2," _
                                      + "auto_medida," _
                                      + "contenido," _
                                      + "utilidad_1," _
                                      + "utilidad_2," _
                                      + "referencia)" _
                                      + "VALUES (" _
                                      + "@auto_producto," _
                                      + "@precio_1," _
                                      + "@precio_2," _
                                      + "@auto_medida," _
                                      + "@contenido," _
                                      + "@utilidad_1," _
                                      + "@utilidad_2," _
                                      + "@referencia)"

                Private Const INSERT_PRODUCTOS_HISTORICO_PRECIOS = "INSERT INTO productos_historico_precios(" _
                                      + "auto," _
                                      + "auto_producto," _
                                      + "fecha," _
                                      + "estacion," _
                                      + "auto_usuario," _
                                      + "precio_id," _
                                      + "precio_anterior," _
                                      + "precio_nuevo," _
                                      + "empaque," _
                                      + "nota," _
                                      + "usuario," _
                                      + "hora, " _
                                      + "contenido_empaque) " _
                                      + "VALUES(" _
                                      + "@auto," _
                                      + "@auto_producto," _
                                      + "@fecha," _
                                      + "@estacion," _
                                      + "@auto_usuario," _
                                      + "@precio_id," _
                                      + "@precio_anterior," _
                                      + "@precio_nuevo," _
                                      + "@empaque," _
                                      + "@nota," _
                                      + "@usuario," _
                                      + "@hora," _
                                      + "@contenido_empaque)"

                Private Const UpdateProductos_FichaPrincipal As String = "update productos set " & _
                                      "codigo=@codigo," & _
                                      "nombre=@nombre," & _
                                      "nombre_corto=@nombre_corto," & _
                                      "auto_departamento=@auto_departamento," & _
                                      "auto_grupo=@auto_grupo," & _
                                      "auto_subgrupo=@auto_subgrupo," & _
                                      "auto_marca=@auto_marca," & _
                                      "auto_medida_compra=@auto_medida_compra," & _
                                      "auto_medida_venta=@auto_medida_venta," & _
                                      "categoria=@categoria," & _
                                      "contenido_empaque=@contenido_empaque," & _
                                      "contenido_empaque_venta=@contenido_empaque_venta," & _
                                      "impuesto=@impuesto," & _
                                      "origen=@origen," & _
                                      "tasa=@tasa," & _
                                      "estatus=@estatus," & _
                                      "fecha_cambio_precio=@fecha_cambio_precio" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaBalanza As String = "update productos set " & _
                                      "plu=@plu," & _
                                      "estatus_balanza=@estatus_balanza," & _
                                      "pesado_unidad=@pesado_unidad" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaLicor As String = "update productos set " & _
                                      "estatus_licor=@estatus_licor," & _
                                      "capacidad=@capacidad," & _
                                      "grados=@grados," & _
                                      "tasa_licor=@tasa_licor" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaGarantia As String = "update productos set " & _
                                      "estatus_garantia=@estatus_garantia," & _
                                      "dias_garantia=@dias_garantia" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaDimensiones As String = "update productos set " & _
                                      "alto=@alto," & _
                                      "ancho=@ancho," & _
                                      "largo=@largo," & _
                                      "peso=@peso," & _
                                      "codigo_arancel=@codigo_arancel," & _
                                      "tasa_arancel=@tasa_arancel" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaContabilidad As String = "update productos set " & _
                                      "contable_producto=@contable_producto" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaDetalle As String = "update productos set " & _
                                      "referencia=@referencia," & _
                                      "modelo=@modelo," & _
                                      "numero_parte=@numero_parte" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductosCostos As String = "update productos set " & _
                                      "costo_proveedor_compra=@costo_proveedor_compra," & _
                                      "costo_proveedor_inventario=@costo_proveedor_inventario," & _
                                      "costo_compra=@costo_compra," & _
                                      "costo_inventario=@costo_inventario," & _
                                      "costo_promedio_compra=@costo_promedio_compra," & _
                                      "costo_promedio_inventario=@costo_promedio_inventario" & _
                                      " where auto=@auto and id_seguridad=@id_seguridad"

                Private Const UpdateProductos_FichaPresupuestoEvento As String = "update productos set " & _
                                      "estatus_consumo=@estatus_consumo," & _
                                      "cant_consumo=@cant_consumo " & _
                                      "where auto=@auto and id_seguridad=@id_seguridad"

                '25/11/2014
                Private Const UpdateProductos_FichaEstatusProducto As String = "update productos set " & _
                                      "EstaRegulado=@EstaRegulado," & _
                                      "EstaRestringidoVenta=@EstaRestringidoVenta " & _
                                      "where auto=@auto and id_seguridad=@id_seguridad"

                Private Const ACTUALIZAR_PRECIO_EMPAQUE = "update productos_empaque set " & _
                                               "precio_1=@precio_1," & _
                                               "precio_2=@precio_2," & _
                                               "auto_medida=@auto_medida," & _
                                               "contenido=@contenido," & _
                                               "utilidad_1=@utilidad_1," & _
                                               "utilidad_2=@utilidad_2 " & _
                                               "where auto_producto=@auto_producto and referencia=@referencia AND id_seguridad=@id_seguridad"

                Private Const ACTUALIZAR_PRECIO_DETAL = "update productos set " & _
                                               "auto_medida_venta=@auto_medida_venta," & _
                                               "contenido_empaque_venta=@contenido_empaque_venta," & _
                                               "precio_pto_venta=@precio_pto_venta," & _
                                               "utilidad_pto_venta=@utilidad_pto_venta," & _
                                               "psv=@psv," & _
                                               "estatus_oferta=@estatus_oferta," & _
                                               "inicio=@inicio," & _
                                               "fin=@fin," & _
                                               "precio_oferta=@precio_oferta," & _
                                               "utilidad_oferta=@utilidad_oferta," & _
                                               "fecha_cambio_precio=@fecha_cambio_precio " & _
                                               "where auto=@auto_producto AND id_seguridad=@id_seguridad"

                Private Const ACTUALIZAR_PRECIO_OFERTA = "update productos set " & _
                                               "estatus_oferta=@estatus_oferta," & _
                                               "inicio=@inicio," & _
                                               "fin=@fin," & _
                                               "precio_oferta=@precio_oferta," & _
                                               "utilidad_oferta=@utilidad_oferta," & _
                                               "fecha_cambio_precio=@fecha_cambio_precio " & _
                                               "where auto=@auto_producto AND id_seguridad=@id_seguridad"

                Protected Friend Const INSERT_PRODUCTOS_HISTORICO_COSTOS = "INSERT INTO productos_historico_costos(" _
                                     + "auto," _
                                     + "auto_documento," _
                                     + "auto_entidad," _
                                     + "auto_producto," _
                                     + "auto_usuario," _
                                     + "codigo_usuario," _
                                     + "contenido_empaque," _
                                     + "costo," _
                                     + "costo_actual," _
                                     + "costo_nuevo," _
                                     + "documento," _
                                     + "fecha_carga," _
                                     + "fecha_emision," _
                                     + "empaque," _
                                     + "entidad," _
                                     + "estacion," _
                                     + "estatus," _
                                     + "hora, " _
                                     + "nota," _
                                     + "origen," _
                                     + "usuario) " _
                                     + "VALUES(" _
                                     + "@auto," _
                                     + "@auto_documento," _
                                     + "@auto_entidad," _
                                     + "@auto_producto," _
                                     + "@auto_usuario," _
                                     + "@codigo_usuario," _
                                     + "@contenido_empaque," _
                                     + "@costo," _
                                     + "@costo_actual," _
                                     + "@costo_nuevo," _
                                     + "@documento," _
                                     + "@fecha_carga," _
                                     + "@fecha_emision," _
                                     + "@empaque," _
                                     + "@entidad," _
                                     + "@estacion," _
                                     + "@estatus," _
                                     + "@hora, " _
                                     + "@nota," _
                                     + "@origen," _
                                     + "@usuario) "
#End Region


                Function F_ActualizarTablaDepositos() As Boolean
                    Try
                        Dim xsql As String = "select d.nombre xnombre, d.codigo xcodigo, pd.real xreal, pd.reservada xreservada, pd.disponible xdisponible, pd.*, d.* " & _
                          "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto where pd.auto_producto=@auto"

                        Me.RegistroDato.tb_Existencia.Rows.Clear()
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", Me.RegistroDato._AutoProducto)
                            xadap.Fill(Me.RegistroDato.tb_Existencia)
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR DEPOSITOS" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarTablaCodigosAlternos() As Boolean
                    Try
                        Dim xsql As String = "select codigo xcodigo,detalle xdetalle, * from productos_alterno where auto_producto=@auto"

                        Me.RegistroDato.tb_CodigosAlternos.Rows.Clear()
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", Me.RegistroDato._AutoProducto)
                            xadap.Fill(Me.RegistroDato.tb_CodigosAlternos)
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR TABLA CODIGOS ALTERNOS" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarTablaProveedores() As Boolean
                    Try
                        Dim xsql As String = "select p.nombre xnombre,pp.codigo xcodigo, p.* from productos_proveedor pp join proveedores p on " & _
                          "pp.auto_proveedor=p.auto and pp.auto_producto=@auto order by p.nombre"

                        Me.RegistroDato.tb_Proveedores.Rows.Clear()
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", Me.RegistroDato._AutoProducto)
                            xadap.Fill(Me.RegistroDato.tb_Proveedores)
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR TABLA PROVEEDORES ASIGNADOS" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' FUNCION: Permite Cargar Ficha General Del Producto 
                ''' </summary>
                Function F_BuscarProducto(ByVal xauto As String) As Boolean
                    Try
                        Dim xsql1 As String = "select * from productos where auto=@auto"
                        Dim xsql2 As String = "select codigo xcodigo,detalle xdetalle, * from productos_alterno where auto_producto=@auto"
                        Dim xsql3 As String = "select d.nombre xnombre, d.codigo xcodigo, pd.real xreal, pd.reservada xreservada, pd.disponible xdisponible, pd.*, d.* " & _
                          "from productos_deposito pd join depositos d on pd.auto_deposito=d.auto where pd.auto_producto=@auto"
                        Dim xsql4 As String = "select pe.*,pm.* from productos_empaque pe join productos_medida pm on pe.auto_medida=pm.auto where pe.auto_producto=@auto ORDER BY PE.REFERENCIA"
                        Dim xsql5 As String = "select p.nombre xnombre,pp.codigo xcodigo, p.* from productos_proveedor pp join proveedores p on " & _
                          "pp.auto_proveedor=p.auto and pp.auto_producto=@auto order by p.nombre"

                        Me.RegistroDato.LimpiarTablas()
                        'Productos
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql1
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(Me.RegistroDato.tb_Producto)

                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql2
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(Me.RegistroDato.tb_CodigosAlternos)

                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql3
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(Me.RegistroDato.tb_Existencia)

                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql4
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(Me.RegistroDato.tb_Precios)

                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = xsql5
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(Me.RegistroDato.tb_proveedores)

                            If Me.RegistroDato.tb_Producto.Rows.Count > 0 Then
                                M_CargarRegistro(Me.RegistroDato.tb_Producto.Rows(0))
                            Else
                                Throw New Exception("PRODUCTO NO ENCONTRADO / FUE ELIMINADO POR OTRO USUARIO")
                            End If

                            Return True
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "BUSQUEDA PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' BUSCAR Y CARGAR EN MEMORIA SOLO LA FICHA DEL PRODUCTO
                ''' </summary>
                Function F_BuscarCargarFichaProducto(ByVal xauto As String) As Boolean
                    Try
                        Me.RegistroDato.BuscarCargar(xauto)
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Enum ModoBusqueda As Integer
                    CodigoBarra = 1
                    CodigoPlu = 2
                    Automatico = 3
                End Enum

                ''' <summary>
                ''' Funcion Que Permite Buscar y Cargar La Data Del Producto, Para Una Consulta Rapida
                ''' </summary>
                Function F_BuscarProducto(ByVal xbuscar As String, ByVal xmodo As ModoBusqueda) As Boolean
                    Select Case xmodo
                        Case ModoBusqueda.CodigoBarra
                            Return BuscarCodigoBarra(xbuscar)
                        Case ModoBusqueda.CodigoPlu
                            Return BuscarPlu(xbuscar)
                        Case ModoBusqueda.Automatico
                            Return F_BuscarProducto(xbuscar)
                    End Select
                End Function

                Function BuscarCodigoBarra(ByVal xbuscar As String) As Boolean
                    Try
                        Dim xauto As String
                        Dim xsql As String = "select auto_producto from productos_alterno where codigo=@codigo"
                        Dim xp1 As New SqlParameter("@codigo", xbuscar)

                        xauto = MiDataSistema.DataSistema.F_GetString(xsql, xp1)
                        If xauto = "" Then
                            Return False
                        Else
                            Return F_BuscarProducto(xauto)
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function BuscarPlu(ByVal xbuscar As String) As Boolean
                    Try
                        Dim xauto As String
                        Dim xsql As String = "select auto from productos where plu=@plu"
                        Dim xp1 As New SqlParameter("@plu", xbuscar)

                        xauto = MiDataSistema.DataSistema.F_GetString(xsql, xp1)
                        If xauto = "" Then
                            Return False
                        Else
                            Return F_BuscarProducto(xauto)
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_EliminarDeptoPtoVenta(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = DeleteDeptoPtoVenta_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("EXISTEN MOVIMIENTOS DE VENTAS")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL ELIMINAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_IngresarDeptoPtoVenta(ByVal xdepto As c_AgregarDepartamentoPtoventas) As Boolean
                    Try
                        With xdepto.RegistroDato
                            .c_CategoriaProducto.c_Texto = "Producto Terminado"
                            .c_ContEmpCompra.c_Valor = 1
                            .c_ContEmpVentaDetal.c_Valor = 1
                            .c_EstatusBalanza.c_Texto = "0"
                            .c_EstatusCorte.c_Texto = "0"
                            .c_EstatusDepartamento.c_Texto = "1"
                            .c_EstatusEmpaque.c_Texto = "0"
                            .c_EstatusEnvasado.c_Texto = "0"
                            .c_EstatusGarantia.c_Texto = "0"
                            .c_EstatusLicor.c_Texto = "0"
                            .c_EstatusOferta.c_Texto = "0"
                            .c_EstatusReplica.c_Texto = "0"
                            .c_EstatusSerial.c_Texto = "0"
                            .c_EstatusWebSite.c_Texto = "0"
                            .c_EstatusFoto.c_Texto = "0"
                            .c_FechaUltCambio.c_Valor = .c_FechaAlta.c_Valor
                            .c_InicioOferta.c_Valor = .c_FechaAlta.c_Valor
                            .c_FinOferta.c_Valor = .c_FechaAlta.c_Valor
                        End With

                        Dim xtr As SqlTransaction
                        Dim sql_1 As String = "update contadores set a_productos=a_productos+1; select a_productos from contadores"
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = sql_1
                                    xdepto.RegistroDato.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from productos_subgrupo where auto_grupo=@auto_grupo"
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xdepto.RegistroDato.c_AutomaticoGrupo.c_Texto)
                                    Dim xobj As Object = Nothing
                                    xobj = xcmd.ExecuteScalar()
                                    If IsDBNull(xobj) Or IsNothing(xobj) Then
                                        Throw New Exception("ERROR... NO HAY UN SUB-GRUPO ASIGNADO PARA ESTE GRUPO")
                                    Else
                                        xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Texto = xobj.ToString
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PRODUCTO
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xdepto.RegistroDato.c_Automatico.c_Texto).Size = xdepto.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@codigo", xdepto.RegistroDato.c_CodigoProducto.c_Texto).Size = xdepto.RegistroDato.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombre", xdepto.RegistroDato.c_NombreProducto.c_Texto).Size = xdepto.RegistroDato.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombre_corto", xdepto.RegistroDato.c_NombreProductoResumen.c_Texto).Size = xdepto.RegistroDato.c_NombreProductoResumen.c_Largo
                                        .AddWithValue("@auto_departamento", xdepto.RegistroDato.c_AutomaticoDepartamento.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoDepartamento.c_Largo
                                        .AddWithValue("@auto_grupo", xdepto.RegistroDato.c_AutomaticoGrupo.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoGrupo.c_Largo
                                        .AddWithValue("@auto_subgrupo", xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Largo
                                        .AddWithValue("@impuesto", xdepto.RegistroDato.c_TipoImpuesto.c_Texto).Size = xdepto.RegistroDato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@auto_medida_compra", xdepto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Largo
                                        .AddWithValue("@auto_medida_venta", xdepto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Largo
                                        .AddWithValue("@factor_existencia", xdepto.RegistroDato.c_FactorExistencia.c_Valor)
                                        .AddWithValue("@costo_proveedor_compra", xdepto.RegistroDato.c_CostoProveedorCompra.c_Valor)
                                        .AddWithValue("@costo_proveedor_inventario", xdepto.RegistroDato.c_CostoProveedorInventario.c_Valor)
                                        .AddWithValue("@costo_importacion_compra", xdepto.RegistroDato.c_CostoImportacionCompra.c_Valor)
                                        .AddWithValue("@costo_importacion_inventario", xdepto.RegistroDato.c_CostoImportacionInventario.c_Valor)
                                        .AddWithValue("@costo_varios_compra", xdepto.RegistroDato.c_CostoVariosCompra.c_Valor)
                                        .AddWithValue("@costo_varios_inventario", xdepto.RegistroDato.c_CostoVariosInventario.c_Valor)
                                        .AddWithValue("@costo_compra", xdepto.RegistroDato.c_CostoCompra.c_Valor)
                                        .AddWithValue("@costo_inventario", xdepto.RegistroDato.c_CostoInventario.c_Valor)
                                        .AddWithValue("@costo_promedio_compra", xdepto.RegistroDato.c_CostoPromedioCompra.c_Valor)
                                        .AddWithValue("@costo_promedio_inventario", xdepto.RegistroDato.c_CostoPromedioInventario.c_Valor)
                                        .AddWithValue("@estatus_empaque", xdepto.RegistroDato.c_EstatusEmpaque.c_Texto).Size = xdepto.RegistroDato.c_EstatusEmpaque.c_Largo
                                        .AddWithValue("@utilidad_1", xdepto.RegistroDato.c_Utilidad1.c_Valor)
                                        .AddWithValue("@utilidad_2", xdepto.RegistroDato.c_Utilidad2.c_Valor)
                                        .AddWithValue("@utilidad_3", xdepto.RegistroDato.c_Utilidad3.c_Valor)
                                        .AddWithValue("@utilidad_4", xdepto.RegistroDato.c_Utilidad4.c_Valor)
                                        .AddWithValue("@precio_1", xdepto.RegistroDato.c_Precio1.c_Valor)
                                        .AddWithValue("@precio_2", xdepto.RegistroDato.c_Precio2.c_Valor)
                                        .AddWithValue("@precio_3", xdepto.RegistroDato.c_Precio3.c_Valor)
                                        .AddWithValue("@precio_4", xdepto.RegistroDato.c_Precio4.c_Valor)
                                        .AddWithValue("@por_llegar", xdepto.RegistroDato.c_PorLLegar.c_Valor)
                                        .AddWithValue("@estatus_balanza", xdepto.RegistroDato.c_EstatusBalanza.c_Texto).Size = xdepto.RegistroDato.c_EstatusBalanza.c_Largo
                                        .AddWithValue("@plu", xdepto.RegistroDato.c_PLU.c_Texto).Size = xdepto.RegistroDato.c_PLU.c_Largo
                                        .AddWithValue("@pesado_unidad", xdepto.RegistroDato.c_PesadoUnidad.c_Texto).Size = xdepto.RegistroDato.c_PesadoUnidad.c_Largo
                                        .AddWithValue("@estatus_envasado", xdepto.RegistroDato.c_EstatusEnvasado.c_Texto).Size = xdepto.RegistroDato.c_EstatusEnvasado.c_Largo
                                        .AddWithValue("@dias_envasado", xdepto.RegistroDato.c_DiasEnvasado.c_Valor)
                                        .AddWithValue("@extra_1", xdepto.RegistroDato.c_Extra1.c_Texto).Size = xdepto.RegistroDato.c_Extra1.c_Largo
                                        .AddWithValue("@dias_garantia", xdepto.RegistroDato.c_DiasGarantia.c_Valor)
                                        .AddWithValue("@modelo", xdepto.RegistroDato.c_Modelo.c_Texto).Size = xdepto.RegistroDato.c_Modelo.c_Largo
                                        .AddWithValue("@comentarios", xdepto.RegistroDato.c_Comentarios.c_Texto).Size = xdepto.RegistroDato.c_Comentarios.c_Largo
                                        .AddWithValue("@fecha_cambio_precio", xdepto.RegistroDato.c_FechaUltCambio.c_Valor)
                                        .AddWithValue("@referencia", xdepto.RegistroDato.c_Referencia.c_Texto).Size = xdepto.RegistroDato.c_Referencia.c_Largo
                                        .AddWithValue("@contenido_empaque", xdepto.RegistroDato.c_ContEmpCompra.c_Valor)
                                        .AddWithValue("@psv", xdepto.RegistroDato.c_PrecioSugerido.c_Valor)
                                        .AddWithValue("@contable_producto", xdepto.RegistroDato.c_CtaContable.c_Texto).Size = xdepto.RegistroDato.c_CtaContable.c_Largo
                                        .AddWithValue("@contenido_empaque_venta", xdepto.RegistroDato.c_ContEmpVentaDetal.c_Valor)
                                        .AddWithValue("@estatus", xdepto.RegistroDato.c_EstatusProducto.c_Texto).Size = xdepto.RegistroDato.c_EstatusProducto.c_Largo
                                        .AddWithValue("@advertencia", xdepto.RegistroDato.c_Advertencia.c_Texto).Size = xdepto.RegistroDato.c_Advertencia.c_Largo
                                        .AddWithValue("@fecha_alta", xdepto.RegistroDato.c_FechaAlta.c_Valor)
                                        .AddWithValue("@extra_2", xdepto.RegistroDato.c_Extra2.c_Texto).Size = xdepto.RegistroDato.c_Extra2.c_Largo
                                        .AddWithValue("@categoria", xdepto.RegistroDato.c_CategoriaProducto.c_Texto).Size = xdepto.RegistroDato.c_CategoriaProducto.c_Largo
                                        .AddWithValue("@origen", xdepto.RegistroDato.c_OrigenProducto.c_Texto).Size = xdepto.RegistroDato.c_OrigenProducto.c_Largo
                                        .AddWithValue("@alto", xdepto.RegistroDato.c_Alto.c_Valor)
                                        .AddWithValue("@largo", xdepto.RegistroDato.c_Largo.c_Valor)
                                        .AddWithValue("@ancho", xdepto.RegistroDato.c_Ancho.c_Valor)
                                        .AddWithValue("@peso", xdepto.RegistroDato.c_Peso.c_Valor)
                                        .AddWithValue("@codigo_arancel", xdepto.RegistroDato.c_CodigoArancel.c_Texto).Size = xdepto.RegistroDato.c_CodigoArancel.c_Largo
                                        .AddWithValue("@tasa_arancel", xdepto.RegistroDato.c_TasaArancel.c_Valor)
                                        .AddWithValue("@auto_marca", xdepto.RegistroDato.c_AutomaticoMarca.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoMarca.c_Largo
                                        .AddWithValue("@estatus_garantia", xdepto.RegistroDato.c_EstatusGarantia.c_Texto).Size = xdepto.RegistroDato.c_EstatusGarantia.c_Largo
                                        .AddWithValue("@estatus_serial", xdepto.RegistroDato.c_EstatusSerial.c_Texto).Size = xdepto.RegistroDato.c_EstatusSerial.c_Largo
                                        .AddWithValue("@precio_pto_venta", xdepto.RegistroDato.c_PrecioNetoPtoVenta.c_Valor)
                                        .AddWithValue("@utilidad_pto_venta", xdepto.RegistroDato.c_UtilidadPtoVenta.c_Valor)
                                        .AddWithValue("@estatus_licor", xdepto.RegistroDato.c_EstatusLicor.c_Texto).Size = xdepto.RegistroDato.c_EstatusLicor.c_Largo
                                        .AddWithValue("@capacidad", xdepto.RegistroDato.c_CapacidadBotella.c_Valor)
                                        .AddWithValue("@grados", xdepto.RegistroDato.c_GradosAlchohol.c_Valor)
                                        .AddWithValue("@tasa_licor", xdepto.RegistroDato.c_TasaLicor.c_Valor)
                                        .AddWithValue("@estatus_oferta", xdepto.RegistroDato.c_EstatusOferta.c_Texto).Size = xdepto.RegistroDato.c_EstatusOferta.c_Largo
                                        .AddWithValue("@inicio", xdepto.RegistroDato.c_InicioOferta.c_Valor)
                                        .AddWithValue("@fin", xdepto.RegistroDato.c_FinOferta.c_Valor)
                                        .AddWithValue("@precio_oferta", xdepto.RegistroDato.c_PrecioOferta.c_Valor)
                                        .AddWithValue("@etiqueta", xdepto.RegistroDato.c_Etiqueta.c_Texto).Size = xdepto.RegistroDato.c_Etiqueta.c_Largo
                                        .AddWithValue("@publicidad", xdepto.RegistroDato.c_Publicidad.c_Texto).Size = xdepto.RegistroDato.c_Publicidad.c_Largo
                                        .AddWithValue("@utilidad_oferta", xdepto.RegistroDato.c_UtilidadOferta.c_Valor)
                                        .AddWithValue("@tasa", xdepto.RegistroDato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@medida_precio_1", xdepto.RegistroDato.c_MedidaPrecio1.c_Texto).Size = xdepto.RegistroDato.c_MedidaPrecio1.c_Largo
                                        .AddWithValue("@medida_precio_2", xdepto.RegistroDato.c_MedidaPrecio2.c_Texto).Size = xdepto.RegistroDato.c_MedidaPrecio2.c_Largo
                                        .AddWithValue("@medida_precio_3", xdepto.RegistroDato.c_MedidaPrecio3.c_Texto).Size = xdepto.RegistroDato.c_MedidaPrecio3.c_Largo
                                        .AddWithValue("@medida_precio_4", xdepto.RegistroDato.c_MedidaPrecio4.c_Texto).Size = xdepto.RegistroDato.c_MedidaPrecio4.c_Largo
                                        .AddWithValue("@medida_precio_pto_venta", xdepto.RegistroDato.c_MedidaPrecioPtoVenta.c_Texto).Size = xdepto.RegistroDato.c_MedidaPrecioPtoVenta.c_Largo
                                        .AddWithValue("@estatus_corte", xdepto.RegistroDato.c_EstatusCorte.c_Texto).Size = xdepto.RegistroDato.c_EstatusCorte.c_Largo
                                        .AddWithValue("@corte", xdepto.RegistroDato.c_Corte.c_Texto).Size = xdepto.RegistroDato.c_Corte.c_Largo
                                        .AddWithValue("@estatus_website", xdepto.RegistroDato.c_EstatusWebSite.c_Texto).Size = xdepto.RegistroDato.c_EstatusWebSite.c_Largo
                                        .AddWithValue("@detalle", xdepto.RegistroDato.c_Detalle.c_Texto).Size = xdepto.RegistroDato.c_Detalle.c_Largo
                                        .AddWithValue("@estatus_departamento", xdepto.RegistroDato.c_EstatusDepartamento.c_Texto).Size = xdepto.RegistroDato.c_EstatusDepartamento.c_Largo
                                        .AddWithValue("@estatus_replica", xdepto.RegistroDato.c_EstatusReplica.c_Texto).Size = xdepto.RegistroDato.c_EstatusReplica.c_Largo
                                        .AddWithValue("@numero_parte", xdepto.RegistroDato.c_NumeroParte.c_Texto).Size = xdepto.RegistroDato.c_NumeroParte.c_Largo
                                        .AddWithValue("@estatus_foto", xdepto.RegistroDato.c_EstatusFoto.c_Texto).Size = xdepto.RegistroDato.c_EstatusFoto.c_Largo
                                        '25/11/2014
                                        .AddWithValue("@EstaRegulado", xdepto.RegistroDato.c_EstaRegulado.c_Texto).Size = xdepto.RegistroDato.c_EstaRegulado.c_Largo
                                        .AddWithValue("@EstaRestringidoVenta", xdepto.RegistroDato.c_EstaRestringidoVenta.c_Texto).Size = xdepto.RegistroDato.c_EstaRestringidoVenta.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2601 Then
                                    Throw New Exception("EXISTE UN PRODUCTO / DEPARTAMENTO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Number)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL AGREGAR DEPT PARA EL (POS)" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarDeptoPtoVenta(ByVal xdepto As c_ModificarDepartamentoPtoVentas) As Boolean
                    Try
                        With xdepto.RegistroDato
                            .c_FechaUltCambio.c_Valor = .c_FechaAlta.c_Valor
                        End With

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from productos_subgrupo where auto_grupo=@auto_grupo"
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xdepto.RegistroDato.c_AutomaticoGrupo.c_Texto)
                                    Dim xobj As Object = Nothing
                                    xobj = xcmd.ExecuteScalar()
                                    If IsDBNull(xobj) Or IsNothing(xobj) Then
                                        Throw New Exception("NO HAY UN SUBGRUPO ASIGNADO PARA ESTE GRUPO")
                                    Else
                                        xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Texto = xobj.ToString
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = UpdateDeptoPtoVenta_1
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xdepto.RegistroDato.c_Automatico.c_Texto).Size = xdepto.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@nombre", xdepto.RegistroDato.c_NombreProducto.c_Texto).Size = xdepto.RegistroDato.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombre_corto", xdepto.RegistroDato.c_NombreProductoResumen.c_Texto).Size = xdepto.RegistroDato.c_NombreProductoResumen.c_Largo
                                        .AddWithValue("@auto_departamento", xdepto.RegistroDato.c_AutomaticoDepartamento.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoDepartamento.c_Largo
                                        .AddWithValue("@auto_grupo", xdepto.RegistroDato.c_AutomaticoGrupo.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoGrupo.c_Largo
                                        .AddWithValue("@auto_subgrupo", xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoSubGrupo.c_Largo
                                        .AddWithValue("@impuesto", xdepto.RegistroDato.c_TipoImpuesto.c_Texto).Size = xdepto.RegistroDato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@tasa", xdepto.RegistroDato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@auto_medida_compra", xdepto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Largo
                                        .AddWithValue("@auto_medida_venta", xdepto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Largo
                                        .AddWithValue("@fecha_cambio_precio", xdepto.RegistroDato.c_FechaUltCambio.c_Valor)
                                        .AddWithValue("@estatus", xdepto.RegistroDato.c_EstatusProducto.c_Texto).Size = xdepto.RegistroDato.c_EstatusProducto.c_Largo
                                        .AddWithValue("@auto_marca", xdepto.RegistroDato.c_AutomaticoMarca.c_Texto).Size = xdepto.RegistroDato.c_AutomaticoMarca.c_Largo
                                        .AddWithValue("@id_seguridad", xdepto.RegistroDato.c_IdSeguridad)
                                    End With
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("REGISTRO HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2601 Then
                                    Throw New Exception("EXISTE UN PRODUCTO / DEPARTAMENTO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Number)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PROBLEMA AL ACTUALIZAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AgregarProducto(ByVal xagregarproducto As c_AgregarProducto) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xauto As String = ""
                        Dim xsql_1 As String = "update contadores set a_productos=a_productos+1;select a_productos from contadores"
                        Dim xsql_2 As String = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                        Dim xsql_3 As String = "update contadores set a_productos_historico_costos=a_productos_historico_costos+1;select a_productos_historico_costos from contadores"

                        With xagregarproducto.RegistroDato
                            .c_EstatusBalanza.c_Texto = "0"
                            .c_EstatusCorte.c_Texto = "0"
                            .c_EstatusDepartamento.c_Texto = "0"
                            .c_EstatusEmpaque.c_Texto = "0"
                            .c_EstatusEnvasado.c_Texto = "0"
                            .c_EstatusGarantia.c_Texto = "0"
                            .c_EstatusLicor.c_Texto = "0"
                            .c_EstatusOferta.c_Texto = "0"
                            .c_EstatusReplica.c_Texto = "0"
                            .c_EstatusSerial.c_Texto = "0"
                            .c_EstatusWebSite.c_Texto = "0"
                            .c_FechaUltCambio.c_Valor = .c_FechaAlta.c_Valor
                            .c_InicioOferta.c_Valor = .c_FechaAlta.c_Valor
                            .c_FinOferta.c_Valor = .c_FechaAlta.c_Valor
                            .c_EstatusFoto.c_Texto = "0"
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'CONTADOR PRODUCTO
                                    xcmd.CommandText = xsql_1
                                    xagregarproducto.RegistroDato.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'PRODUCTOS
                                    xcmd.CommandText = INSERT_PRODUCTO
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xagregarproducto.RegistroDato.c_Automatico.c_Texto).Size = xagregarproducto.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@codigo", xagregarproducto.RegistroDato.c_CodigoProducto.c_Texto).Size = xagregarproducto.RegistroDato.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombre", xagregarproducto.RegistroDato.c_NombreProducto.c_Texto).Size = xagregarproducto.RegistroDato.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombre_corto", xagregarproducto.RegistroDato.c_NombreProductoResumen.c_Texto).Size = xagregarproducto.RegistroDato.c_NombreProductoResumen.c_Largo
                                        .AddWithValue("@auto_departamento", xagregarproducto.RegistroDato.c_AutomaticoDepartamento.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoDepartamento.c_Largo
                                        .AddWithValue("@auto_grupo", xagregarproducto.RegistroDato.c_AutomaticoGrupo.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoGrupo.c_Largo
                                        .AddWithValue("@auto_subgrupo", xagregarproducto.RegistroDato.c_AutomaticoSubGrupo.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoSubGrupo.c_Largo
                                        .AddWithValue("@impuesto", xagregarproducto.RegistroDato.c_TipoImpuesto.c_Texto).Size = xagregarproducto.RegistroDato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@auto_medida_compra", xagregarproducto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Largo
                                        .AddWithValue("@auto_medida_venta", xagregarproducto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Largo
                                        .AddWithValue("@factor_existencia", xagregarproducto.RegistroDato.c_FactorExistencia.c_Valor)
                                        .AddWithValue("@costo_proveedor_compra", xagregarproducto.RegistroDato.c_CostoProveedorCompra.c_Valor)
                                        .AddWithValue("@costo_proveedor_inventario", xagregarproducto.RegistroDato.c_CostoProveedorInventario.c_Valor)
                                        .AddWithValue("@costo_importacion_compra", xagregarproducto.RegistroDato.c_CostoImportacionCompra.c_Valor)
                                        .AddWithValue("@costo_importacion_inventario", xagregarproducto.RegistroDato.c_CostoImportacionInventario.c_Valor)
                                        .AddWithValue("@costo_varios_compra", xagregarproducto.RegistroDato.c_CostoVariosCompra.c_Valor)
                                        .AddWithValue("@costo_varios_inventario", xagregarproducto.RegistroDato.c_CostoVariosInventario.c_Valor)
                                        .AddWithValue("@costo_compra", xagregarproducto.RegistroDato.c_CostoCompra.c_Valor)
                                        .AddWithValue("@costo_inventario", xagregarproducto.RegistroDato.c_CostoInventario.c_Valor)
                                        .AddWithValue("@costo_promedio_compra", xagregarproducto.RegistroDato.c_CostoPromedioCompra.c_Valor)
                                        .AddWithValue("@costo_promedio_inventario", xagregarproducto.RegistroDato.c_CostoPromedioInventario.c_Valor)
                                        .AddWithValue("@estatus_empaque", xagregarproducto.RegistroDato.c_EstatusEmpaque.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusEmpaque.c_Largo
                                        .AddWithValue("@utilidad_1", xagregarproducto.RegistroDato.c_Utilidad1.c_Valor)
                                        .AddWithValue("@utilidad_2", xagregarproducto.RegistroDato.c_Utilidad2.c_Valor)
                                        .AddWithValue("@utilidad_3", xagregarproducto.RegistroDato.c_Utilidad3.c_Valor)
                                        .AddWithValue("@utilidad_4", xagregarproducto.RegistroDato.c_Utilidad4.c_Valor)
                                        .AddWithValue("@precio_1", xagregarproducto.RegistroDato.c_Precio1.c_Valor)
                                        .AddWithValue("@precio_2", xagregarproducto.RegistroDato.c_Precio2.c_Valor)
                                        .AddWithValue("@precio_3", xagregarproducto.RegistroDato.c_Precio3.c_Valor)
                                        .AddWithValue("@precio_4", xagregarproducto.RegistroDato.c_Precio4.c_Valor)
                                        .AddWithValue("@por_llegar", xagregarproducto.RegistroDato.c_PorLLegar.c_Valor)
                                        .AddWithValue("@estatus_balanza", xagregarproducto.RegistroDato.c_EstatusBalanza.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusBalanza.c_Largo
                                        .AddWithValue("@plu", xagregarproducto.RegistroDato.c_PLU.c_Texto).Size = xagregarproducto.RegistroDato.c_PLU.c_Largo
                                        .AddWithValue("@pesado_unidad", xagregarproducto.RegistroDato.c_PesadoUnidad.c_Texto).Size = xagregarproducto.RegistroDato.c_PesadoUnidad.c_Largo
                                        .AddWithValue("@estatus_envasado", xagregarproducto.RegistroDato.c_EstatusEnvasado.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusEnvasado.c_Largo
                                        .AddWithValue("@dias_envasado", xagregarproducto.RegistroDato.c_DiasEnvasado.c_Valor)
                                        .AddWithValue("@extra_1", xagregarproducto.RegistroDato.c_Extra1.c_Texto).Size = xagregarproducto.RegistroDato.c_Extra1.c_Largo
                                        .AddWithValue("@dias_garantia", xagregarproducto.RegistroDato.c_DiasGarantia.c_Valor)
                                        .AddWithValue("@modelo", xagregarproducto.RegistroDato.c_Modelo.c_Texto).Size = xagregarproducto.RegistroDato.c_Modelo.c_Largo
                                        .AddWithValue("@comentarios", xagregarproducto.RegistroDato.c_Comentarios.c_Texto).Size = xagregarproducto.RegistroDato.c_Comentarios.c_Largo
                                        .AddWithValue("@fecha_cambio_precio", xagregarproducto.RegistroDato.c_FechaUltCambio.c_Valor)
                                        .AddWithValue("@referencia", xagregarproducto.RegistroDato.c_Referencia.c_Texto).Size = xagregarproducto.RegistroDato.c_Referencia.c_Largo
                                        .AddWithValue("@contenido_empaque", xagregarproducto.RegistroDato.c_ContEmpCompra.c_Valor)
                                        .AddWithValue("@psv", xagregarproducto.RegistroDato.c_PrecioSugerido.c_Valor)
                                        .AddWithValue("@contable_producto", xagregarproducto.RegistroDato.c_CtaContable.c_Texto).Size = xagregarproducto.RegistroDato.c_CtaContable.c_Largo
                                        .AddWithValue("@contenido_empaque_venta", xagregarproducto.RegistroDato.c_ContEmpVentaDetal.c_Valor)
                                        .AddWithValue("@estatus", xagregarproducto.RegistroDato.c_EstatusProducto.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusProducto.c_Largo
                                        .AddWithValue("@advertencia", xagregarproducto.RegistroDato.c_Advertencia.c_Texto).Size = xagregarproducto.RegistroDato.c_Advertencia.c_Largo
                                        .AddWithValue("@fecha_alta", xagregarproducto.RegistroDato.c_FechaAlta.c_Valor)
                                        .AddWithValue("@extra_2", xagregarproducto.RegistroDato.c_Extra2.c_Texto).Size = xagregarproducto.RegistroDato.c_Extra2.c_Largo
                                        .AddWithValue("@categoria", xagregarproducto.RegistroDato.c_CategoriaProducto.c_Texto).Size = xagregarproducto.RegistroDato.c_CategoriaProducto.c_Largo
                                        .AddWithValue("@origen", xagregarproducto.RegistroDato.c_OrigenProducto.c_Texto).Size = xagregarproducto.RegistroDato.c_OrigenProducto.c_Largo
                                        .AddWithValue("@alto", xagregarproducto.RegistroDato.c_Alto.c_Valor)
                                        .AddWithValue("@largo", xagregarproducto.RegistroDato.c_Largo.c_Valor)
                                        .AddWithValue("@ancho", xagregarproducto.RegistroDato.c_Ancho.c_Valor)
                                        .AddWithValue("@peso", xagregarproducto.RegistroDato.c_Peso.c_Valor)
                                        .AddWithValue("@codigo_arancel", xagregarproducto.RegistroDato.c_CodigoArancel.c_Texto).Size = xagregarproducto.RegistroDato.c_CodigoArancel.c_Largo
                                        .AddWithValue("@tasa_arancel", xagregarproducto.RegistroDato.c_TasaArancel.c_Valor)
                                        .AddWithValue("@auto_marca", xagregarproducto.RegistroDato.c_AutomaticoMarca.c_Texto).Size = xagregarproducto.RegistroDato.c_AutomaticoMarca.c_Largo
                                        .AddWithValue("@estatus_garantia", xagregarproducto.RegistroDato.c_EstatusGarantia.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusGarantia.c_Largo
                                        .AddWithValue("@estatus_serial", xagregarproducto.RegistroDato.c_EstatusSerial.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusSerial.c_Largo
                                        .AddWithValue("@precio_pto_venta", xagregarproducto.RegistroDato.c_PrecioNetoPtoVenta.c_Valor)
                                        .AddWithValue("@utilidad_pto_venta", xagregarproducto.RegistroDato.c_UtilidadPtoVenta.c_Valor)
                                        .AddWithValue("@estatus_licor", xagregarproducto.RegistroDato.c_EstatusLicor.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusLicor.c_Largo
                                        .AddWithValue("@capacidad", xagregarproducto.RegistroDato.c_CapacidadBotella.c_Valor)
                                        .AddWithValue("@grados", xagregarproducto.RegistroDato.c_GradosAlchohol.c_Valor)
                                        .AddWithValue("@tasa_licor", xagregarproducto.RegistroDato.c_TasaLicor.c_Valor)
                                        .AddWithValue("@estatus_oferta", xagregarproducto.RegistroDato.c_EstatusOferta.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusOferta.c_Largo
                                        .AddWithValue("@inicio", xagregarproducto.RegistroDato.c_InicioOferta.c_Valor)
                                        .AddWithValue("@fin", xagregarproducto.RegistroDato.c_FinOferta.c_Valor)
                                        .AddWithValue("@precio_oferta", xagregarproducto.RegistroDato.c_PrecioOferta.c_Valor)
                                        .AddWithValue("@etiqueta", xagregarproducto.RegistroDato.c_Etiqueta.c_Texto).Size = xagregarproducto.RegistroDato.c_Etiqueta.c_Largo
                                        .AddWithValue("@publicidad", xagregarproducto.RegistroDato.c_Publicidad.c_Texto).Size = xagregarproducto.RegistroDato.c_Publicidad.c_Largo
                                        .AddWithValue("@utilidad_oferta", xagregarproducto.RegistroDato.c_UtilidadOferta.c_Valor)
                                        .AddWithValue("@tasa", xagregarproducto.RegistroDato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@medida_precio_1", xagregarproducto.RegistroDato.c_MedidaPrecio1.c_Texto).Size = xagregarproducto.RegistroDato.c_MedidaPrecio1.c_Largo
                                        .AddWithValue("@medida_precio_2", xagregarproducto.RegistroDato.c_MedidaPrecio2.c_Texto).Size = xagregarproducto.RegistroDato.c_MedidaPrecio2.c_Largo
                                        .AddWithValue("@medida_precio_3", xagregarproducto.RegistroDato.c_MedidaPrecio3.c_Texto).Size = xagregarproducto.RegistroDato.c_MedidaPrecio3.c_Largo
                                        .AddWithValue("@medida_precio_4", xagregarproducto.RegistroDato.c_MedidaPrecio4.c_Texto).Size = xagregarproducto.RegistroDato.c_MedidaPrecio4.c_Largo
                                        .AddWithValue("@medida_precio_pto_venta", xagregarproducto.RegistroDato.c_MedidaPrecioPtoVenta.c_Texto).Size = xagregarproducto.RegistroDato.c_MedidaPrecioPtoVenta.c_Largo
                                        .AddWithValue("@estatus_corte", xagregarproducto.RegistroDato.c_EstatusCorte.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusCorte.c_Largo
                                        .AddWithValue("@corte", xagregarproducto.RegistroDato.c_Corte.c_Texto).Size = xagregarproducto.RegistroDato.c_Corte.c_Largo
                                        .AddWithValue("@estatus_website", xagregarproducto.RegistroDato.c_EstatusWebSite.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusWebSite.c_Largo
                                        .AddWithValue("@detalle", xagregarproducto.RegistroDato.c_Detalle.c_Texto).Size = xagregarproducto.RegistroDato.c_Detalle.c_Largo
                                        .AddWithValue("@estatus_departamento", xagregarproducto.RegistroDato.c_EstatusDepartamento.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusDepartamento.c_Largo
                                        .AddWithValue("@estatus_replica", xagregarproducto.RegistroDato.c_EstatusReplica.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusReplica.c_Largo
                                        .AddWithValue("@numero_parte", xagregarproducto.RegistroDato.c_NumeroParte.c_Texto).Size = xagregarproducto.RegistroDato.c_NumeroParte.c_Largo
                                        .AddWithValue("@estatus_foto", xagregarproducto.RegistroDato.c_EstatusFoto.c_Texto).Size = xagregarproducto.RegistroDato.c_EstatusFoto.c_Largo
                                        '25/11/2014
                                        .AddWithValue("@EstaRegulado", xagregarproducto.RegistroDato.c_EstaRegulado.c_Texto).Size = xagregarproducto.RegistroDato.c_EstaRegulado.c_Largo
                                        .AddWithValue("@EstaRestringidoVenta", xagregarproducto.RegistroDato.c_EstaRestringidoVenta.c_Texto).Size = xagregarproducto.RegistroDato.c_EstaRestringidoVenta.c_Largo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    'PRODUCTOS_DEPOSITO 
                                    Dim xdep As New FichaProducto.Prd_Deposito.c_Registro
                                    With xdep
                                        .c_AutomaticoDeposito.c_Texto = xagregarproducto._AutoDepositoDefecto
                                        .c_AutomaticoProducto.c_Texto = xagregarproducto.RegistroDato.c_Automatico.c_Texto
                                        .c_MercanciaDisponible.c_Valor = 0
                                        .c_MercanciaReal.c_Valor = 0
                                        .c_MercanciaReservada.c_Valor = 0
                                        .c_NivelMinimo.c_Valor = 0
                                        .c_NivelOptimo.c_Valor = 0
                                        .c_NivelPedido.c_Valor = 0
                                        .c_Ubicacion1.c_Texto = ""
                                        .c_Ubicacion2.c_Texto = ""
                                        .c_Ubicacion3.c_Texto = ""
                                        .c_Ubicacion4.c_Texto = ""
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PRODUCTOS_DEPOSITO
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdep.c_AutomaticoProducto.c_Texto).Size = xdep.c_AutomaticoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdep.c_AutomaticoDeposito.c_Texto).Size = xdep.c_AutomaticoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@real", xdep.c_MercanciaReal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@reservada", xdep.c_MercanciaReservada.c_Valor)
                                    xcmd.Parameters.AddWithValue("@disponible", xdep.c_MercanciaDisponible.c_Valor)
                                    xcmd.Parameters.AddWithValue("@ubicacion_1", xdep.c_Ubicacion1.c_Texto).Size = xdep.c_Ubicacion1.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_2", xdep.c_Ubicacion2.c_Texto).Size = xdep.c_Ubicacion2.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_3", xdep.c_Ubicacion3.c_Texto).Size = xdep.c_Ubicacion3.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_4", xdep.c_Ubicacion4.c_Texto).Size = xdep.c_Ubicacion4.c_Largo
                                    xcmd.Parameters.AddWithValue("@nivel_minimo", xdep.c_NivelMinimo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@pto_pedido", xdep.c_NivelPedido.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nivel_optimo", xdep.c_NivelOptimo.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'PRODUCTOS_EMPAQUE
                                    Dim xempq As New FichaProducto.Prd_Empaque.c_Registro
                                    With xempq
                                        .c_AutomaticoMedida.c_Texto = xagregarproducto.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto
                                        .c_AutomaticoProducto.c_Texto = xagregarproducto.RegistroDato.c_Automatico.c_Texto
                                        .c_ContenidoEmpaque.c_Valor = xagregarproducto.RegistroDato.c_ContEmpCompra.c_Valor
                                        .c_Precio_N1.c_Valor = 0
                                        .c_Precio_N2.c_Valor = 0
                                        .c_Utilidad_1.c_Valor = 0
                                        .c_Utilidad_2.c_Valor = 0
                                    End With

                                    For i As Integer = 1 To 4
                                        xempq.c_Referencia.c_Texto = i.ToString

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_EMPAQUE
                                        xcmd.Parameters.AddWithValue("@auto_producto", xempq.c_AutomaticoProducto.c_Texto).Size = xempq.c_AutomaticoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_1", xempq.c_Precio_N1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_2", xempq.c_Precio_N2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_medida", xempq.c_AutomaticoMedida.c_Texto).Size = xempq.c_AutomaticoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido", xempq.c_ContenidoEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidad_1", xempq.c_Utilidad_1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidad_2", xempq.c_Utilidad_2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@referencia", xempq.c_Referencia.c_Texto).Size = xempq.c_Referencia.c_Largo
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    Dim xhistorico As New Prd_HistoricoPrecios.c_Registro
                                    With xhistorico
                                        .c_AutoProducto.c_Texto = xagregarproducto.RegistroDato.c_Automatico.c_Texto
                                        .c_AutoUsuario.c_Texto = xagregarproducto._FichaUsuario._AutoUsuario
                                        .c_Empaque.c_Texto = xagregarproducto.RegistroDato._NombreEmpaqueCompra
                                        .c_EstacionEquipo.c_Texto = xagregarproducto._Equipoestacion
                                        .c_FechaMovimiento.c_Valor = xagregarproducto.RegistroDato.c_FechaAlta.c_Valor
                                        .c_Hora.c_Texto = xagregarproducto._Hora
                                        .c_Nota.c_Texto = "PRECIO INICIAL"
                                        .c_PrecioAnterior.c_Valor = 0
                                        .c_PrecioNuevo.c_Valor = 0
                                        .c_Usuario.c_Texto = xagregarproducto._FichaUsuario._NombreUsuario
                                        .c_ContenidoEmpaque.c_Valor = xagregarproducto.RegistroDato.c_ContEmpCompra.c_Valor
                                    End With

                                    'PRODUCTOS_HISTORICO_PRECIOS
                                    For i As Integer = 1 To 4
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql_2
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                        xhistorico.c_PrecioReferencia.c_Texto = "PRECIO " & i.ToString

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    'PRODUCTOS HOSTORICO COSTOS
                                    Dim xhistorico_costo As New Prd_HistoricoCostos.c_Registro
                                    Dim xobj As Object = Nothing
                                    xcmd.CommandText = "select a_productos_historico_costos from contadores"
                                    xobj = xcmd.ExecuteScalar()
                                    If IsDBNull(xobj) Then
                                        xcmd.CommandText = "update contadores set a_productos_historico_costos=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.CommandText = xsql_3
                                    xhistorico_costo.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    With xhistorico_costo
                                        .c_AutoDocumento.c_Texto = ""
                                        .c_AutoEntidad.c_Texto = ""
                                        .c_AutoProducto.c_Texto = xagregarproducto.RegistroDato.c_Automatico.c_Texto
                                        .c_AutoUsuario.c_Texto = xagregarproducto._FichaUsuario._AutoUsuario
                                        .c_CodigoUsuario.c_Texto = xagregarproducto._FichaUsuario._CodigoUsuario
                                        .c_ContenidoEmpaque.c_Valor = xagregarproducto.RegistroDato.c_ContEmpCompra.c_Valor
                                        .c_CostoActual.c_Valor = 0.0
                                        .c_CostoNuevo.c_Valor = 0.0
                                        .c_CostoReferencia.c_Valor = 0.0
                                        .c_Empaque.c_Texto = xagregarproducto.RegistroDato._NombreEmpaqueCompra
                                        .c_Entidad.c_Texto = ""
                                        .c_Estatus.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xagregarproducto.RegistroDato.c_FechaAlta.c_Valor
                                        .c_FechaProceso.c_Valor = xagregarproducto.RegistroDato.c_FechaAlta.c_Valor
                                        .c_Hora.c_Texto = xagregarproducto._Hora
                                        .c_NombreEstacionEquipo.c_Texto = xagregarproducto._Equipoestacion
                                        .c_Nota.c_Texto = "COSTO INICIAL AL CREAR PRODUCTO"
                                        .c_Origen.c_Texto = "0301"
                                        .c_Usuario.c_Texto = xagregarproducto._FichaUsuario._NombreUsuario
                                        .c_Documento.c_Texto = ""
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaProducto.Prd_HistoricoCostos.INSERT_PRODUCTOS_HISTORICO_COSTOS
                                    xcmd.Parameters.AddWithValue("@auto", xhistorico_costo.c_Automatico.c_Texto).Size = xhistorico_costo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xhistorico_costo.c_AutoDocumento.c_Texto).Size = xhistorico_costo.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xhistorico_costo.c_AutoEntidad.c_Texto).Size = xhistorico_costo.c_AutoEntidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xhistorico_costo.c_AutoProducto.c_Texto).Size = xhistorico_costo.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico_costo.c_AutoUsuario.c_Texto).Size = xhistorico_costo.c_AutoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", xhistorico_costo.c_CodigoUsuario.c_Texto).Size = xhistorico_costo.c_CodigoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico_costo.c_ContenidoEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo", xhistorico_costo.c_CostoReferencia.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_actual", xhistorico_costo.c_CostoActual.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_nuevo", xhistorico_costo.c_CostoNuevo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_carga", xhistorico_costo.c_FechaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_emision", xhistorico_costo.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xhistorico_costo.c_Empaque.c_Texto).Size = xhistorico_costo.c_Empaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@entidad", xhistorico_costo.c_Entidad.c_Texto).Size = xhistorico_costo.c_Entidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xhistorico_costo.c_NombreEstacionEquipo.c_Texto).Size = xhistorico_costo.c_NombreEstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xhistorico_costo.c_Estatus.c_Texto).Size = xhistorico_costo.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xhistorico_costo.c_Hora.c_Texto).Size = xhistorico_costo.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@nota", xhistorico_costo.c_Nota.c_Texto).Size = xhistorico_costo.c_Nota.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xhistorico_costo.c_Origen.c_Texto).Size = xhistorico_costo.c_Origen.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xhistorico_costo.c_Usuario.c_Texto).Size = xhistorico_costo.c_Usuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xhistorico_costo.c_Documento.c_Texto).Size = xhistorico_costo.c_Documento.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()

                                RaiseEvent _ProductoRegistrado(xagregarproducto.RegistroDato.c_Automatico.c_Texto)
                                Return True
                            Catch EXSQL As SqlException
                                xtr.Rollback()
                                Throw New Exception(EXSQL.Message)
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "AGREGAR PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' ELIMINAR UN PRODUCTO Y TODOS SUS DEPENDENCIAS
                ''' </summary>
                Function F_EliminarProducto(ByVal xauto As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim lista_sql As New List(Of String)

                        lista_sql.Add("delete from productos_alterno where auto_producto=@auto")
                        lista_sql.Add("delete from productos_deposito where auto_producto=@auto")
                        lista_sql.Add("delete from productos_empaque where auto_producto=@auto")
                        lista_sql.Add("delete from productos_historico_precios where auto_producto=@auto")
                        lista_sql.Add("delete from productos where auto=@auto")

                        Dim xp1 As SqlParameter = New SqlParameter("@auto", xauto)
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    For Each xsql As String In lista_sql
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql
                                        xcmd.Parameters.Add(xp1)
                                        xcmd.ExecuteNonQuery()
                                    Next
                                End Using
                                xtr.Commit()
                                Return True
                            Catch exsql As SqlException
                                xtr.Rollback()
                                If exsql.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR PRODUCTO, HAY MOVIMIENTOS EFECTUADOS PARA ESTE PRODUCTO")
                                Else
                                    Throw New Exception(exsql.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "ELIMINAR PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA PRINCIPAL DEL PRODUCTO
                ''' </summary>
                Function F_ModificarProducto_FichaPrincipal(ByVal xfichaprincipal As c_ModificarFichaPrincipalProducto) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update productos_alterno set estatus_alterno=@estatus_alterno where auto_producto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xfichaprincipal.RegistroDato.c_Automatico.c_Texto).Size = xfichaprincipal.RegistroDato.c_Automatico.c_Largo
                                    If xfichaprincipal.RegistroDato.c_EstatusProducto.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                        xcmd.Parameters.AddWithValue("@estatus_alterno", "0")
                                    Else
                                        xcmd.Parameters.AddWithValue("@estatus_alterno", "1")
                                    End If
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichaprincipal.RegistroDato.c_Automatico.c_Texto).Size = xfichaprincipal.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@codigo", xfichaprincipal.RegistroDato.c_CodigoProducto.c_Texto).Size = xfichaprincipal.RegistroDato.c_CodigoProducto.c_Largo
                                        .AddWithValue("@nombre", xfichaprincipal.RegistroDato.c_NombreProducto.c_Texto).Size = xfichaprincipal.RegistroDato.c_NombreProducto.c_Largo
                                        .AddWithValue("@nombre_corto", xfichaprincipal.RegistroDato.c_NombreProductoResumen.c_Texto).Size = xfichaprincipal.RegistroDato.c_NombreProductoResumen.c_Largo
                                        .AddWithValue("@auto_departamento", xfichaprincipal.RegistroDato.c_AutomaticoDepartamento.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoDepartamento.c_Largo
                                        .AddWithValue("@auto_grupo", xfichaprincipal.RegistroDato.c_AutomaticoGrupo.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoGrupo.c_Largo
                                        .AddWithValue("@auto_subgrupo", xfichaprincipal.RegistroDato.c_AutomaticoSubGrupo.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoSubGrupo.c_Largo
                                        .AddWithValue("@impuesto", xfichaprincipal.RegistroDato.c_TipoImpuesto.c_Texto).Size = xfichaprincipal.RegistroDato.c_TipoImpuesto.c_Largo
                                        .AddWithValue("@auto_medida_compra", xfichaprincipal.RegistroDato.c_AutomaticoEmpaqueCompra.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoEmpaqueCompra.c_Largo
                                        .AddWithValue("@auto_medida_venta", xfichaprincipal.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Largo
                                        .AddWithValue("@fecha_cambio_precio", xfichaprincipal.RegistroDato.c_FechaUltCambio.c_Valor)
                                        .AddWithValue("@contenido_empaque", xfichaprincipal.RegistroDato.c_ContEmpCompra.c_Valor)
                                        .AddWithValue("@contenido_empaque_venta", xfichaprincipal.RegistroDato.c_ContEmpVentaDetal.c_Valor)
                                        .AddWithValue("@estatus", xfichaprincipal.RegistroDato.c_EstatusProducto.c_Texto).Size = xfichaprincipal.RegistroDato.c_EstatusProducto.c_Largo
                                        .AddWithValue("@categoria", xfichaprincipal.RegistroDato.c_CategoriaProducto.c_Texto).Size = xfichaprincipal.RegistroDato.c_CategoriaProducto.c_Largo
                                        .AddWithValue("@origen", xfichaprincipal.RegistroDato.c_OrigenProducto.c_Texto).Size = xfichaprincipal.RegistroDato.c_OrigenProducto.c_Largo
                                        .AddWithValue("@tasa", xfichaprincipal.RegistroDato.c_TasaImpuesto.c_Valor)
                                        .AddWithValue("@auto_marca", xfichaprincipal.RegistroDato.c_AutomaticoMarca.c_Texto).Size = xfichaprincipal.RegistroDato.c_AutomaticoMarca.c_Largo
                                        .AddWithValue("@id_seguridad", xfichaprincipal.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaPrincipal
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA PRINCIPAL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA BALANZA DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaBalanza(ByVal xfichabalanza As c_ModificarFichaBalanza) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichabalanza.RegistroDato.c_Automatico.c_Texto).Size = xfichabalanza.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@plu", xfichabalanza.RegistroDato.c_PLU.c_Texto).Size = xfichabalanza.RegistroDato.c_PLU.c_Largo
                                        .AddWithValue("@estatus_balanza", xfichabalanza.RegistroDato.c_EstatusBalanza.c_Texto).Size = xfichabalanza.RegistroDato.c_EstatusBalanza.c_Largo
                                        .AddWithValue("@pesado_unidad", xfichabalanza.RegistroDato.c_PesadoUnidad.c_Texto).Size = xfichabalanza.RegistroDato.c_PesadoUnidad.c_Largo
                                        .AddWithValue("@id_seguridad", xfichabalanza.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaBalanza
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PROBLEMA AL MODIFICAR FICHA BALANZA DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA FOTO DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaFoto(ByVal xprd As c_Registro, ByVal xestatus As Boolean) As Boolean
                    Try
                        Dim UpdateProductos_FichaFoto As String = "update productos set " & _
                          "estatus_foto=@estatus_foto" & _
                          " where auto=@auto and id_seguridad=@id_seguridad"
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xprd._AutoProducto)
                                        .AddWithValue("@estatus_foto", IIf(xestatus = True, "1", "0")).Size = xprd.c_EstatusFoto.c_Largo
                                        .AddWithValue("@id_seguridad", xprd._IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaFoto
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA IMAGEN DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function


                ''' <summary>
                ''' MODIFICAR FICHA WEB DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaWeb(ByVal xfichaproducto As c_Registro, ByVal xestatus As Boolean) As Boolean
                    Try
                        Dim UpdateProductos_FichaWeb As String = "update productos set " & _
                          "estatus_website=@estatus_website where auto=@auto and id_seguridad=@id_seguridad"
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichaproducto._AutoProducto)
                                        .AddWithValue("@estatus_website", IIf(xestatus = True, "1", "0")).Size = xfichaproducto.c_EstatusWebSite.c_Largo
                                        .AddWithValue("@id_seguridad", xfichaproducto._IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaWeb
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PROBLEMA AL MODIFICAR FICHA WEB DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarFichaSerial(ByVal xfichaproducto As c_Registro, ByVal xestatus As Boolean) As Boolean
                    Try
                        Dim UpdateProductos_FichaWeb As String = "update productos set " & _
                          "estatus_serial=@estatus_serial where auto=@auto and id_seguridad=@id_seguridad"
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichaproducto._AutoProducto)
                                        .AddWithValue("@estatus_serial", IIf(xestatus = True, "1", "0")).Size = xfichaproducto.c_EstatusSerial.c_Largo
                                        .AddWithValue("@id_seguridad", xfichaproducto._IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaWeb
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PROBLEMA AL MODIFICAR FICHA SERIAL DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function


                ''' <summary>
                ''' MODIFICAR FICHA LICOR DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaLicor(ByVal xfichalicor As c_ModificarFichaLicor) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichalicor.RegistroDato.c_Automatico.c_Texto).Size = xfichalicor.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@capacidad", xfichalicor.RegistroDato.c_CapacidadBotella.c_Valor)
                                        .AddWithValue("@estatus_licor", xfichalicor.RegistroDato.c_EstatusLicor.c_Texto).Size = xfichalicor.RegistroDato.c_EstatusLicor.c_Largo
                                        .AddWithValue("@grados", xfichalicor.RegistroDato.c_GradosAlchohol.c_Valor)
                                        .AddWithValue("@tasa_licor", xfichalicor.RegistroDato.c_TasaLicor.c_Valor)
                                        .AddWithValue("@id_seguridad", xfichalicor.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaLicor
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA LICOR DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA GARANTIA DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaGarantia(ByVal xfichagarantia As c_ModificarFichaGarantia) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichagarantia.RegistroDato.c_Automatico.c_Texto).Size = xfichagarantia.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@dias_garantia", xfichagarantia.RegistroDato.c_DiasGarantia.c_Valor)
                                        .AddWithValue("@estatus_garantia", xfichagarantia.RegistroDato.c_EstatusGarantia.c_Texto).Size = xfichagarantia.RegistroDato.c_EstatusGarantia.c_Largo
                                        .AddWithValue("@id_seguridad", xfichagarantia.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaGarantia
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA GARANTIA DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA DIMENSIONES DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaDimensiones(ByVal xfichadimension As c_ModificarFichaDimensiones) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichadimension.RegistroDato.c_Automatico.c_Texto).Size = xfichadimension.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@alto", xfichadimension.RegistroDato.c_Alto.c_Valor)
                                        .AddWithValue("@ancho", xfichadimension.RegistroDato.c_Ancho.c_Valor)
                                        .AddWithValue("@largo", xfichadimension.RegistroDato.c_Largo.c_Valor)
                                        .AddWithValue("@peso", xfichadimension.RegistroDato.c_Peso.c_Valor)
                                        .AddWithValue("@codigo_arancel", xfichadimension.RegistroDato.c_CodigoArancel.c_Texto).Size = xfichadimension.RegistroDato.c_CodigoArancel.c_Largo
                                        .AddWithValue("@tasa_arancel", xfichadimension.RegistroDato.c_TasaArancel.c_Valor)
                                        .AddWithValue("@id_seguridad", xfichadimension.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaDimensiones
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA DIMENSIONES DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA CONTABILIDAD DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaContable(ByVal xfichacontable As c_ModificarFichaContabilidad) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichacontable.RegistroDato.c_Automatico.c_Texto).Size = xfichacontable.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@contable_producto", xfichacontable.RegistroDato.c_CtaContable.c_Texto).Size = xfichacontable.RegistroDato.c_CtaContable.c_Largo
                                        .AddWithValue("@id_seguridad", xfichacontable.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaContabilidad
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA CONTABLE DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA DETALLE DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaDetalle(ByVal xfichadetalle As c_ModificarFichaDetalle) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichadetalle.RegistroDato.c_Automatico.c_Texto).Size = xfichadetalle.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@referencia", xfichadetalle.RegistroDato.c_Referencia.c_Texto).Size = xfichadetalle.RegistroDato.c_Referencia.c_Largo
                                        .AddWithValue("@modelo", xfichadetalle.RegistroDato.c_Modelo.c_Texto).Size = xfichadetalle.RegistroDato.c_Modelo.c_Largo
                                        .AddWithValue("@numero_parte", xfichadetalle.RegistroDato.c_NumeroParte.c_Texto).Size = xfichadetalle.RegistroDato.c_NumeroParte.c_Largo
                                        .AddWithValue("@id_seguridad", xfichadetalle.RegistroDato.c_IdSeguridad)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaDetalle
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA DETALLE DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA COSTO DEL PRODUCTO
                ''' </summary>
                Function F_ModificarFichaCosto(ByVal xfichacosto As c_ModificarCosto) As Boolean
                    Try
                        Dim xsql_1 As String = "update contadores set a_productos_historico_costos=a_productos_historico_costos+1;select a_productos_historico_costos from contadores"
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Dim xci As Decimal = 0
                                If xfichacosto.RegistroDato.c_ContenidoEmpaque.c_Valor > 0 Then
                                    xci = xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor / xfichacosto.RegistroDato.c_ContenidoEmpaque.c_Valor
                                    xci = Decimal.Round(xci, 2, MidpointRounding.AwayFromZero)
                                End If

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'PRODUCTOS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = UpdateProductosCostos
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichacosto.RegistroDato.c_AutoProducto.c_Texto).Size = xfichacosto.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@costo_proveedor_compra", xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor)
                                        .AddWithValue("@costo_proveedor_inventario", xci)
                                        .AddWithValue("@costo_compra", xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor)
                                        .AddWithValue("@costo_inventario", xci)
                                        .AddWithValue("@costo_promedio_compra", xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor)
                                        .AddWithValue("@costo_promedio_inventario", xci)
                                        .AddWithValue("@id_seguridad", xfichacosto._IdSeguridad)
                                    End With
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                    xfichacosto.RegistroDato.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xfichacosto.RegistroDato.c_PrecioReferencia.c_Texto = "COSTO"

                                    With xfichacosto
                                        .RegistroDato.c_AutoUsuario.c_Texto = xfichacosto._FichaUsuario.c_UsuarioAuto.c_Texto
                                        .RegistroDato.c_Usuario.c_Texto = xfichacosto._FichaUsuario.c_UsuarioNombre.c_Texto
                                        .RegistroDato.c_Nota.c_Texto = "ACTUALIZACION AUTORIZADA. MODULO ALMACEN"
                                    End With

                                    'PRODUCTOS_HISTORICO_PRECIOS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                    xcmd.Parameters.AddWithValue("@auto", xfichacosto.RegistroDato.c_Automatico.c_Texto).Size = xfichacosto.RegistroDato.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xfichacosto.RegistroDato.c_AutoProducto.c_Texto).Size = xfichacosto.RegistroDato.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xfichacosto.RegistroDato.c_FechaMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estacion", xfichacosto.RegistroDato.c_EstacionEquipo.c_Texto).Size = xfichacosto.RegistroDato.c_EstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xfichacosto.RegistroDato.c_AutoUsuario.c_Texto).Size = xfichacosto.RegistroDato.c_AutoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@precio_id", xfichacosto.RegistroDato.c_PrecioReferencia.c_Texto).Size = xfichacosto.RegistroDato.c_PrecioReferencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@precio_anterior", xfichacosto.RegistroDato.c_PrecioAnterior.c_Valor)
                                    xcmd.Parameters.AddWithValue("@precio_nuevo", xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xfichacosto.RegistroDato.c_Empaque.c_Texto).Size = xfichacosto.RegistroDato.c_Empaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@nota", xfichacosto.RegistroDato.c_Nota.c_Texto).Size = xfichacosto.RegistroDato.c_Nota.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xfichacosto.RegistroDato.c_Usuario.c_Texto).Size = xfichacosto.RegistroDato.c_Usuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xfichacosto.RegistroDato.c_Hora.c_Texto).Size = xfichacosto.RegistroDato.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xfichacosto.RegistroDato.c_ContenidoEmpaque.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'PRODUCTOS HOSTORICO COSTOS
                                    Dim xhistorico_costo As New Prd_HistoricoCostos.c_Registro
                                    Dim xobj As Object = Nothing
                                    xcmd.CommandText = "select a_productos_historico_costos from contadores"
                                    xobj = xcmd.ExecuteScalar()
                                    If IsDBNull(xobj) Then
                                        xcmd.CommandText = "update contadores set a_productos_historico_costos=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.CommandText = xsql_1
                                    xhistorico_costo.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    With xhistorico_costo
                                        .c_AutoDocumento.c_Texto = ""
                                        .c_AutoEntidad.c_Texto = ""
                                        .c_AutoProducto.c_Texto = xfichacosto.RegistroDato.c_AutoProducto.c_Texto
                                        .c_AutoUsuario.c_Texto = xfichacosto._FichaUsuario._AutoUsuario
                                        .c_CodigoUsuario.c_Texto = xfichacosto._FichaUsuario._CodigoUsuario
                                        .c_ContenidoEmpaque.c_Valor = xfichacosto.RegistroDato.c_ContenidoEmpaque.c_Valor
                                        .c_CostoActual.c_Valor = xfichacosto.RegistroDato.c_PrecioAnterior.c_Valor
                                        .c_CostoNuevo.c_Valor = xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor
                                        .c_CostoReferencia.c_Valor = xfichacosto.RegistroDato.c_PrecioNuevo.c_Valor
                                        .c_Empaque.c_Texto = xfichacosto.RegistroDato.c_Empaque.c_Texto
                                        .c_Entidad.c_Texto = ""
                                        .c_Estatus.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xfichacosto.RegistroDato.c_FechaMovimiento.c_Valor
                                        .c_FechaProceso.c_Valor = xfichacosto.RegistroDato.c_FechaMovimiento.c_Valor
                                        .c_Hora.c_Texto = xfichacosto.RegistroDato.c_Hora.c_Texto
                                        .c_NombreEstacionEquipo.c_Texto = xfichacosto.RegistroDato.c_EstacionEquipo.c_Texto
                                        .c_Nota.c_Texto = "ACTUALIZACION COSTO FICHA PRODUCTO"
                                        .c_Origen.c_Texto = "0301"
                                        .c_Usuario.c_Texto = xfichacosto._FichaUsuario._NombreUsuario
                                        .c_Documento.c_Texto = ""
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaProducto.Prd_HistoricoCostos.INSERT_PRODUCTOS_HISTORICO_COSTOS
                                    xcmd.Parameters.AddWithValue("@auto", xhistorico_costo.c_Automatico.c_Texto).Size = xhistorico_costo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xhistorico_costo.c_AutoDocumento.c_Texto).Size = xhistorico_costo.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_entidad", xhistorico_costo.c_AutoEntidad.c_Texto).Size = xhistorico_costo.c_AutoEntidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_producto", xhistorico_costo.c_AutoProducto.c_Texto).Size = xhistorico_costo.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico_costo.c_AutoUsuario.c_Texto).Size = xhistorico_costo.c_AutoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", xhistorico_costo.c_CodigoUsuario.c_Texto).Size = xhistorico_costo.c_CodigoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico_costo.c_ContenidoEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo", xhistorico_costo.c_CostoReferencia.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_actual", xhistorico_costo.c_CostoActual.c_Valor)
                                    xcmd.Parameters.AddWithValue("@costo_nuevo", xhistorico_costo.c_CostoNuevo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_carga", xhistorico_costo.c_FechaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_emision", xhistorico_costo.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xhistorico_costo.c_Empaque.c_Texto).Size = xhistorico_costo.c_Empaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@entidad", xhistorico_costo.c_Entidad.c_Texto).Size = xhistorico_costo.c_Entidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xhistorico_costo.c_NombreEstacionEquipo.c_Texto).Size = xhistorico_costo.c_NombreEstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xhistorico_costo.c_Estatus.c_Texto).Size = xhistorico_costo.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xhistorico_costo.c_Hora.c_Texto).Size = xhistorico_costo.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@nota", xhistorico_costo.c_Nota.c_Texto).Size = xhistorico_costo.c_Nota.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xhistorico_costo.c_Origen.c_Texto).Size = xhistorico_costo.c_Origen.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xhistorico_costo.c_Usuario.c_Texto).Size = xhistorico_costo.c_Usuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xhistorico_costo.c_Documento.c_Texto).Size = xhistorico_costo.c_Documento.c_Largo
                                    xcmd.ExecuteNonQuery()

                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA COSTO DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' MODIFICAR FICHA EVENTO / PRESUPUESTO
                ''' </summary>
                Function F_ModificarFichaPresupuestoEvento(ByVal xfichaevento As c_ModificarFichaEventoPresupuesto) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xfichaevento._AutoPrd)
                                        .AddWithValue("@estatus_consumo", IIf(xfichaevento._HabilitarParaPresupuestoEvento, "1", "0"))
                                        .AddWithValue("@cant_consumo", xfichaevento._CantidadConsumoPorPersona)
                                        .AddWithValue("@id_seguridad", xfichaevento._ID)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaPresupuestoEvento
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA BALANZA DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function


                ''' <summary>
                ''' 25/11/2014
                ''' MODIFICAR FICHA ESTATUS PRODUCTO 
                ''' </summary>
                Function F_ModificarFichaEstatusProducto(ByVal xficha As c_ModificarFichaEstatusProducto) As Boolean
                    Try
                        Dim xtr As SqlTransaction

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xficha._AutoPrd)
                                        .AddWithValue("@EstaRegulado", IIf(xficha._Regulado = TipoSiNo.Si, "1", ""))
                                        .AddWithValue("@EstaRestringidoVenta", IIf(xficha._Restringido = TipoSiNo.Si, "1", ""))
                                        .AddWithValue("@id_seguridad", xficha._ID)
                                    End With
                                    xcmd.CommandText = UpdateProductos_FichaEstatusProducto
                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL ACTUALIZAR DATOS DEL PRODUCTO... FICHA YA FUE ACTUALIZADA POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "MODIFICAR FICHA ESTATUS DEL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AgregarDeposito(ByVal xprddep As c_AgregarProductoDeposito) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    'PRODUCTOS_DEPOSITO 
                                    Dim xdep As New FichaProducto.Prd_Deposito.c_Registro
                                    With xdep
                                        .c_AutomaticoDeposito.c_Texto = xprddep._AutoDeposito
                                        .c_AutomaticoProducto.c_Texto = xprddep._AutoProducto
                                        .c_MercanciaDisponible.c_Valor = 0
                                        .c_MercanciaReal.c_Valor = 0
                                        .c_MercanciaReservada.c_Valor = 0
                                        .c_NivelMinimo.c_Valor = 0
                                        .c_NivelOptimo.c_Valor = 0
                                        .c_NivelPedido.c_Valor = 0
                                        .c_Ubicacion1.c_Texto = ""
                                        .c_Ubicacion2.c_Texto = ""
                                        .c_Ubicacion3.c_Texto = ""
                                        .c_Ubicacion4.c_Texto = ""
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PRODUCTOS_DEPOSITO
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdep.c_AutomaticoProducto.c_Texto).Size = xdep.c_AutomaticoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdep.c_AutomaticoDeposito.c_Texto).Size = xdep.c_AutomaticoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@real", xdep.c_MercanciaReal.c_Valor)
                                    xcmd.Parameters.AddWithValue("@reservada", xdep.c_MercanciaReservada.c_Valor)
                                    xcmd.Parameters.AddWithValue("@disponible", xdep.c_MercanciaDisponible.c_Valor)
                                    xcmd.Parameters.AddWithValue("@ubicacion_1", xdep.c_Ubicacion1.c_Texto).Size = xdep.c_Ubicacion1.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_2", xdep.c_Ubicacion2.c_Texto).Size = xdep.c_Ubicacion2.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_3", xdep.c_Ubicacion3.c_Texto).Size = xdep.c_Ubicacion3.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_4", xdep.c_Ubicacion4.c_Texto).Size = xdep.c_Ubicacion4.c_Largo
                                    xcmd.Parameters.AddWithValue("@nivel_minimo", xdep.c_NivelMinimo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@pto_pedido", xdep.c_NivelPedido.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nivel_optimo", xdep.c_NivelOptimo.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    Return True
                                End Using
                            Catch ex2 As SqlException
                                If ex2.Number = 557 Then
                                    Throw New Exception("DEPOSITO NO ENCONTRADO / ELIMINADO POR OTRO USUARIO")
                                ElseIf ex2.Number = 2601 Then
                                    Throw New Exception("DEPOSITO YA REGISTRADO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "AGREGAR DEPOSITO AL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarDeposito(ByVal xprddep As c_AgregarProductoDeposito) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'PRODUCTOS_DEPOSITO 
                                    Dim xdep As New FichaProducto.Prd_Deposito.c_Registro
                                    With xdep
                                        .c_AutomaticoDeposito.c_Texto = xprddep._AutoDeposito
                                        .c_AutomaticoProducto.c_Texto = xprddep._AutoProducto
                                    End With

                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "DELETE PRODUCTOS_DEPOSITO WHERE AUTO_PRODUCTO=@AUTO_PRODUCTO AND AUTO_DEPOSITO=@AUTO_DEPOSITO"
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdep.c_AutomaticoProducto.c_Texto).Size = xdep.c_AutomaticoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdep.c_AutomaticoDeposito.c_Texto).Size = xdep.c_AutomaticoDeposito.c_Largo
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("DEPOSITO YA FUE ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 557 Then
                                    Throw New Exception("DEPOSITO NO ENCONTRADO / ELIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS:" + vbCrLf + "ELIMINAR DEPOSITO AL PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' PERMITE ACUTALIZAR DATOS DE UBICACION Y NIVEL DEL PRPODUCTO EN EL DEPOSITO DESEADO
                ''' </summary>
                Function F_ModficarDatosDeposito(ByVal xprddep As c_ModificarDatosDeposito) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xdep As New FichaProducto.Prd_Deposito.c_Registro
                        With xdep
                            .c_AutomaticoDeposito.c_Texto = xprddep._FichaProductoDeposito._AutoDeposito
                            .c_AutomaticoProducto.c_Texto = xprddep._FichaProductoDeposito._AutoProducto
                            .c_NivelMinimo.c_Valor = xprddep._NivelMinimo
                            .c_NivelOptimo.c_Valor = xprddep._NivelOptimo
                            .c_Ubicacion1.c_Texto = xprddep._Ubicacion1
                            .c_Ubicacion2.c_Texto = xprddep._Ubicacion2
                            .c_Ubicacion3.c_Texto = xprddep._Ubicacion3
                            .c_Ubicacion4.c_Texto = xprddep._Ubicacion4
                            .c_IdSeguridad = xprddep._FichaProductoDeposito._IdSeguridad
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "UPDATE PRODUCTOS_DEPOSITO SET UBICACION_1=@UBICACION_1, UBICACION_2=@UBICACION_2," & _
                                       "UBICACION_3=@UBICACION_3,UBICACION_4=@UBICACION_4, NIVEL_MINIMO=@NIVEL_MINIMO, NIVEL_OPTIMO=@NIVEL_OPTIMO " & _
                                       "WHERE AUTO_PRODUCTO=@AUTO_PRODUCTO AND AUTO_DEPOSITO=@AUTO_DEPOSITO and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.AddWithValue("@auto_producto", xdep._AutoProducto).Size = xdep.c_AutomaticoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xdep._AutoDeposito).Size = xdep.c_AutomaticoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_1", xdep._Ubicacion_1).Size = xdep.c_Ubicacion1.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_2", xdep._Ubicacion_2).Size = xdep.c_Ubicacion2.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_3", xdep._Ubicacion_3).Size = xdep.c_Ubicacion3.c_Largo
                                    xcmd.Parameters.AddWithValue("@ubicacion_4", xdep._Ubicacion_4).Size = xdep.c_Ubicacion4.c_Largo
                                    xcmd.Parameters.AddWithValue("@nivel_minimo", xdep._NivelMinimo)
                                    xcmd.Parameters.AddWithValue("@nivel_optimo", xdep._NivelOptimo)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xdep._IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("DEPOSITO NO ENCONTRADO / FUE ELIMINADO / YA FUE ACTUALIZADO POR OTRO USUARIO")
                                    End If
                                End Using
                                xtr.Commit()

                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 557 Then
                                    Throw New Exception("DEPOSITO NO ENCONTRADO / ELIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MODIFICAR DATOS DEL DEPOSITO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ActualizarPrecios(ByVal xprecios As ActualizarPrecioMayor) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)

                                    'PRODUCTOS_EMPAQUE
                                    Dim xempq As New FichaProducto.Prd_Empaque.c_Registro
                                    Dim xhistorico As New Prd_HistoricoPrecios.c_Registro
                                    Dim xr As Integer = 0

                                    For Each xl As c_AgregarPrecioEmpaque In xprecios._ListaEmpaquesMayor
                                        With xempq
                                            .LimpiarRegistro()

                                            .c_AutomaticoMedida.c_Texto = xl._FichaMedidaEmpaque.c_Automatico.c_Texto
                                            .c_AutomaticoProducto.c_Texto = xprecios._AutoProducto
                                            .c_ContenidoEmpaque.c_Valor = xl._ContenidoEmpaque
                                            .c_Precio_N1.c_Valor = xl._PrecioNuevo_1
                                            .c_Precio_N2.c_Valor = xl._PrecioNuevo_2
                                            .c_Utilidad_1.c_Valor = xl._UtilidadPrecio_1
                                            .c_Utilidad_2.c_Valor = xl._UtilidadPrecio_2
                                            .c_Referencia.c_Texto = xl._PrecioReferencia
                                            .c_IdSeguridad = xl._IdSeguridad
                                        End With

                                        xr = 0
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = ACTUALIZAR_PRECIO_EMPAQUE
                                        xcmd.Parameters.AddWithValue("@auto_producto", xempq.c_AutomaticoProducto.c_Texto).Size = xempq.c_AutomaticoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_1", xempq.c_Precio_N1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_2", xempq.c_Precio_N2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@auto_medida", xempq.c_AutomaticoMedida.c_Texto).Size = xempq.c_AutomaticoMedida.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido", xempq.c_ContenidoEmpaque.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidad_1", xempq.c_Utilidad_1.c_Valor)
                                        xcmd.Parameters.AddWithValue("@utilidad_2", xempq.c_Utilidad_2.c_Valor)
                                        xcmd.Parameters.AddWithValue("@referencia", xempq.c_Referencia.c_Texto).Size = xempq.c_Referencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@id_seguridad", xempq.c_IdSeguridad)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL GRABAR PRECIO DE VENTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                        End If

                                        'PRODUCTOS_HISTORICO_PRECIOS PRECIO #1
                                        'PRODUCTOS_HISTORICO
                                        With xhistorico
                                            .LimpiarRegistro()

                                            .c_AutoProducto.c_Texto = xprecios._AutoProducto
                                            .c_AutoUsuario.c_Texto = xprecios._FichaUsuario._AutoUsuario
                                            .c_Empaque.c_Texto = xl._FichaMedidaEmpaque._NombreMedida
                                            .c_EstacionEquipo.c_Texto = xprecios._EquipoEstacion
                                            .c_FechaMovimiento.c_Valor = xprecios._Fecha
                                            .c_Hora.c_Texto = xprecios._Hora
                                            .c_Nota.c_Texto = "CAMBIO DE PRECIO - PRECIO VENTA #1"
                                            .c_PrecioAnterior.c_Valor = xl._PrecioAnterior_1
                                            .c_PrecioNuevo.c_Valor = xl._PrecioNuevo_1
                                            .c_Usuario.c_Texto = xprecios._FichaUsuario._NombreUsuario
                                            .c_ContenidoEmpaque.c_Valor = xl._ContenidoEmpaque
                                            .c_PrecioReferencia.c_Texto = xl._PrecioReferencia
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.ExecuteNonQuery()


                                        'PRODUCTOS_HISTORICO_PRECIOS PRECIO #2
                                        'PRODUCTOS_HISTORICO
                                        With xhistorico
                                            .LimpiarRegistro()

                                            .c_AutoProducto.c_Texto = xprecios._AutoProducto
                                            .c_AutoUsuario.c_Texto = xprecios._FichaUsuario._AutoUsuario
                                            .c_Empaque.c_Texto = xl._FichaMedidaEmpaque._NombreMedida
                                            .c_EstacionEquipo.c_Texto = xprecios._EquipoEstacion
                                            .c_FechaMovimiento.c_Valor = xprecios._Fecha
                                            .c_Hora.c_Texto = xprecios._Hora
                                            .c_Nota.c_Texto = "CAMBIO DE PRECIO - PRECIO VENTA #2"
                                            .c_PrecioAnterior.c_Valor = xl._PrecioAnterior_2
                                            .c_PrecioNuevo.c_Valor = xl._PrecioNuevo_2
                                            .c_Usuario.c_Texto = xprecios._FichaUsuario._NombreUsuario
                                            .c_ContenidoEmpaque.c_Valor = xl._ContenidoEmpaque
                                            .c_PrecioReferencia.c_Texto = xl._PrecioReferencia
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    If xprecios._TipoPrecioModificar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.Ambos Or _
                                      xprecios._TipoPrecioModificar = FichaGlobal.c_ConfSistema.ConfModuloInventario.AlmacenPrecios.PDetal Then

                                        xr = 0
                                        xcmd.CommandText = ACTUALIZAR_PRECIO_DETAL
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@auto_producto", xprecios._AutoProducto).Size = Me.RegistroDato.c_Automatico.c_Largo
                                            .AddWithValue("@auto_medida_venta", xprecios._VentaDetal._FichaMedidaEmpaqueVenta._Automatico).Size = Me.RegistroDato.c_AutomaticoEmpaqueVentaDetal.c_Largo
                                            .AddWithValue("@contenido_empaque_venta", xprecios._VentaDetal._ContenidoEmpaqueVenta)
                                            .AddWithValue("@precio_pto_venta", xprecios._VentaDetal._PrecioVenta)
                                            .AddWithValue("@utilidad_pto_venta", xprecios._VentaDetal._UtilidadVenta)
                                            .AddWithValue("@psv", xprecios._VentaDetal._PrecioSugerido)
                                            .AddWithValue("@estatus_oferta", IIf(xprecios._VentaDetal._EstatusOferta = TipoEstatus.Activo, "1", "0")).Size = Me.RegistroDato.c_EstatusOferta.c_Largo
                                            .AddWithValue("@inicio", xprecios._VentaDetal._InicioOferta)
                                            .AddWithValue("@fin", xprecios._VentaDetal._FinOferta)
                                            .AddWithValue("@precio_oferta", xprecios._VentaDetal._PrecioOferta)
                                            .AddWithValue("@utilidad_oferta", xprecios._VentaDetal._UtilidadOferta)
                                            .AddWithValue("@fecha_cambio_precio", xprecios._Fecha)
                                            .AddWithValue("@id_seguridad", xprecios._IdSeguridadProducto)
                                        End With
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL GRABAR PRECIO DE VENTA DETAL... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                        End If

                                        'PRODUCTOS_HISTORICO_PRECIOS PRECIO #2
                                        'PRODUCTOS_HISTORICO
                                        With xhistorico
                                            .LimpiarRegistro()

                                            .c_AutoProducto.c_Texto = xprecios._AutoProducto
                                            .c_AutoUsuario.c_Texto = xprecios._FichaUsuario._AutoUsuario
                                            .c_Empaque.c_Texto = xprecios._VentaDetal._FichaMedidaEmpaqueVenta._NombreMedida
                                            .c_EstacionEquipo.c_Texto = xprecios._EquipoEstacion
                                            .c_FechaMovimiento.c_Valor = xprecios._Fecha
                                            .c_Hora.c_Texto = xprecios._Hora
                                            .c_Nota.c_Texto = "CAMBIO DE PRECIO DETAL"
                                            .c_PrecioAnterior.c_Valor = xprecios._VentaDetal._PrecioAnterior
                                            .c_PrecioNuevo.c_Valor = xprecios._VentaDetal._PrecioVenta
                                            .c_Usuario.c_Texto = xprecios._FichaUsuario._NombreUsuario
                                            .c_ContenidoEmpaque.c_Valor = xprecios._VentaDetal._ContenidoEmpaqueVenta
                                            .c_PrecioReferencia.c_Texto = "Detal"
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.ExecuteNonQuery()

                                    Else
                                        'PRODUCTOS
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update productos set fecha_cambio_precio=@fecha_cambio_precio where auto=@auto"
                                        With xcmd.Parameters
                                            .AddWithValue("@fecha_cambio_precio", xprecios._Fecha)
                                            .AddWithValue("@auto", xprecios._AutoProducto).Size = Me.RegistroDato.c_Automatico.c_Largo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarPrecios()
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
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR PRECIOS" + vbCrLf + ex.Message)
                    End Try
                End Function

                Class ActualizarPrecioDetal
                    Private _autoprd As String
                    Private _estacion As String
                    Private _fecha As Date
                    Private _hora As String
                    Private _porcentajeIncrementar As Decimal
                    Private _usuario As FichaGlobal.c_Usuario.c_Registro
                    Private _referencia As String


                    Property Referencia() As String
                        Get
                            Return _referencia
                        End Get
                        Set(ByVal value As String)
                            _referencia = value
                        End Set
                    End Property

                    Property AutoProducto() As String
                        Get
                            Return _autoprd
                        End Get
                        Set(ByVal value As String)
                            _autoprd = value
                        End Set
                    End Property

                    Property EstacionEquipo() As String
                        Get
                            Return _estacion
                        End Get
                        Set(ByVal value As String)
                            _estacion = value
                        End Set
                    End Property

                    ReadOnly Property FechaSistema() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
                        End Get
                    End Property

                    ReadOnly Property Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Property PorcentajeIncrementar() As Decimal
                        Get
                            Return _porcentajeIncrementar
                        End Get
                        Set(ByVal value As Decimal)
                            _porcentajeIncrementar = value
                        End Set
                    End Property

                    Property Usuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return _usuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            _usuario = value
                        End Set
                    End Property

                    Sub New()
                        With Me
                            .Referencia = ""
                            .AutoProducto = ""
                            .EstacionEquipo = ""
                            .PorcentajeIncrementar = 0
                            .Usuario = Nothing
                        End With
                    End Sub
                End Class

                Function F_ActualizarPreciosDetal(ByVal xprd As ActualizarPrecioDetal) As Boolean
                    Try
                        Dim ACTUALIZAR_PRECIO_DETAL_2 As String = "update productos set " & _
                                                                       "precio_pto_venta=@precio_pto_venta," & _
                                                                       "fecha_cambio_precio=@fecha_cambio_precio " & _
                                                                       "where auto=@auto_producto "

                        Dim ACTUALIZAR_PRECIO_EMPAQUE_2 = "update productos_empaque set " & _
                                                                      "precio_1=@precio_1," & _
                                                                      "precio_2=@precio_2 " & _
                                                                      "where auto_producto=@auto_producto and referencia=@referencia"

                        Dim xfichaPrd As New FichaProducto
                        xfichaPrd.f_PrdProducto.F_BuscarProducto(xprd.AutoProducto)

                        Dim xtr As SqlTransaction
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction()
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'PRODUCTOS_EMPAQUE
                                    Dim xempq As New FichaProducto.Prd_Empaque.c_Registro
                                    Dim xhistorico As New Prd_HistoricoPrecios.c_Registro
                                    Dim xr As Integer = 0

                                    If xprd.Referencia <> "" Then

                                        For Each xprecio In xfichaPrd.f_PrdProducto.RegistroDato.tb_Precios.Rows
                                            If xprd.Referencia = xprecio("referencia").ToString.Trim Then
                                                Dim precioActual1 As Decimal = 0
                                                Dim precioNuevo1 As Decimal = 0
                                                Dim precioActual2 As Decimal = 0
                                                Dim precioNuevo2 As Decimal = 0
                                                Dim referencia As String = ""
                                                Dim contenido As Integer = 0

                                                contenido = xprecio("contenido")
                                                referencia = xprecio("referencia").ToString.Trim
                                                precioActual1 = xprecio("precio_1")
                                                precioNuevo1 = Math.Round(precioActual1 + (precioActual1 * xprd.PorcentajeIncrementar / 100), 2, MidpointRounding.AwayFromZero)
                                                precioActual2 = xprecio("precio_2")
                                                precioNuevo2 = Math.Round(precioActual2 + (precioActual2 * xprd.PorcentajeIncrementar / 100), 2, MidpointRounding.AwayFromZero)

                                                xr = 0
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = ACTUALIZAR_PRECIO_EMPAQUE_2
                                                xcmd.Parameters.AddWithValue("@auto_producto", xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto)
                                                xcmd.Parameters.AddWithValue("@referencia", referencia)
                                                xcmd.Parameters.AddWithValue("@precio_1", precioNuevo1)
                                                xcmd.Parameters.AddWithValue("@precio_2", precioNuevo2)
                                                xr = xcmd.ExecuteNonQuery()
                                                If xr = 0 Then
                                                    Throw New Exception("ERROR AL GRABAR PRECIO DE VENTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                                End If

                                                'PRODUCTOS_HISTORICO_PRECIOS PRECIO #1
                                                'PRODUCTOS_HISTORICO
                                                With xhistorico
                                                    .LimpiarRegistro()

                                                    .c_AutoProducto.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto
                                                    .c_AutoUsuario.c_Texto = xprd.Usuario._AutoUsuario
                                                    .c_Empaque.c_Texto = ""
                                                    .c_EstacionEquipo.c_Texto = xprd.EstacionEquipo
                                                    .c_FechaMovimiento.c_Valor = xprd.FechaSistema
                                                    .c_Hora.c_Texto = xprd.Hora
                                                    .c_Nota.c_Texto = "INCREMENTO DEL " + xprd.PorcentajeIncrementar.ToString.Trim + "% "
                                                    .c_PrecioAnterior.c_Valor = precioActual1
                                                    .c_PrecioNuevo.c_Valor = precioNuevo1
                                                    .c_Usuario.c_Texto = xprd.Usuario._NombreUsuario
                                                    .c_ContenidoEmpaque.c_Valor = contenido
                                                    .c_PrecioReferencia.c_Texto = referencia
                                                End With

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                                xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                                xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                                xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                                xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                                xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                                xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                                xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                                xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                                xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                                xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                                xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                                xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                                xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                                xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                                xcmd.ExecuteNonQuery()


                                                'PRODUCTOS_HISTORICO_PRECIOS PRECIO #2
                                                'PRODUCTOS_HISTORICO
                                                With xhistorico
                                                    .LimpiarRegistro()

                                                    .c_AutoProducto.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto
                                                    .c_AutoUsuario.c_Texto = xprd.Usuario._AutoUsuario
                                                    .c_Empaque.c_Texto = ""
                                                    .c_EstacionEquipo.c_Texto = xprd.EstacionEquipo
                                                    .c_FechaMovimiento.c_Valor = xprd.FechaSistema
                                                    .c_Hora.c_Texto = xprd.Hora
                                                    .c_Nota.c_Texto = "INCREMENTO DEL " + xprd.PorcentajeIncrementar.ToString.Trim + "% "
                                                    .c_PrecioAnterior.c_Valor = precioActual2
                                                    .c_PrecioNuevo.c_Valor = precioNuevo2
                                                    .c_Usuario.c_Texto = xprd.Usuario._NombreUsuario
                                                    .c_ContenidoEmpaque.c_Valor = contenido
                                                    .c_PrecioReferencia.c_Texto = referencia
                                                End With

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                                xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                                xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                                xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                                xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                                xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                                xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                                xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                                xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                                xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                                xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                                xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                                xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                                xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                                xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                                xcmd.ExecuteNonQuery()
                                            End If
                                        Next
                                    Else

                                        Dim precioActual As Decimal = xfichaPrd.f_PrdProducto.RegistroDato._PrecioDetal._Base
                                        Dim precioNuevo As Decimal = Math.Round(precioActual + (precioActual * xprd.PorcentajeIncrementar / 100), 2, MidpointRounding.AwayFromZero)

                                        xr = 0
                                        xcmd.CommandText = ACTUALIZAR_PRECIO_DETAL_2
                                        xcmd.Parameters.Clear()
                                        With xcmd.Parameters
                                            .AddWithValue("@auto_producto", xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto).Size = Me.RegistroDato.c_Automatico.c_Largo
                                            .AddWithValue("@precio_pto_venta", precioNuevo)
                                            .AddWithValue("@fecha_cambio_precio", xprd.FechaSistema)
                                        End With
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL GRABAR PRECIO DE VENTA DETAL... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                        End If

                                        'PRODUCTOS_HISTORICO_PRECIOS PRECIO #2
                                        'PRODUCTOS_HISTORICO
                                        With xhistorico
                                            .LimpiarRegistro()

                                            .c_AutoProducto.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto
                                            .c_AutoUsuario.c_Texto = xprd.Usuario._AutoUsuario
                                            .c_Empaque.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._NombreEmpaqueVentaDetal
                                            .c_EstacionEquipo.c_Texto = xprd.EstacionEquipo
                                            .c_FechaMovimiento.c_Valor = xprd.FechaSistema
                                            .c_Hora.c_Texto = xprd.Hora
                                            .c_Nota.c_Texto = "INCREMENTO DEL " + xprd.PorcentajeIncrementar.ToString.Trim + "% "
                                            .c_PrecioAnterior.c_Valor = precioActual
                                            .c_PrecioNuevo.c_Valor = precioNuevo
                                            .c_Usuario.c_Texto = xprd.Usuario._NombreUsuario
                                            .c_ContenidoEmpaque.c_Valor = xfichaPrd.f_PrdProducto.RegistroDato._ContEmpqVentaDetal
                                            .c_PrecioReferencia.c_Texto = "Detal"
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                        xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                        xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                        xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                        xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                        xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                        xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                        xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                        xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                        xcmd.ExecuteNonQuery()


                                        For Each xprecio In xfichaPrd.f_PrdProducto.RegistroDato.tb_Precios.Rows
                                            Dim precioActual1 As Decimal = 0
                                            Dim precioNuevo1 As Decimal = 0
                                            Dim precioActual2 As Decimal = 0
                                            Dim precioNuevo2 As Decimal = 0
                                            Dim referencia As String = ""
                                            Dim contenido As Integer = 0

                                            contenido = xprecio("contenido")
                                            referencia = xprecio("referencia").ToString.Trim
                                            precioActual1 = xprecio("precio_1")
                                            precioNuevo1 = Math.Round(precioActual1 + (precioActual1 * xprd.PorcentajeIncrementar / 100), 2, MidpointRounding.AwayFromZero)
                                            precioActual2 = xprecio("precio_2")
                                            precioNuevo2 = Math.Round(precioActual2 + (precioActual2 * xprd.PorcentajeIncrementar / 100), 2, MidpointRounding.AwayFromZero)

                                            xr = 0
                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = ACTUALIZAR_PRECIO_EMPAQUE_2
                                            xcmd.Parameters.AddWithValue("@auto_producto", xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto)
                                            xcmd.Parameters.AddWithValue("@referencia", referencia)
                                            xcmd.Parameters.AddWithValue("@precio_1", precioNuevo1)
                                            xcmd.Parameters.AddWithValue("@precio_2", precioNuevo2)
                                            xr = xcmd.ExecuteNonQuery()
                                            If xr = 0 Then
                                                Throw New Exception("ERROR AL GRABAR PRECIO DE VENTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                            End If

                                            'PRODUCTOS_HISTORICO_PRECIOS PRECIO #1
                                            'PRODUCTOS_HISTORICO
                                            With xhistorico
                                                .LimpiarRegistro()

                                                .c_AutoProducto.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto
                                                .c_AutoUsuario.c_Texto = xprd.Usuario._AutoUsuario
                                                .c_Empaque.c_Texto = ""
                                                .c_EstacionEquipo.c_Texto = xprd.EstacionEquipo
                                                .c_FechaMovimiento.c_Valor = xprd.FechaSistema
                                                .c_Hora.c_Texto = xprd.Hora
                                                .c_Nota.c_Texto = "INCREMENTO DEL " + xprd.PorcentajeIncrementar.ToString.Trim + "% "
                                                .c_PrecioAnterior.c_Valor = precioActual1
                                                .c_PrecioNuevo.c_Valor = precioNuevo1
                                                .c_Usuario.c_Texto = xprd.Usuario._NombreUsuario
                                                .c_ContenidoEmpaque.c_Valor = contenido
                                                .c_PrecioReferencia.c_Texto = referencia
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                            xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                            xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                            xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                            xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                            xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                            xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                            xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                            xcmd.ExecuteNonQuery()


                                            'PRODUCTOS_HISTORICO_PRECIOS PRECIO #2
                                            'PRODUCTOS_HISTORICO
                                            With xhistorico
                                                .LimpiarRegistro()

                                                .c_AutoProducto.c_Texto = xfichaPrd.f_PrdProducto.RegistroDato._AutoProducto
                                                .c_AutoUsuario.c_Texto = xprd.Usuario._AutoUsuario
                                                .c_Empaque.c_Texto = ""
                                                .c_EstacionEquipo.c_Texto = xprd.EstacionEquipo
                                                .c_FechaMovimiento.c_Valor = xprd.FechaSistema
                                                .c_Hora.c_Texto = xprd.Hora
                                                .c_Nota.c_Texto = "INCREMENTO DEL " + xprd.PorcentajeIncrementar.ToString.Trim + "% "
                                                .c_PrecioAnterior.c_Valor = precioActual2
                                                .c_PrecioNuevo.c_Valor = precioNuevo2
                                                .c_Usuario.c_Texto = xprd.Usuario._NombreUsuario
                                                .c_ContenidoEmpaque.c_Valor = contenido
                                                .c_PrecioReferencia.c_Texto = referencia
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "update contadores set a_productos_historico=a_productos_historico+1;select a_productos_historico from contadores"
                                            xhistorico.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = INSERT_PRODUCTOS_HISTORICO_PRECIOS
                                            xcmd.Parameters.AddWithValue("@auto", xhistorico.c_Automatico.c_Texto).Size = xhistorico.c_Automatico.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_producto", xhistorico.c_AutoProducto.c_Texto).Size = xhistorico.c_AutoProducto.c_Largo
                                            xcmd.Parameters.AddWithValue("@fecha", xhistorico.c_FechaMovimiento.c_Valor)
                                            xcmd.Parameters.AddWithValue("@estacion", xhistorico.c_EstacionEquipo.c_Texto).Size = xhistorico.c_EstacionEquipo.c_Largo
                                            xcmd.Parameters.AddWithValue("@auto_usuario", xhistorico.c_AutoUsuario.c_Texto).Size = xhistorico.c_AutoUsuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@precio_id", xhistorico.c_PrecioReferencia.c_Texto).Size = xhistorico.c_PrecioReferencia.c_Largo
                                            xcmd.Parameters.AddWithValue("@precio_anterior", xhistorico.c_PrecioAnterior.c_Valor)
                                            xcmd.Parameters.AddWithValue("@precio_nuevo", xhistorico.c_PrecioNuevo.c_Valor)
                                            xcmd.Parameters.AddWithValue("@empaque", xhistorico.c_Empaque.c_Texto).Size = xhistorico.c_Empaque.c_Largo
                                            xcmd.Parameters.AddWithValue("@nota", xhistorico.c_Nota.c_Texto).Size = xhistorico.c_Nota.c_Largo
                                            xcmd.Parameters.AddWithValue("@usuario", xhistorico.c_Usuario.c_Texto).Size = xhistorico.c_Usuario.c_Largo
                                            xcmd.Parameters.AddWithValue("@hora", xhistorico.c_Hora.c_Texto).Size = xhistorico.c_Hora.c_Largo
                                            xcmd.Parameters.AddWithValue("@contenido_empaque", xhistorico.c_ContenidoEmpaque.c_Valor)
                                            xcmd.ExecuteNonQuery()
                                        Next
                                    End If

                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarPrecios()
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
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR PRECIOS" + vbCrLf + ex.Message)
                    End Try
                End Function


                Function F_ActualizarActivarOferta(ByVal xprecios As c_ProductoOferta) As Boolean
                    Try
                        Dim xr As Integer = 0
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)

                                    xr = 0
                                    xcmd.CommandText = ACTUALIZAR_PRECIO_OFERTA
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto_producto", xprecios._AutoProducto).Size = Me.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@estatus_oferta", "1").Size = Me.RegistroDato.c_EstatusOferta.c_Largo
                                        .AddWithValue("@inicio", xprecios._InicioOferta)
                                        .AddWithValue("@fin", xprecios._FinOferta)
                                        .AddWithValue("@precio_oferta", xprecios._PrecioOferta)
                                        .AddWithValue("@utilidad_oferta", xprecios._UtilidadOferta)
                                        .AddWithValue("@fecha_cambio_precio", xprecios._Fecha)
                                        .AddWithValue("@id_seguridad", xprecios._IdSeguridadProducto)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL GRABAR PRECIO PROMOCION / OEFERTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                    End If

                                End Using
                                RaiseEvent _ActualizarPrecios()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message + "," + ex2.Number)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "ACTUALIZAR / ACTIVAT OFERTA PROMOCION" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_DesactivarOfertaProducto(ByVal xauto As String, ByVal xid As Byte()) As Boolean
                    Try
                        Dim xr As Integer = 0
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)

                                    xr = 0
                                    xcmd.CommandText = "update productos set estatus_oferta='0' where auto=@auto and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.Clear()
                                    With xcmd.Parameters
                                        .AddWithValue("@auto", xauto).Size = Me.RegistroDato.c_Automatico.c_Largo
                                        .AddWithValue("@id_seguridad", xid)
                                    End With
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR AL DESACTIVAR PROMOCION / OEFERTA... PRECIO HA SIDO ACTUALIZADO POR OTRO USUARIO / PRODUCTO FUE ELIMINADO")
                                    End If

                                End Using
                                RaiseEvent _ActualizarPrecios()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message + "," + ex2.Number)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS" + vbCrLf + "DESACTIVAR OFERTA / PROMOCION" + vbCrLf + ex.Message)
                    End Try
                End Function


                ''' <summary>
                ''' FUNCION POS
                ''' BUSCAR Y CARGAR FICHA DEL PRODUCTO 
                ''' BUSQUEDA POR CODIGO DE BARRA
                ''' </summary>
                Function FPos_BuscarCodigoBarra(ByVal xcodigo As String) As FichaProducto.Prd_Producto.c_Registro
                    Try
                        Dim xauto As Object = Nothing
                        Dim xtb As New DataTable
                        Dim xrd As SqlDataReader

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto_producto from productos_alterno with (readpast) where codigo=@codigo"
                                xcmd.Parameters.AddWithValue("@codigo", xcodigo)
                                xauto = xcmd.ExecuteScalar()

                                If xauto IsNot Nothing Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from productos with (readpast) where auto=@xauto"
                                    xcmd.Parameters.AddWithValue("@xauto", xauto.ToString)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)
                                Else
                                    Return Nothing
                                End If
                            End Using
                        End Using

                        If xtb.Rows.Count > 0 Then
                            Dim xprd As New FichaProducto.Prd_Producto.c_Registro
                            xprd.CargarRegistro(xtb(0))
                            Return xprd
                        Else
                            Return Nothing
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                        Return Nothing
                    End Try
                End Function


                ''' <summary>
                ''' FUNCION POS
                ''' BUSCAR Y CARGAR FICHA DEL PRODUCTO 
                ''' BUSQUEDA POR PLU 
                ''' </summary>
                Function FPos_BuscarPLU(ByVal xplu As String) As FichaProducto.Prd_Producto.c_Registro
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "SELECT * from productos with (readpast) where convert(int,plu)=convert(int,@plu)"
                            xadap.SelectCommand.Parameters.AddWithValue("@plu", xplu)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Dim xprd As New FichaProducto.Prd_Producto.c_Registro
                            xprd.CargarRegistro(xtb(0))
                            Return xprd
                        Else
                            Return Nothing
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                        Return Nothing
                    End Try
                End Function

                ''' <summary>
                ''' FUNCION POS
                ''' BUSCAR Y CARGAR FICHA DEL PRODUCTO 
                ''' BUSQUEDA POR AUTO PRODUCTO
                ''' </summary>
                Function FPos_BuscarAuto(ByVal xauto As String) As FichaProducto.Prd_Producto.c_Registro
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "SELECT * from productos with (readpast) where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Dim xprd As New FichaProducto.Prd_Producto.c_Registro
                            xprd.CargarRegistro(xtb(0))
                            Return xprd
                        Else
                            Return Nothing
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                        Return Nothing
                    End Try
                End Function

            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_DEPARTAMENTO
            ''' </summary>
            Class Prd_Departamento
                Event Actualizar()

                Class c_ModificarDepart
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_DepartModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreDepart() As String
                        Set(ByVal value As String)
                            xreg.c_NombreDepart.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoDepart() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_NombreDepart() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Return Me.c_NombreDepart.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_NombreDepart = New CampoTexto(40, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreDepart.c_Texto = xrow(.c_NombreDepart.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS: DEPARTAMENTO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Private Const InsertDepart_1 As String = _
                    "update contadores set a_productos_depto=a_productos_depto+1;select a_productos_depto from contadores"
                Private Const InsertDepart_2 As String = _
                    "Insert into PRODUCTOS_DEPARTAMENTO (auto,nombre) values (@auto,@nombre)"
                Private Const UpdateDepart_1 As String = _
                    "Update PRODUCTOS_DEPARTAMENTO set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const DeleteDepart_1 As String = _
                    "Delete PRODUCTOS_DEPARTAMENTO where auto=@auto"

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_departamento where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("DEPARTAMENTO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPARTAMENTO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = DeleteDepart_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR DEPARTAMENTO, EXISTEN PRODUCTOS DENTRO DE ESTE DEPARTAMENTO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPARTAMENTO: " + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaDepartamento(ByVal xgrupomod As c_ModificarDepart) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(UpdateDepart_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_DepartModificar.c_Automatico.c_Texto)
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_DepartModificar.c_NombreDepart.c_Texto)
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_DepartModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR DEPARTAMENTO, DEPARTAMENTO HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR DEPARTAMENTO, EXISTE UN DEPARTAMENTO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPARTAMENTO" + vbCrLf + "MODIFICAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xnombre As String) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Dim xauto As String = ""
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = InsertDepart_1
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = InsertDepart_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@nombre", xnombre)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR DEPARTAMENTO, EXISTE UN DEPARTAMENTO CON EL MISMO NOMBRE")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR DEPARTAMENTO, AUTOMATICO DEL DEPARTAMENTO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPARTAMENTO " + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_GRUPO
            ''' </summary>
            Class Prd_Grupo
                Event _ActualizarFicha()

                Class c_ModificarGrupo
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_GrupoModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreGrupo() As String
                        Set(ByVal value As String)
                            xreg.c_NombreGrupo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_NombreGrupo() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
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
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Return Me.c_NombreGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_NombreGrupo = New CampoTexto(60, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            Me.c_Automatico.c_Texto = xrow(Me.c_Automatico.c_NombreInterno)
                            Me.c_NombreGrupo.c_Texto = xrow(Me.c_NombreGrupo.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                Me.c_IdSeguridad = xrow("id_seguridad")
                            End If
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    xregistro = New c_Registro
                End Sub

                Private Const Insert_1 As String = _
                    "update contadores set a_productos_grupo=a_productos_grupo+1;select a_productos_grupo from contadores"
                Private Const Insert_2 As String = _
                    "Insert into PRODUCTOS_GRUPO (auto,nombre) values (@auto,@nombre)"
                Private Const Insert_3 As String = _
                    "update contadores set a_productos_subgrupo=a_productos_subgrupo+1;select a_productos_subgrupo from contadores"
                Private Const Insert_4 As String = _
                    "Insert into PRODUCTOS_SUBGRUPO (auto,nombre,auto_grupo) values (@auto,@nombre,@auto_grupo)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_GRUPO set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_GRUPO where auto=@auto"

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_grupo where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("GRUPO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR GRUPO, EXISTEN PRODUCTOS DENTRO DE ESTE GRUPO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaRegistro(ByVal xgrupomod As c_ModificarGrupo) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_GrupoModificar.c_Automatico.c_Texto).Size = xgrupomod.c_GrupoModificar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_GrupoModificar.c_NombreGrupo.c_Texto).Size = xgrupomod.c_GrupoModificar.c_NombreGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_GrupoModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR GRUPO, GRUPO YA HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent _ActualizarFicha()
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
                        Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "MODIFICAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xnombre As String) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Dim xgrupo As New FichaProducto.Prd_Grupo.c_Registro
                    Dim xsubgrupo As New FichaProducto.Prd_SubGrupo.c_Registro
                    Try

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    xgrupo.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_2
                                    xgrupo.c_NombreGrupo.c_Texto = xnombre
                                    xcmd.Parameters.AddWithValue("@auto", xgrupo.c_Automatico.c_Texto).Size = xgrupo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xgrupo.c_NombreGrupo.c_Texto).Size = xgrupo.c_NombreGrupo.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_3
                                    xsubgrupo.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    With xsubgrupo
                                        .c_AutoGrupo.c_Texto = xgrupo.c_Automatico.c_Texto
                                        .c_SubGrupo.c_Texto = "GENERAL"
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_4
                                    xcmd.Parameters.AddWithValue("@auto", xsubgrupo.c_Automatico.c_Texto).Size = xsubgrupo.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xsubgrupo.c_SubGrupo.c_Texto).Size = xsubgrupo.c_SubGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xsubgrupo.c_AutoGrupo.c_Texto).Size = xsubgrupo.c_AutoGrupo.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR GRUPO, EXISTE UN GRUPO CON EL MISMO NOMBRE")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR GRUPO, AUTOMATICO DEL GRUPO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_MARCA
            ''' </summary>
            Class Prd_Marca
                Event Actualizar()

                Class c_ModificarMarca
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_Modificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreMarca() As String
                        Set(ByVal value As String)
                            xreg.c_NombreMarca.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoMarca() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_NombreMarca() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Return Me.c_NombreMarca.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_NombreMarca = New CampoTexto(40, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreMarca.c_Texto = xrow(.c_NombreMarca.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS: MARCAS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Private Const Insert_1 As String = _
                    "update contadores set a_marca=a_marca+1;select a_marca from contadores"
                Private Const Insert_2 As String = _
                    "Insert into PRODUCTOS_MARCA (auto,nombre) values (@auto,@nombre)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_MARCA set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_MARCA where auto=@auto"

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_marca where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("MARCA NO ENCONTRADA... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MARCA" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR MARCA, EXISTEN PRODUCTOS DENTRO DE ESTA MARCA")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MARCA" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaDepartamento(ByVal xgrupomod As c_ModificarMarca) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_Modificar.c_Automatico.c_Texto)
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_Modificar.c_NombreMarca.c_Texto)
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_Modificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR MARCA, MARCA HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR MARCA, EXISTE UNA MARCA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MARCA" + vbCrLf + "MODIFICAR MARCA" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xnombre As String) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Dim xauto As String = ""
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@nombre", xnombre)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR MARCA, EXISTE UNA MARCA CON EL MISMO NOMBRE")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR MARCA, AUTOMATICO DE LA MARCA YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MARCA" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_CONCEPTOS
            ''' </summary>
            Class Prd_Concepto
                Event Actualizar()

                Class c_AgregarConcepto
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_ConceptoRegistrar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreConcepto() As String
                        Set(ByVal value As String)
                            xreg.c_NombreConcepto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoConcepto() As String
                        Set(ByVal value As String)
                            xreg.c_CodigoConcepto.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_ModificarConcepto
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_ConceptoModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreConcepto() As String
                        Set(ByVal value As String)
                            xreg.c_NombreConcepto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoConcepto() As String
                        Set(ByVal value As String)
                            xreg.c_CodigoConcepto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoConcepto() As String
                        Set(ByVal value As String)
                            xreg.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xreg.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NombreConcepto() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreConcepto() As String
                        Get
                            Return Me.c_NombreConcepto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CodigoConcepto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoConcepto() As String
                        Get
                            Return Me.c_CodigoConcepto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_CodigoConcepto = New CampoTexto(10, "codigo")
                        c_NombreConcepto = New CampoTexto(50, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")

                        M_LimpiarRegistro()
                    End Sub

                    Sub CargarData(ByVal xrow As DataRow)
                        Try
                            M_LimpiarRegistro()

                            Me.c_Automatico.c_Texto = xrow(Me.c_Automatico.c_NombreInterno)
                            Me.c_NombreConcepto.c_Texto = xrow(Me.c_NombreConcepto.c_NombreInterno)
                            Me.c_CodigoConcepto.c_Texto = xrow(Me.c_CodigoConcepto.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                Me.c_IdSeguridad = xrow("id_seguridad")
                            End If
                        Catch ex As Exception
                            Throw New Exception("DEPOSITOS: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    xregistro = New c_Registro
                End Sub

                Private Const Insert_1 As String = _
                    "update contadores set a_conceptos=a_conceptos+1;select a_conceptos from contadores"
                Private Const Insert_2 As String = _
                    "Insert into PRODUCTOS_CONCEPTOS (auto,nombre,codigo) values (@auto,@nombre,@codigo)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_CONCEPTOS set nombre=@nombre, codigo=@codigo where auto=@auto and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_CONCEPTOS where auto=@auto"

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR CONCEPTO, EXISTEN MOVIMIENTOS DENTRO DE ESTE CONCEPTO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: CONCEPTO" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaRegistro(ByVal xgrupomod As c_ModificarConcepto) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_ConceptoModificar.c_Automatico.c_Texto).Size = xgrupomod.c_ConceptoModificar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_ConceptoModificar.c_NombreConcepto.c_Texto).Size = xgrupomod.c_ConceptoModificar.c_NombreConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@CODIGO", xgrupomod.c_ConceptoModificar.c_CodigoConcepto.c_Texto).Size = xgrupomod.c_ConceptoModificar.c_CodigoConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_ConceptoModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR CONCEPTO, CONCEPTO SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR CONCEPTO, EXISTE UN CONCEPTO CON EL MISMO NOMBRE/CODIGO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: CONCEPTO" + vbCrLf + "MODIFICAR CONCEPTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal depagregar As c_AgregarConcepto) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    depagregar.c_ConceptoRegistrar.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", depagregar.c_ConceptoRegistrar.c_Automatico.c_Texto).Size = depagregar.c_ConceptoRegistrar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", depagregar.c_ConceptoRegistrar.c_NombreConcepto.c_Texto).Size = depagregar.c_ConceptoRegistrar.c_NombreConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", depagregar.c_ConceptoRegistrar.c_CodigoConcepto.c_Texto).Size = depagregar.c_ConceptoRegistrar.c_CodigoConcepto.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR CONCEPTO, EXISTE UN CONCEPTO CON EL MISMO NOMBRE/CODIGO")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR CONCEPTO, AUTOMATICO DEL CONCEPTO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: CONCEPTO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarConcepto(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_concepto where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count >= 1 Then
                            M_Cargardata(xtb.Rows(0))
                        Else
                            Throw New Exception("PRODUCTOS: CONCEPTO" + vbCrLf + "BUSCAR CONCEPTO" + vbCrLf + "CONCEPTO NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: CONCEPTO" + vbCrLf + "BUSCAR CONCEPTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub M_Cargardata(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarData(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_SUBGRUPO
            ''' </summary>
            Class Prd_SubGrupo
                Event _ActualizarFicha()

                Class c_AgregarSubGrupo
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_Agregar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            c_Agregar.c_AutoGrupo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _SubGrupo() As String
                        Set(ByVal value As String)
                            c_Agregar.c_SubGrupo.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_ModificarSubGrupo
                    Inherits c_AgregarSubGrupo

                    Sub New()
                        MyBase.New()
                    End Sub

                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            c_Agregar.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            c_Agregar.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_grupo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_SubGrupo() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoGrupo() As CampoTexto
                        Get
                            Return f_auto_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_grupo = value
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
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_AutoGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _SubGrupo() As String
                        Get
                            Return Me.c_SubGrupo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_AutoGrupo = New CampoTexto(10, "auto_grupo")
                        c_SubGrupo = New CampoTexto(60, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            Me.c_Automatico.c_Texto = xrow(Me.c_Automatico.c_NombreInterno)
                            Me.c_SubGrupo.c_Texto = xrow(Me.c_SubGrupo.c_NombreInterno)
                            Me.c_AutoGrupo.c_Texto = xrow(Me.c_AutoGrupo.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                Me.c_IdSeguridad = xrow("id_seguridad")
                            End If
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS: SUBGRUPO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    xregistro = New c_Registro
                End Sub

                Private Const Insert_1 As String = _
                    "update contadores set a_productos_subgrupo=a_productos_subgrupo+1;select a_productos_subgrupo from contadores"
                Private Const Insert_2 As String = _
                    "Insert into PRODUCTOS_SUBGRUPO (auto,nombre,auto_grupo) values (@auto,@nombre,@auto_grupo)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_SUBGRUPO set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_SUBGRUPO where auto=@auto"

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_subgrupo where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("SUBGRUPO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: SUBGRUPO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR GRUPO, EXISTEN PRODUCTOS DENTRO DE ESTE GRUPO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: GRUPO" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaRegistro(ByVal xgrupomod As c_ModificarSubGrupo) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_Agregar.c_Automatico.c_Texto).Size = xgrupomod.c_Agregar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_Agregar.c_SubGrupo.c_Texto).Size = xgrupomod.c_Agregar.c_SubGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_Agregar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR SUBGRUPO, SUBGRUPO YA HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR SUBGRUPO, EXISTE UN SUBGRUPO CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: SUBGRUPO" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xsubg As c_AgregarSubGrupo) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Dim xauto As String = ""
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    xsubg.c_Agregar.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", xsubg.c_Agregar.c_Automatico.c_Texto).Size = xsubg.c_Agregar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xsubg.c_Agregar.c_SubGrupo.c_Texto).Size = xsubg.c_Agregar.c_SubGrupo.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_grupo", xsubg.c_Agregar.c_AutoGrupo.c_Texto).Size = xsubg.c_Agregar.c_AutoGrupo.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR SUBGRUPO, EXISTE UN SUBGRUPO CON EL MISMO NOMBRE")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR SUBGRUPO, AUTOMATICO DEL SUBGRUPO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: SUBGRUPO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_ALETRNO
            ''' </summary>
            Class Prd_Alterno
                Event Actualizar()

                ''' <summary>
                ''' Clase PARA AGREGAR CODIGO ALTERNO
                ''' </summary>
                Class c_AgregarCodigoAlterno
                    Private xcodigo As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As c_Registro)
                            xcodigo = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoAlterno() As String
                        Set(ByVal value As String)
                            xcodigo.c_Codigo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Detalle() As String
                        Set(ByVal value As String)
                            xcodigo.c_Detalle.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            xcodigo.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Estatus() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xcodigo.c_Estatus.c_Texto = "0"
                            Else
                                xcodigo.c_Estatus.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    Sub New()
                        xcodigo = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase PARA MODIFICAR CODIGO ALTERNO
                ''' </summary>
                Class c_ModificarCodigoAlterno
                    Private xcodigo As c_Registro

                    Protected Friend Property d_Registro() As c_Registro
                        Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As c_Registro)
                            xcodigo = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoAlterno() As String
                        Set(ByVal value As String)
                            xcodigo.c_Codigo.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Detalle() As String
                        Set(ByVal value As String)
                            xcodigo.c_Detalle.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xcodigo.c_IdSeguridad = value
                        End Set
                    End Property

                    Sub New()
                        xcodigo = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' CLASE REGISTRO DE LA TABLA
                ''' </summary>
                Class c_Registro
                    Private f_auto_producto As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_detalle As CampoTexto
                    Private f_estatus_alterno As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo Automatico Del Producto Al Cual Hace Referencia
                    ''' </summary>
                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutomaticoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Codigo De Barra
                    ''' </summary>
                    Property c_Codigo() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoBarraAlterno() As String
                        Get
                            Return Me.c_Codigo.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Detalle Del Codigo De Barra
                    ''' </summary>
                    Property c_Detalle() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    ReadOnly Property _DetalleDelCodigo() As String
                        Get
                            Return Me.c_Detalle.c_Texto
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo, Estatus Del Codigo Alterno
                    ''' </summary>
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus_alterno
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_alterno = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.ToString.Trim.ToUpper = "0" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_AutoProducto = New CampoTexto(10, "auto_producto")
                        c_Codigo = New CampoTexto(15, "codigo")
                        c_Detalle = New CampoTexto(20, "detalle")
                        c_Estatus = New CampoTexto(1, "estatus_alterno")

                        M_LimpiarRegistro()
                    End Sub

                    Sub CargarData(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_LimpiarRegistro()

                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_Codigo.c_Texto = xrow(.c_Codigo.c_NombreInterno)
                                .c_Detalle.c_Texto = xrow(.c_Detalle.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_IdSeguridad = xrow("ID_SEGURIDAD")
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS_ALTERNO: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Private Const Insert_1 As String = _
                    "Insert into PRODUCTOS_ALTERNO (auto_producto,codigo,detalle,estatus_alterno) values (@auto_producto,@codigo,@detalle,@estatus_alterno)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_ALTERNO set detalle=@detalle where codigo=@codigo and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_ALTERNO where codigo=@codigo"

                ''' <summary>
                ''' Funcion: Permite Cargar Los Cod Alternos De Un Producto Dado en una Tabla dada
                ''' </summary>
                Function F_CargarCodigosAlternos(ByVal xauto As String, ByRef xtb As DataTable, Optional ByVal xsql As String = "select codigo as xcod, detalle as xdet , * from productos_alterno where auto_producto=@auto_producto") As Boolean
                    Try
                        xtb.Rows.Clear()
                        Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_producto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        Return True
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS_ALTERNO: " + vbCrLf + "CARGAR CODIGOS ALTERNOS:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xcodigo As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@codigo", xcodigo)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR CODIGO ALTERNO NO ENCONTRADO / YA FUE ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex As Exception
                                RaiseEvent Actualizar()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS_ALTERNO: " + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ActualizarRegistro(ByVal xmodificar As c_ModificarCodigoAlterno) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Update_1
                                    xcmd.Parameters.AddWithValue("@detalle", xmodificar.d_Registro.c_Detalle.c_Texto).Size = xmodificar.d_Registro.c_Detalle.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xmodificar.d_Registro.c_Codigo.c_Texto).Size = xmodificar.d_Registro.c_Codigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xmodificar.d_Registro.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR CODIGO ALTERNO NO ENCONTRADO / YA FUE ELIMINADO POR OTRO USUARIO / YA FUE MODIFICADO POR OTRO USUARIO")
                                    End If
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex As Exception
                                RaiseEvent Actualizar()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS_ALTERNO: " + vbCrLf + "ACTUALIZAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xcodigo As c_AgregarCodigoAlterno) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xobj As Object = Nothing

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xcodigo.d_Registro.c_AutoProducto.c_Texto).Size = xcodigo.d_Registro.c_AutoProducto.c_Largo
                                    xcmd.CommandText = "select estatus from productos where auto=@auto"
                                    xobj = xcmd.ExecuteScalar()
                                    If IsDBNull(xobj) Or IsNothing(xobj) Then
                                        Throw New Exception("PRODUCTO NO ENCONTRADO, VERIFIQUE POR FAVOR")
                                    Else
                                        If xobj.ToString.Trim.ToUpper = "ACTIVO" Then
                                            xcodigo.d_Registro.c_Estatus.c_Texto = "0"
                                        Else
                                            xcodigo.d_Registro.c_Estatus.c_Texto = "1"
                                        End If
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_1
                                    xcmd.Parameters.AddWithValue("@auto_producto", xcodigo.d_Registro.c_AutoProducto.c_Texto).Size = xcodigo.d_Registro.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xcodigo.d_Registro.c_Codigo.c_Texto).Size = xcodigo.d_Registro.c_Codigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@detalle", xcodigo.d_Registro.c_Detalle.c_Texto).Size = xcodigo.d_Registro.c_Detalle.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus_alterno", xcodigo.d_Registro.c_Estatus.c_Texto).Size = xcodigo.d_Registro.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 2627 Then
                                    Throw New Exception("ERROR AL INTENTAR REGISTRAR CODIGO ALTERNO, CODIGO YA REGISTRADO, VERIFIQUE POR FAVOR")
                                ElseIf ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL INTENTAR REGISTRAR CODIGO ALTERNO, PRODUCTO FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE POR FAVOR")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS_ALTERNO: " + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                        RaiseEvent Actualizar()
                    End Try
                End Function

                Sub M_Cargardata(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarData(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_PROVEEDOR
            ''' </summary>
            Class Prd_Proveedor
                Event Actualizar()

                Class c_AgregarEliminarCodigoProveedor
                    Private xregistro As FichaProducto.Prd_Proveedor.c_Registro

                    Protected Friend Property _RegsitroDato() As FichaProducto.Prd_Proveedor.c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Proveedor.c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        _RegsitroDato = New FichaProducto.Prd_Proveedor.c_Registro
                    End Sub

                    WriteOnly Property _AutoProducto() As String
                        Set(ByVal value As String)
                            Me._RegsitroDato.c_AutoProducto.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoProveedor() As String
                        Set(ByVal value As String)
                            Me._RegsitroDato.c_AutoProveedor.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoAsignar() As String
                        Set(ByVal value As String)
                            Me._RegsitroDato.c_Codigo.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto_producto As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_auto_proveedor As CampoTexto

                    ''' <summary>
                    ''' Campo Automatico Del Producto Al Cual Hace Referencia
                    ''' </summary>
                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Codigo Asigando Al Producto Para Este Proveedor
                    ''' </summary>
                    Property c_Codigo() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del Proveedor 
                    ''' </summary>
                    Protected Friend Property c_AutoProveedor() As CampoTexto
                        Get
                            Return f_auto_proveedor
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_proveedor = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoProveedor() As String
                        Get
                            Return Me.c_AutoProveedor.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoAsignado() As String
                        Get
                            Return Me.c_Codigo.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_AutoProducto = New CampoTexto(10, "auto_producto")
                        c_AutoProveedor = New CampoTexto(10, "auto_proveedor")
                        c_Codigo = New CampoTexto(15, "codigo")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarData(ByVal xrow As DataRow)
                        Try
                            With Me
                                .LimpiarRegistro()

                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_AutoProveedor.c_Texto = xrow(.c_AutoProveedor.c_NombreInterno)
                                .c_Codigo.c_Texto = xrow(.c_Codigo.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS PROVEEDOR: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Protected Friend Const Insert_1 As String = _
                    "Insert into PRODUCTOS_PROVEEDOR (auto_producto,codigo,auto_proveedor) values (@auto_producto,@codigo,@auto_proveedor)"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_PROVEEDOR where auto_producto=@auto_producto and auto_proveedor=@auto_proveedor and codigo=@codigo"

                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xeliminar As c_AgregarEliminarCodigoProveedor) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto_producto", xeliminar._RegsitroDato.c_AutoProducto.c_Texto).Size = xeliminar._RegsitroDato.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_proveedor", xeliminar._RegsitroDato.c_AutoProveedor.c_Texto).Size = xeliminar._RegsitroDato.c_AutoProveedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xeliminar._RegsitroDato.c_Codigo.c_Texto).Size = xeliminar._RegsitroDato.c_Codigo.c_Largo
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("ERROR... CODIGO YA FUE ELIMINADO POR OTRO USUARIO")
                                    End If
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("CODIGO YA REGISTRADO PARA ESTE PROVEEDOR")
                                ElseIf ex2.Number = 547 Then
                                    Throw New Exception("ERROR ... PRODUCTO / PROVEEDOR FUE ELIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS_PROVEEDOR: " + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal xagregar As c_AgregarEliminarCodigoProveedor) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Insert_1
                                    xcmd.Parameters.AddWithValue("@auto_producto", xagregar._RegsitroDato.c_AutoProducto.c_Texto).Size = xagregar._RegsitroDato.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_proveedor", xagregar._RegsitroDato.c_AutoProveedor.c_Texto).Size = xagregar._RegsitroDato.c_AutoProveedor.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xagregar._RegsitroDato.c_Codigo.c_Texto).Size = xagregar._RegsitroDato.c_Codigo.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("CODIGO YA REGISTRADO PARA ESTE PROVEEDOR")
                                ElseIf ex2.Number = 547 Then
                                    Throw New Exception("ERROR ... PRODUCTO / PROVEEDOR FUE ELIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS PROVEEDOR: " + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub M_Cargardata(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarData(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_MEDIDA
            ''' </summary>
            Class Prd_Medida
                Event Actualizar()

                Class c_AgregarMedida
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_MedidaRegistrar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreEmpaque() As String
                        Set(ByVal value As String)
                            xreg.c_Nombre.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NumeroDecimales() As Integer
                        Set(ByVal value As Integer)
                            xreg.c_Decimales.c_Texto = value.ToString.Trim
                        End Set
                    End Property
                    WriteOnly Property _ForzarEmpaque() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                xreg.c_ForzarDecimales.c_Texto = "1"
                            Else
                                xreg.c_ForzarDecimales.c_Texto = "0"
                            End If
                        End Set
                    End Property
                End Class

                Class c_ModificarMedida
                    Inherits c_AgregarMedida

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            MyBase.c_MedidaRegistrar.c_IdSeguridad = value
                        End Set
                    End Property
                    WriteOnly Property _AutoEmpaque() As String
                        Set(ByVal value As String)
                            MyBase.c_MedidaRegistrar.c_Automatico.c_Texto = value
                        End Set
                    End Property

                    Sub New()
                        MyBase.New()
                    End Sub
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_decimales As CampoTexto
                    Private f_forzar_decimales As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Nombre() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreMedida() As String
                        Get
                            Return Me.c_Nombre.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Decimales() As CampoTexto
                        Get
                            Return f_decimales
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_decimales = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Cantidad De Decimales A Usar
                    ''' </summary>
                    ReadOnly Property _DigitosDecimalesAUsar() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.f_decimales.c_Texto, x)
                            Return x
                        End Get
                    End Property

                    Protected Friend Property c_ForzarDecimales() As CampoTexto
                        Get
                            Return f_forzar_decimales
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_forzar_decimales = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Forzar/No El Uso De Cantidades Exactas
                    ''' </summary>
                    ReadOnly Property _ForzarDecimales() As TipoEstatus
                        Get
                            If Me.f_forzar_decimales.c_Texto = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Automatico = New CampoTexto(10, "auto")
                        c_Nombre = New CampoTexto(20, "nombre")
                        c_Decimales = New CampoTexto(1, "decimales")
                        c_ForzarDecimales = New CampoTexto(1, "forzar_decimales")

                        M_LimpiarRegistro()
                    End Sub

                    Sub CargarData(ByVal xrow As DataRow)
                        Try
                            M_LimpiarRegistro()

                            Me.c_Automatico.c_Texto = xrow(Me.c_Automatico.c_NombreInterno)
                            Me.c_Nombre.c_Texto = xrow(Me.c_Nombre.c_NombreInterno)
                            Me.c_Decimales.c_Texto = xrow(Me.c_Decimales.c_NombreInterno)
                            Me.c_ForzarDecimales.c_Texto = xrow(Me.c_ForzarDecimales.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                Me.c_IdSeguridad = xrow("id_seguridad")
                            End If
                        Catch ex As Exception
                            Throw New Exception("MEDIDAS/EMPAQUE: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                    Function BuscarCargar(ByVal xauto As String) As Boolean
                        Try
                            Dim xtb As New DataTable
                            Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                                xadap.SelectCommand.CommandText = "select * from productos_medida where auto=@auto"
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                CargarData(xtb.Rows(0))
                                Return True
                            Else
                                Throw New Exception("PRODUCTOS: MEDIDA/EMPAQUE" + vbCrLf + "BUSCAR MEDIDA" + vbCrLf + "MEDIDA NO ENCONTRADA")
                            End If
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS: MEDIDA/EMPAQUE" + vbCrLf + "BUSCAR MEDIDA" + vbCrLf + ex.Message)
                        End Try
                    End Function
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Sub New(ByVal xrow As DataRow)
                    xregistro = New c_Registro
                    M_Cargardata(xrow)
                End Sub

                Private Const Insert_1 As String = _
                    "update contadores set a_productos_medida=a_productos_medida+1;select a_productos_medida from contadores"
                Private Const Insert_2 As String = _
                    "Insert into PRODUCTOS_MEDIDA (auto,nombre,decimales,forzar_decimales) values (@auto,@nombre,@decimales,@forzar_decimales)"
                Private Const Update_1 As String = _
                    "Update PRODUCTOS_MEDIDA set nombre=@nombre, decimales=@decimales, forzar_decimales=@forzar_decimales " & _
                            "where auto=@auto and id_seguridad=@id_seguridad"
                Private Const Delete_1 As String = _
                    "Delete PRODUCTOS_MEDIDA where auto=@auto"


                ''' <summary>
                ''' Funcion: Eliminar Registro De La Tabla 
                ''' </summary>
                Function F_EliminarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Delete_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR MEDIDA/EMPAQUE, EXISTEN PRODUCTOS CON ESTE TIPO DE EMPAQUE/MEDIDA")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MEDIDA/EMPAQUE" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaRegistro(ByVal xgrupomod As c_ModificarMedida) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_MedidaRegistrar.c_Automatico.c_Texto).Size = xgrupomod.c_MedidaRegistrar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xgrupomod.c_MedidaRegistrar.c_Nombre.c_Texto).Size = xgrupomod.c_MedidaRegistrar.c_Nombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@decimales", xgrupomod.c_MedidaRegistrar.c_Decimales.c_Texto).Size = xgrupomod.c_MedidaRegistrar.c_Decimales.c_Largo
                                    xcmd.Parameters.AddWithValue("@forzar_decimales", xgrupomod.c_MedidaRegistrar.c_ForzarDecimales.c_Texto).Size = xgrupomod.c_MedidaRegistrar.c_ForzarDecimales.c_Largo
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_MedidaRegistrar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR EMPAQUE/MEDIDA, MEDIDA/EMPAQUE HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR EMPAQUE/MEDIDA, EXISTE UN EMPAQUE/MEDIDA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MEDIDA" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal depagregar As c_AgregarMedida) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    depagregar.c_MedidaRegistrar.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", depagregar.c_MedidaRegistrar.c_Automatico.c_Texto).Size = depagregar.c_MedidaRegistrar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", depagregar.c_MedidaRegistrar.c_Nombre.c_Texto).Size = depagregar.c_MedidaRegistrar.c_Nombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@decimales", depagregar.c_MedidaRegistrar.c_Decimales.c_Texto).Size = depagregar.c_MedidaRegistrar.c_Decimales.c_Largo
                                    xcmd.Parameters.AddWithValue("@forzar_decimales", depagregar.c_MedidaRegistrar.c_ForzarDecimales.c_Texto).Size = depagregar.c_MedidaRegistrar.c_ForzarDecimales.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR MEDIDA/EMPAQUE, EXISTE UN EMPAQUE/MEDIDA CON EL MISMO NOMBRE")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR MEDIDA/EMPAQUE, AUTOMATICO DEL EMPAQUE YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MEDIDA" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarMedida(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_medida where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            M_Cargardata(xtb.Rows(0))
                        Else
                            Throw New Exception("PRODUCTOS: MEDIDA/EMPAQUE" + vbCrLf + "BUSCAR MEDIDA" + vbCrLf + "MEDIDA NO ENCONTRADA")
                        End If
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: MEDIDA/EMPAQUE" + vbCrLf + "BUSCAR MEDIDA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub M_Cargardata(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarData(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_DEPOSITO
            ''' </summary>
            Public Class Prd_Deposito
                Event Actualizar()

                Public Class c_Registro
                    Private f_auto_producto As CampoTexto
                    Private f_auto_deposito As CampoTexto
                    Private f_real As CampoSingle
                    Private f_reservada As CampoSingle
                    Private f_disponible As CampoSingle
                    Private f_ubicacion_1 As CampoTexto
                    Private f_ubicacion_2 As CampoTexto
                    Private f_ubicacion_3 As CampoTexto
                    Private f_ubicacion_4 As CampoTexto
                    Private f_nivel_minimo As CampoSingle
                    Private f_pto_pedido As CampoSingle
                    Private f_nivel_optimo As CampoSingle
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo Automatico Del Producto
                    ''' </summary>
                    Protected Friend Property c_AutomaticoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutomaticoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaProducto() As FichaProducto.Prd_Producto.c_Registro
                        Get
                            Try
                                Dim xprd As New FichaProducto.Prd_Producto
                                xprd.F_BuscarCargarFichaProducto(Me._AutoProducto)
                                Return xprd.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del Deposito
                    ''' </summary>
                    Protected Friend Property c_AutomaticoDeposito() As CampoTexto
                        Get
                            Return f_auto_deposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return Me.c_AutomaticoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _f_FichaDeposito() As FichaGlobal.c_Depositos.c_Registro
                        Get
                            Try
                                Dim xdep As New FichaGlobal.c_Depositos
                                xdep.F_BuscarDeposito(Me._AutoDeposito)
                                Return xdep.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Existencia Real, Single 
                    ''' </summary>
                    Protected Friend Property c_MercanciaReal() As CampoSingle
                        Get
                            Return f_real
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_real = value
                        End Set
                    End Property

                    ReadOnly Property _MercanciaReal() As Decimal
                        Get
                            Return Me.c_MercanciaReal.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Existencia Reservada, Single
                    ''' </summary>
                    Protected Friend Property c_MercanciaReservada() As CampoSingle
                        Get
                            Return f_reservada
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_reservada = value
                        End Set
                    End Property

                    ReadOnly Property _MercanciaReservada() As Decimal
                        Get
                            Return Me.c_MercanciaReservada.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Existencia Disponible, Single
                    ''' </summary>
                    Protected Friend Property c_MercanciaDisponible() As CampoSingle
                        Get
                            Return f_disponible
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_disponible = value
                        End Set
                    End Property

                    ReadOnly Property _MercanciaDisponible() As Decimal
                        Get
                            Return Me.c_MercanciaDisponible.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Ubicacion 1
                    ''' </summary>
                    Property c_Ubicacion1() As CampoTexto
                        Get
                            Return f_ubicacion_1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ubicacion_1 = value
                        End Set
                    End Property

                    ReadOnly Property _Ubicacion_1() As String
                        Get
                            Return Me.c_Ubicacion1.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Ubicacion 2
                    ''' </summary>
                    Property c_Ubicacion2() As CampoTexto
                        Get
                            Return f_ubicacion_2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ubicacion_2 = value
                        End Set
                    End Property

                    ReadOnly Property _Ubicacion_2() As String
                        Get
                            Return Me.c_Ubicacion2.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Ubicacion 3
                    ''' </summary>
                    Property c_Ubicacion3() As CampoTexto
                        Get
                            Return f_ubicacion_3
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ubicacion_3 = value
                        End Set
                    End Property

                    ReadOnly Property _Ubicacion_3() As String
                        Get
                            Return Me.c_Ubicacion3.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Ubicacion 4
                    ''' </summary>
                    Property c_Ubicacion4() As CampoTexto
                        Get
                            Return f_ubicacion_4
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_ubicacion_4 = value
                        End Set
                    End Property

                    ReadOnly Property _Ubicacion_4() As String
                        Get
                            Return Me.c_Ubicacion4.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Nivel Minimo En Existencia, Single
                    ''' </summary>
                    Protected Friend Property c_NivelMinimo() As CampoSingle
                        Get
                            Return f_nivel_minimo
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_nivel_minimo = value
                        End Set
                    End Property

                    ReadOnly Property _NivelMinimo() As Decimal
                        Get
                            Return Me.c_NivelMinimo.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Nivel Optimo En Existencia, Single
                    ''' </summary>
                    Protected Friend Property c_NivelOptimo() As CampoSingle
                        Get
                            Return f_nivel_optimo
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_nivel_optimo = value
                        End Set
                    End Property

                    ReadOnly Property _NivelOptimo() As Decimal
                        Get
                            Return Me.c_NivelOptimo.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Nivel Pedido, Single
                    ''' </summary>
                    Protected Friend Property c_NivelPedido() As CampoSingle
                        Get
                            Return f_pto_pedido
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_pto_pedido = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaqueCompra() As Integer
                        Get
                            Try
                                Dim xr As Integer = 0
                                Dim xp1 As New SqlParameter("@auto", _AutoProducto)
                                xr = F_GetDecimal("select contenido_empaque from productos where auto=@auto", xp1)
                                Return xr
                            Catch ex As Exception
                                Return 1
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _NivelPedidoOptimo() As Decimal
                        Get
                            Dim xr As Decimal = 0
                            If Me._NivelOptimo > (Me._MercanciaReal / _ContenidoEmpaqueCompra) Then
                                xr = Me._NivelOptimo - (Me._MercanciaReal / _ContenidoEmpaqueCompra)
                            End If
                            Return xr
                        End Get
                    End Property

                    ReadOnly Property _NivelPedidoMinimo() As Decimal
                        Get
                            Dim xr As Decimal = 0
                            If Me._NivelMinimo > (Me._MercanciaReal / _ContenidoEmpaqueCompra) Then
                                xr = Me._NivelMinimo - (Me._MercanciaReal / _ContenidoEmpaqueCompra)
                            End If
                            Return xr
                        End Get
                    End Property

                    ReadOnly Property _NombreDeposito() As String
                        Get
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me._AutoDeposito)
                                Return F_GetString("select nombre from depositos where auto=@auto", xp1)
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _CodigoDeposito() As String
                        Get
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me._AutoDeposito)
                                Return F_GetString("select codigo from depositos where auto=@auto", xp1)
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Try
                                Dim xp1 As New SqlParameter("@auto", Me._AutoProducto)
                                Return F_GetString("select nombre from productos where auto=@auto", xp1)
                            Catch ex As Exception
                                Return ""
                            End Try
                        End Get
                    End Property

                    Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutomaticoDeposito = New CampoTexto(10, "auto_deposito")
                        Me.c_AutomaticoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_MercanciaDisponible = New CampoSingle("disponible")
                        Me.c_MercanciaReal = New CampoSingle("real")
                        Me.c_MercanciaReservada = New CampoSingle("reservada")
                        Me.c_NivelMinimo = New CampoSingle("nivel_minimo")
                        Me.c_NivelOptimo = New CampoSingle("nivel_optimo")
                        Me.c_NivelPedido = New CampoSingle("pto_pedido")
                        Me.c_Ubicacion1 = New CampoTexto(20, "ubicacion_1")
                        Me.c_Ubicacion2 = New CampoTexto(20, "ubicacion_2")
                        Me.c_Ubicacion3 = New CampoTexto(20, "ubicacion_3")
                        Me.c_Ubicacion4 = New CampoTexto(20, "ubicacion_4")
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutomaticoDeposito.c_Texto = xrow(.c_AutomaticoDeposito.c_NombreInterno)
                                .c_AutomaticoProducto.c_Texto = xrow(.c_AutomaticoProducto.c_NombreInterno)
                                .c_Ubicacion1.c_Texto = xrow(.c_Ubicacion1.c_NombreInterno)
                                .c_Ubicacion2.c_Texto = xrow(.c_Ubicacion2.c_NombreInterno)
                                .c_Ubicacion3.c_Texto = xrow(.c_Ubicacion3.c_NombreInterno)
                                .c_Ubicacion4.c_Texto = xrow(.c_Ubicacion4.c_NombreInterno)
                                .c_MercanciaDisponible.c_Valor = xrow(.c_MercanciaDisponible.c_NombreInterno)
                                .c_MercanciaReal.c_Valor = xrow(.c_MercanciaReal.c_NombreInterno)
                                .c_MercanciaReservada.c_Valor = xrow(.c_MercanciaReservada.c_NombreInterno)
                                .c_NivelMinimo.c_Valor = xrow(.c_NivelMinimo.c_NombreInterno)
                                .c_NivelOptimo.c_Valor = xrow(.c_NivelOptimo.c_NombreInterno)
                                .c_NivelPedido.c_Valor = xrow(.c_NivelPedido.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS:" & vbCrLf & "DEPOSITO" & vbCrLf & "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Sub New(ByVal xrow As DataRow)
                    xregistro = New c_Registro
                    M_CargarRegistro(xrow)
                End Sub

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarDepositoProducto(ByVal xauto_prd As String, ByVal xauto_dep As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@AUTO_PRODUCTO", xauto_prd)
                            xadap.SelectCommand.Parameters.AddWithValue("@AUTO_DEPOSITO", xauto_dep)
                            xadap.SelectCommand.CommandText = "SELECT * FROM PRODUCTOS_DEPOSITO WHERE AUTO_PRODUCTO=@AUTO_PRODUCTO AND AUTO_DEPOSITO=@AUTO_DEPOSITO"
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count = 0 Then
                            Throw New Exception("PRODUCTO Y DEPOSITO NO ENCONTRADO, VERIFIQUE")
                        Else
                            Me.M_CargarRegistro(xtb(0))
                        End If
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS DEPOSITO" + vbCrLf + "BUSCAR DEPOSITO PRODCUTO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_EMPAQUE
            ''' </summary>
            Public Class Prd_Empaque
                Event Actualizar()

                Public Class c_Registro
                    Private f_auto_producto As CampoTexto
                    Private f_precio_1 As CampoSingle
                    Private f_precio_2 As CampoSingle
                    Private f_auto_medida As CampoTexto
                    Private f_contenido As CampoInteger
                    Private f_utilidad_1 As CampoSingle
                    Private f_utilidad_2 As CampoSingle
                    Private f_referencia As CampoTexto
                    Private f_id_seguridad As Byte()

                    Dim xtasa_impuesto As Decimal
                    Dim xcosto_inventario As Decimal

                    Property _TasaIva() As Decimal
                        Get
                            Return xtasa_impuesto
                        End Get
                        Set(ByVal value As Decimal)
                            xtasa_impuesto = value
                        End Set
                    End Property

                    Property _CostoInventario() As Decimal
                        Get
                            Return xcosto_inventario
                        End Get
                        Set(ByVal value As Decimal)
                            xcosto_inventario = value
                        End Set
                    End Property

                    Protected Friend Property c_AutomaticoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Del Producto
                    ''' </summary>
                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutomaticoProducto.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_Precio_N1() As CampoSingle
                        Get
                            Return f_precio_1
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Precio Neto #1
                    ''' </summary>
                    ReadOnly Property _PrecioNeto_1() As Single
                        Get
                            Return Me.c_Precio_N1.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PrecioFull_1() As Decimal
                        Get
                            Dim xf As Decimal
                            xf = Decimal.Round(Me._PrecioNeto_1 + (Me._PrecioNeto_1 * _TasaIva / 100), 2, MidpointRounding.AwayFromZero)
                            Return xf
                        End Get
                    End Property

                    Protected Friend Property c_Precio_N2() As CampoSingle
                        Get
                            Return f_precio_2
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_precio_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Precio Neto #2
                    ''' </summary>
                    ReadOnly Property _PrecioNeto_2() As Single
                        Get
                            Return Me.c_Precio_N2.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _PrecioFull_2() As Decimal
                        Get
                            Dim xf As Decimal
                            xf = Decimal.Round(Me._PrecioNeto_2 + (Me._PrecioNeto_2 * _TasaIva / 100), 2, MidpointRounding.AwayFromZero)
                            Return xf
                        End Get
                    End Property

                    Protected Friend Property c_AutomaticoMedida() As CampoTexto
                        Get
                            Return f_auto_medida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_medida = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Producto_Medida 
                    ''' </summary>
                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return Me.c_AutomaticoMedida.c_Texto
                        End Get
                    End Property

                    ReadOnly Property _f_FichaMedida() As FichaProducto.Prd_Medida.c_Registro
                        Get
                            Try
                                Dim xmedida As New FichaProducto.Prd_Medida
                                xmedida.F_BuscarMedida(Me._AutoMedida)
                                Return xmedida.RegistroDato
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Protected Friend Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenido
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Contenido De Unidades Del Empaque
                    ''' </summary>
                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CostoEmpaque() As Decimal
                        Get
                            Return Decimal.Round(Me._CostoInventario * Me._ContenidoEmpaque, 2, MidpointRounding.AwayFromZero)
                        End Get
                    End Property

                    Protected Friend Property c_Utilidad_1() As CampoSingle
                        Get
                            Return f_utilidad_1
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Utilidad Asignada Al Precio #1 En Porcentaje
                    ''' </summary>
                    ReadOnly Property _UtilidadPrecio_1() As Single
                        Get
                            Return Me.c_Utilidad_1.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Utilidad_2() As CampoSingle
                        Get
                            Return f_utilidad_2
                        End Get
                        Set(ByVal value As CampoSingle)
                            f_utilidad_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Utilidad Asignada Al Precio #2 En Porcentaje
                    ''' </summary>
                    ReadOnly Property _UtilidadPrecio_2() As Single
                        Get
                            Return Me.c_Utilidad_2.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _MargenUtilidad_1() As Decimal
                        Get
                            Dim xf As Decimal = 0
                            xf = Decimal.Round(Me._PrecioNeto_1 - Me._CostoEmpaque, 2, MidpointRounding.AwayFromZero)
                            Return xf
                        End Get
                    End Property

                    ReadOnly Property _MargenUtilidad_2() As Decimal
                        Get
                            Dim xf As Decimal = 0
                            xf = Decimal.Round(Me._PrecioNeto_2 - Me._CostoEmpaque, 2, MidpointRounding.AwayFromZero)
                            Return xf
                        End Get
                    End Property

                    Protected Friend Property c_Referencia() As CampoTexto
                        Get
                            Return f_referencia
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_referencia = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Empaque Referencia: Indica El Empaque Seleccionado (1,2,3,4)
                    ''' </summary>
                    ReadOnly Property _ReferenciaEmpaqueSeleccionado() As String
                        Get
                            Return Me.c_Referencia.c_Texto
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_id_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)

                        Me._TasaIva = 0
                        Me._CostoInventario = 0
                    End Sub

                    Sub New()
                        Me.f_auto_medida = New CampoTexto(10, "auto_medida")
                        Me.f_auto_producto = New CampoTexto(10, "auto_producto")
                        Me.f_referencia = New CampoTexto(1, "referencia")
                        Me.f_contenido = New CampoInteger("contenido")
                        Me.f_precio_1 = New CampoSingle("precio_1")
                        Me.f_precio_2 = New CampoSingle("precio_2")
                        Me.f_utilidad_1 = New CampoSingle("utilidad_1")
                        Me.f_utilidad_2 = New CampoSingle("utilidad_2")

                        Me._TasaIva = 0
                        Me._CostoInventario = 0

                        LimpiarRegistro()
                    End Sub

                    Sub Cargardata(ByVal xrow As DataRow)
                        Try
                            With Me
                                LimpiarRegistro()

                                .c_AutomaticoMedida.c_Texto = xrow(.c_AutomaticoMedida.c_NombreInterno)
                                .c_AutomaticoProducto.c_Texto = xrow(.c_AutomaticoProducto.c_NombreInterno)
                                .c_Referencia.c_Texto = xrow(.c_Referencia.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_Precio_N1.c_Valor = xrow(.c_Precio_N1.c_NombreInterno)
                                .c_Precio_N2.c_Valor = xrow(.c_Precio_N2.c_NombreInterno)
                                .c_Utilidad_1.c_Valor = xrow(.c_Utilidad_1.c_NombreInterno)
                                .c_Utilidad_2.c_Valor = xrow(.c_Utilidad_2.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS EMPAQUE: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub

                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro Dato
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
                    xregistro = New c_Registro
                End Sub

                Sub New(ByVal xrow As DataRow)
                    xregistro = New c_Registro
                    M_Cargardata(xrow)
                End Sub

                Sub M_Cargardata(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.Cargardata(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarCargarPrecioProducto(ByVal xauto As String, ByVal xref As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from productos_empaque where auto_producto=@auto_producto and referencia=@referencia"
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.Parameters.AddWithValue("@auto_producto", xauto).Size = Me.RegistroDato.c_AutomaticoProducto.c_Largo
                            xadap.SelectCommand.Parameters.AddWithValue("@referencia", xref).Size = Me.RegistroDato.c_Referencia.c_Largo
                            xadap.Fill(xtb)
                        End Using

                        If xtb.Rows.Count > 0 Then
                            M_Cargardata(xtb(0))
                            Return True
                        Else
                            Throw New Exception("PRODUCTO - PRECIO REFRENCIA NO ENCONTRADO, VERIFIQUE POR FAVOR")
                        End If
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS EMPAQUE" + vbCrLf + "BUSCAR CARGAR PRECIO REFERENCIA PRODUCTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_KARDEX
            ''' </summary>
            Public Class Prd_Kardex
                Class c_Registro
                    Private f_auto_producto As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_auto_deposito As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_auto_concepto As CampoTexto
                    Private f_entidad As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_medida_empaque As CampoTexto
                    Private f_signo As CampoInteger
                    Private f_cantidad_inventario As CampoDecimal
                    Private f_estatus As CampoTexto
                    Private f_origen As CampoTexto
                    Private f_auto_documento As CampoTexto
                    Private f_nota As CampoTexto
                    'Campos Nuevos
                    Private f_n_NombreProducto As CampoTexto
                    Private f_n_NombreDeposito As CampoTexto
                    Private f_n_NombreConcepto As CampoTexto
                    Private f_n_NombreMedidaEmpaque As CampoTexto
                    Private f_n_AutoMedida As CampoTexto
                    Private f_n_ContenidoMedidaEmpaque As CampoInteger
                    Private f_n_CodigoProducto As CampoTexto
                    Private f_n_CodigoConcepto As CampoTexto
                    Private f_n_CodigoDeposito As CampoTexto

                    Private xitem_venta As String
                    Private xcant_requerida As Integer
                    ''' <summary>
                    ''' PROPIEDAD USADA PARA INDICAR EL ITEM AL CUAL CORRESPONDE EN TABLA VENTAS_DETALLE_FASTFOOD
                    ''' </summary>
                    Protected Friend Property _FastFood_ItemVenta() As String
                        Get
                            Return xitem_venta
                        End Get
                        Set(ByVal value As String)
                            xitem_venta = value
                        End Set
                    End Property
                    ''' <summary>
                    ''' PROPIEDAD USADA PARA INDICAR LA CANTIDAD REQUERIDA A SACAR DEL INVENTARIO 
                    ''' </summary>
                    Protected Friend Property _FastFood_CantidadRequerida() As Integer
                        Get
                            Return xcant_requerida
                        End Get
                        Set(ByVal value As Integer)
                            xcant_requerida = value
                        End Set
                    End Property


                    Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return Me.c_FechaEmision.c_Valor
                        End Get
                    End Property

                    Property c_AutoDeposito() As CampoTexto
                        Get
                            Return f_auto_deposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_deposito = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDeposito() As String
                        Get
                            Return Me.c_AutoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    Property c_CantidadMover() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadMover() As Decimal
                        Get
                            Return Me.c_CantidadMover.c_Valor
                        End Get
                    End Property

                    Property c_AutoConcepto() As CampoTexto
                        Get
                            Return f_auto_concepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_concepto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoConcepto() As String
                        Get
                            Return Me.c_AutoConcepto.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Entidad() As CampoTexto
                        Get
                            Return f_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _Entidad() As String
                        Get
                            Return Me.c_Entidad.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Documento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property

                    ReadOnly Property _Documento() As String
                        Get
                            Return Me.c_Documento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_ReferenciaEmpaque() As CampoTexto
                        Get
                            Return f_medida_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_medida_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _ReferenciaEmpaque() As String
                        Get
                            Return Me.c_ReferenciaEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    Property c_TipoMovimiento() As CampoInteger
                        Get
                            Return f_signo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_signo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMovimiento() As TipoMovimientoInventario
                        Get
                            If Me.c_TipoMovimiento.c_Valor = 1 Then
                                Return TipoMovimientoInventario.Entrada
                            Else
                                Return TipoMovimientoInventario.Salida
                            End If
                        End Get
                    End Property

                    Property c_CantidadUnidadesMover() As CampoDecimal
                        Get
                            Return f_cantidad_inventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad_inventario = value
                        End Set
                    End Property

                    ReadOnly Property _CantidadUnidadesMover() As Decimal
                        Get
                            Return Me.c_CantidadUnidadesMover.c_Valor
                        End Get
                    End Property

                    Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As String
                        Get
                            Return Me.c_Estatus.c_Texto.Trim
                        End Get
                    End Property

                    Property c_OrigenMovimiento() As CampoTexto
                        Get
                            Return f_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_origen = value
                        End Set
                    End Property

                    ReadOnly Property _OrigenMovimiento() As String
                        Get
                            Return Me.c_OrigenMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return Me.c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_NotasDetallesMovimiento() As CampoTexto
                        Get
                            Return f_nota
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nota = value
                        End Set
                    End Property

                    ReadOnly Property _NotasDetallesMovimiento() As String
                        Get
                            Return Me.c_NotasDetallesMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    'Campos Nuevos
                    Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_n_NombreProducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_NombreProducto = value
                        End Set
                    End Property

                    Property c_NombreDeposito() As CampoTexto
                        Get
                            Return f_n_NombreDeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_NombreDeposito = value
                        End Set
                    End Property

                    Property c_NombreConcepto() As CampoTexto
                        Get
                            Return f_n_NombreConcepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_NombreConcepto = value
                        End Set
                    End Property

                    Property c_NombreMedidaEmpaque() As CampoTexto
                        Get
                            Return f_n_NombreMedidaEmpaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_NombreMedidaEmpaque = value
                        End Set
                    End Property

                    Property c_AutoMedida() As CampoTexto
                        Get
                            Return f_n_AutoMedida
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_AutoMedida = value
                        End Set
                    End Property

                    Property c_ContenidoMedidaEmpaque() As CampoInteger
                        Get
                            Return f_n_ContenidoMedidaEmpaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_n_ContenidoMedidaEmpaque = value
                        End Set
                    End Property

                    Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_n_CodigoProducto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_CodigoProducto = value
                        End Set
                    End Property

                    Property c_CodigoDeposito() As CampoTexto
                        Get
                            Return f_n_CodigoDeposito
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_CodigoDeposito = value
                        End Set
                    End Property

                    Property c_CodigoConcepto() As CampoTexto
                        Get
                            Return f_n_CodigoConcepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_n_CodigoConcepto = value
                        End Set
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return f_n_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreDeposito() As String
                        Get
                            Return f_n_NombreDeposito.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreConcepto() As String
                        Get
                            Return f_n_NombreConcepto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreMedidaEmpaque() As String
                        Get
                            Return f_n_NombreMedidaEmpaque.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoMedida() As String
                        Get
                            Return f_n_AutoMedida.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ContenidoMedidaEmpaque() As Integer
                        Get
                            Return f_n_ContenidoMedidaEmpaque.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return f_n_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoDeposito() As String
                        Get
                            Return f_n_CodigoDeposito.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoConcepto() As String
                        Get
                            Return f_n_CodigoConcepto.c_Texto.Trim
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoConcepto = New CampoTexto(10, "auto_concepto")
                        Me.c_AutoDeposito = New CampoTexto(10, "auto_deposito")
                        Me.c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_CantidadMover = New CampoDecimal("cantidad")
                        Me.c_CantidadUnidadesMover = New CampoDecimal("cantidad_inventario")
                        Me.c_Documento = New CampoTexto(15, "documento")
                        Me.c_Entidad = New CampoTexto(50, "entidad")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_FechaEmision = New CampoFecha("fecha")
                        Me.c_NotasDetallesMovimiento = New CampoTexto(50, "nota")
                        Me.c_OrigenMovimiento = New CampoTexto(4, "origen")
                        Me.c_ReferenciaEmpaque = New CampoTexto(1, "medida_empaque")
                        Me.c_TipoMovimiento = New CampoInteger("signo")

                        'Campos Nuevos
                        Me.c_NombreProducto = New CampoTexto(200, "n_NombreProducto")
                        Me.c_NombreDeposito = New CampoTexto(20, "n_NombreDeposito")
                        Me.c_NombreConcepto = New CampoTexto(50, "n_NombreConcepto")
                        Me.c_NombreMedidaEmpaque = New CampoTexto(20, "n_NombreMedidaEmpaque")
                        Me.c_AutoMedida = New CampoTexto(10, "n_AutoMedia")
                        Me.c_ContenidoMedidaEmpaque = New CampoInteger("ContenidoMedidaEmpaque")
                        Me.c_CodigoProducto = New CampoTexto(15, "n_CodigoProducto")
                        Me.c_CodigoDeposito = New CampoTexto(10, "n_CodigoDeposito")
                        Me.c_CodigoConcepto = New CampoTexto(10, "n_CodigoConcepto")

                        M_LimpiarRegistro()
                    End Sub
                End Class

                Protected Friend Const INSERT_PRODUCTOS_KARDEX = " INSERT INTO productos_kardex (" _
                   + "auto_producto," _
                   + "fecha," _
                   + "auto_deposito," _
                   + "cantidad," _
                   + "auto_concepto," _
                   + "entidad," _
                   + "documento," _
                   + "medida_empaque," _
                   + "signo," _
                   + "cantidad_inventario," _
                   + "estatus," _
                   + "origen," _
                   + "auto_documento," _
                   + "nota, " _
                   + "n_NombreProducto, " _
                   + "n_NombreDeposito, " _
                   + "n_NombreConcepto, " _
                   + "n_NombreMedidaEmpaque, " _
                   + "n_AutoMedida, " _
                   + "n_ContenidoMedidaEmpaque, " _
                   + "n_CodigoProducto, " _
                   + "n_CodigoDeposito, " _
                   + "n_CodigoConcepto) " _
                   + "VALUES (" _
                   + "@auto_producto," _
                   + "@fecha," _
                   + "@auto_deposito," _
                   + "@cantidad," _
                   + "@auto_concepto," _
                   + "@entidad," _
                   + "@documento," _
                   + "@medida_empaque," _
                   + "@signo," _
                   + "@cantidad_inventario," _
                   + "@estatus," _
                   + "@origen," _
                   + "@auto_documento," _
                   + "@nota, " _
                   + "@n_NombreProducto, " _
                   + "@n_NombreDeposito, " _
                   + "@n_NombreConcepto, " _
                   + "@n_NombreMedidaEmpaque, " _
                   + "@n_AutoMedida, " _
                   + "@n_ContenidoMedidaEmpaque, " _
                   + "@n_CodigoProducto, " _
                   + "@n_CodigoDeposito, " _
                   + "@n_CodigoConcepto) "

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
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_HISTORICO_PRECIOS
            ''' </summary>
            Public Class Prd_HistoricoPrecios
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_producto As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_estacion As CampoTexto
                    Private f_auto_usuario As CampoTexto
                    Private f_precio_id As CampoTexto
                    Private f_precio_anterior As CampoDecimal
                    Private f_precio_nuevo As CampoDecimal
                    Private f_empaque As CampoTexto
                    Private f_nota As CampoTexto
                    Private f_usuario As CampoTexto
                    Private f_hora As CampoTexto
                    Private f_contenido_empaque As CampoInteger

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaMovimiento() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaMovimiento() As Date
                        Get
                            Return Me.c_FechaMovimiento.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_EstacionEquipo() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _EquipoEstacion() As String
                        Get
                            Return Me.c_EstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_auto_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return Me.c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_PrecioReferencia() As CampoTexto
                        Get
                            Return f_precio_id
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_precio_id = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioReferencia() As String
                        Get
                            Return Me.c_PrecioReferencia.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_PrecioAnterior() As CampoDecimal
                        Get
                            Return f_precio_anterior
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_anterior = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioAnterior() As Decimal
                        Get
                            Return Me.c_PrecioAnterior.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_PrecioNuevo() As CampoDecimal
                        Get
                            Return f_precio_nuevo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_precio_nuevo = value
                        End Set
                    End Property

                    ReadOnly Property _PrecioNuevo() As Decimal
                        Get
                            Return Me.c_PrecioNuevo.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Empaque() As CampoTexto
                        Get
                            Return f_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return Me.c_Empaque.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Nota() As CampoTexto
                        Get
                            Return f_nota
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nota = value
                        End Set
                    End Property

                    ReadOnly Property _NotasDetalle() As String
                        Get
                            Return Me.c_Nota.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Usuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_Usuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _HoraMovimiento() As String
                        Get
                            Return Me.c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenido_empaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_AutoUsuario = New CampoTexto(10, "auto_usuario")
                        Me.c_Empaque = New CampoTexto(15, "empaque")
                        Me.c_EstacionEquipo = New CampoTexto(20, "estacion")
                        Me.c_FechaMovimiento = New CampoFecha("fecha")
                        Me.c_Hora = New CampoTexto(5, "hora")
                        Me.c_Nota = New CampoTexto(40, "nota")
                        Me.c_PrecioAnterior = New CampoDecimal("precio_anterior")
                        Me.c_PrecioNuevo = New CampoDecimal("precio_nunevo")
                        Me.c_PrecioReferencia = New CampoTexto(8, "precio_id")
                        Me.c_Usuario = New CampoTexto(20, "usuario")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenido_empaque")

                        LimpiarRegistro()
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
                    Me.RegistroDato = New c_Registro
                End Sub
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_MOVIMIENTOS
            ''' </summary>
            Public Class Prd_Movimiento
                Event _ActualizarFicha()

                Class c_AgregarMovimiento
                    Private xregistro As c_Registro
                    Private xfecha As Date
                    Private xnota As String
                    Private xsucursal As String
                    Private xhora As String
                    Private xequipo As String
                    Private xdeposito_origen As FichaGlobal.c_Depositos.c_Registro
                    Private xconcepto As FichaProducto.Prd_Concepto.c_Registro
                    Private xproducto As FichaProducto.Prd_Producto.c_Registro
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xcantidad As Decimal
                    Private xidseguridad_deposito As Byte()

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroDato = New c_Registro
                        _CantidadAjuste = 0
                        _ConceptoMovimiento = New FichaProducto.Prd_Concepto.c_Registro
                        _DepositoOrigen = New FichaGlobal.c_Depositos.c_Registro
                        _EquipoEstacion = ""
                        _FechaMovimiento = Date.Today
                        _Hora = ""
                        _NotasDetalle = ""
                        _Producto = New FichaProducto.Prd_Producto.c_Registro
                        _Usuario = New FichaGlobal.c_Usuario.c_Registro
                        _Sucursal = ""
                    End Sub

                    Property _FechaMovimiento() As Date
                        Protected Friend Get
                            Return xfecha
                        End Get
                        Set(ByVal value As Date)
                            xfecha = value
                        End Set
                    End Property

                    Property _NotasDetalle() As String
                        Protected Friend Get
                            Return xnota
                        End Get
                        Set(ByVal value As String)
                            xnota = value
                        End Set
                    End Property

                    Property _Sucursal() As String
                        Protected Friend Get
                            Return xsucursal
                        End Get
                        Set(ByVal value As String)
                            xsucursal = value
                        End Set
                    End Property

                    Property _Hora() As String
                        Protected Friend Get
                            Return xhora
                        End Get
                        Set(ByVal value As String)
                            xhora = value
                        End Set
                    End Property

                    Property _EquipoEstacion() As String
                        Protected Friend Get
                            Return xequipo
                        End Get
                        Set(ByVal value As String)
                            xequipo = value
                        End Set
                    End Property

                    Property _DepositoOrigen() As FichaGlobal.c_Depositos.c_Registro
                        Protected Friend Get
                            Return xdeposito_origen
                        End Get
                        Set(ByVal value As FichaGlobal.c_Depositos.c_Registro)
                            xdeposito_origen = value
                        End Set
                    End Property

                    Property _ConceptoMovimiento() As FichaProducto.Prd_Concepto.c_Registro
                        Protected Friend Get
                            Return xconcepto
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Concepto.c_Registro)
                            xconcepto = value
                        End Set
                    End Property

                    Property _Producto() As FichaProducto.Prd_Producto.c_Registro
                        Protected Friend Get
                            Return xproducto
                        End Get
                        Set(ByVal value As FichaProducto.Prd_Producto.c_Registro)
                            xproducto = value
                        End Set
                    End Property

                    Property _CantidadAjuste() As Decimal
                        Protected Friend Get
                            Return xcantidad
                        End Get
                        Set(ByVal value As Decimal)
                            xcantidad = value
                        End Set
                    End Property

                    Property _Usuario() As FichaGlobal.c_Usuario.c_Registro
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                            xusuario = value
                        End Set
                    End Property

                    Property _IdSeguridad_DepositoMovimiento() As Byte()
                        Protected Friend Get
                            Return Me.xidseguridad_deposito
                        End Get
                        Set(ByVal value As Byte())
                            Me.xidseguridad_deposito = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_documento As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_fecha_vencimiento As CampoFecha
                    Private f_nota As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_usuario As CampoTexto
                    Private f_codigo_usuario As CampoTexto
                    Private f_codigo_sucursal As CampoTexto
                    Private f_hora As CampoTexto
                    Private f_estacion As CampoTexto
                    Private f_origen As CampoTexto
                    Private f_destino As CampoTexto
                    Private f_auto_origen As CampoTexto
                    Private f_auto_destino As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_renglones As CampoInteger
                    Private f_codigo_origen As CampoTexto
                    Private f_codigo_destino As CampoTexto
                    Private f_concepto As CampoTexto
                    Private f_auto_concepto As CampoTexto
                    Private f_codigo_concepto As CampoTexto

                    Protected Friend Property c_AutoMovimiento() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property
                    ReadOnly Property _AutoMovimiento() As String
                        Get
                            Return Me.c_AutoMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Documento() As CampoTexto
                        Get
                            Return f_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_documento = value
                        End Set
                    End Property
                    ReadOnly Property _Documento() As String
                        Get
                            Return Me.c_Documento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property
                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return Me.c_FechaEmision.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_FechaVencimiento() As CampoFecha
                        Get
                            Return f_fecha_vencimiento
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_vencimiento = value
                        End Set
                    End Property
                    ReadOnly Property _FechaVencimiento() As Date
                        Get
                            Return Me.c_FechaVencimiento.c_Valor
                        End Get
                    End Property

                    Property c_NotasDetalle() As CampoTexto
                        Get
                            Return f_nota
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nota = value
                        End Set
                    End Property
                    ReadOnly Property _NotasDetalle() As String
                        Get
                            Return Me.c_NotasDetalle.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_UsuarioNombre() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property
                    ReadOnly Property _UsuarioNombre() As String
                        Get
                            Return Me.c_UsuarioNombre.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_UsuarioCodigo() As CampoTexto
                        Get
                            Return f_codigo_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_usuario = value
                        End Set
                    End Property
                    ReadOnly Property _UsuarioCodigo() As String
                        Get
                            Return Me.c_UsuarioCodigo.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoSucursal() As CampoTexto
                        Get
                            Return f_codigo_sucursal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_sucursal = value
                        End Set
                    End Property
                    ReadOnly Property _CodigoSucursal() As String
                        Get
                            Return Me.c_CodigoSucursal.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property
                    ReadOnly Property _Hora() As String
                        Get
                            Return Me.c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_EstacionEquipo() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property
                    ReadOnly Property _EstacionEquipo() As String
                        Get
                            Return Me.c_EstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Origen() As CampoTexto
                        Get
                            Return f_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_origen = value
                        End Set
                    End Property

                    Property c_Destino() As CampoTexto
                        Get
                            Return f_destino
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_destino = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoOrigen() As CampoTexto
                        Get
                            Return f_auto_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDestino() As CampoTexto
                        Get
                            Return f_auto_destino
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_destino = value
                        End Set
                    End Property

                    Protected Friend Property c_Tipo() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    Protected Friend Property c_Renglones() As CampoInteger
                        Get
                            Return f_renglones
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_renglones = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoOrigen() As CampoTexto
                        Get
                            Return f_codigo_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_origen = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoDestino() As CampoTexto
                        Get
                            Return f_codigo_destino
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_destino = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoConcepto() As CampoTexto
                        Get
                            Return f_auto_concepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_concepto = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoConcepto() As CampoTexto
                        Get
                            Return f_codigo_concepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_concepto = value
                        End Set
                    End Property

                    Protected Friend Property c_Concepto() As CampoTexto
                        Get
                            Return f_concepto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_concepto = value
                        End Set
                    End Property

                    ReadOnly Property _Origen() As String
                        Get
                            Return Me.c_Origen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Destino() As String
                        Get
                            Return Me.c_Destino.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoOrigen() As String
                        Get
                            Return Me.c_AutoOrigen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDestino() As String
                        Get
                            Return Me.c_AutoDestino.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Tipo() As String
                        Get
                            Return Me.c_Tipo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Renglones() As Integer
                        Get
                            Return Me.c_Renglones.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CodigoOrigen() As String
                        Get
                            Return Me.c_CodigoOrigen.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoDestino() As String
                        Get
                            Return Me.c_CodigoDestino.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoConcepto() As String
                        Get
                            Return Me.c_AutoConcepto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoConcepto() As String
                        Get
                            Return Me.c_CodigoConcepto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Concepto() As String
                        Get
                            Return Me.c_Concepto.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoConcepto = New CampoTexto(10, "auto_concepto")
                        Me.c_AutoDestino = New CampoTexto(10, "auto_destino")
                        Me.c_AutoMovimiento = New CampoTexto(10, "auto")
                        Me.c_AutoOrigen = New CampoTexto(10, "auto_origen")
                        Me.c_CodigoConcepto = New CampoTexto(10, "codigo_concepto")
                        Me.c_CodigoDestino = New CampoTexto(10, "codigo_destino")
                        Me.c_CodigoOrigen = New CampoTexto(10, "codigo_origen")
                        Me.c_CodigoSucursal = New CampoTexto(10, "codigo_sucursal")
                        Me.c_Concepto = New CampoTexto(60, "concepto")
                        Me.c_Destino = New CampoTexto(60, "destino")
                        Me.c_Documento = New CampoTexto(10, "documento")
                        Me.c_EstacionEquipo = New CampoTexto(20, "estacion")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_FechaEmision = New CampoFecha("fecha")
                        Me.c_FechaVencimiento = New CampoFecha("fecha_vencimiento")
                        Me.c_Hora = New CampoTexto(10, "hora")
                        Me.c_NotasDetalle = New CampoTexto(120, "nota")
                        Me.c_Origen = New CampoTexto(60, "origen")
                        Me.c_Renglones = New CampoInteger("renglones")
                        Me.c_Tipo = New CampoTexto(2, "tipo")
                        Me.c_UsuarioCodigo = New CampoTexto(10, "codigo_usuario")
                        Me.c_UsuarioNombre = New CampoTexto(20, "usuario")

                        LimpiarRegistro()
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
                    Me.RegistroDato = New c_Registro
                End Sub

                Protected Friend Const INSERT_PRODUCTOS_MOVIMIENTO As String = "insert into productos_movimientos ( " _
                                     + "auto, " _
                                     + "documento, " _
                                     + "fecha, " _
                                     + "fecha_vencimiento, " _
                                     + "nota, " _
                                     + "estatus, " _
                                     + "usuario, " _
                                     + "codigo_usuario, " _
                                     + "codigo_sucursal, " _
                                     + "hora, " _
                                     + "estacion, " _
                                     + "origen, " _
                                     + "destino, " _
                                     + "auto_origen, " _
                                     + "auto_destino, " _
                                     + "tipo, " _
                                     + "renglones, " _
                                     + "codigo_origen, " _
                                     + "codigo_destino, " _
                                     + "concepto, " _
                                     + "auto_concepto, " _
                                     + "codigo_concepto) " _
                                     + "values ( " _
                                     + "@auto, " _
                                     + "@documento, " _
                                     + "@fecha, " _
                                     + "@fecha_vencimiento, " _
                                     + "@nota, " _
                                     + "@estatus, " _
                                     + "@usuario, " _
                                     + "@codigo_usuario, " _
                                     + "@codigo_sucursal, " _
                                     + "@hora, " _
                                     + "@estacion, " _
                                     + "@origen, " _
                                     + "@destino, " _
                                     + "@auto_origen, " _
                                     + "@auto_destino, " _
                                     + "@tipo, " _
                                     + "@renglones, " _
                                     + "@codigo_origen, " _
                                     + "@codigo_destino, " _
                                     + "@concepto, " _
                                     + "@auto_concepto, " _
                                     + "@codigo_concepto) "

                Function F_MovimientoInventario(ByVal xmovimiento As c_AgregarMovimiento) As Boolean
                    Dim xtr As SqlTransaction
                    Dim xauto As String = ""
                    Dim xsql_1 As String = "update contadores set a_productos_ajustes=a_productos_ajustes+1;select a_productos_ajustes from contadores"

                    Dim xsql_3 As String = "update productos_deposito set real=real+@ajuste, disponible=disponible+@ajuste " _
                                         + "where auto_producto=@auto_producto and auto_deposito=@auto_deposito and id_seguridad=@id_seguridad"

                    Try
                        Dim xmov As New FichaProducto.Prd_Movimiento.c_Registro
                        With xmov
                            .c_AutoConcepto.c_Texto = xmovimiento._ConceptoMovimiento.c_Automatico.c_Texto
                            .c_AutoDestino.c_Texto = ""
                            .c_AutoOrigen.c_Texto = xmovimiento._DepositoOrigen.c_Automatico.c_Texto
                            .c_CodigoConcepto.c_Texto = xmovimiento._ConceptoMovimiento.c_CodigoConcepto.c_Texto
                            .c_CodigoDestino.c_Texto = ""
                            .c_CodigoOrigen.c_Texto = xmovimiento._DepositoOrigen.c_Codigo.c_Texto
                            .c_CodigoSucursal.c_Texto = xmovimiento._Sucursal
                            .c_Concepto.c_Texto = xmovimiento._ConceptoMovimiento.c_NombreConcepto.c_Texto
                            .c_Destino.c_Texto = ""
                            .c_EstacionEquipo.c_Texto = xmovimiento._EquipoEstacion
                            .c_Estatus.c_Texto = "0"
                            .c_FechaEmision.c_Valor = xmovimiento._FechaMovimiento
                            .c_FechaVencimiento.c_Valor = xmovimiento._FechaMovimiento
                            .c_Hora.c_Texto = xmovimiento._Hora
                            .c_NotasDetalle.c_Texto = xmovimiento._NotasDetalle
                            .c_Origen.c_Texto = xmovimiento._DepositoOrigen.c_Nombre.c_Texto
                            .c_Renglones.c_Valor = 1
                            .c_Tipo.c_Texto = "01"
                            .c_UsuarioCodigo.c_Texto = xmovimiento._Usuario._CodigoUsuario
                            .c_UsuarioNombre.c_Texto = xmovimiento._Usuario._NombreUsuario
                        End With

                        Dim xkardex As New FichaProducto.Prd_Kardex.c_Registro
                        With xkardex
                            .c_AutoConcepto.c_Texto = xmovimiento._ConceptoMovimiento.c_Automatico.c_Texto
                            .c_AutoDeposito.c_Texto = xmovimiento._DepositoOrigen.c_Automatico.c_Texto
                            .c_AutoProducto.c_Texto = xmovimiento._Producto.c_Automatico.c_Texto
                            .c_CantidadMover.c_Valor = xmovimiento._CantidadAjuste
                            .c_CantidadUnidadesMover.c_Valor = xmovimiento._CantidadAjuste * xmovimiento._Producto.c_ContEmpCompra.c_Valor
                            .c_Entidad.c_Texto = "ALMACEN/INVENTARIO"
                            .c_Estatus.c_Texto = "0"
                            .c_FechaEmision.c_Valor = xmovimiento._FechaMovimiento
                            .c_NotasDetallesMovimiento.c_Texto = xmovimiento._NotasDetalle
                            .c_OrigenMovimiento.c_Texto = "0301"
                            .c_ReferenciaEmpaque.c_Texto = "1"
                            .c_TipoMovimiento.c_Valor = 1
                            'Campos Nuevos
                            .c_NombreProducto.c_Texto = xmovimiento._Producto._DescripcionDetallaDelProducto
                            .c_NombreDeposito.c_Texto = xmovimiento._DepositoOrigen._Nombre
                            .c_NombreConcepto.c_Texto = xmovimiento._ConceptoMovimiento._NombreConcepto
                            .c_NombreMedidaEmpaque.c_Texto = xmovimiento._Producto._NombreEmpaqueCompra
                            .c_AutoMedida.c_Texto = xmovimiento._Producto._AutoEmpaqueCompra
                            .c_ContenidoMedidaEmpaque.c_Valor = xmovimiento._Producto._ContEmpqCompra
                            .c_CodigoProducto.c_Texto = xmovimiento._Producto._CodigoProducto
                            .c_CodigoDeposito.c_Texto = xmovimiento._DepositoOrigen._Codigo
                            .c_CodigoConcepto.c_Texto = xmovimiento._ConceptoMovimiento._CodigoConcepto
                        End With

                        Dim xmov_dt As New FichaProducto.Prd_MovimientoDetalle.c_Registro
                        With xmov_dt
                            .c_AutoItemMovimiento.c_Texto = "0000000001"
                            .c_AutoProducto.c_Texto = xmovimiento._Producto.c_Automatico.c_Texto
                            .c_CantidadAjuste.c_Valor = xmovimiento._CantidadAjuste
                            .c_CantidadUnidadInventario.c_Valor = xkardex.c_CantidadUnidadesMover.c_Valor
                            .c_CategoriaProducto.c_Texto = xmovimiento._Producto.c_CategoriaProducto.c_Texto
                            .c_CodigoProducto.c_Texto = xmovimiento._Producto.c_CodigoProducto.c_Texto
                            .c_ContenidoEmpaque.c_Valor = xmovimiento._Producto.c_ContEmpCompra.c_Valor
                            .c_EmpaqueTipo.c_Texto = "1"
                            .c_EmpaqueUnidadMedida.c_Texto = xmovimiento._Producto._NombreEmpaqueCompra
                            .c_Estatus.c_Texto = "0"
                            .c_FechaMovimiento.c_Valor = xmovimiento._FechaMovimiento
                            .c_NombreProducto.c_Texto = xmovimiento._Producto.c_NombreProducto.c_Texto
                            .c_NumeroDecimalesExpresar.c_Texto = xmovimiento._Producto._CantDecimalesEmpaqueCompra
                            .c_TipoMovimiento.c_Texto = "01"
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'Contadores
                                    xcmd.CommandText = xsql_1
                                    xmov.c_AutoMovimiento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    xmov.c_Documento.c_Texto = xmov.c_AutoMovimiento.c_Texto
                                    xkardex.c_AutoDocumento.c_Texto = xmov.c_AutoMovimiento.c_Texto
                                    xkardex.c_Documento.c_Texto = xmov.c_AutoMovimiento.c_Texto
                                    xmov_dt.c_AutoDocumento.c_Texto = xmov.c_AutoMovimiento.c_Texto

                                    'Productos_Kardex
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                    xcmd.Parameters.AddWithValue("@auto_producto", xkardex.c_AutoProducto.c_Texto).Size = xkardex.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xkardex.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xkardex.c_AutoDeposito.c_Texto).Size = xkardex.c_AutoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad", xkardex.c_CantidadMover.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_concepto", xkardex.c_AutoConcepto.c_Texto).Size = xkardex.c_AutoConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@entidad", xkardex.c_Entidad.c_Texto).Size = xkardex.c_Entidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xkardex.c_Documento.c_Texto).Size = xkardex.c_Documento.c_Largo
                                    xcmd.Parameters.AddWithValue("@medida_empaque", xkardex.c_ReferenciaEmpaque.c_Texto).Size = xkardex.c_ReferenciaEmpaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xkardex.c_TipoMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xkardex.c_CantidadUnidadesMover.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estatus", xkardex.c_Estatus.c_Texto).Size = xkardex.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xkardex.c_OrigenMovimiento.c_Texto).Size = xkardex.c_OrigenMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xkardex.c_AutoDocumento.c_Texto).Size = xkardex.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@nota", xkardex.c_NotasDetallesMovimiento.c_Texto).Size = xkardex.c_NotasDetallesMovimiento.c_Largo
                                    'Campos Nuevos
                                    xcmd.Parameters.AddWithValue("@n_nombreproducto", xkardex.c_NombreProducto.c_Texto).Size = xkardex.c_NombreProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombredeposito", xkardex.c_NombreDeposito.c_Texto).Size = xkardex.c_NombreDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombreconcepto", xkardex.c_NombreConcepto.c_Texto).Size = xkardex.c_NombreConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xkardex.c_NombreMedidaEmpaque.c_Texto).Size = xkardex.c_NombreMedidaEmpaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_automedida", xkardex.c_AutoMedida.c_Texto).Size = xkardex.c_AutoMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xkardex.c_ContenidoMedidaEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@n_codigoproducto", xkardex.c_CodigoProducto.c_Texto).Size = xkardex.c_CodigoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_codigodeposito", xkardex.c_CodigoDeposito.c_Texto).Size = xkardex.c_CodigoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_codigoconcepto", xkardex.c_CodigoConcepto.c_Texto).Size = xkardex.c_CodigoConcepto.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    'Productos_Deposito
                                    Dim xr As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3
                                    xcmd.Parameters.AddWithValue("@auto_producto", xmovimiento._Producto.c_Automatico.c_Texto).Size = xmovimiento._Producto.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xmovimiento._DepositoOrigen.c_Automatico.c_Texto).Size = xmovimiento._DepositoOrigen.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@ajuste", xkardex.c_CantidadUnidadesMover.c_Valor)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xmovimiento._IdSeguridad_DepositoMovimiento)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("DEPOSITO DEL MOVIMIENTO FUE ACTUALIZADO POR OTRO USUARIO, VERIFIQUE")
                                    End If

                                    With xmov
                                        .c_AutoConcepto.c_Texto = xmovimiento._ConceptoMovimiento.c_Automatico.c_Texto
                                        .c_AutoDestino.c_Texto = ""
                                        .c_AutoOrigen.c_Texto = xmovimiento._DepositoOrigen.c_Automatico.c_Texto
                                        .c_CodigoConcepto.c_Texto = xmovimiento._ConceptoMovimiento.c_CodigoConcepto.c_Texto
                                        .c_CodigoDestino.c_Texto = ""
                                        .c_CodigoOrigen.c_Texto = xmovimiento._DepositoOrigen.c_Codigo.c_Texto
                                        .c_CodigoSucursal.c_Texto = xmovimiento._Sucursal
                                        .c_Concepto.c_Texto = xmovimiento._ConceptoMovimiento.c_NombreConcepto.c_Texto
                                        .c_Destino.c_Texto = ""
                                        .c_EstacionEquipo.c_Texto = xmovimiento._EquipoEstacion
                                        .c_Estatus.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xmovimiento._FechaMovimiento
                                        .c_FechaVencimiento.c_Valor = xmovimiento._FechaMovimiento
                                        .c_Hora.c_Texto = xmovimiento._Hora
                                        .c_NotasDetalle.c_Texto = xmovimiento._NotasDetalle
                                        .c_Origen.c_Texto = xmovimiento._DepositoOrigen.c_Nombre.c_Texto
                                        .c_Renglones.c_Valor = 1
                                        .c_Tipo.c_Texto = "01"
                                        .c_UsuarioCodigo.c_Texto = xmovimiento._Usuario._CodigoUsuario
                                        .c_UsuarioNombre.c_Texto = xmovimiento._Usuario._NombreUsuario
                                    End With

                                    'Productos_Movimientos
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_PRODUCTOS_MOVIMIENTO
                                    xcmd.Parameters.AddWithValue("@auto", xmov.c_AutoMovimiento.c_Texto).Size = xmov.c_AutoMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xmov.c_Documento.c_Texto).Size = xmov.c_Documento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xmov.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xmov.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@nota", xmov.c_NotasDetalle.c_Texto).Size = xmov.c_NotasDetalle.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xmov.c_Estatus.c_Texto).Size = xmov.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@usuario", xmov.c_UsuarioNombre.c_Texto).Size = xmov.c_UsuarioNombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_usuario", xmov.c_UsuarioCodigo.c_Texto).Size = xmov.c_UsuarioCodigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_sucursal", xmov.c_CodigoSucursal.c_Texto).Size = xmov.c_CodigoSucursal.c_Largo
                                    xcmd.Parameters.AddWithValue("@hora", xmov.c_Hora.c_Texto).Size = xmov.c_Hora.c_Largo
                                    xcmd.Parameters.AddWithValue("@estacion", xmov.c_EstacionEquipo.c_Texto).Size = xmov.c_EstacionEquipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xmov.c_Origen.c_Texto).Size = xmov.c_Origen.c_Largo
                                    xcmd.Parameters.AddWithValue("@destino", xmov.c_Destino.c_Texto).Size = xmov.c_Destino.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_origen", xmov.c_AutoOrigen.c_Texto).Size = xmov.c_AutoOrigen.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_destino", xmov.c_AutoDestino.c_Texto).Size = xmov.c_AutoDestino.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xmov.c_Tipo.c_Texto).Size = xmov.c_Tipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@renglones", xmov.c_Renglones.c_Valor)
                                    xcmd.Parameters.AddWithValue("@codigo_origen", xmov.c_CodigoOrigen.c_Texto).Size = xmov.c_CodigoOrigen.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_destino", xmov.c_CodigoDestino.c_Texto).Size = xmov.c_AutoDestino.c_Largo
                                    xcmd.Parameters.AddWithValue("@concepto", xmov.c_Concepto.c_Texto).Size = xmov.c_Concepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_concepto", xmov.c_AutoConcepto.c_Texto).Size = xmov.c_AutoConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_concepto", xmov.c_CodigoConcepto.c_Texto).Size = xmov.c_CodigoConcepto.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    'Productos_Movimientos_Detalle
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaProducto.Prd_MovimientoDetalle.INSERT_PRODUCTOS_MOVIMIENTO_DETALLE
                                    xcmd.Parameters.AddWithValue("@auto_documento", xmov_dt.c_AutoDocumento.c_Texto).Size = xmov_dt.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_productos", xmov_dt.c_AutoProducto.c_Texto).Size = xmov_dt.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xmov_dt.c_CodigoProducto.c_Texto).Size = xmov_dt.c_CodigoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xmov_dt.c_NombreProducto.c_Texto).Size = xmov_dt.c_NombreProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad", xmov_dt.c_CantidadAjuste.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque", xmov_dt.c_EmpaqueUnidadMedida.c_Texto).Size = xmov_dt.c_EmpaqueUnidadMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto", xmov_dt.c_AutoItemMovimiento.c_Texto).Size = xmov_dt.c_AutoItemMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xmov_dt.c_Estatus.c_Texto).Size = xmov_dt.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xmov_dt.c_FechaMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo", xmov_dt.c_TipoMovimiento.c_Texto).Size = xmov_dt.c_TipoMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@decimales", xmov_dt.c_NumeroDecimalesExpresar.c_Texto).Size = xmov_dt.c_NumeroDecimalesExpresar.c_Largo
                                    xcmd.Parameters.AddWithValue("@contenido_empaque", xmov_dt.c_ContenidoEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xmov_dt.c_CantidadUnidadInventario.c_Valor)
                                    xcmd.Parameters.AddWithValue("@empaque_tipo", xmov_dt.c_EmpaqueTipo.c_Texto).Size = xmov_dt.c_EmpaqueTipo.c_Largo
                                    xcmd.Parameters.AddWithValue("@categoria", xmov_dt.c_CategoriaProducto.c_Texto).Size = xmov_dt.c_CategoriaProducto.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL REGISTRAR MOVIMIENTO" + vbCrLf + "PRODUCTO/DEPOSITO/CONCEPTO FUE EILIMINADO POR OTRO USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS MOVIMIENTO INVENTARIO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_MOVIMIENTOS_DETALLE
            ''' </summary>
            Public Class Prd_MovimientoDetalle
                Class c_Registro
                    Private f_auto_documento As CampoTexto
                    Private f_auto_productos As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_cantidad As CampoDecimal
                    Private f_empaque As CampoTexto
                    Private f_auto As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_tipo As CampoTexto
                    Private f_decimales As CampoTexto
                    Private f_contenido_empaque As CampoInteger
                    Private f_cantidad_inventario As CampoDecimal
                    Private f_empaque_tipo As CampoTexto
                    Private f_categoria As CampoTexto

                    Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_productos
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_productos = value
                        End Set
                    End Property

                    Property c_CodigoProducto() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    Property c_NombreProducto() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    Property c_CantidadAjuste() As CampoDecimal
                        Get
                            Return f_cantidad
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad = value
                        End Set
                    End Property

                    Property c_EmpaqueUnidadMedida() As CampoTexto
                        Get
                            Return f_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque = value
                        End Set
                    End Property

                    Property c_AutoItemMovimiento() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
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

                    Property c_FechaMovimiento() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_TipoMovimiento() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    Property c_NumeroDecimalesExpresar() As CampoTexto
                        Get
                            Return f_decimales
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_decimales = value
                        End Set
                    End Property

                    Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenido_empaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Indica La Cantidad Ajuste Expresada en Unidades de Inventario
                    ''' </summary>
                    Property c_CantidadUnidadInventario() As CampoDecimal
                        Get
                            Return f_cantidad_inventario
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_cantidad_inventario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Indica El Tipo De Empaque Usado Para El Ajuste: 1:Compra, 2:Venta Detal
                    ''' </summary>
                    Property c_EmpaqueTipo() As CampoTexto
                        Get
                            Return f_empaque_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque_tipo = value
                        End Set
                    End Property

                    Property c_CategoriaProducto() As CampoTexto
                        Get
                            Return f_categoria
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_categoria = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoProducto() As String
                        Get
                            Return c_CodigoProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreProducto() As String
                        Get
                            Return c_NombreProducto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadAjuste() As Decimal
                        Get
                            Return c_CantidadAjuste.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EmpaqueUnidadMedida() As String
                        Get
                            Return c_EmpaqueUnidadMedida.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoItemMovimiento() As String
                        Get
                            Return c_AutoItemMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Inactivo
                            Else
                                Return TipoEstatus.Activo
                            End If
                        End Get
                    End Property

                    ReadOnly Property _FechaMovimiento() As Date
                        Get
                            Return c_FechaMovimiento.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoMovimiento() As String
                        Get
                            Return c_TipoMovimiento.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NumeroDecimalesExpresar() As Integer
                        Get
                            Dim x As Integer = 0
                            Integer.TryParse(Me.c_NumeroDecimalesExpresar.c_Texto.Trim, x)

                            Return x
                        End Get
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _CantidadUnidadInventario() As Decimal
                        Get
                            Return c_CantidadUnidadInventario.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EmpaqueTipo() As String
                        Get
                            Return c_EmpaqueTipo.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CategoriaProducto() As String
                        Get
                            Return c_CategoriaProducto.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        Me.c_AutoItemMovimiento = New CampoTexto(10, "auto")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_productos")
                        Me.c_CantidadAjuste = New CampoDecimal("cantidad")
                        Me.c_CantidadUnidadInventario = New CampoDecimal("cantidad_inventario")
                        Me.c_CategoriaProducto = New CampoTexto(20, "categoria")
                        Me.c_CodigoProducto = New CampoTexto(15, "codigo")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenido_empaque")
                        Me.c_EmpaqueTipo = New CampoTexto(1, "empaque_tipo")
                        Me.c_EmpaqueUnidadMedida = New CampoTexto(15, "empaque")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_FechaMovimiento = New CampoFecha("fecha")
                        Me.c_NombreProducto = New CampoTexto(200, "nombre")
                        Me.c_NumeroDecimalesExpresar = New CampoTexto(1, "decimales")
                        Me.c_TipoMovimiento = New CampoTexto(2, "tipo")

                        LimpiarRegistro()
                    End Sub
                End Class

                Protected Friend Const INSERT_PRODUCTOS_MOVIMIENTO_DETALLE As String = "insert into productos_movimientos_detalle ( " _
                                     + "auto_documento " _
                                     + ",auto_productos " _
                                     + ",codigo " _
                                     + ",nombre " _
                                     + ",cantidad " _
                                     + ",empaque " _
                                     + ",auto " _
                                     + ",estatus " _
                                     + ",fecha " _
                                     + ",tipo " _
                                     + ",decimales " _
                                     + ",contenido_empaque " _
                                     + ",cantidad_inventario " _
                                     + ",empaque_tipo " _
                                     + ",categoria ) " _
                                     + "values ( " _
                                     + "@auto_documento " _
                                     + ",@auto_productos " _
                                     + ",@codigo " _
                                     + ",@nombre " _
                                     + ",@cantidad " _
                                     + ",@empaque " _
                                     + ",@auto " _
                                     + ",@estatus " _
                                     + ",@fecha " _
                                     + ",@tipo " _
                                     + ",@decimales " _
                                     + ",@contenido_empaque " _
                                     + ",@cantidad_inventario " _
                                     + ",@empaque_tipo " _
                                     + ",@categoria ) "

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
            End Class

            ''' <summary>
            ''' CLASE PRODUCTOS_HISTORICO_COSTOS
            ''' </summary>
            Public Class Prd_HistoricoCostos
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_auto_documento As CampoTexto
                    Private f_auto_producto As CampoTexto
                    Private f_auto_usuario As CampoTexto
                    Private f_auto_entidad As CampoTexto
                    Private f_codigo_usuario As CampoTexto
                    Private f_contenido_empaque As CampoInteger
                    Private f_costo As CampoDecimal
                    Private f_costo_actual As CampoDecimal
                    Private f_costo_nuevo As CampoDecimal
                    Private f_empaque As CampoTexto
                    Private f_entidad As CampoTexto
                    Private f_estacion As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha_carga As CampoFecha
                    Private f_fecha_emision As CampoFecha
                    Private f_hora As CampoTexto
                    Private f_nota As CampoTexto
                    Private f_origen As CampoTexto
                    Private f_usuario As CampoTexto
                    Private f_documento As CampoTexto

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return Me.c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoEntidad() As CampoTexto
                        Get
                            Return f_auto_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEntidad() As String
                        Get
                            Return Me.c_AutoEntidad.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoProducto() As CampoTexto
                        Get
                            Return f_auto_producto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_producto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoProducto() As String
                        Get
                            Return Me.c_AutoProducto.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_AutoUsuario() As CampoTexto
                        Get
                            Return f_auto_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return Me.c_AutoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_CodigoUsuario() As CampoTexto
                        Get
                            Return f_codigo_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoUsuario() As String
                        Get
                            Return Me.c_CodigoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_ContenidoEmpaque() As CampoInteger
                        Get
                            Return f_contenido_empaque
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_contenido_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _ContenidoEmpaque() As Integer
                        Get
                            Return Me.c_ContenidoEmpaque.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_CostoReferencia() As CampoDecimal
                        Get
                            Return f_costo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo = value
                        End Set
                    End Property

                    ReadOnly Property _CostoReferencia() As Decimal
                        Get
                            Return Me.c_CostoReferencia.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_CostoActual() As CampoDecimal
                        Get
                            Return f_costo_actual
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo_actual = value
                        End Set
                    End Property

                    ReadOnly Property _CostoActual() As Decimal
                        Get
                            Return Me.c_CostoActual.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_CostoNuevo() As CampoDecimal
                        Get
                            Return f_costo_nuevo
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_costo_nuevo = value
                        End Set
                    End Property

                    ReadOnly Property _CostoNuevo() As Decimal
                        Get
                            Return Me.c_CostoNuevo.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Empaque() As CampoTexto
                        Get
                            Return f_empaque
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_empaque = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEmpaque() As String
                        Get
                            Return Me.c_Empaque.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Entidad() As CampoTexto
                        Get
                            Return f_entidad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_entidad = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEntidad() As String
                        Get
                            Return Me.c_Entidad.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_NombreEstacionEquipo() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _NombreEquipoEstacion() As String
                        Get
                            Return Me.c_NombreEstacionEquipo.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _EstatusDocumento() As TipoEstatus
                        Get
                            Select Case Me.c_Estatus.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEstatus.Activo
                                Case "1" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property

                    Protected Friend Property c_FechaProceso() As CampoFecha
                        Get
                            Return f_fecha_carga
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_carga = value
                        End Set
                    End Property

                    ReadOnly Property _FechaProceso() As Date
                        Get
                            Return Me.c_FechaProceso.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha_emision
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_emision = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return Me.c_FechaEmision.c_Valor
                        End Get
                    End Property

                    Protected Friend Property c_Hora() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _HoraMovimiento() As String
                        Get
                            Return Me.c_Hora.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Nota() As CampoTexto
                        Get
                            Return f_nota
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nota = value
                        End Set
                    End Property

                    ReadOnly Property _NotasDetalle() As String
                        Get
                            Return Me.c_Nota.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Origen() As CampoTexto
                        Get
                            Return f_origen
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_origen = value
                        End Set
                    End Property

                    ReadOnly Property _OrigenMovimiento() As String
                        Get
                            Return Me.c_Origen.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Usuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_Usuario.c_Texto.Trim
                        End Get
                    End Property

                    Protected Friend Property c_Documento() As CampoTexto
                        Get
                            Return Me.f_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            Me.f_documento = value
                        End Set
                    End Property

                    ReadOnly Property _DocumentoNumero() As String
                        Get
                            Return Me.c_Documento.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_Automatico = New CampoTexto(10, "auto")
                        Me.c_AutoDocumento = New CampoTexto(10, "auto_documento")
                        Me.c_AutoProducto = New CampoTexto(10, "auto_producto")
                        Me.c_AutoUsuario = New CampoTexto(10, "auto_usuario")
                        Me.c_AutoEntidad = New CampoTexto(10, "auto_entidad")
                        Me.c_CodigoUsuario = New CampoTexto(10, "codigo_usuario")
                        Me.c_ContenidoEmpaque = New CampoInteger("contenido_empaque")
                        Me.c_CostoReferencia = New CampoDecimal("costo")
                        Me.c_CostoActual = New CampoDecimal("costo_actual")
                        Me.c_CostoNuevo = New CampoDecimal("costo_nuevo")
                        Me.c_Empaque = New CampoTexto(15, "empaque")
                        Me.c_Entidad = New CampoTexto(120, "entidad")
                        Me.c_NombreEstacionEquipo = New CampoTexto(20, "estacion")
                        Me.c_Estatus = New CampoTexto(1, "estatus")
                        Me.c_FechaProceso = New CampoFecha("fecha_carga")
                        Me.c_FechaEmision = New CampoFecha("fecha_emision")
                        Me.c_Hora = New CampoTexto(10, "hora")
                        Me.c_Nota = New CampoTexto(40, "nota")
                        Me.c_Origen = New CampoTexto(4, "origen")
                        Me.c_Usuario = New CampoTexto(20, "usuario")
                        Me.c_Documento = New CampoTexto(15, "documento")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                LimpiarRegistro()

                                .c_AutoDocumento.c_Texto = xrow(.c_AutoDocumento.c_NombreInterno)
                                .c_AutoEntidad.c_Texto = xrow(.c_AutoEntidad.c_NombreInterno)
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_AutoProducto.c_Texto = xrow(.c_AutoProducto.c_NombreInterno)
                                .c_AutoUsuario.c_Texto = xrow(.c_AutoUsuario.c_NombreInterno)
                                .c_CodigoUsuario.c_Texto = xrow(.c_CodigoUsuario.c_NombreInterno)
                                .c_ContenidoEmpaque.c_Valor = xrow(.c_ContenidoEmpaque.c_NombreInterno)
                                .c_CostoActual.c_Valor = xrow(.c_CostoActual.c_NombreInterno)
                                .c_CostoNuevo.c_Valor = xrow(.c_CostoNuevo.c_NombreInterno)
                                .c_CostoReferencia.c_Valor = xrow(.c_CostoReferencia.c_NombreInterno)
                                .c_Empaque.c_Texto = xrow(.c_Empaque.c_NombreInterno)
                                .c_Entidad.c_Texto = xrow(.c_Entidad.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_FechaProceso.c_Valor = xrow(.c_FechaProceso.c_NombreInterno)
                                .c_Hora.c_Texto = xrow(.c_Hora.c_NombreInterno)
                                .c_NombreEstacionEquipo.c_Texto = xrow(.c_NombreEstacionEquipo.c_NombreInterno)
                                .c_Nota.c_Texto = xrow(.c_Nota.c_NombreInterno)
                                .c_Origen.c_Texto = xrow(.c_Origen.c_NombreInterno)
                                .c_Usuario.c_Texto = xrow(.c_Usuario.c_NombreInterno)
                                .c_Documento.c_Texto = xrow(.c_Documento.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("PRODUCTOS HISTORICO COSTO:" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const INSERT_PRODUCTOS_HISTORICO_COSTOS = "INSERT INTO productos_historico_costos(" _
                                                     + "auto," _
                                                     + "auto_documento," _
                                                     + "auto_entidad," _
                                                     + "auto_producto," _
                                                     + "auto_usuario," _
                                                     + "codigo_usuario," _
                                                     + "contenido_empaque," _
                                                     + "costo," _
                                                     + "costo_actual," _
                                                     + "costo_nuevo," _
                                                     + "fecha_carga," _
                                                     + "fecha_emision," _
                                                     + "empaque," _
                                                     + "entidad," _
                                                     + "estacion," _
                                                     + "estatus," _
                                                     + "hora, " _
                                                     + "nota," _
                                                     + "origen," _
                                                     + "usuario," _
                                                     + "documento) " _
                                                     + "VALUES(" _
                                                     + "@auto," _
                                                     + "@auto_documento," _
                                                     + "@auto_entidad," _
                                                     + "@auto_producto," _
                                                     + "@auto_usuario," _
                                                     + "@codigo_usuario," _
                                                     + "@contenido_empaque," _
                                                     + "@costo," _
                                                     + "@costo_actual," _
                                                     + "@costo_nuevo," _
                                                     + "@fecha_carga," _
                                                     + "@fecha_emision," _
                                                     + "@empaque," _
                                                     + "@entidad," _
                                                     + "@estacion," _
                                                     + "@estatus," _
                                                     + "@hora, " _
                                                     + "@nota," _
                                                     + "@origen," _
                                                     + "@usuario," _
                                                     + "@documento)"

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


            '
            '
            '

            Private xproducto As Prd_Producto
            Private xdepartamento As Prd_Departamento
            Private xgrupo As Prd_Grupo
            Private xmarca As Prd_Marca
            Private xconcepto As Prd_Concepto
            Private xsubgrupo As Prd_SubGrupo
            Private xalterno As Prd_Alterno
            Private xproveedor As Prd_Proveedor
            Private xmedida As Prd_Medida
            Private xdeposito As Prd_Deposito
            Private xempaque As Prd_Empaque
            Private xmovimiento As Prd_Movimiento
            Private xmovimientodetalle As Prd_MovimientoDetalle
            Private xhistoricocosto As Prd_HistoricoCostos
            Private xhistoricoprecio As Prd_HistoricoPrecios
            Private xkardex As Prd_Kardex

            ''' <summary>
            ''' Ficha Productos
            ''' </summary>
            Property f_PrdProducto() As Prd_Producto
                Get
                    Return xproducto
                End Get
                Set(ByVal value As Prd_Producto)
                    xproducto = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Departamento
            ''' </summary>
            Property f_PrdDepartamento() As Prd_Departamento
                Get
                    Return xdepartamento
                End Get
                Set(ByVal value As Prd_Departamento)
                    xdepartamento = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Grupo
            ''' </summary>
            Property f_PrdGrupo() As Prd_Grupo
                Get
                    Return xgrupo
                End Get
                Set(ByVal value As Prd_Grupo)
                    xgrupo = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Marca
            ''' </summary>
            Property f_PrdMarca() As Prd_Marca
                Get
                    Return xmarca
                End Get
                Set(ByVal value As Prd_Marca)
                    xmarca = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Conceptos
            ''' </summary>
            Property f_PrdConcepto() As Prd_Concepto
                Get
                    Return xconcepto
                End Get
                Set(ByVal value As Prd_Concepto)
                    xconcepto = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_SubGrupo
            ''' </summary>
            Property f_PrdSubGrupo() As Prd_SubGrupo
                Get
                    Return xsubgrupo
                End Get
                Set(ByVal value As Prd_SubGrupo)
                    xsubgrupo = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Alterno
            ''' </summary>
            Property f_PrdAlterno() As Prd_Alterno
                Get
                    Return xalterno
                End Get
                Set(ByVal value As Prd_Alterno)
                    xalterno = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Proveedor
            ''' </summary>
            Property f_PrdProveedor() As Prd_Proveedor
                Get
                    Return xproveedor
                End Get
                Set(ByVal value As Prd_Proveedor)
                    xproveedor = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Medida
            ''' </summary>
            Property f_PrdMedida() As Prd_Medida
                Get
                    Return xmedida
                End Get
                Set(ByVal value As Prd_Medida)
                    xmedida = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Deposito
            ''' </summary>
            Property f_PrdDeposito() As Prd_Deposito
                Get
                    Return xdeposito
                End Get
                Set(ByVal value As Prd_Deposito)
                    xdeposito = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Empaque
            ''' </summary>
            Property f_PrdEmpaque() As Prd_Empaque
                Get
                    Return xempaque
                End Get
                Set(ByVal value As Prd_Empaque)
                    xempaque = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Movimiento
            ''' </summary>
            Property f_PrdMovimiento() As Prd_Movimiento
                Get
                    Return xmovimiento
                End Get
                Set(ByVal value As Prd_Movimiento)
                    xmovimiento = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_Movimiento_Detalle
            ''' </summary>
            Property f_PrdMovimientoDetalle() As Prd_MovimientoDetalle
                Get
                    Return xmovimientodetalle
                End Get
                Set(ByVal value As Prd_MovimientoDetalle)
                    xmovimientodetalle = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_HistoricoPrecios
            ''' </summary>
            Property f_PrdHistoricoPrecios() As Prd_HistoricoPrecios
                Get
                    Return xhistoricoprecio
                End Get
                Set(ByVal value As Prd_HistoricoPrecios)
                    xhistoricoprecio = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_HistoricoCostos
            ''' </summary>
            Property f_PrdHistoricoCosto() As Prd_HistoricoCostos
                Get
                    Return xhistoricocosto
                End Get
                Set(ByVal value As Prd_HistoricoCostos)
                    xhistoricocosto = value
                End Set
            End Property

            ''' <summary>
            ''' Ficha Productos_HistoricoPrecios
            ''' </summary>
            Property f_PrdKardex() As Prd_Kardex
                Get
                    Return xkardex
                End Get
                Set(ByVal value As Prd_Kardex)
                    xkardex = value
                End Set
            End Property


            Sub New()
                f_PrdProducto = New Prd_Producto
                f_PrdDepartamento = New Prd_Departamento
                f_PrdGrupo = New Prd_Grupo
                f_PrdMarca = New Prd_Marca
                f_PrdConcepto = New Prd_Concepto
                f_PrdSubGrupo = New Prd_SubGrupo
                f_PrdAlterno = New Prd_Alterno
                f_PrdProveedor = New Prd_Proveedor
                f_PrdMedida = New Prd_Medida
                f_PrdDeposito = New Prd_Deposito
                f_PrdEmpaque = New Prd_Empaque
                f_PrdMovimiento = New Prd_Movimiento
                f_PrdMovimientoDetalle = New Prd_MovimientoDetalle
                f_PrdKardex = New Prd_Kardex
                f_PrdHistoricoCosto = New Prd_HistoricoCostos
                f_PrdHistoricoPrecios = New Prd_HistoricoPrecios
            End Sub
        End Class

        Private xfichaProducto As FichaProducto

        ''' <summary>
        ''' Ficha General Productos
        ''' </summary>
        Property f_FichaProducto() As FichaProducto
            Get
                Return xfichaProducto
            End Get
            Set(ByVal value As FichaProducto)
                xfichaProducto = value
            End Set
        End Property
    End Class
End Namespace


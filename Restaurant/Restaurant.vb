Imports System.Data.SqlClient
Imports ImpFiscales.MisFiscales
Imports DataSistema.MiDataSistema.DataSistema.PosOnline

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class Restaurant
            Event _PlatoMesaAgregado(ByVal xautomonitor As String)
            Event _PlatoPedidoAgregado(ByVal xpedido As String)
            Event _CuentaAnuladaOk()
            Event _CambioMesaOK(ByVal xmesadest As String)
            Event _TrasladoPedidoOk(ByVal xmonitor As MonitorMesas.c_Registro)
            Event _DevolucionOk(ByVal xmesapedido As String)
            Event _IncrementoItemOk(ByVal xmesapedido As String)
            Event _NotasActualizadas()
            Event _HistorialComandaLista(ByVal xlista As List(Of HistorialComandas.c_Registro))
            Event _HistorialComandaOK()
            Event _FacturaGrabadaOk()
            Event _ImprimirFacturaChimba(ByVal auto_doc As String)
            Event _VisorCambioDar(ByVal xmonto As Decimal)
            Event _UnionOk(ByVal xmesadest As String)
            Event _IdMesaActualizado()


            Private xtmpventamesa As TemporalVentasMesas
            Private xdevanulacion As DevolucionAnulacion
            Private xmonitormesa As MonitorMesas
            Private xhistorial As HistorialComandas
            Private xctamovil As CtaMesaMovil


            Property F_TemporalVentaMesa() As TemporalVentasMesas
                Get
                    Return xtmpventamesa
                End Get
                Set(ByVal value As TemporalVentasMesas)
                    xtmpventamesa = value
                End Set
            End Property

            Property F_DevAnulacion() As DevolucionAnulacion
                Get
                    Return xdevanulacion
                End Get
                Set(ByVal value As DevolucionAnulacion)
                    xdevanulacion = value
                End Set
            End Property

            Property F_MonitorMesas() As MonitorMesas
                Get
                    Return Me.xmonitormesa
                End Get
                Set(ByVal value As MonitorMesas)
                    Me.xmonitormesa = value
                End Set
            End Property

            Property F_HistorialComandas() As HistorialComandas
                Get
                    Return Me.xhistorial
                End Get
                Set(ByVal value As HistorialComandas)
                    Me.xhistorial = value
                End Set
            End Property

            Property F_CtaMesaMovil() As CtaMesaMovil
                Get
                    Return Me.xctamovil
                End Get
                Set(ByVal value As CtaMesaMovil)
                    Me.xctamovil = value
                End Set
            End Property


            Sub New()
                F_TemporalVentaMesa = New TemporalVentasMesas
                F_DevAnulacion = New DevolucionAnulacion
                F_MonitorMesas = New MonitorMesas
                F_HistorialComandas = New HistorialComandas
                F_CtaMesaMovil = New CtaMesaMovil
            End Sub


            Enum ModoFactura As Integer
                Legal = 1
                Chimba = 2
            End Enum

            Class AgregarItemMesa
                Private xFichaPlato As FastFood.Platos.c_Registro
                Private xFichaMesonero As FichaVendedores.c_Vendedor.c_Registro
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xMesa As String
                Private xequipo As String
                Private xcantidad As Decimal
                Private xcnf_oferta As Boolean
                Private xcnf_precio As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar
                Private xautomonitormesa As String
                Private xdetalle As String
                Private xunida As String

                Property _FichaPlato() As FastFood.Platos.c_Registro
                    Get
                        Return Me.xFichaPlato
                    End Get
                    Set(ByVal value As FastFood.Platos.c_Registro)
                        Me.xFichaPlato = value
                    End Set
                End Property

                Property _FichaMesonero() As FichaVendedores.c_Vendedor.c_Registro
                    Get
                        Return Me.xFichaMesonero
                    End Get
                    Set(ByVal value As FichaVendedores.c_Vendedor.c_Registro)
                        Me.xFichaMesonero = value
                    End Set
                End Property

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _Mesa() As String
                    Get
                        Return Me.xMesa
                    End Get
                    Set(ByVal value As String)
                        Me.xMesa = value
                    End Set
                End Property

                Property _Unida() As String
                    Get
                        Return Me.xunida
                    End Get
                    Set(ByVal value As String)
                        Me.xunida = value
                    End Set
                End Property

                Property _CantDespachar() As Decimal
                    Get
                        Return Me.xcantidad
                    End Get
                    Set(ByVal value As Decimal)
                        Me.xcantidad = value
                    End Set
                End Property

                Property _EquipoEstacion() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Property _EstatusConfiguracion_Oferta() As Boolean
                    Get
                        Return Me.xcnf_oferta
                    End Get
                    Set(ByVal value As Boolean)
                        Me.xcnf_oferta = value
                    End Set
                End Property

                Property _EstatusConfiguracion_PrecioSeleccionado() As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar
                    Get
                        Return Me.xcnf_precio
                    End Get
                    Set(ByVal value As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar)
                        Me.xcnf_precio = value
                    End Set
                End Property

                Property _AutoMonitorMesa() As String
                    Get
                        Return Me.xautomonitormesa
                    End Get
                    Set(ByVal value As String)
                        Me.xautomonitormesa = value
                    End Set
                End Property

                Property _DetallePlato() As String
                    Get
                        Return xdetalle
                    End Get
                    Set(ByVal value As String)
                        xdetalle = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()")
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As Date
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property

                Protected Friend ReadOnly Property _CostoTotalNeto() As Decimal
                    Get
                        Dim x As Decimal = 0
                        x = Decimal.Round(_FichaPlato._CostoPlato * _CantDespachar, 2, MidpointRounding.AwayFromZero)
                        Return x
                    End Get
                End Property

                Protected Friend ReadOnly Property _EstatusEnviado() As String
                    Get
                        Return "0"
                    End Get
                End Property

                Protected Friend ReadOnly Property _Llevar() As String
                    Get
                        Return "0"
                    End Get
                End Property

                Protected Friend ReadOnly Property _Importe() As Decimal
                    Get
                        Dim x As Decimal = 0
                        x = Decimal.Round(Me._PrecioNeto._Base * Me._CantDespachar, 2, MidpointRounding.AwayFromZero)
                        Return x
                    End Get
                End Property

                Protected Friend ReadOnly Property _PrecioNeto() As Precio
                    Get
                        Return Me._FichaPlato._PrecioAFacturar_Restaurant(Me._EstatusConfiguracion_Oferta, Me._EstatusConfiguracion_PrecioSeleccionado)
                    End Get
                End Property

                Protected Friend ReadOnly Property _PrecioSeleccionado() As FastFood.TipoPrecioFastFood
                    Get
                        Return Me._FichaPlato._PrecioAFacturar_Seleccionado
                    End Get
                End Property

                Sub New()
                    Me._CantDespachar = 0
                    Me._EquipoEstacion = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaPlato = Nothing
                    Me._FichaUsuario = Nothing
                    Me._FichaMesonero = Nothing
                    Me._Mesa = ""
                    Me._Unida = ""
                    Me._EstatusConfiguracion_PrecioSeleccionado = FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar.Precio_1
                    Me._EstatusConfiguracion_Oferta = True
                    Me._AutoMonitorMesa = ""
                    Me._DetallePlato = ""
                End Sub
            End Class
            Class AgregarItemPedido
                Private xFichaPlato As FastFood.Platos.c_Registro
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xMesa As String
                Private xequipo As String
                Private xcantidad As Decimal
                Private xcnf_oferta As Boolean
                Private xcnf_precio As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar
                Private xdetalle As String


                Property _FichaPlato() As FastFood.Platos.c_Registro
                    Get
                        Return Me.xFichaPlato
                    End Get
                    Set(ByVal value As FastFood.Platos.c_Registro)
                        Me.xFichaPlato = value
                    End Set
                End Property

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _Mesa() As String
                    Get
                        Return Me.xMesa
                    End Get
                    Set(ByVal value As String)
                        Me.xMesa = value
                    End Set
                End Property

                Property _CantDespachar() As Decimal
                    Get
                        Return Me.xcantidad
                    End Get
                    Set(ByVal value As Decimal)
                        Me.xcantidad = value
                    End Set
                End Property

                Property _EquipoEstacion() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Property _EstatusConfiguracion_Oferta() As Boolean
                    Get
                        Return Me.xcnf_oferta
                    End Get
                    Set(ByVal value As Boolean)
                        Me.xcnf_oferta = value
                    End Set
                End Property

                Property _EstatusConfiguracion_PrecioSeleccionado() As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar
                    Get
                        Return Me.xcnf_precio
                    End Get
                    Set(ByVal value As FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar)
                        Me.xcnf_precio = value
                    End Set
                End Property

                Property _Detalle() As String
                    Get
                        Return xdetalle
                    End Get
                    Set(ByVal value As String)
                        xdetalle = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()")
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As Date
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property

                Protected Friend ReadOnly Property _CostoTotalNeto() As Decimal
                    Get
                        Dim x As Decimal = 0
                        x = Decimal.Round(_FichaPlato._CostoPlato * _CantDespachar, 2, MidpointRounding.AwayFromZero)
                        Return x
                    End Get
                End Property

                Protected Friend ReadOnly Property _EstatusEnviado() As String
                    Get
                        Return "0"
                    End Get
                End Property

                Protected Friend ReadOnly Property _Llevar() As String
                    Get
                        Return "1"
                    End Get
                End Property

                Protected Friend ReadOnly Property _Unida() As String
                    Get
                        Return ""
                    End Get
                End Property

                Protected Friend ReadOnly Property _Importe() As Decimal
                    Get
                        Dim x As Decimal = 0
                        x = Decimal.Round(Me._PrecioNeto._Base * Me._CantDespachar, 2, MidpointRounding.AwayFromZero)
                        Return x
                    End Get
                End Property

                Protected Friend ReadOnly Property _PrecioNeto() As Precio
                    Get
                        Return Me._FichaPlato._PrecioAFacturar_Restaurant(Me._EstatusConfiguracion_Oferta, Me._EstatusConfiguracion_PrecioSeleccionado)
                    End Get
                End Property

                Protected Friend ReadOnly Property _PrecioSeleccionado() As FastFood.TipoPrecioFastFood
                    Get
                        Return Me._FichaPlato._PrecioAFacturar_Seleccionado
                    End Get
                End Property

                Protected Friend ReadOnly Property _AutoCodigoNombreMesonero() As String
                    Get
                        Return ""
                    End Get
                End Property

                Protected Friend ReadOnly Property _AutoMonitorMesa() As String
                    Get
                        Return ""
                    End Get
                End Property


                Sub New()
                    Me._CantDespachar = 0
                    Me._EquipoEstacion = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaPlato = Nothing
                    Me._FichaUsuario = Nothing
                    Me._Mesa = ""
                    Me._EstatusConfiguracion_PrecioSeleccionado = FichaGlobal.c_ConfSistema.ConfRestaurant.PrecioFacturar.Precio_1
                    Me._EstatusConfiguracion_Oferta = True
                    Me._Detalle = ""
                End Sub
            End Class
            Class AgregarAnulacion
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xequipo As String
                Private xmotivo As String
                Private xtipoanulacion As TipoAnulacion
                Private xnivelclave As NivelClave
                Private xmesa As String
                Private xautomonitormesa As String
                Private xtipopedidomesa As Restaurant.TipoPedido

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _Equipo() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Property _Motivo() As String
                    Get
                        Return Me.xmotivo
                    End Get
                    Set(ByVal value As String)
                        Me.xmotivo = value
                    End Set
                End Property

                Property _NivelClaveUsada() As NivelClave
                    Get
                        Return Me.xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        Me.xnivelclave = value
                    End Set
                End Property

                Property _TipoAnulacion() As TipoAnulacion
                    Get
                        Return Me.xtipoanulacion
                    End Get
                    Set(ByVal value As TipoAnulacion)
                        Me.xtipoanulacion = value
                    End Set
                End Property

                Property _Mesa() As String
                    Get
                        Return Me.xmesa
                    End Get
                    Set(ByVal value As String)
                        Me.xmesa = value
                    End Set
                End Property

                Property _AutoMonitorMesa() As String
                    Get
                        Return Me.xautomonitormesa
                    End Get
                    Set(ByVal value As String)
                        Me.xautomonitormesa = value
                    End Set
                End Property

                Property _TipoPedidoMesa() As Restaurant.TipoPedido
                    Get
                        Return Me.xtipopedidomesa
                    End Get
                    Set(ByVal value As Restaurant.TipoPedido)
                        Me.xtipopedidomesa = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property


                Sub New()
                    Me._AutoMonitorMesa = ""
                    Me._Equipo = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._Mesa = ""
                    Me._Motivo = ""
                    Me._NivelClaveUsada = NivelClave.SinClave
                    Me._TipoAnulacion = TipoAnulacion.Anulacion
                    Me._TipoPedidoMesa = TipoPedido.ParaMesa
                End Sub
            End Class
            Class AgregarCambioMesa
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xequipo As String
                Private xmotivo As String
                Private xnivelclave As NivelClave
                Private xmesa_inicio As String
                Private xmesa_final As String
                Private xtipomov As TipoMovimientoMesa
                Private xautomonitormesa As String

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _Equipo() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Property _Motivo() As String
                    Get
                        Return Me.xmotivo
                    End Get
                    Set(ByVal value As String)
                        Me.xmotivo = value
                    End Set
                End Property

                Property _NivelClaveUsada() As NivelClave
                    Get
                        Return Me.xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        Me.xnivelclave = value
                    End Set
                End Property

                Property _MesaInicio() As String
                    Get
                        Return Me.xmesa_inicio
                    End Get
                    Set(ByVal value As String)
                        Me.xmesa_inicio = value
                    End Set
                End Property

                Property _MesaDestino() As String
                    Get
                        Return Me.xmesa_final
                    End Get
                    Set(ByVal value As String)
                        Me.xmesa_final = value
                    End Set
                End Property

                Property _TipoMovimiento() As TipoMovimientoMesa
                    Get
                        Return Me.xtipomov
                    End Get
                    Set(ByVal value As TipoMovimientoMesa)
                        Me.xtipomov = value
                    End Set
                End Property

                Property _AutoMonitorMesa() As String
                    Get
                        Return Me.xautomonitormesa
                    End Get
                    Set(ByVal value As String)
                        Me.xautomonitormesa = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property


                Sub New()
                    Me._AutoMonitorMesa = ""
                    Me._Equipo = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._MesaDestino = ""
                    Me._MesaInicio = ""
                    Me._Motivo = ""
                    Me._NivelClaveUsada = NivelClave.SinClave
                    Me._TipoMovimiento = TipoMovimientoMesa.PorCambio
                End Sub
            End Class
            Class AgregarTrasladoMesa
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xequipo As String
                Private xnivelclave As NivelClave
                Private xpedido As String
                Private xmesa_final As String

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _Equipo() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Motivo() As String
                    Get
                        Dim xpedido As Integer = 0
                        Dim xmesa As Integer = 0
                        Integer.TryParse(_Pedido, xpedido)
                        Integer.TryParse(_MesaDestino, xmesa)
                        Return "Traslado Pedido#(" + xpedido.ToString.Trim + ") A La Mesa#(" + xmesa.ToString.Trim + ")"
                    End Get
                End Property

                Property _NivelClaveUsada() As NivelClave
                    Get
                        Return Me.xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        Me.xnivelclave = value
                    End Set
                End Property

                Property _Pedido() As String
                    Get
                        Return Me.xpedido
                    End Get
                    Set(ByVal value As String)
                        Me.xpedido = value
                    End Set
                End Property

                Property _MesaDestino() As String
                    Get
                        Return Me.xmesa_final
                    End Get
                    Set(ByVal value As String)
                        Me.xmesa_final = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _TipoMovimiento() As TipoMovimientoMesa
                    Get
                        Return TipoMovimientoMesa.PorTraslado
                    End Get
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property


                Sub New()
                    Me._Equipo = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._MesaDestino = ""
                    Me._NivelClaveUsada = NivelClave.SinClave
                    Me._Pedido = ""
                End Sub
            End Class
            Class AgregarDevolucion
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xitem As TemporalVentasMesas.c_Registro
                Private xequipo As String
                Private xtipodev As TipoDevolucion
                Private xnivelclave As NivelClave

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _FichaItemDevolver() As TemporalVentasMesas.c_Registro
                    Get
                        Return Me.xitem
                    End Get
                    Set(ByVal value As TemporalVentasMesas.c_Registro)
                        Me.xitem = value
                    End Set
                End Property

                Property _Equipo() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Motivo() As String
                    Get
                        Return "POR DEVOLUCION"
                    End Get
                End Property

                Property _NivelClaveUsada() As NivelClave
                    Get
                        Return Me.xnivelclave
                    End Get
                    Set(ByVal value As NivelClave)
                        Me.xnivelclave = value
                    End Set
                End Property

                Property _TipoDevolucion() As TipoDevolucion
                    Get
                        Return Me.xtipodev
                    End Get
                    Set(ByVal value As TipoDevolucion)
                        Me.xtipodev = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property


                Sub New()
                    Me._Equipo = ""
                    Me._FichaItemDevolver = Nothing
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._NivelClaveUsada = NivelClave.SinClave
                    Me._TipoDevolucion = 0
                End Sub
            End Class
            Class ActualizarNotasItem
                Private xdetalle As String
                Private xitem As TemporalVentasMesas.c_Registro

                Property _NotasItem() As String
                    Get
                        Return xdetalle
                    End Get
                    Set(ByVal value As String)
                        xdetalle = value
                    End Set
                End Property

                Property _FichaItem() As TemporalVentasMesas.c_Registro
                    Get
                        Return xitem
                    End Get
                    Set(ByVal value As TemporalVentasMesas.c_Registro)
                        xitem = value
                    End Set
                End Property

                Sub New()
                    _NotasItem = ""
                    _FichaItem = Nothing
                End Sub
            End Class
            Class AgregarHistorialComanda
                Private xFichaUsuario As FichaGlobal.c_Usuario.c_Registro
                Private xFichaOperador As FastFood.OperadorJornada.c_Registro
                Private xFichaJornada As FastFood.Jornada.c_Registro
                Private xitem As List(Of TemporalVentasMesas.c_Registro)
                Private xequipo As String

                Property _FichaUsuario() As FichaGlobal.c_Usuario.c_Registro
                    Get
                        Return Me.xFichaUsuario
                    End Get
                    Set(ByVal value As FichaGlobal.c_Usuario.c_Registro)
                        Me.xFichaUsuario = value
                    End Set
                End Property

                Property _FichaOperador() As FastFood.OperadorJornada.c_Registro
                    Get
                        Return Me.xFichaOperador
                    End Get
                    Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                        Me.xFichaOperador = value
                    End Set
                End Property

                Property _FichaJornada() As FastFood.Jornada.c_Registro
                    Get
                        Return Me.xFichaJornada
                    End Get
                    Set(ByVal value As FastFood.Jornada.c_Registro)
                        Me.xFichaJornada = value
                    End Set
                End Property

                Property _ListaItems() As List(Of TemporalVentasMesas.c_Registro)
                    Get
                        Return Me.xitem
                    End Get
                    Set(ByVal value As List(Of TemporalVentasMesas.c_Registro))
                        Me.xitem = value
                    End Set
                End Property

                Property _Equipo() As String
                    Get
                        Return Me.xequipo
                    End Get
                    Set(ByVal value As String)
                        Me.xequipo = value
                    End Set
                End Property

                Protected Friend ReadOnly Property _Fecha() As Date
                    Get
                        Return F_GetDate("Select getdate()").Date
                    End Get
                End Property

                Protected Friend ReadOnly Property _Hora() As String
                    Get
                        Return F_GetDate("Select getdate()").ToShortTimeString
                    End Get
                End Property


                Sub New()
                    Me._Equipo = ""
                    Me._FichaJornada = Nothing
                    Me._FichaOperador = Nothing
                    Me._FichaUsuario = Nothing
                    Me._ListaItems = Nothing
                End Sub
            End Class
            Class AgregarVenta
                Class Encabezado
                    Enum TipoCondicionPago As Integer
                        Contado = 0
                        Credito = 1
                    End Enum

                    Private xcliente As FichaClientes.c_Clientes.c_Registro
                    Private xusuario As FichaGlobal.c_Usuario.c_Registro
                    Private xvendedor As FichaVendedores.c_Vendedor.c_Registro
                    Private xcobrador As FichaCobradores.c_Cobrador.c_Registro
                    Private xestacion As String
                    Private xrenglones As Integer
                    Private xsucursal As String
                    Private xbase1 As Decimal
                    Private xbase2 As Decimal
                    Private xbase3 As Decimal
                    Private xbase0 As Decimal
                    Private xtasa1 As Decimal
                    Private xtasa2 As Decimal
                    Private xtasa3 As Decimal
                    Private xtasadescuento As Decimal
                    Private xjornada As String
                    Private xoperador As String
                    Private xserie As String
                    Private xcondicion As TipoCondicionPago
                    Private xtotal As Decimal
                    Private xsubtotal As Decimal
                    Private xfactor As Decimal
                    Private xmonto_descuento_neto As Decimal
                    Private xmonto_cargo_neto As Decimal
                    Private xtasacargo As Decimal
                    Private xtasa_servicio As Decimal
                    Private xmonto_servicio As Decimal
                    Private xnumero_mesa_pedido As String
                    Private xtipo_mesa_pedido As TipoPedido
                    Private xautomonitor_mesa As String


                    Property _AutoMonitorMesa() As String
                        Get
                            Return Me.xautomonitor_mesa
                        End Get
                        Set(ByVal value As String)
                            Me.xautomonitor_mesa = value
                        End Set
                    End Property

                    Property _TasaServicio() As Decimal
                        Get
                            Return Me.xtasa_servicio
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xtasa_servicio = value
                        End Set
                    End Property

                    Property _MontoServicio() As Decimal
                        Get
                            Return Me.xmonto_servicio
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmonto_servicio = value
                        End Set
                    End Property

                    Property _NumeroMesaPedido() As String
                        Get
                            Return Me.xnumero_mesa_pedido
                        End Get
                        Set(ByVal value As String)
                            Me.xnumero_mesa_pedido = value
                        End Set
                    End Property

                    Property _TipoMesaPedido() As TipoPedido
                        Get
                            Return Me.xtipo_mesa_pedido
                        End Get
                        Set(ByVal value As TipoPedido)
                            Me.xtipo_mesa_pedido = value
                        End Set
                    End Property

                    Property _Cliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Return xcliente
                        End Get
                        Set(ByVal value As FichaClientes.c_Clientes.c_Registro)
                            xcliente = value
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

                    Property _Vendedor() As FichaVendedores.c_Vendedor.c_Registro
                        Get
                            Return xvendedor
                        End Get
                        Set(ByVal value As FichaVendedores.c_Vendedor.c_Registro)
                            xvendedor = value
                        End Set
                    End Property

                    Property _Cobrador() As FichaCobradores.c_Cobrador.c_Registro
                        Get
                            Return xcobrador
                        End Get
                        Set(ByVal value As FichaCobradores.c_Cobrador.c_Registro)
                            xcobrador = value
                        End Set
                    End Property

                    Property _EstacionEquipo() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
                        End Set
                    End Property

                    Property _Renglones() As Integer
                        Get
                            If _TipoMesaPedido = TipoPedido.ParaMesa Then
                                Return (xrenglones + 1)  ' INDICANDO EL SERVICIO QUE SE AGREGARA 
                            Else
                                Return xrenglones
                            End If
                        End Get
                        Set(ByVal value As Integer)
                            xrenglones = value
                        End Set
                    End Property

                    Property _Sucursal() As String
                        Get
                            Return xsucursal
                        End Get
                        Set(ByVal value As String)
                            xsucursal = value
                        End Set
                    End Property

                    Property _Exento() As Decimal
                        Get
                            Return xbase0
                        End Get
                        Set(ByVal value As Decimal)
                            xbase0 = value
                        End Set
                    End Property

                    Property _MontoBase1() As Decimal
                        Get
                            Return xbase1
                        End Get
                        Set(ByVal value As Decimal)
                            xbase1 = value
                        End Set
                    End Property

                    Property _MontoBase2() As Decimal
                        Get
                            Return xbase2
                        End Get
                        Set(ByVal value As Decimal)
                            xbase2 = value
                        End Set
                    End Property

                    Property _MontoBase3() As Decimal
                        Get
                            Return xbase3
                        End Get
                        Set(ByVal value As Decimal)
                            xbase3 = value
                        End Set
                    End Property

                    Property _TasaIva1() As Decimal
                        Get
                            Return xtasa1
                        End Get
                        Set(ByVal value As Decimal)
                            xtasa1 = value
                        End Set
                    End Property

                    Property _TasaIva2() As Decimal
                        Get
                            Return xtasa2
                        End Get
                        Set(ByVal value As Decimal)
                            xtasa2 = value
                        End Set
                    End Property

                    Property _TasaIva3() As Decimal
                        Get
                            Return xtasa3
                        End Get
                        Set(ByVal value As Decimal)
                            xtasa3 = value
                        End Set
                    End Property

                    Property _TasaDescuento() As Decimal
                        Get
                            Return xtasadescuento
                        End Get
                        Set(ByVal value As Decimal)
                            xtasadescuento = value
                        End Set
                    End Property

                    Property _Jornada() As String
                        Get
                            Return xjornada
                        End Get
                        Set(ByVal value As String)
                            xjornada = value
                        End Set
                    End Property

                    Property _Operador() As String
                        Get
                            Return xoperador
                        End Get
                        Set(ByVal value As String)
                            xoperador = value
                        End Set
                    End Property

                    Property _Serie() As String
                        Get
                            Return xserie
                        End Get
                        Set(ByVal value As String)
                            xserie = value
                        End Set
                    End Property

                    Property _CondicionPago() As TipoCondicionPago
                        Get
                            Return xcondicion
                        End Get
                        Set(ByVal value As TipoCondicionPago)
                            xcondicion = value
                        End Set
                    End Property

                    Property _TotalGeneral() As Decimal
                        Get
                            Return xtotal
                        End Get
                        Set(ByVal value As Decimal)
                            xtotal = value
                        End Set
                    End Property

                    Property _FactorCambio() As Decimal
                        Get
                            Return xfactor
                        End Get
                        Set(ByVal value As Decimal)
                            xfactor = value
                        End Set
                    End Property

                    Property _SubTotalGeneralSinDescuentoNiCargos() As Decimal
                        Get
                            Return xsubtotal
                        End Get
                        Set(ByVal value As Decimal)
                            xsubtotal = value
                        End Set
                    End Property

                    Property _MontoDescuentoNeto() As Decimal
                        Get
                            Return xmonto_descuento_neto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto_descuento_neto = value
                        End Set
                    End Property

                    Property _MontoCargoNeto() As Decimal
                        Get
                            Return xmonto_cargo_neto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto_cargo_neto = value
                        End Set
                    End Property

                    Property _TasaCargo() As Decimal
                        Get
                            Return xtasacargo
                        End Get
                        Set(ByVal value As Decimal)
                            xtasacargo = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaEmision() As Date
                        Get
                            Dim xv As Date = F_GetDate("select getdate()").Date
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = F_GetDate("select getdate()").ToShortTimeString
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _AnoRelacion() As String
                        Get
                            Return Year(_FechaEmision).ToString.Trim.PadLeft(4, "0")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Base() As Decimal
                        Get
                            Dim xv As Decimal = Decimal.Round(Me._MontoBase1 + Me._MontoBase2 + Me._MontoBase3, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _BloquearAlmacen() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _DiasCredito() As Integer
                        Get
                            If Me._CondicionPago = TipoCondicionPago.Contado Then
                                Return 0
                            Else
                                Return Me._Cliente.r_DiasCredito
                            End If
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Estatus() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _FechaVencimiento() As Date
                        Get
                            Return DateAdd(DateInterval.Day, _DiasCredito, _FechaEmision)
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Impuesto1() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            xv = Decimal.Round(Me._MontoBase1 * Me._TasaIva1 / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Impuesto2() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            xv = Decimal.Round(Me._MontoBase2 * Me._TasaIva2 / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Impuesto3() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            xv = Decimal.Round(Me._MontoBase3 * Me._TasaIva3 / 100, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Impuesto() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            xv = Decimal.Round(Me._Impuesto1 + Me._Impuesto2 + Me._Impuesto3, 2, MidpointRounding.AwayFromZero)
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _MesRelacion() As String
                        Get
                            Return Month(_FechaEmision).ToString.Trim.PadLeft(2, "0")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TipoDocumento() As String
                        Get
                            Return "01"
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _TipoColumna() As String
                        Get
                            Return "1"
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _MontoDivisa() As Decimal
                        Get
                            Dim xv As Decimal = 0
                            If _FactorCambio > 0 Then
                                xv = Decimal.Round(_TotalGeneral / _FactorCambio, 2, MidpointRounding.AwayFromZero)
                            End If
                            Return xv
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _SaldoPendiente() As Decimal
                        Get
                            If _CondicionPago = TipoCondicionPago.Contado Then
                                Return 0
                            Else
                                Return _TotalGeneral
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me._Cliente = Nothing
                        Me._Cobrador = Nothing
                        Me._CondicionPago = TipoCondicionPago.Contado
                        Me._EstacionEquipo = ""
                        Me._Exento = 0
                        Me._Jornada = ""
                        Me._MontoBase1 = 0
                        Me._MontoBase2 = 0
                        Me._MontoBase3 = 0
                        Me._MontoDescuentoNeto = 0
                        Me._Operador = ""
                        Me._Renglones = 0
                        Me._Serie = ""
                        Me._Sucursal = ""
                        Me._TasaDescuento = 0
                        Me._TasaIva1 = 0
                        Me._TasaIva2 = 0
                        Me._TasaIva3 = 0
                        Me._Usuario = Nothing
                        Me._Vendedor = Nothing
                        Me._FactorCambio = 0
                        Me._TotalGeneral = 0
                        Me._SubTotalGeneralSinDescuentoNiCargos = 0
                        Me._MontoCargoNeto = 0
                        Me._TasaCargo = 0

                        Me._TasaServicio = 0
                        Me._MontoServicio = 0
                        Me._TipoMesaPedido = TipoPedido.ParaMesa
                        Me._NumeroMesaPedido = ""
                        Me._AutoMonitorMesa = ""
                    End Sub
                End Class

                Private xfichadeposito As FichaGlobal.c_Depositos.c_Registro
                Private xencabezado As Encabezado
                Private xdetalles As List(Of TemporalVentasMesas.c_Registro)
                Private xtipocalculoutilidad As TipoCalculoUtilidad
                Private xmontorecibe As Decimal
                Private xtablapagos As DataTable

                Property _TablaModosPago() As DataTable
                    Get
                        Return xtablapagos
                    End Get
                    Set(ByVal value As DataTable)
                        xtablapagos = value
                    End Set
                End Property

                Property _MontoRecibido() As Decimal
                    Get
                        Return xmontorecibe
                    End Get
                    Set(ByVal value As Decimal)
                        xmontorecibe = value
                    End Set
                End Property

                Property _TipoCalculoUtilidad() As TipoCalculoUtilidad
                    Get
                        Return xtipocalculoutilidad
                    End Get
                    Set(ByVal value As TipoCalculoUtilidad)
                        xtipocalculoutilidad = value
                    End Set
                End Property

                Property _FichaDeposito() As FichaGlobal.c_Depositos.c_Registro
                    Get
                        Return xfichadeposito
                    End Get
                    Set(ByVal value As FichaGlobal.c_Depositos.c_Registro)
                        xfichadeposito = value
                    End Set
                End Property

                Property _Encabezado() As Encabezado
                    Get
                        Return xencabezado
                    End Get
                    Set(ByVal value As Encabezado)
                        xencabezado = value
                    End Set
                End Property

                Property _Detalles() As List(Of TemporalVentasMesas.c_Registro)
                    Get
                        Return xdetalles
                    End Get
                    Set(ByVal value As List(Of TemporalVentasMesas.c_Registro))
                        xdetalles = value
                    End Set
                End Property

                Sub New()
                    Me._Encabezado = New Encabezado
                    Me._Detalles = New List(Of TemporalVentasMesas.c_Registro)
                    Me._FichaDeposito = Nothing
                    Me._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto
                    Me._MontoRecibido = 0
                    Me._TablaModosPago = New DataTable
                End Sub

                Sub M_CrearTablaModoPago(ByRef xtb As DataTable)
                    Try
                        xtb = New DataTable
                        xtb.Columns.Add("AutoAgencia", GetType(String))
                        xtb.Columns.Add("NombreAgencia", GetType(String))
                        xtb.Columns.Add("ChequeTarjetaNumero", GetType(String))
                        xtb.Columns.Add("Importe", GetType(Decimal))
                        xtb.Columns.Add("AutoTipoPago", GetType(String))
                        xtb.Columns.Add("NombreTipoPago", GetType(String))
                        xtb.Columns.Add("CodigoTipoPago", GetType(String))
                        xtb.Columns.Add("MontoRecibido", GetType(Decimal))
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub
            End Class


            Function F_AgregarPlatoMesa(ByVal xdata As AgregarItemMesa) As Boolean
                Try
                    Dim xitem As New TemporalVentasMesas
                    Dim xmonitor As New MonitorMesas

                    With xitem
                        .RegistroDato.c_AutoItem._ContenidoCampo = ""
                        .RegistroDato.c_AutoJornada._ContenidoCampo = xdata._FichaJornada._AutoJornada
                        .RegistroDato.c_AutoMesonero._ContenidoCampo = xdata._FichaMesonero.r_Automatico
                        .RegistroDato.c_AutoOperador._ContenidoCampo = xdata._FichaOperador._AutoOperador
                        .RegistroDato.c_AutoPlato._ContenidoCampo = xdata._FichaPlato._Automatico
                        .RegistroDato.c_AutoUsuario._ContenidoCampo = xdata._FichaUsuario._AutoUsuario
                        .RegistroDato.c_CantidadDespachar._ContenidoCampo = xdata._CantDespachar
                        .RegistroDato.c_CodigoMesonero._ContenidoCampo = xdata._FichaMesonero.r_CodigoVendedor
                        .RegistroDato.c_CodigoPlato._ContenidoCampo = xdata._FichaPlato._CodigoPlato
                        .RegistroDato.c_CostoTotalNeto._ContenidoCampo = xdata._CostoTotalNeto
                        .RegistroDato.c_Enviado._ContenidoCampo = xdata._EstatusEnviado
                        .RegistroDato.c_EquipoEstacion._ContenidoCampo = xdata._EquipoEstacion
                        .RegistroDato.c_EsCombo._ContenidoCampo = IIf(xdata._FichaPlato._PlatoTipoCombo = TipoSiNo.Si, "1", "0")
                        .RegistroDato.c_EsOferta._ContenidoCampo = IIf(xdata._FichaPlato._PlatoEnOferta, "1", "0")
                        .RegistroDato.c_EsPesado._ContenidoCampo = IIf(xdata._FichaPlato._EstatusBalanza = TipoEstatus.Activo, "1", "0")
                        .RegistroDato.c_FechaProceso._ContenidoCampo = xdata._Fecha
                        .RegistroDato.c_Hora._ContenidoCampo = xdata._Hora
                        .RegistroDato.c_Importe._ContenidoCampo = xdata._Importe
                        .RegistroDato.c_Mesa._ContenidoCampo = xdata._Mesa
                        .RegistroDato.c_Mesonero._ContenidoCampo = xdata._FichaMesonero.r_NombreVendedor
                        .RegistroDato.c_NombrePlato._ContenidoCampo = xdata._FichaPlato._NombrePlato
                        .RegistroDato.c_NombreUsuario._ContenidoCampo = xdata._FichaUsuario._NombreUsuario
                        .RegistroDato.c_ParaLlevar._ContenidoCampo = xdata._Llevar
                        .RegistroDato.c_PrecioNeto._ContenidoCampo = xdata._PrecioNeto._Base
                        .RegistroDato.c_TasaIva._ContenidoCampo = xdata._FichaPlato._TasaImpuesto
                        Select Case xdata._PrecioSeleccionado
                            Case FastFood.TipoPrecioFastFood.Precio_1 : .RegistroDato.c_TipoPrecio._ContenidoCampo = "1"
                            Case FastFood.TipoPrecioFastFood.Precio_2 : .RegistroDato.c_TipoPrecio._ContenidoCampo = "2"
                            Case FastFood.TipoPrecioFastFood.Precio_Oferta : .RegistroDato.c_TipoPrecio._ContenidoCampo = "O"
                        End Select
                        .RegistroDato.c_TipoTasa._ContenidoCampo = xdata._FichaPlato.c_TipoImpuesto._ContenidoCampo
                        .RegistroDato.c_Unida._ContenidoCampo = xdata._Unida
                        .RegistroDato.c_AutoMonitorMesa._ContenidoCampo = xdata._AutoMonitorMesa
                        .RegistroDato.c_DetallePlato._ContenidoCampo = xdata._DetallePlato
                    End With

                    With xmonitor
                        .RegistroDato.c_Auto._ContenidoCampo = xitem.RegistroDato._AutoMonitorMesa
                        .RegistroDato.c_Mesa._ContenidoCampo = xitem.RegistroDato._Mesa
                    End With

                    If xitem.RegistroDato._Importe <= 0 Then
                        Throw New Exception("PRECIO DEL PLATO INCORRECTO..., VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_rest_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_rest_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_rest_item=a_rest_item+1;select a_rest_item from contadores"
                                xitem.RegistroDato.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                If xitem.RegistroDato._AutoMonitorMesa = "" Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_rest_mesas from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_rest_mesas=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_rest_mesas=a_rest_mesas+1;select a_rest_mesas from contadores"
                                    xmonitor.RegistroDato.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = MonitorMesas.InsertarMonitor
                                    xcmd.Parameters.AddWithValue("@" + xmonitor.RegistroDato.c_Auto._NombreCampo, xmonitor.RegistroDato._Auto).Size = xmonitor.RegistroDato.c_Auto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xmonitor.RegistroDato.c_Mesa._NombreCampo, xmonitor.RegistroDato._Mesa).Size = xmonitor.RegistroDato.c_Mesa._LargoCampo
                                    xcmd.ExecuteNonQuery()

                                    xitem.RegistroDato.c_AutoMonitorMesa._ContenidoCampo = xmonitor.RegistroDato._Auto
                                Else
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from rest_mesas where auto=@xauto"
                                    xcmd.Parameters.AddWithValue("@xauto", xitem.RegistroDato._AutoMonitorMesa)
                                    Dim xobj As Object = Nothing
                                    xobj = xcmd.ExecuteScalar
                                    If IsNothing(xobj) Or IsDBNull(xobj) Then
                                        Throw New Exception("DEBES ACTUIALIZAR / REFRESCAR EL CONTENIDO DE ESTA MESA")
                                    End If
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = Restaurant.TemporalVentasMesas.InsertarPedido
                                With xcmd.Parameters
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoItem._NombreCampo, xitem.RegistroDato._AutoItem).Size = xitem.RegistroDato.c_AutoItem._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoJornada._NombreCampo, xitem.RegistroDato._AutoJornada).Size = xitem.RegistroDato.c_AutoJornada._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoMesonero._NombreCampo, xitem.RegistroDato._AutoMesonero).Size = xitem.RegistroDato.c_AutoMesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoOperador._NombreCampo, xitem.RegistroDato._AutoOperador).Size = xitem.RegistroDato.c_AutoOperador._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoPlato._NombreCampo, xitem.RegistroDato._AutoPlato).Size = xitem.RegistroDato.c_AutoPlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoUsuario._NombreCampo, xitem.RegistroDato._AutoUsuario).Size = xitem.RegistroDato.c_AutoUsuario._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CantidadDespachar._NombreCampo, xitem.RegistroDato._CantidadDespachar)
                                    .AddWithValue("@" + xitem.RegistroDato.c_CodigoMesonero._NombreCampo, xitem.RegistroDato._CodigoMesonero).Size = xitem.RegistroDato.c_CodigoMesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CodigoPlato._NombreCampo, xitem.RegistroDato._CodigoPlato).Size = xitem.RegistroDato.c_CodigoPlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CostoTotalNeto._NombreCampo, xitem.RegistroDato._CostoTotalNeto)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Enviado._NombreCampo, xitem.RegistroDato.c_Enviado._ContenidoCampo).Size = xitem.RegistroDato.c_Enviado._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EquipoEstacion._NombreCampo, xitem.RegistroDato._EquipoEstacion).Size = xitem.RegistroDato.c_EquipoEstacion._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsCombo._NombreCampo, xitem.RegistroDato.c_EsCombo._ContenidoCampo).Size = xitem.RegistroDato.c_EsCombo._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsOferta._NombreCampo, xitem.RegistroDato.c_EsOferta._ContenidoCampo).Size = xitem.RegistroDato.c_EsOferta._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsPesado._NombreCampo, xitem.RegistroDato.c_EsPesado._ContenidoCampo).Size = xitem.RegistroDato.c_EsPesado._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_FechaProceso._NombreCampo, xitem.RegistroDato._FechaProceso)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Hora._NombreCampo, xitem.RegistroDato._Hora).Size = xitem.RegistroDato.c_Hora._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Importe._NombreCampo, xitem.RegistroDato._Importe)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Mesa._NombreCampo, xitem.RegistroDato._Mesa).Size = xitem.RegistroDato.c_Mesa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Mesonero._NombreCampo, xitem.RegistroDato._Mesonero).Size = xitem.RegistroDato.c_Mesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_NombrePlato._NombreCampo, xitem.RegistroDato._NombrePlato).Size = xitem.RegistroDato.c_NombrePlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_NombreUsuario._NombreCampo, xitem.RegistroDato._NombreUsuario).Size = xitem.RegistroDato.c_NombreUsuario._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_ParaLlevar._NombreCampo, xitem.RegistroDato.c_ParaLlevar._ContenidoCampo).Size = xitem.RegistroDato.c_ParaLlevar._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_PrecioNeto._NombreCampo, xitem.RegistroDato._PrecioNeto._Base)
                                    .AddWithValue("@" + xitem.RegistroDato.c_TasaIva._NombreCampo, xitem.RegistroDato._TasaIva)
                                    .AddWithValue("@" + xitem.RegistroDato.c_TipoPrecio._NombreCampo, xitem.RegistroDato.c_TipoPrecio._ContenidoCampo).Size = xitem.RegistroDato.c_TipoPrecio._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_TipoTasa._NombreCampo, xitem.RegistroDato.c_TipoTasa._ContenidoCampo).Size = xitem.RegistroDato.c_TipoTasa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Unida._NombreCampo, xitem.RegistroDato._Unida).Size = xitem.RegistroDato.c_Unida._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoMonitorMesa._NombreCampo, xitem.RegistroDato._AutoMonitorMesa).Size = xitem.RegistroDato.c_AutoMonitorMesa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_DetallePlato._NombreCampo, xitem.RegistroDato._DetallePlato).Size = xitem.RegistroDato.c_DetallePlato._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent _PlatoMesaAgregado(xmonitor.RegistroDato._Auto)
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("MESA YA FUE ABIERTA POR OTRO OPERADOR, VERIFIQUE POR FAVOR")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number)
                            End Select
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("TEMPORAL RESTAURANT VENTA" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AgregarPlatoPedido(ByVal xdata As AgregarItemPedido) As Boolean
                Try
                    Dim xitem As New TemporalVentasMesas
                    With xitem
                        .RegistroDato.c_AutoItem._ContenidoCampo = ""
                        .RegistroDato.c_AutoJornada._ContenidoCampo = xdata._FichaJornada._AutoJornada
                        .RegistroDato.c_AutoMesonero._ContenidoCampo = xdata._AutoCodigoNombreMesonero
                        .RegistroDato.c_AutoOperador._ContenidoCampo = xdata._FichaOperador._AutoOperador
                        .RegistroDato.c_AutoPlato._ContenidoCampo = xdata._FichaPlato._Automatico
                        .RegistroDato.c_AutoUsuario._ContenidoCampo = xdata._FichaUsuario._AutoUsuario
                        .RegistroDato.c_CantidadDespachar._ContenidoCampo = xdata._CantDespachar
                        .RegistroDato.c_CodigoMesonero._ContenidoCampo = xdata._AutoCodigoNombreMesonero
                        .RegistroDato.c_CodigoPlato._ContenidoCampo = xdata._FichaPlato._CodigoPlato
                        .RegistroDato.c_CostoTotalNeto._ContenidoCampo = xdata._CostoTotalNeto
                        .RegistroDato.c_Enviado._ContenidoCampo = xdata._EstatusEnviado
                        .RegistroDato.c_EquipoEstacion._ContenidoCampo = xdata._EquipoEstacion
                        .RegistroDato.c_EsCombo._ContenidoCampo = IIf(xdata._FichaPlato._PlatoTipoCombo = TipoSiNo.Si, "1", "0")
                        .RegistroDato.c_EsOferta._ContenidoCampo = IIf(xdata._FichaPlato._PlatoEnOferta, "1", "0")
                        .RegistroDato.c_EsPesado._ContenidoCampo = IIf(xdata._FichaPlato._EstatusBalanza = TipoEstatus.Activo, "1", "0")
                        .RegistroDato.c_FechaProceso._ContenidoCampo = xdata._Fecha
                        .RegistroDato.c_Hora._ContenidoCampo = xdata._Hora
                        .RegistroDato.c_Importe._ContenidoCampo = xdata._Importe
                        .RegistroDato.c_Mesa._ContenidoCampo = xdata._Mesa
                        .RegistroDato.c_Mesonero._ContenidoCampo = xdata._AutoCodigoNombreMesonero
                        .RegistroDato.c_NombrePlato._ContenidoCampo = xdata._FichaPlato._NombrePlato
                        .RegistroDato.c_NombreUsuario._ContenidoCampo = xdata._FichaUsuario._NombreUsuario
                        .RegistroDato.c_ParaLlevar._ContenidoCampo = xdata._Llevar
                        .RegistroDato.c_PrecioNeto._ContenidoCampo = xdata._PrecioNeto._Base
                        .RegistroDato.c_TasaIva._ContenidoCampo = xdata._FichaPlato._TasaImpuesto
                        Select Case xdata._PrecioSeleccionado
                            Case FastFood.TipoPrecioFastFood.Precio_1 : .RegistroDato.c_TipoPrecio._ContenidoCampo = "1"
                            Case FastFood.TipoPrecioFastFood.Precio_2 : .RegistroDato.c_TipoPrecio._ContenidoCampo = "2"
                            Case FastFood.TipoPrecioFastFood.Precio_Oferta : .RegistroDato.c_TipoPrecio._ContenidoCampo = "O"
                        End Select
                        .RegistroDato.c_TipoTasa._ContenidoCampo = xdata._FichaPlato.c_TipoImpuesto._ContenidoCampo
                        .RegistroDato.c_Unida._ContenidoCampo = xdata._Unida
                        .RegistroDato.c_AutoMonitorMesa._ContenidoCampo = xdata._AutoMonitorMesa
                        .RegistroDato.c_DetallePlato._ContenidoCampo = xdata._Detalle
                    End With

                    If xitem.RegistroDato._Importe <= 0 Then
                        Throw New Exception("PRECIO DEL PLATO INCORRECTO..., VERIFIQUE")
                    End If

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)

                                xcmd.CommandText = "select a_rest_item from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_rest_item=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_rest_item=a_rest_item+1;select a_rest_item from contadores"
                                xitem.RegistroDato.c_AutoItem._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                If xitem.RegistroDato._Mesa = "000000" Then  ' ES UN PEDIDO NUEVO A GENEREAR
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_rest_pedidos from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_rest_pedidos=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_Rest_pedidos=a_Rest_pedidos+1;select a_rest_pedidos from contadores"
                                    xitem.RegistroDato.c_Mesa._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(6, "0")
                                Else
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select COUNT(*) from rest_temporalmesas where mesa=@xpedido and parallevar='1'"
                                    xcmd.Parameters.AddWithValue("@xpedido", xitem.RegistroDato._Mesa)
                                    If xcmd.ExecuteScalar() = 0 Then
                                        Throw New Exception("NUMERO DE PEDIDO NO ENCONTRADO, VERIFIQUE POR FAVOR")
                                    End If
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = Restaurant.TemporalVentasMesas.InsertarPedido
                                With xcmd.Parameters
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoItem._NombreCampo, xitem.RegistroDato._AutoItem).Size = xitem.RegistroDato.c_AutoItem._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoJornada._NombreCampo, xitem.RegistroDato._AutoJornada).Size = xitem.RegistroDato.c_AutoJornada._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoMesonero._NombreCampo, xitem.RegistroDato._AutoMesonero).Size = xitem.RegistroDato.c_AutoMesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoOperador._NombreCampo, xitem.RegistroDato._AutoOperador).Size = xitem.RegistroDato.c_AutoOperador._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoPlato._NombreCampo, xitem.RegistroDato._AutoPlato).Size = xitem.RegistroDato.c_AutoPlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoUsuario._NombreCampo, xitem.RegistroDato._AutoUsuario).Size = xitem.RegistroDato.c_AutoUsuario._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CantidadDespachar._NombreCampo, xitem.RegistroDato._CantidadDespachar)
                                    .AddWithValue("@" + xitem.RegistroDato.c_CodigoMesonero._NombreCampo, xitem.RegistroDato._CodigoMesonero).Size = xitem.RegistroDato.c_CodigoMesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CodigoPlato._NombreCampo, xitem.RegistroDato._CodigoPlato).Size = xitem.RegistroDato.c_CodigoPlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_CostoTotalNeto._NombreCampo, xitem.RegistroDato._CostoTotalNeto)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Enviado._NombreCampo, xitem.RegistroDato.c_Enviado._ContenidoCampo).Size = xitem.RegistroDato.c_Enviado._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EquipoEstacion._NombreCampo, xitem.RegistroDato._EquipoEstacion).Size = xitem.RegistroDato.c_EquipoEstacion._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsCombo._NombreCampo, xitem.RegistroDato.c_EsCombo._ContenidoCampo).Size = xitem.RegistroDato.c_EsCombo._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsOferta._NombreCampo, xitem.RegistroDato.c_EsOferta._ContenidoCampo).Size = xitem.RegistroDato.c_EsOferta._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_EsPesado._NombreCampo, xitem.RegistroDato.c_EsPesado._ContenidoCampo).Size = xitem.RegistroDato.c_EsPesado._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_FechaProceso._NombreCampo, xitem.RegistroDato._FechaProceso)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Hora._NombreCampo, xitem.RegistroDato._Hora).Size = xitem.RegistroDato.c_Hora._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Importe._NombreCampo, xitem.RegistroDato._Importe)
                                    .AddWithValue("@" + xitem.RegistroDato.c_Mesa._NombreCampo, xitem.RegistroDato._Mesa).Size = xitem.RegistroDato.c_Mesa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Mesonero._NombreCampo, xitem.RegistroDato._Mesonero).Size = xitem.RegistroDato.c_Mesonero._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_NombrePlato._NombreCampo, xitem.RegistroDato._NombrePlato).Size = xitem.RegistroDato.c_NombrePlato._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_NombreUsuario._NombreCampo, xitem.RegistroDato._NombreUsuario).Size = xitem.RegistroDato.c_NombreUsuario._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_ParaLlevar._NombreCampo, xitem.RegistroDato.c_ParaLlevar._ContenidoCampo).Size = xitem.RegistroDato.c_ParaLlevar._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_PrecioNeto._NombreCampo, xitem.RegistroDato._PrecioNeto._Base)
                                    .AddWithValue("@" + xitem.RegistroDato.c_TasaIva._NombreCampo, xitem.RegistroDato._TasaIva)
                                    .AddWithValue("@" + xitem.RegistroDato.c_TipoPrecio._NombreCampo, xitem.RegistroDato.c_TipoPrecio._ContenidoCampo).Size = xitem.RegistroDato.c_TipoPrecio._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_TipoTasa._NombreCampo, xitem.RegistroDato.c_TipoTasa._ContenidoCampo).Size = xitem.RegistroDato.c_TipoTasa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_Unida._NombreCampo, xitem.RegistroDato._Unida).Size = xitem.RegistroDato.c_Unida._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_AutoMonitorMesa._NombreCampo, xitem.RegistroDato._AutoMonitorMesa).Size = xitem.RegistroDato.c_AutoMonitorMesa._LargoCampo
                                    .AddWithValue("@" + xitem.RegistroDato.c_DetallePlato._NombreCampo, xitem.RegistroDato._DetallePlato).Size = xitem.RegistroDato.c_DetallePlato._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()
                            End Using
                            xtr.Commit()
                            RaiseEvent _PlatoPedidoAgregado(xitem.RegistroDato.c_Mesa._ContenidoCampo)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("TEMPORAL RESTAURANT VENTA" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AnularCuenta(ByVal xdata As AgregarAnulacion) As Boolean
                Try
                    Dim xauto As String
                    Dim xtr As SqlTransaction

                    Dim xsql As String = "INSERT INTO rest_devolucionanulacion (" & _
                    "auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "importe," & _
                    "costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario," & _
                    "auto_jornada_dev, auto_operador_dev, auto_usuario_dev, maquina_dev, hora_dev, fecha_dev, motivo_dev, nombre_usuario_dev," & _
                    "nivel_clave_usada, auto_anulacion, tipo_anulacion) " & _
                    "SELECT  auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "importe," & _
                    "costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario,@AUTO_JORNADA, @AUTO_OPERADOR, @AUTO_USUARIO, @MAQUINA,@HORA, @FECHA, @MOTIVO, @NOMBRE_USUARIO," & _
                    "@NIVEL_CLAVE, @AUTO_ANULACION, @TIPO_ANULACION FROM rest_temporalmesas where mesa=@MESA and parallevar=@parallevar"

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_rest_anulaciones from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.CommandText = "update contadores set a_rest_anulaciones=0"
                                    xcmd.ExecuteScalar()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_rest_anulaciones=a_rest_anulaciones+1;select a_rest_anulaciones from contadores"
                                xauto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql
                                xcmd.Parameters.AddWithValue("@AUTO_JORNADA", xdata._FichaJornada._AutoJornada)
                                xcmd.Parameters.AddWithValue("@AUTO_OPERADOR", xdata._FichaOperador._AutoOperador)
                                xcmd.Parameters.AddWithValue("@AUTO_USUARIO", xdata._FichaUsuario._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@MAQUINA", xdata._Equipo)
                                xcmd.Parameters.AddWithValue("@HORA", xdata._Hora)
                                xcmd.Parameters.AddWithValue("@FECHA", xdata._Fecha)
                                xcmd.Parameters.AddWithValue("@MOTIVO", xdata._Motivo)
                                xcmd.Parameters.AddWithValue("@NOMBRE_USUARIO", xdata._FichaUsuario._NombreUsuario)
                                Select Case xdata._NivelClaveUsada
                                    Case NivelClave.Maxima : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "1")
                                    Case NivelClave.Media : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "2")
                                    Case NivelClave.Minima : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "3")
                                    Case NivelClave.SinClave : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "0")
                                End Select
                                xcmd.Parameters.AddWithValue("@AUTO_ANULACION", xauto)
                                Select Case xdata._TipoAnulacion
                                    Case TipoAnulacion.Anulacion : xcmd.Parameters.AddWithValue("@TIPO_ANULACION", "A")
                                    Case TipoAnulacion.CtaPendiente : xcmd.Parameters.AddWithValue("@TIPO_ANULACION", "P")
                                End Select
                                xcmd.Parameters.AddWithValue("@MESA", xdata._Mesa)
                                If xdata._TipoPedidoMesa = Restaurant.TipoPedido.ParaMesa Then
                                    xcmd.Parameters.AddWithValue("@parallevar", "0")
                                Else
                                    xcmd.Parameters.AddWithValue("@parallevar", "1")
                                End If
                                xcmd.ExecuteNonQuery()

                                If xdata._TipoPedidoMesa = Restaurant.TipoPedido.ParaMesa Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "DELETE from rest_TEMPORALMESAS where MESA=@MESA and parallevar='0'"
                                    xcmd.Parameters.AddWithValue("@MESA", xdata._Mesa)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "DELETE from rest_mesas where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xdata._AutoMonitorMesa)
                                    If xcmd.ExecuteNonQuery() <= 0 Then
                                        Throw New Exception("MESA NO ENCONTRADA EN EL MONITOR DE REGISTROS" + vbCrLf + "VERIFIQUE POR FAVOR")
                                    End If
                                Else
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "DELETE from rest_TEMPORALMESAS where MESA=@MESA and parallevar='1'"
                                    xcmd.Parameters.AddWithValue("@MESA", xdata._Mesa)
                                    If xcmd.ExecuteNonQuery() <= 0 Then
                                        Throw New Exception("PEDIDO NO ENCONTRADO" + vbCrLf + "VERIFIQUE POR FAVOR")
                                    End If
                                End If
                            End Using
                            xtr.Commit()
                            RaiseEvent _CuentaAnuladaOk()
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_CambioMesa(ByVal xdata As AgregarCambioMesa) As Boolean
                Try
                    Dim xreg As New CambioUnionMesas.c_Registro
                    Dim xtr As SqlTransaction

                    With xreg
                        .c_AutoJornada._ContenidoCampo = xdata._FichaJornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xdata._FichaOperador._AutoOperador
                        .c_AutoUsuario._ContenidoCampo = xdata._FichaUsuario._AutoUsuario
                        .c_DeLaMesa._ContenidoCampo = xdata._MesaInicio
                        .c_EquipoEstacion._ContenidoCampo = xdata._Equipo
                        .c_FechaProceso._ContenidoCampo = xdata._Fecha
                        .c_Hora._ContenidoCampo = xdata._Hora
                        .c_Motivo._ContenidoCampo = xdata._Motivo
                        Select Case xdata._NivelClaveUsada
                            Case NivelClave.Maxima : .c_NivelClaveUsada._ContenidoCampo = "1"
                            Case NivelClave.Media : .c_NivelClaveUsada._ContenidoCampo = "2"
                            Case NivelClave.Minima : .c_NivelClaveUsada._ContenidoCampo = "3"
                            Case NivelClave.SinClave : .c_NivelClaveUsada._ContenidoCampo = "0"
                        End Select
                        .c_NombreUsuario._ContenidoCampo = xdata._FichaUsuario._NombreUsuario
                        .c_ParaLaMesa._ContenidoCampo = xdata._MesaDestino
                        Select Case xdata._TipoMovimiento
                            Case TipoMovimientoMesa.PorCambio : .c_TipoMovimiento._ContenidoCampo = "C"
                            Case TipoMovimientoMesa.PorUnion : .c_TipoMovimiento._ContenidoCampo = "U"
                            Case TipoMovimientoMesa.PorTraslado : .c_TipoMovimiento._ContenidoCampo = "T"
                        End Select
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = CambioUnionMesas.InsertarCambioUnion
                                With xcmd.Parameters
                                    .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_DeLaMesa._NombreCampo, xreg._DeLaMesa).Size = xreg.c_DeLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_EquipoEstacion._NombreCampo, xreg._EquipoEstacion).Size = xreg.c_EquipoEstacion._LargoCampo
                                    .AddWithValue("@" + xreg.c_FechaProceso._NombreCampo, xreg._FechaProceso).Size = xreg.c_FechaProceso._LargoCampo
                                    .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                    .AddWithValue("@" + xreg.c_Motivo._NombreCampo, xreg._Motivo).Size = xreg.c_Motivo._LargoCampo
                                    .AddWithValue("@" + xreg.c_NivelClaveUsada._NombreCampo, xreg.c_NivelClaveUsada._ContenidoCampo).Size = xreg.c_NivelClaveUsada._LargoCampo
                                    .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_ParaLaMesa._NombreCampo, xreg._ParaLaMesa).Size = xreg.c_ParaLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_TipoMovimiento._NombreCampo, xreg.c_TipoMovimiento._ContenidoCampo).Size = xreg.c_TipoMovimiento._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update rest_temporalmesas set mesa = @mesa where mesa = @ViejaMesa and parallevar='0'"
                                With xcmd.Parameters
                                    .AddWithValue("@viejamesa", xreg._DeLaMesa)
                                    .AddWithValue("@mesa", xreg._ParaLaMesa)
                                End With
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update rest_mesas set mesa = @mesa where auto = @auto"
                                With xcmd.Parameters
                                    .AddWithValue("@auto", xdata._AutoMonitorMesa)
                                    .AddWithValue("@mesa", xreg._ParaLaMesa)
                                End With
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("MESA A REALIZAR EL CAMBIO YA ESTA DESACTUALIZADA, DEBES REFRESCAR EL CONTENIDO DE MESA")
                                End If
                            End Using
                            xtr.Commit()
                            RaiseEvent _CambioMesaOK(xreg._ParaLaMesa)
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("MESA DESTINO A CAMBIAR YA ESTA OCUPADA POR UN CLIENTE.. VERIFIQUE POR FAVOR")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number.ToString)
                            End Select
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_TrasladarPedidoAMesa(ByVal xdata As AgregarTrasladoMesa) As Boolean
                Try
                    Dim xreg As New CambioUnionMesas.c_Registro
                    Dim xmonitor As New MonitorMesas
                    Dim xtr As SqlTransaction

                    With xreg
                        .c_AutoJornada._ContenidoCampo = xdata._FichaJornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xdata._FichaOperador._AutoOperador
                        .c_AutoUsuario._ContenidoCampo = xdata._FichaUsuario._AutoUsuario
                        .c_DeLaMesa._ContenidoCampo = xdata._Pedido
                        .c_EquipoEstacion._ContenidoCampo = xdata._Equipo
                        .c_FechaProceso._ContenidoCampo = xdata._Fecha
                        .c_Hora._ContenidoCampo = xdata._Hora
                        .c_Motivo._ContenidoCampo = xdata._Motivo
                        Select Case xdata._NivelClaveUsada
                            Case NivelClave.Maxima : .c_NivelClaveUsada._ContenidoCampo = "1"
                            Case NivelClave.Media : .c_NivelClaveUsada._ContenidoCampo = "2"
                            Case NivelClave.Minima : .c_NivelClaveUsada._ContenidoCampo = "3"
                            Case NivelClave.SinClave : .c_NivelClaveUsada._ContenidoCampo = "0"
                        End Select
                        .c_NombreUsuario._ContenidoCampo = xdata._FichaUsuario._NombreUsuario
                        .c_ParaLaMesa._ContenidoCampo = xdata._MesaDestino
                        Select Case xdata._TipoMovimiento
                            Case TipoMovimientoMesa.PorCambio : .c_TipoMovimiento._ContenidoCampo = "C"
                            Case TipoMovimientoMesa.PorUnion : .c_TipoMovimiento._ContenidoCampo = "U"
                            Case TipoMovimientoMesa.PorTraslado : .c_TipoMovimiento._ContenidoCampo = "T"
                        End Select
                    End With

                    With xmonitor
                        .RegistroDato.c_Mesa._ContenidoCampo = xdata._MesaDestino
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = CambioUnionMesas.InsertarCambioUnion
                                With xcmd.Parameters
                                    .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_DeLaMesa._NombreCampo, xreg._DeLaMesa).Size = xreg.c_DeLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_EquipoEstacion._NombreCampo, xreg._EquipoEstacion).Size = xreg.c_EquipoEstacion._LargoCampo
                                    .AddWithValue("@" + xreg.c_FechaProceso._NombreCampo, xreg._FechaProceso).Size = xreg.c_FechaProceso._LargoCampo
                                    .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                    .AddWithValue("@" + xreg.c_Motivo._NombreCampo, xreg._Motivo).Size = xreg.c_Motivo._LargoCampo
                                    .AddWithValue("@" + xreg.c_NivelClaveUsada._NombreCampo, xreg.c_NivelClaveUsada._ContenidoCampo).Size = xreg.c_NivelClaveUsada._LargoCampo
                                    .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_ParaLaMesa._NombreCampo, xreg._ParaLaMesa).Size = xreg.c_ParaLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_TipoMovimiento._NombreCampo, xreg.c_TipoMovimiento._ContenidoCampo).Size = xreg.c_TipoMovimiento._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_rest_mesas from contadores"
                                If IsDBNull(xcmd.ExecuteScalar()) Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_rest_mesas=0"
                                    xcmd.ExecuteNonQuery()
                                End If
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update contadores set a_rest_mesas=a_rest_mesas+1;select a_rest_mesas from contadores"
                                xmonitor.RegistroDato.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = MonitorMesas.InsertarMonitor
                                xcmd.Parameters.AddWithValue("@" + xmonitor.RegistroDato.c_Auto._NombreCampo, xmonitor.RegistroDato._Auto).Size = xmonitor.RegistroDato.c_Auto._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xmonitor.RegistroDato.c_Mesa._NombreCampo, xmonitor.RegistroDato._Mesa).Size = xmonitor.RegistroDato.c_Mesa._LargoCampo
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update rest_temporalmesas set mesa = @mesa, auto_mesa_monitor=@auto, parallevar='0' where mesa = @ViejaMesa and parallevar='1'"
                                With xcmd.Parameters
                                    .AddWithValue("@viejamesa", xreg._DeLaMesa)
                                    .AddWithValue("@mesa", xreg._ParaLaMesa)
                                    .AddWithValue("@auto", xmonitor.RegistroDato._Auto)
                                End With
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PEDIDO A TRASLADAR HA SIDO MODIFICADO POR OTRO USUARIO, VERIFICA POR FAVOR")
                                End If
                            End Using
                            xtr.Commit()
                            RaiseEvent _TrasladoPedidoOk(xmonitor.RegistroDato)
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 2601 : Throw New Exception("MESA DESTINO YA ESTA OCUPADA POR UN CLIENTE.. VERIFIQUE POR FAVOR")
                                Case Else : Throw New Exception(ex2.Message + vbCrLf + ex2.Number.ToString)
                            End Select
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_DevolucionItem(ByVal xdata As AgregarDevolucion) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Dim xsql As String = "INSERT INTO rest_devolucionanulacion (" & _
                    "auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "importe," & _
                    "costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario," & _
                    "auto_jornada_dev, auto_operador_dev, auto_usuario_dev, maquina_dev, hora_dev, fecha_dev, motivo_dev, nombre_usuario_dev," & _
                    "nivel_clave_usada, auto_anulacion, tipo_anulacion) " & _
                    "SELECT  auto_plato," & _
                    "auto_usuario," & _
                    "auto_jornada," & _
                    "auto_operador," & _
                    "auto_Mesonero," & _
                    "Unida," & _
                    "Mesa," & _
                    "codigo_plato," & _
                    "nombre_plato," & _
                    "@cantidad," & _
                    "precio_neto," & _
                    "tasa_iva," & _
                    "@importe," & _
                    "@costo_total_neto," & _
                    "Codigo_Mesonero," & _
                    "Mesonero," & _
                    "tipo_tasa," & _
                    "tipo_precio," & _
                    "Enviado," & _
                    "Parallevar," & _
                    "escombo," & _
                    "espesado," & _
                    "esoferta," & _
                    "Hora," & _
                    "fecha," & _
                    "maquina," & _
                    "nombre_usuario,@AUTO_JORNADA, @AUTO_OPERADOR, @AUTO_USUARIO, @MAQUINA,@HORA, @FECHA, @MOTIVO, @NOMBRE_USUARIO," & _
                    "@NIVEL_CLAVE, @AUTO_ANULACION, @TIPO_ANULACION FROM rest_temporalmesas where auto_item=@auto_item and id_seguridad=@id_seguridad"

                    Dim xcant As Decimal = 0
                    Dim xneto As Decimal = 0
                    Dim xcost As Decimal = 0
                    Dim ximporte As Decimal = 0
                    Dim xcostotal As Decimal = 0

                    xcant = xdata._FichaItemDevolver._CantidadDespachar - 1
                    xneto = xdata._FichaItemDevolver._PrecioNeto._Base
                    xcost = xdata._FichaItemDevolver._CostoNeto
                    ximporte = Decimal.Round(xcant * xneto, 2, MidpointRounding.AwayFromZero)
                    xcostotal = Decimal.Round(xcant * xcost, 2, MidpointRounding.AwayFromZero)

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql
                                If xdata._TipoDevolucion = TipoDevolucion.Total Then
                                    xcmd.Parameters.AddWithValue("@cantidad", xdata._FichaItemDevolver._CantidadDespachar)
                                    xcmd.Parameters.AddWithValue("@importe", xdata._FichaItemDevolver._Importe)
                                    xcmd.Parameters.AddWithValue("@costo_total_neto", xdata._FichaItemDevolver._CostoTotalNeto)
                                Else
                                    xcmd.Parameters.AddWithValue("@cantidad", 1)
                                    xcmd.Parameters.AddWithValue("@importe", xneto)
                                    xcmd.Parameters.AddWithValue("@costo_total_neto", xcost)
                                End If
                                xcmd.Parameters.AddWithValue("@AUTO_JORNADA", xdata._FichaJornada._AutoJornada)
                                xcmd.Parameters.AddWithValue("@AUTO_OPERADOR", xdata._FichaOperador._AutoOperador)
                                xcmd.Parameters.AddWithValue("@AUTO_USUARIO", xdata._FichaUsuario._AutoUsuario)
                                xcmd.Parameters.AddWithValue("@MAQUINA", xdata._Equipo)
                                xcmd.Parameters.AddWithValue("@HORA", xdata._Hora)
                                xcmd.Parameters.AddWithValue("@FECHA", xdata._Fecha)
                                xcmd.Parameters.AddWithValue("@MOTIVO", xdata._Motivo)
                                xcmd.Parameters.AddWithValue("@NOMBRE_USUARIO", xdata._FichaUsuario._NombreUsuario)
                                Select Case xdata._NivelClaveUsada
                                    Case NivelClave.Maxima : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "1")
                                    Case NivelClave.Media : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "2")
                                    Case NivelClave.Minima : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "3")
                                    Case NivelClave.SinClave : xcmd.Parameters.AddWithValue("@NIVEL_CLAVE", "0")
                                End Select
                                xcmd.Parameters.AddWithValue("@AUTO_ANULACION", "")
                                xcmd.Parameters.AddWithValue("@TIPO_ANULACION", "D")
                                xcmd.Parameters.AddWithValue("@auto_item", xdata._FichaItemDevolver._AutoItem)
                                xcmd.Parameters.AddWithValue("@id_seguridad", xdata._FichaItemDevolver._Id)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("ITEM HA DEVOLVER HA SIDO ACTUALIZADO POR OTRO USUARIO, VERIFIQUE")
                                End If

                                If xdata._TipoDevolucion = TipoDevolucion.Parcial And xdata._FichaItemDevolver._CantidadDespachar > 1 Then
                                    If xdata._FichaItemDevolver._EsPesado = TipoSiNo.Si Then
                                        Throw New Exception("ITEM A DEVOLVER ES PESADO, DEBES SELECCIONAR UNA DEVOLUCION TOTAL DEL ITEM")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update rest_temporalmesas set cantidad=@cantidad, importe=@importe, costo_total_neto=@costototalneto " & _
                                        "where auto_item=@auto_item and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.AddWithValue("@cantidad", xcant)
                                    xcmd.Parameters.AddWithValue("@importe", ximporte)
                                    xcmd.Parameters.AddWithValue("@costototalneto", xcostotal)
                                    xcmd.Parameters.AddWithValue("@auto_item", xdata._FichaItemDevolver._AutoItem)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xdata._FichaItemDevolver._Id)
                                    xcmd.ExecuteNonQuery()
                                End If

                                If xdata._TipoDevolucion = TipoDevolucion.Total Or xdata._FichaItemDevolver._CantidadDespachar = 1 Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "DELETE from rest_TEMPORALMESAS where auto_item=@auto_item and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.AddWithValue("@auto_item", xdata._FichaItemDevolver._AutoItem)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xdata._FichaItemDevolver._Id)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("ITEM HA DEVOLVER HA SIDO ACTUALIZADO POR OTRO USUARIO, VERIFIQUE")
                                    End If
                                End If

                                Dim xreg As Integer = 0
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select count(*) from rest_temporalmesas where mesa=@mesa and parallevar=@parallevar"
                                xcmd.Parameters.AddWithValue("@mesa", xdata._FichaItemDevolver._Mesa)
                                xcmd.Parameters.AddWithValue("@parallevar", xdata._FichaItemDevolver.c_ParaLlevar._ContenidoCampo)
                                xreg = xcmd.ExecuteScalar()
                                If xreg = 0 Then
                                    If xdata._FichaItemDevolver._AutoMonitorMesa <> "" Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "DELETE from rest_mesas where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@auto", xdata._FichaItemDevolver._AutoMonitorMesa)
                                        If xcmd.ExecuteNonQuery() <= 0 Then
                                            Throw New Exception("MESA NO ENCONTRADA EN EL MONITOR DE REGISTROS" + vbCrLf + "VERIFIQUE POR FAVOR")
                                        End If
                                    End If
                                End If
                            End Using
                            xtr.Commit()

                            RaiseEvent _DevolucionOk(xdata._FichaItemDevolver._Mesa)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_IncrementarCantidadItem(ByVal xitem As TemporalVentasMesas.c_Registro, ByVal xcant As Integer) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing

                    Dim xcnt As Decimal = 0
                    Dim xneto As Decimal = 0
                    Dim xcost As Decimal = 0
                    Dim ximporte As Decimal = 0
                    Dim xcostotal As Decimal = 0

                    xcnt = xitem._CantidadDespachar + xcant
                    xneto = xitem._PrecioNeto._Base
                    xcost = xitem._CostoNeto
                    ximporte = Decimal.Round(xcnt * xneto, 2, MidpointRounding.AwayFromZero)
                    xcostotal = Decimal.Round(xcnt * xcost, 2, MidpointRounding.AwayFromZero)

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                If xitem._EsPesado = TipoSiNo.Si Then
                                    Throw New Exception("ERROR ... ITEM HA ACTUALIZAR ES PESADO, VERIFIQUE ")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update rest_temporalmesas set cantidad=@cantidad, importe=@importe, costo_total_neto=@costototalneto " & _
                                    "where auto_item=@auto_item and id_seguridad=@id_seguridad"
                                xcmd.Parameters.AddWithValue("@cantidad", xcnt)
                                xcmd.Parameters.AddWithValue("@importe", ximporte)
                                xcmd.Parameters.AddWithValue("@costototalneto", xcostotal)
                                xcmd.Parameters.AddWithValue("@auto_item", xitem._AutoItem)
                                xcmd.Parameters.AddWithValue("@id_seguridad", xitem._Id)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("ITEM HA SIDO ACTUALIZADO POR OTRO USUARIO, VERIFIQUE")
                                End If
                            End Using
                            xtr.Commit()

                            RaiseEvent _IncrementoItemOk(xitem._Mesa)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_HayItemsQueNotificar(ByVal xmesapedido As String, ByVal xtipo As TipoPedido) As Boolean
                Try
                    Dim x As Integer = 0
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select count(*) from rest_temporalmesas where mesa=@mesa and parallevar=@parallevar and enviado='0'"
                                xcmd.Parameters.AddWithValue("@mesa", xmesapedido)
                                If xtipo = TipoPedido.ParaLLevar Then
                                    xcmd.Parameters.AddWithValue("@parallevar", "1")
                                Else
                                    xcmd.Parameters.AddWithValue("@parallevar", "0")
                                End If
                                x = xcmd.ExecuteScalar
                                If x > 0 Then
                                    Return True
                                Else
                                    Return False
                                End If
                            End Using
                        Catch ex As Exception
                            Throw New Exception("ITEMS QUE NOTIFICAR:" + vbCrLf + ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_ActualizarNotasItem(ByVal xnota As ActualizarNotasItem) As Boolean
                Try
                    Dim xsql As String = "update rest_temporalmesas set detalle_plato=@detalle where auto_item=@auto_item and id_seguridad=@id_seguridad"
                    Dim xtr As SqlTransaction = Nothing

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql
                                With xcmd.Parameters
                                    .AddWithValue("@detalle", xnota._NotasItem).Size = xnota._FichaItem.c_DetallePlato._LargoCampo
                                    .AddWithValue("@auto_item", xnota._FichaItem._AutoItem)
                                    .AddWithValue("@id_seguridad", xnota._FichaItem._Id)
                                End With
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("NO SE PUDO ACTUALIZAR LAS NOTAS DEL PLATO, YA QUE AL PARECER OTRO USUARIO YA ACTUALIZAO")
                                End If
                            End Using
                            xtr.Commit()
                            RaiseEvent _NotasActualizadas()

                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("ERROR AL ACTUALIZAR NOTAS DEL ITEM - RESTAURANT" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AgregarComandasHistorial(ByVal xhistorial As AgregarHistorialComanda) As Boolean
                Try
                    Dim xlista As New List(Of HistorialComandas.c_Registro)
                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xret As Integer = 0
                                Dim xestacion As New FastFood.EstacionFastFood
                                For Each xreg In xhistorial._ListaItems
                                    xret = 0

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update rest_temporalmesas set enviado='1' where auto_item=@auto_item and id_seguridad=@id_seguridad "
                                    xcmd.Parameters.AddWithValue("@auto_item", xreg._AutoItem)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xreg._Id)
                                    xret = xcmd.ExecuteNonQuery
                                    If xret = 0 Then
                                        Throw New Exception("PROBLEMA AL ENVIAR COMANDAS, AL PARECER OTRO USUARIO YA ENVIO")
                                    End If

                                    Dim xtb As New DataTable
                                    Dim xrd As SqlDataReader
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select e.* from ESTACION_FASTFOOD e join menuestaciones_fastfood me on e.auto= me.auto_estacion " & _
                                                       "where me.auto_plato=@auto_plato"
                                    xcmd.Parameters.AddWithValue("@auto_plato", xreg._AutoPlato)
                                    xrd = xcmd.ExecuteReader
                                    xtb.Load(xrd)
                                    xrd.Close()

                                    If xtb.Rows.Count = 0 Then
                                        Dim xhist As New HistorialComandas.c_Registro
                                        With xhist
                                            .M_Limpiar()

                                            .c_Auto._ContenidoCampo = ""
                                            .c_AutoEstacion._ContenidoCampo = ""
                                            .c_AutoItem._ContenidoCampo = xreg._AutoItem
                                            .c_AutoJornada._ContenidoCampo = xhistorial._FichaJornada._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xhistorial._FichaOperador._AutoOperador
                                            .c_AutoPlato._ContenidoCampo = xreg._AutoPlato
                                            .c_Cantidad._ContenidoCampo = xreg._CantidadDespachar
                                            .c_EsParallevar._ContenidoCampo = xreg.c_ParaLlevar._ContenidoCampo
                                            .c_EstatusEstacionEnvio._ContenidoCampo = ""
                                            .c_EstatusPlatoEnvio._ContenidoCampo = ""
                                            .c_FechaProceso._ContenidoCampo = xhistorial._Fecha
                                            .c_MesoneroCodigo._ContenidoCampo = xreg._CodigoMesonero
                                            .c_MesoneroNombre._ContenidoCampo = xreg._Mesonero
                                            .c_MesPedido._ContenidoCampo = xreg._Mesa
                                            .c_NombreEstacion._ContenidoCampo = ""
                                            .c_NombrePlato._ContenidoCampo = xreg._NombrePlato
                                            .c_NombreUsuario._ContenidoCampo = xhistorial._FichaUsuario._NombreUsuario
                                            .c_NotasDetalle._ContenidoCampo = xreg._DetallePlato
                                            .c_RutaEstacion._ContenidoCampo = ""
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select a_rest_historial_comandas from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_rest_historial_comandas=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_rest_historial_comandas=a_rest_historial_comandas+1;" & _
                                                            "select a_rest_historial_comandas from contadores"
                                        xhist.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = HistorialComandas.InsertarHistorialComanda
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_Auto._NombreCampo, xhist.c_Auto._ContenidoCampo).Size = xhist.c_Auto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_AutoEstacion._NombreCampo, xhist.c_AutoEstacion._ContenidoCampo).Size = xhist.c_AutoEstacion._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_AutoItem._NombreCampo, xhist.c_AutoItem._ContenidoCampo).Size = xhist.c_AutoItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_AutoJornada._NombreCampo, xhist.c_AutoJornada._ContenidoCampo).Size = xhist.c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_AutoOperador._NombreCampo, xhist.c_AutoOperador._ContenidoCampo).Size = xhist.c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_AutoPlato._NombreCampo, xhist.c_AutoPlato._ContenidoCampo).Size = xhist.c_AutoPlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_Cantidad._NombreCampo, xhist.c_Cantidad._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_EsParallevar._NombreCampo, xhist.c_EsParallevar._ContenidoCampo).Size = xhist.c_EsParallevar._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusEstacionEnvio._NombreCampo, xhist.c_EstatusEstacionEnvio._ContenidoCampo).Size = xhist.c_EstatusEstacionEnvio._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusPlatoEnvio._NombreCampo, xhist.c_EstatusPlatoEnvio._ContenidoCampo).Size = xhist.c_EstatusPlatoEnvio._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_FechaProceso._NombreCampo, xhist.c_FechaProceso._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroCodigo._NombreCampo, xhist.c_MesoneroCodigo._ContenidoCampo).Size = xhist.c_MesoneroCodigo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroNombre._NombreCampo, xhist.c_MesoneroNombre._ContenidoCampo).Size = xhist.c_MesoneroNombre._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_MesPedido._NombreCampo, xhist.c_MesPedido._ContenidoCampo).Size = xhist.c_MesPedido._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_NombreEstacion._NombreCampo, xhist.c_NombreEstacion._ContenidoCampo).Size = xhist.c_NombreEstacion._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_NombreUsuario._NombreCampo, xhist.c_NombreUsuario._ContenidoCampo).Size = xhist.c_NombreUsuario._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_NombrePlato._NombreCampo, xhist.c_NombrePlato._ContenidoCampo).Size = xhist.c_NombrePlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_NotasDetalle._NombreCampo, xhist.c_NotasDetalle._ContenidoCampo).Size = xhist.c_NotasDetalle._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xhist.c_RutaEstacion._NombreCampo, xhist.c_RutaEstacion._ContenidoCampo).Size = xhist.c_RutaEstacion._LargoCampo
                                        xcmd.ExecuteNonQuery()

                                        xlista.Add(xhist)
                                    Else
                                        For Each dr_estacion In xtb.Rows
                                            xestacion.M_CargarFicha(dr_estacion)
                                            Dim xhist As New HistorialComandas.c_Registro
                                            With xhist
                                                .M_Limpiar()

                                                .c_Auto._ContenidoCampo = ""
                                                .c_AutoEstacion._ContenidoCampo = xestacion.RegistroDato._Automatico
                                                .c_AutoItem._ContenidoCampo = xreg._AutoItem
                                                .c_AutoJornada._ContenidoCampo = xhistorial._FichaJornada._AutoJornada
                                                .c_AutoOperador._ContenidoCampo = xhistorial._FichaOperador._AutoOperador
                                                .c_AutoPlato._ContenidoCampo = xreg._AutoPlato
                                                .c_Cantidad._ContenidoCampo = xreg._CantidadDespachar
                                                .c_EsParallevar._ContenidoCampo = xreg.c_ParaLlevar._ContenidoCampo
                                                .c_EstatusEstacionEnvio._ContenidoCampo = xestacion.RegistroDato.c_Estatus._ContenidoCampo
                                                If xreg._f_FichaPlato._NotificaComanda Then
                                                    .c_EstatusPlatoEnvio._ContenidoCampo = "1"
                                                Else
                                                    .c_EstatusPlatoEnvio._ContenidoCampo = "0"
                                                End If
                                                .c_FechaProceso._ContenidoCampo = xhistorial._Fecha
                                                .c_MesoneroCodigo._ContenidoCampo = xreg._CodigoMesonero
                                                .c_MesoneroNombre._ContenidoCampo = xreg._Mesonero
                                                .c_MesPedido._ContenidoCampo = xreg._Mesa
                                                .c_NombreEstacion._ContenidoCampo = xestacion.RegistroDato._NombreEstacion
                                                .c_NombrePlato._ContenidoCampo = xreg._NombrePlato
                                                .c_NombreUsuario._ContenidoCampo = xhistorial._FichaUsuario._NombreUsuario
                                                .c_NotasDetalle._ContenidoCampo = xreg._DetallePlato
                                                .c_RutaEstacion._ContenidoCampo = xestacion.RegistroDato._RutaEstacion
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select a_rest_historial_comandas from contadores"
                                            If IsDBNull(xcmd.ExecuteScalar()) Then
                                                xcmd.CommandText = "update contadores set a_rest_historial_comandas=0"
                                                xcmd.ExecuteScalar()
                                            End If
                                            xcmd.CommandText = "update contadores set a_rest_historial_comandas=a_rest_historial_comandas+1;" & _
                                                                "select a_rest_historial_comandas from contadores"
                                            xhist.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = HistorialComandas.InsertarHistorialComanda
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_Auto._NombreCampo, xhist.c_Auto._ContenidoCampo).Size = xhist.c_Auto._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoEstacion._NombreCampo, xhist.c_AutoEstacion._ContenidoCampo).Size = xhist.c_AutoEstacion._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoItem._NombreCampo, xhist.c_AutoItem._ContenidoCampo).Size = xhist.c_AutoItem._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoJornada._NombreCampo, xhist.c_AutoJornada._ContenidoCampo).Size = xhist.c_AutoJornada._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoOperador._NombreCampo, xhist.c_AutoOperador._ContenidoCampo).Size = xhist.c_AutoOperador._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoPlato._NombreCampo, xhist.c_AutoPlato._ContenidoCampo).Size = xhist.c_AutoPlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_Cantidad._NombreCampo, xhist.c_Cantidad._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EsParallevar._NombreCampo, xhist.c_EsParallevar._ContenidoCampo).Size = xhist.c_EsParallevar._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusEstacionEnvio._NombreCampo, xhist.c_EstatusEstacionEnvio._ContenidoCampo).Size = xhist.c_EstatusEstacionEnvio._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusPlatoEnvio._NombreCampo, xhist.c_EstatusPlatoEnvio._ContenidoCampo).Size = xhist.c_EstatusPlatoEnvio._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_FechaProceso._NombreCampo, xhist.c_FechaProceso._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroCodigo._NombreCampo, xhist.c_MesoneroCodigo._ContenidoCampo).Size = xhist.c_MesoneroCodigo._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroNombre._NombreCampo, xhist.c_MesoneroNombre._ContenidoCampo).Size = xhist.c_MesoneroNombre._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesPedido._NombreCampo, xhist.c_MesPedido._ContenidoCampo).Size = xhist.c_MesPedido._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombreEstacion._NombreCampo, xhist.c_NombreEstacion._ContenidoCampo).Size = xhist.c_NombreEstacion._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombreUsuario._NombreCampo, xhist.c_NombreUsuario._ContenidoCampo).Size = xhist.c_NombreUsuario._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombrePlato._NombreCampo, xhist.c_NombrePlato._ContenidoCampo).Size = xhist.c_NombrePlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NotasDetalle._NombreCampo, xhist.c_NotasDetalle._ContenidoCampo).Size = xhist.c_NotasDetalle._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_RutaEstacion._NombreCampo, xhist.c_RutaEstacion._ContenidoCampo).Size = xhist.c_RutaEstacion._LargoCampo
                                            xcmd.ExecuteNonQuery()

                                            xlista.Add(xhist)
                                        Next
                                    End If

                                    'HISTORIAL DE COMANDAS
                                    Dim xsql As String = ""
                                    Dim xtb_notas As New DataTable
                                    If xreg._EsCombo = TipoSiNo.Si Then
                                        xsql = "select mp.auto xauto, (mc.cantidad * @cantidad) xcantidad, mp.nombre_plato xnombre, @detalle xdetalle, " & _
                                        " '' xauto_estacion, '' xnombre_estacion, '' xruta_estacion, '' xestatus_plato_envio, '' xestatus_estacion_envio " & _
                                        " from MenuPlatos_FastFood mp join MenuCombos_FastFood mc on mc.auto_plato = mp.auto " & _
                                        " where mc.auto_plato_combo=@auto_plato_combo"

                                        Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                                            xadap.SelectCommand.Parameters.AddWithValue("@cantidad", xreg._CantidadDespachar)
                                            xadap.SelectCommand.Parameters.AddWithValue("@detalle", xreg._DetallePlato)
                                            xadap.SelectCommand.Parameters.AddWithValue("@auto_plato_combo", xreg._AutoPlato)
                                            xadap.Fill(xtb_notas)
                                        End Using

                                        Dim xsql2 As String = "select e.auto xauto_estacion ,e.nombre xnombre_estacion," & _
                                                                      "e.ruta xruta_estacion,e.estatus xestatus_estacion, me.estatus xestatus_envio_plato " & _
                                                                      "from Estacion_FastFood e join MenuEstaciones_FastFood me on e.auto=me.auto_estacion " & _
                                                                      "join MenuPlatos_FastFood mp on mp.auto=me.auto_plato where mp.auto=@auto_plato"
                                        Dim xtb_envio As New DataTable
                                        For Each dr As DataRow In xtb_notas.AsEnumerable
                                            xtb_envio.Rows.Clear()
                                            Using xadap As New SqlDataAdapter(xsql2, _MiCadenaConexion)
                                                xadap.SelectCommand.Parameters.Clear()
                                                xadap.SelectCommand.Parameters.AddWithValue("@auto_plato", dr.Field(Of String)("xauto"))
                                                xadap.Fill(xtb_envio)
                                            End Using
                                            If xtb_envio.Rows.Count > 0 Then
                                                dr.SetField(Of String)("xauto_estacion", xtb_envio(0).Field(Of String)("xauto_estacion"))
                                                dr.SetField(Of String)("xnombre_estacion", xtb_envio(0).Field(Of String)("xnombre_estacion"))
                                                dr.SetField(Of String)("xruta_estacion", xtb_envio(0).Field(Of String)("xruta_estacion"))
                                                dr.SetField(Of String)("xestatus_plato_envio", xtb_envio(0).Field(Of String)("xestatus_envio_plato"))
                                                dr.SetField(Of String)("xestatus_estacion_envio", xtb_envio(0).Field(Of String)("xestatus_estacion"))
                                            End If
                                        Next
                                        xtb_notas.AcceptChanges()

                                        For Each xdata In xtb_notas.Rows
                                            Dim xhist As New HistorialComandas.c_Registro
                                            With xhist
                                                .M_Limpiar()

                                                .c_Auto._ContenidoCampo = ""
                                                .c_AutoEstacion._ContenidoCampo = xdata("xauto_estacion")
                                                .c_AutoItem._ContenidoCampo = xreg._AutoItem
                                                .c_AutoJornada._ContenidoCampo = xhistorial._FichaJornada._AutoJornada
                                                .c_AutoOperador._ContenidoCampo = xhistorial._FichaOperador._AutoOperador
                                                .c_AutoPlato._ContenidoCampo = xdata("xauto")
                                                .c_Cantidad._ContenidoCampo = xdata("xcantidad")
                                                .c_EsParallevar._ContenidoCampo = xreg.c_ParaLlevar._ContenidoCampo
                                                .c_EstatusEstacionEnvio._ContenidoCampo = xdata("xestatus_plato_envio")
                                                If xreg._f_FichaPlato._NotificaComanda Then
                                                    .c_EstatusPlatoEnvio._ContenidoCampo = "1"
                                                Else
                                                    .c_EstatusPlatoEnvio._ContenidoCampo = "0"
                                                End If
                                                .c_FechaProceso._ContenidoCampo = xhistorial._Fecha
                                                .c_MesoneroCodigo._ContenidoCampo = xreg._CodigoMesonero
                                                .c_MesoneroNombre._ContenidoCampo = xreg._Mesonero
                                                .c_MesPedido._ContenidoCampo = xreg._Mesa
                                                .c_NombreEstacion._ContenidoCampo = xdata("xnombre_estacion")
                                                .c_NombrePlato._ContenidoCampo = xdata("xnombre")
                                                .c_NombreUsuario._ContenidoCampo = xhistorial._FichaUsuario._NombreUsuario
                                                .c_NotasDetalle._ContenidoCampo = xdata("xdetalle")
                                                .c_RutaEstacion._ContenidoCampo = xdata("xruta_estacion")
                                            End With

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = "select a_rest_historial_comandas from contadores"
                                            If IsDBNull(xcmd.ExecuteScalar()) Then
                                                xcmd.CommandText = "update contadores set a_rest_historial_comandas=0"
                                                xcmd.ExecuteScalar()
                                            End If
                                            xcmd.CommandText = "update contadores set a_rest_historial_comandas=a_rest_historial_comandas+1;" & _
                                                                "select a_rest_historial_comandas from contadores"
                                            xhist.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = HistorialComandas.InsertarHistorialComanda
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_Auto._NombreCampo, xhist.c_Auto._ContenidoCampo).Size = xhist.c_Auto._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoEstacion._NombreCampo, xhist.c_AutoEstacion._ContenidoCampo).Size = xhist.c_AutoEstacion._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoItem._NombreCampo, xhist.c_AutoItem._ContenidoCampo).Size = xhist.c_AutoItem._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoJornada._NombreCampo, xhist.c_AutoJornada._ContenidoCampo).Size = xhist.c_AutoJornada._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoOperador._NombreCampo, xhist.c_AutoOperador._ContenidoCampo).Size = xhist.c_AutoOperador._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_AutoPlato._NombreCampo, xhist.c_AutoPlato._ContenidoCampo).Size = xhist.c_AutoPlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_Cantidad._NombreCampo, xhist.c_Cantidad._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EsParallevar._NombreCampo, xhist.c_EsParallevar._ContenidoCampo).Size = xhist.c_EsParallevar._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusEstacionEnvio._NombreCampo, xhist.c_EstatusEstacionEnvio._ContenidoCampo).Size = xhist.c_EstatusEstacionEnvio._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_EstatusPlatoEnvio._NombreCampo, xhist.c_EstatusPlatoEnvio._ContenidoCampo).Size = xhist.c_EstatusPlatoEnvio._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_FechaProceso._NombreCampo, xhist.c_FechaProceso._ContenidoCampo)
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroCodigo._NombreCampo, xhist.c_MesoneroCodigo._ContenidoCampo).Size = xhist.c_MesoneroCodigo._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesoneroNombre._NombreCampo, xhist.c_MesoneroNombre._ContenidoCampo).Size = xhist.c_MesoneroNombre._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_MesPedido._NombreCampo, xhist.c_MesPedido._ContenidoCampo).Size = xhist.c_MesPedido._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombreEstacion._NombreCampo, xhist.c_NombreEstacion._ContenidoCampo).Size = xhist.c_NombreEstacion._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombreUsuario._NombreCampo, xhist.c_NombreUsuario._ContenidoCampo).Size = xhist.c_NombreUsuario._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NombrePlato._NombreCampo, xhist.c_NombrePlato._ContenidoCampo).Size = xhist.c_NombrePlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_NotasDetalle._NombreCampo, xhist.c_NotasDetalle._ContenidoCampo).Size = xhist.c_NotasDetalle._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + xhist.c_RutaEstacion._NombreCampo, xhist.c_RutaEstacion._ContenidoCampo).Size = xhist.c_RutaEstacion._LargoCampo
                                            xcmd.ExecuteNonQuery()

                                            xlista.Add(xhist)
                                        Next
                                    End If
                                Next
                            End Using
                            xtr.Commit()

                            RaiseEvent _HistorialComandaOK()
                            RaiseEvent _HistorialComandaLista(xlista)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("AGREGAR AL HISTORIAL COMANDA - RESTAURANT" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_RetornarListaHistorial(ByVal xauto_item As String) As List(Of HistorialComandas.c_Registro)
                Try
                    Dim xtb As New DataTable
                    Dim xlist As New List(Of HistorialComandas.c_Registro)

                    Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.Clear()
                        xadap.SelectCommand.CommandText = "select * from rest_historialcomandas where auto_item=@item"
                        xadap.SelectCommand.Parameters.AddWithValue("@item", xauto_item)
                        xadap.Fill(xtb)
                    End Using

                    For Each dr In xtb.Rows
                        Dim xreg As New HistorialComandas
                        xreg.M_CargarRegistro(dr)
                        xlist.Add(xreg.RegistroDato)
                    Next

                    Return xlist
                Catch ex As Exception
                    Throw New Exception("LISTA HISTORIAL COMANDA" + vbCrLf + ex.Message)
                End Try

            End Function

            Function F_GrabarVentaRestaurant(ByVal xventa As AgregarVenta _
                                            , ByVal impfiscal As IFiscal _
                                            , ByVal xpagos As List(Of FormaPago) _
                                            , Optional ByVal xmodo As ModoFactura = ModoFactura.Legal) As Boolean
                Try
                    Dim xsql_1 As String = "update contadores set a_ventas=a_ventas+1; select a_ventas from contadores"
                    Dim xsql_2 As String = "update contadores set a_cxc=a_cxc+1; select a_cxc from contadores"
                    Dim xsql_3 As String = "update series_fiscales set correlativo=correlativo+1, estatus_fiscal='1' where nombre=@nombre;" _
                                         + "select correlativo from series_fiscales where nombre=@nombre"
                    Dim xsql_4 As String = "update contadores set a_historialcomandas_fastfood=a_historialcomandas_fastfood+1; select a_historialcomandas_fastfood from contadores"

                    Dim autocxc As String = ""
                    Dim xtr As SqlTransaction = Nothing
                    Dim xfiscal As New FichaGlobal.c_SeriesFiscales

                    Dim xtb As New DataTable
                    If xmodo = ModoFactura.Legal Then
                        Using xadap As New SqlDataAdapter("select * from series_fiscales where nombre=@nombre", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            xfiscal.M_CargarFicha(xtb(0))
                        Else
                            Throw New Exception("ERROR... SERIE NO REGISTRADA, VERIFIQUE")
                        End If
                    End If

                    If impfiscal IsNot Nothing Then
                        If xfiscal.RegistroDato.r_SerialFiscal <> impfiscal.Ver_SerialImpresoraFiscal Then
                            Throw New Exception("ERROR... SERIAL FISCAL NO COINCIDE CON EL SERIAL DE LA IMPRESORA A GENERAR DOCUMENTO, VERIFIQUE")
                        End If
                    End If

                    If xmodo = ModoFactura.Legal Then
                        If xfiscal.RegistroDato.r_EstatusSerie = TipoEstatus.Activo Then
                            If xfiscal.RegistroDato.r_EstatusParaVentas = TipoEstatus.Inactivo Then
                                Throw New Exception("ERROR... SERIE NO ASIGNADA PARA EFECTUAR VENTAS, VERIFIQUE")
                            End If
                        Else
                            Throw New Exception("ERROR... SERIE ESTA EN ESTADO INACTVIO, VERIFIQUE")
                        End If
                    End If


                    Dim xtb_venta As New FichaVentas.V_Ventas.c_Registro
                    Dim xservicio As New FastFood.VentasDetalle_FastFood.c_Registro

                    With xtb_venta
                        .c_AnoRelacion.c_Texto = xventa._Encabezado._AnoRelacion
                        .c_AutoCliente.c_Texto = xventa._Encabezado._Cliente.r_Automatico
                        .c_AutoDocumento.c_Texto = ""
                        .c_AutomaticoJornada.c_Texto = xventa._Encabezado._Jornada
                        .c_AutomaticoOperador.c_Texto = xventa._Encabezado._Operador
                        .c_AutoRecibo.c_Texto = ""
                        .c_AutoUsuario.c_Texto = xventa._Encabezado._Usuario._AutoUsuario
                        .c_AutoVendedor.c_Texto = xventa._Encabezado._Vendedor.r_Automatico
                        .c_Base.c_Valor = xventa._Encabezado._Base
                        .c_Base1.c_Valor = xventa._Encabezado._MontoBase1
                        .c_Base2.c_Valor = xventa._Encabezado._MontoBase2
                        .c_Base3.c_Valor = xventa._Encabezado._MontoBase3
                        .c_BloquearAlmacen.c_Texto = xventa._Encabezado._BloquearAlmacen
                        .c_CantidadRenglones.c_Valor = xventa._Encabezado._Renglones
                        .c_CiRifCliente.c_Texto = xventa._Encabezado._Cliente.r_CiRif
                        .c_CodigoCliente.c_Texto = xventa._Encabezado._Cliente.r_CodigoCliente
                        .c_CodigoSucursal.c_Texto = xventa._Encabezado._Sucursal
                        .c_CodigoTransporte.c_Texto = ""
                        .c_CodigoUsuario.c_Texto = xventa._Encabezado._Usuario._CodigoUsuario
                        .c_CodigoVendedor.c_Texto = xventa._Encabezado._Vendedor.r_CodigoVendedor
                        .c_ComprobanteRetencion.c_Texto = ""
                        .c_ComprobanteRetencionISLR.c_Texto = ""
                        .c_CondicionPago.c_Texto = IIf(xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado, "CONTADO", "CREDITO")
                        .c_ControlFiscal.c_Texto = ""
                        .c_DiasCreditoCliente.c_Valor = xventa._Encabezado._DiasCredito
                        .c_DirDespacho.c_Texto = xventa._Encabezado._Cliente.r_DirDespacho
                        .c_DirFiscalCliente.c_Texto = xventa._Encabezado._Cliente.r_DirFiscal
                        .c_Documento.c_Texto = ""
                        .c_DocumentoAplica.c_Texto = ""
                        .c_EstacionEquipo.c_Texto = xventa._Encabezado._EstacionEquipo
                        .c_EstatusDocumento.c_Texto = xventa._Encabezado._Estatus
                        .c_Exento.c_Valor = xventa._Encabezado._Exento
                        .c_FactorCambio.c_Valor = xventa._Encabezado._FactorCambio
                        .c_FechaEmision.c_Valor = xventa._Encabezado._FechaEmision
                        .c_FechaPedido.c_Valor = xventa._Encabezado._FechaEmision
                        .c_FechaRelacion.c_Valor = xventa._Encabezado._FechaEmision
                        .c_FechaVencimiento.c_Valor = xventa._Encabezado._FechaVencimiento
                        .c_Hora.c_Texto = xventa._Encabezado._Hora
                        .c_Impuesto.c_Valor = xventa._Encabezado._Impuesto
                        .c_Impuesto1.c_Valor = xventa._Encabezado._Impuesto1
                        .c_Impuesto2.c_Valor = xventa._Encabezado._Impuesto2
                        .c_Impuesto3.c_Valor = xventa._Encabezado._Impuesto3
                        .c_MesRelacion.c_Texto = xventa._Encabezado._MesRelacion
                        .c_MontoCargo.c_Valor = xventa._Encabezado._MontoCargoNeto
                        .c_MontoDescuento_1.c_Valor = xventa._Encabezado._MontoDescuentoNeto
                        .c_MontoDescuento_2.c_Valor = 0
                        .c_MontoDivisa.c_Valor = xventa._Encabezado._MontoDivisa
                        .c_MontoSaldoPendiente.c_Valor = xventa._Encabezado._SaldoPendiente
                        .c_MontoSubTotal.c_Valor = xventa._Encabezado._SubTotalGeneralSinDescuentoNiCargos
                        .c_NombreCliente.c_Texto = xventa._Encabezado._Cliente.r_NombreRazonSocial
                        .c_NombreDespachador.c_Texto = ""
                        .c_NombreVendedor.c_Texto = xventa._Encabezado._Vendedor.r_NombreVendedor
                        .c_NotasDocumento.c_Texto = ""
                        .c_NumeroPedido.c_Texto = ""
                        .c_NumeroRecibo.c_Texto = ""
                        .c_OrdenCompra.c_Texto = ""
                        .c_RetencionISLR.c_Valor = 0
                        .c_RetencionIva.c_Valor = 0
                        If impfiscal IsNot Nothing Then
                            .c_SerialImpresoraFiscal.c_Texto = impfiscal.Ver_SerialImpresoraFiscal
                        Else
                            .c_SerialImpresoraFiscal.c_Texto = ""
                        End If
                        .c_SerialUnico_Jornada.c_Texto = ""
                        If xmodo = ModoFactura.Legal Then
                            .c_SerieAsignada.c_Texto = xventa._Encabezado._Serie
                        Else
                            .c_SerieAsignada.c_Texto = ""
                        End If
                        .c_Tasa1.c_Valor = xventa._Encabezado._TasaIva1
                        .c_Tasa2.c_Valor = xventa._Encabezado._TasaIva2
                        .c_Tasa3.c_Valor = xventa._Encabezado._TasaIva3
                        .c_TasaCargos.c_Valor = xventa._Encabezado._TasaCargo
                        .c_TasaDescuento_1.c_Valor = xventa._Encabezado._TasaDescuento
                        .c_TasaDescuento_2.c_Valor = 0
                        .c_TasaRetencionISLR.c_Valor = 0
                        .c_TasaRetencionIva.c_Valor = 0
                        .c_TelefonoCliente.c_Texto = xventa._Encabezado._Cliente.r_Telefono_1
                        .c_TipoColumna.c_Texto = xventa._Encabezado._TipoColumna
                        .c_TipoDocumento.c_Texto = xventa._Encabezado._TipoDocumento
                        .c_TotalGeneral.c_Valor = xventa._Encabezado._TotalGeneral
                        .c_Transporte.c_Texto = ""
                        .c_Usuario.c_Texto = xventa._Encabezado._Usuario._NombreUsuario
                        .c_ValidezDocumentoDias.c_Valor = 0
                        .c_OrigenDocumento.c_Texto = "05"
                        If xventa._Encabezado._TipoMesaPedido = TipoPedido.ParaMesa Then
                            .c_Rest_ModoMesaPedido.c_Texto = "M"
                        Else
                            .c_Rest_ModoMesaPedido.c_Texto = "P"
                        End If
                        .c_Rest_NumeroMesaPedido.c_Texto = xventa._Encabezado._NumeroMesaPedido
                        .c_Rest_ServicioMonto.c_Valor = xventa._Encabezado._MontoServicio
                        .c_Rest_ServicioTasa.c_Valor = xventa._Encabezado._TasaServicio
                        .c_Relacion_Z.c_Valor = 0
                    End With

                    'Tabla Usada Para Lista De Productos Para La Impresora Fiscal
                    Dim xtablaprd As New DataTable
                    With xtablaprd
                        .Columns.Add("cantidad", GetType(System.Decimal))
                        .Columns.Add("nombre", GetType(System.String))
                        .Columns.Add("codigo", GetType(System.String))
                        .Columns.Add("precio_neto", GetType(System.Decimal))
                        .Columns.Add("codigo_tasa", GetType(System.String))
                    End With

                    Dim i As Integer = 0
                    Dim xdetalles As New List(Of FastFood.VentasDetalle_FastFood.c_Registro)
                    Dim xhistorial As New List(Of FastFood.HistorialComandas_FastFood.c_Registro)
                    Dim xlistakardex As New List(Of FichaProducto.Prd_Kardex.c_Registro)

                    For Each xitem In xventa._Detalles
                        i += 1
                        Dim xventadetallefastfood As New FastFood.VentasDetalle_FastFood.c_Registro

                        With xventadetallefastfood
                            ._ItemOrigenTablaTemporal = xitem._AutoItem  'solo para hacer el vinculo con tabla rest_historialcomandas

                            .c_AutoCliente._ContenidoCampo = xventa._Encabezado._Cliente.r_Automatico
                            .c_AutoDocumento._ContenidoCampo = ""
                            .c_AutoGrupo._ContenidoCampo = xitem._f_FichaPlato._AutoGrupo
                            .c_AutoItem._ContenidoCampo = i.ToString.Trim.PadLeft(10, "0")
                            .c_AutoItemOrigen._ContenidoCampo = ""
                            .c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                            .c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                            .c_AutoPlato._ContenidoCampo = xitem._f_FichaPlato._Automatico
                            .c_CantidadDespachada._ContenidoCampo = xitem._CantidadDespachar
                            .c_CodigoPlato._ContenidoCampo = xitem._f_FichaPlato._CodigoPlato
                            .c_CostoNeto._ContenidoCampo = xitem._CostoNeto
                            .c_CostoTotalNeto._ContenidoCampo = xitem._CostoTotalNeto
                            .c_EnOferta._ContenidoCampo = xitem.c_EsOferta._ContenidoCampo
                            .c_EsPesado._ContenidoCampo = xitem.c_EsPesado._ContenidoCampo
                            .c_Estatus._ContenidoCampo = "0"
                            .c_FechaEmision._ContenidoCampo = xventa._Encabezado._FechaEmision
                            .c_MontoIva._ContenidoCampo = 0
                            .c_NombrePlato._ContenidoCampo = xitem._f_FichaPlato._NombrePlato
                            .c_NotasItem._ContenidoCampo = xitem._DetallePlato
                            .c_PrecioFinal._ContenidoCampo = 0
                            .c_PrecioNeto._ContenidoCampo = xitem._PrecioNeto._Base
                            .c_SignoDocumento._ContenidoCampo = 1
                            .c_TasaIva._ContenidoCampo = xitem._TasaIva
                            .c_TipoCalculoUtilidad._ContenidoCampo = IIf(xventa._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto, "C", "V")
                            .c_TipoDocumento._ContenidoCampo = "01"
                            .c_TipoItem._ContenidoCampo = "1"
                            .c_TipoMovimiento._ContenidoCampo = "V"
                            Select Case xitem._TipoTasa
                                Case TipoTasaImpuesto.Exento : .c_TipoTasaIva._ContenidoCampo = "0"
                                Case TipoTasaImpuesto.Vigente : .c_TipoTasaIva._ContenidoCampo = "1"
                                Case TipoTasaImpuesto.Reducida : .c_TipoTasaIva._ContenidoCampo = "2"
                                Case TipoTasaImpuesto.Otra : .c_TipoTasaIva._ContenidoCampo = "3"
                            End Select
                            .c_TotalGeneral._ContenidoCampo = 0
                            .c_TotalNeto._ContenidoCampo = 0
                            .c_UtilidadMonto._ContenidoCampo = 0
                            .c_UtilidadTasa._ContenidoCampo = 0
                            .c_EsCombo._ContenidoCampo = xitem.c_EsCombo._ContenidoCampo
                            .c_Rest_AutoMesonero._ContenidoCampo = xitem._AutoMesonero
                            .c_Rest_CodigoMesonero._ContenidoCampo = xitem._CodigoMesonero
                            .c_Rest_NombreMesonero._ContenidoCampo = xitem._Mesonero

                            Dim x0 As Decimal = xitem._PrecioNeto._Base
                            Dim x1 As Decimal = Decimal.Round(x0 * xitem._CantidadDespachar, 2, MidpointRounding.AwayFromZero)
                            .c_TotalNeto._ContenidoCampo = x1
                            Dim x2 As Decimal = Decimal.Round(x1 * xitem._TasaIva / 100, 2, MidpointRounding.AwayFromZero)
                            .c_MontoIva._ContenidoCampo = x2
                            .c_TotalGeneral._ContenidoCampo = Decimal.Round(x1 + x2, 2, MidpointRounding.AwayFromZero)
                            Dim x4 As Decimal = x0
                            x4 = Decimal.Round(x4 - (x4 * xventa._Encabezado._TasaDescuento / 100), 2, MidpointRounding.AwayFromZero)
                            x4 = Decimal.Round(x4 + (x4 * xventa._Encabezado._TasaCargo / 100), 2, MidpointRounding.AwayFromZero)
                            .c_PrecioFinal._ContenidoCampo = x4
                            Dim x5 As Decimal = x4 * ._CantidadDespachada
                            Dim x6 As Decimal = Decimal.Round((xitem._CostoNeto * xitem._CantidadDespachar), 2, MidpointRounding.AwayFromZero)
                            .c_UtilidadMonto._ContenidoCampo = Decimal.Round(x5 - x6, 2, MidpointRounding.AwayFromZero)
                            If ._TipoCalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto Then
                                .c_UtilidadTasa._ContenidoCampo = UtilidadBaseCosto(x6, ._UtilidadMonto)
                            Else
                                .c_UtilidadTasa._ContenidoCampo = UtilidadBasePrecioVenta(x5, ._UtilidadMonto)
                            End If

                            If ._UtilidadMonto >= 0 Then
                            Else
                                Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO POR DEBAJO DEL COSTO" + vbCrLf + ._NombrePlato)
                            End If

                            If xitem._f_FichaPlato._EstatusPlato = TipoEstatus.Activo Then
                            Else
                                Throw New Exception("ERROR AL PROCESAR ITEM" + vbCrLf + "PRODUCTO/PLATO INACTIVO" + vbCrLf + ._NombrePlato)
                            End If
                        End With
                        xdetalles.Add(xventadetallefastfood)


                        'SACO TODOS LOS PLATOS QUE COMPONEN EL COMBO ADEMAS DEL MISMO PLATO, SI ES QUE ES COMBO
                        Dim xtb_notas As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            xadap.SelectCommand.CommandText = "select auto auto_plato from menuplatos_fastfood where auto=@AUTO UNION " & _
                                                              "select auto_plato from MenuCombos_FastFood where auto_plato_combo=@AUTO"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xitem._AutoPlato)
                            xadap.Fill(xtb_notas)
                        End Using


                        'LISTA DE KARDEX PARA PLATOS QUE TRABAJAN CON INVENTARIO
                        For Each dr_notas As DataRow In xtb_notas.Rows
                            Dim xtb_inv As New DataTable
                            Dim xsql_inv As String = "select * from menuplatoinventario where auto_plato=@plato"
                            Using xadap As New SqlDataAdapter(xsql_inv, _MiCadenaConexion)
                                xadap.SelectCommand.Parameters.AddWithValue("@plato", dr_notas("auto_plato"))
                                xadap.Fill(xtb_inv)
                            End Using
                            Dim xplatoinv As New FastFood.PlatosInventario.c_Registro
                            For Each xdr As DataRow In xtb_inv.Rows
                                xplatoinv.M_Limpiar()
                                xplatoinv.CargarRegistro(xdr)

                                Dim xitemkardex As New FichaProducto.Prd_Kardex.c_Registro
                                With xitemkardex
                                    .c_AutoConcepto.c_Texto = ""
                                    .c_AutoDeposito.c_Texto = xventa._FichaDeposito._Automatico
                                    .c_AutoDocumento.c_Texto = ""
                                    .c_AutoProducto.c_Texto = xplatoinv._Producto._AutoProducto
                                    .c_CantidadMover.c_Valor = xplatoinv._CantRequerida * xitem._CantidadDespachar
                                    .c_CantidadUnidadesMover.c_Valor = xplatoinv._CantRequerida * xplatoinv._ContenidoEmpaque * xitem._CantidadDespachar
                                    .c_Documento.c_Texto = ""
                                    .c_Entidad.c_Texto = xventa._Encabezado._Cliente.r_NombreRazonSocial
                                    .c_Estatus.c_Texto = xventa._Encabezado._Estatus
                                    .c_FechaEmision.c_Valor = xventa._Encabezado._FechaEmision
                                    .c_NotasDetallesMovimiento.c_Texto = ""
                                    .c_OrigenMovimiento.c_Texto = "0801"
                                    .c_ReferenciaEmpaque.c_Texto = "5"
                                    .c_TipoMovimiento.c_Valor = TipoMovimientoInventario.Salida
                                    .c_NombreProducto.c_Texto = xplatoinv._Producto._DescripcionDetallaDelProducto
                                    .c_NombreDeposito.c_Texto = xventa._FichaDeposito._Nombre
                                    .c_NombreConcepto.c_Texto = ""
                                    .c_NombreMedidaEmpaque.c_Texto = xplatoinv._MedidaEmpaque._NombreMedida
                                    .c_AutoMedida.c_Texto = xplatoinv._MedidaEmpaque._Automatico
                                    .c_ContenidoMedidaEmpaque.c_Valor = xplatoinv._ContenidoEmpaque
                                    .c_CodigoProducto.c_Texto = xplatoinv._Producto._CodigoProducto
                                    .c_CodigoDeposito.c_Texto = xventa._FichaDeposito._Codigo
                                    .c_CodigoConcepto.c_Texto = "VENTAS"

                                    ._FastFood_ItemVenta = i.ToString.Trim.PadLeft(10, "0")
                                    ._FastFood_CantidadRequerida = xplatoinv._CantRequerida
                                End With
                                xlistakardex.Add(xitemkardex)
                            Next
                        Next
                    Next

                    'EN CASE DE SER UNA MESA, AGREGAR ITEM SERVICIO DE LA MESA
                    If xventa._Encabezado._TipoMesaPedido = TipoPedido.ParaMesa Then
                        With xservicio
                            .c_AutoCliente._ContenidoCampo = xventa._Encabezado._Cliente.r_Automatico
                            .c_AutoDocumento._ContenidoCampo = ""
                            .c_AutoGrupo._ContenidoCampo = "GROUP00001"
                            .c_AutoItem._ContenidoCampo = i.ToString.Trim.PadLeft(10, "0")
                            .c_AutoItemOrigen._ContenidoCampo = ""
                            .c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                            .c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                            .c_AutoPlato._ContenidoCampo = "SERV000001"
                            .c_CantidadDespachada._ContenidoCampo = 1
                            .c_CodigoPlato._ContenidoCampo = ""
                            .c_CostoNeto._ContenidoCampo = 0
                            .c_CostoTotalNeto._ContenidoCampo = 0
                            .c_EnOferta._ContenidoCampo = "0"
                            .c_EsPesado._ContenidoCampo = "0"
                            .c_Estatus._ContenidoCampo = "0"
                            .c_FechaEmision._ContenidoCampo = xventa._Encabezado._FechaEmision
                            .c_MontoIva._ContenidoCampo = 0
                            .c_NombrePlato._ContenidoCampo = "SERVICIO A LE MESA (" + String.Format("{0:#0.00}", xventa._Encabezado._TasaServicio) + "%)"
                            .c_NotasItem._ContenidoCampo = ""
                            .c_PrecioFinal._ContenidoCampo = xventa._Encabezado._MontoServicio
                            .c_PrecioNeto._ContenidoCampo = xventa._Encabezado._MontoServicio
                            .c_SignoDocumento._ContenidoCampo = 1
                            .c_TasaIva._ContenidoCampo = 0
                            .c_TipoCalculoUtilidad._ContenidoCampo = ""
                            .c_TipoDocumento._ContenidoCampo = "01"
                            .c_TipoItem._ContenidoCampo = "1"
                            .c_TipoMovimiento._ContenidoCampo = "V"
                            .c_TipoTasaIva._ContenidoCampo = "0"
                            .c_TotalGeneral._ContenidoCampo = xventa._Encabezado._MontoServicio
                            .c_TotalNeto._ContenidoCampo = xventa._Encabezado._MontoServicio
                            .c_UtilidadMonto._ContenidoCampo = 0
                            .c_UtilidadTasa._ContenidoCampo = 0
                            .c_EsCombo._ContenidoCampo = "0"
                            .c_Rest_AutoMesonero._ContenidoCampo = ""
                            .c_Rest_CodigoMesonero._ContenidoCampo = ""
                            .c_Rest_NombreMesonero._ContenidoCampo = ""
                        End With
                    End If


                    'VERIFICO LIMITE DE DOCUMENTOS DEL CLIENTE / LIMITE DE CREDITO
                    If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Credito Then
                        Dim xcliente As New FichaClientes
                        xcliente.F_BuscarCliente(xventa._Encabezado._Cliente.r_Automatico)
                        If (xcliente.f_Clientes.RegistroDato.r_LimiteCreditoPermitido = 0) Or _
                           (xcliente.f_Clientes.RegistroDato.r_CreditoDisponible >= xventa._Encabezado._TotalGeneral) Then
                            If xcliente.f_Clientes.RegistroDato.r_CantDocPendPermitidos > 0 Then
                                If (xcliente.f_Clientes.RegistroDato.r_CantidadDocPendientes + 1) > xcliente.f_Clientes.RegistroDato.r_CantDocPendPermitidos Then
                                    Throw New Exception("ERROR... CLIENTE SOBREPASA SU LIMITE DE DOCUMENTOS PENDIENTES DE CREDITO, VERIFIQUE")
                                End If
                            End If
                        Else
                            Throw New Exception("ERROR... CLIENTE SOBREPASA SU LIMITE DE CREDITO, VERIFIQUE")
                        End If
                    End If

                    '
                    ' ARRANCA EL PROCEDIMIENTO DE GRABAR
                    '
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                'ACTUALIZO CONTADOR AUTOMATICO DE VENTAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_1
                                xtb_venta.c_AutoDocumento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                'ACTUALIZA CONTADOR AUTOMATICO CXC
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_2
                                autocxc = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                If xmodo = ModoFactura.Legal Then
                                    'ACTUALIZA CORRELATIVO DE SERIES FISCALES
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3
                                    xcmd.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                                    xtb_venta.c_Documento.c_Texto = xventa._Encabezado._Serie + _
                                                     xcmd.ExecuteScalar().ToString.Trim.PadLeft(10 - xventa._Encabezado._Serie.Length, "0")
                                Else
                                    'ACTUALIZA CORRELATIVO FACTURAS CHIMBA
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_chimbo from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_chimbo=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.CommandText = "update CONTADORES set a_chimbo=a_chimbo+1;" _
                                         + "select a_chimbo from contadores"
                                    xtb_venta.c_Documento.c_Texto = "PED" + xcmd.ExecuteScalar().ToString.Trim.PadLeft(7, "0")
                                    xtb_venta.c_TipoDocumento.c_Texto = "XX"
                                End If

                                'VENTAS
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaVentas.INSERT_VENTAS_POS
                                xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto).Size = xtb_venta.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xtb_venta.c_Documento.c_Texto).Size = xtb_venta.c_Documento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xtb_venta.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xtb_venta.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@nombre", xtb_venta.c_NombreCliente.c_Texto).Size = xtb_venta.c_NombreCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_fiscal", xtb_venta.c_DirFiscalCliente.c_Texto).Size = xtb_venta.c_DirFiscalCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xtb_venta.c_CiRifCliente.c_Texto).Size = xtb_venta.c_CiRifCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@tipo", xtb_venta.c_TipoDocumento.c_Texto).Size = xtb_venta.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@exento", xtb_venta.c_Exento.c_Valor)
                                xcmd.Parameters.AddWithValue("@base1", xtb_venta.c_Base1.c_Valor)
                                xcmd.Parameters.AddWithValue("@base2", xtb_venta.c_Base2.c_Valor)
                                xcmd.Parameters.AddWithValue("@base3", xtb_venta.c_Base3.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto1", xtb_venta.c_Impuesto1.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto2", xtb_venta.c_Impuesto2.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto3", xtb_venta.c_Impuesto3.c_Valor)
                                xcmd.Parameters.AddWithValue("@base", xtb_venta.c_Base.c_Valor)
                                xcmd.Parameters.AddWithValue("@impuesto", xtb_venta.c_Impuesto.c_Valor)
                                xcmd.Parameters.AddWithValue("@total", xtb_venta.c_TotalGeneral.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa1", xtb_venta.c_Tasa1.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa2", xtb_venta.c_Tasa2.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa3", xtb_venta.c_Tasa3.c_Valor)
                                xcmd.Parameters.AddWithValue("@nota", xtb_venta.c_NotasDocumento.c_Texto).Size = xtb_venta.c_NotasDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@tasa_retencion_iva", xtb_venta.c_TasaRetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@tasa_retencion_islr", xtb_venta.c_TasaRetencionISLR.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_iva", xtb_venta.c_RetencionIva.c_Valor)
                                xcmd.Parameters.AddWithValue("@retencion_islr", xtb_venta.c_RetencionISLR.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_entidad", xtb_venta.c_AutoCliente.c_Texto).Size = xtb_venta.c_AutoCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_entidad", xtb_venta.c_CodigoCliente.c_Texto).Size = xtb_venta.c_CodigoCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@mes_relacion", xtb_venta.c_MesRelacion.c_Texto).Size = xtb_venta.c_MesRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@control", xtb_venta.c_ControlFiscal.c_Texto).Size = xtb_venta.c_ControlFiscal.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_relacion", xtb_venta.c_FechaRelacion.c_Valor)
                                xcmd.Parameters.AddWithValue("@orden_compra", xtb_venta.c_OrdenCompra.c_Texto).Size = xtb_venta.c_OrdenCompra.c_Largo
                                xcmd.Parameters.AddWithValue("@dias", xtb_venta.c_DiasCreditoCliente.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1", xtb_venta.c_MontoDescuento_1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2", xtb_venta.c_MontoDescuento_2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos", xtb_venta.c_MontoCargo.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento1_porcentaje", xtb_venta.c_TasaDescuento_1.c_Valor)
                                xcmd.Parameters.AddWithValue("@descuento2_porcentaje", xtb_venta.c_TasaDescuento_2.c_Valor)
                                xcmd.Parameters.AddWithValue("@cargos_porcentaje", xtb_venta.c_TasaCargos.c_Valor)
                                xcmd.Parameters.AddWithValue("@columna", xtb_venta.c_TipoColumna.c_Texto).Size = xtb_venta.c_TipoColumna.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xtb_venta.c_EstatusDocumento.c_Texto).Size = xtb_venta.c_EstatusDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@aplica", xtb_venta.c_DocumentoAplica.c_Texto).Size = xtb_venta.c_DocumentoAplica.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion", xtb_venta.c_ComprobanteRetencion.c_Texto).Size = xtb_venta.c_ComprobanteRetencion.c_Largo
                                xcmd.Parameters.AddWithValue("@subtotal", xtb_venta.c_MontoSubTotal.c_Valor)
                                xcmd.Parameters.AddWithValue("@telefono", xtb_venta.c_TelefonoCliente.c_Texto).Size = xtb_venta.c_TelefonoCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@factor_cambio", xtb_venta.c_FactorCambio.c_Valor)
                                xcmd.Parameters.AddWithValue("@codigo_vendedor", xtb_venta.c_CodigoVendedor.c_Texto).Size = xtb_venta.c_CodigoVendedor.c_Largo
                                xcmd.Parameters.AddWithValue("@vendedor", xtb_venta.c_NombreVendedor.c_Texto).Size = xtb_venta.c_NombreVendedor.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_vendedor", xtb_venta.c_AutoVendedor.c_Texto).Size = xtb_venta.c_AutoVendedor.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_pedido", xtb_venta.c_FechaPedido.c_Valor)
                                xcmd.Parameters.AddWithValue("@pedido", xtb_venta.c_NumeroPedido.c_Texto).Size = xtb_venta.c_NumeroPedido.c_Largo
                                xcmd.Parameters.AddWithValue("@condicion_pago", xtb_venta.c_CondicionPago.c_Texto).Size = xtb_venta.c_CondicionPago.c_Largo
                                xcmd.Parameters.AddWithValue("@usuario", xtb_venta.c_Usuario.c_Texto).Size = xtb_venta.c_Usuario.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_usuario", xtb_venta.c_CodigoUsuario.c_Texto).Size = xtb_venta.c_CodigoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_sucursal", xtb_venta.c_CodigoSucursal.c_Texto).Size = xtb_venta.c_CodigoSucursal.c_Largo
                                xcmd.Parameters.AddWithValue("@hora", xtb_venta.c_Hora.c_Texto).Size = xtb_venta.c_Hora.c_Largo
                                xcmd.Parameters.AddWithValue("@transporte", xtb_venta.c_Transporte.c_Texto).Size = xtb_venta.c_Transporte.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_transporte", xtb_venta.c_CodigoTransporte.c_Texto).Size = xtb_venta.c_CodigoTransporte.c_Largo
                                xcmd.Parameters.AddWithValue("@monto_divisa", xtb_venta.c_MontoDivisa.c_Valor)
                                xcmd.Parameters.AddWithValue("@despachado", xtb_venta.c_NombreDespachador.c_Texto).Size = xtb_venta.c_NombreDespachador.c_Largo
                                xcmd.Parameters.AddWithValue("@dir_despacho", xtb_venta.c_DirDespacho.c_Texto).Size = xtb_venta.c_DirDespacho.c_Largo
                                xcmd.Parameters.AddWithValue("@estacion", xtb_venta.c_EstacionEquipo.c_Texto).Size = xtb_venta.c_EstacionEquipo.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_recibo", xtb_venta.c_AutoRecibo.c_Texto).Size = xtb_venta.c_AutoRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@recibo", xtb_venta.c_NumeroRecibo.c_Texto).Size = xtb_venta.c_NumeroRecibo.c_Largo
                                xcmd.Parameters.AddWithValue("@renglones", xtb_venta.c_CantidadRenglones.c_Valor)
                                xcmd.Parameters.AddWithValue("@saldo_pendiente", xtb_venta.c_MontoSaldoPendiente.c_Valor)
                                xcmd.Parameters.AddWithValue("@ano_relacion", xtb_venta.c_AnoRelacion.c_Texto).Size = xtb_venta.c_AnoRelacion.c_Largo
                                xcmd.Parameters.AddWithValue("@comprobante_retencion_islr", xtb_venta.c_ComprobanteRetencionISLR.c_Texto).Size = xtb_venta.c_ComprobanteRetencionISLR.c_Largo
                                xcmd.Parameters.AddWithValue("@dias_validez", xtb_venta.c_ValidezDocumentoDias.c_Valor)
                                xcmd.Parameters.AddWithValue("@nrf", xtb_venta.c_SerialImpresoraFiscal.c_Texto).Size = xtb_venta.c_SerialImpresoraFiscal.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_usuario", xtb_venta.c_AutoUsuario.c_Texto).Size = xtb_venta.c_AutoUsuario.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_jornada", xtb_venta.c_AutomaticoJornada.c_Texto).Size = xtb_venta.c_AutomaticoJornada.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_operador", xtb_venta.c_AutomaticoOperador.c_Texto).Size = xtb_venta.c_AutomaticoOperador.c_Largo
                                xcmd.Parameters.AddWithValue("@serie", xtb_venta.c_SerieAsignada.c_Texto).Size = xtb_venta.c_SerieAsignada.c_Largo
                                xcmd.Parameters.AddWithValue("@serial", xtb_venta.c_SerialUnico_Jornada.c_Texto).Size = xtb_venta.c_SerialUnico_Jornada.c_Largo
                                xcmd.Parameters.AddWithValue("@bloquear_almacen", xtb_venta.c_BloquearAlmacen.c_Texto).Size = xtb_venta.c_BloquearAlmacen.c_Largo
                                xcmd.Parameters.AddWithValue("@origen_documento", xtb_venta.c_OrigenDocumento.c_Texto).Size = xtb_venta.c_OrigenDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@rest_numero_mesapedido", xtb_venta.c_Rest_NumeroMesaPedido.c_Texto).Size = xtb_venta.c_Rest_NumeroMesaPedido.c_Largo
                                xcmd.Parameters.AddWithValue("@rest_servicio_monto", xtb_venta.c_Rest_ServicioMonto.c_Valor)
                                xcmd.Parameters.AddWithValue("@rest_servicio_tasa", xtb_venta.c_Rest_ServicioTasa.c_Valor)
                                xcmd.Parameters.AddWithValue("@rest_modo_mesapedido", xtb_venta.c_Rest_ModoMesaPedido.c_Texto).Size = xtb_venta.c_Rest_ModoMesaPedido.c_Largo
                                xcmd.Parameters.AddWithValue("@relacion_z", xtb_venta.c_Relacion_Z.c_Valor)
                                xcmd.ExecuteNonQuery()

                                'CXC, sea Contado / Credito
                                Dim xcxc_doc_factura As New FichaCtasCobrar.c_CxC.c_Registro
                                With xcxc_doc_factura
                                    .c_AutoAgencia.c_Texto = ""
                                    .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                    .c_AutoCxC.c_Texto = autocxc
                                    .c_AutoDocumento.c_Texto = xtb_venta.c_AutoDocumento.c_Texto
                                    .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                    .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                    .c_EstatusCancelado.c_Texto = "0"
                                    .c_EstatusDocumentoCxC.c_Texto = "0"
                                    .c_FechaProceso.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                    .c_FechaVencimiento.c_Valor = xtb_venta.c_FechaVencimiento.c_Valor
                                    .c_MontoAcumulado.c_Valor = 0
                                    .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                    .c_MontoPorCobrar.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                    .c_NombreAgencia.c_Texto = ""
                                    .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                    .c_NotasDetalles.c_Texto = "DOCUMENTO DE VENTA"
                                    .c_Numero.c_Texto = ""
                                    .c_NumeroDocumento.c_Texto = xtb_venta.c_Documento.c_Texto
                                    .c_TipoDocumento.c_Texto = "FAC"
                                    .c_TipoMovimiento.c_Valor = 1
                                    .c_TipoOperacion.c_Texto = ""
                                    .c_AutoMovimientoEntrada.c_Texto = ""
                                    .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                End With

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = FichaCtasCobrar.INSERT_CXC
                                xcmd.Parameters.AddWithValue("@auto", xcxc_doc_factura.c_AutoCxC.c_Texto).Size = xcxc_doc_factura.c_AutoCxC.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha", xcxc_doc_factura.c_FechaProceso.c_Valor)
                                xcmd.Parameters.AddWithValue("@tipo_documento", xcxc_doc_factura.c_TipoDocumento.c_Texto).Size = xcxc_doc_factura.c_TipoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@documento", xcxc_doc_factura.c_NumeroDocumento.c_Texto).Size = xcxc_doc_factura.c_NumeroDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc_doc_factura.c_FechaVencimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@detalle", xcxc_doc_factura.c_NotasDetalles.c_Texto).Size = xcxc_doc_factura.c_NotasDetalles.c_Largo
                                xcmd.Parameters.AddWithValue("@importe", xcxc_doc_factura.c_MontoImporte.c_Valor)
                                xcmd.Parameters.AddWithValue("@acumulado", xcxc_doc_factura.c_MontoAcumulado.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_cliente", xcxc_doc_factura.c_AutoCliente.c_Texto).Size = xcxc_doc_factura.c_AutoCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@cliente", xcxc_doc_factura.c_NombreCliente.c_Texto).Size = xcxc_doc_factura.c_NombreCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@ci_rif", xcxc_doc_factura.c_CiRifCliente.c_Texto).Size = xcxc_doc_factura.c_CiRifCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@codigo_cliente", xcxc_doc_factura.c_CodigoCliente.c_Texto).Size = xcxc_doc_factura.c_CodigoCliente.c_Largo
                                xcmd.Parameters.AddWithValue("@cancelado", xcxc_doc_factura.c_EstatusCancelado.c_Texto).Size = xcxc_doc_factura.c_EstatusCancelado.c_Largo
                                xcmd.Parameters.AddWithValue("@resta", xcxc_doc_factura.c_MontoPorCobrar.c_Valor)
                                xcmd.Parameters.AddWithValue("@operacion", xcxc_doc_factura.c_TipoOperacion.c_Texto).Size = xcxc_doc_factura.c_TipoOperacion.c_Largo
                                xcmd.Parameters.AddWithValue("@estatus", xcxc_doc_factura.c_EstatusDocumentoCxC.c_Texto).Size = xcxc_doc_factura.c_EstatusDocumentoCxC.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_documento", xcxc_doc_factura.c_AutoDocumento.c_Texto).Size = xcxc_doc_factura.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@numero", xcxc_doc_factura.c_Numero.c_Texto).Size = xcxc_doc_factura.c_Numero.c_Largo
                                xcmd.Parameters.AddWithValue("@auto_agencia", xcxc_doc_factura.c_AutoAgencia.c_Texto).Size = xcxc_doc_factura.c_AutoAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@agencia", xcxc_doc_factura.c_NombreAgencia.c_Texto).Size = xcxc_doc_factura.c_NombreAgencia.c_Largo
                                xcmd.Parameters.AddWithValue("@signo", xcxc_doc_factura.c_TipoMovimiento.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc_doc_factura.c_AutoMovimientoEntrada.c_Texto).Size = xcxc_doc_factura.c_AutoMovimientoEntrada.c_Largo
                                xcmd.Parameters.AddWithValue("@fecha_emision", xcxc_doc_factura.c_FechaEmision.c_Valor)
                                xcmd.ExecuteNonQuery()

                                'BUSCAR EL CONCEPTO ADECUADO PARA EL TIPO DE DOCUMENTO
                                Dim auto_concepto As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto from productos_conceptos where codigo='VENTAS'"
                                auto_concepto = xcmd.ExecuteScalar()
                                If (auto_concepto Is Nothing) Or IsDBNull(auto_concepto) Then
                                    Throw New Exception("CONCEPTO 'VENTAS' NO ESTA DEFINIDO EN LA TABLA CONCEPTOS DE MOVIMIENTO DEL INVENTARIO")
                                End If

                                Dim xconcepto As String = ""
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select nombre from productos_conceptos where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", auto_concepto)
                                xconcepto = xcmd.ExecuteScalar

                                Dim xsalidaventa As New FastFood.PlatoSalida.c_Registro
                                'VENTAS_DETALLE PLATOS
                                For Each xdt In xdetalles
                                    Dim xit As String = xdt._AutoItem

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FastFood.VentasDetalle_FastFood.INSERT_VENTASDETALLE_FASTFOOD
                                    xdt.c_AutoDocumento._ContenidoCampo = xtb_venta.c_AutoDocumento.c_Texto
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoCliente._NombreCampo, xdt._AutoCliente).Size = xdt.c_AutoCliente._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoDocumento._NombreCampo, xdt._AutoDocumento).Size = xdt.c_AutoDocumento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoGrupo._NombreCampo, xdt._AutoGrupo).Size = xdt.c_AutoGrupo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoItem._NombreCampo, xdt._AutoItem).Size = xdt.c_AutoItem._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoItemOrigen._NombreCampo, xdt._AutoItemOrigen).Size = xdt.c_AutoItemOrigen._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoJornada._NombreCampo, xdt._AutoJornada).Size = xdt.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoOperador._NombreCampo, xdt._AutoOperador).Size = xdt.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_AutoPlato._NombreCampo, xdt._AutoPlato).Size = xdt.c_AutoPlato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_CantidadDespachada._NombreCampo, xdt._CantidadDespachada)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_CodigoPlato._NombreCampo, xdt._CodigoPlato).Size = xdt.c_CodigoPlato._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_CostoNeto._NombreCampo, xdt._CostoNeto)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_CostoTotalNeto._NombreCampo, xdt._CostoTotalNeto)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_EnOferta._NombreCampo, xdt.c_EnOferta._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_EsPesado._NombreCampo, xdt.c_EsPesado._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_Estatus._NombreCampo, xdt.c_Estatus._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_FechaEmision._NombreCampo, xdt._FechaEmision)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_MontoIva._NombreCampo, xdt._MontoImpuesto)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_NombrePlato._NombreCampo, xdt._NombrePlato)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_NotasItem._NombreCampo, xdt._NotasItem)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_PrecioFinal._NombreCampo, xdt._PrecioFinal._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_PrecioNeto._NombreCampo, xdt._PrecioNeto._Base)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_SignoDocumento._NombreCampo, xdt._Signo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TasaIva._NombreCampo, xdt._TasaIva)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TipoCalculoUtilidad._NombreCampo, xdt.c_TipoCalculoUtilidad._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TipoDocumento._NombreCampo, xdt.c_TipoDocumento._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TipoItem._NombreCampo, xdt.c_TipoItem._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TipoMovimiento._NombreCampo, xdt.c_TipoMovimiento._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TipoTasaIva._NombreCampo, xdt.c_TipoTasaIva._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TotalGeneral._NombreCampo, xdt._TotalGeneral)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_TotalNeto._NombreCampo, xdt._TotalNeto)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_UtilidadMonto._NombreCampo, xdt._UtilidadMonto)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_UtilidadTasa._NombreCampo, xdt._UtilidadTasa)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_EsCombo._NombreCampo, xdt._EsCombo)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_AutoMesonero._NombreCampo, xdt._Rest_AutoMesonero)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_CodigoMesonero._NombreCampo, xdt._Rest_CodigoMesonero)
                                    xcmd.Parameters.AddWithValue("@" + xdt.c_Rest_NombreMesonero._NombreCampo, xdt._Rest_NombreMesonero)
                                    xcmd.ExecuteNonQuery()


                                    'HISTORIAL COMANDAS
                                    Dim xtb_historial As New DataTable
                                    Dim xrd_historial As SqlDataReader

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select * from rest_historialcomandas where auto_item=@auto_item"
                                    xcmd.Parameters.AddWithValue("@auto_item", xdt._ItemOrigenTablaTemporal)
                                    xrd_historial = xcmd.ExecuteReader()
                                    xtb_historial.Load(xrd_historial)
                                    xrd_historial.Close()

                                    For Each xdrow In xtb_historial.AsEnumerable
                                        Dim xhist As New HistorialComandas
                                        xhist.M_CargarRegistro(xdrow)

                                        Dim xcomanda As New FastFood.HistorialComandas_FastFood.c_Registro
                                        With xcomanda
                                            .c_Auto._ContenidoCampo = ""
                                            .c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                            .c_AutoEstacion._ContenidoCampo = xhist.RegistroDato._AutoEstacion
                                            .c_AutoItem._ContenidoCampo = xdt._AutoItem
                                            .c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                                            .c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                                            .c_AutoPlato._ContenidoCampo = xhist.RegistroDato._AutoPlato
                                            .c_Cantidad._ContenidoCampo = xhist.RegistroDato._Cantidad
                                            .c_Documento._ContenidoCampo = xtb_venta._Documento
                                            .c_EstatusEstacionEnvio._ContenidoCampo = xhist.RegistroDato.c_EstatusEstacionEnvio._ContenidoCampo
                                            .c_EstatusPlatoEnvio._ContenidoCampo = xhist.RegistroDato.c_EstatusPlatoEnvio._ContenidoCampo
                                            .c_FechaProceso._ContenidoCampo = xventa._Encabezado._FechaEmision
                                            .c_NombreEstacion._ContenidoCampo = xhist.RegistroDato._NombreEstacion
                                            .c_NombrePlato._ContenidoCampo = xhist.RegistroDato._NombrePlato
                                            .c_NombreUsuario._ContenidoCampo = xhist.RegistroDato._NombreUsuario
                                            .c_NotasDetalle._ContenidoCampo = xhist.RegistroDato._NotasDetalle
                                            .c_RutaEstacion._ContenidoCampo = xhist.RegistroDato._RutaEstacion
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "select a_historialcomandas_fastfood from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_historialcomandas_fastfood=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = xsql_4
                                        xcomanda.c_Auto._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FastFood.HistorialComandas_FastFood.INSERT_HISTORIALCOMANDAS_FASTFOOD
                                        With xcmd.Parameters
                                            .AddWithValue("@" + xcomanda.c_Auto._NombreCampo, xcomanda.c_Auto._ContenidoCampo).Size = xcomanda.c_Auto._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoDocumento._NombreCampo, xcomanda.c_AutoDocumento._ContenidoCampo).Size = xcomanda.c_AutoDocumento._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoEstacion._NombreCampo, xcomanda.c_AutoEstacion._ContenidoCampo).Size = xcomanda.c_AutoEstacion._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoItem._NombreCampo, xcomanda.c_AutoItem._ContenidoCampo).Size = xcomanda.c_AutoItem._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoJornada._NombreCampo, xcomanda.c_AutoJornada._ContenidoCampo).Size = xcomanda.c_AutoJornada._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoOperador._NombreCampo, xcomanda.c_AutoOperador._ContenidoCampo).Size = xcomanda.c_AutoOperador._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_AutoPlato._NombreCampo, xcomanda.c_AutoPlato._ContenidoCampo).Size = xcomanda.c_AutoPlato._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_Cantidad._NombreCampo, xcomanda.c_Cantidad._ContenidoCampo)
                                            .AddWithValue("@" + xcomanda.c_Documento._NombreCampo, xcomanda.c_Documento._ContenidoCampo).Size = xcomanda.c_Documento._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_EstatusEstacionEnvio._NombreCampo, xcomanda.c_EstatusEstacionEnvio._ContenidoCampo).Size = xcomanda.c_EstatusEstacionEnvio._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_EstatusPlatoEnvio._NombreCampo, xcomanda.c_EstatusPlatoEnvio._ContenidoCampo).Size = xcomanda.c_EstatusPlatoEnvio._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_FechaProceso._NombreCampo, xcomanda.c_FechaProceso._ContenidoCampo)
                                            .AddWithValue("@" + xcomanda.c_NombreEstacion._NombreCampo, xcomanda.c_NombreEstacion._ContenidoCampo).Size = xcomanda.c_NombreEstacion._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_NombrePlato._NombreCampo, xcomanda.c_NombrePlato._ContenidoCampo).Size = xcomanda.c_NombrePlato._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_NombreUsuario._NombreCampo, xcomanda.c_NombreUsuario._ContenidoCampo).Size = xcomanda.c_NombreUsuario._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_NotasDetalle._NombreCampo, xcomanda.c_NotasDetalle._ContenidoCampo).Size = xcomanda.c_NotasDetalle._LargoCampo
                                            .AddWithValue("@" + xcomanda.c_RutaEstacion._NombreCampo, xcomanda.c_RutaEstacion._ContenidoCampo).Size = xcomanda.c_RutaEstacion._LargoCampo
                                        End With
                                        xcmd.ExecuteNonQuery()
                                    Next
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete rest_historialcomandas where auto_item=@auto_item"
                                    xcmd.Parameters.AddWithValue("@auto_item", xdt._ItemOrigenTablaTemporal)
                                    xcmd.ExecuteNonQuery()


                                    'SI ES UN COMBO, DEVUELVE LOS PLATOS QUE INTEGRAN EL COMBO CON SU RESPECTIVA CANTIDAD
                                    If xdt._EsCombo Then
                                        Dim xtb_plat As New DataTable
                                        Dim xreader As SqlDataReader
                                        Dim xsql As String = _
                                        "select mp.auto a_plato ,mp.nombre_plato n_plato ,mc.cantidad ,mp.auto_grupo a_grupo, g.nombre_grupo n_grupo " & _
                                        "from MenuCombos_FastFood mc join MenuPlatos_FastFood mp on mc.auto_plato=mp.auto " & _
                                        "join Grupo_FastFood g on mp.auto_grupo=g.auto where mc.auto_plato_combo=@autocombo"

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = xsql
                                        xcmd.Parameters.AddWithValue("@autocombo", xdt._AutoPlato)
                                        xreader = xcmd.ExecuteReader()
                                        xtb_plat.Load(xreader)

                                        For Each xrp As DataRow In xtb_plat.Rows
                                            With xsalidaventa
                                                .M_Limpiar()

                                                .c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                                .c_AutoGrupo._ContenidoCampo = xrp("a_grupo")
                                                .c_AutoItem._ContenidoCampo = xdt._AutoItem
                                                .c_AutoPlato._ContenidoCampo = xrp("a_plato")
                                                .c_CantidadRequerida._ContenidoCampo = xrp("cantidad")
                                                .c_Documento._ContenidoCampo = xtb_venta._Documento
                                                .c_FechaProceso._ContenidoCampo = xdt._FechaEmision
                                                .c_NombreGrupo._ContenidoCampo = xrp("n_grupo")
                                                .c_NombrePlato._ContenidoCampo = xrp("n_plato")
                                                .c_Signo._ContenidoCampo = 1
                                                .c_CantidadTotal._ContenidoCampo = xdt._CantidadDespachada * xrp("cantidad")
                                                .c_Estatus._ContenidoCampo = "0"
                                            End With

                                            With xsalidaventa
                                                xcmd.Parameters.Clear()
                                                xcmd.CommandText = FastFood.PlatoSalida.InsertRegistro
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoGrupo._NombreCampo, ._AutoGrupo).Size = .c_AutoGrupo._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_AutoPlato._NombreCampo, ._AutoPlato).Size = .c_AutoPlato._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_CantidadRequerida._NombreCampo, ._CantidadRequerida)
                                                xcmd.Parameters.AddWithValue("@" + .c_CantidadTotal._NombreCampo, ._CantidadTotal)
                                                xcmd.Parameters.AddWithValue("@" + .c_Documento._NombreCampo, ._Documento).Size = .c_Documento._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_FechaProceso._NombreCampo, ._FechaProceso)
                                                xcmd.Parameters.AddWithValue("@" + .c_NombreGrupo._NombreCampo, ._NombreGrupo).Size = .c_NombreGrupo._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_NombrePlato._NombreCampo, ._NombrePlato).Size = .c_NombrePlato._LargoCampo
                                                xcmd.Parameters.AddWithValue("@" + .c_Signo._NombreCampo, ._Signo)
                                                xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo).Size = .c_Estatus._LargoCampo

                                                xcmd.ExecuteNonQuery()
                                            End With
                                        Next
                                    Else
                                        With xsalidaventa
                                            .M_Limpiar()

                                            .c_AutoDocumento._ContenidoCampo = xdt._AutoDocumento
                                            .c_AutoGrupo._ContenidoCampo = xdt._AutoGrupo
                                            .c_AutoItem._ContenidoCampo = xdt._AutoItem
                                            .c_AutoPlato._ContenidoCampo = xdt._AutoPlato
                                            .c_Documento._ContenidoCampo = xtb_venta._Documento
                                            .c_FechaProceso._ContenidoCampo = xdt._FechaEmision
                                            .c_NombreGrupo._ContenidoCampo = xdt._NombreGrupo
                                            .c_NombrePlato._ContenidoCampo = xdt._NombrePlato
                                            .c_Signo._ContenidoCampo = 1
                                            .c_CantidadRequerida._ContenidoCampo = 1
                                            .c_CantidadTotal._ContenidoCampo = xdt._CantidadDespachada
                                            .c_Estatus._ContenidoCampo = "0"

                                            xcmd.Parameters.Clear()
                                            xcmd.CommandText = FastFood.PlatoSalida.InsertRegistro
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoGrupo._NombreCampo, ._AutoGrupo).Size = .c_AutoGrupo._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_AutoPlato._NombreCampo, ._AutoPlato).Size = .c_AutoPlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_CantidadRequerida._NombreCampo, ._CantidadRequerida)
                                            xcmd.Parameters.AddWithValue("@" + .c_CantidadTotal._NombreCampo, ._CantidadTotal)
                                            xcmd.Parameters.AddWithValue("@" + .c_Documento._NombreCampo, ._Documento).Size = .c_Documento._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_FechaProceso._NombreCampo, ._FechaProceso)
                                            xcmd.Parameters.AddWithValue("@" + .c_NombreGrupo._NombreCampo, ._NombreGrupo).Size = .c_NombreGrupo._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_NombrePlato._NombreCampo, ._NombrePlato).Size = .c_NombrePlato._LargoCampo
                                            xcmd.Parameters.AddWithValue("@" + .c_Signo._NombreCampo, ._Signo)
                                            xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo).Size = .c_Estatus._LargoCampo
                                            xcmd.ExecuteNonQuery()
                                        End With
                                    End If

                                    'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                    Dim dr As DataRow = xtablaprd.NewRow
                                    dr("cantidad") = xdt._CantidadDespachada
                                    dr("nombre") = xdt._NombrePlato
                                    dr("codigo") = xdt._CodigoPlato
                                    dr("precio_neto") = xdt._PrecioNeto._Base
                                    dr("codigo_tasa") = xdt.c_TipoTasaIva._ContenidoCampo
                                    xtablaprd.Rows.Add(dr)
                                Next

                                If xventa._Encabezado._TasaServicio > 0 Then
                                    'AGREGAR ITEM SERVICIO AL DETALLE
                                    If xventa._Encabezado._TipoMesaPedido = TipoPedido.ParaMesa Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FastFood.VentasDetalle_FastFood.INSERT_VENTASDETALLE_FASTFOOD
                                        xservicio.c_AutoDocumento._ContenidoCampo = xtb_venta.c_AutoDocumento.c_Texto
                                        xservicio.c_AutoItem._ContenidoCampo = (i + 1).ToString.Trim.PadLeft(10, "0")
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoCliente._NombreCampo, xservicio._AutoCliente).Size = xservicio.c_AutoCliente._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoDocumento._NombreCampo, xservicio._AutoDocumento).Size = xservicio.c_AutoDocumento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoGrupo._NombreCampo, xservicio._AutoGrupo).Size = xservicio.c_AutoGrupo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoItem._NombreCampo, xservicio._AutoItem).Size = xservicio.c_AutoItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoItemOrigen._NombreCampo, xservicio._AutoItemOrigen).Size = xservicio.c_AutoItemOrigen._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoJornada._NombreCampo, xservicio._AutoJornada).Size = xservicio.c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoOperador._NombreCampo, xservicio._AutoOperador).Size = xservicio.c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_AutoPlato._NombreCampo, xservicio._AutoPlato).Size = xservicio.c_AutoPlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_CantidadDespachada._NombreCampo, xservicio._CantidadDespachada)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_CodigoPlato._NombreCampo, xservicio._CodigoPlato).Size = xservicio.c_CodigoPlato._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_CostoNeto._NombreCampo, xservicio._CostoNeto)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_CostoTotalNeto._NombreCampo, xservicio._CostoTotalNeto)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_EnOferta._NombreCampo, xservicio.c_EnOferta._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_EsPesado._NombreCampo, xservicio.c_EsPesado._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_Estatus._NombreCampo, xservicio.c_Estatus._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_FechaEmision._NombreCampo, xservicio._FechaEmision)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_MontoIva._NombreCampo, xservicio._MontoImpuesto)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_NombrePlato._NombreCampo, xservicio._NombrePlato)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_NotasItem._NombreCampo, xservicio._NotasItem)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_PrecioFinal._NombreCampo, xservicio._PrecioFinal._Base)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_PrecioNeto._NombreCampo, xservicio._PrecioNeto._Base)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_SignoDocumento._NombreCampo, xservicio._Signo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TasaIva._NombreCampo, xservicio._TasaIva)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TipoCalculoUtilidad._NombreCampo, xservicio.c_TipoCalculoUtilidad._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TipoDocumento._NombreCampo, xservicio.c_TipoDocumento._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TipoItem._NombreCampo, xservicio.c_TipoItem._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TipoMovimiento._NombreCampo, xservicio.c_TipoMovimiento._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TipoTasaIva._NombreCampo, xservicio.c_TipoTasaIva._ContenidoCampo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TotalGeneral._NombreCampo, xservicio._TotalGeneral)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_TotalNeto._NombreCampo, xservicio._TotalNeto)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_UtilidadMonto._NombreCampo, xservicio._UtilidadMonto)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_UtilidadTasa._NombreCampo, xservicio._UtilidadTasa)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_EsCombo._NombreCampo, xservicio._EsCombo)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_Rest_AutoMesonero._NombreCampo, xservicio._Rest_AutoMesonero)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_Rest_CodigoMesonero._NombreCampo, xservicio._Rest_CodigoMesonero)
                                        xcmd.Parameters.AddWithValue("@" + xservicio.c_Rest_NombreMesonero._NombreCampo, xservicio._Rest_NombreMesonero)
                                        If xcmd.ExecuteNonQuery() = 0 Then
                                            Throw New Exception("SERVICIO A LA MESA NO PUDO SER REGISTRADO... VERIFIQUE")
                                        End If

                                        'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                        Dim dr As DataRow = xtablaprd.NewRow
                                        dr("cantidad") = xservicio._CantidadDespachada
                                        dr("nombre") = xservicio._NombrePlato
                                        dr("codigo") = xservicio._CodigoPlato
                                        dr("precio_neto") = xservicio._PrecioNeto._Base
                                        dr("codigo_tasa") = xservicio.c_TipoTasaIva._ContenidoCampo
                                        xtablaprd.Rows.Add(dr)
                                    End If
                                End If


                                'REALIZAR EL KARDEX DE LOS PLATOS QUE TOCAN INVENTARIO
                                For Each xinv As FichaProducto.Prd_Kardex.c_Registro In xlistakardex

                                    'DESCONTAR DE INVENTARIO 
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaVentas.VENTAS_UPDATE_PRODUCTOS_DEPOSITO
                                    xcmd.Parameters.AddWithValue("@auto_producto", xinv._AutoProducto)
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xinv._AutoDeposito)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xinv._CantidadUnidadesMover)
                                    xcmd.ExecuteNonQuery()

                                    'CAMPOS PENDIENTES POR LLENAR
                                    With xinv
                                        .c_AutoConcepto.c_Texto = auto_concepto
                                        .c_AutoDocumento.c_Texto = xtb_venta._AutoDocumento
                                        .c_Documento.c_Texto = xtb_venta._Documento
                                        .c_NombreConcepto.c_Texto = xconcepto
                                    End With
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaProducto.Prd_Kardex.INSERT_PRODUCTOS_KARDEX
                                    xcmd.Parameters.AddWithValue("@auto_producto", xinv.c_AutoProducto.c_Texto).Size = xinv.c_AutoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xinv.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_deposito", xinv.c_AutoDeposito.c_Texto).Size = xinv.c_AutoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@cantidad", xinv.c_CantidadMover.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_concepto", xinv.c_AutoConcepto.c_Texto).Size = xinv.c_AutoConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@entidad", xinv.c_Entidad.c_Texto).Size = xinv.c_Entidad.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xinv.c_Documento.c_Texto).Size = xinv.c_Documento.c_Largo
                                    xcmd.Parameters.AddWithValue("@medida_empaque", xinv.c_ReferenciaEmpaque.c_Texto).Size = xinv.c_ReferenciaEmpaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xinv.c_TipoMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cantidad_inventario", xinv.c_CantidadUnidadesMover.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estatus", xinv.c_Estatus.c_Texto).Size = xinv.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xinv.c_OrigenMovimiento.c_Texto).Size = xinv.c_OrigenMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xinv.c_AutoDocumento.c_Texto).Size = xinv.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@nota", xinv.c_NotasDetallesMovimiento.c_Texto).Size = xinv.c_NotasDetallesMovimiento.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombreproducto", xinv.c_NombreProducto.c_Texto).Size = xinv.c_NombreProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombredeposito", xinv.c_NombreDeposito.c_Texto).Size = xinv.c_NombreDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombreconcepto", xinv.c_NombreConcepto.c_Texto).Size = xinv.c_NombreConcepto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_nombremedidaempaque", xinv.c_NombreMedidaEmpaque.c_Texto).Size = xinv.c_NombreMedidaEmpaque.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_automedida", xinv.c_AutoMedida.c_Texto).Size = xinv.c_AutoMedida.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_contenidomedidaempaque", xinv.c_ContenidoMedidaEmpaque.c_Valor)
                                    xcmd.Parameters.AddWithValue("@n_codigoproducto", xinv.c_CodigoProducto.c_Texto).Size = xinv.c_CodigoProducto.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_codigodeposito", xinv.c_CodigoDeposito.c_Texto).Size = xinv.c_CodigoDeposito.c_Largo
                                    xcmd.Parameters.AddWithValue("@n_codigoconcepto", xinv.c_CodigoConcepto.c_Texto).Size = xinv.c_CodigoConcepto.c_Largo
                                    xcmd.ExecuteNonQuery()

                                    Dim xventainventario As New FastFood.VentaInventario.c_Registro
                                    With xventainventario
                                        .c_AutoDocumentoVenta._ContenidoCampo = xtb_venta._AutoDocumento
                                        .c_AutoItemVenta._ContenidoCampo = xinv._FastFood_ItemVenta
                                        .c_AutoMedEmpaq._ContenidoCampo = xinv.c_AutoMedida.c_Texto
                                        .c_AutoProducto._ContenidoCampo = xinv.c_AutoProducto.c_Texto
                                        .c_Cantidad_Requerida_Descontar._ContenidoCampo = xinv._FastFood_CantidadRequerida
                                        .c_ContEmpaque._ContenidoCampo = xinv.c_ContenidoMedidaEmpaque.c_Valor
                                        .c_AutoDeposito._ContenidoCampo = xinv._AutoDeposito
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FastFood.VentaInventario.Insert
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoDocumentoVenta._NombreCampo, xventainventario._AutoDocumentoVenta).Size = xventainventario.c_AutoDocumentoVenta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoItemVenta._NombreCampo, xventainventario._AutoItemVenta).Size = xventainventario.c_AutoItemVenta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoMedEmpaq._NombreCampo, xventainventario._AutoMedEmpaq).Size = xventainventario.c_AutoMedEmpaq._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoProducto._NombreCampo, xventainventario._AutoProducto).Size = xventainventario.c_AutoProducto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_Cantidad_Requerida_Descontar._NombreCampo, xventainventario._Cantidad_Requerida_Descontar)
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_ContEmpaque._NombreCampo, xventainventario._ContenidoEmpaque)
                                    xcmd.Parameters.AddWithValue("@" + xventainventario.c_AutoDeposito._NombreCampo, xventainventario._AutoDeposito).Size = xventainventario.c_AutoDeposito._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                Next


                                'FACTURA CONTADO
                                If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado Then
                                    Dim autocxc_pago As String = ""
                                    Dim autocxc_recibopago As String = ""
                                    Dim autocxc_numerorecibopago As String = ""

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores SET a_cxc=a_cxc+1;select a_cxc from contadores"
                                    autocxc_pago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_cxc_recibos=a_cxc_recibos+1;select a_cxc_recibos from contadores"
                                    autocxc_recibopago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_cxc_recibos_numero=a_cxc_recibos_numero+1;select a_cxc_recibos_numero from contadores"
                                    autocxc_numerorecibopago = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'CXC, sea Contado / Credito
                                    Dim xcxc_doc_pago As New FichaCtasCobrar.c_CxC.c_Registro
                                    xcxc_doc_pago.LimpiarRegistro()
                                    With xcxc_doc_pago
                                        .c_AutoAgencia.c_Texto = ""
                                        .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                        .c_AutoCxC.c_Texto = autocxc_pago
                                        .c_AutoDocumento.c_Texto = ""
                                        .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                        .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                        .c_EstatusCancelado.c_Texto = ""
                                        .c_EstatusDocumentoCxC.c_Texto = "0"
                                        .c_FechaProceso.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                        .c_FechaVencimiento.c_Valor = xtb_venta.c_FechaVencimiento.c_Valor
                                        .c_MontoAcumulado.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_MontoPorCobrar.c_Valor = 0
                                        .c_NombreAgencia.c_Texto = ""
                                        .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                        .c_NotasDetalles.c_Texto = ""
                                        .c_Numero.c_Texto = ""
                                        .c_NumeroDocumento.c_Texto = autocxc_numerorecibopago
                                        .c_TipoDocumento.c_Texto = "PAG"
                                        .c_TipoMovimiento.c_Valor = -1
                                        .c_TipoOperacion.c_Texto = ""
                                        .c_AutoMovimientoEntrada.c_Texto = ""
                                        .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasCobrar.INSERT_CXC
                                    xcmd.Parameters.AddWithValue("@auto", xcxc_doc_pago.c_AutoCxC.c_Texto).Size = xcxc_doc_pago.c_AutoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xcxc_doc_pago.c_FechaProceso.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo_documento", xcxc_doc_pago.c_TipoDocumento.c_Texto).Size = xcxc_doc_pago.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xcxc_doc_pago.c_NumeroDocumento.c_Texto).Size = xcxc_doc_pago.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_vencimiento", xcxc_doc_pago.c_FechaVencimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xcxc_doc_pago.c_NotasDetalles.c_Texto).Size = xcxc_doc_pago.c_NotasDetalles.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe", xcxc_doc_pago.c_MontoImporte.c_Valor)
                                    xcmd.Parameters.AddWithValue("@acumulado", xcxc_doc_pago.c_MontoAcumulado.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xcxc_doc_pago.c_AutoCliente.c_Texto).Size = xcxc_doc_pago.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cliente", xcxc_doc_pago.c_NombreCliente.c_Texto).Size = xcxc_doc_pago.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif", xcxc_doc_pago.c_CiRifCliente.c_Texto).Size = xcxc_doc_pago.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_cliente", xcxc_doc_pago.c_CodigoCliente.c_Texto).Size = xcxc_doc_pago.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@cancelado", xcxc_doc_pago.c_EstatusCancelado.c_Texto).Size = xcxc_doc_pago.c_EstatusCancelado.c_Largo
                                    xcmd.Parameters.AddWithValue("@resta", xcxc_doc_pago.c_MontoPorCobrar.c_Valor)
                                    xcmd.Parameters.AddWithValue("@operacion", xcxc_doc_pago.c_TipoOperacion.c_Texto).Size = xcxc_doc_pago.c_TipoOperacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xcxc_doc_pago.c_EstatusDocumentoCxC.c_Texto).Size = xcxc_doc_pago.c_EstatusDocumentoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_documento", xcxc_doc_pago.c_AutoDocumento.c_Texto).Size = xcxc_doc_pago.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero", xcxc_doc_pago.c_Numero.c_Texto).Size = xcxc_doc_pago.c_Numero.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_agencia", xcxc_doc_pago.c_AutoAgencia.c_Texto).Size = xcxc_doc_pago.c_AutoAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@agencia", xcxc_doc_pago.c_NombreAgencia.c_Texto).Size = xcxc_doc_pago.c_NombreAgencia.c_Largo
                                    xcmd.Parameters.AddWithValue("@signo", xcxc_doc_pago.c_TipoMovimiento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_mov_entrada", xcxc_doc_factura.c_AutoMovimientoEntrada.c_Texto).Size = xcxc_doc_factura.c_AutoMovimientoEntrada.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha_emision", xcxc_doc_factura.c_FechaEmision.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'CXC_RECIBOS
                                    Dim xrecibo As New FichaCtasCobrar.c_Recibos.c_Registro
                                    With xrecibo
                                        .c_AutoCliente.c_Texto = xtb_venta.c_AutoCliente.c_Texto
                                        .c_AutoCobrador.c_Texto = xventa._Encabezado._Cobrador.r_Automatico
                                        .c_AutoRecibo.c_Texto = autocxc_recibopago
                                        .c_AutoUsuario.c_Texto = xtb_venta.c_AutoUsuario.c_Texto
                                        .c_CiRifCliente.c_Texto = xtb_venta.c_CiRifCliente.c_Texto
                                        .c_CodigoCliente.c_Texto = xtb_venta.c_CodigoCliente.c_Texto
                                        .c_DirFiscalCliente.c_Texto = xtb_venta.c_DirFiscalCliente.c_Texto
                                        .c_EstatusRecibo.c_Texto = "0"
                                        .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                        .c_MontoAnticipo.c_Valor = 0
                                        .c_MontoDescuento.c_Valor = 0
                                        .c_MontoImporte.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_MontoImporteDocumento.c_Valor = 0
                                        .c_MontoTotalDocumento.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_NombreCliente.c_Texto = xtb_venta.c_NombreCliente.c_Texto
                                        .c_NombreCobrador.c_Texto = xventa._Encabezado._Cobrador.r_NombreCobrador
                                        .c_NombreUsuario.c_Texto = xtb_venta.c_Usuario.c_Texto
                                        .c_NotasDetalles.c_Texto = ""
                                        .c_NumeroRecibo.c_Texto = autocxc_numerorecibopago
                                        .c_TelefonoCliente.c_Texto = xtb_venta.c_TelefonoCliente.c_Texto
                                        .c_CantidadDocumentosRelacionados.c_Valor = 1
                                        .c_CantNCPagadas.c_Valor = 0
                                        .c_MontoNCPagadas.c_Valor = 0
                                        .c_AutoCxcPago.c_Texto = autocxc_pago
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasCobrar._INSERT_CXC_RECIBOS
                                    xcmd.Parameters.AddWithValue("@auto", xrecibo.c_AutoRecibo.c_Texto).Size = xrecibo.c_AutoRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero", xrecibo.c_NumeroRecibo.c_Texto).Size = xrecibo.c_NumeroRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xrecibo.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_usuario", xrecibo.c_AutoUsuario.c_Texto).Size = xrecibo.c_AutoUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe", xrecibo.c_MontoImporte.c_Valor)
                                    xcmd.Parameters.AddWithValue("@usuario", xrecibo.c_NombreUsuario.c_Texto).Size = xrecibo.c_NombreUsuario.c_Largo
                                    xcmd.Parameters.AddWithValue("@importe_documentos", xrecibo.c_MontoImporteDocumento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@descuentos", xrecibo.c_MontoDescuento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@total_documentos", xrecibo.c_MontoTotalDocumento.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xrecibo.c_NotasDetalles.c_Texto).Size = xrecibo.c_NotasDetalles.c_Largo
                                    xcmd.Parameters.AddWithValue("@cobrador", xrecibo.c_NombreCobrador.c_Texto).Size = xrecibo.c_NombreCobrador.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cliente", xrecibo.c_AutoCliente.c_Texto).Size = xrecibo.c_AutoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre_cliente", xrecibo.c_NombreCliente.c_Texto).Size = xrecibo.c_NombreCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@ci_rif_cliente", xrecibo.c_CiRifCliente.c_Texto).Size = xrecibo.c_CiRifCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_cliente", xrecibo.c_CodigoCliente.c_Texto).Size = xrecibo.c_CodigoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xrecibo.c_EstatusRecibo.c_Texto).Size = xrecibo.c_EstatusRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@direccion", xrecibo.c_DirFiscalCliente.c_Texto).Size = xrecibo.c_DirFiscalCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@telefono", xrecibo.c_TelefonoCliente.c_Texto).Size = xrecibo.c_TelefonoCliente.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cobrador", xrecibo.c_AutoCobrador.c_Texto).Size = xrecibo.c_AutoCobrador.c_Largo
                                    xcmd.Parameters.AddWithValue("@anticipos", xrecibo.c_MontoAnticipo.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cant_doc_rel", xrecibo.c_CantidadDocumentosRelacionados.c_Valor)
                                    'campos nuevos
                                    xcmd.Parameters.AddWithValue("@monto_nc_pagadas", xrecibo.c_MontoNCPagadas.c_Valor)
                                    xcmd.Parameters.AddWithValue("@cant_nc_pagadas", xrecibo.c_CantNCPagadas.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cxc", xrecibo.c_AutoCxcPago.c_Texto)
                                    xcmd.ExecuteNonQuery()

                                    'VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "UPDATE VENTAS SET " _
                                      + "recibo=@recibo, auto_recibo=@auto_recibo where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto)
                                    xcmd.Parameters.AddWithValue("@auto_recibo", autocxc_recibopago)
                                    xcmd.Parameters.AddWithValue("@recibo", autocxc_numerorecibopago)
                                    xcmd.ExecuteNonQuery()

                                    'CXC_DOCUMENTOS
                                    Dim xdoc As New FichaCtasCobrar.c_Documentos.c_Registro
                                    With xdoc
                                        .c_AutoCxC.c_Texto = autocxc
                                        .c_AutoCxCPago.c_Texto = autocxc_pago
                                        .c_AutoCxCRecibo.c_Texto = xrecibo.c_AutoRecibo.c_Texto
                                        .c_FechaEmision.c_Valor = xtb_venta.c_FechaEmision.c_Valor
                                        .c_Item.c_Valor = 1
                                        .c_Monto.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_NotasDetalles.c_Texto = ""
                                        .c_NumeroDocumento.c_Texto = xtb_venta.c_Documento.c_Texto
                                        .c_NumeroRecibo.c_Texto = autocxc_numerorecibopago
                                        .c_OrigenDocumento.c_Texto = "FACTURA"
                                        .c_TipoDocumento.c_Texto = "PAG"
                                        .c_TipoOperacion.c_Texto = "Cancelación"
                                        .c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor = xtb_venta.c_TotalGeneral.c_Valor
                                        .c_SignoDocumento.c_Valor = 1
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaCtasCobrar.INSERT_CXC_DOCUMENTOS
                                    xcmd.Parameters.AddWithValue("@item", xdoc.c_Item.c_Valor)
                                    xcmd.Parameters.AddWithValue("@operacion", xdoc.c_TipoOperacion.c_Texto).Size = xdoc.c_TipoOperacion.c_Largo
                                    xcmd.Parameters.AddWithValue("@monto", xdoc.c_Monto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@auto_cxc", xdoc.c_AutoCxC.c_Texto).Size = xdoc.c_AutoCxC.c_Largo
                                    xcmd.Parameters.AddWithValue("@documento", xdoc.c_NumeroDocumento.c_Texto).Size = xdoc.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cxc_pago", xdoc.c_AutoCxCPago.c_Texto).Size = xdoc.c_AutoCxCPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@tipo", xdoc.c_TipoDocumento.c_Texto).Size = xdoc.c_TipoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@fecha", xdoc.c_FechaEmision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@detalle", xdoc.c_NotasDetalles.c_Texto).Size = xdoc.c_NotasDetalles.c_Largo
                                    xcmd.Parameters.AddWithValue("@auto_cxc_recibo", xdoc.c_AutoCxCRecibo.c_Texto).Size = xdoc.c_AutoCxCRecibo.c_Largo
                                    xcmd.Parameters.AddWithValue("@numero_recibo", xdoc.c_NumeroRecibo.c_Texto).Size = xdoc.c_NumeroDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@origen", xdoc.c_OrigenDocumento.c_Texto).Size = xdoc.c_OrigenDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@monto_pendiente", xdoc.c_SaldoPendienteAlMomentoDeAbonarPagar.c_Valor)
                                    'campos nuevo
                                    xcmd.Parameters.AddWithValue("@signo", xdoc.c_SignoDocumento.c_Valor)
                                    xcmd.ExecuteNonQuery()

                                    'CXC_MODO_PAGO()
                                    Dim xmodopago As New FichaCtasCobrar.c_ModosPago.c_Registro
                                    For Each xregpag In xventa._TablaModosPago.Rows
                                        With xmodopago
                                            .LimpiarRegistro()

                                            .c_AutoAgencia.c_Texto = xregpag(0)
                                            .c_AutoRecibo.c_Texto = xrecibo.c_AutoRecibo.c_Texto
                                            .c_AutoTipoPago.c_Texto = xregpag(4)
                                            .c_CodigoTipoPago.c_Texto = xregpag(6)
                                            .c_EstatusMovimiento.c_Texto = "0"
                                            .c_FechaEmision.c_Valor = xtb_venta._FechaEmision
                                            .c_MontoImporte.c_Valor = xregpag(3)
                                            .c_MontoRecibido.c_Valor = xregpag(7)
                                            .c_NombreAgencia.c_Texto = xregpag(1)
                                            .c_NombreTipoPago.c_Texto = xregpag(5)
                                            .c_Numero.c_Texto = xregpag(2)
                                        End With

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = FichaCtasCobrar.INSERT_CXC_MODO_PAGO
                                        xcmd.Parameters.AddWithValue("@numero", xmodopago.c_Numero.c_Texto).Size = xmodopago.c_Numero.c_Largo
                                        xcmd.Parameters.AddWithValue("@agencia", xmodopago.c_NombreAgencia.c_Texto).Size = xmodopago.c_NombreAgencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@importe", xmodopago.c_MontoImporte.c_Valor)
                                        xcmd.Parameters.AddWithValue("@codigo", xmodopago.c_CodigoTipoPago.c_Texto).Size = xmodopago.c_CodigoTipoPago.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_recibo", xmodopago.c_AutoRecibo.c_Texto).Size = xmodopago.c_AutoRecibo.c_Largo
                                        xcmd.Parameters.AddWithValue("@nombre", xmodopago.c_NombreTipoPago.c_Texto).Size = xmodopago.c_NombreTipoPago.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_medios_pago", xmodopago.c_AutoTipoPago.c_Texto).Size = xmodopago.c_AutoTipoPago.c_Largo
                                        xcmd.Parameters.AddWithValue("@auto_agencia", xmodopago.c_AutoAgencia.c_Texto).Size = xmodopago.c_AutoAgencia.c_Largo
                                        xcmd.Parameters.AddWithValue("@fecha", xmodopago.c_FechaEmision.c_Valor)
                                        xcmd.Parameters.AddWithValue("@estatus", xmodopago.c_EstatusMovimiento.c_Texto).Size = xmodopago.c_EstatusMovimiento.c_Largo
                                        xcmd.Parameters.AddWithValue("@monto_recibido", xmodopago.c_MontoRecibido.c_Valor)
                                        xcmd.ExecuteNonQuery()
                                    Next

                                    'DOCUMENTO FACTURA EN CXC :> PAGADO COMPLETO
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update cxc set cancelado = '1', acumulado = importe, resta = 0 where auto = @auto"
                                    xcmd.Parameters.AddWithValue("@auto", xcxc_doc_factura.c_AutoCxC.c_Texto).Size = xcxc_doc_factura.c_AutoCxC.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End If


                                Dim t_debito As Single = 0
                                Dim t_credito As Single = 0
                                Dim t_saldo As Single = 0

                                'BUSCA LOS SALDOS PARA EL CLIENTE
                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                xcmd.CommandText = "select sum(resta) as s_importe from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe>=0 group by auto_cliente"
                                t_debito = xcmd.ExecuteScalar()

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                xcmd.CommandText = "select sum(resta) as s_acumulado from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' and importe<0 group by auto_cliente"
                                t_credito = xcmd.ExecuteScalar()

                                xcmd.Parameters.Clear()
                                xcmd.Parameters.AddWithValue("@auto_cliente", xtb_venta.c_AutoCliente.c_Texto)
                                xcmd.CommandText = "select sum(resta) as s_resta from cxc where auto_cliente=@auto_cliente and " _
                                  + "cancelado='0' and estatus='0' and tipo_documento<>'PAG' group by auto_cliente"
                                t_saldo = xcmd.ExecuteScalar()

                                'CLIENTES
                                Dim xr_cliente As Integer = 0
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "UPDATE CLIENTES SET " _
                                  + "TOTAL_DEBITOS=@total_debitos,total_creditos=@total_creditos," _
                                  + "total_saldo=@total_saldo, credito_disponible=limite_credito-@total_saldo, " _
                                  + "fecha_ult_compra=@fecha_ult_compra where auto=@auto and estatus='Activo'"
                                xcmd.Parameters.AddWithValue("@total_debitos", t_debito)
                                xcmd.Parameters.AddWithValue("@total_creditos", t_credito)
                                xcmd.Parameters.AddWithValue("@total_saldo", t_saldo)
                                xcmd.Parameters.AddWithValue("@fecha_ult_compra", xtb_venta.c_FechaEmision.c_Valor)
                                xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoCliente.c_Texto)
                                xr_cliente = xcmd.ExecuteNonQuery()
                                If xr_cliente = 0 Then
                                    Throw New Exception("VERIFICAR CLIENTE, AL PARECER FUE EILIMINADO / CAMBIO DE ESTATUS")
                                End If

                                'TABLA REST_TEMPORALMESAS, VERIFICO SI HUBO / NO UN CAMBIO 
                                For Each xdr In xventa._Detalles
                                    Dim xrw As Integer = 0
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "SELECT 1 from rest_temporalmesas where auto_item=@auto_item and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.AddWithValue("@auto_item", xdr._AutoItem)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xdr._Id)
                                    xrw = xcmd.ExecuteScalar
                                    If xrw = 0 Then
                                        Throw New Exception("ITEM / PLATO HA SIDO ACTUALIZADO o ANULADO POR OTRO USUARIO, VERIFIQUE")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete rest_temporalmesas where auto_item=@auto_item and id_seguridad=@id_seguridad"
                                    xcmd.Parameters.AddWithValue("@auto_item", xdr._AutoItem)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xdr._Id)
                                    xcmd.ExecuteNonQuery()
                                Next

                                Dim xrw1 As Integer = 0
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select count(*) from rest_temporalmesas where mesa=@mesa and parallevar=@parallevar"
                                xcmd.Parameters.AddWithValue("@mesa", xtb_venta._Rest_NumeroMesaPedido)
                                If xtb_venta._Rest_ModoMesaPedido = TipoPedido.ParaMesa Then
                                    xcmd.Parameters.AddWithValue("@parallevar", "0")
                                Else
                                    xcmd.Parameters.AddWithValue("@parallevar", "1")
                                End If
                                xrw1 = xcmd.ExecuteScalar()
                                If xrw1 > 0 Then
                                    Throw New Exception("MESA / PEDIDO  HA SIDO ACTUALIZADA POR OTRO USUARIO, VERIFIQUE")
                                End If

                                If xtb_venta._Rest_ModoMesaPedido = TipoPedido.ParaMesa Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "delete rest_mesas where auto=@auto"
                                    xcmd.Parameters.AddWithValue("@auto", xventa._Encabezado._AutoMonitorMesa)
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("MESA A FACTURAR YA FUE PROCESADA POR OTRO USUARIO..., VERIFIQUE")
                                    End If
                                End If

                                Dim xcontrol As Integer = 0
                                Dim xcont As String = ""
                                Dim xz As Integer = 0
                                If impfiscal IsNot Nothing Then
                                    Integer.TryParse(impfiscal.Ver_UltimaFacturaRegistrada, xcontrol)
                                    Integer.TryParse(impfiscal.Ver_UltimoZFiscal, xz)
                                    xcontrol += 1
                                    xz += 1
                                    xcont = xcontrol.ToString.Trim.PadLeft(10, "0")
                                End If

                                'VENTAS. PARA ACTUALIZAR EL # DE CONTROL  DEL DOCUMENTO
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update ventas set control = @control, relacion_z=@relacion_z where auto = @auto"
                                xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto).Size = xtb_venta.c_AutoDocumento.c_Largo
                                xcmd.Parameters.AddWithValue("@control", xcont).Size = xtb_venta.c_ControlFiscal.c_Largo
                                xcmd.Parameters.AddWithValue("@relacion_z", xz)
                                xcmd.ExecuteNonQuery()

                                If xmodo = ModoFactura.Legal Then
                                    With impfiscal
                                        .FacturaInicializa(xtb_venta.c_Tasa1.c_Valor, _
                                                           xtb_venta.c_Tasa2.c_Valor, _
                                                           xtb_venta.c_Tasa3.c_Valor)

                                        .Cli_CondicionVenta = xtb_venta.c_CondicionPago.c_Texto.Trim
                                        .Cli_DirCliente = xtb_venta.c_DirFiscalCliente.c_Texto.Trim
                                        .Cli_EstacionVenta = xtb_venta.c_EstacionEquipo.c_Texto.Trim
                                        .Cli_FacturaVenta = xtb_venta.c_Documento.c_Texto.Trim
                                        .Cli_NomCliente = xtb_venta.c_NombreCliente.c_Texto.Trim
                                        .Cli_RifCliente = xtb_venta.c_CiRifCliente.c_Texto.Trim
                                        .Cli_TelCliente = xtb_venta.c_TelefonoCliente.c_Texto.Trim
                                        .Cli_UsuarioVenta = xtb_venta.c_Usuario.c_Texto.Trim
                                        .Cli_LineaEncabezado1 = "MESA #: " + xtb_venta._Rest_NumeroMesaPedido
                                        .AutoDocumento = xtb_venta._AutoDocumento
                                        .Cli_DocumentoVenta = xtb_venta._Documento

                                        .CargoGlobal = xtb_venta.c_TasaCargos.c_Valor
                                        .DsctoGlobal = xtb_venta.c_TasaDescuento_1.c_Valor
                                    End With

                                    Dim xmontorecibe As Decimal = 0
                                    If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado Then
                                        xmontorecibe = xventa._Encabezado._TotalGeneral
                                    End If
                                    If xventa._Encabezado._TotalGeneral > 0 Then
                                        ImprimeFactura_3(impfiscal, xtablaprd, xmontorecibe, xventa._Encabezado._TotalGeneral, xpagos)
                                    Else
                                        Throw New Exception("NO SE PUEDE GENERAR UNA FACTURA FISCAL DE MONTO CERO (0)")
                                    End If
                                End If

                                xtr.Commit()
                            End Using
                            Dim xr As Decimal = xventa._MontoRecibido - xtb_venta._TotalGenereal

                            RaiseEvent _FacturaGrabadaOk()
                            If xmodo = ModoFactura.Chimba Then
                                RaiseEvent _ImprimirFacturaChimba(xtb_venta._AutoDocumento)
                            End If
                            RaiseEvent _VisorCambioDar(xr)

                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO Y SERIE, VERIFIQUE" + vbCrLf + xsql.Message)
                            ElseIf xsql.Number = 547 Then
                                Throw New Exception("ERROR... AL PARECER EL CLIENTE / VENDEDOR SELECCIONADO FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE" + vbCrLf + xsql.Message)
                            Else
                                Throw New Exception(xsql.Message + vbCrLf + "ERROR NUMERO: " + xsql.Number.ToString)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("VENTAS" + vbCrLf + "ERROR AL GRABAR VENTA:" + vbCrLf + ex.Message)
                End Try
            End Function


            Function ImprimeFactura_3(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal, ByVal formasPago As List(Of FormaPago)) As Boolean
                Try
                    xfiscal.FacturaEncabezado()
                    For Each dr As DataRow In xtablaprd.Rows
                        xfiscal.LimpiarItem()
                        xfiscal.Prd_CantidadPrd = dr("cantidad")
                        xfiscal.Prd_DetallePrd = dr("nombre")
                        xfiscal.Prd_PNetoPrd = dr("precio_neto")
                        xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                        xfiscal.Prd_Empaque = ""
                        xfiscal.Prd_Codigo = ""
                        xfiscal.FacturaDetalle()
                    Next

                    xfiscal.MedioPago_1 = xmonto_recibe + 1
                    xfiscal.FacturaCerrar()
                    Return True
                Catch ex As Exception
                    Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                End Try
                Return True
            End Function


            Function ImprimeFactura(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal, ByVal formasPago As List(Of FormaPago)) As Boolean
                'If TypeOf (xfiscal) Is ImpFiscales.MisFiscales.HKA112 Then
                '    Dim xlib As New [Lib].Provider.HKA112(xfiscal.PuertoConexion, [Lib].IFiscal.ModelosFiscales.HKA112)
                '    xlib.FacturaInicializa(12, 8, 21)

                '    Try
                '        With xlib
                '            .Cli_NomCliente = xfiscal.Cli_NomCliente
                '            .Cli_RifCliente = xfiscal.Cli_RifCliente
                '            .Cli_CondicionVenta = xfiscal.Cli_CondicionVenta
                '            .Cli_DirCliente = xfiscal.Cli_DirCliente
                '            .Cli_TelCliente = xfiscal.Cli_TelCliente
                '            .Cli_UsuarioVenta = xfiscal.Cli_UsuarioVenta
                '            .Cli_DocumentoVenta = xfiscal.Cli_DocumentoVenta
                '            .Cli_EstacionVenta = xfiscal.Cli_EstacionVenta
                '            .Cli_FacturaVenta = xfiscal.Cli_FacturaVenta
                '            .Cli_LineaEncabezado1 = xfiscal.Cli_LineaEncabezado1
                '            .AutoDocumento = xfiscal.AutoDocumento
                '            .CargoGlobal = xfiscal.CargoGlobal
                '            .DsctoGlobal = xfiscal.DsctoGlobal
                '        End With

                '        xlib.FacturaEncabezado()
                '        For Each dr As DataRow In xtablaprd.Rows
                '            xlib.LimpiarItem()
                '            xlib.Prd_CantidadPrd = dr("cantidad")
                '            xlib.Prd_DetallePrd = dr("nombre")
                '            xlib.Prd_PNetoPrd = dr("precio_neto")
                '            xlib.Prd_TasaIvaPrd = dr("codigo_tasa")
                '            xlib.Prd_Empaque = ""
                '            xlib.Prd_Codigo = ""
                '            xlib.Prd_Nota1Prd = ""
                '            xlib.Prd_Nota2Prd = ""
                '            xlib.Prd_Nota3Prd = ""
                '            xlib.FacturaDetalle()
                '        Next
                '        If xmonto_recibe >= xtotalfactura Then
                '            xlib.MedioPago_1 = xmonto_recibe
                '        Else
                '            xlib.MedioPago_7 = xtotalfactura
                '        End If
                '        xlib.FacturaCerrar()
                '        Return True
                '    Catch ex As Exception
                '        Try
                '            xlib.AbortarDF()
                '        Catch ex2 As Exception
                '        End Try
                '        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                '    End Try

                'Else
                '    Try
                '        xfiscal.FacturaEncabezado()
                '        For Each dr As DataRow In xtablaprd.Rows
                '            xfiscal.LimpiarItem()
                '            xfiscal.Prd_CantidadPrd = dr("cantidad")
                '            xfiscal.Prd_DetallePrd = dr("nombre")
                '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
                '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                '            xfiscal.Prd_Empaque = ""
                '            xfiscal.Prd_Codigo = ""
                '            xfiscal.Prd_Nota1Prd = ""
                '            xfiscal.Prd_Nota2Prd = ""
                '            xfiscal.Prd_Nota3Prd = ""
                '            xfiscal.FacturaDetalle()
                '        Next

                '        If xmonto_recibe >= xtotalfactura Then
                '            xfiscal.MedioPago_1 = xmonto_recibe
                '        Else
                '            xfiscal.MedioPago_7 = xtotalfactura
                '        End If
                '        xfiscal.FacturaCerrar()
                '        Return True
                '    Catch ex As Exception
                '        Try
                '            xfiscal.AbortarDF()
                '        Catch ex2 As Exception
                '        End Try
                '        Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                '    End Try
                'End If

                Try
                    xfiscal.FacturaEncabezado()
                    For Each dr As DataRow In xtablaprd.Rows
                        xfiscal.LimpiarItem()
                        xfiscal.Prd_CantidadPrd = dr("cantidad")
                        xfiscal.Prd_DetallePrd = dr("nombre")
                        xfiscal.Prd_PNetoPrd = dr("precio_neto")
                        xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                        xfiscal.Prd_Empaque = ""
                        xfiscal.Prd_Codigo = ""
                        xfiscal.Prd_Nota1Prd = ""
                        xfiscal.Prd_Nota2Prd = ""
                        xfiscal.Prd_Nota3Prd = ""
                        xfiscal.FacturaDetalle()
                    Next

                    'If xmonto_recibe >= xtotalfactura Then
                    '    xfiscal.MedioPago_1 = xmonto_recibe
                    'Else
                    '    xfiscal.MedioPago_7 = xtotalfactura
                    'End If

                    If xmonto_recibe >= xtotalfactura Then
                        For Each met As FormaPago In formasPago
                            Select Case met.Tipo
                                Case FormaPago.TipoPago.EfectivoTickets
                                    xfiscal.MedioPago_1 = met.Monto
                                Case FormaPago.TipoPago.Cheque
                                    xfiscal.MedioPago_2 = met.Monto
                                Case FormaPago.TipoPago.TDebito
                                    xfiscal.MedioPago_3 = met.Monto
                                Case FormaPago.TipoPago.TCredito
                                    xfiscal.MedioPago_4 = met.Monto
                                Case FormaPago.TipoPago.Otros
                                    xfiscal.MedioPago_5 = met.Monto
                            End Select
                        Next
                        'xfiscal.MedioPago_1 = xmonto_recibe
                    Else
                        xfiscal.MedioPago_7 = xtotalfactura
                    End If



                    xfiscal.FacturaCerrar()
                    Return True
                Catch ex As Exception
                    Try
                        xfiscal.AbortarDF()
                    Catch ex2 As Exception
                    End Try
                    Throw New Exception("PROBLEMA AL IMPRIMIR FACTURA FISCAL" + vbCrLf + ex.Message)
                End Try
                Return True
            End Function

            'Function ImprimeFactura(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal) As Boolean
            '    Try
            '        xfiscal.FacturaEncabezado()

            '        For Each dr As DataRow In xtablaprd.Rows
            '            xfiscal.LimpiarItem()
            '            xfiscal.Prd_CantidadPrd = dr("cantidad")
            '            xfiscal.Prd_DetallePrd = dr("nombre")
            '            xfiscal.Prd_PNetoPrd = dr("precio_neto")
            '            xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
            '            xfiscal.FacturaDetalle()
            '        Next

            '        If xmonto_recibe >= xtotalfactura Then
            '            xfiscal.MedioPago_1 = xtotalfactura
            '        Else
            '            xfiscal.MedioPago_7 = xtotalfactura
            '        End If

            '        xfiscal.FacturaCerrar()
            '        Return True
            '    Catch ex As Exception
            '        Try
            '            xfiscal.AbortarDF()
            '        Catch ex2 As Exception
            '        End Try
            '        Throw New Exception("ERROR AL IMPRIMIR FACTURA FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
            '    End Try
            'End Function

            Function F_UnirMesas(ByVal XDATA As AgregarCambioMesa) As Boolean
                Try
                    Dim xtr As SqlTransaction = Nothing
                    Dim xreg As New CambioUnionMesas.c_Registro

                    With xreg
                        .c_AutoJornada._ContenidoCampo = XDATA._FichaJornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = XDATA._FichaOperador._AutoOperador
                        .c_AutoUsuario._ContenidoCampo = XDATA._FichaUsuario._AutoUsuario
                        .c_DeLaMesa._ContenidoCampo = XDATA._MesaInicio
                        .c_EquipoEstacion._ContenidoCampo = XDATA._Equipo
                        .c_FechaProceso._ContenidoCampo = XDATA._Fecha
                        .c_Hora._ContenidoCampo = XDATA._Hora
                        .c_Motivo._ContenidoCampo = XDATA._Motivo
                        Select Case XDATA._NivelClaveUsada
                            Case NivelClave.Maxima : .c_NivelClaveUsada._ContenidoCampo = "1"
                            Case NivelClave.Media : .c_NivelClaveUsada._ContenidoCampo = "2"
                            Case NivelClave.Minima : .c_NivelClaveUsada._ContenidoCampo = "3"
                            Case NivelClave.SinClave : .c_NivelClaveUsada._ContenidoCampo = "0"
                        End Select
                        .c_NombreUsuario._ContenidoCampo = XDATA._FichaUsuario._NombreUsuario
                        .c_ParaLaMesa._ContenidoCampo = XDATA._MesaDestino
                        Select Case XDATA._TipoMovimiento
                            Case TipoMovimientoMesa.PorCambio : .c_TipoMovimiento._ContenidoCampo = "C"
                            Case TipoMovimientoMesa.PorUnion : .c_TipoMovimiento._ContenidoCampo = "U"
                            Case TipoMovimientoMesa.PorTraslado : .c_TipoMovimiento._ContenidoCampo = "T"
                        End Select
                    End With

                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Dim xautomonitor As String = ""
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto from rest_mesas where mesa=@mesa"
                                xcmd.Parameters.AddWithValue("@mesa", XDATA._MesaDestino)
                                xautomonitor = xcmd.ExecuteScalar()
                                If IsDBNull(xautomonitor) Or xautomonitor = "" Then
                                    Throw New Exception("MESA A LA CUAL SE VA A UNIR NO EXISTE / NO ENCCONTRADA... VERIFIQUE")
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = CambioUnionMesas.InsertarCambioUnion
                                With xcmd.Parameters
                                    .AddWithValue("@" + xreg.c_AutoJornada._NombreCampo, xreg._AutoJornada).Size = xreg.c_AutoJornada._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoOperador._NombreCampo, xreg._AutoOperador).Size = xreg.c_AutoOperador._LargoCampo
                                    .AddWithValue("@" + xreg.c_AutoUsuario._NombreCampo, xreg._AutoUsuario).Size = xreg.c_AutoUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_DeLaMesa._NombreCampo, xreg._DeLaMesa).Size = xreg.c_DeLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_EquipoEstacion._NombreCampo, xreg._EquipoEstacion).Size = xreg.c_EquipoEstacion._LargoCampo
                                    .AddWithValue("@" + xreg.c_FechaProceso._NombreCampo, xreg._FechaProceso).Size = xreg.c_FechaProceso._LargoCampo
                                    .AddWithValue("@" + xreg.c_Hora._NombreCampo, xreg._Hora).Size = xreg.c_Hora._LargoCampo
                                    .AddWithValue("@" + xreg.c_Motivo._NombreCampo, xreg._Motivo).Size = xreg.c_Motivo._LargoCampo
                                    .AddWithValue("@" + xreg.c_NivelClaveUsada._NombreCampo, xreg.c_NivelClaveUsada._ContenidoCampo).Size = xreg.c_NivelClaveUsada._LargoCampo
                                    .AddWithValue("@" + xreg.c_NombreUsuario._NombreCampo, xreg._NombreUsuario).Size = xreg.c_NombreUsuario._LargoCampo
                                    .AddWithValue("@" + xreg.c_ParaLaMesa._NombreCampo, xreg._ParaLaMesa).Size = xreg.c_ParaLaMesa._LargoCampo
                                    .AddWithValue("@" + xreg.c_TipoMovimiento._NombreCampo, xreg.c_TipoMovimiento._ContenidoCampo).Size = xreg.c_TipoMovimiento._LargoCampo
                                End With
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update rest_TEMPORALMESAS set Unida = @MESAINICIO WHERE MESA=@MESAINICIO AND UNIDA=''"
                                xcmd.Parameters.AddWithValue("@MESAINICIO", XDATA._MesaInicio)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "Update rest_TEMPORALMESAS set MESA = @MESADESTINO, AUTO_MESA_MONITOR=@AUTOMONITOR WHERE MESA=@MESAINICIO"
                                xcmd.Parameters.AddWithValue("@MESAINICIO", XDATA._MesaInicio)
                                xcmd.Parameters.AddWithValue("@MESADESTINO", XDATA._MesaDestino)
                                xcmd.Parameters.AddWithValue("@AUTOMONITOR", xautomonitor)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "DELETE rest_MESAS WHERE AUTO=@AUTOMONITOR"
                                xcmd.Parameters.AddWithValue("@AUTOMONITOR", XDATA._AutoMonitorMesa)
                                If xcmd.ExecuteNonQuery() = 0 Then
                                    Throw New Exception("MESA A UNIR HA SIDO ELIMINADA / FACTURADA POR OTRO USUARIO")
                                End If

                            End Using
                            xtr.Commit()

                            RaiseEvent _UnionOk(XDATA._MesaDestino)
                            Return True
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("ERROR AL TRATAR DE UNIR MESAS:" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_VerificarUnionMesa(ByVal xmesa As Integer) As Boolean
                Try
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()

                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select count(distinct unida) from rest_temporalmesas where mesa=@mesa and parallevar='0'"
                                xcmd.Parameters.AddWithValue("@mesa", xmesa)
                                If xcmd.ExecuteScalar() > 1 Then
                                    Return True
                                Else
                                    Return False
                                End If
                            End Using
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("VERIFICAR SI LA MESA ESTA / NO UNIDA" + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_AsignarIdMesa(ByVal xmesamonitor As MonitorMesas.c_Registro, ByVal xid As String) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "update rest_mesas set ci_rif=@ci_rif where auto=@auto"
                                xcmd.Parameters.AddWithValue("@auto", xmesamonitor._Auto)
                                xcmd.Parameters.AddWithValue("@ci_rif", xid)
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PROBLEMA AL ACTUALIZAR ID DE LA MESA")
                                End If
                                xtr.Commit()
                                RaiseEvent _IdMesaActualizado()
                                Return True
                            End Using
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA EN MONITOR MESA " + vbCrLf + ex.Message)
                End Try
            End Function

            Function F_EliminarCtaMovil(ByVal xid As Integer) As Boolean
                Try
                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "delete rest_ImprimirCuentaMovil where id=@id"
                                xcmd.Parameters.AddWithValue("@id", xid)
                                If xcmd.ExecuteNonQuery = 0 Then
                                    Throw New Exception("PROBLEMA AL ELIMINAR CTA MOVIL")
                                End If
                                xtr.Commit()

                                Return True
                            End Using
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("PROBLEMA EN CTA MOVIL" + vbCrLf + ex.Message)
                End Try
            End Function


        End Class


        Private xficharestaurant As Restaurant


        Property f_FichaRestaurant() As Restaurant
            Get
                Return Me.xficharestaurant
            End Get
            Set(ByVal value As Restaurant)
                Me.xficharestaurant = value
            End Set
        End Property
    End Class
End Namespace
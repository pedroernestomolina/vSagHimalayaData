Imports System.Data
Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FichaGlobal
            ''' <summary>
            ''' CLASE: CARGA DE PERMISOS ASIGNADOS AL USUARIO
            ''' </summary>
            Class c_PermisosDelUsuario
                Enum Nivel As Integer
                    Nivel_Maximo = 0
                    Nivel_Medio = 1
                    Nivel_Minimo = 2
                    Nivel_Libre = 3
                End Enum

                Class Permiso
                    Private f_estatus As String
                    Private f_nivel As String

                    ''' <summary>
                    ''' Campo, Estatus Opcion
                    ''' </summary>
                    Property _EstatusPermiso() As String
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As String)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Nivel Opcion
                    ''' </summary>
                    Property _Nivel() As String
                        Get
                            Return f_nivel
                        End Get
                        Set(ByVal value As String)
                            f_nivel = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Opcion
                    ''' </summary>
                    ReadOnly Property r_PermitirOpcion() As Boolean
                        Get
                            If Me._EstatusPermiso.ToString.Trim.ToUpper = "1" Then
                                Return True
                            Else
                                Return False
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Nivel Opcion
                    ''' </summary>
                    ReadOnly Property r_NivelSeguridadOpcion() As Nivel
                        Get
                            Select Case Me._Nivel.ToString.Trim.ToUpper
                                Case "NINGUNA"
                                    Return Nivel.Nivel_Libre
                                Case "MAXIMO"
                                    Return Nivel.Nivel_Maximo
                                Case "MEDIO"
                                    Return Nivel.Nivel_Medio
                                Case "MINIMO"
                                    Return Nivel.Nivel_Minimo
                            End Select
                        End Get
                    End Property

                    ''' <summary>
                    ''' Function: Valida Si Puede O No Usar Este Modulo
                    ''' </summary>
                    Function F_Permitir() As Boolean
                        If r_PermitirOpcion Then
                            If r_NivelSeguridadOpcion = Nivel.Nivel_Libre Then
                                Return True
                            Else
                                Dim xficha As New ClaveSeguridad
                                Dim xclave As String
                                Dim xsalida As Boolean
                                With xficha
                                    .ShowDialog()
                                    xsalida = ._EstatusSalida
                                    xclave = ._ClaveRetornar
                                End With
                                If xsalida Then
                                    If r_NivelSeguridadOpcion = Nivel.Nivel_Maximo Then
                                        If xclave = MiDataSistema.DataSistema.p_ClaveNivelMaximo Then
                                            Return True
                                        Else
                                            Throw New Exception("Error Clave Incorrecta.... Consulte Con El Administrador Del Sistema")
                                        End If
                                    End If
                                    If r_NivelSeguridadOpcion = Nivel.Nivel_Medio Then
                                        If xclave = MiDataSistema.DataSistema.p_ClaveNivelMaximo Or xclave = MiDataSistema.DataSistema.p_ClaveNivelMedio Then
                                            Return True
                                        Else
                                            Throw New Exception("Error Clave Incorrecta.... Consulte Con El Administrador Del Sistema")
                                        End If
                                    End If
                                    If r_NivelSeguridadOpcion = Nivel.Nivel_Minimo Then
                                        If xclave = MiDataSistema.DataSistema.p_ClaveNivelMaximo Or xclave = MiDataSistema.DataSistema.p_ClaveNivelMedio Or xclave = MiDataSistema.DataSistema.p_ClaveNivelMinimo Then
                                            Return True
                                        Else
                                            Throw New Exception("Error Clave Incorrecta.... Consulte Con El Administrador Del Sistema")
                                        End If
                                    End If
                                Else
                                    Throw New Exception("Error Clave Incorrecta.... Consulte Con El Administrador Del Sistema")
                                End If
                            End If
                        Else
                            Throw New Exception("Opcion No Disponible Para Usted.... Consulte Con El Administrador Del Sistema")
                        End If
                    End Function

                    Sub New()
                        Me._EstatusPermiso = ""
                        Me._Nivel = ""
                    End Sub
                End Class

                Private xmodulocliente As Permiso
                Private xmodulocliente_nuevo As Permiso
                Private xmodulocliente_modificar As Permiso
                Private xmodulocliente_eliminar As Permiso
                Private xcliente_reportes_datoscontacto As Permiso
                Private xcliente_reportes_datoscomerciales As Permiso
                Private xcliente_reportes_estadocuenta As Permiso
                Private xcliente_reportes_retencionesiva As Permiso

                Private xmodulogrupocliente As Permiso
                Private xmodulogrupocliente_nuevo As Permiso
                Private xmodulogrupocliente_modificar As Permiso
                Private xmodulogrupocliente_eliminar As Permiso

                Private xmoduloZonacliente As Permiso
                Private xmoduloZonacliente_nuevo As Permiso
                Private xmoduloZonacliente_modificar As Permiso
                Private xmoduloZonacliente_eliminar As Permiso

                Private xmoduloproveedor As Permiso
                Private xmoduloproveedor_nuevo As Permiso
                Private xmoduloproveedor_modificar As Permiso
                Private xmoduloproveedor_eliminar As Permiso
                Private xproveedor_reportes_datoscontacto As Permiso
                Private xproveedor_reportes_datoscomerciales As Permiso
                Private xproveedor_reportes_estadocuenta As Permiso
                Private xproveedor_reportes_retencionesiva As Permiso

                Private xmodulogrupoproveedor As Permiso
                Private xmodulogrupoproveedor_nuevo As Permiso
                Private xmodulogrupoproveedor_modificar As Permiso
                Private xmodulogrupoproveedor_eliminar As Permiso

                Private xmoduloctabancariaproveedor As Permiso
                Private xmoduloctabancariaproveedor_nuevo As Permiso
                Private xmoduloctabancariaproveedor_modificar As Permiso
                Private xmoduloctabancariaproveedor_eliminar As Permiso

                Private xmoduloagenciabancaria As Permiso
                Private xmoduloagenciabancaria_nuevo As Permiso
                Private xmoduloagenciabancaria_modificar As Permiso
                Private xmoduloagenciabancaria_eliminar As Permiso

                Private xmodulovendedor As Permiso
                Private xmodulovendedor_nuevo As Permiso
                Private xmodulovendedor_modificar As Permiso
                Private xmodulovendedor_eliminar As Permiso
                Private xmodulovendedor_tablacomisiones As Permiso
                Private xreportevendedor_maestro As Permiso
                Private xreportevendedor_comisiones As Permiso
                Private xreportevendedor_comisionesventasdetalle As Permiso

                Private xmodulocobrador As Permiso
                Private xmodulocobrador_nuevo As Permiso
                Private xmodulocobrador_modificar As Permiso
                Private xmodulocobrador_eliminar As Permiso
                Private xmodulocobrador_tablacomisiones As Permiso
                Private xreportecobrador_maestro As Permiso
                Private xreportecobrador_comisiones As Permiso

                Private xventa_adm_vercosto As Permiso
                Private xventa_adm_dar_descuento_item As Permiso
                Private xventa_adm_precio_libre As Permiso
                Private xventa_adm_recuperar_documentos As Permiso

                Private xvisorfiscal As Permiso
                Private xvisorfiscal_x As Permiso
                Private xvisorfiscal_z As Permiso
                Private xvisorfiscal_reportes_z As Permiso
                Private xvisorfiscal_reportes_doc As Permiso

                Private xventa_controlventas As Permiso
                Private xventa_controlventas_chimbas As Permiso
                Private xventa_controlpresupuesto As Permiso
                Private xventa_controlnotasentrega As Permiso
                Private xventa_controlnotacredito As Permiso
                Private xventa_controlnotasdebito As Permiso
                Private xventa_controlpedidos As Permiso
                Private xventa_adm_documentos As Permiso
                Private xventa_anulardocumento As Permiso
                Private xventa_revertirdocumento As Permiso
                Private xventa_retenciones_iva As Permiso
                Private xventa_adm_documentos_retenciones As Permiso
                Private xventa_anulardocumento_retenciones As Permiso
                Private xventa_reportes_libroventa As Permiso
                Private xventa_reportes_generaldocumento As Permiso
                Private xventa_reportes_consolidado As Permiso
                Private xventa_reportes_pordepartamento As Permiso
                Private xventa_reportes_porgrupo As Permiso
                Private xventa_reportes_utilidad As Permiso
                Private xventa_reportes_resumen_cuadre As Permiso
                Private xventa_reportes_estadistico As Permiso

                Private xmoduloinventario As Permiso
                Private xmoduloinventario_nuevo As Permiso
                Private xmoduloinventario_modificar As Permiso
                Private xmoduloinventario_eliminar As Permiso
                Private xmoduloinventario_departamento As Permiso
                Private xmoduloinventario_departamento_nuevo As Permiso
                Private xmoduloinventario_departamento_modificar As Permiso
                Private xmoduloinventario_departamento_eliminar As Permiso
                Private xmoduloinventario_kardex As Permiso
                Private xmoduloinventario_modificar_costo As Permiso
                Private xmoduloinventario_modificar_precios As Permiso
                Private xmoduloinventario_modificar_existencia As Permiso
                Private xmoduloinventario_marca As Permiso
                Private xmoduloinventario_marca_nuevo As Permiso
                Private xmoduloinventario_marca_modificar As Permiso
                Private xmoduloinventario_marca_eliminar As Permiso
                Private xmoduloinventario_deposito As Permiso
                Private xmoduloinventario_deposito_nuevo As Permiso
                Private xmoduloinventario_deposito_modificar As Permiso
                Private xmoduloinventario_deposito_eliminar As Permiso
                Private xmoduloinventario_concepto As Permiso
                Private xmoduloinventario_concepto_nuevo As Permiso
                Private xmoduloinventario_concepto_modificar As Permiso
                Private xmoduloinventario_concepto_eliminar As Permiso
                Private xmoduloinventario_medida As Permiso
                Private xmoduloinventario_medida_nuevo As Permiso
                Private xmoduloinventario_medida_modificar As Permiso
                Private xmoduloinventario_medida_eliminar As Permiso
                Private xmoduloinventario_DeptoPtoVenta As Permiso
                Private xmoduloinventario_DeptoPtoVenta_nuevo As Permiso
                Private xmoduloinventario_DeptoPtoVenta_modificar As Permiso
                Private xmoduloinventario_DeptoPtoVenta_eliminar As Permiso
                Private xmoduloinventario_GrupoSubGrupo As Permiso
                Private xmoduloinventario_GrupoSubGrupo_nuevo As Permiso
                Private xmoduloinventario_GrupoSubGrupo_modificar As Permiso
                Private xmoduloinventario_GrupoSubGrupo_eliminar As Permiso

                Private xinventario_reportes_maestrodatos As Permiso
                Private xinventario_reportes_precio_inv As Permiso
                Private xinventario_reportes_lista_precio As Permiso
                Private xinventario_reportes_existencia As Permiso
                Private xinventario_reportes_mov_concepto As Permiso
                Private xinventario_reportes_valorizacion As Permiso
                Private xinventario_reportes_proyeccion As Permiso

                Private xmodulocxc_ControlCuentas As Permiso
                Private xmodulocxc_AdministradorDocumentos As Permiso
                Private xmodulocxc_AnularDocumento As Permiso
                Private xmodulocxc_reportes_DocumentosxCobrar As Permiso
                Private xmodulocxc_reportes_CobranzaDiaria As Permiso
                Private xmodulocxc_reportes_PagosEmitidos As Permiso
                Private xmodulocxc_reportes_AnalisisVencimiento As Permiso

                Private xmodulo_usuario As Permiso
                Private xmodulo_usuario_nuevo As Permiso
                Private xmodulo_usuario_modificar As Permiso
                Private xmodulo_usuario_eliminar As Permiso
                Private xmodulogrupo_usuario As Permiso
                Private xmodulogrupo_usuario_nuevo As Permiso
                Private xmodulogrupo_usuario_modificar As Permiso
                Private xmodulogrupo_usuario_eliminar As Permiso
                Private xmodulogrupo_usuario_permisos As Permiso

                Private xserviciobd_compactar As Permiso
                Private xserviciobd_respaldar As Permiso
                Private xserviciobd_website As Permiso
                Private xserviciobd_monitoreo As Permiso
                Private xserviciobd_mantenimiento As Permiso

                Private xmodulo_datosnegocio As Permiso
                Private xmodulo_tasasfiscales As Permiso
                Private xmodulo_seriesfiscales As Permiso
                Private xmodulo_seriesfiscales_nuevo As Permiso
                Private xmodulo_seriesfiscales_modificar As Permiso
                Private xmodulo_seriesfiscales_eliminar As Permiso
                Private xmodulo_configuracion As Permiso

                Private xmodulo_mediopago As Permiso
                Private xmodulo_mediopago_nuevo As Permiso
                Private xmodulo_mediopago_modificar As Permiso
                Private xmodulo_mediopago_eliminar As Permiso

                Private xmodulocompras_controlcompras As Permiso
                Private xmodulocompras_controlcomprasgastos As Permiso
                Private xmodulocompras_ordencompra As Permiso
                Private xmodulocompras_admdocumentos As Permiso
                Private xmodulocompras_anulardocumento As Permiso
                Private xmodulocompras_notascredito As Permiso
                Private xmodulocompras_retenciones As Permiso
                Private xmodulocompras_admretenciones As Permiso
                Private xmodulocompras_anularretenciones As Permiso
                Private xmodulocompras_actualizarpreciosventas As Permiso

                Private xmodulocompras_reportes_librodecompra As Permiso
                Private xmodulocompras_reportes_general As Permiso
                Private xmodulocompras_reportes_pordepartamento As Permiso
                Private xmodulocompras_reportes_retenciones As Permiso
                Private xmodulocompras_reportes_porgrupos As Permiso
                Private xmodulocompras_generar_txt As Permiso

                Private xmodulocxp_ControlCuentas As Permiso
                Private xmodulocxp_AdministradorDocumentos As Permiso
                Private xmodulocxp_AnularDocumento As Permiso
                Private xmodulocxp_reportes_DocumentosxPagar As Permiso
                Private xmodulocxp_reportes_PagosEmitidos As Permiso
                Private xmodulocxp_reportes_AnalisisVencimiento As Permiso

                'FASTFOOD
                Private xmodulofastfood_activarmodulo As Permiso
                Private xmodulofastfood_menuplatos As Permiso
                Private xmodulofastfood_admdocumentos As Permiso
                Private xmodulofastfood_reportecuadrecaja As Permiso
                Private xmodulofastfood_serviciofiscal As Permiso
                Private xmodulofastfood_configuraciongeneral As Permiso
                Private xmodulofastfood_iniciarjornada As Permiso
                Private xmodulofastfood_abrirptoventa As Permiso
                Private xmodulofastfood_cerraroperador As Permiso
                Private xmodulofastfood_cerrarjornada As Permiso
                Private xmodulofastfood_admjornadas As Permiso
                Private xmodulofastfood_reimprimircuadrecaja As Permiso
                Private xmodulofastfood_elaborarnotacredito As Permiso
                Private xmodulofastfood_anularnotacredito As Permiso
                Private xmodulofastfood_reporteX As Permiso
                Private xmodulofastfood_reporteZ As Permiso
                Private xmodulofastfood_reporteZ_Acumulado As Permiso
                Private xmodulofastfood_DocumentosAcumuladosFiscal As Permiso

                Private xmodulofastfood_pto_abrirgaveta As Permiso
                Private xmodulofastfood_pto_fondo As Permiso
                Private xmodulofastfood_pto_retiro As Permiso
                Private xmodulofastfood_pto_activarinventario As Permiso
                Private xmodulofastfood_pto_pendientes As Permiso
                Private xmodulofastfood_pto_eliminar_pendientes As Permiso
                Private xmodulofastfood_pto_eliminar_todas_pendientes As Permiso
                Private xmodulofastfood_pto_anular_pedido As Permiso
                Private xmodulofastfood_pto_devolucion As Permiso
                Private xmodulofastfood_pto_eliminar_item As Permiso
                Private xmodulofastfood_pto_ajustar_item As Permiso
                Private xmodulofastfood_pto_dardescuento_facturar As Permiso
                Private xmodulofastfood_pto_ctacredito_facturar As Permiso
                Private xmodulofastfood_pto_reenviarcomandas As Permiso

                Private xmodulofastfood_menu_modulogrupo As Permiso
                Private xmodulofastfood_menu_modulogrupo_agregar As Permiso
                Private xmodulofastfood_menu_modulogrupo_modificar As Permiso
                Private xmodulofastfood_menu_modulogrupo_eliminar As Permiso
                Private xmodulofastfood_menu_moduloestacion As Permiso
                Private xmodulofastfood_menu_moduloestacion_agregar As Permiso
                Private xmodulofastfood_menu_moduloestacion_modificar As Permiso
                Private xmodulofastfood_menu_moduloestacion_eliminar As Permiso
                Private xmodulofastfood_menu_agregar As Permiso
                Private xmodulofastfood_menu_modificar As Permiso
                Private xmodulofastfood_menu_eliminar As Permiso

                Private xmodulofastfood_menu_opcion_balanza As Permiso
                Private xmodulofastfood_menu_opcion_combo As Permiso
                Private xmodulofastfood_menu_opcion_estaciones As Permiso
                Private xmodulofastfood_menu_opcion_precioventa As Permiso
                Private xmodulofastfood_menu_opcion_oferta As Permiso
                Private xmodulofastfood_menu_opcion_inventario As Permiso
                Private xmodulofastfood_menu_opcion_imagen As Permiso


                'RESTAURANT
                Private xmoduloresturant_activarmodulo As Permiso
                Private xmoduloresturant_unirmesas As Permiso
                Private xmoduloresturant_cambiomesa As Permiso
                Private xmoduloresturant_anularmesa As Permiso
                Private xmoduloresturant_anularpedido As Permiso
                Private xmoduloresturant_trasladar_pedido_a_mesa As Permiso
                Private xmoduloresturant_devoluciones As Permiso
                Private xmoduloresturant_eliminar_item As Permiso
                Private xmoduloresturant_dar_descuento_facturar As Permiso
                Private xmoduloresturant_facturar_credito As Permiso


                'CONFIGURACION DISPOSITIVO
                Private xmodulo_cnf_dispositivo As Permiso


                'POS (ONLINE) ARRANCA EN 0808POS001
                Private xmoduloposonlie_abrirmodulo As Permiso
                Private xmoduloposonlie_iniciarjornada As Permiso
                Private xmoduloposonlie_abrirptoventa As Permiso
                Private xmoduloposonlie_cerraroperador As Permiso
                Private xmoduloposonlie_cerrarjornada As Permiso
                Private xmoduloposonlie_administradorjornada As Permiso
                Private xmoduloposonlie_cerrarjornada_con_ctaspendientes As Permiso
                Private xmoduloposonlie_cerrarjornada_con_ticketbalanzapendiente As Permiso
                Private xmoduloposonlie_administradorDocumentos As Permiso
                Private xmoduloposonlie_elaborarNCredito As Permiso
                Private xmoduloposonlie_anularNCredito As Permiso
                Private xmoduloposonlie_serviciofiscal As Permiso
                Private xmoduloposonlie_serviciofiscal_x As Permiso
                Private xmoduloposonlie_serviciofiscal_z As Permiso
                Private xmoduloposonlie_serviciofiscal_z_acumulado As Permiso
                Private xmoduloposonlie_serviciofiscal_doc_acumulado As Permiso
                Private xmoduloposonlie_configuracion As Permiso
                Private xmoduloposonlie_reportecuadre As Permiso
                Private xmoduloposonlie_reportecuadre_pantalla As Permiso

                Private xmoduloposonlie_pto_abrirgaveta As Permiso
                Private xmoduloposonlie_pto_fondo As Permiso
                Private xmoduloposonlie_pto_retiro As Permiso
                Private xmoduloposonlie_pto_activarctaspendientes As Permiso
                Private xmoduloposonlie_pto_eliminar_pendientes As Permiso
                Private xmoduloposonlie_pto_abrirpendientes_otros_usuarios As Permiso
                Private xmoduloposonlie_pto_devolucion_codbarra As Permiso
                Private xmoduloposonlie_pto_eliminar_item As Permiso
                Private xmoduloposonlie_pto_anular_venta_proceso As Permiso
                Private xmoduloposonlie_pto_ajustar_item_agregar As Permiso
                Private xmoduloposonlie_pto_permitirdardescuento As Permiso
                Private xmoduloposonlie_pto_permitirventacredito As Permiso
                Private xmoduloposonlie_pto_permitireditarcliente As Permiso
                Private xmoduloposonlie_pto_verificarexistencia As Permiso
                Private xmoduloposonlie_pto_activarptotarjeta_ctapendiente As Permiso
                Private xmoduloposonlie_pto_permitirventamayor As Permiso
                Private xmoduloposonlie_pto_anular_ticket_balanza As Permiso
                Private xmoduloposonlie_pto_cambiar_precio_cantidad As Permiso
                Private xmoduloposonlie_pto_eliminar_pendientes_todas As Permiso


                Private xtabla As DataTable


                '
                ' POS ONLINE 
                '

                Property op_PosOnline_EliminarTodasCuentasPendientes() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_eliminar_pendientes_todas
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_eliminar_pendientes_todas = value
                    End Set
                End Property


                Property op_PosOnline_PermitirCambiarPrecioCantidad() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_cambiar_precio_cantidad
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_cambiar_precio_cantidad = value
                    End Set
                End Property

                Property op_PosOnline_AnularTicketBalanza() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_anular_ticket_balanza
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_anular_ticket_balanza = value
                    End Set
                End Property

                Property op_PosOnline_AbrirGaveta() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_abrirgaveta
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_abrirgaveta = value
                    End Set
                End Property

                Property op_PosOnline_FondoInicio() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_fondo
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_fondo = value
                    End Set
                End Property

                Property op_PosOnline_RetiroDinero() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_retiro
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_retiro = value
                    End Set
                End Property

                Property op_PosOnline_ActivarCtasPendientes() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_activarctaspendientes
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_activarctaspendientes = value
                    End Set
                End Property

                Property op_PosOnline_EliminarCtasPendientes() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_eliminar_pendientes
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_eliminar_pendientes = value
                    End Set
                End Property

                Property op_PosOnline_AbrirCtsaOtrosUsuarios() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_abrirpendientes_otros_usuarios
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_abrirpendientes_otros_usuarios = value
                    End Set
                End Property

                Property op_PosOnline_DevItemCodBarra() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_devolucion_codbarra
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_devolucion_codbarra = value
                    End Set
                End Property

                Property op_PosOnline_EliminarItem() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_eliminar_item
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_eliminar_item = value
                    End Set
                End Property

                Property op_PosOnline_AnularVentaProceso() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_anular_venta_proceso
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_anular_venta_proceso = value
                    End Set
                End Property

                Property op_PosOnline_AjustarItem_Agregar() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_ajustar_item_agregar
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_ajustar_item_agregar = value
                    End Set
                End Property

                Property op_PosOnline_EditarDatosCliente() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_permitireditarcliente
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_permitireditarcliente = value
                    End Set
                End Property

                Property op_PosOnline_HabilitarDescuentoVenta() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_permitirdardescuento
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_permitirdardescuento = value
                    End Set
                End Property

                Property op_PosOnline_HabilitarVentaCredito() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_permitirventacredito
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_permitirventacredito = value
                    End Set
                End Property

                Property op_PosOnline_VerificarExistenciaAlFacturar() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_verificarexistencia
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_verificarexistencia = value
                    End Set
                End Property

                Property op_PosOnline_ActivarPtoTarjetaCtaPendiente() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_activarptotarjeta_ctapendiente
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_activarptotarjeta_ctapendiente = value
                    End Set
                End Property

                Property op_PosOnline_PermitirVentaMayor() As Permiso
                    Get
                        Return Me.xmoduloposonlie_pto_permitirventamayor
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_pto_permitirventamayor = value
                    End Set
                End Property


                Property op_PosOnline_AbrirModulo() As Permiso
                    Get
                        Return Me.xmoduloposonlie_abrirmodulo
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_abrirmodulo = value
                    End Set
                End Property

                Property op_PosOnline_IniciarJornada() As Permiso
                    Get
                        Return Me.xmoduloposonlie_iniciarjornada
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_iniciarjornada = value
                    End Set
                End Property

                Property op_PosOnline_AbrirPtoVenta() As Permiso
                    Get
                        Return Me.xmoduloposonlie_abrirptoventa
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_abrirptoventa = value
                    End Set
                End Property

                Property op_PosOnline_CerrarOperador() As Permiso
                    Get
                        Return Me.xmoduloposonlie_cerraroperador
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_cerraroperador = value
                    End Set
                End Property

                Property op_PosOnline_CerrarJornada() As Permiso
                    Get
                        Return Me.xmoduloposonlie_cerrarjornada
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_cerrarjornada = value
                    End Set
                End Property

                Property op_PosOnline_AdministradorJornada() As Permiso
                    Get
                        Return Me.xmoduloposonlie_administradorjornada
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_administradorjornada = value
                    End Set
                End Property

                Property op_PosOnline_CerrarJornadaConCtasPendientes() As Permiso
                    Get
                        Return Me.xmoduloposonlie_cerrarjornada_con_ctaspendientes
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_cerrarjornada_con_ctaspendientes = value
                    End Set
                End Property

                Property op_PosOnline_CerrarJornadaConTicketBalanzaPendiente() As Permiso
                    Get
                        Return Me.xmoduloposonlie_cerrarjornada_con_ticketbalanzapendiente
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_cerrarjornada_con_ticketbalanzapendiente = value
                    End Set
                End Property

                Property op_PosOnline_HabilitarAdministradorDocumentos() As Permiso
                    Get
                        Return Me.xmoduloposonlie_administradorDocumentos
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_administradorDocumentos = value
                    End Set
                End Property

                Property op_PosOnline_ElaborarNotasCredito() As Permiso
                    Get
                        Return Me.xmoduloposonlie_elaborarNCredito
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_elaborarNCredito = value
                    End Set
                End Property

                Property op_PosOnline_AnularNotasCredito() As Permiso
                    Get
                        Return Me.xmoduloposonlie_anularNCredito
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_anularNCredito = value
                    End Set
                End Property

                Property op_PosOnline_ServicioFiscal() As Permiso
                    Get
                        Return Me.xmoduloposonlie_serviciofiscal
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_serviciofiscal = value
                    End Set
                End Property

                Property op_PosOnline_ServicioFiscal_X() As Permiso
                    Get
                        Return Me.xmoduloposonlie_serviciofiscal_x
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_serviciofiscal_x = value
                    End Set
                End Property

                Property op_PosOnline_ServicioFiscal_Z() As Permiso
                    Get
                        Return Me.xmoduloposonlie_serviciofiscal_z
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_serviciofiscal_z = value
                    End Set
                End Property

                Property op_PosOnline_ServicioFiscal_Z_Acumualados() As Permiso
                    Get
                        Return Me.xmoduloposonlie_serviciofiscal_z_acumulado
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_serviciofiscal_z_acumulado = value
                    End Set
                End Property

                Property op_PosOnline_ServicioFiscal_DocAcumualdos() As Permiso
                    Get
                        Return Me.xmoduloposonlie_serviciofiscal_doc_acumulado
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_serviciofiscal_doc_acumulado = value
                    End Set
                End Property

                Property op_PosOnline_ConfiguracionDispositivo() As Permiso
                    Get
                        Return Me.xmoduloposonlie_configuracion
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_configuracion = value
                    End Set
                End Property

                Property op_PosOnline_ReporteCuadreCaja() As Permiso
                    Get
                        Return Me.xmoduloposonlie_reportecuadre
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_reportecuadre = value
                    End Set
                End Property

                Property op_PosOnline_HabilitarReporteCuadreCaja_Pantalla() As Permiso
                    Get
                        Return Me.xmoduloposonlie_reportecuadre_pantalla
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmoduloposonlie_reportecuadre_pantalla = value
                    End Set
                End Property


                '
                ' CONFIGURACION DISPOSITIVO
                '
                Property op_ModuloCnfDispositivo() As Permiso
                    Get
                        Return xmodulo_cnf_dispositivo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_cnf_dispositivo = value
                    End Set
                End Property



                '
                ' USUARIOS
                '
                Property op_ModuloUsuario() As Permiso
                    Get
                        Return xmodulo_usuario
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_usuario = value
                    End Set
                End Property

                Property op_ModuloUsuario_Ingresar() As Permiso
                    Get
                        Return xmodulo_usuario_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_usuario_nuevo = value
                    End Set
                End Property

                Property op_ModuloUsuario_Modificar() As Permiso
                    Get
                        Return xmodulo_usuario_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_usuario_modificar = value
                    End Set
                End Property

                Property op_ModuloUsuario_Eliminar() As Permiso
                    Get
                        Return xmodulo_usuario_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_usuario_eliminar = value
                    End Set
                End Property

                Property op_ModuloGrupoUsuario() As Permiso
                    Get
                        Return xmodulogrupo_usuario
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupo_usuario = value
                    End Set
                End Property

                Property op_ModuloGrupoUsuario_Ingresar() As Permiso
                    Get
                        Return xmodulogrupo_usuario_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupo_usuario_nuevo = value
                    End Set
                End Property

                Property op_ModuloGrupoUsuario_Modificar() As Permiso
                    Get
                        Return xmodulogrupo_usuario_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupo_usuario_modificar = value
                    End Set
                End Property

                Property op_ModuloGrupoUsuario_Eliminar() As Permiso
                    Get
                        Return xmodulogrupo_usuario_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupo_usuario_eliminar = value
                    End Set
                End Property

                Property op_ModuloGrupoUsuario_Permisos() As Permiso
                    Get
                        Return xmodulogrupo_usuario_permisos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupo_usuario_permisos = value
                    End Set
                End Property


                '
                ' CLIENTES
                '
                Property op_ModuloCliente() As Permiso
                    Get
                        Return xmodulocliente
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocliente = value
                    End Set
                End Property

                Property op_ModuloCliente_Ingresar() As Permiso
                    Get
                        Return xmodulocliente_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocliente_nuevo = value
                    End Set
                End Property

                Property op_ModuloCliente_Modificar() As Permiso
                    Get
                        Return xmodulocliente_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocliente_modificar = value
                    End Set
                End Property

                Property op_ModuloCliente_Eliminar() As Permiso
                    Get
                        Return xmodulocliente_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocliente_eliminar = value
                    End Set
                End Property

                Property op_ModuloGrupoCliente() As Permiso
                    Get
                        Return xmodulogrupocliente
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupocliente = value
                    End Set
                End Property

                Property op_ModuloGrupoCliente_Ingresar() As Permiso
                    Get
                        Return xmodulogrupocliente_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupocliente_nuevo = value
                    End Set
                End Property

                Property op_ModuloGrupoCliente_Modificar() As Permiso
                    Get
                        Return xmodulogrupocliente_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupocliente_modificar = value
                    End Set
                End Property

                Property op_ModuloGrupoCliente_Eliminar() As Permiso
                    Get
                        Return xmodulogrupocliente_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupocliente_eliminar = value
                    End Set
                End Property

                Property op_ModuloZonaCliente() As Permiso
                    Get
                        Return xmoduloZonacliente
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloZonacliente = value
                    End Set
                End Property

                Property op_ModuloZonaCliente_Ingresar() As Permiso
                    Get
                        Return xmoduloZonacliente_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloZonacliente_nuevo = value
                    End Set
                End Property

                Property op_ModuloZonaCliente_Modificar() As Permiso
                    Get
                        Return xmoduloZonacliente_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloZonacliente_modificar = value
                    End Set
                End Property

                Property op_ModuloZonaCliente_Eliminar() As Permiso
                    Get
                        Return xmoduloZonacliente_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloZonacliente_eliminar = value
                    End Set
                End Property

                Property op_ReporteCliente_DatosContacto() As Permiso
                    Get
                        Return Me.xcliente_reportes_datoscontacto
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xcliente_reportes_datoscontacto = value
                    End Set
                End Property

                Property op_ReporteCliente_DatosComerciales() As Permiso
                    Get
                        Return Me.xcliente_reportes_datoscomerciales
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xcliente_reportes_datoscomerciales = value
                    End Set
                End Property

                Property op_ReporteCliente_EstadoCuenta() As Permiso
                    Get
                        Return Me.xcliente_reportes_estadocuenta
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xcliente_reportes_estadocuenta = value
                    End Set
                End Property

                Property op_ReporteCliente_RetencionesIva() As Permiso
                    Get
                        Return Me.xcliente_reportes_retencionesiva
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xcliente_reportes_retencionesiva = value
                    End Set
                End Property


                '
                ' PROVEEDORES
                '
                Property op_ModuloProveedor() As Permiso
                    Get
                        Return xmoduloproveedor
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloproveedor = value
                    End Set
                End Property

                Property op_ModuloProveedor_Ingresar() As Permiso
                    Get
                        Return xmoduloproveedor_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloproveedor_nuevo = value
                    End Set
                End Property

                Property op_ModuloProveedor_Modificar() As Permiso
                    Get
                        Return xmoduloproveedor_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloproveedor_modificar = value
                    End Set
                End Property

                Property op_ModuloProveedor_Eliminar() As Permiso
                    Get
                        Return xmoduloproveedor_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloproveedor_eliminar = value
                    End Set
                End Property

                Property op_ModuloGrupoProveedor() As Permiso
                    Get
                        Return xmodulogrupoproveedor
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupoproveedor = value
                    End Set
                End Property

                Property op_ModuloGrupoProveedor_Ingresar() As Permiso
                    Get
                        Return xmodulogrupoproveedor_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupoproveedor_nuevo = value
                    End Set
                End Property

                Property op_ModuloGrupoProveedor_Modificar() As Permiso
                    Get
                        Return xmodulogrupoproveedor_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupoproveedor_modificar = value
                    End Set
                End Property

                Property op_ModuloGrupoProveedor_Eliminar() As Permiso
                    Get
                        Return xmodulogrupoproveedor_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulogrupoproveedor_eliminar = value
                    End Set
                End Property

                Property op_ModuloCtaBancariaProveedor() As Permiso
                    Get
                        Return xmoduloctabancariaproveedor
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloctabancariaproveedor = value
                    End Set
                End Property

                Property op_ModuloCtaBancariaProveedor_Ingresar() As Permiso
                    Get
                        Return xmoduloctabancariaproveedor_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloctabancariaproveedor_nuevo = value
                    End Set
                End Property

                Property op_ModuloCtaBancariaProveedor_Modificar() As Permiso
                    Get
                        Return xmoduloctabancariaproveedor_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloctabancariaproveedor_modificar = value
                    End Set
                End Property

                Property op_ModuloCtaBancariaProveedor_Eliminar() As Permiso
                    Get
                        Return xmoduloctabancariaproveedor_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloctabancariaproveedor_eliminar = value
                    End Set
                End Property

                Property op_ReporteProveedor_DatosContacto() As Permiso
                    Get
                        Return Me.xproveedor_reportes_datoscontacto
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xproveedor_reportes_datoscontacto = value
                    End Set
                End Property

                Property op_ReporteProveedor_DatosComerciales() As Permiso
                    Get
                        Return Me.xproveedor_reportes_datoscomerciales
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xproveedor_reportes_datoscomerciales = value
                    End Set
                End Property

                Property op_ReporteProveedor_EstadoCuenta() As Permiso
                    Get
                        Return Me.xproveedor_reportes_estadocuenta
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xproveedor_reportes_estadocuenta = value
                    End Set
                End Property

                Property op_ReporteProveedor_RetencionesIva() As Permiso
                    Get
                        Return Me.xproveedor_reportes_retencionesiva
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xproveedor_reportes_retencionesiva = value
                    End Set
                End Property


                '
                ' AGENCIA BANCARIA
                '
                Property op_ModuloAgenciaBancaria() As Permiso
                    Get
                        Return xmoduloagenciabancaria
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloagenciabancaria = value
                    End Set
                End Property

                Property op_ModuloAgenciaBancaria_Ingresar() As Permiso
                    Get
                        Return xmoduloagenciabancaria_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloagenciabancaria_nuevo = value
                    End Set
                End Property

                Property op_ModuloAgenciaBancaria_Modificar() As Permiso
                    Get
                        Return xmoduloagenciabancaria_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloagenciabancaria_modificar = value
                    End Set
                End Property

                Property op_ModuloAgenciaBancaria_Eliminar() As Permiso
                    Get
                        Return xmoduloagenciabancaria_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloagenciabancaria_eliminar = value
                    End Set
                End Property


                '
                ' VENDEDORES
                '
                Property op_ModuloVendedor() As Permiso
                    Get
                        Return xmodulovendedor
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulovendedor = value
                    End Set
                End Property

                Property op_ModuloVendedor_Ingresar() As Permiso
                    Get
                        Return xmodulovendedor_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulovendedor_nuevo = value
                    End Set
                End Property

                Property op_ModuloVendedor_Modificar() As Permiso
                    Get
                        Return xmodulovendedor_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulovendedor_modificar = value
                    End Set
                End Property

                Property op_ModuloVendedor_Eliminar() As Permiso
                    Get
                        Return xmodulovendedor_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulovendedor_eliminar = value
                    End Set
                End Property

                Property op_ModuloVendedor_TablaComisiones() As Permiso
                    Get
                        Return xmodulovendedor_tablacomisiones
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulovendedor_tablacomisiones = value
                    End Set
                End Property

                Property op_ReporteVendedor_Maestro() As Permiso
                    Get
                        Return xreportevendedor_maestro
                    End Get
                    Set(ByVal value As Permiso)
                        xreportevendedor_maestro = value
                    End Set
                End Property

                Property op_ReporteVendedor_Comisiones() As Permiso
                    Get
                        Return xreportevendedor_comisiones
                    End Get
                    Set(ByVal value As Permiso)
                        xreportevendedor_comisiones = value
                    End Set
                End Property

                Property op_ReporteVendedor_ComisionesVentasDetalle() As Permiso
                    Get
                        Return xreportevendedor_comisionesventasdetalle
                    End Get
                    Set(ByVal value As Permiso)
                        xreportevendedor_comisionesventasdetalle = value
                    End Set
                End Property

                '
                ' COBRADORES
                '
                Property op_ModuloCobrador() As Permiso
                    Get
                        Return xmodulocobrador
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocobrador = value
                    End Set
                End Property

                Property op_ModuloCobrador_Ingresar() As Permiso
                    Get
                        Return xmodulocobrador_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocobrador_nuevo = value
                    End Set
                End Property

                Property op_ModuloCobrador_Modificar() As Permiso
                    Get
                        Return xmodulocobrador_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocobrador_modificar = value
                    End Set
                End Property

                Property op_ModuloCobrador_Eliminar() As Permiso
                    Get
                        Return xmodulocobrador_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocobrador_eliminar = value
                    End Set
                End Property

                Property op_ModuloCobrador_TablaComisiones() As Permiso
                    Get
                        Return xmodulocobrador_tablacomisiones
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocobrador_tablacomisiones = value
                    End Set
                End Property

                Property op_ReporteCobrador_Maestro() As Permiso
                    Get
                        Return xreportecobrador_maestro
                    End Get
                    Set(ByVal value As Permiso)
                        xreportecobrador_maestro = value
                    End Set
                End Property

                Property op_ReporteCobrador_Comisiones() As Permiso
                    Get
                        Return xreportecobrador_comisiones
                    End Get
                    Set(ByVal value As Permiso)
                        xreportecobrador_comisiones = value
                    End Set
                End Property


                ' 
                ' VENTAS 
                '
                Property op_ControlVentasAdministrativa() As Permiso
                    Get
                        Return xventa_controlventas
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlventas = value
                    End Set
                End Property

                Property op_ControlVentasAdministrativa_Chimbas() As Permiso
                    Get
                        Return xventa_controlventas_chimbas
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlventas_chimbas = value
                    End Set
                End Property

                Property op_ControlPresupuestos() As Permiso
                    Get
                        Return xventa_controlpresupuesto
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlpresupuesto = value
                    End Set
                End Property

                Property op_ControlNotasEntrega() As Permiso
                    Get
                        Return xventa_controlnotasentrega
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlnotasentrega = value
                    End Set
                End Property

                Property op_ControlNotasCredito_Ventas() As Permiso
                    Get
                        Return xventa_controlnotacredito
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlnotacredito = value
                    End Set
                End Property

                Property op_ControlNotasDebito_Ventas() As Permiso
                    Get
                        Return xventa_controlnotasdebito
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlnotasdebito = value
                    End Set
                End Property

                Property op_ControlPedidos() As Permiso
                    Get
                        Return xventa_controlpedidos
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_controlpedidos = value
                    End Set
                End Property

                Property op_AdmDocumentos_Ventas() As Permiso
                    Get
                        Return xventa_adm_documentos
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_documentos = value
                    End Set
                End Property

                Property op_AnularDocumentos_Ventas() As Permiso
                    Get
                        Return xventa_anulardocumento
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_anulardocumento = value
                    End Set
                End Property

                Property op_RevertirDocumentos_Ventas() As Permiso
                    Get
                        Return xventa_revertirdocumento
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_revertirdocumento = value
                    End Set
                End Property

                Property op_ControlRetencionesIva_Ventas() As Permiso
                    Get
                        Return xventa_retenciones_iva
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_retenciones_iva = value
                    End Set
                End Property

                Property op_AdmDocumentosRetenciones_Ventas() As Permiso
                    Get
                        Return xventa_adm_documentos_retenciones
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_documentos_retenciones = value
                    End Set
                End Property

                Property op_AnularDocumentosRetenciones_Ventas() As Permiso
                    Get
                        Return xventa_anulardocumento_retenciones
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_anulardocumento_retenciones = value
                    End Set
                End Property

                Property op_ReporteVentas_LibroSeniat() As Permiso
                    Get
                        Return xventa_reportes_libroventa
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_libroventa = value
                    End Set
                End Property

                Property op_ReporteVentas_DocumentosGeneral() As Permiso
                    Get
                        Return xventa_reportes_generaldocumento
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_generaldocumento = value
                    End Set
                End Property

                Property op_ReporteVentas_Consolidado() As Permiso
                    Get
                        Return xventa_reportes_consolidado
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_consolidado = value
                    End Set
                End Property

                Property op_ReporteVentas_PorDepartamento() As Permiso
                    Get
                        Return xventa_reportes_pordepartamento
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_pordepartamento = value
                    End Set
                End Property

                Property op_ReporteVentas_PorGrupo() As Permiso
                    Get
                        Return xventa_reportes_porgrupo
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_porgrupo = value
                    End Set
                End Property

                Property op_ReporteVentas_Utilidad() As Permiso
                    Get
                        Return xventa_reportes_utilidad
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_reportes_utilidad = value
                    End Set
                End Property

                Property op_ReporteVentas_ResumenCuadre() As Permiso
                    Get
                        Return Me.xventa_reportes_resumen_cuadre
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xventa_reportes_resumen_cuadre = value
                    End Set
                End Property

                Property op_ReporteVentas_Estadistico() As Permiso
                    Get
                        Return Me.xventa_reportes_estadistico
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xventa_reportes_estadistico = value
                    End Set
                End Property


                Property op_VentasAdm_VerCosto() As Permiso
                    Get
                        Return xventa_adm_vercosto
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_vercosto = value
                    End Set
                End Property

                Property op_VentasAdm_DarDescuento_Item() As Permiso
                    Get
                        Return xventa_adm_dar_descuento_item
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_dar_descuento_item = value
                    End Set
                End Property

                Property op_VentasAdm_PrecioLibre() As Permiso
                    Get
                        Return xventa_adm_precio_libre
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_precio_libre = value
                    End Set
                End Property

                Property op_VentasAdm_RecuperarDocumentos() As Permiso
                    Get
                        Return xventa_adm_recuperar_documentos
                    End Get
                    Set(ByVal value As Permiso)
                        xventa_adm_recuperar_documentos = value
                    End Set
                End Property


                ' 
                ' VISOR FISCAL
                '
                Property op_VisorFiscal() As Permiso
                    Get
                        Return xvisorfiscal
                    End Get
                    Set(ByVal value As Permiso)
                        xvisorfiscal = value
                    End Set
                End Property

                Property op_VisorFiscal_X() As Permiso
                    Get
                        Return xvisorfiscal_x
                    End Get
                    Set(ByVal value As Permiso)
                        xvisorfiscal_x = value
                    End Set
                End Property

                Property op_VisorFiscal_Z() As Permiso
                    Get
                        Return xvisorfiscal_z
                    End Get
                    Set(ByVal value As Permiso)
                        xvisorfiscal_z = value
                    End Set
                End Property

                Property op_VisorFiscal_Reportes_Z() As Permiso
                    Get
                        Return xvisorfiscal_reportes_z
                    End Get
                    Set(ByVal value As Permiso)
                        xvisorfiscal_reportes_z = value
                    End Set
                End Property

                Property op_VisorFiscal_Reportes_Doc() As Permiso
                    Get
                        Return xvisorfiscal_reportes_doc
                    End Get
                    Set(ByVal value As Permiso)
                        xvisorfiscal_reportes_doc = value
                    End Set
                End Property


                '
                ' INVENTARIO
                '
                Property op_ModuloInventario() As Permiso
                    Get
                        Return xmoduloinventario
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario = value
                    End Set
                End Property

                Property op_ModuloInventario_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_eliminar = value
                    End Set
                End Property

                Property op_ModuloInventario_ModificarCosto() As Permiso
                    Get
                        Return xmoduloinventario_modificar_costo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_modificar_costo = value
                    End Set
                End Property

                Property op_ModuloInventario_ModificarPrecios() As Permiso
                    Get
                        Return xmoduloinventario_modificar_precios
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_modificar_precios = value
                    End Set
                End Property

                Property op_ModuloInventario_ModificarExistencia() As Permiso
                    Get
                        Return xmoduloinventario_modificar_existencia
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_modificar_existencia = value
                    End Set
                End Property

                Property op_ModuloInventario_Kardex() As Permiso
                    Get
                        Return xmoduloinventario_kardex
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_kardex = value
                    End Set
                End Property

                Property op_ModuloInventario_Depart() As Permiso
                    Get
                        Return xmoduloinventario_departamento
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_departamento = value
                    End Set
                End Property

                Property op_ModuloInventario_Depart_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_departamento_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_departamento_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Depart_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_departamento_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_departamento_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Depart_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_departamento_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_departamento_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_Marca() As Permiso
                    Get
                        Return xmoduloinventario_marca
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_marca = value
                    End Set
                End Property

                Property op_ModuloInventario_Marca_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_marca_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_marca_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Marca_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_marca_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_marca_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Marca_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_marca_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_marca_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_Deposito() As Permiso
                    Get
                        Return xmoduloinventario_deposito
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_deposito = value
                    End Set
                End Property

                Property op_ModuloInventario_Deposito_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_deposito_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_deposito_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Deposito_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_deposito_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_deposito_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Deposito_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_deposito_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_deposito_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_Concepto() As Permiso
                    Get
                        Return xmoduloinventario_concepto
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_concepto = value
                    End Set
                End Property

                Property op_ModuloInventario_Concepto_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_concepto_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_concepto_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Concepto_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_concepto_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_concepto_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Concepto_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_concepto_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_concepto_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_Medida() As Permiso
                    Get
                        Return xmoduloinventario_medida
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_medida = value
                    End Set
                End Property

                Property op_ModuloInventario_Medida_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_medida_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_medida_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_Medida_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_medida_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_medida_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_Medida_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_medida_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_medida_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_DeptoPtoVenta() As Permiso
                    Get
                        Return xmoduloinventario_DeptoPtoVenta
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_DeptoPtoVenta = value
                    End Set
                End Property

                Property op_ModuloInventario_DeptoPtoVenta_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_DeptoPtoVenta_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_DeptoPtoVenta_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_DeptoPtoVenta_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_DeptoPtoVenta_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_DeptoPtoVenta_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_DeptoPtoVenta_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_DeptoPtoVenta_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_DeptoPtoVenta_eliminar = value
                    End Set
                End Property


                Property op_ModuloInventario_GrupoSubGrupo() As Permiso
                    Get
                        Return xmoduloinventario_GrupoSubGrupo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_GrupoSubGrupo = value
                    End Set
                End Property

                Property op_ModuloInventario_GrupoSubGrupo_Ingresar() As Permiso
                    Get
                        Return xmoduloinventario_GrupoSubGrupo_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_GrupoSubGrupo_nuevo = value
                    End Set
                End Property

                Property op_ModuloInventario_GrupoSubGrupo_Modificar() As Permiso
                    Get
                        Return xmoduloinventario_GrupoSubGrupo_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_GrupoSubGrupo_modificar = value
                    End Set
                End Property

                Property op_ModuloInventario_GrupoSubGrupo_Eliminar() As Permiso
                    Get
                        Return xmoduloinventario_GrupoSubGrupo_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloinventario_GrupoSubGrupo_eliminar = value
                    End Set
                End Property

                Property op_ReporteInventario_MaestroDatos() As Permiso
                    Get
                        Return xinventario_reportes_maestrodatos
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_maestrodatos = value
                    End Set
                End Property

                Property op_ReporteInventario_PrecioInventario() As Permiso
                    Get
                        Return xinventario_reportes_precio_inv
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_precio_inv = value
                    End Set
                End Property

                Property op_ReporteInventario_Existencia() As Permiso
                    Get
                        Return xinventario_reportes_existencia
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_existencia = value
                    End Set
                End Property

                Property op_ReporteInventario_ListaPrecio() As Permiso
                    Get
                        Return xinventario_reportes_lista_precio
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_lista_precio = value
                    End Set
                End Property

                Property op_ReporteInventario_MovimientoPorConcepto() As Permiso
                    Get
                        Return xinventario_reportes_mov_concepto
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_mov_concepto = value
                    End Set
                End Property

                Property op_ReporteInventario_Valorizacion() As Permiso
                    Get
                        Return xinventario_reportes_valorizacion
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_valorizacion = value
                    End Set
                End Property

                Property op_ReporteInventario_ProyeccionVenta() As Permiso
                    Get
                        Return xinventario_reportes_proyeccion
                    End Get
                    Set(ByVal value As Permiso)
                        xinventario_reportes_proyeccion = value
                    End Set
                End Property



                '
                ' CUENTA POR COBRAR
                '
                Property op_ModuloCxCobrar_ControlCuentas() As Permiso
                    Get
                        Return xmodulocxc_ControlCuentas
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_ControlCuentas = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_AdministradorDocumentos() As Permiso
                    Get
                        Return xmodulocxc_AdministradorDocumentos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_AdministradorDocumentos = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_AnularDocumento() As Permiso
                    Get
                        Return xmodulocxc_AnularDocumento
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_AnularDocumento = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_Reportes_DocumentosCobrar() As Permiso
                    Get
                        Return xmodulocxc_reportes_DocumentosxCobrar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_reportes_DocumentosxCobrar = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_Reportes_CobranzaDiaria() As Permiso
                    Get
                        Return xmodulocxc_reportes_CobranzaDiaria
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_reportes_CobranzaDiaria = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_Reportes_PagosEmitidos() As Permiso
                    Get
                        Return xmodulocxc_reportes_PagosEmitidos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_reportes_PagosEmitidos = value
                    End Set
                End Property

                Property op_ModuloCxCobrar_Reportes_AnalisiVencimiento() As Permiso
                    Get
                        Return xmodulocxc_reportes_AnalisisVencimiento
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxc_reportes_AnalisisVencimiento = value
                    End Set
                End Property


                '
                ' 
                '
                Property op_DatosNegocio() As Permiso
                    Get
                        Return Me.xmodulo_datosnegocio
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_datosnegocio = value
                    End Set
                End Property

                Property op_TasasFiscales() As Permiso
                    Get
                        Return Me.xmodulo_tasasfiscales
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_tasasfiscales = value
                    End Set
                End Property

                Property op_SeriesFiscales() As Permiso
                    Get
                        Return Me.xmodulo_seriesfiscales
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_seriesfiscales = value
                    End Set
                End Property

                Property op_SeriesFiscales_Ingresar() As Permiso
                    Get
                        Return Me.xmodulo_seriesfiscales_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_seriesfiscales_nuevo = value
                    End Set
                End Property

                Property op_SeriesFiscales_Modificar() As Permiso
                    Get
                        Return Me.xmodulo_seriesfiscales_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_seriesfiscales_modificar = value
                    End Set
                End Property

                Property op_SeriesFiscales_Eliminar() As Permiso
                    Get
                        Return Me.xmodulo_seriesfiscales_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_seriesfiscales_eliminar = value
                    End Set
                End Property

                Property op_Configuracion() As Permiso
                    Get
                        Return Me.xmodulo_configuracion
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulo_configuracion = value
                    End Set
                End Property

                Property op_ModuloMedioPago() As Permiso
                    Get
                        Return xmodulo_mediopago
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_mediopago = value
                    End Set
                End Property

                Property op_ModuloMedioPago_Ingresar() As Permiso
                    Get
                        Return xmodulo_mediopago_nuevo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_mediopago_nuevo = value
                    End Set
                End Property

                Property op_ModuloMedioPago_Modificar() As Permiso
                    Get
                        Return xmodulo_mediopago_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_mediopago_modificar = value
                    End Set
                End Property

                Property op_ModuloMedioPago_Eliminar() As Permiso
                    Get
                        Return xmodulo_mediopago_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulo_mediopago_eliminar = value
                    End Set
                End Property


                '
                ' SERVICIO BD
                '
                Property op_ServicioBD_Compactar() As Permiso
                    Get
                        Return xserviciobd_compactar
                    End Get
                    Set(ByVal value As Permiso)
                        xserviciobd_compactar = value
                    End Set
                End Property

                Property op_ServicioBD_Respaldar() As Permiso
                    Get
                        Return xserviciobd_respaldar
                    End Get
                    Set(ByVal value As Permiso)
                        xserviciobd_respaldar = value
                    End Set
                End Property

                Property op_ServicioBD_WebSite() As Permiso
                    Get
                        Return xserviciobd_website
                    End Get
                    Set(ByVal value As Permiso)
                        xserviciobd_website = value
                    End Set
                End Property

                Property op_ServicioBD_Monitoreo() As Permiso
                    Get
                        Return xserviciobd_monitoreo
                    End Get
                    Set(ByVal value As Permiso)
                        xserviciobd_monitoreo = value
                    End Set
                End Property

                Property op_ServicioBD_Mantenimiento() As Permiso
                    Get
                        Return xserviciobd_mantenimiento
                    End Get
                    Set(ByVal value As Permiso)
                        xserviciobd_mantenimiento = value
                    End Set
                End Property


                '
                ' COMPRAS
                '
                Property op_ModuloCompra_ControlCompra() As Permiso
                    Get
                        Return Me.xmodulocompras_controlcompras
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_controlcompras = value
                    End Set
                End Property

                Property op_ModuloCompra_ControlCompraGastos() As Permiso
                    Get
                        Return Me.xmodulocompras_controlcomprasgastos
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_controlcomprasgastos = value
                    End Set
                End Property

                Property op_ModuloCompra_OrdenCompra() As Permiso
                    Get
                        Return Me.xmodulocompras_ordencompra
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_ordencompra = value
                    End Set
                End Property

                Property op_ModuloCompra_AdmDocumentos() As Permiso
                    Get
                        Return Me.xmodulocompras_admdocumentos
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_admdocumentos = value
                    End Set
                End Property

                Property op_ModuloCompra_AnularDocumento() As Permiso
                    Get
                        Return Me.xmodulocompras_anulardocumento
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_anulardocumento = value
                    End Set
                End Property

                Property op_ModuloCompra_ControlNotasCredito() As Permiso
                    Get
                        Return Me.xmodulocompras_notascredito
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_notascredito = value
                    End Set
                End Property

                Property op_ModuloCompra_Retenciones() As Permiso
                    Get
                        Return Me.xmodulocompras_retenciones
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_retenciones = value
                    End Set
                End Property

                Property op_ModuloCompra_AdmRetenciones() As Permiso
                    Get
                        Return Me.xmodulocompras_admretenciones
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_admretenciones = value
                    End Set
                End Property

                Property op_ModuloCompra_AnularRetencion() As Permiso
                    Get
                        Return Me.xmodulocompras_anularretenciones
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_anularretenciones = value
                    End Set
                End Property

                Property op_ModuloCompra_ActualizarPreciosVentas() As Permiso
                    Get
                        Return Me.xmodulocompras_actualizarpreciosventas
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_actualizarpreciosventas = value
                    End Set
                End Property

                Property op_ModuloCompras_Reportes_LibroCompra() As Permiso
                    Get
                        Return Me.xmodulocompras_reportes_librodecompra
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_reportes_librodecompra = value
                    End Set
                End Property

                Property op_ModuloCompras_Reportes_GeneralCompras() As Permiso
                    Get
                        Return Me.xmodulocompras_reportes_general
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_reportes_general = value
                    End Set
                End Property

                Property op_ModuloCompras_Reportes_PorDepartamentos() As Permiso
                    Get
                        Return Me.xmodulocompras_reportes_pordepartamento
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_reportes_pordepartamento = value
                    End Set
                End Property

                Property op_ModuloCompras_Reportes_PorGrupos() As Permiso
                    Get
                        Return Me.xmodulocompras_reportes_porgrupos
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_reportes_porgrupos = value
                    End Set
                End Property

                Property op_ModuloCompras_Reportes_Retenciones() As Permiso
                    Get
                        Return Me.xmodulocompras_reportes_retenciones
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_reportes_retenciones = value
                    End Set
                End Property

                Property op_ModuloCompras_GenerarTxT() As Permiso
                    Get
                        Return Me.xmodulocompras_generar_txt
                    End Get
                    Set(ByVal value As Permiso)
                        Me.xmodulocompras_generar_txt = value
                    End Set
                End Property


                '
                ' CUENTA POR PAGAR
                '
                Property op_ModuloCxPagar_ControlCuentas() As Permiso
                    Get
                        Return xmodulocxp_ControlCuentas
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_ControlCuentas = value
                    End Set
                End Property

                Property op_ModuloCxPagar_AdministradorDocumentos() As Permiso
                    Get
                        Return xmodulocxp_AdministradorDocumentos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_AdministradorDocumentos = value
                    End Set
                End Property

                Property op_ModuloCxPagar_AnularDocumento() As Permiso
                    Get
                        Return xmodulocxp_AnularDocumento
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_AnularDocumento = value
                    End Set
                End Property

                Property op_ModuloCxPagar_Reportes_DocumentosxPagar() As Permiso
                    Get
                        Return xmodulocxp_reportes_DocumentosxPagar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_reportes_DocumentosxPagar = value
                    End Set
                End Property

                Property op_ModuloCxPagar_Reportes_PagosEmitidos() As Permiso
                    Get
                        Return xmodulocxp_reportes_PagosEmitidos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_reportes_PagosEmitidos = value
                    End Set
                End Property

                Property op_ModuloCxPagar_Reportes_AnalisiVencimiento() As Permiso
                    Get
                        Return xmodulocxp_reportes_AnalisisVencimiento
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulocxp_reportes_AnalisisVencimiento = value
                    End Set
                End Property



                '
                ' MODULO FASTFOOD
                '
                Property op_ModuloFastFood_ActivarModulo() As Permiso
                    Get
                        Return xmodulofastfood_activarmodulo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_activarmodulo = value
                    End Set
                End Property

                Property op_ModuloFastFood_MenuPlatos() As Permiso
                    Get
                        Return xmodulofastfood_menuplatos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menuplatos = value
                    End Set
                End Property

                Property op_ModuloFastFood_AdministradorDocumentos() As Permiso
                    Get
                        Return xmodulofastfood_admdocumentos
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_admdocumentos = value
                    End Set
                End Property

                Property op_ModuloFastFood_ReporteCuadreCaja() As Permiso
                    Get
                        Return xmodulofastfood_reportecuadrecaja
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_reportecuadrecaja = value
                    End Set
                End Property

                Property op_ModuloFastFood_ServicioFiscal() As Permiso
                    Get
                        Return xmodulofastfood_serviciofiscal
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_serviciofiscal = value
                    End Set
                End Property

                Property op_ModuloFastFood_ConfiguracionGeneral() As Permiso
                    Get
                        Return xmodulofastfood_configuraciongeneral
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_configuraciongeneral = value
                    End Set
                End Property

                Property op_ModuloFastFood_IniciarJornada() As Permiso
                    Get
                        Return xmodulofastfood_iniciarjornada
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_iniciarjornada = value
                    End Set
                End Property

                Property op_ModuloFastFood_AbrirPtoVenta() As Permiso
                    Get
                        Return xmodulofastfood_abrirptoventa
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_abrirptoventa = value
                    End Set
                End Property

                Property op_ModuloFastFood_CerrarOperador() As Permiso
                    Get
                        Return xmodulofastfood_cerraroperador
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_cerraroperador = value
                    End Set
                End Property

                Property op_ModuloFastFood_CerrarJornada() As Permiso
                    Get
                        Return xmodulofastfood_cerrarjornada
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_cerrarjornada = value
                    End Set
                End Property

                Property op_ModuloFastFood_AdministradorJornadas() As Permiso
                    Get
                        Return xmodulofastfood_admjornadas
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_admjornadas = value
                    End Set
                End Property

                Property op_ModuloFastFood_ReimprimirCuadreCaja() As Permiso
                    Get
                        Return xmodulofastfood_reimprimircuadrecaja
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_reimprimircuadrecaja = value
                    End Set
                End Property

                Property op_ModuloFastFood_NotaCRedito() As Permiso
                    Get
                        Return xmodulofastfood_elaborarnotacredito
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_elaborarnotacredito = value
                    End Set
                End Property

                Property op_ModuloFastFood_AnularNotaCredito() As Permiso
                    Get
                        Return xmodulofastfood_anularnotacredito
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_anularnotacredito = value
                    End Set
                End Property

                Property op_ModuloFastFood_Reporte_X() As Permiso
                    Get
                        Return xmodulofastfood_reporteX
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_reporteX = value
                    End Set
                End Property

                Property op_ModuloFastFood_Reporte_Z() As Permiso
                    Get
                        Return xmodulofastfood_reporteZ
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_reporteZ = value
                    End Set
                End Property

                Property op_ModuloFastFood_ReporteZ_Acumulados() As Permiso
                    Get
                        Return xmodulofastfood_reporteZ_Acumulado
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_reporteZ_Acumulado = value
                    End Set
                End Property

                Property op_ModuloFastFood_ReporteAcumuladoDocumentosFiscal() As Permiso
                    Get
                        Return xmodulofastfood_DocumentosAcumuladosFiscal
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_DocumentosAcumuladosFiscal = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_AbrirGaveta() As Permiso
                    Get
                        Return xmodulofastfood_pto_abrirgaveta
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_abrirgaveta = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_FondoCaja() As Permiso
                    Get
                        Return xmodulofastfood_pto_fondo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_fondo = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_RetiroCaja() As Permiso
                    Get
                        Return xmodulofastfood_pto_retiro
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_retiro = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_ActivarInventario() As Permiso
                    Get
                        Return xmodulofastfood_pto_activarinventario
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_activarinventario = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_CtasPendientes() As Permiso
                    Get
                        Return xmodulofastfood_pto_pendientes
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_pendientes = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_EliminarCtasPendientes() As Permiso
                    Get
                        Return xmodulofastfood_pto_eliminar_pendientes
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_eliminar_pendientes = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_EliminarTodasCtasPendientes() As Permiso
                    Get
                        Return xmodulofastfood_pto_eliminar_todas_pendientes
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_eliminar_todas_pendientes = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_AnularPedido() As Permiso
                    Get
                        Return xmodulofastfood_pto_anular_pedido
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_anular_pedido = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_DevolucionItem() As Permiso
                    Get
                        Return xmodulofastfood_pto_devolucion
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_devolucion = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_EliminarItem() As Permiso
                    Get
                        Return xmodulofastfood_pto_eliminar_item
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_eliminar_item = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_AjustarItem() As Permiso
                    Get
                        Return xmodulofastfood_pto_ajustar_item
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_ajustar_item = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_DarDescuentoFacturar() As Permiso
                    Get
                        Return xmodulofastfood_pto_dardescuento_facturar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_dardescuento_facturar = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_DejarCtaCreditoFacturar() As Permiso
                    Get
                        Return xmodulofastfood_pto_ctacredito_facturar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_ctacredito_facturar = value
                    End Set
                End Property

                Property op_ModuloFastFood_PTO_ReEnviarComanads() As Permiso
                    Get
                        Return xmodulofastfood_pto_reenviarcomandas
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_pto_reenviarcomandas = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_GrupoPlatos() As Permiso
                    Get
                        Return xmodulofastfood_menu_modulogrupo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_modulogrupo = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Agregar() As Permiso
                    Get
                        Return xmodulofastfood_menu_modulogrupo_agregar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_modulogrupo_agregar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Modificar() As Permiso
                    Get
                        Return xmodulofastfood_menu_modulogrupo_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_modulogrupo_modificar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Eliminar() As Permiso
                    Get
                        Return xmodulofastfood_menu_modulogrupo_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_modulogrupo_eliminar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_EstacionComandas() As Permiso
                    Get
                        Return xmodulofastfood_menu_moduloestacion
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_moduloestacion = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_EstacionComandas_Agergar() As Permiso
                    Get
                        Return xmodulofastfood_menu_moduloestacion_agregar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_moduloestacion_agregar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_EstacionComandas_Modificar() As Permiso
                    Get
                        Return xmodulofastfood_menu_moduloestacion_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_moduloestacion_modificar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modulo_EstacionComandas_Eliminar() As Permiso
                    Get
                        Return xmodulofastfood_menu_moduloestacion_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_moduloestacion_eliminar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Agregar() As Permiso
                    Get
                        Return xmodulofastfood_menu_agregar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_agregar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Modificar() As Permiso
                    Get
                        Return xmodulofastfood_menu_modificar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_modificar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_Eliminar() As Permiso
                    Get
                        Return xmodulofastfood_menu_eliminar
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_eliminar = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionBalanza() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_balanza
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_balanza = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionCombo() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_combo
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_combo = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionEstaciones() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_estaciones
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_estaciones = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionPrecioVenta() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_precioventa
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_precioventa = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionOferta() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_oferta
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_oferta = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionInventario() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_inventario
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_inventario = value
                    End Set
                End Property

                Property op_ModuloFastFood_Menu_OpcionImagen() As Permiso
                    Get
                        Return xmodulofastfood_menu_opcion_imagen
                    End Get
                    Set(ByVal value As Permiso)
                        xmodulofastfood_menu_opcion_imagen = value
                    End Set
                End Property


                '
                ' MODULO RESTAURANT
                '
                Property op_ModuloRestaurant_ActivarModulo() As Permiso
                    Get
                        Return xmoduloresturant_activarmodulo
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_activarmodulo = value
                    End Set
                End Property

                Property op_ModuloRestaurant_UnirMesas() As Permiso
                    Get
                        Return xmoduloresturant_unirmesas
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_unirmesas = value
                    End Set
                End Property

                Property op_ModuloRestaurant_CambioMesa() As Permiso
                    Get
                        Return xmoduloresturant_cambiomesa
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_cambiomesa = value
                    End Set
                End Property

                Property op_ModuloRestaurant_AnularMesa() As Permiso
                    Get
                        Return xmoduloresturant_anularmesa
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_anularmesa = value
                    End Set
                End Property

                Property op_ModuloRestaurant_AnularPedido() As Permiso
                    Get
                        Return xmoduloresturant_anularpedido
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_anularpedido = value
                    End Set
                End Property

                Property op_ModuloRestaurant_TrasaladarPedidoMesa() As Permiso
                    Get
                        Return xmoduloresturant_trasladar_pedido_a_mesa
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_trasladar_pedido_a_mesa = value
                    End Set
                End Property

                Property op_ModuloRestaurant_DevolucionPlatos() As Permiso
                    Get
                        Return xmoduloresturant_devoluciones
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_devoluciones = value
                    End Set
                End Property

                Property op_ModuloRestaurant_EliminarItem() As Permiso
                    Get
                        Return xmoduloresturant_eliminar_item
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_eliminar_item = value
                    End Set
                End Property

                Property op_ModuloRestaurant_DarDescuentoFacturar() As Permiso
                    Get
                        Return xmoduloresturant_dar_descuento_facturar
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_dar_descuento_facturar = value
                    End Set
                End Property

                Property op_ModuloRestaurant_FacturarCredito() As Permiso
                    Get
                        Return xmoduloresturant_facturar_credito
                    End Get
                    Set(ByVal value As Permiso)
                        xmoduloresturant_facturar_credito = value
                    End Set
                End Property


                Protected Friend Property p_TablaDato() As DataTable
                    Get
                        Return xtabla
                    End Get
                    Set(ByVal value As DataTable)
                        xtabla = value
                    End Set
                End Property

                Protected Friend Sub M_CargarFicha()
                    Try
                        Dim xopcion As New c_GrupoOpciones
                        For Each xrow As DataRow In Me.p_TablaDato.Rows
                            xopcion.M_CargarFicha(xrow)

                            Select Case xopcion.RegistroDato.r_CodigoOpcion

                                '
                                ' CLIENTES
                                '
                                Case "0101000000"
                                    With op_ModuloCliente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0101010000"
                                    With op_ModuloCliente_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0101020000"
                                    With op_ModuloCliente_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0101030000"
                                    With op_ModuloCliente_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0102000000"
                                    With op_ModuloGrupoCliente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0102010000"
                                    With op_ModuloGrupoCliente_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0102020000"
                                    With op_ModuloGrupoCliente_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0102030000"
                                    With op_ModuloGrupoCliente_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0103000000"
                                    With op_ModuloZonaCliente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0103010000"
                                    With op_ModuloZonaCliente_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0103020000"
                                    With op_ModuloZonaCliente_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0103030000"
                                    With op_ModuloZonaCliente_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0199010000"
                                    With op_ReporteCliente_DatosContacto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0199020000"
                                    With op_ReporteCliente_DatosComerciales
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0199040000"
                                    With op_ReporteCliente_EstadoCuenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0199050000"
                                    With op_ReporteCliente_RetencionesIva
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' PROVEEDORES
                                    '
                                Case "0201000000"
                                    With op_ModuloProveedor
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0201010000"
                                    With op_ModuloProveedor_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0201020000"
                                    With op_ModuloProveedor_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0201030000"
                                    With op_ModuloProveedor_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0202000000"
                                    With op_ModuloGrupoProveedor
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0202010000"
                                    With op_ModuloGrupoProveedor_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0202020000"
                                    With op_ModuloGrupoProveedor_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0202030000"
                                    With op_ModuloGrupoProveedor_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0203000000"
                                    With op_ModuloCtaBancariaProveedor
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0203010000"
                                    With op_ModuloCtaBancariaProveedor_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0203020000"
                                    With op_ModuloCtaBancariaProveedor_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0203030000"
                                    With op_ModuloCtaBancariaProveedor_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0299010000"
                                    With op_ReporteProveedor_DatosContacto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0299020000"
                                    With op_ReporteProveedor_DatosComerciales
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0299040000"
                                    With op_ReporteProveedor_EstadoCuenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0299050000"
                                    With op_ReporteProveedor_RetencionesIva
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' AGENCIA BANCARIA
                                    '
                                Case "0602000000"
                                    With op_ModuloAgenciaBancaria
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0602010000"
                                    With op_ModuloAgenciaBancaria_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0602020000"
                                    With op_ModuloAgenciaBancaria_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0602030000"
                                    With op_ModuloAgenciaBancaria_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' VENDEDORES
                                    '
                                Case "0901000000"
                                    With op_ModuloVendedor
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0901010000"
                                    With op_ModuloVendedor_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0901020000"
                                    With op_ModuloVendedor_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0901030000"
                                    With op_ModuloVendedor_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0902010000"
                                    With op_ModuloVendedor_TablaComisiones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0999010000"
                                    With op_ReporteVendedor_Maestro
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0999020000"
                                    With op_ReporteVendedor_Comisiones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0999030000"
                                    With op_ReporteVendedor_ComisionesVentasDetalle
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' COBRADORES
                                    '
                                Case "0104000000"
                                    With op_ModuloCobrador
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104010000"
                                    With op_ModuloCobrador_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104020000"
                                    With op_ModuloCobrador_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104030000"
                                    With op_ModuloCobrador_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104050000"
                                    With op_ModuloCobrador_TablaComisiones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104990100"
                                    With op_ReporteCobrador_Maestro
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0104990200"
                                    With op_ReporteCobrador_Comisiones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' VENTAS 
                                    '
                                Case "0801000000"
                                    With op_ControlVentasAdministrativa
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0801010000"
                                    With op_ControlVentasAdministrativa_Chimbas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0802000000"
                                    With op_ControlPresupuestos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0803000000"
                                    With op_ControlNotasEntrega
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0804000000"
                                    With op_ControlNotasDebito_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0805000000"
                                    With op_ControlNotasCredito_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0806000000"
                                    With op_ControlPedidos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0807000000"
                                    With op_AdmDocumentos_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0807010000"
                                    With op_AnularDocumentos_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0807020000"
                                    With op_RevertirDocumentos_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0810000000"
                                    With op_ControlRetencionesIva_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0812000000"
                                    With op_AdmDocumentosRetenciones_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0812010000"
                                    With op_AnularDocumentosRetenciones_Ventas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                Case "0850010000"
                                    With op_VentasAdm_VerCosto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0850020000"
                                    With op_VentasAdm_DarDescuento_Item
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0850030000"
                                    With op_VentasAdm_PrecioLibre
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0850040000"
                                    With op_VentasAdm_RecuperarDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                Case "0899010000"
                                    With op_ReporteVentas_LibroSeniat
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899030000"
                                    With op_ReporteVentas_DocumentosGeneral
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899040000"
                                    With op_ReporteVentas_Consolidado
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899050000"
                                    With op_ReporteVentas_PorDepartamento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899060000"
                                    With op_ReporteVentas_PorGrupo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899070000"
                                    With op_ReporteVentas_Utilidad
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899080000"
                                    With op_ReporteVentas_ResumenCuadre
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0899090000"
                                    With op_ReporteVentas_Estadistico
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' VISOR FISCAL
                                    '
                                Case "0809000000"
                                    With op_VisorFiscal
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0809010000"
                                    With op_VisorFiscal_X
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0809020000"
                                    With op_VisorFiscal_Z
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0809030000"
                                    With op_VisorFiscal_Reportes_Z
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0809040000"
                                    With op_VisorFiscal_Reportes_Doc
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' INVENTARIO
                                    '
                                Case "0301000000"
                                    With op_ModuloInventario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301010000"
                                    With op_ModuloInventario_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301020000"
                                    With op_ModuloInventario_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301030000"
                                    With op_ModuloInventario_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301060000"
                                    With op_ModuloInventario_ModificarCosto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301050000"
                                    With op_ModuloInventario_ModificarExistencia
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0301040000"
                                    With op_ModuloInventario_ModificarPrecios
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0303000000"
                                    With op_ModuloInventario_Depart
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0303010000"
                                    With op_ModuloInventario_Depart_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0303020000"
                                    With op_ModuloInventario_Depart_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0303030000"
                                    With op_ModuloInventario_Depart_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0305000000"
                                    With op_ModuloInventario_Marca
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0305010000"
                                    With op_ModuloInventario_Marca_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0305020000"
                                    With op_ModuloInventario_Marca_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0305030000"
                                    With op_ModuloInventario_Marca_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0302000000"
                                    With op_ModuloInventario_Deposito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0302010000"
                                    With op_ModuloInventario_Deposito_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0302020000"
                                    With op_ModuloInventario_Deposito_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0302030000"
                                    With op_ModuloInventario_Deposito_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0307000000"
                                    With op_ModuloInventario_Concepto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0307010000"
                                    With op_ModuloInventario_Concepto_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0307020000"
                                    With op_ModuloInventario_Concepto_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0307030000"
                                    With op_ModuloInventario_Concepto_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0306000000"
                                    With op_ModuloInventario_Medida
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0306010000"
                                    With op_ModuloInventario_Medida_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0306020000"
                                    With op_ModuloInventario_Medida_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0306030000"
                                    With op_ModuloInventario_Medida_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0310000000"
                                    With op_ModuloInventario_DeptoPtoVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0310010000"
                                    With op_ModuloInventario_DeptoPtoVenta_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0310020000"
                                    With op_ModuloInventario_DeptoPtoVenta_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0310030000"
                                    With op_ModuloInventario_DeptoPtoVenta_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0304000000"
                                    With op_ModuloInventario_GrupoSubGrupo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0304010000"
                                    With op_ModuloInventario_GrupoSubGrupo_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0304020000"
                                    With op_ModuloInventario_GrupoSubGrupo_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0304030000"
                                    With op_ModuloInventario_GrupoSubGrupo_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399070000"
                                    With op_ModuloInventario_Kardex
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399010000"
                                    With op_ReporteInventario_MaestroDatos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399020000"
                                    With op_ReporteInventario_PrecioInventario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399030000"
                                    With op_ReporteInventario_ListaPrecio
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399040000"
                                    With op_ReporteInventario_Existencia
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399060000"
                                    With op_ReporteInventario_MovimientoPorConcepto
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399090000"
                                    With op_ReporteInventario_Valorizacion
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0399160000"
                                    With op_ReporteInventario_ProyeccionVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' CUENTA POR COBRAR
                                    '
                                Case "0402000000"
                                    With op_ModuloCxCobrar_ControlCuentas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0403000000"
                                    With op_ModuloCxCobrar_AdministradorDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0403010000"
                                    With op_ModuloCxCobrar_AnularDocumento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0499010000"
                                    With op_ModuloCxCobrar_Reportes_DocumentosCobrar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0499020000"
                                    With op_ModuloCxCobrar_Reportes_CobranzaDiaria
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0499030000"
                                    With op_ModuloCxCobrar_Reportes_PagosEmitidos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0499040000"
                                    With op_ModuloCxCobrar_Reportes_AnalisiVencimiento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' SERVICIO BD
                                    '
                                Case "1212000000"
                                    With op_ServicioBD_Compactar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1213000000"
                                    With op_ServicioBD_Respaldar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1216000000"
                                    With op_ServicioBD_Monitoreo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1101000000"
                                    With op_ServicioBD_WebSite
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1217000000"
                                    With op_ServicioBD_Mantenimiento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With



                                    '
                                    ' USUARIO
                                    '
                                Case "1207000000"
                                    With op_ModuloUsuario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1207010000"
                                    With op_ModuloUsuario_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1207020000"
                                    With op_ModuloUsuario_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1207030000"
                                    With op_ModuloUsuario_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "1215000000"
                                    With op_ModuloGrupoUsuario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1215010000"
                                    With op_ModuloGrupoUsuario_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1215020000"
                                    With op_ModuloGrupoUsuario_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1215030000"
                                    With op_ModuloGrupoUsuario_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "1208000000"
                                    With op_ModuloGrupoUsuario_Permisos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    '
                                    '
                                Case "1201000000"
                                    With Me.op_DatosNegocio
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1202000000"
                                    With Me.op_TasasFiscales
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1204000000"
                                    With Me.op_SeriesFiscales
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1204010000"
                                    With Me.op_SeriesFiscales_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1204020000"
                                    With Me.op_SeriesFiscales_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1204030000"
                                    With Me.op_SeriesFiscales_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "1206000000"
                                    With Me.op_Configuracion
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0601000000"
                                    With op_ModuloMedioPago
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0601010000"
                                    With op_ModuloMedioPago_Ingresar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0601020000"
                                    With op_ModuloMedioPago_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0601030000"
                                    With op_ModuloMedioPago_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' COMPRAS
                                    '

                                Case "0701000000"
                                    With op_ModuloCompra_ControlCompra
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0711000000"
                                    With op_ModuloCompra_ControlCompraGastos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0702000000"
                                    With op_ModuloCompra_OrdenCompra
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0705000000"
                                    With op_ModuloCompra_AdmDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0705010000"
                                    With op_ModuloCompra_AnularDocumento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0704000000"
                                    With op_ModuloCompra_ControlNotasCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0706000000"
                                    With op_ModuloCompra_Retenciones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0708000000"
                                    With op_ModuloCompra_AdmRetenciones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0709010000"
                                    With op_ModuloCompra_AnularRetencion
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0710000000"
                                    With op_ModuloCompra_ActualizarPreciosVentas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0799020000"
                                    With op_ModuloCompras_Reportes_LibroCompra
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0799030000"
                                    With op_ModuloCompras_Reportes_GeneralCompras
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0799040000"
                                    With op_ModuloCompras_Reportes_PorDepartamentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0799050000"
                                    With op_ModuloCompras_Reportes_Retenciones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0799070000"
                                    With op_ModuloCompras_GenerarTxT
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0799080000"
                                    With op_ModuloCompras_Reportes_PorGrupos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' CUENTA POR PAGAR
                                    '
                                Case "0501000000"
                                    With op_ModuloCxPagar_ControlCuentas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0502000000"
                                    With op_ModuloCxPagar_AdministradorDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0502010000"
                                    With op_ModuloCxPagar_AnularDocumento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0599010000"
                                    With op_ModuloCxPagar_Reportes_DocumentosxPagar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0599020000"
                                    With op_ModuloCxPagar_Reportes_PagosEmitidos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0599030000"
                                    With op_ModuloCxPagar_Reportes_AnalisiVencimiento
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' PUNTO DE VENTA > FASTFOOD 
                                    '

                                Case "0808FF0000"
                                    With op_ModuloFastFood_ActivarModulo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0001"
                                    With op_ModuloFastFood_MenuPlatos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0002"
                                    With op_ModuloFastFood_AdministradorDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0003"
                                    With op_ModuloFastFood_ReporteCuadreCaja
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0004"
                                    With op_ModuloFastFood_ServicioFiscal
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0005"
                                    With op_ModuloFastFood_ConfiguracionGeneral
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0006"
                                    With op_ModuloFastFood_IniciarJornada
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0007"
                                    With op_ModuloFastFood_AbrirPtoVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0008"
                                    With op_ModuloFastFood_CerrarOperador
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0009"
                                    With op_ModuloFastFood_CerrarJornada
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0010"
                                    With op_ModuloFastFood_AdministradorJornadas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0011"
                                    With op_ModuloFastFood_PTO_AbrirGaveta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0012"
                                    With op_ModuloFastFood_PTO_FondoCaja
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0013"
                                    With op_ModuloFastFood_PTO_RetiroCaja
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0014"
                                    With op_ModuloFastFood_PTO_ActivarInventario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0015"
                                    With op_ModuloFastFood_PTO_CtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0016"
                                    With op_ModuloFastFood_PTO_EliminarCtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0017"
                                    With op_ModuloFastFood_PTO_EliminarTodasCtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0018"
                                    With op_ModuloFastFood_PTO_AnularPedido
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0019"
                                    With op_ModuloFastFood_PTO_DevolucionItem
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0020"
                                    With op_ModuloFastFood_PTO_EliminarItem
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0021"
                                    With op_ModuloFastFood_PTO_AjustarItem
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0022"
                                    With op_ModuloFastFood_PTO_DarDescuentoFacturar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0023"
                                    With op_ModuloFastFood_PTO_DejarCtaCreditoFacturar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0024"
                                    With op_ModuloFastFood_PTO_ReEnviarComanads
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0025"
                                    With op_ModuloFastFood_ReimprimirCuadreCaja
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0026"
                                    With op_ModuloFastFood_NotaCRedito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0027"
                                    With op_ModuloFastFood_AnularNotaCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0028"
                                    With op_ModuloFastFood_Reporte_X
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0029"
                                    With op_ModuloFastFood_Reporte_Z
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0030"
                                    With op_ModuloFastFood_ReporteZ_Acumulados
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0031"
                                    With op_ModuloFastFood_ReporteAcumuladoDocumentosFiscal
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0808FF0032"
                                    With op_ModuloFastFood_Menu_Modulo_GrupoPlatos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0033"
                                    With op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Agregar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0034"
                                    With op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0035"
                                    With op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0036"
                                    With op_ModuloFastFood_Menu_Modulo_EstacionComandas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0037"
                                    With op_ModuloFastFood_Menu_Modulo_EstacionComandas_Agergar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0038"
                                    With op_ModuloFastFood_Menu_Modulo_EstacionComandas_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0039"
                                    With op_ModuloFastFood_Menu_Modulo_EstacionComandas_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0040"
                                    With op_ModuloFastFood_Menu_Agregar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0041"
                                    With op_ModuloFastFood_Menu_Modificar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0042"
                                    With op_ModuloFastFood_Menu_Eliminar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With

                                Case "0808FF0043"
                                    With op_ModuloFastFood_Menu_OpcionBalanza
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0044"
                                    With op_ModuloFastFood_Menu_OpcionCombo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0045"
                                    With op_ModuloFastFood_Menu_OpcionEstaciones
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0046"
                                    With op_ModuloFastFood_Menu_OpcionPrecioVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0047"
                                    With op_ModuloFastFood_Menu_OpcionOferta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0048"
                                    With op_ModuloFastFood_Menu_OpcionInventario
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808FF0049"
                                    With op_ModuloFastFood_Menu_OpcionImagen
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' PUNTO DE VENTA > RESTAURANT
                                    '

                                Case "0808RT0000"
                                    With op_ModuloRestaurant_ActivarModulo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0001"
                                    With op_ModuloRestaurant_UnirMesas
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0002"
                                    With op_ModuloRestaurant_CambioMesa
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0003"
                                    With op_ModuloRestaurant_AnularMesa
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0004"
                                    With op_ModuloRestaurant_AnularPedido
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0005"
                                    With op_ModuloRestaurant_TrasaladarPedidoMesa
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0006"
                                    With op_ModuloRestaurant_DevolucionPlatos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0007"
                                    With op_ModuloRestaurant_EliminarItem
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0008"
                                    With op_ModuloRestaurant_DarDescuentoFacturar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808RT0009"
                                    With op_ModuloRestaurant_FacturarCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' CONFIGURACION DE DISPOSITIVO
                                    '

                                Case "1301000000"
                                    With Me.op_ModuloCnfDispositivo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                    '
                                    ' POS ONLINE
                                    '

                                Case "0808POS051"
                                    With Me.op_PosOnline_AbrirGaveta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS052"
                                    With Me.op_PosOnline_FondoInicio
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS053"
                                    With Me.op_PosOnline_RetiroDinero
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS054"
                                    With Me.op_PosOnline_ActivarCtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS055"
                                    With Me.op_PosOnline_EliminarCtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS056"
                                    With Me.op_PosOnline_AbrirCtsaOtrosUsuarios
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS057"
                                    With Me.op_PosOnline_DevItemCodBarra
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS058"
                                    With Me.op_PosOnline_EliminarItem
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS059"
                                    With Me.op_PosOnline_AnularVentaProceso
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS060"
                                    With Me.op_PosOnline_AjustarItem_Agregar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS061"
                                    With Me.op_PosOnline_EditarDatosCliente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS062"
                                    With Me.op_PosOnline_HabilitarDescuentoVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS063"
                                    With Me.op_PosOnline_HabilitarVentaCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS064"
                                    With Me.op_PosOnline_ActivarPtoTarjetaCtaPendiente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS065"
                                    With Me.op_PosOnline_VerificarExistenciaAlFacturar
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS066"
                                    With Me.op_PosOnline_PermitirVentaMayor
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS067"
                                    With Me.op_PosOnline_AnularTicketBalanza
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS068"
                                    With Me.op_PosOnline_PermitirCambiarPrecioCantidad
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS069"
                                    With Me.op_PosOnline_EliminarTodasCuentasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With


                                Case "0808POS000"
                                    With Me.op_PosOnline_AbrirModulo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS001"
                                    With Me.op_PosOnline_IniciarJornada
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS002"
                                    With Me.op_PosOnline_AbrirPtoVenta
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS003"
                                    With Me.op_PosOnline_CerrarOperador
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS004"
                                    With Me.op_PosOnline_CerrarJornada
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS005"
                                    With Me.op_PosOnline_AdministradorJornada
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS006"
                                    With Me.op_PosOnline_CerrarJornadaConCtasPendientes
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS007"
                                    With Me.op_PosOnline_CerrarJornadaConTicketBalanzaPendiente
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS008"
                                    With Me.op_PosOnline_HabilitarAdministradorDocumentos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS009"
                                    With Me.op_PosOnline_ElaborarNotasCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS010"
                                    With Me.op_PosOnline_AnularNotasCredito
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS011"
                                    With Me.op_PosOnline_ReporteCuadreCaja
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS012"
                                    With Me.op_PosOnline_HabilitarReporteCuadreCaja_Pantalla
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS013"
                                    With Me.op_PosOnline_ServicioFiscal
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS014"
                                    With Me.op_PosOnline_ServicioFiscal_X
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS015"
                                    With Me.op_PosOnline_ServicioFiscal_Z
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS016"
                                    With Me.op_PosOnline_ServicioFiscal_Z_Acumualados
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS017"
                                    With Me.op_PosOnline_ServicioFiscal_DocAcumualdos
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                                Case "0808POS018"
                                    With Me.op_PosOnline_ConfiguracionDispositivo
                                        ._Nivel = xopcion.RegistroDato.r_NivelSeguridad
                                        ._EstatusPermiso = xopcion.RegistroDato.r_EstatusOpcion
                                    End With
                            End Select
                        Next
                    Catch ex As Exception
                        Throw New Exception("ERROR AL CARGAR PERMISOS" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub LimpiarFicha()

                    '
                    ' CONFIGURACIONDE DISPOSITIVO
                    '
                    Me.op_ModuloCnfDispositivo = New Permiso

                    '
                    ' CLIENTES
                    '
                    Me.op_ModuloCliente = New Permiso
                    Me.op_ModuloCliente_Ingresar = New Permiso
                    Me.op_ModuloCliente_Modificar = New Permiso
                    Me.op_ModuloCliente_Eliminar = New Permiso

                    Me.op_ModuloGrupoCliente = New Permiso
                    Me.op_ModuloGrupoCliente_Ingresar = New Permiso
                    Me.op_ModuloGrupoCliente_Modificar = New Permiso
                    Me.op_ModuloGrupoCliente_Eliminar = New Permiso

                    Me.op_ModuloZonaCliente = New Permiso
                    Me.op_ModuloZonaCliente_Ingresar = New Permiso
                    Me.op_ModuloZonaCliente_Modificar = New Permiso
                    Me.op_ModuloZonaCliente_Eliminar = New Permiso

                    Me.op_ReporteCliente_DatosContacto = New Permiso
                    Me.op_ReporteCliente_DatosComerciales = New Permiso
                    Me.op_ReporteCliente_EstadoCuenta = New Permiso
                    Me.op_ReporteCliente_RetencionesIva = New Permiso

                    '
                    ' PROVEEDORES
                    '
                    Me.op_ModuloProveedor = New Permiso
                    Me.op_ModuloProveedor_Ingresar = New Permiso
                    Me.op_ModuloProveedor_Modificar = New Permiso
                    Me.op_ModuloProveedor_Eliminar = New Permiso

                    Me.op_ModuloGrupoProveedor = New Permiso
                    Me.op_ModuloGrupoProveedor_Ingresar = New Permiso
                    Me.op_ModuloGrupoProveedor_Modificar = New Permiso
                    Me.op_ModuloGrupoProveedor_Eliminar = New Permiso

                    Me.op_ModuloCtaBancariaProveedor = New Permiso
                    Me.op_ModuloCtaBancariaProveedor_Ingresar = New Permiso
                    Me.op_ModuloCtaBancariaProveedor_Modificar = New Permiso
                    Me.op_ModuloCtaBancariaProveedor_Eliminar = New Permiso

                    Me.op_ReporteProveedor_DatosContacto = New Permiso
                    Me.op_ReporteProveedor_DatosComerciales = New Permiso
                    Me.op_ReporteProveedor_EstadoCuenta = New Permiso
                    Me.op_ReporteProveedor_RetencionesIva = New Permiso

                    '
                    ' AGENCIAS BANCARIAS
                    '
                    Me.op_ModuloAgenciaBancaria = New Permiso
                    Me.op_ModuloAgenciaBancaria_Ingresar = New Permiso
                    Me.op_ModuloAgenciaBancaria_Modificar = New Permiso
                    Me.op_ModuloAgenciaBancaria_Eliminar = New Permiso

                    '
                    ' VENDEDORES
                    '
                    Me.op_ModuloVendedor = New Permiso
                    Me.op_ModuloVendedor_Ingresar = New Permiso
                    Me.op_ModuloVendedor_Modificar = New Permiso
                    Me.op_ModuloVendedor_Eliminar = New Permiso
                    Me.op_ModuloVendedor_TablaComisiones = New Permiso
                    Me.op_ReporteVendedor_Maestro = New Permiso
                    Me.op_ReporteVendedor_Comisiones = New Permiso
                    Me.op_ReporteVendedor_ComisionesVentasDetalle = New Permiso

                    '
                    ' COBRADORES
                    '
                    Me.op_ModuloCobrador = New Permiso
                    Me.op_ModuloCobrador_Ingresar = New Permiso
                    Me.op_ModuloCobrador_Modificar = New Permiso
                    Me.op_ModuloCobrador_Eliminar = New Permiso
                    Me.op_ModuloCobrador_TablaComisiones = New Permiso
                    Me.op_ReporteCobrador_Maestro = New Permiso
                    Me.op_ReporteCobrador_Comisiones = New Permiso

                    '
                    ' VENTAS
                    '
                    Me.op_VentasAdm_VerCosto = New Permiso
                    Me.op_VentasAdm_DarDescuento_Item = New Permiso
                    Me.op_VentasAdm_PrecioLibre = New Permiso
                    Me.op_VentasAdm_RecuperarDocumentos = New Permiso

                    Me.op_ControlNotasCredito_Ventas = New Permiso
                    Me.op_ControlNotasDebito_Ventas = New Permiso
                    Me.op_ControlNotasEntrega = New Permiso
                    Me.op_ControlPresupuestos = New Permiso
                    Me.op_ControlVentasAdministrativa = New Permiso
                    Me.op_ControlVentasAdministrativa_Chimbas = New Permiso
                    Me.op_ControlPedidos = New Permiso
                    Me.op_ControlRetencionesIva_Ventas = New Permiso
                    Me.op_AdmDocumentos_Ventas = New Permiso
                    Me.op_AnularDocumentos_Ventas = New Permiso
                    Me.op_RevertirDocumentos_Ventas = New Permiso
                    Me.op_AdmDocumentosRetenciones_Ventas = New Permiso
                    Me.op_AnularDocumentosRetenciones_Ventas = New Permiso

                    Me.op_ReporteVentas_Consolidado = New Permiso
                    Me.op_ReporteVentas_DocumentosGeneral = New Permiso
                    Me.op_ReporteVentas_LibroSeniat = New Permiso
                    Me.op_ReporteVentas_PorDepartamento = New Permiso
                    Me.op_ReporteVentas_PorGrupo = New Permiso
                    Me.op_ReporteVentas_Utilidad = New Permiso
                    Me.op_ReporteVentas_ResumenCuadre = New Permiso
                    Me.op_ReporteVentas_Estadistico = New Permiso

                    '
                    ' VISOR FISCAL
                    '
                    Me.op_VisorFiscal = New Permiso
                    Me.op_VisorFiscal_X = New Permiso
                    Me.op_VisorFiscal_Z = New Permiso
                    Me.op_VisorFiscal_Reportes_Z = New Permiso
                    Me.op_VisorFiscal_Reportes_Doc = New Permiso

                    '
                    ' INVENTARIO
                    '
                    Me.op_ModuloInventario = New Permiso
                    Me.op_ModuloInventario_Ingresar = New Permiso
                    Me.op_ModuloInventario_Modificar = New Permiso
                    Me.op_ModuloInventario_Eliminar = New Permiso
                    Me.op_ModuloInventario_ModificarCosto = New Permiso
                    Me.op_ModuloInventario_ModificarExistencia = New Permiso
                    Me.op_ModuloInventario_ModificarPrecios = New Permiso

                    Me.op_ModuloInventario_Depart = New Permiso
                    Me.op_ModuloInventario_Depart_Ingresar = New Permiso
                    Me.op_ModuloInventario_Depart_Modificar = New Permiso
                    Me.op_ModuloInventario_Depart_Eliminar = New Permiso

                    Me.op_ModuloInventario_Marca = New Permiso
                    Me.op_ModuloInventario_Marca_Ingresar = New Permiso
                    Me.op_ModuloInventario_Marca_Modificar = New Permiso
                    Me.op_ModuloInventario_Marca_Eliminar = New Permiso

                    Me.op_ModuloInventario_Deposito = New Permiso
                    Me.op_ModuloInventario_Deposito_Ingresar = New Permiso
                    Me.op_ModuloInventario_Deposito_Modificar = New Permiso
                    Me.op_ModuloInventario_Deposito_Eliminar = New Permiso

                    Me.op_ModuloInventario_Concepto = New Permiso
                    Me.op_ModuloInventario_Concepto_Ingresar = New Permiso
                    Me.op_ModuloInventario_Concepto_Modificar = New Permiso
                    Me.op_ModuloInventario_Concepto_Eliminar = New Permiso

                    Me.op_ModuloInventario_Medida = New Permiso
                    Me.op_ModuloInventario_Medida_Ingresar = New Permiso
                    Me.op_ModuloInventario_Medida_Modificar = New Permiso
                    Me.op_ModuloInventario_Medida_Eliminar = New Permiso

                    Me.op_ModuloInventario_DeptoPtoVenta = New Permiso
                    Me.op_ModuloInventario_DeptoPtoVenta_Ingresar = New Permiso
                    Me.op_ModuloInventario_DeptoPtoVenta_Modificar = New Permiso
                    Me.op_ModuloInventario_DeptoPtoVenta_Eliminar = New Permiso

                    Me.op_ModuloInventario_GrupoSubGrupo = New Permiso
                    Me.op_ModuloInventario_GrupoSubGrupo_Ingresar = New Permiso
                    Me.op_ModuloInventario_GrupoSubGrupo_Modificar = New Permiso
                    Me.op_ModuloInventario_GrupoSubGrupo_Eliminar = New Permiso

                    Me.op_ModuloInventario_Kardex = New Permiso
                    Me.op_ReporteInventario_MaestroDatos = New Permiso
                    Me.op_ReporteInventario_PrecioInventario = New Permiso
                    Me.op_ReporteInventario_ListaPrecio = New Permiso
                    Me.op_ReporteInventario_Existencia = New Permiso
                    Me.op_ReporteInventario_MovimientoPorConcepto = New Permiso
                    Me.op_ReporteInventario_Valorizacion = New Permiso
                    Me.op_ReporteInventario_ProyeccionVenta = New Permiso

                    '
                    ' USUARIOS
                    '
                    Me.op_ModuloUsuario = New Permiso
                    Me.op_ModuloUsuario_Ingresar = New Permiso
                    Me.op_ModuloUsuario_Modificar = New Permiso
                    Me.op_ModuloUsuario_Eliminar = New Permiso
                    Me.op_ModuloGrupoUsuario = New Permiso
                    Me.op_ModuloGrupoUsuario_Ingresar = New Permiso
                    Me.op_ModuloGrupoUsuario_Modificar = New Permiso
                    Me.op_ModuloGrupoUsuario_Eliminar = New Permiso
                    Me.op_ModuloGrupoUsuario_Permisos = New Permiso

                    '
                    ' CUENTAS POR COBRAR
                    '
                    Me.op_ModuloCxCobrar_ControlCuentas = New Permiso
                    Me.op_ModuloCxCobrar_AdministradorDocumentos = New Permiso
                    Me.op_ModuloCxCobrar_AnularDocumento = New Permiso
                    Me.op_ModuloCxCobrar_Reportes_DocumentosCobrar = New Permiso
                    Me.op_ModuloCxCobrar_Reportes_CobranzaDiaria = New Permiso
                    Me.op_ModuloCxCobrar_Reportes_PagosEmitidos = New Permiso
                    Me.op_ModuloCxCobrar_Reportes_AnalisiVencimiento = New Permiso

                    '
                    ' SERVICIO BD
                    '
                    Me.op_ServicioBD_Compactar = New Permiso
                    Me.op_ServicioBD_Respaldar = New Permiso
                    Me.op_ServicioBD_WebSite = New Permiso
                    Me.op_ServicioBD_Monitoreo = New Permiso
                    Me.op_ServicioBD_Mantenimiento = New Permiso

                    '
                    ' 
                    '
                    Me.op_DatosNegocio = New Permiso
                    Me.op_TasasFiscales = New Permiso
                    Me.op_SeriesFiscales = New Permiso
                    Me.op_SeriesFiscales_Ingresar = New Permiso
                    Me.op_SeriesFiscales_Modificar = New Permiso
                    Me.op_SeriesFiscales_Eliminar = New Permiso
                    Me.op_Configuracion = New Permiso

                    Me.op_ModuloMedioPago = New Permiso
                    Me.op_ModuloMedioPago_Ingresar = New Permiso
                    Me.op_ModuloMedioPago_Modificar = New Permiso
                    Me.op_ModuloMedioPago_Eliminar = New Permiso

                    '
                    ' COMPRAS
                    '
                    Me.op_ModuloCompra_ControlCompra = New Permiso
                    Me.op_ModuloCompra_ControlCompraGastos = New Permiso
                    Me.op_ModuloCompra_OrdenCompra = New Permiso
                    Me.op_ModuloCompra_AdmDocumentos = New Permiso
                    Me.op_ModuloCompra_AnularDocumento = New Permiso
                    Me.op_ModuloCompra_ControlNotasCredito = New Permiso
                    Me.op_ModuloCompra_Retenciones = New Permiso
                    Me.op_ModuloCompra_AdmRetenciones = New Permiso
                    Me.op_ModuloCompra_AnularRetencion = New Permiso
                    Me.op_ModuloCompra_ActualizarPreciosVentas = New Permiso

                    Me.op_ModuloCompras_Reportes_LibroCompra = New Permiso
                    Me.op_ModuloCompras_Reportes_GeneralCompras = New Permiso
                    Me.op_ModuloCompras_Reportes_PorDepartamentos = New Permiso
                    Me.op_ModuloCompras_Reportes_PorGrupos = New Permiso
                    Me.op_ModuloCompras_Reportes_Retenciones = New Permiso
                    Me.op_ModuloCompras_GenerarTxT = New Permiso


                    '
                    ' CUENTAS POR PAGAR
                    '
                    Me.op_ModuloCxPagar_ControlCuentas = New Permiso
                    Me.op_ModuloCxPagar_AdministradorDocumentos = New Permiso
                    Me.op_ModuloCxPagar_AnularDocumento = New Permiso
                    Me.op_ModuloCxPagar_Reportes_DocumentosxPagar = New Permiso
                    Me.op_ModuloCxPagar_Reportes_PagosEmitidos = New Permiso
                    Me.op_ModuloCxPagar_Reportes_AnalisiVencimiento = New Permiso


                    '
                    ' PUNTO DE VENTA :> FASTFOOD
                    '
                    Me.op_ModuloFastFood_ActivarModulo = New Permiso
                    Me.op_ModuloFastFood_MenuPlatos = New Permiso
                    Me.op_ModuloFastFood_AdministradorDocumentos = New Permiso
                    Me.op_ModuloFastFood_ReporteCuadreCaja = New Permiso
                    Me.op_ModuloFastFood_ServicioFiscal = New Permiso
                    Me.op_ModuloFastFood_ConfiguracionGeneral = New Permiso
                    Me.op_ModuloFastFood_IniciarJornada = New Permiso
                    Me.op_ModuloFastFood_AbrirPtoVenta = New Permiso
                    Me.op_ModuloFastFood_CerrarOperador = New Permiso
                    Me.op_ModuloFastFood_CerrarJornada = New Permiso
                    Me.op_ModuloFastFood_AdministradorJornadas = New Permiso
                    Me.op_ModuloFastFood_ReimprimirCuadreCaja = New Permiso
                    Me.op_ModuloFastFood_NotaCRedito = New Permiso
                    Me.op_ModuloFastFood_AnularNotaCredito = New Permiso
                    Me.op_ModuloFastFood_Reporte_X = New Permiso
                    Me.op_ModuloFastFood_Reporte_Z = New Permiso
                    Me.op_ModuloFastFood_ReporteZ_Acumulados = New Permiso
                    Me.op_ModuloFastFood_ReporteAcumuladoDocumentosFiscal = New Permiso

                    Me.op_ModuloFastFood_PTO_AbrirGaveta = New Permiso
                    Me.op_ModuloFastFood_PTO_ActivarInventario = New Permiso
                    Me.op_ModuloFastFood_PTO_AjustarItem = New Permiso
                    Me.op_ModuloFastFood_PTO_AnularPedido = New Permiso
                    Me.op_ModuloFastFood_PTO_CtasPendientes = New Permiso
                    Me.op_ModuloFastFood_PTO_DarDescuentoFacturar = New Permiso
                    Me.op_ModuloFastFood_PTO_DejarCtaCreditoFacturar = New Permiso
                    Me.op_ModuloFastFood_PTO_DevolucionItem = New Permiso
                    Me.op_ModuloFastFood_PTO_EliminarCtasPendientes = New Permiso
                    Me.op_ModuloFastFood_PTO_EliminarItem = New Permiso
                    Me.op_ModuloFastFood_PTO_EliminarTodasCtasPendientes = New Permiso
                    Me.op_ModuloFastFood_PTO_FondoCaja = New Permiso
                    Me.op_ModuloFastFood_PTO_RetiroCaja = New Permiso
                    Me.op_ModuloFastFood_PTO_ReEnviarComanads = New Permiso

                    Me.op_ModuloFastFood_Menu_Modulo_GrupoPlatos = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Agregar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Modificar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_GrupoPlatos_Eliminar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_EstacionComandas = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_EstacionComandas_Agergar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_EstacionComandas_Modificar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modulo_EstacionComandas_Eliminar = New Permiso
                    Me.op_ModuloFastFood_Menu_Agregar = New Permiso
                    Me.op_ModuloFastFood_Menu_Modificar = New Permiso
                    Me.op_ModuloFastFood_Menu_Eliminar = New Permiso

                    Me.op_ModuloFastFood_Menu_OpcionBalanza = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionCombo = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionEstaciones = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionPrecioVenta = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionOferta = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionInventario = New Permiso
                    Me.op_ModuloFastFood_Menu_OpcionImagen = New Permiso


                    '
                    ' RESTAURANT
                    '
                    Me.op_ModuloRestaurant_ActivarModulo = New Permiso
                    Me.op_ModuloRestaurant_UnirMesas = New Permiso
                    Me.op_ModuloRestaurant_CambioMesa = New Permiso
                    Me.op_ModuloRestaurant_AnularMesa = New Permiso
                    Me.op_ModuloRestaurant_AnularPedido = New Permiso
                    Me.op_ModuloRestaurant_TrasaladarPedidoMesa = New Permiso
                    Me.op_ModuloRestaurant_DevolucionPlatos = New Permiso
                    Me.op_ModuloRestaurant_EliminarItem = New Permiso
                    Me.op_ModuloRestaurant_DarDescuentoFacturar = New Permiso
                    Me.op_ModuloRestaurant_FacturarCredito = New Permiso


                    '
                    ' POS ONLINE
                    '
                    Me.op_PosOnline_AbrirGaveta = New Permiso
                    Me.op_PosOnline_FondoInicio = New Permiso
                    Me.op_PosOnline_RetiroDinero = New Permiso
                    Me.op_PosOnline_ActivarCtasPendientes = New Permiso
                    Me.op_PosOnline_EliminarCtasPendientes = New Permiso
                    Me.op_PosOnline_AbrirCtsaOtrosUsuarios = New Permiso
                    Me.op_PosOnline_DevItemCodBarra = New Permiso
                    Me.op_PosOnline_EliminarItem = New Permiso
                    Me.op_PosOnline_AnularVentaProceso = New Permiso
                    Me.op_PosOnline_AjustarItem_Agregar = New Permiso
                    Me.op_PosOnline_EditarDatosCliente = New Permiso
                    Me.op_PosOnline_HabilitarDescuentoVenta = New Permiso
                    Me.op_PosOnline_HabilitarVentaCredito = New Permiso
                    Me.op_PosOnline_ActivarPtoTarjetaCtaPendiente = New Permiso
                    Me.op_PosOnline_VerificarExistenciaAlFacturar = New Permiso
                    Me.op_PosOnline_PermitirVentaMayor = New Permiso
                    Me.op_PosOnline_AnularTicketBalanza = New Permiso
                    Me.op_PosOnline_PermitirCambiarPrecioCantidad = New Permiso
                    Me.op_PosOnline_EliminarTodasCuentasPendientes = New Permiso

                    Me.op_PosOnline_AbrirModulo = New Permiso
                    Me.op_PosOnline_IniciarJornada = New Permiso
                    Me.op_PosOnline_AbrirPtoVenta = New Permiso
                    Me.op_PosOnline_CerrarOperador = New Permiso
                    Me.op_PosOnline_CerrarJornada = New Permiso
                    Me.op_PosOnline_AdministradorJornada = New Permiso
                    Me.op_PosOnline_CerrarJornadaConCtasPendientes = New Permiso
                    Me.op_PosOnline_CerrarJornadaConTicketBalanzaPendiente = New Permiso
                    Me.op_PosOnline_HabilitarAdministradorDocumentos = New Permiso
                    Me.op_PosOnline_ElaborarNotasCredito = New Permiso
                    Me.op_PosOnline_AnularNotasCredito = New Permiso
                    Me.op_PosOnline_ReporteCuadreCaja = New Permiso
                    Me.op_PosOnline_HabilitarReporteCuadreCaja_Pantalla = New Permiso
                    Me.op_PosOnline_ServicioFiscal = New Permiso
                    Me.op_PosOnline_ServicioFiscal_X = New Permiso
                    Me.op_PosOnline_ServicioFiscal_Z = New Permiso
                    Me.op_PosOnline_ServicioFiscal_Z_Acumualados = New Permiso
                    Me.op_PosOnline_ServicioFiscal_DocAcumualdos = New Permiso
                    Me.op_PosOnline_ConfiguracionDispositivo = New Permiso
                End Sub

                Sub New()
                    LimpiarFicha()
                    Me.p_TablaDato = New DataTable
                End Sub
            End Class
        End Class
    End Class
End Namespace
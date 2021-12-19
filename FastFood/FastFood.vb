Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Namespace MiDataSistema
    Partial Public Class DataSistema

        Partial Public Class FastFood
            Event _JornadaCreadaOk(ByVal xautoJornada As String)
            Event _JornadaAbierta(ByVal xautoJornada As String)
            Event _JornadaCerrada(ByVal xautoJornada As String)
            Event _OperadorAbierto(ByVal xautoOperador As String)
            Event _OperadorCreado(ByVal xautoOperador As String)
            Event _OperadorCerrado(ByVal xautoOperador As String)

            Private xjornada As Jornada
            Private xjornada_activa As JornadaActiva
            Private xoperadorjornada As OperadorJornada
            Private xoperadorjornada_activa As OperadorJornada_Activa
            Private xfondoretiroaperturagaveta As FondoRetiroAperturaGaveta

            Private xgrupomenu As GrupoFastFood
            Private xplatos As Platos
            Private xplatoscombos As PlatosCombos
            Private xestacion As EstacionFastFood
            Private xplatoestacion As MenuPlatoEstacion

            Private xdevanula As DevolucionAnulacion_FastFood
            Private xtemporalventa As TemporalVenta_FastFood
            Private xtemporalventanotas As TemporalVenta_NotasPlato_FastFood
            Private xtemporalventapendiente As TemporalVentaPendiente_FastFood
            Private xtemporalventapendientedetalle As TemporalVentaPendienteDetalle_FastFood
            Private xtemporalventapendientedetallenotas As TemporalVentaPendiente_NotasPlato_FastFood
            Private xventadetalle_fastfood As VentasDetalle_FastFood
            Private xplatosalida As PlatoSalida
            Private xplatoinventario As PlatosInventario
            Private xventainventario As VentaInventario


            Property F_Jornada() As Jornada
                Get
                    Return xjornada
                End Get
                Set(ByVal value As Jornada)
                    xjornada = value
                End Set
            End Property

            Property F_JornadaActiva() As JornadaActiva
                Get
                    Return xjornada_activa
                End Get
                Set(ByVal value As JornadaActiva)
                    xjornada_activa = value
                End Set
            End Property

            Property F_OperadorJornada() As OperadorJornada
                Get
                    Return xoperadorjornada
                End Get
                Set(ByVal value As OperadorJornada)
                    xoperadorjornada = value
                End Set
            End Property

            Property F_OperadorJornada_Activa() As OperadorJornada_Activa
                Get
                    Return xoperadorjornada_activa
                End Get
                Set(ByVal value As OperadorJornada_Activa)
                    xoperadorjornada_activa = value
                End Set
            End Property

            Property F_FondoRetiroAperturaGaveta() As FondoRetiroAperturaGaveta
                Get
                    Return xfondoretiroaperturagaveta
                End Get
                Set(ByVal value As FondoRetiroAperturaGaveta)
                    xfondoretiroaperturagaveta = value
                End Set
            End Property

            Property F_TemporalVenta() As TemporalVenta_FastFood
                Get
                    Return xtemporalventa
                End Get
                Set(ByVal value As TemporalVenta_FastFood)
                    xtemporalventa = value
                End Set
            End Property

            Property F_TemporalVentaNotasPlato() As TemporalVenta_NotasPlato_FastFood
                Get
                    Return xtemporalventanotas
                End Get
                Set(ByVal value As TemporalVenta_NotasPlato_FastFood)
                    xtemporalventanotas = value
                End Set
            End Property

            Property F_TemporalVentaPendiente() As TemporalVentaPendiente_FastFood
                Get
                    Return xtemporalventapendiente
                End Get
                Set(ByVal value As TemporalVentaPendiente_FastFood)
                    xtemporalventapendiente = value
                End Set
            End Property

            Property F_TemporalVentaPendienteDetalle() As TemporalVentaPendienteDetalle_FastFood
                Get
                    Return xtemporalventapendientedetalle
                End Get
                Set(ByVal value As TemporalVentaPendienteDetalle_FastFood)
                    xtemporalventapendientedetalle = value
                End Set
            End Property

            Property F_TemporalVentaPendienteDetalleNotas() As TemporalVentaPendiente_NotasPlato_FastFood
                Get
                    Return xtemporalventapendientedetallenotas
                End Get
                Set(ByVal value As TemporalVentaPendiente_NotasPlato_FastFood)
                    xtemporalventapendientedetallenotas = value
                End Set
            End Property

            Property F_VentaDetalleFastFood() As VentasDetalle_FastFood
                Get
                    Return xventadetalle_fastfood
                End Get
                Set(ByVal value As VentasDetalle_FastFood)
                    xventadetalle_fastfood = value
                End Set
            End Property


            Property f_GrupoMenu() As GrupoFastFood
                Get
                    Return xgrupomenu
                End Get
                Set(ByVal value As GrupoFastFood)
                    xgrupomenu = value
                End Set
            End Property

            Property f_PlatosMenu() As Platos
                Get
                    Return xplatos
                End Get
                Set(ByVal value As Platos)
                    xplatos = value
                End Set
            End Property

            Property f_PlatosCombo() As PlatosCombos
                Get
                    Return xplatoscombos
                End Get
                Set(ByVal value As PlatosCombos)
                    xplatoscombos = value
                End Set
            End Property

            Property f_EstacionComanda() As EstacionFastFood
                Get
                    Return xestacion
                End Get
                Set(ByVal value As EstacionFastFood)
                    xestacion = value
                End Set
            End Property

            Property f_PlatoEstacionComanda() As MenuPlatoEstacion
                Get
                    Return xplatoestacion
                End Get
                Set(ByVal value As MenuPlatoEstacion)
                    xplatoestacion = value
                End Set
            End Property

            Property f_DevAnulacionFastFood() As DevolucionAnulacion_FastFood
                Get
                    Return xdevanula
                End Get
                Set(ByVal value As DevolucionAnulacion_FastFood)
                    xdevanula = value
                End Set
            End Property

            Property f_PlatoSalida() As PlatoSalida
                Get
                    Return xplatosalida
                End Get
                Set(ByVal value As PlatoSalida)
                    xplatosalida = value
                End Set
            End Property

            Property f_PlatoInventario() As PlatosInventario
                Get
                    Return xplatoinventario
                End Get
                Set(ByVal value As PlatosInventario)
                    xplatoinventario = value
                End Set
            End Property

            ''' <summary>
            ''' REGISTRA LOS PRODUCTOS QUE TOCAN INVENTARIO DEFINIDOS POR PLATOS INVENTARIO
            ''' </summary>
            Property f_VentaInventario() As VentaInventario
                Get
                    Return xventainventario
                End Get
                Set(ByVal value As VentaInventario)
                    xventainventario = value
                End Set
            End Property


            Sub New()
                Me.F_Jornada = New Jornada
                Me.F_JornadaActiva = New JornadaActiva
                Me.F_OperadorJornada = New OperadorJornada
                Me.F_OperadorJornada_Activa = New OperadorJornada_Activa
                Me.F_FondoRetiroAperturaGaveta = New FondoRetiroAperturaGaveta

                Me.f_GrupoMenu = New GrupoFastFood
                Me.f_PlatosMenu = New Platos
                Me.f_PlatosCombo = New PlatosCombos
                Me.f_EstacionComanda = New EstacionFastFood
                Me.f_PlatoEstacionComanda = New MenuPlatoEstacion

                Me.f_DevAnulacionFastFood = New DevolucionAnulacion_FastFood
                Me.F_TemporalVenta = New TemporalVenta_FastFood
                Me.F_TemporalVentaNotasPlato = New TemporalVenta_NotasPlato_FastFood
                Me.F_TemporalVentaPendiente = New TemporalVentaPendiente_FastFood
                Me.F_TemporalVentaPendienteDetalle = New TemporalVentaPendienteDetalle_FastFood
                Me.F_TemporalVentaPendienteDetalleNotas = New TemporalVentaPendiente_NotasPlato_FastFood

                Me.F_VentaDetalleFastFood = New VentasDetalle_FastFood
                Me.f_PlatoSalida = New PlatoSalida
                Me.f_PlatoInventario = New PlatosInventario
                Me.f_VentaInventario = New VentaInventario
            End Sub

            Function F_VerificarEstatusJornada(ByVal xserial_imp As String) As Boolean
                Try
                    Dim xobj As Object = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto_jornada from jornadaactiva where serialfiscal=@serialfiscal"
                                xcmd.Parameters.AddWithValue("@serialfiscal", xserial_imp.Trim)
                                xobj = xcmd.ExecuteScalar()
                            End Using

                            If (xobj Is Nothing) Or (IsDBNull(xobj)) Then
                                Return False
                            Else
                                RaiseEvent _JornadaAbierta(xobj.ToString)
                                Return True
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("FAST FOOD" & vbCrLf & "FUNCION: VERIFICAR ESTATUS JORNADA ACTIVA" & vbCrLf & ex.Message)
                End Try
            End Function

            Function F_VerificarEstatusOperador(ByVal xauto_jornada As String) As Boolean
                Try
                    Dim xobj As Object = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select auto_operador from operadorjornada_activo where auto_jornada=@jornada"
                                xcmd.Parameters.AddWithValue("@jornada", xauto_jornada.Trim)
                                xobj = xcmd.ExecuteScalar()
                            End Using

                            If (xobj Is Nothing) Or (IsDBNull(xobj)) Then
                                RaiseEvent _OperadorAbierto("")
                                Return False
                            Else
                                RaiseEvent _OperadorAbierto(xobj.ToString)
                                Return True
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception("FAST FOOD" & vbCrLf & "FUNCION: VERIFICAR ESTATUS OPERADOR ACTIVO" & vbCrLf & ex.Message)
                End Try
            End Function

            Function F_CrearJornada(ByVal xjornada As AbrirJornada) As Boolean
                Try
                    Dim xjorn As New Jornada.c_Registro
                    Dim xjor_activa As New JornadaActiva.c_Registro

                    With xjorn
                        .c_AutoJornada._ContenidoCampo = ""
                        .c_AutoUsuarioApertura._ContenidoCampo = xjornada._Usuario._AutoUsuario
                        .c_AutoUsuarioCierre._ContenidoCampo = ""
                        .c_CodigoUsuarioApertura._ContenidoCampo = xjornada._Usuario._CodigoUsuario
                        .c_CodigoUsuarioCierre._ContenidoCampo = ""
                        .c_EstacionApertura._ContenidoCampo = xjornada._EstacionEquipo
                        .c_Estatus._ContenidoCampo = "0"
                        .c_FechaApertura._ContenidoCampo = F_GetDate("select getdate()")
                        .c_FechaCierre._ContenidoCampo = Nothing
                        .c_GrupoUsuarioApertura._ContenidoCampo = xjornada._Usuario._NombreGrupo
                        .c_GrupoUsuarioCierre._ContenidoCampo = ""
                        .c_HoraApertura._ContenidoCampo = F_GetDate("select getdate()").ToShortTimeString
                        .c_HoraCierre._ContenidoCampo = ""
                        .c_NombreUsuarioApertura._ContenidoCampo = xjornada._Usuario._NombreUsuario
                        .c_NombreUsuarioCierre._ContenidoCampo = ""
                        .c_SerialFiscal._ContenidoCampo = xjornada._SerialImpFiscal
                        .c_TotalDocumentos_NC._ContenidoCampo = 0
                        .c_TotalDocumentos_Ventas._ContenidoCampo = 0
                        .c_TotalNC._ContenidoCampo = 0
                        .c_TotalVentas._ContenidoCampo = 0
                    End With

                    With xjor_activa
                        .c_AutoJornada._ContenidoCampo = ""
                        .c_SerialFiscal._ContenidoCampo = IIf(xjornada._SerialImpFiscal = "", xjornada._Usuario._AutoUsuario, xjornada._SerialImpFiscal)
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Dim xsql_1 As String = "update contadores set a_jornada=a_jornada+1;select a_jornada from contadores"
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xobj As Object = Nothing
                                If xjorn._SerialFiscal <> "" Then
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from jornada where serialfiscal=@serial and fecha_apert=@fecha"
                                    xcmd.Parameters.AddWithValue("@SERIAL", xjorn._SerialFiscal)
                                    xcmd.Parameters.AddWithValue("@fecha", xjorn._FechaApertura)
                                    xobj = xcmd.ExecuteScalar()
                                    If (xobj Is Nothing) Or IsDBNull(xobj) Then
                                    Else
                                        Throw New Exception("NO PUEDES ABRIR UNA NUEVA JORNADA DEL DIA DE HOY PARA ESTA IMPRESORA FISCAL")
                                    End If
                                Else
                                    xjorn.c_SerialFiscal._ContenidoCampo = xjorn._AutoUsuarioApertura
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from jornada where serialfiscal=@serial and fecha_apert=@fecha"
                                    xcmd.Parameters.AddWithValue("@SERIAL", xjorn._SerialFiscal)
                                    xcmd.Parameters.AddWithValue("@fecha", xjorn._FechaApertura)
                                    xobj = xcmd.ExecuteScalar()
                                    If (xobj Is Nothing) Or IsDBNull(xobj) Then
                                    Else
                                        Throw New Exception("NO PUEDES ABRIR UNA NUEVA JORNADA DEL DIA DE HOY PARA ESTE USUARIO")
                                    End If
                                End If

                                xobj = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_jornada from contadores"
                                xobj = xcmd.ExecuteScalar()
                                If (xobj Is Nothing) Or IsDBNull(xobj) Then
                                    xcmd.CommandText = "update contadores set a_jornada=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_1
                                xjorn.c_AutoJornada._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                xjor_activa.c_AutoJornada._ContenidoCampo = xjorn.c_AutoJornada._ContenidoCampo

                                xcmd.CommandText = Jornada.INSERT_JORNADA
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_AutoJornada._NombreCampo, xjorn._AutoJornada).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_AutoUsuarioApertura._NombreCampo, xjorn._AutoUsuarioApertura).Size = xjorn.c_AutoUsuarioApertura._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_AutoUsuarioCierre._NombreCampo, xjorn._AutoUsuarioCierre).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_CodigoUsuarioApertura._NombreCampo, xjorn._CodigoUsuarioApertura).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_CodigoUsuarioCierre._NombreCampo, xjorn._CodigoUsuarioCierre).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_EstacionApertura._NombreCampo, xjorn._EstacionApertura).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_Estatus._NombreCampo, xjorn.c_Estatus._ContenidoCampo).Size = xjorn.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_FechaApertura._NombreCampo, xjorn._FechaApertura)
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_FechaCierre._NombreCampo, IIf(xjorn._FechaCierre = Date.MinValue, DBNull.Value, xjorn._FechaCierre))
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_GrupoUsuarioApertura._NombreCampo, xjorn._GrupoUsuarioApertura).Size = xjorn.c_GrupoUsuarioApertura._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_GrupoUsuarioCierre._NombreCampo, xjorn._GrupoUsuarioCierre).Size = xjorn.c_GrupoUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_HoraApertura._NombreCampo, xjorn._HoraApertura).Size = xjorn.c_HoraApertura._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_HoraCierre._NombreCampo, xjorn._HoraCierre).Size = xjorn.c_HoraCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_NombreUsuarioApertura._NombreCampo, xjorn._NombreUsuarioApertura).Size = xjorn.c_NombreUsuarioApertura._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_NombreUsuarioCierre._NombreCampo, xjorn._NombreUsuarioCierre).Size = xjorn.c_NombreUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_SerialFiscal._NombreCampo, xjorn._SerialFiscal).Size = xjorn.c_SerialFiscal._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_TotalDocumentos_NC._NombreCampo, xjorn._TotalDoc_NC)
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_TotalDocumentos_Ventas._NombreCampo, xjorn._TotalDoc_Ventas)
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_TotalNC._NombreCampo, xjorn._TotalNC)
                                xcmd.Parameters.AddWithValue("@" + xjorn.c_TotalVentas._NombreCampo, xjorn._TotalVentas)
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = JornadaActiva.INSERT_JORNADA_ACTIVA
                                xcmd.Parameters.AddWithValue("@" + xjor_activa.c_AutoJornada._NombreCampo, xjor_activa._AutoJornada).Size = xjor_activa.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xjor_activa.c_SerialFiscal._NombreCampo, xjor_activa._SerialFiscal).Size = xjor_activa.c_SerialFiscal._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _JornadaCreadaOk(xjorn._AutoJornada)

                            Return True
                        Catch EX2 As SqlException
                            xtr.Rollback()
                            If EX2.Number = 2601 Then
                                Throw New Exception("ERROR: AL CREAR JORNADA" + vbCrLf + "IMPRESORA FISCAL YA TIENE UNA JORNADA ABIERTA")
                            Else
                                Throw New Exception(EX2.Message + vbCrLf + EX2.Number.ToString)
                            End If
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception("INSERTAR NUEVA JORNADA" + vbCrLf + ex.Message + vbCrLf)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_CrearOperador(ByVal xoperador As OperadorCrear) As Boolean
                Try
                    Dim xop As New FastFood.OperadorJornada.c_Registro
                    Dim xop_activo As New FastFood.OperadorJornada_Activa.c_Registro

                    With xop
                        .c_AutoJornada._ContenidoCampo = xoperador._Jornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = ""
                        .c_AutoUsuario._ContenidoCampo = xoperador._Usuario._AutoUsuario
                        .c_AutoUsuarioCierre._ContenidoCampo = ""
                        .c_Estatus._ContenidoCampo = "0"
                        .c_Fechacierre._ContenidoCampo = Nothing
                        .c_FechaInicio._ContenidoCampo = xoperador._Fecha
                        .c_HoraCierre._ContenidoCampo = ""
                        .c_HoraInicio._ContenidoCampo = xoperador._Hora
                        .c_TotalDocumentos_NC._ContenidoCampo = 0
                        .c_TotalDocumentos_Ventas._ContenidoCampo = 0
                        .c_TotalDocumentos_VentasCredito._ContenidoCampo = 0
                        .c_TotalNC._ContenidoCampo = 0
                        .c_TotalVentas._ContenidoCampo = 0
                        .c_TotalVentasCredito._ContenidoCampo = 0
                        .c_UsuarioGrupo._ContenidoCampo = xoperador._Usuario._NombreGrupo
                        .c_UsuarioGrupoCierre._ContenidoCampo = ""
                        .c_UsuarioNombre._ContenidoCampo = xoperador._Usuario._NombreUsuario
                        .c_UsuarioNombreCierre._ContenidoCampo = ""
                    End With

                    With xop_activo
                        .c_AutoJornada._ContenidoCampo = xoperador._Jornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = ""
                        .c_AutoUsuario._ContenidoCampo = xoperador._Usuario._AutoUsuario
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Dim xsql_1 As String = "update contadores set a_operador=a_operador+1;select a_operador from contadores"
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                Dim xobj As Object = Nothing
                                xcmd.Parameters.Clear()
                                xcmd.CommandText = "select a_operador from contadores"
                                xobj = xcmd.ExecuteScalar()
                                If (xobj Is Nothing) Or IsDBNull(xobj) Then
                                    xcmd.CommandText = "update contadores set a_operador=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = xsql_1
                                xop.c_AutoOperador._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                xop_activo.c_AutoOperador._ContenidoCampo = xop.c_AutoOperador._ContenidoCampo

                                xcmd.CommandText = OperadorJornada.INSERT_OPERADORJORNADA
                                xcmd.Parameters.AddWithValue("@" + xop.c_AutoJornada._NombreCampo, xop._AutoJornada).Size = xop.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_AutoOperador._NombreCampo, xop._AutoOperador).Size = xop.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_AutoUsuario._NombreCampo, xop._AutoUsuario).Size = xop.c_AutoUsuario._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_AutoUsuarioCierre._NombreCampo, xop._AutoUsuarioCierre).Size = xop.c_AutoUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_Estatus._NombreCampo, xop.c_Estatus._ContenidoCampo).Size = xop.c_Estatus._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_Fechacierre._NombreCampo, IIf(xop._FechaCierre = Date.MinValue, DBNull.Value, xop._FechaCierre))
                                xcmd.Parameters.AddWithValue("@" + xop.c_FechaInicio._NombreCampo, xop._FechaInicio)
                                xcmd.Parameters.AddWithValue("@" + xop.c_HoraCierre._NombreCampo, xop._HoraCierre).Size = xop.c_HoraCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_HoraInicio._NombreCampo, xop._HoraInicio).Size = xop.c_HoraInicio._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_NC._NombreCampo, xop._TotalDocumentos_NC)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_Ventas._NombreCampo, xop._TotalDocumentos_Ventas)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_VentasCredito._NombreCampo, xop._TotalDocumentos_VentasCredito)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalNC._NombreCampo, xop._TotalNC)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalVentas._NombreCampo, xop._TotalVentas)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalVentasCredito._NombreCampo, xop._TotalVentasCredito)
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioGrupo._NombreCampo, xop._UsuarioGrupo).Size = xop.c_UsuarioGrupo._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioGrupoCierre._NombreCampo, xop._UsuarioGrupoCierre).Size = xop.c_UsuarioGrupoCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioNombre._NombreCampo, xop._UsuarioNombre).Size = xop.c_UsuarioNombre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioNombreCierre._NombreCampo, xop._UsuarioNombreCierre).Size = xop.c_UsuarioNombreCierre._LargoCampo
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = OperadorJornada_Activa.INSERT_OPERADORJORNADA_ACTIVO
                                xcmd.Parameters.AddWithValue("@" + xop_activo.c_AutoJornada._NombreCampo, xop_activo._AutoJornada).Size = xop_activo.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop_activo.c_AutoOperador._NombreCampo, xop_activo._AutoOperador).Size = xop_activo.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop_activo.c_AutoUsuario._NombreCampo, xop_activo._AutoUsuario).Size = xop_activo.c_AutoUsuario._LargoCampo
                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _OperadorCreado(xop._AutoOperador)

                            Return True
                        Catch EX2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(EX2.Message + vbCrLf + EX2.Number.ToString)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception("INSERTAR NUEVO OPERADOR" + vbCrLf + ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_CerrarOperador(ByVal xoperador As OperadorCerrar) As Boolean
                Try
                    Dim xop As New FastFood.OperadorJornada.c_Registro

                    With xop
                        .c_AutoJornada._ContenidoCampo = xoperador._Jornada._AutoJornada
                        .c_AutoOperador._ContenidoCampo = xoperador._Operador._AutoOperador
                        .c_AutoUsuarioCierre._ContenidoCampo = xoperador._Usuario._AutoUsuario
                        .c_Estatus._ContenidoCampo = "1"
                        .c_Fechacierre._ContenidoCampo = xoperador._Fecha
                        .c_HoraCierre._ContenidoCampo = xoperador._Hora
                        .c_TotalDocumentos_NC._ContenidoCampo = xoperador._TotalDocNC
                        .c_TotalDocumentos_Ventas._ContenidoCampo = xoperador._TotalDocVentas
                        .c_TotalDocumentos_VentasCredito._ContenidoCampo = xoperador._TotalDocVentasCredito
                        .c_TotalNC._ContenidoCampo = xoperador._TotalNC
                        .c_TotalVentas._ContenidoCampo = xoperador._TotalVentas
                        .c_TotalVentasCredito._ContenidoCampo = xoperador._TotalVentasCredito
                        .c_UsuarioGrupoCierre._ContenidoCampo = xoperador._Usuario._NombreGrupo
                        .c_UsuarioNombreCierre._ContenidoCampo = xoperador._Usuario._NombreUsuario
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = OperadorJornada.CERRAR_OPERADORJORNADA
                                xcmd.Parameters.AddWithValue("@" + xop.c_AutoUsuarioCierre._NombreCampo, xop._AutoUsuarioCierre).Size = xop.c_AutoUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_Estatus._NombreCampo, xop.c_Estatus._ContenidoCampo).Size = xop.c_Estatus._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_Fechacierre._NombreCampo, IIf(xop._FechaCierre = Date.MinValue, DBNull.Value, xop._FechaCierre))
                                xcmd.Parameters.AddWithValue("@" + xop.c_HoraCierre._NombreCampo, xop._HoraCierre).Size = xop.c_HoraCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_NC._NombreCampo, xop._TotalDocumentos_NC)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_Ventas._NombreCampo, xop._TotalDocumentos_Ventas)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalDocumentos_VentasCredito._NombreCampo, xop._TotalDocumentos_VentasCredito)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalNC._NombreCampo, xop._TotalNC)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalVentas._NombreCampo, xop._TotalVentas)
                                xcmd.Parameters.AddWithValue("@" + xop.c_TotalVentasCredito._NombreCampo, xop._TotalVentasCredito)
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioGrupoCierre._NombreCampo, xop._UsuarioGrupoCierre).Size = xop.c_UsuarioGrupoCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xop.c_UsuarioNombreCierre._NombreCampo, xop._UsuarioNombreCierre).Size = xop.c_UsuarioNombreCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@operador", xop._AutoOperador).Size = xop.c_AutoOperador._LargoCampo
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = OperadorJornada_Activa.ELIMINAR_OPERADORJORNADA_ACTIVO
                                xcmd.Parameters.AddWithValue("@operador", xop._AutoOperador).Size = xop.c_AutoOperador._LargoCampo
                                xcmd.Parameters.AddWithValue("@jornada", xop._AutoJornada).Size = xop.c_AutoJornada._LargoCampo

                                xcmd.ExecuteNonQuery()
                            End Using

                            xtr.Commit()
                            RaiseEvent _OperadorCerrado("")

                            Return True
                        Catch EX2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(EX2.Message + vbCrLf + EX2.Number.ToString)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception("CERRAR OPERADOR" + vbCrLf + ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_CerrarJornada(ByVal xjor As CerrarJornada) As Boolean
                Try
                    Dim xj As New FastFood.Jornada.c_Registro

                    With xj
                        .c_AutoUsuarioCierre._ContenidoCampo = xjor._Usuario._AutoUsuario
                        .c_CodigoUsuarioCierre._ContenidoCampo = xjor._Usuario._CodigoUsuario
                        .c_Estatus._ContenidoCampo = "1"
                        .c_FechaCierre._ContenidoCampo = xjor._Fecha
                        .c_GrupoUsuarioCierre._ContenidoCampo = xjor._Usuario._NombreGrupo
                        .c_HoraCierre._ContenidoCampo = xjor._Hora
                        .c_NombreUsuarioCierre._ContenidoCampo = xjor._Usuario._NombreUsuario
                        .c_TotalDocumentos_NC._ContenidoCampo = xjor._TotalDocNC
                        .c_TotalDocumentos_Ventas._ContenidoCampo = xjor._TotalDocVentas
                        .c_TotalNC._ContenidoCampo = xjor._TotalNC
                        .c_TotalVentas._ContenidoCampo = xjor._TotalVentas
                    End With

                    Dim xtr As SqlTransaction = Nothing
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction

                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.CommandText = Jornada.CERRAR_JORNADA
                                xcmd.Parameters.AddWithValue("@" + xj.c_AutoUsuarioCierre._NombreCampo, xj._AutoUsuarioCierre).Size = xj.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_CodigoUsuarioCierre._NombreCampo, xj._CodigoUsuarioCierre).Size = xj.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_Estatus._NombreCampo, xj.c_Estatus._ContenidoCampo).Size = xj.c_AutoJornada._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_FechaCierre._NombreCampo, IIf(xj._FechaCierre = Date.MinValue, DBNull.Value, xj._FechaCierre))
                                xcmd.Parameters.AddWithValue("@" + xj.c_GrupoUsuarioCierre._NombreCampo, xj._GrupoUsuarioCierre).Size = xj.c_GrupoUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_HoraCierre._NombreCampo, xj._HoraCierre).Size = xj.c_HoraCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_NombreUsuarioCierre._NombreCampo, xj._NombreUsuarioCierre).Size = xj.c_NombreUsuarioCierre._LargoCampo
                                xcmd.Parameters.AddWithValue("@" + xj.c_TotalDocumentos_NC._NombreCampo, xj._TotalDoc_NC)
                                xcmd.Parameters.AddWithValue("@" + xj.c_TotalDocumentos_Ventas._NombreCampo, xj._TotalDoc_Ventas)
                                xcmd.Parameters.AddWithValue("@" + xj.c_TotalNC._NombreCampo, xj._TotalNC)
                                xcmd.Parameters.AddWithValue("@" + xj.c_TotalVentas._NombreCampo, xj._TotalVentas)
                                xcmd.Parameters.AddWithValue("@jornada", xjor._Jornada._AutoJornada).Size = xj.c_AutoJornada._LargoCampo
                                xcmd.ExecuteNonQuery()

                                xcmd.Parameters.Clear()
                                xcmd.CommandText = Jornada.ELIMINAR_JORNADAACTIVA
                                xcmd.Parameters.AddWithValue("@jornada", xjor._Jornada._AutoJornada).Size = xj.c_AutoJornada._LargoCampo
                                xcmd.ExecuteNonQuery()

                                If xjor._PermitirMesasPedidosPendientes = False Then 'REINICIAR CONTEO DE NUMERO DE PEDIDOS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update contadores set a_rest_pedidos=0"
                                    xcmd.ExecuteNonQuery()
                                End If

                            End Using

                            xtr.Commit()
                            RaiseEvent _JornadaCerrada("")

                            Return True
                        Catch EX2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(EX2.Message + vbCrLf + EX2.Number.ToString)
                        Catch ex As Exception
                            xtr.Rollback()
                            Throw New Exception("CERRAR JORNADA" + vbCrLf + ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

        End Class

        Private xfichafastfood As FastFood

        Property f_FichaFastFood() As FastFood
            Get
                Return xfichafastfood
            End Get
            Set(ByVal value As FastFood)
                xfichafastfood = value
            End Set
        End Property
    End Class
End Namespace


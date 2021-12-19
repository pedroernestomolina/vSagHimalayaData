Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class Estacionamiento
            Event _FacturaGrabadaOk()
            Event _VisorCambioDar(ByVal xmonto As Decimal)

            Event _EntradaVehiculo()
            Event _LevantarBarraEntrada()
            Event _LevantarBarraSalida()
            Event _EntradaTarjetaEmpleado()
            Event _SalidaTarjetaEmpleado()

            Function F_EntradaVehiculo(ByVal xEntrada As Entradas_Salidas.AgregarEntradaVehiculo) As Boolean
                Try
                    Dim xregs As New Entradas_Salidas.c_Registro
                    With xregs
                        .c_Auto._ContenidoCampo = ""
                        .c_AutoDocVenta._ContenidoCampo = ""
                        .c_AutoJornadaEntrada._ContenidoCampo = xEntrada._Operador._AutoJornada
                        .c_AutoJornadaSalida._ContenidoCampo = ""
                        .c_AutoOperadorEntrada._ContenidoCampo = xEntrada._Operador._AutoOperador
                        .c_AutoOperadorSalida._ContenidoCampo = ""
                        .c_Codigo._ContenidoCampo = ""
                        .c_Estatus._ContenidoCampo = xEntrada._Estatus
                        .c_FechaEntrada._ContenidoCampo = xEntrada._Fecha
                        .c_FechaSalida._ContenidoCampo = DBNull.Value
                        .c_HoraEntrada._ContenidoCampo = xEntrada._Hora
                        .c_HoraSalida._ContenidoCampo = ""
                    End With

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                With xregs
                                    xcmd.CommandText = "select a_estacionamientos from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_estacionamientos=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_estacionamientos=a_estacionamientos+1;" & _
                                                       "select a_estacionamientos from contadores"
                                    .c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")
                                    .c_Codigo._ContenidoCampo = .c_Auto._ContenidoCampo.ToString.PadLeft(.c_Codigo._LargoCampo, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Entradas_Salidas.InsertarEntradaVehiculos
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Auto._NombreCampo, xregs._Auto).Size = xregs.c_Auto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Codigo._NombreCampo, xregs._Codigo).Size = xregs.c_Codigo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoDocVenta._NombreCampo, xregs._AutoDocVenta).Size = xregs.c_AutoDocVenta._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaEntrada._NombreCampo, xregs._AutoJornadaEntrada).Size = xregs.c_AutoJornadaEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaSalida._NombreCampo, xregs._AutoJornadaSalida).Size = xregs.c_AutoJornadaSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorEntrada._NombreCampo, xregs._AutoOperadorEntrada).Size = xregs.c_AutoOperadorEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorSalida._NombreCampo, xregs._AutoOperadorSalida).Size = xregs.c_AutoOperadorSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Estatus._NombreCampo, xregs.c_Estatus._ContenidoCampo).Size = xregs.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaEntrada._NombreCampo, xregs._FechaEntrada)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaSalida._NombreCampo, xregs.c_FechaSalida._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraEntrada._NombreCampo, xregs._HoraEntrada).Size = xregs.c_HoraEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraSalida._NombreCampo, xregs._HoraSalida).Size = xregs.c_HoraSalida._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End With

                                With xEntrada._Impresora
                                    Dim xtexto1 As String
                                    Dim xtexto2 As String
                                    Dim xtexto3 As String
                                    Dim xtexto As String
                                    xtexto1 = "Fecha: " + xregs._FechaEntrada.ToShortDateString + ", Hora: " + xregs._HoraEntrada
                                    xtexto1 = xtexto1.Trim.PadRight(.AnchoTextoNoFiscal, ".")
                                    xtexto2 = "Ticket #: " + xregs._Auto
                                    xtexto2 = xtexto2.Trim.PadRight(.AnchoTextoNoFiscal, ".")
                                    xtexto3 = "Operador: " + xEntrada._Operador._UsuarioNombre
                                    xtexto3 = xtexto3.Trim.PadRight(.AnchoTextoNoFiscal, ".")
                                    xtexto = xtexto1 + xtexto2 + xtexto3
                                    xtexto = xtexto.Trim.PadRight(.AnchoTextoNoFiscal * 6, ".")

                                    .Estatus()
                                    If .Ver_SerialImpresoraFiscal <> "" AndAlso xEntrada._Operador._FichaJornada._SerialFiscal = .Ver_SerialImpresoraFiscal Then
                                        .CodigoBarra(xregs._Codigo)
                                        .TextoDNF(xtexto)
                                    End If
                                End With

                            End Using
                            xtr.Commit()
                            RaiseEvent _EntradaVehiculo()
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(ex2.Message + " " + ex2.Number.ToString)
                        Catch ex1 As Exception
                            xtr.Rollback()
                            Throw New Exception(ex1.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_MovimientoBarra(ByVal xEntrada As ControlBarras.MovimientoBarra) As Boolean
                Try
                    Dim xregs As New ControlBarras.c_Registro
                    With xregs
                        .c_Auto._ContenidoCampo = ""
                        .c_AutoJornada._ContenidoCampo = xEntrada._Jornada
                        .c_AutoOperador._ContenidoCampo = xEntrada._Operador
                        .c_BarraTipoMovimiento._ContenidoCampo = xEntrada._Movimiento
                        .c_Fecha._ContenidoCampo = xEntrada._Fecha
                        .c_Hora._ContenidoCampo = xEntrada._Hora
                    End With

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                With xregs
                                    xcmd.CommandText = "select a_estacionamientos_barra from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_estacionamientos_barra=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_estacionamientos_barra =a_estacionamientos_barra+1;" & _
                                                       "select a_estacionamientos_barra from contadores"
                                    .c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = ControlBarras.InsertarControlBarra
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Auto._NombreCampo, xregs._Auto).Size = xregs.c_Auto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornada._NombreCampo, xregs._AutoJornada).Size = xregs.c_AutoJornada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperador._NombreCampo, xregs._AutoOperador).Size = xregs.c_AutoOperador._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_BarraTipoMovimiento._NombreCampo, xregs.c_BarraTipoMovimiento._ContenidoCampo).Size = xregs.c_BarraTipoMovimiento._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Fecha._NombreCampo, xregs._Fecha)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Hora._NombreCampo, xregs._Hora).Size = xregs.c_Hora._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End With
                            End Using
                            xtr.Commit()
                            If xEntrada._TipoMovimiento = EstatusEstacionamiento.Entrada Then
                                RaiseEvent _LevantarBarraEntrada()
                            Else
                                RaiseEvent _LevantarBarraSalida()
                            End If
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(ex2.Message + " " + ex2.Number.ToString)
                        Catch ex1 As Exception
                            xtr.Rollback()
                            Throw New Exception(ex1.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_EntradaTarjetaPersonal(ByVal xEntrada As Tarjetas_EntradaSalidas.EntradaTarjeta) As Boolean
                Try
                    Dim xregs As New Tarjetas_EntradaSalidas.c_Registro
                    With xregs
                        .c_Auto._ContenidoCampo = ""
                        .c_AutoJornadaEntrada._ContenidoCampo = xEntrada._Jornada
                        .c_AutoJornadaSalida._ContenidoCampo = ""
                        .c_AutoOperadorEntrada._ContenidoCampo = xEntrada._Operador
                        .c_AutoOperadorSalida._ContenidoCampo = ""
                        .c_Codigo._ContenidoCampo = xEntrada._CodigoTarjeta
                        .c_Estatus._ContenidoCampo = xEntrada._Movimiento
                        .c_FechaEntrada._ContenidoCampo = xEntrada._Fecha
                        .c_FechaSalida._ContenidoCampo = DBNull.Value
                        .c_HoraEntrada._ContenidoCampo = xEntrada._Hora
                        .c_HoraSalida._ContenidoCampo = ""
                    End With

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                With xregs
                                    xcmd.CommandText = "select a_estacionamientos_tarjetas from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.CommandText = "update contadores set a_estacionamientos_tarjetas=0"
                                        xcmd.ExecuteScalar()
                                    End If
                                    xcmd.CommandText = "update contadores set a_estacionamientos_tarjetas =a_estacionamientos_tarjetas+1;" & _
                                                       "select a_estacionamientos_tarjetas from contadores"
                                    .c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Tarjetas_EntradaSalidas.InsertarEntradaVehiculos
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Auto._NombreCampo, xregs._Auto).Size = xregs.c_Auto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Codigo._NombreCampo, xregs._Codigo).Size = xregs.c_Codigo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaEntrada._NombreCampo, xregs._AutoJornadaEntrada).Size = xregs.c_AutoJornadaEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaSalida._NombreCampo, xregs._AutoJornadaSalida).Size = xregs.c_AutoJornadaSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorEntrada._NombreCampo, xregs._AutoOperadorEntrada).Size = xregs.c_AutoOperadorEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorSalida._NombreCampo, xregs._AutoOperadorSalida).Size = xregs.c_AutoOperadorSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Estatus._NombreCampo, xregs.c_Estatus._ContenidoCampo).Size = xregs.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaEntrada._NombreCampo, xregs._FechaEntrada)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaSalida._NombreCampo, xregs.c_FechaSalida._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraEntrada._NombreCampo, xregs._HoraEntrada).Size = xregs.c_HoraEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraSalida._NombreCampo, xregs._HoraSalida).Size = xregs.c_HoraSalida._LargoCampo
                                    xcmd.ExecuteNonQuery()
                                End With
                            End Using
                            xtr.Commit()
                            RaiseEvent _LevantarBarraEntrada()
                            RaiseEvent _EntradaTarjetaEmpleado()

                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Select Case ex2.Number
                                Case 3609
                                    Throw New Exception("Esta Tarjeta Ya Fue Ingresada Y Aún No Ha Salido")
                                Case Else
                                    Throw New Exception(ex2.Message + " " + ex2.Number.ToString)
                            End Select
                        Catch ex1 As Exception
                            xtr.Rollback()
                            Throw New Exception(ex1.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_SalidaTarjetaPersonal(ByVal xEntrada As Tarjetas_EntradaSalidas.EntradaTarjeta) As Boolean
                Try
                    Dim xregs As New Tarjetas_EntradaSalidas.c_Registro
                    With xregs
                        .c_Auto._ContenidoCampo = ""
                        .c_AutoJornadaEntrada._ContenidoCampo = xEntrada._Jornada
                        .c_AutoJornadaSalida._ContenidoCampo = xEntrada._Jornada
                        .c_AutoOperadorEntrada._ContenidoCampo = xEntrada._Operador
                        .c_AutoOperadorSalida._ContenidoCampo = xEntrada._Operador
                        .c_Codigo._ContenidoCampo = xEntrada._CodigoTarjeta
                        .c_Estatus._ContenidoCampo = xEntrada._Movimiento
                        .c_FechaEntrada._ContenidoCampo = xEntrada._Fecha
                        .c_FechaSalida._ContenidoCampo = xEntrada._Fecha
                        .c_HoraEntrada._ContenidoCampo = xEntrada._Hora
                        .c_HoraSalida._ContenidoCampo = xEntrada._Hora
                    End With

                    Dim xtr As SqlTransaction
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        xtr = xcon.BeginTransaction
                        Try
                            Using xcmd As New SqlCommand("", xcon, xtr)
                                xcmd.Parameters.Clear()
                                With xregs

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Tarjetas_EntradaSalidas.ActualizarSalidaVehiculos
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Auto._NombreCampo, xregs._Auto).Size = xregs.c_Auto._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Codigo._NombreCampo, xregs._Codigo).Size = xregs.c_Codigo._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaEntrada._NombreCampo, xregs._AutoJornadaEntrada).Size = xregs.c_AutoJornadaEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoJornadaSalida._NombreCampo, xregs._AutoJornadaSalida).Size = xregs.c_AutoJornadaSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorEntrada._NombreCampo, xregs._AutoOperadorEntrada).Size = xregs.c_AutoOperadorEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_AutoOperadorSalida._NombreCampo, xregs._AutoOperadorSalida).Size = xregs.c_AutoOperadorSalida._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_Estatus._NombreCampo, xregs.c_Estatus._ContenidoCampo).Size = xregs.c_Estatus._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaEntrada._NombreCampo, xregs._FechaEntrada)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_FechaSalida._NombreCampo, xregs.c_FechaSalida._ContenidoCampo)
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraEntrada._NombreCampo, xregs._HoraEntrada).Size = xregs.c_HoraEntrada._LargoCampo
                                    xcmd.Parameters.AddWithValue("@" + xregs.c_HoraSalida._NombreCampo, xregs._HoraSalida).Size = xregs.c_HoraSalida._LargoCampo
                                    If xcmd.ExecuteNonQuery() = 0 Then
                                        Throw New Exception("LA TARJETA NO TIENE EL ESTATUS DE MOVIMIENTO DE ENTRADA")
                                    End If
                                End With
                            End Using
                            xtr.Commit()
                            RaiseEvent _LevantarBarraSalida()
                            RaiseEvent _SalidaTarjetaEmpleado()
                            Return True
                        Catch ex2 As SqlException
                            xtr.Rollback()
                            Throw New Exception(ex2.Message + " " + ex2.Number.ToString)
                        Catch ex1 As Exception
                            xtr.Rollback()
                            Throw New Exception(ex1.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            ''' <summary>
            ''' Indica Si Esta / No Registrado
            ''' </summary>
            ''' <param name="xcodigoTicket">Codigo Barra</param>
            Function F_BuscarTicketEstacionamiento(ByVal xcodigoTicket As String) As Entradas_Salidas.c_Registro
                Try
                    Dim xtb As New DataTable
                    Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                        xadap.SelectCommand.CommandText = "select * from estacionamiento_entradas_salidas where codigo=@auto"
                        xadap.SelectCommand.Parameters.AddWithValue("@auto", xcodigoTicket)
                        xadap.Fill(xtb)
                    End Using
                    If xtb.Rows.Count > 0 Then
                        Dim xficha As New Entradas_Salidas
                        xficha.Registro.CargarRegistro(xtb(0))
                        Return xficha.Registro
                    Else
                        Return Nothing
                    End If
                Catch ex As Exception
                    Return Nothing
                End Try
            End Function


            Public Class AgregarVenta
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
                    Private xserialfiscal As String

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
                            Return xrenglones
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

                    Property _SerialImpFiscal() As String
                        Get
                            Return xserialfiscal
                        End Get
                        Set(ByVal value As String)
                            xserialfiscal = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _FechaEmision() As Date
                        Get
                            Return F_GetDate("select getdate()").Date
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

                    ReadOnly Property _SaldoPendiente() As Decimal
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
                        Me._SerialImpFiscal = ""
                    End Sub
                End Class

                Private xencabezado As Encabezado
                Private xmontorecibe As Decimal
                Private xtablapagos As DataTable
                Private xticket_estacionamineto As Entradas_Salidas.c_Registro
                Private xticket_perdido As TicketsExtraviados.AgregarTicket
                Private xcostohora_neto As Decimal
                Private xcostoticketextraviado_neto As Decimal
                Private xcostohoraextra_neto As Decimal

                Property _CostoHoraNeto() As Decimal
                    Get
                        Return xcostohora_neto
                    End Get
                    Set(ByVal value As Decimal)
                        xcostohora_neto = value
                    End Set
                End Property

                Property _CostoHoraExtraNeto() As Decimal
                    Get
                        Return xcostohoraextra_neto
                    End Get
                    Set(ByVal value As Decimal)
                        xcostohoraextra_neto = value
                    End Set
                End Property

                Property _CostoTicketExtraviadoNeto() As Decimal
                    Get
                        Return xcostoticketextraviado_neto
                    End Get
                    Set(ByVal value As Decimal)
                        xcostoticketextraviado_neto = value
                    End Set
                End Property

                ReadOnly Property _CantidadHoras() As Integer
                    Get
                        Try
                            If _TicketEstacionamiento IsNot Nothing Then
                                Dim x As New Estacionamiento
                                Return x.F_TiempoTrancurrido(_TicketEstacionamiento._Auto)._TotalHoras
                            Else
                                Return 0
                            End If
                        Catch ex As Exception
                            Throw New Exception("CALCULO EN CANTIDAD DE HORAS" + vbCrLf + ex.Message)
                        End Try
                    End Get
                End Property

                ReadOnly Property _TipoSalidaVehiculo() As String
                    Get
                        If _TicketEstacionamiento IsNot Nothing Then
                            Return "0"
                        Else
                            Return "1"
                        End If
                    End Get
                End Property

                ReadOnly Property _AutoTicketEntrada() As String
                    Get
                        If _TicketEstacionamiento IsNot Nothing Then
                            Return _TicketEstacionamiento._Auto
                        Else
                            Return ""
                        End If
                    End Get
                End Property

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

                Property _Encabezado() As Encabezado
                    Get
                        Return xencabezado
                    End Get
                    Set(ByVal value As Encabezado)
                        xencabezado = value
                    End Set
                End Property

                Property _TicketEstacionamiento() As Entradas_Salidas.c_Registro
                    Get
                        Return xticket_estacionamineto
                    End Get
                    Set(ByVal value As Entradas_Salidas.c_Registro)
                        xticket_estacionamineto = value
                    End Set
                End Property

                Property _TicketPerdido() As TicketsExtraviados.AgregarTicket
                    Get
                        Return xticket_perdido
                    End Get
                    Set(ByVal value As TicketsExtraviados.AgregarTicket)
                        xticket_perdido = value
                    End Set
                End Property

                Sub New()
                    Me._Encabezado = New Encabezado
                    Me._MontoRecibido = 0
                    Me._TablaModosPago = New DataTable
                    Me._TicketEstacionamiento = Nothing
                    Me._TicketPerdido = Nothing
                    Me._CostoHoraNeto = 0
                    Me._CostoTicketExtraviadoNeto = 0
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

            Function F_GrabarVenta(ByVal xventa As AgregarVenta, ByVal impfiscal As IFiscal) As Boolean
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
                    Using xadap As New SqlDataAdapter("select * from series_fiscales where nombre=@nombre", _MiCadenaConexion)
                        xadap.SelectCommand.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                        xadap.Fill(xtb)
                    End Using
                    If xtb.Rows.Count > 0 Then
                        xfiscal.M_CargarFicha(xtb(0))
                    Else
                        Throw New Exception("ERROR... SERIE NO REGISTRADA, VERIFIQUE")
                    End If

                    If xfiscal.RegistroDato.r_EstatusSerie = TipoEstatus.Activo Then
                        If xfiscal.RegistroDato.r_EstatusParaVentas = TipoEstatus.Inactivo Then
                            Throw New Exception("ERROR... SERIE NO ASIGNADA PARA EFECTUAR VENTAS, VERIFIQUE")
                        End If
                    Else
                        Throw New Exception("ERROR... SERIE ESTA EN ESTADO INACTVIO, VERIFIQUE")
                    End If

                    Dim xtb_venta As New FichaVentas.V_Ventas.c_Registro
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
                        .c_SerialImpresoraFiscal.c_Texto = xventa._Encabezado._SerialImpFiscal
                        .c_SerialUnico_Jornada.c_Texto = ""
                        .c_SerieAsignada.c_Texto = xventa._Encabezado._Serie
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

                                If xventa._Encabezado._TotalGeneral = 0 Then
                                    If xventa._TicketEstacionamiento IsNot Nothing Then
                                        Dim xsalida As New Entradas_Salidas.SalidaVehiculo
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update estacionamiento_entradas_salidas set estatus=@estatus, hora_salida=@hora, fecha_salida=@fecha, " & _
                                        "auto_operador_salida=@operador, auto_jornada_salida=@jornada, auto_doc_venta=@venta where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@estatus", xsalida._Estatus)
                                        xcmd.Parameters.AddWithValue("@hora", xsalida._Hora)
                                        xcmd.Parameters.AddWithValue("@fecha", xsalida._Fecha)
                                        xcmd.Parameters.AddWithValue("@operador", xventa._Encabezado._Operador)
                                        xcmd.Parameters.AddWithValue("@jornada", xventa._Encabezado._Jornada)
                                        xcmd.Parameters.AddWithValue("@venta", "")
                                        xcmd.Parameters.AddWithValue("@auto", xventa._TicketEstacionamiento._Auto)
                                        xcmd.ExecuteNonQuery()
                                    Else
                                        Throw New Exception("PROBLEMA AL PROCESAR TICKET DE ESTACIONAMIENTO")
                                    End If
                                Else

                                    'ACTUALIZO CONTADOR AUTOMATICO DE VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_1
                                    xtb_venta.c_AutoDocumento.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'ACTUALIZA CONTADOR AUTOMATICO CXC
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_2
                                    autocxc = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    'ACTUALIZA CORRELATIVO DE SERIES FISCALES
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql_3
                                    xcmd.Parameters.AddWithValue("@nombre", xventa._Encabezado._Serie)
                                    xtb_venta.c_Documento.c_Texto = xventa._Encabezado._Serie + _
                                                     xcmd.ExecuteScalar().ToString.Trim.PadLeft(10 - xventa._Encabezado._Serie.Length, "0")

                                    'VENTAS
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = FichaVentas.INSERT_VENTAS_ESTACIONAMIENTO
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
                                    xcmd.Parameters.AddWithValue("@rest_servicio_tasa", xtb_venta.c_Rest_ServicioTasa.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_servicio_monto", xtb_venta.c_Rest_ServicioMonto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@rest_modo_mesapedido", xtb_venta.c_Rest_ModoMesaPedido.c_Texto).Size = xtb_venta.c_Rest_ModoMesaPedido.c_Largo
                                    xcmd.Parameters.AddWithValue("@descuento_por_prontopago", xtb_venta.c_DescuentoPorProntoPago.c_Valor)
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

                                    Dim xdetalle As New Estacionamiento.VentasDetalle
                                    With xdetalle
                                        .Registro.c_AutoCliente._ContenidoCampo = xventa._Encabezado._Cliente.r_Automatico
                                        .Registro.c_AutoDocumento._ContenidoCampo = xtb_venta.c_AutoDocumento.c_Texto
                                        .Registro.c_AutoItem._ContenidoCampo = "0000000001"
                                        .Registro.c_AutoItemOrigen._ContenidoCampo = ""
                                        .Registro.c_AutoJornada._ContenidoCampo = xventa._Encabezado._Jornada
                                        .Registro.c_AutoOperador._ContenidoCampo = xventa._Encabezado._Operador
                                        .Registro.c_AutoTicketEntrada._ContenidoCampo = xventa._AutoTicketEntrada
                                        .Registro.c_TipoSalidaVehiculo._ContenidoCampo = xventa._TipoSalidaVehiculo
                                        .Registro.c_CantidadHoras._ContenidoCampo = xventa._CantidadHoras
                                        .Registro.c_Cantidad._ContenidoCampo = 1
                                        .Registro.c_CostoHoraNeto._ContenidoCampo = xventa._CostoHoraNeto
                                        .Registro.c_CostoHoraExtraNeto._ContenidoCampo = xventa._CostoHoraExtraNeto
                                        .Registro.c_CostoTicketExtraviado._ContenidoCampo = xventa._CostoTicketExtraviadoNeto
                                        .Registro.c_Estatus._ContenidoCampo = "0"
                                        .Registro.c_FechaEmision._ContenidoCampo = xtb_venta._FechaEmision
                                        .Registro.c_HoraSalida._ContenidoCampo = xtb_venta._HoraDocumento
                                        .Registro.c_MontoIva._ContenidoCampo = xtb_venta._MontoTotalImpuesto
                                        .Registro.c_Nombre._ContenidoCampo = "SERVICIO DE ESTACIONAMIENTO"
                                        .Registro.c_NotasItem._ContenidoCampo = ""
                                        .Registro.c_PrecioNeto._ContenidoCampo = xtb_venta._MontoBase_1
                                        .Registro.c_SignoDocumento._ContenidoCampo = 1
                                        .Registro.c_TasaIva._ContenidoCampo = xtb_venta._TasaIva_1
                                        .Registro.c_TipoDocumento._ContenidoCampo = "01"
                                        .Registro.c_TipoMovimiento._ContenidoCampo = "V"
                                        .Registro.c_TipoTasaIva._ContenidoCampo = "1"
                                        .Registro.c_TotalGeneral._ContenidoCampo = xtb_venta._TotalGenereal
                                        .Registro.c_TotalNeto._ContenidoCampo = xtb_venta._MontoBase_1
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = VentasDetalle.Insert
                                    With xdetalle.Registro
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoCliente._NombreCampo, ._AutoCliente).Size = .c_AutoCliente._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoDocumento._NombreCampo, ._AutoDocumento).Size = .c_AutoDocumento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoItem._NombreCampo, ._AutoItem).Size = .c_AutoItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoItemOrigen._NombreCampo, ._AutoItemOrigen).Size = .c_AutoItemOrigen._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoJornada._NombreCampo, ._AutoJornada).Size = .c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoOperador._NombreCampo, ._AutoOperador).Size = .c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_AutoTicketEntrada._NombreCampo, ._AutoTicketEntrada).Size = .c_AutoTicketEntrada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_Cantidad._NombreCampo, ._Cantidad)
                                        xcmd.Parameters.AddWithValue("@" + .c_CantidadHoras._NombreCampo, ._CantidadHoras)
                                        xcmd.Parameters.AddWithValue("@" + .c_CostoHoraNeto._NombreCampo, ._CostoHoraNeto._Base)
                                        xcmd.Parameters.AddWithValue("@" + .c_CostoHoraExtraNeto._NombreCampo, ._CostoHoraExtraNeto._Base)
                                        xcmd.Parameters.AddWithValue("@" + .c_CostoTicketExtraviado._NombreCampo, ._CostoTicketExtraviado._Base)
                                        xcmd.Parameters.AddWithValue("@" + .c_Estatus._NombreCampo, .c_Estatus._ContenidoCampo).Size = .c_Estatus._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_FechaEmision._NombreCampo, ._FechaEmision)
                                        xcmd.Parameters.AddWithValue("@" + .c_HoraSalida._NombreCampo, ._HoraSalida).Size = .c_HoraSalida._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_MontoIva._NombreCampo, ._MontoIva)
                                        xcmd.Parameters.AddWithValue("@" + .c_Nombre._NombreCampo, ._Nombre).Size = .c_Nombre._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_NotasItem._NombreCampo, ._NotasItem).Size = .c_NotasItem._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_PrecioNeto._NombreCampo, ._PrecioNeto._Base)
                                        xcmd.Parameters.AddWithValue("@" + .c_SignoDocumento._NombreCampo, ._SignoDocumento)
                                        xcmd.Parameters.AddWithValue("@" + .c_TasaIva._NombreCampo, ._TasaIva)
                                        xcmd.Parameters.AddWithValue("@" + .c_TipoDocumento._NombreCampo, .c_TipoDocumento._ContenidoCampo).Size = .c_TipoDocumento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_TipoMovimiento._NombreCampo, .c_TipoMovimiento._ContenidoCampo).Size = .c_TipoMovimiento._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_TipoSalidaVehiculo._NombreCampo, .c_TipoSalidaVehiculo._ContenidoCampo).Size = .c_TipoSalidaVehiculo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_TipoTasaIva._NombreCampo, .c_TipoTasaIva._ContenidoCampo).Size = .c_TipoTasaIva._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + .c_TotalGeneral._NombreCampo, ._TotalGeneral)
                                        xcmd.Parameters.AddWithValue("@" + .c_TotalNeto._NombreCampo, ._TotalNeto)
                                    End With
                                    xcmd.ExecuteNonQuery()


                                    'CARGAR REGISTRO DE PRODUCTO A IMPRRIMIR EN IMP FISCAL
                                    Dim dr As DataRow = xtablaprd.NewRow
                                    dr("cantidad") = 1
                                    dr("nombre") = "SERVICIO ESTACIONAMIENTO"
                                    dr("codigo") = ""
                                    dr("precio_neto") = xtb_venta.c_Base1.c_Valor
                                    dr("codigo_tasa") = "1"
                                    xtablaprd.Rows.Add(dr)


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
                                        Throw New Exception("VERIFICAR CLIENTE, AL PARECER FUE ELIMINADO / CAMBIO DE ESTATUS")
                                    End If


                                    '' TICKET ESTACIONAMINETO
                                    If xventa._TicketEstacionamiento IsNot Nothing Then
                                        Dim xsalida As New Entradas_Salidas.SalidaVehiculo
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update estacionamiento_entradas_salidas set estatus=@estatus, hora_salida=@hora, fecha_salida=@fecha, " & _
                                        "auto_operador_salida=@operador, auto_jornada_salida=@jornada, auto_doc_venta=@venta where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@estatus", xsalida._Estatus)
                                        xcmd.Parameters.AddWithValue("@hora", xsalida._Hora)
                                        xcmd.Parameters.AddWithValue("@fecha", xsalida._Fecha)
                                        xcmd.Parameters.AddWithValue("@operador", xventa._Encabezado._Operador)
                                        xcmd.Parameters.AddWithValue("@jornada", xventa._Encabezado._Jornada)
                                        xcmd.Parameters.AddWithValue("@venta", xtb_venta._AutoDocumento)
                                        xcmd.Parameters.AddWithValue("@auto", xventa._TicketEstacionamiento._Auto)
                                        xcmd.ExecuteNonQuery()
                                    Else
                                        '' TICKET EXTRAVIADO
                                        Dim datosvehivulo As New Estacionamiento.TicketsExtraviados.c_Registro
                                        With datosvehivulo
                                            .c_AutoDocVenta._ContenidoCampo = xtb_venta._AutoDocumento
                                            .c_AutoJornada._ContenidoCampo = xventa._TicketPerdido._AutoJornada
                                            .c_AutoOperador._ContenidoCampo = xventa._TicketPerdido._AutoOperador
                                            .c_Cedula._ContenidoCampo = xventa._TicketPerdido._Cedula
                                            .c_ChoferVehiculo._ContenidoCampo = xventa._TicketPerdido._ChoferVehiculo
                                            .c_Fecha._ContenidoCampo = xventa._TicketPerdido._Fecha
                                            .c_Hora._ContenidoCampo = xventa._TicketPerdido._Hora
                                            .c_ModeloVehiculo._ContenidoCampo = xventa._TicketPerdido._ModeloVehiculo
                                            .c_PlacaVehiculo._ContenidoCampo = xventa._TicketPerdido._PlacaVehiculo
                                        End With

                                        xcmd.CommandText = "select a_estacionamientos_tickets_perdido from contadores"
                                        If IsDBNull(xcmd.ExecuteScalar()) Then
                                            xcmd.CommandText = "update contadores set a_estacionamientos_tickets_perdido=0"
                                            xcmd.ExecuteScalar()
                                        End If
                                        xcmd.CommandText = "update contadores set a_estacionamientos_tickets_perdido=a_estacionamientos_tickets_perdido+1;" & _
                                                           "select a_estacionamientos_tickets_perdido from contadores"
                                        datosvehivulo.c_Auto._ContenidoCampo = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = Estacionamiento.TicketsExtraviados.Insert
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_Auto._NombreCampo, datosvehivulo._Auto).Size = datosvehivulo.c_Auto._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_AutoDocVenta._NombreCampo, datosvehivulo._AutoDocVenta).Size = datosvehivulo.c_AutoDocVenta._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_AutoJornada._NombreCampo, datosvehivulo._AutoJornada).Size = datosvehivulo.c_AutoJornada._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_AutoOperador._NombreCampo, datosvehivulo._AutoOperador).Size = datosvehivulo.c_AutoOperador._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_Cedula._NombreCampo, datosvehivulo._Cedula).Size = datosvehivulo.c_Cedula._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_ChoferVehiculo._NombreCampo, datosvehivulo._ChoferVehiculo).Size = datosvehivulo.c_ChoferVehiculo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_Fecha._NombreCampo, datosvehivulo._Fecha)
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_Hora._NombreCampo, datosvehivulo._Hora).Size = datosvehivulo.c_Hora._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_ModeloVehiculo._NombreCampo, datosvehivulo._ModeloVehiculo).Size = datosvehivulo.c_ModeloVehiculo._LargoCampo
                                        xcmd.Parameters.AddWithValue("@" + datosvehivulo.c_PlacaVehiculo._NombreCampo, datosvehivulo._PlacaVehiculo).Size = datosvehivulo.c_PlacaVehiculo._LargoCampo
                                        xcmd.ExecuteNonQuery()
                                    End If


                                    Dim xcontrol As Integer = 0
                                    Integer.TryParse(impfiscal.Ver_UltimaFacturaRegistrada, xcontrol)
                                    xcontrol += 1
                                    Dim xcont As String = xcontrol.ToString.Trim.PadLeft(10, "0")

                                    'VENTAS. PARA ACTUALIZAR EL # DE CONTROL  DEL DOCUMENTO
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "update ventas set control = @control where auto = @auto"
                                    xcmd.Parameters.AddWithValue("@auto", xtb_venta.c_AutoDocumento.c_Texto).Size = xtb_venta.c_AutoDocumento.c_Largo
                                    xcmd.Parameters.AddWithValue("@control", xcont).Size = xtb_venta.c_ControlFiscal.c_Largo
                                    xcmd.ExecuteNonQuery()

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

                                        .CargoGlobal = xtb_venta.c_TasaCargos.c_Valor
                                        .DsctoGlobal = xtb_venta.c_TasaDescuento_1.c_Valor
                                    End With

                                    Dim xmontorecibe As Decimal = 0
                                    If xventa._Encabezado._CondicionPago = AgregarVenta.Encabezado.TipoCondicionPago.Contado Then
                                        xmontorecibe = xventa._Encabezado._TotalGeneral
                                    End If
                                    If xventa._Encabezado._TotalGeneral > 0 Then
                                        ImprimeFactura(impfiscal, xtablaprd, xmontorecibe, xventa._Encabezado._TotalGeneral)
                                    Else
                                        Throw New Exception("NO SE PUEDE GENERAR UNA FACTURA FISCAL DE MONTO CERO (0)")
                                    End If
                                End If

                                xtr.Commit()
                            End Using
                            Dim xr As Decimal = xventa._MontoRecibido - xtb_venta._TotalGenereal

                            RaiseEvent _LevantarBarraSalida()
                            RaiseEvent _FacturaGrabadaOk()
                            RaiseEvent _VisorCambioDar(xr)

                            Return True
                        Catch xsql As SqlException
                            xtr.Rollback()
                            If xsql.Number = 2601 Then
                                Throw New Exception("ERROR... YA EXISTE UN DOCUMENTO CON EL MISMO NUMERO Y SERIE, VERIFIQUE")
                            ElseIf xsql.Number = 547 Then
                                Throw New Exception("ERROR... AL PARECER EL CLIENTE / VENDEDOR SELECCIONADO FUE ELIMINADO POR OTRO USUARIO, VERIFIQUE")
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

            Function ImprimeFactura(ByVal xfiscal As IFiscal, ByVal xtablaprd As DataTable, ByVal xmonto_recibe As Decimal, ByVal xtotalfactura As Decimal) As Boolean
                Try
                    xfiscal.FacturaEncabezado()

                    For Each dr As DataRow In xtablaprd.Rows
                        xfiscal.LimpiarItem()
                        xfiscal.Prd_CantidadPrd = dr("cantidad")
                        xfiscal.Prd_DetallePrd = dr("nombre")
                        xfiscal.Prd_PNetoPrd = dr("precio_neto")
                        xfiscal.Prd_TasaIvaPrd = dr("codigo_tasa")
                        xfiscal.FacturaDetalle()
                    Next

                    If xmonto_recibe >= xtotalfactura Then
                        xfiscal.MedioPago_1 = xtotalfactura
                    Else
                        xfiscal.MedioPago_7 = xtotalfactura
                    End If

                    xfiscal.FacturaCerrar()
                    Return True
                Catch ex As Exception
                    Throw New Exception("ERROR AL IMPRIMIR FACTURA FISCAL:" + vbCrLf + "MOTIVO:" + vbCrLf + ex.Message + vbCrLf)
                End Try
            End Function

        End Class
    End Class
End Namespace

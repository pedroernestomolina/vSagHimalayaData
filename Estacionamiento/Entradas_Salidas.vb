Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema

        Partial Public Class Estacionamiento
            Enum TipoSalidaVehiculo
                Ticket = 1
                TicketExtarviado = 2
            End Enum

            Enum EstatusEstacionamiento
                Entrada = 0
                Salida = 1
            End Enum

            Public Class Tiempo
                Private xdias As Integer
                Private xhoras As Integer
                Private xminutos As Integer

                Property _Dias() As Integer
                    Get
                        Return xdias
                    End Get
                    Protected Friend Set(ByVal value As Integer)
                        xdias = value
                    End Set
                End Property

                Property _Horas() As Integer
                    Get
                        Return xhoras
                    End Get
                    Protected Friend Set(ByVal value As Integer)
                        xhoras = value
                    End Set
                End Property

                Property _Minutos() As Integer
                    Get
                        Return xminutos
                    End Get
                    Protected Friend Set(ByVal value As Integer)
                        xminutos = value
                    End Set
                End Property

                ReadOnly Property _TotalHoras() As Integer
                    Get
                        Dim x As Integer
                        x = _Dias * 24 + _Horas + IIf(_Minutos > 0, 1, 0)
                        Return x
                    End Get
                End Property

                Sub _Limpiar()
                    Me._Dias = 0
                    Me._Horas = 0
                    Me._Minutos = 0
                End Sub

                Sub New()
                    _Limpiar()
                End Sub
            End Class

            Public Class Entradas_Salidas
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_Codigo As CampoDato
                    '********entrada*******
                    Private f_hora_entrada As CampoDato
                    Private f_fecha_entrada As CampoDato
                    Private f_Auto_Operador_Entrada As CampoDato
                    Private f_Auto_Jornada_Entrada As CampoDato
                    '**********salida******
                    Private f_hora_salida As CampoDato
                    Private f_fecha_salida As CampoDato
                    Private f_Auto_Operador_Salida As CampoDato
                    Private f_Auto_Jornada_Salida As CampoDato
                    Private f_Estatus As CampoDato
                    '*******facturacion******
                    Private f_auto_doc_venta As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Codigo() As CampoDato
                        Get
                            Return f_Codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Codigo = value
                        End Set
                    End Property

                    ReadOnly Property _Codigo() As String
                        Get
                            Dim xv As String = IIf(Me.f_Codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_Codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_HoraEntrada() As CampoDato
                        Get
                            Return Me.f_hora_entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _HoraEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaEntrada() As CampoDato
                        Get
                            Return Me.f_fecha_entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEntrada() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_entrada._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_entrada._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_AutoOperadorEntrada() As CampoDato
                        Get
                            Return Me.f_Auto_Operador_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador Entrada
                    ''' </summary>
                    ReadOnly Property _f_AutoOperadorEntrada() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(xv)
                                    Return xoperador.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornadaEntrada() As CampoDato
                        Get
                            Return Me.f_Auto_Jornada_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Jornada_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada Entrada
                    ''' </summary>
                    ReadOnly Property _f_AutoJornadaEntrada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(xv)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_HoraSalida() As CampoDato
                        Get
                            Return Me.f_hora_salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora_salida = value
                        End Set
                    End Property

                    ReadOnly Property _HoraSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_salida._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaSalida() As CampoDato
                        Get
                            Return Me.f_fecha_salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha_salida = value
                        End Set
                    End Property

                    ReadOnly Property _FechaSalida() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_salida._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_salida._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_AutoOperadorSalida() As CampoDato
                        Get
                            Return Me.f_Auto_Operador_Salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador_Salida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador Salida
                    ''' </summary>
                    ReadOnly Property _f_AutoOperadorSalida() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Operador_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Salida._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(xv)
                                    Return xoperador.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornadaSalida() As CampoDato
                        Get
                            Return f_Auto_Jornada_Salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Auto_Jornada_Salida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada Salida
                    ''' </summary>
                    ReadOnly Property _f_AutoJornadaSalida() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Jornada_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Salida._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(xv)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_Estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As EstatusEstacionamiento
                        Get
                            Dim xv As String = IIf(Me.f_Estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_Estatus._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "0" Then
                                Return EstatusEstacionamiento.Entrada
                            Else
                                Return EstatusEstacionamiento.Salida
                            End If
                        End Get
                    End Property

                    Property c_AutoDocVenta() As CampoDato
                        Get
                            Return f_auto_doc_venta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_doc_venta = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocVenta() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc_venta._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_venta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Documento De Venta
                    ''' </summary>
                    ReadOnly Property _f_AutoDocVenta() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_auto_doc_venta._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_venta._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xventa As New FichaVentas.V_Ventas
                                    xventa.F_BuscarDocumento(xv)
                                    Return xventa.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase ENTRADA - SALIDA ESTACIONAMIENTO" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Codigo = New CampoDato("codigo", 11)
                        Me.c_HoraEntrada = New CampoDato("Hora_Entrada", 10)
                        Me.c_FechaEntrada = New CampoDato("Fecha_entrada")
                        Me.c_AutoOperadorEntrada = New CampoDato("auto_operador_entrada", 10)
                        Me.c_AutoJornadaEntrada = New CampoDato("auto_jornada_entrada", 10)
                        Me.c_HoraSalida = New CampoDato("Hora_Salida", 10)
                        Me.c_FechaSalida = New CampoDato("Fecha_Salida")
                        Me.c_AutoOperadorSalida = New CampoDato("auto_operador_Salida", 10)
                        Me.c_AutoJornadaSalida = New CampoDato("auto_jornada_Salida", 10)
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_AutoDocVenta = New CampoDato("auto_doc_venta", 10)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoDocVenta._ContenidoCampo = xrow(.c_AutoDocVenta._NombreCampo)
                                .c_AutoJornadaEntrada._ContenidoCampo = xrow(.c_AutoJornadaEntrada._NombreCampo)
                                .c_AutoJornadaSalida._ContenidoCampo = xrow(.c_AutoJornadaSalida._NombreCampo)
                                .c_AutoOperadorEntrada._ContenidoCampo = xrow(.c_AutoOperadorEntrada._NombreCampo)
                                .c_AutoOperadorSalida._ContenidoCampo = xrow(.c_AutoOperadorSalida._NombreCampo)
                                .c_Codigo._ContenidoCampo = xrow(.c_Codigo._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_FechaEntrada._ContenidoCampo = xrow(.c_FechaEntrada._NombreCampo)
                                If Not IsDBNull(xrow(.c_FechaSalida._NombreCampo)) Then
                                    .c_FechaSalida._ContenidoCampo = xrow(.c_FechaSalida._NombreCampo)
                                End If
                                .c_HoraEntrada._ContenidoCampo = xrow(.c_HoraEntrada._NombreCampo)
                                .c_HoraSalida._ContenidoCampo = xrow(.c_HoraSalida._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("ENTRADA - SALIDA ESTACIONAMIENTO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class
                Class AgregarEntradaVehiculo
                    Private xOperador As FastFood.OperadorJornada.c_Registro
                    Private xfiscal As IFiscal

                    ''' <summary>
                    ''' Ficha Operador
                    ''' </summary>
                    Property _Operador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Return xOperador
                        End Get
                        Set(ByVal value As FastFood.OperadorJornada.c_Registro)
                            xOperador = value
                        End Set
                    End Property

                    Property _Impresora() As IFiscal
                        Get
                            Return xfiscal
                        End Get
                        Set(ByVal value As IFiscal)
                            xfiscal = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return DataSistema.F_GetDate("Select getdate()")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return DataSistema.F_GetDate("Select getdate()").ToShortTimeString
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Estatus() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Sub New()
                        Me._Operador = Nothing
                        Me._Impresora = Nothing
                    End Sub
                End Class
                Class SalidaVehiculo
                    ReadOnly Property _Estatus() As String
                        Get
                            Return "1"
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("select getdate()").ToShortTimeString
                        End Get
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("select getdate()").ToShortDateString
                        End Get
                    End Property
                End Class

                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub

                Function F_BuscarCargar(ByVal xauto As String) As Boolean
                    Try
                        Dim xr As Integer
                        Dim xtb As New DataTable

                        Using xadap As New SqlDataAdapter("select * from estacionamiento_entradas_salidas where auto=@auto", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xr = xadap.Fill(xtb)
                        End Using
                        If xr = 0 Then
                            Throw New Exception("TICKET DE ENTRADA AL ESTACIONAMIENTO NO ENCONTRADO")
                        Else
                            Me.Registro.CargarRegistro(xtb(0))
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("BUSCAR TICKET ESTACIONAMIENTO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Protected Friend Const InsertarEntradaVehiculos As String = "insert into estacionamiento_entradas_salidas " & _
                "(auto,codigo,hora_entrada,fecha_entrada,auto_operador_entrada,auto_jornada_entrada,estatus," & _
                "hora_salida,fecha_salida,auto_operador_salida,auto_jornada_salida,auto_doc_venta) " & _
                "values (@auto,@codigo,@hora_entrada,@fecha_entrada,@auto_operador_entrada,@auto_jornada_entrada,@estatus," & _
                "@hora_salida,@fecha_salida,@auto_operador_salida,@auto_jornada_salida,@auto_doc_venta)"
            End Class

            Public Class Tarifas
                Event _ProcesoRealizado()

                Class c_Registro
                    Private f_tarifahora As CampoDato
                    Private f_tarifaHoraExtra As CampoDato
                    Private f_tarifaExtraviado As CampoDato
                    Private f_Id_Seguridad As Byte()

                    Property c_TarifaHora() As CampoDato
                        Get
                            Return f_tarifahora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tarifahora = value
                        End Set
                    End Property

                    ReadOnly Property _TarifaHora() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tarifahora._ContenidoCampo Is Nothing, 0, Me.f_tarifahora._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TarifaHoraExtra() As CampoDato
                        Get
                            Return f_tarifaHoraExtra
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tarifaHoraExtra = value
                        End Set
                    End Property

                    ReadOnly Property _TarifaHoraExtra() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tarifaHoraExtra._ContenidoCampo Is Nothing, 0, Me.f_tarifaHoraExtra._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_TarifaExtraviado() As CampoDato
                        Get
                            Return Me.f_tarifaExtraviado
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_tarifaExtraviado = value
                        End Set
                    End Property

                    ReadOnly Property _TarifaExtraviado() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tarifaExtraviado._ContenidoCampo Is Nothing, 0, Me.f_tarifaExtraviado._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return Me.f_Id_Seguridad
                        End Get
                        Set(ByVal value As Byte())
                            Me.f_Id_Seguridad = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return f_Id_Seguridad
                        End Get
                    End Property

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TARIFAS ESTACIONAMIENTO" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_TarifaExtraviado = New CampoDato("tarifaextraviado")
                        Me.c_TarifaHora = New CampoDato("tarifahora")
                        Me.c_TarifaHoraExtra = New CampoDato("tarifahoraextra")

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_TarifaExtraviado._ContenidoCampo = xrow(.c_TarifaExtraviado._NombreCampo)
                                .c_TarifaHora._ContenidoCampo = xrow(.c_TarifaHora._NombreCampo)
                                .c_TarifaHoraExtra._ContenidoCampo = xrow(.c_TarifaHoraExtra._NombreCampo)
                                .c_IdSeguridad = xrow("ID_SEGURIDAD")
                            End With
                        Catch ex As Exception
                            Throw New Exception("TARIFA ESTACIONAMIENTO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class
                Class ActualizarTarifas
                    Private xtarifahora As Decimal
                    Private xtarifaHoraExtra As Decimal
                    Private xTarifaExtraviado As Decimal
                    Private xid_seguridad As Byte()

                    Property _IdSeguridad() As Byte()
                        Get
                            Return xid_seguridad
                        End Get
                        Set(ByVal value As Byte())
                            xid_seguridad = value
                        End Set
                    End Property

                    Property _TarifaHora() As Decimal
                        Get
                            Return xtarifahora
                        End Get
                        Set(ByVal value As Decimal)
                            xtarifahora = value
                        End Set
                    End Property

                    Property _TarifaHoraExtra() As Decimal
                        Get
                            Return xtarifaHoraExtra
                        End Get
                        Set(ByVal value As Decimal)
                            xtarifaHoraExtra = value
                        End Set
                    End Property

                    Property _TarifaExtraviado() As Decimal
                        Get
                            Return xTarifaExtraviado
                        End Get
                        Set(ByVal value As Decimal)
                            xTarifaExtraviado = value
                        End Set
                    End Property

                    Sub New()
                        Me._TarifaExtraviado = 0
                        Me._TarifaHora = 0
                        Me._TarifaHoraExtra = 0
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub

                Protected Friend Const ActualizaTarifas As String = "update estacionamiento_tarifas " & _
                "set tarifaHora=@tarifaHora, TarifaHoraExtra=@TarifaHoraExtra, TarifaHoraExtraviada=@TarifaHoraExtraviada " & _
                "Where id_seguridad = @id_seguridad"

                Function F_ActualizarTarifa(ByVal xTarifas As ActualizarTarifas) As Boolean
                    Try
                        Dim xregs As New c_Registro
                        With xregs
                            .c_TarifaHora._ContenidoCampo = xTarifas._TarifaHora
                            .c_TarifaHoraExtra._ContenidoCampo = xTarifas._TarifaHoraExtra
                            .c_TarifaExtraviado._ContenidoCampo = xTarifas._TarifaExtraviado
                            .c_IdSeguridad = xTarifas._IdSeguridad
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    With xregs
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = ActualizaTarifas
                                        xcmd.Parameters.AddWithValue("@" + xregs.c_TarifaHora._NombreCampo, xregs._TarifaHora)
                                        xcmd.Parameters.AddWithValue("@" + xregs.c_TarifaHoraExtra._NombreCampo, xregs._TarifaHoraExtra)
                                        xcmd.Parameters.AddWithValue("@" + xregs.c_TarifaExtraviado._NombreCampo, xregs._TarifaExtraviado)
                                        xcmd.Parameters.AddWithValue("@id_seguridad", xregs._IdSeguridad)
                                        If xcmd.ExecuteNonQuery() = 0 Then
                                            Throw New Exception("TARIFAS - ESTACIONAMIENTO ACTUALIZADAS POR OTRO USUARIO")
                                        End If
                                    End With
                                End Using
                                RaiseEvent _ProcesoRealizado()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message + " " + ex2.Number.ToString)
                            Catch ex1 As Exception
                                Throw New Exception(ex1.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_CargarTarifas() As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("select * from estacionamiento_tarifas", _MiCadenaConexion)
                            xadap.Fill(xtb)
                        End Using
                        Me.Registro.CargarRegistro(xtb(0))
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

            Public Class Tarjetas_EntradaSalidas
                Event _ProcesoRealizado()

                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_Codigo As CampoDato
                    '********entrada*******
                    Private f_hora_entrada As CampoDato
                    Private f_fecha_entrada As CampoDato
                    Private f_Auto_Operador_Entrada As CampoDato
                    Private f_Auto_Jornada_Entrada As CampoDato
                    '**********salida******
                    Private f_hora_salida As CampoDato
                    Private f_fecha_salida As CampoDato
                    Private f_Auto_Operador_Salida As CampoDato
                    Private f_Auto_Jornada_Salida As CampoDato
                    Private f_Estatus As CampoDato


                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Codigo() As CampoDato
                        Get
                            Return f_Codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Codigo = value
                        End Set
                    End Property

                    ReadOnly Property _Codigo() As String
                        Get
                            Dim xv As String = IIf(Me.f_Codigo._RetornarValor(Of String)() Is Nothing, "", Me.f_Codigo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_HoraEntrada() As CampoDato
                        Get
                            Return Me.f_hora_entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _HoraEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaEntrada() As CampoDato
                        Get
                            Return Me.f_fecha_entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha_entrada = value
                        End Set
                    End Property

                    ReadOnly Property _FechaEntrada() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_entrada._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_entrada._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_AutoOperadorEntrada() As CampoDato
                        Get
                            Return Me.f_Auto_Operador_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador Entrada
                    ''' </summary>
                    ReadOnly Property _f_AutoOperadorEntrada() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(xv)
                                    Return xoperador.RegistroDato

                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornadaEntrada() As CampoDato
                        Get
                            Return Me.f_Auto_Jornada_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Jornada_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada Entrada
                    ''' </summary>
                    ReadOnly Property _f_AutoJornadaEntrada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(xv)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_HoraSalida() As CampoDato
                        Get
                            Return Me.f_hora_salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora_salida = value
                        End Set
                    End Property

                    ReadOnly Property _HoraSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_salida._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_FechaSalida() As CampoDato
                        Get
                            Return Me.f_fecha_salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha_salida = value
                        End Set
                    End Property

                    ReadOnly Property _FechaSalida() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha_salida._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha_salida._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_AutoOperadorSalida() As CampoDato
                        Get
                            Return Me.f_Auto_Operador_Salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador_Salida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador Salida
                    ''' </summary>
                    ReadOnly Property _f_AutoOperadorSalida() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Operador_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Salida._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(xv)
                                    Return xoperador.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornadaSalida() As CampoDato
                        Get
                            Return f_Auto_Jornada_Salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Auto_Jornada_Salida = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada Salida
                    ''' </summary>
                    ReadOnly Property _f_AutoJornadaSalida() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Jornada_Salida._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Salida._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(xv)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Estatus() As CampoDato
                        Get
                            Return f_Estatus
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Estatus = value
                        End Set
                    End Property

                    ReadOnly Property _Estatus() As EstatusEstacionamiento
                        Get
                            Dim xv As String = IIf(Me.f_hora_salida._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_salida._RetornarValor(Of String)())
                            If xv.Trim.ToUpper = "0" Then
                                Return EstatusEstacionamiento.Entrada
                            Else
                                Return EstatusEstacionamiento.Salida
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TARJETAS ENTRADA - SALIDA" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Codigo = New CampoDato("codigo", 10)
                        Me.c_HoraEntrada = New CampoDato("Hora_Entrada", 10)
                        Me.c_FechaEntrada = New CampoDato("Fecha_entrada")
                        Me.c_AutoOperadorEntrada = New CampoDato("auto_operador_entrada", 10)
                        Me.c_AutoJornadaEntrada = New CampoDato("auto_jornada_entrada", 10)
                        Me.c_HoraSalida = New CampoDato("Hora_Salida", 10)
                        Me.c_FechaSalida = New CampoDato("Fecha_Salida")
                        Me.c_AutoOperadorSalida = New CampoDato("auto_operador_Salida", 10)
                        Me.c_AutoJornadaSalida = New CampoDato("auto_jornada_Salida", 10)
                        Me.c_Estatus = New CampoDato("estatus", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoJornadaEntrada._ContenidoCampo = xrow(.c_AutoJornadaEntrada._NombreCampo)
                                .c_AutoJornadaSalida._ContenidoCampo = xrow(.c_AutoJornadaSalida._NombreCampo)
                                .c_AutoOperadorEntrada._ContenidoCampo = xrow(.c_AutoOperadorEntrada._NombreCampo)
                                .c_AutoOperadorSalida._ContenidoCampo = xrow(.c_AutoOperadorSalida._NombreCampo)
                                .c_Codigo._ContenidoCampo = xrow(.c_Codigo._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_FechaEntrada._ContenidoCampo = xrow(.c_FechaEntrada._NombreCampo)
                                If Not IsDBNull(xrow(.c_FechaSalida._NombreCampo)) Then
                                    .c_FechaSalida._ContenidoCampo = xrow(.c_FechaSalida._NombreCampo)
                                End If
                                .c_HoraEntrada._ContenidoCampo = xrow(.c_HoraEntrada._NombreCampo)
                                .c_HoraSalida._ContenidoCampo = xrow(.c_HoraSalida._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TARJETAS ENTRADA - SALIDA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class
                Class EntradaTarjeta
                    Private xCodigoTarjeta As String
                    Private xOperador As String
                    Private xJornada As String
                    Private xtipomovimiento As EstatusEstacionamiento

                    Property _CodigoTarjeta() As String
                        Get
                            Return xCodigoTarjeta
                        End Get
                        Set(ByVal value As String)
                            xCodigoTarjeta = value
                        End Set
                    End Property

                    Property _Operador() As String
                        Get
                            Return xOperador
                        End Get
                        Set(ByVal value As String)
                            xOperador = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As EstatusEstacionamiento
                        Get
                            Return xtipomovimiento
                        End Get
                        Set(ByVal value As EstatusEstacionamiento)
                            xtipomovimiento = value
                        End Set
                    End Property

                    Property _Jornada() As String
                        Get
                            Return xJornada
                        End Get
                        Set(ByVal value As String)
                            xJornada = value
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

                    ''' <summary>
                    ''' INDICA EL TIPO DE MOVIMIENTO A GRABAR EN LA BD
                    ''' </summary>
                    Protected Friend ReadOnly Property _Movimiento() As String
                        Get
                            If Me._TipoMovimiento = EstatusEstacionamiento.Entrada Then
                                Return "E"
                            Else
                                Return "S"
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me._CodigoTarjeta = ""
                        Me._Jornada = ""
                        Me._Operador = ""
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub

                Protected Friend Const ActualizarSalidaVehiculos As String = "update estacionamiento_tarjetas " & _
                        "set estatus='S',hora_salida=@hora_salida,fecha_salida=@fecha_salida,auto_operador_salida=@auto_operador_salida," & _
                        "auto_jornada_salida=@auto_jornada_salida where codigo=@Codigo"

                Protected Friend Const InsertarEntradaVehiculos As String = "insert into estacionamiento_tarjetas " & _
                "(auto,codigo,hora_entrada,fecha_entrada,auto_operador_entrada,auto_jornada_entrada,estatus," & _
                "hora_salida,fecha_salida,auto_operador_salida,auto_jornada_salida) " & _
                "values (@auto,@codigo,@hora_entrada,@fecha_entrada,@auto_operador_entrada,@auto_jornada_entrada,@estatus," & _
                "@hora_salida,@fecha_salida,@auto_operador_salida,@auto_jornada_salida)"

            End Class

            Public Class ControlBarras
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_hora As CampoDato
                    Private f_fecha As CampoDato
                    Private f_Auto_Operador_Entrada As CampoDato
                    Private f_Auto_Jornada_Entrada As CampoDato
                    Private f_barraTipo As CampoDato


                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return Me.f_hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora._RetornarValor(Of String)() Is Nothing, "", Me.f_hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return Me.f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return Me.f_Auto_Operador_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador 
                    ''' </summary>
                    ReadOnly Property _f_AutoOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Operador_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(xv)
                                    Return xoperador.RegistroDato

                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return Me.f_Auto_Jornada_Entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Jornada_Entrada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada 
                    ''' </summary>
                    ReadOnly Property _f_AutoJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada_Entrada._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(xv)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_BarraTipoMovimiento() As CampoDato
                        Get
                            Return f_barraTipo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_barraTipo = value
                        End Set
                    End Property

                    ReadOnly Property _BarraTipoMovimiento() As EstatusEstacionamiento
                        Get
                            Dim xv As String = Me.f_barraTipo._ContenidoCampo
                            If xv.Trim.ToUpper = "E" Then
                                Return EstatusEstacionamiento.Entrada
                            Else
                                Return EstatusEstacionamiento.Salida
                            End If
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase CONTROL BARRA ESTACIONAMIENTO" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_Hora = New CampoDato("hora", 10)
                        Me.c_Fecha = New CampoDato("fecha")
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_BarraTipoMovimiento = New CampoDato("barraTipo", 1)

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_BarraTipoMovimiento._ContenidoCampo = xrow(.c_BarraTipoMovimiento._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("CONTROL BARRA ESTACIONAMIENTO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class
                Class MovimientoBarra
                    Private xOperador As String
                    Private xJornada As String
                    Private xTipoBarra As EstatusEstacionamiento

                    Property _Operador() As String
                        Get
                            Return xOperador
                        End Get
                        Set(ByVal value As String)
                            xOperador = value
                        End Set
                    End Property

                    Property _Jornada() As String
                        Get
                            Return xJornada
                        End Get
                        Set(ByVal value As String)
                            xJornada = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As EstatusEstacionamiento
                        Get
                            Return xTipoBarra
                        End Get
                        Set(ByVal value As EstatusEstacionamiento)
                            xTipoBarra = value
                        End Set
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Return F_GetDate("Select getdate()")
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Return F_GetDate("Select getdate()").ToShortTimeString
                        End Get
                    End Property

                    ''' <summary>
                    ''' RETORNA EL TIPO DE MOVIMIENTO A GRABAR EN LA BD
                    ''' </summary>
                    Protected Friend ReadOnly Property _Movimiento() As String
                        Get
                            If Me._TipoMovimiento = EstatusEstacionamiento.Entrada Then
                                Return "E"
                            Else
                                Return "S"
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me._Jornada = ""
                        Me._Operador = ""
                        Me._TipoMovimiento = 0
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub

                Protected Friend Const InsertarControlBarra As String = "insert into estacionamiento_barra " & _
                "(auto,hora,fecha,auto_operador,auto_jornada,barraTipo) " & _
                "values (@auto,@hora,@fecha,@auto_operador,@auto_jornada,@barraTipo)"
            End Class

            Public Class TicketsExtraviados
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_Nombre As CampoDato
                    Private f_Cedula As CampoDato
                    Private f_Placa As CampoDato
                    Private f_Modelo As CampoDato
                    Private f_fecha As CampoDato
                    Private f_hora As CampoDato
                    Private f_auto_doc_venta As CampoDato
                    Private f_Auto_Operador As CampoDato
                    Private f_Auto_Jornada As CampoDato

                    Property c_Auto() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ChoferVehiculo() As CampoDato
                        Get
                            Return f_Nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_Nombre = value
                        End Set
                    End Property

                    ReadOnly Property _ChoferVehiculo() As String
                        Get
                            Dim xv As String = IIf(Me.f_Nombre._RetornarValor(Of String)() Is Nothing, "", Me.f_Nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Cedula() As CampoDato
                        Get
                            Return Me.f_Cedula
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Cedula = value
                        End Set
                    End Property

                    ReadOnly Property _Cedula() As String
                        Get
                            Dim xv As String = IIf(Me.f_Cedula._RetornarValor(Of String)() Is Nothing, "", Me.f_Cedula._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_PlacaVehiculo() As CampoDato
                        Get
                            Return Me.f_Placa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Placa = value
                        End Set
                    End Property

                    ReadOnly Property _PlacaVehiculo() As String
                        Get
                            Dim xv As String = IIf(Me.f_Placa._RetornarValor(Of String)() Is Nothing, "", Me.f_Placa._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ModeloVehiculo() As CampoDato
                        Get
                            Return Me.f_Modelo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Modelo = value
                        End Set
                    End Property

                    ReadOnly Property _ModeloVehiculo() As String
                        Get
                            Dim xv As String = IIf(Me.f_Modelo._RetornarValor(Of String)() Is Nothing, "", Me.f_Modelo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoDocVenta() As CampoDato
                        Get
                            Return f_auto_doc_venta
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_doc_venta = value
                        End Set
                    End Property

                    ReadOnly Property _AutoDocVenta() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_doc_venta._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_venta._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Documento De Venta
                    ''' </summary>
                    ReadOnly Property _f_AutoDocVenta() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                Dim xv As String = IIf(Me.f_auto_doc_venta._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_doc_venta._RetornarValor(Of String)())
                                If xv.Trim <> "" Then
                                    Dim xventa As New FichaVentas.V_Ventas
                                    xventa.F_BuscarDocumento(xv)
                                    Return xventa.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return Me.f_Auto_Operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Operador._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador 
                    ''' </summary>
                    ReadOnly Property _f_AutoOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                If _AutoOperador <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(_AutoOperador)
                                    Return xoperador.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return Me.f_Auto_Jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_Auto_Jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_Auto_Jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_Auto_Jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada 
                    ''' </summary>
                    ReadOnly Property _f_AutoJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                If _AutoJornada <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(_AutoJornada)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    Property c_Hora() As CampoDato
                        Get
                            Return Me.f_hora
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora._RetornarValor(Of String)() Is Nothing, "", Me.f_hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Fecha() As CampoDato
                        Get
                            Return Me.f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            Me.f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase TICKETS EXTRAVIADO" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub


                    Sub New()
                        Me.c_Auto = New CampoDato("auto", 10)
                        Me.c_AutoDocVenta = New CampoDato("auto_doc_venta", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_Cedula = New CampoDato("Cedula", 12)
                        Me.c_ChoferVehiculo = New CampoDato("Nombre", 60)
                        Me.c_Fecha = New CampoDato("fecha")
                        Me.c_Hora = New CampoDato("hora", 10)
                        Me.c_ModeloVehiculo = New CampoDato("modelo", 30)
                        Me.c_PlacaVehiculo = New CampoDato("Placa", 10)

                        M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_Auto._ContenidoCampo = xrow(.c_Auto._NombreCampo)
                                .c_AutoDocVenta._ContenidoCampo = xrow(.c_AutoDocVenta._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_Cedula._ContenidoCampo = xrow(.c_Cedula._NombreCampo)
                                .c_ChoferVehiculo._ContenidoCampo = xrow(.c_ChoferVehiculo._NombreCampo)
                                .c_Fecha._ContenidoCampo = xrow(.c_Fecha._NombreCampo)
                                .c_Hora._ContenidoCampo = xrow(.c_Hora._NombreCampo)
                                .c_PlacaVehiculo._ContenidoCampo = xrow(.c_PlacaVehiculo._NombreCampo)
                                .c_ModeloVehiculo._ContenidoCampo = xrow(.c_ModeloVehiculo._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TICKET EXTRAVIADO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class
                Class AgregarTicket
                    Private xNombre As String
                    Private xcedula As String
                    Private xPlaca As String
                    Private xOperador As String
                    Private xJornada As String
                    Private xModelo As String

                    Property _ChoferVehiculo() As String
                        Get
                            Return xNombre
                        End Get
                        Set(ByVal value As String)
                            xNombre = value
                        End Set
                    End Property

                    Property _Cedula() As String
                        Get
                            Return xcedula
                        End Get
                        Set(ByVal value As String)
                            xcedula = value
                        End Set
                    End Property

                    Property _PlacaVehiculo() As String
                        Get
                            Return xPlaca
                        End Get
                        Set(ByVal value As String)
                            xPlaca = value
                        End Set
                    End Property

                    Property _ModeloVehiculo() As String
                        Get
                            Return Me.xModelo
                        End Get
                        Set(ByVal value As String)
                            Me.xModelo = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xOperador
                        End Get
                        Set(ByVal value As String)
                            xOperador = value
                        End Set
                    End Property

                    Property _AutoJornada() As String
                        Get
                            Return xJornada
                        End Get
                        Set(ByVal value As String)
                            xJornada = value
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
                        Me._ChoferVehiculo = ""
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._Cedula = ""
                        Me._PlacaVehiculo = ""
                        Me._ModeloVehiculo = ""
                    End Sub
                End Class

                Protected Friend Const Insert As String = _
                "INSERT INTO estacionamiento_ticket (" & _
                    "auto, " & _
                    "Nombre, " & _
                    "cedula, " & _
                    "placa, " & _
                    "modelo, " & _
                    "fecha, " & _
                    "hora, " & _
                    "auto_doc_Venta, " & _
                    "auto_operador, " & _
                    "auto_jornada) " & _
                "VALUES (" & _
                    "@auto, " & _
                    "@Nombre, " & _
                    "@cedula, " & _
                    "@placa, " & _
                    "@modelo, " & _
                    "@fecha, " & _
                    "@hora, " & _
                    "@auto_doc_Venta, " & _
                    "@auto_operador, " & _
                    "@auto_jornada)"

                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub
            End Class

            Public Class VentasDetalle
                Class c_Registro
                    Private f_auto_documento As CampoDato
                    Private f_nombre As CampoDato
                    Private f_cantidad As CampoDato
                    Private f_precio_neto As CampoDato
                    Private f_total_neto As CampoDato
                    Private f_tasa As CampoDato
                    Private f_impuesto As CampoDato
                    Private f_total As CampoDato
                    Private f_auto As CampoDato
                    Private f_estatus As CampoDato
                    Private f_fecha As CampoDato
                    Private f_tipo As CampoDato
                    Private f_signo As CampoDato
                    Private f_auto_entidad As CampoDato
                    Private f_codigo_tasa As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_detalle As CampoDato
                    Private f_hora_salida As CampoDato
                    Private f_cantidad_horas As CampoDato
                    Private f_costo_hora_neto As CampoDato
                    Private f_costo_hora_extra_neto As CampoDato
                    Private f_costo_ticket_extraviado_neto As CampoDato
                    Private f_tipo_salida_vehiculo As CampoDato
                    Private f_auto_ticket_entrada As CampoDato
                    Private f_tipomovimiento As CampoDato
                    Private f_auto_item_origen As CampoDato


                    Property c_AutoDocumento() As CampoDato
                        Get
                            Return f_auto_documento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_documento = value
                        End Set
                    End Property

                    Property c_Nombre() As CampoDato
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_nombre = value
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

                    Property c_PrecioNeto() As CampoDato
                        Get
                            Return f_precio_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_precio_neto = value
                        End Set
                    End Property

                    Property c_TotalNeto() As CampoDato
                        Get
                            Return f_total_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_total_neto = value
                        End Set
                    End Property

                    Property c_TasaIva() As CampoDato
                        Get
                            Return f_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tasa = value
                        End Set
                    End Property

                    Property c_MontoIva() As CampoDato
                        Get
                            Return f_impuesto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_impuesto = value
                        End Set
                    End Property

                    Property c_TotalGeneral() As CampoDato
                        Get
                            Return f_total
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_total = value
                        End Set
                    End Property

                    Property c_AutoItem() As CampoDato
                        Get
                            Return f_auto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto = value
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

                    Property c_FechaEmision() As CampoDato
                        Get
                            Return f_fecha
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_fecha = value
                        End Set
                    End Property

                    Property c_TipoDocumento() As CampoDato
                        Get
                            Return f_tipo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo = value
                        End Set
                    End Property

                    Property c_SignoDocumento() As CampoDato
                        Get
                            Return f_signo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_signo = value
                        End Set
                    End Property

                    Property c_AutoCliente() As CampoDato
                        Get
                            Return f_auto_entidad
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_entidad = value
                        End Set
                    End Property

                    Property c_TipoTasaIva() As CampoDato
                        Get
                            Return f_codigo_tasa
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_codigo_tasa = value
                        End Set
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return f_auto_operador
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_operador = value
                        End Set
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return f_auto_jornada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_jornada = value
                        End Set
                    End Property

                    Property c_NotasItem() As CampoDato
                        Get
                            Return f_detalle
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_detalle = value
                        End Set
                    End Property

                    Property c_HoraSalida() As CampoDato
                        Get
                            Return f_hora_salida
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_hora_salida = value
                        End Set
                    End Property

                    Property c_CantidadHoras() As CampoDato
                        Get
                            Return f_cantidad_horas
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_cantidad_horas = value
                        End Set
                    End Property

                    Property c_CostoHoraNeto() As CampoDato
                        Get
                            Return f_costo_hora_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_hora_neto = value
                        End Set
                    End Property

                    Property c_CostoHoraExtraNeto() As CampoDato
                        Get
                            Return f_costo_hora_extra_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_hora_extra_neto = value
                        End Set
                    End Property

                    Property c_CostoTicketExtraviado() As CampoDato
                        Get
                            Return f_costo_ticket_extraviado_neto
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_costo_ticket_extraviado_neto = value
                        End Set
                    End Property

                    Property c_TipoSalidaVehiculo() As CampoDato
                        Get
                            Return f_tipo_salida_vehiculo
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipo_salida_vehiculo = value
                        End Set
                    End Property

                    Property c_AutoTicketEntrada() As CampoDato
                        Get
                            Return f_auto_ticket_entrada
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_ticket_entrada = value
                        End Set
                    End Property

                    Property c_TipoMovimiento() As CampoDato
                        Get
                            Return f_tipomovimiento
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_tipomovimiento = value
                        End Set
                    End Property

                    Property c_AutoItemOrigen() As CampoDato
                        Get
                            Return f_auto_item_origen
                        End Get
                        Protected Friend Set(ByVal value As CampoDato)
                            f_auto_item_origen = value
                        End Set
                    End Property


                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_documento._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_documento._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Documento
                    ''' </summary>
                    ReadOnly Property _f_AutoDocumento() As FichaVentas.V_Ventas.c_Registro
                        Get
                            Try
                                If _AutoDocumento <> "" Then
                                    Dim xventas As New FichaVentas.V_Ventas
                                    xventas.F_BuscarDocumento(_AutoDocumento)
                                    Return xventas.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Dim xv As String = IIf(Me.f_nombre._RetornarValor(Of String)() Is Nothing, "", Me.f_nombre._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Cantidad() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_cantidad._ContenidoCampo Is Nothing, 0, Me.f_cantidad._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _PrecioNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_precio_neto._ContenidoCampo Is Nothing, 0, Me.f_precio_neto._RetornarValor(Of Decimal)())
                            Dim xprecio As New Precio(xv, _TasaIva)
                            Return xprecio
                        End Get
                    End Property

                    ReadOnly Property _TotalNeto() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_total_neto._ContenidoCampo Is Nothing, 0, Me.f_total_neto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TasaIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_tasa._ContenidoCampo Is Nothing, 0, Me.f_tasa._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _MontoIva() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_impuesto._ContenidoCampo Is Nothing, 0, Me.f_impuesto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TotalGeneral() As Decimal
                        Get
                            Dim xv As Decimal = IIf(Me.f_total._ContenidoCampo Is Nothing, 0, Me.f_total._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _AutoItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Dim xv As String = IIf(Me.f_estatus._RetornarValor(Of String)() Is Nothing, "", Me.f_estatus._RetornarValor(Of String)())
                            If xv.Trim = "0" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _TipoDocumento() As FichaVentas.TipoDocumentoVentaRegistrado
                        Get
                            Dim xv As String = IIf(Me.c_TipoDocumento._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoDocumento._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "01" : Return FichaVentas.TipoDocumentoVentaRegistrado.Factura
                                Case "02" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaDebito
                                Case "03" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaCredito
                                Case "04" : Return FichaVentas.TipoDocumentoVentaRegistrado.NotaEntrega
                                Case "05" : Return FichaVentas.TipoDocumentoVentaRegistrado.Presupuesto
                                Case "06" : Return FichaVentas.TipoDocumentoVentaRegistrado.Pedido
                                Case Else : Return ""
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _SignoDocumento() As String
                        Get
                            Dim xv As Integer = IIf(Me.c_SignoDocumento._ContenidoCampo Is Nothing, 0, Me.c_SignoDocumento._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _AutoCliente() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_entidad._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_entidad._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Cliente
                    ''' </summary>
                    ReadOnly Property _f_AutoCliente() As FichaClientes.c_Clientes.c_Registro
                        Get
                            Try
                                If _AutoCliente <> "" Then
                                    Dim xcliente As New FichaClientes.c_Clientes
                                    xcliente.F_BuscarCargar(_AutoCliente)
                                    Return xcliente.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _TipoTasaIva() As TipoTasaImpuesto
                        Get
                            Dim xv As String = IIf(Me.c_TipoTasaIva._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoTasaIva._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "0" : Return TipoTasaImpuesto.Exento
                                Case "1" : Return TipoTasaImpuesto.Vigente
                                Case "2" : Return TipoTasaImpuesto.Reducida
                                Case "3" : Return TipoTasaImpuesto.Otra
                                Case Else : Return ""
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoOperador() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Operador
                    ''' </summary>
                    ReadOnly Property _f_AutoOperador() As FastFood.OperadorJornada.c_Registro
                        Get
                            Try
                                If _AutoOperador <> "" Then
                                    Dim xoperador As New FastFood.OperadorJornada
                                    xoperador.F_BuscarCargar(_AutoOperador)
                                    Return xoperador.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _AutoJornada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ficha Jornada 
                    ''' </summary>
                    ReadOnly Property _f_AutoJornada() As FastFood.Jornada.c_Registro
                        Get
                            Try
                                If _AutoJornada <> "" Then
                                    Dim xjornada As New FastFood.Jornada
                                    xjornada.F_BuscarCargar(_AutoJornada)
                                    Return xjornada.RegistroDato
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _NotasItem() As String
                        Get
                            Dim xv As String = IIf(Me.f_detalle._RetornarValor(Of String)() Is Nothing, "", Me.f_detalle._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _HoraSalida() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora_salida._RetornarValor(Of String)() Is Nothing, "", Me.f_hora_salida._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ReadOnly Property _CantidadHoras() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_cantidad_horas._ContenidoCampo Is Nothing, 0, Me.f_cantidad_horas._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    ReadOnly Property _CostoHoraNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_hora_neto._ContenidoCampo Is Nothing, 0, Me.f_costo_hora_neto._RetornarValor(Of Decimal)())
                            Dim xcosto As New Precio(xv, _TasaIva)
                            Return xcosto
                        End Get
                    End Property

                    ReadOnly Property _CostoHoraExtraNeto() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_hora_extra_neto._ContenidoCampo Is Nothing, 0, Me.f_costo_hora_extra_neto._RetornarValor(Of Decimal)())
                            Dim xcosto As New Precio(xv, _TasaIva)
                            Return xcosto
                        End Get
                    End Property

                    ReadOnly Property _CostoTicketExtraviado() As Precio
                        Get
                            Dim xv As Decimal = IIf(Me.f_costo_ticket_extraviado_neto._ContenidoCampo Is Nothing, 0, Me.f_costo_ticket_extraviado_neto._RetornarValor(Of Decimal)())
                            Dim xcosto As New Precio(xv, _TasaIva)
                            Return xcosto
                        End Get
                    End Property

                    ReadOnly Property _TipoSalidaVehiculo() As TipoSalidaVehiculo
                        Get
                            Dim xv As String = IIf(Me.f_tipo_salida_vehiculo._RetornarValor(Of String)() Is Nothing, "", Me.f_tipo_salida_vehiculo._RetornarValor(Of String)())
                            If xv.Trim = "0" Then
                                Return TipoSalidaVehiculo.Ticket
                            Else
                                Return TipoSalidaVehiculo.TicketExtarviado
                            End If
                        End Get
                    End Property

                    ReadOnly Property _AutoTicketEntrada() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_ticket_entrada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_ticket_entrada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Ticket Entrada
                    ''' </summary>
                    ReadOnly Property _f_AutoTicketEntrada() As Entradas_Salidas.c_Registro
                        Get
                            Try
                                If _AutoTicketEntrada <> "" Then
                                    Dim xticket As New Entradas_Salidas
                                    xticket.f_buscarCargar(_AutoTicketEntrada)
                                    Return xticket.Registro
                                Else
                                    Return Nothing
                                End If
                            Catch ex As Exception
                                Return Nothing
                            End Try
                        End Get
                    End Property

                    ReadOnly Property _TipoMovimiento() As TipoMovimientoDetalle
                        Get
                            Dim xv As String = IIf(Me.c_TipoMovimiento._RetornarValor(Of String)() Is Nothing, "", Me.c_TipoMovimiento._RetornarValor(Of String)())
                            Select Case xv.Trim.ToUpper
                                Case "V" : Return TipoMovimientoDetalle.Venta
                                Case "A" : Return TipoMovimientoDetalle.Ajuste
                                Case "D" : Return TipoMovimientoDetalle.Devolucion
                                Case Else : Return ""
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _AutoItemOrigen() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_item_origen._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_item_origen._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property


                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase VENTAS DETALLE - ESTACIONAMIENTO" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub New()
                        Me.c_AutoCliente = New CampoDato("auto_entidad", 10)
                        Me.c_AutoDocumento = New CampoDato("auto_documento", 10)
                        Me.c_AutoItem = New CampoDato("auto", 10)
                        Me.c_AutoItemOrigen = New CampoDato("auto_item_origen", 10)
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_AutoTicketEntrada = New CampoDato("auto_ticket_entrada", 10)
                        Me.c_Cantidad = New CampoDato("cantidad")
                        Me.c_CantidadHoras = New CampoDato("cantidad_horas")
                        Me.c_CostoHoraNeto = New CampoDato("costo_hora_neto")
                        Me.c_CostoHoraExtraNeto = New CampoDato("costo_hora_extra")
                        Me.c_CostoTicketExtraviado = New CampoDato("costo_ticket_extraviado_neto")
                        Me.c_Estatus = New CampoDato("estatus", 1)
                        Me.c_TipoSalidaVehiculo = New CampoDato("tipo_salida_vehiculo", 1)
                        Me.c_FechaEmision = New CampoDato("fecha")
                        Me.c_HoraSalida = New CampoDato("hora_salida", 10)
                        Me.c_MontoIva = New CampoDato("impuesto")
                        Me.c_Nombre = New CampoDato("nombre", 60)
                        Me.c_NotasItem = New CampoDato("detalle", 120)
                        Me.c_PrecioNeto = New CampoDato("precio_neto")
                        Me.c_SignoDocumento = New CampoDato("signo")
                        Me.c_TasaIva = New CampoDato("tasa")
                        Me.c_TipoDocumento = New CampoDato("tipo", 2)
                        Me.c_TipoTasaIva = New CampoDato("codigo_tasa", 1)
                        Me.c_TipoMovimiento = New CampoDato("tipomovimiento", 1)
                        Me.c_TotalGeneral = New CampoDato("total")
                        Me.c_TotalNeto = New CampoDato("total_neto")

                        Me.M_Limpiar()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                M_Limpiar()

                                .c_AutoCliente._ContenidoCampo = xrow(.c_AutoCliente._NombreCampo)
                                .c_AutoDocumento._ContenidoCampo = xrow(.c_AutoDocumento._NombreCampo)
                                .c_AutoItem._ContenidoCampo = xrow(.c_AutoItem._NombreCampo)
                                .c_AutoItemOrigen._ContenidoCampo = xrow(.c_AutoItemOrigen._NombreCampo)
                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_AutoTicketEntrada._ContenidoCampo = xrow(.c_AutoTicketEntrada._NombreCampo)
                                .c_Cantidad._ContenidoCampo = xrow(.c_Cantidad._NombreCampo)
                                .c_CantidadHoras._ContenidoCampo = xrow(.c_CantidadHoras._NombreCampo)
                                .c_CostoHoraNeto._ContenidoCampo = xrow(.c_CostoHoraNeto._NombreCampo)
                                .c_CostoHoraExtraNeto._ContenidoCampo = xrow(.c_CostoHoraExtraNeto._NombreCampo)
                                .c_CostoTicketExtraviado._ContenidoCampo = xrow(.c_CostoTicketExtraviado._NombreCampo)
                                .c_Estatus._ContenidoCampo = xrow(.c_Estatus._NombreCampo)
                                .c_TipoSalidaVehiculo._ContenidoCampo = xrow(.c_TipoSalidaVehiculo._NombreCampo)
                                .c_FechaEmision._ContenidoCampo = xrow(.c_FechaEmision._NombreCampo)
                                .c_HoraSalida._ContenidoCampo = xrow(.c_HoraSalida._NombreCampo)
                                .c_MontoIva._ContenidoCampo = xrow(.c_MontoIva._NombreCampo)
                                .c_Nombre._ContenidoCampo = xrow(.c_Nombre._NombreCampo)
                                .c_NotasItem._ContenidoCampo = xrow(.c_NotasItem._NombreCampo)
                                .c_PrecioNeto._ContenidoCampo = xrow(.c_PrecioNeto._NombreCampo)
                                .c_SignoDocumento._ContenidoCampo = xrow(.c_SignoDocumento._NombreCampo)
                                .c_TasaIva._ContenidoCampo = xrow(.c_TasaIva._NombreCampo)
                                .c_TipoDocumento._ContenidoCampo = xrow(.c_TipoDocumento._NombreCampo)
                                .c_TipoMovimiento._ContenidoCampo = xrow(.c_TipoMovimiento._NombreCampo)
                                .c_TipoTasaIva._ContenidoCampo = xrow(.c_TipoTasaIva._NombreCampo)
                                .c_TotalGeneral._ContenidoCampo = xrow(.c_TotalGeneral._NombreCampo)
                                .c_TotalNeto._ContenidoCampo = xrow(.c_TotalNeto._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("ESTACIONAMIENTO - VENTAS DETALLE " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Protected Friend Const Insert As String = _
                "INSERT INTO Estacionamientos_VentasDetalle (" & _
                    "auto_documento, " & _
                    "nombre, " & _
                    "cantidad, " & _
                    "precio_neto, " & _
                    "total_neto, " & _
                    "tasa, " & _
                    "impuesto, " & _
                    "total, " & _
                    "auto, " & _
                    "estatus, " & _
                    "fecha, " & _
                    "tipo, " & _
                    "signo, " & _
                    "auto_entidad, " & _
                    "codigo_tasa, " & _
                    "auto_operador, " & _
                    "auto_jornada, " & _
                    "detalle, " & _
                    "hora_salida, " & _
                    "cantidad_horas, " & _
                    "costo_hora_neto, " & _
                    "costo_hora_extra, " & _
                    "costo_ticket_extraviado_neto, " & _
                    "tipo_salida_vehiculo, " & _
                    "auto_ticket_entrada, " & _
                    "tipomovimiento, " & _
                    "auto_item_origen) " & _
               "VALUES (" & _
                    "@auto_documento, " & _
                    "@nombre, " & _
                    "@cantidad, " & _
                    "@precio_neto, " & _
                    "@total_neto, " & _
                    "@tasa, " & _
                    "@impuesto, " & _
                    "@total, " & _
                    "@auto, " & _
                    "@estatus, " & _
                    "@fecha, " & _
                    "@tipo, " & _
                    "@signo, " & _
                    "@auto_entidad, " & _
                    "@codigo_tasa, " & _
                    "@auto_operador, " & _
                    "@auto_jornada, " & _
                    "@detalle, " & _
                    "@hora_salida, " & _
                    "@cantidad_horas, " & _
                    "@costo_hora_neto, " & _
                    "@costo_hora_extra, " & _
                    "@costo_ticket_extraviado_neto, " & _
                    "@tipo_salida_vehiculo, " & _
                    "@auto_ticket_entrada, " & _
                    "@tipomovimiento, " & _
                    "@auto_item_origen)"


                Private xregistro As c_Registro

                Property Registro() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                Sub New()
                    Me.Registro = New c_Registro
                End Sub
            End Class

        End Class
    End Class
End Namespace
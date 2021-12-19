Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports ImpFiscales.MisFiscales

Namespace MiDataSistema
    Partial Public Class DataSistema
        Partial Public Class FastFood

            Enum TipoMovimientoCaja As Integer
                Ninguno = 0
                Entrada = 1
                Salida = 2
            End Enum

            Public Class FondoRetiroAperturaGaveta
                Class c_Registro
                    Private f_auto As CampoDato
                    Private f_monto As CampoDato
                    Private f_motivo As CampoDato
                    Private f_signo As CampoDato
                    Private f_fecha As CampoDato
                    Private f_hora As CampoDato
                    Private f_usuario As CampoDato
                    Private f_estacion As CampoDato
                    Private f_serial_impresora As CampoDato
                    Private f_auto_jornada As CampoDato
                    Private f_auto_operador As CampoDato
                    Private f_tipo As CampoDato

                    Property c_AutoMov() As CampoDato
                        Get
                            Return Me.f_auto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto._RetornarValor(Of String)() Is Nothing, "", Me.f_auto._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_MontoMov() As CampoDato
                        Get
                            Return Me.f_monto
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_monto = value
                        End Set
                    End Property

                    ReadOnly Property _MontoMovimiento() As Decimal
                        Get
                            Dim xv As Integer = IIf(Me.f_monto._ContenidoCampo Is Nothing, 0, Me.f_monto._RetornarValor(Of Decimal)())
                            Return xv
                        End Get
                    End Property

                    Property c_MotivoMov() As CampoDato
                        Get
                            Return Me.f_motivo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_motivo = value
                        End Set
                    End Property

                    ReadOnly Property _MotivoMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_motivo._RetornarValor(Of String)() Is Nothing, "", Me.f_motivo._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_Signo() As CampoDato
                        Get
                            Return Me.f_signo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_signo = value
                        End Set
                    End Property

                    ReadOnly Property _Signo() As Integer
                        Get
                            Dim xv As Integer = IIf(Me.f_signo._ContenidoCampo Is Nothing, 0, Me.f_signo._RetornarValor(Of Integer)())
                            Return xv
                        End Get
                    End Property

                    Property c_FechaMov() As CampoDato
                        Get
                            Return Me.f_fecha
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_fecha = value
                        End Set
                    End Property

                    ReadOnly Property _FechaMovimiento() As Date
                        Get
                            Dim xv As Date = IIf(Me.f_fecha._ContenidoCampo Is Nothing, Date.MinValue, Me.f_fecha._RetornarValor(Of Date)())
                            Return xv.Date
                        End Get
                    End Property

                    Property c_HoraMov() As CampoDato
                        Get
                            Return Me.f_hora
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_hora = value
                        End Set
                    End Property

                    ReadOnly Property _HoraMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_hora._RetornarValor(Of String)() Is Nothing, "", Me.f_hora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_UsuarioMov() As CampoDato
                        Get
                            Return Me.f_usuario
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_usuario = value
                        End Set
                    End Property

                    ReadOnly Property _UsuarioMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_usuario._RetornarValor(Of String)() Is Nothing, "", Me.f_usuario._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_EstacionMov() As CampoDato
                        Get
                            Return Me.f_estacion
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_estacion = value
                        End Set
                    End Property

                    ReadOnly Property _EstacionMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_estacion._RetornarValor(Of String)() Is Nothing, "", Me.f_estacion._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_ImpresoraFiscalMov() As CampoDato
                        Get
                            Return Me.f_serial_impresora
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_serial_impresora = value
                        End Set
                    End Property

                    ReadOnly Property _ImpresoraFiscalMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_serial_impresora._RetornarValor(Of String)() Is Nothing, "", Me.f_serial_impresora._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoJornada() As CampoDato
                        Get
                            Return Me.f_auto_jornada
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto_jornada = value
                        End Set
                    End Property

                    ReadOnly Property _AutoJornadaMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_AutoOperador() As CampoDato
                        Get
                            Return Me.f_auto_operador
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_auto_operador = value
                        End Set
                    End Property

                    ReadOnly Property _AutoOperadorMovimiento() As String
                        Get
                            Dim xv As String = IIf(Me.f_auto_operador._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_operador._RetornarValor(Of String)())
                            Return xv.Trim
                        End Get
                    End Property

                    Property c_TipoMov() As CampoDato
                        Get
                            Return Me.f_tipo
                        End Get
                        Set(ByVal value As CampoDato)
                            Me.f_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _TipoMov() As TipoMovimientoCaja
                        Get
                            Dim xv As String = IIf(Me.f_auto_jornada._RetornarValor(Of String)() Is Nothing, "", Me.f_auto_jornada._RetornarValor(Of String)())
                            Select Case xv
                                Case "0" : Return TipoMovimientoCaja.Ninguno
                                Case "1" : Return TipoMovimientoCaja.Entrada
                                Case "2" : Return TipoMovimientoCaja.Salida
                            End Select
                        End Get
                    End Property

                    Sub New()
                        Me.c_AutoJornada = New CampoDato("auto_jornada", 10)
                        Me.c_AutoMov = New CampoDato("auto", 10)
                        Me.c_AutoOperador = New CampoDato("auto_operador", 10)
                        Me.c_EstacionMov = New CampoDato("estacion", 20)
                        Me.c_FechaMov = New CampoDato("fecha")
                        Me.c_HoraMov = New CampoDato("hora", 10)
                        Me.c_ImpresoraFiscalMov = New CampoDato("serial_impresora", 15)
                        Me.c_MontoMov = New CampoDato("monto")
                        Me.c_MotivoMov = New CampoDato("motivo", 60)
                        Me.c_Signo = New CampoDato("signo")
                        Me.c_TipoMov = New CampoDato("tipo", 1)
                        Me.c_UsuarioMov = New CampoDato("usuario", 20)

                        M_Limpiar()
                    End Sub

                    Sub M_Limpiar()
                        Try
                            InicializarDato(Me)
                        Catch ex As Exception
                            Dim x As String = "Error Al Inicializar Clase FONDO-APERTURA-GAVETA" + vbCrLf + ex.Message
                            MessageBox.Show(x, "*** Mensaje De Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            With Me
                                .M_Limpiar()

                                .c_AutoJornada._ContenidoCampo = xrow(.c_AutoJornada._NombreCampo)
                                .c_AutoMov._ContenidoCampo = xrow(.c_AutoMov._NombreCampo)
                                .c_AutoOperador._ContenidoCampo = xrow(.c_AutoOperador._NombreCampo)
                                .c_EstacionMov._ContenidoCampo = xrow(.c_EstacionMov._NombreCampo)
                                .c_FechaMov._ContenidoCampo = xrow(.c_FechaMov._NombreCampo)
                                .c_HoraMov._ContenidoCampo = xrow(.c_HoraMov._NombreCampo)
                                .c_ImpresoraFiscalMov._ContenidoCampo = xrow(.c_ImpresoraFiscalMov._NombreCampo)
                                .c_MontoMov._ContenidoCampo = xrow(.c_MontoMov._NombreCampo)
                                .c_MotivoMov._ContenidoCampo = xrow(.c_MotivoMov._NombreCampo)
                                .c_Signo._ContenidoCampo = xrow(.c_Signo._NombreCampo)
                                .c_TipoMov._ContenidoCampo = xrow(.c_TipoMov._NombreCampo)
                                .c_UsuarioMov._ContenidoCampo = xrow(.c_UsuarioMov._NombreCampo)
                            End With
                        Catch ex As Exception
                            Throw New Exception("FASTFOOD" + vbCrLf + "FONDO-APERTURA-GAVETA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class AgregarMovCaja
                    Private xmonto As Decimal
                    Private xmotivo As String
                    Private xusuario As String
                    Private xestacion As String
                    Private xserial_impresora As String
                    Private xauto_jornada As String
                    Private xauto_operador As String
                    Private xtipo As TipoMovimientoCaja
                    Private xsigno As Integer

                    Property _TotalMonto() As Decimal
                        Get
                            Return xmonto
                        End Get
                        Set(ByVal value As Decimal)
                            xmonto = value
                        End Set
                    End Property

                    Property _DetalleNotas() As String
                        Get
                            Return xmotivo
                        End Get
                        Set(ByVal value As String)
                            xmotivo = value
                        End Set
                    End Property

                    Property _NombreUsuario() As String
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As String)
                            xusuario = value
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

                    Property _AutoJornada() As String
                        Get
                            Return xauto_jornada
                        End Get
                        Set(ByVal value As String)
                            xauto_jornada = value
                        End Set
                    End Property

                    Property _AutoOperador() As String
                        Get
                            Return xauto_operador
                        End Get
                        Set(ByVal value As String)
                            xauto_operador = value
                        End Set
                    End Property

                    Property _SerialImpresora() As String
                        Get
                            Return xserial_impresora
                        End Get
                        Set(ByVal value As String)
                            xserial_impresora = value
                        End Set
                    End Property

                    Property _TipoMovimiento() As TipoMovimientoCaja
                        Get
                            Return xtipo
                        End Get
                        Set(ByVal value As TipoMovimientoCaja)
                            xtipo = value
                        End Set
                    End Property

                    ReadOnly Property _Signo() As Integer
                        Get
                            If Me._TipoMovimiento = TipoMovimientoCaja.Entrada Then
                                Return 1
                            ElseIf Me._TipoMovimiento = TipoMovimientoCaja.Salida Then
                                Return -1
                            End If
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Fecha() As Date
                        Get
                            Dim xf As Date = F_GetDate("select getdate()")
                            Return xf
                        End Get
                    End Property

                    Protected Friend ReadOnly Property _Hora() As String
                        Get
                            Dim xf As String = F_GetDate("select getdate()").ToShortTimeString
                            Return xf
                        End Get
                    End Property

                    Sub New()
                        Me._AutoJornada = ""
                        Me._AutoOperador = ""
                        Me._DetalleNotas = ""
                        Me._EstacionEquipo = ""
                        Me._NombreUsuario = ""
                        Me._SerialImpresora = ""
                        Me._TipoMovimiento = 0
                        Me._TotalMonto = 0
                    End Sub
                End Class

                Class AbrirGaveta
                    Private xusuario As String
                    Private xestacion As String
                    Private xjornada As String
                    Private xoperador As String
                    Private xserial As String

                    Property _Usuario() As String
                        Get
                            Return xusuario
                        End Get
                        Set(ByVal value As String)
                            xusuario = value
                        End Set
                    End Property

                    Property _Estacion() As String
                        Get
                            Return xestacion
                        End Get
                        Set(ByVal value As String)
                            xestacion = value
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

                    Property _SerialFiscal() As String
                        Get
                            Return xserial
                        End Get
                        Set(ByVal value As String)
                            xserial = value
                        End Set
                    End Property

                    ReadOnly Property _Monto() As Decimal
                        Get
                            Return 0
                        End Get
                    End Property

                    ReadOnly Property _Motivo() As String
                        Get
                            Return "Apertura De Gaveta"
                        End Get
                    End Property

                    ReadOnly Property _Signo() As Integer
                        Get
                            Return 1
                        End Get
                    End Property

                    ReadOnly Property _Fecha() As Date
                        Get
                            Dim x As Date = F_GetDate("select getdate()")
                            Return x
                        End Get
                    End Property

                    ReadOnly Property _Hora() As String
                        Get
                            Dim x As String = F_GetDate("select getdate()").ToShortTimeString
                            Return x
                        End Get
                    End Property

                    ReadOnly Property _TipoMovimiento() As String
                        Get
                            Return "0"
                        End Get
                    End Property

                    Sub New()
                        Me._Estacion = ""
                        Me._Jornada = ""
                        Me._Operador = ""
                        Me._SerialFiscal = ""
                        Me._Usuario = ""
                    End Sub
                End Class

                Protected Friend Const INSERT_FONDORETIROAPERTURAGAVETA As String = "INSERT INTO FONDORETIROAPERTURAGAVETA (" _
                    + "auto" _
                    + ",monto" _
                    + ",motivo" _
                    + ",signo" _
                    + ",fecha" _
                    + ",hora" _
                    + ",usuario" _
                    + ",estacion" _
                    + ",serial_impresora" _
                    + ",auto_jornada" _
                    + ",auto_operador" _
                    + ",tipo) " _
                    + "VALUES(" _
                    + "@auto" _
                    + ",@monto" _
                    + ",@motivo" _
                    + ",@signo" _
                    + ",@fecha" _
                    + ",@hora" _
                    + ",@usuario" _
                    + ",@estacion" _
                    + ",@serial_impresora" _
                    + ",@auto_jornada" _
                    + ",@auto_operador" _
                    + ",@tipo) "

                Dim xregistro As c_Registro

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

                Function F_AbrirGaveta(ByVal xabrir As AbrirGaveta, ByVal ximpfiscal As IFiscal) As Boolean
                    Try
                        Dim xsql As String = "update contadores set a_fondoretiroaperturagaveta=a_fondoretiroaperturagaveta+1; select a_fondoretiroaperturagaveta from contadores"
                        Dim xobj As Object = Nothing
                        Dim xtr As SqlTransaction = Nothing
                        Dim xgv As New FondoRetiroAperturaGaveta.c_Registro

                        With xgv
                            .c_AutoJornada._ContenidoCampo = xabrir._Jornada
                            .c_AutoMov._ContenidoCampo = ""
                            .c_AutoOperador._ContenidoCampo = xabrir._Operador
                            .c_EstacionMov._ContenidoCampo = xabrir._Estacion
                            .c_FechaMov._ContenidoCampo = xabrir._Fecha
                            .c_HoraMov._ContenidoCampo = xabrir._Hora
                            .c_ImpresoraFiscalMov._ContenidoCampo = xabrir._SerialFiscal
                            .c_MontoMov._ContenidoCampo = xabrir._Monto
                            .c_MotivoMov._ContenidoCampo = xabrir._Motivo
                            .c_Signo._ContenidoCampo = xabrir._Signo
                            .c_TipoMov._ContenidoCampo = xabrir._TipoMovimiento
                            .c_UsuarioMov._ContenidoCampo = xabrir._Usuario
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_fondoretiroaperturagaveta from contadores"
                                    xobj = xcmd.ExecuteScalar
                                    If IsDBNull(xobj) Or (xobj Is Nothing) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_fondoretiroaperturagaveta=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql
                                    xgv.c_AutoMov._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_FONDORETIROAPERTURAGAVETA
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xgv.c_AutoJornada._NombreCampo, xgv._AutoJornadaMovimiento).Size = xgv.c_AutoJornada._LargoCampo
                                        .AddWithValue("@" + xgv.c_AutoMov._NombreCampo, xgv._AutoMovimiento).Size = xgv.c_AutoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_AutoOperador._NombreCampo, xgv._AutoOperadorMovimiento).Size = xgv.c_AutoOperador._LargoCampo
                                        .AddWithValue("@" + xgv.c_EstacionMov._NombreCampo, xgv._EstacionMovimiento).Size = xgv.c_EstacionMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_FechaMov._NombreCampo, xgv._FechaMovimiento)
                                        .AddWithValue("@" + xgv.c_HoraMov._NombreCampo, xgv._HoraMovimiento).Size = xgv.c_HoraMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_ImpresoraFiscalMov._NombreCampo, xgv._ImpresoraFiscalMovimiento).Size = xgv.c_ImpresoraFiscalMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_MontoMov._NombreCampo, xgv._MontoMovimiento)
                                        .AddWithValue("@" + xgv.c_MotivoMov._NombreCampo, xgv._MotivoMovimiento).Size = xgv.c_MotivoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_Signo._NombreCampo, xgv._Signo)
                                        .AddWithValue("@" + xgv.c_TipoMov._NombreCampo, xgv.c_TipoMov._ContenidoCampo).Size = xgv.c_TipoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_UsuarioMov._NombreCampo, xgv._UsuarioMovimiento).Size = xgv.c_UsuarioMov._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    If ximpfiscal IsNot Nothing Then
                                        ximpfiscal.AbrirGaveta()
                                    End If
                                End Using
                                xtr.Commit()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                If ex.Number = 547 Then
                                    Throw New Exception("ERROR... JORNADA / OPERADOR NO EXISTE, POR FAVOR VERIFIQUE")
                                Else
                                    Throw New Exception(ex.Message)
                                End If
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("FONDO RETIRO APERTURA GAVETA" + vbCrLf + "GRABAR FONDO DE CAJA:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_GrabarMovimiento(ByVal xmov As AgregarMovCaja, ByVal ximpfiscal As IFiscal) As Boolean
                    Try
                        Dim xsql As String = "update contadores set a_fondoretiroaperturagaveta=a_fondoretiroaperturagaveta+1; select a_fondoretiroaperturagaveta from contadores"
                        Dim xobj As Object = Nothing
                        Dim xtr As SqlTransaction = Nothing
                        Dim xgv As New FondoRetiroAperturaGaveta.c_Registro

                        With xgv
                            .c_AutoJornada._ContenidoCampo = xmov._AutoJornada
                            .c_AutoMov._ContenidoCampo = ""
                            .c_AutoOperador._ContenidoCampo = xmov._AutoOperador
                            .c_EstacionMov._ContenidoCampo = xmov._EstacionEquipo
                            .c_FechaMov._ContenidoCampo = xmov._Fecha
                            .c_HoraMov._ContenidoCampo = xmov._Hora
                            If ximpfiscal IsNot Nothing Then
                                .c_ImpresoraFiscalMov._ContenidoCampo = xmov._SerialImpresora
                            Else
                                .c_ImpresoraFiscalMov._ContenidoCampo = ""
                            End If
                            .c_MontoMov._ContenidoCampo = xmov._TotalMonto
                            .c_MotivoMov._ContenidoCampo = xmov._DetalleNotas
                            .c_Signo._ContenidoCampo = xmov._Signo
                            .c_TipoMov._ContenidoCampo = IIf(xmov._TipoMovimiento = TipoMovimientoCaja.Entrada, "1", "2")
                            .c_UsuarioMov._ContenidoCampo = xmov._NombreUsuario
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select a_fondoretiroaperturagaveta from contadores"
                                    xobj = xcmd.ExecuteScalar
                                    If IsDBNull(xobj) Or (xobj Is Nothing) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_fondoretiroaperturagaveta=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = xsql
                                    xgv.c_AutoMov._ContenidoCampo = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = INSERT_FONDORETIROAPERTURAGAVETA
                                    With xcmd.Parameters
                                        .AddWithValue("@" + xgv.c_AutoJornada._NombreCampo, xgv._AutoJornadaMovimiento).Size = xgv.c_AutoJornada._LargoCampo
                                        .AddWithValue("@" + xgv.c_AutoMov._NombreCampo, xgv._AutoMovimiento).Size = xgv.c_AutoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_AutoOperador._NombreCampo, xgv._AutoOperadorMovimiento).Size = xgv.c_AutoOperador._LargoCampo
                                        .AddWithValue("@" + xgv.c_EstacionMov._NombreCampo, xgv._EstacionMovimiento).Size = xgv.c_EstacionMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_FechaMov._NombreCampo, xgv._FechaMovimiento)
                                        .AddWithValue("@" + xgv.c_HoraMov._NombreCampo, xgv._HoraMovimiento).Size = xgv.c_HoraMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_ImpresoraFiscalMov._NombreCampo, xgv._ImpresoraFiscalMovimiento).Size = xgv.c_ImpresoraFiscalMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_MontoMov._NombreCampo, xgv._MontoMovimiento)
                                        .AddWithValue("@" + xgv.c_MotivoMov._NombreCampo, xgv._MotivoMovimiento).Size = xgv.c_MotivoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_Signo._NombreCampo, xgv._Signo)
                                        .AddWithValue("@" + xgv.c_TipoMov._NombreCampo, xgv.c_TipoMov._ContenidoCampo).Size = xgv.c_TipoMov._LargoCampo
                                        .AddWithValue("@" + xgv.c_UsuarioMov._NombreCampo, xgv._UsuarioMovimiento).Size = xgv.c_UsuarioMov._LargoCampo
                                    End With
                                    xcmd.ExecuteNonQuery()

                                    If ximpfiscal IsNot Nothing Then
                                        If xmov._TipoMovimiento = TipoMovimientoCaja.Entrada Then
                                            ximpfiscal.FondoCaja(xmov._TotalMonto)
                                        ElseIf xmov._TipoMovimiento = TipoMovimientoCaja.Salida Then
                                            ximpfiscal.RetiroCaja(xmov._TotalMonto)
                                        End If
                                    End If
                                End Using
                                xtr.Commit()
                                Return True
                            Catch ex As SqlException
                                xtr.Rollback()
                                Throw New Exception("Error:" + ex.Message + vbCrLf + "Numero:" + ex.Number.ToString)
                            Catch ex2 As Exception
                                xtr.Rollback()
                                Throw New Exception(ex2.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("FONDO RETIRO APERTURA GAVETA" + vbCrLf + "GRABAR MOVIMIENTO:" + vbCrLf + ex.Message)
                    End Try
                End Function

            End Class
        End Class
    End Class
End Namespace


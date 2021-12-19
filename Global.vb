Imports System.Data
Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema

        ''' <summary>
        ''' DEFINICION DE FICHAS GLOBAL DEL SISTEMA, COMO:
        ''' DEPOSITO, TASAS FISCALES, EMPRESA,
        ''' </summary>
        Partial Public Class FichaGlobal
            ''' <summary>
            ''' CLASE: DEPOSITOS
            ''' </summary>
            Class c_Depositos
                Event Actualizar()

                Class c_AgregarDeposito
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_DepositoRegistrar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreDeposito() As String
                        Set(ByVal value As String)
                            xreg.c_Nombre.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoDeposito() As String
                        Set(ByVal value As String)
                            xreg.c_Codigo.c_Texto = value
                        End Set
                    End Property
                End Class

                Class c_ModificarDeposito
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    Protected Friend Property c_DepositoModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                        Set(ByVal value As c_Registro)
                            xreg = value
                        End Set
                    End Property

                    WriteOnly Property _NombreDeposito() As String
                        Set(ByVal value As String)
                            xreg.c_Nombre.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoDeposito() As String
                        Set(ByVal value As String)
                            xreg.c_Codigo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoDeposito() As String
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

                    Property c_Nombre() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _Nombre() As String
                        Get
                            Return Me.c_Nombre.c_Texto.Trim
                        End Get
                    End Property

                    Property c_Codigo() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _Codigo() As String
                        Get
                            Return Me.c_Codigo.c_Texto.Trim
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
                        c_Codigo = New CampoTexto(10, "codigo")
                        c_Nombre = New CampoTexto(20, "nombre")
                        c_Automatico = New CampoTexto(10, "auto")

                        M_LimpiarRegistro()
                    End Sub

                    Sub CargarData(ByVal xrow As DataRow)
                        Try
                            M_LimpiarRegistro()

                            Me.c_Automatico.c_Texto = xrow(Me.c_Automatico.c_NombreInterno)
                            Me.c_Nombre.c_Texto = xrow(Me.c_Nombre.c_NombreInterno)
                            Me.c_Codigo.c_Texto = xrow(Me.c_Codigo.c_NombreInterno)

                            If Not IsDBNull(xrow("id_seguridad")) Then
                                Me.c_IdSeguridad = xrow("id_seguridad")
                            End If
                        Catch ex As Exception
                            Throw New Exception("DEPOSITOS: " + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    "update contadores set a_depositos=a_depositos+1;select a_depositos from contadores"
                Private Const InsertDepart_2 As String = _
                    "Insert into DEPOSITOS (auto,nombre,codigo) values (@auto,@nombre,@codigo)"
                Private Const UpdateDepart_1 As String = _
                    "Update DEPOSITOS set nombre=@nombre, codigo=@codigo where auto=@auto and id_seguridad=@id_seguridad"
                Private Const DeleteDepart_1 As String = _
                    "Delete DEPOSITOS where auto=@auto"

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
                                    Throw New Exception("ERROR AL ELIMINAR DEPOSITO, EXISTEN PRODUCTOS DENTRO DE ESTE DEPOSITO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPOSITO: " + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Actualizar Registro De La Tabla 
                ''' </summary>
                Function F_ModificaRegistro(ByVal xgrupomod As c_ModificarDeposito) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(UpdateDepart_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_DepositoModificar.c_Automatico.c_Texto).Size = xgrupomod.c_DepositoModificar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_DepositoModificar.c_Nombre.c_Texto).Size = xgrupomod.c_DepositoModificar.c_Nombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@CODIGO", xgrupomod.c_DepositoModificar.c_Codigo.c_Texto).Size = xgrupomod.c_DepositoModificar.c_Codigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xgrupomod.c_DepositoModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR DEPOSITO, DEPOSITO HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR DEPOSITO, EXISTE UN DEPOSITO CON EL MISMO NOMBRE/CODIGO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPOSITO" + vbCrLf + "MODIFICAR DEPOSITO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Agregar Registro Nuevo A La Tabla 
                ''' </summary>
                Function F_AgregarRegistro(ByVal depagregar As c_AgregarDeposito) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = InsertDepart_1
                                    depagregar.c_DepositoRegistrar.c_Automatico.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = InsertDepart_2
                                    xcmd.Parameters.AddWithValue("@auto", depagregar.c_DepositoRegistrar.c_Automatico.c_Texto).Size = depagregar.c_DepositoRegistrar.c_Automatico.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", depagregar.c_DepositoRegistrar.c_Nombre.c_Texto).Size = depagregar.c_DepositoRegistrar.c_Nombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", depagregar.c_DepositoRegistrar.c_Codigo.c_Texto).Size = depagregar.c_DepositoRegistrar.c_Codigo.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR DEPOSITO, EXISTE UN DEPOSITO CON EL MISMO NOMBRE/CODIGO")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR DEPOSITO, AUTOMATICO DEL DEPOSITO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("PRODUCTOS: DEPOSITO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarDeposito(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from depositos where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count >= 1 Then
                            M_Cargardata(xtb.Rows(0))
                        Else
                            Throw New Exception("DEPOSITOS" + vbCrLf + "BUSCAR DEPOSITO" + vbCrLf + "DEPOSITO NO ENCONTRADO")
                        End If
                    Catch ex As Exception
                        Throw New Exception("DEPOSITOS: " + vbCrLf + "BUSCAR DEPOSITO" + vbCrLf + ex.Message)
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
            ''' CLASE: TABLAS FISCALES
            ''' </summary>
            Class c_TasasFiscales
                Event Actualizar()

                ''' <summary>
                ''' Clase: Para Ser Usada Por La Lista De Tasas
                ''' </summary>
                Class Tasas
                    Dim xtasa_nom As String
                    Dim xtasa_val As Single
                    Dim xtasa_tip As String

                    Property _TasaNombre() As String
                        Get
                            If xtasa_nom.Trim = "" Then
                                Dim xt As String = "Tasa "
                                xt += String.Format("{0:#0.00}", xtasa_val).Trim.PadLeft(5, "0") + "%"
                                Return xt
                            Else
                                Return xtasa_nom
                            End If
                        End Get
                        Set(ByVal value As String)
                            xtasa_nom = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tipo De Tasa
                    ''' </summary>
                    Property _TasaTipo() As String
                        Get
                            Return xtasa_tip
                        End Get
                        Set(ByVal value As String)
                            xtasa_tip = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Valor De Tasa
                    ''' </summary>
                    Property _TasaValor() As Single
                        Get
                            Return xtasa_val
                        End Get
                        Set(ByVal value As Single)
                            xtasa_val = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna La Clase Tasa
                    ''' </summary>
                    ReadOnly Property _Tasa() As Tasas
                        Get
                            Return Me
                        End Get
                    End Property

                    Sub New()
                        Me._TasaNombre = ""
                        Me._TasaTipo = ""
                        Me._TasaValor = 0
                    End Sub
                End Class

                ''' <summary>
                ''' Clase: Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_tasa1 As CampoSingle
                    Private f_tasa2 As CampoSingle
                    Private f_tasa3 As CampoSingle
                    Private f_retencion_iva As CampoSingle
                    Private f_retencion_islr As CampoSingle
                    Private f_debito_bancario As CampoSingle
                    Private f_tasa_licor As CampoSingle
                    Private f_divisa As CampoSingle

                    ''' <summary>
                    ''' Metodo: Limpiar Registro De Dato
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        With Me.c_TasaDivisaActual
                            .c_NombreInterno = "divisa"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaImpuestoBancario
                            .c_NombreInterno = "debito_bancario"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaIva_1
                            .c_NombreInterno = "tasa1"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaIva_2
                            .c_NombreInterno = "tasa2"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaIva_3
                            .c_NombreInterno = "tasa3"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaLicor
                            .c_NombreInterno = "tasa_licor"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaRetencionISLR
                            .c_NombreInterno = "retencion_islr"
                            .c_Valor = 0
                        End With
                        With Me.c_TasaRetencionIva
                            .c_NombreInterno = "retencion_iva"
                            .c_Valor = 0
                        End With
                    End Sub

                    Sub New()
                        Me.c_TasaDivisaActual = New CampoSingle
                        Me.c_TasaImpuestoBancario = New CampoSingle
                        Me.c_TasaIva_1 = New CampoSingle
                        Me.c_TasaIva_2 = New CampoSingle
                        Me.c_TasaIva_3 = New CampoSingle
                        Me.c_TasaLicor = New CampoSingle
                        Me.c_TasaRetencionISLR = New CampoSingle
                        Me.c_TasaRetencionIva = New CampoSingle

                        M_LimpiarRegistro()
                    End Sub

                    ''' <summary>
                    ''' Campo Tasa Iva 1
                    ''' </summary>
                    Property c_TasaIva_1() As CampoSingle
                        Get
                            Return f_tasa1
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_tasa1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Iva 2
                    ''' </summary>
                    Property c_TasaIva_2() As CampoSingle
                        Get
                            Return f_tasa2
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_tasa2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Iva 3
                    ''' </summary>
                    Property c_TasaIva_3() As CampoSingle
                        Get
                            Return f_tasa3
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_tasa3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Retencion Iva
                    ''' </summary>
                    Property c_TasaRetencionIva() As CampoSingle
                        Get
                            Return f_retencion_iva
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_retencion_iva = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Retencion ISLR
                    ''' </summary>
                    Property c_TasaRetencionISLR() As CampoSingle
                        Get
                            Return f_retencion_islr
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_retencion_islr = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Impuesto/Debito Bancario
                    ''' </summary>
                    Property c_TasaImpuestoBancario() As CampoSingle
                        Get
                            Return f_debito_bancario
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_debito_bancario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Licor
                    ''' </summary>
                    Property c_TasaLicor() As CampoSingle
                        Get
                            Return f_tasa_licor
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_tasa_licor = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Tasa Divisa Actual
                    ''' </summary>
                    Property c_TasaDivisaActual() As CampoSingle
                        Get
                            Return f_divisa
                        End Get
                        Protected Friend Set(ByVal value As CampoSingle)
                            f_divisa = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Iva 1
                    ''' </summary>
                    ReadOnly Property r_TasaIva_1() As Single
                        Get
                            Return Me.c_TasaIva_1.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Iva 2
                    ''' </summary>
                    ReadOnly Property r_TasaIva_2() As Single
                        Get
                            Return Me.c_TasaIva_2.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Iva 3
                    ''' </summary>
                    ReadOnly Property r_TasaIva_3() As Single
                        Get
                            Return Me.c_TasaIva_3.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Retencion ISLR
                    ''' </summary>
                    ReadOnly Property r_TasaRetencionISLR() As Single
                        Get
                            Return Me.c_TasaRetencionISLR.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Retencion IVA
                    ''' </summary>
                    ReadOnly Property r_TasaRetencionIVA() As Single
                        Get
                            Return Me.c_TasaRetencionIva.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Impuesto Debito Bancario
                    ''' </summary>
                    ReadOnly Property r_TasaImpuestoDebitoBancario() As Single
                        Get
                            Return Me.c_TasaImpuestoBancario.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Licor
                    ''' </summary>
                    ReadOnly Property r_TasaLicor() As Single
                        Get
                            Return Me.c_TasaLicor.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Tasa Divisa
                    ''' </summary>
                    ReadOnly Property r_TasaDivisa() As Single
                        Get
                            Return Me.c_TasaDivisaActual.c_Valor
                        End Get
                    End Property

                    'CREATE TABLE [dbo].[fiscal](
                    '	[tasa1] [decimal](6, 2) NOT NULL,
                    '	[tasa2] [decimal](6, 2) NOT NULL,
                    '	[tasa3] [decimal](6, 2) NOT NULL,
                    '	[retencion_iva] [decimal](6, 2) NOT NULL,
                    '	[retencion_islr] [decimal](6, 2) NOT NULL,
                    '	[debito_bancario] [decimal](6, 2) NOT NULL,
                    '	[tasa_licor] [decimal](6, 2) NOT NULL,
                    '	[divisa] [decimal](18, 4) NOT NULL
                End Class

                ''' <summary>
                ''' Instrucciones Sql
                ''' </summary>
                Const Update_1 As String = "update fiscal set tasa1=@tasa1,tasa2=@tasa2,tasa3=@tasa3"
                Const Select_1 As String = "select * from fiscal"

                Private xtabla As DataTable
                Private xregistro As c_Registro
                Private x_listatasas As List(Of Tasas)

                Sub New()
                    xtabla = New DataTable("FISCAL")
                    xregistro = New c_Registro
                    Me.r_ListaTasasFiscales = New List(Of Tasas)
                End Sub

                ''' <summary>
                ''' Funcion: Retorna Lista De Tasas Fiscales Vigentes
                ''' </summary>
                Property r_ListaTasasFiscales() As List(Of Tasas)
                    Get
                        Return x_listatasas
                    End Get
                    Protected Friend Set(ByVal value As List(Of Tasas))
                        x_listatasas = value
                    End Set
                End Property

                ''' <summary>
                ''' Tabla A Almacenar Registro
                ''' </summary>
                Property TablaFiscal() As DataTable
                    Get
                        Return xtabla
                    End Get
                    Set(ByVal value As DataTable)
                        xtabla = value
                    End Set
                End Property

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
                ''' Metodo: Limpiar Tabla
                ''' </summary>
                Sub M_Limpiar_Tabla()
                    Me.TablaFiscal.Rows.Clear()
                End Sub

                ''' <summary>
                ''' Metodo: Carga Ficha De Datos Fiscales A La Clase Registro
                ''' </summary>
                Sub M_CargarFicha()
                    Try
                        Me.RegistroDato.M_LimpiarRegistro()
                        With Me.RegistroDato
                            .c_TasaIva_1.c_Valor = xtabla.Rows(0)(.c_TasaIva_1.c_NombreInterno)
                            .c_TasaIva_2.c_Valor = xtabla.Rows(0)(.c_TasaIva_2.c_NombreInterno)
                            .c_TasaIva_3.c_Valor = xtabla.Rows(0)(.c_TasaIva_3.c_NombreInterno)
                            .c_TasaDivisaActual.c_Valor = xtabla.Rows(0)(.c_TasaDivisaActual.c_NombreInterno)
                            .c_TasaImpuestoBancario.c_Valor = xtabla.Rows(0)(.c_TasaImpuestoBancario.c_NombreInterno)
                            .c_TasaLicor.c_Valor = xtabla.Rows(0)(.c_TasaLicor.c_NombreInterno)
                            .c_TasaRetencionIva.c_Valor = xtabla.Rows(0)(.c_TasaRetencionIva.c_NombreInterno)
                            .c_TasaRetencionISLR.c_Valor = xtabla.Rows(0)(.c_TasaRetencionISLR.c_NombreInterno)
                        End With

                        Me.x_listatasas.Clear()
                        Me.x_listatasas.Add(New Tasas With {._TasaNombre = "Tasa Exenta", ._TasaTipo = "0", ._TasaValor = 0})
                        Me.x_listatasas.Add(New Tasas With {._TasaNombre = "", ._TasaTipo = "1", ._TasaValor = Me.RegistroDato.c_TasaIva_1.c_Valor})
                        Me.x_listatasas.Add(New Tasas With {._TasaNombre = "", ._TasaTipo = "2", ._TasaValor = Me.RegistroDato.c_TasaIva_2.c_Valor})
                        Me.x_listatasas.Add(New Tasas With {._TasaNombre = "", ._TasaTipo = "3", ._TasaValor = Me.RegistroDato.c_TasaIva_3.c_Valor})
                    Catch ex As Exception
                        Throw New Exception("TASAS FISCALES." + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                ''' <summary>
                ''' PERMITE ACTUALIZAR LAS DIFERENTES TASA DE IMPUESTO FISCAL (IVA)
                ''' </summary>
                Function F_ActualizarTasasFiscales(ByVal xtasa1 As Single, ByVal xtasa2 As Single, ByVal xtasa3 As Single) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Update_1
                                    xcmd.Parameters.AddWithValue("@tasa1", xtasa1)
                                    xcmd.Parameters.AddWithValue("@tasa2", xtasa2)
                                    xcmd.Parameters.AddWithValue("@tasa3", xtasa3)
                                    xcmd.ExecuteNonQuery()

                                    Dim xr As Integer = 0
                                    Dim dr As SqlDataReader = Nothing
                                    Dim xtb As New DataTable

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto,nombre from productos where impuesto='1'"
                                    dr = xcmd.ExecuteReader()
                                    xtb.Load(dr)

                                    For Each xrow As DataRow In xtb.Rows
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update productos set tasa=@tasa where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@tasa", xtasa1)
                                        xcmd.Parameters.AddWithValue("@auto", xrow(0).ToString)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL INTENTAR ACTUALIZAR TASA DE IMPUESTO (1) AL PRODUCTO:" + vbCrLf + xrow(1).ToString.Trim)
                                        End If
                                    Next

                                    xtb = New DataTable
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto,nombre from productos where impuesto='2'"
                                    dr = xcmd.ExecuteReader()
                                    xtb.Load(dr)

                                    For Each xrow As DataRow In xtb.Rows
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update productos set tasa=@tasa where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@tasa", xtasa2)
                                        xcmd.Parameters.AddWithValue("@auto", xrow(0).ToString)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL INTENTAR ACTUALIZAR TASA DE IMPUESTO (2) AL PRODUCTO:" + vbCrLf + xrow(1).ToString.Trim)
                                        End If
                                    Next

                                    xtb = New DataTable
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto,nombre from productos where impuesto='3'"
                                    dr = xcmd.ExecuteReader()
                                    xtb.Load(dr)

                                    For Each xrow As DataRow In xtb.Rows
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update productos set tasa=@tasa where auto=@auto"
                                        xcmd.Parameters.AddWithValue("@tasa", xtasa3)
                                        xcmd.Parameters.AddWithValue("@auto", xrow(0).ToString)
                                        xr = xcmd.ExecuteNonQuery()
                                        If xr = 0 Then
                                            Throw New Exception("ERROR AL INTENTAR ACTUALIZAR TASA DE IMPUESTO (3) AL PRODUCTO:" + vbCrLf + xrow(1).ToString.Trim)
                                        End If
                                    Next

                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                        Return True
                    Catch ex As Exception
                        Throw New Exception("TASAS FISCALES" + vbCrLf + "ACTUALIZAR TASAS FISCALES." + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Cargar Data Al Registro De la Clase
                ''' </summary>
                Function F_CargarTasasFiscales() As Boolean
                    Try
                        Dim xsql As String = Select_1
                        Me.M_Limpiar_Tabla()
                        Using xadap As New SqlDataAdapter(xsql, _MiCadenaConexion)
                            xadap.Fill(Me.TablaFiscal)
                        End Using
                        Me.M_CargarFicha()
                        Return True
                    Catch ex As Exception
                        Throw New Exception("TASAS FISCALES" + vbCrLf + "CARGAR TASAS FISCALES:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: FICHA DEL NEGOCIO
            ''' </summary>
            Class c_Negocio
                Event Actualizar()

                ''' <summary>
                ''' Clase Usada Para Actualizar data Del Negocio
                ''' </summary>
                Public Class c_RegistroActualizar
                    Private xregistro As c_Registro

                    ''' <summary>
                    ''' Funcion: Retorna El Registro de Movimiento 
                    ''' </summary>
                    Protected Friend Property RegistroMov() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroMov.c_IdSeguridad = value
                        End Set
                    End Property

                    WriteOnly Property _RazonSocial() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_RazonSocial.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DireccionFiscal() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_DireccionFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _RIF() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_RIF.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Sucursal() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Sucursal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoSucursal() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_CodigoSucursal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _ContactarA() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_ContactarA.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Email.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _WebSite() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_WebSite.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_1() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Telefono_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_2() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Telefono_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_3() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Telefono_3.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Telefono_4() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Telefono_4.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Fax_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Fax_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Celular_1.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_Celular_2.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _DirReferencia() As String
                        Set(ByVal value As String)
                            Me.RegistroMov.c_DirReferencia.c_Texto = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroMov = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Public Class c_Registro
                    Private f_nombre As CampoTexto
                    Private f_direccion As CampoTexto
                    Private f_rif As CampoTexto
                    Private f_clave1 As CampoTexto
                    Private f_clave2 As CampoTexto
                    Private f_clave3 As CampoTexto
                    Private f_telefono As CampoTexto
                    Private f_sucursal As CampoTexto
                    Private f_codigo_sucursal As CampoTexto
                    Private f_nit As CampoTexto
                    Private f_contacto As CampoTexto
                    Private f_fax As CampoTexto
                    Private f_email As CampoTexto
                    Private f_website As CampoTexto
                    Private f_registro As CampoTexto
                    Private f_telefono_1 As CampoTexto
                    Private f_telefono_2 As CampoTexto
                    Private f_telefono_3 As CampoTexto
                    Private f_telefono_4 As CampoTexto
                    Private f_fax_1 As CampoTexto
                    Private f_fax_2 As CampoTexto
                    Private f_celular_1 As CampoTexto
                    Private f_celular_2 As CampoTexto
                    Private f_direccion_referencia As CampoTexto
                    Private f_id_seguridad As Byte()

                    ''' <summary>
                    ''' Campo ID DE SEGURIDAD PARA VALIDAR REGISTRO AL SER MODIFICADO
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
                    ''' Campo Nombre Del Negocio
                    ''' </summary>
                    Property c_RazonSocial() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Direccion Fiscal
                    ''' </summary>
                    Property c_DireccionFiscal() As CampoTexto
                        Get
                            Return f_direccion
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_direccion = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo RIF Del Negocio
                    ''' </summary>
                    Property c_RIF() As CampoTexto
                        Get
                            Return f_rif
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_rif = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Clave 1
                    ''' </summary>
                    Property c_Clave_1() As CampoTexto
                        Get
                            Return f_clave1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_clave1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Clave 2
                    ''' </summary>
                    Property c_Clave_2() As CampoTexto
                        Get
                            Return f_clave2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_clave2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Clave 3
                    ''' </summary>
                    Property c_Clave_3() As CampoTexto
                        Get
                            Return f_clave3
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_clave3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Telefono
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
                    ''' Campo Sucursal
                    ''' </summary>
                    Property c_Sucursal() As CampoTexto
                        Get
                            Return f_sucursal
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_sucursal = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Codigo De La Sucursal
                    ''' </summary>
                    Property c_CodigoSucursal() As CampoTexto
                        Get
                            Return f_codigo_sucursal
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo_sucursal = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo NIT
                    ''' </summary>
                    Property c_NIT() As CampoTexto
                        Get
                            Return f_nit
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nit = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Persona De Contacto
                    ''' </summary>
                    Property c_ContactarA() As CampoTexto
                        Get
                            Return f_contacto
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_contacto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Numero De Fax
                    ''' </summary>
                    Property c_Fax() As CampoTexto
                        Get
                            Return f_fax
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Email
                    ''' </summary>
                    Property c_Email() As CampoTexto
                        Get
                            Return f_email
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_email = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Ubicacion WebSite
                    ''' </summary>
                    Property c_WebSite() As CampoTexto
                        Get
                            Return f_website
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_website = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Registro Del Sistema
                    ''' </summary>
                    Property c_Registro() As CampoTexto
                        Get
                            Return f_registro
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_registro = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Telefono_1
                    ''' </summary>
                    Property c_Telefono_1() As CampoTexto
                        Get
                            Return f_telefono_1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Telefono_2
                    ''' </summary>
                    Property c_Telefono_2() As CampoTexto
                        Get
                            Return f_telefono_2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Telefono_3
                    ''' </summary>
                    Property c_Telefono_3() As CampoTexto
                        Get
                            Return f_telefono_3
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_3 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Telefono_4
                    ''' </summary>
                    Property c_Telefono_4() As CampoTexto
                        Get
                            Return f_telefono_4
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_telefono_4 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Fax_1
                    ''' </summary>
                    Property c_Fax_1() As CampoTexto
                        Get
                            Return f_fax_1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax_1 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Fax_2
                    ''' </summary>
                    Property c_Fax_2() As CampoTexto
                        Get
                            Return f_fax_2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_fax_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Celular_1
                    ''' </summary>
                    Property c_Celular_1() As CampoTexto
                        Get
                            Return f_celular_1
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular_1 = value
                        End Set
                    End Property
                    ''' <summary>
                    ''' Campo Celular_2
                    ''' </summary>
                    Property c_Celular_2() As CampoTexto
                        Get
                            Return f_celular_2
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_celular_2 = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Direccion De Referencia
                    ''' </summary>
                    Property c_DirReferencia() As CampoTexto
                        Get
                            Return f_direccion_referencia
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_direccion_referencia = value
                        End Set
                    End Property

                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    ReadOnly Property _RazonSocial() As String
                        Get
                            Return Me.c_RazonSocial.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _DireccionFiscal() As String
                        Get
                            Return f_direccion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _RIF() As String
                        Get
                            Return f_rif.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Clave_1() As String
                        Get
                            Return f_clave1.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Clave_2() As String
                        Get
                            Return f_clave2.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Clave_3() As String
                        Get
                            Return f_clave3.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Telefono() As String
                        Get
                            Return f_telefono.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Sucursal() As String
                        Get
                            Return f_sucursal.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoSucursal() As String
                        Get
                            Return f_codigo_sucursal.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NIT() As String
                        Get
                            Return f_nit.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _ContactarA() As String
                        Get
                            Return f_contacto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Fax() As String
                        Get
                            Return f_fax.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Email() As String
                        Get
                            Return f_email.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _WebSite() As String
                        Get
                            Return f_website.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Registro() As String
                        Get
                            Return f_registro.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Telefono_1() As String
                        Get
                            Return f_telefono_1.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Telefono_2() As String
                        Get
                            Return f_telefono_2.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Telefono_3() As String
                        Get
                            Return f_telefono_3.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Telefono_4() As String
                        Get
                            Return f_telefono_4.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Fax_1() As String
                        Get
                            Return f_fax_1.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Fax_2() As String
                        Get
                            Return f_fax_2.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Celular_1() As String
                        Get
                            Return f_celular_1.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _Celular_2() As String
                        Get
                            Return f_celular_2.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _DirReferencia() As String
                        Get
                            Return f_direccion_referencia.c_Texto.Trim
                        End Get
                    End Property

                    Sub New()
                        Me.c_Celular_1 = New CampoTexto(14, "celular_1")
                        Me.c_Celular_2 = New CampoTexto(14, "celular_2")
                        Me.c_Clave_1 = New CampoTexto(15, "clave1")
                        Me.c_Clave_2 = New CampoTexto(15, "clave2")
                        Me.c_Clave_3 = New CampoTexto(15, "clave3")
                        Me.c_CodigoSucursal = New CampoTexto(10, "codigo_sucursal")
                        Me.c_ContactarA = New CampoTexto(60, "contacto")
                        Me.c_DireccionFiscal = New CampoTexto(120, "direccion")
                        Me.c_DirReferencia = New CampoTexto(200, "direccion_referencia")
                        Me.c_Email = New CampoTexto(60, "email")
                        Me.c_Fax = New CampoTexto(60, "fax")
                        Me.c_Fax_1 = New CampoTexto(14, "fax_1")
                        Me.c_Fax_2 = New CampoTexto(14, "fax_2")
                        Me.c_NIT = New CampoTexto(15, "nit")
                        Me.c_RazonSocial = New CampoTexto(120, "nombre")
                        Me.c_Registro = New CampoTexto(100, "registro")
                        Me.c_RIF = New CampoTexto(15, "rif")
                        Me.c_Sucursal = New CampoTexto(60, "sucursal")
                        Me.c_Telefono = New CampoTexto(60, "telefono")
                        Me.c_Telefono_1 = New CampoTexto(14, "telefono_1")
                        Me.c_Telefono_2 = New CampoTexto(14, "telefono_2")
                        Me.c_Telefono_3 = New CampoTexto(14, "telefono_3")
                        Me.c_Telefono_4 = New CampoTexto(14, "telefono_4")
                        Me.c_WebSite = New CampoTexto(60, "website")

                        LimpiarRegistro()
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_Clave_1.c_Texto = xrow(.c_Clave_1.c_NombreInterno)
                                .c_Clave_2.c_Texto = xrow(.c_Clave_2.c_NombreInterno)
                                .c_Clave_3.c_Texto = xrow(.c_Clave_3.c_NombreInterno)
                                .c_CodigoSucursal.c_Texto = xrow(.c_CodigoSucursal.c_NombreInterno)
                                .c_ContactarA.c_Texto = xrow(.c_ContactarA.c_NombreInterno)
                                .c_DireccionFiscal.c_Texto = xrow(.c_DireccionFiscal.c_NombreInterno)
                                .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                                .c_Fax.c_Texto = xrow(.c_Fax.c_NombreInterno)
                                .c_NIT.c_Texto = xrow(.c_NIT.c_NombreInterno)
                                .c_RazonSocial.c_Texto = xrow(.c_RazonSocial.c_NombreInterno)
                                .c_Registro.c_Texto = xrow(.c_Registro.c_NombreInterno)
                                .c_RIF.c_Texto = xrow(.c_RIF.c_NombreInterno)
                                .c_Sucursal.c_Texto = xrow(.c_Sucursal.c_NombreInterno)
                                .c_Telefono.c_Texto = xrow(.c_Telefono.c_NombreInterno)
                                .c_WebSite.c_Texto = xrow(.c_WebSite.c_NombreInterno)

                                If Not IsDBNull(xrow(.c_Telefono_1.c_NombreInterno)) Then
                                    .c_Telefono_1.c_Texto = xrow(.c_Telefono_1.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Telefono_2.c_NombreInterno)) Then
                                    .c_Telefono_2.c_Texto = xrow(.c_Telefono_2.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Telefono_3.c_NombreInterno)) Then
                                    .c_Telefono_3.c_Texto = xrow(.c_Telefono_3.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Telefono_4.c_NombreInterno)) Then
                                    .c_Telefono_4.c_Texto = xrow(.c_Telefono_4.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Fax_1.c_NombreInterno)) Then
                                    .c_Fax_1.c_Texto = xrow(.c_Fax_1.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Fax_2.c_NombreInterno)) Then
                                    .c_Fax_2.c_Texto = xrow(.c_Fax_2.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Celular_1.c_NombreInterno)) Then
                                    .c_Celular_1.c_Texto = xrow(.c_Celular_1.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_Celular_2.c_NombreInterno)) Then
                                    .c_Celular_2.c_Texto = xrow(.c_Celular_2.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow(.c_DirReferencia.c_NombreInterno)) Then
                                    .c_DirReferencia.c_Texto = xrow(.c_DirReferencia.c_NombreInterno).ToString
                                End If
                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("EMPRESA" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                ''' <summary>
                ''' Instrucciones Sql 
                ''' </summary>
                Const Update_1 As String = "update empresa set " _
                  + "nombre=@nombre, direccion=@direccion, rif=@rif, telefono=@telefono, sucursal=@sucursal, codigo_sucursal=@codigo_sucursal," _
                  + "nit=@nit, contacto=@contacto, fax=@fax, email=@email, website=@website, telefono_1=@telefono_1, telefono_2=@telefono_2," _
                  + "telefono_3=@telefono_3, telefono_4=@telefono_4, fax_1=@fax_1, fax_2=@fax_2, celular_1=@celular_1, celular_2=@celular_2," _
                  + "direccion_referencia=@direccion_referencia where id_seguridad=@id_seguridad"
                Const Select_1 As String = "select * from empresa"

                Private xtabla As DataTable
                Private xregistro As c_Registro

                Sub New()
                    xregistro = New c_Registro
                    xtabla = New DataTable("EMPRESA")
                End Sub

                ''' <summary>
                ''' Clase Registro De Dato
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
                ''' Tabla A Almacenar Registro
                ''' </summary>
                Property TablaEmpresa() As DataTable
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
                ''' Metodo: Cargar Data A La Ficha De Registro
                ''' </summary>
                Sub M_CargarRegistro(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                ''' <summary>
                ''' Funcion: Permite Actualizar Solo Datos Referentes a La Ficha Del Negocio
                ''' </summary>
                Function F_ActualizarDataNegocio(ByVal xregistro As c_RegistroActualizar) As Boolean
                    Dim x As Integer = 0
                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand(Update_1, xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@celular_1", xregistro.RegistroMov.c_Celular_1.c_Texto)
                                    xcmd.Parameters.AddWithValue("@celular_2", xregistro.RegistroMov.c_Celular_2.c_Texto)
                                    xcmd.Parameters.AddWithValue("@codigo_sucursal", xregistro.RegistroMov.c_CodigoSucursal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@contacto", xregistro.RegistroMov.c_ContactarA.c_Texto)
                                    xcmd.Parameters.AddWithValue("@direccion", xregistro.RegistroMov.c_DireccionFiscal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@direccion_referencia", xregistro.RegistroMov.c_DirReferencia.c_Texto)
                                    xcmd.Parameters.AddWithValue("@email", xregistro.RegistroMov.c_Email.c_Texto)
                                    xcmd.Parameters.AddWithValue("@fax", xregistro.RegistroMov.c_Fax.c_Texto)
                                    xcmd.Parameters.AddWithValue("@fax_1", xregistro.RegistroMov.c_Fax_1.c_Texto)
                                    xcmd.Parameters.AddWithValue("@fax_2", xregistro.RegistroMov.c_Fax_2.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nit", xregistro.RegistroMov.c_NIT.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nombre", xregistro.RegistroMov.c_RazonSocial.c_Texto)
                                    xcmd.Parameters.AddWithValue("@rif", xregistro.RegistroMov.c_RIF.c_Texto)
                                    xcmd.Parameters.AddWithValue("@sucursal", xregistro.RegistroMov.c_Sucursal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@telefono", xregistro.RegistroMov.c_Telefono.c_Texto)
                                    xcmd.Parameters.AddWithValue("@telefono_1", xregistro.RegistroMov.c_Telefono_1.c_Texto)
                                    xcmd.Parameters.AddWithValue("@telefono_2", xregistro.RegistroMov.c_Telefono_2.c_Texto)
                                    xcmd.Parameters.AddWithValue("@telefono_3", xregistro.RegistroMov.c_Telefono_3.c_Texto)
                                    xcmd.Parameters.AddWithValue("@telefono_4", xregistro.RegistroMov.c_Telefono_4.c_Texto)
                                    xcmd.Parameters.AddWithValue("@website", xregistro.RegistroMov.c_WebSite.c_Texto)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xregistro.RegistroMov.c_IdSeguridad)
                                    x = xcmd.ExecuteNonQuery()
                                    If x = 0 Then
                                        Throw New Exception("Registro Ya Fue Actualizado Por Otro Usuario")
                                    End If
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("ACTUALIZAR DATA NEGOCIO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Cargar Data Al Registro De la Clase
                ''' </summary>
                Function F_CargarDataNegocio() As Boolean
                    Try
                        Me.M_Limpiar_Tabla()
                        Using xadap As New SqlDataAdapter(Select_1, _MiCadenaConexion)
                            xadap.Fill(Me.TablaEmpresa)
                        End Using
                        If Me.TablaEmpresa.Rows.Count = 0 Then
                            Throw New Exception("NO HAY UN REGISTRO DEFINIDO EN LA TABLA EMPRESA")
                        Else
                            Me.M_CargarRegistro(Me.TablaEmpresa.Rows(0))
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("CARGAR DATA DEL NEGOCIO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: FICHA DEL USUARIO - GRUPO 
            ''' </summary>
            Class c_Usuario
                Event ActualizarFicha()

                Class c_NuevoUsuario
                    Private xregisto As c_Registro

                    Protected Friend Property RegistroUsuario() As c_Registro
                        Get
                            Return xregisto
                        End Get
                        Set(ByVal value As c_Registro)
                            xregisto = value
                        End Set
                    End Property

                    Sub New()
                        Me.RegistroUsuario = New c_Registro
                    End Sub

                    WriteOnly Property _NombreUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroUsuario.c_UsuarioNombre.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _ClaveUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroUsuario.c_UsuarioClave.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroUsuario.c_UsuarioCodigo.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutoGrupo() As String
                        Set(ByVal value As String)
                            Me.RegistroUsuario.c_GrupoAuto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _EstatusUsuario() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Activo Then
                                Me.RegistroUsuario.c_UsuarioEstatus.c_Texto = "Activo"
                            Else
                                Me.RegistroUsuario.c_UsuarioEstatus.c_Texto = "Inactivo"
                            End If
                        End Set
                    End Property
                End Class

                Class c_ModificaUsuario
                    Inherits c_NuevoUsuario

                    Sub New()
                        MyBase.New()
                    End Sub

                    WriteOnly Property _AutoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroUsuario.c_UsuarioAuto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroUsuario.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_clave As CampoTexto
                    Private f_codigo_grupo As CampoTexto
                    Private f_codigo As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_estatus_replica As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private _relacion_usuario_vendedor As UsuarioVendedor

                    ''' <summary>
                    ''' Campo Automatico Del Usuario
                    ''' </summary>
                    Protected Friend Property c_UsuarioAuto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoUsuario() As String
                        Get
                            Return Me.c_UsuarioAuto.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Nombre Del Usuario
                    ''' </summary>
                    Property c_UsuarioNombre() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return Me.c_UsuarioNombre.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Clave Del Usuario
                    ''' </summary>
                    Property c_UsuarioClave() As CampoTexto
                        Get
                            Return f_clave
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_clave = value
                        End Set
                    End Property

                    ReadOnly Property _ClaveUsuario() As String
                        Get
                            Return Me.c_UsuarioClave.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Automatico Del Grupo Al Cual Pertenece El Usuario
                    ''' </summary>
                    Protected Friend Property c_GrupoAuto() As CampoTexto
                        Get
                            Return f_codigo_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_grupo = value
                        End Set
                    End Property

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_GrupoAuto.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Codigo Del Usuario
                    ''' </summary>
                    Property c_UsuarioCodigo() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoUsuario() As String
                        Get
                            Return Me.c_UsuarioCodigo.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Estatus Del Usuario 
                    ''' </summary>
                    Protected Friend Property c_UsuarioEstatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ReadOnly Property _TipoEstatus() As TipoEstatus
                        Get
                            If Me.c_UsuarioEstatus.c_Texto.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Replica 
                    ''' </summary>
                    Protected Friend Property c_UsuarioReplica() As CampoTexto
                        Get
                            Return f_estatus_replica
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_replica = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Evalua: Si Esta / No Replicado El Usuario
                    ''' </summary>
                    ReadOnly Property _TipoReplicado() As TipoSiNo
                        Get
                            If Me.c_UsuarioEstatus.c_Texto.ToUpper = "1" Then
                                Return TipoSiNo.Si
                            Else
                                Return TipoSiNo.No
                            End If
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Dim xp1 As New SqlParameter("@auto", Me._AutoGrupo)
                            Return F_GetString("select nombre from grupo_usuario where auto=@auto", xp1)
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

                    Property R_UsuarioVendedor() As UsuarioVendedor
                        Get
                            Return _relacion_usuario_vendedor
                        End Get
                        Set(ByVal value As UsuarioVendedor)
                            _relacion_usuario_vendedor = value
                        End Set
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.c_UsuarioAuto = New CampoTexto(10, "auto")
                        Me.c_UsuarioNombre = New CampoTexto(20, "nombre")
                        Me.c_UsuarioClave = New CampoTexto(20, "clave")
                        Me.c_GrupoAuto = New CampoTexto(10, "codigo_grupo")
                        Me.c_UsuarioCodigo = New CampoTexto(10, "codigo")
                        Me.c_UsuarioEstatus = New CampoTexto(10, "estatus")
                        Me.c_UsuarioReplica = New CampoTexto(1, "estatus_replica")
                        Me.R_UsuarioVendedor = Nothing
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_GrupoAuto.c_Texto = xrow(.c_GrupoAuto.c_NombreInterno)
                                .c_UsuarioAuto.c_Texto = xrow(.c_UsuarioAuto.c_NombreInterno)
                                .c_UsuarioClave.c_Texto = xrow(.c_UsuarioClave.c_NombreInterno)
                                .c_UsuarioCodigo.c_Texto = xrow(.c_UsuarioCodigo.c_NombreInterno)
                                .c_UsuarioEstatus.c_Texto = xrow(.c_UsuarioEstatus.c_NombreInterno)
                                .c_UsuarioNombre.c_Texto = xrow(.c_UsuarioNombre.c_NombreInterno)
                                .c_UsuarioReplica.c_Texto = xrow(.c_UsuarioReplica.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If

                                Try
                                    Dim xusuario_vendedor As New UsuarioVendedor
                                    xusuario_vendedor.F_BuscarCargar(._AutoUsuario)
                                    Me.R_UsuarioVendedor = xusuario_vendedor
                                Catch ex As Exception
                                    Me.R_UsuarioVendedor = Nothing
                                End Try
                            End With
                        Catch ex As Exception
                            Throw New Exception("USUARIOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private Const Insert_1 As String = "update contadores set a_usuarios=a_usuarios+1; select a_usuarios from contadores"

                Private Const Insert_2 As String = "INSERT INTO usuarios (" _
                    + "auto," _
                    + "nombre," _
                    + "clave," _
                    + "codigo_grupo," _
                    + "codigo," _
                    + "estatus," _
                    + "estatus_replica) " _
                    + "VALUES (" _
                    + "@auto," _
                    + "@nombre," _
                    + "@clave," _
                    + "@codigo_grupo," _
                    + "@codigo," _
                    + "@estatus," _
                    + "@estatus_replica)"

                Private Const Update_1 As String = "update usuarios set " _
                   + "nombre=@NOMBRE," _
                   + "clave=@CLAVE," _
                   + "codigo=@codigo," _
                   + "codigo_grupo=@CODIGO_GRUPO," _
                   + "estatus=@ESTATUS " _
                   + "WHERE AUTO=@AUTO and id_seguridad=@id_seguridad"

                Private Const EliminarRegistro As String = "delete USUARIOs where auto=@auto"

                Dim xregistro As c_Registro
                Dim xtabla As DataTable

                Sub New()
                    xregistro = New c_Registro
                    xtabla = New DataTable("USUARIOS")
                End Sub

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
                            xadap.SelectCommand.CommandText = "select * from usuarios where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("USUARIO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("USUARIO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminaRegistro(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                If xauto = "0000000001" Then
                                    Throw New Exception("ERROR AL ELIMINAR USUARIO, USUARIO SUPERVISOR NO PUEDE SER ELIMINADO")
                                Else
                                    Using xcmd As New SqlCommand(EliminarRegistro, xcon)
                                        xcmd.Parameters.AddWithValue("@auto", xauto)
                                        xcmd.ExecuteNonQuery()
                                    End Using
                                    RaiseEvent ActualizarFicha()
                                    Return True
                                End If
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR USUARIO, EXISTEN MOVIMIENTOS PARA ESTE USUARIO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("USUARIO" + vbCrLf + "ELIMINAR USUARIO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_IngresaRegistro(ByVal xusernuevo As c_NuevoUsuario) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_1
                                    xusernuevo.RegistroUsuario.c_UsuarioAuto.c_Texto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")
                                    xusernuevo.RegistroUsuario.c_UsuarioReplica.c_Texto = "0"
                                    If xusernuevo.RegistroUsuario.c_UsuarioCodigo.c_Texto.Trim = "" Then
                                        xusernuevo.RegistroUsuario.c_UsuarioCodigo.c_Texto = xusernuevo.RegistroUsuario.c_UsuarioNombre.c_Texto
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", xusernuevo.RegistroUsuario.c_UsuarioAuto.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioAuto.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xusernuevo.RegistroUsuario.c_UsuarioNombre.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioNombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@clave", xusernuevo.RegistroUsuario.c_UsuarioClave.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioClave.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_grupo", xusernuevo.RegistroUsuario.c_GrupoAuto.c_Texto).Size = xusernuevo.RegistroUsuario.c_GrupoAuto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xusernuevo.RegistroUsuario.c_UsuarioCodigo.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioCodigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xusernuevo.RegistroUsuario.c_UsuarioEstatus.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioEstatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus_replica", xusernuevo.RegistroUsuario.c_UsuarioReplica.c_Texto).Size = xusernuevo.RegistroUsuario.c_UsuarioReplica.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR USUARIO, EXISTE UN USUARIO CON EL MISMO NOMBRE/CODIGO")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR USUARIO, AUTOMATICO DEL USUARIO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("USUARIO" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificaRegistro(ByVal xuser As c_ModificaUsuario) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0
                                If xuser.RegistroUsuario.c_UsuarioCodigo.c_Texto.Trim = "" Then
                                    xuser.RegistroUsuario.c_UsuarioCodigo.c_Texto = xuser.RegistroUsuario.c_UsuarioNombre.c_Texto
                                End If

                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xuser.RegistroUsuario.c_UsuarioAuto.c_Texto).Size = xuser.RegistroUsuario.c_UsuarioAuto.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xuser.RegistroUsuario.c_UsuarioNombre.c_Texto).Size = xuser.RegistroUsuario.c_UsuarioNombre.c_Largo
                                    xcmd.Parameters.AddWithValue("@clave", xuser.RegistroUsuario.c_UsuarioClave.c_Texto).Size = xuser.RegistroUsuario.c_UsuarioClave.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo_grupo", xuser.RegistroUsuario.c_GrupoAuto.c_Texto).Size = xuser.RegistroUsuario.c_GrupoAuto.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xuser.RegistroUsuario.c_UsuarioCodigo.c_Texto).Size = xuser.RegistroUsuario.c_UsuarioCodigo.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xuser.RegistroUsuario.c_UsuarioEstatus.c_Texto).Size = xuser.RegistroUsuario.c_UsuarioEstatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xuser.RegistroUsuario.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR USUARIO, FICHA HA SIDO ACTUALIZADO POR OTRO USUARIO")
                                End If
                                RaiseEvent ActualizarFicha()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR USUARIO, EXISTE UN USUARIO CON EL MISMO NOMBRE/CODIGO")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("USUARIO" + vbCrLf + "MODIFICAR USUARIO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_BuscarUsuarioPorCodigo(ByVal xcodigo As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from usuarios where codigo=@codigo"
                            xadap.SelectCommand.Parameters.AddWithValue("@codigo", xcodigo)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else

                            Throw New Exception("USUARIO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("USUARIO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: FICHA SERIES FISCALES 
            ''' </summary>
            Class c_SeriesFiscales
                Event Actualizar()

                Enum ModoBusquedaSerieFiscal As Integer
                    Automatico = 1
                    NombreSerie = 2
                End Enum

                ''' <summary>
                ''' Clase Usada Para Agregar Un Nuevo Registro
                ''' </summary>
                Class c_RegistroMovimientoAgregar
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroMov() As c_Registro
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

                    WriteOnly Property _PreFijoSerie() As String
                        Set(ByVal value As String)
                            xregistro.c_PreFijoSerie.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Correlativo() As Integer
                        Set(ByVal value As Integer)
                            xregistro.c_CorrelativoSerie.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusFiscal() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusFiscal.c_Texto = "0"
                            Else
                                xregistro.c_EstatusFiscal.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaVentas() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusVenta.c_Texto = "0"
                            Else
                                xregistro.c_EstatusVenta.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaNC() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusNC.c_Texto = "0"
                            Else
                                xregistro.c_EstatusNC.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaND() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusND.c_Texto = "0"
                            Else
                                xregistro.c_EstatusND.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaNE() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusNE.c_Texto = "0"
                            Else
                                xregistro.c_EstatusNE.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusSerie() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusSerie.c_Texto = "Inactivo"
                            Else
                                xregistro.c_EstatusSerie.c_Texto = "Activo"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _SerialFiscal() As String
                        Set(ByVal value As String)
                            xregistro.c_SerialFiscal.c_Texto = value
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase Usada Para Modificar Un Registro
                ''' </summary>
                Class c_RegistroMovimientoEditar
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroMov() As c_Registro
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

                    WriteOnly Property _PreFijoSerie() As String
                        Set(ByVal value As String)
                            xregistro.c_PreFijoSerie.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _Correlativo() As Integer
                        Set(ByVal value As Integer)
                            xregistro.c_CorrelativoSerie.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaVentas() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusVenta.c_Texto = "0"
                            Else
                                xregistro.c_EstatusVenta.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaNC() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusNC.c_Texto = "0"
                            Else
                                xregistro.c_EstatusNC.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaND() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusND.c_Texto = "0"
                            Else
                                xregistro.c_EstatusND.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusParaNE() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusNE.c_Texto = "0"
                            Else
                                xregistro.c_EstatusNE.c_Texto = "1"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _EstatusSerie() As TipoEstatus
                        Set(ByVal value As TipoEstatus)
                            If value = TipoEstatus.Inactivo Then
                                xregistro.c_EstatusSerie.c_Texto = "Inactivo"
                            Else
                                xregistro.c_EstatusSerie.c_Texto = "Activo"
                            End If
                        End Set
                    End Property

                    WriteOnly Property _SerialFiscal() As String
                        Set(ByVal value As String)
                            xregistro.c_SerialFiscal.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            xregistro.c_IdSeguridad = value
                        End Set
                    End Property
                End Class

                ''' <summary>
                ''' Clase Registro De Dato
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_correlativo As CampoInteger
                    Private f_estatus_fiscal As CampoTexto
                    Private f_estatus_venta As CampoTexto
                    Private f_estatus_nd As CampoTexto
                    Private f_estatus_nc As CampoTexto
                    Private f_estatus_ne As CampoTexto
                    Private f_nrf As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_id_seguridad As Byte()
                    Private xseleccion As List(Of String)

                    ''' <summary>
                    ''' Campo Automatico De la Serie
                    ''' </summary>
                    Protected Friend Property c_AutomaticoSerie() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo PreFijo Asigando A La Serie
                    ''' </summary>
                    Property c_PreFijoSerie() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property r_PrefijoSerie() As String
                        Get
                            Return Me.c_PreFijoSerie.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Numero Correlativo Que Lleva La Serie
                    ''' </summary>
                    Protected Friend Property c_CorrelativoSerie() As CampoInteger
                        Get
                            Return f_correlativo
                        End Get
                        Set(ByVal value As CampoInteger)
                            f_correlativo = value
                        End Set
                    End Property

                    ReadOnly Property r_CorrelativoSerie() As Integer
                        Get
                            Return Me.c_CorrelativoSerie.c_Valor
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si La Serie Tiene o No Movimientos Efectuados
                    ''' </summary>
                    Protected Friend Property c_EstatusFiscal() As CampoTexto
                        Get
                            Return f_estatus_fiscal
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_fiscal = value
                        End Set
                    End Property

                    ReadOnly Property r_EstatusFiscal() As HayMovimientos
                        Get
                            If Me.c_EstatusFiscal.c_Texto.Trim.ToUpper = "1" Then
                                Return HayMovimientos.SiHay
                            Else
                                Return HayMovimientos.NoHay
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Se Activa Documentos De Ventas Para Esta Serie
                    ''' </summary>
                    Protected Friend Property c_EstatusVenta() As CampoTexto
                        Get
                            Return f_estatus_venta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_venta = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Se Activa Documentos De Notas De Credito Para Esta Serie
                    ''' </summary>
                    Protected Friend Property c_EstatusNC() As CampoTexto
                        Get
                            Return f_estatus_nc
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_nc = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Se Activa Documentos De Notas De Debito Para Esta Serie
                    ''' </summary>
                    Protected Friend Property c_EstatusND() As CampoTexto
                        Get
                            Return f_estatus_nd
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_nd = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Si Se Activa Documentos De Notas De Entrega Para Esta Serie
                    ''' </summary>
                    Protected Friend Property c_EstatusNE() As CampoTexto
                        Get
                            Return f_estatus_ne
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_ne = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica el Estatus De la Serie
                    ''' </summary>
                    Protected Friend Property c_EstatusSerie() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo Indica Numero De Serial Fiscal Asignado A Esta Serie 
                    ''' </summary>
                    Property c_SerialFiscal() As CampoTexto
                        Get
                            Return f_nrf
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nrf = value
                        End Set
                    End Property

                    ReadOnly Property r_SerialFiscal() As String
                        Get
                            Return Me.c_SerialFiscal.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Campo Indica El Id De Seguridad
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
                    ''' Funcion: Retorna El Automatico De La Serie
                    ''' </summary>
                    ReadOnly Property r_AutomaticoSerie() As String
                        Get
                            Return Me.c_AutomaticoSerie.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Seria Para Doc De Ventas
                    ''' </summary>
                    ReadOnly Property r_EstatusParaVentas() As TipoEstatus
                        Get
                            If Me.c_EstatusVenta.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Seria Para Doc De NC
                    ''' </summary>
                    ReadOnly Property r_EstatusParaNC() As TipoEstatus
                        Get
                            If Me.c_EstatusNC.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Seria Para Doc De ND
                    ''' </summary>
                    ReadOnly Property r_EstatusParaND() As TipoEstatus
                        Get
                            If Me.c_EstatusND.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Seria Para Doc De NE
                    ''' </summary>
                    ReadOnly Property r_EstatusParaNE() As TipoEstatus
                        Get
                            If Me.c_EstatusNE.c_Texto.Trim.ToUpper = "1" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Estatus Para La Serie
                    ''' </summary>
                    ReadOnly Property r_EstatusSerie() As TipoEstatus
                        Get
                            If Me.c_EstatusSerie.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Id Seguridad Para La Serie
                    ''' </summary>
                    ReadOnly Property r_IdSeguridad() As Byte()
                        Get
                            Return Me.c_IdSeguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna Lista De Valor Posibles Para La Seleccion
                    ''' </summary>
                    ReadOnly Property r_ListaOpciones() As String()
                        Get
                            Return xseleccion.ToArray
                        End Get
                    End Property

                    Sub New()
                        xseleccion = New List(Of String)
                        xseleccion.Add("Activo")
                        xseleccion.Add("Inactivo")

                        Me.c_AutomaticoSerie = New CampoTexto
                        Me.c_CorrelativoSerie = New CampoInteger
                        Me.c_EstatusFiscal = New CampoTexto
                        Me.c_EstatusNC = New CampoTexto
                        Me.c_EstatusND = New CampoTexto
                        Me.c_EstatusNE = New CampoTexto
                        Me.c_EstatusSerie = New CampoTexto
                        Me.c_EstatusVenta = New CampoTexto
                        Me.c_PreFijoSerie = New CampoTexto
                        Me.c_SerialFiscal = New CampoTexto
                        M_LimpiarRegistro()
                    End Sub

                    ''' <summary>
                    ''' Metodo: Limpiar Registro de Dato
                    ''' </summary>
                    Sub M_LimpiarRegistro()
                        With Me.c_AutomaticoSerie
                            .c_Largo = 10
                            .c_NombreInterno = "auto"
                            .c_Texto = ""
                        End With
                        With Me.c_CorrelativoSerie
                            .c_NombreInterno = "correlativo"
                            .c_Valor = 0
                        End With
                        With Me.c_EstatusFiscal
                            .c_Largo = 1
                            .c_NombreInterno = "estatus_fiscal"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusNC
                            .c_Largo = 1
                            .c_NombreInterno = "estatus_nc"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusND
                            .c_Largo = 1
                            .c_NombreInterno = "estatus_nd"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusNE
                            .c_Largo = 1
                            .c_NombreInterno = "estatus_ne"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusSerie
                            .c_Largo = 10
                            .c_NombreInterno = "estatus"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusVenta
                            .c_Largo = 1
                            .c_NombreInterno = "estatus_venta"
                            .c_Texto = ""
                        End With
                        With Me.c_PreFijoSerie
                            .c_Largo = 10
                            .c_NombreInterno = "nombre"
                            .c_Texto = ""
                        End With
                        With Me.c_SerialFiscal
                            .c_Largo = 10
                            .c_NombreInterno = "nrf"
                            .c_Texto = ""
                        End With
                    End Sub
                End Class

                Private xregistro As c_Registro

                ''' <summary>
                ''' Clase Registro De Dato
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
                ''' Metodo: Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xregistro As DataRow)
                    Try
                        Me.RegistroDato.M_LimpiarRegistro()
                        With Me.RegistroDato
                            .c_AutomaticoSerie.c_Texto = xregistro(.c_AutomaticoSerie.c_NombreInterno)
                            .c_CorrelativoSerie.c_Valor = xregistro(.c_CorrelativoSerie.c_NombreInterno)
                            .c_EstatusFiscal.c_Texto = xregistro(.c_EstatusFiscal.c_NombreInterno)
                            .c_EstatusNC.c_Texto = xregistro(.c_EstatusNC.c_NombreInterno)
                            .c_EstatusND.c_Texto = xregistro(.c_EstatusND.c_NombreInterno)
                            .c_EstatusNE.c_Texto = xregistro(.c_EstatusNE.c_NombreInterno)
                            .c_EstatusSerie.c_Texto = xregistro(.c_EstatusSerie.c_NombreInterno)
                            .c_EstatusVenta.c_Texto = xregistro(.c_EstatusVenta.c_NombreInterno)
                            .c_PreFijoSerie.c_Texto = xregistro(.c_PreFijoSerie.c_NombreInterno)
                            .c_SerialFiscal.c_Texto = xregistro(.c_SerialFiscal.c_NombreInterno)
                            .c_IdSeguridad = xregistro("id_seguridad")
                        End With
                    Catch ex As Exception
                        Throw New Exception("SERIES FISCALES." + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub New()
                    Me.RegistroDato = New c_Registro
                End Sub

                ''' <summary>
                ''' CONSTANTES 
                ''' INSTRUCCIONES SQL USADAS
                ''' </summary>
                Const Insert_1 As String = "update contadores set a_series_fiscales=a_series_fiscales+1;" _
                                            + "select a_series_fiscales from contadores"
                Const Insert_2 As String = "INSERT INTO series_fiscales ( " _
                                   + "auto," _
                                   + "nombre," _
                                   + "correlativo," _
                                   + "estatus_fiscal," _
                                   + "estatus_venta," _
                                   + "estatus_nd," _
                                   + "estatus_nc," _
                                   + "estatus_ne," _
                                   + "nrf," _
                                   + "estatus) " _
                                   + "VALUES (" _
                                   + "@auto," _
                                   + "@nombre," _
                                   + "@correlativo," _
                                   + "@estatus_fiscal," _
                                   + "@estatus_venta," _
                                   + "@estatus_nd," _
                                   + "@estatus_nc," _
                                   + "@estatus_ne," _
                                   + "@nrf," _
                                   + "@estatus)"

                Const Delete_1 As String = "delete series_fiscales where auto=@auto and estatus_fiscal<>'1'"

                Const Update_1 As String = "UPDATE series_fiscales SET " _
                                   + "nombre=@nombre," _
                                   + "correlativo=@correlativo," _
                                   + "estatus_venta=@estatus_venta," _
                                   + "estatus_nd=@estatus_nd," _
                                   + "estatus_nc=@estatus_nc," _
                                   + "estatus_ne=@estatus_ne," _
                                   + "nrf=@nrf," _
                                   + "estatus=@estatus " _
                                   + "WHERE auto=@auto AND estatus_fiscal='0' and id_seguridad=@id_seguridad"

                ''' <summary>
                ''' Funcion: Permite Agregar Nuevo Registro Al Sistema
                ''' </summary>
                Function F_AgregarNuevaSerie(ByVal xserie As c_RegistroMovimientoAgregar) As Boolean
                    Try
                        Dim xauto As String = ""
                        Dim xtr As SqlTransaction = Nothing

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction

                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    xauto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@nombre", xserie.RegistroMov.c_PreFijoSerie.c_Texto)
                                    xcmd.Parameters.AddWithValue("@correlativo", xserie.RegistroMov.c_CorrelativoSerie.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estatus_fiscal", xserie.RegistroMov.c_EstatusFiscal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_venta", xserie.RegistroMov.c_EstatusVenta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_nd", xserie.RegistroMov.c_EstatusND.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_nc", xserie.RegistroMov.c_EstatusNC.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_ne", xserie.RegistroMov.c_EstatusNE.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nrf", xserie.RegistroMov.c_SerialFiscal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus", xserie.RegistroMov.c_EstatusSerie.c_Texto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Throw New Exception("PREFIJO DE SERIE YA REGISTRADO, VERIFIQUE")
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("SERIES FISCALES" + vbCrLf + "AGREGAR NUEVA SERIE" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Permite Eliminar Serie Del Sistema
                ''' </summary>
                Function F_EliminarSerie(ByVal xautomatico As String) As Boolean
                    Dim xr As Integer = 0
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand(Delete_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xautomatico)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("SERIE EN ESTADO ACTIVO, NO PUEDE SER ELIMINADA")
                                    End If
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("SERIES FISCALES" + vbCrLf + "ELIMINAR SERIE" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' Funcion: Permite Modificar - Editar Registro Del Sistema
                ''' </summary>
                Function F_ModificarSerie(ByVal xautomatico As String, ByVal xregistro As c_RegistroMovimientoEditar) As Boolean
                    Dim xr As Integer = 0
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand(Update_1, xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.Parameters.AddWithValue("@auto", xautomatico)
                                    xcmd.Parameters.AddWithValue("@nombre", xregistro.RegistroMov.c_PreFijoSerie.c_Texto)
                                    xcmd.Parameters.AddWithValue("@correlativo", xregistro.RegistroMov.c_CorrelativoSerie.c_Valor)
                                    xcmd.Parameters.AddWithValue("@estatus_venta", xregistro.RegistroMov.c_EstatusVenta.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_nd", xregistro.RegistroMov.c_EstatusND.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_nc", xregistro.RegistroMov.c_EstatusNC.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus_ne", xregistro.RegistroMov.c_EstatusNE.c_Texto)
                                    xcmd.Parameters.AddWithValue("@nrf", xregistro.RegistroMov.c_SerialFiscal.c_Texto)
                                    xcmd.Parameters.AddWithValue("@estatus", xregistro.RegistroMov.c_EstatusSerie.c_Texto)
                                    xcmd.Parameters.AddWithValue("@id_seguridad", xregistro.RegistroMov.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Dim xm As String = "POSIBLES ERRORES:" + vbCrLf _
                                                  + "1. SERIE YA TIENE MOVIMIENTOS EFECTUADOS Y NO PUEDE SER MODIFICADA" + vbCrLf _
                                                  + "2. SERIE YA FUE ACTUALIZADA POR OTRO USUARIO"
                                        Throw New Exception(xm)
                                    End If
                                End Using
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception("PREFIJO DE SERIE YA REGISTRADO")
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("SERIES FISCALES" + vbCrLf + "MODIFICAR SERIE" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                ''' BUSCA Y CARGA REGISTRO SERIE FISCAL
                ''' </summary>
                Function M_BuscarCargar(ByVal xbuscar As String, Optional ByVal xmodo As ModoBusquedaSerieFiscal = ModoBusquedaSerieFiscal.Automatico) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.Parameters.Clear()
                            If xmodo = ModoBusquedaSerieFiscal.Automatico Then
                                xadap.SelectCommand.CommandText = "select * from series_fiscales where auto=@auto"
                                xadap.SelectCommand.Parameters.AddWithValue("@auto", xbuscar)
                            Else
                                xadap.SelectCommand.CommandText = "select * from series_fiscales where nombre=@nombre"
                                xadap.SelectCommand.Parameters.AddWithValue("@nombre", xbuscar)
                            End If
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarFicha(xtb(0))
                        End If
                    Catch ex As Exception
                        Throw New Exception("BUSCAR Y CARGAR SERIES FISCALES:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: CONFIGURACION DEL SISTEMA
            ''' </summary>
            Class c_ConfSistema

                Public Class c_Registro
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_tipo As CampoTexto
                    Private f_valores As CampoTexto
                    Private f_defecto As CampoTexto
                    Private f_usuario As CampoTexto

                    ''' <summary>
                    ''' Campo, Codigo De la Opcion
                    ''' </summary>
                    Property c_CodigoOpcion() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Descripcion De La Opcion
                    ''' </summary>
                    Property c_NombreOpcion() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Tipo De Presentacion De La Opcion
                    ''' </summary>
                    Property c_TipoOpcion() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Valores Posibles A Manejar
                    ''' </summary>
                    Property c_ValoresAsignados() As CampoTexto
                        Get
                            Return f_valores
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_valores = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Valor Por Defecto A Cargar
                    ''' </summary>
                    Property c_ValorPorDefecto() As CampoTexto
                        Get
                            Return f_defecto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_defecto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Campo, Valor Seleccionado Por El Usuario
                    ''' </summary>
                    Property c_ValorSeleccionUsuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Funcion, Retorna El Codigo De La Opcion
                    ''' </summary>
                    ReadOnly Property r_CodigoOpcion() As String
                        Get
                            Return Me.c_CodigoOpcion.c_Texto.ToUpper
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion, Retorna Seleccion Del Usuario
                    ''' </summary>
                    ReadOnly Property r_SeleccionUsuario() As String
                        Get
                            Return Me.c_ValorSeleccionUsuario.c_Texto.ToUpper
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        With Me.c_CodigoOpcion
                            .c_Largo = 10
                            .c_NombreInterno = "codigo"
                            .c_Texto = ""
                        End With
                        With Me.c_NombreOpcion
                            .c_Largo = 120
                            .c_NombreInterno = "nombre"
                            .c_Texto = ""
                        End With
                        With Me.c_TipoOpcion
                            .c_Largo = 1
                            .c_NombreInterno = "tipo"
                            .c_Texto = ""
                        End With
                        With Me.c_ValoresAsignados
                            .c_Largo = 60
                            .c_NombreInterno = "valores"
                            .c_Texto = ""
                        End With
                        With Me.c_ValorPorDefecto
                            .c_Largo = 60
                            .c_NombreInterno = "defecto"
                            .c_Texto = ""
                        End With
                        With Me.c_ValorSeleccionUsuario
                            .c_Largo = 60
                            .c_NombreInterno = "usuario"
                            .c_Texto = ""
                        End With
                    End Sub

                    Sub New()
                        Me.c_CodigoOpcion = New CampoTexto
                        Me.c_NombreOpcion = New CampoTexto
                        Me.c_TipoOpcion = New CampoTexto
                        Me.c_ValoresAsignados = New CampoTexto
                        Me.c_ValorPorDefecto = New CampoTexto
                        Me.c_ValorSeleccionUsuario = New CampoTexto

                        M_LimpiarRegistro()
                    End Sub

                    Sub M_CargarFicha(ByVal xrow As DataRow)
                        Try
                            M_LimpiarRegistro()

                            Me.c_CodigoOpcion.c_Texto = xrow(Me.c_CodigoOpcion.c_NombreInterno)
                            Me.c_NombreOpcion.c_Texto = xrow(Me.c_NombreOpcion.c_NombreInterno)
                            Me.c_TipoOpcion.c_Texto = xrow(Me.c_TipoOpcion.c_NombreInterno)
                            Me.c_ValoresAsignados.c_Texto = xrow(Me.c_ValoresAsignados.c_NombreInterno)
                            Me.c_ValorPorDefecto.c_Texto = xrow(Me.c_ValorPorDefecto.c_NombreInterno)
                            Me.c_ValorSeleccionUsuario.c_Texto = xrow(Me.c_ValorSeleccionUsuario.c_NombreInterno)
                        Catch ex As Exception
                            Throw New Exception("CARGAR FICHA" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Class ConfModuloVentas
                    Enum OrdenImprimirItems
                        PorCodigo = 0
                        PorNombre = 1
                        PorDefecto = 2
                    End Enum

                    Private xruptura_por_existencia As Boolean
                    Private xconfirmar_eliminar_item As Boolean
                    Private xorden_al_imprimir_Items As OrdenImprimirItems
                    Private xagrupar_items_al_imprimir As Boolean
                    Private xruptura_credito_cliente As Boolean
                    Private xfacturar_precio_en_cero As Boolean
                    Private xabrir_doc_pendientes_de_otros As Boolean
                    Private xlimites_renglones As Integer
                    Private xdar_descuento_final As Boolean
                    Private xfacturar_por_debajo_costo As Boolean
                    Private xlimites_renglones_notas_entrega As Integer
                    Private xlimites_renglones_pedidos As Integer
                    Private xlimites_renglones_adm_documentos As Integer
                    Private xlimites_renglones_retenciones As Integer
                    Private xaceptar_anticipos_en_pedidos As Boolean
                    Private xaceptar_modosdepago_anticipos_nc As Boolean
                    Private ximprimirlinea_detalle_imp_fiscal As Boolean
                    Private xcantidad_dias_validos_para_trasladar_documento As Integer

                    'FACTURAR ORIGINAL
                    Private xfactura_medio_impresion As TipoImpresora
                    Private xfactura_formato As String
                    Private xfactura_ruta_imprersora As String

                    'NOTA DE CREDITO ORIGINAL
                    Private xnc_medio_impresion As TipoImpresora
                    Private xnc_formato As String
                    Private xnc_ruta_imprersora As String

                    Private xpresupuesto_modo_impresion As TipoImpresora
                    Private xnotaentrega_modo_impresion As TipoImpresora
                    Private xpedido_modo_impresion As TipoImpresora
                    Private xotros_modo_impresion As TipoImpresora 'DOCUMENTOS CHIMBO

                    'campos a definir para subdetalle impresora fiscal
                    Private xsubdetalle_fiscal_1 As String
                    Private xsubdetalle_fiscal_2 As String
                    Private xsubdetalle_fiscal_3 As String
                    Private xsubdetalle_fiscal_4 As String


                    Property _Ruptura_Por_Existencia() As Boolean
                        Get
                            Return xruptura_por_existencia
                        End Get
                        Set(ByVal value As Boolean)
                            xruptura_por_existencia = value
                        End Set
                    End Property

                    Property _Confirmar_Eliminar_Item() As Boolean
                        Get
                            Return xconfirmar_eliminar_item
                        End Get
                        Set(ByVal value As Boolean)
                            xconfirmar_eliminar_item = value
                        End Set
                    End Property

                    Property _Orden_Al_Imprimir_Items() As OrdenImprimirItems
                        Get
                            Return xorden_al_imprimir_Items
                        End Get
                        Set(ByVal value As OrdenImprimirItems)
                            xorden_al_imprimir_Items = value
                        End Set
                    End Property

                    Property _AgruparItems_Al_Impimir() As Boolean
                        Get
                            Return xagrupar_items_al_imprimir
                        End Get
                        Set(ByVal value As Boolean)
                            xagrupar_items_al_imprimir = value
                        End Set
                    End Property

                    Property _Ruptura_Por_CreditoCliente() As Boolean
                        Get
                            Return xruptura_credito_cliente
                        End Get
                        Set(ByVal value As Boolean)
                            xruptura_credito_cliente = value
                        End Set
                    End Property

                    Property _Facturar_Precio_En_Cero() As Boolean
                        Get
                            Return xfacturar_precio_en_cero
                        End Get
                        Set(ByVal value As Boolean)
                            xfacturar_precio_en_cero = value
                        End Set
                    End Property

                    Property _Abrir_DocPendientes_OtrosUsuarios() As Boolean
                        Get
                            Return xabrir_doc_pendientes_de_otros
                        End Get
                        Set(ByVal value As Boolean)
                            xabrir_doc_pendientes_de_otros = value
                        End Set
                    End Property

                    Property _Limite_Renglones_Factura() As Integer
                        Get
                            Return xlimites_renglones
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones = value
                        End Set
                    End Property

                    Property _Limite_Renglones_NotasEntrega() As Integer
                        Get
                            Return xlimites_renglones_notas_entrega
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_notas_entrega = value
                        End Set
                    End Property

                    Property _Limite_Renglones_Pedidos() As Integer
                        Get
                            Return xlimites_renglones_pedidos
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_pedidos = value
                        End Set
                    End Property

                    Property _Limite_Renglones_AdmDocumentos() As Integer
                        Get
                            Return xlimites_renglones_adm_documentos
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_adm_documentos = value
                        End Set
                    End Property

                    Property _Limite_Renglones_Retenciones() As Integer
                        Get
                            Return xlimites_renglones_retenciones
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_retenciones = value
                        End Set
                    End Property

                    Property _Dar_Descuento_Al_Finalizar() As Boolean
                        Get
                            Return xdar_descuento_final
                        End Get
                        Set(ByVal value As Boolean)
                            xdar_descuento_final = value
                        End Set
                    End Property

                    Property _Facturar_Por_Debajo_Costo() As Boolean
                        Get
                            Return xfacturar_por_debajo_costo
                        End Get
                        Set(ByVal value As Boolean)
                            xfacturar_por_debajo_costo = value
                        End Set
                    End Property

                    Property _PermitirEntradaDeAnticipos_EnPedido() As Boolean
                        Get
                            Return Me.xaceptar_anticipos_en_pedidos
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xaceptar_anticipos_en_pedidos = value
                        End Set
                    End Property

                    Property _PermitirModosPagos_Anticipos_NC() As Boolean
                        Get
                            Return Me.xaceptar_modosdepago_anticipos_nc
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xaceptar_modosdepago_anticipos_nc = value
                        End Set
                    End Property

                    Property _PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar() As Boolean
                        Get
                            Return Me.ximprimirlinea_detalle_imp_fiscal
                        End Get
                        Set(ByVal value As Boolean)
                            Me.ximprimirlinea_detalle_imp_fiscal = value
                        End Set
                    End Property

                    'AL FACTURAR ORIGINAL
                    Property _ALFACTURAR_RutaImpresora() As String
                        Get
                            Return xfactura_ruta_imprersora
                        End Get
                        Set(ByVal value As String)
                            xfactura_ruta_imprersora = value
                        End Set
                    End Property

                    Property _ALFACTURAR_Formato() As String
                        Get
                            Return xfactura_formato
                        End Get
                        Set(ByVal value As String)
                            xfactura_formato = value
                        End Set
                    End Property

                    Property _ALFACTURAR_MedioImpresion() As TipoImpresora
                        Get
                            Return xfactura_medio_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            xfactura_medio_impresion = value
                        End Set
                    End Property

                    'NOTA DE CREDITO ORIGINAL
                    Property _ALNCR_RutaImpresora() As String
                        Get
                            Return xnc_ruta_imprersora
                        End Get
                        Set(ByVal value As String)
                            xnc_ruta_imprersora = value
                        End Set
                    End Property

                    Property _ALNCR_Formato() As String
                        Get
                            Return xnc_formato
                        End Get
                        Set(ByVal value As String)
                            xnc_formato = value
                        End Set
                    End Property

                    Property _ALNCR_MedioImpresion() As TipoImpresora
                        Get
                            Return xnc_medio_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            xnc_medio_impresion = value
                        End Set
                    End Property

                    Property _CantidadDiasPermitos_TrasladarDocumento() As Integer
                        Get
                            Return Me.xcantidad_dias_validos_para_trasladar_documento
                        End Get
                        Set(ByVal value As Integer)
                            Me.xcantidad_dias_validos_para_trasladar_documento = value
                        End Set
                    End Property

                    Property _PRESUPUESTO_MODO_IMPRESION() As TipoImpresora
                        Get
                            Return Me.xpresupuesto_modo_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            Me.xpresupuesto_modo_impresion = value
                        End Set
                    End Property

                    Property _NOTAENTREGA_MODO_IMPRESION() As TipoImpresora
                        Get
                            Return Me.xnotaentrega_modo_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            Me.xnotaentrega_modo_impresion = value
                        End Set
                    End Property

                    Property _PEDIDO_MODO_IMPRESION() As TipoImpresora
                        Get
                            Return Me.xpedido_modo_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            Me.xpedido_modo_impresion = value
                        End Set
                    End Property

                    Property _OTROS_MODO_IMPRESION() As TipoImpresora
                        Get
                            Return Me.xotros_modo_impresion
                        End Get
                        Set(ByVal value As TipoImpresora)
                            Me.xotros_modo_impresion = value
                        End Set
                    End Property

                    Property _SubDetalleFiscal_1() As String
                        Get
                            Return Me.xsubdetalle_fiscal_1
                        End Get
                        Set(ByVal value As String)
                            Me.xsubdetalle_fiscal_1 = value
                        End Set
                    End Property

                    Property _SubDetalleFiscal_2() As String
                        Get
                            Return Me.xsubdetalle_fiscal_2
                        End Get
                        Set(ByVal value As String)
                            Me.xsubdetalle_fiscal_2 = value
                        End Set
                    End Property

                    Property _SubDetalleFiscal_3() As String
                        Get
                            Return Me.xsubdetalle_fiscal_3
                        End Get
                        Set(ByVal value As String)
                            Me.xsubdetalle_fiscal_3 = value
                        End Set
                    End Property

                    Property _SubDetalleFiscal_4() As String
                        Get
                            Return Me.xsubdetalle_fiscal_4
                        End Get
                        Set(ByVal value As String)
                            Me.xsubdetalle_fiscal_4 = value
                        End Set
                    End Property


                    Sub New()
                        _Ruptura_Por_Existencia = True
                        _Confirmar_Eliminar_Item = True
                        _Abrir_DocPendientes_OtrosUsuarios = False
                        _AgruparItems_Al_Impimir = True
                        _Dar_Descuento_Al_Finalizar = False
                        _Facturar_Por_Debajo_Costo = False
                        _Facturar_Precio_En_Cero = False
                        _Limite_Renglones_Factura = 10
                        _Limite_Renglones_NotasEntrega = 10
                        _Limite_Renglones_Pedidos = 10
                        _Orden_Al_Imprimir_Items = OrdenImprimirItems.PorDefecto
                        _Ruptura_Por_CreditoCliente = True
                        _Ruptura_Por_Existencia = True
                        _Limite_Renglones_AdmDocumentos = 1000
                        _Limite_Renglones_Retenciones = 10
                        _PermitirEntradaDeAnticipos_EnPedido = False
                        _PermitirModosPagos_Anticipos_NC = False
                        _PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar = False

                        'AL FACTURAR ORIGINAL
                        Me._ALFACTURAR_MedioImpresion = TipoImpresora.Fiscal
                        Me._ALFACTURAR_RutaImpresora = ""
                        Me._ALFACTURAR_Formato = ""

                        'AL NOTA DE CREDITO ORIGINAL
                        Me._ALNCR_MedioImpresion = TipoImpresora.Fiscal
                        Me._ALNCR_RutaImpresora = ""
                        Me._ALNCR_Formato = ""

                        Me._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Grafico
                        Me._PEDIDO_MODO_IMPRESION = TipoImpresora.Grafico
                        Me._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Grafico
                        Me._OTROS_MODO_IMPRESION = TipoImpresora.Grafico

                        Me._CantidadDiasPermitos_TrasladarDocumento = 15

                        Me._SubDetalleFiscal_1 = ""
                        Me._SubDetalleFiscal_2 = ""
                        Me._SubDetalleFiscal_3 = ""
                        Me._SubDetalleFiscal_4 = ""
                    End Sub
                End Class

                Class ConfModuloClientes
                    Private xautogrupo As String
                    Private xautoestado As String
                    Private xautozona As String
                    Private xautovendedor As String
                    Private xautocobrador As String

                    Property _AutoGrupo_ARegistrar_PorDefecto() As String
                        Get
                            Return xautogrupo.Trim
                        End Get
                        Set(ByVal value As String)
                            xautogrupo = value
                        End Set
                    End Property

                    Property _AutoEstado_ARegistrar_PorDefecto() As String
                        Get
                            Return xautoestado.Trim
                        End Get
                        Set(ByVal value As String)
                            xautoestado = value
                        End Set
                    End Property

                    Property _AutoZona_ARegistrar_PorDefecto() As String
                        Get
                            Return xautozona.Trim
                        End Get
                        Set(ByVal value As String)
                            xautozona = value
                        End Set
                    End Property

                    Property _AutoVendedor_ARegistrar_PorDefecto() As String
                        Get
                            Return xautovendedor.Trim
                        End Get
                        Set(ByVal value As String)
                            xautovendedor = value
                        End Set
                    End Property

                    Property _AutoCobrador_ARegistrar_PorDefecto() As String
                        Get
                            Return xautocobrador.Trim
                        End Get
                        Set(ByVal value As String)
                            xautocobrador = value
                        End Set
                    End Property

                    Sub New()
                        _AutoCobrador_ARegistrar_PorDefecto = ""
                        _AutoEstado_ARegistrar_PorDefecto = ""
                        _AutoGrupo_ARegistrar_PorDefecto = ""
                        _AutoVendedor_ARegistrar_PorDefecto = ""
                        _AutoZona_ARegistrar_PorDefecto = ""
                    End Sub
                End Class

                Class ConfModuloInventario
                    Enum AlmacenPrecios As Integer
                        PMayor = 1
                        PDetal = 2
                        Ambos = 3
                    End Enum

                    Private xautomarca As String
                    Private xautoempq_compra As String
                    Private xautoempq_venta As String
                    Private xtipopreciomanejar As AlmacenPrecios
                    Private xlimiteproductosmostrar_admbusqueda As Integer
                    Private xactivar_precio_2 As Boolean
                    Private xruta_imagenes_productos As String

                    Property _AutoMarca_PorDefecto() As String
                        Get
                            Return xautomarca.Trim
                        End Get
                        Set(ByVal value As String)
                            xautomarca = value
                        End Set
                    End Property

                    Property _AutoEmpqCompra_PorDefecto() As String
                        Get
                            Return xautoempq_compra.Trim
                        End Get
                        Set(ByVal value As String)
                            xautoempq_compra = value
                        End Set
                    End Property

                    Property _AutoEmpqVenta_PorDefecto() As String
                        Get
                            Return xautoempq_venta.Trim
                        End Get
                        Set(ByVal value As String)
                            xautoempq_venta = value
                        End Set
                    End Property

                    Property _TipoPrecioManejar() As AlmacenPrecios
                        Get
                            Return xtipopreciomanejar
                        End Get
                        Set(ByVal value As AlmacenPrecios)
                            xtipopreciomanejar = value
                        End Set
                    End Property

                    Property _LimiteProductosMostrar_AdmBusquedaNormal() As Integer
                        Get
                            Return Me.xlimiteproductosmostrar_admbusqueda
                        End Get
                        Set(ByVal value As Integer)
                            Me.xlimiteproductosmostrar_admbusqueda = value
                        End Set
                    End Property

                    Property _PermitirTrabajarPrecio_2() As Boolean
                        Get
                            Return Me.xactivar_precio_2
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xactivar_precio_2 = value
                        End Set
                    End Property

                    Property _RutaImagenesProductos() As String
                        Get
                            Return xruta_imagenes_productos
                        End Get
                        Set(ByVal value As String)
                            xruta_imagenes_productos = value
                        End Set
                    End Property

                    Sub New()
                        Me._AutoEmpqCompra_PorDefecto = ""
                        Me._AutoEmpqVenta_PorDefecto = ""
                        Me._AutoMarca_PorDefecto = ""
                        Me._TipoPrecioManejar = AlmacenPrecios.Ambos
                        Me._LimiteProductosMostrar_AdmBusquedaNormal = 100
                        Me._PermitirTrabajarPrecio_2 = False
                        Me._RutaImagenesProductos = My.Application.Info.DirectoryPath + "\ImgProductos\"
                    End Sub
                End Class

                Class ConfModuloCxC
                    Private xlimites_renglones_adm_documentos As Integer
                    Private xcomisionchequedevuelto As Decimal
                    Private xdescuento_por_prontopago As Decimal

                    Property _Limite_Renglones_AdmDocumentos() As Integer
                        Get
                            Return xlimites_renglones_adm_documentos
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_adm_documentos = value
                        End Set
                    End Property

                    Property _ComisionChequeDevuelto() As Decimal
                        Get
                            Return Me.xcomisionchequedevuelto
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xcomisionchequedevuelto = value
                        End Set
                    End Property

                    Property _DescuentoPorProntoPago() As Decimal
                        Get
                            Return Me.xdescuento_por_prontopago
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xdescuento_por_prontopago = value
                        End Set
                    End Property

                    Sub New()
                        _Limite_Renglones_AdmDocumentos = 1000
                        _ComisionChequeDevuelto = 0
                        _DescuentoPorProntoPago = 0
                    End Sub
                End Class

                Class ConfModuloVendedor
                    Private xcomisionglobal As Decimal

                    Property _ComisionGlobalAsignada() As Decimal
                        Get
                            Return xcomisionglobal
                        End Get
                        Set(ByVal value As Decimal)
                            xcomisionglobal = value
                        End Set
                    End Property

                    Sub New()
                        _ComisionGlobalAsignada = 0
                    End Sub
                End Class

                Class ConfModuloCobrador
                    Private xcomisionglobal As Decimal

                    Property _ComisionGlobalAsignada() As Decimal
                        Get
                            Return xcomisionglobal
                        End Get
                        Set(ByVal value As Decimal)
                            xcomisionglobal = value
                        End Set
                    End Property

                    Sub New()
                        _ComisionGlobalAsignada = 0
                    End Sub
                End Class

                Class ConfModuloCompras
                    Private xlimites_renglones_adm_documentos As Integer

                    Property _Limite_Renglones_AdmDocumentos() As Integer
                        Get
                            Return xlimites_renglones_adm_documentos
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_adm_documentos = value
                        End Set
                    End Property

                    Sub New()
                        _Limite_Renglones_AdmDocumentos = 1000
                    End Sub
                End Class

                Class ConfModuloCxP
                    Private xlimites_renglones_adm_documentos As Integer

                    Property _Limite_Renglones_AdmDocumentos() As Integer
                        Get
                            Return xlimites_renglones_adm_documentos
                        End Get
                        Set(ByVal value As Integer)
                            xlimites_renglones_adm_documentos = value
                        End Set
                    End Property

                    Sub New()
                        _Limite_Renglones_AdmDocumentos = 1000
                    End Sub
                End Class

                Class ConfPanaderia
                    Private xnumerotarjetamaximo As Integer
                    Private xmostrartarjetasactivas As Boolean
                    Private xactivar_clave_devoluciones As Boolean
                    Private xnivel_clave_para_devoluciones As FichaGlobal.c_PermisosDelUsuario.Nivel
                    Private xactivar_clave_anulaciones As Boolean
                    Private xnivel_clave_para_anulaciones As FichaGlobal.c_PermisosDelUsuario.Nivel
                    Private xnivel_clave_para_desbloquear_tarjeta As FichaGlobal.c_PermisosDelUsuario.Nivel

                    Property _NumeroMaximoTarjetaActivar() As Integer
                        Get
                            Return xnumerotarjetamaximo
                        End Get
                        Set(ByVal value As Integer)
                            xnumerotarjetamaximo = value
                        End Set
                    End Property

                    Property _MostrarTarjetasActivas() As Boolean
                        Get
                            Return Me.xmostrartarjetasactivas
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xmostrartarjetasactivas = value
                        End Set
                    End Property

                    Property _ActivarClave_ParaDevoluciones() As Boolean
                        Get
                            Return Me.xactivar_clave_devoluciones
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xactivar_clave_devoluciones = value
                        End Set
                    End Property

                    Property _NivelClaveUtilizar_Devoluciones() As FichaGlobal.c_PermisosDelUsuario.Nivel
                        Get
                            Return Me.xnivel_clave_para_devoluciones
                        End Get
                        Set(ByVal value As FichaGlobal.c_PermisosDelUsuario.Nivel)
                            Me.xnivel_clave_para_devoluciones = value
                        End Set
                    End Property

                    Property _ActivarClave_ParaAnulaciones() As Boolean
                        Get
                            Return Me.xactivar_clave_anulaciones
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xactivar_clave_anulaciones = value
                        End Set
                    End Property

                    Property _NivelClaveUtilizar_Anulaciones() As FichaGlobal.c_PermisosDelUsuario.Nivel
                        Get
                            Return Me.xnivel_clave_para_anulaciones
                        End Get
                        Set(ByVal value As FichaGlobal.c_PermisosDelUsuario.Nivel)
                            Me.xnivel_clave_para_anulaciones = value
                        End Set
                    End Property

                    Property _NivelClaveUtilizar_DesbloquearTarjeta() As FichaGlobal.c_PermisosDelUsuario.Nivel
                        Get
                            Return Me.xnivel_clave_para_desbloquear_tarjeta
                        End Get
                        Set(ByVal value As FichaGlobal.c_PermisosDelUsuario.Nivel)
                            Me.xnivel_clave_para_desbloquear_tarjeta = value
                        End Set
                    End Property

                    Sub New()
                        _NumeroMaximoTarjetaActivar = 50
                        _MostrarTarjetasActivas = True
                        Me._ActivarClave_ParaAnulaciones = True
                        Me._ActivarClave_ParaDevoluciones = True
                        Me._NivelClaveUtilizar_Anulaciones = c_PermisosDelUsuario.Nivel.Nivel_Maximo
                        Me._ActivarClave_ParaDevoluciones = c_PermisosDelUsuario.Nivel.Nivel_Minimo
                        Me._NivelClaveUtilizar_DesbloquearTarjeta = c_PermisosDelUsuario.Nivel.Nivel_Maximo
                    End Sub
                End Class

                Class ConfFastFood
                    Enum PrecioFacturar As Integer
                        Precio_1 = 1
                        Precio_2 = 2
                    End Enum

                    Enum ModoBusquedaProductoFastFood As Integer
                        Barra = 0
                        Descripcion = 1
                        Codigo = 2
                        Plu = 3
                    End Enum

                    Private xprecio_manejar As PrecioFacturar
                    Private xmodobusqprd As ModoBusquedaProductoFastFood
                    Private xabrir_ctas_otros_usuarios As Boolean
                    Private xvisualizar_reporte_cuadre_caja As Boolean
                    Private xcerrar_operador_con_ctas_pendientes As Boolean
                    Private xmaximo_limite_admdocumentos As Integer

                    Property _AbrirCtasOtrosUsuarios() As Boolean
                        Get
                            Return xabrir_ctas_otros_usuarios
                        End Get
                        Set(ByVal value As Boolean)
                            xabrir_ctas_otros_usuarios = value
                        End Set
                    End Property

                    Property _VisualizarReporteCuadreCaja() As Boolean
                        Get
                            Return xvisualizar_reporte_cuadre_caja
                        End Get
                        Set(ByVal value As Boolean)
                            xvisualizar_reporte_cuadre_caja = value
                        End Set
                    End Property

                    Property _CerrarOperadorConCtasPendiente() As Boolean
                        Get
                            Return xcerrar_operador_con_ctas_pendientes
                        End Get
                        Set(ByVal value As Boolean)
                            xcerrar_operador_con_ctas_pendientes = value
                        End Set
                    End Property

                    Property _MaximoLimiteDoc() As Integer
                        Get
                            Return xmaximo_limite_admdocumentos
                        End Get
                        Set(ByVal value As Integer)
                            xmaximo_limite_admdocumentos = value
                        End Set
                    End Property

                    Property _PrecioFacturar() As PrecioFacturar
                        Get
                            Return Me.xprecio_manejar
                        End Get
                        Set(ByVal value As PrecioFacturar)
                            Me.xprecio_manejar = value
                        End Set
                    End Property

                    Property _ModoBusquedaProductoInventario() As ModoBusquedaProductoFastFood
                        Get
                            Return Me.xmodobusqprd
                        End Get
                        Set(ByVal value As ModoBusquedaProductoFastFood)
                            Me.xmodobusqprd = value
                        End Set
                    End Property

                    Sub New()
                        Me._PrecioFacturar = PrecioFacturar.Precio_1
                        Me._ModoBusquedaProductoInventario = ModoBusquedaProductoFastFood.Barra
                        Me._AbrirCtasOtrosUsuarios = False
                        Me._CerrarOperadorConCtasPendiente = False
                        Me._VisualizarReporteCuadreCaja = False
                        Me._MaximoLimiteDoc = 1000
                    End Sub
                End Class

                Class ConfRestaurant
                    Enum PrecioFacturar As Integer
                        Precio_1 = 1
                        Precio_2 = 2
                    End Enum

                    Private xprecio_manejar As PrecioFacturar
                    Private xnumeromaximomesas As Integer
                    Private xmontoserviciomesas As Decimal
                    Private xpermitirofertaplatos As Boolean
                    Private xcerrar_operador_con_mesas_pedidos_pendientes As Boolean
                    Private xactivar_dispositivo_movil As Boolean
                    Private xruta_imagenes_sistema As String
                    Private xruta_imagenes_web As String


                    Property _PrecioFacturar() As PrecioFacturar
                        Get
                            Return Me.xprecio_manejar
                        End Get
                        Set(ByVal value As PrecioFacturar)
                            Me.xprecio_manejar = value
                        End Set
                    End Property

                    Property _NumeroMaximoMesasAbrir() As Integer
                        Get
                            Return xnumeromaximomesas
                        End Get
                        Set(ByVal value As Integer)
                            xnumeromaximomesas = value
                        End Set
                    End Property

                    Property _MontoServicioMesa() As Decimal
                        Get
                            Return Me.xmontoserviciomesas
                        End Get
                        Set(ByVal value As Decimal)
                            Me.xmontoserviciomesas = value
                        End Set
                    End Property

                    Property _PermiteOfertasMenuPlatos() As Boolean
                        Get
                            Return Me.xpermitirofertaplatos
                        End Get
                        Set(ByVal value As Boolean)
                            Me.xpermitirofertaplatos = value
                        End Set
                    End Property

                    Property _CerrarOperadorConMesasPedidosPendiente() As Boolean
                        Get
                            Return xcerrar_operador_con_mesas_pedidos_pendientes
                        End Get
                        Set(ByVal value As Boolean)
                            xcerrar_operador_con_mesas_pedidos_pendientes = value
                        End Set
                    End Property

                    Property _Activar_DispositivoMovil() As Boolean
                        Get
                            Return xactivar_dispositivo_movil
                        End Get
                        Set(ByVal value As Boolean)
                            xactivar_dispositivo_movil = value
                        End Set
                    End Property

                    Property _RutaImagenesSistema() As String
                        Get
                            Return xruta_imagenes_sistema
                        End Get
                        Set(ByVal value As String)
                            xruta_imagenes_sistema = value
                        End Set
                    End Property

                    Property _RutaImagenesWeb() As String
                        Get
                            Return xruta_imagenes_web
                        End Get
                        Set(ByVal value As String)
                            xruta_imagenes_web = value
                        End Set
                    End Property


                    Sub New()
                        Me._NumeroMaximoMesasAbrir = 20
                        Me._PrecioFacturar = PrecioFacturar.Precio_1
                        Me._MontoServicioMesa = 10
                        Me._PermiteOfertasMenuPlatos = True
                        Me._CerrarOperadorConMesasPedidosPendiente = False
                        Me._Activar_DispositivoMovil = False
                        Me._RutaImagenesSistema = My.Application.Info.DirectoryPath + "\Img"
                        Me._RutaImagenesWeb = ""
                    End Sub
                End Class

                Private xtipobusqueda_cliente As MiDataSistema.DataSistema.FichaClientes.TipoBusquedaCliente
                Private xtipobusqueda_proveedor As MiDataSistema.DataSistema.FichaProveedores.TipoBusqueda
                Private xtipobusqueda_vendedor As MiDataSistema.DataSistema.FichaVendedores.TipoBusquedaVendedor
                Private xtipobusqueda_cobrador As MiDataSistema.DataSistema.FichaCobradores.TipoBusqueda
                Private xtipobusqueda_producto As MiDataSistema.DataSistema.FichaProducto.TipoBusquedaProducto
                Private xdeposito_a_buscar_ventas As String
                Private xdeposito_a_buscar_compras As String
                Private xmodulo_ventas As ConfModuloVentas
                Private xmodulo_clientes As ConfModuloClientes
                Private xmodulo_inventario As ConfModuloInventario
                Private xmodulo_cxc As ConfModuloCxC
                Private xmodulo_cobrador As ConfModuloCobrador
                Private xmodulo_vendedor As ConfModuloVendedor
                Private xmodulo_compras As ConfModuloCompras
                Private xmodulo_cxp As ConfModuloCxP
                Private xmodulo_panaderia As ConfPanaderia
                Private xmodulo_fastfood As ConfFastFood
                Private xmodulo_restaurant As ConfRestaurant
                Private xcalculoutilidad As TipoCalculoUtilidad
                Private xmodopago_por_defecto As String
                Private xrutareportes As String
                Private xrutarespaldodatos As String
                Private xtiposistema As TipoSistemaInstalado

                Private xregistro As c_Registro
                Private xtabla As DataTable

                Protected Friend Property p_RegistroDato() As c_Registro
                    Get
                        Return xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        xregistro = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica Tipo Busqueda Del Cliente Pre Determinado
                ''' </summary>
                Property cnf_BuscarCliente() As MiDataSistema.DataSistema.FichaClientes.TipoBusquedaCliente
                    Get
                        Return xtipobusqueda_cliente
                    End Get
                    Set(ByVal value As MiDataSistema.DataSistema.FichaClientes.TipoBusquedaCliente)
                        xtipobusqueda_cliente = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica Tipo Busqueda Del Proveedor Pre Determinado
                ''' </summary>
                Property cnf_BuscarProveedor() As MiDataSistema.DataSistema.FichaProveedores.TipoBusqueda
                    Get
                        Return xtipobusqueda_proveedor
                    End Get
                    Set(ByVal value As MiDataSistema.DataSistema.FichaProveedores.TipoBusqueda)
                        xtipobusqueda_proveedor = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica Tipo Busqueda Del Vendedor Pre Determinado
                ''' </summary>
                Property cnf_BuscarVendedor() As MiDataSistema.DataSistema.FichaVendedores.TipoBusquedaVendedor
                    Get
                        Return xtipobusqueda_vendedor
                    End Get
                    Set(ByVal value As MiDataSistema.DataSistema.FichaVendedores.TipoBusquedaVendedor)
                        xtipobusqueda_vendedor = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica Tipo Busqueda Del Cobrador Pre Determinado
                ''' </summary>
                Property cnf_BuscarCobrador() As MiDataSistema.DataSistema.FichaCobradores.TipoBusqueda
                    Get
                        Return xtipobusqueda_cobrador
                    End Get
                    Set(ByVal value As MiDataSistema.DataSistema.FichaCobradores.TipoBusqueda)
                        xtipobusqueda_cobrador = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica Tipo Busqueda Del Producto Pre Determinado
                ''' </summary>
                Property cnf_BuscarProducto() As MiDataSistema.DataSistema.FichaProducto.TipoBusquedaProducto
                    Get
                        Return xtipobusqueda_producto
                    End Get
                    Set(ByVal value As MiDataSistema.DataSistema.FichaProducto.TipoBusquedaProducto)
                        xtipobusqueda_producto = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica El Automatico Del Deposito Seleccionado Para Movimientos De Ventas
                ''' </summary>
                Property cnf_AutoDepositoMovimientoInventarioVentas() As String
                    Get
                        Return xdeposito_a_buscar_ventas
                    End Get
                    Set(ByVal value As String)
                        xdeposito_a_buscar_ventas = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica El Automatico Del Deposito Seleccionado Para Movimientos De Compras
                ''' </summary>
                Property cnf_AutoDepositoMovimientoCompras() As String
                    Get
                        Return xdeposito_a_buscar_compras
                    End Get
                    Set(ByVal value As String)
                        xdeposito_a_buscar_compras = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El MOdulo De Ventas
                ''' </summary>
                Property cnf_ModuloVentas() As ConfModuloVentas
                    Get
                        Return xmodulo_ventas
                    End Get
                    Set(ByVal value As ConfModuloVentas)
                        xmodulo_ventas = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Clientes
                ''' </summary>
                Property cnf_ModuloClientes() As ConfModuloClientes
                    Get
                        Return xmodulo_clientes
                    End Get
                    Set(ByVal value As ConfModuloClientes)
                        xmodulo_clientes = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Inventario
                ''' </summary>
                Property cnf_ModuloInventario() As ConfModuloInventario
                    Get
                        Return xmodulo_inventario
                    End Get
                    Set(ByVal value As ConfModuloInventario)
                        xmodulo_inventario = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Cuentas Por Cobrar
                ''' </summary>
                Property cnf_ModuloCxCobrar() As ConfModuloCxC
                    Get
                        Return xmodulo_cxc
                    End Get
                    Set(ByVal value As ConfModuloCxC)
                        xmodulo_cxc = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Cobradores
                ''' </summary>
                Property cnf_ModuloCobrador() As ConfModuloCobrador
                    Get
                        Return xmodulo_cobrador
                    End Get
                    Set(ByVal value As ConfModuloCobrador)
                        xmodulo_cobrador = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Vendedores
                ''' </summary>
                Property cnf_ModuloVendedor() As ConfModuloVendedor
                    Get
                        Return xmodulo_vendedor
                    End Get
                    Set(ByVal value As ConfModuloVendedor)
                        xmodulo_vendedor = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Compras
                ''' </summary>
                Property cnf_ModuloCompras() As ConfModuloCompras
                    Get
                        Return Me.xmodulo_compras
                    End Get
                    Set(ByVal value As ConfModuloCompras)
                        Me.xmodulo_compras = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asignada Para El Modulo De Cuentas Por Pagar
                ''' </summary>
                Property cnf_ModuloCxPagar() As ConfModuloCxP
                    Get
                        Return xmodulo_cxp
                    End Get
                    Set(ByVal value As ConfModuloCxP)
                        xmodulo_cxp = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asiganada Para El Modulo De Panaderia 
                ''' </summary>
                Property cnf_ModuloPanaderia() As ConfPanaderia
                    Get
                        Return xmodulo_panaderia
                    End Get
                    Set(ByVal value As ConfPanaderia)
                        xmodulo_panaderia = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asiganada Para El Modulo De FastFood
                ''' </summary>
                Property cnf_ModuloFastFood() As ConfFastFood
                    Get
                        Return xmodulo_fastfood
                    End Get
                    Set(ByVal value As ConfFastFood)
                        xmodulo_fastfood = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Configuracion Asiganada Para El Modulo De FastFood
                ''' </summary>
                Property cnf_ModuloRestaurant() As ConfRestaurant
                    Get
                        Return Me.xmodulo_restaurant
                    End Get
                    Set(ByVal value As ConfRestaurant)
                        Me.xmodulo_restaurant = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica El Tipo De Formula Usada Para El Calculo De La Utilidad
                ''' </summary>
                Property cnf_CalculoUtilidad() As TipoCalculoUtilidad
                    Get
                        Return xcalculoutilidad
                    End Get
                    Set(ByVal value As TipoCalculoUtilidad)
                        xcalculoutilidad = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica El Automatico Del Modo De Pago Por Defecto A Mostrar Al Procesar Un Pago
                ''' </summary>
                Property cnf_AutoMedioPago_Por_Defecto() As String
                    Get
                        Return xmodopago_por_defecto
                    End Get
                    Set(ByVal value As String)
                        xmodopago_por_defecto = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Ruta Reportes Del Sistema
                ''' </summary>
                Property cnf_RutaReportesSistema() As String
                    Get
                        Return xrutareportes
                    End Get
                    Set(ByVal value As String)
                        xrutareportes = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica La Ruta Respaldo Bd
                ''' </summary>
                Property cnf_RutaRespaldoBD() As String
                    Get
                        Return xrutarespaldodatos
                    End Get
                    Set(ByVal value As String)
                        xrutarespaldodatos = value
                    End Set
                End Property

                ''' <summary>
                ''' Indica El Tipo De Sistema Instalado Por El Cliente
                ''' </summary>
                Property cnf_TipoSistemaInstalado() As TipoSistemaInstalado
                    Get
                        Return Me.xtiposistema
                    End Get
                    Set(ByVal value As TipoSistemaInstalado)
                        Me.xtiposistema = value
                    End Set
                End Property

                Sub New()
                    Me.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto
                    Me.cnf_BuscarCliente = FichaClientes.TipoBusquedaCliente.PorNombreRazonSocial
                    Me.cnf_BuscarProveedor = FichaProveedores.TipoBusqueda.PorNombreRazonSocial
                    Me.cnf_BuscarVendedor = FichaVendedores.TipoBusquedaVendedor.PorNombre
                    Me.cnf_BuscarCobrador = FichaCobradores.TipoBusqueda.PorNombre
                    Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorDescripcion
                    Me.cnf_AutoDepositoMovimientoInventarioVentas = "0000000001"
                    Me.cnf_AutoDepositoMovimientoCompras = "0000000001"

                    Me.cnf_ModuloVentas = New ConfModuloVentas
                    Me.cnf_ModuloClientes = New ConfModuloClientes
                    Me.cnf_ModuloInventario = New ConfModuloInventario
                    Me.cnf_ModuloCxCobrar = New ConfModuloCxC
                    Me.cnf_ModuloCobrador = New ConfModuloCobrador
                    Me.cnf_ModuloVendedor = New ConfModuloVendedor
                    Me.cnf_ModuloCompras = New ConfModuloCompras
                    Me.cnf_ModuloCxPagar = New ConfModuloCxP
                    Me.cnf_ModuloPanaderia = New ConfPanaderia
                    Me.cnf_ModuloFastFood = New ConfFastFood
                    Me.cnf_ModuloFastFood = New ConfFastFood
                    Me.cnf_ModuloRestaurant = New ConfRestaurant

                    Me.cnf_AutoMedioPago_Por_Defecto = "0000000001"
                    Me.cnf_RutaReportesSistema = My.Application.Info.DirectoryPath & "\Reportes\"
                    Me.cnf_RutaRespaldoBD = "C:\RESPALDO\BD"

                    Me.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Basico

                    p_Tabla = New DataTable
                    p_RegistroDato = New c_Registro
                End Sub

                Protected Friend Property p_Tabla() As DataTable
                    Get
                        Return xtabla
                    End Get
                    Set(ByVal value As DataTable)
                        xtabla = value
                    End Set
                End Property

                Sub M_CargarFicha()
                    Try
                        For Each xrow In Me.p_Tabla.Rows
                            Me.p_RegistroDato.M_CargarFicha(xrow)

                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_01" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "LINEAL"
                                        Me.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlCosto
                                    Case "FINANCIERO"
                                        Me.cnf_CalculoUtilidad = TipoCalculoUtilidad.BaseAlPrecioVenta
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_03" Then
                                If Me.p_RegistroDato.r_SeleccionUsuario.Trim <> "" Then
                                    Me.cnf_RutaReportesSistema = Me.p_RegistroDato.r_SeleccionUsuario
                                End If
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_04" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "NOMBRE"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorDescripcion
                                    Case "CODIGO"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorCodigo
                                    Case "COD/BARRA"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorCodBarra
                                    Case "PLU"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorPlu
                                    Case "NUM/PARTE"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorNumParte
                                    Case "REFERENCIA"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorReferencia
                                    Case "SERIAL"
                                        Me.cnf_BuscarProducto = FichaProducto.TipoBusquedaProducto.PorSerial
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_05" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "NOMBRE"
                                        Me.cnf_BuscarCliente = FichaClientes.TipoBusquedaCliente.PorNombreRazonSocial
                                    Case "CODIGO"
                                        Me.cnf_BuscarCliente = FichaClientes.TipoBusquedaCliente.PorCodigo
                                    Case "CI/RIF"
                                        Me.cnf_BuscarCliente = FichaClientes.TipoBusquedaCliente.PorRif_CI
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "NOMBRE"
                                        Me.cnf_BuscarProveedor = FichaProveedores.TipoBusqueda.PorNombreRazonSocial
                                    Case "CODIGO"
                                        Me.cnf_BuscarProveedor = FichaProveedores.TipoBusqueda.PorCodigo
                                    Case "CI/RIF"
                                        Me.cnf_BuscarProveedor = FichaProveedores.TipoBusqueda.PorRif_CI
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_10" Then
                                MiDataSistema.DataSistema.p_ClaveNivelMaximo = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_11" Then
                                MiDataSistema.DataSistema.p_ClaveNivelMedio = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_12" Then
                                MiDataSistema.DataSistema.p_ClaveNivelMinimo = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_14" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "NOMBRE"
                                        Me.cnf_BuscarVendedor = FichaVendedores.TipoBusquedaVendedor.PorNombre
                                    Case "CODIGO"
                                        Me.cnf_BuscarVendedor = FichaVendedores.TipoBusquedaVendedor.PorCodigo
                                    Case "CI/RIF"
                                        Me.cnf_BuscarVendedor = FichaVendedores.TipoBusquedaVendedor.PorRif_CI
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_15" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "NOMBRE"
                                        Me.cnf_BuscarCobrador = FichaCobradores.TipoBusqueda.PorNombre
                                    Case "CODIGO"
                                        Me.cnf_BuscarCobrador = FichaCobradores.TipoBusqueda.PorCodigo
                                    Case "CI/RIF"
                                        Me.cnf_BuscarCobrador = FichaCobradores.TipoBusqueda.PorRif_CI
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_16" Then
                                Me.cnf_AutoDepositoMovimientoInventarioVentas = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_17" Then
                                Me.cnf_AutoMedioPago_Por_Defecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_18" Then
                                Me.cnf_RutaRespaldoBD = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_19" Then
                                Me.cnf_AutoDepositoMovimientoCompras = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "GLOBAL_09" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "BASICO"
                                        Me.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Basico
                                    Case "ADMINISTRATIVO"
                                        Me.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Administrativo
                                    Case "FULL"
                                        Me.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Full
                                    Case "AVANZADO"
                                        Me.cnf_TipoSistemaInstalado = TipoSistemaInstalado.Avanzado
                                End Select
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_01" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Ruptura_Por_Existencia = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Ruptura_Por_Existencia = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_02" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Confirmar_Eliminar_Item = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Confirmar_Eliminar_Item = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_05" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "CODIGO"
                                        Me.cnf_ModuloVentas._Orden_Al_Imprimir_Items = ConfModuloVentas.OrdenImprimirItems.PorCodigo
                                    Case "NOMBRE"
                                        Me.cnf_ModuloVentas._Orden_Al_Imprimir_Items = ConfModuloVentas.OrdenImprimirItems.PorNombre
                                    Case Else
                                        Me.cnf_ModuloVentas._Orden_Al_Imprimir_Items = ConfModuloVentas.OrdenImprimirItems.PorDefecto
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._AgruparItems_Al_Impimir = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._AgruparItems_Al_Impimir = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_11" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Ruptura_Por_CreditoCliente = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Ruptura_Por_CreditoCliente = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_12" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Facturar_Precio_En_Cero = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Facturar_Precio_En_Cero = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_14" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Abrir_DocPendientes_OtrosUsuarios = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Abrir_DocPendientes_OtrosUsuarios = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_15" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_Factura)
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_NotasEntrega)
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_Pedidos)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_17" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Dar_Descuento_Al_Finalizar = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Dar_Descuento_Al_Finalizar = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_18" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._Facturar_Por_Debajo_Costo = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._Facturar_Por_Debajo_Costo = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_19" Then
                                'Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_NotasEntrega)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_20" Then
                                'Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_Pedidos)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_21" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_AdmDocumentos)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_22" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._Limite_Renglones_Retenciones)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_33" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._PermitirModosPagos_Anticipos_NC = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._PermitirModosPagos_Anticipos_NC = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_34" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._PermitirEntradaDeAnticipos_EnPedido = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._PermitirEntradaDeAnticipos_EnPedido = False
                                End Select
                            End If
                            'AL FACTURAR ORIGINAL
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_35" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Texto
                                    Case "FISCAL"
                                        Me.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Fiscal
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = TipoImpresora.Grafico
                                    Case Else
                                        Me.cnf_ModuloVentas._ALFACTURAR_MedioImpresion = 0
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_36" Then
                                Me.cnf_ModuloVentas._ALFACTURAR_Formato = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_37" Then
                                Me.cnf_ModuloVentas._ALFACTURAR_RutaImpresora = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            'AL NOTA DE CREDITO ORIGINAL
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_38" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Texto
                                    Case "FISCAL"
                                        Me.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Fiscal
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._ALNCR_MedioImpresion = TipoImpresora.Grafico
                                    Case Else
                                        Me.cnf_ModuloVentas._ALNCR_MedioImpresion = 0
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_39" Then
                                Me.cnf_ModuloVentas._ALNCR_Formato = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_40" Then
                                Me.cnf_ModuloVentas._ALNCR_RutaImpresora = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_41" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar = True
                                    Case "NO"
                                        Me.cnf_ModuloVentas._PermitirImprimirLinea_EmpaqueSugeridoContenido_ImpFiscal_AlFacturar = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_42" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloVentas._CantidadDiasPermitos_TrasladarDocumento)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_43" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Texto
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._PRESUPUESTO_MODO_IMPRESION = TipoImpresora.Grafico
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_44" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Texto
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._NOTAENTREGA_MODO_IMPRESION = TipoImpresora.Grafico
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_45" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._PEDIDO_MODO_IMPRESION = TipoImpresora.Texto
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._PEDIDO_MODO_IMPRESION = TipoImpresora.Grafico
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_46" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "TEXTO"
                                        Me.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Texto
                                    Case "GRAFICO"
                                        Me.cnf_ModuloVentas._OTROS_MODO_IMPRESION = TipoImpresora.Grafico
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_47" Then
                                Me.cnf_ModuloVentas._SubDetalleFiscal_1 = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_48" Then
                                Me.cnf_ModuloVentas._SubDetalleFiscal_2 = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_49" Then
                                Me.cnf_ModuloVentas._SubDetalleFiscal_3 = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "VENTAS_50" Then
                                Me.cnf_ModuloVentas._SubDetalleFiscal_4 = Me.p_RegistroDato.r_SeleccionUsuario
                            End If


                            If Me.p_RegistroDato.r_CodigoOpcion = "CLIENTE_01" Then
                                Me.cnf_ModuloClientes._AutoGrupo_ARegistrar_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CLIENTE_02" Then
                                Me.cnf_ModuloClientes._AutoEstado_ARegistrar_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CLIENTE_03" Then
                                Me.cnf_ModuloClientes._AutoZona_ARegistrar_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CLIENTE_04" Then
                                Me.cnf_ModuloClientes._AutoVendedor_ARegistrar_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CLIENTE_05" Then
                                Me.cnf_ModuloClientes._AutoCobrador_ARegistrar_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_01" Then
                                Me.cnf_ModuloInventario._AutoMarca_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_02" Then
                                Me.cnf_ModuloInventario._AutoEmpqCompra_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_03" Then
                                Me.cnf_ModuloInventario._AutoEmpqVenta_PorDefecto = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_04" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "MAYOR"
                                        Me.cnf_ModuloInventario._TipoPrecioManejar = ConfModuloInventario.AlmacenPrecios.PMayor
                                    Case "DETAL"
                                        Me.cnf_ModuloInventario._TipoPrecioManejar = ConfModuloInventario.AlmacenPrecios.PDetal
                                    Case Else
                                        Me.cnf_ModuloInventario._TipoPrecioManejar = ConfModuloInventario.AlmacenPrecios.Ambos
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_05" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloInventario._LimiteProductosMostrar_AdmBusquedaNormal)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloInventario._PermitirTrabajarPrecio_2 = True
                                    Case "NO"
                                        Me.cnf_ModuloInventario._PermitirTrabajarPrecio_2 = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "INVENT_07" Then
                                If Me.p_RegistroDato.r_SeleccionUsuario.Trim <> "" Then
                                    Me.cnf_ModuloInventario._RutaImagenesProductos = Me.p_RegistroDato.r_SeleccionUsuario
                                End If
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "CXC_01" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloCxCobrar._Limite_Renglones_AdmDocumentos)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CXC_02" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloCxCobrar._ComisionChequeDevuelto)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "CXC_03" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloCxCobrar._DescuentoPorProntoPago)
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "VENDED_01" Then
                                Dim xvalor As String = Me.p_RegistroDato.r_SeleccionUsuario
                                xvalor = xvalor.Replace(".", My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
                                Decimal.TryParse(xvalor, Me.cnf_ModuloVendedor._ComisionGlobalAsignada)
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "COBRAD_01" Then
                                Dim xvalor As String = Me.p_RegistroDato.r_SeleccionUsuario
                                xvalor = xvalor.Replace(".", My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
                                Decimal.TryParse(xvalor, Me.cnf_ModuloCobrador._ComisionGlobalAsignada)
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "COMPRAS_02" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloCompras._Limite_Renglones_AdmDocumentos)
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "CXP_02" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloCxPagar._Limite_Renglones_AdmDocumentos)
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_01" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloPanaderia._NumeroMaximoTarjetaActivar)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_02" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloPanaderia._MostrarTarjetasActivas = True
                                    Case "NO"
                                        Me.cnf_ModuloPanaderia._MostrarTarjetasActivas = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_03" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloPanaderia._ActivarClave_ParaDevoluciones = True
                                    Case "NO"
                                        Me.cnf_ModuloPanaderia._ActivarClave_ParaDevoluciones = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_04" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloPanaderia._ActivarClave_ParaAnulaciones = True
                                    Case "NO"
                                        Me.cnf_ModuloPanaderia._ActivarClave_ParaAnulaciones = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_05" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "LIBRE"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Devoluciones = c_PermisosDelUsuario.Nivel.Nivel_Libre
                                    Case "MINIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Devoluciones = c_PermisosDelUsuario.Nivel.Nivel_Minimo
                                    Case "MEDIO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Devoluciones = c_PermisosDelUsuario.Nivel.Nivel_Medio
                                    Case "MAXIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Devoluciones = c_PermisosDelUsuario.Nivel.Nivel_Maximo
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "LIBRE"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Anulaciones = c_PermisosDelUsuario.Nivel.Nivel_Libre
                                    Case "MINIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Anulaciones = c_PermisosDelUsuario.Nivel.Nivel_Minimo
                                    Case "MEDIO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Anulaciones = c_PermisosDelUsuario.Nivel.Nivel_Medio
                                    Case "MAXIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_Anulaciones = c_PermisosDelUsuario.Nivel.Nivel_Maximo
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "PANAD_07" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "LIBRE"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_DesbloquearTarjeta = c_PermisosDelUsuario.Nivel.Nivel_Libre
                                    Case "MINIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_DesbloquearTarjeta = c_PermisosDelUsuario.Nivel.Nivel_Minimo
                                    Case "MEDIO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_DesbloquearTarjeta = c_PermisosDelUsuario.Nivel.Nivel_Medio
                                    Case "MAXIMO"
                                        Me.cnf_ModuloPanaderia._NivelClaveUtilizar_DesbloquearTarjeta = c_PermisosDelUsuario.Nivel.Nivel_Maximo
                                End Select
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_01" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloFastFood._AbrirCtasOtrosUsuarios = True
                                    Case "NO"
                                        Me.cnf_ModuloFastFood._AbrirCtasOtrosUsuarios = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_02" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloFastFood._VisualizarReporteCuadreCaja = True
                                    Case "NO"
                                        Me.cnf_ModuloFastFood._VisualizarReporteCuadreCaja = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_03" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloFastFood._CerrarOperadorConCtasPendiente = True
                                    Case "NO"
                                        Me.cnf_ModuloFastFood._CerrarOperadorConCtasPendiente = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_04" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloFastFood._MaximoLimiteDoc)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_05" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "CODIGO"
                                        Me.cnf_ModuloFastFood._ModoBusquedaProductoInventario = ConfFastFood.ModoBusquedaProductoFastFood.Codigo
                                    Case "NOMBRE"
                                        Me.cnf_ModuloFastFood._ModoBusquedaProductoInventario = ConfFastFood.ModoBusquedaProductoFastFood.Descripcion
                                    Case "PLU"
                                        Me.cnf_ModuloFastFood._ModoBusquedaProductoInventario = ConfFastFood.ModoBusquedaProductoFastFood.Plu
                                    Case "COD/BARRA"
                                        Me.cnf_ModuloFastFood._ModoBusquedaProductoInventario = ConfFastFood.ModoBusquedaProductoFastFood.Barra
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "FAST_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "PRECIO 1"
                                        Me.cnf_ModuloFastFood._PrecioFacturar = ConfFastFood.PrecioFacturar.Precio_1
                                    Case "PRECIO 2"
                                        Me.cnf_ModuloFastFood._PrecioFacturar = ConfFastFood.PrecioFacturar.Precio_2
                                End Select
                            End If

                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_01" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "PRECIO 1"
                                        Me.cnf_ModuloRestaurant._PrecioFacturar = ConfRestaurant.PrecioFacturar.Precio_1
                                    Case "PRECIO 2"
                                        Me.cnf_ModuloRestaurant._PrecioFacturar = ConfRestaurant.PrecioFacturar.Precio_2
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_02" Then
                                Integer.TryParse(Me.p_RegistroDato.r_SeleccionUsuario, Me.cnf_ModuloRestaurant._NumeroMaximoMesasAbrir)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_03" Then
                                Me.cnf_ModuloRestaurant._MontoServicioMesa = F_TransformarDecimal(Me.p_RegistroDato.r_SeleccionUsuario)
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_04" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloRestaurant._PermiteOfertasMenuPlatos = True
                                    Case "NO"
                                        Me.cnf_ModuloRestaurant._PermiteOfertasMenuPlatos = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_05" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloRestaurant._CerrarOperadorConMesasPedidosPendiente = True
                                    Case "NO"
                                        Me.cnf_ModuloRestaurant._CerrarOperadorConMesasPedidosPendiente = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_06" Then
                                Select Case Me.p_RegistroDato.r_SeleccionUsuario
                                    Case "SI"
                                        Me.cnf_ModuloRestaurant._Activar_DispositivoMovil = True
                                    Case "NO"
                                        Me.cnf_ModuloRestaurant._Activar_DispositivoMovil = False
                                End Select
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_07" Then
                                If Me.p_RegistroDato.r_SeleccionUsuario.Trim <> "" Then
                                    Me.cnf_ModuloRestaurant._RutaImagenesSistema = Me.p_RegistroDato.r_SeleccionUsuario
                                End If
                            End If
                            If Me.p_RegistroDato.r_CodigoOpcion = "REST_08" Then
                                Me.cnf_ModuloRestaurant._RutaImagenesWeb = Me.p_RegistroDato.r_SeleccionUsuario
                            End If
                        Next
                    Catch ex As Exception
                        Throw New Exception("CONF_SISTEMA" + vbCrLf + ex.Message)
                    End Try
                End Sub
            End Class

            ''' <summary>
            ''' CLASE: OPCIONES PERMITIDAS AL GRUPO SE USUARIO SELECCIONADO
            ''' </summary>
            ''' <remarks></remarks>
            Class c_GrupoOpciones
                Class c_Registro
                    Private f_codigo_grupo As CampoTexto
                    Private f_codigo_opcion As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_seguridad As CampoTexto

                    Property c_CodigoGrupo() As CampoTexto
                        Get
                            Return f_codigo_grupo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_grupo = value
                        End Set
                    End Property

                    Property c_CodigoOpcion() As CampoTexto
                        Get
                            Return f_codigo_opcion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_opcion = value
                        End Set
                    End Property

                    Property c_EstatusOpcion() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property

                    Property c_NivelSeguridad() As CampoTexto
                        Get
                            Return f_seguridad
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_seguridad = value
                        End Set
                    End Property

                    ReadOnly Property r_CodigoOpcion() As String
                        Get
                            Return Me.c_CodigoOpcion.c_Texto.Trim.ToUpper
                        End Get
                    End Property

                    ReadOnly Property r_CodigoGrupo() As String
                        Get
                            Return Me.c_CodigoGrupo.c_Texto.Trim.ToUpper
                        End Get
                    End Property

                    ReadOnly Property r_EstatusOpcion() As String
                        Get
                            Return Me.c_EstatusOpcion.c_Texto.Trim.ToUpper
                        End Get
                    End Property

                    ReadOnly Property r_NivelSeguridad() As String
                        Get
                            Return Me.c_NivelSeguridad.c_Texto.Trim.ToUpper
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        With Me.c_CodigoGrupo
                            .c_Largo = 10
                            .c_NombreInterno = "codigo_grupo"
                            .c_Texto = ""
                        End With
                        With Me.c_CodigoOpcion
                            .c_Largo = 10
                            .c_NombreInterno = "codigo_opcion"
                            .c_Texto = ""
                        End With
                        With Me.c_EstatusOpcion
                            .c_Largo = 1
                            .c_NombreInterno = "estatus"
                            .c_Texto = ""
                        End With
                        With Me.c_NivelSeguridad
                            .c_Largo = 10
                            .c_NombreInterno = "seguridad"
                            .c_Texto = ""
                        End With
                    End Sub

                    Sub New()
                        Me.c_CodigoGrupo = New CampoTexto
                        Me.c_CodigoOpcion = New CampoTexto
                        Me.c_EstatusOpcion = New CampoTexto
                        Me.c_NivelSeguridad = New CampoTexto

                        Me.M_LimpiarRegistro()
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

                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.M_LimpiarRegistro()
                        With Me.RegistroDato
                            .c_CodigoGrupo.c_Texto = xrow(.c_CodigoGrupo.c_NombreInterno)
                            .c_CodigoOpcion.c_Texto = xrow(.c_CodigoOpcion.c_NombreInterno)
                            .c_EstatusOpcion.c_Texto = xrow(.c_EstatusOpcion.c_NombreInterno)
                            .c_NivelSeguridad.c_Texto = xrow(.c_NivelSeguridad.c_NombreInterno)
                        End With
                    Catch ex As Exception
                        Throw New Exception("GRUPO OPCIONES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                    End Try
                End Sub

                Sub New()
                    Me.RegistroDato = New c_Registro
                End Sub
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA DOCUMENTOS ANULADOS DE TODOS LOS MODULOS
            ''' </summary>
            Public Class c_DocumentosAnulados
                Class c_AgregarRegistro
                    Private xregistro As c_Registro

                    Protected Friend Property RegistroDato() As c_Registro
                        Get
                            Return xregistro
                        End Get
                        Set(ByVal value As c_Registro)
                            xregistro = value
                        End Set
                    End Property

                    WriteOnly Property _NotasDetalle() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NotaDetalleAnulacion.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _EstacionEquipo() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreEstacion.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _NombreUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreUsuario.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _CodigoUsuario() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoUsuario.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _AutoDocumento() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_AutoDocumento.c_Texto = value
                        End Set
                    End Property

                    WriteOnly Property _FechaEmision() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaEmision.c_Valor = value
                        End Set
                    End Property

                    WriteOnly Property _Hora() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_HoraAnulacion.c_Texto = value
                        End Set
                    End Property

                    Sub New()
                        RegistroDato = New c_Registro
                    End Sub
                End Class

                Class c_Registro
                    Private f_codigo As CampoTexto
                    Private f_fecha As CampoFecha
                    Private f_hora As CampoTexto
                    Private f_detalle As CampoTexto
                    Private f_estacion As CampoTexto
                    Private f_usuario As CampoTexto
                    Private f_codigo_usuario As CampoTexto
                    Private f_auto As CampoTexto
                    Private f_auto_documento As CampoTexto

                    Protected Friend Property c_CodigoAnulacion() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    Protected Friend Property c_FechaEmision() As CampoFecha
                        Get
                            Return f_fecha
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha = value
                        End Set
                    End Property

                    Protected Friend Property c_HoraAnulacion() As CampoTexto
                        Get
                            Return f_hora
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_hora = value
                        End Set
                    End Property

                    Protected Friend Property c_NotaDetalleAnulacion() As CampoTexto
                        Get
                            Return f_detalle
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_detalle = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreEstacion() As CampoTexto
                        Get
                            Return f_estacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estacion = value
                        End Set
                    End Property

                    Protected Friend Property c_NombreUsuario() As CampoTexto
                        Get
                            Return f_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_usuario = value
                        End Set
                    End Property

                    Protected Friend Property c_CodigoUsuario() As CampoTexto
                        Get
                            Return f_codigo_usuario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_usuario = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoAnulacion() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Protected Friend Property c_AutoDocumento() As CampoTexto
                        Get
                            Return f_auto_documento
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto_documento = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoAnulacion() As String
                        Get
                            Return c_CodigoAnulacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _FechaEmision() As Date
                        Get
                            Return New Date(c_FechaEmision.c_Valor.Year, c_FechaEmision.c_Valor.Month, c_FechaEmision.c_Valor.Day)
                        End Get
                    End Property

                    ReadOnly Property _HoraAnulacion() As String
                        Get
                            Return c_HoraAnulacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NotaDetalleAnulacion() As String
                        Get
                            Return c_NotaDetalleAnulacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEstacion() As String
                        Get
                            Return c_NombreEstacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreUsuario() As String
                        Get
                            Return c_NombreUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _CodigoUsuario() As String
                        Get
                            Return c_CodigoUsuario.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoAnulacion() As String
                        Get
                            Return c_AutoAnulacion.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _AutoDocumento() As String
                        Get
                            Return c_AutoDocumento.c_Texto.Trim
                        End Get
                    End Property

                    Sub M_LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_CodigoAnulacion = New CampoTexto(10, "codigo")
                        c_FechaEmision = New CampoFecha("fecha")
                        c_HoraAnulacion = New CampoTexto(10, "hora")
                        c_NotaDetalleAnulacion = New CampoTexto(120, "detalle")
                        c_NombreEstacion = New CampoTexto(15, "estacion")
                        c_NombreUsuario = New CampoTexto(15, "usuario")
                        c_CodigoUsuario = New CampoTexto(10, "codigo_usuario")
                        c_AutoAnulacion = New CampoTexto(10, "auto")
                        c_AutoDocumento = New CampoTexto(10, "auto_documento")

                        M_LimpiarRegistro()
                    End Sub

                    Sub M_CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.M_LimpiarRegistro()

                            With Me
                                .c_CodigoAnulacion.c_Texto = xrow(.c_CodigoAnulacion.c_NombreInterno)
                                .c_FechaEmision.c_Valor = xrow(.c_FechaEmision.c_NombreInterno)
                                .c_HoraAnulacion.c_Texto = xrow(.c_HoraAnulacion.c_NombreInterno)
                                .c_NotaDetalleAnulacion.c_Texto = xrow(.c_NotaDetalleAnulacion.c_NombreInterno)
                                .c_NombreEstacion.c_Texto = xrow(.c_NombreEstacion.c_NombreInterno)
                                .c_CodigoUsuario.c_Texto = xrow(.c_CodigoUsuario.c_NombreInterno)
                                .c_AutoAnulacion.c_Texto = xrow(.c_AutoAnulacion.c_NombreInterno)
                                .c_AutoDocumento.c_Texto = xrow(.c_AutoDocumento.c_NombreInterno)
                                .c_NombreUsuario.c_Texto = xrow(.c_NombreUsuario.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("GLOBAL" + vbCrLf + "DOCUMENTOS ANULADOS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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
                    Me.RegistroDato = New c_Registro
                End Sub

                Function F_CargarRegistro(ByVal xauto As String, ByVal xcodigo As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from documentos_anulados where auto_documento=@auto_documento and codigo=@codigo", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto_documento", xauto)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@codigo", xcodigo)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            RegistroDato.M_CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("GLOBAL" + vbCrLf + "DOCUMENTOS ANULADOS" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_CargarRegistro(ByVal xrow As DataRow) As Boolean
                    Try
                        RegistroDato.M_CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Protected Friend Const InsertSql As String = "INSERT INTO documentos_anulados (" _
                  + "codigo," _
                  + "fecha," _
                  + "hora," _
                  + "detalle," _
                  + "estacion," _
                  + "usuario," _
                  + "codigo_usuario," _
                  + "auto," _
                  + "auto_documento) " _
                  + "VALUES (" _
                  + "@codigo," _
                  + "@fecha," _
                  + "@hora," _
                  + "@detalle," _
                  + "@estacion," _
                  + "@usuario," _
                  + "@codigo_usuario," _
                  + "@auto," _
                  + "@auto_documento) "
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA LOS MEDIOS / FORMA DE PAGOS DEFINIDOS POR EL SISTEMA
            ''' </summary>
            Public Class c_MediosPagos
                Event _ACTUALIZAR()

                Class c_AgregarMedioPago
                    Private xcodigo As String
                    Private xnombre As String
                    Private xestatus As TipoEstatus

                    Property _CodigoAsignado() As String
                        Protected Friend Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As String)
                            xcodigo = value
                        End Set
                    End Property

                    Property _NombreAsignado() As String
                        Protected Friend Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Protected Friend Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    Sub New()
                        _CodigoAsignado = ""
                        _NombreAsignado = ""
                        _Estatus = TipoEstatus.Inactivo
                    End Sub
                End Class

                Class c_ModificarMedioPago
                    Private xcodigo As String
                    Private xnombre As String
                    Private xestatus As TipoEstatus
                    Private xauto As String
                    Private xid As Byte()

                    Property _CodigoAsignado() As String
                        Protected Friend Get
                            Return xcodigo
                        End Get
                        Set(ByVal value As String)
                            xcodigo = value
                        End Set
                    End Property

                    Property _NombreAsignado() As String
                        Protected Friend Get
                            Return xnombre
                        End Get
                        Set(ByVal value As String)
                            xnombre = value
                        End Set
                    End Property

                    Property _Estatus() As TipoEstatus
                        Protected Friend Get
                            Return xestatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            xestatus = value
                        End Set
                    End Property

                    Property _AutoMedioPago() As String
                        Protected Friend Get
                            Return xauto
                        End Get
                        Set(ByVal value As String)
                            xauto = value
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

                    Sub New()
                        _CodigoAsignado = ""
                        _NombreAsignado = ""
                        _Estatus = TipoEstatus.Inactivo
                        _AutoMedioPago = ""
                    End Sub
                End Class

                Class c_Registro
                    Private f_codigo As CampoTexto
                    Private f_nombre As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_auto As CampoTexto
                    Private f_idseguridad As Byte()

                    Property c_CodigoPago() As CampoTexto
                        Get
                            Return f_codigo
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_codigo = value
                        End Set
                    End Property

                    ReadOnly Property _CodigoTipoPago() As String
                        Get
                            Return Me.c_CodigoPago.c_Texto.Trim.Trim
                        End Get
                    End Property

                    Property c_NombrePago() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _NombreTipoPago() As String
                        Get
                            Return Me.c_NombrePago.c_Texto.Trim.Trim
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

                    ReadOnly Property _EstatusTipoPago() As TipoEstatus
                        Get
                            If Me.c_Estatus.c_Texto.Trim.ToUpper = "ACTIVO" Then
                                Return TipoEstatus.Activo
                            Else
                                Return TipoEstatus.Inactivo
                            End If
                        End Get
                    End Property

                    Protected Friend Property c_AutoPago() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    ReadOnly Property _AutoTipoPago() As String
                        Get
                            Return Me.c_AutoPago.c_Texto.Trim.Trim
                        End Get
                    End Property

                    Protected Friend Property c_IdSeguridad() As Byte()
                        Get
                            Return f_idseguridad
                        End Get
                        Set(ByVal value As Byte())
                            f_idseguridad = value
                        End Set
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
                        Me.c_AutoPago = New CampoTexto(10, "auto")
                        Me.c_CodigoPago = New CampoTexto(2, "codigo")
                        Me.c_Estatus = New CampoTexto(10, "estatus")
                        Me.c_NombrePago = New CampoTexto(10, "nombre")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_AutoPago.c_Texto = xrow(.c_AutoPago.c_NombreInterno)
                                .c_CodigoPago.c_Texto = xrow(.c_CodigoPago.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_NombrePago.c_Texto = xrow(.c_NombrePago.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    Me.c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("MEDIO DE PAGO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private Const Insert_1 As String = _
                    "update contadores set a_medios_pago=a_medios_pago+1;select a_medios_pago from contadores"
                Private Const Insert_2 As String = _
                    "Insert into medios_pago (auto,codigo,nombre,estatus) values (@auto,@codigo,@nombre,@estatus)"
                Private Const Update_1 As String = _
                    "update medios_pago set codigo=@codigo, nombre=@nombre, estatus=@estatus where auto=@auto and id_seguridad=@id"

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
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from medios_pago where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("MEDIO DE PAGO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("MEDIO DE PAGO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarMedioPago(ByVal xauto As String, ByVal xid As Byte()) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = "delete medios_pago where auto=@auto and id_seguridad=@id"
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@id", xid)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent _ACTUALIZAR()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR MEDIO DE PAGO, EXISTEN MOVIMIENTOS DE PAGOS QUE HACEN REFERENCIA A ESTE MODO")
                                Else
                                    Throw New Exception(ex2.Message + ", Error: " + ex2.Number.ToString)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MEDIOS PAGO:" + vbCrLf + "ELIMINAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_AgregarMedioPago(ByVal xagregar As c_AgregarMedioPago) As Boolean
                    Dim xtr As SqlTransaction = Nothing
                    Try
                        Dim xreg As New c_Registro
                        With xreg
                            .c_CodigoPago.c_Texto = xagregar._CodigoAsignado
                            If xagregar._Estatus = TipoEstatus.Activo Then
                                .c_Estatus.c_Texto = "Activo"
                            Else
                                .c_Estatus.c_Texto = "Inactivo"
                            End If
                            .c_NombrePago.c_Texto = xagregar._NombreAsignado
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try

                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = Insert_1
                                    xreg.c_AutoPago.c_Texto = xcmd.ExecuteScalar().ToString.Trim.PadLeft(10, "0")

                                    xcmd.CommandText = Insert_2
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_AutoPago.c_Texto).Size = xreg.c_AutoPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xreg.c_NombrePago.c_Texto).Size = xreg.c_NombrePago.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xreg.c_CodigoPago.c_Texto).Size = xreg.c_CodigoPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xreg.c_Estatus.c_Texto).Size = xreg.c_Estatus.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ACTUALIZAR()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR MEDIO DE PAGO, EXISTE UN REGISTRO CON EL MISMO NOMBRE/CODIGO")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR MEDIO DE PAGO, AUTOMATICO DEL MEDIO DE PAGO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message + ", Error Numero: " + ex2.Number.ToString)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MEDIOS DE PAGO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificarMedioPago(ByVal xagregar As c_ModificarMedioPago) As Boolean
                    Try
                        Dim xreg As New c_Registro
                        With xreg
                            .c_CodigoPago.c_Texto = xagregar._CodigoAsignado
                            If xagregar._Estatus = TipoEstatus.Activo Then
                                .c_Estatus.c_Texto = "Activo"
                            Else
                                .c_Estatus.c_Texto = "Inactivo"
                            End If
                            .c_NombrePago.c_Texto = xagregar._NombreAsignado
                            .c_AutoPago.c_Texto = xagregar._AutoMedioPago
                            .c_IdSeguridad = xagregar._IdSeguridad
                        End With

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try

                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = Update_1
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_AutoPago.c_Texto).Size = xreg.c_AutoPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@nombre", xreg.c_NombrePago.c_Texto).Size = xreg.c_NombrePago.c_Largo
                                    xcmd.Parameters.AddWithValue("@codigo", xreg.c_CodigoPago.c_Texto).Size = xreg.c_CodigoPago.c_Largo
                                    xcmd.Parameters.AddWithValue("@estatus", xreg.c_Estatus.c_Texto).Size = xreg.c_Estatus.c_Largo
                                    xcmd.Parameters.AddWithValue("@id", xreg.c_IdSeguridad)

                                    Dim xr As Integer = 0
                                    xr = xcmd.ExecuteNonQuery()
                                    If xr = 0 Then
                                        Throw New Exception("MEDIO DE PAGO NO PUDO SER ACTUALIZADO" + vbCrLf + "MOTIVO: ACTUALIZADO POR OTRO USUARIO / MEDIO DE PAGO FUE ELIMINADO")
                                    End If
                                End Using
                                RaiseEvent _ACTUALIZAR()
                                Return True
                            Catch ex2 As SqlException
                                Select Case ex2.Number
                                    Case 2601 : Throw New Exception("ERROR AL AGREGAR MEDIO DE PAGO, EXISTE UN REGISTRO CON EL MISMO NOMBRE/CODIGO")
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR MEDIO DE PAGO, AUTOMATICO DEL MEDIO DE PAGO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message + ", Error Numero: " + ex2.Number.ToString)
                                End Select
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("MEDIOS DE PAGO" + vbCrLf + "AGREGAR REGISTRO:" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA LOS GRUPOS DE USUARIOS DEFENIDOS
            ''' </summary>
            Public Class c_GrupoUsuarios
                Event Actualizar()

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
                            xreg.c_Nombre.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _AutomatoGrupo() As String
                        Set(ByVal value As String)
                            xreg.c_Auto.c_Texto = value
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

                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Property c_Nombre() As CampoTexto
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

                    ReadOnly Property _AutoGrupo() As String
                        Get
                            Return Me.c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreGrupo() As String
                        Get
                            Return Me.c_Nombre.c_Texto.Trim
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
                        Me.c_Auto = New CampoTexto(10, "auto")
                        Me.c_Nombre = New CampoTexto(50, "nombre")
                        LimpiarRegistro()
                    End Sub

                    Sub CargarFicha(ByVal xrow As DataRow)
                        Try
                            LimpiarRegistro()
                            With Me
                                .c_Auto.c_Texto = xrow(.c_Auto.c_NombreInterno)
                                .c_Nombre.c_Texto = xrow(.c_Nombre.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("GRUPO USUARIO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private Const AgregarRegistro_1 As String = "update contadores set a_grupo_usuario=a_grupo_usuario+1; select a_grupo_usuario from contadores"
                Private Const AgregarRegistro_2 As String = "insert into grupo_usuario (auto,nombre) values (@auto,@nombre)"
                Private Const AgregarRegistro_3 As String = "insert grupo_opciones select @auto,codigo_opcion,'0','Ninguna' from grupo_opciones where codigo_grupo='0000000001'"
                Private Const ModificarRegistro_1 As String = "update grupo_usuario set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const EliminarRegistro_1 As String = "delete grupo_USUARIO where auto=@auto"
                Private Const EliminarRegistro_2 As String = "delete grupo_opciones where codigo_grupo=@auto"

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
                        Me.RegistroDato.CargarFicha(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                Function F_BuscarRegistro(ByVal xauto As String) As Boolean
                    Try
                        Dim xtb As New DataTable
                        Using xadap As New SqlDataAdapter("", _MiCadenaConexion)
                            xadap.SelectCommand.CommandText = "select * from grupo_usuario where auto=@auto"
                            xadap.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            xadap.Fill(xtb)
                        End Using
                        If xtb.Rows.Count > 0 Then
                            Me.M_CargarRegistro(xtb(0))
                        Else
                            Throw New Exception("GRUPO DE USUARIO NO ENCONTRADO... VERIFIQUE POR FAVOR !!!")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception("GRUPO USUARIO" + vbCrLf + "BUSCAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_NuevoGrupo(ByVal xnombre As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Dim xauto As String = ""
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                xtr = xcon.BeginTransaction
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    xcmd.CommandText = "select a_grupo_usuario from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_grupo_usuario=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_1
                                    xauto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.Parameters.AddWithValue("@nombre", xnombre)
                                    xcmd.ExecuteNonQuery()

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = AgregarRegistro_3
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()
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
                        Throw New Exception("GRUPO USUARIO" + vbCrLf + "NUEVO GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminaGrupo(ByVal xauto As String) As Boolean
                    Try
                        Dim xtr As SqlTransaction = Nothing
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    'GRUPO_OPCIONES
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarRegistro_2
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()

                                    'GRUPO_USUARIO
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = EliminarRegistro_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent Actualizar()

                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                If ex2.Number = 547 Then
                                    Throw New Exception("ERROR AL ELIMINAR GRUPO, EXISTEN USUARIOS DENTRO DE ESTE GRUPO")
                                Else
                                    Throw New Exception(ex2.Message + vbCrLf + "ERROR NUMERO: " + ex2.Number.ToString)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("GRUPO USUARIO" + vbCrLf + "ELIMINAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_ModificaGrupo(ByVal xgrupomod As c_ModificarGrupo) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(ModificarRegistro_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xgrupomod.c_GrupoModificar.c_Auto.c_Texto)
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xgrupomod.c_GrupoModificar.c_Nombre.c_Texto)
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
                        Throw New Exception("GRUPO USUARIO" + vbCrLf + "MODIFICAR GRUPO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA LOS DIFERENTES ESTADOS DEL PAIS
            ''' </summary>
            Public Class c_Estados
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_nombre As CampoTexto

                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Protected Friend Property c_Nombre() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_nombre = value
                        End Set
                    End Property

                    ReadOnly Property _AutoEstado() As String
                        Get
                            Return Me.c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreEstado() As String
                        Get
                            Return Me.c_Nombre.c_Texto.Trim
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        f_auto = New CampoTexto(10, "auto")
                        f_nombre = New CampoTexto(20, "nombre")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_Auto.c_Texto = xrow(.c_Auto.c_NombreInterno)
                                .c_Nombre.c_Texto = xrow(.c_Nombre.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("ESTADO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro

                Property RegistroDato() As c_Registro
                    Get
                        Return Me.xregistro
                    End Get
                    Set(ByVal value As c_Registro)
                        Me.xregistro = value
                    End Set
                End Property

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
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA EL ESTADO DE LA INSTALACION
            ''' </summary>
            Public Class c_Instalacion
                Class c_Registro
                    Private f_fecha_instalacion As CampoFecha
                    Private f_estatus_instalacion As CampoTexto

                    Protected Friend Property c_FechaInstalacion() As CampoFecha
                        Get
                            Return f_fecha_instalacion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_instalacion = value
                        End Set
                    End Property

                    Protected Friend Property c_EstatusInstalacion() As CampoTexto
                        Get
                            Return f_estatus_instalacion
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus_instalacion = value
                        End Set
                    End Property

                    ReadOnly Property _FechaInstalacion() As Date
                        Get
                            Return Me.c_FechaInstalacion.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _EstatusInstalacion() As TipoEstatusInstalacion
                        Get
                            Select Case Me.c_EstatusInstalacion.c_Texto.Trim.ToUpper
                                Case "0" : Return TipoEstatusInstalacion.PorActivar
                                Case "1" : Return TipoEstatusInstalacion.Instalada
                                Case "2" : Return TipoEstatusInstalacion.ExpiroLimite
                            End Select
                        End Get
                    End Property

                    ReadOnly Property _LimiteOk() As Boolean
                        Get
                            Dim x As Integer = 0
                            x = DateDiff(DateInterval.Day, _FechaInstalacion, Date.Today)
                            If x > 10 Then
                                Return False
                            Else
                                Return True
                            End If
                        End Get
                    End Property

                    Sub New()
                        Me.c_EstatusInstalacion = New CampoTexto(1, "ESTATUS_INSTALACION")
                        Me.c_FechaInstalacion = New CampoFecha("FECHA_INSTALACION")

                        LimpiarRegistro()
                    End Sub

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub CargarRegistro()
                        Try
                            LimpiarRegistro()

                            Dim xtb As New DataTable
                            Using xadap As New SqlDataAdapter("select * from registro", _MiCadenaConexion)
                                xadap.Fill(xtb)
                            End Using
                            If xtb.Rows.Count > 0 Then
                                With Me
                                    .c_EstatusInstalacion.c_Texto = xtb(0)(.c_EstatusInstalacion.c_NombreInterno)
                                    .c_FechaInstalacion.c_Valor = xtb(0)(.c_FechaInstalacion.c_NombreInterno)
                                End With
                            Else
                                Throw New Exception("PROBLEMA AL CARGAR REGISTRO DEL SISTEMA")
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Sub
                End Class

                Private xregistro As c_Registro
                Private xestatus As Boolean

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
                    xestatus = F_VerificarEstatusInstalacion()
                End Sub

                Function F_VerificarEstatusInstalacion() As Boolean
                    Try
                        Me.RegistroDato.CargarRegistro()
                        If Me.RegistroDato._EstatusInstalacion = TipoEstatusInstalacion.Instalada Then
                            Return True
                        ElseIf Me.RegistroDato._EstatusInstalacion = TipoEstatusInstalacion.PorActivar And Me.RegistroDato._LimiteOk Then
                            Return True
                        Else
                            If Me.RegistroDato._EstatusInstalacion = TipoEstatusInstalacion.ExpiroLimite Then
                            Else
                                Try
                                    Using xcon As New SqlConnection(_MiCadenaConexion)
                                        xcon.Open()
                                        Try
                                            Using xcmd As New SqlCommand("", xcon)
                                                xcmd.CommandText = "update registro set estatus_instalacion='2'"
                                                xcmd.ExecuteNonQuery()
                                            End Using
                                        Catch ex As Exception
                                            Throw New Exception(ex.Message)
                                        End Try
                                    End Using
                                Catch ex As Exception
                                    Throw New Exception(ex.Message)
                                End Try
                            End If
                            Return False
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_VerificarClaveInstalacion(ByVal xvalidar As String, ByVal xrif_verificar As String) As Boolean
                    Try
                        Dim xrif As String = xrif_verificar
                        xrif = xrif.Replace("-", "")

                        Dim x1 As Integer = Asc(xrif(0))
                        Dim x2 As Long = 0
                        Long.TryParse(xrif.Substring(1), x2)
                        Dim x3 As Long = x1 + x2
                        Dim xr As String = ""
                        xr = String.Format("{0:X}", x3)

                        Dim xg As String = xvalidar
                        Dim m As Integer = 0
                        Dim z As Integer = 0
                        Dim xclave As String = ""
                        For Each s In xg
                            m += 1
                            If (m Mod 4) = 0 Then
                                If z <= xr.Length - 1 Then
                                    xclave += s
                                    z += 1
                                End If
                            End If
                        Next

                        If xclave = xr Then
                        Else
                            Throw New Exception("ERROR CLAVE INCORRECTA, VERIFIQUE POR FAVOR")
                        End If

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.CommandText = "update registro set estatus_instalacion='1'"
                                    xcmd.ExecuteNonQuery()
                                End Using
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_GenerarClaveInstalacion(ByVal xrif_generar As String) As String
                    Dim xrif As String = xrif_generar
                    xrif = xrif.Replace("-", "")

                    Dim x1 As Integer = Asc(xrif(0))
                    Dim x2 As Long = 0
                    Long.TryParse(xrif.Substring(1), x2)
                    Dim x3 As Long = x1 + x2
                    Dim xr As String = ""
                    xr = String.Format("{0:X}", x3)

                    Dim xg As String = Guid.NewGuid.ToString
                    Dim m As Integer = 0
                    Dim z As Integer = 0
                    Dim xclave As String = ""
                    For Each s In xg
                        m += 1
                        If (m Mod 4) = 0 Then
                            If z <= xr.Length - 1 Then
                                xclave += xr(z)
                                s = xr(z)
                                z += 1
                            End If
                        Else
                            xclave += s
                        End If
                    Next
                    xclave = xclave.Trim.ToUpper
                    Return xclave
                End Function

                ReadOnly Property _InstalacionOk() As Boolean
                    Get
                        Return xestatus
                    End Get
                End Property
            End Class

            ''' <summary>
            ''' CLASE: REGISTRA LAS REGLAS PARA CALCULO DE COMISIONES TANAO PARA EL VENDEDOR / COBRADOR
            ''' </summary>
            Public Class c_TablaComisiones
                Event _ActualizarRegla()

                Public Class c_AgregarRegla
                    Private xtipo As TipoTablaComision
                    Private xcomision As Decimal
                    Private xdesde As Decimal
                    Private xhasta As Decimal

                    Property _Comision() As Decimal
                        Get
                            Return xcomision
                        End Get
                        Set(ByVal value As Decimal)
                            xcomision = value
                        End Set
                    End Property

                    Property _MontoDesde() As Decimal
                        Get
                            Return xdesde
                        End Get
                        Set(ByVal value As Decimal)
                            xdesde = value
                        End Set
                    End Property

                    Property _MontoHasta() As Decimal
                        Get
                            Return xhasta
                        End Get
                        Set(ByVal value As Decimal)
                            xhasta = value
                        End Set
                    End Property

                    Property _Tipo() As TipoTablaComision
                        Get
                            Return xtipo
                        End Get
                        Set(ByVal value As TipoTablaComision)
                            xtipo = value
                        End Set
                    End Property

                    Sub New()
                        _Tipo = TipoTablaComision.Vendedor
                        _MontoDesde = 0
                        _MontoHasta = 0
                        _Comision = 0
                    End Sub
                End Class

                Public Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_desde As CampoDecimal
                    Private f_hasta As CampoDecimal
                    Private f_comision As CampoDecimal
                    Private f_tipo As CampoTexto

                    Protected Friend Property c_Auto() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property

                    Protected Friend Property c_DesdeMonto() As CampoDecimal
                        Get
                            Return f_desde
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_desde = value
                        End Set
                    End Property

                    Protected Friend Property c_HastaMonto() As CampoDecimal
                        Get
                            Return f_hasta
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_hasta = value
                        End Set
                    End Property

                    Protected Friend Property c_Comision() As CampoDecimal
                        Get
                            Return f_comision
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_comision = value
                        End Set
                    End Property

                    Protected Friend Property c_TipoTablaComision() As CampoTexto
                        Get
                            Return f_tipo
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo = value
                        End Set
                    End Property

                    ReadOnly Property _Auto() As String
                        Get
                            Return Me.c_Auto.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _DesdeMonto() As Decimal
                        Get
                            Return Me.c_DesdeMonto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _HastaMonto() As Decimal
                        Get
                            Return Me.c_HastaMonto.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _Comision() As Decimal
                        Get
                            Return Me.c_Comision.c_Valor
                        End Get
                    End Property

                    ReadOnly Property _TipoTablaComision() As TipoTablaComision
                        Get
                            If Me.c_TipoTablaComision.c_Texto.Trim.ToUpper = "V" Then
                                Return TipoTablaComision.Vendedor
                            Else
                                Return TipoTablaComision.Cobrador
                            End If
                        End Get
                    End Property

                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        Me.f_auto = New CampoTexto(10, "auto")
                        Me.f_comision = New CampoDecimal("comision")
                        Me.f_desde = New CampoDecimal("desde")
                        Me.f_hasta = New CampoDecimal("hasta")
                        Me.f_tipo = New CampoTexto(1, "tipo")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_Auto.c_Texto = xrow(.c_Auto.c_NombreInterno)
                                .c_Comision.c_Valor = xrow(.c_Comision.c_NombreInterno)
                                .c_DesdeMonto.c_Valor = xrow(.c_DesdeMonto.c_NombreInterno)
                                .c_HastaMonto.c_Valor = xrow(.c_HastaMonto.c_NombreInterno)
                                .c_TipoTablaComision.c_Texto = xrow(.c_TipoTablaComision.c_NombreInterno)
                            End With
                        Catch ex As Exception
                            Throw New Exception("TABLA COMISIONES" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                Private Const Insert_1 As String = "INSERT INTO ComisionRango_VendCob " & _
                    "(auto," & _
                    "desde," & _
                    "hasta," & _
                    "comision," & _
                    "tipo) " & _
                    "VALUES " & _
                    "(@auto," & _
                    "@desde," & _
                    "@hasta," & _
                    "@comision," & _
                    "@tipo)"

                Private Const Eliminar_1 As String = "delete comisionrango_vendcob where auto=@auto"

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

                Function F_AgregarRegla(ByVal xregla As c_AgregarRegla) As Boolean
                    Try
                        Dim xtr As SqlTransaction
                        Dim xreg As New c_TablaComisiones.c_Registro

                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            xtr = xcon.BeginTransaction
                            Try
                                Using xcmd As New SqlCommand("", xcon, xtr)
                                    Dim xtipo As String = ""
                                    xtipo = IIf(xregla._Tipo = TipoTablaComision.Vendedor, "V", "C")

                                    Dim xv As Object = Nothing
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from ComisionRango_VendCob where tipo=@tipo and  @VALOR between desde and hasta  order by desde"
                                    xcmd.Parameters.AddWithValue("@tipo", xtipo)
                                    xcmd.Parameters.AddWithValue("@VALOR", xregla._MontoDesde)
                                    xv = xcmd.ExecuteScalar()
                                    If xv Is Nothing Or IsDBNull(xv) Then
                                    Else
                                        Throw New Exception("REGLA INCORRECTA, YA ESTA COMPARTIENDO UN RANGO CON OTRA REGLA REGISTRADA")
                                    End If

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = "select auto from ComisionRango_VendCob where tipo=@tipo and  @VALOR between desde and hasta  order by desde"
                                    xcmd.Parameters.AddWithValue("@tipo", xtipo)
                                    xcmd.Parameters.AddWithValue("@VALOR", xregla._MontoHasta)
                                    xv = xcmd.ExecuteScalar()
                                    If xv Is Nothing Or IsDBNull(xv) Then
                                    Else
                                        Throw New Exception("REGLA INCORRECTA, YA ESTA COMPARTIENDO UN RANGO CON OTRA REGLA REGISTRADA")
                                    End If

                                    xcmd.CommandText = "select a_tablacomisiones from contadores"
                                    If IsDBNull(xcmd.ExecuteScalar()) Then
                                        xcmd.Parameters.Clear()
                                        xcmd.CommandText = "update contadores set a_tablacomisiones=0"
                                        xcmd.ExecuteNonQuery()
                                    End If
                                    xcmd.CommandText = "update contadores set a_tablacomisiones=a_tablacomisiones+1;select a_tablacomisiones from contadores"
                                    xreg.c_Auto.c_Texto = xcmd.ExecuteScalar.ToString.Trim.PadLeft(10, "0")

                                    With xreg
                                        .c_Comision.c_Valor = xregla._Comision
                                        .c_DesdeMonto.c_Valor = xregla._MontoDesde
                                        .c_HastaMonto.c_Valor = xregla._MontoHasta
                                        .c_TipoTablaComision.c_Texto = xtipo
                                    End With

                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Insert_1
                                    xcmd.Parameters.AddWithValue("@auto", xreg.c_Auto.c_Texto).Size = xreg.c_Auto.c_Largo
                                    xcmd.Parameters.AddWithValue("@comision", xreg.c_Comision.c_Valor)
                                    xcmd.Parameters.AddWithValue("@desde", xreg.c_DesdeMonto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@hasta", xreg.c_HastaMonto.c_Valor)
                                    xcmd.Parameters.AddWithValue("@tipo", xreg.c_TipoTablaComision.c_Texto).Size = xreg.c_TipoTablaComision.c_Largo
                                    xcmd.ExecuteNonQuery()
                                End Using
                                xtr.Commit()
                                RaiseEvent _ActualizarRegla()
                                Return True
                            Catch ex2 As SqlException
                                xtr.Rollback()
                                Select Case ex2.Number
                                    Case 2627 : Throw New Exception("ERROR AL AGREGAR REGLA, AUTOMATICO YA REGISTRADO")
                                    Case Else : Throw New Exception(ex2.Message + "ERROR NUMERO:" + ex2.Number.ToString)
                                End Select
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("TABLA COMISIONES" + vbCrLf + "AGREGAR NUEVA REGLA" + vbCrLf + ex.Message)
                    End Try
                End Function

                Function F_EliminarRegla(ByVal xauto As String) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Using xcmd As New SqlCommand("", xcon)
                                    xcmd.Parameters.Clear()
                                    xcmd.CommandText = Eliminar_1
                                    xcmd.Parameters.AddWithValue("@auto", xauto)
                                    xcmd.ExecuteNonQuery()
                                End Using
                                RaiseEvent _ActualizarRegla()
                                Return True
                            Catch ex2 As SqlException
                                Throw New Exception(ex2.Message + vbCrLf + "ERROR NUMERO: " + ex2.Number.ToString)
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("TABLA COMISIONES" + vbCrLf + "ELIMINAR REGLA" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            Private xdeposito As c_Depositos
            Private xfiscal As c_TasasFiscales
            Private xempresa As c_Negocio
            Private xusuario As c_Usuario
            Private xseriefiscal As c_SeriesFiscales
            Private xconfsistema As c_ConfSistema
            Private xpermisosusuario As c_PermisosDelUsuario
            Private xgrupoopciones As c_GrupoOpciones
            Private xmediospago As c_MediosPagos
            Private xgrupousuario As c_GrupoUsuarios
            Private xestado As c_Estados
            Private xinstalacion As c_Instalacion
            Private xtablacomisiones As c_TablaComisiones

            ''' <summary>
            ''' FICHA DEPOSITOS
            ''' </summary>
            Property f_Depositos() As c_Depositos
                Get
                    Return xdeposito
                End Get
                Set(ByVal value As c_Depositos)
                    xdeposito = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA TASAS FISCALES
            ''' </summary>
            Property f_Fiscal() As c_TasasFiscales
                Get
                    Return xfiscal
                End Get
                Set(ByVal value As c_TasasFiscales)
                    xfiscal = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA NEGOCIO
            ''' </summary>
            Property f_Negocio() As c_Negocio
                Get
                    Return xempresa
                End Get
                Set(ByVal value As c_Negocio)
                    xempresa = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA USUARIO
            ''' </summary>
            Property f_Usuario() As c_Usuario
                Get
                    Return xusuario
                End Get
                Set(ByVal value As c_Usuario)
                    xusuario = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA SERIES FISCALES
            ''' </summary>
            Property f_SeriesFiscales() As c_SeriesFiscales
                Get
                    Return xseriefiscal
                End Get
                Set(ByVal value As c_SeriesFiscales)
                    xseriefiscal = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA CONFIGURACION DEL SISTEMA
            ''' </summary>
            Property f_ConfSistema() As c_ConfSistema
                Get
                    Return xconfsistema
                End Get
                Set(ByVal value As c_ConfSistema)
                    xconfsistema = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA PERMISOS DEL USUARIO, INDICA LOS PERMISOS OTORGADOS A CADA UNA DE LAS OPCIONES DEL SISTEMA
            ''' </summary>
            Property f_PermisosUsuario() As c_PermisosDelUsuario
                Get
                    Return xpermisosusuario
                End Get
                Set(ByVal value As c_PermisosDelUsuario)
                    xpermisosusuario = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA GRUPO OPCIONES, GUARDA CONFIGURACION DE LAS OPCIONES DEL SISTEMA DADAS A UN GRUPO
            ''' </summary>
            Property f_GrupoOpciones() As c_GrupoOpciones
                Get
                    Return xgrupoopciones
                End Get
                Set(ByVal value As c_GrupoOpciones)
                    xgrupoopciones = value
                End Set
            End Property

            ''' <summary>
            ''' FICHA MEDIO DE PAGO, GUARDA LOS TIPOS DE PAGOS DEFINIDOS POR EL USUARIO
            ''' </summary>
            Property f_MediosPago() As c_MediosPagos
                Get
                    Return xmediospago
                End Get
                Set(ByVal value As c_MediosPagos)
                    xmediospago = value
                End Set
            End Property

            Property f_GrupoUsuarios() As c_GrupoUsuarios
                Get
                    Return xgrupousuario
                End Get
                Set(ByVal value As c_GrupoUsuarios)
                    xgrupousuario = value
                End Set
            End Property

            Property f_Estados() As c_Estados
                Get
                    Return xestado
                End Get
                Set(ByVal value As c_Estados)
                    xestado = value
                End Set
            End Property

            Property f_MiInstalacion() As c_Instalacion
                Get
                    Return xinstalacion
                End Get
                Set(ByVal value As c_Instalacion)
                    xinstalacion = value
                End Set
            End Property

            Property f_TablaComisiones() As c_TablaComisiones
                Get
                    Return xtablacomisiones
                End Get
                Set(ByVal value As c_TablaComisiones)
                    xtablacomisiones = value
                End Set
            End Property

            Sub New()
                xdeposito = New c_Depositos
                xfiscal = New c_TasasFiscales
                xempresa = New c_Negocio
                xusuario = New c_Usuario
                xseriefiscal = New c_SeriesFiscales
                xconfsistema = New c_ConfSistema
                xpermisosusuario = New c_PermisosDelUsuario
                xgrupoopciones = New c_GrupoOpciones
                xmediospago = New c_MediosPagos
                xgrupousuario = New c_GrupoUsuarios
                xestado = New c_Estados
                xinstalacion = New c_Instalacion
                xtablacomisiones = New c_TablaComisiones
            End Sub

            Function F_ActualizarOpcionConfiguracion(ByVal xcodigo_opcion As String, ByVal xvalor_usuario As String, ByVal id As Byte()) As Boolean
                Try
                    Dim xr As Integer = 0
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "update opciones set usuario=@usuario where codigo=@codigo and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@codigo", xcodigo_opcion)
                                xcmd.Parameters.AddWithValue("@usuario", xvalor_usuario)
                                xcmd.Parameters.AddWithValue("@id", id)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("OPCION NO ACTUALIZADA..." + vbCrLf + "MOTIVO: OTRO USUARIO ACTUALIZO LA MISMA OPCION / OPCION NO ENCONTRADA")
                                End If
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_ActualizarOpcionConfiguracion(ByVal xcodigo_opcion As String, ByVal xvalor_usuario As Integer, ByVal id As Byte()) As Boolean
                Try
                    Dim xr As Integer = 0
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "update opciones set usuario=@usuario where codigo=@codigo and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@codigo", xcodigo_opcion)
                                xcmd.Parameters.AddWithValue("@usuario", xvalor_usuario)
                                xcmd.Parameters.AddWithValue("@id", id)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("OPCION NO ACTUALIZADA..." + vbCrLf + "MOTIVO: OTRO USUARIO ACTUALIZO LA MISMA OPCION / OPCION NO ENCONTRADA")
                                End If
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Function F_ActualizarOpcionConfiguracion(ByVal xcodigo_opcion As String, ByVal xvalor_usuario As Single, ByVal id As Byte()) As Boolean
                Try
                    Dim xr As Integer = 0
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "update opciones set usuario=@usuario where codigo=@codigo and id_seguridad=@id"
                                xcmd.Parameters.AddWithValue("@codigo", xcodigo_opcion)
                                xcmd.Parameters.AddWithValue("@usuario", xvalor_usuario)
                                xcmd.Parameters.AddWithValue("@id", id)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("OPCION NO ACTUALIZADA..." + vbCrLf + "MOTIVO: OTRO USUARIO ACTUALIZO LA MISMA OPCION / OPCION NO ENCONTRADA")
                                End If
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function

            Class OpcionPermiso
                Private xgrupousuario As String
                Private xopcion As String
                Private xnivelseguridad As FichaGlobal.c_PermisosDelUsuario.Nivel
                Private xestatus As TipoEstatus

                Property _GrupoUsuario() As String
                    Protected Friend Get
                        Return xgrupousuario
                    End Get
                    Set(ByVal value As String)
                        xgrupousuario = value
                    End Set
                End Property

                Property _OpcionCambiar() As String
                    Protected Friend Get
                        Return xopcion
                    End Get
                    Set(ByVal value As String)
                        xopcion = value
                    End Set
                End Property

                Property _NivelSeguridad() As FichaGlobal.c_PermisosDelUsuario.Nivel
                    Get
                        Return xnivelseguridad
                    End Get
                    Set(ByVal value As FichaGlobal.c_PermisosDelUsuario.Nivel)
                        xnivelseguridad = value
                    End Set
                End Property

                Property _EstatusOpcion() As TipoEstatus
                    Get
                        Return xestatus
                    End Get
                    Set(ByVal value As TipoEstatus)
                        xestatus = value
                    End Set
                End Property

                Sub New()
                    _GrupoUsuario = ""
                    _NivelSeguridad = c_PermisosDelUsuario.Nivel.Nivel_Libre
                    _OpcionCambiar = ""
                    _EstatusOpcion = TipoEstatus.Inactivo
                End Sub
            End Class

            Function F_ActualizarPermiso(ByVal xopcion As OpcionPermiso) As Boolean
                Try
                    Dim xest As String = ""
                    Dim xseg As String = ""

                    If xopcion._EstatusOpcion = TipoEstatus.Activo Then
                        xest = "1"
                    Else
                        xest = "0"
                    End If

                    Select Case xopcion._NivelSeguridad
                        Case c_PermisosDelUsuario.Nivel.Nivel_Maximo : xseg = "Maximo"
                        Case c_PermisosDelUsuario.Nivel.Nivel_Medio : xseg = "Medio"
                        Case c_PermisosDelUsuario.Nivel.Nivel_Minimo : xseg = "Minimo"
                        Case c_PermisosDelUsuario.Nivel.Nivel_Libre : xseg = "Ninguna"
                    End Select

                    Dim xr As Integer = 0
                    Using xcon As New SqlConnection(_MiCadenaConexion)
                        xcon.Open()
                        Try
                            Using xcmd As New SqlCommand("", xcon)
                                xcmd.CommandText = "update grupo_opciones set seguridad=@seguridad, estatus=@estatus where codigo_grupo=@grupo and codigo_opcion=@opcion"
                                xcmd.Parameters.AddWithValue("@seguridad", xseg)
                                xcmd.Parameters.AddWithValue("@estatus", xest)
                                xcmd.Parameters.AddWithValue("@grupo", xopcion._GrupoUsuario)
                                xcmd.Parameters.AddWithValue("@opcion", xopcion._OpcionCambiar)
                                xr = xcmd.ExecuteNonQuery()
                                If xr = 0 Then
                                    Throw New Exception("OPCION NO ACTUALIZADA..." + vbCrLf + "MOTIVO: OTRO USUARIO ACTUALIZO LA MISMA OPCION / OPCION NO ENCONTRADA")
                                End If
                            End Using
                            Return True
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    End Using
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Function
        End Class

        Private xfichaGlobal As FichaGlobal

        ''' <summary>
        ''' Ficha General Productos
        ''' </summary>
        Property f_FichaGlobal() As FichaGlobal
            Get
                Return xfichaGlobal
            End Get
            Set(ByVal value As FichaGlobal)
                xfichaGlobal = value
            End Set
        End Property
    End Class
End Namespace

Imports System.Data
Imports System.Data.SqlClient
Imports System.Attribute

Namespace MiDataSistema
    Partial Public Class DataSistema

        Public Class FichaBancos
            ''' <summary>
            ''' CLASE FICHA AGENCIAS
            ''' </summary>
            Public Class c_Agencias
                Event Actualizar()

                Public Class c_ModificarAgencia
                    Private xreg As c_Registro

                    Sub New()
                        xreg = New c_Registro
                    End Sub

                    ''' <summary>
                    ''' PARA USO INTERNO 
                    ''' </summary>
                    Protected Friend ReadOnly Property c_AgenciaModificar() As c_Registro
                        Get
                            Return xreg
                        End Get
                    End Property

                    ''' <summary>
                    ''' Nombre Agencia A Modificar
                    ''' </summary>
                    WriteOnly Property c_NombreAgencia() As String
                        Set(ByVal value As String)
                            xreg.c_NombreAgencia.c_Texto = value
                        End Set
                    End Property

                    ''' <summary>
                    ''' Automatico Agencia A Modificar
                    ''' </summary>
                    WriteOnly Property c_AutomaticoAgencia() As String
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
                    ''' Campo, Automatico Agencia
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
                    ''' Campo, Nombre Agencia
                    ''' </summary>
                    Property c_NombreAgencia() As CampoTexto
                        Get
                            Return f_nombre
                        End Get
                        Protected Friend Set(ByVal value As CampoTexto)
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
                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return f_id_seguridad
                        End Get
                    End Property

                    ''' <summary>
                    ''' Funcion: Retorna El Automatico Agencia
                    ''' </summary>
                    ReadOnly Property _Automatico() As String
                        Get
                            Return Me.c_Automatico.c_Texto.Trim
                        End Get
                    End Property

                    ReadOnly Property _NombreAgencia() As String
                        Get
                            Return Me.c_NombreAgencia.c_Texto.Trim
                        End Get
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Automatico = New CampoTexto(10, "auto")
                        c_NombreAgencia = New CampoTexto(40, "nombre")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreAgencia.c_Texto = xrow(.c_NombreAgencia.c_NombreInterno)

                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("AGENCIAS BANCARIAS" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
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

                Private Const AgregarRegistro_1 As String = "update contadores set a_agencias=a_agencias+1; select a_agencias from contadores"
                Private Const AgregarRegistro_2 As String = "insert into agencias (auto,nombre) values (@auto,@nombre)"
                Private Const ModificarRegistro_1 As String = "update agencias set nombre=@nombre where auto=@auto and id_seguridad=@id_seguridad"
                Private Const EliminarRegistro As String = "delete agencias where auto=@auto"

                Sub New()
                    RegistroDato = New c_Registro
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                ''' <summary>
                '''  Funcion: Permite Eliminar Un Registro De la BD
                ''' </summary>
                Function F_EliminaAgencia(ByVal xautomatico As String) As Boolean
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
                                    Throw New Exception("ERROR AL ELIMINAR AGENCIA BANCARIA, EXISTEN CTAS ACTIVAS DENTRO DE ESTA AGENCIA")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("AGENCIAS BANCARIAS" + vbCrLf + "ELIMINAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Agregar Un Registro A La BD
                ''' </summary>
                Function F_NuevoAgencia(ByVal xnombre As String) As Boolean
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
                                    Throw New Exception("ERROR AL AGREGAR AGENCIA BANCARIA, EXISTE UNA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                xtr.Rollback()
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("AGENCIAS BANCARIAS" + vbCrLf + "AGREGAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function

                ''' <summary>
                '''  Funcion: Permite Modificar Un Registro De La BD
                ''' </summary>
                Function F_ModificaGrupo(ByVal xagencia As c_ModificarAgencia) As Boolean
                    Try
                        Using xcon As New SqlConnection(_MiCadenaConexion)
                            xcon.Open()
                            Try
                                Dim xr As Integer = 0

                                Using xcmd As New SqlCommand(ModificarRegistro_1, xcon)
                                    xcmd.Parameters.AddWithValue("@auto", xagencia.c_AgenciaModificar.c_Automatico.c_Texto)
                                    xcmd.Parameters.AddWithValue("@NOMBRE", xagencia.c_AgenciaModificar.c_NombreAgencia.c_Texto)
                                    xcmd.Parameters.AddWithValue("@ID_SEGURIDAD", xagencia.c_AgenciaModificar.c_IdSeguridad)
                                    xr = xcmd.ExecuteNonQuery()
                                End Using
                                If xr = 0 Then
                                    Throw New Exception("ERROR AL MODIFICAR AGENCIA BANCARIA, AGENCIA HA SIDO ACTUALIZADO POR OTRO USURAIO")
                                End If
                                RaiseEvent Actualizar()
                                Return True
                            Catch ex2 As SqlException
                                If ex2.Number = 2601 Then
                                    Throw New Exception("ERROR AL MODIFICAR AGENCIA BANCARIA, EXISTE UNA CON EL MISMO NOMBRE")
                                Else
                                    Throw New Exception(ex2.Message)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        End Using
                    Catch ex As Exception
                        Throw New Exception("AGENCIAS BANCARIAS" + vbCrLf + "MODIFICAR REGISTRO" + vbCrLf + ex.Message)
                    End Try
                End Function
            End Class

            ''' <summary>
            ''' CLASE FICHA BANCOS
            ''' </summary>
            Public Class c_Bancos

                ''' <summary>
                ''' Clase Registro De Dato 
                ''' </summary>
                Class c_Registro
                    Private f_auto As CampoTexto
                    Private f_banco As CampoTexto
                    Private f_tipo_cuenta As CampoTexto
                    Private f_numero_cuenta As CampoTexto
                    Private f_ultimo_numero_cheque As CampoDecimal
                    Private f_codigo_contable As CampoTexto
                    Private f_saldo_real As CampoDecimal
                    Private f_saldo_conciliado As CampoDecimal
                    Private f_debito_bancario As CampoTexto
                    Private f_dir As CampoTexto
                    Private f_contacto As CampoTexto
                    Private f_telefono As CampoTexto
                    Private f_email As CampoTexto
                    Private f_website As CampoTexto
                    Private f_comentarios As CampoTexto
                    Private f_estatus As CampoTexto
                    Private f_fecha_apertura As CampoFecha
                    Private f_fecha_alta As CampoFecha
                    Private f_fecha_conciliacion As CampoFecha
                    Private f_total_debitos As CampoDecimal
                    Private f_total_creditos As CampoDecimal
                    Private f_saldo_inicial As CampoDecimal

                    'NUEVOS CAMPOS
                    Private f_telefono_1 As CampoTexto
                    Private f_telefono_2 As CampoTexto
                    Private f_telefono_3 As CampoTexto
                    Private f_telefono_4 As CampoTexto
                    Private f_celular_1 As CampoTexto
                    Private f_celular_2 As CampoTexto
                    Private f_fax_1 As CampoTexto
                    Private f_fax_2 As CampoTexto
                    Private f_gerente As CampoTexto
                    Private f_beneficiario As CampoTexto
                    Private f_id_seguridad As Byte()

                    Protected Friend Property c_Automatico() As CampoTexto
                        Get
                            Return f_auto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_auto = value
                        End Set
                    End Property
                    Property c_NombreBanco() As CampoTexto
                        Get
                            Return f_banco
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_banco = value
                        End Set
                    End Property
                    Protected Friend Property c_TipoCuenta() As CampoTexto
                        Get
                            Return f_tipo_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_tipo_cuenta = value
                        End Set
                    End Property
                    Property c_NumeroCuenta() As CampoTexto
                        Get
                            Return f_numero_cuenta
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_numero_cuenta = value
                        End Set
                    End Property
                    Property c_UltimoNumeroCheque() As CampoDecimal
                        Get
                            Return f_ultimo_numero_cheque
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_ultimo_numero_cheque = value
                        End Set
                    End Property
                    Property c_CodigoContable() As CampoTexto
                        Get
                            Return f_codigo_contable
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_codigo_contable = value
                        End Set
                    End Property
                    Property c_SaldoReal() As CampoDecimal
                        Get
                            Return f_saldo_real
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_saldo_real = value
                        End Set
                    End Property
                    Property c_SaldoConciliado() As CampoDecimal
                        Get
                            Return f_saldo_conciliado
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_saldo_conciliado = value
                        End Set
                    End Property
                    Protected Friend Property c_DebitoBancario() As CampoTexto
                        Get
                            Return f_debito_bancario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_debito_bancario = value
                        End Set
                    End Property
                    Property c_Direccion() As CampoTexto
                        Get
                            Return f_dir
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_dir = value
                        End Set
                    End Property
                    Property c_NombreContacto() As CampoTexto
                        Get
                            Return f_contacto
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_contacto = value
                        End Set
                    End Property
                    Property c_Telefono() As CampoTexto
                        Get
                            Return f_telefono
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono = value
                        End Set
                    End Property
                    Property c_Email() As CampoTexto
                        Get
                            Return f_email
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_email = value
                        End Set
                    End Property
                    Property c_Website() As CampoTexto
                        Get
                            Return f_website
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_website = value
                        End Set
                    End Property
                    Property c_Comentarios() As CampoTexto
                        Get
                            Return f_comentarios
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_comentarios = value
                        End Set
                    End Property
                    Protected Friend Property c_Estatus() As CampoTexto
                        Get
                            Return f_estatus
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_estatus = value
                        End Set
                    End Property
                    Protected Friend Property c_FechaApertura() As CampoFecha
                        Get
                            Return f_fecha_apertura
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_apertura = value
                        End Set
                    End Property
                    Property c_FechaAlta() As CampoFecha
                        Get
                            Return f_fecha_alta
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_alta = value
                        End Set
                    End Property
                    Protected Friend Property c_FechaConciliacion() As CampoFecha
                        Get
                            Return f_fecha_conciliacion
                        End Get
                        Set(ByVal value As CampoFecha)
                            f_fecha_conciliacion = value
                        End Set
                    End Property
                    Property c_TotalDebitos() As CampoDecimal
                        Get
                            Return f_total_debitos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total_debitos = value
                        End Set
                    End Property
                    Property c_TotalCreditos() As CampoDecimal
                        Get
                            Return f_total_creditos
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_total_creditos = value
                        End Set
                    End Property
                    Property c_SaldoInicial() As CampoDecimal
                        Get
                            Return f_saldo_inicial
                        End Get
                        Set(ByVal value As CampoDecimal)
                            f_saldo_inicial = value
                        End Set
                    End Property

                    'NUEVOS CAMPOS
                    Property c_Telefono_1() As CampoTexto
                        Get
                            Return f_telefono_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_1 = value
                        End Set
                    End Property
                    Property c_Telefono_2() As CampoTexto
                        Get
                            Return f_telefono_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_2 = value
                        End Set
                    End Property
                    Property c_Telefono_3() As CampoTexto
                        Get
                            Return f_telefono_3
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_3 = value
                        End Set
                    End Property
                    Property c_Telefono_4() As CampoTexto
                        Get
                            Return f_telefono_4
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_telefono_4 = value
                        End Set
                    End Property
                    Property c_Celular_1() As CampoTexto
                        Get
                            Return f_celular_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_celular_1 = value
                        End Set
                    End Property
                    Property c_Celular_2() As CampoTexto
                        Get
                            Return f_celular_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_celular_2 = value
                        End Set
                    End Property
                    Property c_Fax_1() As CampoTexto
                        Get
                            Return f_fax_1
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_fax_1 = value
                        End Set
                    End Property
                    Property c_Fax_2() As CampoTexto
                        Get
                            Return f_fax_2
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_fax_2 = value
                        End Set
                    End Property
                    Property c_NombreGerente() As CampoTexto
                        Get
                            Return f_gerente
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_gerente = value
                        End Set
                    End Property
                    Property c_NombreTitular() As CampoTexto
                        Get
                            Return f_beneficiario
                        End Get
                        Set(ByVal value As CampoTexto)
                            f_beneficiario = value
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
                    ReadOnly Property _Automatico() As String
                        Get
                            Return c_Automatico.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreBanco() As String
                        Get
                            Return c_NombreBanco.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _TipoCuenta() As TipoCuentaBancaria
                        Get
                            Select Case c_TipoCuenta.c_Texto.Trim
                                Case "AHORRO" : Return TipoCuentaBancaria.Ahorro
                                Case "CORRIENTE" : Return TipoCuentaBancaria.Corriente
                                Case "FAL" : Return TipoCuentaBancaria.Fal
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _NumeroCuenta() As String
                        Get
                            Return c_NumeroCuenta.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _UltimoNumeroCheque() As Decimal
                        Get
                            Return c_UltimoNumeroCheque.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _CodigoContable() As String
                        Get
                            Return c_CodigoContable.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _SaldoReal() As Decimal
                        Get
                            Return c_SaldoReal.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _SaldoConciliado() As Decimal
                        Get
                            Return c_SaldoConciliado.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _DebitoBancario() As Boolean
                        Get
                            Select Case c_DebitoBancario.c_Texto.Trim
                                Case "0" : Return False
                                Case "1" : Return True
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _Direccion() As String
                        Get
                            Return c_Direccion.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreContacto() As String
                        Get
                            Return c_NombreContacto.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Telefono() As String
                        Get
                            Return c_Telefono.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Email() As String
                        Get
                            Return c_Email.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Website() As String
                        Get
                            Return c_Website.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Comentarios() As String
                        Get
                            Return c_Comentarios.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Estatus() As TipoEstatus
                        Get
                            Select Case c_Estatus.c_Texto.Trim
                                Case "Activo" : Return TipoEstatus.Activo
                                Case "Inactivo" : Return TipoEstatus.Inactivo
                            End Select
                        End Get
                    End Property
                    ReadOnly Property _FechaApertura() As Date
                        Get
                            Return c_FechaApertura.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _FechaAlta() As Date
                        Get
                            Return c_FechaAlta.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _FechaConciliacion() As Date
                        Get
                            Return c_FechaConciliacion.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TotalDebitos() As Decimal
                        Get
                            Return c_TotalDebitos.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _TotalCreditos() As Decimal
                        Get
                            Return c_TotalCreditos.c_Valor
                        End Get
                    End Property
                    ReadOnly Property _SaldoInicial() As Decimal
                        Get
                            Return c_SaldoInicial.c_Valor
                        End Get
                    End Property

                    'NUEVOS CAMPOS
                    ReadOnly Property _Telefono_1() As String
                        Get
                            Return c_Telefono_1.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Telefono_2() As String
                        Get
                            Return c_Telefono_2.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Telefono_3() As String
                        Get
                            Return c_Telefono_3.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Telefono_4() As String
                        Get
                            Return c_Telefono_4.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Celular_1() As String
                        Get
                            Return c_Celular_1.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Celular_2() As String
                        Get
                            Return c_Celular_2.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Fax_1() As String
                        Get
                            Return c_Fax_1.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _Fax_2() As String
                        Get
                            Return c_Fax_2.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreGerente() As String
                        Get
                            Return c_NombreGerente.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _NombreTitular() As String
                        Get
                            Return c_NombreTitular.c_Texto.Trim
                        End Get
                    End Property
                    ReadOnly Property _IdSeguridad() As Byte()
                        Get
                            Return c_IdSeguridad
                        End Get
                    End Property
                    ReadOnly Property _TasaDebitoBancario() As Decimal
                        Get
                            Return F_GetDecimal("select debito_bancario from fiscal")
                        End Get
                    End Property

                    ''' <summary>
                    '''  Metodo: Limpiar / Inicializar Registro
                    ''' </summary>
                    Sub LimpiarRegistro()
                        LimpiarVariableTipo(Me)
                    End Sub

                    Sub New()
                        c_Automatico = New CampoTexto(10, "auto")
                        c_NombreBanco = New CampoTexto(50, "banco")
                        c_TipoCuenta = New CampoTexto(25, "tipo_cuenta")
                        c_NumeroCuenta = New CampoTexto(25, "numero_cuenta")
                        c_UltimoNumeroCheque = New CampoDecimal("ultimo_numero_cheque")
                        c_CodigoContable = New CampoTexto(20, "codigo_contable")
                        c_SaldoReal = New CampoDecimal("saldo_real")
                        c_SaldoConciliado = New CampoDecimal("saldo_conciliado")
                        c_DebitoBancario = New CampoTexto(1, "debito_bancario")
                        c_Direccion = New CampoTexto(120, "dir")
                        c_NombreContacto = New CampoTexto(50, "contacto")
                        c_Telefono = New CampoTexto(60, "telefono")
                        c_Email = New CampoTexto(50, "email")
                        c_Website = New CampoTexto(50, "website")
                        c_Comentarios = New CampoTexto(60, "comentarios")
                        c_Estatus = New CampoTexto(20, "estatus")
                        c_FechaApertura = New CampoFecha("fecha_apertura")
                        c_FechaAlta = New CampoFecha("fecha_alta")
                        c_FechaConciliacion = New CampoFecha("fecha_conciliacion")
                        c_TotalDebitos = New CampoDecimal("total_debitos")
                        c_TotalCreditos = New CampoDecimal("total_creditos")
                        c_SaldoInicial = New CampoDecimal("saldo_inicial")

                        'NUEVOS CAMPOS
                        c_Telefono_1 = New CampoTexto(14, "telefono_1")
                        c_Telefono_2 = New CampoTexto(14, "telefono_2")
                        c_Telefono_3 = New CampoTexto(14, "telefono_3")
                        c_Telefono_4 = New CampoTexto(14, "telefono_4")
                        c_Celular_1 = New CampoTexto(14, "celular_1")
                        c_Celular_2 = New CampoTexto(14, "celular_2")
                        c_Fax_1 = New CampoTexto(14, "fax_1")
                        c_Fax_2 = New CampoTexto(14, "fax_2")
                        c_NombreGerente = New CampoTexto(50, "gerente")
                        c_NombreTitular = New CampoTexto(50, "beneficiario")

                        LimpiarRegistro()
                    End Sub

                    Sub CargarRegistro(ByVal xrow As DataRow)
                        Try
                            Me.LimpiarRegistro()

                            With Me
                                .c_Automatico.c_Texto = xrow(.c_Automatico.c_NombreInterno)
                                .c_NombreBanco.c_Texto = xrow(.c_NombreBanco.c_NombreInterno)
                                .c_TipoCuenta.c_Texto = xrow(.c_TipoCuenta.c_NombreInterno)
                                .c_NumeroCuenta.c_Texto = xrow(.c_NumeroCuenta.c_NombreInterno)
                                .c_UltimoNumeroCheque.c_Valor = xrow(.c_UltimoNumeroCheque.c_NombreInterno)
                                .c_CodigoContable.c_Texto = xrow(.c_CodigoContable.c_NombreInterno)
                                .c_SaldoReal.c_Valor = xrow(.c_SaldoReal.c_NombreInterno)
                                .c_SaldoConciliado.c_Valor = xrow(.c_SaldoConciliado.c_NombreInterno)
                                .c_DebitoBancario.c_Texto = xrow(.c_DebitoBancario.c_NombreInterno)
                                .c_Direccion.c_Texto = xrow(.c_Direccion.c_NombreInterno)
                                .c_NombreContacto.c_Texto = xrow(.c_NombreContacto.c_NombreInterno)
                                .c_Telefono.c_Texto = xrow(.c_Telefono.c_NombreInterno)
                                .c_Email.c_Texto = xrow(.c_Email.c_NombreInterno)
                                .c_Website.c_Texto = xrow(.c_Website.c_NombreInterno)
                                .c_Comentarios.c_Texto = xrow(.c_Comentarios.c_NombreInterno)
                                .c_Estatus.c_Texto = xrow(.c_Estatus.c_NombreInterno)
                                .c_FechaApertura.c_Valor = xrow(.c_FechaApertura.c_NombreInterno)
                                .c_FechaAlta.c_Valor = xrow(.c_FechaAlta.c_NombreInterno)
                                .c_FechaConciliacion.c_Valor = xrow(.c_FechaConciliacion.c_NombreInterno)
                                .c_TotalDebitos.c_Valor = xrow(.c_TotalDebitos.c_NombreInterno)
                                .c_TotalCreditos.c_Valor = xrow(.c_TotalCreditos.c_NombreInterno)
                                .c_SaldoInicial.c_Valor = xrow(.c_SaldoInicial.c_NombreInterno)

                                'NUEVOS CAMPOS
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
                                    .c_Fax_2.c_Texto = xrow(.c_Fax_1.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NombreGerente.c_NombreInterno)) Then
                                    .c_NombreGerente.c_Texto = xrow(.c_NombreGerente.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow(.c_NombreTitular.c_NombreInterno)) Then
                                    .c_NombreTitular.c_Texto = xrow(.c_NombreTitular.c_NombreInterno)
                                End If
                                If Not IsDBNull(xrow("id_seguridad")) Then
                                    .c_IdSeguridad = xrow("id_seguridad")
                                End If
                            End With
                        Catch ex As Exception
                            Throw New Exception("BANCO" + vbCrLf + "CARGAR DATA:" + vbCrLf + ex.Message)
                        End Try
                    End Sub
                End Class

                ''' <summary>
                ''' Clase Para Agregar Un Nuevo Cliente
                ''' </summary>
                Class c_AgregarBanco
                    WriteOnly Property _NumeroCuenta() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroCuenta.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreBanco() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreBanco.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TipoCuenta() As TipoCuentaBancaria
                        Set(ByVal value As TipoCuentaBancaria)
                            Select Case value
                                Case TipoCuentaBancaria.Ahorro : Me.RegistroDato.c_TipoCuenta.c_Texto = "AHORRO"
                                Case TipoCuentaBancaria.Corriente : Me.RegistroDato.c_TipoCuenta.c_Texto = "CORRIENTE"
                                Case TipoCuentaBancaria.Fal : Me.RegistroDato.c_TipoCuenta.c_Texto = "FAL"
                            End Select
                        End Set
                    End Property
                    WriteOnly Property _Direccion() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Direccion.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreGerente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreGerente.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreTitular() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreTitular.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreContacto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreContacto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Email.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Website() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Website.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _FechaApertura() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaApertura.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _UltimoNumeroCheque() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_UltimoNumeroCheque.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Comentarios.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_3() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_3.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_4() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_4.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Celular_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Celular_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Fax_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Fax_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoContable() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoContable.c_Texto = value
                        End Set
                    End Property

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

                    Sub New()
                        xregistro = New c_Registro
                    End Sub
                End Class

                ''' <summary>
                ''' Clase Para Modificar Un Nuevo Cliente
                ''' </summary>
                Class c_ModificarBanco
                    WriteOnly Property _Automatico() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Automatico.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NumeroCuenta() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NumeroCuenta.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreBanco() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreBanco.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _TipoCuenta() As TipoCuentaBancaria
                        Set(ByVal value As TipoCuentaBancaria)
                            Select Case value
                                Case TipoCuentaBancaria.Ahorro : Me.RegistroDato.c_TipoCuenta.c_Texto = "AHORRO"
                                Case TipoCuentaBancaria.Corriente : Me.RegistroDato.c_TipoCuenta.c_Texto = "CORRIENTE"
                                Case TipoCuentaBancaria.Fal : Me.RegistroDato.c_TipoCuenta.c_Texto = "FAL"
                            End Select
                        End Set
                    End Property
                    WriteOnly Property _Direccion() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Direccion.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreGerente() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreGerente.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreTitular() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreTitular.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _NombreContacto() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_NombreContacto.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Email() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Email.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Website() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Website.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _FechaApertura() As Date
                        Set(ByVal value As Date)
                            Me.RegistroDato.c_FechaApertura.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _UltimoNumeroCheque() As Decimal
                        Set(ByVal value As Decimal)
                            Me.RegistroDato.c_UltimoNumeroCheque.c_Valor = value
                        End Set
                    End Property
                    WriteOnly Property _Comentarios() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Comentarios.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_3() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_3.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Telefono_4() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Telefono_4.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Celular_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Celular_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Celular_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Celular_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Fax_1() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Fax_1.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _Fax_2() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_Fax_2.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _CodigoContable() As String
                        Set(ByVal value As String)
                            Me.RegistroDato.c_CodigoContable.c_Texto = value
                        End Set
                    End Property
                    WriteOnly Property _IdSeguridad() As Byte()
                        Set(ByVal value As Byte())
                            Me.RegistroDato.c_IdSeguridad = value
                        End Set
                    End Property
                    Property _Estatus() As TipoEstatus
                        Get
                            Return Me.RegistroDato._Estatus
                        End Get
                        Set(ByVal value As TipoEstatus)
                            Select Case value
                                Case TipoEstatus.Activo : Me.RegistroDato.c_Estatus.c_Texto = "Activo"
                                Case TipoEstatus.Inactivo : Me.RegistroDato.c_Estatus.c_Texto = "Inactivo"
                            End Select
                        End Set
                    End Property

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

                    Sub New()
                        xregistro = New c_Registro
                    End Sub
                End Class

                Private xtipo_cuenta As String() = {"Cuenta Ahorro", "Cuenta Corriente", "Cuenta FAL"}
                ReadOnly Property p_TipoCuentaBancaria() As String()
                    Get
                        Return xtipo_cuenta
                    End Get
                End Property

                Private xtipo_busqueda As String() = {"Por Numero De Cuenta", "Por Nombre Del Banco", "Por Nombre Del Titular"}
                ReadOnly Property p_TipoBusqueda() As String()
                    Get
                        Return xtipo_busqueda
                    End Get
                End Property
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

                Private xtabla As DataTable

                Sub New()
                    RegistroDato = New c_Registro
                    xtabla = New DataTable("BANCOS")
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
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Sub M_CargarFicha(ByVal xrow As DataRow)
                    Try
                        Me.RegistroDato.CargarRegistro(xrow)
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Sub

                ''' <summary>
                ''' Metodo: Limpiar Tabla De Dato
                ''' </summary>
                Sub M_LimpiarRegistro()
                    Me.RegistroDato.LimpiarRegistro()
                End Sub

                ''' <summary>
                '''  Metodo: Permite Cargar Data Al Registro De Dato
                ''' </summary>
                Function F_CargarRegistro(ByVal xauto As String) As Boolean
                    Dim f_data As New DataTable
                    Try
                        Using f_adapter As New SqlDataAdapter("select * from bancos where auto=@auto", _MiCadenaConexion)
                            f_adapter.SelectCommand.Parameters.AddWithValue("@auto", xauto)
                            f_adapter.Fill(f_data)
                        End Using
                        If (f_data.Rows.Count > 0) Then
                            Me.RegistroDato.CargarRegistro(f_data.Rows.Item(0))
                        Else
                            Throw New Exception("BANCOS" + vbCrLf + "CARGAR REGISTRO" + vbCrLf + "Error No Hay Informacion Para Este Registro")
                        End If
                        Return True
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function

                Function F_UltimoChequeProcesado(ByVal xauto As String) As Decimal
                    Try
                        Dim xultcheque As Decimal = 0
                        Dim xsql As String = "select max(CONVERT(decimal(18,0), documento)) ultcheque from movimientos where auto_banco=@auto_banco and tipo ='CHQ'"
                        Dim xp1 As New SqlParameter("@auto_banco", xauto)
                        xultcheque = F_GetDecimal(xsql, xp1)
                        Return xultcheque
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                End Function
            End Class

        End Class

        Private xfichabanco As FichaBancos

        ''' <summary>
        ''' Ficha General Bancos
        ''' </summary>
        Property f_FichaBancos() As FichaBancos
            Get
                Return xfichabanco
            End Get
            Set(ByVal value As FichaBancos)
                xfichabanco = value
            End Set
        End Property
    End Class
End Namespace


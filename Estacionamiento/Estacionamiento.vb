Imports System.Data.SqlClient

Namespace MiDataSistema
    Partial Public Class DataSistema

        Partial Public Class Estacionamiento

            Private xentradasalida As Entradas_Salidas
            Private xTarifas As Tarifas
            Private xTarjetas_EntradaSalidas As Tarjetas_EntradaSalidas
            Private xBarra As ControlBarras
            Private xticketextraviado As TicketsExtraviados

            Property f_EntradaSalida() As Entradas_Salidas
                Get
                    Return xentradasalida
                End Get
                Set(ByVal value As Entradas_Salidas)
                    xentradasalida = value
                End Set
            End Property

            Property f_Tarifas() As Tarifas
                Get
                    Return xTarifas
                End Get
                Set(ByVal value As Tarifas)
                    xTarifas = value
                End Set
            End Property

            Property f_TarjetasEntradasSalidas() As Tarjetas_EntradaSalidas
                Get
                    Return xTarjetas_EntradaSalidas
                End Get
                Set(ByVal value As Tarjetas_EntradaSalidas)
                    xTarjetas_EntradaSalidas = value
                End Set
            End Property

            Property f_ControlBarra() As ControlBarras
                Get
                    Return xBarra
                End Get
                Set(ByVal value As ControlBarras)
                    xBarra = value
                End Set
            End Property

            Property f_TicketExtraviado() As TicketsExtraviados
                Get
                    Return xticketextraviado
                End Get
                Set(ByVal value As TicketsExtraviados)
                    xticketextraviado = value
                End Set
            End Property


            Sub New()
                Me.f_EntradaSalida = New Entradas_Salidas
                Me.f_Tarifas = New Tarifas
                Me.f_TarjetasEntradasSalidas = New Tarjetas_EntradaSalidas
                Me.f_ControlBarra = New ControlBarras
                Me.f_TicketExtraviado = New TicketsExtraviados
            End Sub


            ''' <summary>
            ''' Retorna Clase Indicando el tiempo de parqueo del carro
            ''' </summary>
            ''' <param name="myAutoMovEntrada"> Atuo Movimiento De Entrada </param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Function F_TiempoTrancurrido(ByVal myAutoMovEntrada As String) As Tiempo
                Try
                    Dim xtiempo As New Tiempo
                    Dim TiempoEntrada As String
                    Dim TiempoSalida As String
                    Dim xtb As New DataTable
                    Dim xsql As String = "Select Fecha_Entrada,Hora_entrada from " & _
                          "estacionamiento_entradas_salidas where estatus='0' and auto=@auto"

                    Using xadp As New SqlDataAdapter("", _MiCadenaConexion)
                        xadp.SelectCommand.CommandText = xsql
                        xadp.SelectCommand.Parameters.AddWithValue("@auto", myAutoMovEntrada)
                        xadp.Fill(xtb)
                    End Using

                    If xtb.Rows.Count > 0 Then
                        TiempoEntrada = xtb(0)(0) & " " & xtb(0)(1)
                        TiempoSalida = F_GetDate("Select getdate()")

                        With xtiempo
                            ._Dias = DateDiff(DateInterval.Day, CDate(TiempoEntrada), CDate(TiempoSalida))
                            ._Horas = DateDiff(DateInterval.Hour, CDate(TiempoEntrada), CDate(TiempoSalida)) - (._Dias * 24)
                            ._Minutos = DateDiff(DateInterval.Minute, CDate(TiempoEntrada), CDate(TiempoSalida)) - ((._Dias * 24 * 60) + (._Horas * 60))
                        End With
                    Else
                        Throw New Exception("AUTO MOVIMIENTO ENTRADA NO ENCONTRADO")
                    End If
                    Return xtiempo
                Catch ex As Exception
                    Throw New Exception("ESTACIONAMIENTO - TIEMPO TRANSCURRIDO" & vbCrLf & ex.Message)
                End Try
            End Function
        End Class

        Private xfichaestacionamiento As Estacionamiento

        Property f_FichaEstacionamiento() As Estacionamiento
            Get
                Return xfichaestacionamiento
            End Get
            Set(ByVal value As Estacionamiento)
                xfichaestacionamiento = value
            End Set
        End Property

    End Class
End Namespace
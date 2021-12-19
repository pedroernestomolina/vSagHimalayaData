Imports System.Data.SqlClient

Module Module1
    ''' <summary>
    ''' Funcion: Retorna El Porcentaje de Utilidad En Base Al Costo
    ''' </summary>
    ''' <param name="xcosto"></param>
    ''' Costo de Venta
    ''' <param name="xmargen"></param>
    ''' Margen/Ganancia A Obtener
    ''' <returns></returns>
    Function UtilidadBaseCosto(ByVal xcosto As Decimal, ByVal xmargen As Decimal)
        If xcosto > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xcosto) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return 100
        End If
    End Function

    ''' <summary>
    ''' Funcion: Retorna El Porcentaje de Utilidad En Base Al Precio De Venta
    ''' </summary>
    ''' <param name="xpventa"></param>
    ''' Precio De Venta
    ''' <param name="xmargen"></param>
    ''' ;argen/Ganancia A Obtener
    ''' <returns></returns>
    Function UtilidadBasePrecioVenta(ByVal xpventa As Decimal, ByVal xmargen As Decimal)
        If xpventa > 0 Then
            Dim x As Decimal = 0
            x = (xmargen / xpventa) * 100
            x = Decimal.Round(x, 2, MidpointRounding.AwayFromZero)
            Return x
        Else
            Return -100
        End If
    End Function

    Function _FechaSistema(ByVal xcadena As String) As Date
        Try
            Using xcon As New SqlConnection(xcadena)
                xcon.Open()
                Using xcmd As New SqlCommand("SELECT getdate()", xcon)
                    Return CType(xcmd.ExecuteScalar(), Date).Date
                End Using
            End Using
        Catch ex As Exception
            Return Date.MinValue
        End Try
    End Function
End Module

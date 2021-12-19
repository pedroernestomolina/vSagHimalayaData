Public Class Pedido_CambioEstatusActivo

    Property autoDoc As String
    Property items As List(Of Pedido_CambioEstatusActivo_Item)


    Sub New()
        autoDoc = ""
        items = New List(Of Pedido_CambioEstatusActivo_Item)
    End Sub

End Class

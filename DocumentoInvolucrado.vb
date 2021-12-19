Public Class DocumentoInvolucrado
    Property autoDoc As String
    Property numDoc As String
    Property fechaEmisionDoc As String
    Property diasValidezDoc As Integer
    Property tipoDoc As String
    Property estatusBloqueoAlm As Boolean
    Property listPrd As List(Of DocumentoInvolucrado_Producto)


    Sub New()
        autoDoc = ""
        numDoc = ""
        fechaEmisionDoc = DateAndTime.Now.Date
        diasValidezDoc = 0
        tipoDoc = ""
        estatusBloqueoAlm = True
        listPrd = New List(Of DocumentoInvolucrado_Producto)
    End Sub

End Class

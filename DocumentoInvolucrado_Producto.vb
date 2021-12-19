Public Class DocumentoInvolucrado_Producto
    Public autoPrd As String
    Public autoDep As String
    Public cnt As Decimal
    Public nomPrd As String


    Sub New(autoPrd As String, autoDep As String, cnt As Decimal, nombrePrd As String)
        Me.autoPrd = autoPrd
        Me.autoDep = autoDep
        Me.nomPrd = nombrePrd
        Me.cnt = cnt
    End Sub
End Class
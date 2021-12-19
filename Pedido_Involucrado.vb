Public Class Pedido_Involucrado
    Public Property documentoNro As String
    Public Property fechaEmision As Date
    Public Property estatus As String
    Public Property estatusBloqueoDeposito As String
    Public Property diasValidez As Integer
    Public Property tipoDoc As String


    Sub New(documento As String, fecha As Date, estatus As String, estatusBloqueoAlm As String, diasValidez As Integer, tipo As String)
        Me.documentoNro = documento
        Me.fechaEmision = fecha
        Me.estatus = estatus
        Me.estatusBloqueoDeposito = estatusBloqueoAlm
        Me.diasValidez = diasValidez
        Me.tipoDoc = tipo
    End Sub
End Class

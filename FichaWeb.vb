Imports System.Windows.Forms

Public Class FichaWeb
    Dim xpaginainicio As String

    Property _PaginaInicio() As String
        Get
            Return xpaginainicio
        End Get
        Set(ByVal value As String)
            xpaginainicio = value
        End Set
    End Property

    Private Sub FichaWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WebBrowser1.Navigate(_PaginaInicio)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje de Alerta ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
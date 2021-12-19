Imports System.Windows.Forms

Public Class ClaveSeguridad
    Dim xclave As String
    Dim xestatus As String

    Property _EstatusSalida() As Boolean
        Get
            Return xestatus
        End Get
        Set(ByVal value As Boolean)
            xestatus = value
        End Set
    End Property

    Property _ClaveRetornar() As String
        Get
            Return xclave
        End Get
        Set(ByVal value As String)
            xclave = value
        End Set
    End Property

    Private Sub ClaveSeguridad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            _EstatusSalida = False
            Me.Close()
        End If
    End Sub

    Private Sub ClaveSeguridad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _ClaveRetornar = ""
        _EstatusSalida = False
    End Sub

    Private Sub MisTextos1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MisTextos1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me._ClaveRetornar = Me.MisTextos1.r_Valor
            _EstatusSalida = True
            Me.Close()
        End If
    End Sub

   
End Class
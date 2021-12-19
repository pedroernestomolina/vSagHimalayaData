Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DataSistema.MiDataSistema.DataSistema

Public Class AgendaTelefonica
    Dim xitems As Integer
    Dim xbusqueda As String() = {"Por Nombre", "Por CI/RIF", "Por Codigo"}
    Dim xtb As DataTable
    Dim xbs As BindingSource
    Dim xficha As DataSistema.MiDataSistema.DataSistema

    Property _Items() As Integer
        Get
            Return xitems
        End Get
        Set(ByVal value As Integer)
            xitems = value
        End Set
    End Property

    Private Sub AgendaTelefonica_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 AndAlso (e.Alt = False AndAlso e.Control = False) Then
            IrInicio()
        End If
    End Sub

    Private Sub AgendaTelefonica_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AgendaTelefonica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub AgendaTelefonica_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Inicializa()
    End Sub

    Sub IrInicio()
        With Me.MT_BUSCAR
            .Text = ""
            .Select()
            .Focus()
        End With
    End Sub

    Sub Inicializa()
        Try
            Me.E_ITEM.Text = String.Format("{0:#0}", _Items)
            Me.TreeView1.Nodes(0).ExpandAll()

            With Me.MCB_BUSQUEDA
                .DataSource = xbusqueda
                .SelectedIndex = 0
            End With

            CargarData()
            AddHandler xbs.PositionChanged, AddressOf ActualizarRegistro
            ActualizaRegistro()

            With MisGrid1
                .Columns.Add("col0", "Nombre")
                .Columns.Add("col1", "CI / RIF")

                .Columns(1).Width = 120
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                .DataSource = xbs
                .Columns(0).DataPropertyName = "nombre"
                .Columns(1).DataPropertyName = "ci_rif"
                .Ocultar(2)
            End With
            IrInicio()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Sub New(ByVal xcadena As String)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        xtb = New DataTable
        xbs = New BindingSource(xtb, "")
        xficha = New DataSistema.MiDataSistema.DataSistema(xcadena)
    End Sub

    Sub CargarData()
        Dim xsql As String = "select nombre,ci_rif,dir_fiscal,codigo,telefono_1,telefono_2,telefono_3,telefono_4,celular_1,celular_2,fax_1,fax_2,email,website,auto,'01' as tipo, telefono from clientes " & _
          "UNION select nombre,ci_rif,dir_fiscal,codigo,telefono_1,telefono_2,telefono_3,telefono_4,celular_1,celular_2,fax_1,fax_2,email,website,auto,'02' as tipo, telefono from PROVEEDORES " & _
          "UNION select nombre,CI ci_rif,direccion dir_fiscal,codigo,TELEFONO1 telefono_1,TELEFONO2 telefono_2,'' telefono_3,'' telefono_4, CELULAR1 celular_1, CELULAR2 celular_2,FAX1 fax_1,FAX2 fax_2,email,website,auto,'03' as tipo, telefono from VENDEDORES " & _
          "UNION select nombre,CI ci_rif,direccion dir_fiscal,codigo,TELEFONO1 telefono_1,TELEFONO2 telefono_2,'' telefono_3,'' telefono_4, CELULAR1 celular_1, CELULAR2 celular_2,FAX1 fax_1,FAX2 fax_2,email,'' website,auto,'04' as tipo, '' as telefono from COBRADORES " & _
          "order by nombre "
        xficha.F_GetData(xsql, xtb)
        ActualizarData()
    End Sub

    Sub ActualizarData()
        _Items = xbs.Count
        Me.E_ITEM.Text = String.Format("{0:#0}", _Items)
    End Sub

    Sub ActualizarRegistro()
        ActualizaRegistro()
    End Sub

    Sub ActualizaRegistro()
        Dim xr As New Registro
        If xbs.Current IsNot Nothing Then
            Dim xd As DataRow = CType(xbs.Current, DataRowView).Row
            xr.CargarRegistro(xd)
        End If
        Me.E_CEL_1.Text = xr._Celular1
        Me.E_CEL_2.Text = xr._Celular2
        Me.E_FAX_1.Text = xr._Fax1
        Me.E_FAX_2.Text = xr._Fax2
        Me.E_TEL_1.Text = xr._Telefono1
        Me.E_TEL_2.Text = xr._Telefono2
        Me.E_TEL_3.Text = xr._Telefono3
        Me.E_TEL_4.Text = xr._Telefono4
        Me.E_NOMBRE.Text = xr._Nombre
        Me.E_RIF.Text = xr._Rif
        Me.E_WEBSITE.Text = xr._WebSite
        Me.E_EMAIL.Text = xr._Email
        Me.E_DIRECCION.Text = xr._Direccion
        Me.E_CODIGO.Text = xr._Codigo
        Me.E_TELEFONO.Text = xr._Telefono
    End Sub

    Sub Busqueda()
        Try
            If MT_BUSCAR.r_Valor <> "" Then
                Dim xp1 As SqlParameter = Nothing
                Dim xsql As String = ""
                Dim xbuscar As String = ""
                Dim TipoB As String = ""

                Select Case Me.MCB_BUSQUEDA.SelectedIndex
                    Case 0
                        TipoB = "NOMBRE"
                    Case 1
                        TipoB = "CI_RIF"
                    Case 2
                        TipoB = "CODIGO"
                End Select

                Dim TipoBusq As String = _
             "select nombre,ci_rif,dir_fiscal,codigo,telefono_1,telefono_2,telefono_3,telefono_4,celular_1,celular_2,fax_1,fax_2,email,website,auto,'01' as tipo, telefono from clientes WHERE " + TipoB + " like @data1 " & _
              "UNION select nombre,ci_rif,dir_fiscal,codigo,telefono_1,telefono_2,telefono_3,telefono_4,celular_1,celular_2,fax_1,fax_2,email,website,auto,'02' as tipo, telefono from PROVEEDORES WHERE " + TipoB + " like @data1 " & _
              "UNION select nombre,CI ci_rif,direccion dir_fiscal,codigo,TELEFONO1 telefono_1,TELEFONO2 telefono_2,'' telefono_3,'' telefono_4, CELULAR1 celular_1, CELULAR2 celular_2,FAX1 fax_1,FAX2 fax_2,email,website,auto,'03' as tipo, telefono from VENDEDORES WHERE " + TipoB + " like @data1 " & _
              "UNION select nombre,CI ci_rif,direccion dir_fiscal,codigo,TELEFONO1 telefono_1,TELEFONO2 telefono_2,'' telefono_3,'' telefono_4, CELULAR1 celular_1, CELULAR2 celular_2,FAX1 fax_1,FAX2 fax_2,email,'' website,auto,'04' as tipo, '' as telefono from COBRADORES WHERE " + TipoB + " like @data1 " & _
              "order by nombre "
                xsql = TipoBusq

                If MT_BUSCAR.Text.Substring(0, 1) = "*" Then
                    xbuscar = "%" + MT_BUSCAR.r_Valor.Substring(1)
                Else
                    xbuscar = MT_BUSCAR.r_Valor
                End If
                xp1 = New SqlParameter("@data1", xbuscar + "%")
                xbs.Filter = ""
                xficha.F_GetData(xsql, xtb, xp1)
                ActualizarData()

                MisGrid1.Select()
                MisGrid1.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "*** Mensaje De Error ***", MessageBoxButtons.OK, MessageBoxIcon.Error)
            IrInicio()
        End Try
    End Sub

    Class Registro
        Private x_nombre As CampoTexto
        Private x_ci_rif As CampoTexto
        Private x_dir_fiscal As CampoTexto
        Private x_codigo As CampoTexto
        Private x_telefono_1 As CampoTexto
        Private x_telefono_2 As CampoTexto
        Private x_telefono_3 As CampoTexto
        Private x_telefono_4 As CampoTexto
        Private x_celular_1 As CampoTexto
        Private x_celular_2 As CampoTexto
        Private x_fax_1 As CampoTexto
        Private x_fax_2 As CampoTexto
        Private x_email As CampoTexto
        Private x_website As CampoTexto
        Private x_auto As CampoTexto
        Private x_tipo As CampoTexto
        Private x_telefono As CampoTexto

        Property c_Nombre() As CampoTexto
            Get
                Return x_nombre
            End Get
            Set(ByVal value As CampoTexto)
                x_nombre = value
            End Set
        End Property

        Property c_Rif() As CampoTexto
            Get
                Return x_ci_rif
            End Get
            Set(ByVal value As CampoTexto)
                x_ci_rif = value
            End Set
        End Property

        Property c_Direccion() As CampoTexto
            Get
                Return x_dir_fiscal
            End Get
            Set(ByVal value As CampoTexto)
                x_dir_fiscal = value
            End Set
        End Property

        Property c_Codigo() As CampoTexto
            Get
                Return x_codigo
            End Get
            Set(ByVal value As CampoTexto)
                x_codigo = value
            End Set
        End Property

        Property c_Telefono1() As CampoTexto
            Get
                Return x_telefono_1
            End Get
            Set(ByVal value As CampoTexto)
                x_telefono_1 = value
            End Set
        End Property

        Property c_Telefono2() As CampoTexto
            Get
                Return x_telefono_2
            End Get
            Set(ByVal value As CampoTexto)
                x_telefono_2 = value
            End Set
        End Property

        Property c_Telefono3() As CampoTexto
            Get
                Return x_telefono_3
            End Get
            Set(ByVal value As CampoTexto)
                x_telefono_3 = value
            End Set
        End Property

        Property c_Telefono4() As CampoTexto
            Get
                Return x_telefono_4
            End Get
            Set(ByVal value As CampoTexto)
                x_telefono_4 = value
            End Set
        End Property

        Property c_Fax1() As CampoTexto
            Get
                Return x_fax_1
            End Get
            Set(ByVal value As CampoTexto)
                x_fax_1 = value
            End Set
        End Property

        Property c_Fax2() As CampoTexto
            Get
                Return x_fax_2
            End Get
            Set(ByVal value As CampoTexto)
                x_fax_2 = value
            End Set
        End Property

        Property c_Celular1() As CampoTexto
            Get
                Return x_celular_1
            End Get
            Set(ByVal value As CampoTexto)
                x_celular_1 = value
            End Set
        End Property

        Property c_Celular2() As CampoTexto
            Get
                Return x_celular_2
            End Get
            Set(ByVal value As CampoTexto)
                x_celular_2 = value
            End Set
        End Property

        Property c_Email() As CampoTexto
            Get
                Return x_email
            End Get
            Set(ByVal value As CampoTexto)
                x_email = value
            End Set
        End Property

        Property c_WebSite() As CampoTexto
            Get
                Return x_website
            End Get
            Set(ByVal value As CampoTexto)
                x_website = value
            End Set
        End Property

        Property c_Automatico() As CampoTexto
            Get
                Return x_auto
            End Get
            Set(ByVal value As CampoTexto)
                x_auto = value
            End Set
        End Property

        Property c_Tipo() As CampoTexto
            Get
                Return x_tipo
            End Get
            Set(ByVal value As CampoTexto)
                x_tipo = value
            End Set
        End Property

        Property c_Telefono() As CampoTexto
            Get
                Return x_telefono
            End Get
            Set(ByVal value As CampoTexto)
                x_telefono = value
            End Set
        End Property


        ReadOnly Property _Nombre() As String
            Get
                Return x_nombre.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Rif() As String
            Get
                Return x_ci_rif.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Direccion() As String
            Get
                Return x_dir_fiscal.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Codigo() As String
            Get
                Return x_codigo.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Telefono1() As String
            Get
                Return x_telefono_1.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Telefono2() As String
            Get
                Return x_telefono_2.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Telefono3() As String
            Get
                Return x_telefono_3.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Telefono4() As String
            Get
                Return x_telefono_4.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Fax1() As String
            Get
                Return x_fax_1.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Fax2() As String
            Get
                Return x_fax_2.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Celular1() As String
            Get
                Return x_celular_1.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Celular2() As String
            Get
                Return x_celular_2.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Email() As String
            Get
                Return x_email.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _WebSite() As String
            Get
                Return x_website.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Automatico() As String
            Get
                Return x_auto.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Tipo() As String
            Get
                Return x_tipo.c_Texto.Trim
            End Get
        End Property

        ReadOnly Property _Telefono() As String
            Get
                Return x_telefono.c_Texto.Trim
            End Get
        End Property

        Sub LimpiarRegistro()
            LimpiarVariableTipo(Me)
        End Sub

        Sub New()
            Me.c_Automatico = New CampoTexto(10, "auto")
            Me.c_Celular1 = New CampoTexto(14, "celular_1")
            Me.c_Celular2 = New CampoTexto(14, "celular_2")
            Me.c_Codigo = New CampoTexto(15, "codigo")
            Me.c_Direccion = New CampoTexto(120, "dir_fiscal")
            Me.c_Email = New CampoTexto(50, "email")
            Me.c_Fax1 = New CampoTexto(14, "fax_1")
            Me.c_Fax2 = New CampoTexto(14, "fax_2")
            Me.c_Nombre = New CampoTexto(120, "nombre")
            Me.c_Rif = New CampoTexto(14, "ci_rif")
            Me.c_Telefono1 = New CampoTexto(14, "telefono_1")
            Me.c_Telefono2 = New CampoTexto(14, "telefono_2")
            Me.c_Telefono3 = New CampoTexto(14, "telefono_3")
            Me.c_Telefono4 = New CampoTexto(14, "telefono_4")
            Me.c_Tipo = New CampoTexto(2, "tipo")
            Me.c_WebSite = New CampoTexto(50, "website")
            Me.c_Telefono = New CampoTexto(60, "telefono")

            LimpiarRegistro()
        End Sub

        Sub CargarRegistro(ByVal xreg As DataRow)
            Try
                LimpiarRegistro()

                With Me
                    If Not IsDBNull(xreg(.c_Automatico.c_NombreInterno)) Then
                        .c_Automatico.c_Texto = xreg(.c_Automatico.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Celular1.c_NombreInterno)) Then
                        .c_Celular1.c_Texto = xreg(.c_Celular1.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Celular2.c_NombreInterno)) Then
                        .c_Celular2.c_Texto = xreg(.c_Celular2.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Codigo.c_NombreInterno)) Then
                        .c_Codigo.c_Texto = xreg(.c_Codigo.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Direccion.c_NombreInterno)) Then
                        .c_Direccion.c_Texto = xreg(.c_Direccion.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Email.c_NombreInterno)) Then
                        .c_Email.c_Texto = xreg(.c_Email.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Fax1.c_NombreInterno)) Then
                        .c_Fax1.c_Texto = xreg(.c_Fax1.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Fax2.c_NombreInterno)) Then
                        .c_Fax2.c_Texto = xreg(.c_Fax2.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Nombre.c_NombreInterno)) Then
                        .c_Nombre.c_Texto = xreg(.c_Nombre.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Rif.c_NombreInterno)) Then
                        .c_Rif.c_Texto = xreg(.c_Rif.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Telefono1.c_NombreInterno)) Then
                        .c_Telefono1.c_Texto = xreg(.c_Telefono1.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Telefono2.c_NombreInterno)) Then
                        .c_Telefono2.c_Texto = xreg(.c_Telefono2.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Telefono3.c_NombreInterno)) Then
                        .c_Telefono3.c_Texto = xreg(.c_Telefono3.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Telefono4.c_NombreInterno)) Then
                        .c_Telefono4.c_Texto = xreg(.c_Telefono4.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Tipo.c_NombreInterno)) Then
                        .c_Tipo.c_Texto = xreg(.c_Tipo.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_WebSite.c_NombreInterno)) Then
                        .c_WebSite.c_Texto = xreg(.c_WebSite.c_NombreInterno)
                    End If
                    If Not IsDBNull(xreg(.c_Telefono.c_NombreInterno)) Then
                        .c_Telefono.c_Texto = xreg(.c_Telefono.c_NombreInterno)
                    End If
                End With
            Catch ex As Exception
                Throw New Exception("AGENDA TELEFONICA" + vbCrLf + "CARGAR DATA" + vbCrLf + ex.Message)
            End Try
        End Sub
    End Class

    Private Sub BUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSCAR.Click
        Busqueda()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Node.Level > 0 Then
            xbs.Filter = "nombre like ('" + e.Node.Name + "%')"
            _Items = xbs.Count
            Me.E_ITEM.Text = String.Format("{0:#0}", _Items)
        End If
    End Sub

    Private Sub LK_WEB_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LK_WEB.LinkClicked
        If E_WEBSITE.Text.Trim <> "" Then
            Dim xficha As New FichaWeb
            With xficha
                ._PaginaInicio = Me.E_WEBSITE.Text
                .ShowDialog()
            End With
        End If
    End Sub
End Class
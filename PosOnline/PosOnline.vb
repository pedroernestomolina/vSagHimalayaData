Imports System.Text

Namespace MiDataSistema
    Partial Public Class DataSistema
        Public Class PosOnline
            Event _RegistroVentaOk()
            Event _ErrorRegistro()
            Event _FichaUltimoItemRegistrado(ByVal xautoitem As String)
            Event _CtaPendienteOK()
            Event _AbrirCtaPendienteOK(ByVal xpendiente As String, ByVal xautocliente As String)
            Event _DevolucionOK()
            Event _AnulacionOK()
            Event _TarjetaPendiente(ByVal xtexto As StringBuilder)
            Event _VisorLimpiar()
            Event _VisorSubTotalPendiente()
            Event _VisorActualizarCantidadVenta(ByVal xproducto As String, ByVal xcantidad As Decimal, ByVal xprecio As Decimal)
            Event _VisorDevolucion(ByVal xproducto As String, ByVal xcantidad As Decimal, ByVal xprecio As Decimal)
            Event _VisorDevolucionCantidad(ByVal xproducto As String, ByVal xcantidad As Decimal, ByVal xprecio As Decimal)
            Event _VendedorActualizado()
            Event _NotasItemActualizadaOk()

            Event _TicketBalanzaAnuladoOk()
            Event _TicketBalanzaOk()

            Private xposventa As PosVenta
            Private xposventa_pendencabezado As PendienteEncabezado
            Private xposventa_penddetalle As PendienteDetalle
            Private xposventa_devanulacion As DevolucionAnulacion
            Private xposventa_balanzaencabezado As BalanzaEncabezado


            Property F_PosVenta() As PosVenta
                Get
                    Return Me.xposventa
                End Get
                Set(ByVal value As PosVenta)
                    Me.xposventa = value
                End Set
            End Property

            Property F_PendEncabezado() As PendienteEncabezado
                Get
                    Return Me.xposventa_pendencabezado
                End Get
                Set(ByVal value As PendienteEncabezado)
                    Me.xposventa_pendencabezado = value
                End Set
            End Property

            Property F_PendDetalle() As PendienteDetalle
                Get
                    Return Me.xposventa_penddetalle
                End Get
                Set(ByVal value As PendienteDetalle)
                    Me.xposventa_penddetalle = value
                End Set
            End Property

            Property F_DevAnulacion() As DevolucionAnulacion
                Get
                    Return Me.xposventa_devanulacion
                End Get
                Set(ByVal value As DevolucionAnulacion)
                    Me.xposventa_devanulacion = value
                End Set
            End Property

            Property F_BalanzaEncabezado() As BalanzaEncabezado
                Get
                    Return Me.xposventa_balanzaencabezado
                End Get
                Set(ByVal value As BalanzaEncabezado)
                    Me.xposventa_balanzaencabezado = value
                End Set
            End Property


            Sub New()
                F_PosVenta = New PosVenta
                F_PendEncabezado = New PendienteEncabezado
                F_PendDetalle = New PendienteDetalle
                F_DevAnulacion = New DevolucionAnulacion
                F_BalanzaEncabezado = New BalanzaEncabezado
            End Sub
        End Class


        Private xfichaposonline As PosOnline


        Property f_FichaPosOnlie() As PosOnline
            Get
                Return Me.xfichaposonline
            End Get
            Set(ByVal value As PosOnline)
                Me.xfichaposonline = value
            End Set
        End Property

    End Class
End Namespace


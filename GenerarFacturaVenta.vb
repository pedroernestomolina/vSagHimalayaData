Public Class GenerarFacturaVenta
    Public Property serieAuto As String
    Public Property diasCredito As Integer
    Public Property cliAuto As String
    Public Property cliCodigo As String
    Public Property cliNombre As String
    Public Property cliDirFiscal As String
    Public Property cliCiRif As String
    Public Property montoExento As Decimal
    Public Property montoBase As Decimal
    Public Property montoImpuesto As Decimal
    Public Property montoTotal As Decimal
    Public Property montoBase1 As Decimal
    Public Property montoBase2 As Decimal
    Public Property montoBase3 As Decimal
    Public Property montoImpuesto1 As Decimal
    Public Property montoImpuesto2 As Decimal
    Public Property montoImpuesto3 As Decimal
    Public Property tasa1 As Decimal
    Public Property tasa2 As Decimal
    Public Property tasa3 As Decimal
    Public Property Notas As String
    Public Property montoDescuento As Decimal
    Public Property montoCargo As Decimal
    Public Property porcDescuento As Decimal
    Public Property porcCargo As Decimal
    Public Property control As String
    Public Property ordeCompra As String
    Public Property subTotal As Decimal
    Public Property cliTelefono As String
    Public Property factorCambio As Decimal
    Public Property vendAuto As String
    Public Property vendCodigo As String
    Public Property vendNombre As String
    Public Property fechaPedido As Date
    Public Property numPedido As String
    Public Property condPago As String
    Public Property usuAuto As String
    Public Property usuCodigo As String
    Public Property usuNombre As String
    Public Property montoDivisa As Decimal
    Public Property cliDirDespacho As String
    Public Property estacionEquipo As String
    Public Property renglones As Integer
    Public Property saldoPend As Decimal
    Public Property serieNombre As String
    Public Property serieSerial As String
    Public Property zFiscal As Integer
    Public Property bloquearAlmacen As String
    Public Property condPagoIsContado As Boolean
    Property depAuto As String
    Property depCodigo As String
    Property depNombre As String
    Property conceptoAuto As String
    Property conceptoCodigo As String
    Property conceptoNombre As String
    Property cobradorAuto As String
    Property cobradorCodigo As String
    Property cobradorNombre As String


    Sub New()
        serieAuto = ""
        diasCredito = 0
        cliCodigo = ""
        cliNombre = ""
        cliCiRif = ""
        cliDirFiscal = ""
        cliAuto = ""
        montoExento = 0D
        montoBase = 0D
        montoImpuesto = 0D
        montoTotal = 0D
        montoBase1 = 0D
        montoBase2 = 0D
        montoBase3 = 0D
        montoImpuesto1 = 0D
        montoImpuesto2 = 0D
        montoImpuesto3 = 0D
        tasa1 = 0D
        tasa2 = 0D
        tasa3 = 0D
        Notas = ""
        montoDescuento = 0D
        montoCargo = 0D
        porcCargo = 0D
        porcDescuento = 0D
        control = ""
        ordeCompra = ""
        subTotal = 0D
        cliTelefono = ""
        factorCambio = 0D
        vendAuto = ""
        vendCodigo = ""
        vendNombre = ""
        fechaPedido = Now.Date
        numPedido = ""
        condPago = ""
        usuAuto = ""
        usuCodigo = ""
        usuNombre = ""
        montoDivisa = 0D
        cliDirDespacho = ""
        estacionEquipo = ""
        renglones = 0
        saldoPend = 0D
        serieNombre = ""
        serieSerial = ""
        zFiscal = 0
        bloquearAlmacen = ""
        condPagoIsContado = False
        depAuto = ""
        depCodigo = ""
        depNombre = ""
        conceptoAuto = ""
        conceptoCodigo = ""
        conceptoNombre = ""
        cobradorAuto = ""
        cobradorCodigo = ""
        cobradorNombre = ""
    End Sub

End Class
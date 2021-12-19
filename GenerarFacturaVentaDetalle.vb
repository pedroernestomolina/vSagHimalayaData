
Public Class GenerarFacturaVentaDetalle
    Property prdAuto As String
    Property prdCodigo As String
    Property prdDescripcion As String
    Property prdNombre As String
    Property departAuto As String
    Property grupoAuto As String
    Property subGrupAuto As String
    Property cantidad As Decimal
    Property empaque As String
    Property descPorc_1 As Decimal
    Property descPorc_2 As Decimal
    Property descPorc_3 As Decimal
    Property descMonto_1 As Decimal
    Property descMonto_2 As Decimal
    Property descMonto_3 As Decimal
    Property totalNeto As Decimal
    Property tasaIva As Decimal
    Property impuesto As Decimal
    Property total As Decimal
    Property codigoTasaIva As String
    Property contEmpaque As Integer
    Property cantUnd As Decimal
    Property costoUnd As Decimal
    Property precioNeto As Decimal
    Property costo As Decimal
    Property precioFinal As Decimal
    Property precioInv As Decimal
    Property utilidad As Decimal
    Property utilidadPorc As Decimal
    Property precioItem As Decimal
    Property detalle As String
    Property psv As Decimal
    Property empaqueTipo As String
    Property categoria As String
    Property medidaDecimales As Integer
    Property medidaAuto As String
    Property medidaNombre As String
    Property medidaForzar As String
    Property confTipoCalcUtilidad As String
    Property provDocOrigen As Boolean


    Sub New()
        prdAuto = ""
        prdCodigo = ""
        prdDescripcion = ""
        prdNombre = ""
        departAuto = ""
        grupoAuto = ""
        subGrupAuto = ""
        cantidad = 0D
        empaque = ""
        descMonto_1 = 0D
        descMonto_2 = 0D
        descMonto_3 = 0D
        descPorc_1 = 0D
        descPorc_2 = 0D
        descPorc_3 = 0D
        totalNeto = 0D
        tasaIva = 0D
        impuesto = 0D
        total = 0D
        codigoTasaIva = ""
        contEmpaque = 0
        costoUnd = 0D
        precioNeto = 0D
        costo = 0D
        precioInv = 0D
        precioInv = 0D
        utilidad = 0D
        utilidadPorc = 0D
        precioItem = 0D
        detalle = ""
        psv = 0D
        empaqueTipo = ""
        categoria = ""
        medidaAuto = ""
        medidaNombre = ""
        medidaDecimales = 0
        medidaForzar = ""
        confTipoCalcUtilidad = ""
        provDocOrigen = True
    End Sub

End Class

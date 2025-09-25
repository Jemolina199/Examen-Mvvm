using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;

namespace Examen_Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Use [ObservableProperty] to generate backing fields and properties
    [ObservableProperty]
    private string producto1 = string.Empty;
    [ObservableProperty]
    private string producto2 = string.Empty;
    [ObservableProperty]
    private string producto3 = string.Empty;

    [ObservableProperty]
    private decimal subtotalValue;
    [ObservableProperty]
    private int descuentoAplicadoValue;
    [ObservableProperty]
    private decimal totalPagar;

    [ObservableProperty]
    private string mensajeErrorValue = string.Empty;

    [RelayCommand]
    private void Calcular()
    {
        MensajeErrorValue = string.Empty;
        if (!TryParseProducto(Producto1, out decimal p1) ||
            !TryParseProducto(Producto2, out decimal p2) ||
            !TryParseProducto(Producto3, out decimal p3))
        {
            MensajeErrorValue = "Ingrese valores numéricos válidos para los tres productos.";
            SubtotalValue = 0;
            DescuentoAplicadoValue = 0;
            TotalPagar = 0;
            return;
        }

        SubtotalValue = p1 + p2 + p3;
        DescuentoAplicadoValue = ObtenerDescuento(SubtotalValue);
        decimal descuento = SubtotalValue * DescuentoAplicadoValue / 100;
        TotalPagar = SubtotalValue - descuento;
    }

    [RelayCommand]
    private void Limpiar()
    {
        Producto1 = string.Empty;
        Producto2 = string.Empty;
        Producto3 = string.Empty;
        SubtotalValue = 0;
        DescuentoAplicadoValue = 0;
        TotalPagar = 0;
        MensajeErrorValue = string.Empty;
    }

    private static bool TryParseProducto(string? input, out decimal value)
    {
        return decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value) && value >= 0;
    }

    private static int ObtenerDescuento(decimal subtotal)
    {
        if (subtotal >= 1000 && subtotal <= 4999.99m) return 10;
        if (subtotal >= 5000 && subtotal <= 9999.99m) return 20;
        if (subtotal >= 10000 && subtotal <= 19999.99m) return 30;
        return 0;
    }
}
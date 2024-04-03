using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace QrcodeMaui;

public partial class LeitorQrCode : ContentPage
{
	public LeitorQrCode()
	{
		InitializeComponent();

        barcodeView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = false,
            Multiple = false
        };
    }

    private void BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        //foreach (var barcode in e.Results)
        //    Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");

        var resultado = e.Results?.FirstOrDefault();
        if (resultado is not null)
        {
            Dispatcher.Dispatch(() =>
            {
                DisplayAlert("Leitura", resultado.Value, "Sair");
                Navigation.PopAsync();
                //// Update BarcodeGeneratorView
                //barcodeGenerator.ClearValue(BarcodeGeneratorView.ValueProperty);
                //barcodeGenerator.Format = first.Format;
                //barcodeGenerator.Value = first.Value;

                //// Update Label
                //ResultLabel.Text = $"Codigo: {first.Format} -> {first.Value}";
            });
            
        }
    }

    private void SwitchCameraButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
    }

    private void TorchButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
    }
}
namespace QrcodeMaui;

public partial class PaginaPrincipal : ContentPage
{
	public PaginaPrincipal()
	{
		InitializeComponent();
	}

    private async void AbrirLeitor(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new LeitorQrCode());
    }
}
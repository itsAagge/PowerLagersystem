using System.Diagnostics;


namespace MauiGui;

public partial class PlacerPage : ContentPage
{
	public PlacerPage()
	{

		InitializeComponent();
        //Bare fylde tekst til item collection indtil vi binder på rigtig liste af objekter
        IndtastedeEAN.ItemsSource = new List<string>
        {
            "Test Vare : Plads 1",
            "Test Vare2 : Plads 2"
        };
        PladserTilValgteVare.ItemsSource = new List<string>
        {
            "A.1.4",
            "B.1.5",
            "C.1.5",
        };
        

    }
   

    private async void ReolClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReolPage());
    }

    private async void FindClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FindPage());
    }

    private async void FlytClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlytPage());
    }

    private async void HistorikClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorikPage());
    }
   

}



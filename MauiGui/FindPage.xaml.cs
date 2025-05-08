namespace MauiGui;
using BusinessLogic.Controllers;
using DTO.Model;

public partial class FindPage : ContentPage
{
	public FindPage()
	{
		InitializeComponent();
	}

    private async void ReolClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReolPage());
    }

    private async void PlacerClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PlacerPage());
    }

    private async void FlytClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlytPage());
    }

    private async void HistorikClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorikPage());
    }

    private void EANFelt_Completed(object sender, EventArgs e)
    {
        if (long.TryParse(EANFelt.Text, out long ean))
        {
            var varer = funktionsMetoder.FindVare(ean);

            if (varer != null && varer.Count > 0)
            {
                var pladsListe = new List<string>();

                foreach (Vare vare in varer)
                {
                    Plads plads = CRUDController.HentPlads(vare.PladsId);
                    Reol reol = CRUDController.HentReol(plads.ReolId);
                    if (plads != null)
                    {
                        pladsListe.Add($"Reol: {reol.ReolNavn}, Plads: {plads.PladsX}, {plads.PladsY}");
                    }
                }
                PladsCollectionView.ItemsSource = pladsListe;

            }


        }
    }
    }
namespace MauiGui;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.IdentityModel.Tokens;

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

    private async void EANFelt_Completed(object sender, EventArgs e)
    {
        if (long.TryParse(EANFelt.Text, out long ean))
        {
            try
            {
                TemplateVare templateVare = CRUDController.HentTemplateVare(ean);
                ModelLabel.Text = templateVare.Model;
                VaregruppeLabel.Text = templateVare.Varegruppe.ToString();
            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Fejl", ex.Message, "Tilbage");
            }

            var varer = funktionsMetoder.FindVare(ean);
            var pladsListe = new List<string>();

            if (varer != null && varer.Count > 0)
            {
                foreach (Vare vare in varer)
                {
                    Plads plads = CRUDController.HentPlads(vare.PladsId);
                    Reol reol = CRUDController.HentReol(plads.ReolId);
                    if (plads != null)
                    {
                        string temp = "Reol: " + reol.ReolNavn + ", " + plads.ToString();
                        if (!vare.Note.IsNullOrEmpty()) temp += ", Note: " + vare.Note;
                        pladsListe.Add(temp);
                    }
                }
            } else
            {
                pladsListe.Add("Ingen varer fundet på lageret");
            }
            PladsCollectionView.ItemsSource = pladsListe;
        }
    }
}
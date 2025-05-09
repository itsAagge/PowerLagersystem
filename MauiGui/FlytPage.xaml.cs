using BusinessLogic.Controllers;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.IdentityModel.Tokens;


namespace MauiGui;


public partial class FlytPage : ContentPage
{
    private long currentEAN = 0;

    public FlytPage()
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

    private async void FindClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FindPage());
    }

    private async void HistorikClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorikPage());
    }

    private void EANFelt_Completed(object sender, EventArgs e)
    {
        if (long.TryParse(EANFelt.Text, out long ean))
        {
            currentEAN = ean;

            var varer = funktionsMetoder.FindVare(ean);
            var pladsListe = new List<string>();

            if (varer != null && varer.Count > 0)
            {

                Vare firstVare = varer[0];
                Varegruppe varegruppe = firstVare.Varegruppe;
                var ledigeVare = funktionsMetoder.FindPladserTilVare(varegruppe);

                foreach (Plads plads in ledigeVare)
                {
                    Reol reol = CRUDController.HentReol(plads.ReolId);
                    if (plads != null)
                    {
                        pladsListe.Add($"Reol {reol.ReolNavn}, Plads {plads.PladsX}, {plads.PladsY}, PladsId: {plads.PladsId}");
                    }
                }

            }

            LedigPladsView.ItemsSource = pladsListe;
            VareView.ItemsSource = visVare(ean);
        }
    }


    private List<string> visVare(long ean)
    {
        var varer = funktionsMetoder.FindVare(ean);
        var vareListe = new List<string>();
        string vareString = "";

        if (varer != null && varer.Count > 0)
        {

            foreach (Vare vare in varer)
            {
                Plads plads = CRUDController.HentPlads(vare.PladsId);
                Reol reol = CRUDController.HentReol(plads.ReolId);

                if (vare != null)
                {

                    vareString = $" Reol {reol.ReolNavn} Plads {plads.PladsX}, {plads.PladsY}, Note, {vare.Note}, VareId: {vare.VareId}";

                    if (!vare.Note.IsNullOrEmpty())
                    {
                        vareString += $" Note: {vare.Note}";
                    }

                }

                vareListe.Add(vareString);
            }

        }

        return vareListe;

    }

    private async void FlytVare_Clicked(object sender, EventArgs e)
    {
        try
        {

            string nyplads = LedigPladsView.SelectedItem as string;
            string stringVare = VareView.SelectedItem as string;

            if (nyplads == null || stringVare == null)
            {
                await DisplayAlert("Fejl", "Vælg både en ledig plads og en vare først.", "OK");
                return;
            }

            int pladsId = int.Parse(nyplads.Split("PladsId:")[1].Trim());

            string vareIdPart = stringVare.Split("VareId:")[1];
            if (vareIdPart.Contains("Note:"))
                vareIdPart = vareIdPart.Split("Note:")[0];

            int vareId = int.Parse(vareIdPart.Trim());

            Vare vare = CRUDController.HentVare(vareId);
            Plads plads = CRUDController.HentPlads(pladsId);

            if (vare == null || plads == null)
            {
                await DisplayAlert("Fejl", "Kunne ikke finde varen eller pladsen.", "OK");
                return;
            }

            CRUDController.FlytVare(vare, plads);

            await DisplayAlert("Fuldført", "Varen blev flyttet til den nye plads.", "OK");
            
            if (currentEAN != 0)
            {
                VareView.ItemsSource = visVare(currentEAN);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fejl", $"Der opstod en fejl under flytning: {ex.Message}", "OK");
        }


    }

    private async void SletVare_Clicked(object sender, EventArgs e)
    {
        try
        {
            string stringVare = VareView.SelectedItem as string;

            if (stringVare == null)
            {
                await DisplayAlert("Fejl", "Vælg vare.", "OK");
                return;
            }
            string vareIdPart = stringVare.Split("VareId:")[1];
            if (vareIdPart.Contains("Note:"))
                vareIdPart = vareIdPart.Split("Note:")[0];
            int vareId = int.Parse(vareIdPart.Trim());

            Vare vare = CRUDController.HentVare(vareId);

            if (vare == null)
            {
                await DisplayAlert("Fejl", "Kunne ikke finde varen", "OK");
                return;
            }

            CRUDController.SletVare(vare);

            await DisplayAlert("Fuldført", "Varen er nu slettet.", "OK");

            if (currentEAN != 0)
            {
                VareView.ItemsSource = visVare(currentEAN);
            }

        } catch(Exception ex)
        {
            await DisplayAlert("Fejl", $"Der opstod en fejl under flytning: {ex.Message}", "OK");
        }

    }
}

using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;



namespace MauiGui;

public partial class PlacerPage : ContentPage
{
    private List<Plads> Pladser = new List<Plads>();
    private List<string> PladsStrings = new List<string>();

    public PlacerPage()
	{

		InitializeComponent();

        List<Reol> reoler = CRUDController.HentAlleReoler();
        foreach (Reol reol in reoler)
        {
            var result = funktionsMetoder.HeltAllePladserPaaReol(reol.ReolId);
            
            LavPladsString(result);
        }

        PladserTilValgteVare.ItemsSource = PladsStrings;

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
    private void EAN_Felt_Udfyldt(object sender, EventArgs e)
    {
        string enteredText = EANFelt.Text;

        if (long.TryParse(enteredText, out long result))
        {
            PlacerVarerne.Text = "Success 1";
            var vare = funktionsMetoder.FindVare(result);
            Debug.WriteLine(result);

            if (vare != null && vare.Any())
            {
                HandleEAN(vare.FirstOrDefault());

            }
        }
    }
    private void HandleEAN(Vare vare)
    {
        List<Plads> result = funktionsMetoder.FindPladserTilVare(vare.Varegruppe);
        PlacerVarerne.Text = "Success 2";
        PladsStrings.Clear();

        LavPladsString(result);

        PladserTilValgteVare.ItemsSource = PladsStrings;
    }
    private void LavPladsString(List<Plads> pladser)
    {
        foreach (var plads in pladser)
        {
            string temp = CRUDController.HentReol(plads.ReolId).ReolNavn + "." + plads.PladsX + "." + plads.PladsY;
            PladsStrings.Add(temp);
        }
    }
}



using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;
using Microsoft.IdentityModel.Tokens;



namespace MauiGui;

public partial class PlacerPage : ContentPage
{
    private List<Reol> Reoler = new List<Reol>();
    ObservableCollection<string> PladsStrings = new ObservableCollection<string>() {};
    ObservableCollection<string> ListeStrings = new ObservableCollection<string>() {};
    List<string> tempValgtePladser = new List<string>();
    List<int> sessionOprettedeVarerId = new List<int>();
    TemplateVare nuværendeVare = null;


    public PlacerPage()
	{

		InitializeComponent();

        Reoler = CRUDController.HentAlleReoler();
        IndtastedeEAN.ItemsSource = ListeStrings;
        PladserTilValgteVare.ItemsSource = PladsStrings;
        
    }


    private async void ReolClicked(object sender, EventArgs e)
    {
        SkiftSideIndenPlacer();
        await Navigation.PushAsync(new ReolPage());
    }

    private async void FindClicked(object sender, EventArgs e)
    {
        SkiftSideIndenPlacer();
        await Navigation.PushAsync(new FindPage());
    }

    private async void FlytClicked(object sender, EventArgs e)
    {
        SkiftSideIndenPlacer();
        await Navigation.PushAsync(new FlytPage());
    }

    private async void HistorikClicked(object sender, EventArgs e)
    {
        SkiftSideIndenPlacer();
        await Navigation.PushAsync(new HistorikPage());
    }
    private async void EAN_Felt_Udfyldt(object sender, EventArgs e)
    {
        string enteredText = EANFelt.Text;

        if (long.TryParse(enteredText, out long result))
        {
            try
            {
                var vare = CRUDController.HentTemplateVare(result);
                Debug.WriteLine(result);
                HandleEAN(vare);
            } catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "EAN Fejl",
                    ex.Message,
                    "Ændre EAN"
                    );
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert(
                        "EAN Fejl",
                        "Et EAN-nummer består af 13 tal",
                        "Ændre EAN"
                        );
        }
    }
    private void HandleEAN(TemplateVare vare)
    {
        List<Plads> result = funktionsMetoder.FindPladserTilVare(vare.Varegruppe);
        PladsStrings.Clear();

        foreach (var plads in result)
        {
            string reolNavn = Reoler.FirstOrDefault(r => r.ReolId == plads.ReolId).ReolNavn;
            string temp = reolNavn + "." + plads.PladsX + "." + plads.PladsY + "(" + plads.PladsId + ")";
            PladsStrings.Add(temp);  
        }
        nuværendeVare = vare;     

    }
    private void TilføjVareMetode(object sender, EventArgs e)
    {
        string ean = EANFelt.Text;
      
        string plads = PladserTilValgteVare.SelectedItem as string;

        
        if (plads != null)
        {
            ListeStrings.Add("EAN: " + ean + ", " + plads);
            EANFelt.Text = "";
            PladsStrings.Clear();
            tempValgtePladser.Add(plads);

            int pladsId = FåPladsId(plads);

            CRUDController.OpretVare(pladsId, nuværendeVare.EAN, nuværendeVare.Model, nuværendeVare.Varegruppe, "");
            sessionOprettedeVarerId.Add(CRUDController.HentSenesteVare());

        }
    }
    public int FåPladsId(string input)
    {
        int start = input.IndexOf('(');
        int end = input.IndexOf(')');

        return int.Parse(input.Substring(start + 1, end - start - 1));
    }

    private void PlacerVareMetode(object sender, EventArgs e)
     {
        sessionOprettedeVarerId.Clear();
        nuværendeVare = null;
        PladsStrings.Clear();
        ListeStrings.Clear();
        tempValgtePladser.Clear();

     }
    private void SkiftSideIndenPlacer()
    {
        if (sessionOprettedeVarerId.Any())
        {
            foreach (int vareId in sessionOprettedeVarerId)
            {
                CRUDController.SletVare(CRUDController.HentVare(vareId));
            }
        }
    }
    


}



using System.Collections.ObjectModel;
using System.Diagnostics;
using DTO.Model;
using BusinessLogic.Controllers;

namespace MauiGui;

public partial class HistorikPage : ContentPage
{
    public List<string> VarerListe { get; set; }
	public HistorikPage()
	{
		InitializeComponent();

        List<Vare> alleVarer = CRUDController.HentAlleVarer();
        Dictionary<string, int> mapVarer = new Dictionary<string, int>();

        foreach (Vare vare in alleVarer)
        {
            if (mapVarer.ContainsKey(vare.Model)) mapVarer[vare.Model]++;
            else mapVarer.Add(vare.Model, 1);
        }

        VarerListe = new List<string>();
        foreach (var (key, value) in mapVarer)
        {
            VarerListe.Add("Model: " + key + " - Antal: " + value);
        }
        BindingContext = this;
        
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

    private async void FlytClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlytPage());
    }

    private void VarerVisning_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
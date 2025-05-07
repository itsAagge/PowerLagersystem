using System.Collections.ObjectModel;
using System.Diagnostics;
using DTO.Model;

namespace MauiGui;

public partial class HistorikPage : ContentPage
{
    public List<Vare> VarerListe { get; set; }
	public HistorikPage()
	{
		InitializeComponent();

        VarerListe = BusinessLogic.Controllers.CRUDController.HentAlleVarer();

        Debug.WriteLine(VarerListe.FirstOrDefault().Model);
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
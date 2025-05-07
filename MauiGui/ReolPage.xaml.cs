using System.Collections.ObjectModel;
using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;

namespace MauiGui;

public partial class ReolPage : ContentPage
{
    public List<Reol> ReolListe { get; set; }

    public ReolPage()
	{
		InitializeComponent();

        ReolListe = CRUDController.HentAlleReoler();

        BindingContext = this;
	}


    private void ReolView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine(sender);
    }

    void GenererPladsGrid(Reol reol)
    {

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

    private async void HistorikClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorikPage());
    }

}
using System.Collections.ObjectModel;
using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.Maui.Graphics.Converters;

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
        Reol selectedReol = (Reol)e.CurrentSelection.FirstOrDefault();
        GenererPladsGrid(selectedReol);
    }

    void GenererPladsGrid(Reol reol)
    {

        PladsGrid.RowDefinitions.Clear();
        PladsGrid.ColumnDefinitions.Clear();
        PladsGrid.Children.Clear();

        for (int i = 0; i < reol.PladserHoej; i++)
        {
            PladsGrid.AddRowDefinition(new RowDefinition());
        }
        for (int i = 0; i < reol.PladserBred; i++)
        {
            PladsGrid.AddColumnDefinition(new ColumnDefinition());
        }

        List<Plads> pladserPÂReolen = funktionsMetoder.HeltAllePladserPaaReol(reol.ReolId);
        foreach (Plads p in pladserPÂReolen)
        {
            String pladsTekst = "";
            List<Vare> varePÂPlads = funktionsMetoder.HentAlleVarerPÂPlads(p.PladsId);
            foreach (Vare v in varePÂPlads)
            {
                pladsTekst += (v.Model.ToString() + "\n");
            }
            Debug.WriteLine("PLADS MED ID: " + p.PladsId + " har tekst/varer: " + pladsTekst);
            var frame = new Frame
            {
                Style = (Style)Application.Current.Resources["PladsItemStyle"],
                Margin = 20,
                WidthRequest = 150,
                HeightRequest = 100,
                Content = new Label
                {
                    Text = p.PladsX +" , "+ p.PladsY + "\n" + pladsTekst,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    TextColor = Colors.Black,
                }
            }; 
            if (reol.ReolNavn != "Butik")
            {
                PladsGrid.Add(frame, p.PladsX, p.PladsY);
            } else
            {
                PladsGrid.Add(frame, 0, 0);
            }

        };
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
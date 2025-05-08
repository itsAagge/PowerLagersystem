using System.Collections.ObjectModel;
using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;
using Microsoft.IdentityModel.Tokens;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiGui;

public partial class ReolPage : ContentPage
{
    public ObservableCollection<Reol> ReolListe { get; set; }
    public List<Plads> ValgtePladser { get; set; }

    public ReolPage()
    {
        InitializeComponent();

        ReolListe = new ObservableCollection<Reol>(CRUDController.HentAlleReoler());
        ValgtePladser = new List<Plads>();

        BindingContext = this;

    }

    private void ReolView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Reol selectedReol = (Reol)e.CurrentSelection.FirstOrDefault();
        if (selectedReol != default) GenererPladsGridButtons(selectedReol);
    }

    void GenererPladsGridButtons(Reol reol)
    {
        PladsGrid.RowDefinitions.Clear();
        PladsGrid.ColumnDefinitions.Clear();
        PladsGrid.Children.Clear();
        for (int i = reol.PladserHoej; i > 0; i--)
        {
            PladsGrid.AddRowDefinition(new RowDefinition());
        }
        for (int i = reol.PladserBred; i > 0; i--)
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
            Debug.WriteLine("PLADS MED x,y: " + p.PladsX + "," + p.PladsY + " har tekst/varer: " + pladsTekst);

            var button = new Button
            {
                Text = p.PladsX + " , " + p.PladsY + "\n" + pladsTekst,
                Padding = new Thickness(0, 0, 0, 10),
                TextColor = Colors.Black,
                BackgroundColor = Colors.LightGrey
            };
            button.BindingContext = p;
            button.Clicked += (s, e) => ToggleButton(button);
            var frame = new Frame
            {
                Style = (Style)Application.Current.Resources["PladsItemStyle"],
                Content = button
            };
            if (reol.ReolNavn != "Butik")
            {

                int y = reol.PladserHoej - p.PladsY;
                PladsGrid.Add(frame, p.PladsX, y);
            }
            else
            {
                PladsGrid.Add(frame, 0, 0);
            }

        };
    }


    void ToggleButton(Button button)
    {
        if (button.Opacity == 1)
        {
            button.Opacity = 0.5;
            ValgtePladser.Add((Plads)button.BindingContext);
        } else
        {
            button.Opacity = 1;
            ValgtePladser.Remove((Plads)button.BindingContext);
        }
    }
    private void opretReolClicked(object sender, EventArgs e)
    {
        int hoejde = int.Parse(pladserHoej.Text);
        int bredde = int.Parse(pladserBred.Text);
        string navn = reolNavn.Text;

        CRUDController.OpretNyReol(navn, bredde, hoejde);
        ReolListe.Add(CRUDController.GetNyesteReol());
    }

    private async void sletReolClicked(object sender, EventArgs e)
    {
        Reol reolAtSlette = ReolView.SelectedItem as Reol;
        try
        {
            if (reolAtSlette != null && PladsGrid.Children.IsNullOrEmpty())
            {
                CRUDController.SletReol(reolAtSlette);
                ReolListe.Remove(reolAtSlette);
            }
            else
            {
                throw new ArgumentException("Du kan ikke slette en tom reol");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Fejl",
                ex.Message,
                "Okay");
        }
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

    private async void HistorikClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HistorikPage());
    }

    private async void SletPladserClicked(object sender, EventArgs e)
    {
        foreach (Plads plads in ValgtePladser)
        {
            try
            {
                CRUDController.SletPlads(plads);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                "Fejl",
                "Plads: " + plads.PladsX + ", " + plads.PladsY + " ikke fjernet. " + ex.Message,
                "Okay");
            }
        }
        ValgtePladser.Clear();
        await Navigation.PushAsync(new ReolPage());
    }

    private async void OpretPladsClicked(object sender, EventArgs e)
    {
        int nyPladsX = 0;
        int nyPladsY = 0;

        try
        {
            nyPladsX = int.Parse(NyPladsX.Text);
            nyPladsY = int.Parse(NyPladsY.Text);

            try
            {
                int reolId = ((Reol)ReolView.SelectedItem).ReolId;
                CRUDController.OpretPlads(reolId, nyPladsX, nyPladsY);
                await Navigation.PushAsync(new ReolPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Fejl",
                    ex.Message,
                    "Okay");
            }
        } 
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Fejl",
                "Venligst indtast X og Y vÊrdien for den nye plads",
                "Okay");
        }
    }
}
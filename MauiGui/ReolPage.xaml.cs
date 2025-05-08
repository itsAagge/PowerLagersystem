using System.Collections.ObjectModel;
using System.Diagnostics;
using BusinessLogic.Controllers;
using DTO.Model;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiGui;

public partial class ReolPage : ContentPage
{
    public ObservableCollection<Reol> ReolListe { get; set; }
    
    
    public ReolPage()
    {
        InitializeComponent();

        ReolListe = new ObservableCollection<Reol>(CRUDController.HentAlleReoler());
        
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
        button.Opacity = (button.Opacity == 0.5) ? 1 : 0.5;
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
            if (reolAtSlette != null)
            {
                CRUDController.SletReol(reolAtSlette);
                ReolListe.Remove(reolAtSlette);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Fejl",
                ex.Message,
                "Spurgt");
        }
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
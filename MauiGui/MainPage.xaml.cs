﻿namespace MauiGui
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
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

        private async void FlytClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlytPage());
        }

        private async void HistorikClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorikPage());
        }

    }

}

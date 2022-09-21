using AppPingMobile.Modelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetSetor : ContentPage
    {
        public SetSetor()
        {
            InitializeComponent();
            if (Empresas.Empresa.ToString() == "01")
            {
                BtnEstamparia.Source = "estampariaDiadema";
                BtnSolda.Source = "soldaDiadema";
                BtnUsinagem.Source = "usinagemDiadema";
            }
            else if (Empresas.Empresa.ToString() == "12")
            {
                BtnEstamparia.Source = "estampariaIgarassu";
                BtnSolda.Source = "soldaIgarassu";
                BtnUsinagem.Source = "usinagemIgarassu";
            }
            lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString();
        }
        private async void BtnEstamparia_Clicked(object sender, EventArgs e)
        {
            Empresas.Setor = "ESTAMPARIA";
            await Navigation.PushAsync(new SetCentros());
        }
        private async void BtnSolda_Clicked(object sender, EventArgs e)
        {
            Empresas.Setor = "SOLDA";
            await Navigation.PushAsync(new SetCentros());
        }
        private async void BtnUsinagem_Clicked(object sender, EventArgs e)
        {
            Empresas.Setor = "USINAGEM";
            await Navigation.PushAsync(new SetCentros());
        }
    }
}
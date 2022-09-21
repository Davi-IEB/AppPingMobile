using AppPingMobile.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetEmpresas : ContentPage
    {
        public SetEmpresas()
        {
            InitializeComponent();
            lblCaminho.Text = "Caminho://ITAESBRA/";
        }

        private async void BtnDiadema_Clicked(object sender, EventArgs e)
        {
            Empresas.Empresa = "01";
            await Navigation.PushAsync(new SetSetor());
        }

        private async void BtnIgarassu_Clicked(object sender, EventArgs e)
        {
            Empresas.Empresa = "12";
            await Navigation.PushAsync(new SetSetor());
        }

        private async void BtnSair_Clicked(object sender, EventArgs e)
        {
            var resultado = await DisplayAlert("Ping", "Deseja mesmo sair?", "Sim", "Não");
            if (resultado)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
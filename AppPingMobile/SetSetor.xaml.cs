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
        }
        private void BtnEstamparia_Clicked(object sender, EventArgs e)
        {

        }
        private void BtnSolda_Clicked(object sender, EventArgs e)
        {

        }
        private void BtnUsinagem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
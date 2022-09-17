using AppPingMobile.Modelo;
using AppPingMobile.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetCentros : ContentPage
    {
        ServicoDeDados dataService;
        List<Centros> items;
        public SetCentros()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            items = await dataService.GetCentrosAsync();            
            var queryItems = from i in items where i.Cod_empresa == Empresas.Empresa.ToString() && i.Setor == Empresas.Setor.ToString() select i;            
            lvCentros.ItemsSource = queryItems;
        }
    }

    //lvCentros.ItemsSource = items;
    //lvCentros.ItemsSource = items.Where(x => x.Cod_empresa.ToLower().Contains(Parametros.Empresa.ToLower()) && x.Setor.ToLower().Contains(Parametros.Setor.ToString()));
    //Caminho.Text = "Empresa://" + queryItems.First().Cod_empresa.ToString() + " - " + queryItems.First().Den_reduz.ToString() + "/" + queryItems.First().Setor.ToString();
}
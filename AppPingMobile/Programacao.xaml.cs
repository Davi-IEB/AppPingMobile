using AppPingMobile.Modelo;
using AppPingMobile.Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Programacao : ContentPage
    {
        ServicoDeDados dataService;
        List<Programa> programas;
        ViewCell cell;
        public Programacao()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            programas = await dataService.GetProgramaAsync(); 
            foreach(var s in programas)
            {
                s.Img = Convert.ToString("img" + s.Cod_item.ToString());
            }
            var query = from i in programas where i.Cod_empresa == Empresas.Empresa.ToString() && i.Cod_equip == Empresas.Maquina.ToString() select i; 
            LvPrograma.ItemsSource = query.OrderBy(x => x.Sequencia.ToString());            
            lblCaminho.Text = "Caminho://ITAESBRA/" + Empresas.Empresa.ToString() + "/" + Empresas.Setor.ToString() + "/" + Empresas.Centro.ToString() + "/" + Empresas.Maquina.ToString();
            lblMaquina.Text = Empresas.Maquina.ToString();
            
        }
        private void Linha_Tapped(object sender, System.EventArgs e)
        {
            if (cell != null)
                cell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.FromRgb(225, 225, 225);

                cell = viewCell;
            }
        }
        private async void BtnDocumento_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Documentacao());
        }
        private async void BtnDetalhe_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Detalhes());
        }
        //foreach(Programa programa in programas)
        //{
        //    string[] parts = { "https://", "github.com/Davi-IEB/AppPingMobile/blob/master/AppDocumentos" , programa.Cod_empresa.ToString(), "ESTAMPARIA/PROCESSO", programa.Cod_item.ToString(), programa.Cod_item.ToString() + ".png" };
        //    string caminho = System.IO.Path.Combine(parts);
        //    if (!Directory.Exists(caminho))
        //    {
        //        programa.Url = "semFoto.png";                    
        //    }
        //    else
        //    {
        //        programa.Url = caminho;
        //    }
        //}
    }
}
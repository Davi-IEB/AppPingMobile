﻿using AppPingMobile.Modelo;
using AppPingMobile.Servico;
using System.Collections.Generic;
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
        public Programacao()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();
            



            //lbl.Text = Empresas.Maquina.ToString();


        }
        private async void AtualizaDados()
        {
            programas = await dataService.GetProgramaAsync();
            var query = from i in programas where i.Cod_empresa == Empresas.Empresa.ToString() select i;
        }

    }
}
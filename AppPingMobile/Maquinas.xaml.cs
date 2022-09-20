﻿using AppPingMobile.Modelo;
using AppPingMobile.Servico;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using ListView = Xamarin.Forms.ListView;
using System;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maquinas : ContentPage
    {
        ServicoDeDados dataService;
        List<Maquina> maquinas;
        ViewCell cell;

        public Maquinas()
        {
            InitializeComponent();
            dataService = new ServicoDeDados();
            AtualizaDados();
        }
        private async void AtualizaDados()
        {
            HorasDisponiveis();
            maquinas = await dataService.GetMaquinasAsync();
            foreach (var i in maquinas)
            {
                i.Horas_disponiveis = Disponibilidade.HDisponivel;
                i.Percentual = i.Horas_necessarias / Disponibilidade.HDisponivel;
            }
            var query = from i in maquinas where i.Cod_empresa==Empresas.Empresa.ToString() && i.Cod_cent_trab==Empresas.Centro.ToString() select i;
            lvMaquinas.ItemsSource = query;
        }

        private void lvMaquinas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvMaquinas.SelectedItem == null)
                return;
            if (sender is ListView list) list.BackgroundColor = Color.Transparent;
            var maq = e.Item as Maquina;
            Empresas.Maquina = maq.Cod_equip;
            
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

        private async void BtnProgramacao_Clicked(object sender, System.EventArgs e)
        {
            if (Empresas.Maquina == null)
                return;
            await Navigation.PushAsync(new Programacao());
        }
        private void HorasDisponiveis()
        {
            DateTime DataHoraInicial;
            DateTime DataHoraFinal;
            DateTime DataHoraFinalSabado;
            TimeSpan DiferencaTempo;
            int DiaDaSemana;
            const double HorasTrabalhadasNaSemana = 15.41;
            const double HorasTrabalhadasNoSabado = 7.5;
            double SaldoDoDia = 0;
            double saldoSemanal = 0;

            DataHoraInicial = DateTime.Now;
            DataHoraFinal = new DateTime(DataHoraInicial.Year, DataHoraInicial.Month, DataHoraInicial.Day, 23, 0, 0);
            DataHoraFinalSabado = new DateTime(DataHoraInicial.Year, DataHoraInicial.Month, DataHoraInicial.Day, 13, 55, 0);
            DiaDaSemana = (int)DataHoraInicial.DayOfWeek;

            if (DiaDaSemana >= 0 && DiaDaSemana < 6)
            {
                if (DataHoraFinal >= DataHoraInicial)
                {
                    DiferencaTempo = DataHoraFinal - DataHoraInicial;
                }
                SaldoDoDia = DiferencaTempo.TotalHours;
            }
            else if (DiaDaSemana == 6)
            {
                if (DataHoraFinalSabado >= DataHoraInicial)
                {
                    DiferencaTempo = DataHoraFinalSabado - DataHoraInicial;
                }
                SaldoDoDia = DiferencaTempo.TotalHours;
            }
            if (DiaDaSemana == 0)
            {
                for (int d = 1; d <= 6; d++)
                {
                    if (d < 6)
                    {
                        saldoSemanal += HorasTrabalhadasNaSemana;
                    }
                    else if (d == 6)
                    {
                        saldoSemanal += HorasTrabalhadasNoSabado;
                    }
                }
            }
            else if (DiaDaSemana > 0)
            {
                for (int d = DiaDaSemana; d <= 6; d++)
                {
                    if (d < 6)
                    {
                        if (d == DiaDaSemana)
                        {
                            if (SaldoDoDia < 15.58)
                            {
                                saldoSemanal += SaldoDoDia;
                            }
                        }
                        else
                        {
                            saldoSemanal += HorasTrabalhadasNaSemana;
                        }
                    }
                    else if (d == 6)
                    {
                        if (d == DiaDaSemana)
                        {
                            if (SaldoDoDia < 7.50)
                            {
                                saldoSemanal += SaldoDoDia;
                            }
                        }
                        else
                        {
                            saldoSemanal += HorasTrabalhadasNoSabado;
                        }
                    }
                }
            }
            Disponibilidade.HDisponivel = Convert.ToInt32(saldoSemanal);
        }
    }
}
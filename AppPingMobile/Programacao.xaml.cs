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
    public partial class Programacao : ContentPage
    {
        public Programacao()
        {
            InitializeComponent();
            lbl.Text = Empresas.Maquina.ToString();
            

        }
    }
}
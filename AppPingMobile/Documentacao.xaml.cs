using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Documentacao : ContentPage
    {
        public Documentacao()
        {
            InitializeComponent();
        }

        //[Obsolete]
        //protected void webOnNavigating(object sender, WebNavigatingEventArgs e)
        //{
        //    if (e.Url.Contains(".pdf"))
        //    {
        //        // retornando a URL
        //        var pdfUrl = new Uri(e.Url);

        //        // Abre a URL do PSD com o navegador para download
        //        Device.OpenUri(pdfUrl);

        //        // Cancela navegacao ao clicar
        //        // (reêm a mesma pagina.)  
        //        e.Cancel = true;
        //    }
        //}
    }
}
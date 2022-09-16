using AppPingMobile.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppPingMobile.Servico
{
    public class ServicoDeDados
    {
        private const string RequestUriCentros = "https://github.com/Davi-IEB/AppPingMobile.git/centros.json";
        HttpClient centros = new HttpClient();
        public async Task<List<Centros>> GetCentrosAsync()
        {
            var response = await centros.GetStringAsync(RequestUriCentros);
            var cts = JsonConvert.DeserializeObject<List<Centros>>(response);
            return cts;
        }
    }
}

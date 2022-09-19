using AppPingMobile.Modelo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppPingMobile.Servico
{
    public class ServicoDeDados
    {
        private const string RequestUriCentros = "https://raw.githubusercontent.com/Davi-IEB/AppPingMobile/master/centros.json";
        HttpClient centros = new HttpClient();
        public async Task<List<Centros>> GetCentrosAsync()
        {
            var response = await centros.GetStringAsync(RequestUriCentros);
            var cts = JsonConvert.DeserializeObject<List<Centros>>(response);
            return cts;
        }
    }
}

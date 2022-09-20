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
        private const string RequestUriMaquinas = "https://raw.githubusercontent.com/Davi-IEB/AppPingMobile/master/maquinas.json";
        private const string RequestUriProgramas = "https://raw.githubusercontent.com/Davi-IEB/AppPingMobile/master/programacao.json";
        HttpClient centros = new HttpClient();
        HttpClient maquinas = new HttpClient();
        HttpClient programas = new HttpClient();
        public async Task<List<Centros>> GetCentrosAsync()
        {
            var response = await centros.GetStringAsync(RequestUriCentros);
            var cts = JsonConvert.DeserializeObject<List<Centros>>(response);
            return cts;
        }
        public async Task<List<Maquina>> GetMaquinasAsync()
        {
            var response2 = await maquinas.GetStringAsync(RequestUriMaquinas);
            var maq = JsonConvert.DeserializeObject<List<Maquina>>(response2);
            return maq;
        }
        public async Task<List<Programa>> GetProgramaAsync()
        {
            var response3 = await programas.GetStringAsync(RequestUriProgramas);
            var prog = JsonConvert.DeserializeObject<List<Programa>>(response3);
            return prog;
        }
    }
}

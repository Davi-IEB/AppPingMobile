using System;
using System.Collections.Generic;
using System.Text;

namespace AppPingMobile.Modelo
{
    public class Empresas
    {
        private static string _empresa;
        public static string Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        private static string _setor;
        public static string Setor
        {
            get { return _setor; }
            set { _setor = value; }
        }
    }
    public class Centros
    {
        public string Cod_empresa { get; set; }
        public string Den_reduz { get; set; }
        public string Setor { get; set; }
        public string Cod_cent_trab { get; set; }
        public string Den_cent_trab { get; set; }
    }

    public class Maquinas
    {
        public string Cod_empresa { get; set; }
        public string Cod_cent_trab { get; set; }
        public string Cod_equip { get; set; }


    }
}

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
    }
}

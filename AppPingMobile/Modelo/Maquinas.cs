using System;
using System.Collections.Generic;
using System.Text;

namespace AppPingMobile.Modelo
{
    public class Maquina
    {
        public string Cod_empresa { get; set; }
        public string Cod_cent_trab { get; set; }
        public string Den_cent_trab { get; set; }
        public string Cod_equip { get; set; }
        public decimal Horas_necessarias { get; set; }
        public decimal Horas_disponiveis { get; set; }
        public decimal Percentual { get; set; }

    }

    public class Disponibilidade
    {
        public static decimal HDisponivel { get; set; }
    }
}

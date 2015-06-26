using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Entidades
{
    public class Previsao
    {
        public string cidade { get; set; }
        public string temperatura { get; set; }
        public string descricao { get; set; }
        public string imagem { get; set; }
        public string umidade { get; set; }
        public string visibilidade { get; set; }
        public string vento_velocidade { get; set; }
        public string vento_direcao { get; set; }
        public string pressao { get; set; }
        public string pressao_status { get; set; }
        public string nascer_do_sol { get; set; }
        public string por_do_sol { get; set; }
        public string data_hora { get; set; }
    }
    public class Previso
    {
        public string data { get; set; }
        public string descricao { get; set; }
        public string temperatura_max { get; set; }
        public string temperatura_min { get; set; }
        public string imagem { get; set; }
    }

    
}

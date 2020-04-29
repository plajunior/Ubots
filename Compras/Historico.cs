using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Compras
{
    public class Historico
    {
        public string codigo { get; set; }
        public string data { get; set; }
        public string cliente { get; set; }
        public List<Iten> itens { get; set; }
        public double valorTotal { get; set; }
    }

}

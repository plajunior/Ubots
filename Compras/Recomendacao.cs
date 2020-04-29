using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Compras
{
    public class Recomendacao
    {
        [LoadColumn(0)]
        public float Cliente;

        [LoadColumn(1)]
        public string Produto;

        [LoadColumn(2)]
        public float Label;

    }
}

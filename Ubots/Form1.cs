using System;
using System.Windows.Forms;
using Compras;

namespace Ubots
{



    public partial class Form1 : Form
    {
        private Processo _Processo;
       
        public Form1()
        {
            InitializeComponent();
            _Processo = new Processo("http://www.mocky.io/v2/598b16291100004705515ec5", "http://www.mocky.io/v2/598b16861100004905515ec7");            
        }             

        private void btnListaClientesMaiorValor_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = _Processo.GetListaClientesMaiorValor();
        }

        private void btnMaiorClienteCompra_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = _Processo.GetMaiorClienteCompra();            
        }

        private void btnClientesFieis_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = _Processo.GetClientesFieis();            
        }

        private void btnRecomendacao_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = _Processo.Recomendar();
        }
    }    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GastoEmRestaurante
{
    public partial class FormGastoEmRestaurante : Form
    {
        public FormGastoEmRestaurante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            double despesa = Convert.ToDouble(txtDespesa.Text);
            despesa = despesa + (despesa*0.1);
            txtTotalConta.Text = "R$" + despesa.ToString("N2");
            */
            txtTotalConta.Text = "R$" + (Convert.ToDouble(txtDespesa.Text) * 1.10).ToString("N2");
        }
    }
}

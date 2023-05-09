using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoDoPesoIdeal
{
    public partial class FormCalculoDoPesoIdeal : Form
    {
        RadioButton rbtnSelecionado = null;
        public FormCalculoDoPesoIdeal()
        {
            InitializeComponent();
        }

        private void rbtnMasculino_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            if (rbtn.Checked )
            {
                rbtnSelecionado = rbtn;
                setPesoIdeal();
            }
        }
        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            setPesoIdeal();
        }
        private void setPesoIdeal()
        {
            try
            {
                double altura = Convert.ToDouble(txtAltura.Text);
                double pesoIdeal;
                if (rbtnSelecionado.Text.Equals("Masculino"))
                {
                    pesoIdeal = (72.7 * altura) - 58;
                }
                else
                {
                    pesoIdeal = (62.1 * altura) - 44.7;
                }
                lblPesoIdeal.Text = pesoIdeal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado! Selecione o sexo e informe a altura corretamente!",
                    "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

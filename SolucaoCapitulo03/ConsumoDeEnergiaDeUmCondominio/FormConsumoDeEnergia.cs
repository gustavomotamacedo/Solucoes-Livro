﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoDeEnergiaDeUmCondominio
{
    public partial class FormConsumoDeEnergia : Form
    {
        private IList<Leitura> leituras = new BindingList<Leitura>();
        private BindingSource leiturasSource = new BindingSource();
        public FormConsumoDeEnergia()
        {
            InitializeComponent();
            leiturasSource.DataSource = leituras;
            dataGridView1.DataSource = leiturasSource;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            RegistraConsumo(txtCasa.Text, Convert.ToDouble(txtConsumo.Text));
        }

        private void RegistraConsumo(string casa, double consumo)
        {
            Leitura leitura = new Leitura(casa, consumo);
            if (leituras.Contains(leitura))
            {
                MessageBox.Show("Essa casa já foi informada!", "Atenção!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                this.leituras.Add(leitura);
                InicializaFormulario();
            }
        }

        private void InicializaFormulario()
        {
            txtCasa.Clear();
            txtConsumo.Clear();
            txtCasa.Focus();
        }

        private void btnProcessarDados_Click(object sender, EventArgs e)
        {
            ProcessarLeituras(dataGridView1);
        }

        private void ProcessarLeituras(DataGridView dgv)
        {
            DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];
            this.leituras.Add(new Leitura("Total", 0));
            for (int i = 0; i < 3; i++)
            {
                dgv.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = Color.Blue;
                dgv.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.ForeColor = Color.Yellow;
                dgv.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.Font = new Font(
                    cell.InheritedStyle.Font, FontStyle.Bold);
            }
            double totalConsumo = 0, totalDesconto = 0;
            foreach (var leitura in leituras)
            {
                totalConsumo += leitura.Consumo;
                totalDesconto += leitura.Desconto;
            }
            dgv[0, dgv.Rows.Count - 1].Value = "Total";
            dgv[1, dgv.Rows.Count - 1].Value = totalConsumo.ToString("N");
            dgv[2, dgv.Rows.Count - 1].Value = totalDesconto.ToString("N");
            lblResultado.Text = "Total sem desconto: " + (totalConsumo - totalDesconto).ToString("N");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReajusteSalarial
{
    public partial class FormReajusteSalarial : Form
    {
        public FormReajusteSalarial()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            RadioButton rbnTurno = gbxTurno.Controls.OfType<RadioButton>()
                .SingleOrDefault(r => r.Checked);
            RadioButton rbnCategoria = gbxCategoria.Controls.OfType<RadioButton>()
                .SingleOrDefault(r => r.Checked);
            RealizarProcessamento(rbnTurno, rbnCategoria,
                Convert.ToDouble(txtHorasTrabalhadas.Text), Convert.ToDouble(txtSalarioMinimo.Text));
        }

        private void RealizarProcessamento(RadioButton rbnTurno, RadioButton rbnCategoria,
            double horas, double salarioMinimo)
        {
            double valorCoeficiente = GetCoeficiente(rbnTurno);
            double valorGratificacao = GetGratificacao(rbnTurno, horas);
            double salarioBruto = horas * valorCoeficiente;
            double valorImposto = GetValorImposto(rbnCategoria, salarioBruto);
            double valorAuxilio = GetValorAuxilio(rbnCategoria, salarioBruto, salarioMinimo);
            double salarioLiquido = (salarioBruto + valorGratificacao + valorAuxilio) - valorImposto;
            ApresentarResultados(valorCoeficiente, salarioBruto, valorImposto,
                valorGratificacao, valorAuxilio,
                salarioLiquido);
        }

        private void ApresentarResultados(double valorCoeficiente, double salarioBruto, double valorImposto, double valorGratificacao, double valorAuxilio, double salarioLiquido)
        {
            txtSituacao.Text = GetSituacaoEstagiario(salarioLiquido);
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Valor do coeficiente:", valorCoeficiente));
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Salário bruto:", salarioBruto));
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Valor do imposto :", valorImposto));
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Valor da gratificação :", valorGratificacao));
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Valor auxilio alimentação :", valorAuxilio));
            lbxResumo.Items.Add(String.Format("{0,-29}{1,12:C}",
            "Salário líquido:", salarioLiquido));
        }

        private string GetSituacaoEstagiario(double salarioLiquido)
        {
            if (salarioLiquido < 350)
            {
                return "Mal remunerado";
            }
            else if (salarioLiquido < 600)
            {
                return "Normal";
            }else
            {
                return "Bem remunerado";
            }
        }

        private double GetValorAuxilio(RadioButton rbnCategoria, double salarioBruto, double salarioMinimo)
        {
            double auxilioAlimentacao = (salarioBruto / 3) / 2;
            if (rbnCategoria.Text.Equals("Calouro") 
                && salarioBruto < salarioMinimo /2)
            {
                auxilioAlimentacao = (salarioBruto / 3);
            }
            return auxilioAlimentacao;
        }

        private double GetValorImposto(RadioButton rbnCategoria, double salarioBruto)
        {
            double imposto = 0;
            switch (rbnCategoria.Text)
            {
                case "Calouro":
                    if (salarioBruto < 300)
                    {
                        imposto = salarioBruto * 0.1;
                    }else
                    {
                        imposto = salarioBruto * 0.2;
                    }
                    break;
                case "Veterano":
                    if (salarioBruto < 400)
                    {
                        imposto = salarioBruto * 0.3;
                    }
                    else
                    {
                        imposto = salarioBruto * 0.4;
                    }
                    break;
            }
            return imposto;
        }

        private double GetGratificacao(RadioButton rbnTurno, double horas)
        {
            double gratificacao = 30;
            if (rbnTurno.Text.Equals("Noturno") && horas > 80)
            {
                gratificacao = 50;
            }
            return gratificacao;
        }

        private double GetCoeficiente(RadioButton rbnTurno)
        {
            double valorCoeficiente = 0;
            switch (rbnTurno.Text)
            {
                case "Matutino":
                    valorCoeficiente = Convert.ToDouble(txtSalarioMinimo.Text) * 0.01;
                    break;
                case "Vespertino":
                    valorCoeficiente = Convert.ToDouble(txtSalarioMinimo.Text) * 0.02;
                    break;
                case "Noturno":
                    valorCoeficiente = Convert.ToDouble(txtSalarioMinimo.Text) * 0.03;
                    break;
            }
            return valorCoeficiente;
        }
    }
}

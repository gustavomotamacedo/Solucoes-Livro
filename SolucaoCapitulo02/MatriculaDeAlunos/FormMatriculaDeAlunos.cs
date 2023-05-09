using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatriculaDeAlunos
{
    public partial class FormMatriculaDeAlunos : Form
    {
        public FormMatriculaDeAlunos()
        {
            InitializeComponent();
        }

        private void txtAniversario_Enter(object sender, EventArgs e)
        {
            if (txtNascimento.Text.Trim().Length != 4)
            {
                MessageBox.Show("O ANO DE NASCIMENTO precisa ter 4 dígitos!",
                    "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNascimento.Focus();
            }
        }

        private void txtAniversario_Validating(object sender, CancelEventArgs e)
        {
            if(txtAniversario.Text != String.Empty &&
                Convert.ToInt32(txtAniversario.Text) < Convert.ToInt32(txtNascimento.Text))
            {
                MessageBox.Show("O ANO DO ÚLTIMO ANIVERSÁRIO não pode ser inferior ao ANO DE NASCIMENTO",
                    "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void btnIdentificar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty || txtNascimento.Text == String.Empty ||
                txtAniversario.Text == String.Empty)
            {
                MessageBox.Show("Todos os dados devem ser preenchido!", "Atenção!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                int idade = Convert.ToInt32(txtAniversario.Text) - Convert.ToInt32(txtNascimento.Text);
                if (idade > 17)
                {
                    label5.Text = "Adulto";
                }else if (idade > 13)
                {
                    label5.Text = "Juvenil B";
                }
                else if (idade > 10)
                {
                    label5.Text = "Juvenil A";
                }
                else if (idade > 7)
                {
                    label5.Text = "Infantil B";
                }
                else if (idade > 5)
                {
                    label5.Text = "Infantil A";
                }
                else
                {
                    label5.Text = "Não existe categoria!";
                }
            }
        }
    }
}

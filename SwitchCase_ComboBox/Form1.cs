using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchCase_ComboBox
{
    public partial class frmPoligono : Form
    {
        public frmPoligono()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            txtResultado.Clear();
            txtLado.Clear();
            txtAltura.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string tri = cbxPoligono.SelectedIndex.Equals(2).ToString();

            if (cbxPoligono.SelectedIndex.Equals(-1) || cbxPoligono.SelectedIndex.Equals(0))
            {
                MessageBox.Show("Insira um polígono!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResultado.Clear();
                txtFormula.Clear();
                cbxPoligono.Focus();
            }
            else if (txtLado.Text == "")
            {
                MessageBox.Show("Insira o valor do Lado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResultado.Clear();
                txtLado.Focus();
            }
            else if (txtAltura.Text == "" && cbxPoligono.SelectedIndex.Equals(3))
            {
                MessageBox.Show("Insira o valor da Altura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResultado.Clear();
                txtAltura.Focus();
            }
            else if (txtAltura.Text == "" && cbxPoligono.SelectedIndex.Equals(2))
            {
                MessageBox.Show("Insira o valor da Altura!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResultado.Clear();
                txtAltura.Focus();
            }
            else if (double.Parse(txtLado.Text) <= 0)
            {
                MessageBox.Show("Insira um valor maior que 0", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtResultado.Clear();
                txtLado.Focus();
            }
            else
            {
                switch (cbxPoligono.SelectedItem)
                {
                    case "Quadrado":
                        txtResultado.Text = (txtLado.Text + " x " + txtLado.Text + " = " + (Convert.ToDouble(txtLado.Text) * Convert.ToDouble(txtLado.Text)).ToString());
                        break;

                    case "Triângulo":
                        txtResultado.Text = (txtLado.Text + " x " + txtAltura.Text + " / 2 = " + (Convert.ToDouble(txtLado.Text) * Convert.ToDouble(txtAltura.Text) / 2).ToString());
                        break;

                    case "Retângulo":
                        txtResultado.Text = (txtLado.Text + " x " + txtAltura.Text + " = " + (Convert.ToDouble(txtLado.Text) * Convert.ToDouble(txtAltura.Text)).ToString());
                        break;
                }
            }
        }

        private void cbxPoligono_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxPoligono.SelectedItem)
            {
                case "Quadrado":
                    txtFormula.Text = "Lado x Lado";
                    txtAltura.ReadOnly = true;
                    Limpar();
                    txtLado.Focus();
                    break;

                case "Triângulo":
                    txtFormula.Text = "Lado x Altura / 2";
                    txtAltura.ReadOnly = false;
                    Limpar();
                    txtLado.Focus();
                    break;

                case "Retângulo":
                    txtFormula.Text = "Lado x Altura";
                    txtAltura.ReadOnly = false;
                    Limpar();
                    txtLado.Focus();
                    break;

                case "":
                    Limpar();
                    txtFormula.Clear();
                    break;
            }
        }

        private void btnApagar_Click_1(object sender, EventArgs e)
        {
            Limpar();
            txtFormula.Clear();
            cbxPoligono.SelectedItem = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pasandole el contenido de "lblResultado", llama al método "DecimalBinario" de la clase "Calculadora" y muestra nuevamente su retorno en "lblResultado".
        /// </summary>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// Pasandole el contenido de "lblResultado", llama al método "BinarioDecimal" de la clase "Calculadora" y muestra nuevamente su retorno en "lblResultado".
        /// </summary>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Valida que tanto "txtNumero1" como "txtNumero2" contengan solo números operables, llama al método "Operar" de esta misma clase y muestra su retorno en "lblResultado".
        /// </summary>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double auxiliarParaValidar1) && double.TryParse(txtNumero2.Text, out double auxiliarParaValidar2))
            {
                string resultadoAMostrar = Operar(txtNumero1.Text, txtNumero2.Text, CmbOperador.Text).ToString();

                lblResultado.Text = resultadoAMostrar;

                if(CmbOperador.Text == "")
                {
                    CmbOperador.Text = "+";
                }
                lstOperaciones.Items.Add(txtNumero1.Text + " " + CmbOperador.Text + " " + txtNumero2.Text + " = " + resultadoAMostrar);
            }
            else
            {
                MessageBox.Show("Alguno de los caracteres ingresados no es un número válido. Por favor, escriba un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        /// <summary>
        /// Llama al método "Limpiar" de esta misma clase.
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Borra los datos de "txtNumero1", "txtNumero2", "CmbOperador" y "lblResultado" de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = string.Empty;

            txtNumero2.Text = string.Empty;

            CmbOperador.SelectedIndex = -1;

            lblResultado.Text = string.Empty;
        }

        /// <summary>
        /// Recibirá dos operandos y un operador para luego llamar al método "Operar" de la clase "Calculadora".
        /// </summary>
        /// <param name="numero1">Primer operando.</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador.</param>
        /// <returns>La operación pedida entre el primer y el segundo operando.</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1.ToString());
            Operando num2 = new Operando(numero2.ToString());

            char.TryParse(operador, out char operandoConvertidoAChar);


            return Calculadora.Operar(num1, num2, operandoConvertidoAChar);
        }


        /// <summary>
        /// Da al usuario una última oportunidad de cancelar el cierre del formulario y cierra dicho formulario si así lo desea.
        /// </summary>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

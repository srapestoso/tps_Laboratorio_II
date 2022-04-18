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
        /// Inicializa los valores de la calculadora al momento de carga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Reestablece los valores de los elementos del Form
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.cmbOperador.Items.Clear();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Text = string.Empty;
            this.lblResultado.Text = "0";
        }


        /// <summary>
        /// Al hacer Click en el boton recupera los valores de los txtBox, cmbBox. Realiza la operacion mostrando el resultado en el lblResultado
        /// y muestra todos los datos en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string operando = cmbOperador.GetItemText(this.cmbOperador.SelectedItem);
            double resultado;
            string calculo;
            double numero1;
            double numero2;
            resultado = Operar(num1, num2, operando);
            this.lblResultado.Text = resultado.ToString();

            if (!double.TryParse(num1, out numero1))
            {
                numero1 = 0;
            }
            if(!double.TryParse(num2,out numero2))
            {
                numero2 = 0;
            }
            if(operando != "+" && operando != "-" && operando != "*" && operando != "/")
            {
                operando = "+";
            }

            calculo = $"{numero1} {operando} {numero2} = {resultado}";
            this.lstOperaciones.Items.Add(calculo);
        }

        /// <summary>
        /// Toma los valores de los textboxs , el comboBox y realiza el calculo llamando al metodo Calculadora.Operar()
        /// </summary>
        /// <param name="num1">STRING del textbox1</param>
        /// <param name="num2">STRING del textbox2</param>
        /// <param name="operando">CHAR del comboBox</param>
        /// <returns>Retorna el resultado del calculo</returns>
        private static double Operar(string num1, string num2, string operando)
        {
            double resultado;
            Operando numero1 = new Operando(num1);
            Operando numero2 = new Operando(num2);
            char.TryParse(operando, out char operacion);

            resultado = Calculadora.Operar(numero1, numero2, operacion);

            return resultado;
        }

        /// <summary>
        /// Al hacer click sobre el boton limpia todos los componentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Cuando se clickea el boton de cerrar llama al FORMCLOSING para confirmar la salida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Al hacer click en el boton CERRAR o al cerrar el FORM, pregunta al usuario si desea salir o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Está seguro de querer salir?","Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(res != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Toma el valor del lblResultado y en caso de ser posible lo convierte a BINARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string calculo = this.lblResultado.Text;
            if(calculo != "" && calculo != double.MinValue.ToString())
            {
                calculo = Operando.DecimalBinario(calculo);
                this.lblResultado.Text = calculo;
            }
        }

        /// <summary>
        /// Toma el valor del lblResultado y en caso de ser posible lo convierte a DECIMAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string calculo = this.lblResultado.Text;
            if(calculo != "" && calculo != double.MinValue.ToString())
            {
                calculo = Operando.DecimalBinario(calculo);
                this.lblResultado.Text = calculo;
            }
        }
    }
}

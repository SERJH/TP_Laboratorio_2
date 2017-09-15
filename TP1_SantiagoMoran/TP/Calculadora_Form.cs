using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.TP1;

namespace TP {

    public partial class Calculadora_Form : Form {

        Numero numero1;
        Numero numero2;
        Calculadora calcu = new Calculadora();
        double resultado = 0;

        public Calculadora_Form() {

            InitializeComponent();
            cmbOperacion.Text = "+";

        }

        private void btnOperar_Click(object sender, EventArgs e) {

            if (txtNumero1.Text != "" && txtNumero2.Text != "") { 

                numero1 = new Numero(txtNumero1.Text);
                numero2 = new Numero(txtNumero2.Text);
                resultado = calcu.operar(numero1, numero2, cmbOperacion.Text);

            }
    
            lblResultado.Text = resultado.ToString();

        }

        private void btnLimpiar_Click(object sender, EventArgs e) {

            limpiar();

        }

        private void cmbOperacion_TextChanged(object sender, EventArgs e) {

            if (cmbOperacion.Text != "+" &&
                cmbOperacion.Text != "-" &&
                cmbOperacion.Text != "*" &&
                cmbOperacion.Text != "/") {

                cmbOperacion.Text = "+";

            }

        }

        public void limpiar() {

            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";

        }

    }
}

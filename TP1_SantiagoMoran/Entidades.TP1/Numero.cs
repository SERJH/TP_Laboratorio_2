using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.TP1
{
    public class Numero {

        private double numero;

        public Numero() {

            this.numero = 0;

        }

        public Numero(double numero) {

            this.numero = numero;

        }

        public Numero(string numero) {

            setNumero(numero);
        
        }

        public double getNumero() {

            return this.numero;

        }

        private void setNumero(string numero) {

            this.numero = validarNumero(numero);

        }

        private double validarNumero(string numeroString) {

            double retorno;

            if (!double.TryParse(numeroString, out retorno)) {

                retorno = 0;

            }

            return retorno;

        }

    }
}

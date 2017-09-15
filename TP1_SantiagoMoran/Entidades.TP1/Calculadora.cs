using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.TP1 {

    public class Calculadora {

        public double operar(Numero numeroUno, Numero numeroDos, string operador) {

            operador = validarOperador(operador);
            double retorno = 0;

            switch (operador) { 
            
                case "+":

                    retorno = (numeroUno.getNumero() + numeroDos.getNumero());
                    break;

                case "-":

                    retorno = (numeroUno.getNumero() - numeroDos.getNumero());
                    break;

                case "*":

                    retorno = (numeroUno.getNumero() * numeroDos.getNumero());
                    break;

                case "/":

                    if (numeroDos.getNumero() == 0) {

                        retorno = 0;

                    } else {

                        retorno = (numeroUno.getNumero() / numeroDos.getNumero());

                    }
                    
                    break;

            }

            return retorno;

        }

        public string validarOperador(string operador) {

            string retorno = operador;

            if (operador != "+" && operador != "-" && operador != "*" && operador != "/") {

                retorno = "+";

            }

            return retorno;

        }

    }

}

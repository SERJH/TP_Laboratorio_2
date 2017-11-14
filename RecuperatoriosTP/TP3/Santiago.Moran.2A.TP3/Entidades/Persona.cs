using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas {

    public abstract class Persona {

        private string _nombre;
        private string _apellido;
        private ENacionalidad _nacionalidad;
        private int _dni;

        public enum ENacionalidad {

            Argentino,
            Extranjero

        }

        #region PROPIEDADES

        public string Nombre {

            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }

        }

        public string Apellido {

            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }

        }

        public ENacionalidad Nacionalidad {

            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }

        }

        public int DNI {

            get { return this._dni; }
            set { this._dni = ValidarDni(this.Nacionalidad, value); }

        }

        public string StringToDNI {

            set { this._dni = ValidarDni(this.Nacionalidad, value); }

        }

        #endregion PROPIEDADES

        #region CONSTRUCTORES

        public Persona() {

            this.Nombre = "Sin nombre";
            this.Apellido = "Sin apellido";
            this.Nacionalidad = ENacionalidad.Argentino;
            this.DNI = 0;

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) {

            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad) {

            this.DNI = dni;

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) :this(nombre, apellido, nacionalidad) {

            this.StringToDNI = dni;

        }

        #endregion CONSTRUCTORES

        #region METODOS

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre: {0}\n", this.Nombre);
            sb.AppendFormat("Apellido: {0}\n", this.Apellido);
            sb.AppendFormat("DNI: {0}\n", this.DNI);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);

            return sb.ToString();

        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato) {

            bool valido = false;

            switch (nacionalidad) {

                case ENacionalidad.Argentino:
                    if (dato > 0 && dato < 90000000) {
                        valido = true;
                    } else if (dato >= 90000000) {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato > 0) {
                        valido = true;
                    }
                    break;

            }
          
            if (valido) {

                return dato;

            } else {

                throw new DniInvalidoException("Numero de DNI invalido");

            }

            return dato;

        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato) {

            int dni;

            if (int.TryParse(dato, out dni)) { 

                return ValidarDni(nacionalidad, dni);

            } else {

                throw new DniInvalidoException("Numero de DNI invalido");
            }

        }

        private string ValidarNombreApellido(string dato) {

            string retorno = "";

            for (int i = 0; i < dato.Length; i++) {

                if (!char.IsLetter(dato[i]) && !char.IsSeparator(dato[i])) {

                    retorno = null;

                }

            }

            if (retorno != null) {

                retorno = dato;

            }

            return retorno;

        }

        #endregion METODOS

    }

}

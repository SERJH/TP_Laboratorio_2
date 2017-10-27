using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas {

    public abstract class Universitario : Persona {

        private int _legajo;

        #region CONSTRUCTORES

        public Universitario() :base() {

            this._legajo = 0;

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(nombre, apellido, dni, nacionalidad) {

            this._legajo = legajo;

        }

        #endregion CONSTRUCTORES

        #region METODOS

        public override bool Equals(object obj) {

            return ((this is Universitario && obj is Universitario) &&
                   ((this._legajo == ((Universitario)obj)._legajo) || this.DNI == ((Universitario)obj).DNI));

        }

        protected virtual string MostrarDatos() {

            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.AppendFormat("Legajo: {0}\n", this._legajo);

            return sb.ToString();

        }

        protected abstract string ParticiparEnClase();

        #endregion METODOS

        #region OPERADORES

        public static bool operator == (Universitario pg1, Universitario pg2) {

            return pg1.Equals(pg2);

        }

        public static bool operator != (Universitario pg1, Universitario pg2) {

            return !(pg1 == pg2);

        }

        #endregion OPERADORES

    }

}

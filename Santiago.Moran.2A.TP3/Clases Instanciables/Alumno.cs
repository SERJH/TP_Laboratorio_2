using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables {

    public sealed class Alumno : Universitario {

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta {

            AlDia,
            Deudor,
            Becado

        }

        #region CONSTRUCTORES

        public Alumno() :base() {

            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.AlDia;

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :base(id, nombre, apellido, dni, nacionalidad) {

            this._claseQueToma = claseQueToma;
            this._estadoCuenta = EEstadoCuenta.AlDia;

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) :this(id, nombre, apellido, dni, nacionalidad, claseQueToma) {

            this._estadoCuenta = estadoCuenta;

        }

        #endregion CONSTRUCTORES

        #region METODOS

        protected override string MostrarDatos() {

            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendFormat("Clase que toma: {0}\n", this._claseQueToma);
            sb.AppendFormat("Estado de cuenta: {0}\n", this._estadoCuenta);

            return sb.ToString();

        }

        protected override string ParticiparEnClase() {

            return "TOMA CLASE DE: " + this._claseQueToma;

        }

        public override string ToString() {

            return this.MostrarDatos();

        }

        #endregion METODOS

        #region OPERADORES 

        public static bool operator == (Alumno a, Universidad.EClases clase) {

            return ((a._claseQueToma == clase) && (a._estadoCuenta != EEstadoCuenta.Deudor));

        }

        public static bool operator != (Alumno a, Universidad.EClases clase) {

            return (a._claseQueToma != clase);

        }

        #endregion OPERADORES

    }

}

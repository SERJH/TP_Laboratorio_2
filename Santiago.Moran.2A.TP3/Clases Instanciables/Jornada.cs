using Clases_Abstractas;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables {

    public class Jornada {

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos {

            get { return this._alumnos; }
            set { this._alumnos = value; }

        }

        public Universidad.EClases Clase {

            get { return this._clase; }
            set { this._clase = value; }

        }

        public Profesor Instructor {

            get { return this._instructor; }
            set { this._instructor = value; }

        }

        #region CONSTRUCTORES

        private Jornada() {

            _alumnos = new List<Alumno>();

        }

        public Jornada(Universidad.EClases clase, Profesor instructor) :this() {

            this.Clase = clase;
            this.Instructor = instructor;

        }

        #endregion CONSTRUCTORES

        #region METODOS

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Clase: {0}\n", this.Clase);
            sb.AppendFormat("\nInstructor:\n{0}\n", this.Instructor);
            sb.AppendLine("Alumnos:\n");

            foreach (Alumno i in this.Alumnos) {

                sb.AppendLine(i.ToString());

            }

            sb.AppendLine("<--------------------------------------->");

            return sb.ToString();

        }

        public static bool Guardar(Jornada jornada) {

            try {

                Texto texto = new Texto();

                texto.Guardar("Jornada.txt", jornada.ToString());

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }

        }

        public static string Leer() {

            Texto texto = new Texto();

            string salida;

            texto.Leer("Jornada.txt", out salida);

            return salida;

        }

        public 

        #endregion METODOS

        #region OPERADORES

        static bool operator == (Jornada j, Alumno a) {

            bool retorno = false;

            if (a == j.Clase) {

                retorno = true;

            }

            return retorno;

        }

        public static bool operator != (Jornada j, Alumno a) {

            return !(j == a);

        }

        public static Jornada operator + (Jornada j, Alumno a) {

            Jornada auxJornada = j;
            bool esta = false;

            foreach (Alumno i in auxJornada.Alumnos) {

                if (a == i) {

                    esta = true;
                    break;

                }

            }

            if (!esta) {

                auxJornada.Alumnos.Add(a);

            }

            return auxJornada;

        }

        #endregion OPERADORES

    }

}

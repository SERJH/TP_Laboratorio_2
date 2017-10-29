using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables {

    public sealed class Profesor : Universitario {

        private Queue<Universidad.EClases> _clasesDelDia;
        static Random _random;

        #region CONSTRUCTORES

        static Profesor() {

            _random = new Random();

        }

        private Profesor() :base() {

            _clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(id, nombre, apellido, dni, nacionalidad) {

            _clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }

        #endregion CONSTRUCTORES

        #region METODOS

        protected override string MostrarDatos() {

            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine("\nClases del día:\n");

            foreach (Universidad.EClases i in this._clasesDelDia) {

                sb.AppendLine(i.ToString());

            }

            return sb.ToString();

        }

        protected override string ParticiparEnClase() {

            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases i in this._clasesDelDia) {

                sb.AppendLine(i.ToString());

            }

            return sb.ToString();

        }

        public override string ToString() {

            return this.MostrarDatos();

        }

        private void _randomClases() {

            int clase;

            for (int i = 0; i < 2; i++) {

                clase = _random.Next(0, 4); ;

                switch (clase) {

                    case 0:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;

                }

            }
            
        }

        #endregion METODOS

        #region OPERADORES

        public static bool operator == (Profesor i, Universidad.EClases clase) {

            bool retorno = false;

            foreach (Universidad.EClases c in i._clasesDelDia) {

                if (clase == c) {

                    retorno = true;

                }

            }

            return retorno;

        }

        public static bool operator != (Profesor i, Universidad.EClases clase) {

            return !(i == clase);

        }

        #endregion OPERADORES

    }

}

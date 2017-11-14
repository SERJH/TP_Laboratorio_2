using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables {

    public class Universidad {

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        public enum EClases {

            Programacion,
            Laboratorio,
            Legislacion,
            SPD

        }

        public List<Alumno> Alumnos {

            get { return this._alumnos; }
            set { this._alumnos = value; }

        }

        public List<Profesor> Instructores {

            get { return this._profesores; }
            set { this._profesores = value; }

        }

        public List<Jornada> Jornadas {

            get { return this._jornada; }
            set { this._jornada = value; }

        }

        public Jornada this[int i] {

            get { return this._jornada[i]; }
            set { this._jornada[i] = value; }

        }

        #region CONSTRUCTORES

        public Universidad() {
            _alumnos = new List<Alumno>();
            _profesores = new List<Profesor>();
            _jornada = new List<Jornada>();

        }

        #endregion CONSTRUCTORES

        #region METODOS

        public static bool Guardar(Universidad gim) {

            try {

                Xml<Universidad> XML = new Xml<Universidad>();

                XML.Guardar("Universidad.xml", gim);

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }
            

        }

        private static string MostrarDatos(Universidad gim) {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADAS:\n");

            foreach (Jornada i in gim.Jornadas) {

                sb.AppendLine(i.ToString());

            }

            return sb.ToString();

        }

        public override string ToString() {

            return Universidad.MostrarDatos(this);

        }

        #endregion METODOS

        #region OPERADORES

        public static bool operator == (Universidad g, Alumno a) {

            bool retorno = false;

            foreach (Alumno i in g.Alumnos) {

                if (i == a) {

                    retorno = true;
                    break;

                }

            }

            return retorno;

        }

        public static bool operator != (Universidad g, Alumno a) {

            return !(g == a);

        }

        public static Profesor operator == (Universidad g, EClases clase) {

            Profesor retorno = null;

            foreach (Profesor i in g.Instructores) {

                if (i == clase) {

                    retorno = i;

                }

            }

            if (retorno != null) {

                return retorno;

            } else {

                throw new SinProfesorException();

            }

        }

        public static Profesor operator != (Universidad g, EClases clase) {

            return null;

        }

        public static bool operator == (Universidad g, Profesor i) {

            bool retorno = false;

            foreach (Profesor p in g.Instructores) {

                if (p == i) {

                    retorno = true;

                }

            }

            return retorno;

        }

        public static bool operator != (Universidad g, Profesor i) {

            return !(g == i);

        }

        public static Universidad operator + (Universidad g, Alumno a) {

            Universidad auxUniversidad = g;
            bool esta = false;

            foreach (Alumno i in auxUniversidad.Alumnos) {

                if (i == a) {

                    esta = true;
                    break;

                }

            }

            if (!esta) {

                auxUniversidad.Alumnos.Add(a);

            } else {

                throw new AlumnoRepetidoException();

            }

            return auxUniversidad;

        }

        public static Universidad operator + (Universidad g, EClases clase) {

            Universidad auxUniversidad = g;
            Jornada nuevaJornada;


            foreach (Profesor i in auxUniversidad.Instructores) {

                if (i == clase) {

                    nuevaJornada = new Jornada(clase, i);

                    foreach (Alumno j in auxUniversidad.Alumnos) {

                        if (j == clase) {

                            nuevaJornada.Alumnos.Add(j);

                        }

                    }

                    auxUniversidad.Jornadas.Add(nuevaJornada);
                    return auxUniversidad;

                }

            }

            throw new SinProfesorException();

        }

        public static Universidad operator + (Universidad g, Profesor i) {

            Universidad auxUniversidad = g;
            bool esta = false;

            foreach (Profesor p in auxUniversidad.Instructores) {

                if (i == p) {

                    esta = true;
                    break;

                }

            }

            if (!esta) {

                auxUniversidad.Instructores.Add(i);

            }

            return auxUniversidad;

        }

        #endregion OPERADORES

    }

}

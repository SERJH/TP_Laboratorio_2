using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos {

    public class Texto : IArchivo<string> {

        private string _archivo;

        public Texto(string archivo) {

            this._archivo = archivo;

        }

        public bool Guardar(string datos) {

            StreamWriter sw = new StreamWriter(this._archivo, true);

            try {

                sw.WriteLine(datos);
                sw.Close();

                return true;

            } catch (Exception) {

                sw.Close();
                return false;

            }

        }

        public bool Leer(out List<string> datos) {

            datos = new List<string>();

            if (!File.Exists(this._archivo)) {

                return false;

            }

            StreamReader sr = new StreamReader(this._archivo);

            try {

                while (!sr.EndOfStream) {

                    datos.Add(sr.ReadLine());

                }

                sr.Close();

                return true;

            } catch (Exception) {

                sr.Close();
                return false;
                throw;

            }

        }

    }

}

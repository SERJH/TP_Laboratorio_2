using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos {

    public class Texto : IArchivo<string> {

        public bool Guardar(string archivo, string datos) {

            try {

                StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);

                sw.Write(datos);

                sw.Close();

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }

        }

        public bool Leer(string archivo, out string datos) {

            try {

                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);

                datos = sr.ReadToEnd();

                sr.Close();

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }

        }

    }

}

﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos {

    public class Xml <T> : IArchivo<T> {

        public bool Guardar(string archivo, T datos) {

            try {

                TextWriter tw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo);

                XmlSerializer serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(tw, datos);

                tw.Close();

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }

        }

        public bool Leer(string archivo, out T datos) {

            try {

                TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo);

                XmlSerializer serializer = new XmlSerializer(typeof(T));

                datos = (T)serializer.Deserialize(tr);

                tr.Close();

                return true;

            } catch (Exception e) {

                throw new ArchivosException(e);

            }

        }

    }

}

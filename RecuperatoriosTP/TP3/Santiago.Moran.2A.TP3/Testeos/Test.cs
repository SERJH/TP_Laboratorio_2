using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace Testeos {
    
    [TestClass]
    public class Test {

        [TestMethod]
        public void ValidarDniNegativo() {

            try {

                Alumno alumno = new Alumno(2, "Yaki", "Sieras", "-1", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            } catch (DniInvalidoException e) {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));

            }

        }

        [TestMethod]
        public void ValidarDniNacionalidad() {

            try {

                Profesor profesor = new Profesor(4, "Esteban", "Dido", "99999999", Persona.ENacionalidad.Argentino);

            } catch (NacionalidadInvalidaException e) {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));

            }

        }

        [TestMethod]
        public void ValidarDniConLetras() {

            try {

                Alumno alumno = new Alumno(7, "Aquiles", "Bailo", "99g999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            } catch (DniInvalidoException e) {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));

            }

        }

        [TestMethod]
        public void ValidarNulo() {

            Alumno alumno = new Alumno(9, "Agus", "Toestoy", "9999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.DNI);
            Assert.IsNotNull(alumno.Nacionalidad);
            Assert.IsNotNull(alumno.Nombre);

        }

        [TestMethod]
        public void ValidarNumero() {

            Alumno alumno = new Alumno(12, "Santiago", "Moran", "9999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));

        }

    }
}

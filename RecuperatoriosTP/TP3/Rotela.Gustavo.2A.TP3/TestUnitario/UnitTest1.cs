using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Archivos;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DocumentoValidado()
        {
            int dni = 38467819;
            Alumno a = new Alumno(1994, "Gustavo", "Rotela", dni.ToString() , Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);

            Assert.AreEqual(a.DNI, dni);
        }

        [TestMethod]
        public void ComprobarAlumnoRepetido()
        {
            try
            {
                Gimnasio gim = new Gimnasio();

                Alumno a1 = new Alumno(1994, "Gustavo", "Rotela", "38467819", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);
                Alumno a2 = new Alumno(1994, "Gustavo", "Rotela", "38467819", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);

                gim += a1;
                gim += a2;

                Assert.Fail("Alumno repetido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void ComprobarNacionalidad()
        {
            try
            {
                Alumno a1 = new Alumno(1994, "Gustavo", "Rotela", "38467819", Persona.ENacionalidad.Extranjero, Gimnasio.EClases.Natacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void AlumnoNoInstaciado()
        {
            Alumno a1 = new Alumno(1994, "Gustavo", "Rotela", "38467819", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion);

            Assert.AreNotEqual(null, a1.Nombre);
            Assert.AreNotEqual(null, a1.Apellido);
            Assert.AreNotEqual(null, a1.Nacionalidad);

            Assert.IsNotNull(a1);
        }

    }
}

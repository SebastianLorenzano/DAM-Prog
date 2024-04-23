using ConsoleApp1;

namespace TestAlumno
{
    [TestFixture]
    public class TestAlumno
    {
        [Test]
        public void TestNombreValido()
        {
            var alumn = new Alumno() { Nombre = "Juan" };
            string esperado = "Juan";
            Assert.AreEqual(esperado, alumn.Nombre);

        }

        [Test]
        public void TestNombreNoValido()
        {
            var alumn = new Alumno() { Nombre = null };
            string? esperado = null;
            Assert.AreEqual(esperado, alumn.Nombre);

        }

        [Test]
        public void TestNotaValida()
        {
            Alumno alum = new Alumno();
            int nota = 4;
            int esperado = 4;
            alum.Nota = nota;
            Assert.AreEqual(esperado, alum.Nota);
        }

        [Test]
        public void TestNotaNoValida1()
        {
            Alumno alum = new Alumno();
            int nota = -4;
            int esperado = 0;
            alum.Nota = nota;
            Assert.AreEqual(esperado, alum.Nota);
        }
        [Test]
        public void TestNotaNoValida2()
        {
            Alumno alum = new Alumno();
            int nota = 56;
            int esperado = 0;
            alum.Nota = nota;
            Assert.AreEqual(esperado, alum.Nota);
        }

        [Test]
        public void TestNotaValida([Range(0, 10, 1)] int nota)
        {
            Alumno alum = new Alumno();
            alum.Nota = nota;
            Assert.AreEqual(nota, alum.Nota);
        }

        [Test]
        public void TestAprobado()
        {
            Alumno alum = new Alumno();
            int nota = 5;
            alum.Nota = nota;
            Assert.IsTrue(alum.Aprobado);
        }

        [Test]
        public void TestNoAprobado()
        {
            Alumno alum = new Alumno();
            int nota = 4;
            alum.Nota = nota;
            Assert.IsFalse(alum.Aprobado);
        }
    }

    [TestFixture]
    public class TestAlumnos
    {

        [Test]
        public void TestAgregar()
        {
            Alumnos alums = new Alumnos();
            Alumno alum = new Alumno();
            alums.Agregar(alum);
            Assert.AreEqual(alum, alums.Obtener(0));
        }
        
        [Test]
        public void TestAgregarNull()
        {
            Alumnos alums = new Alumnos();
            alums.Agregar(null);
            Assert.IsNull(alums.Obtener(0));
        }

        [Test]
        public void TestObtener()
        {
            Alumnos alums = new Alumnos();
            Alumno alum = new Alumno();
            alums.Agregar(alum);
            Assert.AreEqual(alum, alums.Obtener(0));
        }

        [Test]
        public void TestObtenerNull()
        {
            Alumnos alums = new Alumnos();
            Assert.IsNull(alums.Obtener(0));
        }

        [Test]
        public void TestObtenerNull2()
        {
            Alumnos alums = new Alumnos();
            alums.Agregar(new Alumno());
            Assert.IsNull(alums.Obtener(1));
        }

        [Test]
        public void TestObtenerNull3()
        {
            Alumnos alums = new Alumnos();
            Assert.IsNull(alums.Obtener(-1));
        }

        [Test]
        public void TestMedia1()
        {
            Alumnos alums = new Alumnos();
            int esperado = 0;
            Assert.AreEqual(esperado, alums.Media);
        }

        [Test]
        public void TestMedia2()
        {
            Alumnos alums = new Alumnos();
            alums.Agregar(new Alumno() { Nota = 10 });
            int esperado = 10;
            Assert.AreEqual(esperado, alums.Media);
        }

        [Test]
        public void TestMedia3()
        {
            Alumnos alums = new Alumnos();
            alums.Agregar(new Alumno() { Nota = 10 });
            alums.Agregar(new Alumno() { Nota = 8 });
            int esperado = 9;
            Assert.AreEqual(esperado, alums.Media);
        }




    }




}
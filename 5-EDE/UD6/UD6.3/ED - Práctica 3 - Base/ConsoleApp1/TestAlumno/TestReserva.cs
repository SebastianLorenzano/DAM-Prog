using ConsoleApp1;

namespace Test
{
    public class TestReserva
    {

        [Test]
        public void TestNifInvalido()
        {
            var r = new Reserva();

            Assert.Throws<ArgumentException>(() => r.Nif = null);
        }


        [Test]
        public void TestNifValido()
        {
            var r = new Reserva();

            Assert.Throws<ArgumentException>(() => r.Nif = "");
        }

        [Test]
        public void TestNifValido2()
        {
            var r = new Reserva();
            r.Nif = "12345678A";
            Assert.That(r.Nif, Is.EqualTo("12345678A"));
        }


        [Test]
        public void TestNifValido3()
        {
            var r = new Reserva();

            Assert.DoesNotThrow(() => r.Nif = "87654321A");
        }


        [Test]
        public void TestNumPlazasValido()
        {
            var r = new Reserva();

            Assert.Throws<ArgumentException>(() => r.NumPlazas = 0);
        }

        [Test]
        public void TestNumPlazasValido2()
        {
            var r = new Reserva();

            Assert.DoesNotThrow(() => r.NumPlazas = 1);
        }

        [Test]
        public void TestNumPlazasValido3()
        {
            var r = new Reserva();
            r.NumPlazas = 1;
            Assert.That(r.NumPlazas, Is.EqualTo(1));
        }
    }




}
using NUnit.Framework;
using Practica6._3;

namespace ReservaTestsNamespace
{
    [TestFixture]
    public class TestReserva
    {
        //Test para tene line coverage del 100% y los test no se pueden repetir
        [Test]
        public void TestNifValido()
        {
            Reserva reserva = new Reserva();

            Assert.Throws<ArgumentException>(() => reserva.Nif = "");
        }

        [Test]
        public void TestNumPlazasValido()
        {
            Reserva reserva = new Reserva();

            Assert.Throws<ArgumentException>(() => reserva.NumPlazas = 0);
        }
        [Test]
        public void TestNifValido2()
        {
            Reserva reserva = new Reserva();

            Assert.DoesNotThrow(() => reserva.Nif = "12345678A");
        }
        [Test]
        public void TestNumPlazasValido2()
        {
            Reserva reserva = new Reserva();

            Assert.DoesNotThrow(() => reserva.NumPlazas = 1);
        }
        [Test]
        public void TestNifValido3()
        {
            Reserva reserva = new Reserva();
            reserva.Nif = "12345678A";
            Assert.That(reserva.Nif, Is.EqualTo("12345678A"));
        }
        [Test]
        public void TestNumPlazasValido3()
        {
            Reserva reserva = new Reserva();
            reserva.NumPlazas = 1;
            Assert.That(reserva.NumPlazas, Is.EqualTo(1));
        }
    }
}
using Hanoi_LIB;

namespace Hanoi_Tests
{
    public class Tests
    {
        Hanoi hanoi;
        int korongok;

        [SetUp]
        public void Setup()
        {
            korongok = 3;
            hanoi = new Hanoi(korongok);
        }

        [Test]
        public void BaloldaliRúdKezdetbenTeljes()
        {
            Assert.That(hanoi.A.Count, Is.EqualTo(korongok));
        }

        [Test]
        public void TöbbiRúdKezdetbenÜres()
        {
            Assert.That(Hanoi.ÜresRúd(hanoi.B), Is.True);
            Assert.That(Hanoi.ÜresRúd(hanoi.C), Is.True);
        }

        [Test]
        public void ÜresRúdbaÁttehető()
        {
            Assert.That(Hanoi.Áttehető(hanoi.B, 1), Is.True);
        }

        [Test]
        public void KezdetiFázisbanÁthelyezések()
        {   
            Assert.That(Hanoi.Áttehető(hanoi.A, 2), Is.False);
            Assert.That(Hanoi.Áttehető(hanoi.B, 1), Is.True);
            Assert.That(Hanoi.Áttehető(hanoi.C, 3), Is.True);
        }

        [Test]
        public void NagyobbKorongNemHelyezhetőÁt()
        {
            hanoi.B.Push(1);
            Assert.That(Hanoi.Áttehető(hanoi.B, 2), Is.False);
            Assert.That(Hanoi.Áttehető(hanoi.B, 3), Is.False);
        }

        [Test]
        public void KisebbKorongÁthelyezhető()
        {
            hanoi.C.Push(1);
            Assert.That(Hanoi.Áttehető(hanoi.B, 2), Is.True);
            Assert.That(Hanoi.Áttehető(hanoi.B, 2), Is.True);
        }

        [Test]
        public void VisszaTehető()
        {
            int áthelyezendőKorong = hanoi.A.Peek();
            Hanoi.KorongÁttevés(hanoi.A, hanoi.B);
            Assert.That(hanoi.A.Peek(), Is.Not.EqualTo(áthelyezendőKorong)); // át lett helyezve

            int áthelyezettKorong = hanoi.B.Peek();
            Assert.That(áthelyezendőKorong == áthelyezettKorong, Is.True); // A felső korongja most már egyenlő B felső korongjával

            Hanoi.KorongÁttevés(hanoi.B, hanoi.A);
            Assert.That(hanoi.A.Peek() == áthelyezendőKorong, Is.True); // A felső korongja egyezik a kezdetben áthelyezett koronggal
        }

        [Test]
        public void VégetÉrtJáték()
        {
            hanoi.A.Pop();
            hanoi.A.Pop();
            hanoi.A.Pop();
            hanoi.C.Push(3);
            hanoi.C.Push(2);
            hanoi.C.Push(1);
            Assert.That(Hanoi.JátékVége(hanoi.A, hanoi.B, hanoi.C, 3), Is.True);
        }
    }
}

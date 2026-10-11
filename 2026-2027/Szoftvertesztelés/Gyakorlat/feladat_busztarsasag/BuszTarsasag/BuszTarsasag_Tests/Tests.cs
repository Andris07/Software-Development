using BuszTarsasag_LIB;

namespace BuszTarsasag_Tests
{
    public class Tests
    {
        Busz busz;
        Megallo megallo;
        Megallok megallok;

        [SetUp]
        public void Setup()
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            megallo = new Megallo("Örs Vezér Tér", 20);
            megallok = new Megallok(new Dictionary<string, int>
            {
                // meglévő Örs Vezér Tér mock megálló
                { megallo.Nev, megallo.MegallobanVarakozoEmberek },
                { "Deák Ferenc Tér", 25 },
                { "Kálvin Tér", 15 },
                { "Astoria", 10 },
                { "Blaha Lujza Tér", 8 },
                { "Nyugati Pályaudvar", 12 },
                { "Keleti Pályaudvar", 18 }
                // Random megállók random várakozó emberekkel mock célra
            });
        }

        [Test]
        // első két esetben a buszra felszálló emberek száma negatív, ami nem lehetséges, így false-t kell visszaadnia a metódusnak
        [TestCase(-13, ExpectedResult = false)]
        [TestCase(-1, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        [TestCase(21, ExpectedResult = true)]
        [TestCase(67, ExpectedResult = false)]
        // utolsó esetben a buszra felszálló emberek száma nagyobb, mint a megállóban várakozó emberek száma (20), ami szintén nem lehetséges, így false-t kell visszaadnia a metódusnak
        public bool UtasCsereMethod(int utasokSzama)
        {
            // Megállóban várakozó emberek leszállnak, de közben új emberek is érkeznek a megállóba az előző buszjárat miatt
            bool eredmeny = megallo.UtasCsere(utasokSzama, 5);
            return eredmeny;
        }

        [Test]
        [TestCase("Déli Pályaudvar", 13, ExpectedResult = false)]
        [TestCase("Semmelweis Klinikák", 0, ExpectedResult = false)]
        [TestCase("Kossuth Lajos tér", -67, ExpectedResult = true)]
        public bool ErvenytelenMegallobanVarakozoEmberek(string Nev, int varakozoEmberekSzama)
        {
            Megallo ujMegallo = new Megallo(Nev, varakozoEmberekSzama);
            megallok.MegalloHelyek.Add(ujMegallo);

            bool eredmeny = megallok.ErvenytelenMegallo();
            return eredmeny;
        }

        [Test]
        [TestCase(13, 0, ExpectedResult = true)]
        [TestCase(13, 5, ExpectedResult = false)]
        [TestCase(13, 10, ExpectedResult = false)]
        // utolsó kettő azért false, mert üres buszról nem lehet leszállni (elvileg)
        public bool MegalloUtasCsereUresBuszra(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            bool eredmeny = busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);
            return eredmeny;
        }

        [Test]
        // első esetben felszáll 30 ember egy üres buszra, ami lehetséges, így true-t kell visszaadnia a metódusnak
        [TestCase(30, 0, ExpectedResult = true)]
        [TestCase(30, 1, ExpectedResult = false)]
        [TestCase(15, 15, ExpectedResult = false)]
        [TestCase(13, 17, ExpectedResult = false)]
        [TestCase(30, 30, ExpectedResult = true)]
        // utolsó esetben a buszra felszálló emberek száma nagyobb, mint a busz szabad férőhelye (0), ami szintén nem lehetséges, így false-t kell visszaadnia a metódusnak
        public bool MegteltBuszUtasCsereUtan(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz.MegalloUtasCsere(megallo, buszrolLeszalloEmberek, 0);
            busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);
            return busz.MegteltBusz();
        }

        [Test]
        [TestCase(-1, ExpectedResult = true)]
        [TestCase(15, ExpectedResult = false)]
        [TestCase(31, ExpectedResult = true)]
        public bool FelszalloEmberekSzamaErvenytelen(int buszraFelszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, 0);

            bool eredmeny = busz.FelszalloEmberekSzamaErvenytelen(buszraFelszalloEmberek);
            return eredmeny;
        }

        [Test]
        [TestCase(-1, ExpectedResult = true)]
        [TestCase(15, ExpectedResult = false)]
        [TestCase(31, ExpectedResult = true)]
        public bool LeszalloEmberekSzamaErvenytelen(int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            busz.MegalloUtasCsere(megallo, buszrolLeszalloEmberek, 0);

            bool eredmeny = busz.LeszalloEmberekSzamaErvenytelen(buszrolLeszalloEmberek);
            return eredmeny;
        }

        [Test]
        [TestCase(-1, -1, ExpectedResult = true)]
        [TestCase(-1, 15, ExpectedResult = true)]
        [TestCase(15, -1, ExpectedResult = true)]
        [TestCase(3, 2, ExpectedResult = false)]
        [TestCase(10, 10, ExpectedResult = false)]
        [TestCase(10, 20, ExpectedResult = false)] // 20 ember leszáll, 10 fel, ami lehetséges, így true-t kell visszaadnia a metódusnak
        [TestCase(20, 30, ExpectedResult = true)] // több leszálló, mint buszon tartózkodó ember, ami nem lehetséges, így false-t kell visszaadnia a metódusnak
        [TestCase(30, 31, ExpectedResult = true)]
        [TestCase(31, 30, ExpectedResult = true)]
        [TestCase(31, 31, ExpectedResult = true)]
        public bool felEsLeszallokSzamaErvenytelen(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            busz.MegalloUtasCsere(megallo, buszrolLeszalloEmberek, 0);

            bool eredmeny = busz.felEsLeszallokSzamaErvenytelen(buszraFelszalloEmberek, buszrolLeszalloEmberek);
            return eredmeny;
        }

        [Test]
        [TestCase(1, 1, ExpectedResult = true)]
        [TestCase(5, 5, ExpectedResult = true)]
        [TestCase(10, 10, ExpectedResult = true)]
        public bool MegalloUtasCsereUgyanannyiFelszalloEsLeszalloMiattSzabadFeroHelyNemValtozik(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);

            // A busz szabad férőhelye nem változik, mivel ugyanannyi ember száll fel, mint amennyi leszáll
            bool eredmeny = busz.SzabadFerohely == 30;
            return eredmeny;
        }

        [Test]
        [TestCase(16, 14, ExpectedResult = false)]
        [TestCase(17, 14, ExpectedResult = true)]
        [TestCase(21, 20,ExpectedResult = true)]
        [TestCase(29, 1, ExpectedResult = false)]
        [TestCase(30, 0, ExpectedResult = false)]
        [TestCase(30, 1, ExpectedResult = true)]
        [TestCase(31, 1, ExpectedResult = true)]
        public bool MegalloUtasCsereTobbFelszalloMintSzabadFerohely(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            // feltöltjük a buszt annyi emberrel, amennyi leszáll, hogy legyen szabad férőhely
            busz.MegalloUtasCsere(megallo, buszrolLeszalloEmberek, 0);

            bool eredmeny = busz.felSzallasUtaniFerohelyErvenytelen(buszraFelszalloEmberek);
            return eredmeny;
        }

        [Test]
        [TestCase(-1, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(15, ExpectedResult = false)]
        [TestCase(30, ExpectedResult = false)]
        [TestCase(31, ExpectedResult = true)]
        public bool BuszFoglaltFerohelyErvenytelen(int foglaltFerohely)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            busz.MegalloUtasCsere(megallo, foglaltFerohely, 0);

            busz.BuszFoglaltFerohelySet(foglaltFerohely); // beállítjuk a foglalt férőhelyet a tesztelt értékre

            bool eredmeny = busz.BuszFoglaltFerohelyErvenytelen();
            return eredmeny;
        }

        [Test]
        [TestCase(0, 0, 30)]
        [TestCase(0, 5, 30)]
        [TestCase(5, 5, 25)]
        [TestCase(5, 10, 25)]
        [TestCase(10, 15, 20)]
        public void MegalloUtasCsereFerohelyValtozas(int buszraFelszalloEmberek, int buszrolLeszalloEmberek, int varhatoSzabadFerohely)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            // Feltöltjük a buszt annyi emberrel, ahányan később leszállnak
            busz.MegalloUtasCsere(megallo, buszrolLeszalloEmberek, 0);

            busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);

            // A busz szabad férőhelye a várható értékre változik
            Assert.That(varhatoSzabadFerohely.Equals(busz.SzabadFerohely));
        }

        [Test]
        [TestCase(10, 1, ExpectedResult = true)]
        [TestCase(10, 5, ExpectedResult = true)]
        [TestCase(10, 10, ExpectedResult = true)]
        public bool MegalloUtasCsereFeltoltottBuszra(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            // Feltöltjük a buszt 20 emberrel)
            busz.MegalloUtasCsere(megallo, 20, 0);

            bool eredmeny = busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);
            return eredmeny;
        }

        [Test]
        [TestCase(0, 31, ExpectedResult = false)]
        [TestCase(15, 31, ExpectedResult = false)]
        [TestCase(30, 31, ExpectedResult = false)]
        public bool MegalloUtasCsereTobbLeszallovalMintFerohely(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            busz = new Busz("miniBusz", 30, "ABC-123");
            Megallo megallo = new Megallo("Déli Pályaudvar", 13);

            bool eredmeny = busz.MegalloUtasCsere(megallo, buszraFelszalloEmberek, buszrolLeszalloEmberek);
            return eredmeny;
        }
    }
}
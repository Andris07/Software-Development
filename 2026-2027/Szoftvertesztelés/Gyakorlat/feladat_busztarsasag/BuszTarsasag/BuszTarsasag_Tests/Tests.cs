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

        [Test]
        public void BuszKezdetiAllapot()
        {
            Busz ujBusz = new Busz("normal", 40, "XYZ-789");

            Assert.That(ujBusz.Meret, Is.EqualTo("normal"));
            Assert.That(ujBusz.Ferohely, Is.EqualTo(40));
            Assert.That(ujBusz.Rendszam, Is.EqualTo("XYZ-789"));
            Assert.That(ujBusz.FoglaltFerohely, Is.EqualTo(0));
            Assert.That(ujBusz.SzabadFerohely, Is.EqualTo(40));
            Assert.That(ujBusz.EddigSzallitottUtasokLetszama(), Is.EqualTo(0));
            Assert.That(ujBusz.MegteltBusz(), Is.False);
        }

        [Test]
        public void BuszToString()
        {
            Assert.That(busz.ToString(), Is.EqualTo("Busz: Méret=miniBusz, Férőhely=30, Rendszám=ABC-123"));
        }

        [Test]
        public void MegalloUtasCsereErvenytelenMegalloraFalse()
        {
            // negatív várakozó létszámú megállóval nem lehet cserélni
            Megallo hibasMegallo = new Megallo("Kossuth Lajos tér", -5);

            bool eredmeny = busz.MegalloUtasCsere(hibasMegallo, 0, 0);

            Assert.That(eredmeny, Is.False);
            Assert.That(busz.FoglaltFerohely, Is.EqualTo(0));
        }

        [Test]
        public void SzallitottUtasokSzamaCsakFelszalloktolNo()
        {
            busz.MegalloUtasCsere(megallo, 10, 0);   // megállóban 20-an várnak, 10-en felszállnak
            busz.MegalloUtasCsere(megallo, 5, 4);    // 4 leszáll, 5 felszáll

            Assert.That(busz.FoglaltFerohely, Is.EqualTo(11));
            // a leszállók nem számítanak bele, csak aki felszállt: 10 + 5
            Assert.That(busz.EddigSzallitottUtasokLetszama(), Is.EqualTo(15));
        }

        [Test]
        public void ErvenytelenCsereNemValtoztatSzallitottUtasokon()
        {
            // 31 ember nem fér fel a 30 férőhelyes buszra
            bool eredmeny = busz.MegalloUtasCsere(megallo, 31, 0);
            // üres buszról nem tud senki leszállni
            bool eredmeny2 = busz.MegalloUtasCsere(megallo, 0, 5);

            Assert.That(eredmeny, Is.False);
            Assert.That(eredmeny2, Is.False);
            Assert.That(busz.EddigSzallitottUtasokLetszama(), Is.EqualTo(0));
            Assert.That(busz.Esemenyek.Count, Is.EqualTo(0));
        }

        [Test]
        public void MegtelikABuszEsMaradnakAMegalloban()
        {
            Busz kisBusz = new Busz("miniBusz", 15, "KIS-001");
            Megallo teliMegallo = new Megallo("Deák Ferenc Tér", 20);

            bool eredmeny = kisBusz.MegalloUtasCsere(teliMegallo, 15, 0);

            // a busz tele lett, de a megállóban maradtak emberek, ezért false
            Assert.That(eredmeny, Is.False);
            Assert.That(kisBusz.MegteltBusz(), Is.True);
            Assert.That(kisBusz.EddigSzallitottUtasokLetszama(), Is.EqualTo(15));
            Assert.That(teliMegallo.MegallobanVarakozoEmberek, Is.EqualTo(5));
        }

        [Test]
        public void MegtelikABuszDeSenkiNemMaradLent()
        {
            Busz kisBusz = new Busz("miniBusz", 15, "KIS-001");
            Megallo megallo15 = new Megallo("Deák Ferenc Tér", 15);

            bool eredmeny = kisBusz.MegalloUtasCsere(megallo15, 15, 0);

            Assert.That(eredmeny, Is.True);
            Assert.That(kisBusz.MegteltBusz(), Is.True);
            Assert.That(megallo15.MegallobanVarakozoEmberek, Is.EqualTo(0));
        }

        [Test]
        [TestCase(35, 5)]
        [TestCase(31, 1)]
        [TestCase(30, 0)]
        [TestCase(10, 0)]
        [TestCase(0, 0)]
        public void LentMaradtUtasokSzamaUresBuszon(int felszallniAkarok, int vartLentMaradt)
        {
            Assert.That(busz.LentMaradtUtasokSzama(felszallniAkarok), Is.EqualTo(vartLentMaradt));
        }

        [Test]
        [TestCase(15, 5)]
        [TestCase(10, 0)]
        [TestCase(5, 0)]
        public void LentMaradtUtasokSzamaReszbenFeltoltottBuszon(int felszallniAkarok, int vartLentMaradt)
        {
            // 20 ember van a buszon, 10 szabad hely marad
            busz.MegalloUtasCsere(megallo, 20, 0);

            Assert.That(busz.LentMaradtUtasokSzama(felszallniAkarok), Is.EqualTo(vartLentMaradt));
        }

        [Test]
        public void MegalloSzamlalokKezdetbenNullak()
        {
            Assert.That(megallo.FelszalltOsszesen, Is.EqualTo(0));
            Assert.That(megallo.LeszalltOsszesen, Is.EqualTo(0));
        }

        [Test]
        public void MegalloSzamlalokOsszeadodnak()
        {
            megallo.UtasCsere(5, 3);    // 20 -> 18
            megallo.UtasCsere(2, 7);    // 18 -> 23

            Assert.That(megallo.FelszalltOsszesen, Is.EqualTo(7));
            Assert.That(megallo.LeszalltOsszesen, Is.EqualTo(10));
            Assert.That(megallo.MegallobanVarakozoEmberek, Is.EqualTo(23));
        }

        [Test]
        [TestCase(21, 0)]
        [TestCase(-1, 3)]
        [TestCase(3, -1)]
        [TestCase(25, 4)]
        public void MegalloSzamlalokErvenytelenCsereNemValtozik(int felszallok, int leszallok)
        {
            bool eredmeny = megallo.UtasCsere(felszallok, leszallok);

            Assert.That(eredmeny, Is.False);
            Assert.That(megallo.FelszalltOsszesen, Is.EqualTo(0));
            Assert.That(megallo.LeszalltOsszesen, Is.EqualTo(0));
            Assert.That(megallo.MegallobanVarakozoEmberek, Is.EqualTo(20));
        }

        [Test]
        public void UresMegalloUtasCsereNullaNulla()
        {
            Megallo uresMegallo = new Megallo("Déli Pályaudvar", 0);

            Assert.That(uresMegallo.UtasCsere(0, 0), Is.True);
            Assert.That(uresMegallo.UtasCsere(1, 0), Is.False);
            Assert.That(uresMegallo.FelszalltOsszesen, Is.EqualTo(0));
        }

        [Test]
        public void MegalloFelEsLeszalloUtasaiTobbBusszal()
        {
            Busz masikBusz = new Busz("normal", 40, "DEF-456");
            Megallo sajatMegallo = new Megallo("Déli Pályaudvar", 20);

            busz.MegalloUtasCsere(sajatMegallo, 10, 0);       // 10 fel, megállóban 10 marad
            busz.MegalloUtasCsere(sajatMegallo, 3, 4);        // 3 fel, 4 le -> 10 + 4 - 3 = 11
            masikBusz.MegalloUtasCsere(sajatMegallo, 5, 0);   // 5 fel -> 6

            Assert.That(sajatMegallo.FelszalltOsszesen, Is.EqualTo(18));
            Assert.That(sajatMegallo.LeszalltOsszesen, Is.EqualTo(4));
            Assert.That(sajatMegallo.MegallobanVarakozoEmberek, Is.EqualTo(6));
        }

        [Test]
        public void ErvenytelenBuszCsereNemIrjaFelAMegalloAdatait()
        {
            // üres buszról nem lehet leszállni, ezért a megállóhoz sem kerülhet be senki
            busz.MegalloUtasCsere(megallo, 0, 5);

            Assert.That(megallo.LeszalltOsszesen, Is.EqualTo(0));
            Assert.That(megallo.MegallobanVarakozoEmberek, Is.EqualTo(20));
        }

        [Test]
        [TestCase("Örs Vezér Tér", ExpectedResult = 10)]
        [TestCase("Deák Ferenc Tér", ExpectedResult = 18)]
        [TestCase("Kálvin Tér", ExpectedResult = 23)]
        [TestCase("Astoria", ExpectedResult = null)]       // ide nem járt a busz
        [TestCase("Nincs Ilyen", ExpectedResult = null)]
        public int? SzallitottUtasokMegalloig(string megalloNev)
        {
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Örs Vezér Tér")!, 10, 0);
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Deák Ferenc Tér")!, 8, 4);
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Kálvin Tér")!, 5, 2);

            return busz.SzallitottUtasokMegalloig(megalloNev);
        }

        [Test]
        public void SzallitottUtasokMegalloigUjraErintettMegallo()
        {
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Örs Vezér Tér")!, 10, 0);
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Deák Ferenc Tér")!, 8, 4);
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Kálvin Tér")!, 5, 2);
            busz.MegalloUtasCsere(megallok.MegalloNevAlapjan("Deák Ferenc Tér")!, 3, 0);   // másodszor is a Deáknál

            // az utolsó Deák-os megállásig mindenki számít: 10 + 8 + 5 + 3
            Assert.That(busz.SzallitottUtasokMegalloig("Deák Ferenc Tér"), Is.EqualTo(26));
            Assert.That(busz.EddigSzallitottUtasokLetszama(), Is.EqualTo(26));
        }

        [Test]
        public void SzallitottUtasokMegalloigUjBusz()
        {
            Assert.That(busz.SzallitottUtasokMegalloig("Deák Ferenc Tér"), Is.Null);
        }

        [Test]
        public void MegalloknakNevAlapjanKeresese()
        {
            Megallo? talalt = megallok.MegalloNevAlapjan("Astoria");

            Assert.That(talalt, Is.Not.Null);
            Assert.That(talalt!.MegallobanVarakozoEmberek, Is.EqualTo(10));
            Assert.That(megallok.MegalloNevAlapjan("Nincs Ilyen"), Is.Null);
            Assert.That(megallok.MegalloHelyek.Count, Is.EqualTo(7));
        }

        [Test]
        public void UresMegallokLista()
        {
            Megallok uresMegallok = new Megallok(new Dictionary<string, int>());

            Assert.That(uresMegallok.MegalloHelyek.Count, Is.EqualTo(0));
            Assert.That(uresMegallok.ErvenytelenMegallo(), Is.False);
            Assert.That(uresMegallok.MegalloNevAlapjan("Astoria"), Is.Null);
        }

        [Test]
        public void ErvenytelenMegalloNincsAlapesetben()
        {
            Assert.That(megallok.ErvenytelenMegallo(), Is.False);
        }

        [Test]
        public void BuszflottaBetoltese()
        {
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123", "normal;40;DEF-456", "csuklos;60;GHI-789" });

            Assert.That(flotta.Buszflotta.Count, Is.EqualTo(3));
            Assert.That(flotta.BuszRendszamAlapjan("DEF-456")!.Ferohely, Is.EqualTo(40));
            Assert.That(flotta.BuszRendszamAlapjan("DEF-456")!.Meret, Is.EqualTo("normal"));
            Assert.That(flotta.BuszRendszamAlapjan("GHI-789")!.SzabadFerohely, Is.EqualTo(60));
        }

        [Test]
        public void BuszflottaEgyetlenBusszal()
        {
            // legalább 1 buszt kell tartalmaznia, az 1 még megfelel
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123" });

            Assert.That(flotta.Buszflotta.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuszflottaUresListaKivetel()
        {
            Assert.Throws<UresBuszflottaException>(() => new Buszok(new List<string>()));
        }

        [Test]
        public void BuszflottaAzonosRendszamKivetel()
        {
            var sorok = new List<string> { "miniBusz;20;ABC-123", "normal;40;DEF-456", "csuklos;60;ABC-123" };

            Assert.Throws<AzonosRendszamException>(() => new Buszok(sorok));
        }

        [Test]
        public void BuszflottaKetszerUgyanazASor()
        {
            var sorok = new List<string> { "miniBusz;20;ABC-123", "miniBusz;20;ABC-123" };

            Assert.Throws<AzonosRendszamException>(() => new Buszok(sorok));
        }

        [Test]
        public void BuszflottaRosszFerohelyFormatum()
        {
            var sorok = new List<string> { "miniBusz;sok;ABC-123" };

            Assert.Throws<FormatException>(() => new Buszok(sorok));
        }

        [Test]
        public void BuszflottaKeresesNemLetezoRendszam()
        {
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123" });

            Assert.That(flotta.BuszRendszamAlapjan("XXX-000"), Is.Null);
        }

        [Test]
        public void BuszflottaOsszesSzallitottUtas()
        {
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123", "normal;40;DEF-456" });
            Megallo elsoMegallo = megallok.MegalloNevAlapjan("Örs Vezér Tér")!;   // 20-an várnak

            flotta.BuszRendszamAlapjan("ABC-123")!.MegalloUtasCsere(elsoMegallo, 10, 0);
            flotta.BuszRendszamAlapjan("DEF-456")!.MegalloUtasCsere(elsoMegallo, 6, 0);

            Assert.That(flotta.OsszesSzallitottUtas(), Is.EqualTo(16));
        }

        [Test]
        public void BuszflottaOsszesSzallitottUtasEgyetlenMegalloSemVolt()
        {
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123", "normal;40;DEF-456" });

            Assert.That(flotta.OsszesSzallitottUtas(), Is.EqualTo(0));
        }

        [Test]
        public void BuszflottaMegalloigSzallitottUtasokBuszonkent()
        {
            Buszok flotta = new Buszok(new List<string> { "miniBusz;20;ABC-123", "normal;40;DEF-456" });
            Megallo ors = megallok.MegalloNevAlapjan("Örs Vezér Tér")!;
            Megallo deak = megallok.MegalloNevAlapjan("Deák Ferenc Tér")!;

            // az első busz végigmegy, a második csak az első megállóig jut el
            Busz elso = flotta.BuszRendszamAlapjan("ABC-123")!;
            elso.MegalloUtasCsere(ors, 10, 0);
            elso.MegalloUtasCsere(deak, 5, 3);
            flotta.BuszRendszamAlapjan("DEF-456")!.MegalloUtasCsere(ors, 6, 0);

            var deaknal = flotta.SzallitottUtasokMegalloig("Deák Ferenc Tér");
            var orsnel = flotta.SzallitottUtasokMegalloig("Örs Vezér Tér");

            Assert.That(deaknal.Count, Is.EqualTo(1));
            Assert.That(deaknal["ABC-123"], Is.EqualTo(15));
            Assert.That(orsnel.Count, Is.EqualTo(2));
            Assert.That(orsnel["ABC-123"], Is.EqualTo(10));
            Assert.That(orsnel["DEF-456"], Is.EqualTo(6));
            Assert.That(flotta.SzallitottUtasokMegalloig("Astoria").Count, Is.EqualTo(0));
        }
    }
}

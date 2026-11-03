using Urhajok_LIB;

namespace Urhajok_Tests
{
    public class Tests
    {
        Urparancsnoksag up;
        UrhajoOsztaly felfedezo;
        UrhajoTipus felderito;
        Urhajo kutato11;
        LegenysegiTag john;

        [SetUp]
        public void Setup()
        {
            up = new Urparancsnoksag();
            felfedezo = new UrhajoOsztaly("felfedező");
            felderito = new UrhajoTipus("felderítő", "mélységi felderítő űrhajó, mélyűri felfedezésekhez", new List<Kepzettseg> { new Kepzettseg("navigáció", 2) });
            kutato11 = new Urhajo("Kutató 11", felderito, felfedezo, 2150, 3);
            john = new LegenysegiTag("John Smith", "amerikai", new DateOnly(2001, 11, 2), "férfi", new List<Kepzettseg> { new Kepzettseg("diplomácia", 1), new Kepzettseg("navigáció", 2) });
        }

        static LegenysegiTag Navigator(string nev, int szint) => new LegenysegiTag(nev, "orosz", new DateOnly(2001, 2, 11), "nő", new List<Kepzettseg> { new Kepzettseg("navigáció", szint) });
        static UrhajoTipus KovetelmenyNelkuliTipus() => new UrhajoTipus("millenium falcon", "x-wing", new List<Kepzettseg>());

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Osztaly_NevKotelezo(string? nev)
        {
            Assert.Throws<ArgumentException>(() => new UrhajoOsztaly(nev!));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Kepzettseg_NevKotelezo(string? nev)
        {
            Assert.Throws<ArgumentException>(() => new Kepzettseg(nev!, 1));
        }

        [Test]
        public void Tipus_ElvartKepzettsegekLehetUres()
        {
            Assert.That(KovetelmenyNelkuliTipus().ElvartKepzettsegek, Is.Empty);
        }

        [Test]
        public void Tipus_ElvartKepzettsegekMegmaradnak()
        {
            Assert.That(felderito.Nev, Is.EqualTo("felderítő"));
            Assert.That(felderito.ElvartKepzettsegek, Has.Count.EqualTo(1));
            Assert.That(felderito.ElvartKepzettsegek[0].Nev, Is.EqualTo("navigáció"));
            Assert.That(felderito.ElvartKepzettsegek[0].Szint, Is.EqualTo(2));
        }

        [Test]
        public void Urhajo_AdatokBeallitodnak()
        {
            Assert.That(kutato11.Nev, Is.EqualTo("Kutató 11"));
            Assert.That(kutato11.Osztaly.Nev, Is.EqualTo("felfedező"));
            Assert.That(kutato11.Tipus.Nev, Is.EqualTo("felderítő"));
            Assert.That(kutato11.GyartasiEv, Is.EqualTo(2150));
            Assert.That(kutato11.Ferohely, Is.EqualTo(3));
            Assert.That(kutato11.Legenyseg, Is.Empty);
            Assert.That(kutato11.SzabadHely, Is.EqualTo(3));
        }

        [Test]
        public void LegenysegiTag_KepzettsegSzintMegadottKepzettsegre()
        {
            Assert.That(john.KepzettsegSzint("navigáció"), Is.EqualTo(2));
            Assert.That(john.KepzettsegSzint("diplomácia"), Is.EqualTo(1));
        }

        [Test]
        public void LegenysegiTag_NemLetezoKepzettsegSzintje0()
        {
            Assert.That(john.KepzettsegSzint("pilóta"), Is.EqualTo(0));
        }

        [Test]
        public void Felvesz_BekerulAHajoLegenysegebeEsCsokkentiASzabadHelyet()
        {
            var eredmeny = kutato11.Felvesz(john);

            Assert.That(eredmeny, Is.True);
            Assert.That(kutato11.Legenyseg, Does.Contain(john));
            Assert.That(kutato11.SzabadHely, Is.EqualTo(2));
        }

        [Test]
        public void Felvesz_TeliHajonKivetel()
        {
            var kicsi = new Urhajo("Kicsi", felderito, felfedezo, 2100, 1);
            kicsi.Felvesz(Navigator("Első", 1));

            Assert.Throws<InvalidOperationException>(() => kicsi.Felvesz(Navigator("Második", 1)));
            Assert.That(kicsi.Legenyseg, Has.Count.EqualTo(1));
        }

        [Test]
        public void Levesz_JelenLevoTagotEltavolit()
        {
            kutato11.Felvesz(john);

            Assert.That(kutato11.Levesz(john), Is.True);
            Assert.That(kutato11.Legenyseg, Is.Empty);
            Assert.That(kutato11.SzabadHely, Is.EqualTo(3));
        }

        [Test]
        public void Levesz_NemLevoTagraFalse()
        {
            Assert.That(kutato11.Levesz(john), Is.False);
        }

        [Test]
        public void HajoFelvetele_AzonosNevuHajoNemVehetoFel()
        {
            up.HajoFelvetele(kutato11);
            var masik = new Urhajo("Kutató 11", felderito, felfedezo, 2160, 2);

            Assert.Throws<InvalidOperationException>(() => up.HajoFelvetele(masik));
            Assert.That(up.Urhajok, Has.Count.EqualTo(1));
        }

        [Test]
        public void LegenysegFelvetele_UgyanazATagKetszerNemVehetoFel()
        {
            up.LegenysegFelvetele(john);

            Assert.Throws<InvalidOperationException>(() => up.LegenysegFelvetele(john));
            Assert.That(up.SzabadLegenyseg, Has.Count.EqualTo(1));
        }

        [Test]
        public void Hozzarendel_AHajoLegenysegebeKerulASzabadokKozulKi()
        {
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(john);

            up.Hozzarendel(john, kutato11);

            Assert.That(kutato11.Legenyseg, Does.Contain(john));
            Assert.That(up.SzabadLegenyseg, Does.Not.Contain(john));
        }

        [Test]
        public void Hozzarendel_TeliHajoraNemMegyEsATagSzabadMarad()
        {
            var kicsi = new Urhajo("Kicsi", felderito, felfedezo, 2100, 1);
            up.HajoFelvetele(kicsi);
            var elso = Navigator("Első", 1);
            var masodik = Navigator("Második", 1);
            up.LegenysegFelvetele(elso);
            up.LegenysegFelvetele(masodik);
            up.Hozzarendel(elso, kicsi);

            Assert.Throws<InvalidOperationException>(() => up.Hozzarendel(masodik, kicsi));

            Assert.That(up.SzabadLegenyseg, Does.Contain(masodik));
            Assert.That(kicsi.Legenyseg, Has.Count.EqualTo(1));
        }

        [Test]
        public void Hozzarendel_EgyTagEgyszerreCsakEgyHajohozTartozhat()
        {
            var masodik = new Urhajo("Második", KovetelmenyNelkuliTipus(), felfedezo, 2140, 4);
            up.HajoFelvetele(kutato11);
            up.HajoFelvetele(masodik);
            up.LegenysegFelvetele(john);
            up.Hozzarendel(john, kutato11);

            Assert.Throws<InvalidOperationException>(() => up.Hozzarendel(john, masodik));

            Assert.That(masodik.Legenyseg, Is.Empty);
            Assert.That(kutato11.Legenyseg, Does.Contain(john));
        }

        [Test]
        public void Hozzarendel_NemFelvettTagNemRendelhetoHozza()
        {
            up.HajoFelvetele(kutato11);

            Assert.Throws<InvalidOperationException>(() => up.Hozzarendel(john, kutato11));
            Assert.That(kutato11.Legenyseg, Is.Empty);
        }

        [Test]
        public void Visszavon_ATagVisszakerulASzabadokKoze()
        {
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(john);
            up.Hozzarendel(john, kutato11);

            up.Visszavon(john);

            Assert.That(kutato11.Legenyseg, Is.Empty);
            Assert.That(up.SzabadLegenyseg, Does.Contain(john));
            Assert.That(kutato11.SzabadHely, Is.EqualTo(3));
        }

        [Test]
        public void Visszavon_NemHozzarendeltTagnalKivetel()
        {
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(john);

            Assert.Throws<InvalidOperationException>(() => up.Visszavon(john));
        }

        [Test]
        public void Athelyezes_VisszavonasUtanAzUjHajohozRendelheto()
        {
            var kutato12 = new Urhajo("Kutató 12", felderito, felfedezo, 2160, 2);
            up.HajoFelvetele(kutato11);
            up.HajoFelvetele(kutato12);
            up.LegenysegFelvetele(john);
            up.Hozzarendel(john, kutato11);

            up.Visszavon(john);
            up.Hozzarendel(john, kutato12);

            Assert.That(kutato11.Legenyseg, Is.Empty);
            Assert.That(kutato12.Legenyseg, Does.Contain(john));
            Assert.That(up.SzabadLegenyseg, Is.Empty);
        }

        [Test]
        public void Indithato_PontosanElegSzintnelIgen()
        {
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(john); // navigáció: 2, pont annyi, amennyi kell

            up.Hozzarendel(john, kutato11);

            Assert.That(kutato11.Indithato, Is.True);
        }

        [Test]
        public void Indithato_KevesSzintnelNem()
        {
            var kezdo = Navigator("Kezdő", 1);
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(kezdo);

            up.Hozzarendel(kezdo, kutato11);

            Assert.That(kutato11.Indithato, Is.False);
        }

        [Test]
        public void Indithato_TobbTagSzintjeOsszeadodik()
        {
            var a = Navigator("A", 1);
            var b = Navigator("B", 1);
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(a);
            up.LegenysegFelvetele(b);

            up.Hozzarendel(a, kutato11);
            Assert.That(kutato11.Indithato, Is.False);

            up.Hozzarendel(b, kutato11);
            Assert.That(kutato11.Indithato, Is.True);
        }

        [Test]
        public void Indithato_VisszavonasUtanMarNem()
        {
            up.HajoFelvetele(kutato11);
            up.LegenysegFelvetele(john);
            up.Hozzarendel(john, kutato11);
            Assert.That(kutato11.Indithato, Is.True);

            up.Visszavon(john);

            Assert.That(kutato11.Indithato, Is.False);
        }

        [Test]
        public void Indithato_MindenElvartKepzettsegetTeljesitenieKell()
        {
            var tipus = new UrhajoTipus("diplomáciai", "tárgyalóhajó", new List<Kepzettseg>
            {
                new Kepzettseg("navigáció", 1),
                new Kepzettseg("diplomácia", 2)
            });
            var hajo = new Urhajo("Béke 1", tipus, felfedezo, 2170, 4);
            up.HajoFelvetele(hajo);
            up.LegenysegFelvetele(john); // diplomácia: 1, navigáció: 2
            up.Hozzarendel(john, hajo);

            Assert.That(hajo.Indithato, Is.False); // diplomáciából még kevés

            var diplomata = new LegenysegiTag("hitlerbá", "kínai", new DateOnly(1889, 4, 20), "férfi", new List<Kepzettseg> { new Kepzettseg("diplomácia", 100) });
            up.LegenysegFelvetele(diplomata);
            up.Hozzarendel(diplomata, hajo);

            Assert.That(hajo.Indithato, Is.True);
        }

        [Test]
        public void Indithato_KovetelmenyNelkuliTipusLegenysegNelkulIsIndithato()
        {
            var hajo = new Urhajo("death star", KovetelmenyNelkuliTipus(), felfedezo, 2140, 4);

            Assert.That(hajo.Indithato, Is.True);
        }
    }
}
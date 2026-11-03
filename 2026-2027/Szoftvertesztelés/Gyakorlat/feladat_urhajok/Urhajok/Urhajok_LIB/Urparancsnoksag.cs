using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajok_LIB
{
    public class Urparancsnoksag
    {
        readonly List<Urhajo> urhajok = new List<Urhajo>();
        readonly List<LegenysegiTag> szabadLegenyseg = new List<LegenysegiTag>();

        public List<Urhajo> Urhajok => urhajok;
        public List<LegenysegiTag> SzabadLegenyseg => szabadLegenyseg;

        public void HajoFelvetele(Urhajo urhajo)
        {
            if (urhajok.Any(x => x.Nev == urhajo.Nev)) throw new InvalidOperationException($"Már van ilyen nevű űrhajó!");

            urhajok.Add(urhajo);
        }

        public void LegenysegFelvetele(LegenysegiTag legenysegiTag)
        {
            if (szabadLegenyseg.Contains(legenysegiTag) || urhajok.Any(x => x.Legenyseg.Contains(legenysegiTag))) throw new InvalidOperationException($"A legénységi tag már nyilvántartott!");

            szabadLegenyseg.Add(legenysegiTag);
        }

        public void Hozzarendel(LegenysegiTag tag, Urhajo hajo)
        {
            if (!urhajok.Contains(hajo)) throw new InvalidOperationException("Az űrhajó nem tartozik az Űrparancsnoksághoz!");

            // először a hely ellenőrzése, hogy hiba esetén a tag a szabadok között maradjon
            if (!szabadLegenyseg.Contains(tag)) throw new InvalidOperationException($"{tag.Nev} nem szabad: vagy már hajóhoz van rendelve, vagy nem ismert.");

            hajo.Felvesz(tag);
            szabadLegenyseg.Remove(tag);
        }

        public void Visszavon(LegenysegiTag legenysegiTag)
        {
            var hajo = urhajok.FirstOrDefault(x => x.Legenyseg.Contains(legenysegiTag)) ?? throw new InvalidOperationException($"{legenysegiTag.Nev} egyik hajóhoz sincs hozzárendelve.");

            hajo.Levesz(legenysegiTag);
            szabadLegenyseg.Add(legenysegiTag);
        }
    }
}

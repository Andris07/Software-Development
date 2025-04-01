using System;
using System.Collections.Generic;
using System.Linq;

namespace KincsesLada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Találtál egy kincsesládát!");
            List<IKincs> kincsek = new List<IKincs>();
            for (int i = 0; i < 10; i++)
            {
                kincsek.Add(new KincsFactory().Create());
            }
            Console.WriteLine("A kincsesláda tartalma: ");
            foreach (var item in kincsek)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.WriteLine($"A kincsesláda értéke: {kincsek.Sum(x=>x.Ertek)}");
            Console.WriteLine("A kincsesláda tartalma név szerint csoportosítva: ");
            foreach (var item in kincsek.GroupBy(x => x.Nev).OrderBy(x => x.Key))
            {
                Console.WriteLine($"\t{item.Key}: {item.Count()} db");
            }
            Console.WriteLine("A kincsesláda tartalma típus szerint csoportosítva: ");
            foreach (var item in kincsek.GroupBy(x=>x.Tipus).OrderBy(x=>x.Key))
            {
                Console.WriteLine($"\t{item.Key}: {item.Count()} db");
            }
        }
    }
}

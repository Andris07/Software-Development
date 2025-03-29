using Static_PL;

Ember e1 = new("Gipsz Jakab", 2000, 150000);
// e1.Nev = "f"; A Nev property private set, ő csak az osztályon belül állítható
// e1.SzuletesiEv = 2000; Csak lekérdezhető property, itt nem állítható
Console.WriteLine(e1.Info());
// Console.WriteLine(e1.MAXELETKOR); A példányból nem érhető el az osztály konstans mezője
Console.WriteLine($"A maximális életkor: {Ember.MAXELETKOR}");
// Console.WriteLine(e1.MinimalisFizetes); A példányból nem érhető el a statikus mező / tulajdonság
Console.WriteLine($"A minimális fizetés értéke: {Ember.MinimalisFizetes}");

if (!e1.NevValtoztatas("Tigris")) Console.WriteLine("A névnek legalább egy szóközt kell tartalmaznia.");
Console.WriteLine(e1.Info());

if (!e1.NevValtoztatas("Csíkos Tigris")) Console.WriteLine("A névnek legalább egy szóközt kell tartalmaznia.");
Console.WriteLine(e1.Info());

Ember e2 = new("Teszt Elek", 1970, 300000);
Console.WriteLine(e2.Info());
// e2.MinimalisFizetesValtoztatas(10000); A példányból nem érhető el a statikus mező / tulajdonság
Ember.MinimalisFizetesValtoztatas(20000);
Console.WriteLine($"A minimális fizetés: {Ember.MinimalisFizetes}");
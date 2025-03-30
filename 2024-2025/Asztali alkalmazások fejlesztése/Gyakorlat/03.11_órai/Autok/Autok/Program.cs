using Autok;

Auto auto1 = new();
Auto auto2 = new("Ferrari", "Tigris", 600);

Console.WriteLine(auto1.Log());
auto1.SebessegMeres();
Console.WriteLine(auto1.Log());
auto1.Vezeto = "Leopárd";
Console.WriteLine(auto1.Log());
for (int i = 0; i < 10; i++)
    auto1.SebessegMeres();
Console.WriteLine(auto1.Log());

Console.WriteLine(auto2.Log());
for (int i = 0; i < 10; i++)
    auto2.SebessegMeres();
Console.WriteLine(auto2.Log());

Console.WriteLine(auto1.Osszehasonlitas(auto1));
Console.WriteLine(auto1.Osszehasonlitas(auto2));

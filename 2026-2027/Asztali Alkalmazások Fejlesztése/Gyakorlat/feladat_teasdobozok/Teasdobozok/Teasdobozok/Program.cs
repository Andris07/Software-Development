using Teasdobozok_LIB;

Filterek filterek = new (File.ReadAllLines("filterek.txt").Skip(1));

Console.WriteLine("Elérhető gyógynövény filterek: ");
foreach(var filter in filterek.Gyogynovenyek)
{
    Console.WriteLine(filter);
}
Console.WriteLine();

List<TeasDoboz> dobozok = new List<TeasDoboz>();
List<string> hibaLista = new List<string>();

foreach(var fájlSor in File.ReadAllLines("dobozok.txt").Skip(1))
{
    try
    {
        var doboz = DobozFactory.Factory(fájlSor, filterek);
        dobozok.Add(doboz);
    }
    catch (HibasAzonositoException ex)
    {
        hibaLista.Add($"{ex.Message} ({fájlSor})");
    }
}
File.WriteAllLines("hibalista.txt", hibaLista);

Console.WriteLine("Elkészített teásdobozok: ");
foreach (var doboz in dobozok)
{
    Console.WriteLine(doboz);
}
Console.WriteLine();
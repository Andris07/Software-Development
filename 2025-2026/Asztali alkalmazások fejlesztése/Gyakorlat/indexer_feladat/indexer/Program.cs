using indexer_LIB;

School school = new School();

school.addSubject("Magyar Irodalom", 1);
school.addSubject("Magyar Nyelvtan", 2);
school.addSubject("Magyar Történelem", 3);
school.addSubject("Idegen Nyelv", 4);
school.addSubject("Matematika", 5);

var Anna = new Dictionary<Subject, List<int>>
{
    [school["Magyar Irodalom"]] = new List<int> { 5, 4, 5, 3, 5, 4, 5 },
    [school["Magyar Nyelvtan"]] = new List<int> { 5, 4, 3, 5, 5, 4, 5 },
    [school["Magyar Történelem"]] = new List<int> { 3, 4, 4, 3, 5 },
    [school["Idegen Nyelv"]] = new List<int> { 5, 4, 4, 5, 5 },
    [school["Matematika"]] = new List<int> { 1, 2, 3 }
};

var Andrew = new Dictionary<Subject, List<int>>
{
    [school["Magyar Irodalom"]] = new List<int> { 5, 4, 3, 5, 5, 4, 5 },
    [school["Magyar Nyelvtan"]] = new List<int> { 5, 4, 5, 3, 5, 4, 5 },
    [school["Magyar Történelem"]] = new List<int> { 5, 4, 4, 5, 5 },
    [school["Idegen Nyelv"]] = new List<int> { 3, 4, 4, 3, 5 },
    [school["Matematika"]] = new List<int> { 5, 4, 3 }
};

var Zeus = new Dictionary<Subject, List<int>>
{
    [school["Magyar Irodalom"]] = new List<int> { 2, 2, 2, 2, 2, 2, 2 },
    [school["Magyar Nyelvtan"]] = new List<int> { 2, 2, 2, 2, 2, 2, 2 },
    [school["Magyar Történelem"]] = new List<int> { 2, 2, 2, 2, 2 },
    [school["Idegen Nyelv"]] = new List<int> { 2, 2, 2, 2, 2 },
    [school["Matematika"]] = new List<int> { 2, 2, 2 }
};

school.addStudent("Anna", 1, Anna);
school.addStudent("Andrew", 2, Andrew);
school.addStudent("Zeus", 3, Zeus);

Console.WriteLine("Students: ");
Console.WriteLine($"\tName: {school[1].Name}\t(ID: {school[1].ID})");
Console.WriteLine($"\tName: {school[2].Name}\t(ID: {school[2].ID})");
Console.WriteLine($"\tName: {school[3].Name}\t(ID: {school[3].ID})");

school[0].addGradeToSubject(school["mathematics"], new List<int> { 3, 5 });
Console.WriteLine($"Anna's added Mathematics grades: {string.Join(", ", Anna[school["Idegen nyelv"]])}");

school[1].addGradeToSubject(school["mathematics"], new List<int> { 1, 2 });
Console.WriteLine($"Andrew's added Mathematics grades: {string.Join(", ", Anna[school["Matematika"]])}");

school[3].addGradeToSubject(school["mathematics"], new List<int> { 2, 2 });
Console.WriteLine($"Zeus's added Mathematics grades: {string.Join(", ", Anna[school["Matematika"]])}");

/*
 * Rossz
try
{
    var possibleStudent = school[271000];
    Console.WriteLine($"\tName: {possibleStudent.Name}\t(ID: {possibleStudent.ID})");
}
catch (InvalidOperationException)
{
    Console.WriteLine("No student found!");
}
catch (ArgumentNullException)
{
    Console.WriteLine("No student found!");
}

try
{
    var possibleSubject = school["Cookie"];
    Console.WriteLine($"\tName: {possibleSubject.Name}\t(ID: {possibleSubject.ID})");
}
catch (InvalidOperationException)
{
    Console.WriteLine("No subject found!");
}
catch (ArgumentNullException)
{
    Console.WriteLine("No subject found!");
}
*/
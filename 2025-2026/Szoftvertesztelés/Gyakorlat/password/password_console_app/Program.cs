using password_class_lib;

Console.Write("Add meg a jelszót: ");
string password = Console.ReadLine();

bool isValid = Password.IsValid(password);

if (isValid)
{
    Console.WriteLine("A jelszó megfelel a követelményeknek.");
}
else
{
    Console.WriteLine("A jelszó NEM felel meg a követelményeknek.");
}

Console.WriteLine("Nyomj meg egy billentyűt a kilépéshez...");
Console.ReadKey();

// MANUÁLIS TESZTEK ÉS EREDMÉNYEK

// ALAP MŰKÖDÉS TESZTELÉSE
// Kutya1234            megfelelt
// Abc123               megfelelt
// Aáb123               megfelelt
// Áab123               megfelelt

// KISBETŰK TESZTELÉSE
// KUTYA1234            nem felelt meg
// ÁRVÍZ123             nem felelt meg

// NAGYBETŰK TESZTELÉSE
// kutya1234            nem felelt meg
// kutyám1234           nem felelt meg

// SZÁM TESZTELÉSE
// Kutyaabcd            nem felelt meg
// Kutyámabc            nem felelt meg

// HOSSZ TESZTELÉSE
// Ku1a$                nem felelt meg
// Áb1$                 nem felelt meg

// SPECIÁLIS KARAKTEREK TESZTELÉSE
// Kut$am1234           megfelelt
// Kuty@123             megfelelt

// UNICODE KARAKTEREK TESZTELÉSE
// Kutyám@123           megfelelt
// ÁrvÍz$123            megfelelt

// NULL TESZTELÉSE
// ""                   nem felelt meg
// "     "              nem felelt meg

// PÁR RANDOM TESZT
// 123456               nem felelt meg
// KUTYAA               nem felelt meg
// kutyaa               nem felelt meg
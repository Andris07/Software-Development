// See https://aka.ms/new-console-template for more information
using Kor_PL;

Kor kor = new Kor();
Console.WriteLine($"A kör sugara: {kor.Sugar} kerülete: {kor.Kerulet()} területe: {kor.Terulet()}");
Console.WriteLine(kor.Info());

kor.Sugar = 0;
Console.WriteLine("0-ra állított sugár");
Console.WriteLine(kor.Info());

kor.Sugar = -6;
Console.WriteLine("-6-ra állított sugár");
Console.WriteLine(kor.Info());

kor.Sugar = 6;
Console.WriteLine("6-ra állított sugár");
Console.WriteLine(kor.Info());

Kor kor2 = new Kor(0);
Console.WriteLine("0-ra állított sugár");
Console.WriteLine(kor2.Info());

kor2 = new Kor(-6);
Console.WriteLine("-6-ra állított sugár");
Console.WriteLine(kor2.Info());

kor2 = new Kor(6);
Console.WriteLine("6-ra állított sugár");
Console.WriteLine(kor2.Info());
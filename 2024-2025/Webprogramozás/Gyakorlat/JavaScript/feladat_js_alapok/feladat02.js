`use strict`;

// 2. feladat
console.log(`2. feladat: `);

for (let i = 1; i <= 100; i++)
{
    if (i%2 == 0)
    {
        console.log(`${i}: páros`);
    }
    else
    {
        console.log(`${i}: páratlan`);
    }
}

// 3. feladat
let a = Number(window.prompt(`3. feladat: Kérem adja meg az első számot: `));
let b = Number(window.prompt(`3. feladat: Kérem adja meg a második számot: `));

window.alert(`3. feladat: ${a+b}`);

// 4. feladat
let x;
let y;

do
{
    x = Number(window.prompt(`4. feladat: Kérem adja meg az első számot: `));
} while (isNaN(x));
do
{
    y = Number(window.prompt(`4. feladat: Kérem adja meg a második számot: `));
} while (isNaN(y));

window.alert(`4. feladat: ${x+y}`);

// 5. feladat
const PI = 3.14;

// 6. feladat
let radius;

do
{
    radius = Number(window.prompt(`6. feladat: Kérem adja meg a kör sugarát: `))
} while (isNaN(radius));

console.log(`6. a feladat: `);
console.log(`K: ${2 * radius * PI}`);
console.log(`T: ${radius * radius * PI}`);

// 7. feladat
let month;

do
{
    month = Number(window.prompt(`7. feladat: Kérem adja meg a hónap sorszámát (1-12): `));

    if (isNaN(month) || month < 1 || month > 12)
    {
        window.alert(`7. a feladat: Nem ismerem ezt a hónapot!`);
    }
} while (isNaN(month) || month < 1 ||  month > 12);

if (month > 2 && month < 6)
{
    window.alert(`7. a feladat: Az adott hónap a tavaszhoz tartozik`);
}
else if (month > 5 && month < 9)
{
    window.alert(`7. a feladat: Az adott hónap a nyárhoz tartozik`);
}
else if (month > 8 && month < 12)
{
    window.alert(`7. a feladat: Az adott hónap az őszhöz tartozik`);
}
else
{
    window.alert(`7. a feladat: Az adott hónap a télhez tartozik`);
}

// 8. feladat
let min;
let max;

do
{
    min = Number(window.prompt(`8. feladat: Kérem adja meg az alsó értéket: `));
} while (isNaN(min));
do
{
    max = Number(window.prompt(`8. feladat: Kérem adja meg a felső értéket: `));
} while (isNaN(max) || max <= min);

let quantity = max - min + 1;
let sum = 0;
let multiplication = 1;

for (let i = min; i <= max; i++)
{
    sum += i;
    multiplication *= i;
}

let average = sum / quantity;

console.log(`8. feladat: `);
console.log(`Számok száma: ${quantity}`);
console.log(`Számok összege: ${sum}`);
console.log(`Számok átlaga: ${average}`);
console.log(`Számok szorzata: ${multiplication}`);
`use strict`;

// 2. feladat
console.log(`2. feladat: Hello World!`);

// 3. feladat
let familyName = `Laczkovics`;

console.log(`3. a feladat: ${familyName}`);
console.log(`3. b feladat: ${typeof(familyName)}`);

// 4. feladat
let givenName = `András Gergő`;

// 5. feladat
let fullName = familyName + ` ` + givenName;

console.log(`5. feladat: ${fullName}`);

// 6. feladat
let a = 10;
let b = 10;

let value;
if (a == b)
{
    value = `A két változó értéke egyezik`;
}
else
{
    value = `A két változó értéke nem egyezik`;
}
console.log(`6. a feladat: ${value}`);

let valueType;
if (a === b)
{
    valueType = `A két változó értéke és típusa egyezik`;
}
else
{
    valueType = `A két változó értéke és típusa nem egyezik`;
}
console.log(`6. b feladat: ${valueType}`);

// 7. feladat
console.log(`7. a feladat: ${a + b}`);
console.log(`7. b feladat: ${a - b}`);
console.log(`7. c feladat: ${a * b}`);
console.log(`7. d feladat: ${a / b}`);

// 8. feladat
let c = 100;

console.log(`8. a feladat: ${(a + c) - b}`);

// 9. feladat
console.log(`9. feladat: `);

for (let i = 1; i <= 10; i++)
{
    console.log(i);
}
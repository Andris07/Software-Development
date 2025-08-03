`use strict`;

let num;
let nums = [];

do
{
    num = Number(window.prompt(`Kérem adjon meg egy számot: `));
    if (!isNaN(num))
    {
        nums.push(num);
    }
} while (!isNaN(num));

let sum = 0;

for (let i = 0; i < nums.length; i++)
{
    sum += nums[i];
}

let avg = Math.round((sum / nums.length) * 100) / 100;

console.log(`A számok összege: ${sum}`);
console.log(`A számok átlaga: ${avg.toFixed(2)}`);
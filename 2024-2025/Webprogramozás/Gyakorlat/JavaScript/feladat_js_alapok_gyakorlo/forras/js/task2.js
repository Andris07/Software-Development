`use strict`;

const VAT = 0.27;

let name = window.prompt(`Kérem adja meg az árucikk nevét: `);
let price;

do
{
    price = Number(window.prompt(`Kérem adja meg az árucikk árát: `));
} while (isNaN(price));

price = Math.round(price + price * VAT);

console.log(`A(z) ${name} ára ÁFÁ-val: ${price} forint`);
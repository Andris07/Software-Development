`use strict`;

const nums = [15, 28, 42, 95, 33];

function getMinMax(tomb = [], tipus)
{
    if (tipus == `min`)
    {
        return Math.min(...tomb);
    }
    else if (tipus == `max`)
    {
        return Math.max(...tomb);
    }
    else
    {
        return `Kérem helyes bemenetet adjon meg`;
    }
}

console.log(`Legkisebb szám: ${getMinMax(nums, `min`)}`);
console.log(`Legnagyobb szám: ${getMinMax(nums, `max`)}`);
console.log(`Hibás bemenet: ${getMinMax(nums, `minmax`)}`);
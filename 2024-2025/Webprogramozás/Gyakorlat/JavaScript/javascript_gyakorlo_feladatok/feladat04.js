`use strict`;

const nums = [15, 28, 42, 95, 33];

console.log(`Átlag: ${Math.round(nums.reduce((x, y) => x + y) / nums.length)}`);
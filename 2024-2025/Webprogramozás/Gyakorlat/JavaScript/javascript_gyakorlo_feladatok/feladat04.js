`use strict`;

const nums = [15, 28, 42, 95, 33];

const avg = Math.round(nums.reduce((x, y) => x + y) / nums.length);

console.log(`Átlag: ${avg}`);
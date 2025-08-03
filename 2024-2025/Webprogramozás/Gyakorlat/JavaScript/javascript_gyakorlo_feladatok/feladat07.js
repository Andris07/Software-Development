`use strict`;

const nums = [15, 28, 42, 95, 33];

const low = nums.filter((x) => x < 30);
const mid = nums.filter((x) => 30 <= x && x < 70);
const high = nums.filter((x) => 70 <= x);

console.log(low);
console.log(mid);
console.log(high);
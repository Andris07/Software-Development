`use strict`;

const nums = [15, 28, 42, 95, 33];

const oddNums = nums.filter((x) => x%2 != 0);
const evenNums = nums.filter((x) => x%2 == 0);

console.log(`Páros számok: ${evenNums}`);
console.log(`Páratlan számok: ${oddNums}`);
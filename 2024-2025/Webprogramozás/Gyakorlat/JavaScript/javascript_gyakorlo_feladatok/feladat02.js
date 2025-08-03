`use strict`;

const nums = [15, 28, 42, 95, 33];

const numsRoot = [];

for (let i = 0; i < nums.length; i++)
{
    numsRoot[i] = String(Math.round(Math.sqrt(nums[i]) * 100) / 100);
}

console.log(numsRoot);
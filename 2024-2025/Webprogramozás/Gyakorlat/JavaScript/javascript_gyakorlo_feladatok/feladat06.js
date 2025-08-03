`use strict`;

const nums = [15, 28, 42, 95, 33];

const numsIndexPower = [];

for (let i = 1; i <= nums.length; i++)
{
    numsIndexPower[i - 1] = Math.pow(nums[i - 1], i);
}

console.log(numsIndexPower);
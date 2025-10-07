/**
 * A paraméterben megadott tömb alapján számold ki, 
 * hogy a tömben található szavaknak, mekkora az átlagos 
 * hosszuk. Az átlag a függvény visszatérési értéke legyen.
 */
function task01(arr){
    let averageWordLength = 0;

    /*
    for (let i = 0; i < arr.length; i++)
    {
        averageWordLength += arr[i].length;
    }
    */

    for (const word of arr)
    {
        averageWordLength += word.length;
    }

    averageWordLength /= arr.length;
    return averageWordLength;
}

/** 
 * A paraméterben kapott tömbben található számokat alakítsd át 
 * úgy, hogy minden számra vedd az abszolút értékét és oszd el hárommal,
 * ezután az eredményt kerekítsd. Az így kapott tömb legyen a függvény visszatérési értéke. 
 */
function task02(arr){
    let modifiedArr = [];
    let i = 0;

    /*
    for (let i = 0; i < arr.length; i++)
    {
        modifiedArr[i] = Math.abs(arr[i]);
        modifiedArr[i] /= 3;
        modifiedArr[i] = Math.round(modifiedArr[i], 2);
    }
    */

    for (let num of arr)
    {
        modifiedArr[i] = Math.abs(num);
        modifiedArr[i] /= 3;
        modifiedArr[i] = Math.round(modifiedArr[i], 2);
        i++;
    }

    return modifiedArr;
}

/**
 * Keresd meg azt az utolsó elemet a paraméterként kapott tömbben,
 * amelyik hárommal és öttel is osztható.
 */
function task03(arr){
    let nums = [];
    let idx = 0;

    /*
    for (let i = 0; i < arr.length; i++)
    {
        if (arr[i]%3 == 0 && arr[i]%5 == 0)
        {
            nums[idx] = arr[i];
            i++;
        }
    }
    */

    for (let num of arr)
    {
        if (num%3 == 0 && num%5 == 0)
        {
            nums.push(num);
        }
    }

    return nums[nums.length - 1];
}

/**
 * A paraméterben megadott tömbből add vissza annak az elemnek az indexét,
 * amelyik pontosan 5 karakter hosszú. Ha több ilyen is van akkor az első előfordulást.
 */
function task04(arr){
    /*
    for (let i = 0; i < arr.length; i++)
    {
        if (arr[i].length == 5)
        {
            return arr[i];
        }
    }
    */

    for (const num of arr)
    {
        if (num.length == 5)
        {
            return num;
        }
    }
}

/**
 * A paraméterben megadott tömbből válogasd ki a pozitív páros számokat.
 */
function task05(arr){
    let positiveEvenNums = [];
    let idx = 0;

    /*
    for (let i = 0; i < arr.length; i++)
    {
        if (arr[i] > 0 && arr[i]%2 == 0)
        {
            positiveEvenNums[idx] = arr[i];
            idx++;
        }
    }
    */

    for (let num of arr)
    {
        if (num > 0 && num%2 == 0)
        {
            positiveEvenNums.push(num);
        }
    }
    
    return positiveEvenNums;
}
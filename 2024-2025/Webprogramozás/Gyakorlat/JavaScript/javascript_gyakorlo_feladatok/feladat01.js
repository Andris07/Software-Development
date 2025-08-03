`use strict`;

function randomSzamok(tomb = [])
{
    if (tomb.length == 0)
    {
        const min = 1;
        const max = 100;

        for (let i = 0; i < 5; i++)
        {
            tomb[i] = Math.floor(Math.random() * (max - min + 1)) + min;
        }
    }

    console.log(tomb);
}

randomSzamok();
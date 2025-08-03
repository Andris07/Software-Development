`use strict`;

let min = Number(window.prompt(`Kérem adja meg az alsóhatárt: `));
let max = Number(window.prompt(`Kérem adja meg a felsőhatárt: `));

if (min >= max)
{
    window.alert(`A felsőhatárnak nagyobbnak kell lennie, mint az alsóhatár!`);
}
else
{
    window.alert(random(min, max));
}

function random(min = 1, max = 10)
{
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
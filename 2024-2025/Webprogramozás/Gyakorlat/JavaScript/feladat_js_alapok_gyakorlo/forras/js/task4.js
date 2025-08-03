`use strict`;

const months = [`január`, `február`, `március`, `április`, `május`, `június`, `július`, `augusztus`, `szeptember`, `október`, `november`, `december`];
const days = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

let month = Number(window.prompt(`Kérem adja meg a hónap sorszámát: `));

if (month < 1 || month > 12)
{
    console.log(`Érvénytelen hónap!`);
}
else
{
    console.log(`A hónap neve ${months[month - 1]}`);

    if (month > 2 && month < 6)
    {
        console.log(`Tavaszi hónap`);
    }
    else if (month > 5 && month < 9)
    {
        console.log(`Nyári hónap`);
    }
    else if (month > 8 && month < 12)
    {
        console.log(`Őszi hónap`);
    }
    else
    {
        console.log(`Téli hónap`);
    }

    if (month%2 == 0)
    {
        console.log(`A hónap sorszáma páros`);
    }
    else
    {
        console.log(`A hónap sorszáma páratlan`);
    }

    console.log(`A hónap ${days[month - 1]} napos`);
}
"use strict"

function createListItem(text) {
    const liElement = document.createElement(`li`);
    liElement.textContent = text;
    return liElement;
}

function createSpan(text) {
    const spanElement = document.createElement(`span`);
    spanElement.textContent = text;
    return spanElement;
}

function getLineArray(line) {
    switch (line)
    {
        case `1`: return line1;
        case `2`: return line2;
        case `D`: return lineD;
        case `71`: return line71;
        default: return [];
    }
}

function addNewData(line, name, boarded, disembarked) {
    const stop = [name, boarded, disembarked];
    getLineArray(line).push(stop);
}

function passengerStats() {
    const lines = [`1`, `2`, `D`, `71`];

    lines.forEach(line =>
    {
        const array = getLineArray(line);
        const total = array.reduce((sum, stop) => sum + stop[1], 0);
        const avg = (total / array.length).toFixed(2);

        const paragraph = document.getElementById(`sum-${line}`);

        paragraph.innerHTML = ``;
        paragraph.appendChild(createSpan(`Osszesen ${total}`));
        paragraph.appendChild(createSpan(`Átlagos utascsere: ${avg}`));
    });
}
passengerStats();

const filterResults = document.querySelector('#filter-results');
function filterStops(line, value) {
    filterResults.innerHTML = ``;
    
    const actualLine = getLineArray(line);

    const rightLines = actualLine.filter(stop => stop[1] === value || stop[2] === value);

    if (rightLines.length === 0)
    {
        filterResults.appendChild(createListItem(`Nincs találat`)); return;
    }

    rightLines.forEach(stop =>
    {
        const text = `${stop[0]} - felszállók: ${stop[1]}, leszállók: ${stop[2]}`;
        filterResults.appendChild(createListItem(text));
    });
}

const popularResults = document.querySelector('#popular-results');
function popularStops() {
    popularResults.innerHTML = ``;

    const allStops = [];

    allStops.push(...getLineArray(`1`));
    allStops.push(...getLineArray(`2`));
    allStops.push(...getLineArray(`D`));
    allStops.push(...getLineArray(`71`));

    allStops.sort((currentStop, nextStop) => nextStop[1] - currentStop[1]);

    for (let i = 0; i < 3; i++)
    {
        const text = `${allStops[i][0]} (${allStops[i][1]} felszálló)`;
        popularResults.appendChild(createListItem(text));
    }
}
popularStops();

const findResults = document.querySelector('#find-results');
function findStop(name) {
    findResults.innerHTML = ``;

    const lines = [`1`, `2`, `D`, `71`];
    const rightLines = [];

    lines.forEach(line =>
    {
        const stops = getLineArray(line);
        const hasStop = stops.some(stop => stop[0] === name);

        if (hasStop)
        {
            rightLines.push(line);
        }
    });

    if (rightLines.length === 0)
    {
        findResults.appendChild(createListItem("Ø")); return;
    }

    rightLines.forEach(line => findResults.appendChild(createListItem(line)));
}

document.querySelector('#add-item').addEventListener('submit', event => {
    event.preventDefault();
    addNewData(
        document.querySelector('#line').value,
        document.querySelector('#name').value,
        +document.querySelector('#boarded').value,
        +document.querySelector('#disembarked').value,
    );
    passengerStats();
    popularStops();
})

document.querySelector('#filter-item').addEventListener('submit', event => {
    event.preventDefault();
    filterStops(
        document.querySelector('#filter-line').value,
        +document.querySelector('#filter-value').value,
    )
})

document.querySelector('#find-stop').addEventListener('submit', event => {
    event.preventDefault();
    findStop(
        document.querySelector('#stop-name').value,
    )
})

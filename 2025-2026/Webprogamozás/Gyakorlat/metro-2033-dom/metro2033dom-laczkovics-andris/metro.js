`use strict`;

const header = document.getElementById(`header`);
const data = document.getElementById(`data`);
const short = document.getElementById(`short`);
const stations = document.getElementById(`stations`);
const cover = document.getElementById(`cover`);

short.append(title());
short.append(episodes());
short.append(pages());
first();
vdnh();

cover.addEventListener(`click`, coverSwap);

for (const station of stations.children)
{
    station.addEventListener("click", visited)
}

function title()
{
    const title = header.getElementsByTagName(`h1`)[0];
    const paragraph = document.createElement(`p`);
    paragraph.textContent = `Cím: `;
    const answer = document.createElement(`span`);
    answer.textContent = title.textContent;
    paragraph.append(answer);
    return paragraph;
}

function episodes()
{
    const episodesCount = data.getElementsByTagName(`ul`)[0];
    const paragraph = document.createElement(`p`);
    paragraph.textContent = `Részek száma: `;
    const answer = document.createElement(`span`);
    answer.textContent = episodesCount.children.length;
    paragraph.append(answer);
    return paragraph;
}

function pages()
{
    const pagesCount = data.getElementsByTagName(`li`)[3].getElementsByTagName(`span`)[0];
    const paragraph = document.createElement(`p`);
    paragraph.textContent = `Első rész hossza: `;
    const answer = document.createElement(`span`);
    answer.textContent = pagesCount.textContent;
    paragraph.append(answer);
    return paragraph;
}

function first()
{
    const episodes = data.getElementsByTagName(`ul`)[0];
    const firstEpisode = episodes.getElementsByTagName(`li`)[0];
    firstEpisode.classList.add(`first`);
}

function vdnh()
{
    const listElement = document.createElement(`li`);
    listElement .textContent = `VDNH`;
    stations.prepend(listElement);
}

function coverSwap()
{
    const fileName = cover.getAttribute(`src`);
    
    if (fileName === `2033.jpg`)
    {
        cover.setAttribute(`src`, `2033-new.jpg`);
        cover.setAttribute(`alt`, `Metró 2033 könyv új borító`);
        document.body.style.setProperty(`--main-color`, `#ce322b`);
    }
    else
    {
        cover.setAttribute(`src`, `2033.jpg`);
        cover.setAttribute(`alt`, `Metró 2033 könyv eredeti borító`);
        document.body.style.setProperty(`--main-color`, `#ffcc00`);
    }
}

function visited(event)
{
    event.target.style.backgroundColor = `var(--main-color)`;
    event.target.style.color = `black`;
    event.target.style.border = `3px double black`;
    event.target.style.cursor = `crosshair`;
}
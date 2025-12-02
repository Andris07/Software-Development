"use strict"

const ITEMS_PER_PAGE = 20;

let tracks = [...data];

const tracksContainer = document.querySelector('#tracks');

document.querySelector('#next-page').addEventListener('click', e => {
    if (tracksContainer.dataset.page > data.length / ITEMS_PER_PAGE) return;
    tracksContainer.dataset.page = +tracksContainer.dataset.page + 1;
    generateCards(tracksContainer.dataset.page);
});

document.querySelector('#prev-page').addEventListener('click', e => {
    if (tracksContainer.dataset.page <= 1) return;
    tracksContainer.dataset.page = +tracksContainer.dataset.page - 1;
    generateCards(tracksContainer.dataset.page);
});

const paginator = document.querySelector('#page-numbers');
function generatePaginator() {

}
generatePaginator();

function generateCards(page) {
    
}
generateCards(1);

function filterTracks(value) {
    const search = value.toLowerCase();

    tracks = data.filter(track =>
    {
        const nameMatch = track.name.toLowerCase().includes(search);
        const artistsMatch = track.artists.some(artist => artist.toLowerCase().includes(search));
        return nameMatch || artistsMatch;
    });

    tracksContainer.dataset.page = 1;
    generateCards(tracksContainer.dataset.page);
    generatePaginator();
}

const resultsText = document.querySelector('#number-of-results');
document.querySelector('#search').addEventListener('input', e => {
    filterTracks(e.currentTarget.value)
    resultsText.textContent = e.currentTarget.value ? `${tracks.length} találat a(z) "${e.currentTarget.value}" kifejezésre:` : "";
})

const user =
{
    username: "András",
    nickname: "Andris"
};

({ username: document.getElementById(`username`).textContent, nickname: document.getElementById(`nickname`).textContent } = user);

function createCard({name, artists, image, explicit})
{
    const cardElement = document.createElement(`div`);
    cardElement.classList.add(`card`);
    const imageElement = document.createElement(`img`);
    imageElement.src = image;
    imageElement.classList.add(`card--cover`);
    const spanElement1 = document.createElement(`span`);
    spanElement1.textContent = name;
    spanElement1.title = name;
    spanElement1.classList.add(`card--track`);
    const spanElement2 = document.createElement(`span`);
    spanElement2.textContent += artists.join(`, `);
    spanElement2.title += artists.join(`, `);
    if (explicit)
    {
        const spanElement3 = document.createElement(`span`);
        spanElement3.classList.add(`card--explicit`);
        spanElement2.prepend(spanElement3);
    }

    cardElement.append(imageElement);
    cardElement.append(spanElement1);
    cardElement.append(spanElement2);

    cardElement.addEventListener("click", function()
    {
        selectTrack({name, artists, image});
    });

    return cardElement;
}

document.getElementById(`tracks`).replaceChildren(createCard(tracks[0]));

function generatePaginator()
{
    paginator.innerHTML = ``;

    const oldalak = tracksContainer.id / ITEMS_PER_PAGE;

    for (let i = 1; i <= oldalak; i++)
    {
        const a = document.createElement(`a`);
        a.textContent = i;

        a.addEventListener(`click`, function()
        {
            tracksContainer.dataset.page = i;
            generateCards(i);
        });

        paginator.appendChild(a);
    }
}

function generateCards(page)
{
    tracksContainer.innerHTML = ``;
    const index = page * ITEMS_PER_PAGE - ITEMS_PER_PAGE;
    const songs = tracks.slice(index, index + ITEMS_PER_PAGE);

    songs.forEach(song =>
    {
        tracksContainer.append(createCard(song));
    });
}

function selectTrack({name, artists, image})
{
    const imageElement = document.getElementById(`playing--cover`);
    const nameElement = document.getElementById(`playing--track`);
    const artistsElement = document.getElementById(`playing--artists`);
    imageElement.src = image;
    nameElement.textContent = name;
    artistsElement.textContent = artists.join(`, `);
}
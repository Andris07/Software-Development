"use strict"

// 4. filmek száma és időtartam kiírása
const filmCount = document.getElementById(`film-count`);
filmCount.appendChild(createSpan(films.length + " film", ["text-lg"]));
const lengthCount = document.getElementById(`film-length`);
lengthCount.appendChild(createSpan(films.length * 120 + " órányi élmény", ["text-lg", "astrict"]));

// 4.c. legolcsóbb jegy destruktúrálással
const cheapestTicket = tickets.sort((a, b) => a[2] - b[2])[0];
const [ name, type, price ] = cheapestTicket;

document.getElementById("cheapest-ticket-price").appendChild(createSpan(price + " forinttól", ["text-lg", "double-astrict"]));

const detailsElement = document.getElementById("cheapest-ticket-details");
detailsElement.textContent += ` ${name} (${type})`;

// 3. createSpan függvény
function createSpan(text, classArray = [])
{
    const spanElement = document.createElement(`span`);
    spanElement.textContent = text;
    spanElement.classList.add(...classArray);
    return spanElement;
}

// 5. capitalize függvény
function capitalize(string)
{
    const [first, ...rest] = string;
    return first.toUpperCase() + rest.join("");
}

// 6. createTicketCard függvény
function createTicketCard(name, type, price)
{
    const div = document.createElement("div");
    div.classList.add("ticket-card");

    const h3 = document.createElement("h3");
    h3.textContent = capitalize(name);

    const pType = document.createElement("p");
    pType.textContent = type;
    pType.classList.add("ticket-type");

    const pPrice = document.createElement("p");
    pPrice.textContent = `${price} Ft`;
    pPrice.classList.add("ticket-price");

    div.append(h3, pType, pPrice);
    return div;
}

// 7. generateTicketCards függvény
function generateTicketCards()
{
    const cards = [];

    for (const [ name, type, price ] of tickets)
    {
        const card = createTicketCard(name, type, price);
        cards.push(card);
    }

    const ticketsContainer = document.getElementById("tickets");
    ticketsContainer.replaceChildren(...cards);
}
generateTicketCards();

// 8. createFilmCard függvény
function createFilmCard(name, image)
{
    const div = document.createElement("div");
    div.classList.add("film-card");

    const img = document.createElement("img");
    img.src = image;
    img.alt = name;

    const h3 = document.createElement("h3");
    h3.textContent = name;

    div.append(img, h3);
    return div;
}

// 9. generateFilmCards függvény
function generateFilmCards()
{
    const cards = [];
    const images = [];

    // 9.a. mappedFilms létrehozása
    const mappedFilms = films.map(film =>
    [
        film, `src/assets/images/${film.replaceAll(" ", "_")}.jpeg`
    ]);

    // 9.b. első 3 film kiemelése
    const topFilms = mappedFilms.slice(0, 3);

    for (const [name, image] of topFilms)
    {
        cards.push(createFilmCard(name, image));
    }

    // 9.c. kártyák megjelenítése
    const filmsContainer = document.getElementById("films");
    filmsContainer.replaceChildren(...cards);

    // 9.d. maradék filmek képei
    const otherFilms = mappedFilms.slice(3);

    for (const [, image] of otherFilms)
    {
        const img = document.createElement("img");
        img.src = image;
        images.push(img);
    }

    // 9.e. képek megjelenítése
    const otherFilmsContainer = document.getElementById("other-films");
    otherFilmsContainer.replaceChildren(...images);
}
generateFilmCards();
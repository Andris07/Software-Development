`use strict`;

function createSortOptions() {
    const array = [];

    for (let i = 0; i < options.length; i++) {
        const optionElement = document.createElement(`option`);
        optionElement.textContent = options[i].label;
        optionElement.value = options[i].value;

        array.push(optionElement);
    }

    return array;
}

document.addEventListener(`DOMContentLoaded`, (event) => {
    document.getElementById(`sort-select`).append(...createSortOptions());
    loadOffers();
});

function isAvailable(before, after) {
    if (before <= Date.now() && after >= Date.now()) {
        return true;
    }
    return false;
}

function createAvailableBadge(isAvailable) {
    const spanElement = document.createElement(`span`);
    spanElement.classList.add(`badge`);

    if (isAvailable) {
        spanElement.classList.add(`badge-new`);
        spanElement.textContent = `Elérhető`;
    }
    else {
        spanElement.classList.add(`badge-premium`);
        spanElement.textContent = `Nem elérhető`;
    }

    return spanElement;
}

function createFeatureTags(features = []) {
    return features.map((feature) => {
        const spanElement = document.createElement(`span`);
        spanElement.classList.add(`tag`);
        spanElement.textContent = feature;

        return spanElement;
    });
}

function createPriceTag(cost) {
    const divElement = document.createElement(`div`);
    divElement.classList.add(`price`);

    divElement.textContent = cost.toLocaleString(`hu-HU`, { style: `currency`, currency: `HUF`, maximumFractionDigits: 0 });
    divElement.textContent += `/fő/éj`;

    return divElement;
}

function createFeatureList(features) {
    const divElement = document.createElement(`div`);
    divElement.classList.add(`feature-tags`);

    divElement.append(...createFeatureTags(features));

    return divElement;
}

console.log(createFeatureList(offers[0].hotel.features));

let filtered = offers;

function loadOffers() {
    const offersDiv = document.getElementById(`offers`);

    offersDiv.replaceChildren
    (
        ...filtered.map(offer =>
        {
            const divElement = document.createElement(`div`);
            divElement.classList.add(`offer-card`);

            const imgElement = document.createElement(`img`);
            imgElement.src = `./assets/images/${offer.hotel.img}`;
            imgElement.alt = offer.hotel.name;

            const h3Element = document.createElement(`h3`);
            h3Element.textContent = offer.hotel.name;

            const pElement = document.createElement(`p`);
            pElement.textContent = offer.summary;

            divElement.append(imgElement);

            const divElement2 = document.createElement(`div`);
            divElement2.classList.add(`card-body`);

            divElement2.replaceChildren
            (
                createAvailableBadge(isAvailable(offer.available.before, offer.available.after)),
                h3Element,
                pElement,
                createFeatureList(offer.hotel.features),
                createPriceTag(offer.cost)
            );

            divElement.replaceChildren(imgElement, divElement2);
            return divElement;
        })
    );
}

function filter()
{
    const minPrice = document.getElementById(`min-price`);
    const maxPrice = document.getElementById(`max-price`);

    filtered = offers.filter(offer =>
    {
        return minPrice.value <= offer.cost && offer.cost <= maxPrice.value;
    });

    loadOffers();
}

document.getElementById(`run-filter`).addEventListener(`click`, filter);

function clearFilter()
{
    const minPrice = document.getElementById(`min-price`);
    const maxPrice = document.getElementById(`max-price`);
    minPrice.value = ``;
    maxPrice.value = ``;

    filtered = offers;
}

document.getElementById(`clear-filter`).addEventListener(`click`, clearFilter);

function sortOffers()
{
    const sort = document.getElementById(`sort-select`);

    if (sort.value === `price-asc`)
    {
        filtered = offers.toSorted((a, b) => a.cost - b.cost)
    }
    else if (sort.value === `price-desc`)
    {
        filtered = offers.toSorted((a, b) => b.cost - a.cost)
    }
    else if (sort.value === `name-asc`)
    {
        filtered = offers.toSorted((a, b) => a.hotel.name.localeCompare(b.hotel.name))
    }
    else if (sort.value === `name-desc`)
    {
        filtered = offers.toSorted((a, b) => b.hotel.name.localeCompare(a.hotel.name))
    }
    else
    {
        filtered = offers;
    }
    loadOffers();
}

document.getElementById(`sort-select`).addEventListener(`change`, sortOffers);
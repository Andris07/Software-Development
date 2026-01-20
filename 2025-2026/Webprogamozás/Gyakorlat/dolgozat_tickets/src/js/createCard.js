"use strict";

import { capitalize } from "@stdlib/string-capitalize";

export function create(ticket, type)
{
    const cardElement = document.createElement("div");
    cardElement.className = "flex flex-col justify-items-center space-y-4 flex-1";

    const timeElement = document.createElement("h2");
    timeElement.textContent = ticket.time;
    timeElement.className = "p-2 text-lg font-semibold bg-red-300";

    cardElement.append(timeElement);

    const priceDetails = ticket.price[type];
    if (priceDetails)
    {
        Object.entries(priceDetails).forEach(([category, price], index) =>
        {
            const priceElement = document.createElement("div");
            priceElement.className = "p-2 flex flex-1 even:bg-rose-200 odd:bg-rose-100 justify-items-center justify-center";
            priceElement.textContent = `${category}: ${price.toLocaleString("de-DE", {style: "currency", currency: "EUR"})}`;
            cardElement.append(priceElement);
        });
    }
    return cardElement;
}
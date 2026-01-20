import "@assets/app.css";
import { ticketsArray } from "./js/tickets";
import { create } from "./js/createCard";

const tickets = ticketsArray();

const ticketContainer = document.querySelector('#tickets');
function generateCards(type) {
    ticketContainer.replaceChildren();
    for (const ticket of tickets) {
        if (ticket.price[type]) ticketContainer.append(create(ticket, type));
    }
}

generateCards('paper');

const option = document.getElementById("type");
option.addEventListener("change", () =>
{
    generateCards(option.value);
});
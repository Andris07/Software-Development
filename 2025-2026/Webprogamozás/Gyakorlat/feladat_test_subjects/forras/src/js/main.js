"use strict"

function capitalize(text) {
    return text.toUpperCase().slice(0, 1) + text.substring(1);
}

function createTableRow(subject) {
    const row = document.createElement('tr');
    
    
    const id = document.createElement('td');
    

    const name = document.createElement('td');
    

    const statusWraper = document.createElement('td')
    const status = document.createElement('span');
    
    
    statusWraper.append(status);

    row.append(id, name, statusWraper);

    row.dataset.id = subject.id;
    id.textContent = subject.id;
    name.textContent = subject.name;
    status.textContent = capitalize(subject.status);
    status.classList.add(subject.status);
    return row;
}

function fillTable(array) {
    const rows = [];
    for (const subject of array) {
        rows.push(createTableRow(subject));
    }
    table.replaceChildren(...rows);
    addEventListenersToRows()
}

const table = document.querySelector('#list-of-subjects tbody');
fillTable(subjects);

function showSubject(subject)
{
    subject.map(item =>
    {
        const data = item;
        data.id = "current--subject--" + data.value;

        if (data.value == "status")
        {
            data.textContent = capitalize(data.value);
            data.classList.remove("alive","terminated");
            data.classList.add(data.value);
        }
        else if (data.value == "traits")
        {
            const array = [];
            
            data.map(item=>
            {
                const span = document.createElement("span");
                span.textContent = item.value;
                array.push(span);

                for (let i = 0; i < array.length; i++)
                {
                    data[i] = array[i];
                }
            });
        }
        else
        {
            data.textContent = data.value;
        }
    });
}

function addEventListenersToRows()
{
    table.querySelectorAll('tr').forEach(x => x.addEventListener('click', e => showSubject(subjects.find(y => y.id==x.dataset.id))));
}

function filterSubjects(name)
{
    return subjects.filter(subject => subject.name.toLowerCase().includes(name.toLowerCase()));
}

document.querySelector('#search').addEventListener('submit', e => {
    e.preventDefault();
    fillTable(filterSubjects(document.querySelector('#name').value));
});

const userProfile =
{
    name: `Laczkovics András Gergő`,
    position: `unemployed`,
}

document.getElementById(`profile--name`).textContent = userProfile.name;
document.getElementById(`profile--position`).textContent = userProfile.position;
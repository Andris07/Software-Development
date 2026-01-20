import "@assets/app.css";
import { createCard } from "./ui/cards";
import { allPackages } from "./data";
import { mergeIncludes } from "./data";

const courses = document.getElementById("courses");
courses.classList.add("grid");
courses.classList.add("gap-8");
courses.classList.add("grid-cols-1");
courses.classList.add("md:grid-cols-2");
courses.classList.add("lg:grid-cols-3");
courses.classList.add("2xl:grid-cols-4");
courses.classList.add("m-4");

const array = allPackages();
const billing = document.getElementById("billingToggle");

function clearElement(elements)
{
  while (elements.firstChild)
  {
    elements.removeChild(elements.firstChild);
  }
}

function Generate()
{
  clearElement(courses);

  for (let i = 0; i < array.length; i++)
  {
    let subscription = false;
    if (billing.value === "annual") subscription = true;
    courses.append(createCard(array[i], subscription));
  }
}

document.addEventListener("DOMContentLoaded", () =>
{
  Generate();

  billing.addEventListener("change", Generate);
});
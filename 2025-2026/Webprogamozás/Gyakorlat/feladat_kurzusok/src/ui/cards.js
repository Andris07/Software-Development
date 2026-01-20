import { mergeIncludes } from "@/data";

export function createCard({ id, name, short_description, price, discount_percentage, includes_additional, includes_all_from }, subscription)
{
  const divElement1 = document.createElement("div");
  divElement1.classList.add("border");
  divElement1.classList.add("border-solid");
  divElement1.classList.add("border-gray-200");
  divElement1.classList.add("rounded-xl");
  divElement1.classList.add("shadow-md");
  divElement1.classList.add("p-4");

  const h2Element = document.createElement("h2");
  h2Element.textContent = name;
  h2Element.classList.add("text-center");
  h2Element.classList.add("text-2xl");
  h2Element.classList.add("font-bold");
  h2Element.classList.add("text-gray-900");

  const divElement2 = document.createElement("div");
  divElement2.classList.add("flex");
  divElement2.classList.add("justify-center");
  divElement2.classList.add("items-end");
  divElement2.classList.add("p-2");
  divElement2.classList.add("my-4");

  const spanElement1 = document.createElement("span");
  const calculatedPrice = subscription ? price - discount_percentage * price : price;
  spanElement1.textContent = calculatedPrice.toLocaleString("en-US", { style: "currency", currency: "USD", minimumFractionDigits: 0, maximumFractionDigits: 2 });
  spanElement1.classList.add("text-4xl");
  spanElement1.classList.add("font-bold");

  const spanElement2 = document.createElement("span");
  spanElement2.textContent = "/ month";
  spanElement2.classList.add("text-sm");
  spanElement2.classList.add("text-gray-500");

  const pElement = document.createElement("p");
  pElement.textContent = subscription ? "Billed annually at a discount" : "Billed monthly";
  pElement.classList.add("text-center");
  pElement.classList.add("text-sm");
  pElement.classList.add("text-gray-500");
  pElement.classList.add("mb-4");

  const ulElement = document.createElement("ul");
  for (let i = 0; i < mergeIncludes(id).length; i++)
  {
    const liElement = document.createElement("li");
    liElement.textContent = mergeIncludes(id)[i];
    liElement.classList.add("border-t");
    liElement.classList.add("border-solid");
    liElement.classList.add("border-gray-200");
    liElement.classList.add("py-1");
    liElement.classList.add("px-2");
    liElement.classList.add("hover:bg-blue-400");
    liElement.classList.add("hover:text-white");
    ulElement.append(liElement);
  }

  // rövid leírás (feladatleírásból kimaradt)
  const description = document.createElement("p");
  description.textContent = short_description;
  description.classList.add("text-center");
  description.classList.add("text-sm");
  description.classList.add("text-gray-600");

  divElement2.append(spanElement1, spanElement2);
  divElement1.append(h2Element, description, divElement2, pElement, ulElement);
  return divElement1;
}
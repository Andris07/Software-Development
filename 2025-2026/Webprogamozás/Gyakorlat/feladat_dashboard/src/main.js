import "@assets/app.css";
import { formatEmoji } from "./js/helpers";

fetch("https://randomuser.me/api?nat=us,gb",
{
    method: "GET",
    headers:
    {
        Accept: "application/json"
    }
}).then(response =>
{
    return response.json();
}).then(json =>
{
    const name = document.getElementById("name");
    const {first, last } = json.results[0].name;
    name.textContent = first + " " + last;
}).catch(error =>
{
    console.error(error)
});

fetch("https://emojihub.yurace.pro/api/random/category/smileys-and-people",
{
    method: "GET",
    headers:
    {
        Accept: "application/json"
    }
}).then(response =>
{
    return response.json();
}).then(json =>
{
    const emoji = document.getElementById("emoji");
    emoji.textContent = json.unicode[0];
    console.log(json.unicode[0]);
}).catch(error =>
{
    console.error(error)
});

fetch("https://api.fiscaldata.treasury.gov/services/api/fiscal_service/v1/accounting/od/rates_of_exchange?filter=country_currency_desc:eq:Hungary-Forint,record_date:eq:2025-12-31",
{
    method: "GET",
    headers:
    {
        Accept: "application/json"
    }
}).then(response =>
{
    return response.json();
}).then(json =>
{
    const huf = document.getElementById("huf");
    huf.textContent = Math.round(json.data[0].exchange_rate);
}).catch(error =>
{
    console.error(error)
});

fetch("https://api.spaceflightnewsapi.net/v4/articles/?limit=6/",
{
    method: "GET",
    headers:
    {
        Accept: "application/json"
    }
}).then(response =>
{
    return response.json();
}).then(json =>
{
    const news = document.getElementById("news");
    const news_template = document.getElementById("news_template");
    
    json.results.forEach(hir =>
    {
        const clone = news_template.content.cloneNode(true);
        clone.querySelector("img").src = hir.image_url;
        clone.querySelector("img").alt = hir.title;
        clone.querySelector("h3").textContent = hir.title;
        clone.querySelector("p").textContent = hir.summary;
        news.appendChild(clone);
    });
}).catch(error =>
{
    console.error(error);
});

fetch("https://api.open-meteo.com/v1/forecast?latitude=47.29&longitude=29.04&daily=temperature_2m_max,temperature_2m_min,rain_sum&timezone=Europe%2FBerlin",
{
    method: "GET",
    headers:
    {
        Accept: "application/json"
    }
}).then(response =>
{
    return response.json();
}).then(json =>
{
    const weather = document.getElementById("weather");
    const weather_clone = document.getElementById("weather-clone");

    let idojaras = json.daily;
    for(let i = 0; i < idojaras.time.length; i++)
    {
        {
            const clone = weather_clone.content.cloneNode(true);
            clone.querySelector(".time").textContent = idojaras.time[i];
            clone.querySelector(".max").textContent = Math.round(idojaras.temperature_2m_max[i]);
            clone.querySelector(".min").textContent = Math.round(idojaras.temperature_2m_min[i]);
            clone.querySelector(".rain").textContent = idojaras.rain_sum[i];
            weather.appendChild(clone);
        }
    }
}).catch(error =>
{
    console.error(error);
});
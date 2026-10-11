SELECT ROUND(AVG(DATEDIFF(`veg`, `kezdet`)), 2) AS `Gemini küldetések átlagos hosszúsága` FROM `kuldetes`
WHERE `megnevezes` LIKE '%Gemini%';
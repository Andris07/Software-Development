SELECT `kuldetes`.`megnevezes`, `urhajos`.`nev` FROM `kuldetes`
LEFT JOIN `repules`
ON `kuldetes`.`id`=`repules`.`kuldetes_id`
LEFT JOIN `urhajos`
ON `repules`.`urhajos_id`=`urhajos`.`id`
ORDER BY `kuldetes`.`kezdet`, `urhajos`.`nev` DESC;
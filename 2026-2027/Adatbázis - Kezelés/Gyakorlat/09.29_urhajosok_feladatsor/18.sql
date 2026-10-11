DELETE FROM `repules`
WHERE `repules`.`urhajos_id` IN (SELECT `urhajos`.`id` FROM `urhajos` WHERE `urhajos`.`nev`='Serbán Lajos');

DELETE FROM `urhajos`
WHERE `nev`='Serbán Lajos';
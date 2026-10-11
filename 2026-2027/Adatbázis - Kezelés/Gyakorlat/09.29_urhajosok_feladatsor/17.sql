SELECT `kuldetes`.`megnevezes`, `kuldetes`.`kezdet`, `kuldetes`.`veg` FROM `kuldetes`
WHERE `kuldetes`.`id` NOT IN
(SELECT DISTINCT `repules`.`kuldetes_id` FROM `repules`
LEFT JOIN `urhajos`
ON `repules`.`urhajos_id`=`urhajos`.`id`
WHERE `urhajos`.`nem`='F')
AND `kuldetes`.`id` IN
(SELECT DISTINCT `repules`.`kuldetes_id` FROM `repules`
LEFT JOIN `urhajos`
ON `repules`.`urhajos_id`=`urhajos`.`id`
WHERE `urhajos`.`nem`='N')
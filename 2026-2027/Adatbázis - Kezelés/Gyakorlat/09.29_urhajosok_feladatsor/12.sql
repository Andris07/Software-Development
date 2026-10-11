SELECT `urhajos`.`nev`, COUNT(`kuldetes`.`id`) AS `db` FROM `urhajos`
LEFT JOIN `repules`
ON `urhajos`.`id`=`repules`.`urhajos_id`
LEFT JOIN `kuldetes`
ON `repules`.`kuldetes_id`=`kuldetes`.`id`
GROUP BY `urhajos`.`id`
HAVING `db` >= 6;
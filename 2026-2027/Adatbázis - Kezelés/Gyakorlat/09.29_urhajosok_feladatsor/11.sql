SELECT `kuldetes`.`megnevezes`, COUNT(*) AS `fo` FROM `kuldetes`
LEFT JOIN `repules`
ON `kuldetes`.`id`=`repules`.`kuldetes_id`
LEFT JOIN `urhajos`
ON `repules`.`urhajos_id`=`urhajos`.`id`
GROUP BY `kuldetes`.`id`;
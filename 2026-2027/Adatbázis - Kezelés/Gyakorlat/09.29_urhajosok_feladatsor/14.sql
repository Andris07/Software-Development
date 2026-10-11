SELECT `urhajos`.`orszag` FROM `urhajos`
LEFT JOIN `repules`
ON `urhajos`.`id`=`repules`.`urhajos_id`
LEFT JOIN `kuldetes`
ON `repules`.`kuldetes_id`=`kuldetes`.`id`
WHERE YEAR(`kuldetes`.`kezdet`) >= 1991 AND YEAR(`kuldetes`.`kezdet`) <= 2000
GROUP BY `urhajos`.`orszag`
ORDER BY COUNT(`urhajos`.`id`) DESC
LIMIT 3;
CREATE OR REPLACE VIEW `orszagfo` (`COUNTRY_NAME`, `fo`)
AS
SELECT `countries`.`country_name`, COUNT(*)
FROM `employees`
LEFT JOIN `departments`
ON `employees`.`department_id`=`departments`.`department_id`
LEFT JOIN `locations`
ON `departments`.`location_id`=`locations`.`location_id`
LEFT JOIN `countries`
ON `locations`.`country_id`=`countries`.`country_id`
GROUP BY `locations`.`country_id`
HAVING `countries`.`country_name` IS NOT NULL;
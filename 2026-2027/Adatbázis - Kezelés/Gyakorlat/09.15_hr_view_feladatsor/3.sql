CREATE OR REPLACE VIEW `programozok` (`FULL_NAME`)
AS
SELECT CONCAT(`first_name`, ' ', `last_name`)
FROM `employees`
LEFT JOIN `jobs`
ON `employees`.`job_id`=`jobs`.`job_id`
WHERE `job_title`='Programmer';

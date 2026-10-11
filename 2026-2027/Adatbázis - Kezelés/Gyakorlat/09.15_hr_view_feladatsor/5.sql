CREATE OR REPLACE VIEW `munkakorletszam` (`JOB_TITLE`, `db`)
AS
SELECT `job_title`, COUNT(*)
FROM `employees`
LEFT JOIN `jobs`
ON `employees`.`job_id`=`jobs`.`job_id`
GROUP BY `jobs`.`job_title`;
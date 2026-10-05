CREATE OR REPLACE VIEW `munkakorletszam` (`JOB_TITLE`, `db`)
AS
SELECT `job_title`, COUNT(*)
FROM `jobs`
LEFT JOIN `employees`
ON `employees`.`job_id`=`jobs`.`job_id`
LEFT JOIN `departments`
ON `employees`.`department_id`=`departments`.`department_id`
GROUP BY `departments`.`department_id`;
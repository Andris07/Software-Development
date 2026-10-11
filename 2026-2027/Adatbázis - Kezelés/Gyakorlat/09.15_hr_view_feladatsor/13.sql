CREATE OR REPLACE VIEW `belepo` (`FULL_NAME`, `HIRE_DATE`)
AS
SELECT CONCAT(`employees`.`first_name`, ' ', `employees`.`last_name`), `HIRE_DATE`
FROM `job_history`
JOIN `employees`
ON `job_history`.`employee_id`=`employees`.`department_id`;
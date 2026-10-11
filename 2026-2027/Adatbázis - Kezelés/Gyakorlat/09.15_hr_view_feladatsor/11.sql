CREATE OR REPLACE VIEW `kiholdolgozik` (`EMPLOYEE_ID`, `EMPLOYEE_FULL_NAME`, `DEPARTMENT_ID`, `DEPARTMENT_NAME`)
AS
SELECT `employees`.`employee_id`, CONCAT(`employees`.`first_name`, ' ', `employees`.`last_name`), `departments`.`department_id`, `departments`.`department_name`
FROM `employees`
JOIN `departments`
ON `employees`.`department_id`=`departments`.`department_id`;
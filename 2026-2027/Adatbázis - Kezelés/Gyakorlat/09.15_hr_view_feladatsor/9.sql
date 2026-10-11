CREATE OR REPLACE VIEW `reszlegvezeto` (`DEPARTMENT_NAME`, `FULL_NAME`)
AS
SELECT `departments`.`department_name`, CONCAT(`employees`.`first_name`, ' ', `employees`.`last_name`)
FROM `departments`
JOIN `employees`
ON `departments`.`manager_id`=`employees`.`employee_id`;
SELECT ROUND(AVG(`employees`.`salary`))
AS `atlag`
FROM `employees`
JOIN `kiholdolgozik`
ON `kiholdolgozik`.`department_id`=`employees`.`department_id`
WHERE `EMPLOYEE_FULL_NAME`='David Austin';
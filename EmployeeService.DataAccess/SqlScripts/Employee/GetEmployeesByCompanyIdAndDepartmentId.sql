SELECT "Employees"."Id",
	   "Employees"."Name",
	   "Employees"."Surname",
	   "Employees"."Phone",
	   "Employees"."CompanyId",
	   "Employees"."PassportId",
	   "Employees"."DepartmentId",
	   
	   "Companies"."Id",
	   "Companies"."Name",
	   "Companies"."Inn",
	   
	   "Passports"."Id",
	   "Passports"."Type",
	   "Passports"."Number",

	   "Departments"."Id",
	   "Departments"."Name",
	   "Departments"."Phone"
FROM "Employees"
JOIN "Companies" ON "Companies"."Id" = "Employees"."CompanyId"
JOIN "Passports" ON "Passports"."Id" = "Employees"."PassportId"
JOIN "Departments" ON "Departments"."Id" = "Employees"."DepartmentId"
WHERE "Employees"."CompanyId" = @CompanyId AND "Employees"."DepartmentId" = @DepartmentId
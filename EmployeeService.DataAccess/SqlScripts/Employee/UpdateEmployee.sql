UPDATE "Employees"
SET 
	"Name" = COALESCE(@Name, "Name"),
	"Surname" = COALESCE(@Surname, "Surname"),
	"Phone" = COALESCE(@Phone, "Phone"),
	"CompanyId" = COALESCE(@CompanyId, "CompanyId"),
	"PassportId" = COALESCE(@PassportId, "PassportId"),
	"DepartmentId" = COALESCE(@DepartmentId, "DepartmentId")
WHERE "Id" = @Id
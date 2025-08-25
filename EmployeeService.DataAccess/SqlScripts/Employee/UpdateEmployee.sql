UPDATE "Employees"
SET 
	"Name" = COALESCE(@Name, "Name"),
	"Surname" = COALESCE(@Surname, "Surname"),
	"Phone" = COALESCE(@Phone, "Phone"),
	"CompanyId" = CASE WHEN @CompanyId > 0 THEN @CompanyId ELSE "CompanyId" END,
	"PassportId" = CASE WHEN @PassportId > 0 THEN @PassportId ELSE "PassportId" END,
	"DepartmentId" = CASE WHEN @DepartmentId > 0 THEN @DepartmentId ELSE "DepartmentId" END
WHERE "Id" = @Id
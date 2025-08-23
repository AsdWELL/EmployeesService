UPDATE "Departments"
SET 
    "Name" = COALESCE(@Name, "Name"),
    "Phone" = COALESCE(@Phone, "Phone")
WHERE "Id" = @Id
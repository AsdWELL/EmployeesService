UPDATE "Companies"
SET 
    "Name" = COALESCE(@Name, "Name")
WHERE "Id" = @Id
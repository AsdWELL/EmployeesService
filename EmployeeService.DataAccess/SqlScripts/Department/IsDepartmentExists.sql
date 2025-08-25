SELECT EXISTS(
	SELECT 1 FROM "Departments"
	WHERE "Id" = @Id
)
INSERT INTO "Departments" ("Name", "Phone")
VALUES (@Name, @Phone)
RETURNING "Id"
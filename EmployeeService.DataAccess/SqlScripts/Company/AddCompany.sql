INSERT INTO Companies ("Name", "Inn")
VALUES (@Name, @Inn)
RETURNING "Id"
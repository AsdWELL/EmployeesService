CREATE TABLE IF NOT EXISTS "Employees" (
	"Id" SERIAL PRIMARY KEY,
	"Name" TEXT NOT NULL,
	"Surname" TEXT NOT NULL,
	"Phone" TEXT NOT NULL,
	"CompanyId" INTEGER REFERENCES "Companies"("Id") ON DELETE SET NULL,
	"PassportId" INTEGER REFERENCES "Passports"("Id") ON DELETE SET NULL,
	"DepartmentId" INTEGER REFERENCES "Departments"("Id") ON DELETE SET NULL
);

CREATE INDEX CompanyIdIndex ON "Employees" ("CompanyId");
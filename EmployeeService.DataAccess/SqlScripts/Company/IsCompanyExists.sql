﻿SELECT EXISTS(
	SELECT 1 FROM "Companies"
	WHERE "Id" = @Id
)
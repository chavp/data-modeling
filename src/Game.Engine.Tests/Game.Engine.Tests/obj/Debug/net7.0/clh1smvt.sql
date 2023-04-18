BEGIN TRANSACTION;

ALTER TABLE "Blogs" ADD "Name" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230418071413_blogname', '7.0.5');

COMMIT;


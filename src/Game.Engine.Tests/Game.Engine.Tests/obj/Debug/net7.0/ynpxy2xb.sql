CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Blogs" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Blogs" PRIMARY KEY,
    "Url" TEXT NOT NULL
);

CREATE TABLE "Posts" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_Posts" PRIMARY KEY,
    "Title" TEXT NOT NULL,
    "Content" TEXT NOT NULL,
    "BlogId" TEXT NOT NULL,
    CONSTRAINT "FK_Posts_Blogs_BlogId" FOREIGN KEY ("BlogId") REFERENCES "Blogs" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Posts_BlogId" ON "Posts" ("BlogId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230418071058_InitialCreate', '7.0.5');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Blogs" ADD "Name" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230418071413_blogname', '7.0.5');

COMMIT;


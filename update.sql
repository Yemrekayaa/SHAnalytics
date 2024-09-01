CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Players" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Players" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "CreateTime" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240826235833_Test', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Players" ADD "TotalTime" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240830172454_test2', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Players" ADD "TotalPlayed" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240830180952_Player_Add_TotalPlayed', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Sessions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Sessions" PRIMARY KEY AUTOINCREMENT,
    "PlayerId" INTEGER NOT NULL,
    "SessionTime" INTEGER NOT NULL,
    "Difficulty" TEXT NOT NULL,
    CONSTRAINT "FK_Sessions_Players_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "Players" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Sessions_PlayerId" ON "Sessions" ("PlayerId");

CREATE TABLE "ef_temp_Players" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Players" PRIMARY KEY AUTOINCREMENT,
    "CreateTime" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "TotalPlayed" INTEGER NOT NULL DEFAULT 0,
    "TotalTime" INTEGER NOT NULL DEFAULT 0
);

INSERT INTO "ef_temp_Players" ("Id", "CreateTime", "Name", "TotalPlayed", "TotalTime")
SELECT "Id", "CreateTime", "Name", "TotalPlayed", "TotalTime"
FROM "Players";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Players";

ALTER TABLE "ef_temp_Players" RENAME TO "Players";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240830193220_Add_Session_Table', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Sessions" RENAME COLUMN "PlayerId" TO "InGameId";

DROP INDEX "IX_Sessions_PlayerId";

CREATE INDEX "IX_Sessions_InGameId" ON "Sessions" ("InGameId");

ALTER TABLE "Sessions" ADD "DeathCause" TEXT NOT NULL DEFAULT '';

ALTER TABLE "Sessions" ADD "EndCause" TEXT NOT NULL DEFAULT '';

ALTER TABLE "Sessions" ADD "SelectedHero" TEXT NOT NULL DEFAULT '';

CREATE TABLE "InGames" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_InGames" PRIMARY KEY AUTOINCREMENT,
    "PlayerId" INTEGER NOT NULL,
    "TotalTime" INTEGER NOT NULL,
    "CreatedTime" TEXT NOT NULL,
    "GameVersion" REAL NOT NULL,
    CONSTRAINT "FK_InGames_Players_PlayerId" FOREIGN KEY ("PlayerId") REFERENCES "Players" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_InGames_PlayerId" ON "InGames" ("PlayerId");

CREATE TABLE "ef_temp_Sessions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Sessions" PRIMARY KEY AUTOINCREMENT,
    "DeathCause" TEXT NOT NULL,
    "Difficulty" TEXT NOT NULL,
    "EndCause" TEXT NOT NULL,
    "InGameId" INTEGER NOT NULL,
    "SelectedHero" TEXT NOT NULL,
    "SessionTime" INTEGER NOT NULL,
    CONSTRAINT "FK_Sessions_InGames_InGameId" FOREIGN KEY ("InGameId") REFERENCES "InGames" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_Sessions" ("Id", "DeathCause", "Difficulty", "EndCause", "InGameId", "SelectedHero", "SessionTime")
SELECT "Id", "DeathCause", "Difficulty", "EndCause", "InGameId", "SelectedHero", "SessionTime"
FROM "Sessions";

CREATE TABLE "ef_temp_Players" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Players" PRIMARY KEY AUTOINCREMENT,
    "CreateTime" TEXT NOT NULL,
    "Name" TEXT NOT NULL
);

INSERT INTO "ef_temp_Players" ("Id", "CreateTime", "Name")
SELECT "Id", "CreateTime", "Name"
FROM "Players";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Sessions";

ALTER TABLE "ef_temp_Sessions" RENAME TO "Sessions";

DROP TABLE "Players";

ALTER TABLE "ef_temp_Players" RENAME TO "Players";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Sessions_InGameId" ON "Sessions" ("InGameId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240830230136_Add_InGame_Table', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "BattleAreas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_BattleAreas" PRIMARY KEY AUTOINCREMENT,
    "SessionId" INTEGER NOT NULL,
    "Size" INTEGER NOT NULL,
    "Type" TEXT NOT NULL,
    CONSTRAINT "FK_BattleAreas_Sessions_SessionId" FOREIGN KEY ("SessionId") REFERENCES "Sessions" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_BattleAreas_SessionId" ON "BattleAreas" ("SessionId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240901033420_Add_BattleArea_Table', '8.0.8');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Battles" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Battles" PRIMARY KEY AUTOINCREMENT,
    "BattleAreaId" INTEGER NOT NULL,
    "BattleNumber" INTEGER NOT NULL,
    CONSTRAINT "FK_Battles_BattleAreas_BattleAreaId" FOREIGN KEY ("BattleAreaId") REFERENCES "BattleAreas" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Battles_BattleAreaId" ON "Battles" ("BattleAreaId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240901040146_Add_Battle_Table', '8.0.8');

COMMIT;


DROP TABLE [dbo].[Engage_Army];
DROP TABLE [dbo].[Engage_Unit_Rules];
DROP TABLE [dbo].[Engage_Unit_Wargear];
DROP TABLE [dbo].[Engage_RulesUpgrades];
DROP TABLE [dbo].[Engage_WargearUpgrades];
DROP TABLE [dbo].[Engage_Unit];

IF OBJECT_ID(N'[dbo].[Engage_Army]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_Army] (
		ArmyID int NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Engage_Army] PRIMARY KEY,
		ArmyName nvarchar(60) NOT NULL,
		MaxPoints int NOT NULL
	);
END
GO

IF OBJECT_ID(N'[dbo].[Engage_Unit]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_Unit] (
		UnitId int NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Engage_Unit] PRIMARY KEY,
		ArmyId int NOT NULL,
		UnitType int NOT NULL,
		Squad int,
		Size int NOT NULL
	);
END
GO

IF OBJECT_ID(N'[dbo].[Engage_RulesUpgrades]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_RulesUpgrades] (
		RuleID int NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Engage_RulesUpgrades] PRIMARY KEY,
		RuleName nvarchar(30) NOT NULL
	);
END
GO

IF OBJECT_ID(N'[dbo].[Engage_WargearUpgrades]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_WargearUpgrades] (
		WargearID int NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Engage_WargearUpgrades] PRIMARY KEY,
		Wargear nvarchar(60) NOT NULL
	);
END 
GO

IF OBJECT_ID(N'[dbo].[Engage_Unit_Rules]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_Unit_Rules] (
		UnitID int NOT NULL CONSTRAINT [FK_Engage_Unit_Rules_Unit] FOREIGN KEY REFERENCES [dbo].[Engage_Unit] (UnitId),
		RuleID int NOT NULL CONSTRAINT [FK_Engage_Unit_Rules_Rule] FOREIGN KEY REFERENCES [dbo].[Engage_RulesUpgrades] (RuleID),
		PRIMARY KEY (UnitID, RuleID)
	);
END
GO

IF OBJECT_ID(N'[dbo].[Engage_Unit_Wargear]') IS NULL
BEGIN
	CREATE TABLE [dbo].[Engage_Unit_Wargear] (
		UnitID int NOT NULL CONSTRAINT [FK_Engage_Unit_Wargear_Unit] FOREIGN KEY REFERENCES [dbo].[Engage_Unit] (UnitId),
		WargearID int NOT NULL CONSTRAINT [FK_Engage_Unit_Wargear_Rule] FOREIGN KEY REFERENCES [dbo].[Engage_WargearUpgrades] (WargearID),
		Amount int NOT NULL,
		PRIMARY KEY (UnitID, WargearID)
	);
END
GO

INSERT INTO [dbo].[Engage_WargearUpgrades] (Wargear) 
VALUES ('Scything Talons'),
       ('Spinefists'),
       ('Deathspitter'),
       ('Barbed Strangler'),
       ('Venom Cannon'),
       ('Twin-linked Deathspitter'),
       ('Twin-linked Devourer with Brainleech Worms'),
       ('Stranglethorn Cannon'),
       ('Heavy Venom Cannon'),
       ('Rending Claws'),
       ('Boneswords'),
       ('Lash Whip and Bonesword'),
       ('Crushing Claws'),
       ('Bone Sabres'),
       ('Devourer'),
       ('Stinger Salvo'),
       ('Acid Spray'),
       ('Fleshborer'),
       ('Impaler Cannon'),
       ('Bio-electric Pulse'),
       ('Bio-electric Pulse with Containment Spines'),
       ('Bio-Plasma'),
       ('Bio-Plasmic Cannon'),
       ('Cluster Spines'),
       ('Drool Cannon'),
       ('Dessicator Larvae'),
       ('Electroshock Grubs'),
       ('Shreddershard Beetles'),
       ('Spike Rifle'),
       ('Spore Mine Cysts'),
       ('Spore Mine Launcher'),
       ('Strangleweb'),
       ('Tentaclids'),
       ('The Maw-claws of Thyrax'),
       ('The Miasma Cannon'),
       ('The Reaper of Obliterax'),
       ('Shock Cannon'),
       ('Fleshborer Hive'),
       ('Rupture Cannon'),
	   ('Lash Whips'),
	   ('Toxic Miasma'),
	   ('Twin-linked Stranglethorn Cannon'),
	   ('Twin-linked Heavy Venom Cannon'),
	   ('Spore Mine Launcher'),
	   ('Flamespurt');

INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Acid Blood');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Acid Maw');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Adrenal Glands');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Regeneration');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Flesh Hooks');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Spine Banks');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Toxin Sacs');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Wings');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('The Norn Crown');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('The Ymgarl Factor');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Indescribable Horror');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Old Adversary');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Hive Commander');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Deep Strike');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Prehensile Pincer');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Bone Mace');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Thresher Scythe');
INSERT INTO [Engage_RulesUpgrades] (RuleName) VALUES ('Toxinspike');
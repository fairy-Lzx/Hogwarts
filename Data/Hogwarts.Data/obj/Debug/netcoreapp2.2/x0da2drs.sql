IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [IdentityRole] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_IdentityRole] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tb_class] (
    [c_id] int NOT NULL,
    [c_name] varchar(50) NULL,
    [dean] varchar(50) NULL,
    CONSTRAINT [PK_tb_class] PRIMARY KEY ([c_id])
);

GO

CREATE TABLE [tb_course] (
    [cno] int NOT NULL,
    [cname] varchar(50) NULL,
    CONSTRAINT [PK_tb_course] PRIMARY KEY ([cno])
);

GO

CREATE TABLE [tb_teacher] (
    [t_id] int NOT NULL,
    [t_name] varchar(30) NULL,
    [sex] nvarchar(10) NULL,
    [birthday] datetime NULL,
    [cno] nvarchar(10) NULL,
    CONSTRAINT [PK_tb_teacher] PRIMARY KEY ([t_id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [IdentityRole] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [tb_student] (
    [sno] int NOT NULL,
    [sname] varchar(50) NULL,
    [sex] varchar(10) NULL,
    [birthday] datetime NULL,
    [year] int NULL,
    [classno] int NULL,
    [character] varchar(40) NULL,
    [pwd] varchar(36) NULL,
    CONSTRAINT [PK_tb_student] PRIMARY KEY ([sno]),
    CONSTRAINT [FK_tb_student_tb_class] FOREIGN KEY ([classno]) REFERENCES [tb_class] ([c_id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [IdentityUser] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [Tid] int NOT NULL,
    CONSTRAINT [PK_IdentityUser] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IdentityUser_tb_teacher_Tid] FOREIGN KEY ([Tid]) REFERENCES [tb_teacher] ([t_id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TC] (
    [t_id] int NOT NULL,
    [cno] int NOT NULL,
    CONSTRAINT [PK_TC] PRIMARY KEY ([t_id], [cno]),
    CONSTRAINT [FK_TC_tb_course] FOREIGN KEY ([cno]) REFERENCES [tb_course] ([cno]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TC_tb_teacher] FOREIGN KEY ([t_id]) REFERENCES [tb_teacher] ([t_id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [tb_SC] (
    [sno] int NOT NULL,
    [cno] int NOT NULL,
    [score] varchar(36) NULL,
    CONSTRAINT [PK_tb_SC] PRIMARY KEY ([sno], [cno]),
    CONSTRAINT [FK_tb_SC_tb_course] FOREIGN KEY ([cno]) REFERENCES [tb_course] ([cno]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tb_SC_tb_student] FOREIGN KEY ([sno]) REFERENCES [tb_student] ([sno]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [IdentityRole] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_IdentityUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [IdentityUser] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [IdentityRole] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [EmailIndex] ON [IdentityUser] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [IdentityUser] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE UNIQUE INDEX [IX_IdentityUser_Tid] ON [IdentityUser] ([Tid]);

GO

CREATE INDEX [IX_tb_SC_cno] ON [tb_SC] ([cno]);

GO

CREATE INDEX [IX_tb_student_classno] ON [tb_student] ([classno]);

GO

CREATE INDEX [IX_TC_cno] ON [TC] ([cno]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191205133131_init', N'2.2.6-servicing-10079');

GO


CREATE TABLE [dbo].[Account] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NCHAR(50)     NOT NULL,
    [Password] NCHAR(50)     NOT NULL,
    [Email]    NCHAR(50)     NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);


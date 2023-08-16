CREATE TABLE [Logs] (
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[OldSum] DECIMAL(18, 2) NOT NULL,
	[NewSum] DECIMAL(18, 2) NOT NULL
);

CREATE TRIGGER [tr_AddToLogsOnAccountUpdate]
			ON [Accounts] 
		   FOR UPDATE
			AS
				INSERT INTO [Logs] 
					 VALUES (
							(SELECT [Id] FROM inserted), 
							(SELECT [Balance] FROM deleted), 
							(SELECT [Balance] FROM inserted)
							);
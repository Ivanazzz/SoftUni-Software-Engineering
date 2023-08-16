CREATE TABLE [NotificationEmails] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL,
	[Subject] VARCHAR(200) NOT NULL,
	[Body] VARCHAR(MAX) NOT NULL
);

CREATE TRIGGER [tr_CreateNewEmailOnNewLogEntry]
			ON [Logs] 
	FOR INSERT
			AS
				INSERT INTO [NotificationEmails] 
					 VALUES (
								(SELECT [AccountId] FROM inserted),
								(SELECT 'Balance change for account: ' + CAST([AccountId] AS VARCHAR(255)) FROM inserted),
								(SELECT 'On ' + 
									FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + 
									' your balance was changed from ' + 
									CAST([OldSum] AS VARCHAR(255)) + 
									' to ' + 
									CAST([NewSum] AS VARCHAR(255)) + 
									'.' 
								   FROM inserted)
							);
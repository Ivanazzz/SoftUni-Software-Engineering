USE [master]

BACKUP DATABASE [SoftUni]
	TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\softuni-backup.bak' 

GO

DROP DATABASE [SoftUni]

GO

RESTORE DATABASE [SoftUni] 
	FROM DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\softuni-backup.bak'
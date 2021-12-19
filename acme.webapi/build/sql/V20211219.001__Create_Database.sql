IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'acme')
CREATE DATABASE acme
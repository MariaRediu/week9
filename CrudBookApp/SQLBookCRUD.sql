CREATE TABLE [Book](
       [BookId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
       [Title] [varchar](50) NULL,
       [PublisherId] [int] NULL,
       [Year] [int] NULL,
       [Price] [decimal](18, 0) NULL
       )
GO
SET IDENTITY_INSERT Book On
SELECT CAST(scope_identity() AS int)

select *from  Book
delete from Book
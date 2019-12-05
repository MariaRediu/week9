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

insert into Book([Title],[PublisherId],[Year],[Price])
values('Mara',2,1966,20)
insert into Book([Title],[PublisherId],[Year],[Price])
values('Fluturi',1,2010,30)
insert into Book([Title],[PublisherId],[Year],[Price])
values('English for everyone',4,2010,45)
insert into Book([Title],[PublisherId],[Year],[Price])
values('Ion',5,1966,70)
update Book set Year=1876 where price=70
insert into Book([Title],[PublisherId],[Year],[Price])
values('The Huntress',6,2019,100)

--All the books that are published in 2010

select  [Title], Year
from Book
where Year=2010

select  Title ,Year 
from Book
where Price=(select MAX(Price) as MaxPrice from Book)

SELECT TOP 10 *FROM  Book
CREATE TABLE [Publisher](
    [PublisherId] [int] NOT NULL,
    [Name] [varchar](50) NULL,
    CONSTRAINT [pk_publisher] PRIMARY KEY CLUSTERED
    (
        [PublisherId] ASC
    ) WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

CREATE TABLE [Book](
       [BookId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
       [Title] [varchar](50) NULL,
       [PublisherId] [int] NULL,
       [Year] [int] NULL,
       [Price] [decimal](18, 0) NULL
       )
GO
ALTER TABLE [Book]  WITH CHECK ADD  CONSTRAINT [fk_book_publisherid] FOREIGN KEY([PublisherId])
REFERENCES [Publisher] ([PublisherId])
ON DELETE CASCADE
GO
ALTER TABLE [Book] CHECK CONSTRAINT [fk_book_publisherid]
GO


INSERT INTO [Publisher] ([PublisherId],[Name])
VALUES (1,'MARKUS ZUSAK ');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (2,' Suzanne Collins ');
update [Publisher] set Name= 'SUZANNE COLLINS' where [PublisherId]=2
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (3,' Lev Tosloi ');
update [Publisher] set Name= 'LEV TOSLOI' where [PublisherId]=3
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (4,' IRINA BINDER  ');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (5,' IRINA BINDER ');
update [Publisher] set [Name]= ' IARINA BINDER ' where [PublisherId]=5
update [Publisher] set [PublisherId]= 4 where [Name]='IRINA BINDER '
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (6,' ALEX MICHAELIDES');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (7,' HEATHER MORRIS ');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (8,'KEVIN DUTTON, ANDY MCNAB');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (9,'ANTONIO G. ITURBE');
INSERT INTO [Publisher]([PublisherId],[Name])
VALUES (10,' KRISTIN HANNAH');


SET IDENTITY_INSERT Book On
insert into Book ([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (1,'Hoțul de cărți ',1,2010,85);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (2,'Jocurile foamei  ',2,2015,65);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (3,' Anna Karenina  ',3,1877,195);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (4,' Fluturi  ',4,2015,87);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (5,' Pana la sfarsit  ',6,2019,33);
update Book set [PublisherId]= 4 where BookId=5
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (6,' Pacienta tacuta  ',5,2018,28);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (7,' Tatuatorul de la Auschwitz  ',8,2018,23);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (8,' Abc-ul Psihopatului de succes ',9,2019,49);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (9,' Bibliotecara de la Auschwitz ',10,2016,45);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (10,' Aleea cu licurici',10,2019,39);
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (11,' Poezii',7,1965,19);
update Book set [PublisherId]= 11 where BookId=11
INSERT INTO Book([BookId],[Title],[PublisherId],[Year],[Price])
VALUES (12,' Poezii2',11,1965,12);

select *from [Book]
select *from [Publisher]

select 
*from Book as b
join [Publisher] as p
on b.BookId=p.PublisherId 


select Name from [Publisher]

SELECT COUNT(*) AS Counts FROM [Publisher]

SELECT TOP 10 *FROM  [Publisher]

--Number of books for each publisher(Publisher Name, Number of Books)
select p.PublisherId, p.Name ,COUNT(p.PublisherId) as NumberOfBook
from [Publisher] as p
join Book as b
on b.PublisherId=p.PublisherId
group by p.PublisherId, p.Name

--The total price for books for a publisher
select  PublisherId,sum(Price) as SumOfPrice from Book
group by PublisherId

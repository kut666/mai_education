CREATE TABLE TopTable(
T1 int,
T2 varchar(10)
)
GO

CREATE TABLE BottomTable(
B1 int,
B2 varchar(10)
)
GO

INSERT TopTable(T1, T2) VALUES
(1,'Text 1'),
(1,'Text 1'),
(2,'Text 2'),
(3,'Text 3'),
(4,'Text 4'),
(5,'Text 5')

INSERT BottomTable(B1,B2) VALUES
(2,'Text 2'),
(3,'Text 3'),
(6,'Text 6'),
(6,'Text 6')
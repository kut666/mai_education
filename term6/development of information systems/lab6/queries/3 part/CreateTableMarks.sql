CREATE TABLE Marks(
ID smallint PRIMARY KEY NOT NULL,
StudFK smallint,
ProfessorFK smallint,
DisciplineFK smallint,
mark smallint,
dateMark date
);
SELECT * FROM Marks
JOIN StudBachelors ON Marks.StudFK = StudBachelors.ID
JOIN Discipline ON Marks.DisciplineFK = Discipline.ID
JOIN Professor ON Marks.ProfessorFK = Professor.ID
WHERE Discipline.DiscipName = 'MO'
SELECT p.*, s.*
FROM Professor p
RIGHT JOIN StudBachelors s ON p.numDep = s.numDep
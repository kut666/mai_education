SELECT p.*, s.*
FROM Professor p
FULL JOIN StudBachelors s ON p.numDep = s.numDep
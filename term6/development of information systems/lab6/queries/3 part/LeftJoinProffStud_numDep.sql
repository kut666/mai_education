SELECT p.*, s.*
FROM Professor p
LEFT JOIN StudBachelors s ON p.numDep = s.numDep
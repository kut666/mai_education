SELECT StudBachelors.StudName, StudBachelors.Surname, StudBachelors.StudGroup
FROM StudBachelors

INTERSECT

SELECT StudMag.StudName, StudMag.Surname, StudMag.StudGroup
FROM StudMag
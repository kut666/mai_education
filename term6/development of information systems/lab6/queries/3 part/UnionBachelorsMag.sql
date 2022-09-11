SELECT StudBachelors.StudName, StudBachelors.Surname, StudBachelors.StudGroup
FROM StudBachelors

UNION

SELECT StudMag.StudName, StudMag.Surname, StudMag.StudGroup
FROM StudMag
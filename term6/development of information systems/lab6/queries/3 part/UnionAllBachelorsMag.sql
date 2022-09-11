SELECT StudBachelors.StudName, StudBachelors.Surname, StudBachelors.StudGroup
FROM StudBachelors

UNION ALL

SELECT StudMag.StudName, StudMag.Surname, StudMag.StudGroup
FROM StudMag
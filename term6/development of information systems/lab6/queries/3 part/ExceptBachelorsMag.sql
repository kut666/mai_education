SELECT StudBachelors.StudName, StudBachelors.Surname, StudBachelors.StudGroup
FROM StudBachelors

EXCEPT

SELECT StudMag.StudName, StudMag.Surname, StudMag.StudGroup
FROM StudMag
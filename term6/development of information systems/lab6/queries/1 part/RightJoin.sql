SELECT l.*, r.*
FROM LeftTable l
RIGHT JOIN RightTable r ON l.LCode = r.RCode

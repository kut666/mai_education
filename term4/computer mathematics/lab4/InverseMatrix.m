function [output2] = InverseMatrix(matrix)
[i, j] = size(matrix);
deter = round(det(matrix));
if (deter == 0)
    disp('Singular matrix!');
    return;
end

if (i == 2)
    temp = matrix(1,1);
    matrix(1,1) = matrix(2,2);
    matrix(2,2) = temp;
    matrix(1,2) = -matrix(1,2);
    matrix(2,1) = -matrix(2,1);
    output2 = (1 / deter) * matrix;
    return;
elseif(i == 1)
    output2 = 1/matrix;
    return;
end

invBlock1 = InverseMatrix(matrix(1:end-1, 1:end-1));
block2 = matrix(1:end-1, end);
block3 = matrix(end, 1:end-1);
block4 = matrix(end, end);
x = invBlock1 * block2;
y = block3 * invBlock1;
teta = block4 - y * block2;
teta = InverseMatrix(teta);

a1 = invBlock1 + (x*teta)*y;
a2 = (-x)*teta;
a3 = (-teta)*y;
a4 = teta;
output2 = [a1, a2; a3, a4];
end

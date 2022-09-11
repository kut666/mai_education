function [product] = MatrixMultiplication(first, second)
[rows1, columns1] = size(first);
[rows2, columns2] = size(first);
if(rows1 <= 2 && columns1 <= 2 && rows2 <= 2 && columns2 <= 2)
    product = first * second;
else
    div11 = length(first(1, :));
    div12 = ceil(div11/2);
    div13 = length(first(:, 1));
    div14 = ceil(div13/2);
    div21 = length(second(1, :));
    div22 = ceil(div21/2);
    div23 = length(second(:, 1));
    div24 = ceil(div23/2) ;
    first1 = first(1:div14, 1:div12);
    first2 = first(1:div14, div12+1:div11);
    first3 = first(div14+1:div13, 1:div12);
    first4 = first(div14+1:div13, div12+1:div11);
    second1 = second(1:div24, 1:div22);
    second2 = second(1:div24, div22+1:div21);
    second3 = second(div24+1:div23, 1:div22);
    second4 = second(div24+1:div23, div22+1:div21);
    product1 = MatrixMultiplication(first1, second1) + MatrixMultiplication(first2, second3);
    product2 = MatrixMultiplication(first1, second2) + MatrixMultiplication(first2, second4);
    product3 = MatrixMultiplication(first3, second1) + MatrixMultiplication(first4, second3);
    product4 = MatrixMultiplication(first3, second2) + MatrixMultiplication(first4, second4);
    product = [product1 product2; product3 product4];
end
end
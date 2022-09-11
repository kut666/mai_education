function [output1] = LeVerrierMethod(matrix)
[rows, columns] = size(matrix);
identity = eye(rows);
output1(1) = 1;
sum = 0;
traces = [];

for i=1:rows
    traces(i) = trace(matrix ^ i);
    if(i ~= 1)
        for j=1:i-1
            sum = sum + output1(j+1)*traces(i-j);
        end
    end
    output1(i+1) = -(sum + traces(i)) / i;
    sum = 0;
end
end
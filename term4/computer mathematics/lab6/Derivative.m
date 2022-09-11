function [] = Derivative(func, interval, step)
n = size(func, 2);
x = interval(1);
table(1:n, 2) = func;
for i=1:n
    table(i, 1) = x;
    x = x + step; 
    if(i > 1)
        for k=3:5
            if (i-k+2 == 0)
                break;
            end
            table(i-k+2, k) = table(i-k+3, k-1) - table(i-k+2, k-1);
        end
    end
end
width = size(table, 2);
for i=1:n
    table(i, 6) = 0;
    for j=3:5
        table(i, 6) = table(i, 6) + ((-1)^(j-3))*table(i, j) / (j-2);
    end
    table(i, 6) = table(i, 6) / step;
end
plot(table(1:end, 1), table(1:end, 2),table(1:end-1, 1), table(1:end-1, end));
end


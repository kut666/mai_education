function [output1] = newton(p)

c = 1;
i = 2;
q = p;
if (q(1) < 0)
        q = q * (-1);
end

der = {};
der{1} = q;
while (size(q,2) > 2)
    der{i} = (derivative(q));
    q = derivative(q);
    i = i + 1;
end

i = size(der,2);
while (i >= 1)
    a = der{i};
    while (Gorner(a,c) < 0)
        c = c + 1;
    end
    i = i - 1;
end

output1 = c;
end
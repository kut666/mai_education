function [output1] = derivative(p)

k = 0;
q = p;
i = (length(p));
while(i >= 1)
        q(i) = p(i)*k;
        k = k+1;
        i = i-1;
end

output1 = q(1:end-1);
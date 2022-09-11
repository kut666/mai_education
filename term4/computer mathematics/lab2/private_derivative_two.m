function [output5,output6] = private_derivative_two(p)

s1 = size(p,1);
s2 = size(p,2);
k = 0;

for j = 1 : s1
    while(s2 >= 1)
        q(s2) = p(j,s2)*k;
        k = k+1;
        s2 = s2-1;
    end
    k = 0;
    u1(j,:) = q(1:end-1);
    s2 = size(p,2);
end

while (s1 >= 1)
    for i = 1 : s2
        q(i) = p(s1,i)*k;
    end
    k=k+1;
    
    u2(s1,:) = q;
    s1 = s1-1;
end

output5 = u1;

output6 = u2(1:end-1,:);
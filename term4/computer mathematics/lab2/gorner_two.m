function [output4] = gorner_two(p,a)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here

s1 = size(p,1);
s2 = size(p,2);
q(1)= p(1,1);

for j = 1 : s1
    for i = 2 : s2 
        q(i)= q(i-1)*a(1)+p(j,i); 
    end
    u(j) = q(end);
    if (j ~= s1)
        q(1)= p(j+1,1);
    end
end

output4 = gorner(u,a(2));

end
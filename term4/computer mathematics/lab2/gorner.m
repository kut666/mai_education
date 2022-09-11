function [output1, output2] = gorner(p,a)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here

q(1)=p(1);

for i = 2 : length(p)
        q(i)= q(i-1)*a+p(i);
end

output1=q(end);
output2=q(1:end-1); 


end


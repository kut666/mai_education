function [output1, output2] = gorner(p,a)
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here

q(1)=p(1); % присваиваем значение первого элемента массива p первому элементу q

for i = 2 : length(p) % цикл от 2 до конца массива p
        q(i)= q(i-1)*a+p(i); % сама схема стр. 76
end
output1=q(end);  % результат полинома в точке а
output2=q(1:end-1);   % все остальное


end


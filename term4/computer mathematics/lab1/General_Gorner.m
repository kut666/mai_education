function [ output3 ] = General_Gorner (p,a)
%UNTITLED5 Summary of this function goes here
%   Detailed explanation goes here

    for i = 1: length(p)
        [q(i),p] = Gorner(p, a);  % стр. 79
    end
output3 = flip(q);  % переворачивает массив
end


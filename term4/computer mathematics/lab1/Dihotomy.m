function [ output5 ] = Dihotomy(p)
%UNTITLED10 Summary of this function goes here
%   Detailed explanation goes here
a=BordersDown(p);
b=BordersUp(p);

c=(a+b)/2;
    while (abs(Gorner (p,c)) > 0.001)
        if ((Gorner(p,a) * Gorner(p,c)) < 0)
            b=c;
        else
            a=c;
        end
        c=(a+b)/2;
    end
    output5 = c;
end


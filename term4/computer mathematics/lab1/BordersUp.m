function [ output4a ] = BordersUp(p)

i=0;
b=p;
    while any(b < 0)
         i=i+1;
        [x,b] = Gorner(p,i);
    end
    output4a = i;
end


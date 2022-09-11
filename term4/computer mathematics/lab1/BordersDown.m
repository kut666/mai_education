function [ output4b ] = BordersDown(p)

for i = 1 : length(p)
    if(rem(i,2)==0)
        b(i)=-p(i);
    else
        b(i)=p(i);
    end
    output4b=-BordersUp(b);

end


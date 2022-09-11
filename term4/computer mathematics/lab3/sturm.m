function [output4] = sturm(p)

Ninf_plus = 0;
Ninf_minus = 0;

st{1} = {p};
drp = derivative(p);
if (drp(1) ~= 1 && drp(1) ~= -1 && drp(1) ~= 0)
       drp = drp / abs(drp(1)); 
end
st{2} = {drp};   
i = 3;
p3 = [0,1];
while (size(p3,2) > 1)
    p1 = cell2mat(st{i-2});
    p2 = cell2mat(st{i-1});
    if (size(p2,2) == 1)
        break
    end
    [~,p3] = synth_division(p1,p2);
    if (p3(1) ~= 1 && p3(1) ~= -1 && p3(1) ~= 0)
       p3 = p3 / abs(p3(1));
    end
    p3 = p3 * (-1);
    k = size(p3,2);
    while (k > 0)
        if isnan(p3(k))
            p3(k)=[];
        end
        k = k - 1;
    end
    st{i} = {p3};
    i = i + 1;
end
for i = 1 : size(st,2)-1
    tmp1 = cell2mat(st{i});
    tmp2 = cell2mat(st{i+1});
    if (sign(Gorner(tmp1,inf)) ~= sign(Gorner(tmp2,inf)))
        Ninf_plus = Ninf_plus + 1;
    end
    if (sign(Gorner(tmp1,-inf)) ~= sign(Gorner(tmp2,-inf)))
        Ninf_minus = Ninf_minus + 1;
    end
end

output4 = Ninf_minus - Ninf_plus;
end
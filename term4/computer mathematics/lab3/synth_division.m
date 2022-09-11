function [output2, output3] = synth_division(p1,p2)

p1Length = size(p1, 2);
p2Length = size(p2, 2);

ans = zeros(p2Length + 2, p1Length + 1);
ans(1, 2:end) = p1;
ans(2:p2Length, 1) = fliplr(p2(2:end));
ans(p2Length + 1, 2) = p1(1);
ans(p2Length + 2, 2) = p1(1) / -p2(1);
diagonalp2 = fliplr(diag(flip(p2(2:end))));
for i = 1:p1Length - 1
    if (i < p1Length - p2Length + 2)
        ans(p2Length + 2, 1 + i) = ans(p2Length + 1, 1 + i) / -p2(1);
        ans(2:p2Length, 2 + i:p2Length + i) = ans(2:p2Length, 2 + i:p2Length + i) + diagonalp2 * ans(p2Length + 2, 1 + i);
    end
    ans(p2Length + 1, 2 + i) = sum(ans(1:end, 2 + i));
end
if(abs(p2(1)) ~= 1)
    output2 = ans(p2Length + 2, 2:p1Length - p2Length + 2);
    output3 = ans(p2Length + 1, 2:p1Length + 1);
else
    output2 = ans(p2Length + 2, 2:p1Length - p2Length + 2);
    output3 = ans(p2Length + 1, p1Length - p2Length + 3:p1Length + 1);
end
end
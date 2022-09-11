function [output2] = chord(p,b)

a = b - 0.5;
eps = 0.001;
p1 = gorner(p,a);
p2 = gorner(p,b);
x1 = 0;
x2 = 0;
if (p1 == 0)
    output2 = a;
    return;
end
if (p2 == 0)
   output2 = b;
   return;
end
while ( p1*p2 > 0)
    a = a - 0.5;
    b = b - 0.5;
    p1 = gorner(p,a);
    p2 = gorner(p,b);
end
  x1 = a - (gorner(p, a))*(b-a)/(gorner(p, b)-gorner(p, a));
  x2 = x1 - (gorner(p, x1))*(b-x1)/(gorner(p, b)-gorner(p, x1));
while (abs(x1 - x2) > eps)
      x1 = x2;
      x2 = x1 - ((gorner(p, x1))*(b-x1))/(gorner(p, b)-gorner(p, x1));
end
output2 = x2;
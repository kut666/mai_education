function [output3] = newton(p,b)

a = b - 0.5;
eps = 0.001;
p1 = gorner(p,a);
p2 = gorner(p,b);
x1 = 0;
x2 = 0;

while ( p1*p2 > eps)
    a = a - 0.5;
    b = b - 0.5;
    p1 = gorner(p,a);
    p2 = gorner(p,b);
end

if ((gorner(p,a)*gorner((derivative(derivative(p))),a)) > 0) 
  x1 = a;
else
    x1 = b;
end
 x2 = x1 - gorner(p,x1)/gorner((derivative(p)),x1);
 
while (gorner(p,x1)/gorner((derivative(p)),x1) > eps)
    x2 = x1 - gorner(p,x1)/gorner((derivative(p)),x1);
    x1 = x2;
end

if (p1 == 0)
    output3 = a;
    return;
end
if (p2 == 0)
   output3 = b;
   return;
end

output3 =x2;
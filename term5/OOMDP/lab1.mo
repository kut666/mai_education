model lab1

parameter Integer n = 5;
parameter Integer a = 5;
parameter Integer b = 10;
parameter Integer c = 8;
parameter Integer d = 2;

Real x1[n];
Real x2[n];
Real t1;
Real t2;

initial equation
for i in 1:n loop
x1[i] = 1 + 0.1*i;
x2[i] = 1 - 0.1*i;
end for;

equation
for i in 1:n loop
der(x1[i]) = x1[i] * (a - b * x2[i]);
der(x2[i]) = -x2[i] * (c - d * x1[i]);
end for;
t1 = c/d;
t2 = a/b;
end lab1;

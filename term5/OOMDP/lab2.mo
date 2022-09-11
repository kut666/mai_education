model lab2

Real x(start = -8);
Real v(start = 1);
Real flag(start = 0);
parameter Real a = 2;
//parameter Real b = 3;
parameter Real k1 = 7;
parameter Real k2 = 3;
parameter Real k3 = 35;
parameter Real k4 = sqrt(3);
parameter Real k5 = 1;
Real F;


//equation
//if x < 0 then
//  F = -k1;
//else
//  F = k1;
//end if;

equation
if flag == 0 then
  if x < a then
    F = -k1;
    flag = 0;
  else
    F = k1;
    flag = 1;
  end if;
else
  if x <= a then 
    if x > -a then
      F = k1;
      flag = 1;
    else
      F = -k1;
      flag = 0;
    end if;
  end if; 
end if;


//equation 
//if flag == 0 then
//  if x < -a then
//    F = -k1;
//    flag = 0;
//  else
//    F = 0;
//    flag = 1;
//  end if;
//elseif flag == 1 then
//  if x > b then
//    F = k1;
//    flag = 2;
//  elseif x < -b then
//    F = -k1;
//    flag = 0;
//  else
//    F = 0;
//    flag = 1;
//  end if;
//else
//  if x > a then
//    F = k1;
//    flag = 2;
//  else
//    F = 0;
//    flag = 1;
//  end if;
//end if;

der(x) = v;
der(v) = -F - k2 * x + k3 * sin(k4 * time)-k5*v;

end lab2;

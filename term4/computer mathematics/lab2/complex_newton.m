function [output7, output8] = complex_newton(F, G)
  eps = 0.001;
  [dFdx, dFdy] = private_derivative_two(F);
  [dGdx, dGdy] = private_derivative_two(G);
  R = 1;
  Im = 1;
  F_val = 1;
  G_val = 1;
  while (abs(G_val) >= eps) | (abs(F_val) >= eps)
    F_val = gorner_two(F, [R, Im]);
    G_val = gorner_two(G, [R, Im]);
    dFdx_val = gorner_two(dFdx, [R, Im]);
    dFdy_val = gorner_two(dFdy, [R, Im]);
    dGdx_val = gorner_two(dGdx, [R, Im]);
    dGdy_val = gorner_two(dGdy, [R, Im]);
    
    J_det = dFdx_val * dGdy_val - dFdy_val * dGdx_val;
    if J_det == 0
      return
    end
   
    h = (F_val * dGdy_val - dFdy_val * G_val) / J_det;
    k = (dFdx_val * G_val - F_val * dGdx_val) / J_det;
    
    R = R - h;
    Im = Im - k;
  end

output7 = R;
output8 = Im;
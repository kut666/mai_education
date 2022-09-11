function [output1] = Simpson(func, interval, step)
    x = interval(1) + step;
    sigmaOne = 0;
    sigmaTwo = 0;
    n = round((interval(2) - interval(1)) / (2 * step));
    
    for i=2:n+1
       sigmaOne = sigmaOne + 4 * func(x);
       x = x + 2 * step;
    end
    
    x = interval(1) + 2 * step;
    for i=2:n
       sigmaTwo = sigmaTwo + 2 * func(x);
       x = x + 2 * step;
    end
    
    output1 = (func(interval(1)) +func(interval(2)) + sigmaOne + sigmaTwo) * (step / 3);
end
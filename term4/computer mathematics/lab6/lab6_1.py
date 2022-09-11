import math
import numpy as np

def Simpson (func, ab, h):
    n = int(round((ab[1] - ab[0]) / (2 * h)))
    sigma1 = 0
    sigma2 =0
    i = 1
    x = ab[0] + h
    while (i < n + 1):
        sigma1 += 4 * func(x)
        x += 2 * h
        i += 1;
    i = 1
    x = ab[0] + 2 * h 
    while (i < n):
        sigma2 += 2 * func(x)
        x += 2 * h
        i += 1
    return (h/3) * (func(ab[0]) + func(ab[1]) +sigma1 + sigma2)


print (Simpson(lambda x: (math.sin(x)) ** 3 - (math.cos(x / 2)) ** 2 + 2, [-3,3], 0.2))
import math

def gorner (p,a):   
    q = p[:]
    q[0] = p[0]
    i = 1
    while i < len(p):
        q[i]= q[i-1]*a+p[i];
        i +=1
    s = q.pop()
    return s

def derivative (p):
    q = p[:]
    k = 0
    i = len(p) - 1
    while i >= 0:
        q[i] = p[i]*k
        i -= 1
        k += 1
    q.pop()
    return q

def chord (p,b):

    a = b - 0.5
    eps = 0.001
    p1 = gorner(p,a)
    p2 = gorner(p,b)
    x1 = 0
    x2 = 0

    while p1*p2 > eps:
        a = a - 0.5
        b = b - 0.5
        p1 = gorner(p,a)
        p2 = gorner(p,b)

    if (p2 == 0):
        return b

    x1 = a - (gorner(p, a))*(b-a)/(gorner(p, b)-gorner(p, a))
    x2 = x1 - (gorner(p, x1))*(b-x1)/(gorner(p, b)-gorner(p, x1))

    while (math.fabs(x1 - x2) > eps):
        x1 = x2
        x2 = x1 - ((gorner(p, x1))*(b-x1))/(gorner(p, b)-gorner(p, x1))

    return x2

def newton (p,b):

    a = b - 0.5
    eps = 0.001
    p1 = gorner(p,a)
    p2 = gorner(p,b)
    x1 = 0
    x2 = 0

    while p1*p2 > eps:
        a = a - 0.5
        b = b - 0.5
        p1 = gorner(p,a)
        p2 = gorner(p,b)

    if (p2 == 0):
        return b

    if ((gorner(p,a)*gorner((derivative(derivative(p))),a)) > 0):
        x1 = a
    else :
        x1 = b

    x2 = x1 - gorner(p,x1)/gorner((derivative(p)),x1)
 
    while gorner(p,x1)/gorner((derivative(p)),x1) > eps:
        x2 = x1 - gorner(p,x1)/gorner((derivative(p)),x1)
        x1 = x2

    return x2

print(derivative([1,1,1,1,1]))
print(chord([1, -4, -42, 104, 361, -420], 9))
print(newton([1, 3.7, -12.55, -31.525, 69.4914, 41.4407, -88.0729], 4))
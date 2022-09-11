import math
import numpy as np

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

def ring_border_up (p):
    q = p[:]
    while (q[-1] == 0):
        del(q[-1])
    a0 = q[0]
    del(q[0])
    A = max(q, key = abs)
    return (1 + abs(A) / abs(a0))

def ring_border_down (p):
    q = p[:]
    while (p[-1] == 0):
        del(p[-1])
    an = p[-1]
    del(p[-1])
    B = max(p, key = abs)
    return (1 / (1 + abs(B) / abs(an)))

def lagrange (p):
    a = []
    q = p[:]
    a0 = q[0]
    i = 0
    k = 0
    x = 0
    b = [-1]
    if (q[0] < 0):
        while (i <= len(q) - 1):
            q[i] = q[i] * (-1)
            i += 1
    i = 0
    while (q[i] >= 0):
        i += 1
    k = i
    i = 0
    while (i <= len(q) - 1):
        if (q[i] < 0):
            a.append(q[i]) 
            x += 1
        i += 1
    B = max(a, key = abs)
    return (1 + pow(abs(B/a0),(1/k)))

def newton (p):
    c = 1
    q = p[:]
    der = []
    der.append(q)
    while (len(q) > 1):
        der.append(derivative(q))
        q = derivative(q)
    i = len(der) - 1
    while (i >= 0):
        while (gorner(der[i],c) < 0):
            c += 1
        i -= 1
    return c

def synth_division (p1, p2): 
    q1 = np.copy(p1) 
    q2 = np.copy(p2)
    l = q2[0]
    q2 = q2 * (-1)
    q2 = np.delete(q2, 0)
    k = len(q1)
    n = len(q2)
    ans = np.zeros(shape = (n + 2, k + 1))
    i = 0
    while (k > 0):
        ans[0, i + 1] = q1[i]
        i += 1
        k -= 1
    i = 0
    while (n > 0):
        ans[i+1, 0] = q2[n - 1]
        n -= 1
        i += 1
    i = 1
    n1 = len(q2)
    n2 = len(q2)
    ans[n1 + 1 , i] = ans[0, i] / l
    k1 = len(q1)
    k2 = len(q1)
    i1 = 0
    i2 = 0
    i3 = 0
    x = k1 - n1
    while (x > 0):
        while (n1 > 0):
            ans[n1, i1 + 2] = ans[n1, 0] * ans[n2 + 1, i2 + 1]
            n1 -= 1
            i1 += 1
        n = len(q2)
        sum = 0
        while (n > -1):
            sum += ans[n, i2 + 2]
            n -= 1
        ans[n2 + 1,i2 + 2] = sum / l
        x -= 1
        n1 = len(q2)
        i3 += 1
        i1 = i3
        i2 += 1
    k = len(q1)
    while (i2 <= k-1):
        n = len(q2)
        sum = 0
        while (n > -1):
            sum += ans[n, i2 + 1]
            n -= 1
        n = len(q2)
        ans[n + 1,i2 + 1] = sum
        i2 += 1
    print(ans)
    return ans[n+1, 1:k-n+1], ans[n+1, k-n+1:k+1]


print(ring_border_down ([5,0,0,-1,0,-4]), ring_border_up ([5,0,0,-1,0,-4]))
print(lagrange ([-1,-2,-2,-5,0,-3,-4,2,-5,0]))
print(newton ([3,-32,0,288,853]))
print(synth_division ([ 2, -1, 3, -7 ], [ 4, -1, 2 ]))
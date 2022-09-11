#import math 
import numpy as np
import numpy.linalg as la

eps = 0.001


def trans(v):
    v_1 = np.copy(v)
    return v_1.reshape((-1, 1))


def power(A):
    eig = []
    Ac = np.copy(A)
    lamb = 0
    for i in range(2):
        x = np.array([1, 1, 1])
        while True:
            x_1 = Ac.dot(x) 
            x_norm = la.norm(x_1)
            x_1 = x_1/x_norm 
            if(abs(lamb - x_norm) <= eps):
                break
            else:
                lamb = x_norm
                x = x_1
        eig.append(lamb)
        if type((np.flip(np.linalg.eig(A)[0]))[0]) == np.complex128:
            eig.append((np.flip(np.linalg.eig(A)[0])[1]))
            z = eig[1].real - eig[1].imag*1j
            eig[0] = np.trace(A) - eig[1] - z
            break
        v = x_1/la.norm(x_1)
        R = v * trans(v)
        R = eig[i]*R
        Ac = Ac - R
    eig.append(np.trace(A) - np.sum(eig))
    return eig


A = np.array([[2.0,1.0, -4.0],[-3.0,4.0,0.0],[-3.0, -1.0,8.0]])

print(*power(A))
print(*np.flip(np.linalg.eig(A)[0]))









import math
import numpy as np

def Haletsky (R,A,i,j,k,sum1,sum2):
    m = j
    if ((i == 0) & (j == 0)):
        return math.sqrt(R[i,j])
    if (j == 0):
        return R[i,j]/A[j,j]

    if ((j > 0) & (k != 0)):
        print (i,j, ' i,j')
        print(k,'k')
      #  print((Haletsky(R,A,i,j - 1,k - 1,sum1,sum2))**2)
        print (sum2, 'сумма')
        sum2 = sum2 + (Haletsky(R,A,i,j - 1,k - 1,sum1,sum2))**2
        print(sum2, ' сумма после')
        return math.sqrt(R[i,j] - sum2)

    if ((j > 0) & (k == 0)):
   #     print (i,j)
      #  print(Haletsky(R,A,i,j-1,k,sum1,sum2) * Haletsky(R,A,m,j-1,k,sum1,sum2))
    #    print(sum1)
        sum1 = sum1 + Haletsky(R,A,i,j-1,k,sum1,sum2) * Haletsky(R,A,m,j-1,k,sum1,sum2)
     #   print(sum1)
        return (R[i,j] - sum1) #/ A[j,j]
    return 0

def Gauss ():

    #создание массива времени t
    step = 1
    tstart = step
    tfinish = 5
    t = np.arange(tstart, tfinish, step)
    l = t.size

    # моделирование ковариционной матрицы R
    R = np.zeros((l,l))
    i = 0
    j = 0
    while (i < l):
        j = 0
        while (j < l):
            R[i,j] = min(t[i],t[j])
            j = j + 1
        i = i + 1

    # моделирование нижнетреугольной матрицы А
    A = np.zeros((l,l))
    i = 0
    j = 0
    while (i < l):
        j = 0
        while (j != i + 1):
            sum1 = 0
            sum2 = 0
            m = j
            if (i == j):
                k = i
                A[i,j] = Haletsky(R,A,i,j,k,sum1,sum2)
            else:
                k = 0
                A[i,j] = Haletsky(R,A,i,j,k,sum1,sum2)
            j = j + 1
        i = i + 1

    a1 = np.random.random()
    a2 = np.random.random()
    print(R)
    print (np.linalg.cholesky(R))
    return A

print(Gauss())
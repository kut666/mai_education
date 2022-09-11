import numpy as np

def normalization_matrix(A):
    A1 = np.copy(A)
    for i in range(A1.shape[0]):
        a = A1[i,i]
        A1[i,i] = 0
        for j in range(A1.shape[1]):
            if i != j and j != A1.shape[1] - 1:
                A1[i,j] = A1[i,j] / -a
            elif j == A1.shape[1] - 1:
                A1[i,j] = A1[i,j] / a
    return A1


def norm(A):
    maxRow = 0
    sumRow = 0
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            sumRow += abs(A[j,i])
        if (maxRow < sumRow):
            maxRow = sumRow
        sumRow = 0
    return maxRow


def inverse_matrix(A):
    E = np.eye(A.shape[0])
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            if i != j:
                E[j,:] -= A[j,i] * E[i,:]
    return E

def multiply(A,B):
    C = np.zeros((A.shape[1], B.shape[0]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            for k in range(C.shape[1]):
                C[i,j] += A[i,k] * B[k,j]
    return C

def difference(A,B):
    C = np.zeros((A.shape[0], A.shape[1]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            C[i,j] = A[i,j] - B[i,j]
    return C

def simple_iteration(alfa,beta):
    e = 0.00001
    roots0 = np.zeros(len(beta))
    roots1 = np.ones(len(beta))
    error = np.zeros(len(beta))
    for i in range(len(roots0)):
            error[i] = (abs(roots0[i] - roots1[i]))
    m = max(error)
    k = 0
    while (m > e):
        for i in range(alfa.shape[0]):
            roots1[i]= 0
            for j in range(alfa.shape[1]):
                roots1[i] += alfa[i,j] * roots0[j]
            roots1[i] += beta[i]
        for i in range(len(roots0)):
            error[i] = abs(roots0[i] - roots1[i])
        m = (norm(alfa) * max(error)) / (1 - norm(alfa))
        roots0 = np.copy(roots1)
        k += 1
    return roots1, k


def zeidel(alfa,beta):
    e = 0.0001
    roots0 = np.zeros(len(beta))
    roots1 = np.ones(len(beta))
    error = []
    for i in range(len(roots0)):
            error.append(abs(roots0[i] - roots1[i]))
    m = max(error)
    B = np.zeros((alfa.shape[0], alfa.shape[1]))
    C = np.zeros((alfa.shape[0], alfa.shape[1]))
    for i in range(alfa.shape[0]):
        for j in range(alfa.shape[1]):
            if i >= j:
                B[i,j] = alfa[i,j]
            else:
                C[i,j] = alfa[i,j]
    E = np.eye(len(beta))
    EB_inv = inverse_matrix(difference(E,B))
    EB_invC = multiply(EB_inv, C)
    k = 0
    while (m > e):
        for i in range(alfa.shape[0]):
            roots1[i] = 0
            for j in range(alfa.shape[1]):
                roots1[i] += EB_invC[i,j] * roots0[j] + EB_inv[i,j] * beta[j]
        for i in range(len(roots0)):
            error[i] = abs(roots0[i] - roots1[i])
        m = (norm(C) * max(error) ) / (1 - norm(alfa))
        roots0 = np.copy(roots1)
        k += 1
    return roots1, k


def main(A):
    A1 = normalization_matrix(A)
    C1 = A1[:,0:-1]
    D1 = A1[:,-1]
    k1 = simple_iteration(C1,D1)[1]
    k2 = zeidel(C1,D1)[1]
    print("Методом простых итераций:\n",simple_iteration(C1,D1)[0])
    print("Методом Зейделя:\n", zeidel(C1, D1)[0])
    if k1 < k2:
        k = k2 - k1
        print("Методом простых итераций потребовалось ", k1," итераций, ","а методом Зейделя потребовалось ", k2," итераций\n"
            "Что на ", k, " итераций меньше\n")
    elif k1 > k2:
        k = k1 - k2
        print("Методом простых итераций потребовалось ", k1," итераций, ","а методом Зейделя потребовалось ", k2," итераций\n"
            "Что на ", k, " итераций больше\n")
    else:
        k = 0
        print("Методом простых итераций потребовалось ", k1," итераций, ","а методом Зейделя потребовалось ", k2," итераций\n"
            "Методы одинаково сходятся!\n")

A = np.array([[28.0, 9.0, -3.0, -7.0, -159.0],
              [-5.0, 21.0, -5.0, -3.0, 63.0],
              [-8.0, 1.0, -16.0, 5.0, -45.0],
              [0.0, -2.0, 5.0, 8.0, 24.0]])
main(A)

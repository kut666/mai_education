import numpy as np

def sign(x):
    if x > 0:
        return 1
    if x < 0:
        return -1
    else:
        return 0

def transpose(A):
    AT = np.zeros((A.shape[0], A.shape[1]))
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            AT[j,i] = A[i,j]
    return AT


def multiply(A,B):
    C = np.zeros((A.shape[0], A.shape[1]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            for k in range(C.shape[1]):
                C[i,j] += A[i,k] * B[k,j]
    return C

def division(A,B):
    C = np.zeros((A.shape[0], A.shape[1]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            C[i,j] = A[i,j] / B
    return C

def difference(A,B):
    C = np.zeros((A.shape[0], A.shape[1]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            C[i,j] = A[i,j] - B[i,j]
    return C


def norm_vector(b):
    norm = 0
    for i in range(len(b)):
        norm += b[i]*b[i]
    return np.sqrt(norm)


def Householder_matrix(H, index):
    H1 = np.copy(H)
    x1 = np.zeros(H1.shape[1])
    b = np.zeros(H1.shape[1])
    for k in range(H1.shape[1]):
        b[k] = H1[k,index] 
    norm = norm_vector(b)
    for i in range(H1.shape[0]):
            if i == index:
                x1[i] = H1[i,index] + sign(H1[i,index]) * norm
            elif i < index:
                x1[i] = 0
            else: 
                x1[i] = H1[i,index]
    v1 = np.zeros((len(x1),len(x1)))
    for i in range(v1.shape[1]):
        v1[i,0] = x1[i]
    v1_T = transpose(v1)
    E = np.eye(H1.shape[0])
    H1 = difference(E,2*(division(multiply(v1,v1_T),multiply(v1_T,v1)[0,0])))
    return H1


def QR(A):
    A0 = np.copy(A)
    H = []
    for i in range(A.shape[0] - 1):
        H0 = Householder_matrix(A0, i)
        A0 = multiply(H0, A0)
        H.append(H0)
    for i in range(len(H) - 1):
        H[i + 1] = multiply(H[i],H[i + 1])
    return A0, H[-1]

def eigenvalues(A):
    e = 0.001
    m = 1
    A0 = np.copy(A)
    while (m > e):
        Q0 = QR(A0)[1]
        R0 = QR(A0)[0]
        a = []
        A0 = multiply(R0, Q0)
        for i in range(A0.shape[0]):
            for j in range(A0.shape[1]):
                if i > j:
                    a.append(A0[i,j])
        m = norm_vector(a)
    L = []
    for i in range(A0.shape[0]):
        L.append(A0[i,i])
    return L


def main(A):
    Q = QR(A)[1]
    R = QR(A)[0]
    print("Матрица Q:\n", QR(A)[1])
    print("Матрица R:\n", QR(A)[0])
    print("Собственные значения матрицы А:\n", eigenvalues(A))


A = np.array([[-1.0, 4.0, -4.0],
             [2.0, -5.0, 0.0],
             [-8.0, -2.0, 0.0]])
main(A)
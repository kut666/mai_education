import numpy as np

def normalization_matrix(A):
    A1 = np.copy(A)
    for i in range(A1.shape[0]):
        a = A1[i][i]
        for j in range(A1.shape[0]):
            A1[i][j] = A1[i][j] / a
    return A1


def inverse_matrix1(A):
    A1 = np.copy(A)
    E = np.eye(A1.shape[0])
    for i in range(A1.shape[0]):
        for j in range(A1.shape[1]):
            if i != j:
                E[j, :] -= A[j, i] * E[i, :]
    return E


def inverse_matrix2(A):
    A1 = np.copy(A)
    E = np.eye(A1.shape[0])
    for i in range(A1.shape[0] - 1, -1, -1):
        for j in range(A1.shape[1] - 1, -1, -1):
            if i != j:
                E[j, :] -= A[j, i] * E[i, :]
    return E

def multiply(A,B):
    C = np.zeros((A.shape[0], A.shape[1]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            for k in range(C.shape[1]):
                C[i,j] += A[i,k] * B[k,j]
    return C

def LU_decomposition(A):
    A1 = np.copy(A)
    L = np.zeros((A.shape[0], A.shape[1]))
    U = np.copy(A)
    for i in range(A1.shape[0]):
        for j in range(A1.shape[1]):
            if i == j:
                L[i][j] = 1.0
            if i < j:
                if A[i][i] == 0 and i != A.shape[0] - 1:
                    q = A[i][:]
                    A1[i][:] = A1[i+1][:]
                    A1[i+1][:] = q
                    o = L[i+1][0]
                    L[i+1][0] = L[i][0]
                    L[i][0] = o
                F = A1[j][i] / A1[i][i]
                L[j][i] = F
                for k in range(A.shape[0]):
                    A1[j][k] = A1[j][k] - (F * A1[i][k])
                    U[j][k] = A1[j][k]
    return L,U


def decision_SLAU(L, U, B):
    f = np.zeros(len(B))
    y = np.zeros(len(B))
    x = np.zeros(len(B))
    for i in range(len(B)):
        for j in range(len(B)):
            if i != j:
                f[i] += L[i][j] * y[j]
        y[i] = B[i] - f[i]

    for i in range(len(B) - 1, -1, -1):
        tmp = y[i]
        for j in range(len(B) - 1, -1, -1):
            if i != j:
                tmp -= U[i][j] * x[j]
        x[i] = tmp / U[i][i]
    return x

def Determinant(L, U):
    detL = 1
    detU = 1
    for i in range(L.shape[0]):
        for j in range(L.shape[1]):
            if i == j:
                detL *= L[i][j]
                detU *= U[i][j]
    detA = detL * detU
    return detA

def inverse_matrixA(L, U):
    L_inv = np.copy(inverse_matrix1(L))
    U_inv = np.copy(inverse_matrix2(normalization_matrix(U)))
    A_inv = multiply(U_inv, L_inv)
    return A_inv

def main(A):
    C = A[:,0:-1]
    D = A[:,-1]
    L = LU_decomposition(C)[0]
    U = LU_decomposition(C)[1]
    print("Матрица L\n", L)
    print("Матрица U\n", U)
    print("Решение СЛАУ\n", decision_SLAU(L, U, D))
    print("Детерминант матрицы A\n", Determinant(L, U))
    print("Обратная матрица А\n", inverse_matrixA(L, U))


A = np.array([[-7, 3, -4, 7, -126],
             [8, -1, -7, 6, 29],
             [9, 9, 3, -6, 27],
             [-7, -9, -8, -5, 34]])

main(A)

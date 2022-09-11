import numpy as np

def max_modul_element_of_matrix(A):
    max1 = 0
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            if i != j and max1 < abs(A[i,j]):
                max1 = abs(A[i,j])
                i1 = i
                j1 = j
    return i1, j1


def transpose(A):
    AT = np.zeros((A.shape[0], A.shape[1]))
    for i in range(A.shape[0]):
        for j in range(A.shape[1]):
            AT[j,i] = A[i,j]
    return AT


def multiply(A,B):
    C = np.zeros((A.shape[1], B.shape[0]))
    for i in range(C.shape[0]):
        for j in range(C.shape[1]):
            for k in range(C.shape[1]):
                C[i,j] += A[i,k] * B[k,j]
    return C


def rotation_method(A):
    m = 3
    e = 0.003
    U = []
    A1 = np.copy(A)
    while (m > e):
        m = 0
        A0 = np.copy(A1)
        iMax = max_modul_element_of_matrix(A0)[0]
        jMax = max_modul_element_of_matrix(A0)[1]
        if A0[iMax,iMax] != A0[jMax,jMax]:
            phi = np.arctan(2*A0[iMax,jMax]/(A0[iMax,iMax] - A0[jMax,jMax]))/2
        else:
            phi = np.pi/4
        U0 = np.zeros((A0.shape[0], A0.shape[1]))
        for i in range(U0.shape[0]):
            for j in range(U0.shape[1]):
                if i == iMax and j == jMax:
                    U0[i,j] = -np.sin(phi)
                    U0[i,i] = np.cos(phi)
                    U0[j,j] = np.cos(phi)
                    U0[j,i] = np.sin(phi)
                elif i == j and i != iMax and j != jMax:
                    U0[i,j] = 1
        U.append(U0)
        U0T = transpose(U0)
        A1 = multiply(multiply(U0T,A0),U0)
        for i in range(A1.shape[0]):
            for j in range(A1.shape[1]):
                if i < j:
                    m += A1[i,j]*A1[i,j]
        m = np.sqrt(m)
    for i in range(A1.shape[0]):
            for j in range(A1.shape[1]):
                if i == j:
                    print("Собственное значение №", i, np.around(A1[i,j], 2))
    for i in range(len(U) - 1):
        U[i + 1] = multiply(U[i],U[i + 1])
    
    U = U[-1]
    for i in range(U.shape[0]):
        print("Собственный вектор №", i+1)
        for j in range(U.shape[1]):
            print(np.around(U[j, i], 2), sep = '\n')

    return np.around(A1, 2)


def main(A):
    print("Матрица А:\n", np.around(rotation_method(A), 2))

A =np.array([[-7, -6, 8],
             [-6, 3, -7],
             [8, -7, 4]])
main(A)
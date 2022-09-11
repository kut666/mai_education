import numpy as np

def create_matrix_system(A, B):
    A1 = np.zeros((len(B), len(B)))
    for i in range(A1.shape[0]):
        if i == 0:
            A1[i, 0] = A[0]
            A1[i, 1] = A[1]
            j = 2
        elif i == len(A1) - 1:
            A1[i, len(A1) - 1] = A[-1]
            A1[i, len(A1) - 2] = A[-2]
        else:
            A1[i, i] = A[j + 1]
            A1[i, i - 1] = A[j]
            A1[i, i + 1] = A[j + 2]
            j += 3
    return A1


def run_through(A, B):
    a = np.zeros(A.shape[0])
    b = np.zeros(A.shape[0])
    x = np.zeros(A.shape[0])
    y = A[0,0]
    a[0] = -A[0,1] / y
    b[0] = B[0] / y

    for i in range(len(A) - 1):
        y = A[i,i] + A[i, i - 1] * a[i - 1]
        a[i] = -A[i, i + 1] / y
        b[i] = (B[i] - A[i][i - 1] * b[i - 1]) / y

    P = B[len(A) - 1] - A[len(A) - 1][len(A) - 2] * b[len(A) - 2]
    Q = A[len(A) - 1][len(A) - 1] + A[len(A) - 1][len(A) - 2] * a[len(A) - 2]
    x[len(A) - 1] =  P / Q 
    for i in range(len(A) - 2, -1, -1):
        x[i] = a[i] * x[i + 1] + b[i]
    return x


def main(A, B):
    A1 = create_matrix_system(A,B)
    print(A1)
    roots1 = run_through(A1, B)
    print(roots1)

A = np.array([-7.0,-6.0, 6.0, 12.0, 0.0, -3.0, 5.0, 0.0, -9.0, 21.0, 8.0, -5.0, -6.0])
B = np.array([-75.0, 126.0, 13.0, -40.0, -24.0])

main(A,B)
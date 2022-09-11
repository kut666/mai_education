import math
import numpy as np

def Gauss ():

    #создание массива времени t
    step = 1
    tstart = 1
    tfinish = 6
    t = np.arange(tstart, tfinish, step)
    N = len(t)
    H = 0.75
    print('Параметр H =', H, '\n')

    # моделирование ковариционной матрицы R
    R = np.zeros((N, N))
    for i in range(N):
        for j in range(N):
            R[i, j] = (pow(abs(t[i]), (2 * H)) + pow(abs(t[j]), (2 * H)) - pow(abs(t[i] - t[j]), 2 * H)) / 2

    # моделирование нижнетреугольной матрицы А
    A = np.zeros((N, N))
    for i in range(N):
        for j in range(i + 1):
            sum1 = 0
            if (i == j):
                for k in range(j):
                    sum1 += pow(A[j, k], 2)
                A[i, j] = math.sqrt(R[j, j] - sum1)
            else:
                for k in range(j):
                    sum1 += A[i, k] * A[j, k]
                A[i, j] = (R[i, j] - sum1) / A[j, j]

    print('Ковариционная матрица R: \n', R.round(3), '\n')
    print('Нижнетреугольная матрица А\n', A.round(3), '\n')
    #print (np.linalg.cholesky(R))

    # генерация вектора стандартных нормальных величин и вектора значений
    b = 0
    if (N // 2 != 0):
        N = N + 1
        b = 1
    alfa = np.random.uniform(0, 1, N)
    ksi = np.zeros(N)
    i = 0
    while (i < len(alfa)):
            ksi1 = math.sqrt(-2 * math.log(alfa[i])) * math.sin(2 * math.pi * alfa[i + 1])
            ksi[i] = ksi1
            ksi2 = math.sqrt(-2 * math.log(alfa[i])) * math.cos(2 * math.pi * alfa[i + 1])
            ksi[i + 1] = ksi2
            i = i + 2
    if (b == 1):
        ksi = np.delete(ksi, -1)
        N -= 1
    teta = A.dot(ksi)
    print ('Вектор альфа:\n', alfa.round(3), '\n')
    print ('Вектор стандартных нормальных величин', ksi.round(3), '\n')
    print('Вектор значений', teta.round(3), '\n')

    # проверка
    _M = np.zeros(N)
    _R = np.zeros((N, N))
    K = 10000

    b = 0
    if ( N // 2 != 0):
        N = N + 1
        b = 1
    for i in range(K):
        alfa = np.random.uniform(0, 1, N)
        ksi = np.zeros(N)
        i = 0
        while (i < alfa.size):
                ksi1 = math.sqrt(-2 * math.log(alfa[i])) * math.sin(2 * math.pi * alfa[i + 1])
                ksi[i] = ksi1
                ksi2 = math.sqrt(-2 * math.log(alfa[i])) * math.cos(2 * math.pi * alfa[i + 1])
                ksi[i + 1] = ksi2
                i = i + 2
        if (b == 1):
            ksi = np.delete(ksi,-1)
        teta = A.dot(ksi)
        teta = teta.reshape(1, -1)
        teta_t = teta.reshape(-1, 1)
        A_t = teta_t.dot(teta)
        _M = _M + (teta / K)
        _R = _R + (A_t / K)
    print('Проверка вектора мат. ожиданий:', _M.round(3), '\n')
    print('Проверка матрицы R:\n', _R.round(3))

Gauss()
import numpy as np


def function(x, y, z):
    return ((2 * x + 1) * z - (x + 1) * y) / x


def accurate_function(x):
    return np.e**x * x**2


def p(x):
    return -(2 * x + 1) / x


def q(x):
    return (x + 1) / x


def Runge_Kutty(a, b, h, y0, z0):
    x = np.arange(a, b + h, h)
    K = np.zeros(4)
    L = np.zeros(4)
    y = np.zeros(len(x))
    z = np.zeros(len(x))
    y[0] = y0
    z[0] = z0
    for i in range(1, len(x)):
        for j in range(1, len(K)):
            K[0] = h * z[i - 1]
            L[0] = h * function(x[i - 1], y[i - 1], z[i - 1])
            K[j] = h * (z[i - 1] + L[j - 1] / 2)
            L[j] = h * function(x[i - 1] + h / 2, y[i - 1] + K[j - 1] / 2, z[i - 1] + L[j - 1] / 2)
        deltay = (K[0] + 2 * K[1] + 2 * K[2] + K[3]) / 6
        deltaz = (L[0] + 2 * L[1] + 2 * L[2] + L[3]) / 6
        y[i] = y[i - 1] + deltay
        z[i] = z[i - 1] + deltaz
    return y


def shooting_method(a, b, h, e, y0, y1):
    nu1 = 1.0
    nu2 = 0.8
    f1 = Runge_Kutty(a, b, h, y0, nu1)[-1] - y1
    f2 = Runge_Kutty(a, b, h, y0, nu2)[-1] - y1

    while(abs(f2) > e):
        nu1, nu2 = nu2, nu2 - f2 * (nu2 - nu1) / (f2 - f1)
        f1, f2 = f2, Runge_Kutty(a, b, h, y0, nu2)[-1] - y1
    return Runge_Kutty(a, b, h, y0, nu2)


def finite_difference_method(a, b, h, alfa, beta, delta, gamma, y0, y1):
    x = np.arange(a, b + h, h)
    N = int((b - a) / h)
    A = []
    B = []
    C = []
    D = []
    A.append(0)
    B.append(-2 + h * h * q(x[1]))
    C.append(1 + p(x[1]) * h / 2)
    D.append(-(1 - (p(x[1]) * h) / 2) * y0)
    for i in range(2, N):
        A.append(1 - p(x[i]) * h / 2)
        B.append(-2 + h * h * q(x[i]))
        C.append(1 + p(x[i]) * h / 2)
        D.append(0)
    A.append(1 - p(x[N - 2]) * h / 2)
    B.append(-2 + h * h * q(x[N - 2]))
    C.append(0)
    D.append(-(1 + (p(x[N - 2]) * h) / 2) * y1)

    P = np.zeros(N)
    Q = np.zeros(N)
    P[0] = (-C[0] / B[0])
    Q[0] = (D[0] / B[0])
    for i in range(1, N):
        P[i] = (-C[i] / (B[i] + A[i] * P[i - 1]))
        Q[i] = ((D[i] - A[i] * Q[i - 1]) / (B[i] + A[i] * P[i - 1]))
    ans = np.zeros(N)
    ans[N - 1] = Q[N - 1]
    for i in range(N - 2, 0, -1):
        ans[i] = P[i] * ans[i + 1] + Q[i]
    ans[0] = y0
    ans = np.append(ans, y1)
    return ans

def RRR_method(a, b, h, e, y0, y1, alfa, beta, gamma, delta):
    x = np.arange(a, b + h, h)
    shooting_method1 = np.zeros(len(x))
    finite_difference_method1 = np.zeros(len(x))
    shooting_method_norm = shooting_method(a, b, h, e, y0, y1)
    shooting_method_half = shooting_method(a, b, h / 2, e, y0, y1)
    finite_difference_method_norm = finite_difference_method(a, b, h, alfa, beta, delta, gamma, y0, y1)
    finite_difference_method_half = finite_difference_method(a, b, h / 2, alfa, beta, delta, gamma, y0, y1)
    for i in range(len(x)):
        shooting_method1[i] = shooting_method_norm[i] + (shooting_method_half[i * 2] - shooting_method_norm[i]) / (1 - 0.5**2)
        finite_difference_method1[i] = finite_difference_method_norm[i] + (finite_difference_method_half[i * 2] - finite_difference_method_norm[i]) / (1 - 0.5**2)
    return shooting_method1, finite_difference_method1


def main(a, b, h, e, alfa, beta, delta, gamma, y0, y1):
    x = np.arange(a, b + h, h)
    y = accurate_function(x)
    print("             X:           ", *np.around(x, 3))
    print("    Точное значение Y:    ", *np.around(y, 3), "\n")
    print("      Метод стрельбы:     ", *np.around(shooting_method(a, b, h, e, y0, y1), 3))
    print("Конечно-разностный метод: ", *np.around(finite_difference_method(a, b, h, alfa, beta, delta, gamma, y0, y1), 3), "\n")
    print("С применением метода Рунге-Ромберга-Ричардсона")
    print("      Метод стрельбы:     ", *np.around(RRR_method(a, b, h, e, y0, y1, alfa, beta, delta, gamma)[0], 3))
    print("Конечно-разностный метод  ", *np.around(RRR_method(a, b, h, e, y0, y1, alfa, beta, delta, gamma)[1], 3), "\n")
    print("Разница от точного значения")
    print("     Метод стрельбы:      ", *np.around(abs(RRR_method(a, b, h, e, y0, y1, alfa, beta, delta, gamma)[0] - y), 3))
    print("Конечно-разностный метод: ", *np.around(RRR_method(a, b, h, e, y0, y1, alfa, beta, delta, gamma)[1] - y, 3))


a = 1
b = 2
h = 0.1
e = 0.001
alfa = 0
beta = 1
delta = 1
gamma = -2
y0 = np.e
y1 = 4 * np.e**2
main(a, b, h, e, alfa, beta, delta, gamma, y0, y1)
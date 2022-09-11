import numpy as np, matplotlib.pyplot as plt


# def K(x, s):
#     return np.e**(s - x)

def K(x, s):
    return 1


# def f(x):
#     return np.e**(-x)

def f(x):
    return 1


# def accurate_y(x):
#     return 1

def accurate_y(x):
    return np.e**x


def quadrature_method(a, b, h):
    x = np.arange(a, b + h, h)
    y = np.zeros(len(x))
    y[0] = f(x[0])
    for i in range(1, len(x)):
        sum = 0
        if i > 1:
            for j in range(1, i):
                sum = K(x[i], x[j]) * y[j] + sum
        y[i] = ((1 - h / 2 * K(x[i], x[i]))**(-1)) * ((f(x[i])) + (h / 2) * K(x[i], x[0]) * y[0] + h * sum)
    return y


def norm_vector(b):
    norm = 0
    for i in range(len(b)):
        norm += b[i]*b[i]
    return np.sqrt(norm)


def count_yk(x, y):
    yk = np.zeros(len(y))
    for i in range(len(yk)):
        for j in range(0, i + 1):
            yk[i] = yk[i] + 2 * K(x[i], x[j]) * y[j]
        yk[i] = yk[i] - K(x[i], x[0]) * y[0] - K(x[i], x[i]) * y[i]
        yk[i] = f(x[i]) + yk[i] * h / 2
    return yk


def simple_iteration(a, b, h, e):
    x = np.arange(a, b + h, h)
    y = np.zeros(len(x))
    for i in range(len(x)):
        y[i] = f(x)
    yk = count_yk(x, y)
    while (norm_vector(yk - y) / norm_vector(yk)) > e:
        y = yk
        yk = count_yk(x, y)
    return y
    

def main(a, b, h, e):
    x = np.arange(a, b + h, h)
    y = np.zeros(len(x))
    for i in range(len(y)):
        y[i] = accurate_y(x[i])
    q_y = quadrature_method(a, b, h)
    si_y = simple_iteration(a, b, h, e)
    print("Решения интегрального уравнения Вольтерра второго рода \n")
    print("             X          ", x)
    print("   Точное значение Y:   ", y)
    print("    Метод квадратур:    ", *np.around(q_y, 4))
    print("Метод простой итерации: ", *np.around(si_y, 4), "\n")
    print("Разница от точного значения")
    print("    Метод квадратур:    ", *np.around(q_y - y, 4))
    print("Метод простой итерации: ", *np.around(si_y - y, 4))
    plt.title("График точного решения функции и результ работы методов")
    plt.xlabel("x") 
    plt.ylabel("y")
    plt.grid()
    plt.axis([-0.1, 2.1, 0, 8])
    plt.plot(x, y, label = "Точное решение")
    for i in range(len(x)):
        plt.scatter(x[i], q_y[i])
    plt.plot(x,q_y, label = "Значения Y методом квадратур")
    for i in range(len(x)):
        plt.scatter(x[i], si_y[i])
    plt.plot(x,si_y, label = "Значения Y методом простых итераций")
    plt.legend()
    plt.show()


# a = 0
# b = 1
a = 0
b = 2
h = 0.2
e = 0.005
main(a, b, h, e)

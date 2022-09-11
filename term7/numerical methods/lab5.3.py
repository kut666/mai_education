import numpy as np, matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import axes3d

def analyt_func(x, y):
    return np.exp(-x - y) * np.cos(x) * np.cos(y)


def func_border1(x, y):
    return np.exp(-y) * np.cos(y)


def func_border2(x, y):
    return 0


def func_border3(x, y):
    return np.exp(-x) * np.cos(x)


def func_border4(x, y):
    return 0


def norm(cur_u, prev_u):
    max = 0
    for i in range(cur_u.shape[0]):
        for j in range(cur_u.shape[1]):
            if abs(cur_u[i, j] - prev_u[i, j]) > max:
                max = abs(cur_u[i, j] - prev_u[i, j])

    return max


def liebman( x, y, h, eps):
    N = len(x)
    count = 0
    prev_u = np.zeros((N, N))
    cur_u = np.zeros((N, N))

    for j in range(len(y)):
        coeff = (func_border2(x[j], y[j]) - func_border1(x[j], y[j])) / (len(x) - 1)
        addition = func_border1(x[j], y[j])
        for i in range(len(x)):
            cur_u[i][j] = coeff * i + addition
    for i in range(1, N - 1):
        cur_u[i, 0] = func_border3(x[i], y[i])
        cur_u[i, -1] = func_border4(x[i], y[i])

    while norm(cur_u, prev_u) > eps:
        count += 1
        prev_u = np.copy(cur_u)
        for i in range(1, N - 1):
            for j in range(1, N - 1):
                cur_u[i, j] = ((1 + h) * (prev_u[i + 1, j] + prev_u[i, j + 1]) + (1 - h) * (prev_u[i - 1, j] + prev_u[i, j - 1]) \
                + 4 * h**2 * prev_u[i, j]) / 4
    U = np.copy(cur_u)

    return U, count


def relaxation(x, y, h, eps, tau):
    N = len(x)
    count = 0
    prev_u = np.zeros((N, N))
    cur_u = np.zeros((N, N))
    for j in range(len(y)):
        coeff = (func_border2(x[j], y[j]) - func_border1(x[j], y[j])) / (len(x) - 1)
        addition = func_border1(x[j], y[j])
        for i in range(len(x)):
            cur_u[i][j] = coeff * i + addition
    for i in range(1, N - 1):
        cur_u[i, 0] = func_border3(x[i], y[i])
        cur_u[i, -1] = func_border4(x[i], y[i])

    while norm(cur_u, prev_u) > eps:
        count += 1
        prev_u = np.copy(cur_u)
        for i in range(1, N - 1):
            for j in range(1, N - 1):
                cur_u[i, j] = (1 - tau) * prev_u[i, j] + tau * (((1 + h) * (prev_u[i + 1, j] + prev_u[i, j + 1]) + (1 - h) \
                * (prev_u[i - 1, j] + prev_u[i, j - 1]) + 4 * h**2 * prev_u[i, j]) / 4)
    U = np.copy(cur_u)

    return U, count


def Zeidel(x, y, h, eps, tau):
    N = len(x)
    count = 0
    prev_u = np.zeros((N, N))
    cur_u = np.zeros((N, N))
    for j in range(len(y)):
        coeff = (func_border2(x[j], y[j]) - func_border1(x[j], y[j])) / (len(x) - 1)
        addition = func_border1(x[j], y[j])
        for i in range(len(x)):
            cur_u[i][j] = coeff * i + addition
    for i in range(1, N - 1):
        cur_u[i, 0] = func_border3(x[i], y[i])
        cur_u[i, -1] = func_border4(x[i], y[i])

    while norm(cur_u, prev_u) > eps:
        count += 1
        prev_u = np.copy(cur_u)
        
        for i in range(1, N - 1):
            for j in range(1, N - 1):
                cur_u[i, j] = (1 - tau) * prev_u[i, j] + tau * (((1 + h) * (prev_u[i + 1, j] + prev_u[i, j + 1]) + (1 - h) \
                * (cur_u[i - 1, j] + cur_u[i, j - 1]) + 4 * h**2 * prev_u[i, j]) / 4)
    U = np.copy(cur_u)

    return U, count


def main(N, eps):
    h = (np.pi / 2 - 0) / N
    x = np.arange(0, np.pi / 2 + h / 2 - 1e-4, h)
    y = np.arange(0, np.pi / 2 + h / 2 - 1e-4, h)

    while (1):
        print("Выберите метод:\n"
            "1 - метод Либмана\n"
            "2 - метод Зейделя\n"
            "3 - метод простых итераций с верхней релаксацией\n"
            "0 - выход из программы")
        method = int(input())
        if method == 0:
            break
        if method == 1:
            U, count = liebman(x, y, h, eps)
        if method == 2:
            tau = float(input("Введите параметр tau от 0 до 1:"))
            U, count = Zeidel(x, y, h, eps, tau)
        if method == 3:
            tau = float(input("Введите параметр tau от 0 до 1:"))
            U, count = relaxation(x, y, h, eps, tau)

        X, Y = np.meshgrid(x, y)
        U_analytic = analyt_func(X, Y)
        error_x = []
        error_y = []
        for i in range(len(x)):
            error_x.append(max(abs(U_analytic[:, i] - U[:, i])))
            error_y.append(max(abs(U_analytic[i, :] - U[i, :])))
        plt.title("График ошибок")
        plt.plot(x, error_y, label = "При фиксированном x", color = "red")
        plt.plot(x, error_x, label = "При фиксированном y", color = "blue")
        plt.text(0.2, 0.01, "Кол-во итераций: " + str(count))
        plt.xlabel("x, y")
        plt.ylabel("error")
        plt.grid()
        plt.legend()
        fig = plt.figure()
        ax = fig.add_subplot(projection='3d')
        ax.set_title("График точного и численного решения задачи")
        ax.plot_wireframe(X, Y, U_analytic, color = "red", label = "Точное решение")
        ax.plot_wireframe(X, Y, U, color = "blue", label = "Численное решение")
        ax.set_xlabel("x")
        ax.set_ylabel("y")
        ax.set_zlabel("U")
        ax.legend()
        plt.show()

    return 0


eps = 0.0001
N = 50
main(N, eps)
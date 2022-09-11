import numpy as np, matplotlib.pyplot as plt

def func(x1, x2):
    return (np.arctan(x1) - np.arctan(x2)) / (x1 - x2)


def func1(x1, x2, x3):
    return (func(x1, x2) - func(x1, x2)) / (x1 - x2)


def func2(x1, x2, x3, x4):
    return (func1(x1, x2, x3) - func1(x2, x3, x4)) / (x1 - x4)


def couting_w(x):
    w = np.zeros(4)
    w[0] = (x[0] - x[1]) * (x[0] - x[2]) * (x[0] - x[3])
    w[1] = (x[1] - x[0]) * (x[1] - x[2]) * (x[1] - x[3])
    w[2] = (x[2] - x[0]) * (x[2] - x[1]) * (x[2] - x[3])
    w[3] = (x[3] - x[0]) * (x[3] - x[1]) * (x[3] - x[2])
    return w


def Lagrange_method(x, X):
    table = np.zeros((5, 4))
    for i in range(len(x)):
        table[0][i] = x[i]
        table[1][i] = np.arctan(x[i])
        table[2][i] = couting_w(x)[i]
        table[3][i] = table[1][i] / table[2][i]
        table[4][i] = X - x[i]

    L = (table[3][0] * (x - table[0][1]) * (x - table[0][2]) * (x - table[0][3])
        + table[3][1] * (x - table[0][0]) * (x - table[0][2]) * (x - table[0][3])
        + table[3][2] * (x - table[0][0]) * (x - table[0][1]) * (x - table[0][3])
        + table[3][3] * (x - table[0][0]) * (x - table[0][1]) * (x - table[0][2]))
    y = np.arctan(x)
    delta = abs(y - L)
    return L, y, delta


def Newton_method(x, X):
    table = np.zeros((5, 4))
    for i in range(len(x)):
        table[0][i] = x[i]
        table[1][i] = np.arctan(x[i])
        if i != 3:
            table[2][i] = func(x[i], x[i + 1])
        if i < 2:
            table[3][i] = func1(x[i], x[i + 1], x[i + 2])
        table[4][0] = func2(x[0], x[1], x[2], x[3])
    P = (table[1][0] + table[2][0] * (x - table[0][0]) + table[3][0] * (x - table[0][0]) * (x - table[0][1])
        + table[4][0] * (x - table[0][0]) * (x - table[0][1]) * (x - table[0][2]))
    y = np.arctan(x)
    delta = abs(y - P)
    return P, y, delta


def main(x1, x2, root):
    L1, Ly1, Ldelta1 = Lagrange_method(x1, root)
    L2, Ly2, Ldelta2 = Lagrange_method(x2, root)
    P1, Py1, Pdelta1 = Newton_method(x1, root)
    P2, Py2, Pdelta2 = Newton_method(x2, root)
    print("Method Lagrange:\n"
         "          L(x)                      y(x)                 delta\n",
         np.around(L1, 2), np.around(Ly1, 2), np.around(Ldelta1, 2), "\n",
         np.around(L2, 2), np.around(Ly2, 2), np.around(Ldelta2, 2))
    print("Method Newton:\n"
         "          P(x)                      y(x)                      delta\n",
         np.around(P1, 2), np.around(Py1, 2), np.around(Pdelta1, 2), "\n",
         np.around(P2, 2), np.around(Py2, 2), np.around(Pdelta2, 2))

x1 = np.array([-3.0, -1.0, 1.0, 3.0])
x2 = np.array([-3.0, 0.0, 1.0, 3.0])
root = -0.5
main(x1, x2, root)
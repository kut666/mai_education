import numpy as np, matplotlib.pyplot as plt


def function_fi(x1, x2):
    return np.cos(x2) + 1, np.sin(x1) + 1

def function_f(x1,x2):
    return x1 - np.cos(x2) - 1, x2 - np.sin(x1) - 1

def df1x1(x1, x2):
    return 1.0


def df1x2(x1, x2):
    return np.sin(x2)


def df2x1(x1, x2):
    return -np.cos(x1)


def df2x2(x1, x2):
    return 1.0


def detA1(x1,x2):
    return function_f(x1, x2)[0] * df2x2(x1, x2) - function_f(x1, x2)[1] * df1x2(x1, x2)


def detA2(x1,x2):
    return df1x1(x1, x2) * function_f(x1, x2)[1] - df2x1(x1, x2) * function_f(x1, x2)[0]


def detJ(x1,x2):
    return df1x1(x1, x2) * df2x2(x1, x2) - df2x1(x1, x2) * df1x2(x1, x2)


def norm(b):
    max = 0
    for i in range(len(b)):
        if b[i] > max:
            max = b[i]
    return max


def simple_iter(e, q, a, b):
    roots0 = [a, a]
    roots1 = [function_fi(a, a)[0], function_fi(a, a)[1]]
    error = []
    for i in range(len(roots1)):
        error.append(abs(roots0[i] - roots1[i]))
    while q / (1 - q) * norm(error) > e:
        roots0[0] = roots1[0]
        roots1[0] = function_fi(roots1[0], roots1[1])[0]
        roots0[1] = roots1[1]
        roots1[1] = function_fi(roots1[0], roots1[1])[1]
        for i in range(len(error)):
            error[i] = abs(roots0[i] - roots1[i])
    roots1.reverse()
    return roots1


def newton_method(e, a, b):
    roots0 = [a, a]
    roots1 = [function_f((a + b) / 2, (a + b) / 2)[0], function_f((a + b) / 2, (a + b) / 2)[1]]
    error = []
    for i in range(len(roots1)):
        error.append(abs(roots0[i] - roots1[i]))
    while norm(error) > e: 
        x1 = detA1(roots1[0], roots1[1]) / detJ(roots1[0], roots1[1])
        x2 = detA2(roots1[0], roots1[1]) / detJ(roots1[0], roots1[1])
        roots0[0] = roots1[0]
        roots0[1] = roots1[1]
        roots1[0] -= x1
        roots1[1] -= x2
        for i in range(len(error)):
            error[i] = abs(roots1[i] - roots0[i])
    roots1.reverse()
    return roots1


def main():
    e = 0.0001
    q = 0.2
    plt.title("График первого и второго уравнения") 
    plt.xlabel("x") 
    plt.ylabel("y")
    plt.grid()
    plt.axis([-3, 3, -3, 3])
    x1 = np.arange(-10, 10, 0.1)
    x2 = np.arange(-10, 10, 0.1)
    y = function_fi(x1, x2)
    plt.plot(x1, y[0], y[1], x2)
    plt.show()

    print("Введите границы отрезка, на котором производится поиск корня:")
    a, b = map(float, input().split(' '))
    
    print("Методом простых итераций:\n"
          "Корнем уравнения в области от ", a, " до ", b,  "является ", np.around(simple_iter(e, q, a , b), 3))
    print("Методом Нюьтона:\n"
          "Корнем уравнения в области от ", a, " до ", b, "является ", np.around(newton_method(e ,a, b), 3))

main()
import numpy as np, matplotlib.pyplot as plt

def plot_function_f(x):
    return np.sin(x), 2 * x * x - 0.5


def function_fi(x):
    return np.sqrt((np.sin(x) / 2) + 0.25)


def function_f(x):
    return np.sin(x) - 2 * x * x + 0.5


def derivative_f(x):
    return -np.cos(x) - 4 * x


def simple_iter(e, q, a, b):
    roots0 = a
    roots1 = function_fi((a + b) / 2)
    while q / (1 - q) * abs(roots0 - roots1) > e:
        roots0 = roots1
        roots1 = function_fi(roots1)
        return roots1


def newton_method(e, a, b):
    roots0 = 0
    roots1 = - function_f(a) / derivative_f(a)
    while (abs(roots0 - roots1) > e): 
        delta = - function_f(roots0) / derivative_f(roots0)
        roots0 = roots1
        roots1 += delta
    return roots1


def main():
    e = 0.0001
    q = 0.2
    plt.title("График синуса и параболы") 
    plt.xlabel("x") 
    plt.ylabel("y")
    plt.grid()
    plt.axis([-1, 1, -1, 1])
    x = np.arange(-10, 10, 0.1)
    y = plot_function_f(x)
    plt.plot(x, y[0], x, y[1])
    plt.show()

    print("Введите границы отрезка, на котором производится поиск корня:")
    a, b = map(float, input().split(' '))
    
    print("Методом простых итераций:\n"
          "Корнем уравнения на промежутке от ", a, " до ", b,  "является ", np.around(simple_iter(e, q, a , b), 5))
    print("Методом Ньютона:\n"
          "Корнем уравнения на промежутке от ", a, " до ", b, "является ", np.around(newton_method(e ,a, b), 5))

main()
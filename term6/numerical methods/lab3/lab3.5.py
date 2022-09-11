import numpy as np

def function(x):
    return x**2 / (x**2 + 16)


def Rectangle_method(X0, Xk, h):
    n = int((Xk - X0) / h) + 1
    x = np.linspace(X0, Xk, n)
    result = 0
    for i in range(1, n):
            result += h * (function((x[i] + x[i - 1]) / 2))
    return result


def Trapez_method(X0, Xk, h):
    n = int((Xk - X0) / h) + 1
    x = np.linspace(X0, Xk, n)
    result = 0
    for i in range(1, n):
        result += h / 2 * (function(x[i]) + function(x[i - 1]))
    return result


def Simpson_method(X0, Xk, h):
    n = int((Xk - X0) / h) + 1
    x = np.linspace(X0, Xk, n)
    h = h / 2
    result = 0
    for i in range(1, n):
        result += (h * (function(x[i - 1]) + 4 * function((x[i] + x[i - 1]) / 2) + function(x[i]))) / 3
    return result


def RRR_method(X0, Xk, h):
    Rect = Rectangle_method(X0, Xk, h) + (Rectangle_method(X0, Xk, h / 2) - Rectangle_method(X0, Xk, h)) / (1 - 0.5**2)
    Trap = Trapez_method(X0, Xk, h) + (Trapez_method(X0, Xk, h / 2) - Trapez_method(X0, Xk, h)) / (1 - 0.5**2)
    Simp = Simpson_method(X0, Xk, h) + (Simpson_method(X0, Xk, h / 2) - Simpson_method(X0, Xk, h)) / (1 - 0.5**4)
    return Rect, Trap, Simp


def main(X0, Xk, h1, h2):
    print("Метод прямоугольника c шагом 0.5: ", Rectangle_method(X0, Xk, h1))
    print("Метод прямоугольника c шагом 0.25: ", Rectangle_method(X0, Xk, h2), "\n")
    print("Метод трапеции c шагом 0.5: ", Trapez_method(X0, Xk, h1))
    print("Метод трапеции c шагом 0.25: ", Trapez_method(X0, Xk, h2), "\n")
    print("Метод Симпсона c шагом 0.5: ", Simpson_method(X0, Xk, h1))
    print("Метод Симпсона c шагом 0.25: ", Simpson_method(X0, Xk, h2), "\n")
    print("С применением метода Рунге-Ромберга-Ричардсона: \n")
    print("Метод прямоугольника c шагом 0.5: ", RRR_method(X0, Xk, h1)[0])
    print("Метод прямоугольника c шагом 0.25: ", RRR_method(X0, Xk, h2)[0])
    print("Погрешность вычислений:", abs(RRR_method(X0, Xk, h2)[0] - 0.1454095639967755), "\n")
    print("Метод трапеции c шагом 0.5: ", RRR_method(X0, Xk, h1)[1])
    print("Метод трапеции c шагом 0.25: ", RRR_method(X0, Xk, h2)[1])
    print("Погрешность вычислений:", abs(RRR_method(X0, Xk, h2)[1] - 0.1454095639967755), "\n")
    print("Метод Симпсона c шагом 0.5: ", RRR_method(X0, Xk, h1)[2])
    print("Метод Симпсона c шагом 0.25: ", RRR_method(X0, Xk, h2)[2])
    print("Погрешность вычислений:", abs(RRR_method(X0, Xk, h2)[2] - 0.1454095639967755), "\n")


X0 = 0
Xk = 2
h1 = 0.5
h2 = 0.25

main(X0, Xk, h1, h2)
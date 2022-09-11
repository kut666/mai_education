import numpy as np


def function(x, y, z):
    return np.cos(x)**2 * y - np.tan(x) * z


def accurate_function(x):
    return np.e**(np.sin(x)) + np.e**(-np.sin(x))


def Euler(a, b, h):
    x = np.arange(a, b + h, h)
    y = np.ones(len(x))
    y *= 2
    z = np.zeros(len(x))
    for i in range(1, len(x)):
        z[i] = z[i - 1] + h * function(x[i - 1], y[i - 1], z[i - 1])
        y[i] = y[i - 1] + h * z[i - 1]
    return y


def Runge_Kutty(a, b, h):
    x = np.arange(a, b + h, h)
    K = np.zeros(4)
    L = np.zeros(4)
    y = np.ones(len(x))
    y *= 2
    z = np.zeros(len(x))
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
    return y, z


def Adams(a, b, h):
    x = np.arange(a, b + h, h)
    y = np.zeros(len(x))
    z = np.zeros(len(x))
    y_start = Runge_Kutty(a, a + 3 * h, h)[0]
    for i in range(len(y_start)):
        y[i] = y_start[i]

    z_start = Runge_Kutty(a, a + 3 * h, h)[1]
    for i in range(len(z_start)):
        z[i] = z_start[i]
    
    for i in range(4, len(x)):
        z[i] = (z[i - 1] + h * (55 * function(x[i - 1], y[i - 1], z[i - 1]) - 59 * function(x[i - 2], y[i - 2], z[i - 2]) 
        + 37 * function(x[i - 3], y[i - 3], z[i - 3]) - 9 * function(x[i - 4], y[i - 4], z[i - 4])) / 24)
        y[i] = y[i - 1] + h * z[i - 1]
    
    return y


def RRR_method(a, b, h):
    x = np.arange(a, b + h, h)
    Euler1 = np.zeros(len(x))
    Runge_Kutty1 = np.zeros(len(x))
    Adams1 = np.zeros(len(x))
    Euler_norm = Euler(a, b, h)
    Euler_half = Euler(a, b, h / 2)
    Runge_Kutty_norm = Runge_Kutty(a, b, h)[0]
    Runge_Kutty_half = Runge_Kutty(a, b, h / 2)[0]
    Adams_norm = Adams(a, b, h)
    Adams_half = Adams(a, b, h / 2)
    for i in range(len(x)):
        Euler1[i] = Euler_norm[i] + (Euler_half[i * 2] - Euler_norm[i]) / (1 - 0.5**2)
        Runge_Kutty1[i] = Runge_Kutty_norm[i] + (Runge_Kutty_half[i * 2] - Runge_Kutty_norm[i]) / (1 - 0.5**2)
        Adams1[i] = Adams_norm[i] + (Adams_half[i * 2] - Adams_norm[i]) / (1 - 0.5**2)
    
    return Euler1, Runge_Kutty1, Adams1


def main(a, b, h):
    x = np.arange(a, b + h, h)
    y = accurate_function(x)
    print("         X:        ", np.around(x, 3))
    print("Точное значение Y: ", np.around(y, 3), "\n")
    print("    Метод Эйлера   ", np.around(Euler(a, b, h), 3))
    print(" Метод Рунге-Кутты ", np.around(Runge_Kutty(a, b, h)[0], 3))
    print("   Метод Адамса    ", np.around(Adams(a, b, h), 3), "\n")
    print("С применением метода Рунге-Ромберга-Ричардсона: \n")
    print("    Метод Эйлера   ", np.around(RRR_method(a, b, h)[0], 3))
    print(" Метод Рунге-Кутты ", np.around(RRR_method(a, b, h)[1], 3))
    print("   Метод Адамса    ", np.around(RRR_method(a, b, h)[2], 3), "\n")
    print("Разница от точного значения \n")
    print("    Метод Эйлера   ", np.around(abs(RRR_method(a, b, h)[0] - y), 3))
    print(" Метод Рунге-Кутты ", np.around(abs(RRR_method(a, b, h)[1] - y), 3))
    print("   Метод Адамса    ", np.around(abs(RRR_method(a, b, h)[2] - y), 3))
    

h = 0.1
a = 0
b = 1
main(a, b, h)
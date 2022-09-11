#Махмудов Орхан группа М8О-305Б-18
import numpy as np
import matplotlib.pyplot as plt

def func(a, B):
    Title = "p =" + str(a) + "*phi    " + "B =" + str(B)
    phi = np.arange(0, B, 0.01)
    ro = a * phi
    #Полярная система координат
    plt.figure("Polar System")
    plt.polar(phi, ro, 'b')
    plt.grid(True)
    plt.title(Title)
    #Декартова система координат
    plt.figure("Decart System")
    x = a * phi * np.cos(phi)
    y = a * phi * np.sin(phi)
    plt.plot(x, y, 'r')
    plt.grid(True)
    plt.title(Title)
    plt.xlabel("x")
    plt.ylabel("y")
    plt.show()

a = float(input())
B = float(input())
func(a, B)
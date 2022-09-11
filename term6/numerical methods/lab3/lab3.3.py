import numpy as np,  matplotlib.pyplot as plt

def method_least_squares(x, y):
    A = np.zeros((2,3))
    sumx = 0.0
    sumy = 0.0
    sumx2 = 0.0
    sumxy = 0.0
    for i in range(len(x)):
        sumx += x[i]
        sumy += y[i]
        sumx2 += x[i]**2
        sumxy += x[i] * y[i]
    A[0,0] = len(x)
    A[0,1] = sumx 
    A[0,2] = sumy
    A[1,0] = sumx
    A[1,1] = sumx2
    A[1,2] = sumxy
    roots1 = np.linalg.solve(A[:,0:-1], A[:,-1])
    y1 = np.zeros(len(x))
    for i in range(len(y1)):
        y1[i] = roots1[0] + x[i] * roots1[1]

    A = np.zeros((3,4))
    sumx = 0.0
    sumy = 0.0
    sumx2 = 0.0
    sumx3 = 0.0
    sumx4 = 0.0
    sumxy = 0.0
    sumx2y = 0.0
    for i in range(len(x)):
        sumx += x[i]
        sumy += y[i]
        sumx2 += x[i]**2
        sumx3 += x[i]**3
        sumx4 += x[i]**4
        sumxy += x[i] * y[i]
        sumx2y += x[i]**2 * y[i]
    A[0,0] = len(x)
    A[0,1] = sumx 
    A[0,2] = sumx2
    A[0,3] = sumy
    A[1,0] = sumx
    A[1,1] = sumx2
    A[1,2] = sumx3
    A[1,3] = sumxy
    A[2,0] = sumx2
    A[2,1] = sumx3
    A[2,2] = sumx4
    A[2,3] = sumx2y
    roots2 = np.linalg.solve(A[:,0:-1], A[:,-1])
    y2 = np.zeros(len(x))
    for i in range(len(y1)):
        y2[i] = roots2[0] + x[i] * roots2[1] + x[i]**2 * roots2[2]

    return y1, y2


def main(x, y):
    y1, y2 = method_least_squares(x,y)
    F1 = 0
    F2 = 0
    for i in range(len(y)):
        F1 += (y[i] - y1[i])**2
        F2 += (y[i] - y2[i])**2
    plt.title("График многочлена и приближающих многочленов 1-ой и 2-ой степени")
    plt.text(-4, -7.5, "Сумма квадратов ошибок первой степени: " + str(np.around(F1, 2)))
    plt.text(-4, -8.5, "Сумма квадратов ошибок второй степени: " + str(np.around(F2 ,2)))
    plt.xlabel("x") 
    plt.ylabel("y")
    plt.grid()
    plt.axis([-5, 5, -10, 10])
    plt.plot(x, y, label = "Исходный многочлен")
    plt.plot(x, y1, label = "Приближающий многочлен 1-ой степени")
    plt.plot(x, y2, label = "Приближающий многочлен 2-ой степени")
    plt.legend()
    plt.show()


x = np.array([-5.0,	-3.0, -1.0, 1.0, 3.0, 5.0])
y = np.array([-1.3734, -1.249, -0.7854, 0.7854, 1.249, 1.3734])

main(x, y)
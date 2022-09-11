import numpy as np
def Cubic_spline(x, y, X):
    A = np.zeros((3, 1))
    B = np.zeros((3, 3))
    results = np.zeros((4, 4))
    roots = np.zeros(3)
    f = 0

    for i in range(2, 5):
        A[i - 2] = (3 * ((y[i] - y[i - 1]) / (x[i] - x[i - 1]) +
                (y[i - 1] - y[i - 2]) / (x[i - 1] - x[i - 2])))
        for j in range(B.shape[0]):
            for k in range(B.shape[1]):
                if j == k:
                    B[j, k] = 2 * ((x[i - 1] - x[i - 2]) + (x[i] - x[i - 1]))
                elif j < k and (k != B.shape[0] - 1 or j != 0):
                    B[j, k] = (x[i] - x[i - 1])
                elif j > k and (j != B.shape[0] - 1 or k != 0):
                    B[j, k] = (x[i - 1] - x[i - 2])

    roots = np.linalg.solve(B, A)
    roots = np.insert(roots, 0, 0, axis = 0)

    for i in range(results.shape[0]):
        for j in range(results.shape[1]):
            if i != results.shape[0] - 1:
                if j == 0:
                    results[i, j] = y[i]
                if j == 1:
                    results[i, j] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]) - ((x[i + 1] - x[i]) * roots[i + 1] + 2 * roots[i]) / 3
                if j == 2:
                    if i == 0:
                       results[i, j] = 0
                    else:
                        results[i, j] = roots[i]
                if j == 3:
                    results[i, j] = (roots[i + 1] - roots[i]) / (3 *  (x[i + 1] - x[i]))
            else:
                if j == 0:
                    results[i, j] = y[i]
                if j == 1:
                    results[i, j] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]) - (2 * (x[i + 1] - x[i]) * roots[i]) / 3
                if j == 2:
                    results[i, j] = roots[i]
                if j == 3:
                    results[i, j] = -roots[i] / (3 * (x[i + 1] - x[i]))
    
    f = results[1, 0] + results[1, 1] * (X - x[1]) + results[1, 2] * (X - x[2])**2 + results[1, 3] * (X - x[3])**3

    return f


def main(x, y, X):
    print("Заданный X = ", X, " находится в этом отрезке:", x[1], " - ", x[2])
    print("Значения функции на этом отрезке:", y[1], " - ", y[2])
    print("Значение функции в X методом кубического сплайна: ", Cubic_spline(x, y, X))


x = np.array([-3.0, -1.0, 1.0, 3.0, 5.0])
y = np.array([-1.249, -0.7854, 0.7854, 1.249, 1.3734])
X = -0.5

main(x, y, X)
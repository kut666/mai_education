import math
import numpy as np

def det_matrix(matrix, sum):
    matrix2 = np.copy(matrix)
    width = len(matrix2)
    if width == 1:
        return matrix2[0][0]
    elif len(matrix2) != 2:
        if len(matrix2) == len(matrix2[0]):
            if matrix2[0,0] == 0:
                for i in range(1, width):
                    if matrix2[0, i] != 0:
                        matrix2[:, [0, i]] = matrix2[:, [i, 0]]
                        swapped = True
                        sum = sum * (-1)
                        break
            if matrix2[0][0] != 0:
                sum = sum * matrix2[0][0] * (-1)**2
                k = matrix2[0][0]
                for i in range(len(matrix2)):
                    matrix2[i][0] = matrix2[i][0] / k
                for i in range(len(matrix2) - 1):
                    for j in range(len(matrix2[0]) - 1):
                        matrix2[i + 1][j + 1] = matrix2[i + 1][j + 1] - matrix2[i + 1][0] * matrix2[0][j + 1]
                matrix2 = np.delete(matrix2, 0, axis=1)
                matrix2 = np.delete(matrix2, 0, axis=0)
                sum = det_matrix(matrix2, sum)
    elif len(matrix2) == 2:
        sum = sum * (matrix2[0][0] * matrix2[1][1] - matrix2[0][1] * matrix2[1][0])
    return sum

print(det_matrix([[-5.0, 0.0, 10.0, -8.0], [4.0, 0.0, 6.0, 8.0], [-6.0, 1.0, 6.0, -9.0], [6.0, -6.0, 5.0, -4.0]], 1))
import numpy as np


def numerical_differentiation1(x, y, a):
	left_dx = (y[a] - y[a - 1]) / (x[a] - x[a - 1])
	right_dx = (y[a + 1] - y[a]) / (x[a + 1] - x[a])
	dx = ((y[a] - y [a - 1]) / (x[a] - x[a - 1]) +
		(((y[a + 1] - y[a]) / (x[a + 1] - x[a]) - (y[a] - y [a - 1]) / (x[a] - x[a - 1])) / (x[a + 1] - x[a - 1])) *
		(2 * x[a] - x[a - 1] - x[a]))
	return left_dx, right_dx, dx


def numerical_differentiation2(x, y, a):
	dx2 = 2 * (((y[a + 1] - y[a]) / (x[a + 1] - x[a])) - ((y[a] - y[a - 1]) / (x[a] - x[a - 1]))) / (x[a + 1] - x[a - 1])
	return dx2


def main(x, y, a):
	l_dx, r_dx, dx = numerical_differentiation1(x, y, a)
	dx2 = numerical_differentiation2(x, y, a)
	print("Левосторонняя производная: ", np.around(l_dx, 2), "\n"
		  "Правосторонняя проивзодная: ", np.around(r_dx, 2), "\n"
		  "Производная со вторым порядком точности: ", np.around(dx, 2), "\n"
		  "Вторая производная: ", np.around(dx2, 2))


x = np.array([0.0, 0.5, 1.0, 1.5, 2.0])
y = np.array([0.0, 0.97943,	1.8415,	2.4975,	2.9093])
a = 2
main(x, y, a)
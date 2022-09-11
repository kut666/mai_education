import numpy as np, matplotlib.pyplot as plt


N = 8
T1 = N / 10
T2 = N / 100
T3 = N / 1000

P = lambda w, k: k + 1 - (T1 * T2 + T2 * T3 + T1 * T3) * w**2
Q = lambda w: w * (T1 + T2 + T3 - T1 * T2 * T3 * w**2)

i = np.arange(0, 200, 1)
w = np.tan((i * np.pi) / (2 * len(i)))


plt.plot(P(w, 1), Q(w), label = "k = 15")
plt.plot(P(w, 50), Q(w), label = "k = 50")
plt.plot(P(w, 122.21), Q(w), label = "k = 122.21")
plt.plot(P(w, 127), Q(w), label = "k = 125")
plt.xlabel("P")
plt.ylabel("Q")
plt.axis([-130, 130, -20, 20])
plt.grid()
plt.legend()
plt.show()



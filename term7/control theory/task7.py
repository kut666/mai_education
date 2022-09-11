import numpy as np

theta = np.arange(0, 2, 0.1)
x = np.zeros(len(theta))
analytic = np.zeros(len(theta))
error = np.zeros(len(theta))



for i in range(len(theta)):  
    x[i] = 0.000081933679 + 0.1106104056*theta[i] - 0.005530520281*theta[i]**2
    analytic[i] = -np.exp(-theta[i] / 9) + 1
    error[i] = abs(x[i] - analytic[i])
    
print(error)
print(max(error))
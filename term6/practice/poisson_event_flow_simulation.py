import math
import time
import random

RAND_Seed = 1
def random_alfa():                                   #функция рандомайзера
    global RAND_Seed 
    RAND_Seed = (RAND_Seed * 762939453125) % 1099511627776
    return RAND_Seed / 1099511627776


def simulation_exponential_distribution(mu_above): #моделирование случайных величин с показательным распредением                          
    return -math.log(random_alfa()) / mu_above 


def simulation_mu(t, mu_above):             #функция mu(t)
    return mu_above * math.exp(-2 * t)                  


def mathematical_expectation(t, mu_above):            #точное математическое ожидание
    return (mu_above / 2) * (1 - math.exp(-2 * t))


def maximum_cross_section_method(t0, tk, mu_above):     #метод максимального сечения
    teta = t0 + simulation_exponential_distribution(mu_above)    
    while random_alfa() > (simulation_mu(teta, mu_above) / mu_above) and teta < tk:                   
        teta += simulation_exponential_distribution(mu_above)
    if teta <= tk:  
        return teta
    else:
        return 0
    

def modified_maximum_cross_section_method(t0, tk, mu_above):    # модифицированный метод максимального сечения                          
    teta = t0 + simulation_exponential_distribution(mu_above)
    composition = 1 - simulation_mu(teta, mu_above) / mu_above
    alfa = random_alfa()
    while (1 - alfa <= composition and teta < tk):                           
        teta += simulation_exponential_distribution(mu_above)  
        composition *= (1 - simulation_mu(teta, mu_above) / mu_above)
    if teta <= tk:
        return teta
    else:
        return 0
        

def main(t0, tk, mu_above, N):
    e = 0   
    work_time = time.time()
    for i in range(N):
        teta = maximum_cross_section_method(t0, tk, mu_above)
        while teta > 0:
            e += 1
            teta = maximum_cross_section_method(teta, tk, mu_above)
    work_time = time.time() - work_time
    print("Метод максимального сечения\n")
    print("Время моделирования: ", work_time)
    print("Точное значение мат. ожидания:", mathematical_expectation(tk, mu_above))
    print("Среднее выборочное:", e / N)
    print("Интенсивность потока:", mu_above)
    print("Количество итераций:", N, "\n") 
    
    e = 0   
    work_time = time.time()
    for i in range(N):
        teta = modified_maximum_cross_section_method(t0, tk, mu_above)
        while teta > 0:
            e += 1
            teta = modified_maximum_cross_section_method(teta, tk, mu_above)
    work_time = time.time() - work_time
    print("Модифицированный метод максимального сечения\n")
    print("Время моделирования: ", work_time)
    print("Точное значение мат. ожидания:", mathematical_expectation(tk, mu_above))
    print("Среднее выборочное:", e / N)
    print("Интенсивность потока:", mu_above)
    print("Количество итераций:", N, "\n") 


t0 = 0                  #начальное время
tk = 2                  #конечное время
mu_above = 10           #верхняя оценка mu
N = 5000000             #число реализаций
main(t0, tk, mu_above, N)
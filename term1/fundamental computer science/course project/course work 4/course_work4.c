#include <stdio.h>
#include <math.h>

double eps() {
	double e = 1;
	while (1 + e != 1) {
		e /= 2;
	}
	return e;
}

double F1 (double x) {
	return (3 * x * tan(x) - 1) / 3;
}

double F2 (double x) {
	return tan(x / 2) - 1 / tan(x / 2) + x;
}

double dih(double (*F)(double), double a, double b,double e) {
	double c;
	int i = 0;
	while (fabs(a - b) > e && i < 100) {
		c = (a + b) / 2;
		if ((F(a) * F(c)) > 0) {
			a = c;
		}
		if ((F(b) * F(c)) > 0) {
			b = c;
		}
		i++;
	}
	c = (a + b) / 2;
	return c;
}

double iter(double (*F)(double), double k, double a, double b, double e){
	double x = (a + b) / 2;
	int i = 0;
	while (fabs(F(x)) > e && i < 100) {
		x = x - k * F(x);
		i++;
	}
	return x;
}

double newton(double(*F)(double), double k, double a, double b, double e){
	double x = (a + b) / 2;
	int i = 0;
	while (fabs(F(x) / k ) > e && i < 100) {
		x = x - F(x) / k ;
		i++;
	}
	return x;
}


int main() {
	double a1, b1, a2, b2;
	printf("eps = %e\n", eps());
	a1 = 0.2;
	b1 = 1;
	a2 = 1;
	b2 = 2;
	printf("----------------------------------------------------------------------------------\n");
	printf("       Function        |  Dihotomy_method   |  Iteration_method   |  Newton_method  \n");
	printf("    x * tg(x) - 1/3    |  %.4lf            |  %.4lf             |  %.4lf    \n", dih(F1, a1, b1, eps()), iter(F1, 1, a1, b1, eps()), newton(F1, 1, a1, b1, eps()));
	printf(" tg(x/2) -ctg(x/2) + x |  %.4lf            |  %.4lf             |  %.4lf    \n", dih(F2, a2, b2, eps()), iter(F2, 0.1, a2, b2, eps()), newton(F2, 10, a2, b2, eps()));
	printf("----------------------------------------------------------------------------------\n");
	printf("\n");
	printf("------------------------------------------------------------------------------------\n");
	printf("       Function        |  Dihotomy_method   |  Iteration_method  |  Newton_method  \n");
	printf("    x * tg(x) - 1/3    | %.16lf | %.16lf | %.16lf  \n", dih(F1, a1, b1, eps()), iter(F1, 1, a1, b1, eps()), newton(F1, 1, a1, b1, eps()));
	printf(" tg(x/2) -ctg(x/2) + x | %.16lf | %.16lf | %.16lf  \n", dih(F2, a2, b2, eps()), iter(F2, 0.1, a2, b2, eps()), newton(F2, 10, a2, b2, eps()));
	printf("------------------------------------------------------------------------------------\n");
	return 0;
}
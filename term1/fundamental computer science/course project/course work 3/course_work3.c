#include <stdio.h>
#include "math.h"

double eps() {
	double e = 1;
	while (1 + e != 1) {
		e /= 2;
	}
	return e;
}

double anti_fac(double k) {
	double z = 1, f = 1;
	while (k != 0) {
		f = f * z;
		k--;
		z++;
	}
	f = 1 / f;
	return f;
}

double formula_taylora(double x, double e, int* i, double k) {
	double m1 = 1, m2 = x, m3 = 1, res = m1 * m2 * m3, t = 0, l;
	*i = 1;
	while (fabs((m1 * m2 * m3)) > (e * pow(10, k))) {
		if (*i == 100) {
			printf("Iteration = 100, value = %lf\n", fabs((sin(x) - res)));
			break;
		}
		t++;
		m1 = pow(-1, t);
		l = 2 * t + 1;
		m2 = pow(x, l);
		m3 = anti_fac(l);
		res += m1 * m2 * m3;
		(*i)++;
	}
	return res;
}

int main() {
	int n, *i, i1 = 0;
	i = &i1;
	double a = 0.0, b = 1.0, x, part, k;
		printf("eps = %e\n", eps());
		scanf("%d\n", &n);
		scanf("%lf", &k);
		part = (b - a) / n;
	printf("-------------------------------------------------------------------------\n");
	printf("   x    |        tayor_func          |        value          | iterations\n");
	for (int j = 0; j <= n; j++) {
		x = a + part * j;
		printf("%.6lf|    %.18f    |  %.18f |     %d\n", x, formula_taylora(x, eps(), i, k), sin(x), *i);
	}
	printf("-------------------------------------------------------------------------\n");
	return 0;
}
#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int cel(int num, int den) {
	return (num*den > 0) ? num / den : (num%den == 0) ? num / den : num / den - 1;
}

int ost(int a, int b) {
	return a - b * (cel(a, b));
}

int max(int a, int b) {
	return (a > b) ? a : b;
}

int min(int a, int b) {
	return (a > b) ? b : a;
}
int min2(int a, int b, int c)  {
        int minimal;
	if (a < b) {
		minimal = a;
	}
	else {
		minimal = b;
	}
if (minimal > c) {
	minimal = c;
 }
        return minimal;
	}

int main() {

	int i = 10, j = 20, l = -1, sign, k = 0, x, y, z;
printf ("%d %d %d %d\n", k, i, j, l);
		for (k ; k < 50; k++) {
			if (i > j) {
				sign = 1;
			}
			if (i = j) {
				sign = 0;
			}
			if (i < j) {
				sign = -1;
			}
			x = ost((abs(max(i*(k+5),j*(k+6))) - abs(min(j*(k+7),l*(k+8)))), 20);
			y = ost(((3 - sign)*abs(min2(i*l+5,j*l-3,i*j+6))), 25) - 7;
			z = ost(i, 10) + ost(j, 10) + ost(l, 10);
                        i = x;
                        j = y;
                        l = z;
			printf("%d %d %d %d\n", k+1, i, j, l);
			if (i > 5 && i < 15 && j < -5 && i > -15) {
				break;
			}
		}
	return 0;
}

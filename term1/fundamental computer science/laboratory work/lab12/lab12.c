#include <stdio.h>
#include <stdlib.h>

int cel(int num, int den) {
	return (num*den > 0) ? num / den : (num%den == 0) ? num / den : num / den - 1;
}

int ost(int a, int b) {
	return a - b * (cel(a, b));
}

int main() {
	int x, c, n, k, f;
	scanf("%d", &x);
	x = abs(x);
	if (x >= 0 && x <= 10) {
		k = 1;
		printf("%d\n", k);
	}
	else {
		while (x > 10) {
			c = ost(x, 10);
			f = x / 10;
			n = ost(f, 10);
			x = x / 10;
			if (c == n) {
				k = 0;
				break;
			}
			else {
				k = 1;
			}
		}
		printf("%d\n", k);
	}
	return 0;
}
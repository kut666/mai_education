#include <stdio.h> 
#include <limits.h> 
int main() {
	int n, ma, k, i, j, s;
	ma = INT_MIN;
	s = 0;
	scanf("%d", &n);
	int a[n][n];
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++) {
			scanf("%d", &a[i][j]);
			if (a[i][j] > ma) {
				ma = a[i][j];
				k = i;
			}
		}
	for (j = 0; j < n; j++)
		s += a[k][j];
	printf("%d\n", s);
	return 0;
}
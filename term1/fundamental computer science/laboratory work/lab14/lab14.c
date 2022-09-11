#include <stdio.h>

int main() {
	int n, i, j, k, l, p, u;
	scanf("%d", &n);
	int a[n][n];
	for (i = 0; i < n; i++) {
		for (j = 0; j < n; j++) {
			scanf("%d", &a[i][j]);
		}
	}
	k = n * n;
	for (u = 1; u <= n; u++) {
		printf("%d ", a[n - u][n - 1]);
		--k;
	}
	u = n;
	p = n - 2;
	l = 0;
	 while (k != 0) {
	for (j = p; j >= l; j--) {
		printf("%d ", a[l][j]);
		--k;
	}
	l = l + 1;
		if (k != 0)
		{
			for (i = l; i <= n - l; i++) {
				printf("%d ", a[i][n - u]);
				--k;
			}
		}
		else break;
		if (k != 0) {
			for (j = l; j <= n - 1 - l; j++) {
				printf("%d ", a[n - l][j]);
				--k;
			}
		}
		else break;
		if (k != 0)
		{
			for (i = p; i >= l; i--) {
				printf("%d ", a[i][p]);
				--k;
			}
		}
		else break;
		--p;
		--u;
	 }
     printf("\n");
		return 0;
}
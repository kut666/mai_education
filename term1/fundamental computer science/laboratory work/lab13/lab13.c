#include <stdio.h>

int main() {
	int k = 0, x;
	while ((x = getchar()) != '\n') {
		if (x >= 'A' && x <= 'Z') {
			k += 1;
				printf("%d\n", k);
		}
		if (k >= 2) {
			printf("Yes\n");
			break;
		} 
		if (x == ' ') {
			k = 0;
		}
	}
	if (k < 2) {
		printf("No\n");
	}
}
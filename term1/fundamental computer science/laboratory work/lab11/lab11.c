#include <stdio.h>

int main() {
	int n = 0, i = -1, flag = 0, k = 0;
	char str[100];
	fgets(str, 100, stdin);
	while (str[++i] != '\n') {
		if (str[i] >= '0' && str[i] <= '7')
		{
			n = n * 8 + (str[i] - '0');
			flag = 1;
		}
		else if (str[i] != ' ')
		{
			flag = 0;
			n = 0;
			while (str[i] != '\n' && str[i] != ' ' && str[i] != '\0')
				i++;
		}
		else //if (str[i] == ' ')
		{
			if (flag && n > 10 && n < 1000)
				k++;
			flag = 0;
			n = 0;
		}
	}
	if (flag && n > 10 && n < 1000)
		k++;
	printf("%d\n", k);
	return 0;
}
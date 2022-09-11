#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <strings.h>
#include <math.h>

#define MAX_Q 10
#define MAX_S 100
#define MAX_K 6

size_t n = MAX_S;

int counter (const char *file) {
	FILE *in = fopen(file, "r");
	int k = 0;
	char a[100];
	while (!feof(in)) {
		fgetc(in);
		fgetc(in);
		fgetc(in);
		fgetc(in);
		fgetc(in);
		if (fgets(a, 100, in) !=NULL)
			k++;
	}
	rewind(in);
	fclose(in);
	return k;
}

int keys_poem(const char *file1, const char *file2, const char *file3) {
	FILE *in = fopen(file1, "r");
	FILE *keys = fopen(file2, "w");
	FILE *verse = fopen(file3, "w");
	char poem[100];
	char a, b, c, d, e;
	while (!feof(in)) {
		if ((a = fgetc(in)) != EOF) {
			b = fgetc(in);
			c = fgetc(in);
			d = fgetc(in);
			e = fgetc(in);
			fputc(a, keys);
			fputc(b, keys);
			fputc(c, keys);
			fputc(d, keys);
			fputc(e, keys);
			fputs("\n", keys);
			fgetc(in);
		}
		if (fgets(poem, 100, in) != NULL)
			fputs(poem, verse);
	}
		rewind(in);
		fclose(in);
		rewind(keys);
		fclose(keys);
		rewind(verse);
		fclose(verse);
}

void string_by_key(const char *file, int re, int im) {
	FILE *in = fopen(file, "r");
	int k = 0;
	char h[100];
	while (!feof(in)) {
		if (fgetc(in)-'0' == re) {
			fgetc(in);
			fgetc(in);
			fgetc(in);
			if (fgetc(in) - '0' == im) {
				fgets(h, 100, in);
				printf("%s", h);
				k++;
			}
		}
	}
	if (k == 0)
		printf("Key entered incorrectly!\n");
}

void print_table(const char *file) {
	FILE *in = fopen(file, "r");
	char a[100];
	while (!feof(in)) {
		if (fgets(a, 100, in) != NULL)
			printf("%s", a);
	}
	rewind(in);
	fclose(in);
}

void swap(char **first, char **second) {
	char *temp = *first;
	*first = *second;
	*second = temp;
}

void qsortx(double *modul, size_t low, size_t high, char **keys, char **poem) {
	size_t i, j;
	double tmp, pivot;

	i = low;
	j = high;

	pivot = modul[(low + (high - low) / 2)];
	do {
		while (modul[i] < pivot) {
			i++;
		}
		while (modul[j] > pivot) {
			j--;
		}
		if (i <= j) {
			if (modul[i] > modul[j]) {
				tmp = modul[i];
				modul[i] = modul[j];
				modul[j] = tmp;
				swap(&keys[i], &keys[j]);
				swap(&poem[i], &poem[j]);

			}
			i++;
			if (j > 0) {
				j--;
			}
		}
	} while (i <= j);

	if (i < high) {
		qsortx(modul, i, high, keys, poem);
	}
	if (j > low) {
		qsortx(modul, low, j, keys, poem);
	}
}

void reverse(double *value, char **keys, char **poem, int iter) {
	char **tmp1, **tmp2, *tmp;
	double modul[MAX_Q];
	int i = 0;
	tmp1 = malloc(MAX_Q * sizeof(char*));
	tmp1[i] = malloc(MAX_Q * sizeof(char*));
	tmp2 = malloc(MAX_Q * sizeof(char*));
	tmp2[i] = malloc(MAX_Q * sizeof(char*));
	for (i = 0; i < iter / 2; i++) {
		tmp1[i] = keys[i];
		tmp2[i] = poem[i];
		modul[i] = value[i];
		keys[i] = keys[iter - i - 1];
		poem[i] = poem[iter - i - 1];
		value[i] = value[iter - i - 1];
		keys[iter - i - 1] = tmp1[i];
		poem[iter - i - 1] = tmp2[i];
		value[iter - i - 1] = modul[i];
	}
}

void menu() {
	printf("==============================\n");
	printf("||   1-Print table          ||\n");
	printf("||   2-Print of sort table  ||\n");
	printf("||   3-Print string by key  ||\n");
	printf("||   4-Reverse table        ||\n");
	printf("||   5-Menu                 ||\n");
	printf("||   0-End                  ||\n");
	printf("==============================\n");
	printf("\n");
}

int main() {
	int a;
	char ch = '9';
	char **keys, **poem;
	a = counter("table.txt");
	keys_poem("table.txt", "keys.txt", "verse.txt");
	menu();
	FILE *in = fopen("verse.txt", "r");
	int k = 0, count = 0, imag, real;
	poem = malloc(MAX_Q * sizeof(char*));
	poem[k] = malloc(MAX_Q * sizeof(char*));
	bzero(poem[k], MAX_Q);
	while (getline(&poem[k], &n, in) != -1 && count < a) {
		count++;
		k++;
		poem[k] = malloc(MAX_Q * sizeof(char*));
		bzero(poem[k], MAX_Q);
	}
	rewind(in);
	fclose(in); 

	FILE *in2 = fopen("keys.txt", "r");
	 k = 0;
	char string[MAX_K];
	keys = malloc(MAX_Q * sizeof(char *));
	keys[k] = malloc(MAX_Q * sizeof(char*));
	while (!feof(in2) && k < MAX_Q) {
		fscanf(in2, "%s\n", string);
		keys[k] = strdup(string);
		k++;
	}
	for (k = 0; k < a; k++)
	rewind(in2);
	fclose(in2);

	FILE *modul = fopen("keys.txt", "r");
	int z = 0;
	double value[a];
	int re, im;
	double r, i, sum_sqr, mod;
	while (!feof(modul)) {
		re = fgetc(modul);
		fgetc(modul);
		fgetc(modul);
		fgetc(modul);
		im = fgetc(modul);
		fgetc(modul);
		if (re >= '0' && re <= '9' && im >= '0' && im <= '9') {
			r = re - '0';
			i = im - '0';
			sum_sqr = pow(r, 2) + pow(i, 2);
			mod = sqrt(sum_sqr);
			value[z] = mod;
		}
		z++;
	}
	rewind(modul);
	fclose(modul);

	while (ch != '0') {
		printf("=> ");
		scanf(" %c", &ch);
		switch (ch) {
		case '1':
			print_table("table.txt");
			break;
		case '2':
			a = counter("table.txt");
			qsortx(value, 0, a - 1, keys, poem);
			for (int t = 0; t < a; t++)
				printf("%s  %s", keys[t], poem[t]);
			break;
		case '3':
			printf("Enter the real part: ");
			scanf("%d", &real);
			printf("Enter the imaginary part: ");
			scanf("%d", &imag);
			string_by_key("table.txt", real, imag);
			break;
		case '4':
			a = counter("table.txt");
			reverse(value, keys, poem, a);
			for (int p = 0; p < a; p++)
				printf("%s  %s", keys[p], poem[p]);
			break;
		case '5':
			menu();
			break;
		}
	}
	return 0;
} 
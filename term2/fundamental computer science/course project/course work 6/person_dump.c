#include "stdio.h"
#include "string.h"
#include "locale.h"
#include "stdbool.h"

#include "person.h"

int main(int argc, const char *argv[]) {
	if (argc != 3) {
		printf("Error\n");
		return 1;
	}
	person p;
	FILE *in = fopen(argv[1], "r");
	FILE *out = fopen(argv[2], "wb");
	while (!feof(in)) {
		fscanf(in, "%s %s %s %s %s %d %d %d\n", p.surname, p.np, p.gender, p.school, p.medal, &p.mat, &p.inf, &p.rus);
		fwrite(&p, sizeof(person), 1, out);
	}
	fclose(in);
	fclose(out);
	return 0;
}
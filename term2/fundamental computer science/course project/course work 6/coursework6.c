#include "stdio.h"
#include "stdlib.h"
#include "malloc.h"
#include "string.h"

#include "person.h"

void print_data(const char *file) {
	FILE *in = fopen(file, "rb");
	person p;
	while (fread(&p, sizeof(person), 1, in)) {
		printf("%s %s %s %s %s %d %d %d\n", p.surname, p.np, p.gender, p.school, p.medal, p.mat, p.inf, p.rus);
	}
	fclose(in);
}

 void task(const char *file, int par) {
	FILE *in = fopen(file, "rb");
	person p;
	int sum = 0;
	while (fread(&p, sizeof(person), 1, in)) {
		sum = p.mat + p.inf + p.rus;
		if (strcmp(p.gender, "m") == 0 && strcmp(p.medal, "y") == 0 && sum < par) {
			printf("%s %s\n", p.surname, p.np);
		}
	}
	fclose(in);
}

 int main(int argc, const char *argv[]) {
	 if (argc < 2) {
		 printf("Etner a file name!\n");
		 return 1;
	 }
	 if (argc == 2) {
		 printf("Enter operation key!\n");
		 return 2;
	 }
	 person p;
	 FILE *in = fopen(argv[1], "rb+wb");
	 int par = 0, x = 0;
	 char surname[20], np[3];
	 if (argc > 2) {
		 if (*argv[2] == 'f') {
			 print_data(argv[1]);
		 }
		 if (*argv[2] == 'p') {
			 printf("Enter pass mark: ");
			 scanf("%d", &par);
			 task(argv[1], par);
		 }
		 if (*argv[2] == 'a') {
			 fseek(in, 0, SEEK_END);
			 printf("Enter data about applicant: ");
			 scanf("%s %s %s %s %s %d %d %d", p.surname, p.np, p.gender, p.school, p.medal, &p.mat, &p.inf, &p.rus);
			 fwrite(&p, sizeof(person), 1, in);
		 }
		 if (*argv[2] == 'd') {
			 printf("Enter surname and np applicant: ");
				 scanf("%s %s", surname, np);
			 FILE *out = fopen("temp.bin", "wb+");
			 while (!feof(in)) {
				 if (fread(&p, sizeof(p), 1, in) == 0)
					 break;
				 if (strcmp(p.surname, surname) == 0 && strcmp(p.np, np) == 0)
					 x = 1;
				 else
					 fwrite(&p, sizeof(p), 1, out);
			 }
			 if (x == 0)
				 printf("Not found\n");
			 else {
				 fclose(in);
				 in = fopen(argv[1], "wb+");
				 fseek(out, 0, SEEK_SET);
				 while (!feof(out)) {
					 if (fread(&p, sizeof(p), 1, out) == 0)
						 break;
					 fwrite(&p, sizeof(p), 1, in);
				 }
			 }
			 fclose(out);
		 }
	 }
	 fclose(in);
	return 0;
}
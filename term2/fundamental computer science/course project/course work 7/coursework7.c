#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

void error1() { printf("Matrix is not square\n"); };
void error2() { printf("Can't open file\n"); };
void error3() { printf("No matrix anymore\n\n"); };

typedef struct node {
	struct node *next;
	double value;
}node;

struct node* init(double a) {
	node *lst = (node*)malloc(sizeof(node));
	lst->value = a;
	lst->next = NULL;
	return(lst);
};

struct node * push(node *lst, double num) {
	node *tmp = (node*)malloc(sizeof(node));
	lst->next = tmp;
	tmp->value = num;
	tmp->next = NULL;
	return(tmp);
};

void print(node *head) {
	if (head == NULL)printf("empty");
	else {
		while (head) {
			printf("%-5.1lf ", head->value);
			head = head->next;
		}
	}
	printf("\n");
}
void printt(node *head) {
	if (head == NULL)printf("empty");
	else {
		while (head) {
			printf("%-5.0lf ", head->value);
			head = head->next;
		}
	}
	printf("\n");
}

typedef struct matrix {
	node **cip;
	node *pi;
	node *ye;
}matrix;

matrix m, mm;
int stlb = 0, str = 0, *b = NULL, res;
int *bb = NULL, count2;
FILE* file;

int enter() {
	double elem;
	int column = 1, i = 0, check = 1, count = 0;
	stlb = 0, str = 0;
	char s, s2;
	m.cip = (node**)malloc(i * sizeof(node*));
	node *p1, *p2;
	if (feof(file) != 0) { 
		error3();
		return 1;
	}
	while (fscanf(file, "%lf", &elem) != EOF) {
		if (elem != 0) {
			if (count == 0) {
				m.ye = init(elem);
				m.pi = init(column);
				p1 = m.ye;
				p2 = m.pi;
			}
			if (check) {
				m.cip = (node**)realloc(m.cip, (i + 1) * sizeof(node*));
				b = (int*)realloc(b, (i + 1) * sizeof(int));
				*(m.cip + i) = p1;
				*(b + i) = count;
				i++;
			}
			if (count != 0) {
				p1 = push(p1, elem);
				p2 = push(p2, column);
			}
			count++;
			check = 0;
		}
		column++;
		fscanf(file, "%c", &s);
		if (s == '\n') {
			stlb = column - 1; column = 1; check = 1; str++;
			if (i < str) {
				m.cip = (node**)realloc(m.cip, (i + 1) * sizeof(node*));
				b = (int*)realloc(b, (i + 1) * sizeof(int));
				*(m.cip + i) = NULL;
				*(b + i) = -1;
				i++;
			}
			fscanf(file, "%c", &s2);
			if (s2 == '\n')break;
		}
	}
	return 0;
}

int output() {
	int i = 0, n = 1, c = -1;
	int *bbb;
	node *p1, *p2;
	p1 = m.ye; p2 = m.pi; bbb = b;
	printf("Matrix in the usual form :");
	for (int k = 0; k < str; k++) {
		n = 1;
		printf("\n"); c++;
		while (n <= stlb) {
			if (p2 && n == p2->value && *(bbb + c) != -1) {
				printf("%5.1lf ", p1->value);
				p1 = p1->next;
				p2 = p2->next;
			}
			else {
				printf("%5.1lf ", 0.0);
			}
			n++;
		}
	}
	for (int k = n; k < stlb + 1; k++)printf("%5.1lf ", 0.0);
	printf("\n");
	printf("\n");
	printf("Matrix in internal view : \n");
		if (m.ye == NULL)printf("All matrix elements are zero\n");
		printf("CIP : ");
		int k = 0;
		while (printf("%d  ", *(b + k)) > 0 && k < str - 1)k++;
		printf("\n");
		printf("PI  : "); printt(m.pi);
		printf("YE  : "); print(m.ye);
	return 0;
}
/*
int transform(int num) {
	int i = str, j = stlb;
	if (i != j) { error1(); return 1; }
	if (g == 0) {
		mm.pi = init(ed);
		pp1 = mm.ye;
		pp2 = mm.pi;
		mm.cip = (node**)realloc(mm.cip, (ii + 1) * sizeof(node*));
		*(mm.cip + ii) = pp1;
		bb = (int*)realloc(bb, (ii + 1) * sizeof(int));
		*(bb + ii) = count2;
		ii++; g++;
	}
	int i = 0, n = 1, c = -1;
	int *bbb;
	node *p1, *p2;
	if (num == 2) { p1 = m.ye; p2 = m.pi; bbb = b; }
	else { p1 = mm.ye; p2 = mm.pi; bbb = bb; }
	p2 = NULL;
	for (int k = 0; k < j; k++) {
		n = 1;
		c++;
		while (n < stlb)){
		for (int l = i; l > 0; l--) {
			if (p2 && n == p2->value && *(bbb + c) != -1) {
				pp2 = 0;
				while (pp2->ppp2 != p2) pp2 = pp2->ppp2;
				swap(p1, p2); p1 = p1->next; p2->value = pp2;
			}
		}
		if (num == 2) { p1 = m.ye; p2 = m.pi; bbb = b; }
		else { p1 = mm.ye; p2 = mm.pi; bbb = bb; }
		double a[x][y]; double b[x][y];
		for (int x = 0; x < str; x++) {
			for (int y = 0; y < stlb; y++) {
				n = 1;
				printf("\n"); c++;
				while (n <= stlb) {
					if (p2 && n == p2->value && *(bbb + c) != -1) {
						a[x][y] = p1->value; b[y][x] = p1->value;
						p1 = p1->next;
						p2 = p2->next;
					}
					else {
						a[x][y] = 0.0; b[y][x] = 0.0;
					}
					n++;
				}
			}
			x = 0; y = 0; int prvrk1 = 0; while (x <= str && y <= stlb) { if (a[x][y] != 0) prvrk = -1; x++; y++; }
			int prvrk2 = 0; for (int x = 0; x < str; x++) { for (int y = 0; y < stlb; y++) { if (a[x][y] != -b[x][y]) prvrk2 = -1; } }
			n++;
		}
		}
	}
	return 0;
}
	*/
 void menu() {
	 printf("==========================================\n");
	 printf("||   1-Enter actual matrix              ||\n");
	 printf("||   2-Output matrix in different types ||\n");
	 printf("||   3-Tranform the actual matrix       ||\n");
	 printf("||   4-Menu                             ||\n");
	 printf("||   0-End                              ||\n");
	 printf("==========================================\n");
	 printf("\n");
 }

 int main() {
	 int n, chk = 1;
	 char ch = '9';
	 file = fopen("matr.txt", "r");
	 if (!file) {
		 error2();
		 return 1;
	 }
	 menu();
	 while (ch != '0') {
		 printf("=> ");
		 scanf(" %c", &ch);
		 switch (ch) {
		 case '1':
			 if (!enter())
				 printf("The matrix was successfully read\n\n");
			 chk = 0;
			 break;
		 case '2':
			 output();
			 printf("\n");
			 break;
		 case '3':
//			 if (!transform())
				 printf("The matrix was successfully transformed\n\n");
			 break;
		 case '4':
			 menu();
			 break;
		 }
	 }
	 return 0;
 }


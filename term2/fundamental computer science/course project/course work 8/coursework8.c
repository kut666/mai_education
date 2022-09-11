#include "stdio.h"
#include "stdlib.h"
#include "malloc.h"

typedef struct {
	int re;
	int im;
} complex;

typedef struct node {
	complex key;
	struct node *prev;
	struct node *next;
}spisok;

spisok *barrier1(spisok *node) {
	node = (spisok*)malloc(sizeof(spisok));
	node->key.im = 0;
	return node;
}

spisok *barrier2(spisok *barrier1, spisok *node) {
	node = (spisok*)malloc(sizeof(spisok));
	node->key.im = 0;
	barrier1->next = node;
	node->prev = barrier1;
	return node;
}

void push_node(spisok *node, int iter, complex key) {
	if (iter < 1)
		iter = 1;
	while ((iter > 1) && (node->key.im != 0)) {
		node = node->next;
		iter--;
	}
	spisok *newnode = malloc(sizeof(spisok));
	newnode->key.re = key.re;
	newnode->key.im = key.im;
	newnode->next = node->next;
	newnode->prev = node;
	node->next->prev = newnode;
	node->next = newnode;
}

void pop_node(spisok *node, int iter) {
	while (iter > 0) {
		node = node->next;
		iter--;
	}
	node->next->prev = node->prev;
	node->prev->next = node->next;
	free(node);
}

void print_spisok(spisok *node) {
	node = node->next;
	if (node->key.im == 0)
		return;
	else {
		printf("%d", node->key.re);
		printf("+i*");
		printf("%d  ", node->key.im);
		print_spisok(node);
	}
}

int counter(spisok *node) {
	int k = 0;
	node = node->next;
	while (node->key.im != 0) {
		k++;
		node = node->next;
	}
	return k;
}

int task(spisok *node) {
	int k = 0;
	node = node->next;
	while (node->next->key.im != 0) {
		if (node->key.re <= node->next->key.re) {
			k++;
			node = node->next;
		}
		else {
			k = 0;
			return 0;
			break;
		}
	}
	if (k != 0)
		return 1;
}

void menu() {
	printf("==========================\n");
	printf("||   1-Push node        ||\n");
	printf("||   2-Pop node         ||\n");
	printf("||   3-Print spisok     ||\n");
	printf("||   4-Count the length ||\n");
	printf("||   5-Curry to task    ||\n");
	printf("||   6-Menu             ||\n");
	printf("||   0-End              ||\n");
	printf("==========================\n");
	printf("\n");
}

int main() {
	spisok *a = NULL;
	spisok *b = NULL;
	int i, x, c;
	char ch = '9';
	complex n;
	a = barrier1(a);
	b = barrier2(a, b);
	menu();
	while (ch != '0') {
		printf("=> ");
		scanf("%s", &ch);
		switch (ch) {
		case '1':
			printf("Enter the index of the node: ");
			scanf(" %d", &i);
			printf("Enter the real part: ");
			scanf(" %d", &n.re);
			printf("Enter the imaginary part: ");
			scanf(" %d", &n.im);
			push_node(a, i, n);
			break;
		case '2':
			printf("Enter the index of the node: ");
			scanf(" %d", &i);
			pop_node(a, i);
			break;
		case '3':
			print_spisok(a);
			printf("\n");
			break;
		case '4':
			c = counter(a);
			printf("%d\n", c);
			break;
		case '5':
			x = task(a);
			if (x == 0)
				printf("False\n");
			else
				printf("True\n");
			break;
		case '6':
			menu();
			break;
		}
	}
	return 0;
}
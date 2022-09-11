#include "stdio.h"
#include "malloc.h"
#include "stdlib.h"

typedef struct node {
	int key;
	struct node *next;
}stack;

void push(stack **head, int key) {
	stack *tmp = malloc(sizeof(stack));
	if (tmp == NULL) {
		return;
	}
	tmp->next = *head;
	tmp->key = key;
	*head = tmp;
}

stack *pop(stack **head) {
	stack *out;
	if ((*head) == NULL) {
		return;
	}
	out = *head;
	*head = (*head)->next;
	return out;
}

void print_stack(stack *head) {
	if (head != NULL) {
		printf("%d  ", head->key);
		print_stack(head->next);
	}
}

int size(stack *head) {
	int k = 0;
	while (head) {
		k++;
		head = head->next;
	}
	return k;
}

void task(stack *head) {
	stack *tmp = NULL;
	int k = 0, i = 0, l, min;
	int a[100];
	k = size(head);
	while (head) {
		a[i] = head->key;
		free(head);
		head = head->next;
		i++;
	}
	for (i = 0; i < k ; i++) {
		min = i;
		for (int j = i + 1; j < k; j++)
			if (a[j] < a[min])
				min = j;
			l = a[min];
			a[min] = a[i];
			a[i] = l;
	}
	for (int i = 0; i < k; i++) {
		push(&tmp, a[i]);
	}
}

void menu() {
	printf("========================\n");
	printf("||   1-Push           ||\n");
	printf("||   2-Pop            ||\n");
	printf("||   3-Print stack    ||\n");
	printf("||   4-Curry to task  ||\n");
	printf("||   5-Menu           ||\n");
	printf("||   0-End            ||\n");
	printf("========================\n");
	printf("\n");
}

int main() {
	stack *a = NULL;
	int n = 0, ch = 10, x = 0;
	menu();
	while (ch != 0) {
		printf("=> ");
		scanf("%d", &ch);
		switch (ch) {
		case 1:
			printf("Enter the element of the stack: ");
			scanf("%d", &n);
			push(&a, n);
			break;
		case 2:
			pop(&a);
			break;
		case 3:
			if (a) {
				print_stack(a);
				printf("\n");
			}
			else
				printf("Stack is empty!\n");
			break;
		case 4:
			task(a);
			break;
		case 5:
			menu();
			break;
		}
	}
	return 0;
}
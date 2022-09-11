#include "stdio.h"
#include "stdlib.h"
#include "malloc.h"
#include "stdbool.h"

typedef struct tree {
	int key;
	struct tree *left;
	struct tree *right;
} node;

node *create_root(node *root, int key) {
	root = (node*)malloc(sizeof(node));
	root->key = key;
	root->left = root->right = NULL;
	return root;
}

node *add_node(node *root, int key) {
	if (root == 0) {
		return create_root(root, key);
	}
	if (root->key <= key) {
		if (root->right == 0) {
			root->right = create_root(root, key);
			return root;
		}
		add_node(root->right, key);

	}
	else 
		if (root->left == 0) {
			root->left = create_root(root, key);
			return root;
		}
		add_node(root->left, key);
	return root;
}

void print_tree(node *root) {
	static int l = 0;
	l++;
	if (root != NULL) {
		print_tree(root->right);
		for (int i = 0; i < l; i++)
			printf("    ");
		printf("-%d\n", root->key);
		print_tree(root->left);
	}
	l--;
}

void remove_node(node **root, int key) {
	node *repl = NULL,
		*parent = NULL,
		*tmp = *root; 

	while ((tmp != NULL) && (tmp->key != key)) {
		parent = tmp;

		if (key < tmp->key)
			tmp = tmp->left;
		else
			tmp = tmp->right;
	}

	if (tmp == NULL)
		return;

	if ((tmp->left != NULL) && (tmp->right == NULL)) {
		if (parent != NULL) {
			if (parent->left == tmp)
				parent->left = tmp->left;
			else
				parent->right = tmp->left;
		}
		else
			*root = tmp->left;
		free(tmp);
		tmp = NULL;
	}
	else if (tmp->left == NULL && tmp->right != NULL) {
		if (parent != NULL) {
			if (parent->left == tmp)
				parent->left = tmp->right;
			else
				parent->right = tmp->right;
		}
		else
			*root = tmp->right;
		free(tmp);
		tmp = NULL;
	}
	else if (tmp->left != NULL && tmp->right != NULL) {
		repl = tmp->right;
		if (repl->left == NULL)
			tmp->right = repl->right;
		else {
			while (repl->left != NULL) {
				parent = repl;
				repl = repl->left;
			}
			parent->left = repl->right;
		}
		tmp->key = repl->key;
		free(repl);
		repl = NULL;
	}
	else {
		if (parent != NULL) {
			if (parent->left == tmp)
				parent->left = NULL;
			else
				parent->right = NULL;
		}
		else
			*root = NULL;
		free(tmp);
		tmp = NULL;
	}
	return;
}

int task(node *root, int *k, int *depth, int min) {
	// if ((root->right != NULL) || (root->left != NULL)) {
	if (min > root->key) {
		min = root->key;
		*depth = *k;
		printf("%d\n", min);
		printf("%d\n", *k);
	}
	// }
	else
		return ;
	*k = *k + 1;
	if (root->left != NULL)
		task(root->left, k, depth, min);
	if (root->right != NULL)
		task(root->right, k, depth, min);
	return *depth;
}

void menu() {
	printf("===========================\n"
		"|| What you want to do?  ||\n"
		"||     1-add node        ||\n"
		"||     2-print tree      ||\n"
		"||     3-remove node     ||\n"
		"||     4-curry to task   ||\n"
		"||     5-menu            ||\n"
		"||     0-end             ||\n"
		"===========================\n");
}

int main() {
	node *a = NULL;
	int ch = 10, x = 0, k, depth, min;
	int key;
	printf("Enter the root of the tree\n");
	scanf("%d", &key);
	a = create_root(a, key);
	menu();
	while (ch != 0) {
		printf("-> ");
		scanf("%d", &ch);
		switch (ch) {
		case 1:
			printf("Enter the node of the tree: \n");
			printf("-> ");
			getchar();
			scanf("%d", &key);
			add_node(a, key);
			break;
		case 2:
			if (a)
				print_tree(a);
			else
				printf("Tree is empty! \n");
			break;
		case 3:
			printf("Enter the node of the tree: \n");
			printf("-> ");
		    getchar();
			scanf("%d", &key);
			remove_node(&a, key);
			break;
		case 4:
			k = 1;
			depth = 0;
			min = 100000;
			x = task(a, &k, &depth, min);
			printf("%d\n", x);
		case 5:
			menu();
			break;
		default:
			exit;
			break;
		}
	}
	return 0;
}

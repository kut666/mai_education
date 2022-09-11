#include <stdio.h>

#define M 120

int n, g[M][M], Res[M], N_res, Q[M], i_end;

void rec(int ii, int N) {
	int i, j;
	if (N > N_res) {
		for (i = 0; i < i_end; i++)
			Res[i] = Q[i];
		N_res = N;
	}
	if (ii == n)
		return;
	for (i = ii; i < n; i++) {
		for (j = 0; j < i_end; j++)
			if (g[Q[j]][i] == 0)
				break;
		if (j == i_end) {
			Q[i_end++] = i;
			rec(ii + 1, N + 1);
			i_end--;
		}
		rec(ii + 1, N);
	}
}

int main() {
	int i, k;
	char c;
	FILE *file = fopen("graph.txt", "r");
	fscanf(file, "%d" , &n);
	printf("Number of vertices: ");
		printf("%d \n", n);
		for (i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				fscanf(file, "%d", &g[i][j]);
			}
		}
	fclose(file);
	for (i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			if (g[i][j] == 1) g[j][i] = 1;
	printf("Adjacency matrix: \n");
	for (i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			printf(" %d", g[i][j]);
		printf("\n");
	}
	for (i = 0; i < n; i++) {
		i_end = 0;
		rec(i, 0);
	}
	printf("Maximal clique of a graph: ");
	for (i = 0; i < N_res; i++)
		printf("%d ", Res[i]);
	printf("\n");
	return 0;
}
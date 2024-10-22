#include <stdio.h>
#include <stdlib.h>

void feltolt(int n, int matrix[n][n]){
    for (int i=0; i<n; ++i){
        for (int j=0; j<n; ++j){
            matrix[i][j] = (i+1) * (j+1);
        }
    }
}

int main(){
    int n;
    scanf("%d", &n);
    int matrix[n][n];
    feltolt(n, matrix);
    for (int i=0; i<n; ++i){
        for (int j=0; j<n; ++j){
            printf("%d x %d = %d\n", i+1, j+1, matrix[i][j]);
        }
    }
    return 0;
}
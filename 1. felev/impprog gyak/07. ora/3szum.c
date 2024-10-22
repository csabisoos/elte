#include <stdio.h>

int szum(int n){
	int szum=0;
	for(int i = 1; i <= n; ++i)
		szum += i;
	return szum;
}

int main(){
	int n = 0;
	scanf("%d", &n);
	printf("%d\n", szum(n));
	return 0;
}

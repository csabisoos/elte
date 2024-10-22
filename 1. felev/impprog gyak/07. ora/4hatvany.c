#include <stdio.h>
#include <math.h>

int main(){
    int n;
    int szam;

    scanf("%d", &szam);
    scanf("%d", &n);
    for (int i=1; i<=n; ++i){
        int mo = pow(szam,i);
        printf("%d^%d = %d\n",szam,i,mo);
    }
    return 0;
}
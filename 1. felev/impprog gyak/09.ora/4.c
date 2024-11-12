#include <stdio.h>

int main(){

    char a[5] = "alma";
    char* b = a;

    a[0] = 'A';
    *(b+2) = 'R';

    printf("%s\n", a);
    printf("%s\n", b);

    return 0;
}
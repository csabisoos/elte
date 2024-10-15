#include <stdio.h>

int main()
{
    int n = 42;
    int* ptr = &n;
    *ptr = 66;
    printf("%d\n", n);
}
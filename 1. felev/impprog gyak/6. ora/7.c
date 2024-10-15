#include <stdio.h>

int*wat(void)
{
    int n = 5;
    int* a = &n;
    return a;
}

int main()
{
    int w = *wat();
    printf("%d\n", w);
    return 0;
}
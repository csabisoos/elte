#include <stdio.h>

int main()
{
    int n = 42;
    int m = 420;

    int* ptr = &n;
    int** ptrToPtr = &ptr;

    *ptrToPtr = &m;

    printf("%d\n", *ptr);

    int* otherPtr = &n;
    ptrToPtr = &otherPtr;
    printf("%d\n", **ptrToPtr);
    
    return 0;
}
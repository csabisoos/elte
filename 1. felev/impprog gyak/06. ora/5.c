#include <stdio.h>

int sum(int* begin, int* end)
{
    int sum = 0;

    for(int* i = begin;i<end/*+1*/;++i)
    {
        sum += *i;
    }
    return sum;
}
 
int main()
{
    int array[] = {1,2,3};
    printf("%d\n", sum(array, array+3));
    return 0;
}
#include <stdio.h>

int sum(int* p, int l)
{
    int szumma = 0;

    for(int i = 0;i<l;++i)
    {
        szumma += *(p+i);
    }
    return szumma;
}
 
int main()
{
    int array[3] = {1,2,3};
    printf("%d\n", sum(&array[0], 3));
    return 0;
}
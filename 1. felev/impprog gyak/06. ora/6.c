#include <stdio.h>

double atlag(int* begin, int* end)
{
    int sum = 0;    
    for(int* i = begin;i<end;++i)
        sum += *i;    
    return (double)sum/(end-begin);
}
 
int main()
{
    int array[] = {1,2,1};
    printf("%.2f\n", atlag(array, array+3));
    return 0;
}
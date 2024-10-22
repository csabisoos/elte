#include <stdio.h>
#include <limits.h>

unsigned strlen2(char* c)
{
    unsigned size = 0;
    while(*c != '\0')
    {
        ++size;
        ++c;
    }
    return size;
}

char toLower(char c)
{
    if(c >= 'A' && c <= 'Z')
        return c + 32;
    return c;
}


int main()
{
    int array[8]; // default init
    int b[8] = {};

    for (unsigned i = 0; i < 8; ++i)
        printf("%d\n", b[i]);

    
    int a[] = {1,2,3}; // list init

    //2
    int k[] = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    int sulysum[9] = {};
    int sum = 0;
    for (unsigned i = 0; i < 9; i++)
    {
        sum += k[i];
    }
    printf("%d\n", sum);

    //3
    int h[] = {123, 345, 201, 35, 23, 23, 5, 6,46};
    int max = h[0];
    for(int i = 0; i < 9; ++i)
    {
        if(h[i] > max)
        {
            max = h[i];
        }
    }
    printf("%d\n", max);

    //4
    int legkisebb = INT_MAX;
    int masodiklegkisebb = INT_MAX;
    for(unsigned i = 2; i < 9;++i)
    {
        if(masodiklegkisebb > h[i])
        {
            if(h[i] < legkisebb)
            {
                masodiklegkisebb = legkisebb;
                legkisebb = h[i];
            }
            else
            {
                masodiklegkisebb = h[i];
            }
        }
    }
    printf("%d\n", masodiklegkisebb);

    //5


    //7 & 8
    char* str1 = "yes";
    char* str2 = "no";

    unsigned str1Size = strlen2(str1);
    unsigned str2Size = strlen2(str2);
    //tests
    printf("%d, %d\n", strlen2(str1), strlen2(str2));
    printf("%c\n", toLower('A'));

    unsigned minLen = str1Size < str2Size ? str1Size : str2Size;

    for(unsigned i = 0; i < minLen; ++i)
    {
        char c1 = toLower(*(str1 + i));
        char c2 = toLower(*(str2 + i));
        if(c1 < c2)
        {
            printf("elso\n");
            break;
        }
        else if(c1 > c2)
        {
            printf("masodik\n");
            break;
        }
    }


    //8
}
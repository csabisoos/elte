#include <stdio.h>

int main()
{
    //1
    int n = 21;
    printf("%d\n", n);
    if (n % 2 == 0)
    {
        printf("paros\n");
    }
    else if (n % 3 == 0)
    {
        printf("3-al oszthato\n");
    }
    else
    {
        printf("egyik sem");
    }

    //2
    const int m;
    //m = 42; nem mukodik mert konstans
    printf("%d\n", m);

    //3
    int x;
    do
    {
        scanf("%d", &x);
    } while (x % 2 == 0);
    printf("%d paratlan", x);
    
    //4

    //5

    //6
    /*
    for (int i = 0; i < 10; i++)
    {
        printf("0.%d\n", i);
        if (i == 9)
        {
            printf("1\n");
        }        
    }
    */
    for (float i = 0; i < 1.1; i+=0.1)
    {
        printf("%.1f\n", i);
    }

    //7
    //char, unsined char
    //short, unsigned short
    //int, unsigned int
    //long, unsigned long
    //long long, unsigned long long
    printf("%d\n", sizeof(unsigned long long));

    
    #pragma region opcionalis
    //1
    int egy = scanf("%d", &egy);
    if (egy > 0)
    {
        printf("pozitiv\n");
    }
    else if (egy < 0)
    {
        printf("negativ\n");
    }
    else
    {
        printf("nulla\n");
    }
    
    //2
    for (float i = -20; i < 201; i+=10)
    {
        printf("%f %f", i, (i-32)/1.8);
    }
    

    //4
    //int szam = scanf("%d", &szam);
    

    #pragma endregion 



}

#include <stdio.h>
#include "my_utils.h"

void foo(void); //forward declaration

int n;

void foo(void)
{
    int f = 2;
    printf("%d\n", n);

    if(f==2)
    {
        f+=1;
        int g = 0;
    }
    else
    {
        f -=1;
        //g += 2;
    }
    //g++;

    {
        int a = 0;
    }

    {
        int a = 2;
    }

    //printf()
}
/*
void bar(int a, char a)
{
    printf("aaaaaa\n");
}
*/

#define answer 42

const static int answer2 = 42;

void statika(void)
{
    static int s = 0;

    ++s;
    printf("%d\n", s);
}

int main()
{
    printf("%d\n", n);
    fun();

    statika();
    statika();
    statika();
    /*
    printf("%d\n", answer);
    //printf("%d\n", answer);
    printf("%d\n", answer2);
    //printf("%d\n", answer2);
    */

    
}
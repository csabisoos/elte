#include <stdio.h>

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
/** /
void bar(int a, char a)
{
    printf("aaaaaa\n");
}
/**/
int main()
{
    printf("%d\n", n);
}
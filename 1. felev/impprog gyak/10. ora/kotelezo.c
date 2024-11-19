#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void egyes(void)
{
    char input[21];
    scanf("%s", input);

    unsigned size = strlen(input);
    char *dynamicStorage = malloc(size);
    // ha int lenne, akkor pl. kene a typus meret is
    // int *ds = malloc(size * sizeof(int));

    // dest, source, # of bytes
    memcpy(dynamicStorage, input, size);

    printf("%s, size: %u\n", dynamicStorage, size+1);
    free(dynamicStorage);
}

void kettes(void)
{
    char *szavak[5];

    for (int i = 0; i<5;++i)
    {
        char temp[100];
        scanf("%99s", temp);

        szavak[i] = (char*)malloc(strlen(temp)+1);
        strcpy(szavak[i], temp);
    } 
    printf("\nA szavak forditott sorrendben:\n");
    for (int i = 4; i >= 0; --i)
    {
        printf("%s\n", szavak[i]);
        free(szavak[i]);
    }
}

void harmas(void)
{
    int* dynamicMemoria = malloc(sizeof(int));
    int i=0,be;
    while(scanf("%d",(dynamicMemoria+i)))
    {
        //printf("\n");
        i++;
        dynamicMemoria = realloc(dynamicMemoria,i*sizeof(int));
    }   
    for(int j = i-1; j >= 0; --j)
    {
        printf("%d\n",dynamicMemoria[j]);
    }
}

void reverse4(char *str)
{
    int start = 0;
    int end = strlen(str)-1;

    while (start<end)
    {
        char temp = str[start];
        str[start] = str[end];
        str[end] = temp;

        ++start;
        --end;
    }
}

char* reverse5(const char *str)
{
    int len = strlen(str);

    char *reversed = (char *)malloc((len+1) * sizeof(char));

    for(int i = 0; i< len; ++i)
    {
        reversed[i] = str[len - i - 1];
    }

    reversed[len] = '\0';

    return reversed;
}

int main()
{
    harmas();

    char str4[] = "hello";
    printf("\nEredeti string: %s\n", str4);
    reverse4(str4);
    printf("Megforditott string: %s\n\n", str4);

    const char *str5 = "hello";
    printf("Eredeti string: %s\n", str5);
    char *reversed = reverse5(str5);
    printf("Megfordított string: %s\n\n", reversed);
    free(reversed);
    
    return 0;
    
}
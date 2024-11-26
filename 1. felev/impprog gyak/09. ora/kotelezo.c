#include <stdio.h>
#include <string.h>
#include <stdbool.h>

#define BUFFER 100

/*
int main() {
    char str[1000];
    int char_count = 0, word_count = 0;
    int in_word = 0;

    printf("Adja meg a szöveget: ");
    fgets(str, sizeof(str), stdin);

    for (int i = 0; str[i] != '\0'; i++) {
        if (isalpha(str[i]) || isdigit(str[i])) {
            ++char_count;  
            if (!in_word) {  
                word_count++;
                in_word = 1;  
            }
        } else {
            in_word = 0;  
        }
    }

    printf("A karakterek száma: %d\n", char_count);
    printf("A szavak száma: %d\n", word_count);

    return 0;
}
*/

bool isSpace(char c)
{
    return c == ' ' || c == '\t' || c == '\n';
}

void egyes(void)
{
    char buffer[BUFFER];
    fgets(buffer, BUFFER, stdin);

    unsigned numChars = 0;
    unsigned numWords = 0;
    unsigned index = 0;
    bool isSp = false;

    while (buffer[index] != '\0' && isSpace(buffer[index]))
    {
        ++numChars;
        ++index;
    }
    if (buffer[index] != '\0')
    {
        ++numWords;
    }
    while (buffer[index] != '\0')
    {
        ++numChars;
        if (isSp&& !isSpace(buffer[index]))
        {
            ++numWords;
        }
        isSp = isSpace(buffer[index]);
        ++index;
    }

    printf("numChars: %d, numWords: %d\n", numChars, numWords);
}

void kettes(void)
{
    char a[BUFFER];
    char b[BUFFER];

    scanf("%s", a);
    scanf("%s", b);

    printf("%d\n", strcmp(a, b));
}

void harmas(void)
{
    char a[BUFFER];
    char b[BUFFER];

    scanf("%s", a);

    strcpy(b, a);

    printf("%s\n", b);
}

void negyes(void)
{
    char a[5] = "alma";
    char* b = "alma";

    a[0] = 'A';
    //*(b+2) = 'R';

    printf("%s\n", a);
    printf("%s\n", b);

    char* c = a;
    *(c+2) = 'R';

    printf("%s\n", c);
}

char toUpper(char c)
{
    if (c >='a' && c <= 'z')
    {
        return c - 32;
    }
    return c;
}

void otos(void)
{
    char *fileName = "file";
    
    FILE *f = fopen(fileName, "r");

    char b[BUFFER];

    fgets(b, BUFFER, f);

    for (unsigned i = 0; i< BUFFER; ++i)
    {
        b[i] = toUpper(b[i]);
    }

    printf("%s\n", b);

    fclose(f);
}

void hatos(void)
{
    char* fileName = "file";

    FILE* f = fopen(fileName, "r");

    char b[BUFFER];
    fgets(b, BUFFER, f);

    fclose(f);

    for (unsigned i = 0; i < BUFFER; ++i)
    {
        b[i] = toUpper(b[i]);
    }

    FILE* out = fopen("output.txt", "w");
    fprintf(out, "%s\n", b);
    fclose(out);
}

int main()
{
    char code;
    do {
        printf("\n\n\n\n=====MENU=====");
        printf("\na. Elso");
        printf("\nb. Masodik");
        printf("\nc. Harmadik");
        printf("\nd. Negyedik");
        printf("\ne. Otodik");
        printf("\nf. Hatodik");
        printf("\n\nUsd be a kivant muvelet betujelent: \n");
        scanf("%c", &code);
        getchar();
        switch (code) {
            case 'a':
                egyes();
                break;
            case 'b':
                kettes();
                break;
            case 'c':
                harmas();
                break;
            case 'd':
                negyes();
                break;
            case 'e':
                otos();
                break;
            case 'f':
                hatos();
                break;
        }
    } while (code != 'x');
}
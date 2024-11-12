#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <stdbool.h>

#define BUFFER 100

bool isSpace(char c){
    return c == ' ' || c == '\t' || c == '\n';
}

void t1(void){
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
        ++numWords;
    while(buffer[index] != '\0')
    {
        ++numChars;
        if(isSp && !isSpace(buffer[index]))
            ++numWords;
        isSp = isSpace(buffer[index]);
        ++index;
    }
    printf("numChars: %d, numWords: %d\n", numChars, numWords);
}

void t2(){
    char a[BUFFER];
    char b[BUFFER];

    scanf("%s", a);
    scanf("%s", b);

    printf("%d\n", strcmp (a,b));
}

void c(){
    printf("Az harmadik programot valasztottad");
}

int main(){
    char code;
    do {
        printf("\n\n\n\n=====MENU=====");
        printf("\na. Elso");
        printf("\nb. Masodik");
        printf("\nc. Harmadik");
        printf("\nd. Exit");
        printf("\n\nUsd be a kivant muvelet betujelet: \n");
        scanf("%c", &code);
        switch (code) {
            case 'a':
                t1();
                break;
            case 'b':
                t2();
                break;
            case 'c':
                c();
                break;
        }
    } while (code != 'd');
    return 0;
}
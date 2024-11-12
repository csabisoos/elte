#include <stdio.h>

#define BUFFER 100

int main(){

    char* filename = "file";

    FILE* f = fopen(filename, "rw");

    char b[BUFFER];
    fgets(b, BUFFER, f);

    printf("%s\n", b);

    fclose(f);

    return 0;
}
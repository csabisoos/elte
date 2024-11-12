#include <stdio.h>
#include <string.h>

#define BUFFER 100

int main(){
    /** /
    char s[4] = "alma";
    char m[4] = "alma";
    if(strcmp(s, m) == 0) {
        printf("A két szöveg megegyezik.\n");
    } else {
        printf("A két szöveg különbözik.\n");
    }
    return 0;
    */

    char a[BUFFER];
    char b[BUFFER];

    scanf("%s", a);
    scanf("%s", b);

    printf("%d\n", strcmp (a,b));
}
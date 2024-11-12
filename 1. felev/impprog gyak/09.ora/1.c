/** /
#include <stdio.h>
#include <ctype.h>

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

#include <stdio.h>
#include <string.h>
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

int main(){
    t1();
    return 0;
}
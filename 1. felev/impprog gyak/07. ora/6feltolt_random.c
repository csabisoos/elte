#include <stdio.h>

int counter(float* begin, float* end){
    int counter = 0;
    for(;begin != end; ++begin){
        *begin = (float)rand() / (float)(RAND_MAX / 100);
        if(*begin > 50)
            ++counter;
    }
    return counter;
}

int main(){
    srand(time(NULL));
    float a[30];
    printf("%d\n", counter(a,a+30));
    return 0;
}
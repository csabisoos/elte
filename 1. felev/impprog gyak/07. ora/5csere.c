#include <stdio.h>
#include <math.h>

int main(){
    int num, first, last, digits, swapped, mult;
    scanf("%d", &num);
    last = num%10;
    digits = (int)log10(num);
    first = num/pow(10,digits);

    if(digits < 2){
        printf("At least 3 digits.\n");
        return 1;
    }
    mult = pow(10,digits);
    swapped = last * mult;
    swapped += (num%mult)-last;
    swapped += first;

    printf("%d - %d\n", num, swapped);

    return 0;
}
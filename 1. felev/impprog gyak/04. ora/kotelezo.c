#include <stdio.h>
#include <ctype.h>
#include <math.h>

#define PI 3.14159265358979323846

void otos(void)
{
    unsigned date;
    scanf("%d", &date);
    // YYYYMMDD
    unsigned days = date % 100;
    unsigned months = (date % 10000 - days) / 100;
    unsigned years = (date - days - months) /10000;

    printf("%d-%d-%d\n", days, months, years);
}

struct Point
{
    double x;
    double y;
};

struct Vector
{
	struct Point p1;
	struct Point p2;	
};


void hatos(struct Vector a, struct Vector b)
{
	double x1 = a.p2.x - a.p1.x;
	double x2 = b.p2.x - b.p1.x;
	double y1 = a.p2.y - a.p1.y;
	double y2 = b.p2.y - b.p1.y;
	if (x1 * x2 - y1 * y2 == 0)
		printf("meroleges\n");
	else
		printf("nem meroleges\n");

}

void hetes(int* a, int* b)
{
	*a = *a + *b;
	*b = *a - *b;
	*a = *a - *b;
}

int main(){

    #pragma region 2
    char input;
    while (1)
    {
        input = getchar();
        
        if (input == '0')        
            break;        
        
        
        if (isalpha(input) != 0)        
        {
            if (islower(input))            
                input = toupper(input);
            else if (isupper(input))            
                input = tolower(input);

            putchar(input);
        }
        else if (isalpha(input) == 0)
            printf("Hibas bemenet!\n");               
    }
    #pragma endregion

    #pragma region 3
    double x,y;
    scanf("%lf", &x);
    scanf("%lf", &y);
    printf("A ket szam osszege: %.2lf\n", x+y);
    printf("A ket szam elterese: %.2lf\n", x-y);
    printf("A ket szam szorzata: %.2lf\n", x*y);
    if (y != 0)
    {
        printf("A ket szam hanyadosa: %.2lf\n", x/y);
        //printf("A ket szam hanyadosa: %.2lf\n", x%y);
    }
    else
    {
        printf("Az oszto 0, azaz nem lehet az osztast vegrehajtani.");
    }
    printf("A ket szam negalasa: ");
    printf("%.2lf ", -x);
    printf("%.2lf\n", -y);
    #pragma endregion
    
    #pragma region 4
    int r = 0;
    scanf("%d", &r);
    printf("Egy %d sugaru kor atmeroje: %d, kerulete: %lf, terulete: %lf\n", r, 2*r, 2*r*PI, r*r*PI);
    #pragma endregion
        
	//otos
    otos();

    //hatos
	struct Vector a;
	a.p1.x = 0;
	a.p1.y = 1;
	a.p2.x = 1;
	a.p2.y = 1;
	struct Vector b = {{0, 1}, {1, 1}};

	hatos(a, b);
	
	//hetes
	int n = 2;
	int m = 3;
	hetes(&n, &m);
	printf("%d, %d\n", n, m); // 3, 2

    return 0;
}
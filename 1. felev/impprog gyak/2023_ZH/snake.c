#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SOROK 10
#define OSZLOPOK 20
#define KIGYOHOSSZ 9

void init_field(char jatekter[SOROK][OSZLOPOK], int almak)
{
    for (int i=0; i<SOROK; ++i)
    {
        for (int j=0; j<OSZLOPOK; ++j)
        {
            jatekter[i][j] = ' ';
        }
    }
    srand(time(NULL));
    int letett_almak=0;
    while (letett_almak < almak)
    {
        int x=rand()%SOROK;
        int y=rand()%OSZLOPOK;
        if (jatekter[x][y] == ' ')
        {
            jatekter[x][y] = 'a';
            ++letett_almak;
        }
    }
}

void init_snake(int kigyo[KIGYOHOSSZ][2])
{
    for (int i=0; i<KIGYOHOSSZ; ++i)
    {
        kigyo[i][0]=0;
        kigyo[i][1]=i;
    }
}

void print_game(char jatekter[SOROK][OSZLOPOK], int kigyo[KIGYOHOSSZ][2])
{
    char munka[SOROK][OSZLOPOK];
    for (int i=0; i<SOROK; ++i)
    {
        for (int j=0; j<OSZLOPOK; ++j)
        {
            munka[i][j] = jatekter[i][j];
        }
    }
    munka[kigyo[0][0]][kigyo[0][1]] = '8';
    for (int i=1; i<KIGYOHOSSZ; ++i)
    {
        munka[kigyo[i][0]][kigyo[i][1]] = '0';
    }
    printf("\n");
    for (int i=-1; i<=SOROK; ++i)
    {
        for (int j=-1; j<= OSZLOPOK; ++j)
        {
            if (i==-1 || i==SOROK || j==-1 || j==OSZLOPOK)
            {
                printf("#");
            } else 
            {
                printf("%c", munka[i][j]);
            }
        }
        printf("\n");
    }
}

int update_snake(char jatekter[SOROK][OSZLOPOK], int kigyo[KIGYOHOSSZ][2], char irany)
{
    int ujfej_x = kigyo[0][0];
    int ujfej_y = kigyo[0][1];
    if (irany=='w')
    {
        --ujfej_x;
    } else if (irany=='s')
    {
        ++ujfej_x;
    } else if (irany=='a')
    {
        --ujfej_y;
    } else if (irany=='d')
    {
        ++ujfej_y;
    } else
    {
        return -1;
    }
    if (ujfej_x<0 || ujfej_x>=SOROK || ujfej_y<0 || ujfej_y>=OSZLOPOK)
    {
        return -1;
    }
    for (int i=0; i<KIGYOHOSSZ; ++i)
    {
        if (ujfej_x==kigyo[i][0] && ujfej_y==kigyo[i][1])
        {
            return -2;
        }
    }
    int begyujtott=0;
    if (jatekter[ujfej_x][ujfej_y]=='a')
    {
        ++begyujtott;
        jatekter[ujfej_x][ujfej_y]=' ';
    }
    for (int i=KIGYOHOSSZ-1; i>0; --i)
    {
        kigyo[i][0]=kigyo[i-1][0];
        kigyo[i][1]=kigyo[i-1][1];
    }
    kigyo[0][0]=ujfej_x;
    kigyo[0][1]=ujfej_y;
    return begyujtott;
}

int main(void)
{
    printf("Üdvözöllek a Snake játékban!\n");
    printf("A célod, hogy összegyűjtsd az összes almát, miközben nem ütközöl a pálya szélével vagy önmagaddal.\n");
    printf("A kígyót az 'w', 'a', 's', 'd' billentyűkkel irányíthatod.\n");
    printf("A játékból kiléphetsz az EOF (Ctrl+D) megadásával.\n\n");

    char jatekter[SOROK][OSZLOPOK];
    int almak = 10;
    init_field(jatekter, almak);

    int kigyo[KIGYOHOSSZ][2];
    init_snake(kigyo);

    print_game(jatekter, kigyo);

    //char irany;
    while (almak > 0)
    {
        printf("Adj meg egy irányt (w/a/s/d): ");
        char irany = getchar();
        //printf("\n");
        if (irany==EOF)
        {
            printf("\nKiléptél a játékból.\n");
            break;
        }
        if (irany == '\n') continue; // Newline figyelmen kívül hagyása
        
        if (irany != 'w' && irany != 'a' && irany != 's' && irany != 'd') {
            printf("Érvénytelen irány: '%c'\n", irany);
            continue;
        }
        int eredmeny = update_snake(jatekter, kigyo, irany);
        if (eredmeny == -1)
        {
            printf("\nÜtköztél a pálya szélével! Játék vége.\n");
            break;
        } else if (eredmeny == -2)
        {
            printf("\nÜtköztél a kígyó testével! Játék vége.\n");
            break;
        } else if (eredmeny == 1)
        {
            printf("\nAlmát gyűjtöttél be!\n");
            --almak;
        }
        print_game(jatekter, kigyo);
    }

    if (almak == 0) 
    {
        printf("\nGratulálok! Sikerült összegyűjtened az összes almát!\n");
    }

    return 0;
}


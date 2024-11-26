#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define STUD_CNT 42

struct Student
{
    int ID;
    double Avg;
    short Age;
};

typedef struct Student Student;
//      *************  *******
//          létező        új

Student* student_init(void)
{
    int id = rand();
    double avg = (4.0 / RAND_MAX) * rand() + 1;
    short age = rand() % 131 + 10;

    /* Student s = {id, avg, age}; */

    Student* s = /*(Student*)*/malloc(sizeof(Student));
    s -> ID = id;
    /* (*s).ID = id; */ //ugyan az
    s -> Avg = avg;
    s -> Age = age;

    return s;
}

void student_print(Student* s)
{
    printf("Id: %d, Avg: %lf, Age: %d\n", s->ID, s-> Avg, s -> Age );
}

Student* student_search(Student* studentArray, size_t size)
{
    size_t max = 0;
    Student* best = NULL;

    if (NULL == studentArray)
    {
        printf("hibas bemenet\n");
        return NULL;
    }

    for (size_t i=0; i<size; ++i)
    {
        if (studentArray[i].Avg > max)
        {
            max = studentArray[i].Avg;
            best = &studentArray[i];
        }
    }

    return best;
}

enum Type
{
    Bsc, // 0
    Msc, // 1
    PhD  // 2
    // mindig egyel tobb lesz az erteke mint az elozonek
    /* Bsc,
    Msc = 100,
    Phd = 99,
    FOSZK */ // FOSZK == Msc
};

typedef enum Type Type;

struct Impact
{
    double factor;
    int erdos;
};

union Data
{
    int kurzusok;
    double okki;
    struct Impact impakt;
};

typedef union Data Data;

struct AdvStudent
{
    Type kepzes;
    int ID;
    double Avg;
    short Age;
    Data data;
};

typedef struct AdvStudent AdvStudent;

int main(){

    /* I. */

    /* 1. */

    srand(time(NULL));
    int ids1[STUD_CNT];
    int avgs1[STUD_CNT];

    for (unsigned i=0; i<STUD_CNT;++i)
    {
        ids1[i] = rand();
        avgs1[i] = (4.0 / RAND_MAX) * rand() + 1;
    }

    /* 2. */

    short ages[STUD_CNT];
    for (unsigned i=0; i< STUD_CNT; ++i)
    {
        ages[i] = (short)(rand() % 130 + 1);
    }

    /* 3. */
    /* int studentID = 13; */


    /* II. */
    Student* s = student_init();
    student_print(s);

    Student students[5] = {*student_init(), *student_init(), *student_init(), *student_init(), *student_init()};

    student_print(student_search(students, 5));

    printf("size: int:%lu, double:%ld, short: %ld, Student: %ld\n", sizeof(int), sizeof(double), sizeof(short), sizeof(Student));
    // padding, alignment
    // bitszam alapjan valtozik
    //   _________
    //  | Student |
    //  |   ID    |  -- 4
    //  |         |  -- 4 (padding)
    //  |   Avg   |  -- 8 
    //  |   Age   |  -- 2
    //  |         |  -- 6 (padding)
    //   _________
    //  size: int:4, double:8, short: 2, Student: 24
    // 
    //   _________
    //  | Student |
    //  |   Avg   |  -- 8
    //  |   ID    |  -- 4 
    //  |   Age   |  -- 2 
    //  |         |  -- 2 (padding)
    //   _________
    //  size: double: 8, int: 4, short: 2, Student: 16
    // a masodik jobb megoldas!

    /* III. */

    /* printf("%d\n", Msc); */
    /* Type kepzes = Bsc;
    printf("%d\n", kepzes); */

    printf("%ld\n", sizeof(Data));
    // a union mindig azt a nagysagot veszi fel amely memoriameretbe
    // barmely eleme belefer, esetunkben: 16 (struct Impact impakt)
    // maximum kereses

    AdvStudent as = {Bsc, 22, 3.5, 21, 6};

    printf("%d\n", as.data.kurzusok);
    printf("%lf\n", as.data.okki);
    // "tobb tipusu valtozo"
    // mindig csak egy erteket tarol egy adott adattipusaban (valtozojaban)
    //   _________
    //  |   Data   |
    //  | kurzusok |  -- 4  -- |
    //  |   okki   |  -- 8  -- } 16 (maximum kivalasztas)
    //  |  impakt  |  -- 16 -- |
    //   _________

    return 0;
}
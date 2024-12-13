#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

#define RESET       "\033[0m" 
#define BG_BLACK    "\033[40m" 
#define BG_RED      "\033[41m" 
#define BG_GREEN    "\033[42m" 
#define BG_YELLOW   "\033[43m" 
#define BG_BLUE     "\033[44m" 
#define BG_MAGENTA  "\033[45m" 
#define BG_CYAN     "\033[46m" 
#define BG_WHITE    "\033[47m"

#define meret 30

#define TERMINAL_CLEAR  "\033[2J" 
#define TERMINAL_HOME   "\033[2H"

#define GIF_FRAME_COUNT 10

#pragma region Szinek a konzolon
enum color {BLACK, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE};

typedef enum color color;

void color_print(color c) {
    switch (c) {
        case BLACK:
            printf("%s ", BG_BLACK);
            break;
        case RED:
            printf("%s ", BG_RED);
            break;
        case GREEN:
            printf("%s ", BG_GREEN);
            break;
        case YELLOW:
            printf("%s ", BG_YELLOW);
            break;
        case BLUE:
            printf("%s ", BG_BLUE);
            break;
        case MAGENTA:
            printf("%s ", BG_MAGENTA);
            break;
        case CYAN:
            printf("%s ", BG_CYAN);
            break;
        case WHITE:
            printf("%s ", BG_WHITE);
            break;
    }
    printf("%s", RESET);
}
#pragma endregion

#pragma region Kepek fajlbol
struct image {color** matrix; int width; int height;};

typedef struct image image;

image read_image(char *filename)
{
    FILE *file = fopen(filename, "r");
    image kep;
    fscanf(file, "%d %d", &kep.width, &kep.height);

    if (kep.width > meret || kep.height > meret)
    {
        printf("Tul nagy a meret!");
        fclose(file);
        exit(1);
    }

    kep.matrix = (color**)malloc(kep.height * sizeof(color*));
    for (int i = 0;i<kep.height;++i)
    {
        kep.matrix[i] = (color *)malloc(kep.width * sizeof(color));
    }

    for (int i = 0;i<kep.height;++i)
    {
        for (int j = 0;j<kep.width;++j)
        {
            int c;
            fscanf(file, "%d", &c);
            kep.matrix[i][j] = /* (color) */c;
        }
    }

    fclose(file);
    return kep;
}

void image_print(image img)
{
    for (int i = 0; i<img.height;++i)
    {
        for (int j = 0;j<img.width;++j)
        {
            color_print(img.matrix[i][j]);
        }
        printf("\n");
    }
}

void free_img(image img)
{
    for (int i = 0;i<img.height;++i){
        free(img.matrix[i]);
    }
    free(img.matrix);
}
#pragma endregion

#pragma region Gif fajlbol
typedef struct {image frames[GIF_FRAME_COUNT];} gif;

gif load_gif(char* base_filename) {
    gif g;
    for (int i = 0; i < GIF_FRAME_COUNT; ++i) {
        char file_name[50];
        snprintf(file_name, sizeof(file_name), "%s.bg%d", base_filename, i);

        g.frames[i] = read_image(file_name);
    }
    return g;
}

void print_gif(gif g) {
    for (int i = 0; i < GIF_FRAME_COUNT; ++i) {
        printf(TERMINAL_CLEAR);
        printf(TERMINAL_HOME);
        image_print(g.frames[i]);
        usleep(200000);
    }
}

void free_gif(gif g) {
    for (int i = 0; i < GIF_FRAME_COUNT; ++i) {
        free_img(g.frames[i]);
    }
}
#pragma endregion

int main(void)
{
    color_print(YELLOW);
    printf("\n");


    image kep = read_image("input.txt");
    image_print(kep);
    free_img(kep);


    char base_filename[50];
    printf("Add meg a fajl nevet (pl. 'input'): ");
    scanf("%s", base_filename);

    gif g = load_gif(base_filename);
    print_gif(g); 
    free_gif(g); 

    return 0;
}

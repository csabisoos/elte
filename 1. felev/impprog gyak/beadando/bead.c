#include <stdio.h>
#include <stdlib.h>

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

typedef enum {BLACK, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE} color;

void color_print(color c) {
    switch (c) {
        case BLACK:
            printf("%s \n", BG_BLACK);
            break;
        case RED:
            printf("%s \n", BG_RED);
            break;
        case GREEN:
            printf("%s \n", BG_GREEN);
            break;
        case YELLOW:
            printf("%s \n", BG_YELLOW);
            break;
        case BLUE:
            printf("%s \n", BG_BLUE);
            break;
        case MAGENTA:
            printf("%s \n", BG_MAGENTA);
            break;
        case CYAN:
            printf("%s \n", BG_CYAN);
            break;
        case WHITE:
            printf("%s \n", BG_WHITE);
            break;
        default:
            break;
    }
    printf("%s", RESET); // Visszaállítjuk az alapértelmezett színt
}

typedef struct {color** matrix; int width; int height;} image;

image create_image(int width, int height) {
    image img;
    img.width = width;
    img.height = height;

    img.matrix = (color**)malloc(height * sizeof(color*));
    for (int i = 0; i < height; ++i) {
        img.matrix[i] = (color*)malloc(width * sizeof(color));
    }

    return img;
}

int main()
{
    color_print(YELLOW);

    return 0;
}
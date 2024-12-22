#include <stdio.h>
#include <stdlib.h>
#include <termios.h>
#include <unistd.h>
#include <fcntl.h>
#include <time.h>

#define WIDTH 20
#define HEIGHT 10
#define SNAKE_LENGTH 9
#define APPLE 'a'
#define EMPTY ' '
#define SNAKE_HEAD '8'
#define SNAKE_BODY '0'
#define WALL '#'

// Játéktér inicializálása
void init_field(char field[HEIGHT][WIDTH], int apple_count) {
    for (int i = 0; i < HEIGHT; i++)
        for (int j = 0; j < WIDTH; j++)
            field[i][j] = EMPTY;

    srand(time(NULL));
    while (apple_count > 0) {
        int x = rand() % HEIGHT;
        int y = rand() % WIDTH;
        if (field[x][y] == EMPTY) {
            field[x][y] = APPLE;
            apple_count--;
        }
    }
}

// Kígyó inicializálása
void init_snake(int snake[SNAKE_LENGTH][2]) {
    for (int i = 0; i < SNAKE_LENGTH; i++) {
        snake[i][0] = 0;
        snake[i][1] = i;
    }
}

// Játék állapotának kirajzolása
void print_game(char field[HEIGHT][WIDTH], int snake[SNAKE_LENGTH][2]) {
    char work_field[HEIGHT][WIDTH];
    for (int i = 0; i < HEIGHT; i++)
        for (int j = 0; j < WIDTH; j++)
            work_field[i][j] = field[i][j];

    work_field[snake[0][0]][snake[0][1]] = SNAKE_HEAD;
    for (int i = 1; i < SNAKE_LENGTH; i++)
        work_field[snake[i][0]][snake[i][1]] = SNAKE_BODY;

    for (int i = 0; i < WIDTH + 2; i++) printf("%c", WALL);
    printf("\n");
    for (int i = 0; i < HEIGHT; i++) {
        printf("%c", WALL);
        for (int j = 0; j < WIDTH; j++)
            printf("%c", work_field[i][j]);
        printf("%c\n", WALL);
    }
    for (int i = 0; i < WIDTH + 2; i++) printf("%c", WALL);
    printf("\n");
}

// Kígyó frissítése
int update_snake(char field[HEIGHT][WIDTH], int snake[SNAKE_LENGTH][2], char direction) {
    printf("Snake head: (%d, %d), Direction: %c\n", snake[0][0], snake[0][1], direction);

    int dx = 0, dy = 0;
    if (direction == 'w') dx = -1;
    if (direction == 's') dx = 1;
    if (direction == 'a') dy = -1;
    if (direction == 'd') dy = 1;

    int new_head_x = snake[0][0] + dx;
    int new_head_y = snake[0][1] + dy;

    // Ellenőrizzük, hogy az új fejpozíció érvényes-e
    if (new_head_x < 0 || new_head_x >= HEIGHT || new_head_y < 0 || new_head_y >= WIDTH)
        return -1; // Pálya szélével ütközés

    for (int i = 1; i < SNAKE_LENGTH; i++) { // Fejet külön kezeljük
        if (snake[i][0] == new_head_x && snake[i][1] == new_head_y)
            return -2; // Önmagával ütközés
    }

    int apple_eaten = field[new_head_x][new_head_y] == APPLE;
    if (apple_eaten)
        field[new_head_x][new_head_y] = EMPTY;

    // Frissítjük a kígyó testét
    for (int i = SNAKE_LENGTH - 1; i > 0; i--) {
        snake[i][0] = snake[i - 1][0];
        snake[i][1] = snake[i - 1][1];
    }
    snake[0][0] = new_head_x;
    snake[0][1] = new_head_y;

    return apple_eaten;
}

// Billentyűzet érzékelése
int kbhit() {
    struct termios oldt, newt;
    int ch;
    int oldf;

    tcgetattr(STDIN_FILENO, &oldt);
    newt = oldt;
    newt.c_lflag &= ~(ICANON | ECHO);
    tcsetattr(STDIN_FILENO, TCSANOW, &newt);
    oldf = fcntl(STDIN_FILENO, F_GETFL, 0);
    fcntl(STDIN_FILENO, F_SETFL, oldf | O_NONBLOCK);

    ch = getchar();

    tcsetattr(STDIN_FILENO, TCSANOW, &oldt);
    fcntl(STDIN_FILENO, F_SETFL, oldf);

    if (ch != EOF) {
        ungetc(ch, stdin);
        return 1;
    }

    return 0;
}

// Főprogram
int main() {
    char field[HEIGHT][WIDTH];
    int snake[SNAKE_LENGTH][2];
    char direction = 's';
    int apples = 10;

    init_field(field, apples);
    init_snake(snake);
    print_game(field, snake);

    printf("Snake játék! Irányítás: w, a, s, d. Kilépés: Ctrl+C\n");

    while (1) {
       if (kbhit()) {
           char input = getchar();
           if (input == 'w' || input == 'a' || input == 's' || input == 'd')
               direction = input;
       }

       int result = update_snake(field, snake, direction);
       if (result == -1) {
           printf("A kígyó kilépett a pályáról!\n");
           break;
       }
       if (result == -2) {
           printf("A kígyó összeütközött önmagával!\n");
           break;
       }
       if (result == 1) {
           apples--;
           if (apples == 0) {
               printf("Gratulálok! Minden almát begyűjtöttél!\n");
               break;
           }
       }

       print_game(field, snake);
       usleep(300000); // Lassítás, hogy a játék játszható legyen
    }   

    return 0;
}
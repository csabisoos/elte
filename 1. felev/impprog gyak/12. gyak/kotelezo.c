#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

struct Box
{
    double weight;
    struct Box* next;
};

typedef struct Box Box;

static Box* top;

void initialize(void)
{
    top = NULL;
}

bool is_empty(void)
{
    return (top == NULL);
}

bool is_empty_param(Box* elem)
{
    return elem == NULL;
}

double peek(void)
{
    if (is_empty())
    {
        printf("stack is empty!\n");
        return -1;
    }
    return top -> weight; 
}

void push(int weight)
{
    Box *new = malloc(sizeof(struct Box));
    new->weight=weight;
    new->next=top;
    top=new;
}

void clear(Box* elem)
{
    if (is_empty_param(elem->next))
        free(elem);
    else 
    {
        clear(elem->next);
        free(elem);
    }
}

void pop(void)
{
    if (is_empty())
        return;

    Box* next = top->next;
    free(top);
    top = next;
}

void copy_top(void)
{
    push(top->weight);
}

int main()
{
    initialize();
    push(23);
    printf("%f\n", peek());
    push(32);
    printf("%f\n", peek());
    copy_top();
    printf("%f\n", peek());
    pop();
    printf("%f\n", peek());
    pop();
    printf("%f\n", peek());
    
    
    clear(top);
    printf("%f\n", top->weight); // felszaabditotta-e
    return 0;
}
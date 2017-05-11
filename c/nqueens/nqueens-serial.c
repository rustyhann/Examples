//# 601 west second street, 2nd floor, elevator B, two rights

#include <stdio.h>
#include <stdlib.h>
#include <omp.h>
#include <math.h>

int calc_row(int n, int index){
    return floor(index / n);
}

int calc_col(int n, int index){
    return index % n;
}

int calc_index(int n, int row, int col) {
    return row * n + col;
}

void remove_rows(int n, int index, char *board){
    int row = calc_row(n, index);
    int col_start = calc_index(n, row, 0);
    int col_end = calc_index(n, row, n);

    for(int i = col_start; i < col_end; i++) {
        if (board[i] != 'q') {
            board[i] = '*';
        }
    }
}

void remove_cols(int n, int index, char *board){
    int col = calc_col(n, index);
    int row_start = calc_index(n, 0, col);
    int row_end = calc_index(n, n, col);

    for(int i = row_start; i < row_end; i += n){
        if (board[i] != 'q') {
            board[i] = '*';
        }
    }
}

void remove_diagonals(int n, int index, char *board){
    int row;
    int col_start;
    int diag;

    // Down and Right
    row = calc_row(n, index);
    col_start = calc_col(n, index) + 1;
    for (int col = col_start; col < n; col++){
        if (row + 1 < n){
            row += 1;
            diag = calc_index(n, row, col);
            if (board[diag] != 'q'){
                board[diag] = '*';
            }
        }
    }

    // Down and Left
    row = calc_row(n, index);
    col_start = calc_col(n, index) - 1;
    for (int col = col_start; col > -1; col--){
        if (row + 1 < n){
            row += 1;
            diag = calc_index(n, row, col);
            if (board[diag] != 'q'){
                board[diag] = '*';
            }
        }
    }

    // Up and Right
    row = calc_row(n, index);
    col_start = calc_col(n, index) + 1;
    for (int col = col_start; col < n; col++){
        if (row - 1 >= 0){
            row -= 1;
            diag = calc_index(n, row, col);
            if (board[diag] != 'q'){
                board[diag] = '*';
            }
        }
    }

    // Up and Left
    row = calc_row(n, index);
    col_start = calc_col(n, index) - 1;
    for (int col = col_start; col > -1; col--){
        if (row - 1 >= 0){
            row -= 1;
            diag = calc_index(n, row, col);
            if (board[diag] != 'q'){
                board[diag] = '*';
            }
        }
    }
}

void place_piece(int n, int index, char *board){
    board[index] = 'q';
    remove_rows(n, index, board);
    remove_cols(n, index, board);
    remove_diagonals(n, index, board);
}

int remaining_moves(int n, char *board){
    int moves = 0;
    for (int i = 0; i < n*n; i++) {
        if (board[i] == '_'){
            moves += 1;
        }
    }
    return moves;
}

void new_solution(int n, char *board, int s_top, char **solutions){
    for (int i = 0; i < n*n; i++) {
        solutions[s_top][i] = board[i];
    }
}

int validate_board(int n, char *board, int s_top, char **solutions){
    int solution = 0;
    int queens = 0;

    for (int i = 0; i < n*n; i++) {
        if (board[i] == 'q') {
            queens += 1;
        }
    }

    if (queens == n) {
        return 1;
    }
    else {
        return 0;
    }
}

void new_board(int n, int *top, char *board, char **stack){

    // Copy the highest board in the stack to the board array. Top is
    // the next board array to be written to the stack, meaning it
    // hasn't been written yet. We need to decrement it by one to get
    // the last board written.

    *top -= 1;

    // We also have to make sure we haven't reached the last board in
    // the stack. The stack is zero based so we have to make sure top
    // is greater than -1 because -1 indicates the stack is empty.

    if (*top > -1) {
        for (int i = 0; i < n*n; i++) {
            board[i] = stack[*top][i];
        }
    }
}

void backtrack(
    int n, int index, char *board, int *top, int *max, char **stack
){
    // if only one move is left, backtracking is not needed
    if (remaining_moves(n, board) > 1) {

        // set the place holder for the current move
        board[index] = '*';

        // realloc stack if it needs to grow
        if (*top >= *max){
            *max = *max + floor(*max / 2);
            stack = realloc(stack, (*max)*sizeof(char*));
            for (int i = *top; i < (*max); i++) {
                stack[i] = malloc((n*n)*sizeof(char));
            }
        }

        // copy the backtracking array to stack
        for (int i = 0; i < n*n; i++) {
            stack[*top][i] = board[i];
        }

        // move to the next item in the stack
        *top += 1;
    }
}

void print_board(int n, char *board){
    for (int r = 0; r < n; r++) {
        for (int c = 0; c < n; c++) {
            printf("%c ", board[r*n+c]);
        }
        printf("\n");
    }
    printf("\n");
}

int main() {

    printf("\033[H\033[J");

    // The size of the board, make this an argument
    int n = 10;

    int max = n*n;              // Max boards that can be in stack
    int top = 0;                // Highest board in the stack
    int s_max = n;              // Max solutions
    int s_top = 0;              // Current solution
    int index = 0;              // Iterator for tracking moves
    int sols = 0;               // Total number of solutions found
    char successful_move = 'f'; // Determines if a piece has been placed

    //printf("Threads: %d\n", omp_get_num_threads());

    // Create a 2D array that will hold N*N board arrays
    char **stack = (char**) malloc(n*n*sizeof(char*));
    for (int i = 0; i < n*n; i++) {
        stack[i] = (char*) malloc((n*n)*sizeof(char));
    }

    // create a new array to hold a copy of the current board

    char *board = (char*) malloc((n*n)*sizeof(char));
    for (int i = 0; i < n*n; i++) {
        board[i] = '_';
    }

    // Create a 2D array that will hold n solutions.

    char **solutions = (char**) malloc(n*sizeof(char*));
    for (int i = 0; i < n; i++) {
        solutions[i] = (char*) malloc((n*n)*sizeof(char));
    }

    // Work through the stack until it is empty

    while (top > -1) {

        // If the board is full, check to see if it is a solution. If it is not
        // a solution, discard it and pull the next board from the stack

        if (remaining_moves(n, board) == 0){

            if (validate_board(n, board, s_top, solutions) == 1){
                sols += 1;
                // realloc solutions if it needs to grow
                if (s_top >= s_max){
                    s_max = s_max + floor(s_max / 2);
                    solutions = realloc(solutions, (s_max)*sizeof(char*));
                    for (int i = s_top; i < (s_max); i++) {
                        solutions[i] = malloc((n*n)*sizeof(char));
                    }
                }
                new_solution(n, board, s_top, solutions);
                // move to the next item in the solutions
                s_top += 1;
            }
            new_board(n, &top, board, stack);
        }

        // make a move on the new board this cannot be ran as a parallel loop
        // because each thread would make a move, resulting in multiple moves
        // instead of one move. This isn't much of a performance hit because it
        // will only loop 63 times at a maximum and will most likely exit the
        // loop much earlier

        index = 0;
        successful_move = 'f';
        while (index < n*n && successful_move == 'f') {
            if (board[index] == '_') {
                backtrack(n, index, board, &top, &max, stack);
                place_piece(n, index, board);
                successful_move = 't';
            }
            else {
                index += 1;
            }
        }

        // Print the board


        // getchar();
    }

    printf("Solutions: %d\n\n", sols);

    // Free the allocated memory
    free(stack);
    free(solutions);
    free(board);
}



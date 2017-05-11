//# 601 west second street, 2nd floor, elevator B, two rights

#include <stdio.h>
#include <stdlib.h>
#include <omp.h>
#include <math.h>
#include <unistd.h>

void print_board(int n, char *board){
    for (int r = 0; r < n; r++) {
        for (int c = 0; c < n; c++) {
            printf("%c ", board[r*n+c]);
        }
        printf("\n");
    }
    printf("\n");
}

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

int validate_board(int n, char *board){
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

void new_board(int n, int top, char *board, char **stack){
    for (int i = 0; i < n*n; i++) {
        board[i] = stack[top][i];
    }
}

void validate_stack_size(int n, int top, int *max, char **stack){
    // realloc stack if it needs to grow
    if (top >= *max){
        *max = *max + floor(*max + n);
        stack = realloc(stack, (*max)*sizeof(char*));
        for (int i = top; i < (*max); i++) {
            stack[i] = malloc((n * n)*sizeof(char));
        }
    }
}

void backtrack(int n, int index, char *board, int *top, char **stack){
    // if only one move is left, backtracking is not needed
    if (remaining_moves(n, board) > 1) {

        // set the place holder for the current move
        board[index] = '*';

        // copy the backtracking array to stack
        for (int i = 0; i < n*n; i++) {
            stack[*top][i] = board[i];
        }

        // move to the next item in the stack
        *top += 1;
    }
}

int main() {

    system("clear");
    system("reset");

    // The size of the board, make this an argument
    int n = 10;
    int s_max = n;              // Max solutions
    int s_top = 0;              // Current solution
    int sols = 0;               // Total number of solutions found


    // Create a 2D array that will hold N*N board arrays
    char **istack = (char**) malloc(n*n*sizeof(char*));
    for (int i = 0; i < n*n; i++) {
        istack[i] = (char*) malloc((n*n)*sizeof(char));
    }

    // Create a 2D array that will hold n solutions.
    char **solutions = (char**) malloc(n*sizeof(char*));
    for (int i = 0; i < n; i++) {
        solutions[i] = (char*) malloc((n*n)*sizeof(char));
    }

    // initialize istack with every possible first move
    #pragma omp parallel for
    for (int o = 0; o < n*n; o++){
        for (int i = 0; i < n*n; i++) {
            if (i < o){
                istack[o][i] = '*';
            }
            else {
                istack[o][i] = '_';
            }
        }
    }

    #pragma omp parallel shared(n, s_top, s_max, sols, solutions)
    {

        #pragma omp for
        for (int init=0; init < n*n; init++) {

            #pragma omp task
            {

                // Thread specific variables
                int tid = omp_get_thread_num();
                int top = 0;
                int max = n*n;
                int index = 0;
                int c = 0;
                int matches = 0;
                char match_found = 'f';
                char successful_move = 'f';

                char *board = (char*) malloc((n*n)*sizeof(char));
                new_board(n, init, board, istack);

                // Create a stack to manage backtracking
                // This is a 2D array that holds boards
                // Top is the latst board to be added
                // Max is the maximum number of boards that can fit in the
                //      memory allocation

                char **stack = (char**) malloc(n*n*sizeof(char*));
                for (int i = 0; i < n*n; i++) {
                    stack[i] = (char*) malloc((n*n)*sizeof(char));
                }

                while (top >= 0) {
                    if (remaining_moves(n, board) > 0){
                        index = 0;
                        successful_move = 'f';
                        while (index < n*n && successful_move == 'f') {
                            if (board[index] == '_') {
                                validate_stack_size(n, top, &max, stack);
                                backtrack(n, index, board, &top, stack);
                                place_piece(n, index, board);
                                successful_move = 't';
                            }
                            else {
                                index += 1;
                            }
                        }
                    }
                    else {
                        #pragma omp critical
                        {
                            if (validate_board(n, board) == 1){
                                if (s_top == 0){
                                    for (int i=0; i < n*n; i++){
                                        solutions[s_top][i] = board[i];
                                    }
                                    s_top += 1;
                                    sols += 1;

                                }
                                else {
                                    match_found = 'f';
                                    for (int s=0; s < s_top; s++){
                                        if (match_found == 'f'){
                                            matches = 0;
                                            for (int c=0; c < n*n; c++){
                                                if (solutions[s][c]==board[c]){
                                                    matches += 1;
                                                }
                                            }
                                            if (matches == n*n){
                                                match_found = 't';
                                            }
                                        }
                                    }
                                    if (match_found == 'f'){
                                        if (s_top >= s_max){
                                            s_max = s_max + floor(s_max / 2);
                                            solutions = realloc(solutions, (s_max)*sizeof(char*));
                                            for (int i = s_top; i < (s_max); i++) {
                                                solutions[i] = malloc((n*n)*sizeof(char));
                                            }
                                        }
                                        for (int i=0; i < n*n; i++){
                                            solutions[s_top][i] = board[i];
                                        }

                                        s_top += 1;
                                        sols += validate_board(n, board);
                                    }
                                }
                            }
                        }
                        top -= 1;
                        if (top >= 0) {
                            new_board(n, top, board, stack);
                        }
                    }
                }
                free(stack);
                free(board);
            }
        }
    }
    printf("Solutions: %d\n\n", sols);
    free(istack);
    free(solutions);
}

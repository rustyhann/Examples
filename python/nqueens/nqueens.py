# Rusty Hann
# rehann@indiana.edu
# CSCI-B551-35867
# Assignment 0
# Question 4
# N Queens


import math


N = 11
stack = []
solutions = 0


def print_board(board):
    global solutions

    output = ""
    for row in range(0, N):
        for column in range(0, N):
            if board[row * N + column] == 'X':
                output += "_" + " "
            else:
                output += board[row * N + column] + " "
        output += '\n'
    print output
    print "Solution: " + str(solutions)
    print ""

def calc_index(row, col):
    return row * N + col


def calc_row(index):
    return int(math.floor(index / N))


def calc_col(index):
    return int(index % N)


def remove_row(board, index):
    row       = calc_row(index)
    col_start = calc_index(row, 0)
    col_end   = calc_index(row, N)
    for i in xrange(col_start, col_end, 1):
        if board[i] == '_':
            board[i] = 'X'
    return board


def remove_col(board, index):
    col       = calc_col(index)
    row_start = calc_index(0, col)
    row_end   = calc_index(N, col)
    for i in xrange(row_start, row_end, N):
        if board[i] == '_':
            board[i] = 'X'
    return board


def remove_diagonal(board, index):


    # remove diagonals going down and right
    row = calc_row(index)
    col_start = calc_col(index) + 1
    for col in xrange(col_start, N, 1):
        if row + 1 < N:
            row += 1
            index_next = calc_index(row, col)
            if board[index_next] == '_':
                board[index_next] = 'X'

    # Remove diagonals going down and left
    row = calc_row(index)
    col_start = calc_col(index) - 1
    for col in xrange(col_start, -1, -1):
        if row + 1 < N:
            row += 1
            index_next = calc_index(row, col)
            if board[index_next] == '_':
                board[index_next] = 'X'

    # Remove diagonals going up and right
    row = calc_row(index)
    col_start = calc_col(index) + 1
    for col in xrange(col_start, N, 1):
        if row - 1 >= 0:
            row -= 1
            index_next = calc_index(row, col)
            if board[index_next] == '_':
                board[index_next] = 'X'

    # Remove diagonals going up and left
    row = calc_row(index)
    col_start = calc_col(index) - 1
    for col in xrange(col_start, -1, -1):
        if row - 1 >= 0:
            row -= 1
            index_next = calc_index(row, col)
            if board[index_next] == '_':
                board[index_next] = 'X'

    return board

def place_piece(board):
    global stack
    global solutions

    # get the index of the
    index = board.index('_')

    # determine if backtracking is needed and place the resulting board in the stack
    if board.count('_') >= 2:
        board[index] = 'X'
        stack.append(list(board))

    # place the piece
    board[index] = 'Q'

    # minimize the state space
    board = remove_row(board, index)
    board = remove_col(board, index)
    board = remove_diagonal(board, index)

    # check to see if a solution has been found, and recursively call place_piece if it has not
    if board.count('Q') == N:
        solutions += 1
        print_board(board)
    elif '_' in board:
        place_piece(board)


def main():
    global stack
    global solutions

    print "N Queens, N = " + str(N)
    initial_board = ['_'] * N * N
    stack.append(initial_board)
    while len(stack) > 0:
        place_piece(stack.pop())
    print


main()

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <stdint.h>
#include "entropy.h"

#define TINY 1.0e-30

void main()
{
	// control values
	uint32_t min_rows     = 5000;
	uint32_t max_rows     = 10000;
	uint32_t row_iterator = 5000;
	uint32_t min_cols     = 5000;
	uint32_t max_cols     = 10000;
	uint32_t col_iterator = 5000;

	// entropy calculation values
	float entropy_table          = 0.0;
	float entropy_rows           = 0.0;
	float entropy_cols           = 0.0;
	float entropy_rowsGivencols  = 0.0;
	float entropy_colsGivenRows  = 0.0;
	float dependency_rowsOncols  = 0.0;
	float dependency_colsOnRows  = 0.0;
	float dependency_symmetrical = 0.0;

	// timing values
	float time_sum_all       = 0.0;
	float time_sum_rows      = 0.0;
	float time_sum_cols      = 0.0;
	float time_entropy_table = 0.0;
	float time_entropy_rows  = 0.0;
	float time_entropy_cols  = 0.0;

	// calculate integer entropy with random values
	for(uint32_t rows = min_rows; rows <= max_rows; rows += row_iterator)
	{
		for (uint32_t cols = min_cols; cols <= max_cols; cols += col_iterator)
		{
			
			// Create a float array that represents a rows x cols table
			float *table = malloc(rows * cols * sizeof(float));

			// (re)seed the random number generator
			srand(time(NULL));

			// fill the table with random floats
			for(uint32_t row=0; row < rows; row++)
			{
				for (uint32_t col=0; col < cols; col++)
				{
					table[row * cols + col] = (float)rand()/(float)(RAND_MAX/32767);
				}
			}

			// calculate table entropy
			entropy_float(
				table,
				&rows,
				&cols,
				&entropy_table,
				&entropy_rows,
				&entropy_cols,
				&entropy_rowsGivencols,
				&entropy_colsGivenRows,
				&dependency_rowsOncols,
				&dependency_colsOnRows,
				&dependency_symmetrical,
				&time_sum_all,
				&time_sum_rows,
				&time_sum_cols,
				&time_entropy_table,
				&time_entropy_rows,
				&time_entropy_cols
			);

			// cleanup
			free(table);

			printf("Rows: %d, cols: %d\n", rows, cols);
			printf("Entropy of Table          : %1.4f\n", entropy_table);
			printf("Entropy of x-distribution : %1.4f\n", entropy_rows);
			printf("Entropy of y-distribution : %1.4f\n", entropy_cols);
			printf("Entropy of x given y      : %1.4f\n", entropy_rowsGivencols);
			printf("Entropy of y given x      : %1.4f\n", entropy_colsGivenRows);
			printf("Dependency or x on y      : %1.4f\n", dependency_rowsOncols);
			printf("Dependency of y on x      : %1.4f\n", dependency_colsOnRows);
			printf("Symmetrical Dependency    : %1.4f\n", dependency_symmetrical);
			printf("Time Sum All              : %1.4f seconds\n", time_sum_all);
			printf("Time Sum Rows             : %1.4f seconds\n", time_sum_rows);
			printf("Time Sum cols             : %1.4f seconds\n", time_sum_cols);
			printf("Time Entropy Rows         : %1.4f seconds\n", time_entropy_rows);
			printf("Time Entropy cols         : %1.4f seconds\n", time_entropy_cols);
			printf("Time Table Entropy        : %1.4f seconds\n", time_entropy_table);
			printf("\n");			
		}
	}
}
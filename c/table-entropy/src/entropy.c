#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <stdint.h>

#define TINY 1.0e-30

void entropy_int(
	uint32_t *table,
	uint32_t *rows,
	uint32_t *cols,
	float *entropy_table,
	float *entropy_rows,
	float *entropy_cols,
	float *entropy_rowsGivencols,
	float *entropy_colsGivenRows,
	float *dependency_rowsOncols,
	float *dependency_colsOnRows,
	float *dependency_symmetrical,
	float *time_sum_all,
	float *time_sum_rows,
	float *time_sum_cols,
	float *time_entropy_table,
	float *time_entropy_rows,
	float *time_entropy_cols
){
	// local variables
	clock_t begin, end;
	float sum_all = 0.0;
	uint32_t sum_rows[*rows];
	uint32_t sum_cols[*cols];
	float p = 0.0;

	// reset argument values
	*entropy_table            = 0.0;
	*entropy_rows             = 0.0;
	*entropy_cols          = 0.0;
	*entropy_rowsGivencols = 0.0;
	*entropy_colsGivenRows = 0.0;
	*dependency_rowsOncols = 0.0;
	*dependency_colsOnRows = 0.0;
	*dependency_symmetrical   = 0.0;

	// Calculate the sum of all cells
	begin = clock();
	for(uint32_t row = 0; row < *rows; row++)
	{
		for(uint32_t col = 0; col < *cols; col++)
		{
			sum_all += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_all = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the sum of all rows per col
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		sum_rows[row]=0;
		for(uint32_t col=0; col < *cols; col++)
		{
			sum_rows[row] += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_rows = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the sum of all cols per row
	begin = clock();
	for(uint32_t col=0; col < *cols; col++)
	{
		sum_cols[col]=0;
		for(uint32_t row=0; row < *rows; row++)
		{
			sum_cols[col] += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_cols = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the table
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		for(uint32_t col=0; col < *cols; col++)
		{
			if(table[row * *cols + col])
			{
				p=table[row * *cols + col] / sum_all;
				*entropy_table -= p * log(p);
			}
		}
	}
	end = clock();
	*time_entropy_table = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the x distribution
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		if (sum_rows[row])
		{
			p = sum_rows[row] / sum_all;
			*entropy_rows -= p * log(p);
		}
	}
	end = clock();
	*time_entropy_rows = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the x distribution
	begin = clock();
	for(uint32_t col=0; col < *cols; col++)
	{
		if (sum_cols[col])
		{
			p = sum_cols[col] / sum_all;
			*entropy_cols -= p * log(p);
		}
	}
	end = clock();
	*time_entropy_cols = (float)(end - begin) / CLOCKS_PER_SEC;

	// these are not timed as they are relatively simple calculations

	// calculate the row entropy given cols
	*entropy_rowsGivencols = *entropy_table - *entropy_cols;

	// calculate col entropy given rows
	*entropy_colsGivenRows = *entropy_table - *entropy_rows;

	// calculate col dependency on rows
	*dependency_rowsOncols =
		(*entropy_rows - *entropy_rowsGivencols) /
		(*entropy_rows + TINY);

	// calculate row dependency on cols
	*dependency_colsOnRows =
		(*entropy_cols - *entropy_colsGivenRows) /
		(*entropy_cols + TINY);

	// calculate symmetrical dependency
	*dependency_symmetrical =
		2.0 * (*entropy_rows + *entropy_cols - *entropy_table) /
		(*entropy_rows + *entropy_cols + TINY);
}

void entropy_float(
	float *table,
	uint32_t *rows,
	uint32_t *cols,
	float *entropy_table,
	float *entropy_rows,
	float *entropy_cols,
	float *entropy_rowsGivencols,
	float *entropy_colsGivenRows,
	float *dependency_rowsOncols,
	float *dependency_colsOnRows,
	float *dependency_symmetrical,
	float *time_sum_all,
	float *time_sum_rows,
	float *time_sum_cols,
	float *time_entropy_table,
	float *time_entropy_rows,
	float *time_entropy_cols
){
	// local variables
	clock_t begin, end;
	float sum_all = 0.0;
	float sum_rows[*rows];
	float sum_cols[*cols];
	float p = 0.0;

	// reset argument values
	*entropy_table          = 0.0;
	*entropy_rows           = 0.0;
	*entropy_cols           = 0.0;
	*entropy_rowsGivencols  = 0.0;
	*entropy_colsGivenRows  = 0.0;
	*dependency_rowsOncols  = 0.0;
	*dependency_colsOnRows  = 0.0;
	*dependency_symmetrical = 0.0;

	// Calculate the sum of all cells
	begin = clock();
	for(uint32_t row = 0; row < *rows; row++)
	{
		for(uint32_t col = 0; col < *cols; col++)
		{
			sum_all += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_all = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the sum of all rows per col
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		sum_rows[row]=0;
		for(uint32_t col=0; col < *cols; col++)
		{
			sum_rows[row] += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_rows = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the sum of all cols per row
	begin = clock();
	for(uint32_t col=0; col < *cols; col++)
	{
		sum_cols[col]=0;
		for(uint32_t row=0; row < *rows; row++)
		{
			sum_cols[col] += table[row * *cols + col];
		}
	}
	end = clock();
	*time_sum_cols = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the table
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		for(uint32_t col=0; col < *cols; col++)
		{
			if(table[row * *cols + col])
			{
				p=table[row * *cols + col] / sum_all;
				*entropy_table -= p * log(p);
			}
		}
	}
	end = clock();
	*time_entropy_table = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the x distribution
	begin = clock();
	for(uint32_t row=0; row < *rows; row++)
	{
		if (sum_rows[row])
		{
			p = sum_rows[row] / sum_all;
			*entropy_rows -= p * log(p);
		}
	}
	end = clock();
	*time_entropy_rows = (float)(end - begin) / CLOCKS_PER_SEC;

	// Calculate the entropy of the x distribution
	begin = clock();
	for(uint32_t col=0; col < *cols; col++)
	{
		if (sum_cols[col])
		{
			p = sum_cols[col] / sum_all;
			*entropy_cols -= p * log(p);
		}
	}
	end = clock();
	*time_entropy_cols = (float)(end - begin) / CLOCKS_PER_SEC;

	// these are not timed as they are relatively simple calculations

	// calculate the row entropy given cols
	*entropy_rowsGivencols = *entropy_table - *entropy_cols;

	// calculate col entropy given rows
	*entropy_colsGivenRows = *entropy_table - *entropy_rows;

	// calculate col dependency on rows
	*dependency_rowsOncols =
		(*entropy_rows - *entropy_rowsGivencols) /
		(*entropy_rows + TINY);

	// calculate row dependency on cols
	*dependency_colsOnRows =
		(*entropy_cols - *entropy_colsGivenRows) /
		(*entropy_cols + TINY);

	// calculate symmetrical dependency
	*dependency_symmetrical =
		2.0 * (*entropy_rows + *entropy_cols - *entropy_table) /
		(*entropy_rows + *entropy_cols + TINY);
}
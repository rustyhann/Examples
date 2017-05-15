#ifndef ENTROPY_H_INCLUDED
#define ENTROPY_H_INCLUDED

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
);

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
);

#endif
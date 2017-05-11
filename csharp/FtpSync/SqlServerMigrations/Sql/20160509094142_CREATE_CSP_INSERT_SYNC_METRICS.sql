CREATE PROCEDURE CSP_INSERT_SYNC_METRICS

    @SYNC_Table VARCHAR(255),
	@SYNC_StartTime DATETIME,
	@SYNC_EndTime DATETIME,
	@SYNC_ElapsedTime DECIMAL(38,3),
	@SYNC_FetchTime DECIMAL(38,3),
	@SYNC_LoadTime DECIMAL(38,3),
	@SYNC_CleanTime DECIMAL(38,3),
	@SYNC_MergeTime DECIMAL(38,3),
	@SYNC_RowsUpdated BIGINT,
	@SYNC_Success BIT

AS
BEGIN

	BEGIN TRY

		BEGIN TRANSACTION

			INSERT INTO SYNC_METRICS
			(
				SYNC_Table,
				SYNC_StartTime,
				SYNC_EndTime,
				SYNC_ElapsedTime,
				SYNC_FetchTime,
				SYNC_LoadTime,
				SYNC_CleanTime,
				SYNC_MergeTime,
				SYNC_RowsUpdated,
				SYNC_Success
			)
			VALUES
			(
				@SYNC_Table,
				@SYNC_StartTime,
				@SYNC_EndTime,
				@SYNC_ElapsedTime,
				@SYNC_FetchTime,
				@SYNC_LoadTime,
				@SYNC_CleanTime,
				@SYNC_MergeTime,
				@SYNC_RowsUpdated,
				@SYNC_Success
			);

		COMMIT TRANSACTION;

	END TRY

	BEGIN CATCH

		ROLLBACK TRANSACTION;

		THROW;

	END CATCH;

END;
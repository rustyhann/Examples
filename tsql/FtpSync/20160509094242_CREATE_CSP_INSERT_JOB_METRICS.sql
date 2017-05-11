CREATE PROCEDURE CSP_INSERT_JOB_METRICS

    @JOB_StartTime DATETIME,
	@JOB_EndTime DATETIME,
	@JOB_ElapsedTime DECIMAL,
	@JOB_Success BIT

AS
BEGIN

	BEGIN TRY

		BEGIN TRANSACTION

			INSERT INTO JOB_METRICS
			(
				JOB_StartTime,
				JOB_EndTime,
				JOB_ElapsedTime,
				JOB_Success
			)
			VALUES
			(
				@JOB_StartTime,
				@JOB_EndTime,
				@JOB_ElapsedTime,
				@JOB_Success
			);

		COMMIT TRANSACTION;

	END TRY

	BEGIN CATCH

		ROLLBACK TRANSACTION;

		THROW;

	END CATCH;

END;
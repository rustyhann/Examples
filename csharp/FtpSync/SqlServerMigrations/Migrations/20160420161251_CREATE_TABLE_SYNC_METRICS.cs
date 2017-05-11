using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160420161251)]
    public class CREATE_TABLE_SYNC_METRICS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161251_CREATE_TABLE_SYNC_METRICS.sql");
        }

        public override void Down()
        {
        }
    }
}
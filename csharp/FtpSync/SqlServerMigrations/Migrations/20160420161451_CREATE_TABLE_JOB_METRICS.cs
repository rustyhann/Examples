using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160420161451)]
    public class CREATE_TABLE_JOB_METRICS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161451_CREATE_TABLE_JOB_METRICS.sql");
        }

        public override void Down()
        {
        }
    }
}
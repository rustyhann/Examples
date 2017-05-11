using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160509094242)]
    public class CREATE_CSP_INSERT_JOB_METRICS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160509094242_CREATE_CSP_INSERT_JOB_METRICS.sql");
        }

        public override void Down()
        {
        }
    }
}
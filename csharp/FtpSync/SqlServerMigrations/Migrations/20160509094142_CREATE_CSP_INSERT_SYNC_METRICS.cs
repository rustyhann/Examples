using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160509094142)]
    public class CREATE_CSP_INSERT_SYNC_METRICS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160509094142_CREATE_CSP_INSERT_SYNC_METRICS.sql");
        }

        public override void Down()
        {
        }
    }
}
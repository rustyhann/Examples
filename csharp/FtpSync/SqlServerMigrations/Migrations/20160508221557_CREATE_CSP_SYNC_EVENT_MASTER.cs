using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160508221557)]
    public class CREATE_CSP_SYNC_EVENT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160508221557_CREATE_CSP_SYNC_EVENT_MASTER.sql");
        }

        public override void Down()
        {
        }
    }
}
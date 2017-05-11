using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160509090007)]
    public class CREATE_CSP_SYNC_EVT_CLASS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160509090007_CREATE_CSP_SYNC_EVT_CLASS.sql");
        }

        public override void Down()
        {
        }
    }
}
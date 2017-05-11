using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160509095142)]
    public class CREATE_CSP_TOGGLE_SIMPLE_RECOVERY : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160509095142_CREATE_CSP_TOGGLE_SIMPLE_RECOVERY.sql");
        }

        public override void Down()
        {
        }
    }
}
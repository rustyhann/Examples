using FluentMigrator;
using System;

namespace SqlServerMigrations
{
    [Migration(20160509093142)]
    public class CREATE_CSP_SYNC_ACCT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160509093142_CREATE_CSP_SYNC_ACCT_MASTER.sql");
        }

        public override void Down()
        {
        }
    }
}
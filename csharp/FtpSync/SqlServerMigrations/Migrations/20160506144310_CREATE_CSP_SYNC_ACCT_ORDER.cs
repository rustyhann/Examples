using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160506144310)]
    public class CREATE_CSP_SYNC_ACCT_ORDER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160506144310_CREATE_CSP_SYNC_ACCT_ORDER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160506100955)]
    public class CREATE_CSP_SYNC_TRANSACTIONS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160506100955_CREATE_CSP_SYNC_TRANSACTIONS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

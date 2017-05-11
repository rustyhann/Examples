using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161706)]
    public class CREATE_TVP_ACCT_ORDER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161706_CREATE_TVP_ACCT_ORDER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

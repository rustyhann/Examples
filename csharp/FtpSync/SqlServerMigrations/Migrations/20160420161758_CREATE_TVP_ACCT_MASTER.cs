using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161758)]
    public class CREATE_TVP_ACCT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161758_CREATE_TVP_ACCT_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161151)]
    public class CREATE_TABLE_TABLE_ACCT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161151_CREATE_TABLE_ACCT_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

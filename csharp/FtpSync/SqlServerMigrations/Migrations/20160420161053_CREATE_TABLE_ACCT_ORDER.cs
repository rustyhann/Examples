using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161053)]
    public class CREATE_TABLE_TABLE_ACCT_ORDER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161053_CREATE_TABLE_ACCT_ORDER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

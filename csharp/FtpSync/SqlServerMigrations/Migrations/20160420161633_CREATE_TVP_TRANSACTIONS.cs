using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161633)]    
    public class CREATE_TVP_TRANSACTIONS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161633_CREATE_TVP_TRANSACTIONS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

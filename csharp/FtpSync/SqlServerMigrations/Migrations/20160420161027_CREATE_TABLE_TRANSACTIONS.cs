using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161027)]
    public class CREATE_TABLE_TABLE_TRANSACTIONS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161027_CREATE_TABLE_TRANSACTIONS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

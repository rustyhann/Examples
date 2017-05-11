using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161113)]
    public class CREATE_TABLE_TABLE_STATUS_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161113_CREATE_TABLE_STATUS_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

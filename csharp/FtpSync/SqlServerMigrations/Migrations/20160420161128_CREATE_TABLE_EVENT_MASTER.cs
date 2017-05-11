using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161128)]
    public class CREATE_TABLE_TABLE_EVENT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161128_CREATE_TABLE_EVENT_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

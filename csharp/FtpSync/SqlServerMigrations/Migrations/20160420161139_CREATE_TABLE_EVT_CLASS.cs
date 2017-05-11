using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161139)]    
    public class CREATE_TABLE_TABLE_EVT_CLASS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161139_CREATE_TABLE_EVT_CLASS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161749)]
    public class CREATE_TVP_EVT_CLASS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161749_CREATE_TVP_EVT_CLASS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

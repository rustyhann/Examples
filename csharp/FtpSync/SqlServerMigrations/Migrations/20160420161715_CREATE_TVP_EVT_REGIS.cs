using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161715)]
    public class CREATE_TVP_EVT_REGIS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161715_CREATE_TVP_EVT_REGIS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

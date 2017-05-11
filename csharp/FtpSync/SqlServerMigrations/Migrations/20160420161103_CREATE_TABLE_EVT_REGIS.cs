using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161103)]
    public class CREATE_TABLE_TABLE_EVT_REGIS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161103_CREATE_TABLE_EVT_REGIS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

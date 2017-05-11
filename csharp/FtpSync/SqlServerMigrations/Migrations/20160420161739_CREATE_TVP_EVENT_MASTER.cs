using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161739)]
    public class CREATE_TVP_EVENT_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161739_CREATE_TVP_EVENT_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

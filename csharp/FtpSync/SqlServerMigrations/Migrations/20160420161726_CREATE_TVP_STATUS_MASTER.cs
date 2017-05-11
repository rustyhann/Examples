using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161726)]
    public class CREATE_TVP_STATUS_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161726_CREATE_TVP_STATUS_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

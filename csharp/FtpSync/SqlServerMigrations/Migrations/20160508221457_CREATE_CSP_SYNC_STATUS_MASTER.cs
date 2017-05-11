using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160508221457)]
    public class CREATE_CSP_SYNC_STATUS_MASTER : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160508221457_CREATE_CSP_SYNC_STATUS_MASTER.sql");
        }

        public override void Down()
        {
            
        }
    }
}

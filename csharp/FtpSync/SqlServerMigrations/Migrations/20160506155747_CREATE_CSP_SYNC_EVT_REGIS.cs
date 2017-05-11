using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160506155747)]
    public class CREATE_CSP_SYNC_EVT_REGIS : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160506155747_CREATE_CSP_SYNC_EVT_REGIS.sql");
        }

        public override void Down()
        {
            
        }
    }
}

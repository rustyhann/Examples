using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160502104350)]
    public class CREATE_CSP_SYNC_TRANS_TYPES : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160502104350_CREATE_CSP_SYNC_TRANS_TYPES.sql");
        }

        public override void Down()
        {
            
        }
    }
}

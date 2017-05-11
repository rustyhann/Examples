using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160506124327)]
    public class CREATE_CSP_SYNC_TRANS_METHOD_DESC : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160506124327_CREATE_CSP_SYNC_TRANS_METHOD_DESC.sql");
        }

        public override void Down()
        {
            
        }
    }
}

using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161645)]
    public class CREATE_TVP_TRANS_METHOD_DESC : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161645_CREATE_TVP_TRANS_METHOD_DESC.sql");
        }

        public override void Down()
        {
            
        }
    }
}

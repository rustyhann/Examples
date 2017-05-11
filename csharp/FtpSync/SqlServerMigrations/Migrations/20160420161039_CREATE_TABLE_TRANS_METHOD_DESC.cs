using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161039)]
    public class CREATE_TABLE_TABLE_TRANS_METHOD_DESC : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161039_CREATE_TABLE_TRANS_METHOD_DESC.sql");
        }

        public override void Down()
        {
            
        }
    }
}

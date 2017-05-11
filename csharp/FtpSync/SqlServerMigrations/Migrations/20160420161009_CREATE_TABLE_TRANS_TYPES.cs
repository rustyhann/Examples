using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161009)]
    public class CREATE_TABLE_TRANS_TYPES : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161009_CREATE_TABLE_TRANS_TYPES.sql");
        }

        public override void Down()
        {

        }
    }
}

using System;
using FluentMigrator;

namespace SqlServerMigrations
{
    [Migration(20160420161621)]
    public class CREATE_TVP_TRANS_TYPES : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("20160420161621_CREATE_TVP_TRANS_TYPES.sql");
        }

        public override void Down()
        {

        }
    }
}

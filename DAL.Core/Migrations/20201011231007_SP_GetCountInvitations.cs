using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Core.Migrations
{
    public partial class SP_GetCountInvitations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"CREATE PROCEDURE [dbo].[getcountinvitation]
                                @appid int,
                                @countInvitations int output
                                AS
                                SELECT @countInvitations=COUNT(Id) from [dbo].[Invitations] WHERE CONVERT(DATE, Createdon) = CONVERT(DATE, GETDATE())";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            const string sql = @"DROP PROCEDURE [dbo].[getcountinvitation]";

            migrationBuilder.Sql(sql);
        }
    }
}

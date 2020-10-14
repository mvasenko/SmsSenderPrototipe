using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Core.Migrations
{
    public partial class SP_Invite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string sql = @"CREATE TYPE [dbo].[List] AS TABLE
                        (
                            String nvarchar(255)
                        )
                        GO

                        CREATE PROCEDURE [dbo].[invite]
                            @user_id int,
                            @phonestext [dbo].[List] ReadOnly
                        AS
                        INSERT INTO [dbo].[Invitations] (Id, Phone, Author, Createdon)
                        SELECT NEWID(), p.String, @user_id, GETDATE() FROM @phonestext AS p";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            const string sql = @"DROP PROCEDURE [dbo].[invite]
                                    GO
                                    DROP TYPE [dbo].[List]";

            migrationBuilder.Sql(sql);
        }
    }
}

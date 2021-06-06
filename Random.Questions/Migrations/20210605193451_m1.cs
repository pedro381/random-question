using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Random.Questions.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdQuestionNoReply",
                table: "Reply",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

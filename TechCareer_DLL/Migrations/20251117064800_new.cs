using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCareer_DLL.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequiredSkills_JobPosts_JobPostId",
                table: "JobRequiredSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobRequiredSkills_JobPostId",
                table: "JobRequiredSkills");

            migrationBuilder.DropColumn(
                name: "JobPostId",
                table: "JobRequiredSkills");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequiredSkills_JobID",
                table: "JobRequiredSkills",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequiredSkills_JobPosts_JobID",
                table: "JobRequiredSkills",
                column: "JobID",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobRequiredSkills_JobPosts_JobID",
                table: "JobRequiredSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobRequiredSkills_JobID",
                table: "JobRequiredSkills");

            migrationBuilder.AddColumn<int>(
                name: "JobPostId",
                table: "JobRequiredSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobRequiredSkills_JobPostId",
                table: "JobRequiredSkills",
                column: "JobPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequiredSkills_JobPosts_JobPostId",
                table: "JobRequiredSkills",
                column: "JobPostId",
                principalTable: "JobPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

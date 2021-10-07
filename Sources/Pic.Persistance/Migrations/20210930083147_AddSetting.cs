using Microsoft.EntityFrameworkCore.Migrations;
using Pic.Data.Constants;

namespace Pic.Persistance.Migrations
{
    public partial class AddSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Settings", SettingsConstants.SaveFileLocation, "C:/Pic.Data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}

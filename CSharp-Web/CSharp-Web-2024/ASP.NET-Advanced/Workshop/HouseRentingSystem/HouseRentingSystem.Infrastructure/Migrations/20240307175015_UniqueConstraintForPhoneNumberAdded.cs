using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c25adf22-8ae3-4b56-860a-6bfffc1bd913", "AQAAAAIAAYagAAAAEI+5htbXzenfJIosFFtaCrfr7pN7hyaGAndQ5zzYqTg2rXfe7aLyj5aSrmdW0Cr9cA==", "2f48923c-f9c5-42cd-b374-c97d7c9c32ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d783f625-b1e9-4a9f-b194-3d10febc257c", "AQAAAAIAAYagAAAAEN8chVNdciFBV/+p6wzfWcoyDxL8nJmT8MhyoiAhHL8PyPV/4szirdk69NSdCQ8pqA==", "278cae79-63c2-4735-8813-4ecf54326525" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a572086-b8d9-49ac-a35c-e796835747b6", "AQAAAAIAAYagAAAAEIKXOp08pLVxjjAn3BjPToJHO8DXIJwBlq05U7ui8/ZjvSI60U+gNIa+I7L3/AOkiA==", "3715d908-0a7d-4ab9-a10c-abc6c160155b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a2dc154-313c-416c-9a80-cd4174fb4efc", "AQAAAAIAAYagAAAAEALhTQz8+lMRziZDbDVYTYWm5j2EfgXg9TGRWxVvVkWqSXb6yxqn/VX12DrmEUZImA==", "ee3be488-35cc-4f35-aa1b-a6707e3f6811" });
        }
    }
}

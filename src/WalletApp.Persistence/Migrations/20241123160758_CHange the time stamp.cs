using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CHangethetimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("0a089053-cb05-44d2-9c5e-7ba4c53f395b"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c075797-e98e-43a3-9497-488c857edb33"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("516d455b-37d9-4557-ba58-15cb1e2e08b2"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c4201f1-12e3-4bfc-828b-6c38f26a59d7"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("9265202e-9f2a-4459-8ed9-4c95970de981"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("95ebc2db-201d-487a-95e5-fffe4c0eec86"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("9661a1d1-f1a6-42a6-90fa-42e1dac33e89"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4b2301d-b5f2-4a37-8966-a475c1fc08b8"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("eec4c76f-79da-43ed-8953-d6ba5a9f40e9"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("f459fe19-bf20-4682-b9d3-c102da526d25"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WalletUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "WalletUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WalletUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "WalletUsers",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02a0a73a-ba93-4e02-9e2f-967bb3aaa526"), "303 Birch St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8892), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8896), "diana.miller@example.com", "Diana", "Miller", "678-901-2345", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8893) },
                    { new Guid("03cf2198-59c1-445c-8401-25dc77ca242c"), "404 Cedar St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8896), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8924), "eve.wilson@example.com", "Eve", "Wilson", "789-012-3456", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8897) },
                    { new Guid("46f40183-1f18-4b60-b9dd-8822f1af8775"), "789 Oak St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8882), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8884), "alice.johnson@example.com", "Alice", "Johnson", "345-678-9012", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8882) },
                    { new Guid("793de3bc-679f-4fe6-99df-88a247486222"), "505 Walnut St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8926), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8929), "frank.moore@example.com", "Frank", "Moore", "890-123-4567", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8926) },
                    { new Guid("7ad7db99-b84f-4c88-b92f-240d7f694e17"), "101 Pine St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8885), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8888), "bob.brown@example.com", "Bob", "Brown", "456-789-0123", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8885) },
                    { new Guid("97c24ee1-e22c-43c0-ab44-1270cbc2e6f1"), "202 Maple St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8889), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8892), "charlie.davis@example.com", "Charlie", "Davis", "567-890-1234", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8889) },
                    { new Guid("bc3c4d93-4778-4e95-8b49-fedb9eba8366"), "606 Chestnut St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8929), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8932), "grace.taylor@example.com", "Grace", "Taylor", "901-234-5678", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8930) },
                    { new Guid("cdf94f16-9b86-43ab-ba7f-c106fe34cba6"), "456 Elm St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8878), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8881), "jane.smith@example.com", "Jane", "Smith", "234-567-8901", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8878) },
                    { new Guid("e66057f8-e7cd-446d-87ef-a6a5686f8570"), "123 Main St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8840), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8877), "john.doe@example.com", "John", "Doe", "123-456-7890", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8843) },
                    { new Guid("fe0d28c8-145e-4dff-bba5-14fbfc772313"), "707 Spruce St", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8932), new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8935), "hank.anderson@example.com", "Hank", "Anderson", "012-345-6789", new DateTime(2024, 11, 23, 16, 7, 58, 66, DateTimeKind.Utc).AddTicks(8933) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("02a0a73a-ba93-4e02-9e2f-967bb3aaa526"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("03cf2198-59c1-445c-8401-25dc77ca242c"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("46f40183-1f18-4b60-b9dd-8822f1af8775"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("793de3bc-679f-4fe6-99df-88a247486222"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("7ad7db99-b84f-4c88-b92f-240d7f694e17"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("97c24ee1-e22c-43c0-ab44-1270cbc2e6f1"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc3c4d93-4778-4e95-8b49-fedb9eba8366"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("cdf94f16-9b86-43ab-ba7f-c106fe34cba6"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("e66057f8-e7cd-446d-87ef-a6a5686f8570"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe0d28c8-145e-4dff-bba5-14fbfc772313"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "WalletUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "WalletUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "WalletUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "WalletUsers",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a089053-cb05-44d2-9c5e-7ba4c53f395b"), "123 Main St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2617), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2659), "john.doe@example.com", "John", "Doe", "123-456-7890", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2621) },
                    { new Guid("2c075797-e98e-43a3-9497-488c857edb33"), "202 Maple St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2680), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2684), "charlie.davis@example.com", "Charlie", "Davis", "567-890-1234", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2681) },
                    { new Guid("516d455b-37d9-4557-ba58-15cb1e2e08b2"), "789 Oak St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2669), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2673), "alice.johnson@example.com", "Alice", "Johnson", "345-678-9012", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2669) },
                    { new Guid("8c4201f1-12e3-4bfc-828b-6c38f26a59d7"), "456 Elm St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2662), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2667), "jane.smith@example.com", "Jane", "Smith", "234-567-8901", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2663) },
                    { new Guid("9265202e-9f2a-4459-8ed9-4c95970de981"), "707 Spruce St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2725), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2730), "hank.anderson@example.com", "Hank", "Anderson", "012-345-6789", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2726) },
                    { new Guid("95ebc2db-201d-487a-95e5-fffe4c0eec86"), "303 Birch St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2685), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2690), "diana.miller@example.com", "Diana", "Miller", "678-901-2345", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2686) },
                    { new Guid("9661a1d1-f1a6-42a6-90fa-42e1dac33e89"), "606 Chestnut St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2720), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2724), "grace.taylor@example.com", "Grace", "Taylor", "901-234-5678", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2721) },
                    { new Guid("d4b2301d-b5f2-4a37-8966-a475c1fc08b8"), "505 Walnut St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2697), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2719), "frank.moore@example.com", "Frank", "Moore", "890-123-4567", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2697) },
                    { new Guid("eec4c76f-79da-43ed-8953-d6ba5a9f40e9"), "101 Pine St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2675), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2679), "bob.brown@example.com", "Bob", "Brown", "456-789-0123", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2675) },
                    { new Guid("f459fe19-bf20-4682-b9d3-c102da526d25"), "404 Cedar St", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2691), new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2695), "eve.wilson@example.com", "Eve", "Wilson", "789-012-3456", new DateTime(2024, 11, 23, 16, 1, 45, 167, DateTimeKind.Utc).AddTicks(2691) }
                });
        }
    }
}

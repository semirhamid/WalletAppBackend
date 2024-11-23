using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalletApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingWalletUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WalletUsers",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1af4e2e5-f691-4c10-89c5-8f177268de97"), "123 Main St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7360), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "123-456-7890", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7363) },
                    { new Guid("2b8d88f5-d8e2-4665-9f87-16471d5d90a3"), "456 Elm St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7404), new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "234-567-8901", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7405) },
                    { new Guid("368ad1f5-b6ec-4828-af78-444c76429265"), "789 Oak St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7411), new DateTime(1990, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice", "Johnson", "345-678-9012", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7412) },
                    { new Guid("464b4468-3771-44cb-b949-d08660e15f14"), "505 Walnut St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7439), new DateTime(2015, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank.moore@example.com", "Frank", "Moore", "890-123-4567", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7440) },
                    { new Guid("4ab1dedd-cf0d-4522-bc8d-78bdd5200e40"), "404 Cedar St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7434), new DateTime(2010, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "eve.wilson@example.com", "Eve", "Wilson", "789-012-3456", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7434) },
                    { new Guid("a808d4ea-3516-4451-8c76-f57eec9f3a7a"), "606 Chestnut St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7463), new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "grace.taylor@example.com", "Grace", "Taylor", "901-234-5678", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7464) },
                    { new Guid("b1d2efa4-88e9-4db4-95ad-1604488b7c5b"), "101 Pine St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7417), new DateTime(1995, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.brown@example.com", "Bob", "Brown", "456-789-0123", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7418) },
                    { new Guid("c4fa1d8f-0e4d-4733-b226-d31e7b5f786d"), "202 Maple St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7423), new DateTime(2000, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.davis@example.com", "Charlie", "Davis", "567-890-1234", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7423) },
                    { new Guid("e6519812-994f-42e5-acb7-80b3f509ca21"), "303 Birch St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7429), new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.miller@example.com", "Diana", "Miller", "678-901-2345", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7430) },
                    { new Guid("fce6f1ae-a351-4bf9-beb5-d30f5780f38e"), "707 Spruce St", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7469), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "hank.anderson@example.com", "Hank", "Anderson", "012-345-6789", new DateTime(2024, 11, 23, 14, 50, 55, 826, DateTimeKind.Utc).AddTicks(7470) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("1af4e2e5-f691-4c10-89c5-8f177268de97"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b8d88f5-d8e2-4665-9f87-16471d5d90a3"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("368ad1f5-b6ec-4828-af78-444c76429265"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("464b4468-3771-44cb-b949-d08660e15f14"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("4ab1dedd-cf0d-4522-bc8d-78bdd5200e40"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("a808d4ea-3516-4451-8c76-f57eec9f3a7a"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("b1d2efa4-88e9-4db4-95ad-1604488b7c5b"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("c4fa1d8f-0e4d-4733-b226-d31e7b5f786d"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6519812-994f-42e5-acb7-80b3f509ca21"));

            migrationBuilder.DeleteData(
                table: "WalletUsers",
                keyColumn: "Id",
                keyValue: new Guid("fce6f1ae-a351-4bf9-beb5-d30f5780f38e"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class CreateTablePortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7712),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7201),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6788),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.CreateTable(
                name: "portfolio",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    key_access = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    firstname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    lastname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    github_link = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    linkedin_link = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    about_me = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2339)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2460)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_users",
                columns: table => new
                {
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_users", x => new { x.portfolio_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_portfolio_users_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_portfolio_users_portfolio_portfolio_id",
                        column: x => x.portfolio_id,
                        principalTable: "portfolio",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "bc2d399b-281d-4199-878e-2495733d616a");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "415577a4-adea-479e-ae3d-31ca1a8cd5ab");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "bf8fa88c-57c2-4345-8b4e-d961d48a610e", new DateTime(2023, 7, 31, 21, 23, 35, 163, DateTimeKind.Local).AddTicks(867), "AQAAAAEAACcQAAAAEPWFgJ33MVw+m7YmiiYZzntKKHWgJt78bjcQ9jOzJg82Z6nvShTE7GHhZBa9IBXLxw==", "92fbe55b-dfc5-4cc6-af1d-10f74832db85", new DateTime(2023, 7, 31, 21, 23, 35, 163, DateTimeKind.Local).AddTicks(878) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5873), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5880), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5882), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5882) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5883), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5883) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5884), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5884) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5885), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5886), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5887), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5942), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5944), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5945) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5946), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5946) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5947), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5948), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5949), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5950), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5951), new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(5951) });

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_users_user_id",
                table: "portfolio_users",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolio_users");

            migrationBuilder.DropTable(
                name: "portfolio");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4865),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4335),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3824),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "3a2658a0-b474-462e-b86d-1b8613201d96");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "31aa1ce2-0175-4140-ba14-e2dd8d120dc9");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "92cee91a-789d-4cbf-8277-e4db49bf9f2e", new DateTime(2023, 7, 31, 19, 9, 51, 849, DateTimeKind.Local).AddTicks(9407), "AQAAAAEAACcQAAAAEB+zHxBGwA377IQcwq+n4kDm1K7sqvkqo7i0JodCmWhKe3iS0WLXhv4xa8P/abSA3Q==", "a00e90c6-fd99-48c2-b1bc-98ddccb1b448", new DateTime(2023, 7, 31, 19, 9, 51, 849, DateTimeKind.Local).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3162), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3166), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3167), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3167) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3168), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3169), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3169) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3170), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3171), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3171) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3172), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3172) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3247), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3249), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3250) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3250), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3251) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3251), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3252), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3253) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3253), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3254) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3254), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3255), new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3256) });
        }
    }
}

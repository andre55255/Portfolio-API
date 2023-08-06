using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class AddedColumnPortfolioSelectedAspnetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "stack",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3851),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stack",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3742),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3342),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3198),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(2672),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(2557),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8717),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8104),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(7958),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(5749),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(5509),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(2522),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(2364),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(1844),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(1673),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(685),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(331),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.AddColumn<int>(
                name: "portfolio_selected_id",
                table: "aspnetusers",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "feeb90ae-5423-4cf2-8f16-e0c98d6eebf5");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "afe243b9-b4e0-4b3b-b450-8769e9d65ff9");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "8fcc93ca-f202-438c-8bc3-7ade64d4814f", new DateTime(2023, 8, 6, 18, 40, 6, 301, DateTimeKind.Local).AddTicks(5350), "AQAAAAEAACcQAAAAEJM0UBX80vEoyVwdK9LE4MgcvAQkzAwB7WWmDypHOGWf5Msc+apR4AfqLzck2nt1Hg==", "5ee22ff0-dfa9-46c9-ad70-2cb7d1a3e4de", new DateTime(2023, 8, 6, 18, 40, 6, 301, DateTimeKind.Local).AddTicks(5361) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1221), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1230), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1231), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1232), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1233) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1233), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1234) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1235), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1235) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1236), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1237), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1237) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1299), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1301), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1303), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1303) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1304), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1304) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1305), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1307), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1307) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1308), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1309), new DateTime(2023, 8, 6, 18, 40, 6, 303, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.CreateIndex(
                name: "IX_aspnetusers_portfolio_selected_id",
                table: "aspnetusers",
                column: "portfolio_selected_id");

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_portfolio_portfolio_selected_id",
                table: "aspnetusers",
                column: "portfolio_selected_id",
                principalTable: "portfolio",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_portfolio_portfolio_selected_id",
                table: "aspnetusers");

            migrationBuilder.DropIndex(
                name: "IX_aspnetusers_portfolio_selected_id",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "portfolio_selected_id",
                table: "aspnetusers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "stack",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5225),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "stack",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5096),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3893),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 306, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9602),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9474),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8378),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6329),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6174),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(4027),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3862),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(2364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3352),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2897),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2749),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 6, 18, 40, 6, 305, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "abd0d308-0088-4437-ad44-5c98b2182f8d");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "266e01f9-3920-4f01-8cdc-c71e72fb0947");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "76bbb02c-28ed-446c-8ae4-7b63c1b1a7e8", new DateTime(2023, 8, 3, 18, 39, 45, 615, DateTimeKind.Local).AddTicks(7187), "AQAAAAEAACcQAAAAENbTh4eBC7pI219OOGE7/7WiPrVD6nbpe19DRuol7aTZEXOD4dWOGWnzxD3+9qaybg==", "57ec6ea8-327e-4077-acd4-500c1bc1ee68", new DateTime(2023, 8, 3, 18, 39, 45, 615, DateTimeKind.Local).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(1998), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(1999) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2001), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2001) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2002), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2003) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2003), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2005), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2005) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2006), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2006) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2007), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2007) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2008), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2008) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2068), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2071), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2071) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2072), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2073), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2073) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2074), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2075), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2076), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2076) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2077), new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2077) });
        }
    }
}

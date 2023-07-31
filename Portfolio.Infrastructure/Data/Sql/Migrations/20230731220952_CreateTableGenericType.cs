using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class CreateTableGenericType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "configuration",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "configuration",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DisabledAt",
                table: "configuration",
                newName: "disabled_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "configuration",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4335),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3824),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.CreateTable(
                name: "generic_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    value_bool = table.Column<bool>(type: "boolean", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4865)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4965)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generic_type", x => x.id);
                });

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

            migrationBuilder.InsertData(
                table: "generic_type",
                columns: new[] { "id", "created_at", "description", "disabled_at", "token", "updated_at", "value", "value_bool" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3247), "Status de jornada experiência de trabalho", null, "EXPERIENCE_WORK_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3247), "Integral", null },
                    { 2, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3249), "Status de jornada experiência de trabalho", null, "EXPERIENCE_WORK_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3250), "Meio período", null },
                    { 3, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3250), "Status de jornada experiência de trabalho", null, "EXPERIENCE_WORK_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3251), "Noturna", null },
                    { 4, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3251), "Status de jornada experiência de trabalho", null, "EXPERIENCE_WORK_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3252), "Turno", null },
                    { 5, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3252), "Status de faculdade/curso experiência de trabalho", null, "EDUCATION_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3253), "Em curso", null },
                    { 6, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3253), "Status de faculdade/curso experiência de trabalho", null, "EDUCATION_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3254), "Concluído", null },
                    { 7, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3254), "Status de faculdade/curso experiência de trabalho", null, "EDUCATION_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3255), "Incompleto", null },
                    { 8, new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3255), "Status de faculdade/curso experiência de trabalho", null, "EDUCATION_STATUS", new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3256), "Trancado", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "generic_type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "configuration",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "configuration",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "disabled_at",
                table: "configuration",
                newName: "DisabledAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "configuration",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(546),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(375),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9924),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9716),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 19, 9, 51, 851, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "089d8b3b-fda8-4220-92d7-5107f4f5c695");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "0a8c8843-4196-43e0-aa6d-51428d4e08d6");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "639fcc84-adc6-411b-b530-494e9d756ced", new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4860), "AQAAAAEAACcQAAAAEE3Ck8f2OaBIoWpV3GfvTxpoKkLSlbUGSfIWqJHC8EjkETel+wfydKSpsXPTD1fB0g==", "da2782ed-5c95-4bd6-bcb9-eda54ae1119f", new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8986), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8989), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994), new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994) });
        }
    }
}

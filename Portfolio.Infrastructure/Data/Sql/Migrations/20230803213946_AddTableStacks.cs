using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class AddTableStacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3893),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3765),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9602),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9474),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8378),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8194),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6329),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6174),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(4027),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3862),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3352),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2897),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2749),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.CreateTable(
                name: "stack",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    link = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    color = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5096)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(5225)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stack", x => x.id);
                    table.ForeignKey(
                        name: "FK_stack_portfolio_portfolio_id",
                        column: x => x.portfolio_id,
                        principalTable: "portfolio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_stack_portfolio_id",
                table: "stack",
                column: "portfolio_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stack");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8684),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "project",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8542),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7709),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 618, DateTimeKind.Local).AddTicks(3765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2957),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1802),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1667),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9997),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9834),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(6174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7493),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7028),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6887),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6275),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6126),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 39, 45, 617, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "c1673366-a329-46a6-9d87-d9aac990154a");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "e6a48f2f-aff7-47a8-8ca2-111cc96150a8");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "2b14b0be-9dcf-4dd2-ab96-c577c1572ed9", new DateTime(2023, 8, 1, 15, 35, 50, 366, DateTimeKind.Local).AddTicks(1332), "AQAAAAEAACcQAAAAEC8pHlTgpucGonLT9QEpRxmHNjD1JbuAj3Xbs0fvyvnQV4aOpFFrbTdALWA2EYgZ7g==", "b0f5f963-89f4-4121-bf15-5a8a842bcbd5", new DateTime(2023, 8, 1, 15, 35, 50, 366, DateTimeKind.Local).AddTicks(1343) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5424), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5428), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5429), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5430), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5430) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5431), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5431) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5432), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5433), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5434) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5434), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5435) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5487), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5488) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5489), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5490) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5491), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5492), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5492) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5493), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5494), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5495), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5496), new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(5496) });
        }
    }
}

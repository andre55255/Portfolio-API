using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class AddTableProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7836),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7709),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2957),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2847),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1802),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1667),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9997),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9834),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7630),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7493),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7028),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6887),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6275),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6126),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    description = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    techs = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    link_preview = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    link_view_code = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8542)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(8684)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                    table.ForeignKey(
                        name: "FK_project_portfolio_portfolio_id",
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

            migrationBuilder.CreateIndex(
                name: "IX_project_portfolio_id",
                table: "project",
                column: "portfolio_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2406),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(4019),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(3864),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2536),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 368, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9576),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_education",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9338),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5801),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "contact_me",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5575),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4782),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2592),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2026),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 15, 35, 50, 367, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "ec9c1018-4cb0-4248-9d0f-f985194151fe");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "15ec1aa4-7812-483e-887a-11572acd6460");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "0c487fe5-d8e4-4f7b-a95f-c33d6de85bfe", new DateTime(2023, 8, 1, 13, 55, 0, 932, DateTimeKind.Local).AddTicks(4126), "AQAAAAEAACcQAAAAEPI4nxmwU7mBk7pq9IhH+CbAN7QxHkZ4NrveU6ia12Wyaj6EMe75b+MUpQmYgjQLSA==", "9d80920b-5e41-4a93-86c5-741cfa7da238", new DateTime(2023, 8, 1, 13, 55, 0, 932, DateTimeKind.Local).AddTicks(4140) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(692), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(695) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(698), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(698) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(699), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(700), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(701) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(701), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(702), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(703) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(703), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(704), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(705) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(761), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(762) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(763), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(763) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(764), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(765) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(765), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(766) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(767), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(767) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(768), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(769), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(769) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(770), new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(770) });
        }
    }
}

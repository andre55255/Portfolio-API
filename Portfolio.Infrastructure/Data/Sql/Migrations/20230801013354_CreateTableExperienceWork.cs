using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class CreateTableExperienceWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3767),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2339));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9331),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6809),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6708),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6301),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6172),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.CreateTable(
                name: "ExperienceWorks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    office_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    company_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    company_localization = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    journey_work_status_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8686)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8891)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceWorks", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExperienceWorks_generic_type_journey_work_status_id",
                        column: x => x.journey_work_status_id,
                        principalTable: "generic_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ExperienceWorks_portfolio_portfolio_id",
                        column: x => x.portfolio_id,
                        principalTable: "portfolio",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "c11e1e24-f3f6-4c84-9a79-3d93b605a45c");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "44db4ce8-1e64-4579-9159-ee1f0347e009");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "eda06a1d-6d8e-4537-ba65-ea1fe1c531b8", new DateTime(2023, 7, 31, 22, 33, 53, 801, DateTimeKind.Local).AddTicks(1734), "AQAAAAEAACcQAAAAEGKw7+sJxUvN/kEcYdtAJu9fqqKxU8WBg78hhfahxrwVmqbX7JGpSG6PkX0IaZYwhg==", "0ffd1b88-c79d-471b-a4c3-6ecac3595f8d", new DateTime(2023, 7, 31, 22, 33, 53, 801, DateTimeKind.Local).AddTicks(1745) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5571), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5573) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5575), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5576), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5576) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5577), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5577) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5578), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5578) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5579), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5580), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5581), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5581) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5629), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5631), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5632), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5633), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5634) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5634), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5635) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5635), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5636), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5637) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5637), new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(5638) });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceWorks_journey_work_status_id",
                table: "ExperienceWorks",
                column: "journey_work_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceWorks_portfolio_id",
                table: "ExperienceWorks",
                column: "portfolio_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceWorks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2460),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 165, DateTimeKind.Local).AddTicks(2339),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7827),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7712),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(7201),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6788),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 21, 23, 35, 164, DateTimeKind.Local).AddTicks(6627),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6172));

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
        }
    }
}

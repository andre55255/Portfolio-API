using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class FixExperienceWorkTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceWorks_generic_type_journey_work_status_id",
                table: "ExperienceWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceWorks_portfolio_portfolio_id",
                table: "ExperienceWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceWorks",
                table: "ExperienceWorks");

            migrationBuilder.RenameTable(
                name: "ExperienceWorks",
                newName: "experience_work");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienceWorks_portfolio_id",
                table: "experience_work",
                newName: "IX_experience_work_portfolio_id");

            migrationBuilder.RenameIndex(
                name: "IX_ExperienceWorks_journey_work_status_id",
                table: "experience_work",
                newName: "IX_experience_work_journey_work_status_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(8106),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(7981),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3368),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(1019),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(548),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(430),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2973),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2823),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.AddPrimaryKey(
                name: "PK_experience_work",
                table: "experience_work",
                column: "id");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 1,
                column: "concurrency_stamp",
                value: "483ca20c-e085-4ff7-872c-677e253a3cc3");

            migrationBuilder.UpdateData(
                table: "aspnetroles",
                keyColumn: "id",
                keyValue: 2,
                column: "concurrency_stamp",
                value: "bf12fabd-7ef0-4cdf-9d2e-6b074d312e5a");

            migrationBuilder.UpdateData(
                table: "aspnetusers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "concurrency_stamp", "created_at", "password_hash", "security_stamp", "updated_at" },
                values: new object[] { "047c1b34-ec33-453b-910c-9ecd12be5874", new DateTime(2023, 7, 31, 22, 35, 3, 319, DateTimeKind.Local).AddTicks(5064), "AQAAAAEAACcQAAAAEN/oK1vjyJQ+q9fWWCKxUJq0Mz3ghjFgRThjRUfRGCryNXIzo6wn1ZRRE1gDa4DiCQ==", "c7f8c3c5-4dfd-47a9-aab5-d3f293460941", new DateTime(2023, 7, 31, 22, 35, 3, 319, DateTimeKind.Local).AddTicks(5075) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9825), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9827) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9829), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9830) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9830), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9831), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9832), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9833) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9833), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9834), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "configuration",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9835), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9884), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9886), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9887), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9888), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9888) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9889), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9890), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9891), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "generic_type",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9892), new DateTime(2023, 7, 31, 22, 35, 3, 320, DateTimeKind.Local).AddTicks(9892) });

            migrationBuilder.AddForeignKey(
                name: "FK_experience_work_generic_type_journey_work_status_id",
                table: "experience_work",
                column: "journey_work_status_id",
                principalTable: "generic_type",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_experience_work_portfolio_portfolio_id",
                table: "experience_work",
                column: "portfolio_id",
                principalTable: "portfolio",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_experience_work_generic_type_journey_work_status_id",
                table: "experience_work");

            migrationBuilder.DropForeignKey(
                name: "FK_experience_work_portfolio_portfolio_id",
                table: "experience_work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_experience_work",
                table: "experience_work");

            migrationBuilder.RenameTable(
                name: "experience_work",
                newName: "ExperienceWorks");

            migrationBuilder.RenameIndex(
                name: "IX_experience_work_portfolio_id",
                table: "ExperienceWorks",
                newName: "IX_ExperienceWorks_portfolio_id");

            migrationBuilder.RenameIndex(
                name: "IX_experience_work_journey_work_status_id",
                table: "ExperienceWorks",
                newName: "IX_ExperienceWorks_journey_work_status_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3899),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 803, DateTimeKind.Local).AddTicks(3767),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(9331),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6809),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6708),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6301),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(6172),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "ExperienceWorks",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8891),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "ExperienceWorks",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 33, 53, 802, DateTimeKind.Local).AddTicks(8686),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceWorks",
                table: "ExperienceWorks",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceWorks_generic_type_journey_work_status_id",
                table: "ExperienceWorks",
                column: "journey_work_status_id",
                principalTable: "generic_type",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceWorks_portfolio_portfolio_id",
                table: "ExperienceWorks",
                column: "portfolio_id",
                principalTable: "portfolio",
                principalColumn: "id");
        }
    }
}

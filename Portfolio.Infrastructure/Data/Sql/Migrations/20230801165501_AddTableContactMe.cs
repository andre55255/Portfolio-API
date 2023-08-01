using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class AddTableContactMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2406),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(4019),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(3864),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2536),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4782),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4463),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2592),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2026),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.CreateTable(
                name: "contact_me",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    contact = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    message = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5575)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(5801)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_me", x => x.id);
                    table.ForeignKey(
                        name: "FK_contact_me_portfolio_portfolio_id",
                        column: x => x.portfolio_id,
                        principalTable: "portfolio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experience_education",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    education_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    instituition_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    instituition_localization = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    portfolio_id = table.Column<int>(type: "integer", nullable: false),
                    journey_work_status_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9338)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(9576)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experience_education", x => x.id);
                    table.ForeignKey(
                        name: "FK_experience_education_generic_type_journey_work_status_id",
                        column: x => x.journey_work_status_id,
                        principalTable: "generic_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_experience_education_portfolio_portfolio_id",
                        column: x => x.portfolio_id,
                        principalTable: "portfolio",
                        principalColumn: "id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_contact_me_portfolio_id",
                table: "contact_me",
                column: "portfolio_id");

            migrationBuilder.CreateIndex(
                name: "IX_experience_education_journey_work_status_id",
                table: "experience_education",
                column: "journey_work_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_experience_education_portfolio_id",
                table: "experience_education",
                column: "portfolio_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_me");

            migrationBuilder.DropTable(
                name: "experience_education");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(8106),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "portfolio",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(7981),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 936, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "generic_type",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(3368),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2973),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "experience_work",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(2823),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 935, DateTimeKind.Local).AddTicks(2313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(1019),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "configuration",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(920),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(548),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "aspnetusers",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 31, 22, 35, 3, 321, DateTimeKind.Local).AddTicks(430),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2023, 8, 1, 13, 55, 0, 934, DateTimeKind.Local).AddTicks(2026));

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
        }
    }
}

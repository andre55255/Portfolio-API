using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aspnetroles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: false),
                    last_name = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9716)),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9924)),
                    disabled_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: false),
                    security_stamp = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    normalized_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    normalized_username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    value = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    extra = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(375)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValue: new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(546)),
                    DisabledAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetrole_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: false),
                    claim_value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetrole_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetrole_claims_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuser_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: false),
                    claim_value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuser_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_aspnetuser_claims_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuser_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuser_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_aspnetuser_logins_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuser_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuser_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_aspnetuser_roles_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aspnetuser_roles_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuser_tokens",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspnetuser_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_aspnetuser_tokens_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "aspnetroles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { 1, "089d8b3b-fda8-4220-92d7-5107f4f5c695", "Admin", "ADMIN" },
                    { 2, "0a8c8843-4196-43e0-aa6d-51428d4e08d6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "aspnetusers",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "created_at", "disabled_at", "email", "email_confirmed", "name", "last_name", "lockout_enabled", "lockout_end", "normalized_email", "normalized_username", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "updated_at", "username" },
                values: new object[] { 1, 0, "639fcc84-adc6-411b-b530-494e9d756ced", new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4860), null, "andre_luiz.b5@outlook.com", true, "Admin", "ALB Portfolio", false, null, "ANDRE_LUIZ.B5@OUTLOOK.COM", "ADMIN", "AQAAAAEAACcQAAAAEE3Ck8f2OaBIoWpV3GfvTxpoKkLSlbUGSfIWqJHC8EjkETel+wfydKSpsXPTD1fB0g==", "31 995600166", false, "da2782ed-5c95-4bd6-bcb9-eda54ae1119f", false, new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4870), "admin" });

            migrationBuilder.InsertData(
                table: "configuration",
                columns: new[] { "Id", "CreatedAt", "DisabledAt", "extra", "token", "UpdatedAt", "value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983), null, null, "EMAIL_LOGIN", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983), "todo" },
                    { 2, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8986), null, null, "EMAIL_PASSWORD", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8987), "todo" },
                    { 3, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988), null, null, "EMAIL_PORT", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988), "todo" },
                    { 4, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8989), null, null, "EMAIL_SMTP", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8990), "todo" },
                    { 5, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991), null, null, "ATTEMPTS_LOGIN_ERROR", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991), "todo" },
                    { 6, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992), null, null, "ATTEMPTS_LOGIN_ERROR_DAYS_BLOCK", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992), "todo" },
                    { 7, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993), null, null, "MINUTES_EXPIRES_ACCESS_TOKEN", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993), "todo" },
                    { 8, new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994), null, null, "MINUTES_EXPIRES_REFRESH_TOKEN", new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994), "todo" }
                });

            migrationBuilder.InsertData(
                table: "aspnetuser_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_aspnetrole_claims_role_id",
                table: "aspnetrole_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "aspnetroles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuser_claims_user_id",
                table: "aspnetuser_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuser_logins_user_id",
                table: "aspnetuser_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_aspnetuser_roles_role_id",
                table: "aspnetuser_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "aspnetusers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "aspnetusers",
                column: "normalized_username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aspnetrole_claims");

            migrationBuilder.DropTable(
                name: "aspnetuser_claims");

            migrationBuilder.DropTable(
                name: "aspnetuser_logins");

            migrationBuilder.DropTable(
                name: "aspnetuser_roles");

            migrationBuilder.DropTable(
                name: "aspnetuser_tokens");

            migrationBuilder.DropTable(
                name: "configuration");

            migrationBuilder.DropTable(
                name: "aspnetroles");

            migrationBuilder.DropTable(
                name: "aspnetusers");
        }
    }
}

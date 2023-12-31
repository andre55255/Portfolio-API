﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portfolio.Infrastructure.Data.Sql.Context;

#nullable disable

namespace Portfolio.Infrastructure.Data.Sql.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20230731190146_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("aspnetroles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "089d8b3b-fda8-4220-92d7-5107f4f5c695",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "0a8c8843-4196-43e0-aa6d-51428d4e08d6",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("aspnetrole_claims", (string)null);
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValue(new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9716))
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DisabledAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("disabled_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("character varying(125)")
                        .HasColumnName("name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("character varying(125)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("normalized_username");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValue(new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(9924))
                        .HasColumnName("updated_at");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("aspnetusers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "639fcc84-adc6-411b-b530-494e9d756ced",
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4860),
                            Email = "andre_luiz.b5@outlook.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "ALB Portfolio",
                            LockoutEnabled = false,
                            NormalizedEmail = "ANDRE_LUIZ.B5@OUTLOOK.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEE3Ck8f2OaBIoWpV3GfvTxpoKkLSlbUGSfIWqJHC8EjkETel+wfydKSpsXPTD1fB0g==",
                            PhoneNumber = "31 995600166",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da2782ed-5c95-4bd6-bcb9-eda54ae1119f",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 579, DateTimeKind.Local).AddTicks(4870),
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("aspnetuser_claims", (string)null);
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("aspnetuser_logins", (string)null);
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("aspnetuser_roles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserToken", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("aspnetuser_tokens", (string)null);
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Sql.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValue(new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(375));

                    b.Property<DateTime?>("DisabledAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Extra")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("extra");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("token");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValue(new DateTime(2023, 7, 31, 16, 1, 46, 581, DateTimeKind.Local).AddTicks(546));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("configuration");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983),
                            Token = "EMAIL_LOGIN",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8983),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8986),
                            Token = "EMAIL_PASSWORD",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8987),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988),
                            Token = "EMAIL_PORT",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8988),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8989),
                            Token = "EMAIL_SMTP",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8990),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991),
                            Token = "ATTEMPTS_LOGIN_ERROR",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8991),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992),
                            Token = "ATTEMPTS_LOGIN_ERROR_DAYS_BLOCK",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8992),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993),
                            Token = "MINUTES_EXPIRES_ACCESS_TOKEN",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8993),
                            Value = "todo"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994),
                            Token = "MINUTES_EXPIRES_REFRESH_TOKEN",
                            UpdatedAt = new DateTime(2023, 7, 31, 16, 1, 46, 580, DateTimeKind.Local).AddTicks(8994),
                            Value = "todo"
                        });
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetRoleClaim", b =>
                {
                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserClaim", b =>
                {
                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserLogin", b =>
                {
                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserRole", b =>
                {
                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Core.Entities.Identity.AspNetUserToken", b =>
                {
                    b.HasOne("Portfolio.Core.Entities.Identity.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

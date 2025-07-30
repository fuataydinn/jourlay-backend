using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jourlay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editedBaseClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "base_created_date",
                table: "PhoneNumberEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "PhoneNumberEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "PhoneNumberEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "base_created_date",
                table: "OfficeInfos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "OfficeInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "OfficeInfos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "OfficeInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "base_created_date",
                table: "EmailAddressEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "EmailAddressEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "EmailAddressEntity",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "base_created_date",
                table: "ContactUses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "ContactUses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "ContactUses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "ContactUses",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "base_created_date",
                table: "PhoneNumberEntity");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "PhoneNumberEntity");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "PhoneNumberEntity");

            migrationBuilder.DropColumn(
                name: "base_created_date",
                table: "OfficeInfos");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "OfficeInfos");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "OfficeInfos");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "OfficeInfos");

            migrationBuilder.DropColumn(
                name: "base_created_date",
                table: "EmailAddressEntity");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "EmailAddressEntity");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "EmailAddressEntity");

            migrationBuilder.DropColumn(
                name: "base_created_date",
                table: "ContactUses");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "ContactUses");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "ContactUses");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "ContactUses");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jourlay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class firtMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactUses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    facebook_link = table.Column<string>(type: "text", nullable: false),
                    instagram_link = table.Column<string>(type: "text", nullable: false),
                    youtube_link = table.Column<string>(type: "text", nullable: false),
                    twitter_link = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeInfos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_us_id = table.Column<Guid>(type: "uuid", nullable: false),
                    opening_hours_weekday = table.Column<string>(type: "text", nullable: false),
                    opening_hours_weekend = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfficeInfos_ContactUses_contact_us_id",
                        column: x => x.contact_us_id,
                        principalTable: "ContactUses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddressEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    email_type = table.Column<int>(type: "integer", nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddressEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailAddressEntity_OfficeInfos_office_info_id",
                        column: x => x.office_info_id,
                        principalTable: "OfficeInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    office_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    phone_type = table.Column<int>(type: "integer", nullable: false),
                    country_code = table.Column<string>(type: "text", nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_PhoneNumberEntity_OfficeInfos_office_info_id",
                        column: x => x.office_info_id,
                        principalTable: "OfficeInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddressEntity_office_info_id",
                table: "EmailAddressEntity",
                column: "office_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeInfos_contact_us_id",
                table: "OfficeInfos",
                column: "contact_us_id");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumberEntity_office_info_id",
                table: "PhoneNumberEntity",
                column: "office_info_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAddressEntity");

            migrationBuilder.DropTable(
                name: "PhoneNumberEntity");

            migrationBuilder.DropTable(
                name: "OfficeInfos");

            migrationBuilder.DropTable(
                name: "ContactUses");
        }
    }
}

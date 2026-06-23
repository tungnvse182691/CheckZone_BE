using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckZone.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMySQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlogArticles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "Cảnh báo phổ thông")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    slug = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Đã đăng")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogArticles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LegitProfiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    score = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    img = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, defaultValue: "https://images.domain.com/default-avatar.png")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    desc = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telegram = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "@verified_merchant")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    insurance = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 0m),
                    success_trans = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    join_date = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    business_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegitProfiles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PolicyArticles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_updated = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    content = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyArticles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScamReports",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bank_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    account_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    desc = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 0m),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Đang chờ duyệt")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    victim = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, defaultValue: "Ẩn danh")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tags = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    facebook = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    images = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScamReports", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SystemConfigurations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    require_evidence = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    auto_approve = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    min_insurance = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false, defaultValue: 10000000.00m),
                    admin_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, defaultValue: "Ban điều hành Check Zone")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    admin_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, defaultValue: "support@checkzone.vn")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telegram_bot_token = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigurations", x => x.id);
                    table.CheckConstraint("CK_SystemConfiguration_Id", "id = 1");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlogArticles_slug",
                table: "BlogArticles",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScamReports_name",
                table: "ScamReports",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogArticles");

            migrationBuilder.DropTable(
                name: "LegitProfiles");

            migrationBuilder.DropTable(
                name: "PolicyArticles");

            migrationBuilder.DropTable(
                name: "ScamReports");

            migrationBuilder.DropTable(
                name: "SystemConfigurations");
        }
    }
}

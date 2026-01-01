using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelowFlow_api.Migrations
{
    /// <inheritdoc />
    public partial class AddMembersAndDocumentTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyPositions_Companys_CompanyId",
                table: "CompanyPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_CompanyPositions_CompanyPositionId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Companys_CompanyId",
                table: "Leads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyPositions",
                table: "CompanyPositions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Leads",
                newName: "leads");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "companies");

            migrationBuilder.RenameTable(
                name: "CompanyPositions",
                newName: "company_positions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "users",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "users",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "users",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "users",
                newName: "profession");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Niss",
                table: "users",
                newName: "niss");

            migrationBuilder.RenameColumn(
                name: "Nif",
                table: "users",
                newName: "nif");

            migrationBuilder.RenameColumn(
                name: "Naturalidad",
                table: "users",
                newName: "naturalidad");

            migrationBuilder.RenameColumn(
                name: "Nacionalidad",
                table: "users",
                newName: "nacionalidad");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "users",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "users",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "users",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "users",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "VisaStartDate",
                table: "users",
                newName: "visa_start_date");

            migrationBuilder.RenameColumn(
                name: "VisaEndDate",
                table: "users",
                newName: "visa_end_date");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "users",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StreetAddressNumber",
                table: "users",
                newName: "street_address_number");

            migrationBuilder.RenameColumn(
                name: "StreetAddressComplement",
                table: "users",
                newName: "street_address_complement");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "users",
                newName: "street_address");

            migrationBuilder.RenameColumn(
                name: "ResetPassword",
                table: "users",
                newName: "reset_password");

            migrationBuilder.RenameColumn(
                name: "RegisterNumber",
                table: "users",
                newName: "register_number");

            migrationBuilder.RenameColumn(
                name: "PassportNumber",
                table: "users",
                newName: "passport_number");

            migrationBuilder.RenameColumn(
                name: "PassportExpires",
                table: "users",
                newName: "passport_expires");

            migrationBuilder.RenameColumn(
                name: "PassportCreated",
                table: "users",
                newName: "passport_created");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "users",
                newName: "last_login");

            migrationBuilder.RenameColumn(
                name: "HasVisa",
                table: "users",
                newName: "has_visa");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "users",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AnotherInformation",
                table: "users",
                newName: "another_information");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "leads",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "leads",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "leads",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "leads",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "leads",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "leads",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "leads",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "leads",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "leads",
                newName: "zip_code");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "leads",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "leads",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StreetAddressNumber",
                table: "leads",
                newName: "street_address_number");

            migrationBuilder.RenameColumn(
                name: "StreetAddressComplement",
                table: "leads",
                newName: "street_address_complement");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "leads",
                newName: "street_address");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "leads",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "leads",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CompanyPositionId",
                table: "leads",
                newName: "company_position_id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "leads",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_CompanyPositionId",
                table: "leads",
                newName: "ix_leads_company_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_CompanyId",
                table: "leads",
                newName: "ix_leads_company_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "companies",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "companies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "companies",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "companies",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "FinancialCode",
                table: "companies",
                newName: "financial_code");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "companies",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "companies",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "company_positions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "company_positions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "company_positions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "company_positions",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "company_positions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "company_positions",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyPositions_CompanyId",
                table: "company_positions",
                newName: "ix_company_positions_company_id");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "salary",
                table: "users",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "profession",
                table: "users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "users",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "niss",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nif",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "naturalidad",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nacionalidad",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address_number",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address_complement",
                table: "users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address",
                table: "users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "reset_password",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "register_number",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "passport_number",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "has_visa",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "state",
                table: "leads",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "leads",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "currency",
                table: "leads",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "EUR",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "leads",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "leads",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount",
                table: "leads",
                type: "numeric(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "zip_code",
                table: "leads",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address_number",
                table: "leads",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address_complement",
                table: "leads",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street_address",
                table: "leads",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "companies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "financial_code",
                table: "companies",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "company_positions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_leads",
                table: "leads",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_company_positions",
                table: "company_positions",
                column: "id");

            migrationBuilder.CreateTable(
                name: "company_position_document_templates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_position_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    document_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_required = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    target_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_position_document_templates", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_positions_document_templates",
                        column: x => x.company_position_id,
                        principalTable: "company_positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company_users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_company_users_companies",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_company_users_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lead_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lead_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lead_members", x => x.id);
                    table.ForeignKey(
                        name: "fk_lead_members_leads",
                        column: x => x.lead_id,
                        principalTable: "leads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lead_members_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lead_documents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lead_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lead_member_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    document_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    document_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    target_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lead_documents", x => x.id);
                    table.ForeignKey(
                        name: "fk_lead_documents_lead_members",
                        column: x => x.lead_member_id,
                        principalTable: "lead_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lead_documents_leads",
                        column: x => x.lead_id,
                        principalTable: "leads",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_deleted_at",
                table: "users",
                column: "deleted_at");

            // Criar índice único apenas se não houver duplicados
            // Se houver duplicados, será necessário limpar os dados primeiro
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 
                        FROM users 
                        GROUP BY email 
                        HAVING COUNT(*) > 1
                    ) THEN
                        CREATE UNIQUE INDEX ix_users_email ON users(email);
                    END IF;
                END $$;
            ");

            migrationBuilder.CreateIndex(
                name: "ix_users_nif",
                table: "users",
                column: "nif");

            migrationBuilder.CreateIndex(
                name: "ix_leads_deleted_at",
                table: "leads",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_leads_user_id",
                table: "leads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_deleted_at",
                table: "companies",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_companies_financial_code",
                table: "companies",
                column: "financial_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_companies_user_id",
                table: "companies",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_positions_deleted_at",
                table: "company_positions",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_company_position_document_templates_company_position_id",
                table: "company_position_document_templates",
                column: "company_position_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_position_document_templates_deleted_at",
                table: "company_position_document_templates",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_company_users_company_id",
                table: "company_users",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_company_users_company_user_unique",
                table: "company_users",
                columns: new[] { "company_id", "user_id" },
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ix_company_users_deleted_at",
                table: "company_users",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_company_users_user_id",
                table: "company_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_documents_deleted_at",
                table: "lead_documents",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_lead_documents_lead_id",
                table: "lead_documents",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_documents_lead_member_id",
                table: "lead_documents",
                column: "lead_member_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_members_deleted_at",
                table: "lead_members",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_lead_members_lead_id",
                table: "lead_members",
                column: "lead_id");

            migrationBuilder.CreateIndex(
                name: "ix_lead_members_user_id",
                table: "lead_members",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_company_positions_companies",
                table: "company_positions",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leads_companies",
                table: "leads",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_leads_company_positions",
                table: "leads",
                column: "company_position_id",
                principalTable: "company_positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_company_positions_companies",
                table: "company_positions");

            migrationBuilder.DropForeignKey(
                name: "fk_leads_companies",
                table: "leads");

            migrationBuilder.DropForeignKey(
                name: "fk_leads_company_positions",
                table: "leads");

            migrationBuilder.DropTable(
                name: "company_position_document_templates");

            migrationBuilder.DropTable(
                name: "company_users");

            migrationBuilder.DropTable(
                name: "lead_documents");

            migrationBuilder.DropTable(
                name: "lead_members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_deleted_at",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_nif",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_leads",
                table: "leads");

            migrationBuilder.DropIndex(
                name: "ix_leads_deleted_at",
                table: "leads");

            migrationBuilder.DropIndex(
                name: "ix_leads_user_id",
                table: "leads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company_positions",
                table: "company_positions");

            migrationBuilder.DropIndex(
                name: "ix_company_positions_deleted_at",
                table: "company_positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "ix_companies_deleted_at",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "ix_companies_financial_code",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "ix_companies_user_id",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "leads",
                newName: "Leads");

            migrationBuilder.RenameTable(
                name: "company_positions",
                newName: "CompanyPositions");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Companys");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Users",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Users",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Users",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "profession",
                table: "Users",
                newName: "Profession");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "niss",
                table: "Users",
                newName: "Niss");

            migrationBuilder.RenameColumn(
                name: "nif",
                table: "Users",
                newName: "Nif");

            migrationBuilder.RenameColumn(
                name: "naturalidad",
                table: "Users",
                newName: "Naturalidad");

            migrationBuilder.RenameColumn(
                name: "nacionalidad",
                table: "Users",
                newName: "Nacionalidad");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Users",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "Users",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "visa_start_date",
                table: "Users",
                newName: "VisaStartDate");

            migrationBuilder.RenameColumn(
                name: "visa_end_date",
                table: "Users",
                newName: "VisaEndDate");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Users",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "street_address_number",
                table: "Users",
                newName: "StreetAddressNumber");

            migrationBuilder.RenameColumn(
                name: "street_address_complement",
                table: "Users",
                newName: "StreetAddressComplement");

            migrationBuilder.RenameColumn(
                name: "street_address",
                table: "Users",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "reset_password",
                table: "Users",
                newName: "ResetPassword");

            migrationBuilder.RenameColumn(
                name: "register_number",
                table: "Users",
                newName: "RegisterNumber");

            migrationBuilder.RenameColumn(
                name: "passport_number",
                table: "Users",
                newName: "PassportNumber");

            migrationBuilder.RenameColumn(
                name: "passport_expires",
                table: "Users",
                newName: "PassportExpires");

            migrationBuilder.RenameColumn(
                name: "passport_created",
                table: "Users",
                newName: "PassportCreated");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "last_login",
                table: "Users",
                newName: "LastLogin");

            migrationBuilder.RenameColumn(
                name: "has_visa",
                table: "Users",
                newName: "HasVisa");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Users",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Users",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "another_information",
                table: "Users",
                newName: "AnotherInformation");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Leads",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Leads",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Leads",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "Leads",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "Leads",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Leads",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Leads",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Leads",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "zip_code",
                table: "Leads",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Leads",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Leads",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "street_address_number",
                table: "Leads",
                newName: "StreetAddressNumber");

            migrationBuilder.RenameColumn(
                name: "street_address_complement",
                table: "Leads",
                newName: "StreetAddressComplement");

            migrationBuilder.RenameColumn(
                name: "street_address",
                table: "Leads",
                newName: "StreetAddress");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Leads",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Leads",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "company_position_id",
                table: "Leads",
                newName: "CompanyPositionId");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "Leads",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "ix_leads_company_position_id",
                table: "Leads",
                newName: "IX_Leads_CompanyPositionId");

            migrationBuilder.RenameIndex(
                name: "ix_leads_company_id",
                table: "Leads",
                newName: "IX_Leads_CompanyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "CompanyPositions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CompanyPositions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "CompanyPositions",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "CompanyPositions",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "CompanyPositions",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "CompanyPositions",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "ix_company_positions_company_id",
                table: "CompanyPositions",
                newName: "IX_CompanyPositions_CompanyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companys",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Companys",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companys",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Companys",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Companys",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "financial_code",
                table: "Companys",
                newName: "FinancialCode");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "Companys",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Companys",
                newName: "Created");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Users",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Profession",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Niss",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nif",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naturalidad",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nacionalidad",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddressNumber",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddressComplement",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ResetPassword",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "RegisterNumber",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNumber",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "HasVisa",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leads",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Leads",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldDefaultValue: "EUR");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Leads",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddressNumber",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddressComplement",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "Leads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompanyPositions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companys",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FinancialCode",
                table: "Companys",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyPositions",
                table: "CompanyPositions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyPositions_Companys_CompanyId",
                table: "CompanyPositions",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_CompanyPositions_CompanyPositionId",
                table: "Leads",
                column: "CompanyPositionId",
                principalTable: "CompanyPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Companys_CompanyId",
                table: "Leads",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

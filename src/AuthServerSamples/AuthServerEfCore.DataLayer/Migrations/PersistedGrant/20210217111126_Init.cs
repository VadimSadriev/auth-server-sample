﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthServerEfCore.DataLayer.Migrations.PersistedGrant
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "persisted_grant");

            migrationBuilder.CreateTable(
                name: "device_flow_codes",
                schema: "persisted_grant",
                columns: table => new
                {
                    user_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    device_code = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creation_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_codes", x => x.user_code);
                });

            migrationBuilder.CreateTable(
                name: "persisted_grants",
                schema: "persisted_grant",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    subject_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    session_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    client_id = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creation_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    consumed_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    data = table.Column<string>(type: "character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
                });

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_device_code",
                schema: "persisted_grant",
                table: "device_flow_codes",
                column: "device_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_expiration",
                schema: "persisted_grant",
                table: "device_flow_codes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_expiration",
                schema: "persisted_grant",
                table: "persisted_grants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_client_id_type",
                schema: "persisted_grant",
                table: "persisted_grants",
                columns: new[] { "subject_id", "client_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_session_id_type",
                schema: "persisted_grant",
                table: "persisted_grants",
                columns: new[] { "subject_id", "session_id", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_flow_codes",
                schema: "persisted_grant");

            migrationBuilder.DropTable(
                name: "persisted_grants",
                schema: "persisted_grant");
        }
    }
}

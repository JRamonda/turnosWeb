using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    starttime = table.Column<TimeSpan>(name: "start_time", type: "time", nullable: false),
                    endtime = table.Column<TimeSpan>(name: "end_time", type: "time", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_turns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Docs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_type_docs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idprofile = table.Column<int>(name: "id_profile", type: "int", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_profiles",
                        column: x => x.idprofile,
                        principalTable: "Profiles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numdoc = table.Column<string>(name: "num_doc", type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    idtypedoc = table.Column<int>(name: "id_type_doc", type: "int", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    numphone = table.Column<string>(name: "num_phone", type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.id);
                    table.ForeignKey(
                        name: "fk_clients_type_docs",
                        column: x => x.idtypedoc,
                        principalTable: "Type_Docs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Users_X_Services",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users_x_services", x => new { x.IdUser, x.IdService });
                    table.ForeignKey(
                        name: "fk_users_x_services_services",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_x_services_users",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Clients_X_Turns_X_Users",
                columns: table => new
                {
                    idclient = table.Column<int>(name: "id_client", type: "int", nullable: false),
                    idturn = table.Column<int>(name: "id_turn", type: "int", nullable: false),
                    iduser = table.Column<int>(name: "id_user", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients_x_turns_x_users", x => new { x.idclient, x.idturn, x.iduser });
                    table.ForeignKey(
                        name: "fk_clients_x_turns_x_users_clients",
                        column: x => x.idclient,
                        principalTable: "Clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_clients_x_turns_x_users_turns",
                        column: x => x.idturn,
                        principalTable: "Turns",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_clients_x_turns_x_users_users",
                        column: x => x.iduser,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_id_type_doc",
                table: "Clients",
                column: "id_type_doc");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_X_Turns_X_Users_id_turn",
                table: "Clients_X_Turns_X_Users",
                column: "id_turn");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_X_Turns_X_Users_id_user",
                table: "Clients_X_Turns_X_Users",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_profile",
                table: "Users",
                column: "id_profile");

            migrationBuilder.CreateIndex(
                name: "IX_Users_X_Services_IdService",
                table: "Users_X_Services",
                column: "IdService");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients_X_Turns_X_Users");

            migrationBuilder.DropTable(
                name: "Users_X_Services");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Turns");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Type_Docs");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}

using System;
using System.Net;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Inventory_Atlas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitInventoryAtlas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Documents");

            migrationBuilder.EnsureSchema(
                name: "Technics");

            migrationBuilder.EnsureSchema(
                name: "Dictionaries");

            migrationBuilder.EnsureSchema(
                name: "Employees");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "Services");

            migrationBuilder.EnsureSchema(
                name: "Audit");

            migrationBuilder.EnsureSchema(
                name: "Consumables");

            migrationBuilder.CreateTable(
                name: "CPUs",
                schema: "Dictionaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    manufacturer = table.Column<string>(type: "text", nullable: true),
                    core_count = table.Column<short>(type: "smallint", nullable: true),
                    thread_count = table.Column<short>(type: "smallint", nullable: true),
                    сlock = table.Column<double>(type: "double precision", nullable: true),
                    socket = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterials",
                schema: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureTypes",
                schema: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                schema: "Dictionaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vendor = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: false),
                    memory_size = table.Column<int>(type: "integer", nullable: false),
                    memory_type = table.Column<int>(type: "integer", nullable: false),
                    vga_port = table.Column<short>(type: "smallint", nullable: true),
                    hdmi_port = table.Column<short>(type: "smallint", nullable: true),
                    display_port = table.Column<short>(type: "smallint", nullable: true),
                    dvi_port = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCategorys",
                schema: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    custom_fields = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategorys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IpAddresses",
                schema: "Dictionaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ip = table.Column<IPAddress>(type: "inet", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpAddresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MoBos",
                schema: "Dictionaries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vendor = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    socket = table.Column<string>(type: "text", nullable: true),
                    chipset = table.Column<string>(type: "text", nullable: true),
                    form_factor = table.Column<int>(type: "integer", nullable: false),
                    ram_slots = table.Column<short>(type: "smallint", nullable: true),
                    max_ram_gb = table.Column<short>(type: "smallint", nullable: true),
                    pcie_slots = table.Column<short>(type: "smallint", nullable: true),
                    m2_slots = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoBos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrinterCartridges",
                schema: "Consumables",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinterCartridges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_system = table.Column<bool>(type: "boolean", nullable: false),
                    permissions = table.Column<string>(type: "jsonb", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                schema: "Audit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffDocuments",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reason = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    document_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffDocuments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    patronymic = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    department_id = table.Column<int>(type: "integer", nullable: true),
                    position = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    is_responsible = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "Employees",
                        principalTable: "Departments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LogEntrys",
                schema: "Audit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    action_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_session = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<int>(type: "integer", nullable: false),
                    entity_name = table.Column<string>(type: "text", nullable: true),
                    entity_id = table.Column<int>(type: "integer", nullable: true),
                    changes = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntrys", x => x.id);
                    table.ForeignKey(
                        name: "FK_LogEntrys_UserSessions_user_session",
                        column: x => x.user_session,
                        principalSchema: "Audit",
                        principalTable: "UserSessions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutDocuments",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    document_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_CheckoutDocuments_Employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriallyResponsibles",
                schema: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriallyResponsibles", x => x.id);
                    table.ForeignKey(
                        name: "FK_MateriallyResponsibles_Employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnDocuments",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    document_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReturnDocuments_Employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferDocuments",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    from_employee_id = table.Column<int>(type: "integer", nullable: false),
                    to_employee_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    document_number = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    document_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransferDocuments_Employees_from_employee_id",
                        column: x => x.from_employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferDocuments_Employees_to_employee_id",
                        column: x => x.to_employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                schema: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    employee_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "Users",
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workplaces",
                schema: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    employee_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.id);
                    table.ForeignKey(
                        name: "FK_Workplaces_Employees_employee_id",
                        column: x => x.employee_id,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                schema: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    inventory_number = table.Column<long>(type: "bigint", nullable: true),
                    registry_number = table.Column<string>(type: "text", nullable: true),
                    responsible_id = table.Column<int>(type: "integer", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_MateriallyResponsibles_responsible_id",
                        column: x => x.responsible_id,
                        principalSchema: "Employees",
                        principalTable: "MateriallyResponsibles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CheckoutDocumentItems",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutDocumentItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CheckoutDocumentItems_CheckoutDocuments_document_id",
                        column: x => x.document_id,
                        principalSchema: "Documents",
                        principalTable: "CheckoutDocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutDocumentItems_InventoryItems_item_id",
                        column: x => x.item_id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipments_InventoryItems_id",
                        column: x => x.id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                schema: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    favourited_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favourite_InventoryItems_item_id",
                        column: x => x.item_id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourite_UsersProfiles_user_id",
                        column: x => x.user_id,
                        principalSchema: "Users",
                        principalTable: "UsersProfiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                schema: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    dimensions = table.Column<string>(type: "text", nullable: true),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    orientation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Furnitures_FurnitureTypes_type",
                        column: x => x.type,
                        principalSchema: "Services",
                        principalTable: "FurnitureTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furnitures_InventoryItems_id",
                        column: x => x.id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericInventoryItems",
                schema: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    properties = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericInventoryItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_GenericInventoryItems_InventoryCategorys_category_id",
                        column: x => x.category_id,
                        principalSchema: "Services",
                        principalTable: "InventoryCategorys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericInventoryItems_InventoryItems_id",
                        column: x => x.id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryPhotos",
                schema: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inventory_item_id = table.Column<int>(type: "integer", nullable: false),
                    photo_path = table.Column<string>(type: "text", nullable: false),
                    is_primary = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryPhotos", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventoryPhotos_InventoryItems_inventory_item_id",
                        column: x => x.inventory_item_id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetworkDevices",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    mac_address = table.Column<string>(type: "text", nullable: true),
                    dhcp_range = table.Column<string>(type: "text", nullable: true),
                    admin_login = table.Column<string>(type: "text", nullable: true),
                    admin_password = table.Column<string>(type: "text", nullable: true),
                    port_count = table.Column<short>(type: "smallint", nullable: true),
                    has_wifi = table.Column<bool>(type: "boolean", nullable: false),
                    wifi_name = table.Column<string>(type: "text", nullable: true),
                    wifi_password = table.Column<string>(type: "text", nullable: true),
                    network_bandwidth = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkDevices", x => x.id);
                    table.ForeignKey(
                        name: "FK_NetworkDevices_InventoryItems_id",
                        column: x => x.id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnDocumentItems",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnDocumentItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReturnDocumentItems_InventoryItems_item_id",
                        column: x => x.item_id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnDocumentItems_ReturnDocuments_document_id",
                        column: x => x.document_id,
                        principalSchema: "Documents",
                        principalTable: "ReturnDocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferDocumentItems",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferDocumentItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransferDocumentItems_InventoryItems_item_id",
                        column: x => x.item_id,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferDocumentItems_TransferDocuments_document_id",
                        column: x => x.document_id,
                        principalSchema: "Documents",
                        principalTable: "TransferDocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffDocumentItems",
                schema: "Documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    document_id = table.Column<int>(type: "integer", nullable: false),
                    items_id = table.Column<int>(type: "integer", nullable: false),
                    WriteOffItems = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffDocumentItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_WriteOffDocumentItems_InventoryItems_WriteOffItems",
                        column: x => x.WriteOffItems,
                        principalSchema: "Inventory",
                        principalTable: "InventoryItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WriteOffDocumentItems_WriteOffDocuments_document_id",
                        column: x => x.document_id,
                        principalSchema: "Documents",
                        principalTable: "WriteOffDocuments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    is_server = table.Column<bool>(type: "boolean", nullable: false),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    operating_system = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Computers_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    diagonal = table.Column<double>(type: "double precision", nullable: true),
                    resolution = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    operating_system = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    processor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ram = table.Column<int>(type: "integer", nullable: true),
                    drive = table.Column<int>(type: "integer", nullable: true),
                    gpu = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Laptops_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogs",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    maintenance_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    maintenance_type = table.Column<int>(type: "integer", nullable: false),
                    performed_by = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Employees_performed_by",
                        column: x => x.performed_by,
                        principalSchema: "Employees",
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Equipments_device_id",
                        column: x => x.device_id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    diagonal = table.Column<double>(type: "double precision", nullable: true),
                    resolution = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    refresh_rate = table.Column<int>(type: "integer", nullable: true),
                    panel_type = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    vga_port = table.Column<short>(type: "smallint", nullable: true),
                    hdmi_port = table.Column<short>(type: "smallint", nullable: true),
                    display_port = table.Column<short>(type: "smallint", nullable: true),
                    dvi_port = table.Column<short>(type: "smallint", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Monitors_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phones_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Printers",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    cartridge_id = table.Column<int>(type: "integer", nullable: false),
                    color = table.Column<bool>(type: "boolean", nullable: false),
                    has_scanner = table.Column<bool>(type: "boolean", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Printers_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printers_PrinterCartridges_cartridge_id",
                        column: x => x.cartridge_id,
                        principalSchema: "Consumables",
                        principalTable: "PrinterCartridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scanners",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ip_address = table.Column<IPAddress>(type: "inet", nullable: true),
                    dpi = table.Column<int>(type: "integer", nullable: true),
                    color = table.Column<bool>(type: "boolean", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scanners", x => x.id);
                    table.ForeignKey(
                        name: "FK_Scanners_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    licence_key = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.id);
                    table.ForeignKey(
                        name: "FK_Software_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tablets",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    operating_system = table.Column<string>(type: "text", nullable: true),
                    diagonal = table.Column<float>(type: "real", nullable: true),
                    ram = table.Column<int>(type: "integer", nullable: true),
                    drive = table.Column<int>(type: "integer", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tablets_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UPS",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    capacity_watts = table.Column<int>(type: "integer", nullable: true),
                    autonomy_minutes = table.Column<int>(type: "integer", nullable: true),
                    socket_count = table.Column<short>(type: "smallint", nullable: true),
                    model = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "text", nullable: true),
                    vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UPS", x => x.id);
                    table.ForeignKey(
                        name: "FK_UPS_Equipments_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkplaceEquipment",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    workplace_id = table.Column<int>(type: "integer", nullable: false),
                    equipment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplaceEquipment", x => x.id);
                    table.ForeignKey(
                        name: "FK_WorkplaceEquipment_Equipments_equipment_id",
                        column: x => x.equipment_id,
                        principalSchema: "Technics",
                        principalTable: "Equipments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkplaceEquipment_Workplaces_workplace_id",
                        column: x => x.workplace_id,
                        principalSchema: "Employees",
                        principalTable: "Workplaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterialAssignments",
                schema: "Inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    furniture_id = table.Column<int>(type: "integer", nullable: false),
                    material_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterialAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterialAssignments_FurnitureMaterials_furniture_id",
                        column: x => x.furniture_id,
                        principalSchema: "Services",
                        principalTable: "FurnitureMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterialAssignments_Furnitures_furniture_id",
                        column: x => x.furniture_id,
                        principalSchema: "Inventory",
                        principalTable: "Furnitures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    computer_id = table.Column<int>(type: "integer", nullable: false),
                    component_type = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<short>(type: "smallint", nullable: false),
                    serial_number = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_ComputerComponents_Computers_computer_id",
                        column: x => x.computer_id,
                        principalSchema: "Technics",
                        principalTable: "Computers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    cpu_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_CPUComponents_CPUs_cpu_id",
                        column: x => x.cpu_id,
                        principalSchema: "Dictionaries",
                        principalTable: "CPUs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CPUComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    gpu_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_GPUComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPUComponents_GPUs_gpu_id",
                        column: x => x.gpu_id,
                        principalSchema: "Dictionaries",
                        principalTable: "GPUs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoBoComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    mobo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoBoComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_MoBoComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoBoComponents_MoBos_mobo_id",
                        column: x => x.mobo_id,
                        principalSchema: "Dictionaries",
                        principalTable: "MoBos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NetworkComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    mac_address = table.Column<string>(type: "text", nullable: true),
                    optical = table.Column<bool>(type: "boolean", nullable: false),
                    speed = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_NetworkComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_OtherComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSUComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Wattage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_PSUComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAMComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    ddr_type = table.Column<int>(type: "integer", nullable: false),
                    size = table.Column<short>(type: "smallint", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_RAMComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoundComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    channels = table.Column<short>(type: "smallint", nullable: true),
                    is_external = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_SoundComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageComponents",
                schema: "Technics",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    storage_type = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageComponents", x => x.id);
                    table.ForeignKey(
                        name: "FK_StorageComponents_ComputerComponents_id",
                        column: x => x.id,
                        principalSchema: "Technics",
                        principalTable: "ComputerComponents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDocumentItems_document_id",
                schema: "Documents",
                table: "CheckoutDocumentItems",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDocumentItems_item_id",
                schema: "Documents",
                table: "CheckoutDocumentItems",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDocuments_employee_id",
                schema: "Documents",
                table: "CheckoutDocuments",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerComponents_computer_id",
                schema: "Technics",
                table: "ComputerComponents",
                column: "computer_id");

            migrationBuilder.CreateIndex(
                name: "IX_CPUComponents_cpu_id",
                schema: "Technics",
                table: "CPUComponents",
                column: "cpu_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_department_id",
                schema: "Employees",
                table: "Employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_item_id",
                schema: "Users",
                table: "Favourite",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_user_id",
                schema: "Users",
                table: "Favourite",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterialAssignments_furniture_id",
                schema: "Inventory",
                table: "FurnitureMaterialAssignments",
                column: "furniture_id");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_type",
                schema: "Inventory",
                table: "Furnitures",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_GenericInventoryItem_Properties",
                schema: "Inventory",
                table: "GenericInventoryItems",
                column: "properties")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_GenericInventoryItems_category_id",
                schema: "Inventory",
                table: "GenericInventoryItems",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_GPUComponents_gpu_id",
                schema: "Technics",
                table: "GPUComponents",
                column: "gpu_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategory_CustomFields",
                schema: "Services",
                table: "InventoryCategorys",
                column: "custom_fields")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_responsible_id",
                schema: "Inventory",
                table: "InventoryItems",
                column: "responsible_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryPhotos_inventory_item_id",
                schema: "Services",
                table: "InventoryPhotos",
                column: "inventory_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntry_Changes",
                schema: "Audit",
                table: "LogEntrys",
                column: "changes")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntrys_user_session",
                schema: "Audit",
                table: "LogEntrys",
                column: "user_session");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_device_id",
                schema: "Technics",
                table: "MaintenanceLogs",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_performed_by",
                schema: "Technics",
                table: "MaintenanceLogs",
                column: "performed_by");

            migrationBuilder.CreateIndex(
                name: "IX_MateriallyResponsibles_employee_id",
                schema: "Employees",
                table: "MateriallyResponsibles",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_MoBoComponents_mobo_id",
                schema: "Technics",
                table: "MoBoComponents",
                column: "mobo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Printers_cartridge_id",
                schema: "Technics",
                table: "Printers",
                column: "cartridge_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDocumentItems_document_id",
                schema: "Documents",
                table: "ReturnDocumentItems",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDocumentItems_item_id",
                schema: "Documents",
                table: "ReturnDocumentItems",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnDocuments_employee_id",
                schema: "Documents",
                table: "ReturnDocuments",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_PermissionJson",
                schema: "Users",
                table: "Roles",
                column: "permissions")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_TransferDocumentItems_document_id",
                schema: "Documents",
                table: "TransferDocumentItems",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransferDocumentItems_item_id",
                schema: "Documents",
                table: "TransferDocumentItems",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransferDocuments_from_employee_id",
                schema: "Documents",
                table: "TransferDocuments",
                column: "from_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransferDocuments_to_employee_id",
                schema: "Documents",
                table: "TransferDocuments",
                column: "to_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_employee_id",
                schema: "Users",
                table: "UsersProfiles",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_role_id",
                schema: "Users",
                table: "UsersProfiles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceEquipment_equipment_id",
                schema: "Technics",
                table: "WorkplaceEquipment",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplaceEquipment_workplace_id",
                schema: "Technics",
                table: "WorkplaceEquipment",
                column: "workplace_id");

            migrationBuilder.CreateIndex(
                name: "IX_Workplaces_employee_id",
                schema: "Employees",
                table: "Workplaces",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffDocumentItems_document_id",
                schema: "Documents",
                table: "WriteOffDocumentItems",
                column: "document_id");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffDocumentItems_WriteOffItems",
                schema: "Documents",
                table: "WriteOffDocumentItems",
                column: "WriteOffItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutDocumentItems",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "CPUComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Favourite",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "FurnitureMaterialAssignments",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "GenericInventoryItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "GPUComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "InventoryPhotos",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "IpAddresses",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Laptops",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "LogEntrys",
                schema: "Audit");

            migrationBuilder.DropTable(
                name: "MaintenanceLogs",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "MoBoComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Monitors",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "NetworkComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "NetworkDevices",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "OtherComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Phones",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Printers",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "PSUComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "RAMComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "ReturnDocumentItems",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "Scanners",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Software",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "SoundComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "StorageComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Tablets",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "TransferDocumentItems",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "UPS",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "WorkplaceEquipment",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "WriteOffDocumentItems",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "CheckoutDocuments",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "CPUs",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "UsersProfiles",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "FurnitureMaterials",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "Furnitures",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryCategorys",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "GPUs",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "UserSessions",
                schema: "Audit");

            migrationBuilder.DropTable(
                name: "MoBos",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "PrinterCartridges",
                schema: "Consumables");

            migrationBuilder.DropTable(
                name: "ReturnDocuments",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "ComputerComponents",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "TransferDocuments",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "Workplaces",
                schema: "Employees");

            migrationBuilder.DropTable(
                name: "WriteOffDocuments",
                schema: "Documents");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "FurnitureTypes",
                schema: "Services");

            migrationBuilder.DropTable(
                name: "Computers",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "Equipments",
                schema: "Technics");

            migrationBuilder.DropTable(
                name: "InventoryItems",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "MateriallyResponsibles",
                schema: "Employees");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Employees");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Employees");
        }
    }
}

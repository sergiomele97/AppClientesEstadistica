using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisa",
                columns: table => new
                {
                    DivisaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisa", x => x.DivisaId);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Divisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    ConversionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MonedaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonedaDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorOrigen = table.Column<double>(type: "float", nullable: true),
                    ValorDestino = table.Column<double>(type: "float", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.ConversionId);
                    table.ForeignKey(
                        name: "FK_Conversion_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImporteRecibido = table.Column<double>(type: "float", nullable: true),
                    ImporteEnviado = table.Column<double>(type: "float", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsOutlier = table.Column<bool>(type: "bit", nullable: true),
                    IsOutlierVisto = table.Column<bool>(type: "bit", nullable: true),
                    ClienteOrigenId = table.Column<int>(type: "int", nullable: false),
                    ClienteDestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Clientes_ClienteDestinoId",
                        column: x => x.ClienteDestinoId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacciones_Clientes_ClienteOrigenId",
                        column: x => x.ClienteOrigenId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "PaisId", "Divisa", "Iso3", "Nombre" },
                values: new object[,]
                {
                    { 1, "AFN", "AFG", "Afganistán" },
                    { 2, "ALL", "ALB", "Albania" },
                    { 3, "EUR", "DEU", "Alemania" },
                    { 4, "EUR", "AND", "Andorra" },
                    { 5, "AOA", "AGO", "Angola" },
                    { 6, "XCD", "ATG", "Antigua y Barbuda" },
                    { 7, "SAR", "SAU", "Arabia Saudita" },
                    { 8, "DZD", "DZA", "Argelia" },
                    { 9, "ARS", "ARG", "Argentina" },
                    { 10, "AMD", "ARM", "Armenia" },
                    { 11, "AUD", "AUS", "Australia" },
                    { 12, "EUR", "AUT", "Austria" },
                    { 13, "AZN", "AZE", "Azerbaiyán" },
                    { 14, "BSD", "BHS", "Bahamas" },
                    { 15, "BHD", "BHR", "Baréin" },
                    { 16, "BDT", "BGD", "Bangladés" },
                    { 17, "BBD", "BRB", "Barbados" },
                    { 18, "BZD", "BLZ", "Belice" },
                    { 19, "XOF", "BEN", "Benín" },
                    { 20, "INR", "BTN", "Bhután" },
                    { 21, "BOB", "BOL", "Bolivia" },
                    { 22, "BAM", "BIH", "Bosnia y Herzegovina" },
                    { 23, "BWP", "BWA", "Botswana" },
                    { 24, "BRL", "BRA", "Brasil" },
                    { 25, "BND", "BRN", "Brunéi" },
                    { 26, "BGN", "BGR", "Bulgaria" },
                    { 27, "XOF", "BFA", "Burkina Faso" },
                    { 28, "BIF", "BDI", "Burundi" },
                    { 29, "INR", "BTN", "Bután" },
                    { 30, "CVE", "CPV", "Cabo Verde" },
                    { 31, "KHR", "KHM", "Camboya" },
                    { 32, "XAF", "CMR", "Camerún" },
                    { 33, "CAD", "CAN", "Canadá" },
                    { 34, "XAF", "TCD", "Chad" },
                    { 35, "CLP", "CHL", "Chile" },
                    { 36, "CNY", "CHN", "China" },
                    { 37, "COP", "COL", "Colombia" },
                    { 38, "KMF", "COM", "Comoras" },
                    { 39, "XAF", "COG", "Congo" },
                    { 40, "CRC", "CRI", "Costa Rica" },
                    { 41, "HRK", "HRV", "Croacia" },
                    { 42, "CUP", "CUB", "Cuba" },
                    { 43, "EUR", "CYP", "Chipre" },
                    { 44, "DKK", "DNK", "Dinamarca" },
                    { 45, "XCD", "DMA", "Dominica" },
                    { 46, "EGP", "EGY", "Egipto" },
                    { 47, "USD", "SLV", "El Salvador" },
                    { 48, "AED", "ARE", "Emiratos Árabes Unidos" },
                    { 49, "USD", "ECU", "Ecuador" },
                    { 50, "ERN", "ERI", "Eritrea" },
                    { 51, "EUR", "SVK", "Eslovaquia" },
                    { 52, "EUR", "SVN", "Eslovenia" },
                    { 53, "EUR", "ESP", "España" },
                    { 54, "USD", "USA", "Estados Unidos" },
                    { 55, "EUR", "EST", "Estonia" },
                    { 56, "ETB", "ETH", "Etiopía" },
                    { 57, "FJD", "FJI", "Fiji" },
                    { 58, "PHP", "PHL", "Filipinas" },
                    { 59, "EUR", "FIN", "Finlandia" },
                    { 60, "EUR", "FRA", "Francia" },
                    { 61, "XAF", "GAB", "Gabón" },
                    { 62, "GMD", "GMB", "Gambia" },
                    { 63, "GEL", "GEO", "Georgia" },
                    { 64, "GHS", "GHA", "Ghana" },
                    { 65, "XCD", "GRD", "Granada" },
                    { 66, "EUR", "GRC", "Grecia" },
                    { 67, "GTQ", "GTM", "Guatemala" },
                    { 68, "GNF", "GIN", "Guinea" },
                    { 69, "XOF", "GNB", "Guinea-Bisáu" },
                    { 70, "GYD", "GUY", "Guyana" },
                    { 71, "HTG", "HTI", "Haití" },
                    { 72, "HNL", "HND", "Honduras" },
                    { 73, "HUF", "HUN", "Hungría" },
                    { 74, "INR", "IND", "India" },
                    { 75, "IDR", "IDN", "Indonesia" },
                    { 76, "IQD", "IRQ", "Irak" },
                    { 77, "IRR", "IRN", "Irán" },
                    { 78, "EUR", "IRL", "Irlanda" },
                    { 79, "ISK", "ISL", "Islandia" },
                    { 80, "USD", "MHL", "Islas Marshall" },
                    { 81, "SBD", "SLB", "Islas Salomón" },
                    { 82, "USD", "VGB", "Islas Vírgenes Británicas" },
                    { 83, "USD", "VIR", "Islas Vírgenes de los Estados Unidos" },
                    { 84, "EUR", "ITA", "Italia" },
                    { 85, "JMD", "JAM", "Jamaica" },
                    { 86, "JPY", "JPN", "Japón" },
                    { 87, "JOD", "JOR", "Jordania" },
                    { 88, "KZT", "KAZ", "Kazajistán" },
                    { 89, "KES", "KEN", "Kenia" },
                    { 90, "KGS", "KGZ", "Kirguistán" },
                    { 91, "AUD", "KIR", "Kiribati" },
                    { 92, "KWD", "KWT", "Kuwait" },
                    { 93, "LAK", "LAO", "Laos" },
                    { 94, "EUR", "LVA", "Latvia" },
                    { 95, "LBP", "LBN", "Líbano" },
                    { 96, "LRD", "LBR", "Liberia" },
                    { 97, "LYD", "LBY", "Libia" },
                    { 98, "CHF", "LIE", "Liechtenstein" },
                    { 99, "EUR", "LTU", "Lituania" },
                    { 100, "EUR", "LUX", "Luxemburgo" },
                    { 101, "MGA", "MDG", "Madagascar" },
                    { 102, "MYR", "MYS", "Malasia" },
                    { 103, "MWK", "MWI", "Malawi" },
                    { 104, "MVR", "MDV", "Maldivas" },
                    { 105, "XOF", "MLI", "Malí" },
                    { 106, "EUR", "MLT", "Malta" },
                    { 107, "MAD", "MAR", "Marruecos" },
                    { 108, "MUR", "MUS", "Mauricio" },
                    { 109, "MRU", "MRT", "Mauritania" },
                    { 110, "MXN", "MEX", "México" },
                    { 111, "USD", "FSM", "Micronesia" },
                    { 112, "MDL", "MDA", "Moldavia" },
                    { 113, "EUR", "MCO", "Mónaco" },
                    { 114, "MNT", "MNG", "Mongolia" },
                    { 115, "EUR", "MNE", "Montenegro" },
                    { 116, "CZK", "CZE", "Moravia" },
                    { 117, "MZN", "MOZ", "Mozambique" },
                    { 118, "NAD", "NAM", "Namibia" },
                    { 119, "AUD", "NRU", "Nauru" },
                    { 120, "NPR", "NPL", "Nepal" },
                    { 121, "NIO", "NIC", "Nicaragua" },
                    { 122, "XOF", "NER", "Níger" },
                    { 123, "NGN", "NGA", "Nigeria" },
                    { 124, "NOK", "NOR", "Noruega" },
                    { 125, "NZD", "NZL", "Nueva Zelanda" },
                    { 126, "OMR", "OMN", "Omán" },
                    { 127, "EUR", "NLD", "Países Bajos" },
                    { 128, "PKR", "PAK", "Pakistán" },
                    { 129, "USD", "PLW", "Palau" },
                    { 130, "PAB", "PAN", "Panamá" },
                    { 131, "PGK", "PNG", "Papúa Nueva Guinea" },
                    { 132, "PYG", "PRY", "Paraguay" },
                    { 133, "PEN", "PER", "Perú" },
                    { 134, "PLN", "POL", "Polonia" },
                    { 135, "EUR", "PRT", "Portugal" },
                    { 136, "QAR", "QAT", "Qatar" },
                    { 137, "RON", "ROU", "Rumanía" },
                    { 138, "RUB", "RUS", "Rusia" },
                    { 139, "RWF", "RWA", "Rwanda" },
                    { 140, "XCD", "KNA", "San Cristóbal y Nieves" },
                    { 141, "EUR", "SMR", "San Marino" },
                    { 142, "STN", "STP", "Santo Tomé y Príncipe" },
                    { 143, "XOF", "SEN", "Senegal" },
                    { 144, "RSD", "SRB", "Serbia" },
                    { 145, "SCR", "SYC", "Seychelles" },
                    { 146, "SLL", "SLE", "Sierra Leona" },
                    { 147, "SGD", "SGP", "Singapur" },
                    { 148, "SYP", "SYR", "Siria" },
                    { 149, "SOS", "SOM", "Somalia" },
                    { 150, "LKR", "LKA", "Sri Lanka" },
                    { 151, "SDG", "SDN", "Sudán" },
                    { 152, "SSP", "SSD", "Sudán del Sur" },
                    { 153, "SEK", "SWE", "Suecia" },
                    { 154, "CHF", "CHE", "Suiza" },
                    { 155, "STN", "STP", "Santo Tomé y Príncipe" },
                    { 156, "THB", "THA", "Tailandia" },
                    { 157, "TWD", "TWN", "Taiwán" },
                    { 158, "TZS", "TZA", "Tanzania" },
                    { 159, "XOF", "TGO", "Togo" },
                    { 160, "TOP", "TON", "Tonga" },
                    { 161, "TTD", "TTO", "Trinidad y Tobago" },
                    { 162, "TND", "TUN", "Túnez" },
                    { 163, "TMT", "TKM", "Turkmenistán" },
                    { 164, "TRY", "TUR", "Turquía" },
                    { 165, "AUD", "TUV", "Tuvalu" },
                    { 166, "UAH", "UKR", "Ucrania" },
                    { 167, "UGX", "UGA", "Uganda" },
                    { 168, "UYU", "URY", "Uruguay" },
                    { 169, "UZS", "UZB", "Uzbekistán" },
                    { 170, "VUV", "VUT", "Vanuatu" },
                    { 171, "VES", "VEN", "Venezuela" },
                    { 172, "VND", "VNM", "Vietnam" },
                    { 173, "YER", "YEM", "Yemen" },
                    { 174, "ZMW", "ZMB", "Zambia" },
                    { 175, "ZWL", "ZWE", "Zimbabue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisId",
                table: "Clientes",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_ClienteId",
                table: "Conversion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteDestinoId",
                table: "Transacciones",
                column: "ClienteDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteOrigenId",
                table: "Transacciones",
                column: "ClienteOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Divisa");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}

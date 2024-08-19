using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class _InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
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
                    { 20, "BYN", "BLR", "Bielorrusia" },
                    { 21, "MMK", "MMR", "Birmania" },
                    { 22, "BOB", "BOL", "Bolivia" },
                    { 23, "BAM", "BIH", "Bosnia y Herzegovina" },
                    { 24, "BWP", "BWA", "Botswana" },
                    { 25, "BRL", "BRA", "Brasil" },
                    { 26, "BND", "BRN", "Brunéi" },
                    { 27, "BGN", "BGR", "Bulgaria" },
                    { 28, "XOF", "BFA", "Burkina Faso" },
                    { 29, "BIF", "BDI", "Burundi" },
                    { 30, "INR", "BTN", "Bután" },
                    { 31, "CVE", "CPV", "Cabo Verde" },
                    { 32, "KHR", "KHM", "Camboya" },
                    { 33, "XAF", "CMR", "Camerún" },
                    { 34, "CAD", "CAN", "Canadá" },
                    { 35, "QAR", "QAT", "Catar" },
                    { 36, "XAF", "TCD", "Chad" },
                    { 37, "CLP", "CHL", "Chile" },
                    { 38, "CNY", "CHN", "China" },
                    { 39, "COP", "COL", "Colombia" },
                    { 40, "KMF", "COM", "Comoras" },
                    { 41, "XAF", "COG", "Congo" },
                    { 42, "KPW", "PRK", "Corea del Norte" },
                    { 43, "KRW", "KOR", "Corea del Sur" },
                    { 44, "CRC", "CRI", "Costa Rica" },
                    { 45, "HRK", "HRV", "Croacia" },
                    { 46, "CUP", "CUB", "Cuba" },
                    { 47, "EUR", "CYP", "Chipre" },
                    { 48, "CZK", "CZE", "Chequia" },
                    { 49, "DKK", "DNK", "Dinamarca" },
                    { 50, "XCD", "DMA", "Dominica" },
                    { 51, "EGP", "EGY", "Egipto" },
                    { 52, "USD", "SLV", "El Salvador" },
                    { 53, "AED", "ARE", "Emiratos Árabes Unidos" },
                    { 54, "USD", "ECU", "Ecuador" },
                    { 55, "ERN", "ERI", "Eritrea" },
                    { 56, "GBP", "GBR", "Escocia" },
                    { 57, "EUR", "SVK", "Eslovaquia" },
                    { 58, "EUR", "SVN", "Eslovenia" },
                    { 59, "EUR", "ESP", "España" },
                    { 60, "USD", "USA", "Estados Unidos" },
                    { 61, "EUR", "EST", "Estonia" },
                    { 62, "SZL", "SWZ", "Eswatini" },
                    { 63, "XCD", "GRD", "Granada" },
                    { 64, "EUR", "GRC", "Grecia" },
                    { 65, "GTQ", "GTM", "Guatemala" },
                    { 66, "GNF", "GIN", "Guinea" },
                    { 67, "XOF", "GNB", "Guinea-Bisáu" },
                    { 68, "GYD", "GUY", "Guyana" },
                    { 69, "HTG", "HTI", "Haití" },
                    { 70, "HNL", "HND", "Honduras" },
                    { 71, "HUF", "HUN", "Hungría" },
                    { 72, "INR", "IND", "India" },
                    { 73, "IDR", "IDN", "Indonesia" },
                    { 74, "IRR", "IRN", "Irán" },
                    { 75, "IQD", "IRQ", "Iraq" },
                    { 76, "EUR", "IRL", "Irlanda" },
                    { 77, "ISK", "ISL", "Islandia" },
                    { 78, "USD", "MHL", "Islas Marshall" },
                    { 79, "SBD", "SLB", "Islas Salomón" },
                    { 80, "USD", "VGB", "Islas Vírgenes Británicas" },
                    { 81, "USD", "VIR", "Islas Vírgenes de los EE.UU." },
                    { 82, "EUR", "ITA", "Italia" },
                    { 83, "JMD", "JAM", "Jamaica" },
                    { 84, "JPY", "JPN", "Japón" },
                    { 85, "JOD", "JOR", "Jordania" },
                    { 86, "KZT", "KAZ", "Kazajistán" },
                    { 87, "KES", "KEN", "Kenia" },
                    { 88, "KGS", "KGZ", "Kirguistán" },
                    { 89, "AUD", "KIR", "Kiribati" },
                    { 90, "KWD", "KWT", "Kuwait" },
                    { 91, "LAK", "LAO", "Laos" },
                    { 92, "LVL", "LVA", "Latvia" },
                    { 93, "LBP", "LBN", "Líbano" },
                    { 94, "LRD", "LBR", "Liberia" },
                    { 95, "LYD", "LBY", "Libia" },
                    { 96, "CHF", "LIE", "Liechtenstein" },
                    { 97, "EUR", "LTU", "Lituania" },
                    { 98, "EUR", "LUX", "Luxemburgo" },
                    { 99, "MGA", "MDG", "Madagascar" },
                    { 100, "MYR", "MYS", "Malasia" },
                    { 101, "MWK", "MWI", "Malawi" },
                    { 102, "MVR", "MDV", "Maldivas" },
                    { 103, "XOF", "MLI", "Mali" },
                    { 104, "EUR", "MLT", "Malta" },
                    { 105, "MAD", "MAR", "Marruecos" },
                    { 106, "MUR", "MUS", "Mauricio" },
                    { 107, "MRU", "MRT", "Mauritania" },
                    { 108, "MXN", "MEX", "México" },
                    { 109, "USD", "FSM", "Micronesia" },
                    { 110, "MDL", "MDA", "Moldavia" },
                    { 111, "EUR", "MCO", "Mónaco" },
                    { 112, "MNT", "MNG", "Mongolia" },
                    { 113, "EUR", "MNE", "Montenegro" },
                    { 114, "USD", "MOZ", "Moratoria" },
                    { 115, "NAD", "NAM", "Namibia" },
                    { 116, "AUD", "NRU", "Nauru" },
                    { 117, "NPR", "NPL", "Nepal" },
                    { 118, "NIO", "NIC", "Nicaragua" },
                    { 119, "XOF", "NER", "Níger" },
                    { 120, "NGN", "NGA", "Nigeria" },
                    { 121, "NOK", "NOR", "Noruega" },
                    { 122, "NZD", "NZL", "Nueva Zelanda" },
                    { 123, "OMR", "OMN", "Omán" },
                    { 124, "EUR", "NLD", "Países Bajos" },
                    { 125, "PKR", "PAK", "Pakistán" },
                    { 126, "USD", "PLW", "Palaos" },
                    { 127, "PAB", "PAN", "Panamá" },
                    { 128, "PGK", "PNG", "Papúa Nueva Guinea" },
                    { 129, "PYG", "PRY", "Paraguay" },
                    { 130, "PEN", "PER", "Perú" },
                    { 131, "PLN", "POL", "Polonia" },
                    { 132, "EUR", "PRT", "Portugal" },
                    { 133, "QAR", "QAT", "Qatar" },
                    { 134, "GBP", "GBR", "Reino Unido" },
                    { 135, "XAF", "CAF", "República Centroafricana" },
                    { 136, "CZK", "CZE", "República Checa" },
                    { 137, "DOP", "DOM", "República Dominicana" },
                    { 138, "RWF", "RWA", "Ruanda" },
                    { 139, "RON", "ROU", "Rumania" },
                    { 140, "RUB", "RUS", "Rusia" },
                    { 141, "XCD", "KNA", "San Cristóbal y Nieves" },
                    { 142, "EUR", "SMR", "San Marino" },
                    { 143, "XCD", "LCA", "Santa Lucía" },
                    { 144, "XCD", "VCT", "San Vicente y las Granadinas" },
                    { 145, "STN", "STP", "Santo Tomé y Príncipe" },
                    { 146, "XOF", "SEN", "Senegal" },
                    { 147, "RSD", "SRB", "Serbia" },
                    { 148, "SCR", "SYC", "Seychelles" },
                    { 149, "SLL", "SLE", "Sierra Leona" },
                    { 150, "SGD", "SGP", "Singapur" },
                    { 151, "SYP", "SYR", "Siria" },
                    { 152, "SOS", "SOM", "Somalia" },
                    { 153, "LKR", "LKA", "Sri Lanka" },
                    { 154, "SDG", "SDN", "Sudán" },
                    { 155, "SEK", "SWE", "Suecia" },
                    { 156, "CHF", "CHE", "Suiza" },
                    { 157, "SRD", "SUR", "Surinam" },
                    { 158, "THB", "THA", "Tailandia" },
                    { 159, "TZS", "TZA", "Tanzania" },
                    { 160, "USD", "TLS", "Timor Oriental" },
                    { 161, "XOF", "TGO", "Togo" },
                    { 162, "TOP", "TON", "Tonga" },
                    { 163, "TTD", "TTO", "Trinidad y Tobago" },
                    { 164, "TND", "TUN", "Túnez" },
                    { 165, "TMT", "TKM", "Turkmenistán" },
                    { 166, "TRY", "TUR", "Turquía" },
                    { 167, "AUD", "TUV", "Tuvalu" },
                    { 168, "UAH", "UKR", "Ucrania" },
                    { 169, "UGX", "UGA", "Uganda" },
                    { 170, "UYU", "URY", "Uruguay" },
                    { 171, "UZS", "UZB", "Uzbekistán" },
                    { 172, "VUV", "VUT", "Vanuatu" },
                    { 173, "VES", "VEN", "Venezuela" },
                    { 174, "VND", "VNM", "Vietnam" },
                    { 175, "YER", "YEM", "Yemen" },
                    { 176, "ZMW", "ZMB", "Zambia" },
                    { 177, "ZWL", "ZWE", "Zimbabue" }
                });

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
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}

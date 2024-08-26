using System.Numerics;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendEstadistica.Contexto;

/* En .NET Entity Framework, el contexto de la base de datos (DbContext) 
 * actúa como una puerta de enlace entre la aplicación y la base de datos.
 * Define las colecciones de entidades (DbSet) que representan las tablas de la base de datos.
 */

public class ContextoBBDD : IdentityDbContext<ApplicationUser>
{

    // Constructor de la clase:
    // Se pasan opciones al constructor de la clase base DbContext.
    public ContextoBBDD(DbContextOptions<ContextoBBDD> options)
    : base(options)
    {
       
    }

    // DEFINIR LAS TABLAS AQUÍ:
    public DbSet<Usuario> Usuario { get; set; } // 1º Tabla

    public DbSet<Cliente> Clientes { get; set; } // 2ª Tabla

    public DbSet<Pais> Paises { get; set; } // 3ª Tabla

    public DbSet<Transaccion> Transacciones { get; set; } // 4ª Tabla

    public DbSet<Conversion> Conversion { get; set; } // 5ª Tabla

    public DbSet<Divisa> Divisa { get; set; } // 6ª Tabla
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Necesario para Identity

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteOrigen)
            .WithMany(c => c.TransaccionesOrigen)
            .HasForeignKey(t => t.ClienteOrigenId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaccion>()
            .HasOne(t => t.ClienteDestino)
            .WithMany(c => c.TransaccionesDestino)
            .HasForeignKey(t => t.ClienteDestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pais)
            .WithMany(p => p.Clientes)
            .HasForeignKey(c => c.PaisId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Divisa>()
            .Property(d => d.DivisaId)
            .ValueGeneratedOnAdd(); ;

        modelBuilder.Entity<Pais>().HasData(
            new Pais { PaisId = 1, Nombre = "Afganistán", Divisa = "AFN", Iso3 = "AFG" },
            new Pais { PaisId = 2, Nombre = "Albania", Divisa = "ALL", Iso3 = "ALB" },
            new Pais { PaisId = 3, Nombre = "Alemania", Divisa = "EUR", Iso3 = "DEU" },
            new Pais { PaisId = 4, Nombre = "Andorra", Divisa = "EUR", Iso3 = "AND" },
            new Pais { PaisId = 5, Nombre = "Angola", Divisa = "AOA", Iso3 = "AGO" },
            new Pais { PaisId = 6, Nombre = "Antigua y Barbuda", Divisa = "XCD", Iso3 = "ATG" },
            new Pais { PaisId = 7, Nombre = "Arabia Saudita", Divisa = "SAR", Iso3 = "SAU" },
            new Pais { PaisId = 8, Nombre = "Argelia", Divisa = "DZD", Iso3 = "DZA" },
            new Pais { PaisId = 9, Nombre = "Argentina", Divisa = "ARS", Iso3 = "ARG" },
            new Pais { PaisId = 10, Nombre = "Armenia", Divisa = "AMD", Iso3 = "ARM" },
            new Pais { PaisId = 11, Nombre = "Australia", Divisa = "AUD", Iso3 = "AUS" },
            new Pais { PaisId = 12, Nombre = "Austria", Divisa = "EUR", Iso3 = "AUT" },
            new Pais { PaisId = 13, Nombre = "Azerbaiyán", Divisa = "AZN", Iso3 = "AZE" },
            new Pais { PaisId = 14, Nombre = "Bahamas", Divisa = "BSD", Iso3 = "BHS" },
            new Pais { PaisId = 15, Nombre = "Baréin", Divisa = "BHD", Iso3 = "BHR" },
            new Pais { PaisId = 16, Nombre = "Bangladés", Divisa = "BDT", Iso3 = "BGD" },
            new Pais { PaisId = 17, Nombre = "Barbados", Divisa = "BBD", Iso3 = "BRB" },
            new Pais { PaisId = 18, Nombre = "Belice", Divisa = "BZD", Iso3 = "BLZ" },
            new Pais { PaisId = 19, Nombre = "Benín", Divisa = "XOF", Iso3 = "BEN" },
            new Pais { PaisId = 20, Nombre = "Bielorrusia", Divisa = "BYN", Iso3 = "BLR" },
            new Pais { PaisId = 21, Nombre = "Birmania", Divisa = "MMK", Iso3 = "MMR" },
            new Pais { PaisId = 22, Nombre = "Bolivia", Divisa = "BOB", Iso3 = "BOL" },
            new Pais { PaisId = 23, Nombre = "Bosnia y Herzegovina", Divisa = "BAM", Iso3 = "BIH" },
            new Pais { PaisId = 24, Nombre = "Botswana", Divisa = "BWP", Iso3 = "BWA" },
            new Pais { PaisId = 25, Nombre = "Brasil", Divisa = "BRL", Iso3 = "BRA" },
            new Pais { PaisId = 26, Nombre = "Brunéi", Divisa = "BND", Iso3 = "BRN" },
            new Pais { PaisId = 27, Nombre = "Bulgaria", Divisa = "BGN", Iso3 = "BGR" },
            new Pais { PaisId = 28, Nombre = "Burkina Faso", Divisa = "XOF", Iso3 = "BFA" },
            new Pais { PaisId = 29, Nombre = "Burundi", Divisa = "BIF", Iso3 = "BDI" },
            new Pais { PaisId = 30, Nombre = "Bután", Divisa = "INR", Iso3 = "BTN" },
            new Pais { PaisId = 31, Nombre = "Cabo Verde", Divisa = "CVE", Iso3 = "CPV" },
            new Pais { PaisId = 32, Nombre = "Camboya", Divisa = "KHR", Iso3 = "KHM" },
            new Pais { PaisId = 33, Nombre = "Camerún", Divisa = "XAF", Iso3 = "CMR" },
            new Pais { PaisId = 34, Nombre = "Canadá", Divisa = "CAD", Iso3 = "CAN" },
            new Pais { PaisId = 35, Nombre = "Catar", Divisa = "QAR", Iso3 = "QAT" },
            new Pais { PaisId = 36, Nombre = "Chad", Divisa = "XAF", Iso3 = "TCD" },
            new Pais { PaisId = 37, Nombre = "Chile", Divisa = "CLP", Iso3 = "CHL" },
            new Pais { PaisId = 38, Nombre = "China", Divisa = "CNY", Iso3 = "CHN" },
            new Pais { PaisId = 39, Nombre = "Colombia", Divisa = "COP", Iso3 = "COL" },
            new Pais { PaisId = 40, Nombre = "Comoras", Divisa = "KMF", Iso3 = "COM" },
            new Pais { PaisId = 41, Nombre = "Congo", Divisa = "XAF", Iso3 = "COG" },
            new Pais { PaisId = 42, Nombre = "Corea del Norte", Divisa = "KPW", Iso3 = "PRK" },
            new Pais { PaisId = 43, Nombre = "Corea del Sur", Divisa = "KRW", Iso3 = "KOR" },
            new Pais { PaisId = 44, Nombre = "Costa Rica", Divisa = "CRC", Iso3 = "CRI" },
            new Pais { PaisId = 45, Nombre = "Croacia", Divisa = "HRK", Iso3 = "HRV" },
            new Pais { PaisId = 46, Nombre = "Cuba", Divisa = "CUP", Iso3 = "CUB" },
            new Pais { PaisId = 47, Nombre = "Chipre", Divisa = "EUR", Iso3 = "CYP" },
            new Pais { PaisId = 48, Nombre = "Chequia", Divisa = "CZK", Iso3 = "CZE" },
            new Pais { PaisId = 49, Nombre = "Dinamarca", Divisa = "DKK", Iso3 = "DNK" },
            new Pais { PaisId = 50, Nombre = "Dominica", Divisa = "XCD", Iso3 = "DMA" },
            new Pais { PaisId = 51, Nombre = "Egipto", Divisa = "EGP", Iso3 = "EGY" },
            new Pais { PaisId = 52, Nombre = "El Salvador", Divisa = "USD", Iso3 = "SLV" },
            new Pais { PaisId = 53, Nombre = "Emiratos Árabes Unidos", Divisa = "AED", Iso3 = "ARE" },
            new Pais { PaisId = 54, Nombre = "Ecuador", Divisa = "USD", Iso3 = "ECU" },
            new Pais { PaisId = 55, Nombre = "Eritrea", Divisa = "ERN", Iso3 = "ERI" },
            new Pais { PaisId = 56, Nombre = "Escocia", Divisa = "GBP", Iso3 = "GBR" },
            new Pais { PaisId = 57, Nombre = "Eslovaquia", Divisa = "EUR", Iso3 = "SVK" },
            new Pais { PaisId = 58, Nombre = "Eslovenia", Divisa = "EUR", Iso3 = "SVN" },
            new Pais { PaisId = 59, Nombre = "España", Divisa = "EUR", Iso3 = "ESP" },
            new Pais { PaisId = 60, Nombre = "Estados Unidos", Divisa = "USD", Iso3 = "USA" },
            new Pais { PaisId = 61, Nombre = "Estonia", Divisa = "EUR", Iso3 = "EST" },
            new Pais { PaisId = 62, Nombre = "Eswatini", Divisa = "SZL", Iso3 = "SWZ" },
            new Pais { PaisId = 63, Nombre = "Granada", Divisa = "XCD", Iso3 = "GRD" },
            new Pais { PaisId = 64, Nombre = "Grecia", Divisa = "EUR", Iso3 = "GRC" },
            new Pais { PaisId = 65, Nombre = "Guatemala", Divisa = "GTQ", Iso3 = "GTM" },
            new Pais { PaisId = 66, Nombre = "Guinea", Divisa = "GNF", Iso3 = "GIN" },
            new Pais { PaisId = 67, Nombre = "Guinea-Bisáu", Divisa = "XOF", Iso3 = "GNB" },
            new Pais { PaisId = 68, Nombre = "Guyana", Divisa = "GYD", Iso3 = "GUY" },
            new Pais { PaisId = 69, Nombre = "Haití", Divisa = "HTG", Iso3 = "HTI" },
            new Pais { PaisId = 70, Nombre = "Honduras", Divisa = "HNL", Iso3 = "HND" },
            new Pais { PaisId = 71, Nombre = "Hungría", Divisa = "HUF", Iso3 = "HUN" },
            new Pais { PaisId = 72, Nombre = "India", Divisa = "INR", Iso3 = "IND" },
            new Pais { PaisId = 73, Nombre = "Indonesia", Divisa = "IDR", Iso3 = "IDN" },
            new Pais { PaisId = 74, Nombre = "Irán", Divisa = "IRR", Iso3 = "IRN" },
            new Pais { PaisId = 75, Nombre = "Iraq", Divisa = "IQD", Iso3 = "IRQ" },
            new Pais { PaisId = 76, Nombre = "Irlanda", Divisa = "EUR", Iso3 = "IRL" },
            new Pais { PaisId = 77, Nombre = "Islandia", Divisa = "ISK", Iso3 = "ISL" },
            new Pais { PaisId = 78, Nombre = "Islas Marshall", Divisa = "USD", Iso3 = "MHL" },
            new Pais { PaisId = 79, Nombre = "Islas Salomón", Divisa = "SBD", Iso3 = "SLB" },
            new Pais { PaisId = 80, Nombre = "Islas Vírgenes Británicas", Divisa = "USD", Iso3 = "VGB" },
            new Pais { PaisId = 81, Nombre = "Islas Vírgenes de los EE.UU.", Divisa = "USD", Iso3 = "VIR" },
            new Pais { PaisId = 82, Nombre = "Italia", Divisa = "EUR", Iso3 = "ITA" },
            new Pais { PaisId = 83, Nombre = "Jamaica", Divisa = "JMD", Iso3 = "JAM" },
            new Pais { PaisId = 84, Nombre = "Japón", Divisa = "JPY", Iso3 = "JPN" },
            new Pais { PaisId = 85, Nombre = "Jordania", Divisa = "JOD", Iso3 = "JOR" },
            new Pais { PaisId = 86, Nombre = "Kazajistán", Divisa = "KZT", Iso3 = "KAZ" },
            new Pais { PaisId = 87, Nombre = "Kenia", Divisa = "KES", Iso3 = "KEN" },
            new Pais { PaisId = 88, Nombre = "Kirguistán", Divisa = "KGS", Iso3 = "KGZ" },
            new Pais { PaisId = 89, Nombre = "Kiribati", Divisa = "AUD", Iso3 = "KIR" },
            new Pais { PaisId = 90, Nombre = "Kuwait", Divisa = "KWD", Iso3 = "KWT" },
            new Pais { PaisId = 91, Nombre = "Laos", Divisa = "LAK", Iso3 = "LAO" },
            new Pais { PaisId = 92, Nombre = "Latvia", Divisa = "LVL", Iso3 = "LVA" },
            new Pais { PaisId = 93, Nombre = "Líbano", Divisa = "LBP", Iso3 = "LBN" },
            new Pais { PaisId = 94, Nombre = "Liberia", Divisa = "LRD", Iso3 = "LBR" },
            new Pais { PaisId = 95, Nombre = "Libia", Divisa = "LYD", Iso3 = "LBY" },
            new Pais { PaisId = 96, Nombre = "Liechtenstein", Divisa = "CHF", Iso3 = "LIE" },
            new Pais { PaisId = 97, Nombre = "Lituania", Divisa = "EUR", Iso3 = "LTU" },
            new Pais { PaisId = 98, Nombre = "Luxemburgo", Divisa = "EUR", Iso3 = "LUX" },
            new Pais { PaisId = 99, Nombre = "Madagascar", Divisa = "MGA", Iso3 = "MDG" },
            new Pais { PaisId = 100, Nombre = "Malasia", Divisa = "MYR", Iso3 = "MYS" },
            new Pais { PaisId = 101, Nombre = "Malawi", Divisa = "MWK", Iso3 = "MWI" },
            new Pais { PaisId = 102, Nombre = "Maldivas", Divisa = "MVR", Iso3 = "MDV" },
            new Pais { PaisId = 103, Nombre = "Mali", Divisa = "XOF", Iso3 = "MLI" },
            new Pais { PaisId = 104, Nombre = "Malta", Divisa = "EUR", Iso3 = "MLT" },
            new Pais { PaisId = 105, Nombre = "Marruecos", Divisa = "MAD", Iso3 = "MAR" },
            new Pais { PaisId = 106, Nombre = "Mauricio", Divisa = "MUR", Iso3 = "MUS" },
            new Pais { PaisId = 107, Nombre = "Mauritania", Divisa = "MRU", Iso3 = "MRT" },
            new Pais { PaisId = 108, Nombre = "México", Divisa = "MXN", Iso3 = "MEX" },
            new Pais { PaisId = 109, Nombre = "Micronesia", Divisa = "USD", Iso3 = "FSM" },
            new Pais { PaisId = 110, Nombre = "Moldavia", Divisa = "MDL", Iso3 = "MDA" },
            new Pais { PaisId = 111, Nombre = "Mónaco", Divisa = "EUR", Iso3 = "MCO" },
            new Pais { PaisId = 112, Nombre = "Mongolia", Divisa = "MNT", Iso3 = "MNG" },
            new Pais { PaisId = 113, Nombre = "Montenegro", Divisa = "EUR", Iso3 = "MNE" },
            new Pais { PaisId = 114, Nombre = "Moratoria", Divisa = "USD", Iso3 = "MOZ" },
            new Pais { PaisId = 115, Nombre = "Namibia", Divisa = "NAD", Iso3 = "NAM" },
            new Pais { PaisId = 116, Nombre = "Nauru", Divisa = "AUD", Iso3 = "NRU" },
            new Pais { PaisId = 117, Nombre = "Nepal", Divisa = "NPR", Iso3 = "NPL" },
            new Pais { PaisId = 118, Nombre = "Nicaragua", Divisa = "NIO", Iso3 = "NIC" },
            new Pais { PaisId = 119, Nombre = "Níger", Divisa = "XOF", Iso3 = "NER" },
            new Pais { PaisId = 120, Nombre = "Nigeria", Divisa = "NGN", Iso3 = "NGA" },
            new Pais { PaisId = 121, Nombre = "Noruega", Divisa = "NOK", Iso3 = "NOR" },
            new Pais { PaisId = 122, Nombre = "Nueva Zelanda", Divisa = "NZD", Iso3 = "NZL" },
            new Pais { PaisId = 123, Nombre = "Omán", Divisa = "OMR", Iso3 = "OMN" },
            new Pais { PaisId = 124, Nombre = "Países Bajos", Divisa = "EUR", Iso3 = "NLD" },
            new Pais { PaisId = 125, Nombre = "Pakistán", Divisa = "PKR", Iso3 = "PAK" },
            new Pais { PaisId = 126, Nombre = "Palaos", Divisa = "USD", Iso3 = "PLW" },
            new Pais { PaisId = 127, Nombre = "Panamá", Divisa = "PAB", Iso3 = "PAN" },
            new Pais { PaisId = 128, Nombre = "Papúa Nueva Guinea", Divisa = "PGK", Iso3 = "PNG" },
            new Pais { PaisId = 129, Nombre = "Paraguay", Divisa = "PYG", Iso3 = "PRY" },
            new Pais { PaisId = 130, Nombre = "Perú", Divisa = "PEN", Iso3 = "PER" },
            new Pais { PaisId = 131, Nombre = "Polonia", Divisa = "PLN", Iso3 = "POL" },
            new Pais { PaisId = 132, Nombre = "Portugal", Divisa = "EUR", Iso3 = "PRT" },
            new Pais { PaisId = 133, Nombre = "Qatar", Divisa = "QAR", Iso3 = "QAT" },
            new Pais { PaisId = 134, Nombre = "Reino Unido", Divisa = "GBP", Iso3 = "GBR" },
            new Pais { PaisId = 135, Nombre = "República Centroafricana", Divisa = "XAF", Iso3 = "CAF" },
            new Pais { PaisId = 136, Nombre = "República Checa", Divisa = "CZK", Iso3 = "CZE" },
            new Pais { PaisId = 137, Nombre = "República Dominicana", Divisa = "DOP", Iso3 = "DOM" },
            new Pais { PaisId = 138, Nombre = "Ruanda", Divisa = "RWF", Iso3 = "RWA" },
            new Pais { PaisId = 139, Nombre = "Rumania", Divisa = "RON", Iso3 = "ROU" },
            new Pais { PaisId = 140, Nombre = "Rusia", Divisa = "RUB", Iso3 = "RUS" },
            new Pais { PaisId = 141, Nombre = "San Cristóbal y Nieves", Divisa = "XCD", Iso3 = "KNA" },
            new Pais { PaisId = 142, Nombre = "San Marino", Divisa = "EUR", Iso3 = "SMR" },
            new Pais { PaisId = 143, Nombre = "Santa Lucía", Divisa = "XCD", Iso3 = "LCA" },
            new Pais { PaisId = 144, Nombre = "San Vicente y las Granadinas", Divisa = "XCD", Iso3 = "VCT" },
            new Pais { PaisId = 145, Nombre = "Santo Tomé y Príncipe", Divisa = "STN", Iso3 = "STP" },
            new Pais { PaisId = 146, Nombre = "Senegal", Divisa = "XOF", Iso3 = "SEN" },
            new Pais { PaisId = 147, Nombre = "Serbia", Divisa = "RSD", Iso3 = "SRB" },
            new Pais { PaisId = 148, Nombre = "Seychelles", Divisa = "SCR", Iso3 = "SYC" },
            new Pais { PaisId = 149, Nombre = "Sierra Leona", Divisa = "SLL", Iso3 = "SLE" },
            new Pais { PaisId = 150, Nombre = "Singapur", Divisa = "SGD", Iso3 = "SGP" },
            new Pais { PaisId = 151, Nombre = "Siria", Divisa = "SYP", Iso3 = "SYR" },
            new Pais { PaisId = 152, Nombre = "Somalia", Divisa = "SOS", Iso3 = "SOM" },
            new Pais { PaisId = 153, Nombre = "Sri Lanka", Divisa = "LKR", Iso3 = "LKA" },
            new Pais { PaisId = 154, Nombre = "Sudán", Divisa = "SDG", Iso3 = "SDN" },
            new Pais { PaisId = 155, Nombre = "Suecia", Divisa = "SEK", Iso3 = "SWE" },
            new Pais { PaisId = 156, Nombre = "Suiza", Divisa = "CHF", Iso3 = "CHE" },
            new Pais { PaisId = 157, Nombre = "Surinam", Divisa = "SRD", Iso3 = "SUR" },
            new Pais { PaisId = 158, Nombre = "Tailandia", Divisa = "THB", Iso3 = "THA" },
            new Pais { PaisId = 159, Nombre = "Tanzania", Divisa = "TZS", Iso3 = "TZA" },
            new Pais { PaisId = 160, Nombre = "Timor Oriental", Divisa = "USD", Iso3 = "TLS" },
            new Pais { PaisId = 161, Nombre = "Togo", Divisa = "XOF", Iso3 = "TGO" },
            new Pais { PaisId = 162, Nombre = "Tonga", Divisa = "TOP", Iso3 = "TON" },
            new Pais { PaisId = 163, Nombre = "Trinidad y Tobago", Divisa = "TTD", Iso3 = "TTO" },
            new Pais { PaisId = 164, Nombre = "Túnez", Divisa = "TND", Iso3 = "TUN" },
            new Pais { PaisId = 165, Nombre = "Turkmenistán", Divisa = "TMT", Iso3 = "TKM" },
            new Pais { PaisId = 166, Nombre = "Turquía", Divisa = "TRY", Iso3 = "TUR" },
            new Pais { PaisId = 167, Nombre = "Tuvalu", Divisa = "AUD", Iso3 = "TUV" },
            new Pais { PaisId = 168, Nombre = "Ucrania", Divisa = "UAH", Iso3 = "UKR" },
            new Pais { PaisId = 169, Nombre = "Uganda", Divisa = "UGX", Iso3 = "UGA" },
            new Pais { PaisId = 170, Nombre = "Uruguay", Divisa = "UYU", Iso3 = "URY" },
            new Pais { PaisId = 171, Nombre = "Uzbekistán", Divisa = "UZS", Iso3 = "UZB" },
            new Pais { PaisId = 172, Nombre = "Vanuatu", Divisa = "VUV", Iso3 = "VUT" },
            new Pais { PaisId = 173, Nombre = "Venezuela", Divisa = "VES", Iso3 = "VEN" },
            new Pais { PaisId = 174, Nombre = "Vietnam", Divisa = "VND", Iso3 = "VNM" },
            new Pais { PaisId = 175, Nombre = "Yemen", Divisa = "YER", Iso3 = "YEM" },
            new Pais { PaisId = 176, Nombre = "Zambia", Divisa = "ZMW", Iso3 = "ZMB" },
            new Pais { PaisId = 177, Nombre = "Zimbabue", Divisa = "ZWL", Iso3 = "ZWE" }
            );
    }
}

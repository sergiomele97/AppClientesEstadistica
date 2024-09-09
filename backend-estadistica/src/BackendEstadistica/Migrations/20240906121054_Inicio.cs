using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendEstadistica.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Divisa",
                columns: new[] { "DivisaId", "Fecha", "Nombre", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 2, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 3, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.686999999999998 },
                    { 4, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 89.962000000000003 },
                    { 5, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.73099999999999 },
                    { 6, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 7, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 926.32500000000005 },
                    { 8, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 950.66999999999996 },
                    { 9, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.4710000000000001 },
                    { 10, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 11, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.7 },
                    { 12, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.7649999999999999 },
                    { 13, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 14, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.44799999999999 },
                    { 15, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.7649999999999999 },
                    { 16, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 17, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2896.0010000000002 },
                    { 18, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 19, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.302 },
                    { 20, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.915 },
                    { 21, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.5919999999999996 },
                    { 22, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 23, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.909000000000006 },
                    { 24, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.305 },
                    { 25, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.242 },
                    { 26, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 27, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.3480000000000001 },
                    { 28, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2836.9920000000002 },
                    { 29, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.84599999999999997 },
                    { 30, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 912.33000000000004 },
                    { 31, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.0970000000000004 },
                    { 32, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4088.5039999999999 },
                    { 33, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 521.51999999999998 },
                    { 34, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 35, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.495000000000005 },
                    { 36, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.611000000000001 },
                    { 37, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 38, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7320000000000002 },
                    { 39, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.636000000000003 },
                    { 40, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.88999999999999 },
                    { 41, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.618000000000002 },
                    { 42, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 43, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 110.565 },
                    { 44, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90200000000000002 },
                    { 45, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.1949999999999998 },
                    { 46, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.75900000000000001 },
                    { 47, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7320000000000002 },
                    { 48, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.75900000000000001 },
                    { 49, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.6909999999999998 },
                    { 50, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.75900000000000001 },
                    { 51, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.757 },
                    { 52, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.75900000000000001 },
                    { 53, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.498999999999995 },
                    { 54, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8654.3700000000008 },
                    { 55, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7279999999999998 },
                    { 56, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.09899999999999 },
                    { 57, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.798 },
                    { 58, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.780999999999999 },
                    { 59, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.7990000000000004 },
                    { 60, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.66999999999999 },
                    { 61, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 354.45400000000001 },
                    { 62, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15447.316000000001 },
                    { 63, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.6629999999999998 },
                    { 64, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.75900000000000001 },
                    { 65, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.909000000000006 },
                    { 66, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1308.383 },
                    { 67, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42015.239000000001 },
                    { 68, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 137.911 },
                    { 69, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.75900000000000001 },
                    { 70, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.24000000000001 },
                    { 71, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 72, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 144.893 },
                    { 73, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.83000000000001 },
                    { 74, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.072000000000003 },
                    { 75, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4062.3710000000001 },
                    { 76, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.4710000000000001 },
                    { 77, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 443.916 },
                    { 78, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1332.6210000000001 },
                    { 79, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30499999999999999 },
                    { 80, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 81, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 481.70699999999999 },
                    { 82, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 21989.467000000001 },
                    { 83, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 84, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 300.04399999999998 },
                    { 85, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 195.107 },
                    { 86, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.739000000000001 },
                    { 87, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.758 },
                    { 88, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.6839999999999993 },
                    { 89, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.361000000000001 },
                    { 90, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4543.4989999999998 },
                    { 91, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.097999999999999 },
                    { 92, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2099.9630000000002 },
                    { 93, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3412.8820000000001 },
                    { 94, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.032 },
                    { 95, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.719999999999999 },
                    { 96, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.310000000000002 },
                    { 97, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.446 },
                    { 98, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1740.1300000000001 },
                    { 99, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.835000000000001 },
                    { 100, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3150000000000004 },
                    { 101, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.901000000000003 },
                    { 102, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.739000000000001 },
                    { 103, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1589.1089999999999 },
                    { 104, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.798999999999999 },
                    { 105, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.5 },
                    { 106, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.25399999999999 },
                    { 107, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.5960000000000001 },
                    { 108, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 109, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 110, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7450000000000001 },
                    { 111, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.915 },
                    { 112, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.201000000000001 },
                    { 113, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.62599999999998 },
                    { 114, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.8660000000000001 },
                    { 115, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7603.0799999999999 },
                    { 116, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 117, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.4889999999999999 },
                    { 118, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.464 },
                    { 119, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 91.641000000000005 },
                    { 120, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1339.4390000000001 },
                    { 121, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 122, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.4979999999999993 },
                    { 123, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.603999999999999 },
                    { 124, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 511.411 },
                    { 125, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.223000000000001 },
                    { 126, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.302 },
                    { 127, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.75900000000000001 },
                    { 128, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.603999999999999 },
                    { 129, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22604.060000000001 },
                    { 130, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.45000000000005 },
                    { 131, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 28.916 },
                    { 132, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 2885.9079999999999 },
                    { 133, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.106999999999999 },
                    { 134, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 13105.294 },
                    { 135, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.739000000000001 },
                    { 136, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 33.950000000000003 },
                    { 137, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.608000000000001 },
                    { 138, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.4990000000000001 },
                    { 139, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0510000000000002 },
                    { 140, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.319 },
                    { 141, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 34.079999999999998 },
                    { 142, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7549999999999999 },
                    { 143, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.4710000000000001 },
                    { 144, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 31.832000000000001 },
                    { 145, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2702.5039999999999 },
                    { 146, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.225000000000001 },
                    { 147, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3717.1959999999999 },
                    { 148, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.262 },
                    { 149, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12658.368 },
                    { 150, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.625999999999998 },
                    { 151, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24889.925999999999 },
                    { 152, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 118.20999999999999 },
                    { 153, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7050000000000001 },
                    { 154, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 591.88800000000003 },
                    { 155, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 156, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74299999999999999 },
                    { 157, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 591.88800000000003 },
                    { 158, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.67700000000001 },
                    { 159, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.26400000000001 },
                    { 160, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.739999999999998 },
                    { 161, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.045000000000002 },
                    { 162, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.839 },
                    { 163, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 164, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 165, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.686999999999998 },
                    { 166, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 89.962000000000003 },
                    { 167, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.73099999999999 },
                    { 168, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 169, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 926.32500000000005 },
                    { 170, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 950.66999999999996 },
                    { 171, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.4710000000000001 },
                    { 172, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 173, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.7 },
                    { 174, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.7649999999999999 },
                    { 175, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 176, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.44799999999999 },
                    { 177, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.7649999999999999 },
                    { 178, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 179, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2896.0010000000002 },
                    { 180, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 181, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.302 },
                    { 182, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.915 },
                    { 183, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.5919999999999996 },
                    { 184, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 185, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.909000000000006 },
                    { 186, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.305 },
                    { 187, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.242 },
                    { 188, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 189, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.3480000000000001 },
                    { 190, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2836.9920000000002 },
                    { 191, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.84599999999999997 },
                    { 192, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 912.33000000000004 },
                    { 193, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.0970000000000004 },
                    { 194, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4088.5039999999999 },
                    { 195, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 521.51999999999998 },
                    { 196, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 197, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.495000000000005 },
                    { 198, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.611000000000001 },
                    { 199, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 200, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7320000000000002 },
                    { 201, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.636000000000003 },
                    { 202, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.88999999999999 },
                    { 203, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.618000000000002 },
                    { 204, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 205, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 110.565 },
                    { 206, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90200000000000002 },
                    { 207, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.1949999999999998 },
                    { 208, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.75900000000000001 },
                    { 209, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7320000000000002 },
                    { 210, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.75900000000000001 },
                    { 211, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.6909999999999998 },
                    { 212, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.75900000000000001 },
                    { 213, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.757 },
                    { 214, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.75900000000000001 },
                    { 215, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.498999999999995 },
                    { 216, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8654.3700000000008 },
                    { 217, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7279999999999998 },
                    { 218, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.09899999999999 },
                    { 219, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.798 },
                    { 220, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.780999999999999 },
                    { 221, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.7990000000000004 },
                    { 222, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.66999999999999 },
                    { 223, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 354.45400000000001 },
                    { 224, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15447.316000000001 },
                    { 225, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.6629999999999998 },
                    { 226, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.75900000000000001 },
                    { 227, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.909000000000006 },
                    { 228, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1308.383 },
                    { 229, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42015.239000000001 },
                    { 230, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 137.911 },
                    { 231, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.75900000000000001 },
                    { 232, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.24000000000001 },
                    { 233, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 234, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 144.893 },
                    { 235, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.83000000000001 },
                    { 236, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.072000000000003 },
                    { 237, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4062.3710000000001 },
                    { 238, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.4710000000000001 },
                    { 239, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 443.916 },
                    { 240, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1332.6210000000001 },
                    { 241, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30499999999999999 },
                    { 242, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 243, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 481.70699999999999 },
                    { 244, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 21989.467000000001 },
                    { 245, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 246, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 300.04399999999998 },
                    { 247, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 195.107 },
                    { 248, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.739000000000001 },
                    { 249, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.758 },
                    { 250, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.6839999999999993 },
                    { 251, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.361000000000001 },
                    { 252, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4543.4989999999998 },
                    { 253, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.097999999999999 },
                    { 254, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2099.9630000000002 },
                    { 255, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3412.8820000000001 },
                    { 256, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.032 },
                    { 257, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.719999999999999 },
                    { 258, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.310000000000002 },
                    { 259, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.446 },
                    { 260, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1740.1300000000001 },
                    { 261, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.835000000000001 },
                    { 262, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3150000000000004 },
                    { 263, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.901000000000003 },
                    { 264, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.739000000000001 },
                    { 265, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1589.1089999999999 },
                    { 266, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.798999999999999 },
                    { 267, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.5 },
                    { 268, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.25399999999999 },
                    { 269, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.5960000000000001 },
                    { 270, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 271, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 272, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7450000000000001 },
                    { 273, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.915 },
                    { 274, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.201000000000001 },
                    { 275, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.62599999999998 },
                    { 276, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.8660000000000001 },
                    { 277, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7603.0799999999999 },
                    { 278, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 279, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.4889999999999999 },
                    { 280, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.464 },
                    { 281, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 91.641000000000005 },
                    { 282, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1339.4390000000001 },
                    { 283, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 284, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.4979999999999993 },
                    { 285, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.603999999999999 },
                    { 286, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 511.411 },
                    { 287, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.223000000000001 },
                    { 288, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.302 },
                    { 289, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.75900000000000001 },
                    { 290, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.603999999999999 },
                    { 291, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22604.060000000001 },
                    { 292, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.45000000000005 },
                    { 293, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 28.916 },
                    { 294, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 2885.9079999999999 },
                    { 295, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.106999999999999 },
                    { 296, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 13105.294 },
                    { 297, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.739000000000001 },
                    { 298, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 33.950000000000003 },
                    { 299, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.608000000000001 },
                    { 300, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.4990000000000001 },
                    { 301, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0510000000000002 },
                    { 302, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.319 },
                    { 303, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 34.079999999999998 },
                    { 304, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7549999999999999 },
                    { 305, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.4710000000000001 },
                    { 306, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 31.832000000000001 },
                    { 307, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2702.5039999999999 },
                    { 308, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.225000000000001 },
                    { 309, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3717.1959999999999 },
                    { 310, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.262 },
                    { 311, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12658.368 },
                    { 312, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.625999999999998 },
                    { 313, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24889.925999999999 },
                    { 314, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 118.20999999999999 },
                    { 315, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7050000000000001 },
                    { 316, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 591.88800000000003 },
                    { 317, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 318, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74299999999999999 },
                    { 319, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 591.88800000000003 },
                    { 320, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.67700000000001 },
                    { 321, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.26400000000001 },
                    { 322, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.739999999999998 },
                    { 323, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.045000000000002 },
                    { 324, new DateTime(2024, 8, 30, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.839 },
                    { 325, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 326, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 327, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.596999999999994 },
                    { 328, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 90.027000000000001 },
                    { 329, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.64999999999998 },
                    { 330, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 331, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 919.15499999999997 },
                    { 332, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 952.83000000000004 },
                    { 333, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.4770000000000001 },
                    { 334, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 335, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.6990000000000001 },
                    { 336, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.77 },
                    { 337, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 338, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.464 },
                    { 339, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.77 },
                    { 340, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 341, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2878.9290000000001 },
                    { 342, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 343, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.306 },
                    { 344, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.9189999999999996 },
                    { 345, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.6130000000000004 },
                    { 346, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 347, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.906999999999996 },
                    { 348, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.273 },
                    { 349, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.2559999999999998 },
                    { 350, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 351, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.349 },
                    { 352, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2846.4760000000001 },
                    { 353, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.84999999999999998 },
                    { 354, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 913.928 },
                    { 355, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.101 },
                    { 356, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4145.0140000000001 },
                    { 357, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 519.05600000000004 },
                    { 358, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 359, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.778999999999996 },
                    { 360, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.638000000000002 },
                    { 361, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 362, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7519999999999998 },
                    { 363, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.609999999999999 },
                    { 364, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.90100000000001 },
                    { 365, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.595999999999997 },
                    { 366, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 367, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 111.155 },
                    { 368, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90500000000000003 },
                    { 369, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.2000000000000002 },
                    { 370, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.76200000000000001 },
                    { 371, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7510000000000003 },
                    { 372, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.76200000000000001 },
                    { 373, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.6899999999999999 },
                    { 374, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.76200000000000001 },
                    { 375, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.673 },
                    { 376, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.76200000000000001 },
                    { 377, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.138000000000005 },
                    { 378, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8699.0229999999992 },
                    { 379, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7290000000000001 },
                    { 380, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.23699999999999 },
                    { 381, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.798 },
                    { 382, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.788 },
                    { 383, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.8179999999999996 },
                    { 384, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.71899999999999 },
                    { 385, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 354.93299999999999 },
                    { 386, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15503.936 },
                    { 387, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.6469999999999998 },
                    { 388, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.76200000000000001 },
                    { 389, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.905000000000001 },
                    { 390, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1309.386 },
                    { 391, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42012.987999999998 },
                    { 392, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 138.179 },
                    { 393, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.76200000000000001 },
                    { 394, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.05799999999999 },
                    { 395, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 396, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 146.239 },
                    { 397, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.75700000000001 },
                    { 398, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.114000000000004 },
                    { 399, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4067.4059999999999 },
                    { 400, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.4770000000000001 },
                    { 401, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 445.18299999999999 },
                    { 402, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1335.962 },
                    { 403, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30499999999999999 },
                    { 404, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 405, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 481.92000000000002 },
                    { 406, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 21913.966 },
                    { 407, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 408, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 298.935 },
                    { 409, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 195.05600000000001 },
                    { 410, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.809000000000001 },
                    { 411, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.7599999999999998 },
                    { 412, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.7439999999999998 },
                    { 413, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.401 },
                    { 414, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4541.9700000000003 },
                    { 415, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.396000000000001 },
                    { 416, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2101.1640000000002 },
                    { 417, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3352.2979999999998 },
                    { 418, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.032 },
                    { 419, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.771000000000001 },
                    { 420, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.395000000000003 },
                    { 421, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.439 },
                    { 422, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1735.96 },
                    { 423, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.722999999999999 },
                    { 424, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3200000000000003 },
                    { 425, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.676000000000002 },
                    { 426, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.809000000000001 },
                    { 427, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1594.4100000000001 },
                    { 428, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.899000000000001 },
                    { 429, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.602 },
                    { 430, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.25200000000001 },
                    { 431, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.601 },
                    { 432, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 433, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 434, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7480000000000002 },
                    { 435, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.8980000000000001 },
                    { 436, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.201999999999998 },
                    { 437, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.76900000000001 },
                    { 438, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.8719999999999999 },
                    { 439, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7600.7610000000004 },
                    { 440, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 441, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.492 },
                    { 442, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.741 },
                    { 443, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 90.765000000000001 },
                    { 444, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1336.6489999999999 },
                    { 445, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 446, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.5129999999999999 },
                    { 447, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.814 },
                    { 448, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 458.88400000000001 },
                    { 449, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.265000000000001 },
                    { 450, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.304 },
                    { 451, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.76200000000000001 },
                    { 452, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.603999999999999 },
                    { 453, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22604.060000000001 },
                    { 454, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.31399999999996 },
                    { 455, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 28.995000000000001 },
                    { 456, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 3130.9769999999999 },
                    { 457, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.170000000000002 },
                    { 458, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 12852.758 },
                    { 459, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.809000000000001 },
                    { 460, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 34.07 },
                    { 461, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.606 },
                    { 462, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.5 },
                    { 463, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0510000000000002 },
                    { 464, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.298 },
                    { 465, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 34.097999999999999 },
                    { 466, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7709999999999999 },
                    { 467, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.4770000000000001 },
                    { 468, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 31.925000000000001 },
                    { 469, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2719.8339999999998 },
                    { 470, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.045999999999999 },
                    { 471, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3720.1849999999999 },
                    { 472, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.345999999999997 },
                    { 473, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12697.01 },
                    { 474, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.645000000000003 },
                    { 475, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24877.772000000001 },
                    { 476, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 117.804 },
                    { 477, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7040000000000002 },
                    { 478, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 593.57799999999997 },
                    { 479, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 480, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74299999999999999 },
                    { 481, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 593.57799999999997 },
                    { 482, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.98399999999999 },
                    { 483, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.255 },
                    { 484, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.812000000000001 },
                    { 485, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.207000000000001 },
                    { 486, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.855 },
                    { 487, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 488, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 489, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.596999999999994 },
                    { 490, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 90.027000000000001 },
                    { 491, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.64999999999998 },
                    { 492, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 493, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 919.15499999999997 },
                    { 494, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 952.83000000000004 },
                    { 495, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.4770000000000001 },
                    { 496, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 497, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.6990000000000001 },
                    { 498, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.77 },
                    { 499, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 500, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.464 },
                    { 501, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.77 },
                    { 502, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 503, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2878.9290000000001 },
                    { 504, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 505, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.306 },
                    { 506, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.9189999999999996 },
                    { 507, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.6130000000000004 },
                    { 508, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 509, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.906999999999996 },
                    { 510, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.273 },
                    { 511, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.2559999999999998 },
                    { 512, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 513, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.349 },
                    { 514, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2846.4760000000001 },
                    { 515, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.84999999999999998 },
                    { 516, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 913.928 },
                    { 517, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.101 },
                    { 518, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4145.0140000000001 },
                    { 519, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 519.05600000000004 },
                    { 520, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 521, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.778999999999996 },
                    { 522, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.638000000000002 },
                    { 523, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 524, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7519999999999998 },
                    { 525, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.609999999999999 },
                    { 526, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.90100000000001 },
                    { 527, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.595999999999997 },
                    { 528, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 529, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 111.155 },
                    { 530, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90500000000000003 },
                    { 531, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.2000000000000002 },
                    { 532, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.76200000000000001 },
                    { 533, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7510000000000003 },
                    { 534, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.76200000000000001 },
                    { 535, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.6899999999999999 },
                    { 536, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.76200000000000001 },
                    { 537, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.673 },
                    { 538, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.76200000000000001 },
                    { 539, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.138000000000005 },
                    { 540, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8699.0229999999992 },
                    { 541, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7290000000000001 },
                    { 542, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.23699999999999 },
                    { 543, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.798 },
                    { 544, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.788 },
                    { 545, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.8179999999999996 },
                    { 546, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.71899999999999 },
                    { 547, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 354.93299999999999 },
                    { 548, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15503.936 },
                    { 549, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.6469999999999998 },
                    { 550, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.76200000000000001 },
                    { 551, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.905000000000001 },
                    { 552, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1309.386 },
                    { 553, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42012.987999999998 },
                    { 554, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 138.179 },
                    { 555, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.76200000000000001 },
                    { 556, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.05799999999999 },
                    { 557, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 558, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 146.239 },
                    { 559, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.75700000000001 },
                    { 560, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.114000000000004 },
                    { 561, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4067.4059999999999 },
                    { 562, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.4770000000000001 },
                    { 563, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 445.18299999999999 },
                    { 564, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1335.962 },
                    { 565, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30499999999999999 },
                    { 566, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 567, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 481.92000000000002 },
                    { 568, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 21913.966 },
                    { 569, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 570, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 298.935 },
                    { 571, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 195.05600000000001 },
                    { 572, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.809000000000001 },
                    { 573, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.7599999999999998 },
                    { 574, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.7439999999999998 },
                    { 575, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.401 },
                    { 576, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4541.9700000000003 },
                    { 577, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.396000000000001 },
                    { 578, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2101.1640000000002 },
                    { 579, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3352.2979999999998 },
                    { 580, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.032 },
                    { 581, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.771000000000001 },
                    { 582, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.395000000000003 },
                    { 583, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.439 },
                    { 584, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1735.96 },
                    { 585, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.722999999999999 },
                    { 586, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3200000000000003 },
                    { 587, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.676000000000002 },
                    { 588, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.809000000000001 },
                    { 589, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1594.4100000000001 },
                    { 590, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.899000000000001 },
                    { 591, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.602 },
                    { 592, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.25200000000001 },
                    { 593, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.601 },
                    { 594, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 595, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 596, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7480000000000002 },
                    { 597, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.8980000000000001 },
                    { 598, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.201999999999998 },
                    { 599, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.76900000000001 },
                    { 600, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.8719999999999999 },
                    { 601, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7600.7610000000004 },
                    { 602, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 603, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.492 },
                    { 604, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.741 },
                    { 605, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 90.765000000000001 },
                    { 606, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1336.6489999999999 },
                    { 607, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 608, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.5129999999999999 },
                    { 609, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.814 },
                    { 610, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 458.88400000000001 },
                    { 611, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.265000000000001 },
                    { 612, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.304 },
                    { 613, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.76200000000000001 },
                    { 614, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.603999999999999 },
                    { 615, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22604.060000000001 },
                    { 616, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.31399999999996 },
                    { 617, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 28.995000000000001 },
                    { 618, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 3130.9769999999999 },
                    { 619, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.170000000000002 },
                    { 620, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 12852.758 },
                    { 621, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.809000000000001 },
                    { 622, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 34.07 },
                    { 623, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.606 },
                    { 624, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.5 },
                    { 625, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0510000000000002 },
                    { 626, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.298 },
                    { 627, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 34.097999999999999 },
                    { 628, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7709999999999999 },
                    { 629, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.4770000000000001 },
                    { 630, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 31.925000000000001 },
                    { 631, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2719.8339999999998 },
                    { 632, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.045999999999999 },
                    { 633, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3720.1849999999999 },
                    { 634, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.345999999999997 },
                    { 635, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12697.01 },
                    { 636, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.645000000000003 },
                    { 637, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24877.772000000001 },
                    { 638, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 117.804 },
                    { 639, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7040000000000002 },
                    { 640, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 593.57799999999997 },
                    { 641, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 642, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74299999999999999 },
                    { 643, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 593.57799999999997 },
                    { 644, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.98399999999999 },
                    { 645, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.255 },
                    { 646, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.812000000000001 },
                    { 647, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.207000000000001 },
                    { 648, new DateTime(2024, 9, 2, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.855 },
                    { 649, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 650, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 651, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.503 },
                    { 652, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 90.219999999999999 },
                    { 653, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.65100000000001 },
                    { 654, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 655, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 922.024 },
                    { 656, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 952.75 },
                    { 657, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.474 },
                    { 658, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 659, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.7 },
                    { 660, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.768 },
                    { 661, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 662, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.515 },
                    { 663, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.768 },
                    { 664, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 665, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2904.835 },
                    { 666, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 667, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.3069999999999999 },
                    { 668, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.9279999999999999 },
                    { 669, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.6150000000000002 },
                    { 670, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 671, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.933999999999997 },
                    { 672, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.337 },
                    { 673, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.2330000000000001 },
                    { 674, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 675, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.3500000000000001 },
                    { 676, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2840.2829999999999 },
                    { 677, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.85099999999999998 },
                    { 678, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 913.47900000000004 },
                    { 679, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.1109999999999998 },
                    { 680, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4178.8379999999997 },
                    { 681, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 519.57000000000005 },
                    { 682, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 683, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.677999999999997 },
                    { 684, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.622 },
                    { 685, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 686, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7430000000000003 },
                    { 687, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.698 },
                    { 688, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.845 },
                    { 689, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.542999999999999 },
                    { 690, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 691, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 111.108 },
                    { 692, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90400000000000003 },
                    { 693, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.202 },
                    { 694, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.76100000000000001 },
                    { 695, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7430000000000003 },
                    { 696, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.76100000000000001 },
                    { 697, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.6890000000000001 },
                    { 698, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.76100000000000001 },
                    { 699, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.782999999999999 },
                    { 700, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.76100000000000001 },
                    { 701, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.531999999999996 },
                    { 702, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8669.5570000000007 },
                    { 703, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7359999999999998 },
                    { 704, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.24600000000001 },
                    { 705, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.7969999999999997 },
                    { 706, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.800000000000001 },
                    { 707, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.8109999999999999 },
                    { 708, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.78200000000001 },
                    { 709, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 354.71100000000001 },
                    { 710, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15547.826999999999 },
                    { 711, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.6480000000000001 },
                    { 712, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.76100000000000001 },
                    { 713, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.930000000000007 },
                    { 714, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1309.4079999999999 },
                    { 715, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42061.620999999999 },
                    { 716, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 138.45099999999999 },
                    { 717, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.76100000000000001 },
                    { 718, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.06800000000001 },
                    { 719, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 720, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 146.78899999999999 },
                    { 721, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.74600000000001 },
                    { 722, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.188000000000002 },
                    { 723, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4067.6379999999999 },
                    { 724, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.474 },
                    { 725, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 444.73399999999998 },
                    { 726, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1338.1079999999999 },
                    { 727, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30599999999999999 },
                    { 728, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 729, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 482.91300000000001 },
                    { 730, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 21967.332999999999 },
                    { 731, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 732, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 298.81099999999998 },
                    { 733, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 195.178 },
                    { 734, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.838000000000001 },
                    { 735, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.7599999999999998 },
                    { 736, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.7759999999999998 },
                    { 737, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.428000000000001 },
                    { 738, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4542.1369999999997 },
                    { 739, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.375999999999998 },
                    { 740, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2101.6329999999998 },
                    { 741, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3353.1970000000001 },
                    { 742, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.0310000000000006 },
                    { 743, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.774000000000001 },
                    { 744, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.408999999999999 },
                    { 745, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.444000000000001 },
                    { 746, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1743.203 },
                    { 747, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.829999999999998 },
                    { 748, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3490000000000002 },
                    { 749, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.914000000000001 },
                    { 750, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.838000000000001 },
                    { 751, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1589.203 },
                    { 752, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.831000000000003 },
                    { 753, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.593 },
                    { 754, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.29400000000001 },
                    { 755, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.6060000000000001 },
                    { 756, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 757, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 758, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7530000000000001 },
                    { 759, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.9340000000000002 },
                    { 760, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.500999999999998 },
                    { 761, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.84300000000002 },
                    { 762, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.859 },
                    { 763, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7657.1790000000001 },
                    { 764, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 765, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.4960000000000004 },
                    { 766, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.774 },
                    { 767, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 89.879999999999995 },
                    { 768, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1346.3030000000001 },
                    { 769, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 770, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.5 },
                    { 771, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.551 },
                    { 772, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 454.37599999999998 },
                    { 773, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.252000000000001 },
                    { 774, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.3069999999999999 },
                    { 775, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.76100000000000001 },
                    { 776, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.603999999999999 },
                    { 777, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22604.060000000001 },
                    { 778, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.327 },
                    { 779, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 28.998000000000001 },
                    { 780, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 3237.672 },
                    { 781, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.148 },
                    { 782, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 12869.239 },
                    { 783, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.838000000000001 },
                    { 784, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 34.170999999999999 },
                    { 785, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.632 },
                    { 786, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.5 },
                    { 787, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0499999999999998 },
                    { 788, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.298 },
                    { 789, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 33.936999999999998 },
                    { 790, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7430000000000003 },
                    { 791, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.474 },
                    { 792, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 32.006 },
                    { 793, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2716.3899999999999 },
                    { 794, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.143999999999998 },
                    { 795, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3722.172 },
                    { 796, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.378 },
                    { 797, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12667.01 },
                    { 798, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.639000000000003 },
                    { 799, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24891.249 },
                    { 800, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 117.971 },
                    { 801, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7040000000000002 },
                    { 802, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 592.97799999999995 },
                    { 803, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 804, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74299999999999999 },
                    { 805, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 592.97799999999995 },
                    { 806, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.875 },
                    { 807, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.31899999999999 },
                    { 808, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.831 },
                    { 809, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.221 },
                    { 810, new DateTime(2024, 9, 3, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.859999999999999 },
                    { 811, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "USD", 1.0 },
                    { 812, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AED", 3.673 },
                    { 813, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AFN", 70.319000000000003 },
                    { 814, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ALL", 90.332999999999998 },
                    { 815, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AMD", 387.55799999999999 },
                    { 816, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ANG", 1.79 },
                    { 817, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AOA", 925.54700000000003 },
                    { 818, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ARS", 954.5 },
                    { 819, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AUD", 1.4890000000000001 },
                    { 820, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AWG", 1.79 },
                    { 821, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "AZN", 1.7010000000000001 },
                    { 822, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BAM", 1.7669999999999999 },
                    { 823, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BBD", 2.0 },
                    { 824, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BDT", 119.51300000000001 },
                    { 825, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BGN", 1.7669999999999999 },
                    { 826, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BHD", 0.376 },
                    { 827, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BIF", 2885.1579999999999 },
                    { 828, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BMD", 1.0 },
                    { 829, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BND", 1.3049999999999999 },
                    { 830, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BOB", 6.9290000000000003 },
                    { 831, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BRL", 5.6420000000000003 },
                    { 832, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BSD", 1.0 },
                    { 833, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BTN", 83.989999999999995 },
                    { 834, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BWP", 13.375999999999999 },
                    { 835, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BYN", 3.23 },
                    { 836, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "BZD", 2.0 },
                    { 837, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CAD", 1.3520000000000001 },
                    { 838, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CDF", 2829.8049999999998 },
                    { 839, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CHF", 0.84799999999999998 },
                    { 840, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CLP", 928.42200000000003 },
                    { 841, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CNY", 7.1109999999999998 },
                    { 842, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "COP", 4183.1760000000004 },
                    { 843, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CRC", 518.34299999999996 },
                    { 844, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CUP", 24.0 },
                    { 845, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CVE", 99.614999999999995 },
                    { 846, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "CZK", 22.649999999999999 },
                    { 847, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "DJF", 177.721 },
                    { 848, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "DKK", 6.7370000000000001 },
                    { 849, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "DOP", 59.673999999999999 },
                    { 850, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "DZD", 133.291 },
                    { 851, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "EGP", 48.484000000000002 },
                    { 852, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ERN", 15.0 },
                    { 853, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ETB", 111.48099999999999 },
                    { 854, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "EUR", 0.90300000000000002 },
                    { 855, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "FJD", 2.2170000000000001 },
                    { 856, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "FKP", 0.76100000000000001 },
                    { 857, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "FOK", 6.7350000000000003 },
                    { 858, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GBP", 0.76100000000000001 },
                    { 859, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GEL", 2.694 },
                    { 860, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GGP", 0.76100000000000001 },
                    { 861, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GHS", 15.746 },
                    { 862, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GIP", 0.76100000000000001 },
                    { 863, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GMD", 70.561000000000007 },
                    { 864, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GNF", 8663.3899999999994 },
                    { 865, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GTQ", 7.7350000000000003 },
                    { 866, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "GYD", 209.28399999999999 },
                    { 867, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "HKD", 7.7969999999999997 },
                    { 868, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "HNL", 24.780999999999999 },
                    { 869, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "HRK", 6.8070000000000004 },
                    { 870, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "HTG", 131.721 },
                    { 871, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "HUF", 355.29700000000003 },
                    { 872, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "IDR", 15489.531999999999 },
                    { 873, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ILS", 3.694 },
                    { 874, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "IMP", 0.76100000000000001 },
                    { 875, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "INR", 83.991 },
                    { 876, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "IQD", 1310.2149999999999 },
                    { 877, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "IRR", 42084.900000000001 },
                    { 878, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ISK", 138.92599999999999 },
                    { 879, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "JEP", 0.76100000000000001 },
                    { 880, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "JMD", 157.131 },
                    { 881, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "JOD", 0.70899999999999996 },
                    { 882, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "JPY", 144.215 },
                    { 883, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KES", 128.91300000000001 },
                    { 884, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KGS", 85.063000000000002 },
                    { 885, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KHR", 4063.6509999999998 },
                    { 886, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KID", 1.4890000000000001 },
                    { 887, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KMF", 444.452 },
                    { 888, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KRW", 1338.3440000000001 },
                    { 889, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KWD", 0.30599999999999999 },
                    { 890, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KYD", 0.83299999999999996 },
                    { 891, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "KZT", 483.37299999999999 },
                    { 892, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LAK", 22020.466 },
                    { 893, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LBP", 89500.0 },
                    { 894, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LKR", 298.81900000000002 },
                    { 895, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LRD", 194.803 },
                    { 896, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LSL", 17.887 },
                    { 897, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "LYD", 4.7619999999999996 },
                    { 898, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MAD", 9.7560000000000002 },
                    { 899, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MDL", 17.484000000000002 },
                    { 900, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MGA", 4553.3540000000003 },
                    { 901, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MKD", 55.704999999999998 },
                    { 902, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MMK", 2101.1849999999999 },
                    { 903, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MNT", 3413.116 },
                    { 904, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MOP", 8.0310000000000006 },
                    { 905, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MRU", 39.777999999999999 },
                    { 906, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MUR", 46.131 },
                    { 907, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MVR", 15.455 },
                    { 908, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MWK", 1739.8530000000001 },
                    { 909, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MXN", 19.908000000000001 },
                    { 910, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MYR", 4.3529999999999998 },
                    { 911, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "MZN", 63.921999999999997 },
                    { 912, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NAD", 17.887 },
                    { 913, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NGN", 1592.1569999999999 },
                    { 914, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NIO", 36.817 },
                    { 915, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NOK", 10.654999999999999 },
                    { 916, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NPR", 134.38499999999999 },
                    { 917, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "NZD", 1.615 },
                    { 918, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "OMR", 0.38500000000000001 },
                    { 919, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PAB", 1.0 },
                    { 920, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PEN", 3.7909999999999999 },
                    { 921, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PGK", 3.9540000000000002 },
                    { 922, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PHP", 56.454000000000001 },
                    { 923, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PKR", 278.86900000000003 },
                    { 924, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PLN", 3.8650000000000002 },
                    { 925, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "PYG", 7683.6260000000002 },
                    { 926, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "QAR", 3.6400000000000001 },
                    { 927, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "RON", 4.5 },
                    { 928, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "RSD", 105.87 },
                    { 929, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "RUB", 88.343000000000004 },
                    { 930, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "RWF", 1345.3820000000001 },
                    { 931, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SAR", 3.75 },
                    { 932, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SBD", 8.5009999999999994 },
                    { 933, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SCR", 13.635 },
                    { 934, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SDG", 544.50599999999997 },
                    { 935, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SEK", 10.282 },
                    { 936, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SGD", 1.3049999999999999 },
                    { 937, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SHP", 0.76100000000000001 },
                    { 938, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLE", 22.512 },
                    { 939, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SLL", 22512.031999999999 },
                    { 940, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SOS", 571.61599999999999 },
                    { 941, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SRD", 29.236999999999998 },
                    { 942, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SSP", 3157.3890000000001 },
                    { 943, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "STN", 22.134 },
                    { 944, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SYP", 12928.641 },
                    { 945, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "SZL", 17.887 },
                    { 946, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "THB", 34.100000000000001 },
                    { 947, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TJS", 10.646000000000001 },
                    { 948, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TMT", 3.4990000000000001 },
                    { 949, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TND", 3.0499999999999998 },
                    { 950, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TOP", 2.3290000000000002 },
                    { 951, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TRY", 34.064999999999998 },
                    { 952, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TTD", 6.7569999999999997 },
                    { 953, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TVD", 1.4890000000000001 },
                    { 954, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TWD", 32.079000000000001 },
                    { 955, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "TZS", 2717.0390000000002 },
                    { 956, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "UAH", 41.240000000000002 },
                    { 957, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "UGX", 3722.9369999999999 },
                    { 958, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "UYU", 40.317 },
                    { 959, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "UZS", 12670.056 },
                    { 960, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "VES", 36.643999999999998 },
                    { 961, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "VND", 24887.487000000001 },
                    { 962, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "VUV", 118.53400000000001 },
                    { 963, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "WST", 2.7080000000000002 },
                    { 964, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "XAF", 592.60299999999995 },
                    { 965, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "XCD", 2.7000000000000002 },
                    { 966, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "XDR", 0.74399999999999999 },
                    { 967, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "XOF", 592.60299999999995 },
                    { 968, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "XPF", 107.807 },
                    { 969, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "YER", 250.34399999999999 },
                    { 970, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZAR", 17.878 },
                    { 971, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZMW", 26.363 },
                    { 972, new DateTime(2024, 9, 5, 2, 0, 2, 0, DateTimeKind.Unspecified), "ZWL", 13.869999999999999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 856);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 857);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 859);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 861);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 863);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 864);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 865);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 866);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 867);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 868);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 869);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 870);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 871);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 872);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 873);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 874);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 875);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 877);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 879);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 880);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 881);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 883);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 884);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 885);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 886);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 888);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 889);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 890);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 893);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 894);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 895);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 896);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 897);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 898);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 904);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 905);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 906);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 907);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 908);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 909);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 911);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 913);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 914);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 915);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 916);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 917);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 918);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 919);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 920);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 921);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 923);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 924);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 925);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 926);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 927);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 928);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 929);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 930);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 931);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 932);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 933);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 934);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 936);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 937);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 938);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 939);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 940);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 941);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 942);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 943);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 944);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 945);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 946);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 947);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 948);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 949);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 951);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 952);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 953);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 954);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 955);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 956);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 957);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 958);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 959);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 960);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 961);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 962);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 963);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 964);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 965);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 966);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 967);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 968);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 969);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 970);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 971);

            migrationBuilder.DeleteData(
                table: "Divisa",
                keyColumn: "DivisaId",
                keyValue: 972);
        }
    }
}

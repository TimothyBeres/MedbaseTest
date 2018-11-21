using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Open.Infra.Migrations
{
    public partial class Sentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effect", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    AtcCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FormOfInjection = table.Column<string>(nullable: true),
                    Strength = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    LegalStatus = table.Column<string>(nullable: true),
                    Spc = table.Column<string>(nullable: true),
                    Pil = table.Column<string>(nullable: true),
                    Reimbursement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    IDCode = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CityOrAreaCode = table.Column<string>(nullable: true),
                    RegionOrStateOrCountryCode = table.Column<string>(nullable: true),
                    ZipOrPostCodeOrExtension = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: true),
                    NationalDirectDialingPrefix = table.Column<string>(nullable: true),
                    Device = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    CountryID = table.Column<string>(nullable: false),
                    CurrencyID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountryID, x.CurrencyID });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currency_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineEffects",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    MedicineID = table.Column<string>(nullable: false),
                    EffectID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineEffects", x => new { x.EffectID, x.MedicineID });
                    table.ForeignKey(
                        name: "FK_MedicineEffects_Effect_EffectID",
                        column: x => x.EffectID,
                        principalTable: "Effect",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicineEffects_Medicine_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonMedicines",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    PersonID = table.Column<string>(nullable: false),
                    MedicineID = table.Column<string>(nullable: false),
                    SuitableForPerson = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMedicines", x => new { x.PersonID, x.MedicineID });
                    table.ForeignKey(
                        name: "FK_PersonMedicines_Medicine_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicine",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonMedicines_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TelecomDeviceRegistration",
                columns: table => new
                {
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    AddressID = table.Column<string>(nullable: false),
                    DeviceID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelecomDeviceRegistration", x => new { x.AddressID, x.DeviceID });
                    table.ForeignKey(
                        name: "FK_TelecomDeviceRegistration_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TelecomDeviceRegistration_Address_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryID",
                table: "Address",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrencyID",
                table: "CountryCurrency",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineEffects_MedicineID",
                table: "MedicineEffects",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMedicines_MedicineID",
                table: "PersonMedicines",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_TelecomDeviceRegistration_DeviceID",
                table: "TelecomDeviceRegistration",
                column: "DeviceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "MedicineEffects");

            migrationBuilder.DropTable(
                name: "PersonMedicines");

            migrationBuilder.DropTable(
                name: "TelecomDeviceRegistration");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

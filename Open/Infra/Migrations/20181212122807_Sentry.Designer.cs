﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Open.Infra;

namespace Open.Infra.Migrations
{
    [DbContext(typeof(SentryDbContext))]
    [Migration("20181212122807_Sentry")]
    partial class Sentry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Open.Data.Location.AddressDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CityOrAreaCode");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("RegionOrStateOrCountryCode");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<string>("ZipOrPostCodeOrExtension");

                    b.HasKey("ID");

                    b.ToTable("Address");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AddressDbRecord");
                });

            modelBuilder.Entity("Open.Data.Location.CountryDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Open.Data.Location.TelecomDeviceRegistrationDbRecord", b =>
                {
                    b.Property<string>("AddressID");

                    b.Property<string>("DeviceID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("AddressID", "DeviceID");

                    b.HasIndex("DeviceID");

                    b.ToTable("TelecomDeviceRegistration");
                });

            modelBuilder.Entity("Open.Data.Money.CountryCurrencyDbRecord", b =>
                {
                    b.Property<string>("CountryID");

                    b.Property<string>("CurrencyID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("CountryID", "CurrencyID");

                    b.HasIndex("CurrencyID");

                    b.ToTable("CountryCurrency");
                });

            modelBuilder.Entity("Open.Data.Money.CurrencyDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Open.Data.Person.PersonDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GetMedicineInfo");

                    b.Property<string>("IDCode");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Open.Data.Person.PersonMedicineDbRecord", b =>
                {
                    b.Property<string>("PersonID");

                    b.Property<string>("MedicineID");

                    b.Property<string>("SuitableForPerson");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("PersonID", "MedicineID");

                    b.HasIndex("MedicineID");

                    b.ToTable("PersonMedicines");
                });

            modelBuilder.Entity("Open.Data.Process.DosageDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MedicineID");

                    b.Property<string>("PersonID");

                    b.Property<int>("TypeOfTreatment");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Dosage");
                });

            modelBuilder.Entity("Open.Data.Process.SchemeDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<string>("DosageId");

                    b.Property<string>("Length");

                    b.Property<string>("QueueNr");

                    b.Property<string>("TimeOfDay");

                    b.Property<string>("Times");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Scheme");
                });

            modelBuilder.Entity("Open.Data.Product.EffectDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Effect");
                });

            modelBuilder.Entity("Open.Data.Product.MedicineDbRecord", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AtcCode");

                    b.Property<string>("FormOfInjection");

                    b.Property<string>("LegalStatus");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<string>("Pil");

                    b.Property<string>("Reimbursement");

                    b.Property<string>("Spc");

                    b.Property<string>("Strength");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("ID");

                    b.ToTable("Medicine");
                });

            modelBuilder.Entity("Open.Data.Product.MedicineEffectsDbRecord", b =>
                {
                    b.Property<string>("EffectID");

                    b.Property<string>("MedicineID");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("EffectID", "MedicineID");

                    b.HasIndex("MedicineID");

                    b.ToTable("MedicineEffects");
                });

            modelBuilder.Entity("Open.Data.Location.EmailAddressDbRecord", b =>
                {
                    b.HasBaseType("Open.Data.Location.AddressDbRecord");


                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("EmailAddressDbRecord");
                });

            modelBuilder.Entity("Open.Data.Location.GeographicAddressDbRecord", b =>
                {
                    b.HasBaseType("Open.Data.Location.AddressDbRecord");

                    b.Property<string>("CountryID");

                    b.HasIndex("CountryID");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("GeographicAddressDbRecord");
                });

            modelBuilder.Entity("Open.Data.Location.TelecomAddressDbRecord", b =>
                {
                    b.HasBaseType("Open.Data.Location.AddressDbRecord");

                    b.Property<int>("Device");

                    b.Property<string>("NationalDirectDialingPrefix");

                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("TelecomAddressDbRecord");
                });

            modelBuilder.Entity("Open.Data.Location.WebPageAddressDbRecord", b =>
                {
                    b.HasBaseType("Open.Data.Location.AddressDbRecord");


                    b.ToTable("Address");

                    b.HasDiscriminator().HasValue("WebPageAddressDbRecord");
                });

            modelBuilder.Entity("Open.Data.Location.TelecomDeviceRegistrationDbRecord", b =>
                {
                    b.HasOne("Open.Data.Location.GeographicAddressDbRecord", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Location.TelecomAddressDbRecord", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Money.CountryCurrencyDbRecord", b =>
                {
                    b.HasOne("Open.Data.Location.CountryDbRecord", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Money.CurrencyDbRecord", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Person.PersonMedicineDbRecord", b =>
                {
                    b.HasOne("Open.Data.Product.MedicineDbRecord", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Person.PersonDbRecord", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Product.MedicineEffectsDbRecord", b =>
                {
                    b.HasOne("Open.Data.Product.EffectDbRecord", "Effect")
                        .WithMany()
                        .HasForeignKey("EffectID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Open.Data.Product.MedicineDbRecord", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Open.Data.Location.GeographicAddressDbRecord", b =>
                {
                    b.HasOne("Open.Data.Location.CountryDbRecord", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

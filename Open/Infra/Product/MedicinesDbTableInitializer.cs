using System;
using System.Collections.Generic;
using System.Linq;
using Open.Aids;
using Open.Data.Effect;

namespace Open.Infra.Product
{
    public static class MedicinesDbTableInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Medicines.Any()) return;
            initMedicines(c);
            c.SaveChanges();
        }

        private static void initMedicineEffects(SentryDbContext c, List<string> medicineIDs,
            List<string> effectIDs)
        {
            foreach (var a in medicineIDs)
            {
                foreach (var d in effectIDs)
                {
                    if (GetRandom.Bool()) continue;
                    c.MedicineEffects.Add(
                        new MedicineEffectsDbRecord() { EffectID = a, MedicineID = d });
                }
            }
        }

        private static List<string> initMedicines(SentryDbContext c)
        {
            var l = new List<string>
            {
                add(c, new MedicineDbRecord
                {
                    Name = "Loratin",
                    AtcCode = "1234567",
                    FormOfInjection = "medical gas",
                    Strength = "100mg",
                    Manufacturer = "TERE",
                    LegalStatus = "Hospital use",
                    Reimbursement = true,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"                    
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Loratin",
                    AtcCode = "1234567",
                    FormOfInjection = "medical gas",
                    Strength = "10mg",
                    Manufacturer = "TERE",
                    LegalStatus = "Hospital use",
                    Reimbursement = true,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Loratin",
                    AtcCode = "1234567",
                    FormOfInjection = "tablets",
                    Strength = "100mg",
                    Manufacturer = "TERE",
                    LegalStatus = "Hospital use",
                    Reimbursement = false,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Hepthasamphin",
                    AtcCode = "1234567",
                    FormOfInjection = "medical gas",
                    Strength = "100mg",
                    Manufacturer = "TERE",
                    LegalStatus = "OTC",
                    Reimbursement = true,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Loratin",
                    AtcCode = "000001ABC",
                    FormOfInjection = "medical gas",
                    Strength = "100mg",
                    Manufacturer = "TERE",
                    LegalStatus = "Hospital use",
                    Reimbursement = false,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Adambamaba",
                    AtcCode = "1234567",
                    FormOfInjection = "needle injection",
                    Strength = "1ml",
                    Manufacturer = "VALIO",
                    LegalStatus = "Hospital use",
                    Reimbursement = true,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Hello school",
                    AtcCode = "1234567",
                    FormOfInjection = "medical gas",
                    Strength = "100mg",
                    Manufacturer = "TERE",
                    LegalStatus = "Hospital use",
                    Reimbursement = true,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                }),
                add(c, new MedicineDbRecord
                {
                    Name = "Hello school",
                    AtcCode = "128939213",
                    FormOfInjection = "medical gas",
                    Strength = "10000mg",
                    Manufacturer = "ALMA",
                    LegalStatus = "Hospital use",
                    Reimbursement = false,
                    Spc = "www.neti.ee",
                    Pil = "www.delfi.ee"
                })

            };
            return l;
        }

        private static string add(SentryDbContext c, MedicineDbRecord medicine)
        {
            medicine.ID = Guid.NewGuid().ToString();
            c.Medicines.Add(medicine);
            return medicine.ID;
        }
    }
}
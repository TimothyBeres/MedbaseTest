using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Facade.Common;

namespace Open.Facade.Product
{
    public class PortfolioViewModel : UniqueEntityViewModel
    {
        private MedicineViewModel usedMedicine;
        private string userId;

        public string UserID
        {
            get => getString(ref userId, "");
            set => userId = value;
        }

        public List<MedicineViewModel> MedicinesInUse { get; } = new List<MedicineViewModel>();
    }
}

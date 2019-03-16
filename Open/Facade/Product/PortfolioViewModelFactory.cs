using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Domain.Product;

namespace Open.Facade.Product
{
    public static class PortfolioViewModelFactory
    {
        public static PortfolioViewModel Create(string id, List<MedicineObject> medicines)
        {
            var v = new PortfolioViewModel()
            {
                ID = id
            };
            foreach (var m in medicines)
            {
                v.MedicinesInUse.Add(MedicineViewModelFactory.Create(m));
            }

            return v;
        }
    }
}

using Open.Aids;
using Open.Core;
using Open.Facade.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Product
{
    public class CategoryViewModel : UniqueEntityViewModel
    {
        private string userId;
        private string categoryName;

        [Required]
        [DisplayName("Category name")]
        public string CategoryName
        {
            get => getString(ref categoryName, Constants.Unspecified);
            set => categoryName = value;
        }

        public string UserID
        {
            get => getString(ref userId, Constants.Unspecified);
            set => userId = value;
        }
        public List<MedicineViewModel> MedicinesWithCategory { get; } = new List<MedicineViewModel>();
    }
}
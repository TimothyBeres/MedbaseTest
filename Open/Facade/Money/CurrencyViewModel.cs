using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;
using Open.Facade.Location;

namespace Open.Facade.Money
{
    public class CurrencyViewModel : NamedViewModel
    {
        private string currencySymbol;
        private string alpha3Code;

        [Required]
        [RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string CurrencySymbol
        {
            get => getString(ref currencySymbol, Constants.Unspecified);
            set => currencySymbol = value;
        }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Currency Code")]
        public string Alpha3Code
        {
            get => getString(ref alpha3Code, Constants.Unspecified);
            set => alpha3Code = value;
        }

        [DisplayName("Used in countries")]
        public List<CountryViewModel> UsedInCountries { get; } = new List<CountryViewModel>();
    }
}
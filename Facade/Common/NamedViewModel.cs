using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;

namespace Open.Facade.Common
{
    public abstract class NamedViewModel : TemporalViewModel
    {
        private string name;
        [Required]
        [RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Name
        {
            get => getString(ref name, Constants.Unspecified);
            set => name = value;
        }
    }
}
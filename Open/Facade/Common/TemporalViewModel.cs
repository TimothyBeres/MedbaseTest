using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Core;

namespace Open.Facade.Common
{
    public abstract class TemporalViewModel : RootObject
    {
        [DataType(DataType.Date)]
        [DisplayName("Alates")]
        public DateTime? ValidFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Kuni")]
        public DateTime? ValidTo { get; set; }
    }
}
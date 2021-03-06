﻿using System;
using System.ComponentModel;
using Open.Core;
using Open.Facade.Common;

namespace Open.Facade.Location
{
    public abstract class AddressViewModel : UniqueEntityViewModel
    {
        [DisplayName("Address type")]
        public string AddressType
        {
            get
            {
                var name = GetType().Name;
                var suffix = typeof(AddressViewModel).Name;
                var idx = name.IndexOf(suffix, StringComparison.Ordinal);
                if (idx >= 0) name = name.Substring(0, idx);
                return name;
            }
        }

        public string Contact => ToString();
    }
}
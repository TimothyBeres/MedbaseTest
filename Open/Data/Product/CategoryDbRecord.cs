using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Common;

namespace Open.Data.Product
{
    public class CategoryDbRecord : UniqueDbRecord
    {
        private string categoryName;
        private string userId;

        public string CategoryName
        {
            get => getString(ref categoryName);
            set => categoryName = value;
        }

        public string UserID
        {
            get => getString(ref userId);
            set => userId = value;
        }
        
    }
}


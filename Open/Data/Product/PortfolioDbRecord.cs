using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.Data.Common;

namespace Open.Data.Product
{
    public class PortfolioDbRecord: TemporalDbRecord

    {
    private string medicineId;
    private string userId;

    public string MedicineID
    {
        get => getString(ref medicineId);
        set => medicineId = value;
    }

    public string UserID
    {
        get => getString(ref userId);
        set => userId = value;
    }

    public virtual MedicineDbRecord Medicine { get; set; }
    }
}

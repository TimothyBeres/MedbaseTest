using Open.Data.Common;

namespace Open.Data.Process
{
    public class SchemeDbRecord : UniqueDbRecord
    {
        private string dosage_id;
        private string queue_nr;
        private string length;
        private string amount;
        private string times;
        private string time_of_day;

        public string DosageId
        {
            get => getString(ref dosage_id);
            set => dosage_id = value;
        }
        public string QueueNr
        {
            get => getString(ref queue_nr);
            set => queue_nr = value;
        }
        public string Length
        {
            get => getString(ref length);
            set => length = value;
        }
        public string Amount
        {
            get => getString(ref amount);
            set => amount = value;
        }
        public string Times
        {
            get => getString(ref times);
            set => times = value;
        }
        public string TimeOfDay
        {
            get => getString(ref time_of_day);
            set => time_of_day = value;
        }
    }
}
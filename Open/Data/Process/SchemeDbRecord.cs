using Open.Data.Common;

namespace Open.Data.Process
{
    public class SchemeDbRecord : UniqueDbRecord
    {
        private string dosageId;
        private string queueNr;
        private string length;
        private string amount;
        private string times;
        private string timeOfDay;

        public string DosageId
        {
            get => getString(ref dosageId);
            set => dosageId = value;
        }
        public string QueueNr
        {
            get => getString(ref queueNr);
            set => queueNr = value;
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
            get => getString(ref timeOfDay);
            set => timeOfDay = value;
        }
    }
}
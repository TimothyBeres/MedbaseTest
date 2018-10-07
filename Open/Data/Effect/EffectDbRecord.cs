using Open.Data.Common;

namespace Open.Data.Effect
{
    public class EffectDbRecord : UniqueDbRecord
    {
        private string name;

        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }
    }
}
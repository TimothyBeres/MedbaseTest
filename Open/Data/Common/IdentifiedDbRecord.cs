using Open.Core;

namespace Open.Data.Common
{
    public abstract class IdentifiedDbRecord : UniqueDbRecord
    {
        private string code;
        private string name;

        public string Code
        {
            get => getString(ref code, Constants.Unspecified);
            set => code = value;
        }

        public string Name
        {
            get => getString(ref name, Code);
            set => name = value;
        }

        public override string ID
        {
            get => getString(ref id, Name);
            set => id = value;
        }

    }
}
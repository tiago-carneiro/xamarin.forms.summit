using Realms;

namespace Xamarin.Summit
{
    public class KeyValueStorage : RealmObject
    {
        public const string DataAtualizacao = "data_atualizacao";

        [PrimaryKey]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

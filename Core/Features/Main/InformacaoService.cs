using Realms;
using System.Threading.Tasks;

namespace Xamarin.Summit
{
    public interface IInformacaoService
    {
        Task LoadInformacoes();
    }

    public class InformacaoService : IInformacaoService
    {
        ulong SchemaVersion => 0;

        public async Task LoadInformacoes()
        {
            //TODO
            //Carregar dados da api e salvar localmente
        }

        Realm GetRealmInstance()
        {
            var config = new RealmConfiguration { SchemaVersion = SchemaVersion };

            #region Migration
            /***** Se houver alguma alteração de classes, deverá ser efetuado o Migration *****/
            //config.MigrationCallback = (migration, oldSchemaVersion) =>
            //{
            //    if (oldSchemaVersion < SchemaVersion)
            //    {
            //        if (oldSchemaVersion < 1)
            //        {
            //            var newObj = migration.NewRealm.All<Class>();
            //            // Use the dynamic api for oldPeople so we can access
            //            // .FirstName and .LastName even though they no longer
            //            // exist in the class definition.
            //            var oldObj = migration.OldRealm.All("className");
            //            for (var i = 0; i < newObj.Count(); i++)
            //            {
            //                var old = oldObj.ElementAt(i);
            //                var new = newObj.ElementAt(i);
            //            }
            //        }
            //    }
            //};
            #endregion

            config.ObjectClasses = new[]
            {
                typeof(Agenda),
                typeof(Apoio),
                typeof(Informacao),
                typeof(Nota),
                typeof(Pessoa),
                typeof(TimeLine)
            };

            return Realm.GetInstance(config);
        }
    }
}

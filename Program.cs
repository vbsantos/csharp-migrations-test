using System.Threading.Tasks;
using MongoDBMigrationsTeste.Entidades;

namespace MongoDBMigrationsTeste
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var test = new MongoTeste();

      // Conecta no MongoDB
      test.Connect();

      await test.GetCollections();

      test.RunMigrations();

      await test.GetCollections();
    }
  }
}

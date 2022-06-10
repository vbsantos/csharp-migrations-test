using MongoDB.Driver;
using MongoDBMigrations;

namespace MongoDBMigrationsTeste.Migrations
{
  public class Teste3 : IMigration
  {
    public Version Version => new Version(1, 1, 2);
    public string Name => "Third Migration";
    public void Up(IMongoDatabase database)
    {
      database.DropCollection("teste1");
      database.DropCollection("pessoas2");
      database.DropCollection("pessoas");

      // Não deu erro
      database.DropCollection("pessoaasdasdass2");
    }
    public void Down(IMongoDatabase database)
    {
      database.CreateCollection("pessoas");
      database.CreateCollection("pessoas2");
      database.CreateCollection("teste1");
    }
  }
}

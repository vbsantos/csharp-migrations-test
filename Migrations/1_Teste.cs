using MongoDB.Driver;
using MongoDBMigrations;

namespace MongoDBMigrationsTeste.Migrations
{
  public class Teste : IMigration
  {
    public Version Version => new Version(1, 1, 0);
    public string Name => "First Migration";
    public void Up(IMongoDatabase database)
    {
      database.CreateCollection("teste1");
      database.CreateCollection("pessoas");
    }
    public void Down(IMongoDatabase database)
    {
      database.DropCollection("teste1");
      database.DropCollection("pessoas");
    }
  }
}

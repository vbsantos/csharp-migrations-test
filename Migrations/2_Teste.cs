using MongoDB.Driver;
using MongoDBMigrations;

namespace MongoDBMigrationsTeste.Migrations
{
  public class Teste2 : IMigration
  {
    public Version Version => new Version(1, 1, 1);
    public string Name => "Second Migration";
    public void Up(IMongoDatabase database)
    {
      database.CreateCollection("pessoas2");
    }
    public void Down(IMongoDatabase database)
    {
      database.DropCollection("pessoas2");
    }
  }
}

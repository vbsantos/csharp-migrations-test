using System.Collections.Generic;
using MongoDB.Driver;
using MongoDBMigrations;
using MongoDBMigrationsTeste.Entidades;

namespace MongoDBMigrationsTeste.Migrations
{
  public class Teste4 : IMigration
  {
    public Version Version => new Version(1, 2, 0);
    public string Name => "Last Migration";

    public string CollectionName => "pessoasSeeds";
    private List<Pessoa> Seeds = new List<Pessoa> {
      new Pessoa { Name = "João Teste 1" },
      new Pessoa { Name = "João Teste 2" },
      new Pessoa { Name = "João Teste 3" },
      new Pessoa { Name = "João Teste 4" }
    };

    public void Up(IMongoDatabase database)
    {
      // Create Collection
      database.CreateCollection(CollectionName);

      // Add Seeds
      var col = database.GetCollection<Pessoa>(CollectionName);
      foreach (Pessoa seed in Seeds)
      {
        col.InsertOne(seed);
      }

      // Create Index
      var indexOptions = new CreateIndexOptions();
      var indexKeys = Builders<Pessoa>.IndexKeys.Ascending(p => p.Name);
      var indexModel = new CreateIndexModel<Pessoa>(indexKeys, indexOptions);
      col.Indexes.CreateOne(indexModel);
    }
    public void Down(IMongoDatabase database)
    {
      database.DropCollection(CollectionName);
    }
  }
}

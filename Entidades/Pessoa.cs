using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBMigrationsTeste.Entidades
{
  public class Pessoa
  {
    public ObjectId Id { get; set; }

    [BsonRequired]
    [BsonElement]
    public string Name { get; set; }
  }
}

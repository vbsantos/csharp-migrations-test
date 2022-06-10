using MongoDB.Driver;
using MongoDBMigrations;
using MongoDBMigrationsTeste.Migrations;
using System;
using System.Threading.Tasks;

namespace MongoDBMigrationsTeste.Entidades
{
  public class MongoTeste
  {
    private string ConnectionString { get; set; }
    private string DatabaseName { get; set; }
    private MongoClient MongoClient { get; set; }

    public MongoTeste(
      string connectionString = "mongodb://localhost:27017/testeMigrations",
      string databaseName = "testeMigrations"
    )
    {
      ConnectionString = connectionString;
      DatabaseName = databaseName;
    }
    public void Connect()
    {
      MongoClient = new MongoClient(ConnectionString);
    }
    async public Task GetCollections()
    {
      Console.WriteLine("\nThe list of collections are:");
      var collections = MongoClient.GetDatabase(DatabaseName).ListCollections();

      await collections.ForEachAsync(c => Console.WriteLine(c));
    }
    public void RunMigrations()
    {
      Console.WriteLine("\nStart Migrations");

      // var fullPath = $"{Path.GetFullPath(".")}/MongoDBMigrationsTeste.csproj";
      MigrationResult res = new MigrationEngine()
        .UseDatabase(ConnectionString, DatabaseName)
        .UseAssembly(typeof(Teste).Assembly)
        .UseSchemeValidation(false)
        // .UseSchemeValidation(true, fullPath)
        .UseProgressHandler(x =>
        {
          Console.WriteLine($"Rodando MIGRATION:  {x.MigrationName}");
        })
        .Run();
      // .Run(new MongoDBMigrations.Version(1, 1, 0));

      Console.WriteLine(res.Success ? "Success" : "Fail");
      Console.WriteLine("End Migrations");
    }
  }
}

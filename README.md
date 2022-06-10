# Migrations

```
new  MigrationEngine()
  .UseSshTunnel(sshServerAdress, user, privateKeyFileStream, mongoAdress, keyFilePassPhrase)
  .UseTls(cert)
  .UseDatabase(connectionString, databaseName)
  .UseAssembly(assemblyWithMigrations)
  .UseSchemeValidation(bool, string)
  .UseCancelationToken(token)
  .UseProgressHandler(Action<> action)
  .Run(targetVersion)
```

- **UseSshTunnel**: Use if you want to connect to your DB via SSH tunel. keyFilePassPhrase is optional.
- **UseTls**: Use if your database requires TLS. Please use X509Certificate2 instance as a cert value
- **UseDatabase**: Required to use specific db
- **UseAssembly**: Required
- **UseSchemeValidation**: Optional if you want to ensure that all documents in collections, that will be affected in the current run, has a consistent structure. Set a true and absolute path to *.csproj file with migration classes or just false.
- **UseCancelationToken**: Optional if you wanna have the possibility to cancel the migration process. Might be useful when you have many migrations and some interaction with the user.
- **UseProgressHandler**: Optional some delegate that will be called each migration
- **Run**: Execution call. Might be called without targetVersion, in that case, the engine will choose the latest available version.

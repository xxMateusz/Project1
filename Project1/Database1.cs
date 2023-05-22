// Licence file C:\Users\ateor\OneDrive\Dokumenty\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.


// ------------------------------------------------------------------------------------------------
// WARNING: Failed to load provider "System.Data.SqlClient" - Cannot open database "Northwind" requested by the login. The login failed. Login failed for user 'DESKTOP-CVD8VKU\ateor'.
// Allowed providers:
//    "System.Data.Odbc"
//    "System.Data.OleDb"
//    "System.Data.OracleClient"
//    "System.Data.SqlClient"
//    "MySql.Data.MySqlClient"
//    "Microsoft.SqlServerCe.Client.4.0"
//    "Microsoft.Data.SqlClient"

/*   w System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, DbConnectionPool pool, String accessToken, Boolean applyTransientFaultHandling, SqlAuthenticationProviderManager sqlAuthProviderManager)
   w System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   w System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions)
   w System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   w System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   w System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   w System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   w System.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   w System.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   w System.Data.SqlClient.SqlConnection.TryOpenInner(TaskCompletionSource`1 retry)
   w System.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry)
   w System.Data.SqlClient.SqlConnection.Open()
   w Microsoft.VisualStudio.TextTemplating3DACE8D0E4A9E10C8204DACAA3331C3AA1DC51E345E01FB0CD365BDCCDB3FDB3D2725E140CE72BC87A4F84CE5235D8CFAECDBAF3A02E7C4A11ACE6B969200A4E.GeneratedTextTransformation.DatabaseReader.Init() w C:\Users\ateor\source\repos\Project1\Project1\EF.Reverse.POCO.v3.ttinclude:wiersz 12415
   w Microsoft.VisualStudio.TextTemplating3DACE8D0E4A9E10C8204DACAA3331C3AA1DC51E345E01FB0CD365BDCCDB3FDB3D2725E140CE72BC87A4F84CE5235D8CFAECDBAF3A02E7C4A11ACE6B969200A4E.GeneratedTextTransformation.SqlServerDatabaseReader.Init() w C:\Users\ateor\source\repos\Project1\Project1\EF.Reverse.POCO.v3.ttinclude:wiersz 16013
   w Microsoft.VisualStudio.TextTemplating3DACE8D0E4A9E10C8204DACAA3331C3AA1DC51E345E01FB0CD365BDCCDB3FDB3D2725E140CE72BC87A4F84CE5235D8CFAECDBAF3A02E7C4A11ACE6B969200A4E.GeneratedTextTransformation.Generator.Init(DatabaseReader databaseReader, String singleDbContextSubNamespace) w C:\Users\ateor\source\repos\Project1\Project1\EF.Reverse.POCO.v3.ttinclude:wiersz 4239
   w Microsoft.VisualStudio.TextTemplating3DACE8D0E4A9E10C8204DACAA3331C3AA1DC51E345E01FB0CD365BDCCDB3FDB3D2725E140CE72BC87A4F84CE5235D8CFAECDBAF3A02E7C4A11ACE6B969200A4E.GeneratedTextTransformation.GeneratorFactory.Create(FileManagementService fileManagementService, Type fileManagerType, String singleDbContextSubNamespace) w C:\Users\ateor\source\repos\Project1\Project1\EF.Reverse.POCO.v3.ttinclude:wiersz 6474*/
// ------------------------------------------------------------------------------------------------


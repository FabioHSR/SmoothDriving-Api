// using MongoDB.Driver;
// using SmoothDrivingAPI.Domain.Entities;
// using System;

// namespace SmoothDriving.Infra.Context
// {
//     public class MongoDbContext
//     {
//         public static string ConnectionString { get; set; }
//         public static string DatabaseName { get; set; }

//         private IMongoDatabase _database { get; }

//         public MongoDbContext()
//         {
//             try
//             {
//                 MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
//                 var mongoClient = new MongoClient(settings);
//                 _database = mongoClient.GetDatabase(DatabaseName);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception("Não foi possível se conectar com o servidor.", ex);
//             }
//         }

//         public IMongoCollection<Sensores> Sensores
//         {
//             get
//             {
//                 return _database.GetCollection<Sensores>("entities");
//             }
//         }
//     }
// }
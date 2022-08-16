using Sam.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Sam.Services
{
    public class EmployeeServices
    {
       private readonly IMongoCollection<EmployeeData> Empdata;

        public EmployeeServices(IOptions<SamDbSettings> SamDatabaseSettings)
        {
            var mongoclient = new MongoClient(SamDatabaseSettings.Value.ConnectionString);

            var mongodatabase = mongoclient.GetDatabase(SamDatabaseSettings.Value.DatabaseName);

            Empdata = mongodatabase.GetCollection<EmployeeData>(SamDatabaseSettings.Value.EmployeeCollectionName);
        }

        public List<EmployeeData> Get() => 
             Empdata.Find(_ => true).ToList();

        public async Task CreateAsync(EmployeeData newBook) =>
            await Empdata.InsertOneAsync(newBook); 
        
    }
}
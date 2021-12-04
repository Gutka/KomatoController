using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using KomatoController.Models;
using Microsoft.Azure.Documents.Client;

namespace KomatoController.Services
{
    public interface ICosmosDBService
    {
        //Task CreateCosmosDatabaseAsync(string databaseName);
        //Task CreateCosmosCollectionAsync(string databaseName, string collectionName);
        Task<List<EnvRecord>> GetRecordsAsync();
        //Task SaveEnvRecordAsync(EnvRecord stud, bool isNewstudent);
        //Task DeleteEnvRecordtAsync(string id);

    }
}

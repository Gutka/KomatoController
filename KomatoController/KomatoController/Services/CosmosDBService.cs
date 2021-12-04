using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Threading.Tasks;
using KomatoController.Models;
using Microsoft.Azure.Cosmos;

namespace KomatoController.Services
{
    public class CosmosDBService:ICosmosDBService
    {
        public List<EnvRecord> Records
        {
            get;
            private set;
        }


        //For Microsoft.Azure.Cosmos nuget package
        readonly CosmosClient client;
        readonly Microsoft.Azure.Cosmos.Database database;
        readonly Container container;

        public CosmosDBService()
        {
            //For Microsoft.Azure.Cosmos nuget package
            client = new CosmosClient(CosmosClientCon.EndpointUri, CosmosClientCon.PrimaryKey);
            database = client.GetDatabase(CosmosClientCon.DatabaseName);
            container = database.GetContainer(CosmosClientCon.CollectionName);

            //// Pokud Error "503 service unavailable exception" kvůli firewall použiju GateWay
            //this.client = new CosmosClient(CosmosClientCon.EndpointUri, CosmosClientCon.PrimaryKey, new CosmosClientOptions()
            //{
            //    ConnectionMode = Microsoft.Azure.Cosmos.ConnectionMode.Gateway
            //});

        }

        public async Task<List<EnvRecord>> GetRecordsAsync()
        {
            Debug.WriteLine("---------- OnStart called!");
            string sqlQueryText = "SELECT * FROM c";
            Records = new List<EnvRecord>();
            try
            {
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                FeedIterator<EnvRecord> queryResultSetIterator = this.container.GetItemQueryIterator<EnvRecord>(queryDefinition);

                while (queryResultSetIterator.HasMoreResults)
                {

                    Records.AddRange(queryResultSetIterator.ReadNextAsync().Result);
                    //var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    //Records.Add(currentResultSet.GetEnumerator().Current);
                    
                    //Microsoft.Azure.Cosmos.FeedResponse<EnvRecord> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    //foreach (EnvRecord record in currentResultSet)
                    //{
                    //    Records.Add(record);
                    //}
                }
            }
            catch (CosmosException ex)
            {
                Debug.WriteLine("Error: ", ex.Message);
            }
            finally
            {
                this.client.Dispose();
            }
            return Records;
        }
    }
}

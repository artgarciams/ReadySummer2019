using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlotMachine.Controllers
{
    public class DataStore
    {

        public CloudTable GetTable()
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("HighScore");

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            return table;

        }

        public void InsertHighSchore(string Userusername, string ipaddress, string City, double lat, double lon, long highscore)
        {

            CloudTable table = GetTable();
            AzureTableStoreModel entity = new AzureTableStoreModel(Userusername.Replace('\\', '-'), DateTime.Now.ToString());
            entity.City = City;
            entity.HighScore = highscore;
            entity.ipAddress = ipaddress;
            //entity.Latitude = lat;
            //entity.Longitude = lon;

            // Create the TableOperation object that inserts the customer entity.
            TableOperation insertOperation = TableOperation.InsertOrReplace(entity);

            // Execute the insert operation.
            table.Execute(insertOperation);


        }


        public List<HighScoreModel> GetHighScoreList()
        {
            List<HighScoreModel> retValue = new List<HighScoreModel>();
            CloudTable table = GetTable();

            // Create the table query.
            TableQuery<AzureTableStoreModel> rangeQuery = new TableQuery<AzureTableStoreModel>().Where(
                TableQuery.GenerateFilterCondition("HighScore", QueryComparisons.NotEqual, null));

            foreach (AzureTableStoreModel entity in table.ExecuteQuery(rangeQuery))
            {
                HighScoreModel tmp = new HighScoreModel();
                tmp.HighUserName = entity.PartitionKey;
                tmp.Ipaddress = entity.RowKey;
                tmp.HighScore = (int)entity.HighScore;
                tmp.City = entity.PartitionKey;
                retValue.Add(tmp);
            }

            return retValue.OrderByDescending(x => x.HighScore).ToList();
        }

        public bool IsHighScore(long highscore)
        {
            try
            {
                CloudTable table = GetTable();

                // Create the table query.
                TableQuery<AzureTableStoreModel> rangeQuery = new TableQuery<AzureTableStoreModel>().Where(
                    TableQuery.GenerateFilterConditionForLong("HighScore", QueryComparisons.GreaterThanOrEqual, 0));

                foreach (AzureTableStoreModel entity in table.ExecuteQuery(rangeQuery))
                {
                    if (entity.HighScore < highscore && entity.HighScore != 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public AzureTableStoreModel GetPlayerscore(string loginname, string ipaddress)
        {
            CloudTable table = GetTable();

            // Create the table query.
            TableQuery<AzureTableStoreModel> rangeQuery = new TableQuery<AzureTableStoreModel>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, loginname),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, ipaddress)));


            // Loop through the results, displaying information about the entity.
            foreach (AzureTableStoreModel entity in table.ExecuteQuery(rangeQuery))
            {
                return entity;
            }

            return new AzureTableStoreModel();

        }

        public string[] GetUserInfo(HttpBrowserCapabilitiesBase req)
        {
            string name = "not found";
            string ipaddress = "1.1.1.1";
            string browser = "none";
            string[] nme = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Split('\\');

            try
            {
                name = nme[nme.GetUpperBound(0)];
                if (System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetUpperBound(0) > 2)
                    ipaddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[2].ToString();
                else
                    ipaddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();


                browser = req.Type;

            }
            catch (Exception)
            {
            }

            return new string[] { name, ipaddress, browser };

        }



    }
}
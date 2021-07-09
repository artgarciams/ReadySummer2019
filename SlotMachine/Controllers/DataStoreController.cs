using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlotMachine.Controllers
{
    public class DataStoreController : Controller
    {
        // GET: DataStore
        public ActionResult Index()
        {
            return View();
        }

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



      

        //public AzureTableStoreModel GetPlayerscore(string loginname, string ipaddress)
        //{
        //    CloudTable table = GetTable();

        //    // Create the table query.
        //    TableQuery<AzureTableStoreModel> rangeQuery = new TableQuery<AzureTableStoreModel>().Where(
        //        TableQuery.CombineFilters(
        //            TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, loginname),
        //            TableOperators.And,
        //            TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, ipaddress)));


        //    // Loop through the results, displaying information about the entity.
        //    foreach (AzureTableStoreModel entity in table.ExecuteQuery(rangeQuery))
        //    {
        //        return entity;
        //    }

        //    return new AzureTableStoreModel();

        //}

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
using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ConsoleApp2.Models;

namespace ConsoleApp2.Processing
{
    /// <summary>
    /// Handles interaction with table storage
    /// </summary>
    class TableManager : IStorageManager
    {
        /// <summary>
        /// Reads records from table storage and writes them to an output file
        /// </summary>
        public void ProcessRecords()
        {
            var filePath = Directory.GetCurrentDirectory() + "\\users-out.txt";
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=nm07storage01;AccountKey=EHiiLUQXGCyDNq6zo1tdSUwSo6UCHgAzwgKLEcvuKf8qxMNhZQm0oJwGKhXgpC4BFz7zygh5R2/QLARMtSlokg==;EndpointSuffix=core.windows.net";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("nm07storage01table01");

            Console.WriteLine("Records from Table Storage");

            using (var sw = new StreamWriter(filePath))
            {
                TableQuery<User> tableQuery = new TableQuery<User>();

                foreach (User user in table.ExecuteQuery(tableQuery))
                {
                    user.ReadKeys();
                    var record = string.Format("{0}	{1}	{2}	{3}", user.LastName, user.FirstName, user.Email, user.PhoneNumber);
                    Console.WriteLine(record);
                    sw.WriteLine(record);
                }
            }
        }
    }
}

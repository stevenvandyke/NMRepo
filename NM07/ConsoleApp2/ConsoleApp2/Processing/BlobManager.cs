using System;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ConsoleApp2.Processing
{
    /// <summary>
    /// Handles interaction with blob storage
    /// </summary>
    class BlobManager : IStorageManager
    {
        /// <summary>
        /// Reads a file from blob storage and writes the records to the output window
        /// </summary>
        public void ProcessRecords()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=nm07storage01;AccountKey=EHiiLUQXGCyDNq6zo1tdSUwSo6UCHgAzwgKLEcvuKf8qxMNhZQm0oJwGKhXgpC4BFz7zygh5R2/QLARMtSlokg==;EndpointSuffix=core.windows.net";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference("nm07storage01blob01");
            var blob = blobContainer.GetBlockBlobReference("users-in.txt");

            Console.WriteLine("Records from Blob Storage");

            using (var stream = blob.OpenRead())
            {
                using (var sr = new StreamReader(stream))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
        }
    }
}

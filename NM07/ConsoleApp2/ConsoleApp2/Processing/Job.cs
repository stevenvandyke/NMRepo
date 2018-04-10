using System;

namespace ConsoleApp2.Processing
{
    /// <summary>
    /// Dispatches processing tasks to dependencies
    /// </summary>
    class Job
    {
        BlobManager blobManager;
        TableManager tableManager;

        /// <summary>
        /// Contructor that accepts storage managers
        /// </summary>
        /// <param name="blobManager">Handles interaction with blob storage</param>
        /// <param name="tableManager">Handles interaction with table storage</param>
        public Job(BlobManager blobManager, TableManager tableManager)
        {
            this.blobManager = blobManager;
            this.tableManager = tableManager;
        }

        /// <summary>
        /// Start processing
        /// </summary>
        public void Run()
        {
            blobManager.ProcessRecords();
            tableManager.ProcessRecords();

            Console.WriteLine("Press any key to close console window...");
            Console.ReadKey();
        }
    }
}

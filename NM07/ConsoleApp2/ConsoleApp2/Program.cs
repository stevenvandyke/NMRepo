using ConsoleApp2.Processing;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// Run job with its dependencies
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var blobManager = new BlobManager();
            var tableManager = new TableManager();

            var job = new Job(blobManager, tableManager);
            job.Run();
        }
    }
}

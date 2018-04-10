using Microsoft.WindowsAzure.Storage.Table;

namespace ConsoleApp2.Models
{
    /// <summary>
    /// Entity class that maps to table storage
    /// </summary>
    class User : TableEntity
    {
        private string lastName;
        private string firstName;
        private string email;
        private string phoneNumber;

        /// <summary>
        /// Assign table key values to properties
        /// </summary>
        public void ReadKeys()
        {
            LastName = PartitionKey;
            FirstName = this.RowKey;
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}

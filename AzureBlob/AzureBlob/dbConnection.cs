using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;    USE FOR BLOB
using Microsoft.WindowsAzure.Storage.Table;
using System.IO;

namespace AzureBlob
{
    class dbConnection
    {
        private static CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        private CloudTable table;
        private CustomerEntity customer;


        public dbConnection()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }

        public void retrieveContainers()
        {
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("People3");
            customer = new CustomerEntity("Zachary", "Desira");
            customer.Email = "zachdesira@hotmail.com";
            customer.PhoneNumber = "123456789";

            TableOperation insertOperation = TableOperation.Insert(customer);
            table.Execute(insertOperation);

            //if (table.Exists() == true)
            //{
            //    createEntity();
            //}
            //else
            //{
            //    table.CreateIfNotExists();
            //    retrieveContainers();
            //}
        }

        public void createEntity()
        {
            customer = new CustomerEntity("Zachary", "Desira");
            customer.Email = "zachdesira@hotmail.com";
            customer.PhoneNumber = "123456789";

            TableOperation insertOperation = TableOperation.Insert(customer);
            table.Execute(insertOperation);
        }

        /*         AZURE BLOB STORAGE
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;
        private CloudBlockBlob blockBlob;

        public dbConnection()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        }

        public void retrieveContainers()
        {
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("my-container");
            if (container.Exists() == true)
            {
                createBlob();
            }
            else
            {
                createContainer();
            }
        }

        private void createContainer()
        {
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions{PublicAccess = BlobContainerPublicAccessType.Blob});
        }

        private void createBlob()
        {
            using (var fileStream = File.OpenRead(@"C:\Users\zacharydesira\Zach Tests\C#\Testing Azure Blob Storage\Testing-Azure-Blob-Storage\AzureBlob\AzureBlob\test.txt"))
            {
                blockBlob = container.GetBlockBlobReference("myblob");
                blockBlob.UploadFromStream(fileStream);
            }   
        }*/
    }
}

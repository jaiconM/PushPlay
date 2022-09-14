using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace PushPlay.Data.AzureBlobStorageHelper
{
    public class AzureBlobStorage : IAzureBlobStorage
    {
        private readonly IConfiguration _configuration;

        public AzureBlobStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadFile(string fileName, string directory, Stream buffer)
        {
            BlobServiceClient client = new(_configuration["BlobStorageConnection"]);
            BlobContainerClient container;

            container = client.GetBlobContainerClient(directory);
            _ = await container.UploadBlobAsync(fileName, buffer);

            return $"{_configuration["BlobStorageBasePath"]}/{directory}/{fileName}";

        }
    }
}

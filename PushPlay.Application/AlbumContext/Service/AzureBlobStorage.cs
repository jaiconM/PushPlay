using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace PushPlay.Application.AlbumContext.Service
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
            var client = new BlobServiceClient(_configuration["BlobStorageConnection"]);
            BlobContainerClient container;

            container = client.GetBlobContainerClient(directory);
            _ = await container.UploadBlobAsync(fileName, buffer);

            return $"{_configuration["BlobStorageBasePath"]}/{directory}/{fileName}";

        }
    }
}

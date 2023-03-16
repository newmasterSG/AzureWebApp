using Azure.Storage.Blobs;
using AzureWebApp.Data.Storage.Interfaces;
using AzureWebApp.Data.ViewModels;

namespace AzureWebApp.Data.Storage
{
    public class BlobStorage : IBlobStorage
    {
        private readonly BlobServiceClient _blobService;
        private readonly IConfiguration _configuration;

        public BlobStorage(BlobServiceClient blobService, IConfiguration configuration)
        {
            _blobService = blobService;
            _configuration = configuration;
        }

        public async Task UploadFileAsync(BlobVM fileDetails)
        {
            var blobStorageContainerName = _blobService.GetBlobContainerClient(_configuration.GetValue<string>("BlobContainer"));

            var blobStorageClient = blobStorageContainerName.GetBlobClient(fileDetails.Email + "_"+ fileDetails.File.FileName);

            var streamContent = fileDetails.File.OpenReadStream();
            await blobStorageClient.UploadAsync(streamContent);
        }
    }
}

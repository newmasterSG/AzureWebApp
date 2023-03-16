using AzureWebApp.Data.ViewModels;

namespace AzureWebApp.Data.Storage.Interfaces
{
    public interface IBlobStorage
    {
        Task UploadFileAsync(BlobVM fileDetails);
    }
}

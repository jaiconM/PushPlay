namespace PushPlay.Data.AzureBlobStorageHelper
{
    public interface IAzureBlobStorage
    {
        Task<string> UploadFile(string fileName, string directory, Stream buffer);
    }
}
namespace PushPlay.Application.AlbumContext.Service
{
    public interface IAzureBlobStorage
    {
        Task<string> UploadFile(string fileName, string directory, Stream buffer);
    }
}
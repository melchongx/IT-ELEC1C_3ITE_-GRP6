using Microsoft.WindowsAzure.Storage.Blob;

namespace InnoNet.Data.Services;

public interface IUpload
{
    CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
}
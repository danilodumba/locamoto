using Locamoto.UseCases.DeliveryDrivers.Services;
using Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;
using Minio;

namespace Locamoto.Infra.MinIO;

internal class StorageCnhService: IStorageCnhService
{
    readonly MinioClient _minioClient;

    public StorageCnhService(MinioClient minioClient)
    {
        _minioClient = minioClient;
    }

    public async Task Publish(CnhFile file)
    {    
        await ValidateBucket(file.Bucket);
        await _minioClient.PutObjectAsync(file.Bucket, file.FileName, file.Path);
    }

    public async Task GetFile(CnhFile file)
    {
        var bucketName = file.Bucket; 
        var objectName = file.FileName;
        await _minioClient.GetObjectAsync(bucketName, objectName, "./images/" + objectName);
    }

    private async Task ValidateBucket(string bucketName)
    {
        var found = await _minioClient.BucketExistsAsync(bucketName);
        if (!found)
        {
            await _minioClient.MakeBucketAsync(bucketName);
        }
    }
}

using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;

public record UploadCnhImageCommand(Guid DeliverymanID, string FileName, Stream File): CommandRequest<UploadCnhImageResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(DeliverymanID, "The field DeliverymanID is required");

        if (!IsExtensionFileValid(this.GetFileExtension()))
        {
            this.AddError("Invalid file extension. Input only png ou bmp");
        }

        return base.IsValid();
    }

    public string GetFileExtension()
    {
        var extension = FileName.Split('.');
        if (extension.Count() < 2) return string.Empty;

        return extension[1].ToLower();
    }

    public string GetName()
    {
        var extension = FileName.Split('.');
        return extension[0];
    }

    private bool IsExtensionFileValid(string extension)
    {
        return !string.IsNullOrEmpty(extension) && 
                (extension.Equals("png") || 
                extension.Equals("bmp"));
    }
}

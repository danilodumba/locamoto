using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.Core;

namespace Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;

public record UploadCnhImageCommand(Guid DeliverymanID, string FileName, Stream File): CommandRequest<UploadCnhImageResponse>
{
    public override bool IsValid()
    {
        this.ValidateFieldlNull(DeliverymanID, "The field DeliverymanID is required");

        return base.IsValid();
    }
}

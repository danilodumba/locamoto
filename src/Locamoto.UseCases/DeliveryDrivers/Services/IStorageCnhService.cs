using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.UseCases.DeliveryDrivers.UploadCnhImage;

namespace Locamoto.UseCases.DeliveryDrivers.Services
{
    public interface IStorageCnhService
    {
        Task Publish(CnhFile file);
        Task GetFile(CnhFile file);
    }
}
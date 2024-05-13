using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.UseCases.DeliveryDrivers.UploadCnhImage
{
    public class CnhFile
    {
        public CnhFile(string fileName, string path, string bucket)
        {
            FileName = fileName;
            Path = path;
            Bucket = bucket;
        }

        public string FileName { get; set; }
        public string Path { get; set; }
        public string Bucket { get; set; }
    }
}
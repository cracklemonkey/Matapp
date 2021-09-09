using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using System.IO;


namespace matAppBackEnd.Services
{
    public class ImageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ImageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

         public async Task<byte[]> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("foodimages");
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo =  await blobClient.DownloadAsync();

            using (MemoryStream ms = new MemoryStream())
            {
                await blobDownloadInfo.Value.Content.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
        
        public async Task<IEnumerable<string>> ListBlobAsync()
        {
           var containerClient = _blobServiceClient.GetBlobContainerClient("foodimages"); 
           var items = new List<string>();

           await foreach (var blobItem in containerClient.GetBlobsAsync())
           {
               items.Add(blobItem.Name);
           }

           return items;
        }

        public async Task UploadeFileBlobAsync(FileModel model)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("foodimages"); 
            var blobClient = containerClient.GetBlobClient(model.MyFile.FileName);
            await blobClient.UploadAsync(model.MyFile.OpenReadStream());
        }

        public async Task DeleteBlobAsync(string imageName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("foodimages");
            var blobClient = containerClient.GetBlobClient(imageName);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
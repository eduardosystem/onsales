﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;

namespace onsales.Web.Helpers
{
    public class BlobHelper : IBlobHelper
    {
        private readonly CloudBlobClient _blobClient;

        public BlobHelper(IConfiguration configuration)
        {
            string keys = configuration["Blob:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(keys);
            _blobClient = storageAccount.CreateCloudBlobClient();
        }

        public async Task<Guid> UploadBlobAsync(byte[] file, string containerName)
        {
            MemoryStream stream = new MemoryStream(file);
            Guid name = Guid.NewGuid();
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
            await blockBlob.UploadFromStreamAsync(stream);
            return name;
        }

        //public Task<Guid> UploadBlobAsync(IFormFile file, string containerName)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Guid> UploadBlobAsync(string image, string containerName)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Guid> UploadBlobAsync(IFormFile file, string containerName)
        {
            Stream stream = file.OpenReadStream();
            Guid name = Guid.NewGuid();
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
            await blockBlob.UploadFromStreamAsync(stream);
            return name;
        }

        public async Task<Guid> UploadBlobAsync(string image, string containerName)
        {
            Stream stream = File.OpenRead(image);
            Guid name = Guid.NewGuid();
            CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference($"{name}");
            await blockBlob.UploadFromStreamAsync(stream);
            return name;
        }
    }


}

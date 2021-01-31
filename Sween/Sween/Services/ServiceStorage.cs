using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sween.Services
{
    public class ServiceStorage
    {
        const string StorageURL = "https://sweenblobs.blob.core.windows.net";
        const string ContainerUser = "sweenimages";
        const string SASQueryString = "?sv=2019-12-12&st=2021-01-31T05%3A01%3A28Z&se=2030-02-01T05%3A01%3A00Z&sr=c&sp=racwdl&sig=Fs0lZZ5jzsyjTCjHyVOsftRK0lJ0R6j2ShBu8cJQPHk%3D";

        public async Task<string> UploadUser(int id,Stream stream,string dt)
        {
            string blobSAS = $"{StorageURL}/{ContainerUser}/{id}-{dt}.jpg{SASQueryString}";
            return await UploadBlob(blobSAS, stream);
        }

        public async Task<Stream> DownloadUser(int id, string dt)
        {
            string blobSAS = $"{StorageURL}/{ContainerUser}/{id}-{dt}.jpg{SASQueryString}";
            return await DownloadBlob(blobSAS);
        }

        public string GetFullUserURL(int? id, string dt)
        {
            return $"{StorageURL}/{ContainerUser}/{id}-{dt}.jpg{SASQueryString}";
        }

        private async Task<Stream> DownloadBlob(string blobSAS)
        {
            try
            {
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(blobSAS));
                MemoryStream stream = new MemoryStream();
                await blob.DownloadToStreamAsync(stream);
                return stream;

            }catch(Exception ex)
            {
                string msgError = ex.Message;
                return null;
            }
        }

        private async Task<string> UploadBlob(string blobSAS,Stream stream)
        {
            string url = "";
            try
            {
                CloudBlockBlob blob = new CloudBlockBlob(new Uri(blobSAS));
                using (stream)
                {
                    await blob.UploadFromStreamAsync(stream);
                    url = blob.StorageUri.PrimaryUri.AbsoluteUri;
                }
            }catch(Exception ex)
            {
                string msgError = ex.Message;
            }
            return url;

        }
    }
}

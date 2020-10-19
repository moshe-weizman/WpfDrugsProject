using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;
using System.Threading;
using Google.Apis.Drive.v3;
using System.Threading.Tasks;

//using System.Web.MimeMapping.GetMimeMapping

//DrogsProject2020@gmail.com
//pewzner2020

namespace Drugs2020.DAL
{
    public class GoogleDrive : ICloudForImage
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        public string[] Scopes = { DriveService.Scope.Drive };
        public string ApplicationName = "drogs app consent";

        public DriveService GetService()
        {
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = ApplicationName,
            });
        }

        public UserCredential GetCredential()
        {
            var credentialIn = "C:\\Users\\ipewz\\source\\repos\\drugsProject2020\\Drugs2020.DAL\\card.json";
            UserCredential credential;

            using (var stream = new FileStream(credentialIn, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                // FileDataStore v= new Google.Apis.Util.Store.FileDataStore(credPath, true);

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                    GoogleClientSecrets.Load(stream).Secrets,
                                    Scopes,
                                    "user",
                                    CancellationToken.None,
                                    new Google.Apis.Util.Store.FileDataStore(credPath, true)
                                    ).Result;

                Console.WriteLine("Credential file saved to: " + credPath);
            }
            return credential;
        }

        /*
        public void progrem()
        {

            UserCredential credential;
            credential = GetCredential();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string pageToken = null;

            do
            {
               // ListFiles(ref pageToken);
              //  ListFiles( pageToken,fileName);
            } while (pageToken != null);
            Console.WriteLine("done");
            Console.ReadLine();
        }
        */

        // public void ListFiles(ref string pageToken)

        public Google.Apis.Drive.v3.Data.File ListFiles(string pageToken, string fileName)
        {
            DriveService service = GetService();

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            //    listRequest.PageSize = 1;
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.PageToken = pageToken;
            //  listRequest.Q = "mimeType='image/jpg'";

            // List files.
            var request = listRequest.Execute();

            Console.WriteLine("Files:");
            if (request.Files != null && request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    Console.WriteLine("{0} ", file.Name);
                    if (file.Name == fileName) return file;
                }
                pageToken = request.NextPageToken;

                if (request.NextPageToken != null)
                {
                    Console.WriteLine("press any key to cunti...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            // Console.Read();
            return null;
        }

        //helper function
        public string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        //--------------------------------------------------
        //need testing
        public void Rename(string oldName, string newName)
        {
            DriveService service = GetService();
            Google.Apis.Drive.v3.Data.File file = ListFiles(null, oldName);

            //     Google.Apis.Drive.v3.Data.File file = service.Files.Get(file.id).Execute();

            var update = new Google.Apis.Drive.v3.Data.File();
            update.Name = newName;

            service.Files.Update(update, file.Id).Execute();
        }

        public void Upload(string path)
        {
            DriveService service = GetService();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }

            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
        }

        //need testing
        public void Remove(string name)
        {
            DriveService service = GetService();
            Google.Apis.Drive.v3.Data.File file = ListFiles(null, name);

            service.Files.Delete(file.Id).Execute();
        }

        public void Download(string fileName, string saveTo)
        {
            //  DownloadFile(ListFiles(null,fileName), saveTo);
            DownloadAsync(ListFiles(null, fileName).Id, saveTo);
        }
        //--------------------------------------------------

        /*
       public void DownloadFile(Google.Apis.Drive.v3.Data.File file, string saveTo)
       {
           DriveService service = GetService();

           //var request = service.Files.Get(file.Id);
           var request = service.Files.Get(file.Id);
           var stream = new System.IO.MemoryStream();

           // Add a handler which will be notified on progress changes.
           // It will notify on each chunk download and when the
           // download is completed or failed.
           request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
           {
               switch (progress.Status)
               {
                   case Google.Apis.Download.DownloadStatus.Downloading:
                       {
                           Console.WriteLine(progress.BytesDownloaded);
                           break;
                       }
                   case Google.Apis.Download.DownloadStatus.Completed:
                       {
                           Console.WriteLine("Download complete.");
                          // SaveStream(stream, saveTo);
                           break;
                       }
                   case Google.Apis.Download.DownloadStatus.Failed:
                       {
                           Console.WriteLine("Download failed.");
                           break;
                       }
               }
           };
           request.Download(stream);

       }
        */

        public async Task DownloadAsync(string fileId, string saveTo)
        {
            DriveService service = GetService();

            System.IO.MemoryStream outputStream = new System.IO.MemoryStream();
            var request = service.Files.Get(fileId);

            try
            {
                await request.DownloadAsync(outputStream);
                SaveStream(outputStream, saveTo);
            }
            catch (Exception ex) { }

            // outputstream.Position = 0;
        }

        public void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }

    }
}
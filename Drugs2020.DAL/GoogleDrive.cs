using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;
using System.Threading;
using Google.Apis.Drive.v3;


//using System.Web.MimeMapping.GetMimeMapping

//DrogsProject2020@gmail.com
//pewzner2020

namespace Drugs2020.DAL
{
    public class GoogleDrive
    {

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        public string[] Scopes = { DriveService.Scope.Drive };
        public string ApplicationName = "drogs app consent";

        public DriveService GetService() {
            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = ApplicationName,
            });
        }

        public void progrem() {
          
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
                ListFiles(service, ref pageToken);
            } while (pageToken != null);
            Console.WriteLine("done");
            Console.ReadLine();
        }


        public void ListFiles(DriveService service, ref string pageToken) {

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 1;
            // listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Fields = "nextPageToken, files(name)";
            listRequest.PageToken = pageToken;
            listRequest.Q = "mimeType='image/jpg'";

            // List files.
              var request = listRequest.Execute();

            Console.WriteLine("Files:");
            if (request.Files != null && request.Files.Count > 0)
            {
                foreach (var file in request.Files)
                {
                    Console.WriteLine("{0} ", file.Name);
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

        }

        public UserCredential GetCredential()
        {

            // var credentialIn = "C:\\Users\\ipewz\\source\\repos\\drugsProject2020\\Drugs2020.DAL\\credentials.json";
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

        public void UploadBasicImage(string path)
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

    }
}             
using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


//using System.Web.MimeMapping.GetMimeMapping

//DrogsProject2020@gmail.com
//pewzner2020

/*
 3

744759389802-h3v56gmejgrtf6n9o6eul0mkesl9d3v4.apps.googleusercontent.com
                                                        
    0oTvRfMlfK4ZmVZazpowJXGb
 */
/*
 new 2

744759389802-06k6onf4vspv69f718oe5mofhhu0bhcr.apps.googleusercontent.com

    83uKVQ9Jlcdn_KA1q0wY6ugd
 */

/*
 new

539155361256-hog4kmk27s59t6853ohu1vrhve8qj9rs.apps.googleusercontent.com

4kl3tPrO2d7Iafal2TDdNut_

 */

/*
 Client ID
522016693852-t07u9ne0j48mktohjhr50j1qgfve3jlu.apps.googleusercontent.com

    Client Secret
U3iL5V-II1rLzwAWTYJimLgR
 */

namespace Drugs2020.DAL
{
    public class GoogleDrive
    {

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        public string[] Scopes = { DriveService.Scope.Drive };
        public string ApplicationName = "drogsproject2020";

        public void progrem() { 
        /*static void Main(string[] args)
        {  
        */
            UserCredential credential;
            credential = GetCredential();

           // Create Drive API service.
           var service = new DriveService(new BaseClientService.Initializer()
            {
              HttpClientInitializer = credential,
              ApplicationName = ApplicationName,
              // HttpClientInitializer = "744759389802 - h3v56gmejgrtf6n9o6eul0mkesl9d3v4.apps.googleusercontent.com" ,
             //  ApplicationName = ApplicationName,
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
            var credentialIn = "C:\\Users\\ipewz\\source\\repos\\drugsProject2020\\Drugs2020.DAL\\tt3.json";

            UserCredential credential;

            using (var stream = new FileStream(credentialIn, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                FileDataStore v= new FileDataStore(credPath, true);

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                    GoogleClientSecrets.Load(stream).Secrets,
                                    Scopes,
                                    "user",
                                    CancellationToken.None, v).Result; 
               
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



    }
}             
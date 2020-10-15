using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Drugs2020.BLL
{
    public class SaveAndRetrive
    {
        Program p;
        public SaveAndRetrive() {
            p = new Program();
            googleDrive = new GoogleDrive();
        }
        public void Save() {
            p.SavePatient(new Patient("11", "many2", "fd", Sex.MALE, "54", "fd", "fr", new DateTime(2010, 01, 01)));
        }

        GoogleDrive googleDrive;
        public void SaveImage()
        {
            googleDrive.UploadBasicImage("C:\\Users\\ipewz\\source\\repos\\drugsProject2020\\Drugs2020.PL\\Images\\medicine.jpg");
        }

          //  public File Retrive() {
          //       return null;
          //  }
        }
}

using Drugs2020.BLL.BE;
using Drugs2020.DAL;
using System;

namespace Drugs2020.BLL
{
    public class SaveAndRetrive
    {
        ICloudForImage cloud = new GoogleDrive();
        private DalImplementation dal;
        public SaveAndRetrive()
        {
            dal = new DalImplementation();
            googleDrive = new GoogleDrive();
        }
        public void Save()
        {
            dal.AddPatient(new Patient("11", "many2", "fd", Sex.MALE, "54", "fd", "fr", new DateTime(2010, 01, 01)));
        }

        GoogleDrive googleDrive;
        public void SaveImage()
        {
            string place = "C:\\Users\\ipewz\\source\\repos\\drugsProject2020\\Ritalin.jpg";
            //cloud.Download("Ritalin.jpg", place);
            cloud.Upload(place);
            //cloud.Remove("Ritalin.jpg");
            //cloud.Rename("Ritalin.jpg", "RitalinIsGood.jpg");


        }


    }
}

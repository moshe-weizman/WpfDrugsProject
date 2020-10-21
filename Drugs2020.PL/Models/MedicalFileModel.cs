using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class MedicalFileModel
    {
        private IBL bl;
       private  Patient CurrentPatient;
        public MedicalFile MedicalFile { get; set; }
        public MedicalFileModel(Patient patient)
        {
            CurrentPatient =patient;
            bl = new BLImplementation();
            MedicalFile = bl.GetMedicalFile("6");
        }
    }
}

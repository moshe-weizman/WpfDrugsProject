using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class ReceptModel
    {
        private IBL bl;
        public Recept Recept { get; set; }
        public List<Drug> DrugList { get; set; }
        public List<Recept> AllRecepts { get; set; }
        public List<string> Conflicts { get; set; }
        private string patientId;

        public ReceptModel(string patientId, Physician physician)
        {
            bl = new BLImplementation();
            this.patientId = patientId;
            Recept = new Recept(patientId, physician);
            DrugList = bl.GetAllDrugs();
            AllRecepts = bl.GetAllReceptsOfPatient(patientId);
            Conflicts = new List<string>();
        }

        public void AddRecept()
        {
            //Conflicts = bl.checkConflicts(Recept.IdCodeOfDrug, AllRecepts.Select(x => x.IdCodeOfDrug).ToList());
            //לתת לו להחליט אם רוצה להוסיף
            try
            {
                bl.AddRecept(Recept);
            }
            catch (ArgumentException) { throw; }
            catch (Exception) { throw; }
            try
            {
                AllRecepts = bl.GetAllReceptsOfPatient(patientId);
            }
            catch (Exception) { throw; }


        }
        //public bool ReceptAlreadyExists()
        //{
        //    return false;//צריך לממש את זה!!!
        //}


        public void CreatePDF()
        {
            bl.CreatePDF(Recept);
        }
        public string CheckConflicts(string IdCodeOfDrug)
        {
            Conflicts = bl.checkConflicts(IdCodeOfDrug, AllRecepts.Select(x => x.IdCodeOfDrug).ToList());
            return string.Join(",  ", Conflicts.ToArray());
        }


    }
}

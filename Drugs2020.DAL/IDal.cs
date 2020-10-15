using Drugs2020.BLL.BE;

namespace Drugs2020.DAL
{
    public interface IDal
    {                                                                                       
        #region Patient CRUD Functions
        void AddPatient(Patient patient);
        Patient GetPatient(string id);
        void UpdatePatient(Patient patient);
        void DeletePatient(string id);
        #endregion

        #region Physician CRUD Functions
        void AddPhysician(Physician physician);
        Physician GetPhysician(string id);
        void UpdatePhysician(Physician physician);
        void DeletePhysician(string id);
        #endregion

        #region Drug CRUD Functions
        void AddDrug(Drug drug);
        Drug GetDrug(string IdCode);
        void UpdateDrug(Drug drug);
        void DeleteDrug(string id);

        #endregion
    }
}
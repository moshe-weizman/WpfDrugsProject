using Drugs2020.BLL.BE;

namespace Drugs2020.PL.ViewModels
{
    interface IPatientSearchViewModel
    {
        Patient PatientFound { get; set; }
        string PatientID { get; set; }

        Patient GetPatient();
    }
}
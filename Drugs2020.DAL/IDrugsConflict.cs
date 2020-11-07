using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.DAL
{
    public interface IDrugsConflict
    {
        List<string> ConflictTest2(string IdCodeOfNewDrug, List<string> drugsTakenPatient);
        string ConflictTest(string IdCodeOfNewDrug, List<string> drugsTakenPatient);
        int ResolveRxcuiFromName(string name);
    }
}

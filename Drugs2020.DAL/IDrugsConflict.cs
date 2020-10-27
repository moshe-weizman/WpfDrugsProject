using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.DAL
{
    public interface IDrugsConflict
    {
        string ConflictTest(string IdCodeOfNewDrug, List<string> drugsTakenPatient);
        int ResolveRxcuiFromName(string name);
    }
}

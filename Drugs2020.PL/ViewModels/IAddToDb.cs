using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    public interface IAddToDb
    {
        bool AllFieldsFilled();
        void AddItemToDb();
        bool ItemAlreadyExists();
        bool UserWantsToReplaceExistingItem();
        void UpdateExistingItem();
    }
}

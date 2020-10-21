﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.ViewModels
{
    public interface IDelete
    {
        void RemoveItemFromDb(object item);
        bool IsUserSureToDelete();
    }
}

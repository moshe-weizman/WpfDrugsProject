using Drugs2020.BLL.BE;
using Drugs2020.PL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class MainWindowModel
    {
        public MainWindowModel()
        {
        }

        public IUser User { get; set; }
        public Patient Patient { get; set; }

    }
}

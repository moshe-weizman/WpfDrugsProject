using System;
using System.Collections.Generic;
using System.Text;

namespace Drugs2020.BLL.BE
{
    class ClinicBranch
    {
        public int BranchNumber { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public ClinicBranch(int branchNumber, string address, int phone)
        {
            BranchNumber = branchNumber;
            Address = address;
            Phone = phone;
        }
        //
    }
}

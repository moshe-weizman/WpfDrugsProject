using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class PhysicianPanelModel
    {
        public Physician CurrentPhysician { get; set; }
        public Patient Patient { get; set; }
    }
}

using Drugs2020.BLL;
using Drugs2020.BLL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class AddPhysicianModel
    {
        private IBL bl;
        public Physician Physician { get; set; }

        public AddPhysicianModel()
        {
            this.Physician = new Physician();
            bl = new BLImplementation();
        }

        public void AddPhysicianToDb()
        {
            try
            {
                bl.AddPhysician(Physician);
            }
            catch (ArgumentException) { throw; }
            catch (Exception ex) { throw; }
        }
        public bool DoesPhysicianExist()
        {
            return bl.DoesPhysicianExist(Physician.ID);
        }

        public void UpdatePhysician()
        {
            try
            {
                bl.UpdatePhysician(Physician.ID, Physician);
            }
            catch(ArgumentException) { throw; }
            catch (Exception ) { throw; }
        }
    }
}

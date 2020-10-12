using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs2020.PL.Models
{
    class LogInModel
    {
        public int IdUser { get; set; }
        public string Password { get; set; }

        //public LogInModel(int idUser, string password)
        //{
        //    IdUser = idUser;
        //    Password = password;
        //}

        public LogInModel()
        {
        }
    }
}

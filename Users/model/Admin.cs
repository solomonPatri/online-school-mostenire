    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Users.model
{
    public class Admin : User
    {

        private string _type;


        public Admin(string Propietate) : base(Propietate)
        {
            string[] cuvinte = Propietate.Split(',');
           
            _type = cuvinte[3];
        }


        
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public override string Descriere()
        {
            string desc = " ";
            desc += "Type: " + Type + "\n";
            return desc;


        }









    }
}

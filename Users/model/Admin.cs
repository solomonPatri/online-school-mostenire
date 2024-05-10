    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Users.model
{
    public class Admin : User
    {
        private int _nrId;
        private string _type;


        public Admin(string Propietate) : base(Propietate)
        {
            string[] cuvinte = Propietate.Split(',');
            _nrId = int.Parse(cuvinte[3]);
            _type = cuvinte[0];
        }


        public int Id
        {
            get { return _nrId; }
            set { _nrId = value; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;

namespace Tema_OnlineSchool_Noilectii.user.model
{
    internal class User
    {
        private string _username;
        private string _password;


        public User(string Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            _username = cuvinte[0];
            _password = cuvinte[1];
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public virtual string Descriere()
        {
            string desc = " ";
            desc += "email: " + Username + "\n";
            desc += "Parola: " + Password + "\n";
            return desc;


        }
    











    }
}

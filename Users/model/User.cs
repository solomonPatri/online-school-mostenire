using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;

namespace Tema_OnlineSchool_Noilectii.Users.model
{
    public class User
    {
        public int _id;
        private string _username;
        private string _password;
        private string _type;

        public User(string Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            _username = cuvinte[1];
            _password = cuvinte[2];
            _type = cuvinte[0];
            _id = int.Parse(cuvinte[3]);
        }
        public User(string type,string user,string pass,int id)
        {    this._type = type;
            this._username = user;
            this._password = pass;
            this._id = id;
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
            desc += "Type:" + Type + "\n";
            desc += "email: " + Username + "\n";
            desc += "Parola: " + Password + "\n";
           
            return desc;


        }
    











    }
}

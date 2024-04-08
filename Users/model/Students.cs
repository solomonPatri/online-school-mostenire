using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.admin.model;
using Tema_OnlineSchool_Noilectii.user.model;

namespace online_school.Student.model
{
    internal class Students:Admin
    {
        private int _id;
        private string _firstnameStudent;
        private string _lastnameStudent;
        private string _facultate;
        private string _email;
        private int _age;
        private string _password;
        private int _media;

        public Students(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._firstnameStudent = cuvinte[3];
            this._lastnameStudent = cuvinte[4];
            this._facultate = cuvinte[5];
            this._age = int.Parse(cuvinte[6]);
            this._media = int.Parse(cuvinte[7]);
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstnameStudent
        {
            get { return _firstnameStudent; }
            set { _firstnameStudent = value; }
        }
        public string LastnameStudent
        {
            get { return _lastnameStudent; }
            set { _lastnameStudent = value; }
        }
        public string Facultate
        {
            get { return _facultate; }
            set { _facultate = value; }

        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }

        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }

        }
        public string Password
        {
            get { return _password ; }
            set { _password = value; }

        }
        public int Media
        {
            get { return _media; }
            set { _media = value; }
        }


        public override string Descriere()
        {
            string desc = " "+base.Descriere();
            desc += "Prenume: " + this._firstnameStudent + "\n";
            desc += "Nume: " + this._lastnameStudent + "\n";
            desc += "Facultate: " + this._facultate + "\n";
            desc += "Varsta: " + this._age + "\n";
            desc += "Media: " + this._media + "\n";
            return desc;

        }
        public  string DescriereStudenti()
        {
            string desc = " ";
            desc += "Prenume: " + this._firstnameStudent + "\n";
            desc += "Nume: " + this._lastnameStudent + "\n";
            desc += "Facultate: " + this._facultate + "\n";
            desc += "Varsta: " + this._age + "\n";
            desc += "Media: " + this._media + "\n";
            return desc;

        }

    }
}

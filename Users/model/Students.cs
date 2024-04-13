using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Tema_OnlineSchool_Noilectii.Users.model
{
    internal class Student : User
    {
        private int _id;
        private string _firstnameStudent;
        private string _lastnameStudent;
        private string _facultate;
        private string _email;
        private int _age;
        private string _password;
        private int _media;

        public Student(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            _firstnameStudent = cuvinte[5];
            _lastnameStudent = cuvinte[4];
            _facultate = cuvinte[5];
            _age = int.Parse(cuvinte[6]);
            _media = int.Parse(cuvinte[7]);
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
            get { return _password; }
            set { _password = value; }

        }
        public int Media
        {
            get { return _media; }
            set { _media = value; }
        }


        public override string Descriere()
        {
            string desc = " " + base.Descriere();
            desc += "Prenume: " + _firstnameStudent + "\n";
            desc += "Nume: " + _lastnameStudent + "\n";
            desc += "Facultate: " + _facultate + "\n";
            desc += "Varsta: " + _age + "\n";
            desc += "Media: " + _media + "\n";
            return desc;

        }
        public string DescriereStudenti()
        {
            string desc = " ";
            desc += "Prenume: " + _firstnameStudent + "\n";
            desc += "Nume: " + _lastnameStudent + "\n";
            desc += "Facultate: " + _facultate + "\n";
            desc += "Varsta: " + _age + "\n";
            desc += "Media: " + _media + "\n";
            return desc;

        }

    }
}

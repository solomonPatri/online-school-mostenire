using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Tema_OnlineSchool_Noilectii.Users.model
{
    internal class Student : User
    {
       
        private string _firstnameStudent;
        private string _lastnameStudent;
        private string _facultate;
        private int _age;
        private int _media;

        public Student(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            _firstnameStudent = cuvinte[4];
            _lastnameStudent = cuvinte[5];
            _facultate = cuvinte[6];
            _age = int.Parse(cuvinte[7]);
            _media = int.Parse(cuvinte[8]);
        }
        public Student(string type,string email,string pass,int id, string firstname, string lastname, string facultate, int age, int media):base (type,email,pass,id)
        {
            
            this._firstnameStudent = firstname;
            this._lastnameStudent = lastname;
            this._facultate = facultate;
            this._age = age;
            this._media = media;
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
       
        public int Age
        {
            get { return _age; }
            set { _age = value; }

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

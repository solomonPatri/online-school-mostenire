using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class An1:Course
    {
        private string _nameCurs;
        private string _departament;
        private string _facultate;

        public An1(string Propietati) : base(Propietati)
        {
            string[]cuvinte = Propietati.Split(','); 
            this._nameCurs = cuvinte[3];
            this._departament = cuvinte[4];
            this._facultate = cuvinte[5];
        }
        public string NameCurs
        {
            get { return _nameCurs; }
            set { _nameCurs = value; }

        }
        public string Departament
        {
            get { return _departament; }
            set { _departament = value; }

        }
        public string Facultate
        {
            get { return _facultate; }
            set { _facultate = value; }
        }

        public override string Descriere()
        {
            string desc = " ";
            desc += "Numele Curs: " + NameCurs + "\n";
            desc += "Departament: " + Departament + "\n";
            desc += "Facultate: " + Facultate + "\n";

            return desc;
        }

        public  string DescriereAn1()
        {
            string desc = " ";
            desc += "Numele Curs: " + NameCurs + "\n";
            desc += "Departament: " + Departament + "\n";
            desc += "Facultate: " + Facultate + "\n";

            return desc;
        }






    }
}

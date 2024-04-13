using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class Master:Course
    {
        private string _nameCurs;
        private string _facultate;
        private string _specialitate;
        private int _nrStudenti;

        public Master(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._nameCurs = cuvinte[3];
            this._facultate = cuvinte[4];
            this._specialitate = cuvinte[5];
            this._nrStudenti = int.Parse(cuvinte[6]);
        }
        public string NameCurs
        {
            get { return _nameCurs; }
            set { _nameCurs = value; }
        }
        public string Facultate
        {
            get { return _facultate; }
            set { _facultate = value; }
        }

        public string Specialitate
        {
            get { return _specialitate; }
            set { _specialitate = value; }

        }
        public int NrStudenti
        {
            get { return _nrStudenti; }
            set { _nrStudenti = value; }

        }

        public override string Descriere()
        {
            string desc = " ";
            desc += "Name Curs: " + NameCurs + "\n";
            desc += "Facultate: " + Facultate + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            desc += "Nr de Studenti: " + NrStudenti + "\n";
            return desc;
        }

        public string DescriereMaster()
        {
            string desc = " ";
            desc += "Name Curs: " + NameCurs + "\n";
            desc += "Facultate: " + Facultate + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            desc += "Nr de Studenti: " + NrStudenti + "\n";
            return desc;
        }



    }
}

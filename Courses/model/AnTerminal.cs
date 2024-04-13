using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class AnTerminal:Course
    {
        private string _namecurs;
        private string _studentname;
        private int _anAbsolvire;
        private string _facultatea;
        private int _aniiStudii;

        public AnTerminal(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._namecurs = cuvinte[3];
            this._studentname = cuvinte[4];
            this._anAbsolvire = int.Parse(cuvinte[5]);
            this._facultatea = cuvinte[6];
            this._aniiStudii = int.Parse(cuvinte[7]);

        }
        public string Namecurs
        {
            get { return _namecurs; }
            set { _namecurs = value; }
        }
        public string Studentname
        {
            get { return _studentname; }
            set { _studentname = value; }
        }
        public int AnAbsolvire
        {
            get { return _anAbsolvire;}
            set { _anAbsolvire = value;}
        }

        public string Facultate
        {
            get { return _facultatea;}
            set { _facultatea = value;}
        }

        public int AniiStudii
        {
            get { return _aniiStudii; }
            set { _aniiStudii = value;}
        }

        public override string Descriere()
        {
            string desc = " ";
            desc += "Cursul: " + Namecurs + "\n";
            desc += "Student name: " + Studentname + "\n";
            desc += "Anul Absolvire: " + AnAbsolvire + "\n";
            desc += "Anii studiati: " + AniiStudii + "\n";
            return desc;

        }

        public  string DescriereAnTerminal()
        {
            string desc = " ";
            desc += "Cursul: " + Namecurs + "\n";
            desc += "Student name: " + Studentname + "\n";
            desc += "Anul Absolvire: " + AnAbsolvire + "\n";
            desc += "Anii studiati: " + AniiStudii + "\n";
            return desc;

        }







    }
}

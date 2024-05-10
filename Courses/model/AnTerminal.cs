using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class AnTerminal:Course
    {
  
        private string _studentname;
        private int _anAbsolvire;
        private string _facultatea;
        private int _aniiStudii;

        public AnTerminal(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            
            this._studentname = cuvinte[4];
            this._anAbsolvire = int.Parse(cuvinte[5]);
            this._facultatea = cuvinte[6];
            this._aniiStudii = int.Parse(cuvinte[7]);

        }
        public AnTerminal(string type,int id,int profid ,string name,string namestudent,int anAbs,string facultate,int aniiStudii) : base(type, id,profid, name)
        {
            
            this.Studentname = namestudent;
            this.AnAbsolvire = anAbs;
            this.Facultatea = facultate;
            this.AniiStudii= aniiStudii;


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

        public string Facultatea
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
            string desc = " "+base.Descriere();

            desc += "Student name: " + Studentname + "\n";
            desc += "Anul Absolvire: " + AnAbsolvire + "\n";
            desc += "Anii studiati: " + AniiStudii + "\n";
            return desc;

        }

        public  string DescriereAnTerminal()
        {
            string desc = " ";
          
            desc += "Student name: " + Studentname + "\n";
            desc += "Anul Absolvire: " + AnAbsolvire + "\n";
            desc += "Anii studiati: " + AniiStudii + "\n";
            return desc;

        }







    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;


namespace Tema_OnlineSchool_Noilectii.Books.Model
{
    internal class Medicina:Book
    {
        private string _Specialitate;
        private int _AnStudiu;

        public Medicina(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._Specialitate = cuvinte[4];
            this._AnStudiu = int.Parse(cuvinte[5]);
            
          
        }
        public Medicina(string Spec,int Anstudiu,string titlul,string type,int id, int studentid) : base(id,type,titlul, studentid)
        {
            this._Specialitate = Spec;
          
            this._AnStudiu= Anstudiu;

        }


        public string Specialitate
        {
            get { return this._Specialitate; }
            set { this._Specialitate = value; }
        }
        public int AnStudiu
        {
            get { return this._AnStudiu; }
            set { this._AnStudiu = value; }
        }

    
        public override string Descriere()
        {
            string desc = " "+base.Descriere();
            desc += "An de Studiu: " + AnStudiu + "\n";
            desc += "Specialtitate: " + Specialitate + "\n";

            return desc;


        }



    }
}

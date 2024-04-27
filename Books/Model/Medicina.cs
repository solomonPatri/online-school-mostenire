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
        private string _titlul;

        public Medicina(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._Specialitate = cuvinte[3];
            this._AnStudiu = int.Parse(cuvinte[4]);
            this._titlul = cuvinte[5];
          
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

        public string Titlul
        {
            get { return this._titlul; }
            set { this._titlul = value; }
        }

       

        public override string Descriere()
        {
            string desc = " ";
            desc += "Titlul: " + Titlul + "\n";
            desc += "An de Studiu: " + AnStudiu + "\n";
            desc += "Specialtitate: " + Specialitate + "\n";

            return desc;


        }



    }
}

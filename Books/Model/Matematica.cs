
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;

namespace Tema_OnlineSchool_Noilectii.Books.Model
{
    public class Matematica : Book
    {
        private string _Titlul;
        private int _nrPagini;
        private string _continut;

        public Matematica(string Propietati) : base(Propietati)
        {
            string[]cuvinte = Propietati.Split(',');
            this._Titlul = cuvinte[3];
            this._nrPagini = int.Parse(cuvinte[4]);
            this._continut = cuvinte[5];
        }



        public string Titlul
        {
            get { return _Titlul;}
            set { _Titlul = value;}
        }
        public int nrPagini
        {
            get { return _nrPagini;}
            set { _nrPagini = value;}
        }
        public string Continut
        {
            get { return _continut;}
            set { _continut = value;}
        }


        public override string Descriere()
        {
            string desc = " ";
            desc += "Titlul: " + Titlul + "\n";
            desc += "Nr de Pagini: " + nrPagini + "\n";
            desc += "Continut: " + Continut + "\n";
            return desc;
         
        }



    }
}

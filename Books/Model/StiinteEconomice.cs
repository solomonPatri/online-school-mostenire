
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;

namespace Tema_OnlineSchool_Noilectii.Books.Model
{
    internal class StiinteEconomice:Book
    {
        private string _Facultate;
        private string _continut;
        private string _dataeliberari;

        public StiinteEconomice(string Propietati):base(Propietati)
        {
            string[]cuvinte = Propietati.Split(',');
            this._Facultate = cuvinte[4];
            this._continut = cuvinte[5];
            this._dataeliberari = cuvinte[6];
        }
        public StiinteEconomice(string type,int id,int studentid,string facultate,string titlul,string continut,string dataelib) : base(id, type, titlul, studentid)
        {
            this._Facultate = facultate;
            this._continut = continut;
            this._dataeliberari= dataelib;
        }

        public string Facultate
        {
            get { return this._Facultate; }
            set { this._Facultate = value;}
        }
       

  

        public string Continut
        {
            get { return this._continut; }
            set { this._continut = value;}

        }
        public string Dataeliberari
        {
            get { return this._dataeliberari; }
            set { this._dataeliberari = value; }
        }

        public override string Descriere()
        {
            string desc = " "+base.Descriere();
            desc += "Continut: " + Continut + "\n";
            desc += "Facultate: " + Facultate + "\n";
            desc += "Data eliberari: " + Dataeliberari + "\n";
            
            return desc;


        }


    }
}

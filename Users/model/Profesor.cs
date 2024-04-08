
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.admin.model;
using Tema_OnlineSchool_Noilectii.user.model;

namespace online_school.Profesorii.model
{
    internal class Profesor:Admin
    {
        private int _idProf;
        private string _nume;
        private int _nrStudenti;
        private string _facultate;
        

        public Profesor(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._nume = cuvinte[3];
            this._nrStudenti = int.Parse(cuvinte[4]);
            this._facultate = cuvinte[5];
           


        }
        public int IdProfesor
        {
            get { return _idProf; }
            set { _idProf = value; }
        }

        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }
        }

        public int NrStudenti
        {
            get { return _nrStudenti; }
            set { _nrStudenti = value; }
        }
        public string Facultate
        {
            get { return _facultate; }
            set { _facultate = value; }
        }
        

        public override string Descriere()
        {
            string desc = " "+base.Descriere();
            desc += "Nume: " + this._nume + "\n";
            desc += "Nr de studenti: " + this._nrStudenti + "\n";
           desc += "Facultate: " + this._facultate + "\n";
            return desc;
        }

        public string DescriereProfesor()
        {
            string desc = " ";
            desc += "Nume: " + this._nume + "\n";
            desc += "Nr de studenti: " + this._nrStudenti + "\n";
            desc += "Facultate: " + this._facultate + "\n";
          
            return desc;
        }




    }
}

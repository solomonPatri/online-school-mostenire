
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Users.model
{
    internal class Profesor : User
    {
        private int _idProf;
        private string _nume;
        private int _nrStudenti;
        private string _facultate;


        public Profesor(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            _nume = cuvinte[3];
            _nrStudenti = int.Parse(cuvinte[4]);
            _facultate = cuvinte[5];



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
            string desc = " " + base.Descriere();
            desc += "Nume: " + _nume + "\n";
            desc += "Nr de studenti: " + _nrStudenti + "\n";
            desc += "Facultate: " + _facultate + "\n";
            return desc;
        }

        public string DescriereProfesor()
        {
            string desc = " ";
            desc += "Nume: " + _nume + "\n";
            desc += "Nr de studenti: " + _nrStudenti + "\n";
            desc += "Facultate: " + _facultate + "\n";

            return desc;
        }




    }
}

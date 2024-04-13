using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class Doctorat : Course
    {
        private string _NameCurs;
        private string _dataExaminari;
        private string _specialitate;
        private int _nrDiploma;
        public Doctorat(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._NameCurs = cuvinte[3];
            this._dataExaminari = cuvinte[4];
            this._specialitate = cuvinte[5];
            this._nrDiploma = int.Parse(cuvinte[6]);


        }

        public string NameCurs
        {
            get { return _NameCurs; }
            set { _NameCurs = value; }
        }
        public string DataExaminari
        {
            get { return _dataExaminari; }
            set { _dataExaminari = value; }
        }
        public string Specialitate
        {
            get { return _specialitate; }
            set { _specialitate = value; }
        }
        public int nrDiploma
        {
            get { return _nrDiploma; }
            set { _nrDiploma = value; }
        }

        public override string Descriere()
        {
            string desc = " ";
            desc += "Name curs: " + NameCurs + "\n";
            desc += "Data examinari: " + DataExaminari + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            return desc;

        }
        public  string DescriereDoctorat()
        {
            string desc = " ";
            desc += "Name curs: " + NameCurs + "\n";
            desc += "Data examinari: " + DataExaminari + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            return desc;

        }




    }
    }

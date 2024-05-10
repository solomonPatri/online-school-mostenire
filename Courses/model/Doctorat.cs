using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class Doctorat : Course
    {
       
        private string _dataExaminari;
        private string _specialitate;
        private int _nrDiploma;
        public Doctorat(string Propietati) : base(Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._dataExaminari = cuvinte[4];
            this._specialitate = cuvinte[5];
            this._nrDiploma = int.Parse(cuvinte[6]);


        }
        public Doctorat(string type,int id,int profid ,string name,string dataExam,string specialitate,int nrDiploma) : base(type, id,profid,name)
        {
           
            this.DataExaminari = dataExam;
            this.Specialitate = specialitate;
            this.nrDiploma=nrDiploma;

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
            string desc = " "+base.Descriere();
          
            desc += "Data examinari: " + DataExaminari + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            return desc;

        }
        public  string DescriereDoctorat()
        {
            string desc = " ";
            desc += "Data examinari: " + DataExaminari + "\n";
            desc += "Specialitate: " + Specialitate + "\n";
            return desc;

        }




    }
    }

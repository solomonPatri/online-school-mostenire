using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool.Courses.model
{
    public  class Course
    {
        private int _id;
        private int _profesorId;
        private string _type;

        public Course(string Propietati)
        {
            string[] cuvinte = Propietati.Split(',');

           this._id = int.Parse(cuvinte[1]);
           this._profesorId = int.Parse(cuvinte[2]);
           this._type = cuvinte[0];
         
        }

        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        
        public int Profesorid
        {
            get { return _profesorId; }
            set { _profesorId = value; }

        }
       


        public virtual string Descriere()
        {
            string desc = "  ";
            desc += "type: " + Type + "\n";
            
            return desc;



        }

        



    }
}

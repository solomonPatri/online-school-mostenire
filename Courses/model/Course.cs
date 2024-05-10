using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    public  class Course
    {
        private int _id;
        private int _profesorId;
        private string _type;
        private string _name;

        public Course(string Propietati)
        {
            string[] cuvinte = Propietati.Split(',');

           this._id = int.Parse(cuvinte[1]);
           this._profesorId = int.Parse(cuvinte[2]);
           this._type = cuvinte[0];
           this._name = cuvinte[3];
         
        }
        public Course(string type,int id,int profId,string name)
        {
          this._profesorId=profId;
            this.Id=id;
            this.Type = type;
            this.Name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
            desc += "Name:" + Name + "\n";
            
            return desc;



        }

        



    }
}

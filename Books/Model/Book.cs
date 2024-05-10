using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Books.Model
{
    public class Book
    {
        private int _id;
        private int _studentId;
        private string _type;
        private string _title;

        public Book(string Propietati)
        {
            string[] cuvinte = Propietati.Split(',');
            this._id = int.Parse(cuvinte[1]);
            this._studentId = int.Parse(cuvinte[2]);
            this._type = cuvinte[0];
            this._title = cuvinte[3];

        }

        public Book(int id,string Type,string title,int studentid)
        {
            this._studentId=studentid;
            this._id = id;
            this._type = Type;
            this._title = title;
        }

       
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }

        }
      
        public string Type
        {
            get { return _type; }
            set { _type = value; }

        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public virtual string Descriere()
        {
            string desc = " ";
            desc += "Tipul: " + this.Type + "\n";
            desc += "Titlul:" + this.Title + "\n";

            return desc; 

        }


      






    }
}

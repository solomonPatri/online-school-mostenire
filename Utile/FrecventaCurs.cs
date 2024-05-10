using Tema_OnlineSchool_Noilectii.Courses.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Utile
{
    public class FrecventaCurs
    {
        public int corsId;   // id cursului ex:30
        public int corsFreq; // nr de ori care este inscris  ex:3
        public Course course; // cursul cu toate datele


        public string Info()
        {
            string text = "";
            text += "Cursul " + course.Name + " are " + this.corsFreq + " participanti";
            return text;
        }
    }
}

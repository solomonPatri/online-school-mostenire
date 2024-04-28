using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;
using Tema_OnlineSchool_Noilectii.Books.Model;


namespace Tema_OnlineSchool_Noilectii.Courses.model
{
    internal class ServiceCourse
    {
        private List<Course> _curs;
        private string _filePath;

        public ServiceCourse()
        {
            _curs = new List<Course>();
            this._filePath = GetDirectory();
            this.load();



        }


        public void load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string line = " ";

                    while ((line = sr.ReadLine()) != null)
                    {

                        switch (line.Split(',')[0])
                        {

                            case "An 1":

                                An1 an1 = new An1(line);
                                _curs.Add(an1);
                                break;


                            case "An Terminal":
                               AnTerminal anterminal = new AnTerminal(line);
                                _curs.Add(anterminal);

                                break;

                            case "Master":
                                Master master = new Master(line);
                                _curs.Add(master);
                                break;
                            case "Doctorat":
                                Doctorat doctorat = new Doctorat(line);
                                _curs.Add(doctorat);
                                break;
                            default:
                                
                                break;

                        }


                    }



                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }







        }
        private String GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory,"data");
            string filepath = Path.Combine(dataFolder, "Courses.txt");
            return filepath;

        }

        public void AfisareAllCourse()
        {
            for(int i =0;i< _curs.Count; i++)
            {
                Console.WriteLine(_curs[i].Descriere());


            }



        }



        public Course GetCourseById(int id)
        {
            List<Course> curs = _curs;
            for (int i = 0; i < curs.Count; i++)
            {
                if (_curs[i].Id == id)
                {
                    return _curs[i];


                }

            }
            return null;

        }
        public int GenerateIdUnique()
        {
            Random random = new Random();
            int nrrandom = random.Next(100, 10000);

            while (GetCourseById(nrrandom) != null)
            {
                nrrandom = random.Next(100, 10000);
            }

            return nrrandom;


        }

        public void adaugarecourse(Course newcourse)
        {
            newcourse.Id = this.GenerateIdUnique();
            this._curs.Add(newcourse);

        }


        public void afisareAll()
        {
            foreach(Course course in _curs)
            {
                Console.WriteLine(course.Descriere());
            }

        }
        public Course returnCursuri(string type)
        {
            for(int i =0;i< _curs.Count;i++)
            {
                if(_curs is Course)
                {
                    if (_curs[i].Type.Equals(type))
                    {
                        return _curs[i];

                    }


                }


            }
            return null;
        }

        public bool VerificareCourse(string name)
        {
            foreach (Course Course in _curs)
            {
                if(Course is An1 || Course is AnTerminal ||Course is Master || Course is Doctorat)
                {

                    if((Course as An1).NameCurs.Equals(name))
                    {
                        return true;
                    }
                    if((Course as AnTerminal).Namecurs.Equals(name))
                    {
                        return true;
                    }
                    if((Course as Master).NameCurs.Equals(name))
                    {

                        return true;
                    }
                    if((Course is Doctorat).Equals(name))
                    {
                        return true;

                    }


                }
            }
            return false;







        }




    }
}

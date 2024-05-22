using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Utile;

namespace Tema_OnlineSchool_Noilectii.Courses.service
{
    internal class ServiceCourse
    {
        private List<Course> _curs;
        private string _filePath;

        public ServiceCourse()
        {
            _curs = new List<Course>();
            _filePath = GetDirectory();
            load();



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
        private string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory, "data");
            string filepath = Path.Combine(dataFolder, "Courses.txt");
            return filepath;

        }

        public void AfisareAllCourse()
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                Console.WriteLine(_curs[i].Descriere());


            }



        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            for(int i=0; i< _curs.Count; i++)
            {
                courses.Add(_curs[i]);
            }
            return courses;

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
            newcourse.Id = GenerateIdUnique();
            _curs.Add(newcourse);

        }

        public Course returnCursuri(string type)
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs is Course)
                {
                    if (_curs[i].Type.Equals(type))
                    {
                        return _curs[i];

                    }


                }


            }
            return null;
        }
         public Course GetCourseBytitle(string title)
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Name.Equals(title))
                {
                    return _curs[i];
                }


            }

            return null;

        }


        public int GetCourseByName(string name)
        {
            for(int i=0; i< _curs.Count; i++)
            {
                if (_curs[i].Name.Equals(name))
                {
                    return _curs[i].Id;


                }


            }
            return 0;
        }
        public bool VerificareCourse(string name)
        {
            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Name.Equals(name))
                {

                    return true;
                }
            }
            return false;







        }

        public List<Course> FiltrareCourseByProfId(int idprof)
        {
            List<Course> curs = new List<Course>();

            for (int i = 0; i < _curs.Count; i++)
            {
                if (_curs[i].Profesorid.Equals(idprof))
                {

                    curs.Add(_curs[i]);
                  


                }

            }
            return curs;
        }



        public List<Course> CourseLista(int idprof)
        {
            List<Course> cursuri = FiltrareCourseByProfId(idprof);

            for(int i=0; i < cursuri.Count;i++)
            {
                Console.WriteLine(cursuri[i].Descriere());

            }

            return cursuri;

        }
        public bool deleteCurs(string name, int idprof)
        {
            List<Course> cursuri = CourseLista(idprof);
            for (int i = 0; i < cursuri.Count; i++)
            {
                if (cursuri[i].Name.Equals(name))
                {
                    _curs.Remove(cursuri[i]);
                    return true;
                }


            }
            return false;


        }


        public List<Course> GetCourseByEnrol(List<int> idCursuri)
        {
           List<Course> cursuri = new List<Course> ();

            for(int i=0;i<_curs.Count;i++)
            {
                if (idCursuri.Contains(_curs[i].Id))
                {
                    cursuri.Add(_curs[i]);


                }


            }

            return cursuri;

        }

        public void PopularFrecvCursuri(List<FrecventaCurs> frecventaCurs)
        {
            foreach(var frecvent in frecventaCurs)
            {
                frecvent.course = GetCourseById(frecvent.corsId);


            }




        }

        public List<int> GetCourseByProfId(int profId)
        {
            List<int> idcursuri = new List<int>();
            for(int i=0;i<_curs.Count; i++)
            {
                if (profId.Equals(_curs[i].Profesorid))
                {
                    idcursuri.Add(_curs[i].Id);
                }


            }

            return idcursuri;
        }






    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;


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






    }
}

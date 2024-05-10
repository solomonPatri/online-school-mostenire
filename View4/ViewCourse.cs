using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Books.service;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Courses.service;
using Tema_OnlineSchool_Noilectii.Users.model;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewCourse
    {
        private ServiceCourse _servicecourse;
        private Profesor _prof;

        public ViewCourse(Profesor prof)
        {
            _servicecourse = new ServiceCourse();
            _prof = prof;
            play();
        }
        public void meniu()
        {
            Console.WriteLine("1-> Toate Cursurile Disponibile:");
            Console.WriteLine("2-> Adaugarea unui Curs nou");
            Console.WriteLine("3->Stergerea unui curs");
            Console.WriteLine("4->Modificarea unui curs");


        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();

                int alegere = int.Parse(Console.ReadLine());

                switch (alegere)
                {
                    case 1:
                        AfisareAllCourses(); // functionabil
                        break;
                    case 2:
                        AdaugareCourse(); //functionabil
                        break;
                    case 3:
                        StergereaCourseaProf(); // functionabil
                        break;
                    case 4:

                        break;











                }



            }








        }

        public void AfisareAllCourses()
        {
            _servicecourse.AfisareAllCourse();

        }

        public void AdaugareCourse()
        {
            Console.WriteLine("Introduceti tipul de curs care doriti sa modificati:" + "\n");
            Console.WriteLine("An 1,An Terminal,Doctorat,Master");
            string type = Console.ReadLine();

            if(type.Equals("An 1"))
            {
                Console.WriteLine("Introduceti numele cursului:" + "\n");
                string name = Console.ReadLine();
                Console.WriteLine("Introduceti departamentul:" + "\n");
                string depart =Console.ReadLine();
                Console.WriteLine("Introduceti Facultatea" + "\n");
                string faculty = Console.ReadLine();

               An1 an1 = new An1(type,_servicecourse.GenerateIdUnique(),_prof.IdProfesor,name,depart,faculty);
                bool verificare = _servicecourse.VerificareCourse(name);
                if (verificare = true)
                {
                    _servicecourse.adaugarecourse(an1);
                    _servicecourse.AfisareAllCourse();
                }
                else
                {
                    Console.WriteLine("Deja exista  curs cu acest nume.");
                }

            }
            else
            {

                if(type.Equals("An Terminal"))
                {
                    Console.WriteLine("Introduceti numele cursului:" + "\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Introduceti Numele studentului:" + "\n");
                    string studentname = Console.ReadLine();
                    Console.WriteLine("Introduceti Anul Absolvirii" + "\n");
                    int AnAbs = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti Facultate:");
                    string Facultaty = Console.ReadLine();
                    Console.WriteLine("Introduceti anul de studii:");
                    int AnStud = int.Parse(Console.ReadLine());


                    AnTerminal ant = new AnTerminal(type,_servicecourse.GenerateIdUnique(), _prof.IdProfesor,name,studentname, AnAbs,Facultaty,AnStud);


                    bool verificare = _servicecourse.VerificareCourse(name);

                    if (verificare = true)
                    {
                        _servicecourse.adaugarecourse(ant);
                        _servicecourse.AfisareAllCourse();
                    }
                    else
                    {
                        Console.WriteLine("Deja exista  curs cu acest nume.");
                    }
                }
                else
                {
                    if (type.Equals("Master"))
                    {
                        Console.WriteLine("Introduceti numele cursului:" + "\n");
                        string name = Console.ReadLine();
                        Console.WriteLine("Introduceti Specialitatea:" + "\n");
                        string specialitate = Console.ReadLine();
                        Console.WriteLine("Introduceti Facultatea" + "\n");
                        string faculty = Console.ReadLine();
                        Console.WriteLine("Introduceti nr de studenti"+"\n");
                        int nrstud = int.Parse(Console.ReadLine()) ;

                        Master master = new Master(type,_servicecourse.GenerateIdUnique(),_prof.IdProfesor,name,faculty,specialitate,nrstud);
                        bool verificare = _servicecourse.VerificareCourse(name);

                        if (verificare = true)
                        {
                            _servicecourse.adaugarecourse(master);
                            _servicecourse.AfisareAllCourse();
                        }
                        else
                        {
                            Console.WriteLine("Deja exista  curs cu acest nume.");
                        }

                    }
                    else
                    {
                        if (type.Equals("Doctorat"))
                        {
                            Console.WriteLine("Introduceti numele cursului:" + "\n");
                            string name = Console.ReadLine();
                            Console.WriteLine("Introduceti Data examinarii:" + "\n");
                            string dataexa = Console.ReadLine();
                            Console.WriteLine("Introduceti specialitatea" + "\n");
                            string specialitate = Console.ReadLine();
                            Console.WriteLine("Introduceti nr de Diploma:" + "\n");
                            int nrDipl = int.Parse(Console.ReadLine()) ;

                            Doctorat doct = new Doctorat(type,_servicecourse.GenerateIdUnique(),_prof.IdProfesor,name,dataexa,specialitate,nrDipl);
                            bool verificare = _servicecourse.VerificareCourse(name);
                            if (verificare = true)
                            {
                                _servicecourse.adaugarecourse(doct);
                                _servicecourse.AfisareAllCourse();
                            }
                            else
                            {
                                Console.WriteLine("Deja exista  curs cu acest nume.");
                            }
                        }
                    }



                }


            }






        }

        public void StergereaCourseaProf()
        {
            Console.WriteLine("Cartiile dumneavoastra sunt:");

            _servicecourse.CourseLista(_prof.IdProfesor);

            Console.WriteLine("Introduceti numele cursurului care doriti sa stergeti:" + "n");
            string name = Console.ReadLine();


            bool delete = _servicecourse.deleteCurs(name, _prof.IdProfesor);
            if (delete)
            {
                Console.WriteLine("Cursul a fost sters cu succes, acuma cursurile dumneavoastra sunt:" + "\n");
                _servicecourse.CourseLista(_prof.IdProfesor);
            }
            else
            {
                Console.WriteLine("Incercati din nou!");
            }






        }










































    }
}

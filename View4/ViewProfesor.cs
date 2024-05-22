using online_school.Enrolments.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Courses.service;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Users.service;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewProfesor
    {
        private ServiceEnrolment _serviceenrol;
        private Profesor _prof;
        private ServiceCourse _servicecurs;
        private ServiceUser _serviceuser;
       

        public ViewProfesor(Profesor profesor)
        {
           _serviceuser = new ServiceUser();
            _serviceenrol = new ServiceEnrolment();
            _servicecurs = new ServiceCourse();
            _prof = profesor;
            play();
        }
        public void meniu()
        {

            Console.WriteLine("1-> Afisare Cursuri predate");
            Console.WriteLine("2-> Studentii care le preda:");
            Console.WriteLine("3->Cursul cu cei mai multi studenti inscris");
            Console.WriteLine("4->Media studentiilor din curs");
            Console.WriteLine("5->Stergerea Curs:");
            Console.WriteLine("6->Adaugare Curs:");
            Console.WriteLine("7->Modificare curs:");
            Console.WriteLine("8->Deconectare.");


        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch (nrales)
                {

                    case 1:
                        afisareCursuriProf();
                        break;
                    case 2:
                        StudentiiProfesorului();
                            break;
                    case 3:
                        CursProfesorMaxStudenti();
                        break;
                    case 4:
                        mediaStudentiilor();
                        break;
                    case 5:
                        StergereaCurs();
                        break;
                    case 6:
                        AdaugareCurs();
                        break;
                    case 7:
                        modificareCurs();
                        break;
                    case 8:
                        run = false;
                        break;


                }


            }




        }

        public void afisareCursuriProf()
        {
            Console.WriteLine("Cursuriile sunt :");

            _servicecurs.AfisareAllCourse();
        }

        public void StudentiiProfesorului()
        {
            Console.WriteLine("Studenti care ii are Profesorul" + _prof.Nume + " sunt:");
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.Id);
            List<int> idstudenti =_serviceenrol.GetAllStudentIdByCursId(idiuri);
            List<User> courses =_serviceuser.AfisareUserByIdiuri(idstudenti);

            for(int z=0;z<courses.Count;z++)
            {
                Console.WriteLine(courses[z].Descriere());

            }



        }     

        public void CursProfesorMaxStudenti()
        {
            List<Course> cursurile = _servicecurs.GetCourses();
            Console.WriteLine("Cursurile care are profesorul sunt: " + "\n");
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.Id);
            for (int i = 0; i < idiuri.Count; i++)
            {
                if (cursurile[i].Id.Equals(idiuri[i]))
                {

                    Console.WriteLine(cursurile[i].Descriere());
                }
            }
        }

        public void mediaStudentiilor()
        {
            Console.WriteLine("Media studentiilor este:");
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.Id);
            List<int> idstudenti = _serviceenrol.GetAllStudentIdByCursId(idiuri);
            double  media= _serviceuser.Media(idstudenti);
            Console.WriteLine(media);

        }

        public void StergereaCurs()
        {
            Console.WriteLine("Introduceti cursul care doriti sa stergeti: ");
            string nameales = Console.ReadLine();
            List<Course> cursuriprof = _servicecurs.CourseLista(_prof.Id);
            bool verificare = _servicecurs.deleteCurs(nameales, _prof.Id);
            if (verificare)
            {
                Console.WriteLine("Cursul a fost sters cu succes!");
                _servicecurs.AfisareAllCourse();


            }
            else
            {
                Console.WriteLine("Nu sa gasit acest curs!");
            }


        }

        public void AdaugareCurs()
        {
            Console.WriteLine("Introduceti Tipul de Course care doriti sa adaugati");
            Console.WriteLine("An 1 / An Terminal / Doctorat / Master ");
            string type = Console.ReadLine();
            switch (type)
            {
                case "An 1":
                    Console.WriteLine("Introduceti datele noi:");
                    Console.WriteLine("Name curs");
                    string name = Console.ReadLine();
                    Console.WriteLine("Departament:");
                    string departament = Console.ReadLine();
                    Console.WriteLine("Facultate:");
                    string faculaty = Console.ReadLine();

                    An1  an1 = new An1(type,_servicecurs.GenerateIdUnique(),_prof.Id,name,departament,faculaty);
                    bool verificare = _servicecurs.VerificareCourse(name);
                    if (verificare)
                    {
                        Console.WriteLine("Deja exista acest curs!");

                    }
                    else
                    {   _servicecurs.adaugarecourse(an1);
                        Console.WriteLine("Sa adaugat cu succes acest curs!");
                        
                    }
                    break;

                case "An Terminal":

                    Console.WriteLine("Itroduceti cursul nou:" + "\n");
                    Console.WriteLine("Name :");
                    string namecurs = Console.ReadLine();
                    Console.WriteLine("Student name: ");
                    string studname = Console.ReadLine();
                    Console.WriteLine("An absolvire:");
                    int AnAbs = int.Parse(Console.ReadLine());
                    Console.WriteLine("Facultate:");
                    string facult = Console.ReadLine();
                    Console.WriteLine(" Anii de studii:");
                    int anistud = int.Parse(Console.ReadLine());

                    AnTerminal anter = new AnTerminal(type,_servicecurs.GenerateIdUnique(),_prof.Id,namecurs,studname,AnAbs,facult,anistud);
                    bool verif = _servicecurs.VerificareCourse(namecurs);
                    if(verif)
                    {
                        Console.WriteLine("Deja exista acest curs");

                    }
                    else
                    {
                        _servicecurs.adaugarecourse(anter);
                        Console.WriteLine("Sa adaugat cu succes acest curs");
                       

                    }

                    break;

                case "Doctorat":
                    Console.WriteLine("Introduceti datele noi a cursului");
                    Console.WriteLine("Name:");
                    string numcurs = Console.ReadLine();
                    Console.WriteLine("Data Examinari:");
                    string dataexa = Console.ReadLine();
                    Console.WriteLine("Specialitate:");
                    string Spec = Console.ReadLine();
                    Console.WriteLine("Nr de Diploma:");
                    int nrdiploma = int.Parse(Console.ReadLine());  

                    Doctorat doc = new Doctorat(type,_servicecurs.GenerateIdUnique(),_prof.Id,numcurs,dataexa, Spec,nrdiploma);
                    bool ver = _servicecurs.VerificareCourse(numcurs);
                    if(ver)
                    {
                        Console.WriteLine("deja exista acest curs!");

                    }
                    else
                    {

                        _servicecurs.adaugarecourse(doc);
                        Console.WriteLine("Sa adaugat cu succes acest curs");
                    }



                    break;
                case "Master":
                    Console.WriteLine("Introduceti noul curs");
                    Console.WriteLine("Name:");
                    string numecurs = Console.ReadLine();
                    Console.WriteLine("Facultate");
                    string Facultate = Console.ReadLine();
                    Console.WriteLine("Specialitate:");
                    string specialitate = Console.ReadLine();
                    Console.WriteLine("Nr de studenti: ");
                    int nrstud = int.Parse(Console.ReadLine());

                    Master master = new Master(type,_servicecurs.GenerateIdUnique(),_prof.Id,numecurs,Facultate,specialitate,nrstud);
                    bool verifica = _servicecurs.VerificareCourse(numecurs);
                    if(verifica )
                    {
                        Console.WriteLine("Deja exista acest curs!");
                    }
                    else
                    {
                        _servicecurs.adaugarecourse(master);
                        Console.WriteLine("Sa adaugat acest cu succes acest curs");

                    }
                    break;
            }







        }

        public void modificareCurs()
        {
            Console.WriteLine("An 1/ An Terminal / Doctorat / Master");
            string ales = Console.ReadLine();

            switch (ales)
            {
                case "An 1":
                    Console.WriteLine("Introduceti cursul care doriti sa modificati:" + "\n");
                    string titl = Console.ReadLine();
                    An1 an1 = this._servicecurs.GetCourseBytitle(titl) as An1;
                    Console.WriteLine("Introduceti Modificarile:" + "\n");
                    Console.WriteLine("Titlul:" + "\n");
                    string newtitle = Console.ReadLine();
                    an1.Name = newtitle;
                    Console.WriteLine("Departament:");
                    string departamet = Console.ReadLine();
                    an1.Departament = departamet;
                    Console.WriteLine("Facultate:");
                    string facult = Console.ReadLine();
                    an1.Facultate = facult;

                    break;

                case "An Terminal":
                    Console.WriteLine("Intoduceti titlul cursului care doriti sa modificati");
                    string title = Console.ReadLine();
                    AnTerminal anTer = this._servicecurs.GetCourseBytitle(title) as AnTerminal;
                    Console.WriteLine("Introduceti datele noi:");
                    Console.WriteLine("Numele:" + "\n");
                    string name = Console.ReadLine();
                    anTer.Name = name;
                    Console.WriteLine("Numele stduedntului:" + "\n");
                    string stdname = Console.ReadLine();
                    anTer.Studentname = stdname;
                    Console.WriteLine("An Absolvire:" + "\n");
                    int anabs = int.Parse(Console.ReadLine());
                    anTer.AnAbsolvire = anabs;
                    Console.WriteLine("facultatea:" + "\n");
                    string facultate = Console.ReadLine();
                    anTer.Facultatea = facultate;
                    Console.WriteLine("Anii de Studii" + "\n");
                    int Anstd = int.Parse(Console.ReadLine());
                    anTer.AniiStudii = Anstd;
                    break;

                case "Doctorat":

                    Console.WriteLine("Introduceti numele cursului care doriti sa stergeti:");
                    string namecurs = Console.ReadLine();
                    Doctorat doc = this._servicecurs.GetCourseBytitle(namecurs) as Doctorat;
                    Console.WriteLine("Introduceti modificariile:");
                    Console.WriteLine("Numele cursului; " + "\n");
                    string newname = Console.ReadLine();
                    doc.Name = newname;
                    Console.WriteLine("Data Examinari:" + "\n");
                    string dataExa = Console.ReadLine();
                    doc.DataExaminari = dataExa;
                    Console.WriteLine("Specialitate:" + "\n");
                    string spec = Console.ReadLine();
                    doc.Specialitate = spec;
                    Console.WriteLine("Nr de Diploma:" + "\n");
                    int nrdiploma = int.Parse(Console.ReadLine());
                    doc.nrDiploma = nrdiploma;
                    break;
                case "Master":
                    Console.WriteLine("Introduceti numele cursului care doriti sa stergeti:");
                    string nameold = Console.ReadLine();
                    Master master = this._servicecurs.GetCourseBytitle(nameold) as Master;
                    Console.WriteLine("Introduceti modificariile:");
                    Console.WriteLine("Numele cursului:" + "\n");
                    string nouname = Console.ReadLine();
                    master.Name = nouname;
                    Console.WriteLine("facultate:" + "\n");
                    string Facultate = Console.ReadLine();
                    master.Facultate = Facultate;
                    Console.WriteLine("Nr de Stduenti" + "\n");
                    int nrstudentii = int.Parse(Console.ReadLine());
                    master.NrStudenti = nrstudentii;


                    break;






            }







        }

    }
}

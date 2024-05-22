using online_school.Enrolments.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii;
using Tema_OnlineSchool_Noilectii.Books.service;
using Tema_OnlineSchool_Noilectii.Courses.service;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Enrolments.model;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Utile;
using System.Security.AccessControl;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewStudent
    {

        private ServiceBook _servicebook;
        private ServiceEnrolment _serviceenrolment;
        private ServiceCourse _servicecourse;
        private Student _student;

        public ViewStudent(Student student)
        {
            _servicebook = new ServiceBook();
            _serviceenrolment = new ServiceEnrolment();
            _servicecourse = new ServiceCourse();
            _student = student;
            play();

        }

        public  void meniu() {

            Console.WriteLine("1-> Afisarea cursuri: ");
            Console.WriteLine("2-> Afisarea Cursurile studentului:");
            Console.WriteLine("3->Inscrierea unui curs: ");
            Console.WriteLine("4-> Introduceti cursul care doriti sa-l stergeti: ");
            Console.WriteLine("5->Afisare Curs popular: ");
            Console.WriteLine("6->Afisare toate cursuriile in functie de popular:");
            Console.WriteLine("7->Books studentii");
            Console.WriteLine("8->Stergeti cartea.");
            Console.WriteLine("9->Modificati.");
            Console.WriteLine("10->Deconectare.");

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
                        AfisareAllCourses();
                        break;
                    case 2:
                        AfisareCursStudent();
                        break;
                    case 3:

                        InscriereaunuiCurs();
                        break;
                    case 4:
                        DeleteCurs();
                        break;
                    case 5:
                        CursPopular();
                        break;
                    case 6:
                        AfisareCursPopular();
                        break;
                    case 7:
                        BooksStudent();
                        break;
                    case 8:
                        DeleteBook();
                        break;
                    case 9:
                        Modificare();
                        break;

                    case 10:
                        run = false;
                        break;
                }


            }





        }

        public void AfisareAllCourses()
        {
            _servicecourse.AfisareAllCourse();

        }

        public void AfisareCursStudent()
        {
          

           Console.WriteLine("Cursuriile dumneavoastra sunt:" + "\n");

            var list1  = _serviceenrolment.GetAllEnrolByStudentId(_student.Id);
            var list = _servicecourse.GetCourseByEnrol(list1);

            for(int i=0;i<list.Count; i++)
            {
                Console.WriteLine(list[i].Descriere());

            }




        }

     
        public void InscriereaunuiCurs()
        {
            Console.WriteLine("Introduceti numele cursului care doriti sa va inscrieti:" + "\n");

            string name = Console.ReadLine();

          int cursul =  _servicecourse.GetCourseByName(name);

           Enrolment enrol = new Enrolment(_serviceenrolment.GenerateIdUnique(),_student.Id,cursul);

           _serviceenrolment.adaugareEnrol(enrol);

            AfisareCursStudent();
        }

        public void DeleteCurs()
        {
            Console.WriteLine("Introduceti cursul care doriti sa va stergeti: ");

            string numecurs = Console.ReadLine();

            int idcurs = _servicecourse.GetCourseByName(numecurs);

            bool verificare = _serviceenrolment.GetEnrolByCursId(_student.Id, idcurs);

            if(verificare)
            {
                Console.WriteLine("Nu sa gasit cursul");


            }
            else
            {
                _serviceenrolment.DeleteEnrolment(_student.Id,idcurs);
                Console.WriteLine("Cursurile sunt: ");
                AfisareCursStudent();



            }





        }

        public void CursPopular()
        {

            Console.WriteLine("Cursrul cel mai popular este:");
            int idcurs = _serviceenrolment.FindMosPopularCourse();
            Course curspop = _servicecourse.GetCourseById(idcurs);
            Console.WriteLine(curspop.Descriere());

        }

        public void AfisareCursPopular()
        {

            List<FrecventaCurs> frecventacurs = _serviceenrolment.FrecventaCursuriSortate();
            _servicecourse.PopularFrecvCursuri(frecventacurs);

            foreach(var frecv in  frecventacurs)
            {

                Console.WriteLine(frecv.Info());

            }

        }

        public void BooksStudent()
        {

            Console.WriteLine("Cartile studentului disponibile sunt:" + "\n");

            List<Book> books = _servicebook.FiltrareByStudentId(4);
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].Descriere());

            }

        }

        public void DeleteBook()
        {
            Console.WriteLine("Numele cartii de sters");

            string numecurs = Console.ReadLine();

            bool verificare = _servicebook.deleteBook(numecurs,_student.Id);


             if (verificare)
             {
                    Console.WriteLine("Cartea a fost sterasa cu succes, acuma cartiile dumneavoastra sunt:" + "\n");
                    _servicebook.BookLista(_student.Id);
                
            }else
                {
                    Console.WriteLine("Incercati din nou!");
                }


            




        }

        public void ModificareBook()
        {
            Console.WriteLine("Matematica/Medicina/Stiinte Economice");

            string ales = Console.ReadLine();

            switch (ales)
            {
                case "Matematica":

                    Console.WriteLine("Introduceti titlul care doriti sa modificati:");
                    string title = Console.ReadLine();
                    Matematica book = this._servicebook.GetBookByTitle(title) as Matematica ; 


                    Console.WriteLine("Introduceti modificariile:");
                    Console.WriteLine("Tillul:");
                    string newtitle = Console.ReadLine();

                    book.Title = newtitle;
                    Console.WriteLine("nr de pagini:");
                    int nrpag = int.Parse(Console.ReadLine());
                    book.nrPagini = nrpag;
                    Console.WriteLine("Introduceti continutul");
                    string continut = Console.ReadLine();
                    book.Continut = continut;
                   
                    break;

                case "Medicina":

                    Console.WriteLine("Introduceti titlul care dorit sa modificati");
                    string titlu = Console.ReadLine() ;
                    Medicina med = this._servicebook.GetBookByTitle(titlu) as Medicina;

                    Console.WriteLine("Introduceti modificariile");
                    Console.WriteLine("Titlul:");
                    string newtitlu = Console.ReadLine() ;
                    med.Title = newtitlu;
                    Console.WriteLine("Specialitate:");
                    string spec = Console.ReadLine() ;
                    med.Specialitate = spec;
                    Console.WriteLine("An de studiu:");
                    int anstudiu = int.Parse (Console.ReadLine());
                    med.AnStudiu = anstudiu;
                    break;

                case "Stiinte Economice ":

                    Console.WriteLine("Introduceti titlul care doriti sa modificati:" + "\n");
                    string titl = Console.ReadLine() ;
                    StiinteEconomice econ = this._servicebook.GetBookByTitle(titl) as StiinteEconomice;

                    Console.WriteLine("Introduceti modificariile:" + "\n");
                    Console.WriteLine("Titlul:");
                    string newtitl = Console.ReadLine() ;
                    econ.Title = newtitl;
                    Console.WriteLine("Facultate:"+"\n");
                    string facultate = Console.ReadLine() ;
                    econ.Facultate = facultate;
                    Console.WriteLine("Continut:");
                    string content = Console.ReadLine() ;
                    econ.Continut = content;
                    Console.WriteLine("Data eliberari:");
                    string dataElib = Console.ReadLine() ;
                    econ.Dataeliberari = dataElib;

                    break;



            }









        }


        public void modificareCurs()
        {
            Console.WriteLine("An 1/ An Terminal / Doctorat / Master");
            string ales = Console.ReadLine() ;

            switch (ales)
            {
                case "An 1":
                    Console.WriteLine("Introduceti cursul care doriti sa modificati:" + "\n");
                    string titl = Console.ReadLine() ;
                    An1 an1 = this._servicecourse.GetCourseBytitle(titl) as An1 ;
                    Console.WriteLine("Introduceti Modificarile:" + "\n");
                    Console.WriteLine("Titlul:" + "\n");
                    string newtitle = Console.ReadLine() ;
                    an1.Name = newtitle;
                    Console.WriteLine("Departament:");
                    string departamet = Console.ReadLine() ;
                    an1.Departament = departamet;
                    Console.WriteLine("Facultate:");
                    string facult = Console.ReadLine() ;
                    an1.Facultate = facult;

                    break;

                case "An Terminal":
                    Console.WriteLine("Intoduceti titlul cursului care doriti sa modificati");
                    string title = Console.ReadLine() ;
                     AnTerminal anTer = this._servicecourse.GetCourseBytitle(title) as AnTerminal ;
                    Console.WriteLine("Introduceti datele noi:");
                    Console.WriteLine("Numele:" + "\n");
                    string name = Console.ReadLine() ;
                    anTer.Name = name;
                    Console.WriteLine("Numele stduedntului:" + "\n");
                    string stdname = Console.ReadLine() ;
                    anTer.Studentname = stdname;
                    Console.WriteLine("An Absolvire:" + "\n");
                    int anabs = int.Parse(Console.ReadLine()) ; 
                    anTer.AnAbsolvire = anabs ;
                    Console.WriteLine("facultatea:" + "\n");
                    string facultate = Console.ReadLine() ;
                    anTer.Facultatea = facultate;
                    Console.WriteLine("Anii de Studii"+"\n");
                    int Anstd = int.Parse(Console.ReadLine()) ;
                    anTer.AniiStudii = Anstd;
                    break;

                case "Doctorat":

                    Console.WriteLine("Introduceti numele cursului care doriti sa stergeti:");
                    string namecurs = Console.ReadLine() ;
                    Doctorat doc = this._servicecourse.GetCourseBytitle(namecurs) as Doctorat ;
                    Console.WriteLine("Introduceti modificariile:");
                    Console.WriteLine("Numele cursului; " + "\n");
                    string newname= Console.ReadLine();
                    doc.Name = newname;
                    Console.WriteLine("Data Examinari:" + "\n");
                    string dataExa = Console.ReadLine() ;
                    doc.DataExaminari = dataExa;
                    Console.WriteLine("Specialitate:" + "\n");
                    string spec = Console.ReadLine() ;
                    doc.Specialitate = spec;
                    Console.WriteLine("Nr de Diploma:" + "\n");
                    int nrdiploma = int.Parse(Console.ReadLine()) ;
                    doc.nrDiploma = nrdiploma;
                    break;
                case "Master":
                    Console.WriteLine("Introduceti numele cursului care doriti sa stergeti:");
                    string nameold = Console.ReadLine() ;
                    Master master = this._servicecourse.GetCourseBytitle(nameold) as Master ;
                    Console.WriteLine("Introduceti modificariile:");
                    Console.WriteLine("Numele cursului:"+"\n");
                    string nouname = Console.ReadLine() ;
                    master.Name = nouname;
                    Console.WriteLine("facultate:" + "\n");
                    string Facultate = Console.ReadLine() ;
                    master.Facultate = Facultate;
                    Console.WriteLine("Nr de Stduenti" + "\n");
                    int nrstudentii = int.Parse(Console.ReadLine());
                    master.NrStudenti = nrstudentii;


                    break;






            }







        }




        public void Modificare()
        {
            Console.WriteLine("Ce doriti sa modificati:");
            Console.WriteLine("1->Carte.");
            Console.WriteLine("2->Curs");

            int alegere = int.Parse(Console.ReadLine());

            switch(alegere)
            {
                case 1:

                    ModificareBook();

                    break;

                    case 2:

                    modificareCurs();
                    break;

            }









        }


    }
}

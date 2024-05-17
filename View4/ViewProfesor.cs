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
                   
                        break;
                    case 5:
                    
                        break;
                    case 6:
                        
                        break;
                    case 7:
                       
                        break;
                    case 8:

                       

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
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.IdProfesor);
            List<int> idstudenti =_serviceenrol.GetAllStudentIdByCursId(idiuri);
            List<User> courses =_serviceuser.AfisareUserByIdiuri(idstudenti);

            for(int z=0;z<courses.Count;z++)
            {
                Console.WriteLine(courses[z].Descriere());

            }



        }     //functia din serviceuser trebuie verificata GetCourseByProfId

        public void CursProfesorMaxStudenti()
        {
            List<Course> cursurile = _servicecurs.GetCourses();
            Console.WriteLine("Cursurile care are profesorul sunt: " + "\n");
            List<int> idiuri = _servicecurs.GetCourseByProfId(_prof.IdProfesor);
            for (int i = 0; i < idiuri.Count; i++)
            {
                if (cursurile[i].Id.Equals(idiuri[i]))
                {

                    Console.WriteLine(cursurile[i].Descriere());
                }
            }
        }







    }
}

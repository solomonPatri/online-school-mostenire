using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Users.service;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewLogin
    {
        private ServiceUser _serviceuser;

        public ViewLogin()
        {
            _serviceuser = new ServiceUser();
            this.play();
        }
public void meniu()
        {
            Console.WriteLine("1->Log in");
            Console.WriteLine("2->Sign in");



        }

public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                switch(nrales)
                {
                    case 1:
                        AfisareLogIn();
                        break;
                    case 2:
                        AfisareSignIn();
                        break;


                }



            }








        }

        public void AfisareLogIn()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            User user = _serviceuser.GetUserByDate(email, password);

            if((user as Student) != null){

                ViewStudent viewstudent = new ViewStudent((user as Student));
                viewstudent.play();
            }
            else
            {
                if((user as Profesor) != null)
                {
                    ViewProfesor viewProfesor = new ViewProfesor((user as Profesor));
                    viewProfesor.play();
                }
                else
                {
                    Console.WriteLine("datele au fost introduse gresit!");
                }
            }




        }
        public void InscriereStudent()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Firstname: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("SecondName: ");
            string name2 = Console.ReadLine();
            Console.WriteLine("Faculty: ");
            string facult = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Media:");
            int media = int.Parse(Console.ReadLine());
            Student student = new Student(email, password, _serviceuser.GenerateRandomId(), name1, name2, facult, age,media);
            bool verificarea = false;
            if (verificarea)
            {
                Console.WriteLine("Deja exista acest student,incercati din nou!");
            }
            else
            {
                _serviceuser.adaugareUserStudent(student);
            }






        }
        public void InscriereProfesor()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Nr de Studenti: ");
            int nrstud = int.Parse(Console.ReadLine());
            Console.WriteLine("Facultate: ");
            string facultate = Console.ReadLine();
            Profesor prof = new Profesor(email,password, _serviceuser.GenerateRandomId(),name,nrstud,facultate);
            bool verificarea = false;
            if(verificarea)
            {
                Console.WriteLine("DEja eista acest profesor,incercati din nou");


            }
            else
            {
                _serviceuser.adaugareUserProfesor(prof);
            }





        }
        public void AfisareSignIn()
        {
            Console.WriteLine("1->Profesor.");
            Console.WriteLine("2->Student.");
            int ProfStud = int.Parse(Console.ReadLine());   
            switch(ProfStud)
            {
                case 1:
                    InscriereProfesor();
                    break;
                case 2:
                    InscriereStudent();
                    break;




            }



        }




    }
}

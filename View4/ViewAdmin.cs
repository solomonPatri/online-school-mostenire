using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Users.service;


namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewAdmin
    {
        private ServiceUser _serviceuser;
        private List<Admin> _admin;

        public ViewAdmin()
        {
            _serviceuser = new ServiceUser();
            _admin = new List<Admin>();



        }

        public void meniu()
        {
            Console.WriteLine("Lista de useri sunt:" + "\n");
            _serviceuser.afisareUser();
            Console.WriteLine("Unde doriti sa modificati:"+"\n");
            Console.WriteLine("1->Student");
            Console.WriteLine("2->Profesor");
            




        }

        public void play()
        {
            bool run = true;
            while(run){
                meniu();
                int nrales = int.Parse(Console.ReadLine());
                 switch (nrales)
                {
                    case 1:
                        ModificareStduent();
                        break;
                    case 2:
                        ModificareProfesor();
                        break;





                }


            }





        }

        public void ModificareStduent()
        {
            Console.WriteLine("Introduceti Datele Studentului care doriti sa intrati:");
            Console.WriteLine("Nume");
            string nume = Console.ReadLine();

            Student admin = _serviceuser.GetStudentIdByName(nume);

            ViewStudent student = new ViewStudent(admin);
            student.play();



        }

        public void ModificareProfesor()
        {
            Console.WriteLine("Introduceti Datele Profesorului:"+"\n");
            Console.WriteLine("Nume:");
            string name = Console.ReadLine();

            Profesor admin = _serviceuser.GetProfesorByName(name);
            
            ViewProfesor profesor  = new ViewProfesor(admin);   
           profesor.play();


        }




    }
}

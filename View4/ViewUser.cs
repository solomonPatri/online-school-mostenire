using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Books.service;
using Tema_OnlineSchool_Noilectii.Courses.service;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Users.service;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewUser
    {

        private ServiceBook _servicebook;
        private ServiceCourse _servicecourse;
        private ServiceUser _serviceuser;
        public ViewUser()
        {

            _servicebook = new ServiceBook();
            _servicecourse = new ServiceCourse();
            _serviceuser = new ServiceUser();
            play();
        }
        public void meniu()
        {
            Console.WriteLine("Alege ce fel de User esti:"+"\n");
            Console.WriteLine("1->Profesor.");
            Console.WriteLine("2->Student.");
            Console.WriteLine("3->Admin.");
        }
        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int ales = int.Parse(Console.ReadLine());
                switch (ales)
                {
                    case 1:
                        Profesor();
                        break;
                    case 2:

                        break;













                }
            }
        }

        public void Profesor()
        {
            Console.WriteLine("Introduceti username:");
            string userame = Console.ReadLine();
            Console.WriteLine("Introduceti Parola:");
            string password = Console.ReadLine();

            Console.WriteLine(_serviceuser.GetSpecifUser(userame, password));

            




        }
    }
}

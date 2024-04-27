using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool.Courses.model;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Users.model;

namespace Tema_OnlineSchool_Noilectii
{
    public class View
    {
        private ServiceBook _servicebook;
        private ServiceCourse _servicecourse;
        private ServiceUser _serviceuser;

        public View() { 
        
            _servicebook = new ServiceBook();   
            _servicecourse = new ServiceCourse();
            _serviceuser = new ServiceUser();

            play();
        }
        public void meniu()
        {

            Console.WriteLine("1->Afisati Cartiile Disponibile");
            Console.WriteLine("2->Afisati Cursurile Disponibile");
            Console.WriteLine("3-> Afisati Conturiile Disponibile");
            Console.WriteLine("4-> Adaugati ce doriti.");
        }

        public void play()
        {
            bool run = true;
            while (run)
            {
                meniu();
                int ales= int.Parse(Console.ReadLine());
                switch(ales)
                {
                    case 1:
                        AfisaredupaType();
                        break;
                    case 2:
                        Adaugare();
                        break;





                }



            }




        }
        public void AfisaredupaType()
        {
            Console.WriteLine("Cartiile Disponibile sunt: ");
            _servicebook.AfisareBooks();
            Console.WriteLine("Introduceti Cartea care doriti sa aflati mai multe detalii."+"\n");

            string book = Console.ReadLine();

            Book Book = _servicebook.GetBookByName(book);

            _servicebook.AfisareByName(Book);
           



        }

        public void Adaugare()
        {
            Console.WriteLine("Introduceti ce doriti sa adaugati" + "\n");
            string ales = Console.ReadLine();
            switch (ales)
            {
                case "Carte":
                     


                    break;




            }






        }


    }
}

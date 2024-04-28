using System;
using System.Collections.Generic;
using System.Globalization;
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
                        AdaugareBook();
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
            
            Console.WriteLine(_servicebook.GetBookByName(book));

        }

        public void AdaugareBook()
        {
            Console.WriteLine("Introduceti ce carte doriti sa adaugati:" + "\n");
            Console.WriteLine("Matematica,Medicina sau Stiinte Economice");
             string alegere = Console.ReadLine();

            switch (alegere)
            {
                case "Matematica":

                    Console.WriteLine("Introduceti titlul: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Introduceti nr de Pagini:");
                    int nrPag =int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti Continutul: ");
                    string continut = Console.ReadLine();

                    Matematica mate = new Matematica(title, nrPag, continut,"Matematica",_servicebook.GenerateIdUnique());
                    bool verif = _servicebook.VerificareBook(title);

                    if (verif)
                    {
                        Console.WriteLine("Deja exista o carte cu acest titlu");
                    }
                    else
                    {
                        _servicebook.adaugareBook(mate);
                        _servicebook.AfisareByType(mate);
                    }



                    break;
                case "Medicina":

                    Console.WriteLine("Inroduceti Specialitatea:");
                    string specialitate = Console.ReadLine();
                    Console.WriteLine("Introduceti An de studiu: ");
                    int anstd= int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti Titlul:");
                    string titlu= Console.ReadLine();
                    Medicina medicina = new Medicina(specialitate, anstd,titlu,"Medicina",_servicebook.GenerateIdUnique());

                    bool veri = _servicebook.VerificareBook(titlu);

                    if (veri)
                    {
                        Console.WriteLine("Deja exista o carte cu acest titlu");
                    }
                    else
                    {
                        _servicebook.adaugareBook(medicina);
                        _servicebook.AfisareByType(medicina);
                    }
                    

                    break;
                case "Stiinte Economice":

                    Console.WriteLine("Introduceti Facultatea: ");
                    string fac = Console.ReadLine();
                    Console.WriteLine("Introduceti titlul");
                    string titlul = Console.ReadLine();
                    Console.WriteLine("Introduceti Continutul");
                    string Continut = Console.ReadLine();
                    Console.WriteLine("Data Eliberari: ");
                    string DataElib = Console.ReadLine();

                    StiinteEconomice stiinte = new StiinteEconomice("Stiinte Economice",_servicebook.GenerateIdUnique(),fac,titlul,Continut,DataElib);

                    bool ver = _servicebook.VerificareBook(titlul);

                    if (ver)
                    {
                        Console.WriteLine("Deja exista o carte cu acest titlu");
                    }
                    else
                    {
                        _servicebook.adaugareBook(stiinte);
                        _servicebook.AfisareByType(stiinte);
                    }




                    break;





            }





        }


    }
}

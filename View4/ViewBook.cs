using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Books.service;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Users.service;
using Tema_OnlineSchool_Noilectii.Users.model;

namespace Tema_OnlineSchool_Noilectii.View4
{
    internal class ViewBook
    {
        private ServiceBook _servicebook;
        private Student _student;

        public ViewBook(Student student)
        {

            _servicebook = new ServiceBook();
            _student = student;
            play();

        }
        public void meniu()
        {
            Console.WriteLine("1-> Afisare Cartii.");
            Console.WriteLine("2->Adaugare Carte.");
            Console.WriteLine("3->Stergere Carte.");
            Console.WriteLine("4->Modificare Carte");
            Console.WriteLine("Cartiile disponibil pentru dumneavoastra (dupa Id).");



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
                        Afisarecarti(); // functionabil

                        break;

                    case 2:
                        AdaugareCarte(); // Functionabil
                        break;

                    case 3:
                        StergereCarte(); // Functionabil
                        break;
                    case 4:
                        Modificare();
                        break;
                    case 5:
                        ReturnById();
                        break;

                }



            }








        }

        public void Afisarecarti()
        {
            Console.WriteLine("Toate cartile disponibile sunt:" + "\n");
            _servicebook.AfisareAll();

        }

        public void AdaugareCarte()
        {
            Console.WriteLine("Introduceti tipul la cartea cea noua:" + "\n");
            Console.WriteLine("Matematica/Medicina/Stiinte economice" + "\n");
            string type = Console.ReadLine();

            if (type.Equals("Matematica"))
            {
                Console.WriteLine("Introduceti titlul:" + "\n");
                string title = Console.ReadLine();
                Console.WriteLine("Introduceti nr de pagini:" + "\n");
                int nrpag = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti Continutul" + "\n");
                string continut = Console.ReadLine();

                Matematica newbook = new Matematica(title, nrpag, continut, type, _servicebook.GenerateIdUnique(), _student.Id);
                bool verificare = _servicebook.VerificareBook(title);
                if (verificare = true)
                {
                    _servicebook.adaugareBook(newbook);
                    _servicebook.AfisareAll();

                }
                else
                {
                    Console.WriteLine("Deja exista o caret cu acest titlu.");
                }


            }
            else
            {
                if (type.Equals("Medicina"))
                {
                    Console.WriteLine("Introduceti titlul:" + "\n");
                    string title = Console.ReadLine();
                    Console.WriteLine("Introduceti Specialitate:" + "\n");
                    string specialitate = Console.ReadLine();
                    Console.WriteLine("Introduceti anul de studiu:" + "\n");
                    int anstudiu = int.Parse(Console.ReadLine());


                    Medicina book = new Medicina(specialitate, anstudiu, title, type, _servicebook.GenerateIdUnique(), _student.Id);

                    bool verificare = _servicebook.VerificareBook(title);
                    if (verificare = true)
                    {
                        _servicebook.adaugareBook(book);
                        _servicebook.AfisareAll();

                    }
                    else
                    {
                        Console.WriteLine("Deja exista o caret cu acest titlu.");
                    }

                }
                else
                {
                    if (type.Equals("Stiinte Economice"))
                    {
                        Console.WriteLine("Introduceti titlul:" + "\n");
                        string title = Console.ReadLine();
                        Console.WriteLine("Introduceti Data eliberari:" + "\n");
                        string dataelib = Console.ReadLine();
                        Console.WriteLine("Introduceti facultate" + "\n");
                        string facultate = Console.ReadLine();
                        Console.Write("Introduceti continut:" + "\n");
                        string continut = Console.ReadLine();

                        StiinteEconomice newbooks = new StiinteEconomice(type, _servicebook.GenerateIdUnique(), _student.Id, facultate, title, continut, dataelib);


                        bool verificare = _servicebook.VerificareBook(title);
                        if (verificare = true)
                        {
                            _servicebook.adaugareBook(newbooks);
                            _servicebook.AfisareAll();

                        }
                        else
                        {
                            Console.WriteLine("Deja exista o caret cu acest titlu.");
                        }
                    }






                }





            }
        }

        public void StergereCarte()
        {
            Console.WriteLine("Cartile disponibile sunt:" + "\n");
            _servicebook.BookLista(_student.Id);

            Console.WriteLine("Introduceti titlul care doriti sa stergeti:" + "\n");
            string title = Console.ReadLine();

            bool delete = _servicebook.deleteBook(title, _student.Id);
            if (delete)
            {
                Console.WriteLine("Cartea a fost sterasa cu succes, acuma cartiile dumneavoastra sunt:" + "\n");
                _servicebook.BookLista(_student.Id);
            }
            else
            {
                Console.WriteLine("Incercati din nou!");
            }


        }

        public void Modificare()
        {
            Console.WriteLine("Cartile dumneavoastra sunt:" + "\n");
            _servicebook.BookLista(_student.Id);

            Console.WriteLine("Introduceti titlul carti care doriti sa modificati:");
            string title = Console.ReadLine();









        }


        public void ReturnById()
        {
            Console.WriteLine("Cartiile dumneavoastra sunt:" + "\n");
            _servicebook.BookLista(_student.Id);

        }
























    }
}

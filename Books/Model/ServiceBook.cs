using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Books.Model
{
    public class ServiceBook
    {
        private List<Book> _books;
        private string _filePath;




        public ServiceBook()
        {

            _books = new List<Book>();
            _filePath = GetDirectory();
            load();


        }
        public void load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    string line = " ";

                    while ((line = sr.ReadLine()) != null)
                    {
                        

                        switch (line.Split(',')[0])
                        {

                            case "Matematica":

                                Matematica book1 = new Matematica(line);
                                _books.Add(book1);
                                break;


                            case "Medicina":
                                Medicina book2 = new Medicina(line);
                                _books.Add(book2);
                                break;

                            case "Stiinte Economice":
                                StiinteEconomice book3 = new StiinteEconomice(line);
                                _books.Add(book3);
                                break;

                            default:
                                break;

                        }


                    }



                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }






        }
        private string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory, "data");
            string filePath = Path.Combine(dataFolder, "Books.txt");
            return filePath;

        }
        public void AfisareBooks()
        {
            for(int i =0;i<_books.Count;i++)
            {
                if (_books[i] is Medicina) 
                {
                   
                        Console.WriteLine((_books[i] as Medicina).Titlul);
                }
                if (_books[i] is Matematica) {
                    
                    Console.WriteLine((_books[i] as Matematica).Titlul);
                
                }
                if (_books[i] is StiinteEconomice) {

                    
                    Console.WriteLine((_books[i] as StiinteEconomice).Titlul);
                }

            }


        }
        
        public Book GetBookByName(string name)
        {
            for(int i=0;i< _books.Count;i++)
            {
                  if((_books[i] as Book).Type.Equals(name))
                    {
                    return _books[i];


                    }

            }
            return null;


        }
        public void AfisareByName(Book book)
        { 
            for(int i=0;i< _books.Count; i++)
            {
                if (_books[i] is Book && _books[i].Equals(book))
                {
                    Console.WriteLine(_books[i].Descriere());
                    
                }


            }
          

        }
        public Book GetBookById(int id)
        {
            List<Book> books = _books;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    return books[i];


                }

            }
            return null;

        }
        public void adaugareBook(Book newcarte)
        {
            newcarte.Id = this.GenerateIdUnique();
            this._books.Add(newcarte);

        }
        public int GenerateIdUnique()
        {
            Random random = new Random();
            int nrrandom = random.Next(100, 10000);

            while (GetBookById(nrrandom) != null)
            {
                nrrandom = random.Next(100, 10000);
            }

            return nrrandom;


        }
        public void AdaugareVerificare(string type,string titlul,Book newbook)
        {
            for(int i =0;i < _books.Count;i++)
            {
                if (_books[i].Type.Equals(type))
                {
                    Book book = _books[i];
                    if ((book as Matematica).Titlul.Equals(titlul)){

                        Console.WriteLine("Deja exista o carte de Matematica cu acest titlu");
                    }
                    else
                    {

                        adaugareBook(newbook);
                    }

                    if((book as Medicina).Titlul.Equals(titlul))
                    {
                        Console.WriteLine("Deja exista o carte de Medicina ci acest titlul");
                    }
                    else
                    {
                        adaugareBook(newbook);

                    }
                    if((book as StiinteEconomice).Titlul.Equals(titlul))
                    {
                        Console.WriteLine("Deja exista o carte de Stiinte Economice cu acest titlul");


                    }




                }







            }




        }





    }








}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Courses.model;

namespace Tema_OnlineSchool_Noilectii.Books.service
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
        public void AfisareAll()
        {

            foreach (Book book in _books)
            {
                Console.WriteLine(book.Descriere());

            }

        }


        public Book GetBookByTitle(string title)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title.Equals(title))
                {
                    return _books[i];
                }

            }
            return null;

        }
        public List<Book> GetBooksByType(string type)
        {
            List<Book> list = new List<Book>();
            for (int i = 0; i < _books.Count; i++)
            {
                if ((_books[i] as Book).Type.Equals(type))
                {

                    list.Add(_books[i]);

                }

            }
            return list;


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
            newcarte.Id = GenerateIdUnique();
            _books.Add(newcarte);

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

        public bool VerificareBook(string title)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Title.Equals(title))
                {

                    return true;
                }
            }
            return false;
        }

        public List<Book> FiltrareByStudentId(int studentid)
        {
            List<Book> book = new List<Book>();
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].StudentId.Equals(studentid))
                {
                    book.Add(_books[i]);

                }



            }
            return book;



        }

        public void BookLista(int studentid)
        {
            List<Book> books = FiltrareByStudentId(studentid);

            for (int i = 0; i < books.Count; i++)
            {

                Console.WriteLine(books[i].Descriere());

            }


        }
        public void SortareDupaNume()
        {
            for (int i = 0; i < _books.Count - 1; i++)
            {
                for (int j = i + 1; j < _books.Count; j++)
                {

                    if (_books[i].Title == _books[j].Title)
                    {
                        Book aux = _books[i];
                        _books[i] = _books[j];
                        _books[j] = aux;
                    }
                }
            }

        }

        public bool deleteBook(string title, int studentid)
        {
            List<Book> books = FiltrareByStudentId(studentid);
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Equals(title))
                {
                    _books.Remove(books[i]);
                    return true;
                }


            }
            return false;




        }

       















    }























}
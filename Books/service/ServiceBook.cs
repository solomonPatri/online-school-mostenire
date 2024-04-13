using Tema_OnlineSchool_Noilectii.Books.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this._filePath = GetDirectory();
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
                        Console.WriteLine(line.Split(',')[0]);

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





        private String GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory, "data");
            string filePath = Path.Combine(dataFolder, "Books.txt");
            return filePath;

        }
        public void afisareAll()
        { 
            for(int i=0;i< _books.Count;i++)
            {
                if (_books[i].Type == _books[0].Type)
                {
                    Console.WriteLine(_books[i].Descriere());


                } 


            }



        }

    }








}
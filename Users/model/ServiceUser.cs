using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_OnlineSchool_Noilectii.Users.model
{
    internal class ServiceUser
    {
        private List<User> _users;
        private string _filePath;

        public ServiceUser()
        {

            _users = new List<User>();
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

                            case "Profesor":

                                Profesor profesori = new Profesor(line);
                                _users.Add(profesori);
                                break;


                            case "Student":
                                Student studenti = new Student(line);
                                _users.Add(studenti);
                                break;

                            case "Admin":
                                Admin admin = new Admin(line);
                                _users.Add(admin);
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

        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolder = Path.Combine(currentDirectory, "data");
            string filePath = Path.Combine(dataFolder, "Users.txt");
            return filePath;
        }

        public void afisare()
        {
            foreach (User users in _users)
            {
                Console.WriteLine(users.Descriere());
            }


        }

        public void afisareUsername()
        {
            Console.WriteLine("Username Disponibil:" + "\n");

            foreach (User users in _users)
            {
                Console.WriteLine(users.Username);
            }
        }
        public void MediaStudentilor()
        {
            //Console.WriteLine("Media studentilor:" + "\n");
            //int suma = 0;
            //int media = 0;
            //foreach (User studenti in this._users)
            //{

            //    if (studenti is Student)
            //    {
            //        Console.WriteLine((studenti as Student).Media);
            //        suma += (studenti as Student).Media;
            //        media = suma / studenti;

            //    }


            //}

            //Console.WriteLine("Media total este: " +media);



        }


    }
}

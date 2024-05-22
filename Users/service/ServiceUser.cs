using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema_OnlineSchool_Noilectii.Users.model;

namespace Tema_OnlineSchool_Noilectii.Users.service
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
        public User GetUseById(int id)
        {
            List<User> user = _users;
            for(int i=0;i<user.Count; i++)
            {
                if ((user[i] as Profesor).Equals(id) || (user[i] as Student).Equals(id))
                {

                    return user[i];

                }


            }
            return null;

        }
        public void AfisareStudenti()
        {
            for (int i = 0; i < _users.Count; i++)
            {
                Console.WriteLine((_users[i].Id));
            }


        }


       

        public int GenerateRandomId()
        {
            Random random = new Random();
            int nrrandom = random.Next(10, 100);
            while(GetUserById(nrrandom)!=null)
            {

                nrrandom = random.Next(10, 100);

            }


            return nrrandom;


        }
       public void adaugareUser(User user)
        {
            user.Id = GenerateRandomId();
            this._users.Add(user);

        }

        public void afisareUser()
        {
            foreach (User users in _users)
            {
                Console.WriteLine(users.Descriere());
            }


        }
        public User GetUserByDate(string username, string password)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Username.Equals(username) && _users[i].Password.Equals(password))
                {
                    return _users[i];

                }

            }
            return null;
        }



        public void afisareUsername()
        {
            Console.WriteLine("Username Disponibil:" + "\n");

            foreach (User users in _users)
            {
                Console.WriteLine(users.Username);
            }
        }

        public User GetUserById(int id)
        {
            List<User> users = _users;
            for (int i = 0; i < users.Count; i++)
            {
                if (_users[i].Id == id)
                {
                    return users[i];
                }

            }

            return null;

        }

        public User GetSpecifUser(string username, string password)
        {

            User user = GetUserByDate(username, password);

            for (int i = 0; i < _users.Count; i++)
            {
                if ((user as Profesor).Username.Equals(_users[i].Username) && (user as Profesor).Password.Equals(_users[i].Password))
                {
                    Profesor prof = _users[i] as Profesor;
                    return prof;

                }
                else
                {
                    if ((user as Student).Username.Equals(_users[i].Username) && (user as Student).Password.Equals(_users[i].Password))
                    {
                        Student student = _users[i] as Student;
                        return student;

                    }
                }

            }

            return null;


        }

        public List<User> AfisareUserByIdiuri(List<int> ids)
        {
            List<User> users = new List<User>();

            for (int i = 0; i < _users.Count; i++)
            {
                if (ids.Contains(_users[i].Id))
                {
                    users.Add(_users[i]);
                    
                    
                }
              
            }

            return users;



        } 


        public double Media(List<int> idstud)
        {
           double  suma = 0;
           double media = 0;

            for(int i=0;i< _users.Count; i++)
            {
                if (idstud.Contains((_users[i].Id)))
                {

                    suma += (_users[i] as Student).Media;
                    media = suma / idstud.Count;

                }
            }
            return media;



        }
        public Student GetStudentIdByName(string name)
        {
            
            for (int i = 0; i < _users.Count; i++)
            {
                if ((_users [i] as Student).FirstnameStudent.Equals(name))
                {
                   
                    return (_users[i] as Student);

                }

            }
            return null;

        }
        public Profesor GetProfesorByName(string name)
        {
            for(int i=0; i< _users.Count;i++)
            {
                if ((_users[i] as Profesor).Nume.Equals(name))
                {

                    return (_users[i] as Profesor);


                }

            }
            return null;


        }









    }
}

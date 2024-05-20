using Microsoft.VisualBasic;
using online_school.Enrolments.Service;
using System;
using System.Net.Http.Headers;
using Tema_OnlineSchool_Noilectii;
using Tema_OnlineSchool_Noilectii.Books.Model;
using Tema_OnlineSchool_Noilectii.Books.service;
using Tema_OnlineSchool_Noilectii.Courses.model;
using Tema_OnlineSchool_Noilectii.Courses.service;
using Tema_OnlineSchool_Noilectii.Users.model;
using Tema_OnlineSchool_Noilectii.Users.service;
using Tema_OnlineSchool_Noilectii.View4;

internal class Program
{
    private static void Main(string[] args)
    {

        Profesor profesor = new Profesor("ralnuv@gmail.com", "raluca3456", 23, "Raluca", 3554, "Mate - Info");

        ServiceCourse curs = new ServiceCourse();
        Console.WriteLine(curs.GetCourseByProfId(profesor.IdProfesor));

        ViewProfesor prof = new ViewProfesor(profesor);
       prof.play();


        //ViewLogin viewlogin = new ViewLogin();
        //viewlogin.play();




    }




}
using System;
using MySql.Data.MySqlClient;

namespace StudentRecord
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=studentmanagment;port=3306;password=mateen2004adebisi";
        static MySqlConnection conn = new MySqlConnection(connectionString);
        StudentRepository studentRepo = new StudentRepository(conn);
        private void StudentMenu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Student Information");
            Console.WriteLine("2. Find Student InformationBy E-Mail");
            Console.WriteLine("3. List all Emails");
            Console.WriteLine("4. Update Student Information");
            Console.WriteLine("5. Delete Student Information");
            Console.WriteLine("6. Check Number of Student greater than 18");
            Console.WriteLine("7. Print Information of Students in Jss1");
        }
        private void AddStudentInfo()
        {
            Console.Write("Enter Student First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Student last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Student E-Mail: ");
            string eMail = Console.ReadLine();

            Console.Write("Enter Student Phone-No: ");
            string phoneNo = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Class: ");
            string studentClass = Console.ReadLine().ToLower();

            studentRepo.AddStudentInfo(firstName, lastName, eMail, phoneNo, age, studentClass);
        }
        private void UpdateStudent()
        {
            Console.Write("Enter E-Mail of student you want to update: ");
            string eMail = Console.ReadLine();

            Console.Write("Update Student First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Update Student Age: ");
            int age = int.Parse(Console.ReadLine());

            studentRepo.UpdateStudentInfo(firstName, eMail,  age);
        }
        private void DeleteStudent()
        {
            Console.Write("Enter Last Name of Student you want to Delete: ");
            string lastName = Console.ReadLine();
            studentRepo.DeleteStudent(lastName);
        }
        public void MainMenu()
        {
            StudentMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentInfo();
                    MainMenu();
                    break;
                case "2":
                    Console.Write("Enter Email to Find: ");
                    string eMail = Console.ReadLine();
                    Console.WriteLine("");
                    studentRepo.FindStudent(eMail);
                    MainMenu();
                    break;
                case "3":
                    studentRepo.ListAllemails();
                    MainMenu();
                    break;
                case "4":
                    UpdateStudent();
                    MainMenu();
                    break;
                case "5":
                    DeleteStudent();
                    MainMenu();
                    break;
                case "6":
                    studentRepo.Above18Years();
                    MainMenu();
                    break;
                case "7":
                    studentRepo.ListOfJss1Students();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}
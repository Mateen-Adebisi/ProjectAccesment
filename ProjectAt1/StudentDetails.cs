using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAt1
{
    public class StudentDetails
    {
        public List<Student> students = new List<Student>();

        public StudentDetails()
        {
            FetchStudentInfoFromFile();
        }

        public void FetchStudentInfoFromFile()
        {
            try
            {
                var studentInfoLines = File.ReadAllLines("Files//student.txt");
                foreach (var studentInfoLine in studentInfoLines)
                {
                    var student = Student.StringToStudentEntity(studentInfoLine);
                    students.Add(student);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintStudentInfo(Student student)
        {
            Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}, Email: {student.Email}, Phone Number: {student.PhoneNumber}, Age: {student.Age}, Class: {student.Class} ");
        }

        public void GetStudentInfo()
        {
            foreach (Student student in students)
            {
                PrintStudentInfo(student);
            }
        }

        // public List<Student> ListStudentInfo()
        // {
        //     return students;
        // }

        public void AddStudentInfo(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        {
            var stockExist = FindStudentByEmail(email);

            if (stockExist != null)
            {
                Console.WriteLine($"stock with {email} already exist");
            }

            Student student = new Student(firstName, lastName, email, phoneNumber, age, studentClass);

            students.Add(student);

            TextWriter writer = new StreamWriter("Files//student.txt", true);
            writer.WriteLine(student.ToString());
            Console.WriteLine("Student Info added successfully!");
            writer.Close();
        }

        // public void UpdateStock(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        // {
        //     var student = FindStudentByEmail(email);
        //     if (student == null)
        //     {
        //         Console.WriteLine($"Student with {email} does not exist");
        //     }

        //     student.FirstName = firstName;
        //     RefreshFile();
        // }

        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Files//student.txt");
            foreach (var student in students)
            {
                writer.WriteLine(student);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteStudentLastName(string lastName)
        {
            // var student = FindStudentByLastName(lastName);
            // if (student == null)
            // {
            //     Console.WriteLine($"Student with {lastName} does not exist");
            // }

            students.RemoveAll(student => student.LastName == lastName);
            RefreshFile();
        }

        public Student FindStudentByEmail(string email)
        {
            return students.Find(s => s.Email == email);
        }

        // public List<Student> FindStudentByLastName(string lastName)
        // {
        //     return students.FindAll(s => s.LastName == lastName);
        // }

        public void FindStudent()
        {
            Console.WriteLine("Enter the email of the Student you want to find: ");
            string email = Console.ReadLine();

            var student = FindStudentByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Student with Email: \t {email} does not exist! ");
            }

            else
            {
                Console.WriteLine($"First Name: {student.FirstName} Last Name: {student.LastName} Email: {student.Email} Phone Number: {student.PhoneNumber} Age: {student.Age} Class: {student.Class} ");
            }
        }
        public void ListAllEmails()
        {
            //var studentInfoLines = File.ReadAllLines("Files//student.txt");
            foreach (var student in students)
            {
                Console.WriteLine($"Email: {student.Email} ");
            }
            if (students == null)
            {
                Console.Write("Empty");
            }
          
        }

        public void ListAllAges()
        {
            List<Student> Students = new List<Student>();
            {
                int count = 0;
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine($"Age: {Students[2]}");
                    count++;
                }

                Console.WriteLine($"Number of Students with ages greater than 18 is {count}. ");
            }
        }

        public void ListAllStudentInJss1()
        {
            List<Student> Students = new List<Student>();

            foreach (var student in Students)
            {
                if(student.Class == "jss1")
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Email + " " + student.PhoneNumber + " " + student.Age + " " + student.Class);
                }
                else 
                {
                    Console.WriteLine("Not Exist");
                }
               
            }

        }
        public void UpdateStudent(string firstName, string email, int age)
        {
            var student = FindStudentByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }
            else
            {
                foreach (var studenti in students)
                {
                    studenti.FirstName = firstName;
                    studenti.Age = age;
                }
            }
        }
    }
}
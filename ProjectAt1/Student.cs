using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAt1
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; } 

        public string Class { get; set; }

        public Student(string firstName, string lastName, string email, string phoneNumber, int age, string studentclass)
        {
            this.FirstName = firstName;

            this.LastName = lastName;

            this.Email = email;

            this.PhoneNumber = phoneNumber;

            this.Age = age;

            this.Class = studentclass;
        }

        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Email}\t{PhoneNumber}\t{Age}\t{Class} ";
        }

        internal static Student StringToStudentEntity(string studentString)
        {
            var props = studentString.Split("\t");

            int age = int.Parse(props[4]);

            return new Student(props[0], props[1], props[2], props[3], age, props[5]);
        }
    }

}
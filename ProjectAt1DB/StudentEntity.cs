using System;

namespace StudentRecord
{
    public class StudentEntity
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int Age { get; set; }
        public string StudentClass { get; set; }
        public StudentEntity(string firstName, string lastName, string email, string phoneNo, int age, string studentClass)
        {
            this.FirstName = firstName;
            this.LastName =  lastName;
            this.Email = email;
            this.PhoneNo = phoneNo;
            this.Age = age;
            this.StudentClass =studentClass;
        }
    }
}
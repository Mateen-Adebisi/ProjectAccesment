using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAt3
{
    public class ContactRepositry
    {
        public List<Contact> Contacts = new List<Contact>();

        public ContactRepositry()
        {
            FetchContactInfoFromFile();
        }

        public void FetchContactInfoFromFile()
        {
            try
            {
                var contactInfoLines = File.ReadAllLines("Files//MyContact.txt");
                foreach (var contactInfoLiness in contactInfoLines)
                {
                    var student = Contact.StringToContactRep(contactInfoLiness);
                    Contacts.Add(student);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintContactInfo(Contact contact)
        {
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}, OfficeAddress: {contact.OfficeAddress} ");
        }

        public void GetContactInfo()
        {
            foreach (Contact student in Contacts)
            {
                PrintContactInfo(student);
            }
        }
        public void AddContactDetails(int id, string name, string email, string phoneNumber, string officeaddress)
        {
            var contactExist = FindContactByEmail(email);

            if (contactExist != null)
            {
                Console.WriteLine($"stock with {email} already exist");
            }

            Contact contact = new Contact(id, name, email, phoneNumber, officeaddress);

            Contacts.Add(contact);

            TextWriter writer = new StreamWriter("Files//MyContact.txt", true);
            writer.WriteLine(contact.ToString());
            Console.WriteLine("Student Info added successfully!");
            writer.Close();
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("Files//MyContact.txt");
            foreach (var student in Contacts)
            {
                writer.WriteLine(student);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteContact(string lastName)
        {
          
            Contacts.RemoveAll(student => student.Name == lastName);
            RefreshFile();
        }

        public Contact FindContactByEmail(string email)
        {
            return Contacts.Find(s => s.Email == email);
        }

       
      
        public void ListAllEmails()
        {

            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Email: {contact.Email} ");
            }
            if (Contacts == null)
            {
                Console.Write("Empty");
            }

        }

        public void UpdateContact(string name, string email, string officeaddress)
        {
            var student = FindContactByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Contact with {email} does not exist");
            }
            else
            {
                foreach (var studenti in Contacts)
                {
                    studenti.Name = name;
                    studenti.OfficeAddress = officeaddress;
                }
            }
        }
        
        
          public void FindStudent()
        {
            Console.WriteLine("Enter the email of the Contact you want to find: ");
            string email = Console.ReadLine();

            var contact = FindContactByEmail(email);

            if (contact == null)
            {
                Console.WriteLine($"Contact with Email: \t {email} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}, OfficeAddress: {contact.OfficeAddress}  ");
            }
        }
        
        public void ListAllAges()
        {
            List<Contact> contacts = new List<Contact>();
            {
                int count = 0;
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"Age:  {contacts[2]}");
                    count++;
                }

                Console.WriteLine($"Number of contacts with ages greater than 18 is {count}. ");
            }
        }

    }
}

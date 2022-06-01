using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            var sortedBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);
            IEnumerable<Contact> page = null;
            while (true)
            {
                Console.WriteLine("Введите номер страницы Вашего списка контактов, которую Вы хотите увидеть");
                var input = Console.ReadKey().KeyChar;
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    Console.Clear();
                    switch (input)
                    {
                        case '1':
                            page = sortedBook.Take(2);
                            break;
                        case '2':
                            page = sortedBook.Skip(2).Take(2);
                            break;
                        case '3':
                            page = sortedBook.Skip(4).Take(2);
                            break;
                    }
                    Console.WriteLine("Страница " + input);
                    foreach (var item in page)
                    {
                        Console.WriteLine($"{item.Name} {item.LastName} - {item.PhoneNumber}");
                    }
                }
            }
        }
        public class Contact
        {
            public Contact(string name, string lastName, long phoneNumber, String email)
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }
            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}



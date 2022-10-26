﻿namespace text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\diskC\\учеба\\lessons\\simple code\\hwtext\\phonebook.csv";
            var phonebook = ReadFile(ref path);
            Console.WriteLine("Adding new:");
            AddPerson(path);
            Console.WriteLine("Searching person");
            var person = SearchPerson(Console.ReadLine(), phonebook);
            Console.WriteLine(person);
        }

        static List<(string FirstName, string LastName, string PhoneNumber)> ReadFile(ref string path)
        {
            string.Equals("123", "244", StringComparison.InvariantCultureIgnoreCase);
            if (!File.Exists(path)) return null;
            var book = new List<(string FirstName, string LastName, string PhoneNumber)>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var split = line.Split(',');
                book.Add((split[0], split[1], split[2]));
            }

            return book;
        }


       static (string, string, string) SearchPerson(
            string input,
            List<(string, string, string)> collection)
        {
            return collection.FirstOrDefault(person =>
            person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase) ||
            person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
            person.Item3.Contains(input, StringComparison.OrdinalIgnoreCase));
        }

        static void AddPerson(string path)
        {
            InputValue(out var FirstName, "FirstName");
            InputValue(out var SecondName, "SecondName");
            InputValue(out var PhoneNumber, "PhoneNumber");
            File.AppendAllLines(
                path,
                new[] { $"{FirstName},{SecondName},{PhoneNumber}" });
        }
        static void InputValue(out string result, string Name)
        {
            Console.WriteLine($"Enter {Name}:");
            result = Console.ReadLine();
            Console.WriteLine($"{Name} submitted: {result}");
        }

    }
}

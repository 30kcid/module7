using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDictionaryApp
{
    class Program
    {
        static Dictionary<string, List<string>> myDictionary = new();

        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Dictionary Menu ---");
                Console.WriteLine("1. Populate Dictionary");
                Console.WriteLine("2. Display Dictionary");
                Console.WriteLine("3. Remove a Key");
                Console.WriteLine("4. Add New Key and Value");
                Console.WriteLine("5. Add Value to Existing Key");
                Console.WriteLine("6. Sort Keys");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PopulateDictionary();
                        break;
                    case "2":
                        DisplayDictionary();
                        break;
                    case "3":
                        RemoveKey();
                        break;
                    case "4":
                        AddNewKeyAndValue();
                        break;
                    case "5":
                        AddValueToExistingKey();
                        break;
                    case "6":
                        SortKeys();
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void PopulateDictionary()
        {
            Console.WriteLine("\nAdd items (leave key empty to stop):");
            while (true)
            {
                Console.Write("Enter key: ");
                string key = Console.ReadLine();
                if (string.IsNullOrEmpty(key)) break;

                Console.Write("Enter value: ");
                string value = Console.ReadLine();

                if (!myDictionary.ContainsKey(key))
                    myDictionary[key] = new List<string>();

                myDictionary[key].Add(value);
            }

            // Erik Hernandez: added a confirmation so user knows data was added successfully.
            Console.WriteLine("Items added successfully!");
        }

        static void DisplayDictionary()
        {
            if (myDictionary.Count == 0)
            {
                Console.WriteLine("\nDictionary is empty.");
                return;
            }

            Console.WriteLine("\n--- Dictionary Contents ---");
            foreach (var kvp in myDictionary)
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
        }

        static void RemoveKey()
        {
            Console.Write("\nEnter key to remove: ");
            string key = Console.ReadLine();

            if (myDictionary.Remove(key))
                Console.WriteLine("Key removed.");
            else
                Console.WriteLine("Key not found.");
        }

        static void AddNewKeyAndValue()
        {
            Console.Write("\nEnter new key: ");
            string key = Console.ReadLine();
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            if (!myDictionary.ContainsKey(key))
                myDictionary[key] = new List<string> { value };
            else
                Console.WriteLine("Key already exists.");
        }

        static void AddValueToExistingKey()
        {
            Console.Write("\nEnter key: ");
            string key = Console.ReadLine();
            if (!myDictionary.ContainsKey(key))
            {
                Console.WriteLine("Key not found.");
                return;
            }

            Console.Write("Enter value to add: ");
            string value = Console.ReadLine();
            myDictionary[key].Add(value);
        }

        static void SortKeys()
        {
            myDictionary = myDictionary.OrderBy(kvp => kvp.Key)
                                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Console.WriteLine("\nKeys sorted.");

            // Erik Hernandez: added this to show confirmation of the first and last key after sorting.
            Console.WriteLine($"First key: {myDictionary.Keys.First()} | Last key: {myDictionary.Keys.Last()}");
        }
    }
}
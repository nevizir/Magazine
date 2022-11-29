﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Magazine
{
    internal class Program
    {
        [Serializable]
        struct Articles
        {
            public string name;
            public int numberCharacters;
            public string Announcement;
        }

        [Serializable]
        class Magazine
        {
            public string name;
            public string publisher;
            public string date;
            public int pages;
            public Articles articles;

            public Magazine()
            {
                name = "";
                publisher = "";
                date = "";
                pages = 0;
            }
            public void EnterInfo()
            {
                Console.WriteLine("Enter magazine name");
                name = Console.ReadLine();
                Console.WriteLine("Enter magazine publisher");
                publisher = Console.ReadLine();
                Console.WriteLine("Enter date");
                date = Console.ReadLine();
                Console.WriteLine("Enter pages");
                pages = int.Parse(Console.ReadLine());
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Magazine name :\t {name}");
                Console.WriteLine($"Magazine publisher :\t {publisher}");
                Console.WriteLine($"Date :\t {date}");
                Console.WriteLine($"Pages in magazin :\t {pages}");
            }
        }

        static void Main(string[] args)
        {
            Magazine magazine = new Magazine();

            string fileName = "Persons.json";
            File.Create(fileName);
            // Serialize
            string jsonString = JsonSerializer.Serialize(magazine);
            File.WriteAllText(fileName, jsonString);

            // Deserialize
            jsonString = File.ReadAllText(fileName);
            Magazine list = JsonSerializer.Deserialize<Magazine>(jsonString);

        }
    }
}

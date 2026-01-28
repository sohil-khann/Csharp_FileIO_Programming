/*
 * 9. Convert CSV Data into Objects
 * Problem Statement: Read a CSV file and convert each row into a Student object.
 * Store the objects in a List and print them.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace CSV_PracticeProblems.Problems
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"[ID: {ID}, Name: {Name}, Marks: {Marks}]";
        }
    }

    public class CSVToObjects
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "students.csv");
            List<Student> studentList = new List<Student>();

            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "ID,Name,Marks\n1,Alice,85\n2,Bob,75\n3,Charlie,90");
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip header
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 3)
                        {
                            Student s = new Student
                            {
                                ID = int.Parse(parts[0]),
                                Name = parts[1],
                                Marks = int.Parse(parts[2])
                            };
                            studentList.Add(s);
                        }
                    }
                }

                Console.WriteLine("Student Objects List:");
                foreach (var student in studentList)
                {
                    Console.WriteLine(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

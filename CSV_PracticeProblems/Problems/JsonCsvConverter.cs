/*
 * 14. Convert JSON to CSV and Vice Versa
 * Problem Statement: Convert JSON list of students to CSV and vice versa.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace CSV_PracticeProblems.Problems
{
    public class StudentInfo
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class JsonCsvConverter
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string jsonFile = Path.Combine(dirPath, "students.json");
            string csvFile = Path.Combine(dirPath, "students_from_json.csv");

            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            // Create sample JSON
            var students = new List<StudentInfo>
            {
                new StudentInfo { ID = 1, Name = "Sohil", Age = 20 },
                new StudentInfo { ID = 2, Name = "Raj", Age = 21 }
            };
            File.WriteAllText(jsonFile, JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true }));

            try
            {
                // 1. JSON to CSV
                string jsonContent = File.ReadAllText(jsonFile);
                var list = JsonSerializer.Deserialize<List<StudentInfo>>(jsonContent) ?? new List<StudentInfo>();
                
                using (StreamWriter sw = new StreamWriter(csvFile))
                {
                    sw.WriteLine("ID,Name,Age");
                    foreach (var s in list) sw.WriteLine($"{s.ID},{s.Name},{s.Age}");
                }
                Console.WriteLine("JSON converted to CSV.");

                // 2. CSV to JSON
                var newList = new List<StudentInfo>();
                using (StreamReader sr = new StreamReader(csvFile))
                {
                    sr.ReadLine(); // Skip header
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var p = line.Split(',');
                        newList.Add(new StudentInfo { ID = int.Parse(p[0]), Name = p[1], Age = int.Parse(p[2]) });
                    }
                }
                string newJson = JsonSerializer.Serialize(newList, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine("CSV converted back to JSON:\n" + newJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

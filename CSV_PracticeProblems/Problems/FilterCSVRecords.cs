/*
 * 4. Filter Records from CSV
 * Problem Statement: Read a CSV file and filter students who have scored more than 80 marks.
 * Print only the qualifying records.
 */
using System;
using System.IO;

namespace CSV_PracticeProblems.Problems
{
    public class FilterCSVRecords
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "students.csv");

            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "ID,Name,Marks\n1,Alice,85\n2,Bob,75\n3,Charlie,90\n4,David,60");
            }

            try
            {
                Console.WriteLine("Students with marks > 80:");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? header = reader.ReadLine();
                    Console.WriteLine(header); // Print header

                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 3)
                        {
                            if (int.TryParse(parts[2], out int marks) && marks > 80)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

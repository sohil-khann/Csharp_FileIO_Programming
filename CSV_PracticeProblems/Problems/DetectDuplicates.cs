/*
 * 12. Detect Duplicates in a CSV File
 * Problem Statement: Read a CSV file and detect duplicate entries based on the ID column.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace CSV_PracticeProblems.Problems
{
    public class DetectDuplicates
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "duplicate_check.csv");

            // Create sample file with duplicates
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "ID,Name\n1,Alice\n2,Bob\n1,Alice Duplicate\n3,Charlie\n2,Bob Duplicate");
            }

            try
            {
                HashSet<string> seenIds = new HashSet<string>();
                List<string> duplicates = new List<string>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip header
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string id = parts[0];

                        if (seenIds.Contains(id))
                        {
                            duplicates.Add(line);
                        }
                        else
                        {
                            seenIds.Add(id);
                        }
                    }
                }

                if (duplicates.Count > 0)
                {
                    Console.WriteLine("Duplicate records found:");
                    foreach (var dup in duplicates)
                    {
                        Console.WriteLine(dup);
                    }
                }
                else
                {
                    Console.WriteLine("No duplicates found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

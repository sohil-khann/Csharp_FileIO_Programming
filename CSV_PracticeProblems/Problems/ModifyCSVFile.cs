/*
 * 6. Modify a CSV File (Update a Value)
 * Problem Statement: Read a CSV file and increase the salary of employees from the "IT" department by 10%.
 * Save the updated records back to a new CSV file.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace CSV_PracticeProblems.Problems
{
    public class ModifyCSVFile
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string sourcePath = Path.Combine(dirPath, "employees.csv");
            string destPath = Path.Combine(dirPath, "employees_updated.csv");

            if (!File.Exists(sourcePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(sourcePath, "ID,Name,Dept,Salary\n101,John,IT,50000\n102,Jane,HR,45000\n103,Sam,IT,55000");
            }

            try
            {
                List<string> updatedLines = new List<string>();
                using (StreamReader reader = new StreamReader(sourcePath))
                {
                    string? header = reader.ReadLine();
                    if (header != null) updatedLines.Add(header);

                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 4 && parts[2].Trim().Equals("IT", StringComparison.OrdinalIgnoreCase))
                        {
                            if (double.TryParse(parts[3], out double salary))
                            {
                                salary *= 1.10; // Increase by 10%
                                parts[3] = salary.ToString("F2");
                            }
                        }
                        updatedLines.Add(string.Join(",", parts));
                    }
                }

                File.WriteAllLines(destPath, updatedLines);
                Console.WriteLine($"Salaries updated for IT department. Saved to {Path.GetFileName(destPath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

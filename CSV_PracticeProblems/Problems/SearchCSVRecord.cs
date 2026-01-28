/*
 * 5. Search for a Record in CSV
 * Problem Statement: Read an employees.csv file and search for an employee by name.
 * Print their department and salary.
 */
using System;
using System.IO;

namespace CSV_PracticeProblems.Problems
{
    public class SearchCSVRecord
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "employees.csv");

            // Ensure file exists for demonstration
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "ID,Name,Department,Salary\n101,John Doe,IT,50000\n102,Jane Smith,HR,45000\n103,Sam Wilson,IT,55000");
            }

            Console.Write("Enter employee name to search: ");
            string? searchName = Console.ReadLine()?.Trim();

            try
            {
                bool found = false;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip header
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 4 && parts[1].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Match Found!\nDepartment: {parts[2]}\nSalary: {parts[3]}");
                            found = true;
                            break;
                        }
                    }
                }
                if (!found) Console.WriteLine("Employee not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

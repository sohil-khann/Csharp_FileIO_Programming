/*
 * 13. Generate a CSV Report from Database
 * Problem Statement: Fetch employee records (simulated) and write them into a CSV file.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace CSV_PracticeProblems.Problems
{
    public class DatabaseToCSV
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string reportPath = Path.Combine(dirPath, "employee_report.csv");

            // Simulating database records
            var employees = new List<dynamic>
            {
                new { ID = 1, Name = "Alice", Dept = "IT", Salary = 60000 },
                new { ID = 2, Name = "Bob", Dept = "HR", Salary = 50000 },
                new { ID = 3, Name = "Charlie", Dept = "Finance", Salary = 70000 }
            };

            try
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                using (StreamWriter sw = new StreamWriter(reportPath))
                {
                    sw.WriteLine("Employee ID,Name,Department,Salary");
                    foreach (var emp in employees)
                    {
                        sw.WriteLine($"{emp.ID},{emp.Name},{emp.Dept},{emp.Salary}");
                    }
                }
                Console.WriteLine($"CSV report generated successfully at {Path.GetFileName(reportPath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

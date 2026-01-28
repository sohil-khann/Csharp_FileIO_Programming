/*
 * 7. Sort CSV Records by a Column
 * Problem Statement: Read a CSV file and sort the records by Salary in descending order.
 * Print the top 5 highest-paid employees.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CSV_PracticeProblems.Problems
{
    public class SortCSVRecords
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "employees.csv");

            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "ID,Name,Dept,Salary\n101,John,IT,50000\n102,Jane,HR,45000\n103,Sam,IT,55000");
            }

            try
            {
                List<string[]> records = new List<string[]>();
                string? header;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    header = reader.ReadLine();
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        records.Add(line.Split(','));
                    }
                }

                var sortedRecords = records
                    .OrderByDescending(r => double.TryParse(r[3], out double s) ? s : 0)
                    .Take(5);

                Console.WriteLine($"Top 5 Highest Paid Employees:");
                Console.WriteLine(header);
                foreach (var record in sortedRecords)
                {
                    Console.WriteLine(string.Join(",", record));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

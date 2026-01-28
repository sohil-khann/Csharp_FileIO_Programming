/*
⃣Write Data to a CSV File
● Create a CSV file with employee details (ID, Name, Department, Salary).
● Write at least 5 records to the file.

*/
using System;
using System.IO;
using CsvHelper;
namespace CSV_PracticeProblems.Problems;
public class WriteCSV
{
    public static void Solution()
    {
        String filePath = "./DataFiles/employees.csv";
         if (!File.Exists(filePath))//Check if file exists
            {
                File.Create(filePath).Close();
                Console.WriteLine("CSV file created at: " + filePath);
            }
        try
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = new[]
                {
                    new { ID = 1, Name = "Sohil", Department = "HR", Salary = 60000 },
                    new { ID = 2, Name = "Oggy", Department = "IT", Salary = 75000 },
                    new { ID = 3, Name = "Charan", Department = "Finance", Salary = 70000 },
                    new { ID = 4, Name = "Jack", Department = "Marketing", Salary = 65000 },
                    new { ID = 5, Name = "Olivia", Department = "Sales", Salary = 72000 }
                };

                csv.WriteRecords(records);
                
            }
            
            Console.WriteLine("Data written to CSV file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
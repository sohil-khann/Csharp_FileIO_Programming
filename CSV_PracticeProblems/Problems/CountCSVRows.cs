/*
 * 3. Read and Count Rows in a CSV File
 * Problem Statement: Read a CSV file and count the number of records (excluding the header row).
 */
using System;
using System.IO;

namespace CSV_PracticeProblems.Problems
{
    public class CountCSVRows
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "students.csv");
            
            // Ensure directory and file exist for demonstration
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "ID,Name,Marks\n1,Alice,85\n2,Bob,75\n3,Charlie,90\n4,David,60");
            }

            try
            {
                int count = 0;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Skip header row
                    reader.ReadLine();
                    
                    while (reader.ReadLine() != null)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Total records (excluding header): {count}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
        }
    }
}

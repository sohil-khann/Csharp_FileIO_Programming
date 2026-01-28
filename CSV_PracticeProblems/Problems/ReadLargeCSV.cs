/*
 * 11. Read Large CSV File Efficiently
 * Problem Statement: Implement a memory-efficient way to read a large CSV file in chunks.
 * Process 100 lines at a time and display the count.
 */
using System;
using System.IO;

namespace CSV_PracticeProblems.Problems
{
    public class ReadLargeCSV
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "large_data.csv");

            // Create a slightly "large" file for demonstration if not exists
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("ID,Data");
                    for (int i = 1; i <= 550; i++)
                    {
                        sw.WriteLine($"{i},Some random data for record {i}");
                    }
                }
            }

            try
            {
                int totalProcessed = 0;
                int chunkSize = 100;
                
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip header
                    
                    while (!reader.EndOfStream)
                    {
                        int currentChunkCount = 0;
                        while (currentChunkCount < chunkSize && reader.ReadLine() != null)
                        {
                            currentChunkCount++;
                            totalProcessed++;
                        }
                        Console.WriteLine($"Processed {totalProcessed} records so far...");
                    }
                }
                Console.WriteLine("Finished processing large file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

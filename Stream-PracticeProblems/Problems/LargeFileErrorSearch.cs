/*
 * 9. Read a Large File Line by Line
 * Problem Statement: Develop a C# program that efficiently reads a 
 * large text file (500MB+) line by line and prints only lines containing the 
 * word "error". 
 * Requirements: Use StreamReader for efficient reading. Read line-by-line 
 * instead of loading the entire file. Display only lines containing "error" 
 * (case insensitive).
 */
using System;
using System.IO;

namespace StreamPracticeProblems.Problems
{
    public class LargeFileErrorSearch
    {
        public static void Run()
        {
            string logFile = "system_log.txt";

            // Create a sample log file if it doesn't exist
            if (!File.Exists(logFile))
            {
                Console.WriteLine("Generating sample log file...");
                using (StreamWriter sw = new StreamWriter(logFile))
                {
                    sw.WriteLine("INFO: System started.");
                    sw.WriteLine("DEBUG: Checking configurations.");
                    sw.WriteLine("ERROR: Failed to connect to database at 10:05 AM.");
                    sw.WriteLine("INFO: User logged in.");
                    sw.WriteLine("warning: Disk space low.");
                    sw.WriteLine("error: Unauthorized access attempt detected.");
                    sw.WriteLine("INFO: Background task completed.");
                }
            }

            try
            {
                Console.WriteLine($"Searching for lines containing 'error' in {logFile}:\n");

                // Requirement: Use StreamReader for efficient line-by-line reading
                using (StreamReader reader = new StreamReader(logFile))
                {
                    string? line;
                    int lineNumber = 0;
                    bool found = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        // Case-insensitive search for "error"
                        if (line != null && line.Contains("error", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Line {lineNumber}: {line}");
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("No lines containing 'error' were found.");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

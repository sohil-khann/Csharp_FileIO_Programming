/*
 * 10. Merge Two CSV Files
 * Problem Statement: Merge two CSV files (students1.csv and students2.csv) based on ID and create a new file.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CSV_PracticeProblems.Problems
{
    public class MergeCSVFiles
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string file1 = Path.Combine(dirPath, "students1.csv");
            string file2 = Path.Combine(dirPath, "students2.csv");
            string mergedFile = Path.Combine(dirPath, "students_merged.csv");

            // Create sample files
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            if (!File.Exists(file1)) File.WriteAllText(file1, "ID,Name,Age\n1,Alice,20\n2,Bob,21\n3,Charlie,22");
            if (!File.Exists(file2)) File.WriteAllText(file2, "ID,Marks,Grade\n1,85,A\n2,75,B\n3,90,A");

            try
            {
                var dict1 = new Dictionary<string, string>();
                using (StreamReader sr = new StreamReader(file1))
                {
                    sr.ReadLine(); // Skip header
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        dict1[parts[0]] = line;
                    }
                }

                using (StreamWriter sw = new StreamWriter(mergedFile))
                {
                    sw.WriteLine("ID,Name,Age,Marks,Grade");
                    using (StreamReader sr = new StreamReader(file2))
                    {
                        sr.ReadLine(); // Skip header
                        string? line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            string id = parts[0];
                            if (dict1.ContainsKey(id))
                            {
                                sw.WriteLine($"{dict1[id]},{parts[1]},{parts[2]}");
                            }
                        }
                    }
                }
                Console.WriteLine($"Files merged successfully into {Path.GetFileName(mergedFile)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

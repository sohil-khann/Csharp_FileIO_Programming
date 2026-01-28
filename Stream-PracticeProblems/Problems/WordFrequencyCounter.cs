/*
 * 10. Count Words in a File
 * Problem Statement: Write a C# program that counts the number of 
 * words in a given text file and displays the top 5 most frequently 
 * occurring words. 
 * Requirements: Use StreamReader to read the file. Use a 
 * Dictionary<string, int> to count word occurrences. Sort the words based 
 * on frequency and display the top 5.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StreamPracticeProblems.Problems
{
    public class WordFrequencyCounter
    {
        public static void Run()
        {
            string fileName = "word_test.txt";

            // Create a sample file
            File.WriteAllText(fileName, "c# is great. file handling in c# is easy. streams in c# are powerful. c# makes it easy to work with files.");

            try
            {
                Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == null) continue;
                        // Split by common delimiters
                        string[] words = line.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in words)
                        {
                            if (wordCounts.ContainsKey(word))
                                wordCounts[word]++;
                            else
                                wordCounts[word] = 1;
                        }
                    }
                }

                // Sort and get top 5
                var topWords = wordCounts.OrderByDescending(pair => pair.Value).Take(5);

                Console.WriteLine("Top 5 Most Frequent Words:");
                foreach (var pair in topWords)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value} times");
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

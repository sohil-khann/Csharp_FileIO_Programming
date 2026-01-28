/*
 * 15. Encrypt and Decrypt CSV Data
 * Problem Statement: Encrypt sensitive fields (Salary, Email) while writing to CSV and decrypt while reading.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CSV_PracticeProblems.Problems
{
    public class EncryptDecryptCSV
    {
        // Simple Caesar Cipher for demonstration (beginner friendly)
        private static string Encrypt(string text, int key = 3)
        {
            if (string.IsNullOrEmpty(text)) return text;
            StringBuilder sb = new StringBuilder();
            foreach (char c in text) sb.Append((char)(c + key));
            return sb.ToString();
        }

        private static string Decrypt(string text, int key = 3)
        {
            if (string.IsNullOrEmpty(text)) return text;
            StringBuilder sb = new StringBuilder();
            foreach (char c in text) sb.Append((char)(c - key));
            return sb.ToString();
        }

        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "encrypted_data.csv");

            try
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

                // 1. Writing Encrypted Data
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("ID,Email,Salary");
                    sw.WriteLine($"1,{Encrypt("sohil@test.com")},{Encrypt("60000")}");
                    sw.WriteLine($"2,{Encrypt("raj@mail.com")},{Encrypt("50000")}");
                }
                Console.WriteLine("Sensitive data encrypted and saved to CSV.");

                // 2. Reading and Decrypting Data
                Console.WriteLine("\nDecrypted Records:");
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string? header = sr.ReadLine();
                    Console.WriteLine(header);
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var p = line.Split(',');
                        string id = p[0];
                        string email = Decrypt(p[1]);
                        string salary = Decrypt(p[2]);
                        Console.WriteLine($"{id},{email},{salary}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

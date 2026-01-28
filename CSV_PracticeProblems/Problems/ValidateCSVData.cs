/*
 * 8. Validate CSV Data Before Processing
 * Problem Statement: Ensure that the "Email" column follows a valid email format using regex.
 * Ensure that "Phone Numbers" contain exactly 10 digits.
 * Print any invalid rows with an error message.
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSV_PracticeProblems.Problems
{
    public class ValidateCSVData
    {
        public static void Solution()
        {
            string dirPath = "DataFiles";
            string filePath = Path.Combine(dirPath, "contacts.csv");

            // Create sample file
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
                File.WriteAllText(filePath, "Name,Email,Phone\nAlice,alice@test.com,1234567890\nBob,invalid-email,9876543210\nCharlie,charlie@web.com,12345\nDavid,david@mail.org,0000000000");
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string phonePattern = @"^\d{10}$";

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine(); // Skip header
                    int rowNum = 1;
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        rowNum++;
                        string[] parts = line.Split(',');
                        if (parts.Length >= 3)
                        {
                            string email = parts[1].Trim();
                            string phone = parts[2].Trim();

                            bool isEmailValid = Regex.IsMatch(email, emailPattern);
                            bool isPhoneValid = Regex.IsMatch(phone, phonePattern);

                            if (!isEmailValid || !isPhoneValid)
                            {
                                Console.WriteLine($"Row {rowNum} is invalid:");
                                if (!isEmailValid) Console.WriteLine($"  - Invalid Email: {email}");
                                if (!isPhoneValid) Console.WriteLine($"  - Invalid Phone (must be 10 digits): {phone}");
                            }
                        }
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

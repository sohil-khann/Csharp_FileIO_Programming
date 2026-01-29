using System;
using Newtonsoft.Json.Linq;

namespace BasicJsonHandling
{
    /* 1. Create a JSON object for a Student with fields: name, age, and subjects (array). */
    public class CreateJsonObj
    {
        public static void Solution()
        {
            // Create a JSON object
            JObject student = new JObject
            {
                { "name", "Sohil khan" },
                { "age", 20 },
                { "subjects", new JArray("Math", "Science", "History") }
            };

            // Convert to string and print
            string jsonString = student.ToString();
            Console.WriteLine(jsonString);
        }
    }
}
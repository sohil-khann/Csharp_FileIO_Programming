/*
3. Read a JSON file and extract only specific fields (e.g., name, email).
*/
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Nodes;
namespace BasicJsonHandling
{
    public class ReadJsonFile
    {

        public static void Solution()
        {
            // Read JSON file
            string jsonString = File.ReadAllText("./DataFiles/Demo.json");

List<JsonObject> users = JsonSerializer.Deserialize<List<JsonObject>>(jsonString);

            // Extract specific fields
            foreach (var user in users)
            {
                string name = user["name"]?.ToString();
                string email = user["email"]?.ToString();
                Console.WriteLine($"Name: {name}, Email: {email}");
            }
        
        }
    }
}
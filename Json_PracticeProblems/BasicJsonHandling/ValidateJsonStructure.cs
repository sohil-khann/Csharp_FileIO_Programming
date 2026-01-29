/*5. Validate JSON structure using Newtonsoft.Json.Schema.
*//*5. Validate JSON structure using Newtonsoft.Json.Schema.*/
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace BasicJsonHandling
{
    public class ValidateJsonStructure
    {
        public static void Solution()
        {
            // Define a JSON schema
            string schemaJson = @"{
                ""type"": ""object"",
                ""properties"": {
                    ""name"": {""type"": ""string""},
                    ""age"": {""type"": ""integer""},
                    ""email"": {""type"": ""string"", ""format"": ""email""}
                },
                ""required"": [""name"", ""age""]
            }";

            var schema = JSchema.Parse(schemaJson);

            // Define a JSON object to validate
            JObject jsonObj = JObject.Parse(@"{
                ""name"": ""Sohil"",
                ""age"": 30,
                ""email"": ""sohil@example.com""
            }");

            // Validate the JSON object against the schema
            IList<string> errorMessages;
            bool isValid = jsonObj.IsValid(schema, out errorMessages);

            if (isValid)
            {
                Console.WriteLine("JSON is valid.");
            }
            else
            {
                Console.WriteLine("JSON is invalid. Errors:");
                foreach (var error in errorMessages)
                {
                    Console.WriteLine($"- {error}");
                }
            }
        }
    }
}
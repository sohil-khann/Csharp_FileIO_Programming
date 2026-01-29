/*4. Merge two JSON objects into one.
*/
using System;   
using Newtonsoft.Json.Linq;
namespace BasicJsonHandling
{
    public class MergeJsonObj
    {
        public static void Solution()
        {
            // Define two JSON objects
            JObject jsonObj1 = JObject.Parse(@"{
                'name': 'Sohil',
                'age': 30
            }");

            JObject jsonObj2 = JObject.Parse(@"{
                'email': 'sohil@example.com',
                'phone': '123-456-7890',
                'address': '123 Main St'
            }");

            // Merge the JSON objects
            JObject mergedJson = new JObject();
            foreach (var property in jsonObj1.Properties())
            {
                mergedJson[property.Name] = property.Value;
            }
            foreach (var property in jsonObj2.Properties())
            {
                mergedJson[property.Name] = property.Value;
            }

            Console.WriteLine(mergedJson.ToString());
        }
    }
}
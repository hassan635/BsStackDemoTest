using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BsStackDemoTest.Src.Helpers
{
    public static class ConfigManager
    {
        public static string GetTestInputValue(string jsonPathExpression)
        {
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"testConfig.json");
                string testInputs = File.ReadAllText(path);
                JObject parsedInputs = JObject.Parse(testInputs);
                return parsedInputs.SelectToken(jsonPathExpression).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QuickCore.MicroService.Utility
{
    public static class Json
    {
        public static T ReadFromFile<T>(string fileName)
        {
            return ReadFromFile<T>(fileName, Encoding.UTF8);
        }
        public static T ReadFromFile<T>(string fileName,Encoding encoding)
        {
            string jsonText = File.ReadAllText(fileName,encoding);
            return JsonSerializer.Deserialize<T>(jsonText, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}

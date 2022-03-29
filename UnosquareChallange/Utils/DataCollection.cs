using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareChallange.PageObject;

namespace UnosquareChallange.Utils
{
    public static class DataCollection
    {        
        private static string _path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, @"Utils\Search.json");
        public static string GetSearchValue()
        {
            string value;
            using (var reader = new StreamReader(_path))
            {
                value = reader.ReadToEnd();
            }
            return value;
        }

        public static string DeserializeJsonFile(string data)
        {
            Data_Objects.Search value = JsonConvert.DeserializeObject<Data_Objects.Search>(data);
            Console.WriteLine(value.SearchValue);
            string text = value.SearchValue;
            return text;
        }
    }
}

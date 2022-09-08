using EntryTasks.Task2.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntryTasks.Task2.Parsers
{
    class FileParserJson : IWorkWithFile
    {
        string jsonFilePath = @"..\..\..\FilesExtensions\File.json";
        public void WriteToFile(Buket buket)
        {
            using (FileStream fs = new FileStream(jsonFilePath, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var flower in buket)
                {
                    sw.WriteLine(JsonConvert.SerializeObject(flower));
                }
            }
        }
        public void ReadFromFile(Buket buket)
        {
            using (FileStream fs = new FileStream(jsonFilePath, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                JsonConverter[] converters = { new FlowerJSONConverter() };
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var foundFlower = JsonConvert.DeserializeObject<Flower>(line, new JsonSerializerSettings() { Converters = converters });
                    buket.AddFlower(foundFlower.Name);
                }
            }
        }
    }
    class FlowerJSONConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Flower));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["Name"].Value<string>() == "Rose")
                return jo.ToObject<Rose>(serializer);
            if (jo["Name"].Value<string>() == "Tulip")
                return jo.ToObject<Tulip>(serializer);
            if (jo["Name"].Value<string>() == "Violet")
                return jo.ToObject<Violet>(serializer);
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
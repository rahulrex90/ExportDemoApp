using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleApp1.Capterra
{
    public  class CapeterraService<T>
    {
        public IFileReader_Capeterra<T> _client;
        public string _filePath;

        public CapeterraService(IFileReader_Capeterra<T> client, string filePath)
        {
            _client = client;
            _filePath = filePath;


        }

        public List<T> GetData()
        {
            var data = _client.ReadFile(_filePath);
            return data;
        }
    }


    public interface IFileReader_Capeterra<T>
    {

        // all are the abstract methods.
        List<T> ReadFile(string filePath);
    }

    public class ReadYAML<T> : IFileReader_Capeterra<T>
    {
        public List<T> ReadFile(string filePath)
        {
           
            using (var reader = new StreamReader(filePath))
            {
                var deserializer = new DeserializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                var fileContent = reader.ReadToEnd();
                var feedList = deserializer.Deserialize<List<T>>(fileContent);

                return feedList;
                // the rest
            }
        }
    }

    public class ReadJson<T> : IFileReader_Capeterra<T>
    {
        List<T> IFileReader_Capeterra<T>.ReadFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
                // the rest
            }
        }
    }

    public class ReadCSV<T> : IFileReader_Capeterra<T>
    {
        public List<T> ReadFile(string filePath)
        {
            // Code to read CSV Files
            throw new NotImplementedException();
        }
    }
}

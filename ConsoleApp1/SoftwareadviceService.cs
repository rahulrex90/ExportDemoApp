using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;

    namespace ConsoleApp1.SoftwareAdvice
    {
        public class SoftwareAdviceService<t>
        {
            public IFileReader_SA<t> _client;
            public string _filePath;

            public SoftwareAdviceService(IFileReader_SA<t> client, string filePath)
            {
                _client = client;
                _filePath = filePath;
            }

            public t GetData()
            {
                var data = _client.ReadFile(_filePath);
                return data;
            }
        }


        public interface IFileReader_SA<T>
        {

            // all are the abstract methods.
            T ReadFile(string filePath);
        }


        public class ReadJson<T> : IFileReader_SA<T>
        {
            T IFileReader_SA<T>.ReadFile(string filePath)
            {
                using (var reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<T>(json);
                    return items;
                    // the rest
                }
            }
        }

        public class ReadCSV<T> : IFileReader_SA<T>
        {
            public T ReadFile(string filePath)
            {
                throw new NotImplementedException();
            }
        }
        public class ReadYAML<T> : IFileReader_SA<T>
        {
            public T ReadFile(string filePath)
            {
                throw new NotImplementedException();
            }
        }
    }

}

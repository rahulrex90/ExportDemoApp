using ConsoleApp1.ConsoleApp1.SoftwareAdvice;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SAFactory
    {
        string _fileExtention;
        public SAFactory(string fileExtention)
        {
            _fileExtention = fileExtention;
        }

        public IFileReader_SA<Root> GetFileInstance()
        {
            switch (_fileExtention)
            {
                case ".yaml":
                    return new ReadYAML<Root>();
                case ".json":
                    return new ReadJson<Root>();
                case ".csv ":
                    return new ReadCSV<Root>();
                default:
                    return new ReadYAML<Root>();
            }

        }
    }
}

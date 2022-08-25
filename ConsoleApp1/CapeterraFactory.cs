using ConsoleApp1.Capterra;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CapeterraFactory
    {
        string _fileExtention;
        public CapeterraFactory(string fileExtention)
        {
            _fileExtention = fileExtention;
        }

        public IFileReader_Capeterra<feed> GetFileInstance() 
        {
            switch (_fileExtention)
            {
                case ".yaml":
                    return new ReadYAML<feed>();
                case ".json":
                    return new ReadJson<feed>();
                case ".csv ":
                    return new ReadCSV<feed>();
                default:
                    return new ReadYAML<feed>();                    
            }
            
        }
    }
}

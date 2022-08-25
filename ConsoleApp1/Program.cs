using ConsoleApp1.Capterra;
using ConsoleApp1.ConsoleApp1.SoftwareAdvice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleApp1
{
    public class Program
    {

        static void Main(string[] args)
        {
            var startService = new Startup();
            startService.StartProcess();
        }

      
    }




}

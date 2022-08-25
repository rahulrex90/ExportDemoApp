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
    public class Startup
    {
        public Startup()
        {

        }
        public bool StartProcess()
        {
            bool continuepar = false;
            string sourceType, filename, fileExtension, filePath = null;
            var feedData = new List<feed>();
            var productData = new List<Product>();
            Console.WriteLine("Please Choose The Source Site");
            Console.WriteLine("Press 1 for Capterra  or  2  for Softwareadvice ");

            try
            {
                do
                {
                    sourceType = Console.ReadLine();
                    if (sourceType.ToLower() == "1" || sourceType.ToLower() == "2")
                    {

                        continuepar = true;

                        Console.WriteLine("Please enter a valid file path");
                        filePath = Console.ReadLine();

                        filename = Path.GetFileName(filePath);
                        fileExtension = Path.GetExtension(filePath);
                        if (sourceType.ToLower() == "1") //  for  Capterra
                        {
                            var factoryInstance = new CapeterraFactory(fileExtension.ToLower());
                            var fileInstance = factoryInstance.GetFileInstance();
                            CapeterraService<feed> businessLogic = new CapeterraService<feed>(fileInstance, filePath);
                            feedData = businessLogic.GetData();

                        }
                        else if (sourceType.ToLower() == "2") //  for  Softadvice
                        {
                            var factoryInstance = new SAFactory(fileExtension.ToLower());
                            var fileInstance = factoryInstance.GetFileInstance();
                            SoftwareAdviceService<Root> businessLogic = new SoftwareAdviceService<Root>(fileInstance, filePath);
                            productData = businessLogic.GetData().products;
                        }

                        printDataToConsole(sourceType, feedData, productData);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1 or 2.");
                    }

                }
                while (continuepar == false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }

        }
        private static void
            printDataToConsole(string sourceType, List<feed> feedData, List<Product> productData)
        {
            if (sourceType == "1")
            {
                // print feed Data

                foreach (var item in feedData)
                {
                    Console.WriteLine($"importing Feed: Name: {item.name};  Categories: {item.tags}, Development Tools; Twitter: {item.twitter}");
                    Console.WriteLine("********************************************************************************************************");

                }
            }
            else
            {
                // print product Data
                foreach (var item in productData)
                {
                    Console.WriteLine($"importing Product: Title: {item.title};  Categories: {string.Join(",", item.categories)}, Development Tools; Twitter: {item.twitter}");
                    Console.WriteLine("********************************************************************************************************");
                }
            }
        }
    }
}

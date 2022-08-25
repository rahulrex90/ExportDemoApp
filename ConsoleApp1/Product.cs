using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public List<string> categories { get; set; }
        public string twitter { get; set; }
        public string title { get; set; }
    }

    public class Root
    {
        public List<Product> products { get; set; }
    }
}

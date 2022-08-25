using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExportDemo_TestProject
{
    public class StartupTest
    {
        [SetUp]
        public void Setup() {
        
        }

        [Test]
        public void Test_Startup_Called() {
            var startUpobj = new Startup();
            Assert.That(startUpobj, !Is.Null);
        }

        [Test]
        public void Test_Startup_StartProcess_Called()
        {
            var startUpobj = new Startup();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("E:/Workspace/Fw__Demo_Library/capterra.yaml");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);
            var result = startUpobj.StartProcess();
            Assert.That(startUpobj, !Is.Null);
        }

        [Test]
        public void Test_Startup_StartProcess_WithInvalidSource()
        {
            var startUpobj = new Startup();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("3");
            stringBuilder.AppendLine("E:/Workspace/Fw__Demo_Library/capterra.yaml");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);

            var result = startUpobj.StartProcess();
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void Test_Startup_StartProcess_WithInvalidFilePath()
        {
            var startUpobj = new Startup();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("E:/Workspace/Fw__Demo_Library/capterra.xxxx");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);

            var result = startUpobj.StartProcess();
            Assert.That(result, Is.EqualTo(false));
        }
        [Test]
        public void Test_Startup_StartProcess_ExecutedSuccessfully()
        {
            var startUpobj = new Startup();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("1");
            stringBuilder.AppendLine("E:/Workspace/Fw__Demo_Library/capterra.yaml");
            var stringReader = new StringReader(stringBuilder.ToString());
            Console.SetIn(stringReader);
    
            var result = startUpobj.StartProcess();
            Assert.That(result, Is.EqualTo(true));
        }

    }
}

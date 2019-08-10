using System;

namespace Parser
{
    class Program
    {
        internal static FileFactory FileFactory { get; set; } // Single Factory For Creating Files.

        static void Main(string[] args)
        {
            //Test (switch is just for testing, there is factory for each type):
            Console.WriteLine("Please Enter Json for Json test and Xml for Xml test");
            string choise = Console.ReadLine().ToLower();

            switch (choise)
            {
                case "json":
                    FileFactory = new JsonFileCreator();
                    var JF = FileFactory.CreateFile(path: "S1.json");
                    Console.WriteLine(JF.ParseFile());
                    break;
                case "xml":
                    FileFactory = new XmlFileCreator();
                    var XF = FileFactory.CreateFile(path: "S2.xml");
                    Console.WriteLine(XF.ParseFile());
                    break;
                default:
                    Console.WriteLine("Invalide Entry...");
                    break;
            }
            Console.ReadKey();
        }
    }
}
